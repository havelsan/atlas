
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
    /// XXXXXX Ecz.Bil.Mrk.Bşk.lığı Üretimi Ürün İhtiyaç Bildirim Formu Hazırlama Tablosu
    /// </summary>
    public partial class XXXXXXDrugIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public XXXXXXDrugIBFReport MyParentReport
            {
                get { return (XXXXXXDrugIBFReport)ParentReport; }
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
            public TTReportField NewField1212 { get {return Header().NewField1212;} }
            public TTReportField NewField1213 { get {return Header().NewField1213;} }
            public TTReportField NewField1231221 { get {return Header().NewField1231221;} }
            public TTReportField NewField11221331 { get {return Header().NewField11221331;} }
            public TTReportField NewField1214 { get {return Header().NewField1214;} }
            public TTReportField NewField14121 { get {return Header().NewField14121;} }
            public TTReportField NewField14122 { get {return Header().NewField14122;} }
            public TTReportField NewField122141 { get {return Header().NewField122141;} }
            public TTReportField NewField122142 { get {return Header().NewField122142;} }
            public TTReportField YEAR { get {return Header().YEAR;} }
            public TTReportField NewField112312211 { get {return Header().NewField112312211;} }
            public TTReportField NewField13121 { get {return Header().NewField13121;} }
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
                public XXXXXXDrugIBFReport MyParentReport
                {
                    get { return (XXXXXXDrugIBFReport)ParentReport; }
                }
                
                public TTReportField MILITARYUNIT;
                public TTReportField NewField1;
                public TTReportField TOTALMATERIAL;
                public TTReportField NewField11;
                public TTReportField REPORTNAME;
                public TTReportField NewField112;
                public TTReportField NewField1212;
                public TTReportField NewField1213;
                public TTReportField NewField1231221;
                public TTReportField NewField11221331;
                public TTReportField NewField1214;
                public TTReportField NewField14121;
                public TTReportField NewField14122;
                public TTReportField NewField122141;
                public TTReportField NewField122142;
                public TTReportField YEAR;
                public TTReportField NewField112312211;
                public TTReportField NewField13121;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 62;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 15, 156, 24, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 9;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 71, 24, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" BİRLİK/KURUM ADI:";

                    TOTALMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 24, 157, 33, false);
                    TOTALMATERIAL.Name = "TOTALMATERIAL";
                    TOTALMATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALMATERIAL.TextFont.Name = "Arial";
                    TOTALMATERIAL.TextFont.Size = 9;
                    TOTALMATERIAL.TextFont.CharSet = 162;
                    TOTALMATERIAL.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 71, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" TOPLAM KALEM MİKTARI:";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 33, 157, 43, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @".... YILI XXXXXX ECZ.BİL.MRK.BŞK.LIĞI ÜRETİMİ ÜRÜN İHTİYAÇ BİLDİRİM
FORMU HAZIRLAMA TABLOSU";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 19, 60, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"
S.
NU.";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 43, 117, 60, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Size = 9;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @" İSMİ";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 43, 157, 60, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1213.TextFont.Name = "Arial";
                    NewField1213.TextFont.Size = 9;
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"FORMÜLE
ESAS
AMBALAJ
ŞEKLİ";

                    NewField1231221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 15, 204, 60, false);
                    NewField1231221.Name = "NewField1231221";
                    NewField1231221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1231221.TextFont.Name = "Arial";
                    NewField1231221.TextFont.Size = 9;
                    NewField1231221.TextFont.Bold = true;
                    NewField1231221.TextFont.CharSet = 162;
                    NewField1231221.Value = @"



