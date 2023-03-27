
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
    /// Stok Devir Belge Dökümleri (Mal Muhasebe Çizelgesi)
    /// </summary>
    public partial class Census_InventoryAccount : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string TRANSACTIONTYPE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("");
            public string CARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string MAINSTORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string PREVIOUSTERM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Census_InventoryAccount MyParentReport
            {
                get { return (Census_InventoryAccount)ParentReport; }
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
            public TTReportField AdditionNO { get {return Header().AdditionNO;} }
            public TTReportField AccountingTerm { get {return Header().AccountingTerm;} }
            public TTReportField AccountYear { get {return Header().AccountYear;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField PAGENUMBER1 { get {return Footer().PAGENUMBER1;} }
            public TTReportField NewField1111121 { get {return Footer().NewField1111121;} }
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
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField AdditionNO;
                public TTReportField AccountingTerm;
                public TTReportField AccountYear;
                public TTReportField ENDDATE;
                public TTReportField BIRLIK;
                public TTReportField SAYMANLIK; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 21, 256, 32, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"";

                    AdditionNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 337, 7, 362, 12, false);
                    AdditionNO.Name = "AdditionNO";
                    AdditionNO.Visible = EvetHayirEnum.ehHayir;
                    AdditionNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO.TextFont.Name = "Arial";
                    AdditionNO.TextFont.Bold = true;
                    AdditionNO.TextFont.CharSet = 162;
                    AdditionNO.Value = @"EK-88";

                    AccountingTerm = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 5, false);
                    AccountingTerm.Name = "AccountingTerm";
                    AccountingTerm.Visible = EvetHayirEnum.ehHayir;
                    AccountingTerm.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountingTerm.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountingTerm.ObjectDefName = "AccountingTerm";
                    AccountingTerm.DataMember = "STARTDATE";
                    AccountingTerm.Value = @"{@TERMID@}";

                    AccountYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 5, 328, 10, false);
                    AccountYear.Name = "AccountYear";
                    AccountYear.Visible = EvetHayirEnum.ehHayir;
                    AccountYear.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountYear.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 12, 390, 17, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.ObjectDefName = "AccountingTerm";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@TERMID@}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 256, 11, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIK.TextFont.Name = "Arial";
                    BIRLIK.TextFont.Size = 11;
                    BIRLIK.TextFont.Bold = true;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 256, 19, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.TextFont.Name = "Arial";
                    SAYMANLIK.TextFont.Size = 11;
                    SAYMANLIK.TextFont.Bold = true;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = @"";
                    AdditionNO.CalcValue = AdditionNO.Value;
                    AccountingTerm.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    AccountingTerm.PostFieldValueCalculation();
                    AccountYear.CalcValue = @"";
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    BIRLIK.CalcValue = @"";
                    SAYMANLIK.CalcValue = @"";
                    return new TTReportObject[] { REPORTNAME,AdditionNO,AccountingTerm,AccountYear,ENDDATE,BIRLIK,SAYMANLIK};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string termID = ((Census_InventoryAccount)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            ResCardDrawer cardDrawer = (ResCardDrawer)ctx.GetObject(new Guid(((Census_InventoryAccount)ParentReport).RuntimeParameters.CARDDRAWER), typeof(ResCardDrawer).Name);
            REPORTNAME.CalcValue = cardDrawer.Name + " " + Convert.ToDateTime(term.EndDate).Year.ToString() + " YILI MAL MUHASEBE ÇİZELGESİ";
            SAYMANLIK.CalcValue = term.Accountancy.Name;
            BIRLIK.CalcValue = term.Accountancy.AccountancyMilitaryUnit.Name;
            AccountingTerm previousTerm = term.Accountancy.GetPreviousAccountingTerm(((DateTime)term.StartDate).AddDays(-1));
            ((Census_InventoryAccount)ParentReport).RuntimeParameters.PREVIOUSTERM = previousTerm.ObjectID.ToString();
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                
                public TTReportField PAGENUMBER1;
                public TTReportField NewField1111121; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 149, 6, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1.TextFont.Name = "Arial";
                    PAGENUMBER1.TextFont.Size = 9;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"{@pagenumber@}";

                    NewField1111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 143, 6, false);
                    NewField1111121.Name = "NewField1111121";
                    NewField1111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111121.TextFont.Name = "Arial";
                    NewField1111121.TextFont.Size = 9;
                    NewField1111121.TextFont.Bold = true;
                    NewField1111121.TextFont.CharSet = 162;
                    NewField1111121.Value = @"Sayfa";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER1.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField1111121.CalcValue = NewField1111121.Value;
                    return new TTReportObject[] { PAGENUMBER1,NewField1111121};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public Census_InventoryAccount MyParentReport
            {
                get { return (Census_InventoryAccount)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField TEFTIS { get {return Footer().TEFTIS;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField PAGECOUNT { get {return Footer().PAGECOUNT;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
            public TTReportField ACCOUNTANCYNAME { get {return Footer().ACCOUNTANCYNAME;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField SUBGROUPCOUNTTEXT { get {return Footer().SUBGROUPCOUNTTEXT;} }
            public TTReportField NEWMATERIALCENSUS { get {return Footer().NEWMATERIALCENSUS;} }
            public TTReportField NEWZEROCENSUS { get {return Footer().NEWZEROCENSUS;} }
            public TTReportField OLDMATERIALCENSUS { get {return Footer().OLDMATERIALCENSUS;} }
            public TTReportField OLDZEROCENSUS { get {return Footer().OLDZEROCENSUS;} }
            public TTReportField Eskı_Mal_Devirli { get {return Footer().Eskı_Mal_Devirli;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField Eskı_Mal_Devirli1 { get {return Footer().Eskı_Mal_Devirli1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField Eskı_Mal_Devirli2 { get {return Footer().Eskı_Mal_Devirli2;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField Eskı_Mal_Devirli3 { get {return Footer().Eskı_Mal_Devirli3;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField SAYMAN1 { get {return Footer().SAYMAN1;} }
            public TTReportField HESAPSORUMLUSU1 { get {return Footer().HESAPSORUMLUSU1;} }
            public TTReportField TKM1 { get {return Footer().TKM1;} }
            public TTReportField BK { get {return Footer().BK;} }
            public TTReportField NewField1111211 { get {return Footer().NewField1111211;} }
            public TTReportField NewField11121111 { get {return Footer().NewField11121111;} }
            public TTReportField NewField111112111 { get {return Footer().NewField111112111;} }
            public TTReportField TEXT11234561 { get {return Footer().TEXT11234561;} }
            public TTReportField NewField1111211111 { get {return Footer().NewField1111211111;} }
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
                list[0] = new TTReportNqlData<StockCensus.GetStockCensus_Class>("GetStockCensus", StockCensus.GetStockCensus((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MAINSTORE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER)));
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
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField TEFTIS;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField PAGECOUNT;
                public TTReportField AMOUNTTEXT;
                public TTReportField ACCOUNTANCYNAME;
                public TTReportField COUNTTEXT;
                public TTReportField SUBGROUPCOUNTTEXT;
                public TTReportField NEWMATERIALCENSUS;
                public TTReportField NEWZEROCENSUS;
                public TTReportField OLDMATERIALCENSUS;
                public TTReportField OLDZEROCENSUS;
                public TTReportField Eskı_Mal_Devirli;
                public TTReportField NewField1;
                public TTReportField Eskı_Mal_Devirli1;
                public TTReportField NewField11;
                public TTReportField Eskı_Mal_Devirli2;
                public TTReportField NewField12;
                public TTReportField Eskı_Mal_Devirli3;
                public TTReportField NewField13;
                public TTReportField SAYMAN1;
                public TTReportField HESAPSORUMLUSU1;
                public TTReportField TKM1;
                public TTReportField BK;
                public TTReportField NewField1111211;
                public TTReportField NewField11121111;
                public TTReportField NewField111112111;
                public TTReportField TEXT11234561;
                public TTReportField NewField1111211111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 55;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 22, 394, 27, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.Visible = EvetHayirEnum.ehHayir;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    TEFTIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 18, 319, 23, false);
                    TEFTIS.Name = "TEFTIS";
                    TEFTIS.Visible = EvetHayirEnum.ehHayir;
                    TEFTIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEFTIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEFTIS.MultiLine = EvetHayirEnum.ehEvet;
                    TEFTIS.WordBreak = EvetHayirEnum.ehEvet;
                    TEFTIS.TextFont.Name = "Arial";
                    TEFTIS.TextFont.CharSet = 162;
                    TEFTIS.Value = @"";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 327, 1, 352, 6, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT.Value = @"{@subgroupcount@}";

                    PAGECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 327, 6, 352, 11, false);
                    PAGECOUNT.Name = "PAGECOUNT";
                    PAGECOUNT.Visible = EvetHayirEnum.ehHayir;
                    PAGECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGECOUNT.Value = @"{@pagecount@}";

                    AMOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 1, 327, 6, false);
                    AMOUNTTEXT.Name = "AMOUNTTEXT";
                    AMOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AMOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    AMOUNTTEXT.Value = @"";

                    ACCOUNTANCYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 6, 327, 11, false);
                    ACCOUNTANCYNAME.Name = "ACCOUNTANCYNAME";
                    ACCOUNTANCYNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNAME.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCYNAME.DataMember = "ACCOUNTANCY.NAME";
                    ACCOUNTANCYNAME.Value = @"{@TERMID@}";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 290, 7, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTTEXT.TextFont.Name = "Arial";
                    COUNTTEXT.TextFont.CharSet = 162;
                    COUNTTEXT.Value = @"";

                    SUBGROUPCOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 11, 327, 16, false);
                    SUBGROUPCOUNTTEXT.Name = "SUBGROUPCOUNTTEXT";
                    SUBGROUPCOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    SUBGROUPCOUNTTEXT.Value = @"";

                    NEWMATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 9, 185, 14, false);
                    NEWMATERIALCENSUS.Name = "NEWMATERIALCENSUS";
                    NEWMATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWMATERIALCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWMATERIALCENSUS.TextFont.Bold = true;
                    NEWMATERIALCENSUS.TextFont.CharSet = 162;
                    NEWMATERIALCENSUS.Value = @"{#NEWMATERIALCENSUS#}";

                    NEWZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 9, 236, 14, false);
                    NEWZEROCENSUS.Name = "NEWZEROCENSUS";
                    NEWZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWZEROCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWZEROCENSUS.TextFont.Bold = true;
                    NEWZEROCENSUS.TextFont.CharSet = 162;
                    NEWZEROCENSUS.Value = @"{#NEWZEROCENSUS#}";

                    OLDMATERIALCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 9, 71, 14, false);
                    OLDMATERIALCENSUS.Name = "OLDMATERIALCENSUS";
                    OLDMATERIALCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDMATERIALCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDMATERIALCENSUS.TextFont.Bold = true;
                    OLDMATERIALCENSUS.TextFont.CharSet = 162;
                    OLDMATERIALCENSUS.Value = @"{#OLDMATERIALCENSUS#}";

                    OLDZEROCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 9, 122, 14, false);
                    OLDZEROCENSUS.Name = "OLDZEROCENSUS";
                    OLDZEROCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDZEROCENSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDZEROCENSUS.TextFont.Bold = true;
                    OLDZEROCENSUS.TextFont.CharSet = 162;
                    OLDZEROCENSUS.Value = @"{#OLDZEROCENSUS#}";

                    Eskı_Mal_Devirli = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 9, 43, 14, false);
                    Eskı_Mal_Devirli.Name = "Eskı_Mal_Devirli";
                    Eskı_Mal_Devirli.TextFont.Bold = true;
                    Eskı_Mal_Devirli.TextFont.CharSet = 162;
                    Eskı_Mal_Devirli.Value = @"Eski Mal Devirli";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 9, 46, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 0;
                    NewField1.Value = @":";

                    Eskı_Mal_Devirli1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 9, 94, 14, false);
                    Eskı_Mal_Devirli1.Name = "Eskı_Mal_Devirli1";
                    Eskı_Mal_Devirli1.TextFont.Bold = true;
                    Eskı_Mal_Devirli1.TextFont.CharSet = 162;
                    Eskı_Mal_Devirli1.Value = @"Eski Sıfır Devirli";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 9, 97, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 0;
                    NewField11.Value = @":";

                    Eskı_Mal_Devirli2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 9, 157, 14, false);
                    Eskı_Mal_Devirli2.Name = "Eskı_Mal_Devirli2";
                    Eskı_Mal_Devirli2.TextFont.Bold = true;
                    Eskı_Mal_Devirli2.TextFont.CharSet = 162;
                    Eskı_Mal_Devirli2.Value = @"Yeni Mal Devirli";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 9, 160, 14, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 0;
                    NewField12.Value = @":";

                    Eskı_Mal_Devirli3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 9, 208, 14, false);
                    Eskı_Mal_Devirli3.Name = "Eskı_Mal_Devirli3";
                    Eskı_Mal_Devirli3.TextFont.Bold = true;
                    Eskı_Mal_Devirli3.TextFont.CharSet = 162;
                    Eskı_Mal_Devirli3.Value = @"Yeni Sıfır Devirli";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 9, 211, 14, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 0;
                    NewField13.Value = @":";

                    SAYMAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 21, 77, 37, false);
                    SAYMAN1.Name = "SAYMAN1";
                    SAYMAN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMAN1.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMAN1.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMAN1.Value = @"";

                    HESAPSORUMLUSU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 21, 220, 37, false);
                    HESAPSORUMLUSU1.Name = "HESAPSORUMLUSU1";
                    HESAPSORUMLUSU1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HESAPSORUMLUSU1.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU1.WordBreak = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU1.Value = @"";

                    TKM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 21, 173, 37, false);
                    TKM1.Name = "TKM1";
                    TKM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKM1.MultiLine = EvetHayirEnum.ehEvet;
                    TKM1.WordBreak = EvetHayirEnum.ehEvet;
                    TKM1.Value = @"";

                    BK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 21, 126, 37, false);
                    BK.Name = "BK";
                    BK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BK.MultiLine = EvetHayirEnum.ehEvet;
                    BK.WordBreak = EvetHayirEnum.ehEvet;
                    BK.Value = @"";

                    NewField1111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 37, 60, 47, false);
                    NewField1111211.Name = "NewField1111211";
                    NewField1111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111211.TextFont.Name = "Arial";
                    NewField1111211.TextFont.Bold = true;
                    NewField1111211.TextFont.CharSet = 162;
                    NewField1111211.Value = @"Sayman";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 37, 212, 46, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121111.TextFont.Name = "Arial";
                    NewField11121111.TextFont.Bold = true;
                    NewField11121111.TextFont.CharSet = 162;
                    NewField11121111.Value = @"Hesap Sorumlusu";

                    NewField111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 37, 164, 47, false);
                    NewField111112111.Name = "NewField111112111";
                    NewField111112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112111.TextFont.Name = "Arial";
                    NewField111112111.TextFont.Bold = true;
                    NewField111112111.TextFont.CharSet = 162;
                    NewField111112111.Value = @"Mal Sorumlusu";

                    TEXT11234561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 373, 9, 407, 46, false);
                    TEXT11234561.Name = "TEXT11234561";
                    TEXT11234561.Visible = EvetHayirEnum.ehHayir;
                    TEXT11234561.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT11234561.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT11234561.TextFont.Bold = true;
                    TEXT11234561.TextFont.CharSet = 162;
                    TEXT11234561.Value = @"İmza ve Mühür
