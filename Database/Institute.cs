using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
  public class Institute
  {
    public Institute()
    {
      MembersList = new List<Member>();
    }
    public Int32 Id { get; set; }
    public string Name { get; set; }

    public string Address { get; set; }

    public int PhoneNumber { get; set; }

    public string Category { get; set; }
    public string Comments { get; set; }

    public DateTime Registereddate { get; set; }

    public DateTime MembershipExpirtyDate { get; set; }
    public Boolean IsActive { get; set; }

    public virtual ICollection<Member> MembersList { get; set; }

  }
}
