
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
    /// Toplu Fatura Önyazı Raporu (Haydarpaşa)
    /// </summary>
    public partial class CollectedInvoicePreReportByDate : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string EPISODECOUNTER = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue("");
        }

        public partial class PARTFGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public PARTFGroupBody Body()
            {
                return (PARTFGroupBody)_body;
            }
            public TTReportField EPISODECOUNT { get {return Body().EPISODECOUNT;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CollectedInvoice.CIEpisodeCountByDate_Class>("CIEpisodeCountByDate", CollectedInvoice.CIEpisodeCountByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTFGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTFGroupBody : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                
                public TTReportField EPISODECOUNT; 
                public PARTFGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    EPISODECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 38, 6, false);
                    EPISODECOUNT.Name = "EPISODECOUNT";
                    EPISODECOUNT.Visible = EvetHayirEnum.ehHayir;
                    EPISODECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODECOUNT.Value = @"{#EPISODECOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CIEpisodeCountByDate_Class dataset_CIEpisodeCountByDate = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CIEpisodeCountByDate_Class>(0);
                    EPISODECOUNT.CalcValue = (dataset_CIEpisodeCountByDate != null ? Globals.ToStringCore(dataset_CIEpisodeCountByDate.Episodecount) : "");
                    return new TTReportObject[] { EPISODECOUNT};
                }

                public override void RunScript()
                {
#region PARTF BODY_Script
                    ((CollectedInvoicePreReportByDate)ParentReport).RuntimeParameters.EPISODECOUNTER = this.EPISODECOUNT.CalcValue;
#endregion PARTF BODY_Script
                }
            }

        }

        public PARTFGroup PARTF;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HASTASAYISI { get {return Body().HASTASAYISI;} }
            public TTReportField BODYTEXT1 { get {return Body().BODYTEXT1;} }
            public TTReportField BODYTEXT2 { get {return Body().BODYTEXT2;} }
            public TTReportField HASTASAYISIYAZIYLA { get {return Body().HASTASAYISIYAZIYLA;} }
            public TTReportField FATURATOPLAMTUTAR { get {return Body().FATURATOPLAMTUTAR;} }
            public TTReportField FATURATOPLAMTUTARYAZIYLA { get {return Body().FATURATOPLAMTUTARYAZIYLA;} }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField ACCOUNTANTNAME { get {return Body().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Body().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT { get {return Body().ACCOUNTANT;} }
            public TTReportField BANKALBL1 { get {return Body().BANKALBL1;} }
            public TTReportField BASLIK131 { get {return Body().BASLIK131;} }
            public TTReportField BASLIK1131 { get {return Body().BASLIK1131;} }
            public TTReportField BASLIK1231 { get {return Body().BASLIK1231;} }
            public TTReportField BASLIK11321 { get {return Body().BASLIK11321;} }
            public TTReportField DOSENO { get {return Body().DOSENO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField BASLIK1111 { get {return Body().BASLIK1111;} }
            public TTReportField SGKBIRIMADI { get {return Body().SGKBIRIMADI;} }
            public TTReportField SGKBIRIMILVEILCE { get {return Body().SGKBIRIMILVEILCE;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
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
                list[0] = new TTReportNqlData<CollectedInvoice.CITotalPriceByDate_Class>("CITotalPriceByDate", CollectedInvoice.CITotalPriceByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                
                public TTReportField HASTASAYISI;
                public TTReportField BODYTEXT1;
                public TTReportField BODYTEXT2;
                public TTReportField HASTASAYISIYAZIYLA;
                public TTReportField FATURATOPLAMTUTAR;
                public TTReportField FATURATOPLAMTUTARYAZIYLA;
                public TTReportField XXXXXXADI;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT;
                public TTReportField BANKALBL1;
                public TTReportField BASLIK131;
                public TTReportField BASLIK1131;
                public TTReportField BASLIK1231;
                public TTReportField BASLIK11321;
                public TTReportField DOSENO;
                public TTReportField TARIH;
                public TTReportField BASLIK1111;
                public TTReportField SGKBIRIMADI;
                public TTReportField SGKBIRIMILVEILCE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 130;
                    RepeatCount = 0;
                    
                    HASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 29, 262, 34, false);
                    HASTASAYISI.Name = "HASTASAYISI";
                    HASTASAYISI.Visible = EvetHayirEnum.ehHayir;
                    HASTASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAYISI.Value = @"{@EPISODECOUNTER@}";

                    BODYTEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 202, 76, false);
                    BODYTEXT1.Name = "BODYTEXT1";
                    BODYTEXT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT1.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT1.TextFont.CharSet = 162;
                    BODYTEXT1.Value = @"";

                    BODYTEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 76, 202, 98, false);
                    BODYTEXT2.Name = "BODYTEXT2";
                    BODYTEXT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT2.TextFont.CharSet = 162;
                    BODYTEXT2.Value = @"";

                    HASTASAYISIYAZIYLA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 36, 262, 41, false);
                    HASTASAYISIYAZIYLA.Name = "HASTASAYISIYAZIYLA";
                    HASTASAYISIYAZIYLA.Visible = EvetHayirEnum.ehHayir;
                    HASTASAYISIYAZIYLA.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAYISIYAZIYLA.TextFormat = @"NUMBERTEXT";
                    HASTASAYISIYAZIYLA.Value = @"{@EPISODECOUNTER@}";

                    FATURATOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 43, 262, 48, false);
                    FATURATOPLAMTUTAR.Name = "FATURATOPLAMTUTAR";
                    FATURATOPLAMTUTAR.Visible = EvetHayirEnum.ehHayir;
                    FATURATOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    FATURATOPLAMTUTAR.Value = @"{#TOTALPRICE#}";

                    FATURATOPLAMTUTARYAZIYLA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 50, 262, 55, false);
                    FATURATOPLAMTUTARYAZIYLA.Name = "FATURATOPLAMTUTARYAZIYLA";
                    FATURATOPLAMTUTARYAZIYLA.Visible = EvetHayirEnum.ehHayir;
                    FATURATOPLAMTUTARYAZIYLA.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATOPLAMTUTARYAZIYLA.TextFormat = @"NUMBERTEXT( TL , KR)";
                    FATURATOPLAMTUTARYAZIYLA.Value = @"{#TOTALPRICE#}";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 202, 29, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXADI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXADI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXADI.TextFont.Name = "Arial";
                    XXXXXXADI.TextFont.Bold = true;
                    XXXXXXADI.TextFont.CharSet = 162;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 106, 202, 110, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUADI"", """")
";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 110, 202, 114, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUUNVANI"", """")
";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 114, 202, 118, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.TextFont.CharSet = 162;
                    ACCOUNTANT.Value = @"Döner Sermaye İşlt. Md.";

                    BANKALBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 124, 161, 129, false);
                    BANKALBL1.Name = "BANKALBL1";
                    BANKALBL1.TextFont.Underline = true;
                    BANKALBL1.TextFont.CharSet = 162;
                    BANKALBL1.Value = @"EKLER                                         :";

                    BASLIK131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 31, 34, false);
                    BASLIK131.Name = "BASLIK131";
                    BASLIK131.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK131.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK131.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK131.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK131.TextFont.Bold = true;
                    BASLIK131.TextFont.CharSet = 162;
                    BASLIK131.Value = @"DÖSE İŞLT.";

                    BASLIK1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 31, 39, false);
                    BASLIK1131.Name = "BASLIK1131";
                    BASLIK1131.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1131.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1131.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1131.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1131.TextFont.Bold = true;
                    BASLIK1131.TextFont.CharSet = 162;
                    BASLIK1131.Value = @"KONU";

                    BASLIK1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 30, 33, 34, false);
                    BASLIK1231.Name = "BASLIK1231";
                    BASLIK1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1231.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1231.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1231.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1231.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1231.TextFont.Name = "Arial";
                    BASLIK1231.TextFont.Bold = true;
                    BASLIK1231.TextFont.CharSet = 162;
                    BASLIK1231.Value = @":";

                    BASLIK11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 35, 33, 39, false);
                    BASLIK11321.Name = "BASLIK11321";
                    BASLIK11321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK11321.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK11321.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK11321.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK11321.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK11321.TextFont.Name = "Arial";
                    BASLIK11321.TextFont.Bold = true;
                    BASLIK11321.TextFont.CharSet = 162;
                    BASLIK11321.Value = @":";

                    DOSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 30, 112, 34, false);
                    DOSENO.Name = "DOSENO";
                    DOSENO.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOSENO.MultiLine = EvetHayirEnum.ehEvet;
                    DOSENO.NoClip = EvetHayirEnum.ehEvet;
                    DOSENO.WordBreak = EvetHayirEnum.ehEvet;
                    DOSENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOSENO.TextFont.CharSet = 162;
                    DOSENO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDOSENO"", """")";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 31, 202, 35, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TARIH.TextFont.Bold = true;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"";

                    BASLIK1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 48, 156, 52, false);
                    BASLIK1111.Name = "BASLIK1111";
                    BASLIK1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1111.TextFont.Name = "Arial";
                    BASLIK1111.TextFont.Bold = true;
                    BASLIK1111.TextFont.CharSet = 162;
                    BASLIK1111.Value = @"SOSYAL GÜVENLİK KURUMU BAŞKANLIĞI";

                    SGKBIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 202, 57, false);
                    SGKBIRIMADI.Name = "SGKBIRIMADI";
                    SGKBIRIMADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    SGKBIRIMADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SGKBIRIMADI.TextFont.Name = "Arial";
                    SGKBIRIMADI.TextFont.Bold = true;
                    SGKBIRIMADI.TextFont.CharSet = 162;
                    SGKBIRIMADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SGKBRANCHNAME"", """")
