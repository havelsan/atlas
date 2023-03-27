
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
    /// Ekli Liste
    /// </summary>
    public partial class EkliListeReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public EkliListeReport MyParentReport
            {
                get { return (EkliListeReport)ParentReport; }
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
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
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
                public EkliListeReport MyParentReport
                {
                    get { return (EkliListeReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME; 
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
                    REPORTNAME.Value = @"İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN ... EK FORMATI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    return new TTReportObject[] { REPORTNAME};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if (purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                switch (ibfDemand.IBFType.Value)
                {
                    case IBFTypeEnum.PiyasaIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN PİYASA İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Asi:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN AŞI MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.BasiliEvrak:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN BASILI EVRAK MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.XXXXXXIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN XXXXXX İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Kit:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN KİT MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.OrduIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN XXXXXX İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Serum:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN SERUM MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.TibbiCihaz:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN TIBBİ CİHAZ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.TibbiSarf:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN TIBBİ SARF MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.YedekParca:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN YEDEK PARÇA MALZEME EK FORMATI";
                        break;
                        
                    default:
                        break;
                }
            }
            else if (purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                switch (ibf.IBFType.Value)
                {
                    case IBFTypeEnum.PiyasaIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN PİYASA İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Asi:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN AŞI MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.BasiliEvrak:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN BASILI EVRAK MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.XXXXXXIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN XXXXXX İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Kit:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN KİT MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.OrduIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN XXXXXX İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Serum:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN SERUM MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.TibbiCihaz:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN TIBBİ CİHAZ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.TibbiSarf:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN TIBBİ SARF MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.YedekParca:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN YEDEK PARÇA MALZEME EK FORMATI";
                        break;
                        
                    default:
                        break;
                }
            }
            else if (purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                switch (lbPurchase.IBFType.Value)
                {
                    case IBFTypeEnum.PiyasaIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN PİYASA İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Asi:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN AŞI MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.BasiliEvrak:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN BASILI EVRAK MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.XXXXXXIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN XXXXXX İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Kit:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN KİT MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.OrduIlac:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN XXXXXX İLAÇ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.Serum:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN SERUM MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.TibbiCihaz:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN TIBBİ CİHAZ MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.TibbiSarf:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN TIBBİ SARF MALZEME EK FORMATI";
                        break;
                        
                    case IBFTypeEnum.YedekParca:
                        REPORTNAME.CalcValue = "İBF HAZIRLAMA TABLOSUNDA YER ALMAYAN YEDEK PARÇA MALZEME EK FORMATI";
                        break;
                        
                    default:
                        break;
                }
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public EkliListeReport MyParentReport
                {
                    get { return (EkliListeReport)ParentReport; }
                }
                
                public TTReportShape NewLine121; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public EkliListeReport MyParentReport
            {
                get { return (EkliListeReport)ParentReport; }
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
            public TTReportField NewField112141 { get {return Header().NewField112141;} }
            public TTReportField NewField1141211 { get {return Header().NewField1141211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112121 { get {return Header().NewField112121;} }
            public TTReportField NewField11221331 { get {return Header().NewField11221331;} }
            public TTReportField NewField11221341 { get {return Header().NewField11221341;} }
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
                public EkliListeReport MyParentReport
                {
                    get { return (EkliListeReport)ParentReport; }
                }
                
                public TTReportField NewField112131;
                public TTReportField NewField1131211;
                public TTReportField NewField112141;
                public TTReportField NewField1141211;
                public TTReportField NewField11121;
                public TTReportField NewField112121;
                public TTReportField NewField11221331;
                public TTReportField NewField11221341; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 10, 161, 19, false);
                    NewField112131.Name = "NewField112131";
                    NewField112131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112131.TextFont.Name = "Arial";
                    NewField112131.TextFont.Size = 9;
                    NewField112131.TextFont.Bold = true;
                    NewField112131.TextFont.CharSet = 162;
                    NewField112131.Value = @"TEKNİK ŞARTNAME ADI
VE NU.SU";

                    NewField1131211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 10, 205, 19, false);
                    NewField1131211.Name = "NewField1131211";
                    NewField1131211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131211.TextFont.Name = "Arial";
                    NewField1131211.TextFont.Size = 9;
                    NewField1131211.TextFont.Bold = true;
                    NewField1131211.TextFont.CharSet = 162;
                    NewField1131211.Value = @"AÇIKLAMA/İDARİ
HUSUSLAR";

                    NewField112141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 10, 268, 19, false);
                    NewField112141.Name = "NewField112141";
                    NewField112141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112141.TextFont.Name = "Arial";
                    NewField112141.TextFont.Size = 9;
                    NewField112141.TextFont.Bold = true;
                    NewField112141.TextFont.CharSet = 162;
                    NewField112141.Value = @"BİRİM
FİYATI";

                    NewField1141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 10, 289, 19, false);
                    NewField1141211.Name = "NewField1141211";
                    NewField1141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141211.TextFont.Name = "Arial";
                    NewField1141211.TextFont.Size = 9;
                    NewField1141211.TextFont.Bold = true;
                    NewField1141211.TextFont.CharSet = 162;
                    NewField1141211.Value = @"İSTEK
MİKTARI";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 19, 19, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Size = 9;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"S.
NU.";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 10, 113, 19, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Size = 9;
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"MALZEMENİN ADI";

                    NewField11221331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 10, 226, 19, false);
                    NewField11221331.Name = "NewField11221331";
                    NewField11221331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221331.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221331.TextFont.Name = "Arial";
                    NewField11221331.TextFont.Size = 9;
                    NewField11221331.TextFont.Bold = true;
                    NewField11221331.TextFont.CharSet = 162;
                    NewField11221331.Value = @"AMBALAJ
ŞEKLİ";

                    NewField11221341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 10, 247, 19, false);
                    NewField11221341.Name = "NewField11221341";
                    NewField11221341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221341.TextFont.Name = "Arial";
                    NewField11221341.TextFont.Size = 9;
                    NewField11221341.TextFont.Bold = true;
                    NewField11221341.TextFont.CharSet = 162;
                    NewField11221341.Value = @"ÖLÇÜ
BİRİMİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112131.CalcValue = NewField112131.Value;
                    NewField1131211.CalcValue = NewField1131211.Value;
                    NewField112141.CalcValue = NewField112141.Value;
                    NewField1141211.CalcValue = NewField1141211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField11221331.CalcValue = NewField11221331.Value;
                    NewField11221341.CalcValue = NewField11221341.Value;
                    return new TTReportObject[] { NewField112131,NewField1131211,NewField112141,NewField1141211,NewField11121,NewField112121,NewField11221331,NewField11221341};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public EkliListeReport MyParentReport
                {
                    get { return (EkliListeReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public EkliListeReport MyParentReport
            {
                get { return (EkliListeReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField SPECIFICATION { get {return Body().SPECIFICATION;} }
            public TTReportField DISTRIBUTIONTYPE1 { get {return Body().DISTRIBUTIONTYPE1;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
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
                list[0] = new TTReportNqlData<AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class>("GetAnnualRequirementDetailOutOfListQuery", AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class>("GetIBFDemandDetailOutQuery", IBFDetDetailOut.GetIBFDemandDetailOutQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[2] = new TTReportNqlData<LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class>("GetLBPurchaseDetailOutQuery", LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public EkliListeReport MyParentReport
                {
                    get { return (EkliListeReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField SPECIFICATION;
                public TTReportField DISTRIBUTIONTYPE1;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField COUNT;
                public TTReportField MATERIAL;
                public TTReportField REQUESTAMOUNT;
                public TTReportField UNITPRICE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine14;
                public TTReportShape NewLine16;
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

                    Height = 17;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 205, 9, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}{#DETAILDESCRIPTION!GetIBFDemandDetailOutQuery#}";

                    SPECIFICATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 161, 9, false);
                    SPECIFICATION.Name = "SPECIFICATION";
                    SPECIFICATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIFICATION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPECIFICATION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPECIFICATION.MultiLine = EvetHayirEnum.ehEvet;
                    SPECIFICATION.WordBreak = EvetHayirEnum.ehEvet;
                    SPECIFICATION.TextFont.Name = "Arial";
                    SPECIFICATION.TextFont.Size = 9;
                    SPECIFICATION.TextFont.CharSet = 162;
                    SPECIFICATION.Value = @"";

                    DISTRIBUTIONTYPE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 0, 247, 9, false);
                    DISTRIBUTIONTYPE1.Name = "DISTRIBUTIONTYPE1";
                    DISTRIBUTIONTYPE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE1.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE1.TextFont.Size = 9;
                    DISTRIBUTIONTYPE1.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE1.Value = @"";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 226, 9, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE!GetLBPurchaseDetailOutQuery#}{#DISTRIBUTIONTYPE!GetIBFDemandDetailOutQuery#}{#DISTRIBUTIONTYPE#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 9, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 9;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 112, 9, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 9;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL!GetLBPurchaseDetailOutQuery#}{#MATERIAL!GetIBFDemandDetailOutQuery#}{#MATERIAL#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 289, 9, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 9;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#APPROVEDAMOUNT!GetLBPurchaseDetailOutQuery#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 268, 9, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.Size = 9;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE!GetIBFDemandDetailOutQuery#}{#UNITPRICE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 9, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 9, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 113, 0, 113, 9, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 161, 0, 161, 9, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 205, 0, 205, 9, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 226, 0, 226, 9, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 0, 247, 9, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 0, 268, 9, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine24.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 9, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine25.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 9, 289, 9, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
                    DETAILOBJECTID.Name = "DETAILOBJECTID";
                    DETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DETAILOBJECTID.Value = @"{#OBJECTID!GetIBFDemandDetailOutQuery#}{#OBJECTID!GetLBPurchaseDetailOutQuery#}{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class dataset_GetAnnualRequirementDetailOutOfListQuery = ParentGroup.rsGroup.GetCurrentRecord<AnnualRequirementDetailOutOfList.GetAnnualRequirementDetailOutOfListQuery_Class>(0);
                    IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class dataset_GetIBFDemandDetailOutQuery = ParentGroup.rsGroup.GetCurrentRecord<IBFDetDetailOut.GetIBFDemandDetailOutQuery_Class>(1);
                    LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class dataset_GetLBPurchaseDetailOutQuery = ParentGroup.rsGroup.GetCurrentRecord<LBPurchaseProjectDetailOutOfList.GetLBPurchaseDetailOutQuery_Class>(2);
                    DESCRIPTION.CalcValue = (dataset_GetAnnualRequirementDetailOutOfListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailOutOfListQuery.Description) : "") + (dataset_GetIBFDemandDetailOutQuery != null ? Globals.ToStringCore(dataset_GetIBFDemandDetailOutQuery.DetailDescription) : "");
                    SPECIFICATION.CalcValue = @"";
                    DISTRIBUTIONTYPE1.CalcValue = @"";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetLBPurchaseDetailOutQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseDetailOutQuery.DistributionType) : "") + (dataset_GetIBFDemandDetailOutQuery != null ? Globals.ToStringCore(dataset_GetIBFDemandDetailOutQuery.DistributionType) : "") + (dataset_GetAnnualRequirementDetailOutOfListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailOutOfListQuery.DistributionType) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MATERIAL.CalcValue = (dataset_GetLBPurchaseDetailOutQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseDetailOutQuery.Material) : "") + (dataset_GetIBFDemandDetailOutQuery != null ? Globals.ToStringCore(dataset_GetIBFDemandDetailOutQuery.Material) : "") + (dataset_GetAnnualRequirementDetailOutOfListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailOutOfListQuery.Material) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetLBPurchaseDetailOutQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseDetailOutQuery.ApprovedAmount) : "");
                    UNITPRICE.CalcValue = (dataset_GetIBFDemandDetailOutQuery != null ? Globals.ToStringCore(dataset_GetIBFDemandDetailOutQuery.Unitprice) : "") + (dataset_GetAnnualRequirementDetailOutOfListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailOutOfListQuery.Unitprice) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetIBFDemandDetailOutQuery != null ? Globals.ToStringCore(dataset_GetIBFDemandDetailOutQuery.ObjectID) : "") + (dataset_GetLBPurchaseDetailOutQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseDetailOutQuery.ObjectID) : "") + (dataset_GetAnnualRequirementDetailOutOfListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailOutOfListQuery.ObjectID) : "");
                    return new TTReportObject[] { DESCRIPTION,SPECIFICATION,DISTRIBUTIONTYPE1,DISTRIBUTIONTYPE,COUNT,MATERIAL,REQUESTAMOUNT,UNITPRICE,DETAILOBJECTID};
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
                    IBFDetDetailOut detailOut = (IBFDetDetailOut)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDetDetailOut));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(detailOut.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = detailOut.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = detailOut.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = detailOut.Amount.ToString();
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    AnnualRequirementDetailOutOfList detailOut = (AnnualRequirementDetailOutOfList)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(AnnualRequirementDetailOutOfList));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {                        
                        if(detailOut.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = detailOut.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = detailOut.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = detailOut.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = detailOut.LB_ApproveAmount.ToString();
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

        public EkliListeReport()
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
            Name = "EKLILISTEREPORT";
            Caption = "Ekli Liste";
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