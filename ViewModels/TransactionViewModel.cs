using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
  public class TransactionViewModel
  {
    public Int32 Id { get; set; }

    public string DoneBy { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string PayPalRef { get; set; }
    public string Ref { get; set; }
    public string Status { get; set; }


  }
}
