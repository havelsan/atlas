
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
    public partial class CommunityHealthTestDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Halk Sağlığı Tetkik Tanım
    /// </summary>
        protected TTObjectClasses.CommunityHealthTestDefinition _CommunityHealthTestDefinition
        {
            get { return (TTObjectClasses.CommunityHealthTestDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelStandartValue;
        protected ITTTextBox StandartValue;
        protected ITTTextBox Weight;
        protected ITTTextBox ScreenOrder;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox TestTime;
        protected ITTTextBox SampleDoseandType;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelWeight;
        protected ITTLabel labelScreenOrder;
        protected ITTLabel labelTestCategory;
        protected ITTObjectListBox TestCategory;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTLabel labelTestTime;
        protected ITTLabel labelSampleDoseandType;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("c57cca8a-72fc-494a-8488-03164f4c74e0"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("21015801-5e6a-4cbb-ad3d-09db0ddc6411"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("ce7874b1-40a9-4690-81f7-5e719c9bd581"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("8c7de17c-bf5f-4c3c-b10e-3d22e967a31f"));
            labelStandartValue = (ITTLabel)AddControl(new Guid("07334509-9a6c-43ba-8ff6-7c5370102e84"));
            StandartValue = (ITTTextBox)AddControl(new Guid("1b4f253b-eee1-4f9f-9786-19ee1f08c326"));
            Weight = (ITTTextBox)AddControl(new Guid("cb276258-ce9b-4b05-bc8a-35658bb17351"));
            ScreenOrder = (ITTTextBox)AddControl(new Guid("81c7759e-9dfe-44e3-9526-b8263db5fed4"));
            Qref = (ITTTextBox)AddControl(new Guid("9fa1325e-9932-4e93-9892-beab831285e1"));
            Name = (ITTTextBox)AddControl(new Guid("a4ee64a7-3232-42a9-8ed3-065708c10f03"));
            EnglishName = (ITTTextBox)AddControl(new Guid("b01d0507-5f8b-457e-bfaf-130032a603d3"));
            Description = (ITTTextBox)AddControl(new Guid("e52dfda5-b2d3-404a-bd59-a244cbac925f"));
            Code = (ITTTextBox)AddControl(new Guid("18337673-87ef-4064-928d-ac4c97e9520d"));
            TestTime = (ITTTextBox)AddControl(new Guid("f884c0aa-ba57-4b99-94ff-9ac3793be6d0"));
            SampleDoseandType = (ITTTextBox)AddControl(new Guid("c48faad2-0d5b-459e-aff3-518ddc778be3"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a1d62c49-dfac-47db-93fd-93949305d354"));
            labelWeight = (ITTLabel)AddControl(new Guid("02143927-609a-4302-bcd0-4f20dcf3cd07"));
            labelScreenOrder = (ITTLabel)AddControl(new Guid("1a52375e-7677-4fcf-b829-26ed86d89dd7"));
            labelTestCategory = (ITTLabel)AddControl(new Guid("370dfbd0-bb40-4ed8-b25b-19e52db17e41"));
            TestCategory = (ITTObjectListBox)AddControl(new Guid("8e014ecd-25cd-4c7f-b5b7-1f6430554bdc"));
            labelQref = (ITTLabel)AddControl(new Guid("f280088d-bc7a-4ab2-be6c-a51a67485919"));
            labelName = (ITTLabel)AddControl(new Guid("61ce8195-eac0-4726-a422-03d7b6d4408f"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("88b728ba-ef37-4543-bc49-b2b5f8be0520"));
            labelDescription = (ITTLabel)AddControl(new Guid("944702fa-edd3-45e0-b24d-f97839fcea5b"));
            labelCode = (ITTLabel)AddControl(new Guid("d1da3dd4-379e-4cf1-8fbb-5a3df2eb8b28"));
            labelTestTime = (ITTLabel)AddControl(new Guid("02b67ce6-50be-43c9-bba6-57b6b42520c5"));
            labelSampleDoseandType = (ITTLabel)AddControl(new Guid("15bc257f-b64b-44ea-af67-1608353bcf96"));
            IsActive = (ITTCheckBox)AddControl(new Guid("bff0141b-51ad-47bc-a8ac-e8600f5e3a99"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("98cb797a-ece4-47ae-84b9-84bfd85beaa2"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("3ee68cbe-d8d9-4042-990d-1c1ab2483d86"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("68d68f89-6f16-41fb-9f81-3ce9a4fa9a02"));
            base.InitializeControls();
        }

        public CommunityHealthTestDefForm() : base("COMMUNITYHEALTHTESTDEFINITION", "CommunityHealthTestDefForm")
        {
        }

        protected CommunityHealthTestDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}