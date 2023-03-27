
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
    /// Depolarda Sarf edilen Malzemeler
    /// </summary>
    public partial class ConsumableMaterialForStore : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string CLASSID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public ReportType? REPORTTYPE = (ReportType?)(int?)TTObjectDefManager.Instance.DataTypes["ReportType"].ConvertValue("0");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("23:59");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ConsumableMaterialForStore MyParentReport
            {
                get { return (ConsumableMaterialForStore)ParentReport; }
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
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
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
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 4, 257, 16, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"DEPOLARDA SARF EDİLEN MALZEMELER";

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
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
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

        public partial class PARTCGroup : TTReportGroup
        {
            public ConsumableMaterialForStore MyParentReport
            {
                get { return (ConsumableMaterialForStore)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField PARAMETERNAME11 { get {return Header().PARAMETERNAME11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField STOCKCARDCLASSNAME { get {return Header().STOCKCARDCLASSNAME;} }
            public TTReportField PARAMETERNAME111 { get {return Header().PARAMETERNAME111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField PARAMETERNAME112 { get {return Header().PARAMETERNAME112;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField PARAMETERNAME1211 { get {return Header().PARAMETERNAME1211;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField REPORTTYPE { get {return Header().REPORTTYPE;} }
            public TTReportField TOTALAMOUNT11111 { get {return Footer().TOTALAMOUNT11111;} }
            public TTReportField TOTALCOST11 { get {return Footer().TOTALCOST11;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME11;
                public TTReportField NewField111;
                public TTReportField STOCKCARDCLASSNAME;
                public TTReportField PARAMETERNAME111;
                public TTReportField NewField1111;
                public TTReportField STORENAME;
                public TTReportField PARAMETERNAME112;
                public TTReportField NewField1112;
                public TTReportField DATE;
                public TTReportField PARAMETERNAME1211;
                public TTReportField NewField12111;
                public TTReportField REPORTTYPE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 37, 10, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Stok Kart Sınıfı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 5, 42, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    STOCKCARDCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 5, 186, 10, false);
                    STOCKCARDCLASSNAME.Name = "STOCKCARDCLASSNAME";
                    STOCKCARDCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASSNAME.ObjectDefName = "StockCardClass";
                    STOCKCARDCLASSNAME.DataMember = "NAME";
                    STOCKCARDCLASSNAME.TextFont.Bold = true;
                    STOCKCARDCLASSNAME.TextFont.CharSet = 162;
                    STOCKCARDCLASSNAME.Value = @"{@CLASSID@}";

                    PARAMETERNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 37, 5, false);
                    PARAMETERNAME111.Name = "PARAMETERNAME111";
                    PARAMETERNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME111.TextFont.Bold = true;
                    PARAMETERNAME111.TextFont.CharSet = 162;
                    PARAMETERNAME111.Value = @"Depo Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 42, 5, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @":";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 186, 5, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORENAME.ObjectDefName = "Store";
                    STORENAME.DataMember = "NAME";
                    STORENAME.TextFont.Bold = true;
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{@STOREID@}";

                    PARAMETERNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 37, 20, false);
                    PARAMETERNAME112.Name = "PARAMETERNAME112";
                    PARAMETERNAME112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME112.TextFont.Bold = true;
                    PARAMETERNAME112.TextFont.CharSet = 162;
                    PARAMETERNAME112.Value = @"Başlangıç / Bitiş Tarihi";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 15, 42, 20, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @":";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 15, 186, 20, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Bold = true;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@STARTDATE@} / {@ENDDATE@}";

                    PARAMETERNAME1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 37, 15, false);
                    PARAMETERNAME1211.Name = "PARAMETERNAME1211";
                    PARAMETERNAME1211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1211.TextFont.Bold = true;
                    PARAMETERNAME1211.TextFont.CharSet = 162;
                    PARAMETERNAME1211.Value = @"Rapor Tipi";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 10, 42, 15, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @":";

                    REPORTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 10, 186, 15, false);
                    REPORTTYPE.Name = "REPORTTYPE";
                    REPORTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTTYPE.ObjectDefName = "ReportType";
                    REPORTTYPE.DataMember = "DISPLAYTEXT";
                    REPORTTYPE.TextFont.Bold = true;
                    REPORTTYPE.TextFont.CharSet = 162;
                    REPORTTYPE.Value = @"{@REPORTTYPE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME11.CalcValue = PARAMETERNAME11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    STOCKCARDCLASSNAME.CalcValue = MyParentReport.RuntimeParameters.CLASSID.ToString();
                    STOCKCARDCLASSNAME.PostFieldValueCalculation();
                    PARAMETERNAME111.CalcValue = PARAMETERNAME111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    STORENAME.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STORENAME.PostFieldValueCalculation();
                    PARAMETERNAME112.CalcValue = PARAMETERNAME112.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    DATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString() + @" / " + MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    PARAMETERNAME1211.CalcValue = PARAMETERNAME1211.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    REPORTTYPE.CalcValue = MyParentReport.RuntimeParameters.REPORTTYPE.ToString();
                    REPORTTYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { PARAMETERNAME11,NewField111,STOCKCARDCLASSNAME,PARAMETERNAME111,NewField1111,STORENAME,PARAMETERNAME112,NewField1112,DATE,PARAMETERNAME1211,NewField12111,REPORTTYPE};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField TOTALAMOUNT11111;
                public TTReportField TOTALCOST11;
                public TTReportShape NewLine1; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALAMOUNT11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 4, 232, 9, false);
                    TOTALAMOUNT11111.Name = "TOTALAMOUNT11111";
                    TOTALAMOUNT11111.TextFormat = @"#,##0.00";
                    TOTALAMOUNT11111.TextFont.Bold = true;
                    TOTALAMOUNT11111.TextFont.CharSet = 162;
                    TOTALAMOUNT11111.Value = @"GENEL TOPLAM MALİYET :";

                    TOTALCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 4, 257, 9, false);
                    TOTALCOST11.Name = "TOTALCOST11";
                    TOTALCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOST11.TextFormat = @"#,##0.00";
                    TOTALCOST11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCOST11.TextFont.Bold = true;
                    TOTALCOST11.TextFont.CharSet = 162;
                    TOTALCOST11.Value = @"{@sumof(UNVISIBLETOTALCOST)@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 2, 258, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTALAMOUNT11111.CalcValue = TOTALAMOUNT11111.Value;
                    TOTALCOST11.CalcValue = ParentGroup.FieldSums["UNVISIBLETOTALCOST"].Value.ToString();;
                    return new TTReportObject[] { TOTALAMOUNT11111,TOTALCOST11};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public ConsumableMaterialForStore MyParentReport
            {
                get { return (ConsumableMaterialForStore)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField DISTRIBUTIONTYPE { get {return Header().DISTRIBUTIONTYPE;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField SIRANU { get {return Header().SIRANU;} }
            public TTReportField STOCKCARDCLASSCODE11 { get {return Header().STOCKCARDCLASSCODE11;} }
            public TTReportField STOCKCARDCLASSNAME11 { get {return Header().STOCKCARDCLASSNAME11;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportField NSN { get {return Header().NSN;} }
            public TTReportField CARDORDERNO { get {return Header().CARDORDERNO;} }
            public TTReportField STOCKCARDNAME { get {return Header().STOCKCARDNAME;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField UNVISIBLETOTALCOST { get {return Footer().UNVISIBLETOTALCOST;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StockTransaction.ConsumableStockCardQuery_Class>("CSCQ", StockTransaction.ConsumableStockCardQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.CLASSID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField NewField1111;
                public TTReportField SIRANU;
                public TTReportField STOCKCARDCLASSCODE11;
                public TTReportField STOCKCARDCLASSNAME11;
                public TTReportShape NewLine111111;
                public TTReportField NSN;
                public TTReportField CARDORDERNO;
                public TTReportField STOCKCARDNAME;
                public TTReportShape NewLine1;
                public TTReportField OBJECTID; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 8, 202, 13, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#STOCKCARDDISTRIBUTIONTYPE#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 2, 203, 7, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Dağıtım Şekli";

                    SIRANU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 13, 7, false);
                    SIRANU.Name = "SIRANU";
                    SIRANU.TextFont.Size = 11;
                    SIRANU.TextFont.Bold = true;
                    SIRANU.TextFont.CharSet = 162;
                    SIRANU.Value = @"Sıra Nu.";

                    STOCKCARDCLASSCODE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 41, 7, false);
                    STOCKCARDCLASSCODE11.Name = "STOCKCARDCLASSCODE11";
                    STOCKCARDCLASSCODE11.TextFont.Size = 11;
                    STOCKCARDCLASSCODE11.TextFont.Bold = true;
                    STOCKCARDCLASSCODE11.TextFont.CharSet = 162;
                    STOCKCARDCLASSCODE11.Value = @"Nato Stok Nu.";

                    STOCKCARDCLASSNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 2, 181, 7, false);
                    STOCKCARDCLASSNAME11.Name = "STOCKCARDCLASSNAME11";
                    STOCKCARDCLASSNAME11.MultiLine = EvetHayirEnum.ehEvet;
                    STOCKCARDCLASSNAME11.WordBreak = EvetHayirEnum.ehEvet;
                    STOCKCARDCLASSNAME11.ExpandTabs = EvetHayirEnum.ehEvet;
                    STOCKCARDCLASSNAME11.TextFont.Size = 11;
                    STOCKCARDCLASSNAME11.TextFont.Bold = true;
                    STOCKCARDCLASSNAME11.TextFont.CharSet = 162;
                    STOCKCARDCLASSNAME11.Value = @"Stok Kart Adı";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 41, 13, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.Value = @"{#STOCKCARDNSN#}";

                    CARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 11, 13, false);
                    CARDORDERNO.Name = "CARDORDERNO";
                    CARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CARDORDERNO.Value = @"{#STOCKCARDORDERNO#}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 8, 181, 13, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 13, 257, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 1, 283, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#STOCKCARD#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.ConsumableStockCardQuery_Class dataset_CSCQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.ConsumableStockCardQuery_Class>(0);
                    DISTRIBUTIONTYPE.CalcValue = (dataset_CSCQ != null ? Globals.ToStringCore(dataset_CSCQ.Stockcarddistributiontype) : "");
                    DISTRIBUTIONTYPE.PostFieldValueCalculation();
                    NewField1111.CalcValue = NewField1111.Value;
                    SIRANU.CalcValue = SIRANU.Value;
                    STOCKCARDCLASSCODE11.CalcValue = STOCKCARDCLASSCODE11.Value;
                    STOCKCARDCLASSNAME11.CalcValue = STOCKCARDCLASSNAME11.Value;
                    NSN.CalcValue = (dataset_CSCQ != null ? Globals.ToStringCore(dataset_CSCQ.Stockcardnsn) : "");
                    CARDORDERNO.CalcValue = (dataset_CSCQ != null ? Globals.ToStringCore(dataset_CSCQ.Stockcardorderno) : "");
                    STOCKCARDNAME.CalcValue = (dataset_CSCQ != null ? Globals.ToStringCore(dataset_CSCQ.Stockcardname) : "");
                    OBJECTID.CalcValue = (dataset_CSCQ != null ? Globals.ToStringCore(dataset_CSCQ.StockCard) : "");
                    return new TTReportObject[] { DISTRIBUTIONTYPE,NewField1111,SIRANU,STOCKCARDCLASSCODE11,STOCKCARDCLASSNAME11,NSN,CARDORDERNO,STOCKCARDNAME,OBJECTID};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField UNVISIBLETOTALCOST; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    UNVISIBLETOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 262, 5, false);
                    UNVISIBLETOTALCOST.Name = "UNVISIBLETOTALCOST";
                    UNVISIBLETOTALCOST.Visible = EvetHayirEnum.ehHayir;
                    UNVISIBLETOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVISIBLETOTALCOST.Value = @"{@sumof(TOTALCOST)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.ConsumableStockCardQuery_Class dataset_CSCQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.ConsumableStockCardQuery_Class>(0);
                    UNVISIBLETOTALCOST.CalcValue = ParentGroup.FieldSums["TOTALCOST"].Value.ToString();;
                    return new TTReportObject[] { UNVISIBLETOTALCOST};
                }
            }


            protected override bool RunScript()
            {
#region PARTD_Script
                if (((PARTCGroup)this.ParentGroup).REPORTTYPE.CalcValue == "DETAYSIZ")
                {
                    this.Header().Visible = EvetHayirEnum.ehHayir;
                    this.Footer().Visible = EvetHayirEnum.ehHayir;
                }
                else
                {
                    this.Header().Visible = EvetHayirEnum.ehEvet;
                    this.Footer().Visible = EvetHayirEnum.ehEvet;
                }
                return true;
#endregion PARTD_Script
            }
        }

        public PARTDGroup PARTD;

        public partial class PARTBGroup : TTReportGroup
        {
            public ConsumableMaterialForStore MyParentReport
            {
                get { return (ConsumableMaterialForStore)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField TOTALAMOUNT111 { get {return Footer().TOTALAMOUNT111;} }
            public TTReportField TOTALCOST { get {return Footer().TOTALCOST;} }
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
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 2, 39, 7, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"H. Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 2, 98, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Malzeme/İlaç Adı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 2, 209, 7, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Miktar";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 2, 64, 7, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Malzeme Kodu";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 2, 233, 7, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Size = 11;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Birim Fiyat";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 2, 257, 7, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122.TextFont.Size = 11;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"Maliyet";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    return new TTReportObject[] { NewField11111,NewField11,NewField121,NewField131,NewField1121,NewField1122};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField TOTALAMOUNT111;
                public TTReportField TOTALCOST; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALAMOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 1, 234, 6, false);
                    TOTALAMOUNT111.Name = "TOTALAMOUNT111";
                    TOTALAMOUNT111.TextFormat = @"#,##0.00";
                    TOTALAMOUNT111.TextFont.CharSet = 162;
                    TOTALAMOUNT111.Value = @"TOPLAM MALİYET :";

                    TOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 1, 257, 6, false);
                    TOTALCOST.Name = "TOTALCOST";
                    TOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOST.TextFormat = @"#,##0.00";
                    TOTALCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCOST.TextFont.CharSet = 162;
                    TOTALCOST.Value = @"{@sumof(COST)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTALAMOUNT111.CalcValue = TOTALAMOUNT111.Value;
                    TOTALCOST.CalcValue = ParentGroup.FieldSums["COST"].Value.ToString();;
                    return new TTReportObject[] { TOTALAMOUNT111,TOTALCOST};
                }
            }


            protected override bool RunScript()
            {
#region PARTB_Script
                if ( ((PARTCGroup)((PARTDGroup)this.ParentGroup).ParentGroup).REPORTTYPE.CalcValue == "DETAYSIZ")
                {
                    this.Header().Visible = EvetHayirEnum.ehHayir;
                    this.Footer().Visible = EvetHayirEnum.ehHayir;
                }
                else
                {
                    this.Header().Visible = EvetHayirEnum.ehEvet;
                    this.Footer().Visible = EvetHayirEnum.ehEvet;
                }
                return true;
#endregion PARTB_Script
            }
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ConsumableMaterialForStore MyParentReport
            {
                get { return (ConsumableMaterialForStore)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField MATERIALCODE { get {return Body().MATERIALCODE;} }
            public TTReportField COST { get {return Body().COST;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
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
                list[0] = new TTReportNqlData<StockTransaction.ConsumableMaterialForStoreQuery_Class>("CMFSQ", StockTransaction.ConsumableMaterialForStoreQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTD.OBJECTID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public ConsumableMaterialForStore MyParentReport
                {
                    get { return (ConsumableMaterialForStore)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportShape NewLine11;
                public TTReportField MATERIALCODE;
                public TTReportField COST;
                public TTReportField UNITPRICE;
                public TTReportField AMOUNT;
                public TTReportField TRANSACTIONDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 185, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 7, 257, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    MATERIALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 64, 6, false);
                    MATERIALCODE.Name = "MATERIALCODE";
                    MATERIALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCODE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCODE.Value = @"{#MATERIALCODE#}";

                    COST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 1, 257, 6, false);
                    COST.Name = "COST";
                    COST.FieldType = ReportFieldTypeEnum.ftVariable;
                    COST.TextFormat = @"#,##0.00";
                    COST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COST.TextFont.CharSet = 162;
                    COST.Value = @"{#TOTALPRICE#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 1, 233, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.00";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 1, 209, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 40, 6, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    TRANSACTIONDATE.Value = @"{#TRANSACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.ConsumableMaterialForStoreQuery_Class dataset_CMFSQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.ConsumableMaterialForStoreQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_CMFSQ != null ? Globals.ToStringCore(dataset_CMFSQ.Materialname) : "");
                    MATERIALCODE.CalcValue = (dataset_CMFSQ != null ? Globals.ToStringCore(dataset_CMFSQ.Materialcode) : "");
                    COST.CalcValue = (dataset_CMFSQ != null ? Globals.ToStringCore(dataset_CMFSQ.Totalprice) : "");
                    UNITPRICE.CalcValue = (dataset_CMFSQ != null ? Globals.ToStringCore(dataset_CMFSQ.UnitPrice) : "");
                    AMOUNT.CalcValue = (dataset_CMFSQ != null ? Globals.ToStringCore(dataset_CMFSQ.Amount) : "");
                    TRANSACTIONDATE.CalcValue = (dataset_CMFSQ != null ? Globals.ToStringCore(dataset_CMFSQ.TransactionDate) : "");
                    return new TTReportObject[] { MATERIALNAME,MATERIALCODE,COST,UNITPRICE,AMOUNT,TRANSACTIONDATE};
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (   ((PARTCGroup)((PARTDGroup)((PARTBGroup)this.ParentGroup).ParentGroup).ParentGroup).REPORTTYPE.CalcValue == "DETAYSIZ")
                {
                            this.Body().Visible = EvetHayirEnum.ehHayir;
                  
                 
                }
                else
                {
                    this.Body().Visible = EvetHayirEnum.ehEvet;
                   
                    
                }
                return true;
#endregion MAIN_Script
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsumableMaterialForStore()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTD = new PARTDGroup(PARTC,"PARTD");
            PARTB = new PARTBGroup(PARTD,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "", "Depo Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("CLASSID", "", "Stok Kart Sınıfı Seçiniz :", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
            reportParameter = Parameters.Add("REPORTTYPE", "0", "Detaylı Rapor :", @"", true, true, false, new Guid("d108cc72-9aa3-4981-9e05-90223eebc9db"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "23:59", "Bitiş Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("CLASSID"))
                _runtimeParameters.CLASSID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CLASSID"]);
            if (parameters.ContainsKey("REPORTTYPE"))
                _runtimeParameters.REPORTTYPE = (ReportType?)(int?)TTObjectDefManager.Instance.DataTypes["ReportType"].ConvertValue(parameters["REPORTTYPE"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "CONSUMABLEMATERIALFORSTORE";
            Caption = "Depolarda Sarf edilen Malzemeler";
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