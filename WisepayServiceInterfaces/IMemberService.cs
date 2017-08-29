using System;
using System.Collections.Generic;

namespace WisepayServiceInterfaces
{
  using Database;

  using ViewModels;

  public interface IMemberService
  {
    IList<Member> GetAll();
    MemberViewModel GetById(Int32 id);

    IList<MemberViewModel> GetByInstituteId(int instituteId);
    Member GetByName(int instituteId, string firstname, string lastname);
    string AddMember(Member newMemberForInstitute);
  }
}
