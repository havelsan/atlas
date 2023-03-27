
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
    /// Otopsi Raporu
    /// </summary>
    public partial class AutopsyReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public AutopsyReportReport MyParentReport
            {
                get { return (AutopsyReportReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
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
                public AutopsyReportReport MyParentReport
                {
                    get { return (AutopsyReportReport)ParentReport; }
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
                public AutopsyReportReport MyParentReport
                {
                    get { return (AutopsyReportReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportShape NewLine; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 34, 13, false);
                    NewField0.Name = "NewField0";
                    NewField0.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 13, 32, 13, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField0.CalcValue = NewField0.Value;
                    return new TTReportObject[] { NewField0};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public AutopsyReportReport MyParentReport
            {
                get { return (AutopsyReportReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField SAG { get {return Header().SAG;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField RAPORTARIH { get {return Header().RAPORTARIH;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField35 { get {return Header().NewField35;} }
            public TTReportField NewField36 { get {return Header().NewField36;} }
            public TTReportField NewField38 { get {return Header().NewField38;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField EVRAKTARIHI { get {return Header().EVRAKTARIHI;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField EVRAKSAYISI { get {return Header().EVRAKSAYISI;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField BIRIMPROTOKOL { get {return Header().BIRIMPROTOKOL;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField NewField173 { get {return Header().NewField173;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField RUTBE { get {return Header().RUTBE;} }
            public TTReportField SINIF { get {return Header().SINIF;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField FIELDONAY { get {return Footer().FIELDONAY;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField BASHEKIM { get {return Footer().BASHEKIM;} }
            public TTReportField HEADDOCTOR { get {return Footer().HEADDOCTOR;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
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
                list[0] = new TTReportNqlData<AutopsyReport.GetAutopsyReport_Class>("GetAutopsyReport", AutopsyReport.GetAutopsyReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public AutopsyReportReport MyParentReport
                {
                    get { return (AutopsyReportReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField SAG;
                public TTReportField KONU;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField RAPORTARIH;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField RAPORNO;
                public TTReportField NewField35;
                public TTReportField NewField36;
                public TTReportField NewField38;
                public TTReportShape NewLine2;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField0;
                public TTReportShape NewLine3;
                public TTReportField DATE;
                public TTReportField EVRAKTARIHI;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportShape NewLine1;
                public TTReportField PNAME;
                public TTReportField SURNAME;
                public TTReportField DTARIH;
                public TTReportField EVRAKSAYISI;
                public TTReportField ACTIONDATE;
                public TTReportField BIRIMPROTOKOL;
                public TTReportField ACTIONID;
                public TTReportField BIRIMADI;
                public TTReportField MAKAM;
                public TTReportField NewField173;
                public TTReportField NewField133;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField KURUM; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 90;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 5, 167, 17, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 30, 155, 34, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.Value = @"SAĞ:9067-{%BIRIMPROTOKOL%}-{%ACTIONDATE%}/{%BIRIMADI%}-{%ACTIONID%}";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 156, 38, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.Value = @"KONU:Otopsi Raporu";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 61, 60, 65, false);
                    NewField8.Name = "NewField8";
                    NewField8.Value = @"Sınıf ve Rütbesi";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 71, 60, 75, false);
                    NewField9.Name = "NewField9";
                    NewField9.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 66, 166, 70, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.ObjectDefName = "Patient";
                    BABAAD.DataMember = "FATHERNAME";
                    BABAAD.Value = @"{#PATIENT#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 56, 166, 60, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.Value = @"{%PNAME%} {%SURNAME%}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 56, 60, 60, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Adı Soyadı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 61, 62, 65, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 56, 62, 60, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 66, 60, 70, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"Baba Adı";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 71, 62, 75, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 66, 62, 70, false);
                    NewField18.Name = "NewField18";
                    NewField18.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 46, 60, 50, false);
                    NewField19.Name = "NewField19";
                    NewField19.Value = @"Rapor Tarihi";

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 46, 101, 50, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"dd mmmm yyyy";
                    RAPORTARIH.Value = @"{#ACTIONDATE#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 46, 62, 50, false);
                    NewField21.Name = "NewField21";
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 51, 62, 55, false);
                    NewField22.Name = "NewField22";
                    NewField22.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 51, 60, 55, false);
                    NewField23.Name = "NewField23";
                    NewField23.Value = @"Rapor No";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 51, 101, 55, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    NewField35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 76, 60, 80, false);
                    NewField35.Name = "NewField35";
                    NewField35.Value = @"Muayeneye Gönderen Makam";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 76, 62, 80, false);
                    NewField36.Name = "NewField36";
                    NewField36.Value = @":";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 81, 201, 89, false);
                    NewField38.Name = "NewField38";
                    NewField38.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField38.MultiLine = EvetHayirEnum.ehEvet;
                    NewField38.NoClip = EvetHayirEnum.ehEvet;
                    NewField38.WordBreak = EvetHayirEnum.ehEvet;
                    NewField38.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField38.Value = @"{%EVRAKTARIHI%} gün ve {%EVRAKSAYISI%} sayılı yazısı.";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 89, 204, 89, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 61, 166, 65, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.Value = @"{%SINIF%} {%RUTBE%}";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 10, 32, 14, false);
                    NewField0.Name = "NewField0";
                    NewField0.Value = @"HİZMETE ÖZEL";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 14, 32, 14, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 24, 204, 28, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd mmmm yyyy";
                    DATE.Value = @"{@printdate@}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 18, 201, 23, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.Value = @"{#DOCUMENTDATE#}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 4, 200, 9, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 10, 201, 15, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 42, 204, 42, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 30, 201, 35, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.ObjectDefName = "Patient";
                    PNAME.DataMember = "NAME";
                    PNAME.Value = @"{#PATIENT#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 34, 201, 39, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.Value = @"{#PATIENT#}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 47, 201, 52, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.ObjectDefName = "Patient";
                    DTARIH.DataMember = "BIRTHDATE";
                    DTARIH.Value = @"{#PATIENT#}";

                    EVRAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 62, 200, 67, false);
                    EVRAKSAYISI.Name = "EVRAKSAYISI";
                    EVRAKSAYISI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKSAYISI.Value = @"{#DOCUMENTNUMBER#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 61, 237, 66, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    BIRIMPROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 68, 239, 73, false);
                    BIRIMPROTOKOL.Name = "BIRIMPROTOKOL";
                    BIRIMPROTOKOL.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPROTOKOL.Value = @"{#PROTOCOLNO#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 76, 238, 81, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 82, 238, 87, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.Value = @"{#BIRIMADI#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 55, 202, 60, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.Value = @"{#MAKAM#}";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 76, 189, 80, false);
                    NewField173.Name = "NewField173";
                    NewField173.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField173.Value = @"{%MAKAM%}'nın";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 38, 103, 42, false);
                    NewField133.Name = "NewField133";
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.TextFont.Bold = true;
                    NewField133.Value = @"RAPOR";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 25, 233, 29, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBE.TextFont.Name = "Arial Narrow";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.Value = @"{#NOT.RANK#}";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 21, 233, 26, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Name = "Arial Narrow";
                    SINIF.TextFont.Size = 9;
                    SINIF.Value = @"{#NOT.MILITARYCLASS#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 7, 236, 12, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AutopsyReport.GetAutopsyReport_Class dataset_GetAutopsyReport = ParentGroup.rsGroup.GetCurrentRecord<AutopsyReport.GetAutopsyReport_Class>(0);
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    HEADER.CalcValue = MyParentReport.NOT.SITENAME.CalcValue + @"
" + MyParentReport.NOT.SITECITY.CalcValue + @"
";
                    BIRIMPROTOKOL.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.ProtocolNo) : "");
                    ACTIONDATE.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.ActionDate) : "");
                    BIRIMADI.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Birimadi) : "");
                    ACTIONID.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Actionid) : "");
                    SAG.CalcValue = @"SAĞ:9067-" + MyParentReport.NOT.BIRIMPROTOKOL.CalcValue + @"-" + MyParentReport.NOT.ACTIONDATE.CalcValue + @"/" + MyParentReport.NOT.BIRIMADI.CalcValue + @"-" + MyParentReport.NOT.ACTIONID.CalcValue;
                    KONU.CalcValue = @"KONU:Otopsi Raporu";
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    BABAAD.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Patient) : "");
                    BABAAD.PostFieldValueCalculation();
                    PNAME.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Patient) : "");
                    PNAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Patient) : "");
                    SURNAME.PostFieldValueCalculation();
                    ADSOYAD.CalcValue = MyParentReport.NOT.PNAME.CalcValue + @" " + MyParentReport.NOT.SURNAME.CalcValue;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    RAPORTARIH.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.ActionDate) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    RAPORNO.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.ReportNo) : "");
                    NewField35.CalcValue = NewField35.Value;
                    NewField36.CalcValue = NewField36.Value;
                    EVRAKTARIHI.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.DocumentDate) : "");
                    EVRAKSAYISI.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.DocumentNumber) : "");
                    NewField38.CalcValue = MyParentReport.NOT.EVRAKTARIHI.CalcValue + @" gün ve " + MyParentReport.NOT.EVRAKSAYISI.CalcValue + @" sayılı yazısı.";
                    SINIF.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Militaryclass) : "");
                    RUTBE.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Rank) : "");
                    SINIFRUTBE.CalcValue = MyParentReport.NOT.SINIF.CalcValue + @" " + MyParentReport.NOT.RUTBE.CalcValue;
                    NewField0.CalcValue = NewField0.Value;
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    DTARIH.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Patient) : "");
                    DTARIH.PostFieldValueCalculation();
                    MAKAM.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Makam) : "");
                    NewField173.CalcValue = MyParentReport.NOT.MAKAM.CalcValue + @"'nın";
                    NewField133.CalcValue = NewField133.Value;
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { SITENAME,SITECITY,HEADER,BIRIMPROTOKOL,ACTIONDATE,BIRIMADI,ACTIONID,SAG,KONU,NewField8,NewField9,BABAAD,PNAME,SURNAME,ADSOYAD,NewField12,NewField13,NewField14,NewField15,NewField17,NewField18,NewField19,RAPORTARIH,NewField21,NewField22,NewField23,RAPORNO,NewField35,NewField36,EVRAKTARIHI,EVRAKSAYISI,NewField38,SINIF,RUTBE,SINIFRUTBE,NewField0,DATE,DTARIH,MAKAM,NewField173,NewField133,KURUM};
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public AutopsyReportReport MyParentReport
                {
                    get { return (AutopsyReportReport)ParentReport; }
                }
                
                public TTReportField FIELDONAY;
                public TTReportShape NewLine;
                public TTReportField BASHEKIM;
                public TTReportField HEADDOCTOR;
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField DIPSICLABEL;
                public TTReportField SINRUT;
                public TTReportField UZ;
                public TTReportField UZMANLIKDAL;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 52;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FIELDONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 23, 196, 30, false);
                    FIELDONAY.Name = "FIELDONAY";
                    FIELDONAY.MultiLine = EvetHayirEnum.ehEvet;
                    FIELDONAY.WordBreak = EvetHayirEnum.ehEvet;
                    FIELDONAY.Value = @"ONAY