TOPLAM
İSTEK
(ADET)";

                    NewField11221331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 15, 289, 51, false);
                    NewField11221331.Name = "NewField11221331";
                    NewField11221331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221331.TextFont.Name = "Arial";
                    NewField11221331.TextFont.Size = 9;
                    NewField11221331.TextFont.Bold = true;
                    NewField11221331.TextFont.CharSet = 162;
                    NewField11221331.Value = @"MAL SORUMLULARI";

                    NewField1214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 51, 221, 60, false);
                    NewField1214.Name = "NewField1214";
                    NewField1214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1214.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214.TextFont.Name = "Arial";
                    NewField1214.TextFont.Size = 9;
                    NewField1214.TextFont.Bold = true;
                    NewField1214.TextFont.CharSet = 162;
                    NewField1214.Value = @"1";

                    NewField14121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 51, 238, 60, false);
                    NewField14121.Name = "NewField14121";
                    NewField14121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14121.TextFont.Name = "Arial";
                    NewField14121.TextFont.Size = 9;
                    NewField14121.TextFont.Bold = true;
                    NewField14121.TextFont.CharSet = 162;
                    NewField14121.Value = @"2";

                    NewField14122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 51, 255, 60, false);
                    NewField14122.Name = "NewField14122";
                    NewField14122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14122.TextFont.Name = "Arial";
                    NewField14122.TextFont.Size = 9;
                    NewField14122.TextFont.Bold = true;
                    NewField14122.TextFont.CharSet = 162;
                    NewField14122.Value = @"3";

                    NewField122141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 51, 272, 60, false);
                    NewField122141.Name = "NewField122141";
                    NewField122141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122141.TextFont.Name = "Arial";
                    NewField122141.TextFont.Size = 9;
                    NewField122141.TextFont.Bold = true;
                    NewField122141.TextFont.CharSet = 162;
                    NewField122141.Value = @"4";

                    NewField122142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 51, 289, 60, false);
                    NewField122142.Name = "NewField122142";
                    NewField122142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122142.TextFont.Name = "Arial";
                    NewField122142.TextFont.Size = 9;
                    NewField122142.TextFont.Bold = true;
                    NewField122142.TextFont.CharSet = 162;
                    NewField122142.Value = @"5";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 15, 189, 60, false);
                    YEAR.Name = "YEAR";
                    YEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR.TextFont.Name = "Arial";
                    YEAR.TextFont.Size = 9;
                    YEAR.TextFont.Bold = true;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"

....
YILI
İBF
İSTEK
MİKTARI
(ADET)";

                    NewField112312211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 15, 174, 60, false);
                    NewField112312211.Name = "NewField112312211";
                    NewField112312211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112312211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112312211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112312211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112312211.TextFont.Name = "Arial";
                    NewField112312211.TextFont.Size = 9;
                    NewField112312211.TextFont.Bold = true;
                    NewField112312211.TextFont.CharSet = 162;
                    NewField112312211.Value = @"



DEPO/
KLİNİK
MEVCUDU
(ADET)";

                    NewField13121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 43, 137, 60, false);
                    NewField13121.Name = "NewField13121";
                    NewField13121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13121.TextFont.Name = "Arial";
                    NewField13121.TextFont.Size = 9;
                    NewField13121.TextFont.Bold = true;
                    NewField13121.TextFont.CharSet = 162;
                    NewField13121.Value = @"
