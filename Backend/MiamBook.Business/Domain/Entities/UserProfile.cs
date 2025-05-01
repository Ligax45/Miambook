using System.Collections.Generic;

namespace MiamBook.Business.Domain.Entities;

public class UserProfile
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public ICollection<Comment> Comments { get; set; }
}
