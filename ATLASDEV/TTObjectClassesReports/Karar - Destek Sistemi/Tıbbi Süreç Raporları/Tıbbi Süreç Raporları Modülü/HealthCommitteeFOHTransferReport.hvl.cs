
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
    public partial class HealthCommitteeFOHTransferReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeFOHTransferReport MyParentReport
            {
                get { return (HealthCommitteeFOHTransferReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField BASLIK1 { get {return Body().BASLIK1;} }
            public TTReportField BASLIK11 { get {return Body().BASLIK11;} }
            public TTReportField BASLIK12 { get {return Body().BASLIK12;} }
            public TTReportField BASLIK111 { get {return Body().BASLIK111;} }
            public TTReportField BASLIK121 { get {return Body().BASLIK121;} }
            public TTReportField BASLIK1121 { get {return Body().BASLIK1121;} }
            public TTReportField BASLIK122 { get {return Body().BASLIK122;} }
            public TTReportField BASLIK1111 { get {return Body().BASLIK1111;} }
            public TTReportField BASLIK1221 { get {return Body().BASLIK1221;} }
            public TTReportField BASLIK11111 { get {return Body().BASLIK11111;} }
            public TTReportField BASLIK11221 { get {return Body().BASLIK11221;} }
            public TTReportField BASLIK111111 { get {return Body().BASLIK111111;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField BASLIK1111111 { get {return Body().BASLIK1111111;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField BASLIK11111111 { get {return Body().BASLIK11111111;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField BASLIK111111111 { get {return Body().BASLIK111111111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1112 { get {return Body().NewField1112;} }
            public TTReportField BASLIK1111111111 { get {return Body().BASLIK1111111111;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField BASLIK1112 { get {return Body().BASLIK1112;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField IKINOKTA { get {return Body().IKINOKTA;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField XXXXXXSEHIR { get {return Body().XXXXXXSEHIR;} }
            public TTReportField DOCUMENTNUMBER { get {return Body().DOCUMENTNUMBER;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField DOGUMYERIIL { get {return Body().DOGUMYERIIL;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField REASON { get {return Body().REASON;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField RESOURCENAME { get {return Body().RESOURCENAME;} }
            public TTReportField SPECIALITYNAME { get {return Body().SPECIALITYNAME;} }
            public TTReportField HAVALEEDILENXXXXXX { get {return Body().HAVALEEDILENXXXXXX;} }
            public TTReportField BASHEKIM { get {return Body().BASHEKIM;} }
            public TTReportField UNVAN { get {return Body().UNVAN;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField BASLIK11222 { get {return Body().BASLIK11222;} }
            public TTReportField BASLIK111112 { get {return Body().BASLIK111112;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField OTHERRESOURCESNAME { get {return Body().OTHERRESOURCESNAME;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportRTF SEVKYAZISI { get {return Body().SEVKYAZISI;} }
            public TTReportField DATE { get {return Body().DATE;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class>("GetHCEFOHForTransferReport", HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HealthCommitteeFOHTransferReport MyParentReport
                {
                    get { return (HealthCommitteeFOHTransferReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField BASLIK1;
                public TTReportField BASLIK11;
                public TTReportField BASLIK12;
                public TTReportField BASLIK111;
                public TTReportField BASLIK121;
                public TTReportField BASLIK1121;
                public TTReportField BASLIK122;
                public TTReportField BASLIK1111;
                public TTReportField BASLIK1221;
                public TTReportField BASLIK11111;
                public TTReportField BASLIK11221;
                public TTReportField BASLIK111111;
                public TTReportField NewField1;
                public TTReportField BASLIK1111111;
                public TTReportField NewField11;
                public TTReportField BASLIK11111111;
                public TTReportField NewField111;
                public TTReportField BASLIK111111111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField BASLIK1111111111;
                public TTReportField NewField2;
                public TTReportField BASLIK1112;
                public TTReportField NOT;
                public TTReportField IKINOKTA;
                public TTReportField BASLIK;
                public TTReportField XXXXXXSEHIR;
                public TTReportField DOCUMENTNUMBER;
                public TTReportField BIRLIK;
                public TTReportField DOGUMYERIIL;
                public TTReportField BIRTHDATE;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField REASON;
                public TTReportField SINIFRUTBE;
                public TTReportField BOLUM;
                public TTReportField RESOURCENAME;
                public TTReportField SPECIALITYNAME;
                public TTReportField HAVALEEDILENXXXXXX;
                public TTReportField BASHEKIM;
                public TTReportField UNVAN;
                public TTReportField NewField3;
                public TTReportField BASLIK11222;
                public TTReportField BASLIK111112;
                public TTReportField TCKIMLIKNO;
                public TTReportField OTHERRESOURCESNAME;
                public TTReportField NewField13;
                public TTReportRTF SEVKYAZISI;
                public TTReportField DATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 267;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 8, 185, 26, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.Value = @"{%BASLIK%}
{%XXXXXXSEHIR%}";

                    BASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 29, 28, 34, false);
                    BASLIK1.Name = "BASLIK1";
                    BASLIK1.Value = @"SAĞ";

                    BASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 29, 41, 34, false);
                    BASLIK11.Name = "BASLIK11";
                    BASLIK11.Value = @":";

                    BASLIK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 34, 28, 39, false);
                    BASLIK12.Name = "BASLIK12";
                    BASLIK12.Value = @"KONU";

                    BASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 34, 41, 39, false);
                    BASLIK111.Name = "BASLIK111";
                    BASLIK111.Value = @":";

                    BASLIK121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 34, 127, 39, false);
                    BASLIK121.Name = "BASLIK121";
                    BASLIK121.Value = @"SAĞLIK KURULU RAPORUNA ESAS MUAYENE / TETKİK İSTEK";

                    BASLIK1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 94, 185, 106, false);
                    BASLIK1121.Name = "BASLIK1121";
                    BASLIK1121.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1121.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1121.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1121.Value = @"Aşağıda açık kimliği yazılı personele düzenlenmekte olan Sağlık Kurulu Raporuna esas olmak üzere istenilen muayene ve tetkik sonuçlarının SAĞLIK KURULU MUAYENE FİŞİ'ne kayıt edilerek onaylandıktan sonra gönderilmesini arz/rica ederim.";

                    BASLIK122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 140, 59, 145, false);
                    BASLIK122.Name = "BASLIK122";
                    BASLIK122.Value = @"KİMLİĞİ";

                    BASLIK1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 140, 62, 145, false);
                    BASLIK1111.Name = "BASLIK1111";
                    BASLIK1111.Value = @":";

                    BASLIK1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 150, 59, 155, false);
                    BASLIK1221.Name = "BASLIK1221";
                    BASLIK1221.Value = @"Adı Soyadı";

                    BASLIK11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 150, 62, 155, false);
                    BASLIK11111.Name = "BASLIK11111";
                    BASLIK11111.Value = @":";

                    BASLIK11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 155, 59, 160, false);
                    BASLIK11221.Name = "BASLIK11221";
                    BASLIK11221.Value = @"Sınıf ve Rütbesi";

                    BASLIK111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 155, 62, 160, false);
                    BASLIK111111.Name = "BASLIK111111";
                    BASLIK111111.Value = @":";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 170, 59, 175, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Birliği";

                    BASLIK1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 170, 62, 175, false);
                    BASLIK1111111.Name = "BASLIK1111111";
                    BASLIK1111111.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 160, 59, 165, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"Baba Adı";

                    BASLIK11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 160, 62, 165, false);
                    BASLIK11111111.Name = "BASLIK11111111";
                    BASLIK11111111.Value = @":";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 165, 59, 170, false);
                    NewField111.Name = "NewField111";
                    NewField111.Value = @"Doğum Yeri ve Tarihi";

                    BASLIK111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 165, 62, 170, false);
                    BASLIK111111111.Name = "BASLIK111111111";
                    BASLIK111111111.Value = @":";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 193, 62, 198, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Value = @"AÇIKLAMA";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 198, 59, 203, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.Value = @"Sağlık Kurulu Muayene Sebebi";

                    BASLIK1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 198, 62, 203, false);
                    BASLIK1111111111.Name = "BASLIK1111111111";
                    BASLIK1111111111.Value = @":";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 203, 59, 208, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Havale Edildiği Ana Bilim Dalı";

                    BASLIK1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 203, 62, 208, false);
                    BASLIK1112.Name = "BASLIK1112";
                    BASLIK1112.Value = @":";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 218, 59, 223, false);
                    NOT.Name = "NOT";
                    NOT.Value = @"Not";

                    IKINOKTA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 218, 62, 223, false);
                    IKINOKTA.Name = "IKINOKTA";
                    IKINOKTA.Value = @":";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 22, 238, 27, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"","""")";

                    XXXXXXSEHIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 28, 237, 33, false);
                    XXXXXXSEHIR.Name = "XXXXXXSEHIR";
                    XXXXXXSEHIR.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXSEHIR.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXSEHIR.TextFont.Name = "Arial";
                    XXXXXXSEHIR.TextFont.CharSet = 162;
                    XXXXXXSEHIR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"","""")";

                    DOCUMENTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 29, 156, 34, false);
                    DOCUMENTNUMBER.Name = "DOCUMENTNUMBER";
                    DOCUMENTNUMBER.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOCUMENTNUMBER.TextFont.CharSet = 162;
                    DOCUMENTNUMBER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCEFOHTRANSFERREPORTDOCUMENTNUMBER"","""")";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 171, 185, 189, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.NoClip = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIK.Value = @"";

                    DOGUMYERIIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 166, 122, 171, false);
                    DOGUMYERIIL.Name = "DOGUMYERIIL";
                    DOGUMYERIIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERIIL.Value = @"{#DOGUMYERIIL#} {%BIRTHDATE%}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 134, 240, 139, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.Visible = EvetHayirEnum.ehHayir;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"Short Date";
                    BIRTHDATE.Value = @"{#BIRTHDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 150, 122, 155, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#} {#SURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 161, 122, 166, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    REASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 198, 186, 203, false);
                    REASON.Name = "REASON";
                    REASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    REASON.Value = @"{#REASON#}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 155, 122, 161, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.Value = @"";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 203, 186, 217, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM.Value = @"";

                    RESOURCENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 75, 242, 80, false);
                    RESOURCENAME.Name = "RESOURCENAME";
                    RESOURCENAME.Visible = EvetHayirEnum.ehHayir;
                    RESOURCENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCENAME.Value = @"{#RESOURCENAME#}";

                    SPECIALITYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 81, 242, 86, false);
                    SPECIALITYNAME.Name = "SPECIALITYNAME";
                    SPECIALITYNAME.Visible = EvetHayirEnum.ehHayir;
                    SPECIALITYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALITYNAME.Value = @"{#SPECIALITYNAME#}";

                    HAVALEEDILENXXXXXX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 85, 185, 93, false);
                    HAVALEEDILENXXXXXX.Name = "HAVALEEDILENXXXXXX";
                    HAVALEEDILENXXXXXX.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAVALEEDILENXXXXXX.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HAVALEEDILENXXXXXX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HAVALEEDILENXXXXXX.MultiLine = EvetHayirEnum.ehEvet;
                    HAVALEEDILENXXXXXX.NoClip = EvetHayirEnum.ehEvet;
                    HAVALEEDILENXXXXXX.WordBreak = EvetHayirEnum.ehEvet;
                    HAVALEEDILENXXXXXX.ExpandTabs = EvetHayirEnum.ehEvet;
                    HAVALEEDILENXXXXXX.Value = @"{#HAVALEEDILENXXXXXX#}";

                    BASHEKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 114, 185, 119, false);
                    BASHEKIM.Name = "BASHEKIM";
                    BASHEKIM.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASHEKIM.MultiLine = EvetHayirEnum.ehEvet;
                    BASHEKIM.WordBreak = EvetHayirEnum.ehEvet;
                    BASHEKIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASHEKIM.TextFont.CharSet = 162;
                    BASHEKIM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 119, 185, 124, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTORTITAL"", """")";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 124, 151, 129, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"BAŞTABİP";

                    BASLIK11222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 145, 59, 150, false);
                    BASLIK11222.Name = "BASLIK11222";
                    BASLIK11222.Value = @"TC Kimlik No";

                    BASLIK111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 145, 62, 150, false);
                    BASLIK111112.Name = "BASLIK111112";
                    BASLIK111112.Value = @":";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 145, 122, 150, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    OTHERRESOURCESNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 89, 242, 94, false);
                    OTHERRESOURCESNAME.Name = "OTHERRESOURCESNAME";
                    OTHERRESOURCESNAME.Visible = EvetHayirEnum.ehHayir;
                    OTHERRESOURCESNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTHERRESOURCESNAME.Value = @"{#SENTOTHERRESOURCES#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 34, 193, 77, false);
                    NewField13.Name = "NewField13";
                    NewField13.FieldType = ReportFieldTypeEnum.ftOLE;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.Value = @"";

                    SEVKYAZISI = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 62, 218, 186, 241, false);
                    SEVKYAZISI.Name = "SEVKYAZISI";
                    SEVKYAZISI.EvaluateValue = EvetHayirEnum.ehEvet;
                    SEVKYAZISI.Value = @"";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 29, 193, 34, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class dataset_GetHCEFOHForTransferReport = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class>(0);
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","");
                    XXXXXXSEHIR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","");
                    XXXXXXBASLIK.CalcValue = MyParentReport.MAIN.BASLIK.CalcValue + @"
" + MyParentReport.MAIN.XXXXXXSEHIR.CalcValue;
                    BASLIK1.CalcValue = BASLIK1.Value;
                    BASLIK11.CalcValue = BASLIK11.Value;
                    BASLIK12.CalcValue = BASLIK12.Value;
                    BASLIK111.CalcValue = BASLIK111.Value;
                    BASLIK121.CalcValue = BASLIK121.Value;
                    BASLIK1121.CalcValue = BASLIK1121.Value;
                    BASLIK122.CalcValue = BASLIK122.Value;
                    BASLIK1111.CalcValue = BASLIK1111.Value;
                    BASLIK1221.CalcValue = BASLIK1221.Value;
                    BASLIK11111.CalcValue = BASLIK11111.Value;
                    BASLIK11221.CalcValue = BASLIK11221.Value;
                    BASLIK111111.CalcValue = BASLIK111111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    BASLIK1111111.CalcValue = BASLIK1111111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    BASLIK11111111.CalcValue = BASLIK11111111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    BASLIK111111111.CalcValue = BASLIK111111111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    BASLIK1111111111.CalcValue = BASLIK1111111111.Value;
                    NewField2.CalcValue = NewField2.Value;
                    BASLIK1112.CalcValue = BASLIK1112.Value;
                    NOT.CalcValue = NOT.Value;
                    IKINOKTA.CalcValue = IKINOKTA.Value;
                    BIRLIK.CalcValue = @"";
                    BIRTHDATE.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.BirthDate) : "");
                    DOGUMYERIIL.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.Dogumyeriil) : "") + @" " + MyParentReport.MAIN.BIRTHDATE.FormattedValue;
                    NAME.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.Name) : "") + @" " + (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.Surname) : "");
                    FATHERNAME.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.FatherName) : "");
                    REASON.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.Reason) : "");
                    SINIFRUTBE.CalcValue = @"";
                    BOLUM.CalcValue = @"";
                    RESOURCENAME.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.ResourceName) : "");
                    SPECIALITYNAME.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.Specialityname) : "");
                    HAVALEEDILENXXXXXX.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.HavaleedilenXXXXXX) : "");
                    NewField3.CalcValue = NewField3.Value;
                    BASLIK11222.CalcValue = BASLIK11222.Value;
                    BASLIK111112.CalcValue = BASLIK111112.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.UniqueRefNo) : "");
                    OTHERRESOURCESNAME.CalcValue = (dataset_GetHCEFOHForTransferReport != null ? Globals.ToStringCore(dataset_GetHCEFOHForTransferReport.SentOtherResources) : "");
                    NewField13.CalcValue = @"";
                    SEVKYAZISI.CalcValue = SEVKYAZISI.Value;
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    DOCUMENTNUMBER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCEFOHTRANSFERREPORTDOCUMENTNUMBER","");
                    BASHEKIM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "");
                    UNVAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL", "");
                    return new TTReportObject[] { BASLIK,XXXXXXSEHIR,XXXXXXBASLIK,BASLIK1,BASLIK11,BASLIK12,BASLIK111,BASLIK121,BASLIK1121,BASLIK122,BASLIK1111,BASLIK1221,BASLIK11111,BASLIK11221,BASLIK111111,NewField1,BASLIK1111111,NewField11,BASLIK11111111,NewField111,BASLIK111111111,NewField1111,NewField1112,BASLIK1111111111,NewField2,BASLIK1112,NOT,IKINOKTA,BIRLIK,BIRTHDATE,DOGUMYERIIL,NAME,FATHERNAME,REASON,SINIFRUTBE,BOLUM,RESOURCENAME,SPECIALITYNAME,HAVALEEDILENXXXXXX,NewField3,BASLIK11222,BASLIK111112,TCKIMLIKNO,OTHERRESOURCESNAME,NewField13,SEVKYAZISI,DATE,DOCUMENTNUMBER,BASHEKIM,UNVAN};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeFOHTransferReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeExaminationFromOtherHospitals hc = (HealthCommitteeExaminationFromOtherHospitals)context.GetObject(new Guid(sObjectID),"HealthCommitteeExaminationFromOtherHospitals");
                    
            if (this.RESOURCENAME.CalcValue == "")
                this.BOLUM.CalcValue = this.SPECIALITYNAME.CalcValue;
            else 
                this.BOLUM.CalcValue = this.RESOURCENAME.CalcValue;
            if(!string.IsNullOrEmpty(this.OTHERRESOURCESNAME.CalcValue))
            {
                if(!string.IsNullOrEmpty(this.BOLUM.CalcValue))
                    this.BOLUM.CalcValue += " , " + this.OTHERRESOURCESNAME.CalcValue;
                else
                    this.BOLUM.CalcValue = this.OTHERRESOURCESNAME.CalcValue;
            }
            if(hc.InfoOfSent != null)
                this.SEVKYAZISI.CalcValue = hc.InfoOfSent.ToString();
            if(string.IsNullOrEmpty(hc.InfoOfSent))
            {
                this.SEVKYAZISI.Visible = EvetHayirEnum.ehHayir;
                this.NOT.Visible = EvetHayirEnum.ehHayir;
                this.IKINOKTA.Visible = EvetHayirEnum.ehHayir;
            }
            if(hc.DocumentNumber != null)
                this.DOCUMENTNUMBER.CalcValue += " - " + hc.DocumentNumber.ToString();
            this.DOCUMENTNUMBER.CalcValue += " - " + DateTime.Now.Year.ToString().Substring(2);
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

        public HealthCommitteeFOHTransferReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "OBJECTID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEFOHTRANSFERREPORT";
            Caption = "Sağlık Kurulu Transfer Raporu";
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