using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
  public class AdminUser
  {
    public Int32 Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
    public string Comments { get; set; }

    public DateTime Registereddate { get; set; }

    public DateTime RoleExpirtyDate { get; set; }
    public Boolean IsActive { get; set; }
    public Boolean IsCustomer { get; set; }
    public Boolean IsCallCenterUSer { get; set; }
  }
}
