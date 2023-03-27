
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
    /// Kayıt Silme Belgesi
    /// </summary>
    public partial class DeleteRecordDocumentDestroyableReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField EKLER { get {return Footer().EKLER;} }
            public TTReportField DESC1 { get {return Footer().DESC1;} }
            public TTReportField DESC2 { get {return Footer().DESC2;} }
            public TTReportField NewField142 { get {return Footer().NewField142;} }
            public TTReportField NewField11123 { get {return Footer().NewField11123;} }
            public TTReportField NewField11124 { get {return Footer().NewField11124;} }
            public TTReportField NewField142111 { get {return Footer().NewField142111;} }
            public TTReportField BIRLIKXXXXXXI { get {return Footer().BIRLIKXXXXXXI;} }
            public TTReportField MUAYENEBASKAN { get {return Footer().MUAYENEBASKAN;} }
            public TTReportField YETKILIMAKAM { get {return Footer().YETKILIMAKAM;} }
            public TTReportField MALSAYMANI { get {return Footer().MALSAYMANI;} }
            public TTReportField HESAPSORUMLUSU { get {return Footer().HESAPSORUMLUSU;} }
            public TTReportField MUAYENEUYE1 { get {return Footer().MUAYENEUYE1;} }
            public TTReportField MUAYENEUYE2 { get {return Footer().MUAYENEUYE2;} }
            public TTReportField NewFieldMK { get {return Footer().NewFieldMK;} }
            public TTReportField MUAYENEDESC { get {return Footer().MUAYENEDESC;} }
            public TTReportField MALSORUMLUSU { get {return Footer().MALSORUMLUSU;} }
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
                public DeleteRecordDocumentDestroyableReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DeleteRecordDocumentDestroyableReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
                }
                
                public TTReportField NewField141;
                public TTReportField EKLER;
                public TTReportField DESC1;
                public TTReportField DESC2;
                public TTReportField NewField142;
                public TTReportField NewField11123;
                public TTReportField NewField11124;
                public TTReportField NewField142111;
                public TTReportField BIRLIKXXXXXXI;
                public TTReportField MUAYENEBASKAN;
                public TTReportField YETKILIMAKAM;
                public TTReportField MALSAYMANI;
                public TTReportField HESAPSORUMLUSU;
                public TTReportField MUAYENEUYE1;
                public TTReportField MUAYENEUYE2;
                public TTReportField NewFieldMK;
                public TTReportField MUAYENEDESC;
                public TTReportField MALSORUMLUSU; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 70;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 21, 21, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.FontAngle = 900;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Ekler
