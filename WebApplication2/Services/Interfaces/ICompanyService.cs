using WebApplication2.Entity;

namespace WebApplication2.Services.Interfaces;

public interface ICompanyService
{
    Task<Company> Update(CompanyDto dto);
}

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}