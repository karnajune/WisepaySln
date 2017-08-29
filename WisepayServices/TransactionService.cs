using System;

namespace WisepayServices
{
  using System.Collections;
  using System.Collections.Generic;

  using Database;

  using UnitOfWork;

  using ViewModels;

  using WisepayServiceInterfaces;

  public class TransactionService : ITransactionService
  {
    private readonly IUnitOfWork unitOfWork;

    public TransactionService(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public IList<TransactionViewModel> GetByMemberId(int memberId)
    {
      var output=new List<TransactionViewModel>();
      var resultFromDb= this.unitOfWork.TransactionRepository.GetByMemberId(memberId);
      foreach (var transaction in resultFromDb)
      {
        output.Add(new TransactionViewModel()
                     {
                       Id = transaction.Id,
                       DoneBy = transaction.TransactionDoneBy,
                       Date=transaction.TransactionDate,
                       Amount = transaction.Amount,
                       PayPalRef = transaction.PaymentGuid,
                       Ref = transaction.PaymentRef,
                       Status = transaction.PaymentStatus
                     });
      }
      return output;
    }

    public Transaction GetByPaymentRef(string paymentRef)
    {
      return this.unitOfWork.TransactionRepository.GetByPaymentRef(paymentRef);

    }

    public Transaction GetByPaymentGuid(string paymentGuid)
    {
      return this.unitOfWork.TransactionRepository.GetByPaymentGuid(paymentGuid);

    }

    public IList<Transaction> GetByMemberPaymentStatus(int memberId, string status)
    {
      return this.unitOfWork.TransactionRepository.GetByMemberPaymentStatus(memberId,status);

    }

    public IList<Transaction> GetAllByPaymentStatus(string paymentStatus)
    {
      return this.unitOfWork.TransactionRepository.GetAllByPaymentStatus(paymentStatus);

    }

    public string AddTransaction(Transaction newtTransaction)
    {
      var newTransaction= this.unitOfWork.TransactionRepository.AddTransaction(newtTransaction);
      if (newTransaction.Id != 0 || newTransaction.Id != -1)
      {
        return "Successfully added New transaction";
      }
      return " Failed to Add New transaction";

    }
  }
}
