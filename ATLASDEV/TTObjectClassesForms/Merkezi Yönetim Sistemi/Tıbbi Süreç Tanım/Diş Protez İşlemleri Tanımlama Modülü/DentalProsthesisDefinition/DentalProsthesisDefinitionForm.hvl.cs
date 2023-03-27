
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
    /// Diş Protez İşlemleri Tanımlama
    /// </summary>
    public partial class DentalProsthesisDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diş Protez İşlemleri Tanımlama
    /// </summary>
        protected TTObjectClasses.DentalProsthesisDefinition _DentalProsthesisDefinition
        {
            get { return (TTObjectClasses.DentalProsthesisDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTGrid Departments;
        protected ITTListBoxColumn DentalProsthesisDefinition0;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("65075b5d-f261-4f5c-a19b-7ab5423930bc"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("417a4ae8-90b5-484b-8257-5fe34da45647"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("9d77f905-08a6-49a2-a03b-2300dd78c54d"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("9a9b83f9-506e-4a5c-9b06-77b114da2c0f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("355b4e15-cd04-4ad1-b444-ec055ad92d5b"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("308d7a9d-9ec5-474a-921d-fda52fca8fe3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c5bc24e4-b081-4910-b64a-6729582c02b3"));
            labelQref = (ITTLabel)AddControl(new Guid("eb2ca2a9-f02a-41e8-ba26-0cde0bafb790"));
            Qref = (ITTTextBox)AddControl(new Guid("8b4092f7-c76f-4976-a47b-b3f606f7346f"));
            Name = (ITTTextBox)AddControl(new Guid("061b5062-8630-4d21-aebf-0ff6af9099d1"));
            EnglishName = (ITTTextBox)AddControl(new Guid("62b00acc-1f99-418f-8f5c-d62029675ccb"));
            Description = (ITTTextBox)AddControl(new Guid("881155af-ed3b-41a5-a88e-51568cad0fdd"));
            Code = (ITTTextBox)AddControl(new Guid("e07fb26c-9d50-4641-b9c6-6c2a611e7417"));
            labelName = (ITTLabel)AddControl(new Guid("d3cdadfb-f96a-4ba2-89ef-ce5ab0361b36"));
            IsActive = (ITTCheckBox)AddControl(new Guid("546ea782-cf2f-4ead-b9a6-75b84a3d5431"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("c20137ca-d967-40ed-a244-3cfaf951bdce"));
            labelDescription = (ITTLabel)AddControl(new Guid("417c095b-40ab-46db-9255-ab2c80901a91"));
            labelCode = (ITTLabel)AddControl(new Guid("b82c3d95-746d-4571-a67c-cb5d35d4a203"));
            Departments = (ITTGrid)AddControl(new Guid("dc776f2f-540d-49b5-8921-7cc09d9b20b7"));
            DentalProsthesisDefinition0 = (ITTListBoxColumn)AddControl(new Guid("2dd45fd7-7fdf-4883-93af-4f8b9e2a164f"));
            base.InitializeControls();
        }

        public DentalProsthesisDefinitionForm() : base("DENTALPROSTHESISDEFINITION", "DentalProsthesisDefinitionForm")
        {
        }

        protected DentalProsthesisDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}