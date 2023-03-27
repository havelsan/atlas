
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
    /// Senet Takip Muhakemat Raporu
    /// </summary>
    public partial class DebentureFollowExecutionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public DebentureFollowExecutionReport MyParentReport
            {
                get { return (DebentureFollowExecutionReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField COPYORORIGINAL { get {return Header().COPYORORIGINAL;} }
            public TTReportField GCOUNTER { get {return Header().GCOUNTER;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                RepeatCount = 2;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public DebentureFollowExecutionReport MyParentReport
                {
                    get { return (DebentureFollowExecutionReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField COPYORORIGINAL;
                public TTReportField GCOUNTER;
                public TTReportField REPORTNAME; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 53;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 9, 149, 29, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 15;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    COPYORORIGINAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 20, 192, 25, false);
                    COPYORORIGINAL.Name = "COPYORORIGINAL";
                    COPYORORIGINAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    COPYORORIGINAL.TextFont.Name = "Arial Narrow";
                    COPYORORIGINAL.TextFont.Size = 12;
                    COPYORORIGINAL.TextFont.Bold = true;
                    COPYORORIGINAL.TextFont.CharSet = 162;
                    COPYORORIGINAL.Value = @"";

                    GCOUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 12, 248, 17, false);
                    GCOUNTER.Name = "GCOUNTER";
                    GCOUNTER.Visible = EvetHayirEnum.ehHayir;
                    GCOUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GCOUNTER.Value = @"{@groupcounter@}";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 30, 149, 38, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.Visible = EvetHayirEnum.ehHayir;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.TextFont.Name = "Arial Narrow";
                    REPORTNAME.TextFont.Size = 14;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"İCRA EMRİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COPYORORIGINAL.CalcValue = @"";
                    GCOUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { COPYORORIGINAL,GCOUNTER,REPORTNAME,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if (this.GCOUNTER.CalcValue == "1")
                this.COPYORORIGINAL.CalcValue = "- ASIL -";
            else
                this.COPYORORIGINAL.CalcValue = "- SURET -";
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public DebentureFollowExecutionReport MyParentReport
                {
                    get { return (DebentureFollowExecutionReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 124, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 192, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 58, 6, false);
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

        public HEADGroup HEAD;

        public partial class PARTAGroup : TTReportGroup
        {
            public DebentureFollowExecutionReport MyParentReport
            {
                get { return (DebentureFollowExecutionReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField CODE { get {return Header().CODE;} }
            public TTReportField SUBJECT { get {return Header().SUBJECT;} }
            public TTReportField ENTRYTEXT { get {return Header().ENTRYTEXT;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField DEBENTURENO { get {return Header().DEBENTURENO;} }
            public TTReportField DEBENTUREDUEDATE { get {return Header().DEBENTUREDUEDATE;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DEBENTUREPRICE { get {return Header().DEBENTUREPRICE;} }
            public TTReportField TEXT2 { get {return Header().TEXT2;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField PATIENTNO { get {return Header().PATIENTNO;} }
            public TTReportField HOSPITALCITY { get {return Header().HOSPITALCITY;} }
            public TTReportField PRINTDATE { get {return Header().PRINTDATE;} }
            public TTReportField DEPARTMENTRESPONSIBLE { get {return Header().DEPARTMENTRESPONSIBLE;} }
            public TTReportField HOSPITALCHIEF { get {return Header().HOSPITALCHIEF;} }
            public TTReportField DEBENTUREFOLLOWORDERPERIOD { get {return Header().DEBENTUREFOLLOWORDERPERIOD;} }
            public TTReportField HOSPITALFAX { get {return Header().HOSPITALFAX;} }
            public TTReportField DEBENTUREFOLLOWPAYORDREPORTCODE { get {return Header().DEBENTUREFOLLOWPAYORDREPORTCODE;} }
            public TTReportField DEPARTMENTRESPONSIBLETEXT { get {return Header().DEPARTMENTRESPONSIBLETEXT;} }
            public TTReportField HOSPITALCHIEFTEXT { get {return Header().HOSPITALCHIEFTEXT;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField MANAGEMENTOFFICE { get {return Header().MANAGEMENTOFFICE;} }
            public TTReportField EPISODEOPENINGDATE { get {return Header().EPISODEOPENINGDATE;} }
            public TTReportField PATIENTSURNAME { get {return Header().PATIENTSURNAME;} }
            public TTReportField FOOTERTEXT { get {return Footer().FOOTERTEXT;} }
            public TTReportField NotLabel { get {return Footer().NotLabel;} }
            public TTReportField HOSPITALBANKACCOUNTNO { get {return Footer().HOSPITALBANKACCOUNTNO;} }
            public TTReportField TEXTBOTTOM { get {return Footer().TEXTBOTTOM;} }
            public TTReportField DEPARTMENTPHONE { get {return Footer().DEPARTMENTPHONE;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DebentureFollow.DebentureFollowExecutionReportQuery_Class>("DebentureFollowExecutionReportNQL", DebentureFollow.DebentureFollowExecutionReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public DebentureFollowExecutionReport MyParentReport
                {
                    get { return (DebentureFollowExecutionReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField CODE;
                public TTReportField SUBJECT;
                public TTReportField ENTRYTEXT;
                public TTReportField PATIENTNAME;
                public TTReportField DEBENTURENO;
                public TTReportField DEBENTUREDUEDATE;
                public TTReportField DOCUMENTDATE;
                public TTReportField DEBENTUREPRICE;
                public TTReportField TEXT2;
                public TTReportField NewField7;
                public TTReportField PATIENTNO;
                public TTReportField HOSPITALCITY;
                public TTReportField PRINTDATE;
                public TTReportField DEPARTMENTRESPONSIBLE;
                public TTReportField HOSPITALCHIEF;
                public TTReportField DEBENTUREFOLLOWORDERPERIOD;
                public TTReportField HOSPITALFAX;
                public TTReportField DEBENTUREFOLLOWPAYORDREPORTCODE;
                public TTReportField DEPARTMENTRESPONSIBLETEXT;
                public TTReportField HOSPITALCHIEFTEXT;
                public TTReportField NewField3;
                public TTReportField MANAGEMENTOFFICE;
                public TTReportField EPISODEOPENINGDATE;
                public TTReportField PATIENTSURNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 148;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 28, 13, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Sayı   :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 28, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Konu  :";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 8, 85, 13, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.Size = 12;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 85, 20, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBJECT.TextFont.Name = "Arial Narrow";
                    SUBJECT.TextFont.Size = 12;
                    SUBJECT.TextFont.CharSet = 162;
                    SUBJECT.Value = @"";

                    ENTRYTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 57, 192, 63, false);
                    ENTRYTEXT.Name = "ENTRYTEXT";
                    ENTRYTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENTRYTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    ENTRYTEXT.NoClip = EvetHayirEnum.ehEvet;
                    ENTRYTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    ENTRYTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENTRYTEXT.TextFont.Name = "Arial Narrow";
                    ENTRYTEXT.TextFont.Size = 12;
                    ENTRYTEXT.TextFont.CharSet = 162;
                    ENTRYTEXT.Value = @"";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 3, 262, 8, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.ObjectDefName = "Episode";
                    PATIENTNAME.DataMember = "PATIENT.NAME";
                    PATIENTNAME.TextFont.Name = "Arial Narrow";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#EPISODE#}";

                    DEBENTURENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 52, 263, 57, false);
                    DEBENTURENO.Name = "DEBENTURENO";
                    DEBENTURENO.Visible = EvetHayirEnum.ehHayir;
                    DEBENTURENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTURENO.ObjectDefName = "Debenture";
                    DEBENTURENO.DataMember = "NO";
                    DEBENTURENO.TextFont.Name = "Arial Narrow";
                    DEBENTURENO.TextFont.Size = 9;
                    DEBENTURENO.TextFont.CharSet = 162;
                    DEBENTURENO.Value = @"{#DEBENTURE#}";

                    DEBENTUREDUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 57, 275, 62, false);
                    DEBENTUREDUEDATE.Name = "DEBENTUREDUEDATE";
                    DEBENTUREDUEDATE.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREDUEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTUREDUEDATE.TextFormat = @"Short Date";
                    DEBENTUREDUEDATE.ObjectDefName = "Debenture";
                    DEBENTUREDUEDATE.DataMember = "DUEDATE";
                    DEBENTUREDUEDATE.TextFont.Name = "Arial Narrow";
                    DEBENTUREDUEDATE.TextFont.Size = 9;
                    DEBENTUREDUEDATE.TextFont.CharSet = 162;
                    DEBENTUREDUEDATE.Value = @"{#DEBENTURE#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 70, 267, 75, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"Medium Date";
                    DOCUMENTDATE.ObjectDefName = "Debenture";
                    DOCUMENTDATE.DataMember = "ACCOUNTDOCUMENT.DOCUMENTDATE";
                    DOCUMENTDATE.TextFont.Name = "Arial Narrow";
                    DOCUMENTDATE.TextFont.Size = 9;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#DEBENTURE#}";

                    DEBENTUREPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 81, 271, 86, false);
                    DEBENTUREPRICE.Name = "DEBENTUREPRICE";
                    DEBENTUREPRICE.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTUREPRICE.ObjectDefName = "Debenture";
                    DEBENTUREPRICE.DataMember = "PRICE";
                    DEBENTUREPRICE.TextFont.Name = "Arial Narrow";
                    DEBENTUREPRICE.TextFont.Size = 9;
                    DEBENTUREPRICE.TextFont.CharSet = 162;
                    DEBENTUREPRICE.Value = @"{#DEBENTURE#}";

                    TEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 88, 192, 113, false);
                    TEXT2.Name = "TEXT2";
                    TEXT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT2.NoClip = EvetHayirEnum.ehEvet;
                    TEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT2.TextFont.Name = "Arial Narrow";
                    TEXT2.TextFont.Size = 12;
                    TEXT2.TextFont.CharSet = 162;
                    TEXT2.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 35, 170, 40, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 12;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Hasta No :";

                    PATIENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 35, 192, 40, false);
                    PATIENTNO.Name = "PATIENTNO";
                    PATIENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNO.ObjectDefName = "Episode";
                    PATIENTNO.DataMember = "PATIENT.ID";
                    PATIENTNO.TextFont.Name = "Arial Narrow";
                    PATIENTNO.TextFont.Size = 12;
                    PATIENTNO.TextFont.CharSet = 162;
                    PATIENTNO.Value = @"{#EPISODE#}";

                    HOSPITALCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 8, 186, 13, false);
                    HOSPITALCITY.Name = "HOSPITALCITY";
                    HOSPITALCITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCITY.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPITALCITY.TextFont.Name = "Arial Narrow";
                    HOSPITALCITY.TextFont.Size = 12;
                    HOSPITALCITY.TextFont.Bold = true;
                    HOSPITALCITY.TextFont.Underline = true;
                    HOSPITALCITY.TextFont.CharSet = 162;
                    HOSPITALCITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 16, 176, 21, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.TextFormat = @"Short Date";
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.TextFont.Size = 12;
                    PRINTDATE.TextFont.Bold = true;
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@}";

                    DEPARTMENTRESPONSIBLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 131, 67, 138, false);
                    DEPARTMENTRESPONSIBLE.Name = "DEPARTMENTRESPONSIBLE";
                    DEPARTMENTRESPONSIBLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEPARTMENTRESPONSIBLE.MultiLine = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLE.NoClip = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLE.WordBreak = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLE.TextFont.Name = "Arial Narrow";
                    DEPARTMENTRESPONSIBLE.TextFont.Size = 12;
                    DEPARTMENTRESPONSIBLE.TextFont.CharSet = 162;
                    DEPARTMENTRESPONSIBLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWREPORTDEPARTMENTRESPONSIBLE"", """")































































































































































































































";

                    HOSPITALCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 131, 192, 137, false);
                    HOSPITALCHIEF.Name = "HOSPITALCHIEF";
                    HOSPITALCHIEF.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEF.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEF.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEF.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEF.TextFont.Name = "Arial Narrow";
                    HOSPITALCHIEF.TextFont.Size = 12;
                    HOSPITALCHIEF.TextFont.CharSet = 162;
                    HOSPITALCHIEF.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""XXXXXXBASHEKIMYARDIMCISI"", """")















































































































































































































































































































































";

                    DEBENTUREFOLLOWORDERPERIOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 91, 303, 96, false);
                    DEBENTUREFOLLOWORDERPERIOD.Name = "DEBENTUREFOLLOWORDERPERIOD";
                    DEBENTUREFOLLOWORDERPERIOD.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREFOLLOWORDERPERIOD.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEBENTUREFOLLOWORDERPERIOD.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWORDERPERIOD"", """")";

                    HOSPITALFAX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 113, 278, 118, false);
                    HOSPITALFAX.Name = "HOSPITALFAX";
                    HOSPITALFAX.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALFAX.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALFAX.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTFAX"", """")";

                    DEBENTUREFOLLOWPAYORDREPORTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 125, 296, 130, false);
                    DEBENTUREFOLLOWPAYORDREPORTCODE.Name = "DEBENTUREFOLLOWPAYORDREPORTCODE";
                    DEBENTUREFOLLOWPAYORDREPORTCODE.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.TextFont.Name = "Arial Narrow";
                    DEBENTUREFOLLOWPAYORDREPORTCODE.TextFont.Size = 9;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.TextFont.CharSet = 162;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTCODE"", """")";

                    DEPARTMENTRESPONSIBLETEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 124, 67, 131, false);
                    DEPARTMENTRESPONSIBLETEXT.Name = "DEPARTMENTRESPONSIBLETEXT";
                    DEPARTMENTRESPONSIBLETEXT.Visible = EvetHayirEnum.ehHayir;
                    DEPARTMENTRESPONSIBLETEXT.MultiLine = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLETEXT.NoClip = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLETEXT.WordBreak = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLETEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DEPARTMENTRESPONSIBLETEXT.TextFont.Name = "Arial Narrow";
                    DEPARTMENTRESPONSIBLETEXT.TextFont.Size = 12;
                    DEPARTMENTRESPONSIBLETEXT.TextFont.CharSet = 162;
                    DEPARTMENTRESPONSIBLETEXT.Value = @"Bölüm Sorumlusu";

                    HOSPITALCHIEFTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 124, 192, 131, false);
                    HOSPITALCHIEFTEXT.Name = "HOSPITALCHIEFTEXT";
                    HOSPITALCHIEFTEXT.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALCHIEFTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEFTEXT.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEFTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEFTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALCHIEFTEXT.TextFont.Name = "Arial Narrow";
                    HOSPITALCHIEFTEXT.TextFont.Size = 12;
                    HOSPITALCHIEFTEXT.TextFont.CharSet = 162;
                    HOSPITALCHIEFTEXT.Value = @"Başhekim Yardımcısı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 22, 28, 27, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Adres :";

                    MANAGEMENTOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 43, 272, 48, false);
                    MANAGEMENTOFFICE.Name = "MANAGEMENTOFFICE";
                    MANAGEMENTOFFICE.Visible = EvetHayirEnum.ehHayir;
                    MANAGEMENTOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MANAGEMENTOFFICE.ObjectDefName = "DebentureFollowManagementOfficeEnum";
                    MANAGEMENTOFFICE.DataMember = "DISPLAYTEXT";
                    MANAGEMENTOFFICE.TextFont.Name = "Arial Narrow";
                    MANAGEMENTOFFICE.TextFont.Size = 9;
                    MANAGEMENTOFFICE.TextFont.CharSet = 162;
                    MANAGEMENTOFFICE.Value = @"{#MANAGEMENTOFFICE#}";

                    EPISODEOPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 64, 275, 69, false);
                    EPISODEOPENINGDATE.Name = "EPISODEOPENINGDATE";
                    EPISODEOPENINGDATE.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOPENINGDATE.TextFormat = @"Short Date";
                    EPISODEOPENINGDATE.ObjectDefName = "Episode";
                    EPISODEOPENINGDATE.DataMember = "OPENINGDATE";
                    EPISODEOPENINGDATE.TextFont.Name = "Arial Narrow";
                    EPISODEOPENINGDATE.TextFont.Size = 9;
                    EPISODEOPENINGDATE.TextFont.CharSet = 162;
                    EPISODEOPENINGDATE.Value = @"{#EPISODE#}";

                    PATIENTSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 8, 262, 13, false);
                    PATIENTSURNAME.Name = "PATIENTSURNAME";
                    PATIENTSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSURNAME.ObjectDefName = "Episode";
                    PATIENTSURNAME.DataMember = "PATIENT.SURNAME";
                    PATIENTSURNAME.TextFont.Name = "Arial Narrow";
                    PATIENTSURNAME.TextFont.Size = 9;
                    PATIENTSURNAME.TextFont.CharSet = 162;
                    PATIENTSURNAME.Value = @"{#EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebentureFollow.DebentureFollowExecutionReportQuery_Class dataset_DebentureFollowExecutionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DebentureFollow.DebentureFollowExecutionReportQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    CODE.CalcValue = @"";
                    SUBJECT.CalcValue = @"";
                    ENTRYTEXT.CalcValue = @"";
                    PATIENTNAME.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Episode) : "");
                    PATIENTNAME.PostFieldValueCalculation();
                    DEBENTURENO.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Debenture) : "");
                    DEBENTURENO.PostFieldValueCalculation();
                    DEBENTUREDUEDATE.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Debenture) : "");
                    DEBENTUREDUEDATE.PostFieldValueCalculation();
                    DOCUMENTDATE.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Debenture) : "");
                    DOCUMENTDATE.PostFieldValueCalculation();
                    DEBENTUREPRICE.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Debenture) : "");
                    DEBENTUREPRICE.PostFieldValueCalculation();
                    TEXT2.CalcValue = @"";
                    NewField7.CalcValue = NewField7.Value;
                    PATIENTNO.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Episode) : "");
                    PATIENTNO.PostFieldValueCalculation();
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    DEPARTMENTRESPONSIBLETEXT.CalcValue = DEPARTMENTRESPONSIBLETEXT.Value;
                    HOSPITALCHIEFTEXT.CalcValue = HOSPITALCHIEFTEXT.Value;
                    NewField3.CalcValue = NewField3.Value;
                    MANAGEMENTOFFICE.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.ManagementOffice) : "");
                    MANAGEMENTOFFICE.PostFieldValueCalculation();
                    EPISODEOPENINGDATE.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Episode) : "");
                    EPISODEOPENINGDATE.PostFieldValueCalculation();
                    PATIENTSURNAME.CalcValue = (dataset_DebentureFollowExecutionReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowExecutionReportNQL.Episode) : "");
                    PATIENTSURNAME.PostFieldValueCalculation();
                    HOSPITALCITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    DEPARTMENTRESPONSIBLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWREPORTDEPARTMENTRESPONSIBLE", "")































































































































































































































;
                    HOSPITALCHIEF.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXBASHEKIMYARDIMCISI", "")















































































































































































































































































































































;
                    DEBENTUREFOLLOWORDERPERIOD.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWORDERPERIOD", "");
                    HOSPITALFAX.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTFAX", "");
                    DEBENTUREFOLLOWPAYORDREPORTCODE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTCODE", "");
                    return new TTReportObject[] { NewField,NewField2,CODE,SUBJECT,ENTRYTEXT,PATIENTNAME,DEBENTURENO,DEBENTUREDUEDATE,DOCUMENTDATE,DEBENTUREPRICE,TEXT2,NewField7,PATIENTNO,PRINTDATE,DEPARTMENTRESPONSIBLETEXT,HOSPITALCHIEFTEXT,NewField3,MANAGEMENTOFFICE,EPISODEOPENINGDATE,PATIENTSURNAME,HOSPITALCITY,DEPARTMENTRESPONSIBLE,HOSPITALCHIEF,DEBENTUREFOLLOWORDERPERIOD,HOSPITALFAX,DEBENTUREFOLLOWPAYORDREPORTCODE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //                                                                                    string s = new string (' ',23) ;
//            string entryTextValue = "" ;
//            this.CODE.CalcValue = this.DEBENTUREFOLLOWPAYORDREPORTCODE.CalcValue + "/" + this.DEBENTURENO.CalcValue;
//            if (this.GUARANTORNAME.CalcValue == "")
//            {
//                this.SUBJECT.CalcValue = this.PATIENTNAME.CalcValue;
//                this.ADDRESS.CalcValue =this.PATIENTADDRESS.CalcValue;
//            }
//            else
//            {
//                this.SUBJECT.CalcValue = this.GUARANTORNAME.CalcValue;
//                this.ADDRESS.CalcValue =this.GUARANTORADDRESS.CalcValue;
//            }
//            
//            this.TEXT2.CalcValue = s + "XXXXXXmize "  + this.EPISODEOPENINGDATE.FormattedValue +  " de gelen yatarak ya da ayakta tedavi gören veya hastaya kefil olan " + this.GUARANTORNAME.CalcValue + " XXXXXX masraf bedelini bilahare ödemek için   bilgilendirilmiş, fakat son ödeme tarihi " + this.DEBENTUREDUEDATE.FormattedValue + " olan borcun halen ödenmediği kayıtlarımızdan tespit edilmiştir.\n"  + s + "Yukarıda adı geçen  şahsın " +  this.DEBENTUREPRICE.CalcValue + " TL tutarında borcu olup, tahsili için gereğini arz ederim. ";
//            
//            if (this.MANAGEMENTOFFICE.CalcValue == "Mal Müdürlüğü")
//            {
//                if (this.TOWN.CalcValue != "")
//                {
//                    entryTextValue = this.TOWN.FormattedValue + " MAL MÜDÜRLÜĞÜ HAZİNE AVUKATLIĞI" ;
//                    int strLen = entryTextValue.Length ;
//                    string space = new string (' ',2*strLen);
//                    this.ENTRYTEXT.CalcValue = entryTextValue + "\n" + space + this.TOWNCITY.FormattedValue ;
//                    
//                }
//                else
//                {
//                    entryTextValue = this.CITY.FormattedValue + " MAL MÜDÜRLÜĞÜ HAZİNE AVUKATLIĞI" ;
//                    int strLen = entryTextValue.Length ;
//                    string space = new string (' ',2*strLen);
//                    this.ENTRYTEXT.CalcValue = entryTextValue + "\n" + space + this.CITY.FormattedValue ;
//                }
//            }
//            else if(this.MANAGEMENTOFFICE.CalcValue == "Muhakemat Müdürlüğü")
//            {
//                if (this.TOWN.CalcValue != "")
//                {
//                    entryTextValue = this.TOWN.FormattedValue + " MAL MÜDÜRLÜĞÜ HAZİNE AVUKATLIĞI" ;
//                    int strLen = entryTextValue.Length ;
//                    string space = new string (' ',2*strLen);
//                    this.ENTRYTEXT.CalcValue = entryTextValue + "\n" + space + this.TOWNCITY.FormattedValue ;
//                    
//                }
//                else
//                {
//                    entryTextValue = this.CITY.FormattedValue + " MAL MÜDÜRLÜĞÜ HAZİNE AVUKATLIĞI" ;
//                    int strLen = entryTextValue.Length ;
//                    string space = new string (' ',2*strLen);
//                    this.ENTRYTEXT.CalcValue = entryTextValue + "\n" + space + this.CITY.FormattedValue ;
//                }
//            }
//            else if(this.MANAGEMENTOFFICE.CalcValue == "Sağlık Grup Başkanlığı")
//            {
//                if (this.TOWN.CalcValue != "")
//                {
//                    entryTextValue = this.TOWN.FormattedValue + " MAL MÜDÜRLÜĞÜ HAZİNE AVUKATLIĞI" ;
//                    int strLen = entryTextValue.Length ;
//                    string space = new string (' ',2*strLen);
//                    this.ENTRYTEXT.CalcValue = entryTextValue + "\n" + space + this.TOWNCITY.FormattedValue ;
//                    
//                }
//                else
//                {
//                    entryTextValue = this.CITY.FormattedValue + " MAL MÜDÜRLÜĞÜ HAZİNE AVUKATLIĞI" ;
//                    int strLen = entryTextValue.Length ;
//                    string space = new string (' ',2*strLen);
//                    this.ENTRYTEXT.CalcValue = entryTextValue + "\n" + space + this.CITY.FormattedValue ;
//                }
//            }
//
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DebentureFollowExecutionReport MyParentReport
                {
                    get { return (DebentureFollowExecutionReport)ParentReport; }
                }
                
                public TTReportField FOOTERTEXT;
                public TTReportField NotLabel;
                public TTReportField HOSPITALBANKACCOUNTNO;
                public TTReportField TEXTBOTTOM;
                public TTReportField DEPARTMENTPHONE;
                public TTReportField NewField1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 51;
                    RepeatCount = 0;
                    
                    FOOTERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 9, 178, 14, false);
                    FOOTERTEXT.Name = "FOOTERTEXT";
                    FOOTERTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.NoClip = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.TextFont.Name = "Arial Narrow";
                    FOOTERTEXT.TextFont.Size = 12;
                    FOOTERTEXT.TextFont.CharSet = 162;
                    FOOTERTEXT.Value = @"Cevabınızda yazımızın tarih ve sayısını belirtiniz.";

                    NotLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 9, 21, 14, false);
                    NotLabel.Name = "NotLabel";
                    NotLabel.TextFont.Name = "Arial Narrow";
                    NotLabel.TextFont.Size = 12;
                    NotLabel.TextFont.Bold = true;
                    NotLabel.TextFont.CharSet = 162;
                    NotLabel.Value = @"NOT :";

                    HOSPITALBANKACCOUNTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 10, 294, 16, false);
                    HOSPITALBANKACCOUNTNO.Name = "HOSPITALBANKACCOUNTNO";
                    HOSPITALBANKACCOUNTNO.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALBANKACCOUNTNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALBANKACCOUNTNO.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALBANKACCOUNTNO.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALBANKACCOUNTNO.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALBANKACCOUNTNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALBANKACCOUNTNO.TextFont.Name = "Arial Narrow";
                    HOSPITALBANKACCOUNTNO.TextFont.Size = 12;
                    HOSPITALBANKACCOUNTNO.TextFont.CharSet = 162;
                    HOSPITALBANKACCOUNTNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALBANKACCOUNTNO"", """")";

                    TEXTBOTTOM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 146, 34, false);
                    TEXTBOTTOM.Name = "TEXTBOTTOM";
                    TEXTBOTTOM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXTBOTTOM.MultiLine = EvetHayirEnum.ehEvet;
                    TEXTBOTTOM.NoClip = EvetHayirEnum.ehEvet;
                    TEXTBOTTOM.WordBreak = EvetHayirEnum.ehEvet;
                    TEXTBOTTOM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXTBOTTOM.TextFont.Name = "Arial Narrow";
                    TEXTBOTTOM.TextFont.Size = 12;
                    TEXTBOTTOM.TextFont.CharSet = 162;
                    TEXTBOTTOM.Value = @"";

                    DEPARTMENTPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 35, 99, 40, false);
                    DEPARTMENTPHONE.Name = "DEPARTMENTPHONE";
                    DEPARTMENTPHONE.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEPARTMENTPHONE.MultiLine = EvetHayirEnum.ehEvet;
                    DEPARTMENTPHONE.NoClip = EvetHayirEnum.ehEvet;
                    DEPARTMENTPHONE.WordBreak = EvetHayirEnum.ehEvet;
                    DEPARTMENTPHONE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DEPARTMENTPHONE.TextFont.Name = "Arial Narrow";
                    DEPARTMENTPHONE.TextFont.Size = 12;
                    DEPARTMENTPHONE.TextFont.CharSet = 162;
                    DEPARTMENTPHONE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTPHONE"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 35, 29, 40, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Tel:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebentureFollow.DebentureFollowExecutionReportQuery_Class dataset_DebentureFollowExecutionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DebentureFollow.DebentureFollowExecutionReportQuery_Class>(0);
                    FOOTERTEXT.CalcValue = FOOTERTEXT.Value;
                    NotLabel.CalcValue = NotLabel.Value;
                    TEXTBOTTOM.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    HOSPITALBANKACCOUNTNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALBANKACCOUNTNO", "");
                    DEPARTMENTPHONE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTPHONE", "");
                    return new TTReportObject[] { FOOTERTEXT,NotLabel,TEXTBOTTOM,NewField1,HOSPITALBANKACCOUNTNO,DEPARTMENTPHONE};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.TEXTBOTTOM.CalcValue = "Hesap Numaramız : "  + this.HOSPITALBANKACCOUNTNO.CalcValue ;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public DebentureFollowExecutionReport MyParentReport
            {
                get { return (DebentureFollowExecutionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public DebentureFollowExecutionReport MyParentReport
                {
                    get { return (DebentureFollowExecutionReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DebentureFollowExecutionReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            PARTA = new PARTAGroup(HEAD,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DEBENTUREFOLLOWEXECUTIONREPORT";
            Caption = "Senet Takip Muhakemat Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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