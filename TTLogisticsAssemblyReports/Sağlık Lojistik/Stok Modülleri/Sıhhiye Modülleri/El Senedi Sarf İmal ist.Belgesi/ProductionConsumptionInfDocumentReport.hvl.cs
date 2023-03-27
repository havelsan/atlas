
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
    /// El Senedi Sarf İmal İstihsal Belgesi
    /// </summary>
    public partial class ProductionConsumptionInfDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ProductionConsumptionInfDocumentReport MyParentReport
            {
                get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REGISTRATIONNUMBER { get {return Header().REGISTRATIONNUMBER;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField16111231 { get {return Header().NewField16111231;} }
            public TTReportField TRANSACTIONDATE { get {return Header().TRANSACTIONDATE;} }
            public TTReportField NewField113211161 { get {return Header().NewField113211161;} }
            public TTReportField NewField113211162 { get {return Header().NewField113211162;} }
            public TTReportField SIPARISADIVENUMARASI { get {return Header().SIPARISADIVENUMARASI;} }
            public TTReportField DESC1 { get {return Footer().DESC1;} }
            public TTReportField IMZA1 { get {return Footer().IMZA1;} }
            public TTReportField IMZA2 { get {return Footer().IMZA2;} }
            public TTReportField IMZA3 { get {return Footer().IMZA3;} }
            public TTReportField IMZA4 { get {return Footer().IMZA4;} }
            public TTReportField IMZA5 { get {return Footer().IMZA5;} }
            public TTReportField IMZA6 { get {return Footer().IMZA6;} }
            public TTReportField MALSAYMANI { get {return Footer().MALSAYMANI;} }
            public TTReportField DESCLEFT { get {return Footer().DESCLEFT;} }
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
                public ProductionConsumptionInfDocumentReport MyParentReport
                {
                    get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
                }
                
                public TTReportField REGISTRATIONNUMBER;
                public TTReportField NewField111;
                public TTReportField NewField16111231;
                public TTReportField TRANSACTIONDATE;
                public TTReportField NewField113211161;
                public TTReportField NewField113211162;
                public TTReportField SIPARISADIVENUMARASI; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 30, 287, 36, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FillStyle = FillStyleConstants.vbFSTransparent;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.TextFont.Name = "Arial";
                    REGISTRATIONNUMBER.TextFont.Size = 11;
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 287, 24, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"TÜKETİM, ÜRETİM ve ELDE EDİLENLER BELGESİ";

                    NewField16111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 24, 255, 30, false);
                    NewField16111231.Name = "NewField16111231";
                    NewField16111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16111231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16111231.TextFont.Size = 11;
                    NewField16111231.TextFont.Bold = true;
                    NewField16111231.TextFont.CharSet = 162;
                    NewField16111231.Value = @"Kayıt Tarihi";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 24, 287, 30, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"Short Date";
                    TRANSACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TRANSACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDATE.ObjectDefName = "StockAction";
                    TRANSACTIONDATE.DataMember = "TRANSACTIONDATE";
                    TRANSACTIONDATE.TextFont.Name = "Arial";
                    TRANSACTIONDATE.TextFont.Size = 11;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{@TTOBJECTID@}";

                    NewField113211161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 30, 255, 36, false);
                    NewField113211161.Name = "NewField113211161";
                    NewField113211161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113211161.TextFont.Size = 11;
                    NewField113211161.TextFont.Bold = true;
                    NewField113211161.TextFont.CharSet = 162;
                    NewField113211161.Value = @"Kayıt Numarası";

                    NewField113211162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 65, 36, false);
                    NewField113211162.Name = "NewField113211162";
                    NewField113211162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113211162.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113211162.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113211162.TextFont.Size = 11;
                    NewField113211162.TextFont.Bold = true;
                    NewField113211162.TextFont.CharSet = 162;
                    NewField113211162.Value = @"Üretime veya Elde Etmeye İlişkin Sipariş Adı ve Nu.";

                    SIPARISADIVENUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 24, 224, 36, false);
                    SIPARISADIVENUMARASI.Name = "SIPARISADIVENUMARASI";
                    SIPARISADIVENUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    SIPARISADIVENUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISADIVENUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISADIVENUMARASI.TextFont.Name = "Arial";
                    SIPARISADIVENUMARASI.TextFont.Size = 11;
                    SIPARISADIVENUMARASI.TextFont.CharSet = 162;
                    SIPARISADIVENUMARASI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REGISTRATIONNUMBER.CalcValue = @"";
                    NewField111.CalcValue = NewField111.Value;
                    NewField16111231.CalcValue = NewField16111231.Value;
                    TRANSACTIONDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TRANSACTIONDATE.PostFieldValueCalculation();
                    NewField113211161.CalcValue = NewField113211161.Value;
                    NewField113211162.CalcValue = NewField113211162.Value;
                    SIPARISADIVENUMARASI.CalcValue = @"";
                    return new TTReportObject[] { REGISTRATIONNUMBER,NewField111,NewField16111231,TRANSACTIONDATE,NewField113211161,NewField113211162,SIPARISADIVENUMARASI};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
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
                public ProductionConsumptionInfDocumentReport MyParentReport
                {
                    get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
                }
                
                public TTReportField DESC1;
                public TTReportField IMZA1;
                public TTReportField IMZA2;
                public TTReportField IMZA3;
                public TTReportField IMZA4;
                public TTReportField IMZA5;
                public TTReportField IMZA6;
                public TTReportField MALSAYMANI;
                public TTReportField DESCLEFT; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 45;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 287, 32, false);
                    DESC1.Name = "DESC1";
                    DESC1.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC1.TextFont.Size = 8;
                    DESC1.TextFont.CharSet = 162;
                    DESC1.Value = @"";

                    IMZA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 47, 29, false);
                    IMZA1.Name = "IMZA1";
                    IMZA1.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA1.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA1.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA1.TextFont.Size = 9;
                    IMZA1.TextFont.CharSet = 162;
                    IMZA1.Value = @"";

                    IMZA2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 8, 126, 29, false);
                    IMZA2.Name = "IMZA2";
                    IMZA2.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA2.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA2.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA2.TextFont.Size = 9;
                    IMZA2.TextFont.CharSet = 162;
                    IMZA2.Value = @"";

                    IMZA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 8, 166, 29, false);
                    IMZA3.Name = "IMZA3";
                    IMZA3.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA3.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA3.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA3.TextFont.Size = 9;
                    IMZA3.TextFont.CharSet = 162;
                    IMZA3.Value = @"";

                    IMZA4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 8, 206, 29, false);
                    IMZA4.Name = "IMZA4";
                    IMZA4.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA4.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA4.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA4.TextFont.Size = 9;
                    IMZA4.TextFont.CharSet = 162;
                    IMZA4.Value = @"";

                    IMZA5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 8, 245, 29, false);
                    IMZA5.Name = "IMZA5";
                    IMZA5.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA5.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA5.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA5.TextFont.Size = 9;
                    IMZA5.TextFont.CharSet = 162;
                    IMZA5.Value = @"";

                    IMZA6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 8, 285, 29, false);
                    IMZA6.Name = "IMZA6";
                    IMZA6.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA6.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA6.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA6.TextFont.Size = 9;
                    IMZA6.TextFont.CharSet = 162;
                    IMZA6.Value = @"";

                    MALSAYMANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 8, 86, 29, false);
                    MALSAYMANI.Name = "MALSAYMANI";
                    MALSAYMANI.MultiLine = EvetHayirEnum.ehEvet;
                    MALSAYMANI.WordBreak = EvetHayirEnum.ehEvet;
                    MALSAYMANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSAYMANI.TextFont.Size = 9;
                    MALSAYMANI.TextFont.CharSet = 162;
                    MALSAYMANI.Value = @"";

                    DESCLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 284, 6, false);
                    DESCLEFT.Name = "DESCLEFT";
                    DESCLEFT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESC1.CalcValue = DESC1.Value;
                    IMZA1.CalcValue = IMZA1.Value;
                    IMZA2.CalcValue = IMZA2.Value;
                    IMZA3.CalcValue = IMZA3.Value;
                    IMZA4.CalcValue = IMZA4.Value;
                    IMZA5.CalcValue = IMZA5.Value;
                    IMZA6.CalcValue = IMZA6.Value;
                    MALSAYMANI.CalcValue = MALSAYMANI.Value;
                    DESCLEFT.CalcValue = DESCLEFT.Value;
                    return new TTReportObject[] { DESC1,IMZA1,IMZA2,IMZA3,IMZA4,IMZA5,IMZA6,MALSAYMANI,DESCLEFT};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                        if (stockAction is ProductionConsumptionInfirmaryDocument)
                        {
                            ProductionConsumptionInfirmaryDocument productionConsumptionInfirmaryDocument = (ProductionConsumptionInfirmaryDocument)stockAction;
                            this.DESCLEFT.Value = productionConsumptionInfirmaryDocument.StartDate.Value.ToShortDateString() + " - " + productionConsumptionInfirmaryDocument.EndDate.Value.ToShortDateString() + " tarihleri arasında " + productionConsumptionInfirmaryDocument.Store.Name + " için tüketilenler, üretilen/elde edilenlerin yukarıda gösterildiği beyan olunur.";
                        }
                        else if (stockAction is MainStoreProductionConsumptionDocument)
                        {
                            MainStoreProductionConsumptionDocument mainStoreProductionConsumptionDocument = (MainStoreProductionConsumptionDocument)stockAction;
                            this.DESCLEFT.Value = mainStoreProductionConsumptionDocument.StartDate.Value.ToShortDateString() + " - " + mainStoreProductionConsumptionDocument.EndDate.Value.ToShortDateString() + " tarihleri arasında " + mainStoreProductionConsumptionDocument.Store.Name + " için tüketilenler, üretilen/elde edilenlerin yukarıda gösterildiği beyan olunur.";
                        }
                        else
                        {
                            this.DESCLEFT.Value = "....../...../......  -  ....../...../......  tarihleri arasında .............................................. için tüketilenler, üretilen/elde edilenlerin yukarıda gösterildiği beyan olunur.";
                        }

                        foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                        {
                            string signDesc = string.Empty;
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(SignUserTypeEnum).Name];
                            signDesc += dataType.EnumValueDefs[(int)stockActionSignDetail.SignUserType.Value].DisplayText;
                            if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
                                signDesc += " Vek.";

                            signDesc += "\r\n" + stockActionSignDetail.SignUser.Name + "\r\n";

                            if (stockActionSignDetail.SignUser.MilitaryClass != null)
                                signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;

                            if (stockActionSignDetail.SignUser.Rank != null)
                                signDesc += stockActionSignDetail.SignUser.Rank.ShortName + "\r\n";

                            signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
                            if (stockActionSignDetail.SignUserType == SignUserTypeEnum.MalSaymani)
                            {
                                this.MALSAYMANI.Value = signDesc;
                                continue;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(this.IMZA1.Value))
                                {
                                    this.IMZA1.Value = signDesc;
                                    continue;
                                }
                                if (string.IsNullOrEmpty(this.IMZA2.Value))
                                {
                                    this.IMZA2.Value = signDesc;
                                    continue;
                                }
                                if (string.IsNullOrEmpty(this.IMZA3.Value))
                                {
                                    this.IMZA3.Value = signDesc;
                                    continue;
                                }
                                if (string.IsNullOrEmpty(this.IMZA4.Value))
                                {
                                    this.IMZA4.Value = signDesc;
                                    continue;
                                }
                                if (string.IsNullOrEmpty(this.IMZA5.Value))
                                {
                                    this.IMZA5.Value = signDesc;
                                    continue;
                                }
                                if (string.IsNullOrEmpty(this.IMZA6.Value))
                                {
                                    this.IMZA6.Value = signDesc;
                                    continue;
                                }
                            }
                        }

                    }
