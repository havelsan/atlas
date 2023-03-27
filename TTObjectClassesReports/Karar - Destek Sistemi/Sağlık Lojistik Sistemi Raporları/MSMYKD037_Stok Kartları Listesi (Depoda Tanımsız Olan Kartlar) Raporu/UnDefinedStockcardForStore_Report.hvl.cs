
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
    /// Stok Kartları Listesi (Depoda Tanımsız Olan Kartlar) Raporu
    /// </summary>
    public partial class UnDefinedStockcardForStore : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string STOCKCARDCLASSOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public UnDefinedStockcardForStore MyParentReport
            {
                get { return (UnDefinedStockcardForStore)ParentReport; }
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
                public UnDefinedStockcardForStore MyParentReport
                {
                    get { return (UnDefinedStockcardForStore)ParentReport; }
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
                    REPORTNAME.Value = @"STOK KARTLARI LİSTESİ (Depoda Tanımsız Olan Kartlar) RAPORU";

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
                public UnDefinedStockcardForStore MyParentReport
                {
                    get { return (UnDefinedStockcardForStore)ParentReport; }
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
            public UnDefinedStockcardForStore MyParentReport
            {
                get { return (UnDefinedStockcardForStore)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME121 { get {return Header().COLUMNNAME121;} }
            public TTReportField COLUMNNAME1121 { get {return Header().COLUMNNAME1121;} }
            public TTReportField COLUMNNAME12 { get {return Header().COLUMNNAME12;} }
            public TTReportField COLUMNNAME13 { get {return Header().COLUMNNAME13;} }
            public TTReportField PARAMETERNAME { get {return Header().PARAMETERNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PARAMETER { get {return Header().PARAMETER;} }
            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField PARAMETER1 { get {return Header().PARAMETER1;} }
            public TTReportField PARAMETER11 { get {return Header().PARAMETER11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
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
                public UnDefinedStockcardForStore MyParentReport
                {
                    get { return (UnDefinedStockcardForStore)ParentReport; }
                }
                
                public TTReportField COLUMNNAME121;
                public TTReportField COLUMNNAME1121;
                public TTReportField COLUMNNAME12;
                public TTReportField COLUMNNAME13;
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField PARAMETER;
                public TTReportField COLUMNNAME1;
                public TTReportField COLUMNNAME2;
                public TTReportShape NewLine1;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField PARAMETER1;
                public TTReportField PARAMETER11;
                public TTReportField NewField111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COLUMNNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 17, 224, 22, false);
                    COLUMNNAME121.Name = "COLUMNNAME121";
                    COLUMNNAME121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME121.TextFont.Size = 11;
                    COLUMNNAME121.TextFont.Bold = true;
                    COLUMNNAME121.TextFont.CharSet = 162;
                    COLUMNNAME121.Value = @"Dağıtım Şekli";

                    COLUMNNAME1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 17, 257, 22, false);
                    COLUMNNAME1121.Name = "COLUMNNAME1121";
                    COLUMNNAME1121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1121.TextFont.Size = 11;
                    COLUMNNAME1121.TextFont.Bold = true;
                    COLUMNNAME1121.TextFont.CharSet = 162;
                    COLUMNNAME1121.Value = @"Durumu";

                    COLUMNNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 17, 192, 22, false);
                    COLUMNNAME12.Name = "COLUMNNAME12";
                    COLUMNNAME12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME12.TextFont.Size = 11;
                    COLUMNNAME12.TextFont.Bold = true;
                    COLUMNNAME12.TextFont.CharSet = 162;
                    COLUMNNAME12.Value = @"Stok Kart Adı";

                    COLUMNNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 28, 22, false);
                    COLUMNNAME13.Name = "COLUMNNAME13";
                    COLUMNNAME13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME13.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME13.TextFont.Size = 11;
                    COLUMNNAME13.TextFont.Bold = true;
                    COLUMNNAME13.TextFont.CharSet = 162;
                    COLUMNNAME13.Value = @"Sıra Nu.";

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

                    PARAMETER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 206, 5, false);
                    PARAMETER.Name = "PARAMETER";
                    PARAMETER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER.ObjectDefName = "Store";
                    PARAMETER.DataMember = "NAME";
                    PARAMETER.TextFont.Bold = true;
                    PARAMETER.TextFont.CharSet = 162;
                    PARAMETER.Value = @"{@STOREOBJECTID@}";

                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 17, 7, 22, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1.TextFont.Size = 11;
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"Sıra";

                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 17, 59, 22, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME2.TextFont.Size = 11;
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Nato Stok Nu.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 22, 257, 22, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 29, 10, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Stok Kart Sınıfı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 5, 33, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    PARAMETER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 5, 206, 10, false);
                    PARAMETER1.Name = "PARAMETER1";
                    PARAMETER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER1.ObjectDefName = "StockCardClass";
                    PARAMETER1.DataMember = "NAME";
                    PARAMETER1.TextFont.Bold = true;
                    PARAMETER1.TextFont.CharSet = 162;
                    PARAMETER1.Value = @"{@STOCKCARDCLASSOBJECTID@}";

                    PARAMETER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 5, 41, 10, false);
                    PARAMETER11.Name = "PARAMETER11";
                    PARAMETER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER11.ObjectDefName = "StockCardClass";
                    PARAMETER11.DataMember = "CODE";
                    PARAMETER11.TextFont.Bold = true;
                    PARAMETER11.TextFont.CharSet = 162;
                    PARAMETER11.Value = @"{@STOCKCARDCLASSOBJECTID@}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 5, 46, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"/";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME121.CalcValue = COLUMNNAME121.Value;
                    COLUMNNAME1121.CalcValue = COLUMNNAME1121.Value;
                    COLUMNNAME12.CalcValue = COLUMNNAME12.Value;
                    COLUMNNAME13.CalcValue = COLUMNNAME13.Value;
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    PARAMETER.CalcValue = MyParentReport.RuntimeParameters.STOREOBJECTID.ToString();
                    PARAMETER.PostFieldValueCalculation();
                    COLUMNNAME1.CalcValue = COLUMNNAME1.Value;
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    PARAMETER1.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString();
                    PARAMETER1.PostFieldValueCalculation();
                    PARAMETER11.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID.ToString();
                    PARAMETER11.PostFieldValueCalculation();
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { COLUMNNAME121,COLUMNNAME1121,COLUMNNAME12,COLUMNNAME13,PARAMETERNAME,NewField1,PARAMETER,COLUMNNAME1,COLUMNNAME2,PARAMETERNAME1,NewField11,PARAMETER1,PARAMETER11,NewField111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public UnDefinedStockcardForStore MyParentReport
                {
                    get { return (UnDefinedStockcardForStore)ParentReport; }
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
            public UnDefinedStockcardForStore MyParentReport
            {
                get { return (UnDefinedStockcardForStore)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField CARDORDERNO { get {return Body().CARDORDERNO;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
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
                list[0] = new TTReportNqlData<StockCard.UndefinedStockCardForStore_Class>("UDSCFS", StockCard.UndefinedStockCardForStore((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSOBJECTID)));
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
                public UnDefinedStockcardForStore MyParentReport
                {
                    get { return (UnDefinedStockcardForStore)ParentReport; }
                }
                
                public TTReportField NSN;
                public TTReportField NewField1;
                public TTReportField CARDORDERNO;
                public TTReportField STATUS;
                public TTReportField STOCKCARDNAME;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 59, 6, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NATOSTOCKNO#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 7, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@counter@}";

                    CARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 28, 6, false);
                    CARDORDERNO.Name = "CARDORDERNO";
                    CARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CARDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CARDORDERNO.TextFont.CharSet = 162;
                    CARDORDERNO.Value = @"{#CARDORDERNO#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 1, 257, 6, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATUS.ObjectDefName = "StockCardStatusEnum";
                    STATUS.DataMember = "DISPLAYTEXT";
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"{#STATUS#}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 1, 192, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#NAME#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 1, 222, 6, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCard.UndefinedStockCardForStore_Class dataset_UDSCFS = ParentGroup.rsGroup.GetCurrentRecord<StockCard.UndefinedStockCardForStore_Class>(0);
                    NSN.CalcValue = (dataset_UDSCFS != null ? Globals.ToStringCore(dataset_UDSCFS.NATOStockNO) : "");
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    CARDORDERNO.CalcValue = (dataset_UDSCFS != null ? Globals.ToStringCore(dataset_UDSCFS.CardOrderNO) : "");
                    STATUS.CalcValue = (dataset_UDSCFS != null ? Globals.ToStringCore(dataset_UDSCFS.Status) : "");
                    STATUS.PostFieldValueCalculation();
                    STOCKCARDNAME.CalcValue = (dataset_UDSCFS != null ? Globals.ToStringCore(dataset_UDSCFS.Name) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_UDSCFS != null ? Globals.ToStringCore(dataset_UDSCFS.DistributionType) : "");
                    DISTRIBUTIONTYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { NSN,NewField1,CARDORDERNO,STATUS,STOCKCARDNAME,DISTRIBUTIONTYPE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public UnDefinedStockcardForStore()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREOBJECTID", "", "Depo Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STOCKCARDCLASSOBJECTID", "", "Stok Kart Sınıfı Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREOBJECTID"))
                _runtimeParameters.STOREOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREOBJECTID"]);
            if (parameters.ContainsKey("STOCKCARDCLASSOBJECTID"))
                _runtimeParameters.STOCKCARDCLASSOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDCLASSOBJECTID"]);
            Name = "UNDEFINEDSTOCKCARDFORSTORE";
            Caption = "Stok Kartları Listesi (Depoda Tanımsız Olan Kartlar) Raporu";
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