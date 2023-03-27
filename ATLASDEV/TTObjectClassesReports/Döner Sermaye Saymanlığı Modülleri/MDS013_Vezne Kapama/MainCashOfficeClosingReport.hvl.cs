
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
    /// Ana  Kasa kapanırken dökülen rapor
    /// </summary>
    public partial class MainCashOfficeClosingReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public double? PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double17.2"].ConvertValue("0");
        }

        public partial class UPREPORTGroup : TTReportGroup
        {
            public MainCashOfficeClosingReport MyParentReport
            {
                get { return (MainCashOfficeClosingReport)ParentReport; }
            }

            new public UPREPORTGroupBody Body()
            {
                return (UPREPORTGroupBody)_body;
            }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField UPOPENINGDATE { get {return Body().UPOPENINGDATE;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField UPCLOSINGDATE { get {return Body().UPCLOSINGDATE;} }
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
            public TTReportField LOGO { get {return Body().LOGO;} }
            public UPREPORTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UPREPORTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>("CashOfficeClosingCashReportQuery", CashOfficeClosing.CashOfficeClosingCashReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new UPREPORTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class UPREPORTGroupBody : TTReportSection
            {
                public MainCashOfficeClosingReport MyParentReport
                {
                    get { return (MainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField UPOPENINGDATE;
                public TTReportField NewField14;
                public TTReportField UPCLOSINGDATE;
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
                public TTReportField LOGO; 
                public UPREPORTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 78;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 2, 159, 22, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 14;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"VEZNE ALINDISI BORÇ KISMI KASA DEFTERİ";

                    UPOPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 26, 49, 31, false);
                    UPOPENINGDATE.Name = "UPOPENINGDATE";
                    UPOPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPOPENINGDATE.TextFormat = @"Short Date";
                    UPOPENINGDATE.Value = @"{#OPENINGDATE#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 26, 55, 31, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.Value = @"-";

                    UPCLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 26, 80, 31, false);
                    UPCLOSINGDATE.Name = "UPCLOSINGDATE";
                    UPCLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPCLOSINGDATE.TextFormat = @"Short Date";
                    UPCLOSINGDATE.Value = @"{#CLOSINGDATE#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 26, 30, 31, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"TARİH  :";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 36, 56, 41, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"NAKLİ YEKÜN";

                    UPCASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 36, 112, 41, false);
                    UPCASHANNUAL.Name = "UPCASHANNUAL";
                    UPCASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPCASHANNUAL.TextFormat = @"Currency";
                    UPCASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UPCASHANNUAL.Value = @"{#CASHOFFICECASHANNUAL#}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 42, 56, 47, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @"TEDAVİ BEDELİ İADESİ";

                    TREATMENTPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 42, 112, 47, false);
                    TREATMENTPRICEBACKTOTAL.Name = "TREATMENTPRICEBACKTOTAL";
                    TREATMENTPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTPRICEBACKTOTAL.TextFormat = @"Currency";
                    TREATMENTPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TREATMENTPRICEBACKTOTAL.Value = @"{#TREATMENTPRICEBACKTOTAL#}";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 54, 56, 59, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.Value = @"TESLİMAT MÜZEKKERESİ";

                    REVENUETOTALWITHOUTBACKDOCS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 54, 112, 59, false);
                    REVENUETOTALWITHOUTBACKDOCS.Name = "REVENUETOTALWITHOUTBACKDOCS";
                    REVENUETOTALWITHOUTBACKDOCS.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTALWITHOUTBACKDOCS.TextFormat = @"Currency";
                    REVENUETOTALWITHOUTBACKDOCS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTALWITHOUTBACKDOCS.Value = @"{#SUBMITTEDTOTAL#}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 60, 56, 65, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"KASADA KALAN";

                    REMAININGTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 60, 112, 65, false);
                    REMAININGTOTAL.Name = "REMAININGTOTAL";
                    REMAININGTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REMAININGTOTAL.TextFormat = @"Currency";
                    REMAININGTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REMAININGTOTAL.Value = @"{#REMAININGTOTAL#}";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 66, 56, 71, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.Value = @"GÜNLÜK TAHSİLAT";

                    UPREVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 66, 112, 71, false);
                    UPREVENUETOTAL.Name = "UPREVENUETOTAL";
                    UPREVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPREVENUETOTAL.TextFormat = @"Currency";
                    UPREVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UPREVENUETOTAL.Value = @"{#REVENUETOTAL#}";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 72, 56, 77, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.Value = @"NAKLİ YEKÜN";

                    UPTOTALCASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 72, 112, 77, false);
                    UPTOTALCASHOFFICECASHANNUAL.Name = "UPTOTALCASHOFFICECASHANNUAL";
                    UPTOTALCASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UPTOTALCASHOFFICECASHANNUAL.TextFormat = @"Currency";
                    UPTOTALCASHOFFICECASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UPTOTALCASHOFFICECASHANNUAL.Value = @"";

                    NewField1163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 48, 56, 53, false);
                    NewField1163.Name = "NewField1163";
                    NewField1163.Value = @"DİĞER İADELER";

                    OTHERPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 48, 112, 53, false);
                    OTHERPRICEBACKTOTAL.Name = "OTHERPRICEBACKTOTAL";
                    OTHERPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTHERPRICEBACKTOTAL.TextFormat = @"Currency";
                    OTHERPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OTHERPRICEBACKTOTAL.Value = @"{#OTHERPRICEBACKTOTAL#}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 54, 22, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CashOfficeClosing.CashOfficeClosingCashReportQuery_Class dataset_CashOfficeClosingCashReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(0);
                    NewField13.CalcValue = NewField13.Value;
                    UPOPENINGDATE.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.OpeningDate) : "");
                    NewField14.CalcValue = NewField14.Value;
                    UPCLOSINGDATE.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.ClosingDate) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField151.CalcValue = NewField151.Value;
                    UPCASHANNUAL.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.CashOfficeCashAnnual) : "");
                    NewField161.CalcValue = NewField161.Value;
                    TREATMENTPRICEBACKTOTAL.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.TreatmentPriceBackTotal) : "");
                    NewField1151.CalcValue = NewField1151.Value;
                    REVENUETOTALWITHOUTBACKDOCS.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.SubmittedTotal) : "");
                    NewField1161.CalcValue = NewField1161.Value;
                    REMAININGTOTAL.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.RemainingTotal) : "");
                    NewField1152.CalcValue = NewField1152.Value;
                    UPREVENUETOTAL.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.RevenueTotal) : "");
                    NewField1162.CalcValue = NewField1162.Value;
                    UPTOTALCASHOFFICECASHANNUAL.CalcValue = @"";
                    NewField1163.CalcValue = NewField1163.Value;
                    OTHERPRICEBACKTOTAL.CalcValue = (dataset_CashOfficeClosingCashReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingCashReportQuery.OtherPriceBackTotal) : "");
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField13,UPOPENINGDATE,NewField14,UPCLOSINGDATE,NewField16,NewField151,UPCASHANNUAL,NewField161,TREATMENTPRICEBACKTOTAL,NewField1151,REVENUETOTALWITHOUTBACKDOCS,NewField1161,REMAININGTOTAL,NewField1152,UPREVENUETOTAL,NewField1162,UPTOTALCASHOFFICECASHANNUAL,NewField1163,OTHERPRICEBACKTOTAL,LOGO};
                }

                public override void RunScript()
                {
#region UPREPORT BODY_Script
                    this.UPTOTALCASHOFFICECASHANNUAL.CalcValue = (Convert.ToDouble(this.UPCASHANNUAL.CalcValue) + Convert.ToDouble(this.UPREVENUETOTAL.CalcValue)).ToString() ;
            //this.REVENUETOTALWITHOUTBACKDOCS.CalcValue = (Convert.ToDouble(this.UPREVENUETOTAL.CalcValue) - Convert.ToDouble(this.TREATMENTPRICEBACKTOTAL.CalcValue) - Convert.ToDouble(this.OTHERPRICEBACKTOTAL.CalcValue)).ToString();
#endregion UPREPORT BODY_Script
                }
            }

        }

        public UPREPORTGroup UPREPORT;

        public partial class BOTTOMGroup : TTReportGroup
        {
            public MainCashOfficeClosingReport MyParentReport
            {
                get { return (MainCashOfficeClosingReport)ParentReport; }
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
                public MainCashOfficeClosingReport MyParentReport
                {
                    get { return (MainCashOfficeClosingReport)ParentReport; }
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
                public MainCashOfficeClosingReport MyParentReport
                {
                    get { return (MainCashOfficeClosingReport)ParentReport; }
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 183, 6, false);
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
            public MainCashOfficeClosingReport MyParentReport
            {
                get { return (MainCashOfficeClosingReport)ParentReport; }
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
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField CLOSINGDATE { get {return Header().CLOSINGDATE;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField CASHANNUAL { get {return Header().CASHANNUAL;} }
            public TTReportField PAGE { get {return Header().PAGE;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField CASHIERLOG { get {return Header().CASHIERLOG;} }
            public TTReportField CASHOFFICEQREF { get {return Header().CASHOFFICEQREF;} }
            public TTReportField CASHOFFICENAME { get {return Header().CASHOFFICENAME;} }
            public TTReportField RESUSER { get {return Header().RESUSER;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField REVENUETOTAL { get {return Footer().REVENUETOTAL;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField TOTALCASHOFFICECASHANNUAL { get {return Footer().TOTALCASHOFFICECASHANNUAL;} }
            public TTReportField NOTE { get {return Footer().NOTE;} }
            public TTReportField CASHIER { get {return Footer().CASHIER;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField CASHIERUSERTYPE { get {return Footer().CASHIERUSERTYPE;} }
            public TTReportField CASHIERTITLE { get {return Footer().CASHIERTITLE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField CASHIEREMPLOYMENTRECORDID { get {return Footer().CASHIEREMPLOYMENTRECORDID;} }
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

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>("CashOfficeClosingReportQuery", CashOfficeClosing.CashOfficeClosingCashReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MainCashOfficeClosingReport MyParentReport
                {
                    get { return (MainCashOfficeClosingReport)ParentReport; }
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
                public TTReportField NewField4;
                public TTReportField CLOSINGDATE;
                public TTReportField CASHOFFICE;
                public TTReportField NewField17;
                public TTReportField CASHANNUAL;
                public TTReportField PAGE;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField CASHIERLOG;
                public TTReportField CASHOFFICEQREF;
                public TTReportField CASHOFFICENAME;
                public TTReportField RESUSER; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 34, 48, 39, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"VEZ.ALIN.NO";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 34, 183, 39, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"NAKİT";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 34, 27, 39, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 34, 66, 39, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"TARİH";

                    NewField137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 34, 161, 39, false);
                    NewField137.Name = "NewField137";
                    NewField137.TextFont.Bold = true;
                    NewField137.TextFont.CharSet = 162;
                    NewField137.Value = @"TAHSİLAT TÜRÜ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 34, 119, 39, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"AÇIKLAMA";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 40, 183, 40, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 10, 166, 18, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"VEZNE ALINDI LİSTESİ";

                    CASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 5, 245, 10, false);
                    CASHOFFICECASHANNUAL.Name = "CASHOFFICECASHANNUAL";
                    CASHOFFICECASHANNUAL.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICECASHANNUAL.Value = @"{#CASHOFFICECASHANNUAL#}";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 20, 48, 25, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.Value = @"{#OPENINGDATE#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 20, 55, 25, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.Value = @"-";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 20, 78, 25, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"Short Date";
                    CLOSINGDATE.Value = @"{#CLOSINGDATE#}";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 26, 156, 31, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 42, 140, 47, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"NAKLİ YEKÜN";

                    CASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 42, 183, 47, false);
                    CASHANNUAL.Name = "CASHANNUAL";
                    CASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHANNUAL.TextFormat = @"Currency";
                    CASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CASHANNUAL.Value = @"";

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 12, 194, 17, false);
                    PAGE.Name = "PAGE";
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"{@pagenumber@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 12, 183, 17, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"Sayfa No :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 20, 30, 25, false);
                    NewField6.Name = "NewField6";
                    NewField6.Value = @"TARİH  :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 26, 30, 31, false);
                    NewField7.Name = "NewField7";
                    NewField7.Value = @"VEZNE :";

                    CASHIERLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 14, 250, 19, false);
                    CASHIERLOG.Name = "CASHIERLOG";
                    CASHIERLOG.Visible = EvetHayirEnum.ehHayir;
                    CASHIERLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERLOG.Value = @"{#CASHIERLOG#}";

                    CASHOFFICEQREF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 22, 253, 27, false);
                    CASHOFFICEQREF.Name = "CASHOFFICEQREF";
                    CASHOFFICEQREF.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICEQREF.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICEQREF.Value = @"{#CASHOFFICEQREF#}";

                    CASHOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 28, 253, 33, false);
                    CASHOFFICENAME.Name = "CASHOFFICENAME";
                    CASHOFFICENAME.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICENAME.Value = @"{#CASHOFFICENAME#}";

                    RESUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 34, 253, 39, false);
                    RESUSER.Name = "RESUSER";
                    RESUSER.Visible = EvetHayirEnum.ehHayir;
                    RESUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESUSER.Value = @"{#RESUSER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CashOfficeClosing.CashOfficeClosingCashReportQuery_Class dataset_CashOfficeClosingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField137.CalcValue = NewField137.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField3.CalcValue = NewField3.Value;
                    CASHOFFICECASHANNUAL.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.CashOfficeCashAnnual) : "");
                    OPENINGDATE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.OpeningDate) : "");
                    NewField4.CalcValue = NewField4.Value;
                    CLOSINGDATE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.ClosingDate) : "");
                    CASHOFFICE.CalcValue = @"";
                    NewField17.CalcValue = NewField17.Value;
                    CASHANNUAL.CalcValue = @"";
                    PAGE.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    CASHIERLOG.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.CashierLog) : "");
                    CASHOFFICEQREF.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashofficeqref) : "");
                    CASHOFFICENAME.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashofficename) : "");
                    RESUSER.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.ResUser) : "");
                    return new TTReportObject[] { NewField1,NewField2,NewField11,NewField12,NewField137,NewField14,NewField3,CASHOFFICECASHANNUAL,OPENINGDATE,NewField4,CLOSINGDATE,CASHOFFICE,NewField17,CASHANNUAL,PAGE,NewField5,NewField6,NewField7,CASHIERLOG,CASHOFFICEQREF,CASHOFFICENAME,RESUSER};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if (this.PAGE.CalcValue == "1")
                ((MainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL = Convert.ToDouble(this.CASHOFFICECASHANNUAL.CalcValue);
            
            this.CASHANNUAL.CalcValue = ((MainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.RESUSER.CalcValue.ToString();
            ResUser myResUser = (ResUser)context.GetObject(new Guid(sObjectID),"ResUser");
            TTUser ttUser = myResUser.GetMyTTUser();
            
            this.CASHOFFICE.CalcValue = this.CASHOFFICEQREF.CalcValue + " " + this.CASHOFFICENAME.CalcValue + " - " + ttUser.Name;
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public MainCashOfficeClosingReport MyParentReport
                {
                    get { return (MainCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField REVENUETOTAL;
                public TTReportField NewField16;
                public TTReportField TOTALCASHOFFICECASHANNUAL;
                public TTReportField NOTE;
                public TTReportField CASHIER;
                public TTReportField ACCOUNTANT;
                public TTReportField CASHIERUSERTYPE;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIEREMPLOYMENTRECORDID;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField MAINACASHIERNAME; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 75;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 4, 133, 9, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"GÜNLÜK TAHSİLAT";

                    REVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 4, 183, 9, false);
                    REVENUETOTAL.Name = "REVENUETOTAL";
                    REVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTAL.TextFormat = @"Currency";
                    REVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTAL.Value = @"{#REVENUETOTAL#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 10, 126, 15, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"NAKLİ YEKÜN";

                    TOTALCASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 10, 183, 15, false);
                    TOTALCASHOFFICECASHANNUAL.Name = "TOTALCASHOFFICECASHANNUAL";
                    TOTALCASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCASHOFFICECASHANNUAL.TextFormat = @"Currency";
                    TOTALCASHOFFICECASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCASHOFFICECASHANNUAL.Value = @"";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 21, 183, 38, false);
                    NOTE.Name = "NOTE";
                    NOTE.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE.NoClip = EvetHayirEnum.ehEvet;
                    NOTE.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOTE.Value = @"................................................numaradan ................................................ numaraya kadar olan alındılarla tahsil edilmiş toplam .............................................................. Türk Lirası .......................................tarihli ve ..........................................sayılı teslimat müzekkeresi ile bankaya yatırılmıştır.";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 55, 64, 69, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 55, 132, 69, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"Muhasebe Yetkilisi
....../....../..........";

                    CASHIERUSERTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 32, 258, 37, false);
                    CASHIERUSERTYPE.Name = "CASHIERUSERTYPE";
                    CASHIERUSERTYPE.Visible = EvetHayirEnum.ehHayir;
                    CASHIERUSERTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERUSERTYPE.ObjectDefName = "UserTypeEnum";
                    CASHIERUSERTYPE.DataMember = "DISPLAYTEXT";
                    CASHIERUSERTYPE.Value = @"{#USERTYPE#}";

                    CASHIERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 39, 258, 44, false);
                    CASHIERTITLE.Name = "CASHIERTITLE";
                    CASHIERTITLE.Visible = EvetHayirEnum.ehHayir;
                    CASHIERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERTITLE.ObjectDefName = "UserTitleEnum";
                    CASHIERTITLE.DataMember = "DISPLAYTEXT";
                    CASHIERTITLE.Value = @"{#TITLE#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 45, 259, 50, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    CASHIEREMPLOYMENTRECORDID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 51, 259, 56, false);
                    CASHIEREMPLOYMENTRECORDID.Name = "CASHIEREMPLOYMENTRECORDID";
                    CASHIEREMPLOYMENTRECORDID.Visible = EvetHayirEnum.ehHayir;
                    CASHIEREMPLOYMENTRECORDID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIEREMPLOYMENTRECORDID.Value = @"{#CASHIEREMPLOYMENTRECORDID#}";

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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CashOfficeClosing.CashOfficeClosingCashReportQuery_Class dataset_CashOfficeClosingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(0);
                    NewField15.CalcValue = NewField15.Value;
                    REVENUETOTAL.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.RevenueTotal) : "");
                    NewField16.CalcValue = NewField16.Value;
                    TOTALCASHOFFICECASHANNUAL.CalcValue = @"";
                    NOTE.CalcValue = NOTE.Value;
                    CASHIER.CalcValue = @"";
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    CASHIERUSERTYPE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.UserType) : "");
                    CASHIERUSERTYPE.PostFieldValueCalculation();
                    CASHIERTITLE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Title) : "");
                    CASHIERTITLE.PostFieldValueCalculation();
                    CASHIERNAME.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashiername) : "");
                    CASHIEREMPLOYMENTRECORDID.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashieremploymentrecordid) : "");
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "");
                    MAINACASHIERNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAINCASHIERNAME", "");
                    return new TTReportObject[] { NewField15,REVENUETOTAL,NewField16,TOTALCASHOFFICECASHANNUAL,NOTE,CASHIER,ACCOUNTANT,CASHIERUSERTYPE,CASHIERTITLE,CASHIERNAME,CASHIEREMPLOYMENTRECORDID,ACCOUNTANTNAME,MAINACASHIERNAME};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    this.TOTALCASHOFFICECASHANNUAL.CalcValue = ((MainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
            this.CASHIER.CalcValue = this.CASHIERNAME.CalcValue + "\n" + this.CASHIERUSERTYPE.CalcValue + "  (" + this.CASHIEREMPLOYMENTRECORDID.CalcValue + ")" + "\n" + this.CASHIERTITLE.CalcValue + "\n" + "....../....../.........." ;
            //   this.ACCOUNTANT.CalcValue = this.ACCOUNTANTNAME.CalcValue + "\n" + "Saymanlık Müdürü" ;
            //   this.MAINCASHIER.CalcValue = this.MAINACASHIERNAME.CalcValue + "\n" + "Veznedar";
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class DETAILGroup : TTReportGroup
        {
            public MainCashOfficeClosingReport MyParentReport
            {
                get { return (MainCashOfficeClosingReport)ParentReport; }
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
                public MainCashOfficeClosingReport MyParentReport
                {
                    get { return (MainCashOfficeClosingReport)ParentReport; }
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
                    
                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 0, 48, 5, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 183, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 0, 66, 5, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"Short Date";
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 0, 119, 5, false);
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

                    MONEYRECEIVEDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 161, 5, false);
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

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 197, 5, false);
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
                        ((MainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL = ((MainCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.TOTALPRICE.CalcValue);
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

        public MainCashOfficeClosingReport()
        {
            UPREPORT = new UPREPORTGroup(this,"UPREPORT");
            BOTTOM = new BOTTOMGroup(this,"BOTTOM");
            HEAD = new HEADGroup(BOTTOM,"HEAD");
            DETAIL = new DETAILGroup(HEAD,"DETAIL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PAGETOTAL", "0", "NAKLI YEKÜN", @"", false, false, false, new Guid("0ca2000a-f03c-42d1-8125-b33c48d68f02"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PAGETOTAL"))
                _runtimeParameters.PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double17.2"].ConvertValue(parameters["PAGETOTAL"]);
            Name = "MAINCASHOFFICECLOSINGREPORT";
            Caption = "Vezne Kasa Kapama Raporu";
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