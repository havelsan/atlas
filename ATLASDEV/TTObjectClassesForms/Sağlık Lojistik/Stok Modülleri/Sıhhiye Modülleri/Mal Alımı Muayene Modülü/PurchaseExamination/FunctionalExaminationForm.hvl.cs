
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
    /// Fonksiyon Muayenesi
    /// </summary>
    public partial class FunctionalExaminationForm : StockActionBaseForm
    {
    /// <summary>
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseExamination _PurchaseExamination
        {
            get { return (TTObjectClasses.PurchaseExamination)_ttObject; }
        }

        protected ITTTextBox DecisionNo;
        protected ITTTextBox InspectionPlace;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelFileNO;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker DecisionDate;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker InspectionMemorandumCollacationDate;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker ContractDate;
        protected ITTLabel labelActionName;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelContractDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialsTabPage;
        protected ITTGrid StockActionInDetails;
        protected ITTButtonColumn CheckList;
        protected ITTListBoxColumn PurchaseItemDef;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTEnumComboBoxColumn PurchaseExaminationDetStatus;
        protected ITTTextBoxColumn ProductNumber;
        protected ITTTabPage ExaminationTabPage;
        protected ITTGrid ExaminationCommision;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTEnumComboBoxColumn Title;
        protected ITTTextBoxColumn ClassRank;
        protected ITTListBoxColumn NameSurname;
        protected ITTEnumComboBoxColumn CommisionDuty;
        protected ITTCheckBoxColumn PrimeBackup;
        protected ITTTabPage FunctionExaminationTabPage;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabPage GeneralExaminationTabPage;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox FileNO;
        protected ITTEnumComboBox InspectionStatus;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Supplier;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            DecisionNo = (ITTTextBox)AddControl(new Guid("ec72125b-4da2-4327-852a-009d671bf4c2"));
            InspectionPlace = (ITTTextBox)AddControl(new Guid("81f694f8-9c82-4a04-ad97-1e35019a99e2"));
            StockActionID = (ITTTextBox)AddControl(new Guid("775e1906-fee4-4e96-988a-4b4fc418d9ee"));
            Description = (ITTTextBox)AddControl(new Guid("04cde3e8-52c4-4b6b-bb63-6a933922d21e"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("70e74d29-345e-46d4-9a16-14addec82a2d"));
            labelFileNO = (ITTLabel)AddControl(new Guid("622c8c0a-1c95-4f8c-a96d-26787b56ba93"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("6dbed18d-7a03-4865-afbc-52d06645d079"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("4416bb42-0b12-4479-893b-5b9dace9bb01"));
            labelDescription = (ITTLabel)AddControl(new Guid("1c4f3574-0d45-48a7-80a6-5d8a7d2c5f48"));
            InspectionMemorandumCollacationDate = (ITTDateTimePicker)AddControl(new Guid("68c0d04f-3786-4dc5-a854-625b0fe98f7d"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("86b02894-8cd4-4b84-a33a-75b588fcb799"));
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("9149d4f7-ce2f-4e77-92a9-8bb117ce4d99"));
            labelActionName = (ITTLabel)AddControl(new Guid("84ef1b66-a3f9-42af-919c-8d6604b42d1e"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("c2d0bcee-00d0-44ec-bf3a-a5c07b51caa6"));
            labelContractDate = (ITTLabel)AddControl(new Guid("957caa04-cd98-451b-a4a2-ab0577584515"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e1421b62-f5e7-4174-98ac-b4de7f0b2bf6"));
            MaterialsTabPage = (ITTTabPage)AddControl(new Guid("3d5c4288-5f6e-4c2c-afae-36ec2fef4dfe"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("3585d4e3-ab23-4e9b-b7b0-8909525e9602"));
            CheckList = (ITTButtonColumn)AddControl(new Guid("2e8ccce9-62bb-4a7b-b80b-92be028ee070"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("0f5b1c3a-0bc0-49e5-89fc-263c269df539"));
            Material = (ITTListBoxColumn)AddControl(new Guid("712d6d49-be77-4c19-b5ab-d14479634061"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e1984919-6588-4457-b0ba-d12163738f9a"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("42df61a9-625b-47dc-af6e-cb6ed1a6c030"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("d8b993ae-eb36-4c47-bd7c-99bc957f647f"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("5b64151e-8212-432b-9dd3-2e3e0ad87b7c"));
            PurchaseExaminationDetStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("16917239-8ba4-42fc-a24c-8a65ef9bfcad"));
            ProductNumber = (ITTTextBoxColumn)AddControl(new Guid("3be7f984-edda-4440-8df7-719edc257471"));
            ExaminationTabPage = (ITTTabPage)AddControl(new Guid("8bdff038-a402-47e0-b1a8-fedeb6e73ca0"));
            ExaminationCommision = (ITTGrid)AddControl(new Guid("61a4bd71-db47-4485-a16b-47da6ad4bd9b"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("df9ad805-1fc9-4dfe-898f-30632f08db02"));
            Title = (ITTEnumComboBoxColumn)AddControl(new Guid("fcdcb20c-d945-4141-88c3-ad2b6b0f594f"));
            ClassRank = (ITTTextBoxColumn)AddControl(new Guid("d6e74755-3f7f-4900-9544-b37cf1b1f9d5"));
            NameSurname = (ITTListBoxColumn)AddControl(new Guid("d4345a6c-96a5-4b0f-8e42-cbf9fc8a4060"));
            CommisionDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("f6992d67-fc91-4abf-a5c1-6eada55d5e06"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("12f4a8a4-1fdc-4456-990e-79d1d982237c"));
            FunctionExaminationTabPage = (ITTTabPage)AddControl(new Guid("3b9c4864-d528-4dd6-ac01-122cbbe96d56"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("b1dcefac-448f-428c-91c4-0daebac7395b"));
            GeneralExaminationTabPage = (ITTTabPage)AddControl(new Guid("7da4d276-2861-4656-aab8-9aa81ee8dc33"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("bd525d1d-7898-4ef1-936a-5bbbbf9f0b57"));
            FileNO = (ITTTextBox)AddControl(new Guid("71cad20b-62be-45eb-b9da-bd3cc4e032f7"));
            InspectionStatus = (ITTEnumComboBox)AddControl(new Guid("5d102a67-0560-4011-972b-c0a46bec59f1"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("e2ce5a98-3ee0-478a-9210-c499e4f08635"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("54ce677f-b5db-44ad-9955-c45488fdc473"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5bc7dba3-e8ba-4bbe-a6ab-2187ed0e6205"));
            base.InitializeControls();
        }

        public FunctionalExaminationForm() : base("PURCHASEEXAMINATION", "FunctionalExaminationForm")
        {
        }

        protected FunctionalExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}