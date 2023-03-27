
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
    /// Hayvan Kayıt Silme Belgesi
    /// </summary>
    public partial class DeleteAnimalRecordDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DeleteAnimalRecordDocumentReport MyParentReport
            {
                get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField NewField142 { get {return Footer().NewField142;} }
            public TTReportField BIRLIKXXXXXXI { get {return Footer().BIRLIKXXXXXXI;} }
            public TTReportField YETKILIMAKAM { get {return Footer().YETKILIMAKAM;} }
            public TTReportField VETERINERHEKIM { get {return Footer().VETERINERHEKIM;} }
            public TTReportField MALSORUMLUSU { get {return Footer().MALSORUMLUSU;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField1241 { get {return Footer().NewField1241;} }
            public TTReportField MALSAYMANI1 { get {return Footer().MALSAYMANI1;} }
            public TTReportField SAGLIKKISIMAMIRI { get {return Footer().SAGLIKKISIMAMIRI;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
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
                public DeleteAnimalRecordDocumentReport MyParentReport
                {
                    get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
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
                public DeleteAnimalRecordDocumentReport MyParentReport
                {
                    get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
                }
                
                public TTReportField DESC;
                public TTReportField NewField142;
                public TTReportField BIRLIKXXXXXXI;
                public TTReportField YETKILIMAKAM;
                public TTReportField VETERINERHEKIM;
                public TTReportField MALSORUMLUSU;
                public TTReportField NewField1;
                public TTReportField NewField1241;
                public TTReportField MALSAYMANI1;
                public TTReportField SAGLIKKISIMAMIRI;
                public TTReportField NewField2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 108;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 43, 284, 64, false);
                    DESC.Name = "DESC";
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESC.TextFont.CharSet = 162;
                    DESC.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 13, 90, 41, false);
                    NewField142.Name = "NewField142";
                    NewField142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"
 İmza
 Adı Soyadı
 Rütbesi

 Görevi";

                    BIRLIKXXXXXXI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 13, 220, 41, false);
                    BIRLIKXXXXXXI.Name = "BIRLIKXXXXXXI";
                    BIRLIKXXXXXXI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.TextFont.Size = 8;
                    BIRLIKXXXXXXI.TextFont.CharSet = 162;
                    BIRLIKXXXXXXI.Value = @"BIRLIKXXXXXXI";

                    YETKILIMAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 66, 220, 94, false);
                    YETKILIMAKAM.Name = "YETKILIMAKAM";
                    YETKILIMAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    YETKILIMAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YETKILIMAKAM.TextFont.CharSet = 162;
                    YETKILIMAKAM.Value = @"YETKILIMAKAM";

                    VETERINERHEKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 13, 175, 41, false);
                    VETERINERHEKIM.Name = "VETERINERHEKIM";
                    VETERINERHEKIM.MultiLine = EvetHayirEnum.ehEvet;
                    VETERINERHEKIM.WordBreak = EvetHayirEnum.ehEvet;
                    VETERINERHEKIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    VETERINERHEKIM.TextFont.Size = 8;
                    VETERINERHEKIM.TextFont.CharSet = 162;
                    VETERINERHEKIM.Value = @"BİRLİK VETERİNER HEKİMİ";

                    MALSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 13, 133, 41, false);
                    MALSORUMLUSU.Name = "MALSORUMLUSU";
                    MALSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.TextFont.Size = 8;
                    MALSORUMLUSU.TextFont.CharSet = 162;
                    MALSORUMLUSU.Value = @"MALSORUMLUSU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 284, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.Value = @"      ........................... Kurum A.liği/Birlik K.lığı......... Mal Saymanlığı kayıtlarında bulunan ve yukarıda eşkâli yazılı (..rakamla..) ... yazıyla ... baş XXXXXX hayvanının/ hayvanlarının karşılarında gösterilen sebepten/sebeplerden ötürü kayıtlarının silinmesi arz ve teklif olunur .... /...... / 20...... ";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 66, 90, 94, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1241.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1241.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"
 İmza
 Adı Soyadı
 Rütbesi

 Görevi";

                    MALSAYMANI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 66, 133, 94, false);
                    MALSAYMANI1.Name = "MALSAYMANI1";
                    MALSAYMANI1.MultiLine = EvetHayirEnum.ehEvet;
                    MALSAYMANI1.WordBreak = EvetHayirEnum.ehEvet;
                    MALSAYMANI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALSAYMANI1.TextFont.Size = 8;
                    MALSAYMANI1.TextFont.CharSet = 162;
                    MALSAYMANI1.Value = @"MALSAYMANI";

                    SAGLIKKISIMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 66, 175, 94, false);
                    SAGLIKKISIMAMIRI.Name = "SAGLIKKISIMAMIRI";
                    SAGLIKKISIMAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    SAGLIKKISIMAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    SAGLIKKISIMAMIRI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAGLIKKISIMAMIRI.TextFont.Size = 8;
                    SAGLIKKISIMAMIRI.TextFont.CharSet = 162;
                    SAGLIKKISIMAMIRI.Value = @"SAĞLIK KISIM AMİRİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 101, 159, 106, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESC.CalcValue = DESC.Value;
                    NewField142.CalcValue = NewField142.Value;
                    BIRLIKXXXXXXI.CalcValue = BIRLIKXXXXXXI.Value;
                    YETKILIMAKAM.CalcValue = YETKILIMAKAM.Value;
                    VETERINERHEKIM.CalcValue = VETERINERHEKIM.Value;
                    MALSORUMLUSU.CalcValue = MALSORUMLUSU.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    MALSAYMANI1.CalcValue = MALSAYMANI1.Value;
                    SAGLIKKISIMAMIRI.CalcValue = SAGLIKKISIMAMIRI.Value;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { DESC,NewField142,BIRLIKXXXXXXI,YETKILIMAKAM,VETERINERHEKIM,MALSORUMLUSU,NewField1,NewField1241,MALSAYMANI1,SAGLIKKISIMAMIRI,NewField2};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                //this.EKLER.Value = stockAction.Description;
                //this.DESC1.Value = "Belgede yazılı (" + stockAction.StockActionOutDetails.Count + ") kalem Taşınır Mal  .......................................................................................... durumundadır.";
                //this.DESC2.Value = "Belgede yazılı (" + stockAction.StockActionOutDetails.Count + ") kalem Taşınır Malın kayıtlarının silinmesi uygundur.";
                foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                {
                    string signDesc = string.Empty;
                    string vekil = string.Empty;
                    signDesc = stockAction.TransactionDate.Value.ToShortDateString() + "\r\n\r\n";
                    signDesc += stockActionSignDetail.SignUser.Name + "\r\n";
                    if(stockActionSignDetail.SignUser.MilitaryClass != null)
                        signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                    if(stockActionSignDetail.SignUser.Rank != null)
                        signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                    signDesc += "\r\n(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")\r\n";
                    TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(SignUserTypeEnum).Name];
                    signDesc += dataType.EnumValueDefs[(int)stockActionSignDetail.SignUserType.Value].DisplayText;
                    if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
                        signDesc += " Vek.";
                    switch (stockActionSignDetail.SignUserType)
                    {
                        case SignUserTypeEnum.BirlikXXXXXXi:
                            this.BIRLIKXXXXXXI.Value = signDesc;
                            break;
                        case SignUserTypeEnum.MalSaymani:
                            //this.MALSAYMANI.Value = signDesc;
                            break;
                        case SignUserTypeEnum.HesapSorumlusu:
                            //this.HESAPSORUMLUSU.Value = signDesc;
                            break;
                        case SignUserTypeEnum.MalSorumlusu:
                            this.MALSORUMLUSU.Value = signDesc;
                            break;
                        case SignUserTypeEnum.YetkiliMakam:
                            this.YETKILIMAKAM.Value = signDesc;
                            break;
                        default:
                            break;
                    }
                }

                if (stockAction.StockActionInspection != null)
                {
                    if (stockAction.StockActionInspection.ReportNumberSeq != null)
                        //this.MUAYENEDESC.Value = "Muayene Tarihi : " + stockAction.StockActionInspection.InspectionDate.Value.ToShortDateString() + "   Rapor Numarası : " + stockAction.StockActionInspection.ReportNumberSeq.Value;
                    foreach (StockActionInspectionDetail stockActionInspectionDetail in stockAction.StockActionInspection.StockActionInspectionDetails)
                    {
                        string signDesc = string.Empty;
                        string vekil = string.Empty;
                        signDesc = stockActionInspectionDetail.InspectionUser.Name + "\r\n";
                        if(stockActionInspectionDetail.InspectionUser.MilitaryClass != null)
                            signDesc += stockActionInspectionDetail.InspectionUser.MilitaryClass.ShortName;
                        if(stockActionInspectionDetail.InspectionUser.Rank != null)
                            signDesc += stockActionInspectionDetail.InspectionUser.Rank.ShortName;
                        signDesc += "\n\r(" + stockActionInspectionDetail.InspectionUser.EmploymentRecordID + ")\r\n";
                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(InspectionUserTypeEnum).Name];
                        signDesc += dataType.EnumValueDefs[(int)stockActionInspectionDetail.InspectionUserType.Value].DisplayText;
                        //switch (stockActionInspectionDetail.InspectionUserType)
                        //{
                        //    case InspectionUserTypeEnum.Baskan:
                        //        this.MUAYENEBASKAN.Value = signDesc;
                        //        break;
                        //    case InspectionUserTypeEnum.Uye:
                        //        if (string.IsNullOrEmpty(this.MUAYENEUYE1.Value))
                        //            this.MUAYENEUYE1.Value = signDesc;
                        //        else if (string.IsNullOrEmpty(this.MUAYENEUYE2.Value))
                        //            this.MUAYENEUYE2.Value = signDesc;
                        //        break;
                        //    case InspectionUserTypeEnum.TeknikUye:
                        //        if (string.IsNullOrEmpty(this.MUAYENEUYE2.Value))
                        //            this.MUAYENEUYE2.Value = signDesc;
                        //        break;
                        //    default:
                        //        break;
                        //}
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
            public DeleteAnimalRecordDocumentReport MyParentReport
            {
                get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
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
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
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
            public TTReportField BELGEKAYITNUMARASI { get {return Header().BELGEKAYITNUMARASI;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
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
                public DeleteAnimalRecordDocumentReport MyParentReport
                {
                    get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField113;
                public TTReportField NewField12;
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
                public TTReportField BELGEKAYITNUMARASI;
                public TTReportField NewField2;
                public TTReportField NewField13; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 9, 66, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BİRLİK/KURUM ADI VE KONUŞ YERİ :";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 15, 284, 24, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Size = 12;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"HAYVAN KAYIT SİLME BELGESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 42, 9, false);
                    NewField12.Name = "NewField12";
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BELGE KAYIT NU. :";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 24, 284, 34, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Hayvanın";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 34, 20, 49, false);
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

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 34, 237, 49, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"
Stok Nu.";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 34, 60, 49, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"
Adı";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 34, 93, 49, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField143.MultiLine = EvetHayirEnum.ehEvet;
                    NewField143.WordBreak = EvetHayirEnum.ehEvet;
                    NewField143.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"
Türü
";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 34, 124, 49, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1341.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1341.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"
Irkı
";

                    NewField1342 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 34, 252, 49, false);
                    NewField1342.Name = "NewField1342";
                    NewField1342.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1342.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1342.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1342.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1342.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1342.TextFont.CharSet = 162;
                    NewField1342.Value = @"Birim
Maliyet Bedeli
";

                    NewField1343 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 34, 157, 49, false);
                    NewField1343.Name = "NewField1343";
                    NewField1343.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1343.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1343.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1343.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1343.TextFont.CharSet = 162;
                    NewField1343.Value = @"Taşınır
Mal 
Numarası
";

                    NewField1344 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 34, 172, 49, false);
                    NewField1344.Name = "NewField1344";
                    NewField1344.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1344.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1344.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1344.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1344.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1344.TextFont.CharSet = 162;
                    NewField1344.Value = @"
