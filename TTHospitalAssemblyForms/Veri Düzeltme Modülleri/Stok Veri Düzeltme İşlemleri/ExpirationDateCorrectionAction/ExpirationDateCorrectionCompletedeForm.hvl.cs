
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
    /// <summary>
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
    public partial class ExpirationDateCorrectionCompletedeForm : TTForm
    {
    /// <summary>
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
        protected TTObjectClasses.ExpirationDateCorrectionAction _ExpirationDateCorrectionAction
        {
            get { return (TTObjectClasses.ExpirationDateCorrectionAction)_ttObject; }
        }

        protected ITTLabel labelNewExpirationDate;
        protected ITTDateTimePicker NewExpirationDate;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTGrid FirstInStockActions;
        protected ITTTextBoxColumn StockActionID;
        protected ITTTextBoxColumn Description;
        protected ITTDateTimePickerColumn ExpDate;
        protected ITTCheckBoxColumn SelectedStockActionFirstInStockAction;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelOldExpirationDate;
        protected ITTDateTimePicker OldExpirationDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelNewExpirationDate = (ITTLabel)AddControl(new Guid("319f198d-ecc6-4357-b6dc-ef6e933e8ab3"));
            NewExpirationDate = (ITTDateTimePicker)AddControl(new Guid("dfb14a24-7305-4c8f-9060-2f707fc1ee6b"));
            labelMaterial = (ITTLabel)AddControl(new Guid("8ee63a65-5551-47e6-b462-ab75eb2bad80"));
            Material = (ITTObjectListBox)AddControl(new Guid("b91fc4d1-0d8e-4001-8377-38e95e0895c3"));
            FirstInStockActions = (ITTGrid)AddControl(new Guid("f229f729-a954-45c2-b6f4-771c3a30c12f"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("ab7ceacf-7ef4-4053-8a74-f637cbed8c24"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("792ee783-886d-4eac-8ceb-e4814ce836ca"));
            ExpDate = (ITTDateTimePickerColumn)AddControl(new Guid("09c98d4e-cc0f-4a58-98de-c455d9e4c1be"));
            SelectedStockActionFirstInStockAction = (ITTCheckBoxColumn)AddControl(new Guid("6b661c54-c1bf-4fa8-bb82-2717d82a0509"));
            labelID = (ITTLabel)AddControl(new Guid("0d58176a-8255-4500-9b7f-f3526caaca80"));
            ID = (ITTTextBox)AddControl(new Guid("8759c042-6f85-4b0c-8ea0-e7c55fd0f6ea"));
            labelActionDate = (ITTLabel)AddControl(new Guid("733556a1-dc3f-47df-8bdb-9e1e2c119da0"));
            labelOldExpirationDate = (ITTLabel)AddControl(new Guid("c01d349e-1849-44f2-ad83-23a1cc8ebdc5"));
            OldExpirationDate = (ITTDateTimePicker)AddControl(new Guid("1847552d-76b8-4691-af6c-c584b9c3b230"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("125a0267-710e-4724-8d8d-3a6e74109a2b"));
            base.InitializeControls();
        }

        public ExpirationDateCorrectionCompletedeForm() : base("EXPIRATIONDATECORRECTIONACTION", "ExpirationDateCorrectionCompletedeForm")
        {
        }

        protected ExpirationDateCorrectionCompletedeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}