
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
    /// Hemşire Takip Gözlem
    /// </summary>
    public partial class NursingApplicationNursingProcedureForm : TTForm
    {
        protected TTObjectClasses.NursingApplicationNursingProcedure _NursingApplicationNursingProcedure
        {
            get { return (TTObjectClasses.NursingApplicationNursingProcedure)_ttObject; }
        }

        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelResult;
        protected ITTTextBox Result;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        override protected void InitializeControls()
        {
            labelProcedureObject = (ITTLabel)AddControl(new Guid("413d2932-4b08-43c0-8051-7cc6319ec8fa"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("9c782580-a8df-48f6-9de5-653f3470ca75"));
            labelActionDate = (ITTLabel)AddControl(new Guid("98dc91ff-4827-43dd-83c1-22ca699fc5d4"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("13139216-2fd9-499f-81c1-7fa95ead0b3f"));
            labelResult = (ITTLabel)AddControl(new Guid("70b1b37f-c28b-4312-852f-e4fb8dbe794c"));
            Result = (ITTTextBox)AddControl(new Guid("4461039a-1979-4ca4-a9ee-e936bc2b4383"));
            labelNote = (ITTLabel)AddControl(new Guid("8d1c87ff-1b26-4fc2-bd45-56e6aeaad2d4"));
            Note = (ITTTextBox)AddControl(new Guid("8a9b5a69-387e-41e7-a450-b34a240757d4"));
            base.InitializeControls();
        }

        public NursingApplicationNursingProcedureForm() : base("NURSINGAPPLICATIONNURSINGPROCEDURE", "NursingApplicationNursingProcedureForm")
        {
        }

        protected NursingApplicationNursingProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}