
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
    /// Ayıklama Tutanağı
    /// </summary>
    public partial class ShellingProcedureReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ShellingProcedureReport MyParentReport
            {
                get { return (ShellingProcedureReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField DESC1 { get {return Footer().DESC1;} }
            public TTReportField IMZA1 { get {return Footer().IMZA1;} }
            public TTReportField IMZABASLIK11 { get {return Footer().IMZABASLIK11;} }
            public TTReportField IMZA12 { get {return Footer().IMZA12;} }
            public TTReportField IMZABASLIK12 { get {return Footer().IMZABASLIK12;} }
            public TTReportField IMZA13 { get {return Footer().IMZA13;} }
            public TTReportField IMZA14 { get {return Footer().IMZA14;} }
            public TTReportField IMZABASLIK13 { get {return Footer().IMZABASLIK13;} }
            public TTReportField IMZABASLIK14 { get {return Footer().IMZABASLIK14;} }
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
                public ShellingProcedureReport MyParentReport
                {
                    get { return (ShellingProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 23;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 292, 24, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"TAŞINIR MAL AYIKLAMA TUTANAĞI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { NewField111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //            
//                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
//                    {
//                        ProductionConsumptionDocument productionConsumptionDocument = (ProductionConsumptionDocument)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ProductionConsumptionDocument));
//                        SIPARISADIVENUMARASI.CalcValue = productionConsumptionDocument.StockActionID.Value.Value.ToString();
//                        REGISTRATIONNUMBER.CalcValue = productionConsumptionDocument.SequenceNumber + " " + productionConsumptionDocument.RegistrationNumber;
//                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ShellingProcedureReport MyParentReport
                {
                    get { return (ShellingProcedureReport)ParentReport; }
                }
                
                public TTReportField DESC1;
                public TTReportField IMZA1;
                public TTReportField IMZABASLIK11;
                public TTReportField IMZA12;
                public TTReportField IMZABASLIK12;
                public TTReportField IMZA13;
                public TTReportField IMZA14;
                public TTReportField IMZABASLIK13;
                public TTReportField IMZABASLIK14;
                public TTReportShape NewLine1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 44;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 292, 14, false);
                    DESC1.Name = "DESC1";
                    DESC1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC1.MultiLine = EvetHayirEnum.ehEvet;
                    DESC1.NoClip = EvetHayirEnum.ehEvet;
                    DESC1.WordBreak = EvetHayirEnum.ehEvet;
                    DESC1.TextFont.Size = 11;
                    DESC1.TextFont.CharSet = 162;
                    DESC1.Value = @".............................. tarih ve ................. numaralı Muayene Komisyonu/Teknik Muayene Komisyonu raporlarına dayanarak .............................. tarihinde sayım ve tartısı yapılan yukarıda belirtilen taşınır malların ayıklanması sonucunda elde edilenler tarafımızdan tespit edilmiştir.";

                    IMZA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 21, 132, 42, false);
                    IMZA1.Name = "IMZA1";
                    IMZA1.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA1.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA1.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA1.TextFont.Size = 9;
                    IMZA1.TextFont.CharSet = 162;
                    IMZA1.Value = @"";

                    IMZABASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 15, 132, 20, false);
                    IMZABASLIK11.Name = "IMZABASLIK11";
                    IMZABASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK11.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK11.TextFont.Bold = true;
                    IMZABASLIK11.TextFont.CharSet = 162;
                    IMZABASLIK11.Value = @"";

                    IMZA12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 21, 192, 42, false);
                    IMZA12.Name = "IMZA12";
                    IMZA12.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA12.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA12.TextFont.CharSet = 162;
                    IMZA12.Value = @"";

                    IMZABASLIK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 15, 192, 20, false);
                    IMZABASLIK12.Name = "IMZABASLIK12";
                    IMZABASLIK12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK12.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK12.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK12.TextFont.Bold = true;
                    IMZABASLIK12.TextFont.CharSet = 162;
                    IMZABASLIK12.Value = @"";

                    IMZA13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 21, 240, 42, false);
                    IMZA13.Name = "IMZA13";
                    IMZA13.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA13.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA13.TextFont.CharSet = 162;
                    IMZA13.Value = @"";

                    IMZA14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 21, 292, 42, false);
                    IMZA14.Name = "IMZA14";
                    IMZA14.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA14.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA14.TextFont.CharSet = 162;
                    IMZA14.Value = @"";

                    IMZABASLIK13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 15, 240, 20, false);
                    IMZABASLIK13.Name = "IMZABASLIK13";
                    IMZABASLIK13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK13.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK13.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK13.TextFont.Bold = true;
                    IMZABASLIK13.TextFont.CharSet = 162;
                    IMZABASLIK13.Value = @"";

                    IMZABASLIK14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 15, 292, 20, false);
                    IMZABASLIK14.Name = "IMZABASLIK14";
                    IMZABASLIK14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK14.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK14.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK14.TextFont.Bold = true;
                    IMZABASLIK14.TextFont.CharSet = 162;
                    IMZABASLIK14.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 292, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESC1.CalcValue = DESC1.Value;
                    IMZA1.CalcValue = IMZA1.Value;
                    IMZABASLIK11.CalcValue = IMZABASLIK11.Value;
                    IMZA12.CalcValue = IMZA12.Value;
                    IMZABASLIK12.CalcValue = IMZABASLIK12.Value;
                    IMZA13.CalcValue = IMZA13.Value;
                    IMZA14.CalcValue = IMZA14.Value;
                    IMZABASLIK13.CalcValue = IMZABASLIK13.Value;
                    IMZABASLIK14.CalcValue = IMZABASLIK14.Value;
                    return new TTReportObject[] { DESC1,IMZA1,IMZABASLIK11,IMZA12,IMZABASLIK12,IMZA13,IMZA14,IMZABASLIK13,IMZABASLIK14};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                if (stockAction.StockActionInspection != null)
                {
                    int i = 1;
                    foreach (StockActionInspectionDetail stockActionInspectionDetail in stockAction.StockActionInspection.StockActionInspectionDetails)
                    {
                        string signDesc = string.Empty;
                        string vekil = string.Empty;
                        signDesc = stockActionInspectionDetail.InspectionUser.Name + "\r\n";
                        if (stockActionInspectionDetail.InspectionUser.MilitaryClass != null)
                            signDesc += stockActionInspectionDetail.InspectionUser.MilitaryClass.ShortName;
                        if (stockActionInspectionDetail.InspectionUser.Rank != null)
                            signDesc += stockActionInspectionDetail.InspectionUser.Rank.ShortName;
                        signDesc += "(" + stockActionInspectionDetail.InspectionUser.EmploymentRecordID + ")";

                        string gorev = stockActionInspectionDetail.ObjectDef.AllPropertyDefs["INSPECTIONUSERTYPE"].DataType.EnumValueDefs[(int)stockActionInspectionDetail.InspectionUserType.Value].DisplayText;
                        if(i.Equals(1))
                        {
                            this.IMZABASLIK11.Value = gorev;
                            this.IMZA1.Value = signDesc;
                        }

                        if (i.Equals(2))
                        {
                            this.IMZABASLIK12.Value = gorev;
                            this.IMZA12.Value = signDesc;
                        }

                        if (i.Equals(3))
                        {
                            this.IMZABASLIK13.Value = gorev;
                            this.IMZA13.Value = signDesc;
                        }

                        if (i.Equals(4))
                        {
                            this.IMZABASLIK14.Value = gorev;
                            this.IMZA14.Value = signDesc;
                        }
                        i++;
                    }
                }
                
            }
            
            //                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            //                    {
            //                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
            //                        if (stockAction is ProductionConsumptionDocument)
            //                        {
            //                            ProductionConsumptionDocument productionConsumptionDocument = (ProductionConsumptionDocument)stockAction;
            //                            this.DESCLEFT.Value = productionConsumptionDocument.StartDate.Value.ToShortDateString() + " - " + productionConsumptionDocument.EndDate.Value.ToShortDateString() + " tarihleri arasında " + productionConsumptionDocument.Store.Name + " için tüketilenler, üretilen/elde edilenlerin yukarıda gösterildiği beyan olunur.";
            //                        }
            //                        else if (stockAction is MainStoreProductionConsumptionDocument)
            //                        {
            //                            MainStoreProductionConsumptionDocument mainStoreProductionConsumptionDocument = (MainStoreProductionConsumptionDocument)stockAction;
            //                            this.DESCLEFT.Value = mainStoreProductionConsumptionDocument.StartDate.Value.ToShortDateString() + " - " + mainStoreProductionConsumptionDocument.EndDate.Value.ToShortDateString() + " tarihleri arasında " + mainStoreProductionConsumptionDocument.Store.Name + " için tüketilenler, üretilen/elde edilenlerin yukarıda gösterildiği beyan olunur.";
            //                        }
            //                        else
            //                        {
            //                            this.DESCLEFT.Value = "....../...../......  -  ....../...../......  tarihleri arasında .............................................. için tüketilenler, üretilen/elde edilenlerin yukarıda gösterildiği beyan olunur.";
            //                        }
