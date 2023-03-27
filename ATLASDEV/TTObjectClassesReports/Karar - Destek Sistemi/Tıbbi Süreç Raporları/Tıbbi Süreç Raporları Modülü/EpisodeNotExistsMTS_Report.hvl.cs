
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
    /// Taburcu Olan Hasta Listesi (Taburcu Numarasına Göre)
    /// </summary>
    public partial class EpisodeNotExistsMTS : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public EpisodeNotExistsMTS MyParentReport
            {
                get { return (EpisodeNotExistsMTS)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 50, 8, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 50, 13, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    ((EpisodeNotExistsMTS)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((EpisodeNotExistsMTS)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HeaderGroup : TTReportGroup
        {
            public EpisodeNotExistsMTS MyParentReport
            {
                get { return (EpisodeNotExistsMTS)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField RAPORBASLIK { get {return Header().RAPORBASLIK;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
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
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                
                public TTReportField RAPORBASLIK;
                public TTReportField XXXXXXBASLIK;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField19;
                public TTReportField NewField181;
                public TTReportField RDATE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 32, 207, 43, false);
                    RAPORBASLIK.Name = "RAPORBASLIK";
                    RAPORBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.TextFont.Bold = true;
                    RAPORBASLIK.TextFont.CharSet = 162;
                    RAPORBASLIK.Value = @"{%STARTDATE%} - {%ENDDATE%} TARİHLERİ ARASINDA MUAYENE TEDAVİ SONUÇ YAZILMAMIŞ HASTALAR LİSTESİ";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 207, 31, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 18, 258, 23, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 23, 258, 28, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 45, 187, 50, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Tarih";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 45, 190, 50, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 45, 206, 50, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    RAPORBASLIK.CalcValue = MyParentReport.Header.STARTDATE.FormattedValue + @" - " + MyParentReport.Header.ENDDATE.FormattedValue + @" TARİHLERİ ARASINDA MUAYENE TEDAVİ SONUÇ YAZILMAMIŞ HASTALAR LİSTESİ";
                    NewField19.CalcValue = NewField19.Value;
                    NewField181.CalcValue = NewField181.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { STARTDATE,ENDDATE,RAPORBASLIK,NewField19,NewField181,RDATE,XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class BaslikGroup : TTReportGroup
        {
            public EpisodeNotExistsMTS MyParentReport
            {
                get { return (EpisodeNotExistsMTS)ParentReport; }
            }

            new public BaslikGroupHeader Header()
            {
                return (BaslikGroupHeader)_header;
            }

            new public BaslikGroupFooter Footer()
            {
                return (BaslikGroupFooter)_footer;
            }

            public TTReportField LBLHASTAADISOYADI { get {return Header().LBLHASTAADISOYADI;} }
            public TTReportField LBLHASTATCNO { get {return Header().LBLHASTATCNO;} }
            public TTReportField LBLHASTAGRUBU { get {return Header().LBLHASTAGRUBU;} }
            public TTReportField LBLTABURCUTARIHI { get {return Header().LBLTABURCUTARIHI;} }
            public TTReportField LBLSIRANO { get {return Header().LBLSIRANO;} }
            public TTReportField LBLTABURCUNO { get {return Header().LBLTABURCUNO;} }
            public TTReportField LBLHASTAADISOYADI1 { get {return Header().LBLHASTAADISOYADI1;} }
            public BaslikGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BaslikGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new BaslikGroupHeader(this);
                _footer = new BaslikGroupFooter(this);

            }

            public partial class BaslikGroupHeader : TTReportSection
            {
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                
                public TTReportField LBLHASTAADISOYADI;
                public TTReportField LBLHASTATCNO;
                public TTReportField LBLHASTAGRUBU;
                public TTReportField LBLTABURCUTARIHI;
                public TTReportField LBLSIRANO;
                public TTReportField LBLTABURCUNO;
                public TTReportField LBLHASTAADISOYADI1; 
                public BaslikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLHASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 1, 105, 6, false);
                    LBLHASTAADISOYADI.Name = "LBLHASTAADISOYADI";
                    LBLHASTAADISOYADI.TextFont.Size = 9;
                    LBLHASTAADISOYADI.TextFont.Bold = true;
                    LBLHASTAADISOYADI.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI.Value = @"Hasta Adı Soyadı";

                    LBLHASTATCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 57, 6, false);
                    LBLHASTATCNO.Name = "LBLHASTATCNO";
                    LBLHASTATCNO.TextFont.Size = 9;
                    LBLHASTATCNO.TextFont.Bold = true;
                    LBLHASTATCNO.TextFont.CharSet = 162;
                    LBLHASTATCNO.Value = @"Kimlik No ";

                    LBLHASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 1, 186, 6, false);
                    LBLHASTAGRUBU.Name = "LBLHASTAGRUBU";
                    LBLHASTAGRUBU.TextFont.Size = 9;
                    LBLHASTAGRUBU.TextFont.Bold = true;
                    LBLHASTAGRUBU.TextFont.CharSet = 162;
                    LBLHASTAGRUBU.Value = @"İşlem No";

                    LBLTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 207, 6, false);
                    LBLTABURCUTARIHI.Name = "LBLTABURCUTARIHI";
                    LBLTABURCUTARIHI.TextFont.Size = 9;
                    LBLTABURCUTARIHI.TextFont.Bold = true;
                    LBLTABURCUTARIHI.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI.Value = @"İşlem Tarihi";

                    LBLSIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 18, 6, false);
                    LBLSIRANO.Name = "LBLSIRANO";
                    LBLSIRANO.TextFont.Size = 9;
                    LBLSIRANO.TextFont.Bold = true;
                    LBLSIRANO.TextFont.CharSet = 162;
                    LBLSIRANO.Value = @"Sıra No";

                    LBLTABURCUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 37, 6, false);
                    LBLTABURCUNO.Name = "LBLTABURCUNO";
                    LBLTABURCUNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBLTABURCUNO.TextFont.Size = 9;
                    LBLTABURCUNO.TextFont.Bold = true;
                    LBLTABURCUNO.TextFont.CharSet = 162;
                    LBLTABURCUNO.Value = @"H.Protokol No";

                    LBLHASTAADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 162, 6, false);
                    LBLHASTAADISOYADI1.Name = "LBLHASTAADISOYADI1";
                    LBLHASTAADISOYADI1.TextFont.Size = 9;
                    LBLHASTAADISOYADI1.TextFont.Bold = true;
                    LBLHASTAADISOYADI1.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1.Value = @"Sorumlu Doktor";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLHASTAADISOYADI.CalcValue = LBLHASTAADISOYADI.Value;
                    LBLHASTATCNO.CalcValue = LBLHASTATCNO.Value;
                    LBLHASTAGRUBU.CalcValue = LBLHASTAGRUBU.Value;
                    LBLTABURCUTARIHI.CalcValue = LBLTABURCUTARIHI.Value;
                    LBLSIRANO.CalcValue = LBLSIRANO.Value;
                    LBLTABURCUNO.CalcValue = LBLTABURCUNO.Value;
                    LBLHASTAADISOYADI1.CalcValue = LBLHASTAADISOYADI1.Value;
                    return new TTReportObject[] { LBLHASTAADISOYADI,LBLHASTATCNO,LBLHASTAGRUBU,LBLTABURCUTARIHI,LBLSIRANO,LBLTABURCUNO,LBLHASTAADISOYADI1};
                }
            }
            public partial class BaslikGroupFooter : TTReportSection
            {
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                 
                public BaslikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public BaslikGroup Baslik;

        public partial class MAINGroup : TTReportGroup
        {
            public EpisodeNotExistsMTS MyParentReport
            {
                get { return (EpisodeNotExistsMTS)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
            public TTReportField ISLEMNO { get {return Body().ISLEMNO;} }
            public TTReportField ISLEMTARIHI { get {return Body().ISLEMTARIHI;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField PROCEDUREDOCTOR { get {return Body().PROCEDUREDOCTOR;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField FNO { get {return Body().FNO;} }
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
                list[0] = new TTReportNqlData<EpisodeAction.GetEpisodesNotExistsMTS_Class>("GetEpisodesNotExistsMTS", EpisodeAction.GetEpisodesNotExistsMTS((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public EpisodeNotExistsMTS MyParentReport
                {
                    get { return (EpisodeNotExistsMTS)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField HASTAADISOYADI;
                public TTReportField HPROTOKOLNO;
                public TTReportField KIMLIKNO;
                public TTReportField ISLEMNO;
                public TTReportField ISLEMTARIHI;
                public TTReportField HASTAADI;
                public TTReportField HASTASOYADI;
                public TTReportField PROCEDUREDOCTOR;
                public TTReportField TCNO;
                public TTReportField FNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 18, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COUNTER.TextFont.Size = 9;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@}";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 1, 105, 5, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{#HASTAADI#} {#HASTASOYADI#}";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 37, 5, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HPROTOKOLNO.TextFont.Size = 9;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#HPROTOCOLNO#}";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 57, 5, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    KIMLIKNO.TextFont.Size = 9;
                    KIMLIKNO.TextFont.CharSet = 162;
                    KIMLIKNO.Value = @"";

                    ISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 1, 186, 5, false);
                    ISLEMNO.Name = "ISLEMNO";
                    ISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    ISLEMNO.TextFont.Size = 9;
                    ISLEMNO.TextFont.CharSet = 162;
                    ISLEMNO.Value = @"{#ID#}";

                    ISLEMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 207, 5, false);
                    ISLEMTARIHI.Name = "ISLEMTARIHI";
                    ISLEMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMTARIHI.TextFormat = @"dd/MM/yyyy";
                    ISLEMTARIHI.VertAlign = VerticalAlignmentEnum.vaBottom;
                    ISLEMTARIHI.TextFont.Size = 9;
                    ISLEMTARIHI.TextFont.CharSet = 162;
                    ISLEMTARIHI.Value = @"{#REQUESTDATE#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 242, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.Value = @"{#HASTAADI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 1, 269, 6, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.Value = @"{#HASTASOYADI#}";

                    PROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 162, 5, false);
                    PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
                    PROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTOR.VertAlign = VerticalAlignmentEnum.vaBottom;
                    PROCEDUREDOCTOR.TextFont.Size = 9;
                    PROCEDUREDOCTOR.TextFont.CharSet = 162;
                    PROCEDUREDOCTOR.Value = @"{#PROCEDUREDOCTORNAME#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 1, 296, 6, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.Value = @"{#TCNO#}";

                    FNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 1, 322, 6, false);
                    FNO.Name = "FNO";
                    FNO.Visible = EvetHayirEnum.ehHayir;
                    FNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FNO.Value = @"{#FNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpisodesNotExistsMTS_Class dataset_GetEpisodesNotExistsMTS = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodesNotExistsMTS_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    HASTAADISOYADI.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Hastaadi) : "") + @" " + (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Hastasoyadi) : "");
                    HPROTOKOLNO.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Hprotocolno) : "");
                    KIMLIKNO.CalcValue = @"";
                    ISLEMNO.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.ID) : "");
                    ISLEMTARIHI.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.RequestDate) : "");
                    HASTAADI.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Hastasoyadi) : "");
                    PROCEDUREDOCTOR.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Proceduredoctorname) : "");
                    TCNO.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Tcno) : "");
                    FNO.CalcValue = (dataset_GetEpisodesNotExistsMTS != null ? Globals.ToStringCore(dataset_GetEpisodesNotExistsMTS.Fno) : "");
                    return new TTReportObject[] { COUNTER,HASTAADISOYADI,HPROTOKOLNO,KIMLIKNO,ISLEMNO,ISLEMTARIHI,HASTAADI,HASTASOYADI,PROCEDUREDOCTOR,TCNO,FNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string tcno = this.TCNO.CalcValue;
            string fno = this.FNO.CalcValue;
            if(String.IsNullOrEmpty(fno) == false)
                this.KIMLIKNO.CalcValue = "(*)" + fno;
            else
                this.KIMLIKNO.CalcValue = tcno;
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

        public EpisodeNotExistsMTS()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            Header = new HeaderGroup(PARTA,"Header");
            Baslik = new BaslikGroup(Header,"Baslik");
            MAIN = new MAINGroup(Baslik,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "EPISODENOTEXISTSMTS";
            Caption = "MTS Yazılmamış Hastalar Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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