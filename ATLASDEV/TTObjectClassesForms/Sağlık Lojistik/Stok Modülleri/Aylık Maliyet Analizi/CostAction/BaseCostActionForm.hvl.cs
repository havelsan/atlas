
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
    public partial class BaseCostActionForm : StockActionBaseForm
    {
    /// <summary>
    /// Aylık Maliyet Analizi
    /// </summary>
        protected TTObjectClasses.CostAction _CostAction
        {
            get { return (TTObjectClasses.CostAction)_ttObject; }
        }

        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox Description;
        protected ITTLabel TTDatetime;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid CostActionMaterials;
        protected ITTListBoxColumn MaterialCostActionMaterial;
        protected ITTTextBoxColumn PreviousMothInheldCostActionMaterial;
        protected ITTTextBoxColumn PreviousMonthPriceCostActionMaterial;
        protected ITTTextBoxColumn TotalAmountCostActionMaterial;
        protected ITTTextBoxColumn TotalOutAmuntCostActionMaterial;
        protected ITTTextBoxColumn TotalPrice;
        protected ITTTextBoxColumn AvarageUnitePriceCostActionMaterial;
        protected ITTTextBoxColumn MaterialPriceCostActionMaterial;
        protected ITTTextBoxColumn ProfitAndLossCostActionMaterial;
        protected ITTTextBoxColumn DifAvarageUnitePriceCostActionMaterial;
        protected ITTTextBoxColumn TransferredAmount;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            labelTransactionDate = (ITTLabel)AddControl(new Guid("50445e86-e958-47c6-9877-e315c97c7245"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("fe436e48-40bc-4a4d-aae1-3598cf8a8594"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("8ffc8a37-8efa-4af2-a7b5-abd6b9af0ee6"));
            StockActionID = (ITTTextBox)AddControl(new Guid("f499f140-750c-470d-8271-ebcca816fa9d"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("96b0edc2-1564-4c5d-b6d2-f183ffcf084d"));
            Description = (ITTTextBox)AddControl(new Guid("6e20c1c1-085f-436d-b3a5-c6e66ee826c4"));
            TTDatetime = (ITTLabel)AddControl(new Guid("23bc5954-0315-4b11-ab6e-f29b99834b24"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("f66e1b5a-d9fa-49c0-85aa-a7c1630e07a1"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("95854b1e-bcc0-4e9d-bac2-0801491b2e06"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c4645bb2-b875-41de-8ab7-2e579587aa68"));
            CostActionMaterials = (ITTGrid)AddControl(new Guid("828a5a3f-f291-456d-add4-d9763f299717"));
            MaterialCostActionMaterial = (ITTListBoxColumn)AddControl(new Guid("c046a635-e381-4149-bf7e-d089506aab39"));
            PreviousMothInheldCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("64875951-59ba-4dda-b48c-197f3be86d1a"));
            PreviousMonthPriceCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("8a4c6104-b30c-4627-a0cf-fcab4d409fe1"));
            TotalAmountCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("7586377f-7808-459b-bacf-6ac65bd63638"));
            TotalOutAmuntCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("78a48f97-7554-4b18-8eda-336a56b30104"));
            TotalPrice = (ITTTextBoxColumn)AddControl(new Guid("55198d24-4c3f-4330-a04a-e01800d713ad"));
            AvarageUnitePriceCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("3feaa319-1efc-43fe-b9a9-569acc5fff22"));
            MaterialPriceCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("db13475c-62dc-4ada-ac02-a905c686d9e6"));
            ProfitAndLossCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("22dd837e-64b7-4b23-b187-583d2444633a"));
            DifAvarageUnitePriceCostActionMaterial = (ITTTextBoxColumn)AddControl(new Guid("5c0934aa-14f6-474a-abb6-5705d58fb5d1"));
            TransferredAmount = (ITTTextBoxColumn)AddControl(new Guid("4b7625ec-64f0-4fb6-8962-9ed8a22a2f91"));
            labelStore = (ITTLabel)AddControl(new Guid("0c792177-3c7b-421e-88ca-07164fbae78f"));
            Store = (ITTObjectListBox)AddControl(new Guid("c51f1dfc-df23-433f-bf6d-b5ee9c429da5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("da09bf9a-209e-4517-9446-f0d50d37d197"));
            base.InitializeControls();
        }

        public BaseCostActionForm() : base("COSTACTION", "BaseCostActionForm")
        {
        }

        protected BaseCostActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}