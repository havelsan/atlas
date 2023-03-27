
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
    public partial class GlassesReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Gözlük Reçetesi
    /// </summary>
        protected TTObjectClasses.GlassesReport _GlassesReport
        {
            get { return (TTObjectClasses.GlassesReport)_ttObject; }
        }

        protected ITTTextBox CylLeftNear;
        protected ITTTextBox CylLeftFar;
        protected ITTTextBox SphLeftNear;
        protected ITTTextBox SphLeftFar;
        protected ITTTextBox CylRightNear;
        protected ITTTextBox SphRightNear;
        protected ITTTextBox CylRightFar;
        protected ITTTextBox SphRightFar;
        protected ITTTextBox AxRightFar;
        protected ITTTextBox SonucAciklamasi;
        protected ITTTextBox SonucKodu;
        protected ITTTextBox EReceteNo;
        protected ITTTextBox GradientLeftNear;
        protected ITTTextBox GradientRightNear;
        protected ITTTextBox GradientLeftFar;
        protected ITTTextBox GradientRightFar;
        protected ITTTextBox DiameterLeftNear;
        protected ITTTextBox DiameterRightNear;
        protected ITTTextBox DiameterLeftFar;
        protected ITTTextBox DiameterRightFar;
        protected ITTButton btnReceteSil;
        protected ITTCheckBox TemporaryLens;
        protected ITTLabel labelSonucAciklamasi;
        protected ITTLabel labelSonucKodu;
        protected ITTLabel labelEReceteNo;
        protected ITTButton btnReceteKaydet;
        protected ITTLabel labelGradientLeftNear;
        protected ITTLabel labelGradientRightFar;
        protected ITTLabel labelDiameterLeftFar;
        protected ITTLabel labelDiameterRightFar;
        protected ITTEnumComboBox TeleskopikGlassesTypeLeftRead;
        protected ITTLabel labelTeleskopikGlassesTypeRighRead;
        protected ITTEnumComboBox TeleskopikGlassesTypeRighRead;
        protected ITTEnumComboBox TeleskopikGlassesTypeRighNear;
        protected ITTEnumComboBox TeleskopikGlassesTypeLeftNear;
        protected ITTEnumComboBox TeleskopikGlassesTypeLeftFar;
        protected ITTLabel labelTeleskopikGlassesTypeRightFar;
        protected ITTEnumComboBox TeleskopikGlassesTypeRightFar;
        protected ITTEnumComboBox GlassColorLeftNear;
        protected ITTLabel labelGlassColorLeftFar;
        protected ITTEnumComboBox GlassColorLeftFar;
        protected ITTEnumComboBox GlassColorRightNear;
        protected ITTLabel labelGlassColorRightFar;
        protected ITTEnumComboBox GlassColorRightFar;
        protected ITTLabel labelGlassRightTypeNear;
        protected ITTEnumComboBox GlassRightTypeNear;
        protected ITTEnumComboBox GlassLeftTypeNear;
        protected ITTEnumComboBox GlassLeftTypeFar;
        protected ITTLabel labelGlassRightTypeFar;
        protected ITTEnumComboBox GlassRightTypeFar;
        protected ITTLabel labelPrescriptionType;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid SecDiagnosis;
        protected ITTCheckBoxColumn AddToHistorySecDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseSecDiagnosisGrid;
        protected ITTCheckBoxColumn IsMainDiagnoseSecDiagnosisGrid;
        protected ITTListBoxColumn ResponsibleUserSecDiagnosisGrid;
        protected ITTDateTimePickerColumn DiagnoseDateSecDiagnosisGrid;
        protected ITTTabPage tttabpage2;
        protected ITTGrid DiagnosisDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistoryDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseDiagnosisGrid;
        protected ITTEnumComboBoxColumn DiagnosisTypeDiagnosisGrid;
        protected ITTCheckBoxColumn IsMainDiagnoseDiagnosisGrid;
        protected ITTListBoxColumn ResponsibleUserDiagnosisGrid;
        protected ITTDateTimePickerColumn DiagnoseDateDiagnosisGrid;
        protected ITTEnumComboBoxColumn EntryActionTypeDiagnosisGrid;
        protected ITTTextBox AxRightNear;
        protected ITTTextBox AxLeftNear;
        protected ITTTextBox AxLeftFar;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReasonForAdmission;
        protected ITTTextBox PatientGroup;
        protected ITTTextBox RecordID;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelAxRight;
        protected ITTLabel labelAxLeft;
        protected ITTLabel labelCylRight;
        protected ITTLabel labelCylLeft;
        protected ITTLabel labelSphLeft;
        protected ITTLabel labelSphRight;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTCheckBox cbxVitrumNear;
        protected ITTCheckBox cbxVitrumCloseReading;
        protected ITTCheckBox cbxVitrumFar;
        protected ITTLabel labelVitrum;
        protected ITTLabel labelRight;
        protected ITTLabel labelLeft;
        protected ITTLabel labelReasonForAdmission;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel labelRecordID;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            CylLeftNear = (ITTTextBox)AddControl(new Guid("bec7e302-06ed-4519-a6d2-0460b5c2082f"));
            CylLeftFar = (ITTTextBox)AddControl(new Guid("251a20e3-87ff-4a02-bf18-d7f003dc1793"));
            SphLeftNear = (ITTTextBox)AddControl(new Guid("326be610-f82a-4ce2-8c87-397e77dac802"));
            SphLeftFar = (ITTTextBox)AddControl(new Guid("3365b37f-738b-4cc7-9b1d-11d95450e65f"));
            CylRightNear = (ITTTextBox)AddControl(new Guid("af2dcd3d-71c6-4c88-9170-a497f9948107"));
            SphRightNear = (ITTTextBox)AddControl(new Guid("20206be7-0329-4287-bea0-5c1054225dfc"));
            CylRightFar = (ITTTextBox)AddControl(new Guid("38e1054e-5352-45b2-8d71-fc73a3b65608"));
            SphRightFar = (ITTTextBox)AddControl(new Guid("8b2fcd1b-0c34-49d3-afb2-e92cef245adf"));
            AxRightFar = (ITTTextBox)AddControl(new Guid("c0c9f56b-f097-4430-8952-b2d0cf62bbe8"));
            SonucAciklamasi = (ITTTextBox)AddControl(new Guid("c3eaa60f-d7fa-4f12-b336-ee02400605d8"));
            SonucKodu = (ITTTextBox)AddControl(new Guid("ee28ec78-d749-4387-843f-8cf7947911b3"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("4c4dfb6b-5db7-46cf-9f1c-b96ca50e5dc2"));
            GradientLeftNear = (ITTTextBox)AddControl(new Guid("8f7e9c0e-02e6-4161-b4bc-e43ce9f16175"));
            GradientRightNear = (ITTTextBox)AddControl(new Guid("f06d7b06-fac4-4c45-a39b-615b5f053eea"));
            GradientLeftFar = (ITTTextBox)AddControl(new Guid("26f39c85-5c0b-4c78-a224-2e02d74eeff1"));
            GradientRightFar = (ITTTextBox)AddControl(new Guid("f42c44f3-04a6-448c-992f-8b7a5fa7d28c"));
            DiameterLeftNear = (ITTTextBox)AddControl(new Guid("ffc86c79-2dba-4953-a277-0a3a5010bf3a"));
            DiameterRightNear = (ITTTextBox)AddControl(new Guid("593c0233-1b00-407e-846f-c3c29ac2324e"));
            DiameterLeftFar = (ITTTextBox)AddControl(new Guid("a9b2b881-8038-4245-ab56-900490a259ce"));
            DiameterRightFar = (ITTTextBox)AddControl(new Guid("96623e24-4bad-43e1-a5b4-a435db7f431f"));
            btnReceteSil = (ITTButton)AddControl(new Guid("e80f1ecb-a14b-4d83-b564-1ac58e71fdb3"));
            TemporaryLens = (ITTCheckBox)AddControl(new Guid("3362ebfd-0f3b-4a4b-9dec-407d76b48f13"));
            labelSonucAciklamasi = (ITTLabel)AddControl(new Guid("9b16fcb2-097c-47d6-89a0-04dfa11ca14d"));
            labelSonucKodu = (ITTLabel)AddControl(new Guid("1c2686e3-f0fd-4f54-be42-b5ddcdf04fba"));
            labelEReceteNo = (ITTLabel)AddControl(new Guid("ed5172d9-7036-42d6-a2f6-ecb833841f22"));
            btnReceteKaydet = (ITTButton)AddControl(new Guid("d0c75031-d240-4178-8c36-ad7e8402aa78"));
            labelGradientLeftNear = (ITTLabel)AddControl(new Guid("cf6c3416-2bde-4c67-a9b4-713adb111a8c"));
            labelGradientRightFar = (ITTLabel)AddControl(new Guid("8eaa9320-558e-424a-a2eb-c161c2150e21"));
            labelDiameterLeftFar = (ITTLabel)AddControl(new Guid("3ea7f513-53fc-48aa-b678-52dc8e2fc259"));
            labelDiameterRightFar = (ITTLabel)AddControl(new Guid("69e80d63-ddd0-4e89-a2ca-2131e6d32836"));
            TeleskopikGlassesTypeLeftRead = (ITTEnumComboBox)AddControl(new Guid("a10cbda7-636c-40ef-b074-d2c45fc0a617"));
            labelTeleskopikGlassesTypeRighRead = (ITTLabel)AddControl(new Guid("d95a7553-66bb-465a-858e-7735f6df54c7"));
            TeleskopikGlassesTypeRighRead = (ITTEnumComboBox)AddControl(new Guid("f4779f80-38a4-407a-9ec9-a8afcb36a6b9"));
            TeleskopikGlassesTypeRighNear = (ITTEnumComboBox)AddControl(new Guid("a419c6f0-79f0-42ac-b978-dcdcb578b852"));
            TeleskopikGlassesTypeLeftNear = (ITTEnumComboBox)AddControl(new Guid("84205e5e-4d5d-4f2b-8484-fe4a8c67f1e9"));
            TeleskopikGlassesTypeLeftFar = (ITTEnumComboBox)AddControl(new Guid("80f1d53a-fdf7-412f-b0ae-146c44db680c"));
            labelTeleskopikGlassesTypeRightFar = (ITTLabel)AddControl(new Guid("4f392b06-208f-40d3-b77d-6f80b6ab1668"));
            TeleskopikGlassesTypeRightFar = (ITTEnumComboBox)AddControl(new Guid("e3b270df-75ab-4c85-bdb4-794dc190075a"));
            GlassColorLeftNear = (ITTEnumComboBox)AddControl(new Guid("7fce820e-0774-433e-afc4-11fdd31f3e08"));
            labelGlassColorLeftFar = (ITTLabel)AddControl(new Guid("bf0314aa-cb33-47fd-8025-16625c8a8ed5"));
            GlassColorLeftFar = (ITTEnumComboBox)AddControl(new Guid("d2fb33af-6d67-4fd9-ad2d-9646ae022efa"));
            GlassColorRightNear = (ITTEnumComboBox)AddControl(new Guid("6cec7ebb-d3e7-4c88-a6ef-5aaffbfcaa87"));
            labelGlassColorRightFar = (ITTLabel)AddControl(new Guid("a6ff0693-c0d3-4877-ba48-d971bc503ef6"));
            GlassColorRightFar = (ITTEnumComboBox)AddControl(new Guid("2a8330eb-1b00-4bba-9c83-1e51465499ea"));
            labelGlassRightTypeNear = (ITTLabel)AddControl(new Guid("ed95a352-e612-4010-a08d-015a813ac445"));
            GlassRightTypeNear = (ITTEnumComboBox)AddControl(new Guid("e1d567bd-d7e7-40c5-8f14-9adfa564b3ef"));
            GlassLeftTypeNear = (ITTEnumComboBox)AddControl(new Guid("166dd202-9fe6-4225-a068-8b005cd47c07"));
            GlassLeftTypeFar = (ITTEnumComboBox)AddControl(new Guid("91125da2-03cf-4edc-8177-caf6059a84a9"));
            labelGlassRightTypeFar = (ITTLabel)AddControl(new Guid("cb75b3e3-c439-4c3f-bf57-5f5b2a75f238"));
            GlassRightTypeFar = (ITTEnumComboBox)AddControl(new Guid("4c96b6ca-24b3-4ccc-95c8-ba15b9991fb0"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("def30e5e-c1c2-4374-a430-b85f1efd2355"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("72ae2311-eb29-4889-afc8-ff57ed8cc82c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("136cae48-c18a-47dc-b9c4-4c01a3b7efb2"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("f6ee6405-3ef5-48de-b6c7-bbfa1625bff0"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("dc6ac517-5dfc-4abc-89c8-60aa1780c455"));
            AddToHistorySecDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("86af96ac-6fb0-44ea-be43-92652ab483f7"));
            DiagnoseSecDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("6c3bfaee-eed9-489b-b6c6-daea0c4224e4"));
            IsMainDiagnoseSecDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("2bb48a2e-9025-471c-a5d1-09dc4db536bc"));
            ResponsibleUserSecDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("7df9b6ab-69d4-42fb-9833-cedcdc67ccf2"));
            DiagnoseDateSecDiagnosisGrid = (ITTDateTimePickerColumn)AddControl(new Guid("c56af20c-e044-44d6-bd49-36a8fecbc72f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("ba3dd7d0-dfef-4fa7-845d-709030871af4"));
            DiagnosisDiagnosisGrid = (ITTGrid)AddControl(new Guid("e9857448-d397-4b97-bd9c-273f84b50f4d"));
            AddToHistoryDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("53cbd5e2-4846-4a46-a950-7adb1436d70c"));
            DiagnoseDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("3f3a8539-ed91-4fdc-8132-fcc6c8c99d16"));
            DiagnosisTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("3cf784f3-ab36-418f-b32f-b7eac79424a2"));
            IsMainDiagnoseDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("c9df8baa-793a-4073-8920-b984b55ab861"));
            ResponsibleUserDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("63d50711-e162-4565-9292-315a831b9044"));
            DiagnoseDateDiagnosisGrid = (ITTDateTimePickerColumn)AddControl(new Guid("1e671fd2-cd32-41d3-805c-60b46d4240e3"));
            EntryActionTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("77590f4e-34c5-4cda-9b46-9aeb0e023de8"));
            AxRightNear = (ITTTextBox)AddControl(new Guid("44fe6265-9936-41aa-bb02-e16868ed66dd"));
            AxLeftNear = (ITTTextBox)AddControl(new Guid("3b45b6e0-ea2c-4408-bce2-a56bc8b85e8a"));
            AxLeftFar = (ITTTextBox)AddControl(new Guid("a035ddab-8e75-4510-9e51-a1778345b5dd"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("798eb95d-9723-481b-8f40-ceb96d488b49"));
            ReasonForAdmission = (ITTTextBox)AddControl(new Guid("7d6fab4c-ae77-4c6a-80f7-e2d2e80b95a3"));
            PatientGroup = (ITTTextBox)AddControl(new Guid("f56f2878-b54a-4938-96be-2135c7b98af4"));
            RecordID = (ITTTextBox)AddControl(new Guid("1f11e0b7-f3dc-47cc-8996-89ca96eded44"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("3cfdcd2f-2a57-4c3a-bbcd-bf00a909c62b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("3b8ebb40-6aad-4c40-a4e7-c569684dc90d"));
            labelAxRight = (ITTLabel)AddControl(new Guid("96d27429-da19-4031-ab03-ea0f863650d2"));
            labelAxLeft = (ITTLabel)AddControl(new Guid("c941939a-1f85-4f44-b50a-2ec8e5d1917a"));
            labelCylRight = (ITTLabel)AddControl(new Guid("77749293-e109-4646-8943-e43f949b7b6e"));
            labelCylLeft = (ITTLabel)AddControl(new Guid("35a767df-3409-44b4-b718-aa09c25c54ac"));
            labelSphLeft = (ITTLabel)AddControl(new Guid("f94ffe6a-e47e-44b8-a6e3-db8e0f971119"));
            labelSphRight = (ITTLabel)AddControl(new Guid("f5aa67a6-faa2-4c2f-a379-362691565211"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("5c406b86-9c65-4bc0-9c2b-e217ae834d77"));
            labelReportDate = (ITTLabel)AddControl(new Guid("ea733d1c-384f-46cd-8b2b-ce95a29d3467"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("32f60371-db11-4197-9e3b-1d6ae11e40ee"));
            cbxVitrumNear = (ITTCheckBox)AddControl(new Guid("03f4099c-ec58-4f6c-b1c6-8562779d74a2"));
            cbxVitrumCloseReading = (ITTCheckBox)AddControl(new Guid("93e29f40-d260-4cc9-adc3-2844595c2e8c"));
            cbxVitrumFar = (ITTCheckBox)AddControl(new Guid("71f61eec-3dc2-42c0-bad5-d68a2ce82c92"));
            labelVitrum = (ITTLabel)AddControl(new Guid("ec4b5b8d-1b45-46be-9d88-a23e0bc221d2"));
            labelRight = (ITTLabel)AddControl(new Guid("ce112855-d799-415f-9ae0-a53eccec7d36"));
            labelLeft = (ITTLabel)AddControl(new Guid("d350ae7c-6e0a-43ef-9af8-6a895ef0e757"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("d0387ce0-40c0-4034-8de5-83cc37b028c1"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("57bc3f61-85ba-4bfd-a56a-bbb4a8b192a7"));
            labelRecordID = (ITTLabel)AddControl(new Guid("387cef2e-6cb5-4d3b-8242-bd9488249062"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("90f494cf-89f4-4df7-a669-0bbd506b7650"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("db5ee52b-0ab7-4082-bd67-a02da55ee272"));
            base.InitializeControls();
        }

        public GlassesReportForm() : base("GLASSESREPORT", "GlassesReportForm")
        {
        }

        protected GlassesReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}