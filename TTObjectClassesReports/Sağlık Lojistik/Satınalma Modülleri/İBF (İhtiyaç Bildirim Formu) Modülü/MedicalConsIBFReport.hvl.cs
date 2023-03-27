
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
    /// Tıbbi Sarf Malzeme İhtiyaç Bildirim Formu Hazırlama Tablosu
    /// </summary>
    public partial class MedicalConsIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MedicalConsIBFReport MyParentReport
            {
                get { return (MedicalConsIBFReport)ParentReport; }
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
            public TTReportField NewField13121 { get {return Header().NewField13121;} }
            public TTReportField YEAR0 { get {return Header().YEAR0;} }
            public TTReportField NewField122131 { get {return Header().NewField122131;} }
            public TTReportField YEAR1 { get {return Header().YEAR1;} }
            public TTReportField NewField122133 { get {return Header().NewField122133;} }
            public TTReportField NewField1231221 { get {return Header().NewField1231221;} }
            public TTReportField NewField11221331 { get {return Header().NewField11221331;} }
            public TTReportField NewField1214 { get {return Header().NewField1214;} }
            public TTReportField NewField14121 { get {return Header().NewField14121;} }
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
                public MedicalConsIBFReport MyParentReport
                {
                    get { return (MedicalConsIBFReport)ParentReport; }
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
                public TTReportField NewField13121;
                public TTReportField YEAR0;
                public TTReportField NewField122131;
                public TTReportField YEAR1;
                public TTReportField NewField122133;
                public TTReportField NewField1231221;
                public TTReportField NewField11221331;
                public TTReportField NewField1214;
                public TTReportField NewField14121;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 15, 125, 23, false);
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

                    TOTALMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 23, 126, 31, false);
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

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 126, 41, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 9;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @".... YILI TIBBİ SARF MALZEME İHTİYAÇ BİLDİRİM FORMU
HAZIRLAMA TABLOSU";

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

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 41, 46, 49, false);
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

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 41, 126, 49, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Size = 8;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"MALZEMENİN ADI";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 15, 233, 49, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1213.TextFont.Name = "Arial";
                    NewField1213.TextFont.Size = 8;
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"



ÖLÇÜ
BİRİMİ";

                    NewField13121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 41, 69, 49, false);
                    NewField13121.Name = "NewField13121";
                    NewField13121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13121.TextFont.Name = "Arial";
                    NewField13121.TextFont.Size = 8;
                    NewField13121.TextFont.Bold = true;
                    NewField13121.TextFont.CharSet = 162;
                    NewField13121.Value = @"TEKNİK
ŞARTNAME NU.";

                    YEAR0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 15, 140, 49, false);
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
MİKTARI";

                    NewField122131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 15, 169, 49, false);
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

                    YEAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 15, 154, 49, false);
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

                    NewField122133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 15, 216, 49, false);
                    NewField122133.Name = "NewField122133";
                    NewField122133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122133.TextFont.Name = "Arial";
                    NewField122133.TextFont.Size = 8;
                    NewField122133.TextFont.Bold = true;
                    NewField122133.TextFont.CharSet = 162;
                    NewField122133.Value = @"



