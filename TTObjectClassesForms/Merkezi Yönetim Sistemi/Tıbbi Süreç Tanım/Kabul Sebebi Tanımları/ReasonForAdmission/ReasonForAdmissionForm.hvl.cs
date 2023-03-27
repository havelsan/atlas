
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
    /// Kabul Sebebi Tanımları
    /// </summary>
    public partial class ReasonForAdmissionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kabul Sebebi Tanımları
    /// </summary>
        protected TTObjectClasses.ReasonForAdmission _ReasonForAdmission
        {
            get { return (TTObjectClasses.ReasonForAdmission)_ttObject; }
        }

        protected ITTCheckBox RequiresFinancialDepControl;
        protected ITTCheckBox AllowedForInpatientAdmission;
        protected ITTCheckBox IgnoreMedula;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ReasourcesTab;
        protected ITTGrid RelatedResources;
        protected ITTListBoxColumn Resource;
        protected ITTEnumComboBoxColumn ActionType;
        protected ITTCheckBoxColumn GetAutorizeUserList;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTEnumComboBoxColumn ttcomboboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTabPage MedulaTab;
        protected ITTListDefComboBox provizyonTipi;
        protected ITTLabel labelprovizyonTipi;
        protected ITTListDefComboBox tedaviTuru;
        protected ITTLabel labeltedaviTuru;
        protected ITTListDefComboBox takipTipi;
        protected ITTLabel ttlabelTedaviTipi;
        protected ITTListDefComboBox tedaviTipi;
        protected ITTLabel ttlabelTakipTipi;
        protected ITTListDefComboBox sigortaliTuru;
        protected ITTLabel labelIstisnaiHal;
        protected ITTLabel labelsigortaliTuru;
        protected ITTListDefComboBox devredilenKurum;
        protected ITTLabel labeldevredilenKurum;
        protected ITTListDefComboBox istisnaiHal;
        protected ITTTextBox Code;
        protected ITTCheckBox IgnoreTenDaysRule;
        protected ITTCheckBox IgnoreQuota;
        protected ITTLabel labelType;
        protected ITTEnumComboBox Type;
        protected ITTEnumComboBox DefualtActionType;
        protected ITTLabel labelDefualtActionType;
        protected ITTCheckBox FireAllRelatedResources;
        protected ITTLabel labelCode;
        protected ITTCheckBox ignoreSpeciality;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelSKRSVakaTuru;
        protected ITTObjectListBox SKRSVakaTuru;
        override protected void InitializeControls()
        {
            RequiresFinancialDepControl = (ITTCheckBox)AddControl(new Guid("594b5d3f-8224-4d3f-9ee9-e99d8d40855c"));
            AllowedForInpatientAdmission = (ITTCheckBox)AddControl(new Guid("bbc9a51c-61e3-4e8a-b2e6-4a89952004cd"));
            IgnoreMedula = (ITTCheckBox)AddControl(new Guid("260d8bbd-2b52-4659-a726-dd037e209d33"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("7c0d5039-9309-4ab6-a799-2b1e33ab266e"));
            ReasourcesTab = (ITTTabPage)AddControl(new Guid("08be2085-872d-4fc9-a911-26f5bae387fb"));
            RelatedResources = (ITTGrid)AddControl(new Guid("80dbdbaf-e7c5-4c2d-be23-129ada41983f"));
            Resource = (ITTListBoxColumn)AddControl(new Guid("7fce4bd8-fbe7-468c-baf3-ec414ade616a"));
            ActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("41a25dba-6eb1-496d-a648-db26c24e1fbc"));
            GetAutorizeUserList = (ITTCheckBoxColumn)AddControl(new Guid("32602e73-9c79-493e-9265-2dff68f52ef2"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("db113f48-cac8-4ea6-bbb4-bc9564549e4c"));
            ttcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("33e144b6-c829-4419-82ed-73876361cfb0"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("7cda24ac-2cdc-4873-a662-9b24c27049a5"));
            MedulaTab = (ITTTabPage)AddControl(new Guid("5d99dc74-0145-4bf3-9977-b725eedebdef"));
            provizyonTipi = (ITTListDefComboBox)AddControl(new Guid("5496ec08-0024-4097-ac98-9a644540a66c"));
            labelprovizyonTipi = (ITTLabel)AddControl(new Guid("21946fc5-4200-4690-8e59-e52b2f11338f"));
            tedaviTuru = (ITTListDefComboBox)AddControl(new Guid("1897864f-738d-4524-8969-68e8dca605fa"));
            labeltedaviTuru = (ITTLabel)AddControl(new Guid("b9f5d02d-6ad2-418e-8357-43ccc4ce563b"));
            takipTipi = (ITTListDefComboBox)AddControl(new Guid("2046e00d-bb70-42c8-a3ad-c18e01041733"));
            ttlabelTedaviTipi = (ITTLabel)AddControl(new Guid("7134bf37-5674-4736-afa0-9d42b69a7dc7"));
            tedaviTipi = (ITTListDefComboBox)AddControl(new Guid("70b23472-ad74-4122-881d-4e02eaac1ba6"));
            ttlabelTakipTipi = (ITTLabel)AddControl(new Guid("2a3e89d9-266e-48c0-b8a3-f9218fd4f0b9"));
            sigortaliTuru = (ITTListDefComboBox)AddControl(new Guid("2dd5b76a-5cae-43ba-bc7a-ecc4175818b4"));
            labelIstisnaiHal = (ITTLabel)AddControl(new Guid("137595f7-53b6-48d2-b7ff-32ce820f872f"));
            labelsigortaliTuru = (ITTLabel)AddControl(new Guid("f020987a-273f-4bed-a055-0edec181cd51"));
            devredilenKurum = (ITTListDefComboBox)AddControl(new Guid("d2bf1086-7f81-4469-a2a4-59b3013c8bcd"));
            labeldevredilenKurum = (ITTLabel)AddControl(new Guid("823d4e00-8dab-4c6f-8877-f78eaa900142"));
            istisnaiHal = (ITTListDefComboBox)AddControl(new Guid("de775e69-b4b5-4c66-87bc-3ea3d6bca1db"));
            Code = (ITTTextBox)AddControl(new Guid("077b2f26-69d2-4cb5-97ec-bb7790d12519"));
            IgnoreTenDaysRule = (ITTCheckBox)AddControl(new Guid("c84f9fdf-8fa4-4421-968a-9ce87bce52b8"));
            IgnoreQuota = (ITTCheckBox)AddControl(new Guid("b51ddf8c-d79b-4f45-ac1e-fe6bafa0fd81"));
            labelType = (ITTLabel)AddControl(new Guid("e2e93c01-2e89-4bda-a7d1-3c765c90cfb5"));
            Type = (ITTEnumComboBox)AddControl(new Guid("f3939f66-3779-43be-9f52-57cf91fbda5f"));
            DefualtActionType = (ITTEnumComboBox)AddControl(new Guid("78ada1f5-4c1f-46bc-af19-7604755c8635"));
            labelDefualtActionType = (ITTLabel)AddControl(new Guid("8dbf8a52-1ce7-430d-adba-766553087e01"));
            FireAllRelatedResources = (ITTCheckBox)AddControl(new Guid("21a3fb14-90aa-48fe-885c-7e8758522c60"));
            labelCode = (ITTLabel)AddControl(new Guid("4c49f6a2-2a3a-4f35-b416-c17ebcd20dd8"));
            ignoreSpeciality = (ITTCheckBox)AddControl(new Guid("f71fe893-ca74-4bc9-aab5-201404d2ba3f"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c37a0c94-9beb-44d5-bb1f-70d9a0c3a4d7"));
            labelSKRSVakaTuru = (ITTLabel)AddControl(new Guid("11914568-e430-4e05-8bfb-454dc36e9f70"));
            SKRSVakaTuru = (ITTObjectListBox)AddControl(new Guid("3c37798d-505a-40b3-a847-e01ad9ef863e"));
            base.InitializeControls();
        }

        public ReasonForAdmissionForm() : base("REASONFORADMISSION", "ReasonForAdmissionForm")
        {
        }

        protected ReasonForAdmissionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}