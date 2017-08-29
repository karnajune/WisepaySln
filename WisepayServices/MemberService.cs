using System;

namespace WisepayServices
{
  using System.Collections;
  using System.Collections.Generic;

  using Database;

  using UnitOfWork;

  using ViewModels;

  using WisepayServiceInterfaces;

  public class MemberService : IMemberService
  {
    private readonly IUnitOfWork unitOfWork;

    public MemberService(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public IList<Member> GetAll()
    {
      return this.unitOfWork.MemberRepository.GetAll();

    }

    public MemberViewModel GetById(int id)
    {
      var resultFromDb = this.unitOfWork.MemberRepository.GetById(id);
      return new MemberViewModel()
               {
        Id = resultFromDb.Id,
        FirstName = resultFromDb.FirstName,
        LastName = resultFromDb.LastName,
        Comments = resultFromDb.Comments,
        Registered = resultFromDb.Registereddate,
        MembershipExpiryDate = resultFromDb.MembershipExpirtyDate
      };

    }
    public IList<MemberViewModel> GetByInstituteId(int instituteId)
    {
      var output=new List<MemberViewModel>();
      var resultFromDb= this.unitOfWork.MemberRepository.GetByInstituteId(instituteId);
      foreach (var member in resultFromDb)
      {
        output.Add(
          new MemberViewModel()
            {
              Id = member.Id,
              FirstName = member.FirstName,
              LastName = member.LastName,
              Comments = member.Comments,
              Registered = member.Registereddate,
              MembershipExpiryDate = member.MembershipExpirtyDate
            });
      }
      return output;
    }
    public Member GetByName(int instituteId, string firstname, string lastname)
    {
      return this.unitOfWork.MemberRepository.GetByName(instituteId,firstname,lastname);

    }

    public string AddMember(Member newMemberForInstitute)
    {

      var memberfromDb = this.unitOfWork.MemberRepository.GetByName(newMemberForInstitute.InstituteId,newMemberForInstitute.FirstName,newMemberForInstitute.LastName);
      if (memberfromDb != null)
      {
        return "Member already exists";
      }
      var newMember = this.unitOfWork.MemberRepository.AddMember(newMemberForInstitute);
      if (newMember.Id != 0 || newMember.Id != -1)
      {
        return "Successfully added New Member";
      }
      return " Failed to Add New Member";

    }
  }
}
