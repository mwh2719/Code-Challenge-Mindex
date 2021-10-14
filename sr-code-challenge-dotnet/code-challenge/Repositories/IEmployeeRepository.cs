using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(String id);

        Employee Add(Employee employee);
        Compensation GetCompensationById(String id);

        Compensation AddCompensation(Compensation compensation);

        Employee Remove(Employee employee);
        Task SaveAsync();
    }
}