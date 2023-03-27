
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
    public partial class ProstateScreeningForm : TTForm
    {
        protected TTObjectClasses.ProstateScreening _ProstateScreening
        {
            get { return (TTObjectClasses.ProstateScreening)_ttObject; }
        }

        protected ITTGroupBox ProstateResultGB;
        protected ITTLabel labelScreeningResult;
        protected ITTTextBox ScreeningResult;
        protected ITTGroupBox ScreeningResultGB;
        protected ITTLabel labelFreePSA;
        protected ITTTextBox FreePSA;
        protected ITTLabel labelTotalPSA;
        protected ITTTextBox TotalPSA;
        protected ITTGroupBox PreviousScreeningGB;
        protected ITTLabel labelExamination;
        protected ITTTextBox Examination;
        protected ITTLabel labelPSA;
        protected ITTTextBox PSA;
        protected ITTGroupBox ProstateAnamnesisGB;
        protected ITTCheckBox ReductionInUrineFlow;
        protected ITTCheckBox RetentionOfUrine;
        protected ITTCheckBox PainfulUrination;
        protected ITTCheckBox FrequentUrination;
        protected ITTLabel labelChronicDiseases;
        protected ITTTextBox ChronicDiseases;
        protected ITTLabel labelUsedMedicines;
        protected ITTTextBox UsedMedicines;
        protected ITTLabel labelSKRSAlkolKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSAlkolKullanimiAnamnesisInfo;
        protected ITTLabel labelSKRSSigaraKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSSigaraKullanimiAnamnesisInfo;
        protected ITTLabel labelFamilyCancerHistory;
        protected ITTEnumComboBox FamilyCancerHistory;
        protected ITTLabel labelOccupationPatient;
        protected ITTObjectListBox OccupationPatient;
        override protected void InitializeControls()
        {
            ProstateResultGB = (ITTGroupBox)AddControl(new Guid("f2e9348b-aea8-4439-b281-d1c91fbfdc7f"));
            labelScreeningResult = (ITTLabel)AddControl(new Guid("82ce9079-3483-4dc9-a931-a57ebb83485c"));
            ScreeningResult = (ITTTextBox)AddControl(new Guid("714f3126-2ae0-4d62-ae52-e2e8b66d7268"));
            ScreeningResultGB = (ITTGroupBox)AddControl(new Guid("0c5634ff-55ce-46cd-ab81-ded65017b739"));
            labelFreePSA = (ITTLabel)AddControl(new Guid("42a6deed-b797-42f0-ba08-16c14760cb3d"));
            FreePSA = (ITTTextBox)AddControl(new Guid("3ad26149-e340-48d3-a908-3d9fc3964be9"));
            labelTotalPSA = (ITTLabel)AddControl(new Guid("842d3b85-50b0-44a2-bd65-e44491af62be"));
            TotalPSA = (ITTTextBox)AddControl(new Guid("defdf574-73a8-4e2c-9fc5-3f68d62ba473"));
            PreviousScreeningGB = (ITTGroupBox)AddControl(new Guid("e6e28378-9c99-45b4-8969-7acbcd8e2cb9"));
            labelExamination = (ITTLabel)AddControl(new Guid("5a94055d-f81a-4831-8245-6a05626b7c05"));
            Examination = (ITTTextBox)AddControl(new Guid("84ee681b-c30f-4c4e-9d1e-9a5239e1faad"));
            labelPSA = (ITTLabel)AddControl(new Guid("1c6177e5-09b1-4806-a33a-af22f9ba2187"));
            PSA = (ITTTextBox)AddControl(new Guid("dabdd06e-d1c8-4936-88ea-c1369582e8fa"));
            ProstateAnamnesisGB = (ITTGroupBox)AddControl(new Guid("3e60326d-752f-42a3-ae1e-6b1e37a22f64"));
            ReductionInUrineFlow = (ITTCheckBox)AddControl(new Guid("a20d0490-636d-42be-9371-f9491977f3ab"));
            RetentionOfUrine = (ITTCheckBox)AddControl(new Guid("738fd18f-2bc9-44bc-9a3b-413119ebdd05"));
            PainfulUrination = (ITTCheckBox)AddControl(new Guid("d96c67a7-74f8-43f0-882f-a3e1118e365a"));
            FrequentUrination = (ITTCheckBox)AddControl(new Guid("dba05467-1b8a-4521-b7ca-a9dc9ec672a6"));
            labelChronicDiseases = (ITTLabel)AddControl(new Guid("4dd55a27-e19b-4345-ab6c-80f4337764d9"));
            ChronicDiseases = (ITTTextBox)AddControl(new Guid("ad175c1f-0d87-4964-82dc-06a89c1414a8"));
            labelUsedMedicines = (ITTLabel)AddControl(new Guid("0aed4bd2-1b41-40b9-873f-cbb391276854"));
            UsedMedicines = (ITTTextBox)AddControl(new Guid("c8076a9f-53fb-4088-a99b-146abc88742e"));
            labelSKRSAlkolKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("84001e5d-5155-4247-a1b0-6e2f87a742ae"));
            SKRSAlkolKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("3a1a9c89-657a-4d46-9cbd-273672d16ccc"));
            labelSKRSSigaraKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("a2dd8a6b-0428-4f56-8827-8aca626cf085"));
            SKRSSigaraKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("ea4f3c46-f2e6-4c75-85df-3842085e0a3c"));
            labelFamilyCancerHistory = (ITTLabel)AddControl(new Guid("b5bef4f9-c93d-448f-bf0a-d8f515e7de93"));
            FamilyCancerHistory = (ITTEnumComboBox)AddControl(new Guid("a2ca2647-6f08-4b3f-ad30-57e3614cfdb3"));
            labelOccupationPatient = (ITTLabel)AddControl(new Guid("3179fd81-1ab8-4c23-bdac-d88dc5bef85d"));
            OccupationPatient = (ITTObjectListBox)AddControl(new Guid("2c2f3eba-dd4f-4a6a-b13d-9ab1698d6c52"));
            base.InitializeControls();
        }

        public ProstateScreeningForm() : base("PROSTATESCREENING", "ProstateScreeningForm")
        {
        }

        protected ProstateScreeningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}