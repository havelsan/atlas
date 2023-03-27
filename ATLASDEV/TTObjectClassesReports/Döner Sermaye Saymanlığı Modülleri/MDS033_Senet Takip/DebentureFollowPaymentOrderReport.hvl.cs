
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
    /// Senet Takip Ödeme Emri Raporu
    /// </summary>
    public partial class DebentureFollowPaymentOrderReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public DebentureFollowPaymentOrderReport MyParentReport
            {
                get { return (DebentureFollowPaymentOrderReport)ParentReport; }
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
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField COPYORORIGINAL { get {return Header().COPYORORIGINAL;} }
            public TTReportField GCounter { get {return Header().GCounter;} }
            public TTReportField NewField { get {return Header().NewField;} }
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
                public DebentureFollowPaymentOrderReport MyParentReport
                {
                    get { return (DebentureFollowPaymentOrderReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField REPORTNAME;
                public TTReportField COPYORORIGINAL;
                public TTReportField GCounter;
                public TTReportField NewField; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 6, 145, 26, false);
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

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 27, 145, 35, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.TextFont.Name = "Arial Narrow";
                    REPORTNAME.TextFont.Size = 14;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"ÖDEME EMRİ";

                    COPYORORIGINAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 18, 192, 23, false);
                    COPYORORIGINAL.Name = "COPYORORIGINAL";
                    COPYORORIGINAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    COPYORORIGINAL.TextFont.Name = "Arial Narrow";
                    COPYORORIGINAL.TextFont.Size = 12;
                    COPYORORIGINAL.TextFont.Bold = true;
                    COPYORORIGINAL.TextFont.CharSet = 162;
                    COPYORORIGINAL.Value = @"";

                    GCounter = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 26, 283, 31, false);
                    GCounter.Name = "GCounter";
                    GCounter.Visible = EvetHayirEnum.ehHayir;
                    GCounter.FieldType = ReportFieldTypeEnum.ftVariable;
                    GCounter.Value = @"{@groupcounter@}";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 12, 257, 17, false);
                    NewField.Name = "NewField";
                    NewField.Value = @"NewField";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    COPYORORIGINAL.CalcValue = @"";
                    GCounter.CalcValue = ParentGroup.GroupCounter.ToString();
                    NewField.CalcValue = NewField.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME,COPYORORIGINAL,GCounter,NewField,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region HEAD HEADER_PreScript
                    //   if (this.GroupCounter.ToString() == "1")
        //        this.COPYORORJINAL.Value = "- ASIL -";
        //   else
        //       this.COPYORORJINAL.Value = "- SURET -";
