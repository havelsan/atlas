
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
    /// Yıllara Göre Giren Çıkan Malzeme Miktarları Raporu (Depolara Göre)
    /// </summary>
    public partial class TotalInOutStockForStoreByYear : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string STOCKCARDCLASSOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
            public string YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TotalInOutStockForStoreByYear MyParentReport
            {
                get { return (TotalInOutStockForStoreByYear)ParentReport; }
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
                public TotalInOutStockForStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForStoreByYear)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"{@YEAR@} YILINDA GİREN ÇIKAN MALZEME MİKTARLARI RAPORU
(Depolara Göre)";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString() + @" YILINDA GİREN ÇIKAN MALZEME MİKTARLARI RAPORU
(Depolara Göre)";
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { REPORTNAME,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TotalInOutStockForStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForStoreByYear)ParentReport; }
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
            public TotalInOutStockForStoreByYear MyParentReport
            {
                get { return (TotalInOutStockForStoreByYear)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME1311 { get {return Header().COLUMNNAME1311;} }
            public TTReportField COLUMNNAME1312 { get {return Header().COLUMNNAME1312;} }
            public TTReportField COLUMNNAME1211 { get {return Header().COLUMNNAME1211;} }
            public TTReportField PARAMETERNAME { get {return Header().PARAMETERNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PARAMETER { get {return Header().PARAMETER;} }
            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField PARAMETER1 { get {return Header().PARAMETER1;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PARAMETERCODE { get {return Header().PARAMETERCODE;} }
            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportField COLUMNNAME112 { get {return Header().COLUMNNAME112;} }
            public TTReportField COLUMNNAME113 { get {return Header().COLUMNNAME113;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PARAMETERNAME2 { get {return Header().PARAMETERNAME2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField STOCKCARD { get {return Header().STOCKCARD;} }
            public TTReportField PARAMETERNAME3 { get {return Header().PARAMETERNAME3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField PARAMETER3 { get {return Header().PARAMETER3;} }
            public TTReportField STOCKCARDCLASSOBJECTID { get {return Header().STOCKCARDCLASSOBJECTID;} }
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
                public TotalInOutStockForStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForStoreByYear)ParentReport; }
                }
                
                public TTReportField COLUMNNAME1311;
                public TTReportField COLUMNNAME1312;
                public TTReportField COLUMNNAME1211;
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField PARAMETER;
                public TTReportField COLUMNNAME1;
                public TTReportField COLUMNNAME2;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField PARAMETER1;
                public TTReportField NewField111;
                public TTReportField PARAMETERCODE;
                public TTReportField COLUMNNAME11;
                public TTReportField COLUMNNAME111;
                public TTReportField COLUMNNAME112;
                public TTReportField COLUMNNAME113;
                public TTReportShape NewLine1;
                public TTReportField PARAMETERNAME2;
                public TTReportField NewField12;
                public TTReportField STOCKCARD;
                public TTReportField PARAMETERNAME3;
                public TTReportField NewField13;
                public TTReportField PARAMETER3;
                public TTReportField STOCKCARDCLASSOBJECTID; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COLUMNNAME1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 33, 257, 38, false);
                    COLUMNNAME1311.Name = "COLUMNNAME1311";
                    COLUMNNAME1311.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME1311.TextFont.Size = 11;
                    COLUMNNAME1311.TextFont.Bold = true;
                    COLUMNNAME1311.TextFont.CharSet = 162;
                    COLUMNNAME1311.Value = @"Depoda Kalan";

                    COLUMNNAME1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 33, 233, 38, false);
                    COLUMNNAME1312.Name = "COLUMNNAME1312";
                    COLUMNNAME1312.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1312.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME1312.TextFont.Size = 11;
                    COLUMNNAME1312.TextFont.Bold = true;
                    COLUMNNAME1312.TextFont.CharSet = 162;
                    COLUMNNAME1312.Value = @"İade Edilen";

                    COLUMNNAME1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 33, 10, 38, false);
                    COLUMNNAME1211.Name = "COLUMNNAME1211";
                    COLUMNNAME1211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME1211.TextFont.Size = 11;
                    COLUMNNAME1211.TextFont.Bold = true;
                    COLUMNNAME1211.TextFont.CharSet = 162;
                    COLUMNNAME1211.Value = @"S.Nu.";

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

                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 33, 38, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1.TextFont.Size = 11;
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"Nato Stok Nu.";

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 33, 93, 38, false);
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

                    PARAMETERCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 5, 43, 10, false);
                    PARAMETERCODE.Name = "PARAMETERCODE";
                    PARAMETERCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETERCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERCODE.TextFont.Bold = true;
                    PARAMETERCODE.TextFont.CharSet = 162;
                    PARAMETERCODE.Value = @"";

                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 33, 137, 38, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME11.TextFont.Size = 11;
                    COLUMNNAME11.TextFont.Bold = true;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"Ana Depo Mevcudu";

                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 33, 161, 38, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME111.TextFont.Size = 11;
                    COLUMNNAME111.TextFont.Bold = true;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"İstenen";

                    COLUMNNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 33, 185, 38, false);
                    COLUMNNAME112.Name = "COLUMNNAME112";
                    COLUMNNAME112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME112.TextFont.Size = 11;
                    COLUMNNAME112.TextFont.Bold = true;
                    COLUMNNAME112.TextFont.CharSet = 162;
                    COLUMNNAME112.Value = @"Karşılanan";

                    COLUMNNAME113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 33, 209, 38, false);
                    COLUMNNAME113.Name = "COLUMNNAME113";
                    COLUMNNAME113.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME113.TextFont.Size = 11;
                    COLUMNNAME113.TextFont.Bold = true;
                    COLUMNNAME113.TextFont.CharSet = 162;
                    COLUMNNAME113.Value = @"Sarf Edilen";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 39, 257, 39, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    PARAMETERNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 29, 15, false);
                    PARAMETERNAME2.Name = "PARAMETERNAME2";
                    PARAMETERNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME2.TextFont.Bold = true;
                    PARAMETERNAME2.TextFont.CharSet = 162;
                    PARAMETERNAME2.Value = @"Stok Kartı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 10, 33, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    STOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 10, 170, 15, false);
                    STOCKCARD.Name = "STOCKCARD";
                    STOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARD.ObjectDefName = "StockCard";
                    STOCKCARD.DataMember = "NAME";
                    STOCKCARD.TextFont.Bold = true;
                    STOCKCARD.TextFont.CharSet = 162;
                    STOCKCARD.Value = @"{@STOCKCARDID@}";

                    PARAMETERNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 29, 20, false);
                    PARAMETERNAME3.Name = "PARAMETERNAME3";
                    PARAMETERNAME3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME3.TextFont.Bold = true;
                    PARAMETERNAME3.TextFont.CharSet = 162;
                    PARAMETERNAME3.Value = @"Hesap Dönemi";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 15, 33, 20, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    PARAMETER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 15, 170, 20, false);
                    PARAMETER3.Name = "PARAMETER3";
                    PARAMETER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER3.TextFont.Bold = true;
                    PARAMETER3.TextFont.CharSet = 162;
                    PARAMETER3.Value = @"{@YEAR@}";

                    STOCKCARDCLASSOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 3, 236, 8, false);
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
                    COLUMNNAME1311.CalcValue = COLUMNNAME1311.Value;
                    COLUMNNAME1312.CalcValue = COLUMNNAME1312.Value;
                    COLUMNNAME1211.CalcValue = COLUMNNAME1211.Value;
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
                    PARAMETERCODE.CalcValue = @"";
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    COLUMNNAME112.CalcValue = COLUMNNAME112.Value;
                    COLUMNNAME113.CalcValue = COLUMNNAME113.Value;
                    PARAMETERNAME2.CalcValue = PARAMETERNAME2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    STOCKCARD.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    STOCKCARD.PostFieldValueCalculation();
                    PARAMETERNAME3.CalcValue = PARAMETERNAME3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    PARAMETER3.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    STOCKCARDCLASSOBJECTID.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString();
                    return new TTReportObject[] { COLUMNNAME1311,COLUMNNAME1312,COLUMNNAME1211,PARAMETERNAME,NewField1,PARAMETER,COLUMNNAME1,COLUMNNAME2,PARAMETERNAME1,NewField11,PARAMETER1,NewField111,PARAMETERCODE,COLUMNNAME11,COLUMNNAME111,COLUMNNAME112,COLUMNNAME113,PARAMETERNAME2,NewField12,STOCKCARD,PARAMETERNAME3,NewField13,PARAMETER3,STOCKCARDCLASSOBJECTID};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    StockCardClass cardClass = (StockCardClass)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString()), typeof(StockCardClass));
            if (cardClass != null)
            {
                if(cardClass.Code != null)
                    PARAMETERCODE.CalcValue = cardClass.Code;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TotalInOutStockForStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForStoreByYear)ParentReport; }
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
            public TotalInOutStockForStoreByYear MyParentReport
            {
                get { return (TotalInOutStockForStoreByYear)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField MAINSTOREINHELD { get {return Body().MAINSTOREINHELD;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField ACCEPTEDAMOUNT { get {return Body().ACCEPTEDAMOUNT;} }
            public TTReportField RETURNINGAMOUNT { get {return Body().RETURNINGAMOUNT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField CONSUMABLEAMOUNT { get {return Body().CONSUMABLEAMOUNT;} }
            public TTReportField STOREINHELD { get {return Body().STOREINHELD;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[5];
                list[0] = new TTReportNqlData<Stock.GetTotalInHeldByYear_Class>("GetTotalInHeldByYear1", Stock.GetTotalInHeldByYear((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID)));
                list[1] = new TTReportNqlData<Stock.GetTotalInHeldByYear_Class>("GetTotalInHeldByYear2", Stock.GetTotalInHeldByYear((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID)));
                list[2] = new TTReportNqlData<SectionRequirementMaterial.GetTotalAmountByYear_Class>("GetTotalAmountByYear", SectionRequirementMaterial.GetTotalAmountByYear((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR)));
                list[3] = new TTReportNqlData<ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class>("GetTotalConsumptionByYear", ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR)));
                list[4] = new TTReportNqlData<ReturningDocumentMaterial.GetTotalReturningByYear_Class>("GetTotalReturningByYear", ReturningDocumentMaterial.GetTotalReturningByYear((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR)));
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
                public TotalInOutStockForStoreByYear MyParentReport
                {
                    get { return (TotalInOutStockForStoreByYear)ParentReport; }
                }
                
                public TTReportField STOCKCARDNAME;
                public TTReportField NSN;
                public TTReportField MAINSTOREINHELD;
                public TTReportField REQUESTAMOUNT;
                public TTReportField ACCEPTEDAMOUNT;
                public TTReportField RETURNINGAMOUNT;
                public TTReportShape NewLine1;
                public TTReportField COUNT;
                public TTReportField CONSUMABLEAMOUNT;
                public TTReportField STOREINHELD; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 105, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 33, 6, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#STOCKCARDNSN#}";

                    MAINSTOREINHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 1, 135, 6, false);
                    MAINSTOREINHELD.Name = "MAINSTOREINHELD";
                    MAINSTOREINHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINSTOREINHELD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MAINSTOREINHELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAINSTOREINHELD.TextFont.CharSet = 162;
                    MAINSTOREINHELD.Value = @"{#INHELD#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 1, 160, 6, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#REQUESTAMOUNT!GetTotalAmountByYear#}";

                    ACCEPTEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 1, 184, 6, false);
                    ACCEPTEDAMOUNT.Name = "ACCEPTEDAMOUNT";
                    ACCEPTEDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCEPTEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ACCEPTEDAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCEPTEDAMOUNT.TextFont.CharSet = 162;
                    ACCEPTEDAMOUNT.Value = @"{#ACCEPTEDAMOUNT!GetTotalAmountByYear#}";

                    RETURNINGAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 231, 6, false);
                    RETURNINGAMOUNT.Name = "RETURNINGAMOUNT";
                    RETURNINGAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETURNINGAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RETURNINGAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RETURNINGAMOUNT.TextFont.CharSet = 162;
                    RETURNINGAMOUNT.Value = @"{#RETURNINGAMOUNT!GetTotalReturningByYear#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 10, 6, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    CONSUMABLEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 208, 6, false);
                    CONSUMABLEAMOUNT.Name = "CONSUMABLEAMOUNT";
                    CONSUMABLEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMABLEAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSUMABLEAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMABLEAMOUNT.TextFont.CharSet = 162;
                    CONSUMABLEAMOUNT.Value = @"{#CONSUMABELAMOUNT!GetTotalConsumptionByYear#}";

                    STOREINHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 1, 256, 6, false);
                    STOREINHELD.Name = "STOREINHELD";
                    STOREINHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOREINHELD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOREINHELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOREINHELD.TextFont.CharSet = 162;
                    STOREINHELD.Value = @"{#INHELD!GetTotalInHeldByYear2#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetTotalInHeldByYear_Class dataset_GetTotalInHeldByYear1 = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetTotalInHeldByYear_Class>(0);
                    Stock.GetTotalInHeldByYear_Class dataset_GetTotalInHeldByYear2 = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetTotalInHeldByYear_Class>(1);
                    SectionRequirementMaterial.GetTotalAmountByYear_Class dataset_GetTotalAmountByYear = ParentGroup.rsGroup.GetCurrentRecord<SectionRequirementMaterial.GetTotalAmountByYear_Class>(2);
                    ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class dataset_GetTotalConsumptionByYear = ParentGroup.rsGroup.GetCurrentRecord<ProductionConsumptionDocumentMaterialOut.GetTotalConsumptionByYear_Class>(3);
                    ReturningDocumentMaterial.GetTotalReturningByYear_Class dataset_GetTotalReturningByYear = ParentGroup.rsGroup.GetCurrentRecord<ReturningDocumentMaterial.GetTotalReturningByYear_Class>(4);
                    STOCKCARDNAME.CalcValue = (dataset_GetTotalInHeldByYear1 != null ? Globals.ToStringCore(dataset_GetTotalInHeldByYear1.Stockcardname) : "");
                    NSN.CalcValue = (dataset_GetTotalInHeldByYear1 != null ? Globals.ToStringCore(dataset_GetTotalInHeldByYear1.Stockcardnsn) : "");
                    MAINSTOREINHELD.CalcValue = (dataset_GetTotalInHeldByYear1 != null ? Globals.ToStringCore(dataset_GetTotalInHeldByYear1.Inheld) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetTotalAmountByYear != null ? Globals.ToStringCore(dataset_GetTotalAmountByYear.Requestamount) : "");
                    ACCEPTEDAMOUNT.CalcValue = (dataset_GetTotalAmountByYear != null ? Globals.ToStringCore(dataset_GetTotalAmountByYear.Acceptedamount) : "");
                    RETURNINGAMOUNT.CalcValue = (dataset_GetTotalReturningByYear != null ? Globals.ToStringCore(dataset_GetTotalReturningByYear.Returningamount) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    CONSUMABLEAMOUNT.CalcValue = (dataset_GetTotalConsumptionByYear != null ? Globals.ToStringCore(dataset_GetTotalConsumptionByYear.Consumabelamount) : "");
                    STOREINHELD.CalcValue = (dataset_GetTotalInHeldByYear2 != null ? Globals.ToStringCore(dataset_GetTotalInHeldByYear2.Inheld) : "");
                    return new TTReportObject[] { STOCKCARDNAME,NSN,MAINSTOREINHELD,REQUESTAMOUNT,ACCEPTEDAMOUNT,RETURNINGAMOUNT,COUNT,CONSUMABLEAMOUNT,STOREINHELD};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TotalInOutStockForStoreByYear()
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
            reportParameter.ListFilterExpression = "PARENTSTOCKCARDCLASS IS NOT NULL";
            reportParameter = Parameters.Add("STOCKCARDID", "", "Stok Kartı Seçiniz", @"", true, true, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
            reportParameter.LinkedParameterName = "STOCKCARDCLASSOBJECTID";
            reportParameter.LinkedRelationDefID = new Guid("544fee26-2d85-453f-9e38-02a417e072bb");
            reportParameter = Parameters.Add("YEAR", "", "Hesap Dönemini Giriniz", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("STOCKCARDCLASSOBJECTID"))
                _runtimeParameters.STOCKCARDCLASSOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDCLASSOBJECTID"]);
            if (parameters.ContainsKey("STOCKCARDID"))
                _runtimeParameters.STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["STOCKCARDID"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["YEAR"]);
            Name = "TOTALINOUTSTOCKFORSTOREBYYEAR";
            Caption = "Yıllara Göre Giren Çıkan Malzeme Miktarları Raporu (Depolara Göre)";
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