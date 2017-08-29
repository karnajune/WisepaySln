using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
  public class Member
  {
    public Member()
    {
      this.TransactionsList = new List<Transaction>();
    }
    public Int32 Id { get; set; }

    public int InstituteId { get; set; }

    public virtual Institute Institute { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
    public string Comments { get; set; }

    public DateTime Registereddate { get; set; }

    public DateTime MembershipExpirtyDate { get; set; }
    public Boolean IsActive { get; set; }

    public virtual ICollection<Transaction> TransactionsList { get; set; }
  }
}
