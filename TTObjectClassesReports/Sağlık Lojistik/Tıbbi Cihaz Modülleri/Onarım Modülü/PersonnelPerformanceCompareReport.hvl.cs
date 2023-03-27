
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
    /// Personel Performans Karşılaştırma Raporu
    /// </summary>
    public partial class PersonnelPerformanceCompareReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? ATOLYE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? ATOLYEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PersonnelPerformanceCompareReport MyParentReport
            {
                get { return (PersonnelPerformanceCompareReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HOSPITAL11 { get {return Header().HOSPITAL11;} }
            public TTReportField REPORTHEADER { get {return Header().REPORTHEADER;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
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
                public PersonnelPerformanceCompareReport MyParentReport
                {
                    get { return (PersonnelPerformanceCompareReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL11;
                public TTReportField REPORTHEADER;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 2, 202, 19, false);
                    HOSPITAL11.Name = "HOSPITAL11";
                    HOSPITAL11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL11.TextFont.Name = "Arial";
                    HOSPITAL11.TextFont.Size = 12;
                    HOSPITAL11.TextFont.Bold = true;
                    HOSPITAL11.TextFont.CharSet = 162;
                    HOSPITAL11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 20, 202, 40, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTHEADER.NoClip = EvetHayirEnum.ehEvet;
                    REPORTHEADER.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTHEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTHEADER.TextFont.Name = "Arial";
                    REPORTHEADER.TextFont.Size = 12;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.TextFont.CharSet = 162;
                    REPORTHEADER.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 40, 99, 45, false);
                    NewField15.Name = "NewField15";
                    NewField15.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField15.TextFormat = @"Short Date";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"{@STARTDATE@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 40, 108, 45, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"-";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 40, 145, 45, false);
                    NewField17.Name = "NewField17";
                    NewField17.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField17.TextFormat = @"Short Date";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTHEADER.CalcValue = @"";
                    NewField15.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    HOSPITAL11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTHEADER,NewField15,NewField16,NewField17,HOSPITAL11};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    if(((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYE == Guid.Empty)
                ((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYEFLAG = 1;
            else
                ((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYEFLAG = 0;
            
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                REPORTHEADER.CalcValue = "XXXXXX BİYOMEDİKAL MÜHENDİSLİK MERKEZİ"+"\n"+"PERSONEL PERFORMANS KARŞILAŞTIRMA RAPORU";
            else
                REPORTHEADER.CalcValue = "PERSONEL PERFORMANS KARŞILAŞTIRMA RAPORU";
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PersonnelPerformanceCompareReport MyParentReport
                {
                    get { return (PersonnelPerformanceCompareReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public PersonnelPerformanceCompareReport MyParentReport
            {
                get { return (PersonnelPerformanceCompareReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField MATERIAL1121 { get {return Header().MATERIAL1121;} }
            public TTReportField MATERIAL11211 { get {return Header().MATERIAL11211;} }
            public TTReportField MATERIAL11212 { get {return Header().MATERIAL11212;} }
            public TTReportField MATERIAL11213 { get {return Header().MATERIAL11213;} }
            public TTReportField MATERIAL11214 { get {return Header().MATERIAL11214;} }
            public TTReportField PrintDate11111 { get {return Footer().PrintDate11111;} }
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
                public PersonnelPerformanceCompareReport MyParentReport
                {
                    get { return (PersonnelPerformanceCompareReport)ParentReport; }
                }
                
                public TTReportField MATERIAL1121;
                public TTReportField MATERIAL11211;
                public TTReportField MATERIAL11212;
                public TTReportField MATERIAL11213;
                public TTReportField MATERIAL11214; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MATERIAL1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 17, 11, false);
                    MATERIAL1121.Name = "MATERIAL1121";
                    MATERIAL1121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL1121.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL1121.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL1121.TextFont.Bold = true;
                    MATERIAL1121.TextFont.CharSet = 162;
                    MATERIAL1121.Value = @"S.NU.";

                    MATERIAL11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 134, 11, false);
                    MATERIAL11211.Name = "MATERIAL11211";
                    MATERIAL11211.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL11211.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL11211.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL11211.TextFont.Bold = true;
                    MATERIAL11211.TextFont.CharSet = 162;
                    MATERIAL11211.Value = @"GÖREVLENDİRİLDİĞİ İŞ İSTEK SAYISI";

                    MATERIAL11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 93, 11, false);
                    MATERIAL11212.Name = "MATERIAL11212";
                    MATERIAL11212.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL11212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL11212.VertAlign = VerticalAlignmentEnum.vaBottom;
                    MATERIAL11212.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL11212.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL11212.TextFont.Bold = true;
                    MATERIAL11212.TextFont.CharSet = 162;
                    MATERIAL11212.Value = @"TEKNİSYENİN ADI SOYADI";

                    MATERIAL11213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 1, 203, 11, false);
                    MATERIAL11213.Name = "MATERIAL11213";
                    MATERIAL11213.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL11213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL11213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL11213.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL11213.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL11213.TextFont.Bold = true;
                    MATERIAL11213.TextFont.CharSet = 162;
                    MATERIAL11213.Value = @"DEVAM EDEN İŞ İSTEK SAYISI";

                    MATERIAL11214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 1, 171, 11, false);
                    MATERIAL11214.Name = "MATERIAL11214";
                    MATERIAL11214.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL11214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL11214.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL11214.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL11214.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL11214.TextFont.Bold = true;
                    MATERIAL11214.TextFont.CharSet = 162;
                    MATERIAL11214.Value = @"TAMAMLADIĞI İŞ İSTEK SAYISI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIAL1121.CalcValue = MATERIAL1121.Value;
                    MATERIAL11211.CalcValue = MATERIAL11211.Value;
                    MATERIAL11212.CalcValue = MATERIAL11212.Value;
                    MATERIAL11213.CalcValue = MATERIAL11213.Value;
                    MATERIAL11214.CalcValue = MATERIAL11214.Value;
                    return new TTReportObject[] { MATERIAL1121,MATERIAL11211,MATERIAL11212,MATERIAL11213,MATERIAL11214};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PersonnelPerformanceCompareReport MyParentReport
                {
                    get { return (PersonnelPerformanceCompareReport)ParentReport; }
                }
                
                public TTReportField PrintDate11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PrintDate11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 124, 6, false);
                    PrintDate11111.Name = "PrintDate11111";
                    PrintDate11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate11111.TextFont.Size = 9;
                    PrintDate11111.TextFont.CharSet = 162;
                    PrintDate11111.Value = @"Bu Rapor {@printdate@} Tarihinde Alınmıştır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate11111.CalcValue = @"Bu Rapor " + DateTime.Now.ToShortDateString() + @" Tarihinde Alınmıştır.";
                    return new TTReportObject[] { PrintDate11111};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PersonnelPerformanceCompareReport MyParentReport
            {
                get { return (PersonnelPerformanceCompareReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField sn { get {return Body().sn;} }
            public TTReportField PERSONNELNAME { get {return Body().PERSONNELNAME;} }
            public TTReportField TOTALWORK { get {return Body().TOTALWORK;} }
            public TTReportField FINISHEDWORD { get {return Body().FINISHEDWORD;} }
            public TTReportField CONTINUINGWORK { get {return Body().CONTINUINGWORK;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class>("GetPersonnelPerformanceCompareReportQuery2", CMRActionRequest.GetPersonnelPerformanceCompareReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ATOLYE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ATOLYEFLAG)));
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
                public PersonnelPerformanceCompareReport MyParentReport
                {
                    get { return (PersonnelPerformanceCompareReport)ParentReport; }
                }
                
                public TTReportField sn;
                public TTReportField PERSONNELNAME;
                public TTReportField TOTALWORK;
                public TTReportField FINISHEDWORD;
                public TTReportField CONTINUINGWORK;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    sn = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 17, 6, false);
                    sn.Name = "sn";
                    sn.DrawStyle = DrawStyleConstants.vbSolid;
                    sn.FieldType = ReportFieldTypeEnum.ftVariable;
                    sn.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    sn.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    sn.TextFont.Name = "Arial";
                    sn.TextFont.CharSet = 162;
                    sn.Value = @"{@counter@}";

                    PERSONNELNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 93, 6, false);
                    PERSONNELNAME.Name = "PERSONNELNAME";
                    PERSONNELNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PERSONNELNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONNELNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONNELNAME.TextFont.Name = "Arial";
                    PERSONNELNAME.TextFont.CharSet = 162;
                    PERSONNELNAME.Value = @"  {#NAME#}";

                    TOTALWORK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 134, 6, false);
                    TOTALWORK.Name = "TOTALWORK";
                    TOTALWORK.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALWORK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALWORK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALWORK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALWORK.TextFont.Name = "Arial";
                    TOTALWORK.TextFont.CharSet = 162;
                    TOTALWORK.Value = @"{#COUNT#}";

                    FINISHEDWORD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 171, 6, false);
                    FINISHEDWORD.Name = "FINISHEDWORD";
                    FINISHEDWORD.DrawStyle = DrawStyleConstants.vbSolid;
                    FINISHEDWORD.FieldType = ReportFieldTypeEnum.ftVariable;
                    FINISHEDWORD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FINISHEDWORD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FINISHEDWORD.TextFont.Name = "Arial";
                    FINISHEDWORD.TextFont.CharSet = 162;
                    FINISHEDWORD.Value = @"";

                    CONTINUINGWORK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 203, 6, false);
                    CONTINUINGWORK.Name = "CONTINUINGWORK";
                    CONTINUINGWORK.DrawStyle = DrawStyleConstants.vbSolid;
                    CONTINUINGWORK.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTINUINGWORK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONTINUINGWORK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONTINUINGWORK.TextFont.Name = "Arial";
                    CONTINUINGWORK.TextFont.CharSet = 162;
                    CONTINUINGWORK.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 0, 238, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class dataset_GetPersonnelPerformanceCompareReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class>(0);
                    sn.CalcValue = ParentGroup.Counter.ToString();
                    PERSONNELNAME.CalcValue = @"  " + (dataset_GetPersonnelPerformanceCompareReportQuery2 != null ? Globals.ToStringCore(dataset_GetPersonnelPerformanceCompareReportQuery2.Name) : "");
                    TOTALWORK.CalcValue = (dataset_GetPersonnelPerformanceCompareReportQuery2 != null ? Globals.ToStringCore(dataset_GetPersonnelPerformanceCompareReportQuery2.Count) : "");
                    FINISHEDWORD.CalcValue = @"";
                    CONTINUINGWORK.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetPersonnelPerformanceCompareReportQuery2 != null ? Globals.ToStringCore(dataset_GetPersonnelPerformanceCompareReportQuery2.ObjectID) : "");
                    return new TTReportObject[] { sn,PERSONNELNAME,TOTALWORK,FINISHEDWORD,CONTINUINGWORK,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    int totalwork = 0;
            int continuingwork = 0;
            int finisedwork = 0;
            
            totalwork = Convert.ToInt32(TOTALWORK.CalcValue);
            
            if(((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYE == Guid.Empty)
                ((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYEFLAG = 1;
            else
                ((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYEFLAG = 0;
            
            Guid AtolyeGuid;
            if(((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYE == Guid.Empty )
                 AtolyeGuid = Guid.Empty;
            else
                AtolyeGuid = (Guid)((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYE;
            
            TTObjectContext objectContext = new TTObjectContext(true);
            BindingList<CMRActionRequest.GetPersonnelPerformanceCompareRQ2_Class> list = CMRActionRequest.GetPersonnelPerformanceCompareRQ2(objectContext, new Guid(OBJECTID.CalcValue),(DateTime)((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ENDDATE,(DateTime)((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.STARTDATE,AtolyeGuid,(int)((PersonnelPerformanceCompareReport)ParentReport).RuntimeParameters.ATOLYEFLAG);
            if(list.Count != 0)
             {
                continuingwork = Convert.ToInt32(list[0].Count);
             }
            else
             {
                continuingwork = totalwork ;
             }
            
            CONTINUINGWORK.CalcValue = continuingwork.ToString();
            finisedwork= totalwork -  continuingwork;
            FINISHEDWORD.CalcValue =finisedwork.ToString();
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

        public PersonnelPerformanceCompareReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Zamanı ", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zmanı ", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ATOLYE", "00000000-0000-0000-0000-000000000000", "Atölyesi ", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("756dc5eb-8fcd-4788-ac28-fbcbdcbc8c9e");
            reportParameter = Parameters.Add("ATOLYEFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("ATOLYE"))
                _runtimeParameters.ATOLYE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ATOLYE"]);
            if (parameters.ContainsKey("ATOLYEFLAG"))
                _runtimeParameters.ATOLYEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ATOLYEFLAG"]);
            Name = "PERSONNELPERFORMANCECOMPAREREPORT";
            Caption = "Personel Performans Karşılaştırma Raporu";
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