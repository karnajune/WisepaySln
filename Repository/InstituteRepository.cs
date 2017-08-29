namespace Repository
{
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Linq;

  using Database;

  using RepositoryInterfaces;

  public class InstituteRepository : BaseRepository<Institute>, IInstituteRepostitory
  {
    private readonly WisepayContext context;

    public InstituteRepository(WisepayContext context)
            : base(context)
        {
    }
    //public AdminUserRepository(WisepayContext context)
    //{
    //  this.context = context;
    //}
   public IList<Institute> GetAll()
    {
      return this.Entities.Include(r=>r.MembersList).ToList();
    }
   public Institute GetById(int id)
    {
      return this.Entities.FirstOrDefault(s => s.Id.Equals(id) && s.IsActive);
    }

    public Institute GetByName(string name)
    {
      return this.Entities.FirstOrDefault(s => s.Name.Equals(name) && s.IsActive);
    }
    public Institute AddInstitute(Institute institute)
    {
      return this.Create(institute);
    }
    
    
  }
}
