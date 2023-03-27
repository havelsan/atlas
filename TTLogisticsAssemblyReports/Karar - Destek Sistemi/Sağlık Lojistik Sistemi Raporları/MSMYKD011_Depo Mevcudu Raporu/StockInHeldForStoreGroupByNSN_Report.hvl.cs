
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
    /// Depo Mevcudu Raporu (NSN Gruplu)
    /// </summary>
    public partial class StockInHeldForStoreGroupByNSN : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? CARDDRAWER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public bool? INCLUDEZEROAMOUNTS = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("false");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockInHeldForStoreGroupByNSN MyParentReport
            {
                get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
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
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 5, 164, 17, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"DEPO MEVCUDU RAPORU (NSN GRUPLU)";

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
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 26;
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

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 114, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 2, 189, 7, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 189, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PAGENUMBER.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PAGENUMBER,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public StockInHeldForStoreGroupByNSN MyParentReport
            {
                get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField STOCKNAME { get {return Header().STOCKNAME;} }
            public TTReportField PARAMETERNAME11 { get {return Header().PARAMETERNAME11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField STOCKID { get {return Header().STOCKID;} }
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
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField STOCKNAME;
                public TTReportField PARAMETERNAME11;
                public TTReportField NewField111;
                public TTReportField STOCKID; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 6, 22, 11, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Depo Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 6, 27, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    STOCKNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 6, 189, 11, false);
                    STOCKNAME.Name = "STOCKNAME";
                    STOCKNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKNAME.ObjectDefName = "Store";
                    STOCKNAME.DataMember = "NAME";
                    STOCKNAME.TextFont.Bold = true;
                    STOCKNAME.TextFont.CharSet = 162;
                    STOCKNAME.Value = @"{@STOREID@}";

                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 22, 5, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Depo Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 27, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    STOCKID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 189, 5, false);
                    STOCKID.Name = "STOCKID";
                    STOCKID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKID.ObjectDefName = "Store";
                    STOCKID.DataMember = "ID";
                    STOCKID.TextFont.Bold = true;
                    STOCKID.TextFont.CharSet = 162;
                    STOCKID.Value = @"{@STOREID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    STOCKNAME.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STOCKNAME.PostFieldValueCalculation();
                    PARAMETERNAME11.CalcValue = PARAMETERNAME11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    STOCKID.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STOCKID.PostFieldValueCalculation();
                    return new TTReportObject[] { PARAMETERNAME1,NewField11,STOCKNAME,PARAMETERNAME11,NewField111,STOCKID};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public StockInHeldForStoreGroupByNSN MyParentReport
            {
                get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField STOCKCARDCLASSCODE { get {return Header().STOCKCARDCLASSCODE;} }
            public TTReportField STOCKCARDCLASSNAME { get {return Header().STOCKCARDCLASSNAME;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField TOTALAMOUNT1 { get {return Footer().TOTALAMOUNT1;} }
            public TTReportField TOTALCONSIGNED1 { get {return Footer().TOTALCONSIGNED1;} }
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
                list[0] = new TTReportNqlData<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>("GetStockForStoreByCardDrawerNSNGroup", Stock.GetStockForStoreByCardDrawerNSNGroup((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER),(bool)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(MyParentReport.RuntimeParameters.INCLUDEZEROAMOUNTS),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
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
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                
                public TTReportField STOCKCARDCLASSCODE;
                public TTReportField STOCKCARDCLASSNAME;
                public TTReportShape NewLine1111;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportShape NewLine1;
                public TTReportField NewField121;
                public TTReportField NewField131; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STOCKCARDCLASSCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 36, 8, false);
                    STOCKCARDCLASSCODE.Name = "STOCKCARDCLASSCODE";
                    STOCKCARDCLASSCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSCODE.ObjectDefName = "StockCard";
                    STOCKCARDCLASSCODE.DataMember = "NATOSTOCKNO";
                    STOCKCARDCLASSCODE.TextFont.Bold = true;
                    STOCKCARDCLASSCODE.TextFont.CharSet = 162;
                    STOCKCARDCLASSCODE.Value = @"{#STOCKCARDOBJECTID#}";

                    STOCKCARDCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 189, 8, false);
                    STOCKCARDCLASSNAME.Name = "STOCKCARDCLASSNAME";
                    STOCKCARDCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSNAME.MultiLine = EvetHayirEnum.ehEvet;
                    STOCKCARDCLASSNAME.WordBreak = EvetHayirEnum.ehEvet;
                    STOCKCARDCLASSNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    STOCKCARDCLASSNAME.ObjectDefName = "StockCard";
                    STOCKCARDCLASSNAME.DataMember = "NAME";
                    STOCKCARDCLASSNAME.TextFont.Bold = true;
                    STOCKCARDCLASSNAME.TextFont.CharSet = 162;
                    STOCKCARDCLASSNAME.Value = @"{#STOCKCARDOBJECTID#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 9, 189, 9, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 10, 126, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İlaç/Malzeme/Demirbaş Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 10, 152, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Dağıtım Şekli";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 10, 170, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Mevcut";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 16, 189, 16, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 10, 189, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Muvakkat";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 27, 15, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Barkod";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetStockForStoreByCardDrawerNSNGroup_Class dataset_GetStockForStoreByCardDrawerNSNGroup = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>(0);
                    STOCKCARDCLASSCODE.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.Stockcardobjectid) : "");
                    STOCKCARDCLASSCODE.PostFieldValueCalculation();
                    STOCKCARDCLASSNAME.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.Stockcardobjectid) : "");
                    STOCKCARDCLASSNAME.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { STOCKCARDCLASSCODE,STOCKCARDCLASSNAME,NewField1,NewField11,NewField12,NewField121,NewField131};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                
                public TTReportField TOTALAMOUNT1;
                public TTReportField TOTALCONSIGNED1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TOTALAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 1, 170, 6, false);
                    TOTALAMOUNT1.Name = "TOTALAMOUNT1";
                    TOTALAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT1.TextFormat = @"#,##0.00";
                    TOTALAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALAMOUNT1.TextFont.CharSet = 162;
                    TOTALAMOUNT1.Value = @"{@sumof(TOTALAMOUNT)@}";

                    TOTALCONSIGNED1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 1, 189, 6, false);
                    TOTALCONSIGNED1.Name = "TOTALCONSIGNED1";
                    TOTALCONSIGNED1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCONSIGNED1.TextFormat = @"#,##0.00";
                    TOTALCONSIGNED1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCONSIGNED1.TextFont.CharSet = 162;
                    TOTALCONSIGNED1.Value = @"{@sumof(TOTALCONSIGNED)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetStockForStoreByCardDrawerNSNGroup_Class dataset_GetStockForStoreByCardDrawerNSNGroup = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>(0);
                    TOTALAMOUNT1.CalcValue = ParentGroup.FieldSums["TOTALAMOUNT"].Value.ToString();;
                    TOTALCONSIGNED1.CalcValue = ParentGroup.FieldSums["TOTALCONSIGNED"].Value.ToString();;
                    return new TTReportObject[] { TOTALAMOUNT1,TOTALCONSIGNED1};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public StockInHeldForStoreGroupByNSN MyParentReport
            {
                get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField TOTALAMOUNT { get {return Body().TOTALAMOUNT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField TOTALCONSIGNED { get {return Body().TOTALCONSIGNED;} }
            public TTReportField BARKODU { get {return Body().BARKODU;} }
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

                Stock.GetStockForStoreByCardDrawerNSNGroup_Class dataSet_GetStockForStoreByCardDrawerNSNGroup = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>(0);    
                return new object[] {(dataSet_GetStockForStoreByCardDrawerNSNGroup==null ? null : dataSet_GetStockForStoreByCardDrawerNSNGroup.Stockcardobjectid)};
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
                public StockInHeldForStoreGroupByNSN MyParentReport
                {
                    get { return (StockInHeldForStoreGroupByNSN)ParentReport; }
                }
                
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField STOCKCARDNAME;
                public TTReportField TOTALAMOUNT;
                public TTReportShape NewLine1;
                public TTReportField TOTALCONSIGNED;
                public TTReportField BARKODU; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 152, 6, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#PARTB.DISTRIBUTIONTYPE#}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 1, 127, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#PARTB.MATERIALNAME#}";

                    TOTALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 1, 170, 6, false);
                    TOTALAMOUNT.Name = "TOTALAMOUNT";
                    TOTALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT.TextFormat = @"#,##0.00";
                    TOTALAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALAMOUNT.TextFont.CharSet = 162;
                    TOTALAMOUNT.Value = @"{#PARTB.TOPLAMMIKTAR#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 189, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALCONSIGNED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 1, 189, 6, false);
                    TOTALCONSIGNED.Name = "TOTALCONSIGNED";
                    TOTALCONSIGNED.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCONSIGNED.TextFormat = @"#,##0.00";
                    TOTALCONSIGNED.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCONSIGNED.TextFont.CharSet = 162;
                    TOTALCONSIGNED.Value = @"{#PARTB.TOPLAMMUVAKKAT#}";

                    BARKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 27, 6, false);
                    BARKODU.Name = "BARKODU";
                    BARKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARKODU.Value = @"{#PARTB.BARKOD#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetStockForStoreByCardDrawerNSNGroup_Class dataset_GetStockForStoreByCardDrawerNSNGroup = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Stock.GetStockForStoreByCardDrawerNSNGroup_Class>(0);
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.DistributionType) : "");
                    DISTRIBUTIONTYPE.PostFieldValueCalculation();
                    STOCKCARDNAME.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.Materialname) : "");
                    TOTALAMOUNT.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.Toplammiktar) : "");
                    TOTALCONSIGNED.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.Toplammuvakkat) : "");
                    BARKODU.CalcValue = (dataset_GetStockForStoreByCardDrawerNSNGroup != null ? Globals.ToStringCore(dataset_GetStockForStoreByCardDrawerNSNGroup.Barkod) : "");
                    return new TTReportObject[] { DISTRIBUTIONTYPE,STOCKCARDNAME,TOTALAMOUNT,TOTALCONSIGNED,BARKODU};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if((bool)MyParentReport.RuntimeParameters.INCLUDEZEROAMOUNTS.Value == true)
                return;
            
            if(TOTALAMOUNT.CalcValue.ToString() == "0")
                this.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            else
                this.Visible = TTReportTool.EvetHayirEnum.ehEvet;
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

        public StockInHeldForStoreGroupByNSN()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("CARDDRAWER", "00000000-0000-0000-0000-000000000000", "Saymanlık Masası :", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
            reportParameter = Parameters.Add("INCLUDEZEROAMOUNTS", "false", "Sıfır Mevcutluları Göster", @"", false, true, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("CARDDRAWER"))
                _runtimeParameters.CARDDRAWER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CARDDRAWER"]);
            if (parameters.ContainsKey("INCLUDEZEROAMOUNTS"))
                _runtimeParameters.INCLUDEZEROAMOUNTS = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["INCLUDEZEROAMOUNTS"]);
            Name = "STOCKINHELDFORSTOREGROUPBYNSN";
            Caption = "Depo Mevcudu Raporu (NSN Gruplu)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 15;
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