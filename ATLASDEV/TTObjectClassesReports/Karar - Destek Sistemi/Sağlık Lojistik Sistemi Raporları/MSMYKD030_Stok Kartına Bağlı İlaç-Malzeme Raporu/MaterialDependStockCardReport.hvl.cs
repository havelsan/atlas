
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
    /// Stok Kartına Bağlı İlaç/Malzeme Raporu
    /// </summary>
    public partial class MaterialDependStockCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialDependStockCardReport MyParentReport
            {
                get { return (MaterialDependStockCardReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField NewField1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.TextFont.Size = 15;
                    LOGO.TextFont.Bold = true;
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"STOK KARTINA BAĞLI İLAÇ/MALZEME RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { LOGO,NewField1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu. {@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 100, 5, false);
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

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu. " + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialDependStockCardReport MyParentReport
            {
                get { return (MaterialDependStockCardReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NSN { get {return Header().NSN;} }
            public TTReportField CARDNAME { get {return Header().CARDNAME;} }
            public TTReportField CARDORDERNO { get {return Header().CARDORDERNO;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                list[0] = new TTReportNqlData<Material.GetMaterialDependStockCardReportQuery_Class>("GetMaterialDependStockCard", Material.GetMaterialDependStockCardReportQuery());
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
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                
                public TTReportField NSN;
                public TTReportField CARDNAME;
                public TTReportField CARDORDERNO;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 49, 6, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 11;
                    NSN.TextFont.Bold = true;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NATOSTOCKNO#}";

                    CARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 170, 6, false);
                    CARDNAME.Name = "CARDNAME";
                    CARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CARDNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CARDNAME.TextFont.Name = "Arial";
                    CARDNAME.TextFont.Size = 11;
                    CARDNAME.TextFont.Bold = true;
                    CARDNAME.TextFont.CharSet = 162;
                    CARDNAME.Value = @"{#CARDNAME#}";

                    CARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 14, 6, false);
                    CARDORDERNO.Name = "CARDORDERNO";
                    CARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CARDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CARDORDERNO.TextFont.Name = "Arial";
                    CARDORDERNO.TextFont.Size = 11;
                    CARDORDERNO.TextFont.Bold = true;
                    CARDORDERNO.TextFont.CharSet = 162;
                    CARDORDERNO.Value = @"{#CARDORDERNO#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 170, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialDependStockCardReportQuery_Class dataset_GetMaterialDependStockCard = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialDependStockCardReportQuery_Class>(0);
                    NSN.CalcValue = (dataset_GetMaterialDependStockCard != null ? Globals.ToStringCore(dataset_GetMaterialDependStockCard.NATOStockNO) : "");
                    CARDNAME.CalcValue = (dataset_GetMaterialDependStockCard != null ? Globals.ToStringCore(dataset_GetMaterialDependStockCard.Cardname) : "");
                    CARDORDERNO.CalcValue = (dataset_GetMaterialDependStockCard != null ? Globals.ToStringCore(dataset_GetMaterialDependStockCard.CardOrderNO) : "");
                    return new TTReportObject[] { NSN,CARDNAME,CARDORDERNO};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public MaterialDependStockCardReport MyParentReport
            {
                get { return (MaterialDependStockCardReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Material.GetMaterialDependStockCardReportQuery_Class dataSet_GetMaterialDependStockCard = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialDependStockCardReportQuery_Class>(0);    
                return new object[] {(dataSet_GetMaterialDependStockCard==null ? null : dataSet_GetMaterialDependStockCard.NATOStockNO)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportShape NewLine1; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 14, 6, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Sıra";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 49, 6, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Malzeme Kodu";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 170, 6, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @" Malzeme İsmi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 6, 170, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialDependStockCardReportQuery_Class dataset_GetMaterialDependStockCard = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Material.GetMaterialDependStockCardReportQuery_Class>(0);
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    return new TTReportObject[] { NewField4,NewField5,NewField6};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                
                public TTReportField COUNTTEXT; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 170, 6, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTTEXT.TextFont.Name = "Arial";
                    COUNTTEXT.TextFont.CharSet = 162;
                    COUNTTEXT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialDependStockCardReportQuery_Class dataset_GetMaterialDependStockCard = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Material.GetMaterialDependStockCardReportQuery_Class>(0);
                    COUNTTEXT.CalcValue = @"";
                    return new TTReportObject[] { COUNTTEXT};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    if(repeatCount > 1)
                        {
                            COUNTTEXT.CalcValue = " Bu stok kartına bağlı toplam " + repeatCount.ToString() + " ilaç vardır.";
                            this.Visible = EvetHayirEnum.ehEvet;
                        }
                        else
                            this.Visible = EvetHayirEnum.ehHayir;
                        repeatCount = 0;
#endregion PARTC FOOTER_Script
                }
            }

#region PARTC_Methods
            public static int repeatCount = 0;
#endregion PARTC_Methods
        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialDependStockCardReport MyParentReport
            {
                get { return (MaterialDependStockCardReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField MATERIALCODE { get {return Body().MATERIALCODE;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Material.GetMaterialDependStockCardReportQuery_Class dataSet_GetMaterialDependStockCard = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialDependStockCardReportQuery_Class>(0);    
                return new object[] {(dataSet_GetMaterialDependStockCard==null ? null : dataSet_GetMaterialDependStockCard.NATOStockNO)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public MaterialDependStockCardReport MyParentReport
                {
                    get { return (MaterialDependStockCardReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField MATERIALCODE;
                public TTReportField MATERIAL;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 14, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.Name = "Arial";
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@}";

                    MATERIALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 49, 6, false);
                    MATERIALCODE.Name = "MATERIALCODE";
                    MATERIALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCODE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCODE.TextFont.Name = "Arial";
                    MATERIALCODE.TextFont.CharSet = 162;
                    MATERIALCODE.Value = @"{#PARTB.CODE#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 170, 6, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#PARTB.NAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialDependStockCardReportQuery_Class dataset_GetMaterialDependStockCard = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Material.GetMaterialDependStockCardReportQuery_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALCODE.CalcValue = (dataset_GetMaterialDependStockCard != null ? Globals.ToStringCore(dataset_GetMaterialDependStockCard.Code) : "");
                    MATERIAL.CalcValue = (dataset_GetMaterialDependStockCard != null ? Globals.ToStringCore(dataset_GetMaterialDependStockCard.Name) : "");
                    return new TTReportObject[] { COUNTER,MATERIALCODE,MATERIAL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    PARTCGroup.repeatCount = PARTCGroup.repeatCount + 1;
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

        public MaterialDependStockCardReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "MATERIALDEPENDSTOCKCARDREPORT";
            Caption = "Stok Kartına Bağlı İlaç/Malzeme Raporu";
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