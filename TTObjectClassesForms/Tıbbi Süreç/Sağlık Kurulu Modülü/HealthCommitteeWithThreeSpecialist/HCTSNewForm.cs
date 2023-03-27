
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
    public partial class HCTSNewForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SecondAdditionalUnit.SelectedObjectChanged += new TTControlEventDelegate(SecondAdditionalUnit_SelectedObjectChanged);
            FirstAdditionalUnit.SelectedObjectChanged += new TTControlEventDelegate(FirstAdditionalUnit_SelectedObjectChanged);
          //  GridHospitalsUnits.RowLeave += new TTGridCellEventDelegate(GridHospitalsUnits_RowLeave);
            ReasonForExamination.SelectedObjectChanged += new TTControlEventDelegate(ReasonForExamination_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SecondAdditionalUnit.SelectedObjectChanged -= new TTControlEventDelegate(SecondAdditionalUnit_SelectedObjectChanged);
            FirstAdditionalUnit.SelectedObjectChanged -= new TTControlEventDelegate(FirstAdditionalUnit_SelectedObjectChanged);
           // GridHospitalsUnits.RowLeave -= new TTGridCellEventDelegate(GridHospitalsUnits_RowLeave);
            ReasonForExamination.SelectedObjectChanged -= new TTControlEventDelegate(ReasonForExamination_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void SecondAdditionalUnit_SelectedObjectChanged()
        {
#region HCTSNewForm_SecondAdditionalUnit_SelectedObjectChanged
   //            if(this.SecondAdditionalUnit.SelectedObject != null)
            //                this.AdditionalSpecialist2.ListFilterExpression= "USERRESOURCES.RESOURCE='" + this.SecondAdditionalUnit.SelectedObjectID.ToString()+ "'";
            //            else
            //                this.AdditionalSpecialist1.ListFilterExpression= "1=0";
#endregion HCTSNewForm_SecondAdditionalUnit_SelectedObjectChanged
        }

        private void FirstAdditionalUnit_SelectedObjectChanged()
        {
#region HCTSNewForm_FirstAdditionalUnit_SelectedObjectChanged
   //            if(this.FirstAdditionalUnit.SelectedObject != null)
            //                this.AdditionalSpecialist1.ListFilterExpression= "USERRESOURCES.RESOURCE='" + this.FirstAdditionalUnit.SelectedObjectID.ToString()+ "'";
            //            else
            //                this.AdditionalSpecialist1.ListFilterExpression= "1=0";
#endregion HCTSNewForm_FirstAdditionalUnit_SelectedObjectChanged
        }

        private void GridHospitalsUnits_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region HCTSNewForm_GridHospitalsUnits_RowLeave
   //            ITTGridRow rowHospitalUnits = this.GridHospitalsUnits.Rows[this.GridHospitalsUnits.CurrentCell.RowIndex];
            //            if (rowHospitalUnits.Cells[1].Value == null)  // Burada araya colon eklenir de sayısı değişirse sorun olabilir.
            //            {
            //                throw new TTException("Birim boş olamaz.");
            //            }
#endregion HCTSNewForm_GridHospitalsUnits_RowLeave
        }

        private void ReasonForExamination_SelectedObjectChanged()
        {
#region HCTSNewForm_ReasonForExamination_SelectedObjectChanged
   // Butonları açar ve kapar
            this.AddStateButton(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval);
            this.AddStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
            if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason != null && this._HealthCommitteeWithThreeSpecialist.ExaminationReason.SpecialistCount.HasValue)
            {
                if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason.SpecialistCount.Value == HCTSpecialistCountEnum.OneSpecialist)
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval);
                else if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.SpecialistCount.Value == HCTSpecialistCountEnum.ThreeSpecialist)
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
            }
            else
                this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
            
            // tabReport taki 3 tabdan uygun olanı açar, diğerlerini kapatır
            if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason != null && this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.HasValue)
            {
                foreach(ITTTabPage tabPage in tabReport.TabPages)
                {
                    if(tabPage.Visible == false)
                        tabReport.HideTabPage(tabPage);
                }
                
                if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.Material)
                {
                    this.tabReport.ShowTabPage(Material);
                    this._HealthCommitteeWithThreeSpecialist.DecisionDate = null;
                    this._HealthCommitteeWithThreeSpecialist.RestReportDecision = null;
                    this._HealthCommitteeWithThreeSpecialist.SituationInformODDecision = null;
                    this._HealthCommitteeWithThreeSpecialist.SituationInformODReportType = null;
                    this._HealthCommitteeWithThreeSpecialist.NoObstacleDescription = null;
                }
                else if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.Rest)
                {
                    this.tabReport.ShowTabPage(Rest);
                    this._HealthCommitteeWithThreeSpecialist.SituationInformODDecision = null;
                    this._HealthCommitteeWithThreeSpecialist.SituationInformODReportType = null;
                    this._HealthCommitteeWithThreeSpecialist.NoObstacleDescription = null;
                }
                else if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.Value == HCThreeSpecialistReportTypeEnum.SituationInformOneDoctor)
                {
                    this.tabReport.ShowTabPage(InformOneDoctor);
                    this._HealthCommitteeWithThreeSpecialist.ReportStartDate = null;
                    this._HealthCommitteeWithThreeSpecialist.ReportEndDate = null;
                    this._HealthCommitteeWithThreeSpecialist.DecisionDate = null;
                    this._HealthCommitteeWithThreeSpecialist.RestReportDecision = null;
                }
            }
