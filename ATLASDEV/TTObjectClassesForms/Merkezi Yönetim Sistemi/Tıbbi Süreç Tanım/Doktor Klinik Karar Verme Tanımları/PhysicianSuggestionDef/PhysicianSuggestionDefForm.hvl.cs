
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
    public partial class PhysicianSuggestionDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Doktor Klinik Karar Verme Tanımları
    /// </summary>
        protected TTObjectClasses.PhysicianSuggestionDef _PhysicianSuggestionDef
        {
            get { return (TTObjectClasses.PhysicianSuggestionDef)_ttObject; }
        }

        protected ITTLabel labelMessage;
        protected ITTTextBox Message;
        protected ITTTextBox ReturnValueOfParent;
        protected ITTTextBox ReturnValues;
        protected ITTTextBox ButtonCaptions;
        protected ITTTextBox GrupName;
        protected ITTLabel labelDiagnosisDefinition;
        protected ITTObjectListBox DiagnosisDefinition;
        protected ITTLabel labelProcedureDefinition;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTLabel labelParentPhysicianSuggestionDef;
        protected ITTObjectListBox ParentPhysicianSuggestionDef;
        protected ITTLabel labelReturnValueOfParent;
        protected ITTLabel labelReturnValues;
        protected ITTLabel labelButtonCaptions;
        protected ITTLabel labelGrupName;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelMessage = (ITTLabel)AddControl(new Guid("ca7693d1-7eef-4c61-9a34-77b1d3ab62c5"));
            Message = (ITTTextBox)AddControl(new Guid("04222ec5-aa19-49b2-a164-c31a2e7b3567"));
            ReturnValueOfParent = (ITTTextBox)AddControl(new Guid("5fb657fd-3b2d-489c-abbf-bfe4b1c3a482"));
            ReturnValues = (ITTTextBox)AddControl(new Guid("8e28bfb9-077e-428d-9c1b-a6c3813113f7"));
            ButtonCaptions = (ITTTextBox)AddControl(new Guid("8f400f31-11f4-47dc-a61a-f22a3f15ca4c"));
            GrupName = (ITTTextBox)AddControl(new Guid("9c9fd59e-082f-4d59-b090-eca66e382a9c"));
            labelDiagnosisDefinition = (ITTLabel)AddControl(new Guid("ca0bc68a-7bfc-4d81-9242-15be67beb836"));
            DiagnosisDefinition = (ITTObjectListBox)AddControl(new Guid("e809c3c0-becd-4a86-94e2-0026a749fdde"));
            labelProcedureDefinition = (ITTLabel)AddControl(new Guid("14d80b95-73cc-4dd4-9db0-6a4515a49e2b"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("8b309b13-1dc8-40d0-b4dd-24ffebaa3563"));
            labelParentPhysicianSuggestionDef = (ITTLabel)AddControl(new Guid("42c642f7-395b-47b6-aadf-2523f3fa7270"));
            ParentPhysicianSuggestionDef = (ITTObjectListBox)AddControl(new Guid("8348be38-77b9-4855-8989-59a12833dcad"));
            labelReturnValueOfParent = (ITTLabel)AddControl(new Guid("35668d78-dd46-49e1-8ed6-d566650f66c0"));
            labelReturnValues = (ITTLabel)AddControl(new Guid("278baa91-08cc-497c-aa8b-234d93159bbc"));
            labelButtonCaptions = (ITTLabel)AddControl(new Guid("192f17d6-231d-4876-bc13-f73715136809"));
            labelGrupName = (ITTLabel)AddControl(new Guid("20375234-781f-4d69-a081-d62b32c9c5ba"));
            IsActive = (ITTCheckBox)AddControl(new Guid("8136e511-5b32-4759-a8d7-b2abf4552e02"));
            base.InitializeControls();
        }

        public PhysicianSuggestionDefForm() : base("PHYSICIANSUGGESTIONDEF", "PhysicianSuggestionDefForm")
        {
        }

        protected PhysicianSuggestionDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}