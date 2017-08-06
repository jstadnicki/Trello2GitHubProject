namespace Trello2GitHubProject
{
    using System;

    using RestSharp;

    using Trello2GitHubProject.Trello;

    public class Program
    {
        private static void CreateGitHubProject()
        {
            var restClient = new RestClient();
            restClient.BaseUrl = new Uri("https://api.github.com");

            var gitHubProjectApi = new GitHubProjectApi("jstadnicki", "isthereanynews", "");
            gitHubProjectApi.CreateProject(restClient, "projectname", "long description of project that is being created");
        }

        private static TrelloCard LoadTrello()
        {
            var json = System.IO.File.ReadAllText("c:/_temp/itan.json");
            var card = Newtonsoft.Json.JsonConvert.DeserializeObject<TrelloCard>(json);
            return card;
        }

        static void Main(string[] args)
        {
            // var x = LoadTrello();
            CreateGitHubProject();
        }
    }
}