#endregion PARTA FOOTER_PreScript
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ProductionConsumptionInfDocumentReport MyParentReport
            {
                get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
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
            public TTReportField NewField12111111 { get {return Header().NewField12111111;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField111111111 { get {return Header().NewField111111111;} }
            public TTReportField NewField1111113 { get {return Header().NewField1111113;} }
            public TTReportField NewField11111112 { get {return Header().NewField11111112;} }
            public TTReportField NewField12111112 { get {return Header().NewField12111112;} }
            public TTReportField NewField111111121 { get {return Header().NewField111111121;} }
            public TTReportField NewField111111112 { get {return Header().NewField111111112;} }
            public TTReportField NewField1111111111 { get {return Header().NewField1111111111;} }
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
                public ProductionConsumptionInfDocumentReport MyParentReport
                {
                    get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111;
                public TTReportField NewField11112;
                public TTReportField NewField1111111;
                public TTReportField NewField1111112;
                public TTReportField NewField12111111;
                public TTReportField NewField11111111;
                public TTReportField NewField111111111;
                public TTReportField NewField1111113;
                public TTReportField NewField11111112;
                public TTReportField NewField12111112;
                public TTReportField NewField111111121;
                public TTReportField NewField111111112;
                public TTReportField NewField1111111111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 17, 26, false);
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

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 9, 35, 26, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Stok Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 3, 152, 9, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Tüketilenler";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 3, 287, 9, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112.TextFont.Size = 11;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Üretilen / Elde Edilenler";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 9, 92, 26, false);
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
Taşınır Malın Cins ve Özellikleri";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 9, 107, 26, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111112.TextFont.Size = 11;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Miktarı";

                    NewField12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 9, 152, 26, false);
                    NewField12111111.Name = "NewField12111111";
                    NewField12111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12111111.TextFont.Size = 11;
                    NewField12111111.TextFont.Bold = true;
                    NewField12111111.TextFont.CharSet = 162;
                    NewField12111111.Value = @"Tutarı";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 9, 122, 26, false);
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

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 9, 137, 26, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111111.TextFont.Size = 11;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.TextFont.CharSet = 162;
                    NewField111111111.Value = @"