#endregion HEAD HEADER_PreScript
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if (this.GCounter.CalcValue == "1")
                    this.COPYORORIGINAL.CalcValue = "- ASIL -";
            else
                this.COPYORORIGINAL.CalcValue = "- SURET -";
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public DebentureFollowPaymentOrderReport MyParentReport
                {
                    get { return (DebentureFollowPaymentOrderReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 130, 6, false);
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
            public DebentureFollowPaymentOrderReport MyParentReport
            {
                get { return (DebentureFollowPaymentOrderReport)ParentReport; }
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
            public TTReportField ENTRYTEXT { get {return Header().ENTRYTEXT;} }
            public TTReportField SUBJECT { get {return Header().SUBJECT;} }
            public TTReportField GUARANTORNAME { get {return Header().GUARANTORNAME;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField GUARANTORADDRESS { get {return Header().GUARANTORADDRESS;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField DEBENTURENO { get {return Header().DEBENTURENO;} }
            public TTReportField DEBENTUREDUEDATE { get {return Header().DEBENTUREDUEDATE;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DEBENTUREPRICE { get {return Header().DEBENTUREPRICE;} }
            public TTReportField TEXT2 { get {return Header().TEXT2;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField TAXNO { get {return Header().TAXNO;} }
            public TTReportField PATIENTNO { get {return Header().PATIENTNO;} }
            public TTReportField CITY { get {return Header().CITY;} }
            public TTReportField PRINTDATE { get {return Header().PRINTDATE;} }
            public TTReportField DEPARTMENTRESPONSIBLE { get {return Header().DEPARTMENTRESPONSIBLE;} }
            public TTReportField HOSPITALCHIEF { get {return Header().HOSPITALCHIEF;} }
            public TTReportField DEBENTUREFOLLOWORDERPERIOD { get {return Header().DEBENTUREFOLLOWORDERPERIOD;} }
            public TTReportField HOSPITALBANKACCOUNTNO { get {return Header().HOSPITALBANKACCOUNTNO;} }
            public TTReportField HOSPITALFAX { get {return Header().HOSPITALFAX;} }
            public TTReportField DEBENTUREFOLLOWPAYORDREPORTCODE { get {return Header().DEBENTUREFOLLOWPAYORDREPORTCODE;} }
            public TTReportField DEPARTMENTRESPONSIBLETEXT { get {return Header().DEPARTMENTRESPONSIBLETEXT;} }
            public TTReportField HOSPITALCHIEFTEXT { get {return Header().HOSPITALCHIEFTEXT;} }
            public TTReportField TEXT1 { get {return Header().TEXT1;} }
            public TTReportField PATIENTSURNAME { get {return Header().PATIENTSURNAME;} }
            public TTReportField FOOTERTEXT { get {return Footer().FOOTERTEXT;} }
            public TTReportField NotLabel { get {return Footer().NotLabel;} }
            public TTReportField UrgentNotLabel { get {return Footer().UrgentNotLabel;} }
            public TTReportField PhoneLabel { get {return Footer().PhoneLabel;} }
            public TTReportField DEPARTMENTPHONE { get {return Footer().DEPARTMENTPHONE;} }
            public TTReportField FOOTERTEXT2 { get {return Footer().FOOTERTEXT2;} }
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
                list[0] = new TTReportNqlData<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class>("DebentureFollowPaymentOrderReportNQL", DebentureFollow.DebentureFollowPaymentOrderReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DebentureFollowPaymentOrderReport MyParentReport
                {
                    get { return (DebentureFollowPaymentOrderReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField ENTRYTEXT;
                public TTReportField SUBJECT;
                public TTReportField GUARANTORNAME;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField GUARANTORADDRESS;
                public TTReportField PATIENTNAME;
                public TTReportField DEBENTURENO;
                public TTReportField DEBENTUREDUEDATE;
                public TTReportField DOCUMENTDATE;
                public TTReportField DEBENTUREPRICE;
                public TTReportField TEXT2;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField TAXNO;
                public TTReportField PATIENTNO;
                public TTReportField CITY;
                public TTReportField PRINTDATE;
                public TTReportField DEPARTMENTRESPONSIBLE;
                public TTReportField HOSPITALCHIEF;
                public TTReportField DEBENTUREFOLLOWORDERPERIOD;
                public TTReportField HOSPITALBANKACCOUNTNO;
                public TTReportField HOSPITALFAX;
                public TTReportField DEBENTUREFOLLOWPAYORDREPORTCODE;
                public TTReportField DEPARTMENTRESPONSIBLETEXT;
                public TTReportField HOSPITALCHIEFTEXT;
                public TTReportField TEXT1;
                public TTReportField PATIENTSURNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 156;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 28, 13, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Sayı  :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 28, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Konu  :";

                    ENTRYTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 8, 85, 13, false);
                    ENTRYTEXT.Name = "ENTRYTEXT";
                    ENTRYTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENTRYTEXT.TextFont.Name = "Arial Narrow";
                    ENTRYTEXT.TextFont.Size = 12;
                    ENTRYTEXT.TextFont.CharSet = 162;
                    ENTRYTEXT.Value = @"";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 85, 20, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUBJECT.TextFont.Name = "Arial Narrow";
                    SUBJECT.TextFont.Size = 12;
                    SUBJECT.TextFont.CharSet = 162;
                    SUBJECT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTSUBJECT"", """")";

                    GUARANTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 43, 127, 48, false);
                    GUARANTORNAME.Name = "GUARANTORNAME";
                    GUARANTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORNAME.ObjectDefName = "Debenture";
                    GUARANTORNAME.DataMember = "GUARANTOR.NAME";
                    GUARANTORNAME.TextFont.Name = "Arial Narrow";
                    GUARANTORNAME.TextFont.Size = 12;
                    GUARANTORNAME.TextFont.CharSet = 162;
                    GUARANTORNAME.Value = @"{#DEBENTURE#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 24, 48, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 12;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Sayın  :";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 51, 24, 56, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Size = 12;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Adres  :";

                    GUARANTORADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 51, 127, 56, false);
                    GUARANTORADDRESS.Name = "GUARANTORADDRESS";
                    GUARANTORADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTORADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    GUARANTORADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    GUARANTORADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTORADDRESS.ObjectDefName = "Debenture";
                    GUARANTORADDRESS.DataMember = "GUARANTOR.HOMEADDRESS";
                    GUARANTORADDRESS.TextFont.Name = "Arial Narrow";
                    GUARANTORADDRESS.TextFont.Size = 12;
                    GUARANTORADDRESS.TextFont.CharSet = 162;
                    GUARANTORADDRESS.Value = @"{#DEBENTURE#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 9, 261, 14, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.ObjectDefName = "Episode";
                    PATIENTNAME.DataMember = "PATIENT.NAME";
                    PATIENTNAME.TextFont.Name = "Arial Narrow";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#EPISODE#}";

                    DEBENTURENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 26, 263, 31, false);
                    DEBENTURENO.Name = "DEBENTURENO";
                    DEBENTURENO.Visible = EvetHayirEnum.ehHayir;
                    DEBENTURENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTURENO.ObjectDefName = "Debenture";
                    DEBENTURENO.DataMember = "NO";
                    DEBENTURENO.TextFont.Name = "Arial Narrow";
                    DEBENTURENO.TextFont.Size = 9;
                    DEBENTURENO.TextFont.CharSet = 162;
                    DEBENTURENO.Value = @"{#DEBENTURE#}";

                    DEBENTUREDUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 33, 275, 38, false);
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

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 63, 265, 68, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"Short Date";
                    DOCUMENTDATE.ObjectDefName = "Debenture";
                    DOCUMENTDATE.DataMember = "ACCOUNTDOCUMENT.DOCUMENTDATE";
                    DOCUMENTDATE.TextFont.Name = "Arial Narrow";
                    DOCUMENTDATE.TextFont.Size = 9;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#DEBENTURE#}";

                    DEBENTUREPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 55, 273, 60, false);
                    DEBENTUREPRICE.Name = "DEBENTUREPRICE";
                    DEBENTUREPRICE.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTUREPRICE.ObjectDefName = "Debenture";
                    DEBENTUREPRICE.DataMember = "PRICE";
                    DEBENTUREPRICE.TextFont.Name = "Arial Narrow";
                    DEBENTUREPRICE.TextFont.Size = 9;
                    DEBENTUREPRICE.TextFont.CharSet = 162;
                    DEBENTUREPRICE.Value = @"{#DEBENTURE#}";

                    TEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 83, 192, 123, false);
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

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 23, 162, 28, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 12;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Vergi No  :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 35, 162, 40, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 12;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Hasta No :";

                    TAXNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 23, 192, 28, false);
                    TAXNO.Name = "TAXNO";
                    TAXNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXNO.MultiLine = EvetHayirEnum.ehEvet;
                    TAXNO.NoClip = EvetHayirEnum.ehEvet;
                    TAXNO.WordBreak = EvetHayirEnum.ehEvet;
                    TAXNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXNO.TextFont.Name = "Arial Narrow";
                    TAXNO.TextFont.Size = 12;
                    TAXNO.TextFont.CharSet = 162;
                    TAXNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALTAXNO"", """")";

                    PATIENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 35, 192, 40, false);
                    PATIENTNO.Name = "PATIENTNO";
                    PATIENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNO.ObjectDefName = "Episode";
                    PATIENTNO.DataMember = "PATIENT.ID";
                    PATIENTNO.TextFont.Name = "Arial Narrow";
                    PATIENTNO.TextFont.Size = 12;
                    PATIENTNO.TextFont.CharSet = 162;
                    PATIENTNO.Value = @"{#EPISODE#}";

                    CITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 8, 178, 13, false);
                    CITY.Name = "CITY";
                    CITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    CITY.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CITY.TextFont.Name = "Arial Narrow";
                    CITY.TextFont.Size = 12;
                    CITY.TextFont.Bold = true;
                    CITY.TextFont.Underline = true;
                    CITY.TextFont.CharSet = 162;
                    CITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 16, 168, 21, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.TextFormat = @"Short Date";
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.TextFont.Size = 12;
                    PRINTDATE.TextFont.Bold = true;
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@}";

                    DEPARTMENTRESPONSIBLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 128, 67, 135, false);
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

                    HOSPITALCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 129, 192, 135, false);
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

                    DEBENTUREFOLLOWORDERPERIOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 42, 278, 47, false);
                    DEBENTUREFOLLOWORDERPERIOD.Name = "DEBENTUREFOLLOWORDERPERIOD";
                    DEBENTUREFOLLOWORDERPERIOD.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREFOLLOWORDERPERIOD.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEBENTUREFOLLOWORDERPERIOD.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWORDERPERIOD"", """")";

                    HOSPITALBANKACCOUNTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 75, 263, 80, false);
                    HOSPITALBANKACCOUNTNO.Name = "HOSPITALBANKACCOUNTNO";
                    HOSPITALBANKACCOUNTNO.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALBANKACCOUNTNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALBANKACCOUNTNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALBANKACCOUNTNO"", """")";

                    HOSPITALFAX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 87, 263, 92, false);
                    HOSPITALFAX.Name = "HOSPITALFAX";
                    HOSPITALFAX.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALFAX.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALFAX.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTFAX"", """")";

                    DEBENTUREFOLLOWPAYORDREPORTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 95, 297, 100, false);
                    DEBENTUREFOLLOWPAYORDREPORTCODE.Name = "DEBENTUREFOLLOWPAYORDREPORTCODE";
                    DEBENTUREFOLLOWPAYORDREPORTCODE.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.TextFont.Name = "Arial Narrow";
                    DEBENTUREFOLLOWPAYORDREPORTCODE.TextFont.Size = 9;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.TextFont.CharSet = 162;
                    DEBENTUREFOLLOWPAYORDREPORTCODE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTCODE"", """")";

                    DEPARTMENTRESPONSIBLETEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 135, 67, 142, false);
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

                    HOSPITALCHIEFTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 135, 191, 142, false);
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

                    TEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 65, 192, 80, false);
                    TEXT1.Name = "TEXT1";
                    TEXT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT1.NoClip = EvetHayirEnum.ehEvet;
                    TEXT1.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT1.TextFont.Name = "Arial Narrow";
                    TEXT1.TextFont.Size = 12;
                    TEXT1.TextFont.CharSet = 162;
                    TEXT1.Value = @"";

                    PATIENTSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 15, 260, 20, false);
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
                    DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class dataset_DebentureFollowPaymentOrderReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    ENTRYTEXT.CalcValue = @"";
                    GUARANTORNAME.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Debenture) : "");
                    GUARANTORNAME.PostFieldValueCalculation();
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    GUARANTORADDRESS.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Debenture) : "");
                    GUARANTORADDRESS.PostFieldValueCalculation();
                    PATIENTNAME.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Episode) : "");
                    PATIENTNAME.PostFieldValueCalculation();
                    DEBENTURENO.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Debenture) : "");
                    DEBENTURENO.PostFieldValueCalculation();
                    DEBENTUREDUEDATE.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Debenture) : "");
                    DEBENTUREDUEDATE.PostFieldValueCalculation();
                    DOCUMENTDATE.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Debenture) : "");
                    DOCUMENTDATE.PostFieldValueCalculation();
                    DEBENTUREPRICE.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Debenture) : "");
                    DEBENTUREPRICE.PostFieldValueCalculation();
                    TEXT2.CalcValue = @"";
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    PATIENTNO.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Episode) : "");
                    PATIENTNO.PostFieldValueCalculation();
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    DEPARTMENTRESPONSIBLETEXT.CalcValue = DEPARTMENTRESPONSIBLETEXT.Value;
                    HOSPITALCHIEFTEXT.CalcValue = HOSPITALCHIEFTEXT.Value;
                    TEXT1.CalcValue = @"";
                    PATIENTSURNAME.CalcValue = (dataset_DebentureFollowPaymentOrderReportNQL != null ? Globals.ToStringCore(dataset_DebentureFollowPaymentOrderReportNQL.Episode) : "");
                    PATIENTSURNAME.PostFieldValueCalculation();
                    SUBJECT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTSUBJECT", "");
                    TAXNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALTAXNO", "");
                    CITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    DEPARTMENTRESPONSIBLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWREPORTDEPARTMENTRESPONSIBLE", "")































































































































































































































