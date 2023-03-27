
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
    /// <summary>
    /// Reçete Dağıtım Düzeltme
    /// </summary>
    public partial class PresDistributeUpdateForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdGetPrescriptionDis.Click += new TTControlEventDelegate(cmdGetPrescriptionDis_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetPrescriptionDis.Click -= new TTControlEventDelegate(cmdGetPrescriptionDis_Click);
            base.UnBindControlEvents();
        }

        private void cmdGetPrescriptionDis_Click()
        {
#region PresDistributeUpdateForm_cmdGetPrescriptionDis_Click
   IList prescriptionDistiributes = _PresDistributeUpdate.ObjectContext.QueryObjects("PRESCRIPTIONDISTRIBUTE","ID = " + _PresDistributeUpdate.DistributeID.ToString());
            PrescriptionDistribute prescriptionDistribute = ((PrescriptionDistribute)prescriptionDistiributes[0]);
            DateTime dDate = ((DateTime)prescriptionDistribute.ActionDate).AddDays(4);

            if (dDate >= DateTime.Now)
            {
                foreach (DistributeDetail distributeDetail in prescriptionDistribute.DistributeDetails)
                {
                    if (distributeDetail.Prescription is InpatientPrescription)
                    {
                       /* if (((InpatientPrescription)distributeDetail.Prescription).CurrentStateDefID == InpatientPrescription.States.ExternalPharmacySupply)
                        {
                            PresDistributeUpdateDetail presDistributeUpdateDetail = new PresDistributeUpdateDetail(_PresDistributeUpdate.ObjectContext);
                            presDistributeUpdateDetail.Prescription = distributeDetail.Prescription;
                            presDistributeUpdateDetail.ExternalPharmacy = distributeDetail.ExternalPharmacy;
                            presDistributeUpdateDetail.PatientName = distributeDetail.PatientName;
                            presDistributeUpdateDetail.PatientProtocolNo = distributeDetail.PatientProtocolNo;
                            presDistributeUpdateDetail.PatientQuarantineNo = distributeDetail.PatientQuarantineNo;
                            presDistributeUpdateDetail.Price = distributeDetail.Price;
                            presDistributeUpdateDetail.IsCancel = false;
                            presDistributeUpdateDetail.PresDistributeUpdate = _PresDistributeUpdate;
                        }*/
                    }
                }
                this.DistributeID.ReadOnly = true;
                this.cmdGetPrescriptionDis.Enabled = false;
            }
            else
            {
                TTVisual.InfoBox.Show ("4 günden önceki reçete dağıtımları güncelleyemezsiniz. Dağıtım İşlem Tarihi : " + prescriptionDistribute.ActionDate.ToString(),MessageIconEnum.ErrorMessage );
            }
#endregion PresDistributeUpdateForm_cmdGetPrescriptionDis_Click
        }
    }
}