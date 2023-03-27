
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
    /// Kalibrasyon Sertifikası
    /// </summary>
    public partial class KalibrasyonSertifikasi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public KalibrasyonSertifikasi MyParentReport
            {
                get { return (KalibrasyonSertifikasi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField SECTION { get {return Body().SECTION;} }
            public TTReportField WORHSHOP { get {return Body().WORHSHOP;} }
            public TTReportField SECTION2 { get {return Body().SECTION2;} }
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
                list[0] = new TTReportNqlData<Calibration.CalibrationCertificateNQL_Class>("CalibrationCertificateNQL", Calibration.CalibrationCertificateNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KalibrasyonSertifikasi MyParentReport
                {
                    get { return (KalibrasyonSertifikasi)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField SECTION;
                public TTReportField WORHSHOP;
                public TTReportField SECTION2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 50;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 6, 197, 20, false);
                    NewField.Name = "NewField";
                    NewField.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.MultiLine = EvetHayirEnum.ehEvet;
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """");";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 34, 197, 42, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Size = 14;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"KALİBRASYON SERTİFİKASI";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 42, 197, 48, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Italic = true;
                    NewField3.Value = @"CERTIFICATE OF CALIBRATION";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 20, 197, 28, false);
                    SECTION.Name = "SECTION";
                    SECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECTION.TextFont.Size = 12;
                    SECTION.TextFont.Bold = true;
                    SECTION.Value = @"";

                    WORHSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 28, 197, 34, false);
                    WORHSHOP.Name = "WORHSHOP";
                    WORHSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORHSHOP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORHSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORHSHOP.TextFont.Size = 12;
                    WORHSHOP.TextFont.Bold = true;
                    WORHSHOP.Value = @"{#WORKSHOPNAME#}";

                    SECTION2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 23, 239, 28, false);
                    SECTION2.Name = "SECTION2";
                    SECTION2.Visible = EvetHayirEnum.ehHayir;
                    SECTION2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION2.TextFont.Name = "Arial Narrow";
                    SECTION2.TextFont.Size = 10;
                    SECTION2.TextFont.CharSet = 1;
                    SECTION2.Value = @"{#SECTIONNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.CalibrationCertificateNQL_Class dataset_CalibrationCertificateNQL = ParentGroup.rsGroup.GetCurrentRecord<Calibration.CalibrationCertificateNQL_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    SECTION.CalcValue = @"";
                    WORHSHOP.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Workshopname) : "");
                    SECTION2.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Sectionname) : "");
                    NewField.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");;
                    return new TTReportObject[] { NewField2,NewField3,SECTION,WORHSHOP,SECTION2,NewField};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                SECTION.CalcValue = "BİYOMEDİKAL MÜHENDİSLİK MERKEZİ";
            else
                SECTION.CalcValue = SECTION2.CalcValue;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class Page1Group : TTReportGroup
        {
            public KalibrasyonSertifikasi MyParentReport
            {
                get { return (KalibrasyonSertifikasi)ParentReport; }
            }

            new public Page1GroupBody Body()
            {
                return (Page1GroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField62 { get {return Body().NewField62;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField SERIALNUMBER { get {return Body().SERIALNUMBER;} }
            public TTReportField FIXEDASSETNO { get {return Body().FIXEDASSETNO;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField SENDERSECTION { get {return Body().SENDERSECTION;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField NEXTCALIBRATIONDATE { get {return Body().NEXTCALIBRATIONDATE;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField CERTIFICATEPAGENUMBER { get {return Body().CERTIFICATEPAGENUMBER;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportRTF NewRTF1 { get {return Body().NewRTF1;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField LABAMIRI { get {return Body().LABAMIRI;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public Page1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Page1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Calibration.CalibrationCertificateNQL_Class>("CalibrationCertificateNQL", Calibration.CalibrationCertificateNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Page1GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Page1GroupBody : TTReportSection
            {
                public KalibrasyonSertifikasi MyParentReport
                {
                    get { return (KalibrasyonSertifikasi)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportShape NewLine;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportShape NewLine2;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField1;
                public TTReportField NewField26;
                public TTReportField NewField62;
                public TTReportField NAME;
                public TTReportField MARK;
                public TTReportField SERIALNUMBER;
                public TTReportField FIXEDASSETNO;
                public TTReportField ENDDATE;
                public TTReportField SENDERSECTION;
                public TTReportField TTOBJECTID;
                public TTReportField MODEL;
                public TTReportField NEXTCALIBRATIONDATE;
                public TTReportField NewField19;
                public TTReportField CERTIFICATEPAGENUMBER;
                public TTReportShape NewLine1;
                public TTReportRTF NewRTF1;
                public TTReportField NewField20;
                public TTReportField LABAMIRI;
                public TTReportField TARIH;
                public TTReportField NewField18; 
                public Page1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 234;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 35, 7, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Sertifika No      :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 2, 199, 7, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Sayfa No:1/3";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 8, 199, 8, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 2;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 70, 16, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"CİHAZ ADI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 21, 70, 26, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"ÜRETİCİ FİRMA";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 70, 36, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"MODEL/TİP NO";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 41, 70, 46, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"SERİ NO";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 51, 70, 56, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"CİHAZ KODU";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 61, 70, 66, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"TALEP EDEN";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 72, 70, 77, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"KALİBRASYON TARİHİ";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 83, 70, 88, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"GELECEK KALİBRASYON TARİHİ";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 217, 200, 217, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 11, 72, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 21, 72, 26, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 31, 72, 36, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 41, 72, 46, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 51, 72, 56, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 61, 72, 66, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 72, 72, 77, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @":";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 83, 72, 88, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 218, 40, 223, false);
                    NewField26.Name = "NewField26";
                    NewField26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"Tarih";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 218, 179, 223, false);
                    NewField62.Name = "NewField62";
                    NewField62.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField62.TextFont.Bold = true;
                    NewField62.Value = @"Laboratuvar Amiri";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 11, 199, 16, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 21, 199, 26, false);
                    MARK.Name = "MARK";
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.Value = @"{#MARK#}";

                    SERIALNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 41, 199, 46, false);
                    SERIALNUMBER.Name = "SERIALNUMBER";
                    SERIALNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER.Value = @"{#SERIALNUMBER#}";

                    FIXEDASSETNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 51, 199, 56, false);
                    FIXEDASSETNO.Name = "FIXEDASSETNO";
                    FIXEDASSETNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIXEDASSETNO.Value = @"{#FIXEDASSETNO#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 72, 199, 77, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{#ENDDATE#}";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 61, 199, 66, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.Value = @"{#SENDERSECTION#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 4, 239, 9, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 31, 199, 36, false);
                    MODEL.Name = "MODEL";
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.Value = @"{#MODEL#}";

                    NEXTCALIBRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 84, 199, 89, false);
                    NEXTCALIBRATIONDATE.Name = "NEXTCALIBRATIONDATE";
                    NEXTCALIBRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEXTCALIBRATIONDATE.TextFormat = @"dd/MM/yyyy";
                    NEXTCALIBRATIONDATE.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 93, 70, 98, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"SERTİFİKANIN SAYFA SAYISI";

                    CERTIFICATEPAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 93, 199, 98, false);
                    CERTIFICATEPAGENUMBER.Name = "CERTIFICATEPAGENUMBER";
                    CERTIFICATEPAGENUMBER.TextFormat = @"Short Date";
                    CERTIFICATEPAGENUMBER.Value = @"3";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 101, 199, 101, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewRTF1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 7, 103, 199, 182, false);
                    NewRTF1.Name = "NewRTF1";
                    NewRTF1.Value = @"{\rtf1\fbidis\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fswiss\fprq2\fcharset162{\*\fname Arial;}Arial TUR;}}
\viewkind4\uc1\pard\ltrpar\fi360\sa200\b\f0\fs16 A\'e7\'fdklamalar\par
\pard\ltrpar\fi-360\li720\sa200\b0 1.\tab Kalibrasyon Sonu\'e7lar\'fd sadece etki \'f6l\'e7\'fcm raporunda belirtilen seri nolu cihazlara ait olup, kalibrasyon tarihinden itibaren ve sertifikada belirtilmi\'fe olan \'feartlar alt\'fdnda ge\'e7erlidir.\par
2.\tab Birden fazla t\'fdbbi cihaz\'fdn bir araya getirilmesiyle olu\'feturulan t\'fdbbi cihaz sistemlerinin sistemi olu\'feturan her bir par\'e7as\'fdn\'fdn (cihaz\'fdn) farkl\'fd kalibrasyon ge\'e7erlilik s\'fcrelerine sahip olabilece\'f0i hususuna kullan\'fdc\'fd taraf\'fdndan dikkat edilmelidir.\par
3.\tab\'d6l\'e7\'fcm sonu\'e7lar\'fd ve kalibrasyon metotlar\'fd bu sertifikan\'fdn tamamlay\'fdc\'fd k\'fdsm\'fd olan takip eden sayfalarda verilmi\'fetir.\par
4.\tab Bu sertifika, laboratuvar\'fdn yaz\'fdl\'fd izni olmadan k\'fdsmen veya tamamen kopyalan\'fdp \'e7o\'f0alt\'fdlamaz. \'ddmzas\'fdz sertifikalar ge\'e7ersizdir.\par
5.\tab Kalibrasyon sertifikas\'fd kullan\'fdc\'fd taraf\'fdndan teslim al\'fdnd\'fd\'f0\'fdnda incelenmeli ve kullan\'fdc\'fd \'f6l\'e7\'fcm sonu\'e7lar\'fd hakk\'fdnda \'fe\'fcpheye d\'fc\'fet\'fc\'f0\'fcnde ilgili kalibrasyon laboratuvar\'fd ile temasa ge\'e7melidir.\par
6.\tab Yerinde kalibrasyon yap\'fdl\'fdyor ise \ldblquote LABORATUVAR AM\'ddR\'dd\rdblquote  imza k\'fdsm\'fdna yerinde kalibrasyon ibaresi eklenecektir.\par
\pard\ltrpar\li360\sa200 *.\tab Gelecek kalibrasyon tarihi kalibrasyon periyodu i\'e7inde cihaz onar\'fdma tabi tutulmad\'fd\'f0\'fd takdirde ge\'e7ersizdir.  Cihaz onar\'fdma tabi tutuldu\'f0unda kalibrasyonu yeniden yap\'fdlmal\'fdd\'fdr.\par
**.\tab Kalibrasyon i\'feleminde kullan\'fdlan prosed\'fcrlerin tamam\'fdn\'fdn sadece prosed\'fcr numaralar\'fd yaz\'fdlacakt\'fdr.\par
\pard\ltrpar\b\par
}
";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 93, 72, 98, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Size = 10;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @":";

                    LABAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 223, 201, 238, false);
                    LABAMIRI.Name = "LABAMIRI";
                    LABAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LABAMIRI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    LABAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    LABAMIRI.TextFont.Name = "Arial Narrow";
                    LABAMIRI.TextFont.Size = 10;
                    LABAMIRI.TextFont.CharSet = 1;
                    LABAMIRI.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 223, 54, 232, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 10;
                    TARIH.TextFont.CharSet = 1;
                    TARIH.Value = @"{@printdate@}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 10, 239, 15, false);
                    NewField18.Name = "NewField18";
                    NewField18.Visible = EvetHayirEnum.ehHayir;
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 10;
                    NewField18.TextFont.CharSet = 1;
                    NewField18.Value = @"NewField18";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.CalibrationCertificateNQL_Class dataset_CalibrationCertificateNQL = ParentGroup.rsGroup.GetCurrentRecord<Calibration.CalibrationCertificateNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField62.CalcValue = NewField62.Value;
                    NAME.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Name) : "");
                    MARK.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Mark) : "");
                    SERIALNUMBER.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.SerialNumber) : "");
                    FIXEDASSETNO.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.FixedAssetNO) : "");
                    ENDDATE.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.EndDate) : "");
                    SENDERSECTION.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Sendersection) : "");
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    MODEL.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Model) : "");
                    NEXTCALIBRATIONDATE.CalcValue = @"";
                    NewField19.CalcValue = NewField19.Value;
                    CERTIFICATEPAGENUMBER.CalcValue = CERTIFICATEPAGENUMBER.Value;
                    NewRTF1.CalcValue = NewRTF1.Value;
                    NewField20.CalcValue = NewField20.Value;
                    LABAMIRI.CalcValue = @"";
                    TARIH.CalcValue = DateTime.Now.ToShortDateString();
                    NewField18.CalcValue = NewField18.Value;
                    return new TTReportObject[] { NewField,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,NewField17,NewField1,NewField26,NewField62,NAME,MARK,SERIALNUMBER,FIXEDASSETNO,ENDDATE,SENDERSECTION,TTOBJECTID,MODEL,NEXTCALIBRATIONDATE,NewField19,CERTIFICATEPAGENUMBER,NewRTF1,NewField20,LABAMIRI,TARIH,NewField18};
                }

                public override void RunScript()
                {
#region PAGE1 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((KalibrasyonSertifikasi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Calibration ms = (Calibration)ctx.GetObject(new Guid(objectID), typeof(Calibration));
            ResUser user;
            ResUser tuser;
            bool tecnicalMember = false;
            string bamir = string.Empty;
            string tuserstring = string.Empty;
            string userstring = string.Empty;
            
            //DateTime lastcalibrationdate = Convert.ToDateTime(ms.FixedAssetMaterialDefinition.LastCalibrationDate);
            DateTime lastcalibrationdate = Convert.ToDateTime(ms.EndDate);
            int calibrationperiod = Convert.ToInt16(ms.FixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod);
            
           if(calibrationperiod > 0)  
               NEXTCALIBRATIONDATE.CalcValue = Convert.ToString( lastcalibrationdate.AddMonths(calibrationperiod));
                     
           if(ms.LabResponsible != null)
            {
                user = ms.LabResponsible;
                userstring  += user.Name + "\r\n";
                if (user.MilitaryClass != null)
                    userstring += user.MilitaryClass.ShortName;
                if (user.Rank != null)
                    userstring += user.Rank.ShortName + "\r\n";
                userstring += "(" + user.EmploymentRecordID + ")";
                LABAMIRI.CalcValue = userstring;
            }
#endregion PAGE1 BODY_Script
                }
            }

        }

        public Page1Group Page1;

        public partial class Page2part1Group : TTReportGroup
        {
            public KalibrasyonSertifikasi MyParentReport
            {
                get { return (KalibrasyonSertifikasi)ParentReport; }
            }

            new public Page2part1GroupHeader Header()
            {
                return (Page2part1GroupHeader)_header;
            }

            new public Page2part1GroupFooter Footer()
            {
                return (Page2part1GroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField118 { get {return Header().NewField118;} }
            public TTReportField NewField128 { get {return Header().NewField128;} }
            public TTReportField NewField138 { get {return Header().NewField138;} }
            public TTReportField NewField148 { get {return Header().NewField148;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportField NewField101 { get {return Footer().NewField101;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField142 { get {return Footer().NewField142;} }
            public TTReportField NewField152 { get {return Footer().NewField152;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField162 { get {return Footer().NewField162;} }
            public TTReportField NewField123 { get {return Footer().NewField123;} }
            public TTReportField NewField124 { get {return Footer().NewField124;} }
            public TTReportField NewField172 { get {return Footer().NewField172;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField182 { get {return Footer().NewField182;} }
            public TTReportField NewField133 { get {return Footer().NewField133;} }
            public TTReportField NewField134 { get {return Footer().NewField134;} }
            public TTReportField NewField192 { get {return Footer().NewField192;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField103 { get {return Footer().NewField103;} }
            public TTReportField NewField143 { get {return Footer().NewField143;} }
            public TTReportField NewField144 { get {return Footer().NewField144;} }
            public TTReportField NewField113 { get {return Footer().NewField113;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
            public TTReportField NewField153 { get {return Footer().NewField153;} }
            public TTReportField NewField163 { get {return Footer().NewField163;} }
            public TTReportField NewField154 { get {return Footer().NewField154;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField NewField109 { get {return Footer().NewField109;} }
            public TTReportField NewField187 { get {return Footer().NewField187;} }
            public TTReportField NewField135 { get {return Footer().NewField135;} }
            public TTReportField NewField129 { get {return Footer().NewField129;} }
            public TTReportField NewField145 { get {return Footer().NewField145;} }
            public TTReportField NewField155 { get {return Footer().NewField155;} }
            public TTReportField NewField195 { get {return Footer().NewField195;} }
            public TTReportField NewField165 { get {return Footer().NewField165;} }
            public TTReportField NewField106 { get {return Footer().NewField106;} }
            public TTReportField NewField116 { get {return Footer().NewField116;} }
            public TTReportField NewField126 { get {return Footer().NewField126;} }
            public TTReportField NewField136 { get {return Footer().NewField136;} }
            public TTReportField NewField146 { get {return Footer().NewField146;} }
            public TTReportField NewField156 { get {return Footer().NewField156;} }
            public TTReportField NewField159 { get {return Footer().NewField159;} }
            public TTReportField NewField1601 { get {return Footer().NewField1601;} }
            public TTReportField NewField1701 { get {return Footer().NewField1701;} }
            public TTReportField NewField11061 { get {return Footer().NewField11061;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public Page2part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Page2part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Calibration.CalibrationCertificateNQL_Class>("CalibrationCertificateNQL", Calibration.CalibrationCertificateNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Page2part1GroupHeader(this);
                _footer = new Page2part1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Page2part1GroupHeader : TTReportSection
            {
                public KalibrasyonSertifikasi MyParentReport
                {
                    get { return (KalibrasyonSertifikasi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportShape NewLine1;
                public TTReportField NewField11;
                public TTReportField NewField181;
                public TTReportField NewField118;
                public TTReportField NewField128;
                public TTReportField NewField138;
                public TTReportField NewField148;
                public TTReportField NewField1181; 
                public Page2part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 35, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Sertifika No      :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 2, 199, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Sayfa No:2/3";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 8, 199, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 199, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"1.      KALİBRASYONDA KULLANILAN REFERANSLAR:";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 59, 25, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"Cihaz Adı";

                    NewField118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 20, 92, 25, false);
                    NewField118.Name = "NewField118";
                    NewField118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField118.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField118.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField118.TextFont.Bold = true;
                    NewField118.Value = @"Model/Tip";

                    NewField128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 20, 127, 25, false);
                    NewField128.Name = "NewField128";
                    NewField128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField128.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField128.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField128.TextFont.Bold = true;
                    NewField128.Value = @"Seri No";

                    NewField138 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 20, 169, 25, false);
                    NewField138.Name = "NewField138";
                    NewField138.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField138.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField138.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField138.TextFont.Bold = true;
                    NewField138.Value = @"Üretici Firma";

                    NewField148 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 20, 199, 25, false);
                    NewField148.Name = "NewField148";
                    NewField148.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField148.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField148.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField148.TextFont.Bold = true;
                    NewField148.Value = @"İzlenebilirlik";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 20, 25, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @"Sıra Nu.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.CalibrationCertificateNQL_Class dataset_CalibrationCertificateNQL = ParentGroup.rsGroup.GetCurrentRecord<Calibration.CalibrationCertificateNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField118.CalcValue = NewField118.Value;
                    NewField128.CalcValue = NewField128.Value;
                    NewField138.CalcValue = NewField138.Value;
                    NewField148.CalcValue = NewField148.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    return new TTReportObject[] { NewField1,NewField12,NewField11,NewField181,NewField118,NewField128,NewField138,NewField148,NewField1181};
                }
            }
            public partial class Page2part1GroupFooter : TTReportSection
            {
                public KalibrasyonSertifikasi MyParentReport
                {
                    get { return (KalibrasyonSertifikasi)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField101;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField NewField131;
                public TTReportField NewField162;
                public TTReportField NewField123;
                public TTReportField NewField124;
                public TTReportField NewField172;
                public TTReportField NewField141;
                public TTReportField NewField182;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportField NewField192;
                public TTReportField NewField151;
                public TTReportField NewField103;
                public TTReportField NewField143;
                public TTReportField NewField144;
                public TTReportField NewField113;
                public TTReportField NewField161;
                public TTReportField NewField153;
                public TTReportField NewField163;
                public TTReportField NewField154;
                public TTReportField NewField171;
                public TTReportField NewField109;
                public TTReportField NewField187;
                public TTReportField NewField135;
                public TTReportField NewField129;
                public TTReportField NewField145;
                public TTReportField NewField155;
                public TTReportField NewField195;
                public TTReportField NewField165;
                public TTReportField NewField106;
                public TTReportField NewField116;
                public TTReportField NewField126;
                public TTReportField NewField136;
                public TTReportField NewField146;
                public TTReportField NewField156;
                public TTReportField NewField159;
                public TTReportField NewField1601;
                public TTReportField NewField1701;
                public TTReportField NewField11061;
                public TTReportShape NewLine111; 
                public Page2part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 108;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 198, 14, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"2.      KALİBRE EDİLEN CİHAZ:";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 26, 199, 31, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFormat = @"99,99";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"3.      ORTAM ŞARTLARI:";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 52, 199, 57, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"4.      KALİBRASYON YÖNTEMİ VE PROSEDÜRÜ:";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 74, 199, 79, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"5.      KALİBRASYON SONUÇLARI";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 41, 221, 51, false);
                    NewField17.Name = "NewField17";
                    NewField17.Visible = EvetHayirEnum.ehHayir;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Size = 8;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.Underline = true;
                    NewField17.Value = @"S.NO";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 41, 276, 51, false);
                    NewField18.Name = "NewField18";
                    NewField18.Visible = EvetHayirEnum.ehHayir;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.WordBreak = EvetHayirEnum.ehEvet;
                    NewField18.TextFont.Size = 8;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.Underline = true;
                    NewField18.Value = @"YAPILAN İŞLEMİN ADI";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 41, 319, 51, false);
                    NewField19.Name = "NewField19";
                    NewField19.Visible = EvetHayirEnum.ehHayir;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Size = 8;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.Underline = true;
                    NewField19.Value = @"KADEME/ ÖLÇÜM ARALIĞI";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 41, 359, 51, false);
                    NewField101.Name = "NewField101";
                    NewField101.Visible = EvetHayirEnum.ehHayir;
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField101.WordBreak = EvetHayirEnum.ehEvet;
                    NewField101.TextFont.Size = 8;
                    NewField101.TextFont.Bold = true;
                    NewField101.TextFont.Underline = true;
                    NewField101.Value = @"UYGULANAN (REFERANS) DEĞER";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 41, 403, 51, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.Value = @"ÖLÇÜLEN DEĞER";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 52, 221, 57, false);
                    NewField121.Name = "NewField121";
                    NewField121.Visible = EvetHayirEnum.ehHayir;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.Value = @"1";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 52, 276, 57, false);
                    NewField112.Name = "NewField112";
                    NewField112.Visible = EvetHayirEnum.ehHayir;
                    NewField112.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 52, 319, 57, false);
                    NewField122.Name = "NewField122";
                    NewField122.Visible = EvetHayirEnum.ehHayir;
                    NewField122.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 52, 359, 57, false);
                    NewField132.Name = "NewField132";
                    NewField132.Visible = EvetHayirEnum.ehHayir;
                    NewField132.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 52, 403, 57, false);
                    NewField142.Name = "NewField142";
                    NewField142.Visible = EvetHayirEnum.ehHayir;
                    NewField142.Value = @"";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 58, 221, 63, false);
                    NewField152.Name = "NewField152";
                    NewField152.Visible = EvetHayirEnum.ehHayir;
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.Value = @"2";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 58, 276, 63, false);
                    NewField131.Name = "NewField131";
                    NewField131.Visible = EvetHayirEnum.ehHayir;
                    NewField131.Value = @"";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 58, 319, 63, false);
                    NewField162.Name = "NewField162";
                    NewField162.Visible = EvetHayirEnum.ehHayir;
                    NewField162.Value = @"";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 58, 359, 63, false);
                    NewField123.Name = "NewField123";
                    NewField123.Visible = EvetHayirEnum.ehHayir;
                    NewField123.Value = @"";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 58, 403, 63, false);
                    NewField124.Name = "NewField124";
                    NewField124.Visible = EvetHayirEnum.ehHayir;
                    NewField124.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 64, 221, 69, false);
                    NewField172.Name = "NewField172";
                    NewField172.Visible = EvetHayirEnum.ehHayir;
                    NewField172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField172.Value = @"3";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 64, 276, 69, false);
                    NewField141.Name = "NewField141";
                    NewField141.Visible = EvetHayirEnum.ehHayir;
                    NewField141.Value = @"";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 64, 319, 69, false);
                    NewField182.Name = "NewField182";
                    NewField182.Visible = EvetHayirEnum.ehHayir;
                    NewField182.Value = @"";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 64, 359, 69, false);
                    NewField133.Name = "NewField133";
                    NewField133.Visible = EvetHayirEnum.ehHayir;
                    NewField133.Value = @"";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 64, 403, 69, false);
                    NewField134.Name = "NewField134";
                    NewField134.Visible = EvetHayirEnum.ehHayir;
                    NewField134.Value = @"";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 70, 221, 75, false);
                    NewField192.Name = "NewField192";
                    NewField192.Visible = EvetHayirEnum.ehHayir;
                    NewField192.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField192.Value = @"4";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 70, 276, 75, false);
                    NewField151.Name = "NewField151";
                    NewField151.Visible = EvetHayirEnum.ehHayir;
                    NewField151.Value = @"";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 70, 319, 75, false);
                    NewField103.Name = "NewField103";
                    NewField103.Visible = EvetHayirEnum.ehHayir;
                    NewField103.Value = @"";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 70, 359, 75, false);
                    NewField143.Name = "NewField143";
                    NewField143.Visible = EvetHayirEnum.ehHayir;
                    NewField143.Value = @"";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 70, 403, 75, false);
                    NewField144.Name = "NewField144";
                    NewField144.Visible = EvetHayirEnum.ehHayir;
                    NewField144.Value = @"";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 76, 221, 81, false);
                    NewField113.Name = "NewField113";
                    NewField113.Visible = EvetHayirEnum.ehHayir;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.Value = @"5";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 76, 276, 81, false);
                    NewField161.Name = "NewField161";
                    NewField161.Visible = EvetHayirEnum.ehHayir;
                    NewField161.Value = @"";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 76, 319, 81, false);
                    NewField153.Name = "NewField153";
                    NewField153.Visible = EvetHayirEnum.ehHayir;
                    NewField153.Value = @"";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 76, 359, 81, false);
                    NewField163.Name = "NewField163";
                    NewField163.Visible = EvetHayirEnum.ehHayir;
                    NewField163.Value = @"";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 76, 403, 81, false);
                    NewField154.Name = "NewField154";
                    NewField154.Visible = EvetHayirEnum.ehHayir;
                    NewField154.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 79, 199, 95, false);
                    NewField171.Name = "NewField171";
                    NewField171.Value = @"Ölçüm raporu ektedir.";

                    NewField109 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 199, 22, false);
                    NewField109.Name = "NewField109";
                    NewField109.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField109.Value = @"{#SERIALNUMBER#} + ""-"" + {#NAME#} + ""-"" + {#MARK#}";

                    NewField187 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 35, 42, 40, false);
                    NewField187.Name = "NewField187";
                    NewField187.TextFont.Bold = true;
                    NewField187.Value = @"Sıcaklık";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 41, 42, 46, false);
                    NewField135.Name = "NewField135";
                    NewField135.TextFont.Bold = true;
                    NewField135.Value = @"Bağıl Nem";

                    NewField129 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 35, 45, 40, false);
                    NewField129.Name = "NewField129";
                    NewField129.TextFont.Bold = true;
                    NewField129.Value = @":";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 41, 45, 46, false);
                    NewField145.Name = "NewField145";
                    NewField145.TextFont.Bold = true;
                    NewField145.Value = @":";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 41, 50, 46, false);
                    NewField155.Name = "NewField155";
                    NewField155.TextFont.Bold = true;
                    NewField155.Value = @"%(";

                    NewField195 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 35, 61, 40, false);
                    NewField195.Name = "NewField195";
                    NewField195.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField195.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField195.Value = @"{#TEMPERATURE#}";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 41, 61, 46, false);
                    NewField165.Name = "NewField165";
                    NewField165.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField165.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField165.Value = @"{#RELATIVEHUMIDITY#}";

                    NewField106 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 37, 64, 40, false);
                    NewField106.Name = "NewField106";
                    NewField106.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField106.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField106.TextFont.Bold = true;
                    NewField106.Value = @"-";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 35, 72, 40, false);
                    NewField116.Name = "NewField116";
                    NewField116.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField116.Value = @"{#TEMPERATUREDEVIATION#}";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 41, 72, 46, false);
                    NewField126.Name = "NewField126";
                    NewField126.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField126.Value = @"{#HUMIDITYDEVIATION#}";

                    NewField136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 35, 81, 40, false);
                    NewField136.Name = "NewField136";
                    NewField136.TextFont.Bold = true;
                    NewField136.Value = @")C";

                    NewField146 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 35, 77, 40, false);
                    NewField146.Name = "NewField146";
                    NewField146.TextFont.Bold = true;
                    NewField146.Value = @")";

                    NewField156 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 57, 199, 70, false);
                    NewField156.Name = "NewField156";
                    NewField156.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField156.MultiLine = EvetHayirEnum.ehEvet;
                    NewField156.WordBreak = EvetHayirEnum.ehEvet;
                    NewField156.Value = @"{#TECHNIQUEANDPROCEDURE#}
";

                    NewField159 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 35, 50, 40, false);
                    NewField159.Name = "NewField159";
                    NewField159.TextFont.Bold = true;
                    NewField159.Value = @"   (";

                    NewField1601 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 35, 64, 37, false);
                    NewField1601.Name = "NewField1601";
                    NewField1601.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1601.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1601.TextFont.Bold = true;
                    NewField1601.Value = @"+";

                    NewField1701 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 42, 64, 46, false);
                    NewField1701.Name = "NewField1701";
                    NewField1701.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1701.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1701.TextFont.Bold = true;
                    NewField1701.Value = @"-";

                    NewField11061 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 41, 64, 43, false);
                    NewField11061.Name = "NewField11061";
                    NewField11061.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11061.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11061.TextFont.Bold = true;
                    NewField11061.Value = @"+";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 2, 199, 2, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.CalibrationCertificateNQL_Class dataset_CalibrationCertificateNQL = ParentGroup.rsGroup.GetCurrentRecord<Calibration.CalibrationCertificateNQL_Class>(0);
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField182.CalcValue = NewField182.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField192.CalcValue = NewField192.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField154.CalcValue = NewField154.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField187.CalcValue = NewField187.Value;
                    NewField135.CalcValue = NewField135.Value;
                    NewField129.CalcValue = NewField129.Value;
                    NewField145.CalcValue = NewField145.Value;
                    NewField155.CalcValue = NewField155.Value;
                    NewField195.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Temperature) : "");
                    NewField165.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.RelativeHumidity) : "");
                    NewField106.CalcValue = NewField106.Value;
                    NewField116.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.TemperatureDeviation) : "");
                    NewField126.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.HumidityDeviation) : "");
                    NewField136.CalcValue = NewField136.Value;
                    NewField146.CalcValue = NewField146.Value;
                    NewField156.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.TechniqueAndProcedure) : "") + @"
";
                    NewField159.CalcValue = NewField159.Value;
                    NewField1601.CalcValue = NewField1601.Value;
                    NewField1701.CalcValue = NewField1701.Value;
                    NewField11061.CalcValue = NewField11061.Value;
                    NewField109.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.SerialNumber) : "") + "-" + (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Name) : "") + "-" + (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.Mark) : "");
                    return new TTReportObject[] { NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,NewField19,NewField101,NewField111,NewField121,NewField112,NewField122,NewField132,NewField142,NewField152,NewField131,NewField162,NewField123,NewField124,NewField172,NewField141,NewField182,NewField133,NewField134,NewField192,NewField151,NewField103,NewField143,NewField144,NewField113,NewField161,NewField153,NewField163,NewField154,NewField171,NewField187,NewField135,NewField129,NewField145,NewField155,NewField195,NewField165,NewField106,NewField116,NewField126,NewField136,NewField146,NewField156,NewField159,NewField1601,NewField1701,NewField11061,NewField109};
                }
            }

        }

        public Page2part1Group Page2part1;

        public partial class Page2Group : TTReportGroup
        {
            public KalibrasyonSertifikasi MyParentReport
            {
                get { return (KalibrasyonSertifikasi)ParentReport; }
            }

            new public Page2GroupBody Body()
            {
                return (Page2GroupBody)_body;
            }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField TRACEABILITY { get {return Body().TRACEABILITY;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public Page2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Page2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class>("CalibratorCertificationReportQuery", CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Page2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Page2GroupBody : TTReportSection
            {
                public KalibrasyonSertifikasi MyParentReport
                {
                    get { return (KalibrasyonSertifikasi)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField TRACEABILITY;
                public TTReportField MARK;
                public TTReportField SERIALNO;
                public TTReportField MODEL;
                public TTReportField NewField1; 
                public Page2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 30;
                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 59, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 10;
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{#NAME#}";

                    TRACEABILITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 199, 5, false);
                    TRACEABILITY.Name = "TRACEABILITY";
                    TRACEABILITY.DrawStyle = DrawStyleConstants.vbSolid;
                    TRACEABILITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRACEABILITY.TextFont.Name = "Arial Narrow";
                    TRACEABILITY.TextFont.Size = 10;
                    TRACEABILITY.TextFont.CharSet = 1;
                    TRACEABILITY.Value = @"{#TRACEABILITY#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 169, 5, false);
                    MARK.Name = "MARK";
                    MARK.DrawStyle = DrawStyleConstants.vbSolid;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.TextFont.Name = "Arial Narrow";
                    MARK.TextFont.Size = 10;
                    MARK.TextFont.CharSet = 1;
                    MARK.Value = @"{#MARK#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 0, 127, 5, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.TextFont.Name = "Arial Narrow";
                    SERIALNO.TextFont.Size = 10;
                    SERIALNO.TextFont.CharSet = 1;
                    SERIALNO.Value = @"{#SERIALNO#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 0, 92, 5, false);
                    MODEL.Name = "MODEL";
                    MODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.TextFont.Name = "Arial Narrow";
                    MODEL.TextFont.Size = 10;
                    MODEL.TextFont.CharSet = 1;
                    MODEL.Value = @"{#MODEL#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 20, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class dataset_CalibratorCertificationReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class>(0);
                    NAME.CalcValue = (dataset_CalibratorCertificationReportQuery != null ? Globals.ToStringCore(dataset_CalibratorCertificationReportQuery.Name) : "");
                    TRACEABILITY.CalcValue = (dataset_CalibratorCertificationReportQuery != null ? Globals.ToStringCore(dataset_CalibratorCertificationReportQuery.Traceability) : "");
                    MARK.CalcValue = (dataset_CalibratorCertificationReportQuery != null ? Globals.ToStringCore(dataset_CalibratorCertificationReportQuery.Mark) : "");
                    SERIALNO.CalcValue = (dataset_CalibratorCertificationReportQuery != null ? Globals.ToStringCore(dataset_CalibratorCertificationReportQuery.Serialno) : "");
                    MODEL.CalcValue = (dataset_CalibratorCertificationReportQuery != null ? Globals.ToStringCore(dataset_CalibratorCertificationReportQuery.Model) : "");
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { NAME,TRACEABILITY,MARK,SERIALNO,MODEL,NewField1};
                }

                public override void RunScript()
                {
#region PAGE2 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((KalibrasyonSertifikasi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Calibration calib = (Calibration)ctx.GetObject(new Guid(objectID), typeof(Calibration));
//            int calibcount = 1;
//            foreach (CalibratorFixedAssetMaterial calibrator in  calib.CalibratorFixedAssetMaterials)
//            {
//                if(calibcount == 1)
//                {
//                    CIHAZADI.CalcValue = calibrator.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
//                    IZLENEBILIRLIK.CalcValue = calibrator.Traceability ;
//                    URETICIFIRMA.CalcValue = calibrator.FixedAssetMaterialDefinition.Mark;
//                    SERINO.CalcValue = calibrator.FixedAssetMaterialDefinition.SerialNumber;
//                    MODEL.CalcValue = calibrator.FixedAssetMaterialDefinition.Model;
//                    calibcount++;
//                }
//                
//                if(calibcount == 2)
//                {
//                    CIHAZADII.CalcValue = calibrator.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
//                    IZLENEBILIRLIKK.CalcValue = calibrator.Traceability ;
//                    URETICIFIRMAA.CalcValue = calibrator.FixedAssetMaterialDefinition.Mark;
//                    SERINOO.CalcValue = calibrator.FixedAssetMaterialDefinition.SerialNumber;
//                    MODELL.CalcValue = calibrator.FixedAssetMaterialDefinition.Model;
//                    
//                }
//                
//            }
#endregion PAGE2 BODY_Script
                }
            }

        }

        public Page2Group Page2;

        public partial class Page3Group : TTReportGroup
        {
            public KalibrasyonSertifikasi MyParentReport
            {
                get { return (KalibrasyonSertifikasi)ParentReport; }
            }

            new public Page3GroupBody Body()
            {
                return (Page3GroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField56 { get {return Body().NewField56;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField65 { get {return Body().NewField65;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField66 { get {return Body().NewField66;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField67 { get {return Body().NewField67;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField KALIBREDENN { get {return Body().KALIBREDENN;} }
            public TTReportField LABAMIRI { get {return Body().LABAMIRI;} }
            public Page3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Page3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Calibration.CalibrationCertificateNQL_Class>("CalibrationCertificateNQL", Calibration.CalibrationCertificateNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Page3GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Page3GroupBody : TTReportSection
            {
                public KalibrasyonSertifikasi MyParentReport
                {
                    get { return (KalibrasyonSertifikasi)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportShape NewLine;
                public TTReportField NewField5;
                public TTReportField NewField56;
                public TTReportField NewField6;
                public TTReportField NewField65;
                public TTReportField NewField7;
                public TTReportField NewField66;
                public TTReportField NewField8;
                public TTReportField NewField67;
                public TTReportField NewField9;
                public TTReportField NewField3;
                public TTReportField NewField10;
                public TTReportField KALIBREDENN;
                public TTReportField LABAMIRI; 
                public Page3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 205;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 35, 12, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Sertifika No      :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 6, 199, 11, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Sayfa No:3/3";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 12, 199, 12, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 2;

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 18, 199, 23, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"6.      KALİBRASYON BELİRSİZLİĞİ:";

                    NewField56 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 25, 198, 38, false);
                    NewField56.Name = "NewField56";
                    NewField56.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField56.Value = @"{#CALIBRATIONUNCERTAINTY#}";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 43, 198, 48, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"7.      UYGUNLUK BEYANI:";

                    NewField65 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 50, 198, 63, false);
                    NewField65.Name = "NewField65";
                    NewField65.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField65.Value = @"{#AVAILABLITYANNOUNCE#}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 68, 198, 73, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"8.      AÇIKLAMALAR:";

                    NewField66 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 75, 198, 88, false);
                    NewField66.Name = "NewField66";
                    NewField66.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField66.Value = @"{#CERTIFICATEDESCRIPTION#}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 93, 198, 98, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"9.      KALİBRASYON ETİKETİNİN YERİ:";

                    NewField67 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 100, 198, 113, false);
                    NewField67.Name = "NewField67";
                    NewField67.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField67.Value = @"{#PLACEOFCALIBRATIONLABEL#}";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 117, 198, 122, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"10.      KALİBRASYONU YAPAN VE KONTROL EDEN:";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 126, 54, 131, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Kalibrasyonu Yapan";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 126, 193, 131, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Laboratuar Sorumlusu(Amiri)";

                    KALIBREDENN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 131, 57, 141, false);
                    KALIBREDENN.Name = "KALIBREDENN";
                    KALIBREDENN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALIBREDENN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KALIBREDENN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KALIBREDENN.MultiLine = EvetHayirEnum.ehEvet;
                    KALIBREDENN.WordBreak = EvetHayirEnum.ehEvet;
                    KALIBREDENN.Value = @"";

                    LABAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 131, 197, 146, false);
                    LABAMIRI.Name = "LABAMIRI";
                    LABAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LABAMIRI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    LABAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    LABAMIRI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.CalibrationCertificateNQL_Class dataset_CalibrationCertificateNQL = ParentGroup.rsGroup.GetCurrentRecord<Calibration.CalibrationCertificateNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField56.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.CalibrationUncertainty) : "");
                    NewField6.CalcValue = NewField6.Value;
                    NewField65.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.AvailablityAnnounce) : "");
                    NewField7.CalcValue = NewField7.Value;
                    NewField66.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.CertificateDescription) : "");
                    NewField8.CalcValue = NewField8.Value;
                    NewField67.CalcValue = (dataset_CalibrationCertificateNQL != null ? Globals.ToStringCore(dataset_CalibrationCertificateNQL.PlaceOfCalibrationLabel) : "");
                    NewField9.CalcValue = NewField9.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField10.CalcValue = NewField10.Value;
                    KALIBREDENN.CalcValue = @"";
                    LABAMIRI.CalcValue = @"";
                    return new TTReportObject[] { NewField,NewField2,NewField5,NewField56,NewField6,NewField65,NewField7,NewField66,NewField8,NewField67,NewField9,NewField3,NewField10,KALIBREDENN,LABAMIRI};
                }

                public override void RunScript()
                {
#region PAGE3 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((KalibrasyonSertifikasi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Calibration ms = (Calibration)ctx.GetObject(new Guid(objectID), typeof(Calibration));
                   
            ResUser user;
            ResUser tuser;
            bool tecnicalMember = false;
            string bamir = string.Empty;
            //string techMember1 = string.Empty;
            //string techMember2 = string.Empty;
            //string chefString = string.Empty;
            //string approvalMember = string.Empty;
            string tuserstring = string.Empty;
            string userstring = string.Empty;
            
            if(ms.ResponsibleUser != null)
            {
                tuser = ms.ResponsibleUser;
                tuserstring  += tuser.Name + "\r\n";
                if (tuser.MilitaryClass != null)
                    tuserstring += tuser.MilitaryClass.ShortName;
                if (tuser.Rank != null)
                    tuserstring += tuser.Rank.ShortName + "\r\n";
                tuserstring += "(" + tuser.EmploymentRecordID + ")";
                KALIBREDENN.CalcValue = tuserstring;
            }
            
           if(ms.LabResponsible != null)
            {
                user = ms.LabResponsible;
                userstring  += user.Name + "\r\n";
                if (user.MilitaryClass != null)
                    userstring += user.MilitaryClass.ShortName;
                if (user.Rank != null)
                    userstring += user.Rank.ShortName + "\r\n";
                userstring += "(" + user.EmploymentRecordID + ")";
                LABAMIRI.CalcValue = userstring;
            }
#endregion PAGE3 BODY_Script
                }
            }

        }

        public Page3Group Page3;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KalibrasyonSertifikasi()
        {
            MAIN = new MAINGroup(this,"MAIN");
            Page1 = new Page1Group(this,"Page1");
            Page2part1 = new Page2part1Group(this,"Page2part1");
            Page2 = new Page2Group(Page2part1,"Page2");
            Page3 = new Page3Group(this,"Page3");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İstek No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("19a3dbff-9aab-4617-bca1-91262a84d2c4");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KALIBRASYONSERTIFIKASI";
            Caption = "Kalibrasyon Sertifikası";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 10;
            UserMarginLeft = 5;
            UserMarginTop = 10;
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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