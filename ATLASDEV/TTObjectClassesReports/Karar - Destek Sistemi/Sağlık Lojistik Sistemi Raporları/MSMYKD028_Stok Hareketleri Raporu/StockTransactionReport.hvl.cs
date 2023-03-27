
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
    /// Stok Hareketleri Raporu
    /// </summary>
    public partial class StockTransactionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string BUTGETTYPE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string STOCKCARDOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("23:59");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockTransactionReport MyParentReport
            {
                get { return (StockTransactionReport)ParentReport; }
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
                public StockTransactionReport MyParentReport
                {
                    get { return (StockTransactionReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 2, 173, 14, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"STOK HAREKETLERİ RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 23, 15, false);
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
                public StockTransactionReport MyParentReport
                {
                    get { return (StockTransactionReport)ParentReport; }
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

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 1, 97, 6, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 173, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 173, 1, false);
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
            public StockTransactionReport MyParentReport
            {
                get { return (StockTransactionReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME14 { get {return Header().COLUMNNAME14;} }
            public TTReportField COLUMNNAME13 { get {return Header().COLUMNNAME13;} }
            public TTReportField COLUMNNAME12 { get {return Header().COLUMNNAME12;} }
            public TTReportField PARAMETERNAME { get {return Header().PARAMETERNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField PARAMETERNAME2 { get {return Header().PARAMETERNAME2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField PARAMETERNAME3 { get {return Header().PARAMETERNAME3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField PARAMETERNAME4 { get {return Header().PARAMETERNAME4;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField PARAMETERNAME11 { get {return Header().PARAMETERNAME11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PARAMETERNAME12 { get {return Header().PARAMETERNAME12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField PARAMETERNAME13 { get {return Header().PARAMETERNAME13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField STOCKCARDNAME { get {return Header().STOCKCARDNAME;} }
            public TTReportField STOCKCARDORDERNO { get {return Header().STOCKCARDORDERNO;} }
            public TTReportField NSN { get {return Header().NSN;} }
            public TTReportField STOCKCARDCLASSNAME { get {return Header().STOCKCARDCLASSNAME;} }
            public TTReportField PARENTSTOCKCARDCLASSNAME { get {return Header().PARENTSTOCKCARDCLASSNAME;} }
            public TTReportField PRODUCTIONCHECKBOX { get {return Header().PRODUCTIONCHECKBOX;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField REPAIRCHECKBOX { get {return Header().REPAIRCHECKBOX;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField STOCKCARDCLASSCODE { get {return Header().STOCKCARDCLASSCODE;} }
            public TTReportField PARENTSTOCKCARDCLASSCODE { get {return Header().PARENTSTOCKCARDCLASSCODE;} }
            public TTReportField NewField1211111 { get {return Header().NewField1211111;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField BUTGETTYPE { get {return Header().BUTGETTYPE;} }
            public TTReportField REPORTNAME1 { get {return Footer().REPORTNAME1;} }
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
                public StockTransactionReport MyParentReport
                {
                    get { return (StockTransactionReport)ParentReport; }
                }
                
                public TTReportField COLUMNNAME14;
                public TTReportField COLUMNNAME13;
                public TTReportField COLUMNNAME12;
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField STORENAME;
                public TTReportField COLUMNNAME1;
                public TTReportField COLUMNNAME2;
                public TTReportShape NewLine1;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField PARAMETERNAME2;
                public TTReportField NewField12;
                public TTReportField PARAMETERNAME3;
                public TTReportField NewField13;
                public TTReportField PARAMETERNAME4;
                public TTReportField NewField14;
                public TTReportField PARAMETERNAME11;
                public TTReportField NewField111;
                public TTReportField PARAMETERNAME12;
                public TTReportField NewField121;
                public TTReportField PARAMETERNAME13;
                public TTReportField NewField131;
                public TTReportField STOCKCARDNAME;
                public TTReportField STOCKCARDORDERNO;
                public TTReportField NSN;
                public TTReportField STOCKCARDCLASSNAME;
                public TTReportField PARENTSTOCKCARDCLASSNAME;
                public TTReportField PRODUCTIONCHECKBOX;
                public TTReportField DATE;
                public TTReportField REPAIRCHECKBOX;
                public TTReportField NewField112;
                public TTReportField STOCKCARDCLASSCODE;
                public TTReportField PARENTSTOCKCARDCLASSCODE;
                public TTReportField NewField1211111;
                public TTReportField NewField113;
                public TTReportField BUTGETTYPE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COLUMNNAME14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 30, 171, 35, false);
                    COLUMNNAME14.Name = "COLUMNNAME14";
                    COLUMNNAME14.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME14.TextFont.Size = 11;
                    COLUMNNAME14.TextFont.Bold = true;
                    COLUMNNAME14.TextFont.CharSet = 162;
                    COLUMNNAME14.Value = @"Hareket Gören Depo";

                    COLUMNNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 30, 69, 35, false);
                    COLUMNNAME13.Name = "COLUMNNAME13";
                    COLUMNNAME13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME13.TextFont.Size = 11;
                    COLUMNNAME13.TextFont.Bold = true;
                    COLUMNNAME13.TextFont.CharSet = 162;
                    COLUMNNAME13.Value = @"Açıklama *";

                    COLUMNNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 30, 51, 35, false);
                    COLUMNNAME12.Name = "COLUMNNAME12";
                    COLUMNNAME12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME12.TextFont.Size = 11;
                    COLUMNNAME12.TextFont.Bold = true;
                    COLUMNNAME12.TextFont.CharSet = 162;
                    COLUMNNAME12.Value = @"H.Tipi";

                    PARAMETERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 37, 6, false);
                    PARAMETERNAME.Name = "PARAMETERNAME";
                    PARAMETERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME.TextFont.Bold = true;
                    PARAMETERNAME.TextFont.CharSet = 162;
                    PARAMETERNAME.Value = @"Depo Adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 41, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 173, 6, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORENAME.ObjectDefName = "Store";
                    STORENAME.DataMember = "NAME";
                    STORENAME.TextFont.Bold = true;
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{@STOREOBJECTID@}";

                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 30, 16, 35, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1.TextFont.Size = 11;
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"H.Tarihi";

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 30, 36, 35, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME2.TextFont.Size = 11;
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Miktar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 35, 171, 35, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 11, 37, 16, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Stok Kartı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 11, 41, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    PARAMETERNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 2, 250, 7, false);
                    PARAMETERNAME2.Name = "PARAMETERNAME2";
                    PARAMETERNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME2.TextFont.Bold = true;
                    PARAMETERNAME2.TextFont.CharSet = 162;
                    PARAMETERNAME2.Value = @"Sıra Nu.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 2, 254, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    PARAMETERNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 16, 37, 21, false);
                    PARAMETERNAME3.Name = "PARAMETERNAME3";
                    PARAMETERNAME3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME3.TextFont.Bold = true;
                    PARAMETERNAME3.TextFont.CharSet = 162;
                    PARAMETERNAME3.Value = @"Malzeme Kodu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 16, 41, 21, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    PARAMETERNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 7, 250, 12, false);
                    PARAMETERNAME4.Name = "PARAMETERNAME4";
                    PARAMETERNAME4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME4.TextFont.Bold = true;
                    PARAMETERNAME4.TextFont.CharSet = 162;
                    PARAMETERNAME4.Value = @"Sınıfı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 7, 254, 12, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 12, 250, 17, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Ana Sınıfı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 12, 254, 17, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    PARAMETERNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 17, 250, 22, false);
                    PARAMETERNAME12.Name = "PARAMETERNAME12";
                    PARAMETERNAME12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME12.TextFont.Bold = true;
                    PARAMETERNAME12.TextFont.CharSet = 162;
                    PARAMETERNAME12.Value = @"Reni";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 17, 254, 22, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    PARAMETERNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 21, 37, 26, false);
                    PARAMETERNAME13.Name = "PARAMETERNAME13";
                    PARAMETERNAME13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME13.TextFont.Bold = true;
                    PARAMETERNAME13.TextFont.CharSet = 162;
                    PARAMETERNAME13.Value = @"Başlangıç / Bitiş Tarihi";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 21, 41, 26, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 11, 173, 16, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.ObjectDefName = "StockCard";
                    STOCKCARDNAME.DataMember = "NAME";
                    STOCKCARDNAME.TextFont.Bold = true;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{@STOCKCARDOBJECTID@}";

                    STOCKCARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 2, 389, 7, false);
                    STOCKCARDORDERNO.Name = "STOCKCARDORDERNO";
                    STOCKCARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDORDERNO.ObjectDefName = "StockCard";
                    STOCKCARDORDERNO.DataMember = "CARDORDERNO";
                    STOCKCARDORDERNO.TextFont.Bold = true;
                    STOCKCARDORDERNO.TextFont.CharSet = 162;
                    STOCKCARDORDERNO.Value = @"{@STOCKCARDOBJECTID@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 16, 173, 21, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.ObjectDefName = "StockCard";
                    NSN.DataMember = "NATOSTOCKNO";
                    NSN.TextFont.Bold = true;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{@STOCKCARDOBJECTID@}";

                    STOCKCARDCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 7, 389, 12, false);
                    STOCKCARDCLASSNAME.Name = "STOCKCARDCLASSNAME";
                    STOCKCARDCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASSNAME.ObjectDefName = "StockCard";
                    STOCKCARDCLASSNAME.DataMember = "STOCKCARDCLASS.NAME";
                    STOCKCARDCLASSNAME.TextFont.Bold = true;
                    STOCKCARDCLASSNAME.TextFont.CharSet = 162;
                    STOCKCARDCLASSNAME.Value = @"{@STOCKCARDOBJECTID@}";

                    PARENTSTOCKCARDCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 12, 389, 17, false);
                    PARENTSTOCKCARDCLASSNAME.Name = "PARENTSTOCKCARDCLASSNAME";
                    PARENTSTOCKCARDCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARENTSTOCKCARDCLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARENTSTOCKCARDCLASSNAME.ObjectDefName = "StockCard";
                    PARENTSTOCKCARDCLASSNAME.DataMember = "STOCKCARDCLASS.PARENTSTOCKCARDCLASS.NAME";
                    PARENTSTOCKCARDCLASSNAME.TextFont.Bold = true;
                    PARENTSTOCKCARDCLASSNAME.TextFont.CharSet = 162;
                    PARENTSTOCKCARDCLASSNAME.Value = @"{@STOCKCARDOBJECTID@}";

                    PRODUCTIONCHECKBOX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 17, 273, 22, false);
                    PRODUCTIONCHECKBOX.Name = "PRODUCTIONCHECKBOX";
                    PRODUCTIONCHECKBOX.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTIONCHECKBOX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCTIONCHECKBOX.ObjectDefName = "StockCard";
                    PRODUCTIONCHECKBOX.DataMember = "PRODUCTIONCHECKBOX";
                    PRODUCTIONCHECKBOX.TextFont.Bold = true;
                    PRODUCTIONCHECKBOX.TextFont.CharSet = 162;
                    PRODUCTIONCHECKBOX.Value = @"{@STOCKCARDOBJECTID@}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 21, 173, 26, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Bold = true;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@STARTDATE@}  /  {@ENDDATE@}";

                    REPAIRCHECKBOX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 17, 307, 22, false);
                    REPAIRCHECKBOX.Name = "REPAIRCHECKBOX";
                    REPAIRCHECKBOX.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRCHECKBOX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPAIRCHECKBOX.ObjectDefName = "StockCard";
                    REPAIRCHECKBOX.DataMember = "REPAIRCHECKBOX";
                    REPAIRCHECKBOX.TextFont.Bold = true;
                    REPAIRCHECKBOX.TextFont.CharSet = 162;
                    REPAIRCHECKBOX.Value = @"{@STOCKCARDOBJECTID@}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 17, 275, 22, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"/";

                    STOCKCARDCLASSCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 7, 265, 12, false);
                    STOCKCARDCLASSCODE.Name = "STOCKCARDCLASSCODE";
                    STOCKCARDCLASSCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASSCODE.ObjectDefName = "StockCard";
                    STOCKCARDCLASSCODE.DataMember = "STOCKCARDCLASS.CODE";
                    STOCKCARDCLASSCODE.TextFont.Bold = true;
                    STOCKCARDCLASSCODE.TextFont.CharSet = 162;
                    STOCKCARDCLASSCODE.Value = @"{@STOCKCARDOBJECTID@}";

                    PARENTSTOCKCARDCLASSCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 12, 265, 17, false);
                    PARENTSTOCKCARDCLASSCODE.Name = "PARENTSTOCKCARDCLASSCODE";
                    PARENTSTOCKCARDCLASSCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARENTSTOCKCARDCLASSCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARENTSTOCKCARDCLASSCODE.ObjectDefName = "StockCard";
                    PARENTSTOCKCARDCLASSCODE.DataMember = "STOCKCARDCLASS.PARENTSTOCKCARDCLASS.CODE";
                    PARENTSTOCKCARDCLASSCODE.TextFont.Bold = true;
                    PARENTSTOCKCARDCLASSCODE.TextFont.CharSet = 162;
                    PARENTSTOCKCARDCLASSCODE.Value = @"{@STOCKCARDOBJECTID@}";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 6, 37, 11, false);
                    NewField1211111.Name = "NewField1211111";
                    NewField1211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211111.TextFont.Bold = true;
                    NewField1211111.TextFont.CharSet = 162;
                    NewField1211111.Value = @"Bütçe";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 6, 41, 11, false);
                    NewField113.Name = "NewField113";
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @":";

                    BUTGETTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 6, 173, 11, false);
                    BUTGETTYPE.Name = "BUTGETTYPE";
                    BUTGETTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTGETTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BUTGETTYPE.ObjectDefName = "BudgetTypeDefinition";
                    BUTGETTYPE.DataMember = "NAME";
                    BUTGETTYPE.TextFont.Bold = true;
                    BUTGETTYPE.TextFont.CharSet = 162;
                    BUTGETTYPE.Value = @"{@BUTGETTYPE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME14.CalcValue = COLUMNNAME14.Value;
                    COLUMNNAME13.CalcValue = COLUMNNAME13.Value;
                    COLUMNNAME12.CalcValue = COLUMNNAME12.Value;
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    STORENAME.CalcValue = MyParentReport.RuntimeParameters.STOREOBJECTID.ToString();
                    STORENAME.PostFieldValueCalculation();
                    COLUMNNAME1.CalcValue = COLUMNNAME1.Value;
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    PARAMETERNAME2.CalcValue = PARAMETERNAME2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    PARAMETERNAME3.CalcValue = PARAMETERNAME3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    PARAMETERNAME4.CalcValue = PARAMETERNAME4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    PARAMETERNAME11.CalcValue = PARAMETERNAME11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    PARAMETERNAME12.CalcValue = PARAMETERNAME12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    PARAMETERNAME13.CalcValue = PARAMETERNAME13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    STOCKCARDNAME.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    STOCKCARDNAME.PostFieldValueCalculation();
                    STOCKCARDORDERNO.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    STOCKCARDORDERNO.PostFieldValueCalculation();
                    NSN.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    NSN.PostFieldValueCalculation();
                    STOCKCARDCLASSNAME.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    STOCKCARDCLASSNAME.PostFieldValueCalculation();
                    PARENTSTOCKCARDCLASSNAME.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    PARENTSTOCKCARDCLASSNAME.PostFieldValueCalculation();
                    PRODUCTIONCHECKBOX.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    PRODUCTIONCHECKBOX.PostFieldValueCalculation();
                    DATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString() + @"  /  " + MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    REPAIRCHECKBOX.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    REPAIRCHECKBOX.PostFieldValueCalculation();
                    NewField112.CalcValue = NewField112.Value;
                    STOCKCARDCLASSCODE.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    STOCKCARDCLASSCODE.PostFieldValueCalculation();
                    PARENTSTOCKCARDCLASSCODE.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDOBJECTID.ToString();
                    PARENTSTOCKCARDCLASSCODE.PostFieldValueCalculation();
                    NewField1211111.CalcValue = NewField1211111.Value;
                    NewField113.CalcValue = NewField113.Value;
                    BUTGETTYPE.CalcValue = MyParentReport.RuntimeParameters.BUTGETTYPE.ToString();
                    BUTGETTYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { COLUMNNAME14,COLUMNNAME13,COLUMNNAME12,PARAMETERNAME,NewField1,STORENAME,COLUMNNAME1,COLUMNNAME2,PARAMETERNAME1,NewField11,PARAMETERNAME2,NewField12,PARAMETERNAME3,NewField13,PARAMETERNAME4,NewField14,PARAMETERNAME11,NewField111,PARAMETERNAME12,NewField121,PARAMETERNAME13,NewField131,STOCKCARDNAME,STOCKCARDORDERNO,NSN,STOCKCARDCLASSNAME,PARENTSTOCKCARDCLASSNAME,PRODUCTIONCHECKBOX,DATE,REPAIRCHECKBOX,NewField112,STOCKCARDCLASSCODE,PARENTSTOCKCARDCLASSCODE,NewField1211111,NewField113,BUTGETTYPE};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if(this.PRODUCTIONCHECKBOX.CalcValue=="True")
            {
            this.PRODUCTIONCHECKBOX.CalcValue="Sarf Edilir";
            }
            else if(this.PRODUCTIONCHECKBOX.CalcValue=="False")
            {
            this.PRODUCTIONCHECKBOX.CalcValue="Sarf Edilemez";
            }
            else{
            this.PRODUCTIONCHECKBOX.CalcValue="";
            }
            
            if(this.REPAIRCHECKBOX.CalcValue=="True")
            {
            this.REPAIRCHECKBOX.CalcValue="Tamir Edilir";
            }
            else if(this.REPAIRCHECKBOX.CalcValue=="False")
            {
            this.REPAIRCHECKBOX.CalcValue="Tamir Edilemez";
            }
            else{
            this.REPAIRCHECKBOX.CalcValue="";
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockTransactionReport MyParentReport
                {
                    get { return (StockTransactionReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 64;
                    RepeatCount = 0;
                    
                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 173, 64, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME1.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"*
DB   : Dağıtım Belgesi
DS   : Depodan Sarf
KÇ   : GİÇ Belgesi
İB   : İade Belgesi
SC   : Stok Çıkış
TMG  : Taşınır Mal İşlemi Giriş
TMS  : Taşınır Mal İşlemi Satın Alma Yoluyla
TMÇ  : Taşınır Mal İşlemi Çıkış
IF   : İhtiyaç Fazlası 
MUİ  : Miad Uzatım İşlemi
ADAT : Ana Depolar Arası Transfer
HIBE : Bağış Yardım Belgesi
HDAT : Servis Depolar Arası Transfer";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    return new TTReportObject[] { REPORTNAME1};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public StockTransactionReport MyParentReport
            {
                get { return (StockTransactionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public TTReportField INOUT { get {return Body().INOUT;} }
            public TTReportField SHORTDESCRIPTION { get {return Body().SHORTDESCRIPTION;} }
            public TTReportField TRANSACTIONSTORE { get {return Body().TRANSACTIONSTORE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField STR { get {return Body().STR;} }
            public TTReportField DSTR { get {return Body().DSTR;} }
            public TTReportField DSTROBJECTID { get {return Body().DSTROBJECTID;} }
            public TTReportField STROBJECTID { get {return Body().STROBJECTID;} }
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
                list[0] = new TTReportNqlData<StockTransaction.StockTransactionReportQuery_Class>("StockTransactionReportQuery", StockTransaction.StockTransactionReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDOBJECTID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.BUTGETTYPE)));
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
                public StockTransactionReport MyParentReport
                {
                    get { return (StockTransactionReport)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField TRANSACTIONDATE;
                public TTReportField INOUT;
                public TTReportField SHORTDESCRIPTION;
                public TTReportField TRANSACTIONSTORE;
                public TTReportShape NewLine1;
                public TTReportField STR;
                public TTReportField DSTR;
                public TTReportField DSTROBJECTID;
                public TTReportField STROBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 36, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 16, 5, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    TRANSACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{#TRANSACTIONDATE#}";

                    INOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 51, 5, false);
                    INOUT.Name = "INOUT";
                    INOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INOUT.ObjectDefName = "TransactionTypeEnum";
                    INOUT.DataMember = "DISPLAYTEXT";
                    INOUT.TextFont.CharSet = 162;
                    INOUT.Value = @"{#INOUT#}";

                    SHORTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 0, 69, 5, false);
                    SHORTDESCRIPTION.Name = "SHORTDESCRIPTION";
                    SHORTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHORTDESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SHORTDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHORTDESCRIPTION.TextFont.CharSet = 162;
                    SHORTDESCRIPTION.Value = @"{#SHORTDESCRIPTION#}";

                    TRANSACTIONSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 171, 5, false);
                    TRANSACTIONSTORE.Name = "TRANSACTIONSTORE";
                    TRANSACTIONSTORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONSTORE.TextFont.CharSet = 162;
                    TRANSACTIONSTORE.Value = @"NewField1";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 6, 171, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    STR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 7, 231, 12, false);
                    STR.Name = "STR";
                    STR.Visible = EvetHayirEnum.ehHayir;
                    STR.FieldType = ReportFieldTypeEnum.ftVariable;
                    STR.Value = @"{#STORE#}";

                    DSTR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 7, 223, 12, false);
                    DSTR.Name = "DSTR";
                    DSTR.Visible = EvetHayirEnum.ehHayir;
                    DSTR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DSTR.Value = @"{#DESTINATIONSTORE#}";

                    DSTROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 7, 255, 12, false);
                    DSTROBJECTID.Name = "DSTROBJECTID";
                    DSTROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DSTROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DSTROBJECTID.Value = @"{#DESTINATIONSTOREOBJECTID#}";

                    STROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 7, 282, 12, false);
                    STROBJECTID.Name = "STROBJECTID";
                    STROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STROBJECTID.Value = @"{@STOREOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.StockTransactionReportQuery_Class dataset_StockTransactionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.StockTransactionReportQuery_Class>(0);
                    AMOUNT.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.Amount) : "");
                    TRANSACTIONDATE.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.TransactionDate) : "");
                    INOUT.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.InOut) : "");
                    INOUT.PostFieldValueCalculation();
                    SHORTDESCRIPTION.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.ShortDescription) : "");
                    TRANSACTIONSTORE.CalcValue = TRANSACTIONSTORE.Value;
                    STR.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.Store) : "");
                    DSTR.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.Destinationstore) : "");
                    DSTROBJECTID.CalcValue = (dataset_StockTransactionReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionReportQuery.Destinationstoreobjectid) : "");
                    STROBJECTID.CalcValue = MyParentReport.RuntimeParameters.STOREOBJECTID.ToString();
                    return new TTReportObject[] { AMOUNT,TRANSACTIONDATE,INOUT,SHORTDESCRIPTION,TRANSACTIONSTORE,STR,DSTR,DSTROBJECTID,STROBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.DSTROBJECTID.CalcValue==this.STROBJECTID.CalcValue || this.DSTR.CalcValue=="" || this.DSTR.CalcValue == null)
            {
            this.TRANSACTIONSTORE.CalcValue=this.STR.CalcValue;
            }
            else{
            this.TRANSACTIONSTORE.CalcValue=this.DSTR.CalcValue;
            }
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

        public StockTransactionReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREOBJECTID", "", "Depo Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("BUTGETTYPE", "", "Bütçe Türü", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("fdeda53c-2161-46a5-92e3-01c98e1676e3");
            reportParameter = Parameters.Add("STOCKCARDOBJECTID", "", "Malzeme Seçin :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "23:59", "Bitiş Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREOBJECTID"))
                _runtimeParameters.STOREOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREOBJECTID"]);
            if (parameters.ContainsKey("BUTGETTYPE"))
                _runtimeParameters.BUTGETTYPE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["BUTGETTYPE"]);
            if (parameters.ContainsKey("STOCKCARDOBJECTID"))
                _runtimeParameters.STOCKCARDOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDOBJECTID"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "STOCKTRANSACTIONREPORT";
            Caption = "Stok Hareketleri Raporu";
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