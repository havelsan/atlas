
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
    public partial class HCPApprovalForm : TTForm
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
#region HCPApprovalForm_PreScript
    base.PreScript();
            this.SetEpisodeRelations();
#endregion HCPApprovalForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCPApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null && transDef.FromStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.Approval) && transDef.ToStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.HCPSecretary))
                this.ReturnDescriptionInput();
#endregion HCPApprovalForm_ClientSidePostScript

        }

#region HCPApprovalForm_Methods
        private void SetEpisodeRelations()
        {
            //MilitaryClassDefinitions militaryClass= this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyMilitaryClass();
            //if (militaryClass!=null)
            //    this.MilitaryClass.SelectedObjectID = militaryClass.ObjectID;
            
            //RankDefinitions rank= this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyRank();
            //if (rank!=null)
            //    this.Rank.SelectedObjectID = rank.ObjectID;

            
            //RelationshipDefinition relationship=this._HealthCommitteeOfProfessorsApproval.HCPApprovalAction.Episode.MyRelationship();
            //if (relationship!=null)
            //    this.Relationship.SelectedObjectID = relationship.ObjectID;
            

            
            this.Adres.Text = SubEpisode.MyAddress(this._HealthCommitteeOfProfessorsApproval.SubEpisode);
        }
        
#endregion HCPApprovalForm_Methods

#region HCPApprovalForm_ClientSideMethods
        private void ReturnDescriptionInput()
        {
            //TODO:ShowEdit!
            //StringEntryForm pReturnForm = new StringEntryForm();
            //DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
            //if(res == DialogResult.OK)
            //{
            //    HealthCommittee_ReturnDescriptionsGrid theGrid = null;
            //    theGrid = new HealthCommittee_ReturnDescriptionsGrid(this._HealthCommitteeOfProfessorsApproval.ObjectContext);
            //    theGrid.Description = pReturnForm.StringContent;
            //    theGrid.EntryDate = DateTime.Now;
            //    theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;

            //    this._HealthCommitteeOfProfessorsApproval.ReturnDescriptions.Add(theGrid);
            //}
            var a = 1;
        }
        
#endregion HCPApprovalForm_ClientSideMethods
    }
}