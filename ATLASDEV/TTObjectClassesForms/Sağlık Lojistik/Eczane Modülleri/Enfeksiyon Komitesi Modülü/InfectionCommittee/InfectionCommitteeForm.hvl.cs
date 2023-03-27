
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
    public partial class InfectionCommitteeForm : ActionForm
    {
    /// <summary>
    /// Enfeksiyon Komitesi
    /// </summary>
        protected TTObjectClasses.InfectionCommittee _InfectionCommittee
        {
            get { return (TTObjectClasses.InfectionCommittee)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage DrugOrderTab;
        protected ITTGrid InpatientDrugOrders;
        protected ITTListBoxColumn Drug;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn UsageNote;
        protected ITTTextBoxColumn Description;
        protected ITTTextBox NamePerson;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ID;
        protected ITTLabel labelNamePerson;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelID;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelMasterResource;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("221332b1-5b01-4825-8e29-8682010fcf53"));
            DrugOrderTab = (ITTTabPage)AddControl(new Guid("5cb60be6-a557-4e9a-9d7d-b9aa8f131355"));
            InpatientDrugOrders = (ITTGrid)AddControl(new Guid("0996e0dc-dc2d-4990-a617-a88498985c65"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("c4b1b137-f217-4bdd-b561-94f5e9bc580d"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("81153587-93ed-4b38-a682-c24927dddae5"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("dec7abb6-5ae5-4af0-9973-ec294ab6c29a"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("f392b6c1-7307-4083-b90e-8e62c5b68c54"));
            UsageNote = (ITTTextBoxColumn)AddControl(new Guid("7b06019d-16f1-42d8-ad77-3b6acd6ab728"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("5ce63d32-1b9f-48f3-9c4f-a73d26bd423c"));
            NamePerson = (ITTTextBox)AddControl(new Guid("ffc01013-1ee6-4cd0-b204-f13d8998e175"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("ffb3f0f2-5451-4b7a-afd7-e3d82d2a528c"));
            ID = (ITTTextBox)AddControl(new Guid("11f54b11-651e-4758-9cd7-311b4051c3ba"));
            labelNamePerson = (ITTLabel)AddControl(new Guid("d8a108c5-250f-471d-af96-242a636d587b"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("5fcf6080-0fa1-4626-8b21-0d6957dba572"));
            labelID = (ITTLabel)AddControl(new Guid("0715e400-58f9-42b8-a801-7b913fa3aa49"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e1fc51af-d8e5-452a-84d0-054bd3fcdfee"));
            labelActionDate = (ITTLabel)AddControl(new Guid("48207f4d-c0df-439b-9b48-a1b06449e51e"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("a785bbb9-8636-4f9e-aeb7-eaef05a0d9f3"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("0df73991-6185-452b-a211-a9813da004de"));
            base.InitializeControls();
        }

        public InfectionCommitteeForm() : base("INFECTIONCOMMITTEE", "InfectionCommitteeForm")
        {
        }

        protected InfectionCommitteeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}