namespace Trello2GitHubProject.Trello
{
    using Newtonsoft.Json;

    public class TrelloCard
    {
        public string Id { get; set; }

        [JsonProperty("idList")]
        public string ListId { get; set; }

        public string Name { get; set; }
    }
}