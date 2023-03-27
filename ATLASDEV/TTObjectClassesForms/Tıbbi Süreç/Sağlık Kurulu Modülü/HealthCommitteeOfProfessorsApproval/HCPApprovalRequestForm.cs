
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
    /// Profesörler Sağlık Kurulu Onay
    /// </summary>
    public partial class HCPApprovalRequestForm : TTForm
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
#region HCPApprovalRequestForm_PreScript
    base.PreScript();
            this.SetEpisodeRelations();
            
            if(this._HealthCommitteeOfProfessorsApproval.ReturnDescriptions.Count > 0)
            {
                this.ReturnDescriptions.Visible = true;
                this.ttlabel7.Visible = true;
            }
#endregion HCPApprovalRequestForm_PreScript

            }
            
#region HCPApprovalRequestForm_Methods
        private void SetEpisodeRelations()
        {

            //MilitaryClassDefinitions militaryClass= this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyMilitaryClass();
            //if (militaryClass!=null)
            //{
            //    this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
            //}            
            
            //RankDefinitions rank= this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyRank();
            //if (rank!=null)
            //{
            //    this.Rank.SelectedObjectID=rank.ObjectID;
            //}
            
            //MilitaryUnit militaryUnit = this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyMilitaryUnit();
            //if (militaryUnit != null)
            //{
            //    this.MilitaryUnit.SelectedObjectID = militaryUnit.ObjectID;
            //}
            
            //RelationshipDefinition relationship=this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyRelationship();
            //if (relationship!=null)
            //{
            //    this.Relationship.SelectedObjectID=relationship.ObjectID;
            //}
            
            //string headOfFamilyName = this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyHeadOfFamilyName();
            //if (headOfFamilyName!=null)
            //{
            //    this.HeadOfFamilyName.Text=headOfFamilyName;
            //}
            
            //MilitaryUnit pChair = this._HealthCommitteeOfProfessorsApproval.Episode.MySenderChair();
            //if(pChair != null)
            //{
            //    this.SenderChair.SelectedObjectID = pChair.ObjectID;
            //}
            
            //this.EmploymentRecordID.Text = this._HealthCommitteeOfProfessorsApproval.Episode.MyEmploymentRecordID();
            
            this.Adres.Text = SubEpisode.MyAddress(this._HealthCommitteeOfProfessorsApproval.SubEpisode);
        }
        
#endregion HCPApprovalRequestForm_Methods
    }
}