namespace Trello2GitHubProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using RestSharp;

    using Trello2GitHubProject.Trello;

    public class Program
    {
        private static void CreateGitHubProject()
        {
            var restClient = new RestClient();
            restClient.BaseUrl = new Uri("https://api.github.com");

            var gitHubProjectApi = new GitHubProjectApi("jstadnicki", "Trello2GitHubProject", "");


            var trello = LoadTrello();

            var projectId = gitHubProjectApi.CreateProject(restClient, "test itan", "long description of project that is being created");
            Dictionary<string, int> trelloGitHubLists = new Dictionary<string, int>();
            foreach (var trelloList in trello.Lists)
            {
                var id = gitHubProjectApi.CreateList(restClient, projectId, trelloList.Name);
                trelloGitHubLists.Add(trelloList.Id, id);
            }

            foreach (var trelloAction in trello.Actions
            .Where(a => a.Data != null)
            .Where(a => a.Data.Card != null)
            .Where(a => !string.IsNullOrWhiteSpace(a.Data.Card.ListId)))
            {
                gitHubProjectApi.CreateCard(restClient, trelloGitHubLists[trelloAction.Data.Card.ListId], trelloAction.Data.Card.Name);
            }

            var listid = gitHubProjectApi.CreateList(restClient, projectId, "list");
            gitHubProjectApi.CreateCard(restClient, listid, "card name");

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