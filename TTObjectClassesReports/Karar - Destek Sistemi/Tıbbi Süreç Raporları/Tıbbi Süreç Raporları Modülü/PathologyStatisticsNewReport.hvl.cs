
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
    public partial class PathologyStatisticsNewReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string Uniquerefno = (string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue("");
            public int? UNIQUEREFNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string MatPrtNoString = (string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue("");
            public int? MATPRTNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? TESTCATEGORY_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? TEST_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string Diagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? DIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string SnomedDiagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? SNOMEDDIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string ResponsibleDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? RESPONSIBLEDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string SpecialDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? SPECIALDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string AssistantDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? ASSISTANTDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public PathologyStatisticsNewReport MyParentReport
            {
                get { return (PathologyStatisticsNewReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField lblHeader1 { get {return Header().lblHeader1;} }
            public TTReportField lblNameSurname1 { get {return Header().lblNameSurname1;} }
            public TTReportField lblIdentificationCardNo1 { get {return Header().lblIdentificationCardNo1;} }
            public TTReportField lblMatPrtNo1 { get {return Header().lblMatPrtNo1;} }
            public TTReportField lblCatergory1 { get {return Header().lblCatergory1;} }
            public TTReportField lblTest1 { get {return Header().lblTest1;} }
            public TTReportField lblSnomedDiagnosis1 { get {return Header().lblSnomedDiagnosis1;} }
            public TTReportField lblDate1 { get {return Header().lblDate1;} }
            public TTReportField lblResponsibleDoctor1 { get {return Header().lblResponsibleDoctor1;} }
            public TTReportField lblSpecialDoctor1 { get {return Header().lblSpecialDoctor1;} }
            public TTReportField lblAssistantDoctor1 { get {return Header().lblAssistantDoctor1;} }
            public TTReportField lblStartTime { get {return Header().lblStartTime;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField lblEndTime { get {return Header().lblEndTime;} }
            public TTReportField lblStartTime11 { get {return Header().lblStartTime11;} }
            public TTReportField lblEndTime11 { get {return Header().lblEndTime11;} }
            public TTReportField lblDiagnosis1 { get {return Header().lblDiagnosis1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public PathologyStatisticsNewReport MyParentReport
                {
                    get { return (PathologyStatisticsNewReport)ParentReport; }
                }
                
                public TTReportField lblHeader1;
                public TTReportField lblNameSurname1;
                public TTReportField lblIdentificationCardNo1;
                public TTReportField lblMatPrtNo1;
                public TTReportField lblCatergory1;
                public TTReportField lblTest1;
                public TTReportField lblSnomedDiagnosis1;
                public TTReportField lblDate1;
                public TTReportField lblResponsibleDoctor1;
                public TTReportField lblSpecialDoctor1;
                public TTReportField lblAssistantDoctor1;
                public TTReportField lblStartTime;
                public TTReportField NewField12;
                public TTReportField lblEndTime;
                public TTReportField lblStartTime11;
                public TTReportField lblEndTime11;
                public TTReportField lblDiagnosis1; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblHeader1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 7, 196, 15, false);
                    lblHeader1.Name = "lblHeader1";
                    lblHeader1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblHeader1.TextFont.Name = "Arial";
                    lblHeader1.TextFont.Size = 12;
                    lblHeader1.TextFont.Bold = true;
                    lblHeader1.TextFont.Underline = true;
                    lblHeader1.TextFont.CharSet = 162;
                    lblHeader1.Value = @"PATOLOJİ  İSTATİSTİK  RAPORU";

                    lblNameSurname1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 21, 34, 26, false);
                    lblNameSurname1.Name = "lblNameSurname1";
                    lblNameSurname1.TextFont.Size = 9;
                    lblNameSurname1.TextFont.Bold = true;
                    lblNameSurname1.TextFont.CharSet = 162;
                    lblNameSurname1.Value = @"Hasta Adı Soyadı";

                    lblIdentificationCardNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 21, 53, 26, false);
                    lblIdentificationCardNo1.Name = "lblIdentificationCardNo1";
                    lblIdentificationCardNo1.TextFont.Size = 9;
                    lblIdentificationCardNo1.TextFont.Bold = true;
                    lblIdentificationCardNo1.TextFont.CharSet = 162;
                    lblIdentificationCardNo1.Value = @"TC Kimlik No";

                    lblMatPrtNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 17, 72, 26, false);
                    lblMatPrtNo1.Name = "lblMatPrtNo1";
                    lblMatPrtNo1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblMatPrtNo1.MultiLine = EvetHayirEnum.ehEvet;
                    lblMatPrtNo1.WordBreak = EvetHayirEnum.ehEvet;
                    lblMatPrtNo1.TextFont.Size = 9;
                    lblMatPrtNo1.TextFont.Bold = true;
                    lblMatPrtNo1.TextFont.CharSet = 162;
                    lblMatPrtNo1.Value = @"Materyal Protokol No";

                    lblCatergory1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 21, 89, 26, false);
                    lblCatergory1.Name = "lblCatergory1";
                    lblCatergory1.TextFont.Size = 9;
                    lblCatergory1.TextFont.Bold = true;
                    lblCatergory1.TextFont.CharSet = 162;
                    lblCatergory1.Value = @"Kategori";

                    lblTest1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 21, 121, 26, false);
                    lblTest1.Name = "lblTest1";
                    lblTest1.TextFont.Size = 9;
                    lblTest1.TextFont.Bold = true;
                    lblTest1.TextFont.CharSet = 162;
                    lblTest1.Value = @"İşlem";

                    lblSnomedDiagnosis1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 21, 193, 26, false);
                    lblSnomedDiagnosis1.Name = "lblSnomedDiagnosis1";
                    lblSnomedDiagnosis1.TextFont.Size = 9;
                    lblSnomedDiagnosis1.TextFont.Bold = true;
                    lblSnomedDiagnosis1.TextFont.CharSet = 162;
                    lblSnomedDiagnosis1.Value = @"Snomed Tanı";

                    lblDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 21, 214, 26, false);
                    lblDate1.Name = "lblDate1";
                    lblDate1.TextFont.Size = 9;
                    lblDate1.TextFont.Bold = true;
                    lblDate1.TextFont.CharSet = 162;
                    lblDate1.Value = @"İşlem Tarihi";

                    lblResponsibleDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 21, 239, 26, false);
                    lblResponsibleDoctor1.Name = "lblResponsibleDoctor1";
                    lblResponsibleDoctor1.TextFont.Size = 9;
                    lblResponsibleDoctor1.TextFont.Bold = true;
                    lblResponsibleDoctor1.TextFont.CharSet = 162;
                    lblResponsibleDoctor1.Value = @"Sorumlu Tabip";

                    lblSpecialDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 21, 264, 26, false);
                    lblSpecialDoctor1.Name = "lblSpecialDoctor1";
                    lblSpecialDoctor1.TextFont.Size = 9;
                    lblSpecialDoctor1.TextFont.Bold = true;
                    lblSpecialDoctor1.TextFont.CharSet = 162;
                    lblSpecialDoctor1.Value = @"Uzman Tabip";

                    lblAssistantDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 21, 289, 26, false);
                    lblAssistantDoctor1.Name = "lblAssistantDoctor1";
                    lblAssistantDoctor1.TextFont.Size = 9;
                    lblAssistantDoctor1.TextFont.Bold = true;
                    lblAssistantDoctor1.TextFont.CharSet = 162;
                    lblAssistantDoctor1.Value = @"Yardımcı Tabip";

                    lblStartTime = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 10, 258, 15, false);
                    lblStartTime.Name = "lblStartTime";
                    lblStartTime.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblStartTime.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblStartTime.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblStartTime.TextFont.Size = 8;
                    lblStartTime.TextFont.CharSet = 162;
                    lblStartTime.Value = @"{@StartDate@}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 10, 263, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"|";

                    lblEndTime = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 10, 289, 15, false);
                    lblEndTime.Name = "lblEndTime";
                    lblEndTime.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblEndTime.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblEndTime.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblEndTime.TextFont.Size = 8;
                    lblEndTime.TextFont.CharSet = 162;
                    lblEndTime.Value = @"{@EndDate@}";

                    lblStartTime11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 5, 258, 10, false);
                    lblStartTime11.Name = "lblStartTime11";
                    lblStartTime11.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblStartTime11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblStartTime11.TextFont.Size = 8;
                    lblStartTime11.TextFont.Bold = true;
                    lblStartTime11.TextFont.Underline = true;
                    lblStartTime11.TextFont.CharSet = 162;
                    lblStartTime11.Value = @"Başlangıç Tarihi";

                    lblEndTime11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 5, 289, 10, false);
                    lblEndTime11.Name = "lblEndTime11";
                    lblEndTime11.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblEndTime11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblEndTime11.TextFont.Size = 8;
                    lblEndTime11.TextFont.Bold = true;
                    lblEndTime11.TextFont.Underline = true;
                    lblEndTime11.TextFont.CharSet = 162;
                    lblEndTime11.Value = @"Bitiş Tarihi";

                    lblDiagnosis1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 21, 156, 26, false);
                    lblDiagnosis1.Name = "lblDiagnosis1";
                    lblDiagnosis1.TextFont.Size = 9;
                    lblDiagnosis1.TextFont.Bold = true;
                    lblDiagnosis1.TextFont.CharSet = 162;
                    lblDiagnosis1.Value = @"Vaka Tanısı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lblHeader1.CalcValue = lblHeader1.Value;
                    lblNameSurname1.CalcValue = lblNameSurname1.Value;
                    lblIdentificationCardNo1.CalcValue = lblIdentificationCardNo1.Value;
                    lblMatPrtNo1.CalcValue = lblMatPrtNo1.Value;
                    lblCatergory1.CalcValue = lblCatergory1.Value;
                    lblTest1.CalcValue = lblTest1.Value;
                    lblSnomedDiagnosis1.CalcValue = lblSnomedDiagnosis1.Value;
                    lblDate1.CalcValue = lblDate1.Value;
                    lblResponsibleDoctor1.CalcValue = lblResponsibleDoctor1.Value;
                    lblSpecialDoctor1.CalcValue = lblSpecialDoctor1.Value;
                    lblAssistantDoctor1.CalcValue = lblAssistantDoctor1.Value;
                    lblStartTime.CalcValue = MyParentReport.RuntimeParameters.StartDate.ToString();
                    NewField12.CalcValue = NewField12.Value;
                    lblEndTime.CalcValue = MyParentReport.RuntimeParameters.EndDate.ToString();
                    lblStartTime11.CalcValue = lblStartTime11.Value;
                    lblEndTime11.CalcValue = lblEndTime11.Value;
                    lblDiagnosis1.CalcValue = lblDiagnosis1.Value;
                    return new TTReportObject[] { lblHeader1,lblNameSurname1,lblIdentificationCardNo1,lblMatPrtNo1,lblCatergory1,lblTest1,lblSnomedDiagnosis1,lblDate1,lblResponsibleDoctor1,lblSpecialDoctor1,lblAssistantDoctor1,lblStartTime,NewField12,lblEndTime,lblStartTime11,lblEndTime11,lblDiagnosis1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.AssistantDoctor))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.ASSISTANTDOCTOR_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.ASSISTANTDOCTOR_FLAG = 1;
            
            if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.SpecialDoctor))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.SPECIALDOCTOR_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.SPECIALDOCTOR_FLAG = 1;
            
            if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.ResponsibleDoctor))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.RESPONSIBLEDOCTOR_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.RESPONSIBLEDOCTOR_FLAG = 1;
            
            if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.MatPrtNoString))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.MATPRTNO_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.MATPRTNO_FLAG = 1;
            
            if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.Uniquerefno))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.UNIQUEREFNO_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.UNIQUEREFNO_FLAG = 1;
            
            //TODO ASLI
            //if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.TestCategory))
            //    ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.TESTCATEGORY_FLAG = 0;
            //else
            //    ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.TESTCATEGORY_FLAG = 1;
           
       
           // if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.Test))
           //     ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.TEST_FLAG = 0;
           // else
           //     ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.TEST_FLAG = 1;
            
            if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.SnomedDiagnosis))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.SNOMEDDIAGNOSIS_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.SNOMEDDIAGNOSIS_FLAG = 1;
            
            if (String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.Diagnosis))
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.DIAGNOSIS_FLAG = 0;
            else
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.DIAGNOSIS_FLAG = 1;
            
           /////////////////////////
            
            if (!String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.Uniquerefno))
            {
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.Uniquerefno = "%"+((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.Uniquerefno.Trim()+"%";
            }
            
            if (!String.IsNullOrEmpty(((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.MatPrtNoString))
            {
                ((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.MatPrtNoString = "%" +((PathologyStatisticsNewReport)ParentReport).RuntimeParameters.MatPrtNoString.Trim()+"%";
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public PathologyStatisticsNewReport MyParentReport
                {
                    get { return (PathologyStatisticsNewReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField NewField1; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 28;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 258, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 5, 289, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.Value = @"{@pagenumber@} / {@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyStatisticsNewReport MyParentReport
            {
                get { return (PathologyStatisticsNewReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblPatientNameSurname { get {return Body().lblPatientNameSurname;} }
            public TTReportField lblUniquerefNo { get {return Body().lblUniquerefNo;} }
            public TTReportField lblMatPrtNo { get {return Body().lblMatPrtNo;} }
            public TTReportField lblCatergory { get {return Body().lblCatergory;} }
            public TTReportField lblTest { get {return Body().lblTest;} }
            public TTReportField lblSnomedDiagnosis { get {return Body().lblSnomedDiagnosis;} }
            public TTReportField lblDate { get {return Body().lblDate;} }
            public TTReportField lblResponsibleDoctor { get {return Body().lblResponsibleDoctor;} }
            public TTReportField lblSpecialDoctor { get {return Body().lblSpecialDoctor;} }
            public TTReportField lblAssistantDoctor { get {return Body().lblAssistantDoctor;} }
            public TTReportField lblOBJECTID { get {return Body().lblOBJECTID;} }
            public TTReportField lblTESTCATEGORY { get {return Body().lblTESTCATEGORY;} }
            public TTReportField lblPATIENT { get {return Body().lblPATIENT;} }
            public TTReportField lblDiagnosis { get {return Body().lblDiagnosis;} }
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
                list[0] = new TTReportNqlData<Pathology.GetPathologyStatisticsNewNQL_Class>("GetPathologyStatisticsNewNQL", Pathology.GetPathologyStatisticsNewNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.AssistantDoctor),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ASSISTANTDOCTOR_FLAG),(string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(MyParentReport.RuntimeParameters.MatPrtNoString),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MATPRTNO_FLAG),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.ResponsibleDoctor),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.RESPONSIBLEDOCTOR_FLAG),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.SpecialDoctor),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.SPECIALDOCTOR_FLAG),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.EndDate),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.StartDate),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.TESTCATEGORY_FLAG),(string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue(MyParentReport.RuntimeParameters.Uniquerefno),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.UNIQUEREFNO_FLAG),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.TEST_FLAG),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.SnomedDiagnosis),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.SNOMEDDIAGNOSIS_FLAG),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.Diagnosis),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.DIAGNOSIS_FLAG)));
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
                public PathologyStatisticsNewReport MyParentReport
                {
                    get { return (PathologyStatisticsNewReport)ParentReport; }
                }
                
                public TTReportField lblPatientNameSurname;
                public TTReportField lblUniquerefNo;
                public TTReportField lblMatPrtNo;
                public TTReportField lblCatergory;
                public TTReportField lblTest;
                public TTReportField lblSnomedDiagnosis;
                public TTReportField lblDate;
                public TTReportField lblResponsibleDoctor;
                public TTReportField lblSpecialDoctor;
                public TTReportField lblAssistantDoctor;
                public TTReportField lblOBJECTID;
                public TTReportField lblTESTCATEGORY;
                public TTReportField lblPATIENT;
                public TTReportField lblDiagnosis; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    lblPatientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 34, 6, false);
                    lblPatientNameSurname.Name = "lblPatientNameSurname";
                    lblPatientNameSurname.TextFont.Size = 8;
                    lblPatientNameSurname.TextFont.CharSet = 162;
                    lblPatientNameSurname.Value = @"";

                    lblUniquerefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 53, 6, false);
                    lblUniquerefNo.Name = "lblUniquerefNo";
                    lblUniquerefNo.TextFont.Size = 8;
                    lblUniquerefNo.TextFont.CharSet = 162;
                    lblUniquerefNo.Value = @"";

                    lblMatPrtNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 1, 72, 6, false);
                    lblMatPrtNo.Name = "lblMatPrtNo";
                    lblMatPrtNo.TextFont.Size = 8;
                    lblMatPrtNo.TextFont.CharSet = 162;
                    lblMatPrtNo.Value = @"";

                    lblCatergory = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 1, 89, 6, false);
                    lblCatergory.Name = "lblCatergory";
                    lblCatergory.TextFont.Size = 7;
                    lblCatergory.TextFont.CharSet = 162;
                    lblCatergory.Value = @"";

                    lblTest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 1, 121, 6, false);
                    lblTest.Name = "lblTest";
                    lblTest.TextFont.Size = 7;
                    lblTest.TextFont.CharSet = 162;
                    lblTest.Value = @"";

                    lblSnomedDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 193, 6, false);
                    lblSnomedDiagnosis.Name = "lblSnomedDiagnosis";
                    lblSnomedDiagnosis.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblSnomedDiagnosis.TextFont.Size = 7;
                    lblSnomedDiagnosis.TextFont.CharSet = 162;
                    lblSnomedDiagnosis.Value = @"{#CODE#} {#NAME#}";

                    lblDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 1, 214, 6, false);
                    lblDate.Name = "lblDate";
                    lblDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblDate.TextFont.Size = 8;
                    lblDate.TextFont.CharSet = 162;
                    lblDate.Value = @"{#WORKLISTDATE#}";

                    lblResponsibleDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 239, 6, false);
                    lblResponsibleDoctor.Name = "lblResponsibleDoctor";
                    lblResponsibleDoctor.TextFont.Size = 7;
                    lblResponsibleDoctor.TextFont.CharSet = 162;
                    lblResponsibleDoctor.Value = @"";

                    lblSpecialDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 1, 264, 6, false);
                    lblSpecialDoctor.Name = "lblSpecialDoctor";
                    lblSpecialDoctor.TextFont.Size = 7;
                    lblSpecialDoctor.TextFont.CharSet = 162;
                    lblSpecialDoctor.Value = @"";

                    lblAssistantDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 1, 289, 6, false);
                    lblAssistantDoctor.Name = "lblAssistantDoctor";
                    lblAssistantDoctor.TextFont.Size = 7;
                    lblAssistantDoctor.TextFont.CharSet = 162;
                    lblAssistantDoctor.Value = @"";

                    lblOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 294, 1, 319, 6, false);
                    lblOBJECTID.Name = "lblOBJECTID";
                    lblOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    lblOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblOBJECTID.Value = @"{#OBJECTID#}";

                    lblTESTCATEGORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 294, 6, 319, 11, false);
                    lblTESTCATEGORY.Name = "lblTESTCATEGORY";
                    lblTESTCATEGORY.Visible = EvetHayirEnum.ehHayir;
                    lblTESTCATEGORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblTESTCATEGORY.Value = @"";

                    lblPATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 321, 1, 346, 6, false);
                    lblPATIENT.Name = "lblPATIENT";
                    lblPATIENT.Visible = EvetHayirEnum.ehHayir;
                    lblPATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblPATIENT.Value = @"{#PATIENT#}";

                    lblDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 156, 6, false);
                    lblDiagnosis.Name = "lblDiagnosis";
                    lblDiagnosis.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblDiagnosis.TextFont.Size = 7;
                    lblDiagnosis.TextFont.CharSet = 162;
                    lblDiagnosis.Value = @"{#DIAGNOSE_CODE#} {#DIAGNOSE_NAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.GetPathologyStatisticsNewNQL_Class dataset_GetPathologyStatisticsNewNQL = ParentGroup.rsGroup.GetCurrentRecord<Pathology.GetPathologyStatisticsNewNQL_Class>(0);
                    lblPatientNameSurname.CalcValue = lblPatientNameSurname.Value;
                    lblUniquerefNo.CalcValue = lblUniquerefNo.Value;
                    lblMatPrtNo.CalcValue = lblMatPrtNo.Value;
                    lblCatergory.CalcValue = lblCatergory.Value;
                    lblTest.CalcValue = lblTest.Value;
                    lblSnomedDiagnosis.CalcValue = (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.Code) : "") + @" " + (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.Name) : "");
                    lblDate.CalcValue = (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.WorkListDate) : "");
                    lblResponsibleDoctor.CalcValue = lblResponsibleDoctor.Value;
                    lblSpecialDoctor.CalcValue = lblSpecialDoctor.Value;
                    lblAssistantDoctor.CalcValue = lblAssistantDoctor.Value;
                    lblOBJECTID.CalcValue = (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.ObjectID) : "");
                    lblTESTCATEGORY.CalcValue = @"";
                    lblPATIENT.CalcValue = (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.Patient) : "");
                    lblDiagnosis.CalcValue = (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.Diagnose_code) : "") + @" " + (dataset_GetPathologyStatisticsNewNQL != null ? Globals.ToStringCore(dataset_GetPathologyStatisticsNewNQL.Diagnose_name) : "");
                    return new TTReportObject[] { lblPatientNameSurname,lblUniquerefNo,lblMatPrtNo,lblCatergory,lblTest,lblSnomedDiagnosis,lblDate,lblResponsibleDoctor,lblSpecialDoctor,lblAssistantDoctor,lblOBJECTID,lblTESTCATEGORY,lblPATIENT,lblDiagnosis};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.lblOBJECTID.CalcValue;
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            
            string sPatientID = this.lblPATIENT.CalcValue;
            if(!String.IsNullOrEmpty(sPatientID))
            {
                TTObjectClasses.Patient patient  = (TTObjectClasses.Patient)context.GetObject(new Guid(sPatientID),"Patient");
                
                if(patient != null)
                {
                    if(patient !=null)
                    {
                        if(!String.IsNullOrEmpty(patient.Name) && !String.IsNullOrEmpty(patient.Surname))
                        {
                            this.lblPatientNameSurname.CalcValue = patient.Name + " " + patient.Surname;
                        }
                        
                        this.lblUniquerefNo.CalcValue = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : " ";
                    }
                    
                }
            }
            
            /*
            if(pathologyTest.SnomedDiagnosis.Count > 0)
            {
                this.lblSnomedDiagnosis.CalcValue = pathologyTest.SnomedDiagnosis[0].SnomedDiagnose.Name.Trim();
            }
            */
            
            string sTestCategory = this.lblTESTCATEGORY.CalcValue;
            if(!String.IsNullOrEmpty(sTestCategory))
            {
                TTObjectClasses.PathologyTestCategoryDefinition testCategory = (TTObjectClasses.PathologyTestCategoryDefinition)context.GetObject(new Guid(sTestCategory),"PathologyTestCategoryDefinition");
                this.lblCatergory.CalcValue = testCategory.Name.Trim();
            }
            
            //TODO ASLI
            //PathologyTestDefinition testDef = (PathologyTestDefinition)pathologyTest.ProcedureObject;
            
            this.lblMatPrtNo.CalcValue = pathologyTest.MatPrtNoString != null ? pathologyTest.MatPrtNoString : " ";
            
            //this.lblTest.CalcValue = testDef.Code+ " " +testDef.Name;

            this.lblResponsibleDoctor.CalcValue = pathologyTest.ResponsibleDoctor != null ? pathologyTest.ResponsibleDoctor.Name : "";
            this.lblSpecialDoctor.CalcValue = pathologyTest.SpecialDoctor != null ? pathologyTest.SpecialDoctor.Name : "";
            this.lblAssistantDoctor.CalcValue = pathologyTest.AssistantDoctor != null ? pathologyTest.AssistantDoctor.Name : "";
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

        public PathologyStatisticsNewReport()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("StartDate", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("EndDate", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("Uniquerefno", "", "Hasta TC Kimlik Numarası", @"", false, true, false, new Guid("d3f7227f-34dd-423e-9041-fdfffd14f4a3"));
            reportParameter = Parameters.Add("UNIQUEREFNO_FLAG", "", "UNIQUEREFNO_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("MatPrtNoString", "", "Materyal Protokol No", @"", false, true, false, new Guid("d3f7227f-34dd-423e-9041-fdfffd14f4a3"));
            reportParameter = Parameters.Add("MATPRTNO_FLAG", "", "MATPRTNO_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("TESTCATEGORY_FLAG", "", "TESTCATEGORY_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("TEST_FLAG", "", "TEST_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("Diagnosis", "", "Vaka Tanısı", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f438d7e5-bd84-472a-92ef-5b63f94cc57e");
            reportParameter = Parameters.Add("DIAGNOSIS_FLAG", "", "DIAGNOSIS_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("SnomedDiagnosis", "", "Snomed Tanı", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("79f99eac-a0ba-40fc-a259-27983d49d7dc");
            reportParameter = Parameters.Add("SNOMEDDIAGNOSIS_FLAG", "", "SNOMEDDIAGNOSIS_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("ResponsibleDoctor", "", "Sorumlu Tabip", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter = Parameters.Add("RESPONSIBLEDOCTOR_FLAG", "", "RESPONSIBLEDOCTOR_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("SpecialDoctor", "", "Uzman Tabip", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter = Parameters.Add("SPECIALDOCTOR_FLAG", "", "SPECIALDOCTOR_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("AssistantDoctor", "", "Yardımcı Tabip", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter = Parameters.Add("ASSISTANTDOCTOR_FLAG", "", "ASSISTANTDOCTOR_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("StartDate"))
                _runtimeParameters.StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["StartDate"]);
            if (parameters.ContainsKey("EndDate"))
                _runtimeParameters.EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["EndDate"]);
            if (parameters.ContainsKey("Uniquerefno"))
                _runtimeParameters.Uniquerefno = (string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue(parameters["Uniquerefno"]);
            if (parameters.ContainsKey("UNIQUEREFNO_FLAG"))
                _runtimeParameters.UNIQUEREFNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["UNIQUEREFNO_FLAG"]);
            if (parameters.ContainsKey("MatPrtNoString"))
                _runtimeParameters.MatPrtNoString = (string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue(parameters["MatPrtNoString"]);
            if (parameters.ContainsKey("MATPRTNO_FLAG"))
                _runtimeParameters.MATPRTNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["MATPRTNO_FLAG"]);
            if (parameters.ContainsKey("TESTCATEGORY_FLAG"))
                _runtimeParameters.TESTCATEGORY_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["TESTCATEGORY_FLAG"]);
            if (parameters.ContainsKey("TEST_FLAG"))
                _runtimeParameters.TEST_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["TEST_FLAG"]);
            if (parameters.ContainsKey("Diagnosis"))
                _runtimeParameters.Diagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["Diagnosis"]);
            if (parameters.ContainsKey("DIAGNOSIS_FLAG"))
                _runtimeParameters.DIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["DIAGNOSIS_FLAG"]);
            if (parameters.ContainsKey("SnomedDiagnosis"))
                _runtimeParameters.SnomedDiagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["SnomedDiagnosis"]);
            if (parameters.ContainsKey("SNOMEDDIAGNOSIS_FLAG"))
                _runtimeParameters.SNOMEDDIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SNOMEDDIAGNOSIS_FLAG"]);
            if (parameters.ContainsKey("ResponsibleDoctor"))
                _runtimeParameters.ResponsibleDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ResponsibleDoctor"]);
            if (parameters.ContainsKey("RESPONSIBLEDOCTOR_FLAG"))
                _runtimeParameters.RESPONSIBLEDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESPONSIBLEDOCTOR_FLAG"]);
            if (parameters.ContainsKey("SpecialDoctor"))
                _runtimeParameters.SpecialDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["SpecialDoctor"]);
            if (parameters.ContainsKey("SPECIALDOCTOR_FLAG"))
                _runtimeParameters.SPECIALDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SPECIALDOCTOR_FLAG"]);
            if (parameters.ContainsKey("AssistantDoctor"))
                _runtimeParameters.AssistantDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["AssistantDoctor"]);
            if (parameters.ContainsKey("ASSISTANTDOCTOR_FLAG"))
                _runtimeParameters.ASSISTANTDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ASSISTANTDOCTOR_FLAG"]);
            Name = "PATHOLOGYSTATISTICSNEWREPORT";
            Caption = "Patoloji İstatistik Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 4;
            UserMarginTop = 4;
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