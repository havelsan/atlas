
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
    /// Diş Protez İşlemleri
    /// </summary>
    public partial class DentalProsthesisOuterLabForm : SubactionProcedureFlowableForm
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
#region DentalProsthesisOuterLabForm_SecDiagnosis_CellContentClick
   if(this.SecDiagnosis.CurrentCell.OwningColumn.Name.Equals(SecToothSchema.Name))
              this.SecDiagnosis.ShowTTObject(rowIndex, false);
#endregion DentalProsthesisOuterLabForm_SecDiagnosis_CellContentClick
        }

        private void ttbutton1_Click()
        {
#region DentalProsthesisOuterLabForm_ttbutton1_Click
   DentalToothSchemaProthesisProcedure dentalForm = new DentalToothSchemaProthesisProcedure();
                if (dentalForm != null)
                    dentalForm.ShowEdit(this.FindForm(), this._DentalProsthesisProcedure,true);
#endregion DentalProsthesisOuterLabForm_ttbutton1_Click
        }

        protected override void PreScript()
        {
#region DentalProsthesisOuterLabForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
#endregion DentalProsthesisOuterLabForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalProsthesisOuterLabForm_PostScript
    //YAPILACAKLAR// this.parentForm şimdilik yazılan bir kod 76803 nolu issue çöazüldüğünde tekrar bakılacak 
            if  (!(this.Owner is  DentalProsthesisForm ))
            {
                this._DentalProsthesisProcedure.IfLastCompletedProcedureCompleteRequest();
            }
#endregion DentalProsthesisOuterLabForm_PostScript

            }
                }
}