
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
    public partial class PlannedMedicalActionPlanForm : BasePlannedMedicalActionOrderForm
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
#region PlannedMedicalActionPlanForm_PreScript
    base.PreScript();
            if (this._PlannedMedicalActionOrder.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
            {
                this.labelReasonOfRejection.Visible = false;
                this.ReasonOfRejection.Visible = false;
            }
            
             //DP gelistirme, PlannedMedicalActionRequest teki ProcedureDoctor alani  set edilecek.
            if ( this._PlannedMedicalActionOrder.PlannedMedicalActionRequest.ProcedureDoctor != null )
                this.ProcedureDoctor.SelectedObject = this._PlannedMedicalActionOrder.PlannedMedicalActionRequest.ProcedureDoctor;
#endregion PlannedMedicalActionPlanForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PlannedMedicalActionPlanForm_PostScript
    base.PostScript(transDef);
#endregion PlannedMedicalActionPlanForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PlannedMedicalActionPlanForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.ToStateDefID==PlannedMedicalActionOrder.States.Plan)
                {
                    BindingList<PlannedMedicalActionOrder> MySiblingObject = PlannedMedicalActionOrder.GetMySiblingObjectsForAppointment(this._PlannedMedicalActionOrder.ObjectContext, this._PlannedMedicalActionOrder.Episode.ObjectID.ToString(), this._PlannedMedicalActionOrder.ObjectID.ToString());
                    if(MySiblingObject.Count>0)
                    {
                        string result = "";
                        if (TTObjectClasses.SystemParameter.GetParameterValue("ASKFORPLANALLORDERS", "TRUE") == "FALSE")
                            result = "E";
                        else
                            result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Planlı Tıbbi İşlem Planlama","Diğer Planlı Tıbbi İşlem Emirlerini de 'Planlama' adımına almak ister misiniz?");
                        if(result == "E")
                        {
                            foreach (PlannedMedicalActionOrder plannedMedicalActionOrder in MySiblingObject)
                            {
                                if(plannedMedicalActionOrder.CurrentStateDefID == PlannedMedicalActionOrder.States.RequestAcception)
                                    plannedMedicalActionOrder.CurrentStateDefID = PlannedMedicalActionOrder.States.Plan;
                            }
                        }
                    }
                }
                else if(transDef.FromStateDefID == PlannedMedicalActionOrder.States.RequestAcception && transDef.ToStateDefID == PlannedMedicalActionOrder.States.Therapy)
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Planlı Tıbbi İşlem Planlama","Planlı Tıbbi İşlem Uygulamalarını, planlama yapmadan oluşturmak istediğinize emin misiniz?");
                    if(result == "H")
                        throw new Exception("İşlemden vazgeçildi.");
                    if(this._PlannedMedicalActionOrder.TreatmentStartDateTime == null)
                        throw new Exception("'Tedavi Başlangıç Tarih Saati' ni seçiniz.");
                    result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Planlı Tıbbi İşlem Planlama","Planlı Tıbbi İşlem Uygulamaları," + this._PlannedMedicalActionOrder.TreatmentStartDateTime.Value.ToString("dd.MM.yyyy HH:mm") +" tarihinden itibaren " + this._PlannedMedicalActionOrder.Amount.ToString() + " gün boyunca oluşturulacak.\r\nİşlemi onaylıyor musunuz?");
                    if(result == "H")
                        throw new Exception("İşlemden vazgeçildi.");
                }
            }
#endregion PlannedMedicalActionPlanForm_ClientSidePostScript

        }
    }
}