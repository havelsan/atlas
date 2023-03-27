
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
    /// Farure Gönderme Fatura Ön Yazısı
    /// </summary>
    public partial class InvoicePostingPreReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public InvoicePostingPreReport MyParentReport
            {
                get { return (InvoicePostingPreReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField PAYERNAME { get {return Header().PAYERNAME;} }
            public TTReportField PAYERCITY { get {return Header().PAYERCITY;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField CODE { get {return Header().CODE;} }
            public TTReportField SUBJECT { get {return Header().SUBJECT;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField PAYERTEXT { get {return Header().PAYERTEXT;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField AMOUNTOFINVOICE { get {return Footer().AMOUNTOFINVOICE;} }
            public TTReportField AMOUNTOFTRANSFERDOCUMENT { get {return Footer().AMOUNTOFTRANSFERDOCUMENT;} }
            public TTReportField AMOUNTOFINVOICEPOSTINGLIST { get {return Footer().AMOUNTOFINVOICEPOSTINGLIST;} }
            public TTReportField ACCOUNTANTNAME { get {return Footer().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Footer().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT3 { get {return Footer().ACCOUNTANT3;} }
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
                list[0] = new TTReportNqlData<InvoicePosting.InvoicePostingPreReportQuery_Class>("InvoicePostingPreReportQuery", InvoicePosting.InvoicePostingPreReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InvoicePostingPreReport MyParentReport
                {
                    get { return (InvoicePostingPreReport)ParentReport; }
                }
                
                public TTReportField PAYERNAME;
                public TTReportField PAYERCITY;
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField CODE;
                public TTReportField SUBJECT;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField DATE;
                public TTReportField BASLIK;
                public TTReportField PAYERTEXT;
                public TTReportField NewField1; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAYERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 60, 259, 67, false);
                    PAYERNAME.Name = "PAYERNAME";
                    PAYERNAME.Visible = EvetHayirEnum.ehHayir;
                    PAYERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERNAME.NoClip = EvetHayirEnum.ehEvet;
                    PAYERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERNAME.TextFont.Name = "Arial Narrow";
                    PAYERNAME.TextFont.Size = 12;
                    PAYERNAME.Value = @"                       {#PAYERNAME#}";

                    PAYERCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 70, 259, 76, false);
                    PAYERCITY.Name = "PAYERCITY";
                    PAYERCITY.Visible = EvetHayirEnum.ehHayir;
                    PAYERCITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCITY.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERCITY.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERCITY.NoClip = EvetHayirEnum.ehEvet;
                    PAYERCITY.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERCITY.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERCITY.TextFont.Name = "Arial Narrow";
                    PAYERCITY.TextFont.Size = 12;
                    PAYERCITY.Value = @"{#PAYERCITY#}";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 42, 31, 47, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Sayı";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 48, 31, 53, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Konu";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 42, 102, 47, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftExpression;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.Size = 12;
                    CODE.Value = @"{#POSTINGNUMBER#}";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 48, 102, 53, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUBJECT.TextFont.Name = "Arial Narrow";
                    SUBJECT.TextFont.Size = 12;
                    SUBJECT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGPREREPORTSUBJECT"", """")";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 42, 33, 47, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 48, 33, 53, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 12;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 41, 174, 47, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE.TextFont.Name = "Arial Narrow";
                    DATE.TextFont.Size = 12;
                    DATE.Value = @"{#ACTIONDATE#}";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 19, 139, 32, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.DrawWidth = 2;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Arial Narrow";
                    BASLIK.TextFont.Size = 12;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDSNAME"", """")
";

                    PAYERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 62, 175, 69, false);
                    PAYERTEXT.Name = "PAYERTEXT";
                    PAYERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERTEXT.NoClip = EvetHayirEnum.ehEvet;
                    PAYERTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERTEXT.TextFont.Name = "Arial Narrow";
                    PAYERTEXT.TextFont.Size = 12;
                    PAYERTEXT.Value = @"{#PAYERNAME#}  {#PAYERCITY#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 14, 104, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"T.C.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingPreReportQuery_Class dataset_InvoicePostingPreReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPreReportQuery_Class>(0);
                    PAYERNAME.CalcValue = @"                       " + (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Payername) : "");
                    PAYERCITY.CalcValue = (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Payercity) : "");
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    DATE.CalcValue = (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.ActionDate) : "");
                    PAYERTEXT.CalcValue = (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Payername) : "") + @"  " + (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Payercity) : "");
                    NewField1.CalcValue = NewField1.Value;
                    CODE.CalcValue = (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.PostingNumber) : "");
                    SUBJECT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGPREREPORTSUBJECT", "");
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDSNAME", "")
;
                    return new TTReportObject[] { PAYERNAME,PAYERCITY,NewField,NewField2,NewField3,NewField4,DATE,PAYERTEXT,NewField1,CODE,SUBJECT,BASLIK};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    string s = new string (' ',23);
            
  //          this.PAYERTEXT.CalcValue = s + this.PAYERNAME.CalcValue ;
  //        string s2 = new string (' ',this.PAYERTEXT.Length.ToInt());
  //          this.PAYERTEXT.CalcValue = this.PAYERTEXT.CalcValue + "\r\n" + s2 + this.PAYERCITY.CalcValue ;
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public InvoicePostingPreReport MyParentReport
                {
                    get { return (InvoicePostingPreReport)ParentReport; }
                }
                
                public TTReportField AMOUNTOFINVOICE;
                public TTReportField AMOUNTOFTRANSFERDOCUMENT;
                public TTReportField AMOUNTOFINVOICEPOSTINGLIST;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT3; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 52;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    AMOUNTOFINVOICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 18, 88, 23, false);
                    AMOUNTOFINVOICE.Name = "AMOUNTOFINVOICE";
                    AMOUNTOFINVOICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTOFINVOICE.TextFont.Name = "Arial Narrow";
                    AMOUNTOFINVOICE.TextFont.Size = 12;
                    AMOUNTOFINVOICE.Value = @"EK-A ({#INVOICEAMOUNT#} Adet Fatura)";

                    AMOUNTOFTRANSFERDOCUMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 24, 88, 29, false);
                    AMOUNTOFTRANSFERDOCUMENT.Name = "AMOUNTOFTRANSFERDOCUMENT";
                    AMOUNTOFTRANSFERDOCUMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTOFTRANSFERDOCUMENT.TextFont.Name = "Arial Narrow";
                    AMOUNTOFTRANSFERDOCUMENT.TextFont.Size = 12;
                    AMOUNTOFTRANSFERDOCUMENT.Value = @"EK-B ({#INVOICEAMOUNT#} Adet Sevk Kağıdı)";

                    AMOUNTOFINVOICEPOSTINGLIST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 30, 88, 35, false);
                    AMOUNTOFINVOICEPOSTINGLIST.Name = "AMOUNTOFINVOICEPOSTINGLIST";
                    AMOUNTOFINVOICEPOSTINGLIST.TextFont.Name = "Arial Narrow";
                    AMOUNTOFINVOICEPOSTINGLIST.TextFont.Size = 12;
                    AMOUNTOFINVOICEPOSTINGLIST.Value = @"EK-C (1 Adet İcmal Listesi)";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 3, 175, 8, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.TextFont.CharSet = 1;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGPREREPORTACCOUNTANTNAME"", """")
";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 8, 175, 13, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.TextFont.CharSet = 1;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGPREREPORTACCOUNTANTTITLE"", """")
";

                    ACCOUNTANT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 13, 175, 18, false);
                    ACCOUNTANT3.Name = "ACCOUNTANT3";
                    ACCOUNTANT3.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT3.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT3.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT3.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT3.TextFont.CharSet = 1;
                    ACCOUNTANT3.Value = @"Döner Sermaye İşl. M.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingPreReportQuery_Class dataset_InvoicePostingPreReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPreReportQuery_Class>(0);
                    AMOUNTOFINVOICE.CalcValue = @"EK-A (" + (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Invoiceamount) : "") + @" Adet Fatura)";
                    AMOUNTOFTRANSFERDOCUMENT.CalcValue = @"EK-B (" + (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Invoiceamount) : "") + @" Adet Sevk Kağıdı)";
                    AMOUNTOFINVOICEPOSTINGLIST.CalcValue = AMOUNTOFINVOICEPOSTINGLIST.Value;
                    ACCOUNTANT3.CalcValue = ACCOUNTANT3.Value;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGPREREPORTACCOUNTANTNAME", "")
