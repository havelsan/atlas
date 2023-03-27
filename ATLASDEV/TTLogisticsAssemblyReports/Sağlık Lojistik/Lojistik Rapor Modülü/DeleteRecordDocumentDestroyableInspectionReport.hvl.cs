
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
    /// Kayıt Silme Belgesi Muayene Raporu
    /// </summary>
    public partial class DeleteRecordDocumentDestroyableInspectionReport : TTReport
    {
#region Methods
   internal StockAction StockActionObject;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField RAPORNUMARASI { get {return Header().RAPORNUMARASI;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField124 { get {return Header().NewField124;} }
            public TTReportField TASINIRMALINCINSIOZELLIKLERI { get {return Header().TASINIRMALINCINSIOZELLIKLERI;} }
            public TTReportField KAYITTARIHI { get {return Header().KAYITTARIHI;} }
            public TTReportField MUAYENEKABULKOMISYONU { get {return Header().MUAYENEKABULKOMISYONU;} }
            public TTReportField IMZA1 { get {return Footer().IMZA1;} }
            public TTReportField IMZA2 { get {return Footer().IMZA2;} }
            public TTReportField IMZA3 { get {return Footer().IMZA3;} }
            public TTReportField IMZA4 { get {return Footer().IMZA4;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField NewField12421 { get {return Footer().NewField12421;} }
            public TTReportField NewField112421 { get {return Footer().NewField112421;} }
            public TTReportField IMZABASLIK1 { get {return Footer().IMZABASLIK1;} }
            public TTReportField IMZABASLIK2 { get {return Footer().IMZABASLIK2;} }
            public TTReportField IMZABASLIK3 { get {return Footer().IMZABASLIK3;} }
            public TTReportField IMZABASLIK4 { get {return Footer().IMZABASLIK4;} }
            public TTReportField IMZATARIH1 { get {return Footer().IMZATARIH1;} }
            public TTReportField IMZATARIH2 { get {return Footer().IMZATARIH2;} }
            public TTReportField IMZATARIH3 { get {return Footer().IMZATARIH3;} }
            public TTReportField IMZATARIH4 { get {return Footer().IMZATARIH4;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField RAPORNUMARASI;
                public TTReportField MUAYENETARIHI;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField NewField124;
                public TTReportField TASINIRMALINCINSIOZELLIKLERI;
                public TTReportField KAYITTARIHI;
                public TTReportField MUAYENEKABULKOMISYONU; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 60;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 16, 195, 26, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"KAYIT SİLMEYE ESAS MUAYENE KOMİSYON RAPORU";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 26, 105, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.Value = @"Kayıt Tarihi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 40, 105, 47, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.Value = @"Muayene ve Kabul Komisyonu";

                    RAPORNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 54, 195, 61, false);
                    RAPORNUMARASI.Name = "RAPORNUMARASI";
                    RAPORNUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNUMARASI.Value = @"";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 47, 195, 54, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 33, 105, 40, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.Value = @"Taşınır Malın Cinsi, Özellikleri";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 47, 105, 54, false);
                    NewField123.Name = "NewField123";
                    NewField123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.Value = @"Muayene Tarihi";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 54, 105, 61, false);
                    NewField124.Name = "NewField124";
                    NewField124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField124.Value = @"Rapor Numarası";

                    TASINIRMALINCINSIOZELLIKLERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 33, 195, 40, false);
                    TASINIRMALINCINSIOZELLIKLERI.Name = "TASINIRMALINCINSIOZELLIKLERI";
                    TASINIRMALINCINSIOZELLIKLERI.DrawStyle = DrawStyleConstants.vbSolid;
                    TASINIRMALINCINSIOZELLIKLERI.Value = @"";

                    KAYITTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 26, 195, 33, false);
                    KAYITTARIHI.Name = "KAYITTARIHI";
                    KAYITTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    KAYITTARIHI.TextFormat = @"dd/MM/yyyy";
                    KAYITTARIHI.Value = @"";

                    MUAYENEKABULKOMISYONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 40, 195, 47, false);
                    MUAYENEKABULKOMISYONU.Name = "MUAYENEKABULKOMISYONU";
                    MUAYENEKABULKOMISYONU.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENEKABULKOMISYONU.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    RAPORNUMARASI.CalcValue = RAPORNUMARASI.Value;
                    MUAYENETARIHI.CalcValue = MUAYENETARIHI.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField124.CalcValue = NewField124.Value;
                    TASINIRMALINCINSIOZELLIKLERI.CalcValue = TASINIRMALINCINSIOZELLIKLERI.Value;
                    KAYITTARIHI.CalcValue = KAYITTARIHI.Value;
                    MUAYENEKABULKOMISYONU.CalcValue = MUAYENEKABULKOMISYONU.Value;
                    return new TTReportObject[] { NewField11,NewField12,NewField121,RAPORNUMARASI,MUAYENETARIHI,NewField122,NewField123,NewField124,TASINIRMALINCINSIOZELLIKLERI,KAYITTARIHI,MUAYENEKABULKOMISYONU};
                }
                public override void RunPreScript()
                {
#region PARTC HEADER_PreScript
                    if (MyParentReport.StockActionObject != null)
                    {
                        if (MyParentReport.StockActionObject.StockActionInspection != null)
                        {
                            if (MyParentReport.StockActionObject.StockActionInspection.ReportNumberSeq != null)
                                this.RAPORNUMARASI.Value = MyParentReport.StockActionObject.StockActionInspection.ReportNumberNotSeq.ToString();
                            if (MyParentReport.StockActionObject.StockActionInspection.InspectionDate.HasValue)
                                this.MUAYENETARIHI.Value = MyParentReport.StockActionObject.StockActionInspection.InspectionDate.Value.ToShortDateString();
                            if (MyParentReport.StockActionObject.TransactionDate.HasValue)
                                this.KAYITTARIHI.Value = MyParentReport.StockActionObject.TransactionDate.Value.ToShortDateString();
                        }
                    }
#endregion PARTC HEADER_PreScript
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
                }
                
                public TTReportField IMZA1;
                public TTReportField IMZA2;
                public TTReportField IMZA3;
                public TTReportField IMZA4;
                public TTReportShape NewLine1;
                public TTReportField NewField111;
                public TTReportField NewField12421;
                public TTReportField NewField112421;
                public TTReportField IMZABASLIK1;
                public TTReportField IMZABASLIK2;
                public TTReportField IMZABASLIK3;
                public TTReportField IMZABASLIK4;
                public TTReportField IMZATARIH1;
                public TTReportField IMZATARIH2;
                public TTReportField IMZATARIH3;
                public TTReportField IMZATARIH4; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 58;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    IMZA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 16, 87, 32, false);
                    IMZA1.Name = "IMZA1";
                    IMZA1.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA1.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA1.TextFont.Size = 8;
                    IMZA1.TextFont.CharSet = 162;
                    IMZA1.Value = @"";

                    IMZA2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 16, 123, 32, false);
                    IMZA2.Name = "IMZA2";
                    IMZA2.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA2.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA2.TextFont.Size = 8;
                    IMZA2.TextFont.CharSet = 162;
                    IMZA2.Value = @"";

                    IMZA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 16, 159, 32, false);
                    IMZA3.Name = "IMZA3";
                    IMZA3.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA3.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA3.TextFont.Size = 8;
                    IMZA3.TextFont.CharSet = 162;
                    IMZA3.Value = @"";

                    IMZA4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 16, 195, 32, false);
                    IMZA4.Name = "IMZA4";
                    IMZA4.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA4.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA4.TextFont.Size = 8;
                    IMZA4.TextFont.CharSet = 162;
                    IMZA4.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 195, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 3, 195, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"M U A Y E N E   K U R U L U";

                    NewField12421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 16, 49, 38, false);
                    NewField12421.Name = "NewField12421";
                    NewField12421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12421.TextFont.CharSet = 162;
                    NewField12421.Value = @" Adı Soyadı
 Rütbesi/Ünvanı/Sicil Nu.sı

 İmzası
 Tarih";

                    NewField112421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 16, 52, 38, false);
                    NewField112421.Name = "NewField112421";
                    NewField112421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112421.TextFont.CharSet = 162;
                    NewField112421.Value = @":