";

                    EKLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 144, 21, false);
                    EKLER.Name = "EKLER";
                    EKLER.DrawStyle = DrawStyleConstants.vbSolid;
                    EKLER.MultiLine = EvetHayirEnum.ehEvet;
                    EKLER.WordBreak = EvetHayirEnum.ehEvet;
                    EKLER.ExpandTabs = EvetHayirEnum.ehEvet;
                    EKLER.TextFont.CharSet = 162;
                    EKLER.Value = @"";

                    DESC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 246, 21, false);
                    DESC1.Name = "DESC1";
                    DESC1.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC1.MultiLine = EvetHayirEnum.ehEvet;
                    DESC1.WordBreak = EvetHayirEnum.ehEvet;
                    DESC1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESC1.TextFont.CharSet = 162;
                    DESC1.Value = @"";

                    DESC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 284, 21, false);
                    DESC2.Name = "DESC2";
                    DESC2.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC2.MultiLine = EvetHayirEnum.ehEvet;
                    DESC2.WordBreak = EvetHayirEnum.ehEvet;
                    DESC2.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESC2.TextFont.CharSet = 162;
                    DESC2.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 21, 32, 54, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"
 Tarih
 İmza
 Adı Soyadı
 Rütbesi

 Görevi";

                    NewField11123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 21, 144, 54, false);
                    NewField11123.Name = "NewField11123";
                    NewField11123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11123.TextFont.CharSet = 162;
                    NewField11123.Value = @"";

                    NewField11124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 21, 246, 54, false);
                    NewField11124.Name = "NewField11124";
                    NewField11124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11124.TextFont.CharSet = 162;
                    NewField11124.Value = @"";

                    NewField142111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 21, 284, 54, false);
                    NewField142111.Name = "NewField142111";
                    NewField142111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142111.TextFont.CharSet = 162;
                    NewField142111.Value = @"";

                    BIRLIKXXXXXXI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 24, 61, 52, false);
                    BIRLIKXXXXXXI.Name = "BIRLIKXXXXXXI";
                    BIRLIKXXXXXXI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.TextFont.Size = 7;
                    BIRLIKXXXXXXI.TextFont.CharSet = 162;
                    BIRLIKXXXXXXI.Value = @"BIRLIKXXXXXXI";

                    MUAYENEBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 33, 177, 52, false);
                    MUAYENEBASKAN.Name = "MUAYENEBASKAN";
                    MUAYENEBASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENEBASKAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    MUAYENEBASKAN.Value = @"MUAYENEBASKAN";

                    YETKILIMAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 24, 283, 52, false);
                    YETKILIMAKAM.Name = "YETKILIMAKAM";
                    YETKILIMAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    YETKILIMAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YETKILIMAKAM.TextFont.CharSet = 162;
                    YETKILIMAKAM.Value = @"YETKILIMAKAM";

                    MALSAYMANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 24, 88, 52, false);
                    MALSAYMANI.Name = "MALSAYMANI";
                    MALSAYMANI.MultiLine = EvetHayirEnum.ehEvet;
                    MALSAYMANI.WordBreak = EvetHayirEnum.ehEvet;
                    MALSAYMANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSAYMANI.TextFont.Size = 7;
                    MALSAYMANI.TextFont.CharSet = 162;
                    MALSAYMANI.Value = @"MALSAYMANI";

                    HESAPSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 24, 117, 52, false);
                    HESAPSORUMLUSU.Name = "HESAPSORUMLUSU";
                    HESAPSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.ExpandTabs = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.TextFont.Size = 7;
                    HESAPSORUMLUSU.TextFont.CharSet = 162;
                    HESAPSORUMLUSU.Value = @"HESAPSORUMLUSU";

                    MUAYENEUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 33, 211, 52, false);
                    MUAYENEUYE1.Name = "MUAYENEUYE1";
                    MUAYENEUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENEUYE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    MUAYENEUYE1.TextFont.Size = 7;
                    MUAYENEUYE1.TextFont.CharSet = 162;
                    MUAYENEUYE1.Value = @"";

                    MUAYENEUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 33, 245, 52, false);
                    MUAYENEUYE2.Name = "MUAYENEUYE2";
                    MUAYENEUYE2.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENEUYE2.ExpandTabs = EvetHayirEnum.ehEvet;
                    MUAYENEUYE2.Value = @"";

                    NewFieldMK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 21, 247, 24, false);
                    NewFieldMK.Name = "NewFieldMK";
                    NewFieldMK.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewFieldMK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldMK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldMK.TextFont.CharSet = 162;
                    NewFieldMK.Value = @"Muayene ve Kabul Komisyonu";

                    MUAYENEDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 24, 246, 28, false);
                    MUAYENEDESC.Name = "MUAYENEDESC";
                    MUAYENEDESC.FillStyle = FillStyleConstants.vbFSTransparent;
                    MUAYENEDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENEDESC.TextFont.CharSet = 162;
                    MUAYENEDESC.Value = @"";

                    MALSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 24, 144, 52, false);
                    MALSORUMLUSU.Name = "MALSORUMLUSU";
                    MALSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.TextFont.Size = 7;
                    MALSORUMLUSU.TextFont.CharSet = 162;
                    MALSORUMLUSU.Value = @"MALSORUMLUSU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField141.CalcValue = NewField141.Value;
                    EKLER.CalcValue = EKLER.Value;
                    DESC1.CalcValue = DESC1.Value;
                    DESC2.CalcValue = DESC2.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField11123.CalcValue = NewField11123.Value;
                    NewField11124.CalcValue = NewField11124.Value;
                    NewField142111.CalcValue = NewField142111.Value;
                    BIRLIKXXXXXXI.CalcValue = BIRLIKXXXXXXI.Value;
                    MUAYENEBASKAN.CalcValue = MUAYENEBASKAN.Value;
                    YETKILIMAKAM.CalcValue = YETKILIMAKAM.Value;
                    MALSAYMANI.CalcValue = MALSAYMANI.Value;
                    HESAPSORUMLUSU.CalcValue = HESAPSORUMLUSU.Value;
                    MUAYENEUYE1.CalcValue = MUAYENEUYE1.Value;
                    MUAYENEUYE2.CalcValue = MUAYENEUYE2.Value;
                    NewFieldMK.CalcValue = NewFieldMK.Value;
                    MUAYENEDESC.CalcValue = MUAYENEDESC.Value;
                    MALSORUMLUSU.CalcValue = MALSORUMLUSU.Value;
                    return new TTReportObject[] { NewField141,EKLER,DESC1,DESC2,NewField142,NewField11123,NewField11124,NewField142111,BIRLIKXXXXXXI,MUAYENEBASKAN,YETKILIMAKAM,MALSAYMANI,HESAPSORUMLUSU,MUAYENEUYE1,MUAYENEUYE2,NewFieldMK,MUAYENEDESC,MALSORUMLUSU};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                this.EKLER.Value = stockAction.Description;
                this.DESC1.Value = "Belgede yazılı (" + stockAction.StockActionOutDetails.Count + ") kalem Taşınır Mal  .......................................................................................... durumundadır.";
                this.DESC2.Value = "Belgede yazılı (" + stockAction.StockActionOutDetails.Count + ") kalem Taşınır Malın kayıtlarının silinmesi uygundur.";
                foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                {
                    string signDesc = string.Empty;
                    string vekil = string.Empty;
                    signDesc = stockAction.TransactionDate.Value.ToShortDateString() + "\r\n\r\n";
                    if(stockActionSignDetail.SignUser != null)
                    {
                        signDesc += stockActionSignDetail.SignUser.Name + "\r\n";
                        if(stockActionSignDetail.SignUser.MilitaryClass != null)
                            signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                        if(stockActionSignDetail.SignUser.Rank != null)
                        {
                            if(stockActionSignDetail.SignUser.StaffOfficer.HasValue && (bool)stockActionSignDetail.SignUser.StaffOfficer)
                                signDesc += "Kurmay " + stockActionSignDetail.SignUser.Rank.ShortName;
                            else
                                signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                        }
                        signDesc += "\r\n(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")\r\n";
                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(SignUserTypeEnum).Name];
                        signDesc += dataType.EnumValueDefs[(int)stockActionSignDetail.SignUserType.Value].DisplayText;
                        if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
                            signDesc += " Vek.";
                    }
                    else
                        signDesc += stockActionSignDetail.NameString ;
                    
                    switch (stockActionSignDetail.SignUserType)
                    {
                        case SignUserTypeEnum.BirlikXXXXXXi:
                            this.BIRLIKXXXXXXI.Value = signDesc;
                            break;
                        case SignUserTypeEnum.MalSaymani:
                            this.MALSAYMANI.Value = signDesc;
                            break;
                        case SignUserTypeEnum.HesapSorumlusu:
                            this.HESAPSORUMLUSU.Value = signDesc;
                            break;
                        case SignUserTypeEnum.MalSorumlusu:
                            this.MALSORUMLUSU.Value = signDesc;
                            break;
                        case SignUserTypeEnum.YetkiliMakam:
                            this.YETKILIMAKAM.Value = signDesc;
                            break;
                        default:
                            this.BIRLIKXXXXXXI.Value = signDesc;
                            break;
                    }
                }

                if (stockAction.StockActionInspection != null)
                {
                    if (stockAction.StockActionInspection.ReportNumberSeq != null)
                        this.MUAYENEDESC.Value = "Muayene Tarihi : " + stockAction.StockActionInspection.InspectionDate.Value.ToShortDateString() + "   Rapor Numarası : " + stockAction.StockActionInspection.ReportNumberSeq.Value;
                    foreach (StockActionInspectionDetail stockActionInspectionDetail in stockAction.StockActionInspection.StockActionInspectionDetails)
                    {
                        string signDesc = string.Empty;
                        string vekil = string.Empty;
                        signDesc = stockActionInspectionDetail.NameString + "\r\n" + stockActionInspectionDetail.ShortMilitaryClass + stockActionInspectionDetail.ShortRank +"\r\n(" + stockActionInspectionDetail.EmploymentRecordID +")";
                        //                        signDesc = stockActionInspectionDetail.InspectionUser.Name + "\r\n";
                        //                        if(stockActionInspectionDetail.InspectionUser.MilitaryClass != null)
                        //                            signDesc += stockActionInspectionDetail.InspectionUser.MilitaryClass.ShortName;
                        //                        if(stockActionInspectionDetail.InspectionUser.Rank != null)
                        //                            signDesc += stockActionInspectionDetail.InspectionUser.Rank.ShortName;
                        //                        signDesc += "\n\r(" + stockActionInspectionDetail.InspectionUser.EmploymentRecordID + ")\r\n";
                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(InspectionUserTypeEnum).Name];
                        signDesc += dataType.EnumValueDefs[(int)stockActionInspectionDetail.InspectionUserType.Value].DisplayText;
                        switch (stockActionInspectionDetail.InspectionUserType)
                        {
                            case InspectionUserTypeEnum.Baskan:
                                this.MUAYENEBASKAN.Value = signDesc;
                                break;
                            case InspectionUserTypeEnum.Uye:
                                if (string.IsNullOrEmpty(this.MUAYENEUYE1.Value))
                                    this.MUAYENEUYE1.Value = signDesc;
                                else if (string.IsNullOrEmpty(this.MUAYENEUYE2.Value))
                                    this.MUAYENEUYE2.Value = signDesc;
                                break;
                            case InspectionUserTypeEnum.TeknikUye:
                                if (string.IsNullOrEmpty(this.MUAYENEUYE2.Value))
                                    this.MUAYENEUYE2.Value = signDesc;
                                break;
                            default:
                                break;
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
            public DeleteRecordDocumentDestroyableReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1411 { get {return Header().NewField1411;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportField NewField1342 { get {return Header().NewField1342;} }
            public TTReportField NewField1343 { get {return Header().NewField1343;} }
            public TTReportField NewField1344 { get {return Header().NewField1344;} }
            public TTReportField NewField14431 { get {return Header().NewField14431;} }
            public TTReportField NewField14432 { get {return Header().NewField14432;} }
            public TTReportField NewField13431 { get {return Header().NewField13431;} }
            public TTReportField NewField13432 { get {return Header().NewField13432;} }
            public TTReportField BIRLIGINADI { get {return Header().BIRLIGINADI;} }
            public TTReportField SAYMANLIGINCINSI { get {return Header().SAYMANLIGINCINSI;} }
            public TTReportField BELGEKAYITNUMARASI { get {return Header().BELGEKAYITNUMARASI;} }
            public TTReportField YETKISEMBOLU { get {return Header().YETKISEMBOLU;} }
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
                public DeleteRecordDocumentDestroyableReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField113;
                public TTReportField NewField12;
                public TTReportField NewField114;
                public TTReportField NewField121;
                public TTReportField NewField1411;
                public TTReportField NewField1211;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportField NewField1341;
                public TTReportField NewField1342;
                public TTReportField NewField1343;
                public TTReportField NewField1344;
                public TTReportField NewField14431;
                public TTReportField NewField14432;
                public TTReportField NewField13431;
                public TTReportField NewField13432;
                public TTReportField BIRLIGINADI;
                public TTReportField SAYMANLIGINCINSI;
                public TTReportField BELGEKAYITNUMARASI;
                public TTReportField YETKISEMBOLU; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 46, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" Birliğin Adı";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 10, 46, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @" Taşınır Mal
 Saymanlığı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 20, 46, 30, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @" Yetki Sembolü
 veya Kod. Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 0, 122, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 10, 122, 20, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 20, 122, 30, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 199, 30, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Size = 12;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"

TAŞINIR MAL
KAYIT SİLME BELGESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 231, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" 
 Belge 
 Numarası";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 284, 15, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 15, 231, 30, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"
 Aktarılan
 Belge Numarası";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 15, 284, 30, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 30, 284, 40, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Taşınır Malın";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 40, 24, 55, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"
 S.
 Nu.
";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 40, 55, 55, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"
Stok Nu.";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 40, 129, 55, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"
Cinsi ve Özelliği";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 40, 144, 55, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField143.MultiLine = EvetHayirEnum.ehEvet;
                    NewField143.WordBreak = EvetHayirEnum.ehEvet;
                    NewField143.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"
Miktarı
";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 40, 159, 55, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1341.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1341.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"
Ölçü
Birimi
";

                    NewField1342 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 40, 174, 55, false);
                    NewField1342.Name = "NewField1342";
                    NewField1342.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1342.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1342.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1342.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1342.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1342.TextFont.CharSet = 162;
                    NewField1342.Value = @"
Birim
Fiyatı
";

                    NewField1343 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 40, 189, 55, false);
                    NewField1343.Name = "NewField1343";
                    NewField1343.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1343.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1343.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1343.TextFont.CharSet = 162;
                    NewField1343.Value = @"
 Tutarı
";

                    NewField1344 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 46, 204, 55, false);
                    NewField1344.Name = "NewField1344";
                    NewField1344.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1344.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1344.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1344.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1344.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1344.TextFont.CharSet = 162;
                    NewField1344.Value = @"Başlangıç
Tarihi";

                    NewField14431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 46, 219, 55, false);
                    NewField14431.Name = "NewField14431";
                    NewField14431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14431.TextFont.CharSet = 162;
                    NewField14431.Value = @"Süresi";

                    NewField14432 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 40, 219, 46, false);
                    NewField14432.Name = "NewField14432";
                    NewField14432.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14432.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14432.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14432.TextFont.CharSet = 162;
                    NewField14432.Value = @"Kullanma";

                    NewField13431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 40, 246, 55, false);
                    NewField13431.Name = "NewField13431";
                    NewField13431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13431.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13431.TextFont.CharSet = 162;
                    NewField13431.Value = @"
