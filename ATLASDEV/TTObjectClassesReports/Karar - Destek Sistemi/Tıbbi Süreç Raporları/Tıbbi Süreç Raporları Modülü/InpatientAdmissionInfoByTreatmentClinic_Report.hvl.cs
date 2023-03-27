
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
    /// Hasta Yatış Formu
    /// </summary>
    public partial class InpatientAdmissionInfoByTreatmentClinic : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public InpatientAdmissionInfoByTreatmentClinic MyParentReport
            {
                get { return (InpatientAdmissionInfoByTreatmentClinic)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HEADER1 { get {return Header().HEADER1;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public InpatientAdmissionInfoByTreatmentClinic MyParentReport
                {
                    get { return (InpatientAdmissionInfoByTreatmentClinic)ParentReport; }
                }
                
                public TTReportField HEADER1;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField LOGO1;
                public TTReportField DATE; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 42, 196, 47, false);
                    HEADER1.Name = "HEADER1";
                    HEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HEADER1.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER1.TextFont.Name = "Courier New";
                    HEADER1.TextFont.Bold = true;
                    HEADER1.TextFont.CharSet = 162;
                    HEADER1.Value = @"HASTA YATIŞ FORMU";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 9, 196, 41, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Microsoft Sans Serif";
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 36, 41, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO1.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO1.DataMember = "EMBLEM";
                    LOGO1.TextFont.Name = "Courier New";
                    LOGO1.Value = @"";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 52, 182, 56, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.TextFont.Name = "Courier New";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER1.CalcValue = HEADER1.Value;
                    LOGO1.CalcValue = @"";
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { HEADER1,LOGO1,DATE,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO1.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public InpatientAdmissionInfoByTreatmentClinic MyParentReport
                {
                    get { return (InpatientAdmissionInfoByTreatmentClinic)ParentReport; }
                }
                
                public TTReportField ISTEKDR; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 56;
                    RepeatCount = 0;
                    
                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 8, 208, 50, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Name = "Arial Unicode MS";
                    ISTEKDR.TextFont.Size = 8;
                    ISTEKDR.TextFont.CharSet = 162;
                    ISTEKDR.Value = @"ISTEKDR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ISTEKDR.CalcValue = ISTEKDR.Value;
                    return new TTReportObject[] { ISTEKDR};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((InpatientAdmissionInfoByTreatmentClinic)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
            var inPatientTreatmentClinicAppList = InPatientTreatmentClinicApplication.GetByBaseInpatientAdmission(objectContext, objectID);
            if (inPatientTreatmentClinicAppList.Count > 0)
                inPatientTreatmentClinicApp = inPatientTreatmentClinicAppList[0];
            else
                inPatientTreatmentClinicApp = (InPatientTreatmentClinicApplication)objectContext.GetObject(new Guid(objectID), "InPatientTreatmentClinicApplication");

            if(inPatientTreatmentClinicApp.ProcedureDoctor!=null)
                this.ISTEKDR.CalcValue = inPatientTreatmentClinicApp.ProcedureDoctor.SignatureBlock+"\n\n\n\n";
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientAdmissionInfoByTreatmentClinic MyParentReport
            {
                get { return (InpatientAdmissionInfoByTreatmentClinic)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1251 { get {return Body().NewField1251;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportField NewField11521 { get {return Body().NewField11521;} }
            public TTReportField NewField11531 { get {return Body().NewField11531;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
            public TTReportField ISLEM_NO { get {return Body().ISLEM_NO;} }
            public TTReportField NewField112511 { get {return Body().NewField112511;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField NewField112512 { get {return Body().NewField112512;} }
            public TTReportField NewField111612 { get {return Body().NewField111612;} }
            public TTReportField GELDIGI_KLINIK { get {return Body().GELDIGI_KLINIK;} }
            public TTReportField NewField112513 { get {return Body().NewField112513;} }
            public TTReportField NewField111613 { get {return Body().NewField111613;} }
            public TTReportField DIAGNOSE { get {return Body().DIAGNOSE;} }
            public TTReportField NewField1115211 { get {return Body().NewField1115211;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField CLINICINPATIENTDATE { get {return Body().CLINICINPATIENTDATE;} }
            public TTReportField NewField1215211 { get {return Body().NewField1215211;} }
            public TTReportField NewField1216111 { get {return Body().NewField1216111;} }
            public TTReportField PROCEDUREDOCTOR { get {return Body().PROCEDUREDOCTOR;} }
            public TTReportField NewField1315211 { get {return Body().NewField1315211;} }
            public TTReportField NewField1316111 { get {return Body().NewField1316111;} }
            public TTReportField YATTIGI_KLINIK { get {return Body().YATTIGI_KLINIK;} }
            public TTReportField NewField1115212 { get {return Body().NewField1115212;} }
            public TTReportField NewField1116112 { get {return Body().NewField1116112;} }
            public TTReportField PAYER { get {return Body().PAYER;} }
            public TTReportField NewField1215212 { get {return Body().NewField1215212;} }
            public TTReportField NewField1216112 { get {return Body().NewField1216112;} }
            public TTReportField PAYERTYPE { get {return Body().PAYERTYPE;} }
            public TTReportField NewField1315213 { get {return Body().NewField1315213;} }
            public TTReportField NewField1316113 { get {return Body().NewField1316113;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField NewField11125111 { get {return Body().NewField11125111;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField MOTHERNAME { get {return Body().MOTHERNAME;} }
            public TTReportField NewField11125121 { get {return Body().NewField11125121;} }
            public TTReportField NewField11116121 { get {return Body().NewField11116121;} }
            public TTReportField BIRTHPLACE { get {return Body().BIRTHPLACE;} }
            public TTReportField NewField11125131 { get {return Body().NewField11125131;} }
            public TTReportField NewField11116131 { get {return Body().NewField11116131;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField NewField12125111 { get {return Body().NewField12125111;} }
            public TTReportField NewField12116111 { get {return Body().NewField12116111;} }
            public TTReportField YATISKARARIVEREN { get {return Body().YATISKARARIVEREN;} }
            public TTReportField NewField12125121 { get {return Body().NewField12125121;} }
            public TTReportField NewField12116121 { get {return Body().NewField12116121;} }
            public TTReportField ODA { get {return Body().ODA;} }
            public TTReportField NewField12125131 { get {return Body().NewField12125131;} }
            public TTReportField NewField12116131 { get {return Body().NewField12116131;} }
            public TTReportField ADDRESS { get {return Body().ADDRESS;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField ISLEM_NO1133 { get {return Body().ISLEM_NO1133;} }
            public TTReportField ISLEM_NO13311 { get {return Body().ISLEM_NO13311;} }
            public TTReportField NewField113152121 { get {return Body().NewField113152121;} }
            public TTReportField NewField113161121 { get {return Body().NewField113161121;} }
            public TTReportField MOBILEPHONE { get {return Body().MOBILEPHONE;} }
            public TTReportField NewField1121161311 { get {return Body().NewField1121161311;} }
            public TTReportField NewField1121161312 { get {return Body().NewField1121161312;} }
            public TTReportField NewField1121161313 { get {return Body().NewField1121161313;} }
            public TTReportField NewField1121161314 { get {return Body().NewField1121161314;} }
            public TTReportField NewField111614 { get {return Body().NewField111614;} }
            public TTReportField NewField1416111 { get {return Body().NewField1416111;} }
            public TTReportField NewField11116141 { get {return Body().NewField11116141;} }
            public TTReportField NewField114161111 { get {return Body().NewField114161111;} }
            public TTReportField YATAK { get {return Body().YATAK;} }
            public TTReportField ISLEM_NO13312 { get {return Body().ISLEM_NO13312;} }
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
                list[0] = new TTReportNqlData<InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class>("GetInpatientAdmissionInfoByTreatmentClinic", InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InpatientAdmissionInfoByTreatmentClinic MyParentReport
                {
                    get { return (InpatientAdmissionInfoByTreatmentClinic)ParentReport; }
                }
                
                public TTReportField NewField1221;
                public TTReportField NewField1251;
                public TTReportField NewField11221;
                public TTReportField NewField11521;
                public TTReportField NewField11531;
                public TTReportField NewField11611;
                public TTReportField FULLNAME;
                public TTReportField KIMLIKNO;
                public TTReportField ISLEM_NO;
                public TTReportField NewField112511;
                public TTReportField NewField111611;
                public TTReportField PROTOCOLNO;
                public TTReportField NewField112512;
                public TTReportField NewField111612;
                public TTReportField GELDIGI_KLINIK;
                public TTReportField NewField112513;
                public TTReportField NewField111613;
                public TTReportField DIAGNOSE;
                public TTReportField NewField1115211;
                public TTReportField NewField1116111;
                public TTReportField CLINICINPATIENTDATE;
                public TTReportField NewField1215211;
                public TTReportField NewField1216111;
                public TTReportField PROCEDUREDOCTOR;
                public TTReportField NewField1315211;
                public TTReportField NewField1316111;
                public TTReportField YATTIGI_KLINIK;
                public TTReportField NewField1115212;
                public TTReportField NewField1116112;
                public TTReportField PAYER;
                public TTReportField NewField1215212;
                public TTReportField NewField1216112;
                public TTReportField PAYERTYPE;
                public TTReportField NewField1315213;
                public TTReportField NewField1316113;
                public TTReportField FATHERNAME;
                public TTReportField NewField11125111;
                public TTReportField NewField11116111;
                public TTReportField MOTHERNAME;
                public TTReportField NewField11125121;
                public TTReportField NewField11116121;
                public TTReportField BIRTHPLACE;
                public TTReportField NewField11125131;
                public TTReportField NewField11116131;
                public TTReportField BIRTHDATE;
                public TTReportField NewField12125111;
                public TTReportField NewField12116111;
                public TTReportField YATISKARARIVEREN;
                public TTReportField NewField12125121;
                public TTReportField NewField12116121;
                public TTReportField ODA;
                public TTReportField NewField12125131;
                public TTReportField NewField12116131;
                public TTReportField ADDRESS;
                public TTReportField AGE;
                public TTReportField SEX;
                public TTReportField ISLEM_NO1133;
                public TTReportField ISLEM_NO13311;
                public TTReportField NewField113152121;
                public TTReportField NewField113161121;
                public TTReportField MOBILEPHONE;
                public TTReportField NewField1121161311;
                public TTReportField NewField1121161312;
                public TTReportField NewField1121161313;
                public TTReportField NewField1121161314;
                public TTReportField NewField111614;
                public TTReportField NewField1416111;
                public TTReportField NewField11116141;
                public TTReportField NewField114161111;
                public TTReportField YATAK;
                public TTReportField ISLEM_NO13312; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 156;
                    RepeatCount = 0;
                    
                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 9, 46, 13, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Courier New";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Adı Soyadı";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 9, 71, 13, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.TextFont.Name = "Courier New";
                    NewField1251.TextFont.CharSet = 162;
                    NewField1251.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 14, 46, 18, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Name = "Courier New";
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Kimlik No";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 4, 71, 8, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.TextFont.Name = "Courier New";
                    NewField11521.TextFont.CharSet = 162;
                    NewField11521.Value = @":";

                    NewField11531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 14, 71, 18, false);
                    NewField11531.Name = "NewField11531";
                    NewField11531.TextFont.Name = "Courier New";
                    NewField11531.TextFont.CharSet = 162;
                    NewField11531.Value = @":";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 46, 8, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Courier New";
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Hasta İşlem Numarası";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 9, 176, 13, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Courier New";
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @"{#NAME#} {#SURNAME#}";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 14, 176, 18, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.TextFont.Name = "Courier New";
                    KIMLIKNO.TextFont.CharSet = 162;
                    KIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    ISLEM_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 4, 176, 8, false);
                    ISLEM_NO.Name = "ISLEM_NO";
                    ISLEM_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEM_NO.TextFont.Name = "Courier New";
                    ISLEM_NO.TextFont.CharSet = 162;
                    ISLEM_NO.Value = @"";

                    NewField112511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 19, 71, 23, false);
                    NewField112511.Name = "NewField112511";
                    NewField112511.TextFont.Name = "Courier New";
                    NewField112511.TextFont.CharSet = 162;
                    NewField112511.Value = @":";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 19, 46, 23, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Name = "Courier New";
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"Klinik Protokol No";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 19, 176, 23, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Name = "Courier New";
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField112512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 24, 71, 28, false);
                    NewField112512.Name = "NewField112512";
                    NewField112512.TextFont.Name = "Courier New";
                    NewField112512.TextFont.CharSet = 162;
                    NewField112512.Value = @":";

                    NewField111612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 24, 46, 28, false);
                    NewField111612.Name = "NewField111612";
                    NewField111612.TextFont.Name = "Courier New";
                    NewField111612.TextFont.Bold = true;
                    NewField111612.TextFont.CharSet = 162;
                    NewField111612.Value = @"Geldiği Birim";

                    GELDIGI_KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 24, 176, 28, false);
                    GELDIGI_KLINIK.Name = "GELDIGI_KLINIK";
                    GELDIGI_KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELDIGI_KLINIK.TextFont.Name = "Courier New";
                    GELDIGI_KLINIK.TextFont.CharSet = 162;
                    GELDIGI_KLINIK.Value = @"{#GELDIGI_KLINIK#}";

                    NewField112513 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 29, 71, 33, false);
                    NewField112513.Name = "NewField112513";
                    NewField112513.TextFont.Name = "Courier New";
                    NewField112513.TextFont.CharSet = 162;
                    NewField112513.Value = @":";

                    NewField111613 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 29, 46, 33, false);
                    NewField111613.Name = "NewField111613";
                    NewField111613.TextFont.Name = "Courier New";
                    NewField111613.TextFont.Bold = true;
                    NewField111613.TextFont.CharSet = 162;
                    NewField111613.Value = @"Yatış Tanısı";

                    DIAGNOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 29, 176, 37, false);
                    DIAGNOSE.Name = "DIAGNOSE";
                    DIAGNOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSE.TextFont.Name = "Courier New";
                    DIAGNOSE.TextFont.CharSet = 162;
                    DIAGNOSE.Value = @"";

                    NewField1115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 39, 71, 43, false);
                    NewField1115211.Name = "NewField1115211";
                    NewField1115211.TextFont.Name = "Courier New";
                    NewField1115211.TextFont.CharSet = 162;
                    NewField1115211.Value = @":";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 39, 53, 43, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.TextFont.Name = "Courier New";
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"Yattığı Tarih/ Saat";

                    CLINICINPATIENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 39, 176, 43, false);
                    CLINICINPATIENTDATE.Name = "CLINICINPATIENTDATE";
                    CLINICINPATIENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICINPATIENTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    CLINICINPATIENTDATE.TextFont.Name = "Courier New";
                    CLINICINPATIENTDATE.TextFont.CharSet = 162;
                    CLINICINPATIENTDATE.Value = @"{#CLINICINPATIENTDATE#}";

                    NewField1215211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 44, 71, 48, false);
                    NewField1215211.Name = "NewField1215211";
                    NewField1215211.TextFont.Name = "Courier New";
                    NewField1215211.TextFont.CharSet = 162;
                    NewField1215211.Value = @":";

                    NewField1216111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 44, 46, 48, false);
                    NewField1216111.Name = "NewField1216111";
                    NewField1216111.TextFont.Name = "Courier New";
                    NewField1216111.TextFont.Bold = true;
                    NewField1216111.TextFont.CharSet = 162;
                    NewField1216111.Value = @"Klinik Doktoru";

                    PROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 44, 176, 48, false);
                    PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
                    PROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTOR.TextFont.Name = "Courier New";
                    PROCEDUREDOCTOR.TextFont.CharSet = 162;
                    PROCEDUREDOCTOR.Value = @"{#PROCEDUREDOCTOR#}";

                    NewField1315211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 49, 71, 53, false);
                    NewField1315211.Name = "NewField1315211";
                    NewField1315211.TextFont.Name = "Courier New";
                    NewField1315211.TextFont.CharSet = 162;
                    NewField1315211.Value = @":";

                    NewField1316111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 49, 59, 53, false);
                    NewField1316111.Name = "NewField1316111";
                    NewField1316111.TextFont.Name = "Courier New";
                    NewField1316111.TextFont.Bold = true;
                    NewField1316111.TextFont.CharSet = 162;
                    NewField1316111.Value = @"Tedavi Göreceği Klinik";

                    YATTIGI_KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 49, 176, 53, false);
                    YATTIGI_KLINIK.Name = "YATTIGI_KLINIK";
                    YATTIGI_KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATTIGI_KLINIK.TextFont.Name = "Courier New";
                    YATTIGI_KLINIK.TextFont.CharSet = 162;
                    YATTIGI_KLINIK.Value = @"{#YATTIGI_KLINIK#}";

                    NewField1115212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 54, 71, 58, false);
                    NewField1115212.Name = "NewField1115212";
                    NewField1115212.TextFont.Name = "Courier New";
                    NewField1115212.TextFont.CharSet = 162;
                    NewField1115212.Value = @":";

                    NewField1116112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 54, 46, 58, false);
                    NewField1116112.Name = "NewField1116112";
                    NewField1116112.TextFont.Name = "Courier New";
                    NewField1116112.TextFont.Bold = true;
                    NewField1116112.TextFont.CharSet = 162;
                    NewField1116112.Value = @"Hasta Sınıfı";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 54, 176, 58, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.TextFont.Name = "Courier New";
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"";

                    NewField1215212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 59, 71, 63, false);
                    NewField1215212.Name = "NewField1215212";
                    NewField1215212.TextFont.Name = "Courier New";
                    NewField1215212.TextFont.CharSet = 162;
                    NewField1215212.Value = @":";

                    NewField1216112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 59, 46, 63, false);
                    NewField1216112.Name = "NewField1216112";
                    NewField1216112.TextFont.Name = "Courier New";
                    NewField1216112.TextFont.Bold = true;
                    NewField1216112.TextFont.CharSet = 162;
                    NewField1216112.Value = @"Hasta Kurumu";

                    PAYERTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 59, 176, 63, false);
                    PAYERTYPE.Name = "PAYERTYPE";
                    PAYERTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERTYPE.TextFont.Name = "Courier New";
                    PAYERTYPE.TextFont.CharSet = 162;
                    PAYERTYPE.Value = @"";

                    NewField1315213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 72, 71, 76, false);
                    NewField1315213.Name = "NewField1315213";
                    NewField1315213.TextFont.Name = "Courier New";
                    NewField1315213.TextFont.CharSet = 162;
                    NewField1315213.Value = @":";

                    NewField1316113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 72, 46, 76, false);
                    NewField1316113.Name = "NewField1316113";
                    NewField1316113.TextFont.Name = "Courier New";
                    NewField1316113.TextFont.Bold = true;
                    NewField1316113.TextFont.CharSet = 162;
                    NewField1316113.Value = @"Baba Adı";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 72, 176, 76, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.Name = "Courier New";
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    NewField11125111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 77, 71, 81, false);
                    NewField11125111.Name = "NewField11125111";
                    NewField11125111.TextFont.Name = "Courier New";
                    NewField11125111.TextFont.CharSet = 162;
                    NewField11125111.Value = @":";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 77, 46, 81, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.TextFont.Name = "Courier New";
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"Ana Adı";

                    MOTHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 77, 176, 81, false);
                    MOTHERNAME.Name = "MOTHERNAME";
                    MOTHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MOTHERNAME.TextFont.Name = "Courier New";
                    MOTHERNAME.TextFont.CharSet = 162;
                    MOTHERNAME.Value = @"{#MOTHERNAME#}";

                    NewField11125121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 82, 71, 86, false);
                    NewField11125121.Name = "NewField11125121";
                    NewField11125121.TextFont.Name = "Courier New";
                    NewField11125121.TextFont.CharSet = 162;
                    NewField11125121.Value = @":";

                    NewField11116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 82, 46, 86, false);
                    NewField11116121.Name = "NewField11116121";
                    NewField11116121.TextFont.Name = "Courier New";
                    NewField11116121.TextFont.Bold = true;
                    NewField11116121.TextFont.CharSet = 162;
                    NewField11116121.Value = @"Doğduğu Yer";

                    BIRTHPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 82, 176, 86, false);
                    BIRTHPLACE.Name = "BIRTHPLACE";
                    BIRTHPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHPLACE.TextFont.Name = "Courier New";
                    BIRTHPLACE.TextFont.CharSet = 162;
                    BIRTHPLACE.Value = @"{#BIRTHPLACE#}";

                    NewField11125131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 87, 71, 91, false);
                    NewField11125131.Name = "NewField11125131";
                    NewField11125131.TextFont.Name = "Courier New";
                    NewField11125131.TextFont.CharSet = 162;
                    NewField11125131.Value = @":";

                    NewField11116131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 87, 67, 91, false);
                    NewField11116131.Name = "NewField11116131";
                    NewField11116131.TextFont.Name = "Courier New";
                    NewField11116131.TextFont.Bold = true;
                    NewField11116131.TextFont.CharSet = 162;
                    NewField11116131.Value = @"Doğum Yarihi /Yaş /Cinsiyet";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 87, 102, 91, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"dd/MM/yyyy";
                    BIRTHDATE.TextFont.Name = "Courier New";
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{#BIRTHDATE#}";

                    NewField12125111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 92, 71, 96, false);
                    NewField12125111.Name = "NewField12125111";
                    NewField12125111.TextFont.Name = "Courier New";
                    NewField12125111.TextFont.CharSet = 162;
                    NewField12125111.Value = @":";

                    NewField12116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 92, 68, 96, false);
                    NewField12116111.Name = "NewField12116111";
                    NewField12116111.TextFont.Name = "Courier New";
                    NewField12116111.TextFont.Bold = true;
                    NewField12116111.TextFont.CharSet = 162;
                    NewField12116111.Value = @"Yatış Kararı Veren Poliklinik";

                    YATISKARARIVEREN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 92, 176, 96, false);
                    YATISKARARIVEREN.Name = "YATISKARARIVEREN";
                    YATISKARARIVEREN.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISKARARIVEREN.TextFont.Name = "Courier New";
                    YATISKARARIVEREN.TextFont.CharSet = 162;
                    YATISKARARIVEREN.Value = @"{#YATIS_KARARI_VEREN#}";

                    NewField12125121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 97, 71, 101, false);
                    NewField12125121.Name = "NewField12125121";
                    NewField12125121.TextFont.Name = "Courier New";
                    NewField12125121.TextFont.CharSet = 162;
                    NewField12125121.Value = @":";

                    NewField12116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 97, 46, 101, false);
                    NewField12116121.Name = "NewField12116121";
                    NewField12116121.TextFont.Name = "Courier New";
                    NewField12116121.TextFont.Bold = true;
                    NewField12116121.TextFont.CharSet = 162;
                    NewField12116121.Value = @"Oda/Yatak";

                    ODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 97, 117, 101, false);
                    ODA.Name = "ODA";
                    ODA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODA.TextFont.Name = "Courier New";
                    ODA.TextFont.CharSet = 162;
                    ODA.Value = @"{#ODA#}";

                    NewField12125131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 102, 71, 106, false);
                    NewField12125131.Name = "NewField12125131";
                    NewField12125131.TextFont.Name = "Courier New";
                    NewField12125131.TextFont.CharSet = 162;
                    NewField12125131.Value = @":";

                    NewField12116131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 102, 46, 106, false);
                    NewField12116131.Name = "NewField12116131";
                    NewField12116131.TextFont.Name = "Courier New";
                    NewField12116131.TextFont.Bold = true;
                    NewField12116131.TextFont.CharSet = 162;
                    NewField12116131.Value = @"Adres";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 102, 176, 116, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.TextFont.Name = "Courier New";
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"{#HOMEADDRESS#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 87, 138, 91, false);
                    AGE.Name = "AGE";
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Courier New";
                    AGE.TextFont.CharSet = 162;
                    AGE.Value = @"";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 87, 176, 91, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Name = "Courier New";
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"{#SEX#}";

                    ISLEM_NO1133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 87, 107, 91, false);
                    ISLEM_NO1133.Name = "ISLEM_NO1133";
                    ISLEM_NO1133.TextFont.Name = "Courier New";
                    ISLEM_NO1133.TextFont.CharSet = 162;
                    ISLEM_NO1133.Value = @"/";

                    ISLEM_NO13311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 87, 143, 91, false);
                    ISLEM_NO13311.Name = "ISLEM_NO13311";
                    ISLEM_NO13311.TextFont.Name = "Courier New";
                    ISLEM_NO13311.TextFont.CharSet = 162;
                    ISLEM_NO13311.Value = @"/";

                    NewField113152121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 118, 71, 122, false);
                    NewField113152121.Name = "NewField113152121";
                    NewField113152121.TextFont.Name = "Courier New";
                    NewField113152121.TextFont.CharSet = 162;
                    NewField113152121.Value = @":";

                    NewField113161121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 118, 46, 122, false);
                    NewField113161121.Name = "NewField113161121";
                    NewField113161121.TextFont.Name = "Courier New";
                    NewField113161121.TextFont.Bold = true;
                    NewField113161121.TextFont.CharSet = 162;
                    NewField113161121.Value = @"Telefon";

                    MOBILEPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 118, 176, 122, false);
                    MOBILEPHONE.Name = "MOBILEPHONE";
                    MOBILEPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MOBILEPHONE.TextFont.Name = "Courier New";
                    MOBILEPHONE.TextFont.CharSet = 162;
                    MOBILEPHONE.Value = @"{#MOBILEPHONE#}";

                    NewField1121161311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 126, 141, 130, false);
                    NewField1121161311.Name = "NewField1121161311";
                    NewField1121161311.TextFont.Name = "Courier New";
                    NewField1121161311.TextFont.Bold = true;
                    NewField1121161311.TextFont.CharSet = 162;
                    NewField1121161311.Value = @"TETKİK İŞLEMLERİ HAKKINDA BİLGİLENDİRİLDİ";

                    NewField1121161312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 126, 12, 130, false);
                    NewField1121161312.Name = "NewField1121161312";
                    NewField1121161312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121161312.DrawWidth = 2;
                    NewField1121161312.TextFont.Name = "Courier New";
                    NewField1121161312.TextFont.Bold = true;
                    NewField1121161312.TextFont.CharSet = 162;
                    NewField1121161312.Value = @"";

                    NewField1121161313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 132, 141, 136, false);
                    NewField1121161313.Name = "NewField1121161313";
                    NewField1121161313.TextFont.Name = "Courier New";
                    NewField1121161313.TextFont.Bold = true;
                    NewField1121161313.TextFont.CharSet = 162;
                    NewField1121161313.Value = @"HASTALIĞI,TEDAVİSİ VE YAN ETKİLERİ HAKKINDA BİLGİ VERİLDİ";

                    NewField1121161314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 132, 12, 136, false);
                    NewField1121161314.Name = "NewField1121161314";
                    NewField1121161314.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121161314.DrawWidth = 2;
                    NewField1121161314.TextFont.Name = "Courier New";
                    NewField1121161314.TextFont.Bold = true;
                    NewField1121161314.TextFont.CharSet = 162;
                    NewField1121161314.Value = @"";

                    NewField111614 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 138, 141, 142, false);
                    NewField111614.Name = "NewField111614";
                    NewField111614.TextFont.Name = "Courier New";
                    NewField111614.TextFont.Bold = true;
                    NewField111614.TextFont.CharSet = 162;
                    NewField111614.Value = @"SOLUNUM VE DİĞER EGZERSİZLERİ HAKKINDA BİLGİ VERİLDİ";

                    NewField1416111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 144, 141, 148, false);
                    NewField1416111.Name = "NewField1416111";
                    NewField1416111.TextFont.Name = "Courier New";
                    NewField1416111.TextFont.Bold = true;
                    NewField1416111.TextFont.CharSet = 162;
                    NewField1416111.Value = @"AKILCI İLAÇ KULLANIMI HAKKINDA BİLGİ VERİLDİ";

                    NewField11116141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 144, 12, 148, false);
                    NewField11116141.Name = "NewField11116141";
                    NewField11116141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116141.DrawWidth = 2;
                    NewField11116141.TextFont.Name = "Courier New";
                    NewField11116141.TextFont.Bold = true;
                    NewField11116141.TextFont.CharSet = 162;
                    NewField11116141.Value = @"";

                    NewField114161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 138, 12, 142, false);
                    NewField114161111.Name = "NewField114161111";
                    NewField114161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114161111.DrawWidth = 2;
                    NewField114161111.TextFont.Name = "Courier New";
                    NewField114161111.TextFont.Bold = true;
                    NewField114161111.TextFont.CharSet = 162;
                    NewField114161111.Value = @"";

                    YATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 97, 176, 101, false);
                    YATAK.Name = "YATAK";
                    YATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATAK.TextFont.Name = "Courier New";
                    YATAK.TextFont.CharSet = 162;
                    YATAK.Value = @"{#YATAK#}";

                    ISLEM_NO13312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 97, 123, 101, false);
                    ISLEM_NO13312.Name = "ISLEM_NO13312";
                    ISLEM_NO13312.TextFont.Name = "Courier New";
                    ISLEM_NO13312.TextFont.CharSet = 162;
                    ISLEM_NO13312.Value = @"/";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class dataset_GetInpatientAdmissionInfoByTreatmentClinic = ParentGroup.rsGroup.GetCurrentRecord<InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class>(0);
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField11531.CalcValue = NewField11531.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    FULLNAME.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Name) : "") + @" " + (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Surname) : "");
                    KIMLIKNO.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.UniqueRefNo) : "");
                    ISLEM_NO.CalcValue = @"";
                    NewField112511.CalcValue = NewField112511.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    PROTOCOLNO.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.ProtocolNo) : "");
                    NewField112512.CalcValue = NewField112512.Value;
                    NewField111612.CalcValue = NewField111612.Value;
                    GELDIGI_KLINIK.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Geldigi_klinik) : "");
                    NewField112513.CalcValue = NewField112513.Value;
                    NewField111613.CalcValue = NewField111613.Value;
                    DIAGNOSE.CalcValue = @"";
                    NewField1115211.CalcValue = NewField1115211.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    CLINICINPATIENTDATE.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.ClinicInpatientDate) : "");
                    NewField1215211.CalcValue = NewField1215211.Value;
                    NewField1216111.CalcValue = NewField1216111.Value;
                    PROCEDUREDOCTOR.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Proceduredoctor) : "");
                    NewField1315211.CalcValue = NewField1315211.Value;
                    NewField1316111.CalcValue = NewField1316111.Value;
                    YATTIGI_KLINIK.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Yattigi_klinik) : "");
                    NewField1115212.CalcValue = NewField1115212.Value;
                    NewField1116112.CalcValue = NewField1116112.Value;
                    PAYER.CalcValue = @"";
                    NewField1215212.CalcValue = NewField1215212.Value;
                    NewField1216112.CalcValue = NewField1216112.Value;
                    PAYERTYPE.CalcValue = @"";
                    NewField1315213.CalcValue = NewField1315213.Value;
                    NewField1316113.CalcValue = NewField1316113.Value;
                    FATHERNAME.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.FatherName) : "");
                    NewField11125111.CalcValue = NewField11125111.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    MOTHERNAME.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.MotherName) : "");
                    NewField11125121.CalcValue = NewField11125121.Value;
                    NewField11116121.CalcValue = NewField11116121.Value;
                    BIRTHPLACE.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.BirthPlace) : "");
                    NewField11125131.CalcValue = NewField11125131.Value;
                    NewField11116131.CalcValue = NewField11116131.Value;
                    BIRTHDATE.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.BirthDate) : "");
                    NewField12125111.CalcValue = NewField12125111.Value;
                    NewField12116111.CalcValue = NewField12116111.Value;
                    YATISKARARIVEREN.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Yatis_karari_veren) : "");
                    NewField12125121.CalcValue = NewField12125121.Value;
                    NewField12116121.CalcValue = NewField12116121.Value;
                    ODA.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Oda) : "");
                    NewField12125131.CalcValue = NewField12125131.Value;
                    NewField12116131.CalcValue = NewField12116131.Value;
                    ADDRESS.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.HomeAddress) : "");
                    AGE.CalcValue = @"";
                    SEX.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Sex) : "");
                    ISLEM_NO1133.CalcValue = ISLEM_NO1133.Value;
                    ISLEM_NO13311.CalcValue = ISLEM_NO13311.Value;
                    NewField113152121.CalcValue = NewField113152121.Value;
                    NewField113161121.CalcValue = NewField113161121.Value;
                    MOBILEPHONE.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.MobilePhone) : "");
                    NewField1121161311.CalcValue = NewField1121161311.Value;
                    NewField1121161312.CalcValue = NewField1121161312.Value;
                    NewField1121161313.CalcValue = NewField1121161313.Value;
                    NewField1121161314.CalcValue = NewField1121161314.Value;
                    NewField111614.CalcValue = NewField111614.Value;
                    NewField1416111.CalcValue = NewField1416111.Value;
                    NewField11116141.CalcValue = NewField11116141.Value;
                    NewField114161111.CalcValue = NewField114161111.Value;
                    YATAK.CalcValue = (dataset_GetInpatientAdmissionInfoByTreatmentClinic != null ? Globals.ToStringCore(dataset_GetInpatientAdmissionInfoByTreatmentClinic.Yatak) : "");
                    ISLEM_NO13312.CalcValue = ISLEM_NO13312.Value;
                    return new TTReportObject[] { NewField1221,NewField1251,NewField11221,NewField11521,NewField11531,NewField11611,FULLNAME,KIMLIKNO,ISLEM_NO,NewField112511,NewField111611,PROTOCOLNO,NewField112512,NewField111612,GELDIGI_KLINIK,NewField112513,NewField111613,DIAGNOSE,NewField1115211,NewField1116111,CLINICINPATIENTDATE,NewField1215211,NewField1216111,PROCEDUREDOCTOR,NewField1315211,NewField1316111,YATTIGI_KLINIK,NewField1115212,NewField1116112,PAYER,NewField1215212,NewField1216112,PAYERTYPE,NewField1315213,NewField1316113,FATHERNAME,NewField11125111,NewField11116111,MOTHERNAME,NewField11125121,NewField11116121,BIRTHPLACE,NewField11125131,NewField11116131,BIRTHDATE,NewField12125111,NewField12116111,YATISKARARIVEREN,NewField12125121,NewField12116121,ODA,NewField12125131,NewField12116131,ADDRESS,AGE,SEX,ISLEM_NO1133,ISLEM_NO13311,NewField113152121,NewField113161121,MOBILEPHONE,NewField1121161311,NewField1121161312,NewField1121161313,NewField1121161314,NewField111614,NewField1416111,NewField11116141,NewField114161111,YATAK,ISLEM_NO13312};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((InpatientAdmissionInfoByTreatmentClinic)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
            var inPatientTreatmentClinicAppList = InPatientTreatmentClinicApplication.GetByBaseInpatientAdmission(objectContext, objectID);
            if (inPatientTreatmentClinicAppList.Count > 0)
                inPatientTreatmentClinicApp = inPatientTreatmentClinicAppList[0];
            else
                inPatientTreatmentClinicApp = (InPatientTreatmentClinicApplication)objectContext.GetObject(new Guid(objectID), "InPatientTreatmentClinicApplication");

/*            if(inPatientTreatmentClinicApp.ProcedureDoctor!=null)
                this.ISTEKDR.CalcValue = inPatientTreatmentClinicApp.ProcedureDoctor.SignatureBlock; */
            
            if (inPatientTreatmentClinicApp.Episode.Patient.Foreign == true)
                this.KIMLIKNO.CalcValue = inPatientTreatmentClinicApp.Episode.Patient.ForeignUniqueRefNo.ToString();
            else
                this.KIMLIKNO.CalcValue = inPatientTreatmentClinicApp.Episode.Patient.UniqueRefNo.ToString();

            this.AGE.CalcValue = inPatientTreatmentClinicApp.Episode.Patient.Age.ToString();

            foreach (DiagnosisGrid pdG in inPatientTreatmentClinicApp.SubEpisode.Diagnosis)
            {
                    if(!String.IsNullOrEmpty(this.DIAGNOSE.CalcValue))
                        this.DIAGNOSE.CalcValue += "   -   ";
                        if (pdG.Diagnose != null)
                            this.DIAGNOSE.CalcValue += pdG.Diagnose.Code + " " + pdG.Diagnose.Name;
                
            }

            if (inPatientTreatmentClinicApp.SubEpisode != null)
            {
                var sep = inPatientTreatmentClinicApp.SubEpisode.FirstSubEpisodeProtocol;
                if (sep != null)
                {
                    if (sep.Payer != null)
                    {
                        this.PAYER.CalcValue = sep.Payer.Name;
                        if (sep.Payer.Type != null)
                        {
                            this.PAYERTYPE.CalcValue = sep.Payer.Type.Name;
                        }
                    }
                }
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

        public InpatientAdmissionInfoByTreatmentClinic()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INPATIENTADMISSIONINFOBYTREATMENTCLINIC";
            Caption = "Hasta Yatış Formu";
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