
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
    public partial class SubCashOfficeClosingReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public double? PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double17.2"].ConvertValue("0");
        }

        public partial class BOTTOMGroup : TTReportGroup
        {
            public SubCashOfficeClosingReport MyParentReport
            {
                get { return (SubCashOfficeClosingReport)ParentReport; }
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
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public SubCashOfficeClosingReport MyParentReport
                {
                    get { return (SubCashOfficeClosingReport)ParentReport; }
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
                public SubCashOfficeClosingReport MyParentReport
                {
                    get { return (SubCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public BOTTOMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 24;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 121, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 55, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 210, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CURRENTUSER};
                }
            }

        }

        public BOTTOMGroup BOTTOM;

        public partial class HEADGroup : TTReportGroup
        {
            public SubCashOfficeClosingReport MyParentReport
            {
                get { return (SubCashOfficeClosingReport)ParentReport; }
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
            public TTReportField CASHOFFICECASHANNUAL { get {return Header().CASHOFFICECASHANNUAL;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField CLOSINGDATE { get {return Header().CLOSINGDATE;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField CASHANNUAL { get {return Header().CASHANNUAL;} }
            public TTReportField PAGE { get {return Header().PAGE;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField CASHIERLOG { get {return Header().CASHIERLOG;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField CASHOFFICEQREF { get {return Header().CASHOFFICEQREF;} }
            public TTReportField CASHOFFICENAME { get {return Header().CASHOFFICENAME;} }
            public TTReportField RESUSER { get {return Header().RESUSER;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField REVENUETOTAL { get {return Footer().REVENUETOTAL;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField TOTALCASHOFFICECASHANNUAL { get {return Footer().TOTALCASHOFFICECASHANNUAL;} }
            public TTReportField NOTE { get {return Footer().NOTE;} }
            public TTReportField CASHIER { get {return Footer().CASHIER;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField MAINCASHIER { get {return Footer().MAINCASHIER;} }
            public TTReportField CASHIERUSERTYPE { get {return Footer().CASHIERUSERTYPE;} }
            public TTReportField CASHIERTITLE { get {return Footer().CASHIERTITLE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField CASHIEREMPLOYMENTRECORDID { get {return Footer().CASHIEREMPLOYMENTRECORDID;} }
            public TTReportField ACCOUNTANTNAME { get {return Footer().ACCOUNTANTNAME;} }
            public TTReportField MAINACASHIERNAME { get {return Footer().MAINACASHIERNAME;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField TREATMENTPRICEBACKTOTAL { get {return Footer().TREATMENTPRICEBACKTOTAL;} }
            public TTReportField BANKACCOUNT { get {return Footer().BANKACCOUNT;} }
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
                public SubCashOfficeClosingReport MyParentReport
                {
                    get { return (SubCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportShape NewLine1;
                public TTReportField NewField3;
                public TTReportField CASHOFFICECASHANNUAL;
                public TTReportField OPENINGDATE;
                public TTReportField NewField4;
                public TTReportField CLOSINGDATE;
                public TTReportField NewField17;
                public TTReportField CASHANNUAL;
                public TTReportField PAGE;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField CASHIERLOG;
                public TTReportField NewField18;
                public TTReportField NewField181;
                public TTReportField CASHOFFICEQREF;
                public TTReportField CASHOFFICENAME;
                public TTReportField RESUSER;
                public TTReportField CASHOFFICE;
                public TTReportField NewField1131; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 45;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 31, 80, 36, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BELGE NO";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 31, 180, 36, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"NAKİT";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 31, 18, 36, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 31, 106, 36, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BELGE TARİHİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 31, 210, 36, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AÇIKLAMA";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 31, 59, 36, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"ADI SOYADI";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 37, 210, 37, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 3, 177, 15, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"MUHASEBE YETKİLİSİ MUTEMEDİ ALINDISI BORÇ KISMI KASA DEFTERİ";

                    CASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 18, 157, 23, false);
                    CASHOFFICECASHANNUAL.Name = "CASHOFFICECASHANNUAL";
                    CASHOFFICECASHANNUAL.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICECASHANNUAL.Value = @"{#CASHOFFICECASHANNUAL#}";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 18, 71, 23, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.Value = @"{#OPENINGDATE#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 18, 76, 23, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.Value = @"-";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 18, 97, 23, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"Short Date";
                    CLOSINGDATE.Value = @"{#CLOSINGDATE#}";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 39, 154, 44, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"NAKLİ YEKÜN";

                    CASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 39, 180, 44, false);
                    CASHANNUAL.Name = "CASHANNUAL";
                    CASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHANNUAL.TextFormat = @"#,##0.#0";
                    CASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CASHANNUAL.Value = @"";

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 5, 210, 10, false);
                    PAGE.Name = "PAGE";
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"{@pagenumber@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 5, 197, 10, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"Sayfa No :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 18, 51, 23, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"TARİH";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 24, 51, 29, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"MUH.YETKİLİSİ MUTEMETLİĞİ";

                    CASHIERLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 17, 206, 22, false);
                    CASHIERLOG.Name = "CASHIERLOG";
                    CASHIERLOG.Visible = EvetHayirEnum.ehHayir;
                    CASHIERLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERLOG.Value = @"{#CASHIERLOG#}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 18, 55, 23, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 24, 55, 29, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    CASHOFFICEQREF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 20, 258, 25, false);
                    CASHOFFICEQREF.Name = "CASHOFFICEQREF";
                    CASHOFFICEQREF.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICEQREF.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICEQREF.Value = @"{#CASHOFFICEQREF#}";

                    CASHOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 26, 258, 31, false);
                    CASHOFFICENAME.Name = "CASHOFFICENAME";
                    CASHOFFICENAME.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICENAME.Value = @"{#CASHOFFICENAME#}";

                    RESUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 32, 258, 37, false);
                    RESUSER.Name = "RESUSER";
                    RESUSER.Visible = EvetHayirEnum.ehHayir;
                    RESUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESUSER.Value = @"{#RESUSER#}";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 24, 157, 29, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 31, 162, 36, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"GELİR TÜRÜ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CashOfficeClosing.CashOfficeClosingCashReportQuery_Class dataset_CashOfficeClosingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField3.CalcValue = NewField3.Value;
                    CASHOFFICECASHANNUAL.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.CashOfficeCashAnnual) : "");
                    OPENINGDATE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.OpeningDate) : "");
                    NewField4.CalcValue = NewField4.Value;
                    CLOSINGDATE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.ClosingDate) : "");
                    NewField17.CalcValue = NewField17.Value;
                    CASHANNUAL.CalcValue = @"";
                    PAGE.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    CASHIERLOG.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.CashierLog) : "");
                    NewField18.CalcValue = NewField18.Value;
                    NewField181.CalcValue = NewField181.Value;
                    CASHOFFICEQREF.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashofficeqref) : "");
                    CASHOFFICENAME.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashofficename) : "");
                    RESUSER.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.ResUser) : "");
                    CASHOFFICE.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField11,NewField12,NewField13,NewField14,NewField3,CASHOFFICECASHANNUAL,OPENINGDATE,NewField4,CLOSINGDATE,NewField17,CASHANNUAL,PAGE,NewField5,NewField6,NewField7,CASHIERLOG,NewField18,NewField181,CASHOFFICEQREF,CASHOFFICENAME,RESUSER,CASHOFFICE,NewField1131};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if (this.PAGE.CalcValue == "1")
                ((SubCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL = Convert.ToDouble(this.CASHOFFICECASHANNUAL.CalcValue);
            
            this.CASHANNUAL.CalcValue = ((SubCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
            
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
                public SubCashOfficeClosingReport MyParentReport
                {
                    get { return (SubCashOfficeClosingReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField REVENUETOTAL;
                public TTReportField NewField16;
                public TTReportField TOTALCASHOFFICECASHANNUAL;
                public TTReportField NOTE;
                public TTReportField CASHIER;
                public TTReportField ACCOUNTANT;
                public TTReportField MAINCASHIER;
                public TTReportField CASHIERUSERTYPE;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIEREMPLOYMENTRECORDID;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField MAINACASHIERNAME;
                public TTReportField NewField1161;
                public TTReportField TREATMENTPRICEBACKTOTAL;
                public TTReportField BANKACCOUNT; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 81;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 11, 129, 16, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"GÜNLÜK TAHSİLAT";

                    REVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 11, 180, 16, false);
                    REVENUETOTAL.Name = "REVENUETOTAL";
                    REVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTAL.TextFormat = @"#,##0.#0";
                    REVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTAL.Value = @"{#CASHREVENUETOTAL#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 17, 122, 22, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"NAKLİ YEKÜN";

                    TOTALCASHOFFICECASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 17, 180, 22, false);
                    TOTALCASHOFFICECASHANNUAL.Name = "TOTALCASHOFFICECASHANNUAL";
                    TOTALCASHOFFICECASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCASHOFFICECASHANNUAL.TextFormat = @"#,##0.#0";
                    TOTALCASHOFFICECASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCASHOFFICECASHANNUAL.Value = @"";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 29, 210, 46, false);
                    NOTE.Name = "NOTE";
                    NOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTE.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE.NoClip = EvetHayirEnum.ehEvet;
                    NOTE.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOTE.Value = @"";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 63, 52, 77, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 63, 132, 77, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"";

                    MAINCASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 62, 210, 77, false);
                    MAINCASHIER.Name = "MAINCASHIER";
                    MAINCASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINCASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    MAINCASHIER.NoClip = EvetHayirEnum.ehEvet;
                    MAINCASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAINCASHIER.Value = @"";

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

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 5, 136, 10, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"TEDAVİ BEDELİ İADESİ";

                    TREATMENTPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 5, 180, 10, false);
                    TREATMENTPRICEBACKTOTAL.Name = "TREATMENTPRICEBACKTOTAL";
                    TREATMENTPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTPRICEBACKTOTAL.TextFormat = @"#,##0.#0";
                    TREATMENTPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TREATMENTPRICEBACKTOTAL.Value = @"{#TREATMENTPRICEBACKTOTAL#}";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 24, 247, 29, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.Visible = EvetHayirEnum.ehHayir;
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BANKACCOUNT.Value = @"{#BANKACCOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CashOfficeClosing.CashOfficeClosingCashReportQuery_Class dataset_CashOfficeClosingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CashOfficeClosing.CashOfficeClosingCashReportQuery_Class>(0);
                    NewField15.CalcValue = NewField15.Value;
                    REVENUETOTAL.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.CashRevenueTotal) : "");
                    NewField16.CalcValue = NewField16.Value;
                    TOTALCASHOFFICECASHANNUAL.CalcValue = @"";
                    NOTE.CalcValue = @"";
                    CASHIER.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    MAINCASHIER.CalcValue = @"";
                    CASHIERUSERTYPE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.UserType) : "");
                    CASHIERUSERTYPE.PostFieldValueCalculation();
                    CASHIERTITLE.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Title) : "");
                    CASHIERTITLE.PostFieldValueCalculation();
                    CASHIERNAME.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashiername) : "");
                    CASHIEREMPLOYMENTRECORDID.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.Cashieremploymentrecordid) : "");
                    NewField1161.CalcValue = NewField1161.Value;
                    TREATMENTPRICEBACKTOTAL.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.TreatmentPriceBackTotal) : "");
                    BANKACCOUNT.CalcValue = (dataset_CashOfficeClosingReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeClosingReportQuery.BankAccount) : "");
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "");
                    MAINACASHIERNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAINCASHIERNAME", "");
                    return new TTReportObject[] { NewField15,REVENUETOTAL,NewField16,TOTALCASHOFFICECASHANNUAL,NOTE,CASHIER,ACCOUNTANT,MAINCASHIER,CASHIERUSERTYPE,CASHIERTITLE,CASHIERNAME,CASHIEREMPLOYMENTRECORDID,NewField1161,TREATMENTPRICEBACKTOTAL,BANKACCOUNT,ACCOUNTANTNAME,MAINACASHIERNAME};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    // XXXXXX dan alınan raporda Nakli Yekünü ,  Tedavi İadelerinin etkilemediği görüldüğü için commetlendi
            //            double treatmentBackTotal = 0 ;
            //            if (this.TREATMENTPRICEBACKTOTAL.CalcValue != "")
            //                treatmentBackTotal = Convert.ToDouble(this.TREATMENTPRICEBACKTOTAL.CalcValue);
            //            this.TOTALCASHOFFICECASHANNUAL.CalcValue = (Convert.ToDouble(((SubCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL) - treatmentBackTotal).ToString();
