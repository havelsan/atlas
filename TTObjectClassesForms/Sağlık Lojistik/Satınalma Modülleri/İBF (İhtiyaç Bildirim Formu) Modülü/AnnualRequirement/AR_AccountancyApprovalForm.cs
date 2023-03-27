
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
    /// Saymanlık Onay
    /// </summary>
    public partial class AR_AccountancyApprovalForm : AR_BaseForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            cmdApproveAll.Click += new TTControlEventDelegate(cmdApproveAll_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            cmdApproveAll.Click -= new TTControlEventDelegate(cmdApproveAll_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region AR_AccountancyApprovalForm_ttbutton1_Click
   //            List<AnnualRequirementDetailInList> inlists = new List<AnnualRequirementDetailInList>();
//            List<AnnualRequirementDetailOutOfList> outlists = new List<AnnualRequirementDetailOutOfList>();
//            
//            foreach(AnnualRequirementDetailInList ardin in _AnnualRequirement.AnnualRequirementDetailInLists)
//            {
//                inlists.Add(ardin);
//            }
//            foreach(AnnualRequirementDetailOutOfList ardout in _AnnualRequirement.AnnualRequirementDetailOutOfLists)
//            {
//                outlists.Add(ardout);
//            }
//                        
//            AnnualRequirement.RemoteMethods.SendIBFtoLB(Sites.SiteLocalHost ,_AnnualRequirement,inlists,outlists);
#endregion AR_AccountancyApprovalForm_ttbutton1_Click
        }

        private void cmdApproveAll_Click()
        {
#region AR_AccountancyApprovalForm_cmdApproveAll_Click
   foreach(AnnualRequirementDetail ard in _AnnualRequirement.AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID == AnnualRequirementDetail.States.New)
                    ard.ACC_ApproveAmount = ard.RequestAmount;
            }
#endregion AR_AccountancyApprovalForm_cmdApproveAll_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AR_AccountancyApprovalForm_PostScript
    base.PostScript(transDef);
#endregion AR_AccountancyApprovalForm_PostScript

            }
                }
}