";

                    SGKBIRIMILVEILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 58, 202, 62, false);
                    SGKBIRIMILVEILCE.Name = "SGKBIRIMILVEILCE";
                    SGKBIRIMILVEILCE.FieldType = ReportFieldTypeEnum.ftExpression;
                    SGKBIRIMILVEILCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SGKBIRIMILVEILCE.TextFont.Name = "Arial";
                    SGKBIRIMILVEILCE.TextFont.Bold = true;
                    SGKBIRIMILVEILCE.TextFont.CharSet = 162;
                    SGKBIRIMILVEILCE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SGKDISTRICTANDCITY"", """")
";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 10, 240, 15, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 17, 240, 22, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 35, 112, 39, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Tedavi Giderleri Hk.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CITotalPriceByDate_Class dataset_CITotalPriceByDate = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CITotalPriceByDate_Class>(0);
                    HASTASAYISI.CalcValue = MyParentReport.RuntimeParameters.EPISODECOUNTER.ToString();
                    BODYTEXT1.CalcValue = @"";
                    BODYTEXT2.CalcValue = @"";
                    HASTASAYISIYAZIYLA.CalcValue = MyParentReport.RuntimeParameters.EPISODECOUNTER.ToString();
                    FATURATOPLAMTUTAR.CalcValue = (dataset_CITotalPriceByDate != null ? Globals.ToStringCore(dataset_CITotalPriceByDate.Totalprice) : "");
                    FATURATOPLAMTUTARYAZIYLA.CalcValue = (dataset_CITotalPriceByDate != null ? Globals.ToStringCore(dataset_CITotalPriceByDate.Totalprice) : "");
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    BANKALBL1.CalcValue = BANKALBL1.Value;
                    BASLIK131.CalcValue = BASLIK131.Value;
                    BASLIK1131.CalcValue = BASLIK1131.Value;
                    BASLIK1231.CalcValue = BASLIK1231.Value;
                    BASLIK11321.CalcValue = BASLIK11321.Value;
                    TARIH.CalcValue = @"";
                    BASLIK1111.CalcValue = BASLIK1111.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUADI", "")
;
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUUNVANI", "")
;
                    DOSENO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDOSENO", "");
                    SGKBIRIMADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SGKBRANCHNAME", "")
;
                    SGKBIRIMILVEILCE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SGKDISTRICTANDCITY", "")
;
                    return new TTReportObject[] { HASTASAYISI,BODYTEXT1,BODYTEXT2,HASTASAYISIYAZIYLA,FATURATOPLAMTUTAR,FATURATOPLAMTUTARYAZIYLA,ACCOUNTANT,BANKALBL1,BASLIK131,BASLIK1131,BASLIK1231,BASLIK11321,TARIH,BASLIK1111,STARTDATE,ENDDATE,NewField1,XXXXXXADI,ACCOUNTANTNAME,ACCOUNTANTTITLE,DOSENO,SGKBIRIMADI,SGKBIRIMILVEILCE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.FATURATOPLAMTUTAR.CalcValue == "")
                this.FATURATOPLAMTUTAR.CalcValue = "0";
            
            if (this.FATURATOPLAMTUTARYAZIYLA.CalcValue == "")
                this.FATURATOPLAMTUTARYAZIYLA.CalcValue = "0";
            
            string date = "";
            string month = "";
            string monthtext = "";
            string year = "";
            
            date = this.STARTDATE.FormattedValue;
            month = date.Substring(3,2);
            year = date.Substring(6,4);
            
            switch (month)
            {
                case "01":
                    monthtext = "Ocak";
                    break;
                case "02":
                    monthtext = "Şubat";
                    break;
                case "03":
                    monthtext = "Mart";
                    break;
                case "04":
                    monthtext = "Nisan";
                    break;
                case "05":
                    monthtext = "Mayıs";
                    break;
                case "06":
                    monthtext = "Haziran";
                    break;
                case "07":
                    monthtext = "Temmuz";
                    break;
                case "08":
                    monthtext = "Ağustos";
                    break;
                case "09":
                    monthtext = "Eylül";
                    break;
                case "10":
                    monthtext = "Ekim";
                    break;
                case "11":
                    monthtext = "Kasım";
                    break;
                case "12":
                    monthtext = "Aralık";
                    break;
                default:
                    break;
            }
            
            this.TARIH.CalcValue = monthtext + " " + year;
            string hospitalName = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "").Replace("\r\n", " ");
            //this.BODYTEXT1.CalcValue = "1. " + this.XXXXXXADI.FormattedValue + " 'nde tedavi edilen ("  + this.HASTASAYISI.FormattedValue + ") (" + this.HASTASAYISIYAZIYLA.FormattedValue + ") hastaya ait tanzim edilen fatura, masraf belgeleri ve icmal listesi EK'te sunulmuştur.";
            this.BODYTEXT1.CalcValue = "1. " + hospitalName + " 'nde tedavi edilen ("  + this.HASTASAYISI.FormattedValue + ") (" + this.HASTASAYISIYAZIYLA.FormattedValue + ") hastaya ait tanzim edilen fatura, masraf belgeleri ve icmal listesi EK'te sunulmuştur.";
            this.BODYTEXT2.CalcValue = "2. Fatura ve eklerinin 'Sağlık Yardımları Sosyal Güvenlik Kurumu Tarafından Karşılanan Kişilerin XXXXXX Sağlık Kurum ve Kuruluşlarından Faydalanmalarına Dair Protokol' ve anılan protokolün MEDULA sistemine geçiş süresi ve mevcut XXXXXX bilgi sistemlerinin kullanılmasını düzenleyen 4.3.'ncü maddesi kapsamında incelenerek, toplam fatura bedeli olan #" + this.FATURATOPLAMTUTAR.FormattedValue + "# - (" + this.FATURATOPLAMTUTARYAZIYLA.FormattedValue + ")'sının işletmemizin hesabına gönderilmesini arz/rica ederim." ;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField EKA { get {return Body().EKA;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CollectedInvoice.CICountByDate_Class>("CICountByDate", CollectedInvoice.CICountByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                
                public TTReportField EKA; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    EKA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 161, 5, false);
                    EKA.Name = "EKA";
                    EKA.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKA.TextFont.CharSet = 162;
                    EKA.Value = @"EK-A ({#INVOICECOUNT#} Adet Fatura)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CICountByDate_Class dataset_CICountByDate = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CICountByDate_Class>(0);
                    EKA.CalcValue = @"EK-A (" + (dataset_CICountByDate != null ? Globals.ToStringCore(dataset_CICountByDate.Invoicecount) : "") + @" Adet Fatura)";
                    return new TTReportObject[] { EKA};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public PARTBGroupBody Body()
            {
                return (PARTBGroupBody)_body;
            }
            public TTReportField EKB { get {return Body().EKB;} }
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
                _header = null;
                _footer = null;
                _body = new PARTBGroupBody(this);
            }

            public partial class PARTBGroupBody : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                
                public TTReportField EKB; 
                public PARTBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    EKB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 161, 5, false);
                    EKB.Name = "EKB";
                    EKB.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKB.TextFont.CharSet = 162;
                    EKB.Value = @"EK-B (1 Adet Hizmet CD)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EKB.CalcValue = @"EK-B (1 Adet Hizmet CD)";
                    return new TTReportObject[] { EKB};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTEGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField EKC { get {return Footer().EKC;} }
            public TTReportField COUNT { get {return Footer().COUNT;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTEGroupHeader(this);
                _footer = new PARTEGroupFooter(this);

            }

            public partial class PARTEGroupHeader : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                
                public TTReportField EKC;
                public TTReportField COUNT; 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    EKC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 161, 5, false);
                    EKC.Name = "EKC";
                    EKC.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKC.TextFont.CharSet = 162;
                    EKC.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 0, 240, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EKC.CalcValue = @"";
                    COUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { EKC,COUNT};
                }

                public override void RunScript()
                {
#region PARTE FOOTER_Script
                    if (this.COUNT.CalcValue == "-1")
                this.COUNT.CalcValue = "0";
            
            this.EKC.CalcValue = "EK-C (" + this.COUNT.CalcValue + " Klasör Hastaya Ait Hizmet Dökümü ve İcmal Listesi)";
#endregion PARTE FOOTER_Script
                }
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTCGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
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
                list[0] = new TTReportNqlData<CollectedInvoice.CIBranchCountByDate_Class>("CIBranchCountByDate", CollectedInvoice.CIBranchCountByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public CollectedInvoicePreReportByDate MyParentReport
            {
                get { return (CollectedInvoicePreReportByDate)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField BANKALBL { get {return Body().BANKALBL;} }
            public TTReportField SUBEADI { get {return Body().SUBEADI;} }
            public TTReportField SUBEILVEILCE { get {return Body().SUBEILVEILCE;} }
            public TTReportField HESAPNO { get {return Body().HESAPNO;} }
            public TTReportField BANKALBL1 { get {return Body().BANKALBL1;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public CollectedInvoicePreReportByDate MyParentReport
                {
                    get { return (CollectedInvoicePreReportByDate)ParentReport; }
                }
                
                public TTReportField BANKALBL;
                public TTReportField SUBEADI;
                public TTReportField SUBEILVEILCE;
                public TTReportField HESAPNO;
                public TTReportField BANKALBL1; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 30;
                    RepeatCount = 0;
                    
                    BANKALBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 92, 15, false);
                    BANKALBL.Name = "BANKALBL";
                    BANKALBL.TextFont.Underline = true;
                    BANKALBL.TextFont.CharSet = 162;
                    BANKALBL.Value = @"BANKA ADI                                                                                  :";

                    SUBEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 92, 21, false);
                    SUBEADI.Name = "SUBEADI";
                    SUBEADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUBEADI.TextFont.CharSet = 162;
                    SUBEADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKBRANCHNAME"", """")
