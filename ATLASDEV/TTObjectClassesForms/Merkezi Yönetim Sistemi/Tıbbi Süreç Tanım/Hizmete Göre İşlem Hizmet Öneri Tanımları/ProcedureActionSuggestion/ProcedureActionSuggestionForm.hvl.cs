
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
    public partial class ProcedureActionSuggestionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ProcedureActionSuggestion _ProcedureActionSuggestion
        {
            get { return (TTObjectClasses.ProcedureActionSuggestion)_ttObject; }
        }

        protected ITTGrid SuggestionCases;
        protected ITTListBoxColumn ProcedureDefinitionSuggestionCase;
        protected ITTTextBoxColumn MinResultSuggestionCase;
        protected ITTTextBoxColumn MaxResultSuggestionCase;
        protected ITTLabel labelMessage;
        protected ITTTextBox Message;
        protected ITTLabel labelSuggestedMasterResource;
        protected ITTObjectListBox SuggestedMasterResource;
        protected ITTLabel labelSuggestedProcedureDefinition;
        protected ITTObjectListBox SuggestedProcedureDefinition;
        protected ITTLabel labelActionType;
        protected ITTEnumComboBox ActionType;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            SuggestionCases = (ITTGrid)AddControl(new Guid("bd3ccd62-913b-4b03-8437-78a33d85c967"));
            ProcedureDefinitionSuggestionCase = (ITTListBoxColumn)AddControl(new Guid("6cfa535b-dbeb-4661-ab67-a93ac6cdeb57"));
            MinResultSuggestionCase = (ITTTextBoxColumn)AddControl(new Guid("a0848712-178b-4d5b-a04f-7d642d75cec9"));
            MaxResultSuggestionCase = (ITTTextBoxColumn)AddControl(new Guid("e32ea6a8-61aa-4262-8e52-a90e69ba2894"));
            labelMessage = (ITTLabel)AddControl(new Guid("d7a49528-aa57-4be4-b474-722a23969616"));
            Message = (ITTTextBox)AddControl(new Guid("2a1daf65-88ee-4b7d-90e8-b5b128a3362b"));
            labelSuggestedMasterResource = (ITTLabel)AddControl(new Guid("cf90bc2f-b794-40f9-ae5c-2b29cd1f7d19"));
            SuggestedMasterResource = (ITTObjectListBox)AddControl(new Guid("31ecff47-5c0f-402e-b537-3320d7dc092b"));
            labelSuggestedProcedureDefinition = (ITTLabel)AddControl(new Guid("f1ae4304-7755-4f4e-9736-9ec34b3942ed"));
            SuggestedProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("1c8720c1-3628-478a-bb4d-8aaa7e64ed9e"));
            labelActionType = (ITTLabel)AddControl(new Guid("ac243c8e-3bc1-4181-83dd-c7975d035e8c"));
            ActionType = (ITTEnumComboBox)AddControl(new Guid("0ab06311-bf7f-4fd7-9142-f2a265045a88"));
            IsActive = (ITTCheckBox)AddControl(new Guid("070c2d34-c97c-484f-ac1c-02a1178e4377"));
            base.InitializeControls();
        }

        public ProcedureActionSuggestionForm() : base("PROCEDUREACTIONSUGGESTION", "ProcedureActionSuggestionForm")
        {
        }

        protected ProcedureActionSuggestionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}