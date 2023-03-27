
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
    /// Sipariş Onay
    /// </summary>
    public partial class PurchaseOrderApproveForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PurchaseOrderApproveForm_PostScript
    base.PostScript(transDef);
            
            if(_PurchaseOrder.TransDef == null)
                return;
            
            if(_PurchaseOrder.TransDef.ToStateDefID == PurchaseOrder.States.Cancelled)
            {
                string msg = _PurchaseOrder.CheckActiveExaminations();
                if(string.IsNullOrEmpty(msg) == false)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(53) + msg);
            }
#endregion PurchaseOrderApproveForm_PostScript

            }
                }
}