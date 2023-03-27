
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
    /// Toplu Faturaya Hazır Hastalar Listesi
    /// </summary>
    public partial class ReadyToCollectedInvoicePatientListByResource : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public OutPatientInPatientBothEnum? OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue("");
            public int? PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<string> PAYER = new List<string>();
            public int? PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public ReadyToCollectedInvoicePatientListByResource MyParentReport
            {
                get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 30, 6, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 57, 6, false);
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
#region PARTC HEADER_Script
                    ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            if (((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.OutPatient)
            {
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 0;
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 0;
            }
            else if (((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.InPatient)
            {
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 1;
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
            }
            else if (((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.Both)
            {
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
            }
            if (((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PAYER == null)
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PAYERFLAG = 0;
            else
                ((ReadyToCollectedInvoicePatientListByResource)ParentReport).RuntimeParameters.PAYERFLAG = 1;
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public ReadyToCollectedInvoicePatientListByResource MyParentReport
            {
                get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1212211 { get {return Header().NewField1212211;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField STARTDATE;
                public TTReportField NewField11211;
                public TTReportField ENDDATE;
                public TTReportField NewField112211;
                public TTReportField NewField1112211;
                public TTReportField NewField111211;
                public TTReportField NewField1212211;
                public TTReportField PATIENTSTATUS; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 204, 14, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"TOPLU FATURAYA HAZIR HASTALAR LİSTESİ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 16, 29, 21, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 16, 69, 21, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 21, 29, 26, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 21, 69, 26, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 21, 31, 26, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 16, 31, 21, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 26, 29, 31, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Hasta Durumu";

                    NewField1212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 26, 31, 31, false);
                    NewField1212211.Name = "NewField1212211";
                    NewField1212211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212211.TextFont.Bold = true;
                    NewField1212211.TextFont.CharSet = 162;
                    NewField1212211.Value = @":";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 26, 69, 31, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.TextFormat = @"Short Date";
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"{@OUTPATIENTINPATIENTBOTH@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11211.CalcValue = NewField11211.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1212211.CalcValue = NewField1212211.Value;
                    PATIENTSTATUS.CalcValue = MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTBOTH.ToString();
                    return new TTReportObject[] { NewField1111,NewField1121,STARTDATE,NewField11211,ENDDATE,NewField112211,NewField1112211,NewField111211,NewField1212211,PATIENTSTATUS};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (this.PATIENTSTATUS.CalcValue == "OutPatient")
                this.PATIENTSTATUS.CalcValue = "Ayaktan";
            else if (this.PATIENTSTATUS.CalcValue == "InPatient")
                this.PATIENTSTATUS.CalcValue = "Yatan";
            else if (this.PATIENTSTATUS.CalcValue == "Both")
                this.PATIENTSTATUS.CalcValue = "Hepsi";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 204, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 139, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 204, 7, false);
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

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public ReadyToCollectedInvoicePatientListByResource MyParentReport
            {
                get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1115111 { get {return Header().NewField1115111;} }
            public TTReportField NewField1119111 { get {return Header().NewField1119111;} }
            public TTReportField NewField1117111 { get {return Header().NewField1117111;} }
            public TTReportField NewField1112171111 { get {return Header().NewField1112171111;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField111171211 { get {return Header().NewField111171211;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField112122111 { get {return Header().NewField112122111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class>("GetReadyToCollectedInvoicePatientListReportQuery", PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS1),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS2),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS3),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PAYERFLAG),(List<string>) MyParentReport.RuntimeParameters.PAYER));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                
                public TTReportField NewField1115111;
                public TTReportField NewField1119111;
                public TTReportField NewField1117111;
                public TTReportField NewField1112171111;
                public TTReportShape NewLine111;
                public TTReportField NewField111171211;
                public TTReportField KURUM;
                public TTReportField NewField11112111;
                public TTReportField NewField112122111;
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 18, 10, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.TextFont.Name = "Arial";
                    NewField1115111.TextFont.Size = 8;
                    NewField1115111.TextFont.Bold = true;
                    NewField1115111.TextFont.CharSet = 162;
                    NewField1115111.Value = @"Sıra";

                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 6, 60, 10, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.TextFont.Name = "Arial";
                    NewField1119111.TextFont.Size = 8;
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.CharSet = 162;
                    NewField1119111.Value = @"Hasta Adı";

                    NewField1117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 6, 84, 10, false);
                    NewField1117111.Name = "NewField1117111";
                    NewField1117111.TextFont.Name = "Arial";
                    NewField1117111.TextFont.Size = 8;
                    NewField1117111.TextFont.Bold = true;
                    NewField1117111.TextFont.CharSet = 162;
                    NewField1117111.Value = @"TC Kimlik No";

                    NewField1112171111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 6, 134, 10, false);
                    NewField1112171111.Name = "NewField1112171111";
                    NewField1112171111.TextFont.Name = "Arial";
                    NewField1112171111.TextFont.Size = 8;
                    NewField1112171111.TextFont.Bold = true;
                    NewField1112171111.TextFont.CharSet = 162;
                    NewField1112171111.Value = @"Tarih";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 204, 11, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewField111171211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 6, 114, 10, false);
                    NewField111171211.Name = "NewField111171211";
                    NewField111171211.TextFont.Name = "Arial";
                    NewField111171211.TextFont.Size = 8;
                    NewField111171211.TextFont.Bold = true;
                    NewField111171211.TextFont.CharSet = 162;
                    NewField111171211.Value = @"H.Protokol No";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 204, 6, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.TextFormat = @"Short Date";
                    KURUM.TextFont.Size = 8;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#PAYER#}";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 20, 6, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Name = "Arial";
                    NewField11112111.TextFont.Size = 8;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Kurum";

                    NewField112122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 22, 6, false);
                    NewField112122111.Name = "NewField112122111";
                    NewField112122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112122111.TextFont.Name = "Arial";
                    NewField112122111.TextFont.Bold = true;
                    NewField112122111.TextFont.CharSet = 162;
                    NewField112122111.Value = @":";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 6, 204, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Faturayı Hazıra Getiren";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 6, 163, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Fatura Hazır Tarih";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class dataset_GetReadyToCollectedInvoicePatientListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class>(0);
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField1119111.CalcValue = NewField1119111.Value;
                    NewField1117111.CalcValue = NewField1117111.Value;
                    NewField1112171111.CalcValue = NewField1112171111.Value;
                    NewField111171211.CalcValue = NewField111171211.Value;
                    KURUM.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.Payer) : "");
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField112122111.CalcValue = NewField112122111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { NewField1115111,NewField1119111,NewField1117111,NewField1112171111,NewField111171211,KURUM,NewField11112111,NewField112122111,NewField1,NewField2};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ReadyToCollectedInvoicePatientListByResource MyParentReport
            {
                get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField HAZIRAGETIREN { get {return Body().HAZIRAGETIREN;} }
            public TTReportField HAZIRLANISTARIH { get {return Body().HAZIRLANISTARIH;} }
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

                PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class dataSet_GetReadyToCollectedInvoicePatientListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class>(0);    
                return new object[] {(dataSet_GetReadyToCollectedInvoicePatientListReportQuery==null ? null : dataSet_GetReadyToCollectedInvoicePatientListReportQuery.Payer)};
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
                public ReadyToCollectedInvoicePatientListByResource MyParentReport
                {
                    get { return (ReadyToCollectedInvoicePatientListByResource)ParentReport; }
                }
                
                public TTReportField TCKIMLIKNO;
                public TTReportField SNO;
                public TTReportField HASTAADI;
                public TTReportField HPROTOKOLNO;
                public TTReportField TARIH;
                public TTReportField HAZIRAGETIREN;
                public TTReportField HAZIRLANISTARIH; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 84, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.UNIQUEREFNO#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 18, 6, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 8;
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@groupcounter@}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 60, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PARTA.NAME#} {#PARTA.SURNAME#}";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 1, 114, 6, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.TextFont.Name = "Arial";
                    HPROTOKOLNO.TextFont.Size = 8;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#PARTA.HOSPITALPROTOCOLNO#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 134, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#PARTA.OPENINGDATE#}";

                    HAZIRAGETIREN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 1, 204, 6, false);
                    HAZIRAGETIREN.Name = "HAZIRAGETIREN";
                    HAZIRAGETIREN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAGETIREN.MultiLine = EvetHayirEnum.ehEvet;
                    HAZIRAGETIREN.NoClip = EvetHayirEnum.ehEvet;
                    HAZIRAGETIREN.WordBreak = EvetHayirEnum.ehEvet;
                    HAZIRAGETIREN.ExpandTabs = EvetHayirEnum.ehEvet;
                    HAZIRAGETIREN.TextFont.Name = "Arial";
                    HAZIRAGETIREN.TextFont.Size = 8;
                    HAZIRAGETIREN.TextFont.CharSet = 162;
                    HAZIRAGETIREN.Value = @"{#PARTA.CASHIER#}";

                    HAZIRLANISTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 1, 163, 6, false);
                    HAZIRLANISTARIH.Name = "HAZIRLANISTARIH";
                    HAZIRLANISTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRLANISTARIH.TextFormat = @"Short Date";
                    HAZIRLANISTARIH.Value = @"{#PARTA.REQUESTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class dataset_GetReadyToCollectedInvoicePatientListReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<PayerInvoice.GetReadyToCollectedInvoicePatientListReportQuery_Class>(0);
                    TCKIMLIKNO.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.UniqueRefNo) : "");
                    SNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    HASTAADI.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.Name) : "") + @" " + (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.Surname) : "");
                    HPROTOKOLNO.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.HospitalProtocolNo) : "");
                    TARIH.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.OpeningDate) : "");
                    HAZIRAGETIREN.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.Cashier) : "");
                    HAZIRLANISTARIH.CalcValue = (dataset_GetReadyToCollectedInvoicePatientListReportQuery != null ? Globals.ToStringCore(dataset_GetReadyToCollectedInvoicePatientListReportQuery.RequestDate) : "");
                    return new TTReportObject[] { TCKIMLIKNO,SNO,HASTAADI,HPROTOKOLNO,TARIH,HAZIRAGETIREN,HAZIRLANISTARIH};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ReadyToCollectedInvoicePatientListByResource()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTBOTH", "", "Hasta Durumu", @"", true, true, false, new Guid("0ab6e9e9-139a-4b78-9a97-05ed687758d5"));
            reportParameter = Parameters.Add("PATIENTSTATUS1", "", "Hasta Durumu 1", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS2", "", "Hasta Durumu 2", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS3", "", "Hasta Durumu 3", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PAYER", "", "Kurum", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("61cb92fe-0330-48f5-9e09-674ba7a57b3d");
            reportParameter = Parameters.Add("PAYERFLAG", "", "Kurum Kontrol", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTBOTH"))
                _runtimeParameters.OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue(parameters["OUTPATIENTINPATIENTBOTH"]);
            if (parameters.ContainsKey("PATIENTSTATUS1"))
                _runtimeParameters.PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS1"]);
            if (parameters.ContainsKey("PATIENTSTATUS2"))
                _runtimeParameters.PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS2"]);
            if (parameters.ContainsKey("PATIENTSTATUS3"))
                _runtimeParameters.PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS3"]);
            if (parameters.ContainsKey("PAYER"))
                _runtimeParameters.PAYER = (List<string>)parameters["PAYER"];
            if (parameters.ContainsKey("PAYERFLAG"))
                _runtimeParameters.PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYERFLAG"]);
            Name = "READYTOCOLLECTEDINVOICEPATIENTLISTBYRESOURCE";
            Caption = "Toplu Faturaya Hazır Hastalar Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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