
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
    /// Yatış İstek Formu
    /// </summary>
    public partial class InpatientAdmissionRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientAdmissionRequestReport MyParentReport
            {
                get { return (InpatientAdmissionRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HEADER1 { get {return Body().HEADER1;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField BİRİMPRTNO { get {return Body().BİRİMPRTNO;} }
            public TTReportField KARANTİNARAPNO { get {return Body().KARANTİNARAPNO;} }
            public TTReportField sag { get {return Body().sag;} }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField KONU { get {return Body().KONU;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NUM { get {return Body().NUM;} }
            public TTReportField BIRIMADI { get {return Body().BIRIMADI;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField QUARANTINEPROTOCOLNO { get {return Body().QUARANTINEPROTOCOLNO;} }
            public TTReportField ACTIONDATE2 { get {return Body().ACTIONDATE2;} }
            public TTReportField date { get {return Body().date;} }
            public TTReportField YATIRILDIGISERV { get {return Body().YATIRILDIGISERV;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField BIRTHINFO { get {return Body().BIRTHINFO;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField142 { get {return Body().NewField142;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField192 { get {return Body().NewField192;} }
            public TTReportField NewField103 { get {return Body().NewField103;} }
            public TTReportField NewField183 { get {return Body().NewField183;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField SINRUT { get {return Body().SINRUT;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField NewField1291 { get {return Body().NewField1291;} }
            public TTReportField NewField11711 { get {return Body().NewField11711;} }
            public TTReportField ISTEKDR { get {return Body().ISTEKDR;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1251 { get {return Body().NewField1251;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
            public TTReportField FOREIGNUNIQUEREFNO { get {return Body().FOREIGNUNIQUEREFNO;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField FOREIGN { get {return Body().FOREIGN;} }
            public TTReportField NewField1351 { get {return Body().NewField1351;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField NewField111711 { get {return Body().NewField111711;} }
            public TTReportField WARVETERA { get {return Body().WARVETERA;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>("GetInpatientAdmissionDeclaration", InpatientAdmission.GetInpatientAdmissionDeclaration((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InpatientAdmissionRequestReport MyParentReport
                {
                    get { return (InpatientAdmissionRequestReport)ParentReport; }
                }
                
                public TTReportField HEADER1;
                public TTReportField ACTIONDATE;
                public TTReportField BİRİMPRTNO;
                public TTReportField KARANTİNARAPNO;
                public TTReportField sag;
                public TTReportField HEADER;
                public TTReportField NOT;
                public TTReportField KONU;
                public TTReportField ACTIONID;
                public TTReportShape NewLine2;
                public TTReportField NUM;
                public TTReportField BIRIMADI;
                public TTReportField HASTANO;
                public TTReportField KURUM;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField QUARANTINEPROTOCOLNO;
                public TTReportField ACTIONDATE2;
                public TTReportField date;
                public TTReportField YATIRILDIGISERV;
                public TTReportField ADSOYAD;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField SURNAME;
                public TTReportField NAME;
                public TTReportField BIRTHINFO;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField FATHERNAME;
                public TTReportField NewField122;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField NewField162;
                public TTReportField NewField192;
                public TTReportField NewField103;
                public TTReportField NewField183;
                public TTReportShape NewLine13;
                public TTReportField SINRUT;
                public TTReportField FULLNAME;
                public TTReportField NewField1291;
                public TTReportField NewField11711;
                public TTReportField ISTEKDR;
                public TTReportField NewField1221;
                public TTReportField NewField1251;
                public TTReportField KIMLIKNO;
                public TTReportField FOREIGNUNIQUEREFNO;
                public TTReportField UNIQUEREFNO;
                public TTReportField FOREIGN;
                public TTReportField NewField1351;
                public TTReportShape NewLine12;
                public TTReportField NewField111711;
                public TTReportField WARVETERA; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 269;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 6, 171, 24, false);
                    HEADER1.Name = "HEADER1";
                    HEADER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER1.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER1.NoClip = EvetHayirEnum.ehEvet;
                    HEADER1.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER1.TextFont.Bold = true;
                    HEADER1.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 29, 190, 33, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.Value = @"{#REQUESTDATE#}";

                    BİRİMPRTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 10, 240, 14, false);
                    BİRİMPRTNO.Name = "BİRİMPRTNO";
                    BİRİMPRTNO.Visible = EvetHayirEnum.ehHayir;
                    BİRİMPRTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BİRİMPRTNO.Value = @"";

                    KARANTİNARAPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 11, 32, 15, false);
                    KARANTİNARAPNO.Name = "KARANTİNARAPNO";
                    KARANTİNARAPNO.Visible = EvetHayirEnum.ehHayir;
                    KARANTİNARAPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTİNARAPNO.Value = @"{%KARANTİNARAPNO%}";

                    sag = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 40, 198, 44, false);
                    sag.Name = "sag";
                    sag.FieldType = ReportFieldTypeEnum.ftVariable;
                    sag.Value = @"SAĞ:9042-{%QUARANTINEPROTOCOLNO%}-{%ACTIONDATE2%}/{%BIRIMADI%}-{%ACTIONID%}";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 50, 198, 55, false);
                    HEADER.Name = "HEADER";
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"BAŞTABİPLİĞE";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 62, 198, 80, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.Value = @"Aşağıda açık kimliği ve ön tanısı yazılı personelin {%YATIRILDIGISERV%} 'ne yatırılarak tetkik ve tedavi için emir ve müsaadelerinizi arzederim.
";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 44, 198, 48, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.Value = @"KONU: Hasta Yatış İstek";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 17, 31, 21, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.Value = @"{#ID#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 161, 98, 161, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 225, 20, false);
                    NUM.Name = "NUM";
                    NUM.Visible = EvetHayirEnum.ehHayir;
                    NUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUM.Value = @"";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 8, 32, 12, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.ObjectDefName = "InpatientAdmission";
                    BIRIMADI.DataMember = "FROMRESOURCE.NAME";
                    BIRIMADI.TextFont.Name = "Arial";
                    BIRIMADI.Value = @"{@TTOBJECTID@}";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 95, 31, 99, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.Value = @"";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 7, 205, 12, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 12, 205, 17, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 17, 205, 22, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    QUARANTINEPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 21, 38, 25, false);
                    QUARANTINEPROTOCOLNO.Name = "QUARANTINEPROTOCOLNO";
                    QUARANTINEPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEPROTOCOLNO.TextFont.Name = "Arial Narrow";
                    QUARANTINEPROTOCOLNO.TextFont.Size = 9;
                    QUARANTINEPROTOCOLNO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 56, 119, 61, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.TextFont.Name = "Arial Narrow";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 83, 41, 88, false);
                    date.Name = "date";
                    date.Visible = EvetHayirEnum.ehHayir;
                    date.FieldType = ReportFieldTypeEnum.ftVariable;
                    date.TextFormat = @"Short Date";
                    date.TextFont.Name = "Arial Narrow";
                    date.TextFont.Size = 9;
                    date.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    YATIRILDIGISERV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 89, 64, 94, false);
                    YATIRILDIGISERV.Name = "YATIRILDIGISERV";
                    YATIRILDIGISERV.Visible = EvetHayirEnum.ehHayir;
                    YATIRILDIGISERV.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIRILDIGISERV.TextFormat = @"NoCR";
                    YATIRILDIGISERV.TextFont.Name = "Arial Narrow";
                    YATIRILDIGISERV.TextFont.Size = 9;
                    YATIRILDIGISERV.Value = @"{#TREATMENTCLINIC#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 185, 210, 189, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.Visible = EvetHayirEnum.ehHayir;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{%NAME%} {%SURNAME%}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 229, 209, 233, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"dd/MM/yyyy";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#PATIENTBIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 225, 209, 229, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#PATIENTCITYOFBIRTH#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 220, 207, 224, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Arial Narrow";
                    SURNAME.TextFont.Size = 9;
                    SURNAME.Value = @"{#PATIENTSURNAME#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 215, 210, 219, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#PATIENTNAME#}";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 144, 173, 148, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 134, 47, 138, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.Value = @"Sınıf ve Rütbesi";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 144, 54, 148, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @"Doğum Yeri ve Tarihi";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 139, 173, 143, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 124, 47, 128, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Adı Soyadı";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 134, 68, 138, false);
                    NewField142.Name = "NewField142";
                    NewField142.Value = @":";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 124, 68, 128, false);
                    NewField152.Name = "NewField152";
                    NewField152.Value = @":";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 139, 50, 143, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Bold = true;
                    NewField162.Value = @"Baba Adı";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 144, 68, 148, false);
                    NewField192.Name = "NewField192";
                    NewField192.Value = @":";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 139, 68, 143, false);
                    NewField103.Name = "NewField103";
                    NewField103.Value = @":";

                    NewField183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 114, 113, 118, false);
                    NewField183.Name = "NewField183";
                    NewField183.TextFont.Bold = true;
                    NewField183.Value = @"KİMLİĞİ                                     :";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 118, 102, 118, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 134, 173, 138, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.Value = @"";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 124, 173, 128, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"{%NAME%} {%SURNAME%}";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 149, 68, 153, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.Value = @":";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 156, 54, 160, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @"Ön Tanı";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 84, 198, 110, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 119, 47, 123, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @"Kimlik No";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 119, 68, 123, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.Value = @":";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 119, 173, 123, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.Value = @"";

                    FOREIGNUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 122, 201, 126, false);
                    FOREIGNUNIQUEREFNO.Name = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    FOREIGNUNIQUEREFNO.TextFont.Size = 9;
                    FOREIGNUNIQUEREFNO.Value = @"{#FOREIGNUNIQUEREFNO#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 118, 204, 122, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    FOREIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 126, 201, 130, false);
                    FOREIGN.Name = "FOREIGN";
                    FOREIGN.Visible = EvetHayirEnum.ehHayir;
                    FOREIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGN.TextFont.Name = "Arial Narrow";
                    FOREIGN.TextFont.Size = 9;
                    FOREIGN.Value = @"{#FOREIGN#}";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 129, 68, 133, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.Value = @":";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 185, 98, 185, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 180, 54, 184, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Bold = true;
                    NewField111711.Value = @"Kesin Tanı";

                    WARVETERA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 129, 173, 133, false);
                    WARVETERA.Name = "WARVETERA";
                    WARVETERA.TextFont.Name = "Arial Narrow";
                    WARVETERA.TextFont.CharSet = 1;
                    WARVETERA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientAdmissionDeclaration_Class dataset_GetInpatientAdmissionDeclaration = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>(0);
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    HEADER1.CalcValue = MyParentReport.MAIN.SITENAME.CalcValue + @"
" + MyParentReport.MAIN.SITECITY.CalcValue + @"
";
                    ACTIONDATE.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.RequestDate) : "");
                    BİRİMPRTNO.CalcValue = @"";
                    KARANTİNARAPNO.CalcValue = MyParentReport.MAIN.KARANTİNARAPNO.CalcValue;
                    QUARANTINEPROTOCOLNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.QuarantineProtocolNo) : "");
                    ACTIONDATE2.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Quarantineinpatientdate) : "");
                    BIRIMADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BIRIMADI.PostFieldValueCalculation();
                    ACTIONID.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.ID) : "");
                    sag.CalcValue = @"SAĞ:9042-" + MyParentReport.MAIN.QUARANTINEPROTOCOLNO.CalcValue + @"-" + MyParentReport.MAIN.ACTIONDATE2.FormattedValue + @"/" + MyParentReport.MAIN.BIRIMADI.CalcValue + @"-" + MyParentReport.MAIN.ACTIONID.CalcValue;
                    HEADER.CalcValue = HEADER.Value;
                    YATIRILDIGISERV.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Treatmentclinic) : "");
                    NOT.CalcValue = @"Aşağıda açık kimliği ve ön tanısı yazılı personelin " + MyParentReport.MAIN.YATIRILDIGISERV.FormattedValue + @" 'ne yatırılarak tetkik ve tedavi için emir ve müsaadelerinizi arzederim.
";
                    KONU.CalcValue = @"KONU: Hasta Yatış İstek";
                    NUM.CalcValue = @"";
                    HASTANO.CalcValue = @"";
                    date.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Quarantineinpatientdate) : "");
                    NAME.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientname) : "");
                    SURNAME.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientsurname) : "");
                    ADSOYAD.CalcValue = MyParentReport.MAIN.NAME.CalcValue + @" " + MyParentReport.MAIN.SURNAME.CalcValue;
                    DTARIH.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientbirthdate) : "");
                    DYER.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientcityofbirth) : "");
                    BIRTHINFO.CalcValue = MyParentReport.MAIN.DYER.CalcValue + @" / " + MyParentReport.MAIN.DTARIH.FormattedValue;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    FATHERNAME.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.FatherName) : "");
                    NewField122.CalcValue = NewField122.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField192.CalcValue = NewField192.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField183.CalcValue = NewField183.Value;
                    SINRUT.CalcValue = @"";
                    FULLNAME.CalcValue = MyParentReport.MAIN.NAME.CalcValue + @" " + MyParentReport.MAIN.SURNAME.CalcValue;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    ISTEKDR.CalcValue = @"";
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    KIMLIKNO.CalcValue = @"";
                    FOREIGNUNIQUEREFNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.ForeignUniqueRefNo) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.UniqueRefNo) : "");
                    FOREIGN.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Foreign) : "");
                    NewField1351.CalcValue = NewField1351.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    WARVETERA.CalcValue = WARVETERA.Value;
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { SITENAME,SITECITY,HEADER1,ACTIONDATE,BİRİMPRTNO,KARANTİNARAPNO,QUARANTINEPROTOCOLNO,ACTIONDATE2,BIRIMADI,ACTIONID,sag,HEADER,YATIRILDIGISERV,NOT,KONU,NUM,HASTANO,date,NAME,SURNAME,ADSOYAD,DTARIH,DYER,BIRTHINFO,NewField161,NewField171,FATHERNAME,NewField122,NewField142,NewField152,NewField162,NewField192,NewField103,NewField183,SINRUT,FULLNAME,NewField1291,NewField11711,ISTEKDR,NewField1221,NewField1251,KIMLIKNO,FOREIGNUNIQUEREFNO,UNIQUEREFNO,FOREIGN,NewField1351,NewField111711,WARVETERA,KURUM};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            
//            TTObjectContext objectContext = new TTObjectContext(true);
//            string objectID = ((InpatientAdmissionRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            InpatientAdmission inpatientAdmission = (InpatientAdmission)objectContext.GetObject(new Guid(objectID),"InpatientAdmission");
//
//            if(inpatientAdmission.ProcedureDoctor!=null)
//                this.ISTEKDR.CalcValue =inpatientAdmission.ProcedureDoctor.SignatureBlock;
//            
//            if (inpatientAdmission.Episode.Patient.Foreign == true)
//                this.HASTANO.CalcValue = inpatientAdmission.Episode.Patient.ForeignUniqueRefNo.ToString();
//            else
//                this.HASTANO.CalcValue = inpatientAdmission.Episode.Patient.UniqueRefNo.ToString();
//
//            
//            foreach (DiagnosisGrid pdG in inpatientAdmission.Episode.Diagnosis)
//            {
//                if(pdG.DiagnosisType==DiagnosisTypeEnum.Primer)
//                {
//                    if(!String.IsNullOrEmpty(this.DIAGNOSE.CalcValue))
//                        this.DIAGNOSE.CalcValue += "   -   ";
//                    if(pdG.Diagnose!=null)
//                        this.DIAGNOSE.CalcValue += pdG.Diagnose.Code + " " + pdG.Diagnose.Name;
//                }
//
//                if (pdG.DiagnosisType == DiagnosisTypeEnum.Seconder)
//                {
//                    if (!String.IsNullOrEmpty(this.DIAGNOSESEC.CalcValue))
//                        this.DIAGNOSESEC.CalcValue += "   -   ";
//                    if (pdG.Diagnose != null)
//                        this.DIAGNOSESEC.CalcValue += pdG.Diagnose.Code + " " + pdG.Diagnose.Name;
//                }
//                
//            }
//            
//            this.SINRUT.CalcValue = inpatientAdmission.Episode.ClassRankInfoForReport;
//
//            this.ONAY.CalcValue = TTObjectClasses.ResHospital.ApprovalSignatureBlock;
//            
//            if(this.FOREIGN.CalcValue == "1")
//                this.KIMLIKNO.CalcValue = "(*)" + this.FOREIGNUNIQUEREFNO.CalcValue;
//            else
//                this.KIMLIKNO.CalcValue = this.UNIQUEREFNO.CalcValue;
//            
//            
//            
//            if (inpatientAdmission == null)
//                throw new Exception("Hastanın vakasına ulaşılamadı .Lütfen Bilgi işleme Başvurunuz");
//            if(inpatientAdmission.Episode.WarVetera == true)
//                this.WARVETERA.CalcValue ="(Muharip Gazi)";
//            if(inpatientAdmission.Episode.DisabledWarVetera == true)
//                this.WARVETERA.CalcValue ="(Malul Gazi)";

            
//
            //            if (TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION", "HEADDOCTOR") == "IITABIP")
            //            {
            //                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIP","");
            //            }
            //            else //BASHEKIM ise
            //            {
            //                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","");
            //            }
