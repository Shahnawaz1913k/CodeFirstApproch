using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Controllers;

public class HomeController : Controller
{
    private readonly StudentDBContext studentDB;
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public HomeController(StudentDBContext studentDB)
    {
        this.studentDB = studentDB;
    }

    public IActionResult Index()
    {
        var stdData = studentDB.Students.ToList();
        return View(stdData);
    }

    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
     public async Task<IActionResult> Create(Student std)
    {
        if(ModelState.IsValid){
            await studentDB.Students.AddAsync(std);
            await studentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(std); 
    }

    public async Task<IActionResult> Details(int id)
    {
        var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        return View(stdData);
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
