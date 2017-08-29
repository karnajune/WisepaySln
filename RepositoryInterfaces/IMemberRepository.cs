using System.Collections.Generic;

namespace RepositoryInterfaces
{
  using System;

  using Database;

  using Repository;

  public interface IMemberRepository : IBaseRepository<Member>
  {
    IList<Member> GetAll();
    Member GetById(Int32 id);
    IList<Member> GetByInstituteId(Int32 instituteId);

    Member GetByName(int instituteId,string firstname,string lastname);
    Member AddMember(Member newMemberForInstitute);
  }
}
