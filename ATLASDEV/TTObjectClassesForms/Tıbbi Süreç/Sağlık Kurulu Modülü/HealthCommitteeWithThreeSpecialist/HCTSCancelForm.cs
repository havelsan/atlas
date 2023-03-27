
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
    public partial class HCTSCancelForm : EpisodeActionForm
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
#region HCTSCancelForm_PreScript
    base.PreScript();
            //this.SetEpisodeRelations();

            ////Picture Setting
            //GroupBox pBox2 = (GroupBox)this.ttgroupbox2;
            //PictureBox pic = new PictureBox();
            ////pic.Dock = DockStyle.Fill;
            //pic.BackgroundImage = (Image)this._HealthCommitteeWithThreeSpecialist.Picture;
            //pic.BackgroundImageLayout = ImageLayout.Zoom;
            //pBox2.Controls.Add(pic);
            var a = 1;

#endregion HCTSCancelForm_PreScript

            }
            
#region HCTSCancelForm_Methods
        private void SetEpisodeRelations()
        {
            //MilitaryClassDefinitions militaryClass = this._HealthCommitteeWithThreeSpecialist.Episode.MyMilitaryClass();
            //if (militaryClass != null)
            //{
            //    this.MilitaryClass.SelectedObjectID = militaryClass.ObjectID;
            //}

            //RankDefinitions rank = this._HealthCommitteeWithThreeSpecialist.Episode.MyRank();
            //if (rank != null)
            //{
            //    this.Rank.SelectedObjectID = rank.ObjectID;
            //}

            //this.Adres.Text = this._HealthCommitteeWithThreeSpecialist.SubEpisode.PatientAdmission.PA_Address.HomeAddress;

            //MilitaryUnit theUnit = this._HealthCommitteeWithThreeSpecialist.Episode.MyMilitaryUnit();
            //if (theUnit != null)
            //{
            //    this.MilitaryUnit.SelectedObjectID = theUnit.ObjectID;
            //}

            //this.EmploymentRecordID.Text = this._HealthCommitteeWithThreeSpecialist.Episode.MyEmploymentRecordID();
        }
        
#endregion HCTSCancelForm_Methods
    }
}