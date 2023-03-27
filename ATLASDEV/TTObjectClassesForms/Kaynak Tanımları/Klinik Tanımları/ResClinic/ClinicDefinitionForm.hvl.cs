
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
    /// Klinik Tanımı
    /// </summary>
    public partial class ClinicDefinitionForm : TTForm
    {
    /// <summary>
    /// Klinik
    /// </summary>
        protected TTObjectClasses.ResClinic _ResClinic
        {
            get { return (TTObjectClasses.ResClinic)_ttObject; }
        }

        protected ITTCheckBox IsAllowAppointment;
        protected ITTLabel labelResFloor;
        protected ITTObjectListBox ResFloor;
        protected ITTLabel labelBedProcedureType;
        protected ITTEnumComboBox BedProcedureType;
        protected ITTCheckBox IsIntensiveCare;
        protected ITTListDefComboBox TakipTipi;
        protected ITTCheckBox HasCertificate;
        protected ITTCheckBox IsmedicalWaste;
        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox EtiquetteCount;
        protected ITTTextBox PercentageOfEmptyBedFor112;
        protected ITTTextBox InpatientQuota;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Floor;
        protected ITTTextBox PreDischargeLimit;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTCheckBox HimssRequired;
        protected ITTLabel labelSaglikNetKlinikleri;
        protected ITTObjectListBox SaglikNetKlinikleri;
        protected ITTCheckBox IsEtiquettePrinted;
        protected ITTLabel labelEtiquetteCount;
        protected ITTCheckBox PCSInUse;
        protected ITTCheckBox IsToBeConsultation;
        protected ITTLabel labelPercentageOfEmptyBedFor112;
        protected ITTLabel labelRes112ClinicDef;
        protected ITTObjectListBox Res112ClinicDef;
        protected ITTLabel labelInpatientQuota;
        protected ITTCheckBox IgnoreQuotaControl;
        protected ITTLabel labelStore;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox Department;
        protected ITTCheckBox IsEmergencyClinic;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox Store;
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTListDefComboBox TedaviTipi;
        protected ITTListDefComboBox TedaviTuru;
        protected ITTLabel lblTedaviTipi;
        protected ITTLabel lblTedaviTuru;
        protected ITTLabel labelFloor;
        protected ITTLabel labelPreDischargeLimit;
        protected ITTEnumComboBox ResSectionTypeResSection;
        protected ITTLabel labelResSectionTypeResSection;
        protected ITTLabel lblTakipTipi;
        override protected void InitializeControls()
        {
            IsAllowAppointment = (ITTCheckBox)AddControl(new Guid("52b18c66-4b57-4135-aead-1ad3875cf80f"));
            labelResFloor = (ITTLabel)AddControl(new Guid("7468a49c-5358-47b7-a77e-202d76450131"));
            ResFloor = (ITTObjectListBox)AddControl(new Guid("688641c0-0a39-4dbb-b0af-8fec3706926a"));
            labelBedProcedureType = (ITTLabel)AddControl(new Guid("de82eacd-1cb8-4c11-8482-48e0b6cc6e8e"));
            BedProcedureType = (ITTEnumComboBox)AddControl(new Guid("5b27831f-2020-46b1-a3eb-f165c612a5f5"));
            IsIntensiveCare = (ITTCheckBox)AddControl(new Guid("01445c82-3cb6-45d9-857d-eda08be68a59"));
            TakipTipi = (ITTListDefComboBox)AddControl(new Guid("cd9380a0-1a90-43c4-804a-42e8358321d8"));
            HasCertificate = (ITTCheckBox)AddControl(new Guid("75fdc96d-271c-4b38-a83a-80d64c8ade5a"));
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("239e8445-4e03-4410-800a-4694d104b04b"));
            labelLocation = (ITTLabel)AddControl(new Guid("abaa6fdd-2853-4bc9-82a8-28ba313b32bd"));
            Location = (ITTTextBox)AddControl(new Guid("b3605276-fb7c-47de-9f26-665b99ce3b0e"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("22a38ff5-8b72-4be8-9a32-de66627e212d"));
            EtiquetteCount = (ITTTextBox)AddControl(new Guid("60a45bc2-f68a-4bd2-b70a-86c6e453abd5"));
            PercentageOfEmptyBedFor112 = (ITTTextBox)AddControl(new Guid("3ac72093-d875-44b4-a179-8c05f18e1110"));
            InpatientQuota = (ITTTextBox)AddControl(new Guid("147c7f2e-c80f-4ae6-a6f9-56e38866c545"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("58728936-4e09-45b4-b70c-9c2a5875222f"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0c4e0292-7e34-4c5b-98f7-f44ebab5f613"));
            Floor = (ITTTextBox)AddControl(new Guid("9cd9d8ed-1dfd-4619-b020-21b4c1310c66"));
            PreDischargeLimit = (ITTTextBox)AddControl(new Guid("56bd57c2-a0ab-41ee-b7dc-f42a21f43a7c"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("9f63c049-4905-4a56-8f95-50fcd664ab19"));
            HimssRequired = (ITTCheckBox)AddControl(new Guid("8466c1ad-e10c-4a87-84f1-d34899677eae"));
            labelSaglikNetKlinikleri = (ITTLabel)AddControl(new Guid("b5799877-cee8-42d0-a6a5-4e5b699846f6"));
            SaglikNetKlinikleri = (ITTObjectListBox)AddControl(new Guid("18ae7e73-0fc9-470e-905e-9dc17c09e1f4"));
            IsEtiquettePrinted = (ITTCheckBox)AddControl(new Guid("f038054a-8edb-4003-87ad-ebe8e3b053c8"));
            labelEtiquetteCount = (ITTLabel)AddControl(new Guid("a5491da8-0556-45a0-bd4b-834bd38d1973"));
            PCSInUse = (ITTCheckBox)AddControl(new Guid("dae4d2c2-0d3e-4385-8fa6-342c58db373c"));
            IsToBeConsultation = (ITTCheckBox)AddControl(new Guid("67bfc9e7-09c5-4dc4-9099-947a4c7c97e8"));
            labelPercentageOfEmptyBedFor112 = (ITTLabel)AddControl(new Guid("cc404b45-ecf7-4f49-8607-a4fe716a121c"));
            labelRes112ClinicDef = (ITTLabel)AddControl(new Guid("ac8a3e80-d525-46e5-bccf-1636eb362cb8"));
            Res112ClinicDef = (ITTObjectListBox)AddControl(new Guid("4e0c8c57-30fb-4838-8405-97bff1896354"));
            labelInpatientQuota = (ITTLabel)AddControl(new Guid("f31de4e9-d8a7-45a5-ad15-c99f40850fde"));
            IgnoreQuotaControl = (ITTCheckBox)AddControl(new Guid("62691d43-0342-49eb-b727-ef0e8454a07b"));
            labelStore = (ITTLabel)AddControl(new Guid("96dc4fb4-d1f2-4597-bda6-ed383c4dbb16"));
            labelDepartment = (ITTLabel)AddControl(new Guid("d395fa63-628a-4f7c-9be7-cb4534c4e9bc"));
            Department = (ITTObjectListBox)AddControl(new Guid("c27e81b3-7672-4ad1-8107-e614c5580859"));
            IsEmergencyClinic = (ITTCheckBox)AddControl(new Guid("9a7f3d1e-e5d8-4e84-ac2f-4e7e4ca15961"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8b1c26bd-f5cc-41b8-9898-b2b52e8a5e2e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("081b0258-bb3b-4582-b49f-433a6704402e"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("f79b0f7f-6632-4679-a33d-28c7c97565f2"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("5624f865-e05f-4c5b-b6c2-3c199d768cca"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b1045766-5802-470d-8c5a-d2993ebdf95d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cdbdcacb-f603-4ff6-adba-dfaa28af5ad0"));
            Store = (ITTObjectListBox)AddControl(new Guid("7b6908fe-f076-49ae-b736-cd4bee52e85d"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("487aeb49-3529-4f5f-83c6-bf98a701eddc"));
            TedaviTipi = (ITTListDefComboBox)AddControl(new Guid("12540baa-7c99-4b31-b591-f6771f5c5588"));
            TedaviTuru = (ITTListDefComboBox)AddControl(new Guid("41c50d65-ab16-40f2-85db-b021a6282823"));
            lblTedaviTipi = (ITTLabel)AddControl(new Guid("77d05fff-10fa-4b85-9495-e9a20d3b29ad"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("ec282b00-3814-40f2-81a2-3bfe6c03c682"));
            labelFloor = (ITTLabel)AddControl(new Guid("9759b32b-da29-4cb9-8179-9ba9d7ffd14b"));
            labelPreDischargeLimit = (ITTLabel)AddControl(new Guid("e283241d-a4ac-499a-866b-ef953435fcfa"));
            ResSectionTypeResSection = (ITTEnumComboBox)AddControl(new Guid("8f9fd3cb-0e6f-4e56-930c-a01c7c3b0a93"));
            labelResSectionTypeResSection = (ITTLabel)AddControl(new Guid("60120f89-d3a2-48de-a9ac-a508238b5c49"));
            lblTakipTipi = (ITTLabel)AddControl(new Guid("9f73fa6f-b582-434a-9a3e-525e0517d8f5"));
            base.InitializeControls();
        }

        public ClinicDefinitionForm() : base("RESCLINIC", "ClinicDefinitionForm")
        {
        }

        protected ClinicDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}