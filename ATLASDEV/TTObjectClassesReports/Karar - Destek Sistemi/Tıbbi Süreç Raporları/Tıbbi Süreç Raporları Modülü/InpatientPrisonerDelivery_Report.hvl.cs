
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
    /// Tutuklu Sevki
    /// </summary>
    public partial class InpatientPrisonerDelivery : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string Yer = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public InpatientPrisonerDelivery MyParentReport
            {
                get { return (InpatientPrisonerDelivery)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public InpatientPrisonerDelivery MyParentReport
                {
                    get { return (InpatientPrisonerDelivery)ParentReport; }
                }
                 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public InpatientPrisonerDelivery MyParentReport
                {
                    get { return (InpatientPrisonerDelivery)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 2, 41, 8, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.TextFont.Name = "Courier New";
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.TextFont.CharSet = 162;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 2, 212, 2, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 8, 212, 13, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Name = "Courier New";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 3, 212, 8, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Courier New";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 3, 112, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Courier New";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
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

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientPrisonerDelivery MyParentReport
            {
                get { return (InpatientPrisonerDelivery)ParentReport; }
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
            public TTReportField NewField61 { get {return Body().NewField61;} }
            public TTReportField NewField71 { get {return Body().NewField71;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
            public TTReportField SINIF { get {return Body().SINIF;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField NewField42 { get {return Body().NewField42;} }
            public TTReportField NewField52 { get {return Body().NewField52;} }
            public TTReportField NewField62 { get {return Body().NewField62;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField NewField92 { get {return Body().NewField92;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField NewField63 { get {return Body().NewField63;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField83 { get {return Body().NewField83;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField SAG { get {return Body().SAG;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField DAGITIM2 { get {return Body().DAGITIM2;} }
            public TTReportField DAGITIM11 { get {return Body().DAGITIM11;} }
            public TTReportField DAGITIM12 { get {return Body().DAGITIM12;} }
            public TTReportField KONU { get {return Body().KONU;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField YATIRILDIGISERV { get {return Body().YATIRILDIGISERV;} }
            public TTReportField SINRUT { get {return Body().SINRUT;} }
            public TTReportField ACTIONDATE2 { get {return Body().ACTIONDATE2;} }
            public TTReportField ONAY { get {return Body().ONAY;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField EVRAKTARIHI { get {return Body().EVRAKTARIHI;} }
            public TTReportField EVRAKSAYISI { get {return Body().EVRAKSAYISI;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportField DAGITIM { get {return Body().DAGITIM;} }
            public TTReportField YER { get {return Body().YER;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetInpatientPrisonerDelivery_Class>("GetInpatientPrisonerDelivery", InpatientAdmission.GetInpatientPrisonerDelivery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InpatientPrisonerDelivery MyParentReport
                {
                    get { return (InpatientPrisonerDelivery)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField QUARANTINEPROTOCOLNO;
                public TTReportField KARANTİNARAPNO;
                public TTReportField date;
                public TTReportField BIRTHINFO;
                public TTReportField NewField61;
                public TTReportField NewField71;
                public TTReportField FATHERNAME;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField NewField22;
                public TTReportField DTARIH;
                public TTReportField NewField42;
                public TTReportField NewField52;
                public TTReportField NewField62;
                public TTReportField DYER;
                public TTReportField NewField92;
                public TTReportField NewField3;
                public TTReportField BIRLIK;
                public TTReportField MAKAM;
                public TTReportField NewField63;
                public TTReportShape NewLine2;
                public TTReportField NewField83;
                public TTReportShape NewLine3;
                public TTReportField SAG;
                public TTReportField BASLIK;
                public TTReportField NOT;
                public TTReportField DAGITIM2;
                public TTReportField DAGITIM11;
                public TTReportField DAGITIM12;
                public TTReportField KONU;
                public TTReportField NewField4;
                public TTReportShape NewLine4;
                public TTReportField ACTIONID;
                public TTReportField YATIRILDIGISERV;
                public TTReportField SINRUT;
                public TTReportField ACTIONDATE2;
                public TTReportField ONAY;
                public TTReportField SURNAME;
                public TTReportField FULLNAME;
                public TTReportField NAME;
                public TTReportField EVRAKTARIHI;
                public TTReportField EVRAKSAYISI;
                public TTReportField NewField5;
                public TTReportShape NewLine5;
                public TTReportField DAGITIM;
                public TTReportField YER;
                public TTReportField NewField15;
                public TTReportField HEADER;
                public TTReportField NewField101;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField KURUM; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 176;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 30, 207, 34, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"Medium Date";
                    ACTIONDATE.TextFont.Name = "Courier New";
                    ACTIONDATE.TextFont.CharSet = 162;
                    ACTIONDATE.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    QUARANTINEPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 18, 226, 22, false);
                    QUARANTINEPROTOCOLNO.Name = "QUARANTINEPROTOCOLNO";
                    QUARANTINEPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEPROTOCOLNO.TextFont.Size = 9;
                    QUARANTINEPROTOCOLNO.TextFont.CharSet = 162;
                    QUARANTINEPROTOCOLNO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                    KARANTİNARAPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 46, 235, 50, false);
                    KARANTİNARAPNO.Name = "KARANTİNARAPNO";
                    KARANTİNARAPNO.Visible = EvetHayirEnum.ehHayir;
                    KARANTİNARAPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTİNARAPNO.TextFont.Size = 9;
                    KARANTİNARAPNO.TextFont.CharSet = 162;
                    KARANTİNARAPNO.Value = @"{#REPORTNO#}";

                    date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 73, 48, 78, false);
                    date.Name = "date";
                    date.Visible = EvetHayirEnum.ehHayir;
                    date.FieldType = ReportFieldTypeEnum.ftVariable;
                    date.TextFormat = @"Short Date";
                    date.TextFont.Size = 9;
                    date.TextFont.CharSet = 162;
                    date.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 160, 180, 164, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.TextFont.Name = "Courier New";
                    BIRTHINFO.TextFont.CharSet = 162;
                    BIRTHINFO.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 150, 54, 154, false);
                    NewField61.Name = "NewField61";
                    NewField61.TextFont.Name = "Courier New";
                    NewField61.TextFont.Bold = true;
                    NewField61.TextFont.CharSet = 162;
                    NewField61.Value = @"Sınıf ve Rütbesi";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 160, 61, 164, false);
                    NewField71.Name = "NewField71";
                    NewField71.TextFont.Name = "Courier New";
                    NewField71.TextFont.Bold = true;
                    NewField71.TextFont.CharSet = 162;
                    NewField71.Value = @"Doğum Yeri ve Tarihi";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 155, 180, 159, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.Name = "Courier New";
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 109, 201, 114, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Size = 9;
                    RUTBE.TextFont.CharSet = 162;
                    RUTBE.Value = @"";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 104, 202, 109, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Size = 9;
                    SINIF.TextFont.CharSet = 162;
                    SINIF.Value = @"";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 145, 54, 149, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Courier New";
                    NewField22.TextFont.Bold = true;
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @"Adı Soyadı";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 158, 211, 162, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Medium Date";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.TextFont.CharSet = 162;
                    DTARIH.Value = @"{#PATIENTBIRTHDATE#}";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 150, 75, 154, false);
                    NewField42.Name = "NewField42";
                    NewField42.TextFont.Name = "Courier New";
                    NewField42.TextFont.CharSet = 162;
                    NewField42.Value = @":";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 145, 75, 149, false);
                    NewField52.Name = "NewField52";
                    NewField52.TextFont.Name = "Courier New";
                    NewField52.TextFont.CharSet = 162;
                    NewField52.Value = @":";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 155, 57, 159, false);
                    NewField62.Name = "NewField62";
                    NewField62.TextFont.Name = "Courier New";
                    NewField62.TextFont.Bold = true;
                    NewField62.TextFont.CharSet = 162;
                    NewField62.Value = @"Baba Adı";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 153, 211, 157, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Size = 9;
                    DYER.TextFont.CharSet = 162;
                    DYER.Value = @"{#PATIENTCITYOFBIRTH#}";

                    NewField92 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 160, 75, 164, false);
                    NewField92.Name = "NewField92";
                    NewField92.TextFont.Name = "Courier New";
                    NewField92.TextFont.CharSet = 162;
                    NewField92.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 155, 75, 159, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Courier New";
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @":";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 71, 218, 75, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.Visible = EvetHayirEnum.ehHayir;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 132, 207, 136, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Size = 9;
                    MAKAM.TextFont.CharSet = 162;
                    MAKAM.Value = @"";

                    NewField63 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 107, 120, 111, false);
                    NewField63.Name = "NewField63";
                    NewField63.TextFont.Name = "Courier New";
                    NewField63.TextFont.Bold = true;
                    NewField63.TextFont.CharSet = 162;
                    NewField63.Value = @"DAĞITIM                                     :";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 111, 109, 111, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField83 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 140, 120, 144, false);
                    NewField83.Name = "NewField83";
                    NewField83.TextFont.Name = "Courier New";
                    NewField83.TextFont.Bold = true;
                    NewField83.TextFont.CharSet = 162;
                    NewField83.Value = @"KİMLİĞİ                                     :";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 144, 109, 144, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 30, 145, 34, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.TextFont.Name = "Courier New";
                    SAG.TextFont.CharSet = 162;
                    SAG.Value = @"SAĞ:9042-{%QUARANTINEPROTOCOLNO%}-{%ACTIONDATE2%}/Krnt.Ks.-{%KARANTİNARAPNO%}";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 41, 206, 48, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaBottom;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Courier New";
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 52, 207, 70, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Size = 9;
                    NOT.TextFont.CharSet = 162;
                    NOT.Value = @"İLGİ:{%MAKAM%}'nın {%EVRAKTARIHI%} gün ve {%EVRAKSAYISI%} sayılı yazısı.
1.İlgi yazı ile muayene ve tedavi için, 600 Yataklı Mevki XXXXXX Hastahanesine gönderilen {%FULLNAME%} {%DATE%} tarihinde {%YATIRILDIGISERV%}'ne tutuklu bölümüne yatırılmıştır.
2. Anılan tutuklunun taburcu işlemleri tamamlanmış olup, gelmiş olduğu {@Yer@} sevkinin sağlanmasını arz ederim.";

                    DAGITIM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 117, 131, 134, false);
                    DAGITIM2.Name = "DAGITIM2";
                    DAGITIM2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    DAGITIM2.MultiLine = EvetHayirEnum.ehEvet;
                    DAGITIM2.TextFont.Name = "Courier New";
                    DAGITIM2.TextFont.CharSet = 162;
                    DAGITIM2.Value = @"MRK.K.LIĞI-XXXXXX
2.AS.İZ.BLG.K.LIĞI-XXXXXX";

                    DAGITIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 80, 36, 86, false);
                    DAGITIM11.Name = "DAGITIM11";
                    DAGITIM11.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM11.TextFont.Size = 9;
                    DAGITIM11.TextFont.CharSet = 162;
                    DAGITIM11.Value = @""" MRK.K.LIĞI-XXXXXX """;

                    DAGITIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 85, 36, 90, false);
                    DAGITIM12.Name = "DAGITIM12";
                    DAGITIM12.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM12.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM12.TextFont.Size = 9;
                    DAGITIM12.TextFont.CharSet = 162;
                    DAGITIM12.Value = @""" 2.AS.İZ.BLG.K.LIĞI-XXXXXX """;

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 34, 145, 38, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Courier New";
                    KONU.TextFont.CharSet = 162;
                    KONU.Value = @"KONU: Tutuklu {%FULLNAME%}'ün Sevki Hk.";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 112, 31, 116, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Courier New";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Gereği:";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 116, 30, 116, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 3, 249, 7, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ID#}";

                    YATIRILDIGISERV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 73, 104, 78, false);
                    YATIRILDIGISERV.Name = "YATIRILDIGISERV";
                    YATIRILDIGISERV.Visible = EvetHayirEnum.ehHayir;
                    YATIRILDIGISERV.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIRILDIGISERV.TextFormat = @"NoCR";
                    YATIRILDIGISERV.TextFont.Size = 9;
                    YATIRILDIGISERV.TextFont.CharSet = 162;
                    YATIRILDIGISERV.Value = @"{#TREATMENTCLINIC#}";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 150, 180, 154, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Courier New";
                    SINRUT.TextFont.CharSet = 162;
                    SINRUT.Value = @"{%SINIF%} {%RUTBE%}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 7, 244, 12, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.TextFont.CharSet = 162;
                    ACTIONDATE2.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 84, 207, 100, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftExpression;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Size = 9;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"","""");";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 148, 209, 152, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Size = 9;
                    SURNAME.TextFont.CharSet = 162;
                    SURNAME.Value = @"{#PATIENTSURNAME#}";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 145, 180, 149, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Courier New";
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 143, 212, 147, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#PATIENTNAME#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 80, 70, 85, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.TextFont.Size = 9;
                    EVRAKTARIHI.TextFont.CharSet = 162;
                    EVRAKTARIHI.Value = @"{#EVRAKTARIHI#}";

                    EVRAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 87, 93, 92, false);
                    EVRAKSAYISI.Name = "EVRAKSAYISI";
                    EVRAKSAYISI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKSAYISI.TextFormat = @"NoCR";
                    EVRAKSAYISI.TextFont.Size = 9;
                    EVRAKSAYISI.TextFont.CharSet = 162;
                    EVRAKSAYISI.Value = @"{#EVRAKSAYISI#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 110, 167, 114, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Courier New";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"BİLGİ            :";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 145, 115, 167, 115, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    DAGITIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 117, 206, 123, false);
                    DAGITIM.Name = "DAGITIM";
                    DAGITIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM.VertAlign = VerticalAlignmentEnum.vaBottom;
                    DAGITIM.MultiLine = EvetHayirEnum.ehEvet;
                    DAGITIM.TextFont.Name = "Courier New";
                    DAGITIM.TextFont.CharSet = 162;
                    DAGITIM.Value = @"{@Yer@}
";

                    YER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 96, 132, 101, false);
                    YER.Name = "YER";
                    YER.Visible = EvetHayirEnum.ehHayir;
                    YER.FieldType = ReportFieldTypeEnum.ftVariable;
                    YER.TextFormat = @"Short Date";
                    YER.TextFont.Size = 9;
                    YER.TextFont.CharSet = 162;
                    YER.Value = @"{@Yer@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 78, 190, 82, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Courier New";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"ONAY";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 3, 175, 26, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Courier New";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"{%KURUM%}
{%SITENAME%}
{%SITECITY%}
";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 7, 41, 11, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Name = "Courier New";
                    NewField101.TextFont.Underline = true;
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"HİZMETE ÖZEL";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 211, 5, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.TextFont.Name = "Courier New";
                    SITENAME.TextFont.CharSet = 162;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 6, 212, 11, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.TextFont.Name = "Courier New";
                    SITECITY.TextFont.CharSet = 162;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 13, 212, 18, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.TextFont.Name = "Courier New";
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientPrisonerDelivery_Class dataset_GetInpatientPrisonerDelivery = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientPrisonerDelivery_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Quarantineinpatientdate) : "");
                    QUARANTINEPROTOCOLNO.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.QuarantineProtocolNo) : "");
                    KARANTİNARAPNO.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.ReportNo) : "");
                    date.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Quarantineinpatientdate) : "");
                    DYER.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Patientcityofbirth) : "");
                    DTARIH.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Patientbirthdate) : "");
                    BIRTHINFO.CalcValue = MyParentReport.MAIN.DYER.CalcValue + @" / " + MyParentReport.MAIN.DTARIH.FormattedValue;
                    NewField61.CalcValue = NewField61.Value;
                    NewField71.CalcValue = NewField71.Value;
                    FATHERNAME.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.FatherName) : "");
                    RUTBE.CalcValue = @"";
                    SINIF.CalcValue = @"";
                    NewField22.CalcValue = NewField22.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField52.CalcValue = NewField52.Value;
                    NewField62.CalcValue = NewField62.Value;
                    NewField92.CalcValue = NewField92.Value;
                    NewField3.CalcValue = NewField3.Value;
                    BIRLIK.CalcValue = @"";
                    MAKAM.CalcValue = @"";
                    NewField63.CalcValue = NewField63.Value;
                    NewField83.CalcValue = NewField83.Value;
                    ACTIONDATE2.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Quarantineinpatientdate) : "");
                    SAG.CalcValue = @"SAĞ:9042-" + MyParentReport.MAIN.QUARANTINEPROTOCOLNO.CalcValue + @"-" + MyParentReport.MAIN.ACTIONDATE2.FormattedValue + @"/Krnt.Ks.-" + MyParentReport.MAIN.KARANTİNARAPNO.CalcValue;
                    BASLIK.CalcValue = @"";
                    EVRAKTARIHI.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Evraktarihi) : "");
                    EVRAKSAYISI.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Evraksayisi) : "");
                    FULLNAME.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Patientname) : "") + @" " + (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Patientsurname) : "");
                    YATIRILDIGISERV.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Treatmentclinic) : "");
                    NOT.CalcValue = @"İLGİ:" + MyParentReport.MAIN.MAKAM.CalcValue + @"'nın " + MyParentReport.MAIN.EVRAKTARIHI.FormattedValue + @" gün ve " + MyParentReport.MAIN.EVRAKSAYISI.FormattedValue + @" sayılı yazısı.
1.İlgi yazı ile muayene ve tedavi için, 600 Yataklı Mevki XXXXXX Hastahanesine gönderilen " + MyParentReport.MAIN.FULLNAME.CalcValue + @" " + MyParentReport.MAIN.date.FormattedValue + @" tarihinde " + MyParentReport.MAIN.YATIRILDIGISERV.FormattedValue + @"'ne tutuklu bölümüne yatırılmıştır.
2. Anılan tutuklunun taburcu işlemleri tamamlanmış olup, gelmiş olduğu " + MyParentReport.RuntimeParameters.Yer.ToString() + @" sevkinin sağlanmasını arz ederim.";
                    DAGITIM2.CalcValue = @"MRK.K.LIĞI-XXXXXX
2.AS.İZ.BLG.K.LIĞI-XXXXXX";
                    DAGITIM11.CalcValue = @""" MRK.K.LIĞI-XXXXXX """;
                    DAGITIM12.CalcValue = @""" 2.AS.İZ.BLG.K.LIĞI-XXXXXX """;
                    KONU.CalcValue = @"KONU: Tutuklu " + MyParentReport.MAIN.FULLNAME.CalcValue + @"'ün Sevki Hk.";
                    NewField4.CalcValue = NewField4.Value;
                    ACTIONID.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.ID) : "");
                    SINRUT.CalcValue = MyParentReport.MAIN.SINIF.CalcValue + @" " + MyParentReport.MAIN.RUTBE.CalcValue;
                    SURNAME.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Patientsurname) : "");
                    NAME.CalcValue = (dataset_GetInpatientPrisonerDelivery != null ? Globals.ToStringCore(dataset_GetInpatientPrisonerDelivery.Patientname) : "");
                    NewField5.CalcValue = NewField5.Value;
                    DAGITIM.CalcValue = MyParentReport.RuntimeParameters.Yer.ToString() + @"
";
                    YER.CalcValue = MyParentReport.RuntimeParameters.Yer.ToString();
                    NewField15.CalcValue = NewField15.Value;
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    HEADER.CalcValue = MyParentReport.MAIN.KURUM.CalcValue + @"
" + MyParentReport.MAIN.SITENAME.CalcValue + @"
" + MyParentReport.MAIN.SITECITY.CalcValue + @"
";
                    NewField101.CalcValue = NewField101.Value;
                    ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","");;
                    return new TTReportObject[] { ACTIONDATE,QUARANTINEPROTOCOLNO,KARANTİNARAPNO,date,DYER,DTARIH,BIRTHINFO,NewField61,NewField71,FATHERNAME,RUTBE,SINIF,NewField22,NewField42,NewField52,NewField62,NewField92,NewField3,BIRLIK,MAKAM,NewField63,NewField83,ACTIONDATE2,SAG,BASLIK,EVRAKTARIHI,EVRAKSAYISI,FULLNAME,YATIRILDIGISERV,NOT,DAGITIM2,DAGITIM11,DAGITIM12,KONU,NewField4,ACTIONID,SINRUT,SURNAME,NAME,NewField5,DAGITIM,YER,NewField15,KURUM,SITENAME,SITECITY,HEADER,NewField101,ONAY};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION", "HEADDOCTOR") == "IITABIP")
            {
                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIP","");
            }
            else //BASHEKIM ise
            {
                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","");
            }
                       
            
            if ( this.ParentReport.CurrentCopy == 1 )
            {
                this.BASLIK.CalcValue = this.DAGITIM11.CalcValue;
            }
            else if(this.ParentReport.CurrentCopy==2)
            {
                this.BASLIK.CalcValue = this.DAGITIM12.CalcValue;
            }
             else if(this.ParentReport.CurrentCopy==3)
            {
                this.BASLIK.CalcValue = this.YER.CalcValue;
            }
            else
            {
                this.BASLIK.CalcValue =" ";
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

        public InpatientPrisonerDelivery()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hasta Yatış", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("Yer", "", "Gideceği Yer", @"", true, true, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("Yer"))
                _runtimeParameters.Yer = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["Yer"]);
            Name = "INPATIENTPRISONERDELIVERY";
            Caption = "Tutuklu Sevki";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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