
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Laboratuvar Sonuç Raporu
    /// </summary>
    public partial class LaboratoryResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField lblPatientName { get {return Header().lblPatientName;} }
            public TTReportField lblPatientSex { get {return Header().lblPatientSex;} }
            public TTReportField lblPatientAge { get {return Header().lblPatientAge;} }
            public TTReportField lblPatientFatherName { get {return Header().lblPatientFatherName;} }
            public TTReportField lblRequestDoctor { get {return Header().lblRequestDoctor;} }
            public TTReportField lblFromResource { get {return Header().lblFromResource;} }
            public TTReportField lblPreDiagnosis { get {return Header().lblPreDiagnosis;} }
            public TTReportField dotsPatientName { get {return Header().dotsPatientName;} }
            public TTReportField dotsPatientSex { get {return Header().dotsPatientSex;} }
            public TTReportField dotsPatientAge { get {return Header().dotsPatientAge;} }
            public TTReportField dotsPatientFatherName { get {return Header().dotsPatientFatherName;} }
            public TTReportField dotsPreDiagnosis { get {return Header().dotsPreDiagnosis;} }
            public TTReportField dotsRequestDoctor { get {return Header().dotsRequestDoctor;} }
            public TTReportField dotsFromResource { get {return Header().dotsFromResource;} }
            public TTReportField lblPatientStatus { get {return Header().lblPatientStatus;} }
            public TTReportField dotsPatientStatus { get {return Header().dotsPatientStatus;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField PatientSex { get {return Header().PatientSex;} }
            public TTReportField PatientAge { get {return Header().PatientAge;} }
            public TTReportField PatientFatherName { get {return Header().PatientFatherName;} }
            public TTReportField FromResource { get {return Header().FromResource;} }
            public TTReportField PreDiagnosis { get {return Header().PreDiagnosis;} }
            public TTReportField PatientStatus { get {return Header().PatientStatus;} }
            public TTReportField RequestDoctor { get {return Header().RequestDoctor;} }
            public TTReportField lblBirthPlace { get {return Header().lblBirthPlace;} }
            public TTReportField dotsBirthPlace { get {return Header().dotsBirthPlace;} }
            public TTReportField BirthPlace { get {return Header().BirthPlace;} }
            public TTReportField lblProtocolNo { get {return Header().lblProtocolNo;} }
            public TTReportField dotsProtocolNo { get {return Header().dotsProtocolNo;} }
            public TTReportField REQUEST1 { get {return Header().REQUEST1;} }
            public TTReportField REQUEST2 { get {return Header().REQUEST2;} }
            public TTReportField lblBarcodeId { get {return Header().lblBarcodeId;} }
            public TTReportField dotsBarcodeId { get {return Header().dotsBarcodeId;} }
            public TTReportField BarcodeId { get {return Header().BarcodeId;} }
            public TTReportField lblDash1 { get {return Header().lblDash1;} }
            public TTReportField ProtocolNo { get {return Header().ProtocolNo;} }
            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField ApprovedBy { get {return Footer().ApprovedBy;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryRequest.LaboratoryReportNQL_Class>("LaboratoryReportNQL", LaboratoryRequest.LaboratoryReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField LOGO;
                public TTReportField lblPatientName;
                public TTReportField lblPatientSex;
                public TTReportField lblPatientAge;
                public TTReportField lblPatientFatherName;
                public TTReportField lblRequestDoctor;
                public TTReportField lblFromResource;
                public TTReportField lblPreDiagnosis;
                public TTReportField dotsPatientName;
                public TTReportField dotsPatientSex;
                public TTReportField dotsPatientAge;
                public TTReportField dotsPatientFatherName;
                public TTReportField dotsPreDiagnosis;
                public TTReportField dotsRequestDoctor;
                public TTReportField dotsFromResource;
                public TTReportField lblPatientStatus;
                public TTReportField dotsPatientStatus;
                public TTReportField PatientName;
                public TTReportField PatientSex;
                public TTReportField PatientAge;
                public TTReportField PatientFatherName;
                public TTReportField FromResource;
                public TTReportField PreDiagnosis;
                public TTReportField PatientStatus;
                public TTReportField RequestDoctor;
                public TTReportField lblBirthPlace;
                public TTReportField dotsBirthPlace;
                public TTReportField BirthPlace;
                public TTReportField lblProtocolNo;
                public TTReportField dotsProtocolNo;
                public TTReportField REQUEST1;
                public TTReportField REQUEST2;
                public TTReportField lblBarcodeId;
                public TTReportField dotsBarcodeId;
                public TTReportField BarcodeId;
                public TTReportField lblDash1;
                public TTReportField ProtocolNo; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 59, 197, 64, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 13;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"LABORATUVAR SONUÇ RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 2, 165, 25, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Microsoft Sans Serif";
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 28, 251, 34, false);
                    NewField6.Name = "NewField6";
                    NewField6.Visible = EvetHayirEnum.ehHayir;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 2, 45, 25, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.Value = @"";

                    lblPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 26, 38, 31, false);
                    lblPatientName.Name = "lblPatientName";
                    lblPatientName.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName.TextFont.Size = 9;
                    lblPatientName.TextFont.CharSet = 162;
                    lblPatientName.Value = @"Adı Soyadı";

                    lblPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 38, 36, false);
                    lblPatientSex.Name = "lblPatientSex";
                    lblPatientSex.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientSex.TextFont.Size = 9;
                    lblPatientSex.TextFont.CharSet = 162;
                    lblPatientSex.Value = @"Cinsiyeti / Yaşı";

                    lblPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 40, 252, 45, false);
                    lblPatientAge.Name = "lblPatientAge";
                    lblPatientAge.Visible = EvetHayirEnum.ehHayir;
                    lblPatientAge.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientAge.TextFont.Size = 9;
                    lblPatientAge.TextFont.CharSet = 162;
                    lblPatientAge.Value = @"Hastanın Yaşı";

                    lblPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 36, 38, 41, false);
                    lblPatientFatherName.Name = "lblPatientFatherName";
                    lblPatientFatherName.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientFatherName.TextFont.Size = 9;
                    lblPatientFatherName.TextFont.CharSet = 162;
                    lblPatientFatherName.Value = @"Baba Adı";

                    lblRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 36, 133, 41, false);
                    lblRequestDoctor.Name = "lblRequestDoctor";
                    lblRequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    lblRequestDoctor.TextFont.Size = 9;
                    lblRequestDoctor.TextFont.CharSet = 162;
                    lblRequestDoctor.Value = @"İstek Yapan Doktor";

                    lblFromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 31, 133, 36, false);
                    lblFromResource.Name = "lblFromResource";
                    lblFromResource.TextFont.Name = "Microsoft Sans Serif";
                    lblFromResource.TextFont.Size = 9;
                    lblFromResource.TextFont.CharSet = 162;
                    lblFromResource.Value = @"İstek Yapan Birim";

                    lblPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 47, 38, 52, false);
                    lblPreDiagnosis.Name = "lblPreDiagnosis";
                    lblPreDiagnosis.TextFont.Name = "Microsoft Sans Serif";
                    lblPreDiagnosis.TextFont.Size = 9;
                    lblPreDiagnosis.TextFont.CharSet = 162;
                    lblPreDiagnosis.Value = @"Ön Tanı";

                    dotsPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 26, 41, 31, false);
                    dotsPatientName.Name = "dotsPatientName";
                    dotsPatientName.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName.TextFont.Size = 9;
                    dotsPatientName.TextFont.CharSet = 162;
                    dotsPatientName.Value = @":";

                    dotsPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 31, 41, 36, false);
                    dotsPatientSex.Name = "dotsPatientSex";
                    dotsPatientSex.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientSex.TextFont.Size = 9;
                    dotsPatientSex.TextFont.CharSet = 162;
                    dotsPatientSex.Value = @":";

                    dotsPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 40, 255, 45, false);
                    dotsPatientAge.Name = "dotsPatientAge";
                    dotsPatientAge.Visible = EvetHayirEnum.ehHayir;
                    dotsPatientAge.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientAge.TextFont.Size = 9;
                    dotsPatientAge.TextFont.CharSet = 162;
                    dotsPatientAge.Value = @":";

                    dotsPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 36, 41, 41, false);
                    dotsPatientFatherName.Name = "dotsPatientFatherName";
                    dotsPatientFatherName.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientFatherName.TextFont.Size = 9;
                    dotsPatientFatherName.TextFont.CharSet = 162;
                    dotsPatientFatherName.Value = @":";

                    dotsPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 47, 41, 52, false);
                    dotsPreDiagnosis.Name = "dotsPreDiagnosis";
                    dotsPreDiagnosis.TextFont.Name = "Microsoft Sans Serif";
                    dotsPreDiagnosis.TextFont.Size = 9;
                    dotsPreDiagnosis.TextFont.CharSet = 162;
                    dotsPreDiagnosis.Value = @":";

                    dotsRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 36, 136, 41, false);
                    dotsRequestDoctor.Name = "dotsRequestDoctor";
                    dotsRequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    dotsRequestDoctor.TextFont.Size = 9;
                    dotsRequestDoctor.TextFont.CharSet = 162;
                    dotsRequestDoctor.Value = @":";

                    dotsFromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 31, 136, 36, false);
                    dotsFromResource.Name = "dotsFromResource";
                    dotsFromResource.TextFont.Name = "Microsoft Sans Serif";
                    dotsFromResource.TextFont.Size = 9;
                    dotsFromResource.TextFont.CharSet = 162;
                    dotsFromResource.Value = @":";

                    lblPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 41, 38, 46, false);
                    lblPatientStatus.Name = "lblPatientStatus";
                    lblPatientStatus.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientStatus.TextFont.Size = 9;
                    lblPatientStatus.TextFont.CharSet = 162;
                    lblPatientStatus.Value = @"Hasta Tipi";

                    dotsPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 41, 41, 46, false);
                    dotsPatientStatus.Name = "dotsPatientStatus";
                    dotsPatientStatus.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientStatus.TextFont.Size = 9;
                    dotsPatientStatus.TextFont.CharSet = 162;
                    dotsPatientStatus.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 26, 98, 31, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Microsoft Sans Serif";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#} {#SURNAME#}";

                    PatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 31, 58, 36, false);
                    PatientSex.Name = "PatientSex";
                    PatientSex.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSex.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSex.ObjectDefName = "SexEnum";
                    PatientSex.DataMember = "DISPLAYTEXT";
                    PatientSex.TextFont.Name = "Microsoft Sans Serif";
                    PatientSex.TextFont.Size = 9;
                    PatientSex.TextFont.CharSet = 162;
                    PatientSex.Value = @"{#SEX#}";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 31, 92, 36, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAge.TextFont.Name = "Microsoft Sans Serif";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"PatientAge";

                    PatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 36, 98, 41, false);
                    PatientFatherName.Name = "PatientFatherName";
                    PatientFatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientFatherName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientFatherName.TextFont.Name = "Microsoft Sans Serif";
                    PatientFatherName.TextFont.Size = 9;
                    PatientFatherName.TextFont.CharSet = 162;
                    PatientFatherName.Value = @"{#FATHERNAME#}";

                    FromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 31, 197, 36, false);
                    FromResource.Name = "FromResource";
                    FromResource.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResource.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FromResource.MultiLine = EvetHayirEnum.ehEvet;
                    FromResource.TextFont.Name = "Microsoft Sans Serif";
                    FromResource.TextFont.Size = 8;
                    FromResource.TextFont.CharSet = 162;
                    FromResource.Value = @"{#FROMRES#}";

                    PreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 47, 197, 58, false);
                    PreDiagnosis.Name = "PreDiagnosis";
                    PreDiagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    PreDiagnosis.NoClip = EvetHayirEnum.ehEvet;
                    PreDiagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    PreDiagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreDiagnosis.TextFont.Name = "Microsoft Sans Serif";
                    PreDiagnosis.TextFont.Size = 9;
                    PreDiagnosis.TextFont.CharSet = 162;
                    PreDiagnosis.Value = @"PreDiagnosis";

                    PatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 41, 98, 46, false);
                    PatientStatus.Name = "PatientStatus";
                    PatientStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus.TextFormat = @"Long Time";
                    PatientStatus.ObjectDefName = "PatientStatusEnum";
                    PatientStatus.DataMember = "DISPLAYTEXT";
                    PatientStatus.TextFont.Name = "Microsoft Sans Serif";
                    PatientStatus.TextFont.Size = 9;
                    PatientStatus.TextFont.CharSet = 162;
                    PatientStatus.Value = @"{#PATIENTSTATUS#}";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 36, 197, 41, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor.TextFormat = @"dd/mm/yyyy";
                    RequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    RequestDoctor.TextFont.Size = 9;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"{#REQDOCTORNAME#}";

                    lblBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 46, 252, 51, false);
                    lblBirthPlace.Name = "lblBirthPlace";
                    lblBirthPlace.Visible = EvetHayirEnum.ehHayir;
                    lblBirthPlace.TextFont.Name = "Microsoft Sans Serif";
                    lblBirthPlace.TextFont.Size = 9;
                    lblBirthPlace.TextFont.CharSet = 162;
                    lblBirthPlace.Value = @"Doğum Yeri";

                    dotsBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 46, 255, 51, false);
                    dotsBirthPlace.Name = "dotsBirthPlace";
                    dotsBirthPlace.Visible = EvetHayirEnum.ehHayir;
                    dotsBirthPlace.TextFont.Name = "Microsoft Sans Serif";
                    dotsBirthPlace.TextFont.Size = 9;
                    dotsBirthPlace.TextFont.CharSet = 162;
                    dotsBirthPlace.Value = @":";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 46, 275, 51, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.Visible = EvetHayirEnum.ehHayir;
                    BirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlace.TextFormat = @"Long Date";
                    BirthPlace.TextFont.Name = "Microsoft Sans Serif";
                    BirthPlace.TextFont.Size = 9;
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"{#CITYNAME#} - {#TOWNNAME#}";

                    lblProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 41, 133, 46, false);
                    lblProtocolNo.Name = "lblProtocolNo";
                    lblProtocolNo.TextFont.Name = "Microsoft Sans Serif";
                    lblProtocolNo.TextFont.Size = 9;
                    lblProtocolNo.TextFont.CharSet = 162;
                    lblProtocolNo.Value = @"Protokol No";

                    dotsProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 41, 136, 46, false);
                    dotsProtocolNo.Name = "dotsProtocolNo";
                    dotsProtocolNo.TextFont.Name = "Microsoft Sans Serif";
                    dotsProtocolNo.TextFont.Size = 9;
                    dotsProtocolNo.TextFont.CharSet = 162;
                    dotsProtocolNo.Value = @":";

                    REQUEST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 57, 232, 62, false);
                    REQUEST1.Name = "REQUEST1";
                    REQUEST1.Visible = EvetHayirEnum.ehHayir;
                    REQUEST1.TextFont.Name = "Arial Narrow";
                    REQUEST1.TextFont.Size = 9;
                    REQUEST1.TextFont.CharSet = 162;
                    REQUEST1.Value = @"REQUEST1";

                    REQUEST2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 63, 233, 68, false);
                    REQUEST2.Name = "REQUEST2";
                    REQUEST2.Visible = EvetHayirEnum.ehHayir;
                    REQUEST2.TextFont.Name = "Arial Narrow";
                    REQUEST2.TextFont.Size = 9;
                    REQUEST2.TextFont.CharSet = 162;
                    REQUEST2.Value = @"REQUEST2";

                    lblBarcodeId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 26, 133, 31, false);
                    lblBarcodeId.Name = "lblBarcodeId";
                    lblBarcodeId.TextFont.Name = "Microsoft Sans Serif";
                    lblBarcodeId.TextFont.Size = 9;
                    lblBarcodeId.TextFont.CharSet = 162;
                    lblBarcodeId.Value = @"Örnek Numarası";

                    dotsBarcodeId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 26, 136, 31, false);
                    dotsBarcodeId.Name = "dotsBarcodeId";
                    dotsBarcodeId.TextFont.Name = "Microsoft Sans Serif";
                    dotsBarcodeId.TextFont.Size = 9;
                    dotsBarcodeId.TextFont.CharSet = 162;
                    dotsBarcodeId.Value = @":";

                    BarcodeId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 26, 197, 31, false);
                    BarcodeId.Name = "BarcodeId";
                    BarcodeId.FieldType = ReportFieldTypeEnum.ftVariable;
                    BarcodeId.TextFormat = @"Long Time";
                    BarcodeId.TextFont.Name = "Microsoft Sans Serif";
                    BarcodeId.TextFont.Size = 9;
                    BarcodeId.TextFont.CharSet = 162;
                    BarcodeId.Value = @"{#BARCODEID#}";

                    lblDash1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 31, 60, 36, false);
                    lblDash1.Name = "lblDash1";
                    lblDash1.MultiLine = EvetHayirEnum.ehEvet;
                    lblDash1.TextFont.Name = "Microsoft Sans Serif";
                    lblDash1.TextFont.Size = 9;
                    lblDash1.TextFont.CharSet = 162;
                    lblDash1.Value = @"/";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 41, 197, 46, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNo.TextFormat = @"Long Time";
                    ProtocolNo.TextFont.Name = "Microsoft Sans Serif";
                    ProtocolNo.TextFont.Size = 9;
                    ProtocolNo.TextFont.CharSet = 162;
                    ProtocolNo.Value = @"{#PROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryReportNQL_Class dataset_LaboratoryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    LOGO.CalcValue = @"";
                    lblPatientName.CalcValue = lblPatientName.Value;
                    lblPatientSex.CalcValue = lblPatientSex.Value;
                    lblPatientAge.CalcValue = lblPatientAge.Value;
                    lblPatientFatherName.CalcValue = lblPatientFatherName.Value;
                    lblRequestDoctor.CalcValue = lblRequestDoctor.Value;
                    lblFromResource.CalcValue = lblFromResource.Value;
                    lblPreDiagnosis.CalcValue = lblPreDiagnosis.Value;
                    dotsPatientName.CalcValue = dotsPatientName.Value;
                    dotsPatientSex.CalcValue = dotsPatientSex.Value;
                    dotsPatientAge.CalcValue = dotsPatientAge.Value;
                    dotsPatientFatherName.CalcValue = dotsPatientFatherName.Value;
                    dotsPreDiagnosis.CalcValue = dotsPreDiagnosis.Value;
                    dotsRequestDoctor.CalcValue = dotsRequestDoctor.Value;
                    dotsFromResource.CalcValue = dotsFromResource.Value;
                    lblPatientStatus.CalcValue = lblPatientStatus.Value;
                    dotsPatientStatus.CalcValue = dotsPatientStatus.Value;
                    PatientName.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Patientname) : "") + @" " + (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Surname) : "");
                    PatientSex.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Sex) : "");
                    PatientSex.PostFieldValueCalculation();
                    PatientAge.CalcValue = PatientAge.Value;
                    PatientFatherName.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.FatherName) : "");
                    FromResource.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Fromres) : "");
                    PreDiagnosis.CalcValue = PreDiagnosis.Value;
                    PatientStatus.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.PatientStatus) : "");
                    PatientStatus.PostFieldValueCalculation();
                    RequestDoctor.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Reqdoctorname) : "");
                    lblBirthPlace.CalcValue = lblBirthPlace.Value;
                    dotsBirthPlace.CalcValue = dotsBirthPlace.Value;
                    BirthPlace.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Cityname) : "") + @" - " + (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Townname) : "");
                    lblProtocolNo.CalcValue = lblProtocolNo.Value;
                    dotsProtocolNo.CalcValue = dotsProtocolNo.Value;
                    REQUEST1.CalcValue = REQUEST1.Value;
                    REQUEST2.CalcValue = REQUEST2.Value;
                    lblBarcodeId.CalcValue = lblBarcodeId.Value;
                    dotsBarcodeId.CalcValue = dotsBarcodeId.Value;
                    BarcodeId.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.BarcodeID) : "");
                    lblDash1.CalcValue = lblDash1.Value;
                    ProtocolNo.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.ProtocolNo) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField6,LOGO,lblPatientName,lblPatientSex,lblPatientAge,lblPatientFatherName,lblRequestDoctor,lblFromResource,lblPreDiagnosis,dotsPatientName,dotsPatientSex,dotsPatientAge,dotsPatientFatherName,dotsPreDiagnosis,dotsRequestDoctor,dotsFromResource,lblPatientStatus,dotsPatientStatus,PatientName,PatientSex,PatientAge,PatientFatherName,FromResource,PreDiagnosis,PatientStatus,RequestDoctor,lblBirthPlace,dotsBirthPlace,BirthPlace,lblProtocolNo,dotsProtocolNo,REQUEST1,REQUEST2,lblBarcodeId,dotsBarcodeId,BarcodeId,lblDash1,ProtocolNo,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((LaboratoryResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            Patient patient = labObject.Episode.Patient;
            this.PatientAge.CalcValue = patient.Age.ToString();
            string preDiagnosis = null;
            
            
            List<DiagnosisDefinition> distinctList = new List<DiagnosisDefinition>(); //Tekrarlayan tanıların ayıklanmasında kullanılan liste
            
            foreach(DiagnosisGrid dig in labObject.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Primer)
                {
                    if (distinctList.Contains(dig.Diagnose) == false) //Tekrarlayan tanılar burada ayıklanır...
                    {
                        preDiagnosis = preDiagnosis +dig.Diagnose.Code.Trim()+" "+ dig.Diagnose.Name.ToString() + ", " ;
                        distinctList.Add(dig.Diagnose);
                    }
                }
            }
            this.PreDiagnosis.CalcValue = preDiagnosis;
            
            distinctList = null;
            
            /*
            BindingList<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class> requests = LaboratoryRequest.GetLastTwoLaboratoryRequests(context, patient.ObjectID, labObject.MasterResource.ObjectID,labObject.WorkListDate.Value);
            int i = 0;
            foreach(LaboratoryRequest.GetLastTwoLaboratoryRequests_Class request in requests)
            {
                if(i == 0)
                {
                    this.REQUEST1.CalcValue = request.ObjectID.Value.ToString();
                    this.DATE1.CalcValue = request.WorkListDate.Value.ToShortDateString();
                }
                else if(i == 1)
                {
                    this.REQUEST2.CalcValue = request.ObjectID.Value.ToString();
                    this.DATE2.CalcValue = request.WorkListDate.Value.ToShortDateString();
                }
                i++;
            }
             */
            bool overridePrintRoles = TTObjectClasses.Common.OverridePrintRoles(TTObjectClasses.Common.CurrentUser);
            
            if(patient.SecurePerson == true && overridePrintRoles == false)
            {
                this.PatientName.Visible = this.dotsPatientName.Visible = this.lblPatientName.Visible = EvetHayirEnum.ehHayir;
                this.PatientSex.Visible = this.dotsPatientSex.Visible = this.lblPatientSex.Visible = EvetHayirEnum.ehHayir;
                this.BirthPlace.Visible = this.dotsBirthPlace.Visible = this.lblBirthPlace.Visible = EvetHayirEnum.ehHayir;
                this.PatientAge.Visible = this.dotsPatientAge.Visible = this.lblPatientAge.Visible = EvetHayirEnum.ehHayir;
                this.PatientFatherName.Visible = this.dotsPatientFatherName.Visible = this.lblPatientFatherName.Visible = EvetHayirEnum.ehHayir;
                this.PatientStatus.Visible = this.dotsPatientStatus.Visible = this.lblPatientStatus.Visible = EvetHayirEnum.ehHayir;
                this.FromResource.Visible = this.dotsFromResource.Visible = this.lblFromResource.Visible = EvetHayirEnum.ehHayir;
                this.RequestDoctor.Visible = this.dotsRequestDoctor.Visible = this.lblRequestDoctor.Visible = EvetHayirEnum.ehHayir;
                this.PreDiagnosis.Visible = this.dotsPreDiagnosis.Visible = this.lblPreDiagnosis.Visible = EvetHayirEnum.ehHayir;
                this.ProtocolNo.Visible = this.dotsProtocolNo.Visible = this.lblProtocolNo.Visible = EvetHayirEnum.ehHayir;
            }
            
            //this.LOGO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALLOGO","");
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber;
                public TTReportField NewField1111;
                public TTReportField ApprovedBy;
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 10, 245, 16, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel.TextFont.Name = "Arial Narrow";
                    HizmetOzel.TextFont.Size = 11;
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.TextFont.CharSet = 162;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 24, 198, 24, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 25, 36, 30, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PrintDate.TextFont.Name = "Microsoft Sans Serif";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 25, 137, 30, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UserName.TextFont.Name = "Microsoft Sans Serif";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 25, 197, 30, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Microsoft Sans Serif";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 275, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Onaylayan Uzman";

                    ApprovedBy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 197, 22, false);
                    ApprovedBy.Name = "ApprovedBy";
                    ApprovedBy.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ApprovedBy.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedBy.NoClip = EvetHayirEnum.ehEvet;
                    ApprovedBy.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedBy.ObjectDefName = "LaboratoryRequest";
                    ApprovedBy.DataMember = "APPROVEDBY.NAME";
                    ApprovedBy.TextFont.Name = "Microsoft Sans Serif";
                    ApprovedBy.TextFont.Size = 8;
                    ApprovedBy.TextFont.CharSet = 162;
                    ApprovedBy.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 11, 108, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Bu rapor hasta tedavisi ve dosyası için düzenlenmiştir. İzinsiz olarak bilimsel yayın amacı ile kullanılamaz.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 21, 16, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"NOT :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryReportNQL_Class dataset_LaboratoryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryReportNQL_Class>(0);
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField1111.CalcValue = NewField1111.Value;
                    ApprovedBy.CalcValue = ApprovedBy.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel,PrintDate,PageNumber,NewField1111,ApprovedBy,NewField1,NewField2,UserName};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((LaboratoryResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            
            ResUser approvedBy = labObject.ApprovedBy;
  
            string CrLf = "\r\n";
            string SB = "";
            string TextContext = "";
                        
            //ApprovedBy
            if(approvedBy != null)
            {
                SB = approvedBy.SignatureBlock; //approvedBy.Rank == null ? "" : approvedBy.Rank.Name;
                TextContext = SB + CrLf ;
                this.ApprovedBy.CalcValue = TextContext;
            }
            
                       
            /*
            string CrLf = "\r\n";
            string TextContext = "";
            string Title = "";
            string Sicil = "";
            string Rank = "";
                        
            //ApprovedBy
            if(approvedBy != null)
            {
                Title = !approvedBy.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(approvedBy.Title.Value);
                Sicil = approvedBy.EmploymentRecordID;
                Rank = approvedBy.Rank == null ? "" : approvedBy.Rank.Name;
                TextContext = approvedBy.Name + CrLf + Title + " " + Rank + "(" + Sicil + ")" + CrLf ;
                this.ApprovedBy.CalcValue = TextContext;
            }
            */
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class TABORDERGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public TABORDERGroupHeader Header()
            {
                return (TABORDERGroupHeader)_header;
            }

            new public TABORDERGroupFooter Footer()
            {
                return (TABORDERGroupFooter)_footer;
            }

            public TTReportField REQUESTEDTAB { get {return Header().REQUESTEDTAB;} }
            public TTReportField TAB { get {return Header().TAB;} }
            public TTReportField ENVIRONMENT { get {return Header().ENVIRONMENT;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField Date { get {return Header().Date;} }
            public TTReportField lblOldResults { get {return Header().lblOldResults;} }
            public TTReportField REQUEST1 { get {return Header().REQUEST1;} }
            public TTReportField REQUEST2 { get {return Header().REQUEST2;} }
            public TTReportField OBJECTID1 { get {return Header().OBJECTID1;} }
            public TTReportField lblTest { get {return Header().lblTest;} }
            public TTReportField lblResult { get {return Header().lblResult;} }
            public TTReportField lblUnit { get {return Header().lblUnit;} }
            public TTReportField lblUnit2 { get {return Header().lblUnit2;} }
            public TTReportField DATE1 { get {return Header().DATE1;} }
            public TTReportField DATE2 { get {return Header().DATE2;} }
            public TTReportField DATE3 { get {return Header().DATE3;} }
            public TTReportField REQUEST3 { get {return Header().REQUEST3;} }
            public TTReportField LBLENVIRONMENT { get {return Header().LBLENVIRONMENT;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField SampleAcceptionDate { get {return Header().SampleAcceptionDate;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField ResultDate { get {return Header().ResultDate;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField RequestDate { get {return Header().RequestDate;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField RequestAcceptionDate { get {return Header().RequestAcceptionDate;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportField PrintDate1 { get {return Header().PrintDate1;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TABORDERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TABORDERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class>("GetLabTabsNQL", LaboratoryRequestFormTabDefinition.GetLabTabsNQL());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TABORDERGroupHeader(this);
                _footer = new TABORDERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TABORDERGroupHeader : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField REQUESTEDTAB;
                public TTReportField TAB;
                public TTReportField ENVIRONMENT;
                public TTReportField OBJECTID;
                public TTReportField Date;
                public TTReportField lblOldResults;
                public TTReportField REQUEST1;
                public TTReportField REQUEST2;
                public TTReportField OBJECTID1;
                public TTReportField lblTest;
                public TTReportField lblResult;
                public TTReportField lblUnit;
                public TTReportField lblUnit2;
                public TTReportField DATE1;
                public TTReportField DATE2;
                public TTReportField DATE3;
                public TTReportField REQUEST3;
                public TTReportField LBLENVIRONMENT;
                public TTReportField NewField2;
                public TTReportField SampleAcceptionDate;
                public TTReportField NewField12;
                public TTReportField ResultDate;
                public TTReportShape NewLine12;
                public TTReportField NewField13;
                public TTReportField RequestDate;
                public TTReportShape NewLine13;
                public TTReportField NewField131;
                public TTReportField RequestAcceptionDate;
                public TTReportField NewField121;
                public TTReportShape NewLine131;
                public TTReportField PrintDate1;
                public TTReportShape NewLine121; 
                public TABORDERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REQUESTEDTAB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 74, 6, false);
                    REQUESTEDTAB.Name = "REQUESTEDTAB";
                    REQUESTEDTAB.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDTAB.VertAlign = VerticalAlignmentEnum.vaBottom;
                    REQUESTEDTAB.TextFont.Name = "Microsoft Sans Serif";
                    REQUESTEDTAB.TextFont.Size = 11;
                    REQUESTEDTAB.TextFont.Bold = true;
                    REQUESTEDTAB.TextFont.CharSet = 162;
                    REQUESTEDTAB.Value = @"{#NAME#}";

                    TAB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 3, 231, 8, false);
                    TAB.Name = "TAB";
                    TAB.Visible = EvetHayirEnum.ehHayir;
                    TAB.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAB.TextFont.Name = "Arial Narrow";
                    TAB.TextFont.Size = 9;
                    TAB.TextFont.CharSet = 162;
                    TAB.Value = @"{#OBJECTID#}";

                    ENVIRONMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 16, 197, 21, false);
                    ENVIRONMENT.Name = "ENVIRONMENT";
                    ENVIRONMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENVIRONMENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENVIRONMENT.ObjectDefName = "LaboratoryEnvironmentDefinition";
                    ENVIRONMENT.DataMember = "NAME";
                    ENVIRONMENT.TextFont.Name = "Microsoft Sans Serif";
                    ENVIRONMENT.TextFont.Size = 8;
                    ENVIRONMENT.TextFont.Bold = true;
                    ENVIRONMENT.TextFont.CharSet = 162;
                    ENVIRONMENT.Value = @"{#ENVIRONMENT#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 3, 255, 8, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{@TTOBJECTID@}";

                    Date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 150, 6, false);
                    Date.Name = "Date";
                    Date.Visible = EvetHayirEnum.ehHayir;
                    Date.DrawStyle = DrawStyleConstants.vbSolid;
                    Date.FieldType = ReportFieldTypeEnum.ftVariable;
                    Date.TextFormat = @"Short Date";
                    Date.ObjectDefName = "LaboratoryRequest";
                    Date.DataMember = "WORKLISTDATE";
                    Date.TextFont.Name = "Arial Narrow";
                    Date.TextFont.Bold = true;
                    Date.TextFont.CharSet = 162;
                    Date.Value = @"{@TTOBJECTID@}";

                    lblOldResults = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 23, 197, 28, false);
                    lblOldResults.Name = "lblOldResults";
                    lblOldResults.DrawStyle = DrawStyleConstants.vbSolid;
                    lblOldResults.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblOldResults.TextFont.Name = "Microsoft Sans Serif";
                    lblOldResults.TextFont.Size = 9;
                    lblOldResults.TextFont.CharSet = 162;
                    lblOldResults.Value = @"ÖNCEKİ SONUÇLAR";

                    REQUEST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 9, 232, 14, false);
                    REQUEST1.Name = "REQUEST1";
                    REQUEST1.Visible = EvetHayirEnum.ehHayir;
                    REQUEST1.TextFont.Name = "Arial Narrow";
                    REQUEST1.TextFont.Size = 9;
                    REQUEST1.TextFont.CharSet = 162;
                    REQUEST1.Value = @"REQUEST1";

                    REQUEST2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 15, 233, 20, false);
                    REQUEST2.Name = "REQUEST2";
                    REQUEST2.Visible = EvetHayirEnum.ehHayir;
                    REQUEST2.TextFont.Name = "Arial Narrow";
                    REQUEST2.TextFont.Size = 9;
                    REQUEST2.TextFont.CharSet = 162;
                    REQUEST2.Value = @"REQUEST2";

                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 9, 257, 14, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.TextFont.Name = "Arial Narrow";
                    OBJECTID1.TextFont.Size = 9;
                    OBJECTID1.TextFont.CharSet = 162;
                    OBJECTID1.Value = @"{@TTOBJECTID@}";

                    lblTest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 29, 67, 34, false);
                    lblTest.Name = "lblTest";
                    lblTest.TextFont.Name = "Microsoft Sans Serif";
                    lblTest.TextFont.Underline = true;
                    lblTest.TextFont.CharSet = 162;
                    lblTest.Value = @"TEST";

                    lblResult = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 29, 94, 34, false);
                    lblResult.Name = "lblResult";
                    lblResult.TextFont.Name = "Microsoft Sans Serif";
                    lblResult.TextFont.Underline = true;
                    lblResult.TextFont.CharSet = 162;
                    lblResult.Value = @"SONUÇ";

                    lblUnit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 29, 155, 34, false);
                    lblUnit.Name = "lblUnit";
                    lblUnit.TextFont.Name = "Microsoft Sans Serif";
                    lblUnit.TextFont.Underline = true;
                    lblUnit.TextFont.CharSet = 162;
                    lblUnit.Value = @"REFERANS";

                    lblUnit2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 29, 122, 34, false);
                    lblUnit2.Name = "lblUnit2";
                    lblUnit2.TextFont.Name = "Microsoft Sans Serif";
                    lblUnit2.TextFont.Underline = true;
                    lblUnit2.TextFont.CharSet = 162;
                    lblUnit2.Value = @"BİRİM";

                    DATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 29, 173, 34, false);
                    DATE1.Name = "DATE1";
                    DATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE1.TextFont.Name = "Microsoft Sans Serif";
                    DATE1.TextFont.Size = 7;
                    DATE1.TextFont.Underline = true;
                    DATE1.TextFont.CharSet = 162;
                    DATE1.Value = @"";

                    DATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 29, 185, 34, false);
                    DATE2.Name = "DATE2";
                    DATE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE2.TextFont.Name = "Microsoft Sans Serif";
                    DATE2.TextFont.Size = 7;
                    DATE2.TextFont.Underline = true;
                    DATE2.TextFont.CharSet = 162;
                    DATE2.Value = @"";

                    DATE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 29, 197, 34, false);
                    DATE3.Name = "DATE3";
                    DATE3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE3.TextFont.Name = "Microsoft Sans Serif";
                    DATE3.TextFont.Size = 7;
                    DATE3.TextFont.Underline = true;
                    DATE3.TextFont.CharSet = 162;
                    DATE3.Value = @"";

                    REQUEST3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 15, 251, 20, false);
                    REQUEST3.Name = "REQUEST3";
                    REQUEST3.Visible = EvetHayirEnum.ehHayir;
                    REQUEST3.TextFont.Name = "Arial Narrow";
                    REQUEST3.TextFont.Size = 9;
                    REQUEST3.TextFont.CharSet = 162;
                    REQUEST3.Value = @"REQUEST3";

                    LBLENVIRONMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 16, 180, 21, false);
                    LBLENVIRONMENT.Name = "LBLENVIRONMENT";
                    LBLENVIRONMENT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LBLENVIRONMENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLENVIRONMENT.TextFont.Name = "Microsoft Sans Serif";
                    LBLENVIRONMENT.TextFont.Size = 8;
                    LBLENVIRONMENT.TextFont.Bold = true;
                    LBLENVIRONMENT.TextFont.CharSet = 162;
                    LBLENVIRONMENT.Value = @"Örnek Türü:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 36, 19, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 7;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Numune Kabul Tarihi :";

                    SampleAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 15, 61, 19, false);
                    SampleAcceptionDate.Name = "SampleAcceptionDate";
                    SampleAcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    SampleAcceptionDate.TextFont.Name = "Arial";
                    SampleAcceptionDate.TextFont.Size = 7;
                    SampleAcceptionDate.TextFont.CharSet = 162;
                    SampleAcceptionDate.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 19, 36, 23, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 7;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Sonuç Onay Tarihi :";

                    ResultDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 19, 61, 23, false);
                    ResultDate.Name = "ResultDate";
                    ResultDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    ResultDate.TextFont.Name = "Arial";
                    ResultDate.TextFont.Size = 7;
                    ResultDate.TextFont.CharSet = 162;
                    ResultDate.Value = @"";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 63, 6, 63, 28, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.ForeColor = System.Drawing.Color.Gray;
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 36, 11, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 7;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İstek Tarihi :";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 7, 61, 11, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    RequestDate.TextFont.Name = "Arial";
                    RequestDate.TextFont.Size = 7;
                    RequestDate.TextFont.CharSet = 162;
                    RequestDate.Value = @"";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 63, 6, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.ForeColor = System.Drawing.Color.Gray;
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 36, 15, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 7;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İstek Kabul Tarihi :";

                    RequestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 11, 61, 15, false);
                    RequestAcceptionDate.Name = "RequestAcceptionDate";
                    RequestAcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    RequestAcceptionDate.TextFont.Name = "Arial";
                    RequestAcceptionDate.TextFont.Size = 7;
                    RequestAcceptionDate.TextFont.CharSet = 162;
                    RequestAcceptionDate.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 36, 27, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 7;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Rapor Tarihi :";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 28, 63, 28, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.ForeColor = System.Drawing.Color.Gray;
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 23, 61, 27, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate1.TextFont.Name = "Microsoft Sans Serif";
                    PrintDate1.TextFont.Size = 7;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 7, 28, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.ForeColor = System.Drawing.Color.Gray;
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class dataset_GetLabTabsNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class>(0);
                    REQUESTEDTAB.CalcValue = (dataset_GetLabTabsNQL != null ? Globals.ToStringCore(dataset_GetLabTabsNQL.Name) : "");
                    TAB.CalcValue = (dataset_GetLabTabsNQL != null ? Globals.ToStringCore(dataset_GetLabTabsNQL.ObjectID) : "");
                    ENVIRONMENT.CalcValue = (dataset_GetLabTabsNQL != null ? Globals.ToStringCore(dataset_GetLabTabsNQL.Environment) : "");
                    ENVIRONMENT.PostFieldValueCalculation();
                    OBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    Date.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    Date.PostFieldValueCalculation();
                    lblOldResults.CalcValue = lblOldResults.Value;
                    REQUEST1.CalcValue = REQUEST1.Value;
                    REQUEST2.CalcValue = REQUEST2.Value;
                    OBJECTID1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    lblTest.CalcValue = lblTest.Value;
                    lblResult.CalcValue = lblResult.Value;
                    lblUnit.CalcValue = lblUnit.Value;
                    lblUnit2.CalcValue = lblUnit2.Value;
                    DATE1.CalcValue = DATE1.Value;
                    DATE2.CalcValue = DATE2.Value;
                    DATE3.CalcValue = DATE3.Value;
                    REQUEST3.CalcValue = REQUEST3.Value;
                    LBLENVIRONMENT.CalcValue = LBLENVIRONMENT.Value;
                    NewField2.CalcValue = NewField2.Value;
                    SampleAcceptionDate.CalcValue = SampleAcceptionDate.Value;
                    NewField12.CalcValue = NewField12.Value;
                    ResultDate.CalcValue = ResultDate.Value;
                    NewField13.CalcValue = NewField13.Value;
                    RequestDate.CalcValue = RequestDate.Value;
                    NewField131.CalcValue = NewField131.Value;
                    RequestAcceptionDate.CalcValue = RequestAcceptionDate.Value;
                    NewField121.CalcValue = NewField121.Value;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    return new TTReportObject[] { REQUESTEDTAB,TAB,ENVIRONMENT,OBJECTID,Date,lblOldResults,REQUEST1,REQUEST2,OBJECTID1,lblTest,lblResult,lblUnit,lblUnit2,DATE1,DATE2,DATE3,REQUEST3,LBLENVIRONMENT,NewField2,SampleAcceptionDate,NewField12,ResultDate,NewField13,RequestDate,NewField131,RequestAcceptionDate,NewField121,PrintDate1};
                }

                public override void RunScript()
                {
#region TABORDER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            
            BindingList<TTObjectClasses.LaboratoryProcedure> procedures = LaboratoryProcedure.GetLabResults(context, " WHERE CURRENTSTATE <> '" + LaboratoryProcedure.States.Cancelled + "' AND EPISODEACTION = '" + labObject.ObjectID.ToString() + "' AND REQUESTEDTAB = '" + this.TAB.CalcValue.ToString() + "'");
            if (procedures.Count <= 0 )
            {
                ((TTReportTool.TTReportSection)(((LaboratoryResultReport)ParentReport).Groups("TABORDER").Header)).Visible = EvetHayirEnum.ehHayir;
                this.TAB.CalcValue = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                if(((LaboratoryProcedure)procedures[0]).SampleAcceptionDate != null)
                {
                    this.SampleAcceptionDate.CalcValue =  ((LaboratoryProcedure)procedures[0]).SampleAcceptionDate.ToString();
                }
                else
                {
                    this.SampleAcceptionDate.CalcValue = string.Empty;
                    this.SampleAcceptionDate.Visible = EvetHayirEnum.ehHayir;
                }
                    
                
                
                if(((LaboratoryProcedure)procedures[0]).ResultDate != null)
                    this.ResultDate.CalcValue =  ((LaboratoryProcedure)procedures[0]).ResultDate.ToString();
                //Sonradan eklenenler
                if(labObject.RequestDate != null)
                    this.RequestDate.CalcValue = labObject.RequestDate.ToString();
                if(labObject.LabRequestAcceptionDate != null)
                    this.RequestAcceptionDate.CalcValue = labObject.LabRequestAcceptionDate.ToString();             
                //
                ((TTReportTool.TTReportSection)(((LaboratoryResultReport)ParentReport).Groups("TABORDER").Header)).Visible = EvetHayirEnum.ehEvet;
                
                Patient patient = labObject.Episode.Patient;
                Guid tabGuid = new Guid(this.TAB.CalcValue.ToString());
                BindingList<LaboratoryProcedure.GetLabProcedureByRequestTab_Class> requests
                    = LaboratoryProcedure.GetLabProcedureByRequestTab(context, tabGuid, patient.ObjectID,(DateTime)labObject.WorkListDate);
                int i = 0;
                foreach(LaboratoryProcedure.GetLabProcedureByRequestTab_Class request in requests)
                {
                    if(i == 0)
                    {
                        this.REQUEST1.CalcValue = request.Ttobjectid.ToString();
                        this.DATE1.CalcValue = (Convert.ToDateTime(request.WorkListDate.Value)).ToString("dd/MM/yy");
                        
                    }
                    else if(i == 1)
                    {
                        this.REQUEST2.CalcValue = request.Ttobjectid.ToString();
                        this.DATE2.CalcValue = (Convert.ToDateTime(request.WorkListDate.Value)).ToString("dd/MM/yy");
                    }
                    else if(i == 2)
                    {
                        this.REQUEST3.CalcValue = request.Ttobjectid.ToString();
                        this.DATE3.CalcValue = (Convert.ToDateTime(request.WorkListDate.Value)).ToString("dd/MM/yy");
                    }
                    i++;
                }
            }
#endregion TABORDER HEADER_Script
                }
            }
            public partial class TABORDERGroupFooter : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                 
                public TABORDERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TABORDERGroup TABORDER;

        public partial class TABGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public TABGroupHeader Header()
            {
                return (TABGroupHeader)_header;
            }

            new public TABGroupFooter Footer()
            {
                return (TABGroupFooter)_footer;
            }

            public TTReportField TABID { get {return Header().TABID;} }
            public TTReportField PROCEDUREOBJECT { get {return Header().PROCEDUREOBJECT;} }
            public TABGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TABGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryTabNamesGrid.GetByTabs_Class>("GetByTabs", LaboratoryTabNamesGrid.GetByTabs((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.TABORDER.TAB.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TABGroupHeader(this);
                _footer = new TABGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TABGroupHeader : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField TABID;
                public TTReportField PROCEDUREOBJECT; 
                public TABGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TABID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 82, 6, false);
                    TABID.Name = "TABID";
                    TABID.Visible = EvetHayirEnum.ehHayir;
                    TABID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABID.TextFont.Name = "Microsoft Sans Serif";
                    TABID.TextFont.Underline = true;
                    TABID.TextFont.CharSet = 162;
                    TABID.Value = @"{%TABORDER.TAB%}";

                    PROCEDUREOBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 233, 6, false);
                    PROCEDUREOBJECT.Name = "PROCEDUREOBJECT";
                    PROCEDUREOBJECT.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREOBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECT.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECT.TextFont.Size = 9;
                    PROCEDUREOBJECT.TextFont.CharSet = 162;
                    PROCEDUREOBJECT.Value = @"{#TESTDEFID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryTabNamesGrid.GetByTabs_Class dataset_GetByTabs = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryTabNamesGrid.GetByTabs_Class>(0);
                    TABID.CalcValue = MyParentReport.TABORDER.TAB.CalcValue;
                    PROCEDUREOBJECT.CalcValue = (dataset_GetByTabs != null ? Globals.ToStringCore(dataset_GetByTabs.Testdefid) : "");
                    return new TTReportObject[] { TABID,PROCEDUREOBJECT};
                }
            }
            public partial class TABGroupFooter : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                 
                public TABGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TABGroup TAB;

        public partial class GROUPGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public GROUPGroupHeader Header()
            {
                return (GROUPGroupHeader)_header;
            }

            new public GROUPGroupFooter Footer()
            {
                return (GROUPGroupFooter)_footer;
            }

            public GROUPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GROUPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class>("GetLabProcedureByTestAndRequest", LaboratoryProcedure.GetLabProcedureByTestAndRequest((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.TAB.PROCEDUREOBJECT.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GROUPGroupHeader(this);
                _footer = new GROUPGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class GROUPGroupHeader : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                 
                public GROUPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class GROUPGroupFooter : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                 
                public GROUPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public GROUPGroup GROUP;

        public partial class PARENTGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public PARENTGroupHeader Header()
            {
                return (PARENTGroupHeader)_header;
            }

            new public PARENTGroupFooter Footer()
            {
                return (PARENTGroupFooter)_footer;
            }

            public TTReportField LaboratoryProcedureTestName { get {return Header().LaboratoryProcedureTestName;} }
            public TTReportField Result { get {return Header().Result;} }
            public TTReportField Reference { get {return Header().Reference;} }
            public TTReportField Unit { get {return Header().Unit;} }
            public TTReportField OBJID { get {return Header().OBJID;} }
            public TTReportField WARNING { get {return Header().WARNING;} }
            public TTReportField Result1 { get {return Header().Result1;} }
            public TTReportField Result2 { get {return Header().Result2;} }
            public TTReportField REQ1 { get {return Header().REQ1;} }
            public TTReportField REQ2 { get {return Header().REQ2;} }
            public TTReportField TESTID { get {return Header().TESTID;} }
            public TTReportField WarningSign { get {return Header().WarningSign;} }
            public TTReportField REQ3 { get {return Header().REQ3;} }
            public TTReportField Result3 { get {return Header().Result3;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportRTF LongReportRTF { get {return Footer().LongReportRTF;} }
            public PARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGroupHeader(this);
                _footer = new PARENTGroupFooter(this);

            }

            public partial class PARENTGroupHeader : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField LaboratoryProcedureTestName;
                public TTReportField Result;
                public TTReportField Reference;
                public TTReportField Unit;
                public TTReportField OBJID;
                public TTReportField WARNING;
                public TTReportField Result1;
                public TTReportField Result2;
                public TTReportField REQ1;
                public TTReportField REQ2;
                public TTReportField TESTID;
                public TTReportField WarningSign;
                public TTReportField REQ3;
                public TTReportField Result3;
                public TTReportShape NewLine1; 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LaboratoryProcedureTestName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 67, 6, false);
                    LaboratoryProcedureTestName.Name = "LaboratoryProcedureTestName";
                    LaboratoryProcedureTestName.FieldType = ReportFieldTypeEnum.ftVariable;
                    LaboratoryProcedureTestName.MultiLine = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.NoClip = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.WordBreak = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.ExpandTabs = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.TextFont.Name = "Microsoft Sans Serif";
                    LaboratoryProcedureTestName.TextFont.Size = 8;
                    LaboratoryProcedureTestName.TextFont.CharSet = 162;
                    LaboratoryProcedureTestName.Value = @"{#GROUP.NAME#}";

                    Result = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 2, 94, 6, false);
                    Result.Name = "Result";
                    Result.FieldType = ReportFieldTypeEnum.ftVariable;
                    Result.MultiLine = EvetHayirEnum.ehEvet;
                    Result.NoClip = EvetHayirEnum.ehEvet;
                    Result.WordBreak = EvetHayirEnum.ehEvet;
                    Result.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result.TextFont.Name = "Microsoft Sans Serif";
                    Result.TextFont.Size = 8;
                    Result.TextFont.CharSet = 162;
                    Result.Value = @"{#GROUP.RESULT#}";

                    Reference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 2, 155, 6, false);
                    Reference.Name = "Reference";
                    Reference.FieldType = ReportFieldTypeEnum.ftVariable;
                    Reference.MultiLine = EvetHayirEnum.ehEvet;
                    Reference.NoClip = EvetHayirEnum.ehEvet;
                    Reference.WordBreak = EvetHayirEnum.ehEvet;
                    Reference.ExpandTabs = EvetHayirEnum.ehEvet;
                    Reference.TextFont.Name = "Microsoft Sans Serif";
                    Reference.TextFont.Size = 8;
                    Reference.TextFont.CharSet = 162;
                    Reference.Value = @"{#GROUP.REFERENCE#}";

                    Unit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 2, 122, 6, false);
                    Unit.Name = "Unit";
                    Unit.FieldType = ReportFieldTypeEnum.ftVariable;
                    Unit.MultiLine = EvetHayirEnum.ehEvet;
                    Unit.NoClip = EvetHayirEnum.ehEvet;
                    Unit.WordBreak = EvetHayirEnum.ehEvet;
                    Unit.ExpandTabs = EvetHayirEnum.ehEvet;
                    Unit.TextFont.Name = "Microsoft Sans Serif";
                    Unit.TextFont.Size = 8;
                    Unit.TextFont.CharSet = 162;
                    Unit.Value = @"{#GROUP.UNIT#}";

                    OBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 243, 5, false);
                    OBJID.Name = "OBJID";
                    OBJID.Visible = EvetHayirEnum.ehHayir;
                    OBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJID.TextFont.Name = "Arial Narrow";
                    OBJID.TextFont.Size = 9;
                    OBJID.TextFont.CharSet = 162;
                    OBJID.Value = @"{#GROUP.OBJECTID#}";

                    WARNING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 230, 5, false);
                    WARNING.Name = "WARNING";
                    WARNING.Visible = EvetHayirEnum.ehHayir;
                    WARNING.FieldType = ReportFieldTypeEnum.ftVariable;
                    WARNING.ObjectDefName = "HighLowEnum";
                    WARNING.DataMember = "DISPLAYTEXT";
                    WARNING.TextFont.Name = "Arial Narrow";
                    WARNING.TextFont.Size = 9;
                    WARNING.TextFont.CharSet = 162;
                    WARNING.Value = @"{#GROUP.WARNING#}";

                    Result1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 2, 173, 6, false);
                    Result1.Name = "Result1";
                    Result1.MultiLine = EvetHayirEnum.ehEvet;
                    Result1.NoClip = EvetHayirEnum.ehEvet;
                    Result1.WordBreak = EvetHayirEnum.ehEvet;
                    Result1.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result1.TextFont.Name = "Microsoft Sans Serif";
                    Result1.TextFont.Size = 8;
                    Result1.TextFont.CharSet = 162;
                    Result1.Value = @"";

                    Result2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 2, 185, 6, false);
                    Result2.Name = "Result2";
                    Result2.MultiLine = EvetHayirEnum.ehEvet;
                    Result2.NoClip = EvetHayirEnum.ehEvet;
                    Result2.WordBreak = EvetHayirEnum.ehEvet;
                    Result2.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result2.TextFont.Name = "Microsoft Sans Serif";
                    Result2.TextFont.Size = 8;
                    Result2.TextFont.CharSet = 162;
                    Result2.Value = @"";

                    REQ1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 0, 252, 5, false);
                    REQ1.Name = "REQ1";
                    REQ1.Visible = EvetHayirEnum.ehHayir;
                    REQ1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ1.TextFont.Name = "Arial Narrow";
                    REQ1.TextFont.Size = 9;
                    REQ1.TextFont.CharSet = 162;
                    REQ1.Value = @"{%TABORDER.REQUEST1%}";

                    REQ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 0, 262, 5, false);
                    REQ2.Name = "REQ2";
                    REQ2.Visible = EvetHayirEnum.ehHayir;
                    REQ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ2.TextFont.Name = "Arial Narrow";
                    REQ2.TextFont.Size = 9;
                    REQ2.TextFont.CharSet = 162;
                    REQ2.Value = @"{%TABORDER.REQUEST2%}";

                    TESTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 0, 292, 5, false);
                    TESTID.Name = "TESTID";
                    TESTID.Visible = EvetHayirEnum.ehHayir;
                    TESTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTID.TextFont.Name = "Arial Narrow";
                    TESTID.TextFont.Size = 9;
                    TESTID.TextFont.CharSet = 162;
                    TESTID.Value = @"{#GROUP.PROCEDUREOBJECT#}";

                    WarningSign = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 2, 73, 6, false);
                    WarningSign.Name = "WarningSign";
                    WarningSign.TextFont.Name = "Microsoft Sans Serif";
                    WarningSign.TextFont.Size = 9;
                    WarningSign.TextFont.CharSet = 162;
                    WarningSign.Value = @"";

                    REQ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 272, 5, false);
                    REQ3.Name = "REQ3";
                    REQ3.Visible = EvetHayirEnum.ehHayir;
                    REQ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ3.TextFont.Name = "Arial Narrow";
                    REQ3.TextFont.Size = 9;
                    REQ3.TextFont.CharSet = 162;
                    REQ3.Value = @"{%TABORDER.REQUEST3%}";

                    Result3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 2, 197, 6, false);
                    Result3.Name = "Result3";
                    Result3.MultiLine = EvetHayirEnum.ehEvet;
                    Result3.NoClip = EvetHayirEnum.ehEvet;
                    Result3.WordBreak = EvetHayirEnum.ehEvet;
                    Result3.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result3.TextFont.Name = "Microsoft Sans Serif";
                    Result3.TextFont.Size = 8;
                    Result3.TextFont.CharSet = 162;
                    Result3.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 197, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.ForeColor = System.Drawing.Color.FromArgb(255,221,221,221);
                    NewLine1.DrawStyle = DrawStyleConstants.vbDashDot;
                    NewLine1.FillStyle = FillStyleConstants.vbFSTransparent;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class dataset_GetLabProcedureByTestAndRequest = MyParentReport.GROUP.rsGroup.GetCurrentRecord<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class>(0);
                    LaboratoryProcedureTestName.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.Name) : "");
                    Result.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.Result) : "");
                    Reference.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.Reference) : "");
                    Unit.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.Unit) : "");
                    OBJID.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.ObjectID) : "");
                    WARNING.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.Warning) : "");
                    WARNING.PostFieldValueCalculation();
                    Result1.CalcValue = Result1.Value;
                    Result2.CalcValue = Result2.Value;
                    REQ1.CalcValue = MyParentReport.TABORDER.REQUEST1.CalcValue;
                    REQ2.CalcValue = MyParentReport.TABORDER.REQUEST2.CalcValue;
                    TESTID.CalcValue = (dataset_GetLabProcedureByTestAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTestAndRequest.ProcedureObject) : "");
                    WarningSign.CalcValue = WarningSign.Value;
                    REQ3.CalcValue = MyParentReport.TABORDER.REQUEST3.CalcValue;
                    Result3.CalcValue = Result3.Value;
                    return new TTReportObject[] { LaboratoryProcedureTestName,Result,Reference,Unit,OBJID,WARNING,Result1,Result2,REQ1,REQ2,TESTID,WarningSign,REQ3,Result3};
                }
