using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  using System.Data.Entity;

  using Database;

  using RepositoryInterfaces;
  public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
  {
    private readonly WisepayContext context;

    public TransactionRepository(WisepayContext dataDbContext) : base(dataDbContext)
    {

    }

    public IList<Transaction> GetByMemberId(int memberId)
    {
      return this.Entities.Where(r=>r.MemberId.Equals(memberId)).ToList();
    }

    public Transaction GetByPaymentRef(string paymentRef)
    {
      return this.Entities.FirstOrDefault(s => s.PaymentRef.Equals(paymentRef));
    }

    public Transaction GetByPaymentGuid(string paymentGuid)
    {
      return this.Entities.FirstOrDefault(s => s.PaymentGuid.Equals(paymentGuid));

    }

    public IList<Transaction> GetByMemberPaymentStatus(int memberId, string status)
    {
      return this.Entities.Where(s => s.MemberId.Equals(memberId) && s.PaymentStatus.Equals(status)).ToList();
    }

    public IList<Transaction> GetAllByPaymentStatus(string paymentStatus)
    {
      return this.Entities.Where(s => s.PaymentStatus.Equals(paymentStatus)).ToList();
    }

    public Transaction AddTransaction(Transaction newtTransaction)
    {
      return this.Create(newtTransaction);
    }
  }
}
