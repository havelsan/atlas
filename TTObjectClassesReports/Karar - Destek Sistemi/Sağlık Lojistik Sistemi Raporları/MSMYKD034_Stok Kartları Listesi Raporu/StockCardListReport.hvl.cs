
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
    /// Stok Kartları Listesi Raporu
    /// </summary>
    public partial class StockCardListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public StockCardStatusEnum? STATUS = (StockCardStatusEnum?)(int?)TTObjectDefManager.Instance.DataTypes["StockCardStatusEnum"].ConvertValue("0");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockCardListReport MyParentReport
            {
                get { return (StockCardListReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"STOK KARTLARI LİSTESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    return new TTReportObject[] { LOGO,ReportName};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine1; 
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
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 95, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

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
            public StockCardListReport MyParentReport
            {
                get { return (StockCardListReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField MAINCLASSNAME { get {return Header().MAINCLASSNAME;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
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
                list[0] = new TTReportNqlData<Material.GetStockCardListReportQuery_Class>("GetStockCardListReportQuery", Material.GetStockCardListReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.OBJECTID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STATUS)));
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
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                
                public TTReportField MAINCLASSNAME;
                public TTReportField NewField1111;
                public TTReportField NewField11; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MAINCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 170, 6, false);
                    MAINCLASSNAME.Name = "MAINCLASSNAME";
                    MAINCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINCLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAINCLASSNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME.TextFont.Name = "Arial";
                    MAINCLASSNAME.TextFont.CharSet = 162;
                    MAINCLASSNAME.Value = @"{#MAINCLASS#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 31, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 30, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ana Sınıfı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListReportQuery_Class dataset_GetStockCardListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);
                    MAINCLASSNAME.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.Mainclass) : "");
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { MAINCLASSNAME,NewField1111,NewField11};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
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

        public partial class PARTDGroup : TTReportGroup
        {
            public StockCardListReport MyParentReport
            {
                get { return (StockCardListReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField CLASSNAME { get {return Header().CLASSNAME;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
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

                Material.GetStockCardListReportQuery_Class dataSet_GetStockCardListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);    
                return new object[] {(dataSet_GetStockCardListReportQuery==null ? null : dataSet_GetStockCardListReportQuery.Mainclass)};
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
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                
                public TTReportField CLASSNAME;
                public TTReportField NewField1111;
                public TTReportField NewField111111; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    CLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 170, 6, false);
                    CLASSNAME.Name = "CLASSNAME";
                    CLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLASSNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CLASSNAME.TextFont.Name = "Arial";
                    CLASSNAME.TextFont.CharSet = 162;
                    CLASSNAME.Value = @"{#PARTC.CLASSNAME#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 30, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Sınıfı";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 31, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListReportQuery_Class dataset_GetStockCardListReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);
                    CLASSNAME.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.Classname) : "");
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { CLASSNAME,NewField1111,NewField111111};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTBGroup : TTReportGroup
        {
            public StockCardListReport MyParentReport
            {
                get { return (StockCardListReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField11122 { get {return Header().NewField11122;} }
            public TTReportField NewField11123 { get {return Header().NewField11123;} }
            public TTReportField NewField11124 { get {return Header().NewField11124;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField MAINMATERIALNAME { get {return Header().MAINMATERIALNAME;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Material.GetStockCardListReportQuery_Class dataSet_GetStockCardListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);    
                return new object[] {(dataSet_GetStockCardListReportQuery==null ? null : dataSet_GetStockCardListReportQuery.Mainclass), (dataSet_GetStockCardListReportQuery==null ? null : dataSet_GetStockCardListReportQuery.Classname)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField11121;
                public TTReportField NewField11122;
                public TTReportField NewField11123;
                public TTReportField NewField11124;
                public TTReportShape NewLine1;
                public TTReportField NewField1;
                public TTReportField NewField111111;
                public TTReportField MAINMATERIALNAME; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 9, 7, 14, false);
                    NewField112.Name = "NewField112";
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Sıra";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 18, 14, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"S. Nu.";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 9, 45, 14, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"NATO Stok Nu.";

                    NewField11122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 9, 136, 14, false);
                    NewField11122.Name = "NewField11122";
                    NewField11122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11122.TextFont.Name = "Arial";
                    NewField11122.TextFont.Bold = true;
                    NewField11122.TextFont.CharSet = 162;
                    NewField11122.Value = @"Malzeme İsmi";

                    NewField11123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 9, 159, 14, false);
                    NewField11123.Name = "NewField11123";
                    NewField11123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11123.TextFont.Name = "Arial";
                    NewField11123.TextFont.Bold = true;
                    NewField11123.TextFont.CharSet = 162;
                    NewField11123.Value = @"Kart Statüsü";

                    NewField11124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 9, 170, 14, false);
                    NewField11124.Name = "NewField11124";
                    NewField11124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11124.TextFont.Name = "Arial";
                    NewField11124.TextFont.Bold = true;
                    NewField11124.TextFont.CharSet = 162;
                    NewField11124.Value = @"Depo";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 14, 170, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 30, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Malzeme Grubu";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 31, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @":";

                    MAINMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 170, 6, false);
                    MAINMATERIALNAME.Name = "MAINMATERIALNAME";
                    MAINMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINMATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAINMATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MAINMATERIALNAME.TextFont.Name = "Arial";
                    MAINMATERIALNAME.TextFont.CharSet = 162;
                    MAINMATERIALNAME.Value = @"{#PARTC.MAINMATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListReportQuery_Class dataset_GetStockCardListReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField11122.CalcValue = NewField11122.Value;
                    NewField11123.CalcValue = NewField11123.Value;
                    NewField11124.CalcValue = NewField11124.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    MAINMATERIALNAME.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.Mainmaterialname) : "");
                    return new TTReportObject[] { NewField112,NewField1211,NewField11121,NewField11122,NewField11123,NewField11124,NewField1,NewField111111,MAINMATERIALNAME};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
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
            public StockCardListReport MyParentReport
            {
                get { return (StockCardListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CARDORDERNO { get {return Body().CARDORDERNO;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField StoreName { get {return Body().StoreName;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField Store { get {return Body().Store;} }
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

                Material.GetStockCardListReportQuery_Class dataSet_GetStockCardListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);    
                return new object[] {(dataSet_GetStockCardListReportQuery==null ? null : dataSet_GetStockCardListReportQuery.Mainclass), (dataSet_GetStockCardListReportQuery==null ? null : dataSet_GetStockCardListReportQuery.Classname), (dataSet_GetStockCardListReportQuery==null ? null : dataSet_GetStockCardListReportQuery.Mainmaterialname)};
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
                public StockCardListReport MyParentReport
                {
                    get { return (StockCardListReport)ParentReport; }
                }
                
                public TTReportField CARDORDERNO;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALNAME;
                public TTReportField STATUS;
                public TTReportField StoreName;
                public TTReportShape NewLine1;
                public TTReportField COUNTER;
                public TTReportField Store; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    CARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 18, 6, false);
                    CARDORDERNO.Name = "CARDORDERNO";
                    CARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CARDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CARDORDERNO.TextFont.Name = "Arial";
                    CARDORDERNO.TextFont.CharSet = 162;
                    CARDORDERNO.Value = @"{#PARTC.CARDORDERNO#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 45, 6, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#PARTC.NATOSTOCKNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 136, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#PARTC.MATERIALNAME#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 1, 159, 6, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATUS.ObjectDefName = "StockCardStatusEnum";
                    STATUS.DataMember = "DISPLAYTEXT";
                    STATUS.TextFont.Name = "Arial";
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"{#PARTC.STATUS#}";

                    StoreName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 2, 228, 7, false);
                    StoreName.Name = "StoreName";
                    StoreName.Visible = EvetHayirEnum.ehHayir;
                    StoreName.FieldType = ReportFieldTypeEnum.ftVariable;
                    StoreName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    StoreName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StoreName.TextFont.CharSet = 162;
                    StoreName.Value = @"{#PARTC.STORENAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 7, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.Name = "Arial";
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@}";

                    Store = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 170, 6, false);
                    Store.Name = "Store";
                    Store.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Store.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Store.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListReportQuery_Class dataset_GetStockCardListReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<Material.GetStockCardListReportQuery_Class>(0);
                    CARDORDERNO.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.CardOrderNO) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.NATOStockNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.Materialname) : "");
                    STATUS.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.Status) : "");
                    STATUS.PostFieldValueCalculation();
                    StoreName.CalcValue = (dataset_GetStockCardListReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListReportQuery.Storename) : "");
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    Store.CalcValue = Store.Value;
                    return new TTReportObject[] { CARDORDERNO,NATOSTOCKNO,MATERIALNAME,STATUS,StoreName,COUNTER,Store};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.StoreName.CalcValue.ToString() != "")
            {
                this.Store.CalcValue = "X";
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

        public StockCardListReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTD = new PARTDGroup(PARTC,"PARTD");
            PARTB = new PARTBGroup(PARTD,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "Stok Kart Sınıfını Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
            reportParameter = Parameters.Add("STATUS", "0", "Kart Statüsünü Giriniz", @"", true, true, false, new Guid("a4b05482-f11e-4094-80bd-ef386b82e3e3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            if (parameters.ContainsKey("STATUS"))
                _runtimeParameters.STATUS = (StockCardStatusEnum?)(int?)TTObjectDefManager.Instance.DataTypes["StockCardStatusEnum"].ConvertValue(parameters["STATUS"]);
            Name = "STOCKCARDLISTREPORT";
            Caption = "Stok Kartları Listesi Raporu";
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