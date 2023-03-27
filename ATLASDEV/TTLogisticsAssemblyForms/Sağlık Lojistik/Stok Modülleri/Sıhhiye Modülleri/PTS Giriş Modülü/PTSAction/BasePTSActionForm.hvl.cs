
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
    public partial class BasePTSActionForm : StockActionBaseForm
    {
    /// <summary>
    /// PTS Giriş İşlemi
    /// </summary>
        protected TTObjectClasses.PTSAction _PTSAction
        {
            get { return (TTObjectClasses.PTSAction)_ttObject; }
        }

        protected ITTLabel labelPTSID;
        protected ITTTextBox PTSID;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTGrid StockActionInDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialStockActionDetailIn;
        protected ITTDateTimePickerColumn ExpirationDateStockActionDetailIn;
        protected ITTTextBoxColumn LotNoStockActionDetailIn;
        protected ITTTextBoxColumn UnitPriceStockActionDetailIn;
        protected ITTTextBoxColumn VatRateStockActionDetailIn;
        protected ITTTextBoxColumn AmountStockActionDetailIn;
        protected ITTEnumComboBoxColumn StatusStockActionDetailIn;
        protected ITTListBoxColumn StockLevelTypeStockActionDetailIn;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        override protected void InitializeControls()
        {
            labelPTSID = (ITTLabel)AddControl(new Guid("bce59c54-5fb3-4c6e-ba33-7e90406ad86f"));
            PTSID = (ITTTextBox)AddControl(new Guid("80dcf42a-4e2f-4573-b63c-c67e56c27839"));
            StockActionID = (ITTTextBox)AddControl(new Guid("07d94486-04f9-4426-a20f-39b763f89983"));
            labelStore = (ITTLabel)AddControl(new Guid("16650b18-e166-40fe-bbff-7738ba1054c3"));
            Store = (ITTObjectListBox)AddControl(new Guid("9b85e83b-0c6a-495c-8f82-58a9d172c8f8"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("e1997f76-e40c-4aeb-bb19-31e10e0f8b38"));
            Detail = (ITTButtonColumn)AddControl(new Guid("c81769a4-38d8-4b57-b127-b03c85e4363e"));
            MaterialStockActionDetailIn = (ITTListBoxColumn)AddControl(new Guid("fa108bd7-32f6-4e2c-ad5a-4f977e9e8059"));
            ExpirationDateStockActionDetailIn = (ITTDateTimePickerColumn)AddControl(new Guid("8cd8c601-5857-4a55-95d0-08fe5b20b75d"));
            LotNoStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("17408e7c-ef78-4ad8-8aee-c19690fd054e"));
            UnitPriceStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("911c6bfb-b756-4d9b-89b9-1cdbe5f45656"));
            VatRateStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("d8316010-9a7c-49e7-8687-6431971369b9"));
            AmountStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("1b44bbc2-5d47-4b91-a6b9-1d651ab9d06f"));
            StatusStockActionDetailIn = (ITTEnumComboBoxColumn)AddControl(new Guid("ada35408-38b0-451d-bd8b-594ca2ac8d8e"));
            StockLevelTypeStockActionDetailIn = (ITTListBoxColumn)AddControl(new Guid("617bfbfd-ee97-4ce0-9f71-a79cb95004a2"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5ac92970-04e9-4ad4-a996-df7792ec4586"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4949bfdf-e2db-4758-af4f-8a6336274e9c"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("b92a4c00-d82d-4028-8ab3-fa034b8d0e9e"));
            base.InitializeControls();
        }

        public BasePTSActionForm() : base("PTSACTION", "BasePTSActionForm")
        {
        }

        protected BasePTSActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}