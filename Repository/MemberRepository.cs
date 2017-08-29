using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  using System.Data.Entity;

  using Database;

  using RepositoryInterfaces;
  public class MemberRepository : BaseRepository<Member>, IMemberRepository
  {
    private readonly WisepayContext context;
    public MemberRepository(WisepayContext dataDbContext) : base(dataDbContext)
    {

    }

    public IList<Member> GetAll()
    {
      return this.Entities.ToList();
    }

    public Member GetById(int id)
    {
      return this.Entities.FirstOrDefault(s => s.Id.Equals(id) && s.IsActive);
    }

    public IList<Member> GetByInstituteId(int instituteId)
    {
      return this.Entities.Where(s => s.InstituteId.Equals(instituteId) && s.IsActive).ToList();

    }

    public Member GetByName(int instituteId, string firstname, string lastname)
    {
      return this.Entities.FirstOrDefault(s => s.FirstName.Equals(firstname) && s.LastName.Equals(lastname) && s.InstituteId.Equals(instituteId) && s.IsActive);
    }

    public Member AddMember(Member newMemberForInstitute)
    {
      return this.Create(newMemberForInstitute);
    }
  }
}
