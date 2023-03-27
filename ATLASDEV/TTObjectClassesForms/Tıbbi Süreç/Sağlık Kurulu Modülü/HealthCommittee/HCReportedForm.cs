
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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCReportedForm : EpisodeActionForm
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
#region HCReportedForm_PreScript
    base.PreScript();
            this.SetEpisodeRelations();
            //NE Reported state i kaldırıldı
            /*
            if (this._HealthCommittee.CurrentStateDefID.Value == HealthCommittee.States.Reported)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("HCDRIVERLICENSEREPORTEXISTS", "FALSE") == "FALSE")
                    this.DropCurrentStateReport(typeof(TTReportClasses.I_HCDriverLicenseReport));

                
                //TabPage p1 = (TabPage)tttabpageHC;
                //foreach(Control ctrl1 in p1.Controls)
                //{
                //    if(ctrl1.Name != "tttabcontrolDiagnosis")
                //        ctrl1.Enabled = false;
                //}
             

                TabPage p2 = (TabPage)tttabpagePI;
                foreach (Control ctrl2 in p2.Controls)
                {
                    ctrl2.Enabled = false;
                }

                TabPage p3 = (TabPage)tttabpageDecision;
                foreach (Control ctrl3 in p3.Controls)
                {
                    ctrl3.Enabled = false;
                }

                TabPage p4 = (TabPage)tttabpagePreDiagnosis;
                foreach (Control ctrl4 in p4.Controls)
                {
                    ctrl4.Enabled = false;
                }

                TabPage p5 = (TabPage)tttabpageEpisodeDiagnosis;
                foreach (Control ctrl5 in p5.Controls)
                {
                    ctrl5.Enabled = false;
                }
            }

            // Uçucu Sağlık Kurulu ile ilgili alanların görünür yapılması
            //if (this._HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType == HealthCommitteeTypeEnum.FlierCommittee)
            //{
            //    this.lblAircraftType.Visible = true;
            //    this.AircraftType.Visible = true;
            //    this.lblLastHealthCommitteeResult.Visible = true;
            //    this.LastHealthCommitteeResult.Visible = true;
            //    this.lblHCDutyType.Visible = true;
            //    this.HCDutyType.Visible = true;
            //}

            //Picture Setting
          */
#endregion HCReportedForm_PreScript

            }
            
#region HCReportedForm_Methods
        private void SetEpisodeRelations()
        {
            //            MilitaryClassDefinitions militaryClass= this._HealthCommittee.Episode.MyMilitaryClass();
            //            if (militaryClass!=null)
            //            {
            //                this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
            //            }

            //            RankDefinitions rank= this._HealthCommittee.Episode.MyRank();
            //            if (rank!=null)
            //            {
            //                this.Rank.SelectedObjectID=rank.ObjectID;
            //            }

            //            MilitaryOffice militaryOffice = this._HealthCommittee.Episode.MyMilitaryOffice();
            //            if (militaryOffice!=null)
            //            {
            //                this._HealthCommittee.LocalBranch = militaryOffice;
            //                this.MilitaryOffice.SelectedObjectID=militaryOffice.ObjectID;
            //            }

            //RelationshipDefinition relationship = this._HealthCommittee.Episode.MyRelationship();
            //if (relationship != null)
            //{
            //    this.Relationship.SelectedObjectID = relationship.ObjectID;
            //}

            //string headOfFamilyName = this._HealthCommittee.Episode.MyHeadOfFamilyName();
            //if (headOfFamilyName != null)
            //{
            //    this.HeadOfFamilyName.Text = headOfFamilyName;
            //}

            

            //this.EmploymentRecordID.Text = this._HealthCommittee.Episode.MyEmploymentRecordID();

            //            MilitaryUnit pMUnit = this._HealthCommittee.Episode.MyMilitaryUnit();
            //            if(pMUnit != null)
            //            {
            //                this.MilitaryUnit.SelectedObjectID = pMUnit.ObjectID;
            //            }

            //this.Adres.Text = this._HealthCommittee.Episode.MyAddress();

            this.DocumentNumber.Text = SubEpisode.MyDocumentNumber(this._HealthCommittee.SubEpisode);

            DateTime? pDocDate = SubEpisode.MyDocumentDate(this._HealthCommittee.SubEpisode);
            if (pDocDate != null)
                this.DocumentDate.ControlValue = pDocDate.Value;
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            //if (transDef != null && transDef.ToStateDefID == HealthCommittee.States.ApproveofChair)
            //    this._HealthCommittee.RunSendHealthCommittee();

            if (transDef != null && transDef.ToStateDefID == HealthCommittee.States.Completed)
            {
                // SGK hastaları için Sağlık Kurulu Rapor ücreti "Medulaya Gönderilmeyecek" durumuna alınır
                if (SubEpisode.IsSGKSubEpisode(_HealthCommittee.SubEpisode))
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    foreach (HealthCommitteeProcedure hcProc in this._HealthCommittee.HealthCommitteeProcedures)
                    {
                        foreach (AccountTransaction AccTrx in hcProc.AccountTransactions)
                        {
                            if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER && AccTrx.CurrentStateDefID == AccountTransaction.States.New)
                            {
                                AccountTransaction accountTrx = (AccountTransaction)objectContext.GetObject(AccTrx.ObjectID, typeof(AccountTransaction));
                                accountTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                            }
                        }
                    }
                    objectContext.Save();
                    objectContext.Dispose();
                }
            }
        }
        
#endregion HCReportedForm_Methods
    }
}