
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
    /// Diş Tedavi İşlemi
    /// </summary>
    public partial class DentalApprovalTreatmentTechnicianForm : SubactionProcedureFlowableForm
    {
        override protected void BindControlEvents()
        {
            SecDiagnosis.CellContentClick += new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SecDiagnosis.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            base.UnBindControlEvents();
        }

        private void SecDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalApprovalTreatmentTechnicianForm_SecDiagnosis_CellContentClick
   if(this.SecDiagnosis.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosis.ShowTTObject(rowIndex, false);
#endregion DentalApprovalTreatmentTechnicianForm_SecDiagnosis_CellContentClick
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region DentalApprovalTreatmentTechnicianForm_btnNewTreatmentDischarge_Click
   CreateNewTreatmentDischarge();
#endregion DentalApprovalTreatmentTechnicianForm_btnNewTreatmentDischarge_Click
        }

        private void ttbuttonToothSchema_Click()
        {
#region DentalApprovalTreatmentTechnicianForm_ttbuttonToothSchema_Click
   DentalToothSchema dentalForm = new DentalToothSchema();
                if (dentalForm != null)
                    dentalForm.ShowEdit(this.FindForm(), this._DentalTreatmentProcedure, true);
#endregion DentalApprovalTreatmentTechnicianForm_ttbuttonToothSchema_Click
        }

        protected override void PreScript()
        {
#region DentalApprovalTreatmentTechnicianForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
#endregion DentalApprovalTreatmentTechnicianForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalApprovalTreatmentTechnicianForm_PostScript
    if (transDef != null)
                if (transDef.ToStateDefID.Equals(DentalTreatmentProcedure.States.TechnicianProcedure))
                if (this.TechnicalDepartment.SelectedValue  == null)
                throw new Exception(SystemMessage.GetMessage(1165));
            base.PostScript(transDef);
             if (!(this.Owner is  DentalTreatmentForm ))
            {
                this._DentalTreatmentProcedure.IfLastCompletedProcedureCompleteRequest();
            }
#endregion DentalApprovalTreatmentTechnicianForm_PostScript

            }
                }
}