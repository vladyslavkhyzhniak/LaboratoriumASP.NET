namespace WebApp.Models.Services;

public class MemoryContactService: IContactService
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1,new ContactModel()
            {
                Id  = 1,
                FirstName = "Adam",
                LastName = "Babecki",
                Email = "adam@wsei.edu.pl",
                PhoneNumber = "111 222 333",
                Birth = new DateOnly(2001,10,10),
                Category = Category.Business
            } 
        },
        {2,new ContactModel()
            {
                Id  = 2,
                FirstName = "Adam2",
                LastName = "Babecki2",
                Email = "adam2@wsei.edu.pl",
                PhoneNumber = "112 222 333",
                Birth = new DateOnly(2002,12,12),
                Category = Category.Family
            } 
        },
        {3,new ContactModel()
            {
                Id  = 3,
                FirstName = "Adam3",
                LastName = "Babecki3",
                Email = "adam3@wsei.edu.pl",
                PhoneNumber = "113 222 333",
                Birth = new DateOnly(2003,3,13),
                Category = Category.Friend
            } 
        }
    };
    private static int _currentId = 3;
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }

    public List<OrganizationEntity> GetAllOrganizations()
    {
        throw new NotImplementedException();
    }
}