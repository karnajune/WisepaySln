using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfService
{
  using WisepayServiceInterfaces;

  public interface IUnitOfService
  {
    IAdminUserService AdminUserService { get; }
    IInstituteService InstituteService { get; }

    IMemberService MemberService{ get; }
    ITransactionService TransactionService{ get; }

    void SaveChanges();
  }
}
