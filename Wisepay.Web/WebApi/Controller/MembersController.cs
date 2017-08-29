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

  [RoutePrefix("api")]
  public class MembersController : ApiController
  {
    private readonly IUnitOfService unitofService;

    private readonly ILogger _logger;
    
    public MembersController(IUnitOfService unitOfService, ILogger logger)
    {
      this.unitofService = unitOfService;
      _logger = logger;
    }

    [HttpGet]
    [Route("members/get/{instituteId}")]
    public List<MemberViewModel> GetAllMembers(int instituteId)
    {
      try
      {
        return this.unitofService.MemberService.GetByInstituteId(instituteId).ToList();
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return null;
      }
    }
    [HttpGet]
    [Route("member/getdetails/{memberId}")]
    public MemberViewModel GetMemberDetails(int memberId)
    {
      try
      {
        return this.unitofService.MemberService.GetById(memberId);
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return null;
      }
    }

    [HttpPost]
    [Route("members/add")]
    public string Add([FromBody] Member newMember)
    {
      try
      {
       return this.unitofService.MemberService.AddMember(newMember);
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return exception.ToString();
      }
    }

  }
}
