
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
    public partial class CashOfficeAccountReport : TTReport
    {
#region Methods
   bool show800Accounts = TTObjectClasses.SystemParameter.GetParameterValue("CASHOFFICEACCOUNTREPORTSHOW800","FALSE").Equals("TRUE") ? true : false;
        int ParentAccountCodeCounter = 0;
        int AccountCodeCounter = 0;
        Currency TotalReceivablePrice = 0;
        Currency TotalDebtPriceTotal = 0;
        List<AccountInfo> accountInfoList = new List<AccountInfo>();
        
        public class AccountInfo
        {
            public string ParentAccountCode;
            public string AccountCode;
            public Currency DebtPrice;
            public Currency ReceivablePrice;
            public string Description;
        }
        
        public void CreateNewAccountInfo(string accountCode, Currency debtPrice, Currency receivablePrice)
        {
            string parentAccountCode = accountCode;
            if (accountCode.IndexOf(".") > 0)
                parentAccountCode = accountCode.Substring(0, accountCode.IndexOf("."));

            string originalAccountCode = accountCode;
            if (accountCode.StartsWith("601")) // Hesap kodu tanımlarında 601 li kodlar yok, açıklamayı çekebilmek için 600 lü koddan bakmak lazım
                originalAccountCode = "600." + accountCode.Substring(4, accountCode.Length - 4);

            string originalAccountDescription = string.Empty;
            RevenueSubAccountCodeDefinition originalAccount = ReportObjectContext.QueryObjects<RevenueSubAccountCodeDefinition>("ACCOUNTCODE = '" + originalAccountCode + "'").FirstOrDefault();
            if (originalAccount != null)
                originalAccountDescription = originalAccount.Description;

            accountInfoList.Add(new AccountInfo()
                                {
                                    AccountCode = accountCode,
                                    ParentAccountCode = parentAccountCode,
                                    DebtPrice = debtPrice,
                                    ReceivablePrice = receivablePrice,
                                    Description = originalAccountDescription
                                });
        }

        public bool AddPriceToExistingAccInfo(string accountCode, Currency price, bool isDebtPrice)
        {
            if (accountInfoList.FirstOrDefault(x => x.AccountCode == accountCode) != null)
            {
                if (isDebtPrice)
                    accountInfoList.FirstOrDefault(x => x.AccountCode == accountCode).DebtPrice += price;
                else
                    accountInfoList.FirstOrDefault(x => x.AccountCode == accountCode).ReceivablePrice += price;

                return true;
            }
            return false;
        }
        
        public string GetYTL(Currency price)
        {
            if (price.ToString().Contains(','))
                return price.ToString().Substring(0, price.ToString().IndexOf(','));
            else
                return price.ToString();
        }

        public string GetYKR(Currency price)
        {
            if (price.ToString().Contains(','))
                return price.ToString("0.00").Substring(price.ToString().IndexOf(',') + 1);
            else
                return "00";
        }
        
        // Pursaklardaki 800 lü ilişkili hesaplar için yapıldı
        List<RelatedAccountInfo> relatedAccountInfoList = new List<RelatedAccountInfo>();
        
        public class RelatedAccountInfo
        {
            public string AccountCode;
            public string RelatedAccountCode;
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? CASHOFFICE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? CASHOFFICECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public Guid? CASHIER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? CASHIERCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public PaymentTypeCashCCEnum? PAYMENTTYPE = (PaymentTypeCashCCEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].ConvertValue("");
            public int? PAYMENTTYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public bool? USETIME = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
        }

        public partial class PARTDGroup : TTReportGroup
        {
            public CashOfficeAccountReport MyParentReport
            {
                get { return (CashOfficeAccountReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 29, 7, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 2, 57, 7, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTD HEADER_Script
                    if(MyParentReport.RuntimeParameters.USETIME != true)
            {
                MyParentReport.RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
                MyParentReport.RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            }
            
            if(MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.HasValue == false) // Rapor refresh edildiğinde bu bloğa tekrar girmemesi lazım
            {
                if (MyParentReport.RuntimeParameters.PAYMENTTYPE.HasValue)
                    MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL = 1;
                else
                {
                    MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL = 0;
                    MyParentReport.RuntimeParameters.PAYMENTTYPE = PaymentTypeCashCCEnum.Cash;
                }
            }

            if (!MyParentReport.RuntimeParameters.CASHOFFICE.HasValue)
                MyParentReport.RuntimeParameters.CASHOFFICE = Guid.Empty;
            if (!MyParentReport.RuntimeParameters.CASHIER.HasValue)
                MyParentReport.RuntimeParameters.CASHIER = Guid.Empty;
            
            if (MyParentReport.RuntimeParameters.CASHOFFICE == Guid.Empty)
                MyParentReport.RuntimeParameters.CASHOFFICECONTROL = 0;
            else
                MyParentReport.RuntimeParameters.CASHOFFICECONTROL = 1;

            if (MyParentReport.RuntimeParameters.CASHIER == Guid.Empty)
                MyParentReport.RuntimeParameters.CASHIERCONTROL = 0;
            else
                MyParentReport.RuntimeParameters.CASHIERCONTROL = 1;

            // Pursaklardaki ilişkili 800 hesapları için eklendi. İlişkili hesabı olan hesap kodları listeye eklenir
            if (MyParentReport.show800Accounts)
            {
                MyParentReport.relatedAccountInfoList.Clear();
                List<RevenueSubAccountCodeDefinition> relatedAccountList = MyParentReport.ReportObjectContext.QueryObjects<RevenueSubAccountCodeDefinition>("RELATEDREVENUESUBACCOUNT IS NOT NULL").ToList();
                foreach (RevenueSubAccountCodeDefinition account in relatedAccountList)
                    MyParentReport.relatedAccountInfoList.Add(new RelatedAccountInfo() { AccountCode = account.AccountCode, RelatedAccountCode = account.RelatedRevenueSubAccount.AccountCode });
            }
            
            MyParentReport.accountInfoList.Clear();
            MyParentReport.ParentAccountCodeCounter = 0;
            BindingList<ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class> receiptDetailList = ReceiptDocument.CashOfficeRevenueReportDetailQuery(MyParentReport.RuntimeParameters.STARTDATE.Value, MyParentReport.RuntimeParameters.ENDDATE.Value, MyParentReport.RuntimeParameters.CASHOFFICE.Value, MyParentReport.RuntimeParameters.CASHOFFICECONTROL.Value, MyParentReport.RuntimeParameters.CASHIER.Value, MyParentReport.RuntimeParameters.CASHIERCONTROL.Value, MyParentReport.RuntimeParameters.PAYMENTTYPE.Value, MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.Value);
            foreach (ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class item in receiptDetailList)
            {
                if (!item.Statestatus.ToString().Equals("4"))
                {
                    // Alacak hesabı
                    string accountCode = string.Empty;

                    if (item.Type.Equals("PROCEDURE"))
                    {   // SGK lı hastadan alınmış katılım payı ise
                        if ((item.PayerType == PayerTypeEnum.SGK || item.PayerType == PayerTypeEnum.SGKManual) && (item.Isparticipationshare.ToString().Equals("1") || item.Isparticipationprocedure.ToString().Equals("1")))
                        {
                            if (!string.IsNullOrEmpty(item.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                            {
                                if (item.Medulaistisnaihalkodu.ToString().Equals("9")) // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                    accountCode = "600.01.94";
                                else
                                    accountCode = "336.06.01";
                            }
                            else                                           // Takip numarası yok ise Provizyon Alınmayan SGK Katılım payı olarak gelir
                                accountCode = "336.06.02";
                        }
                        else
                        {
                            if (item.Accountcode != null)
                            {
                                accountCode = item.Accountcode.ToString();

                                if (accountCode.Equals("600.01.01") || accountCode.Equals("600.01.02") || accountCode.Equals("600.01.03") || accountCode.Equals("600.01.04") || accountCode.Equals("600.01.05"))
                                {
                                    if (item.tedaviTuruKodu.ToString().Equals("A"))
                                        accountCode += ".01";
                                    else
                                        accountCode += ".02";
                                }
                                else if (accountCode.Equals("600.01.06") || accountCode.Equals("600.01.07"))
                                    accountCode += ".01";
                            }
                            else
                                accountCode = "600.01.99";
                        }
                    }
                    else if (item.Type.Equals("MATERIAL"))
                    {   // SGK lı hastadan alınmış katılım payı ise
                        if ((item.PayerType == PayerTypeEnum.SGK || item.PayerType == PayerTypeEnum.SGKManual) && item.Isparticipationshare.ToString().Equals("1"))
                        {
                            if (!string.IsNullOrEmpty(item.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                            {
                                if (item.Medulaistisnaihalkodu.ToString().Equals("9")) // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                    accountCode = "600.01.94";
                                else
                                    accountCode = "336.06.01";
                            }
                            else                                           // Takip numarası yok ise Provizyon Alınmayan SGK Katılım payı olarak gelir
                                accountCode = "336.06.02";
                        }
                        else if (item.Materialobjectdefname.Equals("DRUGDEFINITION") || item.Materialobjectdefname.Equals("MAGISTRALPREPARATIONDEFINITION"))
                            accountCode = "600.01.08.01";
                        else
                            accountCode = "600.01.08.02";
                    }

                    if (!string.IsNullOrEmpty(accountCode))
                    {
                        // Pursaklardaki ilişkili 800 hesapları için eklendi (Önce bu kısım eklenmeli çünkü aşağıda kodun 601 e çevrilme ihtimali var!)
                        
                        // 336.06.01 in yansıma hesabı yokmuş(800 lü), genel toplamdan da çıkarılacağı için burda 800 lü hesap eklenmiyor listeye ama
                        // 336.06.01 nın kendisi listeye ekleniyor, satır olarak görünecek ama toplama dahil edilmeyecek
                        if (accountCode != "336.06.01" && accountCode != "336.06.02")
                        {
                            RelatedAccountInfo relatedAccountInfo = MyParentReport.relatedAccountInfoList.FirstOrDefault(x => x.AccountCode == accountCode);
                            if(relatedAccountInfo != null && !string.IsNullOrWhiteSpace(relatedAccountInfo.RelatedAccountCode))
                            {
                                if (!MyParentReport.AddPriceToExistingAccInfo(relatedAccountInfo.RelatedAccountCode, item.PaymentPrice.Value, false))
                                    MyParentReport.CreateNewAccountInfo(relatedAccountInfo.RelatedAccountCode, 0, item.PaymentPrice.Value);
                            }
                        }
                        
                        if (accountCode.StartsWith("600.") && item.Ishealthtourism.ToString().Equals("1") && accountCode != "600.01.94")
                            accountCode = "601." + accountCode.Substring(4, accountCode.Length - 4);

                        if (!MyParentReport.AddPriceToExistingAccInfo(accountCode, item.PaymentPrice.Value, false))
                            MyParentReport.CreateNewAccountInfo(accountCode, 0, item.PaymentPrice.Value);
                    }
                    
                    // 336.06.01 genel toplamdan çıkarılacağı için karşılığı olan borç hesapları da listeye eklenmez, yoksa borç alacak toplamları farklı çıkar (Pursaklar böyle istedi)
                    // Gazilerde eskiden olduğu gibi 336.06.01 için borç karşılığı oluşmaya devam edecek.
                    if (MyParentReport.show800Accounts == false || (accountCode != "336.06.01" && accountCode != "336.06.02"))
                    {
                        // Borç hesabı
                        string debtAccountCode = string.Empty;

                        if (item.PaymentType == PaymentTypeEnum.Cash)
                            debtAccountCode = "336.09";
                        else if (item.PaymentType == PaymentTypeEnum.CreditCard)
                            debtAccountCode = "123.02";

                        if (!string.IsNullOrEmpty(debtAccountCode))
                        {
                            // Pursaklardaki ilişkili 800 hesapları için eklendi
                            RelatedAccountInfo relatedAccountInfo = MyParentReport.relatedAccountInfoList.FirstOrDefault(x => x.AccountCode == debtAccountCode);
                            if (relatedAccountInfo != null && !string.IsNullOrWhiteSpace(relatedAccountInfo.RelatedAccountCode))
                            {
                                if (!MyParentReport.AddPriceToExistingAccInfo(relatedAccountInfo.RelatedAccountCode, item.PaymentPrice.Value, true))
                                    MyParentReport.CreateNewAccountInfo(relatedAccountInfo.RelatedAccountCode, item.PaymentPrice.Value, 0);
                            }
                            
                            if (!MyParentReport.AddPriceToExistingAccInfo(debtAccountCode, item.PaymentPrice.Value, true))
                                MyParentReport.CreateNewAccountInfo(debtAccountCode, item.PaymentPrice.Value, 0);
                        }
                    }
                }
            }

            BindingList<AccountDocument.CashOfficeRevenueReportQuery_Class> result = AccountDocument.CashOfficeRevenueReportQuery(MyParentReport.RuntimeParameters.STARTDATE.Value, MyParentReport.RuntimeParameters.ENDDATE.Value, MyParentReport.RuntimeParameters.CASHOFFICE.Value, MyParentReport.RuntimeParameters.CASHOFFICECONTROL.Value, MyParentReport.RuntimeParameters.CASHIER.Value, MyParentReport.RuntimeParameters.CASHIERCONTROL.Value, MyParentReport.RuntimeParameters.PAYMENTTYPE.Value, MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.Value);
            foreach (AccountDocument.CashOfficeRevenueReportQuery_Class item in result)
            {
                if (item.Objectdef.Equals("OLDDEBTRECEIPTDOCUMENT") || (!item.Statestatus.ToString().Equals("4") && (item.Objectdef.Equals("ADVANCEDOCUMENT") || item.Objectdef.Equals("CASHOFFICERECEIPTDOCUMENT") || item.Objectdef.Equals("BONDPAYMENTDOCUMENT"))))
                {
                    // Alacak hesabı
                    string accountCode = string.Empty;

                    if (item.Objectdef.Equals("ADVANCEDOCUMENT"))
                        accountCode = "340.11.01";
                    else if (item.Objectdef.Equals("CASHOFFICERECEIPTDOCUMENT"))
                    {
                        if (item.Accountcode != null)
                            accountCode = item.Accountcode.ToString();
                        else
                            accountCode = "679.09.9099";
                    }
                    else if (item.Objectdef.Equals("BONDPAYMENTDOCUMENT"))
                        accountCode = "679.09.9099";
                    else if (item.Objectdef.Equals("OLDDEBTRECEIPTDOCUMENT"))
                        accountCode = "600.01.99";

                    if (!string.IsNullOrEmpty(accountCode))
                    {
                        // Pursaklardaki ilişkili 800 hesapları için eklendi
                        RelatedAccountInfo relatedAccountInfo = MyParentReport.relatedAccountInfoList.FirstOrDefault(x => x.AccountCode == accountCode);
                        if (relatedAccountInfo != null && !string.IsNullOrWhiteSpace(relatedAccountInfo.RelatedAccountCode))
                        {
                            if (!MyParentReport.AddPriceToExistingAccInfo(relatedAccountInfo.RelatedAccountCode, item.TotalPrice.Value, false))
                                MyParentReport.CreateNewAccountInfo(relatedAccountInfo.RelatedAccountCode, 0, item.TotalPrice.Value);
                        }
                        
                        if (!MyParentReport.AddPriceToExistingAccInfo(accountCode, item.TotalPrice.Value, false))
                            MyParentReport.CreateNewAccountInfo(accountCode, 0, item.TotalPrice.Value);
                    }

                    // Borç hesabı
                    string debtAccountCode = string.Empty;

                    if (item.PaymentType == PaymentTypeEnum.Cash)
                        debtAccountCode = "336.09";
                    else if (item.PaymentType == PaymentTypeEnum.CreditCard)
                        debtAccountCode = "123.02";

                    if (!string.IsNullOrEmpty(debtAccountCode))
                    {
                        // Pursaklardaki ilişkili 800 hesapları için eklendi
                        RelatedAccountInfo relatedAccountInfo = MyParentReport.relatedAccountInfoList.FirstOrDefault(x => x.AccountCode == debtAccountCode);
                        if (relatedAccountInfo != null && !string.IsNullOrWhiteSpace(relatedAccountInfo.RelatedAccountCode))
                        {
                            if (!MyParentReport.AddPriceToExistingAccInfo(relatedAccountInfo.RelatedAccountCode, item.TotalPrice.Value, true))
                                MyParentReport.CreateNewAccountInfo(relatedAccountInfo.RelatedAccountCode, item.TotalPrice.Value, 0);
                        }
                        
                        if (!MyParentReport.AddPriceToExistingAccInfo(debtAccountCode, item.TotalPrice.Value, true))
                            MyParentReport.CreateNewAccountInfo(debtAccountCode, item.TotalPrice.Value, 0);
                    }

                }
            }
            
            MyParentReport.PARTB.RepeatCount = MyParentReport.accountInfoList.Select(x => x.ParentAccountCode).Distinct().Count();
#endregion PARTD HEADER_Script
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTAGroup : TTReportGroup
        {
            public CashOfficeAccountReport MyParentReport
            {
                get { return (CashOfficeAccountReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField MUHASEBEBIRIMADI { get {return Header().MUHASEBEBIRIMADI;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField FINANCIALYEAR { get {return Header().FINANCIALYEAR;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField FINANCIALDATE { get {return Header().FINANCIALDATE;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NO { get {return Header().NO;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField SHORTNAME { get {return Header().SHORTNAME;} }
            public TTReportField NewField1252 { get {return Header().NewField1252;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField NewField1253 { get {return Header().NewField1253;} }
            public TTReportField BANKACCOUNT { get {return Header().BANKACCOUNT;} }
            public TTReportField NewField1254 { get {return Header().NewField1254;} }
            public TTReportField BANKACCOUNTNO { get {return Header().BANKACCOUNTNO;} }
            public TTReportField NewField1255 { get {return Header().NewField1255;} }
            public TTReportField TAXOFFICE { get {return Header().TAXOFFICE;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField DEPARTMENT { get {return Header().DEPARTMENT;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField12912 { get {return Header().NewField12912;} }
            public TTReportField NewField12913 { get {return Header().NewField12913;} }
            public TTReportField NewField111921 { get {return Header().NewField111921;} }
            public TTReportField NewField121921 { get {return Header().NewField121921;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField CLOSINGDATE { get {return Header().CLOSINGDATE;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportField NewField1118111 { get {return Header().NewField1118111;} }
            public TTReportField PAYMENTTYPE { get {return Header().PAYMENTTYPE;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField21 { get {return Footer().NewField21;} }
            public TTReportField NewField22 { get {return Footer().NewField22;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField101 { get {return Footer().NewField101;} }
            public TTReportField NewField1101 { get {return Footer().NewField1101;} }
            public TTReportShape NewRect12 { get {return Footer().NewRect12;} }
            public TTReportShape NewRect121 { get {return Footer().NewRect121;} }
            public TTReportField DOCUMENTNO { get {return Footer().DOCUMENTNO;} }
            public TTReportField DOCUMENTDATE { get {return Footer().DOCUMENTDATE;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField1231 { get {return Footer().NewField1231;} }
            public TTReportField NewField11321 { get {return Footer().NewField11321;} }
            public TTReportField NewField12321 { get {return Footer().NewField12321;} }
            public TTReportShape NewRect13 { get {return Footer().NewRect13;} }
            public TTReportShape NewRect131 { get {return Footer().NewRect131;} }
            public TTReportShape NewRect141 { get {return Footer().NewRect141;} }
            public TTReportField NewField1331 { get {return Footer().NewField1331;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
            public TTReportField NewField112321 { get {return Footer().NewField112321;} }
            public TTReportField NewField122321 { get {return Footer().NewField122321;} }
            public TTReportField NewField1123221 { get {return Footer().NewField1123221;} }
            public TTReportField ADVANCE_CREDIT_DATE { get {return Footer().ADVANCE_CREDIT_DATE;} }
            public TTReportField WAGENO { get {return Footer().WAGENO;} }
            public TTReportField ADVANCEPRICEYTL { get {return Footer().ADVANCEPRICEYTL;} }
            public TTReportField ADVANCEPRICEYKR { get {return Footer().ADVANCEPRICEYKR;} }
            public TTReportField DOCUMENTREASON { get {return Footer().DOCUMENTREASON;} }
            public TTReportField NewField144 { get {return Footer().NewField144;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField SIGNFIELDOFFINANCING { get {return Footer().SIGNFIELDOFFINANCING;} }
            public TTReportField SIGNFIELDOFHOSPMANGER { get {return Footer().SIGNFIELDOFHOSPMANGER;} }
            public TTReportField SIGNFIELDOFACCOUNTINGMANAGER { get {return Footer().SIGNFIELDOFACCOUNTINGMANAGER;} }
            public TTReportField RECEIPTNO { get {return Footer().RECEIPTNO;} }
            public TTReportField SIGNFIELDOFCASHIER { get {return Footer().SIGNFIELDOFCASHIER;} }
            public TTReportShape NewRect2 { get {return Footer().NewRect2;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportField DUZENLEYEN { get {return Footer().DUZENLEYEN;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
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
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField MUHASEBEBIRIMADI;
                public TTReportField NewField15;
                public TTReportField FINANCIALYEAR;
                public TTReportField NewField151;
                public TTReportField FINANCIALDATE;
                public TTReportField NewField1151;
                public TTReportField NO;
                public TTReportField NewField5;
                public TTReportShape NewRect1;
                public TTReportField NewField6;
                public TTReportField NewField152;
                public TTReportField SHORTNAME;
                public TTReportField NewField1252;
                public TTReportField TCNO;
                public TTReportField NewField1253;
                public TTReportField BANKACCOUNT;
                public TTReportField NewField1254;
                public TTReportField BANKACCOUNTNO;
                public TTReportField NewField1255;
                public TTReportField TAXOFFICE;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField PAYER;
                public TTReportField DEPARTMENT;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField1142;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportField NewField13;
                public TTReportField NewField7;
                public TTReportField NewField19;
                public TTReportField NewField191;
                public TTReportField NewField1191;
                public TTReportField NewField12912;
                public TTReportField NewField12913;
                public TTReportField NewField111921;
                public TTReportField NewField121921;
                public TTReportField NewField20;
                public TTReportField STARTDATE;
                public TTReportField CLOSINGDATE;
                public TTReportField NewField161;
                public TTReportField NewField1181;
                public TTReportField NewField11911;
                public TTReportField NewField1118111;
                public TTReportField PAYMENTTYPE;
                public TTReportField NewField23; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 8, 133, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"MUHASEBE İŞLEM FİŞİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 41, 21, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"MUHASEBE BİRİM KODU";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 15, 106, 21, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 21, 41, 27, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"MUHASEBE BİRİM ADI";

                    MUHASEBEBIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 21, 106, 27, false);
                    MUHASEBEBIRIMADI.Name = "MUHASEBEBIRIMADI";
                    MUHASEBEBIRIMADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUHASEBEBIRIMADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    MUHASEBEBIRIMADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MUHASEBEBIRIMADI"", """")";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 21, 126, 27, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"BÜTÇE YILI";

                    FINANCIALYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 21, 146, 27, false);
                    FINANCIALYEAR.Name = "FINANCIALYEAR";
                    FINANCIALYEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    FINANCIALYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    FINANCIALYEAR.TextFont.Size = 9;
                    FINANCIALYEAR.TextFont.CharSet = 162;
                    FINANCIALYEAR.Value = @"";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 27, 126, 33, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"TARİHİ";

                    FINANCIALDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 27, 146, 33, false);
                    FINANCIALDATE.Name = "FINANCIALDATE";
                    FINANCIALDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    FINANCIALDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FINANCIALDATE.TextFont.Size = 9;
                    FINANCIALDATE.TextFont.CharSet = 162;
                    FINANCIALDATE.Value = @"";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 33, 126, 39, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"NO'SU";

                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 33, 146, 39, false);
                    NO.Name = "NO";
                    NO.DrawStyle = DrawStyleConstants.vbSolid;
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.TextFont.Size = 9;
                    NO.TextFont.CharSet = 162;
                    NO.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 21, 152, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.FontAngle = 900;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"İLGİLİNİN";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 146, 21, 152, 55, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 39, 146, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.Value = @"";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 21, 177, 27, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152.TextFont.Size = 9;
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @"ADI SOYADI";

                    SHORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 21, 202, 27, false);
                    SHORTNAME.Name = "SHORTNAME";
                    SHORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    SHORTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SHORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    SHORTNAME.NoClip = EvetHayirEnum.ehEvet;
                    SHORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    SHORTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    SHORTNAME.TextFont.Size = 7;
                    SHORTNAME.TextFont.CharSet = 162;
                    SHORTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALSHORTNAME"", """")";

                    NewField1252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 27, 177, 33, false);
                    NewField1252.Name = "NewField1252";
                    NewField1252.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1252.TextFont.Size = 9;
                    NewField1252.TextFont.CharSet = 162;
                    NewField1252.Value = @"TC KİMLİK NO";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 27, 202, 33, false);
                    TCNO.Name = "TCNO";
                    TCNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCNO.NoClip = EvetHayirEnum.ehEvet;
                    TCNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCNO.TextFont.Size = 8;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"";

                    NewField1253 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 33, 177, 39, false);
                    NewField1253.Name = "NewField1253";
                    NewField1253.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1253.TextFont.Size = 9;
                    NewField1253.TextFont.CharSet = 162;
                    NewField1253.Value = @"BANKA ŞUBESİ";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 33, 202, 39, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.Size = 7;
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")";

                    NewField1254 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 39, 177, 45, false);
                    NewField1254.Name = "NewField1254";
                    NewField1254.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1254.TextFont.Size = 8;
                    NewField1254.TextFont.CharSet = 162;
                    NewField1254.Value = @"BANKA HESAP NO";

                    BANKACCOUNTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 39, 202, 45, false);
                    BANKACCOUNTNO.Name = "BANKACCOUNTNO";
                    BANKACCOUNTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    BANKACCOUNTNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNTNO.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNTNO.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNTNO.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNTNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNTNO.TextFont.Size = 7;
                    BANKACCOUNTNO.TextFont.CharSet = 162;
                    BANKACCOUNTNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")";

                    NewField1255 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 45, 177, 55, false);
                    NewField1255.Name = "NewField1255";
                    NewField1255.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1255.TextFont.Size = 9;
                    NewField1255.TextFont.CharSet = 162;
                    NewField1255.Value = @"VERGİ DAİRESİ";

                    TAXOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 45, 202, 55, false);
                    TAXOFFICE.Name = "TAXOFFICE";
                    TAXOFFICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TAXOFFICE.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXOFFICE.MultiLine = EvetHayirEnum.ehEvet;
                    TAXOFFICE.NoClip = EvetHayirEnum.ehEvet;
                    TAXOFFICE.WordBreak = EvetHayirEnum.ehEvet;
                    TAXOFFICE.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXOFFICE.TextFont.Size = 7;
                    TAXOFFICE.TextFont.CharSet = 162;
                    TAXOFFICE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 27, 41, 39, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"KURUM - BİRİM KODU";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 39, 41, 45, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"KURUM ADI";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 45, 41, 55, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"BİRİM ADI";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 39, 106, 45, false);
                    PAYER.Name = "PAYER";
                    PAYER.DrawStyle = DrawStyleConstants.vbSolid;
                    PAYER.FieldType = ReportFieldTypeEnum.ftExpression;
                    PAYER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MUHASEBEKURUMADI"", """")";

                    DEPARTMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 45, 106, 55, false);
                    DEPARTMENT.Name = "DEPARTMENT";
                    DEPARTMENT.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPARTMENT.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEPARTMENT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""CASHOFFICEDEPARTMENT"", """")";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 27, 46, 33, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.Value = @"1";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 27, 51, 33, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.Value = @"2";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 27, 66, 33, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1142.Value = @"BİRİM";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 27, 106, 39, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.Value = @"YEVMİYENİN";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 33, 66, 39, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 15, 202, 21, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 56, 106, 71, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.Value = @"HESAP ADI";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 56, 152, 61, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.Value = @"TUTAR";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 61, 129, 66, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.Value = @"BORÇ";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 61, 152, 66, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1191.Value = @"ALACAK";

                    NewField12912 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 66, 142, 71, false);
                    NewField12912.Name = "NewField12912";
                    NewField12912.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12912.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField12912.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12912.Value = @"TL";

                    NewField12913 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 66, 152, 71, false);
                    NewField12913.Name = "NewField12913";
                    NewField12913.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12913.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField12913.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12913.Value = @"KR";

                    NewField111921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 66, 119, 71, false);
                    NewField111921.Name = "NewField111921";
                    NewField111921.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111921.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField111921.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111921.Value = @"TL";

                    NewField121921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 66, 129, 71, false);
                    NewField121921.Name = "NewField121921";
                    NewField121921.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121921.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField121921.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121921.Value = @"KR";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 56, 202, 71, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.Value = @"HESAP / AYRINTI ADI";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 5, 45, 9, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 5, 71, 9, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"dd/MM/yyyy";
                    CLOSINGDATE.Value = @"{@ENDDATE@}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 24, 9, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Tarih";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 5, 28, 9, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 9, 24, 13, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.TextFont.Bold = true;
                    NewField11911.TextFont.CharSet = 162;
                    NewField11911.Value = @"Ödeme Tipi";

                    NewField1118111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 9, 28, 13, false);
                    NewField1118111.Name = "NewField1118111";
                    NewField1118111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1118111.TextFont.Bold = true;
                    NewField1118111.TextFont.CharSet = 162;
                    NewField1118111.Value = @":";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 9, 71, 13, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.ObjectDefName = "PaymentTypeCashCCEnum";
                    PAYMENTTYPE.DataMember = "DISPLAYTEXT";
                    PAYMENTTYPE.Value = @"{@PAYMENTTYPE@}";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 5, 49, 9, false);
                    NewField23.Name = "NewField23";
                    NewField23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23.Value = @"-";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField15.CalcValue = NewField15.Value;
                    FINANCIALYEAR.CalcValue = @"";
                    NewField151.CalcValue = NewField151.Value;
                    FINANCIALDATE.CalcValue = @"";
                    NewField1151.CalcValue = NewField1151.Value;
                    NO.CalcValue = @"";
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField1252.CalcValue = NewField1252.Value;
                    TCNO.CalcValue = @"";
                    NewField1253.CalcValue = NewField1253.Value;
                    NewField1254.CalcValue = NewField1254.Value;
                    NewField1255.CalcValue = NewField1255.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField12912.CalcValue = NewField12912.Value;
                    NewField12913.CalcValue = NewField12913.Value;
                    NewField111921.CalcValue = NewField111921.Value;
                    NewField121921.CalcValue = NewField121921.Value;
                    NewField20.CalcValue = NewField20.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    CLOSINGDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField161.CalcValue = NewField161.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField1118111.CalcValue = NewField1118111.Value;
                    PAYMENTTYPE.CalcValue = MyParentReport.RuntimeParameters.PAYMENTTYPE.ToString();
                    PAYMENTTYPE.PostFieldValueCalculation();
                    NewField23.CalcValue = NewField23.Value;
                    MUHASEBEBIRIMADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MUHASEBEBIRIMADI", "");
                    SHORTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "");
                    BANKACCOUNTNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "");
                    TAXOFFICE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    PAYER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MUHASEBEKURUMADI", "");
                    DEPARTMENT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("CASHOFFICEDEPARTMENT", "");
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField15,FINANCIALYEAR,NewField151,FINANCIALDATE,NewField1151,NO,NewField5,NewField6,NewField152,NewField1252,TCNO,NewField1253,NewField1254,NewField1255,NewField16,NewField17,NewField18,NewField141,NewField1141,NewField1142,NewField142,NewField143,NewField13,NewField7,NewField19,NewField191,NewField1191,NewField12912,NewField12913,NewField111921,NewField121921,NewField20,STARTDATE,CLOSINGDATE,NewField161,NewField1181,NewField11911,NewField1118111,PAYMENTTYPE,NewField23,MUHASEBEBIRIMADI,SHORTNAME,BANKACCOUNT,BANKACCOUNTNO,TAXOFFICE,PAYER,DEPARTMENT};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    FINANCIALYEAR.CalcValue = TTObjectClasses.Common.RecTime().Year.ToString();
            FINANCIALDATE.CalcValue = TTObjectClasses.Common.RecTime().ToShortDateString();
            
            if (MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.Value.Equals(0)) // Ödeme Tipi seçilmemişse boş kalsın
                this.PAYMENTTYPE.CalcValue = string.Empty;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField101;
                public TTReportField NewField1101;
                public TTReportShape NewRect12;
                public TTReportShape NewRect121;
                public TTReportField DOCUMENTNO;
                public TTReportField DOCUMENTDATE;
                public TTReportField NewField132;
                public TTReportField NewField1231;
                public TTReportField NewField11321;
                public TTReportField NewField12321;
                public TTReportShape NewRect13;
                public TTReportShape NewRect131;
                public TTReportShape NewRect141;
                public TTReportField NewField1331;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField112321;
                public TTReportField NewField122321;
                public TTReportField NewField1123221;
                public TTReportField ADVANCE_CREDIT_DATE;
                public TTReportField WAGENO;
                public TTReportField ADVANCEPRICEYTL;
                public TTReportField ADVANCEPRICEYKR;
                public TTReportField DOCUMENTREASON;
                public TTReportField NewField144;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField SIGNFIELDOFFINANCING;
                public TTReportField SIGNFIELDOFHOSPMANGER;
                public TTReportField SIGNFIELDOFACCOUNTINGMANAGER;
                public TTReportField RECEIPTNO;
                public TTReportField SIGNFIELDOFCASHIER;
                public TTReportShape NewRect2;
                public TTReportField NewField8;
                public TTReportField DUZENLEYEN;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine11;
                public TTReportShape NewLine3; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 113;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 13, 129, 18, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.Value = @"TAHSİLAT / ÖDEME RET / İADELERDE";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 18, 34, 33, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.Value = @"ALINDI NO";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 18, 79, 33, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.Value = @"ÇEK NO / GÖNDERME EMRİ NO";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 18, 129, 28, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122.Value = @"DÜZELTME FİŞİ / DÜZELTME İADE BELGESİNİN";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 28, 104, 33, false);
                    NewField101.Name = "NewField101";
                    NewField101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.Value = @"TARİHİ";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 28, 129, 33, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1101.Value = @"NUMARASI";

                    NewRect12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 6, 33, 34, 38, false);
                    NewRect12.Name = "NewRect12";
                    NewRect12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 34, 33, 79, 38, false);
                    NewRect121.Name = "NewRect121";
                    NewRect121.DrawStyle = DrawStyleConstants.vbSolid;

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 33, 129, 38, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DOCUMENTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTNO.Value = @"NUMARASI";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 33, 104, 38, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTDATE.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 38, 129, 43, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.Value = @"İADE OLUNAN EMANETLERDE";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 43, 49, 48, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.Value = @"HESABA ALINDIĞI TARİH";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 43, 84, 48, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11321.Value = @"YEVMİYE NUMARASI";

                    NewField12321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 43, 129, 48, false);
                    NewField12321.Name = "NewField12321";
                    NewField12321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12321.Value = @"KİMİN ADINA KAYITLI OLDUĞU";

                    NewRect13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 6, 48, 49, 53, false);
                    NewRect13.Name = "NewRect13";
                    NewRect13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 49, 48, 84, 53, false);
                    NewRect131.Name = "NewRect131";
                    NewRect131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 84, 48, 129, 53, false);
                    NewRect141.Name = "NewRect141";
                    NewRect141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 53, 129, 58, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.Value = @"ÖN ÖDEMELERDE";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 58, 84, 68, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.Value = @"YEVMİYE NUMARASI";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 58, 49, 68, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.Value = @"AVANS / KREDİ TARİHİ";

                    NewField112321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 58, 129, 63, false);
                    NewField112321.Name = "NewField112321";
                    NewField112321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112321.Value = @"İLGİLİDEN AVANS TUTARI";

                    NewField122321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 63, 111, 68, false);
                    NewField122321.Name = "NewField122321";
                    NewField122321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122321.Value = @"TL";

                    NewField1123221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 63, 129, 68, false);
                    NewField1123221.Name = "NewField1123221";
                    NewField1123221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1123221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1123221.Value = @"TL";

                    ADVANCE_CREDIT_DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 68, 49, 73, false);
                    ADVANCE_CREDIT_DATE.Name = "ADVANCE_CREDIT_DATE";
                    ADVANCE_CREDIT_DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ADVANCE_CREDIT_DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADVANCE_CREDIT_DATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ADVANCE_CREDIT_DATE.Value = @"";

                    WAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 68, 84, 73, false);
                    WAGENO.Name = "WAGENO";
                    WAGENO.DrawStyle = DrawStyleConstants.vbSolid;
                    WAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    WAGENO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    WAGENO.Value = @"";

                    ADVANCEPRICEYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 68, 111, 73, false);
                    ADVANCEPRICEYTL.Name = "ADVANCEPRICEYTL";
                    ADVANCEPRICEYTL.DrawStyle = DrawStyleConstants.vbSolid;
                    ADVANCEPRICEYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADVANCEPRICEYTL.TextFormat = @"NUMBERTEXT(TL)";
                    ADVANCEPRICEYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ADVANCEPRICEYTL.Value = @"";

                    ADVANCEPRICEYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 68, 129, 73, false);
                    ADVANCEPRICEYKR.Name = "ADVANCEPRICEYKR";
                    ADVANCEPRICEYKR.DrawStyle = DrawStyleConstants.vbSolid;
                    ADVANCEPRICEYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADVANCEPRICEYKR.TextFormat = @"NUMBERTEXT(Türk Lirası,Kuruş)";
                    ADVANCEPRICEYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ADVANCEPRICEYKR.Value = @"";

                    DOCUMENTREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 28, 202, 73, false);
                    DOCUMENTREASON.Name = "DOCUMENTREASON";
                    DOCUMENTREASON.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTREASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTREASON.MultiLine = EvetHayirEnum.ehEvet;
                    DOCUMENTREASON.WordBreak = EvetHayirEnum.ehEvet;
                    DOCUMENTREASON.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOCUMENTREASON.TextFont.Size = 9;
                    DOCUMENTREASON.TextFont.CharSet = 162;
                    DOCUMENTREASON.Value = @"";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 13, 202, 28, false);
                    NewField144.Name = "NewField144";
                    NewField144.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField144.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField144.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField144.MultiLine = EvetHayirEnum.ehEvet;
                    NewField144.WordBreak = EvetHayirEnum.ehEvet;
                    NewField144.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField144.Value = @"AÇIKLAMA ve EKLER
(BELGE DÜZENLEME NEDENİ)";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 73, 129, 83, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.Value = @"UYGUNDUR";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 73, 169, 83, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111.Value = @"ÖDEYİNİZ / MAHSUP 
EDİNİZ";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 73, 202, 83, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11111.Value = @"TAHSİL EDİLMİŞTİR / 
ÖDENMİŞTİR";

                    SIGNFIELDOFFINANCING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 83, 79, 108, false);
                    SIGNFIELDOFFINANCING.Name = "SIGNFIELDOFFINANCING";
                    SIGNFIELDOFFINANCING.DrawStyle = DrawStyleConstants.vbSolid;
                    SIGNFIELDOFFINANCING.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNFIELDOFFINANCING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNFIELDOFFINANCING.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFFINANCING.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFFINANCING.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFFINANCING.Value = @"";

                    SIGNFIELDOFHOSPMANGER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 83, 129, 108, false);
                    SIGNFIELDOFHOSPMANGER.Name = "SIGNFIELDOFHOSPMANGER";
                    SIGNFIELDOFHOSPMANGER.DrawStyle = DrawStyleConstants.vbSolid;
                    SIGNFIELDOFHOSPMANGER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNFIELDOFHOSPMANGER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNFIELDOFHOSPMANGER.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFHOSPMANGER.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFHOSPMANGER.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFHOSPMANGER.Value = @"";

                    SIGNFIELDOFACCOUNTINGMANAGER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 83, 169, 108, false);
                    SIGNFIELDOFACCOUNTINGMANAGER.Name = "SIGNFIELDOFACCOUNTINGMANAGER";
                    SIGNFIELDOFACCOUNTINGMANAGER.DrawStyle = DrawStyleConstants.vbSolid;
                    SIGNFIELDOFACCOUNTINGMANAGER.TextFormat = @"Standard";
                    SIGNFIELDOFACCOUNTINGMANAGER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNFIELDOFACCOUNTINGMANAGER.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFACCOUNTINGMANAGER.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFACCOUNTINGMANAGER.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFACCOUNTINGMANAGER.Value = @"..../..../......
Muhasebe Yetkilisi
Adı Soyadı";

                    RECEIPTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 108, 246, 113, false);
                    RECEIPTNO.Name = "RECEIPTNO";
                    RECEIPTNO.Visible = EvetHayirEnum.ehHayir;
                    RECEIPTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RECEIPTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RECEIPTNO.Value = @"";

                    SIGNFIELDOFCASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 83, 202, 108, false);
                    SIGNFIELDOFCASHIER.Name = "SIGNFIELDOFCASHIER";
                    SIGNFIELDOFCASHIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SIGNFIELDOFCASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNFIELDOFCASHIER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNFIELDOFCASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFCASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFCASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNFIELDOFCASHIER.Value = @"";

                    NewRect2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 6, 83, 41, 108, false);
                    NewRect2.Name = "NewRect2";
                    NewRect2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect2.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 84, 41, 89, false);
                    NewField8.Name = "NewField8";
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Düzenleyen";

                    DUZENLEYEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 89, 41, 108, false);
                    DUZENLEYEN.Name = "DUZENLEYEN";
                    DUZENLEYEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUZENLEYEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DUZENLEYEN.MultiLine = EvetHayirEnum.ehEvet;
                    DUZENLEYEN.WordBreak = EvetHayirEnum.ehEvet;
                    DUZENLEYEN.TextFont.CharSet = 162;
                    DUZENLEYEN.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 108, 169, 113, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"       Yalnız:";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 108, 202, 113, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Aldım.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 108, 202, 108, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 108, 6, 113, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 113, 202, 113, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 108, 202, 113, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    DOCUMENTNO.CalcValue = @"NUMARASI";
                    DOCUMENTDATE.CalcValue = @"";
                    NewField132.CalcValue = NewField132.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField12321.CalcValue = NewField12321.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField112321.CalcValue = NewField112321.Value;
                    NewField122321.CalcValue = NewField122321.Value;
                    NewField1123221.CalcValue = NewField1123221.Value;
                    ADVANCE_CREDIT_DATE.CalcValue = @"";
                    WAGENO.CalcValue = @"";
                    ADVANCEPRICEYTL.CalcValue = @"";
                    ADVANCEPRICEYKR.CalcValue = @"";
                    DOCUMENTREASON.CalcValue = @"";
                    NewField144.CalcValue = NewField144.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    SIGNFIELDOFFINANCING.CalcValue = @"";
                    SIGNFIELDOFHOSPMANGER.CalcValue = @"";
                    SIGNFIELDOFACCOUNTINGMANAGER.CalcValue = SIGNFIELDOFACCOUNTINGMANAGER.Value;
                    RECEIPTNO.CalcValue = @"";
                    SIGNFIELDOFCASHIER.CalcValue = @"";
                    NewField8.CalcValue = NewField8.Value;
                    DUZENLEYEN.CalcValue = @"";
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    return new TTReportObject[] { NewField21,NewField22,NewField112,NewField122,NewField101,NewField1101,DOCUMENTNO,DOCUMENTDATE,NewField132,NewField1231,NewField11321,NewField12321,NewField1331,NewField121,NewField1121,NewField112321,NewField122321,NewField1123221,ADVANCE_CREDIT_DATE,WAGENO,ADVANCEPRICEYTL,ADVANCEPRICEYKR,DOCUMENTREASON,NewField144,NewField111,NewField1111,NewField11111,SIGNFIELDOFFINANCING,SIGNFIELDOFHOSPMANGER,SIGNFIELDOFACCOUNTINGMANAGER,RECEIPTNO,SIGNFIELDOFCASHIER,NewField8,DUZENLEYEN,NewField9,NewField10};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    DOCUMENTREASON.CalcValue += "VEZNEDEN TAHSİL EDİLEN KASA BEDELİ" + Environment.NewLine;
            DOCUMENTREASON.CalcValue += MyParentReport.RuntimeParameters.STARTDATE.Value.ToShortDateString() + " - " + MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString() + " ARASI MUTEMETLİK MAHSUBU";

            SIGNFIELDOFFINANCING.CalcValue += MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString() + Environment.NewLine + Environment.NewLine; //TTObjectClasses.Common.RecTime().ToShortDateString() + Environment.NewLine + Environment.NewLine;
            SIGNFIELDOFFINANCING.CalcValue += "Gerçekleştirme Görevlisi" + Environment.NewLine;
            SIGNFIELDOFFINANCING.CalcValue += SystemParameter.GetParameterValue("IDARIVEMALIISLERMUDURU", "") + Environment.NewLine;
            SIGNFIELDOFFINANCING.CalcValue += "İdari ve Mali İşler Müdürü";

            SIGNFIELDOFHOSPMANGER.CalcValue += MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString() + " - " + MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString() + Environment.NewLine + Environment.NewLine; //TTObjectClasses.Common.RecTime().ToShortDateString() + Environment.NewLine;
            SIGNFIELDOFHOSPMANGER.CalcValue += "Harcama Yetkilisi" + Environment.NewLine;
            SIGNFIELDOFHOSPMANGER.CalcValue += SystemParameter.GetParameterValue("HEADDOCTORTITAL", "") + " " + SystemParameter.GetParameterValue("HEADDOCTOR", "");
            SIGNFIELDOFHOSPMANGER.CalcValue += Environment.NewLine + "Başhekim";

            SIGNFIELDOFCASHIER.CalcValue += MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString() + Environment.NewLine; //TTObjectClasses.Common.RecTime().ToShortDateString() + Environment.NewLine;
            SIGNFIELDOFCASHIER.CalcValue += Environment.NewLine + Environment.NewLine + "" + "Veznedar";
            SIGNFIELDOFCASHIER.CalcValue += Environment.NewLine + "Adı Soyadı";

            DUZENLEYEN.CalcValue = TTObjectClasses.Common.RecTime().ToShortDateString() + Environment.NewLine;
            DUZENLEYEN.CalcValue += "Sayman Mutemedi" + Environment.NewLine;
            DUZENLEYEN.CalcValue += TTObjectClasses.Common.CurrentResource.Name;

            RECEIPTNO.CalcValue = "FİŞ NO: /" + MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString(); //TTObjectClasses.Common.RecTime().ToShortDateString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public CashOfficeAccountReport MyParentReport
            {
                get { return (CashOfficeAccountReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PARENTACCOUNTCODE { get {return Header().PARENTACCOUNTCODE;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportField TOTALDEBTPRICEYTL { get {return Footer().TOTALDEBTPRICEYTL;} }
            public TTReportField TOTALRECEIVABLEPRICEYTL { get {return Footer().TOTALRECEIVABLEPRICEYTL;} }
            public TTReportField TOTALDEBTPRICEYKR { get {return Footer().TOTALDEBTPRICEYKR;} }
            public TTReportField TOTALRECEIVABLEPRICEYKR { get {return Footer().TOTALRECEIVABLEPRICEYKR;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportShape NewLine4 { get {return Footer().NewLine4;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine122 { get {return Footer().NewLine122;} }
            public TTReportShape NewLine123 { get {return Footer().NewLine123;} }
            public TTReportShape NewLine124 { get {return Footer().NewLine124;} }
            public TTReportShape NewLine125 { get {return Footer().NewLine125;} }
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
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField PARENTACCOUNTCODE;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine18; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PARENTACCOUNTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 32, 4, false);
                    PARENTACCOUNTCODE.Name = "PARENTACCOUNTCODE";
                    PARENTACCOUNTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARENTACCOUNTCODE.TextFont.Name = "Arial";
                    PARENTACCOUNTCODE.TextFont.Size = 8;
                    PARENTACCOUNTCODE.TextFont.Bold = true;
                    PARENTACCOUNTCODE.TextFont.CharSet = 162;
                    PARENTACCOUNTCODE.Value = @"";

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 6, 4, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 0, 202, 4, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 4, 202, 4, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 202, 0, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARENTACCOUNTCODE.CalcValue = @"";
                    return new TTReportObject[] { PARENTACCOUNTCODE};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if(MyParentReport.accountInfoList != null && MyParentReport.accountInfoList.Count > 0)
            {
                this.PARENTACCOUNTCODE.CalcValue = MyParentReport.accountInfoList.OrderBy(x => x.ParentAccountCode).Select(x => x.ParentAccountCode).Distinct().ToList()[MyParentReport.ParentAccountCodeCounter].ToString();
                MyParentReport.ParentAccountCodeCounter++;
                MyParentReport.MAIN.RepeatCount = MyParentReport.accountInfoList.OrderBy(x => x.AccountCode).Where(x => x.ParentAccountCode == MyParentReport.PARTB.PARENTACCOUNTCODE.CalcValue).Count();
            }
            
            if (MyParentReport.show800Accounts)
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField TOTALDEBTPRICEYTL;
                public TTReportField TOTALRECEIVABLEPRICEYTL;
                public TTReportField TOTALDEBTPRICEYKR;
                public TTReportField TOTALRECEIVABLEPRICEYKR;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine1;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine123;
                public TTReportShape NewLine124;
                public TTReportShape NewLine125; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    TOTALDEBTPRICEYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 118, 4, false);
                    TOTALDEBTPRICEYTL.Name = "TOTALDEBTPRICEYTL";
                    TOTALDEBTPRICEYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDEBTPRICEYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDEBTPRICEYTL.TextFont.Name = "Arial";
                    TOTALDEBTPRICEYTL.TextFont.Size = 8;
                    TOTALDEBTPRICEYTL.TextFont.Bold = true;
                    TOTALDEBTPRICEYTL.TextFont.CharSet = 162;
                    TOTALDEBTPRICEYTL.Value = @"";

                    TOTALRECEIVABLEPRICEYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 141, 4, false);
                    TOTALRECEIVABLEPRICEYTL.Name = "TOTALRECEIVABLEPRICEYTL";
                    TOTALRECEIVABLEPRICEYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALRECEIVABLEPRICEYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALRECEIVABLEPRICEYTL.TextFont.Name = "Arial";
                    TOTALRECEIVABLEPRICEYTL.TextFont.Size = 8;
                    TOTALRECEIVABLEPRICEYTL.TextFont.Bold = true;
                    TOTALRECEIVABLEPRICEYTL.TextFont.CharSet = 162;
                    TOTALRECEIVABLEPRICEYTL.Value = @"";

                    TOTALDEBTPRICEYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 128, 4, false);
                    TOTALDEBTPRICEYKR.Name = "TOTALDEBTPRICEYKR";
                    TOTALDEBTPRICEYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDEBTPRICEYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDEBTPRICEYKR.TextFont.Name = "Arial";
                    TOTALDEBTPRICEYKR.TextFont.Size = 8;
                    TOTALDEBTPRICEYKR.TextFont.Bold = true;
                    TOTALDEBTPRICEYKR.TextFont.CharSet = 162;
                    TOTALDEBTPRICEYKR.Value = @"";

                    TOTALRECEIVABLEPRICEYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 151, 4, false);
                    TOTALRECEIVABLEPRICEYKR.Name = "TOTALRECEIVABLEPRICEYKR";
                    TOTALRECEIVABLEPRICEYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALRECEIVABLEPRICEYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALRECEIVABLEPRICEYKR.TextFont.Name = "Arial";
                    TOTALRECEIVABLEPRICEYKR.TextFont.Size = 8;
                    TOTALRECEIVABLEPRICEYKR.TextFont.Bold = true;
                    TOTALRECEIVABLEPRICEYKR.TextFont.CharSet = 162;
                    TOTALRECEIVABLEPRICEYKR.Value = @"";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 6, 4, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 4, 202, 4, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 0, 202, 4, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 202, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 106, 0, 106, 4, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 0, 119, 4, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 129, 0, 129, 4, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 142, 0, 142, 4, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine124.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine125 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 0, 152, 4, false);
                    NewLine125.Name = "NewLine125";
                    NewLine125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine125.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTALDEBTPRICEYTL.CalcValue = @"";
                    TOTALRECEIVABLEPRICEYTL.CalcValue = @"";
                    TOTALDEBTPRICEYKR.CalcValue = @"";
                    TOTALRECEIVABLEPRICEYKR.CalcValue = @"";
                    return new TTReportObject[] { TOTALDEBTPRICEYTL,TOTALRECEIVABLEPRICEYTL,TOTALDEBTPRICEYKR,TOTALRECEIVABLEPRICEYKR};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    TOTALDEBTPRICEYTL.CalcValue = MyParentReport.GetYTL(MyParentReport.TotalDebtPriceTotal);
            TOTALDEBTPRICEYKR.CalcValue = MyParentReport.GetYKR(MyParentReport.TotalDebtPriceTotal);

            TOTALRECEIVABLEPRICEYTL.CalcValue = MyParentReport.GetYTL(MyParentReport.TotalReceivablePrice);
            TOTALRECEIVABLEPRICEYKR.CalcValue = MyParentReport.GetYKR(MyParentReport.TotalReceivablePrice);
            
            if (MyParentReport.AccountCodeCounter >= MyParentReport.MAIN.RepeatCount)
            {
                MyParentReport.TotalDebtPriceTotal = 0;
                MyParentReport.TotalReceivablePrice = 0;
                MyParentReport.AccountCodeCounter = 0;
            }
            
            if (MyParentReport.show800Accounts)
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public CashOfficeAccountReport MyParentReport
            {
                get { return (CashOfficeAccountReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SUTKODU { get {return Body().SUTKODU;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField DEBTYTL { get {return Body().DEBTYTL;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField DEBTYKR { get {return Body().DEBTYKR;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportField RECEIVABLEYTL { get {return Body().RECEIVABLEYTL;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportField RECEIVABLEYKR { get {return Body().RECEIVABLEYKR;} }
            public TTReportShape NewLine1221 { get {return Body().NewLine1221;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportShape NewLine11221 { get {return Body().NewLine11221;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField SUTKODU;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportField DEBTYTL;
                public TTReportShape NewLine121;
                public TTReportField DEBTYKR;
                public TTReportShape NewLine122;
                public TTReportField RECEIVABLEYTL;
                public TTReportShape NewLine1121;
                public TTReportField RECEIVABLEYKR;
                public TTReportShape NewLine1221;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine11221;
                public TTReportShape NewLine3;
                public TTReportShape NewLine13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    SUTKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 105, 4, false);
                    SUTKODU.Name = "SUTKODU";
                    SUTKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTKODU.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTKODU.TextFont.Size = 8;
                    SUTKODU.TextFont.CharSet = 162;
                    SUTKODU.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 6, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 106, 0, 106, 4, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    DEBTYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 118, 4, false);
                    DEBTYTL.Name = "DEBTYTL";
                    DEBTYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBTYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEBTYTL.MultiLine = EvetHayirEnum.ehEvet;
                    DEBTYTL.WordBreak = EvetHayirEnum.ehEvet;
                    DEBTYTL.ExpandTabs = EvetHayirEnum.ehEvet;
                    DEBTYTL.TextFont.Size = 8;
                    DEBTYTL.TextFont.CharSet = 162;
                    DEBTYTL.Value = @"";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 0, 119, 4, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extSectionHeight;

                    DEBTYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 128, 4, false);
                    DEBTYKR.Name = "DEBTYKR";
                    DEBTYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBTYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEBTYKR.MultiLine = EvetHayirEnum.ehEvet;
                    DEBTYKR.WordBreak = EvetHayirEnum.ehEvet;
                    DEBTYKR.ExpandTabs = EvetHayirEnum.ehEvet;
                    DEBTYKR.TextFont.Size = 8;
                    DEBTYKR.TextFont.CharSet = 162;
                    DEBTYKR.Value = @"";

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 129, 0, 129, 4, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extSectionHeight;

                    RECEIVABLEYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 141, 4, false);
                    RECEIVABLEYTL.Name = "RECEIVABLEYTL";
                    RECEIVABLEYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVABLEYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RECEIVABLEYTL.MultiLine = EvetHayirEnum.ehEvet;
                    RECEIVABLEYTL.WordBreak = EvetHayirEnum.ehEvet;
                    RECEIVABLEYTL.ExpandTabs = EvetHayirEnum.ehEvet;
                    RECEIVABLEYTL.TextFont.Size = 8;
                    RECEIVABLEYTL.TextFont.CharSet = 162;
                    RECEIVABLEYTL.Value = @"";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 142, 0, 142, 4, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extSectionHeight;

                    RECEIVABLEYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 151, 4, false);
                    RECEIVABLEYKR.Name = "RECEIVABLEYKR";
                    RECEIVABLEYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVABLEYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RECEIVABLEYKR.MultiLine = EvetHayirEnum.ehEvet;
                    RECEIVABLEYKR.WordBreak = EvetHayirEnum.ehEvet;
                    RECEIVABLEYKR.ExpandTabs = EvetHayirEnum.ehEvet;
                    RECEIVABLEYKR.TextFont.Size = 8;
                    RECEIVABLEYKR.TextFont.CharSet = 162;
                    RECEIVABLEYKR.Value = @"";

                    NewLine1221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 0, 152, 4, false);
                    NewLine1221.Name = "NewLine1221";
                    NewLine1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1221.ExtendTo = ExtendToEnum.extSectionHeight;

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 201, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    NewLine11221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 0, 202, 4, false);
                    NewLine11221.Name = "NewLine11221";
                    NewLine11221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11221.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 4, 202, 4, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 202, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUTKODU.CalcValue = @"";
                    DEBTYTL.CalcValue = @"";
                    DEBTYKR.CalcValue = @"";
                    RECEIVABLEYTL.CalcValue = @"";
                    RECEIVABLEYKR.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    return new TTReportObject[] { SUTKODU,DEBTYTL,DEBTYKR,RECEIVABLEYTL,RECEIVABLEYKR,DESCRIPTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    List<AccountInfo> accInfoList = MyParentReport.accountInfoList.OrderBy(x => x.AccountCode).Where(x => x.ParentAccountCode == MyParentReport.PARTB.PARENTACCOUNTCODE.CalcValue).ToList();
            
            if(accInfoList != null && accInfoList.Count > 0)
            {
                AccountInfo item = accInfoList[MyParentReport.AccountCodeCounter];
                this.SUTKODU.CalcValue = item.AccountCode.ToString();
                this.DESCRIPTION.CalcValue = item.Description;
                this.RECEIVABLEYTL.CalcValue = MyParentReport.GetYTL(item.ReceivablePrice);
                this.RECEIVABLEYKR.CalcValue = MyParentReport.GetYKR(item.ReceivablePrice);
                this.DEBTYTL.CalcValue = MyParentReport.GetYTL(item.DebtPrice);
                this.DEBTYKR.CalcValue = MyParentReport.GetYKR(item.DebtPrice);
                MyParentReport.TotalReceivablePrice += item.ReceivablePrice;
                MyParentReport.TotalDebtPriceTotal += item.DebtPrice;
                MyParentReport.AccountCodeCounter++;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public CashOfficeAccountReport MyParentReport
            {
                get { return (CashOfficeAccountReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField TOPLAMLBL { get {return Body().TOPLAMLBL;} }
            public TTReportField GELIRLBL { get {return Body().GELIRLBL;} }
            public TTReportField TOPLAMLBL3 { get {return Body().TOPLAMLBL3;} }
            public TTReportField TOPLAMLBL4 { get {return Body().TOPLAMLBL4;} }
            public TTReportField GBYTL { get {return Body().GBYTL;} }
            public TTReportField GBYKR { get {return Body().GBYKR;} }
            public TTReportField GAYTL { get {return Body().GAYTL;} }
            public TTReportField GAYKR { get {return Body().GAYKR;} }
            public TTReportField TOPLAMLBL1 { get {return Body().TOPLAMLBL1;} }
            public TTReportField TOPLAMLBL2 { get {return Body().TOPLAMLBL2;} }
            public TTReportField TBYTL { get {return Body().TBYTL;} }
            public TTReportField TBYKR { get {return Body().TBYKR;} }
            public TTReportField TAYTL { get {return Body().TAYTL;} }
            public TTReportField TAYKR { get {return Body().TAYKR;} }
            public TTReportField TBYTL1 { get {return Body().TBYTL1;} }
            public TTReportField TBYKR1 { get {return Body().TBYKR1;} }
            public TTReportField TAYTL1 { get {return Body().TAYTL1;} }
            public TTReportField TAYKR1 { get {return Body().TAYKR1;} }
            public TTReportField EMPTYFIELD { get {return Body().EMPTYFIELD;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public CashOfficeAccountReport MyParentReport
                {
                    get { return (CashOfficeAccountReport)ParentReport; }
                }
                
                public TTReportField TOPLAMLBL;
                public TTReportField GELIRLBL;
                public TTReportField TOPLAMLBL3;
                public TTReportField TOPLAMLBL4;
                public TTReportField GBYTL;
                public TTReportField GBYKR;
                public TTReportField GAYTL;
                public TTReportField GAYKR;
                public TTReportField TOPLAMLBL1;
                public TTReportField TOPLAMLBL2;
                public TTReportField TBYTL;
                public TTReportField TBYKR;
                public TTReportField TAYTL;
                public TTReportField TAYKR;
                public TTReportField TBYTL1;
                public TTReportField TBYKR1;
                public TTReportField TAYTL1;
                public TTReportField TAYKR1;
                public TTReportField EMPTYFIELD; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    TOPLAMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 202, 5, false);
                    TOPLAMLBL.Name = "TOPLAMLBL";
                    TOPLAMLBL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMLBL.TextFont.Size = 9;
                    TOPLAMLBL.TextFont.Bold = true;
                    TOPLAMLBL.TextFont.CharSet = 162;
                    TOPLAMLBL.Value = @"TOPLAMLAR";

                    GELIRLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 5, 106, 10, false);
                    GELIRLBL.Name = "GELIRLBL";
                    GELIRLBL.DrawStyle = DrawStyleConstants.vbSolid;
                    GELIRLBL.TextFont.Size = 8;
                    GELIRLBL.TextFont.CharSet = 162;
                    GELIRLBL.Value = @"Gelirler";

                    TOPLAMLBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 10, 106, 15, false);
                    TOPLAMLBL3.Name = "TOPLAMLBL3";
                    TOPLAMLBL3.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMLBL3.TextFont.Size = 8;
                    TOPLAMLBL3.TextFont.CharSet = 162;
                    TOPLAMLBL3.Value = @"Toplam";

                    TOPLAMLBL4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 106, 20, false);
                    TOPLAMLBL4.Name = "TOPLAMLBL4";
                    TOPLAMLBL4.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMLBL4.TextFont.Size = 8;
                    TOPLAMLBL4.TextFont.Bold = true;
                    TOPLAMLBL4.TextFont.CharSet = 162;
                    TOPLAMLBL4.Value = @"TOPLAM";

                    GBYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 5, 119, 10, false);
                    GBYTL.Name = "GBYTL";
                    GBYTL.DrawStyle = DrawStyleConstants.vbSolid;
                    GBYTL.TextFormat = @"General Number";
                    GBYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GBYTL.TextFont.Size = 8;
                    GBYTL.TextFont.CharSet = 162;
                    GBYTL.Value = @"0";

                    GBYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 5, 129, 10, false);
                    GBYKR.Name = "GBYKR";
                    GBYKR.DrawStyle = DrawStyleConstants.vbSolid;
                    GBYKR.TextFormat = @"General Number";
                    GBYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GBYKR.TextFont.Size = 8;
                    GBYKR.TextFont.CharSet = 162;
                    GBYKR.Value = @"00";

                    GAYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 5, 142, 10, false);
                    GAYTL.Name = "GAYTL";
                    GAYTL.DrawStyle = DrawStyleConstants.vbSolid;
                    GAYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    GAYTL.TextFormat = @"General Number";
                    GAYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GAYTL.TextFont.Size = 8;
                    GAYTL.TextFont.CharSet = 162;
                    GAYTL.Value = @"";

                    GAYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 5, 152, 10, false);
                    GAYKR.Name = "GAYKR";
                    GAYKR.DrawStyle = DrawStyleConstants.vbSolid;
                    GAYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GAYKR.TextFormat = @"General Number";
                    GAYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GAYKR.TextFont.Size = 8;
                    GAYKR.TextFont.CharSet = 162;
                    GAYKR.Value = @"";

                    TOPLAMLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 5, 202, 10, false);
                    TOPLAMLBL1.Name = "TOPLAMLBL1";
                    TOPLAMLBL1.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMLBL1.TextFont.Size = 8;
                    TOPLAMLBL1.TextFont.CharSet = 162;
                    TOPLAMLBL1.Value = @"Toplam";

                    TOPLAMLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 10, 202, 15, false);
                    TOPLAMLBL2.Name = "TOPLAMLBL2";
                    TOPLAMLBL2.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMLBL2.TextFont.Size = 8;
                    TOPLAMLBL2.TextFont.CharSet = 162;
                    TOPLAMLBL2.Value = @"Toplam";

                    TBYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 10, 119, 15, false);
                    TBYTL.Name = "TBYTL";
                    TBYTL.DrawStyle = DrawStyleConstants.vbSolid;
                    TBYTL.TextFormat = @"General Number";
                    TBYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TBYTL.TextFont.Size = 8;
                    TBYTL.TextFont.CharSet = 162;
                    TBYTL.Value = @"0";

                    TBYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 10, 129, 15, false);
                    TBYKR.Name = "TBYKR";
                    TBYKR.DrawStyle = DrawStyleConstants.vbSolid;
                    TBYKR.TextFormat = @"General Number";
                    TBYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TBYKR.TextFont.Size = 8;
                    TBYKR.TextFont.CharSet = 162;
                    TBYKR.Value = @"00";

                    TAYTL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 10, 142, 15, false);
                    TAYTL.Name = "TAYTL";
                    TAYTL.DrawStyle = DrawStyleConstants.vbSolid;
                    TAYTL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAYTL.TextFormat = @"General Number";
                    TAYTL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TAYTL.TextFont.Size = 8;
                    TAYTL.TextFont.CharSet = 162;
                    TAYTL.Value = @"";

                    TAYKR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 10, 152, 15, false);
                    TAYKR.Name = "TAYKR";
                    TAYKR.DrawStyle = DrawStyleConstants.vbSolid;
                    TAYKR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAYKR.TextFormat = @"General Number";
                    TAYKR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TAYKR.TextFont.Size = 8;
                    TAYKR.TextFont.CharSet = 162;
                    TAYKR.Value = @"";

                    TBYTL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 15, 119, 20, false);
                    TBYTL1.Name = "TBYTL1";
                    TBYTL1.DrawStyle = DrawStyleConstants.vbSolid;
                    TBYTL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TBYTL1.TextFormat = @"General Number";
                    TBYTL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TBYTL1.TextFont.Size = 8;
                    TBYTL1.TextFont.Bold = true;
                    TBYTL1.TextFont.CharSet = 162;
                    TBYTL1.Value = @"";

                    TBYKR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 15, 129, 20, false);
                    TBYKR1.Name = "TBYKR1";
                    TBYKR1.DrawStyle = DrawStyleConstants.vbSolid;
                    TBYKR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TBYKR1.TextFormat = @"General Number";
                    TBYKR1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TBYKR1.TextFont.Size = 8;
                    TBYKR1.TextFont.Bold = true;
                    TBYKR1.TextFont.CharSet = 162;
                    TBYKR1.Value = @"";

                    TAYTL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 15, 142, 20, false);
                    TAYTL1.Name = "TAYTL1";
                    TAYTL1.DrawStyle = DrawStyleConstants.vbSolid;
                    TAYTL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAYTL1.TextFormat = @"General Number";
                    TAYTL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TAYTL1.TextFont.Size = 8;
                    TAYTL1.TextFont.Bold = true;
                    TAYTL1.TextFont.CharSet = 162;
                    TAYTL1.Value = @"";

                    TAYKR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 15, 152, 20, false);
                    TAYKR1.Name = "TAYKR1";
                    TAYKR1.DrawStyle = DrawStyleConstants.vbSolid;
                    TAYKR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAYKR1.TextFormat = @"General Number";
                    TAYKR1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TAYKR1.TextFont.Size = 8;
                    TAYKR1.TextFont.Bold = true;
                    TAYKR1.TextFont.CharSet = 162;
                    TAYKR1.Value = @"";

                    EMPTYFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 15, 202, 20, false);
                    EMPTYFIELD.Name = "EMPTYFIELD";
                    EMPTYFIELD.DrawStyle = DrawStyleConstants.vbSolid;
                    EMPTYFIELD.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMLBL.CalcValue = TOPLAMLBL.Value;
                    GELIRLBL.CalcValue = GELIRLBL.Value;
                    TOPLAMLBL3.CalcValue = TOPLAMLBL3.Value;
                    TOPLAMLBL4.CalcValue = TOPLAMLBL4.Value;
                    GBYTL.CalcValue = GBYTL.Value;
                    GBYKR.CalcValue = GBYKR.Value;
                    GAYTL.CalcValue = @"";
                    GAYKR.CalcValue = @"";
                    TOPLAMLBL1.CalcValue = TOPLAMLBL1.Value;
                    TOPLAMLBL2.CalcValue = TOPLAMLBL2.Value;
                    TBYTL.CalcValue = TBYTL.Value;
                    TBYKR.CalcValue = TBYKR.Value;
                    TAYTL.CalcValue = @"";
                    TAYKR.CalcValue = @"";
                    TBYTL1.CalcValue = @"";
                    TBYKR1.CalcValue = @"";
                    TAYTL1.CalcValue = @"";
                    TAYKR1.CalcValue = @"";
                    EMPTYFIELD.CalcValue = EMPTYFIELD.Value;
                    return new TTReportObject[] { TOPLAMLBL,GELIRLBL,TOPLAMLBL3,TOPLAMLBL4,GBYTL,GBYKR,GAYTL,GAYKR,TOPLAMLBL1,TOPLAMLBL2,TBYTL,TBYKR,TAYTL,TAYKR,TBYTL1,TBYKR1,TAYTL1,TAYKR1,EMPTYFIELD};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    if (MyParentReport.show800Accounts == false) // GAZİLER FTR
            {
                Currency receivablePrice = MyParentReport.accountInfoList.Where(x => x.AccountCode == "336.06.01" || x.AccountCode == "336.06.02" || x.ParentAccountCode == "600" || x.ParentAccountCode == "601").Sum(x => (decimal)x.ReceivablePrice);
                GAYTL.CalcValue = MyParentReport.GetYTL(receivablePrice);
                GAYKR.CalcValue = MyParentReport.GetYKR(receivablePrice);

                Currency totalReceivablePrice = MyParentReport.accountInfoList.Where(x => x.ReceivablePrice > 0).Sum(x => (decimal)x.ReceivablePrice);
                TAYTL.CalcValue = MyParentReport.GetYTL(totalReceivablePrice);
                TAYKR.CalcValue = MyParentReport.GetYKR(totalReceivablePrice);
                TAYTL1.CalcValue = TAYTL.CalcValue;
                TAYKR1.CalcValue = TAYKR.CalcValue;

                Currency totalDebtPrice = MyParentReport.accountInfoList.Where(x => x.DebtPrice > 0).Sum(x => (decimal)x.DebtPrice);
                TBYTL1.CalcValue = MyParentReport.GetYTL(totalDebtPrice);
                TBYKR1.CalcValue = MyParentReport.GetYKR(totalDebtPrice);
            }
            else // PURSAKLAR
            {
                Currency receivablePrice = MyParentReport.accountInfoList.Where(x => x.ParentAccountCode == "600" || x.ParentAccountCode == "601").Sum(x => (decimal)x.ReceivablePrice);
                GAYTL.CalcValue = MyParentReport.GetYTL(receivablePrice);
                GAYKR.CalcValue = MyParentReport.GetYKR(receivablePrice);

                // 336.06.01 Alacak toplamına dahil edilmez, karşılığındaki borç ta listeye eklenmemiş olduğu için borç alacak toplamları eşit olur
                Currency totalReceivablePrice = MyParentReport.accountInfoList.Where(x => x.ReceivablePrice > 0 && x.AccountCode != "336.06.01" && x.AccountCode != "336.06.02").Sum(x => (decimal)x.ReceivablePrice);
                TAYTL.CalcValue = MyParentReport.GetYTL(totalReceivablePrice);
                TAYKR.CalcValue = MyParentReport.GetYKR(totalReceivablePrice);
                TAYTL1.CalcValue = TAYTL.CalcValue;
                TAYKR1.CalcValue = TAYKR.CalcValue;

                Currency totalDebtPrice = MyParentReport.accountInfoList.Where(x => x.DebtPrice > 0).Sum(x => (decimal)x.DebtPrice);
                TBYTL1.CalcValue = MyParentReport.GetYTL(totalDebtPrice);
                TBYKR1.CalcValue = MyParentReport.GetYKR(totalDebtPrice);
            }
            
            //            if (MyParentReport.show800Accounts)
            //            {
            //                this.TOPLAMLBL.Visible = EvetHayirEnum.ehHayir;

            //                this.GELIRLBL.Visible = EvetHayirEnum.ehHayir;
            //                this.GBYTL.Visible = EvetHayirEnum.ehHayir;
            //                this.GBYKR.Visible = EvetHayirEnum.ehHayir;
            //                this.GAYTL.Visible = EvetHayirEnum.ehHayir;
            //                this.GAYKR.Visible = EvetHayirEnum.ehHayir;
            //                this.TOPLAMLBL1.Visible = EvetHayirEnum.ehHayir;

            //                this.TOPLAMLBL3.Visible = EvetHayirEnum.ehHayir;
            //                this.TBYTL.Visible = EvetHayirEnum.ehHayir;
            //                this.TBYKR.Visible = EvetHayirEnum.ehHayir;
            //                this.TAYTL.Visible = EvetHayirEnum.ehHayir;
            //                this.TAYKR.Visible = EvetHayirEnum.ehHayir;
            //                this.TOPLAMLBL2.Visible = EvetHayirEnum.ehHayir;

            //                this.TOPLAMLBL4.Y1 -= 15;
            //                this.TBYTL1.Y1 -= 15;
            //                this.TBYKR1.Y1 -= 15;
            //                this.TAYTL1.Y1 -= 15;
            //                this.TAYKR1.Y1 -= 15;
            //                this.EMPTYFIELD.Y1 -= 15;
            //            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CashOfficeAccountReport()
        {
            PARTD = new PARTDGroup(this,"PARTD");
            PARTA = new PARTAGroup(PARTD,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CASHOFFICE", "00000000-0000-0000-0000-000000000000", "Vezne", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("ffa9d300-1561-46fa-a262-4126167d70a5");
            reportParameter = Parameters.Add("CASHOFFICECONTROL", "", "Vezne Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("CASHIER", "00000000-0000-0000-0000-000000000000", "Veznedar", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("b91d94bd-e04f-48fb-ada4-edbeb0973d62");
            reportParameter = Parameters.Add("CASHIERCONTROL", "", "Veznedar Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PAYMENTTYPE", "", "Ödeme Tipi", @"", false, true, false, new Guid("44fa3277-ac8f-4c8f-855c-11b370e2ac95"));
            reportParameter = Parameters.Add("PAYMENTTYPECONTROL", "", "Ödeme Tipi Kontrolü", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("USETIME", "", "Saat Bazlı", @"", false, true, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CASHOFFICE"))
                _runtimeParameters.CASHOFFICE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CASHOFFICE"]);
            if (parameters.ContainsKey("CASHOFFICECONTROL"))
                _runtimeParameters.CASHOFFICECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CASHOFFICECONTROL"]);
            if (parameters.ContainsKey("CASHIER"))
                _runtimeParameters.CASHIER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CASHIER"]);
            if (parameters.ContainsKey("CASHIERCONTROL"))
                _runtimeParameters.CASHIERCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CASHIERCONTROL"]);
            if (parameters.ContainsKey("PAYMENTTYPE"))
                _runtimeParameters.PAYMENTTYPE = (PaymentTypeCashCCEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].ConvertValue(parameters["PAYMENTTYPE"]);
            if (parameters.ContainsKey("PAYMENTTYPECONTROL"))
                _runtimeParameters.PAYMENTTYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYMENTTYPECONTROL"]);
            if (parameters.ContainsKey("USETIME"))
                _runtimeParameters.USETIME = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["USETIME"]);
            Name = "CASHOFFICEACCOUNTREPORT";
            Caption = "Muhasebe İşlem Fişi";
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