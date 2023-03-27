
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
    /// Laboratuvar İkili Tarama Bilgi Formu
    /// </summary>
    public partial class LaboratoryBinaryScanInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public LaboratoryBinaryScanInfoReport MyParentReport
            {
                get { return (LaboratoryBinaryScanInfoReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public LaboratoryBinaryScanInfoReport MyParentReport
                {
                    get { return (LaboratoryBinaryScanInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField XXXXXXBASLIK111; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 200, 36, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Size = 11;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"1° TRIMESTER (8-13 Hafta) DOWN SENDROMU, TRISOMY 18 VE NÖRAL TÜP DEFEKT TARAMA HASTA FORMU";

                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 7, 160, 29, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Size = 11;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.TextFont.CharSet = 162;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1121,XXXXXXBASLIK111};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public LaboratoryBinaryScanInfoReport MyParentReport
                {
                    get { return (LaboratoryBinaryScanInfoReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public LaboratoryBinaryScanInfoReport MyParentReport
            {
                get { return (LaboratoryBinaryScanInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblPatientName1 { get {return Body().lblPatientName1;} }
            public TTReportField dotsPatientName1 { get {return Body().dotsPatientName1;} }
            public TTReportField lblPatientName2 { get {return Body().lblPatientName2;} }
            public TTReportField dotsPatientName2 { get {return Body().dotsPatientName2;} }
            public TTReportField PatientName { get {return Body().PatientName;} }
            public TTReportField PatientSurName { get {return Body().PatientSurName;} }
            public TTReportField lblPatientName11 { get {return Body().lblPatientName11;} }
            public TTReportField dotsPatientName11 { get {return Body().dotsPatientName11;} }
            public TTReportField PatientBirthDate { get {return Body().PatientBirthDate;} }
            public TTReportField lblPatientPhone12 { get {return Body().lblPatientPhone12;} }
            public TTReportField dotsPatientName12 { get {return Body().dotsPatientName12;} }
            public TTReportField PatientPhoneNumber { get {return Body().PatientPhoneNumber;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField lblPatientName111 { get {return Body().lblPatientName111;} }
            public TTReportField dotsPatientName111 { get {return Body().dotsPatientName111;} }
            public TTReportField SerumReceiptDate { get {return Body().SerumReceiptDate;} }
            public TTReportField lblPatientName1111 { get {return Body().lblPatientName1111;} }
            public TTReportField dotsPatientName1111 { get {return Body().dotsPatientName1111;} }
            public TTReportField LastMenstrualDate { get {return Body().LastMenstrualDate;} }
            public TTReportField lblPatientName11111 { get {return Body().lblPatientName11111;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField lblPatientName1112 { get {return Body().lblPatientName1112;} }
            public TTReportField dotsPatientName1112 { get {return Body().dotsPatientName1112;} }
            public TTReportField UltrasoundDate { get {return Body().UltrasoundDate;} }
            public TTReportField lblPatientPhone121 { get {return Body().lblPatientPhone121;} }
            public TTReportField dotsPatientName121 { get {return Body().dotsPatientName121;} }
            public TTReportField CrlMeasurement { get {return Body().CrlMeasurement;} }
            public TTReportField lblPatientName111111 { get {return Body().lblPatientName111111;} }
            public TTReportField lblPatientName12111 { get {return Body().lblPatientName12111;} }
            public TTReportField dotsPatientName12111 { get {return Body().dotsPatientName12111;} }
            public TTReportField NuchalTranslucency { get {return Body().NuchalTranslucency;} }
            public TTReportField lblPatientName1111111 { get {return Body().lblPatientName1111111;} }
            public TTReportField lblPatientPhone1121 { get {return Body().lblPatientPhone1121;} }
            public TTReportField dotsPatientName1121 { get {return Body().dotsPatientName1121;} }
            public TTReportField AbnormalitiesOnUltrasound { get {return Body().AbnormalitiesOnUltrasound;} }
            public TTReportField lblPatientPhone11211 { get {return Body().lblPatientPhone11211;} }
            public TTReportField dotsPatientName11211 { get {return Body().dotsPatientName11211;} }
            public TTReportField NasalBone { get {return Body().NasalBone;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField lblPatientName111112 { get {return Body().lblPatientName111112;} }
            public TTReportField lblPatientName1111112 { get {return Body().lblPatientName1111112;} }
            public TTReportField dotsPatientName111121 { get {return Body().dotsPatientName111121;} }
            public TTReportField MaternalWeight { get {return Body().MaternalWeight;} }
            public TTReportField lblPatientName11111111 { get {return Body().lblPatientName11111111;} }
            public TTReportField lblPatientName12111111 { get {return Body().lblPatientName12111111;} }
            public TTReportField dotsPatientName1121111 { get {return Body().dotsPatientName1121111;} }
            public TTReportField lblPatientName12111112 { get {return Body().lblPatientName12111112;} }
            public TTReportField dotsPatientName1121112 { get {return Body().dotsPatientName1121112;} }
            public TTReportField lblPatientName12111113 { get {return Body().lblPatientName12111113;} }
            public TTReportField dotsPatientName1121113 { get {return Body().dotsPatientName1121113;} }
            public TTReportField lblPatientName12111114 { get {return Body().lblPatientName12111114;} }
            public TTReportField dotsPatientName1121114 { get {return Body().dotsPatientName1121114;} }
            public TTReportField Smoking { get {return Body().Smoking;} }
            public TTReportField InsulinDependentDiabetes { get {return Body().InsulinDependentDiabetes;} }
            public TTReportField IVF { get {return Body().IVF;} }
            public TTReportField TwinPregnancy { get {return Body().TwinPregnancy;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
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
                list[0] = new TTReportNqlData<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class>("LaboratoryBinaryScanInfoNQL", LaboratoryRequest.LaboratoryBinaryScanInfoNQL((string)TTObjectDefManager.Instance.DataTypes["String_255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public LaboratoryBinaryScanInfoReport MyParentReport
                {
                    get { return (LaboratoryBinaryScanInfoReport)ParentReport; }
                }
                
                public TTReportField lblPatientName1;
                public TTReportField dotsPatientName1;
                public TTReportField lblPatientName2;
                public TTReportField dotsPatientName2;
                public TTReportField PatientName;
                public TTReportField PatientSurName;
                public TTReportField lblPatientName11;
                public TTReportField dotsPatientName11;
                public TTReportField PatientBirthDate;
                public TTReportField lblPatientPhone12;
                public TTReportField dotsPatientName12;
                public TTReportField PatientPhoneNumber;
                public TTReportField NewField1;
                public TTReportField lblPatientName111;
                public TTReportField dotsPatientName111;
                public TTReportField SerumReceiptDate;
                public TTReportField lblPatientName1111;
                public TTReportField dotsPatientName1111;
                public TTReportField LastMenstrualDate;
                public TTReportField lblPatientName11111;
                public TTReportField NewField11;
                public TTReportField lblPatientName1112;
                public TTReportField dotsPatientName1112;
                public TTReportField UltrasoundDate;
                public TTReportField lblPatientPhone121;
                public TTReportField dotsPatientName121;
                public TTReportField CrlMeasurement;
                public TTReportField lblPatientName111111;
                public TTReportField lblPatientName12111;
                public TTReportField dotsPatientName12111;
                public TTReportField NuchalTranslucency;
                public TTReportField lblPatientName1111111;
                public TTReportField lblPatientPhone1121;
                public TTReportField dotsPatientName1121;
                public TTReportField AbnormalitiesOnUltrasound;
                public TTReportField lblPatientPhone11211;
                public TTReportField dotsPatientName11211;
                public TTReportField NasalBone;
                public TTReportField NewField111;
                public TTReportField lblPatientName111112;
                public TTReportField lblPatientName1111112;
                public TTReportField dotsPatientName111121;
                public TTReportField MaternalWeight;
                public TTReportField lblPatientName11111111;
                public TTReportField lblPatientName12111111;
                public TTReportField dotsPatientName1121111;
                public TTReportField lblPatientName12111112;
                public TTReportField dotsPatientName1121112;
                public TTReportField lblPatientName12111113;
                public TTReportField dotsPatientName1121113;
                public TTReportField lblPatientName12111114;
                public TTReportField dotsPatientName1121114;
                public TTReportField Smoking;
                public TTReportField InsulinDependentDiabetes;
                public TTReportField IVF;
                public TTReportField TwinPregnancy;
                public TTReportField NewField1111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 121;
                    RepeatCount = 0;
                    
                    lblPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 45, 11, false);
                    lblPatientName1.Name = "lblPatientName1";
                    lblPatientName1.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1.TextFont.Size = 9;
                    lblPatientName1.TextFont.Bold = true;
                    lblPatientName1.TextFont.CharSet = 162;
                    lblPatientName1.Value = @"Adı";

                    dotsPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 6, 48, 11, false);
                    dotsPatientName1.Name = "dotsPatientName1";
                    dotsPatientName1.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1.TextFont.Size = 9;
                    dotsPatientName1.TextFont.Bold = true;
                    dotsPatientName1.TextFont.CharSet = 162;
                    dotsPatientName1.Value = @":";

                    lblPatientName2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 6, 140, 11, false);
                    lblPatientName2.Name = "lblPatientName2";
                    lblPatientName2.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName2.TextFont.Size = 9;
                    lblPatientName2.TextFont.Bold = true;
                    lblPatientName2.TextFont.CharSet = 162;
                    lblPatientName2.Value = @"Soyadı";

                    dotsPatientName2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 6, 143, 11, false);
                    dotsPatientName2.Name = "dotsPatientName2";
                    dotsPatientName2.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName2.TextFont.Size = 9;
                    dotsPatientName2.TextFont.Bold = true;
                    dotsPatientName2.TextFont.CharSet = 162;
                    dotsPatientName2.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 6, 105, 11, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Microsoft Sans Serif";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#}";

                    PatientSurName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 6, 200, 11, false);
                    PatientSurName.Name = "PatientSurName";
                    PatientSurName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSurName.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientSurName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSurName.TextFont.Name = "Microsoft Sans Serif";
                    PatientSurName.TextFont.Size = 9;
                    PatientSurName.TextFont.CharSet = 162;
                    PatientSurName.Value = @"{#SURNAME#}";

                    lblPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 45, 17, false);
                    lblPatientName11.Name = "lblPatientName11";
                    lblPatientName11.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11.TextFont.Size = 9;
                    lblPatientName11.TextFont.Bold = true;
                    lblPatientName11.TextFont.CharSet = 162;
                    lblPatientName11.Value = @"Doğum Tarihi";

                    dotsPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 12, 48, 17, false);
                    dotsPatientName11.Name = "dotsPatientName11";
                    dotsPatientName11.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11.TextFont.Size = 9;
                    dotsPatientName11.TextFont.Bold = true;
                    dotsPatientName11.TextFont.CharSet = 162;
                    dotsPatientName11.Value = @":";

                    PatientBirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 12, 105, 17, false);
                    PatientBirthDate.Name = "PatientBirthDate";
                    PatientBirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientBirthDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientBirthDate.TextFormat = @"dd/MM/yyyy";
                    PatientBirthDate.MultiLine = EvetHayirEnum.ehEvet;
                    PatientBirthDate.TextFont.Name = "Microsoft Sans Serif";
                    PatientBirthDate.TextFont.Size = 9;
                    PatientBirthDate.TextFont.CharSet = 162;
                    PatientBirthDate.Value = @"{#BIRTHDATE#}";

                    lblPatientPhone12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 12, 141, 17, false);
                    lblPatientPhone12.Name = "lblPatientPhone12";
                    lblPatientPhone12.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientPhone12.TextFont.Size = 9;
                    lblPatientPhone12.TextFont.Bold = true;
                    lblPatientPhone12.TextFont.CharSet = 162;
                    lblPatientPhone12.Value = @"Telefon No";

                    dotsPatientName12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 12, 143, 17, false);
                    dotsPatientName12.Name = "dotsPatientName12";
                    dotsPatientName12.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName12.TextFont.Size = 9;
                    dotsPatientName12.TextFont.Bold = true;
                    dotsPatientName12.TextFont.CharSet = 162;
                    dotsPatientName12.Value = @":";

                    PatientPhoneNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 12, 200, 17, false);
                    PatientPhoneNumber.Name = "PatientPhoneNumber";
                    PatientPhoneNumber.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientPhoneNumber.MultiLine = EvetHayirEnum.ehEvet;
                    PatientPhoneNumber.TextFont.Name = "Microsoft Sans Serif";
                    PatientPhoneNumber.TextFont.Size = 9;
                    PatientPhoneNumber.TextFont.CharSet = 162;
                    PatientPhoneNumber.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 200, 23, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Italic = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                    lblPatientName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 25, 45, 30, false);
                    lblPatientName111.Name = "lblPatientName111";
                    lblPatientName111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111.TextFont.Size = 9;
                    lblPatientName111.TextFont.Bold = true;
                    lblPatientName111.TextFont.CharSet = 162;
                    lblPatientName111.Value = @"Serum Alınış Tarihi";

                    dotsPatientName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 25, 48, 30, false);
                    dotsPatientName111.Name = "dotsPatientName111";
                    dotsPatientName111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName111.TextFont.Size = 9;
                    dotsPatientName111.TextFont.Bold = true;
                    dotsPatientName111.TextFont.CharSet = 162;
                    dotsPatientName111.Value = @":";

                    SerumReceiptDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 25, 105, 30, false);
                    SerumReceiptDate.Name = "SerumReceiptDate";
                    SerumReceiptDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SerumReceiptDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    SerumReceiptDate.MultiLine = EvetHayirEnum.ehEvet;
                    SerumReceiptDate.TextFont.Name = "Microsoft Sans Serif";
                    SerumReceiptDate.TextFont.Size = 9;
                    SerumReceiptDate.TextFont.CharSet = 162;
                    SerumReceiptDate.Value = @"";

                    lblPatientName1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 31, 45, 36, false);
                    lblPatientName1111.Name = "lblPatientName1111";
                    lblPatientName1111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1111.TextFont.Size = 9;
                    lblPatientName1111.TextFont.Bold = true;
                    lblPatientName1111.TextFont.CharSet = 162;
                    lblPatientName1111.Value = @"Son Adet Tarihi";

                    dotsPatientName1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 31, 48, 36, false);
                    dotsPatientName1111.Name = "dotsPatientName1111";
                    dotsPatientName1111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1111.TextFont.Size = 9;
                    dotsPatientName1111.TextFont.Bold = true;
                    dotsPatientName1111.TextFont.CharSet = 162;
                    dotsPatientName1111.Value = @":";

                    LastMenstrualDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 31, 105, 36, false);
                    LastMenstrualDate.Name = "LastMenstrualDate";
                    LastMenstrualDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    LastMenstrualDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    LastMenstrualDate.MultiLine = EvetHayirEnum.ehEvet;
                    LastMenstrualDate.TextFont.Name = "Microsoft Sans Serif";
                    LastMenstrualDate.TextFont.Size = 9;
                    LastMenstrualDate.TextFont.CharSet = 162;
                    LastMenstrualDate.Value = @"";

                    lblPatientName11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 73, 48, false);
                    lblPatientName11111.Name = "lblPatientName11111";
                    lblPatientName11111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11111.TextFont.Size = 9;
                    lblPatientName11111.TextFont.Bold = true;
                    lblPatientName11111.TextFont.Italic = true;
                    lblPatientName11111.TextFont.CharSet = 162;
                    lblPatientName11111.Value = @"ULTRASOUND BİLGİSİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 37, 200, 42, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Italic = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                    lblPatientName1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 49, 45, 54, false);
                    lblPatientName1112.Name = "lblPatientName1112";
                    lblPatientName1112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1112.TextFont.Size = 9;
                    lblPatientName1112.TextFont.Bold = true;
                    lblPatientName1112.TextFont.CharSet = 162;
                    lblPatientName1112.Value = @"Ultrasound Tarihi";

                    dotsPatientName1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 49, 48, 54, false);
                    dotsPatientName1112.Name = "dotsPatientName1112";
                    dotsPatientName1112.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1112.TextFont.Size = 9;
                    dotsPatientName1112.TextFont.Bold = true;
                    dotsPatientName1112.TextFont.CharSet = 162;
                    dotsPatientName1112.Value = @":";

                    UltrasoundDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 49, 105, 54, false);
                    UltrasoundDate.Name = "UltrasoundDate";
                    UltrasoundDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    UltrasoundDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    UltrasoundDate.MultiLine = EvetHayirEnum.ehEvet;
                    UltrasoundDate.TextFont.Name = "Microsoft Sans Serif";
                    UltrasoundDate.TextFont.Size = 9;
                    UltrasoundDate.TextFont.CharSet = 162;
                    UltrasoundDate.Value = @"";

                    lblPatientPhone121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 49, 131, 54, false);
                    lblPatientPhone121.Name = "lblPatientPhone121";
                    lblPatientPhone121.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientPhone121.TextFont.Size = 9;
                    lblPatientPhone121.TextFont.Bold = true;
                    lblPatientPhone121.TextFont.CharSet = 162;
                    lblPatientPhone121.Value = @"CRL Ölçümü";

                    dotsPatientName121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 49, 134, 54, false);
                    dotsPatientName121.Name = "dotsPatientName121";
                    dotsPatientName121.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName121.TextFont.Size = 9;
                    dotsPatientName121.TextFont.Bold = true;
                    dotsPatientName121.TextFont.CharSet = 162;
                    dotsPatientName121.Value = @":";

                    CrlMeasurement = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 49, 141, 54, false);
                    CrlMeasurement.Name = "CrlMeasurement";
                    CrlMeasurement.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CrlMeasurement.MultiLine = EvetHayirEnum.ehEvet;
                    CrlMeasurement.TextFont.Name = "Microsoft Sans Serif";
                    CrlMeasurement.TextFont.Size = 9;
                    CrlMeasurement.TextFont.CharSet = 162;
                    CrlMeasurement.Value = @"";

                    lblPatientName111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 49, 192, 54, false);
                    lblPatientName111111.Name = "lblPatientName111111";
                    lblPatientName111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111111.TextFont.Size = 9;
                    lblPatientName111111.TextFont.Italic = true;
                    lblPatientName111111.TextFont.CharSet = 162;
                    lblPatientName111111.Value = @"mm (min: 45mm , max: 84mm)";

                    lblPatientName12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 55, 73, 60, false);
                    lblPatientName12111.Name = "lblPatientName12111";
                    lblPatientName12111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName12111.TextFont.Size = 9;
                    lblPatientName12111.TextFont.Bold = true;
                    lblPatientName12111.TextFont.CharSet = 162;
                    lblPatientName12111.Value = @"Nuchal Translucency Ölçümü(NT)";

                    dotsPatientName12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 55, 76, 60, false);
                    dotsPatientName12111.Name = "dotsPatientName12111";
                    dotsPatientName12111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName12111.TextFont.Size = 9;
                    dotsPatientName12111.TextFont.Bold = true;
                    dotsPatientName12111.TextFont.CharSet = 162;
                    dotsPatientName12111.Value = @":";

                    NuchalTranslucency = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 55, 83, 60, false);
                    NuchalTranslucency.Name = "NuchalTranslucency";
                    NuchalTranslucency.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NuchalTranslucency.MultiLine = EvetHayirEnum.ehEvet;
                    NuchalTranslucency.TextFont.Name = "Microsoft Sans Serif";
                    NuchalTranslucency.TextFont.Size = 9;
                    NuchalTranslucency.TextFont.CharSet = 162;
                    NuchalTranslucency.Value = @"";

                    lblPatientName1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 55, 90, 60, false);
                    lblPatientName1111111.Name = "lblPatientName1111111";
                    lblPatientName1111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1111111.TextFont.Size = 9;
                    lblPatientName1111111.TextFont.Italic = true;
                    lblPatientName1111111.TextFont.CharSet = 162;
                    lblPatientName1111111.Value = @"mm";

                    lblPatientPhone1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 61, 57, 66, false);
                    lblPatientPhone1121.Name = "lblPatientPhone1121";
                    lblPatientPhone1121.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientPhone1121.TextFont.Size = 9;
                    lblPatientPhone1121.TextFont.Bold = true;
                    lblPatientPhone1121.TextFont.CharSet = 162;
                    lblPatientPhone1121.Value = @"Ultrasound da anomali";

                    dotsPatientName1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 61, 60, 66, false);
                    dotsPatientName1121.Name = "dotsPatientName1121";
                    dotsPatientName1121.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1121.TextFont.Size = 9;
                    dotsPatientName1121.TextFont.Bold = true;
                    dotsPatientName1121.TextFont.CharSet = 162;
                    dotsPatientName1121.Value = @":";

                    AbnormalitiesOnUltrasound = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 61, 75, 66, false);
                    AbnormalitiesOnUltrasound.Name = "AbnormalitiesOnUltrasound";
                    AbnormalitiesOnUltrasound.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AbnormalitiesOnUltrasound.MultiLine = EvetHayirEnum.ehEvet;
                    AbnormalitiesOnUltrasound.TextFont.Name = "Microsoft Sans Serif";
                    AbnormalitiesOnUltrasound.TextFont.Size = 9;
                    AbnormalitiesOnUltrasound.TextFont.CharSet = 162;
                    AbnormalitiesOnUltrasound.Value = @"";

                    lblPatientPhone11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 67, 57, 72, false);
                    lblPatientPhone11211.Name = "lblPatientPhone11211";
                    lblPatientPhone11211.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientPhone11211.TextFont.Size = 9;
                    lblPatientPhone11211.TextFont.Bold = true;
                    lblPatientPhone11211.TextFont.CharSet = 162;
                    lblPatientPhone11211.Value = @"Nazal kemik";

                    dotsPatientName11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 67, 60, 72, false);
                    dotsPatientName11211.Name = "dotsPatientName11211";
                    dotsPatientName11211.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11211.TextFont.Size = 9;
                    dotsPatientName11211.TextFont.Bold = true;
                    dotsPatientName11211.TextFont.CharSet = 162;
                    dotsPatientName11211.Value = @":";

                    NasalBone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 67, 75, 72, false);
                    NasalBone.Name = "NasalBone";
                    NasalBone.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NasalBone.MultiLine = EvetHayirEnum.ehEvet;
                    NasalBone.TextFont.Name = "Microsoft Sans Serif";
                    NasalBone.TextFont.Size = 9;
                    NasalBone.TextFont.CharSet = 162;
                    NasalBone.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 73, 200, 78, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Italic = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                    lblPatientName111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 79, 73, 84, false);
                    lblPatientName111112.Name = "lblPatientName111112";
                    lblPatientName111112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111112.TextFont.Size = 9;
                    lblPatientName111112.TextFont.Bold = true;
                    lblPatientName111112.TextFont.Italic = true;
                    lblPatientName111112.TextFont.CharSet = 162;
                    lblPatientName111112.Value = @"DÜZELTME FAKTÖRLERİ";

                    lblPatientName1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 85, 73, 90, false);
                    lblPatientName1111112.Name = "lblPatientName1111112";
                    lblPatientName1111112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1111112.TextFont.Size = 9;
                    lblPatientName1111112.TextFont.CharSet = 162;
                    lblPatientName1111112.Value = @"Serum alınış tarihindeki meternal kilo";

                    dotsPatientName111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 85, 76, 90, false);
                    dotsPatientName111121.Name = "dotsPatientName111121";
                    dotsPatientName111121.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName111121.TextFont.Size = 9;
                    dotsPatientName111121.TextFont.Bold = true;
                    dotsPatientName111121.TextFont.CharSet = 162;
                    dotsPatientName111121.Value = @":";

                    MaternalWeight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 85, 83, 90, false);
                    MaternalWeight.Name = "MaternalWeight";
                    MaternalWeight.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MaternalWeight.MultiLine = EvetHayirEnum.ehEvet;
                    MaternalWeight.TextFont.Name = "Microsoft Sans Serif";
                    MaternalWeight.TextFont.Size = 9;
                    MaternalWeight.TextFont.CharSet = 162;
                    MaternalWeight.Value = @"";

                    lblPatientName11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 85, 88, 90, false);
                    lblPatientName11111111.Name = "lblPatientName11111111";
                    lblPatientName11111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11111111.TextFont.Size = 9;
                    lblPatientName11111111.TextFont.Italic = true;
                    lblPatientName11111111.TextFont.CharSet = 162;
                    lblPatientName11111111.Value = @"kg";

                    lblPatientName12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 91, 73, 96, false);
                    lblPatientName12111111.Name = "lblPatientName12111111";
                    lblPatientName12111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName12111111.TextFont.Size = 9;
                    lblPatientName12111111.TextFont.CharSet = 162;
                    lblPatientName12111111.Value = @"Sigara";

                    dotsPatientName1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 91, 76, 96, false);
                    dotsPatientName1121111.Name = "dotsPatientName1121111";
                    dotsPatientName1121111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1121111.TextFont.Size = 9;
                    dotsPatientName1121111.TextFont.Bold = true;
                    dotsPatientName1121111.TextFont.CharSet = 162;
                    dotsPatientName1121111.Value = @":";

                    lblPatientName12111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 97, 73, 102, false);
                    lblPatientName12111112.Name = "lblPatientName12111112";
                    lblPatientName12111112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName12111112.TextFont.Size = 9;
                    lblPatientName12111112.TextFont.CharSet = 162;
                    lblPatientName12111112.Value = @"İnsuline bağlı diyabet";

                    dotsPatientName1121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 97, 76, 102, false);
                    dotsPatientName1121112.Name = "dotsPatientName1121112";
                    dotsPatientName1121112.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1121112.TextFont.Size = 9;
                    dotsPatientName1121112.TextFont.Bold = true;
                    dotsPatientName1121112.TextFont.CharSet = 162;
                    dotsPatientName1121112.Value = @":";

                    lblPatientName12111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 103, 73, 108, false);
                    lblPatientName12111113.Name = "lblPatientName12111113";
                    lblPatientName12111113.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName12111113.TextFont.Size = 9;
                    lblPatientName12111113.TextFont.CharSet = 162;
                    lblPatientName12111113.Value = @"IVF";

                    dotsPatientName1121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 103, 76, 108, false);
                    dotsPatientName1121113.Name = "dotsPatientName1121113";
                    dotsPatientName1121113.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1121113.TextFont.Size = 9;
                    dotsPatientName1121113.TextFont.Bold = true;
                    dotsPatientName1121113.TextFont.CharSet = 162;
                    dotsPatientName1121113.Value = @":";

                    lblPatientName12111114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 109, 73, 114, false);
                    lblPatientName12111114.Name = "lblPatientName12111114";
                    lblPatientName12111114.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName12111114.TextFont.Size = 9;
                    lblPatientName12111114.TextFont.CharSet = 162;
                    lblPatientName12111114.Value = @"İkiz gebelik";

                    dotsPatientName1121114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 109, 76, 114, false);
                    dotsPatientName1121114.Name = "dotsPatientName1121114";
                    dotsPatientName1121114.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1121114.TextFont.Size = 9;
                    dotsPatientName1121114.TextFont.Bold = true;
                    dotsPatientName1121114.TextFont.CharSet = 162;
                    dotsPatientName1121114.Value = @":";

                    Smoking = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 91, 91, 96, false);
                    Smoking.Name = "Smoking";
                    Smoking.CaseFormat = CaseFormatEnum.fcUpperCase;
                    Smoking.MultiLine = EvetHayirEnum.ehEvet;
                    Smoking.TextFont.Name = "Microsoft Sans Serif";
                    Smoking.TextFont.Size = 9;
                    Smoking.TextFont.CharSet = 162;
                    Smoking.Value = @"";

                    InsulinDependentDiabetes = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 97, 91, 102, false);
                    InsulinDependentDiabetes.Name = "InsulinDependentDiabetes";
                    InsulinDependentDiabetes.CaseFormat = CaseFormatEnum.fcUpperCase;
                    InsulinDependentDiabetes.MultiLine = EvetHayirEnum.ehEvet;
                    InsulinDependentDiabetes.TextFont.Name = "Microsoft Sans Serif";
                    InsulinDependentDiabetes.TextFont.Size = 9;
                    InsulinDependentDiabetes.TextFont.CharSet = 162;
                    InsulinDependentDiabetes.Value = @"";

                    IVF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 103, 91, 108, false);
                    IVF.Name = "IVF";
                    IVF.CaseFormat = CaseFormatEnum.fcUpperCase;
                    IVF.MultiLine = EvetHayirEnum.ehEvet;
                    IVF.TextFont.Name = "Microsoft Sans Serif";
                    IVF.TextFont.Size = 9;
                    IVF.TextFont.CharSet = 162;
                    IVF.Value = @"";

                    TwinPregnancy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 109, 91, 114, false);
                    TwinPregnancy.Name = "TwinPregnancy";
                    TwinPregnancy.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TwinPregnancy.MultiLine = EvetHayirEnum.ehEvet;
                    TwinPregnancy.TextFont.Name = "Microsoft Sans Serif";
                    TwinPregnancy.TextFont.Size = 9;
                    TwinPregnancy.TextFont.CharSet = 162;
                    TwinPregnancy.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 115, 200, 120, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.Italic = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class dataset_LaboratoryBinaryScanInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class>(0);
                    lblPatientName1.CalcValue = lblPatientName1.Value;
                    dotsPatientName1.CalcValue = dotsPatientName1.Value;
                    lblPatientName2.CalcValue = lblPatientName2.Value;
                    dotsPatientName2.CalcValue = dotsPatientName2.Value;
                    PatientName.CalcValue = (dataset_LaboratoryBinaryScanInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryBinaryScanInfoNQL.Patientname) : "");
                    PatientSurName.CalcValue = (dataset_LaboratoryBinaryScanInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryBinaryScanInfoNQL.Surname) : "");
                    lblPatientName11.CalcValue = lblPatientName11.Value;
                    dotsPatientName11.CalcValue = dotsPatientName11.Value;
                    PatientBirthDate.CalcValue = (dataset_LaboratoryBinaryScanInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryBinaryScanInfoNQL.BirthDate) : "");
                    lblPatientPhone12.CalcValue = lblPatientPhone12.Value;
                    dotsPatientName12.CalcValue = dotsPatientName12.Value;
                    PatientPhoneNumber.CalcValue = PatientPhoneNumber.Value;
                    NewField1.CalcValue = NewField1.Value;
                    lblPatientName111.CalcValue = lblPatientName111.Value;
                    dotsPatientName111.CalcValue = dotsPatientName111.Value;
                    SerumReceiptDate.CalcValue = SerumReceiptDate.Value;
                    lblPatientName1111.CalcValue = lblPatientName1111.Value;
                    dotsPatientName1111.CalcValue = dotsPatientName1111.Value;
                    LastMenstrualDate.CalcValue = LastMenstrualDate.Value;
                    lblPatientName11111.CalcValue = lblPatientName11111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    lblPatientName1112.CalcValue = lblPatientName1112.Value;
                    dotsPatientName1112.CalcValue = dotsPatientName1112.Value;
                    UltrasoundDate.CalcValue = UltrasoundDate.Value;
                    lblPatientPhone121.CalcValue = lblPatientPhone121.Value;
                    dotsPatientName121.CalcValue = dotsPatientName121.Value;
                    CrlMeasurement.CalcValue = CrlMeasurement.Value;
                    lblPatientName111111.CalcValue = lblPatientName111111.Value;
                    lblPatientName12111.CalcValue = lblPatientName12111.Value;
                    dotsPatientName12111.CalcValue = dotsPatientName12111.Value;
                    NuchalTranslucency.CalcValue = NuchalTranslucency.Value;
                    lblPatientName1111111.CalcValue = lblPatientName1111111.Value;
                    lblPatientPhone1121.CalcValue = lblPatientPhone1121.Value;
                    dotsPatientName1121.CalcValue = dotsPatientName1121.Value;
                    AbnormalitiesOnUltrasound.CalcValue = AbnormalitiesOnUltrasound.Value;
                    lblPatientPhone11211.CalcValue = lblPatientPhone11211.Value;
                    dotsPatientName11211.CalcValue = dotsPatientName11211.Value;
                    NasalBone.CalcValue = NasalBone.Value;
                    NewField111.CalcValue = NewField111.Value;
                    lblPatientName111112.CalcValue = lblPatientName111112.Value;
                    lblPatientName1111112.CalcValue = lblPatientName1111112.Value;
                    dotsPatientName111121.CalcValue = dotsPatientName111121.Value;
                    MaternalWeight.CalcValue = MaternalWeight.Value;
                    lblPatientName11111111.CalcValue = lblPatientName11111111.Value;
                    lblPatientName12111111.CalcValue = lblPatientName12111111.Value;
                    dotsPatientName1121111.CalcValue = dotsPatientName1121111.Value;
                    lblPatientName12111112.CalcValue = lblPatientName12111112.Value;
                    dotsPatientName1121112.CalcValue = dotsPatientName1121112.Value;
                    lblPatientName12111113.CalcValue = lblPatientName12111113.Value;
                    dotsPatientName1121113.CalcValue = dotsPatientName1121113.Value;
                    lblPatientName12111114.CalcValue = lblPatientName12111114.Value;
                    dotsPatientName1121114.CalcValue = dotsPatientName1121114.Value;
                    Smoking.CalcValue = Smoking.Value;
                    InsulinDependentDiabetes.CalcValue = InsulinDependentDiabetes.Value;
                    IVF.CalcValue = IVF.Value;
                    TwinPregnancy.CalcValue = TwinPregnancy.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    return new TTReportObject[] { lblPatientName1,dotsPatientName1,lblPatientName2,dotsPatientName2,PatientName,PatientSurName,lblPatientName11,dotsPatientName11,PatientBirthDate,lblPatientPhone12,dotsPatientName12,PatientPhoneNumber,NewField1,lblPatientName111,dotsPatientName111,SerumReceiptDate,lblPatientName1111,dotsPatientName1111,LastMenstrualDate,lblPatientName11111,NewField11,lblPatientName1112,dotsPatientName1112,UltrasoundDate,lblPatientPhone121,dotsPatientName121,CrlMeasurement,lblPatientName111111,lblPatientName12111,dotsPatientName12111,NuchalTranslucency,lblPatientName1111111,lblPatientPhone1121,dotsPatientName1121,AbnormalitiesOnUltrasound,lblPatientPhone11211,dotsPatientName11211,NasalBone,NewField111,lblPatientName111112,lblPatientName1111112,dotsPatientName111121,MaternalWeight,lblPatientName11111111,lblPatientName12111111,dotsPatientName1121111,lblPatientName12111112,dotsPatientName1121112,lblPatientName12111113,dotsPatientName1121113,lblPatientName12111114,dotsPatientName1121114,Smoking,InsulinDependentDiabetes,IVF,TwinPregnancy,NewField1111};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((LaboratoryBinaryScanInfoReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            
            if(labRequest.LaboratoryBinaryScanInfo != null)
            {
                this.PatientPhoneNumber.CalcValue = labRequest.LaboratoryBinaryScanInfo.PatientPhoneNumber;
                this.SerumReceiptDate.CalcValue = labRequest.LaboratoryBinaryScanInfo.SerumReceiptDate.ToString();
                this.LastMenstrualDate.CalcValue = labRequest.LaboratoryBinaryScanInfo.LastMenstrualDate.ToString();
                this.UltrasoundDate.CalcValue = labRequest.LaboratoryBinaryScanInfo.UltrasoundDate.ToString();
                this.CrlMeasurement.CalcValue = labRequest.LaboratoryBinaryScanInfo.CrlMeasurement.ToString();
                this.NuchalTranslucency.CalcValue = labRequest.LaboratoryBinaryScanInfo.NuchalTranslucencyMeasurement.ToString();
                
                if((bool)labRequest.LaboratoryBinaryScanInfo.AbnormalitiesOnUltrasound)
                {
                    this.AbnormalitiesOnUltrasound.CalcValue = "Var";
                }
                else
                {
                    this.AbnormalitiesOnUltrasound.CalcValue = "Yok";
                }
                
                if((bool)labRequest.LaboratoryBinaryScanInfo.NasalBone)
                {
                    this.NasalBone.CalcValue = "Var";
                }
                else
                {
                    this.NasalBone.CalcValue = "Yok";
                }
                
                this.MaternalWeight.CalcValue = labRequest.LaboratoryBinaryScanInfo.MaternalWeight.ToString();
                
                if((bool)labRequest.LaboratoryBinaryScanInfo.Smoking)
                {
                    this.Smoking.CalcValue = "Evet";
                }
                else
                {
                    this.Smoking.CalcValue = "Hayır";
                }
                
                if((bool)labRequest.LaboratoryBinaryScanInfo.InsulinDependentDiabetes)
                {
                    this.InsulinDependentDiabetes.CalcValue = "Evet";
                }
                else
                {
                    this.InsulinDependentDiabetes.CalcValue = "Hayır";
                }
                
                if((bool)labRequest.LaboratoryBinaryScanInfo.Ivf)
                {
                    this.IVF.CalcValue = "Evet";
                }
                else
                {
                    this.IVF.CalcValue = "Hayır";
                }
                
                if((bool)labRequest.LaboratoryBinaryScanInfo.TwinPregnancy)
                {
                    this.TwinPregnancy.CalcValue = "Evet";
                }
                else
                {
                    this.TwinPregnancy.CalcValue = "Hayır";
                }
                
                
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public LaboratoryBinaryScanInfoReport()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "EpisodeActionID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "LABORATORYBINARYSCANINFOREPORT";
            Caption = "Laboratuvar İkili Tarama Bilgi Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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
            fd.TextFont.Name = "Arial Narrow";
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