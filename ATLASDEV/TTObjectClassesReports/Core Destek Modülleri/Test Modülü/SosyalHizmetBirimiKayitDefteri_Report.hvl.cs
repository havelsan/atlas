
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
    public partial class SosyalHizmetBirimiKayitDefteri : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string PROCEDUREBYUSER = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue("");
        }

        public partial class part1Group : TTReportGroup
        {
            public SosyalHizmetBirimiKayitDefteri MyParentReport
            {
                get { return (SosyalHizmetBirimiKayitDefteri)ParentReport; }
            }

            new public part1GroupHeader Header()
            {
                return (part1GroupHeader)_header;
            }

            new public part1GroupFooter Footer()
            {
                return (part1GroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField DocumentName { get {return Header().DocumentName;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HospitalInfo111 { get {return Header().HospitalInfo111;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new part1GroupHeader(this);
                _footer = new part1GroupFooter(this);

            }

            public partial class part1GroupHeader : TTReportSection
            {
                public SosyalHizmetBirimiKayitDefteri MyParentReport
                {
                    get { return (SosyalHizmetBirimiKayitDefteri)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField DocumentName;
                public TTReportField LOGO;
                public TTReportField HospitalInfo111;
                public TTReportField NewField1171; 
                public part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 35, 52, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.Value = @"NO";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 47, 57, 52, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.Value = @"Tarih";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 47, 85, 52, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.Value = @"Ad Soyad";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 47, 110, 52, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.Value = @"T.C Kimlik NO";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 47, 155, 52, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.Value = @"Adres";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 47, 180, 52, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.Value = @"Telefon";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 47, 205, 52, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.Value = @"İlgili Klinik";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 47, 230, 52, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.Value = @"Başvuru Nedeni";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 47, 275, 52, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.TextFont.Size = 8;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Yapılan Sosyal Hizmet Müdahalesi";

                    DocumentName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 35, 231, 44, false);
                    DocumentName.Name = "DocumentName";
                    DocumentName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DocumentName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DocumentName.MultiLine = EvetHayirEnum.ehEvet;
                    DocumentName.WordBreak = EvetHayirEnum.ehEvet;
                    DocumentName.ExpandTabs = EvetHayirEnum.ehEvet;
                    DocumentName.TextFont.Bold = true;
                    DocumentName.TextFont.CharSet = 162;
                    DocumentName.Value = @"SOSYAL HİZMET BİRİMİ KAYIT DEFTERİ
";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 7, 34, 30, false);
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

                    HospitalInfo111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 6, 235, 32, false);
                    HospitalInfo111.Name = "HospitalInfo111";
                    HospitalInfo111.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo111.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo111.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo111.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo111.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo111.TextFont.Size = 14;
                    HospitalInfo111.TextFont.Bold = true;
                    HospitalInfo111.TextFont.CharSet = 162;
                    HospitalInfo111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 47, 295, 52, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.Value = @"S.H.U.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    DocumentName.CalcValue = DocumentName.Value;
                    LOGO.CalcValue = @"";
                    NewField1171.CalcValue = NewField1171.Value;
                    HospitalInfo111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField11,NewField121,NewField131,NewField141,NewField151,NewField161,NewField171,NewField181,NewField191,DocumentName,LOGO,NewField1171,HospitalInfo111};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PART1 HEADER_Script
                }
            }
            public partial class part1GroupFooter : TTReportSection
            {
                public SosyalHizmetBirimiKayitDefteri MyParentReport
                {
                    get { return (SosyalHizmetBirimiKayitDefteri)ParentReport; }
                }
                
                public TTReportField NewField12; 
                public part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 3, 246, 8, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { NewField12};
                }
            }

        }

        public part1Group part1;

        public partial class MAINGroup : TTReportGroup
        {
            public SosyalHizmetBirimiKayitDefteri MyParentReport
            {
                get { return (SosyalHizmetBirimiKayitDefteri)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField Address { get {return Body().Address;} }
            public TTReportField PhoneNum { get {return Body().PhoneNum;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField PAPhone { get {return Body().PAPhone;} }
            public TTReportField InterviewPhone { get {return Body().InterviewPhone;} }
            public TTReportField PAaddress { get {return Body().PAaddress;} }
            public TTReportField InterviewAddress { get {return Body().InterviewAddress;} }
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
                list[0] = new TTReportNqlData<PatientInterviewForm.SocialServicesUnitRegistryReport_Class>("SocialServicesUnitRegistryReport", PatientInterviewForm.SocialServicesUnitRegistryReport((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(string)TTObjectDefManager.Instance.DataTypes["String2000"].ConvertValue(MyParentReport.RuntimeParameters.PROCEDUREBYUSER)));
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
                public SosyalHizmetBirimiKayitDefteri MyParentReport
                {
                    get { return (SosyalHizmetBirimiKayitDefteri)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField Address;
                public TTReportField PhoneNum;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField OBJECTID;
                public TTReportField NewField1131;
                public TTReportField NewField111;
                public TTReportField PAPhone;
                public TTReportField InterviewPhone;
                public TTReportField PAaddress;
                public TTReportField InterviewAddress; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"{#PROTOCOLNO#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 57, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField121.TextFormat = @"dd/MM/yyyy";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"{#EXAMINATIONDATE#}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 85, 15, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"{#NAME#} {#SURNAME#}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 110, 15, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"{#UNIQUEREFNO#}";

                    Address = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 155, 15, false);
                    Address.Name = "Address";
                    Address.DrawStyle = DrawStyleConstants.vbSolid;
                    Address.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Address.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Address.MultiLine = EvetHayirEnum.ehEvet;
                    Address.WordBreak = EvetHayirEnum.ehEvet;
                    Address.ExpandTabs = EvetHayirEnum.ehEvet;
                    Address.TextFont.Size = 9;
                    Address.TextFont.CharSet = 162;
                    Address.Value = @"";

                    PhoneNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 180, 15, false);
                    PhoneNum.Name = "PhoneNum";
                    PhoneNum.DrawStyle = DrawStyleConstants.vbSolid;
                    PhoneNum.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PhoneNum.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PhoneNum.TextFont.Size = 9;
                    PhoneNum.TextFont.CharSet = 162;
                    PhoneNum.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 205, 15, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField171.WordBreak = EvetHayirEnum.ehEvet;
                    NewField171.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"{#MNAME#}";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 230, 15, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField181.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField181.ObjectDefName = "PatientTypeEnum";
                    NewField181.DataMember = "DISPLAYTEXT";
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"{#PATIENTTYPE#}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 275, 15, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.WordBreak = EvetHayirEnum.ehEvet;
                    NewField191.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 323, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 0, 295, 15, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"{#PROCEDUREBYUSER#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 10, 15, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"{@counter@}";

                    PAPhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 8, 323, 13, false);
                    PAPhone.Name = "PAPhone";
                    PAPhone.Visible = EvetHayirEnum.ehHayir;
                    PAPhone.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAPhone.Value = @"{#ADMISSIONPHONENO#}";

                    InterviewPhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 324, 8, 349, 13, false);
                    InterviewPhone.Name = "InterviewPhone";
                    InterviewPhone.Visible = EvetHayirEnum.ehHayir;
                    InterviewPhone.FieldType = ReportFieldTypeEnum.ftVariable;
                    InterviewPhone.Value = @"{#MOBILEPHONE#}";

                    PAaddress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 1, 350, 6, false);
                    PAaddress.Name = "PAaddress";
                    PAaddress.Visible = EvetHayirEnum.ehHayir;
                    PAaddress.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAaddress.Value = @"{#ADMISSIONADDRESS#}";

                    InterviewAddress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 352, 1, 377, 6, false);
                    InterviewAddress.Name = "InterviewAddress";
                    InterviewAddress.Visible = EvetHayirEnum.ehHayir;
                    InterviewAddress.FieldType = ReportFieldTypeEnum.ftVariable;
                    InterviewAddress.Value = @"{#HOMEADDRESS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientInterviewForm.SocialServicesUnitRegistryReport_Class dataset_SocialServicesUnitRegistryReport = ParentGroup.rsGroup.GetCurrentRecord<PatientInterviewForm.SocialServicesUnitRegistryReport_Class>(0);
                    NewField11.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.ProtocolNo) : "");
                    NewField121.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.ExaminationDate) : "");
                    NewField131.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Name) : "") + @" " + (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Surname) : "");
                    NewField141.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.UniqueRefNo) : "");
                    Address.CalcValue = Address.Value;
                    PhoneNum.CalcValue = PhoneNum.Value;
                    NewField171.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Mname) : "");
                    NewField181.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.PatientType) : "");
                    NewField181.PostFieldValueCalculation();
                    NewField191.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.ObjectID) : "");
                    NewField1131.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Procedurebyuser) : "");
                    NewField111.CalcValue = ParentGroup.Counter.ToString();
                    PAPhone.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Admissionphoneno) : "");
                    InterviewPhone.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Mobilephone) : "");
                    PAaddress.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Admissionaddress) : "");
                    InterviewAddress.CalcValue = (dataset_SocialServicesUnitRegistryReport != null ? Globals.ToStringCore(dataset_SocialServicesUnitRegistryReport.Homeaddress) : "");
                    return new TTReportObject[] { NewField11,NewField121,NewField131,NewField141,Address,PhoneNum,NewField171,NewField181,NewField191,OBJECTID,NewField1131,NewField111,PAPhone,InterviewPhone,PAaddress,InterviewAddress};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = this.OBJECTID.CalcValue;
            PatientInterviewForm patientInterviewForm = (PatientInterviewForm)objectContext.GetObject(new Guid(objectID),"PatientInterviewForm");
            if (patientInterviewForm.PsychosocialStudyWithPatient != null && patientInterviewForm.PsychosocialStudyWithPatient != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hastayla Psikososyal Çalışma";
            if (patientInterviewForm.PsychosocialStudyPatFamily != null && patientInterviewForm.PsychosocialStudyPatFamily != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hasta Ailesiyle Psikososyal Çalışma";
            if (patientInterviewForm.SocialReviewAndEvolution != null && patientInterviewForm.SocialReviewAndEvolution != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Sosyal İnceleme ve Değerlendirme";
            if (patientInterviewForm.HomeOrOrganizationVisit != null && patientInterviewForm.HomeOrOrganizationVisit != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Ev veya Kuruluş Ziyareti";
            if (patientInterviewForm.WorkplaceVisit != null && patientInterviewForm.WorkplaceVisit != false)
                NewField191.CalcValue = NewField191.CalcValue + ", İşyeri Ziyareti";
            if (patientInterviewForm.SchoolVisit != null && patientInterviewForm.SchoolVisit != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Okul Ziyareti";
            if (patientInterviewForm.InstutionalCarePlacement != null && patientInterviewForm.InstutionalCarePlacement != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Kurum Bakımına Yerleştirme";
            if (patientInterviewForm.PlacementInTemporaryShelters != null && patientInterviewForm.PlacementInTemporaryShelters != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Geçici Barınma Merkezlerine Yerleştirme";
            if (patientInterviewForm.GoodsAndMoneyHelp != null && patientInterviewForm.GoodsAndMoneyHelp != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Ayni ve Nakdi Yardım";
            if (patientInterviewForm.TreatmentExpenseResourceRoute != null && patientInterviewForm.TreatmentExpenseResourceRoute != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Tedavi Giderleri için Kaynak Bulma ve Yönlendirme";
            if (patientInterviewForm.PatientsGroupStudy != null && patientInterviewForm.PatientsGroupStudy != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hastalara Grup Çalışması";
            if (patientInterviewForm.GroupStudyWithPatientFamily != null && patientInterviewForm.GroupStudyWithPatientFamily != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hasta Ailesi ile Grup Çalışması";
            if (patientInterviewForm.PatientEducationAndWorkStudy != null && patientInterviewForm.PatientEducationAndWorkStudy != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hasta Eğitimi ve Uğraşı Çalışması";
            if (patientInterviewForm.PatientTransferervice != null && patientInterviewForm.PatientTransferervice != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hasta Nakil Hizmeti";
            if (patientInterviewForm.PsychosocialEduPatientFamily != null && patientInterviewForm.PsychosocialEduPatientFamily != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Hasta Ailesinin Psikososyal Eğitimi";
            if (patientInterviewForm.SocialActivity != null && patientInterviewForm.SocialActivity != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Sosyal Etkinlik";
            if (patientInterviewForm.OtherVocationalInterventions != null && patientInterviewForm.OtherVocationalInterventions != false)
                NewField191.CalcValue = NewField191.CalcValue + ", Diğer Mesleki Müdahaleler";
            if (NewField191.CalcValue.StartsWith(","))
                NewField191.CalcValue = NewField191.CalcValue.Substring(2);
            
            if(this.InterviewPhone.CalcValue == "")
                this.PhoneNum.CalcValue = this.PAPhone.CalcValue.ToString();
            else
                this.PhoneNum.CalcValue = this.InterviewPhone.CalcValue.ToString();
            
            if(this.InterviewAddress.CalcValue == "")
                this.Address.CalcValue = this.PAaddress.CalcValue.ToString();
            else
                this.Address.CalcValue = this.InterviewAddress.CalcValue.ToString();
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

        public SosyalHizmetBirimiKayitDefteri()
        {
            part1 = new part1Group(this,"part1");
            MAIN = new MAINGroup(part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PROCEDUREBYUSER", "", "İşlemi Yapan", @"", false, false, false, new Guid("0bf6ce17-e764-4aca-9715-722d1b252a6f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PROCEDUREBYUSER"))
                _runtimeParameters.PROCEDUREBYUSER = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue(parameters["PROCEDUREBYUSER"]);
            Name = "SOSYALHIZMETBIRIMIKAYITDEFTERI";
            Caption = "SosyalHizmetBirimiKayıtDefteri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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