Birim Fiyatı";

                    NewField1111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 9, 170, 26, false);
                    NewField1111113.Name = "NewField1111113";
                    NewField1111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111113.TextFont.Size = 11;
                    NewField1111113.TextFont.Bold = true;
                    NewField1111113.TextFont.CharSet = 162;
                    NewField1111113.Value = @"Stok Nu.";

                    NewField11111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 9, 227, 26, false);
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
Taşınır Malın Cins ve Özellikleri";

                    NewField12111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 9, 242, 26, false);
                    NewField12111112.Name = "NewField12111112";
                    NewField12111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12111112.TextFont.Size = 11;
                    NewField12111112.TextFont.Bold = true;
                    NewField12111112.TextFont.CharSet = 162;
                    NewField12111112.Value = @"Miktarı";

                    NewField111111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 9, 287, 26, false);
                    NewField111111121.Name = "NewField111111121";
                    NewField111111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111121.TextFont.Size = 11;
                    NewField111111121.TextFont.Bold = true;
                    NewField111111121.TextFont.CharSet = 162;
                    NewField111111121.Value = @"Tutarı";

                    NewField111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 9, 257, 26, false);
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

                    NewField1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 9, 272, 26, false);
                    NewField1111111111.Name = "NewField1111111111";
                    NewField1111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111111.TextFont.Size = 11;
                    NewField1111111111.TextFont.Bold = true;
                    NewField1111111111.TextFont.CharSet = 162;
                    NewField1111111111.Value = @"
