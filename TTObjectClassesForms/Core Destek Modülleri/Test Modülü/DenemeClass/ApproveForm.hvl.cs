
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
    public partial class Approve : TTForm
    {
        protected TTObjectClasses.DenemeClass _DenemeClass
        {
            get { return (TTObjectClasses.DenemeClass)_ttObject; }
        }

        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTTextBox Name;
        protected ITTLabel labelDate;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelCity = (ITTLabel)AddControl(new Guid("1901f308-c325-4b8b-bfee-cf24a8e08e88"));
            City = (ITTObjectListBox)AddControl(new Guid("b98af3ac-cc14-4c2d-9403-3ffa2399ec1e"));
            labelNote = (ITTLabel)AddControl(new Guid("9ef43609-e289-4dbf-8250-070f13d8e8ca"));
            Note = (ITTTextBox)AddControl(new Guid("15aeb9ca-5a56-4097-8307-47f2dc7aa22b"));
            Name = (ITTTextBox)AddControl(new Guid("ce372162-5083-48b8-94bb-b02922917856"));
            labelDate = (ITTLabel)AddControl(new Guid("2019737a-1ef1-4513-8616-a397b233f699"));
            Date = (ITTDateTimePicker)AddControl(new Guid("ee335375-9323-433d-927b-b7aae7706335"));
            labelName = (ITTLabel)AddControl(new Guid("0c21e3f6-edc8-44a9-b742-75a5316011c0"));
            base.InitializeControls();
        }

        public Approve() : base("DENEMECLASS", "Approve")
        {
        }

        protected Approve(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}