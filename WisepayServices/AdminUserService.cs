using System;

namespace WisepayServices
{
  using System.Collections;
  using System.Collections.Generic;

  using Database;

  using UnitOfWork;

  using WisepayServiceInterfaces;

  public class AdminUserService : IAdminUserService
  {
    private readonly IUnitOfWork unitOfWork;

    public AdminUserService(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }
    public IList<AdminUser> GetAll()
    {
      return this.unitOfWork.AdminUserRepostitory.GetAll();
    }

    public AdminUser AdminAuthenticate(string userName, string password)
    {
      return this.unitOfWork.AdminUserRepostitory.GetByAdminLogInCredentials(userName, password);
    }

    public void Update(AdminUser admin)
    {
      this.unitOfWork.AdminUserRepostitory.Update(admin);
    }

    public string AddAdminUser(AdminUser newAdminUser)
    {
      var adminUserfromDb = this.unitOfWork.AdminUserRepostitory.GetByAdminUser(newAdminUser);
      if (adminUserfromDb != null)
      {
        return "Admin User already exists";
      }
      var newUser=this.unitOfWork.AdminUserRepostitory.AddAdminUser(newAdminUser);
      if (newUser.Id != 0 || newUser.Id != -1)
      {
        return "Successfully added New Admin User";
      }
      return " Failed to Add New Admin User";
    }

    public AdminUser GetById(int id)
    {
      return this.unitOfWork.AdminUserRepostitory.GetById(id);
    }
  }
}
