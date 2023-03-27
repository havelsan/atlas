
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
    /// Taşınır Mal Stok Kaydı Hesap Teftiş Çizelgesi (EK-16)
    /// </summary>
    public partial class TasinirMalStokKaydiHesapTeftisCizelgesi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
            {
                get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField KODU { get {return Header().KODU;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField OldOrderNO111 { get {return Header().OldOrderNO111;} }
            public TTReportField OldOrderNO1111 { get {return Header().OldOrderNO1111;} }
            public TTReportField OldOrderNO1112 { get {return Header().OldOrderNO1112;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField SAYMAN { get {return Footer().SAYMAN;} }
            public TTReportField TKM { get {return Footer().TKM;} }
            public TTReportField TKB { get {return Footer().TKB;} }
            public TTReportField NewField112111 { get {return Footer().NewField112111;} }
            public TTReportField NewField11121111 { get {return Footer().NewField11121111;} }
            public TTReportField NewField1311112111 { get {return Footer().NewField1311112111;} }
            public TTReportField TEXT1654321 { get {return Footer().TEXT1654321;} }
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
                public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
                {
                    get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
                }
                
                public TTReportField SAYMANLIK;
                public TTReportField KODU;
                public TTReportField ReportName1;
                public TTReportField OldOrderNO111;
                public TTReportField OldOrderNO1111;
                public TTReportField OldOrderNO1112; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 15, 292, 21, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMANLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"";

                    KODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 22, 292, 28, false);
                    KODU.Name = "KODU";
                    KODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KODU.TextFont.CharSet = 162;
                    KODU.Value = @"";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 292, 13, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Size = 12;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"TAŞINIR MAL STOK KAYDI HESAP TEFTİŞ ÇİZELGESİ";

                    OldOrderNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 15, 24, 21, false);
                    OldOrderNO111.Name = "OldOrderNO111";
                    OldOrderNO111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO111.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO111.TextFont.Name = "Arial";
                    OldOrderNO111.TextFont.Bold = true;
                    OldOrderNO111.TextFont.CharSet = 162;
                    OldOrderNO111.Value = @"Saymanlık :";

                    OldOrderNO1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 22, 24, 28, false);
                    OldOrderNO1111.Name = "OldOrderNO1111";
                    OldOrderNO1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO1111.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO1111.TextFont.Name = "Arial";
                    OldOrderNO1111.TextFont.Bold = true;
                    OldOrderNO1111.TextFont.CharSet = 162;
                    OldOrderNO1111.Value = @"Bütçe Yılı   :";

                    OldOrderNO1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 2, 289, 8, false);
                    OldOrderNO1112.Name = "OldOrderNO1112";
                    OldOrderNO1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1112.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO1112.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO1112.TextFont.Name = "Arial";
                    OldOrderNO1112.TextFont.Bold = true;
                    OldOrderNO1112.TextFont.CharSet = 162;
                    OldOrderNO1112.Value = @"EK-16";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SAYMANLIK.CalcValue = @"";
                    KODU.CalcValue = @"";
                    ReportName1.CalcValue = ReportName1.Value;
                    OldOrderNO111.CalcValue = OldOrderNO111.Value;
                    OldOrderNO1111.CalcValue = OldOrderNO1111.Value;
                    OldOrderNO1112.CalcValue = OldOrderNO1112.Value;
                    return new TTReportObject[] { SAYMANLIK,KODU,ReportName1,OldOrderNO111,OldOrderNO1111,OldOrderNO1112};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string termID = ((TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(accountingTerm.EndDate != null)
            {
                int actionYear = Convert.ToDateTime(accountingTerm.EndDate).Year;
                this.KODU.CalcValue = actionYear.ToString() ;
                this.SAYMANLIK.CalcValue = accountingTerm.Accountancy.Name+" "+accountingTerm.Accountancy.AccountancyCode+" "+accountingTerm.Accountancy.AccountancyNO;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
                {
                    get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField121;
                public TTReportField NewField14;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField SAYMAN;
                public TTReportField TKM;
                public TTReportField TKB;
                public TTReportField NewField112111;
                public TTReportField NewField11121111;
                public TTReportField NewField1311112111;
                public TTReportField TEXT1654321; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 55;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 5, 293, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Yukarıda miktarı yazılı ............. Adet Taşınır Mal Stok Kayıtlarından .............. Adedi girdi ve çıktı işlemi görmemiştir.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 10, 31, 15, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"GE.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 10, 101, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @": Başka masadan gene Stok kayıt miktarı.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 15, 31, 20, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Gİ.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 101, 20, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @": Başka masaya giden (verilen) Stok kayıt miktarı.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 10, 151, 15, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"MD.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 15, 151, 20, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"SD.";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 10, 180, 15, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @": Mal Devirli";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 15, 180, 20, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @": Sıfır Devirli";

                    SAYMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 84, 41, false);
                    SAYMAN.Name = "SAYMAN";
                    SAYMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMAN.TextFont.Size = 9;
                    SAYMAN.TextFont.CharSet = 162;
                    SAYMAN.Value = @"";

                    TKM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 28, 189, 42, false);
                    TKM.Name = "TKM";
                    TKM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKM.MultiLine = EvetHayirEnum.ehEvet;
                    TKM.WordBreak = EvetHayirEnum.ehEvet;
                    TKM.TextFont.Size = 9;
                    TKM.TextFont.CharSet = 162;
                    TKM.Value = @"";

                    TKB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 28, 134, 42, false);
                    TKB.Name = "TKB";
                    TKB.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKB.MultiLine = EvetHayirEnum.ehEvet;
                    TKB.WordBreak = EvetHayirEnum.ehEvet;
                    TKB.TextFont.Size = 9;
                    TKB.TextFont.CharSet = 162;
                    TKB.Value = @"";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 43, 84, 53, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Size = 9;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"Sayman";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 43, 189, 53, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121111.TextFont.Size = 9;
                    NewField11121111.TextFont.CharSet = 162;
                    NewField11121111.Value = @"Teftiş Kurulu Müfettişi";

                    NewField1311112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 44, 134, 54, false);
                    NewField1311112111.Name = "NewField1311112111";
                    NewField1311112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112111.TextFont.Size = 9;
                    NewField1311112111.TextFont.CharSet = 162;
                    NewField1311112111.Value = @"Teftiş Kurulu Başkanı";

                    TEXT1654321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 24, 36, 43, false);
                    TEXT1654321.Name = "TEXT1654321";
                    TEXT1654321.Visible = EvetHayirEnum.ehHayir;
                    TEXT1654321.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT1654321.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT1654321.TextFont.Size = 9;
                    TEXT1654321.TextFont.CharSet = 162;
                    TEXT1654321.Value = @"İmza ve Mühür
