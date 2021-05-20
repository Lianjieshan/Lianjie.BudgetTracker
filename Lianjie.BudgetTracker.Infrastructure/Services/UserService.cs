using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;
using Lianjie.BudgetTracker.ApplicationCore.Exceptions;
using Lianjie.BudgetTracker.ApplicationCore.Models.Request;
using Lianjie.BudgetTracker.ApplicationCore.Models.Response;
using Lianjie.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces;

namespace Lianjie.BudgetTracker.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);
            if (dbUser != null) {

                throw new ConflictException("User Already exists, please try to login");

            }

            var user = new User
            {
                Email = userRegisterRequestModel.Email,
                Password = userRegisterRequestModel.Password,
                FullName = userRegisterRequestModel.FullName,
                JoinedOn = userRegisterRequestModel.JoinedOn
            };
            var createdUser = await _userRepository.AddAsync(user);

            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,
            };
            return response;
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            var isSuccess = user.Password == password;
            var response = new UserLoginResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                JoinedOn = user.JoinedOn,
                Password = user.Password
            };
            return response;
        }


        public async Task<UserRegisterResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new
                    NotFoundException("User not found!");

            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,

            };
            return response;
        }


        public async Task<List<UserLoginResponseModel>> GetAllUsersasync()
        {
            var users = await _userRepository.ListAllAsync();

            var list = new List<UserLoginResponseModel>();
            foreach (var user in users)
            {
                list.Add(new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    JoinedOn = user.JoinedOn,
                    Password = user.Password,


                });
            }
            return list;
        }


        public async Task<UserDetailResponseModel> GetUserDetailById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var expenditureList = new List<ExpenditureResponseModel>();
            decimal totalExoenditure = 0;
            decimal totalIncome = 0;
            foreach (var expenditure in user.Expenditures)
            {
                expenditureList.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
                totalExoenditure += expenditure.Amount;
            }
            var IncomeList = new List<IncomeResponseModel>();
            foreach (var income in user.Incomes)
            {
                IncomeList.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
                totalIncome += income.Amount;
            }

            var userDetail = new UserDetailResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                TotalExpenditures = totalExoenditure,
                TotalIncomes = totalIncome,
                Expenditures = expenditureList,
                Incomes = IncomeList
            };
            return userDetail;

        }

        public async Task<UserRequestModel> UpdateUser(UserRequestModel userRequest)
        {
            var user = new User
            {
                Id = userRequest.Id,
                Email = userRequest.Email,
                FullName = userRequest.FullName,
                Password = userRequest.Password,
                JoinedOn = userRequest.JoinedOn
            }; 
            var updatedUser = await _userRepository.UpdateAsync(user);
            var response = new UserRequestModel
            {
                Id = userRequest.Id,
                Email = userRequest.Email,
                FullName = userRequest.FullName,
                Password = userRequest.Password,
                JoinedOn = userRequest.JoinedOn
            };
            return response;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.ListAsync(u => u.Id == id);
            await _userRepository.DeleteAsync(user.First());
        }



    }
}
