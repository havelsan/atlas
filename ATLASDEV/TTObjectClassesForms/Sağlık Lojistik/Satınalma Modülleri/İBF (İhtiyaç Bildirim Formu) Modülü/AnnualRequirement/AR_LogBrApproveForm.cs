
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
    /// Birlik/Loj.Şb.İnceleme Onay
    /// </summary>
    public partial class AR_LogBrApproveForm : AR_BaseForm
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
#region AR_LogBrApproveForm_cmdApproveAll_Click
   foreach(AnnualRequirementDetail ard in _AnnualRequirement.AnnualRequirementDetails)
            {
                if(ard.CurrentStateDefID == AnnualRequirementDetail.States.New)
                    ard.LB_ApproveAmount = ard.ACC_ApproveAmount;
            }
#endregion AR_LogBrApproveForm_cmdApproveAll_Click
        }

        protected override void PreScript()
        {
#region AR_LogBrApproveForm_PreScript
    base.PreScript();
            
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if(Sites.SiteSihhiIkmal == siteIDGuid)
                this.DropStateButton(AnnualRequirement.States.AdministrativeChief);
            else
                this.DropStateButton(AnnualRequirement.States.HeadDoctorApproval);
#endregion AR_LogBrApproveForm_PreScript

            }
                }
}