#region PARENT HEADER_Methods
            public bool IsValidGuid(string str)
        {
            Guid value;

            try
            {
                value = new Guid(str);
                return true;
            }
            catch(FormatException)
            {
                value = Guid.Empty;
                return false;
            }
        }
#endregion PARENT HEADER_Methods

                public override void RunScript()
                {
#region PARENT HEADER_Script
                    if(this.WARNING.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.High)
               || this.WARNING.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Low)
               || this.WARNING.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Panic))
            {
                this.LaboratoryProcedureTestName.TextFont.Bold = true;
                this.Result.TextFont.Bold = true;
                this.Reference.TextFont.Bold = true;
                this.Unit.TextFont.Bold = true;
                this.WarningSign.CalcValue = "*";
            }
            else
            {
                this.LaboratoryProcedureTestName.TextFont.Bold = false;
                this.Result.TextFont.Bold = false;
                this.Reference.TextFont.Bold = false;
                this.Unit.TextFont.Bold = false;
                this.WarningSign.CalcValue = "";
            }
            bool hasReqID1 = false;
            bool hasReqID2 = false;
            bool hasReqID3 = false;

            if(this.REQ1.CalcValue != "REQUEST1")
                hasReqID1 = true;
            
            if(this.REQ2.CalcValue != "REQUEST2")
                hasReqID2 = true;
            
            if(this.REQ3.CalcValue != "REQUEST3")
                hasReqID3 = true;
            
            string testName = this.LaboratoryProcedureTestName.CalcValue;
            //ResultDescription ekleme
            TTObjectContext context = new TTObjectContext(true);
            string objectID = ((LaboratoryResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            if(objectID != null)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
                if(laboratoryProcedure.ResultDescription != null)
                {
                    testName = testName + "\r\n" + "   Sonuç Açıklaması: " + laboratoryProcedure.ResultDescription.ToString();
                    this.LaboratoryProcedureTestName.CalcValue = testName;
                }
                
//                /* */
//                if(laboratoryProcedure.SampleAcceptionDate != null)
//                {
//                    this.SampleAcceptionDate.CalcValue =  laboratoryProcedure.SampleAcceptionDate.ToString();
//                }
//                if(laboratoryProcedure.ResultDate != null)
//                {
//                    this.ResultDate.CalcValue = laboratoryProcedure.ResultDate.ToString();
//                }
                
                
            }
            //
            
            Guid testID = new Guid(this.TESTID.CalcValue);
            //TTObjectContext context = new TTObjectContext(true);

            if(hasReqID1)
            {
                if (this.IsValidGuid(this.REQ1.CalcValue))
                {
                    Guid ReqID1 = new Guid(this.REQ1.CalcValue);
                    BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> procedures1 = LaboratoryProcedure.GetLabProcedureByTestAndRequest(context, ReqID1, testID);
                    foreach (LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class procedure in procedures1)
                    {
                        this.Result1.CalcValue = procedure.Result;
                        break;
                    }
                }
            }

            if(hasReqID2)
            {
                if (this.IsValidGuid(this.REQ2.CalcValue))
                {
                    Guid ReqID2 = new Guid(this.REQ2.CalcValue);
                    BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> procedures2 = LaboratoryProcedure.GetLabProcedureByTestAndRequest(context, ReqID2, testID);
                    foreach (LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class procedure in procedures2)
                    {
                        this.Result2.CalcValue = procedure.Result;
                        break;
                    }
                }
            }

            if(hasReqID3)
            {
                if (this.IsValidGuid(this.REQ3.CalcValue))
                {
                    Guid ReqID3 = new Guid(this.REQ3.CalcValue);
                    BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> procedures3 = LaboratoryProcedure.GetLabProcedureByTestAndRequest(context, ReqID3, testID);
                    foreach (LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class procedure in procedures3)
                    {
                        this.Result3.CalcValue = procedure.Result;
                        break;
                    }
                }
            }
#endregion PARENT HEADER_Script
                }
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportRTF LongReportRTF; 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                    LongReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 7, 0, 197, 1, false);
                    LongReportRTF.Name = "LongReportRTF";
                    LongReportRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LongReportRTF.CalcValue = LongReportRTF.Value;
                    return new TTReportObject[] { LongReportRTF};
                }
                public override void RunPreScript()
                {
#region PARENT FOOTER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((LaboratoryResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            this.LongReportRTF.Value = null;
            if(objectID != null)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
                
                if(laboratoryProcedure.LongReport != null)
                {
                    try
                    {
                        this.LongReportRTF.Value = laboratoryProcedure.LongReport.ToString();
                    }
                    catch(Exception ex)
                    {
                        // Hata almaması için yapıldı. RTF olmayan şeyler RTF'e çevrilecek
                        try
                        {
                            this.LongReportRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(laboratoryProcedure.LongReport.ToString());
                        }
                        catch(Exception exception)
                        {
                            
                        }
                    }
                }
                
                //Numune Red Sebebi burada yazdırılıyor...
                if(laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleReject)
                {
                    if (laboratoryProcedure.SampleRejectionReason != null)
                    {
                       //System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
                       // richTextBox.Text = "    Laboratuvar Numune Red : "+laboratoryProcedure.SampleRejectionReason.Reason.Trim();
                       // Sunucuda  System.Windows.Forms.RichTextBox kullanımı mümkün değil 31.10.2018 A.Ş:

                        string rtf = TTUtils.RtfHelper.ConvertoRTF("    Laboratuvar Numune Red : "+laboratoryProcedure.SampleRejectionReason.Reason.Trim());
                        this.LongReportRTF.Value = rtf;
                    }    
                        
                }
                
            }