//
            //                        foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
            //                        {
            //                            string signDesc = string.Empty;
            //                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(SignUserTypeEnum).Name];
            //                            signDesc += dataType.EnumValueDefs[(int)stockActionSignDetail.SignUserType.Value].DisplayText;
            //                            if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
            //                                signDesc += " Vek.";
//
            //                            signDesc += "\r\n" + stockActionSignDetail.SignUser.Name + "\r\n";
//
            //                            if (stockActionSignDetail.SignUser.MilitaryClass != null)
            //                                signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
//
            //                            if (stockActionSignDetail.SignUser.Rank != null)
            //                                signDesc += stockActionSignDetail.SignUser.Rank.ShortName + "\r\n";
//
            //                            signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
            //                            if (stockActionSignDetail.SignUserType == SignUserTypeEnum.MalSaymani)
            //                            {
            //                                this.MALSAYMANI.Value = signDesc;
            //                                continue;
            //                            }
            //                            else
            //                            {
            //                                if (string.IsNullOrEmpty(this.IMZA1.Value))
            //                                {
            //                                    this.IMZA1.Value = signDesc;
            //                                    continue;
            //                                }
            //                                if (string.IsNullOrEmpty(this.IMZA2.Value))
            //                                {
            //                                    this.IMZA2.Value = signDesc;
            //                                    continue;
            //                                }
            //                                if (string.IsNullOrEmpty(this.IMZA3.Value))
            //                                {
            //                                    this.IMZA3.Value = signDesc;
            //                                    continue;
            //                                }
            //                                if (string.IsNullOrEmpty(this.IMZA4.Value))
            //                                {
            //                                    this.IMZA4.Value = signDesc;
            //                                    continue;
            //                                }
            //                                if (string.IsNullOrEmpty(this.IMZA5.Value))
            //                                {
            //                                    this.IMZA5.Value = signDesc;
            //                                    continue;
            //                                }
            //                                if (string.IsNullOrEmpty(this.IMZA6.Value))
            //                                {
            //                                    this.IMZA6.Value = signDesc;
            //                                    continue;
            //                                }
            //                            }
            //                        }