AMBALAJ
ŞEKLİ";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 15, 157, 15, false);
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
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField1213.CalcValue = NewField1213.Value;
                    NewField1231221.CalcValue = NewField1231221.Value;
                    NewField11221331.CalcValue = NewField11221331.Value;
                    NewField1214.CalcValue = NewField1214.Value;
                    NewField14121.CalcValue = NewField14121.Value;
                    NewField14122.CalcValue = NewField14122.Value;
                    NewField122141.CalcValue = NewField122141.Value;
                    NewField122142.CalcValue = NewField122142.Value;
                    YEAR.CalcValue = YEAR.Value;
                    NewField112312211.CalcValue = NewField112312211.Value;
                    NewField13121.CalcValue = NewField13121.Value;
                    return new TTReportObject[] { MILITARYUNIT,NewField1,TOTALMATERIAL,NewField11,REPORTNAME,NewField112,NewField1212,NewField1213,NewField1231221,NewField11221331,NewField1214,NewField14121,NewField14122,NewField122141,NewField122142,YEAR,NewField112312211,NewField13121};
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
                REPORTNAME.CalcValue = ibfDemand.IBFYear.ToString() + " YILI XXXXXX ECZ.BİL.MRK.BŞK.LIĞI ÜRETİMİ ÜRÜN İHTİYAÇ BİLDİRİM\nFORMU HAZIRLAMA TABLOSU";
                YEAR.CalcValue = "\n\n\n" + (ibfDemand.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI\n(ADET)";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                if(ibf.Accountancy.AccountancyMilitaryUnit != null)
                    MILITARYUNIT.CalcValue = ibf.Accountancy.AccountancyMilitaryUnit.Name;
                else
                    MILITARYUNIT.CalcValue = ibf.Accountancy.Name;
                TOTALMATERIAL.CalcValue = "  " + ibf.AnnualRequirementDetailInLists.Count.ToString();
                REPORTNAME.CalcValue = ibf.IBFYear.ToString() + " YILI XXXXXX ECZ.BİL.MRK.BŞK.LIĞI ÜRETİMİ ÜRÜN İHTİYAÇ BİLDİRİM\nFORMU HAZIRLAMA TABLOSU";
                YEAR.CalcValue = "\n\n\n" + (ibf.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI\n(ADET)";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                if(lbPurchase.MasterResource != null)
                    MILITARYUNIT.CalcValue = lbPurchase.MasterResource.Name;
                TOTALMATERIAL.CalcValue = "  " + lbPurchase.LBPurchaseProjectDetailInLists.Count.ToString();
                REPORTNAME.CalcValue = lbPurchase.IBFYear.ToString() + " YILI XXXXXX ECZ.BİL.MRK.BŞK.LIĞI ÜRETİMİ ÜRÜN İHTİYAÇ BİLDİRİM\nFORMU HAZIRLAMA TABLOSU";
                YEAR.CalcValue = "\n\n\n" + (lbPurchase.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI\n(ADET)";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public XXXXXXDrugIBFReport MyParentReport
                {
                    get { return (XXXXXXDrugIBFReport)ParentReport; }
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
            public XXXXXXDrugIBFReport MyParentReport
            {
                get { return (XXXXXXDrugIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField FORMULA { get {return Body().FORMULA;} }
            public TTReportField STOCK { get {return Body().STOCK;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField LASTIBFREQUESTAMOUNT { get {return Body().LASTIBFREQUESTAMOUNT;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportShape NewLine123 { get {return Body().NewLine123;} }
            public TTReportShape NewLine124 { get {return Body().NewLine124;} }
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
                public XXXXXXDrugIBFReport MyParentReport
                {
                    get { return (XXXXXXDrugIBFReport)ParentReport; }
                }
                
                public TTReportField FORMULA;
                public TTReportField STOCK;
                public TTReportField REQUESTAMOUNT;
                public TTReportField LASTIBFREQUESTAMOUNT;
                public TTReportField COUNT;
                public TTReportField MATERIAL;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportShape NewLine122;
                public TTReportShape NewLine123;
                public TTReportShape NewLine124;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    FORMULA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 157, 5, false);
                    FORMULA.Name = "FORMULA";
                    FORMULA.FieldType = ReportFieldTypeEnum.ftVariable;
                    FORMULA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMULA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMULA.TextFont.Name = "Arial";
                    FORMULA.TextFont.Size = 9;
                    FORMULA.TextFont.CharSet = 162;
                    FORMULA.Value = @"";

                    STOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 174, 5, false);
                    STOCK.Name = "STOCK";
                    STOCK.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOCK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCK.TextFont.Name = "Arial";
                    STOCK.TextFont.Size = 9;
                    STOCK.TextFont.CharSet = 162;
                    STOCK.Value = @"{#CLINICSTOCKS#}{#STORESTOCKS!GetIBFDetailInQuery#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 204, 5, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 9;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#APPROVEDAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    LASTIBFREQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 189, 5, false);
                    LASTIBFREQUESTAMOUNT.Name = "LASTIBFREQUESTAMOUNT";
                    LASTIBFREQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTIBFREQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTIBFREQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LASTIBFREQUESTAMOUNT.TextFont.Name = "Arial";
                    LASTIBFREQUESTAMOUNT.TextFont.Size = 9;
                    LASTIBFREQUESTAMOUNT.TextFont.CharSet = 162;
                    LASTIBFREQUESTAMOUNT.Value = @"{#LASTIBFREQUESTAMOUNT!GetIBFDetailInQuery#}{#LASTIBFREQUESTAMOUNT#}{#LASTIBFREQUESTAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 9;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 116, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 9;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 137, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE!GetLBPurchaseProjectDetailInQuery#}{#DISTRIBUTIONTYPE!GetIBFDetailInQuery#}{#DISTRIBUTIONTYPE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 117, 0, 117, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 137, 0, 137, 5, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 189, 0, 189, 5, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 0, 204, 5, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 221, 0, 221, 5, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 255, 0, 255, 5, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 272, 0, 272, 5, false);
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

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 238, 0, 238, 5, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 174, 0, 174, 5, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 157, 0, 157, 5, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine124.ExtendTo = ExtendToEnum.extPageHeight;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 0, 330, 5, false);
                    DETAILOBJECTID.Name = "DETAILOBJECTID";
                    DETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DETAILOBJECTID.Value = @"{#OBJECTID!GetLBPurchaseProjectDetailInQuery#}{#OBJECTID#}{#OBJECTID!GetIBFDetailInQuery#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class dataset_GetAnnualRequirementDetailInListQuery = ParentGroup.rsGroup.GetCurrentRecord<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>(0);
                    IBFDetDetailIn.GetIBFDetailInQuery_Class dataset_GetIBFDetailInQuery = ParentGroup.rsGroup.GetCurrentRecord<IBFDetDetailIn.GetIBFDetailInQuery_Class>(1);
                    LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class dataset_GetLBPurchaseProjectDetailInQuery = ParentGroup.rsGroup.GetCurrentRecord<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>(2);
                    FORMULA.CalcValue = @"";
                    STOCK.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ClinicStocks) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.StoreStocks) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    LASTIBFREQUESTAMOUNT.CalcValue = (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.LastIBFRequestAmount) : "") + (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.LastIBFRequestAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.LastIBFRequestAmount) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MATERIAL.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.DistributionType) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DistributionType) : "") + (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.DistributionType) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "") + (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { FORMULA,STOCK,REQUESTAMOUNT,LASTIBFREQUESTAMOUNT,COUNT,MATERIAL,DISTRIBUTIONTYPE,DETAILOBJECTID};
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
                    IBFDet_XXXXXXDrugIn XXXXXXDrug = (IBFDet_XXXXXXDrugIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_XXXXXXDrugIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(XXXXXXDrug.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = XXXXXXDrug.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = XXXXXXDrug.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = XXXXXXDrug.Amount.ToString();
                    
                    if(XXXXXXDrug.FormulaPurchaseItemUnitType.HasValue)
                    {
                        DistributionTypeDefinition typeDef = (DistributionTypeDefinition)MyParentReport.ReportObjectContext.GetObject(XXXXXXDrug.PurchaseItemDef.StockCard.DistributionType.ObjectID, typeof(DistributionTypeDefinition));
                        FORMULA.CalcValue = typeDef.DistributionType;
                    }
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_XXXXXXDrugIn XXXXXXDrug = (ARD_XXXXXXDrugIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_XXXXXXDrugIn));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        if(XXXXXXDrug.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = XXXXXXDrug.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = XXXXXXDrug.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = XXXXXXDrug.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = XXXXXXDrug.LB_ApproveAmount.ToString();
                    
                    if(XXXXXXDrug.FormulaPurchaseItemUnitType.HasValue)
                    {
                        DistributionTypeDefinition typeDef = (DistributionTypeDefinition)MyParentReport.ReportObjectContext.GetObject(XXXXXXDrug.PurchaseItemDef.StockCard.DistributionType.ObjectID, typeof(DistributionTypeDefinition));
                        FORMULA.CalcValue = typeDef.DistributionType;
                    }
                }
                else if(purchaseAction is LBPurchaseProject)
                {
                    LBD_XXXXXXDrugIn XXXXXXDrug = (LBD_XXXXXXDrugIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(LBD_XXXXXXDrugIn));
                    FORMULA.CalcValue = XXXXXXDrug.FormulaPurchaseItemUnitType;
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

        public XXXXXXDrugIBFReport()
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
            Name = "XXXXXXDRUGIBFREPORT";
            Caption = "XXXXXX Ecz.Bil.Mrk.Bşk.lığı Üretimi Ürün İhtiyaç Bildirim Formu Hazırlama Tablosu";
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