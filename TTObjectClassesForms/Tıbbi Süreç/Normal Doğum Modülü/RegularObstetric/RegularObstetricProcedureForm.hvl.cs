
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
    /// Normal Doğum İşlemleri
    /// </summary>
    public partial class RegularObstetricProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Normal Doğum
    /// </summary>
        protected TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get { return (TTObjectClasses.RegularObstetric)_ttObject; }
        }

        protected ITTRichTextBoxControl NoteRTF;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn RegularObstetricActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn RegularObstetricDoctor;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTListDefComboBoxColumn AyniFarkliKesi;
        protected ITTListDefComboBoxColumn OzelDurum;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn StockOutAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTListDefComboBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        override protected void InitializeControls()
        {
            NoteRTF = (ITTRichTextBoxControl)AddControl(new Guid("fc60a6ef-3c75-42a4-a721-b395233f0c3c"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("02075aca-944d-44ef-abd5-28b2f08a1113"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("cd0b36fd-e59e-4a1d-afb1-320d43544016"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d56d6d3f-9ee0-4b50-a090-43f694b3c3c1"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("1c968546-ef4b-4cab-bec6-0c55075b11f0"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("8f69621e-58ba-4427-94f2-8bb02377cd78"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("4a4128f6-d3b8-4a93-8e35-fb032c618a57"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("3e5d46ac-b8de-4514-92e1-2a29d24a18a3"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e8882d5b-9e75-4aaa-9664-b20c3664b957"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("993de977-e826-43ce-a7d2-5a13758a4be4"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("56f64db8-bec7-4d92-b1c3-3a51b01dafab"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("908a96e7-68e2-41f8-a2a3-9e356aa3f926"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("37e07656-7165-48a2-b662-e69aa2d6307a"));
            GridManipulations = (ITTGrid)AddControl(new Guid("874135d1-62f3-46d1-8224-cfaabd716209"));
            RegularObstetricActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("ec7db18c-cd86-4936-a54a-4c518a3a8f4e"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5d42ec18-ef2a-49d2-8741-55e238aab9c3"));
            RegularObstetricDoctor = (ITTListBoxColumn)AddControl(new Guid("81ed1930-8500-4b87-9dc3-e05eceb821eb"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("e381d7aa-1c5b-4e2d-b85f-74d583bd62cd"));
            AyniFarkliKesi = (ITTListDefComboBoxColumn)AddControl(new Guid("10366d3e-f667-49a7-9998-e39e8d2e4fc5"));
            OzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("58dfaadb-a76b-40f4-94f8-a6cb5c6f4f76"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("14572b1a-cb03-4faa-bd27-ef6f3472d4cb"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("b0551abf-9599-4302-b74a-189c287f9ccf"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("5cae3851-2911-48f0-9a25-5a41d61770ee"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("6d3e73bb-b32e-4363-a7de-ddf25263ba2e"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("c885589b-f4ec-48ce-a715-5f0eb2c94bd0"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("9a4be45f-79b4-4483-bcc9-e428b0549161"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("ac493074-cd32-4be2-9523-2c655fe3e604"));
            Material = (ITTListBoxColumn)AddControl(new Guid("6e7a672b-c935-45b0-921b-6d0aafe8b005"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b5fbc077-78fc-42e7-8680-fd05712bb90f"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("73f10cbd-d42e-44e3-927b-fa21ee935d37"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("60e6486f-a30d-4c05-99f6-257e01312b62"));
            StockOutAmount = (ITTTextBoxColumn)AddControl(new Guid("858ddd7a-3505-4883-a5fc-8a062b7cda07"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("9a40cf67-ece1-4166-a8b3-4bf2cfc979a5"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("0a8c6830-b0b6-43de-a20f-fbd2882ab1de"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("e562eacb-b1b7-4217-9d01-fb6ce12b740d"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("0b040417-77c3-4464-9b3f-2566fcc4b82a"));
            MalzemeTuru = (ITTListDefComboBoxColumn)AddControl(new Guid("b026f9db-59d5-4e0c-9788-2e1c7fdb1c33"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("3d71186f-829f-4835-819d-ded53677d8a7"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("1e42d74a-f425-4cf0-b0b6-b88528075b39"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("3a152c54-f8bf-435b-8990-40df8be26cee"));
            base.InitializeControls();
        }

        public RegularObstetricProcedureForm() : base("REGULAROBSTETRIC", "RegularObstetricProcedureForm")
        {
        }

        protected RegularObstetricProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}