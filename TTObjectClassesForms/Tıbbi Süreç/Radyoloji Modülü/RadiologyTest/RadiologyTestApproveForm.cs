
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
    /// Radyoloji Onay Formu
    /// </summary>
    public partial class RadiologyTestApproveForm : RadiologyTestBaseForm
    {
        override protected void BindControlEvents()
        {
            ttMasterResourceUserCheck.CheckedChanged += new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            cmdReport.Click += new TTControlEventDelegate(cmdReport_Click);
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            cmdSaveAndPrint.Click += new TTControlEventDelegate(cmdSaveAndPrint_Click);
            ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            Materials.CellContentClick += new TTGridCellEventDelegate(Materials_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttMasterResourceUserCheck.CheckedChanged -= new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            cmdReport.Click -= new TTControlEventDelegate(cmdReport_Click);
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            cmdSaveAndPrint.Click -= new TTControlEventDelegate(cmdSaveAndPrint_Click);
            ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            Materials.CellContentClick -= new TTGridCellEventDelegate(Materials_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ttMasterResourceUserCheck_CheckedChanged()
        {
#region RadiologyTestApproveForm_ttMasterResourceUserCheck_CheckedChanged
   if (this.ttMasterResourceUserCheck.Value == true)
            {
                this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.ToString() + "'";
                this.ApprovedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.ToString() + "'";
            }
            else
            {
                this.ReportedBy.ListFilterExpression = null;
                this.ApprovedBy.ListFilterExpression = null;
            }
#endregion RadiologyTestApproveForm_ttMasterResourceUserCheck_CheckedChanged
        }

        private void cmdReport_Click()
        {
#region RadiologyTestApproveForm_cmdReport_Click
   string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
#endregion RadiologyTestApproveForm_cmdReport_Click
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region RadiologyTestApproveForm_GridEpisodeDiagnosis_CellContentClick

            //TODO:ShowEdit!
            //if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
            //{

            //    RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
            //    rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
            //}
            var a = 1;
            #endregion RadiologyTestApproveForm_GridEpisodeDiagnosis_CellContentClick
        }

        private void cmdSaveAndPrint_Click()
        {
#region RadiologyTestApproveForm_cmdSaveAndPrint_Click
   this._RadiologyTest.ObjectContext.Save();

            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", this._RadiologyTest.ObjectID.ToString());

            parameters.Add("TTOBJECTID", objectID);

            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyTestResultReport), true, 1, parameters);
#endregion RadiologyTestApproveForm_cmdSaveAndPrint_Click
        }

        private void ttbuttonToothSchema_Click()
        {
            #region RadiologyTestApproveForm_ttbuttonToothSchema_Click
            //TODO:ShowEdit!
            //RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
            //if (radiologyTestDentalForm != null)
            //    radiologyTestDentalForm.ShowReadOnly(this,_RadiologyTest);
            var a = 1;
            #endregion RadiologyTestApproveForm_ttbuttonToothSchema_Click
        }

        private void Materials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region RadiologyTestApproveForm_Materials_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)Materials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
            //{
            //    RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
            //    rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
            //}
            var a = 1;
            #endregion RadiologyTestApproveForm_Materials_CellContentClick
        }

        protected override void PreScript()
        {
#region RadiologyTestApproveForm_PreScript
    base.PreScript();

            this.SetProcedureDoctorAsCurrentResource();
            
            if(!((ITTObject)this._RadiologyTest).IsReadOnly)
            {
                //this._RadiologyTest.ApprovedBy = Common.CurrentResource;
                 this._RadiologyTest.ApprovedBy = this._RadiologyTest.ProcedureDoctor;
            }
            
            
            if (this.ttMasterResourceUserCheck.Value != null && this.ttMasterResourceUserCheck.Value == true)
            {
                this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.ToString() + "'";
                this.ApprovedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.ToString() + "'";
            }
#endregion RadiologyTestApproveForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestApproveForm_PostScript
    base.PostScript(transDef);


            // Yatan hastalarda rapor alanı zorunlu yapıldı
            /*if (this._RadiologyTest.Episode.PatientStatus != null) //Zaten state geçişinde kontrol yapılıyor.
            {
                if (this._RadiologyTest.Episode.PatientStatus.Value == PatientStatusEnum.Inpatient)
                {
                    if (string.IsNullOrEmpty(this.rtfReport.Text))
                    {
                        this.rtfReport.Text = "...";
                    }
                    if (string.IsNullOrEmpty(this.Description.Text))
                    {
                        this.Description.Text = "...";
                    }
                    this.rtfReport.Required = true;
                }
            }*/
#endregion RadiologyTestApproveForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestApproveForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                if (transDef.FromStateDefID == RadiologyTest.States.Approve &&  transDef.ToStateDefID  == RadiologyTest.States.Procedure)
                    this.DisplayRadiologyRepeatReason();
                
                if (transDef.FromStateDefID == RadiologyTest.States.Approve  && transDef.ToStateDefID  == RadiologyTest.States.Completed)
                    this.LinkRadiologyTestToCopyReportInfo(transDef);
            }
#endregion RadiologyTestApproveForm_ClientSidePostScript

        }
    }
}