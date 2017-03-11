using AutoMapper;
using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.TransactionType;
using System;

namespace MyCashFlow.Web.Services.TransactionType
{
	public class TransactionTypeService : ITransactionTypeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TransactionTypeService(IUnitOfWork unitOfWork)
		{
			if(unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_unitOfWork = unitOfWork;
		}

		public TransactionTypeCreateViewModel BuildTransactionTypeCreateViewModel(string previousUrl)
		{
			var model = new TransactionTypeCreateViewModel
			{
				PreviousUrl = previousUrl
			};
			return model;
		}

		public void CreateTransactionType(TransactionTypeCreateViewModel model)
		{
			var transactionType = Mapper.Map<Domains.DataObject.TransactionType>(model);
			_unitOfWork.TransactionTypeRepository.Insert(transactionType);
			_unitOfWork.Save();
		}
	}
}