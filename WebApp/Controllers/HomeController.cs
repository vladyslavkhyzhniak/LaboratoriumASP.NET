using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
      //  var op = Request.Query["op"];
      //  var  x = double.Parse(Request.Query["x"]) ;
      //  var  y = double.Parse(Request.Query["y"]) ;

      if (x is null || y is null)
      {
          ViewBag.ErrorMessage = "Niepoprawny format liczby x lub y!";
          return View("CalculatorError");
      }

      if (op is null)
      {
          ViewBag.ErrorMessage = "Niepoprawny format operatora!";
          return View("CalculatorError");
      }
        double? result = 0.0d;
        
        switch (op)
        {
            case Operator.Add:
                result = x + y;
                ViewBag.op = "+";
                break;
            case Operator.Sub:
                result = x - y;
                ViewBag.op = "-";
                break;
            case Operator.Mul:
                result = x * y;
                ViewBag.op = "*";
                break;
            case Operator.Div:
                result = x / y;
                ViewBag.op = "/";
                break;
        }

        ViewBag.Result = result;
        ViewBag.x = x;
        ViewBag.y = y;
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add,Sub,Mul,Div
}