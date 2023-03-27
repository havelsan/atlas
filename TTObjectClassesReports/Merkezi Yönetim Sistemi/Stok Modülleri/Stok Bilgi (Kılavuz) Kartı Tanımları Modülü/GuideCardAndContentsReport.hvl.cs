
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
    public partial class GuideCardAndContentsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public GuideCardAndContentsReport MyParentReport
            {
                get { return (GuideCardAndContentsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField CURRENTUSER1 { get {return Footer().CURRENTUSER1;} }
            public TTReportField PAGENUMBER1 { get {return Footer().PAGENUMBER1;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public GuideCardAndContentsReport MyParentReport
                {
                    get { return (GuideCardAndContentsReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 4, 155, 16, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Size = 15;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"KILAVUZ KART MEVCUDU RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    return new TTReportObject[] { REPORTNAME1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public GuideCardAndContentsReport MyParentReport
                {
                    get { return (GuideCardAndContentsReport)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField CURRENTUSER1;
                public TTReportField PAGENUMBER1;
                public TTReportShape NewLine111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 31, 7, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    CURRENTUSER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 2, 113, 7, false);
                    CURRENTUSER1.Name = "CURRENTUSER1";
                    CURRENTUSER1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER1.TextFont.Size = 8;
                    CURRENTUSER1.TextFont.CharSet = 162;
                    CURRENTUSER1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 2, 202, 7, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1.TextFont.Size = 8;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 202, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PAGENUMBER1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PAGENUMBER1,CURRENTUSER1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public GuideCardAndContentsReport MyParentReport
            {
                get { return (GuideCardAndContentsReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField PARAMETERNAME111 { get {return Header().PARAMETERNAME111;} }
            public TTReportField STOCKNAME11 { get {return Header().STOCKNAME11;} }
            public TTReportField PARAMETERNAME1111 { get {return Header().PARAMETERNAME1111;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
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
                list[0] = new TTReportNqlData<StockGuideCard.GetStockGuideCardDetailsRpt_Class>("GetStockGuideCardDetailsRpt", StockGuideCard.GetStockGuideCardDetailsRpt((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public GuideCardAndContentsReport MyParentReport
                {
                    get { return (GuideCardAndContentsReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportShape NewLine11;
                public TTReportField NewField1111;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField PARAMETERNAME111;
                public TTReportField STOCKNAME11;
                public TTReportField PARAMETERNAME1111;
                public TTReportField STORENAME; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 16, 202, 16, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 18, 184, 23, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İlaç/Malzeme/Demirbaş Adı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 18, 202, 23, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Mevcut";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 24, 202, 24, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 18, 13, 23, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Sıra";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 18, 37, 23, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Nato Stok Nu.";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 18, 68, 23, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Barkod";

                    PARAMETERNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 10, 32, 15, false);
                    PARAMETERNAME111.Name = "PARAMETERNAME111";
                    PARAMETERNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME111.TextFont.Bold = true;
                    PARAMETERNAME111.TextFont.CharSet = 162;
                    PARAMETERNAME111.Value = @"Kılavuz Kart Adı";

                    STOCKNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 10, 202, 15, false);
                    STOCKNAME11.Name = "STOCKNAME11";
                    STOCKNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKNAME11.ObjectDefName = "StockGuideCard";
                    STOCKNAME11.DataMember = "NAME";
                    STOCKNAME11.TextFont.Bold = true;
                    STOCKNAME11.TextFont.CharSet = 162;
                    STOCKNAME11.Value = @"{#OBJECTID#}";

                    PARAMETERNAME1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 3, 32, 8, false);
                    PARAMETERNAME1111.Name = "PARAMETERNAME1111";
                    PARAMETERNAME1111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1111.TextFont.Bold = true;
                    PARAMETERNAME1111.TextFont.CharSet = 162;
                    PARAMETERNAME1111.Value = @"Depo Adı";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 3, 201, 8, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORENAME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockGuideCard.GetStockGuideCardDetailsRpt_Class dataset_GetStockGuideCardDetailsRpt = ParentGroup.rsGroup.GetCurrentRecord<StockGuideCard.GetStockGuideCardDetailsRpt_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    PARAMETERNAME111.CalcValue = PARAMETERNAME111.Value;
                    STOCKNAME11.CalcValue = (dataset_GetStockGuideCardDetailsRpt != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetailsRpt.ObjectID) : "");
                    STOCKNAME11.PostFieldValueCalculation();
                    PARAMETERNAME1111.CalcValue = PARAMETERNAME1111.Value;
                    STORENAME.CalcValue = STORENAME.Value;
                    return new TTReportObject[] { NewField11,NewField121,NewField1111,NewField131,NewField1131,PARAMETERNAME111,STOCKNAME11,PARAMETERNAME1111,STORENAME};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string objectid = ((GuideCardAndContentsReport)ParentReport).RuntimeParameters.STORE.ToString();
                    Store store = (Store)this.ParentReport.ReportObjectContext.GetObject(new Guid(objectid), "STORE");
                    this.STORENAME.CalcValue = store.Name;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public GuideCardAndContentsReport MyParentReport
                {
                    get { return (GuideCardAndContentsReport)ParentReport; }
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
            public GuideCardAndContentsReport MyParentReport
            {
                get { return (GuideCardAndContentsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRA { get {return Body().SIRA;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField BARKOD { get {return Body().BARKOD;} }
            public TTReportField DETAY { get {return Body().DETAY;} }
            public TTReportField MEVCUT { get {return Body().MEVCUT;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
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

                StockGuideCard.GetStockGuideCardDetailsRpt_Class dataSet_GetStockGuideCardDetailsRpt = ParentGroup.rsGroup.GetCurrentRecord<StockGuideCard.GetStockGuideCardDetailsRpt_Class>(0);    
                return new object[] {(dataSet_GetStockGuideCardDetailsRpt==null ? null : dataSet_GetStockGuideCardDetailsRpt.ObjectID)};
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
                public GuideCardAndContentsReport MyParentReport
                {
                    get { return (GuideCardAndContentsReport)ParentReport; }
                }
                
                public TTReportField SIRA;
                public TTReportField NSN;
                public TTReportField BARKOD;
                public TTReportField DETAY;
                public TTReportField MEVCUT;
                public TTReportShape NewLine111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 13, 6, false);
                    SIRA.Name = "SIRA";
                    SIRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRA.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SIRA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRA.Value = @"{@counter@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 37, 6, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.Value = @"{#PARTB.NSNNO#}";

                    BARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 68, 6, false);
                    BARKOD.Name = "BARKOD";
                    BARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BARKOD.ObjectDefName = "Material";
                    BARKOD.DataMember = "BARCODE";
                    BARKOD.Value = @"{#PARTB.MATERIALNAME#}";

                    DETAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 1, 184, 6, false);
                    DETAY.Name = "DETAY";
                    DETAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DETAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DETAY.ObjectDefName = "Material";
                    DETAY.DataMember = "NAME";
                    DETAY.Value = @"{#PARTB.MATERIALNAME#}";

                    MEVCUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 202, 6, false);
                    MEVCUT.Name = "MEVCUT";
                    MEVCUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEVCUT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MEVCUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEVCUT.Value = @"{#PARTB.TOPLAMMIKTAR#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 6, 202, 6, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockGuideCard.GetStockGuideCardDetailsRpt_Class dataset_GetStockGuideCardDetailsRpt = MyParentReport.PARTB.rsGroup.GetCurrentRecord<StockGuideCard.GetStockGuideCardDetailsRpt_Class>(0);
                    SIRA.CalcValue = ParentGroup.Counter.ToString();
                    NSN.CalcValue = (dataset_GetStockGuideCardDetailsRpt != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetailsRpt.Nsnno) : "");
                    BARKOD.CalcValue = (dataset_GetStockGuideCardDetailsRpt != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetailsRpt.Materialname) : "");
                    BARKOD.PostFieldValueCalculation();
                    DETAY.CalcValue = (dataset_GetStockGuideCardDetailsRpt != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetailsRpt.Materialname) : "");
                    DETAY.PostFieldValueCalculation();
                    MEVCUT.CalcValue = (dataset_GetStockGuideCardDetailsRpt != null ? Globals.ToStringCore(dataset_GetStockGuideCardDetailsRpt.Toplammiktar) : "");
                    return new TTReportObject[] { SIRA,NSN,BARKOD,DETAY,MEVCUT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GuideCardAndContentsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            Name = "GUIDECARDANDCONTENTSREPORT";
            Caption = "Kılavuz Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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