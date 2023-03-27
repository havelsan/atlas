//$BDF7C357
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
        partial void AfterContextSaveScript_DeleteRecordDocumentDestroyableStockCardRegistryForm(DeleteRecordDocumentDestroyableStockCardRegistryFormViewModel viewModel, DeleteRecordDocumentDestroyable deleteRecordDocumentDestroyable, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (deleteRecordDocumentDestroyable.CurrentStateDefID != null)
            {
                if (deleteRecordDocumentDestroyable.CurrentStateDefID == DeleteRecordDocumentDestroyable.States.Completed)
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                    {
                        var sonucMesaji = deleteRecordDocumentDestroyable.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    }
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class DeleteRecordDocumentDestroyableStockCardRegistryFormViewModel
    {
        public string mkysPwd { get; set; }
    }
}