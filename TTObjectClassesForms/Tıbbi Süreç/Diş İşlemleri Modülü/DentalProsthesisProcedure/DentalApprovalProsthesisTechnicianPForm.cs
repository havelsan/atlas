
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
    /// Diş Protez İşlem Onayı
    /// </summary>
    public partial class DentalApprovalProsthesisTechnicianPForm : SubactionProcedureFlowableForm
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
#region DentalApprovalProsthesisTechnicianPForm_SecDiagnosis_CellContentClick
   if(this.SecDiagnosis.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosis.ShowTTObject(rowIndex, false);
#endregion DentalApprovalProsthesisTechnicianPForm_SecDiagnosis_CellContentClick
        }

        private void ttbutton1_Click()
        {
#region DentalApprovalProsthesisTechnicianPForm_ttbutton1_Click
   DentalToothSchemaProthesisProcedure dentalForm = new DentalToothSchemaProthesisProcedure();
                if (dentalForm != null)
                    dentalForm.ShowEdit(this.FindForm(), this._DentalProsthesisProcedure,true);
#endregion DentalApprovalProsthesisTechnicianPForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region DentalApprovalProsthesisTechnicianPForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();  
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
#endregion DentalApprovalProsthesisTechnicianPForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalApprovalProsthesisTechnicianPForm_PostScript
    if (transDef != null)
                if (transDef.ToStateDefID.Equals(DentalProsthesisProcedure.States.TechnicianProcedure))
                if (this.TechnicalDepartment.SelectedValue  == null)
                throw new Exception("Teknisyen işlemi adımına geçerken 'Teknisyen İşlemleri Birimi' alanı doldurulmalıdır!");
            base.PostScript(transDef);
            if (!(this.Owner is  DentalProsthesisForm ))
            {
                this._DentalProsthesisProcedure.IfLastCompletedProcedureCompleteRequest();
            }
#endregion DentalApprovalProsthesisTechnicianPForm_PostScript

            }
                }
}