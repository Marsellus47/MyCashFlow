using AutoMapper;
using MyCashFlow.Identity.Context;
using MyCashFlow.Web.ViewModels.Transaction;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MyCashFlow.Web.Services.Transaction
{
	public class ApiTransactionService : IApiTransactionService
	{
		private readonly ApplicationDbContext _dbContext;

		public ApiTransactionService(ApplicationDbContext dbContext)
		{
			if(dbContext == null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			_dbContext = dbContext;
		}

		public async Task<IEnumerable<TransactionIndexItemViewModel>> GetAllAsync(int userId, int? projectId)
		{
			var transactions = await _dbContext.Transactions.Where(x => x.CreatorID == userId).ToListAsync();
			if (projectId.HasValue)
			{
				transactions = transactions.Where(x => x.ProjectID == projectId.Value).ToList();
			}
			var result = Mapper.Map<IEnumerable<TransactionIndexItemViewModel>>(transactions);
			return result;
		}

		public async Task<TransactionDetailsViewModel> GetAsync(int id)
		{
			var transaction = await _dbContext.Transactions.FindAsync(id);
			var result = Mapper.Map<TransactionDetailsViewModel>(transaction);
			return result;
		}

		public async Task<TransactionIndexItemViewModel> Create(TransactionCreateViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_dbContext.Transactions.Add(transaction);
			await _dbContext.SaveChangesAsync();

			var result = Mapper.Map<TransactionIndexItemViewModel>(transaction);
			return result;
		}

		public async Task Edit(TransactionEditViewModel model)
		{
			var transaction = Mapper.Map<Domains.DataObject.Transaction>(model);
			_dbContext.Entry(transaction).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var transaction = await _dbContext.Transactions.FindAsync(id);
			_dbContext.Transactions.Remove(transaction);
			await _dbContext.SaveChangesAsync();
		}
	}
}