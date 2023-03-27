
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
    /// Red Tebliğ
    /// </summary>
    public partial class RejectNoticeForm : StockActionBaseForm
    {
    /// <summary>
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseExamination _PurchaseExamination
        {
            get { return (TTObjectClasses.PurchaseExamination)_ttObject; }
        }

        protected ITTDateTimePicker ContractDate;
        protected ITTTextBox InspectionPlace;
        protected ITTTextBox FileNO;
        protected ITTTextBox DecisionNo;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStockActionID;
        protected ITTEnumComboBox InspectionStatus;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelFileNO;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelDescription;
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
        protected ITTTabPage PhysicalExaminationTabPage;
        protected ITTRichTextBoxControl PhysicalInspectionFinalReport;
        protected ITTTabPage GeneralExaminationTabPage;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox Description;
        protected ITTObjectListBox Supplier;
        protected ITTDateTimePicker DecisionDate;
        protected ITTLabel labelActionName;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker InspectionMemorandumCollacationDate;
        protected ITTLabel labelPurchaseType;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        override protected void InitializeControls()
        {
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("266ef3b9-6266-4f33-88a3-40d000bf4692"));
            InspectionPlace = (ITTTextBox)AddControl(new Guid("885e6fd6-8917-40c4-bbcc-02d43c796964"));
            FileNO = (ITTTextBox)AddControl(new Guid("86fb17c2-8a40-405b-8634-d3eca1eb8d86"));
            DecisionNo = (ITTTextBox)AddControl(new Guid("c9f0a7e4-853b-481d-932e-15b652264771"));
            StockActionID = (ITTTextBox)AddControl(new Guid("d13f4d21-9d66-43a0-8918-71cdbe81cdb8"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("adc469cf-779e-4efa-8ce9-419f3e7418af"));
            InspectionStatus = (ITTEnumComboBox)AddControl(new Guid("b38ac62a-55bd-4fac-bb80-fbc596e6805a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("7efd0c09-0ac8-40f3-accd-cf8d7a220d1a"));
            labelFileNO = (ITTLabel)AddControl(new Guid("72b1794b-1041-4c13-8bfe-34861fd5cb55"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("40439d59-978c-42e4-81ea-49f69d74ee35"));
            labelDescription = (ITTLabel)AddControl(new Guid("a224f4a9-2e38-4e58-b816-c32ef678d32f"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("d3e17822-f6b8-4cda-91ce-54e8ae523eac"));
            labelContractDate = (ITTLabel)AddControl(new Guid("62e2ef86-51b3-4158-a943-d8d4e6672860"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("94924dcb-1377-4b26-ab18-232834049675"));
            MaterialsTabPage = (ITTTabPage)AddControl(new Guid("a67fa1e8-3811-4a7a-b364-89426f6e5c11"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("cf811673-d856-4f4a-b015-7034004afa07"));
            CheckList = (ITTButtonColumn)AddControl(new Guid("cb4e01bb-4304-4a93-a4c6-84462756aa2b"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("17549227-6b25-4962-a151-fa4a810a8ea6"));
            Material = (ITTListBoxColumn)AddControl(new Guid("99b33f90-5f88-4448-b086-a8299bdff31c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("046544b7-6d9b-497c-a2b8-2eac7716d961"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("d2a46ded-de0b-481e-96ce-6d9910d02bd4"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("d1030649-1648-424f-8aba-df104e567f7b"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("6b2bdf3b-990d-424d-ac38-59d9557b12aa"));
            PurchaseExaminationDetStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("b709f1db-1a60-4144-ab90-d19a5f4ecb90"));
            ProductNumber = (ITTTextBoxColumn)AddControl(new Guid("d2582095-b5a3-4886-98d9-c90621fb56a6"));
            ExaminationTabPage = (ITTTabPage)AddControl(new Guid("77a7bf0e-b822-4dae-abe3-4df343086599"));
            ExaminationCommision = (ITTGrid)AddControl(new Guid("e596642e-ce5f-45a2-bf4f-21376d1cfa79"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("a53bf124-9935-4bad-ba9b-b4a761cee8ce"));
            Title = (ITTEnumComboBoxColumn)AddControl(new Guid("965a20a3-33b8-44d3-a741-6a85ef761340"));
            ClassRank = (ITTTextBoxColumn)AddControl(new Guid("934bdaa5-210e-44b8-82f0-27b1c47bf778"));
            NameSurname = (ITTListBoxColumn)AddControl(new Guid("c4e4a1ed-5f69-46bc-a4ed-1c5468e1e448"));
            CommisionDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("d4a2a358-0baf-4a0a-b4e1-79434d507063"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("348f195e-7954-4117-8e28-212aa3395e08"));
            PhysicalExaminationTabPage = (ITTTabPage)AddControl(new Guid("fe6ae07e-9d13-4a04-9dd7-2baaad37b87c"));
            PhysicalInspectionFinalReport = (ITTRichTextBoxControl)AddControl(new Guid("54ccc1df-e20d-4d20-a340-25e4ab310e06"));
            GeneralExaminationTabPage = (ITTTabPage)AddControl(new Guid("6bafb2a6-33d6-43e6-bdad-117b4dc39fbe"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("872ec57d-430e-4fc1-b3bb-40911d6a86cf"));
            Description = (ITTTextBox)AddControl(new Guid("c3f219b5-dd48-4867-a55b-155632083e9d"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("9e2fe229-7f07-486b-87c2-e5982eabedcb"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("fd076ab1-164c-42fa-b810-98f65f605021"));
            labelActionName = (ITTLabel)AddControl(new Guid("a4b1dda9-44e5-4b4e-858f-253f9e473cb6"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("f67a5ec1-fdba-455a-857e-ef35d69e019b"));
            InspectionMemorandumCollacationDate = (ITTDateTimePicker)AddControl(new Guid("cff9b432-72a8-4df6-93de-940b43c4c42f"));
            labelPurchaseType = (ITTLabel)AddControl(new Guid("a43c4596-a5af-421d-b030-02a1102fd129"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f7da5b86-27b7-4338-acb7-181f859736fb"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("2ec05355-71a7-4413-b8a5-67ee198e88fa"));
            base.InitializeControls();
        }

        public RejectNoticeForm() : base("PURCHASEEXAMINATION", "RejectNoticeForm")
        {
        }

        protected RejectNoticeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}