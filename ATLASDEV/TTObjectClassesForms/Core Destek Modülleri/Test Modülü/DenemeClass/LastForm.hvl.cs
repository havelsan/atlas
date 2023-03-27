
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
    /// Evrak
    /// </summary>
    public partial class LastForm : TTForm
    {
        protected TTObjectClasses.DenemeClass _DenemeClass
        {
            get { return (TTObjectClasses.DenemeClass)_ttObject; }
        }

        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelNo;
        protected ITTTextBox No;
        protected ITTTextBox Note;
        protected ITTTextBox Name;
        protected ITTLabel labelNote;
        protected ITTLabel labelDate;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelCity = (ITTLabel)AddControl(new Guid("0efefe7a-909d-4b7a-afa7-c247bcbd8942"));
            City = (ITTObjectListBox)AddControl(new Guid("7cb18118-24cc-4bcf-8ddf-9ebd3ec8b5f7"));
            labelNo = (ITTLabel)AddControl(new Guid("cdeae454-4896-40ea-8072-223d4e872dcc"));
            No = (ITTTextBox)AddControl(new Guid("23308a7c-df64-4435-8f2e-7ca9a0707eba"));
            Note = (ITTTextBox)AddControl(new Guid("5dad3e93-1d78-4773-9c1c-70b11ed2fe87"));
            Name = (ITTTextBox)AddControl(new Guid("ca97477f-3b0f-44e4-bfae-ad1813fa3998"));
            labelNote = (ITTLabel)AddControl(new Guid("1f8f71fb-8e2d-4d94-ab13-333097c9dae8"));
            labelDate = (ITTLabel)AddControl(new Guid("29af4d20-07b5-46bf-886d-b2c0281b2f58"));
            Date = (ITTDateTimePicker)AddControl(new Guid("3f903191-1d44-4f2d-b2fc-f360d21d0cb3"));
            labelName = (ITTLabel)AddControl(new Guid("8e6b3478-1e1a-45ec-9236-e941cad4a22d"));
            base.InitializeControls();
        }

        public LastForm() : base("DENEMECLASS", "LastForm")
        {
        }

        protected LastForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}