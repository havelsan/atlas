
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
    /// Günlük Gözlem
    /// </summary>
    public partial class NursingDayToDayInvestigationForm : TTForm
    {
        protected TTObjectClasses.NursingDayToDayInvestigation _NursingDayToDayInvestigation
        {
            get { return (TTObjectClasses.NursingDayToDayInvestigation)_ttObject; }
        }

        protected ITTLabel labelVentulatorMods;
        protected ITTTextBox VentulatorMods;
        protected ITTLabel labelVentral;
        protected ITTTextBox Ventral;
        protected ITTLabel labelRrhythmOfPatient;
        protected ITTTextBox RrhythmOfPatient;
        protected ITTLabel labelPlaceHarshnessTimeOfPain;
        protected ITTTextBox PlaceHarshnessTimeOfPain;
        protected ITTLabel labelEdemaTracing;
        protected ITTTextBox EdemaTracing;
        protected ITTLabel labelCrus;
        protected ITTTextBox Crus;
        protected ITTLabel labelBrains;
        protected ITTTextBox Brains;
        protected ITTLabel labelArm;
        protected ITTTextBox Arm;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelVentulatorMods = (ITTLabel)AddControl(new Guid("137f9e5e-cb7a-4d68-b525-fe2797b1bd15"));
            VentulatorMods = (ITTTextBox)AddControl(new Guid("a5fb2c00-b2da-4723-ac9f-62a5401abb53"));
            labelVentral = (ITTLabel)AddControl(new Guid("3d5b5cbf-980b-442e-b363-930a6d9c505c"));
            Ventral = (ITTTextBox)AddControl(new Guid("3fc4c0fe-c333-4a8f-ae94-af43e56b71d6"));
            labelRrhythmOfPatient = (ITTLabel)AddControl(new Guid("89b280a2-fbe4-48ec-8ffe-3bfd05d404c3"));
            RrhythmOfPatient = (ITTTextBox)AddControl(new Guid("12ea1000-73b4-46bd-8f66-277a6cfb40b5"));
            labelPlaceHarshnessTimeOfPain = (ITTLabel)AddControl(new Guid("b853dc56-8f1d-4aa6-a7f6-8d0329863b9c"));
            PlaceHarshnessTimeOfPain = (ITTTextBox)AddControl(new Guid("e5eaa050-2088-4f94-b119-611f1e67c347"));
            labelEdemaTracing = (ITTLabel)AddControl(new Guid("e0deec87-6800-4edc-a504-a8c30c58ffef"));
            EdemaTracing = (ITTTextBox)AddControl(new Guid("0fe4d4de-ed35-4d25-b8c7-ff7c815334c8"));
            labelCrus = (ITTLabel)AddControl(new Guid("d020e7e4-9f9c-4db9-b615-d58b9f6de4fd"));
            Crus = (ITTTextBox)AddControl(new Guid("b556ab6f-9f42-4382-9798-caab7701e76b"));
            labelBrains = (ITTLabel)AddControl(new Guid("dcc74bb5-bc91-4849-8c53-1a8ee97f5c3d"));
            Brains = (ITTTextBox)AddControl(new Guid("e1f76302-6131-4b5f-984d-0d676cc910ea"));
            labelArm = (ITTLabel)AddControl(new Guid("2a78c54f-8441-4ec0-9f80-149d34fe41f2"));
            Arm = (ITTTextBox)AddControl(new Guid("d6bb0e16-14fe-4ba2-ad9c-19cbca7c3b38"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c90b21a6-9886-437c-b656-0c6bfd85c5ff"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a7e60b3e-b135-4e14-adea-f73ba0f9f502"));
            base.InitializeControls();
        }

        public NursingDayToDayInvestigationForm() : base("NURSINGDAYTODAYINVESTIGATION", "NursingDayToDayInvestigationForm")
        {
        }

        protected NursingDayToDayInvestigationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}