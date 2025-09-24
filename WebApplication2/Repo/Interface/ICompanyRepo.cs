using WebApplication2.Entity;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Repo.Interface;

public interface ICompanyRepo
{
    Task<CompanyDto?> GetCompanyData();
}