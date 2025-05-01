using System;

namespace MiamBook.Business.Domain.Entities;

public class Comment
{
    public int Id { get; set; }

    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public int RecipeId { get; set; }

    public int UserProfileId { get; set; }

    public Recipe Recipe { get; set; }

    public UserProfile UserProfile { get; set; }
}
