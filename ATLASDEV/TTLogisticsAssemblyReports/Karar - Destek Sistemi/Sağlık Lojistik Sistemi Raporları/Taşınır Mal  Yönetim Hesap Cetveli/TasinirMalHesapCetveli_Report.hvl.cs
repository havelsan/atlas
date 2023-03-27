
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
    /// Taşınır Mal Yönetim Hesap Cetveli (EK-106)
    /// </summary>
    public partial class TasinirMalHesapCetveli : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? CARDDRAWERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TasinirMalHesapCetveli MyParentReport
            {
                get { return (TasinirMalHesapCetveli)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField OldOrderNO1 { get {return Header().OldOrderNO1;} }
            public TTReportField OldOrderNO11 { get {return Header().OldOrderNO11;} }
            public TTReportField OldOrderNO12 { get {return Header().OldOrderNO12;} }
            public TTReportField OldOrderNO121 { get {return Header().OldOrderNO121;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField KURUMKODU { get {return Header().KURUMKODU;} }
            public TTReportField KODU { get {return Header().KODU;} }
            public TTReportField OldOrderNO1112111 { get {return Header().OldOrderNO1112111;} }
            public TTReportField SAYMANLIKKODU { get {return Header().SAYMANLIKKODU;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public TasinirMalHesapCetveli MyParentReport
                {
                    get { return (TasinirMalHesapCetveli)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField OldOrderNO1;
                public TTReportField OldOrderNO11;
                public TTReportField OldOrderNO12;
                public TTReportField OldOrderNO121;
                public TTReportField BIRLIK;
                public TTReportField SAYMANLIK;
                public TTReportField KURUMKODU;
                public TTReportField KODU;
                public TTReportField OldOrderNO1112111;
                public TTReportField SAYMANLIKKODU;
                public TTReportField ReportName1;
                public TTReportField NewField1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 5, 287, 16, false);
                    ReportName.Name = "ReportName";
                    ReportName.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"TAŞINIR MAL YÖNETİM HESAP CETVELİ";

                    OldOrderNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 16, 70, 26, false);
                    OldOrderNO1.Name = "OldOrderNO1";
                    OldOrderNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO1.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO1.TextFont.Name = "Arial";
                    OldOrderNO1.TextFont.Bold = true;
                    OldOrderNO1.TextFont.CharSet = 162;
                    OldOrderNO1.Value = @"Harcama Birimi Birlik/Kurumunun Adı";

                    OldOrderNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 26, 70, 32, false);
                    OldOrderNO11.Name = "OldOrderNO11";
                    OldOrderNO11.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO11.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO11.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO11.TextFont.Name = "Arial";
                    OldOrderNO11.TextFont.Bold = true;
                    OldOrderNO11.TextFont.CharSet = 162;
                    OldOrderNO11.Value = @"Taşınır Mal Saymanlığının Adı";

                    OldOrderNO12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 16, 215, 26, false);
                    OldOrderNO12.Name = "OldOrderNO12";
                    OldOrderNO12.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO12.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO12.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO12.TextFont.Name = "Arial";
                    OldOrderNO12.TextFont.Bold = true;
                    OldOrderNO12.TextFont.CharSet = 162;
                    OldOrderNO12.Value = @"KODU";

                    OldOrderNO121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 26, 215, 32, false);
                    OldOrderNO121.Name = "OldOrderNO121";
                    OldOrderNO121.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO121.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO121.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO121.TextFont.Name = "Arial";
                    OldOrderNO121.TextFont.Bold = true;
                    OldOrderNO121.TextFont.CharSet = 162;
                    OldOrderNO121.Value = @"KODU";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 16, 185, 26, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 26, 185, 32, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMANLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 16, 245, 26, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KURUMKODU.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMKODU.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMKODU.TextFont.CharSet = 162;
                    KURUMKODU.Value = @"";

                    KODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 16, 287, 32, false);
                    KODU.Name = "KODU";
                    KODU.DrawStyle = DrawStyleConstants.vbSolid;
                    KODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KODU.TextFont.CharSet = 162;
                    KODU.Value = @"";

                    OldOrderNO1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 16, 265, 32, false);
                    OldOrderNO1112111.Name = "OldOrderNO1112111";
                    OldOrderNO1112111.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO1112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO1112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO1112111.TextFont.Name = "Arial";
                    OldOrderNO1112111.TextFont.Bold = true;
                    OldOrderNO1112111.TextFont.CharSet = 162;
                    OldOrderNO1112111.Value = @"YILI";

                    SAYMANLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 26, 245, 32, false);
                    SAYMANLIKKODU.Name = "SAYMANLIKKODU";
                    SAYMANLIKKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIKKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIKKODU.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMANLIKKODU.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMANLIKKODU.TextFont.CharSet = 162;
                    SAYMANLIKKODU.Value = @"";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 32, 287, 38, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Size = 12;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 6, 286, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.Value = @"EK - 106";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    OldOrderNO1.CalcValue = OldOrderNO1.Value;
                    OldOrderNO11.CalcValue = OldOrderNO11.Value;
                    OldOrderNO12.CalcValue = OldOrderNO12.Value;
                    OldOrderNO121.CalcValue = OldOrderNO121.Value;
                    BIRLIK.CalcValue = @"";
                    SAYMANLIK.CalcValue = @"";
                    KURUMKODU.CalcValue = @"";
                    KODU.CalcValue = @"";
                    OldOrderNO1112111.CalcValue = OldOrderNO1112111.Value;
                    SAYMANLIKKODU.CalcValue = @"";
                    ReportName1.CalcValue = ReportName1.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { ReportName,OldOrderNO1,OldOrderNO11,OldOrderNO12,OldOrderNO121,BIRLIK,SAYMANLIK,KURUMKODU,KODU,OldOrderNO1112111,SAYMANLIKKODU,ReportName1,NewField1};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string termID = ((TasinirMalHesapCetveli)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(accountingTerm.EndDate != null)
            {
                int actionYear = Convert.ToDateTime(accountingTerm.EndDate).Year;
                this.KODU.CalcValue = actionYear.ToString() ;
                this.SAYMANLIK.CalcValue = accountingTerm.Accountancy.Name;
                this.BIRLIK.CalcValue = accountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                this.KURUMKODU.CalcValue = accountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                this.SAYMANLIKKODU.CalcValue = accountingTerm.Accountancy.AccountancyNO;
                
                //this.AtOldYear.CalcValue = actionYear.ToString() + " YILINDA";
                //this.AtNewYear.CalcValue = (actionYear + 1).ToString() + " YILINA DEVİR";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TasinirMalHesapCetveli MyParentReport
                {
                    get { return (TasinirMalHesapCetveli)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 1, 151, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.Bold = true;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa {@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"Sayfa " + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public TasinirMalHesapCetveli MyParentReport
            {
                get { return (TasinirMalHesapCetveli)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField OldOrderNO { get {return Header().OldOrderNO;} }
            public TTReportField NewOrderNO { get {return Header().NewOrderNO;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField AtOldYear { get {return Header().AtOldYear;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField1122111 { get {return Header().NewField1122111;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField AtOldYear1 { get {return Header().AtOldYear1;} }
            public TTReportField NewField1122112 { get {return Header().NewField1122112;} }
            public TTReportField NewField11112211 { get {return Header().NewField11112211;} }
            public TTReportField AtOldYear11 { get {return Header().AtOldYear11;} }
            public TTReportField NewField12112211 { get {return Header().NewField12112211;} }
            public TTReportField NewField111221111 { get {return Header().NewField111221111;} }
            public TTReportField AtOldYear12 { get {return Header().AtOldYear12;} }
            public TTReportField NewField12112212 { get {return Header().NewField12112212;} }
            public TTReportField NewField111221112 { get {return Header().NewField111221112;} }
            public TTReportField AtOldYear121 { get {return Header().AtOldYear121;} }
            public TTReportField NewField121221121 { get {return Header().NewField121221121;} }
            public TTReportField NewField1211122111 { get {return Header().NewField1211122111;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField NEWMATERIALCENSUS { get {return Footer().NEWMATERIALCENSUS;} }
            public TTReportField NEWZEROCENSUS { get {return Footer().NEWZEROCENSUS;} }
            public TTReportField OLDMATERIALCENSUS { get {return Footer().OLDMATERIALCENSUS;} }
            public TTReportField OLDZEROCENSUS { get {return Footer().OLDZEROCENSUS;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField SAYMAN { get {return Footer().SAYMAN;} }
            public TTReportField HESAPSORUMLUSU { get {return Footer().HESAPSORUMLUSU;} }
            public TTReportField TKM { get {return Footer().TKM;} }
            public TTReportField TKB { get {return Footer().TKB;} }
            public TTReportField NewField112111 { get {return Footer().NewField112111;} }
            public TTReportField NewField1111211 { get {return Footer().NewField1111211;} }
            public TTReportField NewField11121111 { get {return Footer().NewField11121111;} }
            public TTReportField NewField1311112111 { get {return Footer().NewField1311112111;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StockCensus.GetStockCensus_Class>("GetStockCensus", StockCensus.GetStockCensus((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWERID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public TasinirMalHesapCetveli MyParentReport
                {
                    get { return (TasinirMalHesapCetveli)ParentReport; }
                }
                
                public TTReportField OldOrderNO;
                public TTReportField NewOrderNO;
                public TTReportField NewField11111;
                public TTReportField AtOldYear;
                public TTReportField NewField111221;
                public TTReportField NewField1122111;
                public TTReportField NewField111211;
                public TTReportField AtOldYear1;
                public TTReportField NewField1122112;
                public TTReportField NewField11112211;
                public TTReportField AtOldYear11;
                public TTReportField NewField12112211;
                public TTReportField NewField111221111;
                public TTReportField AtOldYear12;
                public TTReportField NewField12112212;
                public TTReportField NewField111221112;
                public TTReportField AtOldYear121;
                public TTReportField NewField121221121;
                public TTReportField NewField1211122111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OldOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 94, 20, false);
                    OldOrderNO.Name = "OldOrderNO";
                    OldOrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO.TextFont.Name = "Arial";
                    OldOrderNO.TextFont.Bold = true;
                    OldOrderNO.TextFont.CharSet = 162;
                    OldOrderNO.Value = @"
Taşınır 
Malın Adı";

                    NewOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 12, 20, false);
                    NewOrderNO.Name = "NewOrderNO";
                    NewOrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NewOrderNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewOrderNO.TextFont.Name = "Arial";
                    NewOrderNO.TextFont.Size = 9;
                    NewOrderNO.TextFont.Bold = true;
                    NewOrderNO.TextFont.CharSet = 162;
                    NewOrderNO.Value = @"S.NU";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 0, 109, 20, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"
Ölçü
Birimi";

                    AtOldYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 145, 10, false);
                    AtOldYear.Name = "AtOldYear";
                    AtOldYear.DrawStyle = DrawStyleConstants.vbSolid;
                    AtOldYear.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtOldYear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AtOldYear.MultiLine = EvetHayirEnum.ehEvet;
                    AtOldYear.WordBreak = EvetHayirEnum.ehEvet;
                    AtOldYear.TextFont.Name = "Arial";
                    AtOldYear.TextFont.Size = 8;
                    AtOldYear.TextFont.Bold = true;
                    AtOldYear.TextFont.CharSet = 162;
                    AtOldYear.Value = @"GEÇEN YILDAN
DEVREDEN";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 10, 127, 20, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 8;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"MİKTARI";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 10, 145, 20, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122111.TextFont.Name = "Arial";
                    NewField1122111.TextFont.Size = 8;
                    NewField1122111.TextFont.Bold = true;
                    NewField1122111.TextFont.CharSet = 162;
                    NewField1122111.Value = @"TUTARI";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 36, 20, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"
Stok 
Numarası
";

                    AtOldYear1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 181, 10, false);
                    AtOldYear1.Name = "AtOldYear1";
                    AtOldYear1.DrawStyle = DrawStyleConstants.vbSolid;
                    AtOldYear1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtOldYear1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    AtOldYear1.MultiLine = EvetHayirEnum.ehEvet;
                    AtOldYear1.WordBreak = EvetHayirEnum.ehEvet;
                    AtOldYear1.TextFont.Name = "Arial";
                    AtOldYear1.TextFont.Size = 8;
                    AtOldYear1.TextFont.Bold = true;
                    AtOldYear1.TextFont.CharSet = 162;
                    AtOldYear1.Value = @"
YIL İÇİNDE GİREN";

                    NewField1122112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 10, 163, 20, false);
                    NewField1122112.Name = "NewField1122112";
                    NewField1122112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122112.TextFont.Name = "Arial";
                    NewField1122112.TextFont.Size = 8;
                    NewField1122112.TextFont.Bold = true;
                    NewField1122112.TextFont.CharSet = 162;
                    NewField1122112.Value = @"MİKTARI";

                    NewField11112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 10, 181, 20, false);
                    NewField11112211.Name = "NewField11112211";
                    NewField11112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112211.TextFont.Name = "Arial";
                    NewField11112211.TextFont.Size = 8;
                    NewField11112211.TextFont.Bold = true;
                    NewField11112211.TextFont.CharSet = 162;
                    NewField11112211.Value = @"TUTARI";

                    AtOldYear11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 217, 10, false);
                    AtOldYear11.Name = "AtOldYear11";
                    AtOldYear11.DrawStyle = DrawStyleConstants.vbSolid;
                    AtOldYear11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtOldYear11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    AtOldYear11.MultiLine = EvetHayirEnum.ehEvet;
                    AtOldYear11.WordBreak = EvetHayirEnum.ehEvet;
                    AtOldYear11.TextFont.Name = "Arial";
                    AtOldYear11.TextFont.Size = 8;
                    AtOldYear11.TextFont.Bold = true;
                    AtOldYear11.TextFont.CharSet = 162;
                    AtOldYear11.Value = @"
TOPLAM";

                    NewField12112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 10, 199, 20, false);
                    NewField12112211.Name = "NewField12112211";
                    NewField12112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112211.TextFont.Name = "Arial";
                    NewField12112211.TextFont.Size = 8;
                    NewField12112211.TextFont.Bold = true;
                    NewField12112211.TextFont.CharSet = 162;
                    NewField12112211.Value = @"MİKTARI";

                    NewField111221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 10, 217, 20, false);
                    NewField111221111.Name = "NewField111221111";
                    NewField111221111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221111.TextFont.Name = "Arial";
                    NewField111221111.TextFont.Size = 8;
                    NewField111221111.TextFont.Bold = true;
                    NewField111221111.TextFont.CharSet = 162;
                    NewField111221111.Value = @"TUTARI";

                    AtOldYear12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 253, 10, false);
                    AtOldYear12.Name = "AtOldYear12";
                    AtOldYear12.DrawStyle = DrawStyleConstants.vbSolid;
                    AtOldYear12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtOldYear12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    AtOldYear12.MultiLine = EvetHayirEnum.ehEvet;
                    AtOldYear12.WordBreak = EvetHayirEnum.ehEvet;
                    AtOldYear12.TextFont.Name = "Arial";
                    AtOldYear12.TextFont.Size = 8;
                    AtOldYear12.TextFont.Bold = true;
                    AtOldYear12.TextFont.CharSet = 162;
                    AtOldYear12.Value = @"
YIL İÇİNDE ÇIKAN";

                    NewField12112212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 10, 235, 20, false);
                    NewField12112212.Name = "NewField12112212";
                    NewField12112212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112212.TextFont.Name = "Arial";
                    NewField12112212.TextFont.Size = 8;
                    NewField12112212.TextFont.Bold = true;
                    NewField12112212.TextFont.CharSet = 162;
                    NewField12112212.Value = @"MİKTARI";

                    NewField111221112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 10, 253, 20, false);
                    NewField111221112.Name = "NewField111221112";
                    NewField111221112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221112.TextFont.Name = "Arial";
                    NewField111221112.TextFont.Size = 8;
                    NewField111221112.TextFont.Bold = true;
                    NewField111221112.TextFont.CharSet = 162;
                    NewField111221112.Value = @"TUTARI";

                    AtOldYear121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 0, 287, 10, false);
                    AtOldYear121.Name = "AtOldYear121";
                    AtOldYear121.DrawStyle = DrawStyleConstants.vbSolid;
                    AtOldYear121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtOldYear121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    AtOldYear121.MultiLine = EvetHayirEnum.ehEvet;
                    AtOldYear121.WordBreak = EvetHayirEnum.ehEvet;
                    AtOldYear121.TextFont.Name = "Arial";
                    AtOldYear121.TextFont.Size = 8;
                    AtOldYear121.TextFont.Bold = true;
                    AtOldYear121.TextFont.CharSet = 162;
                    AtOldYear121.Value = @"
GELECEK YILA DEVİR";

                    NewField121221121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 10, 271, 20, false);
                    NewField121221121.Name = "NewField121221121";
                    NewField121221121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221121.TextFont.Name = "Arial";
                    NewField121221121.TextFont.Size = 8;
                    NewField121221121.TextFont.Bold = true;
                    NewField121221121.TextFont.CharSet = 162;
                    NewField121221121.Value = @"MİKTARI";

                    NewField1211122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 10, 287, 20, false);
                    NewField1211122111.Name = "NewField1211122111";
                    NewField1211122111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211122111.TextFont.Name = "Arial";
                    NewField1211122111.TextFont.Size = 8;
                    NewField1211122111.TextFont.Bold = true;
                    NewField1211122111.TextFont.CharSet = 162;
                    NewField1211122111.Value = @"TUTARI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetStockCensus_Class dataset_GetStockCensus = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetStockCensus_Class>(0);
                    OldOrderNO.CalcValue = OldOrderNO.Value;
                    NewOrderNO.CalcValue = NewOrderNO.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    AtOldYear.CalcValue = AtOldYear.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField1122111.CalcValue = NewField1122111.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    AtOldYear1.CalcValue = AtOldYear1.Value;
                    NewField1122112.CalcValue = NewField1122112.Value;
                    NewField11112211.CalcValue = NewField11112211.Value;
                    AtOldYear11.CalcValue = AtOldYear11.Value;
                    NewField12112211.CalcValue = NewField12112211.Value;
                    NewField111221111.CalcValue = NewField111221111.Value;
                    AtOldYear12.CalcValue = AtOldYear12.Value;
                    NewField12112212.CalcValue = NewField12112212.Value;
                    NewField111221112.CalcValue = NewField111221112.Value;
                    AtOldYear121.CalcValue = AtOldYear121.Value;
                    NewField121221121.CalcValue = NewField121221121.Value;
                    NewField1211122111.CalcValue = NewField1211122111.Value;
                    return new TTReportObject[] { OldOrderNO,NewOrderNO,NewField11111,AtOldYear,NewField111221,NewField1122111,NewField111211,AtOldYear1,NewField1122112,NewField11112211,AtOldYear11,NewField12112211,NewField111221111,AtOldYear12,NewField12112212,NewField111221112,AtOldYear121,NewField121221121,NewField1211122111};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string termID = ((TasinirMalHesapCetveli)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(accountingTerm.EndDate != null)
            {
                int actionYear = Convert.ToDateTime(accountingTerm.EndDate).Year;
                //this.YearCensus.CalcValue = "\n" + actionYear.ToString() + " YILINA\nDEVİR";
                //this.AtOldYear.CalcValue = actionYear.ToString() + " YILINDA";
                //this.AtNewYear.CalcValue = (actionYear + 1).ToString() + " YILINA DEVİR";
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TasinirMalHesapCetveli MyParentReport
                {
                    get { return (TasinirMalHesapCetveli)ParentReport; }
                }
                
                public TTReportField COUNTTEXT;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField NEWMATERIALCENSUS;
                public TTReportField NEWZEROCENSUS;
                public TTReportField OLDMATERIALCENSUS;
                public TTReportField OLDZEROCENSUS;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField SAYMAN;
                public TTReportField HESAPSORUMLUSU;
                public TTReportField TKM;
                public TTReportField TKB;
                public TTReportField NewField112111;
                public TTReportField NewField1111211;
                public TTReportField NewField11121111;
                public TTReportField NewField1311112111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 54;
                    RepeatCount = 0;
                    
                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 287, 6, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTTEXT.TextFont.Name = "Arial";
                    COUNTTEXT.TextFont.CharSet = 162;
                    COUNTTEXT.Value = @"";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 4, 337, 9, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT.Value = @"{@sumof(SUBGROUPCOUNT1)@}";

                    NEWMATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 7, 197, 12, false);
                    NEWMATERIALCENSUS.Name = "NEWMATERIALCENSUS";
                    NEWMATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWMATERIALCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWMATERIALCENSUS.TextFont.Bold = true;
                    NEWMATERIALCENSUS.TextFont.CharSet = 162;
                    NEWMATERIALCENSUS.Value = @"{#NEWMATERIALCENSUS#}";

                    NEWZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 7, 250, 12, false);
                    NEWZEROCENSUS.Name = "NEWZEROCENSUS";
                    NEWZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWZEROCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWZEROCENSUS.TextFont.Bold = true;
                    NEWZEROCENSUS.TextFont.CharSet = 162;
                    NEWZEROCENSUS.Value = @"{#NEWZEROCENSUS#}";

                    OLDMATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 7, 76, 12, false);
                    OLDMATERIALCENSUS.Name = "OLDMATERIALCENSUS";
                    OLDMATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDMATERIALCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDMATERIALCENSUS.TextFont.Bold = true;
                    OLDMATERIALCENSUS.TextFont.CharSet = 162;
                    OLDMATERIALCENSUS.Value = @"{#OLDMATERIALCENSUS#}";

                    OLDZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 7, 128, 12, false);
                    OLDZEROCENSUS.Name = "OLDZEROCENSUS";
                    OLDZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDZEROCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDZEROCENSUS.TextFont.Bold = true;
                    OLDZEROCENSUS.TextFont.CharSet = 162;
                    OLDZEROCENSUS.Value = @"{#OLDZEROCENSUS#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 7, 48, 12, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Eski Mal Devirli";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 7, 51, 12, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 0;
                    NewField2.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 7, 100, 12, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Eski Sıfır Devirli";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 7, 103, 12, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 0;
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 7, 169, 12, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Yeni Mal Devirli";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 7, 172, 12, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 0;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 7, 222, 12, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Yeni Sıfır Devirli";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 7, 225, 12, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 0;
                    NewField16.Value = @":";

                    SAYMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 18, 84, 37, false);
                    SAYMAN.Name = "SAYMAN";
                    SAYMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMAN.Value = @"";

                    HESAPSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 18, 225, 37, false);
                    HESAPSORUMLUSU.Name = "HESAPSORUMLUSU";
                    HESAPSORUMLUSU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HESAPSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.Value = @"";

                    TKM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 18, 177, 37, false);
                    TKM.Name = "TKM";
                    TKM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKM.MultiLine = EvetHayirEnum.ehEvet;
                    TKM.WordBreak = EvetHayirEnum.ehEvet;
                    TKM.Value = @"";

                    TKB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 18, 131, 37, false);
                    TKB.Name = "TKB";
                    TKB.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKB.MultiLine = EvetHayirEnum.ehEvet;
                    TKB.WordBreak = EvetHayirEnum.ehEvet;
                    TKB.Value = @"";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 37, 76, 47, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"Sayman";

                    NewField1111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 37, 217, 46, false);
                    NewField1111211.Name = "NewField1111211";
                    NewField1111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111211.TextFont.Name = "Arial";
                    NewField1111211.TextFont.Bold = true;
                    NewField1111211.TextFont.CharSet = 162;
                    NewField1111211.Value = @"Hesap Sorumlusu";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 37, 176, 47, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121111.TextFont.Name = "Arial";
                    NewField11121111.TextFont.Bold = true;
                    NewField11121111.TextFont.CharSet = 162;
                    NewField11121111.Value = @"Teftiş Kurulu Müfettişi";

                    NewField1311112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 37, 131, 47, false);
                    NewField1311112111.Name = "NewField1311112111";
                    NewField1311112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112111.TextFont.Name = "Arial";
                    NewField1311112111.TextFont.Bold = true;
                    NewField1311112111.TextFont.CharSet = 162;
                    NewField1311112111.Value = @"Teftiş Kurulu Başkanı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetStockCensus_Class dataset_GetStockCensus = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetStockCensus_Class>(0);
                    COUNTTEXT.CalcValue = @"";
                    SUBGROUPCOUNT.CalcValue = ParentGroup.FieldSums["SUBGROUPCOUNT1"].Value.ToString();;
                    NEWMATERIALCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.NewMaterialCensus) : "");
                    NEWZEROCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.NewZeroCensus) : "");
                    OLDMATERIALCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.OldMaterialCensus) : "");
                    OLDZEROCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.OldZeroCensus) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    SAYMAN.CalcValue = @"";
                    HESAPSORUMLUSU.CalcValue = @"";
                    TKM.CalcValue = @"";
                    TKB.CalcValue = @"";
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField1111211.CalcValue = NewField1111211.Value;
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField1311112111.CalcValue = NewField1311112111.Value;
                    return new TTReportObject[] { COUNTTEXT,SUBGROUPCOUNT,NEWMATERIALCENSUS,NEWZEROCENSUS,OLDMATERIALCENSUS,OLDZEROCENSUS,NewField1,NewField2,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,SAYMAN,HESAPSORUMLUSU,TKM,TKB,NewField112111,NewField1111211,NewField11121111,NewField1311112111};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    COUNTTEXT.CalcValue = "///////////YALNIZ " + SUBGROUPCOUNT.FormattedValue + " (" + TTReportTool.Common.SpellNumber(SUBGROUPCOUNT.CalcValue.ToString()) + ") KALEMDİR///////////";
                   
             string termID = ((TasinirMalHesapCetveli)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
              AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            
             IList checkStockCensusActions = ctx.QueryObjects("CHECKSTOCKCENSUSACTION","ACCOUNTINGTERM=" + ConnectionManager.GuidToString(term.ObjectID));
            if(checkStockCensusActions.Count > 0)
            {
                CheckStockCensusAction checkStockCensusAction = (CheckStockCensusAction)checkStockCensusActions[0];
                
               SAYMAN.CalcValue =  checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.MalSaymani);
            TKB.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.TeftisKuruluBaskani);
            TKM.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.TeftisKuruluMufettisi);
            HESAPSORUMLUSU.CalcValue = checkStockCensusAction.SignOfAccontingterm((Guid)(MyParentReport.RuntimeParameters.CARDDRAWERID)); 
            }
               
                    
                    
                    
                
            

           // HESAPSORUMLUSU.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.HesapSorumlusu);
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public TasinirMalHesapCetveli MyParentReport
            {
                get { return (TasinirMalHesapCetveli)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField NEWORDERNO { get {return Body().NEWORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField TOTALIN { get {return Body().TOTALIN;} }
            public TTReportField TOTALOUT { get {return Body().TOTALOUT;} }
            public TTReportField TOTALINHELD { get {return Body().TOTALINHELD;} }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
            public TTReportField PTERM { get {return Body().PTERM;} }
            public TTReportField TOTALINPRICE { get {return Body().TOTALINPRICE;} }
            public TTReportField TOTALOUTPRICE { get {return Body().TOTALOUTPRICE;} }
            public TTReportField OLDTOTAL { get {return Body().OLDTOTAL;} }
            public TTReportField STOCKCARD { get {return Body().STOCKCARD;} }
            public TTReportField OLDTOTALPRICE { get {return Body().OLDTOTALPRICE;} }
            public TTReportField OLDUNITPRICE { get {return Body().OLDUNITPRICE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField SUBGROUPCOUNT1 { get {return Body().SUBGROUPCOUNT1;} }
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
                list[0] = new TTReportNqlData<StockCensus.GetCensusScheduleReportQuery_Class>("GetCensusScheduleReportQuery", StockCensus.GetCensusScheduleReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWERID)));
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
                public TasinirMalHesapCetveli MyParentReport
                {
                    get { return (TasinirMalHesapCetveli)ParentReport; }
                }
                
                public TTReportField NATOSTOCKNO;
                public TTReportField NEWORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField TOTALIN;
                public TTReportField TOTALOUT;
                public TTReportField TOTALINHELD;
                public TTReportField TOTAL;
                public TTReportField PTERM;
                public TTReportField TOTALINPRICE;
                public TTReportField TOTALOUTPRICE;
                public TTReportField OLDTOTAL;
                public TTReportField STOCKCARD;
                public TTReportField OLDTOTALPRICE;
                public TTReportField OLDUNITPRICE;
                public TTReportField UNITPRICE;
                public TTReportField TOTALPRICE;
                public TTReportField PRICE;
                public TTReportField SUBGROUPCOUNT1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 36, 9, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.Size = 7;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    NEWORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 12, 9, false);
                    NEWORDERNO.Name = "NEWORDERNO";
                    NEWORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWORDERNO.TextFont.Name = "Arial";
                    NEWORDERNO.TextFont.Size = 7;
                    NEWORDERNO.TextFont.CharSet = 162;
                    NEWORDERNO.Value = @"{#NEWORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 94, 9, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 7;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 0, 109, 9, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 7;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    TOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 163, 9, false);
                    TOTALIN.Name = "TOTALIN";
                    TOTALIN.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALIN.TextFormat = @"General Number";
                    TOTALIN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALIN.TextFont.Name = "Arial";
                    TOTALIN.TextFont.Size = 7;
                    TOTALIN.TextFont.CharSet = 162;
                    TOTALIN.Value = @"{#TOTALIN#}";

                    TOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 235, 9, false);
                    TOTALOUT.Name = "TOTALOUT";
                    TOTALOUT.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUT.TextFormat = @"General Number";
                    TOTALOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUT.TextFont.Name = "Arial";
                    TOTALOUT.TextFont.Size = 7;
                    TOTALOUT.TextFont.CharSet = 162;
                    TOTALOUT.Value = @"{#TOTALOUT#}";

                    TOTALINHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 0, 271, 9, false);
                    TOTALINHELD.Name = "TOTALINHELD";
                    TOTALINHELD.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALINHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINHELD.TextFormat = @"General Number";
                    TOTALINHELD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALINHELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALINHELD.TextFont.Name = "Arial";
                    TOTALINHELD.TextFont.Size = 7;
                    TOTALINHELD.TextFont.CharSet = 162;
                    TOTALINHELD.Value = @"{#TOTALINHELD#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 199, 9, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"General Number";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.Size = 7;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"{#TOTAL#}";

                    PTERM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 1, 324, 10, false);
                    PTERM.Name = "PTERM";
                    PTERM.Visible = EvetHayirEnum.ehHayir;
                    PTERM.DrawStyle = DrawStyleConstants.vbSolid;
                    PTERM.FieldType = ReportFieldTypeEnum.ftVariable;
                    PTERM.TextFormat = @"#,###";
                    PTERM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PTERM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PTERM.TextFont.Name = "Arial";
                    PTERM.TextFont.Size = 8;
                    PTERM.TextFont.CharSet = 162;
                    PTERM.Value = @"";

                    TOTALINPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 181, 9, false);
                    TOTALINPRICE.Name = "TOTALINPRICE";
                    TOTALINPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALINPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINPRICE.TextFormat = @"Currency";
                    TOTALINPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALINPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALINPRICE.TextFont.Name = "Arial";
                    TOTALINPRICE.TextFont.Size = 7;
                    TOTALINPRICE.TextFont.CharSet = 162;
                    TOTALINPRICE.Value = @"{#TOTALINPRICE#}";

                    TOTALOUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 0, 253, 9, false);
                    TOTALOUTPRICE.Name = "TOTALOUTPRICE";
                    TOTALOUTPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALOUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUTPRICE.TextFormat = @"Currency";
                    TOTALOUTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUTPRICE.TextFont.Name = "Arial";
                    TOTALOUTPRICE.TextFont.Size = 7;
                    TOTALOUTPRICE.TextFont.CharSet = 162;
                    TOTALOUTPRICE.Value = @"{#TOTALOUTPRICE#}";

                    OLDTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 127, 9, false);
                    OLDTOTAL.Name = "OLDTOTAL";
                    OLDTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDTOTAL.TextFormat = @"General Number";
                    OLDTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDTOTAL.TextFont.Name = "Arial";
                    OLDTOTAL.TextFont.Size = 7;
                    OLDTOTAL.TextFont.CharSet = 162;
                    OLDTOTAL.Value = @"{#YEARCENSUS#}";

                    STOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 327, 1, 345, 10, false);
                    STOCKCARD.Name = "STOCKCARD";
                    STOCKCARD.Visible = EvetHayirEnum.ehHayir;
                    STOCKCARD.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARD.TextFormat = @"#,###";
                    STOCKCARD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STOCKCARD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARD.TextFont.Name = "Arial";
                    STOCKCARD.TextFont.Size = 8;
                    STOCKCARD.TextFont.CharSet = 162;
                    STOCKCARD.Value = @"{#STOCKCARD#}";

                    OLDTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 145, 9, false);
                    OLDTOTALPRICE.Name = "OLDTOTALPRICE";
                    OLDTOTALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDTOTALPRICE.TextFormat = @"Currency";
                    OLDTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDTOTALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDTOTALPRICE.TextFont.Name = "Arial";
                    OLDTOTALPRICE.TextFont.Size = 7;
                    OLDTOTALPRICE.TextFont.CharSet = 162;
                    OLDTOTALPRICE.Value = @"{#YEARCENSUSPRICE#}";

                    OLDUNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 349, 1, 367, 10, false);
                    OLDUNITPRICE.Name = "OLDUNITPRICE";
                    OLDUNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    OLDUNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDUNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDUNITPRICE.TextFormat = @"#,###";
                    OLDUNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDUNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDUNITPRICE.TextFont.Name = "Arial";
                    OLDUNITPRICE.TextFont.Size = 8;
                    OLDUNITPRICE.TextFont.CharSet = 162;
                    OLDUNITPRICE.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 371, 1, 389, 10, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,###";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 217, 9, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 7;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{#PRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 0, 287, 9, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"Currency";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.Size = 7;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    SUBGROUPCOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 391, 3, 416, 8, false);
                    SUBGROUPCOUNT1.Name = "SUBGROUPCOUNT1";
                    SUBGROUPCOUNT1.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT1.Value = @"1";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetCensusScheduleReportQuery_Class dataset_GetCensusScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetCensusScheduleReportQuery_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.NATOStockNO) : "");
                    NEWORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Neworderno) : "");
                    MATERIALNAME.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Materialname) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.DistributionType) : "");
                    TOTALIN.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalin) : "");
                    TOTALOUT.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalout) : "");
                    TOTALINHELD.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalinheld) : "");
                    TOTAL.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Total) : "");
                    PTERM.CalcValue = @"";
                    TOTALINPRICE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalinprice) : "");
                    TOTALOUTPRICE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totaloutprice) : "");
                    OLDTOTAL.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Yearcensus) : "");
                    STOCKCARD.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.StockCard) : "");
                    OLDTOTALPRICE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Yearcensusprice) : "");
                    OLDUNITPRICE.CalcValue = @"";
                    UNITPRICE.CalcValue = @"";
                    TOTALPRICE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Price) : "");
                    PRICE.CalcValue = @"";
                    SUBGROUPCOUNT1.CalcValue = @"1";
                    return new TTReportObject[] { NATOSTOCKNO,NEWORDERNO,MATERIALNAME,DISTRIBUTIONTYPE,TOTALIN,TOTALOUT,TOTALINHELD,TOTAL,PTERM,TOTALINPRICE,TOTALOUTPRICE,OLDTOTAL,STOCKCARD,OLDTOTALPRICE,OLDUNITPRICE,UNITPRICE,TOTALPRICE,PRICE,SUBGROUPCOUNT1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            string termID = ((TasinirMalHesapCetveli)ParentReport).RuntimeParameters.TERMID.ToString();
            //            TTObjectContext ctx = new TTObjectContext(true);
            //            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            //            double oldUnitPrice = 0;
            //            double unitPrice = 0;
            //            double oldTotalPrice = 0 ;
            double totalPrice= Convert.ToDouble (TOTALPRICE.CalcValue) ;
            double totalOutPrice = Convert.ToDouble(TOTALOUTPRICE.CalcValue);
            double price = totalPrice - totalOutPrice;
            //            double price = 0;
            //            if (accountingTerm != null)
            //            {
            //                AccountingTerm pTerm = accountingTerm.Accountancy.GetPreviousAccountingTerm(((DateTime)accountingTerm.StartDate).AddDays(- 1));
            //                if (pTerm != null)
            //                {
            //                    PTERM.CalcValue = pTerm.ObjectID.ToString();
//
            //                    IList pDetails = ctx.QueryObjects("STOCKCENSUSDETAIL","STOCKCARD =" + ConnectionManager.GuidToString(new Guid(STOCKCARD.CalcValue.ToString())) + " AND ACCOUNTINGTERM =" + ConnectionManager.GuidToString(pTerm.ObjectID));
            //                    if(pDetails.Count > 0)
            //                    {
            //                        double pTotalInPrice = 0;
            //                        double pTotalIn = 0;
            //                        foreach(StockCensusDetail prevDetail in pDetails)
            //                        {
            //                            pTotalInPrice = pTotalInPrice + (double)prevDetail.TotalInPrice;
            //                            pTotalIn = pTotalIn + (double)prevDetail.TotalIn ;
            //                        }
//
            //                        if(pTotalIn >0 && pTotalInPrice >0)
            //                        {
            //                            oldUnitPrice =  pTotalInPrice  / pTotalIn;
            //                        }
            //                    }
            //                }
            //                IList nDetails = ctx.QueryObjects("STOCKCENSUSDETAIL","STOCKCARD =" + ConnectionManager.GuidToString(new Guid(STOCKCARD.CalcValue.ToString())) + " AND ACCOUNTINGTERM =" + ConnectionManager.GuidToString(accountingTerm.ObjectID));
//
            //                if (nDetails.Count > 0)
            //                {
            //                    double nTotalInPrice = 0;
            //                    double nTotalIn = 0;
            //                    double nYearCensus = 0;
            //                    double nTotalInHeld = 0;
            //                    foreach(StockCensusDetail newDetail in nDetails)
            //                    {
            //                        nTotalInPrice = nTotalInPrice +(double)newDetail.TotalInPrice;
            //                        nTotalIn = nTotalIn + (double)newDetail.TotalIn ;
            //                        nYearCensus = nYearCensus + (double)newDetail.YearCensus;
            //                        nTotalInHeld = nTotalInHeld + (double)newDetail.TotalInHeld ;
            //                    }
//
            //                    if (nTotalInPrice > 0 && nTotalInPrice > 0)
            //                    {
            //                        unitPrice = nTotalInPrice / nTotalIn;
            //                    }
            //                    oldTotalPrice = oldUnitPrice * nYearCensus ;
//
            //                    if(unitPrice != 0)
            //                    {
            //                        totalPrice = unitPrice * (nTotalIn + nYearCensus) ;
            //                        price = unitPrice * nTotalInHeld;
            //                    }
            //                    else
            //                    {
            //                        totalPrice = oldUnitPrice * (nTotalIn + nYearCensus) ;
            //                        price = oldUnitPrice * nTotalInHeld;
            //                    }
            //                }
            //            }
            //            OLDTOTALPRICE.CalcValue = oldTotalPrice.ToString();
            //            TOTALPRICE.CalcValue = totalPrice.ToString() ;
            PRICE.CalcValue = price.ToString();
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

        public TasinirMalHesapCetveli()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Devri Yapılan Depoyu Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Devri Yapılan Dönemi Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("CARDDRAWERID", "00000000-0000-0000-0000-000000000000", "Devri Yapılan Masayı Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("CARDDRAWERID"))
                _runtimeParameters.CARDDRAWERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CARDDRAWERID"]);
            Name = "TASINIRMALHESAPCETVELI";
            Caption = "Taşınır Mal Yönetim Hesap Cetveli (EK-106)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 5;
            UserMarginTop = 15;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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