Kayıt Silme
Nedeni
";

                    NewField13432 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 40, 284, 55, false);
                    NewField13432.Name = "NewField13432";
                    NewField13432.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13432.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13432.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13432.TextFont.CharSet = 162;
                    NewField13432.Value = @"Açıklamalar";

                    BIRLIGINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 1, 121, 9, false);
                    BIRLIGINADI.Name = "BIRLIGINADI";
                    BIRLIGINADI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIGINADI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIGINADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIGINADI.Value = @"BIRLIGINADI";

                    SAYMANLIGINCINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 11, 120, 19, false);
                    SAYMANLIGINCINSI.Name = "SAYMANLIGINCINSI";
                    SAYMANLIGINCINSI.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMANLIGINCINSI.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMANLIGINCINSI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAYMANLIGINCINSI.Value = @"SAYMANLIGINCINSI";

                    BELGEKAYITNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 3, 273, 13, false);
                    BELGEKAYITNUMARASI.Name = "BELGEKAYITNUMARASI";
                    BELGEKAYITNUMARASI.MultiLine = EvetHayirEnum.ehEvet;
                    BELGEKAYITNUMARASI.WordBreak = EvetHayirEnum.ehEvet;
                    BELGEKAYITNUMARASI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BELGEKAYITNUMARASI.Value = @"BELGEKAYITNUMARASI";

                    YETKISEMBOLU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 21, 120, 29, false);
                    YETKISEMBOLU.Name = "YETKISEMBOLU";
                    YETKISEMBOLU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETKISEMBOLU.Value = @"YETKISEMBOLU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField1342.CalcValue = NewField1342.Value;
                    NewField1343.CalcValue = NewField1343.Value;
                    NewField1344.CalcValue = NewField1344.Value;
                    NewField14431.CalcValue = NewField14431.Value;
                    NewField14432.CalcValue = NewField14432.Value;
                    NewField13431.CalcValue = NewField13431.Value;
                    NewField13432.CalcValue = NewField13432.Value;
                    BIRLIGINADI.CalcValue = BIRLIGINADI.Value;
                    SAYMANLIGINCINSI.CalcValue = SAYMANLIGINCINSI.Value;
                    BELGEKAYITNUMARASI.CalcValue = BELGEKAYITNUMARASI.Value;
                    YETKISEMBOLU.CalcValue = YETKISEMBOLU.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField11,NewField111,NewField112,NewField113,NewField12,NewField114,NewField121,NewField1411,NewField1211,NewField14,NewField141,NewField142,NewField143,NewField1341,NewField1342,NewField1343,NewField1344,NewField14431,NewField14432,NewField13431,NewField13432,BIRLIGINADI,SAYMANLIGINCINSI,BELGEKAYITNUMARASI,YETKISEMBOLU};
                }
                public override void RunPreScript()
                {
#region PARTB HEADER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                        this.BIRLIGINADI.Value = stockAction.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code + " " + stockAction.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        this.SAYMANLIGINCINSI.Value = stockAction.AccountingTerm.Accountancy.AccountancyNO + " " + stockAction.AccountingTerm.Accountancy.Name;
                        this.BELGEKAYITNUMARASI.Value = stockAction.RegistrationNumber;

                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(AuthorityClassStatusEnum).Name];
                        this.YETKISEMBOLU.Value = dataType.EnumValueDefs[(int)((BaseDeleteRecordDocument)stockAction).AuthorityClass.Value].DisplayText;
                    }
