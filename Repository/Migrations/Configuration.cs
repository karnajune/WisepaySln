using System;

namespace Repository
{
  using System.Data.Entity.Migrations;

  using Database;

  internal sealed class Configuration : DbMigrationsConfiguration<WisepayContext>
  {
    public Configuration()
    {
      this.AutomaticMigrationsEnabled = true;


      this.AutomaticMigrationDataLossAllowed = false;
    }

    //protected override void Seed(WisepayContext context)
    //{
    //  var admins = new AdminUser
    //  {
    //    FirstName = "testfirstname",
    //    LastName = "testlastname",
    //    UserName = "wisepay",
    //    Password = "wisepay",
    //    Comments = "Some Additional Comments",
    //    Registereddate = DateTime.Now,
    //    RoleExpirtyDate = DateTime.Now.AddDays(10),
    //    IsActive = true
    //  };


    //  context.AdminUsers.Add(admins);
    //}
  }
}