;
                    HOSPITALCHIEF.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXBASHEKIMYARDIMCISI", "")















































































































































































































































































































































;
                    DEBENTUREFOLLOWORDERPERIOD.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWORDERPERIOD", "");
                    HOSPITALBANKACCOUNTNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALBANKACCOUNTNO", "");
                    HOSPITALFAX.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTFAX", "");
                    DEBENTUREFOLLOWPAYORDREPORTCODE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTCODE", "");
                    return new TTReportObject[] { NewField,NewField2,ENTRYTEXT,GUARANTORNAME,NewField4,NewField5,GUARANTORADDRESS,PATIENTNAME,DEBENTURENO,DEBENTUREDUEDATE,DOCUMENTDATE,DEBENTUREPRICE,TEXT2,NewField6,NewField7,PATIENTNO,PRINTDATE,DEPARTMENTRESPONSIBLETEXT,HOSPITALCHIEFTEXT,TEXT1,PATIENTSURNAME,SUBJECT,TAXNO,CITY,DEPARTMENTRESPONSIBLE,HOSPITALCHIEF,DEBENTUREFOLLOWORDERPERIOD,HOSPITALBANKACCOUNTNO,HOSPITALFAX,DEBENTUREFOLLOWPAYORDREPORTCODE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string s = new string (' ',23);
        this.TEXT1.CalcValue = s + "XXXXXXmiz bünyesinde "  + this.PATIENTNAME.CalcValue + this.PATIENTSURNAME.CalcValue +  " adına yaptırmış olduğunuz tedavi hizmetleri  karşılığında düzenlenen " +this.DEBENTURENO.CalcValue + " no'lu " + this.DOCUMENTDATE.FormattedValue + " tanzim ve " + this.DEBENTUREDUEDATE.FormattedValue + " son ödeme tarihli fatura bedelini ödemediğiniz kayıtlarımızın tetkikinde anlaşılmaktadır.";
        this.ENTRYTEXT.CalcValue = this.DEBENTUREFOLLOWPAYORDREPORTCODE.CalcValue + "/" + this.DEBENTURENO.CalcValue;
        this.TEXT2.CalcValue = s + "Adınıza tahakkuk eden " + this.DEBENTUREPRICE.CalcValue + " TL  fatura bedelini " + this.DEBENTUREFOLLOWORDERPERIOD.CalcValue + " gün içerisinde XXXXXXmiz veznesine ödemeniz veya HASTA AD,SOYAD VE FATURA NUMARASI BELİRTEREK " + this.HOSPITALBANKACCOUNTNO.CalcValue + " no'lu  Döner Sermaye Muhasebe Birimimiz hesabına yatırmanız gerekmektedir.Aksi takdirde meblağın tahsili için hukuki takip başlatılacağı  hususunda; " + "\r\n\n"  + s + "Gereğini bilgilerinize rica ederiz.";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DebentureFollowPaymentOrderReport MyParentReport
                {
                    get { return (DebentureFollowPaymentOrderReport)ParentReport; }
                }
                
                public TTReportField FOOTERTEXT;
                public TTReportField NotLabel;
                public TTReportField UrgentNotLabel;
                public TTReportField PhoneLabel;
                public TTReportField DEPARTMENTPHONE;
                public TTReportField FOOTERTEXT2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 63;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FOOTERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 192, 35, false);
                    FOOTERTEXT.Name = "FOOTERTEXT";
                    FOOTERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOOTERTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.NoClip = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOOTERTEXT.TextFont.Name = "Arial Narrow";
                    FOOTERTEXT.TextFont.Size = 9;
                    FOOTERTEXT.TextFont.CharSet = 162;
                    FOOTERTEXT.Value = @"1.) Adınıza tahakkuk eden borç miktarını bankaya yatırdığınız takdirde banka dekontunu ve bu formu {%PARTA.HOSPITALFAX%}  fax numarasına göndermeniz gerekmektedir.
