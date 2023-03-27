
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
    public partial class IBFDemand_AccountancyApproveForm : IBFDemand_BaseForm
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
#region IBFDemand_AccountancyApproveForm_cmdApproveAll_Click
   foreach(IBFBaseDemandDetail ibd in _IBFDemand.IBFBaseDemandDetails)
            {
                if(ibd.CurrentStateDefID == IBFBaseDemandDetail.States.New)
                    ibd.Amount = ibd.ClinicApprovedAmount;
            }
#endregion IBFDemand_AccountancyApproveForm_cmdApproveAll_Click
        }
    }
}