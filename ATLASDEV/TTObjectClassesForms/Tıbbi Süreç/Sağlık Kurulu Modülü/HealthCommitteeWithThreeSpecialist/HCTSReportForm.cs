
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
    public partial class HCTSReportForm : EpisodeActionForm
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
#region HCTSReportForm_PreScript
    base.PreScript();
            //this.SetEpisodeRelations();
            
            if (_HealthCommitteeWithThreeSpecialist.CurrentStateDefID == HealthCommitteeWithThreeSpecialist.States.Report)
            {
                this.Text = "Sağlık Kurulu Üç Uzman Tabip İmzalı Rapor Başhekim Onayı";
                this.ReportNo.Visible = false;
                this.ttlabel4.Visible = false;
                _HealthCommitteeWithThreeSpecialist.AdditionalDecision = "ONAYLANDI";
                
                /* Fork edilmiş muayene işlemi olmadığı için aşağıdaki kısım kapatıldı 
                string additionToDecision = "";
                ArrayList arrList = _HealthCommitteeWithThreeSpecialist.GetLinkedEpisodeActions();
                
                // Eğer master actionı HCWTS olan tamamlanmamış  bir işlem varsa, sürecin ilerletilmemesi sağlanır.
                _HealthCommitteeWithThreeSpecialist.throwExceptionForUnfinishedHCExaminations();

                foreach (EpisodeAction episodeAction in arrList)
                {
                    if (!episodeAction.IsCancelled)
                    {
                        BaseHealthCommitteeExamination baseHealthCommitteeEx = (BaseHealthCommitteeExamination)episodeAction;
                        if (baseHealthCommitteeEx.OfferOfDecision != null)
                        {
                            if (baseHealthCommitteeEx.OfferOfDecision.Trim() != "")
                                additionToDecision = additionToDecision + " / " + baseHealthCommitteeEx.OfferOfDecision.Trim();
                        }
                    }
                }
                if (additionToDecision.Trim() != "")
                    _HealthCommitteeWithThreeSpecialist.AdditionalDecision = additionToDecision;
                else
                    _HealthCommitteeWithThreeSpecialist.AdditionalDecision = "ONAYLANDI";
                 */
            }
            

            // Tamamlanmış raporun doktorlar tarafından tekrar alınamaması için
            // SuperUser veya HealthCommitteeWithThreeSpecialistReportRoleID rolü varsa raporu alabilir
            if (!(Common.CurrentUser.IsSuperUser || Common.CurrentUser.HasRole(TTObjectClasses.Common.HealthCommitteeWithThreeSpecialistReportRoleID) || HealthCommitteeWithThreeSpecialist.IsCurrentUserOneOfSpecialists(this._HealthCommitteeWithThreeSpecialist) == 1))
                this.DropCurrentStateReport(typeof(TTReportClasses.I_HealthCommitteeWithThreeSpecialistReport));
            
            ////Picture Setting
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
        
#endregion HCTSReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCTSReportForm_PostScript
    base.PostScript(transDef);

            if (transDef != null && transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.Report) && transDef.ToStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.Completed))
            {
                if (this._HealthCommitteeWithThreeSpecialist.ReportDate == null)
                    throw new TTException(SystemMessage.GetMessage(1139));
            }
#endregion HCTSReportForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCTSReportForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null && transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.Report) && transDef.ToStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.New))
            {
                this._HealthCommitteeWithThreeSpecialist.ReportDate = null;
                this.ReturnDescription();
            }
#endregion HCTSReportForm_ClientSidePostScript

        }

#region HCTSReportForm_Methods
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
           // this.Adres.Text = this._HealthCommitteeWithThreeSpecialist.SubEpisode.PatientAdmission.HomeAddress;
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.FromStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.Report) && transDef.ToStateDefID.Equals(HealthCommitteeWithThreeSpecialist.States.Completed))
                {
                    TTVisual.InfoBox.Alert("Rapor No: " + this._HealthCommitteeWithThreeSpecialist.ReportNo.Value.ToString(), MessageIconEnum.InformationMessage);
                   
                }
            }
        }
        
#endregion HCTSReportForm_Methods

#region HCTSReportForm_ClientSideMethods
        private void ReturnDescription()
        {

            //TODO:ShowEdit!
            //StringEntryForm pReturnForm = new StringEntryForm();
            //DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
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
        
#endregion HCTSReportForm_ClientSideMethods
    }
}