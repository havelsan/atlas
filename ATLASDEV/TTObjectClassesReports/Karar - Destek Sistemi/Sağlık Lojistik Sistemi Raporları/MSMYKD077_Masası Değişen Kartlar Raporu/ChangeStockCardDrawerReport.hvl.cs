
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
    /// Masası Değişen Kartlar Raporu
    /// </summary>
    public partial class ChangeStockCardDrawerReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ChangeStockCardDrawerReport MyParentReport
            {
                get { return (ChangeStockCardDrawerReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public ChangeStockCardDrawerReport MyParentReport
                {
                    get { return (ChangeStockCardDrawerReport)ParentReport; }
                }
                
                public TTReportField LOGO1;
                public TTReportField ReportName1;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.Name = "Arial";
                    LOGO1.TextFont.Size = 12;
                    LOGO1.TextFont.Bold = true;
                    LOGO1.TextFont.CharSet = 162;
                    LOGO1.Value = @"";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 257, 35, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Size = 12;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"MASASI DEĞİŞEN KARTLAR RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 28, 47, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İŞLEM TARİHİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 40, 62, 47, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"NATO STOK NU.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 40, 147, 47, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"STOK KARTININ İSMİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 40, 202, 47, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"ESKİ MASASI";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 40, 257, 47, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"YENİ MASASI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO1.CalcValue = LOGO1.Value;
                    ReportName1.CalcValue = ReportName1.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { LOGO1,ReportName1,NewField1,NewField11,NewField12,NewField13,NewField131};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ChangeStockCardDrawerReport MyParentReport
                {
                    get { return (ChangeStockCardDrawerReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 142, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

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

        public partial class MAINGroup : TTReportGroup
        {
            public ChangeStockCardDrawerReport MyParentReport
            {
                get { return (ChangeStockCardDrawerReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField STOCKCARD { get {return Body().STOCKCARD;} }
            public TTReportField OLDCARDDRAWER { get {return Body().OLDCARDDRAWER;} }
            public TTReportField NEWCARDDRAWER { get {return Body().NEWCARDDRAWER;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
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
                list[0] = new TTReportNqlData<ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class>("GetChangeStockCardDrawerReportQuery", ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
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
                public ChangeStockCardDrawerReport MyParentReport
                {
                    get { return (ChangeStockCardDrawerReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField NATOSTOCKNO;
                public TTReportField STOCKCARD;
                public TTReportField OLDCARDDRAWER;
                public TTReportField NEWCARDDRAWER;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 28, 5, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTIONDATE.TextFont.Name = "Arial";
                    ACTIONDATE.TextFont.CharSet = 162;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 0, 62, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    STOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 147, 5, false);
                    STOCKCARD.Name = "STOCKCARD";
                    STOCKCARD.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARD.TextFont.Name = "Arial";
                    STOCKCARD.TextFont.CharSet = 162;
                    STOCKCARD.Value = @" {#STOCKCARD#}";

                    OLDCARDDRAWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 0, 202, 5, false);
                    OLDCARDDRAWER.Name = "OLDCARDDRAWER";
                    OLDCARDDRAWER.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDCARDDRAWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDCARDDRAWER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDCARDDRAWER.TextFont.Name = "Arial";
                    OLDCARDDRAWER.TextFont.CharSet = 162;
                    OLDCARDDRAWER.Value = @" {#OLDRESCARDDRAWER#}";

                    NEWCARDDRAWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 257, 5, false);
                    NEWCARDDRAWER.Name = "NEWCARDDRAWER";
                    NEWCARDDRAWER.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWCARDDRAWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWCARDDRAWER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWCARDDRAWER.TextFont.Name = "Arial";
                    NEWCARDDRAWER.TextFont.CharSet = 162;
                    NEWCARDDRAWER.Value = @" {#NEWRESCARDDRAWER#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 257, 0, 257, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class dataset_GetChangeStockCardDrawerReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ChangeStockCardDrawer.GetChangeStockCardDrawerReportQuery_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetChangeStockCardDrawerReportQuery != null ? Globals.ToStringCore(dataset_GetChangeStockCardDrawerReportQuery.ActionDate) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetChangeStockCardDrawerReportQuery != null ? Globals.ToStringCore(dataset_GetChangeStockCardDrawerReportQuery.NATOStockNO) : "");
                    STOCKCARD.CalcValue = @" " + (dataset_GetChangeStockCardDrawerReportQuery != null ? Globals.ToStringCore(dataset_GetChangeStockCardDrawerReportQuery.Stockcard) : "");
                    OLDCARDDRAWER.CalcValue = @" " + (dataset_GetChangeStockCardDrawerReportQuery != null ? Globals.ToStringCore(dataset_GetChangeStockCardDrawerReportQuery.Oldrescarddrawer) : "");
                    NEWCARDDRAWER.CalcValue = @" " + (dataset_GetChangeStockCardDrawerReportQuery != null ? Globals.ToStringCore(dataset_GetChangeStockCardDrawerReportQuery.Newrescarddrawer) : "");
                    return new TTReportObject[] { ACTIONDATE,NATOSTOCKNO,STOCKCARD,OLDCARDDRAWER,NEWCARDDRAWER};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ChangeStockCardDrawerReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            Name = "CHANGESTOCKCARDDRAWERREPORT";
            Caption = "Masası Değişen Kartlar Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
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