AÇIKLAMA VE İDARİ HUSUSLAR";

                    NewField1231221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 15, 247, 49, false);
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
MİKTARI";

                    NewField11221331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 15, 289, 41, false);
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

                    NewField1214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 41, 268, 49, false);
                    NewField1214.Name = "NewField1214";
                    NewField1214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1214.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214.TextFont.Name = "Arial";
                    NewField1214.TextFont.Size = 8;
                    NewField1214.TextFont.Bold = true;
                    NewField1214.TextFont.CharSet = 162;
                    NewField1214.Value = @"1";

                    NewField14121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 41, 289, 49, false);
                    NewField14121.Name = "NewField14121";
                    NewField14121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14121.TextFont.Name = "Arial";
                    NewField14121.TextFont.Size = 8;
                    NewField14121.TextFont.Bold = true;
                    NewField14121.TextFont.CharSet = 162;
                    NewField14121.Value = @"2";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 51, 15, 126, 15, false);
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
                    NewField13121.CalcValue = NewField13121.Value;
                    YEAR0.CalcValue = YEAR0.Value;
                    NewField122131.CalcValue = NewField122131.Value;
                    YEAR1.CalcValue = YEAR1.Value;
                    NewField122133.CalcValue = NewField122133.Value;
                    NewField1231221.CalcValue = NewField1231221.Value;
                    NewField11221331.CalcValue = NewField11221331.Value;
                    NewField1214.CalcValue = NewField1214.Value;
                    NewField14121.CalcValue = NewField14121.Value;
                    return new TTReportObject[] { MILITARYUNIT,NewField1,TOTALMATERIAL,NewField11,REPORTNAME,NewField112,NewField1211,NewField1212,NewField1213,NewField13121,YEAR0,NewField122131,YEAR1,NewField122133,NewField1231221,NewField11221331,NewField1214,NewField14121};
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
                REPORTNAME.CalcValue = ibfDemand.IBFYear.ToString() + " YILI TIBBİ SARF MALZEME İHTİYAÇ BİLDİRİM FORMU\nHAZIRLAMA TABLOSU";
                YEAR0.CalcValue = "\n\n\n" + (ibfDemand.IBFYear - 2).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR1.CalcValue = "\n\n\n" + (ibfDemand.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                if(ibf.Accountancy.AccountancyMilitaryUnit != null)
                    MILITARYUNIT.CalcValue = ibf.Accountancy.AccountancyMilitaryUnit.Name;
                else
                    MILITARYUNIT.CalcValue = ibf.Accountancy.Name;
                TOTALMATERIAL.CalcValue = "  " + ibf.AnnualRequirementDetailInLists.Count.ToString();
                REPORTNAME.CalcValue = ibf.IBFYear.ToString() + " YILI TIBBİ SARF MALZEME İHTİYAÇ BİLDİRİM FORMU\nHAZIRLAMA TABLOSU";
                YEAR0.CalcValue = "\n\n\n" + (ibf.IBFYear - 2).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR1.CalcValue = "\n\n\n" + (ibf.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                if(lbPurchase.MasterResource != null)
                    MILITARYUNIT.CalcValue = lbPurchase.MasterResource.Name;
                TOTALMATERIAL.CalcValue = "  " + lbPurchase.LBPurchaseProjectDetailInLists.Count.ToString();
                REPORTNAME.CalcValue = lbPurchase.IBFYear.ToString() + " YILI TIBBİ SARF MALZEME İHTİYAÇ BİLDİRİM FORMU\nHAZIRLAMA TABLOSU";
                YEAR0.CalcValue = "\n\n\n" + (lbPurchase.IBFYear - 2).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR1.CalcValue = "\n\n\n" + (lbPurchase.IBFYear - 1).ToString() + "\nYILI\nİBF\nİSTEK\nMİKTARI";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MedicalConsIBFReport MyParentReport
                {
                    get { return (MedicalConsIBFReport)ParentReport; }
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
            public MedicalConsIBFReport MyParentReport
            {
                get { return (MedicalConsIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField LASTIBFREQUESTAMOUNT { get {return Body().LASTIBFREQUESTAMOUNT;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField SPECIFICATION { get {return Body().SPECIFICATION;} }
            public TTReportField STOCK { get {return Body().STOCK;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
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
                public MedicalConsIBFReport MyParentReport
                {
                    get { return (MedicalConsIBFReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField LASTIBFREQUESTAMOUNT;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField SPECIFICATION;
                public TTReportField STOCK;
                public TTReportField COUNT;
                public TTReportField NSN;
                public TTReportField MATERIAL;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField REQUESTAMOUNT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine2;
                public TTReportShape NewLine14;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 216, 8, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}{#DETAILDESCRIPTION!GetIBFDetailInQuery#}";

                    LASTIBFREQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 154, 8, false);
                    LASTIBFREQUESTAMOUNT.Name = "LASTIBFREQUESTAMOUNT";
                    LASTIBFREQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTIBFREQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTIBFREQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LASTIBFREQUESTAMOUNT.TextFont.Name = "Arial";
                    LASTIBFREQUESTAMOUNT.TextFont.Size = 9;
                    LASTIBFREQUESTAMOUNT.TextFont.CharSet = 162;
                    LASTIBFREQUESTAMOUNT.Value = @"{#LASTIBFREQUESTAMOUNT#}{#LASTIBFREQUESTAMOUNT!GetIBFDetailInQuery#}{#LASTIBFREQUESTAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 0, 140, 8, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT.TextFont.Size = 9;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#CONSUMPTIONAMOUNT#}{#CONSUMPTIONAMOUNT!GetIBFDetailInQuery#}{#CONSUMPTIONAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    SPECIFICATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 0, 69, 8, false);
                    SPECIFICATION.Name = "SPECIFICATION";
                    SPECIFICATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIFICATION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPECIFICATION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPECIFICATION.TextFont.Name = "Arial";
                    SPECIFICATION.TextFont.Size = 9;
                    SPECIFICATION.TextFont.CharSet = 162;
                    SPECIFICATION.Value = @"";

                    STOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 169, 8, false);
                    STOCK.Name = "STOCK";
                    STOCK.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOCK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCK.TextFont.Name = "Arial";
                    STOCK.TextFont.Size = 9;
                    STOCK.TextFont.CharSet = 162;
                    STOCK.Value = @"{#CLINICSTOCKS#}{#STORESTOCKS!GetIBFDetailInQuery#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 8, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 9;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 46, 8, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 9;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NSN#}{#NSN!GetIBFDetailInQuery#}{#NSN!GetLBPurchaseProjectDetailInQuery#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 125, 8, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 9;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 233, 8, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}{#DISTRIBUTIONTYPE!GetIBFDetailInQuery#}{#DISTRIBUTIONTYPE!GetLBPurchaseProjectDetailInQuery#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 247, 8, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 9;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#APPROVEDAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 0, 18, 8, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 46, 0, 46, 8, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 69, 0, 69, 8, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 0, 126, 8, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 140, 0, 140, 8, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 0, 154, 8, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 169, 0, 169, 8, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 216, 0, 216, 8, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 233, 0, 233, 8, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 0, 247, 8, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 0, 268, 8, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine24.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 8, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine25.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 8, 289, 8, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 1, 328, 6, false);
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
                    DESCRIPTION.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Description) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DetailDescription) : "");
                    LASTIBFREQUESTAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.LastIBFRequestAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.LastIBFRequestAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.LastIBFRequestAmount) : "");
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ConsumptionAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ConsumptionAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ConsumptionAmount) : "");
                    SPECIFICATION.CalcValue = @"";
                    STOCK.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ClinicStocks) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.StoreStocks) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    NSN.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.NSN) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.NSN) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.NSN) : "");
                    MATERIAL.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.DistributionType) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DistributionType) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.DistributionType) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { DESCRIPTION,LASTIBFREQUESTAMOUNT,CONSUMPTIONAMOUNT,SPECIFICATION,STOCK,COUNT,NSN,MATERIAL,DISTRIBUTIONTYPE,REQUESTAMOUNT,DETAILOBJECTID};
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
                    IBFDet_MedicalConsIn medicalCons = (IBFDet_MedicalConsIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_MedicalConsIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(medicalCons.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = medicalCons.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = medicalCons.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = medicalCons.Amount.ToString();
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_MedicalConsIn medicalCons = (ARD_MedicalConsIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_MedicalConsIn));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {                        
                        if(medicalCons.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = medicalCons.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = medicalCons.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = medicalCons.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = medicalCons.LB_ApproveAmount.ToString();
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

        public MedicalConsIBFReport()
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
            Name = "MEDICALCONSIBFREPORT";
            Caption = "Tıbbi Sarf Malzeme İhtiyaç Bildirim Formu Hazırlama Tablosu";
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