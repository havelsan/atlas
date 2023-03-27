
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
    /// Epikriz Raporu (Hasta)
    /// </summary>
    public partial class EpicrisisReportForPatient : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string Doctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    PrintDate.Value = @"{@printdate@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 13, 199, 18, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 13, 113, 18, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField1122111 { get {return Header().NewField1122111;} }
            public TTReportField NewField11112211 { get {return Header().NewField11112211;} }
            public TTReportField NewField111221111 { get {return Header().NewField111221111;} }
            public TTReportField NewField13222 { get {return Header().NewField13222;} }
            public TTReportField NewField13223 { get {return Header().NewField13223;} }
            public TTReportField NewField13224 { get {return Header().NewField13224;} }
            public TTReportField NewField13225 { get {return Header().NewField13225;} }
            public TTReportField NewField13226 { get {return Header().NewField13226;} }
            public TTReportField NewField13227 { get {return Header().NewField13227;} }
            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField DOGUMYERITARIHI { get {return Header().DOGUMYERITARIHI;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField YATTIGIBOLUM { get {return Header().YATTIGIBOLUM;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField CIKISTARIHI { get {return Header().CIKISTARIHI;} }
            public TTReportField CINSIYET { get {return Header().CINSIYET;} }
            public TTReportField TELEFON { get {return Header().TELEFON;} }
            public TTReportField DOKTORU { get {return Header().DOKTORU;} }
            public TTReportField HASTAKURUM { get {return Header().HASTAKURUM;} }
            public TTReportField SUBEPISODE { get {return Header().SUBEPISODE;} }
            public TTReportField FIELDONAY { get {return Footer().FIELDONAY;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField HospitalInformation { get {return Footer().HospitalInformation;} }
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
                list[0] = new TTReportNqlData<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class>("GetEpicrisisPatientInfoByEpisodeAction", EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField141;
                public TTReportField NewField191;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField DATE;
                public TTReportField PNAME;
                public TTReportField SURNAME;
                public TTReportField ACTIONDATE;
                public TTReportField NewField1331;
                public TTReportField EPISODE;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField HEADER;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField KURUM;
                public TTReportField NewField1221;
                public TTReportField NewField1231;
                public TTReportField NewField11211;
                public TTReportField NewField11411;
                public TTReportField NewField1122;
                public TTReportField NewField12211;
                public TTReportField NewField111221;
                public TTReportField NewField1122111;
                public TTReportField NewField11112211;
                public TTReportField NewField111221111;
                public TTReportField NewField13222;
                public TTReportField NewField13223;
                public TTReportField NewField13224;
                public TTReportField NewField13225;
                public TTReportField NewField13226;
                public TTReportField NewField13227;
                public TTReportField FULLNAME;
                public TTReportField PROTOCOLNO;
                public TTReportField KIMLIKNO;
                public TTReportField DOGUMYERITARIHI;
                public TTReportField ADRES;
                public TTReportField YATTIGIBOLUM;
                public TTReportField YATISTARIHI;
                public TTReportField CIKISTARIHI;
                public TTReportField CINSIYET;
                public TTReportField TELEFON;
                public TTReportField DOKTORU;
                public TTReportField HASTAKURUM;
                public TTReportField SUBEPISODE; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 85;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 79, 36, 83, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Kurum Adı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 79, 38, 83, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 42, 36, 46, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"Adı Soyadı";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 42, 38, 46, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 47, 38, 51, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 47, 36, 51, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @"Protokol No";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 27, 205, 31, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.TextFont.Name = "Arial Narrow";
                    DATE.Value = @"{@printdate@}";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 43, 236, 48, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.Value = @"{#NAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 47, 236, 52, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.Value = @"{#SURNAME#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 54, 236, 59, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 34, 117, 38, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.TextFont.Name = "Arial Narrow";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.Value = @"EPİKRİZ FORMU";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 60, 226, 65, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Name = "Arial Narrow";
                    EPISODE.TextFont.Size = 9;
                    EPISODE.Value = @"{#EPISODE#}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 57, 36, 61, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Doğum Yeri / Tarihi";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 57, 38, 61, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @":";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 5, 165, 28, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%SITENAME%}
{%SITECITY%}
";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 4, 199, 9, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.TextFont.Name = "Arial Narrow";
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 10, 200, 15, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.TextFont.Name = "Arial Narrow";
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 16, 199, 21, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.TextFont.Name = "Arial Narrow";
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 52, 38, 56, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 52, 36, 56, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.TextFont.Name = "Arial Narrow";
                    NewField1231.TextFont.Bold = true;
                    NewField1231.Value = @"T.C. Kimlik No";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 62, 36, 66, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Narrow";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Adresi";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 62, 38, 66, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Arial Narrow";
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @":";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 42, 124, 46, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.TextFont.Name = "Arial Narrow";
                    NewField1122.TextFont.Bold = true;
                    NewField1122.Value = @"Doktoru";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 47, 124, 51, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Name = "Arial Narrow";
                    NewField12211.TextFont.Bold = true;
                    NewField12211.Value = @"Yattığı Bölüm";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 52, 124, 56, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.TextFont.Name = "Arial Narrow";
                    NewField111221.TextFont.Bold = true;
                    NewField111221.Value = @"Yatış Tarihi";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 57, 124, 61, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.TextFont.Name = "Arial Narrow";
                    NewField1122111.TextFont.Bold = true;
                    NewField1122111.Value = @"Çıkış Tarihi";

                    NewField11112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 62, 124, 66, false);
                    NewField11112211.Name = "NewField11112211";
                    NewField11112211.TextFont.Name = "Arial Narrow";
                    NewField11112211.TextFont.Bold = true;
                    NewField11112211.Value = @"Cinsiyet";

                    NewField111221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 67, 124, 71, false);
                    NewField111221111.Name = "NewField111221111";
                    NewField111221111.TextFont.Name = "Arial Narrow";
                    NewField111221111.TextFont.Bold = true;
                    NewField111221111.Value = @"Telefon";

                    NewField13222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 42, 126, 46, false);
                    NewField13222.Name = "NewField13222";
                    NewField13222.TextFont.Name = "Arial Narrow";
                    NewField13222.TextFont.Bold = true;
                    NewField13222.Value = @":";

                    NewField13223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 47, 126, 51, false);
                    NewField13223.Name = "NewField13223";
                    NewField13223.TextFont.Name = "Arial Narrow";
                    NewField13223.TextFont.Bold = true;
                    NewField13223.Value = @":";

                    NewField13224 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 52, 126, 56, false);
                    NewField13224.Name = "NewField13224";
                    NewField13224.TextFont.Name = "Arial Narrow";
                    NewField13224.TextFont.Bold = true;
                    NewField13224.Value = @":";

                    NewField13225 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 57, 126, 61, false);
                    NewField13225.Name = "NewField13225";
                    NewField13225.TextFont.Name = "Arial Narrow";
                    NewField13225.TextFont.Bold = true;
                    NewField13225.Value = @":";

                    NewField13226 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 62, 126, 66, false);
                    NewField13226.Name = "NewField13226";
                    NewField13226.TextFont.Name = "Arial Narrow";
                    NewField13226.TextFont.Bold = true;
                    NewField13226.Value = @":";

                    NewField13227 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 67, 126, 71, false);
                    NewField13227.Name = "NewField13227";
                    NewField13227.TextFont.Name = "Arial Narrow";
                    NewField13227.TextFont.Bold = true;
                    NewField13227.Value = @":";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 42, 95, 46, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"{#NAME#} {#SURNAME#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 47, 66, 51, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.Value = @"{#PROTOCOLNO#}";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 52, 66, 56, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    DOGUMYERITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 57, 95, 61, false);
                    DOGUMYERITARIHI.Name = "DOGUMYERITARIHI";
                    DOGUMYERITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERITARIHI.Value = @"{#BIRTHPLACE#}/{#BIRTHDATE#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 62, 95, 78, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.Value = @"{#HOMEADDRESS#}";

                    YATTIGIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 47, 183, 51, false);
                    YATTIGIBOLUM.Name = "YATTIGIBOLUM";
                    YATTIGIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATTIGIBOLUM.Value = @"{#YATTIGI_BOLUM#}";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 52, 183, 56, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    YATISTARIHI.Value = @"{#YATIS_TARIHI#}";

                    CIKISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 57, 183, 61, false);
                    CIKISTARIHI.Name = "CIKISTARIHI";
                    CIKISTARIHI.TextFormat = @"dd/MM/yyyy";
                    CIKISTARIHI.Value = @"";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 62, 183, 66, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.Value = @"{#SEX#}";

                    TELEFON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 67, 183, 71, false);
                    TELEFON.Name = "TELEFON";
                    TELEFON.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEFON.Value = @"{#MOBILEPHONE#}";

                    DOKTORU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 42, 183, 46, false);
                    DOKTORU.Name = "DOKTORU";
                    DOKTORU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORU.ObjectDefName = "ResUser";
                    DOKTORU.DataMember = "NAME";
                    DOKTORU.Value = @"{#PROCEDUREDOCTOR#}";

                    HASTAKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 79, 95, 83, false);
                    HASTAKURUM.Name = "HASTAKURUM";
                    HASTAKURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKURUM.TextFont.Name = "Arial Narrow";
                    HASTAKURUM.TextFont.CharSet = 1;
                    HASTAKURUM.Value = @"";

                    SUBEPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 68, 226, 73, false);
                    SUBEPISODE.Name = "SUBEPISODE";
                    SUBEPISODE.Visible = EvetHayirEnum.ehHayir;
                    SUBEPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBEPISODE.TextFont.Name = "Arial Narrow";
                    SUBEPISODE.TextFont.Size = 9;
                    SUBEPISODE.Value = @"{#SUBEPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class dataset_GetEpicrisisPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    PNAME.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Name) : "");
                    SURNAME.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Surname) : "");
                    ACTIONDATE.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.ActionDate) : "");
                    NewField1331.CalcValue = NewField1331.Value;
                    EPISODE.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Episode) : "");
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    HEADER.CalcValue = MyParentReport.NOT.SITENAME.CalcValue + @"
" + MyParentReport.NOT.SITECITY.CalcValue + @"
";
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField1122111.CalcValue = NewField1122111.Value;
                    NewField11112211.CalcValue = NewField11112211.Value;
                    NewField111221111.CalcValue = NewField111221111.Value;
                    NewField13222.CalcValue = NewField13222.Value;
                    NewField13223.CalcValue = NewField13223.Value;
                    NewField13224.CalcValue = NewField13224.Value;
                    NewField13225.CalcValue = NewField13225.Value;
                    NewField13226.CalcValue = NewField13226.Value;
                    NewField13227.CalcValue = NewField13227.Value;
                    FULLNAME.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Name) : "") + @" " + (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Surname) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.ProtocolNo) : "");
                    KIMLIKNO.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.UniqueRefNo) : "");
                    DOGUMYERITARIHI.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.BirthPlace) : "") + @"/" + (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.BirthDate) : "");
                    ADRES.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.HomeAddress) : "");
                    YATTIGIBOLUM.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Yattigi_bolum) : "");
                    YATISTARIHI.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Yatis_tarihi) : "");
                    CIKISTARIHI.CalcValue = CIKISTARIHI.Value;
                    CINSIYET.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Sex) : "");
                    TELEFON.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.MobilePhone) : "");
                    DOKTORU.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.ProcedureDoctor) : "");
                    DOKTORU.PostFieldValueCalculation();
                    HASTAKURUM.CalcValue = @"";
                    SUBEPISODE.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.SubEpisode) : "");
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { NewField121,NewField141,NewField191,NewField112,NewField122,NewField132,DATE,PNAME,SURNAME,ACTIONDATE,NewField1331,EPISODE,NewField1121,NewField1141,SITENAME,SITECITY,HEADER,NewField1221,NewField1231,NewField11211,NewField11411,NewField1122,NewField12211,NewField111221,NewField1122111,NewField11112211,NewField111221111,NewField13222,NewField13223,NewField13224,NewField13225,NewField13226,NewField13227,FULLNAME,PROTOCOLNO,KIMLIKNO,DOGUMYERITARIHI,ADRES,YATTIGIBOLUM,YATISTARIHI,CIKISTARIHI,CINSIYET,TELEFON,DOKTORU,HASTAKURUM,SUBEPISODE,KURUM};
                }
                public override void RunPreScript()
                {
#region NOT HEADER_PreScript
                    //                                                                                                                                                                        
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
//            if(creatingEpicrisis.Episode.PatientStatus != PatientStatusEnum.Outpatient)
//            {
////                IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
////                inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResource(context,creatingEpicrisis.Episode.ObjectID,creatingEpicrisis.MasterResource.ObjectID);
////                if(inpatientTreatmentClinicList.Count > 0)
////                {
////                    this.YATISTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicInpatientDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicInpatientDate.ToString());
////                    this.TABURCUTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate.ToString());
////                }
//                this.LBLYATISTARIHI.Visible = EvetHayirEnum.ehEvet;
//                this.NewField1211.Visible = EvetHayirEnum.ehEvet;
//                this.YATISTARIHI.Visible = EvetHayirEnum.ehEvet;
//                
//                this.LBLTABURCUTARIHI.Visible = EvetHayirEnum.ehEvet;
//                this.NewField11121.Visible = EvetHayirEnum.ehEvet;
//                this.TABURCUTARIHI.Visible = EvetHayirEnum.ehEvet;
//            }
//            else
//            {
//                this.LBLYATISTARIHI.Visible = EvetHayirEnum.ehHayir;
//                this.NewField1211.Visible = EvetHayirEnum.ehHayir;
//                this.YATISTARIHI.Visible = EvetHayirEnum.ehHayir;
//                
//                this.LBLTABURCUTARIHI.Visible = EvetHayirEnum.ehHayir;
//                this.NewField11121.Visible = EvetHayirEnum.ehHayir;
//                this.TABURCUTARIHI.Visible = EvetHayirEnum.ehHayir;
//            }
#endregion NOT HEADER_PreScript
                }

                public override void RunScript()
                {
#region NOT HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            this.HASTAKURUM.CalcValue = episodeAction.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
           
                     EpisodeAction starterEpisodeAction = episodeAction.SubEpisode.StarterEpisodeAction;
                    if (starterEpisodeAction != null && starterEpisodeAction is InPatientTreatmentClinicApplication) {
                        if (((InPatientTreatmentClinicApplication)starterEpisodeAction).ClinicDischargeDate != null)
                            this.CIKISTARIHI.CalcValue = ((InPatientTreatmentClinicApplication)starterEpisodeAction).ClinicDischargeDate.ToString();
                    }
                    else
                    {
                        this.CIKISTARIHI.CalcValue = episodeAction.SubEpisode.ClosingDate.ToString();
                    }
            
            
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
//            if(creatingEpicrisis.Episode.PatientStatus != PatientStatusEnum.Outpatient)
//            {
//                bool valueSet = false;
//                if(creatingEpicrisis.MasterAction != null)
//                {
//                    if(creatingEpicrisis.MasterAction is InPatientPhysicianApplication)
//                    {
//                        this.YATISTARIHI.CalcValue = (((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicInpatientDate == null ? "" : ((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicInpatientDate.ToString());
//                        this.TABURCUTARIHI.CalcValue = (((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicDischargeDate == null ? "" : ((InPatientPhysicianApplication)creatingEpicrisis.MasterAction).InPatientTreatmentClinicApp.ClinicDischargeDate.ToString());
//                        valueSet = true;
//                    }
//                }
//                if(valueSet == false)
//                {
//                    if(creatingEpicrisis.ProcedureSpeciality != null)
//                    {
//                        IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
//                        inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetByEpisodeAndProcedureSpeciality(context,creatingEpicrisis.Episode.ObjectID,creatingEpicrisis.ProcedureSpeciality.ObjectID);
//                        if(inpatientTreatmentClinicList.Count > 0)
//                        {
//                            int count = inpatientTreatmentClinicList.Count;
//                            this.YATISTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[count-1]).ClinicInpatientDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[count-1]).ClinicInpatientDate.ToString());
//                            this.TABURCUTARIHI.CalcValue = (((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate ==null ? "" :((InPatientTreatmentClinicApplication)inpatientTreatmentClinicList[0]).ClinicDischargeDate.ToString());
//                        }
//                    }
//                }
//            }
//
#endregion NOT HEADER_Script
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField FIELDONAY;
                public TTReportField ISTEKDR;
                public TTReportField ONAY;
                public TTReportShape NewLine1;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField111;
                public TTReportField HospitalInformation; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 89;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FIELDONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 22, 191, 29, false);
                    FIELDONAY.Name = "FIELDONAY";
                    FIELDONAY.Visible = EvetHayirEnum.ehHayir;
                    FIELDONAY.MultiLine = EvetHayirEnum.ehEvet;
                    FIELDONAY.WordBreak = EvetHayirEnum.ehEvet;
                    FIELDONAY.TextFont.Name = "Arial Narrow";
                    FIELDONAY.Value = @"ONAYLI";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 77, 38, false);
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
                    ONAY.Visible = EvetHayirEnum.ehHayir;
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 47, 78, 52, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"Epikriz ve raporlarımı elden teslim aldım.
";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 53, 45, 58, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.CharSet = 1;
                    NewField2.Value = @"Hasta Adı Soyadı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 53, 78, 58, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.CharSet = 1;
                    NewField3.Value = @"İmza";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 73, 37, 77, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"İletişim Bilgileri:";

                    HospitalInformation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 73, 201, 87, false);
                    HospitalInformation.Name = "HospitalInformation";
                    HospitalInformation.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInformation.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInformation.TextFont.Name = "Arial Narrow";
                    HospitalInformation.TextFont.Size = 8;
                    HospitalInformation.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class dataset_GetEpicrisisPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class>(0);
                    FIELDONAY.CalcValue = FIELDONAY.Value;
                    ISTEKDR.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField111.CalcValue = NewField111.Value;
                    HospitalInformation.CalcValue = HospitalInformation.Value;
                    return new TTReportObject[] { FIELDONAY,ISTEKDR,ONAY,NewField1,NewField2,NewField3,NewField111,HospitalInformation};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    string doctor = MyParentReport.RuntimeParameters.Doctor;
            ResUser ru = MyParentReport.ReportObjectContext.GetObject<ResUser>(new Guid(doctor), false);
            if (ru != null)
                this.ISTEKDR.CalcValue = ru.SignatureBlock;

            //string sObjectID = MyParentReport.RuntimeParameters.TTOBJECTID;
            //EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            //    if ( episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor!=null)
            //        this.ISTEKDR.CalcValue = episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor.SignatureBlock;
            
            this.ONAY.CalcValue = TTObjectClasses.ResHospital.ApprovalSignatureBlock;
            this.HospitalInformation.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RadiologyUnitAddressInfo", "");
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class TANILARBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                 
                public TANILARBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class TANILARBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField1111191121;
                public TTReportField NewField0;
                public TTReportField NewField10;
                public TTReportShape NewLine1111;
                public TTReportField NewField1111191122; 
                public TANILARALTBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111191121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    NewField1111191121.Name = "NewField1111191121";
                    NewField1111191121.TextFont.Name = "Arial Narrow";
                    NewField1111191121.Value = @"Tarih";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 64, 12, false);
                    NewField0.Name = "NewField0";
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.Value = @"Tanı Adı";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 7, 179, 12, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.Value = @"Tanı Kodu";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111191122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 33, 6, false);
                    NewField1111191122.Name = "NewField1111191122";
                    NewField1111191122.TextFont.Name = "Arial Narrow";
                    NewField1111191122.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    CODE.Value = @"{#CODE#}";

                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.ForeColor = System.Drawing.Color.White;
                    DIAGNOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.TextFormat = @"Short Date";
                    DIAGNOSEDATE.TextFont.Name = "Arial Narrow";
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

        public partial class MAINGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public TTReportField SIKAYET { get {return Body().SIKAYET;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField1191;
                public TTReportField SIKAYET; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 5, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.Underline = true;
                    NewField1191.Value = @"YAKINMALAR VE ÖYKÜ:";

                    SIKAYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 200, 18, false);
                    SIKAYET.Name = "SIKAYET";
                    SIKAYET.MultiLine = EvetHayirEnum.ehEvet;
                    SIKAYET.NoClip = EvetHayirEnum.ehEvet;
                    SIKAYET.WordBreak = EvetHayirEnum.ehEvet;
                    SIKAYET.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIKAYET.TextFont.Name = "Arial Narrow";
                    SIKAYET.TextFont.CharSet = 1;
                    SIKAYET.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1191.CalcValue = NewField1191.Value;
                    SIKAYET.CalcValue = SIKAYET.Value;
                    return new TTReportObject[] { NewField1191,SIKAYET};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            if(episodeAction.Episode.Complaint!=null)
                this.SIKAYET.Value = TTReportTool.TTReport.HTMLtoText(episodeAction.Episode.Complaint.ToString()) + "\r\n";
            if(episodeAction.Episode.PatientHistory!=null)
                this.SIKAYET.Value += TTReportTool.TTReport.HTMLtoText(episodeAction.Episode.PatientHistory.ToString());
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        public partial class FIZIKMUAYENEGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public FIZIKMUAYENEGroupBody Body()
            {
                return (FIZIKMUAYENEGroupBody)_body;
            }
            public TTReportField NewField111911 { get {return Body().NewField111911;} }
            public TTReportField FIZIKMUAYENE { get {return Body().FIZIKMUAYENE;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField111911;
                public TTReportField FIZIKMUAYENE; 
                public FIZIKMUAYENEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 5, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.TextFont.Name = "Arial Narrow";
                    NewField111911.TextFont.Bold = true;
                    NewField111911.TextFont.Underline = true;
                    NewField111911.Value = @"FİZİK MUAYENE:";

                    FIZIKMUAYENE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 200, 18, false);
                    FIZIKMUAYENE.Name = "FIZIKMUAYENE";
                    FIZIKMUAYENE.MultiLine = EvetHayirEnum.ehEvet;
                    FIZIKMUAYENE.NoClip = EvetHayirEnum.ehEvet;
                    FIZIKMUAYENE.WordBreak = EvetHayirEnum.ehEvet;
                    FIZIKMUAYENE.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIZIKMUAYENE.TextFont.Name = "Arial Narrow";
                    FIZIKMUAYENE.TextFont.CharSet = 1;
                    FIZIKMUAYENE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111911.CalcValue = NewField111911.Value;
                    FIZIKMUAYENE.CalcValue = FIZIKMUAYENE.Value;
                    return new TTReportObject[] { NewField111911,FIZIKMUAYENE};
                }
                public override void RunPreScript()
                {
#region FIZIKMUAYENE BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            if(episodeAction.Episode.PhysicalExamination!=null)
                this.FIZIKMUAYENE.Value = TTReportTool.TTReport.HTMLtoText(episodeAction.Episode.PhysicalExamination.ToString()) + "\r\n";
#endregion FIZIKMUAYENE BODY_PreScript
                }
            }

        }

        public FIZIKMUAYENEGroup FIZIKMUAYENE;

        public partial class TEDAVIKARARGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public TEDAVIKARARGroupBody Body()
            {
                return (TEDAVIKARARGroupBody)_body;
            }
            public TTReportField NewField1119111 { get {return Body().NewField1119111;} }
            public TTReportField TEDAVIKARAR { get {return Body().TEDAVIKARAR;} }
            public TEDAVIKARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TEDAVIKARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TEDAVIKARARGroupBody(this);
            }

            public partial class TEDAVIKARARGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField1119111;
                public TTReportField TEDAVIKARAR; 
                public TEDAVIKARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 5, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.TextFont.Name = "Arial Narrow";
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.Underline = true;
                    NewField1119111.Value = @"TEDAVİ KARAR:";

                    TEDAVIKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 200, 18, false);
                    TEDAVIKARAR.Name = "TEDAVIKARAR";
                    TEDAVIKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVIKARAR.NoClip = EvetHayirEnum.ehEvet;
                    TEDAVIKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    TEDAVIKARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEDAVIKARAR.TextFont.Name = "Arial Narrow";
                    TEDAVIKARAR.TextFont.CharSet = 1;
                    TEDAVIKARAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1119111.CalcValue = NewField1119111.Value;
                    TEDAVIKARAR.CalcValue = TEDAVIKARAR.Value;
                    return new TTReportObject[] { NewField1119111,TEDAVIKARAR};
                }
                public override void RunPreScript()
                {
#region TEDAVIKARAR BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            if(episodeAction is PhysicianApplication)
            {
                this.TEDAVIKARAR.Value = ((PhysicianApplication)episodeAction).MTSConclusion != null ? TTReportTool.TTReport.HTMLtoText(((PhysicianApplication)episodeAction).MTSConclusion.ToString()) + "\r\n" : "";
            }else
            {
                if (episodeAction.Episode.MTSConclusion != null)
                    this.TEDAVIKARAR.Value = TTReportTool.TTReport.HTMLtoText(episodeAction.Episode.MTSConclusion.ToString()) + "\r\n";
            }
#endregion TEDAVIKARAR BODY_PreScript
                }
            }

        }

        public TEDAVIKARARGroup TEDAVIKARAR;

        public partial class SKRAPORGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public SKRAPORGroupBody Body()
            {
                return (SKRAPORGroupBody)_body;
            }
            public TTReportField NewField111191121 { get {return Body().NewField111191121;} }
            public TTReportRTF SKRAPOR { get {return Body().SKRAPOR;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField111191121;
                public TTReportRTF SKRAPOR; 
                public SKRAPORGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111191121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField111191121.Name = "NewField111191121";
                    NewField111191121.TextFont.Name = "Arial Narrow";
                    NewField111191121.TextFont.Bold = true;
                    NewField111191121.TextFont.Underline = true;
                    NewField111191121.Value = @"SAĞLIK KURULU RAPORU:";

                    SKRAPOR = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    SKRAPOR.Name = "SKRAPOR";
                    SKRAPOR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111191121.CalcValue = NewField111191121.Value;
                    SKRAPOR.CalcValue = SKRAPOR.Value;
                    return new TTReportObject[] { NewField111191121,SKRAPOR};
                }
                public override void RunPreScript()
                {
#region SKRAPOR BODY_PreScript
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
//            string conc = String.Empty;
//            foreach(HealthCommittee hc in creatingEpicrisis.Episode.HealthCommittees)
//            {
//                if(hc.CurrentStateDefID != HealthCommittee.States.Cancelled)
//                {
//                    if(hc.HCDecision != null && hc.HCDecision.ShowOnlyAddDecisionOnReports != true)
//                    {
//                        if(hc.HCDecisionTime != null)
//                        {
//                            this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
//                            conc += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
//                        }
//                        
//                        if(hc.HCDecisionUnitOfTime != null)
//                            conc += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
//                        
//                        if(hc.HCDecision != null)
//                        {
//                            conc += hc.HCDecision.Name;
//                            if(hc.Decision != null)
//                                conc += "\r\n";
//                        }
//                    }
//                    
//                    if(hc.Decision != null)
//                        conc += TTObjectClasses.Common.GetTextOfRTFString(hc.Decision.ToString());
//                    
//                    conc += "\r\n\r\n";
//                }
//            }
//            if(conc == String.Empty)
//                this.Visible = EvetHayirEnum.ehHayir;
//            else
//            {
//                this.Visible = EvetHayirEnum.ehEvet;
//                this.SKRAPOR.Value = TTObjectClasses.Common.GetRTFOfTextString(conc.ToString()) ;
//            }
#endregion SKRAPOR BODY_PreScript
                }
            }

        }

        public SKRAPORGroup SKRAPOR;

        public partial class LABTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public LABTETKIKBASLIKGroupHeader Header()
            {
                return (LABTETKIKBASLIKGroupHeader)_header;
            }

            new public LABTETKIKBASLIKGroupFooter Footer()
            {
                return (LABTETKIKBASLIKGroupFooter)_footer;
            }

            public TTReportField lableTarih1111 { get {return Header().lableTarih1111;} }
            public TTReportField LableOrtezAdı1111 { get {return Header().LableOrtezAdı1111;} }
            public TTReportField lableOrtezProtezCode111 { get {return Header().lableOrtezProtezCode111;} }
            public TTReportField lableLabTest1111 { get {return Header().lableLabTest1111;} }
            public TTReportShape NewLine11111111 { get {return Header().NewLine11111111;} }
            public TTReportShape NewLine112111111 { get {return Footer().NewLine112111111;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableTarih1111;
                public TTReportField LableOrtezAdı1111;
                public TTReportField lableOrtezProtezCode111;
                public TTReportField lableLabTest1111;
                public TTReportShape NewLine11111111; 
                public LABTETKIKBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 8, 40, 13, false);
                    lableTarih1111.Name = "lableTarih1111";
                    lableTarih1111.TextFont.Name = "Arial Narrow";
                    lableTarih1111.Value = @"Tarih";

                    LableOrtezAdı1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 8, 89, 13, false);
                    LableOrtezAdı1111.Name = "LableOrtezAdı1111";
                    LableOrtezAdı1111.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı1111.Value = @"Tetkik";

                    lableOrtezProtezCode111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 8, 188, 13, false);
                    lableOrtezProtezCode111.Name = "lableOrtezProtezCode111";
                    lableOrtezProtezCode111.TextFont.Name = "Arial Narrow";
                    lableOrtezProtezCode111.Value = @"Sonucu";

                    lableLabTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 2, 79, 7, false);
                    lableLabTest1111.Name = "lableLabTest1111";
                    lableLabTest1111.TextFont.Name = "Arial Narrow";
                    lableLabTest1111.TextFont.Bold = true;
                    lableLabTest1111.Value = @"LABORATUVAR TETKİKLERİ:";

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 14, 188, 14, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

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
            public partial class LABTETKIKBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportShape NewLine112111111; 
                public LABTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine112111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 2, 202, 2, false);
                    NewLine112111111.Name = "NewLine112111111";
                    NewLine112111111.DrawStyle = DrawStyleConstants.vbSolid;

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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportRTF LABTETKIKRTF;
                public TTReportField lableLabTest1111; 
                public LABTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 23;
                    RepeatCount = 0;
                    
                    LABTETKIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 7, 201, 22, false);
                    LABTETKIKRTF.Name = "LABTETKIKRTF";
                    LABTETKIKRTF.Value = @"";

                    lableLabTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 80, 6, false);
                    lableLabTest1111.Name = "lableLabTest1111";
                    lableLabTest1111.TextFont.Name = "Arial Narrow";
                    lableLabTest1111.TextFont.Bold = true;
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
            
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            //CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            //if( Globals.IsGuid(((EpicrisisReportForPatient)ParentReport).NOT.SUBEPISODE.CalcValue) )
            //{
            //    Guid subepisode = new Guid(((EpicrisisReportForPatient)ParentReport).NOT.SUBEPISODE.CalcValue);
                BindingList<TTObjectClasses.LaboratoryProcedure>  labProcedureList = LaboratoryProcedure.GetLabProceduresBySubEpisode(context,episodeAction.SubEpisode.ObjectID, episodeAction.Episode.ObjectID);
            //}
            //else
            //{
                //subepisode olmazsa episode bazlı çalışıyor
            //    labProcedureList = LaboratoryProcedure.GetLabProceduresByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            //}
            
            if(labProcedureList.Count<=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("LABTETKIKBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    lableTarih1111.Value = @"Tarih";

                    LableOrtezAdı1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableOrtezAdı1111.Name = "LableOrtezAdı1111";
                    LableOrtezAdı1111.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı1111.Value = @"Radyoloji Tetkiki";

                    lableOrtezProtezCode111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableOrtezProtezCode111.Name = "lableOrtezProtezCode111";
                    lableOrtezProtezCode111.TextFont.Name = "Arial Narrow";
                    lableOrtezProtezCode111.Value = @"Kodu";

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableLabTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableLabTest1111.Name = "lableLabTest1111";
                    lableLabTest1111.TextFont.Name = "Arial Narrow";
                    lableLabTest1111.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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

        public partial class RADTETKIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public RADTETKIKGroupBody Body()
            {
                return (RADTETKIKGroupBody)_body;
            }
            public TTReportField CODERAD { get {return Body().CODERAD;} }
            public TTReportField DATERAD { get {return Body().DATERAD;} }
            public TTReportField NAMERAD { get {return Body().NAMERAD;} }
            public RADTETKIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RADTETKIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RadiologyTest.GetRadiologyTestBySubEpisode_Class>("GetRadiologyTestBySubEpisode", RadiologyTest.GetRadiologyTestBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RADTETKIKGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class RADTETKIKGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField CODERAD;
                public TTReportField DATERAD;
                public TTReportField NAMERAD; 
                public RADTETKIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CODERAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 188, 6, false);
                    CODERAD.Name = "CODERAD";
                    CODERAD.ForeColor = System.Drawing.Color.White;
                    CODERAD.DrawStyle = DrawStyleConstants.vbSolid;
                    CODERAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODERAD.ObjectDefName = "RadiologyTest";
                    CODERAD.DataMember = "PROCEDUREOBJECT.CODE";
                    CODERAD.TextFont.Name = "Arial Narrow";
                    CODERAD.Value = @"{#OBJECTID#}";

                    DATERAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DATERAD.Name = "DATERAD";
                    DATERAD.ForeColor = System.Drawing.Color.White;
                    DATERAD.DrawStyle = DrawStyleConstants.vbSolid;
                    DATERAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATERAD.TextFormat = @"Short Date";
                    DATERAD.TextFont.Name = "Arial Narrow";
                    DATERAD.Value = @"{#ACTIONDATE#}";

                    NAMERAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 152, 6, false);
                    NAMERAD.Name = "NAMERAD";
                    NAMERAD.ForeColor = System.Drawing.Color.White;
                    NAMERAD.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMERAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMERAD.MultiLine = EvetHayirEnum.ehEvet;
                    NAMERAD.NoClip = EvetHayirEnum.ehEvet;
                    NAMERAD.WordBreak = EvetHayirEnum.ehEvet;
                    NAMERAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAMERAD.ObjectDefName = "RadiologyTest";
                    NAMERAD.DataMember = "PROCEDUREOBJECT.NAME";
                    NAMERAD.TextFont.Name = "Arial Narrow";
                    NAMERAD.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.GetRadiologyTestBySubEpisode_Class dataset_GetRadiologyTestBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.GetRadiologyTestBySubEpisode_Class>(0);
                    CODERAD.CalcValue = (dataset_GetRadiologyTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetRadiologyTestBySubEpisode.ObjectID) : "");
                    CODERAD.PostFieldValueCalculation();
                    DATERAD.CalcValue = (dataset_GetRadiologyTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetRadiologyTestBySubEpisode.ActionDate) : "");
                    NAMERAD.CalcValue = (dataset_GetRadiologyTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetRadiologyTestBySubEpisode.ObjectID) : "");
                    NAMERAD.PostFieldValueCalculation();
                    return new TTReportObject[] { CODERAD,DATERAD,NAMERAD};
                }
            }

        }

        public RADTETKIKGroup RADTETKIK;

        public partial class RADTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public RADTETKIKYENIGroupBody Body()
            {
                return (RADTETKIKYENIGroupBody)_body;
            }
            public TTReportField lableLabTest11111 { get {return Body().lableLabTest11111;} }
            public TTReportField RADTETKIKRTF { get {return Body().RADTETKIKRTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableLabTest11111;
                public TTReportField RADTETKIKRTF; 
                public RADTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    lableLabTest11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableLabTest11111.Name = "lableLabTest11111";
                    lableLabTest11111.TextFont.Name = "Arial Narrow";
                    lableLabTest11111.TextFont.Bold = true;
                    lableLabTest11111.Value = @"RADYOLOJİ TETKİKLERİ:";

                    RADTETKIKRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    RADTETKIKRTF.Name = "RADTETKIKRTF";
                    RADTETKIKRTF.TextFont.Name = "Arial Narrow";
                    RADTETKIKRTF.TextFont.CharSet = 1;
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
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            
            BindingList<TTObjectClasses.RadiologyTest> radTestList = RadiologyTest.GetRadTestBySubEpisode(context,episodeAction.SubEpisode.ObjectID, episodeAction.Episode.ObjectID.ToString());

            
            if(radTestList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {                
                bool IsRadTestListInProperState = false;                
                StringBuilder builder = new StringBuilder();
                foreach (RadiologyTest radTest in radTestList)
                {
                   if(radTest.CurrentStateDefID == RadiologyTest.States.ResultEntry || radTest.CurrentStateDefID == RadiologyTest.States.Approve || radTest.CurrentStateDefID == RadiologyTest.States.Completed || radTest.CurrentStateDefID == RadiologyTest.States.Reported)
                    {
                        builder.Append(Convert.ToDateTime(radTest.ActionDate).ToShortDateString() + " ");
                        builder.Append(radTest.ProcedureObject.Name + " ");
                        builder.Append("(" + radTest.ProcedureObject.MySUTCode + ")");
                        builder.Append(", ");
                        IsRadTestListInProperState = true;
                    }
                }
                //Eger tum radyolojik islemler, (sonuc girisi, onay, tamam) durumlari disinda bir durumdaysa RADTETKIKALTBASLIK alani gorunmez yapilir.
                if(IsRadTestListInProperState)
                {
                    this.Visible = EvetHayirEnum.ehEvet;
                    ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                }
                else
                {
                     this.Visible = EvetHayirEnum.ehHayir;
                   ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("RADTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
                }
                this.RADTETKIKRTF.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString()) + "\r\n";
            }
#endregion RADTETKIKYENI BODY_PreScript
                }
            }

        }

        public RADTETKIKYENIGroup RADTETKIKYENI;

        public partial class PATTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                 
                public PATTETKIKBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PATTETKIKBASLIKGroup PATTETKIKBASLIK;

        public partial class PATTETKIKALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableTarih111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 40, 12, false);
                    lableTarih111111.Name = "lableTarih111111";
                    lableTarih111111.TextFont.Name = "Arial Narrow";
                    lableTarih111111.Value = @"Tarih";

                    LablePatAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LablePatAdı.Name = "LablePatAdı";
                    LablePatAdı.TextFont.Name = "Arial Narrow";
                    LablePatAdı.Value = @"Patoloji Tetkiki";

                    lablePatCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lablePatCode.Name = "lablePatCode";
                    lablePatCode.TextFont.Name = "Arial Narrow";
                    lablePatCode.Value = @"Kodu";

                    NewLine1111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine1111111111.Name = "NewLine1111111111";
                    NewLine1111111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lablePatTest1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lablePatTest1.Name = "lablePatTest1";
                    lablePatTest1.TextFont.Name = "Arial Narrow";
                    lablePatTest1.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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

        public partial class PATOBJECTHeaderGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public PATOBJECTHeaderGroupHeader Header()
            {
                return (PATOBJECTHeaderGroupHeader)_header;
            }

            new public PATOBJECTHeaderGroupFooter Footer()
            {
                return (PATOBJECTHeaderGroupFooter)_footer;
            }

            public TTReportField PATHOLOGYOBJID { get {return Header().PATHOLOGYOBJID;} }
            public PATOBJECTHeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATOBJECTHeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.GetPathologyTestBySubEpisode_Class>("GetPathologyTestBySubEpisode", Pathology.GetPathologyTestBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PATOBJECTHeaderGroupHeader(this);
                _footer = new PATOBJECTHeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PATOBJECTHeaderGroupHeader : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField PATHOLOGYOBJID; 
                public PATOBJECTHeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PATHOLOGYOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
                    PATHOLOGYOBJID.Name = "PATHOLOGYOBJID";
                    PATHOLOGYOBJID.Visible = EvetHayirEnum.ehHayir;
                    PATHOLOGYOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATHOLOGYOBJID.TextFont.Name = "Arial Narrow";
                    PATHOLOGYOBJID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.GetPathologyTestBySubEpisode_Class dataset_GetPathologyTestBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<Pathology.GetPathologyTestBySubEpisode_Class>(0);
                    PATHOLOGYOBJID.CalcValue = (dataset_GetPathologyTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetPathologyTestBySubEpisode.ObjectID) : "");
                    return new TTReportObject[] { PATHOLOGYOBJID};
                }
            }
            public partial class PATOBJECTHeaderGroupFooter : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                 
                public PATOBJECTHeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PATOBJECTHeaderGroup PATOBJECTHeader;

        public partial class PATTETKIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public PATTETKIKGroupBody Body()
            {
                return (PATTETKIKGroupBody)_body;
            }
            public TTReportField CODEPAT { get {return Body().CODEPAT;} }
            public TTReportField DATEPAT { get {return Body().DATEPAT;} }
            public TTReportField NAMEPAT { get {return Body().NAMEPAT;} }
            public PATTETKIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATTETKIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class>("PathologyTestProcedureByObjectIDQuery", PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.PATOBJECTHeader.PATHOLOGYOBJID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PATTETKIKGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PATTETKIKGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField CODEPAT;
                public TTReportField DATEPAT;
                public TTReportField NAMEPAT; 
                public PATTETKIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    CODEPAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 188, 6, false);
                    CODEPAT.Name = "CODEPAT";
                    CODEPAT.ForeColor = System.Drawing.Color.White;
                    CODEPAT.DrawStyle = DrawStyleConstants.vbSolid;
                    CODEPAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODEPAT.ObjectDefName = "PathologyTestProcedure";
                    CODEPAT.DataMember = "PROCEDUREOBJECT.NAME";
                    CODEPAT.TextFont.Name = "Arial Narrow";
                    CODEPAT.Value = @"{#OBJECTID#}";

                    DATEPAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DATEPAT.Name = "DATEPAT";
                    DATEPAT.ForeColor = System.Drawing.Color.White;
                    DATEPAT.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEPAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEPAT.TextFormat = @"Short Date";
                    DATEPAT.TextFont.Name = "Arial Narrow";
                    DATEPAT.Value = @"{#ACTIONDATE#}";

                    NAMEPAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 152, 6, false);
                    NAMEPAT.Name = "NAMEPAT";
                    NAMEPAT.ForeColor = System.Drawing.Color.White;
                    NAMEPAT.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMEPAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMEPAT.MultiLine = EvetHayirEnum.ehEvet;
                    NAMEPAT.NoClip = EvetHayirEnum.ehEvet;
                    NAMEPAT.WordBreak = EvetHayirEnum.ehEvet;
                    NAMEPAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAMEPAT.ObjectDefName = "PathologyTestProcedure";
                    NAMEPAT.DataMember = "PROCEDUREOBJECT.NAME";
                    NAMEPAT.TextFont.Name = "Arial Narrow";
                    NAMEPAT.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class dataset_PathologyTestProcedureByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class>(0);
                    CODEPAT.CalcValue = (dataset_PathologyTestProcedureByObjectIDQuery != null ? Globals.ToStringCore(dataset_PathologyTestProcedureByObjectIDQuery.ObjectID) : "");
                    CODEPAT.PostFieldValueCalculation();
                    DATEPAT.CalcValue = (dataset_PathologyTestProcedureByObjectIDQuery != null ? Globals.ToStringCore(dataset_PathologyTestProcedureByObjectIDQuery.ActionDate) : "");
                    NAMEPAT.CalcValue = (dataset_PathologyTestProcedureByObjectIDQuery != null ? Globals.ToStringCore(dataset_PathologyTestProcedureByObjectIDQuery.ObjectID) : "");
                    NAMEPAT.PostFieldValueCalculation();
                    return new TTReportObject[] { CODEPAT,DATEPAT,NAMEPAT};
                }
            }

        }

        public PATTETKIKGroup PATTETKIK;

        public partial class PATTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportRTF PATTETKIKRTF;
                public TTReportField lablePatTest11; 
                public PATTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATTETKIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    PATTETKIKRTF.Name = "PATTETKIKRTF";
                    PATTETKIKRTF.Value = @"";

                    lablePatTest11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lablePatTest11.Name = "lablePatTest11";
                    lablePatTest11.TextFont.Name = "Arial Narrow";
                    lablePatTest11.TextFont.Bold = true;
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
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
//            
//            BindingList<TTObjectClasses.PathologyTest> patTestList = PathologyTest.GetPatTestByEpisode(context,creatingEpicrisis.Episode.ObjectID);
//            if(patTestList.Count <=0)
//            {
//                this.Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("PATTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                this.Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("PATTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                
//                StringBuilder builder = new StringBuilder();
//                foreach (PathologyTest patTest in patTestList)
//                {
//                    builder.Append(Convert.ToDateTime(patTest.ActionDate).ToShortDateString() + " ");
//                    builder.Append(patTest.ProcedureObject.Name + " ");
//                    builder.Append("(" + patTest.ProcedureObject.MySUTCode + ")");
//                    builder.Append(", ");
//                }
//                this.PATTETKIKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
//            }
#endregion PATTETKIKYENI BODY_PreScript
                }
            }

        }

        public PATTETKIKYENIGroup PATTETKIKYENI;

        public partial class NUKTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    lableTarihNUK.Value = @"Tarih";

                    LableNukAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableNukAdı.Name = "LableNukAdı";
                    LableNukAdı.TextFont.Name = "Arial Narrow";
                    LableNukAdı.Value = @"Nükleer Tıp Tetkiki";

                    lableNukCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableNukCode.Name = "lableNukCode";
                    lableNukCode.TextFont.Name = "Arial Narrow";
                    lableNukCode.Value = @"Kodu";

                    NewLine1211111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 188, 13, false);
                    NewLine1211111211.Name = "NewLine1211111211";
                    NewLine1211111211.DrawStyle = DrawStyleConstants.vbSolid;

                    lableNucTest11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest11.Name = "lableNucTest11";
                    lableNucTest11.TextFont.Name = "Arial Narrow";
                    lableNucTest11.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportShape NewLine1111111211; 
                public NUKTETKIKALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
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

        public partial class NUKTETKIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public NUKTETKIKGroupBody Body()
            {
                return (NUKTETKIKGroupBody)_body;
            }
            public TTReportField CODENUC { get {return Body().CODENUC;} }
            public TTReportField DATENUC { get {return Body().DATENUC;} }
            public TTReportField NAMENUK { get {return Body().NAMENUK;} }
            public NUKTETKIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NUKTETKIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode_Class>("GetNuclearMedicineTestBySubEpisode", NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new NUKTETKIKGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NUKTETKIKGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField CODENUC;
                public TTReportField DATENUC;
                public TTReportField NAMENUK; 
                public NUKTETKIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CODENUC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 188, 6, false);
                    CODENUC.Name = "CODENUC";
                    CODENUC.ForeColor = System.Drawing.Color.White;
                    CODENUC.DrawStyle = DrawStyleConstants.vbSolid;
                    CODENUC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODENUC.ObjectDefName = "NuclearMedicineTest";
                    CODENUC.DataMember = "PROCEDUREOBJECT.CODE";
                    CODENUC.TextFont.Name = "Arial Narrow";
                    CODENUC.Value = @"{#OBJECTID#}";

                    DATENUC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DATENUC.Name = "DATENUC";
                    DATENUC.ForeColor = System.Drawing.Color.White;
                    DATENUC.DrawStyle = DrawStyleConstants.vbSolid;
                    DATENUC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATENUC.TextFormat = @"Short Date";
                    DATENUC.TextFont.Name = "Arial Narrow";
                    DATENUC.Value = @"{#ACTIONDATE#}";

                    NAMENUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 152, 6, false);
                    NAMENUK.Name = "NAMENUK";
                    NAMENUK.ForeColor = System.Drawing.Color.White;
                    NAMENUK.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMENUK.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMENUK.MultiLine = EvetHayirEnum.ehEvet;
                    NAMENUK.NoClip = EvetHayirEnum.ehEvet;
                    NAMENUK.WordBreak = EvetHayirEnum.ehEvet;
                    NAMENUK.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAMENUK.ObjectDefName = "NuclearMedicineTest";
                    NAMENUK.DataMember = "PROCEDUREOBJECT.NAME";
                    NAMENUK.TextFont.Name = "Arial Narrow";
                    NAMENUK.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode_Class dataset_GetNuclearMedicineTestBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<NuclearMedicineTest.GetNuclearMedicineTestBySubEpisode_Class>(0);
                    CODENUC.CalcValue = (dataset_GetNuclearMedicineTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetNuclearMedicineTestBySubEpisode.ObjectID) : "");
                    CODENUC.PostFieldValueCalculation();
                    DATENUC.CalcValue = (dataset_GetNuclearMedicineTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetNuclearMedicineTestBySubEpisode.ActionDate) : "");
                    NAMENUK.CalcValue = (dataset_GetNuclearMedicineTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetNuclearMedicineTestBySubEpisode.ObjectID) : "");
                    NAMENUK.PostFieldValueCalculation();
                    return new TTReportObject[] { CODENUC,DATENUC,NAMENUK};
                }
            }

        }

        public NUKTETKIKGroup NUKTETKIK;

        public partial class NUKTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportRTF NUKLEERRTF;
                public TTReportField lableNucTest111; 
                public NUKTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NUKLEERRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    NUKLEERRTF.Name = "NUKLEERRTF";
                    NUKLEERRTF.Value = @"";

                    lableNucTest111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest111.Name = "lableNucTest111";
                    lableNucTest111.TextFont.Name = "Arial Narrow";
                    lableNucTest111.TextFont.Bold = true;
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
                    /*TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            
            BindingList<TTObjectClasses.NuclearMedicineTest> nuclearMedicineTestList = NuclearMedicineTest.GetNuclearTestByEpisode(context,creatingEpicrisis.Episode.ObjectID);
            if(nuclearMedicineTestList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("NUKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("NUKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (NuclearMedicineTest nuclearMedicineTest in nuclearMedicineTestList)
                {
                    builder.Append(Convert.ToDateTime(nuclearMedicineTest.ActionDate).ToShortDateString() + " ");
                    builder.Append(nuclearMedicineTest.ProcedureObject.Name + " ");
                    builder.Append("(" + nuclearMedicineTest.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.NUKLEERRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
            }*/
