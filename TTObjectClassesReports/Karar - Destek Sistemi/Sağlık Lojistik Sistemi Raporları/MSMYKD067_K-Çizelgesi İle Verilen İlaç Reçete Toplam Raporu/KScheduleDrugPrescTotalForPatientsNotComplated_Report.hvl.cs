
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
    /// Günlük İlaç Çizelgesi İle Verilen İlaçlar Toplam İstem Raporu Hastalara Göre
    /// </summary>
    public partial class KScheduleDrugPrescTotalForPatientsNotComplated : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? STOREID_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
            {
                get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
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
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField StartDate;
                public TTReportField EndDate;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 28, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 20, 133, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 25, 133, 30, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 20, 134, 25, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 25, 134, 30, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 20, 178, 25, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.Value = @"{@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 25, 178, 30, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.Value = @"{@ENDDATE@}";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 183, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.MultiLine = EvetHayirEnum.ehEvet;
                    ReportName.WordBreak = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"GÜNLÜK İLAÇ ÇİZELGESİ İLE VERİLEN İLAÇLAR İSTEM TOPLAM RAPORU
( HASTALARA GÖRE )";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    ReportName.CalcValue = ReportName.Value;
                    return new TTReportObject[] { LOGO,NewField1,NewField11,NewField2,NewField12,StartDate,EndDate,ReportName};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if (String.IsNullOrEmpty(((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID) || ((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID == Guid.Empty.ToString())
                ((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID_FLAG = 0;
            else
                ((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID_FLAG = 1;
            
//            if(((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE != null)
//            {
//                ((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE = new DateTime(((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE.Value.Year, ((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE.Value.Month, ((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE.Value.Day, 23, 59, 59);
//            }
#endregion PARTA HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (String.IsNullOrEmpty(((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID) || ((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID == Guid.Empty.ToString())
                ((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID_FLAG = 0;
            else
                ((KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport).RuntimeParameters.STOREID_FLAG = 1;
            
//            if(((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE != null)
//            {
//                ((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE = new DateTime(((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE.Value.Year, ((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE.Value.Month, ((KScheduleDrugPrescTotalForPatients)ParentReport).RuntimeParameters.ENDDATE.Value.Day, 23, 59, 59);
//            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 185, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 114, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 185, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
            {
                get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField SUMOFTOTALAMOUNT { get {return Footer().SUMOFTOTALAMOUNT;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField121211 { get {return Footer().NewField121211;} }
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
                list[0] = new TTReportNqlData<KSchedule.GetKScheduleWithPatientNotComplated_Class>("GetKScheduleWithPatientNotComplated", KSchedule.GetKScheduleWithPatientNotComplated((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREID_FLAG)));
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
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField112;
                public TTReportField STORENAME;
                public TTReportField NewField131;
                public TTReportField NewField1121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 8, 255, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sıra Nu.";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 8, 241, 13, false);
                    NewField112.Name = "NewField112";
                    NewField112.Visible = EvetHayirEnum.ehHayir;
                    NewField112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Size = 11;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"İlaç Kodu";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 3, 184, 8, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    STORENAME.TextFormat = @"dd/MM/yyyy";
                    STORENAME.MultiLine = EvetHayirEnum.ehEvet;
                    STORENAME.WordBreak = EvetHayirEnum.ehEvet;
                    STORENAME.TextFont.Name = "Arial";
                    STORENAME.TextFont.Bold = true;
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{#STORENAME#}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 45, 8, false);
                    NewField131.Name = "NewField131";
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İSTEK YAPAN BİRİMİN DEPOSU";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 3, 47, 8, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleWithPatientNotComplated_Class dataset_GetKScheduleWithPatientNotComplated = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField112.CalcValue = NewField112.Value;
                    STORENAME.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.Storename) : "");
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField1,NewField112,STORENAME,NewField131,NewField1121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField SUMOFTOTALAMOUNT;
                public TTReportField NewField11;
                public TTReportField NewField121211; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    SUMOFTOTALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 140, 5, false);
                    SUMOFTOTALAMOUNT.Name = "SUMOFTOTALAMOUNT";
                    SUMOFTOTALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFTOTALAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUMOFTOTALAMOUNT.Value = @"{@sumof(SUMOFAMOUNT)@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 122, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField11.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"{#STORENAME#} + "" TOPLAM""";

                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 124, 5, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleWithPatientNotComplated_Class dataset_GetKScheduleWithPatientNotComplated = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);
                    SUMOFTOTALAMOUNT.CalcValue = ParentGroup.FieldSums["SUMOFAMOUNT"].Value.ToString();;
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField11.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.Storename) : "") + " TOPLAM";
                    return new TTReportObject[] { SUMOFTOTALAMOUNT,NewField121211,NewField11};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PatientGROUPGroup : TTReportGroup
        {
            public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
            {
                get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
            }

            new public PatientGROUPGroupHeader Header()
            {
                return (PatientGROUPGroupHeader)_header;
            }

            new public PatientGROUPGroupFooter Footer()
            {
                return (PatientGROUPGroupFooter)_footer;
            }

            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField NewField13111 { get {return Header().NewField13111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField SUMOFAMOUNT { get {return Footer().SUMOFAMOUNT;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11212 { get {return Footer().NewField11212;} }
            public PatientGROUPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PatientGROUPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                KSchedule.GetKScheduleWithPatientNotComplated_Class dataSet_GetKScheduleWithPatientNotComplated = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);    
                return new object[] {(dataSet_GetKScheduleWithPatientNotComplated==null ? null : dataSet_GetKScheduleWithPatientNotComplated.Storename)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PatientGROUPGroupHeader(this);
                _footer = new PatientGROUPGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PatientGROUPGroupHeader : TTReportSection
            {
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField PATIENTNAME;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportShape NewLine11;
                public TTReportField NewField11111;
                public TTReportField NewField12111;
                public TTReportField NewField13111;
                public TTReportField NewField1131;
                public TTReportField NewField11211; 
                public PatientGROUPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 1, 184, 6, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ObjectDefName = "Patient";
                    PATIENTNAME.DataMember = "FullName";
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.Bold = true;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PARTB.PATIENT#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 8, 152, 13, false);
                    NewField111.Name = "NewField111";
                    NewField111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İlaç Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 8, 168, 13, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Miktar";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 13, 185, 13, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 8, 29, 13, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Tarih";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 8, 184, 13, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"D.Şekli";

                    NewField13111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 7, 246, 12, false);
                    NewField13111.Name = "NewField13111";
                    NewField13111.Visible = EvetHayirEnum.ehHayir;
                    NewField13111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField13111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13111.TextFont.Bold = true;
                    NewField13111.TextFont.CharSet = 162;
                    NewField13111.Value = @"Son Kul.Tarihi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 41, 6, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Hasta Adı Soyadı ";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 47, 6, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleWithPatientNotComplated_Class dataset_GetKScheduleWithPatientNotComplated = MyParentReport.PARTB.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);
                    PATIENTNAME.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.Patient) : "");
                    PATIENTNAME.PostFieldValueCalculation();
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField13111.CalcValue = NewField13111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    return new TTReportObject[] { PATIENTNAME,NewField111,NewField1111,NewField11111,NewField12111,NewField13111,NewField1131,NewField11211};
                }
            }
            public partial class PatientGROUPGroupFooter : TTReportSection
            {
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField SUMOFAMOUNT;
                public TTReportField NewField1;
                public TTReportField NewField11212; 
                public PatientGROUPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SUMOFAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 169, 5, false);
                    SUMOFAMOUNT.Name = "SUMOFAMOUNT";
                    SUMOFAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUMOFAMOUNT.Value = @"{@sumof(TotalAmount)@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 150, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Hasta Toplam";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 152, 5, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleWithPatientNotComplated_Class dataset_GetKScheduleWithPatientNotComplated = MyParentReport.PARTB.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);
                    SUMOFAMOUNT.CalcValue = ParentGroup.FieldSums["TotalAmount"].Value.ToString();;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    return new TTReportObject[] { SUMOFAMOUNT,NewField1,NewField11212};
                }
            }

        }

        public PatientGROUPGroup PatientGROUP;

        public partial class MAINGroup : TTReportGroup
        {
            public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
            {
                get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OrderNO { get {return Body().OrderNO;} }
            public TTReportField DrugName { get {return Body().DrugName;} }
            public TTReportField Code { get {return Body().Code;} }
            public TTReportField TotalAmount { get {return Body().TotalAmount;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField TransactionDate { get {return Body().TransactionDate;} }
            public TTReportField DistributionType { get {return Body().DistributionType;} }
            public TTReportField ExpirationDate { get {return Body().ExpirationDate;} }
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

                KSchedule.GetKScheduleWithPatientNotComplated_Class dataSet_GetKScheduleWithPatientNotComplated = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);    
                return new object[] {(dataSet_GetKScheduleWithPatientNotComplated==null ? null : dataSet_GetKScheduleWithPatientNotComplated.Patient)};
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
                public KScheduleDrugPrescTotalForPatientsNotComplated MyParentReport
                {
                    get { return (KScheduleDrugPrescTotalForPatientsNotComplated)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField DrugName;
                public TTReportField Code;
                public TTReportField TotalAmount;
                public TTReportShape NewLine1;
                public TTReportField TransactionDate;
                public TTReportField DistributionType;
                public TTReportField ExpirationDate; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 1, 255, 6, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.Visible = EvetHayirEnum.ehHayir;
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.Value = @"{@groupcounter@}";

                    DrugName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 151, 6, false);
                    DrugName.Name = "DrugName";
                    DrugName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DrugName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DrugName.Value = @"{#PARTB.NAME#}";

                    Code = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 242, 6, false);
                    Code.Name = "Code";
                    Code.Visible = EvetHayirEnum.ehHayir;
                    Code.FieldType = ReportFieldTypeEnum.ftVariable;
                    Code.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Code.Value = @"{#PARTB.BARCODE#}";

                    TotalAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 168, 6, false);
                    TotalAmount.Name = "TotalAmount";
                    TotalAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalAmount.TextFormat = @"#,###";
                    TotalAmount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TotalAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalAmount.Value = @"{#PARTB.AMOUNT#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 184, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TransactionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 28, 6, false);
                    TransactionDate.Name = "TransactionDate";
                    TransactionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    TransactionDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TransactionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate.Value = @"{#PARTB.TRANSACTIONDATE#}";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 1, 184, 6, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.TextFormat = @"#,###";
                    DistributionType.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.ObjectDefName = "DistributionTypeDefinition";
                    DistributionType.DataMember = "DISTRIBUTIONTYPE";
                    DistributionType.Value = @"{#PARTB.DISTRIBUTIONTYPE#}";

                    ExpirationDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 1, 286, 6, false);
                    ExpirationDate.Name = "ExpirationDate";
                    ExpirationDate.Visible = EvetHayirEnum.ehHayir;
                    ExpirationDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpirationDate.TextFormat = @"dd/MM/yyyy";
                    ExpirationDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ExpirationDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpirationDate.Value = @"{#PARTB.EXPIRATIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleWithPatientNotComplated_Class dataset_GetKScheduleWithPatientNotComplated = MyParentReport.PARTB.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleWithPatientNotComplated_Class>(0);
                    OrderNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    DrugName.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.Name) : "");
                    Code.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.Barcode) : "");
                    TotalAmount.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.Amount) : "");
                    TransactionDate.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.TransactionDate) : "");
                    DistributionType.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.DistributionType) : "");
                    DistributionType.PostFieldValueCalculation();
                    ExpirationDate.CalcValue = (dataset_GetKScheduleWithPatientNotComplated != null ? Globals.ToStringCore(dataset_GetKScheduleWithPatientNotComplated.ExpirationDate) : "");
                    return new TTReportObject[] { OrderNO,DrugName,Code,TotalAmount,TransactionDate,DistributionType,ExpirationDate};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KScheduleDrugPrescTotalForPatientsNotComplated()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PatientGROUP = new PatientGROUPGroup(PARTB,"PatientGROUP");
            MAIN = new MAINGroup(PatientGROUP,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "", "Depo Seçiniz :", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STOREID_FLAG", "", "STOREID_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("STOREID_FLAG"))
                _runtimeParameters.STOREID_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREID_FLAG"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "KSCHEDULEDRUGPRESCTOTALFORPATIENTSNOTCOMPLATED";
            Caption = "Günlük İlaç Çizelgesi İle Verilen İlaçlar Toplam İstem Raporu Hastalara Göre";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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