
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
    /// Kurum Faturası
    /// </summary>
    public partial class GeneralInvoiceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public double? PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public double? TURNOVERTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public string ISLASTPAGE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("False");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public GeneralInvoiceReport MyParentReport
            {
                get { return (GeneralInvoiceReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField TAXOFFICE { get {return Header().TAXOFFICE;} }
            public TTReportField TAXNUMBER { get {return Header().TAXNUMBER;} }
            public TTReportField TURNOVERTOTALLABEL { get {return Header().TURNOVERTOTALLABEL;} }
            public TTReportField TURNOVERTOTAL { get {return Header().TURNOVERTOTAL;} }
            public TTReportField TL { get {return Header().TL;} }
            public TTReportField PAYERADDRESS { get {return Header().PAYERADDRESS;} }
            public TTReportField PAYERPHONE { get {return Header().PAYERPHONE;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField TAXINFO { get {return Header().TAXINFO;} }
            public TTReportField BANKACCOUNT { get {return Header().BANKACCOUNT;} }
            public TTReportField HOSPITALIBANNO { get {return Header().HOSPITALIBANNO;} }
            public TTReportField ACCOUNTANTNAME { get {return Header().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Header().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT { get {return Header().ACCOUNTANT;} }
            public TTReportField CASHIERNAME { get {return Header().CASHIERNAME;} }
            public TTReportField CASHIERTITLE { get {return Header().CASHIERTITLE;} }
            public TTReportField CASHIERRECID { get {return Header().CASHIERRECID;} }
            public TTReportField CASHIER { get {return Header().CASHIER;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField DOCUMENTNOFOOTER { get {return Footer().DOCUMENTNOFOOTER;} }
            public TTReportField DOCUMENTDATEFOOTER { get {return Footer().DOCUMENTDATEFOOTER;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField PAGE2 { get {return Footer().PAGE2;} }
            public TTReportField TOTALDISCOUNTPRICE { get {return Footer().TOTALDISCOUNTPRICE;} }
            public TTReportField GENERALTOTALPRICE { get {return Footer().GENERALTOTALPRICE;} }
            public TTReportField PAGETOTALLABEL { get {return Footer().PAGETOTALLABEL;} }
            public TTReportField PAGETOTAL { get {return Footer().PAGETOTAL;} }
            public TTReportField TL1 { get {return Footer().TL1;} }
            public TTReportField TL2 { get {return Footer().TL2;} }
            public TTReportField TL3 { get {return Footer().TL3;} }
            public TTReportField TL4 { get {return Footer().TL4;} }
            public TTReportField PRICE { get {return Footer().PRICE;} }
            public TTReportField PAYER1 { get {return Footer().PAYER1;} }
            public TTReportField PAGENO2 { get {return Footer().PAGENO2;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class>("GeneralInvoiceReportInfoQuery", GeneralInvoice.GeneralInvoiceReportInfoQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public GeneralInvoiceReport MyParentReport
                {
                    get { return (GeneralInvoiceReport)ParentReport; }
                }
                
                public TTReportField PAGENO;
                public TTReportField DOCUMENTDATE;
                public TTReportField DOCUMENTNO;
                public TTReportField TAXOFFICE;
                public TTReportField TAXNUMBER;
                public TTReportField TURNOVERTOTALLABEL;
                public TTReportField TURNOVERTOTAL;
                public TTReportField TL;
                public TTReportField PAYERADDRESS;
                public TTReportField PAYERPHONE;
                public TTReportField PAYER;
                public TTReportField TAXINFO;
                public TTReportField BANKACCOUNT;
                public TTReportField HOSPITALIBANNO;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERRECID;
                public TTReportField CASHIER; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 89;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 6, 184, 11, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.TextFont.Size = 8;
                    PAGENO.TextFont.CharSet = 162;
                    PAGENO.Value = @"{@pagenumber@}. SAYFA";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 16, 167, 21, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATE.TextFont.Size = 8;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 15, 249, 19, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFont.Size = 8;
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    TAXOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 41, 249, 45, false);
                    TAXOFFICE.Name = "TAXOFFICE";
                    TAXOFFICE.Visible = EvetHayirEnum.ehHayir;
                    TAXOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXOFFICE.TextFont.Size = 8;
                    TAXOFFICE.TextFont.CharSet = 162;
                    TAXOFFICE.Value = @"{#PAYERTAXOFFICE#}";

                    TAXNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 47, 249, 51, false);
                    TAXNUMBER.Name = "TAXNUMBER";
                    TAXNUMBER.Visible = EvetHayirEnum.ehHayir;
                    TAXNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXNUMBER.TextFont.Size = 8;
                    TAXNUMBER.TextFont.CharSet = 162;
                    TAXNUMBER.Value = @"{#PAYERTAXNUMBER#}";

                    TURNOVERTOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 76, 150, 80, false);
                    TURNOVERTOTALLABEL.Name = "TURNOVERTOTALLABEL";
                    TURNOVERTOTALLABEL.TextFont.Size = 8;
                    TURNOVERTOTALLABEL.TextFont.CharSet = 162;
                    TURNOVERTOTALLABEL.Value = @"Nakli Yekün :";

                    TURNOVERTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 76, 181, 80, false);
                    TURNOVERTOTAL.Name = "TURNOVERTOTAL";
                    TURNOVERTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TURNOVERTOTAL.TextFormat = @"#,##0.#0";
                    TURNOVERTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TURNOVERTOTAL.TextFont.Size = 8;
                    TURNOVERTOTAL.TextFont.CharSet = 162;
                    TURNOVERTOTAL.Value = @"";

                    TL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 55, 226, 59, false);
                    TL.Name = "TL";
                    TL.Visible = EvetHayirEnum.ehHayir;
                    TL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL.TextFont.Size = 8;
                    TL.TextFont.CharSet = 162;
                    TL.Value = @"TL";

                    PAYERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 8, 249, 12, false);
                    PAYERADDRESS.Name = "PAYERADDRESS";
                    PAYERADDRESS.Visible = EvetHayirEnum.ehHayir;
                    PAYERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.TextFont.Size = 8;
                    PAYERADDRESS.TextFont.CharSet = 162;
                    PAYERADDRESS.Value = @"{#PAYERADDRESS#}";

                    PAYERPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 35, 249, 39, false);
                    PAYERPHONE.Name = "PAYERPHONE";
                    PAYERPHONE.Visible = EvetHayirEnum.ehHayir;
                    PAYERPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERPHONE.TextFont.Size = 8;
                    PAYERPHONE.TextFont.CharSet = 162;
                    PAYERPHONE.Value = @"{#PAYERPHONE#}";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 38, 168, 46, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.NoClip = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"";

                    TAXINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 60, 60, 72, false);
                    TAXINFO.Name = "TAXINFO";
                    TAXINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXINFO.MultiLine = EvetHayirEnum.ehEvet;
                    TAXINFO.NoClip = EvetHayirEnum.ehEvet;
                    TAXINFO.WordBreak = EvetHayirEnum.ehEvet;
                    TAXINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXINFO.TextFont.Size = 8;
                    TAXINFO.TextFont.CharSet = 162;
                    TAXINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 111, 68, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.Size = 8;
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    HOSPITALIBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 68, 111, 72, false);
                    HOSPITALIBANNO.Name = "HOSPITALIBANNO";
                    HOSPITALIBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.TextFont.Size = 8;
                    HOSPITALIBANNO.TextFont.CharSet = 162;
                    HOSPITALIBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 60, 202, 64, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.TextFont.Size = 8;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUADI"", """")";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 64, 202, 68, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.TextFont.Size = 8;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUUNVANI"", """")
";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 68, 202, 72, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.TextFont.Size = 8;
                    ACCOUNTANT.TextFont.CharSet = 162;
                    ACCOUNTANT.Value = @"Döner Sermaye İşl. M.";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 60, 152, 64, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.TextFont.Size = 8;
                    CASHIERNAME.TextFont.CharSet = 162;
                    CASHIERNAME.Value = @"";

                    CASHIERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 64, 152, 68, false);
                    CASHIERTITLE.Name = "CASHIERTITLE";
                    CASHIERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERTITLE.TextFont.Size = 8;
                    CASHIERTITLE.TextFont.CharSet = 162;
                    CASHIERTITLE.Value = @"";

                    CASHIERRECID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 68, 152, 72, false);
                    CASHIERRECID.Name = "CASHIERRECID";
                    CASHIERRECID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERRECID.TextFont.Size = 8;
                    CASHIERRECID.TextFont.CharSet = 162;
                    CASHIERRECID.Value = @"";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 22, 249, 26, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.Visible = EvetHayirEnum.ehHayir;
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.TextFont.Size = 8;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneralInvoice.GeneralInvoiceReportInfoQuery_Class dataset_GeneralInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class>(0);
                    PAGENO.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    DOCUMENTDATE.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.DocumentDate) : "");
                    DOCUMENTNO.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.DocumentNo) : "");
                    TAXOFFICE.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.Payertaxoffice) : "");
                    TAXNUMBER.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.Payertaxnumber) : "");
                    TURNOVERTOTALLABEL.CalcValue = TURNOVERTOTALLABEL.Value;
                    TURNOVERTOTAL.CalcValue = @"";
                    TL.CalcValue = TL.Value;
                    PAYERADDRESS.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.Payeraddress) : "");
                    PAYERPHONE.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.Payerphone) : "");
                    PAYER.CalcValue = @"";
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    CASHIERNAME.CalcValue = @"";
                    CASHIERTITLE.CalcValue = @"";
                    CASHIERRECID.CalcValue = @"";
                    CASHIER.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.Cashier) : "");
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUADI", "");
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUUNVANI", "")
;
                    return new TTReportObject[] { PAGENO,DOCUMENTDATE,DOCUMENTNO,TAXOFFICE,TAXNUMBER,TURNOVERTOTALLABEL,TURNOVERTOTAL,TL,PAYERADDRESS,PAYERPHONE,PAYER,ACCOUNTANT,CASHIERNAME,CASHIERTITLE,CASHIERRECID,CASHIER,TAXINFO,BANKACCOUNT,HOSPITALIBANNO,ACCOUNTANTNAME,ACCOUNTANTTITLE};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if(this.PAGENO.CalcValue == "1. SAYFA")
                ((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = 0;
            
            ((GeneralInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL = 0;
            this.TURNOVERTOTAL.CalcValue = (((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
            
            if(((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL == (double)0)
            {
                this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehHayir;
                this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                this.TL.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehEvet;
                this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehEvet;
                this.TL.Visible = EvetHayirEnum.ehEvet;
            }
            
            TTObjectContext context = new TTObjectContext(true);
            string cashierObjectID = this.CASHIER.CalcValue;
            ResUser cashier = (ResUser)context.GetObject(new Guid(cashierObjectID),"ResUser");
            
            if (cashier != null)
            {
                this.CASHIERNAME.CalcValue = cashier.Name;
                if(cashier.UserType.HasValue)
                    this.CASHIERTITLE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(cashier.UserType.Value);
                if(cashier.EmploymentRecordID != null)
                    this.CASHIERRECID.CalcValue = cashier.EmploymentRecordID;
            }
            
            string payer = string.Empty;
            GeneralInvoice generalInvoice = (GeneralInvoice)context.GetObject(new Guid(((GeneralInvoiceReport)ParentReport).RuntimeParameters.TTOBJECTID), "GeneralInvoice");
            if(generalInvoice.Payer != null)
            {
                payer = generalInvoice.Payer.Code + " " + generalInvoice.Payer.Name;
                if(generalInvoice.Payer.City != null)
                    payer += " " + generalInvoice.Payer.City.Name;
            }
            else if(generalInvoice.CommunityHealthPayer != null)
                payer = generalInvoice.CommunityHealthPayer.Name;
            
            this.PAYER.CalcValue = payer;
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public GeneralInvoiceReport MyParentReport
                {
                    get { return (GeneralInvoiceReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField DOCUMENTNOFOOTER;
                public TTReportField DOCUMENTDATEFOOTER;
                public TTReportField TOTAL;
                public TTReportField PAGE2;
                public TTReportField TOTALDISCOUNTPRICE;
                public TTReportField GENERALTOTALPRICE;
                public TTReportField PAGETOTALLABEL;
                public TTReportField PAGETOTAL;
                public TTReportField TL1;
                public TTReportField TL2;
                public TTReportField TL3;
                public TTReportField TL4;
                public TTReportField PRICE;
                public TTReportField PAYER1;
                public TTReportField PAGENO2; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 118;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 15, 282, 19, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 9, 181, 13, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.TextFont.Size = 8;
                    PRICEWITHLETTERS.TextFont.CharSet = 162;
                    PRICEWITHLETTERS.Value = @"";

                    DOCUMENTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 47, 257, 51, false);
                    DOCUMENTNOFOOTER.Name = "DOCUMENTNOFOOTER";
                    DOCUMENTNOFOOTER.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNOFOOTER.TextFont.Size = 8;
                    DOCUMENTNOFOOTER.TextFont.CharSet = 162;
                    DOCUMENTNOFOOTER.Value = @"{#DOCUMENTNO#}";

                    DOCUMENTDATEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 48, 167, 52, false);
                    DOCUMENTDATEFOOTER.Name = "DOCUMENTDATEFOOTER";
                    DOCUMENTDATEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATEFOOTER.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATEFOOTER.TextFont.Size = 8;
                    DOCUMENTDATEFOOTER.TextFont.CharSet = 162;
                    DOCUMENTDATEFOOTER.Value = @"{#DOCUMENTDATE#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 56, 167, 60, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.TextFont.Size = 8;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    PAGE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 54, 257, 58, false);
                    PAGE2.Name = "PAGE2";
                    PAGE2.Visible = EvetHayirEnum.ehHayir;
                    PAGE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE2.TextFont.Size = 8;
                    PAGE2.TextFont.CharSet = 162;
                    PAGE2.Value = @"";

                    TOTALDISCOUNTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 22, 282, 26, false);
                    TOTALDISCOUNTPRICE.Name = "TOTALDISCOUNTPRICE";
                    TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDISCOUNTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDISCOUNTPRICE.TextFormat = @"#,##0.#0";
                    TOTALDISCOUNTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDISCOUNTPRICE.TextFont.Size = 8;
                    TOTALDISCOUNTPRICE.TextFont.CharSet = 162;
                    TOTALDISCOUNTPRICE.Value = @"0";

                    GENERALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 29, 282, 33, false);
                    GENERALTOTALPRICE.Name = "GENERALTOTALPRICE";
                    GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    GENERALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALTOTALPRICE.TextFormat = @"#,##0.#0";
                    GENERALTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALTOTALPRICE.TextFont.Size = 8;
                    GENERALTOTALPRICE.TextFont.CharSet = 162;
                    GENERALTOTALPRICE.Value = @"{#TOTALPRICE#}";

                    PAGETOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 4, 252, 8, false);
                    PAGETOTALLABEL.Name = "PAGETOTALLABEL";
                    PAGETOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTALLABEL.TextFont.Size = 8;
                    PAGETOTALLABEL.TextFont.CharSet = 162;
                    PAGETOTALLABEL.Value = @"Sayfa Toplamı :";

                    PAGETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 4, 282, 8, false);
                    PAGETOTAL.Name = "PAGETOTAL";
                    PAGETOTAL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGETOTAL.TextFormat = @"#,##0.#0";
                    PAGETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGETOTAL.TextFont.Size = 8;
                    PAGETOTAL.TextFont.CharSet = 162;
                    PAGETOTAL.Value = @"";

                    TL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 4, 289, 8, false);
                    TL1.Name = "TL1";
                    TL1.Visible = EvetHayirEnum.ehHayir;
                    TL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL1.TextFont.Size = 8;
                    TL1.TextFont.CharSet = 162;
                    TL1.Value = @"TL";

                    TL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 15, 289, 19, false);
                    TL2.Name = "TL2";
                    TL2.Visible = EvetHayirEnum.ehHayir;
                    TL2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL2.TextFont.Size = 8;
                    TL2.TextFont.CharSet = 162;
                    TL2.Value = @"TL";

                    TL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 22, 289, 26, false);
                    TL3.Name = "TL3";
                    TL3.Visible = EvetHayirEnum.ehHayir;
                    TL3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL3.TextFont.Size = 8;
                    TL3.TextFont.CharSet = 162;
                    TL3.Value = @"TL";

                    TL4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 29, 289, 33, false);
                    TL4.Name = "TL4";
                    TL4.Visible = EvetHayirEnum.ehHayir;
                    TL4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL4.TextFont.Size = 8;
                    TL4.TextFont.CharSet = 162;
                    TL4.Value = @"TL";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 1, 181, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    PAYER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 39, 180, 47, false);
                    PAYER1.Name = "PAYER1";
                    PAYER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER1.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER1.NoClip = EvetHayirEnum.ehEvet;
                    PAYER1.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER1.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER1.TextFont.Size = 8;
                    PAYER1.TextFont.CharSet = 162;
                    PAYER1.Value = @"";

                    PAGENO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 65, 181, 70, false);
                    PAGENO2.Name = "PAGENO2";
                    PAGENO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO2.TextFont.Size = 8;
                    PAGENO2.TextFont.CharSet = 162;
                    PAGENO2.Value = @"{@pagenumber@}. SAYFA";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneralInvoice.GeneralInvoiceReportInfoQuery_Class dataset_GeneralInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.TotalPrice) : "");
                    PRICEWITHLETTERS.CalcValue = @"";
                    DOCUMENTNOFOOTER.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.DocumentNo) : "");
                    DOCUMENTDATEFOOTER.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.DocumentDate) : "");
                    TOTAL.CalcValue = @"";
                    PAGE2.CalcValue = @"";
                    TOTALDISCOUNTPRICE.CalcValue = @"0";
                    GENERALTOTALPRICE.CalcValue = (dataset_GeneralInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportInfoQuery.TotalPrice) : "");
                    PAGETOTALLABEL.CalcValue = PAGETOTALLABEL.Value;
                    PAGETOTAL.CalcValue = @"";
                    TL1.CalcValue = TL1.Value;
                    TL2.CalcValue = TL2.Value;
                    TL3.CalcValue = TL3.Value;
                    TL4.CalcValue = TL4.Value;
                    PRICE.CalcValue = @"";
                    PAYER1.CalcValue = @"";
                    PAGENO2.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,DOCUMENTNOFOOTER,DOCUMENTDATEFOOTER,TOTAL,PAGE2,TOTALDISCOUNTPRICE,GENERALTOTALPRICE,PAGETOTALLABEL,PAGETOTAL,TL1,TL2,TL3,TL4,PRICE,PAYER1,PAGENO2};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    this.PAGETOTAL.CalcValue = (((GeneralInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL).ToString();
            ((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = ((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL + ((GeneralInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL;
            this.PRICE.CalcValue = (((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
            this.TOTAL.CalcValue = (((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
            this.PRICEWITHLETTERS.CalcValue = (((GeneralInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
            
            if(((GeneralInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE == "True")
            {
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehEvet;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehEvet;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                this.TL2.Visible = EvetHayirEnum.ehEvet;
                this.TL3.Visible = EvetHayirEnum.ehEvet;
                this.TL4.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TL2.Visible = EvetHayirEnum.ehHayir;
                this.TL3.Visible = EvetHayirEnum.ehHayir;
                this.TL4.Visible = EvetHayirEnum.ehHayir;
            }
            
            TTObjectContext context = new TTObjectContext(true);
            string payer = string.Empty;
            GeneralInvoice generalInvoice = (GeneralInvoice)context.GetObject(new Guid(((GeneralInvoiceReport)ParentReport).RuntimeParameters.TTOBJECTID), "GeneralInvoice");
            if(generalInvoice.Payer != null)
            {
                payer = generalInvoice.Payer.Code + " " + generalInvoice.Payer.Name;
                if(generalInvoice.Payer.City != null)
                    payer += " " + generalInvoice.Payer.City.Name;
            }
            else if(generalInvoice.CommunityHealthPayer != null)
                payer = generalInvoice.CommunityHealthPayer.Name;
            
            this.PAYER1.CalcValue = payer;
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class TRXDESCGroup : TTReportGroup
        {
            public GeneralInvoiceReport MyParentReport
            {
                get { return (GeneralInvoiceReport)ParentReport; }
            }

            new public TRXDESCGroupHeader Header()
            {
                return (TRXDESCGroupHeader)_header;
            }

            new public TRXDESCGroupFooter Footer()
            {
                return (TRXDESCGroupFooter)_footer;
            }

            public TTReportField BUTCODE { get {return Header().BUTCODE;} }
            public TRXDESCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TRXDESCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<GeneralInvoice.GeneralInvoiceReportQuery_Class>("GeneralInvoiceReportQuery", GeneralInvoice.GeneralInvoiceReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TRXDESCGroupHeader(this);
                _footer = new TRXDESCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TRXDESCGroupHeader : TTReportSection
            {
                public GeneralInvoiceReport MyParentReport
                {
                    get { return (GeneralInvoiceReport)ParentReport; }
                }
                
                public TTReportField BUTCODE; 
                public TRXDESCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 181, 4, false);
                    BUTCODE.Name = "BUTCODE";
                    BUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCODE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BUTCODE.MultiLine = EvetHayirEnum.ehEvet;
                    BUTCODE.NoClip = EvetHayirEnum.ehEvet;
                    BUTCODE.WordBreak = EvetHayirEnum.ehEvet;
                    BUTCODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    BUTCODE.TextFont.Size = 8;
                    BUTCODE.TextFont.Bold = true;
                    BUTCODE.TextFont.CharSet = 162;
                    BUTCODE.Value = @"{#GROUPDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneralInvoice.GeneralInvoiceReportQuery_Class dataset_GeneralInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneralInvoice.GeneralInvoiceReportQuery_Class>(0);
                    BUTCODE.CalcValue = (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.GroupDescription) : "");
                    return new TTReportObject[] { BUTCODE};
                }
            }
            public partial class TRXDESCGroupFooter : TTReportSection
            {
                public GeneralInvoiceReport MyParentReport
                {
                    get { return (GeneralInvoiceReport)ParentReport; }
                }
                 
                public TRXDESCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TRXDESCGroup TRXDESC;

        public partial class MAINGroup : TTReportGroup
        {
            public GeneralInvoiceReport MyParentReport
            {
                get { return (GeneralInvoiceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                GeneralInvoice.GeneralInvoiceReportQuery_Class dataSet_GeneralInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneralInvoice.GeneralInvoiceReportQuery_Class>(0);    
                return new object[] {(dataSet_GeneralInvoiceReportQuery==null ? null : dataSet_GeneralInvoiceReportQuery.GroupDescription)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public GeneralInvoiceReport MyParentReport
                {
                    get { return (GeneralInvoiceReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField DESCRIPTION;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField TRANSACTIONDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 20, 4, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 103, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#TRXDESC.CODE#} {#TRXDESC.NAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 111, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#TRXDESC.AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 143, 4, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#TRXDESC.UNITPRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 181, 4, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#TRXDESC.TOTALPRICE#}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 40, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"Short Date";
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{#TRXDESC.ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneralInvoice.GeneralInvoiceReportQuery_Class dataset_GeneralInvoiceReportQuery = MyParentReport.TRXDESC.rsGroup.GetCurrentRecord<GeneralInvoice.GeneralInvoiceReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    DESCRIPTION.CalcValue = (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.Code) : "") + @" " + (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.Name) : "");
                    AMOUNT.CalcValue = (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.UnitPrice) : "");
                    PRICE.CalcValue = (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.TotalPrice) : "");
                    TRANSACTIONDATE.CalcValue = (dataset_GeneralInvoiceReportQuery != null ? Globals.ToStringCore(dataset_GeneralInvoiceReportQuery.ActionDate) : "");
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((GeneralInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL = ((GeneralInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (this.MyParentReport.TRXDESC.IsLastData())
                ((GeneralInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE = "True";
            else
                ((GeneralInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE = "False";
            
            return true;
#endregion MAIN_Script
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GeneralInvoiceReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            TRXDESC = new TRXDESCGroup(HEAD,"TRXDESC");
            MAIN = new MAINGroup(TRXDESC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PAGETOTAL", "0", "SAYFA TOPLAMI", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("TURNOVERTOTAL", "0", "NAKLİ YEKÜN", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("ISLASTPAGE", "False", "SON SAYFA", @"", false, false, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PAGETOTAL"))
                _runtimeParameters.PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["PAGETOTAL"]);
            if (parameters.ContainsKey("TURNOVERTOTAL"))
                _runtimeParameters.TURNOVERTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["TURNOVERTOTAL"]);
            if (parameters.ContainsKey("ISLASTPAGE"))
                _runtimeParameters.ISLASTPAGE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["ISLASTPAGE"]);
            Name = "GENERALINVOICEREPORT";
            Caption = "Hizmet Karşılığı Kurum Faturası";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 216;
            p_PageHeight = 309;
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
            fd.TextFont.Name = "Courier New";
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