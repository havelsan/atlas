
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
    public partial class RadiologyTestResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public RadiologyTestResultReport MyParentReport
            {
                get { return (RadiologyTestResultReport)ParentReport; }
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
            public TTReportField HizmetOzel1 { get {return Footer().HizmetOzel1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField UserName1 { get {return Footer().UserName1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
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
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestResultReport_Class>("RadiologyTestResultReport2", RadiologyTest.RadiologyTestResultReport((string)TTObjectDefManager.Instance.DataTypes["String250"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public RadiologyTestResultReport MyParentReport
                {
                    get { return (RadiologyTestResultReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField REPORTHEADER11;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 0, 185, 40, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 41, 185, 47, false);
                    REPORTHEADER11.Name = "REPORTHEADER11";
                    REPORTHEADER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER11.TextFont.Size = 15;
                    REPORTHEADER11.TextFont.Bold = true;
                    REPORTHEADER11.TextFont.CharSet = 162;
                    REPORTHEADER11.Value = @"RADYOLOJİ SONUÇ RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 2, 47, 25, false);
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
                    RadiologyTest.RadiologyTestResultReport_Class dataset_RadiologyTestResultReport2 = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestResultReport_Class>(0);
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
                public RadiologyTestResultReport MyParentReport
                {
                    get { return (RadiologyTestResultReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel1;
                public TTReportShape NewLine1;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HizmetOzel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 29, 244, 35, false);
                    HizmetOzel1.Name = "HizmetOzel1";
                    HizmetOzel1.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel1.TextFont.Size = 11;
                    HizmetOzel1.TextFont.Bold = true;
                    HizmetOzel1.TextFont.Underline = true;
                    HizmetOzel1.TextFont.CharSet = 162;
                    HizmetOzel1.Value = @"HİZMETE ÖZEL";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 4, 200, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 33, 10, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 5, 115, 10, false);
                    UserName1.Name = "UserName1";
                    UserName1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName1.TextFont.Size = 8;
                    UserName1.TextFont.CharSet = 162;
                    UserName1.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 5, 200, 10, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestResultReport_Class dataset_RadiologyTestResultReport2 = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestResultReport_Class>(0);
                    HizmetOzel1.CalcValue = HizmetOzel1.Value;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel1,PrintDate1,PageNumber1,UserName1};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public RadiologyTestResultReport MyParentReport
            {
                get { return (RadiologyTestResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblREQUESTDATE { get {return Body().lblREQUESTDATE;} }
            public TTReportField lblDOCTORNAME { get {return Body().lblDOCTORNAME;} }
            public TTReportField lblFROMRESOURCE { get {return Body().lblFROMRESOURCE;} }
            public TTReportField DOCTORNAME { get {return Body().DOCTORNAME;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField lblNAME { get {return Body().lblNAME;} }
            public TTReportField lblDYERTAR { get {return Body().lblDYERTAR;} }
            public TTReportField lblPROTOKOLNO { get {return Body().lblPROTOKOLNO;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField lblHASTANO { get {return Body().lblHASTANO;} }
            public TTReportField DYERTAR { get {return Body().DYERTAR;} }
            public TTReportField dotsNAME { get {return Body().dotsNAME;} }
            public TTReportField dotsDYERTAR { get {return Body().dotsDYERTAR;} }
            public TTReportField dotsHASTANO { get {return Body().dotsHASTANO;} }
            public TTReportField dotsPROTOKOLNO { get {return Body().dotsPROTOKOLNO;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField lblUNIQUEREFNO { get {return Body().lblUNIQUEREFNO;} }
            public TTReportField dotsUNIQUEREFNO { get {return Body().dotsUNIQUEREFNO;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField dotsDOCTORNAME { get {return Body().dotsDOCTORNAME;} }
            public TTReportField dotsREQUESTDATE { get {return Body().dotsREQUESTDATE;} }
            public TTReportField dotsFROMRESOURCE { get {return Body().dotsFROMRESOURCE;} }
            public TTReportField lblPROCEDUREBRANCHDATE { get {return Body().lblPROCEDUREBRANCHDATE;} }
            public TTReportField dotsPROCEDUREBRANCHDATE { get {return Body().dotsPROCEDUREBRANCHDATE;} }
            public TTReportField PROCEDUREBRANCHDATE { get {return Body().PROCEDUREBRANCHDATE;} }
            public TTReportField lblRDReportDate { get {return Body().lblRDReportDate;} }
            public TTReportField dotsPROCEDUREBRANCHDATE1 { get {return Body().dotsPROCEDUREBRANCHDATE1;} }
            public TTReportField RDReportDate { get {return Body().RDReportDate;} }
            public TTReportField lblICDCode { get {return Body().lblICDCode;} }
            public TTReportField ICDCode { get {return Body().ICDCode;} }
            public TTReportField dotsDOCTORNAME1 { get {return Body().dotsDOCTORNAME1;} }
            public TTReportField dotsACTIONID { get {return Body().dotsACTIONID;} }
            public TTReportField ACCESSIONNO { get {return Body().ACCESSIONNO;} }
            public TTReportField lblACTIONID { get {return Body().lblACTIONID;} }
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
                public RadiologyTestResultReport MyParentReport
                {
                    get { return (RadiologyTestResultReport)ParentReport; }
                }
                
                public TTReportField lblREQUESTDATE;
                public TTReportField lblDOCTORNAME;
                public TTReportField lblFROMRESOURCE;
                public TTReportField DOCTORNAME;
                public TTReportField FROMRESOURCE;
                public TTReportField REQUESTDATE;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NAME;
                public TTReportField PROTOKOLNO;
                public TTReportField lblNAME;
                public TTReportField lblDYERTAR;
                public TTReportField lblPROTOKOLNO;
                public TTReportField HASTANO;
                public TTReportField lblHASTANO;
                public TTReportField DYERTAR;
                public TTReportField dotsNAME;
                public TTReportField dotsDYERTAR;
                public TTReportField dotsHASTANO;
                public TTReportField dotsPROTOKOLNO;
                public TTReportField UNIQUEREFNO;
                public TTReportField lblUNIQUEREFNO;
                public TTReportField dotsUNIQUEREFNO;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField dotsDOCTORNAME;
                public TTReportField dotsREQUESTDATE;
                public TTReportField dotsFROMRESOURCE;
                public TTReportField lblPROCEDUREBRANCHDATE;
                public TTReportField dotsPROCEDUREBRANCHDATE;
                public TTReportField PROCEDUREBRANCHDATE;
                public TTReportField lblRDReportDate;
                public TTReportField dotsPROCEDUREBRANCHDATE1;
                public TTReportField RDReportDate;
                public TTReportField lblICDCode;
                public TTReportField ICDCode;
                public TTReportField dotsDOCTORNAME1;
                public TTReportField dotsACTIONID;
                public TTReportField ACCESSIONNO;
                public TTReportField lblACTIONID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 44;
                    RepeatCount = 0;
                    
                    lblREQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 21, 157, 26, false);
                    lblREQUESTDATE.Name = "lblREQUESTDATE";
                    lblREQUESTDATE.TextFont.Size = 9;
                    lblREQUESTDATE.TextFont.Bold = true;
                    lblREQUESTDATE.TextFont.CharSet = 162;
                    lblREQUESTDATE.Value = @"İstek Tarihi";

                    lblDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 21, 46, 26, false);
                    lblDOCTORNAME.Name = "lblDOCTORNAME";
                    lblDOCTORNAME.TextFont.Size = 9;
                    lblDOCTORNAME.TextFont.Bold = true;
                    lblDOCTORNAME.TextFont.CharSet = 162;
                    lblDOCTORNAME.Value = @"Doktor Adı";

                    lblFROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 26, 46, 31, false);
                    lblFROMRESOURCE.Name = "lblFROMRESOURCE";
                    lblFROMRESOURCE.TextFont.Size = 9;
                    lblFROMRESOURCE.TextFont.Bold = true;
                    lblFROMRESOURCE.TextFont.CharSet = 162;
                    lblFROMRESOURCE.Value = @"İsteyen Bölüm";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 21, 121, 26, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCTORNAME.TextFont.Size = 9;
                    DOCTORNAME.TextFont.CharSet = 162;
                    DOCTORNAME.Value = @"{#HEADER.REQUESTDOCTOR#}";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 26, 121, 31, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FROMRESOURCE.TextFont.Size = 8;
                    FROMRESOURCE.TextFont.CharSet = 162;
                    FROMRESOURCE.Value = @"{#HEADER.FROMRES#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 21, 196, 26, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Size = 8;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 37, 243, 42, false);
                    NewField14.Name = "NewField14";
                    NewField14.Visible = EvetHayirEnum.ehHayir;
                    NewField14.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField14.Value = @"{@TTOBJECTID@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 46, 6, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Hasta";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 11, 121, 16, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "RadiologyTest";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{@TTOBJECTID@}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 6, 196, 11, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HEADER.PROTOCOLNO#}";

                    lblNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 46, 16, false);
                    lblNAME.Name = "lblNAME";
                    lblNAME.TextFont.Size = 9;
                    lblNAME.TextFont.Bold = true;
                    lblNAME.TextFont.CharSet = 162;
                    lblNAME.Value = @"Adı Soyadı";

                    lblDYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 16, 46, 21, false);
                    lblDYERTAR.Name = "lblDYERTAR";
                    lblDYERTAR.TextFont.Size = 9;
                    lblDYERTAR.TextFont.Bold = true;
                    lblDYERTAR.TextFont.CharSet = 162;
                    lblDYERTAR.Value = @"Doğum Tarihi ve Yeri";

                    lblPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 6, 157, 11, false);
                    lblPROTOKOLNO.Name = "lblPROTOKOLNO";
                    lblPROTOKOLNO.TextFont.Size = 9;
                    lblPROTOKOLNO.TextFont.Bold = true;
                    lblPROTOKOLNO.TextFont.CharSet = 162;
                    lblPROTOKOLNO.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 11, 196, 16, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "RadiologyTest";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    lblHASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 11, 157, 16, false);
                    lblHASTANO.Name = "lblHASTANO";
                    lblHASTANO.TextFont.Size = 9;
                    lblHASTANO.TextFont.Bold = true;
                    lblHASTANO.TextFont.CharSet = 162;
                    lblHASTANO.Value = @"Hasta No";

                    DYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 16, 121, 21, false);
                    DYERTAR.Name = "DYERTAR";
                    DYERTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DYERTAR.TextFont.Size = 9;
                    DYERTAR.TextFont.CharSet = 162;
                    DYERTAR.Value = @"{%DTARIH%} {%DYER%}";

                    dotsNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 11, 48, 16, false);
                    dotsNAME.Name = "dotsNAME";
                    dotsNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsNAME.TextFont.Size = 9;
                    dotsNAME.TextFont.Bold = true;
                    dotsNAME.TextFont.CharSet = 162;
                    dotsNAME.Value = @":";

                    dotsDYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 16, 48, 21, false);
                    dotsDYERTAR.Name = "dotsDYERTAR";
                    dotsDYERTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDYERTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDYERTAR.TextFont.Size = 9;
                    dotsDYERTAR.TextFont.Bold = true;
                    dotsDYERTAR.TextFont.CharSet = 162;
                    dotsDYERTAR.Value = @":";

                    dotsHASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 11, 159, 16, false);
                    dotsHASTANO.Name = "dotsHASTANO";
                    dotsHASTANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsHASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsHASTANO.TextFont.Size = 9;
                    dotsHASTANO.TextFont.Bold = true;
                    dotsHASTANO.TextFont.CharSet = 162;
                    dotsHASTANO.Value = @":";

                    dotsPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 6, 159, 11, false);
                    dotsPROTOKOLNO.Name = "dotsPROTOKOLNO";
                    dotsPROTOKOLNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsPROTOKOLNO.TextFont.Size = 9;
                    dotsPROTOKOLNO.TextFont.Bold = true;
                    dotsPROTOKOLNO.TextFont.CharSet = 162;
                    dotsPROTOKOLNO.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 6, 121, 11, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#HEADER.UNIQUEREFNO#}";

                    lblUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 46, 11, false);
                    lblUNIQUEREFNO.Name = "lblUNIQUEREFNO";
                    lblUNIQUEREFNO.TextFont.Size = 9;
                    lblUNIQUEREFNO.TextFont.Bold = true;
                    lblUNIQUEREFNO.TextFont.CharSet = 162;
                    lblUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    dotsUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 6, 48, 11, false);
                    dotsUNIQUEREFNO.Name = "dotsUNIQUEREFNO";
                    dotsUNIQUEREFNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsUNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsUNIQUEREFNO.TextFont.Size = 9;
                    dotsUNIQUEREFNO.TextFont.Bold = true;
                    dotsUNIQUEREFNO.TextFont.CharSet = 162;
                    dotsUNIQUEREFNO.Value = @":";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 11, 254, 16, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.TextFont.CharSet = 162;
                    DTARIH.Value = @"{#HEADER.BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 16, 254, 21, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Size = 9;
                    DYER.TextFont.CharSet = 162;
                    DYER.Value = @"{#HEADER.CITYNAME#}";

                    dotsDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 21, 48, 26, false);
                    dotsDOCTORNAME.Name = "dotsDOCTORNAME";
                    dotsDOCTORNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDOCTORNAME.TextFont.Size = 9;
                    dotsDOCTORNAME.TextFont.Bold = true;
                    dotsDOCTORNAME.TextFont.CharSet = 162;
                    dotsDOCTORNAME.Value = @":";

                    dotsREQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 21, 159, 26, false);
                    dotsREQUESTDATE.Name = "dotsREQUESTDATE";
                    dotsREQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsREQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsREQUESTDATE.TextFont.Size = 9;
                    dotsREQUESTDATE.TextFont.Bold = true;
                    dotsREQUESTDATE.TextFont.CharSet = 162;
                    dotsREQUESTDATE.Value = @":";

                    dotsFROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 26, 48, 31, false);
                    dotsFROMRESOURCE.Name = "dotsFROMRESOURCE";
                    dotsFROMRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsFROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsFROMRESOURCE.TextFont.Size = 9;
                    dotsFROMRESOURCE.TextFont.Bold = true;
                    dotsFROMRESOURCE.TextFont.CharSet = 162;
                    dotsFROMRESOURCE.Value = @":";

                    lblPROCEDUREBRANCHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 26, 157, 31, false);
                    lblPROCEDUREBRANCHDATE.Name = "lblPROCEDUREBRANCHDATE";
                    lblPROCEDUREBRANCHDATE.TextFont.Size = 9;
                    lblPROCEDUREBRANCHDATE.TextFont.Bold = true;
                    lblPROCEDUREBRANCHDATE.TextFont.CharSet = 162;
                    lblPROCEDUREBRANCHDATE.Value = @"Çekim Tarihi";

                    dotsPROCEDUREBRANCHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 26, 159, 31, false);
                    dotsPROCEDUREBRANCHDATE.Name = "dotsPROCEDUREBRANCHDATE";
                    dotsPROCEDUREBRANCHDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsPROCEDUREBRANCHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsPROCEDUREBRANCHDATE.TextFont.Size = 9;
                    dotsPROCEDUREBRANCHDATE.TextFont.Bold = true;
                    dotsPROCEDUREBRANCHDATE.TextFont.CharSet = 162;
                    dotsPROCEDUREBRANCHDATE.Value = @":";

                    PROCEDUREBRANCHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 26, 196, 31, false);
                    PROCEDUREBRANCHDATE.Name = "PROCEDUREBRANCHDATE";
                    PROCEDUREBRANCHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBRANCHDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    PROCEDUREBRANCHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDUREBRANCHDATE.TextFont.Size = 8;
                    PROCEDUREBRANCHDATE.TextFont.CharSet = 162;
                    PROCEDUREBRANCHDATE.Value = @"";

                    lblRDReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 31, 157, 36, false);
                    lblRDReportDate.Name = "lblRDReportDate";
                    lblRDReportDate.TextFont.Size = 9;
                    lblRDReportDate.TextFont.Bold = true;
                    lblRDReportDate.TextFont.CharSet = 162;
                    lblRDReportDate.Value = @"Rapor Tarihi";

                    dotsPROCEDUREBRANCHDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 31, 159, 36, false);
                    dotsPROCEDUREBRANCHDATE1.Name = "dotsPROCEDUREBRANCHDATE1";
                    dotsPROCEDUREBRANCHDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsPROCEDUREBRANCHDATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsPROCEDUREBRANCHDATE1.TextFont.Size = 9;
                    dotsPROCEDUREBRANCHDATE1.TextFont.Bold = true;
                    dotsPROCEDUREBRANCHDATE1.TextFont.CharSet = 162;
                    dotsPROCEDUREBRANCHDATE1.Value = @":";

                    RDReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 31, 196, 36, false);
                    RDReportDate.Name = "RDReportDate";
                    RDReportDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDReportDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    RDReportDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RDReportDate.TextFont.Size = 8;
                    RDReportDate.TextFont.CharSet = 162;
                    RDReportDate.Value = @"";

                    lblICDCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 31, 46, 36, false);
                    lblICDCode.Name = "lblICDCode";
                    lblICDCode.TextFont.Size = 9;
                    lblICDCode.TextFont.Bold = true;
                    lblICDCode.TextFont.CharSet = 162;
                    lblICDCode.Value = @"ICD Tanı Kodu";

                    ICDCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 31, 121, 42, false);
                    ICDCode.Name = "ICDCode";
                    ICDCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICDCode.TextFont.Size = 9;
                    ICDCode.TextFont.CharSet = 162;
                    ICDCode.Value = @"";

                    dotsDOCTORNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 31, 48, 36, false);
                    dotsDOCTORNAME1.Name = "dotsDOCTORNAME1";
                    dotsDOCTORNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsDOCTORNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsDOCTORNAME1.TextFont.Size = 9;
                    dotsDOCTORNAME1.TextFont.Bold = true;
                    dotsDOCTORNAME1.TextFont.CharSet = 162;
                    dotsDOCTORNAME1.Value = @":";

                    dotsACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 16, 159, 21, false);
                    dotsACTIONID.Name = "dotsACTIONID";
                    dotsACTIONID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    dotsACTIONID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    dotsACTIONID.TextFont.Size = 9;
                    dotsACTIONID.TextFont.Bold = true;
                    dotsACTIONID.TextFont.CharSet = 162;
                    dotsACTIONID.Value = @":";

                    ACCESSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 16, 196, 21, false);
                    ACCESSIONNO.Name = "ACCESSIONNO";
                    ACCESSIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCESSIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCESSIONNO.TextFont.Size = 9;
                    ACCESSIONNO.TextFont.CharSet = 162;
                    ACCESSIONNO.Value = @"{#HEADER.ACCESSIONNO#}";

                    lblACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 16, 157, 21, false);
                    lblACTIONID.Name = "lblACTIONID";
                    lblACTIONID.TextFont.Size = 9;
                    lblACTIONID.TextFont.Bold = true;
                    lblACTIONID.TextFont.CharSet = 162;
                    lblACTIONID.Value = @"Accession No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestResultReport_Class dataset_RadiologyTestResultReport2 = MyParentReport.HEADER.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestResultReport_Class>(0);
                    lblREQUESTDATE.CalcValue = lblREQUESTDATE.Value;
                    lblDOCTORNAME.CalcValue = lblDOCTORNAME.Value;
                    lblFROMRESOURCE.CalcValue = lblFROMRESOURCE.Value;
                    DOCTORNAME.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.Requestdoctor) : "");
                    FROMRESOURCE.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.Fromres) : "");
                    REQUESTDATE.CalcValue = @"";
                    NewField14.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NewField15.CalcValue = NewField15.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    PROTOKOLNO.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.Protocolno) : "");
                    lblNAME.CalcValue = lblNAME.Value;
                    lblDYERTAR.CalcValue = lblDYERTAR.Value;
                    lblPROTOKOLNO.CalcValue = lblPROTOKOLNO.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    lblHASTANO.CalcValue = lblHASTANO.Value;
                    DTARIH.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.BirthDate) : "");
                    DYER.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.Cityname) : "");
                    DYERTAR.CalcValue = MyParentReport.MAIN.DTARIH.FormattedValue + @" " + MyParentReport.MAIN.DYER.CalcValue;
                    dotsNAME.CalcValue = dotsNAME.Value;
                    dotsDYERTAR.CalcValue = dotsDYERTAR.Value;
                    dotsHASTANO.CalcValue = dotsHASTANO.Value;
                    dotsPROTOKOLNO.CalcValue = dotsPROTOKOLNO.Value;
                    UNIQUEREFNO.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.UniqueRefNo) : "");
                    lblUNIQUEREFNO.CalcValue = lblUNIQUEREFNO.Value;
                    dotsUNIQUEREFNO.CalcValue = dotsUNIQUEREFNO.Value;
                    dotsDOCTORNAME.CalcValue = dotsDOCTORNAME.Value;
                    dotsREQUESTDATE.CalcValue = dotsREQUESTDATE.Value;
                    dotsFROMRESOURCE.CalcValue = dotsFROMRESOURCE.Value;
                    lblPROCEDUREBRANCHDATE.CalcValue = lblPROCEDUREBRANCHDATE.Value;
                    dotsPROCEDUREBRANCHDATE.CalcValue = dotsPROCEDUREBRANCHDATE.Value;
                    PROCEDUREBRANCHDATE.CalcValue = @"";
                    lblRDReportDate.CalcValue = lblRDReportDate.Value;
                    dotsPROCEDUREBRANCHDATE1.CalcValue = dotsPROCEDUREBRANCHDATE1.Value;
                    RDReportDate.CalcValue = @"";
                    lblICDCode.CalcValue = lblICDCode.Value;
                    ICDCode.CalcValue = @"";
                    dotsDOCTORNAME1.CalcValue = dotsDOCTORNAME1.Value;
                    dotsACTIONID.CalcValue = dotsACTIONID.Value;
                    ACCESSIONNO.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.AccessionNo) : "");
                    lblACTIONID.CalcValue = lblACTIONID.Value;
                    return new TTReportObject[] { lblREQUESTDATE,lblDOCTORNAME,lblFROMRESOURCE,DOCTORNAME,FROMRESOURCE,REQUESTDATE,NewField14,NewField15,NAME,PROTOKOLNO,lblNAME,lblDYERTAR,lblPROTOKOLNO,HASTANO,lblHASTANO,DTARIH,DYER,DYERTAR,dotsNAME,dotsDYERTAR,dotsHASTANO,dotsPROTOKOLNO,UNIQUEREFNO,lblUNIQUEREFNO,dotsUNIQUEREFNO,dotsDOCTORNAME,dotsREQUESTDATE,dotsFROMRESOURCE,lblPROCEDUREBRANCHDATE,dotsPROCEDUREBRANCHDATE,PROCEDUREBRANCHDATE,lblRDReportDate,dotsPROCEDUREBRANCHDATE1,RDReportDate,lblICDCode,ICDCode,dotsDOCTORNAME1,dotsACTIONID,ACCESSIONNO,lblACTIONID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest radiologyTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            this.REQUESTDATE.CalcValue = radiologyTest.RequestDate.ToString();
            //Çekim tarihi
            foreach(TTObjectState objectState in radiologyTest.GetStateHistory())
            {
                if(objectState.StateDefID == RadiologyTest.States.Completed)
                    this.PROCEDUREBRANCHDATE.CalcValue = objectState.BranchDate.ToString();
            }
            
            this.RDReportDate.CalcValue = radiologyTest.ReportDate.ToString();
            string diagnosisStr = "";
            foreach(DiagnosisGrid dig in radiologyTest.EpisodeAction.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    diagnosisStr = diagnosisStr + dig.Diagnose.Code.ToString() + " " + dig.Diagnose.Name.ToString() + ", ";
                    //this.ICDCode.CalcValue = dig.Diagnose.Code.ToString();
                }
            }
            this.ICDCode.CalcValue = diagnosisStr;   
            
            bool overridePrintRoles = TTObjectClasses.Common.OverridePrintRoles(TTObjectClasses.Common.CurrentUser);
            
            if(radiologyTest.Episode.Patient.SecurePerson == true && overridePrintRoles == false)
            {
                this.UNIQUEREFNO.Visible = this.dotsUNIQUEREFNO.Visible = this.lblUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                this.NAME.Visible = this.dotsNAME.Visible = this.lblNAME.Visible = EvetHayirEnum.ehHayir;
                this.DYERTAR.Visible = this.dotsDYERTAR.Visible = this.lblDYERTAR.Visible = EvetHayirEnum.ehHayir;
                this.DOCTORNAME.Visible = this.dotsDOCTORNAME.Visible = this.lblDOCTORNAME.Visible = EvetHayirEnum.ehHayir;
                this.PROTOKOLNO.Visible = this.dotsPROTOKOLNO.Visible = this.lblPROTOKOLNO.Visible = EvetHayirEnum.ehHayir;
                this.HASTANO.Visible = this.dotsHASTANO.Visible = this.lblHASTANO.Visible = EvetHayirEnum.ehHayir;
                this.PROCEDUREBRANCHDATE.Visible = this.dotsPROCEDUREBRANCHDATE.Visible = this.lblPROCEDUREBRANCHDATE.Visible = EvetHayirEnum.ehHayir;
                this.FROMRESOURCE.Visible = this.dotsFROMRESOURCE.Visible = this.lblFROMRESOURCE.Visible = EvetHayirEnum.ehHayir;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class TETKIKGroup : TTReportGroup
        {
            public RadiologyTestResultReport MyParentReport
            {
                get { return (RadiologyTestResultReport)ParentReport; }
            }

            new public TETKIKGroupBody Body()
            {
                return (TETKIKGroupBody)_body;
            }
            public TTReportField Test { get {return Body().Test;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField Report { get {return Body().Report;} }
            public TETKIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TETKIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestResultReport_Class>("RadiologyTestResultReport", RadiologyTest.RadiologyTestResultReport((string)TTObjectDefManager.Instance.DataTypes["String250"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TETKIKGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TETKIKGroupBody : TTReportSection
            {
                public RadiologyTestResultReport MyParentReport
                {
                    get { return (RadiologyTestResultReport)ParentReport; }
                }
                
                public TTReportField Test;
                public TTReportField NewField111611;
                public TTReportField NewField11611;
                public TTReportField Report; 
                public TETKIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 42;
                    RepeatCount = 0;
                    
                    Test = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 148, 15, false);
                    Test.Name = "Test";
                    Test.ExpandTabs = EvetHayirEnum.ehEvet;
                    Test.TextFont.Size = 9;
                    Test.TextFont.CharSet = 162;
                    Test.Value = @"";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 57, 24, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Size = 11;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"RAPOR                                               ";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 58, 9, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"İSTENEN TETKİK                              ";

                    Report = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 200, 40, false);
                    Report.Name = "Report";
                    Report.MultiLine = EvetHayirEnum.ehEvet;
                    Report.NoClip = EvetHayirEnum.ehEvet;
                    Report.WordBreak = EvetHayirEnum.ehEvet;
                    Report.ExpandTabs = EvetHayirEnum.ehEvet;
                    Report.TextFont.Name = "Arial Unicode MS";
                    Report.TextFont.Size = 11;
                    Report.TextFont.CharSet = 162;
                    Report.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestResultReport_Class dataset_RadiologyTestResultReport = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestResultReport_Class>(0);
                    Test.CalcValue = Test.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    Report.CalcValue = Report.Value;
                    return new TTReportObject[] { Test,NewField111611,NewField11611,Report};
                }
                public override void RunPreScript()
                {
#region TETKIK BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest radTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            this.Test.Value = radTest.ProcedureObject.Name;
            if (radTest.Report != null)
                this.Report.Value = TTReportTool.TTReport.HTMLtoText(radTest.Report.ToString());
            else
                this.Report.Value = "";
#endregion TETKIK BODY_PreScript
                }
            }

        }

        public TETKIKGroup TETKIK;

        public partial class EkRaporGroup : TTReportGroup
        {
            public RadiologyTestResultReport MyParentReport
            {
                get { return (RadiologyTestResultReport)ParentReport; }
            }

            new public EkRaporGroupBody Body()
            {
                return (EkRaporGroupBody)_body;
            }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField AdditionalReport { get {return Body().AdditionalReport;} }
            public TTReportField ADDITIONALREPORTDATE { get {return Body().ADDITIONALREPORTDATE;} }
            public EkRaporGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public EkRaporGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new EkRaporGroupBody(this);
            }

            public partial class EkRaporGroupBody : TTReportSection
            {
                public RadiologyTestResultReport MyParentReport
                {
                    get { return (RadiologyTestResultReport)ParentReport; }
                }
                
                public TTReportField NewField111611;
                public TTReportField AdditionalReport;
                public TTReportField ADDITIONALREPORTDATE; 
                public EkRaporGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 30;
                    RepeatCount = 0;
                    
                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 58, 10, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Size = 11;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"EK RAPOR                   ";

                    AdditionalReport = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 200, 30, false);
                    AdditionalReport.Name = "AdditionalReport";
                    AdditionalReport.MultiLine = EvetHayirEnum.ehEvet;
                    AdditionalReport.NoClip = EvetHayirEnum.ehEvet;
                    AdditionalReport.WordBreak = EvetHayirEnum.ehEvet;
                    AdditionalReport.ExpandTabs = EvetHayirEnum.ehEvet;
                    AdditionalReport.TextFont.Name = "Arial Unicode MS";
                    AdditionalReport.TextFont.Size = 11;
                    AdditionalReport.TextFont.CharSet = 162;
                    AdditionalReport.Value = @"";

                    ADDITIONALREPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 44, 15, false);
                    ADDITIONALREPORTDATE.Name = "ADDITIONALREPORTDATE";
                    ADDITIONALREPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDITIONALREPORTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    ADDITIONALREPORTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADDITIONALREPORTDATE.TextFont.Size = 11;
                    ADDITIONALREPORTDATE.TextFont.CharSet = 162;
                    ADDITIONALREPORTDATE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111611.CalcValue = NewField111611.Value;
                    AdditionalReport.CalcValue = AdditionalReport.Value;
                    ADDITIONALREPORTDATE.CalcValue = @"";
                    return new TTReportObject[] { NewField111611,AdditionalReport,ADDITIONALREPORTDATE};
                }
                public override void RunPreScript()
                {
#region EKRAPOR BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest radTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
           
            if (radTest.RadiologyAdditionalReport != null){
                this.AdditionalReport.Value = TTReportTool.TTReport.HTMLtoText(radTest.RadiologyAdditionalReport.AdditionalReport.ToString());
                //this.ADDITIONALREPORTDATE.CalcValue = radTest.RadiologyAdditionalReport.ReportDate.ToString();
       
            }else
                  this.Visible = EvetHayirEnum.ehHayir;
#endregion EKRAPOR BODY_PreScript
                }

                public override void RunScript()
                {
#region EKRAPOR BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest radTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
           
            if (radTest.RadiologyAdditionalReport != null){
                //this.AdditionalReport.Value = TTReportTool.TTReport.HTMLtoText(radTest.RadiologyAdditionalReport.AdditionalReport.ToString());
                this.ADDITIONALREPORTDATE.CalcValue = radTest.RadiologyAdditionalReport.ReportDate.ToString();
       
            }
#endregion EKRAPOR BODY_Script
                }
            }

        }

        public EkRaporGroup EkRapor;

        public partial class LetterFooterGroup : TTReportGroup
        {
            public RadiologyTestResultReport MyParentReport
            {
                get { return (RadiologyTestResultReport)ParentReport; }
            }

            new public LetterFooterGroupBody Body()
            {
                return (LetterFooterGroupBody)_body;
            }
            public TTReportField NewField11116211 { get {return Body().NewField11116211;} }
            public TTReportField REPORTEDBY { get {return Body().REPORTEDBY;} }
            public TTReportField APPROVEDBY { get {return Body().APPROVEDBY;} }
            public TTReportField NewField11116311 { get {return Body().NewField11116311;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField lblRadiologyUnitInfo { get {return Body().lblRadiologyUnitInfo;} }
            public LetterFooterGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LetterFooterGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new LetterFooterGroupBody(this);
            }

            public partial class LetterFooterGroupBody : TTReportSection
            {
                public RadiologyTestResultReport MyParentReport
                {
                    get { return (RadiologyTestResultReport)ParentReport; }
                }
                
                public TTReportField NewField11116211;
                public TTReportField REPORTEDBY;
                public TTReportField APPROVEDBY;
                public TTReportField NewField11116311;
                public TTReportField NewField11;
                public TTReportField lblRadiologyUnitInfo; 
                public LetterFooterGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 48;
                    RepeatCount = 0;
                    
                    NewField11116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 57, 10, false);
                    NewField11116211.Name = "NewField11116211";
                    NewField11116211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11116211.TextFont.Size = 9;
                    NewField11116211.TextFont.Bold = true;
                    NewField11116211.TextFont.CharSet = 162;
                    NewField11116211.Value = @"RAPOR YAZAN";

                    REPORTEDBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 93, 31, false);
                    REPORTEDBY.Name = "REPORTEDBY";
                    REPORTEDBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTEDBY.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTEDBY.TextFont.Size = 9;
                    REPORTEDBY.TextFont.CharSet = 162;
                    REPORTEDBY.Value = @"{#HEADER.REPORTEDBY#}";

                    APPROVEDBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 12, 200, 30, false);
                    APPROVEDBY.Name = "APPROVEDBY";
                    APPROVEDBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPROVEDBY.MultiLine = EvetHayirEnum.ehEvet;
                    APPROVEDBY.TextFont.Size = 9;
                    APPROVEDBY.TextFont.CharSet = 162;
                    APPROVEDBY.Value = @"{#HEADER.APPROVEDBY#}";

                    NewField11116311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 5, 161, 10, false);
                    NewField11116311.Name = "NewField11116311";
                    NewField11116311.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11116311.TextFont.Size = 9;
                    NewField11116311.TextFont.Bold = true;
                    NewField11116311.TextFont.CharSet = 162;
                    NewField11116311.Value = @"SORUMLU DOKTOR";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 36, 37, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İletişim Bilgileri:";

                    lblRadiologyUnitInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 33, 200, 47, false);
                    lblRadiologyUnitInfo.Name = "lblRadiologyUnitInfo";
                    lblRadiologyUnitInfo.MultiLine = EvetHayirEnum.ehEvet;
                    lblRadiologyUnitInfo.WordBreak = EvetHayirEnum.ehEvet;
                    lblRadiologyUnitInfo.TextFont.Size = 8;
                    lblRadiologyUnitInfo.TextFont.CharSet = 162;
                    lblRadiologyUnitInfo.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestResultReport_Class dataset_RadiologyTestResultReport2 = MyParentReport.HEADER.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestResultReport_Class>(0);
                    NewField11116211.CalcValue = NewField11116211.Value;
                    REPORTEDBY.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.Reportedby) : "");
                    APPROVEDBY.CalcValue = (dataset_RadiologyTestResultReport2 != null ? Globals.ToStringCore(dataset_RadiologyTestResultReport2.Approvedby) : "");
                    NewField11116311.CalcValue = NewField11116311.Value;
                    NewField11.CalcValue = NewField11.Value;
                    lblRadiologyUnitInfo.CalcValue = lblRadiologyUnitInfo.Value;
                    return new TTReportObject[] { NewField11116211,REPORTEDBY,APPROVEDBY,NewField11116311,NewField11,lblRadiologyUnitInfo};
                }

                public override void RunScript()
                {
#region LETTERFOOTER BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest radiologyTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            
            ResUser approvedBy = radiologyTest.ProcedureDoctor;
            ResUser reportedBy = radiologyTest.ReportedBy;
            
            string CrLf = "\r\n";
            string TextContext = "";
            string Title = "";
            string Sicil = "";
            string Rank = "";
            
            //Approved By
            if(approvedBy != null)
                this.APPROVEDBY.CalcValue = approvedBy.SignatureBlock;
            
            //Reported By
            if(reportedBy != null)
                this.REPORTEDBY.CalcValue = reportedBy.SignatureBlock;
            
            this.lblRadiologyUnitInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RadiologyUnitAddressInfo", "");
#endregion LETTERFOOTER BODY_Script
                }
            }

        }

        public LetterFooterGroup LetterFooter;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public RadiologyTestResultReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            TETKIK = new TETKIKGroup(HEADER,"TETKIK");
            EkRapor = new EkRaporGroup(HEADER,"EkRapor");
            LetterFooter = new LetterFooterGroup(HEADER,"LetterFooter");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RADIOLOGYTESTRESULTREPORT";
            Caption = "Radyoloji Sonuç Raporu";
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