
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
    /// Laboratuvar Onaylanmış Sonuçlar Raporu
    /// </summary>
    public partial class LaboratoryOnlyApprovedResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public LaboratoryOnlyApprovedResultReport MyParentReport
            {
                get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField12111111 { get {return Header().NewField12111111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1152 { get {return Header().NewField1152;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField1291 { get {return Header().NewField1291;} }
            public TTReportField NewField11011 { get {return Header().NewField11011;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField12411 { get {return Header().NewField12411;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11712 { get {return Header().NewField11712;} }
            public TTReportField NewField112311 { get {return Header().NewField112311;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField PatientSex { get {return Header().PatientSex;} }
            public TTReportField PatientAge { get {return Header().PatientAge;} }
            public TTReportField PatientFatherName { get {return Header().PatientFatherName;} }
            public TTReportField FromResoure { get {return Header().FromResoure;} }
            public TTReportField PreDiagnosis { get {return Header().PreDiagnosis;} }
            public TTReportField PatientStatus { get {return Header().PatientStatus;} }
            public TTReportField TestAcceptionDate { get {return Header().TestAcceptionDate;} }
            public TTReportField RequestDoctor { get {return Header().RequestDoctor;} }
            public TTReportField NewField11921 { get {return Header().NewField11921;} }
            public TTReportField NewField113311 { get {return Header().NewField113311;} }
            public TTReportField BirthPlace { get {return Header().BirthPlace;} }
            public TTReportField NewField121711 { get {return Header().NewField121711;} }
            public TTReportField NewField1113211 { get {return Header().NewField1113211;} }
            public TTReportField ProtocolNo { get {return Header().ProtocolNo;} }
            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField ApprovedBy { get {return Footer().ApprovedBy;} }
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
                list[0] = new TTReportNqlData<LaboratoryRequest.LaboratoryReportNQL_Class>("LaboratoryReportNQL", LaboratoryRequest.LaboratoryReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public LaboratoryOnlyApprovedResultReport MyParentReport
                {
                    get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField LOGO;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportField NewField11111111;
                public TTReportField NewField12111111;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField NewField1152;
                public TTReportField NewField1162;
                public TTReportField NewField1181;
                public TTReportField NewField1291;
                public TTReportField NewField11011;
                public TTReportField NewField11111;
                public TTReportField NewField1131;
                public TTReportField NewField11211;
                public TTReportField NewField11121;
                public TTReportField NewField11221;
                public TTReportField NewField11431;
                public TTReportField NewField11311;
                public TTReportField NewField12411;
                public TTReportField NewField11511;
                public TTReportField NewField11712;
                public TTReportField NewField112311;
                public TTReportField PatientName;
                public TTReportField PatientSex;
                public TTReportField PatientAge;
                public TTReportField PatientFatherName;
                public TTReportField FromResoure;
                public TTReportField PreDiagnosis;
                public TTReportField PatientStatus;
                public TTReportField TestAcceptionDate;
                public TTReportField RequestDoctor;
                public TTReportField NewField11921;
                public TTReportField NewField113311;
                public TTReportField BirthPlace;
                public TTReportField NewField121711;
                public TTReportField NewField1113211;
                public TTReportField ProtocolNo; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 97;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 30, 174, 37, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"LABORATUVAR ONAYLANMIŞ SONUÇLAR RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 7, 156, 30, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 43, 40, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"LOGO";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 91, 48, 96, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.Underline = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"TEST                                ";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 91, 125, 96, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.TextFont.Size = 11;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.Underline = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"SONUÇ                                        ";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 91, 166, 96, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.TextFont.Name = "Arial Narrow";
                    NewField11111111.TextFont.Size = 11;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.Underline = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"REFERANS                        ";

                    NewField12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 91, 207, 96, false);
                    NewField12111111.Name = "NewField12111111";
                    NewField12111111.TextFont.Name = "Arial Narrow";
                    NewField12111111.TextFont.Size = 11;
                    NewField12111111.TextFont.Bold = true;
                    NewField12111111.TextFont.Underline = true;
                    NewField12111111.TextFont.CharSet = 162;
                    NewField12111111.Value = @"BİRİM                              ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 49, 44, 54, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Hasta Adı";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 54, 44, 59, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Cinsiyet";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 64, 44, 69, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.TextFont.Name = "Arial Narrow";
                    NewField1152.TextFont.Size = 9;
                    NewField1152.TextFont.Bold = true;
                    NewField1152.TextFont.CharSet = 162;
                    NewField1152.Value = @"Hastanın Yaşı";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 44, 74, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.TextFont.Name = "Arial Narrow";
                    NewField1162.TextFont.Size = 9;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"Baba Adı";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 64, 150, 69, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"İstek Yapan Doktor";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 59, 150, 64, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.Name = "Arial Narrow";
                    NewField1291.TextFont.Size = 9;
                    NewField1291.TextFont.Bold = true;
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @"İstek Tarihi";

                    NewField11011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 54, 150, 59, false);
                    NewField11011.Name = "NewField11011";
                    NewField11011.TextFont.Name = "Arial Narrow";
                    NewField11011.TextFont.Size = 9;
                    NewField11011.TextFont.Bold = true;
                    NewField11011.TextFont.CharSet = 162;
                    NewField11011.Value = @"İstek Yapan Birim";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 69, 150, 74, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Ön Tanı";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 49, 47, 54, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 54, 47, 59, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Narrow";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 64, 47, 69, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.TextFont.Name = "Arial Narrow";
                    NewField11121.TextFont.Size = 9;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 69, 47, 74, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 69, 153, 74, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.TextFont.Name = "Arial Narrow";
                    NewField11431.TextFont.Size = 9;
                    NewField11431.TextFont.Bold = true;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @":";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 59, 153, 64, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @":";

                    NewField12411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 64, 153, 69, false);
                    NewField12411.Name = "NewField12411";
                    NewField12411.TextFont.Name = "Arial Narrow";
                    NewField12411.TextFont.Size = 9;
                    NewField12411.TextFont.Bold = true;
                    NewField12411.TextFont.CharSet = 162;
                    NewField12411.Value = @":";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 54, 153, 59, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial Narrow";
                    NewField11511.TextFont.Size = 9;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @":";

                    NewField11712 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 49, 150, 54, false);
                    NewField11712.Name = "NewField11712";
                    NewField11712.TextFont.Name = "Arial Narrow";
                    NewField11712.TextFont.Size = 9;
                    NewField11712.TextFont.Bold = true;
                    NewField11712.TextFont.CharSet = 162;
                    NewField11712.Value = @"Hasta Tipi";

                    NewField112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 49, 153, 54, false);
                    NewField112311.Name = "NewField112311";
                    NewField112311.TextFont.Name = "Arial Narrow";
                    NewField112311.TextFont.Size = 9;
                    NewField112311.TextFont.Bold = true;
                    NewField112311.TextFont.CharSet = 162;
                    NewField112311.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 49, 109, 54, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#} {#SURNAME#}";

                    PatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 54, 109, 59, false);
                    PatientSex.Name = "PatientSex";
                    PatientSex.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSex.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSex.ObjectDefName = "SexEnum";
                    PatientSex.DataMember = "DISPLAYTEXT";
                    PatientSex.TextFont.Name = "Arial Narrow";
                    PatientSex.TextFont.Size = 9;
                    PatientSex.TextFont.CharSet = 162;
                    PatientSex.Value = @"{#SEX#}";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 64, 109, 69, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAge.TextFont.Name = "Arial Narrow";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"PatientAge";

                    PatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 69, 109, 74, false);
                    PatientFatherName.Name = "PatientFatherName";
                    PatientFatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientFatherName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientFatherName.TextFont.Name = "Arial Narrow";
                    PatientFatherName.TextFont.Size = 9;
                    PatientFatherName.TextFont.CharSet = 162;
                    PatientFatherName.Value = @"{#FATHERNAME#}";

                    FromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 54, 214, 59, false);
                    FromResoure.Name = "FromResoure";
                    FromResoure.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResoure.MultiLine = EvetHayirEnum.ehEvet;
                    FromResoure.TextFont.Name = "Arial Narrow";
                    FromResoure.TextFont.Size = 9;
                    FromResoure.TextFont.CharSet = 162;
                    FromResoure.Value = @"{#FROMRES#}";

                    PreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 69, 214, 85, false);
                    PreDiagnosis.Name = "PreDiagnosis";
                    PreDiagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    PreDiagnosis.NoClip = EvetHayirEnum.ehEvet;
                    PreDiagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    PreDiagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreDiagnosis.TextFont.Name = "Arial Narrow";
                    PreDiagnosis.TextFont.Size = 9;
                    PreDiagnosis.TextFont.CharSet = 162;
                    PreDiagnosis.Value = @"PreDiagnosis";

                    PatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 49, 214, 54, false);
                    PatientStatus.Name = "PatientStatus";
                    PatientStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus.TextFormat = @"Long Time";
                    PatientStatus.ObjectDefName = "PatientStatusEnum";
                    PatientStatus.DataMember = "DISPLAYTEXT";
                    PatientStatus.TextFont.Name = "Arial Narrow";
                    PatientStatus.TextFont.Size = 9;
                    PatientStatus.TextFont.CharSet = 162;
                    PatientStatus.Value = @"{#PATIENTSTATUS#}";

                    TestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 59, 214, 64, false);
                    TestAcceptionDate.Name = "TestAcceptionDate";
                    TestAcceptionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TestAcceptionDate.TextFormat = @"Short Date";
                    TestAcceptionDate.TextFont.Name = "Arial Narrow";
                    TestAcceptionDate.TextFont.Size = 9;
                    TestAcceptionDate.TextFont.CharSet = 162;
                    TestAcceptionDate.Value = @"{#ACTDATE#}";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 64, 214, 69, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor.TextFormat = @"dd/mm/yyyy";
                    RequestDoctor.TextFont.Name = "Arial Narrow";
                    RequestDoctor.TextFont.Size = 9;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"{#REQDOCTORNAME#}";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 44, 64, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.TextFont.Name = "Arial Narrow";
                    NewField11921.TextFont.Size = 9;
                    NewField11921.TextFont.Bold = true;
                    NewField11921.TextFont.CharSet = 162;
                    NewField11921.Value = @"Doğum Yeri";

                    NewField113311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 59, 47, 64, false);
                    NewField113311.Name = "NewField113311";
                    NewField113311.TextFont.Name = "Arial Narrow";
                    NewField113311.TextFont.Size = 9;
                    NewField113311.TextFont.Bold = true;
                    NewField113311.TextFont.CharSet = 162;
                    NewField113311.Value = @":";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 59, 109, 64, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlace.TextFormat = @"Long Date";
                    BirthPlace.TextFont.Name = "Arial Narrow";
                    BirthPlace.TextFont.Size = 9;
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"{#CITYNAME#} - {#TOWNNAME#}";

                    NewField121711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 74, 44, 79, false);
                    NewField121711.Name = "NewField121711";
                    NewField121711.TextFont.Name = "Arial Narrow";
                    NewField121711.TextFont.Size = 9;
                    NewField121711.TextFont.Bold = true;
                    NewField121711.TextFont.CharSet = 162;
                    NewField121711.Value = @"Protokol No";

                    NewField1113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 74, 47, 79, false);
                    NewField1113211.Name = "NewField1113211";
                    NewField1113211.TextFont.Name = "Arial Narrow";
                    NewField1113211.TextFont.Size = 9;
                    NewField1113211.TextFont.Bold = true;
                    NewField1113211.TextFont.CharSet = 162;
                    NewField1113211.Value = @":";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 74, 109, 79, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNo.TextFormat = @"Long Time";
                    ProtocolNo.TextFont.Name = "Arial Narrow";
                    ProtocolNo.TextFont.Size = 9;
                    ProtocolNo.TextFont.CharSet = 162;
                    ProtocolNo.Value = @"{#PROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryReportNQL_Class dataset_LaboratoryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField12111111.CalcValue = NewField12111111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1152.CalcValue = NewField1152.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField11011.CalcValue = NewField11011.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField12411.CalcValue = NewField12411.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11712.CalcValue = NewField11712.Value;
                    NewField112311.CalcValue = NewField112311.Value;
                    PatientName.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Patientname) : "") + @" " + (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Surname) : "");
                    PatientSex.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Sex) : "");
                    PatientSex.PostFieldValueCalculation();
                    PatientAge.CalcValue = PatientAge.Value;
                    PatientFatherName.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.FatherName) : "");
                    FromResoure.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Fromres) : "");
                    PreDiagnosis.CalcValue = PreDiagnosis.Value;
                    PatientStatus.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.PatientStatus) : "");
                    PatientStatus.PostFieldValueCalculation();
                    TestAcceptionDate.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Actdate) : "");
                    RequestDoctor.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Reqdoctorname) : "");
                    NewField11921.CalcValue = NewField11921.Value;
                    NewField113311.CalcValue = NewField113311.Value;
                    BirthPlace.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Cityname) : "") + @" - " + (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Townname) : "");
                    NewField121711.CalcValue = NewField121711.Value;
                    NewField1113211.CalcValue = NewField1113211.Value;
                    ProtocolNo.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.ProtocolNo) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField6,LOGO,NewField111111,NewField1111111,NewField11111111,NewField12111111,NewField1121,NewField1141,NewField1152,NewField1162,NewField1181,NewField1291,NewField11011,NewField11111,NewField1131,NewField11211,NewField11121,NewField11221,NewField11431,NewField11311,NewField12411,NewField11511,NewField11712,NewField112311,PatientName,PatientSex,PatientAge,PatientFatherName,FromResoure,PreDiagnosis,PatientStatus,TestAcceptionDate,RequestDoctor,NewField11921,NewField113311,BirthPlace,NewField121711,NewField1113211,ProtocolNo,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((LaboratoryOnlyApprovedResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            this.PatientAge.CalcValue = labObject.Episode.Patient.Age.ToString();
            string preDiagnosis = null;
            
            foreach(DiagnosisGrid dig in labObject.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Primer)
                    preDiagnosis = preDiagnosis + dig.Diagnose.Name.ToString() + ", " ;
            }
            
            this.PreDiagnosis.CalcValue = preDiagnosis;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public LaboratoryOnlyApprovedResultReport MyParentReport
                {
                    get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber;
                public TTReportField NewField1111;
                public TTReportField ApprovedBy; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 36;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 24, 245, 30, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel.TextFont.Name = "Arial Narrow";
                    HizmetOzel.TextFont.Size = 11;
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.TextFont.CharSet = 162;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 23, 207, 23, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 35, 29, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 24, 126, 29, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 24, 210, 29, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 1, 207, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Onaylayan Uzman";

                    ApprovedBy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 7, 207, 22, false);
                    ApprovedBy.Name = "ApprovedBy";
                    ApprovedBy.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ApprovedBy.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedBy.NoClip = EvetHayirEnum.ehEvet;
                    ApprovedBy.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedBy.ObjectDefName = "LaboratoryRequest";
                    ApprovedBy.DataMember = "APPROVEDBY.NAME";
                    ApprovedBy.TextFont.Name = "Arial Narrow";
                    ApprovedBy.TextFont.Size = 11;
                    ApprovedBy.TextFont.CharSet = 162;
                    ApprovedBy.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryReportNQL_Class dataset_LaboratoryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryReportNQL_Class>(0);
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField1111.CalcValue = NewField1111.Value;
                    ApprovedBy.CalcValue = ApprovedBy.Value;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel,PrintDate,PageNumber,NewField1111,ApprovedBy,UserName};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((LaboratoryOnlyApprovedResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            
            ResUser approvedBy = labObject.ApprovedBy;
  
            string CrLf = "\r\n";
            string TextContext = "";
            string Title = "";
            string Sicil = "";
            string Rank = "";
                        
            //ApprovedBy
            if(approvedBy != null)
            {
                Title = !approvedBy.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(approvedBy.Title.Value);
                Sicil = approvedBy.EmploymentRecordID;
                Rank = approvedBy.Rank == null ? "" : approvedBy.Rank.Name;
                TextContext = approvedBy.Name + CrLf + Title + " " + Rank + "(" + Sicil + ")" + CrLf ;
                this.ApprovedBy.CalcValue = TextContext;
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class PARENTGroup : TTReportGroup
        {
            public LaboratoryOnlyApprovedResultReport MyParentReport
            {
                get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
            }

            new public PARENTGroupHeader Header()
            {
                return (PARENTGroupHeader)_header;
            }

            new public PARENTGroupFooter Footer()
            {
                return (PARENTGroupFooter)_footer;
            }

            public TTReportField LaboratoryProcedureTestName { get {return Header().LaboratoryProcedureTestName;} }
            public TTReportField Result { get {return Header().Result;} }
            public TTReportField Reference { get {return Header().Reference;} }
            public TTReportField Unit { get {return Header().Unit;} }
            public TTReportField OBJID { get {return Header().OBJID;} }
            public TTReportRTF LongReportRTF { get {return Footer().LongReportRTF;} }
            public PARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>("GetOnlyApprovedProcedures", LaboratoryProcedure.GetOnlyApprovedProcedures((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGroupHeader(this);
                _footer = new PARENTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARENTGroupHeader : TTReportSection
            {
                public LaboratoryOnlyApprovedResultReport MyParentReport
                {
                    get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
                }
                
                public TTReportField LaboratoryProcedureTestName;
                public TTReportField Result;
                public TTReportField Reference;
                public TTReportField Unit;
                public TTReportField OBJID; 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LaboratoryProcedureTestName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 82, 5, false);
                    LaboratoryProcedureTestName.Name = "LaboratoryProcedureTestName";
                    LaboratoryProcedureTestName.FieldType = ReportFieldTypeEnum.ftVariable;
                    LaboratoryProcedureTestName.TextFont.Name = "Arial Narrow";
                    LaboratoryProcedureTestName.TextFont.CharSet = 162;
                    LaboratoryProcedureTestName.Value = @"{#NAME#}";

                    Result = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 126, 5, false);
                    Result.Name = "Result";
                    Result.FieldType = ReportFieldTypeEnum.ftVariable;
                    Result.TextFont.Name = "Arial Narrow";
                    Result.TextFont.CharSet = 162;
                    Result.Value = @"{#RESULT#}";

                    Reference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 167, 5, false);
                    Reference.Name = "Reference";
                    Reference.FieldType = ReportFieldTypeEnum.ftVariable;
                    Reference.TextFont.Name = "Arial Narrow";
                    Reference.TextFont.CharSet = 162;
                    Reference.Value = @"{#REFERENCE#}";

                    Unit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 208, 5, false);
                    Unit.Name = "Unit";
                    Unit.FieldType = ReportFieldTypeEnum.ftVariable;
                    Unit.TextFont.Name = "Arial Narrow";
                    Unit.TextFont.CharSet = 162;
                    Unit.Value = @"{#UNIT#}";

                    OBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 2, 257, 7, false);
                    OBJID.Name = "OBJID";
                    OBJID.Visible = EvetHayirEnum.ehHayir;
                    OBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJID.TextFont.Name = "Arial Narrow";
                    OBJID.TextFont.Size = 11;
                    OBJID.TextFont.CharSet = 162;
                    OBJID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryProcedure.GetOnlyApprovedProcedures_Class dataset_GetOnlyApprovedProcedures = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>(0);
                    LaboratoryProcedureTestName.CalcValue = (dataset_GetOnlyApprovedProcedures != null ? Globals.ToStringCore(dataset_GetOnlyApprovedProcedures.Name) : "");
                    Result.CalcValue = (dataset_GetOnlyApprovedProcedures != null ? Globals.ToStringCore(dataset_GetOnlyApprovedProcedures.Result) : "");
                    Reference.CalcValue = (dataset_GetOnlyApprovedProcedures != null ? Globals.ToStringCore(dataset_GetOnlyApprovedProcedures.Reference) : "");
                    Unit.CalcValue = (dataset_GetOnlyApprovedProcedures != null ? Globals.ToStringCore(dataset_GetOnlyApprovedProcedures.Unit) : "");
                    OBJID.CalcValue = (dataset_GetOnlyApprovedProcedures != null ? Globals.ToStringCore(dataset_GetOnlyApprovedProcedures.ObjectID) : "");
                    return new TTReportObject[] { LaboratoryProcedureTestName,Result,Reference,Unit,OBJID};
                }
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public LaboratoryOnlyApprovedResultReport MyParentReport
                {
                    get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
                }
                
                public TTReportRTF LongReportRTF; 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                    LongReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 0, 210, 1, false);
                    LongReportRTF.Name = "LongReportRTF";
                    LongReportRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryProcedure.GetOnlyApprovedProcedures_Class dataset_GetOnlyApprovedProcedures = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryProcedure.GetOnlyApprovedProcedures_Class>(0);
                    LongReportRTF.CalcValue = LongReportRTF.Value;
                    return new TTReportObject[] { LongReportRTF};
                }
                public override void RunPreScript()
                {
#region PARENT FOOTER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((LaboratoryOnlyApprovedResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            if(objectID != null)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
                if(laboratoryProcedure.LongReport != null)
                    this.LongReportRTF.Value = laboratoryProcedure.LongReport.ToString();
            }
