
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
    public partial class PhysiotherapyTreatmentNoteForm : TTForm
    {
    /// <summary>
    /// FTR Tedavi Notu/Açıklamaları
    /// </summary>
        protected TTObjectClasses.PhysiotherapyTreatmentNote _PhysiotherapyTreatmentNote
        {
            get { return (TTObjectClasses.PhysiotherapyTreatmentNote)_ttObject; }
        }

        protected ITTLabel labelEntryUser;
        protected ITTObjectListBox EntryUser;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl Description;
        override protected void InitializeControls()
        {
            labelEntryUser = (ITTLabel)AddControl(new Guid("73907b32-5e14-483c-9b52-c223ed7b334d"));
            EntryUser = (ITTObjectListBox)AddControl(new Guid("6b662c65-265c-4153-9dc5-2b6fea552fe8"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("db5dd0d4-3992-4193-9088-325ef99cd233"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("af2f1690-c641-4d53-abb1-38e81c55a509"));
            labelDescription = (ITTLabel)AddControl(new Guid("8f1e92cc-1313-439d-8738-3e1de96509b6"));
            Description = (ITTRichTextBoxControl)AddControl(new Guid("a57d73a9-c552-4989-a90d-0355d3154961"));
            base.InitializeControls();
        }

        public PhysiotherapyTreatmentNoteForm() : base("PHYSIOTHERAPYTREATMENTNOTE", "PhysiotherapyTreatmentNoteForm")
        {
        }

        protected PhysiotherapyTreatmentNoteForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}