
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
    /// Diş Tedavi
    /// </summary>
    public partial class DentalTreatmentRequestForm : BaseDentalEpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SuggestedTreatments.CellValueChanged += new TTGridCellEventDelegate(SuggestedTreatments_CellValueChanged);
            SuggestedTreatments.CellContentClick += new TTGridCellEventDelegate(SuggestedTreatments_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SuggestedTreatments.CellValueChanged -= new TTGridCellEventDelegate(SuggestedTreatments_CellValueChanged);
            SuggestedTreatments.CellContentClick -= new TTGridCellEventDelegate(SuggestedTreatments_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SuggestedTreatments_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentRequestForm_SuggestedTreatments_CellValueChanged
   if (this.SuggestedTreatments.CurrentCell.OwningColumn.Name == "SuggestedTreatmentProcedure")
            {
                if (rowIndex < this.SuggestedTreatments.Rows.Count && rowIndex > -1)
                {
                    DentalTreatmentRequestSuggestedTreatment sugTreatment = (DentalTreatmentRequestSuggestedTreatment)((ITTGridRow)SuggestedTreatments.Rows[rowIndex]).TTObject;
                    if (sugTreatment.SuggestedTreatmentProcedure != null)
                    {
                        if (((DentalTreatmentDefinition)sugTreatment.SuggestedTreatmentProcedure).Departments.Count == 1)
                        {
                            sugTreatment.Department = ((DentalTreatmentDepartmentGrid)((DentalTreatmentDefinition)sugTreatment.SuggestedTreatmentProcedure).Departments[0]).Department;
                        }
                        if (((DentalTreatmentDefinition)sugTreatment.SuggestedTreatmentProcedure) != null)
                        {
                            DentalTreatmentDefinition definition = ((DentalTreatmentDefinition)sugTreatment.SuggestedTreatmentProcedure) ; 
                            sugTreatment.ToothNumber = definition.ToothNumber ;
                        }
                    }
                }
            }
#endregion DentalTreatmentRequestForm_SuggestedTreatments_CellValueChanged
        }

        private void SuggestedTreatments_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalTreatmentRequestForm_SuggestedTreatments_CellContentClick
   if (this.SuggestedTreatments.CurrentCell.OwningColumn.Name.Equals(ToothSchema.Name))
                this.SuggestedTreatments.ShowTTObject(rowIndex, false);
#endregion DentalTreatmentRequestForm_SuggestedTreatments_CellContentClick
        }

        protected override void PreScript()
        {
#region DentalTreatmentRequestForm_PreScript
    base.PreScript();
            try {
                this.DentalExaminationFile.Text = Common.GetTextOfRTFString(this.DentalExaminationFile.Text);
            } catch(Exception e) {
                //TODO                
            }
#endregion DentalTreatmentRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalTreatmentRequestForm_PostScript
    base.PostScript(transDef);
            if (this._DentalTreatmentRequest.CurrentStateDefID != null && this._DentalTreatmentRequest.CurrentStateDefID == DentalTreatmentRequest.States.Request)
            {
                if (this.SuggestedTreatments == null || this.SuggestedTreatments.Rows == null || this.SuggestedTreatments.Rows.Count <= 0)
                    throw new Exception("Önerilen Diş Tedavi için en az bir işlem girişi yapılmalıdır!");

            }
#endregion DentalTreatmentRequestForm_PostScript

            }
                }
}