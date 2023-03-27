
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
    /// Ek Ameliyat Raporu
    /// </summary>
    public partial class SubSurgeryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public SubSurgeryReport MyParentReport
            {
                get { return (SubSurgeryReport)ParentReport; }
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
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField FatherName { get {return Header().FatherName;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField BirthPlaceAndDate { get {return Header().BirthPlaceAndDate;} }
            public TTReportField NewField71 { get {return Header().NewField71;} }
            public TTReportField PatientTCNo { get {return Header().PatientTCNo;} }
            public TTReportField NewField81 { get {return Header().NewField81;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
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
                list[0] = new TTReportNqlData<SubSurgery.SubSurgeryReportNQL_Class>("SubSurgeryReportNQL", SubSurgery.SubSurgeryReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SubSurgeryReport MyParentReport
                {
                    get { return (SubSurgeryReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField PatientName;
                public TTReportField NewField4;
                public TTReportField NewField7;
                public TTReportField FatherName;
                public TTReportField NewField3;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField BirthPlaceAndDate;
                public TTReportField NewField71;
                public TTReportField PatientTCNo;
                public TTReportField NewField81;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField8;
                public TTReportField LOGO;
                public TTReportField BirthDate; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 69;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 33, 158, 39, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"EK AMELİYAT RAPORU";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 51, 47, 56, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Hasta Adı";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 51, 114, 56, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 9;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 56, 47, 61, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Baba Adı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 61, 47, 66, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Doğum Yeri / Tarihi";

                    FatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 56, 114, 61, false);
                    FatherName.Name = "FatherName";
                    FatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FatherName.TextFont.Name = "Arial Narrow";
                    FatherName.TextFont.Size = 9;
                    FatherName.Value = @"{#FATHERNAME#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 51, 50, 56, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 56, 50, 61, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Size = 11;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 61, 50, 66, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 11;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @":";

                    BirthPlaceAndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 61, 114, 66, false);
                    BirthPlaceAndDate.Name = "BirthPlaceAndDate";
                    BirthPlaceAndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlaceAndDate.TextFont.Name = "Arial Narrow";
                    BirthPlaceAndDate.TextFont.Size = 9;
                    BirthPlaceAndDate.Value = @"{#CITYNAME#} - {#TOWNNAME#} / {%BirthDate%}";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 47, 51, false);
                    NewField71.Name = "NewField71";
                    NewField71.TextFont.Name = "Arial Narrow";
                    NewField71.TextFont.Size = 11;
                    NewField71.TextFont.Bold = true;
                    NewField71.Value = @"Hasta T.C. No";

                    PatientTCNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 46, 114, 51, false);
                    PatientTCNo.Name = "PatientTCNo";
                    PatientTCNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientTCNo.TextFont.Name = "Arial Narrow";
                    PatientTCNo.TextFont.Size = 9;
                    PatientTCNo.Value = @"{#UNIQUEREFNO#}";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 46, 50, 51, false);
                    NewField81.Name = "NewField81";
                    NewField81.TextFont.Name = "Arial Narrow";
                    NewField81.TextFont.Size = 11;
                    NewField81.TextFont.Bold = true;
                    NewField81.Value = @":";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 10, 158, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 43, 45, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.Underline = true;
                    NewField8.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"LOGO";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 60, 247, 65, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.Visible = EvetHayirEnum.ehHayir;
                    BirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthDate.TextFormat = @"Medium Date";
                    BirthDate.TextFont.Name = "Arial Narrow";
                    BirthDate.TextFont.Size = 9;
                    BirthDate.Value = @"{#BIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgery.SubSurgeryReportNQL_Class dataset_SubSurgeryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PatientName.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Name) : "") + @" " + (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Surname) : "");
                    NewField4.CalcValue = NewField4.Value;
                    NewField7.CalcValue = NewField7.Value;
                    FatherName.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.FatherName) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    BirthDate.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.BirthDate) : "");
                    BirthPlaceAndDate.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Cityname) : "") + @" - " + (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Townname) : "") + @" / " + MyParentReport.HEADER.BirthDate.FormattedValue;
                    NewField71.CalcValue = NewField71.Value;
                    PatientTCNo.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.UniqueRefNo) : "");
                    NewField81.CalcValue = NewField81.Value;
                    NewField8.CalcValue = NewField8.Value;
                    LOGO.CalcValue = LOGO.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField2,PatientName,NewField4,NewField7,FatherName,NewField3,NewField21,NewField22,BirthDate,BirthPlaceAndDate,NewField71,PatientTCNo,NewField81,NewField8,LOGO,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public SubSurgeryReport MyParentReport
                {
                    get { return (SubSurgeryReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class SUBMAINAGroup : TTReportGroup
        {
            public SubSurgeryReport MyParentReport
            {
                get { return (SubSurgeryReport)ParentReport; }
            }

            new public SUBMAINAGroupHeader Header()
            {
                return (SUBMAINAGroupHeader)_header;
            }

            new public SUBMAINAGroupFooter Footer()
            {
                return (SUBMAINAGroupFooter)_footer;
            }

            public TTReportField RAPORSUBBOLUMU { get {return Header().RAPORSUBBOLUMU;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public SUBMAINAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBMAINAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SUBMAINAGroupHeader(this);
                _footer = new SUBMAINAGroupFooter(this);

            }

            public partial class SUBMAINAGroupHeader : TTReportSection
            {
                public SubSurgeryReport MyParentReport
                {
                    get { return (SubSurgeryReport)ParentReport; }
                }
                
                public TTReportField RAPORSUBBOLUMU; 
                public SUBMAINAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORSUBBOLUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 202, 18, false);
                    RAPORSUBBOLUMU.Name = "RAPORSUBBOLUMU";
                    RAPORSUBBOLUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSUBBOLUMU.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSUBBOLUMU.TextFormat = @"Medium Date";
                    RAPORSUBBOLUMU.TextFont.Name = "Arial Narrow";
                    RAPORSUBBOLUMU.TextFont.Size = 11;
                    RAPORSUBBOLUMU.TextFont.Bold = true;
                    RAPORSUBBOLUMU.Value = @"{#HEADER.SUBFROMRES#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgery.SubSurgeryReportNQL_Class dataset_SubSurgeryReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportNQL_Class>(0);
                    RAPORSUBBOLUMU.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Subfromres) : "");
                    return new TTReportObject[] { RAPORSUBBOLUMU};
                }
            }
            public partial class SUBMAINAGroupFooter : TTReportSection
            {
                public SubSurgeryReport MyParentReport
                {
                    get { return (SubSurgeryReport)ParentReport; }
                }
                
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField UZMANLIKDAL;
                public TTReportField DIPSICLABEL;
                public TTReportField SINRUT;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField UZ;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO; 
                public SUBMAINAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 10, 180, 14, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 2, 180, 6, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#HEADER.PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 65, 5, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#HEADER.SPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 10, 130, 14, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 6, 180, 10, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"{%SINIFONAY%} {%RUTBEONAY%}";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 5, 37, 9, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#HEADER.RANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 37, 5, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#HEADER.MILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 14, 180, 18, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 9, 37, 13, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#HEADER.WORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 13, 65, 17, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#HEADER.DIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 5, 65, 9, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 37, 17, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 37, 21, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#HEADER.TITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 9, 65, 13, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#HEADER.EMPLOYMENTRECORDID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgery.SubSurgeryReportNQL_Class dataset_SubSurgeryReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportNQL_Class>(0);
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Speciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINIFONAY.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Militaryclass) : "");
                    RUTBEONAY.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Rank) : "");
                    SINRUT.CalcValue = MyParentReport.SUBMAINA.SINIFONAY.CalcValue + @" " + MyParentReport.SUBMAINA.RUTBEONAY.CalcValue;
                    UZ.CalcValue = MyParentReport.SUBMAINA.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Work) : "");
                    DIPLOMANO.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.DiplomaNo) : "");
                    UNVAN.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Title) : "");
                    SICILNO.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.EmploymentRecordID) : "");
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINIFONAY,RUTBEONAY,SINRUT,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region SUBMAINA FOOTER_Script
                    if(this.SICILKULLAN.CalcValue=="TRUE")
            {
                this.DIPSICLABEL.CalcValue= "SİCİL NO :";
                this.DIPSIC.CalcValue=this.SICILNO.CalcValue;
            }
            else
            {
                this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
                this.DIPSIC.CalcValue=this.DIPLOMANO.CalcValue;
            }
            

            if(this.UNVANKULLAN.CalcValue!="TRUE")
            {
                this.SINRUT.CalcValue=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
            }
            else
            {
                if(this.UNVAN.CalcValue=="")
                {
                    this.SINRUT.Value=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
                else
                {
                    this.SINRUT.CalcValue=this.UNVAN.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
                
            }
#endregion SUBMAINA FOOTER_Script
                }
            }

        }

        public SUBMAINAGroup SUBMAINA;

        public partial class SUBMAINGroup : TTReportGroup
        {
            public SubSurgeryReport MyParentReport
            {
                get { return (SubSurgeryReport)ParentReport; }
            }

            new public SUBMAINGroupBody Body()
            {
                return (SUBMAINGroupBody)_body;
            }
            public TTReportField RAPORTARIH { get {return Body().RAPORTARIH;} }
            public TTReportField LBL1 { get {return Body().LBL1;} }
            public TTReportField LBL2 { get {return Body().LBL2;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField LBL3 { get {return Body().LBL3;} }
            public TTReportRTF SubSurgeryRepor { get {return Body().SubSurgeryRepor;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public SUBMAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBMAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SUBMAINGroupBody(this);
            }

            public partial class SUBMAINGroupBody : TTReportSection
            {
                public SubSurgeryReport MyParentReport
                {
                    get { return (SubSurgeryReport)ParentReport; }
                }
                
                public TTReportField RAPORTARIH;
                public TTReportField LBL1;
                public TTReportField LBL2;
                public TTReportField RAPORNO;
                public TTReportField LBL3;
                public TTReportRTF SubSurgeryRepor;
                public TTReportField NewField1221;
                public TTReportField NewField1321; 
                public SUBMAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 56;
                    RepeatCount = 0;
                    
                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 2, 105, 7, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"Medium Date";
                    RAPORTARIH.TextFont.Name = "Arial Narrow";
                    RAPORTARIH.TextFont.Size = 9;
                    RAPORTARIH.Value = @"{#HEADER.SUBSURGERYREPORTDATE#}";

                    LBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 43, 7, false);
                    LBL1.Name = "LBL1";
                    LBL1.TextFont.Name = "Arial Narrow";
                    LBL1.TextFont.Size = 11;
                    LBL1.TextFont.Bold = true;
                    LBL1.Value = @"Rapor Tarih      ";

                    LBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 2, 141, 7, false);
                    LBL2.Name = "LBL2";
                    LBL2.TextFont.Name = "Arial Narrow";
                    LBL2.TextFont.Size = 11;
                    LBL2.TextFont.Bold = true;
                    LBL2.Value = @"Ameliyat Rapor No:";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 2, 202, 7, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 9;
                    RAPORNO.Value = @"{#HEADER.SUBSURGERYREPORTNO#}";

                    LBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 43, 18, false);
                    LBL3.Name = "LBL3";
                    LBL3.TextFont.Name = "Arial Narrow";
                    LBL3.TextFont.Size = 11;
                    LBL3.TextFont.Bold = true;
                    LBL3.Value = @"Rapor            ";

                    SubSurgeryRepor = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 19, 202, 54, false);
                    SubSurgeryRepor.Name = "SubSurgeryRepor";
                    SubSurgeryRepor.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 13, 49, 18, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 11;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 2, 49, 7, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Size = 11;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubSurgery.SubSurgeryReportNQL_Class dataset_SubSurgeryReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<SubSurgery.SubSurgeryReportNQL_Class>(0);
                    RAPORTARIH.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Subsurgeryreportdate) : "");
                    LBL1.CalcValue = LBL1.Value;
                    LBL2.CalcValue = LBL2.Value;
                    RAPORNO.CalcValue = (dataset_SubSurgeryReportNQL != null ? Globals.ToStringCore(dataset_SubSurgeryReportNQL.Subsurgeryreportno) : "");
                    LBL3.CalcValue = LBL3.Value;
                    SubSurgeryRepor.CalcValue = SubSurgeryRepor.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    return new TTReportObject[] { RAPORTARIH,LBL1,LBL2,RAPORNO,LBL3,SubSurgeryRepor,NewField1221,NewField1321};
                }
                public override void RunPreScript()
                {
#region SUBMAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SubSurgeryReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();// this.SUBSURGERYOBJECTID.CalcValue;
            SubSurgery subSurgery = (SubSurgery)context.GetObject(new Guid(sObjectID),"Subsurgery");
            if(subSurgery.SurgeryReport != null)
                this.SubSurgeryRepor.Value = subSurgery.SurgeryReport.ToString();
#endregion SUBMAIN BODY_PreScript
                }
            }

        }

        public SUBMAINGroup SUBMAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SubSurgeryReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            SUBMAINA = new SUBMAINAGroup(HEADER,"SUBMAINA");
            SUBMAIN = new SUBMAINGroup(SUBMAINA,"SUBMAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Ameliyat", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SUBSURGERYREPORT";
            Caption = "Ek Ameliyat Raporu";
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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