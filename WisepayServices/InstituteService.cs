namespace WisepayServices
{
  using System.Collections.Generic;

  using Database;

  using UnitOfWork;

  using ViewModels;

  using WisepayServiceInterfaces;

  public class InstituteService : IInstituteService
  {
    private readonly IUnitOfWork unitOfWork;

    public InstituteService(IUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }
    public IList<InstituteViewModel> GetAll()
    {
      var output=new List<InstituteViewModel>();
      var resultFromDb= this.unitOfWork.InstituteRepostitory.GetAll();
      foreach (var institute in resultFromDb)
      {
        output.Add(new InstituteViewModel()
                     {
                       Id = institute.Id,
                       Name = institute.Name,
                       Address = institute.Address
                     });
      }
      return output;
    }
    public Institute GetById(int id)
    {
      return this.unitOfWork.InstituteRepostitory.GetById(id);
    }

    public Institute GetByInstituteName(string name)
    {
      return this.unitOfWork.InstituteRepostitory.GetByName(name);
    }

    public void Update(Institute institute)
    {
      this.unitOfWork.InstituteRepostitory.Update(institute);
    }

    public string AddInstitute(Institute newInstitute)
    {
      var institutefromDb = this.unitOfWork.InstituteRepostitory.GetByName(newInstitute.Name);
      if (institutefromDb != null)
      {
        return "Institute already exists";
      }
      var newUser = this.unitOfWork.InstituteRepostitory.AddInstitute(newInstitute);
      if (newUser.Id != 0 || newUser.Id != -1)
      {
        return "Successfully added New Institute";
      }
      return " Failed to Add New Institute";
    }
  }
}
