
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
    /// Hemodiyaliz Planlama Formu
    /// </summary>
    public partial class HemodialysisPlanForm : EpisodeActionForm
    {
    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
        protected TTObjectClasses.HemodialysisOrder _HemodialysisOrder
        {
            get { return (TTObjectClasses.HemodialysisOrder)_ttObject; }
        }

        protected ITTLabel labelSessionDayRangeType;
        protected ITTCheckBox IsWeekendInclude;
        protected ITTLabel labelDuration;
        protected ITTTextBox Duration;
        protected ITTTextBox IDBaseAction;
        protected ITTTextBox Information;
        protected ITTTextBox SessionDayRange;
        protected ITTTextBox SessionCount;
        protected ITTLabel labelTreatmentEquipment;
        protected ITTObjectListBox TreatmentEquipment;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelIDBaseAction;
        protected ITTLabel labelInformation;
        protected ITTLabel labelPackageProcedure;
        protected ITTObjectListBox PackageProcedure;
        protected ITTLabel labelDialysisFrequency;
        protected ITTObjectListBox DialysisFrequency;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelTreatmentStartDateTime;
        protected ITTDateTimePicker TreatmentStartDateTime;
        protected ITTEnumComboBox SessionDayRangeType;
        protected ITTLabel labelSessionDayRange;
        protected ITTLabel labelSessionCount;
        override protected void InitializeControls()
        {
            labelSessionDayRangeType = (ITTLabel)AddControl(new Guid("56dec13e-f19b-4ad0-a7ad-c8e7d7d5f554"));
            IsWeekendInclude = (ITTCheckBox)AddControl(new Guid("d98b8939-a727-4a4d-94c7-2267dc32f3ee"));
            labelDuration = (ITTLabel)AddControl(new Guid("14ec934e-aa08-4e4f-b2e7-f35e2ab51471"));
            Duration = (ITTTextBox)AddControl(new Guid("e1cfbc6b-a5df-496b-ac7f-73dbdc8652ee"));
            IDBaseAction = (ITTTextBox)AddControl(new Guid("d340df48-86f4-4979-957f-685127404588"));
            Information = (ITTTextBox)AddControl(new Guid("b1adbfc6-e394-4171-b457-59fe5f2d6394"));
            SessionDayRange = (ITTTextBox)AddControl(new Guid("9d619327-87c9-4bd3-92c8-d2d039d6cc52"));
            SessionCount = (ITTTextBox)AddControl(new Guid("7da9775b-88f2-430e-94f2-34ffe6d505f4"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("a8733249-16a7-45ae-acb1-07afaa234582"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("0318d599-152c-4fdf-b3c4-361157278bd8"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("d6bb91cb-b5b4-43d9-8972-1c8cf22d7df3"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("6d81cd28-8a5a-4c28-b4f2-fb5ea35acfd8"));
            labelIDBaseAction = (ITTLabel)AddControl(new Guid("3cc69791-5c6f-4a22-8d46-c5e81546b3ad"));
            labelInformation = (ITTLabel)AddControl(new Guid("43d35e48-0104-458b-9a16-09ba81168384"));
            labelPackageProcedure = (ITTLabel)AddControl(new Guid("23bfd58b-6ddc-4874-af20-d06b67690ef5"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("1337b02c-a1e5-4ccd-a712-9fcc0e34e395"));
            labelDialysisFrequency = (ITTLabel)AddControl(new Guid("97321e49-63dd-4f17-a5b9-e9323877d586"));
            DialysisFrequency = (ITTObjectListBox)AddControl(new Guid("c3c5950c-fd2f-4060-b08f-2cda2f194be8"));
            Emergency = (ITTCheckBox)AddControl(new Guid("c3eda96d-ff1f-4917-a378-e194a622b385"));
            labelTreatmentStartDateTime = (ITTLabel)AddControl(new Guid("eb33bf06-faae-4e62-963d-774843848460"));
            TreatmentStartDateTime = (ITTDateTimePicker)AddControl(new Guid("9acaac07-76bd-4311-b505-357d4c61004b"));
            SessionDayRangeType = (ITTEnumComboBox)AddControl(new Guid("fad5440a-af9e-4d14-ad8a-182cf812cd14"));
            labelSessionDayRange = (ITTLabel)AddControl(new Guid("b48c5eea-76e9-4087-8bb1-68bb9677cf7f"));
            labelSessionCount = (ITTLabel)AddControl(new Guid("fcca3071-e12b-4b1c-b6bf-fd04bf74e7df"));
            base.InitializeControls();
        }

        public HemodialysisPlanForm() : base("HEMODIALYSISORDER", "HemodialysisPlanForm")
        {
        }

        protected HemodialysisPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}