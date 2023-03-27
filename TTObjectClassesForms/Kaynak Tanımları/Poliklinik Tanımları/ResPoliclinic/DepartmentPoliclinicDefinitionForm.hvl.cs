
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
    /// Poliklinik Tanımı
    /// </summary>
    public partial class DepartmentPoliclinicDefinitionForm : TTForm
    {
    /// <summary>
    /// Poliklinik
    /// </summary>
        protected TTObjectClasses.ResPoliclinic _ResPoliclinic
        {
            get { return (TTObjectClasses.ResPoliclinic)_ttObject; }
        }

        protected ITTCheckBox IsGoruntuluRandevu;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTLabel labelMinAge;
        protected ITTCheckBox DontTakeGSSProvision;
        protected ITTTextBox MinAge;
        protected ITTLabel labelMaxAge;
        protected ITTTextBox MaxAge;
        protected ITTLabel labelSexException;
        protected ITTEnumComboBox SexException;
        protected ITTTextBox EtiquetteCount;
        protected ITTCheckBox IsDentalPoliclinic;
        protected ITTCheckBox IsHealthCommittee;
        protected ITTCheckBox PatientCallSystemInUse;
        protected ITTCheckBox IsEtiquettePrinted;
        protected ITTLabel labelEtiquetteCount;
        protected ITTCheckBox IsToBeConsultation;
        protected ITTCheckBox CopyHeightWeight;
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTCheckBox IsmedicalWaste;
        protected ITTCheckBox HimssRequired;
        protected ITTCheckBox ShownInKiosk;
        protected ITTTabPage Quotas;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelJanuaryQuota;
        protected ITTLabel labelSeptemberQuota;
        protected ITTTextBox AprilQuota;
        protected ITTTextBox SeptemberQuota;
        protected ITTLabel labelAprilQuota;
        protected ITTLabel labelOctoberQuota;
        protected ITTTextBox August;
        protected ITTTextBox OctoberQuota;
        protected ITTLabel labelAugust;
        protected ITTLabel labelNovemberQuota;
        protected ITTTextBox DecemberQuota;
        protected ITTTextBox NovemberQuota;
        protected ITTLabel labelDecemberQuota;
        protected ITTLabel labelMayQuota;
        protected ITTTextBox FebruaryQuota;
        protected ITTTextBox MayQuota;
        protected ITTLabel labelFebruaryQuota;
        protected ITTLabel labelMarchQuota;
        protected ITTTextBox JanuaryQuota;
        protected ITTTextBox MarchQuota;
        protected ITTTextBox JulyQuota;
        protected ITTLabel labelJuneQuata;
        protected ITTLabel labelJulyQuota;
        protected ITTTextBox JuneQuata;
        protected ITTTextBox OptionalDelayMinute;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox MHRSCode;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox MHRSAltKlinikKodu;
        protected ITTTextBox ASALCode;
        protected ITTLabel labelMHRSCode;
        protected ITTLabel labelMHRSAltKlinikKodu;
        protected ITTDateTimePicker dtResourceStartTime;
        protected ITTLabel labelOptionalDelayMinute;
        protected ITTGrid ResponsibleUsers;
        protected ITTListBoxColumn ResUserResponsibleUsersGrid;
        protected ITTLabel labelResSectionTypeResSection;
        protected ITTEnumComboBox ResSectionTypeResSection;
        protected ITTLabel labelSaglikNetKlinikleri;
        protected ITTObjectListBox SaglikNetKlinikleri;
        protected ITTLabel labelASALCode;
        protected ITTLabel labelStore;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox Department;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox Type;
        protected ITTListDefComboBox TedaviTipi;
        protected ITTListDefComboBox TedaviTuru;
        protected ITTLabel lblTedaviTipi;
        protected ITTLabel lblTedaviTuru;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            IsGoruntuluRandevu = (ITTCheckBox)AddControl(new Guid("81225b80-0b69-4e3e-a025-252d64433978"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4b9192fb-6de8-4fbe-b6c4-7cb1e43dfee0"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("50cdafd3-2eb9-41af-9011-18b8253942b1"));
            labelMinAge = (ITTLabel)AddControl(new Guid("cb8d5992-17a0-4b8a-9d21-fc798f2aa029"));
            DontTakeGSSProvision = (ITTCheckBox)AddControl(new Guid("c2d582f1-9425-425c-9a15-0fc3e3f01278"));
            MinAge = (ITTTextBox)AddControl(new Guid("8bd27cb6-5137-4576-a2b2-940340a7999a"));
            labelMaxAge = (ITTLabel)AddControl(new Guid("8e64bbe8-763f-49f0-a2a1-41776f40c1fa"));
            MaxAge = (ITTTextBox)AddControl(new Guid("3d7bbe60-3d95-47df-9ab3-1bc30bdb76d4"));
            labelSexException = (ITTLabel)AddControl(new Guid("3cba1d14-76ef-4d48-91f7-a8400f66666c"));
            SexException = (ITTEnumComboBox)AddControl(new Guid("2b934a4f-4d49-4dad-b50e-d0662a36c869"));
            EtiquetteCount = (ITTTextBox)AddControl(new Guid("554a886c-ff1b-4bc1-af87-5a32aeb53f59"));
            IsDentalPoliclinic = (ITTCheckBox)AddControl(new Guid("85381281-38d2-461e-9d78-bb0e84da056d"));
            IsHealthCommittee = (ITTCheckBox)AddControl(new Guid("8e7c1678-a020-400f-b8e6-a3ade9b7937d"));
            PatientCallSystemInUse = (ITTCheckBox)AddControl(new Guid("78c4e8ec-4299-48aa-89b8-0050acc1c83d"));
            IsEtiquettePrinted = (ITTCheckBox)AddControl(new Guid("efd3ab41-ade2-48f4-ab5c-68106c9d5adf"));
            labelEtiquetteCount = (ITTLabel)AddControl(new Guid("e66f31b4-c111-43c2-952c-5a1e934436ad"));
            IsToBeConsultation = (ITTCheckBox)AddControl(new Guid("d1065e3d-870a-43a7-b51b-0290876a8c5c"));
            CopyHeightWeight = (ITTCheckBox)AddControl(new Guid("a8119b3c-af10-4bc3-b2d9-276c98ca737b"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("e50c8ce1-1ec4-4897-a310-dbddf7219bed"));
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("12d1e464-d36d-4894-b59a-edde59391ce3"));
            HimssRequired = (ITTCheckBox)AddControl(new Guid("36995f78-20d5-48f2-8df1-a594beef6c57"));
            ShownInKiosk = (ITTCheckBox)AddControl(new Guid("22a9366d-7dd5-45cc-8e2e-8ea600424263"));
            Quotas = (ITTTabPage)AddControl(new Guid("cd50a52b-cc20-40fc-aa75-805bfc5c41ca"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f48927f8-c6bb-40d1-b04a-fe12d965b2fe"));
            labelJanuaryQuota = (ITTLabel)AddControl(new Guid("968c9113-14c8-4b88-8072-05e0587a8251"));
            labelSeptemberQuota = (ITTLabel)AddControl(new Guid("696c2c92-cc60-427c-bb67-d88b9ac789ae"));
            AprilQuota = (ITTTextBox)AddControl(new Guid("2e5fd35d-ba3a-409a-99d1-952d3d1dd287"));
            SeptemberQuota = (ITTTextBox)AddControl(new Guid("08378dfb-297f-4337-b6c0-fff8fdc929fb"));
            labelAprilQuota = (ITTLabel)AddControl(new Guid("f1e516fc-8b5e-4a5d-a6e8-7346b82add6f"));
            labelOctoberQuota = (ITTLabel)AddControl(new Guid("86e358b8-2ef9-4a1b-936b-23ec3a02ae77"));
            August = (ITTTextBox)AddControl(new Guid("cb9ef0dc-5691-4b1a-8b06-c5ba13c1c527"));
            OctoberQuota = (ITTTextBox)AddControl(new Guid("a102ef38-2892-4536-8d65-3556cb5e6ca5"));
            labelAugust = (ITTLabel)AddControl(new Guid("bed2ca0b-14ad-48b7-867b-b70c9f541c2c"));
            labelNovemberQuota = (ITTLabel)AddControl(new Guid("a43709d9-7cf8-4351-bdcd-5bc886a5bc76"));
            DecemberQuota = (ITTTextBox)AddControl(new Guid("d37c5bd7-9e6f-4e2b-8dbc-01d7a2a050c9"));
            NovemberQuota = (ITTTextBox)AddControl(new Guid("e5e48823-91a8-4538-9ac5-e97ecf2c6cf4"));
            labelDecemberQuota = (ITTLabel)AddControl(new Guid("2aa35d6b-fbb6-47c0-8090-1ce69f62cbd0"));
            labelMayQuota = (ITTLabel)AddControl(new Guid("2f6693b3-d53b-42a1-a0ed-85bb1d3e46d8"));
            FebruaryQuota = (ITTTextBox)AddControl(new Guid("c8caacf5-2638-4138-9cdd-7c5393a6a81e"));
            MayQuota = (ITTTextBox)AddControl(new Guid("f3a0b199-ba5e-4dac-9246-aebede75a344"));
            labelFebruaryQuota = (ITTLabel)AddControl(new Guid("8872ebd0-c75f-48c7-a0ce-6a9a7f40f4d5"));
            labelMarchQuota = (ITTLabel)AddControl(new Guid("12636ec9-afdb-45ea-8eb3-ee1c4d95082a"));
            JanuaryQuota = (ITTTextBox)AddControl(new Guid("4203c3d3-882d-412d-b1d4-e6abe6f46d0c"));
            MarchQuota = (ITTTextBox)AddControl(new Guid("6746a00c-b223-45dd-b100-44a26e54ffa5"));
            JulyQuota = (ITTTextBox)AddControl(new Guid("a71d825c-219f-4cee-b05c-d0e6777cdde7"));
            labelJuneQuata = (ITTLabel)AddControl(new Guid("74d1812a-fe12-4aa1-8822-3cfda0aac2df"));
            labelJulyQuota = (ITTLabel)AddControl(new Guid("e3bc76ca-5024-444b-8b65-4db612b6344f"));
            JuneQuata = (ITTTextBox)AddControl(new Guid("c70f652b-2aa0-4777-9207-32c21b128e9f"));
            OptionalDelayMinute = (ITTTextBox)AddControl(new Guid("2315d0bd-b14c-4d2b-9297-1d73061ea3fc"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("93974f7d-43e7-46c2-8eb7-27cd5a9769b3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4d21c954-df8d-4518-8ba4-4473738aabe9"));
            Location = (ITTTextBox)AddControl(new Guid("a4624f7b-0651-469d-8f7b-f267f542c5eb"));
            MHRSCode = (ITTTextBox)AddControl(new Guid("d4234ee0-09a2-4b63-9e14-431b69a327c9"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("f63998bc-e78f-4d78-aca5-cb724a7b46a6"));
            MHRSAltKlinikKodu = (ITTTextBox)AddControl(new Guid("273befad-7c0c-40e0-88a7-9e5f7ae988b0"));
            ASALCode = (ITTTextBox)AddControl(new Guid("fb3f49cd-37b6-4d2b-9776-6abe1fd1ab8c"));
            labelMHRSCode = (ITTLabel)AddControl(new Guid("7b09a8e9-0a20-47e3-a908-e5f6c1d01342"));
            labelMHRSAltKlinikKodu = (ITTLabel)AddControl(new Guid("0b2994be-08b6-46b1-b265-315d82577667"));
            dtResourceStartTime = (ITTDateTimePicker)AddControl(new Guid("7c9d8165-2388-4c56-86b6-006f5eaa439c"));
            labelOptionalDelayMinute = (ITTLabel)AddControl(new Guid("8d38e6de-a647-4a07-9495-316063f24fab"));
            ResponsibleUsers = (ITTGrid)AddControl(new Guid("26eb5173-f4a4-403d-a73f-4680739d8a42"));
            ResUserResponsibleUsersGrid = (ITTListBoxColumn)AddControl(new Guid("c48d668e-5245-4d43-9e4e-66470bd2ebee"));
            labelResSectionTypeResSection = (ITTLabel)AddControl(new Guid("f8ef55f6-5179-4ef7-8bab-de101b02cdc1"));
            ResSectionTypeResSection = (ITTEnumComboBox)AddControl(new Guid("44ecd53e-c102-4496-9d9f-3528d0b08348"));
            labelSaglikNetKlinikleri = (ITTLabel)AddControl(new Guid("76a47cd5-e250-4daa-a566-49179e8f7de8"));
            SaglikNetKlinikleri = (ITTObjectListBox)AddControl(new Guid("227cd897-6f9e-42c1-ba81-89c401f97c3a"));
            labelASALCode = (ITTLabel)AddControl(new Guid("7f8e9e2f-e773-4c83-ab2d-7ea2548ad321"));
            labelStore = (ITTLabel)AddControl(new Guid("b19078d3-a210-4176-b533-68b6da072627"));
            labelDepartment = (ITTLabel)AddControl(new Guid("ecf4eb6b-9136-4e0b-923e-b8dd841e0fcf"));
            Department = (ITTObjectListBox)AddControl(new Guid("ace9e31b-7f8d-436b-958e-d20cb76ffcbd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0e4c60e1-1ca9-4c2b-8464-5544c2ae3432"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("53d3d787-15e2-45bf-9cfe-4924271f7904"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("2262d162-0e73-4a20-8045-a7cf9ff4742a"));
            Store = (ITTObjectListBox)AddControl(new Guid("1970c853-d60e-4ac8-b2ca-cbae8e62a3ab"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("c152753c-3717-4662-ad5b-cf5612929794"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("576229fb-fdbc-4baa-b8de-6e4657d73e67"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ac8b5e97-e5e1-4bb1-9289-80594df93c0a"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("caf1330a-a5f9-4055-b71f-20ac91c7f22d"));
            Type = (ITTEnumComboBox)AddControl(new Guid("227f5e0f-0fb0-4f35-a8d0-d6f985523253"));
            TedaviTipi = (ITTListDefComboBox)AddControl(new Guid("9a13bd39-1b19-4c9a-a556-c14cce4e3ca0"));
            TedaviTuru = (ITTListDefComboBox)AddControl(new Guid("d323066f-1146-47be-9c8d-f447a61ac99e"));
            lblTedaviTipi = (ITTLabel)AddControl(new Guid("5f97ff01-49ea-4910-98a9-3b9e13eff3be"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("fce565ab-c95c-485a-8530-0832dc1ef198"));
            labelLocation = (ITTLabel)AddControl(new Guid("6dc34e4a-6fd6-4fea-834a-b3f7adb19e0a"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("5b709ae5-c459-41e7-ab68-0605e1888312"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("9bc37af0-d4b3-4eaa-8811-e383baea310f"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("63db04be-045f-4e05-ac71-0c0a0bac24c9"));
            base.InitializeControls();
        }

        public DepartmentPoliclinicDefinitionForm() : base("RESPOLICLINIC", "DepartmentPoliclinicDefinitionForm")
        {
        }

        protected DepartmentPoliclinicDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}