:

:
:";

                    IMZABASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 11, 87, 16, false);
                    IMZABASLIK1.Name = "IMZABASLIK1";
                    IMZABASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK1.TextFont.Bold = true;
                    IMZABASLIK1.TextFont.CharSet = 162;
                    IMZABASLIK1.Value = @"";

                    IMZABASLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 11, 123, 16, false);
                    IMZABASLIK2.Name = "IMZABASLIK2";
                    IMZABASLIK2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK2.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK2.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK2.TextFont.Bold = true;
                    IMZABASLIK2.TextFont.CharSet = 162;
                    IMZABASLIK2.Value = @"";

                    IMZABASLIK3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 11, 159, 16, false);
                    IMZABASLIK3.Name = "IMZABASLIK3";
                    IMZABASLIK3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK3.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK3.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK3.TextFont.Bold = true;
                    IMZABASLIK3.TextFont.CharSet = 162;
                    IMZABASLIK3.Value = @"";

                    IMZABASLIK4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 11, 195, 16, false);
                    IMZABASLIK4.Name = "IMZABASLIK4";
                    IMZABASLIK4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZABASLIK4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZABASLIK4.MultiLine = EvetHayirEnum.ehEvet;
                    IMZABASLIK4.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZABASLIK4.TextFont.Bold = true;
                    IMZABASLIK4.TextFont.CharSet = 162;
                    IMZABASLIK4.Value = @"";

                    IMZATARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 33, 87, 38, false);
                    IMZATARIH1.Name = "IMZATARIH1";
                    IMZATARIH1.TextFormat = @"dd/MM/yyyy";
                    IMZATARIH1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZATARIH1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZATARIH1.TextFont.Bold = true;
                    IMZATARIH1.TextFont.CharSet = 162;
                    IMZATARIH1.Value = @"";

                    IMZATARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 33, 123, 38, false);
                    IMZATARIH2.Name = "IMZATARIH2";
                    IMZATARIH2.TextFormat = @"dd/MM/yyyy";
                    IMZATARIH2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZATARIH2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZATARIH2.TextFont.Bold = true;
                    IMZATARIH2.TextFont.CharSet = 162;
                    IMZATARIH2.Value = @"";

                    IMZATARIH3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 33, 159, 38, false);
                    IMZATARIH3.Name = "IMZATARIH3";
                    IMZATARIH3.TextFormat = @"dd/MM/yyyy";
                    IMZATARIH3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZATARIH3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZATARIH3.TextFont.Bold = true;
                    IMZATARIH3.TextFont.CharSet = 162;
                    IMZATARIH3.Value = @"";

                    IMZATARIH4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 33, 195, 38, false);
                    IMZATARIH4.Name = "IMZATARIH4";
                    IMZATARIH4.TextFormat = @"dd/MM/yyyy";
                    IMZATARIH4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZATARIH4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMZATARIH4.TextFont.Bold = true;
                    IMZATARIH4.TextFont.CharSet = 162;
                    IMZATARIH4.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    IMZA1.CalcValue = IMZA1.Value;
                    IMZA2.CalcValue = IMZA2.Value;
                    IMZA3.CalcValue = IMZA3.Value;
                    IMZA4.CalcValue = IMZA4.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField12421.CalcValue = NewField12421.Value;
                    NewField112421.CalcValue = NewField112421.Value;
                    IMZABASLIK1.CalcValue = IMZABASLIK1.Value;
                    IMZABASLIK2.CalcValue = IMZABASLIK2.Value;
                    IMZABASLIK3.CalcValue = IMZABASLIK3.Value;
                    IMZABASLIK4.CalcValue = IMZABASLIK4.Value;
                    IMZATARIH1.CalcValue = IMZATARIH1.Value;
                    IMZATARIH2.CalcValue = IMZATARIH2.Value;
                    IMZATARIH3.CalcValue = IMZATARIH3.Value;
                    IMZATARIH4.CalcValue = IMZATARIH4.Value;
                    return new TTReportObject[] { IMZA1,IMZA2,IMZA3,IMZA4,NewField111,NewField12421,NewField112421,IMZABASLIK1,IMZABASLIK2,IMZABASLIK3,IMZABASLIK4,IMZATARIH1,IMZATARIH2,IMZATARIH3,IMZATARIH4};
                }
                public override void RunPreScript()
                {
#region PARTC FOOTER_PreScript
                    if (MyParentReport.StockActionObject != null)
            {
                if (MyParentReport.StockActionObject.StockActionInspection != null)
                {
                    int i = 1;
                    foreach (StockActionInspectionDetail stockActionInspectionDetail in MyParentReport.StockActionObject.StockActionInspection.StockActionInspectionDetails)
                    {
                        string signDesc = string.Empty;
                        string vekil = string.Empty;
                        signDesc = stockActionInspectionDetail.NameString + "\r\n" + stockActionInspectionDetail.ShortMilitaryClass + stockActionInspectionDetail.ShortRank +"\r\n(" + stockActionInspectionDetail.EmploymentRecordID +")";
                        
                        //                        if (stockActionInspectionDetail.InspectionUser.MilitaryClass != null)
                        //                            signDesc += stockActionInspectionDetail.InspectionUser.MilitaryClass.ShortName;
                        //                        if (stockActionInspectionDetail.InspectionUser.Rank != null)
                        //                            signDesc += stockActionInspectionDetail.InspectionUser.Rank.ShortName;
                        //                        signDesc += "(" + stockActionInspectionDetail.InspectionUser.EmploymentRecordID + ")";

                        string gorev = stockActionInspectionDetail.ObjectDef.AllPropertyDefs["INSPECTIONUSERTYPE"].DataType.EnumValueDefs[(int)stockActionInspectionDetail.InspectionUserType.Value].DisplayText;
                        if(i.Equals(1))
                        {
                            this.IMZABASLIK1.Value = gorev;
                            this.IMZA1.Value = signDesc;
                            if (MyParentReport.StockActionObject.StockActionInspection.InspectionDate.HasValue)
                                this.IMZATARIH1.Value = MyParentReport.StockActionObject.StockActionInspection.InspectionDate.Value.ToShortDateString();
                        }

                        if (i.Equals(2))
                        {
                            this.IMZABASLIK2.Value = gorev;
                            this.IMZA2.Value = signDesc;
                            if (MyParentReport.StockActionObject.StockActionInspection.InspectionDate.HasValue)
                                this.IMZATARIH2.Value = MyParentReport.StockActionObject.StockActionInspection.InspectionDate.Value.ToShortDateString();
                        }

                        if (i.Equals(3))
                        {
                            this.IMZABASLIK3.Value = gorev;
                            this.IMZA3.Value = signDesc;
                            if (MyParentReport.StockActionObject.StockActionInspection.InspectionDate.HasValue)
                                this.IMZATARIH3.Value = MyParentReport.StockActionObject.StockActionInspection.InspectionDate.Value.ToShortDateString();
                        }

                        if (i.Equals(4))
                        {
                            this.IMZABASLIK4.Value = gorev;
                            this.IMZA4.Value = signDesc;
                            if (MyParentReport.StockActionObject.StockActionInspection.InspectionDate.HasValue)
                                this.IMZATARIH4.Value = MyParentReport.StockActionObject.StockActionInspection.InspectionDate.Value.ToShortDateString();
                        }
                        i++;
                    }
                }
            }
#endregion PARTC FOOTER_PreScript
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField NewField1134311 { get {return Header().NewField1134311;} }
            public TTReportField NewField1114311 { get {return Header().NewField1114311;} }
            public TTReportField NewField11134111 { get {return Header().NewField11134111;} }
            public TTReportField NewField11134112 { get {return Header().NewField11134112;} }
            public TTReportField NewField11134113 { get {return Header().NewField11134113;} }
            public TTReportField NewField11134114 { get {return Header().NewField11134114;} }
            public TTReportField NewField111143111 { get {return Header().NewField111143111;} }
            public TTReportField NewField111143112 { get {return Header().NewField111143112;} }
            public TTReportField NewField1111341111 { get {return Header().NewField1111341111;} }
            public TTReportRTF RAPORRTF { get {return Footer().RAPORRTF;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
                }
                
                public TTReportField NewField1141;
                public TTReportField NewField11421;
                public TTReportField NewField11431;
                public TTReportField NewField113411;
                public TTReportField NewField1134311;
                public TTReportField NewField1114311;
                public TTReportField NewField11134111;
                public TTReportField NewField11134112;
                public TTReportField NewField11134113;
                public TTReportField NewField11134114;
                public TTReportField NewField111143111;
                public TTReportField NewField111143112;
                public TTReportField NewField1111341111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 27, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"

 S.
 Nu.
";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 90, 27, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"Taşınır Malın Cinsi";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 105, 27, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"
Miktarı
";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 120, 27, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"

Ölçü
Birimi
";

                    NewField1134311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 195, 9, false);
                    NewField1134311.Name = "NewField1134311";
                    NewField1134311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1134311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1134311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1134311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1134311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1134311.TextFont.CharSet = 162;
                    NewField1134311.Value = @"Kaydı Silinecek Taşınır Mala Yapılacak İşlem
";

                    NewField1114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 9, 133, 27, false);
                    NewField1114311.Name = "NewField1114311";
                    NewField1114311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114311.TextFont.CharSet = 162;
                    NewField1114311.Value = @"";

                    NewField11134111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 9, 129, 29, false);
                    NewField11134111.Name = "NewField11134111";
                    NewField11134111.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField11134111.FontAngle = 900;
                    NewField11134111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11134111.TextFont.CharSet = 162;
                    NewField11134111.Value = @"Yok Etme";

                    NewField11134112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 9, 146, 27, false);
                    NewField11134112.Name = "NewField11134112";
                    NewField11134112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11134112.TextFont.CharSet = 162;
                    NewField11134112.Value = @"";

                    NewField11134113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 9, 159, 27, false);
                    NewField11134113.Name = "NewField11134113";
                    NewField11134113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11134113.TextFont.CharSet = 162;
                    NewField11134113.Value = @"";

                    NewField11134114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 9, 195, 27, false);
                    NewField11134114.Name = "NewField11134114";
                    NewField11134114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11134114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11134114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11134114.TextFont.CharSet = 162;
                    NewField11134114.Value = @"Açıklama";

                    NewField111143111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 9, 157, 29, false);
                    NewField111143111.Name = "NewField111143111";
                    NewField111143111.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField111143111.FontAngle = 900;
                    NewField111143111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111143111.TextFont.CharSet = 162;
                    NewField111143111.Value = @"Onarım";

                    NewField111143112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 9, 142, 29, false);
                    NewField111143112.Name = "NewField111143112";
                    NewField111143112.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField111143112.FontAngle = 900;
                    NewField111143112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111143112.TextFont.CharSet = 162;
                    NewField111143112.Value = @"Ayıklama";

                    NewField1111341111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 9, 153, 29, false);
                    NewField1111341111.Name = "NewField1111341111";
                    NewField1111341111.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1111341111.FontAngle = 900;
                    NewField1111341111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111341111.TextFont.CharSet = 162;
                    NewField1111341111.Value = @"Temizlik/";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    NewField1134311.CalcValue = NewField1134311.Value;
                    NewField1114311.CalcValue = NewField1114311.Value;
                    NewField11134111.CalcValue = NewField11134111.Value;
                    NewField11134112.CalcValue = NewField11134112.Value;
                    NewField11134113.CalcValue = NewField11134113.Value;
                    NewField11134114.CalcValue = NewField11134114.Value;
                    NewField111143111.CalcValue = NewField111143111.Value;
                    NewField111143112.CalcValue = NewField111143112.Value;
                    NewField1111341111.CalcValue = NewField1111341111.Value;
                    return new TTReportObject[] { NewField1141,NewField11421,NewField11431,NewField113411,NewField1134311,NewField1114311,NewField11134111,NewField11134112,NewField11134113,NewField11134114,NewField111143111,NewField111143112,NewField1111341111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
                }
                
                public TTReportRTF RAPORRTF;
                public TTReportShape NewLine1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    RAPORRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 17, 1, 193, 6, false);
                    RAPORRTF.Name = "RAPORRTF";
                    RAPORRTF.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 190, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RAPORRTF.CalcValue = RAPORRTF.Value;
                    return new TTReportObject[] { RAPORRTF};
                }
                public override void RunPreScript()
                {
#region PARTB FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                        if (stockAction.StockActionInspection != null)
                        {
                            if (stockAction.StockActionInspection.InspectionReport != null)
                                this.RAPORRTF.Value = stockAction.StockActionInspection.InspectionReport.ToString();
                        }
                    }