//
            this.TOTALCASHOFFICECASHANNUAL.CalcValue = ((SubCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL.ToString();
            this.CASHIER.CalcValue = this.CASHIERNAME.CalcValue + "\n" + this.CASHIERUSERTYPE.CalcValue + "  (" + this.CASHIEREMPLOYMENTRECORDID.CalcValue + ")" + "\n" + this.CASHIERTITLE.CalcValue ;
            this.ACCOUNTANT.CalcValue = this.ACCOUNTANTNAME.CalcValue + "\n" + "Saymanlık Müdürü" ;
            this.MAINCASHIER.CalcValue = this.MAINACASHIERNAME.CalcValue + "\n" + "Vezne Memuru";
            if(this.BANKACCOUNT.CalcValue=="")
            {
                this.NOTE.CalcValue="......................................... numaradan ......................................... numaraya kadar olan muhasebe yetkilisi mutemedi alındılarıyla tahsil edilmiş toplam ......................................................... Türk Lirası .................................. tarihli ve ........................................" +
               " sayılı alındı belgesi karşılığında saymanlığa yatırılmıştır.";
            }
            else
            {
                this.NOTE.CalcValue="......................................... numaradan ......................................... numaraya kadar olan muhasebe yetkilisi mutemedi alındılarıyla tahsil edilmiş toplam ......................................................... Türk Lirası .................................. tarihli " +
               " banka dekontu karşılığında bankaya yatırılmıştır. ";
            }
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class DETAILGroup : TTReportGroup
        {
            public SubCashOfficeClosingReport MyParentReport
            {
                get { return (SubCashOfficeClosingReport)ParentReport; }
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
                list[0] = new TTReportNqlData<AccountDocument.GetAccDocsByCasLogAndCash_Class>("GetAccDocsByCashierLogID", AccountDocument.GetAccDocsByCasLogAndCash((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.HEAD.CASHIERLOG.CalcValue)));
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
                public SubCashOfficeClosingReport MyParentReport
                {
                    get { return (SubCashOfficeClosingReport)ParentReport; }
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
                    
                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 80, 5, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 180, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 106, 5, false);
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

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 18, 5, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.Value = @"";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 59, 5, false);
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

                    REVENUETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 162, 5, false);
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
                    AccountDocument.GetAccDocsByCasLogAndCash_Class dataset_GetAccDocsByCashierLogID = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetAccDocsByCasLogAndCash_Class>(0);
                    DOCUMENTNO.CalcValue = (dataset_GetAccDocsByCashierLogID != null ? Globals.ToStringCore(dataset_GetAccDocsByCashierLogID.DocumentNo) : "");
                    TOTALPRICE.CalcValue = (dataset_GetAccDocsByCashierLogID != null ? Globals.ToStringCore(dataset_GetAccDocsByCashierLogID.Totalprice) : "");
                    DOCUMENTDATE.CalcValue = (dataset_GetAccDocsByCashierLogID != null ? Globals.ToStringCore(dataset_GetAccDocsByCashierLogID.DocumentDate) : "");
                    DESCRIPTION.CalcValue = (dataset_GetAccDocsByCashierLogID != null ? Globals.ToStringCore(dataset_GetAccDocsByCashierLogID.Description) : "");
                    SNO.CalcValue = @"";
                    PATIENTNAME.CalcValue = (dataset_GetAccDocsByCashierLogID != null ? Globals.ToStringCore(dataset_GetAccDocsByCashierLogID.Patientname) : "");
                    ACCDOCOBJID.CalcValue = (dataset_GetAccDocsByCashierLogID != null ? Globals.ToStringCore(dataset_GetAccDocsByCashierLogID.ObjectID) : "");
                    REVENUETYPE.CalcValue = @"";
                    return new TTReportObject[] { DOCUMENTNO,TOTALPRICE,DOCUMENTDATE,DESCRIPTION,SNO,PATIENTNAME,ACCDOCOBJID,REVENUETYPE};
                }

                public override void RunScript()
                {
#region DETAIL BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.ACCDOCOBJID.CalcValue.ToString();
            AccountDocument accDoc = (AccountDocument)context.GetObject(new Guid(sObjectID),"AccountDocument");
            
            if (accDoc != null)
            {
                if (accDoc is ReceiptDocument)
                {
                    ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                    if(receiptDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue =  receiptDocument.SpecialNo.ToString();
                    else
                        this.SNO.CalcValue = "";
                    
                    this.TOTALPRICE.CalcValue = receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate)).ToString();
                    
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
                    if(advanceDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue =  advanceDocument.SpecialNo.ToString();
                    else
                        this.SNO.CalcValue = "";
                    
                    this.TOTALPRICE.CalcValue = advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate)).ToString();
                    
                    if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                
                if (accDoc is DebenturePaymentDocument)
                {
                    DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                    if(debenturePaymentDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue =  debenturePaymentDocument.SpecialNo.ToString();
                    else
                        this.SNO.CalcValue = "";
                    
                    this.TOTALPRICE.CalcValue = debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate)).ToString();
                    
                    if(debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Cancelled)
                    {
                        this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                if(accDoc is SubCashOfficeReceiptDoc)
                {
                    SubCashOfficeReceiptDoc subCashOfficeReceiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                    if(subCashOfficeReceiptDoc.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue = subCashOfficeReceiptDoc.SpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "";
                    
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
                    if(generalReceiptDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue = generalReceiptDocument.SpecialNo.Value.ToString();
                    else
                        this.SNO.CalcValue = "";
                    
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
                ((SubCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL = ((SubCashOfficeClosingReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.TOTALPRICE.CalcValue);
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

        public SubCashOfficeClosingReport()
        {
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
            Name = "SUBCASHOFFICECLOSINGREPORT";
            Caption = "Muhasebe Yetkilisi Mutemetliği Kasa Kapama Raporu";
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