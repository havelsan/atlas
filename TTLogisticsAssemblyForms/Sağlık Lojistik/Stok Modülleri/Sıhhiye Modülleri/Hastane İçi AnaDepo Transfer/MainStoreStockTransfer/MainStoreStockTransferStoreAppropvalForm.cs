
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
    public partial class MainStoreStockTransferStoreAppropvalForm : BaseMainStoreStockTransferForm
    {
        #region MainStoreStockTransferStoreApprovalForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == MainStoreStockTransfer.States.Completed)
                {


                    if (_MainStoreStockTransfer.OutMkysControl == null || _MainStoreStockTransfer.OutMkysControl == false)
                    {
                        _MainStoreStockTransfer.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);

                        if (_MainStoreStockTransfer.InMkysControl == null || _MainStoreStockTransfer.InMkysControl == false)
                        {
                            _MainStoreStockTransfer.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                    else if (_MainStoreStockTransfer.InMkysControl == null || _MainStoreStockTransfer.InMkysControl == false)
                    {
                        _MainStoreStockTransfer.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }
                }
            }
        }

        #endregion MainStoreStockTransferStoreApprovalForm_Methods
    }
}