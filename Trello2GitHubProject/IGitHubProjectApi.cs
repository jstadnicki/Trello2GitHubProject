namespace Trello2GitHubProject
{
    using RestSharp;

    public interface IGitHubProjectApi
    {
        int CreateProject(RestClient restClient, string name, string description = "");

        void CreateList();

        void CreateTask();
    }
}