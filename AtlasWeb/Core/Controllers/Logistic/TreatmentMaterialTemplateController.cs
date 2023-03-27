using Core.Models;
using Core.Modules.Saglik_Lojistik.Eczane_Modulleri.Ilac_Direktifi_Giris_Modulu;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTConnectionManager;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static Core.Controllers.DrugOrderIntroductionServiceController;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class TreatmentMaterialTemplateController : Controller
    {
        public class TreatmentMaterialTemplateItem
        {
            public Guid? ObjectID { get; set; }
            public string TemplateName { get; set; }
            public List<TreatmentMaterialTemplateDetailItem> TemplateDetails;
        }
         
        public class TreatmentMaterialTemplateDetailItem
        {
            public double Amount { get; set; }
            public string MKYSNo { get; set; }
            public string Barcode { get; set; }
            public string MaterialName { get; set; }
            public Guid MaterialObjectID { get; set; }
            public double Inheld { get; set; }
        }

        [HttpPost]
        public string saveObject(TreatmentMaterialTemplateItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                NursingApplicationTemplate treatmentMaterialTemplateDefinition = new NursingApplicationTemplate(objectContext);
                treatmentMaterialTemplateDefinition.TemplateName = input.TemplateName;
                foreach(TreatmentMaterialTemplateDetailItem detail in input.TemplateDetails)
                {
                    NursingAppTemplateDet nursingAppTemplateDet = new NursingAppTemplateDet(objectContext);
                    Material material = (Material)objectContext.GetObject(detail.MaterialObjectID, typeof(Material));
                    nursingAppTemplateDet.Material = material;
                    nursingAppTemplateDet.Amount = detail.Amount;
                    treatmentMaterialTemplateDefinition.NursingAppTempDetails.Add(nursingAppTemplateDet);
                    treatmentMaterialTemplateDefinition.CurrentStateDefID = NursingApplicationTemplate.States.Create;
 
                }
                objectContext.Update();
                treatmentMaterialTemplateDefinition.CurrentStateDefID = NursingApplicationTemplate.States.Complated;
                objectContext.Save();
                objectContext.Dispose();
                return "Şablon Kayıt İşlemi Yapılmıştır";
            }
            catch(Exception ex)
            {
                return " Şablon Kayıt İşlemi Sırasında Hata Alınmıştır.. Hata: " + ex.Message;
            }
        }

        public class getAllTemplate_Input
        {
            public Guid StoreID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<TreatmentMaterialTemplateItem> getAllTemplate(getAllTemplate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                Store store = (Store)objectContext.GetObject(input.StoreID, typeof(Store));
                IBindingList userTemplates = objectContext.QueryObjects("USERTEMPLATE", "RESUSER =" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID) + "AND TAOBJECTDEFID = 'aec79b4d-8b18-4909-83b9-4e186d4fd054' AND FILITERDATA ='NURSINGAPPLICATIONTEM'");
                List<TreatmentMaterialTemplateItem> output = new List<TreatmentMaterialTemplateItem>();
                foreach(UserTemplate template in userTemplates)
                {
                    TreatmentMaterialTemplateItem templateItem = new TreatmentMaterialTemplateItem();
                    templateItem.ObjectID = template.ObjectID;
                    templateItem.TemplateName = template.Description;
                    templateItem.TemplateDetails = new List<TreatmentMaterialTemplateDetailItem>();
                    NursingApplicationTemplate nt = (NursingApplicationTemplate)objectContext.GetObject(template.TAObjectID.Value, template.TAObjectDefID.Value);
                    
                    foreach(NursingAppTemplateDet templateDet in nt.NursingAppTempDetails)
                    {
                        TreatmentMaterialTemplateDetailItem templateDetailItem = new TreatmentMaterialTemplateDetailItem();
                        templateDetailItem.Amount = (Currency)templateDet.Amount;
                        templateDetailItem.Barcode = templateDet.Material.Barcode;
                        templateDetailItem.MaterialName = templateDet.Material.Name;
                        templateDetailItem.MaterialObjectID = templateDet.Material.ObjectID;
                        templateDetailItem.MKYSNo = templateDet.Material.StockCard.NATOStockNO;
                        templateDetailItem.Inheld = templateDet.Material.StockInheld(store);
                        templateItem.TemplateDetails.Add(templateDetailItem);
                    }
                    output.Add(templateItem);
                }
                return output;
            }
        }
    }
}
