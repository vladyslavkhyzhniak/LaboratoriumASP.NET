using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    
    
    public IActionResult Result(Calculator model)
    {
        
        return View(model);
    }

    public IActionResult Form()
    {
        return View(); 
    }

    
}