#endregion NUKTETKIKYENI BODY_PreScript
                }
            }

        }

        public NUKTETKIKYENIGroup NUKTETKIKYENI;

        public partial class GENETIKTETKIKBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    lableTarih1111111.Value = @"Tarih";

                    LableGenetikAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableGenetikAdı.Name = "LableGenetikAdı";
                    LableGenetikAdı.TextFont.Name = "Arial Narrow";
                    LableGenetikAdı.Value = @"Tıbbi Genetik Tetkiki";

                    lableGenetikCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableGenetikCode.Name = "lableGenetikCode";
                    lableGenetikCode.TextFont.Name = "Arial Narrow";
                    lableGenetikCode.Value = @"Kodu";

                    NewLine112111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 188, 13, false);
                    NewLine112111112.Name = "NewLine112111112";
                    NewLine112111112.DrawStyle = DrawStyleConstants.vbSolid;

                    lableGenetikTest1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableGenetikTest1.Name = "lableGenetikTest1";
                    lableGenetikTest1.TextFont.Name = "Arial Narrow";
                    lableGenetikTest1.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportShape NewLine112111111; 
                public GENETIKTETKIKALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
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

        public partial class GENETIKTETKIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public GENETIKTETKIKGroupBody Body()
            {
                return (GENETIKTETKIKGroupBody)_body;
            }
            public TTReportField CODEGENETIC { get {return Body().CODEGENETIC;} }
            public TTReportField DATEGENETIK { get {return Body().DATEGENETIK;} }
            public TTReportField NAMEGENETIK { get {return Body().NAMEGENETIK;} }
            public GENETIKTETKIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GENETIKTETKIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<GeneticTest.GetGeneticTestBySubEpisode_Class>("GetGeneticTestBySubEpisode", GeneticTest.GetGeneticTestBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new GENETIKTETKIKGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class GENETIKTETKIKGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField CODEGENETIC;
                public TTReportField DATEGENETIK;
                public TTReportField NAMEGENETIK; 
                public GENETIKTETKIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CODEGENETIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 188, 6, false);
                    CODEGENETIC.Name = "CODEGENETIC";
                    CODEGENETIC.ForeColor = System.Drawing.Color.White;
                    CODEGENETIC.DrawStyle = DrawStyleConstants.vbSolid;
                    CODEGENETIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODEGENETIC.ObjectDefName = "GeneticTest";
                    CODEGENETIC.DataMember = "PROCEDUREOBJECT.CODE";
                    CODEGENETIC.TextFont.Name = "Arial Narrow";
                    CODEGENETIC.Value = @"{#OBJECTID#}";

                    DATEGENETIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DATEGENETIK.Name = "DATEGENETIK";
                    DATEGENETIK.ForeColor = System.Drawing.Color.White;
                    DATEGENETIK.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEGENETIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEGENETIK.TextFormat = @"Short Date";
                    DATEGENETIK.TextFont.Name = "Arial Narrow";
                    DATEGENETIK.Value = @"{#ACTIONDATE#}";

                    NAMEGENETIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 152, 6, false);
                    NAMEGENETIK.Name = "NAMEGENETIK";
                    NAMEGENETIK.ForeColor = System.Drawing.Color.White;
                    NAMEGENETIK.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMEGENETIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMEGENETIK.MultiLine = EvetHayirEnum.ehEvet;
                    NAMEGENETIK.NoClip = EvetHayirEnum.ehEvet;
                    NAMEGENETIK.WordBreak = EvetHayirEnum.ehEvet;
                    NAMEGENETIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAMEGENETIK.ObjectDefName = "GeneticTest";
                    NAMEGENETIK.DataMember = "PROCEDUREOBJECT.NAME";
                    NAMEGENETIK.TextFont.Name = "Arial Narrow";
                    NAMEGENETIK.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneticTest.GetGeneticTestBySubEpisode_Class dataset_GetGeneticTestBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<GeneticTest.GetGeneticTestBySubEpisode_Class>(0);
                    CODEGENETIC.CalcValue = (dataset_GetGeneticTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetGeneticTestBySubEpisode.ObjectID) : "");
                    CODEGENETIC.PostFieldValueCalculation();
                    DATEGENETIK.CalcValue = (dataset_GetGeneticTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetGeneticTestBySubEpisode.ActionDate) : "");
                    NAMEGENETIK.CalcValue = (dataset_GetGeneticTestBySubEpisode != null ? Globals.ToStringCore(dataset_GetGeneticTestBySubEpisode.ObjectID) : "");
                    NAMEGENETIK.PostFieldValueCalculation();
                    return new TTReportObject[] { CODEGENETIC,DATEGENETIK,NAMEGENETIK};
                }
            }

        }

        public GENETIKTETKIKGroup GENETIKTETKIK;

        public partial class GENETIKTETKIKYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportRTF GENETIKRTF;
                public TTReportField lableGenetikTest11; 
                public GENETIKTETKIKYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    GENETIKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 7, 200, 19, false);
                    GENETIKRTF.Name = "GENETIKRTF";
                    GENETIKRTF.Value = @"";

                    lableGenetikTest11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableGenetikTest11.Name = "lableGenetikTest11";
                    lableGenetikTest11.TextFont.Name = "Arial Narrow";
                    lableGenetikTest11.TextFont.Bold = true;
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
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
//            
//            BindingList<TTObjectClasses.GeneticTest> geneticTestList = GeneticTest.GetGeneticByEpisode(context,creatingEpicrisis.Episode.ObjectID);
//            if(geneticTestList.Count <=0)
//            {
//                this.Visible = EvetHayirEnum.ehHayir;
//                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                this.Visible = EvetHayirEnum.ehEvet;
//                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("GENETIKTETKIKALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
//                
//                StringBuilder builder = new StringBuilder();
//                foreach (GeneticTest geneticTest in geneticTestList)
//                {
//                    builder.Append(Convert.ToDateTime(geneticTest.ActionDate).ToShortDateString() + " ");
//                    builder.Append(geneticTest.ProcedureObject.Name + " ");
//                    builder.Append("(" + geneticTest.ProcedureObject.MySUTCode + ")");
//                    builder.Append(", ");
//                }
//                this.GENETIKRTF.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
//            }
#endregion GENETIKTETKIKYENI BODY_PreScript
                }
            }

        }

        public GENETIKTETKIKYENIGroup GENETIKTETKIKYENI;

        public partial class KONSULTASYONBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public KONSULTASYONGroupBody Body()
            {
                return (KONSULTASYONGroupBody)_body;
            }
            public TTReportField NewField1121191111 { get {return Body().NewField1121191111;} }
            public TTReportField KONSULTASYONRTF { get {return Body().KONSULTASYONRTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField1121191111;
                public TTReportField KONSULTASYONRTF; 
                public KONSULTASYONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    NewField1121191111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField1121191111.Name = "NewField1121191111";
                    NewField1121191111.TextFont.Name = "Arial Narrow";
                    NewField1121191111.TextFont.Bold = true;
                    NewField1121191111.Value = @"KONSÜLTASYONLAR :";

                    KONSULTASYONRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 200, 20, false);
                    KONSULTASYONRTF.Name = "KONSULTASYONRTF";
                    KONSULTASYONRTF.MultiLine = EvetHayirEnum.ehEvet;
                    KONSULTASYONRTF.NoClip = EvetHayirEnum.ehEvet;
                    KONSULTASYONRTF.WordBreak = EvetHayirEnum.ehEvet;
                    KONSULTASYONRTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONSULTASYONRTF.TextFont.Name = "Arial Narrow";
                    KONSULTASYONRTF.TextFont.CharSet = 1;
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
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            StringBuilder builder = new StringBuilder();
            int counter =1;
            BindingList<EpisodeAction> consFromOtherHospList = EpisodeAction.GetConsFromOtherHospOfSubEpisode(context, episodeAction.SubEpisode.ObjectID, episodeAction.Episode.ObjectID.ToString());
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
                    builder.Append("İstek Sebebi : " + TTReportTool.TTReport.HTMLtoText(consFromOtherHosp.RequestDescription));
                    builder.AppendLine();
                    if(consFromOtherHosp.ConsultationResultAndOffers != null)
                    {
                        builder.Append("Konsültasyon Sonucu ve Öneriler : " + TTReportTool.TTReport.HTMLtoText(consFromOtherHosp.ConsultationResultAndOffers.ToString()));
                        builder.AppendLine();
                    }
                    IsConsListInProperState = true;                    
                }
            }

            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)context.GetObject(hospID, typeof(ResHospital));
            BindingList<SubActionProcedure> consProcedureList = SubActionProcedure.GetAllConsultationProcOfSubEpisode(context, episodeAction.Episode.ObjectID.ToString(), episodeAction.SubEpisode.ObjectID.ToString());
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
                        builder.Append("İstek Sebebi : " + TTReportTool.TTReport.HTMLtoText(consProcedure.Consultation.RequestDescription.ToString()));
                        builder.AppendLine();
                    }
                    if(consProcedure.Consultation.ConsultationResultAndOffers != null)
                    {
                        builder.Append("Konsültasyon Sonucu ve Öneriler : " + TTReportTool.TTReport.HTMLtoText(consProcedure.Consultation.ConsultationResultAndOffers.ToString()));
                        builder.AppendLine();
                    }
                    IsConsListInProperState = true;
                }
            }
            
            BindingList<EpisodeAction> anesthesiaConsList = EpisodeAction.GetAllAnesthesiaConsultationOfSubEpisode(context, episodeAction.SubEpisode.ObjectID.ToString(), episodeAction.Episode.ObjectID.ToString());
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
                        builder.Append("İstek Sebebi : " + TTReportTool.TTReport.HTMLtoText(anesthesiaConsultation.ConsultationRequestNote.ToString()));
                        builder.AppendLine();
                    }
                    if(anesthesiaConsultation.ConsultationResult != null)
                    {
                        builder.Append("Konsültasyon Sonucu ve Öneriler : " + TTReportTool.TTReport.HTMLtoText(anesthesiaConsultation.ConsultationResult.ToString()));
                        builder.AppendLine();
                    }
                    IsConsListInProperState = true;
                }
            }
            if(builder.ToString() == String.Empty || IsConsListInProperState == false)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("KONSULTASYONBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("KONSULTASYONBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                this.KONSULTASYONRTF.Value =  builder.ToString();
            }
