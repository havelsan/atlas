
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
    /// Enfeksiyon Onay
    /// </summary>
    public partial class KScheduleInfectionForm : StockActionBaseForm
    {
    /// <summary>
    /// Günlük İlaç Çizelgesi
    /// </summary>
        protected TTObjectClasses.KSchedule _KSchedule
        {
            get { return (TTObjectClasses.KSchedule)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTGrid InfectionDrugs;
        protected ITTListBoxColumn TDrug;
        protected ITTTextBoxColumn TAmount;
        protected ITTTextBoxColumn QuarantineNo;
        protected ITTTabPage tttabpage1;
        protected ITTGrid KScheduleMaterials;
        protected ITTTextBoxColumn tttextboxcolumn15;
        protected ITTTextBoxColumn tttextboxcolumn16;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn tttextboxcolumn17;
        protected ITTTextBoxColumn tttextboxcolumn18;
        protected ITTTextBoxColumn tttextboxcolumn19;
        protected ITTTextBoxColumn tttextboxcolumn20;
        protected ITTTextBoxColumn tttextboxcolumn21;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn3;
        protected ITTListDefComboBoxColumn ttlistdefcomboboxcolumn3;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTTextBox IDPatient;
        protected ITTTextBox FullNamePatient;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox DestinationStore;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelFullNamePatient;
        protected ITTLabel labelIDPatient;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d91bc539-d396-4e08-9413-fb145e02543e"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("8a6fc654-7fca-4f54-8d65-e7b2b44e4781"));
            InfectionDrugs = (ITTGrid)AddControl(new Guid("81d31b9c-465c-4b76-93d2-b0f20bb0adb5"));
            TDrug = (ITTListBoxColumn)AddControl(new Guid("d67e392f-c0ce-4194-b729-997865510d3a"));
            TAmount = (ITTTextBoxColumn)AddControl(new Guid("18740c64-94bf-4964-9fd1-297192dd7a45"));
            QuarantineNo = (ITTTextBoxColumn)AddControl(new Guid("06d2f795-2690-4e4f-bbd0-96859117a2d1"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("f8f4d723-7dcd-4112-bdea-c2426f0f69bb"));
            KScheduleMaterials = (ITTGrid)AddControl(new Guid("35106bcd-2419-42b8-8fa6-25272a48cd3f"));
            tttextboxcolumn15 = (ITTTextBoxColumn)AddControl(new Guid("28414ecf-eb0e-4c83-88e8-5984110b8e1f"));
            tttextboxcolumn16 = (ITTTextBoxColumn)AddControl(new Guid("062f4e99-f22f-48fe-8f56-679798ba0c4a"));
            Material = (ITTListBoxColumn)AddControl(new Guid("be0c901d-8ce9-4668-8f7f-0b58666e2cb6"));
            tttextboxcolumn17 = (ITTTextBoxColumn)AddControl(new Guid("8c60db1d-1647-49de-b0b8-4ce0b6ca429f"));
            tttextboxcolumn18 = (ITTTextBoxColumn)AddControl(new Guid("8cfef183-920d-407d-ad30-93c3f367a855"));
            tttextboxcolumn19 = (ITTTextBoxColumn)AddControl(new Guid("a6160339-1fa3-4559-a900-f42119b7e2db"));
            tttextboxcolumn20 = (ITTTextBoxColumn)AddControl(new Guid("a21f2df5-3115-458c-ac59-702aa95288e2"));
            tttextboxcolumn21 = (ITTTextBoxColumn)AddControl(new Guid("88fce6ab-8b17-40a2-9ea8-1838fbccb573"));
            ttenumcomboboxcolumn3 = (ITTEnumComboBoxColumn)AddControl(new Guid("2e33e22c-cfba-4e22-b6ca-95c085254ea9"));
            ttlistdefcomboboxcolumn3 = (ITTListDefComboBoxColumn)AddControl(new Guid("d5fd927b-38c9-4857-bef9-0d45da46396c"));
            Description = (ITTTextBox)AddControl(new Guid("ac37a8a9-26c8-4c19-ae31-efa181a16a39"));
            StockActionID = (ITTTextBox)AddControl(new Guid("19e44594-d896-4dc7-b7ac-ea88971227e4"));
            IDPatient = (ITTTextBox)AddControl(new Guid("528fcd3e-e6e8-4e16-b5ac-79b44217c777"));
            FullNamePatient = (ITTTextBox)AddControl(new Guid("f2d25d1b-43fb-446f-ab5a-a3dbde6b54d8"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("6f0d0884-91f1-42a8-8985-d8028d8064f8"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("d5f18e23-5cea-4cff-becb-06b955cdfa3c"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("ad8ec2f8-42eb-4cc9-a145-41ac775dc8c5"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("6a0bd6b0-710a-4082-8a07-d624d1e228c5"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("d8f09241-f1c8-4d22-8e8f-d077150e5bab"));
            labelStore = (ITTLabel)AddControl(new Guid("cf1d11c2-c10f-41ac-9aa6-6720e7ffa82b"));
            labelDescription = (ITTLabel)AddControl(new Guid("10200523-881c-4baf-a186-d3df25e4cde2"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("93c76bc7-34da-4b15-b2ab-a072480be5b9"));
            Store = (ITTObjectListBox)AddControl(new Guid("5eeaf9b6-dc88-4cb3-99d0-f6cf5c73ed76"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("6ff82771-2a23-4756-8cf6-99ed9dab7a1c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e04cd39b-baa3-4d83-b4de-3e7fe5f2427e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("834ab546-7c01-4366-be49-12aa6acf383b"));
            labelFullNamePatient = (ITTLabel)AddControl(new Guid("b63c0fe4-8aa4-483d-8fc1-6a6812d7986a"));
            labelIDPatient = (ITTLabel)AddControl(new Guid("cb5a6636-e464-4963-bf30-dcc74211a4f6"));
            base.InitializeControls();
        }

        public KScheduleInfectionForm() : base("KSCHEDULE", "KScheduleInfectionForm")
        {
        }

        protected KScheduleInfectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}