Doğum Tarihi";

                    NewField14431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 34, 188, 49, false);
                    NewField14431.Name = "NewField14431";
                    NewField14431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14431.TextFont.CharSet = 162;
                    NewField14431.Value = @"Hizmeti";

                    NewField14432 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 34, 137, 49, false);
                    NewField14432.Name = "NewField14432";
                    NewField14432.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14432.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14432.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14432.TextFont.CharSet = 162;
                    NewField14432.Value = @"Cinsiyeti";

                    NewField13431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 34, 212, 49, false);
                    NewField13431.Name = "NewField13431";
                    NewField13431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13431.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13431.TextFont.CharSet = 162;
                    NewField13431.Value = @"Eşkâli (Rengi, Donu ve İşaretleri
";

                    NewField13432 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 34, 284, 49, false);
                    NewField13432.Name = "NewField13432";
                    NewField13432.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13432.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13432.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13432.TextFont.CharSet = 162;
                    NewField13432.Value = @"Kayıt Silme Nedeni";

                    BIRLIGINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 9, 284, 14, false);
                    BIRLIGINADI.Name = "BIRLIGINADI";
                    BIRLIGINADI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIGINADI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIGINADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIGINADI.Value = @"BIRLIGINADI";

                    BELGEKAYITNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 4, 77, 9, false);
                    BELGEKAYITNUMARASI.Name = "BELGEKAYITNUMARASI";
                    BELGEKAYITNUMARASI.MultiLine = EvetHayirEnum.ehEvet;
                    BELGEKAYITNUMARASI.WordBreak = EvetHayirEnum.ehEvet;
                    BELGEKAYITNUMARASI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BELGEKAYITNUMARASI.Value = @"BELGEKAYITNUMARASI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 3, 284, 8, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"EK-I";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 1, 161, 6, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField12.CalcValue = NewField12.Value;
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
                    BELGEKAYITNUMARASI.CalcValue = BELGEKAYITNUMARASI.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField1,NewField113,NewField12,NewField1211,NewField14,NewField141,NewField142,NewField143,NewField1341,NewField1342,NewField1343,NewField1344,NewField14431,NewField14432,NewField13431,NewField13432,BIRLIGINADI,BELGEKAYITNUMARASI,NewField2,NewField13};
                }
                public override void RunPreScript()
                {
#region PARTB HEADER_PreScript
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                        this.BIRLIGINADI.Value = stockAction.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code + " " + stockAction.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        //this.SAYMANLIGINCINSI.Value = stockAction.AccountingTerm.Accountancy.AccountancyNO + " " + stockAction.AccountingTerm.Accountancy.Name;
                        this.BELGEKAYITNUMARASI.Value = stockAction.RegistrationNumber;

                        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(AuthorityClassStatusEnum).Name];
                        //this.YETKISEMBOLU.Value = dataType.EnumValueDefs[(int)((BaseDeleteRecordDocument)stockAction).AuthorityClass.Value].DisplayText;
                    }
