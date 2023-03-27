
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
    /// Fiziksel Muayene ve Numune Alma  
    /// </summary>
    public partial class PhysicalExaminationForm : StockActionBaseForm
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
        protected ITTTabPage AdministrativeSpecification;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTextBox Description;
        protected ITTObjectListBox Supplier;
        protected ITTDateTimePicker DecisionDate;
        protected ITTLabel labelActionName;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker InspectionMemorandumCollacationDate;
        protected ITTLabel labelPurchaseType;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker ttdatetimepicker2;
        override protected void InitializeControls()
        {
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("bab284d3-aa0b-4d77-9a32-04f8f901e109"));
            InspectionPlace = (ITTTextBox)AddControl(new Guid("9c83cc52-f9e1-415a-9dea-05e04aa216a1"));
            FileNO = (ITTTextBox)AddControl(new Guid("ef011e2b-d84c-47cb-89ab-3f2e0f972342"));
            DecisionNo = (ITTTextBox)AddControl(new Guid("7bd1052f-b5a3-4f33-8ec5-5b16c7babde6"));
            StockActionID = (ITTTextBox)AddControl(new Guid("89d49a14-4a7b-4398-b2a7-81da991e2547"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("84a8a7a5-c921-4511-bff5-14257e4cf4cb"));
            InspectionStatus = (ITTEnumComboBox)AddControl(new Guid("6652f983-a7ec-44c0-b9a2-227dfb38321f"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f5fcfa0f-406c-416b-90c3-26cfefd37011"));
            labelFileNO = (ITTLabel)AddControl(new Guid("391a2d2d-7eb7-4f13-b8c0-3d65145ffcf8"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f18557dd-aaaf-42d7-a07e-5daa721821e6"));
            labelDescription = (ITTLabel)AddControl(new Guid("c1ff401e-f526-440e-a3d2-6170e5cef976"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("fa8c7067-b682-4496-a2e3-a23736057a89"));
            labelContractDate = (ITTLabel)AddControl(new Guid("33ae7997-29c4-4400-9e52-b9bc8258dfd6"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("790adbd8-74d1-416a-8711-bc4886e7b8eb"));
            MaterialsTabPage = (ITTTabPage)AddControl(new Guid("a8ec9213-307e-40c7-9f13-927b3302fa50"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("673d097f-3393-4d2d-b259-099aa41e7d0d"));
            CheckList = (ITTButtonColumn)AddControl(new Guid("34f7f2ec-0141-46dc-8dda-2b396f29ea2f"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("72d100aa-06e3-49c9-a14e-29b581e939ee"));
            Material = (ITTListBoxColumn)AddControl(new Guid("46fca865-9e35-412d-9e25-9a11c4467d7a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("0b10811b-47e8-4961-9e24-dc341372984e"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("39ec58d5-1b7e-4fc1-b256-ff74f26bb669"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("2a7fd527-bc3e-4b21-b534-39e57c2b9961"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("8a86d6d3-b54b-4514-b7c8-aec99da0da96"));
            PurchaseExaminationDetStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("e3421e69-dcc6-42ff-8384-666e4c97ddf1"));
            ProductNumber = (ITTTextBoxColumn)AddControl(new Guid("a55061ca-e6c4-4271-a831-4d38a807453c"));
            ExaminationTabPage = (ITTTabPage)AddControl(new Guid("f15bc367-87f3-421f-801d-f79955ea00f5"));
            ExaminationCommision = (ITTGrid)AddControl(new Guid("b2521480-1464-445c-806e-898fa6e4b7af"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("c64685ad-6780-443a-acea-162c6c8a83f1"));
            Title = (ITTEnumComboBoxColumn)AddControl(new Guid("c3204aa0-ac4b-43b9-aaa2-e33d323e1491"));
            ClassRank = (ITTTextBoxColumn)AddControl(new Guid("4e921b32-2814-4011-8502-75f3bee05e0c"));
            NameSurname = (ITTListBoxColumn)AddControl(new Guid("69da4296-6595-4a4d-907b-88dcd13d5f04"));
            CommisionDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("16705549-66cd-46aa-821e-c90cb78b3eb3"));
            PrimeBackup = (ITTCheckBoxColumn)AddControl(new Guid("df5e8304-248d-4cd2-af9b-0ee6d52ac87d"));
            PhysicalExaminationTabPage = (ITTTabPage)AddControl(new Guid("ce544178-bf9b-4e4d-a2db-29b828372a0f"));
            PhysicalInspectionFinalReport = (ITTRichTextBoxControl)AddControl(new Guid("69ae97e6-10b5-4553-bbcb-b487baf8fa1c"));
            GeneralExaminationTabPage = (ITTTabPage)AddControl(new Guid("8ffc07b3-9f0c-4c5e-ab9b-5ad96570e3ee"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("71d268d4-a76e-4397-8438-98ced8a5d6d8"));
            AdministrativeSpecification = (ITTTabPage)AddControl(new Guid("60ed5cec-3b53-4071-bf32-4e7d6212d10c"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("1b142ab3-4086-4f6a-9221-9bc513bc2ac1"));
            Description = (ITTTextBox)AddControl(new Guid("9ac94073-13fb-4e39-8e46-d0b88d146ab5"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("171710d3-58b9-4159-8864-c8761325a925"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("6d9d9e3e-9e68-43e0-a924-d3e7f527b450"));
            labelActionName = (ITTLabel)AddControl(new Guid("0f853db8-2240-420f-91f7-d78398d3d34b"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("3761225d-bb2a-4698-b019-ff3f8e18e6f2"));
            InspectionMemorandumCollacationDate = (ITTDateTimePicker)AddControl(new Guid("a92bd608-5238-4ed9-8bd7-ffa5c16580ad"));
            labelPurchaseType = (ITTLabel)AddControl(new Guid("63cfaf92-ed30-49e1-a185-ffe5d18fc7cf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("729d1894-038d-480f-9606-9c86aa893e11"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("32e280fd-b964-4fcd-b950-1bc79c0e9dbb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e6e6efde-ada2-4fbd-9e39-4cc87031f582"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("99b5c718-3a8a-43b8-ad49-e4dcd069d2c6"));
            base.InitializeControls();
        }

        public PhysicalExaminationForm() : base("PURCHASEEXAMINATION", "PhysicalExaminationForm")
        {
        }

        protected PhysicalExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}