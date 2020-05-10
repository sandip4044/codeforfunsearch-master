using System.Collections.Generic;
using System.Threading.Tasks;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.Business.Abstract.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetAsync(int id);
        Task<List<Customer>> GetListAsync();


        void AddAsync(Customer entity);
        void AddRangeAsync(List<Customer> entities);


        void UpdateAsync(Customer entity);
        void UpdateRangeAsync(List<Customer> entities);


        void DeleteAsync(int id);
        void DeleteRangeAsync(IEnumerable<int> ids);
    }
}