
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
    /// Hemşirelik Girişimleri/Uygulamaları Tanımı
    /// </summary>
    public partial class NursingProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hemşirelik Girişimleri/Uygulamaları Tanımı
    /// </summary>
        protected TTObjectClasses.NursingProcedureDefinition _NursingProcedureDefinition
        {
            get { return (TTObjectClasses.NursingProcedureDefinition)_ttObject; }
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
        protected ITTCheckBox Chargable;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("eb2e2caa-6574-4318-ac7f-e654e9cdd62c"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("bf43b349-e670-431c-9f39-115a0d1a8d3f"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("174bf2a2-6eb7-49e3-a87e-742e6a2af60e"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("fbce1dfc-bd10-4024-a70b-993a4645e762"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("65c9edd0-0c68-4fca-ab08-85c41f3ee7ab"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("ab2b6b67-0ad8-42a0-b4c0-07b6e62d460e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fb35cdd5-b1d9-419f-b8b7-436fd4baa64d"));
            labelQref = (ITTLabel)AddControl(new Guid("d1c8dfe9-e075-49be-a2c8-42bba3c89141"));
            Qref = (ITTTextBox)AddControl(new Guid("631161be-75e7-4bb1-9b3c-703f4ad19b91"));
            Name = (ITTTextBox)AddControl(new Guid("1804f877-73e2-4994-b98c-bd9d92737fe4"));
            EnglishName = (ITTTextBox)AddControl(new Guid("94a213ed-2461-434a-86ac-90d48bd325e1"));
            Description = (ITTTextBox)AddControl(new Guid("e085189d-37e9-4cdd-818f-b76b71652471"));
            Code = (ITTTextBox)AddControl(new Guid("cafeeffd-3e7f-40ea-bc74-a885d8ec5715"));
            labelName = (ITTLabel)AddControl(new Guid("5131d62f-8ace-49b9-8073-48bdb2b115fd"));
            IsActive = (ITTCheckBox)AddControl(new Guid("e21b7b6f-81df-4b61-aecd-8a3f74d7b28c"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("f12d509e-4a8f-4dde-b56f-0ef6b7d87615"));
            labelDescription = (ITTLabel)AddControl(new Guid("1eaf92d9-4b54-4864-9507-21a0b3e073ae"));
            labelCode = (ITTLabel)AddControl(new Guid("30a35e1f-53da-420f-8938-632bf24dcbdc"));
            Chargable = (ITTCheckBox)AddControl(new Guid("d0f663c6-51b5-443c-ba61-47c1913c8f26"));
            base.InitializeControls();
        }

        public NursingProcedureDefinitionForm() : base("NURSINGPROCEDUREDEFINITION", "NursingProcedureDefinitionForm")
        {
        }

        protected NursingProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}