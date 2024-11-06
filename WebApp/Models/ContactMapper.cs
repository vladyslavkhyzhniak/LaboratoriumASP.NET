namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel arg)
    {
        return new ContactEntity()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            PhoneNumber = arg.PhoneNumber,
            Birth = arg.Birth,
            Email = arg.Email,
            Category = arg.Category,
        };
    }

    public static ContactModel FromEntity(ContactEntity arg)
    {
        return new ContactModel()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            PhoneNumber = arg.PhoneNumber,
            Birth = arg.Birth,
            Email = arg.Email,
            Category = arg.Category,
        };
    }
}