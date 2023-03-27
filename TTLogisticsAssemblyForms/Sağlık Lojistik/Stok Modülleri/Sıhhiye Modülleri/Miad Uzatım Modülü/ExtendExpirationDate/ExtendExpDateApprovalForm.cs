
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
    public partial class ExtendExpDateApprovalForm : BaseExtendExpDateForm
    {
        #region ExtendExpDateApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == ExtendExpirationDate.States.Completed)
                {
                 

                    if (_ExtendExpirationDate.OutMkysControl == null || _ExtendExpirationDate.OutMkysControl == false)
                    {
                        _ExtendExpirationDate.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);

                        if (_ExtendExpirationDate.InMkysControl == null || _ExtendExpirationDate.InMkysControl == false)
                        {
                            _ExtendExpirationDate.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                    else if (_ExtendExpirationDate.InMkysControl == null || _ExtendExpirationDate.InMkysControl == false)
                    {
                        _ExtendExpirationDate.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }
                }
            }
        }

        #endregion ExtendExpDateApprovalForm_Methods
    }
}