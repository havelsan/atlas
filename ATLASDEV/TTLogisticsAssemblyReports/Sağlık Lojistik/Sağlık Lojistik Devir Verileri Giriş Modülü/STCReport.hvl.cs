
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
    /// Sayım Tartı Çizelgesi
    /// </summary>
    public partial class STCReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string RESCARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public STCReport MyParentReport
            {
                get { return (STCReport)ParentReport; }
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
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 6, 275, 18, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"SAYIM TARTI ÇİZELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    return new TTReportObject[] { REPORTNAME};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PAGENUMBER;
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

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 1, 160, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 1, 274, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -3, 1, 275, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

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
            public STCReport MyParentReport
            {
                get { return (STCReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField RESCARDDRAWER { get {return Header().RESCARDDRAWER;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField1123 { get {return Header().NewField1123;} }
            public TTReportField NewField1124 { get {return Header().NewField1124;} }
            public TTReportField NewField1125 { get {return Header().NewField1125;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<STCAction.STCReportQuery_Class>("STCReportQuery2", STCAction.STCReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.RESCARDDRAWER)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                
                public TTReportField RESCARDDRAWER;
                public TTReportShape NewLine11111;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportShape NewLine11;
                public TTReportField NewField1111;
                public TTReportField NewField131;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField1123;
                public TTReportField NewField1124;
                public TTReportField NewField1125; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RESCARDDRAWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 158, 7, false);
                    RESCARDDRAWER.Name = "RESCARDDRAWER";
                    RESCARDDRAWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESCARDDRAWER.MultiLine = EvetHayirEnum.ehEvet;
                    RESCARDDRAWER.WordBreak = EvetHayirEnum.ehEvet;
                    RESCARDDRAWER.ExpandTabs = EvetHayirEnum.ehEvet;
                    RESCARDDRAWER.ObjectDefName = "ResCardDrawer";
                    RESCARDDRAWER.DataMember = "NAME";
                    RESCARDDRAWER.TextFont.Size = 11;
                    RESCARDDRAWER.TextFont.Bold = true;
                    RESCARDDRAWER.TextFont.CharSet = 162;
                    RESCARDDRAWER.Value = @"{#RESCARDDRAWER#}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 8, 274, 8, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 12, 59, 17, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Malzeme Adı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 12, 125, 17, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Dağıtım Şekli";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 12, 146, 17, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Yeni Mevcut";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 18, 274, 18, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 12, 8, 17, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Sıra";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 33, 17, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Nato Stok Nu.";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 12, 172, 17, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Kullanılmış Mev.";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 12, 194, 17, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"HEK Mevcut";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 12, 220, 17, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1123.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1123.TextFont.Bold = true;
                    NewField1123.TextFont.CharSet = 162;
                    NewField1123.Value = @"Muvakkaten Ver.";

                    NewField1124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 12, 244, 17, false);
                    NewField1124.Name = "NewField1124";
                    NewField1124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1124.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1124.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1124.TextFont.Bold = true;
                    NewField1124.TextFont.CharSet = 162;
                    NewField1124.Value = @"Toplam";

                    NewField1125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 12, 267, 17, false);
                    NewField1125.Name = "NewField1125";
                    NewField1125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1125.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1125.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1125.TextFont.Bold = true;
                    NewField1125.TextFont.CharSet = 162;
                    NewField1125.Value = @"Toplam Tutar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STCAction.STCReportQuery_Class dataset_STCReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<STCAction.STCReportQuery_Class>(0);
                    RESCARDDRAWER.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.ResCardDrawer) : "");
                    RESCARDDRAWER.PostFieldValueCalculation();
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    NewField1124.CalcValue = NewField1124.Value;
                    NewField1125.CalcValue = NewField1125.Value;
                    return new TTReportObject[] { RESCARDDRAWER,NewField11,NewField111,NewField121,NewField1111,NewField131,NewField1121,NewField1122,NewField1123,NewField1124,NewField1125};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public STCReport MyParentReport
            {
                get { return (STCReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField DISTRIBUTIONTYPE11 { get {return Header().DISTRIBUTIONTYPE11;} }
            public TTReportField MATERIALNAME1 { get {return Header().MATERIALNAME1;} }
            public TTReportField NEWAMOUNT1 { get {return Header().NEWAMOUNT1;} }
            public TTReportField STOCKCARDORDERNO11 { get {return Header().STOCKCARDORDERNO11;} }
            public TTReportField NSN11 { get {return Header().NSN11;} }
            public TTReportField USEDAMOUNT1 { get {return Header().USEDAMOUNT1;} }
            public TTReportField HEKAMOUNT1 { get {return Header().HEKAMOUNT1;} }
            public TTReportField CONSIGNEDAMOUNT1 { get {return Header().CONSIGNEDAMOUNT1;} }
            public TTReportField TOTALAMOUNT1 { get {return Header().TOTALAMOUNT1;} }
            public TTReportField TOTALPRICE1 { get {return Header().TOTALPRICE1;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField OBJECTID1 { get {return Header().OBJECTID1;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                STCAction.STCReportQuery_Class dataSet_STCReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<STCAction.STCReportQuery_Class>(0);    
                return new object[] {(dataSet_STCReportQuery2==null ? null : dataSet_STCReportQuery2.ResCardDrawer)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                
                public TTReportField DISTRIBUTIONTYPE11;
                public TTReportField MATERIALNAME1;
                public TTReportField NEWAMOUNT1;
                public TTReportField STOCKCARDORDERNO11;
                public TTReportField NSN11;
                public TTReportField USEDAMOUNT1;
                public TTReportField HEKAMOUNT1;
                public TTReportField CONSIGNEDAMOUNT1;
                public TTReportField TOTALAMOUNT1;
                public TTReportField TOTALPRICE1;
                public TTReportShape NewLine111;
                public TTReportField NewField111111;
                public TTReportField NewField11311;
                public TTReportShape NewLine1111;
                public TTReportField OBJECTID1; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DISTRIBUTIONTYPE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 125, 6, false);
                    DISTRIBUTIONTYPE11.Name = "DISTRIBUTIONTYPE11";
                    DISTRIBUTIONTYPE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE11.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE11.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE11.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE11.Value = @"{#PARTC.DISTRIBUTIONTYPE#}";

                    MATERIALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 104, 6, false);
                    MATERIALNAME1.Name = "MATERIALNAME1";
                    MATERIALNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME1.ExpandTabs = EvetHayirEnum.ehEvet;
                    MATERIALNAME1.TextFont.Bold = true;
                    MATERIALNAME1.TextFont.CharSet = 162;
                    MATERIALNAME1.Value = @"{#PARTC.NAME#}";

                    NEWAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 1, 146, 6, false);
                    NEWAMOUNT1.Name = "NEWAMOUNT1";
                    NEWAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWAMOUNT1.TextFormat = @"#,##0.00";
                    NEWAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWAMOUNT1.TextFont.CharSet = 162;
                    NEWAMOUNT1.Value = @"{#PARTC.YENIMEVCUT#}";

                    STOCKCARDORDERNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 8, 6, false);
                    STOCKCARDORDERNO11.Name = "STOCKCARDORDERNO11";
                    STOCKCARDORDERNO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDORDERNO11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOCKCARDORDERNO11.TextFont.Bold = true;
                    STOCKCARDORDERNO11.TextFont.CharSet = 162;
                    STOCKCARDORDERNO11.Value = @"{#PARTC.SIRANU#}";

                    NSN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 33, 6, false);
                    NSN11.Name = "NSN11";
                    NSN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN11.TextFont.Bold = true;
                    NSN11.TextFont.CharSet = 162;
                    NSN11.Value = @"{#PARTC.NATOSTOCKNO#}";

                    USEDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 1, 172, 6, false);
                    USEDAMOUNT1.Name = "USEDAMOUNT1";
                    USEDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDAMOUNT1.TextFormat = @"#,##0.00";
                    USEDAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    USEDAMOUNT1.TextFont.CharSet = 162;
                    USEDAMOUNT1.Value = @"{#PARTC.KULLANILMISMEVCUT#}";

                    HEKAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 1, 194, 6, false);
                    HEKAMOUNT1.Name = "HEKAMOUNT1";
                    HEKAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKAMOUNT1.TextFormat = @"#,##0.00";
                    HEKAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HEKAMOUNT1.TextFont.CharSet = 162;
                    HEKAMOUNT1.Value = @"{#PARTC.HEKMEVCUT#}";

                    CONSIGNEDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 1, 220, 6, false);
                    CONSIGNEDAMOUNT1.Name = "CONSIGNEDAMOUNT1";
                    CONSIGNEDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSIGNEDAMOUNT1.TextFormat = @"#,##0.00";
                    CONSIGNEDAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSIGNEDAMOUNT1.TextFont.CharSet = 162;
                    CONSIGNEDAMOUNT1.Value = @"{#PARTC.MUVAKKATENVERILEN#}";

                    TOTALAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 244, 6, false);
                    TOTALAMOUNT1.Name = "TOTALAMOUNT1";
                    TOTALAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT1.TextFormat = @"#,##0.00";
                    TOTALAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALAMOUNT1.TextFont.CharSet = 162;
                    TOTALAMOUNT1.Value = @"{#PARTC.TOPLAM#}";

                    TOTALPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 1, 267, 6, false);
                    TOTALPRICE1.Name = "TOTALPRICE1";
                    TOTALPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE1.TextFormat = @"#,##0.00";
                    TOTALPRICE1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE1.TextFont.CharSet = 162;
                    TOTALPRICE1.Value = @"{#PARTC.TOPLAMTUTAR#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 7, 274, 7, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 8, 193, 13, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Muvakkat Verilen Depo";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 8, 221, 13, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Muvakkat Miktarı";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 90, 13, 221, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 1, 326, 6, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.TextFormat = @"#,##0.00";
                    OBJECTID1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OBJECTID1.TextFont.CharSet = 162;
                    OBJECTID1.Value = @"{#PARTC.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STCAction.STCReportQuery_Class dataset_STCReportQuery2 = MyParentReport.PARTC.rsGroup.GetCurrentRecord<STCAction.STCReportQuery_Class>(0);
                    DISTRIBUTIONTYPE11.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.DistributionType) : "");
                    DISTRIBUTIONTYPE11.PostFieldValueCalculation();
                    MATERIALNAME1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.Name) : "");
                    NEWAMOUNT1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.YeniMevcut) : "");
                    STOCKCARDORDERNO11.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.SiraNu) : "");
                    NSN11.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.NATOStockNO) : "");
                    USEDAMOUNT1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.KullanilmisMevcut) : "");
                    HEKAMOUNT1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.HEKMevcut) : "");
                    CONSIGNEDAMOUNT1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.MuvakkatenVerilen) : "");
                    TOTALAMOUNT1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.Toplam) : "");
                    TOTALPRICE1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.ToplamTutar) : "");
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    OBJECTID1.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.ObjectID) : "");
                    return new TTReportObject[] { DISTRIBUTIONTYPE11,MATERIALNAME1,NEWAMOUNT1,STOCKCARDORDERNO11,NSN11,USEDAMOUNT1,HEKAMOUNT1,CONSIGNEDAMOUNT1,TOTALAMOUNT1,TOTALPRICE1,NewField111111,NewField11311,OBJECTID1};
                }

                public override void RunScript()
                {
#region PARTD HEADER_Script
                    if(OBJECTID1.CalcValue != "")
            {
                TTObjectContext readOnlyContext = new TTObjectContext(true);
                STCAction stcAction = (STCAction)readOnlyContext.GetObject(new Guid(OBJECTID1.CalcValue),"STCACTION");
                if(stcAction.MCActions.Count == 0)
                {
                    NewField111111.Visible = EvetHayirEnum.ehHayir;
                    NewField11311.Visible = EvetHayirEnum.ehHayir ;
                    NewLine1111.Visible = EvetHayirEnum.ehHayir ;
                }
                else
                {
                    NewField111111.Visible = EvetHayirEnum.ehEvet;
                    NewField11311.Visible = EvetHayirEnum.ehEvet ;
                    NewLine1111.Visible = EvetHayirEnum.ehEvet ;
                }
            }
#endregion PARTD HEADER_Script
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTBGroup : TTReportGroup
        {
            public STCReport MyParentReport
            {
                get { return (STCReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField MCSTORENAME { get {return Header().MCSTORENAME;} }
            public TTReportField MCCONSIGNEDAMOUNT { get {return Header().MCCONSIGNEDAMOUNT;} }
            public TTReportField SERINUMARASI { get {return Header().SERINUMARASI;} }
            public TTReportField MARKA { get {return Header().MARKA;} }
            public TTReportField MODEL { get {return Header().MODEL;} }
            public TTReportField GUC { get {return Header().GUC;} }
            public TTReportField FREKANS { get {return Header().FREKANS;} }
            public TTReportField VOLTAJ { get {return Header().VOLTAJ;} }
            public TTReportField GBASLANGIC { get {return Header().GBASLANGIC;} }
            public TTReportField GBITIS { get {return Header().GBITIS;} }
            public TTReportField SONKALIBRASYON { get {return Header().SONKALIBRASYON;} }
            public TTReportField SONBAKIM { get {return Header().SONBAKIM;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField STOREID { get {return Header().STOREID;} }
            public TTReportField OBJECTID11 { get {return Header().OBJECTID11;} }
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
                list[0] = new TTReportNqlData<MCAction.MCActionReportQuery_Class>("MCActionReportQuery", MCAction.MCActionReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTD.OBJECTID1.FormattedValue)));
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
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                
                public TTReportField MCSTORENAME;
                public TTReportField MCCONSIGNEDAMOUNT;
                public TTReportField SERINUMARASI;
                public TTReportField MARKA;
                public TTReportField MODEL;
                public TTReportField GUC;
                public TTReportField FREKANS;
                public TTReportField VOLTAJ;
                public TTReportField GBASLANGIC;
                public TTReportField GBITIS;
                public TTReportField SONKALIBRASYON;
                public TTReportField SONBAKIM;
                public TTReportShape NewLine11111;
                public TTReportField STOREID;
                public TTReportField OBJECTID11; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MCSTORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 1, 193, 6, false);
                    MCSTORENAME.Name = "MCSTORENAME";
                    MCSTORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MCSTORENAME.MultiLine = EvetHayirEnum.ehEvet;
                    MCSTORENAME.WordBreak = EvetHayirEnum.ehEvet;
                    MCSTORENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    MCSTORENAME.TextFont.CharSet = 162;
                    MCSTORENAME.Value = @"{#NAME#}";

                    MCCONSIGNEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 1, 221, 6, false);
                    MCCONSIGNEDAMOUNT.Name = "MCCONSIGNEDAMOUNT";
                    MCCONSIGNEDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MCCONSIGNEDAMOUNT.TextFormat = @"#,##0.00";
                    MCCONSIGNEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MCCONSIGNEDAMOUNT.TextFont.CharSet = 162;
                    MCCONSIGNEDAMOUNT.Value = @"{#MUVAKKATENVERILEN#}";

                    SERINUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 9, 62, 14, false);
                    SERINUMARASI.Name = "SERINUMARASI";
                    SERINUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERINUMARASI.TextFont.Bold = true;
                    SERINUMARASI.TextFont.CharSet = 162;
                    SERINUMARASI.Value = @"Seri Numarası";

                    MARKA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 9, 84, 14, false);
                    MARKA.Name = "MARKA";
                    MARKA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKA.TextFont.Bold = true;
                    MARKA.TextFont.CharSet = 162;
                    MARKA.Value = @"Marka";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 9, 106, 14, false);
                    MODEL.Name = "MODEL";
                    MODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MODEL.TextFont.Bold = true;
                    MODEL.TextFont.CharSet = 162;
                    MODEL.Value = @"Model";

                    GUC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 9, 128, 14, false);
                    GUC.Name = "GUC";
                    GUC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GUC.TextFont.Bold = true;
                    GUC.TextFont.CharSet = 162;
                    GUC.Value = @"Güç";

                    FREKANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 9, 150, 14, false);
                    FREKANS.Name = "FREKANS";
                    FREKANS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FREKANS.TextFont.Bold = true;
                    FREKANS.TextFont.CharSet = 162;
                    FREKANS.Value = @"Frekans";

                    VOLTAJ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 9, 172, 14, false);
                    VOLTAJ.Name = "VOLTAJ";
                    VOLTAJ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    VOLTAJ.TextFont.Bold = true;
                    VOLTAJ.TextFont.CharSet = 162;
                    VOLTAJ.Value = @"Voltaj";

                    GBASLANGIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 9, 194, 14, false);
                    GBASLANGIC.Name = "GBASLANGIC";
                    GBASLANGIC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GBASLANGIC.TextFont.Bold = true;
                    GBASLANGIC.TextFont.CharSet = 162;
                    GBASLANGIC.Value = @"G.Başlangıç";

                    GBITIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 9, 216, 14, false);
                    GBITIS.Name = "GBITIS";
                    GBITIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GBITIS.TextFont.Bold = true;
                    GBITIS.TextFont.CharSet = 162;
                    GBITIS.Value = @"G.Bitiş";

                    SONKALIBRASYON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 9, 242, 14, false);
                    SONKALIBRASYON.Name = "SONKALIBRASYON";
                    SONKALIBRASYON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SONKALIBRASYON.TextFont.Bold = true;
                    SONKALIBRASYON.TextFont.CharSet = 162;
                    SONKALIBRASYON.Value = @"Son Kalibrasyon";

                    SONBAKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 9, 265, 14, false);
                    SONBAKIM.Name = "SONBAKIM";
                    SONBAKIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SONBAKIM.TextFont.Bold = true;
                    SONBAKIM.TextFont.CharSet = 162;
                    SONBAKIM.Value = @"Son Bakım";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 14, 265, 14, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    STOREID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 5, 326, 10, false);
                    STOREID.Name = "STOREID";
                    STOREID.Visible = EvetHayirEnum.ehHayir;
                    STOREID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOREID.TextFormat = @"#,##0.00";
                    STOREID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOREID.TextFont.CharSet = 162;
                    STOREID.Value = @"{#STORE#}";

                    OBJECTID11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 331, 5, 356, 10, false);
                    OBJECTID11.Name = "OBJECTID11";
                    OBJECTID11.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID11.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID11.TextFormat = @"#,##0.00";
                    OBJECTID11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OBJECTID11.TextFont.CharSet = 162;
                    OBJECTID11.Value = @"{#PARTC.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MCAction.MCActionReportQuery_Class dataset_MCActionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MCAction.MCActionReportQuery_Class>(0);
                    STCAction.STCReportQuery_Class dataset_STCReportQuery2 = MyParentReport.PARTC.rsGroup.GetCurrentRecord<STCAction.STCReportQuery_Class>(0);
                    MCSTORENAME.CalcValue = (dataset_MCActionReportQuery != null ? Globals.ToStringCore(dataset_MCActionReportQuery.Name) : "");
                    MCCONSIGNEDAMOUNT.CalcValue = (dataset_MCActionReportQuery != null ? Globals.ToStringCore(dataset_MCActionReportQuery.MuvakkatenVerilen) : "");
                    SERINUMARASI.CalcValue = SERINUMARASI.Value;
                    MARKA.CalcValue = MARKA.Value;
                    MODEL.CalcValue = MODEL.Value;
                    GUC.CalcValue = GUC.Value;
                    FREKANS.CalcValue = FREKANS.Value;
                    VOLTAJ.CalcValue = VOLTAJ.Value;
                    GBASLANGIC.CalcValue = GBASLANGIC.Value;
                    GBITIS.CalcValue = GBITIS.Value;
                    SONKALIBRASYON.CalcValue = SONKALIBRASYON.Value;
                    SONBAKIM.CalcValue = SONBAKIM.Value;
                    STOREID.CalcValue = (dataset_MCActionReportQuery != null ? Globals.ToStringCore(dataset_MCActionReportQuery.Store) : "");
                    OBJECTID11.CalcValue = (dataset_STCReportQuery2 != null ? Globals.ToStringCore(dataset_STCReportQuery2.ObjectID) : "");
                    return new TTReportObject[] { MCSTORENAME,MCCONSIGNEDAMOUNT,SERINUMARASI,MARKA,MODEL,GUC,FREKANS,VOLTAJ,GBASLANGIC,GBITIS,SONKALIBRASYON,SONBAKIM,STOREID,OBJECTID11};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if(OBJECTID11.CalcValue != "")
            {
                TTObjectContext readOnlyContext = new TTObjectContext(true);
                STCAction stcAction = (STCAction)readOnlyContext.GetObject(new Guid(OBJECTID11.CalcValue),"STCACTION");
                if(stcAction.DCActions.Count == 0)
                {
                    NewLine11111.Visible = EvetHayirEnum.ehHayir;
                    SERINUMARASI.Visible = EvetHayirEnum.ehHayir;
                    MARKA.Visible = EvetHayirEnum.ehHayir;
                    MODEL.Visible = EvetHayirEnum.ehHayir;
                    GUC.Visible = EvetHayirEnum.ehHayir;
                    VOLTAJ.Visible = EvetHayirEnum.ehHayir;
                    FREKANS.Visible = EvetHayirEnum.ehHayir;
                    GBASLANGIC.Visible = EvetHayirEnum.ehHayir;
                    GBITIS.Visible = EvetHayirEnum.ehHayir;
                    SONBAKIM.Visible = EvetHayirEnum.ehHayir;
                    SONKALIBRASYON.Visible = EvetHayirEnum.ehHayir;
                }
                else
                {
                    NewLine11111.Visible = EvetHayirEnum.ehEvet;
                    SERINUMARASI.Visible = EvetHayirEnum.ehEvet;
                    MARKA.Visible = EvetHayirEnum.ehEvet;
                    MODEL.Visible = EvetHayirEnum.ehEvet;
                    GUC.Visible = EvetHayirEnum.ehEvet;
                    VOLTAJ.Visible = EvetHayirEnum.ehEvet;
                    FREKANS.Visible = EvetHayirEnum.ehEvet;
                    GBASLANGIC.Visible = EvetHayirEnum.ehEvet;
                    GBITIS.Visible = EvetHayirEnum.ehEvet;
                    SONBAKIM.Visible = EvetHayirEnum.ehEvet;
                    SONKALIBRASYON.Visible = EvetHayirEnum.ehEvet;
                }
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public STCReport MyParentReport
            {
                get { return (STCReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField POWER { get {return Body().POWER;} }
            public TTReportField FREKANS { get {return Body().FREKANS;} }
            public TTReportField VOLTAGE { get {return Body().VOLTAGE;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField LASTCALIBRATION { get {return Body().LASTCALIBRATION;} }
            public TTReportField LASTMAINTENANCE { get {return Body().LASTMAINTENANCE;} }
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
                list[0] = new TTReportNqlData<DCAction.DCActionReportQuery_Class>("DCActionReportQuery", DCAction.DCActionReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTD.OBJECTID1.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTB.STOREID.FormattedValue)));
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
                public STCReport MyParentReport
                {
                    get { return (STCReport)ParentReport; }
                }
                
                public TTReportField SERIALNO;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField POWER;
                public TTReportField FREKANS;
                public TTReportField VOLTAGE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField LASTCALIBRATION;
                public TTReportField LASTMAINTENANCE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 62, 6, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNO.WordBreak = EvetHayirEnum.ehEvet;
                    SERIALNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SERIALNO.TextFont.CharSet = 162;
                    SERIALNO.Value = @"{#SERINUMARASI#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 1, 84, 6, false);
                    MARK.Name = "MARK";
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.MultiLine = EvetHayirEnum.ehEvet;
                    MARK.WordBreak = EvetHayirEnum.ehEvet;
                    MARK.ExpandTabs = EvetHayirEnum.ehEvet;
                    MARK.TextFont.CharSet = 162;
                    MARK.Value = @"{#MARKA#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 1, 106, 6, false);
                    MODEL.Name = "MODEL";
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.MultiLine = EvetHayirEnum.ehEvet;
                    MODEL.WordBreak = EvetHayirEnum.ehEvet;
                    MODEL.ExpandTabs = EvetHayirEnum.ehEvet;
                    MODEL.TextFont.CharSet = 162;
                    MODEL.Value = @"{#MODEL#}";

                    POWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 128, 6, false);
                    POWER.Name = "POWER";
                    POWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    POWER.MultiLine = EvetHayirEnum.ehEvet;
                    POWER.WordBreak = EvetHayirEnum.ehEvet;
                    POWER.ExpandTabs = EvetHayirEnum.ehEvet;
                    POWER.TextFont.CharSet = 162;
                    POWER.Value = @"{#GUC#}";

                    FREKANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 150, 6, false);
                    FREKANS.Name = "FREKANS";
                    FREKANS.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREKANS.MultiLine = EvetHayirEnum.ehEvet;
                    FREKANS.WordBreak = EvetHayirEnum.ehEvet;
                    FREKANS.ExpandTabs = EvetHayirEnum.ehEvet;
                    FREKANS.TextFont.CharSet = 162;
                    FREKANS.Value = @"{#FREKANS#}";

                    VOLTAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 172, 6, false);
                    VOLTAGE.Name = "VOLTAGE";
                    VOLTAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VOLTAGE.MultiLine = EvetHayirEnum.ehEvet;
                    VOLTAGE.WordBreak = EvetHayirEnum.ehEvet;
                    VOLTAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    VOLTAGE.TextFont.CharSet = 162;
                    VOLTAGE.Value = @"{#VOLTAJ#}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 1, 194, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#GARANTIBASLANGICTARIHI#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 1, 216, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#GARANTIBITISTARIHI#}";

                    LASTCALIBRATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 1, 242, 6, false);
                    LASTCALIBRATION.Name = "LASTCALIBRATION";
                    LASTCALIBRATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTCALIBRATION.MultiLine = EvetHayirEnum.ehEvet;
                    LASTCALIBRATION.WordBreak = EvetHayirEnum.ehEvet;
                    LASTCALIBRATION.ExpandTabs = EvetHayirEnum.ehEvet;
                    LASTCALIBRATION.TextFont.CharSet = 162;
                    LASTCALIBRATION.Value = @"{#SONKALIBRASYONTARIHI#}";

                    LASTMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 1, 265, 6, false);
                    LASTMAINTENANCE.Name = "LASTMAINTENANCE";
                    LASTMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTMAINTENANCE.MultiLine = EvetHayirEnum.ehEvet;
                    LASTMAINTENANCE.WordBreak = EvetHayirEnum.ehEvet;
                    LASTMAINTENANCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    LASTMAINTENANCE.TextFont.CharSet = 162;
                    LASTMAINTENANCE.Value = @"{#SONBAKIMTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DCAction.DCActionReportQuery_Class dataset_DCActionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DCAction.DCActionReportQuery_Class>(0);
                    SERIALNO.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.SeriNumarasi) : "");
                    MARK.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.Marka) : "");
                    MODEL.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.Model) : "");
                    POWER.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.Guc) : "");
                    FREKANS.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.Frekans) : "");
                    VOLTAGE.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.Voltaj) : "");
                    STARTDATE.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.GarantiBaslangicTarihi) : "");
                    ENDDATE.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.GarantiBitisTarihi) : "");
                    LASTCALIBRATION.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.SonKalibrasyonTarihi) : "");
                    LASTMAINTENANCE.CalcValue = (dataset_DCActionReportQuery != null ? Globals.ToStringCore(dataset_DCActionReportQuery.SonBakimTarihi) : "");
                    return new TTReportObject[] { SERIALNO,MARK,MODEL,POWER,FREKANS,VOLTAGE,STARTDATE,ENDDATE,LASTCALIBRATION,LASTMAINTENANCE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public STCReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTD = new PARTDGroup(PARTC,"PARTD");
            PARTB = new PARTBGroup(PARTD,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("RESCARDDRAWER", "", "Saymanlık Masası", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("RESCARDDRAWER"))
                _runtimeParameters.RESCARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["RESCARDDRAWER"]);
            Name = "STCREPORT";
            Caption = "Sayım Tartı Çizelgesi";
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