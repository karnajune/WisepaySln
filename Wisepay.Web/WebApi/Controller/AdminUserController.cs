using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Wisepay.Web.WebApi.Controller
{
  using Database;

  using Logging;

  using UnitOfService;

  [RoutePrefix("api")]
  public class AdminUserController : ApiController
  {
    private readonly IUnitOfService unitofService;

    private readonly ILogger _logger;
    
    public AdminUserController(IUnitOfService unitOfService, ILogger logger)
    {
      this.unitofService = unitOfService;
      _logger = logger;
    }

    [HttpGet]
    [Route("adminusers/get")]
    public List<AdminUser> GetAllAdminUsers()
    {
      try
      {
        return unitofService.AdminUserService.GetAll().ToList();
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return null;
      }
    }

    [HttpPost]
    [Route("adminuser")]
    public string Add([FromBody] AdminUser newAdminUser)
    {
      try
      {
       return this.unitofService.AdminUserService.AddAdminUser(newAdminUser);
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return exception.ToString();
      }
    }

    [HttpPost]
    [Route("adminuser/authenticate/{username}/{password}")]
    public AdminUser AdminAuthenticate(string userName,string password)
    {
      try
      {
        return this.unitofService.AdminUserService.AdminAuthenticate(userName, password);
        
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return null;
      }
    }

  }
}
