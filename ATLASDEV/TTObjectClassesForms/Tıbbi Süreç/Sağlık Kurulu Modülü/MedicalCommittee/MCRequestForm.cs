
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
    /// Tıbbi Kurullar
    /// </summary>
    public partial class MCRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            MedicalCommitteType.SelectedObjectChanged += new TTControlEventDelegate(MedicalCommitteType_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MedicalCommitteType.SelectedObjectChanged -= new TTControlEventDelegate(MedicalCommitteType_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void MedicalCommitteType_SelectedObjectChanged()
        {
#region MCRequestForm_MedicalCommitteType_SelectedObjectChanged
   IList<MemberOfMedicalCommitteeDefinition> pDefs = null;
            pDefs = MemberOfMedicalCommitteeDefinition.GetMemberOfMCDefinitionByType(this._MedicalCommittee.ObjectContext, this._MedicalCommittee.MedicalCommitteType.ObjectID.ToString());
            if(pDefs.Count != 0)
            {
                this._MedicalCommittee.Department = pDefs[0].MedicalCommitteeType.Resource;
                this.Department.SelectedObjectID = pDefs[0].MedicalCommitteeType.Resource.ObjectID;
                foreach(MedicalCommiteeMember pMember in pDefs[0].Members)
                {
                    MedicalCommitteeMemberOfMedicalCommitteeGrid newGrid = null;
                    newGrid = new MedicalCommitteeMemberOfMedicalCommitteeGrid(this._MedicalCommittee.ObjectContext);
                    
                    newGrid.Doctor = pMember.Doctor;
                    newGrid.Speciality = pMember.Speciality;
                    newGrid.NotAttend = false;
                    
                    this._MedicalCommittee.MemberOfMedicalCommittee.Add(newGrid);
                }
            }
#endregion MCRequestForm_MedicalCommitteType_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region MCRequestForm_PreScript
    base.PreScript();
            
            if(this._MedicalCommittee.ProtocolNo.Value != null)
                this.TempBox.Visible = false;
            
            this._MedicalCommittee.MeetingTime = DateTime.Now;
#endregion MCRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MCRequestForm_PostScript
    base.PostScript(transDef);
            
            if(transDef != null)
            {
                if(this._MedicalCommittee.AuthorizedUsers.Count == 0)
                {
                    foreach(MedicalCommitteeMemberOfMedicalCommitteeGrid pGrid in this._MedicalCommittee.MemberOfMedicalCommittee)
                    {
                        AuthorizedUser theUser = new AuthorizedUser(this._MedicalCommittee.ObjectContext);
                        theUser.User = pGrid.Doctor;
                        theUser.Action = this._MedicalCommittee;
                    }
                }
            }
#endregion MCRequestForm_PostScript

            }
                }
}