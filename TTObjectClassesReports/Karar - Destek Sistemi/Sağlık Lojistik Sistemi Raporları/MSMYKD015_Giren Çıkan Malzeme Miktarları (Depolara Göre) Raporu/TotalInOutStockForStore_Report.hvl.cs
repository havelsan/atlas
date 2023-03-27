
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
    /// Giren Çıkan Malzeme Miktarları (Depolara Göre) Raporu
    /// </summary>
    public partial class TotalInOutStockForStore : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string STOCKCARDCLASSOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TotalInOutStockForStore MyParentReport
            {
                get { return (TotalInOutStockForStore)ParentReport; }
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
                public TotalInOutStockForStore MyParentReport
                {
                    get { return (TotalInOutStockForStore)ParentReport; }
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
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"GİREN ÇIKAN MALZEME MİKTARLARI (Depolara Göre) RAPORU";

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
                public TotalInOutStockForStore MyParentReport
                {
                    get { return (TotalInOutStockForStore)ParentReport; }
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
            public TotalInOutStockForStore MyParentReport
            {
                get { return (TotalInOutStockForStore)ParentReport; }
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
            public TTReportField PARAMETER { get {return Header().PARAMETER;} }
            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField PARAMETER1 { get {return Header().PARAMETER1;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PARAMETER11 { get {return Header().PARAMETER11;} }
            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportField COLUMNNAME112 { get {return Header().COLUMNNAME112;} }
            public TTReportField COLUMNNAME113 { get {return Header().COLUMNNAME113;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField SUMTOTALIN { get {return Footer().SUMTOTALIN;} }
            public TTReportField SUMTOTALOUT { get {return Footer().SUMTOTALOUT;} }
            public TTReportField SUMTOTALINPRICE { get {return Footer().SUMTOTALINPRICE;} }
            public TTReportField TOTALOUTPRICE { get {return Footer().TOTALOUTPRICE;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
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
                public TotalInOutStockForStore MyParentReport
                {
                    get { return (TotalInOutStockForStore)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField PARAMETER;
                public TTReportField COLUMNNAME1;
                public TTReportField COLUMNNAME2;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField PARAMETER1;
                public TTReportField NewField111;
                public TTReportField PARAMETER11;
                public TTReportField COLUMNNAME11;
                public TTReportField COLUMNNAME111;
                public TTReportField COLUMNNAME112;
                public TTReportField COLUMNNAME113;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PARAMETERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 29, 5, false);
                    PARAMETERNAME.Name = "PARAMETERNAME";
                    PARAMETERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME.TextFont.Bold = true;
                    PARAMETERNAME.TextFont.CharSet = 162;
                    PARAMETERNAME.Value = @"Depo Adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 33, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    PARAMETER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 170, 5, false);
                    PARAMETER.Name = "PARAMETER";
                    PARAMETER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER.ObjectDefName = "Store";
                    PARAMETER.DataMember = "NAME";
                    PARAMETER.TextFont.Bold = true;
                    PARAMETER.TextFont.CharSet = 162;
                    PARAMETER.Value = @"{@STOREID@}";

                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 17, 22, 22, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1.TextFont.Size = 11;
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"Nato Stok Nu.";

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 17, 83, 22, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME2.TextFont.Size = 11;
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Stok Kart Adı";

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 29, 10, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Stok Kartı Sınıfı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 5, 33, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    PARAMETER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 5, 170, 10, false);
                    PARAMETER1.Name = "PARAMETER1";
                    PARAMETER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER1.ObjectDefName = "StockCardClass";
                    PARAMETER1.DataMember = "NAME";
                    PARAMETER1.TextFont.Bold = true;
                    PARAMETER1.TextFont.CharSet = 162;
                    PARAMETER1.Value = @"{@STOCKCARDCLASSOBJECTID@}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 5, 47, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"/";

                    PARAMETER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 5, 43, 10, false);
                    PARAMETER11.Name = "PARAMETER11";
                    PARAMETER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER11.ObjectDefName = "StockCardClass";
                    PARAMETER11.DataMember = "CODE";
                    PARAMETER11.TextFont.Bold = true;
                    PARAMETER11.TextFont.CharSet = 162;
                    PARAMETER11.Value = @"{@STOCKCARDCLASSOBJECTID@}";

                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 17, 155, 22, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME11.TextFont.Size = 11;
                    COLUMNNAME11.TextFont.Bold = true;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"Toplam Giren Miktar";

                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 17, 189, 22, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME111.TextFont.Size = 11;
                    COLUMNNAME111.TextFont.Bold = true;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"Toplam Çıkan Miktar";

                    COLUMNNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 17, 223, 22, false);
                    COLUMNNAME112.Name = "COLUMNNAME112";
                    COLUMNNAME112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME112.TextFont.Size = 11;
                    COLUMNNAME112.TextFont.Bold = true;
                    COLUMNNAME112.TextFont.CharSet = 162;
                    COLUMNNAME112.Value = @"Toplam Giren Fiyatı";

                    COLUMNNAME113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 17, 257, 22, false);
                    COLUMNNAME113.Name = "COLUMNNAME113";
                    COLUMNNAME113.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME113.TextFont.Size = 11;
                    COLUMNNAME113.TextFont.Bold = true;
                    COLUMNNAME113.TextFont.CharSet = 162;
                    COLUMNNAME113.Value = @"Toplam Çıkan Fiyatı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 22, 257, 22, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    PARAMETER.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    PARAMETER.PostFieldValueCalculation();
                    COLUMNNAME1.CalcValue = COLUMNNAME1.Value;
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    PARAMETER1.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString();
                    PARAMETER1.PostFieldValueCalculation();
                    NewField111.CalcValue = NewField111.Value;
                    PARAMETER11.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString();
                    PARAMETER11.PostFieldValueCalculation();
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    COLUMNNAME112.CalcValue = COLUMNNAME112.Value;
                    COLUMNNAME113.CalcValue = COLUMNNAME113.Value;
                    return new TTReportObject[] { PARAMETERNAME,NewField1,PARAMETER,COLUMNNAME1,COLUMNNAME2,PARAMETERNAME1,NewField11,PARAMETER1,NewField111,PARAMETER11,COLUMNNAME11,COLUMNNAME111,COLUMNNAME112,COLUMNNAME113};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TotalInOutStockForStore MyParentReport
                {
                    get { return (TotalInOutStockForStore)ParentReport; }
                }
                
                public TTReportField SUMTOTALIN;
                public TTReportField SUMTOTALOUT;
                public TTReportField SUMTOTALINPRICE;
                public TTReportField TOTALOUTPRICE;
                public TTReportField NewField2; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SUMTOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 155, 6, false);
                    SUMTOTALIN.Name = "SUMTOTALIN";
                    SUMTOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMTOTALIN.TextFormat = @"#,##0.00";
                    SUMTOTALIN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMTOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMTOTALIN.TextFont.Bold = true;
                    SUMTOTALIN.TextFont.CharSet = 162;
                    SUMTOTALIN.Value = @"{@sumof(TOTALIN)@}";

                    SUMTOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 189, 6, false);
                    SUMTOTALOUT.Name = "SUMTOTALOUT";
                    SUMTOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMTOTALOUT.TextFormat = @"#,##0.00";
                    SUMTOTALOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMTOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMTOTALOUT.TextFont.Bold = true;
                    SUMTOTALOUT.TextFont.CharSet = 162;
                    SUMTOTALOUT.Value = @"{@sumof(TOTALOUT)@}";

                    SUMTOTALINPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 1, 223, 6, false);
                    SUMTOTALINPRICE.Name = "SUMTOTALINPRICE";
                    SUMTOTALINPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMTOTALINPRICE.TextFormat = @"#,##0.00";
                    SUMTOTALINPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMTOTALINPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMTOTALINPRICE.TextFont.Bold = true;
                    SUMTOTALINPRICE.TextFont.CharSet = 162;
                    SUMTOTALINPRICE.Value = @"{@sumof(TOTALINPRICE)@}";

                    TOTALOUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 257, 6, false);
                    TOTALOUTPRICE.Name = "TOTALOUTPRICE";
                    TOTALOUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUTPRICE.TextFormat = @"#,##0.00";
                    TOTALOUTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUTPRICE.TextFont.Bold = true;
                    TOTALOUTPRICE.TextFont.CharSet = 162;
                    TOTALOUTPRICE.Value = @"{@sumof(TOTALOUTPRICE)@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 122, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"TOPLAMLAR :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMTOTALIN.CalcValue = ParentGroup.FieldSums["TOTALIN"].Value.ToString();;
                    SUMTOTALOUT.CalcValue = ParentGroup.FieldSums["TOTALOUT"].Value.ToString();;
                    SUMTOTALINPRICE.CalcValue = ParentGroup.FieldSums["TOTALINPRICE"].Value.ToString();;
                    TOTALOUTPRICE.CalcValue = ParentGroup.FieldSums["TOTALOUTPRICE"].Value.ToString();;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { SUMTOTALIN,SUMTOTALOUT,SUMTOTALINPRICE,TOTALOUTPRICE,NewField2};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public TotalInOutStockForStore MyParentReport
            {
                get { return (TotalInOutStockForStore)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField TOTALIN { get {return Body().TOTALIN;} }
            public TTReportField TOTALOUT { get {return Body().TOTALOUT;} }
            public TTReportField TOTALINPRICE { get {return Body().TOTALINPRICE;} }
            public TTReportField TOTALOUTPRICE { get {return Body().TOTALOUTPRICE;} }
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
                list[0] = new TTReportNqlData<Stock.GetTotalInOutStock_Class>("GTIOS", Stock.GetTotalInOutStock((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID)));
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
                public TotalInOutStockForStore MyParentReport
                {
                    get { return (TotalInOutStockForStore)ParentReport; }
                }
                
                public TTReportField STOCKCARDNAME;
                public TTReportField NSN;
                public TTReportField TOTALIN;
                public TTReportField TOTALOUT;
                public TTReportField TOTALINPRICE;
                public TTReportField TOTALOUTPRICE;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 120, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 22, 6, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#STOCKCARDNSN#}";

                    TOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 155, 6, false);
                    TOTALIN.Name = "TOTALIN";
                    TOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALIN.TextFormat = @"#,##0.00";
                    TOTALIN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALIN.TextFont.CharSet = 162;
                    TOTALIN.Value = @"{#TOTALIN#}";

                    TOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 189, 6, false);
                    TOTALOUT.Name = "TOTALOUT";
                    TOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUT.TextFormat = @"-#,##0.00";
                    TOTALOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUT.TextFont.CharSet = 162;
                    TOTALOUT.Value = @"{#TOTALOUT#}";

                    TOTALINPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 1, 223, 6, false);
                    TOTALINPRICE.Name = "TOTALINPRICE";
                    TOTALINPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINPRICE.TextFormat = @"#,##0.00";
                    TOTALINPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALINPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALINPRICE.TextFont.CharSet = 162;
                    TOTALINPRICE.Value = @"{#TOTALINPRICE#}";

                    TOTALOUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 257, 6, false);
                    TOTALOUTPRICE.Name = "TOTALOUTPRICE";
                    TOTALOUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUTPRICE.TextFormat = @"#,##0.00";
                    TOTALOUTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUTPRICE.TextFont.CharSet = 162;
                    TOTALOUTPRICE.Value = @"{#TOTALOUTPRICE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetTotalInOutStock_Class dataset_GTIOS = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetTotalInOutStock_Class>(0);
                    STOCKCARDNAME.CalcValue = (dataset_GTIOS != null ? Globals.ToStringCore(dataset_GTIOS.Stockcardname) : "");
                    NSN.CalcValue = (dataset_GTIOS != null ? Globals.ToStringCore(dataset_GTIOS.Stockcardnsn) : "");
                    TOTALIN.CalcValue = (dataset_GTIOS != null ? Globals.ToStringCore(dataset_GTIOS.Totalin) : "");
                    TOTALOUT.CalcValue = (dataset_GTIOS != null ? Globals.ToStringCore(dataset_GTIOS.Totalout) : "");
                    TOTALINPRICE.CalcValue = (dataset_GTIOS != null ? Globals.ToStringCore(dataset_GTIOS.Totalinprice) : "");
                    TOTALOUTPRICE.CalcValue = (dataset_GTIOS != null ? Globals.ToStringCore(dataset_GTIOS.Totaloutprice) : "");
                    return new TTReportObject[] { STOCKCARDNAME,NSN,TOTALIN,TOTALOUT,TOTALINPRICE,TOTALOUTPRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TotalInOutStockForStore()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "", "Depo Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STOCKCARDCLASSOBJECTID", "", "Stok Kartı Sınıfını Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("STOCKCARDCLASSOBJECTID"))
                _runtimeParameters.STOCKCARDCLASSOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDCLASSOBJECTID"]);
            Name = "TOTALINOUTSTOCKFORSTORE";
            Caption = "Giren Çıkan Malzeme Miktarları (Depolara Göre) Raporu";
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