#endregion HCTSNewForm_ReasonForExamination_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region HCTSNewForm_PreScript
    base.PreScript();
            
            //this.SetEpisodeRelations();

            //if(this._HealthCommitteeWithThreeSpecialist.ReportDate == null)
            //    this._HealthCommitteeWithThreeSpecialist.ReportDate = Common.RecTime();

            this.Adres.ReadOnly = false;

            if (this._HealthCommitteeWithThreeSpecialist.ReturnDescriptions.Count > 0)
            {
                this.ReturnDescriptionsGrid.Visible = true;
                this.ttlabelReturnDescription.Visible = true;
            }

            if (_HealthCommitteeWithThreeSpecialist.CurrentStateDefID == HealthCommitteeWithThreeSpecialist.States.New)
            {
                this.ttobjectlistboxDepartment.SelectedObjectID = this._HealthCommitteeWithThreeSpecialist.MasterResource.ObjectID;
                if (this._HealthCommitteeWithThreeSpecialist.Specialists.Count == 0)
                {
                    HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid theGrid = new HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid(this._HealthCommitteeWithThreeSpecialist.ObjectContext);
                    theGrid.Specialist1 = Common.CurrentResource;
                    this._HealthCommitteeWithThreeSpecialist.Specialists.Add(theGrid);
                }
                
                //1. Uzman Doktor AuthorizedUser olarak ekleniyor
                AuthorizedUser pAUser = new AuthorizedUser(this._HealthCommitteeWithThreeSpecialist.ObjectContext);
                pAUser.Action = this._HealthCommitteeWithThreeSpecialist;
                pAUser.User = Common.CurrentResource;

                this._HealthCommitteeWithThreeSpecialist.AuthorizedUsers.Add(pAUser);

                if (this._HealthCommitteeWithThreeSpecialist.HospitalsUnits.Count == 0)
                    BaseHealthCommittee.AddRequesterHospitalsUnitsForBaseHealthCommittee(_HealthCommitteeWithThreeSpecialist);
                
                if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason != null && this._HealthCommitteeWithThreeSpecialist.ExaminationReason.SpecialistCount.HasValue)
                {
                    if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.SpecialistCount.Value == HCTSpecialistCountEnum.OneSpecialist)
                        this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval);
                    else if (this._HealthCommitteeWithThreeSpecialist.ExaminationReason.SpecialistCount.Value == HCTSpecialistCountEnum.ThreeSpecialist)
                        this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
                }
                else
                    this.DropStateButton(HealthCommitteeWithThreeSpecialist.States.Report);
            }


            ////Picture ContextMenu
            //ContextMenu pCMenu = new ContextMenu();

            //MenuItem m1 = new MenuItem("Resim Ekle/Değiştir");
            //m1.Click += new EventHandler(this.AddPictureClick);
            //pCMenu.MenuItems.Add(m1);

            //MenuItem m2 = new MenuItem("Sil");
            //m2.Click += new EventHandler(this.DeletePicture);
            //pCMenu.MenuItems.Add(m2);

            //GroupBox pBox = (GroupBox)this.ttgroupbox2;
            //pBox.ContextMenu = pCMenu;
            ////Picture Setting
            //GroupBox pBox2 = (GroupBox)this.ttgroupbox2;

            //PictureBox pic2 = new PictureBox();
            //pic2.Name = "PICTURE";
            ////pic2.Dock = DockStyle.Fill;
            //pic2.BackgroundImage = (Image)this._HealthCommitteeWithThreeSpecialist.Picture;
            //pic2.BackgroundImageLayout = ImageLayout.Zoom;

            //pBox2.Controls.Add(pic2);

            //if (pic2.BackgroundImage != null)
            //{
            //    this.ttlabel15.Visible = false;
            //    this.ttlabel16.Visible = false;
            //}

            //işte o
            bool bFound = false;
            foreach (TTUserRole role in TTUser.CurrentUser.Roles)
            {
                if (role.Name == "Yedek Subay Tabip")
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
                throw new Exception(SystemMessage.GetMessage(1141));
            
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
       
            
#endregion HCTSNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region HCTSNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (_HealthCommitteeWithThreeSpecialist.CurrentStateDefID == HealthCommitteeWithThreeSpecialist.States.New)
            {
                DialogResult result = DialogResult.Yes;

                
                if (result == DialogResult.No)
                    throw new TTException(SystemMessage.GetMessage(1140));
            }
#endregion HCTSNewForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCTSNewForm_PostScript
    if(transDef != null && transDef.ToStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval))
            {
                if (!this._HealthCommitteeWithThreeSpecialist.ReportNo.Value.HasValue)
                    this._HealthCommitteeWithThreeSpecialist.ReportNo.GetNextValue(Common.RecTime().Year);
                
                if(!this._HealthCommitteeWithThreeSpecialist.ReportDate.HasValue)
                    this._HealthCommitteeWithThreeSpecialist.ReportDate = Common.RecTime();
            }
