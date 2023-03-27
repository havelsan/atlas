
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
    /// Tıbbi Genetik Tetkik İstek Formu
    /// </summary>
    public partial class GeneticRequestForm : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Part1Group : TTReportGroup
        {
            public GeneticRequestForm MyParentReport
            {
                get { return (GeneticRequestForm)ParentReport; }
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
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
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
                public GeneticRequestForm MyParentReport
                {
                    get { return (GeneticRequestForm)ParentReport; }
                }
                
                public TTReportField NewField121211;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField161;
                public TTReportField LOGO11; 
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
                    NewField121211.Value = @"TIBBİ GENETİK TETKİK İSTEK FORMU";

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

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 43, 47, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.Underline = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"HİZMETE ÖZEL";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 56, 30, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.TextFont.Name = "Courier New";
                    LOGO11.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField161.CalcValue = NewField161.Value;
                    LOGO11.CalcValue = LOGO11.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField121211,NewField161,LOGO11,XXXXXXBASLIK};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public GeneticRequestForm MyParentReport
                {
                    get { return (GeneticRequestForm)ParentReport; }
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
                    
                    HizmetOzel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 4, 243, 10, false);
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

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 5, 124, 10, false);
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
            public GeneticRequestForm MyParentReport
            {
                get { return (GeneticRequestForm)ParentReport; }
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
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField NewField11612 { get {return Body().NewField11612;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PATIENTAGE_GeneticReportQuery { get {return Body().PATIENTAGE_GeneticReportQuery;} }
            public TTReportField ReportRTF { get {return Body().ReportRTF;} }
            public TTReportField REQUESTDATE_GeneticReportQuery { get {return Body().REQUESTDATE_GeneticReportQuery;} }
            public TTReportField PATIENTNAME_GeneticReportQuery { get {return Body().PATIENTNAME_GeneticReportQuery;} }
            public TTReportField SEX_GeneticReportQuery { get {return Body().SEX_GeneticReportQuery;} }
            public TTReportField REQDOCTORNAME_GeneticReportQuery { get {return Body().REQDOCTORNAME_GeneticReportQuery;} }
            public TTReportField DEPARTMENT { get {return Body().DEPARTMENT;} }
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
                list[0] = new TTReportNqlData<GeneticTest.GeneticTestReportQuery_Class>("GeneticTestReportQuery", GeneticTest.GeneticTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<Genetic.GeneticReportQuery_Class>("GeneticReportQuery", Genetic.GeneticReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public GeneticRequestForm MyParentReport
                {
                    get { return (GeneticRequestForm)ParentReport; }
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
                public TTReportField NewField11611;
                public TTReportField NewField11612;
                public TTReportField NAME;
                public TTReportField PATIENTAGE_GeneticReportQuery;
                public TTReportField ReportRTF;
                public TTReportField REQUESTDATE_GeneticReportQuery;
                public TTReportField PATIENTNAME_GeneticReportQuery;
                public TTReportField SEX_GeneticReportQuery;
                public TTReportField REQDOCTORNAME_GeneticReportQuery;
                public TTReportField DEPARTMENT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 126;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 59, 13, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ADI SOYADI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 59, 39, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İSTEK TARİHİ";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 59, 30, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"DOKTOR ADI";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 59, 21, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"CİNSİYET / YAŞI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 59, 47, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"ÇALIŞILACAK BÖLÜM";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 8, 60, 13, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 42, 60, 47, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @":";

                    NewField111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 16, 60, 21, false);
                    NewField111231.Name = "NewField111231";
                    NewField111231.TextFont.Name = "Arial";
                    NewField111231.TextFont.Size = 9;
                    NewField111231.TextFont.Bold = true;
                    NewField111231.TextFont.CharSet = 162;
                    NewField111231.Value = @":";

                    NewField111241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 34, 60, 39, false);
                    NewField111241.Name = "NewField111241";
                    NewField111241.TextFont.Name = "Arial";
                    NewField111241.TextFont.Size = 9;
                    NewField111241.TextFont.Bold = true;
                    NewField111241.TextFont.CharSet = 162;
                    NewField111241.Value = @":";

                    NewField111251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 25, 60, 30, false);
                    NewField111251.Name = "NewField111251";
                    NewField111251.TextFont.Name = "Arial";
                    NewField111251.TextFont.Size = 9;
                    NewField111251.TextFont.Bold = true;
                    NewField111251.TextFont.CharSet = 162;
                    NewField111251.Value = @":";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 63, 59, 68, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.Underline = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"İSTENEN TETKİKLER                       :";

                    NewField11612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 59, 86, false);
                    NewField11612.Name = "NewField11612";
                    NewField11612.TextFont.Name = "Arial";
                    NewField11612.TextFont.Size = 9;
                    NewField11612.TextFont.Bold = true;
                    NewField11612.TextFont.Underline = true;
                    NewField11612.TextFont.CharSet = 162;
                    NewField11612.Value = @"KLİNİK VE ANAMNEZ BULGULAR";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 70, 201, 75, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    PATIENTAGE_GeneticReportQuery = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 16, 115, 21, false);
                    PATIENTAGE_GeneticReportQuery.Name = "PATIENTAGE_GeneticReportQuery";
                    PATIENTAGE_GeneticReportQuery.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTAGE_GeneticReportQuery.Value = @"{#PATIENTAGE!GeneticReportQuery#}";

                    ReportRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 89, 201, 117, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportRTF.Value = @"{#PREDIAGNOSIS!GeneticReportQuery#}";

                    REQUESTDATE_GeneticReportQuery = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 34, 201, 39, false);
                    REQUESTDATE_GeneticReportQuery.Name = "REQUESTDATE_GeneticReportQuery";
                    REQUESTDATE_GeneticReportQuery.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE_GeneticReportQuery.Value = @"{#REQUESTDATE!GeneticReportQuery#}";

                    PATIENTNAME_GeneticReportQuery = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 8, 202, 13, false);
                    PATIENTNAME_GeneticReportQuery.Name = "PATIENTNAME_GeneticReportQuery";
                    PATIENTNAME_GeneticReportQuery.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME_GeneticReportQuery.Value = @"{#PATIENTNAME!GeneticReportQuery#} {#SURNAME!GeneticReportQuery#}";

                    SEX_GeneticReportQuery = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 16, 87, 21, false);
                    SEX_GeneticReportQuery.Name = "SEX_GeneticReportQuery";
                    SEX_GeneticReportQuery.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX_GeneticReportQuery.ObjectDefName = "SexEnum";
                    SEX_GeneticReportQuery.DataMember = "DISPLAYTEXT";
                    SEX_GeneticReportQuery.Value = @"{#SEX!GeneticReportQuery#}";

                    REQDOCTORNAME_GeneticReportQuery = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 25, 201, 30, false);
                    REQDOCTORNAME_GeneticReportQuery.Name = "REQDOCTORNAME_GeneticReportQuery";
                    REQDOCTORNAME_GeneticReportQuery.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQDOCTORNAME_GeneticReportQuery.Value = @"{#REQDOCTORNAME!GeneticReportQuery#}";

                    DEPARTMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 42, 201, 47, false);
                    DEPARTMENT.Name = "DEPARTMENT";
                    DEPARTMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPARTMENT.ObjectDefName = "GeneticTestDefinition";
                    DEPARTMENT.DataMember = "DEPARTMENT.NAME";
                    DEPARTMENT.Value = @"{#PROCEDUREOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneticTest.GeneticTestReportQuery_Class dataset_GeneticTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneticTest.GeneticTestReportQuery_Class>(0);
                    Genetic.GeneticReportQuery_Class dataset_GeneticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Genetic.GeneticReportQuery_Class>(1);
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
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField11612.CalcValue = NewField11612.Value;
                    NAME.CalcValue = (dataset_GeneticTestReportQuery != null ? Globals.ToStringCore(dataset_GeneticTestReportQuery.Name) : "");
                    PATIENTAGE_GeneticReportQuery.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.PatientAge) : "");
                    ReportRTF.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.PreDiagnosis) : "");
                    REQUESTDATE_GeneticReportQuery.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.RequestDate) : "");
                    PATIENTNAME_GeneticReportQuery.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Patientname) : "") + @" " + (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Surname) : "");
                    SEX_GeneticReportQuery.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Sex) : "");
                    SEX_GeneticReportQuery.PostFieldValueCalculation();
                    REQDOCTORNAME_GeneticReportQuery.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Reqdoctorname) : "");
                    DEPARTMENT.CalcValue = (dataset_GeneticTestReportQuery != null ? Globals.ToStringCore(dataset_GeneticTestReportQuery.Procedureobjectid) : "");
                    DEPARTMENT.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField111,NewField121,NewField1131,NewField1141,NewField1161,NewField11211,NewField111211,NewField111231,NewField111241,NewField111251,NewField11611,NewField11612,NAME,PATIENTAGE_GeneticReportQuery,ReportRTF,REQUESTDATE_GeneticReportQuery,PATIENTNAME_GeneticReportQuery,SEX_GeneticReportQuery,REQDOCTORNAME_GeneticReportQuery,DEPARTMENT};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((GeneticRequestForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Genetic genetic = (Genetic)context.GetObject(new Guid(sObjectID),"Genetic");
            this.ReportRTF.Value = genetic.PreDiagnosis;
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GeneticRequestForm()
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
            Name = "GENETICREQUESTFORM";
            Caption = "Tıbbi Genetik Tetkik İstek Formu";
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