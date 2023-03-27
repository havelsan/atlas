
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
    /// Sayım Düzeltme Belgesi
    /// </summary>
    public partial class CensusFixedReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CensusFixedReport MyParentReport
            {
                get { return (CensusFixedReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField15111231 { get {return Header().NewField15111231;} }
            public TTReportField TASINIRMALSAYMANLIGI { get {return Header().TASINIRMALSAYMANLIGI;} }
            public TTReportField REFERANSNU { get {return Header().REFERANSNU;} }
            public TTReportField DESCRIPTIONFIELD { get {return Footer().DESCRIPTIONFIELD;} }
            public TTReportField NewField1333 { get {return Footer().NewField1333;} }
            public TTReportField NewField1332 { get {return Footer().NewField1332;} }
            public TTReportField NewField133 { get {return Footer().NewField133;} }
            public TTReportField MALSORUMLUSU { get {return Footer().MALSORUMLUSU;} }
            public TTReportField MALSORUMLUSUTARIH { get {return Footer().MALSORUMLUSUTARIH;} }
            public TTReportField ONAYLAYAN { get {return Footer().ONAYLAYAN;} }
            public TTReportField ONAYLAYANTARIH { get {return Footer().ONAYLAYANTARIH;} }
            public TTReportField MALSAYMANI { get {return Footer().MALSAYMANI;} }
            public TTReportField MALSAYMANITARIH { get {return Footer().MALSAYMANITARIH;} }
            public TTReportField NewField1331 { get {return Footer().NewField1331;} }
            public TTReportField HESAPSORUMLUSU { get {return Footer().HESAPSORUMLUSU;} }
            public TTReportField HESAPSORUMLUSUTARIH { get {return Footer().HESAPSORUMLUSUTARIH;} }
            public TTReportField TRANSACTIONDATE { get {return Footer().TRANSACTIONDATE;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
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
                public CensusFixedReport MyParentReport
                {
                    get { return (CensusFixedReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField15111231;
                public TTReportField TASINIRMALSAYMANLIGI;
                public TTReportField REFERANSNU; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 201, 16, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"SAYIM DÜZELTME BELGESİ";

                    NewField15111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 71, 25, false);
                    NewField15111231.Name = "NewField15111231";
                    NewField15111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15111231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15111231.TextFont.Name = "Arial Narrow";
                    NewField15111231.TextFont.Size = 11;
                    NewField15111231.TextFont.Bold = true;
                    NewField15111231.Value = @"Taşınır Mal Saymanlık Adı ve Nu.:";

                    TASINIRMALSAYMANLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 16, 201, 25, false);
                    TASINIRMALSAYMANLIGI.Name = "TASINIRMALSAYMANLIGI";
                    TASINIRMALSAYMANLIGI.DrawStyle = DrawStyleConstants.vbSolid;
                    TASINIRMALSAYMANLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TASINIRMALSAYMANLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TASINIRMALSAYMANLIGI.TextFont.Name = "Arial Narrow";
                    TASINIRMALSAYMANLIGI.Value = @"";

                    REFERANSNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 8, 199, 14, false);
                    REFERANSNU.Name = "REFERANSNU";
                    REFERANSNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFERANSNU.ObjectDefName = "StockAction";
                    REFERANSNU.DataMember = "REGISTRATIONNUMBER";
                    REFERANSNU.TextFont.Name = "Arial Narrow";
                    REFERANSNU.TextFont.CharSet = 1;
                    REFERANSNU.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField15111231.CalcValue = NewField15111231.Value;
                    TASINIRMALSAYMANLIGI.CalcValue = @"";
                    REFERANSNU.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    REFERANSNU.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField111,NewField15111231,TASINIRMALSAYMANLIGI,REFERANSNU};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                        if (stockAction.Store is MainStoreDefinition)
                            TASINIRMALSAYMANLIGI.CalcValue = ((MainStoreDefinition)stockAction.Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)stockAction.Store).Accountancy.Name;
                    }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CensusFixedReport MyParentReport
                {
                    get { return (CensusFixedReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTIONFIELD;
                public TTReportField NewField1333;
                public TTReportField NewField1332;
                public TTReportField NewField133;
                public TTReportField MALSORUMLUSU;
                public TTReportField MALSORUMLUSUTARIH;
                public TTReportField ONAYLAYAN;
                public TTReportField ONAYLAYANTARIH;
                public TTReportField MALSAYMANI;
                public TTReportField MALSAYMANITARIH;
                public TTReportField NewField1331;
                public TTReportField HESAPSORUMLUSU;
                public TTReportField HESAPSORUMLUSUTARIH;
                public TTReportField TRANSACTIONDATE;
                public TTReportField DESCRIPTION; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 50;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESCRIPTIONFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 201, 19, false);
                    DESCRIPTIONFIELD.Name = "DESCRIPTIONFIELD";
                    DESCRIPTIONFIELD.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTIONFIELD.TextFont.Name = "Arial Narrow";
                    DESCRIPTIONFIELD.TextFont.Size = 11;
                    DESCRIPTIONFIELD.TextFont.Bold = true;
                    DESCRIPTIONFIELD.Value = @"Açıklamalar :";

                    NewField1333 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 19, 201, 47, false);
                    NewField1333.Name = "NewField1333";
                    NewField1333.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1333.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1333.TextFont.Name = "Arial Narrow";
                    NewField1333.Value = @"";

                    NewField1332 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 152, 47, false);
                    NewField1332.Name = "NewField1332";
                    NewField1332.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1332.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1332.TextFont.Name = "Arial Narrow";
                    NewField1332.Value = @"";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 19, 58, 47, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField133.TextFont.Name = "Arial Narrow";
                    NewField133.Value = @"";

                    MALSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 27, 56, 45, false);
                    MALSORUMLUSU.Name = "MALSORUMLUSU";
                    MALSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.TextFont.Name = "Arial Narrow";
                    MALSORUMLUSU.TextFont.CharSet = 1;
                    MALSORUMLUSU.Value = @"MALSORUMLUSU";

                    MALSORUMLUSUTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 56, 26, false);
                    MALSORUMLUSUTARIH.Name = "MALSORUMLUSUTARIH";
                    MALSORUMLUSUTARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALSORUMLUSUTARIH.TextFont.Name = "Arial Narrow";
                    MALSORUMLUSUTARIH.TextFont.CharSet = 1;
                    MALSORUMLUSUTARIH.Value = @"MALSORUMLUSUTARIH";

                    ONAYLAYAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 28, 199, 45, false);
                    ONAYLAYAN.Name = "ONAYLAYAN";
                    ONAYLAYAN.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYLAYAN.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYLAYAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYLAYAN.TextFont.Name = "Arial Narrow";
                    ONAYLAYAN.TextFont.CharSet = 1;
                    ONAYLAYAN.Value = @"ONAYLAYAN";

                    ONAYLAYANTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 20, 199, 26, false);
                    ONAYLAYANTARIH.Name = "ONAYLAYANTARIH";
                    ONAYLAYANTARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYLAYANTARIH.TextFont.Name = "Arial Narrow";
                    ONAYLAYANTARIH.TextFont.CharSet = 1;
                    ONAYLAYANTARIH.Value = @"ONAYLAYANTARIH";

                    MALSAYMANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 28, 150, 45, false);
                    MALSAYMANI.Name = "MALSAYMANI";
                    MALSAYMANI.MultiLine = EvetHayirEnum.ehEvet;
                    MALSAYMANI.WordBreak = EvetHayirEnum.ehEvet;
                    MALSAYMANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSAYMANI.TextFont.Name = "Arial Narrow";
                    MALSAYMANI.TextFont.CharSet = 1;
                    MALSAYMANI.Value = @"MALSAYMANI";

                    MALSAYMANITARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 20, 150, 26, false);
                    MALSAYMANITARIH.Name = "MALSAYMANITARIH";
                    MALSAYMANITARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALSAYMANITARIH.TextFont.Name = "Arial Narrow";
                    MALSAYMANITARIH.TextFont.CharSet = 1;
                    MALSAYMANITARIH.Value = @"MALSAYMANITARIH";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 19, 105, 47, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1331.TextFont.Name = "Arial Narrow";
                    NewField1331.Value = @"";

                    HESAPSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 27, 103, 45, false);
                    HESAPSORUMLUSU.Name = "HESAPSORUMLUSU";
                    HESAPSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.ExpandTabs = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.TextFont.Name = "Arial Narrow";
                    HESAPSORUMLUSU.TextFont.CharSet = 1;
                    HESAPSORUMLUSU.Value = @"HESAPSORUMLUSU";

                    HESAPSORUMLUSUTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 20, 103, 26, false);
                    HESAPSORUMLUSUTARIH.Name = "HESAPSORUMLUSUTARIH";
                    HESAPSORUMLUSUTARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HESAPSORUMLUSUTARIH.TextFont.Name = "Arial Narrow";
                    HESAPSORUMLUSUTARIH.TextFont.CharSet = 1;
                    HESAPSORUMLUSUTARIH.Value = @"HESAPSORUMLUSUTARIH";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 3, 265, 9, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TRANSACTIONDATE.ObjectDefName = "StockAction";
                    TRANSACTIONDATE.DataMember = "TRANSACTIONDATE";
                    TRANSACTIONDATE.TextFont.Name = "Arial Narrow";
                    TRANSACTIONDATE.TextFont.CharSet = 1;
                    TRANSACTIONDATE.Value = @"{@TTOBJECTID@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 199, 18, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ObjectDefName = "StockAction";
                    DESCRIPTION.DataMember = "DESCRIPTION";
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.CharSet = 1;
                    DESCRIPTION.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTIONFIELD.CalcValue = DESCRIPTIONFIELD.Value;
                    NewField1333.CalcValue = NewField1333.Value;
                    NewField1332.CalcValue = NewField1332.Value;
                    NewField133.CalcValue = NewField133.Value;
                    MALSORUMLUSU.CalcValue = MALSORUMLUSU.Value;
                    MALSORUMLUSUTARIH.CalcValue = MALSORUMLUSUTARIH.Value;
                    ONAYLAYAN.CalcValue = ONAYLAYAN.Value;
                    ONAYLAYANTARIH.CalcValue = ONAYLAYANTARIH.Value;
                    MALSAYMANI.CalcValue = MALSAYMANI.Value;
                    MALSAYMANITARIH.CalcValue = MALSAYMANITARIH.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    HESAPSORUMLUSU.CalcValue = HESAPSORUMLUSU.Value;
                    HESAPSORUMLUSUTARIH.CalcValue = HESAPSORUMLUSUTARIH.Value;
                    TRANSACTIONDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TRANSACTIONDATE.PostFieldValueCalculation();
                    DESCRIPTION.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DESCRIPTION.PostFieldValueCalculation();
                    return new TTReportObject[] { DESCRIPTIONFIELD,NewField1333,NewField1332,NewField133,MALSORUMLUSU,MALSORUMLUSUTARIH,ONAYLAYAN,ONAYLAYANTARIH,MALSAYMANI,MALSAYMANITARIH,NewField1331,HESAPSORUMLUSU,HESAPSORUMLUSUTARIH,TRANSACTIONDATE,DESCRIPTION};
                }
                public override void RunPreScript()
                {
#region PARTB FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                {
                    string signDesc = string.Empty;
                    string unvan = string.Empty;
                    string vekil = string.Empty;
                    signDesc += stockActionSignDetail.SignUser.Name + "\r\n";
                    if (stockActionSignDetail.SignUser.Title != null && stockActionSignDetail.SignUser.Title != UserTitleEnum.Unused)
                        signDesc += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(stockActionSignDetail.SignUser.Title.Value).DisplayText;
                    if (stockActionSignDetail.SignUser.MilitaryClass != null)
                        signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                    if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
                    {
                        if(stockActionSignDetail.SignUser.StaffOfficer.HasValue && (bool)stockActionSignDetail.SignUser.StaffOfficer)
                            signDesc += "Kurmay " + stockActionSignDetail.SignUser.Rank.ShortName;
                        else
                            signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                        
                    }
                    if (stockActionSignDetail.SignUser != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.EmploymentRecordID) == false)
                        signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")\r\n";
                    if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
                        vekil += " Vek.";
                    if (stockActionSignDetail.SignUserType.HasValue)
                        unvan = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(stockActionSignDetail.SignUserType.Value).DisplayText;
                    switch (stockActionSignDetail.SignUserType)
                    {
                        case SignUserTypeEnum.HesapSorumlusu:
                            this.HESAPSORUMLUSUTARIH.Value = stockAction.TransactionDate.Value.ToShortDateString();
                            this.HESAPSORUMLUSU.Value = unvan + vekil + "\r\n" + signDesc;
                            break;
                        case SignUserTypeEnum.MalSorumlusu:
                            this.MALSORUMLUSUTARIH.Value = stockAction.TransactionDate.Value.ToShortDateString();
                            this.MALSORUMLUSU.Value = unvan + vekil + "\r\n" + signDesc;
                            break;
                        case SignUserTypeEnum.MalSaymani:
                            this.MALSAYMANITARIH.Value = stockAction.TransactionDate.Value.ToShortDateString();
                            this.MALSAYMANI.Value = unvan + vekil + "\r\n" + signDesc;
                            break;
                        case SignUserTypeEnum.BirlikXXXXXXi:
                            this.ONAYLAYANTARIH.Value = stockAction.TransactionDate.Value.ToShortDateString();
                            this.ONAYLAYAN.Value = unvan + vekil + "\r\n" + signDesc;
                            break;
                        default:
                            break;
                    }
                }
            }
