
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
    /// Ana  Kasa Ön Döküm Raporu
    /// </summary>
    public partial class PreMainCashOfficeClosingReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Currency? PAGETOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("0");
            public Currency? CASHOFFICECASHANNUAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? TREATMENTPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? OTHERPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? SUBMITTEDTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? REMAININGTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public Currency? REVENUETOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue("");
            public string CASHIERLOGGUID = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
            public string CASHIER = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue("");
        }

        public partial class UPREPORTGroup : TTReportGroup
        {
            public PreMainCashOfficeClosingReport MyParentReport
            {
                get { return (PreMainCashOfficeClosingReport)ParentReport; }
            }

            new public UPREPORTGroupBody Body()
            {
                return (UPREPORTGroupBody)_body;
            }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField UPOPENINGDATE { get {return Body().UPOPENINGDATE;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField UPCASHANNUAL { get {return Body().UPCASHANNUAL;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField TREATMENTPRICEBACKTOTAL { get {return Body().TREATMENTPRICEBACKTOTAL;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField REVENUETOTALWITHOUTBACKDOCS { get {return Body().REVENUETOTALWITHOUTBACKDOCS;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField REMAININGTOTAL { get {return Body().REMAININGTOTAL;} }
            public TTReportField NewField1152 { get {return Body().NewField1152;} }
            public TTReportField UPREVENUETOTAL { get {return Body().UPREVENUETOTAL;} }
            public TTReportField NewField1162 { get {return Body().NewField1162;} }
            public TTReportField UPTOTALCASHOFFICECASHANNUAL { get {return Body().UPTOTALCASHOFFICECASHANNUAL;} }
            public TTReportField NewField1163 { get {return Body().NewField1163;} }
            public TTReportField OTHERPRICEBACKTOTAL { get {return Body().OTHERPRICEBACKTOTAL;} }
            public TTReportField UPCASHIERLOG { get {return Body().UPCASHIERLOG;} }
            public TTReportField LOGO1 { get {return Body().LOGO1;} }
            public UPREPORTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UPREPORTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new UPREPORTGroupBody(this);
            }

            public partial class UPREPORTGroupBody : TTReportSection
            {
                public PreMainCashOfficeClosingReport MyParentReport
                {
                    get { return (PreMainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField UPOPENINGDATE;
                public TTReportField NewField16;
                public TTReportField NewField151;
                public TTReportField UPCASHANNUAL;
                public TTReportField NewField161;
                public TTReportField TREATMENTPRICEBACKTOTAL;
                public TTReportField NewField1151;
                public TTReportField REVENUETOTALWITHOUTBACKDOCS;
                public TTReportField NewField1161;
                public TTReportField REMAININGTOTAL;
                public TTReportField NewField1152;
                public TTReportField UPREVENUETOTAL;
                public TTReportField NewField1162;
                public TTReportField UPTOTALCASHOFFICECASHANNUAL;
                public TTReportField NewField1163;
                public TTReportField OTHERPRICEBACKTOTAL;
                public TTReportField UPCASHIERLOG;
                public TTReportField LOGO1; 
                public UPREPORTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 78;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 156, 21, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Size = 14;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"VEZNE ALINDISI ALACAK KISMI KASA DEFTERİ
(ÖNDÖKÜM)";

                    UPOPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 24, 67, 29, false);
                    UPOPENINGDATE.Name = "UPOPENINGDATE";
                    UPOPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPOPENINGDATE.TextFormat = @"Short Date";
                    UPOPENINGDATE.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 24, 40, 29, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"AÇILIŞ TARİHİ  :";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 34, 56, 39, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"NAKLİ YEKÜN";

                    UPCASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 34, 112, 39, false);
                    UPCASHANNUAL.Name = "UPCASHANNUAL";
                    UPCASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPCASHANNUAL.TextFormat = @"Currency";
                    UPCASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UPCASHANNUAL.Value = @"{@CASHOFFICECASHANNUAL@}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 40, 56, 45, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @"TEDAVİ BEDELİ İADESİ";

                    TREATMENTPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 40, 112, 45, false);
                    TREATMENTPRICEBACKTOTAL.Name = "TREATMENTPRICEBACKTOTAL";
                    TREATMENTPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTPRICEBACKTOTAL.TextFormat = @"Currency";
                    TREATMENTPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TREATMENTPRICEBACKTOTAL.Value = @"{@TREATMENTPRICEBACKTOTAL@}";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 52, 56, 57, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.Value = @"TESLİMAT MÜZEKKERESİ";

                    REVENUETOTALWITHOUTBACKDOCS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 52, 112, 57, false);
                    REVENUETOTALWITHOUTBACKDOCS.Name = "REVENUETOTALWITHOUTBACKDOCS";
                    REVENUETOTALWITHOUTBACKDOCS.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTALWITHOUTBACKDOCS.TextFormat = @"Currency";
                    REVENUETOTALWITHOUTBACKDOCS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTALWITHOUTBACKDOCS.Value = @"{@SUBMITTEDTOTAL@}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 58, 56, 63, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"KASADA KALAN";

                    REMAININGTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 58, 112, 63, false);
                    REMAININGTOTAL.Name = "REMAININGTOTAL";
                    REMAININGTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REMAININGTOTAL.TextFormat = @"Currency";
                    REMAININGTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REMAININGTOTAL.Value = @"{@REMAININGTOTAL@}";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 64, 56, 69, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.Value = @"GÜNLÜK TAHSİLAT";

                    UPREVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 64, 112, 69, false);
                    UPREVENUETOTAL.Name = "UPREVENUETOTAL";
                    UPREVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPREVENUETOTAL.TextFormat = @"Currency";
                    UPREVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UPREVENUETOTAL.Value = @"{@REVENUETOTAL@}";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 70, 56, 75, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.Value = @"NAKLİ YEKÜN";

                    UPTOTALCASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 70, 112, 75, false);
                    UPTOTALCASHOFFICECASHANNUAL.Name = "UPTOTALCASHOFFICECASHANNUAL";
                    UPTOTALCASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPTOTALCASHOFFICECASHANNUAL.TextFormat = @"Currency";
                    UPTOTALCASHOFFICECASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UPTOTALCASHOFFICECASHANNUAL.Value = @"";

                    NewField1163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 46, 56, 51, false);
                    NewField1163.Name = "NewField1163";
                    NewField1163.Value = @"DİĞER İADELER";

                    OTHERPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 46, 112, 51, false);
                    OTHERPRICEBACKTOTAL.Name = "OTHERPRICEBACKTOTAL";
                    OTHERPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTHERPRICEBACKTOTAL.TextFormat = @"Currency";
                    OTHERPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OTHERPRICEBACKTOTAL.Value = @"{@OTHERPRICEBACKTOTAL@}";

                    UPCASHIERLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 23, 252, 28, false);
                    UPCASHIERLOG.Name = "UPCASHIERLOG";
                    UPCASHIERLOG.Visible = EvetHayirEnum.ehHayir;
                    UPCASHIERLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPCASHIERLOG.Value = @"{@CASHIERLOGGUID@}";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 57, 21, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13.CalcValue = NewField13.Value;
                    UPOPENINGDATE.CalcValue = @"";
                    NewField16.CalcValue = NewField16.Value;
                    NewField151.CalcValue = NewField151.Value;
                    UPCASHANNUAL.CalcValue = MyParentReport.RuntimeParameters.CASHOFFICECASHANNUAL.ToString();
                    NewField161.CalcValue = NewField161.Value;
                    TREATMENTPRICEBACKTOTAL.CalcValue = MyParentReport.RuntimeParameters.TREATMENTPRICEBACKTOTAL.ToString();
                    NewField1151.CalcValue = NewField1151.Value;
                    REVENUETOTALWITHOUTBACKDOCS.CalcValue = MyParentReport.RuntimeParameters.SUBMITTEDTOTAL.ToString();
                    NewField1161.CalcValue = NewField1161.Value;
                    REMAININGTOTAL.CalcValue = MyParentReport.RuntimeParameters.REMAININGTOTAL.ToString();
                    NewField1152.CalcValue = NewField1152.Value;
                    UPREVENUETOTAL.CalcValue = MyParentReport.RuntimeParameters.REVENUETOTAL.ToString();
                    NewField1162.CalcValue = NewField1162.Value;
                    UPTOTALCASHOFFICECASHANNUAL.CalcValue = @"";
                    NewField1163.CalcValue = NewField1163.Value;
                    OTHERPRICEBACKTOTAL.CalcValue = MyParentReport.RuntimeParameters.OTHERPRICEBACKTOTAL.ToString();
                    UPCASHIERLOG.CalcValue = MyParentReport.RuntimeParameters.CASHIERLOGGUID.ToString();
                    LOGO1.CalcValue = LOGO1.Value;
                    return new TTReportObject[] { NewField13,UPOPENINGDATE,NewField16,NewField151,UPCASHANNUAL,NewField161,TREATMENTPRICEBACKTOTAL,NewField1151,REVENUETOTALWITHOUTBACKDOCS,NewField1161,REMAININGTOTAL,NewField1152,UPREVENUETOTAL,NewField1162,UPTOTALCASHOFFICECASHANNUAL,NewField1163,OTHERPRICEBACKTOTAL,UPCASHIERLOG,LOGO1};
                }

                public override void RunScript()
                {
#region UPREPORT BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string cashierLogObjID = this.UPCASHIERLOG.CalcValue.ToString();
            CashierLog myCashierLog = (CashierLog)context.GetObject(new Guid(cashierLogObjID),"CashierLog");
            
            this.UPTOTALCASHOFFICECASHANNUAL.CalcValue = (Convert.ToDouble(this.UPCASHANNUAL.CalcValue) + Convert.ToDouble(this.UPREVENUETOTAL.CalcValue)).ToString() ;
            this.UPOPENINGDATE.CalcValue = myCashierLog.OpeningDate.ToString();
#endregion UPREPORT BODY_Script
                }
            }

        }

        public UPREPORTGroup UPREPORT;

        public partial class BOTTOMGroup : TTReportGroup
        {
            public PreMainCashOfficeClosingReport MyParentReport
            {
                get { return (PreMainCashOfficeClosingReport)ParentReport; }
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
                public PreMainCashOfficeClosingReport MyParentReport
                {
                    get { return (PreMainCashOfficeClosingReport)ParentReport; }
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
                public PreMainCashOfficeClosingReport MyParentReport
                {
                    get { return (PreMainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public BOTTOMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 23;
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 1, 196, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 64, 6, false);
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
            public PreMainCashOfficeClosingReport MyParentReport
            {
                get { return (PreMainCashOfficeClosingReport)ParentReport; }
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
            public TTReportField NewField137 { get {return Header().NewField137;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField CASHOFFICECASHANNUAL { get {return Header().CASHOFFICECASHANNUAL;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField CASHANNUAL { get {return Header().CASHANNUAL;} }
            public TTReportField PAGE { get {return Header().PAGE;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField CASHIERLOG { get {return Header().CASHIERLOG;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField REVENUETOTAL { get {return Footer().REVENUETOTAL;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField TOTALCASHOFFICECASHANNUAL { get {return Footer().TOTALCASHOFFICECASHANNUAL;} }
            public TTReportField NOTE { get {return Footer().NOTE;} }
            public TTReportField CASHIER { get {return Footer().CASHIER;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField ACCOUNTANTNAME { get {return Footer().ACCOUNTANTNAME;} }
            public TTReportField MAINACASHIERNAME { get {return Footer().MAINACASHIERNAME;} }
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
                public PreMainCashOfficeClosingReport MyParentReport
                {
                    get { return (PreMainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField137;
                public TTReportField NewField14;
                public TTReportShape NewLine1;
                public TTReportField NewField3;
                public TTReportField CASHOFFICECASHANNUAL;
                public TTReportField OPENINGDATE;
                public TTReportField CASHOFFICE;
                public TTReportField NewField17;
                public TTReportField CASHANNUAL;
                public TTReportField PAGE;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField CASHIERLOG; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 45;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 31, 52, 36, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"VEZ.ALIN.NO";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 31, 196, 36, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"NAKİT";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 31, 27, 36, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 31, 70, 36, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"TARİH";

                    NewField137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 31, 170, 36, false);
                    NewField137.Name = "NewField137";
                    NewField137.TextFont.Size = 12;
                    NewField137.TextFont.Bold = true;
                    NewField137.TextFont.CharSet = 162;
                    NewField137.Value = @"TAHSİLAT TÜRÜ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 31, 126, 36, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"AÇIKLAMA";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 37, 196, 37, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 164, 15, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"VEZNE ALINDI MUHASEBE LİSTESİ KASA DEFTERİ
(ÖNDÖKÜM)";

                    CASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 5, 260, 10, false);
                    CASHOFFICECASHANNUAL.Name = "CASHOFFICECASHANNUAL";
                    CASHOFFICECASHANNUAL.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICECASHANNUAL.Value = @"{@CASHOFFICECASHANNUAL@}";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 17, 64, 22, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.Value = @"";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 23, 167, 28, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 39, 147, 44, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"NAKLİ YEKÜN";

                    CASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 39, 196, 44, false);
                    CASHANNUAL.Name = "CASHANNUAL";
                    CASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHANNUAL.TextFormat = @"Currency";
                    CASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CASHANNUAL.Value = @"";

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 5, 196, 10, false);
                    PAGE.Name = "PAGE";
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"{@pagenumber@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 5, 183, 10, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"Sayfa No :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 17, 40, 22, false);
                    NewField6.Name = "NewField6";
                    NewField6.Value = @"AÇILIŞ TARİHİ  :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 23, 40, 28, false);
                    NewField7.Name = "NewField7";
                    NewField7.Value = @"VEZNE               :";

                    CASHIERLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 14, 250, 19, false);
                    CASHIERLOG.Name = "CASHIERLOG";
                    CASHIERLOG.Visible = EvetHayirEnum.ehHayir;
                    CASHIERLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERLOG.Value = @"{@CASHIERLOGGUID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField137.CalcValue = NewField137.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField3.CalcValue = NewField3.Value;
                    CASHOFFICECASHANNUAL.CalcValue = MyParentReport.RuntimeParameters.CASHOFFICECASHANNUAL.ToString();
                    OPENINGDATE.CalcValue = @"";
                    CASHOFFICE.CalcValue = @"";
                    NewField17.CalcValue = NewField17.Value;
                    CASHANNUAL.CalcValue = @"";
                    PAGE.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    CASHIERLOG.CalcValue = MyParentReport.RuntimeParameters.CASHIERLOGGUID.ToString();
                    return new TTReportObject[] { NewField1,NewField2,NewField11,NewField12,NewField137,NewField14,NewField3,CASHOFFICECASHANNUAL,OPENINGDATE,CASHOFFICE,NewField17,CASHANNUAL,PAGE,NewField5,NewField6,NewField7,CASHIERLOG};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string cashierLogObjID = this.CASHIERLOG.CalcValue.ToString();
            CashierLog myCashierLog = (CashierLog)context.GetObject(new Guid(cashierLogObjID),"CashierLog");
            
            if (this.PAGE.CalcValue == "1")
                ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL = Convert.ToDouble(this.CASHOFFICECASHANNUAL.CalcValue);
            
            this.CASHANNUAL.CalcValue = ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
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
            
            
            ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.CASHIER = myCashierLog.ResUser.Name + "\n" + userType + "  (" + myCashierLog.ResUser.EmploymentRecordID + ")" + "\n" + userTitle + "\n" + "....../....../.........." ;
            
            this.OPENINGDATE.CalcValue = myCashierLog.OpeningDate.ToString();
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public PreMainCashOfficeClosingReport MyParentReport
                {
                    get { return (PreMainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField REVENUETOTAL;
                public TTReportField NewField16;
                public TTReportField TOTALCASHOFFICECASHANNUAL;
                public TTReportField NOTE;
                public TTReportField CASHIER;
                public TTReportField ACCOUNTANT;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField MAINACASHIERNAME; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 70;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 4, 133, 9, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"GÜNLÜK TAHSİLAT";

                    REVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 4, 196, 9, false);
                    REVENUETOTAL.Name = "REVENUETOTAL";
                    REVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTAL.TextFormat = @"Currency";
                    REVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTAL.Value = @"{@REVENUETOTAL@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 10, 126, 15, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"NAKLİ YEKÜN";

                    TOTALCASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 10, 196, 15, false);
                    TOTALCASHOFFICECASHANNUAL.Name = "TOTALCASHOFFICECASHANNUAL";
                    TOTALCASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCASHOFFICECASHANNUAL.TextFormat = @"Currency";
                    TOTALCASHOFFICECASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCASHOFFICECASHANNUAL.Value = @"";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 19, 196, 36, false);
                    NOTE.Name = "NOTE";
                    NOTE.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE.NoClip = EvetHayirEnum.ehEvet;
                    NOTE.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOTE.Value = @".................................numaradan ................................. numaraya kadar olan alındılarla tahsil edilmiş toplam .......................................... Türk Lirası ..............................tarihli ve ..............................sayılı teslimat müzekkeresi ile bankaya yatırılmıştır.";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 53, 64, 67, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 53, 132, 67, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"Muhasebe Yetkilisi
....../....../..........";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 57, 262, 62, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""CIRCCAPITALDIRECTORNAME"", """")";

                    MAINACASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 62, 262, 67, false);
                    MAINACASHIERNAME.Name = "MAINACASHIERNAME";
                    MAINACASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    MAINACASHIERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    MAINACASHIERNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MAINCASHIERNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField15.CalcValue = NewField15.Value;
                    REVENUETOTAL.CalcValue = MyParentReport.RuntimeParameters.REVENUETOTAL.ToString();
                    NewField16.CalcValue = NewField16.Value;
                    TOTALCASHOFFICECASHANNUAL.CalcValue = @"";
                    NOTE.CalcValue = NOTE.Value;
                    CASHIER.CalcValue = @"";
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("CIRCCAPITALDIRECTORNAME", "");
                    MAINACASHIERNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAINCASHIERNAME", "");
                    return new TTReportObject[] { NewField15,REVENUETOTAL,NewField16,TOTALCASHOFFICECASHANNUAL,NOTE,CASHIER,ACCOUNTANT,ACCOUNTANTNAME,MAINACASHIERNAME};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    this.TOTALCASHOFFICECASHANNUAL.CalcValue = ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
            this.CASHIER.CalcValue = ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.CASHIER.ToString();
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class DETAILGroup : TTReportGroup
        {
            public PreMainCashOfficeClosingReport MyParentReport
            {
                get { return (PreMainCashOfficeClosingReport)ParentReport; }
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
            public TTReportField MONEYRECEIVEDTYPE { get {return Body().MONEYRECEIVEDTYPE;} }
            public TTReportField ACCDOCOBJID { get {return Body().ACCDOCOBJID;} }
            public TTReportField DESC { get {return Body().DESC;} }
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
                list[0] = new TTReportNqlData<AccountDocument.GetMainCashOfficeDocsByCasLog_Class>("GetMainCashOfficeDocsByCasLog", AccountDocument.GetMainCashOfficeDocsByCasLog((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.HEAD.CASHIERLOG.CalcValue)));
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
                public PreMainCashOfficeClosingReport MyParentReport
                {
                    get { return (PreMainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField DOCUMENTNO;
                public TTReportField TOTALPRICE;
                public TTReportField DOCUMENTDATE;
                public TTReportField DESCRIPTION;
                public TTReportField SNO;
                public TTReportField MONEYRECEIVEDTYPE;
                public TTReportField ACCDOCOBJID;
                public TTReportField DESC; 
                public DETAILGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 52, 5, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 196, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 70, 5, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"Short Date";
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 126, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.Value = @"";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 27, 5, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.Value = @"";

                    MONEYRECEIVEDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 170, 5, false);
                    MONEYRECEIVEDTYPE.Name = "MONEYRECEIVEDTYPE";
                    MONEYRECEIVEDTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONEYRECEIVEDTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPE.NoClip = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPE.ExpandTabs = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPE.Value = @"";

                    ACCDOCOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 2, 251, 7, false);
                    ACCDOCOBJID.Name = "ACCDOCOBJID";
                    ACCDOCOBJID.Visible = EvetHayirEnum.ehHayir;
                    ACCDOCOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCDOCOBJID.Value = @"{#OBJECTID#}";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 211, 5, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetMainCashOfficeDocsByCasLog_Class dataset_GetMainCashOfficeDocsByCasLog = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetMainCashOfficeDocsByCasLog_Class>(0);
                    DOCUMENTNO.CalcValue = (dataset_GetMainCashOfficeDocsByCasLog != null ? Globals.ToStringCore(dataset_GetMainCashOfficeDocsByCasLog.DocumentNo) : "");
                    TOTALPRICE.CalcValue = (dataset_GetMainCashOfficeDocsByCasLog != null ? Globals.ToStringCore(dataset_GetMainCashOfficeDocsByCasLog.Totalprice) : "");
                    DOCUMENTDATE.CalcValue = (dataset_GetMainCashOfficeDocsByCasLog != null ? Globals.ToStringCore(dataset_GetMainCashOfficeDocsByCasLog.DocumentDate) : "");
                    DESCRIPTION.CalcValue = @"";
                    SNO.CalcValue = @"";
                    MONEYRECEIVEDTYPE.CalcValue = @"";
                    ACCDOCOBJID.CalcValue = (dataset_GetMainCashOfficeDocsByCasLog != null ? Globals.ToStringCore(dataset_GetMainCashOfficeDocsByCasLog.ObjectID) : "");
                    DESC.CalcValue = @"";
                    return new TTReportObject[] { DOCUMENTNO,TOTALPRICE,DOCUMENTDATE,DESCRIPTION,SNO,MONEYRECEIVEDTYPE,ACCDOCOBJID,DESC};
                }

                public override void RunScript()
                {
#region DETAIL BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.ACCDOCOBJID.CalcValue.ToString();
            AccountDocument accDoc = (AccountDocument)context.GetObject(new Guid(sObjectID),"AccountDocument");
            
            if(accDoc != null)
            {
                if(accDoc is CashOfficeReceiptDocument)
                {
                    CashOfficeReceiptDocument cashOfficeReceiptDocument = (CashOfficeReceiptDocument)accDoc;
                    this.SNO.CalcValue = cashOfficeReceiptDocument.SpecialNo.ToString();
                    if(cashOfficeReceiptDocument.PayeeName != null)
                        this.DESCRIPTION.CalcValue = cashOfficeReceiptDocument.PayeeName.ToString();
                    else
                        this.DESCRIPTION.CalcValue = cashOfficeReceiptDocument.MainCashOfficeOperation[0].Description.ToString();
                    
                    this.MONEYRECEIVEDTYPE.CalcValue = cashOfficeReceiptDocument.MoneyReceivedType.Name;
                    
                    if(cashOfficeReceiptDocument.CurrentStateDefID == CashOfficeReceiptDocument.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESC.CalcValue = "(İPTAL)";
                    }
                    else
                        ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL = ((PreMainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.TOTALPRICE.CalcValue);
                }
            }
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

        public PreMainCashOfficeClosingReport()
        {
            UPREPORT = new UPREPORTGroup(this,"UPREPORT");
            BOTTOM = new BOTTOMGroup(this,"BOTTOM");
            HEAD = new HEADGroup(BOTTOM,"HEAD");
            DETAIL = new DETAILGroup(HEAD,"DETAIL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PAGETOTAL", "0", "NAKLI YEKÜN", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("CASHOFFICECASHANNUAL", "", "CASHOFFICECASHANNUAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("TREATMENTPRICEBACKTOTAL", "", "TREATMENTPRICEBACKTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("OTHERPRICEBACKTOTAL", "", "OTHERPRICEBACKTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("SUBMITTEDTOTAL", "", "SUBMITTEDTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("REMAININGTOTAL", "", "REMAININGTOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("REVENUETOTAL", "", "REVENUETOTAL", @"", false, false, false, new Guid("edaf19ac-146a-4114-aec9-1f8f5c3c7396"));
            reportParameter = Parameters.Add("CASHIERLOGGUID", "", "CASHIERLOGGUID", @"", false, false, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
            reportParameter = Parameters.Add("CASHIER", "", "CASHIER", @"", false, false, false, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PAGETOTAL"))
                _runtimeParameters.PAGETOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["PAGETOTAL"]);
            if (parameters.ContainsKey("CASHOFFICECASHANNUAL"))
                _runtimeParameters.CASHOFFICECASHANNUAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["CASHOFFICECASHANNUAL"]);
            if (parameters.ContainsKey("TREATMENTPRICEBACKTOTAL"))
                _runtimeParameters.TREATMENTPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["TREATMENTPRICEBACKTOTAL"]);
            if (parameters.ContainsKey("OTHERPRICEBACKTOTAL"))
                _runtimeParameters.OTHERPRICEBACKTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["OTHERPRICEBACKTOTAL"]);
            if (parameters.ContainsKey("SUBMITTEDTOTAL"))
                _runtimeParameters.SUBMITTEDTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["SUBMITTEDTOTAL"]);
            if (parameters.ContainsKey("REMAININGTOTAL"))
                _runtimeParameters.REMAININGTOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["REMAININGTOTAL"]);
            if (parameters.ContainsKey("REVENUETOTAL"))
                _runtimeParameters.REVENUETOTAL = (Currency?)TTObjectDefManager.Instance.DataTypes["Money"].ConvertValue(parameters["REVENUETOTAL"]);
            if (parameters.ContainsKey("CASHIERLOGGUID"))
                _runtimeParameters.CASHIERLOGGUID = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["CASHIERLOGGUID"]);
            if (parameters.ContainsKey("CASHIER"))
                _runtimeParameters.CASHIER = (string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(parameters["CASHIER"]);
            Name = "PREMAINCASHOFFICECLOSINGREPORT";
            Caption = "Vezne Kasa Kapama Raporu(Ön Döküm)";
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