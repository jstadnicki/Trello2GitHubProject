namespace Trello2GitHubProject.Trello
{
    using System;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class TrelloAction
    {
        public string Id { get; set; }

        public TrelloActionData Data { get; set; }

        public TrelloActionTypes Type { get; set; }
        public DateTime Date { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrelloActionTypes
    {
        Unknown,
        CreateCard,
        UpdateCard,
        AddMemberToBoard,
        CommentCard,
        AddChecklistToCard,
        DeleteCard,
        UpdateList,
        CreateList,
        UpdateCheckItemStateOnCard,
        UpdateBoard,
        CreateBoard
    }
}