
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
    /// Yıllara Göre Giren Çıkan Malzeme Miktarları Raporu (Ana Depoya Göre)
    /// </summary>
    public partial class TotalInOutStockForMainStoreByYear : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STOCKCARDCLASSOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? ACCOUNTINGTERM = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TotalInOutStockForMainStoreByYear MyParentReport
            {
                get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
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
                public TotalInOutStockForMainStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
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
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"
YILINDA GİREN ÇIKAN MALZEME MİKTARLARI RAPORU
(Ana Depoya Göre)";

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

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    AccountingTerm term = (AccountingTerm)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.ACCOUNTINGTERM.Value, typeof(AccountingTerm));
                    if (term != null)
                        REPORTNAME.CalcValue = "\n" + term.StartDate.Value.Year.ToString() + " YILINDA GİREN ÇIKAN MALZEME MİKTARLARI RAPORU\n(Ana Depoya Göre)";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TotalInOutStockForMainStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
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

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 141, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
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
            public TotalInOutStockForMainStoreByYear MyParentReport
            {
                get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
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
            public TTReportField STORE { get {return Header().STORE;} }
            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField STOCKCARDCLASS { get {return Header().STOCKCARDCLASS;} }
            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportField COLUMNNAME112 { get {return Header().COLUMNNAME112;} }
            public TTReportField COLUMNNAME113 { get {return Header().COLUMNNAME113;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField STOCKCARDCLASSOBJECTID { get {return Header().STOCKCARDCLASSOBJECTID;} }
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
                public TotalInOutStockForMainStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField STORE;
                public TTReportField COLUMNNAME1;
                public TTReportField COLUMNNAME2;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField STOCKCARDCLASS;
                public TTReportField COLUMNNAME11;
                public TTReportField COLUMNNAME111;
                public TTReportField COLUMNNAME112;
                public TTReportField COLUMNNAME113;
                public TTReportShape NewLine1;
                public TTReportField STOCKCARDCLASSOBJECTID; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PARAMETERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 29, 5, false);
                    PARAMETERNAME.Name = "PARAMETERNAME";
                    PARAMETERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME.TextFont.Name = "Arial";
                    PARAMETERNAME.TextFont.Bold = true;
                    PARAMETERNAME.TextFont.CharSet = 162;
                    PARAMETERNAME.Value = @"Depo Adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 31, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 0, 257, 5, false);
                    STORE.Name = "STORE";
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORE.ObjectDefName = "Store";
                    STORE.DataMember = "NAME";
                    STORE.TextFont.Name = "Arial";
                    STORE.TextFont.CharSet = 162;
                    STORE.Value = @"{@STOREID@}";

                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 17, 27, 22, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME1.TextFont.Name = "Arial";
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"Nato Stok Nu.";

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 17, 87, 22, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME2.TextFont.Name = "Arial";
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Stok Kart Adı";

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 29, 10, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Name = "Arial";
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Stok Kartı Sınıfı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 5, 31, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    STOCKCARDCLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 5, 257, 10, false);
                    STOCKCARDCLASS.Name = "STOCKCARDCLASS";
                    STOCKCARDCLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASS.TextFont.Name = "Arial";
                    STOCKCARDCLASS.TextFont.CharSet = 162;
                    STOCKCARDCLASS.Value = @"";

                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 17, 155, 22, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME11.TextFont.Name = "Arial";
                    COLUMNNAME11.TextFont.Bold = true;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"Giren Miktar";

                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 17, 189, 22, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME111.TextFont.Name = "Arial";
                    COLUMNNAME111.TextFont.Bold = true;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"Çıkan Miktar";

                    COLUMNNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 17, 223, 22, false);
                    COLUMNNAME112.Name = "COLUMNNAME112";
                    COLUMNNAME112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME112.TextFont.Name = "Arial";
                    COLUMNNAME112.TextFont.Bold = true;
                    COLUMNNAME112.TextFont.CharSet = 162;
                    COLUMNNAME112.Value = @"Giren Fiyatı";

                    COLUMNNAME113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 17, 257, 22, false);
                    COLUMNNAME113.Name = "COLUMNNAME113";
                    COLUMNNAME113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME113.TextFont.Name = "Arial";
                    COLUMNNAME113.TextFont.Bold = true;
                    COLUMNNAME113.TextFont.CharSet = 162;
                    COLUMNNAME113.Value = @"Çıkan Fiyatı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 22, 257, 22, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    STOCKCARDCLASSOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 11, 119, 16, false);
                    STOCKCARDCLASSOBJECTID.Name = "STOCKCARDCLASSOBJECTID";
                    STOCKCARDCLASSOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKCARDCLASSOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSOBJECTID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASSOBJECTID.TextFont.Bold = true;
                    STOCKCARDCLASSOBJECTID.TextFont.CharSet = 162;
                    STOCKCARDCLASSOBJECTID.Value = @"{@STOCKCARDCLASSOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    STORE.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STORE.PostFieldValueCalculation();
                    COLUMNNAME1.CalcValue = COLUMNNAME1.Value;
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    STOCKCARDCLASS.CalcValue = @"";
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    COLUMNNAME112.CalcValue = COLUMNNAME112.Value;
                    COLUMNNAME113.CalcValue = COLUMNNAME113.Value;
                    STOCKCARDCLASSOBJECTID.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString();
                    return new TTReportObject[] { PARAMETERNAME,NewField1,STORE,COLUMNNAME1,COLUMNNAME2,PARAMETERNAME1,NewField11,STOCKCARDCLASS,COLUMNNAME11,COLUMNNAME111,COLUMNNAME112,COLUMNNAME113,STOCKCARDCLASSOBJECTID};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    StockCardClass cardClass = null;
                    cardClass = (StockCardClass)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.Value, typeof(StockCardClass));
            if (cardClass != null)
            {
                if(cardClass.Code != null)
                    STOCKCARDCLASS.CalcValue = cardClass.Code + " - " + cardClass.Name;
                else
                    STOCKCARDCLASS.CalcValue = cardClass.Name;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TotalInOutStockForMainStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
                }
                
                public TTReportField SUMTOTALIN;
                public TTReportField SUMTOTALOUT;
                public TTReportField SUMTOTALINPRICE;
                public TTReportField TOTALOUTPRICE;
                public TTReportField NewField2; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SUMTOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 155, 6, false);
                    SUMTOTALIN.Name = "SUMTOTALIN";
                    SUMTOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMTOTALIN.TextFormat = @"#,##0.00";
                    SUMTOTALIN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMTOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMTOTALIN.TextFont.Name = "Arial";
                    SUMTOTALIN.TextFont.Bold = true;
                    SUMTOTALIN.TextFont.CharSet = 162;
                    SUMTOTALIN.Value = @"{@sumof(TOTALIN)@}";

                    SUMTOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 189, 6, false);
                    SUMTOTALOUT.Name = "SUMTOTALOUT";
                    SUMTOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMTOTALOUT.TextFormat = @"#,##0.00";
                    SUMTOTALOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMTOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMTOTALOUT.TextFont.Name = "Arial";
                    SUMTOTALOUT.TextFont.Bold = true;
                    SUMTOTALOUT.TextFont.CharSet = 162;
                    SUMTOTALOUT.Value = @"{@sumof(TOTALOUT)@}";

                    SUMTOTALINPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 1, 223, 6, false);
                    SUMTOTALINPRICE.Name = "SUMTOTALINPRICE";
                    SUMTOTALINPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMTOTALINPRICE.TextFormat = @"#,##0.00";
                    SUMTOTALINPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMTOTALINPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMTOTALINPRICE.TextFont.Name = "Arial";
                    SUMTOTALINPRICE.TextFont.Bold = true;
                    SUMTOTALINPRICE.TextFont.CharSet = 162;
                    SUMTOTALINPRICE.Value = @"{@sumof(TOTALINPRICE)@}";

                    TOTALOUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 257, 6, false);
                    TOTALOUTPRICE.Name = "TOTALOUTPRICE";
                    TOTALOUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUTPRICE.TextFormat = @"#,##0.00";
                    TOTALOUTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUTPRICE.TextFont.Name = "Arial";
                    TOTALOUTPRICE.TextFont.Bold = true;
                    TOTALOUTPRICE.TextFont.CharSet = 162;
                    TOTALOUTPRICE.Value = @"{@sumof(TOTALOUTPRICE)@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 122, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
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
            public TotalInOutStockForMainStoreByYear MyParentReport
            {
                get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
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
                list[0] = new TTReportNqlData<Stock.GetTotalInOutStockByYear_Class>("GetTotalInOutStockByYear", Stock.GetTotalInOutStockByYear((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTINGTERM)));
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
                public TotalInOutStockForMainStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForMainStoreByYear)ParentReport; }
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
                    
                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 121, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.TextFont.Name = "Arial";
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 27, 6, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#STOCKCARDNSN#}";

                    TOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 155, 6, false);
                    TOTALIN.Name = "TOTALIN";
                    TOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALIN.TextFormat = @"#,##0.00";
                    TOTALIN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALIN.TextFont.Name = "Arial";
                    TOTALIN.TextFont.CharSet = 162;
                    TOTALIN.Value = @"{#TOTALIN#}";

                    TOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 189, 6, false);
                    TOTALOUT.Name = "TOTALOUT";
                    TOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUT.TextFormat = @"-#,##0.00";
                    TOTALOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUT.TextFont.Name = "Arial";
                    TOTALOUT.TextFont.CharSet = 162;
                    TOTALOUT.Value = @"{#TOTALOUT#}";

                    TOTALINPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 1, 223, 6, false);
                    TOTALINPRICE.Name = "TOTALINPRICE";
                    TOTALINPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINPRICE.TextFormat = @"#,##0.00";
                    TOTALINPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALINPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALINPRICE.TextFont.Name = "Arial";
                    TOTALINPRICE.TextFont.CharSet = 162;
                    TOTALINPRICE.Value = @"{#TOTALINPRICE#}";

                    TOTALOUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 257, 6, false);
                    TOTALOUTPRICE.Name = "TOTALOUTPRICE";
                    TOTALOUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUTPRICE.TextFormat = @"#,##0.00";
                    TOTALOUTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUTPRICE.TextFont.Name = "Arial";
                    TOTALOUTPRICE.TextFont.CharSet = 162;
                    TOTALOUTPRICE.Value = @"{#TOTALOUTPRICE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetTotalInOutStockByYear_Class dataset_GetTotalInOutStockByYear = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetTotalInOutStockByYear_Class>(0);
                    STOCKCARDNAME.CalcValue = (dataset_GetTotalInOutStockByYear != null ? Globals.ToStringCore(dataset_GetTotalInOutStockByYear.Stockcardname) : "");
                    NSN.CalcValue = (dataset_GetTotalInOutStockByYear != null ? Globals.ToStringCore(dataset_GetTotalInOutStockByYear.Stockcardnsn) : "");
                    TOTALIN.CalcValue = (dataset_GetTotalInOutStockByYear != null ? Globals.ToStringCore(dataset_GetTotalInOutStockByYear.Totalin) : "");
                    TOTALOUT.CalcValue = (dataset_GetTotalInOutStockByYear != null ? Globals.ToStringCore(dataset_GetTotalInOutStockByYear.Totalout) : "");
                    TOTALINPRICE.CalcValue = (dataset_GetTotalInOutStockByYear != null ? Globals.ToStringCore(dataset_GetTotalInOutStockByYear.Totalinprice) : "");
                    TOTALOUTPRICE.CalcValue = (dataset_GetTotalInOutStockByYear != null ? Globals.ToStringCore(dataset_GetTotalInOutStockByYear.Totaloutprice) : "");
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

        public TotalInOutStockForMainStoreByYear()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("STOCKCARDCLASSOBJECTID", "00000000-0000-0000-0000-000000000000", "Stok Kartı Sınıfını Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
            reportParameter = Parameters.Add("ACCOUNTINGTERM", "00000000-0000-0000-0000-000000000000", "Hesap Dönemini Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("STOCKCARDCLASSOBJECTID"))
                _runtimeParameters.STOCKCARDCLASSOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOCKCARDCLASSOBJECTID"]);
            if (parameters.ContainsKey("ACCOUNTINGTERM"))
                _runtimeParameters.ACCOUNTINGTERM = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ACCOUNTINGTERM"]);
            Name = "TOTALINOUTSTOCKFORMAINSTOREBYYEAR";
            Caption = "Yıllara Göre Giren Çıkan Malzeme Miktarları Raporu (Ana Depoya Göre)";
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