
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
    /// Lojistik Daire İnceleme Onay
    /// </summary>
    public partial class AR_LDApprovalForm : AR_BaseForm
    {
        override protected void BindControlEvents()
        {
            cmdApproveAll.Click += new TTControlEventDelegate(cmdApproveAll_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdApproveAll.Click -= new TTControlEventDelegate(cmdApproveAll_Click);
            base.UnBindControlEvents();
        }

        private void cmdApproveAll_Click()
        {
#region AR_LDApprovalForm_cmdApproveAll_Click
   foreach(AnnualRequirementDetail ard in _AnnualRequirement.AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID == AnnualRequirementDetail.States.New)
                    ard.LD_ApproveAmount = ard.LB_ApproveAmount;
            }
#endregion AR_LDApprovalForm_cmdApproveAll_Click
        }

#region AR_LDApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            List<TTObject> ttObjects = _AnnualRequirement.FillDetailsForRemote();
            if (_AnnualRequirement.OwnerSite == null)
                return;

            //TTMessage message = AnnualRequirement.RemoteMethods.SaveIBF((Guid)_AnnualRequirement.OwnerSite, ttObjects);
        }
        
#endregion AR_LDApprovalForm_Methods
    }
}