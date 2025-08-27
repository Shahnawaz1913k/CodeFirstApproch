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
    [ValidateAntiForgeryToken]
     public async Task<IActionResult> Create(Student std)
    {
        if(ModelState.IsValid){
            await studentDB.Students.AddAsync(std);
            await studentDB.SaveChangesAsync();
            TempData["success"] = "Student record created successfully";
            return RedirectToAction("Index", "Home");
        }
        return View(std); 
    }

    public async Task<IActionResult> Details(int id)
    {
        var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        return View(stdData);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var stddata = await studentDB.Students.FindAsync(id);
        return View(stddata);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student std)
    {
        if(ModelState.IsValid){
            studentDB.Students.Update(std);
            await studentDB.SaveChangesAsync();
            TempData["Update_success"] = "Student record updated successfully";
            return RedirectToAction("Index", "Home");
        }
        return View(std); 
    }
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int? id)
    {
        var stddata = await studentDB.Students.FindAsync(id);
        if(stddata != null){
            studentDB.Students.Remove(stddata);
            await studentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(stddata);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