#endregion PARENT FOOTER_PreScript
                }
            }

        }

        public PARENTGroup PARENT;

        public partial class PANELGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public PANELGroupHeader Header()
            {
                return (PANELGroupHeader)_header;
            }

            new public PANELGroupFooter Footer()
            {
                return (PANELGroupFooter)_footer;
            }

            public TTReportField TESTDEFID { get {return Header().TESTDEFID;} }
            public PANELGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PANELGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class>("GetLabGridPanelsNQL", LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARENT.TESTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PANELGroupHeader(this);
                _footer = new PANELGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PANELGroupHeader : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField TESTDEFID; 
                public PANELGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TESTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 240, 5, false);
                    TESTDEFID.Name = "TESTDEFID";
                    TESTDEFID.Visible = EvetHayirEnum.ehHayir;
                    TESTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTDEFID.TextFont.Name = "Arial Narrow";
                    TESTDEFID.TextFont.Size = 9;
                    TESTDEFID.TextFont.CharSet = 162;
                    TESTDEFID.Value = @"{#LABORATORYTEST#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class dataset_GetLabGridPanelsNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class>(0);
                    TESTDEFID.CalcValue = (dataset_GetLabGridPanelsNQL != null ? Globals.ToStringCore(dataset_GetLabGridPanelsNQL.LaboratoryTest) : "");
                    return new TTReportObject[] { TESTDEFID};
                }
            }
            public partial class PANELGroupFooter : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                 
                public PANELGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PANELGroup PANEL;

        public partial class MAINGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField LaboratorySubProcedureObjectName { get {return Body().LaboratorySubProcedureObjectName;} }
            public TTReportField SubResult { get {return Body().SubResult;} }
            public TTReportField SubReference { get {return Body().SubReference;} }
            public TTReportField SubUnit { get {return Body().SubUnit;} }
            public TTReportField WARNING1 { get {return Body().WARNING1;} }
            public TTReportField SubResult1 { get {return Body().SubResult1;} }
            public TTReportField SubResult2 { get {return Body().SubResult2;} }
            public TTReportField REQ1 { get {return Body().REQ1;} }
            public TTReportField REQ2 { get {return Body().REQ2;} }
            public TTReportField TESTID { get {return Body().TESTID;} }
            public TTReportField WarningSignSub { get {return Body().WarningSignSub;} }
            public TTReportField REQ3 { get {return Body().REQ3;} }
            public TTReportField SubResult3 { get {return Body().SubResult3;} }
            public TTReportField TESTOBJECTID { get {return Body().TESTOBJECTID;} }
            public TTReportField LongReportForSubProcedure { get {return Body().LongReportForSubProcedure;} }
            public TTReportField UzunRaporLabel { get {return Body().UzunRaporLabel;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratorySubProcedure.GetLabSubProcByTestDef_Class>("GetLabSubProcByTestDef", LaboratorySubProcedure.GetLabSubProcByTestDef((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARENT.OBJID.CalcValue),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PANEL.TESTDEFID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportField LaboratorySubProcedureObjectName;
                public TTReportField SubResult;
                public TTReportField SubReference;
                public TTReportField SubUnit;
                public TTReportField WARNING1;
                public TTReportField SubResult1;
                public TTReportField SubResult2;
                public TTReportField REQ1;
                public TTReportField REQ2;
                public TTReportField TESTID;
                public TTReportField WarningSignSub;
                public TTReportField REQ3;
                public TTReportField SubResult3;
                public TTReportField TESTOBJECTID;
                public TTReportField LongReportForSubProcedure;
                public TTReportField UzunRaporLabel; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LaboratorySubProcedureObjectName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 67, 5, false);
                    LaboratorySubProcedureObjectName.Name = "LaboratorySubProcedureObjectName";
                    LaboratorySubProcedureObjectName.FieldType = ReportFieldTypeEnum.ftVariable;
                    LaboratorySubProcedureObjectName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LaboratorySubProcedureObjectName.MultiLine = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.NoClip = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.WordBreak = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.ExpandTabs = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.TextFont.Name = "Microsoft Sans Serif";
                    LaboratorySubProcedureObjectName.TextFont.Size = 8;
                    LaboratorySubProcedureObjectName.TextFont.CharSet = 162;
                    LaboratorySubProcedureObjectName.Value = @"{#NAME#}";

                    SubResult = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 1, 94, 5, false);
                    SubResult.Name = "SubResult";
                    SubResult.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubResult.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubResult.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult.NoClip = EvetHayirEnum.ehEvet;
                    SubResult.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult.TextFont.Name = "Microsoft Sans Serif";
                    SubResult.TextFont.Size = 8;
                    SubResult.TextFont.CharSet = 162;
                    SubResult.Value = @"{#RESULT#}";

                    SubReference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 1, 155, 5, false);
                    SubReference.Name = "SubReference";
                    SubReference.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubReference.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubReference.MultiLine = EvetHayirEnum.ehEvet;
                    SubReference.NoClip = EvetHayirEnum.ehEvet;
                    SubReference.WordBreak = EvetHayirEnum.ehEvet;
                    SubReference.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubReference.TextFont.Name = "Microsoft Sans Serif";
                    SubReference.TextFont.Size = 8;
                    SubReference.TextFont.CharSet = 162;
                    SubReference.Value = @"{#REFERENCE#}";

                    SubUnit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 1, 122, 5, false);
                    SubUnit.Name = "SubUnit";
                    SubUnit.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubUnit.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubUnit.MultiLine = EvetHayirEnum.ehEvet;
                    SubUnit.NoClip = EvetHayirEnum.ehEvet;
                    SubUnit.WordBreak = EvetHayirEnum.ehEvet;
                    SubUnit.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubUnit.TextFont.Name = "Microsoft Sans Serif";
                    SubUnit.TextFont.Size = 8;
                    SubUnit.TextFont.CharSet = 162;
                    SubUnit.Value = @"{#UNIT#}";

                    WARNING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 231, 5, false);
                    WARNING1.Name = "WARNING1";
                    WARNING1.Visible = EvetHayirEnum.ehHayir;
                    WARNING1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WARNING1.ObjectDefName = "HighLowEnum";
                    WARNING1.DataMember = "DISPLAYTEXT";
                    WARNING1.TextFont.Name = "Arial Narrow";
                    WARNING1.TextFont.Size = 9;
                    WARNING1.TextFont.CharSet = 162;
                    WARNING1.Value = @"{#WARNING#}";

                    SubResult1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 173, 5, false);
                    SubResult1.Name = "SubResult1";
                    SubResult1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubResult1.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult1.NoClip = EvetHayirEnum.ehEvet;
                    SubResult1.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult1.TextFont.Name = "Microsoft Sans Serif";
                    SubResult1.TextFont.Size = 8;
                    SubResult1.TextFont.CharSet = 162;
                    SubResult1.Value = @"";

                    SubResult2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 1, 185, 5, false);
                    SubResult2.Name = "SubResult2";
                    SubResult2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubResult2.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult2.NoClip = EvetHayirEnum.ehEvet;
                    SubResult2.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult2.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult2.TextFont.Name = "Microsoft Sans Serif";
                    SubResult2.TextFont.Size = 8;
                    SubResult2.TextFont.CharSet = 162;
                    SubResult2.Value = @"";

                    REQ1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 241, 5, false);
                    REQ1.Name = "REQ1";
                    REQ1.Visible = EvetHayirEnum.ehHayir;
                    REQ1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ1.TextFont.Name = "Arial Narrow";
                    REQ1.TextFont.Size = 9;
                    REQ1.TextFont.CharSet = 162;
                    REQ1.Value = @"{%TABORDER.REQUEST1%}";

                    REQ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 253, 5, false);
                    REQ2.Name = "REQ2";
                    REQ2.Visible = EvetHayirEnum.ehHayir;
                    REQ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ2.TextFont.Name = "Arial Narrow";
                    REQ2.TextFont.Size = 9;
                    REQ2.TextFont.CharSet = 162;
                    REQ2.Value = @"{%TABORDER.REQUEST2%}";

                    TESTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 0, 292, 5, false);
                    TESTID.Name = "TESTID";
                    TESTID.Visible = EvetHayirEnum.ehHayir;
                    TESTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTID.TextFont.Name = "Arial Narrow";
                    TESTID.TextFont.Size = 9;
                    TESTID.TextFont.CharSet = 162;
                    TESTID.Value = @"{#PROCEDUREOBJECT#}";

                    WarningSignSub = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 1, 73, 5, false);
                    WarningSignSub.Name = "WarningSignSub";
                    WarningSignSub.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WarningSignSub.TextFont.Name = "Microsoft Sans Serif";
                    WarningSignSub.TextFont.Size = 9;
                    WarningSignSub.TextFont.CharSet = 162;
                    WarningSignSub.Value = @"";

                    REQ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 264, 5, false);
                    REQ3.Name = "REQ3";
                    REQ3.Visible = EvetHayirEnum.ehHayir;
                    REQ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ3.TextFont.Name = "Arial Narrow";
                    REQ3.TextFont.Size = 9;
                    REQ3.TextFont.CharSet = 162;
                    REQ3.Value = @"{%TABORDER.REQUEST3%}";

                    SubResult3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 197, 5, false);
                    SubResult3.Name = "SubResult3";
                    SubResult3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubResult3.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult3.NoClip = EvetHayirEnum.ehEvet;
                    SubResult3.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult3.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult3.TextFont.Name = "Microsoft Sans Serif";
                    SubResult3.TextFont.Size = 8;
                    SubResult3.TextFont.CharSet = 162;
                    SubResult3.Value = @"";

                    TESTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 0, 305, 5, false);
                    TESTOBJECTID.Name = "TESTOBJECTID";
                    TESTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TESTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTOBJECTID.TextFont.Name = "Arial Narrow";
                    TESTOBJECTID.TextFont.Size = 9;
                    TESTOBJECTID.TextFont.CharSet = 162;
                    TESTOBJECTID.Value = @"{#OBJECTID#}";

                    LongReportForSubProcedure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 161, 5, false);
                    LongReportForSubProcedure.Name = "LongReportForSubProcedure";
                    LongReportForSubProcedure.Visible = EvetHayirEnum.ehHayir;
                    LongReportForSubProcedure.FieldType = ReportFieldTypeEnum.ftVariable;
                    LongReportForSubProcedure.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LongReportForSubProcedure.MultiLine = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.NoClip = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.WordBreak = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.ExpandTabs = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.TextFont.Name = "Arial Narrow";
                    LongReportForSubProcedure.TextFont.Size = 8;
                    LongReportForSubProcedure.TextFont.CharSet = 162;
                    LongReportForSubProcedure.Value = @"";

                    UzunRaporLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 1, 92, 5, false);
                    UzunRaporLabel.Name = "UzunRaporLabel";
                    UzunRaporLabel.Visible = EvetHayirEnum.ehHayir;
                    UzunRaporLabel.TextFont.Name = "Arial";
                    UzunRaporLabel.TextFont.Size = 8;
                    UzunRaporLabel.TextFont.Bold = true;
                    UzunRaporLabel.TextFont.CharSet = 162;
                    UzunRaporLabel.Value = @"Uzun Rapor:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratorySubProcedure.GetLabSubProcByTestDef_Class dataset_GetLabSubProcByTestDef = ParentGroup.rsGroup.GetCurrentRecord<LaboratorySubProcedure.GetLabSubProcByTestDef_Class>(0);
                    LaboratorySubProcedureObjectName.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Name) : "");
                    SubResult.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Result) : "");
                    SubReference.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Reference) : "");
                    SubUnit.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Unit) : "");
                    WARNING1.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Warning) : "");
                    WARNING1.PostFieldValueCalculation();
                    SubResult1.CalcValue = SubResult1.Value;
                    SubResult2.CalcValue = SubResult2.Value;
                    REQ1.CalcValue = MyParentReport.TABORDER.REQUEST1.CalcValue;
                    REQ2.CalcValue = MyParentReport.TABORDER.REQUEST2.CalcValue;
                    TESTID.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.ProcedureObject) : "");
                    WarningSignSub.CalcValue = WarningSignSub.Value;
                    REQ3.CalcValue = MyParentReport.TABORDER.REQUEST3.CalcValue;
                    SubResult3.CalcValue = SubResult3.Value;
                    TESTOBJECTID.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.ObjectID) : "");
                    LongReportForSubProcedure.CalcValue = @"";
                    UzunRaporLabel.CalcValue = UzunRaporLabel.Value;
                    return new TTReportObject[] { LaboratorySubProcedureObjectName,SubResult,SubReference,SubUnit,WARNING1,SubResult1,SubResult2,REQ1,REQ2,TESTID,WarningSignSub,REQ3,SubResult3,TESTOBJECTID,LongReportForSubProcedure,UzunRaporLabel};
                }
