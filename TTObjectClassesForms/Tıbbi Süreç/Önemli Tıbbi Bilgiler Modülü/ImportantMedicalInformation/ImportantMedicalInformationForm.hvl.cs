
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
    /// Önemli Tıbbi Bilgiler
    /// </summary>
    public partial class ImportantMedicalInformationForm : EpisodeActionForm
    {
    /// <summary>
    /// Hastanın Önemli Tıbbi Bilgilerinin Grişinin Yapıldığı Nesnedir.
    /// </summary>
        protected TTObjectClasses.ImportantMedicalInformation _ImportantMedicalInformation
        {
            get { return (TTObjectClasses.ImportantMedicalInformation)_ttObject; }
        }

        protected ITTCheckBox IsPregnant;
        protected ITTButton ttbutton1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PatientHistory;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelIllnessAndOperation;
        protected ITTLabel ttlabel2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTRichTextBoxControl rtfOrganInfo;
        protected ITTLabel ttlabel3;
        protected ITTTabPage AllergyVaccination;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Reaction;
        protected ITTEnumComboBoxColumn Risk2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelAllergyInformation;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn Aşı;
        protected ITTTextBoxColumn Geçerliliği;
        protected ITTEnumComboBoxColumn Risk;
        protected ITTTabPage HistoryInfo;
        protected ITTRichTextBoxControl ttrichtextboxcontrol7;
        protected ITTRichTextBoxControl ttrichtextboxcontrol10;
        protected ITTRichTextBoxControl ttrichtextboxcontrol9;
        protected ITTRichTextBoxControl ttrichtextboxcontrol8;
        protected ITTLabel labelBloodGroup;
        protected ITTCheckBox WarnAllMedicalPersonnel;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage DiagnosisHistoryInfo;
        protected ITTGrid DiagnosisHistory;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTListBoxColumn Diagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTTabPage CancelledDiagnosisInfo;
        protected ITTGrid CancelledDiagnosis;
        protected ITTDateTimePickerColumn CancelledDiagnoseDate;
        protected ITTListBoxColumn CancelledDiagnose;
        protected ITTListBoxColumn CancelDiagnoseUser;
        protected ITTEnumComboBox BloodGroup;
        override protected void InitializeControls()
        {
            IsPregnant = (ITTCheckBox)AddControl(new Guid("6d35c289-a944-49ad-8eae-0e4a2bdaff9a"));
            ttbutton1 = (ITTButton)AddControl(new Guid("f20cc673-6e37-4f01-8650-d6c3434220a3"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("21066d1a-c856-441b-a65b-23df737ae229"));
            PatientHistory = (ITTTabPage)AddControl(new Guid("efcfa3d4-043e-45ea-82d8-799d7c73f340"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("ced85818-0181-4b0a-a8ae-bc5cc27e416f"));
            labelIllnessAndOperation = (ITTLabel)AddControl(new Guid("4c1e7483-852e-40d3-aba5-31c1f20b1c34"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("19faa7a4-f3c2-4e97-a9e8-a97a69f6b9d9"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("d6c7067d-7b44-46e1-a388-6862a21c425a"));
            rtfOrganInfo = (ITTRichTextBoxControl)AddControl(new Guid("575b41ba-e7f0-4a37-be51-f4fefd4015be"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d1c50923-a0b9-4cae-92a9-e1b95e3d802e"));
            AllergyVaccination = (ITTTabPage)AddControl(new Guid("31574ddb-2447-49db-88b1-90479b23a985"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("5b2f36f6-3e4b-4fb7-b787-cc19af971795"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("6f0b2e2e-b53f-4200-9e17-a9c6d97b7d39"));
            Reaction = (ITTTextBoxColumn)AddControl(new Guid("bd793fae-bc62-4ffc-aab5-83a4e39eaf87"));
            Risk2 = (ITTEnumComboBoxColumn)AddControl(new Guid("c8b93cf3-3f49-4b3e-b2a7-b636310e9995"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e50fe733-24d6-453b-b050-570cb3093c1b"));
            labelAllergyInformation = (ITTLabel)AddControl(new Guid("5e9597e2-10e9-4bc2-99ec-85eecd61471f"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("affc841b-7000-4841-afb2-624ef623ec84"));
            Aşı = (ITTTextBoxColumn)AddControl(new Guid("72335442-aa20-420e-8009-ba9257dab824"));
            Geçerliliği = (ITTTextBoxColumn)AddControl(new Guid("d6c7476a-deda-407f-abac-592f6dd2fdfc"));
            Risk = (ITTEnumComboBoxColumn)AddControl(new Guid("9f43c875-e905-4912-81c2-634f4d9e9ee3"));
            HistoryInfo = (ITTTabPage)AddControl(new Guid("4d10f817-4e81-4939-b2b8-1d96b29ea732"));
            ttrichtextboxcontrol7 = (ITTRichTextBoxControl)AddControl(new Guid("12b24b00-198e-41d4-b045-ac963dcb50c7"));
            ttrichtextboxcontrol10 = (ITTRichTextBoxControl)AddControl(new Guid("6f2a48f9-fca8-4de8-b262-f12cd74a4bc9"));
            ttrichtextboxcontrol9 = (ITTRichTextBoxControl)AddControl(new Guid("ef63d630-aebb-4053-a5e5-f806f684d968"));
            ttrichtextboxcontrol8 = (ITTRichTextBoxControl)AddControl(new Guid("f5a2bcf0-5792-4661-85f8-903e51648c19"));
            labelBloodGroup = (ITTLabel)AddControl(new Guid("40de9106-549c-4c38-b6f9-0d65ad579edc"));
            WarnAllMedicalPersonnel = (ITTCheckBox)AddControl(new Guid("a055b870-af0e-42d7-b7b7-534892569144"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("8cd39665-c1cc-4c44-9a12-69e44060dce1"));
            DiagnosisHistoryInfo = (ITTTabPage)AddControl(new Guid("6c215f4c-ceaf-4afb-b37c-15dec3197e47"));
            DiagnosisHistory = (ITTGrid)AddControl(new Guid("543fd414-e302-4941-9be0-9ab3c3c20451"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("048cd483-5fea-4fa6-80e0-1ab1270a7d96"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("32547fdc-2af9-477e-a395-7ea4a8c73d5e"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("702e7a65-5feb-47f6-b618-9d46989399a4"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("1ce2a097-2513-4fbf-9499-788fd58e1286"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("86eba700-5320-4dce-8471-be2c2b0affd3"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a95ccbc8-c589-4ba5-83e8-64e183369edc"));
            CancelledDiagnosisInfo = (ITTTabPage)AddControl(new Guid("a7ae7287-cfd4-4739-82ca-a998b7b10313"));
            CancelledDiagnosis = (ITTGrid)AddControl(new Guid("7fda6df2-35d2-4669-b343-fc0576f7844d"));
            CancelledDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("b230fffc-b7e6-46a0-b895-e2475f19d1a1"));
            CancelledDiagnose = (ITTListBoxColumn)AddControl(new Guid("27287808-f9af-49d2-a2d2-04c3d872641b"));
            CancelDiagnoseUser = (ITTListBoxColumn)AddControl(new Guid("680fc28a-e096-4302-807d-bc989a3d819c"));
            BloodGroup = (ITTEnumComboBox)AddControl(new Guid("10a7f462-dab3-49aa-859c-ac1bf3391525"));
            base.InitializeControls();
        }

        public ImportantMedicalInformationForm() : base("IMPORTANTMEDICALINFORMATION", "ImportantMedicalInformationForm")
        {
        }

        protected ImportantMedicalInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}