#endregion KONSULTASYON BODY_PreScript
                }
            }

        }

        public KONSULTASYONGroup KONSULTASYON;

        public partial class GUNLUKGOZLEMBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    lableTarih11.Value = @"Tarih";

                    LableOrtezAdı11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 7, 110, 12, false);
                    LableOrtezAdı11.Name = "LableOrtezAdı11";
                    LableOrtezAdı11.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı11.Value = @"Klinik İzlem Açıklaması";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 189, 13, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableTıbbiMlz111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 43, 6, false);
                    lableTıbbiMlz111.Name = "lableTıbbiMlz111";
                    lableTıbbiMlz111.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz111.TextFont.Bold = true;
                    lableTıbbiMlz111.Value = @"KLİNİK İZLEM:";

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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public GUNLUKGOZLEMGroupBody Body()
            {
                return (GUNLUKGOZLEMGroupBody)_body;
            }
            public TTReportField PRODESC { get {return Body().PRODESC;} }
            public TTReportField DATEPRO { get {return Body().DATEPRO;} }
            public TTReportRTF PROSSDESC { get {return Body().PROSSDESC;} }
            public TTReportField GUNLUKOBJECTID { get {return Body().GUNLUKOBJECTID;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField PRODESC;
                public TTReportField DATEPRO;
                public TTReportRTF PROSSDESC;
                public TTReportField GUNLUKOBJECTID; 
                public GUNLUKGOZLEMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    PRODESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 200, 7, false);
                    PRODESC.Name = "PRODESC";
                    PRODESC.ForeColor = System.Drawing.Color.White;
                    PRODESC.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODESC.MultiLine = EvetHayirEnum.ehEvet;
                    PRODESC.NoClip = EvetHayirEnum.ehEvet;
                    PRODESC.WordBreak = EvetHayirEnum.ehEvet;
                    PRODESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRODESC.TextFont.Name = "Arial Narrow";
                    PRODESC.Value = @"";

                    DATEPRO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 49, 6, false);
                    DATEPRO.Name = "DATEPRO";
                    DATEPRO.ForeColor = System.Drawing.Color.White;
                    DATEPRO.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEPRO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEPRO.TextFormat = @"dd/MM/yyyy HH:mm";
                    DATEPRO.TextFont.Name = "Arial Narrow";
                    DATEPRO.Value = @"{#PROGRESSDATE#}";

                    PROSSDESC = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 236, 1, 275, 7, false);
                    PROSSDESC.Name = "PROSSDESC";
                    PROSSDESC.Visible = EvetHayirEnum.ehHayir;
                    PROSSDESC.EvaluateValue = EvetHayirEnum.ehEvet;
                    PROSSDESC.Value = @"";

                    GUNLUKOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 1, 235, 7, false);
                    GUNLUKOBJECTID.Name = "GUNLUKOBJECTID";
                    GUNLUKOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    GUNLUKOBJECTID.ForeColor = System.Drawing.Color.White;
                    GUNLUKOBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    GUNLUKOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUNLUKOBJECTID.TextFont.Name = "Arial Narrow";
                    GUNLUKOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class dataset_GetInpatienPhProgressesBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class>(0);
                    PRODESC.CalcValue = PRODESC.Value;
                    DATEPRO.CalcValue = (dataset_GetInpatienPhProgressesBySubEpisode != null ? Globals.ToStringCore(dataset_GetInpatienPhProgressesBySubEpisode.ProgressDate) : "");
                    PROSSDESC.CalcValue = PROSSDESC.Value;
                    GUNLUKOBJECTID.CalcValue = (dataset_GetInpatienPhProgressesBySubEpisode != null ? Globals.ToStringCore(dataset_GetInpatienPhProgressesBySubEpisode.ObjectID) : "");
                    return new TTReportObject[] { PRODESC,DATEPRO,PROSSDESC,GUNLUKOBJECTID};
                }
                public override void RunPreScript()
                {
#region GUNLUKGOZLEM BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            var dataset_GetInpatienPhProgressesBySubEpisode=ParentGroup.rsGroup.GetCurrentRecord<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class>(0);
            string sObjectID =  (dataset_GetInpatienPhProgressesBySubEpisode != null ? Globals.ToStringCore(dataset_GetInpatienPhProgressesBySubEpisode.ObjectID) : "");
            InPatientPhysicianProgresses inPatientPhysicianProgresses = (InPatientPhysicianProgresses)context.GetObject(new Guid(sObjectID),"InPatientPhysicianProgresses");
            if(inPatientPhysicianProgresses.Description!=null)
                this.PRODESC.Value =  TTReportTool.TTReport.HTMLtoText(inPatientPhysicianProgresses.Description.ToString());
#endregion GUNLUKGOZLEM BODY_PreScript
                }
            }

        }

        public GUNLUKGOZLEMGroup GUNLUKGOZLEM;

        public partial class AMELIYATBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public AMELIYATBASLIKGroupHeader Header()
            {
                return (AMELIYATBASLIKGroupHeader)_header;
            }

            new public AMELIYATBASLIKGroupFooter Footer()
            {
                return (AMELIYATBASLIKGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportShape NewLine1211111 { get {return Footer().NewLine1211111;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public AMELIYATBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 57, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.Value = @"AMELİYATLAR:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportShape NewLine1211111; 
                public AMELIYATBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1211111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 200, 3, false);
                    NewLine1211111.Name = "NewLine1211111";
                    NewLine1211111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public AMELIYATBASLIKGroup AMELIYATBASLIK;

        public partial class AMELIYATVEANESTEZIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    CODE.Value = @"{#CODE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.ForeColor = System.Drawing.Color.White;
                    TARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.TextFont.Name = "Arial Narrow";
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
                    NAME.Value = @"{#NAME#}";

                    ANSTEZITYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 1, 178, 6, false);
                    ANSTEZITYPE.Name = "ANSTEZITYPE";
                    ANSTEZITYPE.ForeColor = System.Drawing.Color.White;
                    ANSTEZITYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    ANSTEZITYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANSTEZITYPE.MultiLine = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.NoClip = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.WordBreak = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ANSTEZITYPE.TextFont.Name = "Arial Narrow";
                    ANSTEZITYPE.Value = @"";

                    SURGERYOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 251, 6, false);
                    SURGERYOBJECTID.Name = "SURGERYOBJECTID";
                    SURGERYOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    SURGERYOBJECTID.ForeColor = System.Drawing.Color.White;
                    SURGERYOBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    SURGERYOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURGERYOBJECTID.TextFont.Name = "Arial Narrow";
                    SURGERYOBJECTID.Value = @"{#OBJECTID#}";

                    ANESTHESIACODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 200, 6, false);
                    ANESTHESIACODE.Name = "ANESTHESIACODE";
                    ANESTHESIACODE.ForeColor = System.Drawing.Color.White;
                    ANESTHESIACODE.DrawStyle = DrawStyleConstants.vbSolid;
                    ANESTHESIACODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANESTHESIACODE.TextFont.Name = "Arial Narrow";
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape NewLine11111; 
                public PLANLITIBBIISLEMBASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 56, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.Value = @"PLANLI TIBBI İŞLEMLER:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 8, 43, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.CharSet = 1;
                    NewField2.Value = @"Tarih";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 8, 70, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.CharSet = 1;
                    NewField3.Value = @"İşlem";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 8, 182, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.CharSet = 1;
                    NewField4.Value = @"İşlem Kodu";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 14, 200, 14, false);
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public PLANLITIBBIISLEMGroupBody Body()
            {
                return (PLANLITIBBIISLEMGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField PLANLITIBBIISLEMLER { get {return Body().PLANLITIBBIISLEMLER;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField PLANLITIBBIISLEMLER; 
                public PLANLITIBBIISLEMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 24;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 56, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"PLANLI TIBBI İŞLEMLER:";

                    PLANLITIBBIISLEMLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 199, 22, false);
                    PLANLITIBBIISLEMLER.Name = "PLANLITIBBIISLEMLER";
                    PLANLITIBBIISLEMLER.MultiLine = EvetHayirEnum.ehEvet;
                    PLANLITIBBIISLEMLER.NoClip = EvetHayirEnum.ehEvet;
                    PLANLITIBBIISLEMLER.WordBreak = EvetHayirEnum.ehEvet;
                    PLANLITIBBIISLEMLER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PLANLITIBBIISLEMLER.TextFont.Name = "Arial Narrow";
                    PLANLITIBBIISLEMLER.TextFont.CharSet = 1;
                    PLANLITIBBIISLEMLER.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class dataset_PlannedMedicalActionOrderDetailEpic = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionOrderDetail.PlannedMedicalActionOrderDetailEpic_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    PLANLITIBBIISLEMLER.CalcValue = PLANLITIBBIISLEMLER.Value;
                    return new TTReportObject[] { NewField11,PLANLITIBBIISLEMLER};
                }

                public override void RunScript()
                {
#region PLANLITIBBIISLEM BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
             BindingList<TTObjectClasses.PlannedMedicalActionOrderDetail> plannedMedicalActionOrderList = PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByEpisode(context,episodeAction.Episode.ObjectID.ToString());
            if(plannedMedicalActionOrderList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("PLANLITIBBIISLEMBASLIK").Body)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("PLANLITIBBIISLEMBASLIK").Body)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (PlannedMedicalActionOrderDetail plannedMedicalActionOrder in plannedMedicalActionOrderList)
                {
                    builder.Append(Convert.ToDateTime(plannedMedicalActionOrder.ActionDate).ToShortDateString() + " ");
                    builder.Append(plannedMedicalActionOrder.ProcedureObject.Name + " ");
                    builder.Append("(" + plannedMedicalActionOrder.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.PLANLITIBBIISLEMLER.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString());
            }
#endregion PLANLITIBBIISLEM BODY_Script
                }
            }

        }

        public PLANLITIBBIISLEMGroup PLANLITIBBIISLEM;

        public partial class MANIPLATIONALTBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    lableTarihMAN.Value = @"Tarih";

                    LableManiplasyonAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableManiplasyonAdı.Name = "LableManiplasyonAdı";
                    LableManiplasyonAdı.TextFont.Name = "Arial Narrow";
                    LableManiplasyonAdı.Value = @"Tıbbi Cerrahi Uygulama";

                    lableManCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableManCode.Name = "lableManCode";
                    lableManCode.TextFont.Name = "Arial Narrow";
                    lableManCode.Value = @"Kodu";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 188, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    lableNucTest111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest111.Name = "lableNucTest111";
                    lableNucTest111.TextFont.Name = "Arial Narrow";
                    lableNucTest111.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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

        public partial class MANIPLATIONGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public MANIPLATIONGroupBody Body()
            {
                return (MANIPLATIONGroupBody)_body;
            }
            public TTReportField CODEMAN { get {return Body().CODEMAN;} }
            public TTReportField DATEMAN { get {return Body().DATEMAN;} }
            public TTReportField NAMEMAN { get {return Body().NAMEMAN;} }
            public MANIPLATIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MANIPLATIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ManipulationProcedure.GetManipulationProceduresBySubEpisode_Class>("GetManipulationProceduresBySubEpisode", ManipulationProcedure.GetManipulationProceduresBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MANIPLATIONGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MANIPLATIONGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField CODEMAN;
                public TTReportField DATEMAN;
                public TTReportField NAMEMAN; 
                public MANIPLATIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CODEMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 188, 6, false);
                    CODEMAN.Name = "CODEMAN";
                    CODEMAN.ForeColor = System.Drawing.Color.White;
                    CODEMAN.DrawStyle = DrawStyleConstants.vbSolid;
                    CODEMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODEMAN.ObjectDefName = "ManipulationProcedure";
                    CODEMAN.DataMember = "PROCEDUREOBJECT.CODE";
                    CODEMAN.TextFont.Name = "Arial Narrow";
                    CODEMAN.Value = @"{#OBJECTID#}";

                    DATEMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DATEMAN.Name = "DATEMAN";
                    DATEMAN.ForeColor = System.Drawing.Color.White;
                    DATEMAN.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEMAN.TextFormat = @"Short Date";
                    DATEMAN.TextFont.Name = "Arial Narrow";
                    DATEMAN.Value = @"{#ACTIONDATE#}";

                    NAMEMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 152, 6, false);
                    NAMEMAN.Name = "NAMEMAN";
                    NAMEMAN.ForeColor = System.Drawing.Color.White;
                    NAMEMAN.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMEMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMEMAN.MultiLine = EvetHayirEnum.ehEvet;
                    NAMEMAN.NoClip = EvetHayirEnum.ehEvet;
                    NAMEMAN.WordBreak = EvetHayirEnum.ehEvet;
                    NAMEMAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAMEMAN.ObjectDefName = "ManipulationProcedure";
                    NAMEMAN.DataMember = "PROCEDUREOBJECT.NAME";
                    NAMEMAN.TextFont.Name = "Arial Narrow";
                    NAMEMAN.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ManipulationProcedure.GetManipulationProceduresBySubEpisode_Class dataset_GetManipulationProceduresBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<ManipulationProcedure.GetManipulationProceduresBySubEpisode_Class>(0);
                    CODEMAN.CalcValue = (dataset_GetManipulationProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetManipulationProceduresBySubEpisode.ObjectID) : "");
                    CODEMAN.PostFieldValueCalculation();
                    DATEMAN.CalcValue = (dataset_GetManipulationProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetManipulationProceduresBySubEpisode.ActionDate) : "");
                    NAMEMAN.CalcValue = (dataset_GetManipulationProceduresBySubEpisode != null ? Globals.ToStringCore(dataset_GetManipulationProceduresBySubEpisode.ObjectID) : "");
                    NAMEMAN.PostFieldValueCalculation();
                    return new TTReportObject[] { CODEMAN,DATEMAN,NAMEMAN};
                }
            }

        }

        public MANIPLATIONGroup MANIPLATION;

        public partial class MANIPLATIONYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public MANIPLATIONYENIGroupBody Body()
            {
                return (MANIPLATIONYENIGroupBody)_body;
            }
            public TTReportField lableNucTest1111 { get {return Body().lableNucTest1111;} }
            public TTReportField MANIPLATIONRTF { get {return Body().MANIPLATIONRTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableNucTest1111;
                public TTReportField MANIPLATIONRTF; 
                public MANIPLATIONYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    lableNucTest1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest1111.Name = "lableNucTest1111";
                    lableNucTest1111.TextFont.Name = "Arial Narrow";
                    lableNucTest1111.TextFont.Bold = true;
                    lableNucTest1111.Value = @"TIBBİ CERRAHİ UYGULAMALAR:";

                    MANIPLATIONRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    MANIPLATIONRTF.Name = "MANIPLATIONRTF";
                    MANIPLATIONRTF.MultiLine = EvetHayirEnum.ehEvet;
                    MANIPLATIONRTF.NoClip = EvetHayirEnum.ehEvet;
                    MANIPLATIONRTF.WordBreak = EvetHayirEnum.ehEvet;
                    MANIPLATIONRTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    MANIPLATIONRTF.TextFont.Name = "Arial Narrow";
                    MANIPLATIONRTF.TextFont.CharSet = 1;
                    MANIPLATIONRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableNucTest1111.CalcValue = lableNucTest1111.Value;
                    MANIPLATIONRTF.CalcValue = MANIPLATIONRTF.Value;
                    return new TTReportObject[] { lableNucTest1111,MANIPLATIONRTF};
                }
                public override void RunPreScript()
                {
#region MANIPLATIONYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            
                        BindingList<TTObjectClasses.ManipulationProcedure> manipulationProcedureList = ManipulationProcedure.GetManipulationProceduresOfSubEpisode(context,episodeAction.SubEpisode.ObjectID.ToString(),episodeAction.Episode.ObjectID.ToString());
            if(manipulationProcedureList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("MANIPLATIONALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (ManipulationProcedure manipulationProcedure in manipulationProcedureList)
                {
                    builder.Append(Convert.ToDateTime(manipulationProcedure.ActionDate).ToShortDateString() + " ");
                    builder.Append(manipulationProcedure.ProcedureObject.Name + " ");
                    builder.Append("(" + manipulationProcedure.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.MANIPLATIONRTF.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString());
            }
#endregion MANIPLATIONYENI BODY_PreScript
                }
            }

        }

        public MANIPLATIONYENIGroup MANIPLATIONYENI;

        public partial class ORTEZPROTEZBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    lableTarih1.Value = @"Tarih";

                    LableOrtezAdı1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 89, 12, false);
                    LableOrtezAdı1.Name = "LableOrtezAdı1";
                    LableOrtezAdı1.TextFont.Name = "Arial Narrow";
                    LableOrtezAdı1.Value = @"Ortez Protez İşlemi";

                    lableOrtezProtezCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 188, 12, false);
                    lableOrtezProtezCode.Name = "lableOrtezProtezCode";
                    lableOrtezProtezCode.TextFont.Name = "Arial Narrow";
                    lableOrtezProtezCode.Value = @"Ortez Protez Kodu";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 188, 13, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableTıbbiMlz11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz11.Name = "lableTıbbiMlz11";
                    lableTıbbiMlz11.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz11.TextFont.Bold = true;
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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

        public partial class ORTEZPROTEZGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public ORTEZPROTEZGroupBody Body()
            {
                return (ORTEZPROTEZGroupBody)_body;
            }
            public TTReportField CODEOP { get {return Body().CODEOP;} }
            public TTReportField DATEOP { get {return Body().DATEOP;} }
            public TTReportField NAMEOP { get {return Body().NAMEOP;} }
            public ORTEZPROTEZGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORTEZPROTEZGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class>("GetOrthesisProsthesisProcedureBySubEpisode", OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ORTEZPROTEZGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ORTEZPROTEZGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField CODEOP;
                public TTReportField DATEOP;
                public TTReportField NAMEOP; 
                public ORTEZPROTEZGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CODEOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 188, 6, false);
                    CODEOP.Name = "CODEOP";
                    CODEOP.ForeColor = System.Drawing.Color.White;
                    CODEOP.DrawStyle = DrawStyleConstants.vbSolid;
                    CODEOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODEOP.ObjectDefName = "OrthesisProsthesisProcedure";
                    CODEOP.DataMember = "PROCEDUREOBJECT.CODE";
                    CODEOP.TextFont.Name = "Arial Narrow";
                    CODEOP.Value = @"{#OBJECTID#}";

                    DATEOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 40, 6, false);
                    DATEOP.Name = "DATEOP";
                    DATEOP.ForeColor = System.Drawing.Color.White;
                    DATEOP.DrawStyle = DrawStyleConstants.vbSolid;
                    DATEOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEOP.TextFormat = @"Short Date";
                    DATEOP.TextFont.Name = "Arial Narrow";
                    DATEOP.Value = @"{#ACTIONDATE#}";

                    NAMEOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 153, 6, false);
                    NAMEOP.Name = "NAMEOP";
                    NAMEOP.ForeColor = System.Drawing.Color.White;
                    NAMEOP.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMEOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMEOP.MultiLine = EvetHayirEnum.ehEvet;
                    NAMEOP.NoClip = EvetHayirEnum.ehEvet;
                    NAMEOP.WordBreak = EvetHayirEnum.ehEvet;
                    NAMEOP.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAMEOP.ObjectDefName = "OrthesisProsthesisProcedure";
                    NAMEOP.DataMember = "PROCEDUREOBJECT.NAME";
                    NAMEOP.TextFont.Name = "Arial Narrow";
                    NAMEOP.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class dataset_GetOrthesisProsthesisProcedureBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class>(0);
                    CODEOP.CalcValue = (dataset_GetOrthesisProsthesisProcedureBySubEpisode != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureBySubEpisode.ObjectID) : "");
                    CODEOP.PostFieldValueCalculation();
                    DATEOP.CalcValue = (dataset_GetOrthesisProsthesisProcedureBySubEpisode != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureBySubEpisode.ActionDate) : "");
                    NAMEOP.CalcValue = (dataset_GetOrthesisProsthesisProcedureBySubEpisode != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureBySubEpisode.ObjectID) : "");
                    NAMEOP.PostFieldValueCalculation();
                    return new TTReportObject[] { CODEOP,DATEOP,NAMEOP};
                }
            }

        }

        public ORTEZPROTEZGroup ORTEZPROTEZ;

        public partial class ORTEZPROTEZYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public ORTEZPROTEZYENIGroupBody Body()
            {
                return (ORTEZPROTEZYENIGroupBody)_body;
            }
            public TTReportField lableTıbbiMlz111 { get {return Body().lableTıbbiMlz111;} }
            public TTReportField ORTEZPROTEZRTF { get {return Body().ORTEZPROTEZRTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableTıbbiMlz111;
                public TTReportField ORTEZPROTEZRTF; 
                public ORTEZPROTEZYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    lableTıbbiMlz111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz111.Name = "lableTıbbiMlz111";
                    lableTıbbiMlz111.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz111.TextFont.Bold = true;
                    lableTıbbiMlz111.Value = @"ORTEZ PROTEZ:";

                    ORTEZPROTEZRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    ORTEZPROTEZRTF.Name = "ORTEZPROTEZRTF";
                    ORTEZPROTEZRTF.MultiLine = EvetHayirEnum.ehEvet;
                    ORTEZPROTEZRTF.NoClip = EvetHayirEnum.ehEvet;
                    ORTEZPROTEZRTF.WordBreak = EvetHayirEnum.ehEvet;
                    ORTEZPROTEZRTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    ORTEZPROTEZRTF.TextFont.Name = "Arial Narrow";
                    ORTEZPROTEZRTF.TextFont.CharSet = 1;
                    ORTEZPROTEZRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTıbbiMlz111.CalcValue = lableTıbbiMlz111.Value;
                    ORTEZPROTEZRTF.CalcValue = ORTEZPROTEZRTF.Value;
                    return new TTReportObject[] { lableTıbbiMlz111,ORTEZPROTEZRTF};
                }
                public override void RunPreScript()
                {
#region ORTEZPROTEZYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            
            BindingList<TTObjectClasses.OrthesisProsthesisProcedure> orthProthList = OrthesisProsthesisProcedure.GetOrthesisProthesisBySubEpisode(context,episodeAction.SubEpisode.ObjectID,episodeAction.Episode.ObjectID.ToString());
            if(orthProthList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("ORTEZPROTEZALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (OrthesisProsthesisProcedure orthProth in orthProthList)
                {
                    builder.Append(Convert.ToDateTime(orthProth.ActionDate).ToShortDateString() + " ");
                    builder.Append(orthProth.ProcedureObject.Name + " ");
                    builder.Append("(" + orthProth.ProcedureObject.MySUTCode + ")");
                    builder.Append(", ");
                }
                this.ORTEZPROTEZRTF.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString());
            }
#endregion ORTEZPROTEZYENI BODY_PreScript
                }
            }

        }

        public ORTEZPROTEZYENIGroup ORTEZPROTEZYENI;

        public partial class ONERILERGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportRTF ONERILER;
                public TTReportField NewField11119111; 
                public ONERILERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ONERILER = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 6, 200, 18, false);
                    ONERILER.Name = "ONERILER";
                    ONERILER.Value = @"";

                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 63, 6, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial Narrow";
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.Underline = true;
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
                    /* TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CreatingEpicrisis creatingEpicrisis = (CreatingEpicrisis)context.GetObject(new Guid(sObjectID),"CreatingEpicrisis");
            if(creatingEpicrisis.Suggestion!=null)
                this.ONERILER.Value = creatingEpicrisis.Suggestion.ToString();
*/
#endregion ONERILER BODY_PreScript
                }
            }

        }

        public ONERILERGroup ONERILER;

        public partial class TIBBIMALZEMEBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportShape NewLine1211 { get {return Footer().NewLine1211;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableTarih;
                public TTReportField LableMalzAdı;
                public TTReportField lableMalzemeKodu;
                public TTReportShape NewLine1111;
                public TTReportField lableTıbbiMlz1;
                public TTReportField NewField111411;
                public TTReportField NewField111211; 
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
                    lableTarih.Value = @"Tarih";

                    LableMalzAdı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 81, 12, false);
                    LableMalzAdı.Name = "LableMalzAdı";
                    LableMalzAdı.TextFont.Name = "Arial Narrow";
                    LableMalzAdı.Value = @"Tıbbi Malzeme Adı";

                    lableMalzemeKodu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 7, 188, 12, false);
                    lableMalzemeKodu.Name = "lableMalzemeKodu";
                    lableMalzemeKodu.TextFont.Name = "Arial Narrow";
                    lableMalzemeKodu.Value = @"Malzeme Kodu";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableTıbbiMlz1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz1.Name = "lableTıbbiMlz1";
                    lableTıbbiMlz1.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz1.TextFont.Bold = true;
                    lableTıbbiMlz1.Value = @"TIBBİ MALZEME:";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 35, 64, 39, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.TextFont.Name = "Arial Narrow";
                    NewField111411.Value = @":";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 62, 39, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Name = "Arial Narrow";
                    NewField111211.Value = @"Telefon";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTarih.CalcValue = lableTarih.Value;
                    LableMalzAdı.CalcValue = LableMalzAdı.Value;
                    lableMalzemeKodu.CalcValue = lableMalzemeKodu.Value;
                    lableTıbbiMlz1.CalcValue = lableTıbbiMlz1.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    return new TTReportObject[] { lableTarih,LableMalzAdı,lableMalzemeKodu,lableTıbbiMlz1,NewField111411,NewField111211};
                }
            }
            public partial class TIBBIMALZEMEALTBASLIKGroupFooter : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportShape NewLine1211; 
                public TIBBIMALZEMEALTBASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 2, 200, 2, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;

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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public TIBBIMALZEMEYENIGroupBody Body()
            {
                return (TIBBIMALZEMEYENIGroupBody)_body;
            }
            public TTReportField lableTıbbiMlz11 { get {return Body().lableTıbbiMlz11;} }
            public TTReportField MALZEMERTF { get {return Body().MALZEMERTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableTıbbiMlz11;
                public TTReportField MALZEMERTF; 
                public TIBBIMALZEMEYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    lableTıbbiMlz11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableTıbbiMlz11.Name = "lableTıbbiMlz11";
                    lableTıbbiMlz11.TextFont.Name = "Arial Narrow";
                    lableTıbbiMlz11.TextFont.Bold = true;
                    lableTıbbiMlz11.Value = @"TIBBİ MALZEME:";

                    MALZEMERTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    MALZEMERTF.Name = "MALZEMERTF";
                    MALZEMERTF.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMERTF.NoClip = EvetHayirEnum.ehEvet;
                    MALZEMERTF.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMERTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALZEMERTF.TextFont.Name = "Arial Narrow";
                    MALZEMERTF.TextFont.CharSet = 1;
                    MALZEMERTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableTıbbiMlz11.CalcValue = lableTıbbiMlz11.Value;
                    MALZEMERTF.CalcValue = MALZEMERTF.Value;
                    return new TTReportObject[] { lableTıbbiMlz11,MALZEMERTF};
                }
                public override void RunPreScript()
                {
#region TIBBIMALZEMEYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
                        
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");            
            BindingList<TTObjectClasses.BaseTreatmentMaterial> materialList = BaseTreatmentMaterial.GetMaterialBySubEpisode(context,episodeAction.SubEpisode.ObjectID,episodeAction.Episode.ObjectID.ToString());
            
            if(materialList.Count <=0)
            {
                this.Visible = EvetHayirEnum.ehHayir;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Footer)).Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehEvet;
                ((TTReportTool.TTReportSection)(((EpicrisisReportForPatient)ParentReport).Groups("TIBBIMALZEMEALTBASLIK").Footer)).Visible = EvetHayirEnum.ehEvet;
                
                StringBuilder builder = new StringBuilder();
                foreach (BaseTreatmentMaterial material in materialList)
                {
                    if(material.PricingDate != null)
                        builder.Append(Convert.ToDateTime(material.PricingDate).ToShortDateString() + " ");
                    else
                        builder.Append(Convert.ToDateTime(material.ActionDate).ToShortDateString() + " ");
                    builder.Append(material.Material.Name + " ");
                    builder.Append("(" + material.Material.Barcode + ")");
                    builder.Append(" Miktar :" + material.Amount.ToString() + " ");
                    builder.Append(", ");
                    
                }
                this.MALZEMERTF.Value = builder.ToString();
            }
