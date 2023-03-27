
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Reçete Dağıtım Düzeltme
    /// </summary>
    public  partial class PresDistributeUpdate : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PreTransition_Approval2Completed
            
            
            
            ExternalPharmacyDistributionTerm openTerm = null;
            IList openterms = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(ObjectContext);
            if (openterms.Count > 0)
            {
                openTerm = (ExternalPharmacyDistributionTerm)openterms[0];
            }
            else
            {
                throw new TTException(TTUtils.CultureService.GetText("M25101", "Açık Eczane dönemi bulunamamıştır."));
            }
            foreach (PresDistributeUpdateDetail presDistributeUpdateDetail in PresDistributeUpdateDetails)
            {
                if ((bool)presDistributeUpdateDetail.IsCancel)
                {
                    /*if (((InpatientPrescription)presDistributeUpdateDetail.Prescription).CurrentStateDefID == InpatientPrescription.States.ExternalPharmacySupply)
                    {
                        ExternalPharmacyPrescriptionTransaction externalPharmacyPrescriptionTransaction = new ExternalPharmacyPrescriptionTransaction(this.ObjectContext);
                        externalPharmacyPrescriptionTransaction.ExternalPharmacy = presDistributeUpdateDetail.ExternalPharmacy;
                        externalPharmacyPrescriptionTransaction.Prescription = (Prescription)presDistributeUpdateDetail.Prescription;
                        externalPharmacyPrescriptionTransaction.Price = presDistributeUpdateDetail.Price * -1;
                        externalPharmacyPrescriptionTransaction.TransactionDate = DateTime.Now;
                        externalPharmacyPrescriptionTransaction.DistributionTerm = openTerm;
                        ((InpatientPrescription)presDistributeUpdateDetail.Prescription).ExternalPharmacy = null;
                        ((InpatientPrescription)presDistributeUpdateDetail.Prescription).DistributeDetail.DeleteChildren();
                    }
                    else
                    {
                        throw new TTException ("İptal Edilecek olan " + presDistributeUpdateDetail.Prescription.PrescriptionNO.ToString() + " Numaralı Reçetenin durumu Eczane Temin olmadığı için iptal edemezsiniz."); 
                    }*/
                }
            }

#endregion PreTransition_Approval2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresDistributeUpdate).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresDistributeUpdate.States.Approval && toState == PresDistributeUpdate.States.Completed)
                PreTransition_Approval2Completed();
        }

    }
}