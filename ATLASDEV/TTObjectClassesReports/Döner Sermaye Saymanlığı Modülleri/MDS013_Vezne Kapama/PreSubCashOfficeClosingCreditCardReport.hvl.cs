
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
    /// Yan Kasa kapanırken dökülen rapor
    /// </summary>
    public partial class PreSubCashOfficeClosingCreditCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public double? PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double17.2"].ConvertValue("0");
            public Currency? CASHOFFICECREDITCARDANNUAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public string CASHIERLOGGUID = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
            public Currency? SUBMITTEDTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? BALANCE = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? REMAININGTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? TREATMENTPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? CREDITCARDREVENUETOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? OTHERPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public string CASHIER = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
        }

        public partial class BOTTOMGroup : TTReportGroup
        {
            public PreSubCashOfficeClosingCreditCardReport MyParentReport
            {
                get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
            }

            new public BOTTOMGroupHeader Header()
            {
                return (BOTTOMGroupHeader)_header;
            }

            new public BOTTOMGroupFooter Footer()
            {
                return (BOTTOMGroupFooter)_footer;
            }

            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public BOTTOMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BOTTOMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new BOTTOMGroupHeader(this);
                _footer = new BOTTOMGroupFooter(this);

            }

            public partial class BOTTOMGroupHeader : TTReportSection
            {
                public PreSubCashOfficeClosingCreditCardReport MyParentReport
                {
                    get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
                }
                 
                public BOTTOMGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class BOTTOMGroupFooter : TTReportSection
            {
                public PreSubCashOfficeClosingCreditCardReport MyParentReport
                {
                    get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public BOTTOMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 24;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 123, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 210, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 55, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public BOTTOMGroup BOTTOM;

        public partial class HEADGroup : TTReportGroup
        {
            public PreSubCashOfficeClosingCreditCardReport MyParentReport
            {
                get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField CASHOFFICECREDITCARDANNUAL { get {return Header().CASHOFFICECREDITCARDANNUAL;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField CREDITCARDANNUAL { get {return Header().CREDITCARDANNUAL;} }
            public TTReportField PAGE { get {return Header().PAGE;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField CASHIERLOG { get {return Header().CASHIERLOG;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField REVENUETOTAL { get {return Footer().REVENUETOTAL;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField TOTALCASHOFFICECREDITCARDANNUAL { get {return Footer().TOTALCASHOFFICECREDITCARDANNUAL;} }
            public TTReportField NOTE { get {return Footer().NOTE;} }
            public TTReportField CASHIER { get {return Footer().CASHIER;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField MAINCASHIER { get {return Footer().MAINCASHIER;} }
            public TTReportField ACCOUNTANTNAME { get {return Footer().ACCOUNTANTNAME;} }
            public TTReportField MAINACASHIERNAME { get {return Footer().MAINACASHIERNAME;} }
            public TTReportField NewField11611 { get {return Footer().NewField11611;} }
            public TTReportField TREATMENTPRICEBACKTOTAL { get {return Footer().TREATMENTPRICEBACKTOTAL;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public PreSubCashOfficeClosingCreditCardReport MyParentReport
                {
                    get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportShape NewLine1;
                public TTReportField NewField3;
                public TTReportField CASHOFFICECREDITCARDANNUAL;
                public TTReportField OPENINGDATE;
                public TTReportField CASHOFFICE;
                public TTReportField NewField17;
                public TTReportField CREDITCARDANNUAL;
                public TTReportField PAGE;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField CASHIERLOG;
                public TTReportField NewField181;
                public TTReportField NewField1181;
                public TTReportField NewField1131; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 33, 75, 38, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BELGE NO";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 33, 180, 38, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"KREDİKARTI";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 20, 38, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 33, 101, 38, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BELGE TARİHİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 33, 210, 38, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AÇIKLAMA";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 33, 54, 38, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"ADI SOYADI";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 39, 210, 39, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 3, 177, 17, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"MUHASEBE YETKİLİSİ MUTEMEDİ ALINDISI BORÇ KISMI KASA DEFTERİ
(ÖNDÖKÜM)";

                    CASHOFFICECREDITCARDANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 9, 259, 14, false);
                    CASHOFFICECREDITCARDANNUAL.Name = "CASHOFFICECREDITCARDANNUAL";
                    CASHOFFICECREDITCARDANNUAL.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICECREDITCARDANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICECREDITCARDANNUAL.Value = @"{@CASHOFFICECREDITCARDANNUAL@}";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 19, 81, 24, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.Value = @"";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 25, 187, 30, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 41, 152, 46, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"NAKLİ YEKÜN";

                    CREDITCARDANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 41, 180, 46, false);
                    CREDITCARDANNUAL.Name = "CREDITCARDANNUAL";
                    CREDITCARDANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CREDITCARDANNUAL.TextFormat = @"#,##0.#0";
                    CREDITCARDANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CREDITCARDANNUAL.Value = @"";

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 5, 210, 10, false);
                    PAGE.Name = "PAGE";
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"{@pagenumber@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 5, 197, 10, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"Sayfa No :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 19, 51, 24, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"AÇILIŞ TARİHİ";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 51, 30, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"MUH.YETKİLİSİ MUTEMETLİĞİ";

                    CASHIERLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 2, 259, 7, false);
                    CASHIERLOG.Name = "CASHIERLOG";
                    CASHIERLOG.Visible = EvetHayirEnum.ehHayir;
                    CASHIERLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERLOG.Value = @"{@CASHIERLOGGUID@}";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 25, 54, 30, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 19, 54, 24, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 33, 157, 38, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 12;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"GELİR TÜRÜ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField3.CalcValue = NewField3.Value;
                    CASHOFFICECREDITCARDANNUAL.CalcValue = MyParentReport.RuntimeParameters.CASHOFFICECREDITCARDANNUAL.ToString();
                    OPENINGDATE.CalcValue = @"";
                    CASHOFFICE.CalcValue = @"";
                    NewField17.CalcValue = NewField17.Value;
                    CREDITCARDANNUAL.CalcValue = @"";
                    PAGE.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    CASHIERLOG.CalcValue = MyParentReport.RuntimeParameters.CASHIERLOGGUID.ToString();
                    NewField181.CalcValue = NewField181.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField11,NewField12,NewField13,NewField14,NewField3,CASHOFFICECREDITCARDANNUAL,OPENINGDATE,CASHOFFICE,NewField17,CREDITCARDANNUAL,PAGE,NewField5,NewField6,NewField7,CASHIERLOG,NewField181,NewField1181,NewField1131};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    string cashierLogObjID = this.CASHIERLOG.CalcValue.ToString();
            CashierLog myCashierLog = (CashierLog)((PreSubCashOfficeClosingCreditCardReport)ParentReport).ReportObjectContext.GetObject(new Guid(cashierLogObjID), "CashierLog");
            
            if (this.PAGE.CalcValue == "1")
                ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.PAGETOTAL = Convert.ToDouble(this.CASHOFFICECREDITCARDANNUAL.CalcValue);
            
            this.CREDITCARDANNUAL.CalcValue = ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
            TTUser ttUser = ((ResUser)myCashierLog.ResUser).GetMyTTUser();
            this.CASHOFFICE.CalcValue = myCashierLog.CashOffice.Qref + " " + myCashierLog.CashOffice.Name + " - " + ttUser.Name;
            
            string userType;
            if (myCashierLog.ResUser.UserType != null)
                userType = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(myCashierLog.ResUser.UserType.Value).DisplayText;
            else
                userType = "";
            
            string userTitle;
            if (myCashierLog.ResUser.Title != null)
                userTitle = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(myCashierLog.ResUser.Title.Value).DisplayText;
            else
                userTitle = "";
            
            ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.CASHIER = myCashierLog.ResUser.Name + "\n" + userType + "  (" + myCashierLog.ResUser.EmploymentRecordID + ")" + "\n" + userTitle;

            this.OPENINGDATE.CalcValue = myCashierLog.OpeningDate.ToString();
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public PreSubCashOfficeClosingCreditCardReport MyParentReport
                {
                    get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField REVENUETOTAL;
                public TTReportField NewField16;
                public TTReportField TOTALCASHOFFICECREDITCARDANNUAL;
                public TTReportField NOTE;
                public TTReportField CASHIER;
                public TTReportField ACCOUNTANT;
                public TTReportField MAINCASHIER;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField MAINACASHIERNAME;
                public TTReportField NewField11611;
                public TTReportField TREATMENTPRICEBACKTOTAL; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 74;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 8, 144, 13, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"GÜNLÜK TAHSİLAT";

                    REVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 8, 180, 13, false);
                    REVENUETOTAL.Name = "REVENUETOTAL";
                    REVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTAL.TextFormat = @"#,##0.#0";
                    REVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTAL.Value = @"{@CREDITCARDREVENUETOTAL@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 14, 137, 19, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"NAKLİ YEKÜN";

                    TOTALCASHOFFICECREDITCARDANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 14, 180, 19, false);
                    TOTALCASHOFFICECREDITCARDANNUAL.Name = "TOTALCASHOFFICECREDITCARDANNUAL";
                    TOTALCASHOFFICECREDITCARDANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCASHOFFICECREDITCARDANNUAL.TextFormat = @"#,##0.#0";
                    TOTALCASHOFFICECREDITCARDANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCASHOFFICECREDITCARDANNUAL.Value = @"";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 210, 40, false);
                    NOTE.Name = "NOTE";
                    NOTE.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE.NoClip = EvetHayirEnum.ehEvet;
                    NOTE.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOTE.Value = @"...................... numaradan .................... numaraya kadar olan muhasebe yetkilisi mutemedi alındılarıyla tahsil edilmiş toplam ................. Türk Lirası ................ tarihli ve .................... sayılı vezne alındısı karşılığında saymanlığa yatırılmıştır.";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 57, 52, 71, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 57, 132, 71, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"";

                    MAINCASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 56, 210, 71, false);
                    MAINCASHIER.Name = "MAINCASHIER";
                    MAINCASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINCASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    MAINCASHIER.NoClip = EvetHayirEnum.ehEvet;
                    MAINCASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAINCASHIER.Value = @"";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 57, 262, 62, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""ACCOUNTANT"", """")";

                    MAINACASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 62, 262, 67, false);
                    MAINACASHIERNAME.Name = "MAINACASHIERNAME";
                    MAINACASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    MAINACASHIERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    MAINACASHIERNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MAINCASHIERNAME"", """")";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 2, 151, 7, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.Visible = EvetHayirEnum.ehHayir;
                    NewField11611.Value = @"TEDAVİ BEDELİ İADESİ";

                    TREATMENTPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 2, 180, 7, false);
                    TREATMENTPRICEBACKTOTAL.Name = "TREATMENTPRICEBACKTOTAL";
                    TREATMENTPRICEBACKTOTAL.Visible = EvetHayirEnum.ehHayir;
                    TREATMENTPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTPRICEBACKTOTAL.TextFormat = @"#,##0.#0";
                    TREATMENTPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TREATMENTPRICEBACKTOTAL.Value = @"{@TREATMENTPRICEBACKTOTAL@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField15.CalcValue = NewField15.Value;
                    REVENUETOTAL.CalcValue = MyParentReport.RuntimeParameters.CREDITCARDREVENUETOTAL.ToString();
                    NewField16.CalcValue = NewField16.Value;
                    TOTALCASHOFFICECREDITCARDANNUAL.CalcValue = @"";
                    NOTE.CalcValue = NOTE.Value;
                    CASHIER.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    MAINCASHIER.CalcValue = @"";
                    NewField11611.CalcValue = NewField11611.Value;
                    TREATMENTPRICEBACKTOTAL.CalcValue = MyParentReport.RuntimeParameters.TREATMENTPRICEBACKTOTAL.ToString();
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "");
                    MAINACASHIERNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAINCASHIERNAME", "");
                    return new TTReportObject[] { NewField15,REVENUETOTAL,NewField16,TOTALCASHOFFICECREDITCARDANNUAL,NOTE,CASHIER,ACCOUNTANT,MAINCASHIER,NewField11611,TREATMENTPRICEBACKTOTAL,ACCOUNTANTNAME,MAINACASHIERNAME};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    // XXXXXX dan alınan raporda Nakli Yekünü ,  Tedavi İadelerinin etkilemediği görüldüğü için commetlendi
                    //            double treatmentBackTotal = 0 ;
                    //            if (this.TREATMENTPRICEBACKTOTAL.CalcValue != "")
                    //                treatmentBackTotal = Convert.ToDouble(this.TREATMENTPRICEBACKTOTAL.CalcValue);
                    //            this.TOTALCASHOFFICECREDITCARDANNUAL.CalcValue = (Convert.ToDouble(((SubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.PAGETOTAL) - treatmentBackTotal).ToString();

                    this.TOTALCASHOFFICECREDITCARDANNUAL.CalcValue = ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
                    this.ACCOUNTANT.CalcValue = this.ACCOUNTANTNAME.CalcValue + "\n" + "Saymanlık Müdürü";
                    this.MAINCASHIER.CalcValue = this.MAINACASHIERNAME.CalcValue + "\n" + "Vezne Memuru";
                    this.CASHIER.CalcValue = ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.CASHIER.ToString();
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class DETAILGroup : TTReportGroup
        {
            public PreSubCashOfficeClosingCreditCardReport MyParentReport
            {
                get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
            }

            new public DETAILGroupBody Body()
            {
                return (DETAILGroupBody)_body;
            }
            public TTReportField DOCUMENTNO { get {return Body().DOCUMENTNO;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField DOCUMENTDATE { get {return Body().DOCUMENTDATE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField ACCDOCOBJID { get {return Body().ACCDOCOBJID;} }
            public TTReportField REVENUETYPE { get {return Body().REVENUETYPE;} }
            public DETAILGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DETAILGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountDocument.GetAccDocsByCasLogAndCrdCard_Class>("GetAccDocsByCasLogAndCrdCard", AccountDocument.GetAccDocsByCasLogAndCrdCard((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.HEAD.CASHIERLOG.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DETAILGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DETAILGroupBody : TTReportSection
            {
                public PreSubCashOfficeClosingCreditCardReport MyParentReport
                {
                    get { return (PreSubCashOfficeClosingCreditCardReport)ParentReport; }
                }
                
                public TTReportField DOCUMENTNO;
                public TTReportField TOTALPRICE;
                public TTReportField DOCUMENTDATE;
                public TTReportField DESCRIPTION;
                public TTReportField SNO;
                public TTReportField PATIENTNAME;
                public TTReportField ACCDOCOBJID;
                public TTReportField REVENUETYPE; 
                public DETAILGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 75, 5, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 180, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 0, 101, 5, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"Short Date";
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 210, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 20, 5, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.Value = @"";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 54, 5, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.Value = @"{#PATIENTNAME#}";

                    ACCDOCOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 2, 251, 7, false);
                    ACCDOCOBJID.Name = "ACCDOCOBJID";
                    ACCDOCOBJID.Visible = EvetHayirEnum.ehHayir;
                    ACCDOCOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCDOCOBJID.Value = @"{#OBJECTID#}";

                    REVENUETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 0, 157, 5, false);
                    REVENUETYPE.Name = "REVENUETYPE";
                    REVENUETYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETYPE.MultiLine = EvetHayirEnum.ehEvet;
                    REVENUETYPE.NoClip = EvetHayirEnum.ehEvet;
                    REVENUETYPE.WordBreak = EvetHayirEnum.ehEvet;
                    REVENUETYPE.ExpandTabs = EvetHayirEnum.ehEvet;
                    REVENUETYPE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetAccDocsByCasLogAndCrdCard_Class dataset_GetAccDocsByCasLogAndCrdCard = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetAccDocsByCasLogAndCrdCard_Class>(0);
                    DOCUMENTNO.CalcValue = @"";
                    TOTALPRICE.CalcValue = (dataset_GetAccDocsByCasLogAndCrdCard != null ? Globals.ToStringCore(dataset_GetAccDocsByCasLogAndCrdCard.Totalprice) : "");
                    DOCUMENTDATE.CalcValue = (dataset_GetAccDocsByCasLogAndCrdCard != null ? Globals.ToStringCore(dataset_GetAccDocsByCasLogAndCrdCard.DocumentDate) : "");
                    DESCRIPTION.CalcValue = (dataset_GetAccDocsByCasLogAndCrdCard != null ? Globals.ToStringCore(dataset_GetAccDocsByCasLogAndCrdCard.Description) : "");
                    SNO.CalcValue = @"";
                    PATIENTNAME.CalcValue = (dataset_GetAccDocsByCasLogAndCrdCard != null ? Globals.ToStringCore(dataset_GetAccDocsByCasLogAndCrdCard.Patientname) : "");
                    ACCDOCOBJID.CalcValue = (dataset_GetAccDocsByCasLogAndCrdCard != null ? Globals.ToStringCore(dataset_GetAccDocsByCasLogAndCrdCard.ObjectID) : "");
                    REVENUETYPE.CalcValue = @"";
                    return new TTReportObject[] { DOCUMENTNO,TOTALPRICE,DOCUMENTDATE,DESCRIPTION,SNO,PATIENTNAME,ACCDOCOBJID,REVENUETYPE};
                }

                public override void RunScript()
                {
#region DETAIL BODY_Script
                    string sObjectID = this.ACCDOCOBJID.CalcValue.ToString();
            AccountDocument accDoc = ParentReport.ReportObjectContext.GetObject(new Guid(sObjectID), typeof(AccountDocument)) as AccountDocument;

            if (accDoc != null)
            {
                if (accDoc is ReceiptDocument)
                {
                    ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                    if (receiptDocument.CreditCardSpecialNo.Value.HasValue)
                        this.SNO.CalcValue = "POS-" + receiptDocument.CreditCardSpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "POS-";
                    
                    if (receiptDocument.CreditCardDocumentNo != null)
                        this.DOCUMENTNO.CalcValue = receiptDocument.CreditCardDocumentNo.ToString();
                    
                    if(receiptDocument.CurrentStateDefID == ReceiptDocument.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                    
                    // Gelir Türü set edilir
                    string revenueType = "";
                    
                    foreach(ReceiptProcedure ReceiptProc in ((Receipt)receiptDocument.EpisodeAccountAction).ReceiptProcedures)
                    {
                        if (ReceiptProc.Paid == true && ReceiptProc.RevenueType != null && ReceiptProc.RevenueType != "")
                        {
                            if (revenueType.Contains(ReceiptProc.RevenueType) == false)
                                revenueType = revenueType + ReceiptProc.RevenueType + ", ";
                        }
                    }
                    
                    if (revenueType != "")
                        revenueType = revenueType.Substring(0, (revenueType.Length - 2));
                    
                    this.REVENUETYPE.CalcValue = revenueType;
                }
                if (accDoc is AdvanceDocument)
                {
                    AdvanceDocument advanceDocument = (AdvanceDocument)accDoc;
                    if (advanceDocument.CreditCardSpecialNo.Value.HasValue)
                        this.SNO.CalcValue = "POS-" + advanceDocument.CreditCardSpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "POS-";

                    if (advanceDocument.CreditCardDocumentNo != null)
                        this.DOCUMENTNO.CalcValue = advanceDocument.CreditCardDocumentNo.ToString();
                    
                    if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                if (accDoc is DebenturePaymentDocument)
                {
                    DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                    if (debenturePaymentDocument.CreditCardSpecialNo.Value.HasValue)
                        this.SNO.CalcValue = "POS-" + debenturePaymentDocument.CreditCardSpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "POS-";

                    if (debenturePaymentDocument.CreditCardDocumentNo != null)
                        this.DOCUMENTNO.CalcValue = debenturePaymentDocument.CreditCardDocumentNo.ToString();
                    
                    if(debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                if(accDoc is SubCashOfficeReceiptDoc)
                {
                    SubCashOfficeReceiptDoc subCashOfficeReceiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                    if(subCashOfficeReceiptDoc.CreditCardSpecialNo.Value.HasValue)
                        this.SNO.CalcValue = "POS-" + subCashOfficeReceiptDoc.CreditCardSpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "POS-";
                    
                    if (subCashOfficeReceiptDoc.CreditCardDocumentNo != null)
                        this.DOCUMENTNO.CalcValue = subCashOfficeReceiptDoc.CreditCardDocumentNo.ToString();
                    
                    if(this.PATIENTNAME.CalcValue == " ")
                    {
                        this.PATIENTNAME.CalcValue = subCashOfficeReceiptDoc.PayeeName;
                        this.DESCRIPTION.CalcValue = subCashOfficeReceiptDoc.MoneyReceivedType.Name;
                    }
                    if(subCashOfficeReceiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                if(accDoc is GeneralReceiptDocument)
                {
                    GeneralReceiptDocument generalReceiptDocument  = (GeneralReceiptDocument)accDoc;
                    if(generalReceiptDocument.CreditCardSpecialNo.Value.HasValue)
                        this.SNO.CalcValue = "POS-" + generalReceiptDocument.CreditCardSpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "POS-";
                    
                    if (generalReceiptDocument.CreditCardDocumentNo != null)
                        this.DOCUMENTNO.CalcValue = generalReceiptDocument.CreditCardDocumentNo.ToString();
                    
                    if(this.PATIENTNAME.CalcValue == " ")
                    {
                        this.PATIENTNAME.CalcValue = generalReceiptDocument.PayeeName;
                        this.DESCRIPTION.CalcValue = generalReceiptDocument.GeneralReceipt[0].Description;
                    }
                    if(generalReceiptDocument.CurrentStateDefID == GeneralReceiptDocument.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
            }
            ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.PAGETOTAL = ((PreSubCashOfficeClosingCreditCardReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.TOTALPRICE.CalcValue);
#endregion DETAIL BODY_Script
                }
            }

        }

        public DETAILGroup DETAIL;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PreSubCashOfficeClosingCreditCardReport()
        {
            BOTTOM = new BOTTOMGroup(this,"BOTTOM");
            HEAD = new HEADGroup(BOTTOM,"HEAD");
            DETAIL = new DETAILGroup(HEAD,"DETAIL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PAGETOTAL", "0", "NAKLI YEKÜN", @"", false, false, false, new Guid("0ca2000a-f03c-42d1-8125-b33c48d68f02"));
            reportParameter = Parameters.Add("CASHOFFICECREDITCARDANNUAL", "", "CASHOFFICECREDITCARDANNUAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("CASHIERLOGGUID", "", "CASHIERLOGGUID", @"", false, false, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
            reportParameter = Parameters.Add("SUBMITTEDTOTAL", "", "SUBMITTEDTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("BALANCE", "", "BALANCE", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("REMAININGTOTAL", "", "REMAININGTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("TREATMENTPRICEBACKTOTAL", "", "TREATMENTPRICEBACKTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("CREDITCARDREVENUETOTAL", "", "CREDITCARDREVENUETOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("OTHERPRICEBACKTOTAL", "", "OTHERPRICEBACKTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("CASHIER", "", "CASHIER", @"", false, false, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PAGETOTAL"))
                _runtimeParameters.PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double17.2"].ConvertValue(parameters["PAGETOTAL"]);
            if (parameters.ContainsKey("CASHOFFICECREDITCARDANNUAL"))
                _runtimeParameters.CASHOFFICECREDITCARDANNUAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["CASHOFFICECREDITCARDANNUAL"]);
            if (parameters.ContainsKey("CASHIERLOGGUID"))
                _runtimeParameters.CASHIERLOGGUID = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["CASHIERLOGGUID"]);
            if (parameters.ContainsKey("SUBMITTEDTOTAL"))
                _runtimeParameters.SUBMITTEDTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["SUBMITTEDTOTAL"]);
            if (parameters.ContainsKey("BALANCE"))
                _runtimeParameters.BALANCE = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["BALANCE"]);
            if (parameters.ContainsKey("REMAININGTOTAL"))
                _runtimeParameters.REMAININGTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["REMAININGTOTAL"]);
            if (parameters.ContainsKey("TREATMENTPRICEBACKTOTAL"))
                _runtimeParameters.TREATMENTPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["TREATMENTPRICEBACKTOTAL"]);
            if (parameters.ContainsKey("CREDITCARDREVENUETOTAL"))
                _runtimeParameters.CREDITCARDREVENUETOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["CREDITCARDREVENUETOTAL"]);
            if (parameters.ContainsKey("OTHERPRICEBACKTOTAL"))
                _runtimeParameters.OTHERPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["OTHERPRICEBACKTOTAL"]);
            if (parameters.ContainsKey("CASHIER"))
                _runtimeParameters.CASHIER = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["CASHIER"]);
            Name = "PRESUBCASHOFFICECLOSINGCREDITCARDREPORT";
            Caption = "Muhasebe Yetkilisi Mutemetliği Kasa Kapama Raporu (Kredi Kartı Alındıları için Ön Döküm)";
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