
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
    /// Radyoloji Sonuç Raporu
    /// </summary>
    public partial class PsychologyTestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PsychologyTestReport MyParentReport
            {
                get { return (PsychologyTestReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField REPORTHEADER11 { get {return Header().REPORTHEADER11;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PROCEDUREBYUSER11 { get {return Footer().PROCEDUREBYUSER11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
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
                list[0] = new TTReportNqlData<PsychologyTest.PsychologyTestResultReport_Class>("PsychologyTestResultReport", PsychologyTest.PsychologyTestResultReport((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PsychologyTestReport MyParentReport
                {
                    get { return (PsychologyTestReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField REPORTHEADER11;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 2, 200, 38, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 14;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 40, 187, 46, false);
                    REPORTHEADER11.Name = "REPORTHEADER11";
                    REPORTHEADER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER11.TextFont.Size = 12;
                    REPORTHEADER11.TextFont.Bold = true;
                    REPORTHEADER11.TextFont.CharSet = 162;
                    REPORTHEADER11.Value = @"Psikolog Tetkik Sonuç Raporu";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 10, 35, 33, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PsychologyTest.PsychologyTestResultReport_Class dataset_PsychologyTestResultReport = ParentGroup.rsGroup.GetCurrentRecord<PsychologyTest.PsychologyTestResultReport_Class>(0);
                    REPORTHEADER11.CalcValue = REPORTHEADER11.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { REPORTHEADER11,LOGO,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PsychologyTestReport MyParentReport
                {
                    get { return (PsychologyTestReport)ParentReport; }
                }
                
                public TTReportField PROCEDUREBYUSER11;
                public TTReportField NewField12; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 21;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROCEDUREBYUSER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 6, 200, 11, false);
                    PROCEDUREBYUSER11.Name = "PROCEDUREBYUSER11";
                    PROCEDUREBYUSER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBYUSER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCEDUREBYUSER11.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREBYUSER11.TextFont.Size = 12;
                    PROCEDUREBYUSER11.TextFont.CharSet = 162;
                    PROCEDUREBYUSER11.Value = @"{#PROCEDUREBYUSER#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 11, 163, 16, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Psikolog";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PsychologyTest.PsychologyTestResultReport_Class dataset_PsychologyTestResultReport = ParentGroup.rsGroup.GetCurrentRecord<PsychologyTest.PsychologyTestResultReport_Class>(0);
                    PROCEDUREBYUSER11.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.Procedurebyuser) : "");
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { PROCEDUREBYUSER11,NewField12};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public PsychologyTestReport MyParentReport
            {
                get { return (PsychologyTestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblREQUESTDATE { get {return Body().lblREQUESTDATE;} }
            public TTReportField lblDOCTORNAME { get {return Body().lblDOCTORNAME;} }
            public TTReportField lblFROMRESOURCE { get {return Body().lblFROMRESOURCE;} }
            public TTReportField REQUESTDOCTOR { get {return Body().REQUESTDOCTOR;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField lblNAME { get {return Body().lblNAME;} }
            public TTReportField lblPROTOKOLNO { get {return Body().lblPROTOKOLNO;} }
            public TTReportField dotsNAME { get {return Body().dotsNAME;} }
            public TTReportField dotsPROTOKOLNO { get {return Body().dotsPROTOKOLNO;} }
            public TTReportField dotsDOCTORNAME { get {return Body().dotsDOCTORNAME;} }
            public TTReportField dotsREQUESTDATE { get {return Body().dotsREQUESTDATE;} }
            public TTReportField dotsFROMRESOURCE { get {return Body().dotsFROMRESOURCE;} }
            public TTReportField lblPROCEDUREBRANCHDATE { get {return Body().lblPROCEDUREBRANCHDATE;} }
            public TTReportField dotsPROCEDUREBRANCHDATE { get {return Body().dotsPROCEDUREBRANCHDATE;} }
            public TTReportField PROCEDURESAVEDATE { get {return Body().PROCEDURESAVEDATE;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField lblNAME1 { get {return Body().lblNAME1;} }
            public TTReportField dotsNAME1 { get {return Body().dotsNAME1;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportField lblNAME2 { get {return Body().lblNAME2;} }
            public TTReportField dotsNAME2 { get {return Body().dotsNAME2;} }
            public TTReportField PROCEDURENAME { get {return Body().PROCEDURENAME;} }
            public TTReportField lblNAME13 { get {return Body().lblNAME13;} }
            public TTReportField dotsNAME13 { get {return Body().dotsNAME13;} }
            public TTReportField Patient { get {return Body().Patient;} }
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
                public PsychologyTestReport MyParentReport
                {
                    get { return (PsychologyTestReport)ParentReport; }
                }
                
                public TTReportField lblREQUESTDATE;
                public TTReportField lblDOCTORNAME;
                public TTReportField lblFROMRESOURCE;
                public TTReportField REQUESTDOCTOR;
                public TTReportField FROMRESOURCE;
                public TTReportField REQUESTDATE;
                public TTReportField NAME;
                public TTReportField PROTOCOLNO;
                public TTReportField lblNAME;
                public TTReportField lblPROTOKOLNO;
                public TTReportField dotsNAME;
                public TTReportField dotsPROTOKOLNO;
                public TTReportField dotsDOCTORNAME;
                public TTReportField dotsREQUESTDATE;
                public TTReportField dotsFROMRESOURCE;
                public TTReportField lblPROCEDUREBRANCHDATE;
                public TTReportField dotsPROCEDUREBRANCHDATE;
                public TTReportField PROCEDURESAVEDATE;
                public TTReportField SEX;
                public TTReportField lblNAME1;
                public TTReportField dotsNAME1;
                public TTReportField AGE;
                public TTReportField lblNAME2;
                public TTReportField dotsNAME2;
                public TTReportField PROCEDURENAME;
                public TTReportField lblNAME13;
                public TTReportField dotsNAME13;
                public TTReportField Patient; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 56;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblREQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 26, 129, 31, false);
                    lblREQUESTDATE.Name = "lblREQUESTDATE";
                    lblREQUESTDATE.TextFont.Size = 12;
                    lblREQUESTDATE.TextFont.Bold = true;
                    lblREQUESTDATE.TextFont.CharSet = 162;
                    lblREQUESTDATE.Value = @"İstem Tarihi";

                    lblDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 16, 129, 21, false);
                    lblDOCTORNAME.Name = "lblDOCTORNAME";
                    lblDOCTORNAME.TextFont.Size = 12;
                    lblDOCTORNAME.TextFont.Bold = true;
                    lblDOCTORNAME.TextFont.CharSet = 162;
                    lblDOCTORNAME.Value = @"İstem Doktor";

                    lblFROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 21, 131, 26, false);
                    lblFROMRESOURCE.Name = "lblFROMRESOURCE";
                    lblFROMRESOURCE.TextFont.Size = 12;
                    lblFROMRESOURCE.TextFont.Bold = true;
                    lblFROMRESOURCE.TextFont.CharSet = 162;
                    lblFROMRESOURCE.Value = @"İsteyen Bölüm";

                    REQUESTDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 16, 201, 21, false);
                    REQUESTDOCTOR.Name = "REQUESTDOCTOR";
                    REQUESTDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDOCTOR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDOCTOR.TextFont.Size = 12;
                    REQUESTDOCTOR.TextFont.CharSet = 162;
                    REQUESTDOCTOR.Value = @"{#HEADER.REQUESTBYUSER#}";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 21, 201, 26, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FROMRESOURCE.TextFont.Size = 12;
                    FROMRESOURCE.TextFont.CharSet = 162;
                    FROMRESOURCE.Value = @"{#HEADER.FROMRESOURCE#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 26, 201, 31, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Size = 12;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#HEADER.CREATIONDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 11, 95, 16, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.TextFont.Size = 12;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 10, 201, 16, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOCOLNO.TextFont.Size = 12;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#HEADER.HOSPITALPROTOCOLNO#}";

                    lblNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 49, 16, false);
                    lblNAME.Name = "lblNAME";
                    lblNAME.TextFont.Size = 12;
                    lblNAME.TextFont.Bold = true;
                    lblNAME.TextFont.CharSet = 162;
                    lblNAME.Value = @"Adı Soyadı";

                    lblPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 11, 123, 16, false);
                    lblPROTOKOLNO.Name = "lblPROTOKOLNO";
                    lblPROTOKOLNO.TextFont.Size = 12;
                    lblPROTOKOLNO.TextFont.Bold = true;
                    lblPROTOKOLNO.TextFont.CharSet = 162;
                    lblPROTOKOLNO.Value = @"Kabul No";

                    dotsNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 11, 51, 16, false);
                    dotsNAME.Name = "dotsNAME";
                    dotsNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsNAME.TextFont.Size = 9;
                    dotsNAME.TextFont.Bold = true;
                    dotsNAME.TextFont.CharSet = 162;
                    dotsNAME.Value = @":";

                    dotsPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 10, 133, 16, false);
                    dotsPROTOKOLNO.Name = "dotsPROTOKOLNO";
                    dotsPROTOKOLNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsPROTOKOLNO.TextFont.Size = 9;
                    dotsPROTOKOLNO.TextFont.Bold = true;
                    dotsPROTOKOLNO.TextFont.CharSet = 162;
                    dotsPROTOKOLNO.Value = @":";

                    dotsDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 16, 133, 21, false);
                    dotsDOCTORNAME.Name = "dotsDOCTORNAME";
                    dotsDOCTORNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDOCTORNAME.TextFont.Size = 9;
                    dotsDOCTORNAME.TextFont.Bold = true;
                    dotsDOCTORNAME.TextFont.CharSet = 162;
                    dotsDOCTORNAME.Value = @":";

                    dotsREQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 26, 133, 31, false);
                    dotsREQUESTDATE.Name = "dotsREQUESTDATE";
                    dotsREQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsREQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsREQUESTDATE.TextFont.Size = 9;
                    dotsREQUESTDATE.TextFont.Bold = true;
                    dotsREQUESTDATE.TextFont.CharSet = 162;
                    dotsREQUESTDATE.Value = @":";

                    dotsFROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 21, 133, 26, false);
                    dotsFROMRESOURCE.Name = "dotsFROMRESOURCE";
                    dotsFROMRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsFROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsFROMRESOURCE.TextFont.Size = 9;
                    dotsFROMRESOURCE.TextFont.Bold = true;
                    dotsFROMRESOURCE.TextFont.CharSet = 162;
                    dotsFROMRESOURCE.Value = @":";

                    lblPROCEDUREBRANCHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 31, 129, 36, false);
                    lblPROCEDUREBRANCHDATE.Name = "lblPROCEDUREBRANCHDATE";
                    lblPROCEDUREBRANCHDATE.TextFont.Size = 12;
                    lblPROCEDUREBRANCHDATE.TextFont.Bold = true;
                    lblPROCEDUREBRANCHDATE.TextFont.CharSet = 162;
                    lblPROCEDUREBRANCHDATE.Value = @"Onay Tarihi";

                    dotsPROCEDUREBRANCHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 31, 133, 36, false);
                    dotsPROCEDUREBRANCHDATE.Name = "dotsPROCEDUREBRANCHDATE";
                    dotsPROCEDUREBRANCHDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsPROCEDUREBRANCHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsPROCEDUREBRANCHDATE.TextFont.Size = 9;
                    dotsPROCEDUREBRANCHDATE.TextFont.Bold = true;
                    dotsPROCEDUREBRANCHDATE.TextFont.CharSet = 162;
                    dotsPROCEDUREBRANCHDATE.Value = @":";

                    PROCEDURESAVEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 31, 201, 36, false);
                    PROCEDURESAVEDATE.Name = "PROCEDURESAVEDATE";
                    PROCEDURESAVEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURESAVEDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    PROCEDURESAVEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDURESAVEDATE.TextFont.Size = 12;
                    PROCEDURESAVEDATE.TextFont.CharSet = 162;
                    PROCEDURESAVEDATE.Value = @"{#HEADER.ACTIONDATE#}";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 16, 95, 21, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SEX.TextFont.Size = 12;
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"";

                    lblNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 49, 21, false);
                    lblNAME1.Name = "lblNAME1";
                    lblNAME1.TextFont.Size = 12;
                    lblNAME1.TextFont.Bold = true;
                    lblNAME1.TextFont.CharSet = 162;
                    lblNAME1.Value = @"Cinsiyet";

                    dotsNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 16, 51, 21, false);
                    dotsNAME1.Name = "dotsNAME1";
                    dotsNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsNAME1.TextFont.Size = 9;
                    dotsNAME1.TextFont.Bold = true;
                    dotsNAME1.TextFont.CharSet = 162;
                    dotsNAME1.Value = @":";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 21, 95, 26, false);
                    AGE.Name = "AGE";
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGE.TextFont.Size = 12;
                    AGE.TextFont.CharSet = 162;
                    AGE.Value = @"";

                    lblNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 49, 26, false);
                    lblNAME2.Name = "lblNAME2";
                    lblNAME2.TextFont.Size = 12;
                    lblNAME2.TextFont.Bold = true;
                    lblNAME2.TextFont.CharSet = 162;
                    lblNAME2.Value = @"Yaşı";

                    dotsNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 21, 51, 26, false);
                    dotsNAME2.Name = "dotsNAME2";
                    dotsNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsNAME2.TextFont.Size = 9;
                    dotsNAME2.TextFont.Bold = true;
                    dotsNAME2.TextFont.CharSet = 162;
                    dotsNAME2.Value = @":";

                    PROCEDURENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 39, 197, 46, false);
                    PROCEDURENAME.Name = "PROCEDURENAME";
                    PROCEDURENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDURENAME.TextFont.Size = 13;
                    PROCEDURENAME.TextFont.CharSet = 162;
                    PROCEDURENAME.Value = @"{#HEADER.PSYCHOLOGYTEST#}";

                    lblNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 39, 38, 46, false);
                    lblNAME13.Name = "lblNAME13";
                    lblNAME13.TextFont.Size = 14;
                    lblNAME13.TextFont.Bold = true;
                    lblNAME13.TextFont.CharSet = 162;
                    lblNAME13.Value = @"Yapılan İşlem";

                    dotsNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 39, 40, 46, false);
                    dotsNAME13.Name = "dotsNAME13";
                    dotsNAME13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsNAME13.TextFont.Size = 14;
                    dotsNAME13.TextFont.Bold = true;
                    dotsNAME13.TextFont.CharSet = 162;
                    dotsNAME13.Value = @":";

                    Patient = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 9, 241, 14, false);
                    Patient.Name = "Patient";
                    Patient.Visible = EvetHayirEnum.ehHayir;
                    Patient.FieldType = ReportFieldTypeEnum.ftVariable;
                    Patient.Value = @"{#HEADER.PATIENT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PsychologyTest.PsychologyTestResultReport_Class dataset_PsychologyTestResultReport = MyParentReport.HEADER.rsGroup.GetCurrentRecord<PsychologyTest.PsychologyTestResultReport_Class>(0);
                    lblREQUESTDATE.CalcValue = lblREQUESTDATE.Value;
                    lblDOCTORNAME.CalcValue = lblDOCTORNAME.Value;
                    lblFROMRESOURCE.CalcValue = lblFROMRESOURCE.Value;
                    REQUESTDOCTOR.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.Requestbyuser) : "");
                    FROMRESOURCE.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.Fromresource) : "");
                    REQUESTDATE.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.CreationDate) : "");
                    NAME.CalcValue = @"";
                    PROTOCOLNO.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.HospitalProtocolNo) : "");
                    lblNAME.CalcValue = lblNAME.Value;
                    lblPROTOKOLNO.CalcValue = lblPROTOKOLNO.Value;
                    dotsNAME.CalcValue = dotsNAME.Value;
                    dotsPROTOKOLNO.CalcValue = dotsPROTOKOLNO.Value;
                    dotsDOCTORNAME.CalcValue = dotsDOCTORNAME.Value;
                    dotsREQUESTDATE.CalcValue = dotsREQUESTDATE.Value;
                    dotsFROMRESOURCE.CalcValue = dotsFROMRESOURCE.Value;
                    lblPROCEDUREBRANCHDATE.CalcValue = lblPROCEDUREBRANCHDATE.Value;
                    dotsPROCEDUREBRANCHDATE.CalcValue = dotsPROCEDUREBRANCHDATE.Value;
                    PROCEDURESAVEDATE.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.ActionDate) : "");
                    SEX.CalcValue = @"";
                    lblNAME1.CalcValue = lblNAME1.Value;
                    dotsNAME1.CalcValue = dotsNAME1.Value;
                    AGE.CalcValue = @"";
                    lblNAME2.CalcValue = lblNAME2.Value;
                    dotsNAME2.CalcValue = dotsNAME2.Value;
                    PROCEDURENAME.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.Psychologytest) : "");
                    lblNAME13.CalcValue = lblNAME13.Value;
                    dotsNAME13.CalcValue = dotsNAME13.Value;
                    Patient.CalcValue = (dataset_PsychologyTestResultReport != null ? Globals.ToStringCore(dataset_PsychologyTestResultReport.Patient) : "");
                    return new TTReportObject[] { lblREQUESTDATE,lblDOCTORNAME,lblFROMRESOURCE,REQUESTDOCTOR,FROMRESOURCE,REQUESTDATE,NAME,PROTOCOLNO,lblNAME,lblPROTOKOLNO,dotsNAME,dotsPROTOKOLNO,dotsDOCTORNAME,dotsREQUESTDATE,dotsFROMRESOURCE,lblPROCEDUREBRANCHDATE,dotsPROCEDUREBRANCHDATE,PROCEDURESAVEDATE,SEX,lblNAME1,dotsNAME1,AGE,lblNAME2,dotsNAME2,PROCEDURENAME,lblNAME13,dotsNAME13,Patient};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true); 
            Patient patient = (Patient)objectContext.GetObject(new Guid(this.Patient.CalcValue.ToString()),"Patient");
            this.NAME.CalcValue = patient.Name.ToString() + " " + patient.Surname.ToString();
            this.SEX.CalcValue = patient.Sex.ADI;
            this.AGE.CalcValue = patient.Age.ToString();
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class TestBodyGroup : TTReportGroup
        {
            public PsychologyTestReport MyParentReport
            {
                get { return (PsychologyTestReport)ParentReport; }
            }

            new public TestBodyGroupBody Body()
            {
                return (TestBodyGroupBody)_body;
            }
            public TTReportField THERAPYREPORT { get {return Body().THERAPYREPORT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TestBodyGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TestBodyGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TestBodyGroupBody(this);
            }

            public partial class TestBodyGroupBody : TTReportSection
            {
                public PsychologyTestReport MyParentReport
                {
                    get { return (PsychologyTestReport)ParentReport; }
                }
                
                public TTReportField THERAPYREPORT;
                public TTReportField NewField1; 
                public TestBodyGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 27;
                    RepeatCount = 0;
                    
                    THERAPYREPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 200, 22, false);
                    THERAPYREPORT.Name = "THERAPYREPORT";
                    THERAPYREPORT.MultiLine = EvetHayirEnum.ehEvet;
                    THERAPYREPORT.NoClip = EvetHayirEnum.ehEvet;
                    THERAPYREPORT.WordBreak = EvetHayirEnum.ehEvet;
                    THERAPYREPORT.ExpandTabs = EvetHayirEnum.ehEvet;
                    THERAPYREPORT.TextFont.Size = 13;
                    THERAPYREPORT.TextFont.CharSet = 162;
                    THERAPYREPORT.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 47, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 13;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Terapi Raporu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    THERAPYREPORT.CalcValue = THERAPYREPORT.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { THERAPYREPORT,NewField1};
                }
                public override void RunPreScript()
                {
#region TESTBODY BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PsychologyTestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PsychologyTest psychologyTest = (PsychologyTest)context.GetObject(new Guid(sObjectID),"PsychologyTest");
            this.THERAPYREPORT.Value = psychologyTest.PsychologicExamination.PsychologyBasedObjects[0].TherapyReport != null ? TTReportTool.TTReport.HTMLtoText(psychologyTest.PsychologicExamination.PsychologyBasedObjects[0].TherapyReport.ToString()) : "";
#endregion TESTBODY BODY_PreScript
                }
            }

        }

        public TestBodyGroup TestBody;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PsychologyTestReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            TestBody = new TestBodyGroup(HEADER,"TestBody");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PSYCHOLOGYTESTREPORT";
            Caption = "Psikolojik Test Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 2;
            UserMarginTop = 14;
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