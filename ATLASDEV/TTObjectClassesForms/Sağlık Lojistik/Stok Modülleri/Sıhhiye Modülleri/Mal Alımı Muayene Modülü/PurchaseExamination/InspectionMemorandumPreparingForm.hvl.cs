
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
    /// Muayene Muhtırası Tanzim
    /// </summary>
    public partial class InspectionMemorandumPreparingForm : StockActionBaseForm
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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("7a7a610e-8c9b-4046-a99f-9b94873a987a"));
            MaterialsTabPage = (ITTTabPage)AddControl(new Guid("ab2eccb5-0d78-4190-9ebe-0a66c2f65b87"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("353f84f6-7b30-46b3-964b-ace90e770526"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("2fa563f8-f93d-4288-a09f-6a19b66536a2"));
            Material = (ITTListBoxColumn)AddControl(new Guid("427d644c-a33e-48d0-8173-f403966a5d42"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("238bea24-6a4b-49bf-853f-34b448e81f52"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("52a3d80b-d37b-42bc-97fa-e8c3656594a3"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("35e81c52-ecad-4226-95bf-5efacd18089e"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("01523123-152d-437d-9298-3431a5c8f80d"));
            ProductNumber = (ITTTextBoxColumn)AddControl(new Guid("e5a9aa9f-e9b6-42da-967a-e1da1fc8cc95"));
            AccountancyResponsibleTabPage = (ITTTabPage)AddControl(new Guid("e28881b0-c845-47bf-b7ab-f86b30f7c7cd"));
            ExaminationCommision = (ITTGrid)AddControl(new Guid("2b40b15d-79be-4f67-a7a1-36c476af7153"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("6630ba88-1b3a-46a8-be61-0409a54b2b43"));
            Title = (ITTEnumComboBoxColumn)AddControl(new Guid("bae33b34-4c8a-45e7-b353-810f2c3a9a63"));
            ClassRank = (ITTTextBoxColumn)AddControl(new Guid("ca9dced7-73fd-44b2-85b8-ba29aba96819"));
            NameSurname = (ITTListBoxColumn)AddControl(new Guid("344032eb-6e08-407f-80be-ddef37091bab"));
            CommisionDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("4cb0b567-3e3c-4a67-9715-2e5095d42869"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("f881db72-72d0-431b-a29e-fefc3ed71409"));
            PENoticeTextTab = (ITTTabPage)AddControl(new Guid("06288fba-89c9-44ce-99e7-9659cb40a7c0"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("e6e37c84-1bb3-4d8e-9ff6-85271a700ba2"));
            StockActionID = (ITTTextBox)AddControl(new Guid("2773e31b-5d09-4ca9-8121-0028163636a2"));
            InspectionPlace = (ITTTextBox)AddControl(new Guid("db07e1a3-b850-4d10-8100-d025b24690c8"));
            Description = (ITTTextBox)AddControl(new Guid("aea16ca0-b05d-4d28-9278-f6f7b90bdc68"));
            DecisionNO = (ITTTextBox)AddControl(new Guid("cad6690b-c858-491d-9c15-f71cc41247e8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a8e5d23a-0db1-48a3-8f87-1767e324fde0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ce1fcbe5-3062-4124-8403-28229c4cf711"));
            TemporaryDeliveryDate = (ITTDateTimePicker)AddControl(new Guid("83ff1186-c0fc-4bfd-af30-45752a1a287a"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("22dd861b-0ae4-49f3-9774-479f7f3f1101"));
            Store = (ITTObjectListBox)AddControl(new Guid("35b3eaf4-ac75-45c7-bcdc-49519ab8f625"));
            labelContractDate = (ITTLabel)AddControl(new Guid("516e7963-7b75-476a-8b77-50bd9fb66cf8"));
            labelStore = (ITTLabel)AddControl(new Guid("7581467f-ead6-4b26-9358-69198f8208cd"));
            labelDecisionNO = (ITTLabel)AddControl(new Guid("e01fcd76-62fa-44f5-b1e1-72678fccc62d"));
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("c2c94149-9d1e-44da-ade0-7f371e42ddcd"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("59ef5317-b7a3-468d-8862-889664c0dc01"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("0b733e6d-994f-4c83-b7ff-a8836aedb204"));
            labelActionName = (ITTLabel)AddControl(new Guid("edd3bd3e-685b-4ec8-9328-ab6fe238e8db"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("33524833-befe-4f7b-bb82-d3616eb43103"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4d8881f7-1114-47a7-85ac-dc070fbb92f7"));
            labelDescription = (ITTLabel)AddControl(new Guid("caa2e6ab-fe81-4b53-a836-dc52f248d8d4"));
            InspectionMemorandumCollacationDate = (ITTDateTimePicker)AddControl(new Guid("68ecd73d-4295-4cd4-9bbf-dd815b69cde3"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("3e374e6f-01bc-418d-b878-fea439adfff4"));
            base.InitializeControls();
        }

        public InspectionMemorandumPreparingForm() : base("PURCHASEEXAMINATION", "InspectionMemorandumPreparingForm")
        {
        }

        protected InspectionMemorandumPreparingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}