#endregion TIBBIMALZEMEYENI BODY_PreScript
                }
            }

        }

        public TIBBIMALZEMEYENIGroup TIBBIMALZEMEYENI;

        public partial class DRUGORDERYENIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public DRUGORDERYENIGroupBody Body()
            {
                return (DRUGORDERYENIGroupBody)_body;
            }
            public TTReportField lableNucTest11111 { get {return Body().lableNucTest11111;} }
            public TTReportField DRUGORDERRTF { get {return Body().DRUGORDERRTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableNucTest11111;
                public TTReportField DRUGORDERRTF; 
                public DRUGORDERYENIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    lableNucTest11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest11111.Name = "lableNucTest11111";
                    lableNucTest11111.TextFont.Name = "Arial Narrow";
                    lableNucTest11111.TextFont.Bold = true;
                    lableNucTest11111.Value = @"İLAÇLAR:";

                    DRUGORDERRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    DRUGORDERRTF.Name = "DRUGORDERRTF";
                    DRUGORDERRTF.MultiLine = EvetHayirEnum.ehEvet;
                    DRUGORDERRTF.NoClip = EvetHayirEnum.ehEvet;
                    DRUGORDERRTF.WordBreak = EvetHayirEnum.ehEvet;
                    DRUGORDERRTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    DRUGORDERRTF.TextFont.Name = "Arial Narrow";
                    DRUGORDERRTF.TextFont.CharSet = 1;
                    DRUGORDERRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lableNucTest11111.CalcValue = lableNucTest11111.Value;
                    DRUGORDERRTF.CalcValue = DRUGORDERRTF.Value;
                    return new TTReportObject[] { lableNucTest11111,DRUGORDERRTF};
                }
                public override void RunPreScript()
                {
#region DRUGORDERYENI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            BindingList<TTObjectClasses.DrugOrder> drugOrderList = DrugOrder.GetDrugOrdersBySubEpisode(context,episodeAction.SubEpisode.ObjectID,episodeAction.Episode.ObjectID.ToString());
            
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
                    builder.Append("(" + drugOrder.Material.Barcode + ")");
                                       
                    DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    double unitAmount = 0;
                    double totalAmount = 0;
                    if (drugType)
                    {
                        unitAmount = Math.Ceiling(drugOrder.DoseAmount.Value);
                         totalAmount = unitAmount * (double)drugOrder.DrugOrderDetails.Count;
                    }
                    else
                    {
                        if (drugDefinition.Volume != null)
                        {
                            unitAmount = Math.Ceiling(drugOrder.DoseAmount.Value);
                             totalAmount = Math.Ceiling((unitAmount / (double)drugDefinition.Volume) * (double)drugOrder.DrugOrderDetails.Count);
                        }
                        else
                        {
                            totalAmount = 1;
                        }
                    }
                    
                    builder.Append(" Miktar:" + totalAmount.ToString() + " ");
                    builder.Append(", ");
                }
                this.DRUGORDERRTF.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString());
            }