Adı ve Soyadı
Sınıfı ve Rütbesi
Görevi		
";

                    NewField1111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 37, 125, 47, false);
                    NewField1111211111.Name = "NewField1111211111";
                    NewField1111211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111211111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111211111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111211111.TextFont.Name = "Arial";
                    NewField1111211111.TextFont.Bold = true;
                    NewField1111211111.TextFont.CharSet = 162;
                    NewField1111211111.Value = @"Birlik XXXXXXı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetStockCensus_Class dataset_GetStockCensus = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetStockCensus_Class>(0);
                    TOTAL.CalcValue = @"";
                    TEFTIS.CalcValue = @"";
                    SUBGROUPCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    PAGECOUNT.CalcValue = ParentReport.ReportTotalPageCount;
                    AMOUNTTEXT.CalcValue = @"";
                    ACCOUNTANCYNAME.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ACCOUNTANCYNAME.PostFieldValueCalculation();
                    COUNTTEXT.CalcValue = @"";
                    SUBGROUPCOUNTTEXT.CalcValue = @"";
                    NEWMATERIALCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.NewMaterialCensus) : "");
                    NEWZEROCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.NewZeroCensus) : "");
                    OLDMATERIALCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.OldMaterialCensus) : "");
                    OLDZEROCENSUS.CalcValue = (dataset_GetStockCensus != null ? Globals.ToStringCore(dataset_GetStockCensus.OldZeroCensus) : "");
                    Eskı_Mal_Devirli.CalcValue = Eskı_Mal_Devirli.Value;
                    NewField1.CalcValue = NewField1.Value;
                    Eskı_Mal_Devirli1.CalcValue = Eskı_Mal_Devirli1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    Eskı_Mal_Devirli2.CalcValue = Eskı_Mal_Devirli2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    Eskı_Mal_Devirli3.CalcValue = Eskı_Mal_Devirli3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    SAYMAN1.CalcValue = @"";
                    HESAPSORUMLUSU1.CalcValue = @"";
                    TKM1.CalcValue = @"";
                    BK.CalcValue = @"";
                    NewField1111211.CalcValue = NewField1111211.Value;
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField111112111.CalcValue = NewField111112111.Value;
                    TEXT11234561.CalcValue = TEXT11234561.Value;
                    NewField1111211111.CalcValue = NewField1111211111.Value;
                    return new TTReportObject[] { TOTAL,TEFTIS,SUBGROUPCOUNT,PAGECOUNT,AMOUNTTEXT,ACCOUNTANCYNAME,COUNTTEXT,SUBGROUPCOUNTTEXT,NEWMATERIALCENSUS,NEWZEROCENSUS,OLDMATERIALCENSUS,OLDZEROCENSUS,Eskı_Mal_Devirli,NewField1,Eskı_Mal_Devirli1,NewField11,Eskı_Mal_Devirli2,NewField12,Eskı_Mal_Devirli3,NewField13,SAYMAN1,HESAPSORUMLUSU1,TKM1,BK,NewField1111211,NewField11121111,NewField111112111,TEXT11234561,NewField1111211111};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    //AMOUNTTEXT.CalcValue = PARTBGroup.totalAmount.ToString();
            //SUBGROUPCOUNTTEXT.CalcValue = SUBGROUPCOUNT.CalcValue;
            //PARTBGroup.totalAmount = 0;
            
            string termID = ((Census_InventoryAccount)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            //            if(term.EndDate != null)
            //            {
            //                TEFTIS.CalcValue = "1.Yukarıda stok numarası ve cinsi yazılı toplam " + SUBGROUPCOUNT.FormattedValue
            //                    + " adet ÇİFT SIFIRLI stok kayıt kartları " + ACCOUNTANCYNAME.FormattedValue
            //                    + " saymanlığının " + Convert.ToDateTime(term.EndDate).Year.ToString() + " bütçe yılı teftişinde"
            //                    + " saymandan alınarak teftiş sandığına konmuştur."
            //                    + "\r\n2.Envanter kayıtları bilgisayarda tutulan saymanlıkların Ana Stok Kütüğünden atılan ÇİFT SIFIRLI"
            //                    + " kayıtlarına ilişkin sandığa herhangi bir kart koyulmamaktadır.";
            //            }
            COUNTTEXT.CalcValue = "///////////YALNIZ " + SUBGROUPCOUNT.FormattedValue + " (" + TTReportTool.Common.SpellNumber(SUBGROUPCOUNT.CalcValue.ToString()) + ") KALEMDİR///////////";





            

            IList checkStockCensusActions = ctx.QueryObjects("CHECKSTOCKCENSUSACTION","ACCOUNTINGTERM=" + ConnectionManager.GuidToString(term.ObjectID));
            if(checkStockCensusActions.Count > 0)
            {
                CheckStockCensusAction checkStockCensusAction = (CheckStockCensusAction)checkStockCensusActions[0];
                
                SAYMAN1.CalcValue =  checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.MalSaymani);
                BK.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.BirlikXXXXXXi);
                
                TKM1.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.MalSorumlusu);
                
                //                if(term.Accountancy.MainStores.Count >0 )
                //                {
                //                    if(term.Accountancy.MainStores[0].GoodsResponsible != null)
                //                        TKM1.CalcValue = term.Accountancy.MainStores[0].GoodsResponsible.Name + "/n" + term.Accountancy.MainStores[0].GoodsResponsible.Rank + " - " + term.Accountancy.MainStores[0].GoodsResponsible.MilitaryClass;
                //                }
                
                Guid oID = new Guid(MyParentReport.RuntimeParameters.CARDDRAWER);
                HESAPSORUMLUSU1.CalcValue = checkStockCensusAction.SignOfAccontingterm(oID);
            }
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static int totalAmount = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public Census_InventoryAccount MyParentReport
            {
                get { return (Census_InventoryAccount)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NSN { get {return Header().NSN;} }
            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
            public TTReportField BIRIM { get {return Header().BIRIM;} }
            public TTReportField OLDCENSUSAMOUNT { get {return Header().OLDCENSUSAMOUNT;} }
            public TTReportField OLDNEWCENSUSAMOUNT { get {return Header().OLDNEWCENSUSAMOUNT;} }
            public TTReportField OLDCENSUSORDERNO { get {return Header().OLDCENSUSORDERNO;} }
            public TTReportField NEWCENSUSORDERNO { get {return Header().NEWCENSUSORDERNO;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField121112 { get {return Header().NewField121112;} }
            public TTReportField NewField1111112 { get {return Header().NewField1111112;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField1111113 { get {return Header().NewField1111113;} }
            public TTReportField STOCKCARD { get {return Header().STOCKCARD;} }
            public TTReportField STOCKOBJECTID { get {return Header().STOCKOBJECTID;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112121 { get {return Header().NewField112121;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField121111 { get {return Header().NewField121111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField CENSUSTOTALIN { get {return Header().CENSUSTOTALIN;} }
            public TTReportField NewField111114 { get {return Header().NewField111114;} }
            public TTReportField CENSUSTOTALOUT { get {return Header().CENSUSTOTALOUT;} }
            public TTReportField NewField111115 { get {return Header().NewField111115;} }
            public TTReportField NewField1211111 { get {return Header().NewField1211111;} }
            public TTReportField NewField1211112 { get {return Header().NewField1211112;} }
            public TTReportField NewField1211113 { get {return Header().NewField1211113;} }
            public TTReportField OLDSTOCKCARDSTATUS { get {return Header().OLDSTOCKCARDSTATUS;} }
            public TTReportField NEWCENSUSAMOUNT { get {return Footer().NEWCENSUSAMOUNT;} }
            public TTReportField NewField12111111 { get {return Footer().NewField12111111;} }
            public TTReportField NewField1113 { get {return Footer().NewField1113;} }
            public TTReportField NewField12111 { get {return Footer().NewField12111;} }
            public TTReportField NewField1211114 { get {return Footer().NewField1211114;} }
            public TTReportField NewField1211121 { get {return Footer().NewField1211121;} }
            public TTReportField NewField12111112 { get {return Footer().NewField12111112;} }
            public TTReportField NewField11111121 { get {return Footer().NewField11111121;} }
            public TTReportField NewField12111121 { get {return Footer().NewField12111121;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StockCensus.GetCensusScheduleReportQuery_Class>("GetCensusScheduleReportQuery", StockCensus.GetCensusScheduleReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MAINSTORE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                
                public TTReportField NSN;
                public TTReportField MATERIAL;
                public TTReportField BIRIM;
                public TTReportField OLDCENSUSAMOUNT;
                public TTReportField OLDNEWCENSUSAMOUNT;
                public TTReportField OLDCENSUSORDERNO;
                public TTReportField NEWCENSUSORDERNO;
                public TTReportField NewField111;
                public TTReportField NewField1112;
                public TTReportField NewField111112;
                public TTReportField NewField121112;
                public TTReportField NewField1111112;
                public TTReportField NewField111113;
                public TTReportField NewField1111113;
                public TTReportField STOCKCARD;
                public TTReportField STOCKOBJECTID;
                public TTReportField NewField11121;
                public TTReportField NewField112121;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField121111;
                public TTReportField NewField1111111;
                public TTReportField CENSUSTOTALIN;
                public TTReportField NewField111114;
                public TTReportField CENSUSTOTALOUT;
                public TTReportField NewField111115;
                public TTReportField NewField1211111;
                public TTReportField NewField1211112;
                public TTReportField NewField1211113;
                public TTReportField OLDSTOCKCARDSTATUS; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 6, 60, 11, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 8;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NATOSTOCKNO#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 6, 176, 11, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 8;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIALNAME#}";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 6, 188, 11, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM.ObjectDefName = "DistributionTypeDefinition";
                    BIRIM.DataMember = "QREF";
                    BIRIM.TextFont.Name = "Arial";
                    BIRIM.TextFont.Size = 9;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#DAGITIM#}";

                    OLDCENSUSAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 6, 205, 11, false);
                    OLDCENSUSAMOUNT.Name = "OLDCENSUSAMOUNT";
                    OLDCENSUSAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDCENSUSAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDCENSUSAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDCENSUSAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDCENSUSAMOUNT.TextFont.Name = "Arial";
                    OLDCENSUSAMOUNT.TextFont.Size = 9;
                    OLDCENSUSAMOUNT.TextFont.CharSet = 162;
                    OLDCENSUSAMOUNT.Value = @"{#YEARCENSUS#}";

                    OLDNEWCENSUSAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 6, 256, 11, false);
                    OLDNEWCENSUSAMOUNT.Name = "OLDNEWCENSUSAMOUNT";
                    OLDNEWCENSUSAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDNEWCENSUSAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDNEWCENSUSAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDNEWCENSUSAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDNEWCENSUSAMOUNT.TextFont.Name = "Arial";
                    OLDNEWCENSUSAMOUNT.TextFont.Size = 9;
                    OLDNEWCENSUSAMOUNT.TextFont.CharSet = 162;
                    OLDNEWCENSUSAMOUNT.Value = @"{#TOTALINHELD#}";

                    OLDCENSUSORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 6, 32, 11, false);
                    OLDCENSUSORDERNO.Name = "OLDCENSUSORDERNO";
                    OLDCENSUSORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDCENSUSORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDCENSUSORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDCENSUSORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDCENSUSORDERNO.TextFont.Name = "Arial";
                    OLDCENSUSORDERNO.TextFont.Size = 9;
                    OLDCENSUSORDERNO.TextFont.CharSet = 162;
                    OLDCENSUSORDERNO.Value = @"{#OLDORDERNO#}";

                    NEWCENSUSORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 20, 11, false);
                    NEWCENSUSORDERNO.Name = "NEWCENSUSORDERNO";
                    NEWCENSUSORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWCENSUSORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWCENSUSORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWCENSUSORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWCENSUSORDERNO.TextFont.Name = "Arial";
                    NEWCENSUSORDERNO.TextFont.Size = 9;
                    NEWCENSUSORDERNO.TextFont.CharSet = 162;
                    NEWCENSUSORDERNO.Value = @"{#NEWORDERNO#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 15, 16, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Sıra";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 11, 32, 16, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 9;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"Belge Nu.";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 11, 54, 16, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112.TextFont.Name = "Arial";
                    NewField111112.TextFont.Size = 9;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"Kısa Ad";

                    NewField121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 11, 88, 16, false);
                    NewField121112.Name = "NewField121112";
                    NewField121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121112.TextFont.Name = "Arial";
                    NewField121112.TextFont.Size = 9;
                    NewField121112.TextFont.CharSet = 162;
                    NewField121112.Value = @"Dok.Nu/Eski Stok Nu.";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 11, 176, 16, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111112.TextFont.Name = "Arial";
                    NewField1111112.TextFont.Size = 9;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Açıklama";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 11, 239, 16, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111113.TextFont.Name = "Arial";
                    NewField111113.TextFont.Size = 9;
                    NewField111113.TextFont.CharSet = 162;
                    NewField111113.Value = @"";

                    NewField1111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 11, 256, 16, false);
                    NewField1111113.Name = "NewField1111113";
                    NewField1111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111113.TextFont.Name = "Arial";
                    NewField1111113.TextFont.Size = 9;
                    NewField1111113.TextFont.CharSet = 162;
                    NewField1111113.Value = @"";

                    STOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 2, 329, 7, false);
                    STOCKCARD.Name = "STOCKCARD";
                    STOCKCARD.Visible = EvetHayirEnum.ehHayir;
                    STOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARD.Value = @"{#STOCKCARD#}";

                    STOCKOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 328, 2, 353, 7, false);
                    STOCKOBJECTID.Name = "STOCKOBJECTID";
                    STOCKOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKOBJECTID.Value = @"";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 60, 6, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Size = 9;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Stok Numarası";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 1, 176, 6, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Size = 9;
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"Malzeme Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 1, 188, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Birim";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 6, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Devir";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 1, 256, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 9;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"TOPLAM";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 32, 6, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 9;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"E.DLSN";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 20, 6, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 9;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Y.DLSN";

                    CENSUSTOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 6, 222, 11, false);
                    CENSUSTOTALIN.Name = "CENSUSTOTALIN";
                    CENSUSTOTALIN.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSTOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSTOTALIN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CENSUSTOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CENSUSTOTALIN.TextFont.Name = "Arial";
                    CENSUSTOTALIN.TextFont.Size = 9;
                    CENSUSTOTALIN.TextFont.CharSet = 162;
                    CENSUSTOTALIN.Value = @"{#TOTALIN#}";

                    NewField111114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 1, 222, 6, false);
                    NewField111114.Name = "NewField111114";
                    NewField111114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111114.TextFont.Name = "Arial";
                    NewField111114.TextFont.Size = 9;
                    NewField111114.TextFont.Bold = true;
                    NewField111114.TextFont.CharSet = 162;
                    NewField111114.Value = @"Giren";

                    CENSUSTOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 6, 239, 11, false);
                    CENSUSTOTALOUT.Name = "CENSUSTOTALOUT";
                    CENSUSTOTALOUT.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSTOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSTOTALOUT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CENSUSTOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CENSUSTOTALOUT.TextFont.Name = "Arial";
                    CENSUSTOTALOUT.TextFont.Size = 9;
                    CENSUSTOTALOUT.TextFont.CharSet = 162;
                    CENSUSTOTALOUT.Value = @"{#TOTALOUT#}";

                    NewField111115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 239, 6, false);
                    NewField111115.Name = "NewField111115";
                    NewField111115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111115.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111115.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111115.TextFont.Name = "Arial";
                    NewField111115.TextFont.Size = 9;
                    NewField111115.TextFont.Bold = true;
                    NewField111115.TextFont.CharSet = 162;
                    NewField111115.Value = @"Çıkan";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 11, 188, 16, false);
                    NewField1211111.Name = "NewField1211111";
                    NewField1211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211111.TextFont.Name = "Arial";
                    NewField1211111.TextFont.Size = 9;
                    NewField1211111.TextFont.CharSet = 162;
                    NewField1211111.Value = @"";

                    NewField1211112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 11, 205, 16, false);
                    NewField1211112.Name = "NewField1211112";
                    NewField1211112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211112.TextFont.Name = "Arial";
                    NewField1211112.TextFont.Size = 9;
                    NewField1211112.TextFont.CharSet = 162;
                    NewField1211112.Value = @"";

                    NewField1211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 11, 222, 16, false);
                    NewField1211113.Name = "NewField1211113";
                    NewField1211113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211113.TextFont.Name = "Arial";
                    NewField1211113.TextFont.Size = 9;
                    NewField1211113.TextFont.CharSet = 162;
                    NewField1211113.Value = @"";

                    OLDSTOCKCARDSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 9, 329, 14, false);
                    OLDSTOCKCARDSTATUS.Name = "OLDSTOCKCARDSTATUS";
                    OLDSTOCKCARDSTATUS.Visible = EvetHayirEnum.ehHayir;
                    OLDSTOCKCARDSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDSTOCKCARDSTATUS.Value = @"{#OLDSTOCKCARDSTATUS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetCensusScheduleReportQuery_Class dataset_GetCensusScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetCensusScheduleReportQuery_Class>(0);
                    NSN.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.NATOStockNO) : "");
                    MATERIAL.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Materialname) : "");
                    BIRIM.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Dagitim) : "");
                    BIRIM.PostFieldValueCalculation();
                    OLDCENSUSAMOUNT.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Yearcensus) : "");
                    OLDNEWCENSUSAMOUNT.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalinheld) : "");
                    OLDCENSUSORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Oldorderno) : "");
                    NEWCENSUSORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Neworderno) : "");
                    NewField111.CalcValue = NewField111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField121112.CalcValue = NewField121112.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1111113.CalcValue = NewField1111113.Value;
                    STOCKCARD.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.StockCard) : "");
                    STOCKOBJECTID.CalcValue = @"";
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField121111.CalcValue = NewField121111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    CENSUSTOTALIN.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalin) : "");
                    NewField111114.CalcValue = NewField111114.Value;
                    CENSUSTOTALOUT.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalout) : "");
                    NewField111115.CalcValue = NewField111115.Value;
                    NewField1211111.CalcValue = NewField1211111.Value;
                    NewField1211112.CalcValue = NewField1211112.Value;
                    NewField1211113.CalcValue = NewField1211113.Value;
                    OLDSTOCKCARDSTATUS.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.OldStockCardStatus) : "");
                    return new TTReportObject[] { NSN,MATERIAL,BIRIM,OLDCENSUSAMOUNT,OLDNEWCENSUSAMOUNT,OLDCENSUSORDERNO,NEWCENSUSORDERNO,NewField111,NewField1112,NewField111112,NewField121112,NewField1111112,NewField111113,NewField1111113,STOCKCARD,STOCKOBJECTID,NewField11121,NewField112121,NewField1111,NewField11111,NewField111111,NewField121111,NewField1111111,CENSUSTOTALIN,NewField111114,CENSUSTOTALOUT,NewField111115,NewField1211111,NewField1211112,NewField1211113,OLDSTOCKCARDSTATUS};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    //                    TTObjectContext context = new TTObjectContext(true);
            //            Guid termGuid = new Guid(((Census_InventoryAccount)ParentReport).RuntimeParameters.TERMID);
            //            //Guid previousTermGuid = new Guid(((Census_InventoryAccount)ParentReport).RuntimeParameters.PREVIOUSTERM);
            //            //AccountingTerm term = (AccountingTerm)context.GetObject(termGuid, typeof(AccountingTerm).Name);
            //            //AccountingTerm previousTerm = (AccountingTerm)context.GetObject(previousTermGuid, typeof(AccountingTerm).Name);
            //            Stock stock = (Stock)context.GetObject(new Guid(STOCKOBJECTID.CalcValue), typeof(Stock).Name);
            //            //BindingList<StockCensusDetail> oldDetList = StockCensusDetail.GetCensusDetail(context, previousTermGuid, stock.ObjectID);
            //            BindingList<StockCensusDetail> newDetList = StockCensusDetail.GetCensusDetail(context, termGuid, stock.ObjectID);
            //            if( newDetList.Count == 1)
            //            {
            //                //StockCensusDetail oldDet = oldDetList[0];
            //                StockCensusDetail newDet = newDetList[0];
            //                OLDCENSUSAMOUNT.CalcValue = newDet.YearCensus.ToString();
            //                OLDCENSUSORDERNO.CalcValue = newDet.OldCardOrderNo.ToString();
            //                //NEWCENSUSAMOUNT.CalcValue = newDet.TotalInHeld.ToString();
            //                NEWCENSUSORDERNO.CalcValue = newDet.CardOrderNo.ToString();
            //                //CENSUSTOTALIN.CalcValue = newDet.TotalIn.ToString();
            //                //CENSUSTOTALOUT.CalcValue = newDet.TotalOut.ToString();
            //            }

                    if (OLDSTOCKCARDSTATUS.CalcValue == "NewCard")
                    {
                        OLDCENSUSAMOUNT.CalcValue = " - ";
                    }
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                
                public TTReportField NEWCENSUSAMOUNT;
                public TTReportField NewField12111111;
                public TTReportField NewField1113;
                public TTReportField NewField12111;
                public TTReportField NewField1211114;
                public TTReportField NewField1211121;
                public TTReportField NewField12111112;
                public TTReportField NewField11111121;
                public TTReportField NewField12111121; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NEWCENSUSAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 256, 5, false);
                    NEWCENSUSAMOUNT.Name = "NEWCENSUSAMOUNT";
                    NEWCENSUSAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWCENSUSAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWCENSUSAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWCENSUSAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWCENSUSAMOUNT.TextFont.Name = "Arial";
                    NEWCENSUSAMOUNT.TextFont.Size = 9;
                    NEWCENSUSAMOUNT.TextFont.CharSet = 162;
                    NEWCENSUSAMOUNT.Value = @"{#TOTALINHELD#}";

                    NewField12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 239, 5, false);
                    NewField12111111.Name = "NewField12111111";
                    NewField12111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111111.TextFont.Name = "Arial";
                    NewField12111111.TextFont.Size = 9;
                    NewField12111111.TextFont.CharSet = 162;
                    NewField12111111.Value = @"Gelecek Yıla Devir";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 15, 5, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Size = 9;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 32, 5, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Size = 9;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"";

                    NewField1211114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 54, 5, false);
                    NewField1211114.Name = "NewField1211114";
                    NewField1211114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211114.TextFont.Name = "Arial";
                    NewField1211114.TextFont.Size = 9;
                    NewField1211114.TextFont.CharSet = 162;
                    NewField1211114.Value = @"";

                    NewField1211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 88, 5, false);
                    NewField1211121.Name = "NewField1211121";
                    NewField1211121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211121.TextFont.Name = "Arial";
                    NewField1211121.TextFont.Size = 9;
                    NewField1211121.TextFont.CharSet = 162;
                    NewField1211121.Value = @"";

                    NewField12111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 176, 5, false);
                    NewField12111112.Name = "NewField12111112";
                    NewField12111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111112.TextFont.Name = "Arial";
                    NewField12111112.TextFont.Size = 9;
                    NewField12111112.TextFont.CharSet = 162;
                    NewField12111112.Value = @"";

                    NewField11111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 188, 5, false);
                    NewField11111121.Name = "NewField11111121";
                    NewField11111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111121.TextFont.Name = "Arial";
                    NewField11111121.TextFont.Size = 9;
                    NewField11111121.TextFont.CharSet = 162;
                    NewField11111121.Value = @"";

                    NewField12111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 205, 5, false);
                    NewField12111121.Name = "NewField12111121";
                    NewField12111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111121.TextFont.Name = "Arial";
                    NewField12111121.TextFont.Size = 9;
                    NewField12111121.TextFont.CharSet = 162;
                    NewField12111121.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetCensusScheduleReportQuery_Class dataset_GetCensusScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetCensusScheduleReportQuery_Class>(0);
                    NEWCENSUSAMOUNT.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalinheld) : "");
                    NewField12111111.CalcValue = NewField12111111.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField1211114.CalcValue = NewField1211114.Value;
                    NewField1211121.CalcValue = NewField1211121.Value;
                    NewField12111112.CalcValue = NewField12111112.Value;
                    NewField11111121.CalcValue = NewField11111121.Value;
                    NewField12111121.CalcValue = NewField12111121.Value;
                    return new TTReportObject[] { NEWCENSUSAMOUNT,NewField12111111,NewField1113,NewField12111,NewField1211114,NewField1211121,NewField12111112,NewField11111121,NewField12111121};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            Guid termGuid = new Guid(((Census_InventoryAccount)ParentReport).RuntimeParameters.TERMID);
