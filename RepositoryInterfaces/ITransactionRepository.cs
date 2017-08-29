using System.Collections.Generic;

namespace RepositoryInterfaces
{
  using System;

  using Database;

  using Repository;

  public interface ITransactionRepository : IBaseRepository<Transaction>
  {
    IList<Transaction> GetByMemberId(int memberId);
    Transaction GetByPaymentRef(string paymentRef);
    Transaction GetByPaymentGuid(string paymentGuid);
    IList<Transaction> GetByMemberPaymentStatus(int memberId,string status);

    IList<Transaction> GetAllByPaymentStatus(string paymentStatus);

    Transaction AddTransaction(Transaction newtTransaction);
  }
}
