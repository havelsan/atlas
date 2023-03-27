
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
    /// Taşınır Mal Birim Fiyat Listesi Raporu
    /// </summary>
    public partial class UnitPriceOfStoreOrNSNReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public string MAINSTORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? MATERIALFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string STOCKLEVELTYPE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public UnitPriceOfStoreOrNSNReport MyParentReport
            {
                get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
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
                public UnitPriceOfStoreOrNSNReport MyParentReport
                {
                    get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
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
                    NewField11.Value = @"TAŞINIR MAL BİRİM FİYAT LİSTESİ RAPORU";

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
                    if(((UnitPriceOfStoreOrNSNReport)ParentReport).RuntimeParameters.MATERIAL == Guid.Empty)
                ((UnitPriceOfStoreOrNSNReport)ParentReport).RuntimeParameters.MATERIALFLAG = 1;
            else
                ((UnitPriceOfStoreOrNSNReport)ParentReport).RuntimeParameters.MATERIALFLAG = 0;
            
            TTObjectContext objectContext = new TTObjectContext(true);
            MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)objectContext.GetObject(new Guid(((UnitPriceOfStoreOrNSNReport)ParentReport).RuntimeParameters.MAINSTORE), "MAINSTOREDEFINITION");
            DEPO.CalcValue =  mainStoreDefinition.Name;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public UnitPriceOfStoreOrNSNReport MyParentReport
                {
                    get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
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
            public UnitPriceOfStoreOrNSNReport MyParentReport
            {
                get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
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
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NSNNO { get {return Header().NSNNO;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NSNNO1 { get {return Header().NSNNO1;} }
            public TTReportField AMOUNT1 { get {return Footer().AMOUNT1;} }
            public TTReportField Count1 { get {return Footer().Count1;} }
            public TTReportField AMOUNT11 { get {return Footer().AMOUNT11;} }
            public TTReportField AMOUNT12 { get {return Footer().AMOUNT12;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Stock.UnitePriceOfReportQueryNew_Class>("UnitePriceOfReportQueryNew", Stock.UnitePriceOfReportQueryNew((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.MAINSTORE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public UnitPriceOfStoreOrNSNReport MyParentReport
                {
                    get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
                }
                
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField OBJECTID;
                public TTReportField MATERIAL;
                public TTReportField NewField18;
                public TTReportField NewField181;
                public TTReportField NSNNO;
                public TTReportField NewField1181;
                public TTReportField NewField15;
                public TTReportField NSNNO1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 22, 27, 27, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"S.NU.";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 43, 12, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"NSN";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 43, 6, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"MALZEME ADI";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 22, 60, 27, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"İŞLEM TARİHİ";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 22, 119, 27, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"MİKTAR";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 2, 238, 7, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 197, 6, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 22, 161, 27, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"KUL. MİKTAR";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 22, 196, 27, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"KALAN MİKTAR";

                    NSNNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 7, 197, 12, false);
                    NSNNO.Name = "NSNNO";
                    NSNNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSNNO.TextFont.CharSet = 162;
                    NSNNO.Value = @"";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 22, 95, 27, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"BİRİM FİYATI";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 13, 43, 18, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"MALIN DURUMU";

                    NSNNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 13, 197, 18, false);
                    NSNNO1.Name = "NSNNO1";
                    NSNNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSNNO1.ObjectDefName = "StockLevelType";
                    NSNNO1.DataMember = "Description";
                    NSNNO1.TextFont.CharSet = 162;
                    NSNNO1.Value = @"{@STOCKLEVELTYPE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.UnitePriceOfReportQueryNew_Class dataset_UnitePriceOfReportQueryNew = ParentGroup.rsGroup.GetCurrentRecord<Stock.UnitePriceOfReportQueryNew_Class>(0);
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    OBJECTID.CalcValue = (dataset_UnitePriceOfReportQueryNew != null ? Globals.ToStringCore(dataset_UnitePriceOfReportQueryNew.ObjectID) : "");
                    MATERIAL.CalcValue = @"";
                    NewField18.CalcValue = NewField18.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NSNNO.CalcValue = @"";
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NSNNO1.CalcValue = MyParentReport.RuntimeParameters.STOCKLEVELTYPE.ToString();
                    NSNNO1.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField4,NewField5,NewField6,NewField7,NewField8,OBJECTID,MATERIAL,NewField18,NewField181,NSNNO,NewField1181,NewField15,NSNNO1};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    if((((UnitPriceOfStoreOrNSNReport)ParentReport).RuntimeParameters.MATERIAL).Equals("00000000-0000-0000-0000-000000000000"))
            {
                Material material = (Material)objectContext.GetObject((Guid)(((UnitPriceOfStoreOrNSNReport)ParentReport).RuntimeParameters.MATERIAL), "MATERIAL");
                MATERIAL.CalcValue =  material.Name;
                NSNNO.CalcValue = material.NATOStockNO;
            }
            else
            {
                Stock stock = (Stock)objectContext.GetObject(new Guid(this.OBJECTID.CalcValue), "STOCK");
                MATERIAL.CalcValue = stock.Material.Name;
                NSNNO.CalcValue = stock.Material.NATOStockNO;
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public UnitPriceOfStoreOrNSNReport MyParentReport
                {
                    get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
                }
                
                public TTReportField AMOUNT1;
                public TTReportField Count1;
                public TTReportField AMOUNT11;
                public TTReportField AMOUNT12; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 119, 6, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT1.TextFont.Size = 9;
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"{@sumof(AMOUNT)@}";

                    Count1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 95, 6, false);
                    Count1.Name = "Count1";
                    Count1.DrawStyle = DrawStyleConstants.vbSolid;
                    Count1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Count1.TextFont.Size = 9;
                    Count1.TextFont.CharSet = 162;
                    Count1.Value = @"TOP. MİK.";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 161, 6, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT11.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT11.TextFont.Size = 9;
                    AMOUNT11.TextFont.CharSet = 162;
                    AMOUNT11.Value = @"{@sumof(USEDAMOUNT)@}";

                    AMOUNT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 196, 6, false);
                    AMOUNT12.Name = "AMOUNT12";
                    AMOUNT12.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT12.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT12.TextFont.Size = 9;
                    AMOUNT12.TextFont.CharSet = 162;
                    AMOUNT12.Value = @"{@sumof(RESTAMOUNT)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.UnitePriceOfReportQueryNew_Class dataset_UnitePriceOfReportQueryNew = ParentGroup.rsGroup.GetCurrentRecord<Stock.UnitePriceOfReportQueryNew_Class>(0);
                    AMOUNT1.CalcValue = ParentGroup.FieldSums["AMOUNT"].Value.ToString();;
                    Count1.CalcValue = Count1.Value;
                    AMOUNT11.CalcValue = ParentGroup.FieldSums["USEDAMOUNT"].Value.ToString();;
                    AMOUNT12.CalcValue = ParentGroup.FieldSums["RESTAMOUNT"].Value.ToString();;
                    return new TTReportObject[] { AMOUNT1,Count1,AMOUNT11,AMOUNT12};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public UnitPriceOfStoreOrNSNReport MyParentReport
            {
                get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Count { get {return Body().Count;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField USEDAMOUNT { get {return Body().USEDAMOUNT;} }
            public TTReportField RESTAMOUNT { get {return Body().RESTAMOUNT;} }
            public TTReportField OBJECTID12 { get {return Body().OBJECTID12;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField UNITPRICETEXT { get {return Body().UNITPRICETEXT;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public UnitPriceOfStoreOrNSNReport MyParentReport
                {
                    get { return (UnitPriceOfStoreOrNSNReport)ParentReport; }
                }
                
                public TTReportField Count;
                public TTReportField TRANSACTIONDATE;
                public TTReportField AMOUNT;
                public TTReportField USEDAMOUNT;
                public TTReportField RESTAMOUNT;
                public TTReportField OBJECTID12;
                public TTReportField OBJECTID;
                public TTReportField UNITPRICETEXT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    Count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 27, 6, false);
                    Count.Name = "Count";
                    Count.DrawStyle = DrawStyleConstants.vbSolid;
                    Count.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Count.TextFont.Size = 9;
                    Count.TextFont.CharSet = 162;
                    Count.Value = @"{@counter@}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 60, 6, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"Short Date";
                    TRANSACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TRANSACTIONDATE.TextFont.Size = 9;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 119, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"";

                    USEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 161, 6, false);
                    USEDAMOUNT.Name = "USEDAMOUNT";
                    USEDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    USEDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    USEDAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    USEDAMOUNT.TextFont.Size = 9;
                    USEDAMOUNT.TextFont.CharSet = 162;
                    USEDAMOUNT.Value = @"";

                    RESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 196, 6, false);
                    RESTAMOUNT.Name = "RESTAMOUNT";
                    RESTAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    RESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESTAMOUNT.TextFont.Size = 9;
                    RESTAMOUNT.TextFont.CharSet = 162;
                    RESTAMOUNT.Value = @"";

                    OBJECTID12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 1, 252, 6, false);
                    OBJECTID12.Name = "OBJECTID12";
                    OBJECTID12.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID12.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OBJECTID12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTID12.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 1, 235, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"";

                    UNITPRICETEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 95, 6, false);
                    UNITPRICETEXT.Name = "UNITPRICETEXT";
                    UNITPRICETEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICETEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICETEXT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICETEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICETEXT.TextFont.Size = 9;
                    UNITPRICETEXT.TextFont.CharSet = 162;
                    UNITPRICETEXT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Count.CalcValue = ParentGroup.Counter.ToString();
                    TRANSACTIONDATE.CalcValue = @"";
                    AMOUNT.CalcValue = @"";
                    USEDAMOUNT.CalcValue = @"";
                    RESTAMOUNT.CalcValue = @"";
                    OBJECTID12.CalcValue = @"";
                    OBJECTID.CalcValue = @"";
                    UNITPRICETEXT.CalcValue = @"";
                    return new TTReportObject[] { Count,TRANSACTIONDATE,AMOUNT,USEDAMOUNT,RESTAMOUNT,OBJECTID12,OBJECTID,UNITPRICETEXT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    UNITPRICETEXT.CalcValue = OBJECTID12.CalcValue + " TL ";
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

        public UnitPriceOfStoreOrNSNReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Malzeme", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
            reportParameter = Parameters.Add("MAINSTORE", "", "Ana Depo", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("MATERIALFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("STOCKLEVELTYPE", "", "Malın Durumu", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("a5d3a625-ebef-4793-94bf-db619afef912");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            if (parameters.ContainsKey("MAINSTORE"))
                _runtimeParameters.MAINSTORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MAINSTORE"]);
            if (parameters.ContainsKey("MATERIALFLAG"))
                _runtimeParameters.MATERIALFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["MATERIALFLAG"]);
            if (parameters.ContainsKey("STOCKLEVELTYPE"))
                _runtimeParameters.STOCKLEVELTYPE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKLEVELTYPE"]);
            Name = "UNITPRICEOFSTOREORNSNREPORT";
            Caption = "Taşınır Mal Birim Fiyat Listesi Raporu";
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