
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
    /// Miad Tarihli Depo Mevcudu
    /// </summary>
    public partial class StockInHeldForStoreByExpirationDate : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockInHeldForStoreByExpirationDate MyParentReport
            {
                get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
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
            public TTReportField PrintDate1 { get {return Header().PrintDate1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
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
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO;
                public TTReportField PrintDate1;
                public TTReportField NewField1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 5, 180, 17, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"MİAD TARİHLİ DEPO MEVCUDU RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 19, 197, 24, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Bold = true;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 19, 173, 24, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Yazdırma Tarihi : ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { REPORTNAME,LOGO,PrintDate1,NewField1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
                }
                
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
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -2, 1, 23, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 1, 197, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 198, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PAGENUMBER,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public StockInHeldForStoreByExpirationDate MyParentReport
            {
                get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
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
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField STOCKNAME; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 22, 5, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Depo Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 27, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    STOCKNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 198, 5, false);
                    STOCKNAME.Name = "STOCKNAME";
                    STOCKNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKNAME.ObjectDefName = "Store";
                    STOCKNAME.DataMember = "NAME";
                    STOCKNAME.TextFont.Bold = true;
                    STOCKNAME.TextFont.CharSet = 162;
                    STOCKNAME.Value = @"{@STOREID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    STOCKNAME.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STOCKNAME.PostFieldValueCalculation();
                    return new TTReportObject[] { PARAMETERNAME1,NewField11,STOCKNAME};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
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
            public StockInHeldForStoreByExpirationDate MyParentReport
            {
                get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField MaterialTree { get {return Header().MaterialTree;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
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
                list[0] = new TTReportNqlData<StockTransaction.StockInHeldByExpirationDateRQ_Class>("StockInHeldByExpirationDateRQ", StockTransaction.StockInHeldByExpirationDateRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
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
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportShape NewLine1;
                public TTReportField NewField111;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField MaterialTree;
                public TTReportField NewField112; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 9, 205, 9, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.Visible = EvetHayirEnum.ehHayir;
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 10, 119, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İlaç/Malzeme Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 10, 135, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"D. Şekli";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 10, 179, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Mevcut";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 16, 205, 16, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 7, 15, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Sıra";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 10, 160, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Birim Fiyat";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 30, 15, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Barkod";

                    MaterialTree = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 150, 7, false);
                    MaterialTree.Name = "MaterialTree";
                    MaterialTree.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialTree.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MaterialTree.ObjectDefName = "MaterialTreeDefinition";
                    MaterialTree.DataMember = "NAME";
                    MaterialTree.TextFont.Name = "Arial";
                    MaterialTree.TextFont.Bold = true;
                    MaterialTree.TextFont.CharSet = 162;
                    MaterialTree.Value = @"{#MATERIALTREE#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 10, 205, 15, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"S.K.T";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.StockInHeldByExpirationDateRQ_Class dataset_StockInHeldByExpirationDateRQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.StockInHeldByExpirationDateRQ_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    MaterialTree.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.MaterialTree) : "");
                    MaterialTree.PostFieldValueCalculation();
                    NewField112.CalcValue = NewField112.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField111,NewField13,NewField131,MaterialTree,NewField112};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
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
            public StockInHeldForStoreByExpirationDate MyParentReport
            {
                get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField TOTALAMOUNT { get {return Body().TOTALAMOUNT;} }
            public TTReportField STOCKCARDORDERNO { get {return Body().STOCKCARDORDERNO;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField BARKODU { get {return Body().BARKODU;} }
            public TTReportField EXPIRATIONDATE { get {return Body().EXPIRATIONDATE;} }
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

                StockTransaction.StockInHeldByExpirationDateRQ_Class dataSet_StockInHeldByExpirationDateRQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.StockInHeldByExpirationDateRQ_Class>(0);    
                return new object[] {(dataSet_StockInHeldByExpirationDateRQ==null ? null : dataSet_StockInHeldByExpirationDateRQ.MaterialTree)};
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
                public StockInHeldForStoreByExpirationDate MyParentReport
                {
                    get { return (StockInHeldForStoreByExpirationDate)ParentReport; }
                }
                
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField STOCKCARDNAME;
                public TTReportField TOTALAMOUNT;
                public TTReportField STOCKCARDORDERNO;
                public TTReportShape NewLine1;
                public TTReportField UNITPRICE;
                public TTReportField BARKODU;
                public TTReportField EXPIRATIONDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 135, 6, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#PARTB.DISTRIBUTIONTYPE#}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 1, 119, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    STOCKCARDNAME.TextFont.Size = 9;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#PARTB.NAME#}";

                    TOTALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 180, 6, false);
                    TOTALAMOUNT.Name = "TOTALAMOUNT";
                    TOTALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT.TextFormat = @"#,##0.00";
                    TOTALAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALAMOUNT.TextFont.Size = 9;
                    TOTALAMOUNT.TextFont.CharSet = 162;
                    TOTALAMOUNT.Value = @"{#PARTB.RESTAMOUNT#}";

                    STOCKCARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 7, 6, false);
                    STOCKCARDORDERNO.Name = "STOCKCARDORDERNO";
                    STOCKCARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDORDERNO.TextFont.Size = 9;
                    STOCKCARDORDERNO.TextFont.CharSet = 162;
                    STOCKCARDORDERNO.Value = @"{@groupcounter@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 205, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 1, 159, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFont.Size = 9;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#PARTB.UNITPRICE#}";

                    BARKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 30, 6, false);
                    BARKODU.Name = "BARKODU";
                    BARKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARKODU.TextFont.Size = 9;
                    BARKODU.TextFont.CharSet = 162;
                    BARKODU.Value = @"{#PARTB.BARCODE#}";

                    EXPIRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 1, 205, 6, false);
                    EXPIRATIONDATE.Name = "EXPIRATIONDATE";
                    EXPIRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPIRATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXPIRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    EXPIRATIONDATE.Value = @"{#PARTB.EXPIRATIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.StockInHeldByExpirationDateRQ_Class dataset_StockInHeldByExpirationDateRQ = MyParentReport.PARTB.rsGroup.GetCurrentRecord<StockTransaction.StockInHeldByExpirationDateRQ_Class>(0);
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.DistributionType) : "");
                    DISTRIBUTIONTYPE.PostFieldValueCalculation();
                    STOCKCARDNAME.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.Name) : "");
                    TOTALAMOUNT.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.Restamount) : "");
                    STOCKCARDORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    UNITPRICE.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.UnitPrice) : "");
                    BARKODU.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.Barcode) : "");
                    EXPIRATIONDATE.CalcValue = (dataset_StockInHeldByExpirationDateRQ != null ? Globals.ToStringCore(dataset_StockInHeldByExpirationDateRQ.ExpirationDate) : "");
                    return new TTReportObject[] { DISTRIBUTIONTYPE,STOCKCARDNAME,TOTALAMOUNT,STOCKCARDORDERNO,UNITPRICE,BARKODU,EXPIRATIONDATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StockInHeldForStoreByExpirationDate()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            Name = "STOCKINHELDFORSTOREBYEXPIRATIONDATE";
            Caption = "Miad Tarihli Depo Mevcudu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 8;
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