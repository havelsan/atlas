
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
    /// Depo Mevcudu Raporu ( Bütçeye Göre)
    /// </summary>
    public partial class StockInHeldForStoreByButdegType : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? BUTGETTYPE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockInHeldForStoreByButdegType MyParentReport
            {
                get { return (StockInHeldForStoreByButdegType)ParentReport; }
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
                public StockInHeldForStoreByButdegType MyParentReport
                {
                    get { return (StockInHeldForStoreByButdegType)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 5, 212, 17, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"DEPO MEVCUDU RAPORU (BÜTÇE GRUBLU)";

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
                public StockInHeldForStoreByButdegType MyParentReport
                {
                    get { return (StockInHeldForStoreByButdegType)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
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

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 1, 166, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 1, 272, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 272, 1, false);
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
            public StockInHeldForStoreByButdegType MyParentReport
            {
                get { return (StockInHeldForStoreByButdegType)ParentReport; }
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
            public TTReportField BUTGETNAME { get {return Header().BUTGETNAME;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
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
                public StockInHeldForStoreByButdegType MyParentReport
                {
                    get { return (StockInHeldForStoreByButdegType)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField STOCKNAME;
                public TTReportField PARAMETERNAME11;
                public TTReportField NewField111;
                public TTReportField BUTGETNAME;
                public TTReportShape NewLine11111;
                public TTReportField NewField12;
                public TTReportField NewField112;
                public TTReportField NewField121;
                public TTReportField NewField1111;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField1121; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
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

                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 5, 21, 10, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Bütçe Türü";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 5, 26, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    BUTGETNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 5, 198, 10, false);
                    BUTGETNAME.Name = "BUTGETNAME";
                    BUTGETNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTGETNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BUTGETNAME.ObjectDefName = "BudgetTypeDefinition";
                    BUTGETNAME.DataMember = "NAME";
                    BUTGETNAME.TextFont.Bold = true;
                    BUTGETNAME.TextFont.CharSet = 162;
                    BUTGETNAME.Value = @"{@BUTGETTYPE@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 11, 272, 11, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.Visible = EvetHayirEnum.ehHayir;
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 12, 208, 17, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İlaç/Malzeme Adı";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 12, 230, 17, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"D. Şekli";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 12, 272, 17, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Mevcut";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 12, 7, 17, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Sıra";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 12, 45, 17, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Malzeme Kodu";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 12, 73, 17, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Barkod";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 12, 250, 17, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Kul. Miktar
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    STOCKNAME.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STOCKNAME.PostFieldValueCalculation();
                    PARAMETERNAME11.CalcValue = PARAMETERNAME11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    BUTGETNAME.CalcValue = MyParentReport.RuntimeParameters.BUTGETTYPE.ToString();
                    BUTGETNAME.PostFieldValueCalculation();
                    NewField12.CalcValue = NewField12.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { PARAMETERNAME1,NewField11,STOCKNAME,PARAMETERNAME11,NewField111,BUTGETNAME,NewField12,NewField112,NewField121,NewField1111,NewField131,NewField1131,NewField1121};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public StockInHeldForStoreByButdegType MyParentReport
                {
                    get { return (StockInHeldForStoreByButdegType)ParentReport; }
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

        public partial class MAINGroup : TTReportGroup
        {
            public StockInHeldForStoreByButdegType MyParentReport
            {
                get { return (StockInHeldForStoreByButdegType)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALOBJECTID1 { get {return Body().MATERIALOBJECTID1;} }
            public TTReportField STOCKCARDNSN1 { get {return Body().STOCKCARDNSN1;} }
            public TTReportField DISTRIBUTIONTYPE1 { get {return Body().DISTRIBUTIONTYPE1;} }
            public TTReportField MATERIALNAME1 { get {return Body().MATERIALNAME1;} }
            public TTReportField BARKOD1 { get {return Body().BARKOD1;} }
            public TTReportField USEDAMOUNT1 { get {return Body().USEDAMOUNT1;} }
            public TTReportField RESTAMOUNT1 { get {return Body().RESTAMOUNT1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
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
                list[0] = new TTReportNqlData<StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class>("StockTrasnactionByBudgetTypeStockInheld", StockTransaction.StockTrasnactionByBudgetTypeStockInheld((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.BUTGETTYPE)));
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
                public StockInHeldForStoreByButdegType MyParentReport
                {
                    get { return (StockInHeldForStoreByButdegType)ParentReport; }
                }
                
                public TTReportField MATERIALOBJECTID1;
                public TTReportField STOCKCARDNSN1;
                public TTReportField DISTRIBUTIONTYPE1;
                public TTReportField MATERIALNAME1;
                public TTReportField BARKOD1;
                public TTReportField USEDAMOUNT1;
                public TTReportField RESTAMOUNT1;
                public TTReportField NewField11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    MATERIALOBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 0, 326, 5, false);
                    MATERIALOBJECTID1.Name = "MATERIALOBJECTID1";
                    MATERIALOBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    MATERIALOBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALOBJECTID1.Value = @"{#MATERIALOBJECTID#}";

                    STOCKCARDNSN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 45, 5, false);
                    STOCKCARDNSN1.Name = "STOCKCARDNSN1";
                    STOCKCARDNSN1.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKCARDNSN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNSN1.Value = @"{#STOCKCARDNSN#}";

                    DISTRIBUTIONTYPE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 0, 230, 5, false);
                    DISTRIBUTIONTYPE1.Name = "DISTRIBUTIONTYPE1";
                    DISTRIBUTIONTYPE1.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE1.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE1.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE1.Value = @"{#DISTRIBUTIONTYPE#}";

                    MATERIALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 0, 208, 5, false);
                    MATERIALNAME1.Name = "MATERIALNAME1";
                    MATERIALNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME1.Value = @"{#MATERIALNAME#}";

                    BARKOD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 73, 5, false);
                    BARKOD1.Name = "BARKOD1";
                    BARKOD1.DrawStyle = DrawStyleConstants.vbSolid;
                    BARKOD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARKOD1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BARKOD1.Value = @"{#BARKOD#}";

                    USEDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 250, 5, false);
                    USEDAMOUNT1.Name = "USEDAMOUNT1";
                    USEDAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    USEDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    USEDAMOUNT1.Value = @"{#USEDAMOUNT#}";

                    RESTAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 272, 5, false);
                    RESTAMOUNT1.Name = "RESTAMOUNT1";
                    RESTAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    RESTAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESTAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RESTAMOUNT1.Value = @"{#RESTAMOUNT#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 7, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class dataset_StockTrasnactionByBudgetTypeStockInheld = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.StockTrasnactionByBudgetTypeStockInheld_Class>(0);
                    MATERIALOBJECTID1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.Materialobjectid) : "");
                    STOCKCARDNSN1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.Stockcardnsn) : "");
                    DISTRIBUTIONTYPE1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.DistributionType) : "");
                    DISTRIBUTIONTYPE1.PostFieldValueCalculation();
                    MATERIALNAME1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.Materialname) : "");
                    BARKOD1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.Barkod) : "");
                    USEDAMOUNT1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.Usedamount) : "");
                    RESTAMOUNT1.CalcValue = (dataset_StockTrasnactionByBudgetTypeStockInheld != null ? Globals.ToStringCore(dataset_StockTrasnactionByBudgetTypeStockInheld.Restamount) : "");
                    NewField11.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { MATERIALOBJECTID1,STOCKCARDNSN1,DISTRIBUTIONTYPE1,MATERIALNAME1,BARKOD1,USEDAMOUNT1,RESTAMOUNT1,NewField11};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StockInHeldForStoreByButdegType()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("BUTGETTYPE", "00000000-0000-0000-0000-000000000000", "Bütçe Seçiniz:", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("fdeda53c-2161-46a5-92e3-01c98e1676e3");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("BUTGETTYPE"))
                _runtimeParameters.BUTGETTYPE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["BUTGETTYPE"]);
            Name = "STOCKINHELDFORSTOREBYBUTDEGTYPE";
            Caption = "Depo Mevcudu Raporu ( Bütçeye Göre)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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