//            Stock stock = (Stock)context.GetObject(new Guid(STOCKOBJECTID1.CalcValue), typeof(Stock).Name);
//            BindingList<StockCensusDetail> newDetList = StockCensusDetail.GetCensusDetail(context, termGuid, stock.ObjectID);
//            if( newDetList.Count == 1)
//            {
//                StockCensusDetail newDet = newDetList[0];
//                NEWCENSUSAMOUNT.CalcValue = newDet.TotalInHeld.ToString();
//            }
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public Census_InventoryAccount MyParentReport
            {
                get { return (Census_InventoryAccount)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
            public TTReportField SUBGROUPCOUNT { get {return Body().SUBGROUPCOUNT;} }
            public TTReportField REGISTRATIONNUMBER { get {return Body().REGISTRATIONNUMBER;} }
            public TTReportField SHORTDESCRIPTION { get {return Body().SHORTDESCRIPTION;} }
            public TTReportField NewField1211121 { get {return Body().NewField1211121;} }
            public TTReportField DESC { get {return Body().DESC;} }
            public TTReportField OUTAMOUNT { get {return Body().OUTAMOUNT;} }
            public TTReportField INAMOUNT { get {return Body().INAMOUNT;} }
            public TTReportField INOUT { get {return Body().INOUT;} }
            public TTReportField DESC1 { get {return Body().DESC1;} }
            public TTReportField DESC11 { get {return Body().DESC11;} }
            public TTReportField DESC12 { get {return Body().DESC12;} }
            public TTReportField STOCKACTION { get {return Body().STOCKACTION;} }
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
                list[0] = new TTReportNqlData<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class>("GetActionDetailsForCensus_InventoryAccountReport", StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTC.STOCKCARD.CalcValue),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MAINSTORE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
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
                public Census_InventoryAccount MyParentReport
                {
                    get { return (Census_InventoryAccount)ParentReport; }
                }
                
                public TTReportField ObjectID;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField REGISTRATIONNUMBER;
                public TTReportField SHORTDESCRIPTION;
                public TTReportField NewField1211121;
                public TTReportField DESC;
                public TTReportField OUTAMOUNT;
                public TTReportField INAMOUNT;
                public TTReportField INOUT;
                public TTReportField DESC1;
                public TTReportField DESC11;
                public TTReportField DESC12;
                public TTReportField STOCKACTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 1, 333, 6, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.Value = @"{#OBJECTID#}";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 15, 5, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBGROUPCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBGROUPCOUNT.TextFont.Name = "Arial";
                    SUBGROUPCOUNT.TextFont.Size = 9;
                    SUBGROUPCOUNT.TextFont.CharSet = 162;
                    SUBGROUPCOUNT.Value = @"{@groupcounter@}";

                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 32, 5, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.TextFont.Name = "Arial";
                    REGISTRATIONNUMBER.TextFont.Size = 9;
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"";

                    SHORTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 54, 5, false);
                    SHORTDESCRIPTION.Name = "SHORTDESCRIPTION";
                    SHORTDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    SHORTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHORTDESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SHORTDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHORTDESCRIPTION.TextFont.Name = "Arial";
                    SHORTDESCRIPTION.TextFont.Size = 9;
                    SHORTDESCRIPTION.TextFont.CharSet = 162;
                    SHORTDESCRIPTION.Value = @"";

                    NewField1211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 88, 5, false);
                    NewField1211121.Name = "NewField1211121";
                    NewField1211121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211121.TextFont.Name = "Arial";
                    NewField1211121.TextFont.Size = 9;
                    NewField1211121.TextFont.CharSet = 162;
                    NewField1211121.Value = @"";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 176, 5, false);
                    DESC.Name = "DESC";
                    DESC.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC.TextFont.Name = "Arial";
                    DESC.TextFont.Size = 9;
                    DESC.TextFont.CharSet = 162;
                    DESC.Value = @"";

                    OUTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 239, 5, false);
                    OUTAMOUNT.Name = "OUTAMOUNT";
                    OUTAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    OUTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OUTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OUTAMOUNT.TextFont.Name = "Arial";
                    OUTAMOUNT.TextFont.Size = 9;
                    OUTAMOUNT.TextFont.CharSet = 162;
                    OUTAMOUNT.Value = @"{#AMOUNT#}";

                    INAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 222, 5, false);
                    INAMOUNT.Name = "INAMOUNT";
                    INAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    INAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    INAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INAMOUNT.TextFont.Name = "Arial";
                    INAMOUNT.TextFont.Size = 9;
                    INAMOUNT.TextFont.CharSet = 162;
                    INAMOUNT.Value = @"{#AMOUNT#}";

                    INOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 334, 1, 359, 6, false);
                    INOUT.Name = "INOUT";
                    INOUT.Visible = EvetHayirEnum.ehHayir;
                    INOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INOUT.Value = @"";

                    DESC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 188, 5, false);
                    DESC1.Name = "DESC1";
                    DESC1.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC1.TextFont.Name = "Arial";
                    DESC1.TextFont.Size = 9;
                    DESC1.TextFont.CharSet = 162;
                    DESC1.Value = @"";

                    DESC11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 205, 5, false);
                    DESC11.Name = "DESC11";
                    DESC11.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC11.TextFont.Name = "Arial";
                    DESC11.TextFont.Size = 9;
                    DESC11.TextFont.CharSet = 162;
                    DESC11.Value = @"";

                    DESC12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 256, 5, false);
                    DESC12.Name = "DESC12";
                    DESC12.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC12.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC12.TextFont.Name = "Arial";
                    DESC12.TextFont.Size = 9;
                    DESC12.TextFont.CharSet = 162;
                    DESC12.Value = @"";

                    STOCKACTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 359, 1, 384, 6, false);
                    STOCKACTION.Name = "STOCKACTION";
                    STOCKACTION.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTION.Value = @"{#STOCKACTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class dataset_GetActionDetailsForCensus_InventoryAccountReport = ParentGroup.rsGroup.GetCurrentRecord<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class>(0);
                    ObjectID.CalcValue = (dataset_GetActionDetailsForCensus_InventoryAccountReport != null ? Globals.ToStringCore(dataset_GetActionDetailsForCensus_InventoryAccountReport.ObjectID) : "");
                    SUBGROUPCOUNT.CalcValue = ParentGroup.GroupCounter.ToString();
                    REGISTRATIONNUMBER.CalcValue = @"";
                    SHORTDESCRIPTION.CalcValue = @"";
                    NewField1211121.CalcValue = NewField1211121.Value;
                    DESC.CalcValue = @"";
                    OUTAMOUNT.CalcValue = (dataset_GetActionDetailsForCensus_InventoryAccountReport != null ? Globals.ToStringCore(dataset_GetActionDetailsForCensus_InventoryAccountReport.Amount) : "");
                    INAMOUNT.CalcValue = (dataset_GetActionDetailsForCensus_InventoryAccountReport != null ? Globals.ToStringCore(dataset_GetActionDetailsForCensus_InventoryAccountReport.Amount) : "");
                    INOUT.CalcValue = @"";
                    DESC1.CalcValue = @"";
                    DESC11.CalcValue = @"";
                    DESC12.CalcValue = @"";
                    STOCKACTION.CalcValue = (dataset_GetActionDetailsForCensus_InventoryAccountReport != null ? Globals.ToStringCore(dataset_GetActionDetailsForCensus_InventoryAccountReport.Stockaction) : "");
                    return new TTReportObject[] { ObjectID,SUBGROUPCOUNT,REGISTRATIONNUMBER,SHORTDESCRIPTION,NewField1211121,DESC,OUTAMOUNT,INAMOUNT,INOUT,DESC1,DESC11,DESC12,STOCKACTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            Guid storeGuid = new Guid(((Census_InventoryAccount)ParentReport).RuntimeParameters.MAINSTORE);
            StockAction stockAction = (StockAction)context.GetObject(new Guid(STOCKACTION.CalcValue), typeof(StockAction).Name);
            StockActionDetail stockActionDetail = (StockActionDetail)context.GetObject(new Guid(ObjectID.CalcValue), typeof(StockActionDetail).Name);
            StockTransaction trx = null;
            foreach (StockTransaction mtrx in stockActionDetail.StockTransactions.Select(string.Empty))
            {
                if(mtrx.Stock != null)
                {
                    if(mtrx.Stock.Store != null)
                    {
                        if(mtrx.Stock.Store.ObjectID != null)
                        {
                            if (mtrx.Stock.Store.ObjectID.Equals(storeGuid))
                            {
                                trx = mtrx;
                                break;
                            }
                        }
                    }
                }
            }
                    
                    
            SHORTDESCRIPTION.CalcValue = trx.StockTransactionDefinition.ShortDescription ;
            DESC.CalcValue = trx.StockTransactionDefinition.Description;
            if(trx.InOut != null)
            {
                if (trx.InOut == TransactionTypeEnum.In)
                {
                    INOUT.CalcValue = "In";
                }
                else if (trx.InOut == TransactionTypeEnum.Out)
                {
                    INOUT.CalcValue = "Out";
                }
            }
            
            string documentLogNo = string.Empty;
            if(stockAction.DocumentRecordLogs != null)
                foreach (DocumentRecordLog document in stockAction.DocumentRecordLogs)
                {
                    if(INOUT.CalcValue != null)
                    {
                        if (INOUT.CalcValue == "In")
                        {
                            if(document.DocumentTransactionType != null)
                                if (document.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                                {
                                    documentLogNo = document.DocumentRecordLogNumber.ToString();
                                }
                        }
                        else if (INOUT.CalcValue == "Out")
                        {
                            if(document.DocumentTransactionType != null)
                                if (document.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                                {
                                    documentLogNo = document.DocumentRecordLogNumber.ToString();
                                }
                        }
                    }
                }
            REGISTRATIONNUMBER.CalcValue = documentLogNo;
            
            if(INOUT.CalcValue == "In")
                OUTAMOUNT.CalcValue = "";
            else if(INOUT.CalcValue == "Out")
                INAMOUNT.CalcValue = "";
            else
                throw new TTUtils.TTException("Bilinmeyen hareket tipi. " + INOUT.CalcValue);
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

        public Census_InventoryAccount()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("TRANSACTIONTYPE", "", "", @"", false, false, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
            reportParameter = Parameters.Add("CARDDRAWER", "", "Masa", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
            reportParameter = Parameters.Add("MAINSTORE", "", "Ana depo", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("PREVIOUSTERM", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("TRANSACTIONTYPE"))
                _runtimeParameters.TRANSACTIONTYPE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["TRANSACTIONTYPE"]);
            if (parameters.ContainsKey("CARDDRAWER"))
                _runtimeParameters.CARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CARDDRAWER"]);
            if (parameters.ContainsKey("MAINSTORE"))
                _runtimeParameters.MAINSTORE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MAINSTORE"]);
            if (parameters.ContainsKey("PREVIOUSTERM"))
                _runtimeParameters.PREVIOUSTERM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PREVIOUSTERM"]);
            Name = "CENSUS_INVENTORYACCOUNT";
            Caption = "Stok Devir Belge Dökümleri (Mal Muhasebe Çizelgesi)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
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