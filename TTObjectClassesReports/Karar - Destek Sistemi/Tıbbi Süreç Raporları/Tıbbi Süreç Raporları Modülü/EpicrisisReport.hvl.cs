
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
    /// Epikriz Raporu (Kurum)
    /// </summary>
    public partial class EpicrisisReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 12, 200, 12, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 18, 199, 23, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 13, 199, 18, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 13, 113, 18, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate,PageNumber,UserName};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField RAPORTARIH { get {return Header().RAPORTARIH;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField LBLYATISTARIHI { get {return Header().LBLYATISTARIHI;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField LBLTABURCUTARIHI { get {return Header().LBLTABURCUTARIHI;} }
            public TTReportField TABURCUTARIHI { get {return Header().TABURCUTARIHI;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField SUBEPISODE { get {return Header().SUBEPISODE;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField ID { get {return Header().ID;} }
            public TTReportField FIELDONAY { get {return Footer().FIELDONAY;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                list[0] = new TTReportNqlData<CreatingEpicrisis.GetCreatingEpicrisis_Class>("GetCreatingEpicrisis2", CreatingEpicrisis.GetCreatingEpicrisis((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField KONU;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField141;
                public TTReportField NewField191;
                public TTReportField RAPORTARIH;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField RAPORNO;
                public TTReportField DATE;
                public TTReportShape NewLine11;
                public TTReportField PNAME;
                public TTReportField SURNAME;
                public TTReportField ACTIONDATE;
                public TTReportField ACTIONID;
                public TTReportField BIRIMADI;
                public TTReportField NewField1331;
                public TTReportField EPISODE;
                public TTReportField TCNO;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField LBLYATISTARIHI;
                public TTReportField YATISTARIHI;
                public TTReportField NewField1211;
                public TTReportField LBLTABURCUTARIHI;
                public TTReportField TABURCUTARIHI;
                public TTReportField NewField11121;
                public TTReportField HEADER;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField KURUM;
                public TTReportField SUBEPISODE;
                public TTReportField NewField1221;
                public TTReportField NewField1231;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField11211;
                public TTReportField NewField11411;
                public TTReportField ID; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 158, 29, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Arial Narrow";
                    KONU.TextFont.CharSet = 162;
                    KONU.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 62, 168, 66, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{%PNAME%} {%SURNAME%}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 62, 66, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Adı Soyadı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 62, 64, 66, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 37, 62, 41, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Rapor Tarihi";

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 37, 103, 41, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIH.TextFont.Name = "Arial Narrow";
                    RAPORTARIH.TextFont.CharSet = 162;
                    RAPORTARIH.Value = @"{#REQUESTDATE#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 37, 64, 41, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 42, 64, 46, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 62, 46, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"Rapor No";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 42, 103, 46, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 22, 205, 26, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.TextFont.Name = "Arial Narrow";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@printdate@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 34, 199, 34, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 38, 236, 43, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.ObjectDefName = "Patient";
                    PNAME.DataMember = "NAME";
                    PNAME.TextFont.CharSet = 162;
                    PNAME.Value = @"{#PATIENT#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 42, 236, 47, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.TextFont.CharSet = 162;
                    SURNAME.Value = @"{#PATIENT#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 49, 236, 54, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFont.CharSet = 162;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 31, 237, 36, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 93, 241, 98, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.TextFont.CharSet = 162;
                    BIRIMADI.Value = @"{#BIRIMADI#}";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 29, 105, 33, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.TextFont.Name = "Arial Narrow";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"RAPOR";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 55, 226, 60, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Name = "Arial Narrow";
                    EPISODE.TextFont.Size = 9;
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#EPISODE#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 52, 103, 56, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.ObjectDefName = "patient";
                    TCNO.DataMember = "UNIQUEREFNO";
                    TCNO.TextFont.Name = "Arial Narrow";
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"{#PATIENT#}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 62, 56, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"TC Kimlik No";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 52, 64, 56, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    LBLYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 36, 173, 40, false);
                    LBLYATISTARIHI.Name = "LBLYATISTARIHI";
                    LBLYATISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    LBLYATISTARIHI.TextFont.Name = "Arial Narrow";
                    LBLYATISTARIHI.TextFont.CharSet = 162;
                    LBLYATISTARIHI.Value = @"Yatış Tarihi";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 36, 199, 40, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    YATISTARIHI.TextFont.Name = "Arial Narrow";
                    YATISTARIHI.TextFont.CharSet = 162;
                    YATISTARIHI.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 36, 175, 40, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.Visible = EvetHayirEnum.ehHayir;
                    NewField1211.TextFont.Name = "Arial Narrow";
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @":";

                    LBLTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 41, 173, 45, false);
                    LBLTABURCUTARIHI.Name = "LBLTABURCUTARIHI";
                    LBLTABURCUTARIHI.Visible = EvetHayirEnum.ehHayir;
                    LBLTABURCUTARIHI.TextFont.Name = "Arial Narrow";
                    LBLTABURCUTARIHI.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI.Value = @"Taburcu Tarihi";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 41, 199, 45, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.Visible = EvetHayirEnum.ehHayir;
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"dd/MM/yyyy";
                    TABURCUTARIHI.TextFont.Name = "Arial Narrow";
                    TABURCUTARIHI.TextFont.CharSet = 162;
                    TABURCUTARIHI.Value = @"";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 41, 175, 45, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.Visible = EvetHayirEnum.ehHayir;
                    NewField11121.TextFont.Name = "Arial Narrow";
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @":";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 3, 165, 15, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, -1, 199, 4, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.TextFont.Name = "Arial Narrow";
                    SITENAME.TextFont.CharSet = 162;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 5, 200, 10, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.TextFont.Name = "Arial Narrow";
                    SITECITY.TextFont.CharSet = 162;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 11, 199, 16, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.TextFont.Name = "Arial Narrow";
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    SUBEPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 23, 238, 28, false);
                    SUBEPISODE.Name = "SUBEPISODE";
                    SUBEPISODE.Visible = EvetHayirEnum.ehHayir;
                    SUBEPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBEPISODE.TextFont.Name = "Arial Narrow";
                    SUBEPISODE.TextFont.Size = 9;
                    SUBEPISODE.TextFont.CharSet = 162;
                    SUBEPISODE.Value = @"{#SUBEPISODE#}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 47, 64, 51, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 62, 51, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.TextFont.Name = "Arial Narrow";
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"H. Protokol No";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 47, 103, 51, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 57, 62, 61, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Narrow";
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Hasta No";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 57, 64, 61, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Arial Narrow";
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    ID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 57, 90, 61, false);
                    ID.Name = "ID";
                    ID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ID.TextFont.Name = "Arial Narrow";
                    ID.TextFont.CharSet = 162;
                    ID.Value = @"{#ID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CreatingEpicrisis.GetCreatingEpicrisis_Class dataset_GetCreatingEpicrisis2 = ParentGroup.rsGroup.GetCurrentRecord<CreatingEpicrisis.GetCreatingEpicrisis_Class>(0);
                    KONU.CalcValue = @"";
                    PNAME.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Patient) : "");
                    PNAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Patient) : "");
                    SURNAME.PostFieldValueCalculation();
                    ADSOYAD.CalcValue = MyParentReport.NOT.PNAME.CalcValue + @" " + MyParentReport.NOT.SURNAME.CalcValue;
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField191.CalcValue = NewField191.Value;
                    RAPORTARIH.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.RequestDate) : "");
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    RAPORNO.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.ReportNo) : "");
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    ACTIONDATE.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.ActionDate) : "");
                    ACTIONID.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Actionid) : "");
                    BIRIMADI.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Birimadi) : "");
                    NewField1331.CalcValue = NewField1331.Value;
                    EPISODE.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Episode) : "");
                    TCNO.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Patient) : "");
                    TCNO.PostFieldValueCalculation();
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    LBLYATISTARIHI.CalcValue = LBLYATISTARIHI.Value;
                    YATISTARIHI.CalcValue = @"";
                    NewField1211.CalcValue = NewField1211.Value;
                    LBLTABURCUTARIHI.CalcValue = LBLTABURCUTARIHI.Value;
                    TABURCUTARIHI.CalcValue = @"";
                    NewField11121.CalcValue = NewField11121.Value;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    HEADER.CalcValue = MyParentReport.NOT.SITENAME.CalcValue + @"
" + MyParentReport.NOT.SITECITY.CalcValue + @"
";
                    SUBEPISODE.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.SubEpisode) : "");
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    PROTOKOLNO.CalcValue = @"";
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    ID.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.ID) : "");
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { KONU,PNAME,SURNAME,ADSOYAD,NewField121,NewField141,NewField191,RAPORTARIH,NewField112,NewField122,NewField132,RAPORNO,DATE,ACTIONDATE,ACTIONID,BIRIMADI,NewField1331,EPISODE,TCNO,NewField1121,NewField1141,LBLYATISTARIHI,YATISTARIHI,NewField1211,LBLTABURCUTARIHI,TABURCUTARIHI,NewField11121,SITENAME,SITECITY,HEADER,SUBEPISODE,NewField1221,NewField1231,PROTOKOLNO,NewField11211,NewField11411,ID,KURUM};
                }
                public override void RunPreScript()
                {
#region NOT HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.Episode.PatientStatus != PatientStatusEnum.Outpatient)
            {
//                IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
//                inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResource(context,creatingEpicrisis.Episode.ObjectID,creatingEpicrisis.MasterResource.ObjectID);
//                if(inpatientTreatmentClinicList.Count > 0)
//                {
//                    this.YATISTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicInpatientDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicInpatientDate.ToString());
//                    this.TABURCUTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate.ToString());
//                }
                this.LBLYATISTARIHI.Visible = EvetHayirEnum.ehEvet;
                this.NewField1211.Visible = EvetHayirEnum.ehEvet;
                this.YATISTARIHI.Visible = EvetHayirEnum.ehEvet;
                
                this.LBLTABURCUTARIHI.Visible = EvetHayirEnum.ehEvet;
                this.NewField11121.Visible = EvetHayirEnum.ehEvet;
                this.TABURCUTARIHI.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.LBLYATISTARIHI.Visible = EvetHayirEnum.ehHayir;
                this.NewField1211.Visible = EvetHayirEnum.ehHayir;
                this.YATISTARIHI.Visible = EvetHayirEnum.ehHayir;
                
                this.LBLTABURCUTARIHI.Visible = EvetHayirEnum.ehHayir;
                this.NewField11121.Visible = EvetHayirEnum.ehHayir;
                this.TABURCUTARIHI.Visible = EvetHayirEnum.ehHayir;
            }
#endregion NOT HEADER_PreScript
                }

                public override void RunScript()
                {
#region NOT HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.Episode.PatientStatus != PatientStatusEnum.Outpatient)
            {
                //subepisode u varsa
                if(Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue))
                {
                    bool valueSet = false;
                    //masterAction ı varsa ve Klinik doktor işlemleri türünde ise, masterAction ın klinik yatış ve çıkış tarihleri alınır.
                    if(creatingEpicrisis.MasterAction != null)
                    {
                        if(creatingEpicrisis.MasterAction is InPatientPhysicianApplication)
                        {
                            this.YATISTARIHI.CalcValue = (((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicInpatientDate == null ? "" : ((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicInpatientDate.ToString());
                            this.TABURCUTARIHI.CalcValue = (((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicDischargeDate == null ? "" : ((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicDischargeDate.ToString());
                            valueSet = true;
                        }
                    }
                    //masterAction ı yoksa ya da Klinik Doktor İşlemleri türünde değilse subepisode daki Klinik İşlemleri bulunur. Bunların ilkinin yatış, sonuncusunun çıkış tarihi alınır.
                    if(valueSet == false)
                    {
                        if(creatingEpicrisis.ProcedureSpeciality != null)
                        {
                            IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
                            Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                            inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetBySubEpisodeAndProcedureSpeciality(context,creatingEpicrisis.Episode.ObjectID,subepisode,creatingEpicrisis.ProcedureSpeciality.ObjectID);
                            if(inpatientTreatmentClinicList.Count > 1)
                            {
                                int count = inpatientTreatmentClinicList.Count;
                                this.YATISTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[count-1]).ClinicInpatientDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[count-1]).ClinicInpatientDate.ToString());
                                this.TABURCUTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate.ToString());
                            }
                        }
                    }
                }
                else //subepisode u yoksa episode daki Klinik İşlemleri bulunur. Bunların ilkinin yatış, sonuncusunun çıkış tarihi alınır.
                {
                    if(creatingEpicrisis.ProcedureSpeciality != null)
                    {
                        
                        IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
                        inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetByEpisodeAndProcedureSpeciality(context,creatingEpicrisis.Episode.ObjectID,creatingEpicrisis.ProcedureSpeciality.ObjectID);
                        if(inpatientTreatmentClinicList.Count > 0)
                        {
                            int count = inpatientTreatmentClinicList.Count;
                            this.YATISTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[count-1]).ClinicInpatientDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[count-1]).ClinicInpatientDate.ToString());
                            this.TABURCUTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate.ToString());
                        }
                    }
                }
            }

            
            if(creatingEpicrisis.ProcedureSpeciality != null)
                this.KONU.CalcValue = "KONU: " + creatingEpicrisis.ProcedureSpeciality.Name + " Epikriz Raporu (KURUM)";
            else
                this.KONU.CalcValue = "KONU: Epikriz Raporu";
            this.PROTOKOLNO.CalcValue = creatingEpicrisis.Episode.HospitalProtocolNo.Value.ToString();
