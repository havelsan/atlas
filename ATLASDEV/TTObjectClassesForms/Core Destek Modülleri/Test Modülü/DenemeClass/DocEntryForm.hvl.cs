
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
    public partial class DocEntry : TTForm
    {
        protected TTObjectClasses.DenemeClass _DenemeClass
        {
            get { return (TTObjectClasses.DenemeClass)_ttObject; }
        }

        protected ITTLabel labelCity;
        protected ITTObjectListBox City;
        protected ITTLabel labelDate;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelCity = (ITTLabel)AddControl(new Guid("ca6625a8-33f5-4ccf-83e9-e231dc30caf4"));
            City = (ITTObjectListBox)AddControl(new Guid("fc6e58f0-08fa-41b0-9201-4970ff0de8e9"));
            labelDate = (ITTLabel)AddControl(new Guid("88ccec25-2f15-4361-839a-712dd26dcb2c"));
            Date = (ITTDateTimePicker)AddControl(new Guid("6d2d1d2e-c003-42e4-90f4-52cfca22776c"));
            labelName = (ITTLabel)AddControl(new Guid("eacee6dc-c36e-4ea3-98d3-1c1bd53462cb"));
            Name = (ITTTextBox)AddControl(new Guid("50351008-b065-4715-b53c-64794c61f6ce"));
            base.InitializeControls();
        }

        public DocEntry() : base("DENEMECLASS", "DocEntry")
        {
        }

        protected DocEntry(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}