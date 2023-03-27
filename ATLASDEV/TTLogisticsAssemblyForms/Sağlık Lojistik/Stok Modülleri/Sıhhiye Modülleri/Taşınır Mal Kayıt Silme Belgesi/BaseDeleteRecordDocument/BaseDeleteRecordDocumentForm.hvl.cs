
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
    public partial class BaseDeleteRecordDocumentForm : StockActionBaseForm
    {
        protected TTObjectClasses.BaseDeleteRecordDocument _BaseDeleteRecordDocument
        {
            get { return (TTObjectClasses.BaseDeleteRecordDocument)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox ReturningDocumentNumber;
        protected ITTTextBox StockActionID;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTTextBoxColumn FreeTextSignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTLabel labelMKYS_CikisStokHareketTuru;
        protected ITTEnumComboBox MKYS_CikisStokHareketTuru;
        protected ITTLabel labelMKYS_CikisIslemTuru;
        protected ITTEnumComboBox MKYS_CikisIslemTuru;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelReturningDocumentNumber;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelTransactionDate;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage TechnicalReportTabpage;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage InspectionTabpage;
        protected ITTGrid StockActionInspectionDetailsStockActionInspectionDetail;
        protected ITTEnumComboBoxColumn InspectionUserTypeStockActionInspectionDetail;
        protected ITTListBoxColumn InspectionUserStockActionInspectionDetail;
        protected ITTTextBoxColumn NameStringStockActionInspectionDetail;
        protected ITTTextBoxColumn ShortMilitaryClassStockActionInspectionDetail;
        protected ITTTextBoxColumn ShortRankStockActionInspectionDetail;
        protected ITTTextBoxColumn EmploymentRecordIDStockActionInspectionDetail;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel labelInspectionDate;
        protected ITTTextBox ReportNO;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker InspectionDate;
        protected ITTButton TTTeslimEdenButon;
        protected ITTButton TTTeslimAlanButon;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("f188f037-a142-41c7-a63b-64c9725698a1"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("38d0cbe0-542f-4c69-81e8-a4d5622461de"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("646d817b-3b15-471d-a736-b0dc635da96c"));
            ReturningDocumentNumber = (ITTTextBox)AddControl(new Guid("4e503d75-8ade-49c4-b2b0-c57fca68f7e2"));
            StockActionID = (ITTTextBox)AddControl(new Guid("8a245efd-e256-46f2-97db-f9588baa9d7b"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("5317be81-6498-4c2a-8c63-bb494c6a1e2d"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("58440ad0-0d91-4c37-9775-20293896ce98"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("b6b0a4d9-a76a-4cfb-ac24-8946c3a9e470"));
            FreeTextSignUser = (ITTTextBoxColumn)AddControl(new Guid("ae1eeaa2-45c9-4338-a741-6c9c74b0c080"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("e193f66e-13ca-4757-a5b1-ed78d6a65aaa"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("087af9c2-a277-4994-9c2a-997f4d5cb165"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("4263ae3b-2a0c-4d03-aa3a-0ed4c3f3a7f6"));
            labelMKYS_CikisStokHareketTuru = (ITTLabel)AddControl(new Guid("e1f38198-134e-47f3-9a92-557598f8c7bd"));
            MKYS_CikisStokHareketTuru = (ITTEnumComboBox)AddControl(new Guid("3e0fff36-dec5-4754-a02d-69ae4135ee05"));
            labelMKYS_CikisIslemTuru = (ITTLabel)AddControl(new Guid("85300f5d-5ed9-4999-bed6-7e2b881e3210"));
            MKYS_CikisIslemTuru = (ITTEnumComboBox)AddControl(new Guid("3e6d81cf-796f-403a-8e45-e3e66306b85f"));
            labelStore = (ITTLabel)AddControl(new Guid("2178a0bf-6419-444b-8a54-caf861029513"));
            Store = (ITTObjectListBox)AddControl(new Guid("923a8fbb-d581-4ae9-bac2-491bfebb96a1"));
            labelReturningDocumentNumber = (ITTLabel)AddControl(new Guid("1d6db6c1-97d6-4adb-ad42-50bd40d2444f"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("9707065f-2f4c-47cc-83d8-e330747c7322"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("f97e73ae-92e0-4179-9093-6b1bc8ad2a70"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("b3508eb1-9c54-4d6c-a32f-239f8dddb4b8"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("d08c00d7-661e-4814-ae9f-20647cd87a21"));
            TechnicalReportTabpage = (ITTTabPage)AddControl(new Guid("84231e88-b93c-40e8-8dfe-163f4c502301"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("0a6e53fa-6568-47aa-95b7-d1ed0c88cb22"));
            InspectionTabpage = (ITTTabPage)AddControl(new Guid("744dd7bc-41d4-4b2a-be88-45317f32f1e8"));
            StockActionInspectionDetailsStockActionInspectionDetail = (ITTGrid)AddControl(new Guid("b2042d54-f9d3-4583-98fd-f91cde2d7818"));
            InspectionUserTypeStockActionInspectionDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("690d315b-0021-4fa8-9823-93937c9dc4cc"));
            InspectionUserStockActionInspectionDetail = (ITTListBoxColumn)AddControl(new Guid("5aece016-9d8a-450c-9cf1-c7ef4d786554"));
            NameStringStockActionInspectionDetail = (ITTTextBoxColumn)AddControl(new Guid("85533e2f-98d3-4c30-9a5e-214f961e6f71"));
            ShortMilitaryClassStockActionInspectionDetail = (ITTTextBoxColumn)AddControl(new Guid("afe25764-861e-4fb4-85c0-1b09fd8ca163"));
            ShortRankStockActionInspectionDetail = (ITTTextBoxColumn)AddControl(new Guid("65d03f0e-a469-46b8-9b21-cc4b23ef2e89"));
            EmploymentRecordIDStockActionInspectionDetail = (ITTTextBoxColumn)AddControl(new Guid("f96fb1db-a4c3-45a3-80e2-325aa65ebaeb"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("7267dbee-f020-4ba3-897c-a4617b0d8f2d"));
            labelInspectionDate = (ITTLabel)AddControl(new Guid("9d701d85-755e-416d-b0d3-5eb34ee0dac3"));
            ReportNO = (ITTTextBox)AddControl(new Guid("fa78a186-6188-43be-9fc9-81f0c5936342"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4fd0703c-1d60-4a16-bee7-22031b3f5b59"));
            InspectionDate = (ITTDateTimePicker)AddControl(new Guid("f905a829-e8f3-47f6-9c35-85ed4334f30e"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("10a73f0b-c530-4e1c-a081-5f0eb1448095"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("f8916159-bc1a-4bba-abec-1b7bec913a20"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2e8714cd-284b-4563-a4e1-7fb67520f7d0"));
            base.InitializeControls();
        }

        public BaseDeleteRecordDocumentForm() : base("BASEDELETERECORDDOCUMENT", "BaseDeleteRecordDocumentForm")
        {
        }

        protected BaseDeleteRecordDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}