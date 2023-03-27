
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
    public partial class CigaretteInspectionForm : TTForm
    {
        protected TTObjectClasses.CigaretteExamination _CigaretteExamination
        {
            get { return (TTObjectClasses.CigaretteExamination)_ttObject; }
        }

        protected ITTLabel labelPhysicalExamination;
        protected ITTEnumComboBox PhysicalExamination;
        protected ITTEnumComboBox MedicineRangeType;
        protected ITTLabel labelAdditionalComplaint;
        protected ITTTextBox AdditionalComplaint;
        protected ITTTextBox MedicationRange;
        protected ITTTextBox ControlCOHb;
        protected ITTTextBox ControlCO;
        protected ITTTextBox SmokingReason;
        protected ITTTextBox SmokingAmount;
        protected ITTTextBox ControlNumber;
        protected ITTLabel labelTreatment;
        protected ITTEnumComboBox Treatment;
        protected ITTLabel labelMedicationRange;
        protected ITTLabel labelControlCOHb;
        protected ITTLabel labelControlCO;
        protected ITTLabel labelSmokingReason;
        protected ITTLabel labelSmokingAmount;
        protected ITTLabel labelDidSheHeSmoke;
        protected ITTEnumComboBox DidSheHeSmoke;
        protected ITTLabel labelQuitDate;
        protected ITTDateTimePicker QuitDate;
        protected ITTLabel labelControlNumber;
        protected ITTLabel labelGetTraining;
        protected ITTEnumComboBox GetTraining;
        protected ITTLabel labelControlType;
        protected ITTEnumComboBox ControlType;
        protected ITTLabel labelQuitSmokingMethod;
        protected ITTEnumComboBox QuitSmokingMethod;
        protected ITTGroupBox gb1;
        protected ITTTextBox Challenges;
        protected ITTCheckBox Other;
        protected ITTCheckBox NoDifficulty;
        protected ITTCheckBox MouthSore;
        protected ITTCheckBox IncreasedAppetite;
        protected ITTCheckBox ExcessiveSmoking;
        protected ITTCheckBox Imbalance;
        protected ITTCheckBox SleepingDisorder;
        protected ITTCheckBox HeadAndFacialNumbness;
        protected ITTCheckBox LossOfConcentration;
        protected ITTCheckBox Irritability;
        protected ITTCheckBox HeadacheAndDizziness;
        protected ITTCheckBox Constipation;
        override protected void InitializeControls()
        {
            labelPhysicalExamination = (ITTLabel)AddControl(new Guid("70624f23-c61f-42fa-8a8b-ac8cadd4f105"));
            PhysicalExamination = (ITTEnumComboBox)AddControl(new Guid("e689b3d2-91e5-4a2b-9e06-8e28f881a442"));
            MedicineRangeType = (ITTEnumComboBox)AddControl(new Guid("d892762f-1301-4497-89db-0953561f65f8"));
            labelAdditionalComplaint = (ITTLabel)AddControl(new Guid("3ea0a84c-f4db-4001-a88b-da0a3468b5f1"));
            AdditionalComplaint = (ITTTextBox)AddControl(new Guid("50338af6-edd1-4f22-8361-7803b3bcfb94"));
            MedicationRange = (ITTTextBox)AddControl(new Guid("1de8aabf-68e0-4a7a-bd82-935bfad188cd"));
            ControlCOHb = (ITTTextBox)AddControl(new Guid("8ca12ad1-2293-4fd3-939d-cd5d7945a78a"));
            ControlCO = (ITTTextBox)AddControl(new Guid("064cf82f-fe7d-41e4-960a-57dbcd5018fa"));
            SmokingReason = (ITTTextBox)AddControl(new Guid("90151e04-40b0-4ed4-bdde-af4bef3a4935"));
            SmokingAmount = (ITTTextBox)AddControl(new Guid("9fa7d8a2-6c00-440e-b6fb-075ef698b7b8"));
            ControlNumber = (ITTTextBox)AddControl(new Guid("21a29120-1f04-467f-991d-2583de7225b7"));
            labelTreatment = (ITTLabel)AddControl(new Guid("096c8a60-df3d-4abe-aa7c-cc981248c508"));
            Treatment = (ITTEnumComboBox)AddControl(new Guid("a064c5a7-3894-4e4c-85b9-bf4bbd6dce88"));
            labelMedicationRange = (ITTLabel)AddControl(new Guid("ae1a3de9-b4ad-4337-af9d-717c1ad83f4c"));
            labelControlCOHb = (ITTLabel)AddControl(new Guid("32628af4-0041-4efc-8b29-a5578de6e9ad"));
            labelControlCO = (ITTLabel)AddControl(new Guid("71578d17-a1a4-4829-a481-ffdb7e98614a"));
            labelSmokingReason = (ITTLabel)AddControl(new Guid("c1b6049c-37e8-4f97-af35-176603f0047f"));
            labelSmokingAmount = (ITTLabel)AddControl(new Guid("38f2bc4c-a491-4aee-a2dd-192d892a89b2"));
            labelDidSheHeSmoke = (ITTLabel)AddControl(new Guid("67bc11f4-30d7-462f-8ac2-25099ae769c4"));
            DidSheHeSmoke = (ITTEnumComboBox)AddControl(new Guid("7963ad8e-5eb0-403f-872d-899c84214bc3"));
            labelQuitDate = (ITTLabel)AddControl(new Guid("96582ddf-57c8-4ba2-9a87-37d6af4a6b0d"));
            QuitDate = (ITTDateTimePicker)AddControl(new Guid("8a09daa5-6894-464a-8377-768a9cbc65cf"));
            labelControlNumber = (ITTLabel)AddControl(new Guid("5489ebd3-701c-4bc1-a05c-77d90bc4e19a"));
            labelGetTraining = (ITTLabel)AddControl(new Guid("80dd05a9-a616-4556-815c-72de9c8fd396"));
            GetTraining = (ITTEnumComboBox)AddControl(new Guid("ab95e432-589d-48bd-a181-224992facfcd"));
            labelControlType = (ITTLabel)AddControl(new Guid("18ac4682-f164-4b1e-93ad-24744a57217e"));
            ControlType = (ITTEnumComboBox)AddControl(new Guid("a4832995-d3cd-493a-b427-c7c96a290ba8"));
            labelQuitSmokingMethod = (ITTLabel)AddControl(new Guid("f1916e4d-e1d1-4153-a250-c390afc9c6dc"));
            QuitSmokingMethod = (ITTEnumComboBox)AddControl(new Guid("5c8b9635-df8d-4e1b-8487-87eb8985cd85"));
            gb1 = (ITTGroupBox)AddControl(new Guid("ca9daf66-8611-4531-b314-62b8723c527e"));
            Challenges = (ITTTextBox)AddControl(new Guid("797cb43f-3461-4f91-a536-54011dd05148"));
            Other = (ITTCheckBox)AddControl(new Guid("72763c8f-9441-408e-98db-30b471d2008f"));
            NoDifficulty = (ITTCheckBox)AddControl(new Guid("7cc1df4c-90f7-482c-91fe-b31ebd9ce29b"));
            MouthSore = (ITTCheckBox)AddControl(new Guid("f6c7fdb6-b6b6-4c13-b08a-4a77f7678215"));
            IncreasedAppetite = (ITTCheckBox)AddControl(new Guid("13e6c168-68e6-45d6-9d24-7a1577357fb7"));
            ExcessiveSmoking = (ITTCheckBox)AddControl(new Guid("fed58b6f-5070-4031-bc2a-47457723a74f"));
            Imbalance = (ITTCheckBox)AddControl(new Guid("02230c1f-e943-4631-9236-d0277c35617b"));
            SleepingDisorder = (ITTCheckBox)AddControl(new Guid("300513f7-80f5-416e-a2cc-85172fc128dc"));
            HeadAndFacialNumbness = (ITTCheckBox)AddControl(new Guid("1d8366f3-ebf8-4155-a213-722dd687867e"));
            LossOfConcentration = (ITTCheckBox)AddControl(new Guid("3dfd47bd-014f-484d-9fe5-0045118f9215"));
            Irritability = (ITTCheckBox)AddControl(new Guid("08067685-08aa-4105-801b-ca7a88bbb233"));
            HeadacheAndDizziness = (ITTCheckBox)AddControl(new Guid("15588686-dc38-43fa-8551-1050a0eaf740"));
            Constipation = (ITTCheckBox)AddControl(new Guid("345ec34e-fcb7-40ba-bf18-6fe56553595d"));
            base.InitializeControls();
        }

        public CigaretteInspectionForm() : base("CIGARETTEEXAMINATION", "CigaretteInspectionForm")
        {
        }

        protected CigaretteInspectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}