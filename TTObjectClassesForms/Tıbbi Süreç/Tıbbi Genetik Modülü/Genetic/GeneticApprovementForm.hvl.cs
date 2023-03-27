
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
    /// Tıbbi Genetik Onayda Formu
    /// </summary>
    public partial class GeneticApprovementForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTRichTextBoxControl ReportRTF;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTObjectListBox RejectReason;
        protected ITTCheckBox EmergencyCheckBox;
        protected ITTTabControl TabTextInfos;
        protected ITTTabPage TabPageRequestDesc;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage TabPagePrediagnosis;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTabPage TabPageApprovementDescription;
        protected ITTTextBox ApprovementDescription;
        protected ITTTabControl TabTests;
        protected ITTTabPage TabPageTests;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn TestAmount;
        protected ITTDateTimePickerColumn islemTarihi;
        protected ITTTextBoxColumn birim;
        protected ITTListBoxColumn kesi;
        protected ITTListBoxColumn sagSol;
        protected ITTTextBoxColumn sonuc;
        protected ITTListBoxColumn drAnesteziTescilNo;
        protected ITTListBoxColumn performer;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridGeneticMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTListBoxColumn MATERIAL;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn AMOUNT;
        protected ITTTabPage TabPageEquipments;
        protected ITTGrid GridEquipments;
        protected ITTListBoxColumn Equipment;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox PatientAge;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTTextBoxColumn EntryActionType;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel13;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("2006907d-1573-47d3-b212-12097d8faab0"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a86f7b35-d8b5-4817-b6b4-7348394e16c5"));
            ReportRTF = (ITTRichTextBoxControl)AddControl(new Guid("963a86ad-61a2-48de-a777-6caa74aa73b9"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("0ea3bcb2-c28c-4ec8-81bb-94c15ca0bb7d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8dd84265-d005-471d-b2e9-36953f45ab22"));
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("f0a4adf5-68d7-4c1d-bd49-99920fec84cc"));
            RejectReason = (ITTObjectListBox)AddControl(new Guid("96061a78-0da9-42d0-8e49-b3fc4b1ca98c"));
            EmergencyCheckBox = (ITTCheckBox)AddControl(new Guid("17f54ac3-3c77-4314-bcbe-5ae04621a6dc"));
            TabTextInfos = (ITTTabControl)AddControl(new Guid("58eb4740-e214-427e-ae48-524bd8ea3843"));
            TabPageRequestDesc = (ITTTabPage)AddControl(new Guid("6db9f953-63b8-4c7d-b3c3-66d35b565119"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("d055794b-2a45-47bc-8f7e-dbcf5a587b1c"));
            TabPagePrediagnosis = (ITTTabPage)AddControl(new Guid("a4fdadae-4ebc-4211-ac59-fbfeb621743c"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("52694347-2830-4826-90c8-01d04a1ba5e2"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("3560a7ae-0ad3-4de4-a389-07b1c9a96c31"));
            Description = (ITTTextBox)AddControl(new Guid("805439ba-a2f3-47cc-a519-5a5b3eb06b6c"));
            TabPageApprovementDescription = (ITTTabPage)AddControl(new Guid("ece29ef5-b536-48d9-9026-8dd0abc84c5a"));
            ApprovementDescription = (ITTTextBox)AddControl(new Guid("636723f6-424f-4bc8-a83a-0a611890e7bc"));
            TabTests = (ITTTabControl)AddControl(new Guid("f0a0854d-5d64-452d-946f-2144e7639f61"));
            TabPageTests = (ITTTabPage)AddControl(new Guid("d30b36a2-d441-4269-9944-483f0a48b393"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("fee7f727-aa5f-40e6-95b2-c0b2aed7a892"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0fab6f4f-4e69-43b7-b177-50edf0ef7870"));
            TestAmount = (ITTTextBoxColumn)AddControl(new Guid("003f9378-41a7-433c-a273-684eb2ecc6f3"));
            islemTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("423b1cc6-1c1c-4252-b9a5-4c47f5275bb9"));
            birim = (ITTTextBoxColumn)AddControl(new Guid("89aead71-25e4-4e6b-80ad-3d27c6da13ed"));
            kesi = (ITTListBoxColumn)AddControl(new Guid("8a5e6851-78a3-42b1-835b-cc605b8231c0"));
            sagSol = (ITTListBoxColumn)AddControl(new Guid("536cccbd-82e8-4931-a9f1-5bc0d8c745b0"));
            sonuc = (ITTTextBoxColumn)AddControl(new Guid("1801c5da-eb79-4773-b663-811ea196172e"));
            drAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("54e33006-e686-49d9-9d58-1a9310e120c7"));
            performer = (ITTListBoxColumn)AddControl(new Guid("28a3d2fc-0f2c-4fdc-af4c-d2987377075c"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("836a973a-b7e1-456f-94b5-edc1b8d03bf9"));
            GridGeneticMaterials = (ITTGrid)AddControl(new Guid("39e268db-6a79-4a81-9548-f07e90ccb987"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("00b36b50-590f-43e3-a9f4-6bd0d906d0e6"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("8a345973-b0c1-49f4-89e8-7a83351f2aad"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("f34e8076-1ecd-4b44-bb8a-b51716a4e0d9"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("5d8f73f2-0289-47d4-b0a5-1c4af3fa0e14"));
            AMOUNT = (ITTTextBoxColumn)AddControl(new Guid("5d9d19cb-798e-4a23-8369-16ac83b9d943"));
            TabPageEquipments = (ITTTabPage)AddControl(new Guid("8f17f78d-b823-456a-8db2-0a01b09e7d37"));
            GridEquipments = (ITTGrid)AddControl(new Guid("463ae3ab-5c50-42ac-a7a9-0403d995c743"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("eda80a58-777f-4cfb-9de3-d2b24cf0615a"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("8196988d-5d4b-4e2f-9171-710bf684a0b3"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("646e4fb2-8798-43f8-a417-53d882600a8e"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("92fa64d4-c8fb-4511-b8e8-754d1522070f"));
            PatientAge = (ITTTextBox)AddControl(new Guid("3808bbe4-8281-4449-bc96-0934399219c3"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("9d6e069b-d99f-4b8e-9722-720837b64311"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("eb4ad330-63b4-4a40-bfd9-4c428d808c76"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("c7396e69-29e0-4089-97ff-a5f11b19123e"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("7caa06bc-4bab-4f4b-8d8f-4f2ad34ec22f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b383f0f4-f636-4110-b1c1-86a6ae713e9d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("3a10fd17-5ad8-42b2-a7b1-b51a84f506d6"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("9db637ad-7d09-4d51-9463-1f113b26d1b2"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b33902a1-4b8e-4948-afb8-ec96d6d19b2d"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f5e075c0-d6c3-4442-9b7c-117cb4b86997"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e18bbb0c-55f1-4169-ac41-cedbc3bd2425"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("d951b756-8b39-464f-9dba-b8fdb5f54f71"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("147bde17-5c2d-42a8-9e80-fbddd465269c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f40777ec-9f31-4837-9d54-ac0a3247ccd4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d21e5881-b0b6-4758-8765-e226587aa966"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2736ab4f-5b76-4010-a064-adfe10a50dbd"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("fbe5da06-ffda-4803-82a6-0f3602ed8526"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("8af7e928-3d0d-423f-9536-03732da65198"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("9754e133-4658-412c-9958-9c877b1f071f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c64799be-1f6c-4739-aead-b563d72adb28"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("2458aa4a-c5cf-4659-b76a-281844a01cbb"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("b9dccec2-fee9-46aa-b9f6-a983909b3a8c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ffbd833f-ea16-4ef2-bb9e-0f6ea92910a3"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5c5a4354-7390-4eab-8be9-b433ea365281"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("4fea14ba-3a62-480a-832c-18c90d220537"));
            base.InitializeControls();
        }

        public GeneticApprovementForm() : base("GENETIC", "GeneticApprovementForm")
        {
        }

        protected GeneticApprovementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}