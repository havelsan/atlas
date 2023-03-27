
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
    /// Sonuçlanmış Test
    /// </summary>
    public partial class DPT_CompletedForm : TTForm
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
        protected ITTObjectListBox TTListBox;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ttobjectlistbox2;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("ed9960f6-4f17-469a-9ae0-ac5377b9c6ed"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("2b666b3a-4d4d-4a1e-9f08-969a590b791c"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("bbe50044-934a-4f99-903e-05eed075bd7c"));
            TestsGrid = (ITTGrid)AddControl(new Guid("edf0bb08-b8e1-4d15-aec6-90ba1a03259d"));
            TestDef = (ITTListBoxColumn)AddControl(new Guid("62f7b03a-d412-4458-90a6-0b19adaa2621"));
            RequestedBy = (ITTListBoxColumn)AddControl(new Guid("8de5b175-5881-4d6d-a070-513c78971374"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("cfc3d074-8729-4ec1-b9c1-a6617246e58f"));
            Analyser = (ITTListBoxColumn)AddControl(new Guid("660ce993-ec55-4fbb-a6c6-20a07c077c2d"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("dc74497e-9d13-469d-96a7-76a84d93a0d4"));
            SerialNo = (ITTMaskedTextBox)AddControl(new Guid("59870fea-a9c0-48ed-accc-022218a6a256"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("30696263-222e-459f-9570-61069d81996d"));
            labelStore = (ITTLabel)AddControl(new Guid("b30a185c-7fe0-4743-8ad9-be9865dd32db"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("11168159-8068-4064-a1b1-bcf38fe86737"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("dcd178a5-31ce-411b-84a4-98b7385b9cc1"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("3d441b5d-0db4-4ecf-b69e-f347e3b93619"));
            StockActionID = (ITTTextBox)AddControl(new Guid("cd565ddf-2389-448b-91df-a1197eafd79a"));
            ProducedMaterial = (ITTObjectListBox)AddControl(new Guid("23b21a0b-d374-4dc9-b7db-175a7cd32642"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0e37482d-e2b2-421e-9863-d4b70f0bbf19"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("42097fe8-7370-4818-b693-17315f016106"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("24a66aba-4a56-415b-900a-3f77569e9d59"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("829a4f49-cc48-4849-9251-c8f6a62d2bc9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("83c9244f-0125-451c-bf50-ad6c55336dcc"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2adceb34-5c70-4c2b-a67a-81c2d1965876"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7f8bf6cc-4fdb-4306-b7f5-0b3f74930f46"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5e2f4566-2f54-4cc9-b512-7c318a54be33"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e98258f4-7834-47da-ac1e-5712af644541"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d5c45195-3599-4643-a981-dbba826d702d"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b2a5fdc1-a9a6-4714-a74c-a16e592bdd80"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d6668465-c760-4b74-9a38-ae9556be9cee"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("332616ed-1a88-4b5a-b43c-c1457ab5057e"));
            base.InitializeControls();
        }

        public DPT_CompletedForm() : base("DRUGPRODUCTIONTEST", "DPT_CompletedForm")
        {
        }

        protected DPT_CompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}