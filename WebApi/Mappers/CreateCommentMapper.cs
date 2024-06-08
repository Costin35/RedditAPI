using RedditAPI.Services.Features.Comments;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class CreateCommentMapper
{
    public static CreateCommentDto ToDto(this CreateCommentModel createCommentModel)
    {
        return new CreateCommentDto
        {
            Content = createCommentModel.Content
        };
    }
}