
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
    public partial class PathologyResultReportNew : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class LastSectionGroup : TTReportGroup
        {
            public PathologyResultReportNew MyParentReport
            {
                get { return (PathologyResultReportNew)ParentReport; }
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
            public TTReportField FieldPageNumber11 { get {return Footer().FieldPageNumber11;} }
            public LastSectionGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LastSectionGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LastSectionGroupHeader(this);
                _footer = new LastSectionGroupFooter(this);

            }

            public partial class LastSectionGroupHeader : TTReportSection
            {
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
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
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1;
                public TTReportField PageCountCaution1;
                public TTReportField FieldPageNumber1;
                public TTReportField FieldPageCount1;
                public TTReportField NewField11;
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

                    FieldPageCount1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 77, 5, false);
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
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    PageCountCaution1.CalcValue = PageCountCaution1.Value;
                    FieldPageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    FieldPageCount1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/         " + ParentReport.ReportTotalPageCount;
                    NewField11.CalcValue = NewField11.Value;
                    FieldPageNumber11.CalcValue = FieldPageNumber11.Value;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate1,PageNumber1,PageCountCaution1,FieldPageNumber1,FieldPageCount1,NewField11,FieldPageNumber11,UserName1};
                }
            }

        }

        public LastSectionGroup LastSection;

        public partial class HEADERGroup : TTReportGroup
        {
            public PathologyResultReportNew MyParentReport
            {
                get { return (PathologyResultReportNew)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField lblPatientName { get {return Header().lblPatientName;} }
            public TTReportField lblPatientSex { get {return Header().lblPatientSex;} }
            public TTReportField lblPatientAge { get {return Header().lblPatientAge;} }
            public TTReportField lblPatientFatherName { get {return Header().lblPatientFatherName;} }
            public TTReportField lblTestReqDate { get {return Header().lblTestReqDate;} }
            public TTReportField lblTestAcceptionDate { get {return Header().lblTestAcceptionDate;} }
            public TTReportField lblFromResoure { get {return Header().lblFromResoure;} }
            public TTReportField dotsPatientName { get {return Header().dotsPatientName;} }
            public TTReportField dotsPatientSex { get {return Header().dotsPatientSex;} }
            public TTReportField dotsPatientAge { get {return Header().dotsPatientAge;} }
            public TTReportField dotsPatientFatherName { get {return Header().dotsPatientFatherName;} }
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
            public TTReportField PatientStatus { get {return Header().PatientStatus;} }
            public TTReportField PathologyRequestDate { get {return Header().PathologyRequestDate;} }
            public TTReportField PathologyAcceptionDate { get {return Header().PathologyAcceptionDate;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField lblRequestDoctor { get {return Header().lblRequestDoctor;} }
            public TTReportField dotsRequestDoctor { get {return Header().dotsRequestDoctor;} }
            public TTReportField RequestDoctor { get {return Header().RequestDoctor;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField lblUniqueRefNo { get {return Header().lblUniqueRefNo;} }
            public TTReportField dotsUniqueRefNo { get {return Header().dotsUniqueRefNo;} }
            public TTReportField HASTATCNU { get {return Header().HASTATCNU;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField MaterialProtocolNo { get {return Header().MaterialProtocolNo;} }
            public TTReportField NewField11125111 { get {return Header().NewField11125111;} }
            public TTReportField NewField1115211 { get {return Footer().NewField1115211;} }
            public TTReportField SpecialDoctor { get {return Footer().SpecialDoctor;} }
            public TTReportField NewField11119111 { get {return Footer().NewField11119111;} }
            public TTReportField ProcedureDoctor { get {return Footer().ProcedureDoctor;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField112411 { get {return Footer().NewField112411;} }
            public TTReportField ReportDate { get {return Footer().ReportDate;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField NewField1114211 { get {return Footer().NewField1114211;} }
            public TTReportField ApproveDate { get {return Footer().ApproveDate;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.GetPathologyByObjectID_Class>("GetPathologyByObjectID", Pathology.GetPathologyByObjectID((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
                }
                
                public TTReportField lblPatientName;
                public TTReportField lblPatientSex;
                public TTReportField lblPatientAge;
                public TTReportField lblPatientFatherName;
                public TTReportField lblTestReqDate;
                public TTReportField lblTestAcceptionDate;
                public TTReportField lblFromResoure;
                public TTReportField dotsPatientName;
                public TTReportField dotsPatientSex;
                public TTReportField dotsPatientAge;
                public TTReportField dotsPatientFatherName;
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
                public TTReportField PatientStatus;
                public TTReportField PathologyRequestDate;
                public TTReportField PathologyAcceptionDate;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField REPORTHEADER1;
                public TTReportField lblRequestDoctor;
                public TTReportField dotsRequestDoctor;
                public TTReportField RequestDoctor;
                public TTReportShape NewLine1111;
                public TTReportField lblUniqueRefNo;
                public TTReportField dotsUniqueRefNo;
                public TTReportField HASTATCNU;
                public TTReportField LOGO;
                public TTReportField MaterialProtocolNo;
                public TTReportField NewField11125111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 87;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 66, 43, 71, false);
                    lblPatientName.Name = "lblPatientName";
                    lblPatientName.TextFont.Name = "Arial Narrow";
                    lblPatientName.TextFont.Size = 9;
                    lblPatientName.TextFont.Bold = true;
                    lblPatientName.TextFont.CharSet = 162;
                    lblPatientName.Value = @"Hasta Adı";

                    lblPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 71, 43, 76, false);
                    lblPatientSex.Name = "lblPatientSex";
                    lblPatientSex.TextFont.Name = "Arial Narrow";
                    lblPatientSex.TextFont.Size = 9;
                    lblPatientSex.TextFont.Bold = true;
                    lblPatientSex.TextFont.CharSet = 162;
                    lblPatientSex.Value = @"Cinsiyeti";

                    lblPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 76, 43, 81, false);
                    lblPatientAge.Name = "lblPatientAge";
                    lblPatientAge.TextFont.Name = "Arial Narrow";
                    lblPatientAge.TextFont.Size = 9;
                    lblPatientAge.TextFont.Bold = true;
                    lblPatientAge.TextFont.CharSet = 162;
                    lblPatientAge.Value = @"Doğum Tarihi";

                    lblPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 81, 45, 86, false);
                    lblPatientFatherName.Name = "lblPatientFatherName";
                    lblPatientFatherName.TextFont.Name = "Arial Narrow";
                    lblPatientFatherName.TextFont.Size = 9;
                    lblPatientFatherName.TextFont.Bold = true;
                    lblPatientFatherName.TextFont.CharSet = 162;
                    lblPatientFatherName.Value = @"Baba Adı";

                    lblTestReqDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 71, 138, 76, false);
                    lblTestReqDate.Name = "lblTestReqDate";
                    lblTestReqDate.TextFont.Name = "Arial Narrow";
                    lblTestReqDate.TextFont.Size = 9;
                    lblTestReqDate.TextFont.Bold = true;
                    lblTestReqDate.TextFont.CharSet = 162;
                    lblTestReqDate.Value = @"İstek Kabul Tarihi";

                    lblTestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 66, 138, 71, false);
                    lblTestAcceptionDate.Name = "lblTestAcceptionDate";
                    lblTestAcceptionDate.TextFont.Name = "Arial Narrow";
                    lblTestAcceptionDate.TextFont.Size = 9;
                    lblTestAcceptionDate.TextFont.Bold = true;
                    lblTestAcceptionDate.TextFont.CharSet = 162;
                    lblTestAcceptionDate.Value = @"İstek Tarihi";

                    lblFromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 81, 138, 86, false);
                    lblFromResoure.Name = "lblFromResoure";
                    lblFromResoure.TextFont.Name = "Arial Narrow";
                    lblFromResoure.TextFont.Size = 9;
                    lblFromResoure.TextFont.Bold = true;
                    lblFromResoure.TextFont.CharSet = 162;
                    lblFromResoure.Value = @"Gönderen Klinik";

                    dotsPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 66, 46, 71, false);
                    dotsPatientName.Name = "dotsPatientName";
                    dotsPatientName.TextFont.Name = "Arial Narrow";
                    dotsPatientName.TextFont.Size = 9;
                    dotsPatientName.TextFont.Bold = true;
                    dotsPatientName.TextFont.CharSet = 162;
                    dotsPatientName.Value = @":";

                    dotsPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 71, 46, 76, false);
                    dotsPatientSex.Name = "dotsPatientSex";
                    dotsPatientSex.TextFont.Name = "Arial Narrow";
                    dotsPatientSex.TextFont.Size = 9;
                    dotsPatientSex.TextFont.Bold = true;
                    dotsPatientSex.TextFont.CharSet = 162;
                    dotsPatientSex.Value = @":";

                    dotsPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 76, 46, 81, false);
                    dotsPatientAge.Name = "dotsPatientAge";
                    dotsPatientAge.TextFont.Name = "Arial Narrow";
                    dotsPatientAge.TextFont.Size = 9;
                    dotsPatientAge.TextFont.Bold = true;
                    dotsPatientAge.TextFont.CharSet = 162;
                    dotsPatientAge.Value = @":";

                    dotsPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 81, 46, 86, false);
                    dotsPatientFatherName.Name = "dotsPatientFatherName";
                    dotsPatientFatherName.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName.TextFont.Size = 9;
                    dotsPatientFatherName.TextFont.Bold = true;
                    dotsPatientFatherName.TextFont.CharSet = 162;
                    dotsPatientFatherName.Value = @":";

                    dotsTestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 66, 142, 71, false);
                    dotsTestAcceptionDate.Name = "dotsTestAcceptionDate";
                    dotsTestAcceptionDate.TextFont.Name = "Arial Narrow";
                    dotsTestAcceptionDate.TextFont.Size = 9;
                    dotsTestAcceptionDate.TextFont.Bold = true;
                    dotsTestAcceptionDate.TextFont.CharSet = 162;
                    dotsTestAcceptionDate.Value = @":";

                    dotsTestReqDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 71, 142, 76, false);
                    dotsTestReqDate.Name = "dotsTestReqDate";
                    dotsTestReqDate.TextFont.Name = "Arial Narrow";
                    dotsTestReqDate.TextFont.Size = 9;
                    dotsTestReqDate.TextFont.Bold = true;
                    dotsTestReqDate.TextFont.CharSet = 162;
                    dotsTestReqDate.Value = @":";

                    dotsFromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 81, 142, 86, false);
                    dotsFromResoure.Name = "dotsFromResoure";
                    dotsFromResoure.TextFont.Name = "Arial Narrow";
                    dotsFromResoure.TextFont.Size = 9;
                    dotsFromResoure.TextFont.Bold = true;
                    dotsFromResoure.TextFont.CharSet = 162;
                    dotsFromResoure.Value = @":";

                    lblPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 61, 138, 66, false);
                    lblPatientStatus.Name = "lblPatientStatus";
                    lblPatientStatus.TextFont.Name = "Arial Narrow";
                    lblPatientStatus.TextFont.Size = 9;
                    lblPatientStatus.TextFont.Bold = true;
                    lblPatientStatus.TextFont.CharSet = 162;
                    lblPatientStatus.Value = @"Hasta Tipi";

                    dotsPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 61, 142, 66, false);
                    dotsPatientStatus.Name = "dotsPatientStatus";
                    dotsPatientStatus.TextFont.Name = "Arial Narrow";
                    dotsPatientStatus.TextFont.Size = 9;
                    dotsPatientStatus.TextFont.Bold = true;
                    dotsPatientStatus.TextFont.CharSet = 162;
                    dotsPatientStatus.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 66, 108, 71, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    PatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 71, 108, 76, false);
                    PatientSex.Name = "PatientSex";
                    PatientSex.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSex.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSex.TextFont.Name = "Arial Narrow";
                    PatientSex.TextFont.Size = 9;
                    PatientSex.TextFont.CharSet = 162;
                    PatientSex.Value = @"{#CINSIYET#}";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 76, 108, 81, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientAge.TextFormat = @"dd/MM/yyyy";
                    PatientAge.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAge.TextFont.Name = "Arial Narrow";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"{#BIRTHDATE#}";

                    PatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 81, 108, 86, false);
                    PatientFatherName.Name = "PatientFatherName";
                    PatientFatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientFatherName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientFatherName.TextFont.Name = "Arial Narrow";
                    PatientFatherName.TextFont.Size = 9;
                    PatientFatherName.TextFont.CharSet = 162;
                    PatientFatherName.Value = @"{#FATHERNAME#}";

                    FromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 81, 201, 86, false);
                    FromResoure.Name = "FromResoure";
                    FromResoure.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResoure.MultiLine = EvetHayirEnum.ehEvet;
                    FromResoure.TextFont.Name = "Arial Narrow";
                    FromResoure.TextFont.Size = 9;
                    FromResoure.TextFont.CharSet = 162;
                    FromResoure.Value = @"{#FROMRES#}";

                    PatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 61, 201, 66, false);
                    PatientStatus.Name = "PatientStatus";
                    PatientStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus.TextFormat = @"Long Time";
                    PatientStatus.ObjectDefName = "PatientStatusEnum";
                    PatientStatus.DataMember = "DISPLAYTEXT";
                    PatientStatus.TextFont.Name = "Arial Narrow";
                    PatientStatus.TextFont.Size = 9;
                    PatientStatus.TextFont.CharSet = 162;
                    PatientStatus.Value = @"{#PATIENTSTATUS#}";

                    PathologyRequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 66, 201, 71, false);
                    PathologyRequestDate.Name = "PathologyRequestDate";
                    PathologyRequestDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PathologyRequestDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PathologyRequestDate.TextFont.Name = "Arial Narrow";
                    PathologyRequestDate.TextFont.Size = 9;
                    PathologyRequestDate.TextFont.CharSet = 162;
                    PathologyRequestDate.Value = @"{#ISTEKTARIHI#}";

                    PathologyAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 71, 201, 76, false);
                    PathologyAcceptionDate.Name = "PathologyAcceptionDate";
                    PathologyAcceptionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PathologyAcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PathologyAcceptionDate.TextFont.Name = "Arial Narrow";
                    PathologyAcceptionDate.TextFont.Size = 9;
                    PathologyAcceptionDate.TextFont.CharSet = 162;
                    PathologyAcceptionDate.Value = @"{#MATERYALKABULTARIHI#}";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 11, 174, 33, false);
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

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 33, 174, 39, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.TextFont.CharSet = 162;
                    REPORTHEADER1.Value = @"PATOLOJİ SONUÇ RAPORU";

                    lblRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 76, 138, 81, false);
                    lblRequestDoctor.Name = "lblRequestDoctor";
                    lblRequestDoctor.TextFont.Name = "Arial Narrow";
                    lblRequestDoctor.TextFont.Size = 9;
                    lblRequestDoctor.TextFont.Bold = true;
                    lblRequestDoctor.TextFont.CharSet = 162;
                    lblRequestDoctor.Value = @"İstek Yapan Tabip";

                    dotsRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 76, 142, 81, false);
                    dotsRequestDoctor.Name = "dotsRequestDoctor";
                    dotsRequestDoctor.TextFont.Name = "Arial Narrow";
                    dotsRequestDoctor.TextFont.Size = 9;
                    dotsRequestDoctor.TextFont.Bold = true;
                    dotsRequestDoctor.TextFont.CharSet = 162;
                    dotsRequestDoctor.Value = @":";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 76, 201, 81, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor.TextFont.Name = "Arial Narrow";
                    RequestDoctor.TextFont.Size = 9;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"{#ISTEKYAPANDOKTOR#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 90, 200, 90, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    lblUniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 61, 38, 66, false);
                    lblUniqueRefNo.Name = "lblUniqueRefNo";
                    lblUniqueRefNo.TextFont.Name = "Arial Narrow";
                    lblUniqueRefNo.TextFont.Size = 9;
                    lblUniqueRefNo.TextFont.Bold = true;
                    lblUniqueRefNo.TextFont.CharSet = 162;
                    lblUniqueRefNo.Value = @"T.C.Kimlik Numarası";

                    dotsUniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 61, 46, 66, false);
                    dotsUniqueRefNo.Name = "dotsUniqueRefNo";
                    dotsUniqueRefNo.TextFont.Name = "Arial Narrow";
                    dotsUniqueRefNo.TextFont.Size = 9;
                    dotsUniqueRefNo.TextFont.Bold = true;
                    dotsUniqueRefNo.TextFont.CharSet = 162;
                    dotsUniqueRefNo.Value = @":";

                    HASTATCNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 61, 105, 66, false);
                    HASTATCNU.Name = "HASTATCNU";
                    HASTATCNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNU.TextFont.Name = "Arial Narrow";
                    HASTATCNU.TextFont.Size = 9;
                    HASTATCNU.TextFont.CharSet = 162;
                    HASTATCNU.Value = @"{#UNIQUEREFNO#}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 11, 52, 34, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.Value = @"";

                    MaterialProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 43, 201, 60, false);
                    MaterialProtocolNo.Name = "MaterialProtocolNo";
                    MaterialProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialProtocolNo.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MaterialProtocolNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialProtocolNo.MultiLine = EvetHayirEnum.ehEvet;
                    MaterialProtocolNo.TextFont.Name = "Code39HalfInchTT-Regular";
                    MaterialProtocolNo.TextFont.Size = 32;
                    MaterialProtocolNo.TextFont.CharSet = 0;
                    MaterialProtocolNo.Value = @"{#PROTOKOLNUMARASI#}";

                    NewField11125111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 39, 201, 43, false);
                    NewField11125111.Name = "NewField11125111";
                    NewField11125111.TextFont.Name = "Arial Narrow";
                    NewField11125111.TextFont.Size = 9;
                    NewField11125111.TextFont.Bold = true;
                    NewField11125111.TextFont.CharSet = 162;
                    NewField11125111.Value = @"Materyal Protokol No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.GetPathologyByObjectID_Class dataset_GetPathologyByObjectID = ParentGroup.rsGroup.GetCurrentRecord<Pathology.GetPathologyByObjectID_Class>(0);
                    lblPatientName.CalcValue = lblPatientName.Value;
                    lblPatientSex.CalcValue = lblPatientSex.Value;
                    lblPatientAge.CalcValue = lblPatientAge.Value;
                    lblPatientFatherName.CalcValue = lblPatientFatherName.Value;
                    lblTestReqDate.CalcValue = lblTestReqDate.Value;
                    lblTestAcceptionDate.CalcValue = lblTestAcceptionDate.Value;
                    lblFromResoure.CalcValue = lblFromResoure.Value;
                    dotsPatientName.CalcValue = dotsPatientName.Value;
                    dotsPatientSex.CalcValue = dotsPatientSex.Value;
                    dotsPatientAge.CalcValue = dotsPatientAge.Value;
                    dotsPatientFatherName.CalcValue = dotsPatientFatherName.Value;
                    dotsTestAcceptionDate.CalcValue = dotsTestAcceptionDate.Value;
                    dotsTestReqDate.CalcValue = dotsTestReqDate.Value;
                    dotsFromResoure.CalcValue = dotsFromResoure.Value;
                    lblPatientStatus.CalcValue = lblPatientStatus.Value;
                    dotsPatientStatus.CalcValue = dotsPatientStatus.Value;
                    PatientName.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Name) : "") + @" " + (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Surname) : "");
                    PatientSex.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Cinsiyet) : "");
                    PatientAge.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.BirthDate) : "");
                    PatientFatherName.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.FatherName) : "");
                    FromResoure.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Fromres) : "");
                    PatientStatus.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.PatientStatus) : "");
                    PatientStatus.PostFieldValueCalculation();
                    PathologyRequestDate.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Istektarihi) : "");
                    PathologyAcceptionDate.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Materyalkabultarihi) : "");
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    lblRequestDoctor.CalcValue = lblRequestDoctor.Value;
                    dotsRequestDoctor.CalcValue = dotsRequestDoctor.Value;
                    RequestDoctor.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Istekyapandoktor) : "");
                    lblUniqueRefNo.CalcValue = lblUniqueRefNo.Value;
                    dotsUniqueRefNo.CalcValue = dotsUniqueRefNo.Value;
                    HASTATCNU.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.UniqueRefNo) : "");
                    LOGO.CalcValue = @"";
                    MaterialProtocolNo.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Protokolnumarasi) : "");
                    NewField11125111.CalcValue = NewField11125111.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { lblPatientName,lblPatientSex,lblPatientAge,lblPatientFatherName,lblTestReqDate,lblTestAcceptionDate,lblFromResoure,dotsPatientName,dotsPatientSex,dotsPatientAge,dotsPatientFatherName,dotsTestAcceptionDate,dotsTestReqDate,dotsFromResoure,lblPatientStatus,dotsPatientStatus,PatientName,PatientSex,PatientAge,PatientFatherName,FromResoure,PatientStatus,PathologyRequestDate,PathologyAcceptionDate,REPORTHEADER1,lblRequestDoctor,dotsRequestDoctor,RequestDoctor,lblUniqueRefNo,dotsUniqueRefNo,HASTATCNU,LOGO,MaterialProtocolNo,NewField11125111,XXXXXXBASLIK1};
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
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
                }
                
                public TTReportField NewField1115211;
                public TTReportField SpecialDoctor;
                public TTReportField NewField11119111;
                public TTReportField ProcedureDoctor;
                public TTReportField NewField1111;
                public TTReportField NewField112411;
                public TTReportField ReportDate;
                public TTReportField NewField11111;
                public TTReportField NewField1114211;
                public TTReportField ApproveDate; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 33;
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
                    NewField1115211.Value = @"Uzman Doktor";

                    SpecialDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 6, 201, 25, false);
                    SpecialDoctor.Name = "SpecialDoctor";
                    SpecialDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpecialDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    SpecialDoctor.TextFont.Name = "Arial Narrow";
                    SpecialDoctor.TextFont.Size = 9;
                    SpecialDoctor.TextFont.CharSet = 162;
                    SpecialDoctor.Value = @"{#UZMANDOKTOR#}";

                    NewField11119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 46, 6, false);
                    NewField11119111.Name = "NewField11119111";
                    NewField11119111.TextFont.Name = "Arial Narrow";
                    NewField11119111.TextFont.Size = 9;
                    NewField11119111.TextFont.Bold = true;
                    NewField11119111.TextFont.CharSet = 162;
                    NewField11119111.Value = @"İşlemi Uygulayan Doktor";

                    ProcedureDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 69, 25, false);
                    ProcedureDoctor.Name = "ProcedureDoctor";
                    ProcedureDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProcedureDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    ProcedureDoctor.TextFont.Name = "Arial Narrow";
                    ProcedureDoctor.TextFont.Size = 9;
                    ProcedureDoctor.TextFont.CharSet = 162;
                    ProcedureDoctor.Value = @"{#ISLEMIYAPANDOKTOR#}";

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

                    ReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 26, 89, 31, false);
                    ReportDate.Name = "ReportDate";
                    ReportDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    ReportDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportDate.TextFont.Name = "Arial";
                    ReportDate.TextFont.Size = 9;
                    ReportDate.TextFont.CharSet = 162;
                    ReportDate.Value = @"{#RAPORTARIHI#}";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 26, 114, 31, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Onay Tarihi";

                    NewField1114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 26, 117, 31, false);
                    NewField1114211.Name = "NewField1114211";
                    NewField1114211.TextFont.Name = "Arial Narrow";
                    NewField1114211.TextFont.Size = 9;
                    NewField1114211.TextFont.Bold = true;
                    NewField1114211.TextFont.CharSet = 162;
                    NewField1114211.Value = @":";

                    ApproveDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 26, 166, 31, false);
                    ApproveDate.Name = "ApproveDate";
                    ApproveDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ApproveDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    ApproveDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ApproveDate.TextFont.Name = "Arial";
                    ApproveDate.TextFont.Size = 9;
                    ApproveDate.TextFont.CharSet = 162;
                    ApproveDate.Value = @"{#ONAYTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.GetPathologyByObjectID_Class dataset_GetPathologyByObjectID = ParentGroup.rsGroup.GetCurrentRecord<Pathology.GetPathologyByObjectID_Class>(0);
                    NewField1115211.CalcValue = NewField1115211.Value;
                    SpecialDoctor.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Uzmandoktor) : "");
                    NewField11119111.CalcValue = NewField11119111.Value;
                    ProcedureDoctor.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Islemiyapandoktor) : "");
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    ReportDate.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Raportarihi) : "");
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1114211.CalcValue = NewField1114211.Value;
                    ApproveDate.CalcValue = (dataset_GetPathologyByObjectID != null ? Globals.ToStringCore(dataset_GetPathologyByObjectID.Onaytarihi) : "");
                    return new TTReportObject[] { NewField1115211,SpecialDoctor,NewField11119111,ProcedureDoctor,NewField1111,NewField112411,ReportDate,NewField11111,NewField1114211,ApproveDate};
                }
                public override void RunPreScript()
                {
#region HEADER FOOTER_PreScript
                    //                                                TTObjectContext context = this.ParentReport.ReportObjectContext;
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//
//            if (pathologyTest.RemoteSpecialDoctor != null)
//            {
//                this.RemoteDoctor.Value = pathologyTest.RemoteSpecialDoctor.ToString();
//                this.UZMANTABIB.Visible = EvetHayirEnum.ehEvet;
//            }
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
            public PathologyResultReportNew MyParentReport
            {
                get { return (PathologyResultReportNew)ParentReport; }
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
            public TTReportField MateryalArsivNo { get {return Header().MateryalArsivNo;} }
            public TTReportField MATERIALOBJECTID { get {return Header().MATERIALOBJECTID;} }
            public TTReportField lblPreDiagnosis11 { get {return Header().lblPreDiagnosis11;} }
            public TTReportField lblPreDiagnosis111 { get {return Header().lblPreDiagnosis111;} }
            public TTReportField lblPreDiagnosis1111 { get {return Header().lblPreDiagnosis1111;} }
            public TTReportField lblPreDiagnosis11111 { get {return Header().lblPreDiagnosis11111;} }
            public TTReportField lblPreDiagnosis111111 { get {return Header().lblPreDiagnosis111111;} }
            public TTReportField lblPreDiagnosis1111111 { get {return Header().lblPreDiagnosis1111111;} }
            public TTReportField dotsPatientFatherName1 { get {return Header().dotsPatientFatherName1;} }
            public TTReportField dotsPatientFatherName11 { get {return Header().dotsPatientFatherName11;} }
            public TTReportField dotsPatientFatherName111 { get {return Header().dotsPatientFatherName111;} }
            public TTReportField dotsPatientFatherName1111 { get {return Header().dotsPatientFatherName1111;} }
            public TTReportField dotsPatientFatherName11111 { get {return Header().dotsPatientFatherName11111;} }
            public TTReportField dotsPatientFatherName111111 { get {return Header().dotsPatientFatherName111111;} }
            public TTReportField dotsPatientFatherName1111111 { get {return Header().dotsPatientFatherName1111111;} }
            public TTReportField dateofsampletaken { get {return Header().dateofsampletaken;} }
            public TTReportField alindigiorgan { get {return Header().alindigiorgan;} }
            public TTReportField alindigidokununtemelozelligi { get {return Header().alindigidokununtemelozelligi;} }
            public TTReportField numunealinmasekli { get {return Header().numunealinmasekli;} }
            public TTReportField preparatdurumu { get {return Header().preparatdurumu;} }
            public TTReportField morfolojikodu { get {return Header().morfolojikodu;} }
            public TTReportField lblPreDiagnosis11111111 { get {return Header().lblPreDiagnosis11111111;} }
            public TTReportField klinikbulgular { get {return Header().klinikbulgular;} }
            public TTReportField lblPreDiagnosis111111111 { get {return Header().lblPreDiagnosis111111111;} }
            public TTReportField aciklama { get {return Header().aciklama;} }
            public TTReportField lblPreDiagnosis111111112 { get {return Header().lblPreDiagnosis111111112;} }
            public TTReportField makroskopi { get {return Header().makroskopi;} }
            public TTReportField lblMikroskopi { get {return Header().lblMikroskopi;} }
            public TTReportField mikroskopi { get {return Header().mikroskopi;} }
            public TTReportField lblMikroskopi1 { get {return Header().lblMikroskopi1;} }
            public TTReportField notyorum { get {return Header().notyorum;} }
            public TTReportField lblMikroskopi11 { get {return Header().lblMikroskopi11;} }
            public TTReportField tani { get {return Header().tani;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public PAGEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PAGEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyMaterial.GetPathologyMaterialsByPathology_Class>("GetPathologyMaterialsByPathology", PathologyMaterial.GetPathologyMaterialsByPathology((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PAGEGroupHeader(this);
                _footer = new PAGEGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PAGEGroupHeader : TTReportSection
            {
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
                }
                
                public TTReportField lblPreDiagnosis1;
                public TTReportField MateryalArsivNo;
                public TTReportField MATERIALOBJECTID;
                public TTReportField lblPreDiagnosis11;
                public TTReportField lblPreDiagnosis111;
                public TTReportField lblPreDiagnosis1111;
                public TTReportField lblPreDiagnosis11111;
                public TTReportField lblPreDiagnosis111111;
                public TTReportField lblPreDiagnosis1111111;
                public TTReportField dotsPatientFatherName1;
                public TTReportField dotsPatientFatherName11;
                public TTReportField dotsPatientFatherName111;
                public TTReportField dotsPatientFatherName1111;
                public TTReportField dotsPatientFatherName11111;
                public TTReportField dotsPatientFatherName111111;
                public TTReportField dotsPatientFatherName1111111;
                public TTReportField dateofsampletaken;
                public TTReportField alindigiorgan;
                public TTReportField alindigidokununtemelozelligi;
                public TTReportField numunealinmasekli;
                public TTReportField preparatdurumu;
                public TTReportField morfolojikodu;
                public TTReportField lblPreDiagnosis11111111;
                public TTReportField klinikbulgular;
                public TTReportField lblPreDiagnosis111111111;
                public TTReportField aciklama;
                public TTReportField lblPreDiagnosis111111112;
                public TTReportField makroskopi;
                public TTReportField lblMikroskopi;
                public TTReportField mikroskopi;
                public TTReportField lblMikroskopi1;
                public TTReportField notyorum;
                public TTReportField lblMikroskopi11;
                public TTReportField tani;
                public TTReportField NewField1321;
                public TTReportField NewField121;
                public TTReportField NewField1221;
                public TTReportField NewField11221; 
                public PAGEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 133;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblPreDiagnosis1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 58, 6, false);
                    lblPreDiagnosis1.Name = "lblPreDiagnosis1";
                    lblPreDiagnosis1.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis1.TextFont.Bold = true;
                    lblPreDiagnosis1.TextFont.Underline = true;
                    lblPreDiagnosis1.TextFont.CharSet = 162;
                    lblPreDiagnosis1.Value = @"Material Arşiv No";

                    MateryalArsivNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 101, 6, false);
                    MateryalArsivNo.Name = "MateryalArsivNo";
                    MateryalArsivNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    MateryalArsivNo.MultiLine = EvetHayirEnum.ehEvet;
                    MateryalArsivNo.NoClip = EvetHayirEnum.ehEvet;
                    MateryalArsivNo.WordBreak = EvetHayirEnum.ehEvet;
                    MateryalArsivNo.ExpandTabs = EvetHayirEnum.ehEvet;
                    MateryalArsivNo.TextFont.Name = "Arial Narrow";
                    MateryalArsivNo.TextFont.Size = 9;
                    MateryalArsivNo.TextFont.CharSet = 162;
                    MateryalArsivNo.Value = @"{#MATERYALNUMARASI#}";

                    MATERIALOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 1, 179, 6, false);
                    MATERIALOBJECTID.Name = "MATERIALOBJECTID";
                    MATERIALOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALOBJECTID.TextFont.Name = "Arial Narrow";
                    MATERIALOBJECTID.TextFont.CharSet = 162;
                    MATERIALOBJECTID.Value = @"{#MATERIALOBJID#}";

                    lblPreDiagnosis11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 58, 11, false);
                    lblPreDiagnosis11.Name = "lblPreDiagnosis11";
                    lblPreDiagnosis11.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis11.TextFont.Bold = true;
                    lblPreDiagnosis11.TextFont.Underline = true;
                    lblPreDiagnosis11.TextFont.CharSet = 162;
                    lblPreDiagnosis11.Value = @"Numune Alınma Tarihi";

                    lblPreDiagnosis111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 11, 58, 16, false);
                    lblPreDiagnosis111.Name = "lblPreDiagnosis111";
                    lblPreDiagnosis111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis111.TextFont.Bold = true;
                    lblPreDiagnosis111.TextFont.Underline = true;
                    lblPreDiagnosis111.TextFont.CharSet = 162;
                    lblPreDiagnosis111.Value = @"Alındığı Organ";

                    lblPreDiagnosis1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 16, 58, 21, false);
                    lblPreDiagnosis1111.Name = "lblPreDiagnosis1111";
                    lblPreDiagnosis1111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis1111.TextFont.Bold = true;
                    lblPreDiagnosis1111.TextFont.Underline = true;
                    lblPreDiagnosis1111.TextFont.CharSet = 162;
                    lblPreDiagnosis1111.Value = @"Alındığı Dokunun Temel Özelliği";

                    lblPreDiagnosis11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 21, 58, 26, false);
                    lblPreDiagnosis11111.Name = "lblPreDiagnosis11111";
                    lblPreDiagnosis11111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis11111.TextFont.Bold = true;
                    lblPreDiagnosis11111.TextFont.Underline = true;
                    lblPreDiagnosis11111.TextFont.CharSet = 162;
                    lblPreDiagnosis11111.Value = @"Numune Alınma Şekli";

                    lblPreDiagnosis111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 26, 58, 31, false);
                    lblPreDiagnosis111111.Name = "lblPreDiagnosis111111";
                    lblPreDiagnosis111111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis111111.TextFont.Bold = true;
                    lblPreDiagnosis111111.TextFont.Underline = true;
                    lblPreDiagnosis111111.TextFont.CharSet = 162;
                    lblPreDiagnosis111111.Value = @"Preparat Durumu";

                    lblPreDiagnosis1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 31, 58, 36, false);
                    lblPreDiagnosis1111111.Name = "lblPreDiagnosis1111111";
                    lblPreDiagnosis1111111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis1111111.TextFont.Bold = true;
                    lblPreDiagnosis1111111.TextFont.Underline = true;
                    lblPreDiagnosis1111111.TextFont.CharSet = 162;
                    lblPreDiagnosis1111111.Value = @"Morfoloji Kodu";

                    dotsPatientFatherName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 1, 61, 6, false);
                    dotsPatientFatherName1.Name = "dotsPatientFatherName1";
                    dotsPatientFatherName1.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName1.TextFont.Size = 9;
                    dotsPatientFatherName1.TextFont.Bold = true;
                    dotsPatientFatherName1.TextFont.CharSet = 162;
                    dotsPatientFatherName1.Value = @":";

                    dotsPatientFatherName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 6, 61, 11, false);
                    dotsPatientFatherName11.Name = "dotsPatientFatherName11";
                    dotsPatientFatherName11.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName11.TextFont.Size = 9;
                    dotsPatientFatherName11.TextFont.Bold = true;
                    dotsPatientFatherName11.TextFont.CharSet = 162;
                    dotsPatientFatherName11.Value = @":";

                    dotsPatientFatherName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 11, 61, 16, false);
                    dotsPatientFatherName111.Name = "dotsPatientFatherName111";
                    dotsPatientFatherName111.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName111.TextFont.Size = 9;
                    dotsPatientFatherName111.TextFont.Bold = true;
                    dotsPatientFatherName111.TextFont.CharSet = 162;
                    dotsPatientFatherName111.Value = @":";

                    dotsPatientFatherName1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 16, 61, 21, false);
                    dotsPatientFatherName1111.Name = "dotsPatientFatherName1111";
                    dotsPatientFatherName1111.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName1111.TextFont.Size = 9;
                    dotsPatientFatherName1111.TextFont.Bold = true;
                    dotsPatientFatherName1111.TextFont.CharSet = 162;
                    dotsPatientFatherName1111.Value = @":";

                    dotsPatientFatherName11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 21, 61, 26, false);
                    dotsPatientFatherName11111.Name = "dotsPatientFatherName11111";
                    dotsPatientFatherName11111.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName11111.TextFont.Size = 9;
                    dotsPatientFatherName11111.TextFont.Bold = true;
                    dotsPatientFatherName11111.TextFont.CharSet = 162;
                    dotsPatientFatherName11111.Value = @":";

                    dotsPatientFatherName111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 26, 61, 31, false);
                    dotsPatientFatherName111111.Name = "dotsPatientFatherName111111";
                    dotsPatientFatherName111111.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName111111.TextFont.Size = 9;
                    dotsPatientFatherName111111.TextFont.Bold = true;
                    dotsPatientFatherName111111.TextFont.CharSet = 162;
                    dotsPatientFatherName111111.Value = @":";

                    dotsPatientFatherName1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 31, 61, 36, false);
                    dotsPatientFatherName1111111.Name = "dotsPatientFatherName1111111";
                    dotsPatientFatherName1111111.TextFont.Name = "Arial Narrow";
                    dotsPatientFatherName1111111.TextFont.Size = 9;
                    dotsPatientFatherName1111111.TextFont.Bold = true;
                    dotsPatientFatherName1111111.TextFont.CharSet = 162;
                    dotsPatientFatherName1111111.Value = @":";

                    dateofsampletaken = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 6, 101, 11, false);
                    dateofsampletaken.Name = "dateofsampletaken";
                    dateofsampletaken.FieldType = ReportFieldTypeEnum.ftVariable;
                    dateofsampletaken.TextFormat = @"dd/MM/yyyy HH:mm";
                    dateofsampletaken.MultiLine = EvetHayirEnum.ehEvet;
                    dateofsampletaken.NoClip = EvetHayirEnum.ehEvet;
                    dateofsampletaken.WordBreak = EvetHayirEnum.ehEvet;
                    dateofsampletaken.ExpandTabs = EvetHayirEnum.ehEvet;
                    dateofsampletaken.TextFont.Name = "Arial Narrow";
                    dateofsampletaken.TextFont.Size = 9;
                    dateofsampletaken.TextFont.CharSet = 162;
                    dateofsampletaken.Value = @"{#NUMUNEALINMATARIHI#}";

                    alindigiorgan = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 11, 201, 16, false);
                    alindigiorgan.Name = "alindigiorgan";
                    alindigiorgan.FieldType = ReportFieldTypeEnum.ftVariable;
                    alindigiorgan.MultiLine = EvetHayirEnum.ehEvet;
                    alindigiorgan.NoClip = EvetHayirEnum.ehEvet;
                    alindigiorgan.WordBreak = EvetHayirEnum.ehEvet;
                    alindigiorgan.ExpandTabs = EvetHayirEnum.ehEvet;
                    alindigiorgan.TextFont.Name = "Arial Narrow";
                    alindigiorgan.TextFont.Size = 9;
                    alindigiorgan.TextFont.CharSet = 162;
                    alindigiorgan.Value = @"{#TOPOGRAFIKODU#}-{#KODTANIMI#}";

                    alindigidokununtemelozelligi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 16, 201, 21, false);
                    alindigidokununtemelozelligi.Name = "alindigidokununtemelozelligi";
                    alindigidokununtemelozelligi.FieldType = ReportFieldTypeEnum.ftVariable;
                    alindigidokununtemelozelligi.MultiLine = EvetHayirEnum.ehEvet;
                    alindigidokununtemelozelligi.NoClip = EvetHayirEnum.ehEvet;
                    alindigidokununtemelozelligi.WordBreak = EvetHayirEnum.ehEvet;
                    alindigidokununtemelozelligi.ExpandTabs = EvetHayirEnum.ehEvet;
                    alindigidokununtemelozelligi.TextFont.Name = "Arial Narrow";
                    alindigidokununtemelozelligi.TextFont.Size = 9;
                    alindigidokununtemelozelligi.TextFont.CharSet = 162;
                    alindigidokununtemelozelligi.Value = @"{#ALINDIGIDOKUNUNTEMELOZELLIGI#}";

                    numunealinmasekli = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 21, 201, 26, false);
                    numunealinmasekli.Name = "numunealinmasekli";
                    numunealinmasekli.FieldType = ReportFieldTypeEnum.ftVariable;
                    numunealinmasekli.MultiLine = EvetHayirEnum.ehEvet;
                    numunealinmasekli.NoClip = EvetHayirEnum.ehEvet;
                    numunealinmasekli.WordBreak = EvetHayirEnum.ehEvet;
                    numunealinmasekli.ExpandTabs = EvetHayirEnum.ehEvet;
                    numunealinmasekli.TextFont.Name = "Arial Narrow";
                    numunealinmasekli.TextFont.Size = 9;
                    numunealinmasekli.TextFont.CharSet = 162;
                    numunealinmasekli.Value = @"{#NUMUNEALINMASEKLI#}";

                    preparatdurumu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 26, 201, 31, false);
                    preparatdurumu.Name = "preparatdurumu";
                    preparatdurumu.FieldType = ReportFieldTypeEnum.ftVariable;
                    preparatdurumu.MultiLine = EvetHayirEnum.ehEvet;
                    preparatdurumu.NoClip = EvetHayirEnum.ehEvet;
                    preparatdurumu.WordBreak = EvetHayirEnum.ehEvet;
                    preparatdurumu.ExpandTabs = EvetHayirEnum.ehEvet;
                    preparatdurumu.TextFont.Name = "Arial Narrow";
                    preparatdurumu.TextFont.Size = 9;
                    preparatdurumu.TextFont.CharSet = 162;
                    preparatdurumu.Value = @"{#PREPARATDURUMU#}";

                    morfolojikodu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 31, 201, 36, false);
                    morfolojikodu.Name = "morfolojikodu";
                    morfolojikodu.FieldType = ReportFieldTypeEnum.ftVariable;
                    morfolojikodu.MultiLine = EvetHayirEnum.ehEvet;
                    morfolojikodu.NoClip = EvetHayirEnum.ehEvet;
                    morfolojikodu.WordBreak = EvetHayirEnum.ehEvet;
                    morfolojikodu.ExpandTabs = EvetHayirEnum.ehEvet;
                    morfolojikodu.TextFont.Name = "Arial Narrow";
                    morfolojikodu.TextFont.Size = 9;
                    morfolojikodu.TextFont.CharSet = 162;
                    morfolojikodu.Value = @"{#MORFOLOJIKODU#}";

                    lblPreDiagnosis11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 36, 58, 41, false);
                    lblPreDiagnosis11111111.Name = "lblPreDiagnosis11111111";
                    lblPreDiagnosis11111111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis11111111.TextFont.Bold = true;
                    lblPreDiagnosis11111111.TextFont.Underline = true;
                    lblPreDiagnosis11111111.TextFont.CharSet = 162;
                    lblPreDiagnosis11111111.Value = @"Klinik Bulgular";

                    klinikbulgular = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 41, 103, 52, false);
                    klinikbulgular.Name = "klinikbulgular";
                    klinikbulgular.FieldType = ReportFieldTypeEnum.ftVariable;
                    klinikbulgular.MultiLine = EvetHayirEnum.ehEvet;
                    klinikbulgular.NoClip = EvetHayirEnum.ehEvet;
                    klinikbulgular.WordBreak = EvetHayirEnum.ehEvet;
                    klinikbulgular.ExpandTabs = EvetHayirEnum.ehEvet;
                    klinikbulgular.TextFont.Name = "Arial Narrow";
                    klinikbulgular.TextFont.Size = 9;
                    klinikbulgular.TextFont.CharSet = 162;
                    klinikbulgular.Value = @"{#KLINIKBULGULAR#}";

                    lblPreDiagnosis111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 36, 150, 41, false);
                    lblPreDiagnosis111111111.Name = "lblPreDiagnosis111111111";
                    lblPreDiagnosis111111111.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis111111111.TextFont.Bold = true;
                    lblPreDiagnosis111111111.TextFont.Underline = true;
                    lblPreDiagnosis111111111.TextFont.CharSet = 162;
                    lblPreDiagnosis111111111.Value = @"Açıklama";

                    aciklama = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 41, 201, 52, false);
                    aciklama.Name = "aciklama";
                    aciklama.FieldType = ReportFieldTypeEnum.ftVariable;
                    aciklama.MultiLine = EvetHayirEnum.ehEvet;
                    aciklama.NoClip = EvetHayirEnum.ehEvet;
                    aciklama.WordBreak = EvetHayirEnum.ehEvet;
                    aciklama.ExpandTabs = EvetHayirEnum.ehEvet;
                    aciklama.TextFont.Name = "Arial Narrow";
                    aciklama.TextFont.Size = 9;
                    aciklama.TextFont.CharSet = 162;
                    aciklama.Value = @"{#ACIKLAMA#}";

                    lblPreDiagnosis111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 52, 58, 57, false);
                    lblPreDiagnosis111111112.Name = "lblPreDiagnosis111111112";
                    lblPreDiagnosis111111112.TextFont.Name = "Arial Narrow";
                    lblPreDiagnosis111111112.TextFont.Bold = true;
                    lblPreDiagnosis111111112.TextFont.Underline = true;
                    lblPreDiagnosis111111112.TextFont.CharSet = 162;
                    lblPreDiagnosis111111112.Value = @"Makroskopi";

                    makroskopi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 57, 202, 73, false);
                    makroskopi.Name = "makroskopi";
                    makroskopi.FieldType = ReportFieldTypeEnum.ftVariable;
                    makroskopi.MultiLine = EvetHayirEnum.ehEvet;
                    makroskopi.NoClip = EvetHayirEnum.ehEvet;
                    makroskopi.WordBreak = EvetHayirEnum.ehEvet;
                    makroskopi.ExpandTabs = EvetHayirEnum.ehEvet;
                    makroskopi.TextFont.Name = "Arial Narrow";
                    makroskopi.TextFont.Size = 9;
                    makroskopi.TextFont.CharSet = 162;
                    makroskopi.Value = @"";

                    lblMikroskopi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 73, 58, 78, false);
                    lblMikroskopi.Name = "lblMikroskopi";
                    lblMikroskopi.TextFont.Name = "Arial Narrow";
                    lblMikroskopi.TextFont.Bold = true;
                    lblMikroskopi.TextFont.Underline = true;
                    lblMikroskopi.TextFont.CharSet = 162;
                    lblMikroskopi.Value = @"Mikroskopi";

                    mikroskopi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 78, 202, 94, false);
                    mikroskopi.Name = "mikroskopi";
                    mikroskopi.FieldType = ReportFieldTypeEnum.ftVariable;
                    mikroskopi.MultiLine = EvetHayirEnum.ehEvet;
                    mikroskopi.NoClip = EvetHayirEnum.ehEvet;
                    mikroskopi.WordBreak = EvetHayirEnum.ehEvet;
                    mikroskopi.ExpandTabs = EvetHayirEnum.ehEvet;
                    mikroskopi.TextFont.Name = "Arial Narrow";
                    mikroskopi.TextFont.Size = 9;
                    mikroskopi.TextFont.CharSet = 162;
                    mikroskopi.Value = @"";

                    lblMikroskopi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 94, 58, 99, false);
                    lblMikroskopi1.Name = "lblMikroskopi1";
                    lblMikroskopi1.TextFont.Name = "Arial Narrow";
                    lblMikroskopi1.TextFont.Bold = true;
                    lblMikroskopi1.TextFont.Underline = true;
                    lblMikroskopi1.TextFont.CharSet = 162;
                    lblMikroskopi1.Value = @"Not/Yorum";

                    notyorum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 99, 202, 109, false);
                    notyorum.Name = "notyorum";
                    notyorum.FieldType = ReportFieldTypeEnum.ftVariable;
                    notyorum.MultiLine = EvetHayirEnum.ehEvet;
                    notyorum.NoClip = EvetHayirEnum.ehEvet;
                    notyorum.WordBreak = EvetHayirEnum.ehEvet;
                    notyorum.ExpandTabs = EvetHayirEnum.ehEvet;
                    notyorum.TextFont.Name = "Arial Narrow";
                    notyorum.TextFont.Size = 9;
                    notyorum.TextFont.CharSet = 162;
                    notyorum.Value = @"";

                    lblMikroskopi11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 109, 58, 114, false);
                    lblMikroskopi11.Name = "lblMikroskopi11";
                    lblMikroskopi11.TextFont.Name = "Arial Narrow";
                    lblMikroskopi11.TextFont.Bold = true;
                    lblMikroskopi11.TextFont.Underline = true;
                    lblMikroskopi11.TextFont.CharSet = 162;
                    lblMikroskopi11.Value = @"Tanı";

                    tani = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 114, 202, 122, false);
                    tani.Name = "tani";
                    tani.FieldType = ReportFieldTypeEnum.ftVariable;
                    tani.MultiLine = EvetHayirEnum.ehEvet;
                    tani.NoClip = EvetHayirEnum.ehEvet;
                    tani.WordBreak = EvetHayirEnum.ehEvet;
                    tani.ExpandTabs = EvetHayirEnum.ehEvet;
                    tani.TextFont.Name = "Arial Narrow";
                    tani.TextFont.Size = 9;
                    tani.TextFont.CharSet = 162;
                    tani.Value = @"";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 122, 38, 127, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Yapılan Tetkikler";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 127, 31, 132, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.Underline = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"SUT Kodu";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 127, 59, 132, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.Underline = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"İşlem";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 127, 145, 132, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.Underline = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Adet";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyMaterial.GetPathologyMaterialsByPathology_Class dataset_GetPathologyMaterialsByPathology = ParentGroup.rsGroup.GetCurrentRecord<PathologyMaterial.GetPathologyMaterialsByPathology_Class>(0);
                    lblPreDiagnosis1.CalcValue = lblPreDiagnosis1.Value;
                    MateryalArsivNo.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Materyalnumarasi) : "");
                    MATERIALOBJECTID.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Materialobjid) : "");
                    lblPreDiagnosis11.CalcValue = lblPreDiagnosis11.Value;
                    lblPreDiagnosis111.CalcValue = lblPreDiagnosis111.Value;
                    lblPreDiagnosis1111.CalcValue = lblPreDiagnosis1111.Value;
                    lblPreDiagnosis11111.CalcValue = lblPreDiagnosis11111.Value;
                    lblPreDiagnosis111111.CalcValue = lblPreDiagnosis111111.Value;
                    lblPreDiagnosis1111111.CalcValue = lblPreDiagnosis1111111.Value;
                    dotsPatientFatherName1.CalcValue = dotsPatientFatherName1.Value;
                    dotsPatientFatherName11.CalcValue = dotsPatientFatherName11.Value;
                    dotsPatientFatherName111.CalcValue = dotsPatientFatherName111.Value;
                    dotsPatientFatherName1111.CalcValue = dotsPatientFatherName1111.Value;
                    dotsPatientFatherName11111.CalcValue = dotsPatientFatherName11111.Value;
                    dotsPatientFatherName111111.CalcValue = dotsPatientFatherName111111.Value;
                    dotsPatientFatherName1111111.CalcValue = dotsPatientFatherName1111111.Value;
                    dateofsampletaken.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Numunealinmatarihi) : "");
                    alindigiorgan.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.TOPOGRAFIKODU) : "") + @"-" + (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.KODTANIMI) : "");
                    alindigidokununtemelozelligi.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Alindigidokununtemelozelligi) : "");
                    numunealinmasekli.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Numunealinmasekli) : "");
                    preparatdurumu.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Preparatdurumu) : "");
                    morfolojikodu.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Morfolojikodu) : "");
                    lblPreDiagnosis11111111.CalcValue = lblPreDiagnosis11111111.Value;
                    klinikbulgular.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Klinikbulgular) : "");
                    lblPreDiagnosis111111111.CalcValue = lblPreDiagnosis111111111.Value;
                    aciklama.CalcValue = (dataset_GetPathologyMaterialsByPathology != null ? Globals.ToStringCore(dataset_GetPathologyMaterialsByPathology.Aciklama) : "");
                    lblPreDiagnosis111111112.CalcValue = lblPreDiagnosis111111112.Value;
                    makroskopi.CalcValue = @"";
                    lblMikroskopi.CalcValue = lblMikroskopi.Value;
                    mikroskopi.CalcValue = @"";
                    lblMikroskopi1.CalcValue = lblMikroskopi1.Value;
                    notyorum.CalcValue = @"";
                    lblMikroskopi11.CalcValue = lblMikroskopi11.Value;
                    tani.CalcValue = @"";
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    return new TTReportObject[] { lblPreDiagnosis1,MateryalArsivNo,MATERIALOBJECTID,lblPreDiagnosis11,lblPreDiagnosis111,lblPreDiagnosis1111,lblPreDiagnosis11111,lblPreDiagnosis111111,lblPreDiagnosis1111111,dotsPatientFatherName1,dotsPatientFatherName11,dotsPatientFatherName111,dotsPatientFatherName1111,dotsPatientFatherName11111,dotsPatientFatherName111111,dotsPatientFatherName1111111,dateofsampletaken,alindigiorgan,alindigidokununtemelozelligi,numunealinmasekli,preparatdurumu,morfolojikodu,lblPreDiagnosis11111111,klinikbulgular,lblPreDiagnosis111111111,aciklama,lblPreDiagnosis111111112,makroskopi,lblMikroskopi,mikroskopi,lblMikroskopi1,notyorum,lblMikroskopi11,tani,NewField1321,NewField121,NewField1221,NewField11221};
                }

                public override void RunScript()
                {
#region PAGE HEADER_Script
                    //                                                            
                  TTObjectContext context = new TTObjectContext(true);
          
                                        
                        PathologyMaterial mObject = (PathologyMaterial)context.GetObject(new Guid(this.MATERIALOBJECTID.CalcValue.ToString()), "PathologyMaterial");
                    if(mObject.Macroscopy!= null)
                        this.makroskopi.CalcValue = TTReport.HTMLtoText(mObject.Macroscopy.ToString());
                    if (mObject.Microscopy != null)
                        this.mikroskopi.CalcValue = TTReport.HTMLtoText(mObject.Microscopy.ToString());
                    if (mObject.PathologicDiagnosis != null)
                        this.tani.CalcValue = TTReport.HTMLtoText(mObject.PathologicDiagnosis.ToString());
                    if (mObject.Note != null)
                        this.notyorum.CalcValue = TTReport.HTMLtoText(mObject.Note.ToString());
#endregion PAGE HEADER_Script
                }
            }
            public partial class PAGEGroupFooter : TTReportSection
            {
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
                }
                 
                public PAGEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PAGE FOOTER_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