#endregion PARTB HEADER_PreScript
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DeleteAnimalRecordDocumentReport MyParentReport
                {
                    get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
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
            public DeleteAnimalRecordDocumentReport MyParentReport
            {
                get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField DUTY { get {return Body().DUTY;} }
            public TTReportField VIEW { get {return Body().VIEW;} }
            public TTReportField SPECIE { get {return Body().SPECIE;} }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField KIND { get {return Body().KIND;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField DELETERECORDREASON { get {return Body().DELETERECORDREASON;} }
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
                public DeleteAnimalRecordDocumentReport MyParentReport
                {
                    get { return (DeleteAnimalRecordDocumentReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField MATERIALNAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField DUTY;
                public TTReportField VIEW;
                public TTReportField SPECIE;
                public TTReportField NO;
                public TTReportField BIRTHDATE;
                public TTReportField UNITPRICE;
                public TTReportField KIND;
                public TTReportField SEX;
                public TTReportField DELETERECORDREASON; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 20, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@} ";

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 60, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 237, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    DUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 188, 5, false);
                    DUTY.Name = "DUTY";
                    DUTY.DrawStyle = DrawStyleConstants.vbSolid;
                    DUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUTY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DUTY.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    DUTY.DataMember = "DUTY";
                    DUTY.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    VIEW = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 212, 5, false);
                    VIEW.Name = "VIEW";
                    VIEW.DrawStyle = DrawStyleConstants.vbSolid;
                    VIEW.FieldType = ReportFieldTypeEnum.ftVariable;
                    VIEW.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    VIEW.DataMember = "VIEW";
                    VIEW.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    SPECIE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 124, 5, false);
                    SPECIE.Name = "SPECIE";
                    SPECIE.DrawStyle = DrawStyleConstants.vbSolid;
                    SPECIE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPECIE.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    SPECIE.DataMember = "SPECIE";
                    SPECIE.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 157, 5, false);
                    NO.Name = "NO";
                    NO.DrawStyle = DrawStyleConstants.vbSolid;
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NO.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    NO.DataMember = "NO";
                    NO.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 172, 5, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"dd/MM/yyyy";
                    BIRTHDATE.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    BIRTHDATE.DataMember = "BIRTHDATE";
                    BIRTHDATE.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 252, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.Value = @"";

                    KIND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 93, 5, false);
                    KIND.Name = "KIND";
                    KIND.DrawStyle = DrawStyleConstants.vbSolid;
                    KIND.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIND.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KIND.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    KIND.DataMember = "KIND";
                    KIND.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 137, 5, false);
                    SEX.Name = "SEX";
                    SEX.DrawStyle = DrawStyleConstants.vbSolid;
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SEX.ObjectDefName = "DeleteRecordDocAnimalDetail";
                    SEX.DataMember = "SEX";
                    SEX.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                    DELETERECORDREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 0, 284, 5, false);
                    DELETERECORDREASON.Name = "DELETERECORDREASON";
                    DELETERECORDREASON.DrawStyle = DrawStyleConstants.vbSolid;
                    DELETERECORDREASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELETERECORDREASON.ObjectDefName = "BaseDeleteRecordDocumentDetail";
                    DELETERECORDREASON.DataMember = "DELETERECORDREASON";
                    DELETERECORDREASON.Value = @"{%STOCKACTIONDETAILOBJECTID%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    MATERIALNAME.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "");
                    NATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    DUTY.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    DUTY.PostFieldValueCalculation();
                    VIEW.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    VIEW.PostFieldValueCalculation();
                    SPECIE.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    SPECIE.PostFieldValueCalculation();
                    NO.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    NO.PostFieldValueCalculation();
                    BIRTHDATE.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    BIRTHDATE.PostFieldValueCalculation();
                    UNITPRICE.CalcValue = @"";
                    KIND.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    KIND.PostFieldValueCalculation();
                    SEX.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    SEX.PostFieldValueCalculation();
                    DELETERECORDREASON.CalcValue = MyParentReport.MAIN.STOCKACTIONDETAILOBJECTID.CalcValue;
                    DELETERECORDREASON.PostFieldValueCalculation();
                    return new TTReportObject[] { COUNTER,STOCKACTIONDETAILOBJECTID,MATERIALNAME,NATOSTOCKNO,DUTY,VIEW,SPECIE,NO,BIRTHDATE,UNITPRICE,KIND,SEX,DELETERECORDREASON};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (TTUtils.Globals.IsGuid(STOCKACTIONDETAILOBJECTID.CalcValue))
                    {
                        StockActionDetailOut stockActionDetailOut = MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTIONDETAILOBJECTID.CalcValue), typeof(StockActionDetailOut)) as StockActionDetailOut;
                        if (stockActionDetailOut != null)
                        {
                            DeleteRecordDocAnimalDetail deleteRecordDocAnimalDetail = (DeleteRecordDocAnimalDetail)stockActionDetailOut;
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

        public DeleteAnimalRecordDocumentReport()
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
            Name = "DELETEANIMALRECORDDOCUMENTREPORT";
            Caption = "Hayvan Kayıt Silme Belgesi";
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