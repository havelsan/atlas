
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
    /// Hiperbarik Oksijen Tedavi Uygulamaları
    /// </summary>
    public partial class HyperbarikOxygenTreatmentOrderDetailForm : SubactionProcedureFlowableForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region HyperbarikOxygenTreatmentOrderDetailForm_PreScript
    base.PreScript();
            
            int index = 0;
            
            this.tttextboxDescription.Text = string.Empty;
            //TODO:pnlControls!
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;
            
            if (this._HyperbarikOxygenTreatmentOrderDetail.GetStateHistory().Count > 1)
            {
                index = this._HyperbarikOxygenTreatmentOrderDetail.GetStateHistory().Count-1;
                if(this._HyperbarikOxygenTreatmentOrderDetail.GetStateHistory()[index].IsUndo == true || this._HyperbarikOxygenTreatmentOrderDetail.CurrentStateDefID != HyperbarikOxygenTreatmentOrderDetail.States.Execution)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._HyperbarikOxygenTreatmentOrderDetail);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._HyperbarikOxygenTreatmentOrderDetail);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._HyperbarikOxygenTreatmentOrderDetail);
            }
            
           
            if(((HyperbaricOxygenTreatmentOrder)this._HyperbarikOxygenTreatmentOrderDetail.OrderObject).HyperOxygenTreatmentRequest.ProcedureDoctor != null)
            {
                ResUser doctor = ((HyperbaricOxygenTreatmentOrder)this._HyperbarikOxygenTreatmentOrderDetail.OrderObject).HyperOxygenTreatmentRequest.ProcedureDoctor;
                if(doctor.ResourceSpecialities.Count > 0)
                {
                    bool searchForMainSpeciality = false;
                    if(doctor.ResourceSpecialities.Count>1)
                        searchForMainSpeciality = true;
                    foreach(ResourceSpecialityGrid speciality in doctor.ResourceSpecialities)
                    {
                        if(searchForMainSpeciality == false)
                        {
                            this.ProcedureSpeciality.SelectedObject = speciality.Speciality;
                            break;
                        }
                        else
                        {
                            if (speciality.MainSpeciality == true)
                            {
                                this.ProcedureSpeciality.SelectedObject = speciality.Speciality;
                                break;
                            }
                        }
                    }
                }
            }
            
            if (this._HyperbarikOxygenTreatmentOrderDetail.CurrentStateDefID == HyperbarikOxygenTreatmentOrderDetail.States.Execution)
            {
                this._HyperbarikOxygenTreatmentOrderDetail.ActionDate = Common.RecTime();
            }
            
            this.cmdOK.Visible = false;
            
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["HyperbarikOxygenTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
            
            //DP Gelistirme, ilk acilista islemi yapacak olan operator bilgisi Tedavi emri isleminde girilen Operator bilgisi olarak set edilecek.
            if (this._HyperbarikOxygenTreatmentOrderDetail.OrderObject.ProcedureByUser != null)
            {
                 if (this._HyperbarikOxygenTreatmentOrderDetail.ProcedureByUser == null)
                    this.ProcedureDoctor.SelectedObject = this._HyperbarikOxygenTreatmentOrderDetail.OrderObject.ProcedureByUser;
            }
#endregion HyperbarikOxygenTreatmentOrderDetailForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbarikOxygenTreatmentOrderDetailForm_PostScript
    base.PostScript(transDef);
            
            if (this._HyperbarikOxygenTreatmentOrderDetail.ActionDate == null)
                throw new Exception("Uygulama Tarihi boş geçilemez.");
            
            if (this._HyperbarikOxygenTreatmentOrderDetail.ProcedureSpeciality == null)
                throw new Exception("İşlemin Yapıldığı Uzmanlık Dalı boş geçilemez.");
#endregion HyperbarikOxygenTreatmentOrderDetailForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbarikOxygenTreatmentOrderDetailForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            
            if (transDef.FromStateDefID == HyperbarikOxygenTreatmentOrderDetail.States.Execution && transDef.ToStateDefID == HyperbarikOxygenTreatmentOrderDetail.States.Completed)
            {
                
                bool allComplete=true;
                foreach (SubActionProcedure orderDetail in this._HyperbarikOxygenTreatmentOrderDetail.OrderObject.OrderDetails)
                {
                    if (orderDetail.CurrentStateDef.Status== StateStatusEnum.Uncompleted && orderDetail.ObjectID!=this._HyperbarikOxygenTreatmentOrderDetail.ObjectID)
                    {
                        allComplete=false;
                    }
                }
                if (allComplete)
                {
                    //HyperbaricOxygenTreatmentOrder tedavi raporu print edilecek
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> reportNoParam = new TTReportTool.PropertyCache<object>();
                    reportNoParam.Add("VALUE", this._HyperbarikOxygenTreatmentOrderDetail.OrderObject.ObjectID);
                    parameter.Add("TTOBJECTID", reportNoParam);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HyperbaricOxygenResultReport), true, 1, parameter);
                }
            }
#endregion HyperbarikOxygenTreatmentOrderDetailForm_ClientSidePostScript

        }
    }
}