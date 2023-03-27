
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
    /// Patoloji İstek Adımı Bilgi Formu
    /// </summary>
    public partial class PathologyReqStateInfoForm : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class REPORTGroup : TTReportGroup
        {
            public PathologyReqStateInfoForm MyParentReport
            {
                get { return (PathologyReqStateInfoForm)ParentReport; }
            }

            new public REPORTGroupHeader Header()
            {
                return (REPORTGroupHeader)_header;
            }

            new public REPORTGroupFooter Footer()
            {
                return (REPORTGroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField XXXXXXBASLIK11 { get {return Header().XXXXXXBASLIK11;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField lblActionID1 { get {return Footer().lblActionID1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField PrintDate11 { get {return Footer().PrintDate11;} }
            public TTReportField UserName11 { get {return Footer().UserName11;} }
            public TTReportField PageNumber11 { get {return Footer().PageNumber11;} }
            public TTReportField lblActionIDnum { get {return Footer().lblActionIDnum;} }
            public TTReportField ActionID { get {return Footer().ActionID;} }
            public REPORTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REPORTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestReqStateInfoNQL_Class>("PathologyTestReqStateInfoNQL", Pathology.PathologyTestReqStateInfoNQL((string)TTObjectDefManager.Instance.DataTypes["String250"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new REPORTGroupHeader(this);
                _footer = new REPORTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class REPORTGroupHeader : TTReportSection
            {
                public PathologyReqStateInfoForm MyParentReport
                {
                    get { return (PathologyReqStateInfoForm)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField XXXXXXBASLIK11;
                public TTReportField LOGO; 
                public REPORTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 32, 204, 38, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 14;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"PATOLOJİ İSTEK ADIMI BİLGİ FORMU";

                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 8, 165, 30, false);
                    XXXXXXBASLIK11.Name = "XXXXXXBASLIK11";
                    XXXXXXBASLIK11.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.TextFont.Size = 11;
                    XXXXXXBASLIK11.TextFont.Bold = true;
                    XXXXXXBASLIK11.TextFont.CharSet = 162;
                    XXXXXXBASLIK11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 8, 54, 31, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestReqStateInfoNQL_Class dataset_PathologyTestReqStateInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestReqStateInfoNQL_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField121,LOGO,XXXXXXBASLIK11};
                }

                public override void RunScript()
                {
#region REPORT HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion REPORT HEADER_Script
                }
            }
            public partial class REPORTGroupFooter : TTReportSection
            {
                public PathologyReqStateInfoForm MyParentReport
                {
                    get { return (PathologyReqStateInfoForm)ParentReport; }
                }
                
                public TTReportField lblActionID1;
                public TTReportShape NewLine11;
                public TTReportField PrintDate11;
                public TTReportField UserName11;
                public TTReportField PageNumber11;
                public TTReportField lblActionIDnum;
                public TTReportField ActionID; 
                public REPORTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 39;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblActionID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 1, 128, 6, false);
                    lblActionID1.Name = "lblActionID1";
                    lblActionID1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblActionID1.TextFont.Size = 9;
                    lblActionID1.TextFont.Bold = true;
                    lblActionID1.TextFont.CharSet = 162;
                    lblActionID1.Value = @"İşlem No";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 27, 204, 27, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 28, 40, 33, false);
                    PrintDate11.Name = "PrintDate11";
                    PrintDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate11.TextFont.Size = 8;
                    PrintDate11.TextFont.CharSet = 162;
                    PrintDate11.Value = @"{@printdatetime@}";

                    UserName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 28, 122, 33, false);
                    UserName11.Name = "UserName11";
                    UserName11.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName11.TextFont.Size = 8;
                    UserName11.TextFont.CharSet = 162;
                    UserName11.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 28, 204, 33, false);
                    PageNumber11.Name = "PageNumber11";
                    PageNumber11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11.TextFont.Size = 8;
                    PageNumber11.TextFont.CharSet = 162;
                    PageNumber11.Value = @"{@pagenumber@}/{@pagecount@}";

                    lblActionIDnum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 21, 128, 26, false);
                    lblActionIDnum.Name = "lblActionIDnum";
                    lblActionIDnum.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblActionIDnum.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblActionIDnum.TextFont.Size = 9;
                    lblActionIDnum.TextFont.Bold = true;
                    lblActionIDnum.TextFont.CharSet = 162;
                    lblActionIDnum.Value = @"";

                    ActionID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 6, 134, 21, false);
                    ActionID.Name = "ActionID";
                    ActionID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ActionID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActionID.TextFont.Name = "Code39QuarterInchTT-Regular";
                    ActionID.TextFont.Size = 32;
                    ActionID.TextFont.CharSet = 0;
                    ActionID.Value = @"ACTIONID";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestReqStateInfoNQL_Class dataset_PathologyTestReqStateInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestReqStateInfoNQL_Class>(0);
                    lblActionID1.CalcValue = lblActionID1.Value;
                    PrintDate11.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber11.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    lblActionIDnum.CalcValue = lblActionIDnum.Value;
                    ActionID.CalcValue = ActionID.Value;
                    UserName11.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { lblActionID1,PrintDate11,PageNumber11,lblActionIDnum,ActionID,UserName11};
                }

                public override void RunScript()
                {
#region REPORT FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyReqStateInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            this.ActionID.CalcValue = pathologyTest.ID.Value.Value.ToString();
            this.lblActionIDnum.CalcValue = pathologyTest.ID.Value.Value.ToString();
#endregion REPORT FOOTER_Script
                }
            }

        }

        public REPORTGroup REPORT;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyReqStateInfoForm MyParentReport
            {
                get { return (PathologyReqStateInfoForm)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField13211 { get {return Body().NewField13211;} }
            public TTReportField NewField14211 { get {return Body().NewField14211;} }
            public TTReportField NewField15211 { get {return Body().NewField15211;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField AcceptionDate { get {return Body().AcceptionDate;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField Age { get {return Body().Age;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField111221 { get {return Body().NewField111221;} }
            public TTReportField NewField111241 { get {return Body().NewField111241;} }
            public TTReportField NewField111261 { get {return Body().NewField111261;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public TTReportField NewField1201 { get {return Body().NewField1201;} }
            public TTReportField NewField1211 { get {return Body().NewField1211;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1142111 { get {return Body().NewField1142111;} }
            public TTReportField NewField11121 { get {return Body().NewField11121;} }
            public TTReportField NewField11511 { get {return Body().NewField11511;} }
            public TTReportField NewField1162111 { get {return Body().NewField1162111;} }
            public TTReportField NewField11811 { get {return Body().NewField11811;} }
            public TTReportField NewField12511 { get {return Body().NewField12511;} }
            public TTReportField NewField1262111 { get {return Body().NewField1262111;} }
            public TTReportField NewField12811 { get {return Body().NewField12811;} }
            public TTReportField NewField13511 { get {return Body().NewField13511;} }
            public TTReportField NewField1362111 { get {return Body().NewField1362111;} }
            public TTReportField NewField13811 { get {return Body().NewField13811;} }
            public TTReportField NewField111531 { get {return Body().NewField111531;} }
            public TTReportField NewField111831 { get {return Body().NewField111831;} }
            public TTReportField PatientStatus1 { get {return Body().PatientStatus1;} }
            public TTReportField PatientGroup1 { get {return Body().PatientGroup1;} }
            public TTReportField NewField11212 { get {return Body().NewField11212;} }
            public TTReportField NewField111231 { get {return Body().NewField111231;} }
            public TTReportField PatientStatus2 { get {return Body().PatientStatus2;} }
            public TTReportField PatientGroup2 { get {return Body().PatientGroup2;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField111242 { get {return Body().NewField111242;} }
            public TTReportField FieldDateOfSampleTaken { get {return Body().FieldDateOfSampleTaken;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField NewField11213 { get {return Body().NewField11213;} }
            public TTReportField Uniquerefno { get {return Body().Uniquerefno;} }
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
                list[0] = new TTReportNqlData<Pathology.PathologyTestResultPatientInfoReportQuery_Class>("PathologyTestResultPatientInfoReportQuery", Pathology.PathologyTestResultPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyReqStateInfoForm MyParentReport
                {
                    get { return (PathologyReqStateInfoForm)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField12;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField1121;
                public TTReportField NewField12211;
                public TTReportField NewField13211;
                public TTReportField NewField14211;
                public TTReportField NewField15211;
                public TTReportField NewField13;
                public TTReportField NewField171;
                public TTReportField AcceptionDate;
                public TTReportField NewField112;
                public TTReportField Age;
                public TTReportField NewField1111;
                public TTReportField NewField121;
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField NewField111211;
                public TTReportField NewField111221;
                public TTReportField NewField111241;
                public TTReportField NewField111261;
                public TTReportField NewField1181;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField NewField1211;
                public TTReportField NewField1221;
                public TTReportField NewField1142111;
                public TTReportField NewField11121;
                public TTReportField NewField11511;
                public TTReportField NewField1162111;
                public TTReportField NewField11811;
                public TTReportField NewField12511;
                public TTReportField NewField1262111;
                public TTReportField NewField12811;
                public TTReportField NewField13511;
                public TTReportField NewField1362111;
                public TTReportField NewField13811;
                public TTReportField NewField111531;
                public TTReportField NewField111831;
                public TTReportField PatientStatus1;
                public TTReportField PatientGroup1;
                public TTReportField NewField11212;
                public TTReportField NewField111231;
                public TTReportField PatientStatus2;
                public TTReportField PatientGroup2;
                public TTReportField NewField122;
                public TTReportField NewField111242;
                public TTReportField FieldDateOfSampleTaken;
                public TTReportField NewField113;
                public TTReportField NewField11213;
                public TTReportField Uniquerefno; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 65;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 18, 46, 23, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Adı Soyadı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 54, 46, 59, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Patoloji Kabul Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 48, 46, 53, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İstek Tarihi";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 30, 46, 35, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Doğum Tarihi";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 24, 46, 29, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Yaşı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 18, 48, 23, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 54, 48, 59, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Size = 9;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @":";

                    NewField13211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 24, 48, 29, false);
                    NewField13211.Name = "NewField13211";
                    NewField13211.TextFont.Size = 9;
                    NewField13211.TextFont.Bold = true;
                    NewField13211.TextFont.CharSet = 162;
                    NewField13211.Value = @":";

                    NewField14211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 48, 48, 53, false);
                    NewField14211.Name = "NewField14211";
                    NewField14211.TextFont.Size = 9;
                    NewField14211.TextFont.Bold = true;
                    NewField14211.TextFont.CharSet = 162;
                    NewField14211.Value = @":";

                    NewField15211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 30, 48, 35, false);
                    NewField15211.Name = "NewField15211";
                    NewField15211.TextFont.Size = 9;
                    NewField15211.TextFont.Bold = true;
                    NewField15211.TextFont.CharSet = 162;
                    NewField15211.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 18, 102, 23, false);
                    NewField13.Name = "NewField13";
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"{#REPORT.NAME#} {#REPORT.SURNAME#}";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 30, 102, 35, false);
                    NewField171.Name = "NewField171";
                    NewField171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"{#REPORT.BIRTHDATE#}";

                    AcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 54, 102, 59, false);
                    AcceptionDate.Name = "AcceptionDate";
                    AcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    AcceptionDate.TextFont.Size = 9;
                    AcceptionDate.TextFont.CharSet = 162;
                    AcceptionDate.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 48, 102, 53, false);
                    NewField112.Name = "NewField112";
                    NewField112.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField112.TextFormat = @"dd/MM/yyyy HH:mm";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"{#REPORT.ACTIONDATE#}";

                    Age = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 24, 102, 29, false);
                    Age.Name = "Age";
                    Age.TextFont.Size = 9;
                    Age.TextFont.CharSet = 162;
                    Age.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 36, 46, 41, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Cinsiyeti";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 30, 148, 35, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İstek Yapan Doktor Tel No";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 42, 148, 47, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"İstek Yapan Doktor Bölümü";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 36, 148, 41, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"İstek Yapan Doktor Ünvanı";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 36, 150, 41, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @":";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 36, 48, 41, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.TextFont.Size = 9;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @":";

                    NewField111241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 30, 150, 35, false);
                    NewField111241.Name = "NewField111241";
                    NewField111241.TextFont.Size = 9;
                    NewField111241.TextFont.Bold = true;
                    NewField111241.TextFont.CharSet = 162;
                    NewField111241.Value = @":";

                    NewField111261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 42, 150, 47, false);
                    NewField111261.Name = "NewField111261";
                    NewField111261.TextFont.Size = 9;
                    NewField111261.TextFont.Bold = true;
                    NewField111261.TextFont.CharSet = 162;
                    NewField111261.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 42, 204, 47, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"{#REPORT.FROMRESOURCE#}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 36, 204, 41, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"{#REPORT.REQDOCTITLE#}";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 36, 102, 41, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1201.ObjectDefName = "SexEnum";
                    NewField1201.DataMember = "DISPLAYTEXT";
                    NewField1201.TextFont.Size = 9;
                    NewField1201.TextFont.CharSet = 162;
                    NewField1201.Value = @"{#REPORT.SEX#}";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 30, 204, 35, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1211.TextFont.Size = 9;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"{#REPORT.REQDOCPHONENUMBER#}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 24, 148, 29, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"İstek Yapan Doktor";

                    NewField1142111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 24, 150, 29, false);
                    NewField1142111.Name = "NewField1142111";
                    NewField1142111.TextFont.Size = 9;
                    NewField1142111.TextFont.Bold = true;
                    NewField1142111.TextFont.CharSet = 162;
                    NewField1142111.Value = @":";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 24, 204, 29, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11121.TextFont.Size = 9;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"{#REPORT.REQDOCNAME#}";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 48, 148, 53, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Size = 9;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Sorumlu Doktor";

                    NewField1162111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 48, 150, 53, false);
                    NewField1162111.Name = "NewField1162111";
                    NewField1162111.TextFont.Size = 9;
                    NewField1162111.TextFont.Bold = true;
                    NewField1162111.TextFont.CharSet = 162;
                    NewField1162111.Value = @":";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 48, 204, 53, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11811.TextFont.Size = 9;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @"{#REPORT.RESPDOCNAME#}";

                    NewField12511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 54, 148, 59, false);
                    NewField12511.Name = "NewField12511";
                    NewField12511.TextFont.Size = 9;
                    NewField12511.TextFont.Bold = true;
                    NewField12511.TextFont.CharSet = 162;
                    NewField12511.Value = @"Sorumlu Doktor Tel No";

                    NewField1262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 54, 150, 59, false);
                    NewField1262111.Name = "NewField1262111";
                    NewField1262111.TextFont.Size = 9;
                    NewField1262111.TextFont.Bold = true;
                    NewField1262111.TextFont.CharSet = 162;
                    NewField1262111.Value = @":";

                    NewField12811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 54, 204, 59, false);
                    NewField12811.Name = "NewField12811";
                    NewField12811.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField12811.TextFont.Size = 9;
                    NewField12811.TextFont.CharSet = 162;
                    NewField12811.Value = @"{#REPORT.RESPDOCTEL#}";

                    NewField13511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 60, 148, 65, false);
                    NewField13511.Name = "NewField13511";
                    NewField13511.TextFont.Size = 9;
                    NewField13511.TextFont.Bold = true;
                    NewField13511.TextFont.CharSet = 162;
                    NewField13511.Value = @"Sorumlu Uzm. Öğrencisi Doktor";

                    NewField1362111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 60, 150, 65, false);
                    NewField1362111.Name = "NewField1362111";
                    NewField1362111.TextFont.Size = 9;
                    NewField1362111.TextFont.Bold = true;
                    NewField1362111.TextFont.CharSet = 162;
                    NewField1362111.Value = @":";

                    NewField13811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 60, 204, 65, false);
                    NewField13811.Name = "NewField13811";
                    NewField13811.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13811.TextFont.Size = 9;
                    NewField13811.TextFont.CharSet = 162;
                    NewField13811.Value = @"{#REPORT.ASSISTANTDOCNAME#}";

                    NewField111531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 52, 10, false);
                    NewField111531.Name = "NewField111531";
                    NewField111531.TextFont.Size = 11;
                    NewField111531.TextFont.Bold = true;
                    NewField111531.TextFont.CharSet = 162;
                    NewField111531.Value = @"Materyal Protokol No :";

                    NewField111831 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 4, 139, 11, false);
                    NewField111831.Name = "NewField111831";
                    NewField111831.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111831.TextFont.Size = 16;
                    NewField111831.TextFont.Bold = true;
                    NewField111831.TextFont.CharSet = 162;
                    NewField111831.Value = @"{#REPORT.MATPRTNO#}";

                    PatientStatus1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 12, 148, 17, false);
                    PatientStatus1.Name = "PatientStatus1";
                    PatientStatus1.TextFont.Size = 9;
                    PatientStatus1.TextFont.Bold = true;
                    PatientStatus1.TextFont.CharSet = 162;
                    PatientStatus1.Value = @"Hasta Tipi";

                    PatientGroup1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 18, 148, 23, false);
                    PatientGroup1.Name = "PatientGroup1";
                    PatientGroup1.TextFont.Size = 9;
                    PatientGroup1.TextFont.Bold = true;
                    PatientGroup1.TextFont.CharSet = 162;
                    PatientGroup1.Value = @"Hasta Grubu";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 12, 150, 17, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.TextFont.Size = 9;
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @":";

                    NewField111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 18, 150, 23, false);
                    NewField111231.Name = "NewField111231";
                    NewField111231.TextFont.Size = 9;
                    NewField111231.TextFont.Bold = true;
                    NewField111231.TextFont.CharSet = 162;
                    NewField111231.Value = @":";

                    PatientStatus2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 12, 204, 17, false);
                    PatientStatus2.Name = "PatientStatus2";
                    PatientStatus2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus2.ObjectDefName = "PatientStatusEnum";
                    PatientStatus2.DataMember = "DISPLAYTEXT";
                    PatientStatus2.TextFont.Size = 9;
                    PatientStatus2.TextFont.CharSet = 162;
                    PatientStatus2.Value = @"{#PATIENTSTATUS#}";

                    PatientGroup2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 18, 204, 23, false);
                    PatientGroup2.Name = "PatientGroup2";
                    PatientGroup2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientGroup2.ObjectDefName = "PatientGroupEnum";
                    PatientGroup2.DataMember = "DISPLAYTEXT";
                    PatientGroup2.TextFont.Size = 9;
                    PatientGroup2.TextFont.CharSet = 162;
                    PatientGroup2.Value = @"{#PATIENTGROUP#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 42, 46, 47, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Numune Alım Tarihi";

                    NewField111242 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 42, 48, 47, false);
                    NewField111242.Name = "NewField111242";
                    NewField111242.TextFont.Size = 9;
                    NewField111242.TextFont.Bold = true;
                    NewField111242.TextFont.CharSet = 162;
                    NewField111242.Value = @":";

                    FieldDateOfSampleTaken = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 42, 102, 47, false);
                    FieldDateOfSampleTaken.Name = "FieldDateOfSampleTaken";
                    FieldDateOfSampleTaken.FieldType = ReportFieldTypeEnum.ftVariable;
                    FieldDateOfSampleTaken.TextFormat = @"dd/MM/yyyy HH:mm";
                    FieldDateOfSampleTaken.TextFont.Size = 9;
                    FieldDateOfSampleTaken.TextFont.CharSet = 162;
                    FieldDateOfSampleTaken.Value = @"";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 12, 46, 17, false);
                    NewField113.Name = "NewField113";
                    NewField113.TextFont.Size = 9;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"TC Kimlik No";

                    NewField11213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 12, 48, 17, false);
                    NewField11213.Name = "NewField11213";
                    NewField11213.TextFont.Size = 9;
                    NewField11213.TextFont.Bold = true;
                    NewField11213.TextFont.CharSet = 162;
                    NewField11213.Value = @":";

                    Uniquerefno = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 12, 102, 17, false);
                    Uniquerefno.Name = "Uniquerefno";
                    Uniquerefno.FieldType = ReportFieldTypeEnum.ftVariable;
                    Uniquerefno.TextFont.Size = 9;
                    Uniquerefno.TextFont.CharSet = 162;
                    Uniquerefno.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestResultPatientInfoReportQuery_Class dataset_PathologyTestResultPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestResultPatientInfoReportQuery_Class>(0);
                    Pathology.PathologyTestReqStateInfoNQL_Class dataset_PathologyTestReqStateInfoNQL = MyParentReport.REPORT.rsGroup.GetCurrentRecord<Pathology.PathologyTestReqStateInfoNQL_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField13211.CalcValue = NewField13211.Value;
                    NewField14211.CalcValue = NewField14211.Value;
                    NewField15211.CalcValue = NewField15211.Value;
                    NewField13.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Name) : "") + @" " + (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Surname) : "");
                    NewField171.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.BirthDate) : "");
                    AcceptionDate.CalcValue = AcceptionDate.Value;
                    NewField112.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.ActionDate) : "");
                    Age.CalcValue = Age.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField111241.CalcValue = NewField111241.Value;
                    NewField111261.CalcValue = NewField111261.Value;
                    NewField1181.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Fromresource) : "");
                    NewField1191.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Reqdoctitle) : "");
                    NewField1201.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Sex) : "");
                    NewField1201.PostFieldValueCalculation();
                    NewField1211.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Reqdocphonenumber) : "");
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1142111.CalcValue = NewField1142111.Value;
                    NewField11121.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Reqdocname) : "");
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField1162111.CalcValue = NewField1162111.Value;
                    NewField11811.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Respdocname) : "");
                    NewField12511.CalcValue = NewField12511.Value;
                    NewField1262111.CalcValue = NewField1262111.Value;
                    NewField12811.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Respdoctel) : "");
                    NewField13511.CalcValue = NewField13511.Value;
                    NewField1362111.CalcValue = NewField1362111.Value;
                    NewField13811.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Assistantdocname) : "");
                    NewField111531.CalcValue = NewField111531.Value;
                    NewField111831.CalcValue = (dataset_PathologyTestReqStateInfoNQL != null ? Globals.ToStringCore(dataset_PathologyTestReqStateInfoNQL.Matprtno) : "");
                    PatientStatus1.CalcValue = PatientStatus1.Value;
                    PatientGroup1.CalcValue = PatientGroup1.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField111231.CalcValue = NewField111231.Value;
                    PatientStatus2.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.PatientStatus) : "");
                    PatientStatus2.PostFieldValueCalculation();
                    PatientGroup2.CalcValue = (dataset_PathologyTestResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyTestResultPatientInfoReportQuery.Patientgroup) : "");
                    PatientGroup2.PostFieldValueCalculation();
                    NewField122.CalcValue = NewField122.Value;
                    NewField111242.CalcValue = NewField111242.Value;
                    FieldDateOfSampleTaken.CalcValue = @"";
                    NewField113.CalcValue = NewField113.Value;
                    NewField11213.CalcValue = NewField11213.Value;
                    Uniquerefno.CalcValue = @"";
                    return new TTReportObject[] { NewField11,NewField111,NewField12,NewField131,NewField141,NewField1121,NewField12211,NewField13211,NewField14211,NewField15211,NewField13,NewField171,AcceptionDate,NewField112,Age,NewField1111,NewField121,NewField1151,NewField1161,NewField111211,NewField111221,NewField111241,NewField111261,NewField1181,NewField1191,NewField1201,NewField1211,NewField1221,NewField1142111,NewField11121,NewField11511,NewField1162111,NewField11811,NewField12511,NewField1262111,NewField12811,NewField13511,NewField1362111,NewField13811,NewField111531,NewField111831,PatientStatus1,PatientGroup1,NewField11212,NewField111231,PatientStatus2,PatientGroup2,NewField122,NewField111242,FieldDateOfSampleTaken,NewField113,NewField11213,Uniquerefno};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyReqStateInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //string sObjectID = this.NewField4.CalcValue;
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            
            //if(pathologyTest.PathologyRequest.DateOfSampleTaken != null)
            //    this.FieldDateOfSampleTaken.CalcValue = pathologyTest.PathologyRequest.DateOfSampleTaken.ToString();
            
            this.Age.CalcValue = pathologyTest.Episode.Patient.Age.ToString();
            
            if(pathologyTest.Episode.Patient.UniqueRefNo != null && pathologyTest.Episode.Patient.UniqueRefNo.HasValue)
                this.Uniquerefno.CalcValue = pathologyTest.Episode.Patient.UniqueRefNo.Value.ToString();
            
            //            string CrLf = "\r\n";
            //            string DiagnosisText = "";
            //            string MatPrtNoString = "";
            
            //            Patient patient = pathologyTest.Pathology.Episode.Patient;
