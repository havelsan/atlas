
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
    /// Depodan Sarf İşlemi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresSubStoreConsumptionForm : StockActionBaseForm
    {
    /// <summary>
    /// Depodan Sarf İşlemi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.ResSubStoreConsumption _ResSubStoreConsumption
        {
            get { return (TTObjectClasses.ResSubStoreConsumption)_ttObject; }
        }

        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid ResSubStoreConsumptionDetails;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTListBoxColumn MaterialResSubStoreConsumptionDetail;
        protected ITTListBoxColumn PresDistributionType;
        protected ITTTextBoxColumn AmountResSubStoreConsumptionDetail;
        protected ITTTextBoxColumn PresInheld;
        protected ITTListBoxColumn StockLevelTypeResSubStoreConsumptionDetail;
        override protected void InitializeControls()
        {
            labelActionDate = (ITTLabel)AddControl(new Guid("2dcd3123-4548-46e4-a137-8e516635c6e1"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7771e73e-bc2a-4eab-9b43-e6b8908dfdc3"));
            labelStore = (ITTLabel)AddControl(new Guid("48b27b82-727a-403e-8dda-a84d69f6be08"));
            Store = (ITTObjectListBox)AddControl(new Guid("d1af4323-7e90-42a2-aa63-f208ec34ccee"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("d7753e4c-da92-400d-af0a-95104b5ff446"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("4cf2b0d8-bb8c-4c04-a9b1-4b19b8a3705c"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("864ab5b7-74cd-46cc-9682-b270f31fc48e"));
            StockActionID = (ITTTextBox)AddControl(new Guid("01335922-8949-4b02-886b-f635daf436d5"));
            Description = (ITTTextBox)AddControl(new Guid("e694222c-8fad-4939-8a8f-dcd5f354e768"));
            labelDescription = (ITTLabel)AddControl(new Guid("92cad9fc-cb8c-48af-9763-127454828e5b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5a513a12-8f14-4467-9751-bc67ee067187"));
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("151ca071-c05f-4e91-856a-dbd7c38909bd"));
            ResSubStoreConsumptionDetails = (ITTGrid)AddControl(new Guid("2fdb2559-1de9-42f2-8bd1-a60bdc0b4e9a"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("40d81bcc-9f3a-4619-ba6a-e96a4056e396"));
            MaterialResSubStoreConsumptionDetail = (ITTListBoxColumn)AddControl(new Guid("95090c8c-1d00-46e2-bd9a-00c972f4098a"));
            PresDistributionType = (ITTListBoxColumn)AddControl(new Guid("b6656ce1-08ad-430b-b36d-d289048d0226"));
            AmountResSubStoreConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("6532fb92-57bc-4d70-a4b2-f313ee1f134d"));
            PresInheld = (ITTTextBoxColumn)AddControl(new Guid("469e70ba-db84-46dc-9474-ac2f99f7cc4f"));
            StockLevelTypeResSubStoreConsumptionDetail = (ITTListBoxColumn)AddControl(new Guid("54cb1393-15d2-4cc9-b5cc-9880982d5b6b"));
            base.InitializeControls();
        }

        public BasePresSubStoreConsumptionForm() : base("RESSUBSTORECONSUMPTION", "BasePresSubStoreConsumptionForm")
        {
        }

        protected BasePresSubStoreConsumptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}