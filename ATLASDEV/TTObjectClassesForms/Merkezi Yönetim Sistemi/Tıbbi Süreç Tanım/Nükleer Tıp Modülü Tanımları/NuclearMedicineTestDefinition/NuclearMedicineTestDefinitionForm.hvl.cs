
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
    /// Nükleer Tıp Tetkik Tanımları
    /// </summary>
    public partial class NuclearMedicineTestDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Nükleer Tıp Tetkik Tanımları
    /// </summary>
        protected TTObjectClasses.NuclearMedicineTestDefinition _NuclearMedicineTestDefinition
        {
            get { return (TTObjectClasses.NuclearMedicineTestDefinition)_ttObject; }
        }

        protected ITTLabel labelSKRSLoincKodu;
        protected ITTObjectListBox SKRSLoincKodu;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTCheckBox ChkChargable;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn TabNameGridCol;
        protected ITTTabPage tttabpage2;
        protected ITTGrid ttgrid4;
        protected ITTListBoxColumn EquipmentList;
        protected ITTTabPage TabPagePharmMaterials;
        protected ITTGrid ttgrid3;
        protected ITTListBoxColumn RadioPharmaCeuticalMaterial;
        protected ITTTabPage TabPageTreatmentMaterials;
        protected ITTGrid ttgrid2;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Qref;
        protected ITTTextBox ID;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelQref;
        protected ITTLabel labelID;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelSKRSLoincKodu = (ITTLabel)AddControl(new Guid("83685c21-91e0-4d12-b1d2-d6bb3aa21b4a"));
            SKRSLoincKodu = (ITTObjectListBox)AddControl(new Guid("be51cd9a-25b9-446a-af0f-b6b0eac005ab"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("67a9f4c9-6bfc-46b6-9529-889ccbb2796e"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("0be66a9b-ec33-4738-9d40-db167b4aa387"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("a31edc90-2ac1-4bcc-b7e2-f40d49a1fe29"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("3adc2d4c-43bf-40fc-ad12-f64cd73a5f58"));
            ChkChargable = (ITTCheckBox)AddControl(new Guid("38760728-bbe5-4e45-b8a4-f5e962c1c2fc"));
            Name = (ITTTextBox)AddControl(new Guid("d8531459-539d-43b0-877d-17fcbe0b75c3"));
            labelName = (ITTLabel)AddControl(new Guid("7370cced-d91c-4f84-8783-1a891e8dd745"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8058f06e-1d97-4020-98be-584dca28ab54"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("c9cdc015-2086-4aa9-9f5c-e76596b01ca3"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("51b017ce-409b-4b7f-83b4-d3778a015f33"));
            TabNameGridCol = (ITTListBoxColumn)AddControl(new Guid("5a957f94-8446-41e0-ac86-427a9fae2c49"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("5eef25f4-a1eb-4875-8977-b2bf6fb494c4"));
            ttgrid4 = (ITTGrid)AddControl(new Guid("8c9d48e3-8eb2-47ee-aaba-28fd0f68db1c"));
            EquipmentList = (ITTListBoxColumn)AddControl(new Guid("3299cca1-e7e2-4791-a282-6ed4845c45d0"));
            TabPagePharmMaterials = (ITTTabPage)AddControl(new Guid("878f12d1-0a0b-4e51-8669-d49aa135a4d3"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("64831fa1-820b-4607-8dc3-5658c185e6e8"));
            RadioPharmaCeuticalMaterial = (ITTListBoxColumn)AddControl(new Guid("fa3545e9-dff3-4d87-9134-c3724cb0aca1"));
            TabPageTreatmentMaterials = (ITTTabPage)AddControl(new Guid("12881e42-a25c-4fc5-9e84-9533c89ae3f1"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("854ac6f4-94fe-4132-abec-019c6a19433a"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("e28634ed-011f-4be6-a9ba-4ee7bffd48f7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8d90e962-6aab-4316-a3bf-e00c2f682868"));
            Qref = (ITTTextBox)AddControl(new Guid("aefde1f3-8445-4b85-bfe6-a68321414166"));
            ID = (ITTTextBox)AddControl(new Guid("5c9124c8-5827-46da-aadf-926750c30f6e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2fade037-c082-4df1-967c-58190771c95b"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("72e5c0d2-b584-4cb6-9c5f-ed5ee904f7f1"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8b916a37-8b3a-4208-b8f5-69bd2f2af56f"));
            labelQref = (ITTLabel)AddControl(new Guid("108eeab1-7d53-4829-8fae-77455562213a"));
            labelID = (ITTLabel)AddControl(new Guid("77f424db-c8c6-4a91-a28a-e9a5c9d3de61"));
            IsActive = (ITTCheckBox)AddControl(new Guid("90b6ef63-3f68-4f12-bc9a-e980d86155ba"));
            base.InitializeControls();
        }

        public NuclearMedicineTestDefinitionForm() : base("NUCLEARMEDICINETESTDEFINITION", "NuclearMedicineTestDefinitionForm")
        {
        }

        protected NuclearMedicineTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}