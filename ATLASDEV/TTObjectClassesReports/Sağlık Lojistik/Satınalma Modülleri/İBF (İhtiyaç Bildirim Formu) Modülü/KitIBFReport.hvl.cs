
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
    /// Kit İhtiyaç Bildirim Formu Hazırlama Tablosu
    /// </summary>
    public partial class KitIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KitIBFReport MyParentReport
            {
                get { return (KitIBFReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField TOTALMATERIAL { get {return Header().TOTALMATERIAL;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1212 { get {return Header().NewField1212;} }
            public TTReportField NewField13122 { get {return Header().NewField13122;} }
            public TTReportField NewField122131 { get {return Header().NewField122131;} }
            public TTReportField NewField122132 { get {return Header().NewField122132;} }
            public TTReportField NewField122133 { get {return Header().NewField122133;} }
            public TTReportField NewField1231221 { get {return Header().NewField1231221;} }
            public TTReportField NewField11221321 { get {return Header().NewField11221321;} }
            public TTReportField NewField1214 { get {return Header().NewField1214;} }
            public TTReportField NewField14121 { get {return Header().NewField14121;} }
            public TTReportField NewField14122 { get {return Header().NewField14122;} }
            public TTReportField NewField14123 { get {return Header().NewField14123;} }
            public TTReportField NewField112141 { get {return Header().NewField112141;} }
            public TTReportField NewField122141 { get {return Header().NewField122141;} }
            public TTReportField NewField132141 { get {return Header().NewField132141;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
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
                public KitIBFReport MyParentReport
                {
                    get { return (KitIBFReport)ParentReport; }
                }
                
                public TTReportField MILITARYUNIT;
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField TOTALMATERIAL;
                public TTReportField NewField11;
                public TTReportField NewField112;
                public TTReportField NewField1212;
                public TTReportField NewField13122;
                public TTReportField NewField122131;
                public TTReportField NewField122132;
                public TTReportField NewField122133;
                public TTReportField NewField1231221;
                public TTReportField NewField11221321;
                public TTReportField NewField1214;
                public TTReportField NewField14121;
                public TTReportField NewField14122;
                public TTReportField NewField14123;
                public TTReportField NewField112141;
                public TTReportField NewField122141;
                public TTReportField NewField132141;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 15, 197, 23, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 8;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 104, 44, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 9;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 52, 23, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" BİRLİK/KURUM ADI:";

                    TOTALMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 23, 198, 31, false);
                    TOTALMATERIAL.Name = "TOTALMATERIAL";
                    TOTALMATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALMATERIAL.TextFont.Name = "Arial";
                    TOTALMATERIAL.TextFont.Size = 8;
                    TOTALMATERIAL.TextFont.CharSet = 162;
                    TOTALMATERIAL.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 52, 31, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" CİHAZIN MARKA VE MODELİ :
 ENVANTERE GİRİŞ TARİHİ     :";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 18, 52, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Size = 8;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"S.
NU.";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 44, 104, 52, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Size = 8;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"KİTİN ADI";

                    NewField13122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 31, 119, 52, false);
                    NewField13122.Name = "NewField13122";
                    NewField13122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13122.TextFont.Name = "Arial";
                    NewField13122.TextFont.Size = 8;
                    NewField13122.TextFont.Bold = true;
                    NewField13122.TextFont.CharSet = 162;
                    NewField13122.Value = @"
YILLIK
SARF
MİKTARI";

                    NewField122131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 31, 134, 52, false);
                    NewField122131.Name = "NewField122131";
                    NewField122131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122131.TextFont.Name = "Arial";
                    NewField122131.TextFont.Size = 8;
                    NewField122131.TextFont.Bold = true;
                    NewField122131.TextFont.CharSet = 162;
                    NewField122131.Value = @"

ÖLÇÜ
BİRİMİ";

                    NewField122132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 31, 149, 52, false);
                    NewField122132.Name = "NewField122132";
                    NewField122132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122132.TextFont.Name = "Arial";
                    NewField122132.TextFont.Size = 8;
                    NewField122132.TextFont.Bold = true;
                    NewField122132.TextFont.CharSet = 162;
                    NewField122132.Value = @"

ÜRETİM
DURUMU";

                    NewField122133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 31, 166, 52, false);
                    NewField122133.Name = "NewField122133";
                    NewField122133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122133.TextFont.Name = "Arial";
                    NewField122133.TextFont.Size = 8;
                    NewField122133.TextFont.Bold = true;
                    NewField122133.TextFont.CharSet = 162;
                    NewField122133.Value = @"1. GRUP
(OCAK-
HAZİRAN)
İSTEK
MİKTARI";

                    NewField1231221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 31, 183, 52, false);
                    NewField1231221.Name = "NewField1231221";
                    NewField1231221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1231221.TextFont.Name = "Arial";
                    NewField1231221.TextFont.Size = 8;
                    NewField1231221.TextFont.Bold = true;
                    NewField1231221.TextFont.CharSet = 162;
                    NewField1231221.Value = @"2. GRUP
(TEMMUZ-
ARALIK)
İSTEK
MİKTARI";

                    NewField11221321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 31, 198, 52, false);
                    NewField11221321.Name = "NewField11221321";
                    NewField11221321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221321.TextFont.Name = "Arial";
                    NewField11221321.TextFont.Size = 8;
                    NewField11221321.TextFont.Bold = true;
                    NewField11221321.TextFont.CharSet = 162;
                    NewField11221321.Value = @"
