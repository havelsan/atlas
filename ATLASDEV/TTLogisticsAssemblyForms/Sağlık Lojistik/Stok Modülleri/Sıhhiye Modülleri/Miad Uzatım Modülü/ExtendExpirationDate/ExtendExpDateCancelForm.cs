
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
    public partial class ExtendExpDateCancelForm : BaseExtendExpDateForm
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

            #region ambarlar arasý tranfer iptali tekrar yollama
            //Ilac Miad Guncelleme isleminde Iptal asamasi kaldirildigi icin asagidaki blok kaldirildi.

            //if (this._ExtendExpirationDate.CurrentStateDefID == ExtendExpirationDate.States.Cancelled)
            //{
            //    foreach (DocumentRecordLog log in this._ExtendExpirationDate.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
            //    {
            //        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
            //        {
            //            if (log.ReceiptNumber != null)
            //            {
            //                _ExtendExpirationDate.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
            //            }
            //        }
            //    }

            //    foreach (DocumentRecordLog log in this._ExtendExpirationDate.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
            //    {
            //        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
            //        {
            //            if (log.ReceiptNumber != null)
            //            {
            //                _ExtendExpirationDate.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
            //            }
            //        }
            //    }
            //}
            #endregion ambarlar arasý tranfer iptali tekrar yollama


        }





    }
}