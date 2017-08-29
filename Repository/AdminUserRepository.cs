namespace Repository
{
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Linq;

  using Database;

  using RepositoryInterfaces;

  public class AdminUserRepository:BaseRepository<AdminUser>, IAdminUserRepostitory
  {
    private readonly WisepayContext context;

    public AdminUserRepository(WisepayContext context)
            : base(context)
        {
    }
    //public AdminUserRepository(WisepayContext context)
    //{
    //  this.context = context;
    //}
   public IList<AdminUser> GetAll()
   {
      //return this.context.AdminUsers.ToList();
     return this.Entities.ToList();
   }

    public AdminUser GetById(int id)
    {
      return this.Entities.FirstOrDefault(s => s.Id.Equals(id) && s.IsActive);
    }

    public AdminUser GetByAdminUser(AdminUser adminUser)
    {
     return this.Entities.FirstOrDefault(s => s.FirstName.Equals(adminUser.FirstName) && s.LastName.Equals(adminUser.LastName) && s.UserName.Equals(adminUser.UserName) && s.Password.Equals(adminUser.Password) && s.IsActive);
    }

    public AdminUser GetByAdminLogInCredentials(string userName, string password)
    {
     return this.Entities.FirstOrDefault(s =>s.UserName.Equals(userName) && s.Password.Equals(password) && s.IsActive);

    }

    public AdminUser AddAdminUser(AdminUser newAdminUser)
    {
       return this.Create(newAdminUser);
    }
  }
}
