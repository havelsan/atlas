
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
    /// MSB İlaç FB.K.lığı Üretimi İlaç ve Malzeme İhtiyaç Bildirim Formu Hazırlama Tablosu
    /// </summary>
    public partial class MilitaryDrugIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MilitaryDrugIBFReport MyParentReport
            {
                get { return (MilitaryDrugIBFReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField TOTALMATERIAL { get {return Header().TOTALMATERIAL;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1212 { get {return Header().NewField1212;} }
            public TTReportField NewField1213 { get {return Header().NewField1213;} }
            public TTReportField YEAR0 { get {return Header().YEAR0;} }
            public TTReportField NewField122131 { get {return Header().NewField122131;} }
            public TTReportField YEAR1 { get {return Header().YEAR1;} }
            public TTReportField NewField1231221 { get {return Header().NewField1231221;} }
            public TTReportField NewField11221321 { get {return Header().NewField11221321;} }
            public TTReportField NewField1331221 { get {return Header().NewField1331221;} }
            public TTReportField NewField11221331 { get {return Header().NewField11221331;} }
            public TTReportField NewField1214 { get {return Header().NewField1214;} }
            public TTReportField NewField14121 { get {return Header().NewField14121;} }
            public TTReportField NewField14122 { get {return Header().NewField14122;} }
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
                public MilitaryDrugIBFReport MyParentReport
                {
                    get { return (MilitaryDrugIBFReport)ParentReport; }
                }
                
                public TTReportField MILITARYUNIT;
                public TTReportField NewField1;
                public TTReportField TOTALMATERIAL;
                public TTReportField NewField11;
                public TTReportField REPORTNAME;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField1212;
                public TTReportField NewField1213;
                public TTReportField YEAR0;
                public TTReportField NewField122131;
                public TTReportField YEAR1;
                public TTReportField NewField1231221;
                public TTReportField NewField11221321;
                public TTReportField NewField1331221;
                public TTReportField NewField11221331;
                public TTReportField NewField1214;
                public TTReportField NewField14121;
                public TTReportField NewField14122;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 15, 137, 23, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 8;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 51, 23, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" BİRLİK/KURUM ADI:";

                    TOTALMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 23, 138, 31, false);
                    TOTALMATERIAL.Name = "TOTALMATERIAL";
                    TOTALMATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALMATERIAL.TextFont.Name = "Arial";
                    TOTALMATERIAL.TextFont.Size = 8;
                    TOTALMATERIAL.TextFont.CharSet = 162;
                    TOTALMATERIAL.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 51, 31, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" TOPLAM KALEM MİKTARI:";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 138, 41, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 9;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @".... YILI MSB İLAÇ FB.K.LIĞI ÜRETİMİ İLAÇ VE MALZEME İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 18, 49, false);
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

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 41, 49, 49, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Size = 8;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"NATO STOK
NUMARASI";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 41, 121, 49, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Size = 8;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @" İLACIN/MALZEMENİN İSMİ";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 41, 138, 49, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1213.TextFont.Name = "Arial";
                    NewField1213.TextFont.Size = 8;
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"AMBALAJ
ŞEKLİ";

                    YEAR0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 15, 152, 49, false);
                    YEAR0.Name = "YEAR0";
                    YEAR0.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR0.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR0.TextFont.Name = "Arial";
                    YEAR0.TextFont.Size = 8;
                    YEAR0.TextFont.Bold = true;
                    YEAR0.TextFont.CharSet = 162;
                    YEAR0.Value = @"

....
YILI
SARF
MİKTARI
(ADET)";

                    NewField122131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 15, 167, 49, false);
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


DEPO/
KLİNİK
MEVCUDU
(ADET)";

                    YEAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 15, 181, 49, false);
                    YEAR1.Name = "YEAR1";
                    YEAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR1.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR1.TextFont.Name = "Arial";
                    YEAR1.TextFont.Size = 8;
                    YEAR1.TextFont.Bold = true;
                    YEAR1.TextFont.CharSet = 162;
                    YEAR1.Value = @"

....
YILI
İBF
İSTEK
MİKTARI";

                    NewField1231221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 15, 195, 49, false);
                    NewField1231221.Name = "NewField1231221";
                    NewField1231221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1231221.TextFont.Name = "Arial";
                    NewField1231221.TextFont.Size = 8;
                    NewField1231221.TextFont.Bold = true;
                    NewField1231221.TextFont.CharSet = 162;
                    NewField1231221.Value = @"


TOPLAM
İSTEK
(ADET)";

                    NewField11221321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 15, 209, 49, false);
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
(KUTU)";

                    NewField1331221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 15, 226, 49, false);
                    NewField1331221.Name = "NewField1331221";
                    NewField1331221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1331221.TextFont.Name = "Arial";
                    NewField1331221.TextFont.Size = 8;
                    NewField1331221.TextFont.Bold = true;
                    NewField1331221.TextFont.CharSet = 162;
                    NewField1331221.Value = @"



