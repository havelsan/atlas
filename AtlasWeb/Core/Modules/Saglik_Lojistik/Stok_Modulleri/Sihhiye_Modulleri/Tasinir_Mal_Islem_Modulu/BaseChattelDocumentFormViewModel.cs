//$386B252F
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTUtils.RequirementManager;

namespace Core.Controllers
{
    public partial class BaseChattelDocumentServiceController
    {
        public RequirementResultCode UpdateSupplierNumber(SupplierUpdateModel updateModel)
        {
            RequirementResultCode req = new RequirementResultCode(updateModel.ToJSON(), "Bayi No Hatasý", false);
            using (TTObjectContext context = new TTObjectContext(false))
            {
                try
                {
                    Supplier supplier = context.GetObject<Supplier>(new Guid(updateModel.SupplierObjectId));
                    supplier.SupplierNumber = updateModel.SupplierNumber;
                    req.IsSuccess = true;
                    req.ErrorMessage = "";
                    req.SuccessMessage = "Bayi No Alaný " + supplier.Name + " için " + supplier.SupplierNumber + " olarak güncellenmiþtir.";
                    context.Save();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return req;
        }
    }
}

namespace Core.Models
{
    public partial class BaseChattelDocumentFormViewModel
    {
    }
    public partial class SupplierUpdateModel
    {
        public string SupplierObjectId { get; set; }
        public string SupplierNumber { get; set; }
    }
}