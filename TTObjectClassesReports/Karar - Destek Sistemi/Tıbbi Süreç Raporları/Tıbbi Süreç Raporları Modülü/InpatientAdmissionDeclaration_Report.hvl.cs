
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
    /// Hasta Yatış Bildirimi
    /// </summary>
    public partial class InpatientAdmissionDeclaration : TTReport
    {
#region Methods
   public List<DagitimBilgi> dagitimList = new List<DagitimBilgi>();
        public string dagitim = "";
        
        public class DagitimBilgi
        {
            public string Baslik;
            public DagitimBilgi(string baslik)
            {
                Baslik = baslik;
            }
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public InpatientAdmissionDeclaration MyParentReport
            {
                get { return (InpatientAdmissionDeclaration)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public InpatientAdmissionDeclaration MyParentReport
                {
                    get { return (InpatientAdmissionDeclaration)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public InpatientAdmissionDeclaration MyParentReport
                {
                    get { return (InpatientAdmissionDeclaration)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 36, 8, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 208, 2, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 8, 207, 13, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 3, 207, 8, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Size = 8;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 3, 107, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + @"}";
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel,PrintDate,PageNumber,UserName};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientAdmissionDeclaration MyParentReport
            {
                get { return (InpatientAdmissionDeclaration)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField QUARANTINEPROTOCOLNO { get {return Body().QUARANTINEPROTOCOLNO;} }
            public TTReportField KARANTİNARAPNO { get {return Body().KARANTİNARAPNO;} }
            public TTReportField date { get {return Body().date;} }
            public TTReportField BIRTHINFO { get {return Body().BIRTHINFO;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
            public TTReportField SINIF { get {return Body().SINIF;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportField XXXXXXLIKSUBE { get {return Body().XXXXXXLIKSUBE;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField NewField36 { get {return Body().NewField36;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField38 { get {return Body().NewField38;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField SAG { get {return Body().SAG;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField DAGITIM2 { get {return Body().DAGITIM2;} }
            public TTReportField DAGITIM11 { get {return Body().DAGITIM11;} }
            public TTReportField DAGITIM12 { get {return Body().DAGITIM12;} }
            public TTReportField DAGITIM13 { get {return Body().DAGITIM13;} }
            public TTReportField KONU { get {return Body().KONU;} }
            public TTReportField NewField40 { get {return Body().NewField40;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField YATIRILDIGISERV { get {return Body().YATIRILDIGISERV;} }
            public TTReportField SINRUT { get {return Body().SINRUT;} }
            public TTReportField ACTIONDATE2 { get {return Body().ACTIONDATE2;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField ONAY { get {return Body().ONAY;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
            public TTReportField FOREIGNUNIQUEREFNO { get {return Body().FOREIGNUNIQUEREFNO;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField FOREIGN { get {return Body().FOREIGN;} }
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
                public InpatientAdmissionDeclaration MyParentReport
                {
                    get { return (InpatientAdmissionDeclaration)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField QUARANTINEPROTOCOLNO;
                public TTReportField KARANTİNARAPNO;
                public TTReportField date;
                public TTReportField BIRTHINFO;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField FATHERNAME;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField NewField22;
                public TTReportField DTARIH;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportField NewField26;
                public TTReportField DYER;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportField XXXXXXLIKSUBE;
                public TTReportField BIRLIK;
                public TTReportField MAKAM;
                public TTReportField NewField36;
                public TTReportShape NewLine2;
                public TTReportField NewField38;
                public TTReportShape NewLine3;
                public TTReportField SAG;
                public TTReportField BASLIK;
                public TTReportField NOT;
                public TTReportField DAGITIM2;
                public TTReportField DAGITIM11;
                public TTReportField DAGITIM12;
                public TTReportField DAGITIM13;
                public TTReportField KONU;
                public TTReportField NewField40;
                public TTReportShape NewLine4;
                public TTReportField ACTIONID;
                public TTReportField YATIRILDIGISERV;
                public TTReportField SINRUT;
                public TTReportField ACTIONDATE2;
                public TTReportField SURNAME;
                public TTReportField FULLNAME;
                public TTReportField NAME;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField KURUM;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField ONAY;
                public TTReportField NewField122;
                public TTReportField NewField152;
                public TTReportField KIMLIKNO;
                public TTReportField FOREIGNUNIQUEREFNO;
                public TTReportField UNIQUEREFNO;
                public TTReportField FOREIGN; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 204;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 33, 190, 37, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.TextFont.Size = 9;
                    ACTIONDATE.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    QUARANTINEPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 25, 152, 29, false);
                    QUARANTINEPROTOCOLNO.Name = "QUARANTINEPROTOCOLNO";
                    QUARANTINEPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEPROTOCOLNO.TextFont.Name = "Arial Narrow";
                    QUARANTINEPROTOCOLNO.TextFont.Size = 9;
                    QUARANTINEPROTOCOLNO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                    KARANTİNARAPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 25, 116, 29, false);
                    KARANTİNARAPNO.Name = "KARANTİNARAPNO";
                    KARANTİNARAPNO.Visible = EvetHayirEnum.ehHayir;
                    KARANTİNARAPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTİNARAPNO.TextFont.Name = "Arial Narrow";
                    KARANTİNARAPNO.TextFont.Size = 9;
                    KARANTİNARAPNO.Value = @"{#REPORTNO#}";

                    date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 76, 44, 81, false);
                    date.Name = "date";
                    date.Visible = EvetHayirEnum.ehHayir;
                    date.FieldType = ReportFieldTypeEnum.ftVariable;
                    date.TextFormat = @"Short Date";
                    date.TextFont.Name = "Arial Narrow";
                    date.TextFont.Size = 9;
                    date.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 174, 176, 178, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 164, 50, 168, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"Sınıf ve Rütbesi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 174, 57, 178, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Doğum Yeri ve Tarihi";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 169, 176, 173, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 112, 197, 117, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial Narrow";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.Value = @"";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 107, 198, 112, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Name = "Arial Narrow";
                    SINIF.TextFont.Size = 9;
                    SINIF.Value = @"";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 154, 50, 158, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Adı Soyadı";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 157, 206, 161, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"dd/MM/yyyy";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#PATIENTBIRTHDATE#}";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 164, 71, 168, false);
                    NewField24.Name = "NewField24";
                    NewField24.Value = @":";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 154, 71, 158, false);
                    NewField25.Name = "NewField25";
                    NewField25.Value = @":";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 169, 53, 173, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"Baba Adı";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 153, 206, 157, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#PATIENTCITYOFBIRTH#}";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 174, 71, 178, false);
                    NewField29.Name = "NewField29";
                    NewField29.Value = @":";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 169, 71, 173, false);
                    NewField30.Name = "NewField30";
                    NewField30.Value = @":";

                    XXXXXXLIKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 126, 198, 130, false);
                    XXXXXXLIKSUBE.Name = "XXXXXXLIKSUBE";
                    XXXXXXLIKSUBE.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXLIKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE.TextFont.Name = "Arial Narrow";
                    XXXXXXLIKSUBE.TextFont.Size = 9;
                    XXXXXXLIKSUBE.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 122, 199, 126, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.Visible = EvetHayirEnum.ehHayir;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 118, 198, 122, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 9;
                    MAKAM.Value = @"";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 110, 116, 114, false);
                    NewField36.Name = "NewField36";
                    NewField36.TextFont.Bold = true;
                    NewField36.Value = @"DAĞITIM                                     :";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 114, 105, 114, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 143, 116, 147, false);
                    NewField38.Name = "NewField38";
                    NewField38.TextFont.Bold = true;
                    NewField38.Value = @"KİMLİĞİ                                     :";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 147, 105, 147, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 141, 37, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.Value = @"SAĞ:9042-{%QUARANTINEPROTOCOLNO%}-{%ACTIONDATE2%}/Krnt.Ks.-{%KARANTİNARAPNO%}";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 44, 202, 51, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaBottom;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 55, 201, 73, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.Value = @"Aşağıda açık kimliği yazılı personel {%DATE%} tarihinde {%YATIRILDIGISERV%} 'ne tetkik ve tedavi için yatırılmıştır.
Arz/Rica ederim.";

                    DAGITIM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 120, 172, 137, false);
                    DAGITIM2.Name = "DAGITIM2";
                    DAGITIM2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    DAGITIM2.MultiLine = EvetHayirEnum.ehEvet;
                    DAGITIM2.Value = @"1.{%DAGITIM11%}
2.{%DAGITIM12%}
3.{%DAGITIM13%}";

                    DAGITIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 83, 32, 89, false);
                    DAGITIM11.Name = "DAGITIM11";
                    DAGITIM11.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM11.TextFont.Name = "Arial Narrow";
                    DAGITIM11.TextFont.Size = 9;
                    DAGITIM11.Value = @"{%MAKAM%}";

                    DAGITIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 88, 32, 93, false);
                    DAGITIM12.Name = "DAGITIM12";
                    DAGITIM12.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM12.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM12.TextFont.Name = "Arial Narrow";
                    DAGITIM12.TextFont.Size = 9;
                    DAGITIM12.Value = @"";

                    DAGITIM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 93, 32, 98, false);
                    DAGITIM13.Name = "DAGITIM13";
                    DAGITIM13.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM13.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM13.TextFont.Name = "Arial Narrow";
                    DAGITIM13.TextFont.Size = 9;
                    DAGITIM13.Value = @"";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 37, 141, 41, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.Value = @"KONU: Hasta Yatış Bildirimi({%ACTIONID%})";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 115, 27, 119, false);
                    NewField40.Name = "NewField40";
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.TextFont.Size = 9;
                    NewField40.TextFont.Bold = true;
                    NewField40.Value = @"Gereği:";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 119, 26, 119, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 26, 79, 30, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ID#}";

                    YATIRILDIGISERV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 76, 100, 81, false);
                    YATIRILDIGISERV.Name = "YATIRILDIGISERV";
                    YATIRILDIGISERV.Visible = EvetHayirEnum.ehHayir;
                    YATIRILDIGISERV.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIRILDIGISERV.TextFormat = @"NoCR";
                    YATIRILDIGISERV.TextFont.Name = "Arial Narrow";
                    YATIRILDIGISERV.TextFont.Size = 9;
                    YATIRILDIGISERV.Value = @"{#TREATMENTCLINIC#}";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 164, 176, 168, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.Value = @"{%SINIF%} {%RUTBE%}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 24, 185, 29, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.TextFont.Name = "Arial Narrow";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 149, 204, 153, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Arial Narrow";
                    SURNAME.TextFont.Size = 9;
                    SURNAME.Value = @"{#PATIENTSURNAME#}";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 154, 176, 158, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"{%NAME%} {%SURNAME%}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 145, 207, 149, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#PATIENTNAME#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 6, 201, 26, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 12, 35, 18, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 24, 32, 29, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 25, 216, 30, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 31, 217, 36, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 78, 193, 98, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 149, 50, 153, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Kimlik No";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 149, 71, 153, false);
                    NewField152.Name = "NewField152";
                    NewField152.Value = @":";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 149, 176, 153, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.Value = @"";

                    FOREIGNUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 165, 204, 169, false);
                    FOREIGNUNIQUEREFNO.Name = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    FOREIGNUNIQUEREFNO.TextFont.Size = 9;
                    FOREIGNUNIQUEREFNO.Value = @"{#FOREIGNUNIQUEREFNO#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 161, 207, 165, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    FOREIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 169, 204, 173, false);
                    FOREIGN.Name = "FOREIGN";
                    FOREIGN.Visible = EvetHayirEnum.ehHayir;
                    FOREIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGN.TextFont.Name = "Arial Narrow";
                    FOREIGN.TextFont.Size = 9;
                    FOREIGN.Value = @"{#FOREIGN#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientAdmissionDeclaration_Class dataset_GetInpatientAdmissionDeclaration = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Quarantineinpatientdate) : "");
                    QUARANTINEPROTOCOLNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.QuarantineProtocolNo) : "");
                    KARANTİNARAPNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.ReportNo) : "");
                    date.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Quarantineinpatientdate) : "");
                    DYER.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientcityofbirth) : "");
                    DTARIH.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientbirthdate) : "");
                    BIRTHINFO.CalcValue = MyParentReport.MAIN.DYER.CalcValue + @" / " + MyParentReport.MAIN.DTARIH.FormattedValue;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    FATHERNAME.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.FatherName) : "");
                    RUTBE.CalcValue = @"";
                    SINIF.CalcValue = @"";
                    NewField22.CalcValue = NewField22.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    XXXXXXLIKSUBE.CalcValue = @"";
                    BIRLIK.CalcValue = @"";
                    MAKAM.CalcValue = @"";
                    NewField36.CalcValue = NewField36.Value;
                    NewField38.CalcValue = NewField38.Value;
                    ACTIONDATE2.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Quarantineinpatientdate) : "");
                    SAG.CalcValue = @"SAĞ:9042-" + MyParentReport.MAIN.QUARANTINEPROTOCOLNO.CalcValue + @"-" + MyParentReport.MAIN.ACTIONDATE2.FormattedValue + @"/Krnt.Ks.-" + MyParentReport.MAIN.KARANTİNARAPNO.CalcValue;
                    BASLIK.CalcValue = @"";
                    YATIRILDIGISERV.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Treatmentclinic) : "");
                    NOT.CalcValue = @"Aşağıda açık kimliği yazılı personel " + MyParentReport.MAIN.date.FormattedValue + @" tarihinde " + MyParentReport.MAIN.YATIRILDIGISERV.FormattedValue + @" 'ne tetkik ve tedavi için yatırılmıştır.