//
            
            //            string asube = this.XXXXXXLIKSUBE.CalcValue;
            //            //System.Diagnostics.Debugger.Break();
            //            //int x = asube.IndexOf(" ");
            //            //if(x > 0)
            //            // {
            //            //asube = asube.Substring(1,x-1) + " XXXXXXLİK ŞUBESİ BAŞKANLIĞINA "  + asube.Substring(x+1);
            //            asube = asube.ToString() + " XXXXXXLİK ŞUBESİ BAŞKANLIĞINA ";
            //            // }
            //            string s = "";
            //            int i = 1;
            //            if (this.BIRLIK.CalcValue != "")
            //            {
            //                s = s + i + "." + this.BIRLIK.CalcValue + "\r\n";
            //                this.DAGITIM11.CalcValue  = this.BIRLIK.CalcValue.Trim();
            //                i++;
            //            }
//
//
            //            if (asube != "")
            //            {
            //                s = s + i + "." + asube + "\r\n";
            //                this.DAGITIM12.CalcValue  = asube.Trim();
            //                i++;
            //            }
//
//
            //            if (this.MAKAM.CalcValue != "" && this.BIRLIK.CalcValue != this.MAKAM.CalcValue )
            //            {
            //                s = s + i + "." +this.MAKAM.CalcValue + "\r\n";
            //                this.DAGITIM13.CalcValue = this.MAKAM.CalcValue.Trim();
            //                i++;
            //            }
//
            //            this.DAGITIM2.CalcValue  = s;
//
            //            if ( this.ParentReport.CurrentCopy == 1 )
            //            {
            //                this.BASLIK.CalcValue = this.DAGITIM11.CalcValue;
            //            }
            //            else if(this.ParentReport.CurrentCopy==2)
            //            {
            //                this.BASLIK.CalcValue = this.DAGITIM12.CalcValue;
            //            }
            //            else
            //            {
            //                this.BASLIK.CalcValue =this.DAGITIM13.CalcValue;
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

        public InpatientAdmissionRequestReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INPATIENTADMISSIONREQUESTREPORT";
            Caption = "Yatış İstek Formu";
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
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