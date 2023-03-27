
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
    public partial class PregnancyResultForm : TTForm
    {
        protected TTObjectClasses.PregnancyResult _PregnancyResult
        {
            get { return (TTObjectClasses.PregnancyResult)_ttObject; }
        }

        protected ITTLabel labelBirthType;
        protected ITTObjectListBox BirthType;
        protected ITTLabel labelBabyStatus;
        protected ITTEnumComboBox BabyStatus;
        protected ITTLabel labelCongenitalAnomalies;
        protected ITTObjectListBox CongenitalAnomalies;
        protected ITTLabel labelBirthResult;
        protected ITTObjectListBox BirthResult;
        protected ITTLabel labelBirthTerminationDatePregnancy;
        protected ITTDateTimePicker BirthTerminationDatePregnancy;
        protected ITTLabel labelGender;
        protected ITTEnumComboBox Gender;
        protected ITTLabel labelCesareanReason;
        protected ITTTextBox CesareanReason;
        protected ITTTextBox BirthWeight;
        protected ITTTextBox BirthDescription;
        protected ITTTextBox AfterBirthStory;
        protected ITTLabel labelBirthWeight;
        protected ITTLabel labelBirthDescription;
        protected ITTLabel labelAfterBirthStory;
        override protected void InitializeControls()
        {
            labelBirthType = (ITTLabel)AddControl(new Guid("ff020e0d-80f7-4a65-afd3-08166082751a"));
            BirthType = (ITTObjectListBox)AddControl(new Guid("a42047f8-d159-428a-b0e0-f7020465828e"));
            labelBabyStatus = (ITTLabel)AddControl(new Guid("45dde226-5a71-4eb1-afd7-4821852063ee"));
            BabyStatus = (ITTEnumComboBox)AddControl(new Guid("9ae90721-43ec-4561-b65e-ee559b40d3fa"));
            labelCongenitalAnomalies = (ITTLabel)AddControl(new Guid("911049d9-f1ed-4d21-a651-2accb7b2a4c2"));
            CongenitalAnomalies = (ITTObjectListBox)AddControl(new Guid("ca85285c-845d-433c-9c30-51b2c920564d"));
            labelBirthResult = (ITTLabel)AddControl(new Guid("455d797a-b739-452e-95aa-917404a3f764"));
            BirthResult = (ITTObjectListBox)AddControl(new Guid("db1154bc-4a69-4074-b345-be54e16b35ec"));
            labelBirthTerminationDatePregnancy = (ITTLabel)AddControl(new Guid("417f0c95-c9ed-47a0-9bb5-67137c93d3d9"));
            BirthTerminationDatePregnancy = (ITTDateTimePicker)AddControl(new Guid("f5747be8-c073-41f1-9fc6-9ac5c748f0ab"));
            labelGender = (ITTLabel)AddControl(new Guid("8f5771f2-d646-4778-a0e7-c1874ff455d9"));
            Gender = (ITTEnumComboBox)AddControl(new Guid("e2079cec-0964-44b0-b7f7-16409ef7f480"));
            labelCesareanReason = (ITTLabel)AddControl(new Guid("15d65fb3-ba06-4c66-b375-d3128e863417"));
            CesareanReason = (ITTTextBox)AddControl(new Guid("adf01e0c-bfe0-471d-bd3b-0ebafba4bbc7"));
            BirthWeight = (ITTTextBox)AddControl(new Guid("56bbff9b-6fba-476a-bec0-e6cf5cf0b205"));
            BirthDescription = (ITTTextBox)AddControl(new Guid("9ba92bfa-ba1c-42a6-9fe5-89d8a9aa996e"));
            AfterBirthStory = (ITTTextBox)AddControl(new Guid("94bacbf3-73f4-4b67-a530-00e59bdbb377"));
            labelBirthWeight = (ITTLabel)AddControl(new Guid("c9e0734a-d043-47c1-8e2a-9d0c783f659f"));
            labelBirthDescription = (ITTLabel)AddControl(new Guid("7f05db06-0e83-4358-85da-1f093e31b136"));
            labelAfterBirthStory = (ITTLabel)AddControl(new Guid("f373a466-3bf5-4dbf-bc3a-a6277fa2c9a3"));
            base.InitializeControls();
        }

        public PregnancyResultForm() : base("PREGNANCYRESULT", "PregnancyResultForm")
        {
        }

        protected PregnancyResultForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}