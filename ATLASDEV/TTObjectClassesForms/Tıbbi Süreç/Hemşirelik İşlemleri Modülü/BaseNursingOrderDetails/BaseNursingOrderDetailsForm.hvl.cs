
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
    public partial class BaseNursingOrderDetailsForm : TTForm
    {
    /// <summary>
    /// Vital tipleri olmayan Hemşire Orderlarının uygulanması sırasında kullanılacak Form
    /// </summary>
        protected TTObjectClasses.BaseNursingOrderDetails _BaseNursingOrderDetails
        {
            get { return (TTObjectClasses.BaseNursingOrderDetails)_ttObject; }
        }

        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelExecutionDate;
        protected ITTLabel labelResult;
        protected ITTTextBox Result;
        protected ITTTextBox Note;
        protected ITTLabel lableSonucCombo;
        protected ITTObjectListBox ResultBySelection;
        protected ITTDateTimePicker ExecutionDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelNote;
        override protected void InitializeControls()
        {
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("b49ad947-72c8-4093-805c-e00d1fccbfdd"));
            labelExecutionDate = (ITTLabel)AddControl(new Guid("1dd0cdb7-4a28-4865-b283-2b0b1965982d"));
            labelResult = (ITTLabel)AddControl(new Guid("b14be8a1-7067-49c6-97a3-9c9930b6c481"));
            Result = (ITTTextBox)AddControl(new Guid("eda8bd1a-f161-4bb3-9729-69505e67b3df"));
            Note = (ITTTextBox)AddControl(new Guid("5cf86a3e-ff88-40f1-aaa8-247d5cd94b39"));
            lableSonucCombo = (ITTLabel)AddControl(new Guid("7497d044-8d64-43e4-a6e8-cd43b27fec03"));
            ResultBySelection = (ITTObjectListBox)AddControl(new Guid("54a8d022-c40e-4347-a1d2-7392df241f9f"));
            ExecutionDate = (ITTDateTimePicker)AddControl(new Guid("15878afc-0d98-472b-985c-4256bd8e87d1"));
            labelProcedure = (ITTLabel)AddControl(new Guid("8b4f6a2e-65d1-45a3-9b86-ebbb10820e55"));
            labelNote = (ITTLabel)AddControl(new Guid("03602cf1-04dd-4257-833f-0d8c3136d600"));
            base.InitializeControls();
        }

        public BaseNursingOrderDetailsForm() : base("BASENURSINGORDERDETAILS", "BaseNursingOrderDetailsForm")
        {
        }

        protected BaseNursingOrderDetailsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}