";

                    SUBEILVEILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 92, 27, false);
                    SUBEILVEILCE.Name = "SUBEILVEILCE";
                    SUBEILVEILCE.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUBEILVEILCE.TextFont.CharSet = 162;
                    SUBEILVEILCE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKBRANCHDISTRICTANDCITY"", """")
";

                    HESAPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 16, 167, 21, false);
                    HESAPNO.Name = "HESAPNO";
                    HESAPNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HESAPNO.TextFont.CharSet = 162;
                    HESAPNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTNO"", """")
";

                    BANKALBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 10, 167, 15, false);
                    BANKALBL1.Name = "BANKALBL1";
                    BANKALBL1.TextFont.Underline = true;
                    BANKALBL1.TextFont.CharSet = 162;
                    BANKALBL1.Value = @"HESAP NUMARASI                                         :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BANKALBL.CalcValue = BANKALBL.Value;
                    BANKALBL1.CalcValue = BANKALBL1.Value;
                    SUBEADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKBRANCHNAME", "")
;
                    SUBEILVEILCE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKBRANCHDISTRICTANDCITY", "")
;
                    HESAPNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTNO", "")
;
                    return new TTReportObject[] { BANKALBL,BANKALBL1,SUBEADI,SUBEILVEILCE,HESAPNO};
                }
            }

        }

        public PARTDGroup PARTD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollectedInvoicePreReportByDate()
        {
            PARTF = new PARTFGroup(this,"PARTF");
            MAIN = new MAINGroup(this,"MAIN");
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(this,"PARTB");
            PARTE = new PARTEGroup(this,"PARTE");
            PARTC = new PARTCGroup(PARTE,"PARTC");
            PARTD = new PARTDGroup(this,"PARTD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("EPISODECOUNTER", "", "", @"", false, false, false, new Guid("5dcf77fd-4b8d-479a-9e5e-e5e7414cf8b6"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("EPISODECOUNTER"))
                _runtimeParameters.EPISODECOUNTER = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue(parameters["EPISODECOUNTER"]);
            Name = "COLLECTEDINVOICEPREREPORTBYDATE";
            Caption = "Toplu Fatura Önyazı Raporu (Haydarpaşa)";
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

    }
}