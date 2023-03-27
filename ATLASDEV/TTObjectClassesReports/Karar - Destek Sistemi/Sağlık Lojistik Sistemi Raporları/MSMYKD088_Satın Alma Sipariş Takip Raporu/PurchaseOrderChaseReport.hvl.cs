
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
    /// Satın Alma Sipariş Takip Raporu
    /// </summary>
    public partial class PurchaseOrderChaseReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public long? ORDERNO = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue("0");
            public Guid? PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? SUPPLIERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PurchaseOrderChaseReport MyParentReport
            {
                get { return (PurchaseOrderChaseReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public TTReportField LOGO12 { get {return Header().LOGO12;} }
            public TTReportField LOGO13 { get {return Header().LOGO13;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public PurchaseOrderChaseReport MyParentReport
                {
                    get { return (PurchaseOrderChaseReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField REPORTNAME;
                public TTReportField LOGO1;
                public TTReportField LOGO11;
                public TTReportField LOGO12;
                public TTReportField LOGO13;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 10, 65, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 10, 282, 30, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"SATIN ALMA SİPARİŞ TAKİP RAPORU";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 35, 54, 40, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.TextFont.Name = "Arial";
                    LOGO1.TextFont.Bold = true;
                    LOGO1.TextFont.CharSet = 162;
                    LOGO1.Value = @"Başlangıç Tarihi";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 40, 54, 45, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO11.TextFont.Name = "Arial";
                    LOGO11.TextFont.Bold = true;
                    LOGO11.TextFont.CharSet = 162;
                    LOGO11.Value = @"Bitiş Tarihi";

                    LOGO12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 35, 56, 40, false);
                    LOGO12.Name = "LOGO12";
                    LOGO12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO12.TextFont.Name = "Arial";
                    LOGO12.TextFont.Bold = true;
                    LOGO12.TextFont.CharSet = 162;
                    LOGO12.Value = @":";

                    LOGO13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 40, 56, 45, false);
                    LOGO13.Name = "LOGO13";
                    LOGO13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO13.TextFont.Name = "Arial";
                    LOGO13.TextFont.Bold = true;
                    LOGO13.TextFont.CharSet = 162;
                    LOGO13.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 35, 85, 40, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.NoClip = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 40, 85, 45, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.NoClip = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    LOGO11.CalcValue = LOGO11.Value;
                    LOGO12.CalcValue = LOGO12.Value;
                    LOGO13.CalcValue = LOGO13.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { LOGO,REPORTNAME,LOGO1,LOGO11,LOGO12,LOGO13,STARTDATE,ENDDATE};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PurchaseOrderChaseReport MyParentReport
                {
                    get { return (PurchaseOrderChaseReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 162, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 282, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 50, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 0, 282, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public PurchaseOrderChaseReport MyParentReport
            {
                get { return (PurchaseOrderChaseReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField LOGO11411 { get {return Header().LOGO11411;} }
            public TTReportField LOGO11211 { get {return Header().LOGO11211;} }
            public TTReportField LOGO111411 { get {return Header().LOGO111411;} }
            public TTReportField LOGO111211 { get {return Header().LOGO111211;} }
            public TTReportField LOGO111421 { get {return Header().LOGO111421;} }
            public TTReportField LOGO111221 { get {return Header().LOGO111221;} }
            public TTReportField LOGO111431 { get {return Header().LOGO111431;} }
            public TTReportField LOGO111231 { get {return Header().LOGO111231;} }
            public TTReportField LOGO111441 { get {return Header().LOGO111441;} }
            public TTReportField LOGO111241 { get {return Header().LOGO111241;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField LOGO1144111 { get {return Header().LOGO1144111;} }
            public TTReportField LOGO1144121 { get {return Header().LOGO1144121;} }
            public TTReportField LOGO1144131 { get {return Header().LOGO1144131;} }
            public TTReportField LOGO1144141 { get {return Header().LOGO1144141;} }
            public TTReportField LOGO1144151 { get {return Header().LOGO1144151;} }
            public TTReportField LOGO1144161 { get {return Header().LOGO1144161;} }
            public TTReportField LOGO1144171 { get {return Header().LOGO1144171;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField LOGO111451 { get {return Header().LOGO111451;} }
            public TTReportField LOGO111251 { get {return Header().LOGO111251;} }
            public TTReportField LOGO111461 { get {return Header().LOGO111461;} }
            public TTReportField LOGO111261 { get {return Header().LOGO111261;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField PROJECTNO { get {return Header().PROJECTNO;} }
            public TTReportField ORDERDATE { get {return Header().ORDERDATE;} }
            public TTReportField DUEDATE { get {return Header().DUEDATE;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField ORDEREDPRICE { get {return Header().ORDEREDPRICE;} }
            public TTReportField TOTALCONTRACTPRICE { get {return Header().TOTALCONTRACTPRICE;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class>("GetPurchaseOrderChaseReportQuery", PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(long)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(MyParentReport.RuntimeParameters.ORDERNO),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PROJECTNO),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SUPPLIERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public PurchaseOrderChaseReport MyParentReport
                {
                    get { return (PurchaseOrderChaseReport)ParentReport; }
                }
                
                public TTReportField LOGO11411;
                public TTReportField LOGO11211;
                public TTReportField LOGO111411;
                public TTReportField LOGO111211;
                public TTReportField LOGO111421;
                public TTReportField LOGO111221;
                public TTReportField LOGO111431;
                public TTReportField LOGO111231;
                public TTReportField LOGO111441;
                public TTReportField LOGO111241;
                public TTReportShape NewLine1111;
                public TTReportField LOGO1144111;
                public TTReportField LOGO1144121;
                public TTReportField LOGO1144131;
                public TTReportField LOGO1144141;
                public TTReportField LOGO1144151;
                public TTReportField LOGO1144161;
                public TTReportField LOGO1144171;
                public TTReportShape NewLine11111;
                public TTReportField LOGO111451;
                public TTReportField LOGO111251;
                public TTReportField LOGO111461;
                public TTReportField LOGO111261;
                public TTReportField ORDERNO;
                public TTReportField PROJECTNO;
                public TTReportField ORDERDATE;
                public TTReportField DUEDATE;
                public TTReportField SUPPLIER;
                public TTReportField ORDEREDPRICE;
                public TTReportField TOTALCONTRACTPRICE;
                public TTReportShape NewLine111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 7, 54, 12, false);
                    LOGO11411.Name = "LOGO11411";
                    LOGO11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO11411.TextFont.Name = "Arial";
                    LOGO11411.TextFont.Bold = true;
                    LOGO11411.TextFont.CharSet = 162;
                    LOGO11411.Value = @"Proje Numarası";

                    LOGO11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 7, 56, 12, false);
                    LOGO11211.Name = "LOGO11211";
                    LOGO11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO11211.TextFont.Name = "Arial";
                    LOGO11211.TextFont.Bold = true;
                    LOGO11211.TextFont.CharSet = 162;
                    LOGO11211.Value = @":";

                    LOGO111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 2, 54, 7, false);
                    LOGO111411.Name = "LOGO111411";
                    LOGO111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111411.TextFont.Name = "Arial";
                    LOGO111411.TextFont.Bold = true;
                    LOGO111411.TextFont.CharSet = 162;
                    LOGO111411.Value = @"Sipariş Numarası";

                    LOGO111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 2, 56, 7, false);
                    LOGO111211.Name = "LOGO111211";
                    LOGO111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111211.TextFont.Name = "Arial";
                    LOGO111211.TextFont.Bold = true;
                    LOGO111211.TextFont.CharSet = 162;
                    LOGO111211.Value = @":";

                    LOGO111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 2, 171, 7, false);
                    LOGO111421.Name = "LOGO111421";
                    LOGO111421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111421.TextFont.Name = "Arial";
                    LOGO111421.TextFont.Bold = true;
                    LOGO111421.TextFont.CharSet = 162;
                    LOGO111421.Value = @"Tedarikçi Adı";

                    LOGO111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 2, 173, 7, false);
                    LOGO111221.Name = "LOGO111221";
                    LOGO111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111221.TextFont.Name = "Arial";
                    LOGO111221.TextFont.Bold = true;
                    LOGO111221.TextFont.CharSet = 162;
                    LOGO111221.Value = @":";

                    LOGO111431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 7, 171, 12, false);
                    LOGO111431.Name = "LOGO111431";
                    LOGO111431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111431.TextFont.Name = "Arial";
                    LOGO111431.TextFont.Bold = true;
                    LOGO111431.TextFont.CharSet = 162;
                    LOGO111431.Value = @"Sipariş Tutarı";

                    LOGO111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 7, 173, 12, false);
                    LOGO111231.Name = "LOGO111231";
                    LOGO111231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO111231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111231.TextFont.Name = "Arial";
                    LOGO111231.TextFont.Bold = true;
                    LOGO111231.TextFont.CharSet = 162;
                    LOGO111231.Value = @":";

                    LOGO111441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 12, 171, 17, false);
                    LOGO111441.Name = "LOGO111441";
                    LOGO111441.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111441.TextFont.Name = "Arial";
                    LOGO111441.TextFont.Bold = true;
                    LOGO111441.TextFont.CharSet = 162;
                    LOGO111441.Value = @"Toplam Tutar";

                    LOGO111241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 12, 173, 17, false);
                    LOGO111241.Name = "LOGO111241";
                    LOGO111241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO111241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111241.TextFont.Name = "Arial";
                    LOGO111241.TextFont.Bold = true;
                    LOGO111241.TextFont.CharSet = 162;
                    LOGO111241.Value = @":";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 23, 282, 23, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    LOGO1144111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 24, 102, 29, false);
                    LOGO1144111.Name = "LOGO1144111";
                    LOGO1144111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144111.TextFont.Name = "Arial";
                    LOGO1144111.TextFont.Bold = true;
                    LOGO1144111.TextFont.CharSet = 162;
                    LOGO1144111.Value = @"Malzeme Adı";

                    LOGO1144121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 24, 132, 29, false);
                    LOGO1144121.Name = "LOGO1144121";
                    LOGO1144121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144121.TextFont.Name = "Arial";
                    LOGO1144121.TextFont.Bold = true;
                    LOGO1144121.TextFont.CharSet = 162;
                    LOGO1144121.Value = @"Karar Miktarı";

                    LOGO1144131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 24, 162, 29, false);
                    LOGO1144131.Name = "LOGO1144131";
                    LOGO1144131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144131.TextFont.Name = "Arial";
                    LOGO1144131.TextFont.Bold = true;
                    LOGO1144131.TextFont.CharSet = 162;
                    LOGO1144131.Value = @"Karar Tutarı";

                    LOGO1144141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 24, 192, 29, false);
                    LOGO1144141.Name = "LOGO1144141";
                    LOGO1144141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144141.TextFont.Name = "Arial";
                    LOGO1144141.TextFont.Bold = true;
                    LOGO1144141.TextFont.CharSet = 162;
                    LOGO1144141.Value = @"Kalan Miktar";

                    LOGO1144151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 24, 222, 29, false);
                    LOGO1144151.Name = "LOGO1144151";
                    LOGO1144151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144151.TextFont.Name = "Arial";
                    LOGO1144151.TextFont.Bold = true;
                    LOGO1144151.TextFont.CharSet = 162;
                    LOGO1144151.Value = @"Sipariş Miktarı";

                    LOGO1144161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 24, 252, 29, false);
                    LOGO1144161.Name = "LOGO1144161";
                    LOGO1144161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144161.TextFont.Name = "Arial";
                    LOGO1144161.TextFont.Bold = true;
                    LOGO1144161.TextFont.CharSet = 162;
                    LOGO1144161.Value = @"Birim Fiyatı";

                    LOGO1144171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 24, 282, 29, false);
                    LOGO1144171.Name = "LOGO1144171";
                    LOGO1144171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1144171.TextFont.Name = "Arial";
                    LOGO1144171.TextFont.Bold = true;
                    LOGO1144171.TextFont.CharSet = 162;
                    LOGO1144171.Value = @"Toplam Tutar";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 30, 282, 30, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    LOGO111451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 12, 54, 17, false);
                    LOGO111451.Name = "LOGO111451";
                    LOGO111451.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111451.TextFont.Name = "Arial";
                    LOGO111451.TextFont.Bold = true;
                    LOGO111451.TextFont.CharSet = 162;
                    LOGO111451.Value = @"Sipariş Tarihi";

                    LOGO111251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 12, 56, 17, false);
                    LOGO111251.Name = "LOGO111251";
                    LOGO111251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO111251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111251.TextFont.Name = "Arial";
                    LOGO111251.TextFont.Bold = true;
                    LOGO111251.TextFont.CharSet = 162;
                    LOGO111251.Value = @":";

                    LOGO111461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 17, 85, 22, false);
                    LOGO111461.Name = "LOGO111461";
                    LOGO111461.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111461.TextFont.Name = "Arial";
                    LOGO111461.TextFont.Bold = true;
                    LOGO111461.TextFont.CharSet = 162;
                    LOGO111461.Value = @"Depoya Teslim Edileceği Son Tarih";

                    LOGO111261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 17, 87, 22, false);
                    LOGO111261.Name = "LOGO111261";
                    LOGO111261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO111261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO111261.TextFont.Name = "Arial";
                    LOGO111261.TextFont.Bold = true;
                    LOGO111261.TextFont.CharSet = 162;
                    LOGO111261.Value = @":";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 2, 133, 7, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 7, 133, 12, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"{#PURCHASEPROJECTNO#}";

                    ORDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 12, 133, 17, false);
                    ORDERDATE.Name = "ORDERDATE";
                    ORDERDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDATE.TextFormat = @"dd/MM/yyyy";
                    ORDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERDATE.TextFont.Name = "Arial";
                    ORDERDATE.TextFont.CharSet = 162;
                    ORDERDATE.Value = @"{#ORDERDATE#}";

                    DUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 17, 133, 22, false);
                    DUEDATE.Name = "DUEDATE";
                    DUEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUEDATE.TextFormat = @"dd/MM/yyyy";
                    DUEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DUEDATE.TextFont.Name = "Arial";
                    DUEDATE.TextFont.CharSet = 162;
                    DUEDATE.Value = @"{#DUEDATE#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 2, 282, 7, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.CharSet = 162;
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    ORDEREDPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 7, 282, 12, false);
                    ORDEREDPRICE.Name = "ORDEREDPRICE";
                    ORDEREDPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEREDPRICE.TextFormat = @"#,##0.#0";
                    ORDEREDPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDEREDPRICE.TextFont.Name = "Arial";
                    ORDEREDPRICE.TextFont.CharSet = 162;
                    ORDEREDPRICE.Value = @"{#ORDEREDPRICE#}";

                    TOTALCONTRACTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 12, 282, 17, false);
                    TOTALCONTRACTPRICE.Name = "TOTALCONTRACTPRICE";
                    TOTALCONTRACTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCONTRACTPRICE.TextFormat = @"#,##0.#0";
                    TOTALCONTRACTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCONTRACTPRICE.TextFont.Name = "Arial";
                    TOTALCONTRACTPRICE.TextFont.CharSet = 162;
                    TOTALCONTRACTPRICE.Value = @"{#TOTALCONTRACTVALUE#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 1, 282, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class dataset_GetPurchaseOrderChaseReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class>(0);
                    LOGO11411.CalcValue = LOGO11411.Value;
                    LOGO11211.CalcValue = LOGO11211.Value;
                    LOGO111411.CalcValue = LOGO111411.Value;
                    LOGO111211.CalcValue = LOGO111211.Value;
                    LOGO111421.CalcValue = LOGO111421.Value;
                    LOGO111221.CalcValue = LOGO111221.Value;
                    LOGO111431.CalcValue = LOGO111431.Value;
                    LOGO111231.CalcValue = LOGO111231.Value;
                    LOGO111441.CalcValue = LOGO111441.Value;
                    LOGO111241.CalcValue = LOGO111241.Value;
                    LOGO1144111.CalcValue = LOGO1144111.Value;
                    LOGO1144121.CalcValue = LOGO1144121.Value;
                    LOGO1144131.CalcValue = LOGO1144131.Value;
                    LOGO1144141.CalcValue = LOGO1144141.Value;
                    LOGO1144151.CalcValue = LOGO1144151.Value;
                    LOGO1144161.CalcValue = LOGO1144161.Value;
                    LOGO1144171.CalcValue = LOGO1144171.Value;
                    LOGO111451.CalcValue = LOGO111451.Value;
                    LOGO111251.CalcValue = LOGO111251.Value;
                    LOGO111461.CalcValue = LOGO111461.Value;
                    LOGO111261.CalcValue = LOGO111261.Value;
                    ORDERNO.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.OrderNO) : "");
                    PROJECTNO.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.PurchaseProjectNO) : "");
                    ORDERDATE.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.OrderDate) : "");
                    DUEDATE.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.DueDate) : "");
                    SUPPLIER.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.Supplier) : "");
                    ORDEREDPRICE.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.OrderedPrice) : "");
                    TOTALCONTRACTPRICE.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.TotalContractValue) : "");
                    return new TTReportObject[] { LOGO11411,LOGO11211,LOGO111411,LOGO111211,LOGO111421,LOGO111221,LOGO111431,LOGO111231,LOGO111441,LOGO111241,LOGO1144111,LOGO1144121,LOGO1144131,LOGO1144141,LOGO1144151,LOGO1144161,LOGO1144171,LOGO111451,LOGO111251,LOGO111461,LOGO111261,ORDERNO,PROJECTNO,ORDERDATE,DUEDATE,SUPPLIER,ORDEREDPRICE,TOTALCONTRACTPRICE};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PurchaseOrderChaseReport MyParentReport
                {
                    get { return (PurchaseOrderChaseReport)ParentReport; }
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

        public partial class MAINGroup : TTReportGroup
        {
            public PurchaseOrderChaseReport MyParentReport
            {
                get { return (PurchaseOrderChaseReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField TOTALAMOUNT { get {return Body().TOTALAMOUNT;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField RESTAMOUNT { get {return Body().RESTAMOUNT;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
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

                PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class dataSet_GetPurchaseOrderChaseReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class>(0);    
                return new object[] {(dataSet_GetPurchaseOrderChaseReportQuery==null ? null : dataSet_GetPurchaseOrderChaseReportQuery.PurchaseProjectNO)};
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
                public PurchaseOrderChaseReport MyParentReport
                {
                    get { return (PurchaseOrderChaseReport)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField TOTALAMOUNT;
                public TTReportField TOTALPRICE;
                public TTReportField RESTAMOUNT;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField TOTAL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 102, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#PARTB.ITEMNAME#}";

                    TOTALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 132, 6, false);
                    TOTALAMOUNT.Name = "TOTALAMOUNT";
                    TOTALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT.TextFormat = @"#,###";
                    TOTALAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALAMOUNT.TextFont.Name = "Arial";
                    TOTALAMOUNT.TextFont.CharSet = 162;
                    TOTALAMOUNT.Value = @"{#PARTB.TOTALAMOUNT#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 162, 6, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{#PARTB.TOTALPRICE#}";

                    RESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 1, 192, 6, false);
                    RESTAMOUNT.Name = "RESTAMOUNT";
                    RESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESTAMOUNT.TextFormat = @"#,###";
                    RESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESTAMOUNT.TextFont.Name = "Arial";
                    RESTAMOUNT.TextFont.CharSet = 162;
                    RESTAMOUNT.Value = @"{#PARTB.RESTAMOUNT#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 1, 222, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PARTB.AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 1, 252, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#PARTB.UNITPRICE#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 1, 282, 6, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"{#PARTB.TOTAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class dataset_GetPurchaseOrderChaseReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.ItemName) : "");
                    TOTALAMOUNT.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.Totalamount) : "");
                    TOTALPRICE.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.Totalprice) : "");
                    RESTAMOUNT.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.RestAmount) : "");
                    AMOUNT.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.UnitPrice) : "");
                    TOTAL.CalcValue = (dataset_GetPurchaseOrderChaseReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseOrderChaseReportQuery.Total) : "");
                    return new TTReportObject[] { MATERIALNAME,TOTALAMOUNT,TOTALPRICE,RESTAMOUNT,AMOUNT,UNITPRICE,TOTAL};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PurchaseOrderChaseReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", false, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", false, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ORDERNO", "0", "Sipariş Numarasını Giriniz", @"", true, true, false, new Guid("c573f560-55ee-4514-8ef8-380110697129"));
            reportParameter = Parameters.Add("PROJECTNO", "00000000-0000-0000-0000-000000000000", "Proje Numarasını Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
            reportParameter = Parameters.Add("SUPPLIERID", "00000000-0000-0000-0000-000000000000", "Tedarikçi Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("41069fdc-2950-40b8-a40e-072e0d8d670b");
            reportParameter = Parameters.Add("MATERIALID", "00000000-0000-0000-0000-000000000000", "Malzeme Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("6edc2ba6-9aee-410a-9fc2-326f1be669c8");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("ORDERNO"))
                _runtimeParameters.ORDERNO = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(parameters["ORDERNO"]);
            if (parameters.ContainsKey("PROJECTNO"))
                _runtimeParameters.PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PROJECTNO"]);
            if (parameters.ContainsKey("SUPPLIERID"))
                _runtimeParameters.SUPPLIERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SUPPLIERID"]);
            if (parameters.ContainsKey("MATERIALID"))
                _runtimeParameters.MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIALID"]);
            Name = "PURCHASEORDERCHASEREPORT";
            Caption = "Satın Alma Sipariş Takip Raporu";
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