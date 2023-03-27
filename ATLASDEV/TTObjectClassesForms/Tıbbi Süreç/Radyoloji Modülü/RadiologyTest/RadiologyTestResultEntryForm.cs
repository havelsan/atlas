
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
    /// Radyoloji Sonuç Giriş Formu
    /// </summary>
    public partial class RadiologyTestResultEntryForm : RadiologyTestBaseForm
    {
        override protected void BindControlEvents()
        {
            ttMasterResourceUserCheck.CheckedChanged += new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            Materials.CellContentClick += new TTGridCellEventDelegate(Materials_CellContentClick);
            cmdImage.Click += new TTControlEventDelegate(cmdImage_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttMasterResourceUserCheck.CheckedChanged -= new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            Materials.CellContentClick -= new TTGridCellEventDelegate(Materials_CellContentClick);
            cmdImage.Click -= new TTControlEventDelegate(cmdImage_Click);
            base.UnBindControlEvents();
        }

        private void ttMasterResourceUserCheck_CheckedChanged()
        {
#region RadiologyTestResultEntryForm_ttMasterResourceUserCheck_CheckedChanged
   if (this.ttMasterResourceUserCheck.Value == true)
            {
                this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.ToString() + "'";
            }
            else
            {
                this.ReportedBy.ListFilterExpression = null;
            }
#endregion RadiologyTestResultEntryForm_ttMasterResourceUserCheck_CheckedChanged
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            //TODO:ShowEdit!
            #region RadiologyTestResultEntryForm_GridEpisodeDiagnosis_CellContentClick
            //   if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
            //            {

            //                RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
            //                rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
            //            }
            var a = 1;
            #endregion RadiologyTestResultEntryForm_GridEpisodeDiagnosis_CellContentClick

        }

        private void ttbuttonToothSchema_Click()
        {
            //TODO:Showedit!
            #region RadiologyTestResultEntryForm_ttbuttonToothSchema_Click
            //   RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
            //            if (radiologyTestDentalForm != null)
            //                radiologyTestDentalForm.ShowReadOnly(this,_RadiologyTest);
            var a = 1;
            #endregion RadiologyTestResultEntryForm_ttbuttonToothSchema_Click
        }

        private void Materials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            //TODO:Showedit!
            #region RadiologyTestResultEntryForm_Materials_CellContentClick
            //            if (((ITTGridCell)Materials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
            //            {

            //                RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
            //                rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
            //            }
            var a = 1;
            #endregion RadiologyTestResultEntryForm_Materials_CellContentClick
        }

        private void cmdImage_Click()
        {
            //TODO:Showedit!
            #region RadiologyTestResultEntryForm_cmdImage_Click
            //            string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
            //            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
            //            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
            var a = 1;
            #endregion RadiologyTestResultEntryForm_cmdImage_Click
        }

        protected override void PreScript()
        {
#region RadiologyTestResultEntryForm_PreScript
    base.PreScript();
    this.SetProcedureDoctorAsCurrentResource();

            if (this.ttMasterResourceUserCheck.Value != null && this.ttMasterResourceUserCheck.Value == true)
            {
                this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.ToString() + "'";
            }
            
            Guid guidRoleID = new Guid("c318a87a-c781-4024-b4b1-d6c3bffe9bc6"); //Radyoloji Uzmanı roleID
            if(Common.CurrentUser.HasRole(guidRoleID))
            {
                this.DropStateButton(RadiologyTest.States.Approve);
            }
            else
            {
                this.DropStateButton(RadiologyTest.States.Completed);
            }

            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["RadiologyMaterial"], (ITTGridColumn)this.Materials.Columns["Material"]);

            if (((ITTObject)this._RadiologyTest).IsReadOnly == false)
            {
                this._RadiologyTest.ReportedBy = Common.CurrentResource;
            }
            
            if (this._RadiologyTest.IsGunubirlikTakip == true && this._RadiologyTest.SubEpisode.IsSGK)
            {
                this.rtfReport.Required = true;
            }
#endregion RadiologyTestResultEntryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestResultEntryForm_PostScript
    base.PostScript(transDef);

            // Yatan hastalarda rapor alanı zorunlu yapıldı
            /*if (this._RadiologyTest.Episode.PatientStatus != null)
            {
                if (this._RadiologyTest.Episode.PatientStatus.Value == PatientStatusEnum.Inpatient)
                {
                    this.rtfReport.Required = true;
                }
            }

            if (_RadiologyTest.Episode.IsMedulaEpisode())
            {
                string rtfStr = Common.GetTextOfRTFString(rtfReport.Rtf);
                if (rtfStr != null && string.IsNullOrEmpty(Description.Text))
                    throw new TTUtils.TTException("'Rapor' alanının boş olmadığı durumlarda 'Açıklama' alanına veri girişi zorunludur.");
            }*/
#endregion RadiologyTestResultEntryForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestResultEntryForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                if (transDef.FromStateDefID == RadiologyTest.States.ResultEntry &&  transDef.ToStateDefID  == RadiologyTest.States.Procedure) 
                    this.DisplayRadiologyRepeatReason();
                
                if (transDef.FromStateDefID == RadiologyTest.States.ResultEntry && transDef.ToStateDefID  == RadiologyTest.States.Completed)
                    this.LinkRadiologyTestToCopyReportInfo(transDef);
            }
#endregion RadiologyTestResultEntryForm_ClientSidePostScript

        }
    }
}