#endregion PARTB HEADER_PreScript
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DeleteRecordDocumentDestroyableReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DeleteRecordDocumentDestroyableReport MyParentReport
            {
                get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField BASLANGICTARIHI { get {return Body().BASLANGICTARIHI;} }
            public TTReportField SURESI { get {return Body().SURESI;} }
            public TTReportField KAYITSILMENEDENI { get {return Body().KAYITSILMENEDENI;} }
            public TTReportField DIYECEKLER { get {return Body().DIYECEKLER;} }
            public TTReportField BIRIMFIYATI { get {return Body().BIRIMFIYATI;} }
            public TTReportField TUTARI { get {return Body().TUTARI;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine11112 { get {return Body().NewLine11112;} }
            public TTReportShape NewLine11113 { get {return Body().NewLine11113;} }
            public TTReportShape NewLine121111 { get {return Body().NewLine121111;} }
            public TTReportShape NewLine121112 { get {return Body().NewLine121112;} }
            public TTReportShape NewLine121113 { get {return Body().NewLine121113;} }
            public TTReportShape NewLine121114 { get {return Body().NewLine121114;} }
            public TTReportShape NewLine121115 { get {return Body().NewLine121115;} }
            public TTReportShape NewLine121116 { get {return Body().NewLine121116;} }
            public TTReportShape NewLine121117 { get {return Body().NewLine121117;} }
            public TTReportShape NewLine121118 { get {return Body().NewLine121118;} }
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
                public DeleteRecordDocumentDestroyableReport MyParentReport
                {
                    get { return (DeleteRecordDocumentDestroyableReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField MATERIALNAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField BASLANGICTARIHI;
                public TTReportField SURESI;
                public TTReportField KAYITSILMENEDENI;
                public TTReportField DIYECEKLER;
                public TTReportField BIRIMFIYATI;
                public TTReportField TUTARI;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine11112;
                public TTReportShape NewLine11113;
                public TTReportShape NewLine121111;
                public TTReportShape NewLine121112;
                public TTReportShape NewLine121113;
                public TTReportShape NewLine121114;
                public TTReportShape NewLine121115;
                public TTReportShape NewLine121116;
                public TTReportShape NewLine121117;
                public TTReportShape NewLine121118; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 24, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@} ";

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 1, 128, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 55, 6, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 143, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 159, 6, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    BASLANGICTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 1, 205, 6, false);
                    BASLANGICTARIHI.Name = "BASLANGICTARIHI";
                    BASLANGICTARIHI.TextFormat = @"Short Date";
                    BASLANGICTARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLANGICTARIHI.Value = @"";

                    SURESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 1, 218, 6, false);
                    SURESI.Name = "SURESI";
                    SURESI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SURESI.Value = @"";

                    KAYITSILMENEDENI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 1, 245, 6, false);
                    KAYITSILMENEDENI.Name = "KAYITSILMENEDENI";
                    KAYITSILMENEDENI.Value = @"";

                    DIYECEKLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 1, 283, 6, false);
                    DIYECEKLER.Name = "DIYECEKLER";
                    DIYECEKLER.Value = @"";

                    BIRIMFIYATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 1, 173, 6, false);
                    BIRIMFIYATI.Name = "BIRIMFIYATI";
                    BIRIMFIYATI.TextFormat = @"#,##0.00";
                    BIRIMFIYATI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYATI.Value = @"";

                    TUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 1, 188, 6, false);
                    TUTARI.Name = "TUTARI";
                    TUTARI.TextFormat = @"#,##0.00";
                    TUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTARI.Value = @"";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 6, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 0, 24, 6, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 55, 0, 55, 6, false);
                    NewLine11112.Name = "NewLine11112";
                    NewLine11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 284, 1, 284, 7, false);
                    NewLine11113.Name = "NewLine11113";
                    NewLine11113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 129, 0, 129, 6, false);
                    NewLine121111.Name = "NewLine121111";
                    NewLine121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 0, 144, 6, false);
                    NewLine121112.Name = "NewLine121112";
                    NewLine121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 0, 159, 6, false);
                    NewLine121113.Name = "NewLine121113";
                    NewLine121113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 174, 0, 174, 6, false);
                    NewLine121114.Name = "NewLine121114";
                    NewLine121114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121114.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 189, 0, 189, 6, false);
                    NewLine121115.Name = "NewLine121115";
                    NewLine121115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121115.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 205, 0, 205, 6, false);
                    NewLine121116.Name = "NewLine121116";
                    NewLine121116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121116.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 219, 0, 219, 6, false);
                    NewLine121117.Name = "NewLine121117";
                    NewLine121117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121117.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121118 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 246, 0, 246, 6, false);
                    NewLine121118.Name = "NewLine121118";
                    NewLine121118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121118.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    MATERIALNAME.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "");
                    NATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    BASLANGICTARIHI.CalcValue = BASLANGICTARIHI.Value;
                    SURESI.CalcValue = SURESI.Value;
                    KAYITSILMENEDENI.CalcValue = KAYITSILMENEDENI.Value;
                    DIYECEKLER.CalcValue = DIYECEKLER.Value;
                    BIRIMFIYATI.CalcValue = BIRIMFIYATI.Value;
                    TUTARI.CalcValue = TUTARI.Value;
                    return new TTReportObject[] { COUNTER,STOCKACTIONDETAILOBJECTID,MATERIALNAME,NATOSTOCKNO,AMOUNT,DISTRIBUTIONTYPE,BASLANGICTARIHI,SURESI,KAYITSILMENEDENI,DIYECEKLER,BIRIMFIYATI,TUTARI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (TTUtils.Globals.IsGuid(STOCKACTIONDETAILOBJECTID.CalcValue))
                    {
                        StockActionDetailOut stockActionDetailOut = MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTIONDETAILOBJECTID.CalcValue), typeof(StockActionDetailOut)) as StockActionDetailOut;
                        if (stockActionDetailOut != null)
                        {
                            if (stockActionDetailOut is DeleteRecordDocumentDestroyableMaterialOut)
                            {
                                DeleteRecordDocumentDestroyableMaterialOut deleteRecordDocumentDestroyableMaterialOut = (DeleteRecordDocumentDestroyableMaterialOut)stockActionDetailOut;
                                if (deleteRecordDocumentDestroyableMaterialOut.StartDate.HasValue)
                                {
                                    BASLANGICTARIHI.CalcValue = deleteRecordDocumentDestroyableMaterialOut.StartDate.Value.ToString();
                                    TimeSpan diffResult = TTObjectDefManager.ServerTime.Subtract(deleteRecordDocumentDestroyableMaterialOut.StartDate.Value);
                                    SURESI.CalcValue = diffResult.Days.ToString();
                                }
                                DIYECEKLER.CalcValue = deleteRecordDocumentDestroyableMaterialOut.Opinions;
                                if (deleteRecordDocumentDestroyableMaterialOut.DeleteRecordReason.HasValue)
                                {
                                    TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(DeleteRecordReasonEnum).Name];
                                    KAYITSILMENEDENI.CalcValue = dataType.EnumValueDefs[(int)deleteRecordDocumentDestroyableMaterialOut.DeleteRecordReason.Value].DisplayText;
                                }
                            }
                            if (stockActionDetailOut is DeleteRecordDocumentWasteMaterialOut)
                            {
                                DeleteRecordDocumentWasteMaterialOut deleteRecordDocumentWasteMaterialOut = (DeleteRecordDocumentWasteMaterialOut)stockActionDetailOut;
                                if (deleteRecordDocumentWasteMaterialOut.StartDate.HasValue)
                                {
                                    BASLANGICTARIHI.CalcValue = deleteRecordDocumentWasteMaterialOut.StartDate.Value.ToString();
                                    TimeSpan diffResult = TTObjectDefManager.ServerTime.Subtract(deleteRecordDocumentWasteMaterialOut.StartDate.Value);
                                    SURESI.CalcValue = diffResult.Days.ToString();
                                }
                                DIYECEKLER.CalcValue = deleteRecordDocumentWasteMaterialOut.Opinions;
                                if (deleteRecordDocumentWasteMaterialOut.DeleteRecordReason.HasValue)
                                {
                                    TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(DeleteRecordReasonEnum).Name];
                                    KAYITSILMENEDENI.CalcValue = dataType.EnumValueDefs[(int)deleteRecordDocumentWasteMaterialOut.DeleteRecordReason.Value].DisplayText;
                                }
                            }
                            BIRIMFIYATI.CalcValue = stockActionDetailOut.UnitPrice.ToString();
                            TUTARI.CalcValue = stockActionDetailOut.TotalPrice.ToString();

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

        public DeleteRecordDocumentDestroyableReport()
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
            Name = "DELETERECORDDOCUMENTDESTROYABLEREPORT";
            Caption = "Kayıt Silme Belgesi";
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