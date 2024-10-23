using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
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
            Birth = new DateOnly(2001,10,10)
            } 
        },
        {2,new ContactModel()
            {
                Id  = 2,
                FirstName = "Adam2",
                LastName = "Babecki2",
                Email = "adam2@wsei.edu.pl",
                PhoneNumber = "112 222 333",
                Birth = new DateOnly(2002,12,12)
            } 
        },
        {3,new ContactModel()
            {
                Id  = 3,
                FirstName = "Adam3",
                LastName = "Babecki3",
                Email = "adam3@wsei.edu.pl",
                PhoneNumber = "113 222 333",
                Birth = new DateOnly(2003,3,13)
            } 
        }
    };

    private static int _currentId = 3;
    
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }
    // Zwraca formularz dodania kontaktu
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    // Odebranie danych z form, zapis kontaktu i powrót do listy
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        // zapisanie dannych
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index");
    }

    public IActionResult Details(int id)
    {
        return View("Details");
    }
}