Birim Fiyatı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField12111111.CalcValue = NewField12111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    NewField1111113.CalcValue = NewField1111113.Value;
                    NewField11111112.CalcValue = NewField11111112.Value;
                    NewField12111112.CalcValue = NewField12111112.Value;
                    NewField111111121.CalcValue = NewField111111121.Value;
                    NewField111111112.CalcValue = NewField111111112.Value;
                    NewField1111111111.CalcValue = NewField1111111111.Value;
                    return new TTReportObject[] { NewField11111,NewField111111,NewField1111,NewField11112,NewField1111111,NewField1111112,NewField12111111,NewField11111111,NewField111111111,NewField1111113,NewField11111112,NewField12111112,NewField111111121,NewField111111112,NewField1111111111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ProductionConsumptionInfDocumentReport MyParentReport
                {
                    get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
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
                    
                    OUTITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 152, 5, false);
                    OUTITEMCOUNT.Name = "OUTITEMCOUNT";
                    OUTITEMCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTITEMCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OUTITEMCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OUTITEMCOUNT.TextFont.CharSet = 162;
                    OUTITEMCOUNT.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    INITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 287, 5, false);
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
                StockAction stockAction = MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction)) as StockAction;
                if(stockAction is ProductionConsumptionInfirmaryDocument)
                {
                    ProductionConsumptionInfirmaryDocument productionConsumptionInfirmaryDocument = (ProductionConsumptionInfirmaryDocument)stockAction;

                    string closer = "/////////////////////////////////////////////////////////////////////////////////////////////////////////";
                    if (productionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentOutMaterials.Count > 0)
                    {
                        int outItemCount = productionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentOutMaterials.Count;
                        OUTITEMCOUNT.Visible = EvetHayirEnum.ehEvet;
                        OUTITEMCOUNT.CalcValue = closer + "Yalnız " + outItemCount + "(" + TTReportTool.Common.SpellNumber(outItemCount.ToString()) + ") kalemdir." + closer;
                    }
                    else
                    {
                        OUTITEMCOUNT.Visible = EvetHayirEnum.ehHayir;
                    }

                    if (productionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentInMaterials.Count > 0)
                    {
                        int inItemCount = productionConsumptionInfirmaryDocument.ProductionConsumptionInfirmaryDocumentInMaterials.Count;
                        INITEMCOUNT.Visible = EvetHayirEnum.ehEvet;
                        INITEMCOUNT.CalcValue = closer + "Yalnız " + inItemCount + "(" + TTReportTool.Common.SpellNumber(inItemCount.ToString()) + ") kalemdir." + closer;
                    }
                    else
                    {
                        INITEMCOUNT.Visible = EvetHayirEnum.ehHayir;
                    }
                }
                else if (stockAction is PresInfirmaryDocument)
                {
                    PresInfirmaryDocument presInfirmaryDocument = (PresInfirmaryDocument)stockAction;

                    string closer = "/////////////////////////////////////////////////////////////////////////////////////////////////////////";
                    if (presInfirmaryDocument.PresInfirmaryDocumentOutMaterials.Count > 0)
                    {
                        int outItemCount = presInfirmaryDocument.PresInfirmaryDocumentOutMaterials.Count;
                        OUTITEMCOUNT.Visible = EvetHayirEnum.ehEvet;
                        OUTITEMCOUNT.CalcValue = closer + "Yalnız " + outItemCount + "(" + TTReportTool.Common.SpellNumber(outItemCount.ToString()) + ") kalemdir." + closer;
                    }
                    else
                    {
                        OUTITEMCOUNT.Visible = EvetHayirEnum.ehHayir;
                    }

                    if (presInfirmaryDocument.PresInfirmaryDocumentInMaterials.Count > 0)
                    {
                        int inItemCount = presInfirmaryDocument.PresInfirmaryDocumentInMaterials.Count;
                        INITEMCOUNT.Visible = EvetHayirEnum.ehEvet;
                        INITEMCOUNT.CalcValue = closer + "Yalnız " + inItemCount + "(" + TTReportTool.Common.SpellNumber(inItemCount.ToString()) + ") kalemdir." + closer;
                    }
                    else
                    {
                        INITEMCOUNT.Visible = EvetHayirEnum.ehHayir;
                    }
                    
                }

            }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ProductionConsumptionInfDocumentReport MyParentReport
            {
                get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CONSUMPTIONDISTRIBUTIONTYPE { get {return Body().CONSUMPTIONDISTRIBUTIONTYPE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField CONSUMPTIONMATERIALDESCRIPTION { get {return Body().CONSUMPTIONMATERIALDESCRIPTION;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField OUTSTOCKACTIONDETAILOBJECTID { get {return Body().OUTSTOCKACTIONDETAILOBJECTID;} }
            public TTReportField INSTOCKACTIONDETAILOBJECTID { get {return Body().INSTOCKACTIONDETAILOBJECTID;} }
            public TTReportField CONSUMPTIONMATERIALNATOSTOCKNO { get {return Body().CONSUMPTIONMATERIALNATOSTOCKNO;} }
            public TTReportField OUTUNITPRICE { get {return Body().OUTUNITPRICE;} }
            public TTReportField OUTPRICE { get {return Body().OUTPRICE;} }
            public TTReportField MATERIALNATOSTOCKNO { get {return Body().MATERIALNATOSTOCKNO;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
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
                public ProductionConsumptionInfDocumentReport MyParentReport
                {
                    get { return (ProductionConsumptionInfDocumentReport)ParentReport; }
                }
                
                public TTReportField CONSUMPTIONDISTRIBUTIONTYPE;
                public TTReportField UNITPRICE;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField CONSUMPTIONMATERIALDESCRIPTION;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField OUTSTOCKACTIONDETAILOBJECTID;
                public TTReportField INSTOCKACTIONDETAILOBJECTID;
                public TTReportField CONSUMPTIONMATERIALNATOSTOCKNO;
                public TTReportField OUTUNITPRICE;
                public TTReportField OUTPRICE;
                public TTReportField MATERIALNATOSTOCKNO;
                public TTReportField PRICE;
                public TTReportField ORDERNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CONSUMPTIONDISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 122, 5, false);
                    CONSUMPTIONDISTRIBUTIONTYPE.Name = "CONSUMPTIONDISTRIBUTIONTYPE";
                    CONSUMPTIONDISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONDISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONDISTRIBUTIONTYPE.TextFormat = @"#,##0.#0";
                    CONSUMPTIONDISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSUMPTIONDISTRIBUTIONTYPE.TextFont.Size = 8;
                    CONSUMPTIONDISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    CONSUMPTIONDISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE!StockActionOutDetailsReportQuery#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 272, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.00";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 242, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.####";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 0, 257, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 227, 5, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 8;
                    MATERIALDESCRIPTION.TextFont.CharSet = 162;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#}";

                    CONSUMPTIONMATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 92, 5, false);
                    CONSUMPTIONMATERIALDESCRIPTION.Name = "CONSUMPTIONMATERIALDESCRIPTION";
                    CONSUMPTIONMATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALDESCRIPTION.TextFont.Size = 8;
                    CONSUMPTIONMATERIALDESCRIPTION.TextFont.CharSet = 162;
                    CONSUMPTIONMATERIALDESCRIPTION.Value = @"{#MATERIALNAME!StockActionOutDetailsReportQuery#}";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 0, 107, 5, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.TextFormat = @"#,##0.####";
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSUMPTIONAMOUNT.TextFont.Size = 8;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#AMOUNT!StockActionOutDetailsReportQuery#}";

                    OUTSTOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 2, 334, 7, false);
                    OUTSTOCKACTIONDETAILOBJECTID.Name = "OUTSTOCKACTIONDETAILOBJECTID";
                    OUTSTOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OUTSTOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTSTOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID!StockActionOutDetailsReportQuery#}";

                    INSTOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 338, 2, 363, 7, false);
                    INSTOCKACTIONDETAILOBJECTID.Name = "INSTOCKACTIONDETAILOBJECTID";
                    INSTOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    INSTOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    INSTOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    CONSUMPTIONMATERIALNATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 35, 5, false);
                    CONSUMPTIONMATERIALNATOSTOCKNO.Name = "CONSUMPTIONMATERIALNATOSTOCKNO";
                    CONSUMPTIONMATERIALNATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALNATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALNATOSTOCKNO.TextFont.Size = 8;
                    CONSUMPTIONMATERIALNATOSTOCKNO.TextFont.CharSet = 162;
                    CONSUMPTIONMATERIALNATOSTOCKNO.Value = @"{#NATOSTOCKNO!StockActionOutDetailsReportQuery#}";

                    OUTUNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 137, 5, false);
                    OUTUNITPRICE.Name = "OUTUNITPRICE";
                    OUTUNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    OUTUNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTUNITPRICE.TextFormat = @"#,##0.00";
                    OUTUNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OUTUNITPRICE.TextFont.Size = 8;
                    OUTUNITPRICE.TextFont.CharSet = 162;
                    OUTUNITPRICE.Value = @"";

                    OUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 152, 5, false);
                    OUTPRICE.Name = "OUTPRICE";
                    OUTPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    OUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTPRICE.TextFormat = @"#,##0.00";
                    OUTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OUTPRICE.TextFont.Size = 8;
                    OUTPRICE.TextFont.CharSet = 162;
                    OUTPRICE.Value = @"";

                    MATERIALNATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 170, 5, false);
                    MATERIALNATOSTOCKNO.Name = "MATERIALNATOSTOCKNO";
                    MATERIALNATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNATOSTOCKNO.TextFont.Size = 8;
                    MATERIALNATOSTOCKNO.TextFont.CharSet = 162;
                    MATERIALNATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 0, 287, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.00";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 17, 5, false);
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
                    UNITPRICE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.UnitPrice) : "");
                    AMOUNT.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.DistributionType) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Materialname) : "");
                    CONSUMPTIONMATERIALDESCRIPTION.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "");
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    OUTSTOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    INSTOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Stockactiondetailobjectid) : "");
                    CONSUMPTIONMATERIALNATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    OUTUNITPRICE.CalcValue = @"";
                    OUTPRICE.CalcValue = @"";
                    MATERIALNATOSTOCKNO.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.NATOStockNO) : "");
                    PRICE.CalcValue = @"";
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    return new TTReportObject[] { CONSUMPTIONDISTRIBUTIONTYPE,UNITPRICE,AMOUNT,DISTRIBUTIONTYPE,MATERIALDESCRIPTION,CONSUMPTIONMATERIALDESCRIPTION,CONSUMPTIONAMOUNT,OUTSTOCKACTIONDETAILOBJECTID,INSTOCKACTIONDETAILOBJECTID,CONSUMPTIONMATERIALNATOSTOCKNO,OUTUNITPRICE,OUTPRICE,MATERIALNATOSTOCKNO,PRICE,ORDERNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    StockAction stockAction = MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction)) as StockAction;
            if (stockAction is ProductionConsumptionInfirmaryDocument)
            {
                if (string.IsNullOrEmpty(OUTSTOCKACTIONDETAILOBJECTID.CalcValue) == false && TTUtils.Globals.IsGuid(OUTSTOCKACTIONDETAILOBJECTID.CalcValue))
                {
                    ProductionConsumptionInfirmaryDocumentMaterialOut productionConsumptionInfirmaryDocumentMaterialOut = (ProductionConsumptionInfirmaryDocumentMaterialOut)MyParentReport.ReportObjectContext.GetObject(new Guid(OUTSTOCKACTIONDETAILOBJECTID.CalcValue), typeof(ProductionConsumptionInfirmaryDocumentMaterialOut));
                    this.OUTUNITPRICE.CalcValue = productionConsumptionInfirmaryDocumentMaterialOut.UnitPrice.ToString();
                    this.OUTPRICE.CalcValue = productionConsumptionInfirmaryDocumentMaterialOut.Price.ToString();

                    //double totalPrice = 0;
                    //foreach (StockCollectedTrx stockCollectedTrx in stockActionDetailOut.StockCollectedTrxs)
                    //    totalPrice += stockCollectedTrx.StockTransaction.UnitPrice.Value * stockCollectedTrx.StockTransaction.Amount.Value;

                    //this.OUTPRICE.CalcValue = totalPrice.ToString();
                    //this.OUTUNITPRICE.CalcValue = (totalPrice / stockActionDetailOut.Amount.Value).ToString();
                }

                if (string.IsNullOrEmpty(INSTOCKACTIONDETAILOBJECTID.CalcValue) == false && TTUtils.Globals.IsGuid(INSTOCKACTIONDETAILOBJECTID.CalcValue))
                {
                    ProductionConsumptionInfirmaryDocumentMaterialIn productionConsumptionInfirmaryDocumentMaterialIn = (ProductionConsumptionInfirmaryDocumentMaterialIn)MyParentReport.ReportObjectContext.GetObject(new Guid(INSTOCKACTIONDETAILOBJECTID.CalcValue), typeof(ProductionConsumptionInfirmaryDocumentMaterialIn));
                    this.UNITPRICE.CalcValue = productionConsumptionInfirmaryDocumentMaterialIn.UnitPrice.ToString();
                    this.PRICE.CalcValue = productionConsumptionInfirmaryDocumentMaterialIn.Price.ToString();
                }
            }
            else if (stockAction is PresInfirmaryDocument)
            {
                if (string.IsNullOrEmpty(OUTSTOCKACTIONDETAILOBJECTID.CalcValue) == false && TTUtils.Globals.IsGuid(OUTSTOCKACTIONDETAILOBJECTID.CalcValue))
                {
                    PresInfirmaryDocMatOut presInfirmaryDocMatOut = (PresInfirmaryDocMatOut)MyParentReport.ReportObjectContext.GetObject(new Guid(OUTSTOCKACTIONDETAILOBJECTID.CalcValue), typeof(PresInfirmaryDocMatOut));
                    this.OUTUNITPRICE.CalcValue = presInfirmaryDocMatOut.UnitPrice.ToString();
                    this.OUTPRICE.CalcValue = presInfirmaryDocMatOut.Price.ToString();

                    //double totalPrice = 0;
                    //foreach (StockCollectedTrx stockCollectedTrx in stockActionDetailOut.StockCollectedTrxs)
                    //    totalPrice += stockCollectedTrx.StockTransaction.UnitPrice.Value * stockCollectedTrx.StockTransaction.Amount.Value;

                    //this.OUTPRICE.CalcValue = totalPrice.ToString();
                    //this.OUTUNITPRICE.CalcValue = (totalPrice / stockActionDetailOut.Amount.Value).ToString();
                }

                if (string.IsNullOrEmpty(INSTOCKACTIONDETAILOBJECTID.CalcValue) == false && TTUtils.Globals.IsGuid(INSTOCKACTIONDETAILOBJECTID.CalcValue))
                {
                    PresInfirmaryDocMaterialIn presInfirmaryDocMaterialIn = (PresInfirmaryDocMaterialIn)MyParentReport.ReportObjectContext.GetObject(new Guid(INSTOCKACTIONDETAILOBJECTID.CalcValue), typeof(PresInfirmaryDocMaterialIn));
                    this.UNITPRICE.CalcValue = presInfirmaryDocMaterialIn.UnitPrice.ToString();
                    this.PRICE.CalcValue = presInfirmaryDocMaterialIn.Price.ToString();
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

        public ProductionConsumptionInfDocumentReport()
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
            Name = "PRODUCTIONCONSUMPTIONINFDOCUMENTREPORT";
            Caption = "El Senedi Sarf İmal İstihsal Belgesi";
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