#endregion PARENT FOOTER_PreScript
                }
            }

        }

        public PARENTGroup PARENT;

        public partial class MAINGroup : TTReportGroup
        {
            public LaboratoryOnlyApprovedResultReport MyParentReport
            {
                get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField LaboratorySubProcedureObjectName { get {return Body().LaboratorySubProcedureObjectName;} }
            public TTReportField SubResult { get {return Body().SubResult;} }
            public TTReportField SubReference { get {return Body().SubReference;} }
            public TTReportField SubUnit { get {return Body().SubUnit;} }
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
                list[0] = new TTReportNqlData<LaboratorySubProcedure.LabSubProcedureReportNQL_Class>("LabSubProcedureReportNQL", LaboratorySubProcedure.LabSubProcedureReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.PARENT.OBJID.CalcValue)));
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
                public LaboratoryOnlyApprovedResultReport MyParentReport
                {
                    get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
                }
                
                public TTReportField LaboratorySubProcedureObjectName;
                public TTReportField SubResult;
                public TTReportField SubReference;
                public TTReportField SubUnit; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    LaboratorySubProcedureObjectName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 85, 5, false);
                    LaboratorySubProcedureObjectName.Name = "LaboratorySubProcedureObjectName";
                    LaboratorySubProcedureObjectName.FieldType = ReportFieldTypeEnum.ftVariable;
                    LaboratorySubProcedureObjectName.TextFont.Name = "Arial Narrow";
                    LaboratorySubProcedureObjectName.TextFont.CharSet = 162;
                    LaboratorySubProcedureObjectName.Value = @"{#NAME#}";

                    SubResult = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 127, 5, false);
                    SubResult.Name = "SubResult";
                    SubResult.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubResult.TextFont.Name = "Arial Narrow";
                    SubResult.TextFont.CharSet = 162;
                    SubResult.Value = @"{#RESULT#}";

                    SubReference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 169, 5, false);
                    SubReference.Name = "SubReference";
                    SubReference.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubReference.TextFont.Name = "Arial Narrow";
                    SubReference.TextFont.CharSet = 162;
                    SubReference.Value = @"{#REFERENCE#}";

                    SubUnit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 0, 210, 5, false);
                    SubUnit.Name = "SubUnit";
                    SubUnit.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubUnit.TextFont.Name = "Arial Narrow";
                    SubUnit.TextFont.CharSet = 162;
                    SubUnit.Value = @"{#UNIT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratorySubProcedure.LabSubProcedureReportNQL_Class dataset_LabSubProcedureReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratorySubProcedure.LabSubProcedureReportNQL_Class>(0);
                    LaboratorySubProcedureObjectName.CalcValue = (dataset_LabSubProcedureReportNQL != null ? Globals.ToStringCore(dataset_LabSubProcedureReportNQL.Name) : "");
                    SubResult.CalcValue = (dataset_LabSubProcedureReportNQL != null ? Globals.ToStringCore(dataset_LabSubProcedureReportNQL.Result) : "");
                    SubReference.CalcValue = (dataset_LabSubProcedureReportNQL != null ? Globals.ToStringCore(dataset_LabSubProcedureReportNQL.Reference) : "");
                    SubUnit.CalcValue = (dataset_LabSubProcedureReportNQL != null ? Globals.ToStringCore(dataset_LabSubProcedureReportNQL.Unit) : "");
                    return new TTReportObject[] { LaboratorySubProcedureObjectName,SubResult,SubReference,SubUnit};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    //TTObjectContext context = new TTObjectContext(true);
            //string sObjectID = ((LaboratoryResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //LaboratoryRequest laboratoryRequest = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            //this.ReportRTF.Value = laboratoryRequest.Report;
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        public partial class REFERENCEGroup : TTReportGroup
        {
            public LaboratoryOnlyApprovedResultReport MyParentReport
            {
                get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
            }

            new public REFERENCEGroupBody Body()
            {
                return (REFERENCEGroupBody)_body;
            }
            public TTReportRTF SpecialRefer { get {return Body().SpecialRefer;} }
            public REFERENCEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REFERENCEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new REFERENCEGroupBody(this);
            }

            public partial class REFERENCEGroupBody : TTReportSection
            {
                public LaboratoryOnlyApprovedResultReport MyParentReport
                {
                    get { return (LaboratoryOnlyApprovedResultReport)ParentReport; }
                }
                
                public TTReportRTF SpecialRefer; 
                public REFERENCEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                    SpecialRefer = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 87, 0, 210, 1, false);
                    SpecialRefer.Name = "SpecialRefer";
                    SpecialRefer.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SpecialRefer.CalcValue = SpecialRefer.Value;
                    return new TTReportObject[] { SpecialRefer};
                }
                public override void RunPreScript()
                {
#region REFERENCE BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((LaboratoryOnlyApprovedResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            if(objectID != null)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
                if(laboratoryProcedure.SpecialReference != null)
                    this.SpecialRefer.Value = laboratoryProcedure.SpecialReference.ToString();
            }
#endregion REFERENCE BODY_PreScript
                }
            }

        }

        public REFERENCEGroup REFERENCE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public LaboratoryOnlyApprovedResultReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARENT = new PARENTGroup(HEADER,"PARENT");
            MAIN = new MAINGroup(PARENT,"MAIN");
            REFERENCE = new REFERENCEGroup(PARENT,"REFERENCE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protokol No", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f1afb241-e28f-4f1a-84a3-e7fe12256626");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "LABORATORYONLYAPPROVEDRESULTREPORT";
            Caption = "Laboratuvar Onaylanmış Sonuçlar Raporu";
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