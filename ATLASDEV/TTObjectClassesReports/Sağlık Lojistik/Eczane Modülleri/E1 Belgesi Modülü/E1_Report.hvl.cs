
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
    /// E1 Çizelgesi
    /// </summary>
    public partial class E1_Report : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public E1_Report MyParentReport
            {
                get { return (E1_Report)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField SDATE { get {return Header().SDATE;} }
            public TTReportField EDATE { get {return Header().EDATE;} }
            public TTReportField HOSPITALNAMEHEADER { get {return Header().HOSPITALNAMEHEADER;} }
            public TTReportField HOSPITALCITYHEADER { get {return Header().HOSPITALCITYHEADER;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public E1_Report MyParentReport
                {
                    get { return (E1_Report)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField SDATE;
                public TTReportField EDATE;
                public TTReportField HOSPITALNAMEHEADER;
                public TTReportField HOSPITALCITYHEADER; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 198, 29, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{%SDATE%} - {%EDATE%} Tarihleri Arası E1 Çizelgesi";

                    SDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 21, 29, false);
                    SDATE.Name = "SDATE";
                    SDATE.Visible = EvetHayirEnum.ehHayir;
                    SDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SDATE.TextFormat = @"DD/MM/YYYY HH:MM";
                    SDATE.ObjectDefName = "E1";
                    SDATE.DataMember = "STARTDATE";
                    SDATE.TextFont.Name = "Courier New";
                    SDATE.TextFont.CharSet = 162;
                    SDATE.Value = @"{@TTOBJECTID@}";

                    EDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 25, 34, 29, false);
                    EDATE.Name = "EDATE";
                    EDATE.Visible = EvetHayirEnum.ehHayir;
                    EDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EDATE.TextFormat = @"DD/MM/YYYY HH:MM";
                    EDATE.ObjectDefName = "E1";
                    EDATE.DataMember = "ENDDATE";
                    EDATE.TextFont.Name = "Courier New";
                    EDATE.TextFont.CharSet = 162;
                    EDATE.Value = @"{@TTOBJECTID@}";

                    HOSPITALNAMEHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 7, 198, 15, false);
                    HOSPITALNAMEHEADER.Name = "HOSPITALNAMEHEADER";
                    HOSPITALNAMEHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAMEHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAMEHEADER.TextFont.Size = 11;
                    HOSPITALNAMEHEADER.TextFont.Bold = true;
                    HOSPITALNAMEHEADER.TextFont.CharSet = 162;
                    HOSPITALNAMEHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    HOSPITALCITYHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 14, 198, 24, false);
                    HOSPITALCITYHEADER.Name = "HOSPITALCITYHEADER";
                    HOSPITALCITYHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCITYHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALCITYHEADER.TextFont.Size = 11;
                    HOSPITALCITYHEADER.TextFont.Bold = true;
                    HOSPITALCITYHEADER.TextFont.CharSet = 162;
                    HOSPITALCITYHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SDATE.PostFieldValueCalculation();
                    EDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    EDATE.PostFieldValueCalculation();
                    DESCRIPTION.CalcValue = MyParentReport.PARTB.SDATE.FormattedValue + @" - " + MyParentReport.PARTB.EDATE.FormattedValue + @" Tarihleri Arası E1 Çizelgesi";
                    HOSPITALNAMEHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HOSPITALCITYHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { SDATE,EDATE,DESCRIPTION,HOSPITALNAMEHEADER,HOSPITALCITYHEADER};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public E1_Report MyParentReport
                {
                    get { return (E1_Report)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField PAGENUMBER; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 39;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 112, 27, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Hazırlayan";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 200, 27, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Başeczacı";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 29, 198, 34, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa No : {@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    PAGENUMBER.CalcValue = @"Sayfa No : " + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { NewField13,NewField14,PAGENUMBER};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public E1_Report MyParentReport
            {
                get { return (E1_Report)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
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
                public E1_Report MyParentReport
                {
                    get { return (E1_Report)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 2, 200, 7, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Karantina No";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 2, 125, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ölçü";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 112, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İlaçların İsimleri";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 16, 7, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"S No";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 2, 139, 7, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Miktarı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    return new TTReportObject[] { NewField10,NewField11,NewField12,NewField13,NewField14};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public E1_Report MyParentReport
                {
                    get { return (E1_Report)ParentReport; }
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

        public partial class MAINGroup : TTReportGroup
        {
            public E1_Report MyParentReport
            {
                get { return (E1_Report)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField BIRIM { get {return Body().BIRIM;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField FULLDESC { get {return Body().FULLDESC;} }
            public TTReportField KARANTINANO1 { get {return Body().KARANTINANO1;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public E1_Report MyParentReport
                {
                    get { return (E1_Report)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField BIRIM;
                public TTReportField SIRANO;
                public TTReportField FULLDESC;
                public TTReportField KARANTINANO1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, -1, 139, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"###,##0";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, -1, 125, 4, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.TextFont.Size = 8;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#DISTRIBUTIONTYPE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, -1, 16, 4, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@counter@}";

                    FULLDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, -1, 112, 4, false);
                    FULLDESC.Name = "FULLDESC";
                    FULLDESC.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLDESC.TextFont.CharSet = 162;
                    FULLDESC.Value = @"{#NATOSTOCKNO#} {#MATERIALNAME#} ({#STOCKCARDCLASSCODE#} - {#CARDORDERNO#})";

                    KARANTINANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, -1, 200, 4, false);
                    KARANTINANO1.Name = "KARANTINANO1";
                    KARANTINANO1.DrawStyle = DrawStyleConstants.vbSolid;
                    KARANTINANO1.TextFont.Size = 8;
                    KARANTINANO1.TextFont.CharSet = 162;
                    KARANTINANO1.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    BIRIM.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    FULLDESC.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "") + @" " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "") + @" (" + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockcardclasscode) : "") + @" - " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.CardOrderNO) : "") + @")";
                    KARANTINANO1.CalcValue = KARANTINANO1.Value;
                    return new TTReportObject[] { AMOUNT,BIRIM,SIRANO,FULLDESC,KARANTINANO1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public E1_Report()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "E1 Çizelgesi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "E1_REPORT";
            Caption = "E1 Çizelgesi";
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