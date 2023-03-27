
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
    /// Depo Toplam Çıkış Miktarları  Raporu
    /// </summary>
    public partial class StockOutSumAmount : TTReport
    {
#region Methods
   public double totalAllPrice =0.0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string STORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string BUTGETTYPE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public StockOutSumAmount MyParentReport
            {
                get { return (StockOutSumAmount)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField CURRENTUSER1 { get {return Footer().CURRENTUSER1;} }
            public TTReportField PAGENUMBER1 { get {return Footer().PAGENUMBER1;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public StockOutSumAmount MyParentReport
                {
                    get { return (StockOutSumAmount)ParentReport; }
                }
                
                public TTReportField REPORTNAME1;
                public TTReportField LOGO1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 5, 197, 17, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Size = 15;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"DEPO TOPLAM ÇIKIŞ MİKTARLARI RAPORU";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 41, 21, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    return new TTReportObject[] { REPORTNAME1,LOGO1};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockOutSumAmount MyParentReport
                {
                    get { return (StockOutSumAmount)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField CURRENTUSER1;
                public TTReportField PAGENUMBER1;
                public TTReportShape NewLine1111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 29, 6, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    CURRENTUSER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 1, 155, 6, false);
                    CURRENTUSER1.Name = "CURRENTUSER1";
                    CURRENTUSER1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER1.TextFont.Size = 8;
                    CURRENTUSER1.TextFont.CharSet = 162;
                    CURRENTUSER1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 0, 278, 5, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1.TextFont.Size = 8;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 1, 279, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

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

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public StockOutSumAmount MyParentReport
            {
                get { return (StockOutSumAmount)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField111211 { get {return Footer().NewField111211;} }
            public TTReportField TOTALALLPRICES { get {return Footer().TOTALALLPRICES;} }
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
                public StockOutSumAmount MyParentReport
                {
                    get { return (StockOutSumAmount)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField1221;
                public TTReportField NewField1111;
                public TTReportField NewField11211;
                public TTReportShape NewLine11111;
                public TTReportField NewField2;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField1111111;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField16; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 30, 204, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İlaç/Malzeme";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 30, 64, 35, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MKYS KODU";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 30, 94, 35, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"BARKOD";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 30, 254, 35, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"B.FİYAT";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 30, 228, 35, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"MİKTAR";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 30, 13, 35, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"S. Nu.";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 30, 279, 35, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"TUTAR";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 35, 279, 36, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 279, 7, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.ObjectDefName = "Store";
                    NewField2.DataMember = "NAME";
                    NewField2.Value = @"{@STORE@}";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 2, 32, 7, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"DEPO";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 14, 32, 19, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"BAŞLANGIÇ TARİHİ";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 8, 32, 13, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"BÜTÇE";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 20, 32, 25, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"BİTİŞ TARİHİ";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 2, 35, 7, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 8, 35, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 14, 35, 19, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 20, 35, 25, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 8, 279, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.ObjectDefName = "BudgetTypeDefinition";
                    NewField4.DataMember = "NAME";
                    NewField4.Value = @"{@BUTGETTYPE@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 14, 279, 19, false);
                    NewField5.Name = "NewField5";
                    NewField5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField5.TextFormat = @"dd/MM/yyyy";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.Value = @"{@STARTDATE@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 20, 279, 25, false);
                    NewField16.Name = "NewField16";
                    NewField16.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField16.TextFormat = @"dd/MM/yyyy";
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField2.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    NewField2.PostFieldValueCalculation();
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField4.CalcValue = MyParentReport.RuntimeParameters.BUTGETTYPE.ToString();
                    NewField4.PostFieldValueCalculation();
                    NewField5.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField16.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { NewField11,NewField111,NewField121,NewField1121,NewField1221,NewField1111,NewField11211,NewField2,NewField11111,NewField111111,NewField111112,NewField1111111,NewField3,NewField13,NewField14,NewField15,NewField4,NewField5,NewField16};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public StockOutSumAmount MyParentReport
                {
                    get { return (StockOutSumAmount)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportField TOTALALLPRICES; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 244, 6, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"TOPLAM TUTAR:";

                    TOTALALLPRICES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 1, 278, 6, false);
                    TOTALALLPRICES.Name = "TOTALALLPRICES";
                    TOTALALLPRICES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALALLPRICES.TextFormat = @"#,###";
                    TOTALALLPRICES.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALALLPRICES.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111211.CalcValue = NewField111211.Value;
                    TOTALALLPRICES.CalcValue = @"";
                    return new TTReportObject[] { NewField111211,TOTALALLPRICES};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.TOTALALLPRICES.CalcValue =  this.MyParentReport.totalAllPrice.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public StockOutSumAmount MyParentReport
            {
                get { return (StockOutSumAmount)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNSN { get {return Body().MATERIALNSN;} }
            public TTReportField MATERIALBARCODE { get {return Body().MATERIALBARCODE;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
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
                list[0] = new TTReportNqlData<StockTransaction.StockOutSumAmountRQ_Class>("StockOutSumAmountRQ", StockTransaction.StockOutSumAmountRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.BUTGETTYPE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public StockOutSumAmount MyParentReport
                {
                    get { return (StockOutSumAmount)ParentReport; }
                }
                
                public TTReportField MATERIALNSN;
                public TTReportField MATERIALBARCODE;
                public TTReportField MATERIALNAME;
                public TTReportField UNITPRICE;
                public TTReportField AMOUNT;
                public TTReportField NewField1;
                public TTReportField TOTALPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    MATERIALNSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 64, 5, false);
                    MATERIALNSN.Name = "MATERIALNSN";
                    MATERIALNSN.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNSN.Value = @"{#MATERIALNSN#}";

                    MATERIALBARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 94, 5, false);
                    MATERIALBARCODE.Name = "MATERIALBARCODE";
                    MATERIALBARCODE.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALBARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALBARCODE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALBARCODE.Value = @"{#MATERIALBARCODE#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 0, 204, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 254, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 0, 228, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 13, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.Value = @"{@counter@}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 279, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.StockOutSumAmountRQ_Class dataset_StockOutSumAmountRQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.StockOutSumAmountRQ_Class>(0);
                    MATERIALNSN.CalcValue = (dataset_StockOutSumAmountRQ != null ? Globals.ToStringCore(dataset_StockOutSumAmountRQ.Materialnsn) : "");
                    MATERIALBARCODE.CalcValue = (dataset_StockOutSumAmountRQ != null ? Globals.ToStringCore(dataset_StockOutSumAmountRQ.Materialbarcode) : "");
                    MATERIALNAME.CalcValue = (dataset_StockOutSumAmountRQ != null ? Globals.ToStringCore(dataset_StockOutSumAmountRQ.Materialname) : "");
                    UNITPRICE.CalcValue = (dataset_StockOutSumAmountRQ != null ? Globals.ToStringCore(dataset_StockOutSumAmountRQ.UnitPrice) : "");
                    AMOUNT.CalcValue = (dataset_StockOutSumAmountRQ != null ? Globals.ToStringCore(dataset_StockOutSumAmountRQ.Amount) : "");
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    TOTALPRICE.CalcValue = TOTALPRICE.Value;
                    return new TTReportObject[] { MATERIALNSN,MATERIALBARCODE,MATERIALNAME,UNITPRICE,AMOUNT,NewField1,TOTALPRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    double totalPrice = double.Parse(this.AMOUNT.CalcValue)* double.Parse(this.UNITPRICE.CalcValue);
            this.TOTALPRICE.CalcValue = totalPrice.ToString();
                this.MyParentReport.totalAllPrice += totalPrice;
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

        public StockOutSumAmount()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "", "Depo Seçin :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("BUTGETTYPE", "", "Bütçe Türü :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("fdeda53c-2161-46a5-92e3-01c98e1676e3");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("BUTGETTYPE"))
                _runtimeParameters.BUTGETTYPE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["BUTGETTYPE"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "STOCKOUTSUMAMOUNT";
            Caption = "Depo Toplam Çıkış Miktarları  Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 5;
            UserMarginTop = 5;
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


        protected override void RunPreScript()
        {
#region STOCKOUTSUMAMOUNT_PreScript
            if (this.RuntimeParameters.STARTDATE != null)
            {
                DateTime startDate = ((DateTime)this.RuntimeParameters.STARTDATE);
                this.RuntimeParameters.STARTDATE = DateTime.Parse(startDate.ToShortDateString().Trim() + " 00:00:00");
            }
            if (this.RuntimeParameters.ENDDATE != null)
            {
                DateTime entDate = ((DateTime)this.RuntimeParameters.ENDDATE);
                this.RuntimeParameters.ENDDATE =  DateTime.Parse(entDate.ToShortDateString().Trim() + " 23:59:59");
            }
#endregion STOCKOUTSUMAMOUNT_PreScript
        }
    }
}