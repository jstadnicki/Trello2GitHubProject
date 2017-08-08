namespace Trello2GitHubProject
{
    using System;

    using Newtonsoft.Json;

    using RestSharp;

    public class GitHubProjectApi : IGitHubProjectApi
    {
        public string Username { get; }

        public string Projectname { get; }

        public string Token { get; }

        public GitHubProjectApi(string username, string projectname, string token)
        {
            this.Username = username;
            this.Projectname = projectname;
            this.Token = token;
        }

        public int CreateProject(RestClient restClient, string name, string description = "")
        {
            var restRequest = new RestRequest(new Uri($"/repos/{this.Username}/{this.Projectname}/projects", UriKind.Relative), Method.POST);

            restRequest.AddHeader("Authorization", $"token {this.Token}");
            restRequest.AddHeader("Accept", "application/vnd.github.inertia-preview+json");

            var o = new { name = name, body = description };
            restRequest.AddJsonBody(o);
            var restResponse = restClient.Execute(restRequest);
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(restResponse.Content);

            return (int)json["id"];

        }

        public void CreateList()
        {
            throw new NotImplementedException();
        }

        public void CreateTask()
        {
            throw new NotImplementedException();
        }

        public int CreateList(RestClient restClient, int projectId, string listName)
        {
            var restRequest = new RestRequest(new Uri($"/projects/{projectId}/columns", UriKind.Relative), Method.POST);

            restRequest.AddHeader("Authorization", $"token {this.Token}");
            restRequest.AddHeader("Accept", "application/vnd.github.inertia-preview+json");

            var o = new { name = listName };
            restRequest.AddJsonBody(o);
            var restResponse = restClient.Execute(restRequest);
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(restResponse.Content);

            return (int)json["id"];
        }

        public int CreateCard(RestClient restClient, int listid, string cardName)
        {
            var restRequest = new RestRequest(new Uri($"/projects/columns/{listid}/cards", UriKind.Relative), Method.POST);

            restRequest.AddHeader("Authorization", $"token {this.Token}");
            restRequest.AddHeader("Accept", "application/vnd.github.inertia-preview+json");

            var o = new { note = cardName };
            restRequest.AddJsonBody(o);
            var restResponse = restClient.Execute(restRequest);
            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(restResponse.Content);

            return (int)json["id"];
        }
    }
}