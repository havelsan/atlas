
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
    /// Birim Fiyat Olamayan Taşınır Mal Raporu
    /// </summary>
    public partial class UnitPriceIsZeroOfStore : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public UnitPriceIsZeroOfStore MyParentReport
            {
                get { return (UnitPriceIsZeroOfStore)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField DEPO { get {return Header().DEPO;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
            public TTReportField PrintDate11111 { get {return Footer().PrintDate11111;} }
            public TTReportField PageNumber11111 { get {return Footer().PageNumber11111;} }
            public TTReportField CurrentUser11111 { get {return Footer().CurrentUser11111;} }
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
                public UnitPriceIsZeroOfStore MyParentReport
                {
                    get { return (UnitPriceIsZeroOfStore)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField DEPO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 197, 18, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"BİRİM FİYATI OLMAYAN TAŞINIR MAL RAPORU";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 24, 43, 29, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"DEPO ";

                    DEPO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 24, 197, 29, false);
                    DEPO.Name = "DEPO";
                    DEPO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPO.TextFont.CharSet = 162;
                    DEPO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    DEPO.CalcValue = @"";
                    return new TTReportObject[] { NewField11,NewField12,DEPO};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    //            if(((UnitPriceIsZeroOfStore)ParentReport).RuntimeParameters.MATERIAL == Guid.Empty)
//                ((UnitPriceIsZeroOfStore)ParentReport).RuntimeParameters.MATERIALFLAG = 1;
//            else
//                ((UnitPriceIsZeroOfStore)ParentReport).RuntimeParameters.MATERIALFLAG = 0;
//            
            TTObjectContext objectContext = new TTObjectContext(true);
            MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)objectContext.GetObject(new Guid(((UnitPriceIsZeroOfStore)ParentReport).RuntimeParameters.STORE ), "MAINSTOREDEFINITION");
            DEPO.CalcValue =  mainStoreDefinition.Name;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public UnitPriceIsZeroOfStore MyParentReport
                {
                    get { return (UnitPriceIsZeroOfStore)ParentReport; }
                }
                
                public TTReportShape NewLine1111111;
                public TTReportField PrintDate11111;
                public TTReportField PageNumber11111;
                public TTReportField CurrentUser11111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 16, 1, 197, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.DrawWidth = 2;

                    PrintDate11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 41, 7, false);
                    PrintDate11111.Name = "PrintDate11111";
                    PrintDate11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate11111.TextFont.Size = 8;
                    PrintDate11111.TextFont.CharSet = 162;
                    PrintDate11111.Value = @"{@printdate@}";

                    PageNumber11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 2, 197, 7, false);
                    PageNumber11111.Name = "PageNumber11111";
                    PageNumber11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber11111.TextFont.Size = 8;
                    PageNumber11111.TextFont.CharSet = 162;
                    PageNumber11111.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 2, 123, 7, false);
                    CurrentUser11111.Name = "CurrentUser11111";
                    CurrentUser11111.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser11111.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser11111.TextFont.Size = 8;
                    CurrentUser11111.TextFont.CharSet = 162;
                    CurrentUser11111.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate11111.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber11111.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser11111.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate11111,PageNumber11111,CurrentUser11111};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public UnitPriceIsZeroOfStore MyParentReport
            {
                get { return (UnitPriceIsZeroOfStore)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
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
                public UnitPriceIsZeroOfStore MyParentReport
                {
                    get { return (UnitPriceIsZeroOfStore)ParentReport; }
                }
                
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField1181; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 27, 9, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"S.NU.";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 4, 142, 9, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"NSN";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 4, 107, 9, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"MALZEME ADI";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 4, 171, 9, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"İŞLEM TARİHİ";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 4, 197, 9, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"BİRİM FİYATI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    return new TTReportObject[] { NewField4,NewField5,NewField6,NewField7,NewField1181};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public UnitPriceIsZeroOfStore MyParentReport
                {
                    get { return (UnitPriceIsZeroOfStore)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public UnitPriceIsZeroOfStore MyParentReport
            {
                get { return (UnitPriceIsZeroOfStore)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
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
                list[0] = new TTReportNqlData<StockTransaction.UnitePriceOfZero_Class>("UnitePriceOfZero", StockTransaction.UnitePriceOfZero((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public UnitPriceIsZeroOfStore MyParentReport
                {
                    get { return (UnitPriceIsZeroOfStore)ParentReport; }
                }
                
                public TTReportField TRANSACTIONDATE;
                public TTReportField UNITPRICE;
                public TTReportField NewField1;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 171, 5, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"Short Date";
                    TRANSACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TRANSACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDATE.TextFont.Size = 9;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{#TRANSACTIONDATE#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 197, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 9;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 27, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@counter@}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 142, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 9;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 107, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.TextFont.Size = 9;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.UnitePriceOfZero_Class dataset_UnitePriceOfZero = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.UnitePriceOfZero_Class>(0);
                    TRANSACTIONDATE.CalcValue = (dataset_UnitePriceOfZero != null ? Globals.ToStringCore(dataset_UnitePriceOfZero.TransactionDate) : "");
                    UNITPRICE.CalcValue = (dataset_UnitePriceOfZero != null ? Globals.ToStringCore(dataset_UnitePriceOfZero.UnitPrice) : "");
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    NATOSTOCKNO.CalcValue = (dataset_UnitePriceOfZero != null ? Globals.ToStringCore(dataset_UnitePriceOfZero.NATOStockNO) : "");
                    MATERIALNAME.CalcValue = (dataset_UnitePriceOfZero != null ? Globals.ToStringCore(dataset_UnitePriceOfZero.Materialname) : "");
                    return new TTReportObject[] { TRANSACTIONDATE,UNITPRICE,NewField1,NATOSTOCKNO,MATERIALNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public UnitPriceIsZeroOfStore()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "", "Ana Depo", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STORE"]);
            Name = "UNITPRICEISZEROOFSTORE";
            Caption = "Birim Fiyat Olamayan Taşınır Mal Raporu";
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