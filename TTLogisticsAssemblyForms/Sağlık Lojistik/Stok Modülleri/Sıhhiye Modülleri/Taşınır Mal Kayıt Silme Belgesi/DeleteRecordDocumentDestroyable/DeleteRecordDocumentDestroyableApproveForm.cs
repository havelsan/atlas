
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
    public partial class DeleteRecordDocumentDestroyableApproveForm : BaseDeleteRecordDocumentDestroyableForm
    {

        //BU SON STATE NEYSE ONA G�RE UYARLANMASI LAZIM!!!!!
        #region DeleteRecordDocumentDestroyableApproveForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == DeleteRecordDocumentDestroyable.States.Completed)
                {
                    _DeleteRecordDocumentDestroyable.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                }
            }

        }

        #endregion DeleteRecordDocumentDestroyableApproveForm_Methods



    }
}