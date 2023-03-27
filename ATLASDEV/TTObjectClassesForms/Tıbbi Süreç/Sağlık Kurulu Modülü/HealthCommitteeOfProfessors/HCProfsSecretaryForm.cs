
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
    public partial class HCProfsSecretaryForm : EpisodeActionForm
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
#region HCProfsSecretaryForm_PreScript
    base.PreScript();
            
            this.SetEpisodeRelations();
            if(this._HealthCommitteeOfProfessors.MemberClinics.Count == 0)
            {
                IList<HCPMemberClinicsDefinition> defs = (IList<HCPMemberClinicsDefinition>)HCPMemberClinicsDefinition.GetAllMemberClinics(this._HealthCommitteeOfProfessors.ObjectContext);
                foreach(HCPMemberClinicsDefinition pDef in defs)
                {
                    this._HealthCommitteeOfProfessors.MemberClinics.Add(pDef);
                }
            }
            
            this.Adres.ReadOnly = false;
#endregion HCProfsSecretaryForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCProfsSecretaryForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null && transDef.FromStateDefID.Equals(HealthCommitteeOfProfessors.States.WaitingForSignature) && transDef.ToStateDefID.Equals(HealthCommitteeOfProfessors.States.CommitteeExamination))
                this.ShowResourceListForReturn();
#endregion HCProfsSecretaryForm_ClientSidePostScript

        }

#region HCProfsSecretaryForm_Methods
        private void SetEpisodeRelations()
        {
            //MilitaryClassDefinitions militaryClass= this._HealthCommitteeOfProfessors.Episode.MyMilitaryClass();
            //if (militaryClass!=null)
            //    this.MilitaryClass.SelectedObjectID=militaryClass.ObjectID;
            
            //RankDefinitions rank= this._HealthCommitteeOfProfessors.Episode.MyRank();
            //if (rank!=null)
            //    this.Rank.SelectedObjectID=rank.ObjectID;
            
            //MilitaryUnit militaryUnit = this._HealthCommitteeOfProfessors.Episode.MyMilitaryUnit();
            //if (militaryUnit != null)
            //    this.MilitaryUnit.SelectedObjectID = militaryUnit.ObjectID;
            
            //RelationshipDefinition relationship=this._HealthCommitteeOfProfessors.Episode.MyRelationship();
            //if (relationship!=null)
            //    this.Relationship.SelectedObjectID=relationship.ObjectID;
            
            //string headOfFamilyName = this._HealthCommitteeOfProfessors.Episode.MyHeadOfFamilyName();
            //if (headOfFamilyName!=null)
            //    this.HeadOfFamilyName.Text=headOfFamilyName;
            
            //MilitaryUnit pChair = this._HealthCommitteeOfProfessors.Episode.MySenderChair();
            //if(pChair != null)
            //    this.SenderChair.SelectedObjectID = pChair.ObjectID;
            
            //this.EmploymentRecordID.Text = this._HealthCommitteeOfProfessors.Episode.MyEmploymentRecordID();
            //this.Adres.Text = this._HealthCommitteeOfProfessors.Episode.MyAddress();
        }
        
#endregion HCProfsSecretaryForm_Methods

#region HCProfsSecretaryForm_ClientSideMethods
        private void ShowResourceListForReturn()
        {
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this._HealthCommitteeOfProfessors);
            MultiSelectForm theFrm = new MultiSelectForm();
            foreach( EpisodeAction eaction in arrList)
            {
                HealthCommitteeExamination exam = eaction as HealthCommitteeExamination;
                if(exam != null && exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
                    theFrm.AddMSItem("İşlem no :"+exam.ID.Value.ToString()+", Bölüm :"+exam.MasterResource.Name,exam.ObjectID.ToString());
            }
            
            string sKey = theFrm.GetMSItem(this,"İade edilen muayeneyi seçiniz.");
            if(!string.IsNullOrEmpty(sKey))
            {
                HealthCommitteeExamination theExam = (HealthCommitteeExamination)this._HealthCommitteeOfProfessors.ObjectContext.GetObject(new Guid(sKey),"HealthCommitteeExamination");

                ITTObject pObject = (ITTObject)theExam;
                pObject.UndoLastTransition();
            }
        }
        
#endregion HCProfsSecretaryForm_ClientSideMethods
    }
}