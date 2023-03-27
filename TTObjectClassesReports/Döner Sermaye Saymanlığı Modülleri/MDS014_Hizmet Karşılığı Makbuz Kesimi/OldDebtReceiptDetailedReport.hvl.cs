
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
    public partial class OldDebtReceiptDetailedReport : TTReport
    {
#region Methods
   public List<Detail> detailList = new List<Detail>();
        
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
            public OldDebtReceiptDetailedReport MyParentReport
            {
                get { return (OldDebtReceiptDetailedReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ACCOUNTOFFICENAME { get {return Header().ACCOUNTOFFICENAME;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField LBL14 { get {return Header().LBL14;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField REASON { get {return Header().REASON;} }
            public TTReportField TOTALPAYMENT { get {return Footer().TOTALPAYMENT;} }
            public TTReportField PRICEWITHLETTERSANDTYPE { get {return Footer().PRICEWITHLETTERSANDTYPE;} }
            public TTReportField ACCOUNTOFFICENAMEFOOTER { get {return Footer().ACCOUNTOFFICENAMEFOOTER;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIERNAMEFOOTER { get {return Footer().CASHIERNAMEFOOTER;} }
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
                list[0] = new TTReportNqlData<PatientOldDebt.OldDebtReceiptReportQuery_Class>("OldDebtReceiptReportQuery", PatientOldDebt.OldDebtReceiptReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OldDebtReceiptDetailedReport MyParentReport
                {
                    get { return (OldDebtReceiptDetailedReport)ParentReport; }
                }
                
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField ADDRESS;
                public TTReportField LBL14;
                public TTReportField HOSPITALNAME;
                public TTReportField UNIQUEREFNO;
                public TTReportField REASON; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 80;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
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
                    ADDRESS.Value = @"{#HOMEADDRESS#}";

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
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MAKBUZUSTACIKLAMA"", """")";

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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientOldDebt.OldDebtReceiptReportQuery_Class dataset_OldDebtReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PatientOldDebt.OldDebtReceiptReportQuery_Class>(0);
                    PAYEENAME.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.Payeename) : "");
                    DOCUMENTNO.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.DocumentNo) : "");
                    ADDRESS.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.HomeAddress) : "");
                    LBL14.CalcValue = LBL14.Value;
                    UNIQUEREFNO.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.Uniquerefno) : "");
                    REASON.CalcValue = @"";
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAKBUZUSTACIKLAMA", "");
                    return new TTReportObject[] { PAYEENAME,DOCUMENTNO,ADDRESS,LBL14,UNIQUEREFNO,REASON,ACCOUNTOFFICENAME,HOSPITALNAME};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.DOCUMENTNO.CalcValue = AccountDocument.ReceiptDocumentNo(this.DOCUMENTNO.CalcValue);
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public OldDebtReceiptDetailedReport MyParentReport
                {
                    get { return (OldDebtReceiptDetailedReport)ParentReport; }
                }
                
                public TTReportField TOTALPAYMENT;
                public TTReportField PRICEWITHLETTERSANDTYPE;
                public TTReportField ACCOUNTOFFICENAMEFOOTER;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIERNAMEFOOTER;
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

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 11, 273, 16, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.TextFont.Name = "Arial Narrow";
                    PRICEWITHLETTERS.TextFont.Bold = true;
                    PRICEWITHLETTERS.TextFont.CharSet = 162;
                    PRICEWITHLETTERS.Value = @"{#TOTALPAYMENT#}";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 17, 273, 22, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.Visible = EvetHayirEnum.ehHayir;
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.ObjectDefName = "PaymentTypeEnum";
                    PAYMENTTYPE.DataMember = "DISPLAYTEXT";
                    PAYMENTTYPE.TextFont.Name = "Arial Narrow";
                    PAYMENTTYPE.TextFont.Bold = true;
                    PAYMENTTYPE.TextFont.CharSet = 162;
                    PAYMENTTYPE.Value = @"{#PAYMENTTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientOldDebt.OldDebtReceiptReportQuery_Class dataset_OldDebtReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PatientOldDebt.OldDebtReceiptReportQuery_Class>(0);
                    TOTALPAYMENT.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.Totalpayment) : "");
                    PRICEWITHLETTERSANDTYPE.CalcValue = @"";
                    RECEIPTDATE.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.DocumentDate) : "");
                    CASHIERNAMEFOOTER.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.Cashiername) : "");
                    PRICEWITHLETTERS.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.Totalpayment) : "");
                    PAYMENTTYPE.CalcValue = (dataset_OldDebtReceiptReportQuery != null ? Globals.ToStringCore(dataset_OldDebtReceiptReportQuery.PaymentType) : "");
                    PAYMENTTYPE.PostFieldValueCalculation();
                    ACCOUNTOFFICENAMEFOOTER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAKBUZALTACIKLAMA", "");
                    return new TTReportObject[] { TOTALPAYMENT,PRICEWITHLETTERSANDTYPE,RECEIPTDATE,CASHIERNAMEFOOTER,PRICEWITHLETTERS,PAYMENTTYPE,ACCOUNTOFFICENAMEFOOTER};
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
            public OldDebtReceiptDetailedReport MyParentReport
            {
                get { return (OldDebtReceiptDetailedReport)ParentReport; }
            }

            new public DETAILSGroupBody Body()
            {
                return (DETAILSGroupBody)_body;
            }
            public TTReportField DESCRIPTION1 { get {return Body().DESCRIPTION1;} }
            public TTReportField PRICE1 { get {return Body().PRICE1;} }
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
                public OldDebtReceiptDetailedReport MyParentReport
                {
                    get { return (OldDebtReceiptDetailedReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION1;
                public TTReportField PRICE1; 
                public DETAILSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 24;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESCRIPTION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 183, 4, false);
                    DESCRIPTION1.Name = "DESCRIPTION1";
                    DESCRIPTION1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1.TextFont.Name = "Arial Narrow";
                    DESCRIPTION1.TextFont.Bold = true;
                    DESCRIPTION1.TextFont.CharSet = 162;
                    DESCRIPTION1.Value = @"";

                    PRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 205, 4, false);
                    PRICE1.Name = "PRICE1";
                    PRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1.TextFormat = @"#,##0.#0";
                    PRICE1.TextFont.Name = "Arial Narrow";
                    PRICE1.TextFont.Bold = true;
                    PRICE1.TextFont.CharSet = 162;
                    PRICE1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTION1.CalcValue = @"";
                    PRICE1.CalcValue = @"";
                    return new TTReportObject[] { DESCRIPTION1,PRICE1};
                }

                public override void RunScript()
                {
#region DETAILS BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string pObjectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            List<PatientOldDebt> oldDebts = (List<PatientOldDebt>)context.QueryObjects<PatientOldDebt>("PATIENT = '" + new Guid(pObjectID) + "'").ToList();
            
            this.DESCRIPTION1.CalcValue = "600.01.99 - Diğer Sağlık Hizmet Gelirleri";
            this.PRICE1.CalcValue = oldDebts[0].OldDebtReceiptDocument.TotalPrice.ToString();
            
            
//            int rowCount = 5;
//            int detailcount = 0;
//            bool detailFound = false;
//            string description = string.Empty;
//            string otherDescription = string.Empty;
//            string showdetail = SystemParameter.GetParameterValue("RECEIPTREPORTSHOWDETAILS", "TRUE");
//
//            ((ReceiptDetailedReport)ParentReport).detailList.Clear();
//
//            foreach (ReceiptDocumentGroup recGroup in rec.ReceiptDocument.ReceiptDocumentGroups)
//                detailcount += recGroup.ReceiptDocumentDetails.Count;
//
//            //if (detailcount <= rowCount) // Detay sayısı satır sayısından küçükeşit ise makbuz detaylı dökülür
//            //    showdetail = "TRUE";
//
//            if (showdetail.Equals("TRUE"))
//                otherDescription = "Diğer Sağlık Hizmet Gelirleri";
//            else
//                otherDescription = "600.01.99 - Diğer Sağlık Hizmet Gelirleri";
//
//            foreach (ReceiptDocumentGroup recGroup in rec.ReceiptDocument.ReceiptDocumentGroups)
//            {
//                foreach (ReceiptDocumentDetail receiptDetail in recGroup.ReceiptDocumentDetails)
//                {
//                    description = otherDescription;
//
//                    if (showdetail.Equals("TRUE"))
//                    {
//                        if (detailcount <= rowCount || ((ReceiptDetailedReport)ParentReport).detailList.Count < rowCount - 1)
//                            description = receiptDetail.ExternalCode + " " + receiptDetail.Description;
//                    }
//                    else
//                    {
//                        if (((ReceiptDetailedReport)ParentReport).detailList.Count < rowCount - 1)
//                        {
//                            AccountTransaction accTrx = receiptDetail.AccountTrxDocument[0].AccountTransaction;
//                            PayerTypeEnum payerType = accTrx.SubEpisodeProtocol.Payer.Type.PayerType.Value;
//                            
//                            if (accTrx.SubActionProcedure != null)
//                            {
//                                if (receiptDetail.IsParticipationShare == true && (payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual))
//                                {
//                                    if (payerType == PayerTypeEnum.SGK)
//                                        description = "336.06.01 - Provizyon Alınan SGK Katılım Payları";
//                                    else
//                                        description = "336.06.02 - Provizyon Alınmayan SGK Katılım Payları";
//                                }
//                                else if (accTrx.SubActionProcedure.ProcedureObject != null)
//                                {
//                                    RevenueSubAccountCodeDefinition revenue = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
//                                    if (revenue != null)
//                                    {
//                                        string accountCode = revenue.AccountCode;
//                                        string accountDescription = revenue.Description;
//
//                                        if (accountCode.Equals("600.01.01") || accountCode.Equals("600.01.02") || accountCode.Equals("600.01.03") || accountCode.Equals("600.01.04") || accountCode.Equals("600.01.05"))
//                                        {
//                                            if (rec.Episode.PatientStatus == PatientStatusEnum.Outpatient)
//                                            {
//                                                accountCode += ".01";
//                                                accountDescription = "Ayaktan Hasta " + accountDescription;
//                                            }
//                                            else
//                                            {
//                                                accountCode += ".02";
//                                                accountDescription = "Yatan Hasta " + accountDescription;
//                                            }
//                                        }
//                                        else if (accountCode.Equals("600.01.06") || accountCode.Equals("600.01.07"))
//                                        {
//                                            accountCode += ".01";
//                                            accountDescription = "Yatan Hasta " + accountDescription;
//                                        }
//
//                                        description = accountCode + " - " + accountDescription;
//                                    }
//                                }
//                            }
//                            else if (accTrx.SubActionMaterial != null)
//                            {
//                                if (receiptDetail.IsParticipationShare == true && (payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual))
//                                {
//                                    if (payerType == PayerTypeEnum.SGK)
//                                        description = "336.06.01 - Provizyon Alınan SGK Katılım Payları";
//                                    else
//                                        description = "336.06.02 - Provizyon Alınmayan SGK Katılım Payları";
//                                }
//                                else if(accTrx.SubActionMaterial.Material is DrugDefinition || accTrx.SubActionMaterial.Material is MagistralPreparationDefinition)
//                                    description = "600.01.08.01 - İlaç Gelirleri";
//                                else
//                                    description = "600.01.08.02 - Tıbbi Sarf Malzemesi Gelirleri";
//                            }
//                        }
//                    }
//
//                    detailFound = false;
//                    if (showdetail.Equals("FALSE") || detailcount > rowCount) // Detaylı döküm alınacak ve detay sayısı row sayısından küçükeşitse gruplama yapmasın
//                    {
//                        foreach (Detail detail in ((ReceiptDetailedReport)ParentReport).detailList)
//                        {
//                            if (detail.Description.Equals(description))
//                            {
//                                detail.Price += receiptDetail.PaymentPrice.Value;
//                                detailFound = true;
//                                break;
//                            }
//                        }
//                    }
//
//                    if (!detailFound)
//                    {
//                        int orderNo = ((ReceiptDetailedReport)ParentReport).detailList.Count;
//
//                        if (description.Equals(otherDescription))
//                            orderNo = int.MaxValue;
//
//                        ((ReceiptDetailedReport)ParentReport).detailList.Add(new Detail(orderNo, description, receiptDetail.PaymentPrice.Value));
//                    }
//                }
//            }
//
//            int i = 1;
//            TTReportField fieldDesc;
//            TTReportField fieldPrice;
//
//            ((ReceiptDetailedReport)ParentReport).detailList = ((ReceiptDetailedReport)ParentReport).detailList.OrderBy(x => x.OrderNo).ToList();
//
//            foreach (Detail detail in ((ReceiptDetailedReport)ParentReport).detailList)
//            {
//                fieldDesc = this.FieldsByName("DESCRIPTION" + i.ToString());
//                fieldPrice = this.FieldsByName("PRICE" + i.ToString());
//
//                fieldDesc.CalcValue = detail.Description;
//                fieldPrice.CalcValue = detail.Price.ToString();
//                i++;
//            }
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

        public OldDebtReceiptDetailedReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            DETAILS = new DETAILSGroup(HEADER,"DETAILS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Patient ObjectID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "OLDDEBTRECEIPTDETAILEDREPORT";
            Caption = "Eski Hasta Borcu Raporu";
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