#region MAIN BODY_Methods
            public bool IsValidGuid(string str)
        {
            Guid value;

            try
            {
                value = new Guid(str);
                return true;
            }
            catch(FormatException)
            {
                value = Guid.Empty;
                return false;
            }
        }
#endregion MAIN BODY_Methods

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.LongReportForSubProcedure.Visible = EvetHayirEnum.ehHayir; //***Başlangıçta gizleniyor...
            this.UzunRaporLabel.Visible = EvetHayirEnum.ehHayir; //***Başlangıçta gizleniyor...
            
            if(this.WARNING1.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.High)
               || this.WARNING1.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Low)
               || this.WARNING1.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Panic))
            {
                this.LaboratorySubProcedureObjectName.TextFont.Bold = true;
                this.SubResult.TextFont.Bold = true;
                this.SubReference.TextFont.Bold = true;
                this.SubUnit.TextFont.Bold = true;
                this.WarningSignSub.CalcValue = "*";
            }
            else
            {
                this.LaboratorySubProcedureObjectName.TextFont.Bold = false;
                this.SubResult.TextFont.Bold = false;
                this.SubReference.TextFont.Bold = false;
                this.SubUnit.TextFont.Bold = false;
                this.WarningSignSub.CalcValue = "";
            }
            
            bool hasReqID1 = false;
            bool hasReqID2 = false;
            bool hasReqID3 = false;

            if(this.REQ1.CalcValue != "REQUEST1")
                hasReqID1 = true;
            
            if(this.REQ2.CalcValue != "REQUEST2")
                hasReqID2 = true;
            
            if(this.REQ3.CalcValue != "REQUEST3")
                hasReqID3 = true;
            
            Guid testID = new Guid(this.TESTID.CalcValue);
            TTObjectContext context = new TTObjectContext(true);
            
            //
            string objectID = ((LaboratoryResultReport)ParentReport).MAIN.TESTOBJECTID.CalcValue.ToString();
            //string text = string.Empty;
            string text = this.LaboratorySubProcedureObjectName.CalcValue;
            
            LaboratorySubProcedure laboratorySubProcedure = (LaboratorySubProcedure)context.GetObject(new Guid(objectID),"LaboratorySubProcedure");
            
            if(laboratorySubProcedure.LongReport != null)
            {
                string longReportForSubProcedure = TTObjectClasses.Common.GetTextOfRTFString(laboratorySubProcedure.LongReport.ToString());
                longReportForSubProcedure = longReportForSubProcedure.Replace("  ", " ");
                longReportForSubProcedure = longReportForSubProcedure.Replace("\r\n", "");
                longReportForSubProcedure = longReportForSubProcedure.Replace("\r", "");
                longReportForSubProcedure = longReportForSubProcedure.Replace("\n", "");
                
                if(longReportForSubProcedure.Trim() != string.Empty)
                {
                    text = text + "\r\n     Rapor: "+longReportForSubProcedure+"  ";
                    this.LaboratorySubProcedureObjectName.CalcValue = text.ToString();
                    //text = text + longReportForSubProcedure;
                    //this.LongReportForSubProcedure.CalcValue = text.ToString();
                    //this.LongReportForSubProcedure.Visible = EvetHayirEnum.ehEvet; //***Başlangıçta gizlenmişti.Burada görüntüleniyor...
                    //this.UzunRaporLabel.Visible = EvetHayirEnum.ehEvet; //***Başlangıçta gizlenmişti.Burada görüntüleniyor...
                }
            }
            
            
            //
            
            
            
            if(hasReqID1)
            {
                if (this.IsValidGuid(this.REQ1.CalcValue))
                {
                    Guid ReqID1 = new Guid(this.REQ1.CalcValue);
                    BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> procedures1 = LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest(context, ReqID1, testID);
                    foreach (LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class procedure in procedures1)
                    {
                        this.SubResult1.CalcValue = procedure.Result;
                        break;
                    }
                }
            }

            if(hasReqID2)
            {
                if (this.IsValidGuid(this.REQ2.CalcValue))
                {
                    Guid ReqID2 = new Guid(this.REQ2.CalcValue);
                    BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> procedures2 = LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest(context, ReqID2, testID);
                    foreach (LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class procedure in procedures2)
                    {
                        this.SubResult2.CalcValue = procedure.Result;
                        break;
                    }
                }
            }
            
            if(hasReqID3)
            {
                if (this.IsValidGuid(this.REQ3.CalcValue))
                {
                    Guid ReqID3 = new Guid(this.REQ3.CalcValue);
                    BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> procedures3 = LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest(context, ReqID3, testID);
                    foreach (LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class procedure in procedures3)
                    {
                        this.SubResult3.CalcValue = procedure.Result;
                        break;
                    }
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class REFERENCEGroup : TTReportGroup
        {
            public LaboratoryResultReport MyParentReport
            {
                get { return (LaboratoryResultReport)ParentReport; }
            }

            new public REFERENCEGroupBody Body()
            {
                return (REFERENCEGroupBody)_body;
            }
            public TTReportRTF SpecialRefer { get {return Body().SpecialRefer;} }
            public REFERENCEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REFERENCEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new REFERENCEGroupBody(this);
            }

            public partial class REFERENCEGroupBody : TTReportSection
            {
                public LaboratoryResultReport MyParentReport
                {
                    get { return (LaboratoryResultReport)ParentReport; }
                }
                
                public TTReportRTF SpecialRefer; 
                public REFERENCEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                    SpecialRefer = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 135, 0, 192, 2, false);
                    SpecialRefer.Name = "SpecialRefer";
                    SpecialRefer.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SpecialRefer.CalcValue = SpecialRefer.Value;
                    return new TTReportObject[] { SpecialRefer};
                }
                public override void RunPreScript()
                {
#region REFERENCE BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((LaboratoryResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            if(objectID != null)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
                if(laboratoryProcedure.SpecialReference != null)
                    this.SpecialRefer.Value = laboratoryProcedure.SpecialReference.ToString();
                else
                    this.SpecialRefer.Value = null;
            }
            
            if(this.SpecialRefer.Value == null)
                this.SpecialRefer.Visible = EvetHayirEnum.ehHayir;
#endregion REFERENCE BODY_PreScript
                }
            }

        }

        public REFERENCEGroup REFERENCE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public LaboratoryResultReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            TABORDER = new TABORDERGroup(HEADER,"TABORDER");
            TAB = new TABGroup(TABORDER,"TAB");
            GROUP = new GROUPGroup(TAB,"GROUP");
            PARENT = new PARENTGroup(GROUP,"PARENT");
            PANEL = new PANELGroup(PARENT,"PANEL");
            MAIN = new MAINGroup(PANEL,"MAIN");
            REFERENCE = new REFERENCEGroup(PANEL,"REFERENCE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protokol No", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f1afb241-e28f-4f1a-84a3-e7fe12256626");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "LABORATORYRESULTREPORT";
            Caption = "Laboratuvar Sonuç Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UsePrinterMargins = EvetHayirEnum.ehEvet;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}