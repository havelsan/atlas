
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
    /// Makbuz Raporu (Detaylı)
    /// </summary>
    public partial class ReceiptDetailedReport : TTReport
    {
#region Methods
   public List<Detail> detailList = new List<Detail>();
        public List<Detail> printList = new List<Detail>();
        
        public class Detail
        {
            public int OrderNo;
            public string Description;
            public Currency Price;

            public Detail(int orderNo, string description, Currency price)
            {
                OrderNo = orderNo;
                Description = description;
                Price = price;
            }
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ReceiptDetailedReport MyParentReport
            {
                get { return (ReceiptDetailedReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField CASHOFFICENAME { get {return Header().CASHOFFICENAME;} }
            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ACCOUNTOFFICENAME { get {return Header().ACCOUNTOFFICENAME;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField CASHIERNAME { get {return Header().CASHIERNAME;} }
            public TTReportField CASHIERUNIQUEREFNO { get {return Header().CASHIERUNIQUEREFNO;} }
            public TTReportField HOSPITALPROTOCOLNO { get {return Header().HOSPITALPROTOCOLNO;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField LBL14 { get {return Header().LBL14;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField REASON { get {return Header().REASON;} }
            public TTReportField HOMEADDRESS { get {return Header().HOMEADDRESS;} }
            public TTReportField HOMETOWN { get {return Header().HOMETOWN;} }
            public TTReportField HOMECITY { get {return Header().HOMECITY;} }
            public TTReportField LBLSPECIALNO { get {return Header().LBLSPECIALNO;} }
            public TTReportField SPECIALNO { get {return Header().SPECIALNO;} }
            public TTReportField TOTALPAYMENT { get {return Footer().TOTALPAYMENT;} }
            public TTReportField PRICEWITHLETTERSANDTYPE { get {return Footer().PRICEWITHLETTERSANDTYPE;} }
            public TTReportField ACCOUNTOFFICENAMEFOOTER { get {return Footer().ACCOUNTOFFICENAMEFOOTER;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIERNAMEFOOTER { get {return Footer().CASHIERNAMEFOOTER;} }
            public TTReportField RECEIPTDOCUMENTOBJECTID { get {return Footer().RECEIPTDOCUMENTOBJECTID;} }
            public TTReportField ADVANCES { get {return Footer().ADVANCES;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField PAYMENTTYPE { get {return Footer().PAYMENTTYPE;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Receipt.ReceiptReportQuery_Class>("ReceiptReportQuery", Receipt.ReceiptReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public ReceiptDetailedReport MyParentReport
                {
                    get { return (ReceiptDetailedReport)ParentReport; }
                }
                
                public TTReportField CASHOFFICENAME;
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField ADDRESS;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIERUNIQUEREFNO;
                public TTReportField HOSPITALPROTOCOLNO;
                public TTReportField PATIENTNAME;
                public TTReportField BABAADI;
                public TTReportField LBL14;
                public TTReportField HOSPITALNAME;
                public TTReportField UNIQUEREFNO;
                public TTReportField REASON;
                public TTReportField HOMEADDRESS;
                public TTReportField HOMETOWN;
                public TTReportField HOMECITY;
                public TTReportField LBLSPECIALNO;
                public TTReportField SPECIALNO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 80;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CASHOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 19, 273, 23, false);
                    CASHOFFICENAME.Name = "CASHOFFICENAME";
                    CASHOFFICENAME.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHOFFICENAME.Value = @"{#CASHOFFICENAME#}";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 53, 191, 57, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEENAME.TextFont.Name = "Arial Narrow";
                    PAYEENAME.TextFont.Bold = true;
                    PAYEENAME.TextFont.CharSet = 162;
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 39, 204, 44, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFont.Name = "Arial Narrow";
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    ACCOUNTOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 48, 191, 52, false);
                    ACCOUNTOFFICENAME.Name = "ACCOUNTOFFICENAME";
                    ACCOUNTOFFICENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTOFFICENAME.TextFont.Name = "Arial Narrow";
                    ACCOUNTOFFICENAME.TextFont.Bold = true;
                    ACCOUNTOFFICENAME.TextFont.CharSet = 162;
                    ACCOUNTOFFICENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")
";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 63, 191, 67, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.TextFont.Name = "Arial Narrow";
                    ADDRESS.TextFont.Bold = true;
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 24, 273, 28, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERNAME.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    CASHIERUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 29, 273, 33, false);
                    CASHIERUNIQUEREFNO.Name = "CASHIERUNIQUEREFNO";
                    CASHIERUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    CASHIERUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERUNIQUEREFNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERUNIQUEREFNO.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERUNIQUEREFNO.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERUNIQUEREFNO.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERUNIQUEREFNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERUNIQUEREFNO.Value = @"{#CASHIERUNIQUEREFNO#}";

                    HOSPITALPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 3, 273, 7, false);
                    HOSPITALPROTOCOLNO.Name = "HOSPITALPROTOCOLNO";
                    HOSPITALPROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPITALPROTOCOLNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPITALPROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 8, 273, 12, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTNAME.Value = @"{#PATIENTNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 13, 273, 17, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.Visible = EvetHayirEnum.ehHayir;
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    LBL14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 39, 177, 44, false);
                    LBL14.Name = "LBL14";
                    LBL14.TextFont.Name = "Arial Narrow";
                    LBL14.TextFont.CharSet = 162;
                    LBL14.Value = @"Makbuz No :";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 81, 36, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial Narrow";
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MAKBUZUSTACIKLAMA"", """")
";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 58, 191, 62, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Bold = true;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    REASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 68, 191, 72, false);
                    REASON.Name = "REASON";
                    REASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    REASON.CaseFormat = CaseFormatEnum.fcUpperCase;
                    REASON.TextFont.Name = "Arial Narrow";
                    REASON.TextFont.Bold = true;
                    REASON.TextFont.CharSet = 162;
                    REASON.Value = @"";

                    HOMEADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 3, 332, 7, false);
                    HOMEADDRESS.Name = "HOMEADDRESS";
                    HOMEADDRESS.Visible = EvetHayirEnum.ehHayir;
                    HOMEADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMEADDRESS.Value = @"{#HOMEADDRESS#}";

                    HOMETOWN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 8, 332, 12, false);
                    HOMETOWN.Name = "HOMETOWN";
                    HOMETOWN.Visible = EvetHayirEnum.ehHayir;
                    HOMETOWN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMETOWN.Value = @"{#HOMETOWN#}";

                    HOMECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 14, 332, 18, false);
                    HOMECITY.Name = "HOMECITY";
                    HOMECITY.Visible = EvetHayirEnum.ehHayir;
                    HOMECITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMECITY.Value = @"{#HOMECITY#}";

                    LBLSPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 44, 177, 48, false);
                    LBLSPECIALNO.Name = "LBLSPECIALNO";
                    LBLSPECIALNO.TextFont.Name = "Arial Narrow";
                    LBLSPECIALNO.TextFont.CharSet = 162;
                    LBLSPECIALNO.Value = @"Tahsilat No :";

                    SPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 44, 204, 48, false);
                    SPECIALNO.Name = "SPECIALNO";
                    SPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALNO.TextFont.Name = "Arial Narrow";
                    SPECIALNO.TextFont.CharSet = 162;
                    SPECIALNO.Value = @"{#SPECIALNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptReportQuery_Class dataset_ReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptReportQuery_Class>(0);
                    CASHOFFICENAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.CashOfficeName) : "");
                    PAYEENAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.PayeeName) : "");
                    DOCUMENTNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.DocumentNo) : "");
                    ADDRESS.CalcValue = @"";
                    CASHIERNAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Cashiername) : "");
                    CASHIERUNIQUEREFNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Cashieruniquerefno) : "");
                    HOSPITALPROTOCOLNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.HospitalProtocolNo) : "");
                    PATIENTNAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Patientname) : "");
                    BABAADI.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.FatherName) : "");
                    LBL14.CalcValue = LBL14.Value;
                    UNIQUEREFNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.UniqueRefNo) : "");
                    REASON.CalcValue = @"";
                    HOMEADDRESS.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.HomeAddress) : "");
                    HOMETOWN.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Hometown) : "");
                    HOMECITY.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Homecity) : "");
                    LBLSPECIALNO.CalcValue = LBLSPECIALNO.Value;
                    SPECIALNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.SpecialNo) : "");
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAKBUZUSTACIKLAMA", "")
;
                    return new TTReportObject[] { CASHOFFICENAME,PAYEENAME,DOCUMENTNO,ADDRESS,CASHIERNAME,CASHIERUNIQUEREFNO,HOSPITALPROTOCOLNO,PATIENTNAME,BABAADI,LBL14,UNIQUEREFNO,REASON,HOMEADDRESS,HOMETOWN,HOMECITY,LBLSPECIALNO,SPECIALNO,ACCOUNTOFFICENAME,HOSPITALNAME};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.DOCUMENTNO.CalcValue = AccountDocument.ReceiptDocumentNo(this.DOCUMENTNO.CalcValue);
            
            if(SystemParameter.GetParameterValue("RECEIPTREPORTSHOWSPECIALNO","FALSE") == "TRUE")
            {
                this.SPECIALNO.Visible = EvetHayirEnum.ehEvet;
                this.LBLSPECIALNO.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.SPECIALNO.Visible = EvetHayirEnum.ehHayir;
                this.LBLSPECIALNO.Visible = EvetHayirEnum.ehHayir;
            }
            
            if (string.IsNullOrEmpty(this.PAYEENAME.CalcValue))
                this.PAYEENAME.CalcValue = this.PATIENTNAME.CalcValue;

            // Adres
            this.ADDRESS.CalcValue = string.Empty;

            if (!string.IsNullOrEmpty(this.HOMEADDRESS.CalcValue))
                this.ADDRESS.CalcValue = this.HOMEADDRESS.CalcValue;

            if (!string.IsNullOrEmpty(this.HOMETOWN.CalcValue))
            {
                if (!string.IsNullOrEmpty(this.HOMEADDRESS.CalcValue))
                    this.ADDRESS.CalcValue += " ";

                this.ADDRESS.CalcValue += this.HOMETOWN.CalcValue;
            }

            if (!string.IsNullOrEmpty(this.HOMECITY.CalcValue))
            {
                if (!string.IsNullOrEmpty(this.HOMETOWN.CalcValue))
                    this.ADDRESS.CalcValue += "/";

                this.ADDRESS.CalcValue += " " + this.HOMECITY.CalcValue;
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ReceiptDetailedReport MyParentReport
                {
                    get { return (ReceiptDetailedReport)ParentReport; }
                }
                
                public TTReportField TOTALPAYMENT;
                public TTReportField PRICEWITHLETTERSANDTYPE;
                public TTReportField ACCOUNTOFFICENAMEFOOTER;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIERNAMEFOOTER;
                public TTReportField RECEIPTDOCUMENTOBJECTID;
                public TTReportField ADVANCES;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField PAYMENTTYPE; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPAYMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 5, 205, 10, false);
                    TOTALPAYMENT.Name = "TOTALPAYMENT";
                    TOTALPAYMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPAYMENT.TextFormat = @"#,##0.#0";
                    TOTALPAYMENT.TextFont.Name = "Arial Narrow";
                    TOTALPAYMENT.TextFont.Bold = true;
                    TOTALPAYMENT.TextFont.CharSet = 162;
                    TOTALPAYMENT.Value = @"{#TOTALPAYMENT#}";

                    PRICEWITHLETTERSANDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 15, 200, 20, false);
                    PRICEWITHLETTERSANDTYPE.Name = "PRICEWITHLETTERSANDTYPE";
                    PRICEWITHLETTERSANDTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERSANDTYPE.TextFont.Name = "Arial Narrow";
                    PRICEWITHLETTERSANDTYPE.TextFont.Bold = true;
                    PRICEWITHLETTERSANDTYPE.TextFont.CharSet = 162;
                    PRICEWITHLETTERSANDTYPE.Value = @"";

                    ACCOUNTOFFICENAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 12, 75, 22, false);
                    ACCOUNTOFFICENAMEFOOTER.Name = "ACCOUNTOFFICENAMEFOOTER";
                    ACCOUNTOFFICENAMEFOOTER.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAMEFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTOFFICENAMEFOOTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTOFFICENAMEFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.TextFont.Name = "Arial Narrow";
                    ACCOUNTOFFICENAMEFOOTER.TextFont.Bold = true;
                    ACCOUNTOFFICENAMEFOOTER.TextFont.CharSet = 162;
                    ACCOUNTOFFICENAMEFOOTER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MAKBUZALTACIKLAMA"", """")";

                    RECEIPTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 26, 211, 30, false);
                    RECEIPTDATE.Name = "RECEIPTDATE";
                    RECEIPTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    RECEIPTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECEIPTDATE.TextFont.Name = "Arial Narrow";
                    RECEIPTDATE.TextFont.Bold = true;
                    RECEIPTDATE.TextFont.CharSet = 162;
                    RECEIPTDATE.Value = @"{#DOCUMENTDATE#}";

                    CASHIERNAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 30, 211, 34, false);
                    CASHIERNAMEFOOTER.Name = "CASHIERNAMEFOOTER";
                    CASHIERNAMEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAMEFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERNAMEFOOTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CASHIERNAMEFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERNAMEFOOTER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERNAMEFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERNAMEFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERNAMEFOOTER.TextFont.Name = "Arial Narrow";
                    CASHIERNAMEFOOTER.TextFont.Bold = true;
                    CASHIERNAMEFOOTER.TextFont.CharSet = 162;
                    CASHIERNAMEFOOTER.Value = @"{#CASHIERNAME#}";

                    RECEIPTDOCUMENTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 5, 273, 10, false);
                    RECEIPTDOCUMENTOBJECTID.Name = "RECEIPTDOCUMENTOBJECTID";
                    RECEIPTDOCUMENTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    RECEIPTDOCUMENTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDOCUMENTOBJECTID.Value = @"{#RECEIPTDOCUMENTOBJECTID#}";

                    ADVANCES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 5, 333, 20, false);
                    ADVANCES.Name = "ADVANCES";
                    ADVANCES.Visible = EvetHayirEnum.ehHayir;
                    ADVANCES.FieldType = ReportFieldTypeEnum.ftExpression;
                    ADVANCES.MultiLine = EvetHayirEnum.ehEvet;
                    ADVANCES.WordBreak = EvetHayirEnum.ehEvet;
                    ADVANCES.Value = @"";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 11, 273, 16, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.Value = @"{#TOTALPAYMENT#}";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 17, 273, 22, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.Visible = EvetHayirEnum.ehHayir;
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.ObjectDefName = "PaymentTypeEnum";
                    PAYMENTTYPE.DataMember = "DISPLAYTEXT";
                    PAYMENTTYPE.Value = @"{#PAYMENTTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptReportQuery_Class dataset_ReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptReportQuery_Class>(0);
                    TOTALPAYMENT.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.TotalPayment) : "");
                    PRICEWITHLETTERSANDTYPE.CalcValue = @"";
                    RECEIPTDATE.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.DocumentDate) : "");
                    CASHIERNAMEFOOTER.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Cashiername) : "");
                    RECEIPTDOCUMENTOBJECTID.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Receiptdocumentobjectid) : "");
                    PRICEWITHLETTERS.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.TotalPayment) : "");
                    PAYMENTTYPE.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.PaymentType) : "");
                    PAYMENTTYPE.PostFieldValueCalculation();
                    ACCOUNTOFFICENAMEFOOTER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAKBUZALTACIKLAMA", "");
                    ADVANCES.CalcValue = @"";
                    return new TTReportObject[] { TOTALPAYMENT,PRICEWITHLETTERSANDTYPE,RECEIPTDATE,CASHIERNAMEFOOTER,RECEIPTDOCUMENTOBJECTID,PRICEWITHLETTERS,PAYMENTTYPE,ACCOUNTOFFICENAMEFOOTER,ADVANCES};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    this.PRICEWITHLETTERSANDTYPE.CalcValue = this.PRICEWITHLETTERS.FormattedValue + " - " + this.PAYMENTTYPE.CalcValue;
            
            /*
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.RECEIPTDOCUMENTOBJECTID.CalcValue.ToString();
            AccountDocument accDoc = (AccountDocument)context.GetObject(new Guid(sObjectID),"AccountDocument");
            this.TOTALPAYMENT.CalcValue = (accDoc.GetCalculatedCashPayment(Convert.ToDateTime(accDoc.DocumentDate))).ToString();
            this.PRICEWITHLETTERS.CalcValue = this.TOTALPAYMENT.CalcValue;
            
            string advances = string.Empty;
            string rObjectID = ((ReceiptDetailedReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Receipt receipt = (Receipt)MyParentReport.ReportObjectContext.GetObject(new Guid(rObjectID), typeof(Receipt));
            
            foreach(AdvanceDocument adv in receipt.ReceiptDocument.AdvanceDocuments)
            {
                if(receipt.ReceiptDocument.ResUser != adv.ResUser) // avans alan ile makbuz kesen farklı cashierlog lar ise gösterilir
                {
                    if(advances == string.Empty)
                        advances += "AVANS: ";
                    
                    advances += adv.TotalPrice.ToString() + " ";
                    
                    if(adv.DocumentNo != null)
                        advances += adv.DocumentNo + " ";
                    
                    if(adv.CreditCardDocumentNo != null)
                        advances += adv.CreditCardDocumentNo + " ";
                    
                    advances += adv.ResUser.Name + ", ";
                }
            }
            
            if(advances != string.Empty)
            {
                advances = advances.Substring(0,(advances.Length-2));
                this.ADVANCES.CalcValue = advances;
                this.ADVANCES.Visible = EvetHayirEnum.ehEvet;
            }
            else
                this.ADVANCES.Visible = EvetHayirEnum.ehHayir;
             */
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class DETAILSGroup : TTReportGroup
        {
            public ReceiptDetailedReport MyParentReport
            {
                get { return (ReceiptDetailedReport)ParentReport; }
            }

            new public DETAILSGroupBody Body()
            {
                return (DETAILSGroupBody)_body;
            }
            public TTReportField DESCRIPTION1 { get {return Body().DESCRIPTION1;} }
            public TTReportField DESCRIPTION2 { get {return Body().DESCRIPTION2;} }
            public TTReportField DESCRIPTION3 { get {return Body().DESCRIPTION3;} }
            public TTReportField DESCRIPTION4 { get {return Body().DESCRIPTION4;} }
            public TTReportField DESCRIPTION5 { get {return Body().DESCRIPTION5;} }
            public TTReportField PRICE1 { get {return Body().PRICE1;} }
            public TTReportField PRICE2 { get {return Body().PRICE2;} }
            public TTReportField PRICE3 { get {return Body().PRICE3;} }
            public TTReportField PRICE4 { get {return Body().PRICE4;} }
            public TTReportField PRICE5 { get {return Body().PRICE5;} }
            public TTReportField DESCRIPTION6 { get {return Body().DESCRIPTION6;} }
            public TTReportField PRICE6 { get {return Body().PRICE6;} }
            public DETAILSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DETAILSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DETAILSGroupBody(this);
            }

            public partial class DETAILSGroupBody : TTReportSection
            {
                public ReceiptDetailedReport MyParentReport
                {
                    get { return (ReceiptDetailedReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION1;
                public TTReportField DESCRIPTION2;
                public TTReportField DESCRIPTION3;
                public TTReportField DESCRIPTION4;
                public TTReportField DESCRIPTION5;
                public TTReportField PRICE1;
                public TTReportField PRICE2;
                public TTReportField PRICE3;
                public TTReportField PRICE4;
                public TTReportField PRICE5;
                public TTReportField DESCRIPTION6;
                public TTReportField PRICE6; 
                public DETAILSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 24;
                    RepeatCount = 0;
                    
                    DESCRIPTION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 183, 4, false);
                    DESCRIPTION1.Name = "DESCRIPTION1";
                    DESCRIPTION1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1.TextFont.Name = "Arial Narrow";
                    DESCRIPTION1.TextFont.Bold = true;
                    DESCRIPTION1.TextFont.CharSet = 162;
                    DESCRIPTION1.Value = @"";

                    DESCRIPTION2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 4, 183, 8, false);
                    DESCRIPTION2.Name = "DESCRIPTION2";
                    DESCRIPTION2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION2.TextFont.Name = "Arial Narrow";
                    DESCRIPTION2.TextFont.Bold = true;
                    DESCRIPTION2.TextFont.CharSet = 162;
                    DESCRIPTION2.Value = @"";

                    DESCRIPTION3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 8, 183, 12, false);
                    DESCRIPTION3.Name = "DESCRIPTION3";
                    DESCRIPTION3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION3.TextFont.Name = "Arial Narrow";
                    DESCRIPTION3.TextFont.Bold = true;
                    DESCRIPTION3.TextFont.CharSet = 162;
                    DESCRIPTION3.Value = @"";

                    DESCRIPTION4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 12, 183, 16, false);
                    DESCRIPTION4.Name = "DESCRIPTION4";
                    DESCRIPTION4.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION4.TextFont.Name = "Arial Narrow";
                    DESCRIPTION4.TextFont.Bold = true;
                    DESCRIPTION4.TextFont.CharSet = 162;
                    DESCRIPTION4.Value = @"";

                    DESCRIPTION5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 16, 183, 20, false);
                    DESCRIPTION5.Name = "DESCRIPTION5";
                    DESCRIPTION5.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION5.TextFont.Name = "Arial Narrow";
                    DESCRIPTION5.TextFont.Bold = true;
                    DESCRIPTION5.TextFont.CharSet = 162;
                    DESCRIPTION5.Value = @"";

                    PRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 205, 4, false);
                    PRICE1.Name = "PRICE1";
                    PRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1.TextFormat = @"#,##0.#0";
                    PRICE1.TextFont.Name = "Arial Narrow";
                    PRICE1.TextFont.Bold = true;
                    PRICE1.TextFont.CharSet = 162;
                    PRICE1.Value = @"";

                    PRICE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 4, 205, 8, false);
                    PRICE2.Name = "PRICE2";
                    PRICE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE2.TextFormat = @"#,##0.#0";
                    PRICE2.TextFont.Name = "Arial Narrow";
                    PRICE2.TextFont.Bold = true;
                    PRICE2.TextFont.CharSet = 162;
                    PRICE2.Value = @"";

                    PRICE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 8, 205, 12, false);
                    PRICE3.Name = "PRICE3";
                    PRICE3.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE3.TextFormat = @"#,##0.#0";
                    PRICE3.TextFont.Name = "Arial Narrow";
                    PRICE3.TextFont.Bold = true;
                    PRICE3.TextFont.CharSet = 162;
                    PRICE3.Value = @"";

                    PRICE4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 12, 205, 16, false);
                    PRICE4.Name = "PRICE4";
                    PRICE4.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE4.TextFormat = @"#,##0.#0";
                    PRICE4.TextFont.Name = "Arial Narrow";
                    PRICE4.TextFont.Bold = true;
                    PRICE4.TextFont.CharSet = 162;
                    PRICE4.Value = @"";

                    PRICE5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 16, 205, 20, false);
                    PRICE5.Name = "PRICE5";
                    PRICE5.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE5.TextFormat = @"#,##0.#0";
                    PRICE5.TextFont.Name = "Arial Narrow";
                    PRICE5.TextFont.Bold = true;
                    PRICE5.TextFont.CharSet = 162;
                    PRICE5.Value = @"";

                    DESCRIPTION6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 20, 183, 24, false);
                    DESCRIPTION6.Name = "DESCRIPTION6";
                    DESCRIPTION6.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION6.TextFont.Name = "Arial Narrow";
                    DESCRIPTION6.TextFont.Bold = true;
                    DESCRIPTION6.TextFont.CharSet = 162;
                    DESCRIPTION6.Value = @"";

                    PRICE6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 20, 205, 24, false);
                    PRICE6.Name = "PRICE6";
                    PRICE6.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE6.TextFormat = @"#,##0.#0";
                    PRICE6.TextFont.Name = "Arial Narrow";
                    PRICE6.TextFont.Bold = true;
                    PRICE6.TextFont.CharSet = 162;
                    PRICE6.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTION1.CalcValue = @"";
                    DESCRIPTION2.CalcValue = @"";
                    DESCRIPTION3.CalcValue = @"";
                    DESCRIPTION4.CalcValue = @"";
                    DESCRIPTION5.CalcValue = @"";
                    PRICE1.CalcValue = @"";
                    PRICE2.CalcValue = @"";
                    PRICE3.CalcValue = @"";
                    PRICE4.CalcValue = @"";
                    PRICE5.CalcValue = @"";
                    DESCRIPTION6.CalcValue = @"";
                    PRICE6.CalcValue = @"";
                    return new TTReportObject[] { DESCRIPTION1,DESCRIPTION2,DESCRIPTION3,DESCRIPTION4,DESCRIPTION5,PRICE1,PRICE2,PRICE3,PRICE4,PRICE5,DESCRIPTION6,PRICE6};
                }

                public override void RunScript()
                {
#region DETAILS BODY_Script
                    Receipt receipt = (Receipt)MyParentReport.ReportObjectContext.GetObject(new Guid(((ReceiptDetailedReport)ParentReport).RuntimeParameters.TTOBJECTID), "Receipt");

            int rowCount = 6;
            bool detailFound = false;
            string description = string.Empty;
            bool isHealthTourism = false;

            const string otherDescription = "600.01.99 - Diğer Sağlık Hizmet Gelirleri";
            const string otherDescriptionHealthTourism = "601.01.99 - Diğer Sağlık Hizmet Gelirleri";
            const string BKKPrimBorcuOlanlar = "600.01.94 - Cumhurbaşkanlığı Kararı İle Muaf Tut. Has. Kat. Pay. Gelirler";
            const string PrvAlinanSGKKatılımPayı = "336.06.01 - Provizyon Alınan SGK Katılım Payları";
            const string PrvAlinmayanSGKKatılımPayı = "336.06.02 - Provizyon Alınmayan SGK Katılım Payları";
            const string IlacGelirleri = "600.01.08.01 - İlaç Gelirleri";
            const string SarfMalzemeGelirleri = "600.01.08.02 - Tıbbi Sarf Malzemesi Gelirleri";

            //string showdetail = SystemParameter.GetParameterValue("RECEIPTREPORTSHOWDETAILS", "TRUE"); // Rapor hizmet detayında dökülmediği için kaldırıldı

            ((ReceiptDetailedReport)ParentReport).detailList.Clear();
            ((ReceiptDetailedReport)ParentReport).printList.Clear();

            foreach (ReceiptDocumentGroup recGroup in receipt.ReceiptDocument.ReceiptDocumentGroups)
            {
                foreach (ReceiptDocumentDetail receiptDetail in recGroup.ReceiptDocumentDetails)
                {
                    description = otherDescription;
                    AccountTransaction accTrx = receiptDetail.AccountTrxDocument[0].AccountTransaction;

                    PayerTypeEnum payerType = accTrx.SubEpisodeProtocol.Payer.Type.PayerType.Value;

                    if (accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.ProcedureObject != null)
                    {   // SGK lı hastadan alınmış katılım payı ise
                        if ((payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual) && (receiptDetail.IsParticipationShare == true || accTrx.SubActionProcedure.ProcedureObject.ParticipationProcedure == true))
                        {
                            if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                            {
                                if (accTrx.SubEpisodeProtocol?.MedulaIstisnaiHal?.Kodu == "9")  // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                    description = BKKPrimBorcuOlanlar;
                                else
                                    description = PrvAlinanSGKKatılımPayı;
                            }
                            else
                                description = PrvAlinmayanSGKKatılımPayı;
                        }
                        else
                        {
                            RevenueSubAccountCodeDefinition revenue = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                            if (revenue != null)
                            {
                                string accountCode = revenue.AccountCode;
                                string accountDescription = revenue.Description;

                                if (accountCode.Equals("600.01.01") || accountCode.Equals("600.01.02") || accountCode.Equals("600.01.03") || accountCode.Equals("600.01.04") || accountCode.Equals("600.01.05"))
                                {
                                    if (accTrx.SubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu.Equals("A"))
                                    {
                                        accountCode += ".01";
                                        accountDescription = "Ayaktan Hasta " + accountDescription;
                                    }
                                    else
                                    {
                                        accountCode += ".02";
                                        accountDescription = "Yatan Hasta " + accountDescription;
                                    }
                                }
                                else if (accountCode.Equals("600.01.06") || accountCode.Equals("600.01.07"))
                                {
                                    accountCode += ".01";
                                    accountDescription = "Yatan Hasta " + accountDescription;
                                }

                                description = accountCode + " - " + accountDescription;
                            }
                        }
                    }
                    else if (accTrx.SubActionMaterial != null)
                    {
                        if ((payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual) && receiptDetail.IsParticipationShare == true)
                        {
                            if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                            {
                                if (accTrx.SubEpisodeProtocol?.MedulaIstisnaiHal?.Kodu == "9")  // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                    description = BKKPrimBorcuOlanlar;
                                else
                                    description = PrvAlinanSGKKatılımPayı;
                            }
                            else
                                description = PrvAlinmayanSGKKatılımPayı;
                        }
                        else if (accTrx.SubActionMaterial.Material is DrugDefinition || accTrx.SubActionMaterial.Material is MagistralPreparationDefinition)
                            description = IlacGelirleri;
                        else
                            description = SarfMalzemeGelirleri;
                    }

                    // Kurum Sağlık Turizmi ise
                    if (accTrx.SubEpisodeProtocol.Payer.HealthTourism == true)
                    {
                        if (description.StartsWith("600.") && description != BKKPrimBorcuOlanlar)  // Sağlık Turizmi için hesap kodunun başı 601 olarak değiştirilir
                            description = "601." + description.Substring(4, description.Length - 4);

                        isHealthTourism = true; // Makbuzdaki hizmetlerden birinin kurumu Sağlık Turizmi ise tüm makbuz o şekilde değerlendirilir
                    }

                    detailFound = false;
                    foreach (Detail detail in ((ReceiptDetailedReport)ParentReport).detailList)
                    {
                        if (detail.Description.Equals(description))
                        {
                            detail.Price += receiptDetail.PaymentPrice.Value;
                            detailFound = true;
                            break;
                        }
                    }

                    if (!detailFound)
                    {
                        int orderNo = ((ReceiptDetailedReport)ParentReport).detailList.Count;

                        if (description.Equals(otherDescription) || description.Equals(otherDescriptionHealthTourism))
                            orderNo = int.MaxValue;

                        ((ReceiptDetailedReport)ParentReport).detailList.Add(new Detail(orderNo, description, receiptDetail.PaymentPrice.Value));
                    }
                }
            }

            // detailList te "600.01.99 - Diğer Sağlık Hizmet Gelirleri" grubu varsa listenin en sonuna gitsin diye sıralanır
            ((ReceiptDetailedReport)ParentReport).detailList = ((ReceiptDetailedReport)ParentReport).detailList.OrderBy(x => x.OrderNo).ToList();

            // detailList in sayısı rowCount tan büyüks, eleman sayısı rowCount a eşit olacak şekilde printList ayarlanır
            // küçükeşitse printList direkt detailList ile eşitlenir
            if (((ReceiptDetailedReport)ParentReport).detailList.Count > rowCount)
            {
                foreach (Detail detail in ((ReceiptDetailedReport)ParentReport).detailList)
                {
                    if (((ReceiptDetailedReport)ParentReport).printList.Count < rowCount - 1)
                        ((ReceiptDetailedReport)ParentReport).printList.Add(detail);
                    else
                    {
                        // "600.01.99 / 601.01.99 - Diğer Sağlık Hizmet Gelirleri" grubu eklenir
                        if (((ReceiptDetailedReport)ParentReport).printList.Count == rowCount - 1)
                        {
                            string otherDesc = otherDescription;
                            if (isHealthTourism)
                                otherDesc = otherDescriptionHealthTourism;

                            ((ReceiptDetailedReport)ParentReport).printList.Add(new Detail(rowCount - 1, otherDesc, 0));
                        }

                        // Eklenen "600.01.99 / 601.01.99 - Diğer Sağlık Hizmet Gelirleri" grubunun tutarı artırılır
                        ((ReceiptDetailedReport)ParentReport).printList[rowCount - 1].Price += detail.Price;
                    }
                }
            }
            else
                ((ReceiptDetailedReport)ParentReport).printList = ((ReceiptDetailedReport)ParentReport).detailList;

            // Detay satırları doldurulur
            int i = 1;
            TTReportField fieldDesc;
            TTReportField fieldPrice;

            foreach (Detail detail in ((ReceiptDetailedReport)ParentReport).printList)
            {
                fieldDesc = this.FieldsByName("DESCRIPTION" + i.ToString());
                fieldPrice = this.FieldsByName("PRICE" + i.ToString());

                fieldDesc.CalcValue = detail.Description;
                fieldPrice.CalcValue = detail.Price.ToString();
                i++;
            }
#endregion DETAILS BODY_Script
                }
            }

        }

        public DETAILSGroup DETAILS;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ReceiptDetailedReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            DETAILS = new DETAILSGroup(HEADER,"DETAILS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RECEIPTDETAILEDREPORT";
            Caption = "Muhasebe Yetkilisi Mutemedi Alındısı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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