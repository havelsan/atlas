
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
    /// Diş Protez İşlemi
    /// </summary>
    public partial class DentalProsthesisProcedureForm : SubactionProcedureFlowableForm
    {
        override protected void BindControlEvents()
        {
            SecDiagnosis.CellContentClick += new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged += new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            btnNewTreatmentDischarge.Click += new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttcheckboxGeneralAnesthesia.CheckedChanged += new TTControlEventDelegate(ttcheckboxGeneralAnesthesia_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SecDiagnosis.CellContentClick -= new TTGridCellEventDelegate(SecDiagnosis_CellContentClick);
            TTListBoxDrAnesteziTescilNo.SelectedObjectChanged -= new TTControlEventDelegate(TTListBoxDrAnesteziTescilNo_SelectedObjectChanged);
            btnNewTreatmentDischarge.Click -= new TTControlEventDelegate(btnNewTreatmentDischarge_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttcheckboxGeneralAnesthesia.CheckedChanged -= new TTControlEventDelegate(ttcheckboxGeneralAnesthesia_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void SecDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisProcedureForm_SecDiagnosis_CellContentClick
   if(this.SecDiagnosis.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosis.ShowTTObject(rowIndex, false);
#endregion DentalProsthesisProcedureForm_SecDiagnosis_CellContentClick
        }

        private void TTListBoxDrAnesteziTescilNo_SelectedObjectChanged()
        {
#region DentalProsthesisProcedureForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
   if(this.TTListBoxDrAnesteziTescilNo.SelectedObject != null){
                ResUser resUser=(ResUser) this.TTListBoxDrAnesteziTescilNo.SelectedObject;
                _DentalProsthesisProcedure.DrAnesteziTescilNo= (resUser.DiplomaRegisterNo == null)? null : resUser.DiplomaRegisterNo.ToString();
                //_DentalExamination.DrAnesteziTescilNo = _DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            }
#endregion DentalProsthesisProcedureForm_TTListBoxDrAnesteziTescilNo_SelectedObjectChanged
        }

        private void btnNewTreatmentDischarge_Click()
        {
#region DentalProsthesisProcedureForm_btnNewTreatmentDischarge_Click
   CreateNewTreatmentDischarge();
#endregion DentalProsthesisProcedureForm_btnNewTreatmentDischarge_Click
        }

        private void ttbutton1_Click()
        {
#region DentalProsthesisProcedureForm_ttbutton1_Click
   DentalToothSchemaProthesisProcedure dentalForm = new DentalToothSchemaProthesisProcedure();
                if (dentalForm != null)
                    dentalForm.ShowEdit(this.FindForm(), this._DentalProsthesisProcedure,true);
#endregion DentalProsthesisProcedureForm_ttbutton1_Click
        }

        private void ttcheckboxGeneralAnesthesia_CheckedChanged()
        {
#region DentalProsthesisProcedureForm_ttcheckboxGeneralAnesthesia_CheckedChanged
   if (ttcheckboxGeneralAnesthesia.Value.HasValue && ttcheckboxGeneralAnesthesia.Value.Value) {
                TTObjectContext context = new TTObjectContext(true);
                BindingList<OzelDurum> oList = OzelDurum.GetOzelDurumByKod(context, "Y");
                if (oList.Count > 0)
                    this._DentalProsthesisProcedure.OzelDurum = oList[0];
                context.Dispose();
                }
            else 
            {
                if (this._DentalProsthesisProcedure.OzelDurum != null && this._DentalProsthesisProcedure.OzelDurum.ozelDurumKodu == "Y")
                {
                    this._DentalProsthesisProcedure.OzelDurum = null;
                }
            }
#endregion DentalProsthesisProcedureForm_ttcheckboxGeneralAnesthesia_CheckedChanged
        }

        protected override void PreScript()
        {
#region DentalProsthesisProcedureForm_PreScript
    base.PreScript();
            //if(this._DentalProsthesisProcedure.CurrentStateDefID != null && this._DentalProsthesisProcedure.CurrentStateDefID == DentalProsthesisProcedure.States.ProtesisProcedure)
            this.SetProcedureDoctorAsCurrentResource();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
            try {
                this.DentalExaminationFile.Text = Common.GetTextOfRTFString(this.DentalExaminationFile.Text);
            } catch(Exception e) {
                
            }
#endregion DentalProsthesisProcedureForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalProsthesisProcedureForm_PostScript
    //YAPILACAKLAR// this.parentForm şimdilik yazılan bir kod 76803 nolu issue çöazüldüğünde tekrar bakılacak
            if (transDef != null)
                if (transDef.ToStateDefID.Equals(DentalProsthesisProcedure.States.TechnicianProcedure))
                if (this.TechnicalDepartment.SelectedValue  == null)
                throw new Exception("Teknisyen işlemi adımına geçerken 'Teknisyen İşlemleri Birimi' alanı doldurulmalıdır!");
            if (!(this.Owner is  DentalProsthesisForm ))
            {
                this._DentalProsthesisProcedure.IfLastCompletedProcedureCompleteRequest();
            }
#endregion DentalProsthesisProcedureForm_PostScript

            }
                }
}