
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
    public partial class HCProfsRequestApprovalForm : EpisodeActionForm
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
#region HCProfsRequestApprovalForm_PreScript
    base.PreScript();
            this.SetEpisodeRelations();
            
            if(this._HealthCommitteeOfProfessors.CurrentStateDefID.Equals(HealthCommitteeOfProfessors.States.RequestApproval))
            {
                this.ApprovalStatus.Visible = true;
                
                List<ResSection> depList = new List<ResSection>();
                ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this._HealthCommitteeOfProfessors);
                foreach( EpisodeAction eaction in arrList)
                {
                    if(eaction is HealthCommitteeOfProfessorsApproval)
                    {
                        HealthCommitteeOfProfessorsApproval approval = (HealthCommitteeOfProfessorsApproval)eaction;
                        if(approval.CurrentStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.Completed))
                            depList.Add(approval.MasterResource);
                    }
                }
                
                if(depList.Count != 0)
                {
                    foreach(BaseHealthCommittee_HospitalsUnitsGrid theGrid in this._HealthCommitteeOfProfessors.HospitalsUnits)
                    {
                        if(depList.Contains(theGrid.Unit))
                        {
                            foreach(ITTGridRow theRow in this.HospitalsUnits.Rows)
                            {
                                if(theRow.Cells["Units"].Value != null && theRow.Cells["Units"].Value.Equals(theGrid.Unit.ObjectID))
                                    theRow.Cells["ApprovalStatus"].Value = true;
                            }
                        }
                    }
                }
            }
            
            this.Adres.ReadOnly = false;
#endregion HCProfsRequestApprovalForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCProfsRequestApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null && transDef.FromStateDefID.Equals(HealthCommitteeOfProfessors.States.DeanApproval) && transDef.ToStateDefID.Equals(HealthCommitteeOfProfessors.States.Request))
                this.ReturnDescriptionInput();
#endregion HCProfsRequestApprovalForm_ClientSidePostScript

        }

#region HCProfsRequestApprovalForm_Methods
        private void SetEpisodeRelations()
        {
            //MilitaryClassDefinitions militaryClass= this._HealthCommitteeOfProfessors.Episode.MyMilitaryClass();
            //if (militaryClass!=null)
            //    this.MilitaryClass.SelectedObjectID = militaryClass.ObjectID;
            
            //RankDefinitions rank= this._HealthCommitteeOfProfessors.Episode.MyRank();
            //if (rank!=null)
            //    this.Rank.SelectedObjectID = rank.ObjectID;
            
            //MilitaryUnit militaryUnit = this._HealthCommitteeOfProfessors.Episode.MyMilitaryUnit();
            //if (militaryUnit != null)
            //    this.MilitaryUnit.SelectedObjectID = militaryUnit.ObjectID;
            
            //RelationshipDefinition relationship=this._HealthCommitteeOfProfessors.Episode.MyRelationship();
            //if (relationship!=null)
            //    this.Relationship.SelectedObjectID = relationship.ObjectID;
            
            //string headOfFamilyName = this._HealthCommitteeOfProfessors.Episode.MyHeadOfFamilyName();
            //if (headOfFamilyName!=null)
            //    this.HeadOfFamilyName.Text = headOfFamilyName;
            
            //MilitaryUnit pChair = this._HealthCommitteeOfProfessors.Episode.MySenderChair();
            //if(pChair != null)
            //    this.SenderChair.SelectedObjectID = pChair.ObjectID;
            
            //this.EmploymentRecordID.Text = this._HealthCommitteeOfProfessors.Episode.MyEmploymentRecordID();
            ////this.Adres.Text = this._HealthCommitteeOfProfessors.Episode.MyAddress();
        }
        
#endregion HCProfsRequestApprovalForm_Methods

#region HCProfsRequestApprovalForm_ClientSideMethods
        private void ReturnDescriptionInput()
        {
            //TODO:ShowEdit!
            //StringEntryForm pReturnForm = new StringEntryForm();
            //DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
            //if(res == DialogResult.OK)
            //{
            //    HealthCommittee_ReturnDescriptionsGrid theGrid = null;
            //    theGrid = new HealthCommittee_ReturnDescriptionsGrid(this._HealthCommitteeOfProfessors.ObjectContext);
            //    theGrid.Description = pReturnForm.StringContent;
            //    theGrid.EntryDate = DateTime.Now;
            //    theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;
            //    this._HealthCommitteeOfProfessors.ReturnDescriptions.Add(theGrid);
            //}
            var a = 1;
        }
        
#endregion HCProfsRequestApprovalForm_ClientSideMethods
    }
}