//
            //                    }
#endregion PARTA FOOTER_PreScript
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ShellingProcedureReport MyParentReport
            {
                get { return (ShellingProcedureReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField1111112 { get {return Header().NewField1111112;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField1111113 { get {return Header().NewField1111113;} }
            public TTReportField NewField11111112 { get {return Header().NewField11111112;} }
            public TTReportField NewField12111112 { get {return Header().NewField12111112;} }
            public TTReportField NewField111111112 { get {return Header().NewField111111112;} }
            public TTReportField OUTITEMCOUNT { get {return Footer().OUTITEMCOUNT;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField INITEMCOUNT { get {return Footer().INITEMCOUNT;} }
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
                public ShellingProcedureReport MyParentReport
                {
                    get { return (ShellingProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111;
                public TTReportField NewField11112;
                public TTReportField NewField1111111;
                public TTReportField NewField1111112;
                public TTReportField NewField11111111;
                public TTReportField NewField1111113;
                public TTReportField NewField11111112;
                public TTReportField NewField12111112;
                public TTReportField NewField111111112; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 23;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 23, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"
S. Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 6, 51, 23, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Stok Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 157, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Sayılan ve Tartılan Taşınır Mal/Malların";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 292, 6, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112.TextFont.Size = 11;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Elde Edilen Taşınır Mal/Malların";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 6, 127, 23, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Size = 11;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"
Cins ve Özelliği";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 6, 157, 23, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111112.TextFont.Size = 11;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Miktarı";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 6, 142, 23, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111111.TextFont.Size = 11;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"
Ölçü Birimi";

                    NewField1111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 6, 188, 23, false);
                    NewField1111113.Name = "NewField1111113";
                    NewField1111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111113.TextFont.Size = 11;
                    NewField1111113.TextFont.Bold = true;
                    NewField1111113.TextFont.CharSet = 162;
                    NewField1111113.Value = @"Stok Nu.";

                    NewField11111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 6, 262, 23, false);
                    NewField11111112.Name = "NewField11111112";
                    NewField11111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111112.TextFont.Size = 11;
                    NewField11111112.TextFont.Bold = true;
                    NewField11111112.TextFont.CharSet = 162;
                    NewField11111112.Value = @"
Cins ve Özelliği";

                    NewField12111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 6, 292, 23, false);
                    NewField12111112.Name = "NewField12111112";
                    NewField12111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12111112.TextFont.Size = 11;
                    NewField12111112.TextFont.Bold = true;
                    NewField12111112.TextFont.CharSet = 162;
                    NewField12111112.Value = @"Miktarı";

                    NewField111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 6, 277, 23, false);
                    NewField111111112.Name = "NewField111111112";
                    NewField111111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111112.TextFont.Size = 11;
                    NewField111111112.TextFont.Bold = true;
                    NewField111111112.TextFont.CharSet = 162;
                    NewField111111112.Value = @"
Ölçü Birimi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField1111113.CalcValue = NewField1111113.Value;
                    NewField11111112.CalcValue = NewField11111112.Value;
                    NewField12111112.CalcValue = NewField12111112.Value;
                    NewField111111112.CalcValue = NewField111111112.Value;
                    return new TTReportObject[] { NewField11111,NewField111111,NewField1111,NewField11112,NewField1111111,NewField1111112,NewField11111111,NewField1111113,NewField11111112,NewField12111112,NewField111111112};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ShellingProcedureReport MyParentReport
                {
                    get { return (ShellingProcedureReport)ParentReport; }
                }
                
                public TTReportField OUTITEMCOUNT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField INITEMCOUNT; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    OUTITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 157, 5, false);
                    OUTITEMCOUNT.Name = "OUTITEMCOUNT";
                    OUTITEMCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTITEMCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OUTITEMCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OUTITEMCOUNT.TextFont.CharSet = 162;
                    OUTITEMCOUNT.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 292, 0, 292, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    INITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 292, 5, false);
                    INITEMCOUNT.Name = "INITEMCOUNT";
                    INITEMCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INITEMCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    INITEMCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INITEMCOUNT.TextFont.CharSet = 162;
                    INITEMCOUNT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OUTITEMCOUNT.CalcValue = @"";
                    INITEMCOUNT.CalcValue = @"";
                    return new TTReportObject[] { OUTITEMCOUNT,INITEMCOUNT};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        ShellingProcedure shellingProcedure = (ShellingProcedure)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ShellingProcedure));

                        string closer = "/////////////////////////////////////////////////////////////////////////////////////////////////////////";
                        if (shellingProcedure.ShellingProcedureOutMaterials.Count > 0)
                        {
                            int outItemCount = shellingProcedure.ShellingProcedureOutMaterials.Count;
                            OUTITEMCOUNT.Visible = EvetHayirEnum.ehEvet;
                            OUTITEMCOUNT.CalcValue = closer + "Yalnız " + outItemCount + "(" + TTReportTool.Common.SpellNumber(outItemCount.ToString()) + ") kalemdir." + closer;
                        }
                        else
                        {
                            OUTITEMCOUNT.Visible = EvetHayirEnum.ehHayir;
                        }

                        if (shellingProcedure.ShellingProcedureInMaterials.Count > 0)
                        {
                            int inItemCount = shellingProcedure.ShellingProcedureInMaterials.Count;
                            INITEMCOUNT.Visible = EvetHayirEnum.ehEvet;
                            INITEMCOUNT.CalcValue = closer + "Yalnız " + inItemCount + "(" + TTReportTool.Common.SpellNumber(inItemCount.ToString()) + ") kalemdir." + closer;
                        }
                        else
                        {
                            INITEMCOUNT.Visible = EvetHayirEnum.ehHayir;
                        }

                    }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ShellingProcedureReport MyParentReport
            {
                get { return (ShellingProcedureReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CONSUMPTIONDISTRIBUTIONTYPE { get {return Body().CONSUMPTIONDISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField CONSUMPTIONMATERIALDESCRIPTION { get {return Body().CONSUMPTIONMATERIALDESCRIPTION;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField OUTSTOCKACTIONDETAILOBJECTID { get {return Body().OUTSTOCKACTIONDETAILOBJECTID;} }
            public TTReportField INSTOCKACTIONDETAILOBJECTID { get {return Body().INSTOCKACTIONDETAILOBJECTID;} }
            public TTReportField CONSUMPTIONMATERIALNATOSTOCKNO { get {return Body().CONSUMPTIONMATERIALNATOSTOCKNO;} }
            public TTReportField MATERIALNATOSTOCKNO { get {return Body().MATERIALNATOSTOCKNO;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<StockAction.StockActionInDetailsReportQuery_Class>("StockActionInDetailsReportQuery", StockAction.StockActionInDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ShellingProcedureReport MyParentReport
                {
                    get { return (ShellingProcedureReport)ParentReport; }
                }
                
                public TTReportField CONSUMPTIONDISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField CONSUMPTIONMATERIALDESCRIPTION;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField OUTSTOCKACTIONDETAILOBJECTID;
                public TTReportField INSTOCKACTIONDETAILOBJECTID;
                public TTReportField CONSUMPTIONMATERIALNATOSTOCKNO;
                public TTReportField MATERIALNATOSTOCKNO;
                public TTReportField ORDERNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CONSUMPTIONDISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 142, 5, false);
                    CONSUMPTIONDISTRIBUTIONTYPE.Name = "CONSUMPTIONDISTRIBUTIONTYPE";
                    CONSUMPTIONDISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONDISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONDISTRIBUTIONTYPE.TextFormat = @"#,##0.#0";
                    CONSUMPTIONDISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSUMPTIONDISTRIBUTIONTYPE.TextFont.Size = 8;
                    CONSUMPTIONDISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    CONSUMPTIONDISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE!StockActionOutDetailsReportQuery#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 292, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.####";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 277, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 262, 5, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 8;
                    MATERIALDESCRIPTION.TextFont.CharSet = 162;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#}";

                    CONSUMPTIONMATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 127, 5, false);
                    CONSUMPTIONMATERIALDESCRIPTION.Name = "CONSUMPTIONMATERIALDESCRIPTION";
                    CONSUMPTIONMATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALDESCRIPTION.TextFont.Size = 8;
                    CONSUMPTIONMATERIALDESCRIPTION.TextFont.CharSet = 162;
                    CONSUMPTIONMATERIALDESCRIPTION.Value = @"{#MATERIALNAME!StockActionOutDetailsReportQuery#}";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 157, 5, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.TextFormat = @"#,##0.####";
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSUMPTIONAMOUNT.TextFont.Size = 8;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#AMOUNT!StockActionOutDetailsReportQuery#}";

                    OUTSTOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 2, 331, 7, false);
                    OUTSTOCKACTIONDETAILOBJECTID.Name = "OUTSTOCKACTIONDETAILOBJECTID";
                    OUTSTOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OUTSTOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTSTOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID!StockActionOutDetailsReportQuery#}";

                    INSTOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 2, 360, 7, false);
                    INSTOCKACTIONDETAILOBJECTID.Name = "INSTOCKACTIONDETAILOBJECTID";
                    INSTOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    INSTOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    INSTOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    CONSUMPTIONMATERIALNATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 51, 5, false);
                    CONSUMPTIONMATERIALNATOSTOCKNO.Name = "CONSUMPTIONMATERIALNATOSTOCKNO";
                    CONSUMPTIONMATERIALNATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALNATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALNATOSTOCKNO.TextFont.Size = 8;
                    CONSUMPTIONMATERIALNATOSTOCKNO.TextFont.CharSet = 162;
                    CONSUMPTIONMATERIALNATOSTOCKNO.Value = @"{#NATOSTOCKNO!StockActionOutDetailsReportQuery#}";

                    MATERIALNATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 188, 5, false);
                    MATERIALNATOSTOCKNO.Name = "MATERIALNATOSTOCKNO";
                    MATERIALNATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNATOSTOCKNO.TextFont.Size = 8;
                    MATERIALNATOSTOCKNO.TextFont.CharSet = 162;
                    MATERIALNATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@} ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionInDetailsReportQuery_Class dataset_StockActionInDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionInDetailsReportQuery_Class>(0);
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(1);
                    CONSUMPTIONDISTRIBUTIONTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.DistributionType) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Materialname) : "");
                    CONSUMPTIONMATERIALDESCRIPTION.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "");
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    OUTSTOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    INSTOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Stockactiondetailobjectid) : "");
                    CONSUMPTIONMATERIALNATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    MATERIALNATOSTOCKNO.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.NATOStockNO) : "");
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    return new TTReportObject[] { CONSUMPTIONDISTRIBUTIONTYPE,AMOUNT,DISTRIBUTIONTYPE,MATERIALDESCRIPTION,CONSUMPTIONMATERIALDESCRIPTION,CONSUMPTIONAMOUNT,OUTSTOCKACTIONDETAILOBJECTID,INSTOCKACTIONDETAILOBJECTID,CONSUMPTIONMATERIALNATOSTOCKNO,MATERIALNATOSTOCKNO,ORDERNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                        StockAction stockAction = MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction)) as StockAction;
//                        if (stockAction is ProductionConsumptionDocument)
//                        {
//                            if (string.IsNullOrEmpty(OUTSTOCKACTIONDETAILOBJECTID.CalcValue) == false && TTUtils.Globals.IsGuid(OUTSTOCKACTIONDETAILOBJECTID.CalcValue))
//                            {
//                                ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = (ProductionConsumptionDocumentMaterialOut)MyParentReport.ReportObjectContext.GetObject(new Guid(OUTSTOCKACTIONDETAILOBJECTID.CalcValue), typeof(ProductionConsumptionDocumentMaterialOut));
//                                this.OUTUNITPRICE.CalcValue = productionConsumptionDocumentMaterialOut.UnitPrice.ToString();
//                                this.OUTPRICE.CalcValue = productionConsumptionDocumentMaterialOut.Price.ToString();
//
//                                //double totalPrice = 0;
//                                //foreach (StockCollectedTrx stockCollectedTrx in stockActionDetailOut.StockCollectedTrxs)
//                                //    totalPrice += stockCollectedTrx.StockTransaction.UnitPrice.Value * stockCollectedTrx.StockTransaction.Amount.Value;
//
//                                //this.OUTPRICE.CalcValue = totalPrice.ToString();
//                                //this.OUTUNITPRICE.CalcValue = (totalPrice / stockActionDetailOut.Amount.Value).ToString();
//                            }
//
//                            if (string.IsNullOrEmpty(INSTOCKACTIONDETAILOBJECTID.CalcValue) == false && TTUtils.Globals.IsGuid(INSTOCKACTIONDETAILOBJECTID.CalcValue))
//                            {
//                                ProductionConsumptionDocumentMaterialIn productionConsumptionDocumentMaterialIn = (ProductionConsumptionDocumentMaterialIn)MyParentReport.ReportObjectContext.GetObject(new Guid(INSTOCKACTIONDETAILOBJECTID.CalcValue), typeof(ProductionConsumptionDocumentMaterialIn));
//                                this.UNITPRICE.CalcValue = productionConsumptionDocumentMaterialIn.UnitPrice.ToString();
//                                this.PRICE.CalcValue = productionConsumptionDocumentMaterialIn.Price.ToString();
//                            }
//                        }
//                        else
//                        {
//                        }
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

        public ShellingProcedureReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SHELLINGPROCEDUREREPORT";
            Caption = "Ayıklama Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 256;
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