
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
    /// Bölümlere İade Edilen Sağlık Kurulu İşlemleri Raporu
    /// </summary>
    public partial class BackToPoliclinicsHealthCommitteeReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public BackToPoliclinicsHealthCommitteeReport MyParentReport
            {
                get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
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
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField CURRENTUSER1 { get {return Footer().CURRENTUSER1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
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
                public BackToPoliclinicsHealthCommitteeReport MyParentReport
                {
                    get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 4, 33, 9, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 4, 57, 9, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
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
                    ((BackToPoliclinicsHealthCommitteeReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((BackToPoliclinicsHealthCommitteeReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public BackToPoliclinicsHealthCommitteeReport MyParentReport
                {
                    get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField CURRENTUSER1;
                public TTReportField PrintDate1;
                public TTReportField PageNumber1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 204, 2, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 4, 118, 9, false);
                    CURRENTUSER1.Name = "CURRENTUSER1";
                    CURRENTUSER1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER1.TextFont.Name = "Arial";
                    CURRENTUSER1.TextFont.Size = 8;
                    CURRENTUSER1.TextFont.CharSet = 162;
                    CURRENTUSER1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 41, 9, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"Short Date";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 4, 204, 9, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CURRENTUSER1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public BackToPoliclinicsHealthCommitteeReport MyParentReport
            {
                get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public BackToPoliclinicsHealthCommitteeReport MyParentReport
                {
                    get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportShape NewLine11;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField131;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 204, 20, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"BÖLÜMLERE İADE EDİLEN SAĞLIK KURULU İŞLEMLERİ RAPORU";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 47, 204, 47, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 23, 46, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Sıra No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 41, 46, 46, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Kimlik No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 41, 97, 46, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Tarih";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 41, 77, 46, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Ad Soyad";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 41, 203, 46, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"İade Sebebi";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 41, 147, 46, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Geri Heyet Yapılan Poliklinik";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 26, 39, 31, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Başlangıç Tarihi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 32, 39, 37, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Bitiş Tarihi";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 26, 42, 31, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 32, 42, 37, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 26, 68, 31, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 32, 68, 37, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { NewField1111,NewField11,NewField12,NewField13,NewField14,NewField15,NewField131,NewField1121,NewField1131,NewField16,NewField161,STARTDATE,ENDDATE};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public BackToPoliclinicsHealthCommitteeReport MyParentReport
                {
                    get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public BackToPoliclinicsHealthCommitteeReport MyParentReport
            {
                get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField IADESEBEBI { get {return Body().IADESEBEBI;} }
            public TTReportField GERIHEYETYAPPOLIKLINIK { get {return Body().GERIHEYETYAPPOLIKLINIK;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetBackHCExaminationByDate_Class>("GetBackHCExaminationByDate", HealthCommitteeExamination.GetBackHCExaminationByDate());
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
                public BackToPoliclinicsHealthCommitteeReport MyParentReport
                {
                    get { return (BackToPoliclinicsHealthCommitteeReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField KIMLIKNO;
                public TTReportField TARIH;
                public TTReportField ADSOYAD;
                public TTReportField IADESEBEBI;
                public TTReportField GERIHEYETYAPPOLIKLINIK; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 23, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 46, 6, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    KIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    KIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    KIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KIMLIKNO.TextFont.CharSet = 162;
                    KIMLIKNO.Value = @"{#KIMLIKNO#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 1, 97, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 1, 77, 6, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    ADSOYAD.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    ADSOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#AD#} {#SOYAD#}";

                    IADESEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 203, 6, false);
                    IADESEBEBI.Name = "IADESEBEBI";
                    IADESEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IADESEBEBI.MultiLine = EvetHayirEnum.ehEvet;
                    IADESEBEBI.NoClip = EvetHayirEnum.ehEvet;
                    IADESEBEBI.WordBreak = EvetHayirEnum.ehEvet;
                    IADESEBEBI.ExpandTabs = EvetHayirEnum.ehEvet;
                    IADESEBEBI.TextFont.CharSet = 162;
                    IADESEBEBI.Value = @"";

                    GERIHEYETYAPPOLIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 147, 6, false);
                    GERIHEYETYAPPOLIKLINIK.Name = "GERIHEYETYAPPOLIKLINIK";
                    GERIHEYETYAPPOLIKLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    GERIHEYETYAPPOLIKLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    GERIHEYETYAPPOLIKLINIK.NoClip = EvetHayirEnum.ehEvet;
                    GERIHEYETYAPPOLIKLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    GERIHEYETYAPPOLIKLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    GERIHEYETYAPPOLIKLINIK.TextFont.CharSet = 162;
                    GERIHEYETYAPPOLIKLINIK.Value = @"{#POLIKLINIK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetBackHCExaminationByDate_Class dataset_GetBackHCExaminationByDate = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetBackHCExaminationByDate_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    KIMLIKNO.CalcValue = (dataset_GetBackHCExaminationByDate != null ? Globals.ToStringCore(dataset_GetBackHCExaminationByDate.Kimlikno) : "");
                    TARIH.CalcValue = @"";
                    ADSOYAD.CalcValue = (dataset_GetBackHCExaminationByDate != null ? Globals.ToStringCore(dataset_GetBackHCExaminationByDate.Ad) : "") + @" " + (dataset_GetBackHCExaminationByDate != null ? Globals.ToStringCore(dataset_GetBackHCExaminationByDate.Soyad) : "");
                    IADESEBEBI.CalcValue = @"";
                    GERIHEYETYAPPOLIKLINIK.CalcValue = (dataset_GetBackHCExaminationByDate != null ? Globals.ToStringCore(dataset_GetBackHCExaminationByDate.Poliklinik) : "");
                    return new TTReportObject[] { SIRANO,KIMLIKNO,TARIH,ADSOYAD,IADESEBEBI,GERIHEYETYAPPOLIKLINIK};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BackToPoliclinicsHealthCommitteeReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
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
            Name = "BACKTOPOLICLINICSHEALTHCOMMITTEEREPORT";
            Caption = "Bölümlere İade Edilen Sağlık Kurulu İşlemleri Raporu";
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