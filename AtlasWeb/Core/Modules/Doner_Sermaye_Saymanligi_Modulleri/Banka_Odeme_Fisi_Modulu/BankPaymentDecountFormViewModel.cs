//$46596597
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using TTDefinitionManagement;

namespace Core.Controllers
{
    public partial class BankPaymentDecountServiceController
    {
        partial void PreScript_BankPaymentDecountForm(BankPaymentDecountFormViewModel viewModel, BankPaymentDecount bankPaymentDecount, TTObjectContext objectContext)
        {
            if (((ITTObject)bankPaymentDecount).IsNew)
            {
                viewModel._BankPaymentDecount.PrepareBankPaymentDecount();
                ContextToViewModel(viewModel, objectContext);
            }
        }
    //[HttpPost]
    //public void BankPaymentDecountForm([ModelBinder(typeof(NebulaModelBinder))]BankPaymentDecountFormViewModel viewModel)
    //{
    //    using (var objectContext = new TTObjectContext(false))
    //    {
    //        Guid entryStateID = Guid.Parse("c15d8145-94dc-498e-9401-9030fcd41a20");
    //        var bankPaymentDecount = (BankPaymentDecount)objectContext.AddObject(viewModel._BankPaymentDecount, entryStateID);
    //        BankPaymentDecountDocument bankPaymentDecDoc = (BankPaymentDecountDocument)objectContext.AddObject(viewModel.BankPaymentDecountDocuments[0]);
    //        bankPaymentDecount.BankPaymentDecountDocument = bankPaymentDecDoc;
    //        objectContext.Save();
    //    }
    //}
    }
}

namespace Core.Models
{
    public partial class BankPaymentDecountFormViewModel
    {
    }
}