#endregion NOT HEADER_Script
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField FIELDONAY;
                public TTReportField ISTEKDR;
                public TTReportField ONAY;
                public TTReportShape NewLine1; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 50;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FIELDONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 22, 191, 29, false);
                    FIELDONAY.Name = "FIELDONAY";
                    FIELDONAY.MultiLine = EvetHayirEnum.ehEvet;
                    FIELDONAY.WordBreak = EvetHayirEnum.ehEvet;
                    FIELDONAY.TextFont.Name = "Arial Narrow";
                    FIELDONAY.TextFont.CharSet = 162;
                    FIELDONAY.Value = @"ONAYLI";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 77, 30, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Name = "Arial Narrow";
                    ISTEKDR.TextFont.CharSet = 1;
                    ISTEKDR.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 29, 191, 46, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CreatingEpicrisis.GetCreatingEpicrisis_Class dataset_GetCreatingEpicrisis2 = ParentGroup.rsGroup.GetCurrentRecord<CreatingEpicrisis.GetCreatingEpicrisis_Class>(0);
                    FIELDONAY.CalcValue = FIELDONAY.Value;
                    ISTEKDR.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    return new TTReportObject[] { FIELDONAY,ISTEKDR,ONAY};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    string sObjectID = ((TTReportClasses.EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext context = new TTObjectContext(true);//yeni context oluşturduk
            BindingList<TTObjectClasses.CreatingEpicrisis> actions = TTObjectClasses.CreatingEpicrisis.GetCreatingEpicrisisById(context, sObjectID);
            if(actions.Count > 0)
            {
                TTObjectClasses.CreatingEpicrisis  theObj = actions[0];
                if (theObj.ProcedureDoctor!=null)
                    this.ISTEKDR.CalcValue =theObj.ProcedureDoctor.SignatureBlock;
            }
            
            this.ONAY.CalcValue = TTObjectClasses.ResHospital.ApprovalSignatureBlock;
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class NOTSIBLINGGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public NOTSIBLINGGroupBody Body()
            {
                return (NOTSIBLINGGroupBody)_body;
            }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField BABAAD { get {return Body().BABAAD;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField NewField1291 { get {return Body().NewField1291;} }
            public TTReportField NewField11711 { get {return Body().NewField11711;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField111411 { get {return Body().NewField111411;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public NOTSIBLINGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTSIBLINGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new NOTSIBLINGGroupBody(this);
            }

            public partial class NOTSIBLINGGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField BABAAD;
                public TTReportField NewField1131;
                public TTReportField NewField1151;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField NewField1291;
                public TTReportField NewField11711;
                public TTReportField NewField111211;
                public TTReportField NewField111411;
                public TTReportShape NewLine1121; 
                public NOTSIBLINGGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 41;
                    RepeatCount = 0;
                    
                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 62, 10, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Sınıf ve Rütbesi";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 62, 20, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 11, 168, 15, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.ObjectDefName = "Patient";
                    BABAAD.DataMember = "FATHERNAME";
                    BABAAD.TextFont.Name = "Arial Narrow";
                    BABAAD.TextFont.CharSet = 162;
                    BABAAD.Value = @"{#NOT.PATIENT#}";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 6, 64, 10, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 62, 15, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Name = "Arial Narrow";
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Baba Adı";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 16, 64, 20, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 11, 64, 15, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 62, 25, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.Name = "Arial Narrow";
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @"Adres";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 21, 64, 25, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial Narrow";
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @":";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 62, 39, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Name = "Arial Narrow";
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Telefon";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 35, 64, 39, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.TextFont.Name = "Arial Narrow";
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @":";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 40, 200, 40, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CreatingEpicrisis.GetCreatingEpicrisis_Class dataset_GetCreatingEpicrisis2 = MyParentReport.NOT.rsGroup.GetCurrentRecord<CreatingEpicrisis.GetCreatingEpicrisis_Class>(0);
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    BABAAD.CalcValue = (dataset_GetCreatingEpicrisis2 != null ? Globals.ToStringCore(dataset_GetCreatingEpicrisis2.Patient) : "");
                    BABAAD.PostFieldValueCalculation();
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    return new TTReportObject[] { NewField181,NewField191,BABAAD,NewField1131,NewField1151,NewField1171,NewField1181,NewField1291,NewField11711,NewField111211,NewField111411};
                }

                public override void RunScript()
                {
#region NOTSIBLING BODY_Script
                    //                                                         EpicrisisReport parentReport = (EpicrisisReport)ParentReport;
//                    TTObjectContext context = parentReport.ReportObjectContext;
//                    string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//                    CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID), "CreatingEpicrisis");
//                    Episode episode = creatingEpicrisis.Episode;
//                    if (episode == null)
//                        throw new Exception("Hastanın vakasına ulaşılamadı .Lütfen Bilgi işleme Başvurunuz");
////                     if(episode.WarVetera == true)
////                        this.WARVETERA.CalcValue ="(Muharip Gazi)";
////                    if(episode.DisabledWarVetera == true)
////                       this.WARVETERA.CalcValue ="(Malul Gazi)";
#endregion NOTSIBLING BODY_Script
                }
            }

        }

        public NOTSIBLINGGroup NOTSIBLING;

        public partial class PARENTGRPGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public PARENTGRPGroupHeader Header()
            {
                return (PARENTGRPGroupHeader)_header;
            }

            new public PARENTGRPGroupFooter Footer()
            {
                return (PARENTGRPGroupFooter)_footer;
            }

            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public PARENTGRPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGRPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGRPGroupHeader(this);
                _footer = new PARENTGRPGroupFooter(this);

            }

            public partial class PARENTGRPGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public PARENTGRPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARENTGRPGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1121; 
                public PARENTGRPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARENTGRPGroup PARENTGRP;

        public partial class MAINGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF SIKAYET { get {return Body().SIKAYET;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
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
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF SIKAYET;
                public TTReportField NewField1191; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    SIKAYET = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 17, false);
                    SIKAYET.Name = "SIKAYET";
                    SIKAYET.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 5, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.Underline = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"YAKINMALAR VE ÖYKÜ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIKAYET.CalcValue = SIKAYET.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    return new TTReportObject[] { SIKAYET,NewField1191};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.COMPLAINTANDSTORY!=null)
                this.SIKAYET.Value = creatingEpicrisis.COMPLAINTANDSTORY.ToString();
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        public partial class OZGECMISGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public OZGECMISGroupBody Body()
            {
                return (OZGECMISGroupBody)_body;
            }
            public TTReportRTF OZGECMIS { get {return Body().OZGECMIS;} }
            public TTReportField NewField11191 { get {return Body().NewField11191;} }
            public OZGECMISGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OZGECMISGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new OZGECMISGroupBody(this);
            }

            public partial class OZGECMISGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF OZGECMIS;
                public TTReportField NewField11191; 
                public OZGECMISGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    OZGECMIS = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    OZGECMIS.Name = "OZGECMIS";
                    OZGECMIS.Value = @"";

                    NewField11191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 63, 7, false);
                    NewField11191.Name = "NewField11191";
                    NewField11191.TextFont.Name = "Arial Narrow";
                    NewField11191.TextFont.Bold = true;
                    NewField11191.TextFont.Underline = true;
                    NewField11191.TextFont.CharSet = 162;
                    NewField11191.Value = @"ÖZGEÇMİŞ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OZGECMIS.CalcValue = OZGECMIS.Value;
                    NewField11191.CalcValue = NewField11191.Value;
                    return new TTReportObject[] { OZGECMIS,NewField11191};
                }
                public override void RunPreScript()
                {
#region OZGECMIS BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");            
            if(creatingEpicrisis.AUTOBIOGRAPHY!=null)
                this.OZGECMIS.Value = creatingEpicrisis.AUTOBIOGRAPHY.ToString();
#endregion OZGECMIS BODY_PreScript
                }
            }

        }

        public OZGECMISGroup OZGECMIS;

        public partial class FIZIKMUAYENEGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public FIZIKMUAYENEGroupBody Body()
            {
                return (FIZIKMUAYENEGroupBody)_body;
            }
            public TTReportRTF FIZIKMUAYENE { get {return Body().FIZIKMUAYENE;} }
            public TTReportField NewField111911 { get {return Body().NewField111911;} }
            public FIZIKMUAYENEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIZIKMUAYENEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIZIKMUAYENEGroupBody(this);
            }

            public partial class FIZIKMUAYENEGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF FIZIKMUAYENE;
                public TTReportField NewField111911; 
                public FIZIKMUAYENEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    FIZIKMUAYENE = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 18, false);
                    FIZIKMUAYENE.Name = "FIZIKMUAYENE";
                    FIZIKMUAYENE.Value = @"";

                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.TextFont.Name = "Arial Narrow";
                    NewField111911.TextFont.Bold = true;
                    NewField111911.TextFont.Underline = true;
                    NewField111911.TextFont.CharSet = 162;
                    NewField111911.Value = @"FİZİK MUAYENE:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FIZIKMUAYENE.CalcValue = FIZIKMUAYENE.Value;
                    NewField111911.CalcValue = NewField111911.Value;
                    return new TTReportObject[] { FIZIKMUAYENE,NewField111911};
                }
                public override void RunPreScript()
                {
#region FIZIKMUAYENE BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.PHYSICALEXAMINATION!=null)
                this.FIZIKMUAYENE.Value = creatingEpicrisis.PHYSICALEXAMINATION.ToString();
#endregion FIZIKMUAYENE BODY_PreScript
                }
            }

        }

        public FIZIKMUAYENEGroup FIZIKMUAYENE;

        public partial class SKRAPORGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public SKRAPORGroupBody Body()
            {
                return (SKRAPORGroupBody)_body;
            }
            public TTReportField NewField111191121 { get {return Body().NewField111191121;} }
            public TTReportRTF SKRAPOR { get {return Body().SKRAPOR;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
            public SKRAPORGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SKRAPORGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SKRAPORGroupBody(this);
            }

            public partial class SKRAPORGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField NewField111191121;
                public TTReportRTF SKRAPOR;
                public TTReportField DECISIONTIME; 
                public SKRAPORGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    NewField111191121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField111191121.Name = "NewField111191121";
                    NewField111191121.TextFont.Name = "Arial Narrow";
                    NewField111191121.TextFont.Bold = true;
                    NewField111191121.TextFont.Underline = true;
                    NewField111191121.TextFont.CharSet = 162;
                    NewField111191121.Value = @"SAĞLIK KURULU RAPORU:";

                    SKRAPOR = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 18, false);
                    SKRAPOR.Name = "SKRAPOR";
                    SKRAPOR.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 5, 237, 10, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111191121.CalcValue = NewField111191121.Value;
                    SKRAPOR.CalcValue = SKRAPOR.Value;
                    DECISIONTIME.CalcValue = @"";
                    return new TTReportObject[] { NewField111191121,SKRAPOR,DECISIONTIME};
                }
                public override void RunPreScript()
                {
#region SKRAPOR BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            string conc = String.Empty;
            foreach(HealthCommittee hc in creatingEpicrisis.Episode.HealthCommittees)
            {
                if(hc.CurrentStateDefID != HealthCommittee.States.Cancelled)
                {
                    if(hc.HealthCommitteeDecision != null )
                    {
                        if(hc.HCDecisionTime != null)
                        {
                            this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                            conc += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                        }
                        
                        if(hc.HCDecisionUnitOfTime != null)
                            conc += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                        
                        conc += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString());
                    }
                    
                    
                    conc += "\r\n\r\n";
                }
            }
            if(conc == String.Empty)
                this.Visible = EvetHayirEnum.ehHayir;
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                this.SKRAPOR.Value = TTObjectClasses.Common.GetRTFOfTextString(conc.ToString()) ;
            }
