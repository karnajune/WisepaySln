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
  public class TransactionsController : ApiController
  {
    private readonly IUnitOfService unitofService;

    private readonly ILogger _logger;
    
    public TransactionsController(IUnitOfService unitOfService, ILogger logger)
    {
      this.unitofService = unitOfService;
      _logger = logger;
    }

    [HttpGet]
    [Route("transactions/getbymember/{memberId}")]
    public List<TransactionViewModel> GetAllTransactions(int memberId)
    {
      try
      {
        return this.unitofService.TransactionService.GetByMemberId(memberId).ToList();
      }
      catch (Exception exception)
      {
        _logger.Error(exception);
        return null;
      }
    }

    [HttpPost]
    [Route("transactions/add")]
    public string Add([FromBody] Transaction newTransaction)
    {
      try
      {
       return this.unitofService.TransactionService.AddTransaction(newTransaction);
      }
      catch (Exception exception)
      {
        _logger.Error(exception);

        return exception.ToString();
      }
    }

  }
}
