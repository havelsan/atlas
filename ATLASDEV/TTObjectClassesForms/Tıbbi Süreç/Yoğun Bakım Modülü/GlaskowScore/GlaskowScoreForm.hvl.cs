
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
    /// Glaskow Koma Skalası
    /// </summary>
    public partial class GlaskowScoreForm : TTForm
    {
    /// <summary>
    /// Glaskow Skorlama
    /// </summary>
        protected TTObjectClasses.GlaskowScore _GlaskowScore
        {
            get { return (TTObjectClasses.GlaskowScore)_ttObject; }
        }

        protected ITTLabel labelTotalScore;
        protected ITTLabel labelTotal;
        protected ITTTextBox Total;
        protected ITTLabel labelOralAnswer;
        protected ITTObjectListBox OralAnswer;
        protected ITTLabel labelMotorAnswer;
        protected ITTObjectListBox MotorAnswer;
        protected ITTLabel labelEyes;
        protected ITTObjectListBox Eyes;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTEnumComboBox TotalScore;
        override protected void InitializeControls()
        {
            labelTotalScore = (ITTLabel)AddControl(new Guid("2da6cdb3-c826-4514-8e31-3a7351d8eeec"));
            labelTotal = (ITTLabel)AddControl(new Guid("6796c36a-fdbd-43ff-8b97-7b61fc062444"));
            Total = (ITTTextBox)AddControl(new Guid("59775bf8-14bb-409c-b860-fecfd1d1d6fb"));
            labelOralAnswer = (ITTLabel)AddControl(new Guid("25cf003b-78d3-4b56-bedb-c6ac8f87aef4"));
            OralAnswer = (ITTObjectListBox)AddControl(new Guid("d28c47ca-57bc-4bc9-bc3d-0aef405d3608"));
            labelMotorAnswer = (ITTLabel)AddControl(new Guid("12e1651b-c2f7-4d6e-9d80-9e642634232d"));
            MotorAnswer = (ITTObjectListBox)AddControl(new Guid("07a0b09d-5e65-4181-8ef5-0ac5febee1fd"));
            labelEyes = (ITTLabel)AddControl(new Guid("10016984-2b75-4a6f-9b0e-34965a60ccd2"));
            Eyes = (ITTObjectListBox)AddControl(new Guid("deb5c478-518a-41e6-8dec-6bee75010bd7"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("a8bca6e1-e228-4d5f-aaa5-eaabdcbaef6d"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("7266afb7-eb97-4a44-a7fb-357e576ebb5f"));
            TotalScore = (ITTEnumComboBox)AddControl(new Guid("f7121004-9c67-4e2c-8208-11b3bec34a43"));
            base.InitializeControls();
        }

        public GlaskowScoreForm() : base("GLASKOWSCORE", "GlaskowScoreForm")
        {
        }

        protected GlaskowScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}