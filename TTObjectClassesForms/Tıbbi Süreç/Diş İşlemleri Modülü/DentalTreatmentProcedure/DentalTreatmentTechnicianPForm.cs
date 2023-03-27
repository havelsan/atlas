
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
    public partial class DentalTreatmentTechnicianPForm : SubactionProcedureFlowableForm
    {
        override protected void BindControlEvents()
        {
            SecDiagnosis.CellContentClick += new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SecDiagnosis.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void SecDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentTechnicianPForm_SecDiagnosis_CellContentClick
   if(this.SecDiagnosis.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosis.ShowTTObject(rowIndex, false);
#endregion DentalTreatmentTechnicianPForm_SecDiagnosis_CellContentClick
        }

        private void ttbutton1_Click()
        {
#region DentalTreatmentTechnicianPForm_ttbutton1_Click
   DentalToothSchema dentalForm = new DentalToothSchema();
                if (dentalForm != null)
                    dentalForm.ShowEdit(this.FindForm(), this._DentalTreatmentProcedure, true);
#endregion DentalTreatmentTechnicianPForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region DentalTreatmentTechnicianPForm_PreScript
    base.PreScript();
            if(this._DentalTreatmentProcedure.SecondaryMasterResource==null)
            {
                this._DentalTreatmentProcedure.SecondaryMasterResource=this._DentalTreatmentProcedure.MasterResource;
            }
            if(this._DentalTreatmentProcedure.DentalTreatmentRequest.ProcedureSpeciality!=null)
            {
                this.TechnicalDepartment.ListFilterExpression = "THIS.RESOURCESPECIALITIES.SPECIALITY = '" + this._DentalTreatmentProcedure.DentalTreatmentRequest.ProcedureSpeciality.ObjectID + "'";
            }
            this.SetProcedureDoctorAsCurrentResource();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
#endregion DentalTreatmentTechnicianPForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalTreatmentTechnicianPForm_PostScript
    //YAPILACAKLAR// this.parentForm şimdilik yazılan bir kod 76803 nolu issue çözüldüğünde tekrar bakılacak
            if (!(this.Owner is  DentalTreatmentForm ))
            {
                this._DentalTreatmentProcedure.IfLastCompletedProcedureCompleteRequest();
            }
#endregion DentalTreatmentTechnicianPForm_PostScript

            }
                }
}