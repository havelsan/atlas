
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
    public partial class AllGuideCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public AllGuideCardReport MyParentReport
            {
                get { return (AllGuideCardReport)ParentReport; }
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
                public AllGuideCardReport MyParentReport
                {
                    get { return (AllGuideCardReport)ParentReport; }
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
                public AllGuideCardReport MyParentReport
                {
                    get { return (AllGuideCardReport)ParentReport; }
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
            public AllGuideCardReport MyParentReport
            {
                get { return (AllGuideCardReport)ParentReport; }
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
            public TTReportField COLUMNNAME1121 { get {return Header().COLUMNNAME1121;} }
            public TTReportField COLUMNNAME121 { get {return Header().COLUMNNAME121;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField STOCKCARD { get {return Header().STOCKCARD;} }
            public TTReportField COLUMNNAME11211 { get {return Header().COLUMNNAME11211;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StockGuideCard.GetAllStockGuideCard_Class>("GetAllStockGuideCard", StockGuideCard.GetAllStockGuideCard());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public AllGuideCardReport MyParentReport
                {
                    get { return (AllGuideCardReport)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField COLUMNNAME1121;
                public TTReportField COLUMNNAME121;
                public TTReportShape NewLine111;
                public TTReportField NAME;
                public TTReportField OBJECTID;
                public TTReportField STOCKCARD;
                public TTReportField COLUMNNAME11211; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PARAMETERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 27, 7, false);
                    PARAMETERNAME.Name = "PARAMETERNAME";
                    PARAMETERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME.TextFont.Bold = true;
                    PARAMETERNAME.TextFont.CharSet = 162;
                    PARAMETERNAME.Value = @"Kılavuz Kart Adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 31, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    COLUMNNAME1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 15, 52, 20, false);
                    COLUMNNAME1121.Name = "COLUMNNAME1121";
                    COLUMNNAME1121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1121.TextFont.Size = 11;
                    COLUMNNAME1121.TextFont.Bold = true;
                    COLUMNNAME1121.TextFont.CharSet = 162;
                    COLUMNNAME1121.Value = @"Stok Kart Adı";

                    COLUMNNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 15, 24, 20, false);
                    COLUMNNAME121.Name = "COLUMNNAME121";
                    COLUMNNAME121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME121.TextFont.Size = 11;
                    COLUMNNAME121.TextFont.Bold = true;
                    COLUMNNAME121.TextFont.CharSet = 162;
                    COLUMNNAME121.Value = @"Nato Stok Nu.";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 21, 170, 21, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 8, 170, 13, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Bold = true;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 2, 242, 7, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    STOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 8, 26, 13, false);
                    STOCKCARD.Name = "STOCKCARD";
                    STOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARD.ObjectDefName = "StockCard";
                    STOCKCARD.DataMember = "NATOSTOCKNO";
                    STOCKCARD.TextFont.Bold = true;
                    STOCKCARD.TextFont.CharSet = 162;
                    STOCKCARD.Value = @"{#STOCKCARD#}";

                    COLUMNNAME11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 15, 169, 20, false);
                    COLUMNNAME11211.Name = "COLUMNNAME11211";
                    COLUMNNAME11211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME11211.TextFont.Size = 11;
                    COLUMNNAME11211.TextFont.Bold = true;
                    COLUMNNAME11211.TextFont.CharSet = 162;
                    COLUMNNAME11211.Value = @"Miktar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockGuideCard.GetAllStockGuideCard_Class dataset_GetAllStockGuideCard = ParentGroup.rsGroup.GetCurrentRecord<StockGuideCard.GetAllStockGuideCard_Class>(0);
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    COLUMNNAME1121.CalcValue = COLUMNNAME1121.Value;
                    COLUMNNAME121.CalcValue = COLUMNNAME121.Value;
                    NAME.CalcValue = (dataset_GetAllStockGuideCard != null ? Globals.ToStringCore(dataset_GetAllStockGuideCard.Name) : "");
                    OBJECTID.CalcValue = (dataset_GetAllStockGuideCard != null ? Globals.ToStringCore(dataset_GetAllStockGuideCard.ObjectID) : "");
                    STOCKCARD.CalcValue = (dataset_GetAllStockGuideCard != null ? Globals.ToStringCore(dataset_GetAllStockGuideCard.StockCard) : "");
                    STOCKCARD.PostFieldValueCalculation();
                    COLUMNNAME11211.CalcValue = COLUMNNAME11211.Value;
                    return new TTReportObject[] { PARAMETERNAME,NewField1,COLUMNNAME1121,COLUMNNAME121,NAME,OBJECTID,STOCKCARD,COLUMNNAME11211};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public AllGuideCardReport MyParentReport
                {
                    get { return (AllGuideCardReport)ParentReport; }
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
            public AllGuideCardReport MyParentReport
            {
                get { return (AllGuideCardReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField STOCKCARNAME { get {return Body().STOCKCARNAME;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
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
                list[0] = new TTReportNqlData<StockGuideCard.GetStockGuideCardDetails_Class>("GetStockGuideCardDetails", StockGuideCard.GetStockGuideCardDetails((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTB.OBJECTID.CalcValue)));
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
                public AllGuideCardReport MyParentReport
                {
                    get { return (AllGuideCardReport)ParentReport; }
                }
                
                public TTReportField NATOSTOCKNO;
                public TTReportField STOCKCARNAME;
                public TTReportShape NewLine1;
                public TTReportField AMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 24, 6, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    STOCKCARNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 156, 6, false);
                    STOCKCARNAME.Name = "STOCKCARNAME";
                    STOCKCARNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARNAME.TextFont.CharSet = 162;
                    STOCKCARNAME.Value = @"{#STOCKCARDNAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 169, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockGuideCard.GetStockGuideCardDetails_Class dataset_GetStockGuideCardDetails = ParentGroup.rsGroup.GetCurrentRecord<StockGuideCard.GetStockGuideCardDetails_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_GetStockGuideCardDetails != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetails.NATOStockNO) : "");
                    STOCKCARNAME.CalcValue = (dataset_GetStockGuideCardDetails != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetails.Stockcardname) : "");
                    AMOUNT.CalcValue = (dataset_GetStockGuideCardDetails != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetails.Amount) : "");
                    return new TTReportObject[] { NATOSTOCKNO,STOCKCARNAME,AMOUNT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AllGuideCardReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "ALLGUIDECARDREPORT";
            Caption = "Tüm Klavuz Kart Dökümü";
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