Adı ve Soyadı
Sınıfı ve Rütbesi
Görevi		
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    SAYMAN.CalcValue = @"";
                    TKM.CalcValue = @"";
                    TKB.CalcValue = @"";
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField1311112111.CalcValue = NewField1311112111.Value;
                    TEXT1654321.CalcValue = TEXT1654321.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField13,NewField121,NewField14,NewField131,NewField141,NewField1141,SAYMAN,TKM,TKB,NewField112111,NewField11121111,NewField1311112111,TEXT1654321};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string termID = ((TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            
            IList checkStockCensusActions = ctx.QueryObjects("CHECKSTOCKCENSUSACTION","ACCOUNTINGTERM=" + ConnectionManager.GuidToString(term.ObjectID));
            if(checkStockCensusActions.Count > 0)
            {
                CheckStockCensusAction checkStockCensusAction = (CheckStockCensusAction)checkStockCensusActions[0];
                
                SAYMAN.CalcValue =  checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.MalSaymani);
                TKB.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.TeftisKuruluBaskani);
                TKM.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.TeftisKuruluMufettisi);
            }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
            {
                get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField OldOrderNO1111 { get {return Header().OldOrderNO1111;} }
            public TTReportField OldOrderNO11111 { get {return Header().OldOrderNO11111;} }
            public TTReportField OldOrderNO111111 { get {return Header().OldOrderNO111111;} }
            public TTReportField OldOrderNO111112 { get {return Header().OldOrderNO111112;} }
            public TTReportField OldOrderNO1211111 { get {return Header().OldOrderNO1211111;} }
            public TTReportField OldOrderNO1211112 { get {return Header().OldOrderNO1211112;} }
            public TTReportField OldOrderNO1211113 { get {return Header().OldOrderNO1211113;} }
            public TTReportField OldOrderNO1211114 { get {return Header().OldOrderNO1211114;} }
            public TTReportField OldOrderNO1111111 { get {return Header().OldOrderNO1111111;} }
            public TTReportField OldOrderNO1211115 { get {return Header().OldOrderNO1211115;} }
            public TTReportField OldOrderNO11111121 { get {return Header().OldOrderNO11111121;} }
            public TTReportField OldOrderNO14111121 { get {return Header().OldOrderNO14111121;} }
            public TTReportField OldOrderNO11111111 { get {return Header().OldOrderNO11111111;} }
            public TTReportField OldOrderNO111111111 { get {return Header().OldOrderNO111111111;} }
            public TTReportField OldOrderNO112111141 { get {return Header().OldOrderNO112111141;} }
            public TTReportField OldOrderNO112111142 { get {return Header().OldOrderNO112111142;} }
            public TTReportField OldOrderNO112111143 { get {return Header().OldOrderNO112111143;} }
            public TTReportField OldOrderNO1111111111 { get {return Header().OldOrderNO1111111111;} }
            public TTReportField OldOrderNO11111111111 { get {return Header().OldOrderNO11111111111;} }
            public TTReportField OldOrderNO111113 { get {return Header().OldOrderNO111113;} }
            public TTReportField OldOrderNO11112 { get {return Footer().OldOrderNO11112;} }
            public TTReportField OldOrderNO121111 { get {return Footer().OldOrderNO121111;} }
            public TTReportField TMD { get {return Footer().TMD;} }
            public TTReportField TSD { get {return Footer().TSD;} }
            public TTReportField TGELEN { get {return Footer().TGELEN;} }
            public TTReportField TGIDEN { get {return Footer().TGIDEN;} }
            public TTReportField TTOPLAM { get {return Footer().TTOPLAM;} }
            public TTReportField TYMD { get {return Footer().TYMD;} }
            public TTReportField TYSD { get {return Footer().TYSD;} }
            public TTReportField TYTOPLAM1 { get {return Footer().TYTOPLAM1;} }
            public TTReportField TGTOPLAM { get {return Footer().TGTOPLAM;} }
            public TTReportField TCTOPLAM1 { get {return Footer().TCTOPLAM1;} }
            public TTReportField TDTOPLAM { get {return Footer().TDTOPLAM;} }
            public TTReportField TDMD { get {return Footer().TDMD;} }
            public TTReportField TDSD { get {return Footer().TDSD;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField TTOPLAM1 { get {return Footer().TTOPLAM1;} }
            public TTReportField TGTOPLAM1 { get {return Footer().TGTOPLAM1;} }
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
                public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
                {
                    get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
                }
                
                public TTReportField OldOrderNO1111;
                public TTReportField OldOrderNO11111;
                public TTReportField OldOrderNO111111;
                public TTReportField OldOrderNO111112;
                public TTReportField OldOrderNO1211111;
                public TTReportField OldOrderNO1211112;
                public TTReportField OldOrderNO1211113;
                public TTReportField OldOrderNO1211114;
                public TTReportField OldOrderNO1111111;
                public TTReportField OldOrderNO1211115;
                public TTReportField OldOrderNO11111121;
                public TTReportField OldOrderNO14111121;
                public TTReportField OldOrderNO11111111;
                public TTReportField OldOrderNO111111111;
                public TTReportField OldOrderNO112111141;
                public TTReportField OldOrderNO112111142;
                public TTReportField OldOrderNO112111143;
                public TTReportField OldOrderNO1111111111;
                public TTReportField OldOrderNO11111111111;
                public TTReportField OldOrderNO111113; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OldOrderNO1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 27, 47, false);
                    OldOrderNO1111.Name = "OldOrderNO1111";
                    OldOrderNO1111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO1111.TextFont.Name = "Arial";
                    OldOrderNO1111.TextFont.Size = 9;
                    OldOrderNO1111.TextFont.Bold = true;
                    OldOrderNO1111.TextFont.CharSet = 162;
                    OldOrderNO1111.Value = @"




MALZEMENİN
CİNSİ






 





 





 





 

 



$



%





 





 




123

 

 






Arial

 

 








 

 





 





 





 







 

 

 







 

 






 

 





 




 

 






 

 






 

 





 

 






More

 







































 

| 


MALZEMENİN CİNSİ
 
";

                    OldOrderNO11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 19, 55, 47, false);
                    OldOrderNO11111.Name = "OldOrderNO11111";
                    OldOrderNO11111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO11111.TextFont.Name = "Arial";
                    OldOrderNO11111.TextFont.Size = 9;
                    OldOrderNO11111.TextFont.Bold = true;
                    OldOrderNO11111.TextFont.CharSet = 162;
                    OldOrderNO11111.Value = @"
SAYFA
ADEDİ";

                    OldOrderNO111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 127, 19, false);
                    OldOrderNO111111.Name = "OldOrderNO111111";
                    OldOrderNO111111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO111111.TextFont.Name = "Arial";
                    OldOrderNO111111.TextFont.Size = 9;
                    OldOrderNO111111.TextFont.Bold = true;
                    OldOrderNO111111.TextFont.CharSet = 162;
                    OldOrderNO111111.Value = @"ESKİ KAYITLAR";

                    OldOrderNO111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 19, 69, 47, false);
                    OldOrderNO111112.Name = "OldOrderNO111112";
                    OldOrderNO111112.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO111112.TextFont.Name = "Arial";
                    OldOrderNO111112.TextFont.Size = 9;
                    OldOrderNO111112.TextFont.Bold = true;
                    OldOrderNO111112.TextFont.CharSet = 162;
                    OldOrderNO111112.Value = @"M. D.";

                    OldOrderNO1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 19, 83, 47, false);
                    OldOrderNO1211111.Name = "OldOrderNO1211111";
                    OldOrderNO1211111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1211111.TextFont.Name = "Arial";
                    OldOrderNO1211111.TextFont.Size = 9;
                    OldOrderNO1211111.TextFont.Bold = true;
                    OldOrderNO1211111.TextFont.CharSet = 162;
                    OldOrderNO1211111.Value = @"S. D.";

                    OldOrderNO1211112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 19, 97, 47, false);
                    OldOrderNO1211112.Name = "OldOrderNO1211112";
                    OldOrderNO1211112.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1211112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1211112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1211112.TextFont.Name = "Arial";
                    OldOrderNO1211112.TextFont.Size = 9;
                    OldOrderNO1211112.TextFont.Bold = true;
                    OldOrderNO1211112.TextFont.CharSet = 162;
                    OldOrderNO1211112.Value = @"GE.";

                    OldOrderNO1211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 19, 111, 47, false);
                    OldOrderNO1211113.Name = "OldOrderNO1211113";
                    OldOrderNO1211113.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1211113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1211113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1211113.TextFont.Name = "Arial";
                    OldOrderNO1211113.TextFont.Size = 9;
                    OldOrderNO1211113.TextFont.Bold = true;
                    OldOrderNO1211113.TextFont.CharSet = 162;
                    OldOrderNO1211113.Value = @"Gİ.";

                    OldOrderNO1211114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 19, 127, 47, false);
                    OldOrderNO1211114.Name = "OldOrderNO1211114";
                    OldOrderNO1211114.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1211114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1211114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1211114.TextFont.Name = "Arial";
                    OldOrderNO1211114.TextFont.Size = 9;
                    OldOrderNO1211114.TextFont.Bold = true;
                    OldOrderNO1211114.TextFont.CharSet = 162;
                    OldOrderNO1211114.Value = @"TOPLAM";

                    OldOrderNO1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 171, 19, false);
                    OldOrderNO1111111.Name = "OldOrderNO1111111";
                    OldOrderNO1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1111111.TextFont.Name = "Arial";
                    OldOrderNO1111111.TextFont.Size = 9;
                    OldOrderNO1111111.TextFont.Bold = true;
                    OldOrderNO1111111.TextFont.CharSet = 162;
                    OldOrderNO1111111.Value = @"YENİ KAYITLAR";

                    OldOrderNO1211115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 19, 141, 47, false);
                    OldOrderNO1211115.Name = "OldOrderNO1211115";
                    OldOrderNO1211115.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1211115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1211115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1211115.TextFont.Name = "Arial";
                    OldOrderNO1211115.TextFont.Size = 9;
                    OldOrderNO1211115.TextFont.Bold = true;
                    OldOrderNO1211115.TextFont.CharSet = 162;
                    OldOrderNO1211115.Value = @"M. D.";

                    OldOrderNO11111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 19, 155, 47, false);
                    OldOrderNO11111121.Name = "OldOrderNO11111121";
                    OldOrderNO11111121.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO11111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11111121.TextFont.Name = "Arial";
                    OldOrderNO11111121.TextFont.Size = 9;
                    OldOrderNO11111121.TextFont.Bold = true;
                    OldOrderNO11111121.TextFont.CharSet = 162;
                    OldOrderNO11111121.Value = @"S. D.";

                    OldOrderNO14111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 19, 171, 47, false);
                    OldOrderNO14111121.Name = "OldOrderNO14111121";
                    OldOrderNO14111121.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO14111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO14111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO14111121.TextFont.Name = "Arial";
                    OldOrderNO14111121.TextFont.Size = 9;
                    OldOrderNO14111121.TextFont.Bold = true;
                    OldOrderNO14111121.TextFont.CharSet = 162;
                    OldOrderNO14111121.Value = @"TOPLAM";

                    OldOrderNO11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 1, 189, 47, false);
                    OldOrderNO11111111.Name = "OldOrderNO11111111";
                    OldOrderNO11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11111111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO11111111.TextFont.Name = "Arial";
                    OldOrderNO11111111.TextFont.Size = 9;
                    OldOrderNO11111111.TextFont.Bold = true;
                    OldOrderNO11111111.TextFont.CharSet = 162;
                    OldOrderNO11111111.Value = @"