Arz/Rica ederim.";
                    DAGITIM11.CalcValue = MyParentReport.MAIN.MAKAM.CalcValue;
                    DAGITIM12.CalcValue = @"";
                    DAGITIM13.CalcValue = @"";
                    DAGITIM2.CalcValue = @"1." + MyParentReport.MAIN.DAGITIM11.CalcValue + @"
2." + MyParentReport.MAIN.DAGITIM12.CalcValue + @"
3." + MyParentReport.MAIN.DAGITIM13.CalcValue;
                    ACTIONID.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.ID) : "");
                    KONU.CalcValue = @"KONU: Hasta Yatış Bildirimi(" + MyParentReport.MAIN.ACTIONID.CalcValue + @")";
                    NewField40.CalcValue = NewField40.Value;
                    SINRUT.CalcValue = MyParentReport.MAIN.SINIF.CalcValue + @" " + MyParentReport.MAIN.RUTBE.CalcValue;
                    SURNAME.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientsurname) : "");
                    NAME.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Patientname) : "");
                    FULLNAME.CalcValue = MyParentReport.MAIN.NAME.CalcValue + @" " + MyParentReport.MAIN.SURNAME.CalcValue;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    XXXXXXBASLIK.CalcValue = MyParentReport.MAIN.SITENAME.CalcValue + @"
