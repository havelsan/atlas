
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
    /// Saymanlık Onayı
    /// </summary>
    public partial class AccountancyApprovalForm : StockActionBaseForm
    {
    /// <summary>
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseExamination _PurchaseExamination
        {
            get { return (TTObjectClasses.PurchaseExamination)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialsTabPage;
        protected ITTGrid StockActionInDetails;
        protected ITTListBoxColumn PurchaseItemDef;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTextBoxColumn ProductNumber;
        protected ITTTabPage AccountancyResponsibleTabPage;
        protected ITTGrid ExaminationCommision;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTEnumComboBoxColumn Title;
        protected ITTTextBoxColumn ClassRank;
        protected ITTListBoxColumn NameSurname;
        protected ITTEnumComboBoxColumn CommisionDuty;
        protected ITTCheckBoxColumn PrimeBackup;
        protected ITTTabPage PENoticeTextTab;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox StockActionID;
        protected ITTTextBox InspectionPlace;
        protected ITTTextBox Description;
        protected ITTTextBox DecisionNO;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker TemporaryDeliveryDate;
        protected ITTDateTimePicker DecisionDate;
        protected ITTObjectListBox Store;
        protected ITTLabel labelContractDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelDecisionNO;
        protected ITTDateTimePicker ContractDate;
        protected ITTLabel ttlabel21;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelActionName;
        protected ITTLabel labelStockActionID;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker InspectionMemorandumCollacationDate;
        protected ITTObjectListBox Supplier;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("97e026c2-c363-471b-8e74-93a02192aea3"));
            MaterialsTabPage = (ITTTabPage)AddControl(new Guid("afa597f5-e548-4a30-8644-e0f008e84fac"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("e35e9320-5577-4e00-98c8-a3b2f6b5f58b"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("635b79a7-9292-4e0a-ad62-6402e1c2a613"));
            Material = (ITTListBoxColumn)AddControl(new Guid("fffd2fe6-f15f-49e4-a53a-ce3e01a5c012"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("cbd96747-7205-4a09-bb35-8bfd286b5ff6"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("9d766259-ff9e-414f-bca3-8f28150c2811"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("a3332fa4-1c4b-40a5-a994-f892441f967f"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("06e7e4ef-29c7-4c19-bc8a-8defdf4c3eb9"));
            ProductNumber = (ITTTextBoxColumn)AddControl(new Guid("8f277f5c-59f0-4bda-8c23-493cd618e917"));
            AccountancyResponsibleTabPage = (ITTTabPage)AddControl(new Guid("d41c7ca6-4af7-43e7-bad1-fe9ea7fe6e4b"));
            ExaminationCommision = (ITTGrid)AddControl(new Guid("5e1d2f9f-068c-47c7-a953-487a0066b0cd"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("71846e49-11ed-456d-bb23-bd245153f935"));
            Title = (ITTEnumComboBoxColumn)AddControl(new Guid("df76c45e-0437-40be-949a-9f09cdb782c7"));
            ClassRank = (ITTTextBoxColumn)AddControl(new Guid("fbe67e76-b1f7-42f0-8090-7d942784ff23"));
            NameSurname = (ITTListBoxColumn)AddControl(new Guid("07d72857-5dc4-441d-b22c-74a4db1cfd44"));
            CommisionDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("228b159e-a239-4101-8a2b-d9f8e2fe5a13"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("0463e22f-a3bc-4d57-b2d0-ca4fb2b7de37"));
            PENoticeTextTab = (ITTTabPage)AddControl(new Guid("1603050f-c799-49dd-babb-569dd4d643a5"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("6bf1dc3f-1cf9-4382-b49f-f5b367531f12"));
            StockActionID = (ITTTextBox)AddControl(new Guid("976d1f8f-57c1-4e80-b520-9ce6707d6934"));
            InspectionPlace = (ITTTextBox)AddControl(new Guid("79a7daae-25bb-46de-b51a-727534448cbb"));
            Description = (ITTTextBox)AddControl(new Guid("e3e110b8-83b8-4fdd-b847-457d9956ce95"));
            DecisionNO = (ITTTextBox)AddControl(new Guid("b8d9db29-3331-4cb8-be3d-6f83fd0694bc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4ea639a8-3c8f-4e21-8544-77c2538d06e2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e9d8c0c6-0da8-44bc-b1b5-c5fd3d388994"));
            TemporaryDeliveryDate = (ITTDateTimePicker)AddControl(new Guid("0d19efff-0d3d-4396-91b3-c2421653cae0"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("956061e9-a3b2-46bd-97a4-4ae6922aa648"));
            Store = (ITTObjectListBox)AddControl(new Guid("980cf92b-e1a5-48be-b541-e7c06f83233b"));
            labelContractDate = (ITTLabel)AddControl(new Guid("f65eb734-145b-4075-b407-6d48fabfd307"));
            labelStore = (ITTLabel)AddControl(new Guid("3d3079ec-c888-48ab-aafd-d937a6569247"));
            labelDecisionNO = (ITTLabel)AddControl(new Guid("81d58365-25d8-49ef-89ae-eaf2a5add1b9"));
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("e57b9230-57ce-4661-b47f-1f0ea1d7e765"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("13f7be8d-a89a-49ee-987b-ed7cb50b2f93"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("1651221e-f950-4698-ae7d-71750fb72422"));
            labelActionName = (ITTLabel)AddControl(new Guid("5c89eeba-10a7-4dda-aa81-a4fbbb84cfd0"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("860dbeec-4679-490a-81f3-544bb850b0b0"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9a528d84-e371-4299-95a4-a90a8f699cac"));
            labelDescription = (ITTLabel)AddControl(new Guid("3278c3a0-f353-4f6f-b1b5-318f758144fe"));
            InspectionMemorandumCollacationDate = (ITTDateTimePicker)AddControl(new Guid("04b93ffe-6829-4804-8cbf-f9b6a155d05c"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("4823abe5-8d11-45e1-985e-0dcc75d2dc67"));
            base.InitializeControls();
        }

        public AccountancyApprovalForm() : base("PURCHASEEXAMINATION", "AccountancyApprovalForm")
        {
        }

        protected AccountancyApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}