namespace Trello2GitHubProject.Trello
{
    using System.Collections.Generic;

    public class TrelloCard
    {
        public List<TrelloList> Lists { get; set; }
        public Dictionary<string, string> LabelNames { get; set; }

        public List<TrelloAction> Actions { get; set; }
    }
}