" + MyParentReport.MAIN.SITECITY.CalcValue + @"
";
                    NewField6.CalcValue = NewField6.Value;
                    ONAY.CalcValue = @"";
                    NewField122.CalcValue = NewField122.Value;
                    NewField152.CalcValue = NewField152.Value;
                    KIMLIKNO.CalcValue = @"";
                    FOREIGNUNIQUEREFNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.ForeignUniqueRefNo) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.UniqueRefNo) : "");
                    FOREIGN.CalcValue = (dataset_GetInpatientAdmissionDeclaration != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionDeclaration.Foreign) : "");
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { ACTIONDATE,QUARANTINEPROTOCOLNO,KARANTİNARAPNO,date,DYER,DTARIH,BIRTHINFO,NewField16,NewField17,FATHERNAME,RUTBE,SINIF,NewField22,NewField24,NewField25,NewField26,NewField29,NewField30,XXXXXXLIKSUBE,BIRLIK,MAKAM,NewField36,NewField38,ACTIONDATE2,SAG,BASLIK,YATIRILDIGISERV,NOT,DAGITIM11,DAGITIM12,DAGITIM13,DAGITIM2,ACTIONID,KONU,NewField40,SINRUT,SURNAME,NAME,FULLNAME,SITENAME,SITECITY,XXXXXXBASLIK,NewField6,ONAY,NewField122,NewField152,KIMLIKNO,FOREIGNUNIQUEREFNO,UNIQUEREFNO,FOREIGN,KURUM};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                                        
//            InpatientAdmissionDeclaration parentReport = (InpatientAdmissionDeclaration)ParentReport;
//            this.ONAY.CalcValue = TTObjectClasses.ResHospital.ApprovalSignatureBlock;
//            this.DAGITIM2.CalcValue = parentReport.dagitim;
//            DagitimBilgi dagitimBilgi = parentReport.dagitimList[parentReport.HEADER.GroupCounter-1];
//            this.BASLIK.CalcValue = dagitimBilgi.Baslik;
//            if(this.FOREIGN.CalcValue == "1")
//                this.KIMLIKNO.CalcValue = "(*)" + this.FOREIGNUNIQUEREFNO.CalcValue;
//            else
//                this.KIMLIKNO.CalcValue = this.UNIQUEREFNO.CalcValue;
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

        public InpatientAdmissionDeclaration()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hasta Yatış", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INPATIENTADMISSIONDECLARATION";
            Caption = "Hasta Yatış Bildirimi";
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


        protected override void RunPreScript()
        {
#region INPATIENTADMISSIONDECLARATION_PreScript
            TTObjectContext context = this.ReportObjectContext;
            string sObjectID = this.RuntimeParameters.TTOBJECTID.ToString();
            InpatientAdmission inpatientAdmission = (InpatientAdmission)context.GetObject(new Guid(sObjectID), "InpatientAdmission");
            
            Episode episode = inpatientAdmission.Episode;
            if (episode == null)
                throw new Exception("Hastanın vakasına ulaşılamadı .Lütfen Bilgi işleme Başvurunuz");

            int Sayac = 0;
            int i = 1;
            string s = "";
            
//            if (episode.MilitaryUnit != null)
//            {
//                s = s + i + "." + episode.MilitaryUnit.Name.ToString() + "\r\n";
//                this.dagitimList.Add(new DagitimBilgi(episode.MilitaryUnit.Name.ToString()));
//                i++;
//                Sayac++;
//            }
//
//            if (episode.MilitaryOffice != null)
//            {
//                s = s + i + "." + episode.MilitaryOffice.Name.ToString() + " XXXXXXLİK ŞUBESİ BAŞKANLIĞINA " + "\r\n";
//                this.dagitimList.Add(new DagitimBilgi(episode.MilitaryOffice.Name.ToString() + " XXXXXXLİK ŞUBESİ BAŞKANLIĞINA " ));
//                i++;
//                Sayac++;
//            }
//
//            if (episode.SenderChair != null)
//            {
//                bool isequal = false;
//                if(episode.MilitaryUnit != null && episode.SenderChair.ObjectID == episode.MilitaryUnit.ObjectID)
//                    isequal = true;
//                if(!isequal)
//                {
//                    s = s + i + "." +episode.SenderChair.Name.ToString() + "\r\n";
//                    this.dagitimList.Add(new DagitimBilgi(episode.SenderChair.Name.ToString()));
//                    i++;
//                    Sayac++;
//                }
//            }
            
            this.dagitim = s;
            
            if (Sayac == 0)
            {
                Sayac = 1;
                this.dagitimList.Add(new DagitimBilgi(""));
            }
            this.HEADER.RepeatCount = Sayac;
#endregion INPATIENTADMISSIONDECLARATION_PreScript
        }
    }
}