#endregion DRUGORDERYENI BODY_PreScript
                }
            }

        }

        public DRUGORDERYENIGroup DRUGORDERYENI;

        public partial class KANTORBASIGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public KANTORBASIGroupBody Body()
            {
                return (KANTORBASIGroupBody)_body;
            }
            public TTReportField lableNucTest111111 { get {return Body().lableNucTest111111;} }
            public TTReportField BLOODBANKRTF { get {return Body().BLOODBANKRTF;} }
            public KANTORBASIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KANTORBASIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KANTORBASIGroupBody(this);
            }

            public partial class KANTORBASIGroupBody : TTReportSection
            {
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableNucTest111111;
                public TTReportField BLOODBANKRTF; 
                public KANTORBASIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    lableNucTest111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    lableNucTest111111.Name = "lableNucTest111111";
                    lableNucTest111111.TextFont.Name = "Arial Narrow";
                    lableNucTest111111.TextFont.Bold = true;
                    lableNucTest111111.Value = @"KAN ÜRÜNLERİ:";

                    BLOODBANKRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    BLOODBANKRTF.Name = "BLOODBANKRTF";
                    BLOODBANKRTF.MultiLine = EvetHayirEnum.ehEvet;
                    BLOODBANKRTF.NoClip = EvetHayirEnum.ehEvet;
                    BLOODBANKRTF.WordBreak = EvetHayirEnum.ehEvet;
                    BLOODBANKRTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    BLOODBANKRTF.TextFont.Name = "Arial Narrow";
                    BLOODBANKRTF.TextFont.CharSet = 1;
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
#region KANTORBASI BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");            
               
            BindingList<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class>  bloodList = BloodBankBloodProducts.GetBloodProductBySubEpisode(episodeAction.SubEpisode.ObjectID,episodeAction.Episode.ObjectID.ToString());
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
            this.BLOODBANKRTF.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString());
            if (found)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion KANTORBASI BODY_PreScript
                }
            }

        }

        public KANTORBASIGroup KANTORBASI;

        public partial class HIZMETLERGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
            }

            new public HIZMETLERGroupBody Body()
            {
                return (HIZMETLERGroupBody)_body;
            }
            public TTReportField labelPMProcedures { get {return Body().labelPMProcedures;} }
            public TTReportField PMPROCEDURERTF { get {return Body().PMPROCEDURERTF;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField labelPMProcedures;
                public TTReportField PMPROCEDURERTF; 
                public HIZMETLERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    labelPMProcedures = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 79, 6, false);
                    labelPMProcedures.Name = "labelPMProcedures";
                    labelPMProcedures.TextFont.Name = "Arial Narrow";
                    labelPMProcedures.TextFont.Bold = true;
                    labelPMProcedures.Value = @"HİZMETLER :";

                    PMPROCEDURERTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 200, 19, false);
                    PMPROCEDURERTF.Name = "PMPROCEDURERTF";
                    PMPROCEDURERTF.MultiLine = EvetHayirEnum.ehEvet;
                    PMPROCEDURERTF.NoClip = EvetHayirEnum.ehEvet;
                    PMPROCEDURERTF.WordBreak = EvetHayirEnum.ehEvet;
                    PMPROCEDURERTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    PMPROCEDURERTF.TextFont.Name = "Arial Narrow";
                    PMPROCEDURERTF.TextFont.CharSet = 1;
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
            string sObjectID = ((EpicrisisReportForPatient)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
BindingList<TTObjectClasses.PMAddingProcedure> procedureList = PMAddingProcedure.GetPMProcedureBySubEpisode(context,episodeAction.SubEpisode.ObjectID,episodeAction.Episode.ObjectID);
            
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
                this.PMPROCEDURERTF.Value = TTReportTool.TTReport.HTMLtoText(builder.ToString());
            }
