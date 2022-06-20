using AutoMapper;
using MIS.Application.DTOs.TotalCashFlow;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.ExpensesSpec;
using MIS.Application.Specifications.IncomeSpec;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using MIS.Application.Specifications.TotalCashFlowSpec;
using System.Globalization;

namespace MIS.Application.Services
{
    public class CashFlowService : ICashFlowService
    {
        private readonly IRepository<TotalCashFlow> _cashFlowRepo;
        private readonly IRepository<Income> _incomeRepo;
        private readonly IRepository<Expenses> _expensesRepo;        
        private readonly IMapper _mapper;

        public CashFlowService(IRepository<TotalCashFlow> cashFlowRepo,
                               IRepository<Income> incomeRepo,
                               IRepository<Expenses> expensesRepo,                               
                               IMapper mapper)
        {
            _cashFlowRepo = cashFlowRepo;
            _incomeRepo = incomeRepo;
            _expensesRepo = expensesRepo;           
            _mapper = mapper;
        }

        public async Task<Dictionary<Branch, decimal>> GetBranchesDailyExpenses()
        {
            Dictionary<Branch, decimal> branchExpenses = new();

            var dailyExpenses = await _expensesRepo.ListAsync(new ExpensesDailySpec());
            var expensesByBranch = dailyExpenses.GroupBy(x => x.Branch).OrderBy(x => x.Key);

            foreach (var expenses in expensesByBranch)
            {
                branchExpenses.Add(expenses.Key, expenses.Sum(x => x.Amount));
            }

            return branchExpenses;
        }

        public async Task<Dictionary<Branch, decimal>> GetBranchesDailyIncome()
        {
            Dictionary<Branch, decimal> branchIncome = new();

            var dailyIncome = await _incomeRepo.ListAsync(new IncomeDailySpec());
            var incomeByBranch = dailyIncome.GroupBy(x => x.Branch).OrderBy(x => x.Key);

            foreach (var income in incomeByBranch)
            {
                branchIncome.Add(income.Key, income.Sum(x => x.Amount));
            }

            return branchIncome;
        }

        public async Task CalculateDailyCashFlowAsync()
        {
            var dailyIncome = await GetBranchesDailyIncome();
            var dailyExpenses = await GetBranchesDailyExpenses();
            var branchesWithIncomeAndExpenses = dailyIncome.Keys.Intersect(dailyExpenses.Keys);            

            List<TotalCashFlow> totalCashFlows = new();
           
            foreach (var branch in branchesWithIncomeAndExpenses)
            {
                var income = dailyIncome[branch];
                var expense = dailyExpenses[branch];

                var totalCashFlow = new TotalCashFlow
                {
                    DateTime = DateTime.Today.Date,
                    Amount = income - expense,
                    BranchId = branch.Id
                };

                totalCashFlows.Add(totalCashFlow);
            }

            await _cashFlowRepo.AddRangeAsync(totalCashFlows);
        }


        public async Task AddDailyIncomeToCashFlow()
        {
            var dailyIncome = await GetBranchesDailyIncome();
            var dailyExpenses = await GetBranchesDailyExpenses();
            var branchesWithOnlyIncome = dailyIncome.Keys.Except(dailyExpenses.Keys);

            List<TotalCashFlow> totalCashFlows = new();

            foreach (var branch in branchesWithOnlyIncome)
            {
                var totalCashFlow = new TotalCashFlow
                {
                    DateTime = DateTime.Today.Date,
                    Amount = dailyIncome[branch],
                    BranchId = branch.Id
                };

                totalCashFlows.Add(totalCashFlow);
            }

            await _cashFlowRepo.AddRangeAsync(totalCashFlows);
        }

        public async Task AddDailyExpensesToCashFlow()
        {
            var dailyIncome = await GetBranchesDailyIncome();
            var dailyExpenses = await GetBranchesDailyExpenses();
            var branchesWithOnlyExpenses = dailyExpenses.Keys.Except(dailyIncome.Keys);

            List<TotalCashFlow> totalCashFlows = new();

            foreach (var branch in branchesWithOnlyExpenses)
            {
                var totalCashFlow = new TotalCashFlow
                {
                    DateTime = DateTime.Today.Date,
                    Amount = dailyIncome[branch] * -1,
                    BranchId = branch.Id
                };

                totalCashFlows.Add(totalCashFlow);
            }

            await _cashFlowRepo.AddRangeAsync(totalCashFlows);
        }

        public async Task<IEnumerable<DailyCashFlowDTO>> GetDailyCashFlowAsync()
        {
            var dailyCashFlows = await _cashFlowRepo.ListAsync(new TotalCashFlowWithBranchSpec());
            return _mapper.Map<IEnumerable<DailyCashFlowDTO>>(dailyCashFlows);
        }

        public async Task<IEnumerable<MonthlyCashFlowDTO>> GetMonthlyCashFlowAsync()
        {
            var dailyCashFlows = await _cashFlowRepo.ListAsync(new TotalCashFlowWithBranchSpec());
            var monthlyCashFlow = dailyCashFlows
                            .GroupBy(x => new
                            {
                                Branch = x.Branch,
                                Month = x.DateTime.Month,
                                Year = x.DateTime.Year                               
                            })
                            .Select(x => new MonthlyCashFlowDTO
                            {
                                Branch = $"{x.Key.Branch.Address} {x.Key.Branch.District}",
                                Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Key.Month),
                                Year = x.Key.Year,                                
                                Amount = x.Sum(a => a.Amount)
                            });
            return monthlyCashFlow;
        }

        public async Task<IEnumerable<YearlyCashFlowDTO>> GetYearlyCashFlowAsync()
        {
            var dailyCashFlows = await _cashFlowRepo.ListAsync(new TotalCashFlowWithBranchSpec());
            var yearlyCashFlow = dailyCashFlows
                            .GroupBy(x => new
                            {
                                Branch = x.Branch,
                                Year = x.DateTime.Year
                            })
                            .Select(x => new YearlyCashFlowDTO
                            {
                                Branch = $"{x.Key.Branch.Address} {x.Key.Branch.District}",
                                Year = x.Key.Year,
                                Amount = x.Sum(a => a.Amount)
                            });
            return yearlyCashFlow;
        }
    }
}
