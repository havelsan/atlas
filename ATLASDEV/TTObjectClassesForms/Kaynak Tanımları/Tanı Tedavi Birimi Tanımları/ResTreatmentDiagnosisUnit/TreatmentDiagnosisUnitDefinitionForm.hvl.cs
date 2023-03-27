
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
    /// Tanı Tedavi Ünitesi Tanımı
    /// </summary>
    public partial class TreatmentDiagnosisUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// Tanı Tedavi Birimi
    /// </summary>
        protected TTObjectClasses.ResTreatmentDiagnosisUnit _ResTreatmentDiagnosisUnit
        {
            get { return (TTObjectClasses.ResTreatmentDiagnosisUnit)_ttObject; }
        }

        protected ITTCheckBox OpenOnWednesday;
        protected ITTCheckBox OpenOnTuesday;
        protected ITTCheckBox OpenOnThursday;
        protected ITTCheckBox OpenOnSunday;
        protected ITTCheckBox OpenOnSaturday;
        protected ITTCheckBox OpenOnMonday;
        protected ITTCheckBox OpenOnFriday;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelHospital;
        protected ITTObjectListBox Hospital;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTLabel labelResSectionTypeResSection;
        protected ITTEnumComboBox ResSectionTypeResSection;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            OpenOnWednesday = (ITTCheckBox)AddControl(new Guid("ed932832-0792-4476-b318-49cb4ddfdf8c"));
            OpenOnTuesday = (ITTCheckBox)AddControl(new Guid("28885f6f-37fa-4c24-bee6-97c00c47d304"));
            OpenOnThursday = (ITTCheckBox)AddControl(new Guid("ba2bb9ae-ff78-429e-8322-83f98e1b7944"));
            OpenOnSunday = (ITTCheckBox)AddControl(new Guid("300d74ac-b3cc-4b57-86ac-c5c65dfcf016"));
            OpenOnSaturday = (ITTCheckBox)AddControl(new Guid("5fe205eb-c622-4fe3-af75-343605bb5faa"));
            OpenOnMonday = (ITTCheckBox)AddControl(new Guid("6c380c12-51dc-460f-ad25-08f3c0df99b8"));
            OpenOnFriday = (ITTCheckBox)AddControl(new Guid("04873e4c-f29f-4567-8f8a-ea39fd134658"));
            labelQref = (ITTLabel)AddControl(new Guid("13de7131-2b6a-46e0-b4cf-99c749d2d100"));
            Qref = (ITTTextBox)AddControl(new Guid("b27f368c-b75b-4c06-addb-5a259c7d8bdd"));
            Name = (ITTTextBox)AddControl(new Guid("db702fe3-df9a-4d3c-bced-141db74bffe1"));
            Location = (ITTTextBox)AddControl(new Guid("32789993-279f-4c54-976e-dd46646384ad"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("ff55f539-d135-43fd-a26e-48bb8187c8c9"));
            labelName = (ITTLabel)AddControl(new Guid("c94d391c-ee53-46ae-81ab-7077e64393f2"));
            labelStore = (ITTLabel)AddControl(new Guid("3997a603-47d1-499e-9fa3-5350a85a5bbe"));
            Store = (ITTObjectListBox)AddControl(new Guid("b70d9c44-f69b-4831-9bae-29e2a6954cf4"));
            IsActive = (ITTCheckBox)AddControl(new Guid("45c88ecd-794b-4819-b51d-ca4daadc2760"));
            labelHospital = (ITTLabel)AddControl(new Guid("d72c3961-9439-4b69-b40d-a25f4bea5b1a"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("977a9e60-d733-4056-a422-398e5443abaa"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("313912e7-8bec-4aea-b223-af6101797fc4"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("91b98c7c-a4a7-4239-9c16-3264058f5b12"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4f9efa1c-84f6-4317-8e8b-4f296c81e6ab"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("02f35b3e-5965-4e3e-97e8-9b2c2994a5a9"));
            labelResSectionTypeResSection = (ITTLabel)AddControl(new Guid("3666c4b8-7061-48ef-89f7-0ebf1bf2bacb"));
            ResSectionTypeResSection = (ITTEnumComboBox)AddControl(new Guid("9376a9d6-e5c4-4506-91c1-968b4d24c616"));
            labelLocation = (ITTLabel)AddControl(new Guid("8940518e-c5e5-4f19-8d75-980ff9caabf0"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("f0c38b39-1cf3-4d34-97ec-bf1e5d1f2f8f"));
            base.InitializeControls();
        }

        public TreatmentDiagnosisUnitDefinitionForm() : base("RESTREATMENTDIAGNOSISUNIT", "TreatmentDiagnosisUnitDefinitionForm")
        {
        }

        protected TreatmentDiagnosisUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}