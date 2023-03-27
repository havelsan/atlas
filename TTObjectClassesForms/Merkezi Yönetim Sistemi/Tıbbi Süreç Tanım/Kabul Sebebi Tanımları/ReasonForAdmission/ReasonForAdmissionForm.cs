
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
    /// Kabul Sebebi Tanımları
    /// </summary>
    public partial class ReasonForAdmissionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            RelatedResources.CellValueChanged += new TTGridCellEventDelegate(RelatedResources_CellValueChanged);
            Type.SelectedIndexChanged += new TTControlEventDelegate(Type_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RelatedResources.CellValueChanged -= new TTGridCellEventDelegate(RelatedResources_CellValueChanged);
            Type.SelectedIndexChanged -= new TTControlEventDelegate(Type_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void RelatedResources_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ReasonForAdmissionForm_RelatedResources_CellValueChanged
   if(RelatedResources.CurrentCell.OwningColumn.Name == "ActionType")
            {
                if (rowIndex < this.RelatedResources.Rows.Count && rowIndex > -1)
                {
                    ReasonForAdmissionRelatedResources relatedResource = (ReasonForAdmissionRelatedResources)((ITTGridRow)RelatedResources.Rows[rowIndex]).TTObject;
                    if(relatedResource.ProcedureDefinitions.Count>0){
                        relatedResource.ProcedureDefinitions.DeleteChildren();
                    }
                }
            }
#endregion ReasonForAdmissionForm_RelatedResources_CellValueChanged
        }

        private void Type_SelectedIndexChanged()
        {
#region ReasonForAdmissionForm_Type_SelectedIndexChanged
   SetIsActiveReadOnlyByType();
#endregion ReasonForAdmissionForm_Type_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region ReasonForAdmissionForm_PreScript
    base.PreScript();
            SetIsActiveReadOnlyByType();
#endregion ReasonForAdmissionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ReasonForAdmissionForm_PostScript
    base.PostScript(transDef);
            
            BindingList<ReasonForAdmission.GetReasonForAdmissionDefinition_Class> definitionList=ReasonForAdmission.GetReasonForAdmissionDefinition("WHERE TYPE=" + this._ReasonForAdmission.Type.GetHashCode() );
            if (definitionList.Count>0 && ((definitionList[0].ObjectID).ToString()!=this._ReasonForAdmission.ObjectID.ToString()))
                throw new Exception(SystemMessage.GetMessageV3(1269, new string[] {this._ReasonForAdmission.Type.ToString()}));
            
            this._ReasonForAdmission.Description=Common.GetEnumValueDefOfEnumValue(this._ReasonForAdmission.Type).DisplayText;
#endregion ReasonForAdmissionForm_PostScript

            }
            
#region ReasonForAdmissionForm_Methods
        public void SetIsActiveReadOnlyByType(){
            if(this._ReasonForAdmission.Type==AdmissionTypeEnum.ConsultationFromOtherHospitalRequestAcception){
                this.IsActive.Value=false;
                this.IsActive.ReadOnly=true;
            }else{
                this.IsActive.ReadOnly=false;
            }
        }
        
#endregion ReasonForAdmissionForm_Methods
    }
}