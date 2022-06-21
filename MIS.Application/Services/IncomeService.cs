using AutoMapper;
using MIS.Application.DTOs.Income;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities;
using MIS.Domain.Entities.AuditLogging;
using MIS.Shared.Interfaces;
using System;
using System.Threading.Tasks;
using MIS.Domain.Enums;
using MIS.Application.Specifications.IncomeSpec;

namespace MIS.Application.Services
{
    public class IncomeService : GenericService<Income, IncomeDTO, IncomeInfoDTO>, IIncomeService
    {
        private readonly IRepository<IncomeLog> _incomeLogRepo;
        private readonly ICurrentUserService _currentUserService;

        public IncomeService(IRepository<Income> incomeRepo,                              
                             IMapper mapper,
                             IRepository<IncomeLog> incomeLogRepo,
                             ICurrentUserService currentUserService) : base(incomeRepo, mapper)
        {
            _incomeLogRepo = incomeLogRepo;
            _currentUserService = currentUserService;
        }

        public async Task<IncomeInfoDTO> AddIncomeAsync(IncomeDTO incomeDTO)
        {
            var income = _mapper.Map<Income>(incomeDTO);
            var addedIncome = await _repo.AddAsync(income);
            
            var incomeLog = _mapper.Map<IncomeLog>(incomeDTO);
            incomeLog.Date = addedIncome.Date;
            incomeLog.User = _currentUserService.GetUserName();
            incomeLog.EventTime = DateTime.Now;
            incomeLog.OperationType = OperationType.Create;
            await _incomeLogRepo.AddAsync(incomeLog);

            return await GetEntityInfoSpecAsync(new IncomeWithIncludesSpec(income.Id));
        }

        public async Task<IncomeInfoDTO> UpdateIncomeAsync(int id, IncomeDTO incomeDTO)
        {
            var income = await _repo.GetBySpecAsync(new IncomeWithIncludesSpec(id));
            var updatedIncome = _mapper.Map(incomeDTO, income);
            await _repo.UpdateAsync(updatedIncome);
            
            var incomeLog = new IncomeLog 
            {
                Date = income.Date,
                Amount = updatedIncome.Amount,
                PaymentType = updatedIncome.PaymentType,
                Comment = updatedIncome.Comment,
                BranchId = updatedIncome.BranchId,
                StudentId = updatedIncome.StudentId,
                GroupId = updatedIncome.GroupId,
                User = _currentUserService.GetUserName(),
                EventTime = DateTime.Now,
                OperationType = OperationType.Update
            };
            
            await _incomeLogRepo.AddAsync(incomeLog);

            return await GetEntityInfoAsync(updatedIncome.Id);
        }
    }
}
