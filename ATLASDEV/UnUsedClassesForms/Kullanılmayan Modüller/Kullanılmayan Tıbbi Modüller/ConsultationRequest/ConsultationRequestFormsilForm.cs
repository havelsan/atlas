
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
    /// Konsültasyon İstek
    /// </summary>
    public partial class ConsultationRequestFormsil : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ConsultationProcedures.CellDoubleClick += new TTGridCellEventDelegate(ConsultationProcedures_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ConsultationProcedures.CellDoubleClick -= new TTGridCellEventDelegate(ConsultationProcedures_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void ConsultationProcedures_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ConsultationRequestFormsil_ConsultationProcedures_CellDoubleClick
   // Çift tıklanan Konsültasyon işlemli açılır
           /* if (this.ConsultationProcedures.Rows.Count > rowIndex && rowIndex>-1)
            {

                
                try
                {
                    ConsultationProcedure  consultationProcedure = (ConsultationProcedure)((ITTGridRow)this.ConsultationProcedures.Rows[rowIndex]).TTObject;
                    if(consultationProcedure!=null)
                    {
                        TTForm frm = TTForm.GetEditForm(consultationProcedure);
                        if (frm == null)
                        {
                            MessageBox.Show(consultationProcedure.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
                        }
                        frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
                        
                        
                        frm.ShowEdit(this.FindForm(),consultationProcedure);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }*/
#endregion ConsultationRequestFormsil_ConsultationProcedures_CellDoubleClick
        }

        protected override void PreScript()
        {
#region ConsultationRequestFormsil_PreScript
    Guid Doctor= new Guid("9431A69C-1A2A-4DCF-B1D3-6B1368318F89");
            Guid Dietician= new Guid("0a5a3824-d3fa-4400-a3c1-c2a8906726a5");
            Guid Psychologist= new Guid("fa55ee1d-3048-453d-b46d-64ea35953e50");
            
            base.PreScript();
            if(this.RequestDoctor.SelectedObject == null)
            {
                this.SetProcedureDoctorAsCurrentResource();
                /*if(Common.CurrentUser.HasRole(Doctor) || Common.CurrentUser.HasRole(Dietician)|| Common.CurrentUser.HasRole(Psychologist))
                {
                    this.RequestDoctor.SelectedObject = Common.CurrentResource;
                }*/
            }
            if(this.RequestDoctor.SelectedObject != null)
                this.RequestDoctor.ReadOnly=true;
            else
                this.RequestDoctor.ReadOnly=false;
         
            
            TTObjectContext rocontext = new TTObjectContext(true);
            // anestezi konsültasyonu isteğı yapılan birimlere burda istek yapılamasın
            string filter = "";
            
            BindingList<ActionDefaultMasterResourceDefinition> adMasterResourceDefinitionList = ActionDefaultMasterResourceDefinition.GetByActionType(rocontext, ActionTypeEnum.AnesthesiaConsultation);
            
            foreach (ActionDefaultMasterResourceDefinition adMasterResourceDefinition in adMasterResourceDefinitionList)
            {
                foreach(ActionDefaultMasterResourceGrid adMasterResourceGrid in adMasterResourceDefinition.MasterResources)
                {
                    if(adMasterResourceGrid.Resource != null)
                    {
                        if(filter == "")
                            filter += " OBJECTID NOT IN(";
                        else
                            filter += ",";
                        filter += "'" + adMasterResourceGrid.Resource.ObjectID.ToString() + "'";
                    }
                }
                break;
            }
            if(filter != "")
                filter += ")";
            
            ((ITTListBoxColumn)((ITTGridColumn)this.ConsultationProcedures.Columns["MasterResource"])).ListFilterExpression =  filter;
#endregion ConsultationRequestFormsil_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsultationRequestFormsil_PostScript
    base.PostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.ToStateDefID!=ConsultationRequest.States.Cancelled)
                {
                    if (this.RequestDescription.Text == null || this.RequestDescription.Text == "")
                        throw new Exception(SystemMessage.GetMessage(639));
                    
                   // this._ConsultationRequest.IsPatientApprovalFormGiven=GetIfPatientApprovalFormIsGiven(this._ConsultationRequest.IsPatientApprovalFormGiven);
                }
            }
#endregion ConsultationRequestFormsil_PostScript

            }
            
#region ConsultationRequestFormsil_Methods
        //        void ShowAction_ObjectUpdated(TTObject ttObject)
        //        {
        //            OnObjectUpdated(ttObject);
        //        }


        
#endregion ConsultationRequestFormsil_Methods
    }
}