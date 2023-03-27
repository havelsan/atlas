
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
    public partial class DentalTreatmentProcedureForm : SubactionProcedureFlowableForm
    {
        override protected void BindControlEvents()
        {
            ttcheckboxGeneralAnesthesia.CheckedChanged += new TTControlEventDelegate(ttcheckboxGeneralAnesthesia_CheckedChanged);
            SecDiagnosis.CellContentClick += new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged += new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttcheckboxGeneralAnesthesia.CheckedChanged -= new TTControlEventDelegate(ttcheckboxGeneralAnesthesia_CheckedChanged);
            SecDiagnosis.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged -= new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            base.UnBindControlEvents();
        }

        private void ttcheckboxGeneralAnesthesia_CheckedChanged()
        {
#region DentalTreatmentProcedureForm_ttcheckboxGeneralAnesthesia_CheckedChanged
   if (ttcheckboxGeneralAnesthesia.Value.HasValue && ttcheckboxGeneralAnesthesia.Value.Value) {
                TTObjectContext context = new TTObjectContext(true);
                BindingList<OzelDurum> oList = OzelDurum.GetOzelDurumByKod(context, "Y");
                if (oList.Count > 0)
                    this._DentalTreatmentProcedure.OzelDurum = oList[0];
                context.Dispose();
                }
            else 
            {
                if (this._DentalTreatmentProcedure.OzelDurum  != null && this._DentalTreatmentProcedure.OzelDurum.ozelDurumKodu == "Y")
                {
                    this._DentalTreatmentProcedure.OzelDurum = null;
                }
            }
#endregion DentalTreatmentProcedureForm_ttcheckboxGeneralAnesthesia_CheckedChanged
        }

        private void SecDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentProcedureForm_SecDiagnosis_CellContentClick
   if(this.SecDiagnosis.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosis.ShowTTObject(rowIndex, false);
#endregion DentalTreatmentProcedureForm_SecDiagnosis_CellContentClick
        }

        private void TTListBoxDrAnesteziTescilNo_SelectedObjectChanged()
        {
#region DentalTreatmentProcedureForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
   if(this.TTListBoxDrAnesteziTescilNo.SelectedObject != null){
                ResUser resUser=(ResUser) this.TTListBoxDrAnesteziTescilNo.SelectedObject;
                _DentalTreatmentProcedure.DrAnesteziTescilNo= (resUser.DiplomaRegisterNo == null)? null : resUser.DiplomaRegisterNo.ToString();
                //_DentalExamination.DrAnesteziTescilNo = _DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            }
#endregion DentalTreatmentProcedureForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region DentalTreatmentProcedureForm_btnNewTreatmentDischarge_Click
   CreateNewTreatmentDischarge();
#endregion DentalTreatmentProcedureForm_btnNewTreatmentDischarge_Click
        }

        private void ttbuttonToothSchema_Click()
        {
#region DentalTreatmentProcedureForm_ttbuttonToothSchema_Click
   DentalToothSchema dentalForm = new DentalToothSchema();
                if (dentalForm != null)
                    dentalForm.ShowEdit(this.FindForm(),this._DentalTreatmentProcedure,true);
#endregion DentalTreatmentProcedureForm_ttbuttonToothSchema_Click
        }

        protected override void PreScript()
        {
#region DentalTreatmentProcedureForm_PreScript
    base.PreScript();
            //if(this._DentalTreatmentProcedure.CurrentStateDefID != null && this._DentalTreatmentProcedure.CurrentStateDefID == DentalTreatmentProcedure.States.TreatmentProcedure)
                this.SetProcedureDoctorAsCurrentResource();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
#endregion DentalTreatmentProcedureForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalTreatmentProcedureForm_PostScript
    //YAPILACAKLAR// this.parentForm şimdilik yazılan bir kod 76803 nolu issue çözüldüğünde tekrar bakılacak
            if (transDef != null)
                if (transDef.ToStateDefID.Equals(DentalTreatmentProcedure.States.TechnicianProcedure))
                if (this.TechnicalDepartment.SelectedValue  == null)
                throw new Exception(SystemMessage.GetMessage(1165));
            if (!(this.Owner is  DentalTreatmentForm ))
            {
                this._DentalTreatmentProcedure.IfLastCompletedProcedureCompleteRequest();
            }
#endregion DentalTreatmentProcedureForm_PostScript

            }
                }
}