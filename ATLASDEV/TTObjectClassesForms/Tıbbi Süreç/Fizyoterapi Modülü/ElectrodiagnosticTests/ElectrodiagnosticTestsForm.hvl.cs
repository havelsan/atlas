
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
    public partial class ElectrodiagnosticTestsForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Elektrodiagnostik Testler
    /// </summary>
        protected TTObjectClasses.ElectrodiagnosticTests _ElectrodiagnosticTests
        {
            get { return (TTObjectClasses.ElectrodiagnosticTests)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelRheobaseAndChronaxie;
        protected ITTTextBox RheobaseAndChronaxie;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("ccdb0d06-bfcb-466a-a71f-0c27d845a311"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("dcba5f9a-6d37-4760-9f95-c5ec7ecc3d9d"));
            labelRheobaseAndChronaxie = (ITTLabel)AddControl(new Guid("cd2e1e8e-0bfa-4dc7-80bb-8b87096a353c"));
            RheobaseAndChronaxie = (ITTTextBox)AddControl(new Guid("681d7599-c692-4a8f-be9d-f02c26bb5439"));
            Code = (ITTTextBox)AddControl(new Guid("f7817928-4b9a-4e20-b6df-f534fc85411f"));
            labelCode = (ITTLabel)AddControl(new Guid("14450695-eace-4ee3-9c9a-b9a28270637f"));
            base.InitializeControls();
        }

        public ElectrodiagnosticTestsForm() : base("ELECTRODIAGNOSTICTESTS", "ElectrodiagnosticTestsForm")
        {
        }

        protected ElectrodiagnosticTestsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}