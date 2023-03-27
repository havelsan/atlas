
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class BaseExtendExpDateForm : BaseChattelDocumentForm
    {
    /// <summary>
    /// Miad Güncelleme İşlemi
    /// </summary>
        protected TTObjectClasses.ExtendExpirationDate _ExtendExpirationDate
        {
            get { return (TTObjectClasses.ExtendExpirationDate)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid ExtendExpirationDateDetails;
        protected ITTListBoxColumn MaterialExtendExpirationDateDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn RestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTDateTimePickerColumn CurrentExpirationDate;
        protected ITTDateTimePickerColumn NewDateForExpirationExtendExpirationDateDetail;
        protected ITTListBoxColumn StockLevelType;
        override protected void InitializeControls()
        {
            labelStore = (ITTLabel)AddControl(new Guid("62aad65a-da64-4949-8394-049b0a3475eb"));
            Store = (ITTObjectListBox)AddControl(new Guid("809a4812-b4b2-45cd-bfc0-e91542e0210c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6d0b3efd-5e20-4e06-bab6-e9c394368f3d"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("abbc68d3-2a87-438c-bcf8-8f85308cbb9a"));
            ExtendExpirationDateDetails = (ITTGrid)AddControl(new Guid("357c5c02-f663-49a1-b385-7acb6177b9a9"));
            MaterialExtendExpirationDateDetail = (ITTListBoxColumn)AddControl(new Guid("25c2a341-3f82-4425-9c87-5e44caa63762"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("4628b191-7f26-4d94-bb65-906a69b4896d"));
            RestAmount = (ITTTextBoxColumn)AddControl(new Guid("72c08576-1c34-4010-b2f7-ad210acd54fd"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("06c67a23-a278-4bd8-8451-e32af059122a"));
            CurrentExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("21e92c05-0c50-4613-8121-cd1c2c257373"));
            NewDateForExpirationExtendExpirationDateDetail = (ITTDateTimePickerColumn)AddControl(new Guid("db94e502-0895-498e-b559-a9ef0c65b766"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("02346fe1-3ea3-474b-b64e-b1afa63ca6d5"));
            base.InitializeControls();
        }

        public BaseExtendExpDateForm() : base("EXTENDEXPIRATIONDATE", "BaseExtendExpDateForm")
        {
        }

        protected BaseExtendExpDateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}