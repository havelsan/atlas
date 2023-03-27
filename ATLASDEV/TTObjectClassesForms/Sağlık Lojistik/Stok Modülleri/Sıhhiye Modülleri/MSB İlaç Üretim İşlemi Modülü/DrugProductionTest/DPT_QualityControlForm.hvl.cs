
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
    /// Kalite Kontrol
    /// </summary>
    public partial class DPT_QualityControlForm : TTForm
    {
    /// <summary>
    /// İlaç Üretim Testi modülü için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DrugProductionTest _DrugProductionTest
        {
            get { return (TTObjectClasses.DrugProductionTest)_ttObject; }
        }

        protected ITTObjectListBox TTListBox;
        protected ITTLabel ttlabel3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid TestsGrid;
        protected ITTListBoxColumn TestDef;
        protected ITTListBoxColumn RequestedBy;
        protected ITTTextBoxColumn Result;
        protected ITTListBoxColumn Analyser;
        protected ITTObjectListBox DestinationStore;
        protected ITTMaskedTextBox SerialNo;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelOrderNO;
        protected ITTDateTimePicker TransactionDate;
        protected ITTTextBox StockActionID;
        protected ITTObjectListBox ProducedMaterial;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            TTListBox = (ITTObjectListBox)AddControl(new Guid("a0b11d0b-3dee-4249-84e2-0e92700c5008"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("89fa4cf7-6765-4eb8-8609-df9044e6ad91"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("9177504f-5c25-4581-a108-cb478bf3c7ab"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("da4ff507-54d3-4599-93ed-83bd61c1bc8c"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("a3f052c6-c241-40d9-80de-3116a460e807"));
            TestsGrid = (ITTGrid)AddControl(new Guid("3b86d2bc-4b85-4ff2-b23e-c42f6a7e8971"));
            TestDef = (ITTListBoxColumn)AddControl(new Guid("0eeeabc9-bcfe-42c6-91d7-ace61a8742bd"));
            RequestedBy = (ITTListBoxColumn)AddControl(new Guid("9cfb135e-d0a6-4a86-bfde-15ebf77866f1"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("212d8ffc-777a-4826-b89a-ee08566d4fc4"));
            Analyser = (ITTListBoxColumn)AddControl(new Guid("8358c367-621f-4de4-aec1-777646f8db89"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("5a3e3bcb-e3fe-475e-b214-23a13bf0169b"));
            SerialNo = (ITTMaskedTextBox)AddControl(new Guid("5fd741a3-fdad-4d27-894d-09a6443d5ec7"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("e303b6fa-8c5d-4b32-b11d-d3214cf04e05"));
            labelStore = (ITTLabel)AddControl(new Guid("bf5e51f3-9d76-40e2-8db1-51c43480c488"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("203fd35b-f557-439b-84ba-5eb13806dac4"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("d297f227-31fc-44fe-a7e6-b496a1db463d"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("1e658081-7f55-4936-82f2-0855b0b659d8"));
            StockActionID = (ITTTextBox)AddControl(new Guid("39513d99-0a71-4a3e-bc6d-d70158acc907"));
            ProducedMaterial = (ITTObjectListBox)AddControl(new Guid("1a5abd21-1bc0-428d-a251-0366f788ab2d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4a73c8af-0d06-42e7-8d99-58980d8e8fe2"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("5587092f-a7fc-48e4-be86-95c66ce1ffd9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7738636c-28fe-418b-9dbb-03f384ff3b7d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5947ffa4-67f8-45c3-8f1c-bc35c00ee7a7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("142af702-2c06-4ebb-8639-f5a96eeeba5a"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("3f5a443b-67e3-42d7-8097-b4a81e577a9b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("c09223e0-3582-4039-8965-5ccdefb2d5ee"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("228a6667-9e04-48de-aee7-87e56272e3af"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("16886d79-8001-4894-9dd3-bc5c49d53086"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("4cfcf30c-958f-474d-aa74-5702e88c5ec4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("a65155ad-8ce0-4fda-8016-44b9e3e3a837"));
            base.InitializeControls();
        }

        public DPT_QualityControlForm() : base("DRUGPRODUCTIONTEST", "DPT_QualityControlForm")
        {
        }

        protected DPT_QualityControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}