#endregion SKRAPOR BODY_PreScript
                }
            }

        }

        public SKRAPORGroup SKRAPOR;

        public partial class LABTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public LABTETKIKBASLIKGroupHeader Header()
            {
                return (LABTETKIKBASLIKGroupHeader)_header;
            }

            new public LABTETKIKBASLIKGroupFooter Footer()
            {
                return (LABTETKIKBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih111 { get {return Header().lableTarih111;} }
            public TTReportField LableOrtezAdı111 { get {return Header().LableOrtezAdı111;} }
            public TTReportField lableOrtezProtezCode11 { get {return Header().lableOrtezProtezCode11;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportField lableLabTest111 { get {return Header().lableLabTest111;} }
            public TTReportShape NewLine11111121 { get {return Footer().NewLine11111121;} }
            public LABTETKIKBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LABTETKIKBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LABTETKIKBASLIKGroupHeader(this);
                _footer = new LABTETKIKBASLIKGroupFooter(this);

            }

            public partial class LABTETKIKBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih111;
                public TTReportField LableOrtezAdı111;
                public TTReportField lableOrtezProtezCode11;
                public TTReportShape NewLine1111111;
                public TTReportField lableLabTest111; 
                public LABTETKIKBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih111.Name = "lableTarih111";
                    lableTarih111.TextFont.Name = "Arial Narrow";
                    lableTarih111.TextFont.CharSet = 162;
                    lableTarih111.Value = @"Tarih";

                    LableOrtezAdı111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableOrtezAdı111.Name = "LableOrtezAdı111";
                    LableOrtezAdı111.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı111.TextFont.CharSet = 162;
                    LableOrtezAdı111.Value = @"Tetkik";

                    lableOrtezProtezCode11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableOrtezProtezCode11.Name = "lableOrtezProtezCode11";
                    lableOrtezProtezCode11.TextFont.Name = "Arial Narrow";
                    lableOrtezProtezCode11.TextFont.CharSet = 162;
                    lableOrtezProtezCode11.Value = @"Sonucu";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableLabTest111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableLabTest111.Name = "lableLabTest111";
                    lableLabTest111.TextFont.Name = "Arial Narrow";
                    lableLabTest111.TextFont.Bold = true;
                    lableLabTest111.TextFont.CharSet = 162;
                    lableLabTest111.Value = @"LABORATUVAR TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih111.CalcValue = lableTarih111.Value;
                    LableOrtezAdı111.CalcValue = LableOrtezAdı111.Value;
                    lableOrtezProtezCode11.CalcValue = lableOrtezProtezCode11.Value;
                    lableLabTest111.CalcValue = lableLabTest111.Value;
                    return new TTReportObject[] { lableTarih111,LableOrtezAdı111,lableOrtezProtezCode11,lableLabTest111};
                }
                public override void RunPreScript()
                {
#region LABTETKIKBASLIK HEADER_PreScript
                    //            if(((EpicrisisReport)ParentReport).LABTETKIKALTBASLIK.GroupDataSet == null || ((EpicrisisReport)ParentReport).LABTETKIKALTBASLIK.GroupDataSet.Count <= 0)
//            {
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABALTTETKIK").Body)).Visible = EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABALTTETKIK").Body)).Visible = EvetHayirEnum.ehEvet;
//            }
#endregion LABTETKIKBASLIK HEADER_PreScript
                }
            }
            public partial class LABTETKIKBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111121; 
                public LABTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine11111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLine11111121.Name = "NewLine11111121";
                    NewLine11111121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public LABTETKIKBASLIKGroup LABTETKIKBASLIK;

        public partial class LABTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public LABTETKIKYENIGroupBody Body()
            {
                return (LABTETKIKYENIGroupBody)_body;
            }
            public TTReportRTF LABTETKIKRTF { get {return Body().LABTETKIKRTF;} }
            public TTReportField lableLabTest1111 { get {return Body().lableLabTest1111;} }
            public LABTETKIKYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LABTETKIKYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new LABTETKIKYENIGroupBody(this);
            }

            public partial class LABTETKIKYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF LABTETKIKRTF;
                public TTReportField lableLabTest1111; 
                public LABTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    LABTETKIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    LABTETKIKRTF.Name = "LABTETKIKRTF";
                    LABTETKIKRTF.Value = @"";

                    lableLabTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableLabTest1111.Name = "lableLabTest1111";
                    lableLabTest1111.TextFont.Name = "Arial Narrow";
                    lableLabTest1111.TextFont.Bold = true;
                    lableLabTest1111.TextFont.CharSet = 162;
                    lableLabTest1111.Value = @"LABORATUVAR TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LABTETKIKRTF.CalcValue = LABTETKIKRTF.Value;
                    lableLabTest1111.CalcValue = lableLabTest1111.Value;
                    return new TTReportObject[] { LABTETKIKRTF,lableLabTest1111};
                }
                public override void RunPreScript()
                {
#region LABTETKIKYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            
            BindingList<TTObjectClasses.LaboratoryProcedure> labProcedureList ;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                labProcedureList = LaboratoryProcedure.GetLabProceduresBySubEpisode(context, subepisode,creatingEpicrisis.Episode.ObjectID);
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
                labProcedureList = LaboratoryProcedure.GetLabProceduresByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            
            if(labProcedureList.Count<=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                StringBuilder builder = new StringBuilder();
                foreach (LaboratoryProcedure labProc in labProcedureList)
                {
                    builder.Append(Convert.ToDateTime(labProc.ActionDate).ToShortDateString() + " ");
                    builder.Append(labProc.ProcedureObject.Name + " ");
                    builder.Append("(" + labProc.ProcedureObject.MySUTCode+ ") ");
                    if (labProc.Result != null && labProc.Result != "")
                    {
                        builder.Append(":" + labProc.Result + " ");
                        builder.Append(labProc.Unit + " ");
                        if (labProc.Warning != null)
                            builder.Append(TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(labProc.Warning.Value));
                    }
                    //                if (labProc.LongReport != null)
                    //                {
                    //                    builder.Append(" ");
                    //                    string report = TTObjectClasses.Common.GetTextOfRTFString(labProc.LongReport.ToString());
                    //                    report = report.Replace("  ", " ");
                    //                    report = report.Replace("\r\n", "");
                    //                    report = report.Replace("\r", "");
                    //                    report = report.Replace("\n", "");
                    //                    builder.Append(report);
                    //                }

                    if (labProc.LaboratorySubProcedures.Count > 0)
                    {
                        builder.Append("(");
                        foreach (LaboratorySubProcedure subLabProc in labProc.LaboratorySubProcedures)
                        {
                            builder.Append(subLabProc.ProcedureObject.Name + " ");
                            builder.Append("(" + subLabProc.ProcedureObject.MySUTCode + ") ");
                            if (subLabProc.Result != null && subLabProc.Result != "")
                            {
                                builder.Append(":" + subLabProc.Result + " ");
                                builder.Append(subLabProc.Unit + " ");
                                if (subLabProc.Warning != null)
                                    builder.Append(TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(subLabProc.Warning.Value));
                                builder.Append(",");
                            }
                        }
                        builder.Append(")");
                    }

                    builder.Append(", ");
                }
                this.LABTETKIKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
            
            //            if(((EpicrisisReport)ParentReport).AMELIYATVEANESTEZI.GroupDataSet == null || ((EpicrisisReport)ParentReport).AMELIYATVEANESTEZI.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATVEANESTEZI").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATVEANESTEZI").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).TIBBIMALZEME.GroupDataSet == null || ((EpicrisisReport)ParentReport).TIBBIMALZEME.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEME").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEME").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).ORTEZPROTEZ.GroupDataSet == null || ((EpicrisisReport)ParentReport).ORTEZPROTEZ.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZ").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZ").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).GUNLUKGOZLEM.GroupDataSet == null || ((EpicrisisReport)ParentReport).GUNLUKGOZLEM.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEM").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEMALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GUNLUKGOZLEM").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).RADTETKIK.GroupDataSet == null || ((EpicrisisReport)ParentReport).RADTETKIK.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIK").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIK").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).LABTETKIKALTBASLIK.GroupDataSet == null || ((EpicrisisReport)ParentReport).LABTETKIKALTBASLIK.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABALTTETKIK").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("LABALTTETKIK").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).PATTETKIK.GroupDataSet == null || ((EpicrisisReport)ParentReport).PATTETKIK.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIK").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIK").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).GENETIKTETKIK.GroupDataSet == null || ((EpicrisisReport)ParentReport).GENETIKTETKIK.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIK").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIK").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).NUKTETKIK.GroupDataSet == null || ((EpicrisisReport)ParentReport).NUKTETKIK.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIK").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIK").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
//
            //            if(((EpicrisisReport)ParentReport).MANIPLATION.GroupDataSet == null || ((EpicrisisReport)ParentReport).MANIPLATION.GroupDataSet.Count <= 0)
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATION").Body)).Visible = EvetHayirEnum.ehHayir;
            //            }
            //            else
            //            {
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
            //                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATION").Body)).Visible = EvetHayirEnum.ehEvet;
            //            }
#endregion LABTETKIKYENI BODY_PreScript
                }
            }

        }

        public LABTETKIKYENIGroup LABTETKIKYENI;

        public partial class RADTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public RADTETKIKBASLIKGroupHeader Header()
            {
                return (RADTETKIKBASLIKGroupHeader)_header;
            }

            new public RADTETKIKBASLIKGroupFooter Footer()
            {
                return (RADTETKIKBASLIKGroupFooter)_footer;
            }

            public RADTETKIKBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RADTETKIKBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new RADTETKIKBASLIKGroupHeader(this);
                _footer = new RADTETKIKBASLIKGroupFooter(this);

            }

            public partial class RADTETKIKBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public RADTETKIKBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class RADTETKIKBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public RADTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public RADTETKIKBASLIKGroup RADTETKIKBASLIK;

        public partial class RADTETKIKALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public RADTETKIKALTBASLIKGroupHeader Header()
            {
                return (RADTETKIKALTBASLIKGroupHeader)_header;
            }

            new public RADTETKIKALTBASLIKGroupFooter Footer()
            {
                return (RADTETKIKALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih1111 { get {return Header().lableTarih1111;} }
            public TTReportField LableOrtezAdı1111 { get {return Header().LableOrtezAdı1111;} }
            public TTReportField lableOrtezProtezCode111 { get {return Header().lableOrtezProtezCode111;} }
            public TTReportShape NewLine11111111 { get {return Header().NewLine11111111;} }
            public TTReportField lableLabTest1111 { get {return Header().lableLabTest1111;} }
            public TTReportShape NewLine1211111 { get {return Footer().NewLine1211111;} }
            public RADTETKIKALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RADTETKIKALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new RADTETKIKALTBASLIKGroupHeader(this);
                _footer = new RADTETKIKALTBASLIKGroupFooter(this);

            }

            public partial class RADTETKIKALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih1111;
                public TTReportField LableOrtezAdı1111;
                public TTReportField lableOrtezProtezCode111;
                public TTReportShape NewLine11111111;
                public TTReportField lableLabTest1111; 
                public RADTETKIKALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih1111.Name = "lableTarih1111";
                    lableTarih1111.TextFont.Name = "Arial Narrow";
                    lableTarih1111.TextFont.CharSet = 162;
                    lableTarih1111.Value = @"Tarih";

                    LableOrtezAdı1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableOrtezAdı1111.Name = "LableOrtezAdı1111";
                    LableOrtezAdı1111.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı1111.TextFont.CharSet = 162;
                    LableOrtezAdı1111.Value = @"Radyoloji Tetkiki";

                    lableOrtezProtezCode111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableOrtezProtezCode111.Name = "lableOrtezProtezCode111";
                    lableOrtezProtezCode111.TextFont.Name = "Arial Narrow";
                    lableOrtezProtezCode111.TextFont.CharSet = 162;
                    lableOrtezProtezCode111.Value = @"Kodu";

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableLabTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableLabTest1111.Name = "lableLabTest1111";
                    lableLabTest1111.TextFont.Name = "Arial Narrow";
                    lableLabTest1111.TextFont.Bold = true;
                    lableLabTest1111.TextFont.CharSet = 162;
                    lableLabTest1111.Value = @"RADYOLOJİ TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih1111.CalcValue = lableTarih1111.Value;
                    LableOrtezAdı1111.CalcValue = LableOrtezAdı1111.Value;
                    lableOrtezProtezCode111.CalcValue = lableOrtezProtezCode111.Value;
                    lableLabTest1111.CalcValue = lableLabTest1111.Value;
                    return new TTReportObject[] { lableTarih1111,LableOrtezAdı1111,lableOrtezProtezCode111,lableLabTest1111};
                }
            }
            public partial class RADTETKIKALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1211111; 
                public RADTETKIKALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1211111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1211111.Name = "NewLine1211111";
                    NewLine1211111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public RADTETKIKALTBASLIKGroup RADTETKIKALTBASLIK;

        public partial class RADTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public RADTETKIKYENIGroupBody Body()
            {
                return (RADTETKIKYENIGroupBody)_body;
            }
            public TTReportField lableLabTest11111 { get {return Body().lableLabTest11111;} }
            public TTReportRTF RADTETKIKRTF { get {return Body().RADTETKIKRTF;} }
            public RADTETKIKYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RADTETKIKYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RADTETKIKYENIGroupBody(this);
            }

            public partial class RADTETKIKYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableLabTest11111;
                public TTReportRTF RADTETKIKRTF; 
                public RADTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    lableLabTest11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableLabTest11111.Name = "lableLabTest11111";
                    lableLabTest11111.TextFont.Name = "Arial Narrow";
                    lableLabTest11111.TextFont.Bold = true;
                    lableLabTest11111.TextFont.CharSet = 162;
                    lableLabTest11111.Value = @"RADYOLOJİ TETKİKLERİ:";

                    RADTETKIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    RADTETKIKRTF.Name = "RADTETKIKRTF";
                    RADTETKIKRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableLabTest11111.CalcValue = lableLabTest11111.Value;
                    RADTETKIKRTF.CalcValue = RADTETKIKRTF.Value;
                    return new TTReportObject[] { lableLabTest11111,RADTETKIKRTF};
                }
                public override void RunPreScript()
                {
#region RADTETKIKYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            BindingList<TTObjectClasses.RadiologyTest> radTestList ;
            //subepisode olmazsa episode bazlı çalışıyor
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                radTestList = RadiologyTest.GetRadTestBySubEpisode(context, subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                radTestList = RadiologyTest.GetRadTestByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            
            if(radTestList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                bool IsRadTestListInProperState = false;                 
                StringBuilder builder = new StringBuilder();
                foreach (RadiologyTest radTest in radTestList)
                {
                    builder.Append(Convert.ToDateTime(radTest.ActionDate).ToShortDateString() + " ");
                    builder.Append(radTest.ProcedureObject.Name + " ");
                    builder.Append("(" + radTest.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                    IsRadTestListInProperState = true;
                }
                //Eger tum radyolojik islemler, (sonuc girisi, onay, tamam) durumlari disinda bir durumdaysa RADTETKIKALTBASLIK alani gorunmez yapilir.
                if(IsRadTestListInProperState)
                {
                    this.Visible = EvetHayirEnum.ehEvet;
                    ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                }
                else
                {
                     this.Visible = EvetHayirEnum.ehHayir;
                    ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
                }
                this.RADTETKIKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion RADTETKIKYENI BODY_PreScript
                }
            }

        }

        public RADTETKIKYENIGroup RADTETKIKYENI;

        public partial class PATTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public PATTETKIKBASLIKGroupHeader Header()
            {
                return (PATTETKIKBASLIKGroupHeader)_header;
            }

            new public PATTETKIKBASLIKGroupFooter Footer()
            {
                return (PATTETKIKBASLIKGroupFooter)_footer;
            }

            public PATTETKIKBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATTETKIKBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PATTETKIKBASLIKGroupHeader(this);
                _footer = new PATTETKIKBASLIKGroupFooter(this);

            }

            public partial class PATTETKIKBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public PATTETKIKBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PATTETKIKBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public PATTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PATTETKIKBASLIKGroup PATTETKIKBASLIK;

        public partial class PATTETKIKALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public PATTETKIKALTBASLIKGroupHeader Header()
            {
                return (PATTETKIKALTBASLIKGroupHeader)_header;
            }

            new public PATTETKIKALTBASLIKGroupFooter Footer()
            {
                return (PATTETKIKALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih111111 { get {return Header().lableTarih111111;} }
            public TTReportField LablePatAdı { get {return Header().LablePatAdı;} }
            public TTReportField lablePatCode { get {return Header().lablePatCode;} }
            public TTReportShape NewLine1111111111 { get {return Header().NewLine1111111111;} }
            public TTReportField lablePatTest1 { get {return Header().lablePatTest1;} }
            public TTReportShape NewLine11111121 { get {return Footer().NewLine11111121;} }
            public PATTETKIKALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATTETKIKALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PATTETKIKALTBASLIKGroupHeader(this);
                _footer = new PATTETKIKALTBASLIKGroupFooter(this);

            }

            public partial class PATTETKIKALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih111111;
                public TTReportField LablePatAdı;
                public TTReportField lablePatCode;
                public TTReportShape NewLine1111111111;
                public TTReportField lablePatTest1; 
                public PATTETKIKALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih111111.Name = "lableTarih111111";
                    lableTarih111111.TextFont.Name = "Arial Narrow";
                    lableTarih111111.TextFont.CharSet = 162;
                    lableTarih111111.Value = @"Tarih";

                    LablePatAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LablePatAdı.Name = "LablePatAdı";
                    LablePatAdı.TextFont.Name = "Arial Narrow";
                    LablePatAdı.TextFont.CharSet = 162;
                    LablePatAdı.Value = @"Patoloji Tetkiki";

                    lablePatCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lablePatCode.Name = "lablePatCode";
                    lablePatCode.TextFont.Name = "Arial Narrow";
                    lablePatCode.TextFont.CharSet = 162;
                    lablePatCode.Value = @"Kodu";

                    NewLine1111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine1111111111.Name = "NewLine1111111111";
                    NewLine1111111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lablePatTest1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lablePatTest1.Name = "lablePatTest1";
                    lablePatTest1.TextFont.Name = "Arial Narrow";
                    lablePatTest1.TextFont.Bold = true;
                    lablePatTest1.TextFont.CharSet = 162;
                    lablePatTest1.Value = @"PATOLOJİ TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih111111.CalcValue = lableTarih111111.Value;
                    LablePatAdı.CalcValue = LablePatAdı.Value;
                    lablePatCode.CalcValue = lablePatCode.Value;
                    lablePatTest1.CalcValue = lablePatTest1.Value;
                    return new TTReportObject[] { lableTarih111111,LablePatAdı,lablePatCode,lablePatTest1};
                }
            }
            public partial class PATTETKIKALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111121; 
                public PATTETKIKALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine11111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 200, 3, false);
                    NewLine11111121.Name = "NewLine11111121";
                    NewLine11111121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PATTETKIKALTBASLIKGroup PATTETKIKALTBASLIK;

        public partial class PATTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public PATTETKIKYENIGroupBody Body()
            {
                return (PATTETKIKYENIGroupBody)_body;
            }
            public TTReportRTF PATTETKIKRTF { get {return Body().PATTETKIKRTF;} }
            public TTReportField lablePatTest11 { get {return Body().lablePatTest11;} }
            public PATTETKIKYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATTETKIKYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PATTETKIKYENIGroupBody(this);
            }

            public partial class PATTETKIKYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF PATTETKIKRTF;
                public TTReportField lablePatTest11; 
                public PATTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    PATTETKIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    PATTETKIKRTF.Name = "PATTETKIKRTF";
                    PATTETKIKRTF.Value = @"";

                    lablePatTest11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lablePatTest11.Name = "lablePatTest11";
                    lablePatTest11.TextFont.Name = "Arial Narrow";
                    lablePatTest11.TextFont.Bold = true;
                    lablePatTest11.TextFont.CharSet = 162;
                    lablePatTest11.Value = @"PATOLOJİ TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATTETKIKRTF.CalcValue = PATTETKIKRTF.Value;
                    lablePatTest11.CalcValue = lablePatTest11.Value;
                    return new TTReportObject[] { PATTETKIKRTF,lablePatTest11};
                }
                public override void RunPreScript()
                {
#region PATTETKIKYENI BODY_PreScript
                    //TODO ASLI                       
          /*  TTObjectContext context = new TTObjectContext(true);
            BindingList<TTObjectClasses.Pathology> patTestList ;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                patTestList = Pathology.GetPatTestBySubEpisode(context, subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor      
                patTestList = Pathology.GetPatTestByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            
            if(patTestList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("PATTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (Pathology patTest in patTestList)
                {
                    builder.Append(Convert.ToDateTime(patTest.ActionDate).ToShortDateString() + " ");
                    builder.Append(patTest.ProcedureObject.Name + " ");
                    builder.Append("(" + patTest.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.PATTETKIKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
            */
#endregion PATTETKIKYENI BODY_PreScript
                }
            }

        }

        public PATTETKIKYENIGroup PATTETKIKYENI;

        public partial class NUKTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public NUKTETKIKBASLIKGroupHeader Header()
            {
                return (NUKTETKIKBASLIKGroupHeader)_header;
            }

            new public NUKTETKIKBASLIKGroupFooter Footer()
            {
                return (NUKTETKIKBASLIKGroupFooter)_footer;
            }

            public NUKTETKIKBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NUKTETKIKBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NUKTETKIKBASLIKGroupHeader(this);
                _footer = new NUKTETKIKBASLIKGroupFooter(this);

            }

            public partial class NUKTETKIKBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public NUKTETKIKBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class NUKTETKIKBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public NUKTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public NUKTETKIKBASLIKGroup NUKTETKIKBASLIK;

        public partial class NUKTETKIKALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public NUKTETKIKALTBASLIKGroupHeader Header()
            {
                return (NUKTETKIKALTBASLIKGroupHeader)_header;
            }

            new public NUKTETKIKALTBASLIKGroupFooter Footer()
            {
                return (NUKTETKIKALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarihNUK { get {return Header().lableTarihNUK;} }
            public TTReportField LableNukAdı { get {return Header().LableNukAdı;} }
            public TTReportField lableNukCode { get {return Header().lableNukCode;} }
            public TTReportShape NewLine1211111211 { get {return Header().NewLine1211111211;} }
            public TTReportField lableNucTest11 { get {return Header().lableNucTest11;} }
            public TTReportShape NewLine1111111211 { get {return Footer().NewLine1111111211;} }
            public NUKTETKIKALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NUKTETKIKALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NUKTETKIKALTBASLIKGroupHeader(this);
                _footer = new NUKTETKIKALTBASLIKGroupFooter(this);

            }

            public partial class NUKTETKIKALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarihNUK;
                public TTReportField LableNukAdı;
                public TTReportField lableNukCode;
                public TTReportShape NewLine1211111211;
                public TTReportField lableNucTest11; 
                public NUKTETKIKALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarihNUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarihNUK.Name = "lableTarihNUK";
                    lableTarihNUK.TextFont.Name = "Arial Narrow";
                    lableTarihNUK.TextFont.CharSet = 162;
                    lableTarihNUK.Value = @"Tarih";

                    LableNukAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableNukAdı.Name = "LableNukAdı";
                    LableNukAdı.TextFont.Name = "Arial Narrow";
                    LableNukAdı.TextFont.CharSet = 162;
                    LableNukAdı.Value = @"Nükleer Tıp Tetkiki";

                    lableNukCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableNukCode.Name = "lableNukCode";
                    lableNukCode.TextFont.Name = "Arial Narrow";
                    lableNukCode.TextFont.CharSet = 162;
                    lableNukCode.Value = @"Kodu";

                    NewLine1211111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 188, 13, false);
                    NewLine1211111211.Name = "NewLine1211111211";
                    NewLine1211111211.DrawStyle = DrawStyleConstants.vbSolid;

                    lableNucTest11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest11.Name = "lableNucTest11";
                    lableNucTest11.TextFont.Name = "Arial Narrow";
                    lableNucTest11.TextFont.Bold = true;
                    lableNucTest11.TextFont.CharSet = 162;
                    lableNucTest11.Value = @"NUKLEER TIP TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarihNUK.CalcValue = lableTarihNUK.Value;
                    LableNukAdı.CalcValue = LableNukAdı.Value;
                    lableNukCode.CalcValue = lableNukCode.Value;
                    lableNucTest11.CalcValue = lableNucTest11.Value;
                    return new TTReportObject[] { lableTarihNUK,LableNukAdı,lableNukCode,lableNucTest11};
                }
            }
            public partial class NUKTETKIKALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111111211; 
                public NUKTETKIKALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine1111111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1111111211.Name = "NewLine1111111211";
                    NewLine1111111211.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public NUKTETKIKALTBASLIKGroup NUKTETKIKALTBASLIK;

        public partial class NUKTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public NUKTETKIKYENIGroupBody Body()
            {
                return (NUKTETKIKYENIGroupBody)_body;
            }
            public TTReportRTF NUKLEERRTF { get {return Body().NUKLEERRTF;} }
            public TTReportField lableNucTest111 { get {return Body().lableNucTest111;} }
            public NUKTETKIKYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NUKTETKIKYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new NUKTETKIKYENIGroupBody(this);
            }

            public partial class NUKTETKIKYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF NUKLEERRTF;
                public TTReportField lableNucTest111; 
                public NUKTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    NUKLEERRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    NUKLEERRTF.Name = "NUKLEERRTF";
                    NUKLEERRTF.Value = @"";

                    lableNucTest111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest111.Name = "lableNucTest111";
                    lableNucTest111.TextFont.Name = "Arial Narrow";
                    lableNucTest111.TextFont.Bold = true;
                    lableNucTest111.TextFont.CharSet = 162;
                    lableNucTest111.Value = @"NUKLEER TIP TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NUKLEERRTF.CalcValue = NUKLEERRTF.Value;
                    lableNucTest111.CalcValue = lableNucTest111.Value;
                    return new TTReportObject[] { NUKLEERRTF,lableNucTest111};
                }
                public override void RunPreScript()
                {
#region NUKTETKIKYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);

            BindingList<TTObjectClasses.NuclearMedicineTest> nuclearMedicineTestList;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                nuclearMedicineTestList = NuclearMedicineTest.GetNuclearTestBySubEpisode(context,subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
                
                nuclearMedicineTestList = NuclearMedicineTest.GetNuclearTestByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            
            if(nuclearMedicineTestList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("NUKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (NuclearMedicineTest nuclearMedicineTest in nuclearMedicineTestList)
                {
                    builder.Append(Convert.ToDateTime(nuclearMedicineTest.ActionDate).ToShortDateString() + " ");
                    builder.Append(nuclearMedicineTest.ProcedureObject.Name + " ");
                    builder.Append("(" + nuclearMedicineTest.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.NUKLEERRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion NUKTETKIKYENI BODY_PreScript
                }
            }

        }

        public NUKTETKIKYENIGroup NUKTETKIKYENI;

        public partial class GENETIKTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public GENETIKTETKIKBASLIKGroupHeader Header()
            {
                return (GENETIKTETKIKBASLIKGroupHeader)_header;
            }

            new public GENETIKTETKIKBASLIKGroupFooter Footer()
            {
                return (GENETIKTETKIKBASLIKGroupFooter)_footer;
            }

            public GENETIKTETKIKBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GENETIKTETKIKBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GENETIKTETKIKBASLIKGroupHeader(this);
                _footer = new GENETIKTETKIKBASLIKGroupFooter(this);

            }

            public partial class GENETIKTETKIKBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public GENETIKTETKIKBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class GENETIKTETKIKBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public GENETIKTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public GENETIKTETKIKBASLIKGroup GENETIKTETKIKBASLIK;

        public partial class GENETIKTETKIKALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public GENETIKTETKIKALTBASLIKGroupHeader Header()
            {
                return (GENETIKTETKIKALTBASLIKGroupHeader)_header;
            }

            new public GENETIKTETKIKALTBASLIKGroupFooter Footer()
            {
                return (GENETIKTETKIKALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih1111111 { get {return Header().lableTarih1111111;} }
            public TTReportField LableGenetikAdı { get {return Header().LableGenetikAdı;} }
            public TTReportField lableGenetikCode { get {return Header().lableGenetikCode;} }
            public TTReportShape NewLine112111112 { get {return Header().NewLine112111112;} }
            public TTReportField lableGenetikTest1 { get {return Header().lableGenetikTest1;} }
            public TTReportShape NewLine112111111 { get {return Footer().NewLine112111111;} }
            public GENETIKTETKIKALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GENETIKTETKIKALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GENETIKTETKIKALTBASLIKGroupHeader(this);
                _footer = new GENETIKTETKIKALTBASLIKGroupFooter(this);

            }

            public partial class GENETIKTETKIKALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih1111111;
                public TTReportField LableGenetikAdı;
                public TTReportField lableGenetikCode;
                public TTReportShape NewLine112111112;
                public TTReportField lableGenetikTest1; 
                public GENETIKTETKIKALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih1111111.Name = "lableTarih1111111";
                    lableTarih1111111.TextFont.Name = "Arial Narrow";
                    lableTarih1111111.TextFont.CharSet = 162;
                    lableTarih1111111.Value = @"Tarih";

                    LableGenetikAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableGenetikAdı.Name = "LableGenetikAdı";
                    LableGenetikAdı.TextFont.Name = "Arial Narrow";
                    LableGenetikAdı.TextFont.CharSet = 162;
                    LableGenetikAdı.Value = @"Tıbbi Genetik Tetkiki";

                    lableGenetikCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableGenetikCode.Name = "lableGenetikCode";
                    lableGenetikCode.TextFont.Name = "Arial Narrow";
                    lableGenetikCode.TextFont.CharSet = 162;
                    lableGenetikCode.Value = @"Kodu";

                    NewLine112111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 188, 13, false);
                    NewLine112111112.Name = "NewLine112111112";
                    NewLine112111112.DrawStyle = DrawStyleConstants.vbSolid;

                    lableGenetikTest1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableGenetikTest1.Name = "lableGenetikTest1";
                    lableGenetikTest1.TextFont.Name = "Arial Narrow";
                    lableGenetikTest1.TextFont.Bold = true;
                    lableGenetikTest1.TextFont.CharSet = 162;
                    lableGenetikTest1.Value = @"TIBBİ GENETİK TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih1111111.CalcValue = lableTarih1111111.Value;
                    LableGenetikAdı.CalcValue = LableGenetikAdı.Value;
                    lableGenetikCode.CalcValue = lableGenetikCode.Value;
                    lableGenetikTest1.CalcValue = lableGenetikTest1.Value;
                    return new TTReportObject[] { lableTarih1111111,LableGenetikAdı,lableGenetikCode,lableGenetikTest1};
                }
            }
            public partial class GENETIKTETKIKALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine112111111; 
                public GENETIKTETKIKALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine112111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine112111111.Name = "NewLine112111111";
                    NewLine112111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public GENETIKTETKIKALTBASLIKGroup GENETIKTETKIKALTBASLIK;

        public partial class GENETIKTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public GENETIKTETKIKYENIGroupBody Body()
            {
                return (GENETIKTETKIKYENIGroupBody)_body;
            }
            public TTReportRTF GENETIKRTF { get {return Body().GENETIKRTF;} }
            public TTReportField lableGenetikTest11 { get {return Body().lableGenetikTest11;} }
            public GENETIKTETKIKYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GENETIKTETKIKYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new GENETIKTETKIKYENIGroupBody(this);
            }

            public partial class GENETIKTETKIKYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF GENETIKRTF;
                public TTReportField lableGenetikTest11; 
                public GENETIKTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    GENETIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    GENETIKRTF.Name = "GENETIKRTF";
                    GENETIKRTF.Value = @"";

                    lableGenetikTest11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableGenetikTest11.Name = "lableGenetikTest11";
                    lableGenetikTest11.TextFont.Name = "Arial Narrow";
                    lableGenetikTest11.TextFont.Bold = true;
                    lableGenetikTest11.TextFont.CharSet = 162;
                    lableGenetikTest11.Value = @"TIBBİ GENETİK TETKİKLERİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GENETIKRTF.CalcValue = GENETIKRTF.Value;
                    lableGenetikTest11.CalcValue = lableGenetikTest11.Value;
                    return new TTReportObject[] { GENETIKRTF,lableGenetikTest11};
                }
                public override void RunPreScript()
                {
#region GENETIKTETKIKYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);

            BindingList<TTObjectClasses.GeneticTest> geneticTestList;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                geneticTestList = GeneticTest.GetGeneticBySubEpisode(context,subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
                geneticTestList = GeneticTest.GetGeneticByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            
            if(geneticTestList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (GeneticTest geneticTest in geneticTestList)
                {
                    builder.Append(Convert.ToDateTime(geneticTest.ActionDate).ToShortDateString() + " ");
                    builder.Append(geneticTest.ProcedureObject.Name + " ");
                    builder.Append("(" + geneticTest.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.GENETIKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion GENETIKTETKIKYENI BODY_PreScript
                }
            }

        }

        public GENETIKTETKIKYENIGroup GENETIKTETKIKYENI;

        public partial class KONSULTASYONBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public KONSULTASYONBASLIKGroupHeader Header()
            {
                return (KONSULTASYONBASLIKGroupHeader)_header;
            }

            new public KONSULTASYONBASLIKGroupFooter Footer()
            {
                return (KONSULTASYONBASLIKGroupFooter)_footer;
            }

            public TTReportShape NewLine1111111211 { get {return Footer().NewLine1111111211;} }
            public KONSULTASYONBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KONSULTASYONBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KONSULTASYONBASLIKGroupHeader(this);
                _footer = new KONSULTASYONBASLIKGroupFooter(this);

            }

            public partial class KONSULTASYONBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public KONSULTASYONBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class KONSULTASYONBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111111211; 
                public KONSULTASYONBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1111111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1111111211.Name = "NewLine1111111211";
                    NewLine1111111211.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public KONSULTASYONBASLIKGroup KONSULTASYONBASLIK;

        public partial class KONSULTASYONGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public KONSULTASYONGroupBody Body()
            {
                return (KONSULTASYONGroupBody)_body;
            }
            public TTReportField NewField1121191111 { get {return Body().NewField1121191111;} }
            public TTReportRTF KONSULTASYONRTF { get {return Body().KONSULTASYONRTF;} }
            public KONSULTASYONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KONSULTASYONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KONSULTASYONGroupBody(this);
            }

            public partial class KONSULTASYONGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField NewField1121191111;
                public TTReportRTF KONSULTASYONRTF; 
                public KONSULTASYONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    NewField1121191111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField1121191111.Name = "NewField1121191111";
                    NewField1121191111.TextFont.Name = "Arial Narrow";
                    NewField1121191111.TextFont.Bold = true;
                    NewField1121191111.TextFont.CharSet = 162;
                    NewField1121191111.Value = @"KONSÜLTASYONLAR :";

                    KONSULTASYONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    KONSULTASYONRTF.Name = "KONSULTASYONRTF";
                    KONSULTASYONRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121191111.CalcValue = NewField1121191111.Value;
                    KONSULTASYONRTF.CalcValue = KONSULTASYONRTF.Value;
                    return new TTReportObject[] { NewField1121191111,KONSULTASYONRTF};
                }
                public override void RunPreScript()
                {
#region KONSULTASYON BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            
            BindingList<EpisodeAction> consFromOtherHospList;
            BindingList<EpisodeAction> anesthesiaConsList ;
            BindingList<SubActionProcedure> consProcedureList;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID), "CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                consFromOtherHospList = EpisodeAction.GetConsFromOtherHospOfSubEpisode(context, subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
                anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfSubEpisode(context,subepisode.ToString(), creatingEpicrisis.Episode.ObjectID.ToString());
                consProcedureList = SubActionProcedure.GetAllConsultationProcOfSubEpisode(context, subepisode.ToString(), creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
                
                consFromOtherHospList = EpisodeAction.GetConsFromOtherHospOfEpisode(context, creatingEpicrisis.Episode.ObjectID.ToString());
                anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfEpisode(context, creatingEpicrisis.Episode.ObjectID.ToString());
                consProcedureList = SubActionProcedure.GetAllConsultationProcOfEpisode(context, creatingEpicrisis.Episode.ObjectID.ToString());
            }
            
            StringBuilder builder = new StringBuilder();
            int counter =1;
            bool IsConsListInProperState = false;
            
            foreach (EpisodeAction ea in consFromOtherHospList)
            {                
                if (ea is ConsultationFromOtherHospital && ea.CurrentStateDefID == ConsultationFromOtherHospital.States.Completed)
                {
                    builder.Append(counter + ". Konsültasyon Tarihi : " + Convert.ToDateTime(ea.ActionDate).ToShortDateString());
                    counter++;
                    builder.AppendLine();
                    
                    ConsultationFromOtherHospital consFromOtherHosp = (ConsultationFromOtherHospital)ea;
                    if (consFromOtherHosp.RequesterHospital != null)
                        builder.Append("İstek Yapan XXXXXX : " + consFromOtherHosp.RequesterHospital.Name + "  ");
                    builder.Append("İstek Yapan Birim : " + consFromOtherHosp.RequesterResourceName);
                    builder.AppendLine();
                    if (consFromOtherHosp.RequestedReferableHospital != null && consFromOtherHosp.RequestedReferableHospital.ResOtherHospital != null)
                        builder.Append("İstek Yapılan XXXXXX : " + consFromOtherHosp.RequestedReferableHospital.ResOtherHospital.Name + "  ");
                    else if (consFromOtherHosp.RequestedExternalHospital != null)
                        builder.Append("İstek Yapılan XXXXXX : " + consFromOtherHosp.RequestedExternalHospital.Name + "  ");
                    if (consFromOtherHosp.RequestedReferableResource != null)
                    {
                        builder.Append("İstek Yapılan Birim : " + consFromOtherHosp.RequestedReferableResource.ResourceName);
                        builder.AppendLine();
                    }
                    else if (consFromOtherHosp.RequestedExternalDepartment != null)
                    {
                        builder.Append("İstek Yapılan Birim : " + consFromOtherHosp.RequestedExternalDepartment.Name);
                        builder.AppendLine();
                    }
                    builder.Append("İstek Sebebi : " + consFromOtherHosp.RequestDescription);
                    builder.AppendLine();
                    if(consFromOtherHosp.ConsultationResultAndOffers != null)
                    {
                        builder.Append("Konsültasyon Sonucu ve Öneriler : " + consFromOtherHosp.ConsultationResultAndOffers.ToString());
                        builder.AppendLine();
                    }
                    IsConsListInProperState = true;
                }
            }

            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)context.GetObject(hospID, typeof(ResHospital));

            
            foreach (SubActionProcedure spf in consProcedureList)
            {                
                if (spf is ConsultationProcedure && ((ConsultationProcedure)spf).Consultation.CurrentStateDefID == Consultation.States.Completed)
                {
                    builder.Append(counter + ". Konsültasyon Tarihi : " + Convert.ToDateTime(spf.ActionDate).ToShortDateString());
                    counter++;
                    builder.AppendLine();
                
                    ConsultationProcedure consProcedure = (ConsultationProcedure)spf;
                    if (hospital != null)
                        builder.Append("İstek Yapan XXXXXX : " + hospital.Name + "  ");
                    builder.Append("İstek Yapan Birim : " + (consProcedure.Consultation.RequesterResource != null ? consProcedure.Consultation.RequesterResource.Name : ""));
                    builder.AppendLine();
                    if(hospital != null)
                        builder.Append("İstek Yapılan XXXXXX : " + hospital.Name + "  ");
                    builder.Append("İstek Yapılan Birim : " + (consProcedure.Consultation.MasterResource != null ? consProcedure.Consultation.MasterResource.Name : ""));
                    builder.AppendLine();
                    if(consProcedure.Consultation.RequestDescription != null)
                    {
                        builder.Append("İstek Sebebi : " + TTObjectClasses.Common.GetTextOfRTFString(consProcedure.Consultation.RequestDescription.ToString()));
                        builder.AppendLine();
                    }
                    if(consProcedure.Consultation.ConsultationResultAndOffers != null)
                    {
                        builder.Append("Konsültasyon Sonucu ve Öneriler : " + TTObjectClasses.Common.GetTextOfRTFString(consProcedure.Consultation.ConsultationResultAndOffers.ToString()));
                        builder.AppendLine();
                    }
                    IsConsListInProperState = true;
                }
            }
            
            
            foreach (EpisodeAction ea in anesthesiaConsList)
            {                
                if (ea is AnesthesiaConsultation && ea.CurrentStateDefID == AnesthesiaConsultation.States.Completed)
                {
                    builder.Append(counter + ". Konsültasyon Tarihi : " + Convert.ToDateTime(ea.ActionDate).ToShortDateString());
                    counter++;
                    builder.AppendLine();
                    
                    AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)ea;
                    if (hospital != null)
                        builder.Append("İstek Yapan XXXXXX : " + hospital.Name + "  ");
                    builder.Append("İstek Yapan Birim : " + (anesthesiaConsultation.FromResource != null ? anesthesiaConsultation.FromResource.Name : ""));
                    builder.AppendLine();
                    if(hospital != null)
                        builder.Append("İstek Yapılan XXXXXX : " + hospital.Name + "  ");
                    builder.Append("İstek Yapılan Birim : " + (anesthesiaConsultation.MasterResource != null ? anesthesiaConsultation.MasterResource.Name : ""));
                    builder.AppendLine();
                    if(anesthesiaConsultation.ConsultationRequestNote != null)
                    {
                        builder.Append("İstek Sebebi : " + TTObjectClasses.Common.GetTextOfRTFString(anesthesiaConsultation.ConsultationRequestNote.ToString()));
                        builder.AppendLine();
                    }
                    if(anesthesiaConsultation.ConsultationResult != null)
                    {
                        builder.Append("Konsültasyon Sonucu ve Öneriler : " + TTObjectClasses.Common.GetTextOfRTFString(anesthesiaConsultation.ConsultationResult.ToString()));
                        builder.AppendLine();
                    }
                    IsConsListInProperState = true;
                }
            }
            if(builder.ToString() == String.Empty || IsConsListInProperState == false)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("KONSULTASYONBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("KONSULTASYONBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                this.KONSULTASYONRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion KONSULTASYON BODY_PreScript
                }
            }

        }

        public KONSULTASYONGroup KONSULTASYON;

        public partial class TANILARBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TANILARBASLIKGroupHeader Header()
            {
                return (TANILARBASLIKGroupHeader)_header;
            }

            new public TANILARBASLIKGroupFooter Footer()
            {
                return (TANILARBASLIKGroupFooter)_footer;
            }

            public TANILARBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANILARBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANILARBASLIKGroupHeader(this);
                _footer = new TANILARBASLIKGroupFooter(this);

            }

            public partial class TANILARBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public TANILARBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class TANILARBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public TANILARBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TANILARBASLIKGroup TANILARBASLIK;

        public partial class TANILARALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TANILARALTBASLIKGroupHeader Header()
            {
                return (TANILARALTBASLIKGroupHeader)_header;
            }

            new public TANILARALTBASLIKGroupFooter Footer()
            {
                return (TANILARALTBASLIKGroupFooter)_footer;
            }

            public TTReportField NewField1111191121 { get {return Header().NewField1111191121;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1111191122 { get {return Header().NewField1111191122;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
            public TANILARALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANILARALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANILARALTBASLIKGroupHeader(this);
                _footer = new TANILARALTBASLIKGroupFooter(this);

            }

            public partial class TANILARALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField NewField1111191121;
                public TTReportField NewField0;
                public TTReportField NewField10;
                public TTReportShape NewLine1111;
                public TTReportField NewField1111191122; 
                public TANILARALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111191121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    NewField1111191121.Name = "NewField1111191121";
                    NewField1111191121.TextFont.Name = "Arial Narrow";
                    NewField1111191121.TextFont.CharSet = 162;
                    NewField1111191121.Value = @"Tarih";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 64, 12, false);
                    NewField0.Name = "NewField0";
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.CharSet = 162;
                    NewField0.Value = @"Tanı Adı";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 7, 179, 12, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Tanı Kodu";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111191122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 33, 6, false);
                    NewField1111191122.Name = "NewField1111191122";
                    NewField1111191122.TextFont.Name = "Arial Narrow";
                    NewField1111191122.TextFont.Bold = true;
                    NewField1111191122.TextFont.CharSet = 162;
                    NewField1111191122.Value = @"TANI:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111191121.CalcValue = NewField1111191121.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField1111191122.CalcValue = NewField1111191122.Value;
                    return new TTReportObject[] { NewField1111191121,NewField0,NewField10,NewField1111191122};
                }
            }
            public partial class TANILARALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1112; 
                public TANILARALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public TANILARALTBASLIKGroup TANILARALTBASLIK;

        public partial class TANILARGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TANILARGroupBody Body()
            {
                return (TANILARGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DIAGNOSEDATE { get {return Body().DIAGNOSEDATE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TANILARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANILARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnosisBySubEpisode_Class>("GetDiagnosisBySubEpisode", DiagnosisGrid.GetDiagnosisBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TANILARGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANILARGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DIAGNOSEDATE;
                public TTReportField NAME; 
                public TANILARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 188, 6, false);
                    CODE.Name = "CODE";
                    CODE.ForeColor = System.Drawing.Color.White;
                    CODE.DrawStyle = DrawStyleConstants.vbSolid;
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#CODE#}";

                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.ForeColor = System.Drawing.Color.White;
                    DIAGNOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.TextFormat = @"Short Date";
                    DIAGNOSEDATE.TextFont.Name = "Arial Narrow";
                    DIAGNOSEDATE.TextFont.CharSet = 162;
                    DIAGNOSEDATE.Value = @"{#DIAGNOSEDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 156, 6, false);
                    NAME.Name = "NAME";
                    NAME.ForeColor = System.Drawing.Color.White;
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnosisBySubEpisode_Class dataset_GetDiagnosisBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnosisBySubEpisode_Class>(0);
                    CODE.CalcValue = (dataset_GetDiagnosisBySubEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisBySubEpisode.Code) : "");
                    DIAGNOSEDATE.CalcValue = (dataset_GetDiagnosisBySubEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisBySubEpisode.Diagnosedate) : "");
                    NAME.CalcValue = (dataset_GetDiagnosisBySubEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisBySubEpisode.Name) : "");
                    return new TTReportObject[] { CODE,DIAGNOSEDATE,NAME};
                }
            }

        }

        public TANILARGroup TANILAR;

        public partial class GUNLUKGOZLEMBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public GUNLUKGOZLEMBASLIKGroupHeader Header()
            {
                return (GUNLUKGOZLEMBASLIKGroupHeader)_header;
            }

            new public GUNLUKGOZLEMBASLIKGroupFooter Footer()
            {
                return (GUNLUKGOZLEMBASLIKGroupFooter)_footer;
            }

            public GUNLUKGOZLEMBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GUNLUKGOZLEMBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GUNLUKGOZLEMBASLIKGroupHeader(this);
                _footer = new GUNLUKGOZLEMBASLIKGroupFooter(this);

            }

            public partial class GUNLUKGOZLEMBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public GUNLUKGOZLEMBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class GUNLUKGOZLEMBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public GUNLUKGOZLEMBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public GUNLUKGOZLEMBASLIKGroup GUNLUKGOZLEMBASLIK;

        public partial class GUNLUKGOZLEMALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public GUNLUKGOZLEMALTBASLIKGroupHeader Header()
            {
                return (GUNLUKGOZLEMALTBASLIKGroupHeader)_header;
            }

            new public GUNLUKGOZLEMALTBASLIKGroupFooter Footer()
            {
                return (GUNLUKGOZLEMALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih11 { get {return Header().lableTarih11;} }
            public TTReportField LableOrtezAdı11 { get {return Header().LableOrtezAdı11;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportField lableTıbbiMlz111 { get {return Header().lableTıbbiMlz111;} }
            public TTReportShape NewLine111112 { get {return Footer().NewLine111112;} }
            public GUNLUKGOZLEMALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GUNLUKGOZLEMALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GUNLUKGOZLEMALTBASLIKGroupHeader(this);
                _footer = new GUNLUKGOZLEMALTBASLIKGroupFooter(this);

            }

            public partial class GUNLUKGOZLEMALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih11;
                public TTReportField LableOrtezAdı11;
                public TTReportShape NewLine111111;
                public TTReportField lableTıbbiMlz111; 
                public GUNLUKGOZLEMALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih11.Name = "lableTarih11";
                    lableTarih11.TextFont.Name = "Arial Narrow";
                    lableTarih11.TextFont.CharSet = 162;
                    lableTarih11.Value = @"Tarih";

                    LableOrtezAdı11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 7, 110, 12, false);
                    LableOrtezAdı11.Name = "LableOrtezAdı11";
                    LableOrtezAdı11.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı11.TextFont.CharSet = 162;
                    LableOrtezAdı11.Value = @"Günlük Gözlem  Açıklaması";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 189, 13, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableTıbbiMlz111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 43, 6, false);
                    lableTıbbiMlz111.Name = "lableTıbbiMlz111";
                    lableTıbbiMlz111.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz111.TextFont.Bold = true;
                    lableTıbbiMlz111.TextFont.CharSet = 162;
                    lableTıbbiMlz111.Value = @"GÜNLÜK GÖZLEM:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih11.CalcValue = lableTarih11.Value;
                    LableOrtezAdı11.CalcValue = LableOrtezAdı11.Value;
                    lableTıbbiMlz111.CalcValue = lableTıbbiMlz111.Value;
                    return new TTReportObject[] { lableTarih11,LableOrtezAdı11,lableTıbbiMlz111};
                }
            }
            public partial class GUNLUKGOZLEMALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine111112; 
                public GUNLUKGOZLEMALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 200, 3, false);
                    NewLine111112.Name = "NewLine111112";
                    NewLine111112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public GUNLUKGOZLEMALTBASLIKGroup GUNLUKGOZLEMALTBASLIK;

        public partial class GUNLUKGOZLEMGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public GUNLUKGOZLEMGroupBody Body()
            {
                return (GUNLUKGOZLEMGroupBody)_body;
            }
            public TTReportField DATEPRO { get {return Body().DATEPRO;} }
            public TTReportRTF PROSSDESC { get {return Body().PROSSDESC;} }
            public TTReportField GUNLUKOBJECTID { get {return Body().GUNLUKOBJECTID;} }
            public TTReportField PRODESC { get {return Body().PRODESC;} }
            public GUNLUKGOZLEMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GUNLUKGOZLEMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class>("GetInpatienPhProgressesBySubEpisode", InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new GUNLUKGOZLEMGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class GUNLUKGOZLEMGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField DATEPRO;
                public TTReportRTF PROSSDESC;
                public TTReportField GUNLUKOBJECTID;
                public TTReportField PRODESC; 
                public GUNLUKGOZLEMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    DATEPRO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 49, 6, false);
                    DATEPRO.Name = "DATEPRO";
                    DATEPRO.ForeColor = System.Drawing.Color.White;
                    DATEPRO.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEPRO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEPRO.TextFormat = @"dd/MM/yyyy HH:mm";
                    DATEPRO.TextFont.Name = "Arial Narrow";
                    DATEPRO.TextFont.CharSet = 162;
                    DATEPRO.Value = @"{#PROGRESSDATE#}";

                    PROSSDESC = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 216, 1, 349, 7, false);
                    PROSSDESC.Name = "PROSSDESC";
                    PROSSDESC.Visible = EvetHayirEnum.ehHayir;
                    PROSSDESC.EvaluateValue = EvetHayirEnum.ehEvet;
                    PROSSDESC.Value = @"";

                    GUNLUKOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, -2, 245, 4, false);
                    GUNLUKOBJECTID.Name = "GUNLUKOBJECTID";
                    GUNLUKOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    GUNLUKOBJECTID.ForeColor = System.Drawing.Color.White;
                    GUNLUKOBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    GUNLUKOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUNLUKOBJECTID.TextFont.Name = "Arial Narrow";
                    GUNLUKOBJECTID.TextFont.CharSet = 162;
                    GUNLUKOBJECTID.Value = @"{#OBJECTID#}";

                    PRODESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 200, 6, false);
                    PRODESC.Name = "PRODESC";
                    PRODESC.ForeColor = System.Drawing.Color.White;
                    PRODESC.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODESC.MultiLine = EvetHayirEnum.ehEvet;
                    PRODESC.NoClip = EvetHayirEnum.ehEvet;
                    PRODESC.WordBreak = EvetHayirEnum.ehEvet;
                    PRODESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRODESC.TextFont.Name = "Arial Narrow";
                    PRODESC.TextFont.CharSet = 162;
                    PRODESC.Value = @"{#DESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class dataset_GetInpatienPhProgressesBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class>(0);
                    DATEPRO.CalcValue = (dataset_GetInpatienPhProgressesBySubEpisode != null ? Globals.ToStringCore(dataset_GetInpatienPhProgressesBySubEpisode.ProgressDate) : "");
                    PROSSDESC.CalcValue = PROSSDESC.Value;
                    GUNLUKOBJECTID.CalcValue = (dataset_GetInpatienPhProgressesBySubEpisode != null ? Globals.ToStringCore(dataset_GetInpatienPhProgressesBySubEpisode.ObjectID) : "");
                    PRODESC.CalcValue = (dataset_GetInpatienPhProgressesBySubEpisode != null ? Globals.ToStringCore(dataset_GetInpatienPhProgressesBySubEpisode.Description) : "");
                    return new TTReportObject[] { DATEPRO,PROSSDESC,GUNLUKOBJECTID,PRODESC};
                }

                public override void RunScript()
                {
#region GUNLUKGOZLEM BODY_Script
                    //                        TTObjectContext context = new TTObjectContext(true);
            //            string sObjectID = this.GUNLUKOBJECTID.CalcValue;
            //            InPatientPhysicianProgresses inPatientPhysicianProgresses = (InPatientPhysicianProgresses)context.GetObject(new Guid(sObjectID),"InPatientPhysicianProgresses");
            //            if(inPatientPhysicianProgresses.Description!=null)
            //                this.PROSSDESC.Value = inPatientPhysicianProgresses.Description.ToString();
#endregion GUNLUKGOZLEM BODY_Script
                }
            }

        }

        public GUNLUKGOZLEMGroup GUNLUKGOZLEM;

        public partial class TEDAVIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TEDAVIGroupBody Body()
            {
                return (TEDAVIGroupBody)_body;
            }
            public TTReportRTF TEDAVISONUCU { get {return Body().TEDAVISONUCU;} }
            public TTReportField NewField11119111 { get {return Body().NewField11119111;} }
            public TEDAVIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TEDAVIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TEDAVIGroupBody(this);
            }

            public partial class TEDAVIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF TEDAVISONUCU;
                public TTReportField NewField11119111; 
                public TEDAVIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    TEDAVISONUCU = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 18, false);
                    TEDAVISONUCU.Name = "TEDAVISONUCU";
                    TEDAVISONUCU.Value = @"";

                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial Narrow";
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.Underline = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"TEDAVİ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TEDAVISONUCU.CalcValue = TEDAVISONUCU.Value;
                    NewField11119111.CalcValue = NewField11119111.Value;
                    return new TTReportObject[] { TEDAVISONUCU,NewField11119111};
                }
                public override void RunPreScript()
                {
#region TEDAVI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            string conc = "";
            foreach(TreatmentDischarge  tr in creatingEpicrisis.Episode.TreatmentDischarges)
            {
                if(tr.CurrentStateDefID != TreatmentDischarge.States.Cancelled)
                    conc += TTObjectClasses.Common.GetTextOfRTFString(tr.Conclusion.ToString()) + "\r\n\r\n";   
            }
            
            this.TEDAVISONUCU.Value = TTObjectClasses.Common.GetRTFOfTextString(conc.ToString()) ;
#endregion TEDAVI BODY_PreScript
                }
            }

        }

        public TEDAVIGroup TEDAVI;

        public partial class AMELIYATBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public AMELIYATBASLIKGroupHeader Header()
            {
                return (AMELIYATBASLIKGroupHeader)_header;
            }

            new public AMELIYATBASLIKGroupFooter Footer()
            {
                return (AMELIYATBASLIKGroupFooter)_footer;
            }

            public AMELIYATBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new AMELIYATBASLIKGroupHeader(this);
                _footer = new AMELIYATBASLIKGroupFooter(this);

            }

            public partial class AMELIYATBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public AMELIYATBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
                public override void RunPreScript()
                {
#region AMELIYATBASLIK HEADER_PreScript
                    //            if(((EpicrisisReport)ParentReport).AMELIYATVEANESTEZI.GroupDataSet == null || ((EpicrisisReport)ParentReport).AMELIYATVEANESTEZI.GroupDataSet.Count <= 0)
//            {
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATVEANESTEZI").Body)).Visible = EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("AMELIYATVEANESTEZI").Body)).Visible = EvetHayirEnum.ehEvet;
//            }
            
            //            int i = ((EpicrisisReport)ParentReport).AMELIYATVEANESTEZI.GroupDataSet.Count;
            //            TTObjectContext context = new TTObjectContext(true);
            //            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            //            string sEpisodeID = creatingEpicrisis.Episode.ToString();
            //            BindingList<TTObjectClasses.SurgeryProcedure.GetSurgeryProceduresByEpisode_Class> surgeryProcedureList =  TTObjectClasses.SurgeryProcedure.GetSurgeryProceduresByEpisode(context,sEpisodeID);
            //            if (surgeryProcedureList.Count <=0)
            //            {
            //                //((EpicrisisReport)ParentReport).AMELIYATBASLIKBody.Visible = EvetHayirEnum.ehHayir;
            //            }
//
#endregion AMELIYATBASLIK HEADER_PreScript
                }
            }
            public partial class AMELIYATBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public AMELIYATBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public AMELIYATBASLIKGroup AMELIYATBASLIK;

        public partial class AMELIYATALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public AMELIYATALTBASLIKGroupHeader Header()
            {
                return (AMELIYATALTBASLIKGroupHeader)_header;
            }

            new public AMELIYATALTBASLIKGroupFooter Footer()
            {
                return (AMELIYATALTBASLIKGroupFooter)_footer;
            }

            public TTReportField NewField11211911111 { get {return Header().NewField11211911111;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1101 { get {return Header().NewField1101;} }
            public TTReportField NewField1102 { get {return Header().NewField1102;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public AMELIYATALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new AMELIYATALTBASLIKGroupHeader(this);
                _footer = new AMELIYATALTBASLIKGroupFooter(this);

            }

            public partial class AMELIYATALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField NewField11211911111;
                public TTReportField NewField10;
                public TTReportField NewField101;
                public TTReportShape NewLine1111;
                public TTReportField NewField1101;
                public TTReportField NewField1102;
                public TTReportField NewField1; 
                public AMELIYATALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11211911111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    NewField11211911111.Name = "NewField11211911111";
                    NewField11211911111.TextFont.Name = "Arial Narrow";
                    NewField11211911111.TextFont.CharSet = 162;
                    NewField11211911111.Value = @"Tarih";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 67, 12, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Ameliyat Adı";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 7, 120, 12, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Name = "Arial Narrow";
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"Ameliyat Kodu";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 7, 146, 12, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.TextFont.Name = "Arial Narrow";
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @"Anestezi İşlemi";

                    NewField1102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 7, 199, 12, false);
                    NewField1102.Name = "NewField1102";
                    NewField1102.TextFont.Name = "Arial Narrow";
                    NewField1102.TextFont.CharSet = 162;
                    NewField1102.Value = @"Anestezi Kodu";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 33, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"AMELİYAT:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11211911111.CalcValue = NewField11211911111.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    NewField1102.CalcValue = NewField1102.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField11211911111,NewField10,NewField101,NewField1101,NewField1102,NewField1};
                }
            }
            public partial class AMELIYATALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111; 
                public AMELIYATALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public AMELIYATALTBASLIKGroup AMELIYATALTBASLIK;

        public partial class AMELIYATVEANESTEZIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public AMELIYATVEANESTEZIGroupBody Body()
            {
                return (AMELIYATVEANESTEZIGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField ANSTEZITYPE { get {return Body().ANSTEZITYPE;} }
            public TTReportField SURGERYOBJECTID { get {return Body().SURGERYOBJECTID;} }
            public TTReportField ANESTHESIACODE { get {return Body().ANESTHESIACODE;} }
            public AMELIYATVEANESTEZIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AMELIYATVEANESTEZIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class>("GetSurgeryProceduresBySubEpisode", SurgeryProcedure.GetSurgeryProceduresBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new AMELIYATVEANESTEZIGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class AMELIYATVEANESTEZIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField TARIH;
                public TTReportField NAME;
                public TTReportField ANSTEZITYPE;
                public TTReportField SURGERYOBJECTID;
                public TTReportField ANESTHESIACODE; 
                public AMELIYATVEANESTEZIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 120, 6, false);
                    CODE.Name = "CODE";
                    CODE.ForeColor = System.Drawing.Color.White;
                    CODE.DrawStyle = DrawStyleConstants.vbSolid;
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#CODE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.ForeColor = System.Drawing.Color.White;
                    TARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#SURGERYDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 100, 6, false);
                    NAME.Name = "NAME";
                    NAME.ForeColor = System.Drawing.Color.White;
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                    ANSTEZITYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 179, 6, false);
                    ANSTEZITYPE.Name = "ANSTEZITYPE";
                    ANSTEZITYPE.ForeColor = System.Drawing.Color.White;
                    ANSTEZITYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    ANSTEZITYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANSTEZITYPE.MultiLine = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.NoClip = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.WordBreak = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.TextFont.Name = "Arial Narrow";
                    ANSTEZITYPE.TextFont.CharSet = 162;
                    ANSTEZITYPE.Value = @"";

                    SURGERYOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 251, 6, false);
                    SURGERYOBJECTID.Name = "SURGERYOBJECTID";
                    SURGERYOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    SURGERYOBJECTID.ForeColor = System.Drawing.Color.White;
                    SURGERYOBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    SURGERYOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURGERYOBJECTID.TextFont.Name = "Arial Narrow";
                    SURGERYOBJECTID.TextFont.CharSet = 162;
                    SURGERYOBJECTID.Value = @"{#OBJECTID#}";

                    ANESTHESIACODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 200, 6, false);
                    ANESTHESIACODE.Name = "ANESTHESIACODE";
                    ANESTHESIACODE.ForeColor = System.Drawing.Color.White;
                    ANESTHESIACODE.DrawStyle = DrawStyleConstants.vbSolid;
                    ANESTHESIACODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANESTHESIACODE.TextFont.Name = "Arial Narrow";
                    ANESTHESIACODE.TextFont.CharSet = 162;
                    ANESTHESIACODE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class dataset_GetSurgeryProceduresBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class>(0);
                    CODE.CalcValue = (dataset_GetSurgeryProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetSurgeryProceduresBySubEpisode.Code) : "");
                    TARIH.CalcValue = (dataset_GetSurgeryProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetSurgeryProceduresBySubEpisode.Surgerydate) : "");
                    NAME.CalcValue = (dataset_GetSurgeryProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetSurgeryProceduresBySubEpisode.Name) : "");
                    ANSTEZITYPE.CalcValue = @"";
                    SURGERYOBJECTID.CalcValue = (dataset_GetSurgeryProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetSurgeryProceduresBySubEpisode.ObjectID) : "");
                    ANESTHESIACODE.CalcValue = @"";
                    return new TTReportObject[] { CODE,TARIH,NAME,ANSTEZITYPE,SURGERYOBJECTID,ANESTHESIACODE};
                }

                public override void RunScript()
                {
#region AMELIYATVEANESTEZI BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            if(this.SURGERYOBJECTID.CalcValue != null)
            {
                string objectID = this.SURGERYOBJECTID.CalcValue.ToString();
                SurgeryProcedure surgeryProcedure = (SurgeryProcedure)objectContext.GetObject(new Guid(objectID),"SurgeryProcedure");
                if(surgeryProcedure != null)
                {
                    if(surgeryProcedure.Surgery != null)
                    {
                        if(surgeryProcedure.Surgery.AnesthesiaAndReanimation != null)
                        {
                            if(surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures != null && surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures.Count > 0)
                            {
                                this.ANSTEZITYPE.CalcValue = surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures[0].ProcedureObject.Name;
                                this.ANESTHESIACODE.CalcValue = surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures[0].ProcedureObject.MySUTCode;
                            }
//                            if(surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnesthesiaTechnique != null)
//                                this.ANSTEZITYPE.CalcValue=TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(surgeryProcedure.Surgery.AnesthesiaAndReanimation.AnesthesiaTechnique);
                        }
                    }
                }
            }
#endregion AMELIYATVEANESTEZI BODY_Script
                }
            }

        }

        public AMELIYATVEANESTEZIGroup AMELIYATVEANESTEZI;

        public partial class MANIPLATIONBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public MANIPLATIONBASLIKGroupHeader Header()
            {
                return (MANIPLATIONBASLIKGroupHeader)_header;
            }

            new public MANIPLATIONBASLIKGroupFooter Footer()
            {
                return (MANIPLATIONBASLIKGroupFooter)_footer;
            }

            public MANIPLATIONBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MANIPLATIONBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MANIPLATIONBASLIKGroupHeader(this);
                _footer = new MANIPLATIONBASLIKGroupFooter(this);

            }

            public partial class MANIPLATIONBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public MANIPLATIONBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class MANIPLATIONBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public MANIPLATIONBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
                public override void RunPreScript()
                {
#region MANIPLATIONBASLIK FOOTER_PreScript
                    //                        if(((EpicrisisReport)ParentReport).MANIPLATION.GroupDataSet == null || ((EpicrisisReport)ParentReport).MANIPLATION.GroupDataSet.Count <= 0)
//            {
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Header)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATION").Body)).Visible = EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Header)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATION").Body)).Visible = EvetHayirEnum.ehEvet;
//            }
#endregion MANIPLATIONBASLIK FOOTER_PreScript
                }
            }

        }

        public MANIPLATIONBASLIKGroup MANIPLATIONBASLIK;

        public partial class PLANLITIBBIISLEMBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public PLANLITIBBIISLEMBASLIKGroupHeader Header()
            {
                return (PLANLITIBBIISLEMBASLIKGroupHeader)_header;
            }

            new public PLANLITIBBIISLEMBASLIKGroupFooter Footer()
            {
                return (PLANLITIBBIISLEMBASLIKGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public PLANLITIBBIISLEMBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PLANLITIBBIISLEMBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PLANLITIBBIISLEMBASLIKGroupHeader(this);
                _footer = new PLANLITIBBIISLEMBASLIKGroupFooter(this);

            }

            public partial class PLANLITIBBIISLEMBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape NewLine11111; 
                public PLANLITIBBIISLEMBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 53, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"PLANLI TIBBİ İŞLEMLER:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 8, 42, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.CharSet = 1;
                    NewField2.Value = @"Tarih";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 8, 69, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.CharSet = 1;
                    NewField3.Value = @"İşlem";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 8, 174, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.CharSet = 1;
                    NewField4.Value = @"İşlem Kodu";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 16, 14, 198, 14, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4};
                }
            }
            public partial class PLANLITIBBIISLEMBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public PLANLITIBBIISLEMBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PLANLITIBBIISLEMBASLIKGroup PLANLITIBBIISLEMBASLIK;

        public partial class PLANLITIBBIISLEMGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public PLANLITIBBIISLEMGroupBody Body()
            {
                return (PLANLITIBBIISLEMGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField PROCEDUREOBJECTCODE { get {return Body().PROCEDUREOBJECTCODE;} }
            public TTReportField PROCEDUREOBJECTNAME { get {return Body().PROCEDUREOBJECTNAME;} }
            public PLANLITIBBIISLEMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PLANLITIBBIISLEMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class>("PlannedMedicalActionOrderDetailEpic", PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PLANLITIBBIISLEMGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PLANLITIBBIISLEMGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField PROCEDUREOBJECTCODE;
                public TTReportField PROCEDUREOBJECTNAME; 
                public PLANLITIBBIISLEMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 42, 5, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"Short Date";
                    ACTIONDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDATE.TextFont.CharSet = 1;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    PROCEDUREOBJECTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 195, 5, false);
                    PROCEDUREOBJECTCODE.Name = "PROCEDUREOBJECTCODE";
                    PROCEDUREOBJECTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTCODE.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECTCODE.TextFont.CharSet = 1;
                    PROCEDUREOBJECTCODE.Value = @"{#PROCEDUREOBJECTCODE#}";

                    PROCEDUREOBJECTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 0, 145, 5, false);
                    PROCEDUREOBJECTNAME.Name = "PROCEDUREOBJECTNAME";
                    PROCEDUREOBJECTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTNAME.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECTNAME.TextFont.CharSet = 1;
                    PROCEDUREOBJECTNAME.Value = @"{#PROCEDUREOBJECTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class dataset_PlannedMedicalActionOrderDetailEpic = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_PlannedMedicalActionOrderDetailEpic != null ? Globals.ToStringCore(dataset_PlannedMedicalActionOrderDetailEpic.ActionDate) : "");
                    PROCEDUREOBJECTCODE.CalcValue = (dataset_PlannedMedicalActionOrderDetailEpic != null ? Globals.ToStringCore(dataset_PlannedMedicalActionOrderDetailEpic.Procedureobjectcode) : "");
                    PROCEDUREOBJECTNAME.CalcValue = (dataset_PlannedMedicalActionOrderDetailEpic != null ? Globals.ToStringCore(dataset_PlannedMedicalActionOrderDetailEpic.Procedureobjectname) : "");
                    return new TTReportObject[] { ACTIONDATE,PROCEDUREOBJECTCODE,PROCEDUREOBJECTNAME};
                }
            }

        }

        public PLANLITIBBIISLEMGroup PLANLITIBBIISLEM;

        public partial class MANIPLATIONALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public MANIPLATIONALTBASLIKGroupHeader Header()
            {
                return (MANIPLATIONALTBASLIKGroupHeader)_header;
            }

            new public MANIPLATIONALTBASLIKGroupFooter Footer()
            {
                return (MANIPLATIONALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarihMAN { get {return Header().lableTarihMAN;} }
            public TTReportField LableManiplasyonAdı { get {return Header().LableManiplasyonAdı;} }
            public TTReportField lableManCode { get {return Header().lableManCode;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField lableNucTest111 { get {return Header().lableNucTest111;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public MANIPLATIONALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MANIPLATIONALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MANIPLATIONALTBASLIKGroupHeader(this);
                _footer = new MANIPLATIONALTBASLIKGroupFooter(this);

            }

            public partial class MANIPLATIONALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarihMAN;
                public TTReportField LableManiplasyonAdı;
                public TTReportField lableManCode;
                public TTReportShape NewLine1;
                public TTReportField lableNucTest111; 
                public MANIPLATIONALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarihMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarihMAN.Name = "lableTarihMAN";
                    lableTarihMAN.TextFont.Name = "Arial Narrow";
                    lableTarihMAN.TextFont.CharSet = 162;
                    lableTarihMAN.Value = @"Tarih";

                    LableManiplasyonAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableManiplasyonAdı.Name = "LableManiplasyonAdı";
                    LableManiplasyonAdı.TextFont.Name = "Arial Narrow";
                    LableManiplasyonAdı.TextFont.CharSet = 162;
                    LableManiplasyonAdı.Value = @"Tıbbi Cerrahi Uygulama";

                    lableManCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableManCode.Name = "lableManCode";
                    lableManCode.TextFont.Name = "Arial Narrow";
                    lableManCode.TextFont.CharSet = 162;
                    lableManCode.Value = @"Kodu";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 188, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    lableNucTest111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest111.Name = "lableNucTest111";
                    lableNucTest111.TextFont.Name = "Arial Narrow";
                    lableNucTest111.TextFont.Bold = true;
                    lableNucTest111.TextFont.CharSet = 162;
                    lableNucTest111.Value = @"TIBBİ CERRAHİ UYGULAMALAR:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarihMAN.CalcValue = lableTarihMAN.Value;
                    LableManiplasyonAdı.CalcValue = LableManiplasyonAdı.Value;
                    lableManCode.CalcValue = lableManCode.Value;
                    lableNucTest111.CalcValue = lableNucTest111.Value;
                    return new TTReportObject[] { lableTarihMAN,LableManiplasyonAdı,lableManCode,lableNucTest111};
                }
            }
            public partial class MANIPLATIONALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine2; 
                public MANIPLATIONALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public MANIPLATIONALTBASLIKGroup MANIPLATIONALTBASLIK;

        public partial class MANIPLATIONYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public MANIPLATIONYENIGroupBody Body()
            {
                return (MANIPLATIONYENIGroupBody)_body;
            }
            public TTReportRTF MANIPLATIONRTF { get {return Body().MANIPLATIONRTF;} }
            public TTReportField lableNucTest1111 { get {return Body().lableNucTest1111;} }
            public MANIPLATIONYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MANIPLATIONYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MANIPLATIONYENIGroupBody(this);
            }

            public partial class MANIPLATIONYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF MANIPLATIONRTF;
                public TTReportField lableNucTest1111; 
                public MANIPLATIONYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    MANIPLATIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    MANIPLATIONRTF.Name = "MANIPLATIONRTF";
                    MANIPLATIONRTF.Value = @"";

                    lableNucTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest1111.Name = "lableNucTest1111";
                    lableNucTest1111.TextFont.Name = "Arial Narrow";
                    lableNucTest1111.TextFont.Bold = true;
                    lableNucTest1111.TextFont.CharSet = 162;
                    lableNucTest1111.Value = @"TIBBİ CERRAHİ UYGULAMALAR:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MANIPLATIONRTF.CalcValue = MANIPLATIONRTF.Value;
                    lableNucTest1111.CalcValue = lableNucTest1111.Value;
                    return new TTReportObject[] { MANIPLATIONRTF,lableNucTest1111};
                }
                public override void RunPreScript()
                {
#region MANIPLATIONYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            
            BindingList<TTObjectClasses.ManipulationProcedure> manipulationProcedureList ;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                manipulationProcedureList = ManipulationProcedure.GetManipulationProceduresOfSubEpisode(context, subepisode.ToString(),creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
                
                manipulationProcedureList = ManipulationProcedure.GetManipulationProceduresOfEpisode(context,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            
            if(manipulationProcedureList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (ManipulationProcedure manipulationProcedure in manipulationProcedureList)
                {
                    builder.Append(Convert.ToDateTime(manipulationProcedure.ActionDate).ToShortDateString() + " ");
                    builder.Append(manipulationProcedure.ProcedureObject.Name + " ");
                    builder.Append("(" + manipulationProcedure.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.MANIPLATIONRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion MANIPLATIONYENI BODY_PreScript
                }
            }

        }

        public MANIPLATIONYENIGroup MANIPLATIONYENI;

        public partial class ORTEZPROTEZBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public ORTEZPROTEZBASLIKGroupHeader Header()
            {
                return (ORTEZPROTEZBASLIKGroupHeader)_header;
            }

            new public ORTEZPROTEZBASLIKGroupFooter Footer()
            {
                return (ORTEZPROTEZBASLIKGroupFooter)_footer;
            }

            public ORTEZPROTEZBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORTEZPROTEZBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ORTEZPROTEZBASLIKGroupHeader(this);
                _footer = new ORTEZPROTEZBASLIKGroupFooter(this);

            }

            public partial class ORTEZPROTEZBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public ORTEZPROTEZBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class ORTEZPROTEZBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public ORTEZPROTEZBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ORTEZPROTEZBASLIKGroup ORTEZPROTEZBASLIK;

        public partial class ORTEZPROTEZALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public ORTEZPROTEZALTBASLIKGroupHeader Header()
            {
                return (ORTEZPROTEZALTBASLIKGroupHeader)_header;
            }

            new public ORTEZPROTEZALTBASLIKGroupFooter Footer()
            {
                return (ORTEZPROTEZALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih1 { get {return Header().lableTarih1;} }
            public TTReportField LableOrtezAdı1 { get {return Header().LableOrtezAdı1;} }
            public TTReportField lableOrtezProtezCode { get {return Header().lableOrtezProtezCode;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField lableTıbbiMlz11 { get {return Header().lableTıbbiMlz11;} }
            public TTReportShape NewLine11112 { get {return Footer().NewLine11112;} }
            public ORTEZPROTEZALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORTEZPROTEZALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ORTEZPROTEZALTBASLIKGroupHeader(this);
                _footer = new ORTEZPROTEZALTBASLIKGroupFooter(this);

            }

            public partial class ORTEZPROTEZALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih1;
                public TTReportField LableOrtezAdı1;
                public TTReportField lableOrtezProtezCode;
                public TTReportShape NewLine11111;
                public TTReportField lableTıbbiMlz11; 
                public ORTEZPROTEZALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih1.Name = "lableTarih1";
                    lableTarih1.TextFont.Name = "Arial Narrow";
                    lableTarih1.TextFont.CharSet = 162;
                    lableTarih1.Value = @"Tarih";

                    LableOrtezAdı1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableOrtezAdı1.Name = "LableOrtezAdı1";
                    LableOrtezAdı1.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı1.TextFont.CharSet = 162;
                    LableOrtezAdı1.Value = @"Ortez Protez İşlemi";

                    lableOrtezProtezCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableOrtezProtezCode.Name = "lableOrtezProtezCode";
                    lableOrtezProtezCode.TextFont.Name = "Arial Narrow";
                    lableOrtezProtezCode.TextFont.CharSet = 162;
                    lableOrtezProtezCode.Value = @"Ortez Protez Kodu";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableTıbbiMlz11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz11.Name = "lableTıbbiMlz11";
                    lableTıbbiMlz11.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz11.TextFont.Bold = true;
                    lableTıbbiMlz11.TextFont.CharSet = 162;
                    lableTıbbiMlz11.Value = @"ORTEZ PROTEZ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih1.CalcValue = lableTarih1.Value;
                    LableOrtezAdı1.CalcValue = LableOrtezAdı1.Value;
                    lableOrtezProtezCode.CalcValue = lableOrtezProtezCode.Value;
                    lableTıbbiMlz11.CalcValue = lableTıbbiMlz11.Value;
                    return new TTReportObject[] { lableTarih1,LableOrtezAdı1,lableOrtezProtezCode,lableTıbbiMlz11};
                }
            }
            public partial class ORTEZPROTEZALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine11112; 
                public ORTEZPROTEZALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine11112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine11112.Name = "NewLine11112";
                    NewLine11112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public ORTEZPROTEZALTBASLIKGroup ORTEZPROTEZALTBASLIK;

        public partial class ORTEZPROTEZYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public ORTEZPROTEZYENIGroupBody Body()
            {
                return (ORTEZPROTEZYENIGroupBody)_body;
            }
            public TTReportRTF ORTEZPROTEZRTF { get {return Body().ORTEZPROTEZRTF;} }
            public TTReportField lableTıbbiMlz111 { get {return Body().lableTıbbiMlz111;} }
            public ORTEZPROTEZYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORTEZPROTEZYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ORTEZPROTEZYENIGroupBody(this);
            }

            public partial class ORTEZPROTEZYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF ORTEZPROTEZRTF;
                public TTReportField lableTıbbiMlz111; 
                public ORTEZPROTEZYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    ORTEZPROTEZRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    ORTEZPROTEZRTF.Name = "ORTEZPROTEZRTF";
                    ORTEZPROTEZRTF.Value = @"";

                    lableTıbbiMlz111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz111.Name = "lableTıbbiMlz111";
                    lableTıbbiMlz111.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz111.TextFont.Bold = true;
                    lableTıbbiMlz111.TextFont.CharSet = 162;
                    lableTıbbiMlz111.Value = @"ORTEZ PROTEZ:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ORTEZPROTEZRTF.CalcValue = ORTEZPROTEZRTF.Value;
                    lableTıbbiMlz111.CalcValue = lableTıbbiMlz111.Value;
                    return new TTReportObject[] { ORTEZPROTEZRTF,lableTıbbiMlz111};
                }
                public override void RunPreScript()
                {
#region ORTEZPROTEZYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            
            BindingList<TTObjectClasses.OrthesisProsthesisProcedure> orthProthList ;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                orthProthList = OrthesisProsthesisProcedure.GetOrthesisProthesisBySubEpisode(context, subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor

                orthProthList = OrthesisProsthesisProcedure.GetOrthesisProthesisByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            if(orthProthList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (OrthesisProsthesisProcedure orthProth in orthProthList)
                {
                    builder.Append(Convert.ToDateTime(orthProth.ActionDate).ToShortDateString() + " ");
                    builder.Append(orthProth.ProcedureObject.Name + " ");
                    builder.Append("(" + orthProth.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.ORTEZPROTEZRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion ORTEZPROTEZYENI BODY_PreScript
                }
            }

        }

        public ORTEZPROTEZYENIGroup ORTEZPROTEZYENI;

        public partial class ONERILERGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public ONERILERGroupBody Body()
            {
                return (ONERILERGroupBody)_body;
            }
            public TTReportRTF ONERILER { get {return Body().ONERILER;} }
            public TTReportField NewField11119111 { get {return Body().NewField11119111;} }
            public ONERILERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ONERILERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ONERILERGroupBody(this);
            }

            public partial class ONERILERGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF ONERILER;
                public TTReportField NewField11119111; 
                public ONERILERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    ONERILER = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 18, false);
                    ONERILER.Name = "ONERILER";
                    ONERILER.Value = @"";

                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial Narrow";
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.Underline = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"ÖNERİLER:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ONERILER.CalcValue = ONERILER.Value;
                    NewField11119111.CalcValue = NewField11119111.Value;
                    return new TTReportObject[] { ONERILER,NewField11119111};
                }
                public override void RunPreScript()
                {
#region ONERILER BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.Suggestion!=null)
                this.ONERILER.Value = creatingEpicrisis.Suggestion.ToString();
#endregion ONERILER BODY_PreScript
                }
            }

        }

        public ONERILERGroup ONERILER;

        public partial class ISLEMGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public ISLEMGroupBody Body()
            {
                return (ISLEMGroupBody)_body;
            }
            public TTReportRTF ISLEM { get {return Body().ISLEM;} }
            public TTReportField NewField12119111 { get {return Body().NewField12119111;} }
            public ISLEMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ISLEMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ISLEMGroupBody(this);
            }

            public partial class ISLEMGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF ISLEM;
                public TTReportField NewField12119111; 
                public ISLEMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    ISLEM = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 18, false);
                    ISLEM.Name = "ISLEM";
                    ISLEM.Value = @"";

                    NewField12119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField12119111.Name = "NewField12119111";
                    NewField12119111.TextFont.Name = "Arial Narrow";
                    NewField12119111.TextFont.Bold = true;
                    NewField12119111.TextFont.Underline = true;
                    NewField12119111.TextFont.CharSet = 162;
                    NewField12119111.Value = @"İŞLEM:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ISLEM.CalcValue = ISLEM.Value;
                    NewField12119111.CalcValue = NewField12119111.Value;
                    return new TTReportObject[] { ISLEM,NewField12119111};
                }
                public override void RunPreScript()
                {
#region ISLEM BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.PROCEDURE!=null)
                this.ISLEM.Value = creatingEpicrisis.PROCEDURE.ToString();
#endregion ISLEM BODY_PreScript
                }
            }

        }

        public ISLEMGroup ISLEM;

        public partial class TIBBIMALZEMEBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TIBBIMALZEMEBASLIKGroupHeader Header()
            {
                return (TIBBIMALZEMEBASLIKGroupHeader)_header;
            }

            new public TIBBIMALZEMEBASLIKGroupFooter Footer()
            {
                return (TIBBIMALZEMEBASLIKGroupFooter)_footer;
            }

            public TIBBIMALZEMEBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TIBBIMALZEMEBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TIBBIMALZEMEBASLIKGroupHeader(this);
                _footer = new TIBBIMALZEMEBASLIKGroupFooter(this);

            }

            public partial class TIBBIMALZEMEBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public TIBBIMALZEMEBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class TIBBIMALZEMEBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public TIBBIMALZEMEBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TIBBIMALZEMEBASLIKGroup TIBBIMALZEMEBASLIK;

        public partial class TIBBIMALZEMEALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TIBBIMALZEMEALTBASLIKGroupHeader Header()
            {
                return (TIBBIMALZEMEALTBASLIKGroupHeader)_header;
            }

            new public TIBBIMALZEMEALTBASLIKGroupFooter Footer()
            {
                return (TIBBIMALZEMEALTBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih { get {return Header().lableTarih;} }
            public TTReportField LableMalzAdı { get {return Header().LableMalzAdı;} }
            public TTReportField lableMalzemeKodu { get {return Header().lableMalzemeKodu;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField lableTıbbiMlz1 { get {return Header().lableTıbbiMlz1;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
            public TIBBIMALZEMEALTBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TIBBIMALZEMEALTBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TIBBIMALZEMEALTBASLIKGroupHeader(this);
                _footer = new TIBBIMALZEMEALTBASLIKGroupFooter(this);

            }

            public partial class TIBBIMALZEMEALTBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih;
                public TTReportField LableMalzAdı;
                public TTReportField lableMalzemeKodu;
                public TTReportShape NewLine1111;
                public TTReportField lableTıbbiMlz1; 
                public TIBBIMALZEMEALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih.Name = "lableTarih";
                    lableTarih.TextFont.Name = "Arial Narrow";
                    lableTarih.TextFont.CharSet = 162;
                    lableTarih.Value = @"Tarih";

                    LableMalzAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 81, 12, false);
                    LableMalzAdı.Name = "LableMalzAdı";
                    LableMalzAdı.TextFont.Name = "Arial Narrow";
                    LableMalzAdı.TextFont.CharSet = 162;
                    LableMalzAdı.Value = @"Tıbbi Malzeme Adı";

                    lableMalzemeKodu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 7, 188, 12, false);
                    lableMalzemeKodu.Name = "lableMalzemeKodu";
                    lableMalzemeKodu.TextFont.Name = "Arial Narrow";
                    lableMalzemeKodu.TextFont.CharSet = 162;
                    lableMalzemeKodu.Value = @"Malzeme Kodu";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableTıbbiMlz1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz1.Name = "lableTıbbiMlz1";
                    lableTıbbiMlz1.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz1.TextFont.Bold = true;
                    lableTıbbiMlz1.TextFont.CharSet = 162;
                    lableTıbbiMlz1.Value = @"TIBBİ MALZEME:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih.CalcValue = lableTarih.Value;
                    LableMalzAdı.CalcValue = LableMalzAdı.Value;
                    lableMalzemeKodu.CalcValue = lableMalzemeKodu.Value;
                    lableTıbbiMlz1.CalcValue = lableTıbbiMlz1.Value;
                    return new TTReportObject[] { lableTarih,LableMalzAdı,lableMalzemeKodu,lableTıbbiMlz1};
                }
            }
            public partial class TIBBIMALZEMEALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1112; 
                public TIBBIMALZEMEALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public TIBBIMALZEMEALTBASLIKGroup TIBBIMALZEMEALTBASLIK;

        public partial class TIBBIMALZEMEYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public TIBBIMALZEMEYENIGroupBody Body()
            {
                return (TIBBIMALZEMEYENIGroupBody)_body;
            }
            public TTReportRTF MALZEMERTF { get {return Body().MALZEMERTF;} }
            public TTReportField lableTıbbiMlz11 { get {return Body().lableTıbbiMlz11;} }
            public TIBBIMALZEMEYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TIBBIMALZEMEYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TIBBIMALZEMEYENIGroupBody(this);
            }

            public partial class TIBBIMALZEMEYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF MALZEMERTF;
                public TTReportField lableTıbbiMlz11; 
                public TIBBIMALZEMEYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    MALZEMERTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    MALZEMERTF.Name = "MALZEMERTF";
                    MALZEMERTF.Value = @"";

                    lableTıbbiMlz11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz11.Name = "lableTıbbiMlz11";
                    lableTıbbiMlz11.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz11.TextFont.Bold = true;
                    lableTıbbiMlz11.TextFont.CharSet = 162;
                    lableTıbbiMlz11.Value = @"TIBBİ MALZEME:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MALZEMERTF.CalcValue = MALZEMERTF.Value;
                    lableTıbbiMlz11.CalcValue = lableTıbbiMlz11.Value;
                    return new TTReportObject[] { MALZEMERTF,lableTıbbiMlz11};
                }
                public override void RunPreScript()
                {
#region TIBBIMALZEMEYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            
            BindingList<TTObjectClasses.BaseTreatmentMaterial> materialList ;
            string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                materialList = BaseTreatmentMaterial.GetMaterialBySubEpisode(context, subepisode ,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
                materialList = BaseTreatmentMaterial.GetMaterialByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            if(materialList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReport)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (BaseTreatmentMaterial material in materialList)
                {
                    if(material.PricingDate != null)
                        builder.Append(Convert.ToDateTime(material.PricingDate).ToShortDateString() + " ");
                    else
                        builder.Append(Convert.ToDateTime(material.ActionDate).ToShortDateString() + " ");
                    builder.Append(material.Material.Name + " ");
                    builder.Append("(" + material.Material.Code + ")");
                    builder.Append(", ");
                }
                this.MALZEMERTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion TIBBIMALZEMEYENI BODY_PreScript
                }
            }

        }

        public TIBBIMALZEMEYENIGroup TIBBIMALZEMEYENI;

        public partial class DRUGORDERYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public DRUGORDERYENIGroupBody Body()
            {
                return (DRUGORDERYENIGroupBody)_body;
            }
            public TTReportRTF DRUGORDERRTF { get {return Body().DRUGORDERRTF;} }
            public TTReportField lableNucTest11111 { get {return Body().lableNucTest11111;} }
            public DRUGORDERYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DRUGORDERYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DRUGORDERYENIGroupBody(this);
            }

            public partial class DRUGORDERYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportRTF DRUGORDERRTF;
                public TTReportField lableNucTest11111; 
                public DRUGORDERYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    DRUGORDERRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    DRUGORDERRTF.Name = "DRUGORDERRTF";
                    DRUGORDERRTF.Value = @"";

                    lableNucTest11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest11111.Name = "lableNucTest11111";
                    lableNucTest11111.TextFont.Name = "Arial Narrow";
                    lableNucTest11111.TextFont.Bold = true;
                    lableNucTest11111.TextFont.CharSet = 162;
                    lableNucTest11111.Value = @"İLAÇLAR:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DRUGORDERRTF.CalcValue = DRUGORDERRTF.Value;
                    lableNucTest11111.CalcValue = lableNucTest11111.Value;
                    return new TTReportObject[] { DRUGORDERRTF,lableNucTest11111};
                }
                public override void RunPreScript()
                {
#region DRUGORDERYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            BindingList<TTObjectClasses.DrugOrder> drugOrderList ;
             string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
                
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                drugOrderList = DrugOrder.GetDrugOrdersBySubEpisode(context,subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
               
                drugOrderList = DrugOrder.GetDrugOrdersByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            if(drugOrderList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                StringBuilder builder = new StringBuilder();
                foreach (DrugOrder drugOrder in drugOrderList)
                {
                    builder.Append(Convert.ToDateTime(drugOrder.PlannedStartTime).ToShortDateString() + " ");
                    builder.Append(drugOrder.Material.Name + " ");
                    builder.Append("(" + drugOrder.Material.Code + ")");
                    builder.Append(", ");
                }
                this.DRUGORDERRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion DRUGORDERYENI BODY_PreScript
                }
            }

        }

        public DRUGORDERYENIGroup DRUGORDERYENI;

        public partial class KANTTORBASIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public KANTTORBASIGroupBody Body()
            {
                return (KANTTORBASIGroupBody)_body;
            }
            public TTReportField lableNucTest111111 { get {return Body().lableNucTest111111;} }
            public TTReportRTF BLOODBANKRTF { get {return Body().BLOODBANKRTF;} }
            public KANTTORBASIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KANTTORBASIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KANTTORBASIGroupBody(this);
            }

            public partial class KANTTORBASIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableNucTest111111;
                public TTReportRTF BLOODBANKRTF; 
                public KANTTORBASIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    lableNucTest111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest111111.Name = "lableNucTest111111";
                    lableNucTest111111.TextFont.Name = "Arial Narrow";
                    lableNucTest111111.TextFont.Bold = true;
                    lableNucTest111111.TextFont.CharSet = 162;
                    lableNucTest111111.Value = @"KAN ÜRÜNLERİ:";

                    BLOODBANKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    BLOODBANKRTF.Name = "BLOODBANKRTF";
                    BLOODBANKRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableNucTest111111.CalcValue = lableNucTest111111.Value;
                    BLOODBANKRTF.CalcValue = BLOODBANKRTF.Value;
                    return new TTReportObject[] { lableNucTest111111,BLOODBANKRTF};
                }
                public override void RunPreScript()
                {
#region KANTTORBASI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
 string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                BindingList<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class> bloodList = BloodBankBloodProducts.GetBloodProductBySubEpisode(subepisode,creatingEpicrisis.Episode.ObjectID.ToString());
                bool found = false;
                StringBuilder builder = new StringBuilder();
                foreach (BloodBankBloodProducts.GetBloodProductBySubEpisode_Class blood in bloodList)
                {
                    if (blood.Returned != true)
                    {
                        builder.Append(Convert.ToDateTime(blood.RequestDate).ToShortDateString() + " ");
                        builder.Append(blood.Procedurename + " ");
                        builder.Append("(" + blood.ProductNumber + ")");
                        builder.Append(", ");
                        found = true;
                    }
                }
                this.BLOODBANKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
                if (found)
                    this.Visible = EvetHayirEnum.ehEvet;
                else
                    this.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
               
                BindingList<BloodBankBloodProducts.GetBloodProductByEpisode_Class>  bloodList = BloodBankBloodProducts.GetBloodProductByEpisode(creatingEpicrisis.Episode.ObjectID);
                bool found = false;
                StringBuilder builder = new StringBuilder();
                foreach (BloodBankBloodProducts.GetBloodProductByEpisode_Class blood in bloodList)
                {
                    if (blood.Returned != true)
                    {
                        builder.Append(Convert.ToDateTime(blood.RequestDate).ToShortDateString() + " ");
                        builder.Append(blood.Procedurename + " ");
                        builder.Append("(" + blood.ProductNumber + ")");
                        builder.Append(", ");
                        found = true;
                    }
                }
                this.BLOODBANKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
                if (found)
                    this.Visible = EvetHayirEnum.ehEvet;
                else
                    this.Visible = EvetHayirEnum.ehHayir;
            }
