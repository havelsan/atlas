
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
    public partial class ConvTestForm2 : TTForm
    {
    /// <summary>
    /// ConvTest Kılası
    /// </summary>
        protected TTObjectClasses.ConvTest _ConvTest
        {
            get { return (TTObjectClasses.ConvTest)_ttObject; }
        }

        protected ITTTextBox Telephone;
        protected ITTTextBox No;
        protected ITTDateTimePicker deyt;
        protected ITTCheckBox cekbaks;
        protected ITTButton ttbutton1;
        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelTelephone;
        protected ITTLabel labelNo;
        override protected void InitializeControls()
        {
            Telephone = (ITTTextBox)AddControl(new Guid("8cfcdd28-b0b9-4565-a13e-4f398be63f69"));
            No = (ITTTextBox)AddControl(new Guid("47681025-ed04-40d4-a629-4605391a7b76"));
            deyt = (ITTDateTimePicker)AddControl(new Guid("954529ca-997c-48e4-b319-93131f3c25af"));
            cekbaks = (ITTCheckBox)AddControl(new Guid("16e43a34-a7c9-4754-a940-5137eb141fb8"));
            ttbutton1 = (ITTButton)AddControl(new Guid("6447a0ed-bc1a-4b10-adc6-1d882bee1365"));
            labelCity = (ITTLabel)AddControl(new Guid("4ac86e5c-c4f7-4470-9e4f-636fa288357a"));
            City = (ITTObjectListBox)AddControl(new Guid("89614cf7-afec-4425-9aca-73c142be7533"));
            labelTelephone = (ITTLabel)AddControl(new Guid("5703219a-3e9c-471f-8424-bd236ffd0e59"));
            labelNo = (ITTLabel)AddControl(new Guid("b3b01255-5b22-40ed-a31a-d461d6063bf7"));
            base.InitializeControls();
        }

        public ConvTestForm2() : base("CONVTEST", "ConvTestForm2")
        {
        }

        protected ConvTestForm2(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}