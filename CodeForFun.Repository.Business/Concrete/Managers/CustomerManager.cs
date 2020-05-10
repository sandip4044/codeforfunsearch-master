using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeForFun.Repository.Business.Abstract.Services;
using CodeForFun.Repository.DataAccess.Abstract;
using CodeForFun.Repository.Entities.Concrete;

namespace CodeForFun.Repository.Business.Concrete.Managers
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _dal;

        public CustomerManager(ICustomerDal dal)
        {
            _dal = dal;
        }


        // GET ASYNC
        public async Task<Customer> GetAsync(int id)
        {
            return await _dal.ReadAsync(p => p.Id == id);
        }

        // GET ALL ASYNC
        public async Task<List<Customer>> GetListAsync()
        {
            return await _dal.ReadListAsync();
        }


        // ADD ASYNC
        public async void AddAsync(Customer entity)
        {
            await Task.Run(() => { _dal.CreateAsync(entity); });
        }

        // ADD RANGE ASYNC
        public async void AddRangeAsync(List<Customer> entities)
        {
            await Task.Run(() => { _dal.CreateRangeAsync(entities); });
        }


        // UPDATE ASYNC
        public async void UpdateAsync(Customer entity)
        {
            await Task.Run(() => { _dal.UpdateAsync(entity); });
        }

        // UPDATE RANGE ASYNC
        public async void UpdateRangeAsync(List<Customer> entities)
        {
            await Task.Run(() => { _dal.UpdateRangeAsync(entities); });
        }


        // DELETE ASYNC
        public async void DeleteAsync(int id)
        {
            await Task.Run(() => { _dal.DeleteAsync(new Customer {Id = id}); });
        }

        // DELETE RANGE ASYNC
        public async void DeleteRangeAsync(IEnumerable<int> ids)
        {
            await Task.Run(() => { _dal.DeleteRange(ids.Select(id => new Customer{Id = id}).ToList()); });
        }
    }
}