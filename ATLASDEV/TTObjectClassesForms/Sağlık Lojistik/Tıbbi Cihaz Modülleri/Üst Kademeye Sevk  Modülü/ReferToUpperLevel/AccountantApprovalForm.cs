
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
    /// Sayman Onay
    /// </summary>
    public partial class AccountantApprovalForm : RUL_BaseForm
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
#region AccountantApprovalForm_PreScript
    _ReferToUpperLevel.RequestNo = _ReferToUpperLevel.RequestNo.Replace("####", _ReferToUpperLevel.RequestNoSeq.Value.ToString());
            
            if(_ReferToUpperLevel.ReferType == ReferTypeEnum.TeamRequest)
            {
                this.DropStateButton(ReferToUpperLevel.States.TemporaryAdmission);
            }
            else
            {
                this.DropStateButton(ReferToUpperLevel.States.TeamRequest);
            }
#endregion AccountantApprovalForm_PreScript

            }
                }
}