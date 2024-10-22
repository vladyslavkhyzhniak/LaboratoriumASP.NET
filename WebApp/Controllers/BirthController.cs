using LabProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Form()
    {
        return View();
    }

    public IActionResult Result(BirthModel birth)
    {
        if (!birth.IsValid())
        {
            ViewData["Error"] = "Proszę wprowadzić poprawne imię oraz datę urodzenia wcześniejszą niż dzisiaj.";
            return View("Error");
        }

        int age = birth.GetAge();
        ViewBag.Name = birth.Name;
        ViewBag.Age = age;

        return View();
    }
}