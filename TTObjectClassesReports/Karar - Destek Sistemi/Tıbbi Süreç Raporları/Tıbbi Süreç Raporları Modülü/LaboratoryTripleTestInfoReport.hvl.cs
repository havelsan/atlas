
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
    /// Laboratuvar Triple Test Bilgi Formu
    /// </summary>
    public partial class LaboratoryTripleTestInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public LaboratoryTripleTestInfoReport MyParentReport
            {
                get { return (LaboratoryTripleTestInfoReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1111 { get {return Header().XXXXXXBASLIK1111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
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
                public LaboratoryTripleTestInfoReport MyParentReport
                {
                    get { return (LaboratoryTripleTestInfoReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1111;
                public TTReportField NewField11211; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 9, 161, 31, false);
                    XXXXXXBASLIK1111.Name = "XXXXXXBASLIK1111";
                    XXXXXXBASLIK1111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1111.TextFont.Size = 11;
                    XXXXXXBASLIK1111.TextFont.Bold = true;
                    XXXXXXBASLIK1111.TextFont.CharSet = 162;
                    XXXXXXBASLIK1111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 32, 202, 38, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Size = 11;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"TRİPLE TEST İSTEK FORMU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11211.CalcValue = NewField11211.Value;
                    XXXXXXBASLIK1111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField11211,XXXXXXBASLIK1111};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public LaboratoryTripleTestInfoReport MyParentReport
                {
                    get { return (LaboratoryTripleTestInfoReport)ParentReport; }
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
            public LaboratoryTripleTestInfoReport MyParentReport
            {
                get { return (LaboratoryTripleTestInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblPatientName111111 { get {return Body().lblPatientName111111;} }
            public TTReportField lblPatientName11 { get {return Body().lblPatientName11;} }
            public TTReportField dotsPatientName11 { get {return Body().dotsPatientName11;} }
            public TTReportField lblPatientName12 { get {return Body().lblPatientName12;} }
            public TTReportField dotsPatientName12 { get {return Body().dotsPatientName12;} }
            public TTReportField PatientName { get {return Body().PatientName;} }
            public TTReportField PatientSurName { get {return Body().PatientSurName;} }
            public TTReportField lblPatientName111 { get {return Body().lblPatientName111;} }
            public TTReportField dotsPatientName111 { get {return Body().dotsPatientName111;} }
            public TTReportField PatientBirthDate { get {return Body().PatientBirthDate;} }
            public TTReportField lblPatientPhone121 { get {return Body().lblPatientPhone121;} }
            public TTReportField dotsPatientName121 { get {return Body().dotsPatientName121;} }
            public TTReportField PatientPhoneNumber { get {return Body().PatientPhoneNumber;} }
            public TTReportField lblPatientName112 { get {return Body().lblPatientName112;} }
            public TTReportField dotsPatientName112 { get {return Body().dotsPatientName112;} }
            public TTReportField dotsPatientName1121111 { get {return Body().dotsPatientName1121111;} }
            public TTReportField PatientWeight { get {return Body().PatientWeight;} }
            public TTReportField lblPatientName111111111 { get {return Body().lblPatientName111111111;} }
            public TTReportField lblPatientName1211 { get {return Body().lblPatientName1211;} }
            public TTReportField lblPatientName11121 { get {return Body().lblPatientName11121;} }
            public TTReportField dotsPatientName11111211 { get {return Body().dotsPatientName11111211;} }
            public TTReportField IsHaveDiabetes { get {return Body().IsHaveDiabetes;} }
            public TTReportField lblPatientName112111 { get {return Body().lblPatientName112111;} }
            public TTReportField dotsPatientName111211111 { get {return Body().dotsPatientName111211111;} }
            public TTReportField Smoking { get {return Body().Smoking;} }
            public TTReportField lblPatientName112112 { get {return Body().lblPatientName112112;} }
            public TTReportField SmokingNumberPerADay { get {return Body().SmokingNumberPerADay;} }
            public TTReportField lblPatientName1211211 { get {return Body().lblPatientName1211211;} }
            public TTReportField lblPatientName11111 { get {return Body().lblPatientName11111;} }
            public TTReportField dotsPatientName11111 { get {return Body().dotsPatientName11111;} }
            public TTReportField LastMenstrualDate { get {return Body().LastMenstrualDate;} }
            public TTReportField dotsPatientName11111212 { get {return Body().dotsPatientName11111212;} }
            public TTReportField CycleLength { get {return Body().CycleLength;} }
            public TTReportField lblPatientName1111111111 { get {return Body().lblPatientName1111111111;} }
            public TTReportField lblPatientName11122 { get {return Body().lblPatientName11122;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField lblPatientName1111111 { get {return Body().lblPatientName1111111;} }
            public TTReportField lblPatientName111112 { get {return Body().lblPatientName111112;} }
            public TTReportField dotsPatientName111111 { get {return Body().dotsPatientName111111;} }
            public TTReportField UltrasoundDate { get {return Body().UltrasoundDate;} }
            public TTReportField lblPatientName122111 { get {return Body().lblPatientName122111;} }
            public TTReportField dotsPatientName121211111 { get {return Body().dotsPatientName121211111;} }
            public TTReportField GestationalAge { get {return Body().GestationalAge;} }
            public TTReportField lblPatientName1111111112 { get {return Body().lblPatientName1111111112;} }
            public TTReportField lblPatientName1211111 { get {return Body().lblPatientName1211111;} }
            public TTReportField dotsPatientName1111111 { get {return Body().dotsPatientName1111111;} }
            public TTReportField BiparietalDiameter { get {return Body().BiparietalDiameter;} }
            public TTReportField lblPatientName11121121 { get {return Body().lblPatientName11121121;} }
            public TTReportField lblPatientName111113 { get {return Body().lblPatientName111113;} }
            public TTReportField dotsPatientName111112 { get {return Body().dotsPatientName111112;} }
            public TTReportField RequestDate { get {return Body().RequestDate;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField lblPatientName1311111 { get {return Body().lblPatientName1311111;} }
            public TTReportField RequestDoctor { get {return Body().RequestDoctor;} }
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
                list[0] = new TTReportNqlData<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class>("LaboratoryTripleTestInfoNQL", LaboratoryRequest.LaboratoryTripleTestInfoNQL((string)TTObjectDefManager.Instance.DataTypes["String_255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public LaboratoryTripleTestInfoReport MyParentReport
                {
                    get { return (LaboratoryTripleTestInfoReport)ParentReport; }
                }
                
                public TTReportField lblPatientName111111;
                public TTReportField lblPatientName11;
                public TTReportField dotsPatientName11;
                public TTReportField lblPatientName12;
                public TTReportField dotsPatientName12;
                public TTReportField PatientName;
                public TTReportField PatientSurName;
                public TTReportField lblPatientName111;
                public TTReportField dotsPatientName111;
                public TTReportField PatientBirthDate;
                public TTReportField lblPatientPhone121;
                public TTReportField dotsPatientName121;
                public TTReportField PatientPhoneNumber;
                public TTReportField lblPatientName112;
                public TTReportField dotsPatientName112;
                public TTReportField dotsPatientName1121111;
                public TTReportField PatientWeight;
                public TTReportField lblPatientName111111111;
                public TTReportField lblPatientName1211;
                public TTReportField lblPatientName11121;
                public TTReportField dotsPatientName11111211;
                public TTReportField IsHaveDiabetes;
                public TTReportField lblPatientName112111;
                public TTReportField dotsPatientName111211111;
                public TTReportField Smoking;
                public TTReportField lblPatientName112112;
                public TTReportField SmokingNumberPerADay;
                public TTReportField lblPatientName1211211;
                public TTReportField lblPatientName11111;
                public TTReportField dotsPatientName11111;
                public TTReportField LastMenstrualDate;
                public TTReportField dotsPatientName11111212;
                public TTReportField CycleLength;
                public TTReportField lblPatientName1111111111;
                public TTReportField lblPatientName11122;
                public TTReportField NewField11;
                public TTReportField lblPatientName1111111;
                public TTReportField lblPatientName111112;
                public TTReportField dotsPatientName111111;
                public TTReportField UltrasoundDate;
                public TTReportField lblPatientName122111;
                public TTReportField dotsPatientName121211111;
                public TTReportField GestationalAge;
                public TTReportField lblPatientName1111111112;
                public TTReportField lblPatientName1211111;
                public TTReportField dotsPatientName1111111;
                public TTReportField BiparietalDiameter;
                public TTReportField lblPatientName11121121;
                public TTReportField lblPatientName111113;
                public TTReportField dotsPatientName111112;
                public TTReportField RequestDate;
                public TTReportField NewField111;
                public TTReportField lblPatientName1311111;
                public TTReportField RequestDoctor; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 133;
                    RepeatCount = 0;
                    
                    lblPatientName111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 75, 7, false);
                    lblPatientName111111.Name = "lblPatientName111111";
                    lblPatientName111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111111.TextFont.Size = 9;
                    lblPatientName111111.TextFont.Bold = true;
                    lblPatientName111111.TextFont.Italic = true;
                    lblPatientName111111.TextFont.CharSet = 162;
                    lblPatientName111111.Value = @"HASTA BİLGİLERİ";

                    lblPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 47, 13, false);
                    lblPatientName11.Name = "lblPatientName11";
                    lblPatientName11.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11.TextFont.Size = 9;
                    lblPatientName11.TextFont.Bold = true;
                    lblPatientName11.TextFont.CharSet = 162;
                    lblPatientName11.Value = @"Adı";

                    dotsPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 8, 50, 13, false);
                    dotsPatientName11.Name = "dotsPatientName11";
                    dotsPatientName11.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11.TextFont.Size = 9;
                    dotsPatientName11.TextFont.Bold = true;
                    dotsPatientName11.TextFont.CharSet = 162;
                    dotsPatientName11.Value = @":";

                    lblPatientName12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 142, 13, false);
                    lblPatientName12.Name = "lblPatientName12";
                    lblPatientName12.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName12.TextFont.Size = 9;
                    lblPatientName12.TextFont.Bold = true;
                    lblPatientName12.TextFont.CharSet = 162;
                    lblPatientName12.Value = @"Soyadı";

                    dotsPatientName12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 8, 145, 13, false);
                    dotsPatientName12.Name = "dotsPatientName12";
                    dotsPatientName12.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName12.TextFont.Size = 9;
                    dotsPatientName12.TextFont.Bold = true;
                    dotsPatientName12.TextFont.CharSet = 162;
                    dotsPatientName12.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 8, 107, 13, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Microsoft Sans Serif";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#}";

                    PatientSurName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 8, 202, 13, false);
                    PatientSurName.Name = "PatientSurName";
                    PatientSurName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSurName.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientSurName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSurName.TextFont.Name = "Microsoft Sans Serif";
                    PatientSurName.TextFont.Size = 9;
                    PatientSurName.TextFont.CharSet = 162;
                    PatientSurName.Value = @"{#SURNAME#}";

                    lblPatientName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 47, 19, false);
                    lblPatientName111.Name = "lblPatientName111";
                    lblPatientName111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111.TextFont.Size = 9;
                    lblPatientName111.TextFont.Bold = true;
                    lblPatientName111.TextFont.CharSet = 162;
                    lblPatientName111.Value = @"Doğum Tarihi";

                    dotsPatientName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 14, 50, 19, false);
                    dotsPatientName111.Name = "dotsPatientName111";
                    dotsPatientName111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName111.TextFont.Size = 9;
                    dotsPatientName111.TextFont.Bold = true;
                    dotsPatientName111.TextFont.CharSet = 162;
                    dotsPatientName111.Value = @":";

                    PatientBirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 14, 107, 19, false);
                    PatientBirthDate.Name = "PatientBirthDate";
                    PatientBirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientBirthDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientBirthDate.TextFormat = @"dd/MM/yyyy";
                    PatientBirthDate.MultiLine = EvetHayirEnum.ehEvet;
                    PatientBirthDate.TextFont.Name = "Microsoft Sans Serif";
                    PatientBirthDate.TextFont.Size = 9;
                    PatientBirthDate.TextFont.CharSet = 162;
                    PatientBirthDate.Value = @"{#BIRTHDATE#}";

                    lblPatientPhone121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 14, 143, 19, false);
                    lblPatientPhone121.Name = "lblPatientPhone121";
                    lblPatientPhone121.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientPhone121.TextFont.Size = 9;
                    lblPatientPhone121.TextFont.Bold = true;
                    lblPatientPhone121.TextFont.CharSet = 162;
                    lblPatientPhone121.Value = @"Telefon No";

                    dotsPatientName121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 14, 145, 19, false);
                    dotsPatientName121.Name = "dotsPatientName121";
                    dotsPatientName121.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName121.TextFont.Size = 9;
                    dotsPatientName121.TextFont.Bold = true;
                    dotsPatientName121.TextFont.CharSet = 162;
                    dotsPatientName121.Value = @":";

                    PatientPhoneNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 14, 202, 19, false);
                    PatientPhoneNumber.Name = "PatientPhoneNumber";
                    PatientPhoneNumber.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientPhoneNumber.MultiLine = EvetHayirEnum.ehEvet;
                    PatientPhoneNumber.TextFont.Name = "Microsoft Sans Serif";
                    PatientPhoneNumber.TextFont.Size = 9;
                    PatientPhoneNumber.TextFont.CharSet = 162;
                    PatientPhoneNumber.Value = @"";

                    lblPatientName112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 47, 25, false);
                    lblPatientName112.Name = "lblPatientName112";
                    lblPatientName112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName112.TextFont.Size = 9;
                    lblPatientName112.TextFont.Bold = true;
                    lblPatientName112.TextFont.CharSet = 162;
                    lblPatientName112.Value = @"Doğum Yeri";

                    dotsPatientName112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 20, 50, 25, false);
                    dotsPatientName112.Name = "dotsPatientName112";
                    dotsPatientName112.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName112.TextFont.Size = 9;
                    dotsPatientName112.TextFont.Bold = true;
                    dotsPatientName112.TextFont.CharSet = 162;
                    dotsPatientName112.Value = @":";

                    dotsPatientName1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 26, 50, 31, false);
                    dotsPatientName1121111.Name = "dotsPatientName1121111";
                    dotsPatientName1121111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1121111.TextFont.Size = 9;
                    dotsPatientName1121111.TextFont.Bold = true;
                    dotsPatientName1121111.TextFont.CharSet = 162;
                    dotsPatientName1121111.Value = @":";

                    PatientWeight = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 26, 57, 31, false);
                    PatientWeight.Name = "PatientWeight";
                    PatientWeight.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientWeight.MultiLine = EvetHayirEnum.ehEvet;
                    PatientWeight.TextFont.Name = "Microsoft Sans Serif";
                    PatientWeight.TextFont.Size = 9;
                    PatientWeight.TextFont.CharSet = 162;
                    PatientWeight.Value = @"";

                    lblPatientName111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 26, 62, 31, false);
                    lblPatientName111111111.Name = "lblPatientName111111111";
                    lblPatientName111111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111111111.TextFont.Size = 9;
                    lblPatientName111111111.TextFont.Italic = true;
                    lblPatientName111111111.TextFont.CharSet = 162;
                    lblPatientName111111111.Value = @"kg";

                    lblPatientName1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 47, 31, false);
                    lblPatientName1211.Name = "lblPatientName1211";
                    lblPatientName1211.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1211.TextFont.Size = 9;
                    lblPatientName1211.TextFont.Bold = true;
                    lblPatientName1211.TextFont.CharSet = 162;
                    lblPatientName1211.Value = @"Ağırlık";

                    lblPatientName11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 35, 52, 40, false);
                    lblPatientName11121.Name = "lblPatientName11121";
                    lblPatientName11121.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11121.TextFont.Size = 9;
                    lblPatientName11121.TextFont.Bold = true;
                    lblPatientName11121.TextFont.CharSet = 162;
                    lblPatientName11121.Value = @"Diyabeti var mı?";

                    dotsPatientName11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 35, 55, 40, false);
                    dotsPatientName11111211.Name = "dotsPatientName11111211";
                    dotsPatientName11111211.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11111211.TextFont.Size = 9;
                    dotsPatientName11111211.TextFont.Bold = true;
                    dotsPatientName11111211.TextFont.CharSet = 162;
                    dotsPatientName11111211.Value = @":";

                    IsHaveDiabetes = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 35, 72, 40, false);
                    IsHaveDiabetes.Name = "IsHaveDiabetes";
                    IsHaveDiabetes.CaseFormat = CaseFormatEnum.fcUpperCase;
                    IsHaveDiabetes.MultiLine = EvetHayirEnum.ehEvet;
                    IsHaveDiabetes.TextFont.Name = "Microsoft Sans Serif";
                    IsHaveDiabetes.TextFont.Size = 9;
                    IsHaveDiabetes.TextFont.CharSet = 162;
                    IsHaveDiabetes.Value = @"";

                    lblPatientName112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 41, 52, 46, false);
                    lblPatientName112111.Name = "lblPatientName112111";
                    lblPatientName112111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName112111.TextFont.Size = 9;
                    lblPatientName112111.TextFont.Bold = true;
                    lblPatientName112111.TextFont.CharSet = 162;
                    lblPatientName112111.Value = @"Sigara kullanıyor mu?";

                    dotsPatientName111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 41, 55, 46, false);
                    dotsPatientName111211111.Name = "dotsPatientName111211111";
                    dotsPatientName111211111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName111211111.TextFont.Size = 9;
                    dotsPatientName111211111.TextFont.Bold = true;
                    dotsPatientName111211111.TextFont.CharSet = 162;
                    dotsPatientName111211111.Value = @":";

                    Smoking = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 41, 72, 46, false);
                    Smoking.Name = "Smoking";
                    Smoking.CaseFormat = CaseFormatEnum.fcUpperCase;
                    Smoking.MultiLine = EvetHayirEnum.ehEvet;
                    Smoking.TextFont.Name = "Microsoft Sans Serif";
                    Smoking.TextFont.Size = 9;
                    Smoking.TextFont.CharSet = 162;
                    Smoking.Value = @"";

                    lblPatientName112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 41, 84, 46, false);
                    lblPatientName112112.Name = "lblPatientName112112";
                    lblPatientName112112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName112112.TextFont.Size = 9;
                    lblPatientName112112.TextFont.CharSet = 162;
                    lblPatientName112112.Value = @"Günde";

                    SmokingNumberPerADay = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 41, 90, 46, false);
                    SmokingNumberPerADay.Name = "SmokingNumberPerADay";
                    SmokingNumberPerADay.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SmokingNumberPerADay.MultiLine = EvetHayirEnum.ehEvet;
                    SmokingNumberPerADay.TextFont.Name = "Microsoft Sans Serif";
                    SmokingNumberPerADay.TextFont.Size = 9;
                    SmokingNumberPerADay.TextFont.CharSet = 162;
                    SmokingNumberPerADay.Value = @"";

                    lblPatientName1211211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 41, 101, 46, false);
                    lblPatientName1211211.Name = "lblPatientName1211211";
                    lblPatientName1211211.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1211211.TextFont.Size = 9;
                    lblPatientName1211211.TextFont.CharSet = 162;
                    lblPatientName1211211.Value = @"adet";

                    lblPatientName11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 47, 52, 52, false);
                    lblPatientName11111.Name = "lblPatientName11111";
                    lblPatientName11111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11111.TextFont.Size = 9;
                    lblPatientName11111.TextFont.Bold = true;
                    lblPatientName11111.TextFont.CharSet = 162;
                    lblPatientName11111.Value = @"Son Adet Tarihi";

                    dotsPatientName11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 47, 55, 52, false);
                    dotsPatientName11111.Name = "dotsPatientName11111";
                    dotsPatientName11111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11111.TextFont.Size = 9;
                    dotsPatientName11111.TextFont.Bold = true;
                    dotsPatientName11111.TextFont.CharSet = 162;
                    dotsPatientName11111.Value = @":";

                    LastMenstrualDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 47, 112, 52, false);
                    LastMenstrualDate.Name = "LastMenstrualDate";
                    LastMenstrualDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    LastMenstrualDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    LastMenstrualDate.MultiLine = EvetHayirEnum.ehEvet;
                    LastMenstrualDate.TextFont.Name = "Microsoft Sans Serif";
                    LastMenstrualDate.TextFont.Size = 9;
                    LastMenstrualDate.TextFont.CharSet = 162;
                    LastMenstrualDate.Value = @"";

                    dotsPatientName11111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 47, 150, 52, false);
                    dotsPatientName11111212.Name = "dotsPatientName11111212";
                    dotsPatientName11111212.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11111212.TextFont.Size = 9;
                    dotsPatientName11111212.TextFont.Bold = true;
                    dotsPatientName11111212.TextFont.CharSet = 162;
                    dotsPatientName11111212.Value = @":";

                    CycleLength = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 47, 156, 52, false);
                    CycleLength.Name = "CycleLength";
                    CycleLength.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CycleLength.MultiLine = EvetHayirEnum.ehEvet;
                    CycleLength.TextFont.Name = "Microsoft Sans Serif";
                    CycleLength.TextFont.Size = 9;
                    CycleLength.TextFont.CharSet = 162;
                    CycleLength.Value = @"";

                    lblPatientName1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 47, 163, 52, false);
                    lblPatientName1111111111.Name = "lblPatientName1111111111";
                    lblPatientName1111111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1111111111.TextFont.Size = 9;
                    lblPatientName1111111111.TextFont.Italic = true;
                    lblPatientName1111111111.TextFont.CharSet = 162;
                    lblPatientName1111111111.Value = @"gün";

                    lblPatientName11122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 47, 147, 52, false);
                    lblPatientName11122.Name = "lblPatientName11122";
                    lblPatientName11122.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11122.TextFont.Size = 9;
                    lblPatientName11122.TextFont.Bold = true;
                    lblPatientName11122.TextFont.CharSet = 162;
                    lblPatientName11122.Value = @"Siklus Uzunluğu";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 54, 202, 59, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Italic = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                    lblPatientName1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 61, 92, 66, false);
                    lblPatientName1111111.Name = "lblPatientName1111111";
                    lblPatientName1111111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1111111.TextFont.Size = 9;
                    lblPatientName1111111.TextFont.Bold = true;
                    lblPatientName1111111.TextFont.Italic = true;
                    lblPatientName1111111.TextFont.CharSet = 162;
                    lblPatientName1111111.Value = @"ULTRASONOGRAFİK İNCELEME BİLGİLERİ";

                    lblPatientName111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 67, 47, 72, false);
                    lblPatientName111112.Name = "lblPatientName111112";
                    lblPatientName111112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111112.TextFont.Size = 9;
                    lblPatientName111112.TextFont.Bold = true;
                    lblPatientName111112.TextFont.CharSet = 162;
                    lblPatientName111112.Value = @"US Tarihi";

                    dotsPatientName111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 67, 50, 72, false);
                    dotsPatientName111111.Name = "dotsPatientName111111";
                    dotsPatientName111111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName111111.TextFont.Size = 9;
                    dotsPatientName111111.TextFont.Bold = true;
                    dotsPatientName111111.TextFont.CharSet = 162;
                    dotsPatientName111111.Value = @":";

                    UltrasoundDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 67, 107, 72, false);
                    UltrasoundDate.Name = "UltrasoundDate";
                    UltrasoundDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    UltrasoundDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    UltrasoundDate.MultiLine = EvetHayirEnum.ehEvet;
                    UltrasoundDate.TextFont.Name = "Microsoft Sans Serif";
                    UltrasoundDate.TextFont.Size = 9;
                    UltrasoundDate.TextFont.CharSet = 162;
                    UltrasoundDate.Value = @"";

                    lblPatientName122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 67, 156, 72, false);
                    lblPatientName122111.Name = "lblPatientName122111";
                    lblPatientName122111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName122111.TextFont.Size = 9;
                    lblPatientName122111.TextFont.Bold = true;
                    lblPatientName122111.TextFont.CharSet = 162;
                    lblPatientName122111.Value = @"Us Sırasındaki Gebelik Yaşı";

                    dotsPatientName121211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 67, 159, 72, false);
                    dotsPatientName121211111.Name = "dotsPatientName121211111";
                    dotsPatientName121211111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName121211111.TextFont.Size = 9;
                    dotsPatientName121211111.TextFont.Bold = true;
                    dotsPatientName121211111.TextFont.CharSet = 162;
                    dotsPatientName121211111.Value = @":";

                    GestationalAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 67, 165, 72, false);
                    GestationalAge.Name = "GestationalAge";
                    GestationalAge.CaseFormat = CaseFormatEnum.fcUpperCase;
                    GestationalAge.MultiLine = EvetHayirEnum.ehEvet;
                    GestationalAge.TextFont.Name = "Microsoft Sans Serif";
                    GestationalAge.TextFont.Size = 9;
                    GestationalAge.TextFont.CharSet = 162;
                    GestationalAge.Value = @"";

                    lblPatientName1111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 67, 176, 72, false);
                    lblPatientName1111111112.Name = "lblPatientName1111111112";
                    lblPatientName1111111112.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1111111112.TextFont.Size = 9;
                    lblPatientName1111111112.TextFont.Italic = true;
                    lblPatientName1111111112.TextFont.CharSet = 162;
                    lblPatientName1111111112.Value = @"(hafta)";

                    lblPatientName1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 73, 47, 78, false);
                    lblPatientName1211111.Name = "lblPatientName1211111";
                    lblPatientName1211111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1211111.TextFont.Size = 9;
                    lblPatientName1211111.TextFont.Bold = true;
                    lblPatientName1211111.TextFont.CharSet = 162;
                    lblPatientName1211111.Value = @"Biparietal Çap";

                    dotsPatientName1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 73, 50, 78, false);
                    dotsPatientName1111111.Name = "dotsPatientName1111111";
                    dotsPatientName1111111.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1111111.TextFont.Size = 9;
                    dotsPatientName1111111.TextFont.Bold = true;
                    dotsPatientName1111111.TextFont.CharSet = 162;
                    dotsPatientName1111111.Value = @":";

                    BiparietalDiameter = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 73, 56, 78, false);
                    BiparietalDiameter.Name = "BiparietalDiameter";
                    BiparietalDiameter.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BiparietalDiameter.MultiLine = EvetHayirEnum.ehEvet;
                    BiparietalDiameter.TextFont.Name = "Microsoft Sans Serif";
                    BiparietalDiameter.TextFont.Size = 9;
                    BiparietalDiameter.TextFont.CharSet = 162;
                    BiparietalDiameter.Value = @"";

                    lblPatientName11121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 73, 67, 78, false);
                    lblPatientName11121121.Name = "lblPatientName11121121";
                    lblPatientName11121121.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11121121.TextFont.Size = 9;
                    lblPatientName11121121.TextFont.CharSet = 162;
                    lblPatientName11121121.Value = @"bpd";

                    lblPatientName111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 87, 47, 92, false);
                    lblPatientName111113.Name = "lblPatientName111113";
                    lblPatientName111113.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName111113.TextFont.Size = 9;
                    lblPatientName111113.TextFont.Bold = true;
                    lblPatientName111113.TextFont.CharSet = 162;
                    lblPatientName111113.Value = @"İstek Tarihi";

                    dotsPatientName111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 87, 50, 92, false);
                    dotsPatientName111112.Name = "dotsPatientName111112";
                    dotsPatientName111112.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName111112.TextFont.Size = 9;
                    dotsPatientName111112.TextFont.Bold = true;
                    dotsPatientName111112.TextFont.CharSet = 162;
                    dotsPatientName111112.Value = @":";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 87, 107, 92, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDate.CaseFormat = CaseFormatEnum.fcUpperCase;
                    RequestDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    RequestDate.MultiLine = EvetHayirEnum.ehEvet;
                    RequestDate.TextFont.Name = "Microsoft Sans Serif";
                    RequestDate.TextFont.Size = 9;
                    RequestDate.TextFont.CharSet = 162;
                    RequestDate.Value = @"{#REQUESTDATE#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 80, 202, 85, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Italic = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                    lblPatientName1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 93, 182, 98, false);
                    lblPatientName1311111.Name = "lblPatientName1311111";
                    lblPatientName1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblPatientName1311111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblPatientName1311111.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1311111.TextFont.Size = 9;
                    lblPatientName1311111.TextFont.Bold = true;
                    lblPatientName1311111.TextFont.CharSet = 162;
                    lblPatientName1311111.Value = @"İSTEĞİ YAPAN DOKTOR";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 100, 182, 121, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RequestDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    RequestDoctor.NoClip = EvetHayirEnum.ehEvet;
                    RequestDoctor.WordBreak = EvetHayirEnum.ehEvet;
                    RequestDoctor.ObjectDefName = "LaboratoryRequest";
                    RequestDoctor.DataMember = "APPROVEDBY.NAME";
                    RequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    RequestDoctor.TextFont.Size = 9;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class dataset_LaboratoryTripleTestInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class>(0);
                    lblPatientName111111.CalcValue = lblPatientName111111.Value;
                    lblPatientName11.CalcValue = lblPatientName11.Value;
                    dotsPatientName11.CalcValue = dotsPatientName11.Value;
                    lblPatientName12.CalcValue = lblPatientName12.Value;
                    dotsPatientName12.CalcValue = dotsPatientName12.Value;
                    PatientName.CalcValue = (dataset_LaboratoryTripleTestInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryTripleTestInfoNQL.Patientname) : "");
                    PatientSurName.CalcValue = (dataset_LaboratoryTripleTestInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryTripleTestInfoNQL.Surname) : "");
                    lblPatientName111.CalcValue = lblPatientName111.Value;
                    dotsPatientName111.CalcValue = dotsPatientName111.Value;
                    PatientBirthDate.CalcValue = (dataset_LaboratoryTripleTestInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryTripleTestInfoNQL.BirthDate) : "");
                    lblPatientPhone121.CalcValue = lblPatientPhone121.Value;
                    dotsPatientName121.CalcValue = dotsPatientName121.Value;
                    PatientPhoneNumber.CalcValue = PatientPhoneNumber.Value;
                    lblPatientName112.CalcValue = lblPatientName112.Value;
                    dotsPatientName112.CalcValue = dotsPatientName112.Value;
                    dotsPatientName1121111.CalcValue = dotsPatientName1121111.Value;
                    PatientWeight.CalcValue = PatientWeight.Value;
                    lblPatientName111111111.CalcValue = lblPatientName111111111.Value;
                    lblPatientName1211.CalcValue = lblPatientName1211.Value;
                    lblPatientName11121.CalcValue = lblPatientName11121.Value;
                    dotsPatientName11111211.CalcValue = dotsPatientName11111211.Value;
                    IsHaveDiabetes.CalcValue = IsHaveDiabetes.Value;
                    lblPatientName112111.CalcValue = lblPatientName112111.Value;
                    dotsPatientName111211111.CalcValue = dotsPatientName111211111.Value;
                    Smoking.CalcValue = Smoking.Value;
                    lblPatientName112112.CalcValue = lblPatientName112112.Value;
                    SmokingNumberPerADay.CalcValue = SmokingNumberPerADay.Value;
                    lblPatientName1211211.CalcValue = lblPatientName1211211.Value;
                    lblPatientName11111.CalcValue = lblPatientName11111.Value;
                    dotsPatientName11111.CalcValue = dotsPatientName11111.Value;
                    LastMenstrualDate.CalcValue = LastMenstrualDate.Value;
                    dotsPatientName11111212.CalcValue = dotsPatientName11111212.Value;
                    CycleLength.CalcValue = CycleLength.Value;
                    lblPatientName1111111111.CalcValue = lblPatientName1111111111.Value;
                    lblPatientName11122.CalcValue = lblPatientName11122.Value;
                    NewField11.CalcValue = NewField11.Value;
                    lblPatientName1111111.CalcValue = lblPatientName1111111.Value;
                    lblPatientName111112.CalcValue = lblPatientName111112.Value;
                    dotsPatientName111111.CalcValue = dotsPatientName111111.Value;
                    UltrasoundDate.CalcValue = UltrasoundDate.Value;
                    lblPatientName122111.CalcValue = lblPatientName122111.Value;
                    dotsPatientName121211111.CalcValue = dotsPatientName121211111.Value;
                    GestationalAge.CalcValue = GestationalAge.Value;
                    lblPatientName1111111112.CalcValue = lblPatientName1111111112.Value;
                    lblPatientName1211111.CalcValue = lblPatientName1211111.Value;
                    dotsPatientName1111111.CalcValue = dotsPatientName1111111.Value;
                    BiparietalDiameter.CalcValue = BiparietalDiameter.Value;
                    lblPatientName11121121.CalcValue = lblPatientName11121121.Value;
                    lblPatientName111113.CalcValue = lblPatientName111113.Value;
                    dotsPatientName111112.CalcValue = dotsPatientName111112.Value;
                    RequestDate.CalcValue = (dataset_LaboratoryTripleTestInfoNQL != null ? Globals.ToStringCore(dataset_LaboratoryTripleTestInfoNQL.RequestDate) : "");
                    NewField111.CalcValue = NewField111.Value;
                    lblPatientName1311111.CalcValue = lblPatientName1311111.Value;
                    RequestDoctor.CalcValue = RequestDoctor.Value;
                    return new TTReportObject[] { lblPatientName111111,lblPatientName11,dotsPatientName11,lblPatientName12,dotsPatientName12,PatientName,PatientSurName,lblPatientName111,dotsPatientName111,PatientBirthDate,lblPatientPhone121,dotsPatientName121,PatientPhoneNumber,lblPatientName112,dotsPatientName112,dotsPatientName1121111,PatientWeight,lblPatientName111111111,lblPatientName1211,lblPatientName11121,dotsPatientName11111211,IsHaveDiabetes,lblPatientName112111,dotsPatientName111211111,Smoking,lblPatientName112112,SmokingNumberPerADay,lblPatientName1211211,lblPatientName11111,dotsPatientName11111,LastMenstrualDate,dotsPatientName11111212,CycleLength,lblPatientName1111111111,lblPatientName11122,NewField11,lblPatientName1111111,lblPatientName111112,dotsPatientName111111,UltrasoundDate,lblPatientName122111,dotsPatientName121211111,GestationalAge,lblPatientName1111111112,lblPatientName1211111,dotsPatientName1111111,BiparietalDiameter,lblPatientName11121121,lblPatientName111113,dotsPatientName111112,RequestDate,NewField111,lblPatientName1311111,RequestDoctor};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                    TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((LaboratoryTripleTestInfoReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
//            
//            if(labRequest.LaboratoryTripleTestInfo != null)
//            {
//                this.PatientPhoneNumber.CalcValue = labRequest.LaboratoryTripleTestInfo.PatientPhoneNumber;
//                this.PatientBirthPlace.CalcValue = labRequest.Episode.Patient.TownOfBirth.Name +" / "+ labRequest.Episode.Patient.CityOfBirth.Name;
//                this.PatientWeight.CalcValue = labRequest.LaboratoryTripleTestInfo.PatientWeight.ToString();
//                
//                if((bool)labRequest.LaboratoryTripleTestInfo.IsHaveDiabetes)
//                {
//                    this.IsHaveDiabetes.CalcValue = "Evet";
//                }
//                else
//                {
//                    this.IsHaveDiabetes.CalcValue = "Hayır";
//                }
//                
//                if((bool)labRequest.LaboratoryTripleTestInfo.Smoking)
//                {
//                    this.Smoking.CalcValue = "Evet";
//                    this.SmokingNumberPerADay.CalcValue = labRequest.LaboratoryTripleTestInfo.SmokingNumberPerADay.ToString();
//                }
//                else
//                {
//                    this.Smoking.CalcValue = "Hayır";
//                }
//                
//                this.LastMenstrualDate.CalcValue = labRequest.LaboratoryTripleTestInfo.LastMenstrualDate.ToString();
//                this.CycleLength.CalcValue = labRequest.LaboratoryTripleTestInfo.CycleLength.ToString();
//                this.UltrasoundDate.CalcValue = labRequest.LaboratoryTripleTestInfo.UltrasoundDate.ToString();
//                this.GestationalAge.CalcValue = labRequest.LaboratoryTripleTestInfo.GestationalAge.ToString();
//                this.BiparietalDiameter.CalcValue = labRequest.LaboratoryTripleTestInfo.BiparietalDiameter.ToString();
//                
//                ResUser requestedBy = labRequest.RequestDoctor;
//                
//                string CrLf = "\r\n";
//                string SB = "";
//                string TextContext = "";
//                
//                //requestedBy
//                if(requestedBy != null)
//                {
//                    SB = requestedBy.SignatureBlock;
//                    TextContext = SB + CrLf ;
//                    this.RequestDoctor.CalcValue = TextContext;
//                }
//            }
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

        public LaboratoryTripleTestInfoReport()
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
            Name = "LABORATORYTRIPLETESTINFOREPORT";
            Caption = "Laboratuvar Triple Test Bilgi Formu";
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