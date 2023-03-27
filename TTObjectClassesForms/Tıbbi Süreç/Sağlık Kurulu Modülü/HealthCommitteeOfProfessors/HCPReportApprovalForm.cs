
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
    /// Profesörler Sağlık Kurulu
    /// </summary>
    public partial class HCPReportApproval : TTForm
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
#region HCPReportApproval_PreScript
    base.PreScript();
            this.SetEpisodeRelations();
#endregion HCPReportApproval_PreScript

            }
            
#region HCPReportApproval_Methods
        private void SetEpisodeRelations()
        {
            //MilitaryClassDefinitions militaryClass= this._HealthCommitteeOfProfessors.Episode.MyMilitaryClass();
            //if (militaryClass!=null)
            //{
            //    this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
            //}            
            
            //RankDefinitions rank= this._HealthCommitteeOfProfessors.Episode.MyRank();
            //if (rank!=null)
            //{
            //    this.Rank.SelectedObjectID=rank.ObjectID;
            //}
            
            //MilitaryUnit militaryUnit = this._HealthCommitteeOfProfessors.Episode.MyMilitaryUnit();
            //if (militaryUnit != null)
            //{
            //    this.MilitaryUnit.SelectedObjectID = militaryUnit.ObjectID;
            //}
            
            //RelationshipDefinition relationship=this._HealthCommitteeOfProfessors.Episode.MyRelationship();
            //if (relationship!=null)
            //{
            //    this.Relationship.SelectedObjectID=relationship.ObjectID;
            //}
            
            //string headOfFamilyName = this._HealthCommitteeOfProfessors.Episode.MyHeadOfFamilyName();
            //if (headOfFamilyName!=null)
            //{
            //    this.HeadOfFamilyName.Text=headOfFamilyName;
            //}
            
            //MilitaryUnit pChair = this._HealthCommitteeOfProfessors.Episode.MySenderChair();
            //if(pChair != null)
            //{
            //    this.SenderChair.SelectedObjectID = pChair.ObjectID;
            //}
            
            //this.EmploymentRecordID.Text = this._HealthCommitteeOfProfessors.Episode.MyEmploymentRecordID();
            
            this.Adres.Text = SubEpisode.MyAddress(this._HealthCommitteeOfProfessors.SubEpisode);
        }
        
#endregion HCPReportApproval_Methods
    }
}