#endregion HIZMETLER BODY_PreScript
                }
            }

        }

        public HIZMETLERGroup HIZMETLER;

        public partial class REFAKATCIBASLIKGroup : TTReportGroup
        {
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
                }
                
                public TTReportField lableTarih1;
                public TTReportField labelRefakatciAdi;
                public TTReportField lableRefakatciAdresi;
                public TTReportShape NewLine111111;
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
                    lableTarih1.Value = @"Tarih";

                    labelRefakatciAdi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 7, 81, 12, false);
                    labelRefakatciAdi.Name = "labelRefakatciAdi";
                    labelRefakatciAdi.TextFont.Name = "Arial Narrow";
                    labelRefakatciAdi.Value = @"Refakatçi Adı";

                    lableRefakatciAdresi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 7, 200, 12, false);
                    lableRefakatciAdresi.Name = "lableRefakatciAdresi";
                    lableRefakatciAdresi.TextFont.Name = "Arial Narrow";
                    lableRefakatciAdresi.Value = @"Adres";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 13, 200, 13, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableRefakatci = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 41, 6, false);
                    lableRefakatci.Name = "lableRefakatci";
                    lableRefakatci.TextFont.Name = "Arial Narrow";
                    lableRefakatci.TextFont.Bold = true;
                    lableRefakatci.Value = @"REFAKATÇİ:";

                    labelRefakatciYasi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 7, 88, 12, false);
                    labelRefakatciYasi.Name = "labelRefakatciYasi";
                    labelRefakatciYasi.TextFont.Name = "Arial Narrow";
                    labelRefakatciYasi.Value = @"Yaş";

                    labelRefakatciCinsiyet = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 7, 100, 12, false);
                    labelRefakatciCinsiyet.Name = "labelRefakatciCinsiyet";
                    labelRefakatciCinsiyet.TextFont.Name = "Arial Narrow";
                    labelRefakatciCinsiyet.Value = @"Cinsiyet";

                    labelRefakatciKalacagiGunSayisi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 7, 131, 12, false);
                    labelRefakatciKalacagiGunSayisi.Name = "labelRefakatciKalacagiGunSayisi";
                    labelRefakatciKalacagiGunSayisi.TextFont.Name = "Arial Narrow";
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
            public EpicrisisReportForPatient MyParentReport
            {
                get { return (EpicrisisReportForPatient)ParentReport; }
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
                list[0] = new TTReportNqlData<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>("GetCompanionApplicationBySubEpisode", CompanionApplication.GetCompanionApplicationBySubEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.SUBEPISODE.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
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
                public EpicrisisReportForPatient MyParentReport
                {
                    get { return (EpicrisisReportForPatient)ParentReport; }
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
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    COMPANIONNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 81, 6, false);
                    COMPANIONNAME.Name = "COMPANIONNAME";
                    COMPANIONNAME.ForeColor = System.Drawing.Color.White;
                    COMPANIONNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONNAME.TextFont.Name = "Arial Narrow";
                    COMPANIONNAME.Value = @"{#COMPANIONNAME#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 1, 88, 6, false);
                    AGE.Name = "AGE";
                    AGE.ForeColor = System.Drawing.Color.White;
                    AGE.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Arial Narrow";
                    AGE.Value = @"";

                    COMPANIONSEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 100, 6, false);
                    COMPANIONSEX.Name = "COMPANIONSEX";
                    COMPANIONSEX.ForeColor = System.Drawing.Color.White;
                    COMPANIONSEX.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONSEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONSEX.TextFont.Name = "Arial Narrow";
                    COMPANIONSEX.Value = @"{#COMPANIONSEX#}";

                    STAYINGDATECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 131, 6, false);
                    STAYINGDATECOUNT.Name = "STAYINGDATECOUNT";
                    STAYINGDATECOUNT.ForeColor = System.Drawing.Color.White;
                    STAYINGDATECOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    STAYINGDATECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    STAYINGDATECOUNT.TextFont.Name = "Arial Narrow";
                    STAYINGDATECOUNT.Value = @"{#STAYINGDATECOUNT#}";

                    COMPANIONADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 1, 200, 6, false);
                    COMPANIONADDRESS.Name = "COMPANIONADDRESS";
                    COMPANIONADDRESS.ForeColor = System.Drawing.Color.White;
                    COMPANIONADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONADDRESS.TextFont.Name = "Arial Narrow";
                    COMPANIONADDRESS.Value = @"{#COMPANIONADDRESS#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 254, 6, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.Visible = EvetHayirEnum.ehHayir;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"General Date";
                    BIRTHDATE.TextFont.Name = "Arial Narrow";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.Value = @"{#COMPANIONBIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CompanionApplication.GetCompanionApplicationBySubEpisode_Class dataset_GetCompanionApplicationBySubEpisode = ParentGroup.rsGroup.GetCurrentRecord<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>(0);
                    REQUESTDATE.CalcValue = (dataset_GetCompanionApplicationBySubEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode.RequestDate) : "");
                    COMPANIONNAME.CalcValue = (dataset_GetCompanionApplicationBySubEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode.CompanionName) : "");
                    AGE.CalcValue = @"";
                    COMPANIONSEX.CalcValue = (dataset_GetCompanionApplicationBySubEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode.Companionsex) : "");
                    STAYINGDATECOUNT.CalcValue = (dataset_GetCompanionApplicationBySubEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode.StayingDateCount) : "");
                    COMPANIONADDRESS.CalcValue = (dataset_GetCompanionApplicationBySubEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode.CompanionAddress) : "");
                    BIRTHDATE.CalcValue = (dataset_GetCompanionApplicationBySubEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationBySubEpisode.CompanionBirthDate) : "");
                    return new TTReportObject[] { REQUESTDATE,COMPANIONNAME,AGE,COMPANIONSEX,STAYINGDATECOUNT,COMPANIONADDRESS,BIRTHDATE};
                }

                public override void RunScript()
                {
#region REFAKATCIYENI BODY_Script
                    if(this.BIRTHDATE.CalcValue != null && this.BIRTHDATE.CalcValue != "")
            {
                                         int birthYear = Convert.ToDateTime(this.BIRTHDATE.CalcValue).Year;
                   
                int patientAge = DateTime.Now.Year - birthYear;
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

        public EpicrisisReportForPatient()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            TANILARBASLIK = new TANILARBASLIKGroup(NOT,"TANILARBASLIK");
            TANILARALTBASLIK = new TANILARALTBASLIKGroup(TANILARBASLIK,"TANILARALTBASLIK");
            TANILAR = new TANILARGroup(TANILARALTBASLIK,"TANILAR");
            MAIN = new MAINGroup(NOT,"MAIN");
            FIZIKMUAYENE = new FIZIKMUAYENEGroup(NOT,"FIZIKMUAYENE");
            TEDAVIKARAR = new TEDAVIKARARGroup(NOT,"TEDAVIKARAR");
            SKRAPOR = new SKRAPORGroup(NOT,"SKRAPOR");
            LABTETKIKBASLIK = new LABTETKIKBASLIKGroup(NOT,"LABTETKIKBASLIK");
            LABTETKIKYENI = new LABTETKIKYENIGroup(LABTETKIKBASLIK,"LABTETKIKYENI");
            RADTETKIKBASLIK = new RADTETKIKBASLIKGroup(NOT,"RADTETKIKBASLIK");
            RADTETKIKALTBASLIK = new RADTETKIKALTBASLIKGroup(RADTETKIKBASLIK,"RADTETKIKALTBASLIK");
            RADTETKIK = new RADTETKIKGroup(RADTETKIKALTBASLIK,"RADTETKIK");
            RADTETKIKYENI = new RADTETKIKYENIGroup(RADTETKIKALTBASLIK,"RADTETKIKYENI");
            PATTETKIKBASLIK = new PATTETKIKBASLIKGroup(NOT,"PATTETKIKBASLIK");
            PATTETKIKALTBASLIK = new PATTETKIKALTBASLIKGroup(PATTETKIKBASLIK,"PATTETKIKALTBASLIK");
            PATOBJECTHeader = new PATOBJECTHeaderGroup(PATTETKIKALTBASLIK,"PATOBJECTHeader");
            PATTETKIK = new PATTETKIKGroup(PATOBJECTHeader,"PATTETKIK");
            PATTETKIKYENI = new PATTETKIKYENIGroup(PATTETKIKALTBASLIK,"PATTETKIKYENI");
            NUKTETKIKBASLIK = new NUKTETKIKBASLIKGroup(NOT,"NUKTETKIKBASLIK");
            NUKTETKIKALTBASLIK = new NUKTETKIKALTBASLIKGroup(NUKTETKIKBASLIK,"NUKTETKIKALTBASLIK");
            NUKTETKIK = new NUKTETKIKGroup(NUKTETKIKALTBASLIK,"NUKTETKIK");
            NUKTETKIKYENI = new NUKTETKIKYENIGroup(NUKTETKIKALTBASLIK,"NUKTETKIKYENI");
            GENETIKTETKIKBASLIK = new GENETIKTETKIKBASLIKGroup(NOT,"GENETIKTETKIKBASLIK");
            GENETIKTETKIKALTBASLIK = new GENETIKTETKIKALTBASLIKGroup(GENETIKTETKIKBASLIK,"GENETIKTETKIKALTBASLIK");
            GENETIKTETKIK = new GENETIKTETKIKGroup(GENETIKTETKIKALTBASLIK,"GENETIKTETKIK");
            GENETIKTETKIKYENI = new GENETIKTETKIKYENIGroup(GENETIKTETKIKALTBASLIK,"GENETIKTETKIKYENI");
            KONSULTASYONBASLIK = new KONSULTASYONBASLIKGroup(NOT,"KONSULTASYONBASLIK");
            KONSULTASYON = new KONSULTASYONGroup(KONSULTASYONBASLIK,"KONSULTASYON");
            GUNLUKGOZLEMBASLIK = new GUNLUKGOZLEMBASLIKGroup(NOT,"GUNLUKGOZLEMBASLIK");
            GUNLUKGOZLEMALTBASLIK = new GUNLUKGOZLEMALTBASLIKGroup(GUNLUKGOZLEMBASLIK,"GUNLUKGOZLEMALTBASLIK");
            GUNLUKGOZLEM = new GUNLUKGOZLEMGroup(GUNLUKGOZLEMALTBASLIK,"GUNLUKGOZLEM");
            AMELIYATBASLIK = new AMELIYATBASLIKGroup(NOT,"AMELIYATBASLIK");
            AMELIYATVEANESTEZI = new AMELIYATVEANESTEZIGroup(AMELIYATBASLIK,"AMELIYATVEANESTEZI");
            MANIPLATIONBASLIK = new MANIPLATIONBASLIKGroup(NOT,"MANIPLATIONBASLIK");
            PLANLITIBBIISLEMBASLIK = new PLANLITIBBIISLEMBASLIKGroup(MANIPLATIONBASLIK,"PLANLITIBBIISLEMBASLIK");
            PLANLITIBBIISLEM = new PLANLITIBBIISLEMGroup(PLANLITIBBIISLEMBASLIK,"PLANLITIBBIISLEM");
            MANIPLATIONALTBASLIK = new MANIPLATIONALTBASLIKGroup(MANIPLATIONBASLIK,"MANIPLATIONALTBASLIK");
            MANIPLATION = new MANIPLATIONGroup(MANIPLATIONALTBASLIK,"MANIPLATION");
            MANIPLATIONYENI = new MANIPLATIONYENIGroup(MANIPLATIONALTBASLIK,"MANIPLATIONYENI");
            ORTEZPROTEZBASLIK = new ORTEZPROTEZBASLIKGroup(NOT,"ORTEZPROTEZBASLIK");
            ORTEZPROTEZALTBASLIK = new ORTEZPROTEZALTBASLIKGroup(ORTEZPROTEZBASLIK,"ORTEZPROTEZALTBASLIK");
            ORTEZPROTEZ = new ORTEZPROTEZGroup(ORTEZPROTEZALTBASLIK,"ORTEZPROTEZ");
            ORTEZPROTEZYENI = new ORTEZPROTEZYENIGroup(ORTEZPROTEZALTBASLIK,"ORTEZPROTEZYENI");
            ONERILER = new ONERILERGroup(NOT,"ONERILER");
            TIBBIMALZEMEBASLIK = new TIBBIMALZEMEBASLIKGroup(NOT,"TIBBIMALZEMEBASLIK");
            TIBBIMALZEMEALTBASLIK = new TIBBIMALZEMEALTBASLIKGroup(TIBBIMALZEMEBASLIK,"TIBBIMALZEMEALTBASLIK");
            TIBBIMALZEMEYENI = new TIBBIMALZEMEYENIGroup(TIBBIMALZEMEALTBASLIK,"TIBBIMALZEMEYENI");
            DRUGORDERYENI = new DRUGORDERYENIGroup(NOT,"DRUGORDERYENI");
            KANTORBASI = new KANTORBASIGroup(NOT,"KANTORBASI");
            HIZMETLER = new HIZMETLERGroup(NOT,"HIZMETLER");
            REFAKATCIBASLIK = new REFAKATCIBASLIKGroup(NOT,"REFAKATCIBASLIK");
            REFAKATCIYENI = new REFAKATCIYENIGroup(REFAKATCIBASLIK,"REFAKATCIYENI");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("Doctor", "", "Doktor", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("Doctor"))
                _runtimeParameters.Doctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["Doctor"]);
            Name = "EPICRISISREPORTFORPATIENT";
            Caption = "Epikriz Raporu (Hasta)";
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