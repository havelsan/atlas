
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
    public partial class ReviewActionCompletedForm : BaseReviewActionForm
    {
        override protected void BindControlEvents()
        {
            SendToMKYS.Click += new TTControlEventDelegate(SendToMKYS_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SendToMKYS.Click -= new TTControlEventDelegate(SendToMKYS_Click);
            base.UnBindControlEvents();
        }

        private void SendToMKYS_Click()
        {
            #region ReviewActionCompletedForm_SendToMKYS_Click
            string message = this._ReviewAction.SendMkysOutputDocumentForReviewAction(Common.CurrentResource.MkysPassword);

            #endregion ReviewActionCompletedForm_SendToMKYS_Click
        }

    }
}