#endregion HCTSNewForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCTSNewForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (this._HealthCommitteeWithThreeSpecialist.Specialists.Count <= 0)
                throw new Exception(SystemMessage.GetMessage(1142));

            string error = string.Empty;
            if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist1 == null)
                error += "İlgili Uzmanlar 1. Uzman Tabip bilgisini girmediniz.";
            
            if(transDef != null && transDef.ToStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval))
            {
                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2 == null)
                {
                    if (string.IsNullOrEmpty(error) == false)
                        error += "\r\n";
                    error += "İlgili Uzmanlar 2. Uzman Tabip bilgisini girmediniz.";
                }
                
                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3 == null)
                {
                    if (string.IsNullOrEmpty(error) == false)
                        error += "\r\n";
                    error += "İlgili Uzmanlar 3. Uzman Tabip bilgisini girmediniz.";
                }

                if (string.IsNullOrEmpty(error) == false)
                    throw new Exception(error);

                string warning = string.Empty;
                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist1.ObjectID.Equals(this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2.ObjectID))
                    warning += "1. Uzman Tabip ile 2. Uzman Tabip bilgisini aynı seçtiniz.";

                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist1.ObjectID.Equals(this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3.ObjectID))
                {
                    if (string.IsNullOrEmpty(error) == false)
                        warning += "\r\n";
                    warning += "1. Uzman Tabip ile 3. Uzman Tabip bilgisini aynı seçtiniz.";
                }

                if (this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist2.ObjectID.Equals(this._HealthCommitteeWithThreeSpecialist.Specialists[0].Specialist3.ObjectID))
                {
                    if (string.IsNullOrEmpty(error) == false)
                        warning += "\r\n";
                    warning += "2. Uzman Tabip ile 3. Uzman Tabip bilgisini aynı seçtiniz.";
                }

                if (string.IsNullOrEmpty(warning) == false)
                {
                    warning += "\r\n\r\nLütfen farklı uzman tabip bilgisi seçiniz.";
                    
                    if (TTObjectClasses.SystemParameter.GetParameterValue("HealthCommitteeWThreeSpecUnique", "") != "TRUE")
                    {
                        if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Üç Uzman Tabip İmzalı Rapor", "Aynı uzman tabip bilgisini birden çok kez seçtiniz. Bu rapor üç farklı uzman tabip tarafından onaylanmalıdır. İşleme devam etmek istediğinize emin misiniz?") != "E")
                            throw new Exception(warning);
                    }
                    else
                        throw new Exception(warning);
                }
            }
#endregion HCTSNewForm_ClientSidePostScript

        }