TOPLAM
İSTEK
MİKTARI";

                    NewField1214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 15, 211, 52, false);
                    NewField1214.Name = "NewField1214";
                    NewField1214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1214.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214.TextFont.Name = "Arial";
                    NewField1214.TextFont.Size = 8;
                    NewField1214.TextFont.Bold = true;
                    NewField1214.TextFont.CharSet = 162;
                    NewField1214.Value = @"1";

                    NewField14121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 15, 224, 52, false);
                    NewField14121.Name = "NewField14121";
                    NewField14121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14121.TextFont.Name = "Arial";
                    NewField14121.TextFont.Size = 8;
                    NewField14121.TextFont.Bold = true;
                    NewField14121.TextFont.CharSet = 162;
                    NewField14121.Value = @"2";

                    NewField14122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 15, 237, 52, false);
                    NewField14122.Name = "NewField14122";
                    NewField14122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14122.TextFont.Name = "Arial";
                    NewField14122.TextFont.Size = 8;
                    NewField14122.TextFont.Bold = true;
                    NewField14122.TextFont.CharSet = 162;
                    NewField14122.Value = @"3";

                    NewField14123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 15, 250, 52, false);
                    NewField14123.Name = "NewField14123";
                    NewField14123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14123.TextFont.Name = "Arial";
                    NewField14123.TextFont.Size = 8;
                    NewField14123.TextFont.Bold = true;
                    NewField14123.TextFont.CharSet = 162;
                    NewField14123.Value = @"4";

                    NewField112141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 15, 263, 52, false);
                    NewField112141.Name = "NewField112141";
                    NewField112141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112141.TextFont.Name = "Arial";
                    NewField112141.TextFont.Size = 8;
                    NewField112141.TextFont.Bold = true;
                    NewField112141.TextFont.CharSet = 162;
                    NewField112141.Value = @"5";

                    NewField122141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 15, 276, 52, false);
                    NewField122141.Name = "NewField122141";
                    NewField122141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122141.TextFont.Name = "Arial";
                    NewField122141.TextFont.Size = 8;
                    NewField122141.TextFont.Bold = true;
                    NewField122141.TextFont.CharSet = 162;
                    NewField122141.Value = @"6";

                    NewField132141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 15, 289, 52, false);
                    NewField132141.Name = "NewField132141";
                    NewField132141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132141.TextFont.Name = "Arial";
                    NewField132141.TextFont.Size = 8;
                    NewField132141.TextFont.Bold = true;
                    NewField132141.TextFont.CharSet = 162;
                    NewField132141.Value = @"7";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 51, 15, 198, 15, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MILITARYUNIT.CalcValue = @"";
                    REPORTNAME.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    TOTALMATERIAL.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField13122.CalcValue = NewField13122.Value;
                    NewField122131.CalcValue = NewField122131.Value;
                    NewField122132.CalcValue = NewField122132.Value;
                    NewField122133.CalcValue = NewField122133.Value;
                    NewField1231221.CalcValue = NewField1231221.Value;
                    NewField11221321.CalcValue = NewField11221321.Value;
                    NewField1214.CalcValue = NewField1214.Value;
                    NewField14121.CalcValue = NewField14121.Value;
                    NewField14122.CalcValue = NewField14122.Value;
                    NewField14123.CalcValue = NewField14123.Value;
                    NewField112141.CalcValue = NewField112141.Value;
                    NewField122141.CalcValue = NewField122141.Value;
                    NewField132141.CalcValue = NewField132141.Value;
                    return new TTReportObject[] { MILITARYUNIT,REPORTNAME,NewField1,TOTALMATERIAL,NewField11,NewField112,NewField1212,NewField13122,NewField122131,NewField122132,NewField122133,NewField1231221,NewField11221321,NewField1214,NewField14121,NewField14122,NewField14123,NewField112141,NewField122141,NewField132141};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if(purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                if(ibfDemand.MasterResource != null)
                    MILITARYUNIT.CalcValue = ibfDemand.MasterResource.Name;
                REPORTNAME.CalcValue = ibfDemand.IBFYear.ToString() + " YILI XXXXXX H.PAŞA EĞT.HST.BŞTBP.LİĞİ ÜRETİMİ\nAÇIK SİSTEM RUTİN BİYOKİMYA CİHAZI KİTLERİ İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                if(ibf.Accountancy.AccountancyMilitaryUnit != null)
                    MILITARYUNIT.CalcValue = ibf.Accountancy.AccountancyMilitaryUnit.Name;
                else
                    MILITARYUNIT.CalcValue = ibf.Accountancy.Name;
                REPORTNAME.CalcValue = ibf.IBFYear.ToString() + " YILI XXXXXX H.PAŞA EĞT.HST.BŞTBP.LİĞİ ÜRETİMİ\nAÇIK SİSTEM RUTİN BİYOKİMYA CİHAZI KİTLERİ İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                if(lbPurchase.MasterResource != null)
                    MILITARYUNIT.CalcValue = lbPurchase.MasterResource.Name;
                REPORTNAME.CalcValue = lbPurchase.IBFYear.ToString() + " YILI XXXXXX H.PAŞA EĞT.HST.BŞTBP.LİĞİ ÜRETİMİ\nAÇIK SİSTEM RUTİN BİYOKİMYA CİHAZI KİTLERİ İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KitIBFReport MyParentReport
                {
                    get { return (KitIBFReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public KitIBFReport MyParentReport
            {
                get { return (KitIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PRODUCTTYPE { get {return Body().PRODUCTTYPE;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT2 { get {return Body().AMOUNT2;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField AMOUNT1 { get {return Body().AMOUNT1;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine26 { get {return Body().NewLine26;} }
            public TTReportField DETAILOBJECTID { get {return Body().DETAILOBJECTID;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[3];
                list[0] = new TTReportNqlData<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>("GetAnnualRequirementDetailInListQuery", AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<IBFDetDetailIn.GetIBFDetailInQuery_Class>("GetIBFDetailInQuery", IBFDetDetailIn.GetIBFDetailInQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[2] = new TTReportNqlData<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>("GetLBPurchaseProjectDetailInQuery", LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KitIBFReport MyParentReport
                {
                    get { return (KitIBFReport)ParentReport; }
                }
                
                public TTReportField PRODUCTTYPE;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT2;
                public TTReportField COUNT;
                public TTReportField MATERIAL;
                public TTReportField AMOUNT1;
                public TTReportField REQUESTAMOUNT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine2;
                public TTReportShape NewLine26;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    PRODUCTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 149, 5, false);
                    PRODUCTTYPE.Name = "PRODUCTTYPE";
                    PRODUCTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRODUCTTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCTTYPE.TextFont.Name = "Arial";
                    PRODUCTTYPE.TextFont.Size = 8;
                    PRODUCTTYPE.TextFont.CharSet = 162;
                    PRODUCTTYPE.Value = @"";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 119, 5, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT.TextFont.Size = 8;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#CONSUMPTIONAMOUNT#}{#CONSUMPTIONAMOUNT!GetIBFDetailInQuery#}{#CONSUMPTIONAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 134, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}{#DISTRIBUTIONTYPE!GetIBFDetailInQuery#}{#DISTRIBUTIONTYPE!GetLBPurchaseProjectDetailInQuery#}";

                    AMOUNT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 183, 5, false);
                    AMOUNT2.Name = "AMOUNT2";
                    AMOUNT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT2.TextFont.Name = "Arial";
                    AMOUNT2.TextFont.Size = 8;
                    AMOUNT2.TextFont.CharSet = 162;
                    AMOUNT2.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 8;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 103, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 8;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 166, 5, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1.TextFont.Name = "Arial";
                    AMOUNT1.TextFont.Size = 8;
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 198, 5, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 8;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#APPROVEDAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 0, 18, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 224, 0, 224, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 0, 104, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 0, 119, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 0, 134, 5, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 0, 149, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 5, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 0, 183, 5, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 0, 198, 5, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 237, 0, 237, 5, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 250, 0, 250, 5, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 263, 0, 263, 5, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 276, 0, 276, 5, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine24.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 5, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine25.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 289, 5, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine26 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine26.Name = "NewLine26";
                    NewLine26.DrawStyle = DrawStyleConstants.vbSolid;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 5, false);
                    DETAILOBJECTID.Name = "DETAILOBJECTID";
                    DETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DETAILOBJECTID.Value = @"{#OBJECTID#}{#OBJECTID!GetIBFDetailInQuery#}{#OBJECTID!GetLBPurchaseProjectDetailInQuery#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class dataset_GetAnnualRequirementDetailInListQuery = ParentGroup.rsGroup.GetCurrentRecord<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>(0);
                    IBFDetDetailIn.GetIBFDetailInQuery_Class dataset_GetIBFDetailInQuery = ParentGroup.rsGroup.GetCurrentRecord<IBFDetDetailIn.GetIBFDetailInQuery_Class>(1);
                    LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class dataset_GetLBPurchaseProjectDetailInQuery = ParentGroup.rsGroup.GetCurrentRecord<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>(2);
                    PRODUCTTYPE.CalcValue = @"";
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ConsumptionAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ConsumptionAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ConsumptionAmount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.DistributionType) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DistributionType) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.DistributionType) : "");
                    AMOUNT2.CalcValue = @"";
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MATERIAL.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "");
                    AMOUNT1.CalcValue = @"";
                    REQUESTAMOUNT.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { PRODUCTTYPE,CONSUMPTIONAMOUNT,DISTRIBUTIONTYPE,AMOUNT2,COUNT,MATERIAL,AMOUNT1,REQUESTAMOUNT,DETAILOBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(DETAILOBJECTID.CalcValue != "")
            {
                string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
                if(purchaseAction is IBFDemand)
                {
                    IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                    IBFDet_KitIn kit = (IBFDet_KitIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_KitIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(kit.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = kit.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = kit.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = kit.Amount.ToString();
                    
                    PRODUCTTYPE.CalcValue = kit.ProductStatus;
                    AMOUNT1.CalcValue = kit.FirstRequestAmount.ToString();
                    AMOUNT2.CalcValue = kit.SecondRequestAmount.ToString();
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_KitIn kit = (ARD_KitIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_KitIn));                    
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {                        
                        if(kit.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = kit.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = kit.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = kit.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = kit.LB_ApproveAmount.ToString();
                    
                    PRODUCTTYPE.CalcValue = kit.ProductStatus;
                    AMOUNT1.CalcValue = kit.FirstRequestAmount.ToString();
                    AMOUNT2.CalcValue = kit.SecondRequestAmount.ToString();
                }
                else if(purchaseAction is LBPurchaseProject)
                {
                    LBD_KitIn kit = (LBD_KitIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(LBD_KitIn));                    
                    PRODUCTTYPE.CalcValue = kit.ProductStatus;
                    AMOUNT1.CalcValue = kit.FirstRequestAmount.ToString();
                    AMOUNT2.CalcValue = kit.SecondRequestAmount.ToString();
                }
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

        public KitIBFReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KITIBFREPORT";
            Caption = "Kit İhtiyaç Bildirim Formu Hazırlama Tablosu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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