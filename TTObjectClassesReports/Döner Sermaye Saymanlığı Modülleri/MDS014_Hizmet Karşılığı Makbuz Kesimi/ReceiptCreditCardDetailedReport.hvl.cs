
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
    /// Makbuz KK Raporu (Detaylı)
    /// </summary>
    public partial class ReceiptCreditCardDetailedReport : TTReport
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
            public ReceiptCreditCardDetailedReport MyParentReport
            {
                get { return (ReceiptCreditCardDetailedReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField RECEIPTSPECIALNO { get {return Header().RECEIPTSPECIALNO;} }
            public TTReportField CARDOWNER { get {return Header().CARDOWNER;} }
            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ACCOUNTOFFICENAME { get {return Header().ACCOUNTOFFICENAME;} }
            public TTReportField KK1 { get {return Header().KK1;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField TOTALPRICE1 { get {return Footer().TOTALPRICE1;} }
            public TTReportField ACCOUNTANTTITLE111 { get {return Footer().ACCOUNTANTTITLE111;} }
            public TTReportField ADVANCES { get {return Footer().ADVANCES;} }
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
                list[0] = new TTReportNqlData<Receipt.ReceiptCreditCardReportQuery_Class>("ReceiptCreditCardReportQuery", Receipt.ReceiptCreditCardReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ReceiptCreditCardDetailedReport MyParentReport
                {
                    get { return (ReceiptCreditCardDetailedReport)ParentReport; }
                }
                
                public TTReportField RECEIPTSPECIALNO;
                public TTReportField CARDOWNER;
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField KK1;
                public TTReportField TCKIMLIKNO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RECEIPTSPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 22, 183, 27, false);
                    RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
                    RECEIPTSPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTSPECIALNO.Value = @"{#CREDITCARDSPECIALNO#}";

                    CARDOWNER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 31, 164, 36, false);
                    CARDOWNER.Name = "CARDOWNER";
                    CARDOWNER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDOWNER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CARDOWNER.Value = @"{#CARDOWNER#}";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 36, 164, 41, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEENAME.MultiLine = EvetHayirEnum.ehEvet;
                    PAYEENAME.NoClip = EvetHayirEnum.ehEvet;
                    PAYEENAME.WordBreak = EvetHayirEnum.ehEvet;
                    PAYEENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 15, 183, 20, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#CREDITCARDDOCUMENTNO#}";

                    ACCOUNTOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 112, 17, false);
                    ACCOUNTOFFICENAME.Name = "ACCOUNTOFFICENAME";
                    ACCOUNTOFFICENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")
";

                    KK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 22, 113, 27, false);
                    KK1.Name = "KK1";
                    KK1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KK1.Value = @"KREDİ KARTI TAHSİLATI";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 41, 164, 45, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptCreditCardReportQuery_Class dataset_ReceiptCreditCardReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptCreditCardReportQuery_Class>(0);
                    RECEIPTSPECIALNO.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.CreditCardSpecialNo) : "");
                    CARDOWNER.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.Cardowner) : "");
                    PAYEENAME.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.PayeeName) : "");
                    DOCUMENTNO.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.CreditCardDocumentNo) : "");
                    KK1.CalcValue = KK1.Value;
                    TCKIMLIKNO.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.UniqueRefNo) : "");
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    return new TTReportObject[] { RECEIPTSPECIALNO,CARDOWNER,PAYEENAME,DOCUMENTNO,KK1,TCKIMLIKNO,ACCOUNTOFFICENAME};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ReceiptCreditCardDetailedReport MyParentReport
                {
                    get { return (ReceiptCreditCardDetailedReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField DESC;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIERNAME;
                public TTReportField ACCOUNTANT;
                public TTReportField TOTALPRICE1;
                public TTReportField ACCOUNTANTTITLE111;
                public TTReportField ADVANCES; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 5, 178, 10, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.Value = @"{#CREDITCARDPAYMENT#}";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 151, 17, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.Value = @"{%TOTALPRICE1%}";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 12, 269, 17, false);
                    DESC.Name = "DESC";
                    DESC.Visible = EvetHayirEnum.ehHayir;
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")";

                    RECEIPTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 20, 109, 25, false);
                    RECEIPTDATE.Name = "RECEIPTDATE";
                    RECEIPTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDATE.TextFormat = @"Short Date";
                    RECEIPTDATE.Value = @"{#DOCUMENTDATE#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 24, 190, 29, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERNAME.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 56, 25, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""ACCOUNTANT"", """")
";

                    TOTALPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 4, 251, 9, false);
                    TOTALPRICE1.Name = "TOTALPRICE1";
                    TOTALPRICE1.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE1.Value = @"{#CREDITCARDPAYMENT#}";

                    ACCOUNTANTTITLE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 29, 190, 33, false);
                    ACCOUNTANTTITLE111.Name = "ACCOUNTANTTITLE111";
                    ACCOUNTANTTITLE111.Value = @"Dön. Ser. Muh. Yet. Mut.";

                    ADVANCES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 147, 11, false);
                    ADVANCES.Name = "ADVANCES";
                    ADVANCES.FieldType = ReportFieldTypeEnum.ftExpression;
                    ADVANCES.MultiLine = EvetHayirEnum.ehEvet;
                    ADVANCES.WordBreak = EvetHayirEnum.ehEvet;
                    ADVANCES.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptCreditCardReportQuery_Class dataset_ReceiptCreditCardReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptCreditCardReportQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.Creditcardpayment) : "");
                    TOTALPRICE1.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.Creditcardpayment) : "");
                    PRICEWITHLETTERS.CalcValue = MyParentReport.HEADER.TOTALPRICE1.CalcValue;
                    RECEIPTDATE.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.DocumentDate) : "");
                    CASHIERNAME.CalcValue = (dataset_ReceiptCreditCardReportQuery != null ? Globals.ToStringCore(dataset_ReceiptCreditCardReportQuery.Cashiername) : "");
                    ACCOUNTANTTITLE111.CalcValue = ACCOUNTANTTITLE111.Value;
                    DESC.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");
                    ACCOUNTANT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "")
;
                    ADVANCES.CalcValue = @"";
                    return new TTReportObject[] { TOTALPRICE,TOTALPRICE1,PRICEWITHLETTERS,RECEIPTDATE,CASHIERNAME,ACCOUNTANTTITLE111,DESC,ACCOUNTANT,ADVANCES};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    string advances = string.Empty;
            
            string rObjectID = ((ReceiptCreditCardDetailedReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ReceiptCreditCardDetailedReport MyParentReport
            {
                get { return (ReceiptCreditCardDetailedReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
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
                list[0] = new TTReportNqlData<Receipt.ReceiptDetailsQuery_Class>("ReceiptDetailsQuery", Receipt.ReceiptDetailsQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ReceiptCreditCardDetailedReport MyParentReport
                {
                    get { return (ReceiptCreditCardDetailedReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 2;
                    RepeatWidth = 60;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 66, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 150, 4, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#TOTALDISCOUNTEDPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptDetailsQuery_Class dataset_ReceiptDetailsQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptDetailsQuery_Class>(0);
                    DESCRIPTION.CalcValue = (dataset_ReceiptDetailsQuery != null ? Globals.ToStringCore(dataset_ReceiptDetailsQuery.Description) : "");
                    PRICE.CalcValue = (dataset_ReceiptDetailsQuery != null ? Globals.ToStringCore(dataset_ReceiptDetailsQuery.TotalDiscountedPrice) : "");
                    return new TTReportObject[] { DESCRIPTION,PRICE};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class DETAILSGroup : TTReportGroup
        {
            public ReceiptCreditCardDetailedReport MyParentReport
            {
                get { return (ReceiptCreditCardDetailedReport)ParentReport; }
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
            public TTReportField DESCRIPTION6 { get {return Body().DESCRIPTION6;} }
            public TTReportField DESCRIPTION7 { get {return Body().DESCRIPTION7;} }
            public TTReportField DESCRIPTION8 { get {return Body().DESCRIPTION8;} }
            public TTReportField DESCRIPTION9 { get {return Body().DESCRIPTION9;} }
            public TTReportField DESCRIPTION10 { get {return Body().DESCRIPTION10;} }
            public TTReportField PRICE1 { get {return Body().PRICE1;} }
            public TTReportField PRICE2 { get {return Body().PRICE2;} }
            public TTReportField PRICE3 { get {return Body().PRICE3;} }
            public TTReportField PRICE4 { get {return Body().PRICE4;} }
            public TTReportField PRICE5 { get {return Body().PRICE5;} }
            public TTReportField PRICE6 { get {return Body().PRICE6;} }
            public TTReportField PRICE7 { get {return Body().PRICE7;} }
            public TTReportField PRICE8 { get {return Body().PRICE8;} }
            public TTReportField PRICE9 { get {return Body().PRICE9;} }
            public TTReportField PRICE10 { get {return Body().PRICE10;} }
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
                public ReceiptCreditCardDetailedReport MyParentReport
                {
                    get { return (ReceiptCreditCardDetailedReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION1;
                public TTReportField DESCRIPTION2;
                public TTReportField DESCRIPTION3;
                public TTReportField DESCRIPTION4;
                public TTReportField DESCRIPTION5;
                public TTReportField DESCRIPTION6;
                public TTReportField DESCRIPTION7;
                public TTReportField DESCRIPTION8;
                public TTReportField DESCRIPTION9;
                public TTReportField DESCRIPTION10;
                public TTReportField PRICE1;
                public TTReportField PRICE2;
                public TTReportField PRICE3;
                public TTReportField PRICE4;
                public TTReportField PRICE5;
                public TTReportField PRICE6;
                public TTReportField PRICE7;
                public TTReportField PRICE8;
                public TTReportField PRICE9;
                public TTReportField PRICE10; 
                public DETAILSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    DESCRIPTION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 73, 4, false);
                    DESCRIPTION1.Name = "DESCRIPTION1";
                    DESCRIPTION1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1.TextFont.CharSet = 162;
                    DESCRIPTION1.Value = @"";

                    DESCRIPTION2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 73, 8, false);
                    DESCRIPTION2.Name = "DESCRIPTION2";
                    DESCRIPTION2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION2.TextFont.CharSet = 162;
                    DESCRIPTION2.Value = @"";

                    DESCRIPTION3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 73, 12, false);
                    DESCRIPTION3.Name = "DESCRIPTION3";
                    DESCRIPTION3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION3.TextFont.CharSet = 162;
                    DESCRIPTION3.Value = @"";

                    DESCRIPTION4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 12, 73, 16, false);
                    DESCRIPTION4.Name = "DESCRIPTION4";
                    DESCRIPTION4.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION4.TextFont.CharSet = 162;
                    DESCRIPTION4.Value = @"";

                    DESCRIPTION5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 16, 73, 20, false);
                    DESCRIPTION5.Name = "DESCRIPTION5";
                    DESCRIPTION5.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION5.TextFont.CharSet = 162;
                    DESCRIPTION5.Value = @"";

                    DESCRIPTION6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 141, 4, false);
                    DESCRIPTION6.Name = "DESCRIPTION6";
                    DESCRIPTION6.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION6.TextFont.CharSet = 162;
                    DESCRIPTION6.Value = @"";

                    DESCRIPTION7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 4, 141, 8, false);
                    DESCRIPTION7.Name = "DESCRIPTION7";
                    DESCRIPTION7.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION7.TextFont.CharSet = 162;
                    DESCRIPTION7.Value = @"";

                    DESCRIPTION8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 8, 141, 12, false);
                    DESCRIPTION8.Name = "DESCRIPTION8";
                    DESCRIPTION8.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION8.TextFont.CharSet = 162;
                    DESCRIPTION8.Value = @"";

                    DESCRIPTION9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 12, 141, 16, false);
                    DESCRIPTION9.Name = "DESCRIPTION9";
                    DESCRIPTION9.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION9.TextFont.CharSet = 162;
                    DESCRIPTION9.Value = @"";

                    DESCRIPTION10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 16, 141, 20, false);
                    DESCRIPTION10.Name = "DESCRIPTION10";
                    DESCRIPTION10.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION10.TextFont.CharSet = 162;
                    DESCRIPTION10.Value = @"";

                    PRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 164, 4, false);
                    PRICE1.Name = "PRICE1";
                    PRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1.TextFormat = @"#,##0.#0";
                    PRICE1.TextFont.CharSet = 162;
                    PRICE1.Value = @"";

                    PRICE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 4, 164, 8, false);
                    PRICE2.Name = "PRICE2";
                    PRICE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE2.TextFormat = @"#,##0.#0";
                    PRICE2.TextFont.CharSet = 162;
                    PRICE2.Value = @"";

                    PRICE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 8, 164, 12, false);
                    PRICE3.Name = "PRICE3";
                    PRICE3.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE3.TextFormat = @"#,##0.#0";
                    PRICE3.TextFont.CharSet = 162;
                    PRICE3.Value = @"";

                    PRICE4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 12, 164, 16, false);
                    PRICE4.Name = "PRICE4";
                    PRICE4.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE4.TextFormat = @"#,##0.#0";
                    PRICE4.TextFont.CharSet = 162;
                    PRICE4.Value = @"";

                    PRICE5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 16, 164, 20, false);
                    PRICE5.Name = "PRICE5";
                    PRICE5.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE5.TextFormat = @"#,##0.#0";
                    PRICE5.TextFont.CharSet = 162;
                    PRICE5.Value = @"";

                    PRICE6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 184, 4, false);
                    PRICE6.Name = "PRICE6";
                    PRICE6.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE6.TextFormat = @"#,##0.#0";
                    PRICE6.TextFont.CharSet = 162;
                    PRICE6.Value = @"";

                    PRICE7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 4, 184, 8, false);
                    PRICE7.Name = "PRICE7";
                    PRICE7.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE7.TextFormat = @"#,##0.#0";
                    PRICE7.TextFont.CharSet = 162;
                    PRICE7.Value = @"";

                    PRICE8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 8, 184, 12, false);
                    PRICE8.Name = "PRICE8";
                    PRICE8.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE8.TextFormat = @"#,##0.#0";
                    PRICE8.TextFont.CharSet = 162;
                    PRICE8.Value = @"";

                    PRICE9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 12, 184, 16, false);
                    PRICE9.Name = "PRICE9";
                    PRICE9.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE9.TextFormat = @"#,##0.#0";
                    PRICE9.TextFont.CharSet = 162;
                    PRICE9.Value = @"";

                    PRICE10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 16, 184, 20, false);
                    PRICE10.Name = "PRICE10";
                    PRICE10.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE10.TextFormat = @"#,##0.#0";
                    PRICE10.TextFont.CharSet = 162;
                    PRICE10.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTION1.CalcValue = @"";
                    DESCRIPTION2.CalcValue = @"";
                    DESCRIPTION3.CalcValue = @"";
                    DESCRIPTION4.CalcValue = @"";
                    DESCRIPTION5.CalcValue = @"";
                    DESCRIPTION6.CalcValue = @"";
                    DESCRIPTION7.CalcValue = @"";
                    DESCRIPTION8.CalcValue = @"";
                    DESCRIPTION9.CalcValue = @"";
                    DESCRIPTION10.CalcValue = @"";
                    PRICE1.CalcValue = @"";
                    PRICE2.CalcValue = @"";
                    PRICE3.CalcValue = @"";
                    PRICE4.CalcValue = @"";
                    PRICE5.CalcValue = @"";
                    PRICE6.CalcValue = @"";
                    PRICE7.CalcValue = @"";
                    PRICE8.CalcValue = @"";
                    PRICE9.CalcValue = @"";
                    PRICE10.CalcValue = @"";
                    return new TTReportObject[] { DESCRIPTION1,DESCRIPTION2,DESCRIPTION3,DESCRIPTION4,DESCRIPTION5,DESCRIPTION6,DESCRIPTION7,DESCRIPTION8,DESCRIPTION9,DESCRIPTION10,PRICE1,PRICE2,PRICE3,PRICE4,PRICE5,PRICE6,PRICE7,PRICE8,PRICE9,PRICE10};
                }

                public override void RunScript()
                {
#region DETAILS BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ReceiptCreditCardDetailedReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Receipt rec = (Receipt)context.GetObject(new Guid(sObjectID), "Receipt");

            int rowCount = 10;
            int detailcount = 0;
            bool detailFound = false;
            string description = string.Empty;
            const string otherDescription = "Diğer Ücretler";
            string showdetail = SystemParameter.GetParameterValue("RECEIPTREPORTSHOWDETAILS", "TRUE");

            ((ReceiptCreditCardDetailedReport)ParentReport).detailList.Clear();

            foreach (ReceiptDocumentGroup recGroup in rec.ReceiptDocument.ReceiptDocumentGroups)
                detailcount += recGroup.ReceiptDocumentDetails.Count;

            if (detailcount <= rowCount) // Detay sayısı satır sayısından küçükeşit ise makbuz detaylı dökülür
                showdetail = "TRUE";

            foreach (ReceiptDocumentGroup recGroup in rec.ReceiptDocument.ReceiptDocumentGroups)
            {
                foreach (ReceiptDocumentDetail receiptDetail in recGroup.ReceiptDocumentDetails)
                {
                    description = otherDescription;

                    if (showdetail.Equals("TRUE"))
                    {
                        if (detailcount <= rowCount || ((ReceiptCreditCardDetailedReport)ParentReport).detailList.Count < rowCount - 1)
                            description = receiptDetail.Description;
                    }
                    else
                    {
                        if (((ReceiptCreditCardDetailedReport)ParentReport).detailList.Count < rowCount - 1)
                        {
                            AccountTransaction accTrx = receiptDetail.AccountTrxDocument[0].AccountTransaction;
                            if (accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.ProcedureObject != null)
                            {
                                RevenueSubAccountCodeDefinition revenue = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                if (revenue != null) 
                                    description = revenue.Description;
                            }
                            else if (accTrx.SubActionMaterial != null)
                                description = "Aşı, Serum, İlaç, Tıbbi Malzeme Gelirleri";
                        }
                    }

                    detailFound = false;
                    if (showdetail.Equals("FALSE") || detailcount > rowCount) // Detaylı döküm alınacak ve detay sayısı row sayısından küçükeşitse gruplama yapmasın
                    {
                        foreach (Detail detail in ((ReceiptCreditCardDetailedReport)ParentReport).detailList)
                        {
                            if (detail.Description.Equals(description))
                            {
                                detail.Price += receiptDetail.PaymentPrice.Value;
                                detailFound = true;
                                break;
                            }
                        }
                    }

                    if (!detailFound)
                    {
                        int orderNo = ((ReceiptCreditCardDetailedReport)ParentReport).detailList.Count;

                        if (description.Equals(otherDescription))
                            orderNo = int.MaxValue;

                        ((ReceiptCreditCardDetailedReport)ParentReport).detailList.Add(new Detail(orderNo, description, receiptDetail.PaymentPrice.Value));
                    }
                }
            }

            int i = 1;
            TTReportField fieldDesc;
            TTReportField fieldPrice;

            ((ReceiptCreditCardDetailedReport)ParentReport).detailList = ((ReceiptCreditCardDetailedReport)ParentReport).detailList.OrderBy(x => x.OrderNo).ToList();

            foreach (Detail detail in ((ReceiptCreditCardDetailedReport)ParentReport).detailList)
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

        public ReceiptCreditCardDetailedReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            DETAILS = new DETAILSGroup(HEADER,"DETAILS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RECEIPTCREDITCARDDETAILEDREPORT";
            Caption = "Kredi Kartı Alındısı  (Detaylı)";
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