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
    }
}