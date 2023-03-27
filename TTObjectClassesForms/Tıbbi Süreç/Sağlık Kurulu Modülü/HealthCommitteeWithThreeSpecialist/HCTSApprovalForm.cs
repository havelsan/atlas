
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
    /// Üç Uzman Tabip İmzalı Rapor
    /// </summary>
    public partial class HCTSApprovalForm : EpisodeActionForm
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
#region HCTSApprovalForm_PreScript
    base.PreScript();
            //this.SetEpisodeRelations();

            //if(this._HealthCommitteeWithThreeSpecialist.ReportDate == null)
            //    this._HealthCommitteeWithThreeSpecialist.ReportDate = Common.RecTime();


            // Rapor Numarası verildikten sonra, raporun doktorlar tarafından tekrar alınamaması için
            // SuperUser veya HealthCommitteeWithThreeSpecialistReportRoleID rolü varsa raporu alabilir
            if (this._HealthCommitteeWithThreeSpecialist.ReportNo.Value != null)
            {
                if (!(Common.CurrentUser.IsSuperUser || Common.CurrentUser.HasRole(TTObjectClasses.Common.HealthCommitteeWithThreeSpecialistReportRoleID) || HealthCommitteeWithThreeSpecialist.IsCurrentUserOneOfSpecialists(this._HealthCommitteeWithThreeSpecialist) == 1))
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_HealthCommitteeWithThreeSpecialistReport));
            }

            //Picture Setting
            //GroupBox pBox2 = (GroupBox)this.ttgroupbox2;
            //PictureBox pic = new PictureBox();
            ////pic.Dock = DockStyle.Fill;
            //pic.BackgroundImage = (Image)this._HealthCommitteeWithThreeSpecialist.Picture;
            //pic.BackgroundImageLayout = ImageLayout.Zoom;
            //pBox2.Controls.Add(pic);
            
            // tabReport taki 3 tabdan uygun olanı açar, diğerlerini kapatır
            foreach(ITTTabPage tabPage in tabReport.TabPages)
            {
                if(tabPage.Visible == false)
                    tabReport.HideTabPage(tabPage);
            }
            
            if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason != null && this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.HasValue)
            {
                if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.Material)
                    this.tabReport.ShowTabPage(Material);
                else if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.Rest)
                    this.tabReport.ShowTabPage(Rest);
                else if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.SituationInformOneDoctor)
                    this.tabReport.ShowTabPage(InformOneDoctor);
            }           
         
#endregion HCTSApprovalForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region HCTSApprovalForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (this._HealthCommitteeWithThreeSpecialist.CurrentStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval))
            {
                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2 != null)
                {
                    if (Common.CurrentUser.IsSuperUser == false && this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                    {
                        if (Common.CurrentResource.SelectedOutPatientResource.ObjectID == this._HealthCommitteeWithThreeSpecialist.MasterResource.ObjectID)
                        {
                            string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Üç Uzman Tabip İmzalı Rapor", "İşlemin 2. uzman tabibi :  " + this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2.Name + " . \r\nİşlemi yine de açmak istediğinize emin misiniz? \r\n \r\nBilgi: İşlemi açtığınızda 2. uzman tabip olarak kaydedileceksiniz.");
                            if (result == "E")
                                this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2 = Common.CurrentResource;
                            else
                                throw new Exception(SystemMessage.GetMessage(80));
                        }
                    }
                }
            }
            else if (this._HealthCommitteeWithThreeSpecialist.CurrentStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval))
            {
                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3 != null)
                {
                    if (Common.CurrentUser.IsSuperUser == false && this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3.ObjectID.ToString() != Common.CurrentResource.ObjectID.ToString())
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Üç Uzman Tabip İmzalı Rapor", "İşlemin 3. uzman tabibi :  " + this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3.Name + " . \r\nİşlemi yine de açmak istediğinize emin misiniz? \r\n \r\nBilgi: İşlemi açtığınızda 3. uzman tabip olarak kaydedileceksiniz.");
                        if (result == "E")
                            this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3 = Common.CurrentResource;
                        else
                            throw new Exception(SystemMessage.GetMessage(80));
                    }
                }
                
                if (this._HealthCommitteeWithThreeSpecialist.FirstAdditionalUnit != null)
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit);
                else
                {
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit);
                    if (this._HealthCommitteeWithThreeSpecialist.SecondAdditionalUnit == null)
                        this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit);
                }

                if (this._HealthCommitteeWithThreeSpecialist.FirstAdditionalUnit != null || this._HealthCommitteeWithThreeSpecialist.SecondAdditionalUnit != null)
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
            }
            else if (this._HealthCommitteeWithThreeSpecialist.CurrentStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit))
            {
                if (this._HealthCommitteeWithThreeSpecialist.SecondAdditionalUnit == null)
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit);

                if (this._HealthCommitteeWithThreeSpecialist.SecondAdditionalUnit != null)
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
            }
#endregion HCTSApprovalForm_ClientSidePreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCTSApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                if (transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval) ||
                    transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.ThirdSpecialistApproval) ||
                    transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.FirstAdditionalUnit) ||
                    transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.SecondAdditionalUnit))
                {
                    if (transDef.ToStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.New))
                        this.ReturnDescription();
                }
            }
#endregion HCTSApprovalForm_ClientSidePostScript

        }

#region HCTSApprovalForm_Methods
        private void SetEpisodeRelations()
        {
           // MilitaryClassDefinitions militaryClass = this._HealthCommitteeWithThreeSpecialist.Episode.MyMilitaryClass();
           // if (militaryClass != null)
           //     this.MilitaryClass.SelectedObjectID = militaryClass.ObjectID;

           // RankDefinitions rank = this._HealthCommitteeWithThreeSpecialist.Episode.MyRank();
           // if (rank != null)
           //     this.Rank.SelectedObjectID = rank.ObjectID;

           //// this.Adres.Text = this._HealthCommitteeWithThreeSpecialist.SubEpisode.PatientAdmission.HomeAddress;

           // MilitaryUnit theUnit = this._HealthCommitteeWithThreeSpecialist.Episode.MyMilitaryUnit();
           // if (theUnit != null)
           //     this.MilitaryUnit.SelectedObjectID = theUnit.ObjectID;

           // this.EmploymentRecordID.Text = this._HealthCommitteeWithThreeSpecialist.Episode.MyEmploymentRecordID();
        }

        #endregion HCTSApprovalForm_Methods

        #region HCTSApprovalForm_ClientSideMethods
        private void ReturnDescription()
        {
            //TODO:ShowEdit!
            //StringEntryForm pReturnForm = new StringEntryForm();
            //DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Griniz");
            //if (res == DialogResult.OK)
            //{
            //    HealthCommittee_ReturnDescriptionsGrid theGrid = null;
            //    theGrid = new HealthCommittee_ReturnDescriptionsGrid(this._HealthCommitteeWithThreeSpecialist.ObjectContext);
            //    theGrid.Description = pReturnForm.StringContent;
            //    theGrid.EntryDate = DateTime.Now;
            //    theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;

            //    this._HealthCommitteeWithThreeSpecialist.ReturnDescriptions.Add(theGrid);
            //}
            var a = 1;
        }

        #endregion HCTSApprovalForm_ClientSideMethods
    }
}