#endregion KANTTORBASI BODY_PreScript
                }
            }

        }

        public KANTTORBASIGroup KANTTORBASI;

        public partial class HIZMETLERGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public HIZMETLERGroupBody Body()
            {
                return (HIZMETLERGroupBody)_body;
            }
            public TTReportField labelPMProcedures { get {return Body().labelPMProcedures;} }
            public TTReportRTF PMPROCEDURERTF { get {return Body().PMPROCEDURERTF;} }
            public HIZMETLERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HIZMETLERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new HIZMETLERGroupBody(this);
            }

            public partial class HIZMETLERGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField labelPMProcedures;
                public TTReportRTF PMPROCEDURERTF; 
                public HIZMETLERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    labelPMProcedures = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    labelPMProcedures.Name = "labelPMProcedures";
                    labelPMProcedures.TextFont.Name = "Arial Narrow";
                    labelPMProcedures.TextFont.Bold = true;
                    labelPMProcedures.TextFont.CharSet = 162;
                    labelPMProcedures.Value = @"HİZMETLER :";

                    PMPROCEDURERTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    PMPROCEDURERTF.Name = "PMPROCEDURERTF";
                    PMPROCEDURERTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    labelPMProcedures.CalcValue = labelPMProcedures.Value;
                    PMPROCEDURERTF.CalcValue = PMPROCEDURERTF.Value;
                    return new TTReportObject[] { labelPMProcedures,PMPROCEDURERTF};
                }
                public override void RunPreScript()
                {
#region HIZMETLER BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            BindingList<TTObjectClasses.PMAddingProcedure> procedureList ;
             string sObjectID = ((EpicrisisReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
                
            if( Globals.IsGuid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue) )
            {
                Guid subepisode = new Guid(((EpicrisisReport)ParentReport).NOT.SUBEPISODE.CalcValue);
                procedureList = PMAddingProcedure.GetPMProcedureBySubEpisode(context,creatingEpicrisis.Episode.ObjectID,subepisode);
            }
            else
            {
                //subepisode olmazsa episode bazlı çalışıyor
               
                procedureList = PMAddingProcedure.GetPMProcedureByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            }
            if(procedureList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                StringBuilder builder = new StringBuilder();
                foreach (PMAddingProcedure procedure in procedureList)
                {
                    if(procedure.PricingDate != null)
                        builder.Append(Convert.ToDateTime(procedure.PricingDate).ToShortDateString() + " ");
                    else
                        builder.Append(Convert.ToDateTime(procedure.ActionDate).ToShortDateString() + " ");
                    builder.Append(procedure.ProcedureObject.Name + " ");
                    builder.Append("(" + procedure.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.PMPROCEDURERTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }
#endregion HIZMETLER BODY_PreScript
                }
            }

        }

        public HIZMETLERGroup HIZMETLER;

        public partial class REFAKATCIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public REFAKATCIGroupHeader Header()
            {
                return (REFAKATCIGroupHeader)_header;
            }

            new public REFAKATCIGroupFooter Footer()
            {
                return (REFAKATCIGroupFooter)_footer;
            }

            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public REFAKATCIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REFAKATCIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new REFAKATCIGroupHeader(this);
                _footer = new REFAKATCIGroupFooter(this);

            }

            public partial class REFAKATCIGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public REFAKATCIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }
            public partial class REFAKATCIGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public REFAKATCIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public REFAKATCIGroup REFAKATCI;

        public partial class REFAKATCIBASLIKGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public REFAKATCIBASLIKGroupHeader Header()
            {
                return (REFAKATCIBASLIKGroupHeader)_header;
            }

            new public REFAKATCIBASLIKGroupFooter Footer()
            {
                return (REFAKATCIBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih1 { get {return Header().lableTarih1;} }
            public TTReportField labelRefakatciAdi { get {return Header().labelRefakatciAdi;} }
            public TTReportField lableRefakatciAdresi { get {return Header().lableRefakatciAdresi;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField lableRefakatci { get {return Header().lableRefakatci;} }
            public TTReportField labelRefakatciYasi { get {return Header().labelRefakatciYasi;} }
            public TTReportField labelRefakatciCinsiyet { get {return Header().labelRefakatciCinsiyet;} }
            public TTReportField labelRefakatciKalacagiGunSayisi { get {return Header().labelRefakatciKalacagiGunSayisi;} }
            public REFAKATCIBASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REFAKATCIBASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new REFAKATCIBASLIKGroupHeader(this);
                _footer = new REFAKATCIBASLIKGroupFooter(this);

            }

            public partial class REFAKATCIBASLIKGroupHeader : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField lableTarih1;
                public TTReportField labelRefakatciAdi;
                public TTReportField lableRefakatciAdresi;
                public TTReportShape NewLine11111;
                public TTReportField lableRefakatci;
                public TTReportField labelRefakatciYasi;
                public TTReportField labelRefakatciCinsiyet;
                public TTReportField labelRefakatciKalacagiGunSayisi; 
                public REFAKATCIBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih1.Name = "lableTarih1";
                    lableTarih1.TextFont.Name = "Arial Narrow";
                    lableTarih1.TextFont.CharSet = 162;
                    lableTarih1.Value = @"Tarih";

                    labelRefakatciAdi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 81, 12, false);
                    labelRefakatciAdi.Name = "labelRefakatciAdi";
                    labelRefakatciAdi.TextFont.Name = "Arial Narrow";
                    labelRefakatciAdi.TextFont.CharSet = 162;
                    labelRefakatciAdi.Value = @"Refakatçi Adı";

                    lableRefakatciAdresi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 7, 200, 12, false);
                    lableRefakatciAdresi.Name = "lableRefakatciAdresi";
                    lableRefakatciAdresi.TextFont.Name = "Arial Narrow";
                    lableRefakatciAdresi.TextFont.CharSet = 162;
                    lableRefakatciAdresi.Value = @"Adres";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableRefakatci = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableRefakatci.Name = "lableRefakatci";
                    lableRefakatci.TextFont.Name = "Arial Narrow";
                    lableRefakatci.TextFont.Bold = true;
                    lableRefakatci.TextFont.CharSet = 162;
                    lableRefakatci.Value = @"REFAKATÇİ:";

                    labelRefakatciYasi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 7, 88, 12, false);
                    labelRefakatciYasi.Name = "labelRefakatciYasi";
                    labelRefakatciYasi.TextFont.Name = "Arial Narrow";
                    labelRefakatciYasi.TextFont.CharSet = 162;
                    labelRefakatciYasi.Value = @"Yaş";

                    labelRefakatciCinsiyet = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 7, 100, 12, false);
                    labelRefakatciCinsiyet.Name = "labelRefakatciCinsiyet";
                    labelRefakatciCinsiyet.TextFont.Name = "Arial Narrow";
                    labelRefakatciCinsiyet.TextFont.CharSet = 162;
                    labelRefakatciCinsiyet.Value = @"Cinsiyet";

                    labelRefakatciKalacagiGunSayisi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 7, 127, 12, false);
                    labelRefakatciKalacagiGunSayisi.Name = "labelRefakatciKalacagiGunSayisi";
                    labelRefakatciKalacagiGunSayisi.TextFont.Name = "Arial Narrow";
                    labelRefakatciKalacagiGunSayisi.TextFont.CharSet = 162;
                    labelRefakatciKalacagiGunSayisi.Value = @"Kalacağı Gün Sayısı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih1.CalcValue = lableTarih1.Value;
                    labelRefakatciAdi.CalcValue = labelRefakatciAdi.Value;
                    lableRefakatciAdresi.CalcValue = lableRefakatciAdresi.Value;
                    lableRefakatci.CalcValue = lableRefakatci.Value;
                    labelRefakatciYasi.CalcValue = labelRefakatciYasi.Value;
                    labelRefakatciCinsiyet.CalcValue = labelRefakatciCinsiyet.Value;
                    labelRefakatciKalacagiGunSayisi.CalcValue = labelRefakatciKalacagiGunSayisi.Value;
                    return new TTReportObject[] { lableTarih1,labelRefakatciAdi,lableRefakatciAdresi,lableRefakatci,labelRefakatciYasi,labelRefakatciCinsiyet,labelRefakatciKalacagiGunSayisi};
                }
            }
            public partial class REFAKATCIBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                 
                public REFAKATCIBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public REFAKATCIBASLIKGroup REFAKATCIBASLIK;

        public partial class REFAKATCIYENIGroup : TTReportGroup
        {
            public EpicrisisReport MyParentReport
            {
                get { return (EpicrisisReport)ParentReport; }
            }

            new public REFAKATCIYENIGroupBody Body()
            {
                return (REFAKATCIYENIGroupBody)_body;
            }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField COMPANIONNAME { get {return Body().COMPANIONNAME;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportField COMPANIONSEX { get {return Body().COMPANIONSEX;} }
            public TTReportField STAYINGDATECOUNT { get {return Body().STAYINGDATECOUNT;} }
            public TTReportField COMPANIONADDRESS { get {return Body().COMPANIONADDRESS;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public REFAKATCIYENIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REFAKATCIYENIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>("GetCompanionApplicationBySubEpisode2", CompanionApplication.GetCompanionApplicationBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new REFAKATCIYENIGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class REFAKATCIYENIGroupBody : TTReportSection
            {
                public EpicrisisReport MyParentReport
                {
                    get { return (EpicrisisReport)ParentReport; }
                }
                
                public TTReportField REQUESTDATE;
                public TTReportField COMPANIONNAME;
                public TTReportField AGE;
                public TTReportField COMPANIONSEX;
                public TTReportField STAYINGDATECOUNT;
                public TTReportField COMPANIONADDRESS;
                public TTReportField BIRTHDATE; 
                public REFAKATCIYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.ForeColor = System.Drawing.Color.White;
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    COMPANIONNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 81, 6, false);
                    COMPANIONNAME.Name = "COMPANIONNAME";
                    COMPANIONNAME.ForeColor = System.Drawing.Color.White;
                    COMPANIONNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONNAME.TextFont.Name = "Arial Narrow";
                    COMPANIONNAME.TextFont.CharSet = 162;
                    COMPANIONNAME.Value = @"{#COMPANIONNAME#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 1, 88, 6, false);
                    AGE.Name = "AGE";
                    AGE.ForeColor = System.Drawing.Color.White;
                    AGE.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Arial Narrow";
                    AGE.TextFont.CharSet = 162;
                    AGE.Value = @"";

                    COMPANIONSEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 100, 6, false);
                    COMPANIONSEX.Name = "COMPANIONSEX";
                    COMPANIONSEX.ForeColor = System.Drawing.Color.White;
                    COMPANIONSEX.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONSEX.TextFont.Name = "Arial Narrow";
                    COMPANIONSEX.TextFont.CharSet = 162;
                    COMPANIONSEX.Value = @"{#COMPANIONSEX#}";

                    STAYINGDATECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 127, 6, false);
                    STAYINGDATECOUNT.Name = "STAYINGDATECOUNT";
                    STAYINGDATECOUNT.ForeColor = System.Drawing.Color.White;
                    STAYINGDATECOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    STAYINGDATECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    STAYINGDATECOUNT.TextFont.Name = "Arial Narrow";
                    STAYINGDATECOUNT.TextFont.CharSet = 162;
                    STAYINGDATECOUNT.Value = @"{#STAYINGDATECOUNT#}";

                    COMPANIONADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 200, 6, false);
                    COMPANIONADDRESS.Name = "COMPANIONADDRESS";
                    COMPANIONADDRESS.ForeColor = System.Drawing.Color.White;
                    COMPANIONADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONADDRESS.TextFont.Name = "Arial Narrow";
                    COMPANIONADDRESS.TextFont.CharSet = 162;
                    COMPANIONADDRESS.Value = @"{#COMPANIONADDRESS#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 1, 258, 6, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.Visible = EvetHayirEnum.ehHayir;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"General Date";
                    BIRTHDATE.TextFont.Name = "Arial Narrow";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{#COMPANIONBIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CompanionApplication.GetCompanionApplicationBySubEpisode_Class dataset_GetCompanionApplicationBySubEpisode2 = ParentGroup.rsGroup.GetCurrentRecord<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>(0);
                    REQUESTDATE.CalcValue = (dataset_GetCompanionApplicationBySubEpisode2 != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode2.RequestDate) : "");
                    COMPANIONNAME.CalcValue = (dataset_GetCompanionApplicationBySubEpisode2 != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode2.CompanionName) : "");
                    AGE.CalcValue = @"";
                    COMPANIONSEX.CalcValue = COMPANIONSEX.Value;
                    STAYINGDATECOUNT.CalcValue = (dataset_GetCompanionApplicationBySubEpisode2 != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode2.StayingDateCount) : "");
                    COMPANIONADDRESS.CalcValue = (dataset_GetCompanionApplicationBySubEpisode2 != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode2.CompanionAddress) : "");
                    BIRTHDATE.CalcValue = (dataset_GetCompanionApplicationBySubEpisode2 != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode2.CompanionBirthDate) : "");
                    return new TTReportObject[] { REQUESTDATE,COMPANIONNAME,AGE,COMPANIONSEX,STAYINGDATECOUNT,COMPANIONADDRESS,BIRTHDATE};
                }

                public override void RunScript()
                {
#region REFAKATCIYENI BODY_Script
                    if(this.BIRTHDATE.CalcValue != null && this.BIRTHDATE.CalcValue != "")
            {
                int patientAge = DateTime.Now.Year - DateTime.ParseExact(this.BIRTHDATE.CalcValue,"dd/MM/yyyy HH:mm:ss", null).Year;
                this.AGE.CalcValue = patientAge.ToString();                               
            }
#endregion REFAKATCIYENI BODY_Script
                }
            }

        }

        public REFAKATCIYENIGroup REFAKATCIYENI;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EpicrisisReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            NOTSIBLING = new NOTSIBLINGGroup(NOT,"NOTSIBLING");
            PARENTGRP = new PARENTGRPGroup(NOT,"PARENTGRP");
            MAIN = new MAINGroup(PARENTGRP,"MAIN");
            OZGECMIS = new OZGECMISGroup(PARENTGRP,"OZGECMIS");
            FIZIKMUAYENE = new FIZIKMUAYENEGroup(PARENTGRP,"FIZIKMUAYENE");
            SKRAPOR = new SKRAPORGroup(PARENTGRP,"SKRAPOR");
            LABTETKIKBASLIK = new LABTETKIKBASLIKGroup(NOT,"LABTETKIKBASLIK");
            LABTETKIKYENI = new LABTETKIKYENIGroup(LABTETKIKBASLIK,"LABTETKIKYENI");
            RADTETKIKBASLIK = new RADTETKIKBASLIKGroup(NOT,"RADTETKIKBASLIK");
            RADTETKIKALTBASLIK = new RADTETKIKALTBASLIKGroup(RADTETKIKBASLIK,"RADTETKIKALTBASLIK");
            RADTETKIKYENI = new RADTETKIKYENIGroup(RADTETKIKALTBASLIK,"RADTETKIKYENI");
            PATTETKIKBASLIK = new PATTETKIKBASLIKGroup(NOT,"PATTETKIKBASLIK");
            PATTETKIKALTBASLIK = new PATTETKIKALTBASLIKGroup(PATTETKIKBASLIK,"PATTETKIKALTBASLIK");
            PATTETKIKYENI = new PATTETKIKYENIGroup(PATTETKIKALTBASLIK,"PATTETKIKYENI");
            NUKTETKIKBASLIK = new NUKTETKIKBASLIKGroup(NOT,"NUKTETKIKBASLIK");
            NUKTETKIKALTBASLIK = new NUKTETKIKALTBASLIKGroup(NUKTETKIKBASLIK,"NUKTETKIKALTBASLIK");
            NUKTETKIKYENI = new NUKTETKIKYENIGroup(NUKTETKIKALTBASLIK,"NUKTETKIKYENI");
            GENETIKTETKIKBASLIK = new GENETIKTETKIKBASLIKGroup(NOT,"GENETIKTETKIKBASLIK");
            GENETIKTETKIKALTBASLIK = new GENETIKTETKIKALTBASLIKGroup(GENETIKTETKIKBASLIK,"GENETIKTETKIKALTBASLIK");
            GENETIKTETKIKYENI = new GENETIKTETKIKYENIGroup(GENETIKTETKIKALTBASLIK,"GENETIKTETKIKYENI");
            KONSULTASYONBASLIK = new KONSULTASYONBASLIKGroup(NOT,"KONSULTASYONBASLIK");
            KONSULTASYON = new KONSULTASYONGroup(KONSULTASYONBASLIK,"KONSULTASYON");
            TANILARBASLIK = new TANILARBASLIKGroup(NOT,"TANILARBASLIK");
            TANILARALTBASLIK = new TANILARALTBASLIKGroup(TANILARBASLIK,"TANILARALTBASLIK");
            TANILAR = new TANILARGroup(TANILARALTBASLIK,"TANILAR");
            GUNLUKGOZLEMBASLIK = new GUNLUKGOZLEMBASLIKGroup(NOT,"GUNLUKGOZLEMBASLIK");
            GUNLUKGOZLEMALTBASLIK = new GUNLUKGOZLEMALTBASLIKGroup(GUNLUKGOZLEMBASLIK,"GUNLUKGOZLEMALTBASLIK");
            GUNLUKGOZLEM = new GUNLUKGOZLEMGroup(GUNLUKGOZLEMALTBASLIK,"GUNLUKGOZLEM");
            TEDAVI = new TEDAVIGroup(NOT,"TEDAVI");
            AMELIYATBASLIK = new AMELIYATBASLIKGroup(NOT,"AMELIYATBASLIK");
            AMELIYATALTBASLIK = new AMELIYATALTBASLIKGroup(AMELIYATBASLIK,"AMELIYATALTBASLIK");
            AMELIYATVEANESTEZI = new AMELIYATVEANESTEZIGroup(AMELIYATALTBASLIK,"AMELIYATVEANESTEZI");
            MANIPLATIONBASLIK = new MANIPLATIONBASLIKGroup(NOT,"MANIPLATIONBASLIK");
            PLANLITIBBIISLEMBASLIK = new PLANLITIBBIISLEMBASLIKGroup(MANIPLATIONBASLIK,"PLANLITIBBIISLEMBASLIK");
            PLANLITIBBIISLEM = new PLANLITIBBIISLEMGroup(PLANLITIBBIISLEMBASLIK,"PLANLITIBBIISLEM");
            MANIPLATIONALTBASLIK = new MANIPLATIONALTBASLIKGroup(MANIPLATIONBASLIK,"MANIPLATIONALTBASLIK");
            MANIPLATIONYENI = new MANIPLATIONYENIGroup(MANIPLATIONALTBASLIK,"MANIPLATIONYENI");
            ORTEZPROTEZBASLIK = new ORTEZPROTEZBASLIKGroup(NOT,"ORTEZPROTEZBASLIK");
            ORTEZPROTEZALTBASLIK = new ORTEZPROTEZALTBASLIKGroup(ORTEZPROTEZBASLIK,"ORTEZPROTEZALTBASLIK");
            ORTEZPROTEZYENI = new ORTEZPROTEZYENIGroup(ORTEZPROTEZALTBASLIK,"ORTEZPROTEZYENI");
            ONERILER = new ONERILERGroup(NOT,"ONERILER");
            ISLEM = new ISLEMGroup(NOT,"ISLEM");
            TIBBIMALZEMEBASLIK = new TIBBIMALZEMEBASLIKGroup(NOT,"TIBBIMALZEMEBASLIK");
            TIBBIMALZEMEALTBASLIK = new TIBBIMALZEMEALTBASLIKGroup(TIBBIMALZEMEBASLIK,"TIBBIMALZEMEALTBASLIK");
            TIBBIMALZEMEYENI = new TIBBIMALZEMEYENIGroup(TIBBIMALZEMEALTBASLIK,"TIBBIMALZEMEYENI");
            DRUGORDERYENI = new DRUGORDERYENIGroup(NOT,"DRUGORDERYENI");
            KANTTORBASI = new KANTTORBASIGroup(NOT,"KANTTORBASI");
            HIZMETLER = new HIZMETLERGroup(NOT,"HIZMETLER");
            REFAKATCI = new REFAKATCIGroup(NOT,"REFAKATCI");
            REFAKATCIBASLIK = new REFAKATCIBASLIKGroup(REFAKATCI,"REFAKATCIBASLIK");
            REFAKATCIYENI = new REFAKATCIYENIGroup(REFAKATCIBASLIK,"REFAKATCIYENI");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "EPICRISISREPORT";
            Caption = "Epikriz Raporu (Kurum)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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
            fd.TextFont.CharSet = 0;
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