
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
    public partial class MedulaOptikReportOnayForm : EpisodeActionForm
    {
        protected TTObjectClasses.MedulaOptikReport _MedulaOptikReport
        {
            get { return (TTObjectClasses.MedulaOptikReport)_ttObject; }
        }

        protected ITTPanel ttpanel1;
        protected ITTButton btnBashekimOnay;
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
        protected ITTButtonColumn btnOnay;
        protected ITTButtonColumn btnRed;
        protected ITTCheckBoxColumn IsApproved;
        protected ITTTextBoxColumn onayRedSonucKodu;
        protected ITTTextBoxColumn onayRedSonucMesaji;
        protected ITTTextBoxColumn onayRedUyariMesaji;
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
        override protected void InitializeControls()
        {
            ttpanel1 = (ITTPanel)AddControl(new Guid("b89e8689-b8d5-43e2-bb33-ef9246506272"));
            btnBashekimOnay = (ITTButton)AddControl(new Guid("08590749-58cf-49b7-9ca9-2a91aa470291"));
            labelSonucKodu = (ITTLabel)AddControl(new Guid("20de50a1-51cc-49fb-8228-4b4e7bf5511f"));
            labelSonucMesaji = (ITTLabel)AddControl(new Guid("abd0009d-aef0-4799-8015-43a4719e13a0"));
            labelUyariMesaji = (ITTLabel)AddControl(new Guid("ad2184ba-1427-462f-a909-b527a3a57507"));
            SonucKodu = (ITTTextBox)AddControl(new Guid("0ddd6e27-3d38-4a6e-aa05-202697c0b084"));
            SonucMesaji = (ITTTextBox)AddControl(new Guid("0f0a44a4-653f-43bd-84d3-da66fe2e6245"));
            UyariMesaji = (ITTTextBox)AddControl(new Guid("40284001-dbb0-4b43-b186-cb44886f235c"));
            Diagnosis = (ITTGrid)AddControl(new Guid("a51f33e4-7f6d-4bcc-852b-4e6835fecf78"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("658f3b64-f866-4abf-a28f-f67e9cd49abb"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("edbe68d9-aaff-4641-90ba-04c0d8023f4a"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("22c001bf-18b1-4364-9212-2284f791b975"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("c9d89fc2-51a5-4377-a611-0a4b1cf948bb"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("3162f99d-6ef9-45ca-bc41-99b222bce3c6"));
            labelDiagnosisDefinition = (ITTLabel)AddControl(new Guid("0ef76fc1-8e7f-4002-8eba-a2b8c4172270"));
            DiagnosisDefinition = (ITTObjectListBox)AddControl(new Guid("1e60b171-0249-4011-82b2-f68ff202fc6c"));
            DoctorsGrid = (ITTGrid)AddControl(new Guid("a8ef4f98-c3f8-4899-91c5-63f74496744d"));
            MedulaOptikReportDoctorGrid = (ITTListBoxColumn)AddControl(new Guid("11e363e9-4b29-4d1c-a4bf-6e5fff4f5438"));
            btnOnay = (ITTButtonColumn)AddControl(new Guid("592561f0-922e-473a-90e4-6b6337946765"));
            btnRed = (ITTButtonColumn)AddControl(new Guid("fbba7adc-1c1a-4d5b-89aa-692ad0b81e89"));
            IsApproved = (ITTCheckBoxColumn)AddControl(new Guid("7ec5d0b1-c9a7-4038-a33e-f0856f90737e"));
            onayRedSonucKodu = (ITTTextBoxColumn)AddControl(new Guid("e6443b04-e548-4d16-8c63-a570e3abeb7b"));
            onayRedSonucMesaji = (ITTTextBoxColumn)AddControl(new Guid("81312d67-ff56-4ba3-b987-8c79f6e1b1cf"));
            onayRedUyariMesaji = (ITTTextBoxColumn)AddControl(new Guid("5446513e-327e-48a2-8caf-19b447cea86d"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("1fe1a690-164e-4b15-866d-b003fae56fc8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("55efcc7f-be53-44ba-9a35-d675acb16475"));
            RaporAciklama = (ITTTextBox)AddControl(new Guid("42724ab1-2f3c-42cc-97eb-612817d4c16b"));
            RaporSequenceNo = (ITTTextBox)AddControl(new Guid("46730b3a-035d-4182-ae9a-c40de34c1a5d"));
            labelRaporKayitSekli = (ITTLabel)AddControl(new Guid("9c9a5fe8-cc22-40b8-a472-0a77506ccb26"));
            RaporKayitSekli = (ITTEnumComboBox)AddControl(new Guid("71ad422b-4f15-464f-91dc-569aa9cf43a6"));
            labelRaporDuzenlemeTuru = (ITTLabel)AddControl(new Guid("ceefe01d-390f-4d08-96b1-6976f5bcab6f"));
            RaporDuzenlemeTuru = (ITTEnumComboBox)AddControl(new Guid("e6bd7499-3a9d-4393-b071-0306bc3d7733"));
            labelRaporAciklama = (ITTLabel)AddControl(new Guid("9db2c31c-847e-4717-8b55-ced00a2d1a67"));
            labelRaporTipi = (ITTLabel)AddControl(new Guid("4ac5d6de-56de-43a9-aa40-485b49a282b5"));
            RaporTipi = (ITTEnumComboBox)AddControl(new Guid("840d997b-461b-40c0-b23a-a37188b25a53"));
            labelRaporSequenceNo = (ITTLabel)AddControl(new Guid("3271411f-ee2a-4b2e-ac2f-50ae71ffab78"));
            labelRaporBitisTarih = (ITTLabel)AddControl(new Guid("51049c4a-81de-4117-8325-babfbfb2c4db"));
            RaporBitisTarih = (ITTDateTimePicker)AddControl(new Guid("34715874-ae13-44eb-9c87-5af3737bc63f"));
            labelRaporBaslangicTarih = (ITTLabel)AddControl(new Guid("45dee808-1f38-4493-bb32-85bf853a0e24"));
            RaporBaslangicTarih = (ITTDateTimePicker)AddControl(new Guid("7b54ee24-3586-4bca-af2d-4f98f32c88c9"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("260c8c08-a4af-4e96-8509-7828f1fd0ea2"));
            base.InitializeControls();
        }

        public MedulaOptikReportOnayForm() : base("MEDULAOPTIKREPORT", "MedulaOptikReportOnayForm")
        {
        }

        protected MedulaOptikReportOnayForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}