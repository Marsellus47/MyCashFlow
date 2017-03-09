﻿using MyCashFlow.Web.ViewModels.Transaction;

namespace MyCashFlow.Web.Services.Transaction
{
	public interface ITransactionService
	{
		TransactionIndexViewModel BuildTransactionIndexViewModel(int userId, int? projectId);
		TransactionCreateViewModel BuildTransactionCreateViewModel(int userId, int? projectId);
		void CreateTransaction(TransactionCreateViewModel model);
	}
}
