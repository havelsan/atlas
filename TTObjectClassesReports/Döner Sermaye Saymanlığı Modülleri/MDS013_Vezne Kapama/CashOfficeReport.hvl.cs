
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
    /// Vezne Raporu
    /// </summary>
    public partial class CashOfficeReport : TTReport
    {
#region Methods
   public Currency PageTotalPrice;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? CASHOFFICE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? CASHIER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public PaymentTypeCashCCEnum? PAYMENTTYPE = (PaymentTypeCashCCEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].ConvertValue("");
            public int? PAYMENTTYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? CASHOFFICECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? CASHIERCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class BOTTOMGroup : TTReportGroup
        {
            public CashOfficeReport MyParentReport
            {
                get { return (CashOfficeReport)ParentReport; }
            }

            new public BOTTOMGroupHeader Header()
            {
                return (BOTTOMGroupHeader)_header;
            }

            new public BOTTOMGroupFooter Footer()
            {
                return (BOTTOMGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public CashOfficeReport MyParentReport
                {
                    get { return (CashOfficeReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public BOTTOMGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 28, 7, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 2, 55, 7, false);
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
#region BOTTOM HEADER_Script
                    MyParentReport.PageTotalPrice = 0;
            MyParentReport.RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            MyParentReport.RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");

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
#endregion BOTTOM HEADER_Script
                }
            }
            public partial class BOTTOMGroupFooter : TTReportSection
            {
                public CashOfficeReport MyParentReport
                {
                    get { return (CashOfficeReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public BOTTOMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
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
            public CashOfficeReport MyParentReport
            {
                get { return (CashOfficeReport)ParentReport; }
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
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField CLOSINGDATE { get {return Header().CLOSINGDATE;} }
            public TTReportField CASHANNUALLBL { get {return Header().CASHANNUALLBL;} }
            public TTReportField CASHANNUAL { get {return Header().CASHANNUAL;} }
            public TTReportField PAGE { get {return Header().PAGE;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField CASHIER { get {return Header().CASHIER;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField PAYMENTTYPE { get {return Header().PAYMENTTYPE;} }
            public TTReportField CASHOFFICEOBJECTID { get {return Header().CASHOFFICEOBJECTID;} }
            public TTReportField CASHIEROBJECTID { get {return Header().CASHIEROBJECTID;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField REVENUETOTAL { get {return Footer().REVENUETOTAL;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField TOTALCASHOFFICECASHANNUAL { get {return Footer().TOTALCASHOFFICECASHANNUAL;} }
            public TTReportField NOTE { get {return Footer().NOTE;} }
            public TTReportField CASHIERINFO { get {return Footer().CASHIERINFO;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField MAINCASHIER { get {return Footer().MAINCASHIER;} }
            public TTReportField CASHIERUSERTYPE { get {return Footer().CASHIERUSERTYPE;} }
            public TTReportField CASHIERTITLE { get {return Footer().CASHIERTITLE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField CASHIEREMPLOYMENTRECORDID { get {return Footer().CASHIEREMPLOYMENTRECORDID;} }
            public TTReportField ACCOUNTANTNAME { get {return Footer().ACCOUNTANTNAME;} }
            public TTReportField MAINCASHIERNAME { get {return Footer().MAINCASHIERNAME;} }
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

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public CashOfficeReport MyParentReport
                {
                    get { return (CashOfficeReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportShape NewLine1;
                public TTReportField NewField3;
                public TTReportField OPENINGDATE;
                public TTReportField NewField4;
                public TTReportField CLOSINGDATE;
                public TTReportField CASHANNUALLBL;
                public TTReportField CASHANNUAL;
                public TTReportField PAGE;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField18;
                public TTReportField NewField181;
                public TTReportField CASHOFFICE;
                public TTReportField NewField1131;
                public TTReportField NewField19;
                public TTReportField NewField1181;
                public TTReportField CASHIER;
                public TTReportField NewField191;
                public TTReportField NewField11811;
                public TTReportField PAYMENTTYPE;
                public TTReportField CASHOFFICEOBJECTID;
                public TTReportField CASHIEROBJECTID; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 36, 80, 41, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BELGE NO";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 36, 180, 41, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"NAKİT";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 36, 18, 41, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 36, 106, 41, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BELGE TARİHİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 36, 210, 41, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AÇIKLAMA";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 36, 59, 41, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"ADI SOYADI";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 42, 210, 42, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 7, 177, 15, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"KASA DEFTERİ";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 15, 48, 20, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"dd/MM/yyyy";
                    OPENINGDATE.Value = @"{@STARTDATE@}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 15, 52, 20, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.Value = @"-";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 15, 74, 20, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"dd/MM/yyyy";
                    CLOSINGDATE.Value = @"{@ENDDATE@}";

                    CASHANNUALLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 30, 158, 35, false);
                    CASHANNUALLBL.Name = "CASHANNUALLBL";
                    CASHANNUALLBL.Value = @"NAKLİ YEKÜN";

                    CASHANNUAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 30, 180, 35, false);
                    CASHANNUAL.Name = "CASHANNUAL";
                    CASHANNUAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHANNUAL.TextFormat = @"#,##0.#0";
                    CASHANNUAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CASHANNUAL.Value = @"";

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 7, 210, 12, false);
                    PAGE.Name = "PAGE";
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"{@pagenumber@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 7, 198, 12, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"Sayfa No :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 28, 20, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Tarih";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 28, 25, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Vezne";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 15, 31, 20, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 20, 31, 25, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 20, 129, 25, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 36, 162, 41, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"GELİR TÜRÜ";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 28, 30, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Veznedar";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 25, 31, 30, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 25, 129, 30, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 30, 28, 35, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Ödeme Tipi";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 30, 31, 35, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @":";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 30, 129, 35, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.ObjectDefName = "PaymentTypeCashCCEnum";
                    PAYMENTTYPE.DataMember = "DISPLAYTEXT";
                    PAYMENTTYPE.Value = @"{@PAYMENTTYPE@}";

                    CASHOFFICEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 10, 258, 15, false);
                    CASHOFFICEOBJECTID.Name = "CASHOFFICEOBJECTID";
                    CASHOFFICEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICEOBJECTID.Value = @"{@CASHOFFICE@}";

                    CASHIEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 15, 258, 20, false);
                    CASHIEROBJECTID.Name = "CASHIEROBJECTID";
                    CASHIEROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    CASHIEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIEROBJECTID.Value = @"{@CASHIER@}";

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
                    OPENINGDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField4.CalcValue = NewField4.Value;
                    CLOSINGDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    CASHANNUALLBL.CalcValue = CASHANNUALLBL.Value;
                    CASHANNUAL.CalcValue = @"";
                    PAGE.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField181.CalcValue = NewField181.Value;
                    CASHOFFICE.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    CASHIER.CalcValue = @"";
                    NewField191.CalcValue = NewField191.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    PAYMENTTYPE.CalcValue = MyParentReport.RuntimeParameters.PAYMENTTYPE.ToString();
                    PAYMENTTYPE.PostFieldValueCalculation();
                    CASHOFFICEOBJECTID.CalcValue = MyParentReport.RuntimeParameters.CASHOFFICE.ToString();
                    CASHIEROBJECTID.CalcValue = MyParentReport.RuntimeParameters.CASHIER.ToString();
                    return new TTReportObject[] { NewField1,NewField2,NewField11,NewField12,NewField13,NewField14,NewField3,OPENINGDATE,NewField4,CLOSINGDATE,CASHANNUALLBL,CASHANNUAL,PAGE,NewField5,NewField6,NewField7,NewField18,NewField181,CASHOFFICE,NewField1131,NewField19,NewField1181,CASHIER,NewField191,NewField11811,PAYMENTTYPE,CASHOFFICEOBJECTID,CASHIEROBJECTID};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if (this.CASHOFFICEOBJECTID.CalcValue != Guid.Empty.ToString())
            {
                CashOfficeDefinition cashOffice = ((CashOfficeReport)ParentReport).ReportObjectContext.GetObject(new Guid(this.CASHOFFICEOBJECTID.CalcValue), typeof(CashOfficeDefinition)) as CashOfficeDefinition;
                this.CASHOFFICE.CalcValue = cashOffice.Name;
            }

            if (this.CASHIEROBJECTID.CalcValue != Guid.Empty.ToString())
            {
                ResUser cashier = ((CashOfficeReport)ParentReport).ReportObjectContext.GetObject(new Guid(this.CASHIEROBJECTID.CalcValue), typeof(ResUser)) as ResUser;
                this.CASHIER.CalcValue = cashier.Name;
            }
            
            if (((CashOfficeReport)ParentReport).RuntimeParameters.PAYMENTTYPECONTROL.Value.Equals(0)) // Ödeme Tipi seçilmemişse boş kalsın
                this.PAYMENTTYPE.CalcValue = string.Empty;
            
            if (this.PAGE.CalcValue == "1")
            {
                this.CASHANNUALLBL.Visible = EvetHayirEnum.ehHayir;
                this.CASHANNUAL.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.CASHANNUALLBL.Visible = EvetHayirEnum.ehEvet;
                this.CASHANNUAL.Visible = EvetHayirEnum.ehEvet;
            }

            this.CASHANNUAL.CalcValue = ((CashOfficeReport)ParentReport).PageTotalPrice.ToString();

            //            TTObjectContext context = new TTObjectContext(true);
            //            string sObjectID = this.RESUSER.CalcValue.ToString();
            //            ResUser myResUser = (ResUser)context.GetObject(new Guid(sObjectID),"ResUser");
            //            TTUser ttUser = myResUser.GetMyTTUser();
            //            this.CASHOFFICE.CalcValue = this.CASHOFFICEQREF.CalcValue + " " + this.CASHOFFICENAME.CalcValue + " - " + ttUser.Name;
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public CashOfficeReport MyParentReport
                {
                    get { return (CashOfficeReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField REVENUETOTAL;
                public TTReportField NewField16;
                public TTReportField TOTALCASHOFFICECASHANNUAL;
                public TTReportField NOTE;
                public TTReportField CASHIERINFO;
                public TTReportField ACCOUNTANT;
                public TTReportField MAINCASHIER;
                public TTReportField CASHIERUSERTYPE;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIEREMPLOYMENTRECORDID;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField MAINCASHIERNAME;
                public TTReportField NewField1161;
                public TTReportField TREATMENTPRICEBACKTOTAL;
                public TTReportField BANKACCOUNT; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 81;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 11, 136, 16, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"GÜNLÜK TAHSİLAT";

                    REVENUETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 11, 180, 16, false);
                    REVENUETOTAL.Name = "REVENUETOTAL";
                    REVENUETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REVENUETOTAL.TextFormat = @"#,##0.#0";
                    REVENUETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REVENUETOTAL.Value = @"";

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

                    CASHIERINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 63, 52, 77, false);
                    CASHIERINFO.Name = "CASHIERINFO";
                    CASHIERINFO.Visible = EvetHayirEnum.ehHayir;
                    CASHIERINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERINFO.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERINFO.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERINFO.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERINFO.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 63, 132, 77, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"";

                    MAINCASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 62, 210, 77, false);
                    MAINCASHIER.Name = "MAINCASHIER";
                    MAINCASHIER.Visible = EvetHayirEnum.ehHayir;
                    MAINCASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINCASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    MAINCASHIER.NoClip = EvetHayirEnum.ehEvet;
                    MAINCASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAINCASHIER.Value = @"";

                    CASHIERUSERTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 32, 258, 37, false);
                    CASHIERUSERTYPE.Name = "CASHIERUSERTYPE";
                    CASHIERUSERTYPE.Visible = EvetHayirEnum.ehHayir;
                    CASHIERUSERTYPE.ObjectDefName = "UserTypeEnum";
                    CASHIERUSERTYPE.DataMember = "DISPLAYTEXT";
                    CASHIERUSERTYPE.Value = @"{#USERTYPE#}";

                    CASHIERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 39, 258, 44, false);
                    CASHIERTITLE.Name = "CASHIERTITLE";
                    CASHIERTITLE.Visible = EvetHayirEnum.ehHayir;
                    CASHIERTITLE.ObjectDefName = "UserTitleEnum";
                    CASHIERTITLE.DataMember = "DISPLAYTEXT";
                    CASHIERTITLE.Value = @"{#TITLE#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 45, 259, 50, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    CASHIEREMPLOYMENTRECORDID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 51, 259, 56, false);
                    CASHIEREMPLOYMENTRECORDID.Name = "CASHIEREMPLOYMENTRECORDID";
                    CASHIEREMPLOYMENTRECORDID.Visible = EvetHayirEnum.ehHayir;
                    CASHIEREMPLOYMENTRECORDID.Value = @"{#CASHIEREMPLOYMENTRECORDID#}";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 57, 262, 62, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""ACCOUNTANT"", """")";

                    MAINCASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 62, 262, 67, false);
                    MAINCASHIERNAME.Name = "MAINCASHIERNAME";
                    MAINCASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    MAINCASHIERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    MAINCASHIERNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MAINCASHIERNAME"", """")";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 5, 136, 10, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"TEDAVİ BEDELİ İADESİ";

                    TREATMENTPRICEBACKTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 5, 180, 10, false);
                    TREATMENTPRICEBACKTOTAL.Name = "TREATMENTPRICEBACKTOTAL";
                    TREATMENTPRICEBACKTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTPRICEBACKTOTAL.TextFormat = @"#,##0.#0";
                    TREATMENTPRICEBACKTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TREATMENTPRICEBACKTOTAL.Value = @"";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 24, 247, 29, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.Visible = EvetHayirEnum.ehHayir;
                    BANKACCOUNT.Value = @"{#BANKACCOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField15.CalcValue = NewField15.Value;
                    REVENUETOTAL.CalcValue = @"";
                    NewField16.CalcValue = NewField16.Value;
                    TOTALCASHOFFICECASHANNUAL.CalcValue = @"";
                    NOTE.CalcValue = @"";
                    CASHIERINFO.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    MAINCASHIER.CalcValue = @"";
                    CASHIERUSERTYPE.CalcValue = CASHIERUSERTYPE.Value;
                    CASHIERTITLE.CalcValue = CASHIERTITLE.Value;
                    CASHIERNAME.CalcValue = CASHIERNAME.Value;
                    CASHIEREMPLOYMENTRECORDID.CalcValue = CASHIEREMPLOYMENTRECORDID.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    TREATMENTPRICEBACKTOTAL.CalcValue = @"";
                    BANKACCOUNT.CalcValue = BANKACCOUNT.Value;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "");
                    MAINCASHIERNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MAINCASHIERNAME", "");
                    return new TTReportObject[] { NewField15,REVENUETOTAL,NewField16,TOTALCASHOFFICECASHANNUAL,NOTE,CASHIERINFO,ACCOUNTANT,MAINCASHIER,CASHIERUSERTYPE,CASHIERTITLE,CASHIERNAME,CASHIEREMPLOYMENTRECORDID,NewField1161,TREATMENTPRICEBACKTOTAL,BANKACCOUNT,ACCOUNTANTNAME,MAINCASHIERNAME};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    Currency backTotal = 0;

            foreach (AccountDocument accDoc in AccountDocument.GetBackDocsByCashierAndDate(((CashOfficeReport)ParentReport).ReportObjectContext, ((CashOfficeReport)ParentReport).RuntimeParameters.STARTDATE.Value, ((CashOfficeReport)ParentReport).RuntimeParameters.ENDDATE.Value, ((CashOfficeReport)ParentReport).RuntimeParameters.CASHOFFICE.Value, ((CashOfficeReport)ParentReport).RuntimeParameters.CASHIER.Value))
            {
                if (accDoc is ReceiptBackDocument)
                {
                    ReceiptBackDocument receiptBackDocument = (ReceiptBackDocument)accDoc;
                    if (receiptBackDocument.CurrentStateDefID == ReceiptBackDocument.States.Paid && receiptBackDocument.AccountantShipBack != true)
                        backTotal += receiptBackDocument.TotalPrice.Value;
                }
                else if (accDoc is AdvanceBackDocument)
                {
                    AdvanceBackDocument advanceBackDocument = (AdvanceBackDocument)accDoc;
                    if (advanceBackDocument.CurrentStateDefID == AdvanceBackDocument.States.Paid && advanceBackDocument.AccountantShipBack != true)
                        backTotal += advanceBackDocument.TotalPrice.Value;

                }
                else if (accDoc is MainCashOfficeBackDocument)
                {
                    MainCashOfficeBackDocument mainCashOfficeBackDocument = (MainCashOfficeBackDocument)accDoc;
                    if (mainCashOfficeBackDocument.CurrentStateDefID == MainCashOfficeBackDocument.States.Paid && mainCashOfficeBackDocument.BackBankAccount == null)
                        backTotal += mainCashOfficeBackDocument.TotalPrice.Value;
                }
            }

            this.TREATMENTPRICEBACKTOTAL.CalcValue = backTotal.ToString();
            this.REVENUETOTAL.CalcValue = ((CashOfficeReport)ParentReport).PageTotalPrice.ToString();
            this.TOTALCASHOFFICECASHANNUAL.CalcValue = ((CashOfficeReport)ParentReport).PageTotalPrice.ToString();
            
            //this.CASHIER.CalcValue = this.CASHIERNAME.CalcValue + "\n" + this.CASHIERUSERTYPE.CalcValue + "  (" + this.CASHIEREMPLOYMENTRECORDID.CalcValue + ")" + "\n" + this.CASHIERTITLE.CalcValue ;
            this.ACCOUNTANT.CalcValue = this.ACCOUNTANTNAME.CalcValue + "\n" + "Saymanlık Müdürü";
            this.MAINCASHIER.CalcValue = this.MAINCASHIERNAME.CalcValue + "\n" + "Vezne Memuru";

            if (this.BANKACCOUNT.CalcValue == "")
            {
                this.NOTE.CalcValue = "......................................... numaradan ......................................... numaraya kadar olan muhasebe yetkilisi mutemedi alındılarıyla tahsil edilmiş toplam ......................................................... Türk Lirası .................................. tarihli ve ........................................" +
                    " sayılı alındı belgesi karşılığında saymanlığa yatırılmıştır.";
            }
            else
            {
                this.NOTE.CalcValue = "......................................... numaradan ......................................... numaraya kadar olan muhasebe yetkilisi mutemedi alındılarıyla tahsil edilmiş toplam ......................................................... Türk Lirası .................................. tarihli " +
                    " banka dekontu karşılığında bankaya yatırılmıştır. ";
            }
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class DETAILGroup : TTReportGroup
        {
            public CashOfficeReport MyParentReport
            {
                get { return (CashOfficeReport)ParentReport; }
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
                list[0] = new TTReportNqlData<AccountDocument.CashOfficeReportQuery_Class>("CashOfficeReportQuery", AccountDocument.CashOfficeReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CASHOFFICE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CASHIER),((PaymentTypeEnum)TTObjectDefManager.Instance.DataTypes["PaymentTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PAYMENTTYPE.ToString()].EnumValue),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.CASHOFFICECONTROL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.CASHIERCONTROL)));
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
                public CashOfficeReport MyParentReport
                {
                    get { return (CashOfficeReport)ParentReport; }
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
                    DOCUMENTDATE.TextFormat = @"dd/MM/yyyy";
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

                    ACCDOCOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 1, 251, 6, false);
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
                    AccountDocument.CashOfficeReportQuery_Class dataset_CashOfficeReportQuery = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.CashOfficeReportQuery_Class>(0);
                    DOCUMENTNO.CalcValue = (dataset_CashOfficeReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReportQuery.DocumentNo) : "");
                    TOTALPRICE.CalcValue = (dataset_CashOfficeReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReportQuery.TotalPrice) : "");
                    DOCUMENTDATE.CalcValue = (dataset_CashOfficeReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReportQuery.DocumentDate) : "");
                    DESCRIPTION.CalcValue = (dataset_CashOfficeReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReportQuery.Description) : "");
                    SNO.CalcValue = @"";
                    PATIENTNAME.CalcValue = (dataset_CashOfficeReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReportQuery.Patientname) : "");
                    ACCDOCOBJID.CalcValue = (dataset_CashOfficeReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReportQuery.ObjectID) : "");
                    REVENUETYPE.CalcValue = @"";
                    return new TTReportObject[] { DOCUMENTNO,TOTALPRICE,DOCUMENTDATE,DESCRIPTION,SNO,PATIENTNAME,ACCDOCOBJID,REVENUETYPE};
                }

                public override void RunScript()
                {
#region DETAIL BODY_Script
                    bool isCancel = false;
            string sObjectID = this.ACCDOCOBJID.CalcValue.ToString();
            AccountDocument accDoc = (AccountDocument)((CashOfficeReport)ParentReport).ReportObjectContext.GetObject(new Guid(sObjectID), typeof(AccountDocument));
            
            this.DOCUMENTNO.CalcValue = AccountDocument.ReceiptDocumentNo(this.DOCUMENTNO.CalcValue);
            
            if (accDoc != null)
            {
                if (accDoc is ReceiptDocument)
                {
                    ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                    if(receiptDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue =  receiptDocument.SpecialNo.ToString();
                    
                    //this.TOTALPRICE.CalcValue = receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate)).ToString();
                    
                    if(receiptDocument.CurrentStateDefID == ReceiptDocument.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "(İPTAL)";
                        isCancel = true;
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
                else if (accDoc is AdvanceDocument)
                {
                    AdvanceDocument advanceDocument = (AdvanceDocument)accDoc;
                    if(advanceDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue =  advanceDocument.SpecialNo.ToString();
                    
                    //this.TOTALPRICE.CalcValue = advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate)).ToString();
                    
                    if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "(İPTAL)";
                        isCancel = true;
                    }
                }
                else if (accDoc is BondPaymentDocument)
                {
                    BondPaymentDocument bondPaymentDocument = (BondPaymentDocument)accDoc;
                    if(bondPaymentDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue = bondPaymentDocument.SpecialNo.ToString();
                    
                    //this.TOTALPRICE.CalcValue = bondPaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(bondPaymentDocument.DocumentDate)).ToString();

                    if(bondPaymentDocument.BondPayment[0].CurrentStateDefID == BondPayment.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "(İPTAL)";
                        isCancel = true;
                    }
                }
                else if (accDoc is CashOfficeReceiptDocument)
                {
                    CashOfficeReceiptDocument cashOfficeReceiptDocument = (CashOfficeReceiptDocument)accDoc;
                    this.SNO.CalcValue = cashOfficeReceiptDocument.SpecialNo.ToString();
                    
                    if(cashOfficeReceiptDocument.PayeeName != null)
                        this.DESCRIPTION.CalcValue = cashOfficeReceiptDocument.PayeeName.ToString();
                    else
                        this.DESCRIPTION.CalcValue = cashOfficeReceiptDocument.MainCashOfficeOperation[0].Description;
                    
                    this.REVENUETYPE.CalcValue = cashOfficeReceiptDocument.MoneyReceivedType.Name;
                    
                    if(cashOfficeReceiptDocument.CurrentStateDefID == CashOfficeReceiptDocument.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "(İPTAL)";
                        isCancel = true;
                    }
                }
                else if (accDoc is OldDebtReceiptDocument)
                {
                    OldDebtReceiptDocument oldReceipt = accDoc as OldDebtReceiptDocument;
                    if(oldReceipt.PatientOldDebt.Count() > 0)
                        this.PATIENTNAME.CalcValue = oldReceipt.PatientOldDebt[0].OldPatientNameSurname;
                }
                
                /*
                else if(accDoc is SubCashOfficeReceiptDoc)
                {
                    SubCashOfficeReceiptDoc subCashOfficeReceiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                    if(subCashOfficeReceiptDoc.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue = subCashOfficeReceiptDoc.SpecialNo.Value.ToString();
                    
                    if(this.PATIENTNAME.CalcValue == " ")
                    {
                        this.PATIENTNAME.CalcValue = subCashOfficeReceiptDoc.PayeeName;
                        this.DESCRIPTION.CalcValue = subCashOfficeReceiptDoc.MoneyReceivedType.Name;
                    }
                    
                    if(subCashOfficeReceiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                        isCancel = true;
                    }
                }
                else if(accDoc is GeneralReceiptDocument)
                {
                    GeneralReceiptDocument generalReceiptDocument  = (GeneralReceiptDocument)accDoc;
                    if(generalReceiptDocument.SpecialNo.Value.HasValue)
                        this.SNO.CalcValue = generalReceiptDocument.SpecialNo.Value.ToString();
                    
                    if(this.PATIENTNAME.CalcValue == " ")
                    {
                        this.PATIENTNAME.CalcValue = generalReceiptDocument.PayeeName;
                        this.DESCRIPTION.CalcValue = generalReceiptDocument.GeneralReceipt[0].Description;
                    }
                    if(generalReceiptDocument.CurrentStateDefID == GeneralReceiptDocument.States.Cancelled)
                    {
                        //this.TOTALPRICE.CalcValue = "0";
                        this.DESCRIPTION.CalcValue = "İPTAL EDİLMİŞTİR";
                        isCancel = true;
                    }
                }
                 */
                
                if(!isCancel)
                    ((CashOfficeReport)ParentReport).PageTotalPrice += Convert.ToDouble(this.TOTALPRICE.CalcValue);
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

        public CashOfficeReport()
        {
            BOTTOM = new BOTTOMGroup(this,"BOTTOM");
            HEAD = new HEADGroup(BOTTOM,"HEAD");
            DETAIL = new DETAILGroup(HEAD,"DETAIL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CASHOFFICE", "00000000-0000-0000-0000-000000000000", "Vezne", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("ffa9d300-1561-46fa-a262-4126167d70a5");
            reportParameter = Parameters.Add("CASHIER", "00000000-0000-0000-0000-000000000000", "Veznedar", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("b91d94bd-e04f-48fb-ada4-edbeb0973d62");
            reportParameter = Parameters.Add("PAYMENTTYPE", "", "Ödeme Tipi", @"", false, true, false, new Guid("44fa3277-ac8f-4c8f-855c-11b370e2ac95"));
            reportParameter = Parameters.Add("PAYMENTTYPECONTROL", "", "Ödeme Tipi Kontrolü", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("CASHOFFICECONTROL", "", "Vezne Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("CASHIERCONTROL", "", "Veznedar Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CASHOFFICE"))
                _runtimeParameters.CASHOFFICE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CASHOFFICE"]);
            if (parameters.ContainsKey("CASHIER"))
                _runtimeParameters.CASHIER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CASHIER"]);
            if (parameters.ContainsKey("PAYMENTTYPE"))
                _runtimeParameters.PAYMENTTYPE = (PaymentTypeCashCCEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].ConvertValue(parameters["PAYMENTTYPE"]);
            if (parameters.ContainsKey("PAYMENTTYPECONTROL"))
                _runtimeParameters.PAYMENTTYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYMENTTYPECONTROL"]);
            if (parameters.ContainsKey("CASHOFFICECONTROL"))
                _runtimeParameters.CASHOFFICECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CASHOFFICECONTROL"]);
            if (parameters.ContainsKey("CASHIERCONTROL"))
                _runtimeParameters.CASHIERCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CASHIERCONTROL"]);
            Name = "CASHOFFICEREPORT";
            Caption = "Vezne Raporu";
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