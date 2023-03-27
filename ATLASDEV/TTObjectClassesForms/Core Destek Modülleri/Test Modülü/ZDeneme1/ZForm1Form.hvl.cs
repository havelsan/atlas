
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
    public partial class ZForm1 : TTForm
    {
        protected TTObjectClasses.ZDeneme1 _ZDeneme1
        {
            get { return (TTObjectClasses.ZDeneme1)_ttObject; }
        }

        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelBirthDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelCity = (ITTLabel)AddControl(new Guid("4ce4e62b-304c-4461-b4b6-f31d549b54d3"));
            City = (ITTObjectListBox)AddControl(new Guid("5f93baa7-c98e-4cbc-ac14-e9573de6df64"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("538b01a8-41ce-483f-9b89-ffb379bb85ca"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("0bd9ad33-401f-4ef8-b067-8ac3215ab6c3"));
            labelName = (ITTLabel)AddControl(new Guid("d35c430b-60fd-4c76-b771-af76d3560ac3"));
            Name = (ITTTextBox)AddControl(new Guid("e2ff9ae3-4a14-4e32-8f9a-7d9610508d50"));
            base.InitializeControls();
        }

        public ZForm1() : base("ZDENEME1", "ZForm1")
        {
        }

        protected ZForm1(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}