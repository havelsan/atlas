
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
    /// Anestezi Tanımlama Modülü
    /// </summary>
    public partial class AnesthesiaDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Anestezi Tanımlama
    /// </summary>
        protected TTObjectClasses.AnesthesiaDefinition _AnesthesiaDefinition
        {
            get { return (TTObjectClasses.AnesthesiaDefinition)_ttObject; }
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
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("92f0e1f9-9eea-4c71-9cb9-20e39efb6888"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("4189cb75-c8d7-4764-a77f-efbf69817bb5"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("77b7eaed-fd67-42b7-a36d-d98f32a53beb"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("68ac3f33-830d-480c-b432-08c6c47971b0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("27ed2bf0-4417-4022-9b5c-27343398ed79"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("7fd5ad78-a1fb-4fb9-b7ff-6b99a278eec3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("60af486e-e724-4b64-a179-fb9a548deda6"));
            labelQref = (ITTLabel)AddControl(new Guid("c42b2e74-f1a6-454f-af96-648b63d71e6e"));
            Qref = (ITTTextBox)AddControl(new Guid("66e2fe4d-fc97-4734-aff6-90da5a46be43"));
            Name = (ITTTextBox)AddControl(new Guid("c997e581-4b51-4411-aff5-bdb4ee55fd89"));
            EnglishName = (ITTTextBox)AddControl(new Guid("4f5498c3-2c88-49cb-b5eb-4e199103e124"));
            Description = (ITTTextBox)AddControl(new Guid("931cfb1e-b5d1-43b8-8406-fd93148e368c"));
            Code = (ITTTextBox)AddControl(new Guid("8bea3683-d5f9-4db1-8a0c-43d822e6d0d1"));
            labelName = (ITTLabel)AddControl(new Guid("318fd110-8c15-4469-b251-af6e58722da7"));
            IsActive = (ITTCheckBox)AddControl(new Guid("231c5476-555c-4213-9922-6fef8ad8a71a"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("30ac1145-5e3a-4231-abae-822a5d6ff89e"));
            labelDescription = (ITTLabel)AddControl(new Guid("23e5a5e4-9379-457c-b4e7-fbbf483f322f"));
            labelCode = (ITTLabel)AddControl(new Guid("a78be06a-ed20-453b-bf2b-f004361137ea"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("751a3177-dbf2-4ef7-9a97-76272fcb1573"));
            base.InitializeControls();
        }

        public AnesthesiaDefinitionForm() : base("ANESTHESIADEFINITION", "AnesthesiaDefinitionForm")
        {
        }

        protected AnesthesiaDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}