GENEL
TOPLAM
";

                    OldOrderNO111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 1, 228, 47, false);
                    OldOrderNO111111111.Name = "OldOrderNO111111111";
                    OldOrderNO111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO111111111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO111111111.TextFont.Name = "Arial";
                    OldOrderNO111111111.TextFont.Size = 9;
                    OldOrderNO111111111.TextFont.Bold = true;
                    OldOrderNO111111111.TextFont.CharSet = 162;
                    OldOrderNO111111111.Value = @"
SAYMANLIKTAN ALINIP
 KONTROL EDİLEN
 KARTLAR (MANUEL
 OLARAK İŞLEM
 YAPAN SAYMANLIK
 VARSA) / ASK'DAN
 ATILAN ÇİFT SIFIRLI
 KAYIT
MİKTARI";

                    OldOrderNO112111141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 19, 266, 47, false);
                    OldOrderNO112111141.Name = "OldOrderNO112111141";
                    OldOrderNO112111141.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO112111141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO112111141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO112111141.TextFont.Name = "Arial";
                    OldOrderNO112111141.TextFont.Size = 9;
                    OldOrderNO112111141.TextFont.Bold = true;
                    OldOrderNO112111141.TextFont.CharSet = 162;
                    OldOrderNO112111141.Value = @"TOPLAM";

                    OldOrderNO112111142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 19, 239, 47, false);
                    OldOrderNO112111142.Name = "OldOrderNO112111142";
                    OldOrderNO112111142.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO112111142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO112111142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO112111142.TextFont.Name = "Arial";
                    OldOrderNO112111142.TextFont.Size = 9;
                    OldOrderNO112111142.TextFont.Bold = true;
                    OldOrderNO112111142.TextFont.CharSet = 162;
                    OldOrderNO112111142.Value = @"M.D.";

                    OldOrderNO112111143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 19, 250, 47, false);
                    OldOrderNO112111143.Name = "OldOrderNO112111143";
                    OldOrderNO112111143.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO112111143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO112111143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO112111143.TextFont.Name = "Arial";
                    OldOrderNO112111143.TextFont.Size = 9;
                    OldOrderNO112111143.TextFont.Bold = true;
                    OldOrderNO112111143.TextFont.CharSet = 162;
                    OldOrderNO112111143.Value = @"S.D.";

                    OldOrderNO1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 1, 266, 19, false);
                    OldOrderNO1111111111.Name = "OldOrderNO1111111111";
                    OldOrderNO1111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1111111111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO1111111111.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO1111111111.TextFont.Name = "Arial";
                    OldOrderNO1111111111.TextFont.Size = 9;
                    OldOrderNO1111111111.TextFont.Bold = true;
                    OldOrderNO1111111111.TextFont.CharSet = 162;
                    OldOrderNO1111111111.Value = @"ÖNÜMÜZDEKİ YILA DEVREDEN KAYITLAR (YÖNETİM HESAP CETVELİNE GÖRE)";

                    OldOrderNO11111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 1, 292, 47, false);
                    OldOrderNO11111111111.Name = "OldOrderNO11111111111";
                    OldOrderNO11111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO11111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11111111111.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO11111111111.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO11111111111.TextFont.Name = "Arial";
                    OldOrderNO11111111111.TextFont.Size = 9;
                    OldOrderNO11111111111.TextFont.Bold = true;
                    OldOrderNO11111111111.TextFont.CharSet = 162;
                    OldOrderNO11111111111.Value = @"


