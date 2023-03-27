
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
    public partial class WeightChartForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.WeightChart _WeightChart
        {
            get { return (TTObjectClasses.WeightChart)_ttObject; }
        }

        protected ITTLabel labelRequesterPerson;
        protected ITTObjectListBox RequesterPerson;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelWeight;
        protected ITTTextBox Weight;
        protected ITTTextBox MeasuringPerson;
        protected ITTTextBox Length;
        protected ITTTextBox HeadCircumference;
        protected ITTLabel labelMeasuringPerson;
        protected ITTLabel labelLength;
        protected ITTLabel labelHeadCircumference;
        override protected void InitializeControls()
        {
            labelRequesterPerson = (ITTLabel)AddControl(new Guid("78893a2d-68c3-4eb7-9f3d-d4fcfe9d0016"));
            RequesterPerson = (ITTObjectListBox)AddControl(new Guid("8387bdf9-1f0f-4d9e-b479-4dc08fb17fb8"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("99578ade-36b5-48a0-bf93-eec3bcc4db82"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("82dc9154-be93-43c0-b49b-add3c39c8e99"));
            labelWeight = (ITTLabel)AddControl(new Guid("6e960adb-b963-415b-ac6a-fd90e4bf299c"));
            Weight = (ITTTextBox)AddControl(new Guid("6fc1d96e-d6bd-4328-a6cc-73322cc1dc9c"));
            MeasuringPerson = (ITTTextBox)AddControl(new Guid("0830ce8b-b21f-4bdd-9e34-9fd33c74e4cc"));
            Length = (ITTTextBox)AddControl(new Guid("cc1a6a65-eb2a-424d-a623-543065521aa2"));
            HeadCircumference = (ITTTextBox)AddControl(new Guid("75b64fcc-b30e-4c2e-bf25-5b4ed45e35fe"));
            labelMeasuringPerson = (ITTLabel)AddControl(new Guid("5f1eb8cc-29da-4d2f-bc8e-6875ba161b0b"));
            labelLength = (ITTLabel)AddControl(new Guid("d38c3a84-86d9-4af6-852d-9fb15ea1cbf9"));
            labelHeadCircumference = (ITTLabel)AddControl(new Guid("749e5a96-28d6-4721-896e-43b1f1543ebb"));
            base.InitializeControls();
        }

        public WeightChartForm() : base("WEIGHTCHART", "WeightChartForm")
        {
        }

        protected WeightChartForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}