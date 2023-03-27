
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
    /// Laboratuvar Önceki Sonuçlar Bildirimi
    /// </summary>
    public partial class LabPreviousResultNotificationForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton_Cancel.Click += new TTControlEventDelegate(ttbutton_Cancel_Click);
            ttbutton_Proceed.Click += new TTControlEventDelegate(ttbutton_Proceed_Click);
            ttbutton_PrintReport.Click += new TTControlEventDelegate(ttbutton_PrintReport_Click);
            ttbutton_OpenAction.Click += new TTControlEventDelegate(ttbutton_OpenAction_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton_Cancel.Click -= new TTControlEventDelegate(ttbutton_Cancel_Click);
            ttbutton_Proceed.Click -= new TTControlEventDelegate(ttbutton_Proceed_Click);
            ttbutton_PrintReport.Click -= new TTControlEventDelegate(ttbutton_PrintReport_Click);
            ttbutton_OpenAction.Click -= new TTControlEventDelegate(ttbutton_OpenAction_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton_Cancel_Click()
        {
#region LabPreviousResultNotificationForm_ttbutton_Cancel_Click
   //Vazgeç
            proceed = false;
            this.Tag = proceed;
            this.Close();
#endregion LabPreviousResultNotificationForm_ttbutton_Cancel_Click
        }

        private void ttbutton_Proceed_Click()
        {
#region LabPreviousResultNotificationForm_ttbutton_Proceed_Click
   //Devam
            proceed = true;
            this.Tag = proceed;
            this.Close();
#endregion LabPreviousResultNotificationForm_ttbutton_Proceed_Click
        }

        private void ttbutton_PrintReport_Click()
        {
#region LabPreviousResultNotificationForm_ttbutton_PrintReport_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            pc.Add("VALUE", laboratoryProcedure.EpisodeAction.ObjectID.ToString());
            parameters.Add("TTOBJECTID", pc);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryResultReport), true, 1, parameters);
#endregion LabPreviousResultNotificationForm_ttbutton_PrintReport_Click
        }

        private void ttbutton_OpenAction_Click()
        {
#region LabPreviousResultNotificationForm_ttbutton_OpenAction_Click
   EpisodeAction episodeAction = null;
            if(laboratoryProcedure != null)
                episodeAction = laboratoryProcedure.EpisodeAction;
            if(nuclearMedicine != null)
                episodeAction = nuclearMedicine;
            TTForm form = TTForm.GetEditForm(episodeAction);
            form.ShowReadOnly(this, episodeAction);
#endregion LabPreviousResultNotificationForm_ttbutton_OpenAction_Click
        }

#region LabPreviousResultNotificationForm_Methods
        public bool proceed = false;
        public LaboratoryProcedure laboratoryProcedure;
        
        public NuclearMedicine nuclearMedicine;
        
        public LabPreviousResultNotificationForm(LaboratoryProcedure laboratoryProcedure,ref bool goOn) :this()
        {
            this.laboratoryProcedure = laboratoryProcedure;
            this.proceed = goOn;

            this.ControlBox = false;
            this.ShowInTaskbar = false;

            this.ttlabel_Header.Text = "Hastanın vakasında, daha önceden istenmiş tetkik tespit edilmiştir. \n Tetkik istek işlemine devam etmek istiyor musunuz?";
            this.ttlabel_TestName.Text = laboratoryProcedure.ProcedureObject != null ? laboratoryProcedure.ProcedureObject.Code.Trim()+" "+laboratoryProcedure.ProcedureObject.Name.Trim() : string.Empty;
            this.tttextbox_CurrentState.Text = ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).CurrentStateDef.DisplayText.Trim();
            this.tttextbox_ID.Text = ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).ID.Value.ToString();
            this.tttextbox_RequestDate.Text = ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).RequestDate != null ? ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).RequestDate.Value.ToString() : string.Empty;
            this.tttextbox_WorkListDate.Text = laboratoryProcedure.WorkListDate != null ? laboratoryProcedure.WorkListDate.Value.ToString() : string.Empty;
        }
        
        public LabPreviousResultNotificationForm(Guid labProcObjectID,string formHeaderText,string notificationText) :this()
        {
            TTObjectContext readOnlyContext = new TTObjectContext(true);
            LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)readOnlyContext.GetObject(labProcObjectID, typeof(LaboratoryProcedure));
            
            this.laboratoryProcedure = laboratoryProcedure;
            this.Text = formHeaderText;
            
            this.ttbutton_Proceed.Text = "Tamam";
            this.ttbutton_PrintReport.Visible = false;
            this.ttbutton_Cancel.Visible = false;

            this.ControlBox = false;
            this.ShowInTaskbar = false;

            this.ttlabel_Header.Text = notificationText;
            this.ttlabel_TestName.Text = laboratoryProcedure.ProcedureObject != null ? laboratoryProcedure.ProcedureObject.Code.Trim()+" "+laboratoryProcedure.ProcedureObject.Name.Trim() : string.Empty;
            this.tttextbox_CurrentState.Text = ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).CurrentStateDef.DisplayText.Trim();
            this.tttextbox_ID.Text = ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).ID.Value.ToString();
            this.tttextbox_RequestDate.Text = ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).RequestDate != null ? ((LaboratoryRequest)laboratoryProcedure.EpisodeAction).RequestDate.Value.ToString() : string.Empty;
            this.tttextbox_WorkListDate.Text = laboratoryProcedure.WorkListDate != null ? laboratoryProcedure.WorkListDate.Value.ToString() : string.Empty;
        }
        
        public LabPreviousResultNotificationForm(NuclearMedicine nuclearMedicine) : this()
        {
            this.nuclearMedicine = nuclearMedicine;
            
            this.Text = "Nükleer Tıp Rapor Sonuç Bildirimi";
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            
            this.ttbutton_PrintReport.Visible = false;
            this.ttbutton_Proceed.Text = "Onayla";
            
            this.ttlabel_Header.Text = "Hastanın vakasında, tamamlanmış Nükleer Tıp işlemi tespit edilmiştir. \n Nükleer Tıp işlem raporu, Patoloji isteğinin 'Kısa anamnez ve Klinik bulgular' alanına kopyalanacaktır. \n Onaylıyor musunuz?";
            this.ttlabel_TestName.Text = nuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null ? nuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Code.Trim() + " " +nuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name.Trim() : string.Empty;
            this.tttextbox_CurrentState.Text = nuclearMedicine.CurrentStateDef.DisplayText.Trim();
            this.tttextbox_ID.Text = nuclearMedicine.ID.Value.ToString();
            this.tttextbox_RequestDate.Text = nuclearMedicine.RequestDate != null ? nuclearMedicine.RequestDate.Value.ToString() : string.Empty;
            this.tttextbox_WorkListDate.Text = nuclearMedicine.WorkListDate != null ? nuclearMedicine.WorkListDate.Value.ToString() : string.Empty;  
            
        }
        
#endregion LabPreviousResultNotificationForm_Methods
    }
}