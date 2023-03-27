
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
    /// Tıbbi Kurul Karar Raporu
    /// </summary>
    public partial class MedicalCommitteeDesicionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("1B0EFED2-C893-486D-8AC0-44D71950737E");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MedicalCommitteeDesicionReport MyParentReport
            {
                get { return (MedicalCommitteeDesicionReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField64 { get {return Header().NewField64;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField BIRIM { get {return Header().BIRIM;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField ADI { get {return Header().ADI;} }
            public TTReportField SOYADI { get {return Header().SOYADI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField GONDERENMAKAM { get {return Header().GONDERENMAKAM;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField KURULTIPI { get {return Header().KURULTIPI;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYERTARIH { get {return Header().DYERTARIH;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
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
                list[0] = new TTReportNqlData<MedicalCommittee.GetCurrentMedicalCommittee_Class>("GetCurrentMedicalCommittee", MedicalCommittee.GetCurrentMedicalCommittee((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MedicalCommitteeDesicionReport MyParentReport
                {
                    get { return (MedicalCommitteeDesicionReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField NewField;
                public TTReportField ADISOYADI;
                public TTReportField NewField2;
                public TTReportField NewField64;
                public TTReportField NewField3;
                public TTReportField DYER;
                public TTReportField NewField4;
                public TTReportField BIRIM;
                public TTReportField NewField5;
                public TTReportField ADI;
                public TTReportField SOYADI;
                public TTReportField NewField1;
                public TTReportField TCNO;
                public TTReportField NewField12;
                public TTReportField NewField6;
                public TTReportField GONDERENMAKAM;
                public TTReportField NewField13;
                public TTReportField NewField7;
                public TTReportField KURULTIPI;
                public TTReportField NewField14;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField DTARIH;
                public TTReportField DYERTARIH;
                public TTReportField NewField8; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 62;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 28, 192, 34, false);
                    HEADER.Name = "HEADER";
                    HEADER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Size = 16;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"TIBBİ KURUL KARAR RAPORU";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 36, 39, 41, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Adı Soyadı";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 36, 111, 41, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.Value = @"{%ADI%} {%SOYADI%}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 36, 41, 41, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 41, 39, 46, false);
                    NewField64.Name = "NewField64";
                    NewField64.MultiLine = EvetHayirEnum.ehEvet;
                    NewField64.NoClip = EvetHayirEnum.ehEvet;
                    NewField64.WordBreak = EvetHayirEnum.ehEvet;
                    NewField64.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField64.TextFont.Size = 8;
                    NewField64.TextFont.Bold = true;
                    NewField64.TextFont.CharSet = 162;
                    NewField64.Value = @"Doğum Yeri/Tarihi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 41, 41, 46, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @":";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 62, 96, 67, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFormat = @"Short Date";
                    DYER.Value = @"{#DOGUMYERI#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 46, 39, 51, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Birimi";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 46, 111, 51, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.TextFont.Size = 8;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#BIRIM#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 46, 41, 51, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @":";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 54, 65, 59, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.ObjectDefName = "Patient";
                    ADI.DataMember = "NAME";
                    ADI.Value = @"{#POBJECTID#}";

                    SOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 54, 91, 59, false);
                    SOYADI.Name = "SOYADI";
                    SOYADI.Visible = EvetHayirEnum.ehHayir;
                    SOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYADI.ObjectDefName = "Patient";
                    SOYADI.DataMember = "SURNAME";
                    SOYADI.Value = @"{#POBJECTID#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 36, 138, 41, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"T.C. No";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 36, 192, 41, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.ObjectDefName = "Patient";
                    TCNO.DataMember = "UNIQUEREFNO";
                    TCNO.Value = @"{#POBJECTID#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 36, 140, 41, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 41, 138, 46, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Gönderen Makam";

                    GONDERENMAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 41, 192, 46, false);
                    GONDERENMAKAM.Name = "GONDERENMAKAM";
                    GONDERENMAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERENMAKAM.TextFont.Size = 8;
                    GONDERENMAKAM.TextFont.CharSet = 162;
                    GONDERENMAKAM.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 41, 140, 46, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 46, 138, 51, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Kurul Tipi";

                    KURULTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 46, 192, 51, false);
                    KURULTIPI.Name = "KURULTIPI";
                    KURULTIPI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURULTIPI.Value = @"{#KURULTIPI#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 46, 140, 51, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 5, 192, 28, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 67, 96, 72, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.ObjectDefName = "Patient";
                    DTARIH.DataMember = "BIRTHDATE";
                    DTARIH.Value = @"{#POBJECTID#}";

                    DYERTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 41, 111, 46, false);
                    DYERTARIH.Name = "DYERTARIH";
                    DYERTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTARIH.TextFormat = @"Short Date";
                    DYERTARIH.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 62, 127, 67, false);
                    NewField8.Name = "NewField8";
                    NewField8.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MedicalCommittee.GetCurrentMedicalCommittee_Class dataset_GetCurrentMedicalCommittee = ParentGroup.rsGroup.GetCurrentRecord<MedicalCommittee.GetCurrentMedicalCommittee_Class>(0);
                    HEADER.CalcValue = HEADER.Value;
                    NewField.CalcValue = NewField.Value;
                    ADI.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Pobjectid) : "");
                    ADI.PostFieldValueCalculation();
                    SOYADI.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Pobjectid) : "");
                    SOYADI.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = MyParentReport.PARTA.ADI.CalcValue + @" " + MyParentReport.PARTA.SOYADI.CalcValue;
                    NewField2.CalcValue = NewField2.Value;
                    NewField64.CalcValue = NewField64.Value;
                    NewField3.CalcValue = NewField3.Value;
                    DYER.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Dogumyeri) : "");
                    NewField4.CalcValue = NewField4.Value;
                    BIRIM.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Birim) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField1.CalcValue = NewField1.Value;
                    TCNO.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Pobjectid) : "");
                    TCNO.PostFieldValueCalculation();
                    NewField12.CalcValue = NewField12.Value;
                    NewField6.CalcValue = NewField6.Value;
                    GONDERENMAKAM.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    NewField7.CalcValue = NewField7.Value;
                    KURULTIPI.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Kurultipi) : "");
                    NewField14.CalcValue = NewField14.Value;
                    DTARIH.CalcValue = (dataset_GetCurrentMedicalCommittee != null ? Globals.ToStringCore(dataset_GetCurrentMedicalCommittee.Pobjectid) : "");
                    DTARIH.PostFieldValueCalculation();
                    DYERTARIH.CalcValue = MyParentReport.PARTA.DYER.FormattedValue + @" / " + MyParentReport.PARTA.DTARIH.FormattedValue;
                    NewField8.CalcValue = NewField8.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { HEADER,NewField,ADI,SOYADI,ADISOYADI,NewField2,NewField64,NewField3,DYER,NewField4,BIRIM,NewField5,NewField1,TCNO,NewField12,NewField6,GONDERENMAKAM,NewField13,NewField7,KURULTIPI,NewField14,DTARIH,DYERTARIH,NewField8,XXXXXXBASLIK1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MedicalCommitteeDesicionReport MyParentReport
                {
                    get { return (MedicalCommitteeDesicionReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MedicalCommitteeDesicionReport MyParentReport
            {
                get { return (MedicalCommitteeDesicionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField KONU { get {return Body().KONU;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField TEDAVIPLANI { get {return Body().TEDAVIPLANI;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField MEMBERS { get {return Body().MEMBERS;} }
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
                public MedicalCommitteeDesicionReport MyParentReport
                {
                    get { return (MedicalCommitteeDesicionReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField TANI;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField KONU;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField TEDAVIPLANI;
                public TTReportField NewField6;
                public TTReportField MEMBERS; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 171;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 4, 41, 9, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Tanı";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 4, 193, 23, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Size = 8;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 4, 43, 9, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 27, 41, 32, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Konu";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 27, 193, 62, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.MultiLine = EvetHayirEnum.ehEvet;
                    KONU.WordBreak = EvetHayirEnum.ehEvet;
                    KONU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU.TextFont.Size = 8;
                    KONU.TextFont.CharSet = 162;
                    KONU.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 27, 43, 32, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @":";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 64, 41, 69, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Karar";

                    TEDAVIPLANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 64, 193, 108, false);
                    TEDAVIPLANI.Name = "TEDAVIPLANI";
                    TEDAVIPLANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVIPLANI.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVIPLANI.WordBreak = EvetHayirEnum.ehEvet;
                    TEDAVIPLANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEDAVIPLANI.TextFont.Size = 7;
                    TEDAVIPLANI.TextFont.CharSet = 162;
                    TEDAVIPLANI.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 64, 43, 69, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    MEMBERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 118, 210, 169, false);
                    MEMBERS.Name = "MEMBERS";
                    MEMBERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBERS.MultiLine = EvetHayirEnum.ehEvet;
                    MEMBERS.NoClip = EvetHayirEnum.ehEvet;
                    MEMBERS.WordBreak = EvetHayirEnum.ehEvet;
                    MEMBERS.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEMBERS.TextFont.Name = "Courier New";
                    MEMBERS.TextFont.Size = 6;
                    MEMBERS.TextFont.Bold = true;
                    MEMBERS.TextFont.CharSet = 162;
                    MEMBERS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    TANI.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    KONU.CalcValue = @"";
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    TEDAVIPLANI.CalcValue = @"";
                    NewField6.CalcValue = NewField6.Value;
                    MEMBERS.CalcValue = @"";
                    return new TTReportObject[] { NewField,TANI,NewField2,NewField3,KONU,NewField4,NewField5,TEDAVIPLANI,NewField6,MEMBERS};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sObjectID = ((MedicalCommitteeDesicionReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BindingList<MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction_Class> pDiagnosis = null;
            pDiagnosis = MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction(sObjectID);

            TTObjectContext context = new TTObjectContext(true);
            MedicalCommittee pCommittee = (MedicalCommittee)context.GetObject(new Guid(sObjectID),"MedicalCommittee");
            
            int nCount = 1;
            this.TANI.CalcValue = "";
            foreach(MedicalComiteeDiagnosisGrid.GetMCDiagnosisGridByEpisodeAction_Class pDiagnose in pDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- "+ pDiagnose.Tanikodu + " " + pDiagnose.Taniadi;
                this.TANI.CalcValue += "\r\n";
            }
            
            //Konu
            if(pCommittee.Subject!=null)
                this.KONU.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(pCommittee.Subject.ToString());
            //Karar
            if(pCommittee.TreatmentPlan!=null)
                this.TEDAVIPLANI.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(pCommittee.TreatmentPlan.ToString());
            
            //Members
            if(pCommittee.MemberOfMedicalCommittee != null)
            {
                string sCrLf = "\r\n";
                string sMembersText = sCrLf;
                string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "";
                
                const int COLUMN_COUNT = 3;
                const int SPACE_COUNT = 60;
                int nCounter = 0;
                int nRow = 0;

                string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                
                foreach(MedicalCommitteeMemberOfMedicalCommitteeGrid pMember in pCommittee.MemberOfMedicalCommittee)
                {
                    sMemberName = pMember.Doctor.Name;
                    sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.Name;
                    sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.Name;
                    sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(pMember.Doctor.Title.Value);
                    
                    sNameRow = sNameRow.Insert(nCounter, sMemberName);
                    sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
                    sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);

                    nCounter += SPACE_COUNT;

                    nRow = nCounter / SPACE_COUNT;
                    int nRate = nRow % COLUMN_COUNT;
                    if (nRate == 0)
                    {
                        sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sNameRow + "\r\n";
                        sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sRankRow + "\r\n";
                        sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sTitleRow + "\r\n";

                        sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                        sMembersText +=  sCrLf + sCrLf + sCrLf;
                        nCounter = 0;
                    }
                }
                
                sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                sMembersText += sNameRow + "\r\n";
                sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                sMembersText += sRankRow + "\r\n";
                sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                sMembersText += sTitleRow + "\r\n";
                
                this.MEMBERS.CalcValue = sMembersText;
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

        public MedicalCommitteeDesicionReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "1B0EFED2-C893-486D-8AC0-44D71950737E", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MEDICALCOMMITTEEDESICIONREPORT";
            Caption = "Tıbbi Kurul Karar Raporu";
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