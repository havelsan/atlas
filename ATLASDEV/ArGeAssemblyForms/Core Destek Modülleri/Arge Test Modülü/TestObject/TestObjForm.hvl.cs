
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
    public partial class TestObjForm : TTForm
    {
    /// <summary>
    /// .
    /// </summary>
        protected TTObjectClasses.TestObject _TestObject
        {
            get { return (TTObjectClasses.TestObject)_ttObject; }
        }

        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelTelefon;
        protected ITTTextBox Telefon;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelCity = (ITTLabel)AddControl(new Guid("cc0dca50-d296-4135-937f-c654ea6f13c0"));
            City = (ITTObjectListBox)AddControl(new Guid("1c4948d0-0c79-4c3d-965c-f6b019ee3b90"));
            labelTelefon = (ITTLabel)AddControl(new Guid("3c72f20b-3f15-4815-b40e-d7320eed6b5d"));
            Telefon = (ITTTextBox)AddControl(new Guid("fa4d4b99-63f3-4b6e-bef0-cbfd39954445"));
            Name = (ITTTextBox)AddControl(new Guid("4b9bd782-162e-443e-8645-259068dcb066"));
            labelName = (ITTLabel)AddControl(new Guid("5d251bf6-68be-4b68-b5d0-89a740bc8dec"));
            base.InitializeControls();
        }

        public TestObjForm() : base("TESTOBJECT", "TestObjForm")
        {
        }

        protected TestObjForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}