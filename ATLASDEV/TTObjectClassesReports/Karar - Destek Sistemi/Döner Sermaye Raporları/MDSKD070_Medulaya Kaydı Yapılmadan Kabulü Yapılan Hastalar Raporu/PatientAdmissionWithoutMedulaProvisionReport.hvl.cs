
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
    /// Medulaya Kaydı Yapılmadan Kabulü Yapılan Hastalar Raporu
    /// </summary>
    public partial class PatientAdmissionWithoutMedulaProvisionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> SPECIALITY = new List<string>();
            public int? SPECIALITYFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public InvoicedNotInvoicedEnum? INVOICESTATUS = (InvoicedNotInvoicedEnum?)(int?)TTObjectDefManager.Instance.DataTypes["InvoicedNotInvoicedEnum"].ConvertValue("");
            public int? INVOICEDFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
            {
                get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
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
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
                {
                    get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 33, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 60, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
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
                    ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(this.STARTDATE.FormattedValue + " 00:00:00");
            ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(this.ENDDATE.FormattedValue + " 23:59:59");
            
            if(((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.SPECIALITY == null)
            {
                ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.SPECIALITYFLAG = 0;
            }
            else
            {
                ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.SPECIALITYFLAG = 1;
            }
            
            if(((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.INVOICESTATUS == InvoicedNotInvoicedEnum.Invoiced)
            {
                ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.INVOICEDFLAG = 1;
            }
            else
            {
                ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.INVOICEDFLAG = 0;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
                {
                    get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 206, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 3, 112, 8, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 3, 37, 8, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"Short Date";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
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

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
            {
                get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
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
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField111311 { get {return Header().NewField111311;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField INVOICESTATUS { get {return Header().INVOICESTATUS;} }
            public TTReportField NewField1113111 { get {return Header().NewField1113111;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField UZMANLIKDALI { get {return Header().UZMANLIKDALI;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11312 { get {return Header().NewField11312;} }
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
                public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
                {
                    get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportShape NewLine111;
                public TTReportField NewField1141;
                public TTReportField NewField11421;
                public TTReportField NewField1241;
                public TTReportField NewField11111;
                public TTReportField NewField11211;
                public TTReportField NewField11311;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField111311;
                public TTReportField NewField11611;
                public TTReportField INVOICESTATUS;
                public TTReportField NewField1113111;
                public TTReportField NewField111611;
                public TTReportField UZMANLIKDALI;
                public TTReportField NewField1131;
                public TTReportField NewField11312; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 42, 14, 47, false);
                    NewField111.Name = "NewField111";
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"S. No";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 42, 74, 47, false);
                    NewField121.Name = "NewField121";
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Prot No";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 42, 124, 47, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Uzmanlık Dalı";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 48, 206, 48, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 42, 30, 47, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"TC No";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 42, 60, 47, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.TextFont.Name = "Arial";
                    NewField11421.TextFont.Size = 8;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"Hasta Adı";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 42, 89, 47, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 8;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Tarih
";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 206, 19, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 12;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"MEDULAYA KAYDI YAPILMADAN KABULÜ YAPILAN HASTALAR RAPORU";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 20, 38, 25, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Başlangıç Tarihi";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 38, 31, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 8;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Bitiş Tarihi";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 20, 41, 25, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 26, 41, 31, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 20, 67, 25, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 26, 67, 31, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 20, 100, 25, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.TextFont.Name = "Arial";
                    NewField111311.TextFont.Size = 8;
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"Faturalanma Durumu";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 20, 103, 25, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @":";

                    INVOICESTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 20, 129, 25, false);
                    INVOICESTATUS.Name = "INVOICESTATUS";
                    INVOICESTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICESTATUS.ObjectDefName = "InvoicedNotInvoicedEnum";
                    INVOICESTATUS.DataMember = "DISPLAYTEXT";
                    INVOICESTATUS.TextFont.Size = 8;
                    INVOICESTATUS.TextFont.CharSet = 162;
                    INVOICESTATUS.Value = @"{@INVOICESTATUS@}";

                    NewField1113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 32, 38, 37, false);
                    NewField1113111.Name = "NewField1113111";
                    NewField1113111.TextFont.Name = "Arial";
                    NewField1113111.TextFont.Size = 8;
                    NewField1113111.TextFont.Bold = true;
                    NewField1113111.TextFont.CharSet = 162;
                    NewField1113111.Value = @"Uzmanlık Dalı";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 32, 41, 37, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 8;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @":";

                    UZMANLIKDALI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 32, 206, 41, false);
                    UZMANLIKDALI.Name = "UZMANLIKDALI";
                    UZMANLIKDALI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDALI.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.ExpandTabs = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.TextFont.Size = 8;
                    UZMANLIKDALI.TextFont.CharSet = 162;
                    UZMANLIKDALI.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 42, 206, 47, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Kurum Adı";

                    NewField11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 42, 150, 47, false);
                    NewField11312.Name = "NewField11312";
                    NewField11312.TextFont.Name = "Arial";
                    NewField11312.TextFont.Size = 8;
                    NewField11312.TextFont.Bold = true;
                    NewField11312.TextFont.CharSet = 162;
                    NewField11312.Value = @"Kullanıcı Adı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    INVOICESTATUS.CalcValue = MyParentReport.RuntimeParameters.INVOICESTATUS.ToString();
                    INVOICESTATUS.PostFieldValueCalculation();
                    NewField1113111.CalcValue = NewField1113111.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    UZMANLIKDALI.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11312.CalcValue = NewField11312.Value;
                    return new TTReportObject[] { NewField111,NewField121,NewField131,NewField1141,NewField11421,NewField1241,NewField11111,NewField11211,NewField11311,NewField161,NewField1161,STARTDATE,ENDDATE,NewField111311,NewField11611,INVOICESTATUS,NewField1113111,NewField111611,UZMANLIKDALI,NewField1131,NewField11312};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.SPECIALITY == null)
            {
                this.UZMANLIKDALI.CalcValue = "Hepsi";
            }
            else
            {
                String speciality = "";
                IList<String> specialityList = ((PatientAdmissionWithoutMedulaProvisionReport)ParentReport).RuntimeParameters.SPECIALITY;
                for(int i = 0; i < specialityList.Count; i++)
                {
                    SpecialityDefinition specialityDefinition = (SpecialityDefinition) MyParentReport.ReportObjectContext.GetObject(new Guid(specialityList[i]),"SpecialityDefinition");
                    speciality += specialityDefinition.Name + " , ";
                }
                this.UZMANLIKDALI.CalcValue = speciality.Substring(0,speciality.Length-3);
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
                {
                    get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
            {
                get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField UZMANLIKDALI { get {return Body().UZMANLIKDALI;} }
            public TTReportField KURUMADI { get {return Body().KURUMADI;} }
            public TTReportField KULLANICIADI { get {return Body().KULLANICIADI;} }
            public TTReportField USERID { get {return Body().USERID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public PatientAdmissionWithoutMedulaProvisionReport MyParentReport
                {
                    get { return (PatientAdmissionWithoutMedulaProvisionReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField PROTOKOLNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField TARIH;
                public TTReportField ADISOYADI;
                public TTReportField UZMANLIKDALI;
                public TTReportField KURUMADI;
                public TTReportField KULLANICIADI;
                public TTReportField USERID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 14, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 74, 6, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.TextFont.Size = 8;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 30, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 1, 89, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#OPENINGDATE#}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 1, 60, 6, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{#PATIENTNAME#}";

                    UZMANLIKDALI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 1, 124, 6, false);
                    UZMANLIKDALI.Name = "UZMANLIKDALI";
                    UZMANLIKDALI.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.ExpandTabs = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.TextFont.Size = 8;
                    UZMANLIKDALI.TextFont.CharSet = 162;
                    UZMANLIKDALI.Value = @"{#SPECIALITY#}";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 206, 6, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"{#PAYERNAME#}";

                    KULLANICIADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 1, 150, 6, false);
                    KULLANICIADI.Name = "KULLANICIADI";
                    KULLANICIADI.MultiLine = EvetHayirEnum.ehEvet;
                    KULLANICIADI.NoClip = EvetHayirEnum.ehEvet;
                    KULLANICIADI.WordBreak = EvetHayirEnum.ehEvet;
                    KULLANICIADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KULLANICIADI.TextFont.Size = 8;
                    KULLANICIADI.TextFont.CharSet = 162;
                    KULLANICIADI.Value = @"";

                    USERID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 6, false);
                    USERID.Name = "USERID";
                    USERID.Visible = EvetHayirEnum.ehHayir;
                    USERID.Value = @"{#USERID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIRANO.CalcValue = SIRANO.Value;
                    PROTOKOLNO.CalcValue = PROTOKOLNO.Value;
                    TCKIMLIKNO.CalcValue = TCKIMLIKNO.Value;
                    TARIH.CalcValue = TARIH.Value;
                    ADISOYADI.CalcValue = ADISOYADI.Value;
                    UZMANLIKDALI.CalcValue = UZMANLIKDALI.Value;
                    KURUMADI.CalcValue = KURUMADI.Value;
                    KULLANICIADI.CalcValue = KULLANICIADI.Value;
                    USERID.CalcValue = USERID.Value;
                    return new TTReportObject[] { SIRANO,PROTOKOLNO,TCKIMLIKNO,TARIH,ADISOYADI,UZMANLIKDALI,KURUMADI,KULLANICIADI,USERID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(!string.IsNullOrEmpty(this.USERID.CalcValue))
            {
                TTUser user = TTUser.GetUser(new Guid(this.USERID.CalcValue));
                ResUser resUser = (ResUser)user.UserObject;
                this.KULLANICIADI.CalcValue = resUser.Name;
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

        public PatientAdmissionWithoutMedulaProvisionReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SPECIALITY", "", "Uzmanlık Dalı ", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("8b28f3a9-d983-4221-a2b8-65a9dc603636");
            reportParameter = Parameters.Add("SPECIALITYFLAG", "", "Uzmanlık Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("INVOICESTATUS", "", "Faturalanma Durumu", @"", true, true, false, new Guid("51180971-1459-456d-9efe-282069277bdd"));
            reportParameter = Parameters.Add("INVOICEDFLAG", "", "Faturalama Kontrolü", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SPECIALITY"))
                _runtimeParameters.SPECIALITY = (List<string>)parameters["SPECIALITY"];
            if (parameters.ContainsKey("SPECIALITYFLAG"))
                _runtimeParameters.SPECIALITYFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SPECIALITYFLAG"]);
            if (parameters.ContainsKey("INVOICESTATUS"))
                _runtimeParameters.INVOICESTATUS = (InvoicedNotInvoicedEnum?)(int?)TTObjectDefManager.Instance.DataTypes["InvoicedNotInvoicedEnum"].ConvertValue(parameters["INVOICESTATUS"]);
            if (parameters.ContainsKey("INVOICEDFLAG"))
                _runtimeParameters.INVOICEDFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["INVOICEDFLAG"]);
            Name = "PATIENTADMISSIONWITHOUTMEDULAPROVISIONREPORT";
            Caption = "Medulaya Kaydı Yapılmadan Kabulü Yapılan Hastalar Raporu";
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