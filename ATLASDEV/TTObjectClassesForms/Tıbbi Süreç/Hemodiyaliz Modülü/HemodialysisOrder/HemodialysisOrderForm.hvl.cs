
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
    /// Diyaliz Emri Formu
    /// </summary>
    public partial class HemodialysisOrderForm : EpisodeActionForm
    {
    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
        protected TTObjectClasses.HemodialysisOrder _HemodialysisOrder
        {
            get { return (TTObjectClasses.HemodialysisOrder)_ttObject; }
        }

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
        protected ITTLabel labelSessionDayRangeType;
        protected ITTEnumComboBox SessionDayRangeType;
        protected ITTLabel labelSessionDayRange;
        protected ITTLabel labelSessionCount;
        override protected void InitializeControls()
        {
            IsWeekendInclude = (ITTCheckBox)AddControl(new Guid("9bd265a2-5229-44ce-9901-718a044febee"));
            labelDuration = (ITTLabel)AddControl(new Guid("dc7df416-d4cd-41dd-a403-c1b4747ca258"));
            Duration = (ITTTextBox)AddControl(new Guid("2c4a89d1-888f-4c7f-b490-534ac4702ad5"));
            IDBaseAction = (ITTTextBox)AddControl(new Guid("6856b80c-7b97-485b-8391-11dabb0b1d47"));
            Information = (ITTTextBox)AddControl(new Guid("731b3b1e-09e3-46bd-90ba-31849474da07"));
            SessionDayRange = (ITTTextBox)AddControl(new Guid("0c6822fc-d10e-4eab-a6ba-2fd2d543022c"));
            SessionCount = (ITTTextBox)AddControl(new Guid("a88127c1-8b24-4934-a337-910d566092a4"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("c1cb69d6-9259-460b-8811-b1dfb2fbdf78"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("cdce4592-a706-46ab-96b7-8f386d1e0dd6"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("778b687a-aa16-4eda-aea1-ed4d67862a2a"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("8374213a-57b5-46af-aee1-03139ef5ffdc"));
            labelIDBaseAction = (ITTLabel)AddControl(new Guid("3c4d81a2-3bfe-4c6a-8020-966f0cb51d20"));
            labelInformation = (ITTLabel)AddControl(new Guid("b1bdd0b7-fea6-465f-bd8c-53af69a9a277"));
            labelPackageProcedure = (ITTLabel)AddControl(new Guid("af3c4bce-2cfb-4ccd-b391-73d4868e4c79"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("ed3ffecc-0071-44a0-b757-65913641b324"));
            labelDialysisFrequency = (ITTLabel)AddControl(new Guid("7d192cba-7395-48b1-9913-f3af6da0de83"));
            DialysisFrequency = (ITTObjectListBox)AddControl(new Guid("657b519f-ec0c-4a56-8948-0e500dde765f"));
            Emergency = (ITTCheckBox)AddControl(new Guid("ae70b08c-7e3f-4128-ab1b-9b39f0071aab"));
            labelTreatmentStartDateTime = (ITTLabel)AddControl(new Guid("ed70353b-e1f6-43b6-97d3-eef16afccd46"));
            TreatmentStartDateTime = (ITTDateTimePicker)AddControl(new Guid("b64e0af9-8ece-4425-ad20-5b47431d2569"));
            labelSessionDayRangeType = (ITTLabel)AddControl(new Guid("9fa1afbc-aa8d-46ad-a0d2-a4cf4136cb66"));
            SessionDayRangeType = (ITTEnumComboBox)AddControl(new Guid("110d4202-342d-4159-ae02-49af449dcafd"));
            labelSessionDayRange = (ITTLabel)AddControl(new Guid("3658dee2-4fd6-4e7c-aadc-83aa3977a27f"));
            labelSessionCount = (ITTLabel)AddControl(new Guid("c753e085-18e5-4daf-a03a-cba386bb44b9"));
            base.InitializeControls();
        }

        public HemodialysisOrderForm() : base("HEMODIALYSISORDER", "HemodialysisOrderForm")
        {
        }

        protected HemodialysisOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}