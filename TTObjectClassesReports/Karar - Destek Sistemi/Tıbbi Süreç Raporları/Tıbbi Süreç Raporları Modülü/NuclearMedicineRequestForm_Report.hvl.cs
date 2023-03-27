
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
    /// Nükleer Tıp Tetkik İstek Formu
    /// </summary>
    public partial class NuclearMedicineRequestForm : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Part1Group : TTReportGroup
        {
            public NuclearMedicineRequestForm MyParentReport
            {
                get { return (NuclearMedicineRequestForm)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField NewField121211 { get {return Header().NewField121211;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HizmetOzel1 { get {return Footer().HizmetOzel1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField UserName1 { get {return Footer().UserName1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public NuclearMedicineRequestForm MyParentReport
                {
                    get { return (NuclearMedicineRequestForm)ParentReport; }
                }
                
                public TTReportField NewField121211;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField161;
                public TTReportField LOGO; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 33, 202, 40, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121211.TextFont.Name = "Arial";
                    NewField121211.TextFont.Size = 14;
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @"NÜKLEER TIP TETKİK İSTEK FORMU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 10, 202, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 43, 46, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.Underline = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 12, 44, 35, false);
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
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField161.CalcValue = NewField161.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField121211,NewField161,LOGO,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PART1 HEADER_Script
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public NuclearMedicineRequestForm MyParentReport
                {
                    get { return (NuclearMedicineRequestForm)ParentReport; }
                }
                
                public TTReportField HizmetOzel1;
                public TTReportShape NewLine1;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HizmetOzel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 5, 243, 11, false);
                    HizmetOzel1.Name = "HizmetOzel1";
                    HizmetOzel1.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel1.TextFont.Size = 11;
                    HizmetOzel1.TextFont.Bold = true;
                    HizmetOzel1.TextFont.Underline = true;
                    HizmetOzel1.TextFont.CharSet = 162;
                    HizmetOzel1.Value = @"HİZMETE ÖZEL";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 4, 201, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 35, 10, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 5, 125, 10, false);
                    UserName1.Name = "UserName1";
                    UserName1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName1.TextFont.Size = 8;
                    UserName1.TextFont.CharSet = 162;
                    UserName1.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 5, 201, 10, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel1.CalcValue = HizmetOzel1.Value;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel1,PrintDate1,PageNumber1,UserName1};
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public NuclearMedicineRequestForm MyParentReport
            {
                get { return (NuclearMedicineRequestForm)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField111231 { get {return Body().NewField111231;} }
            public TTReportField NewField111241 { get {return Body().NewField111241;} }
            public TTReportField NewField111251 { get {return Body().NewField111251;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField REQDOCTORNAME { get {return Body().REQDOCTORNAME;} }
            public TTReportField NUCLEARMEDICINEDEPARTMENTNAME { get {return Body().NUCLEARMEDICINEDEPARTMENTNAME;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportField NUCLEARMEDICINETESTNAME { get {return Body().NUCLEARMEDICINETESTNAME;} }
            public TTReportField NewField11612 { get {return Body().NewField11612;} }
            public TTReportField PREDIAGNOSIS { get {return Body().PREDIAGNOSIS;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField11421 { get {return Body().NewField11421;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField NewField11631 { get {return Body().NewField11631;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public TTReportField NewField1112112 { get {return Body().NewField1112112;} }
            public TTReportField NewField1112113 { get {return Body().NewField1112113;} }
            public TTReportField NewField1112114 { get {return Body().NewField1112114;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField ICD { get {return Body().ICD;} }
            public TTReportField ONTANI { get {return Body().ONTANI;} }
            public TTReportField NewField11112112 { get {return Body().NewField11112112;} }
            public TTReportField UNIQUEREF { get {return Body().UNIQUEREF;} }
            public TTReportField NewField112411 { get {return Body().NewField112411;} }
            public TTReportField NewField13112111 { get {return Body().NewField13112111;} }
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
                list[0] = new TTReportNqlData<NuclearMedicine.NuclearMedicineReportNQL_Class>("NuclearMedicineReportNQL", NuclearMedicine.NuclearMedicineReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<NuclearMedicineTest.NuclearMedicineTestReportQuery_Class>("NuclearMedicineTestReportQuery", NuclearMedicineTest.NuclearMedicineTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NuclearMedicineRequestForm MyParentReport
                {
                    get { return (NuclearMedicineRequestForm)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField1161;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField111231;
                public TTReportField NewField111241;
                public TTReportField NewField111251;
                public TTReportField PATIENTNAME;
                public TTReportField REQDOCTORNAME;
                public TTReportField NUCLEARMEDICINEDEPARTMENTNAME;
                public TTReportField REQUESTDATE;
                public TTReportField SEX;
                public TTReportField NewField11611;
                public TTReportField AGE;
                public TTReportField NUCLEARMEDICINETESTNAME;
                public TTReportField NewField11612;
                public TTReportField PREDIAGNOSIS;
                public TTReportField NewField111611;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField11231;
                public TTReportField HASTANO;
                public TTReportField NewField11421;
                public TTReportField ACTIONID;
                public TTReportField NewField11631;
                public TTReportField NewField1112111;
                public TTReportField NewField1112112;
                public TTReportField NewField1112113;
                public TTReportField NewField1112114;
                public TTReportField NewField1116111;
                public TTReportField NewField11112111;
                public TTReportField ICD;
                public TTReportField ONTANI;
                public TTReportField NewField11112112;
                public TTReportField UNIQUEREF;
                public TTReportField NewField112411;
                public TTReportField NewField13112111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 124;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 47, 15, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ADI SOYADI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 47, 36, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İSTEK TARİHİ";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 47, 29, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"DOKTOR ADI";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 47, 22, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"CİNSİYET / YAŞI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 47, 43, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"ÇALIŞILACAK BÖLÜM";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 10, 49, 15, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 38, 49, 43, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @":";

                    NewField111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 17, 49, 22, false);
                    NewField111231.Name = "NewField111231";
                    NewField111231.TextFont.Name = "Arial";
                    NewField111231.TextFont.Size = 9;
                    NewField111231.TextFont.Bold = true;
                    NewField111231.TextFont.CharSet = 162;
                    NewField111231.Value = @":";

                    NewField111241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 31, 49, 36, false);
                    NewField111241.Name = "NewField111241";
                    NewField111241.TextFont.Name = "Arial";
                    NewField111241.TextFont.Size = 9;
                    NewField111241.TextFont.Bold = true;
                    NewField111241.TextFont.CharSet = 162;
                    NewField111241.Value = @":";

                    NewField111251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 24, 49, 29, false);
                    NewField111251.Name = "NewField111251";
                    NewField111251.TextFont.Name = "Arial";
                    NewField111251.TextFont.Size = 9;
                    NewField111251.TextFont.Bold = true;
                    NewField111251.TextFont.CharSet = 162;
                    NewField111251.Value = @":";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 10, 110, 15, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENTNAME#} {#SURNAME#}";

                    REQDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 24, 110, 29, false);
                    REQDOCTORNAME.Name = "REQDOCTORNAME";
                    REQDOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQDOCTORNAME.TextFont.Name = "Arial";
                    REQDOCTORNAME.TextFont.Size = 9;
                    REQDOCTORNAME.TextFont.CharSet = 162;
                    REQDOCTORNAME.Value = @"{#REQDOCTORNAME#}";

                    NUCLEARMEDICINEDEPARTMENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 38, 110, 43, false);
                    NUCLEARMEDICINEDEPARTMENTNAME.Name = "NUCLEARMEDICINEDEPARTMENTNAME";
                    NUCLEARMEDICINEDEPARTMENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUCLEARMEDICINEDEPARTMENTNAME.ObjectDefName = "ResNuclearMedicineDepartment";
                    NUCLEARMEDICINEDEPARTMENTNAME.DataMember = "NAME";
                    NUCLEARMEDICINEDEPARTMENTNAME.TextFont.Name = "Arial";
                    NUCLEARMEDICINEDEPARTMENTNAME.TextFont.Size = 9;
                    NUCLEARMEDICINEDEPARTMENTNAME.TextFont.CharSet = 162;
                    NUCLEARMEDICINEDEPARTMENTNAME.Value = @"{#MASTERRESNAME#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 31, 110, 36, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFont.Name = "Arial";
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 17, 83, 22, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.ObjectDefName = "SexEnum";
                    SEX.DataMember = "DISPLAYTEXT";
                    SEX.TextFont.Name = "Arial";
                    SEX.TextFont.Size = 9;
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"{#SEX#}";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 65, 59, 70, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.Underline = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"İSTENEN TETKİKLER                       :";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 17, 110, 22, false);
                    AGE.Name = "AGE";
                    AGE.Value = @"{#PATIENTAGE#}";

                    NUCLEARMEDICINETESTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 71, 150, 76, false);
                    NUCLEARMEDICINETESTNAME.Name = "NUCLEARMEDICINETESTNAME";
                    NUCLEARMEDICINETESTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NUCLEARMEDICINETESTNAME.TextFont.Name = "Arial";
                    NUCLEARMEDICINETESTNAME.TextFont.Size = 9;
                    NUCLEARMEDICINETESTNAME.TextFont.CharSet = 162;
                    NUCLEARMEDICINETESTNAME.Value = @"{#NAME#}";

                    NewField11612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 83, 63, 88, false);
                    NewField11612.Name = "NewField11612";
                    NewField11612.TextFont.Name = "Arial";
                    NewField11612.TextFont.Size = 9;
                    NewField11612.TextFont.Bold = true;
                    NewField11612.TextFont.Underline = true;
                    NewField11612.TextFont.CharSet = 162;
                    NewField11612.Value = @"KLİNİK VE ANAMNEZ BULGULAR";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 90, 201, 122, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.Value = @"{#PREDIAGNOSIS#}";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 47, 50, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 9;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"KABUL SEBEBİ";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 3, 202, 8, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.ObjectDefName = "NuclearMedicine";
                    PROTOKOLNO.DataMember = "EPISODE.HOSPITALPROTOCOLNO";
                    PROTOKOLNO.TextFont.Name = "Arial";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{@TTOBJECTID@}";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 3, 146, 8, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Name = "Arial";
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"PROTOKOL NO";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 17, 202, 22, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "NuclearMedicine";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Name = "Arial";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 17, 146, 22, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.TextFont.Name = "Arial";
                    NewField11421.TextFont.Size = 9;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"HASTA NO";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 10, 202, 15, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.ObjectDefName = "NuclearMedicine";
                    ACTIONID.DataMember = "ID";
                    ACTIONID.TextFont.Name = "Arial";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{@TTOBJECTID@}";

                    NewField11631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 10, 146, 15, false);
                    NewField11631.Name = "NewField11631";
                    NewField11631.TextFont.Name = "Arial";
                    NewField11631.TextFont.Size = 9;
                    NewField11631.TextFont.Bold = true;
                    NewField11631.TextFont.CharSet = 162;
                    NewField11631.Value = @"İŞLEM NO";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 45, 49, 50, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Name = "Arial";
                    NewField1112111.TextFont.Size = 9;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @":";

                    NewField1112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 10, 148, 15, false);
                    NewField1112112.Name = "NewField1112112";
                    NewField1112112.TextFont.Name = "Arial";
                    NewField1112112.TextFont.Size = 9;
                    NewField1112112.TextFont.Bold = true;
                    NewField1112112.TextFont.CharSet = 162;
                    NewField1112112.Value = @":";

                    NewField1112113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 17, 148, 22, false);
                    NewField1112113.Name = "NewField1112113";
                    NewField1112113.TextFont.Name = "Arial";
                    NewField1112113.TextFont.Size = 9;
                    NewField1112113.TextFont.Bold = true;
                    NewField1112113.TextFont.CharSet = 162;
                    NewField1112113.Value = @":";

                    NewField1112114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 3, 148, 8, false);
                    NewField1112114.Name = "NewField1112114";
                    NewField1112114.TextFont.Name = "Arial";
                    NewField1112114.TextFont.Size = 9;
                    NewField1112114.TextFont.Bold = true;
                    NewField1112114.TextFont.CharSet = 162;
                    NewField1112114.Value = @":";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 24, 146, 29, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.TextFont.Name = "Arial";
                    NewField1116111.TextFont.Size = 9;
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"RÜTBE";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 24, 148, 29, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Name = "Arial";
                    NewField11112111.TextFont.Size = 9;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @":";

                    ICD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 47, 57, false);
                    ICD.Name = "ICD";
                    ICD.TextFont.Name = "Arial";
                    ICD.TextFont.Size = 9;
                    ICD.TextFont.Bold = true;
                    ICD.TextFont.CharSet = 162;
                    ICD.Value = @"ÖN TANI (ICD 10)";

                    ONTANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 52, 202, 57, false);
                    ONTANI.Name = "ONTANI";
                    ONTANI.MultiLine = EvetHayirEnum.ehEvet;
                    ONTANI.NoClip = EvetHayirEnum.ehEvet;
                    ONTANI.WordBreak = EvetHayirEnum.ehEvet;
                    ONTANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONTANI.TextFont.Name = "Arial";
                    ONTANI.TextFont.Size = 9;
                    ONTANI.TextFont.CharSet = 162;
                    ONTANI.Value = @"ONTANI";

                    NewField11112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 52, 49, 57, false);
                    NewField11112112.Name = "NewField11112112";
                    NewField11112112.TextFont.Name = "Arial";
                    NewField11112112.TextFont.Size = 9;
                    NewField11112112.TextFont.Bold = true;
                    NewField11112112.TextFont.CharSet = 162;
                    NewField11112112.Value = @":";

                    UNIQUEREF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 3, 110, 8, false);
                    UNIQUEREF.Name = "UNIQUEREF";
                    UNIQUEREF.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREF.ObjectDefName = "NuclearMedicine";
                    UNIQUEREF.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UNIQUEREF.TextFont.Name = "Arial";
                    UNIQUEREF.TextFont.Size = 9;
                    UNIQUEREF.TextFont.CharSet = 162;
                    UNIQUEREF.Value = @"{@TTOBJECTID@}";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 47, 8, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.TextFont.Name = "Arial";
                    NewField112411.TextFont.Size = 9;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.TextFont.CharSet = 162;
                    NewField112411.Value = @"T.C. KİMLİK NO";

                    NewField13112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 3, 49, 8, false);
                    NewField13112111.Name = "NewField13112111";
                    NewField13112111.TextFont.Name = "Arial";
                    NewField13112111.TextFont.Size = 9;
                    NewField13112111.TextFont.Bold = true;
                    NewField13112111.TextFont.CharSet = 162;
                    NewField13112111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NuclearMedicine.NuclearMedicineReportNQL_Class dataset_NuclearMedicineReportNQL = ParentGroup.rsGroup.GetCurrentRecord<NuclearMedicine.NuclearMedicineReportNQL_Class>(0);
                    NuclearMedicineTest.NuclearMedicineTestReportQuery_Class dataset_NuclearMedicineTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<NuclearMedicineTest.NuclearMedicineTestReportQuery_Class>(1);
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111231.CalcValue = NewField111231.Value;
                    NewField111241.CalcValue = NewField111241.Value;
                    NewField111251.CalcValue = NewField111251.Value;
                    PATIENTNAME.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Patientname) : "") + @" " + (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Surname) : "");
                    REQDOCTORNAME.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Reqdoctorname) : "");
                    NUCLEARMEDICINEDEPARTMENTNAME.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Masterresname) : "");
                    NUCLEARMEDICINEDEPARTMENTNAME.PostFieldValueCalculation();
                    REQUESTDATE.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.RequestDate) : "");
                    SEX.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Sex) : "");
                    SEX.PostFieldValueCalculation();
                    NewField11611.CalcValue = NewField11611.Value;
                    AGE.CalcValue = AGE.Value;
                    NUCLEARMEDICINETESTNAME.CalcValue = NUCLEARMEDICINETESTNAME.Value;
                    NewField11612.CalcValue = NewField11612.Value;
                    PREDIAGNOSIS.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.PreDiagnosis) : "");
                    NewField111611.CalcValue = NewField111611.Value;
                    PROTOKOLNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROTOKOLNO.PostFieldValueCalculation();
                    NewField11231.CalcValue = NewField11231.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField11421.CalcValue = NewField11421.Value;
                    ACTIONID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ACTIONID.PostFieldValueCalculation();
                    NewField11631.CalcValue = NewField11631.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1112112.CalcValue = NewField1112112.Value;
                    NewField1112113.CalcValue = NewField1112113.Value;
                    NewField1112114.CalcValue = NewField1112114.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    ICD.CalcValue = ICD.Value;
                    ONTANI.CalcValue = ONTANI.Value;
                    NewField11112112.CalcValue = NewField11112112.Value;
                    UNIQUEREF.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UNIQUEREF.PostFieldValueCalculation();
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField13112111.CalcValue = NewField13112111.Value;
                    return new TTReportObject[] { NewField111,NewField121,NewField1131,NewField1141,NewField1161,NewField11211,NewField111211,NewField111231,NewField111241,NewField111251,PATIENTNAME,REQDOCTORNAME,NUCLEARMEDICINEDEPARTMENTNAME,REQUESTDATE,SEX,NewField11611,AGE,NUCLEARMEDICINETESTNAME,NewField11612,PREDIAGNOSIS,NewField111611,PROTOKOLNO,NewField11231,HASTANO,NewField11421,ACTIONID,NewField11631,NewField1112111,NewField1112112,NewField1112113,NewField1112114,NewField1116111,NewField11112111,ICD,ONTANI,NewField11112112,UNIQUEREF,NewField112411,NewField13112111};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NuclearMedicineRequestForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NuclearMedicine nucObject = (NuclearMedicine)context.GetObject(new Guid(sObjectID),"NuclearMedicine");
            string preDiagnosis = null;
            
            List<DiagnosisDefinition> distinctList = new List<DiagnosisDefinition>();
            
            foreach(DiagnosisGrid dig in nucObject.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Primer)
                {
                    if (distinctList.Contains(dig.Diagnose) == false)
                    {
                        preDiagnosis = preDiagnosis + dig.Diagnose.Code.ToString() + " " + dig.Diagnose.Name.ToString() + ", " ;
                        distinctList.Add(dig.Diagnose);
                    }
                }
            }
            
            distinctList = null;
            
            this.ONTANI.CalcValue = preDiagnosis;
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

        public NuclearMedicineRequestForm()
        {
            Part1 = new Part1Group(this,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protokol No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("458e9a61-c56f-4285-88d4-a27473fb9964");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NUCLEARMEDICINEREQUESTFORM";
            Caption = "Nükleer Tıp Tetkik İstek Formu";
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