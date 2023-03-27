
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
    /// Muhasebe Yetkilisi Mutemetliği Kapamaları Raporu
    /// </summary>
    public partial class CashOfficeClosingsByDate : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CashOfficeClosingsByDate MyParentReport
            {
                get { return (CashOfficeClosingsByDate)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public CashOfficeClosingsByDate MyParentReport
                {
                    get { return (CashOfficeClosingsByDate)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 3, 51, 8, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 3, 79, 8, false);
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
#region PARTB HEADER_Script
                    ((CashOfficeClosingsByDate)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((CashOfficeClosingsByDate)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CashOfficeClosingsByDate MyParentReport
                {
                    get { return (CashOfficeClosingsByDate)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public CashOfficeClosingsByDate MyParentReport
            {
                get { return (CashOfficeClosingsByDate)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField1201 { get {return Header().NewField1201;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public CashOfficeClosingsByDate MyParentReport
                {
                    get { return (CashOfficeClosingsByDate)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField STARTDATE;
                public TTReportField NewField1121;
                public TTReportField ENDDATE;
                public TTReportField NewField16;
                public TTReportField NewField181;
                public TTReportField NewField102;
                public TTReportField NewField18;
                public TTReportField NewField17;
                public TTReportShape NewLine111;
                public TTReportField NewField11221;
                public TTReportField NewField112211;
                public TTReportField NewField171;
                public TTReportField NewField1201; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 266, 15, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MUHASEBE YETKİLİSİ MUTEMETLİĞİ KAPAMALARI RAPORU";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 17, 35, 22, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 17, 91, 22, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 23, 35, 28, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 23, 91, 28, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 29, 23, 33, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Sıra No";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 29, 156, 33, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Mutemetlik Adı";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 29, 241, 33, false);
                    NewField102.Name = "NewField102";
                    NewField102.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"Nakit";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 29, 46, 33, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"Kapama Tarihi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 29, 216, 33, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Mutemet Adı Soyadı";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 34, 266, 34, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 23, 37, 28, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 17, 37, 22, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 29, 76, 33, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"İşlem No";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 29, 266, 33, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1201.TextFont.Bold = true;
                    NewField1201.TextFont.CharSet = 162;
                    NewField1201.Value = @"Kredi Kartı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1121.CalcValue = NewField1121.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField16.CalcValue = NewField16.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    return new TTReportObject[] { NewField111,NewField121,STARTDATE,NewField1121,ENDDATE,NewField16,NewField181,NewField102,NewField18,NewField17,NewField11221,NewField112211,NewField171,NewField1201};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CashOfficeClosingsByDate MyParentReport
                {
                    get { return (CashOfficeClosingsByDate)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 266, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 2, 191, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 2, 266, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 43, 7, false);
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

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CashOfficeClosingsByDate MyParentReport
            {
                get { return (CashOfficeClosingsByDate)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CASHOFFICE { get {return Body().CASHOFFICE;} }
            public TTReportField CASH { get {return Body().CASH;} }
            public TTReportField SIRANO1 { get {return Body().SIRANO1;} }
            public TTReportField CLOSINGDATE { get {return Body().CLOSINGDATE;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField CASHIER { get {return Body().CASHIER;} }
            public TTReportField CREDITCARD { get {return Body().CREDITCARD;} }
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
                list[0] = new TTReportNqlData<CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class>("GetSubCashOfficeClosingsByDate", CashOfficeClosing.GetSubCashOfficeClosingsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CashOfficeClosingsByDate MyParentReport
                {
                    get { return (CashOfficeClosingsByDate)ParentReport; }
                }
                
                public TTReportField CASHOFFICE;
                public TTReportField CASH;
                public TTReportField SIRANO1;
                public TTReportField CLOSINGDATE;
                public TTReportField ACTIONID;
                public TTReportField CASHIER;
                public TTReportField CREDITCARD; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 0, 156, 5, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.MultiLine = EvetHayirEnum.ehEvet;
                    CASHOFFICE.NoClip = EvetHayirEnum.ehEvet;
                    CASHOFFICE.WordBreak = EvetHayirEnum.ehEvet;
                    CASHOFFICE.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHOFFICE.TextFont.CharSet = 162;
                    CASHOFFICE.Value = @"{#CASHOFFICE#}";

                    CASH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 241, 5, false);
                    CASH.Name = "CASH";
                    CASH.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASH.TextFormat = @"#,##0.#0";
                    CASH.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CASH.TextFont.CharSet = 162;
                    CASH.Value = @"{#CASHREVENUETOTAL#}";

                    SIRANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 23, 5, false);
                    SIRANO1.Name = "SIRANO1";
                    SIRANO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO1.TextFont.CharSet = 162;
                    SIRANO1.Value = @"{@groupcounter@}";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 46, 5, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"Short Date";
                    CLOSINGDATE.TextFont.CharSet = 162;
                    CLOSINGDATE.Value = @"{#CLOSINGDATE#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 76, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 216, 5, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIER#}";

                    CREDITCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 266, 5, false);
                    CREDITCARD.Name = "CREDITCARD";
                    CREDITCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    CREDITCARD.TextFormat = @"#,##0.#0";
                    CREDITCARD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CREDITCARD.TextFont.CharSet = 162;
                    CREDITCARD.Value = @"{#CREDITCARDREVENUETOTAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class dataset_GetSubCashOfficeClosingsByDate = ParentGroup.rsGroup.GetCurrentRecord<CashOfficeClosing.GetSubCashOfficeClosingsByDate_Class>(0);
                    CASHOFFICE.CalcValue = (dataset_GetSubCashOfficeClosingsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeClosingsByDate.Cashoffice) : "");
                    CASH.CalcValue = (dataset_GetSubCashOfficeClosingsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeClosingsByDate.CashRevenueTotal) : "");
                    SIRANO1.CalcValue = ParentGroup.GroupCounter.ToString();
                    CLOSINGDATE.CalcValue = (dataset_GetSubCashOfficeClosingsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeClosingsByDate.ClosingDate) : "");
                    ACTIONID.CalcValue = (dataset_GetSubCashOfficeClosingsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeClosingsByDate.Actionid) : "");
                    CASHIER.CalcValue = (dataset_GetSubCashOfficeClosingsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeClosingsByDate.Cashier) : "");
                    CREDITCARD.CalcValue = (dataset_GetSubCashOfficeClosingsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeClosingsByDate.CreditCardRevenueTotal) : "");
                    return new TTReportObject[] { CASHOFFICE,CASH,SIRANO1,CLOSINGDATE,ACTIONID,CASHIER,CREDITCARD};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CashOfficeClosingsByDate()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "CASHOFFICECLOSINGSBYDATE";
            Caption = "Muhasebe Yetkilisi Mutemetliği Kapamaları Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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