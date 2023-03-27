
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
    /// Performans Raporu
    /// </summary>
    public partial class PerformanceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField ReportName1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 5, 170, 25, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Size = 15;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"PERFORMANS RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName1.CalcValue = ReportName1.Value;
                    return new TTReportObject[] { ReportName1};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1;
                public TTReportField PrintDate1;
                public TTReportShape NewLine111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 102, 5, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 30, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 170, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber1.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : "";
                    return new TTReportObject[] { PageNumber1,PrintDate1,CurrentUser1};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
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
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField1111111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 170, 7, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"XXXXXX Performans";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111111.CalcValue = NewField1111111.Value;
                    return new TTReportObject[] { NewField1111111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField1113161 { get {return Footer().NewField1113161;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportShape NewLine1; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 70, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İşlem";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İşlem Sayısı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 6, 170, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    return new TTReportObject[] { NewField1111,NewField11111};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField1113161;
                public TTReportShape NewLine121; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField1113161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 1, 145, 6, false);
                    NewField1113161.Name = "NewField1113161";
                    NewField1113161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1113161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113161.TextFont.Bold = true;
                    NewField1113161.TextFont.CharSet = 162;
                    NewField1113161.Value = @"Toplam :";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField1113161.CalcValue = NewField1113161.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField1113161};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
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
                list[0] = new TTReportNqlData<EpisodeAction.GetEpisodeActionsCount_Class>("GetEpisodeActionsCount2", EpisodeAction.GetEpisodeActionsCount((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 2, 207, 7, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#SAYI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 145, 5, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpisodeActionsCount_Class dataset_GetEpisodeActionsCount2 = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodeActionsCount_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GetEpisodeActionsCount2 != null ? Globals.ToStringCore(dataset_GetEpisodeActionsCount2.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GetEpisodeActionsCount2 != null ? Globals.ToStringCore(dataset_GetEpisodeActionsCount2.Sayi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
                    {
                        TTObjectDef objectDef;
                        TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                        if (objectDef != null)
                            OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
                    }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTB2Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTB2GroupHeader Header()
            {
                return (PARTB2GroupHeader)_header;
            }

            new public PARTB2GroupFooter Footer()
            {
                return (PARTB2GroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public PARTB2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTB2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTB2GroupHeader(this);
                _footer = new PARTB2GroupFooter(this);

            }

            public partial class PARTB2GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField111111; 
                public PARTB2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 170, 8, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Lojistik Performans";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField111111};
                }
            }
            public partial class PARTB2GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                 
                public PARTB2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTB2Group PARTB2;

        public partial class PARTA2Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTA2GroupHeader Header()
            {
                return (PARTA2GroupHeader)_header;
            }

            new public PARTA2GroupFooter Footer()
            {
                return (PARTA2GroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField11613111 { get {return Footer().NewField11613111;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public PARTA2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTA2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTA2GroupHeader(this);
                _footer = new PARTA2GroupFooter(this);

            }

            public partial class PARTA2GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportShape NewLine11; 
                public PARTA2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 70, 6, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İşlem";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"İşlem Sayısı";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 6, 170, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField11111,NewField111111};
                }
            }
            public partial class PARTA2GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField11613111;
                public TTReportShape NewLine1121; 
                public PARTA2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField11613111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    NewField11613111.Name = "NewField11613111";
                    NewField11613111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11613111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11613111.TextFont.Bold = true;
                    NewField11613111.TextFont.CharSet = 162;
                    NewField11613111.Value = @"Toplam :";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField11613111.CalcValue = NewField11613111.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField11613111};
                }
            }

        }

        public PARTA2Group PARTA2;

        public partial class MAIN2Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StockAction.GetStockActionsCount_Class>("GetStockActionsCount2", StockAction.GetStockActionsCount((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 206, 6, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#SAYI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 145, 5, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.GetStockActionsCount_Class dataset_GetStockActionsCount2 = ParentGroup.rsGroup.GetCurrentRecord<StockAction.GetStockActionsCount_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GetStockActionsCount2 != null ? Globals.ToStringCore(dataset_GetStockActionsCount2.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GetStockActionsCount2 != null ? Globals.ToStringCore(dataset_GetStockActionsCount2.Sayi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    if (string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
                    {
                        TTObjectDef objectDef;
                        TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                        if (objectDef != null)
                            OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
                    }
#endregion MAIN2 BODY_Script
                }
            }

        }

        public MAIN2Group MAIN2;

        public partial class PARTB3Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTB3GroupHeader Header()
            {
                return (PARTB3GroupHeader)_header;
            }

            new public PARTB3GroupFooter Footer()
            {
                return (PARTB3GroupFooter)_footer;
            }

            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public PARTB3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTB3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTB3GroupHeader(this);
                _footer = new PARTB3GroupFooter(this);

            }

            public partial class PARTB3GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField1111111; 
                public PARTB3GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 170, 7, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Hasta Kabul Performans";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111111.CalcValue = NewField1111111.Value;
                    return new TTReportObject[] { NewField1111111};
                }
            }
            public partial class PARTB3GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                 
                public PARTB3GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTB3Group PARTB3;

        public partial class PARTA3Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTA3GroupHeader Header()
            {
                return (PARTA3GroupHeader)_header;
            }

            new public PARTA3GroupFooter Footer()
            {
                return (PARTA3GroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField111131611 { get {return Footer().NewField111131611;} }
            public TTReportShape NewLine11211 { get {return Footer().NewLine11211;} }
            public PARTA3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTA3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTA3GroupHeader(this);
                _footer = new PARTA3GroupFooter(this);

            }

            public partial class PARTA3GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportShape NewLine111; 
                public PARTA3GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 70, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"İşlem";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"İşlem Sayısı";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 6, 170, 6, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    return new TTReportObject[] { NewField111111,NewField1111111};
                }
            }
            public partial class PARTA3GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField111131611;
                public TTReportShape NewLine11211; 
                public PARTA3GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField111131611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    NewField111131611.Name = "NewField111131611";
                    NewField111131611.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111131611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111131611.TextFont.Bold = true;
                    NewField111131611.TextFont.CharSet = 162;
                    NewField111131611.Value = @"Toplam :";

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField111131611.CalcValue = NewField111131611.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField111131611};
                }
            }

        }

        public PARTA3Group PARTA3;

        public partial class MAIN3Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public MAIN3GroupBody Body()
            {
                return (MAIN3GroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
            public MAIN3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PatientAdmission.GetPatientAdmissionsCount_Class>("GetPatientAdmissionsCount2", PatientAdmission.GetPatientAdmissionsCount((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN3GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN3GroupBody : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAIN3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 205, 5, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#SAYI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 145, 5, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientAdmission.GetPatientAdmissionsCount_Class dataset_GetPatientAdmissionsCount2 = ParentGroup.rsGroup.GetCurrentRecord<PatientAdmission.GetPatientAdmissionsCount_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GetPatientAdmissionsCount2 != null ? Globals.ToStringCore(dataset_GetPatientAdmissionsCount2.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GetPatientAdmissionsCount2 != null ? Globals.ToStringCore(dataset_GetPatientAdmissionsCount2.Sayi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN3 BODY_Script
                    if(string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
                    {
                        TTObjectDef objectDef;
                        TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                        if (objectDef != null)
                            OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
                    }
#endregion MAIN3 BODY_Script
                }
            }

        }

        public MAIN3Group MAIN3;

        public partial class PARTB4Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTB4GroupHeader Header()
            {
                return (PARTB4GroupHeader)_header;
            }

            new public PARTB4GroupFooter Footer()
            {
                return (PARTB4GroupFooter)_footer;
            }

            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public PARTB4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTB4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTB4GroupHeader(this);
                _footer = new PARTB4GroupFooter(this);

            }

            public partial class PARTB4GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField11111111; 
                public PARTB4GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 170, 6, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"Merkezi Performans";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111111.CalcValue = NewField11111111.Value;
                    return new TTReportObject[] { NewField11111111};
                }
            }
            public partial class PARTB4GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                 
                public PARTB4GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTB4Group PARTB4;

        public partial class PARTA4Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTA4GroupHeader Header()
            {
                return (PARTA4GroupHeader)_header;
            }

            new public PARTA4GroupFooter Footer()
            {
                return (PARTA4GroupFooter)_footer;
            }

            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField1116131111 { get {return Footer().NewField1116131111;} }
            public TTReportShape NewLine111211 { get {return Footer().NewLine111211;} }
            public PARTA4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTA4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTA4GroupHeader(this);
                _footer = new PARTA4GroupFooter(this);

            }

            public partial class PARTA4GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField1111111;
                public TTReportField NewField11111111;
                public TTReportShape NewLine1111; 
                public PARTA4GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 70, 6, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"İşlem";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"İşlem Sayısı";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 6, 170, 6, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    return new TTReportObject[] { NewField1111111,NewField11111111};
                }
            }
            public partial class PARTA4GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField1116131111;
                public TTReportShape NewLine111211; 
                public PARTA4GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField1116131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    NewField1116131111.Name = "NewField1116131111";
                    NewField1116131111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1116131111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116131111.TextFont.Bold = true;
                    NewField1116131111.TextFont.CharSet = 162;
                    NewField1116131111.Value = @"Toplam :";

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField1116131111.CalcValue = NewField1116131111.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField1116131111};
                }
            }

        }

        public PARTA4Group PARTA4;

        public partial class MAIN4Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public MAIN4GroupBody Body()
            {
                return (MAIN4GroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
            public MAIN4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<BaseCentralAction.GetBaseCentralActionsCount_Class>("GetBaseCentralActionsCount2", BaseCentralAction.GetBaseCentralActionsCount((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN4GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN4GroupBody : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAIN4GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 205, 5, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#SAYI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 145, 5, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseCentralAction.GetBaseCentralActionsCount_Class dataset_GetBaseCentralActionsCount2 = ParentGroup.rsGroup.GetCurrentRecord<BaseCentralAction.GetBaseCentralActionsCount_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GetBaseCentralActionsCount2 != null ? Globals.ToStringCore(dataset_GetBaseCentralActionsCount2.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GetBaseCentralActionsCount2 != null ? Globals.ToStringCore(dataset_GetBaseCentralActionsCount2.Sayi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN4 BODY_Script
                    if(string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
            {
                TTObjectDef objectDef;
                TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                if (objectDef != null)
                    OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
            }
#endregion MAIN4 BODY_Script
                }
            }

        }

        public MAIN4Group MAIN4;

        public partial class PARTB5Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTB5GroupHeader Header()
            {
                return (PARTB5GroupHeader)_header;
            }

            new public PARTB5GroupFooter Footer()
            {
                return (PARTB5GroupFooter)_footer;
            }

            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public PARTB5Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTB5Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTB5GroupHeader(this);
                _footer = new PARTB5GroupFooter(this);

            }

            public partial class PARTB5GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField11111111; 
                public PARTB5GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 170, 6, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"Bakım Onarım Kalibrasyon Performans";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111111.CalcValue = NewField11111111.Value;
                    return new TTReportObject[] { NewField11111111};
                }
            }
            public partial class PARTB5GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                 
                public PARTB5GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTB5Group PARTB5;

        public partial class PARTA5Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public PARTA5GroupHeader Header()
            {
                return (PARTA5GroupHeader)_header;
            }

            new public PARTA5GroupFooter Footer()
            {
                return (PARTA5GroupFooter)_footer;
            }

            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField111111111 { get {return Header().NewField111111111;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportShape NewLine1112111 { get {return Footer().NewLine1112111;} }
            public PARTA5Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTA5Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTA5GroupHeader(this);
                _footer = new PARTA5GroupFooter(this);

            }

            public partial class PARTA5GroupHeader : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField NewField11111111;
                public TTReportField NewField111111111;
                public TTReportShape NewLine11111; 
                public PARTA5GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 70, 6, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"İşlem";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.TextFont.CharSet = 162;
                    NewField111111111.Value = @"İşlem Sayısı";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 6, 170, 6, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    return new TTReportObject[] { NewField11111111,NewField111111111};
                }
            }
            public partial class PARTA5GroupFooter : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField0;
                public TTReportShape NewLine1112111; 
                public PARTA5GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    NewField0.Name = "NewField0";
                    NewField0.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField0.TextFont.Bold = true;
                    NewField0.TextFont.CharSet = 162;
                    NewField0.Value = @"Toplam :";

                    NewLine1112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine1112111.Name = "NewLine1112111";
                    NewLine1112111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField0.CalcValue = NewField0.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField0};
                }
            }

        }

        public PARTA5Group PARTA5;

        public partial class MAIN5Group : TTReportGroup
        {
            public PerformanceReport MyParentReport
            {
                get { return (PerformanceReport)ParentReport; }
            }

            new public MAIN5GroupBody Body()
            {
                return (MAIN5GroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
            public MAIN5Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN5Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CMRAction.GetCMRActionsCount_Class>("GetCMRActionsCount2", CMRAction.GetCMRActionsCount((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN5GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN5GroupBody : TTReportSection
            {
                public PerformanceReport MyParentReport
                {
                    get { return (PerformanceReport)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAIN5GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 205, 6, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#SAYI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 145, 6, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetCMRActionsCount_Class dataset_GetCMRActionsCount2 = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionsCount_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GetCMRActionsCount2 != null ? Globals.ToStringCore(dataset_GetCMRActionsCount2.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GetCMRActionsCount2 != null ? Globals.ToStringCore(dataset_GetCMRActionsCount2.Sayi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN5 BODY_Script
                    if(string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
            {
                TTObjectDef objectDef;
                TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                if (objectDef != null)
                    OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
            }
#endregion MAIN5 BODY_Script
                }
            }

        }

        public MAIN5Group MAIN5;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PerformanceReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            PARTB2 = new PARTB2Group(PARTB,"PARTB2");
            PARTA2 = new PARTA2Group(PARTB2,"PARTA2");
            MAIN2 = new MAIN2Group(PARTA2,"MAIN2");
            PARTB3 = new PARTB3Group(PARTB,"PARTB3");
            PARTA3 = new PARTA3Group(PARTB3,"PARTA3");
            MAIN3 = new MAIN3Group(PARTA3,"MAIN3");
            PARTB4 = new PARTB4Group(PARTB,"PARTB4");
            PARTA4 = new PARTA4Group(PARTB4,"PARTA4");
            MAIN4 = new MAIN4Group(PARTA4,"MAIN4");
            PARTB5 = new PARTB5Group(PARTB,"PARTB5");
            PARTA5 = new PARTA5Group(PARTB5,"PARTA5");
            MAIN5 = new MAIN5Group(PARTA5,"MAIN5");
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
            Name = "PERFORMANCEREPORT";
            Caption = "Performans Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 15;
            UserMarginTop = 15;
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