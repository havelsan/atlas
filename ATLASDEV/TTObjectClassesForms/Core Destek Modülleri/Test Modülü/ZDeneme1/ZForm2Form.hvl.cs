
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
    public partial class ZForm2 : TTForm
    {
        protected TTObjectClasses.ZDeneme1 _ZDeneme1
        {
            get { return (TTObjectClasses.ZDeneme1)_ttObject; }
        }

        protected ITTLabel labelBloodType;
        protected ITTObjectListBox BloodType;
        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelBirthDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelBloodType = (ITTLabel)AddControl(new Guid("a943f82a-23ab-4f2c-a52f-24e96c4c500e"));
            BloodType = (ITTObjectListBox)AddControl(new Guid("9c6f2c60-d502-4e13-bc68-71e26c80d8a7"));
            labelCity = (ITTLabel)AddControl(new Guid("40b74a19-d634-497c-9cef-6483c9789d14"));
            City = (ITTObjectListBox)AddControl(new Guid("644dea23-7103-49ea-9f8c-b6b551570dd0"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("4e77019d-cc4f-4184-9dbc-e15d1e2f6f74"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("a7adc882-4237-4ab0-9564-860922720edb"));
            labelName = (ITTLabel)AddControl(new Guid("9a3abc3c-dae0-4b8c-a7b6-0830b7bd88b1"));
            Name = (ITTTextBox)AddControl(new Guid("7b9c6db4-efba-49e4-aece-72e10a0c5d89"));
            base.InitializeControls();
        }

        public ZForm2() : base("ZDENEME1", "ZForm2")
        {
        }

        protected ZForm2(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}