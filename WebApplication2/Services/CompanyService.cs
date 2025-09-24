using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entity;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Services;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _context;

    public CompanyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Company> Update(CompanyDto dto)
    {
        var company = await _context.Companies.FirstOrDefaultAsync();
        company.Name = dto.Name;
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
        return company;

    }
}