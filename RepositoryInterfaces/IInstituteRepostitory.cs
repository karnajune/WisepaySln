using System.Collections.Generic;

namespace RepositoryInterfaces
{
  using System;

  using Database;

  using Repository;

  public interface IInstituteRepostitory : IBaseRepository<Institute>
  {
    IList<Institute> GetAll();
    Institute GetById(Int32 id);
    Institute GetByName(string name);

    Institute AddInstitute(Institute institute);
  }
}
