
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
    /// Sağlık Kurulu Zeyil Raporu
    /// </summary>
    public partial class HCAddendumReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HCAddendumReport MyParentReport
            {
                get { return (HCAddendumReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTDATE { get {return Header().REPORTDATE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField REPORTNO { get {return Header().REPORTNO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField XXXXXXSEHIR { get {return Header().XXXXXXSEHIR;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField DOCUMENTNUMBER { get {return Header().DOCUMENTNUMBER;} }
            public TTReportField MEMBEROBJECTID { get {return Footer().MEMBEROBJECTID;} }
            public TTReportShape shape11 { get {return Footer().shape11;} }
            public TTReportField SK_CHAIRMAN { get {return Footer().SK_CHAIRMAN;} }
            public TTReportField SK_MEMBER1 { get {return Footer().SK_MEMBER1;} }
            public TTReportField SK_MEMBER2 { get {return Footer().SK_MEMBER2;} }
            public TTReportField SK_MEMBER3 { get {return Footer().SK_MEMBER3;} }
            public TTReportField SK_MEMBER4 { get {return Footer().SK_MEMBER4;} }
            public TTReportField SK_MEMBER5 { get {return Footer().SK_MEMBER5;} }
            public TTReportField SK_MEMBER6 { get {return Footer().SK_MEMBER6;} }
            public TTReportField SK_MEMBER7 { get {return Footer().SK_MEMBER7;} }
            public TTReportField SK_MEMBER8 { get {return Footer().SK_MEMBER8;} }
            public TTReportField SK_MEMBER9 { get {return Footer().SK_MEMBER9;} }
            public TTReportField SK_MEMBER10 { get {return Footer().SK_MEMBER10;} }
            public TTReportField SK_MEMBER11 { get {return Footer().SK_MEMBER11;} }
            public TTReportField SK_MEMBER12 { get {return Footer().SK_MEMBER12;} }
            public TTReportField SK_MEMBER13 { get {return Footer().SK_MEMBER13;} }
            public TTReportField SK_MEMBER14 { get {return Footer().SK_MEMBER14;} }
            public TTReportField SK_MEMBER15 { get {return Footer().SK_MEMBER15;} }
            public TTReportField BASTABIP { get {return Footer().BASTABIP;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>("GetCurrentHCAdditionalReport", HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCAddendumReport MyParentReport
                {
                    get { return (HCAddendumReport)ParentReport; }
                }
                
                public TTReportField REPORTDATE;
                public TTReportField NewField1;
                public TTReportField REPORTNO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1111;
                public TTReportField BASLIK;
                public TTReportField XXXXXXSEHIR;
                public TTReportField NewField12;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField121;
                public TTReportField DOCUMENTNUMBER; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 68;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 45, 201, 50, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.TextFont.Name = "Arial";
                    REPORTDATE.TextFont.CharSet = 162;
                    REPORTDATE.Value = @"{#REPORTDATE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 59, 112, 64, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"ZEYİL RAPOR NO :";

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 59, 138, 64, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Name = "Arial";
                    REPORTNO.TextFont.CharSet = 162;
                    REPORTNO.Value = @"{#REPORTNO#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 20, 201, 44, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"{%BASLIK%}
{%XXXXXXSEHIR%}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 48, 27, 53, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"SAĞ.KRL";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 26, 238, 31, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"","""")";

                    XXXXXXSEHIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 32, 237, 37, false);
                    XXXXXXSEHIR.Name = "XXXXXXSEHIR";
                    XXXXXXSEHIR.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXSEHIR.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXSEHIR.TextFont.Name = "Arial";
                    XXXXXXSEHIR.TextFont.CharSet = 162;
                    XXXXXXSEHIR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"","""")";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 53, 27, 58, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"KONU";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 48, 29, 53, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @":";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 53, 29, 58, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 53, 53, 58, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Zeyil Raporu";

                    DOCUMENTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 48, 172, 53, false);
                    DOCUMENTNUMBER.Name = "DOCUMENTNUMBER";
                    DOCUMENTNUMBER.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOCUMENTNUMBER.TextFont.Name = "Arial";
                    DOCUMENTNUMBER.TextFont.CharSet = 162;
                    DOCUMENTNUMBER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCADDENDUMREPORTDOCUMENTNUMBER"","""")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class dataset_GetCurrentHCAdditionalReport = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>(0);
                    REPORTDATE.CalcValue = (dataset_GetCurrentHCAdditionalReport != null ? Globals.ToStringCore(dataset_GetCurrentHCAdditionalReport.ReportDate) : "");
                    NewField1.CalcValue = NewField1.Value;
                    REPORTNO.CalcValue = (dataset_GetCurrentHCAdditionalReport != null ? Globals.ToStringCore(dataset_GetCurrentHCAdditionalReport.ReportNo) : "");
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","");
                    XXXXXXSEHIR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","");
                    XXXXXXBASLIK.CalcValue = MyParentReport.PARTA.BASLIK.CalcValue + @"
" + MyParentReport.PARTA.XXXXXXSEHIR.CalcValue;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    DOCUMENTNUMBER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCADDENDUMREPORTDOCUMENTNUMBER","");
                    return new TTReportObject[] { REPORTDATE,NewField1,REPORTNO,BASLIK,XXXXXXSEHIR,XXXXXXBASLIK,NewField1111,NewField12,NewField11111,NewField111111,NewField121,DOCUMENTNUMBER};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HCAddendumReport MyParentReport
                {
                    get { return (HCAddendumReport)ParentReport; }
                }
                
                public TTReportField MEMBEROBJECTID;
                public TTReportShape shape11;
                public TTReportField SK_CHAIRMAN;
                public TTReportField SK_MEMBER1;
                public TTReportField SK_MEMBER2;
                public TTReportField SK_MEMBER3;
                public TTReportField SK_MEMBER4;
                public TTReportField SK_MEMBER5;
                public TTReportField SK_MEMBER6;
                public TTReportField SK_MEMBER7;
                public TTReportField SK_MEMBER8;
                public TTReportField SK_MEMBER9;
                public TTReportField SK_MEMBER10;
                public TTReportField SK_MEMBER11;
                public TTReportField SK_MEMBER12;
                public TTReportField SK_MEMBER13;
                public TTReportField SK_MEMBER14;
                public TTReportField SK_MEMBER15;
                public TTReportField BASTABIP;
                public TTReportField ONAY;
                public TTReportField NewField2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 121;
                    RepeatCount = 0;
                    
                    MEMBEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 19, 242, 24, false);
                    MEMBEROBJECTID.Name = "MEMBEROBJECTID";
                    MEMBEROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    MEMBEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBEROBJECTID.Value = @"{#MEMBEROFHEALTHCOMMITTEE#}";

                    shape11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, -36, 0, 81, false);
                    shape11.Name = "shape11";
                    shape11.DrawStyle = DrawStyleConstants.vbSolid;

                    SK_CHAIRMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 8, 59, 25, false);
                    SK_CHAIRMAN.Name = "SK_CHAIRMAN";
                    SK_CHAIRMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_CHAIRMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.TextFont.Name = "Arial";
                    SK_CHAIRMAN.TextFont.Size = 7;
                    SK_CHAIRMAN.TextFont.CharSet = 162;
                    SK_CHAIRMAN.Value = @"";

                    SK_MEMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 8, 105, 25, false);
                    SK_MEMBER1.Name = "SK_MEMBER1";
                    SK_MEMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER1.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.TextFont.Name = "Arial";
                    SK_MEMBER1.TextFont.Size = 7;
                    SK_MEMBER1.TextFont.CharSet = 162;
                    SK_MEMBER1.Value = @"";

                    SK_MEMBER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 151, 25, false);
                    SK_MEMBER2.Name = "SK_MEMBER2";
                    SK_MEMBER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER2.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.TextFont.Name = "Arial";
                    SK_MEMBER2.TextFont.Size = 7;
                    SK_MEMBER2.TextFont.CharSet = 162;
                    SK_MEMBER2.Value = @"";

                    SK_MEMBER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 8, 197, 25, false);
                    SK_MEMBER3.Name = "SK_MEMBER3";
                    SK_MEMBER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER3.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.TextFont.Name = "Arial";
                    SK_MEMBER3.TextFont.Size = 7;
                    SK_MEMBER3.TextFont.CharSet = 162;
                    SK_MEMBER3.Value = @"";

                    SK_MEMBER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 25, 59, 42, false);
                    SK_MEMBER4.Name = "SK_MEMBER4";
                    SK_MEMBER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER4.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.TextFont.Name = "Arial";
                    SK_MEMBER4.TextFont.Size = 7;
                    SK_MEMBER4.TextFont.CharSet = 162;
                    SK_MEMBER4.Value = @"";

                    SK_MEMBER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 25, 105, 42, false);
                    SK_MEMBER5.Name = "SK_MEMBER5";
                    SK_MEMBER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER5.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.TextFont.Name = "Arial";
                    SK_MEMBER5.TextFont.Size = 7;
                    SK_MEMBER5.TextFont.CharSet = 162;
                    SK_MEMBER5.Value = @"";

                    SK_MEMBER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 25, 151, 42, false);
                    SK_MEMBER6.Name = "SK_MEMBER6";
                    SK_MEMBER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER6.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.TextFont.Name = "Arial";
                    SK_MEMBER6.TextFont.Size = 7;
                    SK_MEMBER6.TextFont.CharSet = 162;
                    SK_MEMBER6.Value = @"";

                    SK_MEMBER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 25, 197, 42, false);
                    SK_MEMBER7.Name = "SK_MEMBER7";
                    SK_MEMBER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER7.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.TextFont.Name = "Arial";
                    SK_MEMBER7.TextFont.Size = 7;
                    SK_MEMBER7.TextFont.CharSet = 162;
                    SK_MEMBER7.Value = @"";

                    SK_MEMBER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 42, 59, 59, false);
                    SK_MEMBER8.Name = "SK_MEMBER8";
                    SK_MEMBER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER8.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.TextFont.Name = "Arial";
                    SK_MEMBER8.TextFont.Size = 7;
                    SK_MEMBER8.TextFont.CharSet = 162;
                    SK_MEMBER8.Value = @"";

                    SK_MEMBER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 42, 105, 59, false);
                    SK_MEMBER9.Name = "SK_MEMBER9";
                    SK_MEMBER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER9.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.TextFont.Name = "Arial";
                    SK_MEMBER9.TextFont.Size = 7;
                    SK_MEMBER9.TextFont.CharSet = 162;
                    SK_MEMBER9.Value = @"";

                    SK_MEMBER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 42, 151, 59, false);
                    SK_MEMBER10.Name = "SK_MEMBER10";
                    SK_MEMBER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER10.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.TextFont.Name = "Arial";
                    SK_MEMBER10.TextFont.Size = 7;
                    SK_MEMBER10.TextFont.CharSet = 162;
                    SK_MEMBER10.Value = @"";

                    SK_MEMBER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 42, 197, 59, false);
                    SK_MEMBER11.Name = "SK_MEMBER11";
                    SK_MEMBER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER11.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.TextFont.Name = "Arial";
                    SK_MEMBER11.TextFont.Size = 7;
                    SK_MEMBER11.TextFont.CharSet = 162;
                    SK_MEMBER11.Value = @"";

                    SK_MEMBER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 59, 59, 76, false);
                    SK_MEMBER12.Name = "SK_MEMBER12";
                    SK_MEMBER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER12.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.TextFont.Name = "Arial";
                    SK_MEMBER12.TextFont.Size = 7;
                    SK_MEMBER12.TextFont.CharSet = 162;
                    SK_MEMBER12.Value = @"";

                    SK_MEMBER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 59, 105, 76, false);
                    SK_MEMBER13.Name = "SK_MEMBER13";
                    SK_MEMBER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER13.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.TextFont.Name = "Arial";
                    SK_MEMBER13.TextFont.Size = 7;
                    SK_MEMBER13.TextFont.CharSet = 162;
                    SK_MEMBER13.Value = @"";

                    SK_MEMBER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 59, 151, 76, false);
                    SK_MEMBER14.Name = "SK_MEMBER14";
                    SK_MEMBER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER14.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.TextFont.Name = "Arial";
                    SK_MEMBER14.TextFont.Size = 7;
                    SK_MEMBER14.TextFont.CharSet = 162;
                    SK_MEMBER14.Value = @"";

                    SK_MEMBER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 59, 197, 76, false);
                    SK_MEMBER15.Name = "SK_MEMBER15";
                    SK_MEMBER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER15.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.TextFont.Name = "Arial";
                    SK_MEMBER15.TextFont.Size = 7;
                    SK_MEMBER15.TextFont.CharSet = 162;
                    SK_MEMBER15.Value = @"";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 96, 135, 119, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial";
                    BASTABIP.TextFont.CharSet = 162;
                    BASTABIP.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 80, 128, 95, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.TextFont.Name = "Arial";
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 54, 8, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 7;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.Underline = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Sağ. Krl. Bşk.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class dataset_GetCurrentHCAdditionalReport = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>(0);
                    MEMBEROBJECTID.CalcValue = (dataset_GetCurrentHCAdditionalReport != null ? Globals.ToStringCore(dataset_GetCurrentHCAdditionalReport.MemberOfHealthCommittee) : "");
                    SK_CHAIRMAN.CalcValue = @"";
                    SK_MEMBER1.CalcValue = @"";
                    SK_MEMBER2.CalcValue = @"";
                    SK_MEMBER3.CalcValue = @"";
                    SK_MEMBER4.CalcValue = @"";
                    SK_MEMBER5.CalcValue = @"";
                    SK_MEMBER6.CalcValue = @"";
                    SK_MEMBER7.CalcValue = @"";
                    SK_MEMBER8.CalcValue = @"";
                    SK_MEMBER9.CalcValue = @"";
                    SK_MEMBER10.CalcValue = @"";
                    SK_MEMBER11.CalcValue = @"";
                    SK_MEMBER12.CalcValue = @"";
                    SK_MEMBER13.CalcValue = @"";
                    SK_MEMBER14.CalcValue = @"";
                    SK_MEMBER15.CalcValue = @"";
                    BASTABIP.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { MEMBEROBJECTID,SK_CHAIRMAN,SK_MEMBER1,SK_MEMBER2,SK_MEMBER3,SK_MEMBER4,SK_MEMBER5,SK_MEMBER6,SK_MEMBER7,SK_MEMBER8,SK_MEMBER9,SK_MEMBER10,SK_MEMBER11,SK_MEMBER12,SK_MEMBER13,SK_MEMBER14,SK_MEMBER15,BASTABIP,ONAY,NewField2};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
           string sObjectID =  this.MEMBEROBJECTID.CalcValue;
           MemberOfHealthCommitteeDefinition member = (MemberOfHealthCommitteeDefinition)context.GetObject(new Guid(sObjectID),"MemberOfHealthCommitteeDefinition");
           
           
           
              //Baştabip
            string sCrLf = "\r\n";
            if(member != null && member.MasterOfHealthCommittee != null)
            {
                string sEmpID = member.MasterOfHealthCommittee.EmploymentRecordID;
                string sTitle = ""; //(member.MasterOfHealthCommittee.MilitaryClass == null ? "" : member.MasterOfHealthCommittee.MilitaryClass.ShortName);
                
                if (member.MasterOfHealthCommittee.Title.HasValue)
                    sTitle +=  TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MasterOfHealthCommittee.Title.Value);
                //string sRank = (member.MasterOfHealthCommittee.Rank != null)?member.MasterOfHealthCommittee.Rank.ShortName:"";
                //string sMilClass = (member.MasterOfHealthCommittee.MilitaryClass != null)?member.MasterOfHealthCommittee.MilitaryClass.ShortName:"";
                
                sTitle += " " + (member.MasterOfHealthCommittee.Rank == null ? "" : member.MasterOfHealthCommittee.Rank.ShortName);
                string sMasterText = "";
                
                sMasterText = sMasterText + " " + member.MasterOfHealthCommittee.Name + sCrLf;
                sMasterText = sMasterText + " " + sTitle + " (" + sEmpID + ")" + sCrLf;
                sMasterText = sMasterText + " BAŞTABİP ";
                this.BASTABIP.CalcValue = sMasterText;
            }

             //Signatures
            if (member!=null)
            {
            //Chairman
                if (member.MasterOfHealthCommittee2 != null){
                    string chairmanName = member.MasterOfHealthCommittee2.Name;
                    string chairmanMilClass = member.MasterOfHealthCommittee2.MilitaryClass == null ? "" : member.MasterOfHealthCommittee2.MilitaryClass.ShortName;
                    string chairmanRank = member.MasterOfHealthCommittee2.Rank == null ? "" : member.MasterOfHealthCommittee2.Rank.ShortName;
                    string chairmanTitle = !member.MasterOfHealthCommittee2.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MasterOfHealthCommittee2.Title.Value);
                    string chairmanRecId = member.MasterOfHealthCommittee2.EmploymentRecordID == null ? "" : member.MasterOfHealthCommittee2.EmploymentRecordID;
                    string chairmanMainSpeciality = "";
                    string chairmanSpecialities = "";
                    for(int s=0;s<member.MasterOfHealthCommittee2.ResourceSpecialities.Count;s++)
                        if (member.MasterOfHealthCommittee2.ResourceSpecialities[s].MainSpeciality.Equals(true))
                        {
                            chairmanMainSpeciality += member.MasterOfHealthCommittee2.ResourceSpecialities[s].Speciality.Name;
                            if(!member.MasterOfHealthCommittee2.ResourceSpecialities[s].Speciality.Name.Contains("Uzm"))chairmanMainSpeciality+=" Uzm.";
                        }
                        else
                        {
                            chairmanSpecialities += member.MasterOfHealthCommittee2.ResourceSpecialities[s].Speciality.Name;
                            if(!member.MasterOfHealthCommittee2.ResourceSpecialities[s].Speciality.Name.Contains("Uzm"))chairmanSpecialities+=" Uzm.";
                            chairmanSpecialities+="\r\n";
                        }
                    //if (chairmanSpecialities != "") chairmanSpecialities += " Uzm.";
                    //else if (chairmanMainSpeciality != "") chairmanMainSpeciality += " Uzm.";

                    this.SK_CHAIRMAN.CalcValue =  chairmanName + "\r\n" + chairmanTitle + chairmanRank + " (" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
                    //this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanMilClass + chairmanTitle + chairmanRank + "(" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
                }

                foreach (HealthCommitteMemberGrid pMember in member.Members)
                {
                    if (pMember.Doctor != null)
                    {
                        string memberName = pMember.Doctor.Name;
                        string memberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
                        string memberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
                        string memberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
                        string memberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
                        string memberMainSpeciality = "";
                        string memberSpecialities = "";
                        for (int s = 0; s < pMember.Doctor.ResourceSpecialities.Count; s++)
                            if (pMember.Doctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
                            {
                                memberMainSpeciality += pMember.Doctor.ResourceSpecialities[s].Speciality.Name;
                                if (!pMember.Doctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
                            }
                            else
                            {
                                memberSpecialities += pMember.Doctor.ResourceSpecialities[s].Speciality.Name;
                                if (!pMember.Doctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
                                memberSpecialities+="\r\n";
                            }
                        string sigText = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
                        //string sigText = memberName + "\r\n" + memberMilClass + memberTitle + memberRank + "(" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;

                        //if (memberSpecialities != "") memberSpecialities += " Uzm.";
                        //else if (memberMainSpeciality != "") memberMainSpeciality += " Uzm.";

                        if (this.SK_MEMBER1.CalcValue.Length == 0) this.SK_MEMBER1.CalcValue = sigText;
                        else if (this.SK_MEMBER2.CalcValue.Length == 0) this.SK_MEMBER2.CalcValue = sigText;
                        else if (this.SK_MEMBER3.CalcValue.Length == 0) this.SK_MEMBER3.CalcValue = sigText;
                        else if (this.SK_MEMBER4.CalcValue.Length == 0) this.SK_MEMBER4.CalcValue = sigText;
                        else if (this.SK_MEMBER5.CalcValue.Length == 0) this.SK_MEMBER5.CalcValue = sigText;
                        else if (this.SK_MEMBER6.CalcValue.Length == 0) this.SK_MEMBER6.CalcValue = sigText;
                        else if (this.SK_MEMBER7.CalcValue.Length == 0) this.SK_MEMBER7.CalcValue = sigText;
                        else if (this.SK_MEMBER8.CalcValue.Length == 0) this.SK_MEMBER8.CalcValue = sigText;
                        else if (this.SK_MEMBER9.CalcValue.Length == 0) this.SK_MEMBER9.CalcValue = sigText;
                        else if (this.SK_MEMBER10.CalcValue.Length == 0) this.SK_MEMBER10.CalcValue = sigText;
                        else if (this.SK_MEMBER11.CalcValue.Length == 0) this.SK_MEMBER11.CalcValue = sigText;
                        else if (this.SK_MEMBER12.CalcValue.Length == 0) this.SK_MEMBER12.CalcValue = sigText;
                        else if (this.SK_MEMBER13.CalcValue.Length == 0) this.SK_MEMBER13.CalcValue = sigText;
                        else if (this.SK_MEMBER14.CalcValue.Length == 0) this.SK_MEMBER14.CalcValue = sigText;
                        else if (this.SK_MEMBER15.CalcValue.Length == 0) this.SK_MEMBER15.CalcValue = sigText;
                    }
                }
            }
            
            this.ONAY.CalcValue = "ONAY  (           /         /" + TTObjectClasses.Common.RecTime().Year.ToString() +")";
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HCAddendumReport MyParentReport
            {
                get { return (HCAddendumReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REPORT { get {return Body().REPORT;} }
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
                public HCAddendumReport MyParentReport
                {
                    get { return (HCAddendumReport)ParentReport; }
                }
                
                public TTReportField REPORT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    REPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 201, 7, false);
                    REPORT.Name = "REPORT";
                    REPORT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORT.MultiLine = EvetHayirEnum.ehEvet;
                    REPORT.NoClip = EvetHayirEnum.ehEvet;
                    REPORT.WordBreak = EvetHayirEnum.ehEvet;
                    REPORT.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORT.TextFont.Name = "Arial";
                    REPORT.TextFont.CharSet = 162;
                    REPORT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORT.CalcValue = @"";
                    return new TTReportObject[] { REPORT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCAddendumReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeAdditionalReport hcr = (HealthCommitteeAdditionalReport)context.GetObject(new Guid(sObjectID),"HealthCommitteeAdditionalReport");  
           
            // Rapor
            if(hcr.Report != null)
                this.REPORT.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hcr.Report.ToString());
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

        public HCAddendumReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCADDENDUMREPORT";
            Caption = "Sağlık Kurulu Zeyil Raporu";
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