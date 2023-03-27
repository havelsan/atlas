
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
    public partial class SensoryPerceptionAssessmentForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Duyu-Algı-Motor Değerlendirmesi
    /// </summary>
        protected TTObjectClasses.SensoryPerceptionAssessmentForm _SensoryPerceptionAssessmentForm
        {
            get { return (TTObjectClasses.SensoryPerceptionAssessmentForm)_ttObject; }
        }

        protected ITTLabel labelStarCancellationTest;
        protected ITTTextBox StarCancellationTest;
        protected ITTTextBox MiniMentalStateExamination;
        protected ITTTextBox RivemeadIndex;
        protected ITTTextBox FuglMeyerTest;
        protected ITTTextBox KurtzkeScale;
        protected ITTTextBox ASIAImpairmentScale;
        protected ITTTextBox Code;
        protected ITTLabel labelMiniMentalStateExamination;
        protected ITTLabel labelRivemeadIndex;
        protected ITTLabel labelFuglMeyerTest;
        protected ITTLabel labelKurtzkeScale;
        protected ITTLabel labelASIAImpairmentScale;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelStarCancellationTest = (ITTLabel)AddControl(new Guid("8372a3bc-f0ea-411d-9a0c-f1533537fe8c"));
            StarCancellationTest = (ITTTextBox)AddControl(new Guid("491ffcaa-e9bc-48a5-9505-3e700439408c"));
            MiniMentalStateExamination = (ITTTextBox)AddControl(new Guid("23b45dcd-7f25-4267-aacc-a100cdfb8a10"));
            RivemeadIndex = (ITTTextBox)AddControl(new Guid("fa546bb6-a933-4c79-a625-86ec2dd2ee2e"));
            FuglMeyerTest = (ITTTextBox)AddControl(new Guid("33256857-29ec-4ecf-ad96-8c484bdb200d"));
            KurtzkeScale = (ITTTextBox)AddControl(new Guid("f207cf6d-548f-43de-80f7-6bd2c8f1e5bb"));
            ASIAImpairmentScale = (ITTTextBox)AddControl(new Guid("cab1677c-bc89-406d-8ffd-118b371ded79"));
            Code = (ITTTextBox)AddControl(new Guid("66e85be3-b51f-42ed-adb7-3e27cf884b5a"));
            labelMiniMentalStateExamination = (ITTLabel)AddControl(new Guid("3492cf2b-de36-4d32-b8fa-418fefb02298"));
            labelRivemeadIndex = (ITTLabel)AddControl(new Guid("8d4d6a2e-cd62-47de-a3ec-df5b4907b8d0"));
            labelFuglMeyerTest = (ITTLabel)AddControl(new Guid("4d19702a-b8a6-4374-bc46-acb989ef2516"));
            labelKurtzkeScale = (ITTLabel)AddControl(new Guid("9eaf480b-0740-43ad-8198-53f361f81ae7"));
            labelASIAImpairmentScale = (ITTLabel)AddControl(new Guid("2def9e1b-41b3-4528-adf6-061a20c27475"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("51d0a2a9-f04f-44e3-96d6-d4544b51b400"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("b2a5d1d0-734d-4782-b021-0677d8aaa2c5"));
            labelCode = (ITTLabel)AddControl(new Guid("5366d7f6-c35b-4f88-8d5d-740c424587b9"));
            base.InitializeControls();
        }

        public SensoryPerceptionAssessmentForm() : base("SENSORYPERCEPTIONASSESSMENTFORM", "SensoryPerceptionAssessmentForm")
        {
        }

        protected SensoryPerceptionAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}