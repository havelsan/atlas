
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
    /// Test İstek Formu
    /// </summary>
    public partial class DPT_RequestForm : TTForm
    {
    /// <summary>
    /// İlaç Üretim Testi modülü için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DrugProductionTest _DrugProductionTest
        {
            get { return (TTObjectClasses.DrugProductionTest)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid TestsGrid;
        protected ITTListBoxColumn TestDef;
        protected ITTListBoxColumn RequestedBy;
        protected ITTTextBox StockActionID;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTButton cmdControl;
        protected ITTObjectListBox DestinationStore;
        protected ITTMaskedTextBox SerialNo;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelOrderNO;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ProducedMaterial;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox TTListBox;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("8bf88cf1-c7f5-4a00-9522-268cbded4c02"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("cdeba07f-1c66-4697-aea2-2d0d3662c4f0"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("33236054-a0c5-419e-8d83-466debb0258b"));
            TestsGrid = (ITTGrid)AddControl(new Guid("2c7776c5-a856-41db-8236-58224bf3af63"));
            TestDef = (ITTListBoxColumn)AddControl(new Guid("eeae71d2-1315-472a-8e47-b68fa323cbd8"));
            RequestedBy = (ITTListBoxColumn)AddControl(new Guid("21f34ecc-a2c8-4895-8a5b-523a012e0e60"));
            StockActionID = (ITTTextBox)AddControl(new Guid("e41a0173-f14f-4796-a10a-9622e3c8d2cd"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e32fed69-c108-47ad-9621-089bf97b8b92"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8e6d3d49-f77c-43c8-ab59-798103ea533b"));
            cmdControl = (ITTButton)AddControl(new Guid("df37b203-9248-4e7c-a1da-f3584993781c"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("e640e76c-78fe-41c6-8220-37c72366df75"));
            SerialNo = (ITTMaskedTextBox)AddControl(new Guid("7e8a861c-3d7e-475f-9d91-9f2145750a94"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("5961b265-6cb6-4f61-8538-18ce6ee10b61"));
            labelStore = (ITTLabel)AddControl(new Guid("1a15294d-24fa-4441-b03f-e832fd0f74b6"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("f1b1e594-af4b-4985-9a5e-d1c41deb09a0"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("03c7f1d4-a770-46da-a3bf-bcfe7d168250"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("fb858f36-30b1-4b4f-807f-ff32188ddbc4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ac2558a6-485e-4b2d-8321-5b22d10a63b3"));
            ProducedMaterial = (ITTObjectListBox)AddControl(new Guid("8f2cd8f3-8f4d-4bf0-97ee-4444e43b5d08"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("61782d5f-0ecb-45ac-be3e-876626eebddb"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9f20ea18-ac94-4495-b359-36cab9f8d3f7"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("6d6d5dc2-d698-413f-ba43-d0138514cd79"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3b68d5d5-cd9d-4c07-b5fe-41c14eab8191"));
            base.InitializeControls();
        }

        public DPT_RequestForm() : base("DRUGPRODUCTIONTEST", "DPT_RequestForm")
        {
        }

        protected DPT_RequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}