#region HCTSNewForm_Methods
        private void SetEpisodeRelations()
        {
            //MilitaryClassDefinitions militaryClass = this._HealthCommitteeWithThreeSpecialist.Episode.MyMilitaryClass();
            //if (militaryClass != null)
            //    this.MilitaryClass.SelectedObjectID = militaryClass.ObjectID;

            //RankDefinitions rank = this._HealthCommitteeWithThreeSpecialist.Episode.MyRank();
            //if (rank != null)
            //    this.Rank.SelectedObjectID = rank.ObjectID;

            //MilitaryUnit theUnit = this._HealthCommitteeWithThreeSpecialist.Episode.MyMilitaryUnit();
            //if (theUnit != null)
            //    this.MilitaryUnit.SelectedObjectID = theUnit.ObjectID;

            //this.EmploymentRecordID.Text = this._HealthCommitteeWithThreeSpecialist.Episode.MyEmploymentRecordID();
            //this.Adres.Text = this._HealthCommitteeWithThreeSpecialist.SubEpisode.PatientAdmission.HomeAddress;
        }

        private void DeletePicture(object sender, EventArgs e)
        {
            //GroupBox pGBox2 = (GroupBox)this.ttgroupbox2;

            //if (pGBox2.Controls.ContainsKey("PICTURE"))
            //    pGBox2.Controls.RemoveByKey("PICTURE");

            //this._HealthCommitteeWithThreeSpecialist.Picture = null;

            //this.ttlabel16.Visible = true;
            //this.ttlabel15.Visible = true;
            var a = 1;
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null && (transDef.ToStateDefID == HealthCommitteeWithThreeSpecialist.States.SecondSpecialistApproval || transDef.ToStateDefID == HealthCommitteeWithThreeSpecialist.States.Report))
            {
                string sBirthID = TTObjectClasses.SystemParameter.GetParameterValue("UNITOFBIRTH_OBJECTID", "");
                Guid birthID = new Guid(sBirthID);
                if (this._HealthCommitteeWithThreeSpecialist.MasterResource.ObjectID == birthID)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", this._HealthCommitteeWithThreeSpecialist.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", objectID);
                    int copy = 1;
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCWThreeSpecialistReportForBirth), true, copy, parameters);
                }
                else
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                    objectID.Add("VALUE", this._HealthCommitteeWithThreeSpecialist.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", objectID);
                    int copy = 1;
                    
                    if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType.HasValue)
                    {
                        if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType == HCThreeSpecialistReportTypeEnum.Material)
                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCThreeSpecialistReport_Material), true, copy, parameters);
                        else if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType == HCThreeSpecialistReportTypeEnum.Rest)
                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCThreeSpecialistReport_Rest), true, copy, parameters);
                        else if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType == HCThreeSpecialistReportTypeEnum.SituationInform)
                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCThreeSpecialistReport_Inform), true, copy, parameters);
                        else if(this._HealthCommitteeWithThreeSpecialist.ExaminationReason.ReportType == HCThreeSpecialistReportTypeEnum.SituationInformOneDoctor)
                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HCThreeSpecialistReport_InformOD), true, copy, parameters);
                    }
                    else
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HealthCommitteeWithThreeSpecialistReport), true, copy, parameters);
                }
            }
        }
        
#endregion HCTSNewForm_Methods

#region HCTSNewForm_ClientSideMethods
        private void AddPictureClick(object sender, EventArgs e)
        {
            //using (OpenFileDialog pDlg = new OpenFileDialog())
            //{
            //    DialogResult res = pDlg.ShowDialog(this);
            //    if (res == DialogResult.OK)
            //    {
            //        ////PictureBox pBox = new PictureBox();
            //        //pBox.Name = "PICTURE";
            //        ////pBox.Dock = DockStyle.Fill;
            //        //pBox.BackgroundImage = null;
            //        //pBox.BackgroundImageLayout = ImageLayout.Zoom;
            //        //pBox.BackgroundImage = Image.FromFile(pDlg.FileName);

            //        //this._HealthCommitteeWithThreeSpecialist.Picture = null;
            //        //this._HealthCommitteeWithThreeSpecialist.Picture = pBox.BackgroundImage;
            //        //this._HealthCommitteeWithThreeSpecialist.Episode.Patient.Photo = pBox.BackgroundImage;
            //        //GroupBox pGBox2 = (GroupBox)this.ttgroupbox2;

            //        //if (!pGBox2.Controls.ContainsKey("PICTURE"))
            //        //    pGBox2.Controls.Add(pBox);
            //        //else
            //        //{
            //        //    pGBox2.Controls.RemoveByKey("PICTURE");
            //        //    pGBox2.Controls.Add(pBox);
            //        //}

            //        this.ttlabel16.Visible = false;
            //        this.ttlabel15.Visible = false;
            //    }
            //}
            var a = 1;
        }
        
#endregion HCTSNewForm_ClientSideMethods
    }
}