
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
    /// Sağlık Kurulu Rapor Çıkış
    /// </summary>
    public partial class ReportOutputForm : EpisodeActionForm
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
#region ReportOutputForm_PreScript
    base.PreScript();
            this.SetEpisodeRelations();
#endregion ReportOutputForm_PreScript

            }
            
#region ReportOutputForm_Methods
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
        
#endregion ReportOutputForm_Methods
    }
}