
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
    public partial class UnusedReceiptsDefForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            txtUnusedReceiptStartNo.TextChanged += new TTControlEventDelegate(txtUnusedReceiptStartNo_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            txtUnusedReceiptStartNo.TextChanged -= new TTControlEventDelegate(txtUnusedReceiptStartNo_TextChanged);
            base.UnBindControlEvents();
        }

        private void txtUnusedReceiptStartNo_TextChanged()
        {
        }

        protected override void PreScript()
        {
            base.PreScript();
            ResUser _resUser = Common.CurrentResource;
            List<Guid> cashOfficeIdList = CashOfficeComputerUserDefinition.GetByUserID(_UnusedReceiptNoDefinition.ObjectContext, _resUser.ObjectID).Where(x => x.IsActive == true && x.ComputerName == Common.GetCurrentUserComputerName()).Select(x => x.CashOffice.ObjectID).ToList();
            StringBuilder strBuilder = new StringBuilder();
            foreach (Guid cashOfficeGuid in cashOfficeIdList)
            {
                strBuilder.Append("'" + cashOfficeGuid + "',");
            }

            if (strBuilder.Length > 0)
            {
                strBuilder.Remove(strBuilder.Length - 1, 1);
                lstBoxReceiptCashOfficeListDef.ListFilterExpression = "CASHOFFICE IN(" + strBuilder.ToString() + ") AND ISACTIVE = 1";
            }
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            base.PostScript(transDef);
            int unusedReceiptStartNo;
            int unusedReceiptEndNo;
            try
            {
                unusedReceiptStartNo = Math.Abs(Convert.ToInt32(txtUnusedReceiptStartNo.Text));
                unusedReceiptEndNo = Math.Abs(Convert.ToInt32(txtUnusedReceiptEndNo.Text));
            }
            catch (Exception)
            {
                throw new TTUtils.TTException("Kullanýlmayacak baþlangýç ya da bitiþ numarasý sayý formatýnda deðil!. Lütfen tam sayý giriniz.");
            }

            if (unusedReceiptStartNo < this._UnusedReceiptNoDefinition.ReceiptCashOfficeDefinition.CurrentReceiptNumber)
            {
                throw new TTUtils.TTException("Kullanýlmayacak fatura baþlangýç numarasý sýradaki alýndý numarasýndan küçük olamaz.");
            }
            if (unusedReceiptEndNo > this._UnusedReceiptNoDefinition.ReceiptCashOfficeDefinition.ReceiptEndNumber)
            {
                throw new TTUtils.TTException("Kullanýlmayacak fatura bitiþ numarasý alýndý sýra no bitiþ numarasýndan büyük olamaz.");
            }
            if (unusedReceiptStartNo > unusedReceiptEndNo)
            {
                throw new TTUtils.TTException("Kullanýlmayacak fatura baþlangýç numarasý kullanýlmayacak bitiþ numarasýndan büyük olamaz.");
            }
            if (this._UnusedReceiptNoDefinition.ReceiptCashOfficeDefinition.CurrentReceiptNumber == this._UnusedReceiptNoDefinition.UnusedReceiptStartNo && this._UnusedReceiptNoDefinition.ReceiptCashOfficeDefinition.ReceiptEndNumber == this._UnusedReceiptNoDefinition.UnusedReceiptEndNo)
            {
                this._UnusedReceiptNoDefinition.ReceiptCashOfficeDefinition.IsActive = false;
            }
        }
    }
}