using System;
using System.Collections.Generic;

namespace WisepayServiceInterfaces
{
  using Database;

  public interface IAdminUserService
    {
    IList<AdminUser> GetAll();

    AdminUser GetById(Int32 id);

    AdminUser AdminAuthenticate(string userName, string password);

    void Update(AdminUser admin);

    string AddAdminUser(AdminUser newAdminUser);
    }
}
