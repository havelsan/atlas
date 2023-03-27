
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
    public partial class NursingFunctionalDailyLifeActivityNewForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Hemşire Bakım İzlem Formu
    /// </summary>
        protected TTObjectClasses.NursingDailyLifeActivity _NursingDailyLifeActivity
        {
            get { return (TTObjectClasses.NursingDailyLifeActivity)_ttObject; }
        }

        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelNote;
        protected ITTTextBox tttextbox1;
        protected ITTGrid NursingFunctionalDailyLifeActivity;
        protected ITTCheckBoxColumn Ischeck;
        protected ITTListBoxColumn FunctionalDailyLifeActivity;
        protected ITTTextBoxColumn DetailNote;
        override protected void InitializeControls()
        {
            labelApplicationDate = (ITTLabel)AddControl(new Guid("7123d2ef-6983-4e3a-b499-dc0de4faa414"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("57816f76-22b3-4ad5-af41-827869832a27"));
            labelNote = (ITTLabel)AddControl(new Guid("2b0efa4e-e704-4b5f-90f6-2379b0d0b640"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e8dcca75-31db-40b9-b44b-6b7a6187713b"));
            NursingFunctionalDailyLifeActivity = (ITTGrid)AddControl(new Guid("c7299574-fc6b-4618-b95a-96c7bf6af32f"));
            Ischeck = (ITTCheckBoxColumn)AddControl(new Guid("f1166c4e-d5c4-45c1-a996-db6f973673cf"));
            FunctionalDailyLifeActivity = (ITTListBoxColumn)AddControl(new Guid("b4e5f4d5-f8d8-4b74-9ec4-3daff48dad51"));
            DetailNote = (ITTTextBoxColumn)AddControl(new Guid("20b89a33-1c39-4c86-9da5-ee42ef48fc0f"));
            base.InitializeControls();
        }

        public NursingFunctionalDailyLifeActivityNewForm() : base("NURSINGDAILYLIFEACTIVITY", "NursingFunctionalDailyLifeActivityNewForm")
        {
        }

        protected NursingFunctionalDailyLifeActivityNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}