";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 204, 1, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    BASHEKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 32, 196, 51, false);
                    BASHEKIM.Name = "BASHEKIM";
                    BASHEKIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASHEKIM.MultiLine = EvetHayirEnum.ehEvet;
                    BASHEKIM.WordBreak = EvetHayirEnum.ehEvet;
                    BASHEKIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASHEKIM.Value = @"{%HEADDOCTOR%}";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 11, 179, 16, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOR.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"", """")";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 13, 81, 17, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 81, 9, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#NOT.PROCEDUREDOCTORNAME#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 31, 17, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 81, 13, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"{%SINIFONAY%} {%RUTBEONAY%}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 81, 21, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 26, 35, 30, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#NOT.SPECIALITY#}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 26, 63, 30, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#NOT.WORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 38, 64, 42, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#NOT.DIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 30, 35, 34, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 30, 63, 34, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 34, 63, 38, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#NOT.TITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 35, 38, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#NOT.EMPLOYMENTRECORDID#}";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 43, 33, 47, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#NOT.RANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 39, 33, 44, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#NOT.MILITARYCLASS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AutopsyReport.GetAutopsyReport_Class dataset_GetAutopsyReport = ParentGroup.rsGroup.GetCurrentRecord<AutopsyReport.GetAutopsyReport_Class>(0);
                    FIELDONAY.CalcValue = FIELDONAY.Value;
                    HEADDOCTOR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "");
                    BASHEKIM.CalcValue = MyParentReport.NOT.HEADDOCTOR.CalcValue;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Proceduredoctorname) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINIFONAY.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Militaryclass) : "");
                    RUTBEONAY.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Rank) : "");
                    SINRUT.CalcValue = MyParentReport.NOT.SINIFONAY.CalcValue + @" " + MyParentReport.NOT.RUTBEONAY.CalcValue;
                    UZMANLIKDAL.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Speciality) : "");
                    UZ.CalcValue = MyParentReport.NOT.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Work) : "");
                    DIPLOMANO.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.DiplomaNo) : "");
                    UNVAN.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.Title) : "");
                    SICILNO.CalcValue = (dataset_GetAutopsyReport != null ? Globals.ToStringCore(dataset_GetAutopsyReport.EmploymentRecordID) : "");
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { FIELDONAY,HEADDOCTOR,BASHEKIM,DIPSIC,ADSOYADDOC,DIPSICLABEL,SINIFONAY,RUTBEONAY,SINRUT,UZMANLIKDAL,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    //            string sObjectID = ((TTReportClasses.AutopsyReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //            TTObjectContext context = new TTObjectContext(true);//yeni context oluşturduk
            //            BindingList<TTObjectClasses.AutopsyReport> actions = TTObjectClasses.AutopsyReport.GetAutopsyReportById(context, sObjectID);
            //            if(actions.Count > 0)
            //            {
            //                TTObjectClasses.AutopsyReport theObj = actions[0];
            //                if (theObj.ProcedureDoctor!=null)
            //                {
            //                    this.USERNAME.CalcValue = theObj.ProcedureDoctor.Person.Name + " "  + theObj.ProcedureDoctor.Person.Surname;
            //                    if(theObj.ProcedureDoctor.MilitaryClass != null)
            //                        this.SINIFONAYRUTBEONAY.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
            //                    if(theObj.ProcedureDoctor.Rank != null)
            //                        this.SINIFONAYRUTBEONAY.CalcValue += " " + theObj.ProcedureDoctor.Rank.Name;
            //                    this.UZ.CalcValue = theObj.ProcedureDoctor.Title.ToString();
            //                }
            //            }             
            if(this.SICILKULLAN.Value=="TRUE")
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
                    this.SINRUT.CalcValue=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
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
            public AutopsyReportReport MyParentReport
            {
                get { return (AutopsyReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF Report { get {return Body().Report;} }
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
                public AutopsyReportReport MyParentReport
                {
                    get { return (AutopsyReportReport)ParentReport; }
                }
                
                public TTReportRTF Report; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    Report = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 8, 2, 204, 11, false);
                    Report.Name = "Report";
                    Report.CanExpand = EvetHayirEnum.ehHayir;
                    Report.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Report.CalcValue = Report.Value;
                    return new TTReportObject[] { Report};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((AutopsyReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            AutopsyReport autopsyReport = (AutopsyReport)context.GetObject(new Guid(sObjectID),"AutopsyReport");
            this.Report.Value=autopsyReport.Report.ToString();
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AutopsyReportReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "AUTOPSYREPORTREPORT";
            Caption = "Otopsi Raporu";
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