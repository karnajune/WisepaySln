using System;
using System.Collections.Generic;

namespace WisepayServiceInterfaces
{
  using Database;

  using ViewModels;

  public interface IInstituteService
  {
    IList<InstituteViewModel> GetAll();

    Institute GetById(Int32 id);

    Institute GetByInstituteName(string name);
    void Update(Institute admin);

    string AddInstitute(Institute newInstitute);
    }
}
