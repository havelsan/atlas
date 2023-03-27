
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
    /// Patoloji Sonuç Raporu
    /// </summary>
    public partial class PathologyResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField UniqueRefNo { get {return Header().UniqueRefNo;} }
            public TTReportField PatientSex { get {return Header().PatientSex;} }
            public TTReportField PatientAge { get {return Header().PatientAge;} }
            public TTReportField PatientFatherName { get {return Header().PatientFatherName;} }
            public TTReportField FromResoure { get {return Header().FromResoure;} }
            public TTReportField PreDiagnosis { get {return Header().PreDiagnosis;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public TTReportField PatientStatus { get {return Header().PatientStatus;} }
            public TTReportField TestAcceptionDate { get {return Header().TestAcceptionDate;} }
            public TTReportField TestReqDate { get {return Header().TestReqDate;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField BirthPlace { get {return Header().BirthPlace;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField142 { get {return Footer().NewField142;} }
            public TTReportField NewField25 { get {return Footer().NewField25;} }
            public TTReportField ReportDate { get {return Footer().ReportDate;} }
            public TTReportField SpecialDoctor { get {return Footer().SpecialDoctor;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField ResponsibleDoctor1 { get {return Footer().ResponsibleDoctor1;} }
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
                list[0] = new TTReportNqlData<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>("PathologyResultPatientInfoReportQuery", PathologyRequest.PathologyResultPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField3;
                public TTReportField NewField12;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField17;
                public TTReportField NewField132;
                public TTReportField NewField16;
                public TTReportField NewField18;
                public TTReportField PatientName;
                public TTReportField UniqueRefNo;
                public TTReportField PatientSex;
                public TTReportField PatientAge;
                public TTReportField PatientFatherName;
                public TTReportField FromResoure;
                public TTReportField PreDiagnosis;
                public TTReportField BirthDate;
                public TTReportField PatientStatus;
                public TTReportField TestAcceptionDate;
                public TTReportField TestReqDate;
                public TTReportField NewField19;
                public TTReportField NewField133;
                public TTReportField BirthPlace; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 75;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 27, 147, 34, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"PATOLOJİ SONUÇ RAPORU";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 37, 36, 42, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Hasta Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 47, 36, 52, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Cinsiyet";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 52, 36, 57, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Hastanın Yaşı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 57, 36, 62, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Baba Adı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 37, 150, 42, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Doğum Tarihi";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 52, 150, 57, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Tetkik Kabul Tarihi";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 57, 150, 62, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Tetkik İstek Tarihi";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 62, 36, 67, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Gönderen Klinik";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 67, 36, 72, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ön Tanı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 37, 39, 42, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 47, 39, 52, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 52, 39, 57, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Size = 9;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 57, 39, 62, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial";
                    NewField22.TextFont.Size = 9;
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 37, 153, 42, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Name = "Arial";
                    NewField23.TextFont.Size = 9;
                    NewField23.TextFont.CharSet = 162;
                    NewField23.Value = @":";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 67, 39, 72, false);
                    NewField24.Name = "NewField24";
                    NewField24.TextFont.Name = "Arial";
                    NewField24.TextFont.Size = 9;
                    NewField24.TextFont.CharSet = 162;
                    NewField24.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 52, 153, 57, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 57, 153, 62, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 62, 39, 67, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 8, 147, 27, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 15;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 47, 150, 52, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Hasta Tipi";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 47, 153, 52, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Size = 9;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 42, 36, 47, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"TC Kimlik No";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 42, 39, 47, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 37, 102, 42, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.TextFont.Name = "Arial";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    UniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 42, 102, 47, false);
                    UniqueRefNo.Name = "UniqueRefNo";
                    UniqueRefNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    UniqueRefNo.TextFont.Name = "Arial";
                    UniqueRefNo.TextFont.Size = 9;
                    UniqueRefNo.TextFont.CharSet = 162;
                    UniqueRefNo.Value = @"{#UNIQUEREFNO#}";

                    PatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 47, 102, 52, false);
                    PatientSex.Name = "PatientSex";
                    PatientSex.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSex.TextFont.Name = "Arial";
                    PatientSex.TextFont.Size = 9;
                    PatientSex.TextFont.CharSet = 162;
                    PatientSex.Value = @"{#SEX#}";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 52, 102, 57, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.TextFont.Name = "Arial";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"PatientAge";

                    PatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 57, 102, 62, false);
                    PatientFatherName.Name = "PatientFatherName";
                    PatientFatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientFatherName.TextFont.Name = "Arial";
                    PatientFatherName.TextFont.Size = 9;
                    PatientFatherName.TextFont.CharSet = 162;
                    PatientFatherName.Value = @"{#FATHERNAME#}";

                    FromResoure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 62, 214, 67, false);
                    FromResoure.Name = "FromResoure";
                    FromResoure.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResoure.TextFont.Name = "Arial";
                    FromResoure.TextFont.Size = 9;
                    FromResoure.TextFont.CharSet = 162;
                    FromResoure.Value = @"{#FROMRES#}";

                    PreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 67, 214, 72, false);
                    PreDiagnosis.Name = "PreDiagnosis";
                    PreDiagnosis.TextFont.Name = "Arial";
                    PreDiagnosis.TextFont.Size = 9;
                    PreDiagnosis.TextFont.CharSet = 162;
                    PreDiagnosis.Value = @"PreDiagnosis";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 37, 214, 42, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthDate.TextFormat = @"Long Date";
                    BirthDate.TextFont.Name = "Arial";
                    BirthDate.TextFont.Size = 9;
                    BirthDate.TextFont.CharSet = 162;
                    BirthDate.Value = @"{#BIRTHDATE#}";

                    PatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 47, 214, 52, false);
                    PatientStatus.Name = "PatientStatus";
                    PatientStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus.TextFormat = @"Long Time";
                    PatientStatus.ObjectDefName = "PatientStatusEnum";
                    PatientStatus.DataMember = "DISPLAYTEXT";
                    PatientStatus.TextFont.Name = "Arial";
                    PatientStatus.TextFont.Size = 9;
                    PatientStatus.TextFont.CharSet = 162;
                    PatientStatus.Value = @"{#PATIENTSTATUS#}";

                    TestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 52, 214, 57, false);
                    TestAcceptionDate.Name = "TestAcceptionDate";
                    TestAcceptionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TestAcceptionDate.TextFormat = @"dd/mm/yyyy";
                    TestAcceptionDate.TextFont.Name = "Arial";
                    TestAcceptionDate.TextFont.Size = 9;
                    TestAcceptionDate.TextFont.CharSet = 162;
                    TestAcceptionDate.Value = @"{#ACCEPTDATE#}";

                    TestReqDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 57, 214, 62, false);
                    TestReqDate.Name = "TestReqDate";
                    TestReqDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TestReqDate.TextFormat = @"dd/mm/yyyy";
                    TestReqDate.TextFont.Name = "Arial";
                    TestReqDate.TextFont.Size = 9;
                    TestReqDate.TextFont.CharSet = 162;
                    TestReqDate.Value = @"{#ACTDATE#}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 42, 150, 47, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Doğum Yeri";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 42, 153, 47, false);
                    NewField133.Name = "NewField133";
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Size = 9;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @":";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 42, 214, 47, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlace.TextFormat = @"Long Date";
                    BirthPlace.TextFont.Name = "Arial";
                    BirthPlace.TextFont.Size = 9;
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"{#CITYNAME#} - {#TOWNNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultPatientInfoReportQuery_Class dataset_PathologyResultPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField18.CalcValue = NewField18.Value;
                    PatientName.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Name) : "") + @" " + (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Surname) : "");
                    UniqueRefNo.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.UniqueRefNo) : "");
                    PatientSex.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Sex) : "");
                    PatientAge.CalcValue = PatientAge.Value;
                    PatientFatherName.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.FatherName) : "");
                    FromResoure.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Fromres) : "");
                    PreDiagnosis.CalcValue = PreDiagnosis.Value;
                    BirthDate.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.BirthDate) : "");
                    PatientStatus.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.PatientStatus) : "");
                    PatientStatus.PostFieldValueCalculation();
                    TestAcceptionDate.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Acceptdate) : "");
                    TestReqDate.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Actdate) : "");
                    NewField19.CalcValue = NewField19.Value;
                    NewField133.CalcValue = NewField133.Value;
                    BirthPlace.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Cityname) : "") + @" - " + (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Townname) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField,NewField2,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,NewField11,NewField3,NewField12,NewField21,NewField22,NewField23,NewField24,NewField13,NewField14,NewField15,NewField17,NewField132,NewField16,NewField18,PatientName,UniqueRefNo,PatientSex,PatientAge,PatientFatherName,FromResoure,PreDiagnosis,BirthDate,PatientStatus,TestAcceptionDate,TestReqDate,NewField19,NewField133,BirthPlace,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);    
            string sObjectID = ((PathologyResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PathologyRequest pObject = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
            string preDiagnosis = null;
            
            foreach(DiagnosisGrid dig in pObject.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Primer)
                    preDiagnosis = preDiagnosis + dig.Diagnose.Name.ToString() + ", " ;
            }            
            
            this.PreDiagnosis.CalcValue = preDiagnosis;
            this.PatientAge.CalcValue = pObject.Episode.Patient.Age.ToString();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField142;
                public TTReportField NewField25;
                public TTReportField ReportDate;
                public TTReportField SpecialDoctor;
                public TTReportField NewField191;
                public TTReportField NewField1141;
                public TTReportField ResponsibleDoctor1; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 3, 27, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor Tarihi";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 3, 30, 8, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Name = "Arial";
                    NewField142.TextFont.Size = 9;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @":";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 14, 174, 19, false);
                    NewField25.Name = "NewField25";
                    NewField25.TextFont.Name = "Arial";
                    NewField25.TextFont.Size = 9;
                    NewField25.TextFont.Bold = true;
                    NewField25.TextFont.CharSet = 162;
                    NewField25.Value = @"UZMAN DOKTOR";

                    ReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 3, 80, 8, false);
                    ReportDate.Name = "ReportDate";
                    ReportDate.TextFormat = @"dd/mm/yyyy";
                    ReportDate.TextFont.Name = "Arial";
                    ReportDate.TextFont.Size = 9;
                    ReportDate.TextFont.CharSet = 162;
                    ReportDate.Value = @"";

                    SpecialDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 20, 208, 25, false);
                    SpecialDoctor.Name = "SpecialDoctor";
                    SpecialDoctor.TextFormat = @"Long Date";
                    SpecialDoctor.TextFont.Name = "Arial";
                    SpecialDoctor.TextFont.Size = 9;
                    SpecialDoctor.TextFont.CharSet = 162;
                    SpecialDoctor.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 14, 27, 19, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Sorumlu Doktor";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 14, 30, 19, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    ResponsibleDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 20, 80, 25, false);
                    ResponsibleDoctor1.Name = "ResponsibleDoctor1";
                    ResponsibleDoctor1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleDoctor1.TextFormat = @"dd/mm/yyyy";
                    ResponsibleDoctor1.TextFont.Name = "Arial";
                    ResponsibleDoctor1.TextFont.Size = 9;
                    ResponsibleDoctor1.TextFont.CharSet = 162;
                    ResponsibleDoctor1.Value = @"{#SORUMLUDOKTOR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultPatientInfoReportQuery_Class dataset_PathologyResultPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField25.CalcValue = NewField25.Value;
                    ReportDate.CalcValue = ReportDate.Value;
                    SpecialDoctor.CalcValue = SpecialDoctor.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    ResponsibleDoctor1.CalcValue = (dataset_PathologyResultPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_PathologyResultPatientInfoReportQuery.Sorumludoktor) : "");
                    return new TTReportObject[] { NewField1,NewField142,NewField25,ReportDate,SpecialDoctor,NewField191,NewField1141,ResponsibleDoctor1};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyTestResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            this.SpecialDoctor.CalcValue = pObject.SpecialDoctor != null ? pObject.SpecialDoctor.ToString() : String.Empty;
            this.ReportDate.CalcValue = DateTime.Now.ToString();
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF RepMacroscopy { get {return Body().RepMacroscopy;} }
            public TTReportField NewField { get {return Body().NewField;} }
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
                list[0] = new TTReportNqlData<PathologyRequest.PathologyResultReportQuery_Class>("PathologyResultReportQuery", PathologyRequest.PathologyResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportRTF RepMacroscopy;
                public TTReportField NewField; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    RepMacroscopy = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 2, 7, 213, 12, false);
                    RepMacroscopy.Name = "RepMacroscopy";
                    RepMacroscopy.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 30, 6, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 11;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"MAKROSKOPİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultReportQuery_Class dataset_PathologyResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultReportQuery_Class>(0);
                    RepMacroscopy.CalcValue = RepMacroscopy.Value;
                    NewField.CalcValue = NewField.Value;
                    return new TTReportObject[] { RepMacroscopy,NewField};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PathologyRequest pObject = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
            //if(pObject.ReportMacroscopi != null)
            //    this.RepMacroscopy.CalcValue = pObject.ReportMacroscopi.ToString();
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MikroskopiGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public MikroskopiGroupBody Body()
            {
                return (MikroskopiGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportRTF RepMicroscopy { get {return Body().RepMicroscopy;} }
            public MikroskopiGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MikroskopiGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyRequest.PathologyResultReportQuery_Class>("PathologyResultReportQuery", PathologyRequest.PathologyResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MikroskopiGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MikroskopiGroupBody : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportRTF RepMicroscopy; 
                public MikroskopiGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 29, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"MİKROSKOPİ";

                    RepMicroscopy = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 2, 7, 213, 12, false);
                    RepMicroscopy.Name = "RepMicroscopy";
                    RepMicroscopy.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultReportQuery_Class dataset_PathologyResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultReportQuery_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    RepMicroscopy.CalcValue = RepMicroscopy.Value;
                    return new TTReportObject[] { NewField11,RepMicroscopy};
                }

                public override void RunScript()
                {
#region MIKROSKOPI BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PathologyRequest pObject = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
            //if(pObject.ReportMicroscopi != null)
            //    this.RepMicroscopy.CalcValue = pObject.ReportMicroscopi.ToString();
#endregion MIKROSKOPI BODY_Script
                }
            }

        }

        public MikroskopiGroup Mikroskopi;

        public partial class DokuIslemGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public DokuIslemGroupBody Body()
            {
                return (DokuIslemGroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportRTF RepTissueProc { get {return Body().RepTissueProc;} }
            public DokuIslemGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DokuIslemGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyRequest.PathologyResultReportQuery_Class>("PathologyResultReportQuery", PathologyRequest.PathologyResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DokuIslemGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DokuIslemGroupBody : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportRTF RepTissueProc; 
                public DokuIslemGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 2, 31, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"DOKU İŞLEMİ";

                    RepTissueProc = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 2, 8, 213, 13, false);
                    RepTissueProc.Name = "RepTissueProc";
                    RepTissueProc.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultReportQuery_Class dataset_PathologyResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultReportQuery_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    RepTissueProc.CalcValue = RepTissueProc.Value;
                    return new TTReportObject[] { NewField12,RepTissueProc};
                }

                public override void RunScript()
                {
#region DOKUISLEM BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PathologyRequest pObject = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
           // if(pObject.ReportTissueProcedure != null)
           //     this.RepTissueProc.CalcValue = pObject.ReportTissueProcedure.ToString();
#endregion DOKUISLEM BODY_Script
                }
            }

        }

        public DokuIslemGroup DokuIslem;

        public partial class EkIslemlerGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public EkIslemlerGroupBody Body()
            {
                return (EkIslemlerGroupBody)_body;
            }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportRTF RepAddProc { get {return Body().RepAddProc;} }
            public EkIslemlerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public EkIslemlerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyRequest.PathologyResultReportQuery_Class>("PathologyResultReportQuery", PathologyRequest.PathologyResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new EkIslemlerGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class EkIslemlerGroupBody : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportRTF RepAddProc; 
                public EkIslemlerGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 30, 6, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"EK İŞLEMLER";

                    RepAddProc = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 2, 7, 213, 11, false);
                    RepAddProc.Name = "RepAddProc";
                    RepAddProc.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultReportQuery_Class dataset_PathologyResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultReportQuery_Class>(0);
                    NewField13.CalcValue = NewField13.Value;
                    RepAddProc.CalcValue = RepAddProc.Value;
                    return new TTReportObject[] { NewField13,RepAddProc};
                }

                public override void RunScript()
                {
#region EKISLEMLER BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PathologyRequest pObject = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
            //if(pObject.ReportAdditionalOperation != null)
            //    this.RepAddProc.CalcValue = pObject.ReportAdditionalOperation.ToString();
#endregion EKISLEMLER BODY_Script
                }
            }

        }

        public EkIslemlerGroup EkIslemler;

        public partial class TaniGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public TaniGroupBody Body()
            {
                return (TaniGroupBody)_body;
            }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportRTF RepDiagnosis { get {return Body().RepDiagnosis;} }
            public TaniGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TaniGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyRequest.PathologyResultReportQuery_Class>("PathologyResultReportQuery", PathologyRequest.PathologyResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TaniGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TaniGroupBody : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportRTF RepDiagnosis; 
                public TaniGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 27, 6, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"TANI";

                    RepDiagnosis = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 2, 7, 213, 12, false);
                    RepDiagnosis.Name = "RepDiagnosis";
                    RepDiagnosis.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyResultReportQuery_Class dataset_PathologyResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyResultReportQuery_Class>(0);
                    NewField14.CalcValue = NewField14.Value;
                    RepDiagnosis.CalcValue = RepDiagnosis.Value;
                    return new TTReportObject[] { NewField14,RepDiagnosis};
                }

                public override void RunScript()
                {
#region TANI BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PathologyRequest pObject = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
            //this.RepDiagnosis.CalcValue  = pObject.ReportDiagnoseComment;
#endregion TANI BODY_Script
                }
            }

        }

        public TaniGroup Tani;

        public partial class PROCEDURESGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public PROCEDURESGroupBody Body()
            {
                return (PROCEDURESGroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField CATEGORY { get {return Body().CATEGORY;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public PROCEDURESGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCEDURESGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Pathology.PathologyTestReportQuery_Class>("PathologyTestsReportQuery", Pathology.PathologyTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PROCEDURESGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PROCEDURESGroupBody : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField CATEGORY;
                public TTReportField PROTOCOLNO;
                public TTReportField CODE;
                public TTReportField NAME; 
                public PROCEDURESGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 30, 6, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Yapılan Tetkik(ler)";

                    CATEGORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 6, 103, 11, false);
                    CATEGORY.Name = "CATEGORY";
                    CATEGORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    CATEGORY.TextFont.Name = "Arial";
                    CATEGORY.TextFont.Size = 9;
                    CATEGORY.TextFont.CharSet = 162;
                    CATEGORY.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 6, 38, 11, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.Size = 14;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 6, 68, 11, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial";
                    CODE.TextFont.Size = 9;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 7, 213, 12, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestReportQuery_Class dataset_PathologyTestsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestReportQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    CATEGORY.CalcValue = @"";
                    PROTOCOLNO.CalcValue = @"";
                    CODE.CalcValue = @"";
                    NAME.CalcValue = @"";
                    return new TTReportObject[] { NewField,CATEGORY,PROTOCOLNO,CODE,NAME};
                }
            }

        }

        public PROCEDURESGroup PROCEDURES;

        public partial class FOOTERGroup : TTReportGroup
        {
            public PathologyResultReport MyParentReport
            {
                get { return (PathologyResultReport)ParentReport; }
            }

            new public FOOTERGroupBody Body()
            {
                return (FOOTERGroupBody)_body;
            }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField PrintDate11 { get {return Body().PrintDate11;} }
            public TTReportField UserName11 { get {return Body().UserName11;} }
            public TTReportField PageNumber11 { get {return Body().PageNumber11;} }
            public FOOTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FOOTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FOOTERGroupBody(this);
            }

            public partial class FOOTERGroupBody : TTReportSection
            {
                public PathologyResultReport MyParentReport
                {
                    get { return (PathologyResultReport)ParentReport; }
                }
                
                public TTReportField NewField102;
                public TTReportField NewField162;
                public TTReportShape NewLine11;
                public TTReportField PrintDate11;
                public TTReportField UserName11;
                public TTReportField PageNumber11; 
                public FOOTERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    AutoSizeGap = 1;
                    RepeatCount = 2;
                    RepeatWidth = 1;
                    
                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 165, 9, false);
                    NewField102.Name = "NewField102";
                    NewField102.TextFont.Name = "Arial";
                    NewField102.TextFont.Size = 9;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"Bu rapor hasta tedavisi ve dosyası için düzenlenmiştir. İzinsiz olarak bilimsel yayın amacı ile kullanılamaz.";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 4, 10, 9, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Name = "Arial";
                    NewField162.TextFont.Size = 9;
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"Not :";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 12, 199, 12, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 13, 27, 18, false);
                    PrintDate11.Name = "PrintDate11";
                    PrintDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate11.TextFont.Name = "Arial Narrow";
                    PrintDate11.TextFont.Size = 8;
                    PrintDate11.TextFont.CharSet = 162;
                    PrintDate11.Value = @"{@printdatetime@}";

                    UserName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 13, 116, 18, false);
                    UserName11.Name = "UserName11";
                    UserName11.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName11.TextFont.Name = "Arial Narrow";
                    UserName11.TextFont.Size = 8;
                    UserName11.TextFont.CharSet = 162;
                    UserName11.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 13, 199, 18, false);
                    PageNumber11.Name = "PageNumber11";
                    PageNumber11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11.TextFont.Name = "Arial Narrow";
                    PageNumber11.TextFont.Size = 8;
                    PageNumber11.TextFont.CharSet = 162;
                    PageNumber11.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField102.CalcValue = NewField102.Value;
                    NewField162.CalcValue = NewField162.Value;
                    PrintDate11.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber11.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName11.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { NewField102,NewField162,PrintDate11,PageNumber11,UserName11};
                }
            }

        }

        public FOOTERGroup FOOTER;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PathologyResultReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            Mikroskopi = new MikroskopiGroup(HEADER,"Mikroskopi");
            DokuIslem = new DokuIslemGroup(HEADER,"DokuIslem");
            EkIslemler = new EkIslemlerGroup(HEADER,"EkIslemler");
            Tani = new TaniGroup(HEADER,"Tani");
            PROCEDURES = new PROCEDURESGroup(HEADER,"PROCEDURES");
            FOOTER = new FOOTERGroup(this,"FOOTER");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYRESULTREPORT";
            Caption = "Patoloji Sonuç Raporu";
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