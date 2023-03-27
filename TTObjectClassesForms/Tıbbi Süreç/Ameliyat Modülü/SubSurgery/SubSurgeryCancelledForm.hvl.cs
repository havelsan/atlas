
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
    /// New Form
    /// </summary>
    public partial class SubSurgeryCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Aynı Seansda Birden Fazla Bölüm Ameliyat Gerçekleştirdiğinde Diğer Bölümler İçin Kullanılan Nesnedir 
    /// </summary>
        protected TTObjectClasses.SubSurgery _SubSurgery
        {
            get { return (TTObjectClasses.SubSurgery)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker SurgeryEndTime;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelSurgeryStartTime;
        protected ITTDateTimePicker SurgeryStartTime;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRoom;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl TabOperative;
        protected ITTTabPage CancelledReasonInfo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTabPage SurgeryInfo;
        protected ITTRichTextBoxControl TabSubaction;
        protected ITTTabControl Ameliyat;
        protected ITTTabPage MainSurgeryProcedures;
        protected ITTGrid GridSubSurgeryProcedures;
        protected ITTDateTimePickerColumn MSActionDate;
        protected ITTListBoxColumn MSProcedureObject;
        protected ITTEnumComboBoxColumn MSIncisionType;
        protected ITTEnumComboBoxColumn MSPosition;
        protected ITTRichTextBoxControlColumn DescOfObj;
        protected ITTButtonColumn EnterSurgeryPersonel;
        protected ITTTabPage SurgeryProcedures;
        protected ITTGrid GridSurgeryProcedures;
        protected ITTDateTimePickerColumn CAActionDate;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTEnumComboBoxColumn IncisionType;
        protected ITTEnumComboBoxColumn Position;
        protected ITTRichTextBoxControlColumn DescriptionOfObject;
        protected ITTListBoxColumn EntryDepartment;
        protected ITTTabPage SurgeryTeam;
        protected ITTGrid GridSurgeryPersonnels;
        protected ITTListBoxColumn SurgeryPersonnel;
        protected ITTEnumComboBoxColumn CARole;
        protected ITTTabPage SurgeryExpend;
        protected ITTGrid GridSurgeryExpends;
        protected ITTDateTimePickerColumn CMActionDate;
        protected ITTListBoxColumn CAMaterial;
        protected ITTTextBoxColumn CAAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage PreOperativeInfo;
        protected ITTGrid GridPreOpApplications;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTRichTextBoxControl PreOpDescriptions;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelSurgeryDesk;
        protected ITTObjectListBox SurgeryDesk;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("a111fe89-9fd6-4515-b714-6f8648f75e0a"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("9520c8a7-77a4-46d8-baca-c6952b2c0b2e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("69af87f0-6004-4aa5-a344-3b3f12fd3ae2"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("14576461-6682-4117-becb-5499dc9cfd75"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("8bb4f285-2921-4903-a2d2-d684fa0394cd"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("3e112d30-7771-46eb-96da-3430452f2f51"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("47cdec52-7e6a-4e27-a529-eb8aba598285"));
            SurgeryEndTime = (ITTDateTimePicker)AddControl(new Guid("4e031012-3b74-4199-b3b1-c9a129e98b38"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("23ba2fc0-f501-47d8-8c7f-b558d3ca22e4"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c5203234-425e-4294-992e-45d372b94c02"));
            Emergency = (ITTCheckBox)AddControl(new Guid("f2054447-3739-4e51-af0d-26125a63d0c7"));
            labelSurgeryStartTime = (ITTLabel)AddControl(new Guid("cdf5d232-8e47-41d7-9fbe-803d91ee67ba"));
            SurgeryStartTime = (ITTDateTimePicker)AddControl(new Guid("7f90a172-c801-4ccf-8972-4199786bc4ac"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8d626717-952e-4a09-a539-55d134a5bdc1"));
            labelRoom = (ITTLabel)AddControl(new Guid("7b92edc4-0131-4c6a-b144-c07794384d02"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("21ff4116-5116-444b-a763-64f19ec0c6d7"));
            TabOperative = (ITTTabControl)AddControl(new Guid("86234f08-eba5-47fa-9813-6e916d52bbac"));
            CancelledReasonInfo = (ITTTabPage)AddControl(new Guid("be4aa27a-80ff-4d7e-9279-68d14e6bd2a7"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("ea2cdb30-5af8-47f5-8597-cfea999875d0"));
            SurgeryInfo = (ITTTabPage)AddControl(new Guid("69b9aa32-237f-48e4-80d8-6129933d9b0a"));
            TabSubaction = (ITTRichTextBoxControl)AddControl(new Guid("e57fdb9b-2512-45f8-be28-44338850d7c8"));
            Ameliyat = (ITTTabControl)AddControl(new Guid("1d27c8da-a9d3-4413-ba52-605da5622522"));
            MainSurgeryProcedures = (ITTTabPage)AddControl(new Guid("1266e12e-3b2c-41e8-87f7-c13b7a8c5244"));
            GridSubSurgeryProcedures = (ITTGrid)AddControl(new Guid("d9e1f702-7962-40f6-b718-f4e2b2faa6cb"));
            MSActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("26c23c6e-e279-4c12-a310-e5066217386d"));
            MSProcedureObject = (ITTListBoxColumn)AddControl(new Guid("9fcadb3b-2561-4dac-aca5-07863a575fc8"));
            MSIncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("6c162517-620f-4dfe-9df3-747b48decfd6"));
            MSPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("1103aed3-bdff-4434-a4d0-c85bcb2a98e1"));
            DescOfObj = (ITTRichTextBoxControlColumn)AddControl(new Guid("3b956bf0-970d-47b3-9999-c54afb9477c2"));
            EnterSurgeryPersonel = (ITTButtonColumn)AddControl(new Guid("01b6d7fe-80d4-4db8-9ea6-16123ba7ebfb"));
            SurgeryProcedures = (ITTTabPage)AddControl(new Guid("26c1cbb8-71a3-48c8-9be1-53c9f059a481"));
            GridSurgeryProcedures = (ITTGrid)AddControl(new Guid("c67021d4-ff2f-4f04-9e7e-541279a5843a"));
            CAActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("4f1ff861-3c13-42f6-9697-dbb3e483e68b"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("d1fc8bd8-2801-41ce-ace8-7652db9d4cba"));
            IncisionType = (ITTEnumComboBoxColumn)AddControl(new Guid("c1f9fbf9-2f01-4150-a99d-7ae509e849a4"));
            Position = (ITTEnumComboBoxColumn)AddControl(new Guid("b59411c9-e78b-4186-a281-fbd8bfbe3ff8"));
            DescriptionOfObject = (ITTRichTextBoxControlColumn)AddControl(new Guid("da9a6afe-2e52-43da-8a87-b720e785311f"));
            EntryDepartment = (ITTListBoxColumn)AddControl(new Guid("7cea34a3-b526-4dce-bc92-f676ab759fc9"));
            SurgeryTeam = (ITTTabPage)AddControl(new Guid("0aaf07b1-b035-4647-915b-2e8e1c677f0e"));
            GridSurgeryPersonnels = (ITTGrid)AddControl(new Guid("40ce6c63-f773-4079-9c50-9c3056d8a9ac"));
            SurgeryPersonnel = (ITTListBoxColumn)AddControl(new Guid("7cbfb23b-7956-4e91-a674-76de7c0a2568"));
            CARole = (ITTEnumComboBoxColumn)AddControl(new Guid("f0e0df6d-cee1-45af-9370-240df1c5fe49"));
            SurgeryExpend = (ITTTabPage)AddControl(new Guid("7c5ae741-6711-4f49-adc1-4fabb9894fce"));
            GridSurgeryExpends = (ITTGrid)AddControl(new Guid("a4182eca-f082-4763-93e3-d9e18f5cbe02"));
            CMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("e24001dd-453f-4269-bf67-ca192e874a82"));
            CAMaterial = (ITTListBoxColumn)AddControl(new Guid("9b91f307-771f-4aab-84e3-816a5562a18d"));
            CAAmount = (ITTTextBoxColumn)AddControl(new Guid("fbe7e5b5-81ec-4f47-81a9-e471d127a577"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("ca51ba99-2fb5-4db3-801d-95284941a45b"));
            PreOperativeInfo = (ITTTabPage)AddControl(new Guid("5dca2ed2-83d1-41ab-9c58-2ef9e2b933d6"));
            GridPreOpApplications = (ITTGrid)AddControl(new Guid("f5c31049-ef13-46f9-9e90-8041968b65f4"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9583f873-511d-4be4-b988-55be68fb1efe"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("b34387a2-4476-4f42-b3dd-58153a7fcac0"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("65ee5561-ff2f-42d3-ab5e-8ba95d886fcd"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("0d38825d-2607-4921-9134-dd840909804b"));
            PreOpDescriptions = (ITTRichTextBoxControl)AddControl(new Guid("1803072a-48d1-4103-b206-c31400939638"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("0ae67c19-381f-4d0d-9987-a5e5cb6866c8"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("6c23ed0b-0e91-41e5-ab03-5513fc3fee32"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("69093eb9-b866-442c-9d99-66a8976f1afd"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("4e75c992-1e65-41b2-8231-f06f2b3df8c4"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ee132cff-8e23-4f98-9c37-74a093495422"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b75bbd78-edf8-489f-8fbf-e893d0fea684"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3244c85f-d12d-4a44-b8f9-fa8ddd0d0c12"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("83d489f8-d0e4-4bb2-8af3-713c38ca52c6"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a5265eee-1b6d-4676-bfce-91af63f07e1a"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("64a6f628-75b6-41ab-b372-351051e842af"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1983c3cd-b5b2-4c5e-b754-6d6ae42b1ca9"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3d8c2d2b-fed1-4ed8-a838-6b14e7ae9c6c"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ac670812-2828-45cd-acf0-cf9268078aa9"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("53c6b0ee-64a4-4e8e-848c-b0799b74849f"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ee0272e8-eeb3-4055-9456-8e9fb241b096"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ba6b2057-8df2-42bc-9f50-f9a8378a8e45"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("dcba885e-24ab-450d-bfd2-582f018815ca"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("9ccfe5c1-c4c6-4b6a-b2d5-d54931d046af"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("c9b27284-0b40-4164-89b8-6a48e1f68954"));
            base.InitializeControls();
        }

        public SubSurgeryCancelledForm() : base("SUBSURGERY", "SubSurgeryCancelledForm")
        {
        }

        protected SubSurgeryCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}