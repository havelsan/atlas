
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
    /// Ambulans Hizmetleri Tanımı
    /// </summary>
    public partial class AmbulanceProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ambulans Hizmetleri Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.AmbulanceProcedureDefinition _AmbulanceProcedureDefinition
        {
            get { return (TTObjectClasses.AmbulanceProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTLabel labelName;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelQref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("19be2620-b473-489c-95f1-353a1cf4da8f"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("bae08e57-0d8d-4e48-b688-7b118b411f22"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("cc0fa48c-7f8f-4814-8b50-ad3de37fe952"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("36f0141e-6641-4cdf-aa37-f2865df8caac"));
            Description = (ITTTextBox)AddControl(new Guid("7b8fc306-0196-40a5-a8f9-ba4a180092d5"));
            Name = (ITTTextBox)AddControl(new Guid("8a44818a-5265-44ea-bb5a-d253efe9639a"));
            Code = (ITTTextBox)AddControl(new Guid("e9a463f2-912e-4a9e-8b5d-b16b35ca3257"));
            ID = (ITTTextBox)AddControl(new Guid("704da850-103f-483b-9c77-7e234d1c41f5"));
            Qref = (ITTTextBox)AddControl(new Guid("87b7567d-c54c-4907-8cb4-198122cb134f"));
            labelName = (ITTLabel)AddControl(new Guid("f1db801f-e0c2-427b-b0e5-2a032b21b411"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("d2d20d0f-66c4-4c43-9f34-987eb4fa04c1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1ab43514-2375-4628-b1f9-2019faa27112"));
            labelDescription = (ITTLabel)AddControl(new Guid("2d8f7272-87c4-4754-8e20-a42fd04538ee"));
            labelQref = (ITTLabel)AddControl(new Guid("6688d37f-45cd-4b18-9f62-eff2616139db"));
            IsActive = (ITTCheckBox)AddControl(new Guid("3c78155a-52db-4a35-9ea2-f1935b39904e"));
            labelCode = (ITTLabel)AddControl(new Guid("79901172-3e16-4f2a-a4e3-a27a697794cc"));
            labelID = (ITTLabel)AddControl(new Guid("ba379ec6-a9df-496b-b94a-f17e3d210adb"));
            base.InitializeControls();
        }

        public AmbulanceProcedureDefinitionForm() : base("AMBULANCEPROCEDUREDEFINITION", "AmbulanceProcedureDefinitionForm")
        {
        }

        protected AmbulanceProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}