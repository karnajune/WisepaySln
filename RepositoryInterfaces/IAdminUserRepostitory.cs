using System.Collections.Generic;

namespace RepositoryInterfaces
{
  using System;

  using Database;

  using Repository;

  public interface IAdminUserRepostitory: IBaseRepository<AdminUser>
  {
    IList<AdminUser> GetAll();
    AdminUser GetById(Int32 id);
    AdminUser GetByAdminUser(AdminUser adminUser);
    AdminUser GetByAdminLogInCredentials(string userName,string password);

    AdminUser AddAdminUser(AdminUser newAdminUser);
  }
}
