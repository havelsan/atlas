
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
    /// Tıbbi Cihaz Mekanik Yedek Parça İhtiyaçları Listesi
    /// </summary>
    public partial class SpareIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public SpareIBFReport MyParentReport
            {
                get { return (SpareIBFReport)ParentReport; }
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
            public TTReportField PAGENO1 { get {return Header().PAGENO1;} }
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
                public SpareIBFReport MyParentReport
                {
                    get { return (SpareIBFReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField PAGENO1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 289, 23, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @".... YILI TIBBİ CİHAZ MEKANİK YEDEK PARÇA İHTİYAÇLARI LİSTESİ";

                    PAGENO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 5, 289, 10, false);
                    PAGENO1.Name = "PAGENO1";
                    PAGENO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENO1.TextFont.Name = "Arial";
                    PAGENO1.TextFont.Size = 8;
                    PAGENO1.TextFont.CharSet = 162;
                    PAGENO1.Value = @"EK - A";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    PAGENO1.CalcValue = PAGENO1.Value;
                    return new TTReportObject[] { REPORTNAME,PAGENO1};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if(purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                REPORTNAME.CalcValue = ibfDemand.IBFYear.ToString() + " YILI TIBBİ CİHAZ MEKANİK YEDEK PARÇA İHTİYAÇLARI LİSTESİ";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                REPORTNAME.CalcValue = ibf.IBFYear.ToString() + " YILI TIBBİ CİHAZ MEKANİK YEDEK PARÇA İHTİYAÇLARI LİSTESİ";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                REPORTNAME.CalcValue = lbPurchase.IBFYear.ToString() + " YILI TIBBİ CİHAZ MEKANİK YEDEK PARÇA İHTİYAÇLARI LİSTESİ";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SpareIBFReport MyParentReport
                {
                    get { return (SpareIBFReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public SpareIBFReport MyParentReport
            {
                get { return (SpareIBFReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField112131 { get {return Header().NewField112131;} }
            public TTReportField NewField1131211 { get {return Header().NewField1131211;} }
            public TTReportField YEAR1 { get {return Header().YEAR1;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField112121 { get {return Header().NewField112121;} }
            public TTReportField NewField11221311 { get {return Header().NewField11221311;} }
            public TTReportField NewField11221331 { get {return Header().NewField11221331;} }
            public TTReportField YEAR0 { get {return Header().YEAR0;} }
            public TTReportField PAGENO { get {return Footer().PAGENO;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
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
                public SpareIBFReport MyParentReport
                {
                    get { return (SpareIBFReport)ParentReport; }
                }
                
                public TTReportField NewField112131;
                public TTReportField NewField1131211;
                public TTReportField YEAR1;
                public TTReportField NewField11121;
                public TTReportField NewField112111;
                public TTReportField NewField112121;
                public TTReportField NewField11221311;
                public TTReportField NewField11221331;
                public TTReportField YEAR0; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 10, 173, 31, false);
                    NewField112131.Name = "NewField112131";
                    NewField112131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112131.TextFont.Name = "Arial";
                    NewField112131.TextFont.Size = 9;
                    NewField112131.TextFont.Bold = true;
                    NewField112131.TextFont.CharSet = 162;
                    NewField112131.Value = @"
YEDEK PARÇANIN
KULLANILACAĞI
CİHAZIN ADI/
MARKA/ MODELİ";

                    NewField1131211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 10, 214, 31, false);
                    NewField1131211.Name = "NewField1131211";
                    NewField1131211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131211.TextFont.Name = "Arial";
                    NewField1131211.TextFont.Size = 9;
                    NewField1131211.TextFont.Bold = true;
                    NewField1131211.TextFont.CharSet = 162;
                    NewField1131211.Value = @"HANGİ AMAÇLA
TEDARİK EDİLECEĞİ
(BAKIM, ONARIM,
YENİLEŞTİRME VEYA
STOK)";

                    YEAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 10, 289, 31, false);
                    YEAR1.Name = "YEAR1";
                    YEAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR1.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR1.TextFont.Name = "Arial";
                    YEAR1.TextFont.Size = 9;
                    YEAR1.TextFont.Bold = true;
                    YEAR1.TextFont.CharSet = 162;
                    YEAR1.Value = @"
.... YILI
HARCANAN
MİKTAR
";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 18, 31, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Size = 9;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"

S.
NU.";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 10, 132, 31, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Size = 9;
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"
YEDEK PARÇA NU.
KATALOG NU.
NSN";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 10, 101, 31, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Size = 9;
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"

YEDEK PARÇA ADI / CİNSİ";

                    NewField11221311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 10, 247, 31, false);
                    NewField11221311.Name = "NewField11221311";
                    NewField11221311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221311.TextFont.Name = "Arial";
                    NewField11221311.TextFont.Size = 9;
                    NewField11221311.TextFont.Bold = true;
                    NewField11221311.TextFont.CharSet = 162;
                    NewField11221311.Value = @"

BİRİMİ
";

                    NewField11221331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 10, 268, 31, false);
                    NewField11221331.Name = "NewField11221331";
                    NewField11221331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221331.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221331.TextFont.Name = "Arial";
                    NewField11221331.TextFont.Size = 9;
                    NewField11221331.TextFont.Bold = true;
                    NewField11221331.TextFont.CharSet = 162;
                    NewField11221331.Value = @"
SAYMANLIK
DEPO
MEVCUDU";

                    YEAR0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 10, 230, 31, false);
                    YEAR0.Name = "YEAR0";
                    YEAR0.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR0.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR0.TextFont.Name = "Arial";
                    YEAR0.TextFont.Size = 9;
                    YEAR0.TextFont.Bold = true;
                    YEAR0.TextFont.CharSet = 162;
                    YEAR0.Value = @"....
YILI
İHTİYAÇ
MİKTARI
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112131.CalcValue = NewField112131.Value;
                    NewField1131211.CalcValue = NewField1131211.Value;
                    YEAR1.CalcValue = YEAR1.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField11221311.CalcValue = NewField11221311.Value;
                    NewField11221331.CalcValue = NewField11221331.Value;
                    YEAR0.CalcValue = YEAR0.Value;
                    return new TTReportObject[] { NewField112131,NewField1131211,YEAR1,NewField11121,NewField112111,NewField112121,NewField11221311,NewField11221331,YEAR0};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if(purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                YEAR0.CalcValue = ibfDemand.IBFYear.ToString() + "\nYILI\nİHTİYAÇ\nMİKTARI\n(ADET)";
                YEAR1.CalcValue = "\n" + (ibfDemand.IBFYear - 1).ToString() + " YILI\nHARCANAN\nMİKTAR";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                YEAR0.CalcValue = ibf.IBFYear.ToString() + "\nYILI\nİHTİYAÇ\nMİKTARI\n(ADET)";
                YEAR1.CalcValue = "\n" + (ibf.IBFYear - 1).ToString() + " YILI\nHARCANAN\nMİKTAR";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                YEAR0.CalcValue = lbPurchase.IBFYear.ToString() + "\nYILI\nİHTİYAÇ\nMİKTARI\n(ADET)";
                YEAR1.CalcValue = "\n" + (lbPurchase.IBFYear - 1).ToString() + " YILI\nHARCANAN\nMİKTAR";
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SpareIBFReport MyParentReport
                {
                    get { return (SpareIBFReport)ParentReport; }
                }
                
                public TTReportField PAGENO;
                public TTReportShape NewLine12; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 1, 159, 6, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENO.TextFont.Name = "Arial";
                    PAGENO.TextFont.Size = 8;
                    PAGENO.TextFont.CharSet = 162;
                    PAGENO.Value = @"A - {@pagenumber@}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENO.CalcValue = @"A - " + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENO};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public SpareIBFReport MyParentReport
            {
                get { return (SpareIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DEPENDENTSPARE { get {return Body().DEPENDENTSPARE;} }
            public TTReportField PURPOSE { get {return Body().PURPOSE;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField ACCOUNTANCYSTOCK { get {return Body().ACCOUNTANCYSTOCK;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
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
                public SpareIBFReport MyParentReport
                {
                    get { return (SpareIBFReport)ParentReport; }
                }
                
                public TTReportField DEPENDENTSPARE;
                public TTReportField PURPOSE;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField REQUESTAMOUNT;
                public TTReportField NSN;
                public TTReportField COUNT;
                public TTReportField MATERIAL;
                public TTReportField ACCOUNTANCYSTOCK;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine14;
                public TTReportShape NewLine16;
                public TTReportShape NewLine18;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    DEPENDENTSPARE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 173, 8, false);
                    DEPENDENTSPARE.Name = "DEPENDENTSPARE";
                    DEPENDENTSPARE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPENDENTSPARE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEPENDENTSPARE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEPENDENTSPARE.MultiLine = EvetHayirEnum.ehEvet;
                    DEPENDENTSPARE.WordBreak = EvetHayirEnum.ehEvet;
                    DEPENDENTSPARE.TextFont.Name = "Arial";
                    DEPENDENTSPARE.TextFont.Size = 9;
                    DEPENDENTSPARE.TextFont.CharSet = 162;
                    DEPENDENTSPARE.Value = @"";

                    PURPOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 0, 214, 8, false);
                    PURPOSE.Name = "PURPOSE";
                    PURPOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURPOSE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURPOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURPOSE.MultiLine = EvetHayirEnum.ehEvet;
                    PURPOSE.WordBreak = EvetHayirEnum.ehEvet;
                    PURPOSE.TextFont.Name = "Arial";
                    PURPOSE.TextFont.Size = 9;
                    PURPOSE.TextFont.CharSet = 162;
                    PURPOSE.Value = @"";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 289, 8, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT.TextFont.Size = 9;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#CONSUMPTIONAMOUNT#}{#CONSUMPTIONAMOUNT!GetIBFDetailInQuery#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 247, 8, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}{#DISTRIBUTIONTYPE!GetIBFDetailInQuery#}{#DISTRIBUTIONTYPE!GetLBPurchaseProjectDetailInQuery#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 230, 8, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 9;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#REQUESTAMOUNT#}{#REQUESTAMOUNT!GetIBFDetailInQuery#}{#APPROVEDAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 132, 8, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 9;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NSN#}{#NSN!GetIBFDetailInQuery#}{#NSN!GetLBPurchaseProjectDetailInQuery#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 8, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 9;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 100, 8, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 9;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}";

                    ACCOUNTANCYSTOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 268, 8, false);
                    ACCOUNTANCYSTOCK.Name = "ACCOUNTANCYSTOCK";
                    ACCOUNTANCYSTOCK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYSTOCK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANCYSTOCK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCYSTOCK.TextFont.Name = "Arial";
                    ACCOUNTANCYSTOCK.TextFont.Size = 9;
                    ACCOUNTANCYSTOCK.TextFont.CharSet = 162;
                    ACCOUNTANCYSTOCK.Value = @"{#ACCOUNTANCYSTOCK#}{#STORESTOCKS!GetIBFDetailInQuery#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 0, 18, 8, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 101, 0, 101, 8, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 132, 0, 132, 8, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 173, 0, 173, 8, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 214, 0, 214, 8, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 230, 0, 230, 8, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 0, 247, 8, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 0, 268, 8, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 8, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 8, 289, 8, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

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
                    DEPENDENTSPARE.CalcValue = @"";
                    PURPOSE.CalcValue = @"";
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ConsumptionAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ConsumptionAmount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.DistributionType) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DistributionType) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.DistributionType) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.RequestAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.RequestAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    NSN.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.NSN) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.NSN) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.NSN) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MATERIAL.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "");
                    ACCOUNTANCYSTOCK.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.AccountancyStock) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.StoreStocks) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { DEPENDENTSPARE,PURPOSE,CONSUMPTIONAMOUNT,DISTRIBUTIONTYPE,REQUESTAMOUNT,NSN,COUNT,MATERIAL,ACCOUNTANCYSTOCK,DETAILOBJECTID};
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
                    IBFDet_SparePartIn spare = (IBFDet_SparePartIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_SparePartIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(spare.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = spare.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = spare.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = spare.Amount.ToString();
                    
                    DEPENDENTSPARE.CalcValue = spare.DependentSpare;
                    PURPOSE.CalcValue = spare.Purpose;
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_SparePartIn spare = (ARD_SparePartIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_SparePartIn));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {                        
                        if(spare.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = spare.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = spare.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = spare.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = spare.LB_ApproveAmount.ToString();
                    
                    DEPENDENTSPARE.CalcValue = spare.DependentSpare;
                    PURPOSE.CalcValue = spare.Purpose;
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

        public SpareIBFReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SPAREIBFREPORT";
            Caption = "Tıbbi Cihaz Mekanik Yedek Parça İhtiyaçları Listesi";
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