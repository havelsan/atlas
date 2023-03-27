
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
    /// Patoloji Sonuç Raporu
    /// </summary>
    public partial class PathologyTestResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class LastSectionGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public LastSectionGroupHeader Header()
            {
                return (LastSectionGroupHeader)_header;
            }

            new public LastSectionGroupFooter Footer()
            {
                return (LastSectionGroupFooter)_footer;
            }

            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField UserName1 { get {return Footer().UserName1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField PageCountCaution1 { get {return Footer().PageCountCaution1;} }
            public TTReportField FieldPageNumber1 { get {return Footer().FieldPageNumber1;} }
            public TTReportField FieldPageCount1 { get {return Footer().FieldPageCount1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField FieldPageNumber11 { get {return Footer().FieldPageNumber11;} }
            public LastSectionGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LastSectionGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LastSectionGroupHeader(this);
                _footer = new LastSectionGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class LastSectionGroupHeader : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                 
                public LastSectionGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class LastSectionGroupFooter : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1;
                public TTReportField PageCountCaution1;
                public TTReportField FieldPageNumber1;
                public TTReportField FieldPageCount1;
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField FieldPageNumber11; 
                public LastSectionGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 6, 201, 6, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 7, 37, 12, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate1.TextFont.Name = "Arial Narrow";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 7, 122, 12, false);
                    UserName1.Name = "UserName1";
                    UserName1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName1.TextFont.Name = "Arial Narrow";
                    UserName1.TextFont.Size = 8;
                    UserName1.TextFont.CharSet = 162;
                    UserName1.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 7, 201, 12, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.TextFont.Name = "Arial Narrow";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"{@pagenumber@} / {@pagecount@}";

                    PageCountCaution1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 108, 5, false);
                    PageCountCaution1.Name = "PageCountCaution1";
                    PageCountCaution1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageCountCaution1.TextFont.Name = "Arial";
                    PageCountCaution1.TextFont.Bold = true;
                    PageCountCaution1.TextFont.CharSet = 162;
                    PageCountCaution1.Value = @" sayfalık rapordur. ";

                    FieldPageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 0, 117, 5, false);
                    FieldPageNumber1.Name = "FieldPageNumber1";
                    FieldPageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FieldPageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FieldPageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FieldPageNumber1.TextFont.Name = "Arial";
                    FieldPageNumber1.TextFont.Bold = true;
                    FieldPageNumber1.TextFont.CharSet = 162;
                    FieldPageNumber1.Value = @"{@pagenumber@}";

                    FieldPageCount1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 77, 5, false);
                    FieldPageCount1.Name = "FieldPageCount1";
                    FieldPageCount1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FieldPageCount1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FieldPageCount1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FieldPageCount1.TextFont.Name = "Arial";
                    FieldPageCount1.TextFont.Bold = true;
                    FieldPageCount1.TextFont.CharSet = 162;
                    FieldPageCount1.Value = @"{@pagenumber@}/         {@pagecount@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 137, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @". sayfa  )";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 178, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İşlem Numarası :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 1, 201, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"{#ID#}";

                    FieldPageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 113, 5, false);
                    FieldPageNumber11.Name = "FieldPageNumber11";
                    FieldPageNumber11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FieldPageNumber11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FieldPageNumber11.TextFont.Name = "Arial";
                    FieldPageNumber11.TextFont.Bold = true;
                    FieldPageNumber11.TextFont.CharSet = 162;
                    FieldPageNumber11.Value = @"(";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    PageCountCaution1.CalcValue = PageCountCaution1.Value;
                    FieldPageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    FieldPageCount1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/         " + ParentReport.ReportTotalPageCount;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = (dataset_PathologyTestResultReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultReportQuery.ID) : "");
                    FieldPageNumber11.CalcValue = FieldPageNumber11.Value;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate1,PageNumber1,PageCountCaution1,FieldPageNumber1,FieldPageCount1,NewField11,NewField1,NewField12,FieldPageNumber11,UserName1};
                }
            }

        }

        public LastSectionGroup LastSection;

        public partial class HEADERGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField MaterialProtocolNo2 { get {return Header().MaterialProtocolNo2;} }
            public TTReportField lblPatientName { get {return Header().lblPatientName;} }
            public TTReportField lblPatientSex { get {return Header().lblPatientSex;} }
            public TTReportField lblPatientAge { get {return Header().lblPatientAge;} }
            public TTReportField lblPatientFatherName { get {return Header().lblPatientFatherName;} }
            public TTReportField lblTestReqDate { get {return Header().lblTestReqDate;} }
            public TTReportField lblTestAcceptionDate { get {return Header().lblTestAcceptionDate;} }
            public TTReportField lblFromResoure { get {return Header().lblFromResoure;} }
            public TTReportField lblPreDiagnosis { get {return Header().lblPreDiagnosis;} }
            public TTReportField dotsPatientName { get {return Header().dotsPatientName;} }
            public TTReportField dotsPatientSex { get {return Header().dotsPatientSex;} }
            public TTReportField dotsPatientAge { get {return Header().dotsPatientAge;} }
            public TTReportField dotsPatientFatherName { get {return Header().dotsPatientFatherName;} }
            public TTReportField dotsPreDiagnosis { get {return Header().dotsPreDiagnosis;} }
            public TTReportField dotsTestAcceptionDate { get {return Header().dotsTestAcceptionDate;} }
            public TTReportField dotsTestReqDate { get {return Header().dotsTestReqDate;} }
            public TTReportField dotsFromResoure { get {return Header().dotsFromResoure;} }
            public TTReportField lblPatientStatus { get {return Header().lblPatientStatus;} }
            public TTReportField dotsPatientStatus { get {return Header().dotsPatientStatus;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField PatientSex { get {return Header().PatientSex;} }
            public TTReportField PatientAge { get {return Header().PatientAge;} }
            public TTReportField PatientFatherName { get {return Header().PatientFatherName;} }
            public TTReportField FromResoure { get {return Header().FromResoure;} }
            public TTReportField PreDiagnosis { get {return Header().PreDiagnosis;} }
            public TTReportField PatientStatus { get {return Header().PatientStatus;} }
            public TTReportField TestRequestDate { get {return Header().TestRequestDate;} }
            public TTReportField TestAcceptionDate { get {return Header().TestAcceptionDate;} }
            public TTReportField lblBirthPlace { get {return Header().lblBirthPlace;} }
            public TTReportField dotsBirthPlace { get {return Header().dotsBirthPlace;} }
            public TTReportField BirthPlace { get {return Header().BirthPlace;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField lblRequestDoctor { get {return Header().lblRequestDoctor;} }
            public TTReportField dotsRequestDoctor { get {return Header().dotsRequestDoctor;} }
            public TTReportField RequestDoctor { get {return Header().RequestDoctor;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1132 { get {return Header().NewField1132;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField lblPatientGroup { get {return Header().lblPatientGroup;} }
            public TTReportField PatientGroup { get {return Header().PatientGroup;} }
            public TTReportField dotsPatientGroup { get {return Header().dotsPatientGroup;} }
            public TTReportField lblActionId { get {return Header().lblActionId;} }
            public TTReportField dotsActionId { get {return Header().dotsActionId;} }
            public TTReportField ActionId { get {return Header().ActionId;} }
            public TTReportField lblUniqueRefNo { get {return Header().lblUniqueRefNo;} }
            public TTReportField dotsUniqueRefNo { get {return Header().dotsUniqueRefNo;} }
            public TTReportField HASTATCNU { get {return Header().HASTATCNU;} }
            public TTReportField FKIMLIKNO { get {return Header().FKIMLIKNO;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField lblTestReqDate1 { get {return Header().lblTestReqDate1;} }
            public TTReportField dotsTestReqDate1 { get {return Header().dotsTestReqDate1;} }
            public TTReportField ttDateOfSampleTaken { get {return Header().ttDateOfSampleTaken;} }
            public TTReportField MaterialProtocolNo { get {return Header().MaterialProtocolNo;} }
            public TTReportField NewField11125111 { get {return Header().NewField11125111;} }
            public TTReportField NewField1115211 { get {return Footer().NewField1115211;} }
            public TTReportField SpecialDoctor { get {return Footer().SpecialDoctor;} }
            public TTReportField NewField11119111 { get {return Footer().NewField11119111;} }
            public TTReportField ResponsibleDoctor { get {return Footer().ResponsibleDoctor;} }
            public TTReportRTF RemoteDoctor { get {return Footer().RemoteDoctor;} }
            public TTReportField UZMANTABIB { get {return Footer().UZMANTABIB;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField HospitalName { get {return Footer().HospitalName;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField HospitalAddress { get {return Footer().HospitalAddress;} }
            public TTReportField Laboratuvar_İletişim_Bilgileri { get {return Footer().Laboratuvar_İletişim_Bilgileri;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField112411 { get {return Footer().NewField112411;} }
            public TTReportField ReportDate { get {return Footer().ReportDate;} }
            public TTReportField NewField1110211 { get {return Footer().NewField1110211;} }
            public TTReportField NewField1116211 { get {return Footer().NewField1116211;} }
            public TTReportField NewField11126111 { get {return Footer().NewField11126111;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[3];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultPatientInfoReportQuery_Class>("PathologyTestResultPatientInfoReportQuery", Pathology.PathologyTestResultPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<Pathology.PathologyTestReportQuery_Class>("PathologyTestReportQuery", Pathology.PathologyTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[2] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField MaterialProtocolNo2;
                public TTReportField lblPatientName;
                public TTReportField lblPatientSex;
                public TTReportField lblPatientAge;
                public TTReportField lblPatientFatherName;
                public TTReportField lblTestReqDate;
                public TTReportField lblTestAcceptionDate;
                public TTReportField lblFromResoure;
                public TTReportField lblPreDiagnosis;
                public TTReportField dotsPatientName;
                public TTReportField dotsPatientSex;
                public TTReportField dotsPatientAge;
                public TTReportField dotsPatientFatherName;
                public TTReportField dotsPreDiagnosis;
                public TTReportField dotsTestAcceptionDate;
                public TTReportField dotsTestReqDate;
                public TTReportField dotsFromResoure;
                public TTReportField lblPatientStatus;
                public TTReportField dotsPatientStatus;
                public TTReportField PatientName;
                public TTReportField PatientSex;
                public TTReportField PatientAge;
                public TTReportField PatientFatherName;
                public TTReportField FromResoure;
                public TTReportField PreDiagnosis;
                public TTReportField PatientStatus;
                public TTReportField TestRequestDate;
                public TTReportField TestAcceptionDate;
                public TTReportField lblBirthPlace;
                public TTReportField dotsBirthPlace;
                public TTReportField BirthPlace;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField REPORTHEADER1;
                public TTReportField lblRequestDoctor;
                public TTReportField dotsRequestDoctor;
                public TTReportField RequestDoctor;
                public TTReportField PROTOCOLNO;
                public TTReportField NewField122;
                public TTReportField NewField1132;
                public TTReportShape NewLine1111;
                public TTReportField lblPatientGroup;
                public TTReportField PatientGroup;
                public TTReportField dotsPatientGroup;
                public TTReportField lblActionId;
                public TTReportField dotsActionId;
                public TTReportField ActionId;
                public TTReportField lblUniqueRefNo;
                public TTReportField dotsUniqueRefNo;
                public TTReportField HASTATCNU;
                public TTReportField FKIMLIKNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField LOGO;
                public TTReportField lblTestReqDate1;
                public TTReportField dotsTestReqDate1;
                public TTReportField ttDateOfSampleTaken;
                public TTReportField MaterialProtocolNo;
                public TTReportField NewField11125111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 90;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MaterialProtocolNo2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 26, 200, 31, false);
                    MaterialProtocolNo2.Name = "MaterialProtocolNo2";
                    MaterialProtocolNo2.Visible = EvetHayirEnum.ehHayir;
                    MaterialProtocolNo2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialProtocolNo2.ObjectDefName = "PathologyTest";
                    MaterialProtocolNo2.DataMember = "MATPRTNOSTRING";
                    MaterialProtocolNo2.TextFont.Name = "Arial";
                    MaterialProtocolNo2.TextFont.Size = 9;
                    MaterialProtocolNo2.TextFont.CharSet = 162;
                    MaterialProtocolNo2.Value = @"{@TTOBJECTID@}";

                    lblPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 59, 43, 64, false);
                    lblPatientName.Name = "lblPatientName";
                    lblPatientName.TextFont.Name = "Arial Narrow";
                    lblPatientName.TextFont.Size = 9;
                    lblPatientName.TextFont.Bold = true;
                    lblPatientName.TextFont.CharSet = 162;
                    lblPatientName.Value = @"Hasta Adı";

                    lblPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 64, 43, 69, false);
                    lblPatientSex.Name = "lblPatientSex";
                    lblPatientSex.TextFont.Name = "Arial Narrow";
                    lblPatientSex.TextFont.Size = 9;
                    lblPatientSex.TextFont.Bold = true;
                    lblPatientSex.TextFont.CharSet = 162;
                    lblPatientSex.Value = @"Cinsiyeti";

                    lblPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 74, 43, 79, false);
                    lblPatientAge.Name = "lblPatientAge";
                    lblPatientAge.TextFont.Name = "Arial Narrow";
                    lblPatientAge.TextFont.Size = 9;
                    lblPatientAge.TextFont.Bold = true;
                    lblPatientAge.TextFont.CharSet = 162;
                    lblPatientAge.Value = @"Doğum Tarihi / Yaşı";

                    lblPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 79, 45, 84, false);
                    lblPatientFatherName.Name = "lblPatientFatherName";
                    lblPatientFatherName.TextFont.Name = "Arial Narrow";
                    lblPatientFatherName.TextFont.Size = 9;
                    lblPatientFatherName.TextFont.Bold = true;
                    lblPatientFatherName.TextFont.CharSet = 162;
                    lblPatientFatherName.Value = @"Baba Adı";

                    lblTestReqDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 74, 138, 79, false);
                    lblTestReqDate.Name = "lblTestReqDate";
                    lblTestReqDate.TextFont.Name = "Arial Narrow";
                    lblTestReqDate.TextFont.Size = 9;
                    lblTestReqDate.TextFont.Bold = true;
                    lblTestReqDate.TextFont.CharSet = 162;
                    lblTestReqDate.Value = @"Tetkik Kabul Tarihi";

                    lblTestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 69, 138, 74, false);
                    lblTestAcceptionDate.Name = "lblTestAcceptionDate";
                    lblTestAcceptionDate.TextFont.Name = "Arial Narrow";
                    lblTestAcceptionDate.TextFont.Size = 9;
                    lblTestAcceptionDate.TextFont.Bold = true;
                    lblTestAcceptionDate.TextFont.CharSet = 162;
                    lblTestAcceptionDate.Value = @"Tetkik İstek Tarihi";

                    lblFromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 84, 138, 89, false);
                    lblFromResoure.Name = "lblFromResoure";
                    lblFromResoure.TextFont.Name = "Arial Narrow";
                    lblFromResoure.TextFont.Size = 9;
                    lblFromResoure.TextFont.Bold = true;
                    lblFromResoure.TextFont.CharSet = 162;
                    lblFromResoure.Value = @"Gönderen Klinik";

                    lblPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 72, 239, 77, false);
                    lblPreDiagnosis.Name = "lblPreDiagnosis";
                    lblPreDiagnosis.Visible = EvetHayirEnum.ehHayir;
                    lblPreDiagnosis.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis.TextFont.Size = 9;
                    lblPreDiagnosis.TextFont.Bold = true;
                    lblPreDiagnosis.TextFont.CharSet = 162;
                    lblPreDiagnosis.Value = @"Ön Tanı";

                    dotsPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 59, 46, 64, false);
                    dotsPatientName.Name = "dotsPatientName";
                    dotsPatientName.TextFont.Name = "Arial Narrow";
                    dotsPatientName.TextFont.Size = 9;
                    dotsPatientName.TextFont.Bold = true;
                    dotsPatientName.TextFont.CharSet = 162;
                    dotsPatientName.Value = @":";

                    dotsPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 64, 46, 69, false);
                    dotsPatientSex.Name = "dotsPatientSex";
                    dotsPatientSex.TextFont.Name = "Arial Narrow";
                    dotsPatientSex.TextFont.Size = 9;
                    dotsPatientSex.TextFont.Bold = true;
                    dotsPatientSex.TextFont.CharSet = 162;
                    dotsPatientSex.Value = @":";

                    dotsPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 74, 46, 79, false);
                    dotsPatientAge.Name = "dotsPatientAge";
                    dotsPatientAge.TextFont.Name = "Arial Narrow";
                    dotsPatientAge.TextFont.Size = 9;
                    dotsPatientAge.TextFont.Bold = true;
                    dotsPatientAge.TextFont.CharSet = 162;
                    dotsPatientAge.Value = @":";

                    dotsPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 79, 46, 84, false);
                    dotsPatientFatherName.Name = "dotsPatientFatherName";
                    dotsPatientFatherName.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName.TextFont.Size = 9;
                    dotsPatientFatherName.TextFont.Bold = true;
                    dotsPatientFatherName.TextFont.CharSet = 162;
                    dotsPatientFatherName.Value = @":";

                    dotsPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 72, 243, 77, false);
                    dotsPreDiagnosis.Name = "dotsPreDiagnosis";
                    dotsPreDiagnosis.Visible = EvetHayirEnum.ehHayir;
                    dotsPreDiagnosis.TextFont.Name = "Arial Narrow";
                    dotsPreDiagnosis.TextFont.Size = 9;
                    dotsPreDiagnosis.TextFont.Bold = true;
                    dotsPreDiagnosis.TextFont.CharSet = 162;
                    dotsPreDiagnosis.Value = @":";

                    dotsTestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 69, 142, 74, false);
                    dotsTestAcceptionDate.Name = "dotsTestAcceptionDate";
                    dotsTestAcceptionDate.TextFont.Name = "Arial Narrow";
                    dotsTestAcceptionDate.TextFont.Size = 9;
                    dotsTestAcceptionDate.TextFont.Bold = true;
                    dotsTestAcceptionDate.TextFont.CharSet = 162;
                    dotsTestAcceptionDate.Value = @":";

                    dotsTestReqDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 74, 142, 79, false);
                    dotsTestReqDate.Name = "dotsTestReqDate";
                    dotsTestReqDate.TextFont.Name = "Arial Narrow";
                    dotsTestReqDate.TextFont.Size = 9;
                    dotsTestReqDate.TextFont.Bold = true;
                    dotsTestReqDate.TextFont.CharSet = 162;
                    dotsTestReqDate.Value = @":";

                    dotsFromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 84, 142, 89, false);
                    dotsFromResoure.Name = "dotsFromResoure";
                    dotsFromResoure.TextFont.Name = "Arial Narrow";
                    dotsFromResoure.TextFont.Size = 9;
                    dotsFromResoure.TextFont.Bold = true;
                    dotsFromResoure.TextFont.CharSet = 162;
                    dotsFromResoure.Value = @":";

                    lblPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 54, 138, 59, false);
                    lblPatientStatus.Name = "lblPatientStatus";
                    lblPatientStatus.TextFont.Name = "Arial Narrow";
                    lblPatientStatus.TextFont.Size = 9;
                    lblPatientStatus.TextFont.Bold = true;
                    lblPatientStatus.TextFont.CharSet = 162;
                    lblPatientStatus.Value = @"Hasta Tipi";

                    dotsPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 54, 142, 59, false);
                    dotsPatientStatus.Name = "dotsPatientStatus";
                    dotsPatientStatus.TextFont.Name = "Arial Narrow";
                    dotsPatientStatus.TextFont.Size = 9;
                    dotsPatientStatus.TextFont.Bold = true;
                    dotsPatientStatus.TextFont.CharSet = 162;
                    dotsPatientStatus.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 59, 108, 64, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    PatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 64, 108, 69, false);
                    PatientSex.Name = "PatientSex";
                    PatientSex.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSex.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSex.ObjectDefName = "SexEnum";
                    PatientSex.DataMember = "DISPLAYTEXT";
                    PatientSex.TextFont.Name = "Arial Narrow";
                    PatientSex.TextFont.Size = 9;
                    PatientSex.TextFont.CharSet = 162;
                    PatientSex.Value = @"{#SEX#}";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 74, 108, 79, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAge.TextFont.Name = "Arial Narrow";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"PatientAge";

                    PatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 79, 108, 84, false);
                    PatientFatherName.Name = "PatientFatherName";
                    PatientFatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientFatherName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientFatherName.TextFont.Name = "Arial Narrow";
                    PatientFatherName.TextFont.Size = 9;
                    PatientFatherName.TextFont.CharSet = 162;
                    PatientFatherName.Value = @"{#FATHERNAME#}";

                    FromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 84, 201, 89, false);
                    FromResoure.Name = "FromResoure";
                    FromResoure.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResoure.MultiLine = EvetHayirEnum.ehEvet;
                    FromResoure.TextFont.Name = "Arial Narrow";
                    FromResoure.TextFont.Size = 9;
                    FromResoure.TextFont.CharSet = 162;
                    FromResoure.Value = @"{#FROMRES#}";

                    PreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 72, 302, 77, false);
                    PreDiagnosis.Name = "PreDiagnosis";
                    PreDiagnosis.Visible = EvetHayirEnum.ehHayir;
                    PreDiagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    PreDiagnosis.NoClip = EvetHayirEnum.ehEvet;
                    PreDiagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    PreDiagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreDiagnosis.TextFont.Name = "Arial Narrow";
                    PreDiagnosis.TextFont.Size = 9;
                    PreDiagnosis.TextFont.CharSet = 162;
                    PreDiagnosis.Value = @"PreDiagnosis";

                    PatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 54, 201, 59, false);
                    PatientStatus.Name = "PatientStatus";
                    PatientStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus.TextFormat = @"Long Time";
                    PatientStatus.ObjectDefName = "PatientStatusEnum";
                    PatientStatus.DataMember = "DISPLAYTEXT";
                    PatientStatus.TextFont.Name = "Arial Narrow";
                    PatientStatus.TextFont.Size = 9;
                    PatientStatus.TextFont.CharSet = 162;
                    PatientStatus.Value = @"{#PATIENTSTATUS#}";

                    TestRequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 69, 201, 74, false);
                    TestRequestDate.Name = "TestRequestDate";
                    TestRequestDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    TestRequestDate.TextFont.Name = "Arial Narrow";
                    TestRequestDate.TextFont.Size = 9;
                    TestRequestDate.TextFont.CharSet = 162;
                    TestRequestDate.Value = @"";

                    TestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 74, 201, 79, false);
                    TestAcceptionDate.Name = "TestAcceptionDate";
                    TestAcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    TestAcceptionDate.TextFont.Name = "Arial Narrow";
                    TestAcceptionDate.TextFont.Size = 9;
                    TestAcceptionDate.TextFont.CharSet = 162;
                    TestAcceptionDate.Value = @"";

                    lblBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 69, 43, 74, false);
                    lblBirthPlace.Name = "lblBirthPlace";
                    lblBirthPlace.TextFont.Name = "Arial Narrow";
                    lblBirthPlace.TextFont.Size = 9;
                    lblBirthPlace.TextFont.Bold = true;
                    lblBirthPlace.TextFont.CharSet = 162;
                    lblBirthPlace.Value = @"Doğum Yeri";

                    dotsBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 69, 46, 74, false);
                    dotsBirthPlace.Name = "dotsBirthPlace";
                    dotsBirthPlace.TextFont.Name = "Arial Narrow";
                    dotsBirthPlace.TextFont.Size = 9;
                    dotsBirthPlace.TextFont.Bold = true;
                    dotsBirthPlace.TextFont.CharSet = 162;
                    dotsBirthPlace.Value = @":";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 69, 108, 74, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlace.TextFormat = @"Long Date";
                    BirthPlace.TextFont.Name = "Arial Narrow";
                    BirthPlace.TextFont.Size = 9;
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"{#CITYNAME#} - {#TOWNNAME#}";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 4, 174, 26, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 26, 174, 32, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.TextFont.CharSet = 162;
                    REPORTHEADER1.Value = @"PATOLOJİ SONUÇ RAPORU";

                    lblRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 79, 138, 84, false);
                    lblRequestDoctor.Name = "lblRequestDoctor";
                    lblRequestDoctor.TextFont.Name = "Arial Narrow";
                    lblRequestDoctor.TextFont.Size = 9;
                    lblRequestDoctor.TextFont.Bold = true;
                    lblRequestDoctor.TextFont.CharSet = 162;
                    lblRequestDoctor.Value = @"İstek Yapan Tabip";

                    dotsRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 79, 142, 84, false);
                    dotsRequestDoctor.Name = "dotsRequestDoctor";
                    dotsRequestDoctor.TextFont.Name = "Arial Narrow";
                    dotsRequestDoctor.TextFont.Size = 9;
                    dotsRequestDoctor.TextFont.Bold = true;
                    dotsRequestDoctor.TextFont.CharSet = 162;
                    dotsRequestDoctor.Value = @":";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 79, 201, 84, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.TextFont.Name = "Arial Narrow";
                    RequestDoctor.TextFont.Size = 9;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"RequestDoctor";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 44, 82, 49, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Name = "Arial Narrow";
                    PROTOCOLNO.TextFont.Size = 14;
                    PROTOCOLNO.TextFont.Bold = true;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#MATPRTNOSTRING!PathologyTestReportQuery#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 44, 43, 49, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"PATOLOJİ NO";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 44, 46, 49, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.TextFont.Name = "Arial Narrow";
                    NewField1132.TextFont.Size = 9;
                    NewField1132.TextFont.Bold = true;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @":";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 90, 200, 90, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    lblPatientGroup = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 59, 138, 64, false);
                    lblPatientGroup.Name = "lblPatientGroup";
                    lblPatientGroup.TextFont.Name = "Arial Narrow";
                    lblPatientGroup.TextFont.Size = 9;
                    lblPatientGroup.TextFont.Bold = true;
                    lblPatientGroup.TextFont.CharSet = 162;
                    lblPatientGroup.Value = @"Hasta Grubu";

                    PatientGroup = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 59, 201, 64, false);
                    PatientGroup.Name = "PatientGroup";
                    PatientGroup.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientGroup.TextFormat = @"Long Time";
                    PatientGroup.ObjectDefName = "PatientGroupEnum";
                    PatientGroup.DataMember = "DISPLAYTEXT";
                    PatientGroup.TextFont.Name = "Arial Narrow";
                    PatientGroup.TextFont.Size = 9;
                    PatientGroup.TextFont.CharSet = 162;
                    PatientGroup.Value = @"{#PATIENTGROUP#}";

                    dotsPatientGroup = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 59, 142, 64, false);
                    dotsPatientGroup.Name = "dotsPatientGroup";
                    dotsPatientGroup.TextFont.Name = "Arial Narrow";
                    dotsPatientGroup.TextFont.Size = 9;
                    dotsPatientGroup.TextFont.Bold = true;
                    dotsPatientGroup.TextFont.CharSet = 162;
                    dotsPatientGroup.Value = @":";

                    lblActionId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 17, 248, 22, false);
                    lblActionId.Name = "lblActionId";
                    lblActionId.Visible = EvetHayirEnum.ehHayir;
                    lblActionId.TextFont.Name = "Arial Narrow";
                    lblActionId.TextFont.Size = 9;
                    lblActionId.TextFont.Bold = true;
                    lblActionId.TextFont.CharSet = 162;
                    lblActionId.Value = @"İşlem Numarası";

                    dotsActionId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 22, 225, 27, false);
                    dotsActionId.Name = "dotsActionId";
                    dotsActionId.Visible = EvetHayirEnum.ehHayir;
                    dotsActionId.TextFont.Name = "Arial Narrow";
                    dotsActionId.TextFont.Size = 9;
                    dotsActionId.TextFont.Bold = true;
                    dotsActionId.TextFont.CharSet = 162;
                    dotsActionId.Value = @":";

                    ActionId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 22, 284, 27, false);
                    ActionId.Name = "ActionId";
                    ActionId.Visible = EvetHayirEnum.ehHayir;
                    ActionId.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionId.TextFont.Name = "Arial Narrow";
                    ActionId.TextFont.Size = 9;
                    ActionId.TextFont.CharSet = 162;
                    ActionId.Value = @"{#ID!PathologyTestResultReportQuery#}";

                    lblUniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 54, 38, 59, false);
                    lblUniqueRefNo.Name = "lblUniqueRefNo";
                    lblUniqueRefNo.TextFont.Name = "Arial Narrow";
                    lblUniqueRefNo.TextFont.Size = 9;
                    lblUniqueRefNo.TextFont.Bold = true;
                    lblUniqueRefNo.TextFont.CharSet = 162;
                    lblUniqueRefNo.Value = @"T.C.Kimlik Numarası";

                    dotsUniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 54, 46, 59, false);
                    dotsUniqueRefNo.Name = "dotsUniqueRefNo";
                    dotsUniqueRefNo.TextFont.Name = "Arial Narrow";
                    dotsUniqueRefNo.TextFont.Size = 9;
                    dotsUniqueRefNo.TextFont.Bold = true;
                    dotsUniqueRefNo.TextFont.CharSet = 162;
                    dotsUniqueRefNo.Value = @":";

                    HASTATCNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 54, 105, 59, false);
                    HASTATCNU.Name = "HASTATCNU";
                    HASTATCNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNU.TextFont.Name = "Arial Narrow";
                    HASTATCNU.TextFont.Size = 9;
                    HASTATCNU.TextFont.CharSet = 162;
                    HASTATCNU.Value = @"";

                    FKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 41, 237, 46, false);
                    FKIMLIKNO.Name = "FKIMLIKNO";
                    FKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    FKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FKIMLIKNO.TextFont.Name = "Arial Narrow";
                    FKIMLIKNO.Value = @"{#FOREIGNUNIQUEREFNO#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 50, 237, 55, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 4, 52, 27, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.Value = @"";

                    lblTestReqDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 64, 138, 69, false);
                    lblTestReqDate1.Name = "lblTestReqDate1";
                    lblTestReqDate1.TextFont.Name = "Arial Narrow";
                    lblTestReqDate1.TextFont.Size = 9;
                    lblTestReqDate1.TextFont.Bold = true;
                    lblTestReqDate1.TextFont.CharSet = 162;
                    lblTestReqDate1.Value = @"Örnek Alım Tarihi";

                    dotsTestReqDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 64, 142, 69, false);
                    dotsTestReqDate1.Name = "dotsTestReqDate1";
                    dotsTestReqDate1.TextFont.Name = "Arial Narrow";
                    dotsTestReqDate1.TextFont.Size = 9;
                    dotsTestReqDate1.TextFont.Bold = true;
                    dotsTestReqDate1.TextFont.CharSet = 162;
                    dotsTestReqDate1.Value = @":";

                    ttDateOfSampleTaken = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 64, 201, 69, false);
                    ttDateOfSampleTaken.Name = "ttDateOfSampleTaken";
                    ttDateOfSampleTaken.TextFormat = @"dd/MM/yyyy HH:mm";
                    ttDateOfSampleTaken.TextFont.Name = "Arial Narrow";
                    ttDateOfSampleTaken.TextFont.Size = 9;
                    ttDateOfSampleTaken.TextFont.CharSet = 162;
                    ttDateOfSampleTaken.Value = @"";

                    MaterialProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 36, 201, 53, false);
                    MaterialProtocolNo.Name = "MaterialProtocolNo";
                    MaterialProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialProtocolNo.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MaterialProtocolNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialProtocolNo.MultiLine = EvetHayirEnum.ehEvet;
                    MaterialProtocolNo.TextFont.Name = "Code39HalfInchTT-Regular";
                    MaterialProtocolNo.TextFont.Size = 32;
                    MaterialProtocolNo.TextFont.CharSet = 0;
                    MaterialProtocolNo.Value = @"{#MATPRTNOSTRING!PathologyTestReportQuery#}";

                    NewField11125111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 32, 201, 36, false);
                    NewField11125111.Name = "NewField11125111";
                    NewField11125111.TextFont.Name = "Arial Narrow";
                    NewField11125111.TextFont.Size = 9;
                    NewField11125111.TextFont.Bold = true;
                    NewField11125111.TextFont.CharSet = 162;
                    NewField11125111.Value = @"Materyal Protokol No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultPatientInfoReportQuery_Class dataset_PathologyTestResultPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultPatientInfoReportQuery_Class>(0);
                    Pathology.PathologyTestReportQuery_Class dataset_PathologyTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestReportQuery_Class>(1);
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(2);
                    MaterialProtocolNo2.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    MaterialProtocolNo2.PostFieldValueCalculation();
                    lblPatientName.CalcValue = lblPatientName.Value;
                    lblPatientSex.CalcValue = lblPatientSex.Value;
                    lblPatientAge.CalcValue = lblPatientAge.Value;
                    lblPatientFatherName.CalcValue = lblPatientFatherName.Value;
                    lblTestReqDate.CalcValue = lblTestReqDate.Value;
                    lblTestAcceptionDate.CalcValue = lblTestAcceptionDate.Value;
                    lblFromResoure.CalcValue = lblFromResoure.Value;
                    lblPreDiagnosis.CalcValue = lblPreDiagnosis.Value;
                    dotsPatientName.CalcValue = dotsPatientName.Value;
                    dotsPatientSex.CalcValue = dotsPatientSex.Value;
                    dotsPatientAge.CalcValue = dotsPatientAge.Value;
                    dotsPatientFatherName.CalcValue = dotsPatientFatherName.Value;
                    dotsPreDiagnosis.CalcValue = dotsPreDiagnosis.Value;
                    dotsTestAcceptionDate.CalcValue = dotsTestAcceptionDate.Value;
                    dotsTestReqDate.CalcValue = dotsTestReqDate.Value;
                    dotsFromResoure.CalcValue = dotsFromResoure.Value;
                    lblPatientStatus.CalcValue = lblPatientStatus.Value;
                    dotsPatientStatus.CalcValue = dotsPatientStatus.Value;
                    PatientName.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Name) : "") + @" " + (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Surname) : "");
                    PatientSex.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Sex) : "");
                    PatientSex.PostFieldValueCalculation();
                    PatientAge.CalcValue = PatientAge.Value;
                    PatientFatherName.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.FatherName) : "");
                    FromResoure.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Fromres) : "");
                    PreDiagnosis.CalcValue = PreDiagnosis.Value;
                    PatientStatus.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.PatientStatus) : "");
                    PatientStatus.PostFieldValueCalculation();
                    TestRequestDate.CalcValue = TestRequestDate.Value;
                    TestAcceptionDate.CalcValue = TestAcceptionDate.Value;
                    lblBirthPlace.CalcValue = lblBirthPlace.Value;
                    dotsBirthPlace.CalcValue = dotsBirthPlace.Value;
                    BirthPlace.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Cityname) : "") + @" - " + (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Townname) : "");
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    lblRequestDoctor.CalcValue = lblRequestDoctor.Value;
                    dotsRequestDoctor.CalcValue = dotsRequestDoctor.Value;
                    RequestDoctor.CalcValue = RequestDoctor.Value;
                    PROTOCOLNO.CalcValue = (dataset_PathologyTestReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestReportQuery.MatPrtNoString) : "");
                    NewField122.CalcValue = NewField122.Value;
                    NewField1132.CalcValue = NewField1132.Value;
                    lblPatientGroup.CalcValue = lblPatientGroup.Value;
                    PatientGroup.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Patientgroup) : "");
                    PatientGroup.PostFieldValueCalculation();
                    dotsPatientGroup.CalcValue = dotsPatientGroup.Value;
                    lblActionId.CalcValue = lblActionId.Value;
                    dotsActionId.CalcValue = dotsActionId.Value;
                    ActionId.CalcValue = (dataset_PathologyTestResultReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultReportQuery.ID) : "");
                    lblUniqueRefNo.CalcValue = lblUniqueRefNo.Value;
                    dotsUniqueRefNo.CalcValue = dotsUniqueRefNo.Value;
                    HASTATCNU.CalcValue = @"";
                    FKIMLIKNO.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.ForeignUniqueRefNo) : "");
                    TCKIMLIKNO.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.UniqueRefNo) : "");
                    LOGO.CalcValue = @"";
                    lblTestReqDate1.CalcValue = lblTestReqDate1.Value;
                    dotsTestReqDate1.CalcValue = dotsTestReqDate1.Value;
                    ttDateOfSampleTaken.CalcValue = ttDateOfSampleTaken.Value;
                    MaterialProtocolNo.CalcValue = (dataset_PathologyTestReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestReportQuery.MatPrtNoString) : "");
                    NewField11125111.CalcValue = NewField11125111.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { MaterialProtocolNo2,lblPatientName,lblPatientSex,lblPatientAge,lblPatientFatherName,lblTestReqDate,lblTestAcceptionDate,lblFromResoure,lblPreDiagnosis,dotsPatientName,dotsPatientSex,dotsPatientAge,dotsPatientFatherName,dotsPreDiagnosis,dotsTestAcceptionDate,dotsTestReqDate,dotsFromResoure,lblPatientStatus,dotsPatientStatus,PatientName,PatientSex,PatientAge,PatientFatherName,FromResoure,PreDiagnosis,PatientStatus,TestRequestDate,TestAcceptionDate,lblBirthPlace,dotsBirthPlace,BirthPlace,REPORTHEADER1,lblRequestDoctor,dotsRequestDoctor,RequestDoctor,PROTOCOLNO,NewField122,NewField1132,lblPatientGroup,PatientGroup,dotsPatientGroup,lblActionId,dotsActionId,ActionId,lblUniqueRefNo,dotsUniqueRefNo,HASTATCNU,FKIMLIKNO,TCKIMLIKNO,LOGO,lblTestReqDate1,dotsTestReqDate1,ttDateOfSampleTaken,MaterialProtocolNo,NewField11125111,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    //                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
//            
//            if(this.FKIMLIKNO.CalcValue != null && this.FKIMLIKNO.CalcValue != "")
//                    this.HASTATCNU.CalcValue = "(*)" + this.FKIMLIKNO.CalcValue;
//            else if(this.TCKIMLIKNO.CalcValue != null)
//                    this.HASTATCNU.CalcValue = this.TCKIMLIKNO.CalcValue;
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            
////            string preDiagnosis = null;
////            foreach(DiagnosisGrid dig in pObject.EpisodeAction.Episode.Diagnosis)
////            {
////                if(dig.DiagnosisType == DiagnosisTypeEnum.Primer)
////                    preDiagnosis = preDiagnosis + dig.Diagnose.Name.ToString() + ", " ;
////            }
////            this.PreDiagnosis.CalcValue = preDiagnosis;
//            
//            if(pObject.PathologyRequest.RequestDoctor != null)
//                this.RequestDoctor.CalcValue = pObject.PathologyRequest.RequestDoctor.Name;
//            else
//                this.RequestDoctor.CalcValue = "";
//            Patient patient = pObject.Episode.Patient; //TODO ASLI Kontrol et
//            if(patient.BirthDate.HasValue && patient.Age.HasValue)
//                this.PatientAge.CalcValue = patient.BirthDate.Value.ToShortDateString() + " / " + patient.Age.ToString();
//            if(patient.CityOfBirth == null && patient.TownOfBirth == null && patient.CountryOfBirth != null)
//                this.BirthPlace.CalcValue = patient.CountryOfBirth.ToString();
//            
//            if(pObject.PathologyRequest.RequestDate != null)
//                this.TestRequestDate.CalcValue = pObject.PathologyRequest.RequestDate.ToString();
//            
//            if(pObject.PathologyRequest.AcceptionDate != null)
//                this.TestAcceptionDate.CalcValue = pObject.PathologyRequest.AcceptionDate.ToString();
//            
//           // if(pObject.PathologyRequest.DateOfSampleTaken != null)
//           //     this.ttDateOfSampleTaken.CalcValue = pObject.PathologyRequest.DateOfSampleTaken.ToString();
//            
////            foreach (TTObjectState objectState in pObject.GetStateHistory())
////            {
////                if (objectState.StateDefID == PathologyTest.States.Procedure)
////                {
////                    //this.TestReqDate.CalcValue = objectState.BranchDate.ToLongDateString();
////                    
////                    //Bu alan istek doğrultusunda zamanı da gösterecek şekilde belirlenmiştir.
////                    this.TestReqDate.CalcValue = objectState.BranchDate.ToString();
////                }
////            }
//            
//            bool overridePrintRoles = TTObjectClasses.Common.OverridePrintRoles(TTObjectClasses.Common.CurrentUser);
//            
//            if(patient.SecurePerson == true && overridePrintRoles == false)
//            {
//                this.PatientName.Visible = this.dotsPatientName.Visible = this.lblPatientName.Visible = EvetHayirEnum.ehHayir;
//                this.PatientSex.Visible = this.dotsPatientSex.Visible = this.lblPatientSex.Visible = EvetHayirEnum.ehHayir;
//                this.BirthPlace.Visible = this.dotsBirthPlace.Visible = this.lblBirthPlace.Visible = EvetHayirEnum.ehHayir;
//                this.PatientAge.Visible = this.dotsPatientAge.Visible = this.lblPatientAge.Visible = EvetHayirEnum.ehHayir;
//                this.PatientFatherName.Visible = this.dotsPatientFatherName.Visible = this.lblPatientFatherName.Visible = EvetHayirEnum.ehHayir;
//                this.PatientStatus.Visible = this.dotsPatientStatus.Visible = this.lblPatientStatus.Visible = EvetHayirEnum.ehHayir;
//                this.FromResoure.Visible = this.dotsFromResoure.Visible = this.lblFromResoure.Visible = EvetHayirEnum.ehHayir;
//                this.RequestDoctor.Visible = this.dotsRequestDoctor.Visible = this.lblRequestDoctor.Visible = EvetHayirEnum.ehHayir;
//                this.PreDiagnosis.Visible = this.dotsPreDiagnosis.Visible = this.lblPreDiagnosis.Visible = EvetHayirEnum.ehHayir;
//                this.HASTATCNU.Visible = this.dotsUniqueRefNo.Visible = this.lblUniqueRefNo.Visible = EvetHayirEnum.ehHayir;
//            }
//            
//            //
////            string protocolNoText = this.PROTOCOLNO.CalcValue;
////            string protocolNoText_1 = protocolNoText.Substring(0,6);
////            string protocolNoText_2 = protocolNoText.Substring(6,4);
////            
////            this.PROTOCOLNO.CalcValue = protocolNoText_1+"-"+protocolNoText_2;
//            
            //
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField NewField1115211;
                public TTReportField SpecialDoctor;
                public TTReportField NewField11119111;
                public TTReportField ResponsibleDoctor;
                public TTReportRTF RemoteDoctor;
                public TTReportField UZMANTABIB;
                public TTReportField NewField11;
                public TTReportField HospitalName;
                public TTReportField NewField13;
                public TTReportField HospitalAddress;
                public TTReportField Laboratuvar_İletişim_Bilgileri;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField14;
                public TTReportField NewField1111;
                public TTReportField NewField112411;
                public TTReportField ReportDate;
                public TTReportField NewField1110211;
                public TTReportField NewField1116211;
                public TTReportField NewField11126111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 50;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 169, 6, false);
                    NewField1115211.Name = "NewField1115211";
                    NewField1115211.TextFont.Name = "Arial Narrow";
                    NewField1115211.TextFont.Size = 9;
                    NewField1115211.TextFont.Bold = true;
                    NewField1115211.TextFont.CharSet = 162;
                    NewField1115211.Value = @"Uzman Tabip";

                    SpecialDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 6, 201, 25, false);
                    SpecialDoctor.Name = "SpecialDoctor";
                    SpecialDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    SpecialDoctor.TextFont.Name = "Arial Narrow";
                    SpecialDoctor.TextFont.Size = 9;
                    SpecialDoctor.TextFont.CharSet = 162;
                    SpecialDoctor.Value = @"SpecialDoctor";

                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 37, 6, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial Narrow";
                    NewField11119111.TextFont.Size = 9;
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"Sorumlu Tabip";

                    ResponsibleDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 69, 25, false);
                    ResponsibleDoctor.Name = "ResponsibleDoctor";
                    ResponsibleDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    ResponsibleDoctor.TextFont.Name = "Arial Narrow";
                    ResponsibleDoctor.TextFont.Size = 9;
                    ResponsibleDoctor.TextFont.CharSet = 162;
                    ResponsibleDoctor.Value = @"ResponsibleDoctor";

                    RemoteDoctor = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 83, 6, 140, 25, false);
                    RemoteDoctor.Name = "RemoteDoctor";
                    RemoteDoctor.Value = @"";

                    UZMANTABIB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 1, 109, 6, false);
                    UZMANTABIB.Name = "UZMANTABIB";
                    UZMANTABIB.Visible = EvetHayirEnum.ehHayir;
                    UZMANTABIB.TextFont.Name = "Arial Narrow";
                    UZMANTABIB.TextFont.Size = 9;
                    UZMANTABIB.TextFont.Bold = true;
                    UZMANTABIB.TextFont.CharSet = 162;
                    UZMANTABIB.Value = @"Uzman Tabip";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 41, 40, 45, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"XXXXXXnin Adı:";

                    HospitalName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 41, 141, 45, false);
                    HospitalName.Name = "HospitalName";
                    HospitalName.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalName.TextFont.Name = "Arial Narrow";
                    HospitalName.TextFont.Size = 8;
                    HospitalName.TextFont.CharSet = 162;
                    HospitalName.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 45, 42, 50, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"XXXXXXnin Adresi:";

                    HospitalAddress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 45, 141, 49, false);
                    HospitalAddress.Name = "HospitalAddress";
                    HospitalAddress.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalAddress.TextFont.Name = "Arial Narrow";
                    HospitalAddress.TextFont.Size = 8;
                    HospitalAddress.TextFont.CharSet = 162;
                    HospitalAddress.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Laboratuvar_İletişim_Bilgileri = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 41, 201, 49, false);
                    Laboratuvar_İletişim_Bilgileri.Name = "Laboratuvar_İletişim_Bilgileri";
                    Laboratuvar_İletişim_Bilgileri.FieldType = ReportFieldTypeEnum.ftExpression;
                    Laboratuvar_İletişim_Bilgileri.MultiLine = EvetHayirEnum.ehEvet;
                    Laboratuvar_İletişim_Bilgileri.WordBreak = EvetHayirEnum.ehEvet;
                    Laboratuvar_İletişim_Bilgileri.TextFont.Name = "Arial Narrow";
                    Laboratuvar_İletişim_Bilgileri.TextFont.Size = 8;
                    Laboratuvar_İletişim_Bilgileri.TextFont.CharSet = 162;
                    Laboratuvar_İletişim_Bilgileri.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""PathologyLaboratoryInfo"", """") ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 40, 162, 45, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Telefon Nu :";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 44, 162, 48, false);
                    NewField16.Name = "NewField16";
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Fax Nu :";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 36, 201, 41, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Laboratuvar İletişim Bilgileri :";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 26, 37, 31, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Rapor Tarihi";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 26, 40, 31, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.TextFont.Name = "Arial Narrow";
                    NewField112411.TextFont.Size = 9;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.TextFont.CharSet = 162;
                    NewField112411.Value = @":";

                    ReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 26, 140, 31, false);
                    ReportDate.Name = "ReportDate";
                    ReportDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    ReportDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportDate.TextFont.Name = "Arial";
                    ReportDate.TextFont.Size = 9;
                    ReportDate.TextFont.CharSet = 162;
                    ReportDate.Value = @"";

                    NewField1110211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 31, 140, 36, false);
                    NewField1110211.Name = "NewField1110211";
                    NewField1110211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1110211.TextFont.Name = "Arial Narrow";
                    NewField1110211.TextFont.Size = 9;
                    NewField1110211.TextFont.CharSet = 162;
                    NewField1110211.Value = @"Bu rapor hasta tedavisi ve dosyası için düzenlenmiştir. İzinsiz olarak bilimsel yayın amacı ile kullanılamaz.";

                    NewField1116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 31, 20, 36, false);
                    NewField1116211.Name = "NewField1116211";
                    NewField1116211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116211.TextFont.Name = "Arial Narrow";
                    NewField1116211.TextFont.Size = 9;
                    NewField1116211.TextFont.Bold = true;
                    NewField1116211.TextFont.CharSet = 162;
                    NewField1116211.Value = @"Not :";

                    NewField11126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 36, 20, 41, false);
                    NewField11126111.Name = "NewField11126111";
                    NewField11126111.TextFont.Name = "Arial Narrow";
                    NewField11126111.TextFont.Size = 9;
                    NewField11126111.TextFont.Bold = true;
                    NewField11126111.TextFont.CharSet = 162;
                    NewField11126111.Value = @"B197";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultPatientInfoReportQuery_Class dataset_PathologyTestResultPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultPatientInfoReportQuery_Class>(0);
                    Pathology.PathologyTestReportQuery_Class dataset_PathologyTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestReportQuery_Class>(1);
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(2);
                    NewField1115211.CalcValue = NewField1115211.Value;
                    SpecialDoctor.CalcValue = SpecialDoctor.Value;
                    NewField11119111.CalcValue = NewField11119111.Value;
                    ResponsibleDoctor.CalcValue = ResponsibleDoctor.Value;
                    RemoteDoctor.CalcValue = RemoteDoctor.Value;
                    UZMANTABIB.CalcValue = UZMANTABIB.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    ReportDate.CalcValue = ReportDate.Value;
                    NewField1110211.CalcValue = NewField1110211.Value;
                    NewField1116211.CalcValue = NewField1116211.Value;
                    NewField11126111.CalcValue = NewField11126111.Value;
                    HospitalName.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") ;
                    HospitalAddress.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    Laboratuvar_İletişim_Bilgileri.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("PathologyLaboratoryInfo", "") ;
                    return new TTReportObject[] { NewField1115211,SpecialDoctor,NewField11119111,ResponsibleDoctor,RemoteDoctor,UZMANTABIB,NewField11,NewField13,NewField15,NewField16,NewField14,NewField1111,NewField112411,ReportDate,NewField1110211,NewField1116211,NewField11126111,HospitalName,HospitalAddress,Laboratuvar_İletişim_Bilgileri};
                }
                public override void RunPreScript()
                {
#region HEADER FOOTER_PreScript
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");

            if (pathologyTest.RemoteSpecialDoctor != null)
            {
                this.RemoteDoctor.Value = pathologyTest.RemoteSpecialDoctor.ToString();
                this.UZMANTABIB.Visible = EvetHayirEnum.ehEvet;
            }
#endregion HEADER FOOTER_PreScript
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    //                                    TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            
//            
//            if(pObject.RemoteSpecialDoctor != null && pObject.SpecialDoctor == null)
//                this.SpecialDoctor.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(pObject.RemoteSpecialDoctor.ToString());
//            else
//                this.SpecialDoctor.CalcValue = pObject.SpecialDoctor != null ? pObject.SpecialDoctor.SignatureBlock : String.Empty;
//            if(pObject.ResponsibleDoctor != null)
//                this.ResponsibleDoctor.CalcValue = pObject.ResponsibleDoctor.SignatureBlock;
//            else if(pObject.AssistantDoctor != null)
//                this.ResponsibleDoctor.CalcValue = pObject.AssistantDoctor.SignatureBlock;
//            else
//                this.ResponsibleDoctor.CalcValue = String.Empty;
//            
//            if(pObject.SpecialDoctor != null && pObject.ResponsibleDoctor != null)
//            {
//                if(pObject.SpecialDoctor.ObjectID == pObject.ResponsibleDoctor.ObjectID)
//                {
//                    this.SpecialDoctor.CalcValue = pObject.SpecialDoctor.SignatureBlock;
//                    this.ResponsibleDoctor.CalcValue = String.Empty;
//                }
//            }
//            
//            foreach (TTObjectState objectState in pObject.GetStateHistory())
//            {
//                if (objectState.StateDefID == Pathology.States.Report)
//                {
//                    this.ReportDate.CalcValue = objectState.BranchDate.ToString();
//                }
//            }
//            

            //            //Böyle kod mu olur, yaptım oldu.
            //            if(pObject.PathologyConsultantDoctors.Count == 1)
            //            {
            //                this.ConsultantDoctor1.CalcValue = pObject.PathologyConsultantDoctors[0].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[0].ConsultantDoctor.SignatureBlock : String.Empty ;
            //            }
            //            if(pObject.PathologyConsultantDoctors.Count == 2)
            //            {
            //                this.ConsultantDoctor1.CalcValue = pObject.PathologyConsultantDoctors[0].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[0].ConsultantDoctor.SignatureBlock : String.Empty ;
            //                this.ConsultantDoctor2.CalcValue = pObject.PathologyConsultantDoctors[1].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[1].ConsultantDoctor.SignatureBlock : String.Empty ;
            //            }
            //            if(pObject.PathologyConsultantDoctors.Count == 3)
            //            {
            //                this.ConsultantDoctor1.CalcValue = pObject.PathologyConsultantDoctors[0].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[0].ConsultantDoctor.SignatureBlock : String.Empty ;
            //                this.ConsultantDoctor2.CalcValue = pObject.PathologyConsultantDoctors[1].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[1].ConsultantDoctor.SignatureBlock : String.Empty ;
            //                this.ConsultantDoctor3.CalcValue = pObject.PathologyConsultantDoctors[2].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[2].ConsultantDoctor.SignatureBlock : String.Empty ;
            //            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class PAGEGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public PAGEGroupHeader Header()
            {
                return (PAGEGroupHeader)_header;
            }

            new public PAGEGroupFooter Footer()
            {
                return (PAGEGroupFooter)_footer;
            }

            public TTReportField lblPreDiagnosis1 { get {return Header().lblPreDiagnosis1;} }
            public TTReportField PreliminaryDiagnosis { get {return Header().PreliminaryDiagnosis;} }
            public TTReportField MaterialProtocolNo { get {return Footer().MaterialProtocolNo;} }
            public TTReportField NewField1115211 { get {return Footer().NewField1115211;} }
            public TTReportField ConsDoctorHeader { get {return Footer().ConsDoctorHeader;} }
            public TTReportField ConsultantDoctor1 { get {return Footer().ConsultantDoctor1;} }
            public TTReportField ConsultantDoctor3 { get {return Footer().ConsultantDoctor3;} }
            public TTReportField ConsultantDoctor2 { get {return Footer().ConsultantDoctor2;} }
            public PAGEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PAGEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PAGEGroupHeader(this);
                _footer = new PAGEGroupFooter(this);

            }

            public partial class PAGEGroupHeader : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblPreDiagnosis1;
                public TTReportField PreliminaryDiagnosis; 
                public PAGEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblPreDiagnosis1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 92, 6, false);
                    lblPreDiagnosis1.Name = "lblPreDiagnosis1";
                    lblPreDiagnosis1.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis1.TextFont.Bold = true;
                    lblPreDiagnosis1.TextFont.Underline = true;
                    lblPreDiagnosis1.TextFont.CharSet = 162;
                    lblPreDiagnosis1.Value = @"Ön Tanı";

                    PreliminaryDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 7, 201, 12, false);
                    PreliminaryDiagnosis.Name = "PreliminaryDiagnosis";
                    PreliminaryDiagnosis.TextFormat = @"Short Date";
                    PreliminaryDiagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    PreliminaryDiagnosis.NoClip = EvetHayirEnum.ehEvet;
                    PreliminaryDiagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    PreliminaryDiagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreliminaryDiagnosis.TextFont.Name = "Arial Narrow";
                    PreliminaryDiagnosis.TextFont.Size = 9;
                    PreliminaryDiagnosis.TextFont.CharSet = 162;
                    PreliminaryDiagnosis.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lblPreDiagnosis1.CalcValue = lblPreDiagnosis1.Value;
                    PreliminaryDiagnosis.CalcValue = PreliminaryDiagnosis.Value;
                    return new TTReportObject[] { lblPreDiagnosis1,PreliminaryDiagnosis};
                }

                public override void RunScript()
                {
#region PAGE HEADER_Script
                    //                                                            
//                    TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            
//            string preDiagnosis = null;
//            List<DiagnosisDefinition> distinctList = new List<DiagnosisDefinition>();
//
//            foreach(DiagnosisGrid dig in pObject.Episode.Diagnosis) //TODO ASLI Kontrol
//            {
//                if (dig.DiagnosisType == DiagnosisTypeEnum.Primer)
//                {
//                    if (distinctList.Contains(dig.Diagnose) == false)
//                    {
//                        preDiagnosis = preDiagnosis + dig.Diagnose.Code.ToString() + " " + dig.Diagnose.Name.ToString() + ",  ";
//                        distinctList.Add(dig.Diagnose);
//                    }
//                }
//            }
//            distinctList = null;
//
//            this.PreliminaryDiagnosis.CalcValue = preDiagnosis;
#endregion PAGE HEADER_Script
                }
            }
            public partial class PAGEGroupFooter : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField MaterialProtocolNo;
                public TTReportField NewField1115211;
                public TTReportField ConsDoctorHeader;
                public TTReportField ConsultantDoctor1;
                public TTReportField ConsultantDoctor3;
                public TTReportField ConsultantDoctor2; 
                public PAGEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MaterialProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 6, 276, 20, false);
                    MaterialProtocolNo.Name = "MaterialProtocolNo";
                    MaterialProtocolNo.Visible = EvetHayirEnum.ehHayir;
                    MaterialProtocolNo.MultiLine = EvetHayirEnum.ehEvet;
                    MaterialProtocolNo.TextFont.Name = "Code39HalfInchTT-Regular";
                    MaterialProtocolNo.TextFont.Size = 28;
                    MaterialProtocolNo.TextFont.CharSet = 0;
                    MaterialProtocolNo.Value = @"MaterialProtocolNo";

                    NewField1115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 241, 6, false);
                    NewField1115211.Name = "NewField1115211";
                    NewField1115211.Visible = EvetHayirEnum.ehHayir;
                    NewField1115211.TextFont.Name = "Arial Narrow";
                    NewField1115211.TextFont.Size = 9;
                    NewField1115211.TextFont.Bold = true;
                    NewField1115211.TextFont.CharSet = 162;
                    NewField1115211.Value = @"Materyal Protokol No";

                    ConsDoctorHeader = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 47, 5, false);
                    ConsDoctorHeader.Name = "ConsDoctorHeader";
                    ConsDoctorHeader.Visible = EvetHayirEnum.ehHayir;
                    ConsDoctorHeader.TextFont.Name = "Arial Narrow";
                    ConsDoctorHeader.TextFont.Size = 9;
                    ConsDoctorHeader.TextFont.Bold = true;
                    ConsDoctorHeader.TextFont.CharSet = 162;
                    ConsDoctorHeader.Value = @"Konsültan Doktorlar";

                    ConsultantDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 5, 69, 24, false);
                    ConsultantDoctor1.Name = "ConsultantDoctor1";
                    ConsultantDoctor1.MultiLine = EvetHayirEnum.ehEvet;
                    ConsultantDoctor1.TextFont.Name = "Arial Narrow";
                    ConsultantDoctor1.TextFont.Size = 9;
                    ConsultantDoctor1.TextFont.CharSet = 162;
                    ConsultantDoctor1.Value = @"";

                    ConsultantDoctor3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 5, 201, 24, false);
                    ConsultantDoctor3.Name = "ConsultantDoctor3";
                    ConsultantDoctor3.MultiLine = EvetHayirEnum.ehEvet;
                    ConsultantDoctor3.TextFont.Name = "Arial Narrow";
                    ConsultantDoctor3.TextFont.Size = 9;
                    ConsultantDoctor3.TextFont.CharSet = 162;
                    ConsultantDoctor3.Value = @"";

                    ConsultantDoctor2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 5, 140, 24, false);
                    ConsultantDoctor2.Name = "ConsultantDoctor2";
                    ConsultantDoctor2.MultiLine = EvetHayirEnum.ehEvet;
                    ConsultantDoctor2.TextFont.Name = "Arial Narrow";
                    ConsultantDoctor2.TextFont.Size = 9;
                    ConsultantDoctor2.TextFont.CharSet = 162;
                    ConsultantDoctor2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialProtocolNo.CalcValue = MaterialProtocolNo.Value;
                    NewField1115211.CalcValue = NewField1115211.Value;
                    ConsDoctorHeader.CalcValue = ConsDoctorHeader.Value;
                    ConsultantDoctor1.CalcValue = ConsultantDoctor1.Value;
                    ConsultantDoctor3.CalcValue = ConsultantDoctor3.Value;
                    ConsultantDoctor2.CalcValue = ConsultantDoctor2.Value;
                    return new TTReportObject[] { MaterialProtocolNo,NewField1115211,ConsDoctorHeader,ConsultantDoctor1,ConsultantDoctor3,ConsultantDoctor2};
                }

                public override void RunScript()
                {
#region PAGE FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            
            //Böyle kod mu olur, yaptım oldu.
            
            if(pObject.PathologyConsultantDoctors.Count > 0)
                this.ConsDoctorHeader.Visible = EvetHayirEnum.ehEvet;
            
            if(pObject.PathologyConsultantDoctors.Count == 1)
            {
                this.ConsultantDoctor1.CalcValue = pObject.PathologyConsultantDoctors[0].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[0].ConsultantDoctor.SignatureBlock : String.Empty ;
            }
            if(pObject.PathologyConsultantDoctors.Count == 2)
            {
                this.ConsultantDoctor1.CalcValue = pObject.PathologyConsultantDoctors[0].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[0].ConsultantDoctor.SignatureBlock : String.Empty ;
                this.ConsultantDoctor2.CalcValue = pObject.PathologyConsultantDoctors[1].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[1].ConsultantDoctor.SignatureBlock : String.Empty ;
            }
            if(pObject.PathologyConsultantDoctors.Count == 3)
            {
                this.ConsultantDoctor1.CalcValue = pObject.PathologyConsultantDoctors[0].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[0].ConsultantDoctor.SignatureBlock : String.Empty ;
                this.ConsultantDoctor2.CalcValue = pObject.PathologyConsultantDoctors[1].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[1].ConsultantDoctor.SignatureBlock : String.Empty ;
                this.ConsultantDoctor3.CalcValue = pObject.PathologyConsultantDoctors[2].ConsultantDoctor != null ? pObject.PathologyConsultantDoctors[2].ConsultantDoctor.SignatureBlock : String.Empty ;
            }
            
            
            //            foreach (TTObjectState objectState in pObject.GetStateHistory())
            //            {
            //                if (objectState.StateDefID == PathologyTest.States.Report)
            //                {
            //                    this.ReportDate.CalcValue = objectState.BranchDate.ToString();
            //                }
            //            }
//
            
            //this.ResponsibleDoctor.CalcValue = pObject.ResponsibleDoctor != null ? pObject.ResponsibleDoctor.SignatureBlock : String.Empty;
//            this.MaterialProtocolNo.CalcValue = pObject.MatPrtNoString;
//            this.testf.CalcValue = pObject.MatPrtNoString;
//
#endregion PAGE FOOTER_Script
                }
            }

        }

        public PAGEGroup PAGE;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblPreDiagnosis { get {return Body().lblPreDiagnosis;} }
            public TTReportField PreDiagnosisString { get {return Body().PreDiagnosisString;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField CATEGORY { get {return Body().CATEGORY;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField LOCALISATION { get {return Body().LOCALISATION;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<Pathology.PathologyTestReportQuery_Class>("PathologyTestReportQuery", Pathology.PathologyTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblPreDiagnosis;
                public TTReportField PreDiagnosisString;
                public TTReportField NewField12;
                public TTReportField CATEGORY;
                public TTReportField CODE;
                public TTReportField NAME;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField LOCALISATION;
                public TTReportField NewField1221; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 30;
                    RepeatCount = 0;
                    
                    lblPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 18, 92, 23, false);
                    lblPreDiagnosis.Name = "lblPreDiagnosis";
                    lblPreDiagnosis.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis.TextFont.Size = 11;
                    lblPreDiagnosis.TextFont.Bold = true;
                    lblPreDiagnosis.TextFont.Underline = true;
                    lblPreDiagnosis.TextFont.CharSet = 162;
                    lblPreDiagnosis.Value = @"Kısa Anamnez ve Klinik Bulgular :";

                    PreDiagnosisString = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 24, 201, 29, false);
                    PreDiagnosisString.Name = "PreDiagnosisString";
                    PreDiagnosisString.TextFormat = @"Short Date";
                    PreDiagnosisString.MultiLine = EvetHayirEnum.ehEvet;
                    PreDiagnosisString.NoClip = EvetHayirEnum.ehEvet;
                    PreDiagnosisString.WordBreak = EvetHayirEnum.ehEvet;
                    PreDiagnosisString.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreDiagnosisString.TextFont.Name = "Arial Narrow";
                    PreDiagnosisString.TextFont.Size = 9;
                    PreDiagnosisString.TextFont.CharSet = 162;
                    PreDiagnosisString.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 7, 31, 12, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.Underline = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"SUT Kodu";

                    CATEGORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 12, 53, 17, false);
                    CATEGORY.Name = "CATEGORY";
                    CATEGORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    CATEGORY.TextFont.Name = "Arial Narrow";
                    CATEGORY.TextFont.CharSet = 162;
                    CATEGORY.Value = @"";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 12, 31, 17, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 12, 141, 17, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 7, 53, 12, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.Underline = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Örnek";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 7, 77, 12, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.Underline = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"İşlem";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 34, 6, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"Yapılan Tetkik";

                    LOCALISATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 12, 201, 17, false);
                    LOCALISATION.Name = "LOCALISATION";
                    LOCALISATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOCALISATION.TextFont.Name = "Arial Narrow";
                    LOCALISATION.TextFont.CharSet = 162;
                    LOCALISATION.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 7, 164, 12, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.Underline = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Lokalizasyon";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    Pathology.PathologyTestReportQuery_Class dataset_PathologyTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestReportQuery_Class>(1);
                    lblPreDiagnosis.CalcValue = lblPreDiagnosis.Value;
                    PreDiagnosisString.CalcValue = PreDiagnosisString.Value;
                    NewField12.CalcValue = NewField12.Value;
                    CATEGORY.CalcValue = @"";
                    CODE.CalcValue = @"";
                    NAME.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    LOCALISATION.CalcValue = @"";
                    NewField1221.CalcValue = NewField1221.Value;
                    return new TTReportObject[] { lblPreDiagnosis,PreDiagnosisString,NewField12,CATEGORY,CODE,NAME,NewField121,NewField122,NewField123,LOCALISATION,NewField1221};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MakroskopiGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public MakroskopiGroupBody Body()
            {
                return (MakroskopiGroupBody)_body;
            }
            public TTReportRTF RepMacroscopy { get {return Body().RepMacroscopy;} }
            public TTReportField lblMacroscopy { get {return Body().lblMacroscopy;} }
            public MakroskopiGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MakroskopiGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MakroskopiGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MakroskopiGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportRTF RepMacroscopy;
                public TTReportField lblMacroscopy; 
                public MakroskopiGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    RepMacroscopy = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 6, 201, 11, false);
                    RepMacroscopy.Name = "RepMacroscopy";
                    RepMacroscopy.EvaluateValue = EvetHayirEnum.ehEvet;
                    RepMacroscopy.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    lblMacroscopy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 40, 6, false);
                    lblMacroscopy.Name = "lblMacroscopy";
                    lblMacroscopy.TextFont.Name = "Arial Narrow";
                    lblMacroscopy.TextFont.Size = 11;
                    lblMacroscopy.TextFont.Bold = true;
                    lblMacroscopy.TextFont.Underline = true;
                    lblMacroscopy.TextFont.CharSet = 162;
                    lblMacroscopy.Value = @"Makroskopi :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    RepMacroscopy.CalcValue = RepMacroscopy.Value;
                    lblMacroscopy.CalcValue = lblMacroscopy.Value;
                    return new TTReportObject[] { RepMacroscopy,lblMacroscopy};
                }

                public override void RunScript()
                {
#region MAKROSKOPI BODY_Script
                    //                                                                                                                        
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            if(pObject.ReportMacroscopi != null)
//                this.RepMacroscopy.CalcValue = pObject.ReportMacroscopi.ToString();
//            //lblMacroscopy.Visible = pObject.ReportMacroscopi != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
//            IsVisible = pObject.ReportMacroscopi != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
#endregion MAKROSKOPI BODY_Script
                }
            }

        }

        public MakroskopiGroup Makroskopi;

        public partial class MikroskopiGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public MikroskopiGroupBody Body()
            {
                return (MikroskopiGroupBody)_body;
            }
            public TTReportField lblMicroscopy { get {return Body().lblMicroscopy;} }
            public TTReportRTF RepMicroscopy { get {return Body().RepMicroscopy;} }
            public MikroskopiGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MikroskopiGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MikroskopiGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MikroskopiGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblMicroscopy;
                public TTReportRTF RepMicroscopy; 
                public MikroskopiGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    lblMicroscopy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 39, 6, false);
                    lblMicroscopy.Name = "lblMicroscopy";
                    lblMicroscopy.TextFont.Name = "Arial Narrow";
                    lblMicroscopy.TextFont.Size = 11;
                    lblMicroscopy.TextFont.Bold = true;
                    lblMicroscopy.TextFont.Underline = true;
                    lblMicroscopy.TextFont.CharSet = 162;
                    lblMicroscopy.Value = @"Mikroskopi :";

                    RepMicroscopy = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 6, 201, 11, false);
                    RepMicroscopy.Name = "RepMicroscopy";
                    RepMicroscopy.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    lblMicroscopy.CalcValue = lblMicroscopy.Value;
                    RepMicroscopy.CalcValue = RepMicroscopy.Value;
                    return new TTReportObject[] { lblMicroscopy,RepMicroscopy};
                }

                public override void RunScript()
                {
#region MIKROSKOPI BODY_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            if(pObject.ReportMicroscopi != null)
//                this.RepMicroscopy.CalcValue = pObject.ReportMicroscopi.ToString();
//            //lblMicroscopy.Visible = pObject.ReportMicroscopi != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
//            IsVisible = pObject.ReportMicroscopi != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
#endregion MIKROSKOPI BODY_Script
                }
            }

        }

        public MikroskopiGroup Mikroskopi;

        public partial class DokuIslemGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public DokuIslemGroupBody Body()
            {
                return (DokuIslemGroupBody)_body;
            }
            public TTReportField lblTissue { get {return Body().lblTissue;} }
            public TTReportRTF RepTissueProc { get {return Body().RepTissueProc;} }
            public DokuIslemGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DokuIslemGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DokuIslemGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DokuIslemGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblTissue;
                public TTReportRTF RepTissueProc; 
                public DokuIslemGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    lblTissue = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 41, 6, false);
                    lblTissue.Name = "lblTissue";
                    lblTissue.TextFont.Name = "Arial Narrow";
                    lblTissue.TextFont.Size = 11;
                    lblTissue.TextFont.Bold = true;
                    lblTissue.TextFont.Underline = true;
                    lblTissue.TextFont.CharSet = 162;
                    lblTissue.Value = @"Doku İşlemi :";

                    RepTissueProc = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 6, 201, 11, false);
                    RepTissueProc.Name = "RepTissueProc";
                    RepTissueProc.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    lblTissue.CalcValue = lblTissue.Value;
                    RepTissueProc.CalcValue = RepTissueProc.Value;
                    return new TTReportObject[] { lblTissue,RepTissueProc};
                }

                public override void RunScript()
                {
#region DOKUISLEM BODY_Script
                    //                                                                                                                                                 
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            if(pObject.ReportTissueProcedure != null)
//                this.RepTissueProc.CalcValue = pObject.ReportTissueProcedure.ToString();
//            //lblTissue.Visible = pObject.ReportTissueProcedure != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
//            IsVisible = pObject.ReportTissueProcedure != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
#endregion DOKUISLEM BODY_Script
                }
            }

        }

        public DokuIslemGroup DokuIslem;

        public partial class EkIslemlerGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public EkIslemlerGroupBody Body()
            {
                return (EkIslemlerGroupBody)_body;
            }
            public TTReportField lblAdditional { get {return Body().lblAdditional;} }
            public TTReportRTF RepAddProc { get {return Body().RepAddProc;} }
            public EkIslemlerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public EkIslemlerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new EkIslemlerGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class EkIslemlerGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblAdditional;
                public TTReportRTF RepAddProc; 
                public EkIslemlerGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    lblAdditional = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 40, 6, false);
                    lblAdditional.Name = "lblAdditional";
                    lblAdditional.TextFont.Name = "Arial Narrow";
                    lblAdditional.TextFont.Size = 11;
                    lblAdditional.TextFont.Bold = true;
                    lblAdditional.TextFont.Underline = true;
                    lblAdditional.TextFont.CharSet = 162;
                    lblAdditional.Value = @"Ek İşlemler :";

                    RepAddProc = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 6, 201, 10, false);
                    RepAddProc.Name = "RepAddProc";
                    RepAddProc.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    lblAdditional.CalcValue = lblAdditional.Value;
                    RepAddProc.CalcValue = RepAddProc.Value;
                    return new TTReportObject[] { lblAdditional,RepAddProc};
                }

                public override void RunScript()
                {
#region EKISLEMLER BODY_Script
                    //                                                                                                                                     
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            if(pObject.ReportAdditionalOperation != null)
//                this.RepAddProc.CalcValue = pObject.ReportAdditionalOperation.ToString();
//            IsVisible = pObject.ReportAdditionalOperation != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
//            //lblAdditional.Visible = pObject.ReportAdditionalOperation != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
#endregion EKISLEMLER BODY_Script
                }
            }

        }

        public EkIslemlerGroup EkIslemler;

        public partial class TaniGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public TaniGroupBody Body()
            {
                return (TaniGroupBody)_body;
            }
            public TTReportField lblDiagnosis { get {return Body().lblDiagnosis;} }
            public TTReportRTF RepDiagnosis { get {return Body().RepDiagnosis;} }
            public TaniGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TaniGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultReportQuery_Class>("PathologyTestResultReportQuery", Pathology.PathologyTestResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TaniGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TaniGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblDiagnosis;
                public TTReportRTF RepDiagnosis; 
                public TaniGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    lblDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 37, 6, false);
                    lblDiagnosis.Name = "lblDiagnosis";
                    lblDiagnosis.TextFont.Name = "Arial Narrow";
                    lblDiagnosis.TextFont.Size = 11;
                    lblDiagnosis.TextFont.Bold = true;
                    lblDiagnosis.TextFont.Underline = true;
                    lblDiagnosis.TextFont.CharSet = 162;
                    lblDiagnosis.Value = @"Tanı :";

                    RepDiagnosis = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 6, 201, 11, false);
                    RepDiagnosis.Name = "RepDiagnosis";
                    RepDiagnosis.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultReportQuery_Class dataset_PathologyTestResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultReportQuery_Class>(0);
                    lblDiagnosis.CalcValue = lblDiagnosis.Value;
                    RepDiagnosis.CalcValue = RepDiagnosis.Value;
                    return new TTReportObject[] { lblDiagnosis,RepDiagnosis};
                }

                public override void RunScript()
                {
#region TANI BODY_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            if(pObject.ReportDiagnoseComment != null)
//                this.RepDiagnosis.CalcValue = pObject.ReportDiagnoseComment.ToString();
//            //lblDiagnosis.Visible = pObject.ReportDiagnoseComment != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
//            IsVisible = pObject.ReportDiagnoseComment != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
#endregion TANI BODY_Script
                }
            }

        }

        public TaniGroup Tani;

        public partial class PROCEDURESGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public PROCEDURESGroupBody Body()
            {
                return (PROCEDURESGroupBody)_body;
            }
            public TTReportField lblLaboratoryResults { get {return Body().lblLaboratoryResults;} }
            public TTReportRTF RepLaboratory { get {return Body().RepLaboratory;} }
            public PROCEDURESGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCEDURESGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PROCEDURESGroupBody(this);
            }

            public partial class PROCEDURESGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblLaboratoryResults;
                public TTReportRTF RepLaboratory; 
                public PROCEDURESGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    lblLaboratoryResults = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 55, 6, false);
                    lblLaboratoryResults.Name = "lblLaboratoryResults";
                    lblLaboratoryResults.TextFont.Name = "Arial Narrow";
                    lblLaboratoryResults.TextFont.Size = 11;
                    lblLaboratoryResults.TextFont.Bold = true;
                    lblLaboratoryResults.TextFont.Underline = true;
                    lblLaboratoryResults.TextFont.CharSet = 162;
                    lblLaboratoryResults.Value = @"Laboratuvar Sonuçları :";

                    RepLaboratory = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 6, 201, 11, false);
                    RepLaboratory.Name = "RepLaboratory";
                    RepLaboratory.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lblLaboratoryResults.CalcValue = lblLaboratoryResults.Value;
                    RepLaboratory.CalcValue = RepLaboratory.Value;
                    return new TTReportObject[] { lblLaboratoryResults,RepLaboratory};
                }

                public override void RunScript()
                {
#region PROCEDURES BODY_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            if(pObject.ReportLaboratory != null)
//                this.RepLaboratory.CalcValue = pObject.ReportLaboratory.ToString();
//            //lblLaboratoryResults.Visible = pObject.ReportLaboratory != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
//            IsVisible = pObject.ReportLaboratory != null ? EvetHayirEnum.ehEvet : EvetHayirEnum.ehHayir;
#endregion PROCEDURES BODY_Script
                }
            }

        }

        public PROCEDURESGroup PROCEDURES;

        public partial class OzelIslemlerGroup : TTReportGroup
        {
            public PathologyTestResultReport MyParentReport
            {
                get { return (PathologyTestResultReport)ParentReport; }
            }

            new public OzelIslemlerGroupBody Body()
            {
                return (OzelIslemlerGroupBody)_body;
            }
            public TTReportRTF RtfOzelIslemler { get {return Body().RtfOzelIslemler;} }
            public OzelIslemlerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OzelIslemlerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new OzelIslemlerGroupBody(this);
            }

            public partial class OzelIslemlerGroupBody : TTReportSection
            {
                public PathologyTestResultReport MyParentReport
                {
                    get { return (PathologyTestResultReport)ParentReport; }
                }
                
                public TTReportRTF RtfOzelIslemler; 
                public OzelIslemlerGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    RtfOzelIslemler = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 12, 1, 201, 6, false);
                    RtfOzelIslemler.Name = "RtfOzelIslemler";
                    RtfOzelIslemler.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RtfOzelIslemler.CalcValue = RtfOzelIslemler.Value;
                    return new TTReportObject[] { RtfOzelIslemler};
                }

                public override void RunScript()
                {
#region OZELISLEMLER BODY_Script
                    //                                                                        
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            StringBuilder builder = new StringBuilder();
//            foreach(PathologySpecialProcedure specProc in pObject.PathologySpecialProcedures)
//            {
//                builder.Append(specProc.SubMatPrtNoString + " - ");
//                builder.Append(specProc.ProcedureObject.Name + " ");
//                builder.Append("(" + specProc.ProcedureObject.SUTCode + ")\r\n");
//            }
//            this.RtfOzelIslemler.Value = TTObjectClasses.Common.GetRTFOfTextString(builder.ToString());
           
            //if(pObject.ReportDiagnoseComment != null)
            //    this.RepDiagnosis.CalcValue = pObject.ReportDiagnoseComment.ToString();
#endregion OZELISLEMLER BODY_Script
                }
            }

        }

        public OzelIslemlerGroup OzelIslemler;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PathologyTestResultReport()
        {
            LastSection = new LastSectionGroup(this,"LastSection");
            HEADER = new HEADERGroup(LastSection,"HEADER");
            PAGE = new PAGEGroup(HEADER,"PAGE");
            MAIN = new MAINGroup(PAGE,"MAIN");
            Makroskopi = new MakroskopiGroup(PAGE,"Makroskopi");
            Mikroskopi = new MikroskopiGroup(PAGE,"Mikroskopi");
            DokuIslem = new DokuIslemGroup(PAGE,"DokuIslem");
            EkIslemler = new EkIslemlerGroup(PAGE,"EkIslemler");
            Tani = new TaniGroup(PAGE,"Tani");
            PROCEDURES = new PROCEDURESGroup(PAGE,"PROCEDURES");
            OzelIslemler = new OzelIslemlerGroup(PAGE,"OzelIslemler");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYTESTRESULTREPORT";
            Caption = "Patoloji Sonuç Raporu";
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
            fd.TextFont.Name = "Courier New";
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