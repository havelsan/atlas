
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
    public partial class MedulaOptikReportForm : EpisodeActionForm
    {
        protected TTObjectClasses.MedulaOptikReport _MedulaOptikReport
        {
            get { return (TTObjectClasses.MedulaOptikReport)_ttObject; }
        }

        protected ITTButton btnRaporSorgula;
        protected ITTPanel ttpanel1;
        protected ITTLabel labelRaporTakipNo;
        protected ITTTextBox txtRaporTakipNo;
        protected ITTButton btnRaporGiris;
        protected ITTLabel labelraporId;
        protected ITTTextBox raporId;
        protected ITTLabel labelSonucKodu;
        protected ITTLabel labelSonucMesaji;
        protected ITTLabel labelUyariMesaji;
        protected ITTTextBox SonucKodu;
        protected ITTTextBox SonucMesaji;
        protected ITTTextBox UyariMesaji;
        protected ITTGrid Diagnosis;
        protected ITTListBoxColumn Diagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelDiagnosisDefinition;
        protected ITTObjectListBox DiagnosisDefinition;
        protected ITTGrid DoctorsGrid;
        protected ITTListBoxColumn MedulaOptikReportDoctorGrid;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox RaporAciklama;
        protected ITTTextBox RaporSequenceNo;
        protected ITTLabel labelRaporKayitSekli;
        protected ITTEnumComboBox RaporKayitSekli;
        protected ITTLabel labelRaporDuzenlemeTuru;
        protected ITTEnumComboBox RaporDuzenlemeTuru;
        protected ITTLabel labelRaporAciklama;
        protected ITTLabel labelRaporTipi;
        protected ITTEnumComboBox RaporTipi;
        protected ITTLabel labelRaporSequenceNo;
        protected ITTLabel labelRaporBitisTarih;
        protected ITTDateTimePicker RaporBitisTarih;
        protected ITTLabel labelRaporBaslangicTarih;
        protected ITTDateTimePicker RaporBaslangicTarih;
        protected ITTLabel ttlabel22;
        protected ITTGrid gridRaporlar;
        protected ITTButtonColumn raporSil;
        protected ITTTextBoxColumn raporTakipNo;
        protected ITTTextBoxColumn raporTip;
        protected ITTTextBoxColumn raporNoTesis;
        protected ITTTextBoxColumn raporSonucKodu;
        protected ITTTextBoxColumn raporSonucMesaji;
        protected ITTTextBoxColumn raporUyariMesaji;
        protected ITTTextBoxColumn raporBaslangicTarihi;
        protected ITTTextBoxColumn raporBitisTarihi;
        protected ITTTextBoxColumn raporTeshis;
        protected ITTTextBoxColumn drTCKNo;
        protected ITTTextBoxColumn raporNo;
        protected ITTTextBoxColumn Aciklama;
        protected ITTTextBoxColumn raporTarihi;
        protected ITTTextBoxColumn protokolNo;
        protected ITTEnumComboBoxColumn raporDuzenlenmeTuru;
        protected ITTEnumComboBoxColumn kayitSekli;
        protected ITTTextBoxColumn durum;
        protected ITTTextBoxColumn objectID;
        override protected void InitializeControls()
        {
            btnRaporSorgula = (ITTButton)AddControl(new Guid("7495781e-382a-4113-a7b2-4657cb10f4f5"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("ee29bc27-2dc5-483d-89c9-9122837d6815"));
            labelRaporTakipNo = (ITTLabel)AddControl(new Guid("879b4b96-4904-4471-8aa1-823a08880d51"));
            txtRaporTakipNo = (ITTTextBox)AddControl(new Guid("97c8fa5f-11a0-4581-9351-95aa995ac43d"));
            btnRaporGiris = (ITTButton)AddControl(new Guid("00f6607e-4223-4e23-b99e-b65534b612a7"));
            labelraporId = (ITTLabel)AddControl(new Guid("090abdcb-145c-4475-a54c-6e28a3c249bd"));
            raporId = (ITTTextBox)AddControl(new Guid("777cfc74-6221-4e39-8103-4020fe331c37"));
            labelSonucKodu = (ITTLabel)AddControl(new Guid("8c8386ae-6174-438f-ac0f-b7e8f9dfadce"));
            labelSonucMesaji = (ITTLabel)AddControl(new Guid("3ab2590f-d9ab-4564-b687-66415a254795"));
            labelUyariMesaji = (ITTLabel)AddControl(new Guid("5f6f5838-d44d-49d3-991c-7051506888e5"));
            SonucKodu = (ITTTextBox)AddControl(new Guid("63372219-c8a5-4b99-b704-218563acee41"));
            SonucMesaji = (ITTTextBox)AddControl(new Guid("cd319c37-95b1-445b-a087-90aad90c5353"));
            UyariMesaji = (ITTTextBox)AddControl(new Guid("97892631-62d9-49be-ba46-c80c9ab4634d"));
            Diagnosis = (ITTGrid)AddControl(new Guid("ca261651-237b-4970-a36d-6e91eb8f3f4d"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("d2253bf0-b5a6-4182-962b-1902843aeaab"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0e3bc0b7-abba-424e-8f72-2ec910301cdb"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("23c8c983-0481-411f-b37c-5cf3d8e54593"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("77458e7f-71ba-40fe-b48a-7d63f479fa0f"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("bd9edd84-1ac2-44d8-a2d9-d656d5b2fe25"));
            labelDiagnosisDefinition = (ITTLabel)AddControl(new Guid("959005b4-17d3-4444-bc9f-8d1d72bc2f41"));
            DiagnosisDefinition = (ITTObjectListBox)AddControl(new Guid("a26236b4-4457-44cc-b6f9-391cd5c7f623"));
            DoctorsGrid = (ITTGrid)AddControl(new Guid("e5ed0703-bc06-4bf3-8c81-8b2bedbb3fea"));
            MedulaOptikReportDoctorGrid = (ITTListBoxColumn)AddControl(new Guid("d6f8d60d-1fba-406a-97f2-2cd49384d752"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("6eb659a3-3a67-49c8-b43e-094fc217ea10"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("12afc3e6-8900-4e5a-9349-d20f8c2c36b7"));
            RaporAciklama = (ITTTextBox)AddControl(new Guid("34d62e0b-b4f7-417b-be78-a7d56c2cbc3d"));
            RaporSequenceNo = (ITTTextBox)AddControl(new Guid("17e4c69a-3ef7-4ace-a175-cf56519329e6"));
            labelRaporKayitSekli = (ITTLabel)AddControl(new Guid("8edb62f9-4839-45b5-bc7b-72f517e197fd"));
            RaporKayitSekli = (ITTEnumComboBox)AddControl(new Guid("50a9fb7e-2d94-4d0b-b815-1cc43b19757b"));
            labelRaporDuzenlemeTuru = (ITTLabel)AddControl(new Guid("94f0ce0e-d900-4e94-ad78-f09b42390cb5"));
            RaporDuzenlemeTuru = (ITTEnumComboBox)AddControl(new Guid("bfbf4bb5-49bb-4541-8129-b6bc1d6622bb"));
            labelRaporAciklama = (ITTLabel)AddControl(new Guid("0536c5c4-bc5a-4f26-b05c-425722f041d2"));
            labelRaporTipi = (ITTLabel)AddControl(new Guid("fec3fbef-1490-4367-ba47-1c30afa0cf8e"));
            RaporTipi = (ITTEnumComboBox)AddControl(new Guid("96e9153d-c2b0-4c3b-ab65-625746acbbb0"));
            labelRaporSequenceNo = (ITTLabel)AddControl(new Guid("8314700a-385e-4138-9515-3faeeac0ce45"));
            labelRaporBitisTarih = (ITTLabel)AddControl(new Guid("0a1a10e0-3b5f-4bf0-bcc9-8d5ca724223e"));
            RaporBitisTarih = (ITTDateTimePicker)AddControl(new Guid("bc6cba87-701a-4998-8fe3-9bc434e7907a"));
            labelRaporBaslangicTarih = (ITTLabel)AddControl(new Guid("05c12a77-a85d-4647-9ac0-5679e9bad9d8"));
            RaporBaslangicTarih = (ITTDateTimePicker)AddControl(new Guid("88d473b4-0c00-4b73-9290-0cf80afd7e92"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("35cd2ca0-efee-47d2-b3d1-ce463877e2d6"));
            gridRaporlar = (ITTGrid)AddControl(new Guid("5af310d3-63e7-47fe-a6f5-33b7b3c4eaf4"));
            raporSil = (ITTButtonColumn)AddControl(new Guid("1664b846-106e-4d6a-bea4-34cd2a498e01"));
            raporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("2ad005e3-dfb5-41a9-85f6-1c52227f84f1"));
            raporTip = (ITTTextBoxColumn)AddControl(new Guid("7a28e31e-18f7-448c-9ea6-5221a08a1943"));
            raporNoTesis = (ITTTextBoxColumn)AddControl(new Guid("6c40b4b6-00ec-40c8-be7f-2c796abbd6eb"));
            raporSonucKodu = (ITTTextBoxColumn)AddControl(new Guid("62875781-fd0e-47c7-94c4-c992341c2822"));
            raporSonucMesaji = (ITTTextBoxColumn)AddControl(new Guid("3deeb9ca-9c2d-4b00-a5ea-55ef9c4379e2"));
            raporUyariMesaji = (ITTTextBoxColumn)AddControl(new Guid("9d52c966-0291-4cad-bd05-14073bd82065"));
            raporBaslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("7abb03b1-fe10-4446-8575-4c2c794b5b71"));
            raporBitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("8c215c0d-91a8-4330-900a-19fd4a7bbff2"));
            raporTeshis = (ITTTextBoxColumn)AddControl(new Guid("333f9122-24d1-4625-a4d1-b681926a79f9"));
            drTCKNo = (ITTTextBoxColumn)AddControl(new Guid("9ab5fddb-6216-455b-9d28-0093da02305d"));
            raporNo = (ITTTextBoxColumn)AddControl(new Guid("aaf2a128-71c8-4708-a537-1fc5b9f76c98"));
            Aciklama = (ITTTextBoxColumn)AddControl(new Guid("c1d70e7b-619e-4891-9980-5c0f417d8af9"));
            raporTarihi = (ITTTextBoxColumn)AddControl(new Guid("ba6f5d38-87fc-4534-b235-4077a8677b96"));
            protokolNo = (ITTTextBoxColumn)AddControl(new Guid("a064bede-7072-46b6-ba95-14fbf8922b10"));
            raporDuzenlenmeTuru = (ITTEnumComboBoxColumn)AddControl(new Guid("7f54697b-b562-4d88-af0e-8e58e3216195"));
            kayitSekli = (ITTEnumComboBoxColumn)AddControl(new Guid("2daba536-cfd6-422d-a4bb-2b6253ab1d39"));
            durum = (ITTTextBoxColumn)AddControl(new Guid("5eb358fc-15ba-4b7a-b503-c35b51ef121d"));
            objectID = (ITTTextBoxColumn)AddControl(new Guid("e3aa9a7e-84ce-45f3-9125-9d9d764c1da3"));
            base.InitializeControls();
        }

        public MedulaOptikReportForm() : base("MEDULAOPTIKREPORT", "MedulaOptikReportForm")
        {
        }

        protected MedulaOptikReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}