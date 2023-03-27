
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ProcedureMaterialAddingForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region ProcedureMaterialAddingForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            /*
            if (this._ProcedureMaterialAdding.CurrentStateDefID == ProcedureMaterialAdding.States.New && this._ProcedureMaterialAdding.Episode.IsMedulaEpisode())
            {
                // Medula geçişi öncesi hastalara Hizmet Malzeme Girişi yapılabilmesi için geçici olarak eklendi, ilerde kaldırılacak
                if(this._ProcedureMaterialAdding.Episode.OpeningDate >= Convert.ToDateTime("21.12.2013 00:00:00"))
                    throw new TTUtils.TTException("Vaka açılış tarihi 21.12.2013 ten sonra olan SGK'lı hastalarda Hizmet Malzeme Giriş işlemi kullanılamaz.");
            }
            */
#endregion ProcedureMaterialAddingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureMaterialAddingForm_PostScript
    base.PostScript(transDef);
            
            
            if( transDef != null && transDef.FromStateDefID == ProcedureMaterialAdding.States.New && transDef.ToStateDefID == ProcedureMaterialAdding.States.Completed)
            {
                
                if(this._ProcedureMaterialAdding.PMAddingProcedures.Count == 0 && this._ProcedureMaterialAdding.PMAddingTreatmentMaterials.Count == 0 && this._ProcedureMaterialAdding.ProcedureDefinition == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(1241));
                
                foreach (PMAddingProcedure addingProcedure in this._ProcedureMaterialAdding.PMAddingProcedures)
                {
                    // Kurum veya Hasta Fiyatı girilmişse, girilen fiyatı kullanması için SubActionProcPricingDet oluşturuluyor
                    if(addingProcedure.PayerPrice != null || addingProcedure.PatientPrice != null)
                    {
                        SubActionProcPricingDet subActionProcPricingDet = new SubActionProcPricingDet(this._ProcedureMaterialAdding.ObjectContext);
                        subActionProcPricingDet.Description = addingProcedure.ProcedureObject.Name;
                        subActionProcPricingDet.ExternalCode = addingProcedure.ProcedureObject.Code;
                        subActionProcPricingDet.PatientPrice = addingProcedure.PatientPrice;
                        subActionProcPricingDet.PayerPrice = addingProcedure.PayerPrice;
                        addingProcedure.SetPerformedDate();
                        subActionProcPricingDet.SubActionProcedure = addingProcedure;
                        
                    }
                }
                
                foreach (PMAddingTreatmentMaterial addingMaterial in this._ProcedureMaterialAdding.PMAddingTreatmentMaterials)
                {
                    // Kurum veya Hasta Fiyatı girilmişse, girilen fiyatı kullanması için SubActionMatPricingDet oluşturuluyor
                    if(addingMaterial.PayerPrice != null || addingMaterial.PatientPrice != null)
                    {
                        SubActionMatPricingDet subActionMatPricingDet = new SubActionMatPricingDet(this._ProcedureMaterialAdding.ObjectContext);
                        subActionMatPricingDet.Amount = addingMaterial.Amount;
                        subActionMatPricingDet.Description = addingMaterial.Material.Name;
                        subActionMatPricingDet.ExternalCode = addingMaterial.Material.Code;
                        subActionMatPricingDet.PatientPrice = addingMaterial.PatientPrice;
                        subActionMatPricingDet.PayerPrice = addingMaterial.PayerPrice;
                        subActionMatPricingDet.SubActionMaterial = addingMaterial;
                    }
                }
                
            }
#endregion ProcedureMaterialAddingForm_PostScript

            }
                }
}