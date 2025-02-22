﻿namespace CP.Api.Services;

public class UpdateHubService : IUpdateHubService
{
    private readonly HttpClient _updateClient;

    public UpdateHubService(string updateHubUrl)
    {
        _updateClient = new HttpClient {BaseAddress = new Uri(updateHubUrl)};
    }

    public void NotifyCategoryUpdate(int categoryId)
    {
        _updateClient.PostAsJsonAsync("",
            new {MethodName = "updateCategory", Message = "Update Category", Data = categoryId.ToString()});
    }

    public void NotifyCommentUpdate(int commentId)
    {
        _updateClient.PostAsJsonAsync("",
            new {MethodName = "updateComment", Message = "Update Comment", Data = commentId.ToString()});
    }

    public void NotifyVoteCountUpdate(int commentId)
    {
        _updateClient.PostAsJsonAsync("",
            new {MethodName = "updateVote", Message = "Update Vote Of Comment", Data = commentId.ToString()});
    }
}

public interface IUpdateHubService
{
    void NotifyCategoryUpdate(int categoryId);
    void NotifyCommentUpdate(int commentId);
    void NotifyVoteCountUpdate(int commentId);
}