ADET/KUTU
KONTROLÜ";

                    NewField11221331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 15, 289, 41, false);
                    NewField11221331.Name = "NewField11221331";
                    NewField11221331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221331.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221331.TextFont.Name = "Arial";
                    NewField11221331.TextFont.Size = 8;
                    NewField11221331.TextFont.Bold = true;
                    NewField11221331.TextFont.CharSet = 162;
                    NewField11221331.Value = @"


MAL SORUMLULARI";

                    NewField1214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 41, 247, 49, false);
                    NewField1214.Name = "NewField1214";
                    NewField1214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1214.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214.TextFont.Name = "Arial";
                    NewField1214.TextFont.Size = 8;
                    NewField1214.TextFont.Bold = true;
                    NewField1214.TextFont.CharSet = 162;
                    NewField1214.Value = @"1";

                    NewField14121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 41, 268, 49, false);
                    NewField14121.Name = "NewField14121";
                    NewField14121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14121.TextFont.Name = "Arial";
                    NewField14121.TextFont.Size = 8;
                    NewField14121.TextFont.Bold = true;
                    NewField14121.TextFont.CharSet = 162;
                    NewField14121.Value = @"2";

                    NewField14122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 41, 289, 49, false);
                    NewField14122.Name = "NewField14122";
                    NewField14122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14122.TextFont.Name = "Arial";
                    NewField14122.TextFont.Size = 8;
                    NewField14122.TextFont.Bold = true;
                    NewField14122.TextFont.CharSet = 162;
                    NewField14122.Value = @"3";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 51, 15, 138, 15, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MILITARYUNIT.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    TOTALMATERIAL.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField1213.CalcValue = NewField1213.Value;
                    YEAR0.CalcValue = YEAR0.Value;
                    NewField122131.CalcValue = NewField122131.Value;
                    YEAR1.CalcValue = YEAR1.Value;
                    NewField1231221.CalcValue = NewField1231221.Value;
                    NewField11221321.CalcValue = NewField11221321.Value;
                    NewField1331221.CalcValue = NewField1331221.Value;
                    NewField11221331.CalcValue = NewField11221331.Value;
                    NewField1214.CalcValue = NewField1214.Value;
                    NewField14121.CalcValue = NewField14121.Value;
                    NewField14122.CalcValue = NewField14122.Value;
                    return new TTReportObject[] { MILITARYUNIT,NewField1,TOTALMATERIAL,NewField11,REPORTNAME,NewField112,NewField1211,NewField1212,NewField1213,YEAR0,NewField122131,YEAR1,NewField1231221,NewField11221321,NewField1331221,NewField11221331,NewField1214,NewField14121,NewField14122};
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
                TOTALMATERIAL.CalcValue = "  " + ibfDemand.IBFDetDetailIns.Count.ToString();
                REPORTNAME.CalcValue = ibfDemand.IBFYear.ToString() + " YILI MSB İLAÇ FB.K.LIĞI ÜRETİMİ İLAÇ VE MALZEME İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";
                YEAR0.CalcValue = "\n\n\n" + (ibfDemand.IBFYear - 3).ToString() + "\nYILI\nSARF\nMİKTARI\n(ADET)";
                YEAR1.CalcValue = "\n\n\n" + (ibfDemand.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI\n(ADET)";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                if(ibf.Accountancy.AccountancyMilitaryUnit != null)
                    MILITARYUNIT.CalcValue = ibf.Accountancy.AccountancyMilitaryUnit.Name;
                else
                    MILITARYUNIT.CalcValue = ibf.Accountancy.Name;
                TOTALMATERIAL.CalcValue = "  " + ibf.AnnualRequirementDetailInLists.Count.ToString();
                REPORTNAME.CalcValue = ibf.IBFYear.ToString() + " YILI MSB İLAÇ FB.K.LIĞI ÜRETİMİ İLAÇ VE MALZEME İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";
                YEAR0.CalcValue = "\n\n\n" + (ibf.IBFYear - 3).ToString() + "\nYILI\nSARF\nMİKTARI\n(ADET)";
                YEAR1.CalcValue = "\n\n\n" + (ibf.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI\n(ADET)";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                if(lbPurchase.MasterResource != null)
                    MILITARYUNIT.CalcValue = lbPurchase.MasterResource.Name;
                TOTALMATERIAL.CalcValue = "  " + lbPurchase.LBPurchaseProjectDetailInLists.Count.ToString();
                REPORTNAME.CalcValue = lbPurchase.IBFYear.ToString() + " YILI MSB İLAÇ FB.K.LIĞI ÜRETİMİ İLAÇ VE MALZEME İHTİYAÇ BİLDİRİM FORMU HAZIRLAMA TABLOSU";
                YEAR0.CalcValue = "\n\n\n" + (lbPurchase.IBFYear - 3).ToString() + "\nYILI\nSARF\nMİKTARI\n(ADET)";
                YEAR1.CalcValue = "\n\n\n" + (lbPurchase.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI\n(ADET)";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MilitaryDrugIBFReport MyParentReport
                {
                    get { return (MilitaryDrugIBFReport)ParentReport; }
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
            public MilitaryDrugIBFReport MyParentReport
            {
                get { return (MilitaryDrugIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REQUESTAMOUNTBOX { get {return Body().REQUESTAMOUNTBOX;} }
            public TTReportField LASTIBFREQUESTAMOUNT { get {return Body().LASTIBFREQUESTAMOUNT;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField STOCK { get {return Body().STOCK;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
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
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
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
                public MilitaryDrugIBFReport MyParentReport
                {
                    get { return (MilitaryDrugIBFReport)ParentReport; }
                }
                
                public TTReportField REQUESTAMOUNTBOX;
                public TTReportField LASTIBFREQUESTAMOUNT;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField STOCK;
                public TTReportField COUNT;
                public TTReportField NSN;
                public TTReportField MATERIAL;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField REQUESTAMOUNT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
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
                public TTReportShape NewLine13;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    REQUESTAMOUNTBOX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 209, 5, false);
                    REQUESTAMOUNTBOX.Name = "REQUESTAMOUNTBOX";
                    REQUESTAMOUNTBOX.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNTBOX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNTBOX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNTBOX.TextFont.Name = "Arial";
                    REQUESTAMOUNTBOX.TextFont.Size = 9;
                    REQUESTAMOUNTBOX.TextFont.CharSet = 162;
                    REQUESTAMOUNTBOX.Value = @"";

                    LASTIBFREQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 181, 5, false);
                    LASTIBFREQUESTAMOUNT.Name = "LASTIBFREQUESTAMOUNT";
                    LASTIBFREQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTIBFREQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTIBFREQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LASTIBFREQUESTAMOUNT.TextFont.Name = "Arial";
                    LASTIBFREQUESTAMOUNT.TextFont.Size = 9;
                    LASTIBFREQUESTAMOUNT.TextFont.CharSet = 162;
                    LASTIBFREQUESTAMOUNT.Value = @"{#LASTIBFREQUESTAMOUNT#}{#LASTIBFREQUESTAMOUNT!GetIBFDetailInQuery#}";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 152, 5, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT.TextFont.Size = 9;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#CONSUMPTIONAMOUNT#}{#CONSUMPTIONAMOUNT!GetIBFDetailInQuery#}";

                    STOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 167, 5, false);
                    STOCK.Name = "STOCK";
                    STOCK.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOCK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCK.TextFont.Name = "Arial";
                    STOCK.TextFont.Size = 9;
                    STOCK.TextFont.CharSet = 162;
                    STOCK.Value = @"{#CLINICSTOCKS#}{#STORESTOCKS!GetIBFDetailInQuery#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 9;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 49, 5, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 9;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NSN#}{#NSN!GetIBFDetailInQuery#}{#NSN!GetLBPurchaseProjectDetailInQuery#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 120, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 9;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 0, 138, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}{#DISTRIBUTIONTYPE!GetIBFDetailInQuery#}{#DISTRIBUTIONTYPE!GetLBPurchaseProjectDetailInQuery#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 195, 5, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 9;
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

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 0, 49, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 121, 0, 121, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 138, 0, 138, 5, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 0, 152, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 167, 0, 167, 5, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 181, 0, 181, 5, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 0, 195, 5, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 209, 0, 209, 5, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 226, 0, 226, 5, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 0, 247, 5, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 0, 268, 5, false);
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

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
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
                    REQUESTAMOUNTBOX.CalcValue = @"";
                    LASTIBFREQUESTAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.LastIBFRequestAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.LastIBFRequestAmount) : "");
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ConsumptionAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ConsumptionAmount) : "");
                    STOCK.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ClinicStocks) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.StoreStocks) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    NSN.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.NSN) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.NSN) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.NSN) : "");
                    MATERIAL.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.DistributionType) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DistributionType) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.DistributionType) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { REQUESTAMOUNTBOX,LASTIBFREQUESTAMOUNT,CONSUMPTIONAMOUNT,STOCK,COUNT,NSN,MATERIAL,DISTRIBUTIONTYPE,REQUESTAMOUNT,DETAILOBJECTID};
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
                    IBFDet_MilitaryDrugIn militaryDrug = (IBFDet_MilitaryDrugIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_MilitaryDrugIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(militaryDrug.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = militaryDrug.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = militaryDrug.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = militaryDrug.Amount.ToString();
                    
                    REQUESTAMOUNTBOX.CalcValue = militaryDrug.RequestAmountBox.ToString();
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_MilitaryDrugIn militaryDrug = (ARD_MilitaryDrugIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_MilitaryDrugIn));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {                        
                        if(militaryDrug.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = militaryDrug.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = militaryDrug.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = militaryDrug.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = militaryDrug.LB_ApproveAmount.ToString();
                    
                    REQUESTAMOUNTBOX.CalcValue = militaryDrug.RequestAmountBox.ToString();
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

        public MilitaryDrugIBFReport()
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
            Name = "MILITARYDRUGIBFREPORT";
            Caption = "MSB İlaç FB.K.lığı Üretimi İlaç ve Malzeme İhtiyaç Bildirim Formu Hazırlama Tablosu";
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