
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
    /// Sağlık Kurulu Ek Raporu
    /// </summary>
    public partial class HCAdditionalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public HCAdditionalReport MyParentReport
            {
                get { return (HCAdditionalReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public HCAdditionalReport MyParentReport
                {
                    get { return (HCAdditionalReport)ParentReport; }
                }
                 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HCAdditionalReport MyParentReport
                {
                    get { return (HCAdditionalReport)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField131; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 10, 122, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"HİZMETE ÖZEL";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 3, 114, 8, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"B-2";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { NewField121,NewField131};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public HCAdditionalReport MyParentReport
            {
                get { return (HCAdditionalReport)ParentReport; }
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
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField REPORTNO { get {return Header().REPORTNO;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
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
            public TTReportField MEMBEROBJECTID { get {return Footer().MEMBEROBJECTID;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>("GetCurrentHCAdditionalReport2", HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCAdditionalReport MyParentReport
                {
                    get { return (HCAdditionalReport)ParentReport; }
                }
                
                public TTReportField REPORTDATE;
                public TTReportField NewField11;
                public TTReportField REPORTNO;
                public TTReportField NewField111;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportField NewField112;
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 14, 197, 19, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.Visible = EvetHayirEnum.ehHayir;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.TextFont.Name = "Arial";
                    REPORTDATE.TextFont.CharSet = 162;
                    REPORTDATE.Value = @"{#REPORTDATE#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 19, 168, 24, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"RAPOR NO";

                    REPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 19, 197, 24, false);
                    REPORTNO.Name = "REPORTNO";
                    REPORTNO.Visible = EvetHayirEnum.ehHayir;
                    REPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNO.TextFont.Name = "Arial";
                    REPORTNO.TextFont.CharSet = 162;
                    REPORTNO.Value = @"{#REPORTNO#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 14, 168, 19, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"EK RAPOR TARİHİ";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 14, 170, 19, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.Visible = EvetHayirEnum.ehHayir;
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @":";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 19, 170, 24, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @":";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 28, 117, 33, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"EK RAPORDUR";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 12, 116, 17, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HİZMETE ÖZEL";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 5, 202, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"EK-B";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class dataset_GetCurrentHCAdditionalReport2 = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>(0);
                    REPORTDATE.CalcValue = (dataset_GetCurrentHCAdditionalReport2 != null ? Globals.ToStringCore(dataset_GetCurrentHCAdditionalReport2.ReportDate) : "");
                    NewField11.CalcValue = NewField11.Value;
                    REPORTNO.CalcValue = (dataset_GetCurrentHCAdditionalReport2 != null ? Globals.ToStringCore(dataset_GetCurrentHCAdditionalReport2.ReportNo) : "");
                    NewField111.CalcValue = NewField111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { REPORTDATE,NewField11,REPORTNO,NewField111,NewField111111,NewField1111111,NewField112,NewField1,NewField2};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HCAdditionalReport MyParentReport
                {
                    get { return (HCAdditionalReport)ParentReport; }
                }
                
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
                public TTReportField MEMBEROBJECTID;
                public TTReportField NewField14;
                public TTReportShape NewLine1;
                public TTReportField NewField3; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 99;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SK_CHAIRMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 4, 60, 21, false);
                    SK_CHAIRMAN.Name = "SK_CHAIRMAN";
                    SK_CHAIRMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_CHAIRMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.TextFont.Name = "Arial";
                    SK_CHAIRMAN.TextFont.Size = 7;
                    SK_CHAIRMAN.TextFont.CharSet = 162;
                    SK_CHAIRMAN.Value = @"";

                    SK_MEMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 4, 106, 21, false);
                    SK_MEMBER1.Name = "SK_MEMBER1";
                    SK_MEMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER1.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.TextFont.Name = "Arial";
                    SK_MEMBER1.TextFont.Size = 7;
                    SK_MEMBER1.TextFont.CharSet = 162;
                    SK_MEMBER1.Value = @"";

                    SK_MEMBER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 4, 152, 21, false);
                    SK_MEMBER2.Name = "SK_MEMBER2";
                    SK_MEMBER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER2.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.TextFont.Name = "Arial";
                    SK_MEMBER2.TextFont.Size = 7;
                    SK_MEMBER2.TextFont.CharSet = 162;
                    SK_MEMBER2.Value = @"";

                    SK_MEMBER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 4, 198, 21, false);
                    SK_MEMBER3.Name = "SK_MEMBER3";
                    SK_MEMBER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER3.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.TextFont.Name = "Arial";
                    SK_MEMBER3.TextFont.Size = 7;
                    SK_MEMBER3.TextFont.CharSet = 162;
                    SK_MEMBER3.Value = @"";

                    SK_MEMBER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 21, 60, 38, false);
                    SK_MEMBER4.Name = "SK_MEMBER4";
                    SK_MEMBER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER4.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.TextFont.Name = "Arial";
                    SK_MEMBER4.TextFont.Size = 7;
                    SK_MEMBER4.TextFont.CharSet = 162;
                    SK_MEMBER4.Value = @"";

                    SK_MEMBER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 21, 106, 38, false);
                    SK_MEMBER5.Name = "SK_MEMBER5";
                    SK_MEMBER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER5.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.TextFont.Name = "Arial";
                    SK_MEMBER5.TextFont.Size = 7;
                    SK_MEMBER5.TextFont.CharSet = 162;
                    SK_MEMBER5.Value = @"";

                    SK_MEMBER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 21, 152, 38, false);
                    SK_MEMBER6.Name = "SK_MEMBER6";
                    SK_MEMBER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER6.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.TextFont.Name = "Arial";
                    SK_MEMBER6.TextFont.Size = 7;
                    SK_MEMBER6.TextFont.CharSet = 162;
                    SK_MEMBER6.Value = @"";

                    SK_MEMBER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 21, 198, 38, false);
                    SK_MEMBER7.Name = "SK_MEMBER7";
                    SK_MEMBER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER7.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.TextFont.Name = "Arial";
                    SK_MEMBER7.TextFont.Size = 7;
                    SK_MEMBER7.TextFont.CharSet = 162;
                    SK_MEMBER7.Value = @"";

                    SK_MEMBER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 38, 60, 55, false);
                    SK_MEMBER8.Name = "SK_MEMBER8";
                    SK_MEMBER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER8.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.TextFont.Name = "Arial";
                    SK_MEMBER8.TextFont.Size = 7;
                    SK_MEMBER8.TextFont.CharSet = 162;
                    SK_MEMBER8.Value = @"";

                    SK_MEMBER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 38, 106, 55, false);
                    SK_MEMBER9.Name = "SK_MEMBER9";
                    SK_MEMBER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER9.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.TextFont.Name = "Arial";
                    SK_MEMBER9.TextFont.Size = 7;
                    SK_MEMBER9.TextFont.CharSet = 162;
                    SK_MEMBER9.Value = @"";

                    SK_MEMBER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 38, 152, 55, false);
                    SK_MEMBER10.Name = "SK_MEMBER10";
                    SK_MEMBER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER10.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.TextFont.Name = "Arial";
                    SK_MEMBER10.TextFont.Size = 7;
                    SK_MEMBER10.TextFont.CharSet = 162;
                    SK_MEMBER10.Value = @"";

                    SK_MEMBER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 38, 198, 55, false);
                    SK_MEMBER11.Name = "SK_MEMBER11";
                    SK_MEMBER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER11.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.TextFont.Name = "Arial";
                    SK_MEMBER11.TextFont.Size = 7;
                    SK_MEMBER11.TextFont.CharSet = 162;
                    SK_MEMBER11.Value = @"";

                    SK_MEMBER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 55, 60, 72, false);
                    SK_MEMBER12.Name = "SK_MEMBER12";
                    SK_MEMBER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER12.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.TextFont.Name = "Arial";
                    SK_MEMBER12.TextFont.Size = 7;
                    SK_MEMBER12.TextFont.CharSet = 162;
                    SK_MEMBER12.Value = @"";

                    SK_MEMBER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 55, 106, 72, false);
                    SK_MEMBER13.Name = "SK_MEMBER13";
                    SK_MEMBER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER13.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.TextFont.Name = "Arial";
                    SK_MEMBER13.TextFont.Size = 7;
                    SK_MEMBER13.TextFont.CharSet = 162;
                    SK_MEMBER13.Value = @"";

                    SK_MEMBER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 55, 152, 72, false);
                    SK_MEMBER14.Name = "SK_MEMBER14";
                    SK_MEMBER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER14.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.TextFont.Name = "Arial";
                    SK_MEMBER14.TextFont.Size = 7;
                    SK_MEMBER14.TextFont.CharSet = 162;
                    SK_MEMBER14.Value = @"";

                    SK_MEMBER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 55, 198, 72, false);
                    SK_MEMBER15.Name = "SK_MEMBER15";
                    SK_MEMBER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER15.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.TextFont.Name = "Arial";
                    SK_MEMBER15.TextFont.Size = 7;
                    SK_MEMBER15.TextFont.CharSet = 162;
                    SK_MEMBER15.Value = @"";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 81, 139, 98, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial";
                    BASTABIP.TextFont.CharSet = 162;
                    BASTABIP.Value = @"";

                    MEMBEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 42, 239, 47, false);
                    MEMBEROBJECTID.Name = "MEMBEROBJECTID";
                    MEMBEROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    MEMBEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBEROBJECTID.Value = @"{#MEMBEROFHEALTHCOMMITTEE#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 75, 114, 80, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"ONAY";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 80, 114, 80, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 53, 4, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 7;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.Underline = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Sağ. Krl. Bşk.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class dataset_GetCurrentHCAdditionalReport2 = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeAdditionalReport.GetCurrentHCAdditionalReport_Class>(0);
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
                    MEMBEROBJECTID.CalcValue = (dataset_GetCurrentHCAdditionalReport2 != null ? Globals.ToStringCore(dataset_GetCurrentHCAdditionalReport2.MemberOfHealthCommittee) : "");
                    NewField14.CalcValue = NewField14.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { SK_CHAIRMAN,SK_MEMBER1,SK_MEMBER2,SK_MEMBER3,SK_MEMBER4,SK_MEMBER5,SK_MEMBER6,SK_MEMBER7,SK_MEMBER8,SK_MEMBER9,SK_MEMBER10,SK_MEMBER11,SK_MEMBER12,SK_MEMBER13,SK_MEMBER14,SK_MEMBER15,BASTABIP,MEMBEROBJECTID,NewField14,NewField3};
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
                
                sMasterText = sMasterText + member.MasterOfHealthCommittee.Name + sCrLf;
                sMasterText = sMasterText + sTitle + " (" + sEmpID + ")" + sCrLf;
                sMasterText = sMasterText + "BAŞTABİP ";
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

                    this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanTitle + chairmanRank + " (" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
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
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HCAdditionalReport MyParentReport
            {
                get { return (HCAdditionalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REPORT { get {return Body().REPORT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField XXXXXXLIKSUBESI { get {return Body().XXXXXXLIKSUBESI;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
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
                public HCAdditionalReport MyParentReport
                {
                    get { return (HCAdditionalReport)ParentReport; }
                }
                
                public TTReportField REPORT;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportShape NewLine1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField TCKIMLIKNO;
                public TTReportField ADISOYADI;
                public TTReportField SINIFRUTBE;
                public TTReportField BABAADI;
                public TTReportField XXXXXXLIKSUBESI;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportShape NewLine11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField RAPORTARIHI;
                public TTReportField RAPORNO;
                public TTReportField TESHIS;
                public TTReportShape NewLine2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 77;
                    RepeatCount = 0;
                    
                    REPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 72, 202, 77, false);
                    REPORT.Name = "REPORT";
                    REPORT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORT.MultiLine = EvetHayirEnum.ehEvet;
                    REPORT.NoClip = EvetHayirEnum.ehEvet;
                    REPORT.WordBreak = EvetHayirEnum.ehEvet;
                    REPORT.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORT.TextFont.Name = "Arial";
                    REPORT.TextFont.CharSet = 162;
                    REPORT.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 58, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"PERSONEL KİMLİĞİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 2, 61, 7, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 7, 61, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 58, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"T.C. Kimlik No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 8, 61, 13, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 13, 58, 18, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Adı Soyadı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 13, 61, 18, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 18, 58, 23, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Sınıf ve Rütbesi";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 18, 61, 23, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 23, 58, 28, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Baba Adı";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 23, 61, 28, false);
                    NewField18.Name = "NewField18";
                    NewField18.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 28, 58, 33, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Doğum Yeri/Tarihi";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 28, 61, 33, false);
                    NewField20.Name = "NewField20";
                    NewField20.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 33, 58, 38, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"Nüfusa Kayıtlı Olduğu As. Şb.";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 33, 61, 38, false);
                    NewField22.Name = "NewField22";
                    NewField22.Value = @":";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 8, 202, 13, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 13, 202, 18, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.Name = "Arial";
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 18, 202, 23, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Name = "Arial";
                    SINIFRUTBE.TextFont.CharSet = 162;
                    SINIFRUTBE.Value = @"";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 23, 202, 28, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Name = "Arial";
                    BABAADI.TextFont.CharSet = 162;
                    BABAADI.Value = @"";

                    XXXXXXLIKSUBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 33, 202, 38, false);
                    XXXXXXLIKSUBESI.Name = "XXXXXXLIKSUBESI";
                    XXXXXXLIKSUBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBESI.TextFont.Name = "Arial";
                    XXXXXXLIKSUBESI.TextFont.CharSet = 162;
                    XXXXXXLIKSUBESI.Value = @"";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 42, 58, 47, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Name = "Arial";
                    NewField23.TextFont.CharSet = 162;
                    NewField23.Value = @"RAPOR BİLGİLERİ";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 42, 61, 47, false);
                    NewField24.Name = "NewField24";
                    NewField24.Value = @":";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 47, 61, 47, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 48, 58, 53, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Rapor Tarihi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 48, 61, 53, false);
                    NewField121.Name = "NewField121";
                    NewField121.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 53, 58, 58, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Rapor No ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 53, 61, 58, false);
                    NewField141.Name = "NewField141";
                    NewField141.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 58, 58, 63, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Teşhis";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 58, 61, 63, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 65, 61, 70, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Karar";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 48, 202, 53, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.TextFont.Name = "Arial";
                    RAPORTARIHI.TextFont.CharSet = 162;
                    RAPORTARIHI.Value = @"";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 53, 202, 58, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial";
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 58, 202, 63, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.TextFont.Name = "Arial";
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 70, 61, 70, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORT.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    TCKIMLIKNO.CalcValue = @"";
                    ADISOYADI.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    BABAADI.CalcValue = @"";
                    XXXXXXLIKSUBESI.CalcValue = @"";
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    RAPORTARIHI.CalcValue = @"";
                    RAPORNO.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    return new TTReportObject[] { REPORT,NewField1,NewField2,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,NewField19,NewField20,NewField21,NewField22,TCKIMLIKNO,ADISOYADI,SINIFRUTBE,BABAADI,XXXXXXLIKSUBESI,NewField23,NewField24,NewField111,NewField121,NewField131,NewField141,NewField151,NewField161,NewField171,RAPORTARIHI,RAPORNO,TESHIS};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                                                                                                                            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((HCAdditionalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            HealthCommitteeAdditionalReport hcr = (HealthCommitteeAdditionalReport)context.GetObject(new Guid(sObjectID),"HealthCommitteeAdditionalReport");  
//            EpisodeAction episodeAction = (EpisodeAction) context.GetObject(new Guid(sObjectID),"EpisodeAction");
//            Episode episode = episodeAction.Episode;
////            MilitaryClassDefinitions pMilClass = episode.MilitaryClass;
////            RankDefinitions pRank = episode.Rank;
//            
//            this.TCKIMLIKNO.CalcValue = episode.Patient.UniqueRefNo.ToString();
//            this.ADISOYADI.CalcValue = episode.Patient.Name + " " + episode.Patient.Surname;
////            this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//            this.BABAADI.CalcValue = episode.Patient.FatherName;
//            this.DOGUMYERITARIHI.CalcValue = (episode.Patient.CityOfBirth == null ? "" : episode.Patient.CityOfBirth.Name + " ") + (episode.Patient.BirthDate == null ? "" : episode.Patient.BirthDate.Value.ToShortDateString());
////            this.XXXXXXLIKSUBESI.CalcValue = episode.MilitaryOffice == null ? "" : episode.MilitaryOffice.Name;
//            
//            // Rapor
//            if(hcr.Report != null)
//                this.REPORT.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hcr.Report.ToString());
//            
//            if(hcr.IsOtherHospitalHC.Value == true)
//            {
//                this.RAPORNO.CalcValue = hcr.HCReportNo.ToString();
//                this.RAPORTARIHI.CalcValue = hcr.HCDate.ToString();
//            }
//            else
//            {
//                this.RAPORNO.CalcValue = hcr.ReportNo.ToString();
//                this.RAPORTARIHI.CalcValue = hcr.ReportDate.ToString();
//            }
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

        public HCAdditionalReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCADDITIONALREPORT";
            Caption = "Sağlık Kurulu Ek Raporu";
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