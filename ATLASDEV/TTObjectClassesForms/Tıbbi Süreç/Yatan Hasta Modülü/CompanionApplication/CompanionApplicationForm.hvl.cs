
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
    /// Refakatçi İşlemleri
    /// </summary>
    public partial class CompanionApplicationForm : EpisodeActionForm
    {
    /// <summary>
    /// Refakatçi İşlemleri
    /// </summary>
        protected TTObjectClasses.CompanionApplication _CompanionApplication
        {
            get { return (TTObjectClasses.CompanionApplication)_ttObject; }
        }

        protected ITTLabel labelPassportNo;
        protected ITTTextBox PassportNo;
        protected ITTTextBox MedicalReasonForCompanion;
        protected ITTTextBox StayingDateCount;
        protected ITTPanel ttpanel1;
        protected ITTButton CheckMernis;
        protected ITTLabel labelUniqueRefNo;
        protected ITTObjectListBox CompanionSex;
        protected ITTLabel labelCompanionAddress;
        protected ITTDateTimePicker CompanionBirthDate;
        protected ITTTextBox UniqueRefNo;
        protected ITTLabel labelCompanionBirthDate;
        protected ITTLabel labelCompanionName;
        protected ITTLabel labelCompanionSex;
        protected ITTTextBox CompanionName;
        protected ITTEnumComboBox Relationship;
        protected ITTTextBox tttextbox7;
        protected ITTLabel labelRelationship;
        protected ITTLabel labelMedicalReasonForCompanion;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelStayingDateCount;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelDietDefinition;
        protected ITTObjectListBox DietDefinition;
        override protected void InitializeControls()
        {
            labelPassportNo = (ITTLabel)AddControl(new Guid("e8c5015d-0af3-4434-8057-d4b09be0de1f"));
            PassportNo = (ITTTextBox)AddControl(new Guid("5ada9d15-0397-4f90-a9be-9d1b9b3d5878"));
            MedicalReasonForCompanion = (ITTTextBox)AddControl(new Guid("7587bb36-1e89-4c1e-b5aa-4df98a15b971"));
            StayingDateCount = (ITTTextBox)AddControl(new Guid("a0c7681b-b00a-479d-a6e3-03ddf082fe2c"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("76709287-2e4a-4ef0-a917-debf44b9dcc2"));
            CheckMernis = (ITTButton)AddControl(new Guid("cef2c61e-873b-4fcd-9428-ba7a30eb7013"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("4eabbd20-16e4-4c61-90ee-c0a7fd0cbdef"));
            CompanionSex = (ITTObjectListBox)AddControl(new Guid("bb449a5d-cea9-4ad3-a2e3-083e80977b39"));
            labelCompanionAddress = (ITTLabel)AddControl(new Guid("9193b2dd-009e-477c-8a62-4622148d66c3"));
            CompanionBirthDate = (ITTDateTimePicker)AddControl(new Guid("a7512802-7cc4-49f9-8f8d-aefcbb43a53d"));
            UniqueRefNo = (ITTTextBox)AddControl(new Guid("2bbe79b5-68f9-4625-b9b4-5a0013cf1f79"));
            labelCompanionBirthDate = (ITTLabel)AddControl(new Guid("338b0f77-992c-4ced-9713-1fb2a5e164c4"));
            labelCompanionName = (ITTLabel)AddControl(new Guid("abf197fb-0506-4062-8120-a19e476671a8"));
            labelCompanionSex = (ITTLabel)AddControl(new Guid("f3cdc821-af79-4f5e-989e-b3ad3660cdbb"));
            CompanionName = (ITTTextBox)AddControl(new Guid("1be9984d-c49f-4e73-adb3-595917196962"));
            Relationship = (ITTEnumComboBox)AddControl(new Guid("e6a53836-5230-456a-b9fc-ee509eb75071"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("76b7bfaf-ecb8-4421-b7e4-378e279f3957"));
            labelRelationship = (ITTLabel)AddControl(new Guid("90e17ce7-3571-486a-9cc0-e8691443a6f9"));
            labelMedicalReasonForCompanion = (ITTLabel)AddControl(new Guid("1aded162-b791-45c1-9564-af09ebdca1e1"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("c0ce538e-4f8a-4b45-b6ae-e69c82337363"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("19c49538-ec7b-4965-9918-c82b27c742df"));
            labelStayingDateCount = (ITTLabel)AddControl(new Guid("76c28fd8-00a5-446d-91d0-883202bf5b22"));
            labelEndDate = (ITTLabel)AddControl(new Guid("8c4a16df-b906-45b0-b76d-f5d9815e1f44"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("89635284-90d8-4485-bc7a-ac1912b06954"));
            labelDietDefinition = (ITTLabel)AddControl(new Guid("3dc74adc-a54b-47b2-b54e-df9a7c4eb16d"));
            DietDefinition = (ITTObjectListBox)AddControl(new Guid("6ed5bf1f-483c-49a8-95ff-e73c23ec53d8"));
            base.InitializeControls();
        }

        public CompanionApplicationForm() : base("COMPANIONAPPLICATION", "CompanionApplicationForm")
        {
        }

        protected CompanionApplicationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}