using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
  public class MemberViewModel
  {
    public Int32 Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Comments { get; set; }
    public DateTime Registered { get; set; }
    public DateTime MembershipExpiryDate { get; set; }

  }
}
