
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
    /// Stok Kartları Min. Max. Raporu
    /// </summary>
    public partial class MinMaxForStockCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MinMaxForStockCardReport MyParentReport
            {
                get { return (MinMaxForStockCardReport)ParentReport; }
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
                public MinMaxForStockCardReport MyParentReport
                {
                    get { return (MinMaxForStockCardReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 4, 257, 16, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"MİNİMUM - MAKSİMUM RAPORU";

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
                public MinMaxForStockCardReport MyParentReport
                {
                    get { return (MinMaxForStockCardReport)ParentReport; }
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

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 1, 141, 6, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 1, 257, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 257, 1, false);
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
            public MinMaxForStockCardReport MyParentReport
            {
                get { return (MinMaxForStockCardReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField STOCKCARDNAME12 { get {return Header().STOCKCARDNAME12;} }
            public TTReportField STOCKCARDNAME3 { get {return Header().STOCKCARDNAME3;} }
            public TTReportField STOCKCARDNAME2 { get {return Header().STOCKCARDNAME2;} }
            public TTReportField INHELDCONSTANT { get {return Header().INHELDCONSTANT;} }
            public TTReportField STOCKCARDNAMECONSTANT { get {return Header().STOCKCARDNAMECONSTANT;} }
            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportField NSNCONSTANT { get {return Header().NSNCONSTANT;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
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
                public MinMaxForStockCardReport MyParentReport
                {
                    get { return (MinMaxForStockCardReport)ParentReport; }
                }
                
                public TTReportField STOCKCARDNAME12;
                public TTReportField STOCKCARDNAME3;
                public TTReportField STOCKCARDNAME2;
                public TTReportField INHELDCONSTANT;
                public TTReportField STOCKCARDNAMECONSTANT;
                public TTReportField COLUMNNAME11;
                public TTReportField NSNCONSTANT;
                public TTReportShape NewLine11;
                public TTReportField COLUMNNAME111;
                public TTReportField NewField1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STOCKCARDNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 10, 235, 15, false);
                    STOCKCARDNAME12.Name = "STOCKCARDNAME12";
                    STOCKCARDNAME12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STOCKCARDNAME12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOCKCARDNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME12.TextFont.Size = 11;
                    STOCKCARDNAME12.TextFont.Bold = true;
                    STOCKCARDNAME12.TextFont.CharSet = 162;
                    STOCKCARDNAME12.Value = @"Kritik ";

                    STOCKCARDNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 10, 256, 15, false);
                    STOCKCARDNAME3.Name = "STOCKCARDNAME3";
                    STOCKCARDNAME3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STOCKCARDNAME3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOCKCARDNAME3.TextFont.Size = 11;
                    STOCKCARDNAME3.TextFont.Bold = true;
                    STOCKCARDNAME3.TextFont.CharSet = 162;
                    STOCKCARDNAME3.Value = @"Maksimum";

                    STOCKCARDNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 10, 213, 15, false);
                    STOCKCARDNAME2.Name = "STOCKCARDNAME2";
                    STOCKCARDNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STOCKCARDNAME2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOCKCARDNAME2.TextFont.Size = 11;
                    STOCKCARDNAME2.TextFont.Bold = true;
                    STOCKCARDNAME2.TextFont.CharSet = 162;
                    STOCKCARDNAME2.Value = @"Minimum";

                    INHELDCONSTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 10, 191, 15, false);
                    INHELDCONSTANT.Name = "INHELDCONSTANT";
                    INHELDCONSTANT.CaseFormat = CaseFormatEnum.fcTitleCase;
                    INHELDCONSTANT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INHELDCONSTANT.TextFont.Size = 11;
                    INHELDCONSTANT.TextFont.Bold = true;
                    INHELDCONSTANT.TextFont.CharSet = 162;
                    INHELDCONSTANT.Value = @"Mevcut";

                    STOCKCARDNAMECONSTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 169, 15, false);
                    STOCKCARDNAMECONSTANT.Name = "STOCKCARDNAMECONSTANT";
                    STOCKCARDNAMECONSTANT.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STOCKCARDNAMECONSTANT.TextFont.Size = 11;
                    STOCKCARDNAMECONSTANT.TextFont.Bold = true;
                    STOCKCARDNAMECONSTANT.TextFont.CharSet = 162;
                    STOCKCARDNAMECONSTANT.Value = @"Malzeme / İlaç";

                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 9, 15, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME11.TextFont.Size = 11;
                    COLUMNNAME11.TextFont.Bold = true;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"Sıra";

                    NSNCONSTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 11, 327, 16, false);
                    NSNCONSTANT.Name = "NSNCONSTANT";
                    NSNCONSTANT.Visible = EvetHayirEnum.ehHayir;
                    NSNCONSTANT.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NSNCONSTANT.TextFont.Size = 11;
                    NSNCONSTANT.TextFont.Bold = true;
                    NSNCONSTANT.TextFont.CharSet = 162;
                    NSNCONSTANT.Value = @"Nato Stok Nu.";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 15, 257, 15, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 18, 7, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME111.TextFont.Size = 11;
                    COLUMNNAME111.TextFont.Bold = true;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"DEPO :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 2, 257, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.ObjectDefName = "MainStoreDefinition";
                    NewField1.DataMember = "NAME";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@STOREID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STOCKCARDNAME12.CalcValue = STOCKCARDNAME12.Value;
                    STOCKCARDNAME3.CalcValue = STOCKCARDNAME3.Value;
                    STOCKCARDNAME2.CalcValue = STOCKCARDNAME2.Value;
                    INHELDCONSTANT.CalcValue = INHELDCONSTANT.Value;
                    STOCKCARDNAMECONSTANT.CalcValue = STOCKCARDNAMECONSTANT.Value;
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    NSNCONSTANT.CalcValue = NSNCONSTANT.Value;
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    NewField1.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    NewField1.PostFieldValueCalculation();
                    return new TTReportObject[] { STOCKCARDNAME12,STOCKCARDNAME3,STOCKCARDNAME2,INHELDCONSTANT,STOCKCARDNAMECONSTANT,COLUMNNAME11,NSNCONSTANT,COLUMNNAME111,NewField1};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MinMaxForStockCardReport MyParentReport
                {
                    get { return (MinMaxForStockCardReport)ParentReport; }
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
            public MinMaxForStockCardReport MyParentReport
            {
                get { return (MinMaxForStockCardReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField C { get {return Body().C;} }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField INHELD { get {return Body().INHELD;} }
            public TTReportField MINLEVEL { get {return Body().MINLEVEL;} }
            public TTReportField MAXLEVEL { get {return Body().MAXLEVEL;} }
            public TTReportField SAFETYLEVEL { get {return Body().SAFETYLEVEL;} }
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
                list[0] = new TTReportNqlData<Stock.MinMaxForStockCardQuery_Class>("MinMaxForStockCardQuery", Stock.MinMaxForStockCardQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
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
                public MinMaxForStockCardReport MyParentReport
                {
                    get { return (MinMaxForStockCardReport)ParentReport; }
                }
                
                public TTReportField NSN;
                public TTReportField C;
                public TTReportField STOCKCARDNAME;
                public TTReportField INHELD;
                public TTReportField MINLEVEL;
                public TTReportField MAXLEVEL;
                public TTReportField SAFETYLEVEL;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 1, 324, 6, false);
                    NSN.Name = "NSN";
                    NSN.Visible = EvetHayirEnum.ehHayir;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#STOCKCARDNSN#}";

                    C = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 9, 6, false);
                    C.Name = "C";
                    C.FieldType = ReportFieldTypeEnum.ftVariable;
                    C.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    C.TextFont.CharSet = 162;
                    C.Value = @"{@groupcounter@}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 169, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    INHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 1, 191, 6, false);
                    INHELD.Name = "INHELD";
                    INHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    INHELD.TextFormat = @"#,##0.00";
                    INHELD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INHELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INHELD.TextFont.CharSet = 162;
                    INHELD.Value = @"{#INHELD#}";

                    MINLEVEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 1, 213, 6, false);
                    MINLEVEL.Name = "MINLEVEL";
                    MINLEVEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MINLEVEL.TextFormat = @"#,##0.00";
                    MINLEVEL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MINLEVEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MINLEVEL.TextFont.CharSet = 162;
                    MINLEVEL.Value = @"{#MINLEVEL#}";

                    MAXLEVEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 1, 256, 6, false);
                    MAXLEVEL.Name = "MAXLEVEL";
                    MAXLEVEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAXLEVEL.TextFormat = @"#,##0.00";
                    MAXLEVEL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MAXLEVEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAXLEVEL.TextFont.CharSet = 162;
                    MAXLEVEL.Value = @"{#MAXLEVEL#}";

                    SAFETYLEVEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 235, 6, false);
                    SAFETYLEVEL.Name = "SAFETYLEVEL";
                    SAFETYLEVEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAFETYLEVEL.TextFormat = @"#,##0.00";
                    SAFETYLEVEL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SAFETYLEVEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAFETYLEVEL.TextFont.CharSet = 162;
                    SAFETYLEVEL.Value = @"{#SAFETYLEVEL#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.MinMaxForStockCardQuery_Class dataset_MinMaxForStockCardQuery = ParentGroup.rsGroup.GetCurrentRecord<Stock.MinMaxForStockCardQuery_Class>(0);
                    NSN.CalcValue = (dataset_MinMaxForStockCardQuery != null ? Globals.ToStringCore(dataset_MinMaxForStockCardQuery.Stockcardnsn) : "");
                    C.CalcValue = ParentGroup.GroupCounter.ToString();
                    STOCKCARDNAME.CalcValue = (dataset_MinMaxForStockCardQuery != null ? Globals.ToStringCore(dataset_MinMaxForStockCardQuery.Stockcardname) : "");
                    INHELD.CalcValue = (dataset_MinMaxForStockCardQuery != null ? Globals.ToStringCore(dataset_MinMaxForStockCardQuery.Inheld) : "");
                    MINLEVEL.CalcValue = (dataset_MinMaxForStockCardQuery != null ? Globals.ToStringCore(dataset_MinMaxForStockCardQuery.Minlevel) : "");
                    MAXLEVEL.CalcValue = (dataset_MinMaxForStockCardQuery != null ? Globals.ToStringCore(dataset_MinMaxForStockCardQuery.Maxlevel) : "");
                    SAFETYLEVEL.CalcValue = (dataset_MinMaxForStockCardQuery != null ? Globals.ToStringCore(dataset_MinMaxForStockCardQuery.Safetylevel) : "");
                    return new TTReportObject[] { NSN,C,STOCKCARDNAME,INHELD,MINLEVEL,MAXLEVEL,SAFETYLEVEL};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MinMaxForStockCardReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "", "Depo", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            Name = "MINMAXFORSTOCKCARDREPORT";
            Caption = "Stok Kartları Min. Max. Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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