
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
    public partial class DiagnosisActionSuggestionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Tanıya Göre Hizmet Öneri Tanımları
    /// </summary>
        protected TTObjectClasses.DiagnosisActionSuggestion _DiagnosisActionSuggestion
        {
            get { return (TTObjectClasses.DiagnosisActionSuggestion)_ttObject; }
        }

        protected ITTLabel labelProcedureDefinition;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTLabel labelDiagnosisDefinition;
        protected ITTObjectListBox DiagnosisDefinition;
        protected ITTLabel labelActionType;
        protected ITTEnumComboBox ActionType;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelProcedureDefinition = (ITTLabel)AddControl(new Guid("ad0eb369-2ffc-4bf1-875a-c67f04a72e37"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("c647f537-8d0f-4a0a-b810-8fc239db9ae6"));
            labelDiagnosisDefinition = (ITTLabel)AddControl(new Guid("694c774e-8392-4cdd-bb38-931a5c8c9ed1"));
            DiagnosisDefinition = (ITTObjectListBox)AddControl(new Guid("bac5d403-42af-4296-b7ce-63e3a5acf842"));
            labelActionType = (ITTLabel)AddControl(new Guid("08074c49-ed03-4c77-a6b7-6a5b84370814"));
            ActionType = (ITTEnumComboBox)AddControl(new Guid("3d2347da-0b26-49c5-bd93-edd59a4d4f31"));
            IsActive = (ITTCheckBox)AddControl(new Guid("454353f5-be3e-4cc5-879d-a69a3dd6dc57"));
            base.InitializeControls();
        }

        public DiagnosisActionSuggestionForm() : base("DIAGNOSISACTIONSUGGESTION", "DiagnosisActionSuggestionForm")
        {
        }

        protected DiagnosisActionSuggestionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}