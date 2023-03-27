
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
    /// Dış XXXXXX Konsültasyon İstek Raporu
    /// </summary>
    public partial class ConsultationFromOtherHospitalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TOPHEADERGroup : TTReportGroup
        {
            public ConsultationFromOtherHospitalReport MyParentReport
            {
                get { return (ConsultationFromOtherHospitalReport)ParentReport; }
            }

            new public TOPHEADERGroupHeader Header()
            {
                return (TOPHEADERGroupHeader)_header;
            }

            new public TOPHEADERGroupFooter Footer()
            {
                return (TOPHEADERGroupFooter)_footer;
            }

            public TTReportField DATE1 { get {return Header().DATE1;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField BASLIK1 { get {return Header().BASLIK1;} }
            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TOPHEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TOPHEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TOPHEADERGroupHeader(this);
                _footer = new TOPHEADERGroupFooter(this);

            }

            public partial class TOPHEADERGroupHeader : TTReportSection
            {
                public ConsultationFromOtherHospitalReport MyParentReport
                {
                    get { return (ConsultationFromOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField DATE1;
                public TTReportField NewField102;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField BASLIK1; 
                public TOPHEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 38, 207, 42, false);
                    DATE1.Name = "DATE1";
                    DATE1.FieldType = ReportFieldTypeEnum.ftExpression;
                    DATE1.TextFormat = @"Short Date";
                    DATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE1.TextFont.Name = "Arial Narrow";
                    DATE1.TextFont.Size = 9;
                    DATE1.Value = @"TTObjectClasses.Common.RecTime().ToString()";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 37, 13, false);
                    NewField102.Name = "NewField102";
                    NewField102.TextFont.Name = "Arial Narrow";
                    NewField102.TextFont.Size = 11;
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.Underline = true;
                    NewField102.Value = @"HİZMETE ÖZEL";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 7, 183, 29, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    BASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 30, 183, 37, false);
                    BASLIK1.Name = "BASLIK1";
                    BASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    BASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1.TextFont.Name = "Arial Narrow";
                    BASLIK1.TextFont.Size = 15;
                    BASLIK1.TextFont.Bold = true;
                    BASLIK1.Value = @"DİĞER XXXXXXLERDEN KONSÜLTASYON İSTEK RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField102.CalcValue = NewField102.Value;
                    BASLIK1.CalcValue = BASLIK1.Value;
                    DATE1.CalcValue = TTObjectClasses.Common.RecTime().ToString();
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField102,BASLIK1,DATE1,XXXXXXBASLIK1};
                }
            }
            public partial class TOPHEADERGroupFooter : TTReportSection
            {
                public ConsultationFromOtherHospitalReport MyParentReport
                {
                    get { return (ConsultationFromOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public TOPHEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 36, 8, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.TextFont.Name = "Arial Narrow";
                    HizmetOzel.TextFont.Size = 11;
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 205, 2, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 8, 205, 13, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 3, 205, 8, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UserName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 5, 121, 10, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel,PrintDate,PageNumber,UserName};
                }
            }

        }

        public TOPHEADERGroup TOPHEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public ConsultationFromOtherHospitalReport MyParentReport
            {
                get { return (ConsultationFromOtherHospitalReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField SAG { get {return Header().SAG;} }
            public TTReportField BIRIMPROTOKOL { get {return Header().BIRIMPROTOKOL;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField RUTBE { get {return Header().RUTBE;} }
            public TTReportField SINIF { get {return Header().SINIF;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField EVRAKSAYISI { get {return Header().EVRAKSAYISI;} }
            public TTReportField EVRAKTARIHI { get {return Header().EVRAKTARIHI;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField FULLSINIFRUTBE { get {return Header().FULLSINIFRUTBE;} }
            public TTReportField NewField40 { get {return Header().NewField40;} }
            public TTReportField NewField30 { get {return Header().NewField30;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField34 { get {return Header().NewField34;} }
            public TTReportField GIDECEGIYER { get {return Header().GIDECEGIYER;} }
            public TTReportField GIDECEGIBIRIM { get {return Header().GIDECEGIBIRIM;} }
            public TTReportField ACTIONDATE2 { get {return Header().ACTIONDATE2;} }
            public TTReportField GRUP_KHDJ { get {return Header().GRUP_KHDJ;} }
            public TTReportField DAGITIM { get {return Header().DAGITIM;} }
            public TTReportField GIDYER_KOD { get {return Header().GIDYER_KOD;} }
            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField NewField33 { get {return Header().NewField33;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField REQUESTEDHOSPITALNAME { get {return Header().REQUESTEDHOSPITALNAME;} }
            public TTReportField REQUESTEDDEPARTMENTNAME { get {return Header().REQUESTEDDEPARTMENTNAME;} }
            public TTReportField REQUESTEDEXTERNALHOSPITALNAME { get {return Header().REQUESTEDEXTERNALHOSPITALNAME;} }
            public TTReportField REQUESTEDEXTERNALDEPARTMENTNAME { get {return Header().REQUESTEDEXTERNALDEPARTMENTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PREDIAGNOSIS { get {return Header().PREDIAGNOSIS;} }
            public TTReportField ONAY { get {return Header().ONAY;} }
            public TTReportField ONAYUNVAN { get {return Header().ONAYUNVAN;} }
            public TTReportField ONAYUNVAN2 { get {return Header().ONAYUNVAN2;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public NOTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>("GetConsultationFromOtherHospitalInfo", ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTGroupHeader(this);
                _footer = new NOTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NOTGroupHeader : TTReportSection
            {
                public ConsultationFromOtherHospitalReport MyParentReport
                {
                    get { return (ConsultationFromOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField SAG;
                public TTReportField BIRIMPROTOKOL;
                public TTReportField RAPORNO;
                public TTReportField KONU;
                public TTReportField BIRIMADI;
                public TTReportField DYERVETARIH;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField MAKAM;
                public TTReportField EVRAKSAYISI;
                public TTReportField EVRAKTARIHI;
                public TTReportField ACTIONID;
                public TTReportField FULLSINIFRUTBE;
                public TTReportField NewField40;
                public TTReportField NewField30;
                public TTReportField BIRLIK;
                public TTReportField NewField34;
                public TTReportField GIDECEGIYER;
                public TTReportField GIDECEGIBIRIM;
                public TTReportField ACTIONDATE2;
                public TTReportField GRUP_KHDJ;
                public TTReportField DAGITIM;
                public TTReportField GIDYER_KOD;
                public TTReportField SAYMANLIK;
                public TTReportField NewField33;
                public TTReportShape NewLine13;
                public TTReportField NewField141;
                public TTReportField NewField143;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField131;
                public TTReportField REQUESTEDHOSPITALNAME;
                public TTReportField REQUESTEDDEPARTMENTNAME;
                public TTReportField REQUESTEDEXTERNALHOSPITALNAME;
                public TTReportField REQUESTEDEXTERNALDEPARTMENTNAME;
                public TTReportField NewField1;
                public TTReportShape NewLine1;
                public TTReportField PREDIAGNOSIS;
                public TTReportField ONAY;
                public TTReportField ONAYUNVAN;
                public TTReportField ONAYUNVAN2; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 119;
                    RepeatCount = 0;
                    
                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 206, 6, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.TextFont.Name = "Arial Narrow";
                    SAG.TextFont.Size = 9;
                    SAG.Value = @"SAĞ:9036-{%BIRIMPROTOKOL%}-{%ACTIONDATE2%}/{%BIRIMADI%}-{%ACTIONID%}";

                    BIRIMPROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 42, 34, 46, false);
                    BIRIMPROTOKOL.Name = "BIRIMPROTOKOL";
                    BIRIMPROTOKOL.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPROTOKOL.TextFont.Name = "Arial Narrow";
                    BIRIMPROTOKOL.TextFont.Size = 9;
                    BIRIMPROTOKOL.Value = @"{#PROTOCOLNO#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 31, 254, 35, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.Visible = EvetHayirEnum.ehHayir;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial";
                    RAPORNO.TextFont.Size = 9;
                    RAPORNO.Value = @"";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 206, 10, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Arial Narrow";
                    KONU.TextFont.Size = 9;
                    KONU.Value = @"KONU:Tıbbi Konsültasyon";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 42, 64, 46, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.TextFont.Name = "Arial";
                    BIRIMADI.TextFont.Size = 9;
                    BIRIMADI.Value = @"{#FROMRESOURCENAME#}";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 98, 207, 102, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial Narrow";
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.Value = @" {%DYER%} / {%DTARIH%}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 83, 57, 87, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"Sınıf ve Rütbesi";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 98, 57, 102, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 93, 207, 97, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.TextFont.Name = "Arial Narrow";
                    BABAAD.TextFont.Size = 9;
                    BABAAD.Value = @" {#FATHERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 78, 207, 82, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @" {#PATIENTNAME#} {#PATIENTSURNAME#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 78, 57, 82, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Adı Soyadı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 83, 60, 87, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 78, 60, 82, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 93, 57, 97, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Baba Adı";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 55, 242, 59, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.Visible = EvetHayirEnum.ehHayir;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Name = "Arial";
                    SINIFRUTBE.TextFont.Size = 9;
                    SINIFRUTBE.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 98, 60, 102, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 93, 60, 97, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 47, 254, 51, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.Value = @"";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 39, 254, 43, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Name = "Arial";
                    SINIF.TextFont.Size = 9;
                    SINIF.Value = @"";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 42, 90, 46, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#PATIENTBIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 46, 60, 50, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.ObjectDefName = "City";
                    DYER.DataMember = "NAME";
                    DYER.TextFont.Name = "Arial";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#PATIENTCITYOFBIRTH#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 43, 238, 47, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Name = "Arial";
                    MAKAM.TextFont.Size = 9;
                    MAKAM.Value = @"";

                    EVRAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 51, 244, 55, false);
                    EVRAKSAYISI.Name = "EVRAKSAYISI";
                    EVRAKSAYISI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKSAYISI.TextFont.Name = "Arial";
                    EVRAKSAYISI.TextFont.Size = 9;
                    EVRAKSAYISI.Value = @"";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 35, 244, 39, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFont.Name = "Arial";
                    EVRAKTARIHI.TextFont.Size = 9;
                    EVRAKTARIHI.Value = @"";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 46, 34, 50, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ID#}";

                    FULLSINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 83, 207, 87, false);
                    FULLSINIFRUTBE.Name = "FULLSINIFRUTBE";
                    FULLSINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLSINIFRUTBE.TextFont.Name = "Arial Narrow";
                    FULLSINIFRUTBE.TextFont.Size = 9;
                    FULLSINIFRUTBE.Value = @"";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 207, 41, false);
                    NewField40.Name = "NewField40";
                    NewField40.MultiLine = EvetHayirEnum.ehEvet;
                    NewField40.NoClip = EvetHayirEnum.ehEvet;
                    NewField40.WordBreak = EvetHayirEnum.ehEvet;
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.TextFont.Size = 9;
                    NewField40.Value = @"Aşağıda açık kimliği yazılı personelin muayenesinin yapılarak sonucun bildirilmesini arz/rica ederim.";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 67, 58, 71, false);
                    NewField30.Name = "NewField30";
                    NewField30.TextFont.Name = "Arial Narrow";
                    NewField30.TextFont.Size = 9;
                    NewField30.TextFont.Bold = true;
                    NewField30.Value = @"Kimliği";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 88, 207, 92, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 88, 57, 92, false);
                    NewField34.Name = "NewField34";
                    NewField34.TextFont.Name = "Arial Narrow";
                    NewField34.TextFont.Size = 9;
                    NewField34.TextFont.Bold = true;
                    NewField34.Value = @"Birliği";

                    GIDECEGIYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 207, 23, false);
                    GIDECEGIYER.Name = "GIDECEGIYER";
                    GIDECEGIYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDECEGIYER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GIDECEGIYER.TextFont.Name = "Arial Narrow";
                    GIDECEGIYER.TextFont.Size = 9;
                    GIDECEGIYER.TextFont.Bold = true;
                    GIDECEGIYER.Value = @"";

                    GIDECEGIBIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 23, 207, 28, false);
                    GIDECEGIBIRIM.Name = "GIDECEGIBIRIM";
                    GIDECEGIBIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDECEGIBIRIM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GIDECEGIBIRIM.TextFont.Name = "Arial Narrow";
                    GIDECEGIBIRIM.TextFont.Size = 9;
                    GIDECEGIBIRIM.TextFont.Bold = true;
                    GIDECEGIBIRIM.Value = @"";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 12, 125, 17, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"yy";
                    ACTIONDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIONDATE2.TextFont.Name = "Arial Narrow";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.Value = @"{#ACTIONDATE#}";

                    GRUP_KHDJ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 50, 45, 54, false);
                    GRUP_KHDJ.Name = "GRUP_KHDJ";
                    GRUP_KHDJ.Visible = EvetHayirEnum.ehHayir;
                    GRUP_KHDJ.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRUP_KHDJ.MultiLine = EvetHayirEnum.ehEvet;
                    GRUP_KHDJ.TextFont.Name = "Arial Narrow";
                    GRUP_KHDJ.TextFont.Size = 9;
                    GRUP_KHDJ.Value = @"";

                    DAGITIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 55, 84, 61, false);
                    DAGITIM.Name = "DAGITIM";
                    DAGITIM.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM.TextFont.Name = "Arial Narrow";
                    DAGITIM.TextFont.Size = 9;
                    DAGITIM.TextFont.Bold = true;
                    DAGITIM.TextFont.Underline = true;
                    DAGITIM.Value = @"Dağıtım                                                :";

                    GIDYER_KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 59, 254, 63, false);
                    GIDYER_KOD.Name = "GIDYER_KOD";
                    GIDYER_KOD.Visible = EvetHayirEnum.ehHayir;
                    GIDYER_KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDYER_KOD.MultiLine = EvetHayirEnum.ehEvet;
                    GIDYER_KOD.TextFont.Name = "Arial";
                    GIDYER_KOD.TextFont.Size = 9;
                    GIDYER_KOD.Value = @"";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 62, 207, 66, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.Visible = EvetHayirEnum.ehHayir;
                    SAYMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIK.TextFont.Name = "Arial Narrow";
                    SAYMANLIK.TextFont.Size = 9;
                    SAYMANLIK.Value = @"";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 88, 60, 92, false);
                    NewField33.Name = "NewField33";
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.TextFont.Size = 9;
                    NewField33.TextFont.Bold = true;
                    NewField33.Value = @":";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 71, 60, 71, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 67, 60, 71, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 115, 60, 119, false);
                    NewField143.Name = "NewField143";
                    NewField143.TextFont.Name = "Arial Narrow";
                    NewField143.TextFont.Size = 9;
                    NewField143.TextFont.Bold = true;
                    NewField143.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 73, 207, 77, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 73, 57, 77, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 73, 60, 77, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial Narrow";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    REQUESTEDHOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 65, 262, 70, false);
                    REQUESTEDHOSPITALNAME.Name = "REQUESTEDHOSPITALNAME";
                    REQUESTEDHOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    REQUESTEDHOSPITALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDHOSPITALNAME.TextFont.Name = "Arial Narrow";
                    REQUESTEDHOSPITALNAME.Value = @"{#REQUESTEDHOSPITALNAME#}";

                    REQUESTEDDEPARTMENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 71, 262, 76, false);
                    REQUESTEDDEPARTMENTNAME.Name = "REQUESTEDDEPARTMENTNAME";
                    REQUESTEDDEPARTMENTNAME.Visible = EvetHayirEnum.ehHayir;
                    REQUESTEDDEPARTMENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDDEPARTMENTNAME.TextFont.Name = "Arial Narrow";
                    REQUESTEDDEPARTMENTNAME.Value = @"{#REQUESTEDDEPARTMENTNAME#}";

                    REQUESTEDEXTERNALHOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 77, 262, 82, false);
                    REQUESTEDEXTERNALHOSPITALNAME.Name = "REQUESTEDEXTERNALHOSPITALNAME";
                    REQUESTEDEXTERNALHOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    REQUESTEDEXTERNALHOSPITALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDEXTERNALHOSPITALNAME.TextFont.Name = "Arial Narrow";
                    REQUESTEDEXTERNALHOSPITALNAME.Value = @"{#REQUESTEDEXTERNALHOSPITALNAME#}";

                    REQUESTEDEXTERNALDEPARTMENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 83, 262, 88, false);
                    REQUESTEDEXTERNALDEPARTMENTNAME.Name = "REQUESTEDEXTERNALDEPARTMENTNAME";
                    REQUESTEDEXTERNALDEPARTMENTNAME.Visible = EvetHayirEnum.ehHayir;
                    REQUESTEDEXTERNALDEPARTMENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDEXTERNALDEPARTMENTNAME.TextFont.Name = "Arial Narrow";
                    REQUESTEDEXTERNALDEPARTMENTNAME.Value = @"{#REQUESTEDEXTERNALDEPTNAME#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 103, 58, 107, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Ön Tanı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 107, 60, 107, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 108, 207, 119, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    PREDIAGNOSIS.TextFont.Size = 9;
                    PREDIAGNOSIS.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 43, 204, 48, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.Value = @"";

                    ONAYUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 48, 204, 53, false);
                    ONAYUNVAN.Name = "ONAYUNVAN";
                    ONAYUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAYUNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.NoClip = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYUNVAN.TextFont.Name = "Arial Narrow";
                    ONAYUNVAN.TextFont.Size = 9;
                    ONAYUNVAN.Value = @"";

                    ONAYUNVAN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 53, 204, 58, false);
                    ONAYUNVAN2.Name = "ONAYUNVAN2";
                    ONAYUNVAN2.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.NoClip = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYUNVAN2.TextFont.Name = "Arial Narrow";
                    ONAYUNVAN2.TextFont.Size = 9;
                    ONAYUNVAN2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class dataset_GetConsultationFromOtherHospitalInfo = ParentGroup.rsGroup.GetCurrentRecord<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>(0);
                    BIRIMPROTOKOL.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.ProtocolNo) : "");
                    ACTIONDATE2.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.ActionDate) : "");
                    BIRIMADI.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Fromresourcename) : "");
                    ACTIONID.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.ID) : "");
                    SAG.CalcValue = @"SAĞ:9036-" + MyParentReport.NOT.BIRIMPROTOKOL.CalcValue + @"-" + MyParentReport.NOT.ACTIONDATE2.FormattedValue + @"/" + MyParentReport.NOT.BIRIMADI.CalcValue + @"-" + MyParentReport.NOT.ACTIONID.CalcValue;
                    RAPORNO.CalcValue = @"";
                    KONU.CalcValue = @"KONU:Tıbbi Konsültasyon";
                    DYER.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Patientcityofbirth) : "");
                    DYER.PostFieldValueCalculation();
                    DTARIH.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Patientbirthdate) : "");
                    DYERVETARIH.CalcValue = @" " + MyParentReport.NOT.DYER.CalcValue + @" / " + MyParentReport.NOT.DTARIH.FormattedValue;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    BABAAD.CalcValue = @" " + (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.FatherName) : "");
                    ADSOYAD.CalcValue = @" " + (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Patientname) : "") + @" " + (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Patientsurname) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    RUTBE.CalcValue = @"";
                    SINIF.CalcValue = @"";
                    MAKAM.CalcValue = @"";
                    EVRAKSAYISI.CalcValue = @"";
                    EVRAKTARIHI.CalcValue = @"";
                    FULLSINIFRUTBE.CalcValue = @"";
                    NewField40.CalcValue = NewField40.Value;
                    NewField30.CalcValue = NewField30.Value;
                    BIRLIK.CalcValue = @"";
                    NewField34.CalcValue = NewField34.Value;
                    GIDECEGIYER.CalcValue = @"";
                    GIDECEGIBIRIM.CalcValue = @"";
                    GRUP_KHDJ.CalcValue = @"";
                    DAGITIM.CalcValue = DAGITIM.Value;
                    GIDYER_KOD.CalcValue = @"";
                    SAYMANLIK.CalcValue = @"";
                    NewField33.CalcValue = NewField33.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField143.CalcValue = NewField143.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField131.CalcValue = NewField131.Value;
                    REQUESTEDHOSPITALNAME.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Requestedhospitalname) : "");
                    REQUESTEDDEPARTMENTNAME.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Requesteddepartmentname) : "");
                    REQUESTEDEXTERNALHOSPITALNAME.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Requestedexternalhospitalname) : "");
                    REQUESTEDEXTERNALDEPARTMENTNAME.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Requestedexternaldeptname) : "");
                    NewField1.CalcValue = NewField1.Value;
                    PREDIAGNOSIS.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    ONAYUNVAN.CalcValue = @"";
                    ONAYUNVAN2.CalcValue = ONAYUNVAN2.Value;
                    return new TTReportObject[] { BIRIMPROTOKOL,ACTIONDATE2,BIRIMADI,ACTIONID,SAG,RAPORNO,KONU,DYER,DTARIH,DYERVETARIH,NewField8,NewField9,BABAAD,ADSOYAD,NewField12,NewField13,NewField14,NewField15,SINIFRUTBE,NewField17,NewField18,RUTBE,SINIF,MAKAM,EVRAKSAYISI,EVRAKTARIHI,FULLSINIFRUTBE,NewField40,NewField30,BIRLIK,NewField34,GIDECEGIYER,GIDECEGIBIRIM,GRUP_KHDJ,DAGITIM,GIDYER_KOD,SAYMANLIK,NewField33,NewField141,NewField143,UNIQUEREFNO,LBLUNIQUEREFNO,NewField131,REQUESTEDHOSPITALNAME,REQUESTEDDEPARTMENTNAME,REQUESTEDEXTERNALHOSPITALNAME,REQUESTEDEXTERNALDEPARTMENTNAME,NewField1,PREDIAGNOSIS,ONAY,ONAYUNVAN,ONAYUNVAN2};
                }

                public override void RunScript()
                {
#region NOT HEADER_Script
                    int cnt = 1;
            TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationFromOtherHospitalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationFromOtherHospital consultationFromOtherHospital = (ConsultationFromOtherHospital)objectContext.GetObject(new Guid(objectID),"ConsultationFromOtherHospital");
            if (consultationFromOtherHospital==null)
                throw new Exception("Rapor Dış XXXXXXlerden Konsültasyon modülü üzerinden alınmalıdır.");
            Episode episode = consultationFromOtherHospital.Episode;
            
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
            
            this.PREDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> preDiagnosis = null;
            preDiagnosis = DiagnosisGrid.GetPreDiagnosisByEpisodeAction(consultationFromOtherHospital.ObjectID.ToString());
            foreach(DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class preDiagnosisGrid in preDiagnosis)
            {
                this.PREDIAGNOSIS.CalcValue += cnt + ". " + preDiagnosisGrid.Code + " " + preDiagnosisGrid.Diagnosename;
                this.PREDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "").ToString();
            /*if (((ConsultationFromOtherHospitalReport)ParentReport).CurrentCopy != 1)
            {
                if (consultationFromOtherHospital.RequestedReferableHospital != null)
                {
                    Accountancy acc = AccountancyMatchingDefinition.GetAccountancy(objectContext,consultationFromOtherHospital.Episode.ForcesCommand,(ResSection)consultationFromOtherHospital.RequestedReferableHospital.ResOtherHospital);
                    if (acc != null)
                    {
                        this.SAYMANLIK.CalcValue = acc.Name + "' nca ödenecektir.";
                        this.DAGITIM.Visible = EvetHayirEnum.ehEvet;
                        this.SAYMANLIK.Visible = EvetHayirEnum.ehEvet;
                    }
                }
            }*/
            
            if (consultationFromOtherHospital.Episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = " " + consultationFromOtherHospital.Episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hastalar)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = " " + consultationFromOtherHospital.Episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
            
            if (consultationFromOtherHospital.RequestedReferableHospital != null)
                this.GIDECEGIYER.CalcValue = this.REQUESTEDHOSPITALNAME.CalcValue;
            if (consultationFromOtherHospital.RequestedReferableResource != null)
                this.GIDECEGIBIRIM.CalcValue = this.REQUESTEDDEPARTMENTNAME.CalcValue;
            if (consultationFromOtherHospital.RequestedExternalHospital != null)
                this.GIDECEGIYER.CalcValue = this.REQUESTEDEXTERNALHOSPITALNAME.CalcValue;
            if (consultationFromOtherHospital.RequestedExternalDepartment != null)
                this.GIDECEGIBIRIM.CalcValue = this.REQUESTEDEXTERNALDEPARTMENTNAME.CalcValue;
#endregion NOT HEADER_Script
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public ConsultationFromOtherHospitalReport MyParentReport
                {
                    get { return (ConsultationFromOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField UZMANLIKDAL;
                public TTReportField DIPSICLABEL;
                public TTReportField SINRUT;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField UZ;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 83, 6, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"İstek Yapan Tabip";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 14, 83, 18, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 83, 10, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 4, 297, 8, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 32, 18, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 83, 14, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 8, 244, 12, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 3, 270, 8, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#DOCMILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 83, 22, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 3, 244, 8, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 12, 298, 16, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 8, 297, 12, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 12, 244, 16, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 8, 270, 13, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 13, 271, 17, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class dataset_GetConsultationFromOtherHospitalInfo = ParentGroup.rsGroup.GetCurrentRecord<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>(0);
                    NewField10.CalcValue = NewField10.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.NOT.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Docemploymentrecordid) : "");
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField10,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    if(this.SICILKULLAN.CalcValue=="TRUE")
            {
                this.DIPSICLABEL.CalcValue= "SİCİL NO :";
                this.DIPSIC.CalcValue=this.SICILNO.CalcValue;
            }
            else
            {
                this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
                this.DIPSIC.CalcValue=this.DIPLOMANO.CalcValue;
            }
            

            if(this.UNVANKULLAN.CalcValue!="TRUE")
            {
                this.SINRUT.CalcValue=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
            }
            else
            {
                if(this.UNVAN.CalcValue=="")
                {
                    this.SINRUT.Value=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
                else
                {
                    this.SINRUT.CalcValue=this.UNVAN.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
                
            }
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class MAINGroup : TTReportGroup
        {
            public ConsultationFromOtherHospitalReport MyParentReport
            {
                get { return (ConsultationFromOtherHospitalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ANAMNEZ { get {return Body().ANAMNEZ;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportField NewField1341 { get {return Body().NewField1341;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public ConsultationFromOtherHospitalReport MyParentReport
                {
                    get { return (ConsultationFromOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField ANAMNEZ;
                public TTReportField NewField1;
                public TTReportShape NewLine;
                public TTReportField NewField1341; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    ANAMNEZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 205, 15, false);
                    ANAMNEZ.Name = "ANAMNEZ";
                    ANAMNEZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANAMNEZ.MultiLine = EvetHayirEnum.ehEvet;
                    ANAMNEZ.NoClip = EvetHayirEnum.ehEvet;
                    ANAMNEZ.WordBreak = EvetHayirEnum.ehEvet;
                    ANAMNEZ.ExpandTabs = EvetHayirEnum.ehEvet;
                    ANAMNEZ.TextFont.Name = "Arial Narrow";
                    ANAMNEZ.TextFont.Size = 9;
                    ANAMNEZ.Value = @"{#NOT.SYMPTOM#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Kısa Anamnez ve Klinik Bulgular";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 6, 59, 6, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 59, 5, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.TextFont.Name = "Arial Narrow";
                    NewField1341.TextFont.Size = 9;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class dataset_GetConsultationFromOtherHospitalInfo = MyParentReport.NOT.rsGroup.GetCurrentRecord<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>(0);
                    ANAMNEZ.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.Symptom) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    return new TTReportObject[] { ANAMNEZ,NewField1,NewField1341};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class DESCRIPTIONGroup : TTReportGroup
        {
            public ConsultationFromOtherHospitalReport MyParentReport
            {
                get { return (ConsultationFromOtherHospitalReport)ParentReport; }
            }

            new public DESCRIPTIONGroupBody Body()
            {
                return (DESCRIPTIONGroupBody)_body;
            }
            public TTReportField REQUESTDESCRIPTION { get {return Body().REQUESTDESCRIPTION;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField11431 { get {return Body().NewField11431;} }
            public DESCRIPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DESCRIPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DESCRIPTIONGroupBody(this);
            }

            public partial class DESCRIPTIONGroupBody : TTReportSection
            {
                public ConsultationFromOtherHospitalReport MyParentReport
                {
                    get { return (ConsultationFromOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField REQUESTDESCRIPTION;
                public TTReportField NewField11;
                public TTReportShape NewLine1;
                public TTReportField NewField11431; 
                public DESCRIPTIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    REQUESTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 205, 15, false);
                    REQUESTDESCRIPTION.Name = "REQUESTDESCRIPTION";
                    REQUESTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    REQUESTDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    REQUESTDESCRIPTION.TextFont.Name = "Arial Narrow";
                    REQUESTDESCRIPTION.TextFont.Size = 9;
                    REQUESTDESCRIPTION.Value = @"{#NOT.REQUESTDESCRIPTION#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"İstek Açıklaması";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 6, 59, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 59, 5, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.TextFont.Name = "Arial Narrow";
                    NewField11431.TextFont.Size = 9;
                    NewField11431.TextFont.Bold = true;
                    NewField11431.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class dataset_GetConsultationFromOtherHospitalInfo = MyParentReport.NOT.rsGroup.GetCurrentRecord<ConsultationFromOtherHospital.GetConsultationFromOtherHospitalInfo_Class>(0);
                    REQUESTDESCRIPTION.CalcValue = (dataset_GetConsultationFromOtherHospitalInfo != null ? Globals.ToStringCore(dataset_GetConsultationFromOtherHospitalInfo.RequestDescription) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    return new TTReportObject[] { REQUESTDESCRIPTION,NewField11,NewField11431};
                }
            }

        }

        public DESCRIPTIONGroup DESCRIPTION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsultationFromOtherHospitalReport()
        {
            TOPHEADER = new TOPHEADERGroup(this,"TOPHEADER");
            NOT = new NOTGroup(TOPHEADER,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            DESCRIPTION = new DESCRIPTIONGroup(NOT,"DESCRIPTION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Dış XXXXXXlerden Konsültasyon ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CONSULTATIONFROMOTHERHOSPITALREPORT";
            Caption = "Dış XXXXXX Konsültasyon İstek Raporu";
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