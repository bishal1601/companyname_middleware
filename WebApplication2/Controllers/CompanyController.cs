using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repo.Interface;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers;

public class CompanyController : Controller
{
    private readonly ICompanyRepo _companyRepo;
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyRepo companyRepo, ICompanyService companyService)
    {
        _companyRepo = companyRepo;
        _companyService = companyService;
    }

    // GET
    public async Task<IActionResult> Update()
    {
        var company = await _companyRepo.GetCompanyData();
        return View(company);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CompanyDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return View(dto);
            await _companyService.Update(dto);
            return Redirect("/");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}