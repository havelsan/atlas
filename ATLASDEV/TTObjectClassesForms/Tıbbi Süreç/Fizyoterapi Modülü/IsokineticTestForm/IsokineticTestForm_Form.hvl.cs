
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
    public partial class IsokineticTestForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Bilgisayarlı İzokinetik Testi
    /// </summary>
        protected TTObjectClasses.IsokineticTestForm _IsokineticTestForm
        {
            get { return (TTObjectClasses.IsokineticTestForm)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelComputerBasedIsokineticTest;
        protected ITTTextBox ComputerBasedIsokineticTest;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("9148cc40-fd17-42a5-a14b-2076745a7608"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("254d4acd-6aed-4a44-b0fd-17b15cd1fc1a"));
            labelComputerBasedIsokineticTest = (ITTLabel)AddControl(new Guid("e6712e2c-a327-4243-b016-95c648f617fa"));
            ComputerBasedIsokineticTest = (ITTTextBox)AddControl(new Guid("3e74a64d-0c00-4f5c-b057-8690fece08f1"));
            Code = (ITTTextBox)AddControl(new Guid("5aef5e96-a2da-434a-847c-96b13900b6f4"));
            labelCode = (ITTLabel)AddControl(new Guid("fb75bcb5-dc36-428c-bc9c-7f6c789c4464"));
            base.InitializeControls();
        }

        public IsokineticTestForm() : base("ISOKINETICTESTFORM", "IsokineticTestForm")
        {
        }

        protected IsokineticTestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}