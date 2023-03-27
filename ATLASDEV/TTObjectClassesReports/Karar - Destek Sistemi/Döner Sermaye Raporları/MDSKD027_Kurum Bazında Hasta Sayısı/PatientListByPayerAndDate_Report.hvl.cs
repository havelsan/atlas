
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
    /// XXXXXXye Kabulü Yapılan Hastaların Listesi
    /// </summary>
    public partial class PatientListByPayerAndDate : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> PAYER = new List<string>();
            public OutPatientInPatientBothEnum? OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue("");
            public int? PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public PatientListByPayerAndDate MyParentReport
            {
                get { return (PatientListByPayerAndDate)ParentReport; }
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
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 29, 8, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 3, 57, 8, false);
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
                    //            ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
//            ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
//            
//            
//            if (((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PAYER == null)
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PAYERFLAG = 0;
//            else
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PAYERFLAG = 1;
//            
//            if (((PatientListByPayerAndDate)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.OutPatient)
//            {
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 0;
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 0;
//            }
//            else if (((PatientListByPayerAndDate)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.InPatient)
//            {
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 1;
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
//            }
//            else if (((PatientListByPayerAndDate)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.Both)
//            {
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
//                ((PatientListByPayerAndDate)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
//            }
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public PatientListByPayerAndDate MyParentReport
            {
                get { return (PatientListByPayerAndDate)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1121141 { get {return Header().NewField1121141;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField NewField1121121 { get {return Header().NewField1121121;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField11411211 { get {return Header().NewField11411211;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
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
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField STARTDATE;
                public TTReportField NewField1121141;
                public TTReportField NewField111111;
                public TTReportField PATIENTSTATUS;
                public TTReportField NewField1121121;
                public TTReportField ENDDATE;
                public TTReportField NewField11411211;
                public TTReportField LOGO; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 8, 163, 28, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"XXXXXXYE KABULÜ YAPILAN HASTALARIN LİSTESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 30, 31, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.NoClip = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Tarih";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 30, 52, 35, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1121141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 30, 34, 35, false);
                    NewField1121141.Name = "NewField1121141";
                    NewField1121141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121141.TextFont.Bold = true;
                    NewField1121141.TextFont.CharSet = 162;
                    NewField1121141.Value = @":";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 36, 31, 41, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 9;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Hasta Durumu";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 36, 76, 41, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.TextFont.Name = "Arial";
                    PATIENTSTATUS.TextFont.Size = 9;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"{@OUTPATIENTINPATIENTBOTH@}";

                    NewField1121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 36, 34, 41, false);
                    NewField1121121.Name = "NewField1121121";
                    NewField1121121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121121.TextFont.Bold = true;
                    NewField1121121.TextFont.CharSet = 162;
                    NewField1121121.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 30, 76, 35, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField11411211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 30, 58, 35, false);
                    NewField11411211.Name = "NewField11411211";
                    NewField11411211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411211.TextFont.Bold = true;
                    NewField11411211.TextFont.CharSet = 162;
                    NewField11411211.Value = @"-";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 49, 28, false);
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
                    NewField1121141.CalcValue = NewField1121141.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    PATIENTSTATUS.CalcValue = MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTBOTH.ToString();
                    NewField1121121.CalcValue = NewField1121121.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField11411211.CalcValue = NewField11411211.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField11,NewField12,STARTDATE,NewField1121141,NewField111111,PATIENTSTATUS,NewField1121121,ENDDATE,NewField11411211,LOGO};
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
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                
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
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 1, 137, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 208, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 40, 6, false);
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
            public PatientListByPayerAndDate MyParentReport
            {
                get { return (PatientListByPayerAndDate)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField121711 { get {return Header().NewField121711;} }
            public TTReportField NewField11112 { get {return Footer().NewField11112;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
            public TTReportField HASTASAYISI { get {return Footer().HASTASAYISI;} }
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
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField PAYER;
                public TTReportField NewField12111;
                public TTReportField NewField1151;
                public TTReportField NewField1171;
                public TTReportField NewField1191;
                public TTReportShape NewLine1111;
                public TTReportField NewField11711;
                public TTReportField NewField121711; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 31, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Kurum";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 208, 6, false);
                    PAYER.Name = "PAYER";
                    PAYER.TextFont.Name = "Arial";
                    PAYER.TextFont.Size = 9;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYER#}";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 34, 6, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 19, 12, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Sıra";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 8, 115, 12, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 9;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"TC Kimlik No";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 67, 12, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Hasta Adı";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 13, 208, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 8, 208, 12, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"Poliklinik / Klinik";

                    NewField121711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 8, 92, 12, false);
                    NewField121711.Name = "NewField121711";
                    NewField121711.TextFont.Name = "Arial";
                    NewField121711.TextFont.Size = 9;
                    NewField121711.TextFont.Bold = true;
                    NewField121711.TextFont.CharSet = 162;
                    NewField121711.Value = @"H.Protokol No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    PAYER.CalcValue = PAYER.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField121711.CalcValue = NewField121711.Value;
                    return new TTReportObject[] { NewField1111,PAYER,NewField12111,NewField1151,NewField1171,NewField1191,NewField11711,NewField121711};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                
                public TTReportField NewField11112;
                public TTReportShape NewLine1112;
                public TTReportField HASTASAYISI; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    RepeatCount = 0;
                    
                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 3, 185, 8, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Size = 9;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Hasta Sayısı :";

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 164, 2, 208, 2, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.DrawWidth = 2;

                    HASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 3, 208, 8, false);
                    HASTASAYISI.Name = "HASTASAYISI";
                    HASTASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTASAYISI.TextFont.Name = "Arial";
                    HASTASAYISI.TextFont.Size = 9;
                    HASTASAYISI.TextFont.CharSet = 162;
                    HASTASAYISI.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11112.CalcValue = NewField11112.Value;
                    HASTASAYISI.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { NewField11112,HASTASAYISI};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientListByPayerAndDate MyParentReport
            {
                get { return (PatientListByPayerAndDate)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField PATIENTSTATUS { get {return Body().PATIENTSTATUS;} }
            public TTReportField CLINIC { get {return Body().CLINIC;} }
            public TTReportField POLICLINIC { get {return Body().POLICLINIC;} }
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
                public PatientListByPayerAndDate MyParentReport
                {
                    get { return (PatientListByPayerAndDate)ParentReport; }
                }
                
                public TTReportField TCKIMLIKNO;
                public TTReportField SNO;
                public TTReportField HASTAADI;
                public TTReportField BOLUM;
                public TTReportField HPROTOKOLNO;
                public TTReportField PATIENTSTATUS;
                public TTReportField CLINIC;
                public TTReportField POLICLINIC; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 115, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.UNIQUEREFNO#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 19, 6, false);
                    SNO.Name = "SNO";
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 9;
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@groupcounter@}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 67, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 9;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PARTA.PATIENTNAME#}";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 1, 208, 6, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM.TextFont.Name = "Arial";
                    BOLUM.TextFont.Size = 9;
                    BOLUM.TextFont.CharSet = 162;
                    BOLUM.Value = @"";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 1, 92, 6, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.TextFont.Name = "Arial";
                    HPROTOKOLNO.TextFont.Size = 9;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#PARTA.HOSPITALPROTOCOLNO#}";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 245, 6, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSTATUS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTSTATUS.TextFont.Name = "Arial";
                    PATIENTSTATUS.TextFont.Size = 9;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"{#PARTA.PATIENTSTATUS#}";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 1, 258, 6, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.Visible = EvetHayirEnum.ehHayir;
                    CLINIC.TextFont.Name = "Arial";
                    CLINIC.TextFont.Size = 9;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"{#PARTA.CLINIC#}";

                    POLICLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 1, 278, 6, false);
                    POLICLINIC.Name = "POLICLINIC";
                    POLICLINIC.Visible = EvetHayirEnum.ehHayir;
                    POLICLINIC.TextFont.Name = "Arial";
                    POLICLINIC.TextFont.Size = 9;
                    POLICLINIC.TextFont.CharSet = 162;
                    POLICLINIC.Value = @"{#PARTA.POLICLINIC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TCKIMLIKNO.CalcValue = TCKIMLIKNO.Value;
                    SNO.CalcValue = SNO.Value;
                    HASTAADI.CalcValue = HASTAADI.Value;
                    BOLUM.CalcValue = BOLUM.Value;
                    HPROTOKOLNO.CalcValue = HPROTOKOLNO.Value;
                    PATIENTSTATUS.CalcValue = PATIENTSTATUS.Value;
                    CLINIC.CalcValue = CLINIC.Value;
                    POLICLINIC.CalcValue = POLICLINIC.Value;
                    return new TTReportObject[] { TCKIMLIKNO,SNO,HASTAADI,BOLUM,HPROTOKOLNO,PATIENTSTATUS,CLINIC,POLICLINIC};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                        if (this.PATIENTSTATUS.FormattedValue == "OUTPATIENT" || this.PATIENTSTATUS.FormattedValue == "OUTPATİENT")
//                this.BOLUM.CalcValue = this.POLICLINIC.CalcValue;
//            else
//                this.BOLUM.CalcValue = this.CLINIC.CalcValue;
//
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

        public PatientListByPayerAndDate()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PAYER", "", "Kurum", @"", false, true, true, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
            reportParameter.ListDefID = new Guid("61cb92fe-0330-48f5-9e09-674ba7a57b3d");
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTBOTH", "", "Hasta Durumu", @"", true, true, false, new Guid("0ab6e9e9-139a-4b78-9a97-05ed687758d5"));
            reportParameter = Parameters.Add("PAYERFLAG", "", "Kurum Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS1", "", "Hasta Durumu 1", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS2", "", "Hasta Durumu 2", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS3", "", "Hasta Durumu 3", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PAYER"))
                _runtimeParameters.PAYER = (List<string>)parameters["PAYER"];
            if (parameters.ContainsKey("OUTPATIENTINPATIENTBOTH"))
                _runtimeParameters.OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue(parameters["OUTPATIENTINPATIENTBOTH"]);
            if (parameters.ContainsKey("PAYERFLAG"))
                _runtimeParameters.PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYERFLAG"]);
            if (parameters.ContainsKey("PATIENTSTATUS1"))
                _runtimeParameters.PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS1"]);
            if (parameters.ContainsKey("PATIENTSTATUS2"))
                _runtimeParameters.PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS2"]);
            if (parameters.ContainsKey("PATIENTSTATUS3"))
                _runtimeParameters.PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS3"]);
            Name = "PATIENTLISTBYPAYERANDDATE";
            Caption = "XXXXXXye Kabulü Yapılan Hastaların Listesi";
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