#endregion PARTB FOOTER_PreScript
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public CensusFixedReport MyParentReport
            {
                get { return (CensusFixedReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField1211111 { get {return Header().NewField1211111;} }
            public TTReportField NewField13111131 { get {return Header().NewField13111131;} }
            public TTReportField NewField113111131 { get {return Header().NewField113111131;} }
            public TTReportField NewField113111132 { get {return Header().NewField113111132;} }
            public TTReportField NewField113111133 { get {return Header().NewField113111133;} }
            public TTReportField NewField113111134 { get {return Header().NewField113111134;} }
            public TTReportField NewField113111135 { get {return Header().NewField113111135;} }
            public TTReportField NewField113111136 { get {return Header().NewField113111136;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportShape NewLine12111 { get {return Footer().NewLine12111;} }
            public TTReportShape NewLine13111 { get {return Footer().NewLine13111;} }
            public TTReportShape NewLine14111 { get {return Footer().NewLine14111;} }
            public TTReportShape NewLine15111 { get {return Footer().NewLine15111;} }
            public TTReportShape NewLine16111 { get {return Footer().NewLine16111;} }
            public TTReportShape NewLine17111 { get {return Footer().NewLine17111;} }
            public TTReportShape NewLine18111 { get {return Footer().NewLine18111;} }
            public TTReportField ITEMCOUNT { get {return Footer().ITEMCOUNT;} }
            public TTReportField ITEM { get {return Footer().ITEM;} }
            public TTReportField ITEMTEXT { get {return Footer().ITEMTEXT;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
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
                public CensusFixedReport MyParentReport
                {
                    get { return (CensusFixedReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportField NewField1211111;
                public TTReportField NewField13111131;
                public TTReportField NewField113111131;
                public TTReportField NewField113111132;
                public TTReportField NewField113111133;
                public TTReportField NewField113111134;
                public TTReportField NewField113111135;
                public TTReportField NewField113111136; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 18, 18, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"
S. Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 41, 18, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Stok Nu.";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 96, 18, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.TextFont.Size = 11;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.Value = @"Taşınır Malın Cins, Özellikleri";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 107, 18, false);
                    NewField1211111.Name = "NewField1211111";
                    NewField1211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211111.TextFont.Name = "Arial Narrow";
                    NewField1211111.TextFont.Size = 11;
                    NewField1211111.TextFont.Bold = true;
                    NewField1211111.Value = @"
Ölçü
Birimi";

                    NewField13111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 119, 18, false);
                    NewField13111131.Name = "NewField13111131";
                    NewField13111131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13111131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13111131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13111131.TextFont.Name = "Arial Narrow";
                    NewField13111131.TextFont.Size = 8;
                    NewField13111131.TextFont.Bold = true;
                    NewField13111131.Value = @"
Kayıtlı
Miktar";

                    NewField113111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 131, 18, false);
                    NewField113111131.Name = "NewField113111131";
                    NewField113111131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111131.TextFont.Name = "Arial Narrow";
                    NewField113111131.TextFont.Size = 8;
                    NewField113111131.TextFont.Bold = true;
                    NewField113111131.Value = @"
Sayılan
Miktar";

                    NewField113111132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 143, 18, false);
                    NewField113111132.Name = "NewField113111132";
                    NewField113111132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111132.TextFont.Name = "Arial Narrow";
                    NewField113111132.TextFont.Size = 8;
                    NewField113111132.TextFont.Bold = true;
                    NewField113111132.Value = @"
Fazla
Miktar";

                    NewField113111133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 155, 18, false);
                    NewField113111133.Name = "NewField113111133";
                    NewField113111133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111133.TextFont.Name = "Arial Narrow";
                    NewField113111133.TextFont.Size = 8;
                    NewField113111133.TextFont.Bold = true;
                    NewField113111133.Value = @"
Eksik
Miktar";

                    NewField113111134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 171, 18, false);
                    NewField113111134.Name = "NewField113111134";
                    NewField113111134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111134.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111134.TextFont.Name = "Arial Narrow";
                    NewField113111134.TextFont.Size = 8;
                    NewField113111134.TextFont.Bold = true;
                    NewField113111134.Value = @"
Birim
Fiyatı";

                    NewField113111135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 186, 18, false);
                    NewField113111135.Name = "NewField113111135";
                    NewField113111135.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111135.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111135.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111135.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111135.TextFont.Name = "Arial Narrow";
                    NewField113111135.TextFont.Size = 8;
                    NewField113111135.TextFont.Bold = true;
                    NewField113111135.Value = @"
Fazlanın
Tutarı";

                    NewField113111136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 201, 18, false);
                    NewField113111136.Name = "NewField113111136";
                    NewField113111136.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111136.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111136.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111136.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111136.TextFont.Name = "Arial Narrow";
                    NewField113111136.TextFont.Size = 8;
                    NewField113111136.TextFont.Bold = true;
                    NewField113111136.Value = @"
Eksiğin
Tutarı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1211111.CalcValue = NewField1211111.Value;
                    NewField13111131.CalcValue = NewField13111131.Value;
                    NewField113111131.CalcValue = NewField113111131.Value;
                    NewField113111132.CalcValue = NewField113111132.Value;
                    NewField113111133.CalcValue = NewField113111133.Value;
                    NewField113111134.CalcValue = NewField113111134.Value;
                    NewField113111135.CalcValue = NewField113111135.Value;
                    NewField113111136.CalcValue = NewField113111136.Value;
                    return new TTReportObject[] { NewField11111,NewField111111,NewField1111111,NewField1211111,NewField13111131,NewField113111131,NewField113111132,NewField113111133,NewField113111134,NewField113111135,NewField113111136};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CensusFixedReport MyParentReport
                {
                    get { return (CensusFixedReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine12111;
                public TTReportShape NewLine13111;
                public TTReportShape NewLine14111;
                public TTReportShape NewLine15111;
                public TTReportShape NewLine16111;
                public TTReportShape NewLine17111;
                public TTReportShape NewLine18111;
                public TTReportField ITEMCOUNT;
                public TTReportField ITEM;
                public TTReportField ITEMTEXT;
                public TTReportShape NewLine1112; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, -1, 11, 20, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 7, 18, 28, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 96, 6, 96, 27, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 6, 119, 27, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 6, 131, 27, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 6, 143, 27, false);
                    NewLine13111.Name = "NewLine13111";
                    NewLine13111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 155, 6, 155, 27, false);
                    NewLine14111.Name = "NewLine14111";
                    NewLine14111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 6, 107, 27, false);
                    NewLine15111.Name = "NewLine15111";
                    NewLine15111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 171, 6, 171, 27, false);
                    NewLine16111.Name = "NewLine16111";
                    NewLine16111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 186, 6, 186, 27, false);
                    NewLine17111.Name = "NewLine17111";
                    NewLine17111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 0, 201, 21, false);
                    NewLine18111.Name = "NewLine18111";
                    NewLine18111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18111.ExtendTo = ExtendToEnum.extPageHeight;

                    ITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 200, 6, false);
                    ITEMCOUNT.Name = "ITEMCOUNT";
                    ITEMCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMCOUNT.TextFont.Name = "Arial Narrow";
                    ITEMCOUNT.TextFont.CharSet = 1;
                    ITEMCOUNT.Value = @"/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Yalnız {%ITEM%} ({%ITEMTEXT%}) kalemdir./////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";

                    ITEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 3, 249, 8, false);
                    ITEM.Name = "ITEM";
                    ITEM.Visible = EvetHayirEnum.ehHayir;
                    ITEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEM.TextFont.Name = "Arial Narrow";
                    ITEM.TextFont.CharSet = 1;
                    ITEM.Value = @"{@subgroupcount@}";

                    ITEMTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 8, 249, 13, false);
                    ITEMTEXT.Name = "ITEMTEXT";
                    ITEMTEXT.Visible = EvetHayirEnum.ehHayir;
                    ITEMTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMTEXT.TextFormat = @"NUMBERTEXT";
                    ITEMTEXT.TextFont.Name = "Arial Narrow";
                    ITEMTEXT.TextFont.CharSet = 1;
                    ITEMTEXT.Value = @"{%ITEM%}";

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 7, 41, 28, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ITEM.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    ITEMTEXT.CalcValue = MyParentReport.PARTA.ITEM.CalcValue;
                    ITEMCOUNT.CalcValue = @"/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Yalnız " + MyParentReport.PARTA.ITEM.CalcValue + @" (" + MyParentReport.PARTA.ITEMTEXT.FormattedValue + @") kalemdir./////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";
                    return new TTReportObject[] { ITEM,ITEMTEXT,ITEMCOUNT};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CensusFixedReport MyParentReport
            {
                get { return (CensusFixedReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CENSUSAMOUNT { get {return Body().CENSUSAMOUNT;} }
            public TTReportField CARDAMOUNT { get {return Body().CARDAMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField ORDERSEQUENCENUMBER { get {return Body().ORDERSEQUENCENUMBER;} }
            public TTReportField NATOSTOCKNOANDNAME { get {return Body().NATOSTOCKNOANDNAME;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField FAZLAMIKTAR { get {return Body().FAZLAMIKTAR;} }
            public TTReportField EKSIKMIKTAR { get {return Body().EKSIKMIKTAR;} }
            public TTReportField BIRININTUTARI { get {return Body().BIRININTUTARI;} }
            public TTReportField FAZLANINTUTARI { get {return Body().FAZLANINTUTARI;} }
            public TTReportField EKSIGININTUTARI { get {return Body().EKSIGININTUTARI;} }
            public TTReportField ISLEMTIPI { get {return Body().ISLEMTIPI;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
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
                list[0] = new TTReportNqlData<CensusFixed.CensusFixedReportForReportQuery_Class>("CensusFixedReportForReportQuery", CensusFixed.CensusFixedReportForReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public CensusFixedReport MyParentReport
                {
                    get { return (CensusFixedReport)ParentReport; }
                }
                
                public TTReportField CENSUSAMOUNT;
                public TTReportField CARDAMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField ORDERSEQUENCENUMBER;
                public TTReportField NATOSTOCKNOANDNAME;
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField NATOSTOCKNO;
                public TTReportField NAME;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField FAZLAMIKTAR;
                public TTReportField EKSIKMIKTAR;
                public TTReportField BIRININTUTARI;
                public TTReportField FAZLANINTUTARI;
                public TTReportField EKSIGININTUTARI;
                public TTReportField ISLEMTIPI;
                public TTReportField MATERIALNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CENSUSAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 131, 4, false);
                    CENSUSAMOUNT.Name = "CENSUSAMOUNT";
                    CENSUSAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CENSUSAMOUNT.TextFont.Name = "Arial Narrow";
                    CENSUSAMOUNT.TextFont.Size = 8;
                    CENSUSAMOUNT.Value = @"{#CENSUSAMOUNT#}";

                    CARDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 119, 4, false);
                    CARDAMOUNT.Name = "CARDAMOUNT";
                    CARDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CARDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CARDAMOUNT.TextFont.Name = "Arial Narrow";
                    CARDAMOUNT.TextFont.Size = 8;
                    CARDAMOUNT.Value = @"{#CARDAMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 107, 4, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial Narrow";
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    ORDERSEQUENCENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 18, 4, false);
                    ORDERSEQUENCENUMBER.Name = "ORDERSEQUENCENUMBER";
                    ORDERSEQUENCENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERSEQUENCENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERSEQUENCENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERSEQUENCENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERSEQUENCENUMBER.TextFont.Name = "Arial Narrow";
                    ORDERSEQUENCENUMBER.TextFont.Size = 8;
                    ORDERSEQUENCENUMBER.Value = @"{@counter@}";

                    NATOSTOCKNOANDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 41, 4, false);
                    NATOSTOCKNOANDNAME.Name = "NATOSTOCKNOANDNAME";
                    NATOSTOCKNOANDNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNOANDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNOANDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNOANDNAME.TextFont.Name = "Arial Narrow";
                    NATOSTOCKNOANDNAME.TextFont.Size = 8;
                    NATOSTOCKNOANDNAME.Value = @"{%NATOSTOCKNO%}";

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 1, 271, 5, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.TextFont.Name = "Arial Narrow";
                    STOCKACTIONDETAILOBJECTID.TextFont.CharSet = 1;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 7, 271, 11, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.Visible = EvetHayirEnum.ehHayir;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Name = "Arial Narrow";
                    NATOSTOCKNO.TextFont.CharSet = 1;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 13, 271, 18, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{#NAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 19, 271, 24, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.CharSet = 1;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 25, 271, 30, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFont.Name = "Arial Narrow";
                    UNITPRICE.TextFont.CharSet = 1;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    FAZLAMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 143, 4, false);
                    FAZLAMIKTAR.Name = "FAZLAMIKTAR";
                    FAZLAMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    FAZLAMIKTAR.TextFormat = @"#,##0.00";
                    FAZLAMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FAZLAMIKTAR.TextFont.Name = "Arial Narrow";
                    FAZLAMIKTAR.TextFont.Size = 8;
                    FAZLAMIKTAR.Value = @"";

                    EKSIKMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 155, 4, false);
                    EKSIKMIKTAR.Name = "EKSIKMIKTAR";
                    EKSIKMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    EKSIKMIKTAR.TextFormat = @"#,##0.00";
                    EKSIKMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    EKSIKMIKTAR.TextFont.Name = "Arial Narrow";
                    EKSIKMIKTAR.TextFont.Size = 8;
                    EKSIKMIKTAR.Value = @"";

                    BIRININTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 171, 4, false);
                    BIRININTUTARI.Name = "BIRININTUTARI";
                    BIRININTUTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRININTUTARI.TextFormat = @"#,##0.00";
                    BIRININTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRININTUTARI.TextFont.Name = "Arial Narrow";
                    BIRININTUTARI.TextFont.Size = 8;
                    BIRININTUTARI.Value = @"";

                    FAZLANINTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 186, 4, false);
                    FAZLANINTUTARI.Name = "FAZLANINTUTARI";
                    FAZLANINTUTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    FAZLANINTUTARI.TextFormat = @"#,##0.00";
                    FAZLANINTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FAZLANINTUTARI.TextFont.Name = "Arial Narrow";
                    FAZLANINTUTARI.TextFont.Size = 8;
                    FAZLANINTUTARI.Value = @"";

                    EKSIGININTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 201, 4, false);
                    EKSIGININTUTARI.Name = "EKSIGININTUTARI";
                    EKSIGININTUTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    EKSIGININTUTARI.TextFormat = @"#,##0.00";
                    EKSIGININTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    EKSIGININTUTARI.TextFont.Name = "Arial Narrow";
                    EKSIGININTUTARI.TextFont.Size = 8;
                    EKSIGININTUTARI.Value = @"";

                    ISLEMTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 31, 271, 36, false);
                    ISLEMTIPI.Name = "ISLEMTIPI";
                    ISLEMTIPI.Visible = EvetHayirEnum.ehHayir;
                    ISLEMTIPI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMTIPI.TextFont.Name = "Arial Narrow";
                    ISLEMTIPI.TextFont.CharSet = 1;
                    ISLEMTIPI.Value = @"{#ISLEMTIPI#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 96, 4, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial Narrow";
                    MATERIALNAME.TextFont.Size = 8;
                    MATERIALNAME.Value = @"{%NAME%} ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CensusFixed.CensusFixedReportForReportQuery_Class dataset_CensusFixedReportForReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CensusFixed.CensusFixedReportForReportQuery_Class>(0);
                    CENSUSAMOUNT.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.CensusAmount) : "");
                    CARDAMOUNT.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.CardAmount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.DistributionType) : "");
                    ORDERSEQUENCENUMBER.CalcValue = ParentGroup.Counter.ToString();
                    NATOSTOCKNO.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.NATOStockNO) : "");
                    NATOSTOCKNOANDNAME.CalcValue = MyParentReport.MAIN.NATOSTOCKNO.CalcValue;
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.Stockactiondetailobjectid) : "");
                    NAME.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.Name) : "");
                    AMOUNT.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.Unitprice) : "");
                    FAZLAMIKTAR.CalcValue = FAZLAMIKTAR.Value;
                    EKSIKMIKTAR.CalcValue = EKSIKMIKTAR.Value;
                    BIRININTUTARI.CalcValue = BIRININTUTARI.Value;
                    FAZLANINTUTARI.CalcValue = FAZLANINTUTARI.Value;
                    EKSIGININTUTARI.CalcValue = EKSIGININTUTARI.Value;
                    ISLEMTIPI.CalcValue = (dataset_CensusFixedReportForReportQuery != null ? Globals.ToStringCore(dataset_CensusFixedReportForReportQuery.Islemtipi) : "");
                    MATERIALNAME.CalcValue = MyParentReport.MAIN.NAME.CalcValue + @" ";
                    return new TTReportObject[] { CENSUSAMOUNT,CARDAMOUNT,DISTRIBUTIONTYPE,ORDERSEQUENCENUMBER,NATOSTOCKNO,NATOSTOCKNOANDNAME,STOCKACTIONDETAILOBJECTID,NAME,AMOUNT,UNITPRICE,FAZLAMIKTAR,EKSIKMIKTAR,BIRININTUTARI,FAZLANINTUTARI,EKSIGININTUTARI,ISLEMTIPI,MATERIALNAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (ISLEMTIPI.CalcValue.Equals("ARTTIRILAN"))
                    {
                        FAZLAMIKTAR.TextFormat = @"#,##0.00";
                        FAZLAMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                        FAZLAMIKTAR.CalcValue = AMOUNT.CalcValue;
                        FAZLANINTUTARI.TextFormat = @"#,##0.00";
                        FAZLANINTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                        if (string.IsNullOrEmpty(AMOUNT.CalcValue) == false && string.IsNullOrEmpty(UNITPRICE.CalcValue) == false)
                            FAZLANINTUTARI.CalcValue = Convert.ToString(Convert.ToDouble(AMOUNT.CalcValue) * Convert.ToDouble(UNITPRICE.CalcValue));

                        BIRININTUTARI.CalcValue = UNITPRICE.CalcValue;

                        EKSIKMIKTAR.TextFormat = "";
                        EKSIKMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                        EKSIKMIKTAR.CalcValue = "-";
                        EKSIGININTUTARI.TextFormat = "";
                        EKSIGININTUTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                        EKSIGININTUTARI.CalcValue = "-";
                    }

                    if (ISLEMTIPI.CalcValue.Equals("EKSILTILEN"))
                    {
                        EKSIKMIKTAR.TextFormat = @"#,##0.00";
                        EKSIKMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                        EKSIKMIKTAR.CalcValue = AMOUNT.CalcValue;
                        EKSIGININTUTARI.TextFormat = @"#,##0.00";
                        EKSIGININTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                        EKSIGININTUTARI.CalcValue = "0";

                        BIRININTUTARI.CalcValue = "0";

                        if (TTUtils.Globals.IsGuid(STOCKACTIONDETAILOBJECTID.CalcValue))
                        {
                            CensusFixedMaterialOut censusFixedMaterialOut = MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTIONDETAILOBJECTID.CalcValue), typeof(CensusFixedMaterialOut)) as CensusFixedMaterialOut;
                            if (censusFixedMaterialOut != null)
                            {
                                BIRININTUTARI.CalcValue = (censusFixedMaterialOut.TotalPrice.Value / censusFixedMaterialOut.Amount.Value).ToString();
                                EKSIGININTUTARI.CalcValue = censusFixedMaterialOut.TotalPrice.ToString();
                            }
                        }
                        FAZLAMIKTAR.TextFormat = "";
                        FAZLAMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                        FAZLAMIKTAR.CalcValue = "-";
                        FAZLANINTUTARI.TextFormat = "";
                        FAZLANINTUTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                        FAZLANINTUTARI.CalcValue = "-";
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

        public CensusFixedReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CENSUSFIXEDREPORT";
            Caption = "Sayım Düzeltme Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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