//            
//            //Böyle kod mu olur, yaptım oldu.
//            
//            if(pObject.PathologyConsultantDoctors.Count > 0)
//                this.ConsDoctorHeader.Visible = EvetHayirEnum.ehEvet;
//            
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
//            
//            
//            //            foreach (TTObjectState objectState in pObject.GetStateHistory())
//            //            {
//            //                if (objectState.StateDefID == PathologyTest.States.Report)
//            //                {
//            //                    this.ReportDate.CalcValue = objectState.BranchDate.ToString();
//            //                }
//            //            }
////
//            
//            //this.ResponsibleDoctor.CalcValue = pObject.ResponsibleDoctor != null ? pObject.ResponsibleDoctor.SignatureBlock : String.Empty;
////            this.MaterialProtocolNo.CalcValue = pObject.MatPrtNoString;
////            this.testf.CalcValue = pObject.MatPrtNoString;
////
#endregion PAGE FOOTER_Script
                }
            }

        }

        public PAGEGroup PAGE;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyResultReportNew MyParentReport
            {
                get { return (PathologyResultReportNew)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
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
                list[0] = new TTReportNqlData<PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class>("GetPathologyProceduresByPathologyMaterial", PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PAGE.MATERIALOBJECTID.CalcValue)));
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
                public PathologyResultReportNew MyParentReport
                {
                    get { return (PathologyResultReportNew)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField NAME;
                public TTReportField AMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 31, 6, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#TETKIKKODU#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 123, 6, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#TETKIKADI#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 1, 144, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#TETKIKADETI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class dataset_GetPathologyProceduresByPathologyMaterial = ParentGroup.rsGroup.GetCurrentRecord<PathologyTestProcedure.GetPathologyProceduresByPathologyMaterial_Class>(0);
                    CODE.CalcValue = (dataset_GetPathologyProceduresByPathologyMaterial != null ? Globals.ToStringCore(dataset_GetPathologyProceduresByPathologyMaterial.Tetkikkodu) : "");
                    NAME.CalcValue = (dataset_GetPathologyProceduresByPathologyMaterial != null ? Globals.ToStringCore(dataset_GetPathologyProceduresByPathologyMaterial.Tetkikadi) : "");
                    AMOUNT.CalcValue = (dataset_GetPathologyProceduresByPathologyMaterial != null ? Globals.ToStringCore(dataset_GetPathologyProceduresByPathologyMaterial.Tetkikadeti) : "");
                    return new TTReportObject[] { CODE,NAME,AMOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
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

        public PathologyResultReportNew()
        {
            LastSection = new LastSectionGroup(this,"LastSection");
            HEADER = new HEADERGroup(LastSection,"HEADER");
            PAGE = new PAGEGroup(HEADER,"PAGE");
            MAIN = new MAINGroup(PAGE,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYRESULTREPORTNEW";
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