
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
    /// Kılavuz Kart Raporu
    /// </summary>
    public partial class GuideCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string GUIDECARDOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public GuideCardReport MyParentReport
            {
                get { return (GuideCardReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public GuideCardReport MyParentReport
                {
                    get { return (GuideCardReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 4, 170, 16, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"KILAVUZ KART RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { REPORTNAME,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public GuideCardReport MyParentReport
                {
                    get { return (GuideCardReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 25, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 1, 97, 6, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public GuideCardReport MyParentReport
            {
                get { return (GuideCardReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PARAMETERNAME { get {return Header().PARAMETERNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField GUIDECARDNAME { get {return Header().GUIDECARDNAME;} }
            public TTReportField COLUMNNAME1221 { get {return Header().COLUMNNAME1221;} }
            public TTReportField COLUMNNAME1121 { get {return Header().COLUMNNAME1121;} }
            public TTReportField COLUMNNAME121 { get {return Header().COLUMNNAME121;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
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
                public GuideCardReport MyParentReport
                {
                    get { return (GuideCardReport)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField GUIDECARDNAME;
                public TTReportField COLUMNNAME1221;
                public TTReportField COLUMNNAME1121;
                public TTReportField COLUMNNAME121;
                public TTReportShape NewLine111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PARAMETERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 27, 5, false);
                    PARAMETERNAME.Name = "PARAMETERNAME";
                    PARAMETERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME.TextFont.Bold = true;
                    PARAMETERNAME.TextFont.CharSet = 162;
                    PARAMETERNAME.Value = @"Kılavuz Kart Adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 31, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    GUIDECARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 0, 170, 5, false);
                    GUIDECARDNAME.Name = "GUIDECARDNAME";
                    GUIDECARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDECARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GUIDECARDNAME.ObjectDefName = "StockGuideCard";
                    GUIDECARDNAME.DataMember = "NAME";
                    GUIDECARDNAME.TextFont.Bold = true;
                    GUIDECARDNAME.TextFont.CharSet = 162;
                    GUIDECARDNAME.Value = @"{@GUIDECARDOBJECTID@}";

                    COLUMNNAME1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 13, 12, 18, false);
                    COLUMNNAME1221.Name = "COLUMNNAME1221";
                    COLUMNNAME1221.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1221.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME1221.TextFont.Size = 11;
                    COLUMNNAME1221.TextFont.Bold = true;
                    COLUMNNAME1221.TextFont.CharSet = 162;
                    COLUMNNAME1221.Value = @"Sıra Nu.";

                    COLUMNNAME1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 13, 64, 18, false);
                    COLUMNNAME1121.Name = "COLUMNNAME1121";
                    COLUMNNAME1121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1121.TextFont.Size = 11;
                    COLUMNNAME1121.TextFont.Bold = true;
                    COLUMNNAME1121.TextFont.CharSet = 162;
                    COLUMNNAME1121.Value = @"Stok Kart Adı";

                    COLUMNNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 13, 37, 18, false);
                    COLUMNNAME121.Name = "COLUMNNAME121";
                    COLUMNNAME121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME121.TextFont.Size = 11;
                    COLUMNNAME121.TextFont.Bold = true;
                    COLUMNNAME121.TextFont.CharSet = 162;
                    COLUMNNAME121.Value = @"Nato Stok Nu.";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 18, 170, 18, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    GUIDECARDNAME.CalcValue = MyParentReport.RuntimeParameters.GUIDECARDOBJECTID.ToString();
                    GUIDECARDNAME.PostFieldValueCalculation();
                    COLUMNNAME1221.CalcValue = COLUMNNAME1221.Value;
                    COLUMNNAME1121.CalcValue = COLUMNNAME1121.Value;
                    COLUMNNAME121.CalcValue = COLUMNNAME121.Value;
                    return new TTReportObject[] { PARAMETERNAME,NewField1,GUIDECARDNAME,COLUMNNAME1221,COLUMNNAME1121,COLUMNNAME121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public GuideCardReport MyParentReport
                {
                    get { return (GuideCardReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public GuideCardReport MyParentReport
            {
                get { return (GuideCardReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField STOCKCARNAME { get {return Body().STOCKCARNAME;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<StockCard.GetStockCardForGuideCard_Class>("GSGC", StockCard.GetStockCardForGuideCard((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.GUIDECARDOBJECTID)));
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
                public GuideCardReport MyParentReport
                {
                    get { return (GuideCardReport)ParentReport; }
                }
                
                public TTReportField NATOSTOCKNO;
                public TTReportField STOCKCARNAME;
                public TTReportField ORDERNO;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 37, 6, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    STOCKCARNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 170, 6, false);
                    STOCKCARNAME.Name = "STOCKCARNAME";
                    STOCKCARNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARNAME.TextFont.CharSet = 162;
                    STOCKCARNAME.Value = @"{#NAME#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 11, 6, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#CARDORDERNO#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCard.GetStockCardForGuideCard_Class dataset_GSGC = ParentGroup.rsGroup.GetCurrentRecord<StockCard.GetStockCardForGuideCard_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_GSGC != null ? Globals.ToStringCore(dataset_GSGC.NATOStockNO) : "");
                    STOCKCARNAME.CalcValue = (dataset_GSGC != null ? Globals.ToStringCore(dataset_GSGC.Name) : "");
                    ORDERNO.CalcValue = (dataset_GSGC != null ? Globals.ToStringCore(dataset_GSGC.CardOrderNO) : "");
                    return new TTReportObject[] { NATOSTOCKNO,STOCKCARNAME,ORDERNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GuideCardReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("GUIDECARDOBJECTID", "", "Kılavuz Kartı Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("1b6b6a05-dc7e-4475-85c8-1253cb26e20a");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("GUIDECARDOBJECTID"))
                _runtimeParameters.GUIDECARDOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["GUIDECARDOBJECTID"]);
            Name = "GUIDECARDREPORT";
            Caption = "Kılavuz Kart Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
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