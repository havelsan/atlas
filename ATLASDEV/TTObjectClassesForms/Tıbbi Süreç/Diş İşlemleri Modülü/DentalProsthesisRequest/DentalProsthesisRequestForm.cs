
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
    /// Diş Protez
    /// </summary>
    public partial class DentalProsthesisRequestForm : BaseDentalEpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SuggestedProsthesis.CellValueChanged += new TTGridCellEventDelegate(SuggestedProsthesis_CellValueChanged);
            SuggestedProsthesis.CellContentClick += new TTGridCellEventDelegate(SuggestedProsthesis_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SuggestedProsthesis.CellValueChanged -= new TTGridCellEventDelegate(SuggestedProsthesis_CellValueChanged);
            SuggestedProsthesis.CellContentClick -= new TTGridCellEventDelegate(SuggestedProsthesis_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SuggestedProsthesis_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisRequestForm_SuggestedProsthesis_CellValueChanged
   if(this.SuggestedProsthesis.CurrentCell.OwningColumn.Name == "SuggestedProsthesisProcedure")
            {
                if (rowIndex < this.SuggestedProsthesis.Rows.Count && rowIndex > -1)
                {
                    DentalProsthesisRequestSuggestedProsthesis sugPro = (DentalProsthesisRequestSuggestedProsthesis)((ITTGridRow)SuggestedProsthesis.Rows[rowIndex]).TTObject;
                    if(sugPro.SuggestedProsthesisProcedure!=null)
                    {
                        if(((DentalProsthesisDefinition)sugPro.SuggestedProsthesisProcedure).Departments.Count==1)
                        {
                            sugPro.Department=((DentalProsthesisDepartmentGrid)((DentalProsthesisDefinition)sugPro.SuggestedProsthesisProcedure).Departments[0]).Department;
                        }
                    }
                }
            }
#endregion DentalProsthesisRequestForm_SuggestedProsthesis_CellValueChanged
        }

        private void SuggestedProsthesis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisRequestForm_SuggestedProsthesis_CellContentClick
   if(this.SuggestedProsthesis.CurrentCell.OwningColumn.Name.Equals(SuggestedToothSchema.Name))
              this.SuggestedProsthesis.ShowTTObject(rowIndex, false);
#endregion DentalProsthesisRequestForm_SuggestedProsthesis_CellContentClick
        }

        protected override void PreScript()
        {
#region DentalProsthesisRequestForm_PreScript
    base.PreScript();
            try {
                this.DentalExaminationFile.Text = Common.GetTextOfRTFString(this.DentalExaminationFile.Text);
            } catch(Exception e) {
                //TODO
            }
#endregion DentalProsthesisRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalProsthesisRequestForm_PostScript
    base.PostScript(transDef);
            
            if(this._DentalProsthesisRequest.CurrentStateDefID != null && this._DentalProsthesisRequest.CurrentStateDefID == DentalProsthesisRequest.States.Request)
            {
                if(this.SuggestedProsthesis == null || this.SuggestedProsthesis.Rows == null || this.SuggestedProsthesis.Rows.Count <= 0)
                    throw new Exception("Önerilen Diş Protez için en az bir işlem girişi yapılmalıdır!");
                
            }
#endregion DentalProsthesisRequestForm_PostScript

            }
                }
}