2.) Gönderilen ödeme emrindeki  hasta adına herhangi bir sosyal güvenlik evrakınız (SSK, Bağkur Yeşilkart, fon evrakı, Emekli Sandığı vs.) var ise en geç 10 gün içerisinde birimimize başvurup resmi işlem ile bilgilendirme formumuzun aslını senet biriminden alabilirsiniz.
3.) Borç bedelini ödemeye gelirken elinizdeki bu evrağı mutlaka yanınızda getiriniz.";

                    NotLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 21, 13, false);
                    NotLabel.Name = "NotLabel";
                    NotLabel.TextFont.Name = "Arial Narrow";
                    NotLabel.TextFont.Size = 12;
                    NotLabel.TextFont.Bold = true;
                    NotLabel.TextFont.CharSet = 162;
                    NotLabel.Value = @"NOT :";

                    UrgentNotLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 35, 34, 40, false);
                    UrgentNotLabel.Name = "UrgentNotLabel";
                    UrgentNotLabel.TextFont.Name = "Arial Narrow";
                    UrgentNotLabel.TextFont.Size = 12;
                    UrgentNotLabel.TextFont.Bold = true;
                    UrgentNotLabel.TextFont.CharSet = 162;
                    UrgentNotLabel.Value = @"Önemli Not :";

                    PhoneLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 19, 8, false);
                    PhoneLabel.Name = "PhoneLabel";
                    PhoneLabel.TextFont.Name = "Arial Narrow";
                    PhoneLabel.TextFont.Size = 9;
                    PhoneLabel.TextFont.Bold = true;
                    PhoneLabel.TextFont.CharSet = 162;
                    PhoneLabel.Value = @"Tel:";

                    DEPARTMENTPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 3, 75, 8, false);
                    DEPARTMENTPHONE.Name = "DEPARTMENTPHONE";
                    DEPARTMENTPHONE.FieldType = ReportFieldTypeEnum.ftExpression;
                    DEPARTMENTPHONE.TextFont.Name = "Arial Narrow";
                    DEPARTMENTPHONE.TextFont.Size = 9;
                    DEPARTMENTPHONE.TextFont.CharSet = 162;
                    DEPARTMENTPHONE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DEBENTUREFOLLOWPAYORDREPORTPHONE"", """")";

                    FOOTERTEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 40, 192, 60, false);
                    FOOTERTEXT2.Name = "FOOTERTEXT2";
                    FOOTERTEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    FOOTERTEXT2.NoClip = EvetHayirEnum.ehEvet;
                    FOOTERTEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    FOOTERTEXT2.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOOTERTEXT2.TextFont.Name = "Arial Narrow";
                    FOOTERTEXT2.TextFont.Size = 9;
                    FOOTERTEXT2.TextFont.CharSet = 162;
                    FOOTERTEXT2.Value = @"*SSK'lı hastaların borç iptali için sağlık karneleri, nüfus cüzdanları ile birlikte getirecekleri vizite kağıdının tarihi (silinti karalama olmadan) XXXXXXmize hasta olarak gelip kaydının yapıldığı güne ait olması gerekmektedir.
*Bağkur'lu hastaların XXXXXXye hasta olarak geldikleri tarihte karne vizelerinin geçerli olması ve nüfus cüzdanı ile birlikte XXXXXXmize başvurmaları gerekmektedir.
*Yeşilkartlı olan hastaların borcun yapıldığı tarih itibarı ile karne vizelerinin geçerli olması ve nüfus cüzdanları ile birlikte XXXXXXmize başvurması gerekmektedir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class dataset_DebentureFollowPaymentOrderReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DebentureFollow.DebentureFollowPaymentOrderReportQuery_Class>(0);
                    FOOTERTEXT.CalcValue = @"1.) Adınıza tahakkuk eden borç miktarını bankaya yatırdığınız takdirde banka dekontunu ve bu formu " + MyParentReport.PARTA.HOSPITALFAX.CalcValue + @"  fax numarasına göndermeniz gerekmektedir.
2.) Gönderilen ödeme emrindeki  hasta adına herhangi bir sosyal güvenlik evrakınız (SSK, Bağkur Yeşilkart, fon evrakı, Emekli Sandığı vs.) var ise en geç 10 gün içerisinde birimimize başvurup resmi işlem ile bilgilendirme formumuzun aslını senet biriminden alabilirsiniz.
3.) Borç bedelini ödemeye gelirken elinizdeki bu evrağı mutlaka yanınızda getiriniz.";
                    NotLabel.CalcValue = NotLabel.Value;
                    UrgentNotLabel.CalcValue = UrgentNotLabel.Value;
                    PhoneLabel.CalcValue = PhoneLabel.Value;
                    FOOTERTEXT2.CalcValue = FOOTERTEXT2.Value;
                    DEPARTMENTPHONE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DEBENTUREFOLLOWPAYORDREPORTPHONE", "");
                    return new TTReportObject[] { FOOTERTEXT,NotLabel,UrgentNotLabel,PhoneLabel,FOOTERTEXT2,DEPARTMENTPHONE};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public DebentureFollowPaymentOrderReport MyParentReport
            {
                get { return (DebentureFollowPaymentOrderReport)ParentReport; }
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
                public DebentureFollowPaymentOrderReport MyParentReport
                {
                    get { return (DebentureFollowPaymentOrderReport)ParentReport; }
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

        public DebentureFollowPaymentOrderReport()
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
            Name = "DEBENTUREFOLLOWPAYMENTORDERREPORT";
            Caption = "Senet Takip Ödeme Emri Raporu";
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