#endregion PARTB FOOTER_PreScript
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine1511121 { get {return Body().NewLine1511121;} }
            public TTReportField NEWFIELD1 { get {return Body().NEWFIELD1;} }
            public TTReportField NEWFIELD2 { get {return Body().NEWFIELD2;} }
            public TTReportField NEWFIELD3 { get {return Body().NEWFIELD3;} }
            public TTReportField NEWFIELD13 { get {return Body().NEWFIELD13;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DeleteRecordDocumentDestroyableInspectionReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableInspectionReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField MATERIALNAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine1511121;
                public TTReportField NEWFIELD1;
                public TTReportField NEWFIELD2;
                public TTReportField NEWFIELD3;
                public TTReportField NEWFIELD13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 7, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@} ";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 90, 7, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 42, 7, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 105, 7, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 120, 7, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.Value = @" {#DISTRIBUTIONTYPE#}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 2, 15, 7, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1511121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 1, 195, 7, false);
                    NewLine1511121.Name = "NewLine1511121";
                    NewLine1511121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1511121.ExtendTo = ExtendToEnum.extPageHeight;

                    NEWFIELD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 133, 7, false);
                    NEWFIELD1.Name = "NEWFIELD1";
                    NEWFIELD1.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWFIELD1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWFIELD1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWFIELD1.TextFont.Size = 18;
                    NEWFIELD1.TextFont.CharSet = 162;
                    NEWFIELD1.Value = @"";

                    NEWFIELD2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 146, 7, false);
                    NEWFIELD2.Name = "NEWFIELD2";
                    NEWFIELD2.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWFIELD2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWFIELD2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWFIELD2.TextFont.Size = 18;
                    NEWFIELD2.TextFont.CharSet = 162;
                    NEWFIELD2.Value = @"";

                    NEWFIELD3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 159, 7, false);
                    NEWFIELD3.Name = "NEWFIELD3";
                    NEWFIELD3.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWFIELD3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWFIELD3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWFIELD3.TextFont.Size = 18;
                    NEWFIELD3.TextFont.CharSet = 162;
                    NEWFIELD3.Value = @"";

                    NEWFIELD13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 0, 195, 7, false);
                    NEWFIELD13.Name = "NEWFIELD13";
                    NEWFIELD13.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWFIELD13.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    MATERIALNAME.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "");
                    NATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = @" " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    NEWFIELD1.CalcValue = NEWFIELD1.Value;
                    NEWFIELD2.CalcValue = NEWFIELD2.Value;
                    NEWFIELD3.CalcValue = NEWFIELD3.Value;
                    NEWFIELD13.CalcValue = NEWFIELD13.Value;
                    return new TTReportObject[] { COUNTER,MATERIALNAME,NATOSTOCKNO,AMOUNT,DISTRIBUTIONTYPE,NEWFIELD1,NEWFIELD2,NEWFIELD3,NEWFIELD13};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    if (MyParentReport.StockActionObject != null)
                    {
                        if (MyParentReport.StockActionObject is DeleteRecordDocumentDestroyable)
                            NEWFIELD1.Value = "X";
                        if (MyParentReport.StockActionObject is DeleteRecordDocumentWaste)
                            NEWFIELD2.Value = "X";
                    }
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DeleteRecordDocumentDestroyableInspectionReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DELETERECORDDOCUMENTDESTROYABLEINSPECTIONREPORT";
            Caption = "Kayıt Silme Belgesi Muayene Raporu";
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
#region DELETERECORDDOCUMENTDESTROYABLEINSPECTIONREPORT_PreScript
            base.RunPreScript();

            if (this.RuntimeParameters.TTOBJECTID.HasValue)
                StockActionObject = (StockAction)this.ReportObjectContext.GetObject(this.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
#endregion DELETERECORDDOCUMENTDESTROYABLEINSPECTIONREPORT_PreScript
        }
    }
}