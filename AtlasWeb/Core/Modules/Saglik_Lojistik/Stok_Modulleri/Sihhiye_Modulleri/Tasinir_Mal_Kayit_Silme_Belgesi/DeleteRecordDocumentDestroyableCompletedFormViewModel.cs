//$16B99A60
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class DeleteRecordDocumentDestroyableServiceController
    {
        partial void AfterContextSaveScript_DeleteRecordDocumentDestroyableCompletedForm(DeleteRecordDocumentDestroyableCompletedFormViewModel viewModel, DeleteRecordDocumentDestroyable deleteRecordDocumentDestroyable, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DeleteAnimalRecordDocument.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in deleteRecordDocumentDestroyable.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            deleteRecordDocumentDestroyable.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class DeleteRecordDocumentDestroyableCompletedFormViewModel
    {
    }
}