
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
    public partial class NursingSpiritualEvaluationForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Ruhsal Değerlendirme
    /// </summary>
        protected TTObjectClasses.NursingSpiritualEvaluation _NursingSpiritualEvaluation
        {
            get { return (TTObjectClasses.NursingSpiritualEvaluation)_ttObject; }
        }

        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelExplanation;
        protected ITTTextBox Explanation;
        protected ITTCheckBox Other;
        protected ITTCheckBox Indifferent;
        protected ITTCheckBox Nervous;
        protected ITTCheckBox Sad;
        protected ITTCheckBox Furious;
        protected ITTCheckBox Normal;
        override protected void InitializeControls()
        {
            labelApplicationDate = (ITTLabel)AddControl(new Guid("99eddf68-41dd-4544-95ef-1e8b9265dd5c"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("ce6c7ed8-6607-4674-9cd1-523efe9cb384"));
            labelExplanation = (ITTLabel)AddControl(new Guid("a215e3d1-7ec6-43c7-96ad-2a723c12c330"));
            Explanation = (ITTTextBox)AddControl(new Guid("74dba7ed-55e9-4238-8ad8-e2716764d981"));
            Other = (ITTCheckBox)AddControl(new Guid("8f64b0e9-6859-4b24-a6ea-f0a2d7acda8f"));
            Indifferent = (ITTCheckBox)AddControl(new Guid("b41edc9d-b9cd-4fe5-b026-68588a82cdff"));
            Nervous = (ITTCheckBox)AddControl(new Guid("91e5b06c-9eef-4561-9536-83672cafad5c"));
            Sad = (ITTCheckBox)AddControl(new Guid("7a5fe62d-720b-48fe-9490-c77ffb18c970"));
            Furious = (ITTCheckBox)AddControl(new Guid("1bd80b62-581b-4ae5-95fa-e5884a182caa"));
            Normal = (ITTCheckBox)AddControl(new Guid("baa0f306-8f57-45f8-a815-0233f866fe7a"));
            base.InitializeControls();
        }

        public NursingSpiritualEvaluationForm() : base("NURSINGSPIRITUALEVALUATION", "NursingSpiritualEvaluationForm")
        {
        }

        protected NursingSpiritualEvaluationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}