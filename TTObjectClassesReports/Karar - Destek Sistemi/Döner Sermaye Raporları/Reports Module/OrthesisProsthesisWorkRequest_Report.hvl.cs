
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
    public partial class OrthesisProsthesisWorkRequest : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
            public string PROCEDUREOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class part1Group : TTReportGroup
        {
            public OrthesisProsthesisWorkRequest MyParentReport
            {
                get { return (OrthesisProsthesisWorkRequest)ParentReport; }
            }

            new public part1GroupHeader Header()
            {
                return (part1GroupHeader)_header;
            }

            new public part1GroupFooter Footer()
            {
                return (part1GroupFooter)_footer;
            }

            public TTReportField XXXXXXInfo { get {return Header().XXXXXXInfo;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField1451 { get {return Footer().NewField1451;} }
            public TTReportField NewField1452 { get {return Footer().NewField1452;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField1151 { get {return Footer().NewField1151;} }
            public TTReportField Technician { get {return Footer().Technician;} }
            public TTReportField NewField1251 { get {return Footer().NewField1251;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
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
                public OrthesisProsthesisWorkRequest MyParentReport
                {
                    get { return (OrthesisProsthesisWorkRequest)ParentReport; }
                }
                
                public TTReportField XXXXXXInfo;
                public TTReportField LOGO;
                public TTReportField NewField1; 
                public part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 5, 190, 52, false);
                    XXXXXXInfo.Name = "XXXXXXInfo";
                    XXXXXXInfo.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXInfo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXInfo.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXInfo.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXInfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXInfo.TextFont.Name = "Arial";
                    XXXXXXInfo.TextFont.Size = 11;
                    XXXXXXInfo.TextFont.Bold = true;
                    XXXXXXInfo.TextFont.CharSet = 162;
                    XXXXXXInfo.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 32, 29, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.Value = @"LOGO";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 56, 144, 61, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"ORTEZ-PROTEZ KISMI İŞ TALEP FORMU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"LOGO";
                    NewField1.CalcValue = NewField1.Value;
                    XXXXXXInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField1,XXXXXXInfo};
                }
            }
            public partial class part1GroupFooter : TTReportSection
            {
                public OrthesisProsthesisWorkRequest MyParentReport
                {
                    get { return (OrthesisProsthesisWorkRequest)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField1451;
                public TTReportField NewField1452;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField Technician;
                public TTReportField NewField1251;
                public TTReportField NewField12;
                public TTReportField NewField3; 
                public part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 51;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 78, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.Underline = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Ortez-Protez Birimi Tarafından Tanzim Edilecek";

                    NewField1451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 41, 14, false);
                    NewField1451.Name = "NewField1451";
                    NewField1451.TextFont.Bold = true;
                    NewField1451.TextFont.CharSet = 162;
                    NewField1451.Value = @"Görevli Personel";

                    NewField1452 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 16, 41, 21, false);
                    NewField1452.Name = "NewField1452";
                    NewField1452.TextFont.Bold = true;
                    NewField1452.TextFont.CharSet = 162;
                    NewField1452.Value = @"Birim Sorumlusu";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 9, 44, 14, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 16, 44, 21, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @":";

                    Technician = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 9, 69, 14, false);
                    Technician.Name = "Technician";
                    Technician.TextFont.CharSet = 162;
                    Technician.Value = @"";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 16, 69, 21, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.TextFont.CharSet = 162;
                    NewField1251.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 63, 28, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.Underline = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İşin Yapımında Kullanılan Malzemeler:";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 30, 33, 35, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    NewField1451.CalcValue = NewField1451.Value;
                    NewField1452.CalcValue = NewField1452.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    Technician.CalcValue = Technician.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField2,NewField1451,NewField1452,NewField1141,NewField1151,Technician,NewField1251,NewField12,NewField3};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((OrthesisProsthesisWorkRequest)ParentReport).RuntimeParameters.PROCEDUREOBJECTID.ToString();
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class[] p = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure(sObjectID).ToArray();

                    //TODO değiştir
                    foreach (OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class item in p)
                    {
                        this.Technician.CalcValue = item.Technicianname;
                    }
#endregion PART1 FOOTER_Script
                }
            }

        }

        public part1Group part1;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisWorkRequest MyParentReport
            {
                get { return (OrthesisProsthesisWorkRequest)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField PHONE { get {return Body().PHONE;} }
            public TTReportField ADRESS { get {return Body().ADRESS;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField143 { get {return Body().NewField143;} }
            public TTReportField NewField153 { get {return Body().NewField153;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField PAYER { get {return Body().PAYER;} }
            public TTReportField PROTOKOL { get {return Body().PROTOKOL;} }
            public TTReportField Doctor { get {return Body().Doctor;} }
            public TTReportField NewField154 { get {return Body().NewField154;} }
            public TTReportField NewField1152 { get {return Body().NewField1152;} }
            public TTReportField ProcedureObject { get {return Body().ProcedureObject;} }
            public TTReportField NewField155 { get {return Body().NewField155;} }
            public TTReportField NewField1153 { get {return Body().NewField1153;} }
            public TTReportField Side { get {return Body().Side;} }
            public TTReportField HiddenName { get {return Body().HiddenName;} }
            public TTReportField BirthPlace { get {return Body().BirthPlace;} }
            public TTReportField birthdate { get {return Body().birthdate;} }
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
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>("GetOrthesisRceptionReportInfo", OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OrthesisProsthesisWorkRequest MyParentReport
                {
                    get { return (OrthesisProsthesisWorkRequest)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField FULLNAME;
                public TTReportField TC;
                public TTReportField FATHERNAME;
                public TTReportField PHONE;
                public TTReportField ADRESS;
                public TTReportField NewField18;
                public TTReportField NewField123;
                public TTReportField NewField143;
                public TTReportField NewField153;
                public TTReportField NewField161;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField NewField171;
                public TTReportField PAYER;
                public TTReportField PROTOKOL;
                public TTReportField Doctor;
                public TTReportField NewField154;
                public TTReportField NewField1152;
                public TTReportField ProcedureObject;
                public TTReportField NewField155;
                public TTReportField NewField1153;
                public TTReportField Side;
                public TTReportField HiddenName;
                public TTReportField BirthPlace;
                public TTReportField birthdate; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 77;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 78, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Klinik/Poliklinik Birimi Tarafından Tanzim Edilecek";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 33, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Adı Soyadı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 33, 18, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"TC No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 18, 33, 23, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Baba Adı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 33, 28, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Tel No";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 33, 33, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Adresi";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 8, 36, 13, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 13, 36, 18, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 18, 36, 23, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 23, 36, 28, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 28, 36, 33, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @":";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 8, 113, 13, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @"{%HiddenName%}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 13, 113, 18, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.TextFont.CharSet = 162;
                    TC.Value = @"{#TCKIMLIKNO#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 18, 113, 23, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    PHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 23, 113, 28, false);
                    PHONE.Name = "PHONE";
                    PHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHONE.TextFont.CharSet = 162;
                    PHONE.Value = @"{#MOBILEPHONE#}";

                    ADRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 28, 113, 33, false);
                    ADRESS.Name = "ADRESS";
                    ADRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRESS.TextFont.CharSet = 162;
                    ADRESS.Value = @"{#HOMEADDRESS#}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 8, 148, 13, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"DoğumYeri/Tarihi";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 13, 148, 18, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"Hasta Kurumu";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 18, 148, 23, false);
                    NewField143.Name = "NewField143";
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Hast.Prot.No";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 23, 148, 28, false);
                    NewField153.Name = "NewField153";
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @"Uzm.Tabip";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 8, 151, 13, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 13, 151, 18, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 18, 151, 23, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 23, 151, 28, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 8, 206, 13, false);
                    NewField171.Name = "NewField171";
                    NewField171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"{%BirthPlace%} / {%birthdate%}";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 13, 207, 18, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYER#}";

                    PROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 18, 206, 23, false);
                    PROTOKOL.Name = "PROTOKOL";
                    PROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOL.TextFont.CharSet = 162;
                    PROTOKOL.Value = @"{#PROTOCOLNO#}";

                    Doctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 23, 206, 28, false);
                    Doctor.Name = "Doctor";
                    Doctor.TextFont.CharSet = 162;
                    Doctor.Value = @"";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 42, 41, 47, false);
                    NewField154.Name = "NewField154";
                    NewField154.TextFont.Bold = true;
                    NewField154.TextFont.CharSet = 162;
                    NewField154.Value = @"İşin Adı ve Ek Talepler";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 42, 44, 47, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.TextFont.Bold = true;
                    NewField1152.TextFont.CharSet = 162;
                    NewField1152.Value = @":";

                    ProcedureObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 42, 206, 47, false);
                    ProcedureObject.Name = "ProcedureObject";
                    ProcedureObject.MultiLine = EvetHayirEnum.ehEvet;
                    ProcedureObject.NoClip = EvetHayirEnum.ehEvet;
                    ProcedureObject.WordBreak = EvetHayirEnum.ehEvet;
                    ProcedureObject.ExpandTabs = EvetHayirEnum.ehEvet;
                    ProcedureObject.TextFont.CharSet = 162;
                    ProcedureObject.Value = @"";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 56, 33, 61, false);
                    NewField155.Name = "NewField155";
                    NewField155.TextFont.Bold = true;
                    NewField155.TextFont.CharSet = 162;
                    NewField155.Value = @"Taraf";

                    NewField1153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 56, 36, 61, false);
                    NewField1153.Name = "NewField1153";
                    NewField1153.TextFont.Bold = true;
                    NewField1153.TextFont.CharSet = 162;
                    NewField1153.Value = @":";

                    Side = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 56, 61, 61, false);
                    Side.Name = "Side";
                    Side.TextFont.Bold = true;
                    Side.TextFont.CharSet = 162;
                    Side.Value = @"";

                    HiddenName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 13, 248, 18, false);
                    HiddenName.Name = "HiddenName";
                    HiddenName.Visible = EvetHayirEnum.ehHayir;
                    HiddenName.FieldType = ReportFieldTypeEnum.ftVariable;
                    HiddenName.Value = @"{#NAME#} {#SURNAME#}";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 21, 239, 26, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.Visible = EvetHayirEnum.ehHayir;
                    BirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlace.Value = @"{#BIRTHPLACE#}";

                    birthdate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 33, 241, 38, false);
                    birthdate.Name = "birthdate";
                    birthdate.Visible = EvetHayirEnum.ehHayir;
                    birthdate.FieldType = ReportFieldTypeEnum.ftVariable;
                    birthdate.TextFormat = @"dd/MM/yyyy";
                    birthdate.Value = @"{#BIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    HiddenName.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Name) : "") + @" " + (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Surname) : "");
                    FULLNAME.CalcValue = MyParentReport.MAIN.HiddenName.CalcValue;
                    TC.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Tckimlikno) : "");
                    FATHERNAME.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.FatherName) : "");
                    PHONE.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.MobilePhone) : "");
                    ADRESS.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.HomeAddress) : "");
                    NewField18.CalcValue = NewField18.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    BirthPlace.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.BirthPlace) : "");
                    birthdate.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.BirthDate) : "");
                    NewField171.CalcValue = MyParentReport.MAIN.BirthPlace.CalcValue + @" / " + MyParentReport.MAIN.birthdate.FormattedValue;
                    PAYER.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Payer) : "");
                    PROTOKOL.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.ProtocolNo) : "");
                    Doctor.CalcValue = Doctor.Value;
                    NewField154.CalcValue = NewField154.Value;
                    NewField1152.CalcValue = NewField1152.Value;
                    ProcedureObject.CalcValue = ProcedureObject.Value;
                    NewField155.CalcValue = NewField155.Value;
                    NewField1153.CalcValue = NewField1153.Value;
                    Side.CalcValue = Side.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField13,NewField14,NewField15,NewField16,NewField121,NewField131,NewField141,NewField151,HiddenName,FULLNAME,TC,FATHERNAME,PHONE,ADRESS,NewField18,NewField123,NewField143,NewField153,NewField161,NewField1121,NewField1141,NewField1151,BirthPlace,birthdate,NewField171,PAYER,PROTOKOL,Doctor,NewField154,NewField1152,ProcedureObject,NewField155,NewField1153,Side};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((OrthesisProsthesisWorkRequest)ParentReport).RuntimeParameters.PROCEDUREOBJECTID.ToString();
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class[] p = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure(sObjectID).ToArray();

                    foreach (OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class item in p)
                    {
                        this.ProcedureObject.CalcValue = item.Procedurename;
                        if (item.Side != null)
                            this.Side.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(item.Side).DisplayText;
                    }

                    string ttObjectID = ((OrthesisProsthesisWorkRequest)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    OrthesisProsthesisRequest pp = (OrthesisProsthesisRequest)context.GetObject(new Guid(ttObjectID), "OrthesisProsthesisRequest");

                    if (pp.ProcedureDoctor != null)
                    {
                        //this.SIGNATURE.CalcValue =p.ProcedureDoctor.SignatureBlock;
                        //edited by ETAGMAT 06.03.2012
                        this.Doctor.CalcValue = pp.ProcedureDoctor.Name;
                    }
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

        public OrthesisProsthesisWorkRequest()
        {
            part1 = new part1Group(this,"part1");
            MAIN = new MAINGroup(part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
            reportParameter = Parameters.Add("PROCEDUREOBJECTID", "", "PROCEDUREOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PROCEDUREOBJECTID"))
                _runtimeParameters.PROCEDUREOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["PROCEDUREOBJECTID"]);
            Name = "ORTHESISPROSTHESISWORKREQUEST";
            Caption = "Ortez Protez Kısmı IsTalep";
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