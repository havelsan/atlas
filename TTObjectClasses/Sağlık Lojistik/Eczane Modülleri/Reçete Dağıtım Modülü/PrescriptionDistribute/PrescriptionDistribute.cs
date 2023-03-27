
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
    /// Reçete Dağıtım
    /// </summary>
    public  partial class PrescriptionDistribute : BaseAction, IWorkListBaseAction
    {
        public partial class GetPrescriptionDistributeReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionOrderForDailyNoReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionOrderByPharmacyReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetExternalPharmacyBalance_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionNotDistributedReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionOutScheduleQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionOfSelectedPharmacyQuery_Class : TTReportNqlObject 
        {
        }

        public partial class YatanHastaReceteQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetInpatientPrescriptionOrderByClinicReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class ReceteParaQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetSivilEczaneQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetPrescriptionDistributeForERecete_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
#region PreTransition_New2Approval
            
            
            if(DistributeDetails.Count == 0)
            {
                throw new TTException(SystemMessage.GetMessage(1181));
            }
#endregion PreTransition_New2Approval
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            
            
            TTObjectContext context = ObjectContext ;
            BindingList<ExternalPharmacyDistributionTerm> termList = ExternalPharmacyDistributionTerm.GetOpenDistributionTerm(ObjectContext);
            if (termList.Count == 1)
            {
                ExternalPharmacyDistributionTerm distributionTerm = termList[0];
                foreach (DistributeDetail distributeDetail in DistributeDetails)
                {
                    if (distributeDetail.Prescription is InpatientPrescription)
                    {
                        ((InpatientPrescription)distributeDetail.Prescription).ExternalPharmacy = distributeDetail.ExternalPharmacy;
                    }
                    else
                    {
                        ((OutPatientPrescription)distributeDetail.Prescription).ExternalPharmacy = distributeDetail.ExternalPharmacy;
                    }
                    ExternalPharmacyPrescriptionTransaction prescriptionTransaction = new ExternalPharmacyPrescriptionTransaction(context);
                    prescriptionTransaction.ExternalPharmacy = distributeDetail.ExternalPharmacy;
                    prescriptionTransaction.Prescription = distributeDetail.Prescription;
                    prescriptionTransaction.Cancelled = false;
                    prescriptionTransaction.TransactionDate = Common.RecTime();
                    prescriptionTransaction.DistributionTerm = distributionTerm;
                    prescriptionTransaction.Price = (double)distributeDetail.Prescription.PrescriptionPrice;
                }
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(1182));
            }

#endregion PostTransition_Approval2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PrescriptionDistribute).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PrescriptionDistribute.States.New && toState == PrescriptionDistribute.States.Approval)
                PreTransition_New2Approval();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PrescriptionDistribute).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PrescriptionDistribute.States.Approval && toState == PrescriptionDistribute.States.Completed)
                PostTransition_Approval2Completed();
        }

    }
}