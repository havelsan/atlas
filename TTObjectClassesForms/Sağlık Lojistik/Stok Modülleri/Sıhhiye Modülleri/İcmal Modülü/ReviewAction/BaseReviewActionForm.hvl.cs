
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
    public partial class BaseReviewActionForm : StockActionBaseForm
    {
    /// <summary>
    /// İcmal 
    /// </summary>
        protected TTObjectClasses.ReviewAction _ReviewAction
        {
            get { return (TTObjectClasses.ReviewAction)_ttObject; }
        }

        protected ITTButton TTGetDrugButton;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ReviewActionTabPanel;
        protected ITTGrid ReviewActionDetails;
        protected ITTListBoxColumn MaterialRewiewActionDetail;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountRewiewActionDetail;
        protected ITTTextBox Description;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDescription;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTLabel labelMKYS_CikisStokHareketTuru;
        protected ITTEnumComboBox MKYS_CikisStokHareketTuru;
        protected ITTLabel labelMKYS_CikisIslemTuru;
        protected ITTEnumComboBox MKYS_CikisIslemTuru;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTButton TTTeslimEdenButon;
        protected ITTButton TTTeslimAlanButon;
        override protected void InitializeControls()
        {
            TTGetDrugButton = (ITTButton)AddControl(new Guid("2b5e96ab-1e25-476c-a9ed-bbe3627ca72a"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("00cddabf-a49e-4ca2-96e0-2b1840b80a46"));
            ReviewActionTabPanel = (ITTTabPage)AddControl(new Guid("fb34a1d7-cb34-4a73-ad93-4bd7b9aa92f2"));
            ReviewActionDetails = (ITTGrid)AddControl(new Guid("416dbab1-6c52-49e0-8866-97488988722d"));
            MaterialRewiewActionDetail = (ITTListBoxColumn)AddControl(new Guid("42cb5188-6f28-462b-8270-6feaf988e7ef"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("054cac66-7976-4731-ac2f-e3e68043b2bf"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("473ab82e-7245-4574-9d07-f199de8175e4"));
            AmountRewiewActionDetail = (ITTTextBoxColumn)AddControl(new Guid("b8116b08-d5e8-4d9a-9166-b807b3a32906"));
            Description = (ITTTextBox)AddControl(new Guid("990546b7-65d4-4d10-95a5-028cc89752d8"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("6e8e4032-ec7c-4400-a954-0886bd2c28c4"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("b8b9b46d-efae-4c32-9a83-d2ffd7ca97cd"));
            StockActionID = (ITTTextBox)AddControl(new Guid("26739e9a-a465-43a8-a7ac-773b6c476a85"));
            labelStore = (ITTLabel)AddControl(new Guid("4708a33c-793b-42a3-b0b4-020ee85a5727"));
            Store = (ITTObjectListBox)AddControl(new Guid("ff4f729b-9d7f-49c0-9e51-a0d3a5d69826"));
            labelDescription = (ITTLabel)AddControl(new Guid("dcdd29d2-2fea-46f0-9cf1-dc9b73804803"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("27a8e5e0-1673-4855-91f5-1824fd8f4bc7"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("94e8345c-29d5-4b14-bc13-4932bd1f95b1"));
            labelMKYS_CikisStokHareketTuru = (ITTLabel)AddControl(new Guid("b89c2895-fb92-4f37-99cd-4f72dc6e3161"));
            MKYS_CikisStokHareketTuru = (ITTEnumComboBox)AddControl(new Guid("241fe208-3bb8-4155-9ec1-a5dd96d4e906"));
            labelMKYS_CikisIslemTuru = (ITTLabel)AddControl(new Guid("16cc6033-cd45-4066-b756-29038330e285"));
            MKYS_CikisIslemTuru = (ITTEnumComboBox)AddControl(new Guid("77396afa-c9a8-4024-bdf4-fc01e21648c5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6eafff3d-1bbf-45ec-998c-ffae2f19b88d"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c78637e6-a81d-48a3-a029-77f872fd1d6d"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("36b07cda-5260-45a3-b6f5-185790657719"));
            labelEndDate = (ITTLabel)AddControl(new Guid("1c106aee-2cce-473c-8022-6d8b23e1ceb8"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("b5a26a0f-029d-4098-be6d-622f799e2340"));
            labelStartDate = (ITTLabel)AddControl(new Guid("715dd782-34e9-4936-bace-09a607c1c890"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("90defaa8-58cf-4d95-87f5-d3796ebeebdf"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("c16204c6-01fc-4708-a9d0-efe8814dceb8"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("b72df188-05ce-442d-8ddd-34a2a57e81b5"));
            base.InitializeControls();
        }

        public BaseReviewActionForm() : base("REVIEWACTION", "BaseReviewActionForm")
        {
        }

        protected BaseReviewActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}