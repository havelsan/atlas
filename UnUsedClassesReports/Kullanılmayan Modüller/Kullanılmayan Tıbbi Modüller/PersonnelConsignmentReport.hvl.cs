
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
    /// Personel Sevk Muhtırası 
    /// </summary>
    public partial class PersonnelConsignmentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PersonnelConsignmentReport MyParentReport
            {
                get { return (PersonnelConsignmentReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public PersonnelConsignmentReport MyParentReport
                {
                    get { return (PersonnelConsignmentReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PersonnelConsignmentReport MyParentReport
                {
                    get { return (PersonnelConsignmentReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportField HizmetOzel;
                public TTReportShape NewLine2;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 41;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 210, 20, false);
                    NewField0.Name = "NewField0";
                    NewField0.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.NoClip = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 9;
                    NewField0.Value = @"""NOT: Personel Sevk Muhtırası alan hastaların saat 17:00 'ye kadar "" + TTObjectClasses.SystemParameter.GetParameterValue(""PersonelSevkMuhtrasıGönderilenYer"", ""ULAŞTIRMA HAREKET KONTROL XXXXXXLIĞI"") + "" 'nda bulunmaları gerekmektedir.""";

                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 25, 41, 31, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.TextFont.Name = "Arial Narrow";
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 16, 25, 213, 25, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 31, 212, 36, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 26, 212, 31, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 26, 112, 31, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + @"}";
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField0.CalcValue = "NOT: Personel Sevk Muhtırası alan hastaların saat 17:00 'ye kadar " + TTObjectClasses.SystemParameter.GetParameterValue("PersonelSevkMuhtrasıGönderilenYer", "ULAŞTIRMA HAREKET KONTROL XXXXXXLIĞI") + " 'nda bulunmaları gerekmektedir.";
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel,PrintDate,PageNumber,NewField0,UserName};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PersonnelConsignmentReport MyParentReport
            {
                get { return (PersonnelConsignmentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField KONU { get {return Body().KONU;} }
            public TTReportField BIRIMPRTNO { get {return Body().BIRIMPRTNO;} }
            public TTReportField NewField32 { get {return Body().NewField32;} }
            public TTReportField NewField33 { get {return Body().NewField33;} }
            public TTReportField NewField34 { get {return Body().NewField34;} }
            public TTReportField NewField135 { get {return Body().NewField135;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField XXXXXXSUBE { get {return Body().XXXXXXSUBE;} }
            public TTReportField GONDERILEN { get {return Body().GONDERILEN;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField ACTIONDATE2 { get {return Body().ACTIONDATE2;} }
            public TTReportField NewField38 { get {return Body().NewField38;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField REFFULLNAME { get {return Body().REFFULLNAME;} }
            public TTReportField NewField41 { get {return Body().NewField41;} }
            public TTReportField NewField42 { get {return Body().NewField42;} }
            public TTReportField INPLACE { get {return Body().INPLACE;} }
            public TTReportField BIRIMADI { get {return Body().BIRIMADI;} }
            public TTReportField SAG { get {return Body().SAG;} }
            public TTReportField EPISODEID { get {return Body().EPISODEID;} }
            public TTReportField AYAKTANYATAN { get {return Body().AYAKTANYATAN;} }
            public TTReportField BIRIMADIYATAN { get {return Body().BIRIMADIYATAN;} }
            public TTReportField XXXXXXIL { get {return Body().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
            public TTReportField SINIF { get {return Body().SINIF;} }
            public TTReportField BIRTHINFO { get {return Body().BIRTHINFO;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField SINRUT { get {return Body().SINRUT;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField REFAKATCSEVK { get {return Body().REFAKATCSEVK;} }
            public TTReportField REFAKATCIILESEVK { get {return Body().REFAKATCIILESEVK;} }
            public TTReportField ONAY { get {return Body().ONAY;} }
            public TTReportField ONAYUNVAN { get {return Body().ONAYUNVAN;} }
            public TTReportField ONAYUNVAN2 { get {return Body().ONAYUNVAN2;} }
            public TTReportField QUARANTINEPROTOCOLNO { get {return Body().QUARANTINEPROTOCOLNO;} }
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
                list[0] = new TTReportNqlData<PersonnelConsignment.GetPersonnelConsignmentInfo_Class>("GetPersonnelConsignmentInfo", PersonnelConsignment.GetPersonnelConsignmentInfo((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PersonnelConsignmentReport MyParentReport
                {
                    get { return (PersonnelConsignmentReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField10;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField23;
                public TTReportShape NewLine;
                public TTReportField ACIKLAMA;
                public TTReportField KONU;
                public TTReportField BIRIMPRTNO;
                public TTReportField NewField32;
                public TTReportField NewField33;
                public TTReportField NewField34;
                public TTReportField NewField135;
                public TTReportField BIRLIK;
                public TTReportField XXXXXXSUBE;
                public TTReportField GONDERILEN;
                public TTReportField ACTIONID;
                public TTReportField ACTIONDATE2;
                public TTReportField NewField38;
                public TTReportShape NewLine3;
                public TTReportField REFFULLNAME;
                public TTReportField NewField41;
                public TTReportField NewField42;
                public TTReportField INPLACE;
                public TTReportField BIRIMADI;
                public TTReportField SAG;
                public TTReportField EPISODEID;
                public TTReportField AYAKTANYATAN;
                public TTReportField BIRIMADIYATAN;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField7;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField SURNAME;
                public TTReportField NAME;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField BIRTHINFO;
                public TTReportField FATHERNAME;
                public TTReportField SINRUT;
                public TTReportField FULLNAME;
                public TTReportField REFAKATCSEVK;
                public TTReportField REFAKATCIILESEVK;
                public TTReportField ONAY;
                public TTReportField ONAYUNVAN;
                public TTReportField ONAYUNVAN2;
                public TTReportField QUARANTINEPROTOCOLNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 153;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 32, 205, 36, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 109, 59, 113, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Sınıf ve Rütbesi";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 119, 59, 123, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Doğum Yeri ve Tarihi";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 104, 59, 108, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Adı Soyadı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 109, 61, 113, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 104, 61, 108, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 114, 59, 118, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"Baba Adı";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 119, 61, 123, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 114, 61, 118, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 98, 119, 102, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @"KİMLİĞİ                                     :";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 103, 109, 103, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 58, 210, 82, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Name = "Arial Narrow";
                    ACIKLAMA.Value = @"Aşağıda açık kimliği yazılı personelin {%BIRIMADI%}{%BIRIMADIYATAN%}'nde muayene ve tedavisi yapılmıştır.
Muayene ve tedavisi yapılan hasta ve refakatçisi için  {%XXXXXXIL%}-{%INPLACE%} arası yalnız gidiş personel sevk muhtırasının verilmesini arz ederim.";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 43, 161, 47, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Arial Narrow";
                    KONU.Value = @"KONU:Personel Sevk Muhtırası Verilmesi";

                    BIRIMPRTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 32, 246, 36, false);
                    BIRIMPRTNO.Name = "BIRIMPRTNO";
                    BIRIMPRTNO.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPRTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPRTNO.TextFont.Name = "Arial Narrow";
                    BIRIMPRTNO.TextFont.Size = 9;
                    BIRIMPRTNO.TextFont.Bold = true;
                    BIRIMPRTNO.Value = @"";

                    NewField32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 124, 59, 134, false);
                    NewField32.Name = "NewField32";
                    NewField32.TextFont.Name = "Arial Narrow";
                    NewField32.TextFont.Bold = true;
                    NewField32.Value = @"Birliği:";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 135, 59, 139, false);
                    NewField33.Name = "NewField33";
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.TextFont.Bold = true;
                    NewField33.Value = @"XXXXXXlik Şubesi";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 124, 61, 134, false);
                    NewField34.Name = "NewField34";
                    NewField34.TextFont.Name = "Arial Narrow";
                    NewField34.TextFont.Bold = true;
                    NewField34.Value = @":";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 135, 61, 139, false);
                    NewField135.Name = "NewField135";
                    NewField135.TextFont.Name = "Arial Narrow";
                    NewField135.TextFont.Bold = true;
                    NewField135.Value = @":";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 124, 167, 134, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.Value = @"";

                    XXXXXXSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 135, 167, 139, false);
                    XXXXXXSUBE.Name = "XXXXXXSUBE";
                    XXXXXXSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXSUBE.TextFont.Name = "Arial Narrow";
                    XXXXXXSUBE.Value = @"";

                    GONDERILEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 51, 194, 56, false);
                    GONDERILEN.Name = "GONDERILEN";
                    GONDERILEN.FieldType = ReportFieldTypeEnum.ftExpression;
                    GONDERILEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GONDERILEN.TextFont.Name = "Arial Narrow";
                    GONDERILEN.TextFont.Bold = true;
                    GONDERILEN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""PersonelSevkMuhtrasıGönderilenYer"", ""ULAŞTIRMA HAREKET KONTROL XXXXXXLIĞI"")";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 17, 240, 21, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.TextFont.Bold = true;
                    ACTIONID.Value = @"{#ID#}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 47, 243, 52, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.TextFont.Name = "Arial Narrow";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.TextFont.Bold = true;
                    ACTIONDATE2.Value = @"{#REQUESTDATE#}";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 140, 119, 144, false);
                    NewField38.Name = "NewField38";
                    NewField38.TextFont.Name = "Arial Narrow";
                    NewField38.TextFont.Bold = true;
                    NewField38.Value = @"REFAKATÇİSİ                                    :";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 145, 109, 145, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    REFFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 146, 167, 150, false);
                    REFFULLNAME.Name = "REFFULLNAME";
                    REFFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFFULLNAME.TextFont.Name = "Arial Narrow";
                    REFFULLNAME.Value = @"{#REFAKATCI#}";

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 146, 59, 150, false);
                    NewField41.Name = "NewField41";
                    NewField41.TextFont.Name = "Arial Narrow";
                    NewField41.TextFont.Bold = true;
                    NewField41.Value = @"Adı Soyadı";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 146, 61, 150, false);
                    NewField42.Name = "NewField42";
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.TextFont.Bold = true;
                    NewField42.Value = @":";

                    INPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 42, 243, 47, false);
                    INPLACE.Name = "INPLACE";
                    INPLACE.Visible = EvetHayirEnum.ehHayir;
                    INPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INPLACE.TextFont.Name = "Arial Narrow";
                    INPLACE.TextFont.Size = 9;
                    INPLACE.TextFont.Bold = true;
                    INPLACE.Value = @"{#GIDECEGIYER#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 11, 246, 15, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.TextFont.Name = "Arial Narrow";
                    BIRIMADI.TextFont.Size = 9;
                    BIRIMADI.TextFont.Bold = true;
                    BIRIMADI.Value = @"";

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 39, 176, 43, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.TextFont.Name = "Arial Narrow";
                    SAG.Value = @"";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 22, 240, 26, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.TextFont.Bold = true;
                    EPISODEID.Value = @"{#EPISODE#}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 27, 240, 31, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.Visible = EvetHayirEnum.ehHayir;
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.TextFont.Name = "Arial Narrow";
                    AYAKTANYATAN.TextFont.Size = 9;
                    AYAKTANYATAN.TextFont.Bold = true;
                    AYAKTANYATAN.Value = @"{#PATIENTSTATUS#}";

                    BIRIMADIYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 37, 246, 42, false);
                    BIRIMADIYATAN.Name = "BIRIMADIYATAN";
                    BIRIMADIYATAN.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADIYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADIYATAN.TextFont.Name = "Arial Narrow";
                    BIRIMADIYATAN.TextFont.Size = 9;
                    BIRIMADIYATAN.TextFont.Bold = true;
                    BIRIMADIYATAN.Value = @"{#TREATMENTCLINIC#}";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 23, 212, 29, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Name = "Arial Narrow";
                    XXXXXXIL.TextFont.Size = 12;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 6, 211, 29, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 11, 35, 17, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.Underline = true;
                    NewField7.Value = @"HİZMETE ÖZEL";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 131, 194, 135, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Medium Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Bold = true;
                    DTARIH.Value = @"{#PATIENTBIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 127, 194, 131, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Bold = true;
                    DYER.Value = @"{#PATIENTCITYOFBIRTH#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 123, 192, 127, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Arial Narrow";
                    SURNAME.TextFont.Bold = true;
                    SURNAME.Value = @"{#PATIENTSURNAME#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 119, 195, 123, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Bold = true;
                    NAME.Value = @"{#PATIENTNAME#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 114, 188, 119, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial Narrow";
                    RUTBE.TextFont.Bold = true;
                    RUTBE.Value = @"";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 109, 189, 114, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Name = "Arial Narrow";
                    SINIF.TextFont.Bold = true;
                    SINIF.Value = @"";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 119, 167, 123, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.TextFont.Name = "Arial Narrow";
                    BIRTHINFO.Value = @"{%DYER%} / {%DTARIH%}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 114, 167, 118, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 109, 167, 113, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.Value = @"{%SINIF%} {%RUTBE%}";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 104, 167, 108, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Arial Narrow";
                    FULLNAME.Value = @"{%NAME%} {%SURNAME%}";

                    REFAKATCSEVK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 40, 211, 44, false);
                    REFAKATCSEVK.Name = "REFAKATCSEVK";
                    REFAKATCSEVK.Visible = EvetHayirEnum.ehHayir;
                    REFAKATCSEVK.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCSEVK.TextFont.Name = "Arial Narrow";
                    REFAKATCSEVK.TextFont.Size = 9;
                    REFAKATCSEVK.TextFont.Bold = true;
                    REFAKATCSEVK.Value = @"{#REFAKATCSEVK#}";

                    REFAKATCIILESEVK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 44, 211, 48, false);
                    REFAKATCIILESEVK.Name = "REFAKATCIILESEVK";
                    REFAKATCIILESEVK.Visible = EvetHayirEnum.ehHayir;
                    REFAKATCIILESEVK.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCIILESEVK.TextFont.Name = "Arial Narrow";
                    REFAKATCIILESEVK.TextFont.Size = 9;
                    REFAKATCIILESEVK.TextFont.Bold = true;
                    REFAKATCIILESEVK.Value = @"{#REFAKATCIILESEVK#}";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 83, 210, 88, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.Value = @"";

                    ONAYUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 88, 210, 93, false);
                    ONAYUNVAN.Name = "ONAYUNVAN";
                    ONAYUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAYUNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.NoClip = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.TextFont.Name = "Arial Narrow";
                    ONAYUNVAN.TextFont.Size = 9;
                    ONAYUNVAN.Value = @"";

                    ONAYUNVAN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 93, 210, 98, false);
                    ONAYUNVAN2.Name = "ONAYUNVAN2";
                    ONAYUNVAN2.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.NoClip = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.TextFont.Name = "Arial Narrow";
                    ONAYUNVAN2.TextFont.Size = 9;
                    ONAYUNVAN2.Value = @"";

                    QUARANTINEPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 53, 246, 57, false);
                    QUARANTINEPROTOCOLNO.Name = "QUARANTINEPROTOCOLNO";
                    QUARANTINEPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEPROTOCOLNO.TextFont.Name = "Arial Narrow";
                    QUARANTINEPROTOCOLNO.TextFont.Size = 9;
                    QUARANTINEPROTOCOLNO.TextFont.Bold = true;
                    QUARANTINEPROTOCOLNO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PersonnelConsignment.GetPersonnelConsignmentInfo_Class dataset_GetPersonnelConsignmentInfo = ParentGroup.rsGroup.GetCurrentRecord<PersonnelConsignment.GetPersonnelConsignmentInfo_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.ActionDate) : "");
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField23.CalcValue = NewField23.Value;
                    BIRIMADI.CalcValue = @"";
                    BIRIMADIYATAN.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Treatmentclinic) : "");
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    INPLACE.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Gidecegiyer) : "");
                    ACIKLAMA.CalcValue = @"Aşağıda açık kimliği yazılı personelin " + MyParentReport.MAIN.BIRIMADI.CalcValue + MyParentReport.MAIN.BIRIMADIYATAN.CalcValue + @"'nde muayene ve tedavisi yapılmıştır.
Muayene ve tedavisi yapılan hasta ve refakatçisi için  " + MyParentReport.MAIN.XXXXXXIL.CalcValue + @"-" + MyParentReport.MAIN.INPLACE.CalcValue + @" arası yalnız gidiş personel sevk muhtırasının verilmesini arz ederim.";
                    KONU.CalcValue = @"KONU:Personel Sevk Muhtırası Verilmesi";
                    BIRIMPRTNO.CalcValue = @"";
                    NewField32.CalcValue = NewField32.Value;
                    NewField33.CalcValue = NewField33.Value;
                    NewField34.CalcValue = NewField34.Value;
                    NewField135.CalcValue = NewField135.Value;
                    BIRLIK.CalcValue = @"";
                    XXXXXXSUBE.CalcValue = @"";
                    ACTIONID.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.ID) : "");
                    ACTIONDATE2.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.RequestDate) : "");
                    NewField38.CalcValue = NewField38.Value;
                    REFFULLNAME.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Refakatci) : "");
                    NewField41.CalcValue = NewField41.Value;
                    NewField42.CalcValue = NewField42.Value;
                    SAG.CalcValue = @"";
                    EPISODEID.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Episode) : "");
                    AYAKTANYATAN.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.PatientStatus) : "");
                    NewField7.CalcValue = NewField7.Value;
                    DTARIH.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Patientbirthdate) : "");
                    DYER.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Patientcityofbirth) : "");
                    SURNAME.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Patientsurname) : "");
                    NAME.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Patientname) : "");
                    RUTBE.CalcValue = @"";
                    SINIF.CalcValue = @"";
                    BIRTHINFO.CalcValue = MyParentReport.MAIN.DYER.CalcValue + @" / " + MyParentReport.MAIN.DTARIH.FormattedValue;
                    FATHERNAME.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.FatherName) : "");
                    SINRUT.CalcValue = MyParentReport.MAIN.SINIF.CalcValue + @" " + MyParentReport.MAIN.RUTBE.CalcValue;
                    FULLNAME.CalcValue = MyParentReport.MAIN.NAME.CalcValue + @" " + MyParentReport.MAIN.SURNAME.CalcValue;
                    REFAKATCSEVK.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Refakatcsevk) : "");
                    REFAKATCIILESEVK.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.Refakatciilesevk) : "");
                    ONAY.CalcValue = @"";
                    ONAYUNVAN.CalcValue = @"";
                    ONAYUNVAN2.CalcValue = ONAYUNVAN2.Value;
                    QUARANTINEPROTOCOLNO.CalcValue = (dataset_GetPersonnelConsignmentInfo != null ? Globals.ToStringCore(dataset_GetPersonnelConsignmentInfo.QuarantineProtocolNo) : "");
                    GONDERILEN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("PersonelSevkMuhtrasıGönderilenYer", "ULAŞTIRMA HAREKET KONTROL XXXXXXLIĞI");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { ACTIONDATE,NewField4,NewField5,NewField10,NewField12,NewField13,NewField14,NewField17,NewField18,NewField23,BIRIMADI,BIRIMADIYATAN,XXXXXXIL,INPLACE,ACIKLAMA,KONU,BIRIMPRTNO,NewField32,NewField33,NewField34,NewField135,BIRLIK,XXXXXXSUBE,ACTIONID,ACTIONDATE2,NewField38,REFFULLNAME,NewField41,NewField42,SAG,EPISODEID,AYAKTANYATAN,NewField7,DTARIH,DYER,SURNAME,NAME,RUTBE,SINIF,BIRTHINFO,FATHERNAME,SINRUT,FULLNAME,REFAKATCSEVK,REFAKATCIILESEVK,ONAY,ONAYUNVAN,ONAYUNVAN2,QUARANTINEPROTOCOLNO,GONDERILEN,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION","HEADDOCTOR") == "IITABIP")
            {
                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIP","").ToString();
                this.ONAYUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IITABIPUNVANI","").ToString();
                this.ONAYUNVAN2.CalcValue = "II.Tabip";
                
            }
            else
            {
                this.ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","").ToString();
                this.ONAYUNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL","").ToString();
                this.ONAYUNVAN2.CalcValue = "Baştabip";
            }
            
            IList<PatientExamination> patientExaminationList = (IList<PatientExamination>)PatientExamination.GetPatientExaminationByEpisode(this.ParentReport.ReportObjectContext, this.EPISODEID.CalcValue.ToString());
            foreach (PatientExamination pa in patientExaminationList)
            {
                this.BIRIMADI.CalcValue = pa.MasterResource.Name.ToString();
                if (this.AYAKTANYATAN.CalcValue == "0")
                    this.BIRIMPRTNO.CalcValue = pa.ProtocolNo.ToString();
                
            }
            string tedaviBirimi = "";
            if (this.AYAKTANYATAN.CalcValue == "0")
            {
                tedaviBirimi = this.BIRIMADIYATAN.CalcValue;
            }
            else
            {
                tedaviBirimi = this.BIRIMADI.CalcValue;
            }

            if(this.REFAKATCSEVK.CalcValue=="0" && this.REFAKATCIILESEVK.CalcValue=="0" )
            {
                this.ACIKLAMA.CalcValue = "Aşağıda açık kimliği yazılı personelin " + tedaviBirimi + "'nde muayene ve tedavisi yapılmıştır.\r\n" +
                    "Bir (1) er için " + this.XXXXXXIL.CalcValue.ToString() + "-" + this.INPLACE.CalcValue.ToString() + " arası yalnız gidiş personel sevk muhtırasının verilmesini arz/rica ederim.";
            }
            else if(this.REFAKATCSEVK.CalcValue=="1")
            {
                this.ACIKLAMA.CalcValue = "Aşağıda açık kimliği yazılı personel " + this.BIRIMADI + "'nde yapılan muayene ve tedavisi sonucu " + tedaviBirimi + "'ne yatırılmıştır.\r\n" +
                    "Hastahanemize yatışı yapılan hastanın aşağıda açık kimliği yazılı refakatçisi için " + this.XXXXXXIL.CalcValue.ToString() + "-" + this.INPLACE.CalcValue.ToString() + " arası yalnız gidiş personel sevk muhtırasının verilmesini arz/rica ederim.";
            }
            else if(this.REFAKATCIILESEVK.CalcValue=="1")
            {
                this.ACIKLAMA.CalcValue = "Aşağıda açık kimliği yazılı personelin " + tedaviBirimi + "'nde muayene ve tedavisi yapılmıştır.\r\n" +
                    "Muayene ve tedavisi yapılan hasta ve refakatçisi için  " + this.XXXXXXIL.CalcValue.ToString() + "-" + this.INPLACE.CalcValue.ToString() + " arası yalnız gidiş personel sevk muhtırasının verilmesini arz/rica ederim.";
            }
            
            
            if(String.IsNullOrEmpty(this.QUARANTINEPROTOCOLNO.CalcValue))
                this.SAG.CalcValue = "PER :9013-..........-" +  Convert.ToDateTime(this.ACTIONDATE2.CalcValue).Year.ToString().Substring(2) +  "/" + this.BIRIMADI.CalcValue + this.BIRIMADIYATAN.CalcValue + "-(" + this.ACTIONID.CalcValue + ")";
            else
                this.SAG.CalcValue = "PER :9013-" + this.QUARANTINEPROTOCOLNO.CalcValue + "-" + Convert.ToDateTime(this.ACTIONDATE2.CalcValue).Year.ToString().Substring(2) +  "/" + this.BIRIMADI.CalcValue + this.BIRIMADIYATAN.CalcValue + "-(" + this.ACTIONID.CalcValue + ")";
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

        public PersonnelConsignmentReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Personel Sevk Muhtırası İşlemi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PERSONNELCONSIGNMENTREPORT";
            Caption = "Personel Sevk Muhtırası ";
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