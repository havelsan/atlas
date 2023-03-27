
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
    /// Kan Bankası Kan Ürünleri Tanım
    /// </summary>
    public partial class BloodBankTestDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kan Bankası Hizmet Tanımı
    /// </summary>
        protected TTObjectClasses.BloodBankTestDefinition _BloodBankTestDefinition
        {
            get { return (TTObjectClasses.BloodBankTestDefinition)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTabControl TabControl;
        protected ITTTabPage TabPageTests;
        protected ITTGrid GridProcedures;
        protected ITTListBoxColumn ColumnSubProcedures;
        protected ITTTabPage TabPageMaterials;
        protected ITTGrid GridMaterials;
        protected ITTListBoxColumn ColumnMaterial;
        protected ITTCheckBox OnlyChargeWithProduct;
        protected ITTTextBox Name;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox IsActive;
        protected ITTTextBox tttextbox7;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelCode;
        protected ITTLabel labelQref;
        protected ITTTextBox barcodetextbox;
        protected ITTLabel ttlabel7;
        protected ITTTextBox Qref;
        protected ITTLabel ttlabel5;
        protected ITTEnumComboBox ttenumcombobox4;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTTextBox tttextbox6;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel10;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelName;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox9;
        protected ITTTextBox Code;
        protected ITTTextBox tttextbox8;
        protected ITTTextBox ID;
        protected ITTEnumComboBox ttenumcombobox3;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("11ab3bf3-77b2-4ac4-918f-ca57b3d4a05e"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("e9323a47-9aa5-405c-bb1e-2723a25f2630"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("99ec7050-fc55-4c4f-8222-3718d772b902"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("084429bb-cb8a-42a8-9600-b2c0d0657e2d"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("873f44a5-d343-47f6-bab5-bb99372a84c2"));
            TabControl = (ITTTabControl)AddControl(new Guid("418a90c5-fe97-4c70-809a-a8995140b9b7"));
            TabPageTests = (ITTTabPage)AddControl(new Guid("283a4303-1f0b-41ca-9f17-ddde252b5485"));
            GridProcedures = (ITTGrid)AddControl(new Guid("ed281d8e-f8a1-47d4-8fbe-ee7dd1a9aae2"));
            ColumnSubProcedures = (ITTListBoxColumn)AddControl(new Guid("a18424b1-fdb9-4368-8f53-d03ab8d082b3"));
            TabPageMaterials = (ITTTabPage)AddControl(new Guid("d930f9de-cff1-4515-91bb-6fd589369bbc"));
            GridMaterials = (ITTGrid)AddControl(new Guid("15238eff-d4c7-4311-a371-33ab9a00dfe7"));
            ColumnMaterial = (ITTListBoxColumn)AddControl(new Guid("21c8e3a6-569b-4de2-96e1-707a4400449f"));
            OnlyChargeWithProduct = (ITTCheckBox)AddControl(new Guid("52ffddf8-43ae-4c6a-a221-3c905f5360e8"));
            Name = (ITTTextBox)AddControl(new Guid("f03e192a-f8d3-4b97-94af-e691456873af"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9b1ac9fc-47a4-4952-b9eb-6a62c4b4692c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9d7bf285-6209-481c-aa24-98e4b3a95295"));
            IsActive = (ITTCheckBox)AddControl(new Guid("519dcf0a-6dbd-43fb-b211-2bba22f9f535"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("f9139c93-c09d-42c8-934b-cd4ddc5f1e6e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("73ee3458-5590-45ec-9ea0-df0ecb49ce77"));
            labelCode = (ITTLabel)AddControl(new Guid("0cb0b91d-5534-4bca-9df0-dd2627a010b9"));
            labelQref = (ITTLabel)AddControl(new Guid("c979b340-8831-4528-a6aa-f70b7181529e"));
            barcodetextbox = (ITTTextBox)AddControl(new Guid("287bf6e9-cf1d-4e0a-8496-e3ffb970acfd"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("089335d4-8d95-4a75-9da1-f5a14140f28a"));
            Qref = (ITTTextBox)AddControl(new Guid("0694de40-6763-426c-903a-0222353bce3f"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("18e73839-a32b-47b0-b515-02f7bd2abf28"));
            ttenumcombobox4 = (ITTEnumComboBox)AddControl(new Guid("29611019-3509-4437-b0e8-1ab18afaf387"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("05a774b3-bbbb-43ae-af4b-1014c18f2d60"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("4742fcb0-af34-4681-a36e-2f991e953568"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("1c3f380a-3f27-4068-93d5-257d8206d28e"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("2833a7bf-b0b8-42a9-bc93-4f1fff60b5d4"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("a82a2b99-20de-4a1e-a2c2-53275d975fb7"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("45e2ad5b-53d6-401b-ae47-3986f1a88423"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6ebe6405-bcf7-45a7-9eed-35fe0accacc0"));
            labelName = (ITTLabel)AddControl(new Guid("1e04f626-3024-48bc-85ac-63e7c6b01022"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("33090a22-a7ff-41ca-ada9-501630cfb6cb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b4095678-b39b-4550-836d-5d01ea0a7e65"));
            tttextbox9 = (ITTTextBox)AddControl(new Guid("e72cfa4c-f8a7-4580-97ab-64566d05ec43"));
            Code = (ITTTextBox)AddControl(new Guid("21778a45-d85a-49a5-8679-54e2dd471832"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("133e7544-0712-4312-b7f3-6780829bac16"));
            ID = (ITTTextBox)AddControl(new Guid("d2b4d11f-5c13-4eb1-9dfa-a130dbc0cc30"));
            ttenumcombobox3 = (ITTEnumComboBox)AddControl(new Guid("fcf03b1f-4d69-49f9-a175-c6874165e6d4"));
            labelID = (ITTLabel)AddControl(new Guid("2e3161ee-b070-490c-9101-b116fb012969"));
            base.InitializeControls();
        }

        public BloodBankTestDefinitionForm() : base("BLOODBANKTESTDEFINITION", "BloodBankTestDefinitionForm")
        {
        }

        protected BloodBankTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}