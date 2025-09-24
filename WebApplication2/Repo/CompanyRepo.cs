using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entity;
using WebApplication2.Repo.Interface;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Repo;

public class CompanyRepo : ICompanyRepo
{
    private readonly ApplicationDbContext _context;

    public CompanyRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyDto?> GetCompanyData()
    {
        var entity = await _context.Companies.FirstOrDefaultAsync();
        return MapToCompanyDto(entity);
    }

    public CompanyDto MapToCompanyDto(Company entity)
    {
        return new CompanyDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}