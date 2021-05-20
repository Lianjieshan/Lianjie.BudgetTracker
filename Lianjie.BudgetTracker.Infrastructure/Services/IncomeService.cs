using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;
using Lianjie.BudgetTracker.ApplicationCore.Models.Request;
using Lianjie.BudgetTracker.ApplicationCore.Models.Response;
using Lianjie.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Lianjie.BudgetTracker.Infrastructure.Repositories;

namespace Lianjie.BudgetTracker.Infrastructure.Services
{
    public class IncomeService : IIncomeService
    {

        private readonly IAsyncRepository<Income> _incomeRepository;

        public IncomeService(IAsyncRepository<Income> incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task AddIncome(IncomeRequestModel incomeRequest)
        {
            var income = new Income
            {
                UserId = incomeRequest.UserId,
                Amount = incomeRequest.Amount,
                Description = incomeRequest.Description,
                IncomeDate = incomeRequest.IncomeDate,
                Remarks = incomeRequest.Remarks,
            };
            await _incomeRepository.AddAsync(income);
        }

        public async Task DeleteIncome(int id)
        {
            var income = await _incomeRepository.ListAsync(e => e.Id == id);
            await _incomeRepository.DeleteAsync(income.First());
        }


        public async Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequest)
        {
            var income = new Income
            {
                UserId = incomeRequest.UserId,
                Amount = incomeRequest.Amount,
                Description = incomeRequest.Description,
                IncomeDate = incomeRequest.IncomeDate,
                Remarks = incomeRequest.Remarks,
            };
            var updateIncome = await _incomeRepository.UpdateAsync(income);
            var response = new IncomeResponseModel
            {
                UserId = income.UserId,
                Amount = income.Amount,
                Description = income.Description,
                IncomeDate = income.IncomeDate,
                Remarks = income.Remarks,
            };
            return response;
        }


        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomesByUser(int id)
        {
            var incomes = await _incomeRepository.ListAsync(e => e.UserId == id);
            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = (decimal)income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks,
                });
            }
            return response;
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomes()
        {
            var incomes = await _incomeRepository.ListAllAsync();
            var response = new List<IncomeResponseModel>();
            foreach (var income in incomes)
            {
                response.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks,
                });
            }
            return response;
        }


    }
}