HESAP SORUMLUSUNUN ADI, SOYADI VE İMZASI";

                    OldOrderNO111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 55, 19, false);
                    OldOrderNO111113.Name = "OldOrderNO111113";
                    OldOrderNO111113.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO111113.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO111113.TextFont.Name = "Arial";
                    OldOrderNO111113.TextFont.Size = 9;
                    OldOrderNO111113.TextFont.Bold = true;
                    OldOrderNO111113.TextFont.CharSet = 162;
                    OldOrderNO111113.Value = @"
TAŞINIR MAL
YÖNETİM HESAP
CETVELİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OldOrderNO1111.CalcValue = OldOrderNO1111.Value;
                    OldOrderNO11111.CalcValue = OldOrderNO11111.Value;
                    OldOrderNO111111.CalcValue = OldOrderNO111111.Value;
                    OldOrderNO111112.CalcValue = OldOrderNO111112.Value;
                    OldOrderNO1211111.CalcValue = OldOrderNO1211111.Value;
                    OldOrderNO1211112.CalcValue = OldOrderNO1211112.Value;
                    OldOrderNO1211113.CalcValue = OldOrderNO1211113.Value;
                    OldOrderNO1211114.CalcValue = OldOrderNO1211114.Value;
                    OldOrderNO1111111.CalcValue = OldOrderNO1111111.Value;
                    OldOrderNO1211115.CalcValue = OldOrderNO1211115.Value;
                    OldOrderNO11111121.CalcValue = OldOrderNO11111121.Value;
                    OldOrderNO14111121.CalcValue = OldOrderNO14111121.Value;
                    OldOrderNO11111111.CalcValue = OldOrderNO11111111.Value;
                    OldOrderNO111111111.CalcValue = OldOrderNO111111111.Value;
                    OldOrderNO112111141.CalcValue = OldOrderNO112111141.Value;
                    OldOrderNO112111142.CalcValue = OldOrderNO112111142.Value;
                    OldOrderNO112111143.CalcValue = OldOrderNO112111143.Value;
                    OldOrderNO1111111111.CalcValue = OldOrderNO1111111111.Value;
                    OldOrderNO11111111111.CalcValue = OldOrderNO11111111111.Value;
                    OldOrderNO111113.CalcValue = OldOrderNO111113.Value;
                    return new TTReportObject[] { OldOrderNO1111,OldOrderNO11111,OldOrderNO111111,OldOrderNO111112,OldOrderNO1211111,OldOrderNO1211112,OldOrderNO1211113,OldOrderNO1211114,OldOrderNO1111111,OldOrderNO1211115,OldOrderNO11111121,OldOrderNO14111121,OldOrderNO11111111,OldOrderNO111111111,OldOrderNO112111141,OldOrderNO112111142,OldOrderNO112111143,OldOrderNO1111111111,OldOrderNO11111111111,OldOrderNO111113};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
                {
                    get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
                }
                
                public TTReportField OldOrderNO11112;
                public TTReportField OldOrderNO121111;
                public TTReportField TMD;
                public TTReportField TSD;
                public TTReportField TGELEN;
                public TTReportField TGIDEN;
                public TTReportField TTOPLAM;
                public TTReportField TYMD;
                public TTReportField TYSD;
                public TTReportField TYTOPLAM1;
                public TTReportField TGTOPLAM;
                public TTReportField TCTOPLAM1;
                public TTReportField TDTOPLAM;
                public TTReportField TDMD;
                public TTReportField TDSD;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField TTOPLAM1;
                public TTReportField TGTOPLAM1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    OldOrderNO11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 27, 7, false);
                    OldOrderNO11112.Name = "OldOrderNO11112";
                    OldOrderNO11112.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO11112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11112.TextFont.Name = "Arial";
                    OldOrderNO11112.TextFont.Bold = true;
                    OldOrderNO11112.TextFont.CharSet = 162;
                    OldOrderNO11112.Value = @"TOPLAM";

                    OldOrderNO121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 55, 7, false);
                    OldOrderNO121111.Name = "OldOrderNO121111";
                    OldOrderNO121111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO121111.TextFont.Name = "Arial";
                    OldOrderNO121111.TextFont.Bold = true;
                    OldOrderNO121111.TextFont.CharSet = 162;
                    OldOrderNO121111.Value = @"";

                    TMD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 69, 7, false);
                    TMD.Name = "TMD";
                    TMD.DrawStyle = DrawStyleConstants.vbSolid;
                    TMD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TMD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TMD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TMD.TextFont.Name = "Arial";
                    TMD.TextFont.Bold = true;
                    TMD.TextFont.CharSet = 162;
                    TMD.Value = @"{@sumof(OLDMATERIALCENSUS)@}";

                    TSD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 83, 7, false);
                    TSD.Name = "TSD";
                    TSD.DrawStyle = DrawStyleConstants.vbSolid;
                    TSD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TSD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TSD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TSD.TextFont.Name = "Arial";
                    TSD.TextFont.Bold = true;
                    TSD.TextFont.CharSet = 162;
                    TSD.Value = @"{@sumof(OLDZEROCENSUS)@}";

                    TGELEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 97, 7, false);
                    TGELEN.Name = "TGELEN";
                    TGELEN.DrawStyle = DrawStyleConstants.vbSolid;
                    TGELEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TGELEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TGELEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TGELEN.TextFont.Name = "Arial";
                    TGELEN.TextFont.Bold = true;
                    TGELEN.TextFont.CharSet = 162;
                    TGELEN.Value = @"{@sumof(GELEN1)@}";

                    TGIDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 111, 7, false);
                    TGIDEN.Name = "TGIDEN";
                    TGIDEN.DrawStyle = DrawStyleConstants.vbSolid;
                    TGIDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TGIDEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TGIDEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TGIDEN.TextFont.Name = "Arial";
                    TGIDEN.TextFont.Bold = true;
                    TGIDEN.TextFont.CharSet = 162;
                    TGIDEN.Value = @"{@sumof(GIDEN1)@}";

                    TTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 127, 7, false);
                    TTOPLAM.Name = "TTOPLAM";
                    TTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOPLAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TTOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TTOPLAM.TextFont.Name = "Arial";
                    TTOPLAM.TextFont.Bold = true;
                    TTOPLAM.TextFont.CharSet = 162;
                    TTOPLAM.Value = @"{@sumof(NORMALCARDAMOUNT)@}";

                    TYMD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 141, 7, false);
                    TYMD.Name = "TYMD";
                    TYMD.DrawStyle = DrawStyleConstants.vbSolid;
                    TYMD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYMD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TYMD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TYMD.TextFont.Name = "Arial";
                    TYMD.TextFont.Bold = true;
                    TYMD.TextFont.CharSet = 162;
                    TYMD.Value = @"{@sumof(NEWMATERIALCENSUS)@}";

                    TYSD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 0, 155, 7, false);
                    TYSD.Name = "TYSD";
                    TYSD.DrawStyle = DrawStyleConstants.vbSolid;
                    TYSD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYSD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TYSD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TYSD.TextFont.Name = "Arial";
                    TYSD.TextFont.Bold = true;
                    TYSD.TextFont.CharSet = 162;
                    TYSD.Value = @"{@sumof(NEWZEROCENSUS)@}";

                    TYTOPLAM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 171, 7, false);
                    TYTOPLAM1.Name = "TYTOPLAM1";
                    TYTOPLAM1.DrawStyle = DrawStyleConstants.vbSolid;
                    TYTOPLAM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYTOPLAM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TYTOPLAM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TYTOPLAM1.TextFont.Name = "Arial";
                    TYTOPLAM1.TextFont.Bold = true;
                    TYTOPLAM1.TextFont.CharSet = 162;
                    TYTOPLAM1.Value = @"{@sumof(NEWCARDAMOUNT)@}";

                    TGTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 189, 7, false);
                    TGTOPLAM.Name = "TGTOPLAM";
                    TGTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TGTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TGTOPLAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TGTOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TGTOPLAM.TextFont.Name = "Arial";
                    TGTOPLAM.TextFont.Bold = true;
                    TGTOPLAM.TextFont.CharSet = 162;
                    TGTOPLAM.Value = @"{@sumof(TOTALCARDAMOUNT)@}";

                    TCTOPLAM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 228, 7, false);
                    TCTOPLAM1.Name = "TCTOPLAM1";
                    TCTOPLAM1.DrawStyle = DrawStyleConstants.vbSolid;
                    TCTOPLAM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCTOPLAM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCTOPLAM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCTOPLAM1.TextFont.Name = "Arial";
                    TCTOPLAM1.TextFont.Bold = true;
                    TCTOPLAM1.TextFont.CharSet = 162;
                    TCTOPLAM1.Value = @"{@sumof(CIFTSIFIR1)@}";

                    TDTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 266, 7, false);
                    TDTOPLAM.Name = "TDTOPLAM";
                    TDTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TDTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TDTOPLAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TDTOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TDTOPLAM.TextFont.Name = "Arial";
                    TDTOPLAM.TextFont.Bold = true;
                    TDTOPLAM.TextFont.CharSet = 162;
                    TDTOPLAM.Value = @"{@sumof(TOPLAM1)@}";

                    TDMD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 239, 7, false);
                    TDMD.Name = "TDMD";
                    TDMD.DrawStyle = DrawStyleConstants.vbSolid;
                    TDMD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TDMD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TDMD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TDMD.TextFont.Name = "Arial";
                    TDMD.TextFont.Bold = true;
                    TDMD.TextFont.CharSet = 162;
                    TDMD.Value = @"{@sumof(MATERIALCENSUS)@}";

                    TDSD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 250, 7, false);
                    TDSD.Name = "TDSD";
                    TDSD.DrawStyle = DrawStyleConstants.vbSolid;
                    TDSD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TDSD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TDSD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TDSD.TextFont.Name = "Arial";
                    TDSD.TextFont.Bold = true;
                    TDSD.TextFont.CharSet = 162;
                    TDSD.Value = @"{@sumof(ZEROCENSUS)@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 250, 7, 292, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 292, -3, 292, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    TTOPLAM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 338, 1, 354, 8, false);
                    TTOPLAM1.Name = "TTOPLAM1";
                    TTOPLAM1.Visible = EvetHayirEnum.ehHayir;
                    TTOPLAM1.DrawStyle = DrawStyleConstants.vbSolid;
                    TTOPLAM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOPLAM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TTOPLAM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TTOPLAM1.TextFont.Name = "Arial";
                    TTOPLAM1.TextFont.Bold = true;
                    TTOPLAM1.TextFont.CharSet = 162;
                    TTOPLAM1.Value = @"{@sumof(NORMALCARDAMOUNT1)@}";

                    TGTOPLAM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 375, 1, 395, 8, false);
                    TGTOPLAM1.Name = "TGTOPLAM1";
                    TGTOPLAM1.Visible = EvetHayirEnum.ehHayir;
                    TGTOPLAM1.DrawStyle = DrawStyleConstants.vbSolid;
                    TGTOPLAM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TGTOPLAM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TGTOPLAM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TGTOPLAM1.TextFont.Name = "Arial";
                    TGTOPLAM1.TextFont.Bold = true;
                    TGTOPLAM1.TextFont.CharSet = 162;
                    TGTOPLAM1.Value = @"{@sumof(TOTALCARDAMOUNT1)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OldOrderNO11112.CalcValue = OldOrderNO11112.Value;
                    OldOrderNO121111.CalcValue = OldOrderNO121111.Value;
                    TMD.CalcValue = ParentGroup.FieldSums["OLDMATERIALCENSUS"].Value.ToString();;
                    TSD.CalcValue = ParentGroup.FieldSums["OLDZEROCENSUS"].Value.ToString();;
                    TGELEN.CalcValue = ParentGroup.FieldSums["GELEN1"].Value.ToString();;
                    TGIDEN.CalcValue = ParentGroup.FieldSums["GIDEN1"].Value.ToString();;
                    TTOPLAM.CalcValue = ParentGroup.FieldSums["NORMALCARDAMOUNT"].Value.ToString();;
                    TYMD.CalcValue = ParentGroup.FieldSums["NEWMATERIALCENSUS"].Value.ToString();;
                    TYSD.CalcValue = ParentGroup.FieldSums["NEWZEROCENSUS"].Value.ToString();;
                    TYTOPLAM1.CalcValue = ParentGroup.FieldSums["NEWCARDAMOUNT"].Value.ToString();;
                    TGTOPLAM.CalcValue = ParentGroup.FieldSums["TOTALCARDAMOUNT"].Value.ToString();;
                    TCTOPLAM1.CalcValue = ParentGroup.FieldSums["CIFTSIFIR1"].Value.ToString();;
                    TDTOPLAM.CalcValue = ParentGroup.FieldSums["TOPLAM1"].Value.ToString();;
                    TDMD.CalcValue = ParentGroup.FieldSums["MATERIALCENSUS"].Value.ToString();;
                    TDSD.CalcValue = ParentGroup.FieldSums["ZEROCENSUS"].Value.ToString();;
                    TTOPLAM1.CalcValue = ParentGroup.FieldSums["NORMALCARDAMOUNT1"].Value.ToString();;
                    TGTOPLAM1.CalcValue = ParentGroup.FieldSums["TOTALCARDAMOUNT1"].Value.ToString();;
                    return new TTReportObject[] { OldOrderNO11112,OldOrderNO121111,TMD,TSD,TGELEN,TGIDEN,TTOPLAM,TYMD,TYSD,TYTOPLAM1,TGTOPLAM,TCTOPLAM1,TDTOPLAM,TDMD,TDSD,TTOPLAM1,TGTOPLAM1};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    double materialCensus = 0;
            double zeroCensus = 0 ;
            double total = 0;
            materialCensus = Convert.ToDouble(TDMD.CalcValue) ;
            zeroCensus = Convert.ToDouble(TDSD.CalcValue);
            total = materialCensus + zeroCensus;
            TDTOPLAM.CalcValue = total.ToString();
            
            string termID = ((TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            
            IList stockCensuses = ctx.QueryObjects("STOCKCENSUS","ACCOUNTINGTERM ="+ ConnectionManager.GuidToString( accountingTerm.ObjectID));
            int gelen = 0;
            int giden = 0;
            int ciftSifir = 0;
            foreach(StockCensus census in stockCensuses)
            {
                if(census.CurrentStateDefID == StockCensus.States.Completed)
                {
                    BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer_Class> gelenCount =  ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer(census.AccountingTerm.ObjectID,census.CardDrawer.ObjectID);
                    
                    if (gelenCount[0].Nqlcolumn != null)
                        gelen =  gelen + Convert.ToInt32(gelenCount[0].Nqlcolumn);

                    BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer_Class> gidenCount = ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer(census.CardDrawer.ObjectID,census.AccountingTerm.ObjectID);

                    if (gidenCount[0].Nqlcolumn != null)
                        giden = giden + Convert.ToInt32(gidenCount[0].Nqlcolumn);

                    DoubleZeroCardEpoch doubleZeroCardEpoch = (DoubleZeroCardEpoch)census.GetDoubleZeroEpoch(census.Store,census.AccountingTerm,census.CardDrawer);
                    if(doubleZeroCardEpoch != null)
                        ciftSifir = ciftSifir + (int)doubleZeroCardEpoch.TotalCardCount ;
                }
                
            }
            TGELEN.CalcValue = gelen.ToString();
            TGIDEN.CalcValue = giden.ToString();
            TCTOPLAM1.CalcValue = ciftSifir.ToString();
            
            int ttoplam = Convert.ToInt32(TTOPLAM1.CalcValue)+ ciftSifir;
            TTOPLAM.CalcValue = ttoplam.ToString();
            
            int tgtoplam = Convert.ToInt32(TGTOPLAM1.CalcValue)+ ciftSifir;
            TGTOPLAM.CalcValue = tgtoplam.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
            {
                get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALCENSUS { get {return Body().MATERIALCENSUS;} }
            public TTReportField NEWCARDAMOUNT { get {return Body().NEWCARDAMOUNT;} }
            public TTReportField NEWMATERIALCENSUS { get {return Body().NEWMATERIALCENSUS;} }
            public TTReportField NEWZEROCENSUS { get {return Body().NEWZEROCENSUS;} }
            public TTReportField NORMALCARDAMOUNT { get {return Body().NORMALCARDAMOUNT;} }
            public TTReportField OLDMATERIALCENSUS { get {return Body().OLDMATERIALCENSUS;} }
            public TTReportField OLDZEROCENSUS { get {return Body().OLDZEROCENSUS;} }
            public TTReportField TOTALCARDAMOUNT { get {return Body().TOTALCARDAMOUNT;} }
            public TTReportField ZEROCENSUS { get {return Body().ZEROCENSUS;} }
            public TTReportField CARDDRAWER { get {return Body().CARDDRAWER;} }
            public TTReportField SAYFAADEDI { get {return Body().SAYFAADEDI;} }
            public TTReportField GELEN { get {return Body().GELEN;} }
            public TTReportField GIDEN { get {return Body().GIDEN;} }
            public TTReportField CIFTSIFIR { get {return Body().CIFTSIFIR;} }
            public TTReportField TOPLAM { get {return Body().TOPLAM;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField TOPLAM1 { get {return Body().TOPLAM1;} }
            public TTReportField GELEN1 { get {return Body().GELEN1;} }
            public TTReportField GIDEN1 { get {return Body().GIDEN1;} }
            public TTReportField CIFTSIFIR1 { get {return Body().CIFTSIFIR1;} }
            public TTReportField NORMALCARDAMOUNT1 { get {return Body().NORMALCARDAMOUNT1;} }
            public TTReportField TOTALCARDAMOUNT1 { get {return Body().TOTALCARDAMOUNT1;} }
            public TTReportField HESAPSORUMLUSU1 { get {return Body().HESAPSORUMLUSU1;} }
            public TTReportField CARDDRAWEROBJECTID { get {return Body().CARDDRAWEROBJECTID;} }
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
                list[0] = new TTReportNqlData<StockCensus.GetStockCensusSKHReport_Class>("GetStockCensusSKHReport", StockCensus.GetStockCensusSKHReport((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
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
                public TasinirMalStokKaydiHesapTeftisCizelgesi MyParentReport
                {
                    get { return (TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport; }
                }
                
                public TTReportField MATERIALCENSUS;
                public TTReportField NEWCARDAMOUNT;
                public TTReportField NEWMATERIALCENSUS;
                public TTReportField NEWZEROCENSUS;
                public TTReportField NORMALCARDAMOUNT;
                public TTReportField OLDMATERIALCENSUS;
                public TTReportField OLDZEROCENSUS;
                public TTReportField TOTALCARDAMOUNT;
                public TTReportField ZEROCENSUS;
                public TTReportField CARDDRAWER;
                public TTReportField SAYFAADEDI;
                public TTReportField GELEN;
                public TTReportField GIDEN;
                public TTReportField CIFTSIFIR;
                public TTReportField TOPLAM;
                public TTReportShape NewLine1;
                public TTReportField OBJECTID;
                public TTReportField TOPLAM1;
                public TTReportField GELEN1;
                public TTReportField GIDEN1;
                public TTReportField CIFTSIFIR1;
                public TTReportField NORMALCARDAMOUNT1;
                public TTReportField TOTALCARDAMOUNT1;
                public TTReportField HESAPSORUMLUSU1;
                public TTReportField CARDDRAWEROBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    MATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 239, 5, false);
                    MATERIALCENSUS.Name = "MATERIALCENSUS";
                    MATERIALCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCENSUS.Value = @"{#MATERIALCENSUS#}";

                    NEWCARDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 171, 5, false);
                    NEWCARDAMOUNT.Name = "NEWCARDAMOUNT";
                    NEWCARDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWCARDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWCARDAMOUNT.Value = @"{#NEWCARDAMOUNT#}";

                    NEWMATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 141, 5, false);
                    NEWMATERIALCENSUS.Name = "NEWMATERIALCENSUS";
                    NEWMATERIALCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWMATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWMATERIALCENSUS.Value = @"{#NEWMATERIALCENSUS#}";

                    NEWZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 0, 155, 5, false);
                    NEWZEROCENSUS.Name = "NEWZEROCENSUS";
                    NEWZEROCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWZEROCENSUS.Value = @"{#NEWZEROCENSUS#}";

                    NORMALCARDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 127, 5, false);
                    NORMALCARDAMOUNT.Name = "NORMALCARDAMOUNT";
                    NORMALCARDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    NORMALCARDAMOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    NORMALCARDAMOUNT.Value = @"";

                    OLDMATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 69, 5, false);
                    OLDMATERIALCENSUS.Name = "OLDMATERIALCENSUS";
                    OLDMATERIALCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDMATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDMATERIALCENSUS.Value = @"{#MATERIALOLDCENSUS#}";

                    OLDZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 83, 5, false);
                    OLDZEROCENSUS.Name = "OLDZEROCENSUS";
                    OLDZEROCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDZEROCENSUS.Value = @"{#ZEROOLDCENSUS#}";

                    TOTALCARDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 189, 5, false);
                    TOTALCARDAMOUNT.Name = "TOTALCARDAMOUNT";
                    TOTALCARDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCARDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCARDAMOUNT.Value = @"";

                    ZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 250, 5, false);
                    ZEROCENSUS.Name = "ZEROCENSUS";
                    ZEROCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    ZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ZEROCENSUS.Value = @"{#ZEROCENSUS#}";

                    CARDDRAWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 27, 5, false);
                    CARDDRAWER.Name = "CARDDRAWER";
                    CARDDRAWER.DrawStyle = DrawStyleConstants.vbSolid;
                    CARDDRAWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDDRAWER.ObjectDefName = "ResCardDrawer";
                    CARDDRAWER.DataMember = "NAME";
                    CARDDRAWER.TextFont.Size = 9;
                    CARDDRAWER.TextFont.CharSet = 162;
                    CARDDRAWER.Value = @"{#CARDDRAWER#}";

                    SAYFAADEDI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 55, 5, false);
                    SAYFAADEDI.Name = "SAYFAADEDI";
                    SAYFAADEDI.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYFAADEDI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYFAADEDI.Value = @"";

                    GELEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 97, 5, false);
                    GELEN.Name = "GELEN";
                    GELEN.DrawStyle = DrawStyleConstants.vbSolid;
                    GELEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELEN.Value = @"";

                    GIDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 111, 5, false);
                    GIDEN.Name = "GIDEN";
                    GIDEN.DrawStyle = DrawStyleConstants.vbSolid;
                    GIDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDEN.Value = @"";

                    CIFTSIFIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 228, 5, false);
                    CIFTSIFIR.Name = "CIFTSIFIR";
                    CIFTSIFIR.DrawStyle = DrawStyleConstants.vbSolid;
                    CIFTSIFIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIFTSIFIR.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 266, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 292, 0, 292, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    TOPLAM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 329, 0, 354, 5, false);
                    TOPLAM1.Name = "TOPLAM1";
                    TOPLAM1.Visible = EvetHayirEnum.ehHayir;
                    TOPLAM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM1.Value = @"{%TOPLAM%}";

                    GELEN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 1, 379, 6, false);
                    GELEN1.Name = "GELEN1";
                    GELEN1.Visible = EvetHayirEnum.ehHayir;
                    GELEN1.DrawStyle = DrawStyleConstants.vbSolid;
                    GELEN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELEN1.Value = @"{%GELEN%}";

                    GIDEN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 388, 1, 402, 6, false);
                    GIDEN1.Name = "GIDEN1";
                    GIDEN1.Visible = EvetHayirEnum.ehHayir;
                    GIDEN1.DrawStyle = DrawStyleConstants.vbSolid;
                    GIDEN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDEN1.Value = @"{%GIDEN%}";

                    CIFTSIFIR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 412, 1, 432, 6, false);
                    CIFTSIFIR1.Name = "CIFTSIFIR1";
                    CIFTSIFIR1.Visible = EvetHayirEnum.ehHayir;
                    CIFTSIFIR1.DrawStyle = DrawStyleConstants.vbSolid;
                    CIFTSIFIR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIFTSIFIR1.Value = @"{%CIFTSIFIR%}";

                    NORMALCARDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 441, 0, 457, 5, false);
                    NORMALCARDAMOUNT1.Name = "NORMALCARDAMOUNT1";
                    NORMALCARDAMOUNT1.Visible = EvetHayirEnum.ehHayir;
                    NORMALCARDAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    NORMALCARDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NORMALCARDAMOUNT1.Value = @"{#NORMALCARDAMOUNT#}";

                    TOTALCARDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 464, 1, 484, 6, false);
                    TOTALCARDAMOUNT1.Name = "TOTALCARDAMOUNT1";
                    TOTALCARDAMOUNT1.Visible = EvetHayirEnum.ehHayir;
                    TOTALCARDAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCARDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCARDAMOUNT1.Value = @"{#TOTALCARDAMOUNT#}";

                    HESAPSORUMLUSU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 0, 292, 5, false);
                    HESAPSORUMLUSU1.Name = "HESAPSORUMLUSU1";
                    HESAPSORUMLUSU1.DrawStyle = DrawStyleConstants.vbSolid;
                    HESAPSORUMLUSU1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HESAPSORUMLUSU1.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU1.TextFont.Size = 9;
                    HESAPSORUMLUSU1.TextFont.CharSet = 162;
                    HESAPSORUMLUSU1.Value = @"";

                    CARDDRAWEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 352, 0, 378, 5, false);
                    CARDDRAWEROBJECTID.Name = "CARDDRAWEROBJECTID";
                    CARDDRAWEROBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    CARDDRAWEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDDRAWEROBJECTID.TextFont.Size = 9;
                    CARDDRAWEROBJECTID.TextFont.CharSet = 162;
                    CARDDRAWEROBJECTID.Value = @"{#CARDDRAWER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetStockCensusSKHReport_Class dataset_GetStockCensusSKHReport = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetStockCensusSKHReport_Class>(0);
                    MATERIALCENSUS.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.MaterialCensus) : "");
                    NEWCARDAMOUNT.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.NewCardAmount) : "");
                    NEWMATERIALCENSUS.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.NewMaterialCensus) : "");
                    NEWZEROCENSUS.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.NewZeroCensus) : "");
                    OLDMATERIALCENSUS.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.MaterialOldCensus) : "");
                    OLDZEROCENSUS.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.ZeroOldCensus) : "");
                    TOTALCARDAMOUNT.CalcValue = @"";
                    ZEROCENSUS.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.ZeroCensus) : "");
                    CARDDRAWER.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.CardDrawer) : "");
                    CARDDRAWER.PostFieldValueCalculation();
                    SAYFAADEDI.CalcValue = @"";
                    GELEN.CalcValue = @"";
                    GIDEN.CalcValue = @"";
                    CIFTSIFIR.CalcValue = @"";
                    TOPLAM.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.ObjectID) : "");
                    TOPLAM1.CalcValue = MyParentReport.MAIN.TOPLAM.CalcValue;
                    GELEN1.CalcValue = MyParentReport.MAIN.GELEN.CalcValue;
                    GIDEN1.CalcValue = MyParentReport.MAIN.GIDEN.CalcValue;
                    CIFTSIFIR1.CalcValue = MyParentReport.MAIN.CIFTSIFIR.CalcValue;
                    NORMALCARDAMOUNT1.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.NormalCardAmount) : "");
                    TOTALCARDAMOUNT1.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.TotalCardAmount) : "");
                    HESAPSORUMLUSU1.CalcValue = @"";
                    CARDDRAWEROBJECTID.CalcValue = (dataset_GetStockCensusSKHReport != null ? Globals.ToStringCore(dataset_GetStockCensusSKHReport.CardDrawer) : "");
                    NORMALCARDAMOUNT.CalcValue = @"";
                    return new TTReportObject[] { MATERIALCENSUS,NEWCARDAMOUNT,NEWMATERIALCENSUS,NEWZEROCENSUS,OLDMATERIALCENSUS,OLDZEROCENSUS,TOTALCARDAMOUNT,ZEROCENSUS,CARDDRAWER,SAYFAADEDI,GELEN,GIDEN,CIFTSIFIR,TOPLAM,OBJECTID,TOPLAM1,GELEN1,GIDEN1,CIFTSIFIR1,NORMALCARDAMOUNT1,TOTALCARDAMOUNT1,HESAPSORUMLUSU1,CARDDRAWEROBJECTID,NORMALCARDAMOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            StockCensus census = (StockCensus)ctx.GetObject(new Guid(OBJECTID.CalcValue.ToString()), typeof(StockCensus));
            long toplam = 0;
            toplam =(long)census.MaterialCensus + (long)census.ZeroCensus ;
            TOPLAM.CalcValue = toplam.ToString() ;
            
            BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer_Class> gelenCount =  ChangeStockCardDrawer.GetChangeStockCardDrawerByNewCardDrawer(census.AccountingTerm.ObjectID,census.CardDrawer.ObjectID);
            
            int gelen = 0;
            if (gelenCount[0].Nqlcolumn != null)
            {
                gelen = Convert.ToInt32(gelenCount[0].Nqlcolumn);
            }

            BindingList<ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer_Class> gidenCount = ChangeStockCardDrawer.GetChangeStockCardDrawerByOldCardDrawer(census.CardDrawer.ObjectID,census.AccountingTerm.ObjectID);
            int giden = 0;
            if (gidenCount[0].Nqlcolumn != null)
                giden = Convert.ToInt32(gidenCount[0].Nqlcolumn);

            GELEN.CalcValue = gelen.ToString();
            GIDEN.CalcValue = giden.ToString();
            
            DoubleZeroCardEpoch doubleZeroCardEpoch = (DoubleZeroCardEpoch)census.GetDoubleZeroEpoch(census.Store,census.AccountingTerm,census.CardDrawer);
            if(doubleZeroCardEpoch != null)
            {
                CIFTSIFIR.CalcValue = doubleZeroCardEpoch.TotalCardCount.ToString();
            }
            
            int normalCardAmount = Convert.ToInt32(NORMALCARDAMOUNT1.CalcValue)+ (int)doubleZeroCardEpoch.TotalCardCount;
            NORMALCARDAMOUNT.CalcValue = normalCardAmount.ToString();
            
            int totalCardAmount = Convert.ToInt32(TOTALCARDAMOUNT1.CalcValue)+ (int)doubleZeroCardEpoch.TotalCardCount;
            TOTALCARDAMOUNT.CalcValue = totalCardAmount.ToString();
            
            
            
            string termID = ((TasinirMalStokKaydiHesapTeftisCizelgesi)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctxx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctxx.GetObject(new Guid(termID), typeof(AccountingTerm));
            
            IList checkStockCensusActions = ctxx.QueryObjects("CHECKSTOCKCENSUSACTION","ACCOUNTINGTERM=" + ConnectionManager.GuidToString(term.ObjectID));
            if(checkStockCensusActions.Count > 0)
            {
                CheckStockCensusAction checkStockCensusAction = (CheckStockCensusAction)checkStockCensusActions[0];
                
                
                //Guid oID = new Guid(census.CardDrawer.ObjectID);
                HESAPSORUMLUSU1.CalcValue = checkStockCensusAction.SignOfAccontingterm2(census.CardDrawer.ObjectID);
            }
            
            
            
            
            //  TTObjectContext ctxx = new TTObjectContext(true);
            // CheckStockCensusAction checkStockCensusAction = new CheckStockCensusAction(ctxx);
            //   Guid oID = new Guid();
            //   HESAPSORUMLUSU1.CalcValue = checkStockCensusAction.SignOfAccontingterm2(oID);
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

        public TasinirMalStokKaydiHesapTeftisCizelgesi()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemi", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Saymanlık", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            Name = "TASINIRMALSTOKKAYDIHESAPTEFTISCIZELGESI";
            Caption = "Taşınır Mal Stok Kaydı Hesap Teftiş Çizelgesi (EK-16)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 5;
            UserMarginTop = 15;
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