//
            //            foreach (Episode episode in patient.Episodes)
            //            {
            //                foreach(EpisodeAction episodeAction in episode.EpisodeActions)
            //                {
            //                    foreach(SubactionProcedureFlowable subActionFlowable in episodeAction.SubactionProcedureFlowables)
            //                    {
            //                        if(subActionFlowable is PathologyTest)
            //                        {
            //                            MatPrtNoString = ((PathologyTest)subActionFlowable).MatPrtNoString;
            //                            foreach(DiagnosisGrid diagGrid in subActionFlowable.EpisodeAction.Episode.Diagnosis)
            //                            {
            //                                if(MatPrtNoString != null)
            //                                {
            //                                    DiagnosisText += diagGrid.Diagnose.Name + "  -  " + MatPrtNoString + CrLf;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
//
            //            this.Diagnosis.CalcValue = DiagnosisText;
            this.AcceptionDate.CalcValue = TTObjectClasses.Common.RecTime().ToString();
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ACCEPTIONNOTEGroup : TTReportGroup
        {
            public PathologyReqStateInfoForm MyParentReport
            {
                get { return (PathologyReqStateInfoForm)ParentReport; }
            }

            new public ACCEPTIONNOTEGroupBody Body()
            {
                return (ACCEPTIONNOTEGroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField111261 { get {return Body().NewField111261;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public ACCEPTIONNOTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ACCEPTIONNOTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ACCEPTIONNOTEGroupBody(this);
            }

            public partial class ACCEPTIONNOTEGroupBody : TTReportSection
            {
                public PathologyReqStateInfoForm MyParentReport
                {
                    get { return (PathologyReqStateInfoForm)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField111261;
                public TTReportField NewField1181; 
                public ACCEPTIONNOTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 46, 6, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Kabul Notu";

                    NewField111261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 48, 6, false);
                    NewField111261.Name = "NewField111261";
                    NewField111261.TextFont.Size = 9;
                    NewField111261.TextFont.Bold = true;
                    NewField111261.TextFont.CharSet = 162;
                    NewField111261.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 1, 204, 6, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1181.NoClip = EvetHayirEnum.ehEvet;
                    NewField1181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1181.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField111261.CalcValue = NewField111261.Value;
                    NewField1181.CalcValue = @"";
                    return new TTReportObject[] { NewField1151,NewField111261,NewField1181};
                }
            }

        }

        public ACCEPTIONNOTEGroup ACCEPTIONNOTE;

        public partial class PREDIAGNOSISGroup : TTReportGroup
        {
            public PathologyReqStateInfoForm MyParentReport
            {
                get { return (PathologyReqStateInfoForm)ParentReport; }
            }

            new public PREDIAGNOSISGroupBody Body()
            {
                return (PREDIAGNOSISGroupBody)_body;
            }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public PREDIAGNOSISGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PREDIAGNOSISGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PREDIAGNOSISGroupBody(this);
            }

            public partial class PREDIAGNOSISGroupBody : TTReportSection
            {
                public PathologyReqStateInfoForm MyParentReport
                {
                    get { return (PathologyReqStateInfoForm)ParentReport; }
                }
                
                public TTReportField NewField1161;
                public TTReportField NewField111211;
                public TTReportField NewField1191; 
                public PREDIAGNOSISGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 46, 6, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Kısa Anamnez";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 48, 6, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @":";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 1, 204, 6, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1191.NoClip = EvetHayirEnum.ehEvet;
                    NewField1191.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1191.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1191.CalcValue = @"";
                    return new TTReportObject[] { NewField1161,NewField111211,NewField1191};
                }
            }

        }

        public PREDIAGNOSISGroup PREDIAGNOSIS;

        public partial class TESTGroup : TTReportGroup
        {
            public PathologyReqStateInfoForm MyParentReport
            {
                get { return (PathologyReqStateInfoForm)ParentReport; }
            }

            new public TESTGroupBody Body()
            {
                return (TESTGroupBody)_body;
            }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField NewField11521 { get {return Body().NewField11521;} }
            public TTReportField Diagnosis { get {return Body().Diagnosis;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField12221 { get {return Body().NewField12221;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField NewField112221 { get {return Body().NewField112221;} }
            public TTReportField CATEGORY2 { get {return Body().CATEGORY2;} }
            public TTReportField CODE2 { get {return Body().CODE2;} }
            public TTReportField NAME2 { get {return Body().NAME2;} }
            public TTReportField LOCALISATION2 { get {return Body().LOCALISATION2;} }
            public TESTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TESTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TESTGroupBody(this);
            }

            public partial class TESTGroupBody : TTReportSection
            {
                public PathologyReqStateInfoForm MyParentReport
                {
                    get { return (PathologyReqStateInfoForm)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField NewField11521;
                public TTReportField Diagnosis;
                public TTReportField NewField1221;
                public TTReportField NewField12211;
                public TTReportField NewField12221;
                public TTReportField NewField11231;
                public TTReportField NewField112221;
                public TTReportField CATEGORY2;
                public TTReportField CODE2;
                public TTReportField NAME2;
                public TTReportField LOCALISATION2; 
                public TESTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 37;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 1, 204, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 93, 25, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.TextFont.Size = 9;
                    NewField11521.TextFont.Bold = true;
                    NewField11521.TextFont.CharSet = 162;
                    NewField11521.Value = @"ESKİ TANILARI ve MATERYAL PROTOKOL NUMARALARI";

                    Diagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 26, 204, 36, false);
                    Diagnosis.Name = "Diagnosis";
                    Diagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    Diagnosis.NoClip = EvetHayirEnum.ehEvet;
                    Diagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    Diagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    Diagnosis.TextFont.Size = 9;
                    Diagnosis.TextFont.CharSet = 162;
                    Diagnosis.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 8, 31, 13, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.Underline = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"SUT Kodu";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 8, 55, 13, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Size = 9;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.Underline = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"Örnek Kategorisi";

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 8, 79, 13, false);
                    NewField12221.Name = "NewField12221";
                    NewField12221.TextFont.Size = 9;
                    NewField12221.TextFont.Bold = true;
                    NewField12221.TextFont.Underline = true;
                    NewField12221.TextFont.CharSet = 162;
                    NewField12221.Value = @"İşlem";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 2, 39, 7, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"Yapılacak Tetkik";

                    NewField112221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 8, 171, 13, false);
                    NewField112221.Name = "NewField112221";
                    NewField112221.TextFont.Size = 9;
                    NewField112221.TextFont.Bold = true;
                    NewField112221.TextFont.Underline = true;
                    NewField112221.TextFont.CharSet = 162;
                    NewField112221.Value = @"Lokalizasyon";

                    CATEGORY2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 13, 55, 18, false);
                    CATEGORY2.Name = "CATEGORY2";
                    CATEGORY2.FieldType = ReportFieldTypeEnum.ftVariable;
                    CATEGORY2.TextFont.CharSet = 162;
                    CATEGORY2.Value = @"";

                    CODE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 13, 31, 18, false);
                    CODE2.Name = "CODE2";
                    CODE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE2.TextFont.CharSet = 162;
                    CODE2.Value = @"";

                    NAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 13, 146, 18, false);
                    NAME2.Name = "NAME2";
                    NAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME2.TextFont.CharSet = 162;
                    NAME2.Value = @"";

                    LOCALISATION2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 13, 204, 18, false);
                    LOCALISATION2.Name = "LOCALISATION2";
                    LOCALISATION2.FieldType = ReportFieldTypeEnum.ftVariable;
                    LOCALISATION2.MultiLine = EvetHayirEnum.ehEvet;
                    LOCALISATION2.NoClip = EvetHayirEnum.ehEvet;
                    LOCALISATION2.WordBreak = EvetHayirEnum.ehEvet;
                    LOCALISATION2.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOCALISATION2.TextFont.CharSet = 162;
                    LOCALISATION2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11521.CalcValue = NewField11521.Value;
                    Diagnosis.CalcValue = Diagnosis.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField12221.CalcValue = NewField12221.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField112221.CalcValue = NewField112221.Value;
                    CATEGORY2.CalcValue = @"";
                    CODE2.CalcValue = @"";
                    NAME2.CalcValue = @"";
                    LOCALISATION2.CalcValue = @"";
                    return new TTReportObject[] { NewField11521,Diagnosis,NewField1221,NewField12211,NewField12221,NewField11231,NewField112221,CATEGORY2,CODE2,NAME2,LOCALISATION2};
                }

                public override void RunScript()
                {
#region TEST BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyReqStateInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //string sObjectID = this.NewField4.CalcValue;
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            //this.Age.CalcValue = pathologyTest.Episode.Patient.Age.ToString();
            
            string CrLf = "\r\n";
            string DiagnosisText = "";
            string MatPrtNoString = "";
            
            Patient patient = pathologyTest.PathologyRequest.Episode.Patient;
            
            ///
            /// Bu bölümün daha hızlı çalışması için aşağıdaki değişiklik gerçekleştirilmiştir.
            ///
            /*
            foreach (Episode episode in patient.Episodes)
            {
                foreach(EpisodeAction episodeAction in episode.EpisodeActions)
                {
                    foreach(SubactionProcedureFlowable subActionFlowable in episodeAction.SubactionProcedureFlowables)
                    {
                        if(subActionFlowable is PathologyTest)
                        {
                            MatPrtNoString = ((PathologyTest)subActionFlowable).MatPrtNoString;
                            foreach(DiagnosisGrid diagGrid in subActionFlowable.EpisodeAction.Episode.Diagnosis)
                            {
                                if(MatPrtNoString != null)
                                {
                                    DiagnosisText += diagGrid.Diagnose.Name + "  -  " + MatPrtNoString + CrLf;
                                }
                            }
                        }
                    }
                }
            }
             */

            ///
            /// Yukarıda belirtilen kodun daha hızlı çalışması için düzenlenmiş hali aşağıdaki şekildedir.
            ///
            
            //List<DiagnosisDefinition> distinctList = new List<DiagnosisDefinition>(); //Tekrarlayan tanıların ayıklanmasında kullanılan liste
            

            //foreach (Episode episode in patient.Episodes)
            //{
            //    foreach (SubactionProcedureFlowable subActionFlowable in episode.SubactionProcedureFlowables)
            //    {
            //        if (subActionFlowable is PathologyTest)
            //        {
            //            MatPrtNoString = ((PathologyTest)subActionFlowable).MatPrtNoString;
            //            foreach (DiagnosisGrid diagGrid in subActionFlowable.Episode.Diagnosis)
            //            {
            //                if (distinctList.Contains(diagGrid.Diagnose) == false) //Tekrarlayan tanılar burada ayıklanır...
            //                {
            //                    if (MatPrtNoString != null)
            //                    {
            //                        DiagnosisText += diagGrid.Diagnose.Code.Trim() + "  "+ diagGrid.Diagnose.Name + "  -  " + MatPrtNoString + CrLf;
            //                        distinctList.Add(diagGrid.Diagnose);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            
            //distinctList = null;


            Dictionary<DiagnosisDefinition, List<string>> dictionary = new Dictionary<DiagnosisDefinition, List<string>> ();

           //TODO ASLI          
           /* foreach (Episode episode in patient.Episodes)
            {
                foreach (SubactionProcedureFlowable subActionFlowable in episode.SubactionProcedureFlowables)
                {
                    if (subActionFlowable is Pathology)
                    {
                        MatPrtNoString = ((Pathology)subActionFlowable).MatPrtNoString;
                        foreach (DiagnosisGrid diagGrid in subActionFlowable.Episode.Diagnosis)
                        {
                            if(dictionary.ContainsKey(diagGrid.Diagnose))
                            {
                                if(MatPrtNoString != null)
                                    dictionary[diagGrid.Diagnose].Add(MatPrtNoString);
                            }
                            else
                            {
                                dictionary.Add(diagGrid.Diagnose, new List<string> ());

                                if(MatPrtNoString != null)
                                    dictionary[diagGrid.Diagnose].Add(MatPrtNoString);
                            }
                        }
                    }
                }
            }*/

            int str_Counter = 0;
            foreach (KeyValuePair<DiagnosisDefinition, List<string>> item in dictionary)
            {
                DiagnosisText += item.Key.Code.Trim() + "  " + item.Key.Name + "  (  ";
                str_Counter = 0;
                foreach(string str in item.Value)
                {
                    DiagnosisText += str;
                    if (str_Counter != item.Value.Count - 1)
                        DiagnosisText += " - ";
                    str_Counter++;
                }

                DiagnosisText += " ) ";

                DiagnosisText += CrLf;
                    
            }



            
            this.Diagnosis.CalcValue = DiagnosisText;
            //this.AcceptionDate.CalcValue = TTObjectClasses.Common.RecTime().ToLongDateString();
#endregion TEST BODY_Script
                }
            }

        }

        public TESTGroup TEST;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PathologyReqStateInfoForm()
        {
            REPORT = new REPORTGroup(this,"REPORT");
            MAIN = new MAINGroup(REPORT,"MAIN");
            ACCEPTIONNOTE = new ACCEPTIONNOTEGroup(REPORT,"ACCEPTIONNOTE");
            PREDIAGNOSIS = new PREDIAGNOSISGroup(REPORT,"PREDIAGNOSIS");
            TEST = new TESTGroup(REPORT,"TEST");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Episode Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYREQSTATEINFOFORM";
            Caption = "Patoloji İstek Adımı Bilgi Formu";
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