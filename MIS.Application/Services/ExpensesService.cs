using AutoMapper;
using MIS.Application.DTOs.Expenses;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.ExpensesSpec;
using MIS.Domain.Entities;
using MIS.Domain.Entities.AuditLogging;
using MIS.Domain.Enums;
using MIS.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class ExpensesService : GenericService<Expenses, ExpensesDTO, ExpensesInfoDTO>, IExpensesService
    {
        private readonly IRepository<ExpensesLog> _expensesLogRepo;
        private readonly ICurrentUserService _currentUserService;

        public ExpensesService(IRepository<Expenses> repo,
                               IMapper mapper,
                               IRepository<ExpensesLog> expensesLogRepo,
                               ICurrentUserService currentUserService) : base(repo, mapper)
        {
            _expensesLogRepo = expensesLogRepo;
            _currentUserService = currentUserService;
        }

        public async Task<ExpensesInfoDTO> AddExpenseAsync(ExpensesDTO expensesDTO)
        {
            var expense = _mapper.Map<Expenses>(expensesDTO);
            var addedExpense = await _repo.AddAsync(expense);

            var expensesLog = _mapper.Map<ExpensesLog>(expensesDTO);
            expensesLog.Date = addedExpense.Date;
            expensesLog.User = _currentUserService.GetUserName();
            expensesLog.EventTime = DateTime.Now;
            expensesLog.OperationType = OperationType.Create;
            await _expensesLogRepo.AddAsync(expensesLog);

            return await GetEntityInfoSpecAsync(new ExpensesWithIncludesSpec(expense.Id));
        }

        public async Task<ExpensesInfoDTO> UpdateExpenseAsync(int id, ExpensesDTO expensesDTO)
        {
            var expense = await _repo.GetBySpecAsync(new ExpensesWithIncludesSpec(id));
            var updatedExpense = _mapper.Map(expensesDTO, expense);
            await _repo.UpdateAsync(updatedExpense);

            var expensesLog = new ExpensesLog
            {
                Date = expense.Date,
                Amount = updatedExpense.Amount,
                PaymentType = updatedExpense.PaymentType,
                Comment = updatedExpense.Comment,
                BranchId = updatedExpense.BranchId,
                Item = updatedExpense.Item,
                User = _currentUserService.GetUserName(),
                EventTime = DateTime.Now,
                OperationType = OperationType.Update
            };
            
            await _expensesLogRepo.AddAsync(expensesLog);

            return await GetEntityInfoAsync(updatedExpense.Id);
        }
    }
}
