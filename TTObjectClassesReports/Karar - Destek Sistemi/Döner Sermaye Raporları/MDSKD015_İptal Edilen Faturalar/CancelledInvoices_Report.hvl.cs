
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
    /// İptal Edilen Faturalar
    /// </summary>
    public partial class CancelledInvoices : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CancelledInvoices MyParentReport
            {
                get { return (CancelledInvoices)ParentReport; }
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
                public CancelledInvoices MyParentReport
                {
                    get { return (CancelledInvoices)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 28, 8, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 3, 55, 8, false);
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
                    ((CancelledInvoices)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((CancelledInvoices)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CancelledInvoices MyParentReport
                {
                    get { return (CancelledInvoices)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public CancelledInvoices MyParentReport
            {
                get { return (CancelledInvoices)ParentReport; }
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
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField111121111 { get {return Header().NewField111121111;} }
            public TTReportField NewField111121112 { get {return Header().NewField111121112;} }
            public TTReportField NewField1211121111 { get {return Header().NewField1211121111;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public CancelledInvoices MyParentReport
                {
                    get { return (CancelledInvoices)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField STARTDATE;
                public TTReportField NewField12;
                public TTReportField ENDDATE;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField1112111;
                public TTReportField NewField11112111;
                public TTReportField NewField111121111;
                public TTReportField NewField111121112;
                public TTReportField NewField1211121111;
                public TTReportField NewField3;
                public TTReportShape NewLine1;
                public TTReportField NewField122;
                public TTReportField NewField1221;
                public TTReportField NewField7;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 6, 186, 26, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İPTAL EDİLEN FATURALAR";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 31, 33, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 28, 86, 33, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 31, 39, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 34, 86, 39, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 40, 19, 44, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sıra No";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 40, 142, 44, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Fatura No";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 40, 161, 44, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Fatura Tarihi";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 40, 184, 44, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Fatura Tutarı";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 40, 37, 44, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Hasta No";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 40, 79, 44, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"Hasta Adı Soyadı";

                    NewField111121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 40, 101, 44, false);
                    NewField111121112.Name = "NewField111121112";
                    NewField111121112.TextFont.Bold = true;
                    NewField111121112.TextFont.CharSet = 162;
                    NewField111121112.Value = @"H.Protokol No";

                    NewField1211121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 40, 254, 44, false);
                    NewField1211121111.Name = "NewField1211121111";
                    NewField1211121111.TextFont.Bold = true;
                    NewField1211121111.TextFont.CharSet = 162;
                    NewField1211121111.Value = @"Kurum";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 40, 296, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İptal Eden";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 45, 296, 45, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 34, 33, 39, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @":";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 28, 33, 33, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 40, 121, 44, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"İşlem No";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 48, 26, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField12.CalcValue = NewField12.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField111121112.CalcValue = NewField111121112.Value;
                    NewField1211121111.CalcValue = NewField1211121111.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField7.CalcValue = NewField7.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField1,NewField2,STARTDATE,NewField12,ENDDATE,NewField121,NewField1121,NewField11211,NewField1112111,NewField11112111,NewField111121111,NewField111121112,NewField1211121111,NewField3,NewField122,NewField1221,NewField7,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CancelledInvoices MyParentReport
                {
                    get { return (CancelledInvoices)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 296, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 2, 186, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 2, 296, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 39, 7, false);
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
            public CancelledInvoices MyParentReport
            {
                get { return (CancelledInvoices)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField FATURANO { get {return Body().FATURANO;} }
            public TTReportField FATURATARIH { get {return Body().FATURATARIH;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField IPTALEDEN { get {return Body().IPTALEDEN;} }
            public TTReportField ISLEMNO { get {return Body().ISLEMNO;} }
            public TTReportField INVOICETYPE { get {return Body().INVOICETYPE;} }
            public TTReportField ACTIONGUID { get {return Body().ACTIONGUID;} }
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
                list[0] = new TTReportNqlData<AccountDocument.GetCancelledInvoices_Class>("GetCancelledInvoices", AccountDocument.GetCancelledInvoices((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CancelledInvoices MyParentReport
                {
                    get { return (CancelledInvoices)ParentReport; }
                }
                
                public TTReportField HASTANO;
                public TTReportField HASTAADI;
                public TTReportField TUTAR;
                public TTReportField SIRANO;
                public TTReportField PROTOKOLNO;
                public TTReportField FATURANO;
                public TTReportField FATURATARIH;
                public TTReportField KURUM;
                public TTReportField IPTALEDEN;
                public TTReportField ISLEMNO;
                public TTReportField INVOICETYPE;
                public TTReportField ACTIONGUID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 37, 5, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{#PATIENTID#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 79, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 184, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#PRICE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 19, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 101, 5, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 142, 5, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#DOCUMENTNO#}";

                    FATURATARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 161, 5, false);
                    FATURATARIH.Name = "FATURATARIH";
                    FATURATARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIH.TextFormat = @"Short Date";
                    FATURATARIH.TextFont.CharSet = 162;
                    FATURATARIH.Value = @"{#DOCUMENTDATE#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 254, 5, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#PAYERNAME#}";

                    IPTALEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 0, 296, 5, false);
                    IPTALEDEN.Name = "IPTALEDEN";
                    IPTALEDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    IPTALEDEN.CaseFormat = CaseFormatEnum.fcUpperCase;
                    IPTALEDEN.MultiLine = EvetHayirEnum.ehEvet;
                    IPTALEDEN.NoClip = EvetHayirEnum.ehEvet;
                    IPTALEDEN.WordBreak = EvetHayirEnum.ehEvet;
                    IPTALEDEN.ExpandTabs = EvetHayirEnum.ehEvet;
                    IPTALEDEN.TextFont.CharSet = 162;
                    IPTALEDEN.Value = @"";

                    ISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 0, 121, 5, false);
                    ISLEMNO.Name = "ISLEMNO";
                    ISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMNO.TextFont.CharSet = 162;
                    ISLEMNO.Value = @"{#ACTIONID#}";

                    INVOICETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 327, 5, false);
                    INVOICETYPE.Name = "INVOICETYPE";
                    INVOICETYPE.Visible = EvetHayirEnum.ehHayir;
                    INVOICETYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICETYPE.TextFont.CharSet = 162;
                    INVOICETYPE.Value = @"{#INVOICETYPE#}";

                    ACTIONGUID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 330, 0, 350, 5, false);
                    ACTIONGUID.Name = "ACTIONGUID";
                    ACTIONGUID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONGUID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONGUID.TextFont.CharSet = 162;
                    ACTIONGUID.Value = @"{#ACTIONGUID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetCancelledInvoices_Class dataset_GetCancelledInvoices = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetCancelledInvoices_Class>(0);
                    HASTANO.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Patientid) : "");
                    HASTAADI.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Patientname) : "") + @" " + (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Patientsurname) : "");
                    TUTAR.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Price) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    PROTOKOLNO.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.HospitalProtocolNo) : "");
                    FATURANO.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.DocumentNo) : "");
                    FATURATARIH.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.DocumentDate) : "");
                    KURUM.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Payername) : "");
                    IPTALEDEN.CalcValue = @"";
                    ISLEMNO.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Actionid) : "");
                    INVOICETYPE.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Invoicetype) : "");
                    ACTIONGUID.CalcValue = (dataset_GetCancelledInvoices != null ? Globals.ToStringCore(dataset_GetCancelledInvoices.Actionguid) : "");
                    return new TTReportObject[] { HASTANO,HASTAADI,TUTAR,SIRANO,PROTOKOLNO,FATURANO,FATURATARIH,KURUM,IPTALEDEN,ISLEMNO,INVOICETYPE,ACTIONGUID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.HASTANO.CalcValue == "0")
                this.HASTANO.CalcValue = " ";
            
            if (this.PROTOKOLNO.CalcValue == "0")
                this.PROTOKOLNO.CalcValue = " ";
            
            ResUser resUser = null;
            TTObjectContext objectContext = new TTObjectContext(true);
            
            if (this.ACTIONGUID.CalcValue != "")
            {
                if (this.INVOICETYPE.CalcValue == "HASTA")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    PatientInvoice Inv = (PatientInvoice)objectContext.GetObject(new Guid(ObjectId),"PatientInvoice");
                    
                    foreach(TTObjectState objectState in Inv.GetStateHistory())
                    {
                        if(objectState.StateDefID == PatientInvoice.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                }
                else if (this.INVOICETYPE.CalcValue == "KURUM")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    PayerInvoice Inv = (PayerInvoice)objectContext.GetObject(new Guid(ObjectId),"PayerInvoice");
                    
                    foreach(TTObjectState objectState in Inv.GetStateHistory())
                    {
                        if(objectState.StateDefID == PayerInvoice.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                }
                else if (this.INVOICETYPE.CalcValue == "TOPLU")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    CollectedInvoice Inv = (CollectedInvoice)objectContext.GetObject(new Guid(ObjectId),"CollectedInvoice");
                    
                    foreach(TTObjectState objectState in Inv.GetStateHistory())
                    {
                        if(objectState.StateDefID == CollectedInvoice.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                }
                else if (this.INVOICETYPE.CalcValue == "GENEL")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    GeneralInvoice Inv = (GeneralInvoice)objectContext.GetObject(new Guid(ObjectId),"GeneralInvoice");
                    
                    foreach(TTObjectState objectState in Inv.GetStateHistory())
                    {
                        if(objectState.StateDefID == GeneralInvoice.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                }
            }
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

        public CancelledInvoices()
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
            Name = "CANCELLEDINVOICES";
            Caption = "İptal Edilen Faturalar";
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