;
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGPREREPORTACCOUNTANTTITLE", "")
;
                    return new TTReportObject[] { AMOUNTOFINVOICE,AMOUNTOFTRANSFERDOCUMENT,AMOUNTOFINVOICEPOSTINGLIST,ACCOUNTANT3,ACCOUNTANTNAME,ACCOUNTANTTITLE};
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public InvoicePostingPreReport MyParentReport
            {
                get { return (InvoicePostingPreReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BODYTEXT { get {return Body().BODYTEXT;} }
            public TTReportField HOSPITALNAME { get {return Body().HOSPITALNAME;} }
            public TTReportField INVOICEAMOUNT { get {return Body().INVOICEAMOUNT;} }
            public TTReportField TOTALINVOICEPRICE { get {return Body().TOTALINVOICEPRICE;} }
            public TTReportField BANKACCOUNT { get {return Body().BANKACCOUNT;} }
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

                InvoicePosting.InvoicePostingPreReportQuery_Class dataSet_InvoicePostingPreReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPreReportQuery_Class>(0);    
                return new object[] {(dataSet_InvoicePostingPreReportQuery==null ? null : dataSet_InvoicePostingPreReportQuery.Payercode)};
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
                public InvoicePostingPreReport MyParentReport
                {
                    get { return (InvoicePostingPreReport)ParentReport; }
                }
                
                public TTReportField BODYTEXT;
                public TTReportField HOSPITALNAME;
                public TTReportField INVOICEAMOUNT;
                public TTReportField TOTALINVOICEPRICE;
                public TTReportField BANKACCOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 32;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BODYTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 3, 175, 30, false);
                    BODYTEXT.Name = "BODYTEXT";
                    BODYTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT.TextFont.Name = "Arial Narrow";
                    BODYTEXT.TextFont.Size = 12;
                    BODYTEXT.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 7, 254, 12, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    INVOICEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 14, 254, 19, false);
                    INVOICEAMOUNT.Name = "INVOICEAMOUNT";
                    INVOICEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    INVOICEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEAMOUNT.Value = @"{#HEAD.INVOICEAMOUNT#}";

                    TOTALINVOICEPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 21, 254, 26, false);
                    TOTALINVOICEPRICE.Name = "TOTALINVOICEPRICE";
                    TOTALINVOICEPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALINVOICEPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINVOICEPRICE.TextFormat = @"Currency";
                    TOTALINVOICEPRICE.Value = @"{#HEAD.TOTALINVOICEPRICE#}";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 27, 254, 32, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.Visible = EvetHayirEnum.ehHayir;
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.CharSet = 1;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingPreReportQuery_Class dataset_InvoicePostingPreReportQuery = MyParentReport.HEAD.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPreReportQuery_Class>(0);
                    BODYTEXT.CalcValue = @"";
                    INVOICEAMOUNT.CalcValue = (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Invoiceamount) : "");
                    TOTALINVOICEPRICE.CalcValue = (dataset_InvoicePostingPreReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPreReportQuery.Totalinvoiceprice) : "");
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    return new TTReportObject[] { BODYTEXT,INVOICEAMOUNT,TOTALINVOICEPRICE,HOSPITALNAME,BANKACCOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string s = new string (' ',23);
            this.BODYTEXT.CalcValue = this.HOSPITALNAME.CalcValue + " XXXXXXnde tedavi edilen ("  + this.INVOICEAMOUNT.CalcValue +  ") adet kişiye ait masraf belgeleri ve tanzim edilen faturalar ilişiktedir. Toplam fatura bedeli olan " + this.TOTALINVOICEPRICE.FormattedValue + " 'sının Müdürlüğümüzün " + this.BANKACCOUNT.CalcValue + " no'lu hesabına gönderilmesi arz/rica olunur. " ;
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

        public InvoicePostingPreReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GuidID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICEPOSTINGPREREPORT";
            Caption = "Fatura Ön Yazı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 999;
            p_PageWidth = 0;
            p_PageHeight = 0;
            PreferredPrinter = "*";
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
            fd.TextFont.CharSet = 162;
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