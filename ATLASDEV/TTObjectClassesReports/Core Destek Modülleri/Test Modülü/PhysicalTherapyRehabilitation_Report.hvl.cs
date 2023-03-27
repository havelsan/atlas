
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
    public partial class PhysicalTherapyRehabilitation : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class part1Group : TTReportGroup
        {
            public PhysicalTherapyRehabilitation MyParentReport
            {
                get { return (PhysicalTherapyRehabilitation)ParentReport; }
            }

            new public part1GroupHeader Header()
            {
                return (part1GroupHeader)_header;
            }

            new public part1GroupFooter Footer()
            {
                return (part1GroupFooter)_footer;
            }

            public TTReportField HospitalInfo { get {return Header().HospitalInfo;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
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
                public PhysicalTherapyRehabilitation MyParentReport
                {
                    get { return (PhysicalTherapyRehabilitation)ParentReport; }
                }
                
                public TTReportField HospitalInfo;
                public TTReportField NewField3;
                public TTReportField LOGO; 
                public part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 6, 170, 30, false);
                    HospitalInfo.Name = "HospitalInfo";
                    HospitalInfo.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HospitalInfo.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo.TextFont.Size = 11;
                    HospitalInfo.TextFont.Bold = true;
                    HospitalInfo.TextFont.CharSet = 162;
                    HospitalInfo.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 32, 170, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"FİZİK TEDAVİ VE REHABİLİTASYON UYGULAMALARI
İÇİN SEANS BAŞLAMA-BİTİŞ TARİH VE SAATLERİ";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 17, 34, 40, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField3.CalcValue = NewField3.Value;
                    LOGO.CalcValue = @"";
                    HospitalInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField3,LOGO,HospitalInfo};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PART1 HEADER_Script
                }
            }
            public partial class part1GroupFooter : TTReportSection
            {
                public PhysicalTherapyRehabilitation MyParentReport
                {
                    get { return (PhysicalTherapyRehabilitation)ParentReport; }
                }
                 
                public part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public part1Group part1;

        public partial class MAINGroup : TTReportGroup
        {
            public PhysicalTherapyRehabilitation MyParentReport
            {
                get { return (PhysicalTherapyRehabilitation)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField BirthDate { get {return Body().BirthDate;} }
            public TTReportField NewField172 { get {return Body().NewField172;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField NewField1201 { get {return Body().NewField1201;} }
            public TTReportField NewField1202 { get {return Body().NewField1202;} }
            public TTReportField NewField12021 { get {return Body().NewField12021;} }
            public TTReportField NewField112021 { get {return Body().NewField112021;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField103 { get {return Body().NewField103;} }
            public TTReportField NewField1203 { get {return Body().NewField1203;} }
            public TTReportField NewField11021 { get {return Body().NewField11021;} }
            public TTReportField NewField12022 { get {return Body().NewField12022;} }
            public TTReportField NewField112022 { get {return Body().NewField112022;} }
            public TTReportField NewField1120211 { get {return Body().NewField1120211;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField1301 { get {return Body().NewField1301;} }
            public TTReportField NewField13021 { get {return Body().NewField13021;} }
            public TTReportField NewField112011 { get {return Body().NewField112011;} }
            public TTReportField NewField122021 { get {return Body().NewField122021;} }
            public TTReportField NewField1220211 { get {return Body().NewField1220211;} }
            public TTReportField NewField11120211 { get {return Body().NewField11120211;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField NewField1302 { get {return Body().NewField1302;} }
            public TTReportField NewField13022 { get {return Body().NewField13022;} }
            public TTReportField NewField112012 { get {return Body().NewField112012;} }
            public TTReportField NewField122022 { get {return Body().NewField122022;} }
            public TTReportField NewField1220212 { get {return Body().NewField1220212;} }
            public TTReportField NewField11120212 { get {return Body().NewField11120212;} }
            public TTReportField NewField114 { get {return Body().NewField114;} }
            public TTReportField NewField1303 { get {return Body().NewField1303;} }
            public TTReportField NewField13023 { get {return Body().NewField13023;} }
            public TTReportField NewField112013 { get {return Body().NewField112013;} }
            public TTReportField NewField122023 { get {return Body().NewField122023;} }
            public TTReportField NewField1220213 { get {return Body().NewField1220213;} }
            public TTReportField NewField11120213 { get {return Body().NewField11120213;} }
            public TTReportField NewField115 { get {return Body().NewField115;} }
            public TTReportField NewField1304 { get {return Body().NewField1304;} }
            public TTReportField NewField13024 { get {return Body().NewField13024;} }
            public TTReportField NewField112014 { get {return Body().NewField112014;} }
            public TTReportField NewField122024 { get {return Body().NewField122024;} }
            public TTReportField NewField1220214 { get {return Body().NewField1220214;} }
            public TTReportField NewField11120214 { get {return Body().NewField11120214;} }
            public TTReportField NewField1211 { get {return Body().NewField1211;} }
            public TTReportField NewField11031 { get {return Body().NewField11031;} }
            public TTReportField NewField112031 { get {return Body().NewField112031;} }
            public TTReportField NewField1110211 { get {return Body().NewField1110211;} }
            public TTReportField NewField1120221 { get {return Body().NewField1120221;} }
            public TTReportField NewField11120221 { get {return Body().NewField11120221;} }
            public TTReportField NewField111202111 { get {return Body().NewField111202111;} }
            public TTReportField NewField1311 { get {return Body().NewField1311;} }
            public TTReportField NewField12031 { get {return Body().NewField12031;} }
            public TTReportField NewField122031 { get {return Body().NewField122031;} }
            public TTReportField NewField1210211 { get {return Body().NewField1210211;} }
            public TTReportField NewField1220221 { get {return Body().NewField1220221;} }
            public TTReportField NewField12120221 { get {return Body().NewField12120221;} }
            public TTReportField NewField121202111 { get {return Body().NewField121202111;} }
            public TTReportField NewField1411 { get {return Body().NewField1411;} }
            public TTReportField NewField13031 { get {return Body().NewField13031;} }
            public TTReportField NewField132031 { get {return Body().NewField132031;} }
            public TTReportField NewField1310211 { get {return Body().NewField1310211;} }
            public TTReportField NewField1320221 { get {return Body().NewField1320221;} }
            public TTReportField NewField13120221 { get {return Body().NewField13120221;} }
            public TTReportField NewField131202111 { get {return Body().NewField131202111;} }
            public TTReportField NewField116 { get {return Body().NewField116;} }
            public TTReportField NewField1305 { get {return Body().NewField1305;} }
            public TTReportField NewField13025 { get {return Body().NewField13025;} }
            public TTReportField NewField112015 { get {return Body().NewField112015;} }
            public TTReportField NewField122025 { get {return Body().NewField122025;} }
            public TTReportField NewField1220215 { get {return Body().NewField1220215;} }
            public TTReportField NewField11120215 { get {return Body().NewField11120215;} }
            public TTReportField NewField1212 { get {return Body().NewField1212;} }
            public TTReportField NewField11032 { get {return Body().NewField11032;} }
            public TTReportField NewField112032 { get {return Body().NewField112032;} }
            public TTReportField NewField1110212 { get {return Body().NewField1110212;} }
            public TTReportField NewField1120222 { get {return Body().NewField1120222;} }
            public TTReportField NewField11120222 { get {return Body().NewField11120222;} }
            public TTReportField NewField111202112 { get {return Body().NewField111202112;} }
            public TTReportField NewField1312 { get {return Body().NewField1312;} }
            public TTReportField NewField12032 { get {return Body().NewField12032;} }
            public TTReportField NewField122032 { get {return Body().NewField122032;} }
            public TTReportField NewField1210212 { get {return Body().NewField1210212;} }
            public TTReportField NewField1220222 { get {return Body().NewField1220222;} }
            public TTReportField NewField12120222 { get {return Body().NewField12120222;} }
            public TTReportField NewField121202112 { get {return Body().NewField121202112;} }
            public TTReportField NewField1412 { get {return Body().NewField1412;} }
            public TTReportField NewField13032 { get {return Body().NewField13032;} }
            public TTReportField NewField132032 { get {return Body().NewField132032;} }
            public TTReportField NewField1310212 { get {return Body().NewField1310212;} }
            public TTReportField NewField1320222 { get {return Body().NewField1320222;} }
            public TTReportField NewField13120222 { get {return Body().NewField13120222;} }
            public TTReportField NewField131202112 { get {return Body().NewField131202112;} }
            public TTReportField NewField1511 { get {return Body().NewField1511;} }
            public TTReportField NewField14031 { get {return Body().NewField14031;} }
            public TTReportField NewField142031 { get {return Body().NewField142031;} }
            public TTReportField NewField1410211 { get {return Body().NewField1410211;} }
            public TTReportField NewField1420221 { get {return Body().NewField1420221;} }
            public TTReportField NewField14120221 { get {return Body().NewField14120221;} }
            public TTReportField NewField141202111 { get {return Body().NewField141202111;} }
            public TTReportField NewField11121 { get {return Body().NewField11121;} }
            public TTReportField NewField113011 { get {return Body().NewField113011;} }
            public TTReportField NewField1130211 { get {return Body().NewField1130211;} }
            public TTReportField NewField11120111 { get {return Body().NewField11120111;} }
            public TTReportField NewField11220211 { get {return Body().NewField11220211;} }
            public TTReportField NewField112202111 { get {return Body().NewField112202111;} }
            public TTReportField NewField1111202111 { get {return Body().NewField1111202111;} }
            public TTReportField NewField11131 { get {return Body().NewField11131;} }
            public TTReportField NewField113021 { get {return Body().NewField113021;} }
            public TTReportField NewField1130221 { get {return Body().NewField1130221;} }
            public TTReportField NewField11120121 { get {return Body().NewField11120121;} }
            public TTReportField NewField11220221 { get {return Body().NewField11220221;} }
            public TTReportField NewField112202121 { get {return Body().NewField112202121;} }
            public TTReportField NewField1111202121 { get {return Body().NewField1111202121;} }
            public TTReportField NewField11141 { get {return Body().NewField11141;} }
            public TTReportField NewField113031 { get {return Body().NewField113031;} }
            public TTReportField NewField1130231 { get {return Body().NewField1130231;} }
            public TTReportField NewField11120131 { get {return Body().NewField11120131;} }
            public TTReportField NewField11220231 { get {return Body().NewField11220231;} }
            public TTReportField NewField112202131 { get {return Body().NewField112202131;} }
            public TTReportField NewField1111202131 { get {return Body().NewField1111202131;} }
            public TTReportField NewField117 { get {return Body().NewField117;} }
            public TTReportField NewField1306 { get {return Body().NewField1306;} }
            public TTReportField NewField13026 { get {return Body().NewField13026;} }
            public TTReportField NewField112016 { get {return Body().NewField112016;} }
            public TTReportField NewField122026 { get {return Body().NewField122026;} }
            public TTReportField NewField1220216 { get {return Body().NewField1220216;} }
            public TTReportField NewField11120216 { get {return Body().NewField11120216;} }
            public TTReportField NewField1213 { get {return Body().NewField1213;} }
            public TTReportField NewField11033 { get {return Body().NewField11033;} }
            public TTReportField NewField112033 { get {return Body().NewField112033;} }
            public TTReportField NewField1110213 { get {return Body().NewField1110213;} }
            public TTReportField NewField1120223 { get {return Body().NewField1120223;} }
            public TTReportField NewField11120223 { get {return Body().NewField11120223;} }
            public TTReportField NewField111202113 { get {return Body().NewField111202113;} }
            public TTReportField NewField1313 { get {return Body().NewField1313;} }
            public TTReportField NewField12033 { get {return Body().NewField12033;} }
            public TTReportField NewField122033 { get {return Body().NewField122033;} }
            public TTReportField NewField1210213 { get {return Body().NewField1210213;} }
            public TTReportField NewField1220223 { get {return Body().NewField1220223;} }
            public TTReportField NewField12120223 { get {return Body().NewField12120223;} }
            public TTReportField NewField121202113 { get {return Body().NewField121202113;} }
            public TTReportField NewField1413 { get {return Body().NewField1413;} }
            public TTReportField NewField13033 { get {return Body().NewField13033;} }
            public TTReportField NewField132033 { get {return Body().NewField132033;} }
            public TTReportField NewField1310213 { get {return Body().NewField1310213;} }
            public TTReportField NewField1320223 { get {return Body().NewField1320223;} }
            public TTReportField NewField13120223 { get {return Body().NewField13120223;} }
            public TTReportField NewField131202113 { get {return Body().NewField131202113;} }
            public TTReportField NewField1512 { get {return Body().NewField1512;} }
            public TTReportField NewField14032 { get {return Body().NewField14032;} }
            public TTReportField NewField142032 { get {return Body().NewField142032;} }
            public TTReportField NewField1410212 { get {return Body().NewField1410212;} }
            public TTReportField NewField1420222 { get {return Body().NewField1420222;} }
            public TTReportField NewField14120222 { get {return Body().NewField14120222;} }
            public TTReportField NewField141202112 { get {return Body().NewField141202112;} }
            public TTReportField NewField11122 { get {return Body().NewField11122;} }
            public TTReportField NewField113012 { get {return Body().NewField113012;} }
            public TTReportField NewField1130212 { get {return Body().NewField1130212;} }
            public TTReportField NewField11120112 { get {return Body().NewField11120112;} }
            public TTReportField NewField11220212 { get {return Body().NewField11220212;} }
            public TTReportField NewField112202112 { get {return Body().NewField112202112;} }
            public TTReportField NewField1111202112 { get {return Body().NewField1111202112;} }
            public TTReportField NewField11132 { get {return Body().NewField11132;} }
            public TTReportField NewField113022 { get {return Body().NewField113022;} }
            public TTReportField NewField1130222 { get {return Body().NewField1130222;} }
            public TTReportField NewField11120122 { get {return Body().NewField11120122;} }
            public TTReportField NewField11220222 { get {return Body().NewField11220222;} }
            public TTReportField NewField112202122 { get {return Body().NewField112202122;} }
            public TTReportField NewField1111202122 { get {return Body().NewField1111202122;} }
            public TTReportField NewField11142 { get {return Body().NewField11142;} }
            public TTReportField NewField113032 { get {return Body().NewField113032;} }
            public TTReportField NewField1130232 { get {return Body().NewField1130232;} }
            public TTReportField NewField11120132 { get {return Body().NewField11120132;} }
            public TTReportField NewField11220232 { get {return Body().NewField11220232;} }
            public TTReportField NewField112202132 { get {return Body().NewField112202132;} }
            public TTReportField NewField1111202132 { get {return Body().NewField1111202132;} }
            public TTReportField NewField1611 { get {return Body().NewField1611;} }
            public TTReportField NewField15031 { get {return Body().NewField15031;} }
            public TTReportField NewField152031 { get {return Body().NewField152031;} }
            public TTReportField NewField1510211 { get {return Body().NewField1510211;} }
            public TTReportField NewField1520221 { get {return Body().NewField1520221;} }
            public TTReportField NewField15120221 { get {return Body().NewField15120221;} }
            public TTReportField NewField151202111 { get {return Body().NewField151202111;} }
            public TTReportField NewField12121 { get {return Body().NewField12121;} }
            public TTReportField NewField123011 { get {return Body().NewField123011;} }
            public TTReportField NewField1230211 { get {return Body().NewField1230211;} }
            public TTReportField NewField12120111 { get {return Body().NewField12120111;} }
            public TTReportField NewField12220211 { get {return Body().NewField12220211;} }
            public TTReportField NewField122202111 { get {return Body().NewField122202111;} }
            public TTReportField NewField1211202111 { get {return Body().NewField1211202111;} }
            public TTReportField NewField12131 { get {return Body().NewField12131;} }
            public TTReportField NewField123021 { get {return Body().NewField123021;} }
            public TTReportField NewField1230221 { get {return Body().NewField1230221;} }
            public TTReportField NewField12120121 { get {return Body().NewField12120121;} }
            public TTReportField NewField12220221 { get {return Body().NewField12220221;} }
            public TTReportField NewField122202121 { get {return Body().NewField122202121;} }
            public TTReportField NewField1211202121 { get {return Body().NewField1211202121;} }
            public TTReportField NewField12141 { get {return Body().NewField12141;} }
            public TTReportField NewField123031 { get {return Body().NewField123031;} }
            public TTReportField NewField1230231 { get {return Body().NewField1230231;} }
            public TTReportField NewField12120131 { get {return Body().NewField12120131;} }
            public TTReportField NewField12220231 { get {return Body().NewField12220231;} }
            public TTReportField NewField122202131 { get {return Body().NewField122202131;} }
            public TTReportField NewField1211202131 { get {return Body().NewField1211202131;} }
            public TTReportField NewField114121 { get {return Body().NewField114121;} }
            public TTReportField NewField114122 { get {return Body().NewField114122;} }
            public TTReportField NewField1120321 { get {return Body().NewField1120321;} }
            public TTReportField NewField11220321 { get {return Body().NewField11220321;} }
            public TTReportField NewField1130321 { get {return Body().NewField1130321;} }
            public TTReportField NewField11320321 { get {return Body().NewField11320321;} }
            public TTReportField NewField113102121 { get {return Body().NewField113102121;} }
            public TTReportField NewField113202221 { get {return Body().NewField113202221;} }
            public TTReportField NewField1131202221 { get {return Body().NewField1131202221;} }
            public TTReportField NewField113102122 { get {return Body().NewField113102122;} }
            public TTReportField NewField113202222 { get {return Body().NewField113202222;} }
            public TTReportField NewField1131202222 { get {return Body().NewField1131202222;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
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
                list[0] = new TTReportNqlData<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>("GetExistingPhysiotherapyUnits", PhysiotherapyOrder.GetExistingPhysiotherapyUnits((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST)));
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
                public PhysicalTherapyRehabilitation MyParentReport
                {
                    get { return (PhysicalTherapyRehabilitation)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField5;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField19;
                public TTReportField NameSurname;
                public TTReportField BirthDate;
                public TTReportField NewField172;
                public TTReportField NewField6;
                public TTReportField NewField20;
                public TTReportField NewField102;
                public TTReportField NewField1201;
                public TTReportField NewField1202;
                public TTReportField NewField12021;
                public TTReportField NewField112021;
                public TTReportField NewField21;
                public TTReportField NewField103;
                public TTReportField NewField1203;
                public TTReportField NewField11021;
                public TTReportField NewField12022;
                public TTReportField NewField112022;
                public TTReportField NewField1120211;
                public TTReportField NewField112;
                public TTReportField NewField1301;
                public TTReportField NewField13021;
                public TTReportField NewField112011;
                public TTReportField NewField122021;
                public TTReportField NewField1220211;
                public TTReportField NewField11120211;
                public TTReportField NewField113;
                public TTReportField NewField1302;
                public TTReportField NewField13022;
                public TTReportField NewField112012;
                public TTReportField NewField122022;
                public TTReportField NewField1220212;
                public TTReportField NewField11120212;
                public TTReportField NewField114;
                public TTReportField NewField1303;
                public TTReportField NewField13023;
                public TTReportField NewField112013;
                public TTReportField NewField122023;
                public TTReportField NewField1220213;
                public TTReportField NewField11120213;
                public TTReportField NewField115;
                public TTReportField NewField1304;
                public TTReportField NewField13024;
                public TTReportField NewField112014;
                public TTReportField NewField122024;
                public TTReportField NewField1220214;
                public TTReportField NewField11120214;
                public TTReportField NewField1211;
                public TTReportField NewField11031;
                public TTReportField NewField112031;
                public TTReportField NewField1110211;
                public TTReportField NewField1120221;
                public TTReportField NewField11120221;
                public TTReportField NewField111202111;
                public TTReportField NewField1311;
                public TTReportField NewField12031;
                public TTReportField NewField122031;
                public TTReportField NewField1210211;
                public TTReportField NewField1220221;
                public TTReportField NewField12120221;
                public TTReportField NewField121202111;
                public TTReportField NewField1411;
                public TTReportField NewField13031;
                public TTReportField NewField132031;
                public TTReportField NewField1310211;
                public TTReportField NewField1320221;
                public TTReportField NewField13120221;
                public TTReportField NewField131202111;
                public TTReportField NewField116;
                public TTReportField NewField1305;
                public TTReportField NewField13025;
                public TTReportField NewField112015;
                public TTReportField NewField122025;
                public TTReportField NewField1220215;
                public TTReportField NewField11120215;
                public TTReportField NewField1212;
                public TTReportField NewField11032;
                public TTReportField NewField112032;
                public TTReportField NewField1110212;
                public TTReportField NewField1120222;
                public TTReportField NewField11120222;
                public TTReportField NewField111202112;
                public TTReportField NewField1312;
                public TTReportField NewField12032;
                public TTReportField NewField122032;
                public TTReportField NewField1210212;
                public TTReportField NewField1220222;
                public TTReportField NewField12120222;
                public TTReportField NewField121202112;
                public TTReportField NewField1412;
                public TTReportField NewField13032;
                public TTReportField NewField132032;
                public TTReportField NewField1310212;
                public TTReportField NewField1320222;
                public TTReportField NewField13120222;
                public TTReportField NewField131202112;
                public TTReportField NewField1511;
                public TTReportField NewField14031;
                public TTReportField NewField142031;
                public TTReportField NewField1410211;
                public TTReportField NewField1420221;
                public TTReportField NewField14120221;
                public TTReportField NewField141202111;
                public TTReportField NewField11121;
                public TTReportField NewField113011;
                public TTReportField NewField1130211;
                public TTReportField NewField11120111;
                public TTReportField NewField11220211;
                public TTReportField NewField112202111;
                public TTReportField NewField1111202111;
                public TTReportField NewField11131;
                public TTReportField NewField113021;
                public TTReportField NewField1130221;
                public TTReportField NewField11120121;
                public TTReportField NewField11220221;
                public TTReportField NewField112202121;
                public TTReportField NewField1111202121;
                public TTReportField NewField11141;
                public TTReportField NewField113031;
                public TTReportField NewField1130231;
                public TTReportField NewField11120131;
                public TTReportField NewField11220231;
                public TTReportField NewField112202131;
                public TTReportField NewField1111202131;
                public TTReportField NewField117;
                public TTReportField NewField1306;
                public TTReportField NewField13026;
                public TTReportField NewField112016;
                public TTReportField NewField122026;
                public TTReportField NewField1220216;
                public TTReportField NewField11120216;
                public TTReportField NewField1213;
                public TTReportField NewField11033;
                public TTReportField NewField112033;
                public TTReportField NewField1110213;
                public TTReportField NewField1120223;
                public TTReportField NewField11120223;
                public TTReportField NewField111202113;
                public TTReportField NewField1313;
                public TTReportField NewField12033;
                public TTReportField NewField122033;
                public TTReportField NewField1210213;
                public TTReportField NewField1220223;
                public TTReportField NewField12120223;
                public TTReportField NewField121202113;
                public TTReportField NewField1413;
                public TTReportField NewField13033;
                public TTReportField NewField132033;
                public TTReportField NewField1310213;
                public TTReportField NewField1320223;
                public TTReportField NewField13120223;
                public TTReportField NewField131202113;
                public TTReportField NewField1512;
                public TTReportField NewField14032;
                public TTReportField NewField142032;
                public TTReportField NewField1410212;
                public TTReportField NewField1420222;
                public TTReportField NewField14120222;
                public TTReportField NewField141202112;
                public TTReportField NewField11122;
                public TTReportField NewField113012;
                public TTReportField NewField1130212;
                public TTReportField NewField11120112;
                public TTReportField NewField11220212;
                public TTReportField NewField112202112;
                public TTReportField NewField1111202112;
                public TTReportField NewField11132;
                public TTReportField NewField113022;
                public TTReportField NewField1130222;
                public TTReportField NewField11120122;
                public TTReportField NewField11220222;
                public TTReportField NewField112202122;
                public TTReportField NewField1111202122;
                public TTReportField NewField11142;
                public TTReportField NewField113032;
                public TTReportField NewField1130232;
                public TTReportField NewField11120132;
                public TTReportField NewField11220232;
                public TTReportField NewField112202132;
                public TTReportField NewField1111202132;
                public TTReportField NewField1611;
                public TTReportField NewField15031;
                public TTReportField NewField152031;
                public TTReportField NewField1510211;
                public TTReportField NewField1520221;
                public TTReportField NewField15120221;
                public TTReportField NewField151202111;
                public TTReportField NewField12121;
                public TTReportField NewField123011;
                public TTReportField NewField1230211;
                public TTReportField NewField12120111;
                public TTReportField NewField12220211;
                public TTReportField NewField122202111;
                public TTReportField NewField1211202111;
                public TTReportField NewField12131;
                public TTReportField NewField123021;
                public TTReportField NewField1230221;
                public TTReportField NewField12120121;
                public TTReportField NewField12220221;
                public TTReportField NewField122202121;
                public TTReportField NewField1211202121;
                public TTReportField NewField12141;
                public TTReportField NewField123031;
                public TTReportField NewField1230231;
                public TTReportField NewField12120131;
                public TTReportField NewField12220231;
                public TTReportField NewField122202131;
                public TTReportField NewField1211202131;
                public TTReportField NewField114121;
                public TTReportField NewField114122;
                public TTReportField NewField1120321;
                public TTReportField NewField11220321;
                public TTReportField NewField1130321;
                public TTReportField NewField11320321;
                public TTReportField NewField113102121;
                public TTReportField NewField113202221;
                public TTReportField NewField1131202221;
                public TTReportField NewField113102122;
                public TTReportField NewField113202222;
                public TTReportField NewField1131202222;
                public TTReportField NewField7;
                public TTReportField NewField22; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 227;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 32, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"Döküman Kodu     :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 8, 49, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.Value = @"FİZ.FR.239";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 8, 68, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.Value = @"Yayın Tarihi  :";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 8, 97, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.Value = @"14.10.2016";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 8, 122, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.Value = @"Revizyon Tarihi:";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 8, 151, 13, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 8, 180, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.Value = @"Revizyon Numarası :";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 8, 205, 13, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 13, 43, 18, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Ünitenin Adı";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 18, 43, 23, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Hasta Adı Soyadı";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 23, 43, 28, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Doğum Tarihi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 28, 43, 33, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Protokol Numarası";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 13, 45, 18, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 18, 45, 23, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @":";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 23, 45, 28, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 28, 45, 33, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 13, 205, 18, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"{#NAME#}";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 18, 205, 23, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.DrawStyle = DrawStyleConstants.vbSolid;
                    NameSurname.TextFont.Bold = true;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 23, 205, 28, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.DrawStyle = DrawStyleConstants.vbSolid;
                    BirthDate.TextFormat = @"dd/MM/yyyy";
                    BirthDate.TextFont.Bold = true;
                    BirthDate.TextFont.CharSet = 162;
                    BirthDate.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 28, 205, 33, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.TextFont.Bold = true;
                    NewField172.TextFont.CharSet = 162;
                    NewField172.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 33, 16, 43, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Sıra
No";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 33, 35, 43, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.MultiLine = EvetHayirEnum.ehEvet;
                    NewField20.WordBreak = EvetHayirEnum.ehEvet;
                    NewField20.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"Seans
Tarihi";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 33, 54, 43, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField102.MultiLine = EvetHayirEnum.ehEvet;
                    NewField102.WordBreak = EvetHayirEnum.ehEvet;
                    NewField102.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"Başlangıç
Saati";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 33, 73, 43, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1201.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1201.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1201.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1201.TextFont.Bold = true;
                    NewField1201.TextFont.CharSet = 162;
                    NewField1201.Value = @"Bitiş
Saati";

                    NewField1202 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 33, 107, 43, false);
                    NewField1202.Name = "NewField1202";
                    NewField1202.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1202.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1202.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1202.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1202.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1202.TextFont.Bold = true;
                    NewField1202.TextFont.CharSet = 162;
                    NewField1202.Value = @"Sorumlu FTR Uzm.
Ünvanı/İmzası";

                    NewField12021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 33, 141, 43, false);
                    NewField12021.Name = "NewField12021";
                    NewField12021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12021.TextFont.Bold = true;
                    NewField12021.TextFont.CharSet = 162;
                    NewField12021.Value = @"Fizyoterapist
Ünvanı/İmzası";

                    NewField112021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 33, 205, 43, false);
                    NewField112021.Name = "NewField112021";
                    NewField112021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112021.TextFont.Bold = true;
                    NewField112021.TextFont.CharSet = 162;
                    NewField112021.Value = @"Hastanın İmzası Yoksa
Parmak İzi veya Yakını İmza ve Tel.";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 43, 16, 49, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"1";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 43, 35, 49, false);
                    NewField103.Name = "NewField103";
                    NewField103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField103.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField103.MultiLine = EvetHayirEnum.ehEvet;
                    NewField103.WordBreak = EvetHayirEnum.ehEvet;
                    NewField103.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField103.TextFont.Bold = true;
                    NewField103.TextFont.CharSet = 162;
                    NewField103.Value = @"";

                    NewField1203 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 43, 54, 49, false);
                    NewField1203.Name = "NewField1203";
                    NewField1203.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1203.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1203.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1203.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1203.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1203.TextFont.Bold = true;
                    NewField1203.TextFont.CharSet = 162;
                    NewField1203.Value = @"";

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 43, 73, 49, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11021.TextFont.Bold = true;
                    NewField11021.TextFont.CharSet = 162;
                    NewField11021.Value = @"";

                    NewField12022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 43, 107, 49, false);
                    NewField12022.Name = "NewField12022";
                    NewField12022.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12022.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12022.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12022.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12022.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12022.TextFont.Bold = true;
                    NewField12022.TextFont.CharSet = 162;
                    NewField12022.Value = @"";

                    NewField112022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 43, 141, 49, false);
                    NewField112022.Name = "NewField112022";
                    NewField112022.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112022.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112022.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112022.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112022.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112022.TextFont.Bold = true;
                    NewField112022.TextFont.CharSet = 162;
                    NewField112022.Value = @"";

                    NewField1120211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 43, 205, 49, false);
                    NewField1120211.Name = "NewField1120211";
                    NewField1120211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1120211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1120211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1120211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1120211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1120211.TextFont.Bold = true;
                    NewField1120211.TextFont.CharSet = 162;
                    NewField1120211.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 49, 16, 55, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"2";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 49, 35, 55, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1301.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1301.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1301.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1301.TextFont.Bold = true;
                    NewField1301.TextFont.CharSet = 162;
                    NewField1301.Value = @"";

                    NewField13021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 49, 54, 55, false);
                    NewField13021.Name = "NewField13021";
                    NewField13021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13021.TextFont.Bold = true;
                    NewField13021.TextFont.CharSet = 162;
                    NewField13021.Value = @"";

                    NewField112011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 49, 73, 55, false);
                    NewField112011.Name = "NewField112011";
                    NewField112011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112011.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112011.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112011.TextFont.Bold = true;
                    NewField112011.TextFont.CharSet = 162;
                    NewField112011.Value = @"";

                    NewField122021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 49, 107, 55, false);
                    NewField122021.Name = "NewField122021";
                    NewField122021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122021.TextFont.Bold = true;
                    NewField122021.TextFont.CharSet = 162;
                    NewField122021.Value = @"";

                    NewField1220211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 49, 141, 55, false);
                    NewField1220211.Name = "NewField1220211";
                    NewField1220211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220211.TextFont.Bold = true;
                    NewField1220211.TextFont.CharSet = 162;
                    NewField1220211.Value = @"";

                    NewField11120211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 49, 205, 55, false);
                    NewField11120211.Name = "NewField11120211";
                    NewField11120211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120211.TextFont.Bold = true;
                    NewField11120211.TextFont.CharSet = 162;
                    NewField11120211.Value = @"";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 55, 16, 61, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"3";

                    NewField1302 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 55, 35, 61, false);
                    NewField1302.Name = "NewField1302";
                    NewField1302.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1302.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1302.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1302.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1302.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1302.TextFont.Bold = true;
                    NewField1302.TextFont.CharSet = 162;
                    NewField1302.Value = @"";

                    NewField13022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 55, 54, 61, false);
                    NewField13022.Name = "NewField13022";
                    NewField13022.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13022.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13022.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13022.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13022.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13022.TextFont.Bold = true;
                    NewField13022.TextFont.CharSet = 162;
                    NewField13022.Value = @"";

                    NewField112012 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 55, 73, 61, false);
                    NewField112012.Name = "NewField112012";
                    NewField112012.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112012.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112012.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112012.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112012.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112012.TextFont.Bold = true;
                    NewField112012.TextFont.CharSet = 162;
                    NewField112012.Value = @"";

                    NewField122022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 55, 107, 61, false);
                    NewField122022.Name = "NewField122022";
                    NewField122022.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122022.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122022.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122022.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122022.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122022.TextFont.Bold = true;
                    NewField122022.TextFont.CharSet = 162;
                    NewField122022.Value = @"";

                    NewField1220212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 55, 141, 61, false);
                    NewField1220212.Name = "NewField1220212";
                    NewField1220212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220212.TextFont.Bold = true;
                    NewField1220212.TextFont.CharSet = 162;
                    NewField1220212.Value = @"";

                    NewField11120212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 55, 205, 61, false);
                    NewField11120212.Name = "NewField11120212";
                    NewField11120212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120212.TextFont.Bold = true;
                    NewField11120212.TextFont.CharSet = 162;
                    NewField11120212.Value = @"";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 61, 16, 67, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField114.TextFont.Bold = true;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"4";

                    NewField1303 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 61, 35, 67, false);
                    NewField1303.Name = "NewField1303";
                    NewField1303.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1303.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1303.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1303.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1303.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1303.TextFont.Bold = true;
                    NewField1303.TextFont.CharSet = 162;
                    NewField1303.Value = @"";

                    NewField13023 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 61, 54, 67, false);
                    NewField13023.Name = "NewField13023";
                    NewField13023.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13023.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13023.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13023.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13023.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13023.TextFont.Bold = true;
                    NewField13023.TextFont.CharSet = 162;
                    NewField13023.Value = @"";

                    NewField112013 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 61, 73, 67, false);
                    NewField112013.Name = "NewField112013";
                    NewField112013.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112013.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112013.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112013.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112013.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112013.TextFont.Bold = true;
                    NewField112013.TextFont.CharSet = 162;
                    NewField112013.Value = @"";

                    NewField122023 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 61, 107, 67, false);
                    NewField122023.Name = "NewField122023";
                    NewField122023.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122023.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122023.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122023.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122023.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122023.TextFont.Bold = true;
                    NewField122023.TextFont.CharSet = 162;
                    NewField122023.Value = @"";

                    NewField1220213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 61, 141, 67, false);
                    NewField1220213.Name = "NewField1220213";
                    NewField1220213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220213.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220213.TextFont.Bold = true;
                    NewField1220213.TextFont.CharSet = 162;
                    NewField1220213.Value = @"";

                    NewField11120213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 61, 205, 67, false);
                    NewField11120213.Name = "NewField11120213";
                    NewField11120213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120213.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120213.TextFont.Bold = true;
                    NewField11120213.TextFont.CharSet = 162;
                    NewField11120213.Value = @"";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 67, 16, 73, false);
                    NewField115.Name = "NewField115";
                    NewField115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115.MultiLine = EvetHayirEnum.ehEvet;
                    NewField115.WordBreak = EvetHayirEnum.ehEvet;
                    NewField115.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField115.TextFont.Bold = true;
                    NewField115.TextFont.CharSet = 162;
                    NewField115.Value = @"5";

                    NewField1304 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 67, 35, 73, false);
                    NewField1304.Name = "NewField1304";
                    NewField1304.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1304.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1304.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1304.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1304.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1304.TextFont.Bold = true;
                    NewField1304.TextFont.CharSet = 162;
                    NewField1304.Value = @"";

                    NewField13024 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 67, 54, 73, false);
                    NewField13024.Name = "NewField13024";
                    NewField13024.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13024.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13024.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13024.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13024.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13024.TextFont.Bold = true;
                    NewField13024.TextFont.CharSet = 162;
                    NewField13024.Value = @"";

                    NewField112014 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 67, 73, 73, false);
                    NewField112014.Name = "NewField112014";
                    NewField112014.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112014.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112014.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112014.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112014.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112014.TextFont.Bold = true;
                    NewField112014.TextFont.CharSet = 162;
                    NewField112014.Value = @"";

                    NewField122024 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 67, 107, 73, false);
                    NewField122024.Name = "NewField122024";
                    NewField122024.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122024.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122024.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122024.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122024.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122024.TextFont.Bold = true;
                    NewField122024.TextFont.CharSet = 162;
                    NewField122024.Value = @"";

                    NewField1220214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 67, 141, 73, false);
                    NewField1220214.Name = "NewField1220214";
                    NewField1220214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220214.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220214.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220214.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220214.TextFont.Bold = true;
                    NewField1220214.TextFont.CharSet = 162;
                    NewField1220214.Value = @"";

                    NewField11120214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 67, 205, 73, false);
                    NewField11120214.Name = "NewField11120214";
                    NewField11120214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120214.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120214.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120214.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120214.TextFont.Bold = true;
                    NewField11120214.TextFont.CharSet = 162;
                    NewField11120214.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 73, 16, 79, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"6";

                    NewField11031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 73, 35, 79, false);
                    NewField11031.Name = "NewField11031";
                    NewField11031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11031.TextFont.Bold = true;
                    NewField11031.TextFont.CharSet = 162;
                    NewField11031.Value = @"";

                    NewField112031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 73, 54, 79, false);
                    NewField112031.Name = "NewField112031";
                    NewField112031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112031.TextFont.Bold = true;
                    NewField112031.TextFont.CharSet = 162;
                    NewField112031.Value = @"";

                    NewField1110211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 73, 73, 79, false);
                    NewField1110211.Name = "NewField1110211";
                    NewField1110211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1110211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1110211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1110211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1110211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1110211.TextFont.Bold = true;
                    NewField1110211.TextFont.CharSet = 162;
                    NewField1110211.Value = @"";

                    NewField1120221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 73, 107, 79, false);
                    NewField1120221.Name = "NewField1120221";
                    NewField1120221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1120221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1120221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1120221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1120221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1120221.TextFont.Bold = true;
                    NewField1120221.TextFont.CharSet = 162;
                    NewField1120221.Value = @"";

                    NewField11120221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 73, 141, 79, false);
                    NewField11120221.Name = "NewField11120221";
                    NewField11120221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120221.TextFont.Bold = true;
                    NewField11120221.TextFont.CharSet = 162;
                    NewField11120221.Value = @"";

                    NewField111202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 73, 205, 79, false);
                    NewField111202111.Name = "NewField111202111";
                    NewField111202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111202111.TextFont.Bold = true;
                    NewField111202111.TextFont.CharSet = 162;
                    NewField111202111.Value = @"";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 79, 16, 85, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @"7";

                    NewField12031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 79, 35, 85, false);
                    NewField12031.Name = "NewField12031";
                    NewField12031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12031.TextFont.Bold = true;
                    NewField12031.TextFont.CharSet = 162;
                    NewField12031.Value = @"";

                    NewField122031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 79, 54, 85, false);
                    NewField122031.Name = "NewField122031";
                    NewField122031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122031.TextFont.Bold = true;
                    NewField122031.TextFont.CharSet = 162;
                    NewField122031.Value = @"";

                    NewField1210211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 79, 73, 85, false);
                    NewField1210211.Name = "NewField1210211";
                    NewField1210211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1210211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1210211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1210211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1210211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1210211.TextFont.Bold = true;
                    NewField1210211.TextFont.CharSet = 162;
                    NewField1210211.Value = @"";

                    NewField1220221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 79, 107, 85, false);
                    NewField1220221.Name = "NewField1220221";
                    NewField1220221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220221.TextFont.Bold = true;
                    NewField1220221.TextFont.CharSet = 162;
                    NewField1220221.Value = @"";

                    NewField12120221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 79, 141, 85, false);
                    NewField12120221.Name = "NewField12120221";
                    NewField12120221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12120221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12120221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12120221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12120221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12120221.TextFont.Bold = true;
                    NewField12120221.TextFont.CharSet = 162;
                    NewField12120221.Value = @"";

                    NewField121202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 79, 205, 85, false);
                    NewField121202111.Name = "NewField121202111";
                    NewField121202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121202111.TextFont.Bold = true;
                    NewField121202111.TextFont.CharSet = 162;
                    NewField121202111.Value = @"";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 85, 16, 91, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1411.TextFont.Bold = true;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"8";

                    NewField13031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 85, 35, 91, false);
                    NewField13031.Name = "NewField13031";
                    NewField13031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13031.TextFont.Bold = true;
                    NewField13031.TextFont.CharSet = 162;
                    NewField13031.Value = @"";

                    NewField132031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 85, 54, 91, false);
                    NewField132031.Name = "NewField132031";
                    NewField132031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField132031.TextFont.Bold = true;
                    NewField132031.TextFont.CharSet = 162;
                    NewField132031.Value = @"";

                    NewField1310211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 85, 73, 91, false);
                    NewField1310211.Name = "NewField1310211";
                    NewField1310211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1310211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1310211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1310211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1310211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1310211.TextFont.Bold = true;
                    NewField1310211.TextFont.CharSet = 162;
                    NewField1310211.Value = @"";

                    NewField1320221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 85, 107, 91, false);
                    NewField1320221.Name = "NewField1320221";
                    NewField1320221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1320221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1320221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1320221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1320221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1320221.TextFont.Bold = true;
                    NewField1320221.TextFont.CharSet = 162;
                    NewField1320221.Value = @"";

                    NewField13120221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 85, 141, 91, false);
                    NewField13120221.Name = "NewField13120221";
                    NewField13120221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13120221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13120221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13120221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13120221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13120221.TextFont.Bold = true;
                    NewField13120221.TextFont.CharSet = 162;
                    NewField13120221.Value = @"";

                    NewField131202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 85, 205, 91, false);
                    NewField131202111.Name = "NewField131202111";
                    NewField131202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131202111.TextFont.Bold = true;
                    NewField131202111.TextFont.CharSet = 162;
                    NewField131202111.Value = @"";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 91, 16, 97, false);
                    NewField116.Name = "NewField116";
                    NewField116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116.MultiLine = EvetHayirEnum.ehEvet;
                    NewField116.WordBreak = EvetHayirEnum.ehEvet;
                    NewField116.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField116.TextFont.Bold = true;
                    NewField116.TextFont.CharSet = 162;
                    NewField116.Value = @"9";

                    NewField1305 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 91, 35, 97, false);
                    NewField1305.Name = "NewField1305";
                    NewField1305.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1305.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1305.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1305.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1305.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1305.TextFont.Bold = true;
                    NewField1305.TextFont.CharSet = 162;
                    NewField1305.Value = @"";

                    NewField13025 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 91, 54, 97, false);
                    NewField13025.Name = "NewField13025";
                    NewField13025.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13025.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13025.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13025.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13025.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13025.TextFont.Bold = true;
                    NewField13025.TextFont.CharSet = 162;
                    NewField13025.Value = @"";

                    NewField112015 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 91, 73, 97, false);
                    NewField112015.Name = "NewField112015";
                    NewField112015.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112015.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112015.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112015.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112015.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112015.TextFont.Bold = true;
                    NewField112015.TextFont.CharSet = 162;
                    NewField112015.Value = @"";

                    NewField122025 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 91, 107, 97, false);
                    NewField122025.Name = "NewField122025";
                    NewField122025.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122025.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122025.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122025.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122025.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122025.TextFont.Bold = true;
                    NewField122025.TextFont.CharSet = 162;
                    NewField122025.Value = @"";

                    NewField1220215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 91, 141, 97, false);
                    NewField1220215.Name = "NewField1220215";
                    NewField1220215.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220215.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220215.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220215.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220215.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220215.TextFont.Bold = true;
                    NewField1220215.TextFont.CharSet = 162;
                    NewField1220215.Value = @"";

                    NewField11120215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 91, 205, 97, false);
                    NewField11120215.Name = "NewField11120215";
                    NewField11120215.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120215.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120215.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120215.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120215.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120215.TextFont.Bold = true;
                    NewField11120215.TextFont.CharSet = 162;
                    NewField11120215.Value = @"";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 97, 16, 103, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"10";

                    NewField11032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 97, 35, 103, false);
                    NewField11032.Name = "NewField11032";
                    NewField11032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11032.TextFont.Bold = true;
                    NewField11032.TextFont.CharSet = 162;
                    NewField11032.Value = @"";

                    NewField112032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 97, 54, 103, false);
                    NewField112032.Name = "NewField112032";
                    NewField112032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112032.TextFont.Bold = true;
                    NewField112032.TextFont.CharSet = 162;
                    NewField112032.Value = @"";

                    NewField1110212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 97, 73, 103, false);
                    NewField1110212.Name = "NewField1110212";
                    NewField1110212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1110212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1110212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1110212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1110212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1110212.TextFont.Bold = true;
                    NewField1110212.TextFont.CharSet = 162;
                    NewField1110212.Value = @"";

                    NewField1120222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 97, 107, 103, false);
                    NewField1120222.Name = "NewField1120222";
                    NewField1120222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1120222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1120222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1120222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1120222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1120222.TextFont.Bold = true;
                    NewField1120222.TextFont.CharSet = 162;
                    NewField1120222.Value = @"";

                    NewField11120222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 97, 141, 103, false);
                    NewField11120222.Name = "NewField11120222";
                    NewField11120222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120222.TextFont.Bold = true;
                    NewField11120222.TextFont.CharSet = 162;
                    NewField11120222.Value = @"";

                    NewField111202112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 97, 205, 103, false);
                    NewField111202112.Name = "NewField111202112";
                    NewField111202112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111202112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111202112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111202112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111202112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111202112.TextFont.Bold = true;
                    NewField111202112.TextFont.CharSet = 162;
                    NewField111202112.Value = @"";

                    NewField1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 103, 16, 109, false);
                    NewField1312.Name = "NewField1312";
                    NewField1312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1312.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1312.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1312.TextFont.Bold = true;
                    NewField1312.TextFont.CharSet = 162;
                    NewField1312.Value = @"11";

                    NewField12032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 103, 35, 109, false);
                    NewField12032.Name = "NewField12032";
                    NewField12032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12032.TextFont.Bold = true;
                    NewField12032.TextFont.CharSet = 162;
                    NewField12032.Value = @"";

                    NewField122032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 103, 54, 109, false);
                    NewField122032.Name = "NewField122032";
                    NewField122032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122032.TextFont.Bold = true;
                    NewField122032.TextFont.CharSet = 162;
                    NewField122032.Value = @"";

                    NewField1210212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 103, 73, 109, false);
                    NewField1210212.Name = "NewField1210212";
                    NewField1210212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1210212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1210212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1210212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1210212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1210212.TextFont.Bold = true;
                    NewField1210212.TextFont.CharSet = 162;
                    NewField1210212.Value = @"";

                    NewField1220222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 103, 107, 109, false);
                    NewField1220222.Name = "NewField1220222";
                    NewField1220222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220222.TextFont.Bold = true;
                    NewField1220222.TextFont.CharSet = 162;
                    NewField1220222.Value = @"";

                    NewField12120222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 103, 141, 109, false);
                    NewField12120222.Name = "NewField12120222";
                    NewField12120222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12120222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12120222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12120222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12120222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12120222.TextFont.Bold = true;
                    NewField12120222.TextFont.CharSet = 162;
                    NewField12120222.Value = @"";

                    NewField121202112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 103, 205, 109, false);
                    NewField121202112.Name = "NewField121202112";
                    NewField121202112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121202112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121202112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121202112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121202112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121202112.TextFont.Bold = true;
                    NewField121202112.TextFont.CharSet = 162;
                    NewField121202112.Value = @"";

                    NewField1412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 109, 16, 115, false);
                    NewField1412.Name = "NewField1412";
                    NewField1412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1412.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1412.TextFont.Bold = true;
                    NewField1412.TextFont.CharSet = 162;
                    NewField1412.Value = @"12";

                    NewField13032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 109, 35, 115, false);
                    NewField13032.Name = "NewField13032";
                    NewField13032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13032.TextFont.Bold = true;
                    NewField13032.TextFont.CharSet = 162;
                    NewField13032.Value = @"";

                    NewField132032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 109, 54, 115, false);
                    NewField132032.Name = "NewField132032";
                    NewField132032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField132032.TextFont.Bold = true;
                    NewField132032.TextFont.CharSet = 162;
                    NewField132032.Value = @"";

                    NewField1310212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 109, 73, 115, false);
                    NewField1310212.Name = "NewField1310212";
                    NewField1310212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1310212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1310212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1310212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1310212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1310212.TextFont.Bold = true;
                    NewField1310212.TextFont.CharSet = 162;
                    NewField1310212.Value = @"";

                    NewField1320222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 109, 107, 115, false);
                    NewField1320222.Name = "NewField1320222";
                    NewField1320222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1320222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1320222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1320222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1320222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1320222.TextFont.Bold = true;
                    NewField1320222.TextFont.CharSet = 162;
                    NewField1320222.Value = @"";

                    NewField13120222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 109, 141, 115, false);
                    NewField13120222.Name = "NewField13120222";
                    NewField13120222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13120222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13120222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13120222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13120222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13120222.TextFont.Bold = true;
                    NewField13120222.TextFont.CharSet = 162;
                    NewField13120222.Value = @"";

                    NewField131202112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 109, 205, 115, false);
                    NewField131202112.Name = "NewField131202112";
                    NewField131202112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131202112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131202112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131202112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131202112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131202112.TextFont.Bold = true;
                    NewField131202112.TextFont.CharSet = 162;
                    NewField131202112.Value = @"";

                    NewField1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 115, 16, 121, false);
                    NewField1511.Name = "NewField1511";
                    NewField1511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1511.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1511.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1511.TextFont.Bold = true;
                    NewField1511.TextFont.CharSet = 162;
                    NewField1511.Value = @"13";

                    NewField14031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 115, 35, 121, false);
                    NewField14031.Name = "NewField14031";
                    NewField14031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14031.TextFont.Bold = true;
                    NewField14031.TextFont.CharSet = 162;
                    NewField14031.Value = @"";

                    NewField142031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 115, 54, 121, false);
                    NewField142031.Name = "NewField142031";
                    NewField142031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField142031.TextFont.Bold = true;
                    NewField142031.TextFont.CharSet = 162;
                    NewField142031.Value = @"";

                    NewField1410211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 115, 73, 121, false);
                    NewField1410211.Name = "NewField1410211";
                    NewField1410211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1410211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1410211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1410211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1410211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1410211.TextFont.Bold = true;
                    NewField1410211.TextFont.CharSet = 162;
                    NewField1410211.Value = @"";

                    NewField1420221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 115, 107, 121, false);
                    NewField1420221.Name = "NewField1420221";
                    NewField1420221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1420221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1420221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1420221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1420221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1420221.TextFont.Bold = true;
                    NewField1420221.TextFont.CharSet = 162;
                    NewField1420221.Value = @"";

                    NewField14120221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 115, 141, 121, false);
                    NewField14120221.Name = "NewField14120221";
                    NewField14120221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14120221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14120221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14120221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14120221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14120221.TextFont.Bold = true;
                    NewField14120221.TextFont.CharSet = 162;
                    NewField14120221.Value = @"";

                    NewField141202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 115, 205, 121, false);
                    NewField141202111.Name = "NewField141202111";
                    NewField141202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141202111.TextFont.Bold = true;
                    NewField141202111.TextFont.CharSet = 162;
                    NewField141202111.Value = @"";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 121, 16, 127, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"14";

                    NewField113011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 121, 35, 127, false);
                    NewField113011.Name = "NewField113011";
                    NewField113011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113011.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113011.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113011.TextFont.Bold = true;
                    NewField113011.TextFont.CharSet = 162;
                    NewField113011.Value = @"";

                    NewField1130211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 121, 54, 127, false);
                    NewField1130211.Name = "NewField1130211";
                    NewField1130211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130211.TextFont.Bold = true;
                    NewField1130211.TextFont.CharSet = 162;
                    NewField1130211.Value = @"";

                    NewField11120111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 121, 73, 127, false);
                    NewField11120111.Name = "NewField11120111";
                    NewField11120111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120111.TextFont.Bold = true;
                    NewField11120111.TextFont.CharSet = 162;
                    NewField11120111.Value = @"";

                    NewField11220211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 121, 107, 127, false);
                    NewField11220211.Name = "NewField11220211";
                    NewField11220211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220211.TextFont.Bold = true;
                    NewField11220211.TextFont.CharSet = 162;
                    NewField11220211.Value = @"";

                    NewField112202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 121, 141, 127, false);
                    NewField112202111.Name = "NewField112202111";
                    NewField112202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112202111.TextFont.Bold = true;
                    NewField112202111.TextFont.CharSet = 162;
                    NewField112202111.Value = @"";

                    NewField1111202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 121, 205, 127, false);
                    NewField1111202111.Name = "NewField1111202111";
                    NewField1111202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111202111.TextFont.Bold = true;
                    NewField1111202111.TextFont.CharSet = 162;
                    NewField1111202111.Value = @"";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 127, 16, 133, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11131.TextFont.Bold = true;
                    NewField11131.TextFont.CharSet = 162;
                    NewField11131.Value = @"15";

                    NewField113021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 127, 35, 133, false);
                    NewField113021.Name = "NewField113021";
                    NewField113021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113021.TextFont.Bold = true;
                    NewField113021.TextFont.CharSet = 162;
                    NewField113021.Value = @"";

                    NewField1130221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 127, 54, 133, false);
                    NewField1130221.Name = "NewField1130221";
                    NewField1130221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130221.TextFont.Bold = true;
                    NewField1130221.TextFont.CharSet = 162;
                    NewField1130221.Value = @"";

                    NewField11120121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 127, 73, 133, false);
                    NewField11120121.Name = "NewField11120121";
                    NewField11120121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120121.TextFont.Bold = true;
                    NewField11120121.TextFont.CharSet = 162;
                    NewField11120121.Value = @"";

                    NewField11220221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 127, 107, 133, false);
                    NewField11220221.Name = "NewField11220221";
                    NewField11220221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220221.TextFont.Bold = true;
                    NewField11220221.TextFont.CharSet = 162;
                    NewField11220221.Value = @"";

                    NewField112202121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 127, 141, 133, false);
                    NewField112202121.Name = "NewField112202121";
                    NewField112202121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112202121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112202121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112202121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112202121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112202121.TextFont.Bold = true;
                    NewField112202121.TextFont.CharSet = 162;
                    NewField112202121.Value = @"";

                    NewField1111202121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 127, 205, 133, false);
                    NewField1111202121.Name = "NewField1111202121";
                    NewField1111202121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111202121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111202121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111202121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111202121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111202121.TextFont.Bold = true;
                    NewField1111202121.TextFont.CharSet = 162;
                    NewField1111202121.Value = @"";

                    NewField11141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 133, 16, 139, false);
                    NewField11141.Name = "NewField11141";
                    NewField11141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11141.TextFont.Bold = true;
                    NewField11141.TextFont.CharSet = 162;
                    NewField11141.Value = @"16";

                    NewField113031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 133, 35, 139, false);
                    NewField113031.Name = "NewField113031";
                    NewField113031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113031.TextFont.Bold = true;
                    NewField113031.TextFont.CharSet = 162;
                    NewField113031.Value = @"";

                    NewField1130231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 133, 54, 139, false);
                    NewField1130231.Name = "NewField1130231";
                    NewField1130231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130231.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130231.TextFont.Bold = true;
                    NewField1130231.TextFont.CharSet = 162;
                    NewField1130231.Value = @"";

                    NewField11120131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 133, 73, 139, false);
                    NewField11120131.Name = "NewField11120131";
                    NewField11120131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120131.TextFont.Bold = true;
                    NewField11120131.TextFont.CharSet = 162;
                    NewField11120131.Value = @"";

                    NewField11220231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 133, 107, 139, false);
                    NewField11220231.Name = "NewField11220231";
                    NewField11220231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220231.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220231.TextFont.Bold = true;
                    NewField11220231.TextFont.CharSet = 162;
                    NewField11220231.Value = @"";

                    NewField112202131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 133, 141, 139, false);
                    NewField112202131.Name = "NewField112202131";
                    NewField112202131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112202131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112202131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112202131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112202131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112202131.TextFont.Bold = true;
                    NewField112202131.TextFont.CharSet = 162;
                    NewField112202131.Value = @"";

                    NewField1111202131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 133, 205, 139, false);
                    NewField1111202131.Name = "NewField1111202131";
                    NewField1111202131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111202131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111202131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111202131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111202131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111202131.TextFont.Bold = true;
                    NewField1111202131.TextFont.CharSet = 162;
                    NewField1111202131.Value = @"";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 139, 16, 145, false);
                    NewField117.Name = "NewField117";
                    NewField117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField117.TextFont.Bold = true;
                    NewField117.TextFont.CharSet = 162;
                    NewField117.Value = @"17";

                    NewField1306 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 139, 35, 145, false);
                    NewField1306.Name = "NewField1306";
                    NewField1306.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1306.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1306.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1306.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1306.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1306.TextFont.Bold = true;
                    NewField1306.TextFont.CharSet = 162;
                    NewField1306.Value = @"";

                    NewField13026 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 139, 54, 145, false);
                    NewField13026.Name = "NewField13026";
                    NewField13026.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13026.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13026.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13026.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13026.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13026.TextFont.Bold = true;
                    NewField13026.TextFont.CharSet = 162;
                    NewField13026.Value = @"";

                    NewField112016 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 139, 73, 145, false);
                    NewField112016.Name = "NewField112016";
                    NewField112016.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112016.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112016.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112016.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112016.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112016.TextFont.Bold = true;
                    NewField112016.TextFont.CharSet = 162;
                    NewField112016.Value = @"";

                    NewField122026 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 139, 107, 145, false);
                    NewField122026.Name = "NewField122026";
                    NewField122026.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122026.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122026.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122026.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122026.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122026.TextFont.Bold = true;
                    NewField122026.TextFont.CharSet = 162;
                    NewField122026.Value = @"";

                    NewField1220216 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 139, 141, 145, false);
                    NewField1220216.Name = "NewField1220216";
                    NewField1220216.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220216.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220216.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220216.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220216.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220216.TextFont.Bold = true;
                    NewField1220216.TextFont.CharSet = 162;
                    NewField1220216.Value = @"";

                    NewField11120216 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 139, 205, 145, false);
                    NewField11120216.Name = "NewField11120216";
                    NewField11120216.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120216.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120216.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120216.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120216.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120216.TextFont.Bold = true;
                    NewField11120216.TextFont.CharSet = 162;
                    NewField11120216.Value = @"";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 145, 16, 151, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1213.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"18";

                    NewField11033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 145, 35, 151, false);
                    NewField11033.Name = "NewField11033";
                    NewField11033.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11033.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11033.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11033.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11033.TextFont.Bold = true;
                    NewField11033.TextFont.CharSet = 162;
                    NewField11033.Value = @"";

                    NewField112033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 145, 54, 151, false);
                    NewField112033.Name = "NewField112033";
                    NewField112033.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112033.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112033.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112033.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112033.TextFont.Bold = true;
                    NewField112033.TextFont.CharSet = 162;
                    NewField112033.Value = @"";

                    NewField1110213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 145, 73, 151, false);
                    NewField1110213.Name = "NewField1110213";
                    NewField1110213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1110213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1110213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1110213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1110213.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1110213.TextFont.Bold = true;
                    NewField1110213.TextFont.CharSet = 162;
                    NewField1110213.Value = @"";

                    NewField1120223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 145, 107, 151, false);
                    NewField1120223.Name = "NewField1120223";
                    NewField1120223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1120223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1120223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1120223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1120223.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1120223.TextFont.Bold = true;
                    NewField1120223.TextFont.CharSet = 162;
                    NewField1120223.Value = @"";

                    NewField11120223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 145, 141, 151, false);
                    NewField11120223.Name = "NewField11120223";
                    NewField11120223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120223.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120223.TextFont.Bold = true;
                    NewField11120223.TextFont.CharSet = 162;
                    NewField11120223.Value = @"";

                    NewField111202113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 145, 205, 151, false);
                    NewField111202113.Name = "NewField111202113";
                    NewField111202113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111202113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111202113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111202113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111202113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111202113.TextFont.Bold = true;
                    NewField111202113.TextFont.CharSet = 162;
                    NewField111202113.Value = @"";

                    NewField1313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 151, 16, 157, false);
                    NewField1313.Name = "NewField1313";
                    NewField1313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1313.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1313.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1313.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1313.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1313.TextFont.Bold = true;
                    NewField1313.TextFont.CharSet = 162;
                    NewField1313.Value = @"19";

                    NewField12033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 151, 35, 157, false);
                    NewField12033.Name = "NewField12033";
                    NewField12033.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12033.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12033.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12033.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12033.TextFont.Bold = true;
                    NewField12033.TextFont.CharSet = 162;
                    NewField12033.Value = @"";

                    NewField122033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 151, 54, 157, false);
                    NewField122033.Name = "NewField122033";
                    NewField122033.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122033.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122033.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122033.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122033.TextFont.Bold = true;
                    NewField122033.TextFont.CharSet = 162;
                    NewField122033.Value = @"";

                    NewField1210213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 151, 73, 157, false);
                    NewField1210213.Name = "NewField1210213";
                    NewField1210213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1210213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1210213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1210213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1210213.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1210213.TextFont.Bold = true;
                    NewField1210213.TextFont.CharSet = 162;
                    NewField1210213.Value = @"";

                    NewField1220223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 151, 107, 157, false);
                    NewField1220223.Name = "NewField1220223";
                    NewField1220223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1220223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1220223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1220223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1220223.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1220223.TextFont.Bold = true;
                    NewField1220223.TextFont.CharSet = 162;
                    NewField1220223.Value = @"";

                    NewField12120223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 151, 141, 157, false);
                    NewField12120223.Name = "NewField12120223";
                    NewField12120223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12120223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12120223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12120223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12120223.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12120223.TextFont.Bold = true;
                    NewField12120223.TextFont.CharSet = 162;
                    NewField12120223.Value = @"";

                    NewField121202113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 151, 205, 157, false);
                    NewField121202113.Name = "NewField121202113";
                    NewField121202113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121202113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121202113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121202113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121202113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121202113.TextFont.Bold = true;
                    NewField121202113.TextFont.CharSet = 162;
                    NewField121202113.Value = @"";

                    NewField1413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 157, 16, 163, false);
                    NewField1413.Name = "NewField1413";
                    NewField1413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1413.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1413.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1413.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1413.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1413.TextFont.Bold = true;
                    NewField1413.TextFont.CharSet = 162;
                    NewField1413.Value = @"20";

                    NewField13033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 157, 35, 163, false);
                    NewField13033.Name = "NewField13033";
                    NewField13033.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13033.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13033.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13033.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13033.TextFont.Bold = true;
                    NewField13033.TextFont.CharSet = 162;
                    NewField13033.Value = @"";

                    NewField132033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 157, 54, 163, false);
                    NewField132033.Name = "NewField132033";
                    NewField132033.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132033.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132033.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132033.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField132033.TextFont.Bold = true;
                    NewField132033.TextFont.CharSet = 162;
                    NewField132033.Value = @"";

                    NewField1310213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 157, 73, 163, false);
                    NewField1310213.Name = "NewField1310213";
                    NewField1310213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1310213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1310213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1310213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1310213.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1310213.TextFont.Bold = true;
                    NewField1310213.TextFont.CharSet = 162;
                    NewField1310213.Value = @"";

                    NewField1320223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 157, 107, 163, false);
                    NewField1320223.Name = "NewField1320223";
                    NewField1320223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1320223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1320223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1320223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1320223.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1320223.TextFont.Bold = true;
                    NewField1320223.TextFont.CharSet = 162;
                    NewField1320223.Value = @"";

                    NewField13120223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 157, 141, 163, false);
                    NewField13120223.Name = "NewField13120223";
                    NewField13120223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13120223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13120223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13120223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13120223.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13120223.TextFont.Bold = true;
                    NewField13120223.TextFont.CharSet = 162;
                    NewField13120223.Value = @"";

                    NewField131202113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 157, 205, 163, false);
                    NewField131202113.Name = "NewField131202113";
                    NewField131202113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131202113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131202113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131202113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131202113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131202113.TextFont.Bold = true;
                    NewField131202113.TextFont.CharSet = 162;
                    NewField131202113.Value = @"";

                    NewField1512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 163, 16, 169, false);
                    NewField1512.Name = "NewField1512";
                    NewField1512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1512.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1512.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1512.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1512.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1512.TextFont.Bold = true;
                    NewField1512.TextFont.CharSet = 162;
                    NewField1512.Value = @"21";

                    NewField14032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 163, 35, 169, false);
                    NewField14032.Name = "NewField14032";
                    NewField14032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14032.TextFont.Bold = true;
                    NewField14032.TextFont.CharSet = 162;
                    NewField14032.Value = @"";

                    NewField142032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 163, 54, 169, false);
                    NewField142032.Name = "NewField142032";
                    NewField142032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField142032.TextFont.Bold = true;
                    NewField142032.TextFont.CharSet = 162;
                    NewField142032.Value = @"";

                    NewField1410212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 163, 73, 169, false);
                    NewField1410212.Name = "NewField1410212";
                    NewField1410212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1410212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1410212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1410212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1410212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1410212.TextFont.Bold = true;
                    NewField1410212.TextFont.CharSet = 162;
                    NewField1410212.Value = @"";

                    NewField1420222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 163, 107, 169, false);
                    NewField1420222.Name = "NewField1420222";
                    NewField1420222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1420222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1420222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1420222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1420222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1420222.TextFont.Bold = true;
                    NewField1420222.TextFont.CharSet = 162;
                    NewField1420222.Value = @"";

                    NewField14120222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 163, 141, 169, false);
                    NewField14120222.Name = "NewField14120222";
                    NewField14120222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14120222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14120222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14120222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14120222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14120222.TextFont.Bold = true;
                    NewField14120222.TextFont.CharSet = 162;
                    NewField14120222.Value = @"";

                    NewField141202112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 163, 205, 169, false);
                    NewField141202112.Name = "NewField141202112";
                    NewField141202112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141202112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141202112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141202112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141202112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141202112.TextFont.Bold = true;
                    NewField141202112.TextFont.CharSet = 162;
                    NewField141202112.Value = @"";

                    NewField11122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 169, 16, 175, false);
                    NewField11122.Name = "NewField11122";
                    NewField11122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11122.TextFont.Bold = true;
                    NewField11122.TextFont.CharSet = 162;
                    NewField11122.Value = @"22";

                    NewField113012 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 169, 35, 175, false);
                    NewField113012.Name = "NewField113012";
                    NewField113012.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113012.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113012.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113012.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113012.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113012.TextFont.Bold = true;
                    NewField113012.TextFont.CharSet = 162;
                    NewField113012.Value = @"";

                    NewField1130212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 169, 54, 175, false);
                    NewField1130212.Name = "NewField1130212";
                    NewField1130212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130212.TextFont.Bold = true;
                    NewField1130212.TextFont.CharSet = 162;
                    NewField1130212.Value = @"";

                    NewField11120112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 169, 73, 175, false);
                    NewField11120112.Name = "NewField11120112";
                    NewField11120112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120112.TextFont.Bold = true;
                    NewField11120112.TextFont.CharSet = 162;
                    NewField11120112.Value = @"";

                    NewField11220212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 169, 107, 175, false);
                    NewField11220212.Name = "NewField11220212";
                    NewField11220212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220212.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220212.TextFont.Bold = true;
                    NewField11220212.TextFont.CharSet = 162;
                    NewField11220212.Value = @"";

                    NewField112202112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 169, 141, 175, false);
                    NewField112202112.Name = "NewField112202112";
                    NewField112202112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112202112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112202112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112202112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112202112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112202112.TextFont.Bold = true;
                    NewField112202112.TextFont.CharSet = 162;
                    NewField112202112.Value = @"";

                    NewField1111202112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 169, 205, 175, false);
                    NewField1111202112.Name = "NewField1111202112";
                    NewField1111202112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111202112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111202112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111202112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111202112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111202112.TextFont.Bold = true;
                    NewField1111202112.TextFont.CharSet = 162;
                    NewField1111202112.Value = @"";

                    NewField11132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 175, 16, 181, false);
                    NewField11132.Name = "NewField11132";
                    NewField11132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11132.TextFont.Bold = true;
                    NewField11132.TextFont.CharSet = 162;
                    NewField11132.Value = @"23";

                    NewField113022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 175, 35, 181, false);
                    NewField113022.Name = "NewField113022";
                    NewField113022.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113022.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113022.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113022.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113022.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113022.TextFont.Bold = true;
                    NewField113022.TextFont.CharSet = 162;
                    NewField113022.Value = @"";

                    NewField1130222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 175, 54, 181, false);
                    NewField1130222.Name = "NewField1130222";
                    NewField1130222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130222.TextFont.Bold = true;
                    NewField1130222.TextFont.CharSet = 162;
                    NewField1130222.Value = @"";

                    NewField11120122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 175, 73, 181, false);
                    NewField11120122.Name = "NewField11120122";
                    NewField11120122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120122.TextFont.Bold = true;
                    NewField11120122.TextFont.CharSet = 162;
                    NewField11120122.Value = @"";

                    NewField11220222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 175, 107, 181, false);
                    NewField11220222.Name = "NewField11220222";
                    NewField11220222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220222.TextFont.Bold = true;
                    NewField11220222.TextFont.CharSet = 162;
                    NewField11220222.Value = @"";

                    NewField112202122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 175, 141, 181, false);
                    NewField112202122.Name = "NewField112202122";
                    NewField112202122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112202122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112202122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112202122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112202122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112202122.TextFont.Bold = true;
                    NewField112202122.TextFont.CharSet = 162;
                    NewField112202122.Value = @"";

                    NewField1111202122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 175, 205, 181, false);
                    NewField1111202122.Name = "NewField1111202122";
                    NewField1111202122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111202122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111202122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111202122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111202122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111202122.TextFont.Bold = true;
                    NewField1111202122.TextFont.CharSet = 162;
                    NewField1111202122.Value = @"";

                    NewField11142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 181, 16, 187, false);
                    NewField11142.Name = "NewField11142";
                    NewField11142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11142.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11142.TextFont.Bold = true;
                    NewField11142.TextFont.CharSet = 162;
                    NewField11142.Value = @"24";

                    NewField113032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 181, 35, 187, false);
                    NewField113032.Name = "NewField113032";
                    NewField113032.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113032.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113032.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113032.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113032.TextFont.Bold = true;
                    NewField113032.TextFont.CharSet = 162;
                    NewField113032.Value = @"";

                    NewField1130232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 181, 54, 187, false);
                    NewField1130232.Name = "NewField1130232";
                    NewField1130232.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130232.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130232.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130232.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130232.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130232.TextFont.Bold = true;
                    NewField1130232.TextFont.CharSet = 162;
                    NewField1130232.Value = @"";

                    NewField11120132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 181, 73, 187, false);
                    NewField11120132.Name = "NewField11120132";
                    NewField11120132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11120132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11120132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11120132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11120132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11120132.TextFont.Bold = true;
                    NewField11120132.TextFont.CharSet = 162;
                    NewField11120132.Value = @"";

                    NewField11220232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 181, 107, 187, false);
                    NewField11220232.Name = "NewField11220232";
                    NewField11220232.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220232.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220232.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220232.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220232.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220232.TextFont.Bold = true;
                    NewField11220232.TextFont.CharSet = 162;
                    NewField11220232.Value = @"";

                    NewField112202132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 181, 141, 187, false);
                    NewField112202132.Name = "NewField112202132";
                    NewField112202132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112202132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112202132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112202132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112202132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112202132.TextFont.Bold = true;
                    NewField112202132.TextFont.CharSet = 162;
                    NewField112202132.Value = @"";

                    NewField1111202132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 181, 205, 187, false);
                    NewField1111202132.Name = "NewField1111202132";
                    NewField1111202132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111202132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111202132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111202132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111202132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111202132.TextFont.Bold = true;
                    NewField1111202132.TextFont.CharSet = 162;
                    NewField1111202132.Value = @"";

                    NewField1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 187, 16, 193, false);
                    NewField1611.Name = "NewField1611";
                    NewField1611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1611.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1611.TextFont.Bold = true;
                    NewField1611.TextFont.CharSet = 162;
                    NewField1611.Value = @"25";

                    NewField15031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 187, 35, 193, false);
                    NewField15031.Name = "NewField15031";
                    NewField15031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField15031.TextFont.Bold = true;
                    NewField15031.TextFont.CharSet = 162;
                    NewField15031.Value = @"";

                    NewField152031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 187, 54, 193, false);
                    NewField152031.Name = "NewField152031";
                    NewField152031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField152031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField152031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField152031.TextFont.Bold = true;
                    NewField152031.TextFont.CharSet = 162;
                    NewField152031.Value = @"";

                    NewField1510211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 187, 73, 193, false);
                    NewField1510211.Name = "NewField1510211";
                    NewField1510211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1510211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1510211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1510211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1510211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1510211.TextFont.Bold = true;
                    NewField1510211.TextFont.CharSet = 162;
                    NewField1510211.Value = @"";

                    NewField1520221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 187, 107, 193, false);
                    NewField1520221.Name = "NewField1520221";
                    NewField1520221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1520221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1520221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1520221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1520221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1520221.TextFont.Bold = true;
                    NewField1520221.TextFont.CharSet = 162;
                    NewField1520221.Value = @"";

                    NewField15120221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 187, 141, 193, false);
                    NewField15120221.Name = "NewField15120221";
                    NewField15120221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15120221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15120221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15120221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15120221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField15120221.TextFont.Bold = true;
                    NewField15120221.TextFont.CharSet = 162;
                    NewField15120221.Value = @"";

                    NewField151202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 187, 205, 193, false);
                    NewField151202111.Name = "NewField151202111";
                    NewField151202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField151202111.TextFont.Bold = true;
                    NewField151202111.TextFont.CharSet = 162;
                    NewField151202111.Value = @"";

                    NewField12121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 193, 16, 199, false);
                    NewField12121.Name = "NewField12121";
                    NewField12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12121.TextFont.Bold = true;
                    NewField12121.TextFont.CharSet = 162;
                    NewField12121.Value = @"26";

                    NewField123011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 193, 35, 199, false);
                    NewField123011.Name = "NewField123011";
                    NewField123011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField123011.WordBreak = EvetHayirEnum.ehEvet;
                    NewField123011.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField123011.TextFont.Bold = true;
                    NewField123011.TextFont.CharSet = 162;
                    NewField123011.Value = @"";

                    NewField1230211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 193, 54, 199, false);
                    NewField1230211.Name = "NewField1230211";
                    NewField1230211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1230211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1230211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1230211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1230211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1230211.TextFont.Bold = true;
                    NewField1230211.TextFont.CharSet = 162;
                    NewField1230211.Value = @"";

                    NewField12120111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 193, 73, 199, false);
                    NewField12120111.Name = "NewField12120111";
                    NewField12120111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12120111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12120111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12120111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12120111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12120111.TextFont.Bold = true;
                    NewField12120111.TextFont.CharSet = 162;
                    NewField12120111.Value = @"";

                    NewField12220211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 193, 107, 199, false);
                    NewField12220211.Name = "NewField12220211";
                    NewField12220211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12220211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12220211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12220211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12220211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12220211.TextFont.Bold = true;
                    NewField12220211.TextFont.CharSet = 162;
                    NewField12220211.Value = @"";

                    NewField122202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 193, 141, 199, false);
                    NewField122202111.Name = "NewField122202111";
                    NewField122202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122202111.TextFont.Bold = true;
                    NewField122202111.TextFont.CharSet = 162;
                    NewField122202111.Value = @"";

                    NewField1211202111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 193, 205, 199, false);
                    NewField1211202111.Name = "NewField1211202111";
                    NewField1211202111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211202111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211202111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211202111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211202111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211202111.TextFont.Bold = true;
                    NewField1211202111.TextFont.CharSet = 162;
                    NewField1211202111.Value = @"";

                    NewField12131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 199, 16, 205, false);
                    NewField12131.Name = "NewField12131";
                    NewField12131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12131.TextFont.Bold = true;
                    NewField12131.TextFont.CharSet = 162;
                    NewField12131.Value = @"27";

                    NewField123021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 199, 35, 205, false);
                    NewField123021.Name = "NewField123021";
                    NewField123021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField123021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField123021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField123021.TextFont.Bold = true;
                    NewField123021.TextFont.CharSet = 162;
                    NewField123021.Value = @"";

                    NewField1230221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 199, 54, 205, false);
                    NewField1230221.Name = "NewField1230221";
                    NewField1230221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1230221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1230221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1230221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1230221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1230221.TextFont.Bold = true;
                    NewField1230221.TextFont.CharSet = 162;
                    NewField1230221.Value = @"";

                    NewField12120121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 199, 73, 205, false);
                    NewField12120121.Name = "NewField12120121";
                    NewField12120121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12120121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12120121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12120121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12120121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12120121.TextFont.Bold = true;
                    NewField12120121.TextFont.CharSet = 162;
                    NewField12120121.Value = @"";

                    NewField12220221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 199, 107, 205, false);
                    NewField12220221.Name = "NewField12220221";
                    NewField12220221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12220221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12220221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12220221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12220221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12220221.TextFont.Bold = true;
                    NewField12220221.TextFont.CharSet = 162;
                    NewField12220221.Value = @"";

                    NewField122202121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 199, 141, 205, false);
                    NewField122202121.Name = "NewField122202121";
                    NewField122202121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122202121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122202121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122202121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122202121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122202121.TextFont.Bold = true;
                    NewField122202121.TextFont.CharSet = 162;
                    NewField122202121.Value = @"";

                    NewField1211202121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 199, 205, 205, false);
                    NewField1211202121.Name = "NewField1211202121";
                    NewField1211202121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211202121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211202121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211202121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211202121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211202121.TextFont.Bold = true;
                    NewField1211202121.TextFont.CharSet = 162;
                    NewField1211202121.Value = @"";

                    NewField12141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 205, 16, 211, false);
                    NewField12141.Name = "NewField12141";
                    NewField12141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12141.TextFont.Bold = true;
                    NewField12141.TextFont.CharSet = 162;
                    NewField12141.Value = @"28";

                    NewField123031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 205, 35, 211, false);
                    NewField123031.Name = "NewField123031";
                    NewField123031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField123031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField123031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField123031.TextFont.Bold = true;
                    NewField123031.TextFont.CharSet = 162;
                    NewField123031.Value = @"";

                    NewField1230231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 205, 54, 211, false);
                    NewField1230231.Name = "NewField1230231";
                    NewField1230231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1230231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1230231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1230231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1230231.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1230231.TextFont.Bold = true;
                    NewField1230231.TextFont.CharSet = 162;
                    NewField1230231.Value = @"";

                    NewField12120131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 205, 73, 211, false);
                    NewField12120131.Name = "NewField12120131";
                    NewField12120131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12120131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12120131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12120131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12120131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12120131.TextFont.Bold = true;
                    NewField12120131.TextFont.CharSet = 162;
                    NewField12120131.Value = @"";

                    NewField12220231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 205, 107, 211, false);
                    NewField12220231.Name = "NewField12220231";
                    NewField12220231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12220231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12220231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12220231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12220231.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12220231.TextFont.Bold = true;
                    NewField12220231.TextFont.CharSet = 162;
                    NewField12220231.Value = @"";

                    NewField122202131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 205, 141, 211, false);
                    NewField122202131.Name = "NewField122202131";
                    NewField122202131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122202131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122202131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122202131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122202131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122202131.TextFont.Bold = true;
                    NewField122202131.TextFont.CharSet = 162;
                    NewField122202131.Value = @"";

                    NewField1211202131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 205, 205, 211, false);
                    NewField1211202131.Name = "NewField1211202131";
                    NewField1211202131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211202131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211202131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211202131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211202131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211202131.TextFont.Bold = true;
                    NewField1211202131.TextFont.CharSet = 162;
                    NewField1211202131.Value = @"";

                    NewField114121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 211, 16, 217, false);
                    NewField114121.Name = "NewField114121";
                    NewField114121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField114121.TextFont.Bold = true;
                    NewField114121.TextFont.CharSet = 162;
                    NewField114121.Value = @"29";

                    NewField114122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 217, 16, 223, false);
                    NewField114122.Name = "NewField114122";
                    NewField114122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField114122.TextFont.Bold = true;
                    NewField114122.TextFont.CharSet = 162;
                    NewField114122.Value = @"30";

                    NewField1120321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 211, 35, 217, false);
                    NewField1120321.Name = "NewField1120321";
                    NewField1120321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1120321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1120321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1120321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1120321.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1120321.TextFont.Bold = true;
                    NewField1120321.TextFont.CharSet = 162;
                    NewField1120321.Value = @"";

                    NewField11220321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 211, 54, 217, false);
                    NewField11220321.Name = "NewField11220321";
                    NewField11220321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11220321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11220321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11220321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11220321.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11220321.TextFont.Bold = true;
                    NewField11220321.TextFont.CharSet = 162;
                    NewField11220321.Value = @"";

                    NewField1130321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 217, 35, 223, false);
                    NewField1130321.Name = "NewField1130321";
                    NewField1130321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1130321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1130321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1130321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1130321.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1130321.TextFont.Bold = true;
                    NewField1130321.TextFont.CharSet = 162;
                    NewField1130321.Value = @"";

                    NewField11320321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 217, 54, 223, false);
                    NewField11320321.Name = "NewField11320321";
                    NewField11320321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11320321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11320321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11320321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11320321.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11320321.TextFont.Bold = true;
                    NewField11320321.TextFont.CharSet = 162;
                    NewField11320321.Value = @"";

                    NewField113102121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 211, 73, 217, false);
                    NewField113102121.Name = "NewField113102121";
                    NewField113102121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113102121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113102121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113102121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113102121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113102121.TextFont.Bold = true;
                    NewField113102121.TextFont.CharSet = 162;
                    NewField113102121.Value = @"";

                    NewField113202221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 211, 107, 217, false);
                    NewField113202221.Name = "NewField113202221";
                    NewField113202221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113202221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113202221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113202221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113202221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113202221.TextFont.Bold = true;
                    NewField113202221.TextFont.CharSet = 162;
                    NewField113202221.Value = @"";

                    NewField1131202221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 211, 141, 217, false);
                    NewField1131202221.Name = "NewField1131202221";
                    NewField1131202221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131202221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131202221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131202221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1131202221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1131202221.TextFont.Bold = true;
                    NewField1131202221.TextFont.CharSet = 162;
                    NewField1131202221.Value = @"";

                    NewField113102122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 217, 73, 223, false);
                    NewField113102122.Name = "NewField113102122";
                    NewField113102122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113102122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113102122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113102122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113102122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113102122.TextFont.Bold = true;
                    NewField113102122.TextFont.CharSet = 162;
                    NewField113102122.Value = @"";

                    NewField113202222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 217, 107, 223, false);
                    NewField113202222.Name = "NewField113202222";
                    NewField113202222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113202222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113202222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113202222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113202222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113202222.TextFont.Bold = true;
                    NewField113202222.TextFont.CharSet = 162;
                    NewField113202222.Value = @"";

                    NewField1131202222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 217, 141, 223, false);
                    NewField1131202222.Name = "NewField1131202222";
                    NewField1131202222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131202222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131202222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131202222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1131202222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1131202222.TextFont.Bold = true;
                    NewField1131202222.TextFont.CharSet = 162;
                    NewField1131202222.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 211, 205, 217, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField7.Value = @"";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 217, 205, 223, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField22.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class dataset_GetExistingPhysiotherapyUnits = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField19.CalcValue = (dataset_GetExistingPhysiotherapyUnits != null ? Globals.ToStringCore(dataset_GetExistingPhysiotherapyUnits.Name) : "");
                    NameSurname.CalcValue = NameSurname.Value;
                    BirthDate.CalcValue = BirthDate.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1202.CalcValue = NewField1202.Value;
                    NewField12021.CalcValue = NewField12021.Value;
                    NewField112021.CalcValue = NewField112021.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField1203.CalcValue = NewField1203.Value;
                    NewField11021.CalcValue = NewField11021.Value;
                    NewField12022.CalcValue = NewField12022.Value;
                    NewField112022.CalcValue = NewField112022.Value;
                    NewField1120211.CalcValue = NewField1120211.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1301.CalcValue = NewField1301.Value;
                    NewField13021.CalcValue = NewField13021.Value;
                    NewField112011.CalcValue = NewField112011.Value;
                    NewField122021.CalcValue = NewField122021.Value;
                    NewField1220211.CalcValue = NewField1220211.Value;
                    NewField11120211.CalcValue = NewField11120211.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField1302.CalcValue = NewField1302.Value;
                    NewField13022.CalcValue = NewField13022.Value;
                    NewField112012.CalcValue = NewField112012.Value;
                    NewField122022.CalcValue = NewField122022.Value;
                    NewField1220212.CalcValue = NewField1220212.Value;
                    NewField11120212.CalcValue = NewField11120212.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField1303.CalcValue = NewField1303.Value;
                    NewField13023.CalcValue = NewField13023.Value;
                    NewField112013.CalcValue = NewField112013.Value;
                    NewField122023.CalcValue = NewField122023.Value;
                    NewField1220213.CalcValue = NewField1220213.Value;
                    NewField11120213.CalcValue = NewField11120213.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField1304.CalcValue = NewField1304.Value;
                    NewField13024.CalcValue = NewField13024.Value;
                    NewField112014.CalcValue = NewField112014.Value;
                    NewField122024.CalcValue = NewField122024.Value;
                    NewField1220214.CalcValue = NewField1220214.Value;
                    NewField11120214.CalcValue = NewField11120214.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11031.CalcValue = NewField11031.Value;
                    NewField112031.CalcValue = NewField112031.Value;
                    NewField1110211.CalcValue = NewField1110211.Value;
                    NewField1120221.CalcValue = NewField1120221.Value;
                    NewField11120221.CalcValue = NewField11120221.Value;
                    NewField111202111.CalcValue = NewField111202111.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField12031.CalcValue = NewField12031.Value;
                    NewField122031.CalcValue = NewField122031.Value;
                    NewField1210211.CalcValue = NewField1210211.Value;
                    NewField1220221.CalcValue = NewField1220221.Value;
                    NewField12120221.CalcValue = NewField12120221.Value;
                    NewField121202111.CalcValue = NewField121202111.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField13031.CalcValue = NewField13031.Value;
                    NewField132031.CalcValue = NewField132031.Value;
                    NewField1310211.CalcValue = NewField1310211.Value;
                    NewField1320221.CalcValue = NewField1320221.Value;
                    NewField13120221.CalcValue = NewField13120221.Value;
                    NewField131202111.CalcValue = NewField131202111.Value;
                    NewField116.CalcValue = NewField116.Value;
                    NewField1305.CalcValue = NewField1305.Value;
                    NewField13025.CalcValue = NewField13025.Value;
                    NewField112015.CalcValue = NewField112015.Value;
                    NewField122025.CalcValue = NewField122025.Value;
                    NewField1220215.CalcValue = NewField1220215.Value;
                    NewField11120215.CalcValue = NewField11120215.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField11032.CalcValue = NewField11032.Value;
                    NewField112032.CalcValue = NewField112032.Value;
                    NewField1110212.CalcValue = NewField1110212.Value;
                    NewField1120222.CalcValue = NewField1120222.Value;
                    NewField11120222.CalcValue = NewField11120222.Value;
                    NewField111202112.CalcValue = NewField111202112.Value;
                    NewField1312.CalcValue = NewField1312.Value;
                    NewField12032.CalcValue = NewField12032.Value;
                    NewField122032.CalcValue = NewField122032.Value;
                    NewField1210212.CalcValue = NewField1210212.Value;
                    NewField1220222.CalcValue = NewField1220222.Value;
                    NewField12120222.CalcValue = NewField12120222.Value;
                    NewField121202112.CalcValue = NewField121202112.Value;
                    NewField1412.CalcValue = NewField1412.Value;
                    NewField13032.CalcValue = NewField13032.Value;
                    NewField132032.CalcValue = NewField132032.Value;
                    NewField1310212.CalcValue = NewField1310212.Value;
                    NewField1320222.CalcValue = NewField1320222.Value;
                    NewField13120222.CalcValue = NewField13120222.Value;
                    NewField131202112.CalcValue = NewField131202112.Value;
                    NewField1511.CalcValue = NewField1511.Value;
                    NewField14031.CalcValue = NewField14031.Value;
                    NewField142031.CalcValue = NewField142031.Value;
                    NewField1410211.CalcValue = NewField1410211.Value;
                    NewField1420221.CalcValue = NewField1420221.Value;
                    NewField14120221.CalcValue = NewField14120221.Value;
                    NewField141202111.CalcValue = NewField141202111.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField113011.CalcValue = NewField113011.Value;
                    NewField1130211.CalcValue = NewField1130211.Value;
                    NewField11120111.CalcValue = NewField11120111.Value;
                    NewField11220211.CalcValue = NewField11220211.Value;
                    NewField112202111.CalcValue = NewField112202111.Value;
                    NewField1111202111.CalcValue = NewField1111202111.Value;
                    NewField11131.CalcValue = NewField11131.Value;
                    NewField113021.CalcValue = NewField113021.Value;
                    NewField1130221.CalcValue = NewField1130221.Value;
                    NewField11120121.CalcValue = NewField11120121.Value;
                    NewField11220221.CalcValue = NewField11220221.Value;
                    NewField112202121.CalcValue = NewField112202121.Value;
                    NewField1111202121.CalcValue = NewField1111202121.Value;
                    NewField11141.CalcValue = NewField11141.Value;
                    NewField113031.CalcValue = NewField113031.Value;
                    NewField1130231.CalcValue = NewField1130231.Value;
                    NewField11120131.CalcValue = NewField11120131.Value;
                    NewField11220231.CalcValue = NewField11220231.Value;
                    NewField112202131.CalcValue = NewField112202131.Value;
                    NewField1111202131.CalcValue = NewField1111202131.Value;
                    NewField117.CalcValue = NewField117.Value;
                    NewField1306.CalcValue = NewField1306.Value;
                    NewField13026.CalcValue = NewField13026.Value;
                    NewField112016.CalcValue = NewField112016.Value;
                    NewField122026.CalcValue = NewField122026.Value;
                    NewField1220216.CalcValue = NewField1220216.Value;
                    NewField11120216.CalcValue = NewField11120216.Value;
                    NewField1213.CalcValue = NewField1213.Value;
                    NewField11033.CalcValue = NewField11033.Value;
                    NewField112033.CalcValue = NewField112033.Value;
                    NewField1110213.CalcValue = NewField1110213.Value;
                    NewField1120223.CalcValue = NewField1120223.Value;
                    NewField11120223.CalcValue = NewField11120223.Value;
                    NewField111202113.CalcValue = NewField111202113.Value;
                    NewField1313.CalcValue = NewField1313.Value;
                    NewField12033.CalcValue = NewField12033.Value;
                    NewField122033.CalcValue = NewField122033.Value;
                    NewField1210213.CalcValue = NewField1210213.Value;
                    NewField1220223.CalcValue = NewField1220223.Value;
                    NewField12120223.CalcValue = NewField12120223.Value;
                    NewField121202113.CalcValue = NewField121202113.Value;
                    NewField1413.CalcValue = NewField1413.Value;
                    NewField13033.CalcValue = NewField13033.Value;
                    NewField132033.CalcValue = NewField132033.Value;
                    NewField1310213.CalcValue = NewField1310213.Value;
                    NewField1320223.CalcValue = NewField1320223.Value;
                    NewField13120223.CalcValue = NewField13120223.Value;
                    NewField131202113.CalcValue = NewField131202113.Value;
                    NewField1512.CalcValue = NewField1512.Value;
                    NewField14032.CalcValue = NewField14032.Value;
                    NewField142032.CalcValue = NewField142032.Value;
                    NewField1410212.CalcValue = NewField1410212.Value;
                    NewField1420222.CalcValue = NewField1420222.Value;
                    NewField14120222.CalcValue = NewField14120222.Value;
                    NewField141202112.CalcValue = NewField141202112.Value;
                    NewField11122.CalcValue = NewField11122.Value;
                    NewField113012.CalcValue = NewField113012.Value;
                    NewField1130212.CalcValue = NewField1130212.Value;
                    NewField11120112.CalcValue = NewField11120112.Value;
                    NewField11220212.CalcValue = NewField11220212.Value;
                    NewField112202112.CalcValue = NewField112202112.Value;
                    NewField1111202112.CalcValue = NewField1111202112.Value;
                    NewField11132.CalcValue = NewField11132.Value;
                    NewField113022.CalcValue = NewField113022.Value;
                    NewField1130222.CalcValue = NewField1130222.Value;
                    NewField11120122.CalcValue = NewField11120122.Value;
                    NewField11220222.CalcValue = NewField11220222.Value;
                    NewField112202122.CalcValue = NewField112202122.Value;
                    NewField1111202122.CalcValue = NewField1111202122.Value;
                    NewField11142.CalcValue = NewField11142.Value;
                    NewField113032.CalcValue = NewField113032.Value;
                    NewField1130232.CalcValue = NewField1130232.Value;
                    NewField11120132.CalcValue = NewField11120132.Value;
                    NewField11220232.CalcValue = NewField11220232.Value;
                    NewField112202132.CalcValue = NewField112202132.Value;
                    NewField1111202132.CalcValue = NewField1111202132.Value;
                    NewField1611.CalcValue = NewField1611.Value;
                    NewField15031.CalcValue = NewField15031.Value;
                    NewField152031.CalcValue = NewField152031.Value;
                    NewField1510211.CalcValue = NewField1510211.Value;
                    NewField1520221.CalcValue = NewField1520221.Value;
                    NewField15120221.CalcValue = NewField15120221.Value;
                    NewField151202111.CalcValue = NewField151202111.Value;
                    NewField12121.CalcValue = NewField12121.Value;
                    NewField123011.CalcValue = NewField123011.Value;
                    NewField1230211.CalcValue = NewField1230211.Value;
                    NewField12120111.CalcValue = NewField12120111.Value;
                    NewField12220211.CalcValue = NewField12220211.Value;
                    NewField122202111.CalcValue = NewField122202111.Value;
                    NewField1211202111.CalcValue = NewField1211202111.Value;
                    NewField12131.CalcValue = NewField12131.Value;
                    NewField123021.CalcValue = NewField123021.Value;
                    NewField1230221.CalcValue = NewField1230221.Value;
                    NewField12120121.CalcValue = NewField12120121.Value;
                    NewField12220221.CalcValue = NewField12220221.Value;
                    NewField122202121.CalcValue = NewField122202121.Value;
                    NewField1211202121.CalcValue = NewField1211202121.Value;
                    NewField12141.CalcValue = NewField12141.Value;
                    NewField123031.CalcValue = NewField123031.Value;
                    NewField1230231.CalcValue = NewField1230231.Value;
                    NewField12120131.CalcValue = NewField12120131.Value;
                    NewField12220231.CalcValue = NewField12220231.Value;
                    NewField122202131.CalcValue = NewField122202131.Value;
                    NewField1211202131.CalcValue = NewField1211202131.Value;
                    NewField114121.CalcValue = NewField114121.Value;
                    NewField114122.CalcValue = NewField114122.Value;
                    NewField1120321.CalcValue = NewField1120321.Value;
                    NewField11220321.CalcValue = NewField11220321.Value;
                    NewField1130321.CalcValue = NewField1130321.Value;
                    NewField11320321.CalcValue = NewField11320321.Value;
                    NewField113102121.CalcValue = NewField113102121.Value;
                    NewField113202221.CalcValue = NewField113202221.Value;
                    NewField1131202221.CalcValue = NewField1131202221.Value;
                    NewField113102122.CalcValue = NewField113102122.Value;
                    NewField113202222.CalcValue = NewField113202222.Value;
                    NewField1131202222.CalcValue = NewField1131202222.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField22.CalcValue = NewField22.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField13,NewField14,NewField131,NewField141,NewField5,NewField15,NewField16,NewField17,NewField18,NewField151,NewField161,NewField171,NewField19,NameSurname,BirthDate,NewField172,NewField6,NewField20,NewField102,NewField1201,NewField1202,NewField12021,NewField112021,NewField21,NewField103,NewField1203,NewField11021,NewField12022,NewField112022,NewField1120211,NewField112,NewField1301,NewField13021,NewField112011,NewField122021,NewField1220211,NewField11120211,NewField113,NewField1302,NewField13022,NewField112012,NewField122022,NewField1220212,NewField11120212,NewField114,NewField1303,NewField13023,NewField112013,NewField122023,NewField1220213,NewField11120213,NewField115,NewField1304,NewField13024,NewField112014,NewField122024,NewField1220214,NewField11120214,NewField1211,NewField11031,NewField112031,NewField1110211,NewField1120221,NewField11120221,NewField111202111,NewField1311,NewField12031,NewField122031,NewField1210211,NewField1220221,NewField12120221,NewField121202111,NewField1411,NewField13031,NewField132031,NewField1310211,NewField1320221,NewField13120221,NewField131202111,NewField116,NewField1305,NewField13025,NewField112015,NewField122025,NewField1220215,NewField11120215,NewField1212,NewField11032,NewField112032,NewField1110212,NewField1120222,NewField11120222,NewField111202112,NewField1312,NewField12032,NewField122032,NewField1210212,NewField1220222,NewField12120222,NewField121202112,NewField1412,NewField13032,NewField132032,NewField1310212,NewField1320222,NewField13120222,NewField131202112,NewField1511,NewField14031,NewField142031,NewField1410211,NewField1420221,NewField14120221,NewField141202111,NewField11121,NewField113011,NewField1130211,NewField11120111,NewField11220211,NewField112202111,NewField1111202111,NewField11131,NewField113021,NewField1130221,NewField11120121,NewField11220221,NewField112202121,NewField1111202121,NewField11141,NewField113031,NewField1130231,NewField11120131,NewField11220231,NewField112202131,NewField1111202131,NewField117,NewField1306,NewField13026,NewField112016,NewField122026,NewField1220216,NewField11120216,NewField1213,NewField11033,NewField112033,NewField1110213,NewField1120223,NewField11120223,NewField111202113,NewField1313,NewField12033,NewField122033,NewField1210213,NewField1220223,NewField12120223,NewField121202113,NewField1413,NewField13033,NewField132033,NewField1310213,NewField1320223,NewField13120223,NewField131202113,NewField1512,NewField14032,NewField142032,NewField1410212,NewField1420222,NewField14120222,NewField141202112,NewField11122,NewField113012,NewField1130212,NewField11120112,NewField11220212,NewField112202112,NewField1111202112,NewField11132,NewField113022,NewField1130222,NewField11120122,NewField11220222,NewField112202122,NewField1111202122,NewField11142,NewField113032,NewField1130232,NewField11120132,NewField11220232,NewField112202132,NewField1111202132,NewField1611,NewField15031,NewField152031,NewField1510211,NewField1520221,NewField15120221,NewField151202111,NewField12121,NewField123011,NewField1230211,NewField12120111,NewField12220211,NewField122202111,NewField1211202111,NewField12131,NewField123021,NewField1230221,NewField12120121,NewField12220221,NewField122202121,NewField1211202121,NewField12141,NewField123031,NewField1230231,NewField12120131,NewField12220231,NewField122202131,NewField1211202131,NewField114121,NewField114122,NewField1120321,NewField11220321,NewField1130321,NewField11320321,NewField113102121,NewField113202221,NewField1131202221,NewField113102122,NewField113202222,NewField1131202222,NewField7,NewField22};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true); 
            PhysiotherapyRequest pr = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST.ToString()), "PhysiotherapyRequest");
            this.NameSurname.CalcValue = pr.Episode.Patient.Name.ToString() + " " + pr.Episode.Patient.Surname.ToString();
            this.BirthDate.CalcValue = pr.Episode.Patient.BirthDate.ToString();
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

        public PhysicalTherapyRehabilitation()
        {
            part1 = new part1Group(this,"part1");
            MAIN = new MAINGroup(part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSIOTHERAPYREQUEST", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSIOTHERAPYREQUEST"))
                _runtimeParameters.PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PHYSIOTHERAPYREQUEST"]);
            Name = "PHYSICALTHERAPYREHABILITATION";
            Caption = "Fizik Tedavi Rehabilitasyon";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            DontUseWatermark = EvetHayirEnum.ehEvet;
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