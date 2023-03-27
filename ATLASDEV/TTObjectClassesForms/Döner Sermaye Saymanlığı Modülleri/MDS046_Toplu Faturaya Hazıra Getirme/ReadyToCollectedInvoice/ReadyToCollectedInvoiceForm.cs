
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
    /// Toplu Faturaya Hazırlama
    /// </summary>
    public partial class ReadyToCollectedInvoiceForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MakeNewButton.Click += new TTControlEventDelegate(MakeNewButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MakeNewButton.Click -= new TTControlEventDelegate(MakeNewButton_Click);
            base.UnBindControlEvents();
        }

        private void MakeNewButton_Click()
        {
#region ReadyToCollectedInvoiceForm_MakeNewButton_Click
   if (this._ReadyToCollectedInvoice.CurrentStateDefID == ReadyToCollectedInvoice.States.New)
            {
                foreach (ReadyToCollectedInvoiceDetail detail in this._ReadyToCollectedInvoice.ReadyToCollectedInvoiceDetails)
                {
                    if(detail.CurrentStateDefID == ReadyToCollectedInvoiceDetail.States.Failed)
                        detail.CurrentStateDefID = ReadyToCollectedInvoiceDetail.States.New;
                }
            }
#endregion ReadyToCollectedInvoiceForm_MakeNewButton_Click
        }

        protected override void PreScript()
        {
#region ReadyToCollectedInvoiceForm_PreScript
    base.PreScript();
            
            if (_ReadyToCollectedInvoice.CurrentStateDefID == ReadyToCollectedInvoice.States.New)
            {
                this.MakeNewButton.ReadOnly = false;
                this.DropStateButton(ReadyToCollectedInvoice.States.Completed);
            }
            else
                this.MakeNewButton.ReadOnly = true;
#endregion ReadyToCollectedInvoiceForm_PreScript

            }
                }
}