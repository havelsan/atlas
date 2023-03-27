
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
    /// İptal Edilen Makbuzlar
    /// </summary>
    public partial class CancelledReceipts : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CancelledReceipts MyParentReport
            {
                get { return (CancelledReceipts)ParentReport; }
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
                public CancelledReceipts MyParentReport
                {
                    get { return (CancelledReceipts)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 28, 10, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 5, 55, 10, false);
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
                    ((CancelledReceipts)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((CancelledReceipts)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CancelledReceipts MyParentReport
                {
                    get { return (CancelledReceipts)ParentReport; }
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
            public CancelledReceipts MyParentReport
            {
                get { return (CancelledReceipts)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public CancelledReceipts MyParentReport
                {
                    get { return (CancelledReceipts)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField STARTDATE;
                public TTReportField NewField121;
                public TTReportField ENDDATE;
                public TTReportField NewField6;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField8;
                public TTReportField NewField7;
                public TTReportField NewField9;
                public TTReportShape NewLine11;
                public TTReportField NewField1221;
                public TTReportField NewField11221;
                public TTReportField NewField17;
                public TTReportField NewField22;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 6, 237, 26, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İPTAL EDİLEN MUHASEBE YETKİLİSİ MUTEMEDİ / KREDİ KARTI / VEZNE ALINDILARI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 31, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 28, 86, 33, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 31, 39, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 34, 86, 39, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 40, 19, 44, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Sıra No";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 40, 191, 44, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"No";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 40, 215, 44, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Tarih";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 40, 240, 44, false);
                    NewField20.Name = "NewField20";
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"Tutar";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 40, 42, 44, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Hasta No";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 40, 119, 44, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Hasta Adı Soyadı";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 40, 146, 44, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"H.Protokol No";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 45, 296, 45, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 34, 33, 39, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 28, 33, 33, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 40, 168, 44, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"İşlem No";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 40, 296, 44, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Bold = true;
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @"İptal Eden";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 48, 26, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField121.CalcValue = NewField121.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField6.CalcValue = NewField6.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField22.CalcValue = NewField22.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField11,NewField12,STARTDATE,NewField121,ENDDATE,NewField6,NewField18,NewField19,NewField20,NewField8,NewField7,NewField9,NewField1221,NewField11221,NewField17,NewField22,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CancelledReceipts MyParentReport
                {
                    get { return (CancelledReceipts)ParentReport; }
                }
                
                public TTReportShape NewLine111;
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
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 296, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 2, 187, 7, false);
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
            public CancelledReceipts MyParentReport
            {
                get { return (CancelledReceipts)ParentReport; }
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
            public TTReportField MAKBUZNO { get {return Body().MAKBUZNO;} }
            public TTReportField MAKBUZTARIH { get {return Body().MAKBUZTARIH;} }
            public TTReportField IPTALEDEN { get {return Body().IPTALEDEN;} }
            public TTReportField ISLEMNO { get {return Body().ISLEMNO;} }
            public TTReportField RECEIPTTYPE { get {return Body().RECEIPTTYPE;} }
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
                list[0] = new TTReportNqlData<AccountDocument.GetCancelledReceipts_Class>("GetCancelledReceipts", AccountDocument.GetCancelledReceipts((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CancelledReceipts MyParentReport
                {
                    get { return (CancelledReceipts)ParentReport; }
                }
                
                public TTReportField HASTANO;
                public TTReportField HASTAADI;
                public TTReportField TUTAR;
                public TTReportField SIRANO;
                public TTReportField PROTOKOLNO;
                public TTReportField MAKBUZNO;
                public TTReportField MAKBUZTARIH;
                public TTReportField IPTALEDEN;
                public TTReportField ISLEMNO;
                public TTReportField RECEIPTTYPE;
                public TTReportField ACTIONGUID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 42, 5, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{#PATIENTID#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 119, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 240, 5, false);
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

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 146, 5, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    MAKBUZNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 191, 5, false);
                    MAKBUZNO.Name = "MAKBUZNO";
                    MAKBUZNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKBUZNO.TextFont.CharSet = 162;
                    MAKBUZNO.Value = @"{#DOCUMENTNO#}";

                    MAKBUZTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 0, 215, 5, false);
                    MAKBUZTARIH.Name = "MAKBUZTARIH";
                    MAKBUZTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKBUZTARIH.TextFormat = @"Short Date";
                    MAKBUZTARIH.TextFont.CharSet = 162;
                    MAKBUZTARIH.Value = @"{#DOCUMENTDATE#}";

                    IPTALEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 296, 5, false);
                    IPTALEDEN.Name = "IPTALEDEN";
                    IPTALEDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    IPTALEDEN.CaseFormat = CaseFormatEnum.fcUpperCase;
                    IPTALEDEN.MultiLine = EvetHayirEnum.ehEvet;
                    IPTALEDEN.NoClip = EvetHayirEnum.ehEvet;
                    IPTALEDEN.WordBreak = EvetHayirEnum.ehEvet;
                    IPTALEDEN.ExpandTabs = EvetHayirEnum.ehEvet;
                    IPTALEDEN.TextFont.CharSet = 162;
                    IPTALEDEN.Value = @"";

                    ISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 168, 5, false);
                    ISLEMNO.Name = "ISLEMNO";
                    ISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMNO.TextFont.CharSet = 162;
                    ISLEMNO.Value = @"{#ACTIONID#}";

                    RECEIPTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 326, 5, false);
                    RECEIPTTYPE.Name = "RECEIPTTYPE";
                    RECEIPTTYPE.Visible = EvetHayirEnum.ehHayir;
                    RECEIPTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTTYPE.TextFont.CharSet = 162;
                    RECEIPTTYPE.Value = @"{#RECEIPTTYPE#}";

                    ACTIONGUID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 329, 0, 349, 5, false);
                    ACTIONGUID.Name = "ACTIONGUID";
                    ACTIONGUID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONGUID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONGUID.TextFont.CharSet = 162;
                    ACTIONGUID.Value = @"{#ACTIONGUID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetCancelledReceipts_Class dataset_GetCancelledReceipts = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetCancelledReceipts_Class>(0);
                    HASTANO.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Patientid) : "");
                    HASTAADI.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Patientname) : "") + @" " + (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Patientsurname) : "");
                    TUTAR.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Price) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    PROTOKOLNO.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.HospitalProtocolNo) : "");
                    MAKBUZNO.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.DocumentNo) : "");
                    MAKBUZTARIH.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.DocumentDate) : "");
                    IPTALEDEN.CalcValue = @"";
                    ISLEMNO.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Actionid) : "");
                    RECEIPTTYPE.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Receipttype) : "");
                    ACTIONGUID.CalcValue = (dataset_GetCancelledReceipts != null ? Globals.ToStringCore(dataset_GetCancelledReceipts.Actionguid) : "");
                    return new TTReportObject[] { HASTANO,HASTAADI,TUTAR,SIRANO,PROTOKOLNO,MAKBUZNO,MAKBUZTARIH,IPTALEDEN,ISLEMNO,RECEIPTTYPE,ACTIONGUID};
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
                if (this.RECEIPTTYPE.CalcValue == "AVANSNAKIT" || this.RECEIPTTYPE.CalcValue == "AVANSKK")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    Advance Rec = (Advance)objectContext.GetObject(new Guid(ObjectId),"Advance");
                    
                    foreach(TTObjectState objectState in Rec.GetStateHistory())
                    {
                        if(objectState.StateDefID == Advance.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                    if (this.RECEIPTTYPE.CalcValue == "AVANSNAKIT")
                        this.TUTAR.CalcValue = Rec.AdvanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(Rec.AdvanceDocument.DocumentDate)).ToString();
                }
                else if (this.RECEIPTTYPE.CalcValue == "MAKBUZNAKIT" || this.RECEIPTTYPE.CalcValue == "MAKBUZKK")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    Receipt Rec = (Receipt)objectContext.GetObject(new Guid(ObjectId),"Receipt");
                    
                    foreach(TTObjectState objectState in Rec.GetStateHistory())
                    {
                        if(objectState.StateDefID == Receipt.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                    if (this.RECEIPTTYPE.CalcValue == "MAKBUZNAKIT")
                        this.TUTAR.CalcValue = Rec.ReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(Rec.ReceiptDocument.DocumentDate)).ToString();
                }
                else if (this.RECEIPTTYPE.CalcValue == "SENETNAKIT" || this.RECEIPTTYPE.CalcValue == "SENETKK")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    DebenturePayment Rec = (DebenturePayment)objectContext.GetObject(new Guid(ObjectId),"DebenturePayment");
                    
                    foreach(TTObjectState objectState in Rec.GetStateHistory())
                    {
                        if(objectState.StateDefID == DebenturePayment.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                    if (this.RECEIPTTYPE.CalcValue == "SENETNAKIT")
                        this.TUTAR.CalcValue = Rec.DebenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(Rec.DebenturePaymentDocument.DocumentDate)).ToString();
                }
                else if (this.RECEIPTTYPE.CalcValue == "VEZNENAKIT")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    MainCashOfficeOperation Rec = (MainCashOfficeOperation)objectContext.GetObject(new Guid(ObjectId),"MainCashOfficeOperation");
                    
                    foreach(TTObjectState objectState in Rec.GetStateHistory())
                    {
                        if(objectState.StateDefID == MainCashOfficeOperation.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                    this.TUTAR.CalcValue = Rec.CashOfficeReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(Rec.CashOfficeReceiptDocument.DocumentDate)).ToString();
                }
                else if (this.RECEIPTTYPE.CalcValue == "HIZMETKARSILIGINAKIT" || this.RECEIPTTYPE.CalcValue == "HIZMETKARSILIGIKK")
                {
                    string ObjectId = this.ACTIONGUID.CalcValue;
                    GeneralReceipt Rec = (GeneralReceipt)objectContext.GetObject(new Guid(ObjectId),"GeneralReceipt");
                    
                    foreach(TTObjectState objectState in Rec.GetStateHistory())
                    {
                        if(objectState.StateDefID == GeneralReceipt.States.Cancelled)
                        {
                            resUser = (ResUser)objectState.User.UserObject;
                            if (resUser != null)
                                this.IPTALEDEN.CalcValue = resUser.Person.Name + " " + resUser.Person.Surname;
                        }
                    }
                    if (this.RECEIPTTYPE.CalcValue == "HIZMETKARSILIGINAKIT")
                        this.TUTAR.CalcValue = Rec.GeneralReceiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(Rec.GeneralReceiptDocument.DocumentDate)).ToString();
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

        public CancelledReceipts()
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
            Name = "CANCELLEDRECEIPTS";
            Caption = "İptal Edilen Makbuzlar";
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