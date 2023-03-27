
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
    public partial class PoliclinicDefinitionForm : TTForm
    {
    /// <summary>
    /// Poliklinik
    /// </summary>
        protected TTObjectClasses.ResPoliclinic _ResPoliclinic
        {
            get { return (TTObjectClasses.ResPoliclinic)_ttObject; }
        }

        protected ITTListDefComboBox TedaviTipi;
        protected ITTListDefComboBox TedaviTuru;
        protected ITTLabel lblTedaviTipi;
        protected ITTLabel lblTedaviTuru;
        protected ITTLabel labelASALCode;
        protected ITTTextBox ASALCode;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTCheckBox PatientCallSystemInUse;
        protected ITTLabel labelStore;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTGroupBox Quotas;
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
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox Type;
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTLabel labelResSectionTypeResSection;
        protected ITTEnumComboBox ResSectionTypeResSection;
        protected ITTCheckBox HimssRequired;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTCheckBox IsmedicalWaste;
        override protected void InitializeControls()
        {
            TedaviTipi = (ITTListDefComboBox)AddControl(new Guid("78d1b10c-6c11-42d9-984d-6ea2b924ec89"));
            TedaviTuru = (ITTListDefComboBox)AddControl(new Guid("85c792a0-8c50-432a-8452-115de9c31573"));
            lblTedaviTipi = (ITTLabel)AddControl(new Guid("bdeb7085-77c3-44e7-9101-4581bf673a6d"));
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("fea22acd-df33-4b23-8191-e161b3e01f26"));
            labelASALCode = (ITTLabel)AddControl(new Guid("b558334d-8271-41db-aff5-8472802c870d"));
            ASALCode = (ITTTextBox)AddControl(new Guid("d6092f72-d8d0-4da9-9874-fcf8ad29212f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a19ad134-9b01-486d-8eaa-78cf971ea25f"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("6b545611-5125-461c-9054-2e52ddc5a5e5"));
            Location = (ITTTextBox)AddControl(new Guid("fa9f65fc-2c2f-4392-b862-16bc339e542c"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("0b9e56af-436e-4113-8f1f-4221a07afd11"));
            PatientCallSystemInUse = (ITTCheckBox)AddControl(new Guid("2aec9b31-053e-45d4-a47b-b3162067cdbe"));
            labelStore = (ITTLabel)AddControl(new Guid("524cf262-2814-4b87-9539-fe5ad904f47c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0f033dbd-60ad-403b-ae36-6c6989da5aaf"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6bad0f1c-a586-464f-8a7b-08aa87f1bf51"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("241e5383-c9d6-496c-b977-fc3886f24a18"));
            Store = (ITTObjectListBox)AddControl(new Guid("eeca8c02-63ce-4d2d-8d73-cc1f6a40ffa3"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("704ced7b-479a-46ef-bc87-078fc1bb2dee"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b0ee120f-b9e3-4198-9242-d12e33ecd33e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("492f75c4-3f02-42af-9f27-c49b60324348"));
            Quotas = (ITTGroupBox)AddControl(new Guid("a2d7c641-35bf-4ed3-8ece-32dc8a9047a1"));
            labelJanuaryQuota = (ITTLabel)AddControl(new Guid("fdfc2dfc-846b-4942-8a3d-b1b58b007e88"));
            labelSeptemberQuota = (ITTLabel)AddControl(new Guid("eff695f3-1e28-41cc-837d-9e4b8f57012e"));
            AprilQuota = (ITTTextBox)AddControl(new Guid("58a9c20d-8c25-4b97-9aec-73a86d45f188"));
            SeptemberQuota = (ITTTextBox)AddControl(new Guid("8331b2d4-1c7b-4b82-8573-2fa4eac499f4"));
            labelAprilQuota = (ITTLabel)AddControl(new Guid("83f2a041-c886-4b4e-bce1-99c7960d131f"));
            labelOctoberQuota = (ITTLabel)AddControl(new Guid("ef9d91e8-347d-4623-8aca-443792a8511e"));
            August = (ITTTextBox)AddControl(new Guid("1c20b7c6-a6db-4b0c-863a-23b1d29d83cb"));
            OctoberQuota = (ITTTextBox)AddControl(new Guid("cc7d9c82-5759-483f-928b-438ae2ce52ca"));
            labelAugust = (ITTLabel)AddControl(new Guid("33742278-446f-45f1-9fe2-2c71805dd8d8"));
            labelNovemberQuota = (ITTLabel)AddControl(new Guid("e6a8f8b5-6335-48c6-b082-c8d04ba87330"));
            DecemberQuota = (ITTTextBox)AddControl(new Guid("74ae7ded-3722-401e-b99f-bc7a73cc0e39"));
            NovemberQuota = (ITTTextBox)AddControl(new Guid("6eb650ed-8aee-481c-bcac-9fee2f4312b5"));
            labelDecemberQuota = (ITTLabel)AddControl(new Guid("91a609c8-ddb2-4b1b-9291-039f5254caa4"));
            labelMayQuota = (ITTLabel)AddControl(new Guid("8140877e-99a6-422a-ba84-ef9aea06f5e9"));
            FebruaryQuota = (ITTTextBox)AddControl(new Guid("6bf20561-778a-45e0-bba2-382da8b6bbab"));
            MayQuota = (ITTTextBox)AddControl(new Guid("0abae2a8-0a99-45bf-bec1-65d2c6d70bce"));
            labelFebruaryQuota = (ITTLabel)AddControl(new Guid("d6b266c4-d6a7-4356-9ab3-3e7163590c9e"));
            labelMarchQuota = (ITTLabel)AddControl(new Guid("030ceb68-8a0d-45b6-8815-e33a550a60fa"));
            JanuaryQuota = (ITTTextBox)AddControl(new Guid("1fa94dd8-24c9-49d7-82e9-db25c5598bc9"));
            MarchQuota = (ITTTextBox)AddControl(new Guid("64128d2c-68a5-4ca1-808c-d5c2c6b0c46e"));
            JulyQuota = (ITTTextBox)AddControl(new Guid("c399e1f8-97a9-4313-baf6-0c8c899cd438"));
            labelJuneQuata = (ITTLabel)AddControl(new Guid("7552709d-3e09-4dd8-8cf0-bc1779f869f9"));
            labelJulyQuota = (ITTLabel)AddControl(new Guid("87621fb9-05ea-4059-83ef-52e1209943a4"));
            JuneQuata = (ITTTextBox)AddControl(new Guid("49205c97-4db9-4a02-b611-b4c8e881014f"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("f27e6a83-f536-4274-8ad5-ff697c813267"));
            Type = (ITTEnumComboBox)AddControl(new Guid("8c3b049d-3cde-43d3-935d-37b00ef6ee9c"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("348199a5-0b99-432c-a906-3737d7372a59"));
            labelResSectionTypeResSection = (ITTLabel)AddControl(new Guid("f0dbd4bb-d737-4bcf-ac9b-b19fc994dc3c"));
            ResSectionTypeResSection = (ITTEnumComboBox)AddControl(new Guid("6d86166f-5678-451b-9cce-a933142d88b9"));
            HimssRequired = (ITTCheckBox)AddControl(new Guid("63119d32-db93-4db3-bea5-d901cee3142b"));
            labelLocation = (ITTLabel)AddControl(new Guid("8b1c1973-c13d-45f9-8800-749e86f177a3"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("ab2ba873-aaa4-4d27-9d40-368f3e7991ba"));
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("4259ed0c-dd12-4b81-a15a-b2073ccf4403"));
            base.InitializeControls();
        }

        public PoliclinicDefinitionForm() : base("RESPOLICLINIC", "PoliclinicDefinitionForm")
        {
        }

        protected PoliclinicDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}