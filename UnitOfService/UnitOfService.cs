using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfService
{
  using UnitOfWork;

  using WisepayServiceInterfaces;

  using WisepayServices;

  public  class UnitOfService:IUnitOfService
  {
    private IAdminUserService adminUserService;

    private IInstituteService instituteService;
    private IMemberService memberService;
    private ITransactionService transactionService;


    private readonly IUnitOfWork unitOfWork;

    public UnitOfService(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public IAdminUserService AdminUserService => this.adminUserService ?? (this.adminUserService = new AdminUserService(this.unitOfWork));
    public IInstituteService InstituteService => this.instituteService ?? (this.instituteService = new InstituteService(this.unitOfWork));
    public IMemberService MemberService => this.memberService ?? (this.memberService = new MemberService(this.unitOfWork));
    public ITransactionService TransactionService => this.transactionService ?? (this.transactionService = new TransactionService(this.unitOfWork));

    public void SaveChanges()
    {
      this.unitOfWork.SaveChanges();
    }
  }
}
