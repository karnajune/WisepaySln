using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Wisepay.Web.WebApi.Controller
{
  using Database;

  using Logging;

  using UnitOfService;

  using ViewModels;

  using Wisepay.Web.Models;

  [RoutePrefix("api")]
  public class InstituteController : ApiController
  {
    private readonly IUnitOfService unitofService;

    private readonly ILogger _logger;
    
    public InstituteController(IUnitOfService unitOfService, ILogger logger)
    {
      this.unitofService = unitOfService;
      _logger = logger;
    }

    [HttpGet]
    [Route("institutes/get")]
    public List<InstituteViewModel> GetAllInstitutes()
    {
      try
      {
        return this.unitofService.InstituteService.GetAll().ToList();
         
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return null;
      }
    }

    [HttpPost]
    [Route("institute/add")]
    public string Add([FromBody] Institute newInstitute)
    {
      try
      {
       return this.unitofService.InstituteService.AddInstitute(newInstitute);
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return exception.ToString();
      }
    }

  }
}
