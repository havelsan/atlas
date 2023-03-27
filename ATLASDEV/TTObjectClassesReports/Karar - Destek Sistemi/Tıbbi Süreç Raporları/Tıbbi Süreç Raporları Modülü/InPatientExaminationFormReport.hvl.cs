
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
    /// Doktor Muayene Formu
    /// </summary>
    public partial class InPatientExaminationFormReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
            public TTReportField LOGO { get {return Header().LOGO;} }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                public TTReportField LOGO; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 85;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 73, 36, 77, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Kurum Adı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 73, 38, 77, false);
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

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 27, 206, 31, false);
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

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 33, 128, 37, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.TextFont.Name = "Arial Narrow";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.Value = @"DOKTOR MUAYENE FORMU";

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

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 5, 171, 28, false);
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

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 62, 95, 72, false);
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
                    YATISTARIHI.Value = @"{#YATIS_TARIHI#}";

                    CIKISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 57, 183, 61, false);
                    CIKISTARIHI.Name = "CIKISTARIHI";
                    CIKISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKISTARIHI.Value = @"{#CIKIS_TARIHI#}";

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

                    HASTAKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 73, 95, 77, false);
                    HASTAKURUM.Name = "HASTAKURUM";
                    HASTAKURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKURUM.TextFont.Name = "Arial Narrow";
                    HASTAKURUM.TextFont.CharSet = 1;
                    HASTAKURUM.Value = @"";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 5, 41, 37, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

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
                    CIKISTARIHI.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Cikis_tarihi) : "");
                    CINSIYET.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.Sex) : "");
                    TELEFON.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.MobilePhone) : "");
                    DOKTORU.CalcValue = (dataset_GetEpicrisisPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetEpicrisisPatientInfoByEpisodeAction.ProcedureDoctor) : "");
                    DOKTORU.PostFieldValueCalculation();
                    HASTAKURUM.CalcValue = @"";
                    LOGO.CalcValue = @"";
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { NewField121,NewField141,NewField191,NewField112,NewField122,NewField132,DATE,PNAME,SURNAME,ACTIONDATE,NewField1331,EPISODE,NewField1121,NewField1141,SITENAME,SITECITY,HEADER,NewField1221,NewField1231,NewField11211,NewField11411,NewField1122,NewField12211,NewField111221,NewField1122111,NewField11112211,NewField111221111,NewField13222,NewField13223,NewField13224,NewField13225,NewField13226,NewField13227,FULLNAME,PROTOCOLNO,KIMLIKNO,DOGUMYERITARIHI,ADRES,YATTIGIBOLUM,YATISTARIHI,CIKISTARIHI,CINSIYET,TELEFON,DOKTORU,HASTAKURUM,LOGO,KURUM};
                }
                public override void RunPreScript()
                {
#region NOT HEADER_PreScript
                    //                                                                                                                                                                        
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((InPatientExaminationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((InPatientExaminationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            this.HASTAKURUM.CalcValue = episodeAction.SubEpisode.FirstSubEpisodeProtocol.Payer.Name;
           
            
            
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((InPatientExaminationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                    FIELDONAY.Visible = EvetHayirEnum.ehHayir;
                    FIELDONAY.MultiLine = EvetHayirEnum.ehEvet;
                    FIELDONAY.WordBreak = EvetHayirEnum.ehEvet;
                    FIELDONAY.TextFont.Name = "Arial Narrow";
                    FIELDONAY.Value = @"ONAYLI";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 4, 89, 46, false);
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class dataset_GetEpicrisisPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class>(0);
                    FIELDONAY.CalcValue = FIELDONAY.Value;
                    ISTEKDR.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    return new TTReportObject[] { FIELDONAY,ISTEKDR,ONAY};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);//yeni context oluşturduk                                                         
            string sObjectID = ((InPatientExaminationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            
            
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            
 

                if ( episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor!=null)
                    this.ISTEKDR.CalcValue = episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor.SignatureBlock;
            
            
            this.ONAY.CalcValue = TTObjectClasses.ResHospital.ApprovalSignatureBlock;
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class TANILARBASLIKGroup : TTReportGroup
        {
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnosisByEpisode_Class>("GetDiagnosisByEpisode", DiagnosisGrid.GetDiagnosisByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                    DiagnosisGrid.GetDiagnosisByEpisode_Class dataset_GetDiagnosisByEpisode = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnosisByEpisode_Class>(0);
                    CODE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Code) : "");
                    DIAGNOSEDATE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Diagnosedate) : "");
                    NAME.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Name) : "");
                    return new TTReportObject[] { CODE,DIAGNOSEDATE,NAME};
                }
            }

        }

        public TANILARGroup TANILAR;

        public partial class MAINGroup : TTReportGroup
        {
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
            string sObjectID = ((InPatientExaminationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
            string sObjectID = ((InPatientExaminationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
            if(episodeAction.Episode.PhysicalExamination!=null)
                this.FIZIKMUAYENE.Value = TTReportTool.TTReport.HTMLtoText(episodeAction.Episode.PhysicalExamination.ToString()) + "\r\n";
#endregion FIZIKMUAYENE BODY_PreScript
                }
            }

        }

        public FIZIKMUAYENEGroup FIZIKMUAYENE;

        public partial class REFAKATCIBASLIKGroup : TTReportGroup
        {
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                    
                    lableTarih1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 7, 34, 12, false);
                    lableTarih1.Name = "lableTarih1";
                    lableTarih1.TextFont.Name = "Arial Narrow";
                    lableTarih1.Value = @"Tarih";

                    labelRefakatciAdi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 7, 75, 12, false);
                    labelRefakatciAdi.Name = "labelRefakatciAdi";
                    labelRefakatciAdi.TextFont.Name = "Arial Narrow";
                    labelRefakatciAdi.Value = @"Refakatçi Adı";

                    lableRefakatciAdresi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 7, 194, 12, false);
                    lableRefakatciAdresi.Name = "lableRefakatciAdresi";
                    lableRefakatciAdresi.TextFont.Name = "Arial Narrow";
                    lableRefakatciAdresi.Value = @"Adres";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 13, 194, 13, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    lableRefakatci = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 42, 6, false);
                    lableRefakatci.Name = "lableRefakatci";
                    lableRefakatci.TextFont.Name = "Arial Narrow";
                    lableRefakatci.TextFont.Bold = true;
                    lableRefakatci.Value = @"REFAKATÇİ:";

                    labelRefakatciYasi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 7, 82, 12, false);
                    labelRefakatciYasi.Name = "labelRefakatciYasi";
                    labelRefakatciYasi.TextFont.Name = "Arial Narrow";
                    labelRefakatciYasi.Value = @"Yaş";

                    labelRefakatciCinsiyet = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 7, 94, 12, false);
                    labelRefakatciCinsiyet.Name = "labelRefakatciCinsiyet";
                    labelRefakatciCinsiyet.TextFont.Name = "Arial Narrow";
                    labelRefakatciCinsiyet.Value = @"Cinsiyet";

                    labelRefakatciKalacagiGunSayisi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 7, 126, 12, false);
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
            public InPatientExaminationFormReport MyParentReport
            {
                get { return (InPatientExaminationFormReport)ParentReport; }
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
                list[0] = new TTReportNqlData<CompanionApplication.GetCompanionApplicationByEpisode_Class>("GetCompanionApplicationByEpisode", CompanionApplication.GetCompanionApplicationByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.NOT.EPISODE.CalcValue)));
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
                public InPatientExaminationFormReport MyParentReport
                {
                    get { return (InPatientExaminationFormReport)ParentReport; }
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
                    
                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 34, 6, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.ForeColor = System.Drawing.Color.White;
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    COMPANIONNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 75, 6, false);
                    COMPANIONNAME.Name = "COMPANIONNAME";
                    COMPANIONNAME.ForeColor = System.Drawing.Color.White;
                    COMPANIONNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONNAME.TextFont.Name = "Arial Narrow";
                    COMPANIONNAME.Value = @"{#COMPANIONNAME#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 1, 82, 6, false);
                    AGE.Name = "AGE";
                    AGE.ForeColor = System.Drawing.Color.White;
                    AGE.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Arial Narrow";
                    AGE.Value = @"";

                    COMPANIONSEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 1, 94, 6, false);
                    COMPANIONSEX.Name = "COMPANIONSEX";
                    COMPANIONSEX.ForeColor = System.Drawing.Color.White;
                    COMPANIONSEX.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONSEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONSEX.TextFont.Name = "Arial Narrow";
                    COMPANIONSEX.Value = @"{#COMPANIONSEX#}";

                    STAYINGDATECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 1, 126, 6, false);
                    STAYINGDATECOUNT.Name = "STAYINGDATECOUNT";
                    STAYINGDATECOUNT.ForeColor = System.Drawing.Color.White;
                    STAYINGDATECOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    STAYINGDATECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    STAYINGDATECOUNT.TextFont.Name = "Arial Narrow";
                    STAYINGDATECOUNT.Value = @"{#STAYINGDATECOUNT#}";

                    COMPANIONADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 194, 6, false);
                    COMPANIONADDRESS.Name = "COMPANIONADDRESS";
                    COMPANIONADDRESS.ForeColor = System.Drawing.Color.White;
                    COMPANIONADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPANIONADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPANIONADDRESS.TextFont.Name = "Arial Narrow";
                    COMPANIONADDRESS.Value = @"{#COMPANIONADDRESS#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 1, 248, 6, false);
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
                    CompanionApplication.GetCompanionApplicationByEpisode_Class dataset_GetCompanionApplicationByEpisode = ParentGroup.rsGroup.GetCurrentRecord<CompanionApplication.GetCompanionApplicationByEpisode_Class>(0);
                    REQUESTDATE.CalcValue = (dataset_GetCompanionApplicationByEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationByEpisode.RequestDate) : "");
                    COMPANIONNAME.CalcValue = (dataset_GetCompanionApplicationByEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationByEpisode.CompanionName) : "");
                    AGE.CalcValue = @"";
                    COMPANIONSEX.CalcValue = (dataset_GetCompanionApplicationByEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationByEpisode.Companionsex) : "");
                    STAYINGDATECOUNT.CalcValue = (dataset_GetCompanionApplicationByEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationByEpisode.StayingDateCount) : "");
                    COMPANIONADDRESS.CalcValue = (dataset_GetCompanionApplicationByEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationByEpisode.CompanionAddress) : "");
                    BIRTHDATE.CalcValue = (dataset_GetCompanionApplicationByEpisode != null ? Globals.ToStringCore(dataset_GetCompanionApplicationByEpisode.CompanionBirthDate) : "");
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

        public InPatientExaminationFormReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            TANILARBASLIK = new TANILARBASLIKGroup(NOT,"TANILARBASLIK");
            TANILARALTBASLIK = new TANILARALTBASLIKGroup(TANILARBASLIK,"TANILARALTBASLIK");
            TANILAR = new TANILARGroup(TANILARALTBASLIK,"TANILAR");
            MAIN = new MAINGroup(NOT,"MAIN");
            FIZIKMUAYENE = new FIZIKMUAYENEGroup(NOT,"FIZIKMUAYENE");
            REFAKATCIBASLIK = new REFAKATCIBASLIKGroup(NOT,"REFAKATCIBASLIK");
            REFAKATCIYENI = new REFAKATCIYENIGroup(REFAKATCIBASLIK,"REFAKATCIYENI");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INPATIENTEXAMINATIONFORMREPORT";
            Caption = "Doktor Muayene Formu";
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