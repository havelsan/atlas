
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
    /// Hastaya Reçeteyle Yazılmış İlaçlar Raporu (Doktor Bazında)
    /// </summary>
    public partial class DrugsToPatientWithPrescriptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string DOCTORID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string DRUGID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugsToPatientWithPrescriptionReport MyParentReport
            {
                get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
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
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField NewField12112 { get {return Header().NewField12112;} }
            public TTReportField NewField12113 { get {return Header().NewField12113;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField Doctor { get {return Header().Doctor;} }
            public TTReportField DrugName { get {return Header().DrugName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public DrugsToPatientWithPrescriptionReport MyParentReport
                {
                    get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField12112;
                public TTReportField NewField12113;
                public TTReportField StartDate;
                public TTReportField EndDate;
                public TTReportField Doctor;
                public TTReportField DrugName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.MultiLine = EvetHayirEnum.ehEvet;
                    ReportName.WordBreak = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"HASTAYA REÇETEYLE YAZILMIŞ İLAÇLAR RAPORU (DOKTOR BAZINDA)";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 24, 23, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 23, 34, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 34, 23, 39, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İlacı Yazan";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 39, 23, 44, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İlacın Adı";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 24, 24, 29, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @":";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 29, 24, 34, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @":";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 34, 24, 39, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @":";

                    NewField12113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 39, 24, 44, false);
                    NewField12113.Name = "NewField12113";
                    NewField12113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12113.TextFont.Bold = true;
                    NewField12113.TextFont.CharSet = 162;
                    NewField12113.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 24, 49, 29, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.Value = @"{@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 29, 49, 34, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.Value = @"{@ENDDATE@}";

                    Doctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 34, 49, 39, false);
                    Doctor.Name = "Doctor";
                    Doctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    Doctor.CaseFormat = CaseFormatEnum.fcNameSurname;
                    Doctor.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Doctor.NoClip = EvetHayirEnum.ehEvet;
                    Doctor.ObjectDefName = "ResUser";
                    Doctor.DataMember = "NAME";
                    Doctor.Value = @"{@DOCTORID@}";

                    DrugName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 39, 49, 44, false);
                    DrugName.Name = "DrugName";
                    DrugName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DrugName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DrugName.NoClip = EvetHayirEnum.ehEvet;
                    DrugName.ObjectDefName = "DrugDefinition";
                    DrugName.DataMember = "NAME";
                    DrugName.Value = @"{@DRUGID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    NewField12113.CalcValue = NewField12113.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    Doctor.CalcValue = MyParentReport.RuntimeParameters.DOCTORID.ToString();
                    Doctor.PostFieldValueCalculation();
                    DrugName.CalcValue = MyParentReport.RuntimeParameters.DRUGID.ToString();
                    DrugName.PostFieldValueCalculation();
                    return new TTReportObject[] { LOGO,ReportName,NewField1,NewField11,NewField111,NewField1111,NewField1112,NewField12111,NewField12112,NewField12113,StartDate,EndDate,Doctor,DrugName};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DrugsToPatientWithPrescriptionReport MyParentReport
                {
                    get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 100, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

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
            public DrugsToPatientWithPrescriptionReport MyParentReport
            {
                get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
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
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                public DrugsToPatientWithPrescriptionReport MyParentReport
                {
                    get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 17, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Hasta Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 89, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Hasta Adı Soyadı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 115, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İşlem Tarihi";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 141, 5, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İşlem Nu.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 170, 5, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"İşlem Tipi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 170, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DrugsToPatientWithPrescriptionReport MyParentReport
                {
                    get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DrugsToPatientWithPrescriptionReport MyParentReport
            {
                get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PatientNO { get {return Body().PatientNO;} }
            public TTReportField PatientName { get {return Body().PatientName;} }
            public TTReportField ActionDate { get {return Body().ActionDate;} }
            public TTReportField ActionID { get {return Body().ActionID;} }
            public TTReportField ActionType { get {return Body().ActionType;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class>("GetDrugsToPatientWithPrescriptionReportQuery", DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.DOCTORID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.DRUGID)));
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
                public DrugsToPatientWithPrescriptionReport MyParentReport
                {
                    get { return (DrugsToPatientWithPrescriptionReport)ParentReport; }
                }
                
                public TTReportField PatientNO;
                public TTReportField PatientName;
                public TTReportField ActionDate;
                public TTReportField ActionID;
                public TTReportField ActionType;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    PatientNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 17, 6, false);
                    PatientNO.Name = "PatientNO";
                    PatientNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PatientNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PatientNO.Value = @"{#PATIENTID#}";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 89, 6, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PatientName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    ActionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 1, 115, 6, false);
                    ActionDate.Name = "ActionDate";
                    ActionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionDate.TextFormat = @"dd/MM/yyyy";
                    ActionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActionDate.Value = @"{#ACTIONDATE#}";

                    ActionID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 1, 141, 6, false);
                    ActionID.Name = "ActionID";
                    ActionID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ActionID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActionID.Value = @"{#ID#}";

                    ActionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 170, 6, false);
                    ActionType.Name = "ActionType";
                    ActionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ActionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActionType.Value = @"{#TYPE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class dataset_GetDrugsToPatientWithPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class>(0);
                    PatientNO.CalcValue = (dataset_GetDrugsToPatientWithPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsToPatientWithPrescriptionReportQuery.Patientid) : "");
                    PatientName.CalcValue = (dataset_GetDrugsToPatientWithPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsToPatientWithPrescriptionReportQuery.Name) : "") + @" " + (dataset_GetDrugsToPatientWithPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsToPatientWithPrescriptionReportQuery.Surname) : "");
                    ActionDate.CalcValue = (dataset_GetDrugsToPatientWithPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsToPatientWithPrescriptionReportQuery.ActionDate) : "");
                    ActionID.CalcValue = (dataset_GetDrugsToPatientWithPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsToPatientWithPrescriptionReportQuery.ID) : "");
                    ActionType.CalcValue = (dataset_GetDrugsToPatientWithPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsToPatientWithPrescriptionReportQuery.Type) : "");
                    return new TTReportObject[] { PatientNO,PatientName,ActionDate,ActionID,ActionType};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DrugsToPatientWithPrescriptionReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DOCTORID", "", "İlacı Yazan Doktoru Seçiniz", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter = Parameters.Add("DRUGID", "", "İlacı Seçiniz", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("65a31b98-5ce0-4a87-bd7b-576c835d18e9");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DOCTORID"))
                _runtimeParameters.DOCTORID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DOCTORID"]);
            if (parameters.ContainsKey("DRUGID"))
                _runtimeParameters.DRUGID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DRUGID"]);
            Name = "DRUGSTOPATIENTWITHPRESCRIPTIONREPORT";
            Caption = "Hastaya Reçeteyle Yazılmış İlaçlar Raporu (Doktor Bazında)";
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