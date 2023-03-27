
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
    /// Üst Kademe XXXXXX Onayı
    /// </summary>
    public partial class UpperLevelCommanderApprovalForm : TTForm
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
#region UpperLevelCommanderApprovalForm_PreScript
    base.PreScript();
            if(_ReferToUpperLevel.ReferType != ReferTypeEnum.Calibration && _ReferToUpperLevel.ReferType != ReferTypeEnum.TeamRequest )
            {
                this.DropStateButton(ReferToUpperLevel.States.TechnicalDirectorApproval);
            }
            else
            {
                this.DropStateButton(ReferToUpperLevel.States.TemporaryAdmissionRegistry);
            }
#endregion UpperLevelCommanderApprovalForm_PreScript

            }
                }
}