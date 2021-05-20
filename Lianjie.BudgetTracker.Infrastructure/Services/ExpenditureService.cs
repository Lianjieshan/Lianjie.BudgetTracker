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
    public class ExpenditureService : IExpenditureService
    {
        private readonly IAsyncRepository<Expenditure> _expenditureRepository;

        public ExpenditureService(IAsyncRepository<Expenditure> expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }

        public async Task AddExpenditure(ExpenditureRequestModel expenditureRequest)
        {
            var expenditure = new Expenditure
            {
                UserId = expenditureRequest.UserId,
                Amount = expenditureRequest.Amount,
                Description = expenditureRequest.Description,
                ExpDate = expenditureRequest.ExpDate,
                Remarks = expenditureRequest.Remarks
            };
            await _expenditureRepository.AddAsync(expenditure);
        }

        public async Task DeleteExpenditure(int id)
        {
            var expenditure = await _expenditureRepository.ListAsync(e => e.Id == id);
            await _expenditureRepository.DeleteAsync(expenditure.First());
        }


        public async Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expenditureRequest)
        {
            var expenditure = new Expenditure
            {
                UserId = expenditureRequest.UserId,
                Amount = expenditureRequest.Amount,
                Description = expenditureRequest.Description,
                ExpDate = expenditureRequest.ExpDate,
                Remarks = expenditureRequest.Remarks,
            };
            var updateExpenditure = await _expenditureRepository.UpdateAsync(expenditure);
            var response = new ExpenditureResponseModel
            {
                UserId = expenditure.UserId,
                Amount = expenditure.Amount,
                Description = expenditure.Description,
                ExpDate = expenditure.ExpDate,
                Remarks = expenditure.Remarks,
            };
            return response;
        }


        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpendituresByUser(int id)
        {
            var expenditures = await _expenditureRepository.ListAsync(e => e.UserId == id);
            var response = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                response.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks,
                });
            }
            return response;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures()
        {
            var expenditures = await _expenditureRepository.ListAllAsync();
            var response = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                response.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = (decimal)expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks,
                });
            }
            return response;
        }

    }
}
