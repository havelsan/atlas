
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
    public partial class HC_LowerExtremiteReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public HC_ExtremiteReportTypeEnum? ReportType = (HC_ExtremiteReportTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HC_ExtremiteReportTypeEnum"].ConvertValue("");
        }

        public partial class ALT_EKTREMITE_HEADERGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public ALT_EKTREMITE_HEADERGroupHeader Header()
            {
                return (ALT_EKTREMITE_HEADERGroupHeader)_header;
            }

            new public ALT_EKTREMITE_HEADERGroupFooter Footer()
            {
                return (ALT_EKTREMITE_HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField Reçete1 { get {return Header().Reçete1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public ALT_EKTREMITE_HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ALT_EKTREMITE_HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ALT_EKTREMITE_HEADERGroupHeader(this);
                _footer = new ALT_EKTREMITE_HEADERGroupFooter(this);

            }

            public partial class ALT_EKTREMITE_HEADERGroupHeader : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField Reçete1;
                public TTReportField LOGO; 
                public ALT_EKTREMITE_HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 6, 191, 46, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Reçete1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 51, 186, 56, false);
                    Reçete1.Name = "Reçete1";
                    Reçete1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Reçete1.MultiLine = EvetHayirEnum.ehEvet;
                    Reçete1.NoClip = EvetHayirEnum.ehEvet;
                    Reçete1.WordBreak = EvetHayirEnum.ehEvet;
                    Reçete1.TextFont.Name = "Arial";
                    Reçete1.TextFont.Size = 12;
                    Reçete1.TextFont.Bold = true;
                    Reçete1.TextFont.CharSet = 162;
                    Reçete1.Value = @"TIBBİ UYGUNLUK KOMİSYONU HASTA DEĞERLENDİRME FORMU
(ALT EKSTREMİTE PROTEZLERİ İÇİN)";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 8, 32, 31, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Reçete1.CalcValue = Reçete1.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { Reçete1,LOGO,XXXXXXBASLIK1};
                }
                public override void RunPreScript()
                {
#region ALT_EKTREMITE_HEADER HEADER_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.LowerExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
            
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion ALT_EKTREMITE_HEADER HEADER_PreScript
                }
            }
            public partial class ALT_EKTREMITE_HEADERGroupFooter : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                 
                public ALT_EKTREMITE_HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ALT_EKTREMITE_HEADERGroup ALT_EKTREMITE_HEADER;

        public partial class ALT_EKSTREMITEGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public ALT_EKSTREMITEGroupBody Body()
            {
                return (ALT_EKSTREMITEGroupBody)_body;
            }
            public TTReportField FULLNAME1 { get {return Body().FULLNAME1;} }
            public TTReportField lblPAtientName1 { get {return Body().lblPAtientName1;} }
            public TTReportField PNAME { get {return Body().PNAME;} }
            public TTReportField PSURNAME { get {return Body().PSURNAME;} }
            public TTReportField ExaminationDate { get {return Body().ExaminationDate;} }
            public TTReportField lblPAtientName11 { get {return Body().lblPAtientName11;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField lblPAtientName12 { get {return Body().lblPAtientName12;} }
            public TTReportField FULLNAME12 { get {return Body().FULLNAME12;} }
            public TTReportField lblPAtientName13 { get {return Body().lblPAtientName13;} }
            public TTReportField FULLNAME13 { get {return Body().FULLNAME13;} }
            public TTReportField lblPAtientName14 { get {return Body().lblPAtientName14;} }
            public TTReportField FULLNAME14 { get {return Body().FULLNAME14;} }
            public TTReportField lblPAtientName15 { get {return Body().lblPAtientName15;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField DIAGNOSISFIELD1 { get {return Body().DIAGNOSISFIELD1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField DIAGNOSISFIELD11 { get {return Body().DIAGNOSISFIELD11;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField DIAGNOSISFIELD12 { get {return Body().DIAGNOSISFIELD12;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField DIAGNOSISFIELD13 { get {return Body().DIAGNOSISFIELD13;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField DIAGNOSISFIELD14 { get {return Body().DIAGNOSISFIELD14;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField DIAGNOSISFIELD15 { get {return Body().DIAGNOSISFIELD15;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField DIAGNOSISFIELD16 { get {return Body().DIAGNOSISFIELD16;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField DIAGNOSISFIELD17 { get {return Body().DIAGNOSISFIELD17;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField DIAGNOSISFIELD171 { get {return Body().DIAGNOSISFIELD171;} }
            public TTReportField NewField103 { get {return Body().NewField103;} }
            public TTReportField DIAGNOSISFIELD172 { get {return Body().DIAGNOSISFIELD172;} }
            public TTReportField NewField104 { get {return Body().NewField104;} }
            public TTReportField DIAGNOSISFIELD173 { get {return Body().DIAGNOSISFIELD173;} }
            public TTReportField NewField105 { get {return Body().NewField105;} }
            public TTReportField DIAGNOSISFIELD174 { get {return Body().DIAGNOSISFIELD174;} }
            public TTReportField NewField106 { get {return Body().NewField106;} }
            public TTReportField DIAGNOSISFIELD175 { get {return Body().DIAGNOSISFIELD175;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField107 { get {return Body().NewField107;} }
            public TTReportField DIAGNOSISFIELD176 { get {return Body().DIAGNOSISFIELD176;} }
            public TTReportField NewField108 { get {return Body().NewField108;} }
            public TTReportField DIAGNOSISFIELD177 { get {return Body().DIAGNOSISFIELD177;} }
            public TTReportField NewField109 { get {return Body().NewField109;} }
            public TTReportField DIAGNOSISFIELD178 { get {return Body().DIAGNOSISFIELD178;} }
            public TTReportField NewField110 { get {return Body().NewField110;} }
            public TTReportField DIAGNOSISFIELD179 { get {return Body().DIAGNOSISFIELD179;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField DIAGNOSISFIELD180 { get {return Body().DIAGNOSISFIELD180;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField DIAGNOSISFIELD181 { get {return Body().DIAGNOSISFIELD181;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField DIAGNOSISFIELD182 { get {return Body().DIAGNOSISFIELD182;} }
            public TTReportField ReportDate { get {return Body().ReportDate;} }
            public TTReportField ReportNo { get {return Body().ReportNo;} }
            public ALT_EKSTREMITEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ALT_EKSTREMITEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LowerExtremity.GetExtremityReportInfoByObjId_Class>("GetExtremityReportInfoByObjId", LowerExtremity.GetExtremityReportInfoByObjId((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ALT_EKSTREMITEGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ALT_EKSTREMITEGroupBody : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField FULLNAME1;
                public TTReportField lblPAtientName1;
                public TTReportField PNAME;
                public TTReportField PSURNAME;
                public TTReportField ExaminationDate;
                public TTReportField lblPAtientName11;
                public TTReportField UNIQUEREFNO;
                public TTReportField lblPAtientName12;
                public TTReportField FULLNAME12;
                public TTReportField lblPAtientName13;
                public TTReportField FULLNAME13;
                public TTReportField lblPAtientName14;
                public TTReportField FULLNAME14;
                public TTReportField lblPAtientName15;
                public TTReportField NewField1;
                public TTReportField DIAGNOSISFIELD1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField4;
                public TTReportField NewField11;
                public TTReportField DIAGNOSISFIELD11;
                public TTReportField NewField14;
                public TTReportField DIAGNOSISFIELD12;
                public TTReportField NewField15;
                public TTReportField DIAGNOSISFIELD13;
                public TTReportShape NewLine13;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField DIAGNOSISFIELD14;
                public TTReportField NewField18;
                public TTReportField DIAGNOSISFIELD15;
                public TTReportField NewField19;
                public TTReportField DIAGNOSISFIELD16;
                public TTReportField NewField20;
                public TTReportField DIAGNOSISFIELD17;
                public TTReportField NewField102;
                public TTReportField DIAGNOSISFIELD171;
                public TTReportField NewField103;
                public TTReportField DIAGNOSISFIELD172;
                public TTReportField NewField104;
                public TTReportField DIAGNOSISFIELD173;
                public TTReportField NewField105;
                public TTReportField DIAGNOSISFIELD174;
                public TTReportField NewField106;
                public TTReportField DIAGNOSISFIELD175;
                public TTReportField NewField161;
                public TTReportField NewField107;
                public TTReportField DIAGNOSISFIELD176;
                public TTReportField NewField108;
                public TTReportField DIAGNOSISFIELD177;
                public TTReportField NewField109;
                public TTReportField DIAGNOSISFIELD178;
                public TTReportField NewField110;
                public TTReportField DIAGNOSISFIELD179;
                public TTReportField NewField111;
                public TTReportField DIAGNOSISFIELD180;
                public TTReportField NewField112;
                public TTReportField DIAGNOSISFIELD181;
                public TTReportField NewField113;
                public TTReportField DIAGNOSISFIELD182;
                public TTReportField ReportDate;
                public TTReportField ReportNo; 
                public ALT_EKSTREMITEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 224;
                    RepeatCount = 0;
                    
                    FULLNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 10, 191, 15, false);
                    FULLNAME1.Name = "FULLNAME1";
                    FULLNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME1.Value = @"{%PNAME%} {%PSURNAME%}";

                    lblPAtientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 10, 36, 15, false);
                    lblPAtientName1.Name = "lblPAtientName1";
                    lblPAtientName1.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName1.Value = @"Adı Soyadı :";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 6, 245, 11, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.Value = @"{#NAME#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 14, 247, 19, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.Value = @"{#SURNAME#}";

                    ExaminationDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 4, 191, 9, false);
                    ExaminationDate.Name = "ExaminationDate";
                    ExaminationDate.DrawStyle = DrawStyleConstants.vbSolid;
                    ExaminationDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExaminationDate.Value = @"{#PROCESSDATE#}";

                    lblPAtientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 36, 9, false);
                    lblPAtientName11.Name = "lblPAtientName11";
                    lblPAtientName11.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName11.Value = @"Muayene Tarihi";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 191, 21, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.DrawStyle = DrawStyleConstants.vbSolid;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    lblPAtientName12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 16, 36, 21, false);
                    lblPAtientName12.Name = "lblPAtientName12";
                    lblPAtientName12.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName12.Value = @"T.C. :";

                    FULLNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 22, 191, 27, false);
                    FULLNAME12.Name = "FULLNAME12";
                    FULLNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME12.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME12.Value = @"{#BIRTHDATE#}";

                    lblPAtientName13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 22, 36, 27, false);
                    lblPAtientName13.Name = "lblPAtientName13";
                    lblPAtientName13.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName13.Value = @"Doğum Tarihi :";

                    FULLNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 28, 191, 33, false);
                    FULLNAME13.Name = "FULLNAME13";
                    FULLNAME13.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME13.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME13.Value = @"{#BIRTHPLACE#}";

                    lblPAtientName14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 28, 36, 33, false);
                    lblPAtientName14.Name = "lblPAtientName14";
                    lblPAtientName14.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName14.Value = @"Doğum Yeri :";

                    FULLNAME14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 34, 191, 39, false);
                    FULLNAME14.Name = "FULLNAME14";
                    FULLNAME14.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME14.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME14.Value = @"{#MOBILEPHONE#}";

                    lblPAtientName15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 34, 36, 39, false);
                    lblPAtientName15.Name = "lblPAtientName15";
                    lblPAtientName15.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName15.Value = @"Telefon :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 50, 79, 55, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"Tanı";

                    DIAGNOSISFIELD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 50, 191, 55, false);
                    DIAGNOSISFIELD1.Name = "DIAGNOSISFIELD1";
                    DIAGNOSISFIELD1.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 56, 79, 61, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.Value = @"Yaralanma nedeni ve tarihi:";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 56, 190, 61, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.Value = @"{#LE_CAUSEOFINJURY#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 79, 67, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.Value = @"Amputasyon tarihi:
";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 62, 190, 67, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.Value = @"{#LE_AMPUTATIONDATE#}
";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 68, 191, 73, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.Underline = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"HALEN PROTEZ KULLANIYORSA:";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 75, 82, 80, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"Kaçıncı protezi olduğu:";

                    DIAGNOSISFIELD11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 75, 191, 80, false);
                    DIAGNOSISFIELD11.Name = "DIAGNOSISFIELD11";
                    DIAGNOSISFIELD11.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11.Value = @"{#LE_PROSTHESISNUMBER#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 82, 86, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.Value = @"Yapım tarihi:";

                    DIAGNOSISFIELD12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 81, 191, 86, false);
                    DIAGNOSISFIELD12.Name = "DIAGNOSISFIELD12";
                    DIAGNOSISFIELD12.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD12.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD12.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD12.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD12.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD12.Value = @"{#LE_CONSTRUCTIONDATE#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 87, 82, 92, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.Value = @"Protez tipi:";

                    DIAGNOSISFIELD13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 87, 191, 92, false);
                    DIAGNOSISFIELD13.Name = "DIAGNOSISFIELD13";
                    DIAGNOSISFIELD13.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD13.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD13.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD13.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD13.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD13.Value = @"{#LE_PROSTHETICTYPE#}";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 93, 191, 93, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 100, 190, 105, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"SAĞLIK KURULU RAPORU:";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 106, 81, 111, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.Value = @"Raporu Veren Kurum";

                    DIAGNOSISFIELD14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 106, 190, 111, false);
                    DIAGNOSISFIELD14.Name = "DIAGNOSISFIELD14";
                    DIAGNOSISFIELD14.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD14.Value = @"Gaziler Fizik Tedavi ve Rehabilitasyon Eğitim ve Araştırma XXXXXX
";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 112, 81, 117, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.Value = @"Rapor Tarih ve Numarası";

                    DIAGNOSISFIELD15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 112, 190, 117, false);
                    DIAGNOSISFIELD15.Name = "DIAGNOSISFIELD15";
                    DIAGNOSISFIELD15.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD15.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD15.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD15.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD15.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD15.Value = @"{%ReportDate%} - {%ReportNo%}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 118, 81, 130, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.Value = @"Raporda Yazılan Protez Tipi
";

                    DIAGNOSISFIELD16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 118, 190, 130, false);
                    DIAGNOSISFIELD16.Name = "DIAGNOSISFIELD16";
                    DIAGNOSISFIELD16.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD16.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD16.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD16.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD16.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD16.Value = @"{#LE_SK_PROSTHETICTYPE#}";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 131, 81, 136, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.Value = @"Tıbbi Gerekçe Yazılmış mı?";

                    DIAGNOSISFIELD17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 131, 190, 136, false);
                    DIAGNOSISFIELD17.Name = "DIAGNOSISFIELD17";
                    DIAGNOSISFIELD17.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD17.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD17.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD17.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD17.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD17.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD17.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD17.Value = @"{#LE_MEDICALREASON#}";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 161, 81, 166, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.Value = @"Başhekim Onayı Var mı?";

                    DIAGNOSISFIELD171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 161, 190, 166, false);
                    DIAGNOSISFIELD171.Name = "DIAGNOSISFIELD171";
                    DIAGNOSISFIELD171.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD171.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD171.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD171.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD171.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD171.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD171.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD171.Value = @"{#LE_HEADDOCTORAPPROVE#}";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 155, 81, 160, false);
                    NewField103.Name = "NewField103";
                    NewField103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField103.Value = @"Psikiyatri Uzman Onayı Var mı?";

                    DIAGNOSISFIELD172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 155, 190, 160, false);
                    DIAGNOSISFIELD172.Name = "DIAGNOSISFIELD172";
                    DIAGNOSISFIELD172.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD172.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD172.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD172.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD172.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD172.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD172.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD172.Value = @"{#LE_PSYCHIATRICEXPERTAPPROVE#}";

                    NewField104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 149, 81, 154, false);
                    NewField104.Name = "NewField104";
                    NewField104.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField104.Value = @"Ortopedi Uzman Onayı Var mı?";

                    DIAGNOSISFIELD173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 149, 190, 154, false);
                    DIAGNOSISFIELD173.Name = "DIAGNOSISFIELD173";
                    DIAGNOSISFIELD173.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD173.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD173.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD173.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD173.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD173.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD173.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD173.Value = @"{#LE_ORTHOPEDICEXPERTAPPROVE#}";

                    NewField105 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 143, 81, 148, false);
                    NewField105.Name = "NewField105";
                    NewField105.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField105.Value = @"FTR Uzman Onayı Var mı?";

                    DIAGNOSISFIELD174 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 143, 190, 148, false);
                    DIAGNOSISFIELD174.Name = "DIAGNOSISFIELD174";
                    DIAGNOSISFIELD174.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD174.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD174.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD174.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD174.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD174.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD174.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD174.Value = @"{#LE_FTREXPERTAPPROVE#}";

                    NewField106 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 137, 81, 142, false);
                    NewField106.Name = "NewField106";
                    NewField106.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField106.Value = @"3. basamak sağlık kurumu";

                    DIAGNOSISFIELD175 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 137, 190, 142, false);
                    DIAGNOSISFIELD175.Name = "DIAGNOSISFIELD175";
                    DIAGNOSISFIELD175.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD175.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD175.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD175.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD175.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD175.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD175.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD175.Value = @"{#LE_THIRDSTEPHEALTHINST#}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 172, 190, 177, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.Underline = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"REÇETE İÇERİĞİ:";

                    NewField107 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 178, 81, 183, false);
                    NewField107.Name = "NewField107";
                    NewField107.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField107.Value = @"Hasta Adı Soyadı ve T.C kimlik NumarasıVar mı?";

                    DIAGNOSISFIELD176 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 178, 190, 183, false);
                    DIAGNOSISFIELD176.Name = "DIAGNOSISFIELD176";
                    DIAGNOSISFIELD176.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD176.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD176.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD176.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD176.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD176.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD176.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD176.Value = @"{#LE_PATIENTNAMESURNAME#}";

                    NewField108 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 184, 81, 192, false);
                    NewField108.Name = "NewField108";
                    NewField108.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField108.MultiLine = EvetHayirEnum.ehEvet;
                    NewField108.WordBreak = EvetHayirEnum.ehEvet;
                    NewField108.Value = @"Reçeteyi düzenleyen sağlık hizmet sunucusu adı veya MEDULA tesis kodu var mı?";

                    DIAGNOSISFIELD177 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 184, 190, 192, false);
                    DIAGNOSISFIELD177.Name = "DIAGNOSISFIELD177";
                    DIAGNOSISFIELD177.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD177.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD177.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSISFIELD177.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD177.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD177.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD177.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD177.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD177.Value = @"{#LE_MEDULAINSCODE#}";

                    NewField109 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 193, 81, 198, false);
                    NewField109.Name = "NewField109";
                    NewField109.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField109.Value = @"Medula veya Protokol Numarası Var mı?";

                    DIAGNOSISFIELD178 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 193, 190, 198, false);
                    DIAGNOSISFIELD178.Name = "DIAGNOSISFIELD178";
                    DIAGNOSISFIELD178.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD178.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD178.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD178.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD178.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD178.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD178.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD178.Value = @"{#LE_MEDULAORPROTOCOLNO#}";

                    NewField110 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 199, 81, 204, false);
                    NewField110.Name = "NewField110";
                    NewField110.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110.Value = @"Tanı ve ICD-10 Kodu Varmı";

                    DIAGNOSISFIELD179 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 199, 190, 204, false);
                    DIAGNOSISFIELD179.Name = "DIAGNOSISFIELD179";
                    DIAGNOSISFIELD179.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD179.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD179.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD179.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD179.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD179.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD179.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD179.Value = @"{#LE_DIAGNOSANDICD10CODE#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 205, 81, 210, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.Value = @"Cihazın adı/taraf/adet bilgisi var mı?";

                    DIAGNOSISFIELD180 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 205, 190, 210, false);
                    DIAGNOSISFIELD180.Name = "DIAGNOSISFIELD180";
                    DIAGNOSISFIELD180.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD180.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD180.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD180.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD180.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD180.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD180.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD180.Value = @"{#LE_MACHINENAME#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 211, 81, 216, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.Value = @"Cihazın adı/taraf/adet bilgisi doğrumu?";

                    DIAGNOSISFIELD181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 211, 190, 216, false);
                    DIAGNOSISFIELD181.Name = "DIAGNOSISFIELD181";
                    DIAGNOSISFIELD181.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD181.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD181.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD181.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD181.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD181.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD181.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD181.Value = @"{#LE_MACHINENAMEISCORRECT#}";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 217, 81, 222, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.Value = @"Islak İmza Varmı?";

                    DIAGNOSISFIELD182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 217, 190, 222, false);
                    DIAGNOSISFIELD182.Name = "DIAGNOSISFIELD182";
                    DIAGNOSISFIELD182.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD182.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD182.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD182.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD182.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD182.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD182.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD182.Value = @"{#LE_WETSIGNATURE#}";

                    ReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 31, 250, 36, false);
                    ReportDate.Name = "ReportDate";
                    ReportDate.Visible = EvetHayirEnum.ehHayir;
                    ReportDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportDate.Value = @"{#REPORTDATE#}";

                    ReportNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 39, 250, 44, false);
                    ReportNo.Name = "ReportNo";
                    ReportNo.Visible = EvetHayirEnum.ehHayir;
                    ReportNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportNo.Value = @"{#REPORTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = ParentGroup.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    PNAME.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Name) : "");
                    PSURNAME.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Surname) : "");
                    FULLNAME1.CalcValue = MyParentReport.ALT_EKSTREMITE.PNAME.CalcValue + @" " + MyParentReport.ALT_EKSTREMITE.PSURNAME.CalcValue;
                    lblPAtientName1.CalcValue = lblPAtientName1.Value;
                    ExaminationDate.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ProcessDate) : "");
                    lblPAtientName11.CalcValue = lblPAtientName11.Value;
                    UNIQUEREFNO.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UniqueRefNo) : "");
                    lblPAtientName12.CalcValue = lblPAtientName12.Value;
                    FULLNAME12.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.BirthDate) : "");
                    lblPAtientName13.CalcValue = lblPAtientName13.Value;
                    FULLNAME13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.BirthPlace) : "");
                    lblPAtientName14.CalcValue = lblPAtientName14.Value;
                    FULLNAME14.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.MobilePhone) : "");
                    lblPAtientName15.CalcValue = lblPAtientName15.Value;
                    NewField1.CalcValue = NewField1.Value;
                    DIAGNOSISFIELD1.CalcValue = DIAGNOSISFIELD1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_CauseOfInjury) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_AmputationDate) : "") + @"
";
                    NewField4.CalcValue = NewField4.Value;
                    NewField11.CalcValue = NewField11.Value;
                    DIAGNOSISFIELD11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_ProsthesisNumber) : "");
                    NewField14.CalcValue = NewField14.Value;
                    DIAGNOSISFIELD12.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_ConstructionDate) : "");
                    NewField15.CalcValue = NewField15.Value;
                    DIAGNOSISFIELD13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_ProstheticType) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    DIAGNOSISFIELD14.CalcValue = DIAGNOSISFIELD14.Value;
                    NewField18.CalcValue = NewField18.Value;
                    ReportDate.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ReportDate) : "");
                    ReportNo.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ReportNo) : "");
                    DIAGNOSISFIELD15.CalcValue = MyParentReport.ALT_EKSTREMITE.ReportDate.CalcValue + @" - " + MyParentReport.ALT_EKSTREMITE.ReportNo.CalcValue;
                    NewField19.CalcValue = NewField19.Value;
                    DIAGNOSISFIELD16.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_SK_ProstheticType) : "");
                    NewField20.CalcValue = NewField20.Value;
                    DIAGNOSISFIELD17.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_MedicalReason) : "");
                    DIAGNOSISFIELD17.PostFieldValueCalculation();
                    NewField102.CalcValue = NewField102.Value;
                    DIAGNOSISFIELD171.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HeadDoctorApprove) : "");
                    DIAGNOSISFIELD171.PostFieldValueCalculation();
                    NewField103.CalcValue = NewField103.Value;
                    DIAGNOSISFIELD172.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_PsychiatricExpertApprove) : "");
                    DIAGNOSISFIELD172.PostFieldValueCalculation();
                    NewField104.CalcValue = NewField104.Value;
                    DIAGNOSISFIELD173.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_OrthopedicExpertApprove) : "");
                    DIAGNOSISFIELD173.PostFieldValueCalculation();
                    NewField105.CalcValue = NewField105.Value;
                    DIAGNOSISFIELD174.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_FTRExpertApprove) : "");
                    DIAGNOSISFIELD174.PostFieldValueCalculation();
                    NewField106.CalcValue = NewField106.Value;
                    DIAGNOSISFIELD175.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_ThirdStepHealthInst) : "");
                    DIAGNOSISFIELD175.PostFieldValueCalculation();
                    NewField161.CalcValue = NewField161.Value;
                    NewField107.CalcValue = NewField107.Value;
                    DIAGNOSISFIELD176.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_PatientNameSurname) : "");
                    DIAGNOSISFIELD176.PostFieldValueCalculation();
                    NewField108.CalcValue = NewField108.Value;
                    DIAGNOSISFIELD177.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_MedulaInsCode) : "");
                    DIAGNOSISFIELD177.PostFieldValueCalculation();
                    NewField109.CalcValue = NewField109.Value;
                    DIAGNOSISFIELD178.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_MedulaOrProtocolNo) : "");
                    DIAGNOSISFIELD178.PostFieldValueCalculation();
                    NewField110.CalcValue = NewField110.Value;
                    DIAGNOSISFIELD179.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_DiagnosAndICD10Code) : "");
                    DIAGNOSISFIELD179.PostFieldValueCalculation();
                    NewField111.CalcValue = NewField111.Value;
                    DIAGNOSISFIELD180.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_MachineName) : "");
                    DIAGNOSISFIELD180.PostFieldValueCalculation();
                    NewField112.CalcValue = NewField112.Value;
                    DIAGNOSISFIELD181.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_MachineNameIsCorrect) : "");
                    DIAGNOSISFIELD181.PostFieldValueCalculation();
                    NewField113.CalcValue = NewField113.Value;
                    DIAGNOSISFIELD182.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_WetSignature) : "");
                    DIAGNOSISFIELD182.PostFieldValueCalculation();
                    return new TTReportObject[] { PNAME,PSURNAME,FULLNAME1,lblPAtientName1,ExaminationDate,lblPAtientName11,UNIQUEREFNO,lblPAtientName12,FULLNAME12,lblPAtientName13,FULLNAME13,lblPAtientName14,FULLNAME14,lblPAtientName15,NewField1,DIAGNOSISFIELD1,NewField2,NewField3,NewField12,NewField13,NewField4,NewField11,DIAGNOSISFIELD11,NewField14,DIAGNOSISFIELD12,NewField15,DIAGNOSISFIELD13,NewField16,NewField17,DIAGNOSISFIELD14,NewField18,ReportDate,ReportNo,DIAGNOSISFIELD15,NewField19,DIAGNOSISFIELD16,NewField20,DIAGNOSISFIELD17,NewField102,DIAGNOSISFIELD171,NewField103,DIAGNOSISFIELD172,NewField104,DIAGNOSISFIELD173,NewField105,DIAGNOSISFIELD174,NewField106,DIAGNOSISFIELD175,NewField161,NewField107,DIAGNOSISFIELD176,NewField108,DIAGNOSISFIELD177,NewField109,DIAGNOSISFIELD178,NewField110,DIAGNOSISFIELD179,NewField111,DIAGNOSISFIELD180,NewField112,DIAGNOSISFIELD181,NewField113,DIAGNOSISFIELD182};
                }
                public override void RunPreScript()
                {
#region ALT_EKSTREMITE BODY_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.LowerExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion ALT_EKSTREMITE BODY_PreScript
                }
            }

        }

        public ALT_EKSTREMITEGroup ALT_EKSTREMITE;

        public partial class ALT_EKSTREMITE_TEMGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public ALT_EKSTREMITE_TEMGroupBody Body()
            {
                return (ALT_EKSTREMITE_TEMGroupBody)_body;
            }
            public TTReportField NewField121611 { get {return Body().NewField121611;} }
            public TTReportField NewField11711 { get {return Body().NewField11711;} }
            public TTReportField DIAGNOSISFIELD11411 { get {return Body().DIAGNOSISFIELD11411;} }
            public TTReportField NewField1111401 { get {return Body().NewField1111401;} }
            public TTReportField DIAGNOSISFIELD1118301 { get {return Body().DIAGNOSISFIELD1118301;} }
            public TTReportField NewField1111161301 { get {return Body().NewField1111161301;} }
            public TTReportField NewField1211401 { get {return Body().NewField1211401;} }
            public TTReportField DIAGNOSISFIELD1218301 { get {return Body().DIAGNOSISFIELD1218301;} }
            public TTReportField NewField1211161301 { get {return Body().NewField1211161301;} }
            public TTReportField NewField1311401 { get {return Body().NewField1311401;} }
            public TTReportField DIAGNOSISFIELD1318301 { get {return Body().DIAGNOSISFIELD1318301;} }
            public TTReportField NewField1311161301 { get {return Body().NewField1311161301;} }
            public TTReportField NewField1411401 { get {return Body().NewField1411401;} }
            public TTReportField DIAGNOSISFIELD1418301 { get {return Body().DIAGNOSISFIELD1418301;} }
            public TTReportField NewField1411161301 { get {return Body().NewField1411161301;} }
            public TTReportField NewField1511401 { get {return Body().NewField1511401;} }
            public TTReportField DIAGNOSISFIELD1518301 { get {return Body().DIAGNOSISFIELD1518301;} }
            public TTReportField NewField1511161301 { get {return Body().NewField1511161301;} }
            public TTReportField NewField1611401 { get {return Body().NewField1611401;} }
            public TTReportField DIAGNOSISFIELD1618301 { get {return Body().DIAGNOSISFIELD1618301;} }
            public TTReportField NewField1611161301 { get {return Body().NewField1611161301;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField DIAGNOSISFIELD1141 { get {return Body().DIAGNOSISFIELD1141;} }
            public TTReportField NewField1271 { get {return Body().NewField1271;} }
            public TTReportField DIAGNOSISFIELD1241 { get {return Body().DIAGNOSISFIELD1241;} }
            public TTReportField NewField1371 { get {return Body().NewField1371;} }
            public TTReportField DIAGNOSISFIELD1341 { get {return Body().DIAGNOSISFIELD1341;} }
            public TTReportField NewField11131 { get {return Body().NewField11131;} }
            public TTReportField DIAGNOSISFIELD11821 { get {return Body().DIAGNOSISFIELD11821;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField1216111 { get {return Body().NewField1216111;} }
            public TTReportField NewField11116121 { get {return Body().NewField11116121;} }
            public TTReportField NewField113111 { get {return Body().NewField113111;} }
            public TTReportField DIAGNOSISFIELD112811 { get {return Body().DIAGNOSISFIELD112811;} }
            public TTReportField NewField112161111 { get {return Body().NewField112161111;} }
            public TTReportField NewField123111 { get {return Body().NewField123111;} }
            public TTReportField DIAGNOSISFIELD122811 { get {return Body().DIAGNOSISFIELD122811;} }
            public TTReportField NewField122161111 { get {return Body().NewField122161111;} }
            public TTReportField NewField133111 { get {return Body().NewField133111;} }
            public TTReportField DIAGNOSISFIELD132811 { get {return Body().DIAGNOSISFIELD132811;} }
            public TTReportField NewField132161111 { get {return Body().NewField132161111;} }
            public TTReportField NewField143111 { get {return Body().NewField143111;} }
            public TTReportField DIAGNOSISFIELD142811 { get {return Body().DIAGNOSISFIELD142811;} }
            public TTReportField NewField142161111 { get {return Body().NewField142161111;} }
            public TTReportField NewField153111 { get {return Body().NewField153111;} }
            public TTReportField DIAGNOSISFIELD152811 { get {return Body().DIAGNOSISFIELD152811;} }
            public TTReportField NewField152161111 { get {return Body().NewField152161111;} }
            public TTReportField NewField163111 { get {return Body().NewField163111;} }
            public TTReportField DIAGNOSISFIELD162811 { get {return Body().DIAGNOSISFIELD162811;} }
            public TTReportField NewField162161111 { get {return Body().NewField162161111;} }
            public TTReportField NewField173111 { get {return Body().NewField173111;} }
            public TTReportField DIAGNOSISFIELD172811 { get {return Body().DIAGNOSISFIELD172811;} }
            public TTReportField NewField172161111 { get {return Body().NewField172161111;} }
            public TTReportField NewField183111 { get {return Body().NewField183111;} }
            public TTReportField DIAGNOSISFIELD182811 { get {return Body().DIAGNOSISFIELD182811;} }
            public TTReportField NewField182161111 { get {return Body().NewField182161111;} }
            public TTReportField NewField193111 { get {return Body().NewField193111;} }
            public TTReportField DIAGNOSISFIELD192811 { get {return Body().DIAGNOSISFIELD192811;} }
            public TTReportField NewField192161111 { get {return Body().NewField192161111;} }
            public TTReportField NewField104111 { get {return Body().NewField104111;} }
            public TTReportField DIAGNOSISFIELD103811 { get {return Body().DIAGNOSISFIELD103811;} }
            public TTReportField NewField103161111 { get {return Body().NewField103161111;} }
            public TTReportField NewField114111 { get {return Body().NewField114111;} }
            public TTReportField DIAGNOSISFIELD113811 { get {return Body().DIAGNOSISFIELD113811;} }
            public TTReportField NewField113161111 { get {return Body().NewField113161111;} }
            public ALT_EKSTREMITE_TEMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ALT_EKSTREMITE_TEMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LowerExtremity.GetExtremityReportInfoByObjId_Class>("GetExtremityReportInfoByObjId", LowerExtremity.GetExtremityReportInfoByObjId((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ALT_EKSTREMITE_TEMGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ALT_EKSTREMITE_TEMGroupBody : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField NewField121611;
                public TTReportField NewField11711;
                public TTReportField DIAGNOSISFIELD11411;
                public TTReportField NewField1111401;
                public TTReportField DIAGNOSISFIELD1118301;
                public TTReportField NewField1111161301;
                public TTReportField NewField1211401;
                public TTReportField DIAGNOSISFIELD1218301;
                public TTReportField NewField1211161301;
                public TTReportField NewField1311401;
                public TTReportField DIAGNOSISFIELD1318301;
                public TTReportField NewField1311161301;
                public TTReportField NewField1411401;
                public TTReportField DIAGNOSISFIELD1418301;
                public TTReportField NewField1411161301;
                public TTReportField NewField1511401;
                public TTReportField DIAGNOSISFIELD1518301;
                public TTReportField NewField1511161301;
                public TTReportField NewField1611401;
                public TTReportField DIAGNOSISFIELD1618301;
                public TTReportField NewField1611161301;
                public TTReportField NewField11611;
                public TTReportField NewField1171;
                public TTReportField DIAGNOSISFIELD1141;
                public TTReportField NewField1271;
                public TTReportField DIAGNOSISFIELD1241;
                public TTReportField NewField1371;
                public TTReportField DIAGNOSISFIELD1341;
                public TTReportField NewField11131;
                public TTReportField DIAGNOSISFIELD11821;
                public TTReportField NewField111611;
                public TTReportField NewField1116111;
                public TTReportField NewField1216111;
                public TTReportField NewField11116121;
                public TTReportField NewField113111;
                public TTReportField DIAGNOSISFIELD112811;
                public TTReportField NewField112161111;
                public TTReportField NewField123111;
                public TTReportField DIAGNOSISFIELD122811;
                public TTReportField NewField122161111;
                public TTReportField NewField133111;
                public TTReportField DIAGNOSISFIELD132811;
                public TTReportField NewField132161111;
                public TTReportField NewField143111;
                public TTReportField DIAGNOSISFIELD142811;
                public TTReportField NewField142161111;
                public TTReportField NewField153111;
                public TTReportField DIAGNOSISFIELD152811;
                public TTReportField NewField152161111;
                public TTReportField NewField163111;
                public TTReportField DIAGNOSISFIELD162811;
                public TTReportField NewField162161111;
                public TTReportField NewField173111;
                public TTReportField DIAGNOSISFIELD172811;
                public TTReportField NewField172161111;
                public TTReportField NewField183111;
                public TTReportField DIAGNOSISFIELD182811;
                public TTReportField NewField182161111;
                public TTReportField NewField193111;
                public TTReportField DIAGNOSISFIELD192811;
                public TTReportField NewField192161111;
                public TTReportField NewField104111;
                public TTReportField DIAGNOSISFIELD103811;
                public TTReportField NewField103161111;
                public TTReportField NewField114111;
                public TTReportField DIAGNOSISFIELD113811;
                public TTReportField NewField113161111; 
                public ALT_EKSTREMITE_TEMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 188;
                    RepeatCount = 0;
                    
                    NewField121611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 132, 199, 137, false);
                    NewField121611.Name = "NewField121611";
                    NewField121611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121611.TextFont.Name = "Arial";
                    NewField121611.TextFont.Bold = true;
                    NewField121611.TextFont.Underline = true;
                    NewField121611.TextFont.CharSet = 162;
                    NewField121611.Value = @"TALEP EDİLEN MİKROİŞLEMCİ KONTROLLÜ DİZ EKLEMİ İÇİN:";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 138, 90, 143, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.Value = @"Hangi aktivite düzeyindeki hastalar için uygun?";

                    DIAGNOSISFIELD11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 138, 199, 143, false);
                    DIAGNOSISFIELD11411.Name = "DIAGNOSISFIELD11411";
                    DIAGNOSISFIELD11411.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11411.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11411.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.Value = @"{#LE_TEM_WHICHLEVEL#}";

                    NewField1111401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 144, 90, 152, false);
                    NewField1111401.Name = "NewField1111401";
                    NewField1111401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111401.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111401.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111401.Value = @"Yürüyüşün salınım ve duruş faz özelliklerini kontrol edebilir mi?
";

                    DIAGNOSISFIELD1118301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 144, 122, 152, false);
                    DIAGNOSISFIELD1118301.Name = "DIAGNOSISFIELD1118301";
                    DIAGNOSISFIELD1118301.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1118301.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1118301.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1118301.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1118301.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1118301.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1118301.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1118301.Value = @"{#LE_TEM_OSCILLATIONANDPOSTURE#}";

                    NewField1111161301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 144, 199, 152, false);
                    NewField1111161301.Name = "NewField1111161301";
                    NewField1111161301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111161301.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1111161301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111161301.TextFont.Name = "Arial";
                    NewField1111161301.TextFont.Bold = true;
                    NewField1111161301.TextFont.Underline = true;
                    NewField1111161301.TextFont.CharSet = 162;
                    NewField1111161301.Value = @"{#LE_TEM_OSCILLATIONAND_DESC#}";

                    NewField1211401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 152, 90, 157, false);
                    NewField1211401.Name = "NewField1211401";
                    NewField1211401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211401.Value = @"Değişken yürüme hızlarına uyum sağlayabilir mi?
";

                    DIAGNOSISFIELD1218301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 152, 122, 157, false);
                    DIAGNOSISFIELD1218301.Name = "DIAGNOSISFIELD1218301";
                    DIAGNOSISFIELD1218301.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1218301.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1218301.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1218301.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1218301.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1218301.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1218301.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1218301.Value = @"{#LE_TEM_WALKINGSPEED#}";

                    NewField1211161301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 152, 199, 157, false);
                    NewField1211161301.Name = "NewField1211161301";
                    NewField1211161301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211161301.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1211161301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211161301.TextFont.Name = "Arial";
                    NewField1211161301.TextFont.Bold = true;
                    NewField1211161301.TextFont.Underline = true;
                    NewField1211161301.TextFont.CharSet = 162;
                    NewField1211161301.Value = @"{#LE_TEM_WALKINGSPEED_DESC#}";

                    NewField1311401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 158, 90, 166, false);
                    NewField1311401.Name = "NewField1311401";
                    NewField1311401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311401.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311401.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311401.Value = @"Değişken adım uzunluklarında yürümeye uyum sağlayabilir mi?";

                    DIAGNOSISFIELD1318301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 158, 122, 166, false);
                    DIAGNOSISFIELD1318301.Name = "DIAGNOSISFIELD1318301";
                    DIAGNOSISFIELD1318301.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1318301.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1318301.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1318301.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1318301.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1318301.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1318301.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1318301.Value = @"{#LE_TEM_STRIDELENGTH#}";

                    NewField1311161301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 158, 199, 166, false);
                    NewField1311161301.Name = "NewField1311161301";
                    NewField1311161301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311161301.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1311161301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311161301.TextFont.Name = "Arial";
                    NewField1311161301.TextFont.Bold = true;
                    NewField1311161301.TextFont.Underline = true;
                    NewField1311161301.TextFont.CharSet = 162;
                    NewField1311161301.Value = @"{#LE_TEM_STRIDELENGTH_DESC#}";

                    NewField1411401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 166, 90, 171, false);
                    NewField1411401.Name = "NewField1411401";
                    NewField1411401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411401.Value = @"Basamak çıkma özelliği var mı?
";

                    DIAGNOSISFIELD1418301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 166, 122, 171, false);
                    DIAGNOSISFIELD1418301.Name = "DIAGNOSISFIELD1418301";
                    DIAGNOSISFIELD1418301.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1418301.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1418301.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1418301.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1418301.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1418301.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1418301.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1418301.Value = @"{#LE_TEM_STEPCLIMBING#}";

                    NewField1411161301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 166, 199, 171, false);
                    NewField1411161301.Name = "NewField1411161301";
                    NewField1411161301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411161301.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1411161301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1411161301.TextFont.Name = "Arial";
                    NewField1411161301.TextFont.Bold = true;
                    NewField1411161301.TextFont.Underline = true;
                    NewField1411161301.TextFont.CharSet = 162;
                    NewField1411161301.Value = @"{#LE_TEM_STEPCLIMBING_DESC#}";

                    NewField1511401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 172, 90, 177, false);
                    NewField1511401.Name = "NewField1511401";
                    NewField1511401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1511401.Value = @"Geri geri yürüme özelliği var mı?
";

                    DIAGNOSISFIELD1518301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 172, 122, 177, false);
                    DIAGNOSISFIELD1518301.Name = "DIAGNOSISFIELD1518301";
                    DIAGNOSISFIELD1518301.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1518301.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1518301.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1518301.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1518301.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1518301.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1518301.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1518301.Value = @"{#LE_TEM_WALKBACKWARDS#}";

                    NewField1511161301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 172, 199, 177, false);
                    NewField1511161301.Name = "NewField1511161301";
                    NewField1511161301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1511161301.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1511161301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1511161301.TextFont.Name = "Arial";
                    NewField1511161301.TextFont.Bold = true;
                    NewField1511161301.TextFont.Underline = true;
                    NewField1511161301.TextFont.CharSet = 162;
                    NewField1511161301.Value = @"{#LE_TEM_WALKBACKWARDS_DESC#}";

                    NewField1611401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 178, 90, 183, false);
                    NewField1611401.Name = "NewField1611401";
                    NewField1611401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1611401.Value = @"Suya dayanıklı mı?
";

                    DIAGNOSISFIELD1618301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 178, 122, 183, false);
                    DIAGNOSISFIELD1618301.Name = "DIAGNOSISFIELD1618301";
                    DIAGNOSISFIELD1618301.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1618301.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1618301.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1618301.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1618301.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1618301.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1618301.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1618301.Value = @"{#LE_TEM_WATERPROOF#}";

                    NewField1611161301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 178, 199, 183, false);
                    NewField1611161301.Name = "NewField1611161301";
                    NewField1611161301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1611161301.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1611161301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1611161301.TextFont.Name = "Arial";
                    NewField1611161301.TextFont.Bold = true;
                    NewField1611161301.TextFont.Underline = true;
                    NewField1611161301.TextFont.CharSet = 162;
                    NewField1611161301.Value = @"{#LE_TEM_WATERPROOF_DESC#}";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 199, 13, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.Underline = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"HASTA DEĞERLENDİRME:";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 14, 90, 19, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.Value = @"Boy:";

                    DIAGNOSISFIELD1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 14, 199, 19, false);
                    DIAGNOSISFIELD1141.Name = "DIAGNOSISFIELD1141";
                    DIAGNOSISFIELD1141.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1141.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1141.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1141.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1141.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1141.Value = @"{#HEIGTH#}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 90, 25, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1271.Value = @"Kilo";

                    DIAGNOSISFIELD1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 20, 199, 25, false);
                    DIAGNOSISFIELD1241.Name = "DIAGNOSISFIELD1241";
                    DIAGNOSISFIELD1241.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1241.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1241.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1241.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1241.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1241.Value = @"{#WEIGHT#}";

                    NewField1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 26, 90, 34, false);
                    NewField1371.Name = "NewField1371";
                    NewField1371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1371.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1371.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1371.Value = @"Aktivite düzeyi (Ampute Mobilite Belirleme Skoru ? K seviyesi)";

                    DIAGNOSISFIELD1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 26, 199, 34, false);
                    DIAGNOSISFIELD1341.Name = "DIAGNOSISFIELD1341";
                    DIAGNOSISFIELD1341.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1341.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1341.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1341.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1341.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1341.Value = @"{#LE_HD_AKTIVITYLEVEL#}";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 43, 90, 48, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131.Value = @"Hastanın protez marka/model tercih dilekçesi var mı?";

                    DIAGNOSISFIELD11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 43, 122, 48, false);
                    DIAGNOSISFIELD11821.Name = "DIAGNOSISFIELD11821";
                    DIAGNOSISFIELD11821.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11821.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11821.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11821.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11821.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11821.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11821.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11821.Value = @"{#LE_HD_PREFERENCEPETITION#}";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 36, 90, 41, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.Underline = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 36, 122, 41, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1116111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1116111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116111.TextFont.Name = "Arial";
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"EVET / HAYIR";

                    NewField1216111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 36, 199, 41, false);
                    NewField1216111.Name = "NewField1216111";
                    NewField1216111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1216111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1216111.TextFont.Name = "Arial";
                    NewField1216111.TextFont.Bold = true;
                    NewField1216111.TextFont.CharSet = 162;
                    NewField1216111.Value = @"AÇIKLAMA";

                    NewField11116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 43, 199, 48, false);
                    NewField11116121.Name = "NewField11116121";
                    NewField11116121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116121.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11116121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11116121.TextFont.Name = "Arial";
                    NewField11116121.TextFont.Bold = true;
                    NewField11116121.TextFont.Underline = true;
                    NewField11116121.TextFont.CharSet = 162;
                    NewField11116121.Value = @"{#LE_HD_PREFERENCEPETITION_DESC#}";

                    NewField113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 49, 90, 57, false);
                    NewField113111.Name = "NewField113111";
                    NewField113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113111.Value = @"Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?";

                    DIAGNOSISFIELD112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 49, 122, 57, false);
                    DIAGNOSISFIELD112811.Name = "DIAGNOSISFIELD112811";
                    DIAGNOSISFIELD112811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD112811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD112811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD112811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD112811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD112811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD112811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD112811.Value = @"{#LE_HD_STUMPZONE#}";

                    NewField112161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 49, 199, 57, false);
                    NewField112161111.Name = "NewField112161111";
                    NewField112161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField112161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112161111.TextFont.Name = "Arial";
                    NewField112161111.TextFont.Bold = true;
                    NewField112161111.TextFont.Underline = true;
                    NewField112161111.TextFont.CharSet = 162;
                    NewField112161111.Value = @"{#LE_HD_STUMPZONE_DESC#}";

                    NewField123111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 58, 90, 63, false);
                    NewField123111.Name = "NewField123111";
                    NewField123111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123111.Value = @"Protezin ağırlığı hasta tarafından tolere edilebilecek mi?";

                    DIAGNOSISFIELD122811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 58, 122, 63, false);
                    DIAGNOSISFIELD122811.Name = "DIAGNOSISFIELD122811";
                    DIAGNOSISFIELD122811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD122811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD122811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD122811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD122811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD122811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD122811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD122811.Value = @"{#LE_HD_WEIGHTTOLERANCE#}";

                    NewField122161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 58, 199, 63, false);
                    NewField122161111.Name = "NewField122161111";
                    NewField122161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField122161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122161111.TextFont.Name = "Arial";
                    NewField122161111.TextFont.Bold = true;
                    NewField122161111.TextFont.Underline = true;
                    NewField122161111.TextFont.CharSet = 162;
                    NewField122161111.Value = @"{#LE_HD_WEIGHTTOLERANCE_DESC#}";

                    NewField133111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 64, 90, 69, false);
                    NewField133111.Name = "NewField133111";
                    NewField133111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133111.Value = @"Ampute ekstremitede kontraktür var mı?";

                    DIAGNOSISFIELD132811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 64, 122, 69, false);
                    DIAGNOSISFIELD132811.Name = "DIAGNOSISFIELD132811";
                    DIAGNOSISFIELD132811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD132811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD132811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD132811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD132811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD132811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD132811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD132811.Value = @"{#LE_HD_CONTRACTURE#}";

                    NewField132161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 64, 199, 69, false);
                    NewField132161111.Name = "NewField132161111";
                    NewField132161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField132161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132161111.TextFont.Name = "Arial";
                    NewField132161111.TextFont.Bold = true;
                    NewField132161111.TextFont.Underline = true;
                    NewField132161111.TextFont.CharSet = 162;
                    NewField132161111.Value = @"{#LE_HD_CONTRACTURE_DESC#}";

                    NewField143111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 70, 90, 78, false);
                    NewField143111.Name = "NewField143111";
                    NewField143111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField143111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField143111.Value = @"Tek taraflı amputelerde diğer ekstremitede yürümeyi bozan veya engelleyen tıbbi sorun var mı?";

                    DIAGNOSISFIELD142811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 70, 122, 78, false);
                    DIAGNOSISFIELD142811.Name = "DIAGNOSISFIELD142811";
                    DIAGNOSISFIELD142811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD142811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD142811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD142811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD142811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD142811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD142811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD142811.Value = @"{#LE_HD_SINGLESIDEAMPUTATE#}";

                    NewField142161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 70, 199, 78, false);
                    NewField142161111.Name = "NewField142161111";
                    NewField142161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField142161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142161111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142161111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142161111.TextFont.Name = "Arial";
                    NewField142161111.TextFont.Bold = true;
                    NewField142161111.TextFont.Underline = true;
                    NewField142161111.TextFont.CharSet = 162;
                    NewField142161111.Value = @"{#LE_HD_SINGLESIDEAMPUTATE_DESC#}";

                    NewField153111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 79, 90, 87, false);
                    NewField153111.Name = "NewField153111";
                    NewField153111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField153111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField153111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField153111.Value = @"Ambulasyonu engelleyebilecek denge bozukluğu veya ataksi var mı?";

                    DIAGNOSISFIELD152811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 79, 122, 87, false);
                    DIAGNOSISFIELD152811.Name = "DIAGNOSISFIELD152811";
                    DIAGNOSISFIELD152811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD152811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD152811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD152811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD152811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD152811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD152811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD152811.Value = @"{#LE_HD_AMBULATION#}";

                    NewField152161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 79, 199, 87, false);
                    NewField152161111.Name = "NewField152161111";
                    NewField152161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField152161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152161111.TextFont.Name = "Arial";
                    NewField152161111.TextFont.Bold = true;
                    NewField152161111.TextFont.Underline = true;
                    NewField152161111.TextFont.CharSet = 162;
                    NewField152161111.Value = @"{#LE_HD_AMBULATION_DESC#}";

                    NewField163111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 89, 90, 94, false);
                    NewField163111.Name = "NewField163111";
                    NewField163111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField163111.Value = @"Kas-iskelet sistemi hastalığı var mı?";

                    DIAGNOSISFIELD162811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 89, 122, 94, false);
                    DIAGNOSISFIELD162811.Name = "DIAGNOSISFIELD162811";
                    DIAGNOSISFIELD162811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD162811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD162811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD162811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD162811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD162811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD162811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD162811.Value = @"{#LE_HD_MUSCULOSKELETAL#}";

                    NewField162161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 89, 199, 94, false);
                    NewField162161111.Name = "NewField162161111";
                    NewField162161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField162161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField162161111.TextFont.Name = "Arial";
                    NewField162161111.TextFont.Bold = true;
                    NewField162161111.TextFont.Underline = true;
                    NewField162161111.TextFont.CharSet = 162;
                    NewField162161111.Value = @"{#LE_HD_MUSCULOSKELETAL_DESC#}";

                    NewField173111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 95, 90, 100, false);
                    NewField173111.Name = "NewField173111";
                    NewField173111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField173111.Value = @"Nörolojik /nöromusküler hastalık var mı?";

                    DIAGNOSISFIELD172811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 95, 122, 100, false);
                    DIAGNOSISFIELD172811.Name = "DIAGNOSISFIELD172811";
                    DIAGNOSISFIELD172811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD172811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD172811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD172811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD172811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD172811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD172811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD172811.Value = @"{#LE_HD_NEUROLOGICAL#}";

                    NewField172161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 95, 199, 100, false);
                    NewField172161111.Name = "NewField172161111";
                    NewField172161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField172161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField172161111.TextFont.Name = "Arial";
                    NewField172161111.TextFont.Bold = true;
                    NewField172161111.TextFont.Underline = true;
                    NewField172161111.TextFont.CharSet = 162;
                    NewField172161111.Value = @"{#LE_HD_NEUROLOGICAL_DESC#}";

                    NewField183111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 101, 90, 106, false);
                    NewField183111.Name = "NewField183111";
                    NewField183111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField183111.Value = @"Kardiyovasküler hastalık var mı?";

                    DIAGNOSISFIELD182811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 101, 122, 106, false);
                    DIAGNOSISFIELD182811.Name = "DIAGNOSISFIELD182811";
                    DIAGNOSISFIELD182811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD182811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD182811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD182811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD182811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD182811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD182811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD182811.Value = @"{#LE_HD_CARDIOVASCULAR#}";

                    NewField182161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 101, 199, 106, false);
                    NewField182161111.Name = "NewField182161111";
                    NewField182161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField182161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField182161111.TextFont.Name = "Arial";
                    NewField182161111.TextFont.Bold = true;
                    NewField182161111.TextFont.Underline = true;
                    NewField182161111.TextFont.CharSet = 162;
                    NewField182161111.Value = @"{#LE_HD_CARDIOVASCULAR_DESC#}";

                    NewField193111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 107, 90, 112, false);
                    NewField193111.Name = "NewField193111";
                    NewField193111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField193111.Value = @"Pulmoner hastalık var mı?";

                    DIAGNOSISFIELD192811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 107, 122, 112, false);
                    DIAGNOSISFIELD192811.Name = "DIAGNOSISFIELD192811";
                    DIAGNOSISFIELD192811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD192811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD192811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD192811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD192811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD192811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD192811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD192811.Value = @"{#LE_HD_PULMONARY#}";

                    NewField192161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 107, 199, 112, false);
                    NewField192161111.Name = "NewField192161111";
                    NewField192161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField192161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField192161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField192161111.TextFont.Name = "Arial";
                    NewField192161111.TextFont.Bold = true;
                    NewField192161111.TextFont.Underline = true;
                    NewField192161111.TextFont.CharSet = 162;
                    NewField192161111.Value = @"{#LE_HD_PULMONARY_DESC#}";

                    NewField104111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 113, 90, 118, false);
                    NewField104111.Name = "NewField104111";
                    NewField104111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField104111.Value = @"Organ yetmezliği var mı?";

                    DIAGNOSISFIELD103811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 113, 122, 118, false);
                    DIAGNOSISFIELD103811.Name = "DIAGNOSISFIELD103811";
                    DIAGNOSISFIELD103811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD103811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD103811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD103811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD103811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD103811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD103811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD103811.Value = @"{#LE_HD_ORGANFAILURE#}";

                    NewField103161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 113, 199, 118, false);
                    NewField103161111.Name = "NewField103161111";
                    NewField103161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField103161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField103161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField103161111.TextFont.Name = "Arial";
                    NewField103161111.TextFont.Bold = true;
                    NewField103161111.TextFont.Underline = true;
                    NewField103161111.TextFont.CharSet = 162;
                    NewField103161111.Value = @"{#LE_HD_ORGANFAILURE_DESC#}";

                    NewField114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 119, 90, 127, false);
                    NewField114111.Name = "NewField114111";
                    NewField114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114111.Value = @"Sistemik (HT,DM, Romatolojik, Endokrinolojik, vb.) hastalıklar var mı?";

                    DIAGNOSISFIELD113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 119, 122, 127, false);
                    DIAGNOSISFIELD113811.Name = "DIAGNOSISFIELD113811";
                    DIAGNOSISFIELD113811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD113811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD113811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD113811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD113811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD113811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD113811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD113811.Value = @"{#LE_HD_SYSTEMICDISEASE#}";

                    NewField113161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 119, 199, 127, false);
                    NewField113161111.Name = "NewField113161111";
                    NewField113161111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113161111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField113161111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113161111.TextFont.Name = "Arial";
                    NewField113161111.TextFont.Bold = true;
                    NewField113161111.TextFont.Underline = true;
                    NewField113161111.TextFont.CharSet = 162;
                    NewField113161111.Value = @"{#LE_HD_SYSTEMICDISEASE_DESC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = ParentGroup.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    NewField121611.CalcValue = NewField121611.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    DIAGNOSISFIELD11411.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_WhichLevel) : "");
                    NewField1111401.CalcValue = NewField1111401.Value;
                    DIAGNOSISFIELD1118301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_OscillationandPosture) : "");
                    DIAGNOSISFIELD1118301.PostFieldValueCalculation();
                    NewField1111161301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_Oscillationand_Desc) : "");
                    NewField1211401.CalcValue = NewField1211401.Value;
                    DIAGNOSISFIELD1218301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_WalkingSpeed) : "");
                    DIAGNOSISFIELD1218301.PostFieldValueCalculation();
                    NewField1211161301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_WalkingSpeed_Desc) : "");
                    NewField1311401.CalcValue = NewField1311401.Value;
                    DIAGNOSISFIELD1318301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_StrideLength) : "");
                    DIAGNOSISFIELD1318301.PostFieldValueCalculation();
                    NewField1311161301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_StrideLength_Desc) : "");
                    NewField1411401.CalcValue = NewField1411401.Value;
                    DIAGNOSISFIELD1418301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_StepClimbing) : "");
                    DIAGNOSISFIELD1418301.PostFieldValueCalculation();
                    NewField1411161301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_StepClimbing_Desc) : "");
                    NewField1511401.CalcValue = NewField1511401.Value;
                    DIAGNOSISFIELD1518301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_WalkBackwards) : "");
                    DIAGNOSISFIELD1518301.PostFieldValueCalculation();
                    NewField1511161301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_WalkBackwards_Desc) : "");
                    NewField1611401.CalcValue = NewField1611401.Value;
                    DIAGNOSISFIELD1618301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_Waterproof) : "");
                    DIAGNOSISFIELD1618301.PostFieldValueCalculation();
                    NewField1611161301.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_TEM_Waterproof_Desc) : "");
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    DIAGNOSISFIELD1141.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Heigth) : "");
                    NewField1271.CalcValue = NewField1271.Value;
                    DIAGNOSISFIELD1241.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Weight) : "");
                    NewField1371.CalcValue = NewField1371.Value;
                    DIAGNOSISFIELD1341.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_AktivityLevel) : "");
                    NewField11131.CalcValue = NewField11131.Value;
                    DIAGNOSISFIELD11821.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_PreferencePetition) : "");
                    DIAGNOSISFIELD11821.PostFieldValueCalculation();
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField1216111.CalcValue = NewField1216111.Value;
                    NewField11116121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_PreferencePetition_Desc) : "");
                    NewField113111.CalcValue = NewField113111.Value;
                    DIAGNOSISFIELD112811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_StumpZone) : "");
                    DIAGNOSISFIELD112811.PostFieldValueCalculation();
                    NewField112161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_StumpZone_Desc) : "");
                    NewField123111.CalcValue = NewField123111.Value;
                    DIAGNOSISFIELD122811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_WeightTolerance) : "");
                    DIAGNOSISFIELD122811.PostFieldValueCalculation();
                    NewField122161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_WeightTolerance_desc) : "");
                    NewField133111.CalcValue = NewField133111.Value;
                    DIAGNOSISFIELD132811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Contracture) : "");
                    DIAGNOSISFIELD132811.PostFieldValueCalculation();
                    NewField132161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Contracture_Desc) : "");
                    NewField143111.CalcValue = NewField143111.Value;
                    DIAGNOSISFIELD142811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_SingleSideAmputate) : "");
                    DIAGNOSISFIELD142811.PostFieldValueCalculation();
                    NewField142161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_SingleSideAmputate_Desc) : "");
                    NewField153111.CalcValue = NewField153111.Value;
                    DIAGNOSISFIELD152811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Ambulation) : "");
                    DIAGNOSISFIELD152811.PostFieldValueCalculation();
                    NewField152161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Ambulation_Desc) : "");
                    NewField163111.CalcValue = NewField163111.Value;
                    DIAGNOSISFIELD162811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Musculoskeletal) : "");
                    DIAGNOSISFIELD162811.PostFieldValueCalculation();
                    NewField162161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Musculoskeletal_Desc) : "");
                    NewField173111.CalcValue = NewField173111.Value;
                    DIAGNOSISFIELD172811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Neurological) : "");
                    DIAGNOSISFIELD172811.PostFieldValueCalculation();
                    NewField172161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Neurological_Desc) : "");
                    NewField183111.CalcValue = NewField183111.Value;
                    DIAGNOSISFIELD182811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Cardiovascular) : "");
                    DIAGNOSISFIELD182811.PostFieldValueCalculation();
                    NewField182161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Cardiovascular_Desc) : "");
                    NewField193111.CalcValue = NewField193111.Value;
                    DIAGNOSISFIELD192811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Pulmonary) : "");
                    DIAGNOSISFIELD192811.PostFieldValueCalculation();
                    NewField192161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_Pulmonary_Desc) : "");
                    NewField104111.CalcValue = NewField104111.Value;
                    DIAGNOSISFIELD103811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_OrganFailure) : "");
                    DIAGNOSISFIELD103811.PostFieldValueCalculation();
                    NewField103161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_OrganFailure_Desc) : "");
                    NewField114111.CalcValue = NewField114111.Value;
                    DIAGNOSISFIELD113811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_SystemicDisease) : "");
                    DIAGNOSISFIELD113811.PostFieldValueCalculation();
                    NewField113161111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_HD_SystemicDisease_Desc) : "");
                    return new TTReportObject[] { NewField121611,NewField11711,DIAGNOSISFIELD11411,NewField1111401,DIAGNOSISFIELD1118301,NewField1111161301,NewField1211401,DIAGNOSISFIELD1218301,NewField1211161301,NewField1311401,DIAGNOSISFIELD1318301,NewField1311161301,NewField1411401,DIAGNOSISFIELD1418301,NewField1411161301,NewField1511401,DIAGNOSISFIELD1518301,NewField1511161301,NewField1611401,DIAGNOSISFIELD1618301,NewField1611161301,NewField11611,NewField1171,DIAGNOSISFIELD1141,NewField1271,DIAGNOSISFIELD1241,NewField1371,DIAGNOSISFIELD1341,NewField11131,DIAGNOSISFIELD11821,NewField111611,NewField1116111,NewField1216111,NewField11116121,NewField113111,DIAGNOSISFIELD112811,NewField112161111,NewField123111,DIAGNOSISFIELD122811,NewField122161111,NewField133111,DIAGNOSISFIELD132811,NewField132161111,NewField143111,DIAGNOSISFIELD142811,NewField142161111,NewField153111,DIAGNOSISFIELD152811,NewField152161111,NewField163111,DIAGNOSISFIELD162811,NewField162161111,NewField173111,DIAGNOSISFIELD172811,NewField172161111,NewField183111,DIAGNOSISFIELD182811,NewField182161111,NewField193111,DIAGNOSISFIELD192811,NewField192161111,NewField104111,DIAGNOSISFIELD103811,NewField103161111,NewField114111,DIAGNOSISFIELD113811,NewField113161111};
                }
                public override void RunPreScript()
                {
#region ALT_EKSTREMITE_TEM BODY_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.LowerExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion ALT_EKSTREMITE_TEM BODY_PreScript
                }
            }

        }

        public ALT_EKSTREMITE_TEMGroup ALT_EKSTREMITE_TEM;

        public partial class UST_EKSTREMITE_HEADERGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public UST_EKSTREMITE_HEADERGroupHeader Header()
            {
                return (UST_EKSTREMITE_HEADERGroupHeader)_header;
            }

            new public UST_EKSTREMITE_HEADERGroupFooter Footer()
            {
                return (UST_EKSTREMITE_HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK11 { get {return Header().XXXXXXBASLIK11;} }
            public TTReportField Reçete11 { get {return Header().Reçete11;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public UST_EKSTREMITE_HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UST_EKSTREMITE_HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LowerExtremity.GetExtremityReportInfoByObjId_Class>("GetExtremityReportInfoByObjId", LowerExtremity.GetExtremityReportInfoByObjId((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new UST_EKSTREMITE_HEADERGroupHeader(this);
                _footer = new UST_EKSTREMITE_HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class UST_EKSTREMITE_HEADERGroupHeader : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK11;
                public TTReportField Reçete11;
                public TTReportField LOGO1; 
                public UST_EKSTREMITE_HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 5, 189, 46, false);
                    XXXXXXBASLIK11.Name = "XXXXXXBASLIK11";
                    XXXXXXBASLIK11.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.TextFont.Name = "Arial";
                    XXXXXXBASLIK11.TextFont.Size = 11;
                    XXXXXXBASLIK11.TextFont.Bold = true;
                    XXXXXXBASLIK11.TextFont.CharSet = 162;
                    XXXXXXBASLIK11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Reçete11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 48, 184, 53, false);
                    Reçete11.Name = "Reçete11";
                    Reçete11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Reçete11.MultiLine = EvetHayirEnum.ehEvet;
                    Reçete11.NoClip = EvetHayirEnum.ehEvet;
                    Reçete11.WordBreak = EvetHayirEnum.ehEvet;
                    Reçete11.TextFont.Name = "Arial";
                    Reçete11.TextFont.Size = 12;
                    Reçete11.TextFont.Bold = true;
                    Reçete11.TextFont.CharSet = 162;
                    Reçete11.Value = @"TIBBİ UYGUNLUK KOMİSYONU HASTA DEĞERLENDİRME FORMU
(MYOELEKTRİK ÜST EKSTREMİTE PROTEZLERİ İÇİN)";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 5, 34, 28, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO1.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO1.DataMember = "EMBLEM";
                    LOGO1.TextFont.Name = "Courier New";
                    LOGO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = ParentGroup.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    Reçete11.CalcValue = Reçete11.Value;
                    LOGO1.CalcValue = @"";
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { Reçete11,LOGO1,XXXXXXBASLIK11};
                }
                public override void RunPreScript()
                {
#region UST_EKSTREMITE_HEADER HEADER_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.UpperExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
            
            this.LOGO1.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion UST_EKSTREMITE_HEADER HEADER_PreScript
                }
            }
            public partial class UST_EKSTREMITE_HEADERGroupFooter : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                 
                public UST_EKSTREMITE_HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public UST_EKSTREMITE_HEADERGroup UST_EKSTREMITE_HEADER;

        public partial class UST_EKSTREMITEGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public UST_EKSTREMITEGroupBody Body()
            {
                return (UST_EKSTREMITEGroupBody)_body;
            }
            public TTReportField FULLNAME11 { get {return Body().FULLNAME11;} }
            public TTReportField lblPAtientName11 { get {return Body().lblPAtientName11;} }
            public TTReportField ExaminationDate1 { get {return Body().ExaminationDate1;} }
            public TTReportField lblPAtientName111 { get {return Body().lblPAtientName111;} }
            public TTReportField UNIQUEREFNO1 { get {return Body().UNIQUEREFNO1;} }
            public TTReportField lblPAtientName121 { get {return Body().lblPAtientName121;} }
            public TTReportField FULLNAME121 { get {return Body().FULLNAME121;} }
            public TTReportField lblPAtientName131 { get {return Body().lblPAtientName131;} }
            public TTReportField FULLNAME131 { get {return Body().FULLNAME131;} }
            public TTReportField lblPAtientName141 { get {return Body().lblPAtientName141;} }
            public TTReportField FULLNAME141 { get {return Body().FULLNAME141;} }
            public TTReportField lblPAtientName151 { get {return Body().lblPAtientName151;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField DIAGNOSISFIELD11 { get {return Body().DIAGNOSISFIELD11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField DIAGNOSISFIELD111 { get {return Body().DIAGNOSISFIELD111;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField DIAGNOSISFIELD121 { get {return Body().DIAGNOSISFIELD121;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField DIAGNOSISFIELD131 { get {return Body().DIAGNOSISFIELD131;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField DIAGNOSISFIELD141 { get {return Body().DIAGNOSISFIELD141;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField DIAGNOSISFIELD151 { get {return Body().DIAGNOSISFIELD151;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField DIAGNOSISFIELD161 { get {return Body().DIAGNOSISFIELD161;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField DIAGNOSISFIELD171 { get {return Body().DIAGNOSISFIELD171;} }
            public TTReportField NewField1201 { get {return Body().NewField1201;} }
            public TTReportField DIAGNOSISFIELD1171 { get {return Body().DIAGNOSISFIELD1171;} }
            public TTReportField NewField1301 { get {return Body().NewField1301;} }
            public TTReportField DIAGNOSISFIELD1271 { get {return Body().DIAGNOSISFIELD1271;} }
            public TTReportField NewField1401 { get {return Body().NewField1401;} }
            public TTReportField DIAGNOSISFIELD1371 { get {return Body().DIAGNOSISFIELD1371;} }
            public TTReportField NewField1501 { get {return Body().NewField1501;} }
            public TTReportField DIAGNOSISFIELD1471 { get {return Body().DIAGNOSISFIELD1471;} }
            public TTReportField NewField1601 { get {return Body().NewField1601;} }
            public TTReportField DIAGNOSISFIELD1571 { get {return Body().DIAGNOSISFIELD1571;} }
            public TTReportField NewField11061 { get {return Body().NewField11061;} }
            public TTReportField DIAGNOSISFIELD11751 { get {return Body().DIAGNOSISFIELD11751;} }
            public TTReportField PNAME1 { get {return Body().PNAME1;} }
            public TTReportField PSURNAME1 { get {return Body().PSURNAME1;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField1701 { get {return Body().NewField1701;} }
            public TTReportField DIAGNOSISFIELD1671 { get {return Body().DIAGNOSISFIELD1671;} }
            public TTReportField NewField1801 { get {return Body().NewField1801;} }
            public TTReportField DIAGNOSISFIELD1771 { get {return Body().DIAGNOSISFIELD1771;} }
            public TTReportField NewField1901 { get {return Body().NewField1901;} }
            public TTReportField DIAGNOSISFIELD1871 { get {return Body().DIAGNOSISFIELD1871;} }
            public TTReportField NewField1011 { get {return Body().NewField1011;} }
            public TTReportField DIAGNOSISFIELD1971 { get {return Body().DIAGNOSISFIELD1971;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField DIAGNOSISFIELD1081 { get {return Body().DIAGNOSISFIELD1081;} }
            public TTReportField NewField1211 { get {return Body().NewField1211;} }
            public TTReportField DIAGNOSISFIELD1181 { get {return Body().DIAGNOSISFIELD1181;} }
            public TTReportField NewField1311 { get {return Body().NewField1311;} }
            public TTReportField DIAGNOSISFIELD1281 { get {return Body().DIAGNOSISFIELD1281;} }
            public TTReportField ReportDate1 { get {return Body().ReportDate1;} }
            public TTReportField ReportNo1 { get {return Body().ReportNo1;} }
            public UST_EKSTREMITEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UST_EKSTREMITEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new UST_EKSTREMITEGroupBody(this);
            }

            public partial class UST_EKSTREMITEGroupBody : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField FULLNAME11;
                public TTReportField lblPAtientName11;
                public TTReportField ExaminationDate1;
                public TTReportField lblPAtientName111;
                public TTReportField UNIQUEREFNO1;
                public TTReportField lblPAtientName121;
                public TTReportField FULLNAME121;
                public TTReportField lblPAtientName131;
                public TTReportField FULLNAME131;
                public TTReportField lblPAtientName141;
                public TTReportField FULLNAME141;
                public TTReportField lblPAtientName151;
                public TTReportField NewField11;
                public TTReportField DIAGNOSISFIELD11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField14;
                public TTReportField NewField111;
                public TTReportField DIAGNOSISFIELD111;
                public TTReportField NewField141;
                public TTReportField DIAGNOSISFIELD121;
                public TTReportField NewField151;
                public TTReportField DIAGNOSISFIELD131;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField DIAGNOSISFIELD141;
                public TTReportField NewField181;
                public TTReportField DIAGNOSISFIELD151;
                public TTReportField NewField191;
                public TTReportField DIAGNOSISFIELD161;
                public TTReportField NewField102;
                public TTReportField DIAGNOSISFIELD171;
                public TTReportField NewField1201;
                public TTReportField DIAGNOSISFIELD1171;
                public TTReportField NewField1301;
                public TTReportField DIAGNOSISFIELD1271;
                public TTReportField NewField1401;
                public TTReportField DIAGNOSISFIELD1371;
                public TTReportField NewField1501;
                public TTReportField DIAGNOSISFIELD1471;
                public TTReportField NewField1601;
                public TTReportField DIAGNOSISFIELD1571;
                public TTReportField NewField11061;
                public TTReportField DIAGNOSISFIELD11751;
                public TTReportField PNAME1;
                public TTReportField PSURNAME1;
                public TTReportField NewField1161;
                public TTReportField NewField1701;
                public TTReportField DIAGNOSISFIELD1671;
                public TTReportField NewField1801;
                public TTReportField DIAGNOSISFIELD1771;
                public TTReportField NewField1901;
                public TTReportField DIAGNOSISFIELD1871;
                public TTReportField NewField1011;
                public TTReportField DIAGNOSISFIELD1971;
                public TTReportField NewField1111;
                public TTReportField DIAGNOSISFIELD1081;
                public TTReportField NewField1211;
                public TTReportField DIAGNOSISFIELD1181;
                public TTReportField NewField1311;
                public TTReportField DIAGNOSISFIELD1281;
                public TTReportField ReportDate1;
                public TTReportField ReportNo1; 
                public UST_EKSTREMITEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 226;
                    RepeatCount = 0;
                    
                    FULLNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 11, 191, 16, false);
                    FULLNAME11.Name = "FULLNAME11";
                    FULLNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME11.Value = @"{%PNAME1%} {%PSURNAME1%}";

                    lblPAtientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 11, 36, 16, false);
                    lblPAtientName11.Name = "lblPAtientName11";
                    lblPAtientName11.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName11.Value = @"Adı Soyadı :";

                    ExaminationDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 5, 191, 10, false);
                    ExaminationDate1.Name = "ExaminationDate1";
                    ExaminationDate1.DrawStyle = DrawStyleConstants.vbSolid;
                    ExaminationDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExaminationDate1.Value = @"{#UST_EKSTREMITE_HEADER.PROCESSDATE#}";

                    lblPAtientName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 36, 10, false);
                    lblPAtientName111.Name = "lblPAtientName111";
                    lblPAtientName111.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName111.Value = @"Muayene Tarihi";

                    UNIQUEREFNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 17, 191, 22, false);
                    UNIQUEREFNO1.Name = "UNIQUEREFNO1";
                    UNIQUEREFNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    UNIQUEREFNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO1.Value = @"{#UST_EKSTREMITE_HEADER.UNIQUEREFNO#}";

                    lblPAtientName121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 17, 36, 22, false);
                    lblPAtientName121.Name = "lblPAtientName121";
                    lblPAtientName121.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName121.Value = @"T.C. :";

                    FULLNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 23, 191, 28, false);
                    FULLNAME121.Name = "FULLNAME121";
                    FULLNAME121.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME121.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME121.Value = @"{#UST_EKSTREMITE_HEADER.BIRTHDATE#}";

                    lblPAtientName131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 23, 36, 28, false);
                    lblPAtientName131.Name = "lblPAtientName131";
                    lblPAtientName131.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName131.Value = @"Doğum Tarihi :";

                    FULLNAME131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 29, 191, 34, false);
                    FULLNAME131.Name = "FULLNAME131";
                    FULLNAME131.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME131.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME131.Value = @"{#UST_EKSTREMITE_HEADER.BIRTHPLACE#}";

                    lblPAtientName141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 29, 36, 34, false);
                    lblPAtientName141.Name = "lblPAtientName141";
                    lblPAtientName141.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName141.Value = @"Doğum Yeri :";

                    FULLNAME141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 35, 191, 40, false);
                    FULLNAME141.Name = "FULLNAME141";
                    FULLNAME141.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME141.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME141.Value = @"{#UST_EKSTREMITE_HEADER.MOBILEPHONE#}";

                    lblPAtientName151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 35, 36, 40, false);
                    lblPAtientName151.Name = "lblPAtientName151";
                    lblPAtientName151.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName151.Value = @"Telefon :";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 45, 81, 50, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"Tanı";

                    DIAGNOSISFIELD11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 45, 190, 50, false);
                    DIAGNOSISFIELD11.Name = "DIAGNOSISFIELD11";
                    DIAGNOSISFIELD11.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 51, 81, 56, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.Value = @"Yaralanma nedeni ve tarihi:";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 51, 190, 56, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.Value = @"{#UST_EKSTREMITE_HEADER.UE_CAUSEOFINJURY#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 57, 81, 62, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.Value = @"Amputasyon tarihi:
";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 57, 190, 62, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField131.Value = @"{#UST_EKSTREMITE_HEADER.UE_AMPUTATIONDATE#}
";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 63, 190, 68, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.Underline = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"HALEN PROTEZ KULLANIYORSA:";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 70, 81, 75, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.Value = @"Kaçıncı protezi olduğu:";

                    DIAGNOSISFIELD111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 70, 190, 75, false);
                    DIAGNOSISFIELD111.Name = "DIAGNOSISFIELD111";
                    DIAGNOSISFIELD111.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD111.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111.Value = @"{#UST_EKSTREMITE_HEADER.UE_PROSTHESISNUMBER#}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 76, 81, 81, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.Value = @"Yapım tarihi:";

                    DIAGNOSISFIELD121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 76, 190, 81, false);
                    DIAGNOSISFIELD121.Name = "DIAGNOSISFIELD121";
                    DIAGNOSISFIELD121.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD121.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD121.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD121.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD121.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD121.Value = @"{#UST_EKSTREMITE_HEADER.UE_CONSTRUCTIONDATE#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 82, 81, 87, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.Value = @"Protez tipi:";

                    DIAGNOSISFIELD131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 82, 190, 87, false);
                    DIAGNOSISFIELD131.Name = "DIAGNOSISFIELD131";
                    DIAGNOSISFIELD131.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD131.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD131.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD131.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD131.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD131.Value = @"{#UST_EKSTREMITE_HEADER.UE_PROSTHETICTYPE#}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 95, 190, 100, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.Underline = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"SAĞLIK KURULU RAPORU:";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 101, 81, 106, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.Value = @"Raporu Veren Kurum";

                    DIAGNOSISFIELD141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 101, 190, 106, false);
                    DIAGNOSISFIELD141.Name = "DIAGNOSISFIELD141";
                    DIAGNOSISFIELD141.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD141.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD141.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD141.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD141.Value = @"Gaziler Fizik Tedavi ve Rehabilitasyon Eğitim ve Araştırma XXXXXX";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 107, 81, 112, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.Value = @"Rapor Tarih ve Numarası";

                    DIAGNOSISFIELD151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 107, 190, 112, false);
                    DIAGNOSISFIELD151.Name = "DIAGNOSISFIELD151";
                    DIAGNOSISFIELD151.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD151.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD151.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD151.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD151.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD151.Value = @"{%ReportDate1%} - {%ReportNo1%}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 113, 81, 125, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.Value = @"Raporda Yazılan Protez Tipi
";

                    DIAGNOSISFIELD161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 113, 190, 125, false);
                    DIAGNOSISFIELD161.Name = "DIAGNOSISFIELD161";
                    DIAGNOSISFIELD161.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD161.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD161.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD161.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD161.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD161.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_PROSTHETICTYPE#}";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 126, 81, 131, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.Value = @"Tıbbi Gerekçe Yazılmış mı?";

                    DIAGNOSISFIELD171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 126, 190, 131, false);
                    DIAGNOSISFIELD171.Name = "DIAGNOSISFIELD171";
                    DIAGNOSISFIELD171.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD171.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD171.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD171.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD171.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD171.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD171.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD171.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_MEDICALREASON#}";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 162, 81, 167, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.Value = @"Başhekim Onayı Var mı?";

                    DIAGNOSISFIELD1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 162, 190, 167, false);
                    DIAGNOSISFIELD1171.Name = "DIAGNOSISFIELD1171";
                    DIAGNOSISFIELD1171.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1171.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1171.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1171.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1171.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1171.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1171.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1171.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_HEADDOCTORAPPROVE#}";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 156, 81, 161, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1301.Value = @"Psikiyatri Uzman Onayı Var mı?";

                    DIAGNOSISFIELD1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 156, 190, 161, false);
                    DIAGNOSISFIELD1271.Name = "DIAGNOSISFIELD1271";
                    DIAGNOSISFIELD1271.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1271.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1271.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1271.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1271.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1271.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1271.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1271.Value = @"{#UST_EKSTREMITE_HEADER.LE_PSYCHIATRICEXPERTAPPROVE#}";

                    NewField1401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 150, 81, 155, false);
                    NewField1401.Name = "NewField1401";
                    NewField1401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1401.Value = @"Ortopedi Uzman Onayı Var mı?";

                    DIAGNOSISFIELD1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 150, 190, 155, false);
                    DIAGNOSISFIELD1371.Name = "DIAGNOSISFIELD1371";
                    DIAGNOSISFIELD1371.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1371.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1371.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1371.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1371.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1371.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1371.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1371.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_ORTHOPEDICEXPAPPROVE#}";

                    NewField1501 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 144, 81, 149, false);
                    NewField1501.Name = "NewField1501";
                    NewField1501.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1501.Value = @"FTR Uzman Onayı Var mı?";

                    DIAGNOSISFIELD1471 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 144, 190, 149, false);
                    DIAGNOSISFIELD1471.Name = "DIAGNOSISFIELD1471";
                    DIAGNOSISFIELD1471.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1471.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1471.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1471.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1471.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1471.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1471.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1471.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_FTREXPERTAPPROVE#}";

                    NewField1601 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 138, 81, 143, false);
                    NewField1601.Name = "NewField1601";
                    NewField1601.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1601.Value = @"3. basamak sağlık kurumu";

                    DIAGNOSISFIELD1571 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 138, 190, 143, false);
                    DIAGNOSISFIELD1571.Name = "DIAGNOSISFIELD1571";
                    DIAGNOSISFIELD1571.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1571.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1571.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1571.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1571.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1571.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1571.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1571.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_THIRDSTEPHEALTHINST#}";

                    NewField11061 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 132, 81, 137, false);
                    NewField11061.Name = "NewField11061";
                    NewField11061.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11061.Value = @"sEMG Belgelendirilmiş mi?";

                    DIAGNOSISFIELD11751 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 132, 190, 137, false);
                    DIAGNOSISFIELD11751.Name = "DIAGNOSISFIELD11751";
                    DIAGNOSISFIELD11751.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11751.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11751.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11751.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11751.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11751.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11751.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11751.Value = @"{#UST_EKSTREMITE_HEADER.UE_SK_SEMG#}";

                    PNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 12, 237, 17, false);
                    PNAME1.Name = "PNAME1";
                    PNAME1.Visible = EvetHayirEnum.ehHayir;
                    PNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME1.Value = @"{#UST_EKSTREMITE_HEADER.NAME#}";

                    PSURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 20, 239, 25, false);
                    PSURNAME1.Name = "PSURNAME1";
                    PSURNAME1.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME1.Value = @"{#UST_EKSTREMITE_HEADER.SURNAME#}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 173, 190, 178, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.Underline = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"REÇETE İÇERİĞİ:";

                    NewField1701 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 179, 81, 184, false);
                    NewField1701.Name = "NewField1701";
                    NewField1701.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1701.Value = @"Hasta Adı Soyadı ve T.C kimlik NumarasıVar mı?";

                    DIAGNOSISFIELD1671 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 179, 190, 184, false);
                    DIAGNOSISFIELD1671.Name = "DIAGNOSISFIELD1671";
                    DIAGNOSISFIELD1671.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1671.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1671.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1671.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1671.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1671.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1671.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1671.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_PATIENTNAMESURNAME#}";

                    NewField1801 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 185, 81, 195, false);
                    NewField1801.Name = "NewField1801";
                    NewField1801.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1801.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1801.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1801.Value = @"Reçeteyi düzenleyen sağlık hizmet sunucusu adı veya MEDULA tesis kodu var mı?";

                    DIAGNOSISFIELD1771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 185, 190, 195, false);
                    DIAGNOSISFIELD1771.Name = "DIAGNOSISFIELD1771";
                    DIAGNOSISFIELD1771.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1771.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1771.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSISFIELD1771.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1771.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1771.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1771.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1771.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1771.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_MEDULAINSCODE#}";

                    NewField1901 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 194, 81, 199, false);
                    NewField1901.Name = "NewField1901";
                    NewField1901.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1901.Value = @"Medula veya Protokol Numarası Var mı?";

                    DIAGNOSISFIELD1871 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 194, 190, 199, false);
                    DIAGNOSISFIELD1871.Name = "DIAGNOSISFIELD1871";
                    DIAGNOSISFIELD1871.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1871.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1871.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1871.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1871.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1871.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1871.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1871.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_MEDULAORPROTOCOLNO#}";

                    NewField1011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 200, 81, 205, false);
                    NewField1011.Name = "NewField1011";
                    NewField1011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1011.Value = @"Tanı ve ICD-10 Kodu Varmı";

                    DIAGNOSISFIELD1971 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 200, 190, 205, false);
                    DIAGNOSISFIELD1971.Name = "DIAGNOSISFIELD1971";
                    DIAGNOSISFIELD1971.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1971.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1971.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1971.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1971.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1971.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1971.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1971.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_DIAGNOSANDICD10CODE#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 206, 81, 211, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.Value = @"Cihazın adı/taraf/adet bilgisi var mı?";

                    DIAGNOSISFIELD1081 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 206, 190, 211, false);
                    DIAGNOSISFIELD1081.Name = "DIAGNOSISFIELD1081";
                    DIAGNOSISFIELD1081.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1081.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1081.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1081.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1081.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1081.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1081.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1081.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_MACHINENAME#}";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 212, 81, 217, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.Value = @"Cihazın adı/taraf/adet bilgisi doğrumu?";

                    DIAGNOSISFIELD1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 212, 190, 217, false);
                    DIAGNOSISFIELD1181.Name = "DIAGNOSISFIELD1181";
                    DIAGNOSISFIELD1181.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1181.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1181.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1181.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1181.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1181.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1181.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1181.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_MACHINENAMEISCORRECT#}";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 218, 81, 223, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311.Value = @"Islak İmza Varmı?";

                    DIAGNOSISFIELD1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 218, 190, 223, false);
                    DIAGNOSISFIELD1281.Name = "DIAGNOSISFIELD1281";
                    DIAGNOSISFIELD1281.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1281.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1281.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1281.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1281.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1281.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD1281.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD1281.Value = @"{#UST_EKSTREMITE_HEADER.UE_RI_WETSIGNATURE#}";

                    ReportDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 37, 249, 42, false);
                    ReportDate1.Name = "ReportDate1";
                    ReportDate1.Visible = EvetHayirEnum.ehHayir;
                    ReportDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportDate1.Value = @"{#UST_EKSTREMITE_HEADER.REPORTDATE#}";

                    ReportNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 45, 249, 50, false);
                    ReportNo1.Name = "ReportNo1";
                    ReportNo1.Visible = EvetHayirEnum.ehHayir;
                    ReportNo1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportNo1.Value = @"{#UST_EKSTREMITE_HEADER.REPORTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = MyParentReport.UST_EKSTREMITE_HEADER.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    PNAME1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Name) : "");
                    PSURNAME1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Surname) : "");
                    FULLNAME11.CalcValue = MyParentReport.UST_EKSTREMITE.PNAME1.CalcValue + @" " + MyParentReport.UST_EKSTREMITE.PSURNAME1.CalcValue;
                    lblPAtientName11.CalcValue = lblPAtientName11.Value;
                    ExaminationDate1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ProcessDate) : "");
                    lblPAtientName111.CalcValue = lblPAtientName111.Value;
                    UNIQUEREFNO1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UniqueRefNo) : "");
                    lblPAtientName121.CalcValue = lblPAtientName121.Value;
                    FULLNAME121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.BirthDate) : "");
                    lblPAtientName131.CalcValue = lblPAtientName131.Value;
                    FULLNAME131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.BirthPlace) : "");
                    lblPAtientName141.CalcValue = lblPAtientName141.Value;
                    FULLNAME141.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.MobilePhone) : "");
                    lblPAtientName151.CalcValue = lblPAtientName151.Value;
                    NewField11.CalcValue = NewField11.Value;
                    DIAGNOSISFIELD11.CalcValue = DIAGNOSISFIELD11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_CauseOfInjury) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_AmputationDate) : "") + @"
";
                    NewField14.CalcValue = NewField14.Value;
                    NewField111.CalcValue = NewField111.Value;
                    DIAGNOSISFIELD111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_ProsthesisNumber) : "");
                    NewField141.CalcValue = NewField141.Value;
                    DIAGNOSISFIELD121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_ConstructionDate) : "");
                    NewField151.CalcValue = NewField151.Value;
                    DIAGNOSISFIELD131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_ProstheticType) : "");
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    DIAGNOSISFIELD141.CalcValue = DIAGNOSISFIELD141.Value;
                    NewField181.CalcValue = NewField181.Value;
                    ReportDate1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ReportDate) : "");
                    ReportNo1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ReportNo) : "");
                    DIAGNOSISFIELD151.CalcValue = MyParentReport.UST_EKSTREMITE.ReportDate1.CalcValue + @" - " + MyParentReport.UST_EKSTREMITE.ReportNo1.CalcValue;
                    NewField191.CalcValue = NewField191.Value;
                    DIAGNOSISFIELD161.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_ProstheticType) : "");
                    NewField102.CalcValue = NewField102.Value;
                    DIAGNOSISFIELD171.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_MedicalReason) : "");
                    DIAGNOSISFIELD171.PostFieldValueCalculation();
                    NewField1201.CalcValue = NewField1201.Value;
                    DIAGNOSISFIELD1171.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_HeadDoctorApprove) : "");
                    DIAGNOSISFIELD1171.PostFieldValueCalculation();
                    NewField1301.CalcValue = NewField1301.Value;
                    DIAGNOSISFIELD1271.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.LE_PsychiatricExpertApprove) : "");
                    DIAGNOSISFIELD1271.PostFieldValueCalculation();
                    NewField1401.CalcValue = NewField1401.Value;
                    DIAGNOSISFIELD1371.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_OrthopedicExpApprove) : "");
                    DIAGNOSISFIELD1371.PostFieldValueCalculation();
                    NewField1501.CalcValue = NewField1501.Value;
                    DIAGNOSISFIELD1471.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_FTRExpertApprove) : "");
                    DIAGNOSISFIELD1471.PostFieldValueCalculation();
                    NewField1601.CalcValue = NewField1601.Value;
                    DIAGNOSISFIELD1571.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_ThirdStepHealthInst) : "");
                    DIAGNOSISFIELD1571.PostFieldValueCalculation();
                    NewField11061.CalcValue = NewField11061.Value;
                    DIAGNOSISFIELD11751.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_SK_sEMG) : "");
                    DIAGNOSISFIELD11751.PostFieldValueCalculation();
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1701.CalcValue = NewField1701.Value;
                    DIAGNOSISFIELD1671.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_PatientNameSurname) : "");
                    DIAGNOSISFIELD1671.PostFieldValueCalculation();
                    NewField1801.CalcValue = NewField1801.Value;
                    DIAGNOSISFIELD1771.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_MedulaInsCode) : "");
                    DIAGNOSISFIELD1771.PostFieldValueCalculation();
                    NewField1901.CalcValue = NewField1901.Value;
                    DIAGNOSISFIELD1871.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_MedulaOrProtocolNo) : "");
                    DIAGNOSISFIELD1871.PostFieldValueCalculation();
                    NewField1011.CalcValue = NewField1011.Value;
                    DIAGNOSISFIELD1971.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_DiagnosAndICD10Code) : "");
                    DIAGNOSISFIELD1971.PostFieldValueCalculation();
                    NewField1111.CalcValue = NewField1111.Value;
                    DIAGNOSISFIELD1081.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_MachineName) : "");
                    DIAGNOSISFIELD1081.PostFieldValueCalculation();
                    NewField1211.CalcValue = NewField1211.Value;
                    DIAGNOSISFIELD1181.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_MachineNameIsCorrect) : "");
                    DIAGNOSISFIELD1181.PostFieldValueCalculation();
                    NewField1311.CalcValue = NewField1311.Value;
                    DIAGNOSISFIELD1281.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_RI_WetSignature) : "");
                    DIAGNOSISFIELD1281.PostFieldValueCalculation();
                    return new TTReportObject[] { PNAME1,PSURNAME1,FULLNAME11,lblPAtientName11,ExaminationDate1,lblPAtientName111,UNIQUEREFNO1,lblPAtientName121,FULLNAME121,lblPAtientName131,FULLNAME131,lblPAtientName141,FULLNAME141,lblPAtientName151,NewField11,DIAGNOSISFIELD11,NewField12,NewField13,NewField121,NewField131,NewField14,NewField111,DIAGNOSISFIELD111,NewField141,DIAGNOSISFIELD121,NewField151,DIAGNOSISFIELD131,NewField161,NewField171,DIAGNOSISFIELD141,NewField181,ReportDate1,ReportNo1,DIAGNOSISFIELD151,NewField191,DIAGNOSISFIELD161,NewField102,DIAGNOSISFIELD171,NewField1201,DIAGNOSISFIELD1171,NewField1301,DIAGNOSISFIELD1271,NewField1401,DIAGNOSISFIELD1371,NewField1501,DIAGNOSISFIELD1471,NewField1601,DIAGNOSISFIELD1571,NewField11061,DIAGNOSISFIELD11751,NewField1161,NewField1701,DIAGNOSISFIELD1671,NewField1801,DIAGNOSISFIELD1771,NewField1901,DIAGNOSISFIELD1871,NewField1011,DIAGNOSISFIELD1971,NewField1111,DIAGNOSISFIELD1081,NewField1211,DIAGNOSISFIELD1181,NewField1311,DIAGNOSISFIELD1281};
                }
                public override void RunPreScript()
                {
#region UST_EKSTREMITE BODY_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.UpperExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion UST_EKSTREMITE BODY_PreScript
                }
            }

        }

        public UST_EKSTREMITEGroup UST_EKSTREMITE;

        public partial class UST_EKSTREMITE_HDGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public UST_EKSTREMITE_HDGroupBody Body()
            {
                return (UST_EKSTREMITE_HDGroupBody)_body;
            }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField11711 { get {return Body().NewField11711;} }
            public TTReportField DIAGNOSISFIELD11411 { get {return Body().DIAGNOSISFIELD11411;} }
            public TTReportField NewField111711 { get {return Body().NewField111711;} }
            public TTReportField DIAGNOSISFIELD111411 { get {return Body().DIAGNOSISFIELD111411;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField11116121 { get {return Body().NewField11116121;} }
            public TTReportField NewField113111 { get {return Body().NewField113111;} }
            public TTReportField DIAGNOSISFIELD112811 { get {return Body().DIAGNOSISFIELD112811;} }
            public TTReportField III1 { get {return Body().III1;} }
            public TTReportField NF1 { get {return Body().NF1;} }
            public TTReportField I_DIAG_1 { get {return Body().I_DIAG_1;} }
            public TTReportField LISO_1 { get {return Body().LISO_1;} }
            public TTReportField NF11 { get {return Body().NF11;} }
            public TTReportField I_DIAG_11 { get {return Body().I_DIAG_11;} }
            public TTReportField LISO_11 { get {return Body().LISO_11;} }
            public TTReportField NF12 { get {return Body().NF12;} }
            public TTReportField I_DIAG_12 { get {return Body().I_DIAG_12;} }
            public TTReportField LISO_12 { get {return Body().LISO_12;} }
            public TTReportField NF13 { get {return Body().NF13;} }
            public TTReportField I_DIAG_13 { get {return Body().I_DIAG_13;} }
            public TTReportField LISO_13 { get {return Body().LISO_13;} }
            public TTReportField NF14 { get {return Body().NF14;} }
            public TTReportField I_DIAG_14 { get {return Body().I_DIAG_14;} }
            public TTReportField LISO_14 { get {return Body().LISO_14;} }
            public TTReportField NF15 { get {return Body().NF15;} }
            public TTReportField I_DIAG_15 { get {return Body().I_DIAG_15;} }
            public TTReportField LISO_15 { get {return Body().LISO_15;} }
            public TTReportField NF16 { get {return Body().NF16;} }
            public TTReportField I_DIAG_16 { get {return Body().I_DIAG_16;} }
            public TTReportField LISO_16 { get {return Body().LISO_16;} }
            public TTReportField NF17 { get {return Body().NF17;} }
            public TTReportField I_DIAG_17 { get {return Body().I_DIAG_17;} }
            public TTReportField LISO_17 { get {return Body().LISO_17;} }
            public TTReportField NF18 { get {return Body().NF18;} }
            public TTReportField I_DIAG_18 { get {return Body().I_DIAG_18;} }
            public TTReportField LISO_18 { get {return Body().LISO_18;} }
            public TTReportField NF19 { get {return Body().NF19;} }
            public TTReportField I_DIAG_19 { get {return Body().I_DIAG_19;} }
            public TTReportField LISO_19 { get {return Body().LISO_19;} }
            public TTReportField NF20 { get {return Body().NF20;} }
            public TTReportField I_DIAG_20 { get {return Body().I_DIAG_20;} }
            public TTReportField LISO_20 { get {return Body().LISO_20;} }
            public TTReportField NF21 { get {return Body().NF21;} }
            public TTReportField I_DIAG_21 { get {return Body().I_DIAG_21;} }
            public TTReportField LISO_21 { get {return Body().LISO_21;} }
            public UST_EKSTREMITE_HDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UST_EKSTREMITE_HDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new UST_EKSTREMITE_HDGroupBody(this);
            }

            public partial class UST_EKSTREMITE_HDGroupBody : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField NewField111611;
                public TTReportField NewField11711;
                public TTReportField DIAGNOSISFIELD11411;
                public TTReportField NewField111711;
                public TTReportField DIAGNOSISFIELD111411;
                public TTReportField NewField1116111;
                public TTReportField NewField11116111;
                public TTReportField NewField11116121;
                public TTReportField NewField113111;
                public TTReportField DIAGNOSISFIELD112811;
                public TTReportField III1;
                public TTReportField NF1;
                public TTReportField I_DIAG_1;
                public TTReportField LISO_1;
                public TTReportField NF11;
                public TTReportField I_DIAG_11;
                public TTReportField LISO_11;
                public TTReportField NF12;
                public TTReportField I_DIAG_12;
                public TTReportField LISO_12;
                public TTReportField NF13;
                public TTReportField I_DIAG_13;
                public TTReportField LISO_13;
                public TTReportField NF14;
                public TTReportField I_DIAG_14;
                public TTReportField LISO_14;
                public TTReportField NF15;
                public TTReportField I_DIAG_15;
                public TTReportField LISO_15;
                public TTReportField NF16;
                public TTReportField I_DIAG_16;
                public TTReportField LISO_16;
                public TTReportField NF17;
                public TTReportField I_DIAG_17;
                public TTReportField LISO_17;
                public TTReportField NF18;
                public TTReportField I_DIAG_18;
                public TTReportField LISO_18;
                public TTReportField NF19;
                public TTReportField I_DIAG_19;
                public TTReportField LISO_19;
                public TTReportField NF20;
                public TTReportField I_DIAG_20;
                public TTReportField LISO_20;
                public TTReportField NF21;
                public TTReportField I_DIAG_21;
                public TTReportField LISO_21; 
                public UST_EKSTREMITE_HDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 144;
                    RepeatCount = 0;
                    
                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 200, 13, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.Underline = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"HASTA DEĞERLENDİRME:";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 110, 19, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.Value = @"Amputasyon seviyesi:";

                    DIAGNOSISFIELD11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 14, 200, 19, false);
                    DIAGNOSISFIELD11411.Name = "DIAGNOSISFIELD11411";
                    DIAGNOSISFIELD11411.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11411.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11411.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_AMPUTATIONLEVEL#}";

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 110, 25, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111711.Value = @"Güdük uzunluğu (cm):";

                    DIAGNOSISFIELD111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 20, 200, 25, false);
                    DIAGNOSISFIELD111411.Name = "DIAGNOSISFIELD111411";
                    DIAGNOSISFIELD111411.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD111411.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD111411.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111411.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111411.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111411.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_STUMPLENGTH#}";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 26, 110, 31, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1116111.TextFont.Name = "Arial";
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.Underline = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 26, 142, 31, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11116111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11116111.TextFont.Name = "Arial";
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"EVET / HAYIR";

                    NewField11116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 26, 200, 31, false);
                    NewField11116121.Name = "NewField11116121";
                    NewField11116121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11116121.TextFont.Name = "Arial";
                    NewField11116121.TextFont.Bold = true;
                    NewField11116121.TextFont.CharSet = 162;
                    NewField11116121.Value = @"AÇIKLAMA";

                    NewField113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 33, 110, 38, false);
                    NewField113111.Name = "NewField113111";
                    NewField113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113111.Value = @"Hastanın protez marka/model tercih dilekçesi var mı?";

                    DIAGNOSISFIELD112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 33, 142, 38, false);
                    DIAGNOSISFIELD112811.Name = "DIAGNOSISFIELD112811";
                    DIAGNOSISFIELD112811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD112811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD112811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSISFIELD112811.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD112811.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD112811.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD112811.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD112811.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD112811.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_PREFERENCEPETITION#}";

                    III1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 33, 200, 38, false);
                    III1.Name = "III1";
                    III1.DrawStyle = DrawStyleConstants.vbSolid;
                    III1.FieldType = ReportFieldTypeEnum.ftVariable;
                    III1.MultiLine = EvetHayirEnum.ehEvet;
                    III1.WordBreak = EvetHayirEnum.ehEvet;
                    III1.TextFont.Name = "Arial";
                    III1.TextFont.Bold = true;
                    III1.TextFont.Underline = true;
                    III1.TextFont.CharSet = 162;
                    III1.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_PREFERENCEPETITION_DESC#}";

                    NF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 110, 44, false);
                    NF1.Name = "NF1";
                    NF1.DrawStyle = DrawStyleConstants.vbSolid;
                    NF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF1.MultiLine = EvetHayirEnum.ehEvet;
                    NF1.WordBreak = EvetHayirEnum.ehEvet;
                    NF1.Value = @"Protez uygulanabilmesi için yeterli güdük uzunluğuna sahip mi?
";

                    I_DIAG_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 39, 142, 44, false);
                    I_DIAG_1.Name = "I_DIAG_1";
                    I_DIAG_1.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_1.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_1.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_1.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_1.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_1.ObjectDefName = "YesNoEnum";
                    I_DIAG_1.DataMember = "DISPLAYTEXT";
                    I_DIAG_1.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SUFFICIENTSTUMPLENGTH#}";

                    LISO_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 39, 200, 44, false);
                    LISO_1.Name = "LISO_1";
                    LISO_1.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_1.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_1.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_1.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_1.TextFont.Name = "Arial";
                    LISO_1.TextFont.Bold = true;
                    LISO_1.TextFont.Underline = true;
                    LISO_1.TextFont.CharSet = 162;
                    LISO_1.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SUFFICIENTSTUMP_DESC#}";

                    NF11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 110, 57, false);
                    NF11.Name = "NF11";
                    NF11.DrawStyle = DrawStyleConstants.vbSolid;
                    NF11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF11.MultiLine = EvetHayirEnum.ehEvet;
                    NF11.WordBreak = EvetHayirEnum.ehEvet;
                    NF11.Value = @"Tek taraflı ampute hastalar için; Ampute edilen taraf dominant ekstremite mi? veya non-dominant üst ekstremite amputasyon ile birlikte karşı ekstremiteyi kullanmasına engel tıbbi bir durum var mı?
";

                    I_DIAG_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 45, 142, 57, false);
                    I_DIAG_11.Name = "I_DIAG_11";
                    I_DIAG_11.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_11.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_11.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_11.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_11.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_11.ObjectDefName = "YesNoEnum";
                    I_DIAG_11.DataMember = "DISPLAYTEXT";
                    I_DIAG_11.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SINGLESIDEAMPUTATE#}";

                    LISO_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 45, 200, 57, false);
                    LISO_11.Name = "LISO_11";
                    LISO_11.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_11.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_11.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_11.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_11.TextFont.Name = "Arial";
                    LISO_11.TextFont.Bold = true;
                    LISO_11.TextFont.Underline = true;
                    LISO_11.TextFont.CharSet = 162;
                    LISO_11.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SINGLESIDEAMPUTATE_DESC#}";

                    NF12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 110, 66, false);
                    NF12.Name = "NF12";
                    NF12.DrawStyle = DrawStyleConstants.vbSolid;
                    NF12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF12.MultiLine = EvetHayirEnum.ehEvet;
                    NF12.WordBreak = EvetHayirEnum.ehEvet;
                    NF12.Value = @"Protezin teknik özelliklerine uygun fonksiyonel hareketleri yerine getirebilecek mi?
";

                    I_DIAG_12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 58, 142, 66, false);
                    I_DIAG_12.Name = "I_DIAG_12";
                    I_DIAG_12.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_12.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_12.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_12.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_12.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_12.ObjectDefName = "YesNoEnum";
                    I_DIAG_12.DataMember = "DISPLAYTEXT";
                    I_DIAG_12.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_FUNCTIONALMOVEMENTS#}";

                    LISO_12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 58, 200, 66, false);
                    LISO_12.Name = "LISO_12";
                    LISO_12.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_12.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_12.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_12.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_12.TextFont.Name = "Arial";
                    LISO_12.TextFont.Bold = true;
                    LISO_12.TextFont.Underline = true;
                    LISO_12.TextFont.CharSet = 162;
                    LISO_12.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_FUNCTIONALMOVEMENT_DESC#}";

                    NF13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 110, 72, false);
                    NF13.Name = "NF13";
                    NF13.DrawStyle = DrawStyleConstants.vbSolid;
                    NF13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF13.MultiLine = EvetHayirEnum.ehEvet;
                    NF13.WordBreak = EvetHayirEnum.ehEvet;
                    NF13.Value = @"Kardiyovasküler hastalık var mı?
";

                    I_DIAG_13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 67, 142, 72, false);
                    I_DIAG_13.Name = "I_DIAG_13";
                    I_DIAG_13.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_13.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_13.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_13.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_13.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_13.ObjectDefName = "YesNoEnum";
                    I_DIAG_13.DataMember = "DISPLAYTEXT";
                    I_DIAG_13.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_CARDIOVASCULAR#}";

                    LISO_13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 67, 200, 72, false);
                    LISO_13.Name = "LISO_13";
                    LISO_13.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_13.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_13.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_13.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_13.TextFont.Name = "Arial";
                    LISO_13.TextFont.Bold = true;
                    LISO_13.TextFont.Underline = true;
                    LISO_13.TextFont.CharSet = 162;
                    LISO_13.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_CARDIOVASCULAR_DESC#}";

                    NF14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 73, 110, 82, false);
                    NF14.Name = "NF14";
                    NF14.DrawStyle = DrawStyleConstants.vbSolid;
                    NF14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF14.MultiLine = EvetHayirEnum.ehEvet;
                    NF14.WordBreak = EvetHayirEnum.ehEvet;
                    NF14.Value = @"Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?
";

                    I_DIAG_14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 73, 142, 82, false);
                    I_DIAG_14.Name = "I_DIAG_14";
                    I_DIAG_14.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_14.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_14.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_14.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_14.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_14.ObjectDefName = "YesNoEnum";
                    I_DIAG_14.DataMember = "DISPLAYTEXT";
                    I_DIAG_14.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_STUMPZONE#}";

                    LISO_14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 73, 200, 82, false);
                    LISO_14.Name = "LISO_14";
                    LISO_14.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_14.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_14.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_14.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_14.TextFont.Name = "Arial";
                    LISO_14.TextFont.Bold = true;
                    LISO_14.TextFont.Underline = true;
                    LISO_14.TextFont.CharSet = 162;
                    LISO_14.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_STUMPZONE_DESC#}";

                    NF15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 83, 110, 88, false);
                    NF15.Name = "NF15";
                    NF15.DrawStyle = DrawStyleConstants.vbSolid;
                    NF15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF15.MultiLine = EvetHayirEnum.ehEvet;
                    NF15.WordBreak = EvetHayirEnum.ehEvet;
                    NF15.Value = @"Ampute ekstremitede kontraktür var mı?
";

                    I_DIAG_15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 83, 142, 88, false);
                    I_DIAG_15.Name = "I_DIAG_15";
                    I_DIAG_15.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_15.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_15.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_15.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_15.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_15.ObjectDefName = "YesNoEnum";
                    I_DIAG_15.DataMember = "DISPLAYTEXT";
                    I_DIAG_15.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_CONTRACTURE#}";

                    LISO_15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 83, 200, 88, false);
                    LISO_15.Name = "LISO_15";
                    LISO_15.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_15.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_15.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_15.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_15.TextFont.Name = "Arial";
                    LISO_15.TextFont.Bold = true;
                    LISO_15.TextFont.Underline = true;
                    LISO_15.TextFont.CharSet = 162;
                    LISO_15.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_CONTRACTURE_DESC#}";

                    NF16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 89, 110, 94, false);
                    NF16.Name = "NF16";
                    NF16.DrawStyle = DrawStyleConstants.vbSolid;
                    NF16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF16.MultiLine = EvetHayirEnum.ehEvet;
                    NF16.WordBreak = EvetHayirEnum.ehEvet;
                    NF16.Value = @"Kas-iskelet sistemi hastalığı var mı?";

                    I_DIAG_16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 89, 142, 94, false);
                    I_DIAG_16.Name = "I_DIAG_16";
                    I_DIAG_16.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_16.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_16.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_16.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_16.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_16.ObjectDefName = "YesNoEnum";
                    I_DIAG_16.DataMember = "DISPLAYTEXT";
                    I_DIAG_16.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_MUSCULOSKELETAL#}";

                    LISO_16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 89, 200, 94, false);
                    LISO_16.Name = "LISO_16";
                    LISO_16.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_16.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_16.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_16.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_16.TextFont.Name = "Arial";
                    LISO_16.TextFont.Bold = true;
                    LISO_16.TextFont.Underline = true;
                    LISO_16.TextFont.CharSet = 162;
                    LISO_16.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_MUSCULOSKELETAL_DESC#}";

                    NF17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 95, 110, 100, false);
                    NF17.Name = "NF17";
                    NF17.DrawStyle = DrawStyleConstants.vbSolid;
                    NF17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF17.MultiLine = EvetHayirEnum.ehEvet;
                    NF17.WordBreak = EvetHayirEnum.ehEvet;
                    NF17.Value = @"Nörolojik /nöromusküler hastalık var mı?";

                    I_DIAG_17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 95, 142, 100, false);
                    I_DIAG_17.Name = "I_DIAG_17";
                    I_DIAG_17.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_17.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_17.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_17.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_17.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_17.ObjectDefName = "YesNoEnum";
                    I_DIAG_17.DataMember = "DISPLAYTEXT";
                    I_DIAG_17.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_NEUROLOGICAL#}";

                    LISO_17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 95, 200, 100, false);
                    LISO_17.Name = "LISO_17";
                    LISO_17.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_17.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_17.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_17.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_17.TextFont.Name = "Arial";
                    LISO_17.TextFont.Bold = true;
                    LISO_17.TextFont.Underline = true;
                    LISO_17.TextFont.CharSet = 162;
                    LISO_17.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_NEUROLOGICAL_DESC#}";

                    NF18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 101, 110, 106, false);
                    NF18.Name = "NF18";
                    NF18.DrawStyle = DrawStyleConstants.vbSolid;
                    NF18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF18.MultiLine = EvetHayirEnum.ehEvet;
                    NF18.WordBreak = EvetHayirEnum.ehEvet;
                    NF18.Value = @"Pulmoner hastalık var mı?";

                    I_DIAG_18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 101, 142, 106, false);
                    I_DIAG_18.Name = "I_DIAG_18";
                    I_DIAG_18.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_18.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_18.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_18.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_18.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_18.ObjectDefName = "YesNoEnum";
                    I_DIAG_18.DataMember = "DISPLAYTEXT";
                    I_DIAG_18.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_PULMONARY#}";

                    LISO_18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 101, 200, 106, false);
                    LISO_18.Name = "LISO_18";
                    LISO_18.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_18.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_18.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_18.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_18.TextFont.Name = "Arial";
                    LISO_18.TextFont.Bold = true;
                    LISO_18.TextFont.Underline = true;
                    LISO_18.TextFont.CharSet = 162;
                    LISO_18.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_PULMONARY_DESC#}";

                    NF19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 107, 110, 112, false);
                    NF19.Name = "NF19";
                    NF19.DrawStyle = DrawStyleConstants.vbSolid;
                    NF19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF19.MultiLine = EvetHayirEnum.ehEvet;
                    NF19.WordBreak = EvetHayirEnum.ehEvet;
                    NF19.Value = @"Organ yetmezliği var mı?
";

                    I_DIAG_19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 107, 142, 112, false);
                    I_DIAG_19.Name = "I_DIAG_19";
                    I_DIAG_19.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_19.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_19.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_19.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_19.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_19.ObjectDefName = "YesNoEnum";
                    I_DIAG_19.DataMember = "DISPLAYTEXT";
                    I_DIAG_19.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_ORGANFAILURE#}";

                    LISO_19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 107, 200, 112, false);
                    LISO_19.Name = "LISO_19";
                    LISO_19.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_19.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_19.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_19.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_19.TextFont.Name = "Arial";
                    LISO_19.TextFont.Bold = true;
                    LISO_19.TextFont.Underline = true;
                    LISO_19.TextFont.CharSet = 162;
                    LISO_19.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_ORGANFAILURE_DESC#}";

                    NF20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 113, 110, 118, false);
                    NF20.Name = "NF20";
                    NF20.DrawStyle = DrawStyleConstants.vbSolid;
                    NF20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF20.MultiLine = EvetHayirEnum.ehEvet;
                    NF20.WordBreak = EvetHayirEnum.ehEvet;
                    NF20.Value = @"Sistemik (HT,DM, Romatolojik, Endokrinolojik, vb.) hastalıklar var mı?
";

                    I_DIAG_20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 113, 142, 118, false);
                    I_DIAG_20.Name = "I_DIAG_20";
                    I_DIAG_20.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_20.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_20.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_20.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_20.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_20.ObjectDefName = "YesNoEnum";
                    I_DIAG_20.DataMember = "DISPLAYTEXT";
                    I_DIAG_20.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SYSTEMICDISEASE#}";

                    LISO_20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 113, 200, 118, false);
                    LISO_20.Name = "LISO_20";
                    LISO_20.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_20.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_20.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_20.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_20.TextFont.Name = "Arial";
                    LISO_20.TextFont.Bold = true;
                    LISO_20.TextFont.Underline = true;
                    LISO_20.TextFont.CharSet = 162;
                    LISO_20.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SYSTEMICDISEASE_DESC#}";

                    NF21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 110, 131, false);
                    NF21.Name = "NF21";
                    NF21.DrawStyle = DrawStyleConstants.vbSolid;
                    NF21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NF21.MultiLine = EvetHayirEnum.ehEvet;
                    NF21.WordBreak = EvetHayirEnum.ehEvet;
                    NF21.Value = @"Hasta myoelektrik kontrollü kol protezi temin edildikten sonra yüksek gerilim altında ve manyetik alanlarda çalışmayacağını belgelemiş mi veya taahhüt ediyor mu?";

                    I_DIAG_21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 119, 142, 131, false);
                    I_DIAG_21.Name = "I_DIAG_21";
                    I_DIAG_21.DrawStyle = DrawStyleConstants.vbSolid;
                    I_DIAG_21.FieldType = ReportFieldTypeEnum.ftVariable;
                    I_DIAG_21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    I_DIAG_21.MultiLine = EvetHayirEnum.ehEvet;
                    I_DIAG_21.WordBreak = EvetHayirEnum.ehEvet;
                    I_DIAG_21.ExpandTabs = EvetHayirEnum.ehEvet;
                    I_DIAG_21.ObjectDefName = "YesNoEnum";
                    I_DIAG_21.DataMember = "DISPLAYTEXT";
                    I_DIAG_21.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_MYOELECTRIC#}";

                    LISO_21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 119, 200, 131, false);
                    LISO_21.Name = "LISO_21";
                    LISO_21.DrawStyle = DrawStyleConstants.vbSolid;
                    LISO_21.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISO_21.MultiLine = EvetHayirEnum.ehEvet;
                    LISO_21.WordBreak = EvetHayirEnum.ehEvet;
                    LISO_21.TextFont.Name = "Arial";
                    LISO_21.TextFont.Bold = true;
                    LISO_21.TextFont.Underline = true;
                    LISO_21.TextFont.CharSet = 162;
                    LISO_21.Value = @"{#UST_EKSTREMITE_HEADER.UE_HD_SUFFICIENTSTUMP_DESC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = MyParentReport.UST_EKSTREMITE_HEADER.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    DIAGNOSISFIELD11411.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_AmputationLevel) : "");
                    NewField111711.CalcValue = NewField111711.Value;
                    DIAGNOSISFIELD111411.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_StumpLength) : "");
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField11116121.CalcValue = NewField11116121.Value;
                    NewField113111.CalcValue = NewField113111.Value;
                    DIAGNOSISFIELD112811.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_PreferencePetition) : "");
                    DIAGNOSISFIELD112811.PostFieldValueCalculation();
                    III1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_PreferencePetition_Desc) : "");
                    NF1.CalcValue = NF1.Value;
                    I_DIAG_1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SufficientStumpLength) : "");
                    I_DIAG_1.PostFieldValueCalculation();
                    LISO_1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SufficientStump_Desc) : "");
                    NF11.CalcValue = NF11.Value;
                    I_DIAG_11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SingleSideAmputate) : "");
                    I_DIAG_11.PostFieldValueCalculation();
                    LISO_11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SingleSideAmputate_Desc) : "");
                    NF12.CalcValue = NF12.Value;
                    I_DIAG_12.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_FunctionalMovements) : "");
                    I_DIAG_12.PostFieldValueCalculation();
                    LISO_12.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_FunctionalMovement_Desc) : "");
                    NF13.CalcValue = NF13.Value;
                    I_DIAG_13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Cardiovascular) : "");
                    I_DIAG_13.PostFieldValueCalculation();
                    LISO_13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Cardiovascular_Desc) : "");
                    NF14.CalcValue = NF14.Value;
                    I_DIAG_14.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_StumpZone) : "");
                    I_DIAG_14.PostFieldValueCalculation();
                    LISO_14.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_StumpZone_Desc) : "");
                    NF15.CalcValue = NF15.Value;
                    I_DIAG_15.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Contracture) : "");
                    I_DIAG_15.PostFieldValueCalculation();
                    LISO_15.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Contracture_Desc) : "");
                    NF16.CalcValue = NF16.Value;
                    I_DIAG_16.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Musculoskeletal) : "");
                    I_DIAG_16.PostFieldValueCalculation();
                    LISO_16.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Musculoskeletal_Desc) : "");
                    NF17.CalcValue = NF17.Value;
                    I_DIAG_17.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Neurological) : "");
                    I_DIAG_17.PostFieldValueCalculation();
                    LISO_17.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Neurological_Desc) : "");
                    NF18.CalcValue = NF18.Value;
                    I_DIAG_18.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Pulmonary) : "");
                    I_DIAG_18.PostFieldValueCalculation();
                    LISO_18.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Pulmonary_Desc) : "");
                    NF19.CalcValue = NF19.Value;
                    I_DIAG_19.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_OrganFailure) : "");
                    I_DIAG_19.PostFieldValueCalculation();
                    LISO_19.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_OrganFailure_Desc) : "");
                    NF20.CalcValue = NF20.Value;
                    I_DIAG_20.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SystemicDisease) : "");
                    I_DIAG_20.PostFieldValueCalculation();
                    LISO_20.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SystemicDisease_Desc) : "");
                    NF21.CalcValue = NF21.Value;
                    I_DIAG_21.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_Myoelectric) : "");
                    I_DIAG_21.PostFieldValueCalculation();
                    LISO_21.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UE_HD_SufficientStump_Desc) : "");
                    return new TTReportObject[] { NewField111611,NewField11711,DIAGNOSISFIELD11411,NewField111711,DIAGNOSISFIELD111411,NewField1116111,NewField11116111,NewField11116121,NewField113111,DIAGNOSISFIELD112811,III1,NF1,I_DIAG_1,LISO_1,NF11,I_DIAG_11,LISO_11,NF12,I_DIAG_12,LISO_12,NF13,I_DIAG_13,LISO_13,NF14,I_DIAG_14,LISO_14,NF15,I_DIAG_15,LISO_15,NF16,I_DIAG_16,LISO_16,NF17,I_DIAG_17,LISO_17,NF18,I_DIAG_18,LISO_18,NF19,I_DIAG_19,LISO_19,NF20,I_DIAG_20,LISO_20,NF21,I_DIAG_21,LISO_21};
                }
                public override void RunPreScript()
                {
#region UST_EKSTREMITE_HD BODY_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.UpperExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion UST_EKSTREMITE_HD BODY_PreScript
                }
            }

        }

        public UST_EKSTREMITE_HDGroup UST_EKSTREMITE_HD;

        public partial class ATS_HEADERGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public ATS_HEADERGroupHeader Header()
            {
                return (ATS_HEADERGroupHeader)_header;
            }

            new public ATS_HEADERGroupFooter Footer()
            {
                return (ATS_HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField Reçete111 { get {return Header().Reçete111;} }
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public ATS_HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ATS_HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LowerExtremity.GetExtremityReportInfoByObjId_Class>("GetExtremityReportInfoByObjId", LowerExtremity.GetExtremityReportInfoByObjId((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ATS_HEADERGroupHeader(this);
                _footer = new ATS_HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ATS_HEADERGroupHeader : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK111;
                public TTReportField Reçete111;
                public TTReportField LOGO11; 
                public ATS_HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 6, 192, 47, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Name = "Arial";
                    XXXXXXBASLIK111.TextFont.Size = 11;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.TextFont.CharSet = 162;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Reçete111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 49, 187, 54, false);
                    Reçete111.Name = "Reçete111";
                    Reçete111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Reçete111.MultiLine = EvetHayirEnum.ehEvet;
                    Reçete111.NoClip = EvetHayirEnum.ehEvet;
                    Reçete111.WordBreak = EvetHayirEnum.ehEvet;
                    Reçete111.TextFont.Name = "Arial";
                    Reçete111.TextFont.Size = 12;
                    Reçete111.TextFont.Bold = true;
                    Reçete111.TextFont.CharSet = 162;
                    Reçete111.Value = @"TIBBİ UYGUNLUK KOMİSYONU HASTA DEĞERLENDİRME FORMU
(AKTİF TEKERLEKLİ SANDALYE İÇİN)";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 37, 29, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO11.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO11.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO11.DataMember = "EMBLEM";
                    LOGO11.TextFont.Name = "Courier New";
                    LOGO11.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = ParentGroup.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    Reçete111.CalcValue = Reçete111.Value;
                    LOGO11.CalcValue = @"";
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { Reçete111,LOGO11,XXXXXXBASLIK111};
                }
                public override void RunPreScript()
                {
#region ATS_HEADER HEADER_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.ChairExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion ATS_HEADER HEADER_PreScript
                }
            }
            public partial class ATS_HEADERGroupFooter : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                 
                public ATS_HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ATS_HEADERGroup ATS_HEADER;

        public partial class ATSGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public ATSGroupBody Body()
            {
                return (ATSGroupBody)_body;
            }
            public TTReportField PNAME11 { get {return Body().PNAME11;} }
            public TTReportField PSURNAME11 { get {return Body().PSURNAME11;} }
            public TTReportField ReportDate11 { get {return Body().ReportDate11;} }
            public TTReportField ReportNo11 { get {return Body().ReportNo11;} }
            public TTReportField FULLNAME111 { get {return Body().FULLNAME111;} }
            public TTReportField lblPAtientName111 { get {return Body().lblPAtientName111;} }
            public TTReportField ExaminationDate11 { get {return Body().ExaminationDate11;} }
            public TTReportField lblPAtientName1111 { get {return Body().lblPAtientName1111;} }
            public TTReportField UNIQUEREFNO11 { get {return Body().UNIQUEREFNO11;} }
            public TTReportField lblPAtientName1121 { get {return Body().lblPAtientName1121;} }
            public TTReportField FULLNAME1121 { get {return Body().FULLNAME1121;} }
            public TTReportField lblPAtientName1131 { get {return Body().lblPAtientName1131;} }
            public TTReportField FULLNAME1131 { get {return Body().FULLNAME1131;} }
            public TTReportField lblPAtientName1141 { get {return Body().lblPAtientName1141;} }
            public TTReportField FULLNAME1141 { get {return Body().FULLNAME1141;} }
            public TTReportField lblPAtientName1151 { get {return Body().lblPAtientName1151;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField DIAGNOSISFIELD111 { get {return Body().DIAGNOSISFIELD111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField DIAGNOSISFIELD1111 { get {return Body().DIAGNOSISFIELD1111;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField DIAGNOSISFIELD1121 { get {return Body().DIAGNOSISFIELD1121;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField DIAGNOSISFIELD1131 { get {return Body().DIAGNOSISFIELD1131;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField DIAGNOSISFIELD1141 { get {return Body().DIAGNOSISFIELD1141;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField DIAGNOSISFIELD1151 { get {return Body().DIAGNOSISFIELD1151;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public TTReportField DIAGNOSISFIELD1161 { get {return Body().DIAGNOSISFIELD1161;} }
            public TTReportField NewField11021 { get {return Body().NewField11021;} }
            public TTReportField DIAGNOSISFIELD11711 { get {return Body().DIAGNOSISFIELD11711;} }
            public TTReportField NewField11041 { get {return Body().NewField11041;} }
            public TTReportField DIAGNOSISFIELD11731 { get {return Body().DIAGNOSISFIELD11731;} }
            public TTReportField NewField11051 { get {return Body().NewField11051;} }
            public TTReportField DIAGNOSISFIELD11741 { get {return Body().DIAGNOSISFIELD11741;} }
            public TTReportField NewField11061 { get {return Body().NewField11061;} }
            public TTReportField DIAGNOSISFIELD11751 { get {return Body().DIAGNOSISFIELD11751;} }
            public TTReportField NewField11911 { get {return Body().NewField11911;} }
            public TTReportField DIAGNOSISFIELD11611 { get {return Body().DIAGNOSISFIELD11611;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField NewField11071 { get {return Body().NewField11071;} }
            public TTReportField DIAGNOSISFIELD11761 { get {return Body().DIAGNOSISFIELD11761;} }
            public TTReportField NewField11081 { get {return Body().NewField11081;} }
            public TTReportField DIAGNOSISFIELD11771 { get {return Body().DIAGNOSISFIELD11771;} }
            public TTReportField NewField11091 { get {return Body().NewField11091;} }
            public TTReportField DIAGNOSISFIELD11781 { get {return Body().DIAGNOSISFIELD11781;} }
            public TTReportField NewField11101 { get {return Body().NewField11101;} }
            public TTReportField DIAGNOSISFIELD11791 { get {return Body().DIAGNOSISFIELD11791;} }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField DIAGNOSISFIELD11801 { get {return Body().DIAGNOSISFIELD11801;} }
            public TTReportField NewField11131 { get {return Body().NewField11131;} }
            public TTReportField DIAGNOSISFIELD11821 { get {return Body().DIAGNOSISFIELD11821;} }
            public ATSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ATSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ATSGroupBody(this);
            }

            public partial class ATSGroupBody : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField PNAME11;
                public TTReportField PSURNAME11;
                public TTReportField ReportDate11;
                public TTReportField ReportNo11;
                public TTReportField FULLNAME111;
                public TTReportField lblPAtientName111;
                public TTReportField ExaminationDate11;
                public TTReportField lblPAtientName1111;
                public TTReportField UNIQUEREFNO11;
                public TTReportField lblPAtientName1121;
                public TTReportField FULLNAME1121;
                public TTReportField lblPAtientName1131;
                public TTReportField FULLNAME1131;
                public TTReportField lblPAtientName1141;
                public TTReportField FULLNAME1141;
                public TTReportField lblPAtientName1151;
                public TTReportField NewField111;
                public TTReportField DIAGNOSISFIELD111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField1111;
                public TTReportField DIAGNOSISFIELD1111;
                public TTReportField NewField1141;
                public TTReportField DIAGNOSISFIELD1121;
                public TTReportField NewField1151;
                public TTReportField DIAGNOSISFIELD1131;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField DIAGNOSISFIELD1141;
                public TTReportField NewField1181;
                public TTReportField DIAGNOSISFIELD1151;
                public TTReportField NewField1191;
                public TTReportField DIAGNOSISFIELD1161;
                public TTReportField NewField11021;
                public TTReportField DIAGNOSISFIELD11711;
                public TTReportField NewField11041;
                public TTReportField DIAGNOSISFIELD11731;
                public TTReportField NewField11051;
                public TTReportField DIAGNOSISFIELD11741;
                public TTReportField NewField11061;
                public TTReportField DIAGNOSISFIELD11751;
                public TTReportField NewField11911;
                public TTReportField DIAGNOSISFIELD11611;
                public TTReportField NewField11611;
                public TTReportField NewField11071;
                public TTReportField DIAGNOSISFIELD11761;
                public TTReportField NewField11081;
                public TTReportField DIAGNOSISFIELD11771;
                public TTReportField NewField11091;
                public TTReportField DIAGNOSISFIELD11781;
                public TTReportField NewField11101;
                public TTReportField DIAGNOSISFIELD11791;
                public TTReportField NewField11111;
                public TTReportField DIAGNOSISFIELD11801;
                public TTReportField NewField11131;
                public TTReportField DIAGNOSISFIELD11821; 
                public ATSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 216;
                    RepeatCount = 0;
                    
                    PNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 242, 21, false);
                    PNAME11.Name = "PNAME11";
                    PNAME11.Visible = EvetHayirEnum.ehHayir;
                    PNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME11.Value = @"{#ATS_HEADER.NAME#}";

                    PSURNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 24, 244, 29, false);
                    PSURNAME11.Name = "PSURNAME11";
                    PSURNAME11.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME11.Value = @"{#ATS_HEADER.SURNAME#}";

                    ReportDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 39, 243, 44, false);
                    ReportDate11.Name = "ReportDate11";
                    ReportDate11.Visible = EvetHayirEnum.ehHayir;
                    ReportDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportDate11.Value = @"{#ATS_HEADER.REPORTDATE#}";

                    ReportNo11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 50, 243, 55, false);
                    ReportNo11.Name = "ReportNo11";
                    ReportNo11.Visible = EvetHayirEnum.ehHayir;
                    ReportNo11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportNo11.Value = @"{#ATS_HEADER.REPORTNO#}";

                    FULLNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 14, 194, 19, false);
                    FULLNAME111.Name = "FULLNAME111";
                    FULLNAME111.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME111.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME111.Value = @"{%PNAME11%} {%PSURNAME11%}";

                    lblPAtientName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 14, 39, 19, false);
                    lblPAtientName111.Name = "lblPAtientName111";
                    lblPAtientName111.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName111.Value = @"Adı Soyadı :";

                    ExaminationDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 8, 194, 13, false);
                    ExaminationDate11.Name = "ExaminationDate11";
                    ExaminationDate11.DrawStyle = DrawStyleConstants.vbSolid;
                    ExaminationDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExaminationDate11.Value = @"{#ATS_HEADER.PROCESSDATE#}";

                    lblPAtientName1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 39, 13, false);
                    lblPAtientName1111.Name = "lblPAtientName1111";
                    lblPAtientName1111.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName1111.Value = @"Muayene Tarihi";

                    UNIQUEREFNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 20, 194, 25, false);
                    UNIQUEREFNO11.Name = "UNIQUEREFNO11";
                    UNIQUEREFNO11.DrawStyle = DrawStyleConstants.vbSolid;
                    UNIQUEREFNO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO11.Value = @"{#ATS_HEADER.UNIQUEREFNO#}";

                    lblPAtientName1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 20, 39, 25, false);
                    lblPAtientName1121.Name = "lblPAtientName1121";
                    lblPAtientName1121.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName1121.Value = @"T.C. :";

                    FULLNAME1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 26, 194, 31, false);
                    FULLNAME1121.Name = "FULLNAME1121";
                    FULLNAME1121.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME1121.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME1121.Value = @"{#ATS_HEADER.BIRTHDATE#}";

                    lblPAtientName1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 26, 39, 31, false);
                    lblPAtientName1131.Name = "lblPAtientName1131";
                    lblPAtientName1131.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName1131.Value = @"Doğum Tarihi :";

                    FULLNAME1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 32, 194, 37, false);
                    FULLNAME1131.Name = "FULLNAME1131";
                    FULLNAME1131.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME1131.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME1131.Value = @"{#ATS_HEADER.BIRTHPLACE#}";

                    lblPAtientName1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 32, 39, 37, false);
                    lblPAtientName1141.Name = "lblPAtientName1141";
                    lblPAtientName1141.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName1141.Value = @"Doğum Yeri :";

                    FULLNAME1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 38, 194, 43, false);
                    FULLNAME1141.Name = "FULLNAME1141";
                    FULLNAME1141.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLNAME1141.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME1141.Value = @"{#ATS_HEADER.MOBILEPHONE#}";

                    lblPAtientName1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 39, 43, false);
                    lblPAtientName1151.Name = "lblPAtientName1151";
                    lblPAtientName1151.DrawStyle = DrawStyleConstants.vbSolid;
                    lblPAtientName1151.Value = @"Telefon :";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 48, 84, 53, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.Value = @"Tanı";

                    DIAGNOSISFIELD111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 48, 193, 53, false);
                    DIAGNOSISFIELD111.Name = "DIAGNOSISFIELD111";
                    DIAGNOSISFIELD111.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD111.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD111.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 54, 84, 59, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.Value = @"Yaralanma nedeni ve tarihi:";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 54, 193, 59, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField131.Value = @"{#ATS_HEADER.ATS_CAUSEOFINJURY#}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 61, 193, 66, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.Underline = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"KULLANILAN TEKERLEKLİ SANDALYE:";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 68, 84, 73, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.Value = @"Kaçıncı sandalye olduğu:";

                    DIAGNOSISFIELD1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 68, 193, 73, false);
                    DIAGNOSISFIELD1111.Name = "DIAGNOSISFIELD1111";
                    DIAGNOSISFIELD1111.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1111.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1111.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1111.Value = @"{#ATS_HEADER.ATS_CHAIRNUMBER#}";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 74, 84, 79, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.Value = @"Teslim alma tarihi:";

                    DIAGNOSISFIELD1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 74, 193, 79, false);
                    DIAGNOSISFIELD1121.Name = "DIAGNOSISFIELD1121";
                    DIAGNOSISFIELD1121.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1121.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1121.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1121.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1121.Value = @"{#ATS_HEADER.ATS_DELIVERYDATE#}";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 80, 84, 85, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.Value = @"Sandalye tipi:";

                    DIAGNOSISFIELD1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 80, 193, 85, false);
                    DIAGNOSISFIELD1131.Name = "DIAGNOSISFIELD1131";
                    DIAGNOSISFIELD1131.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1131.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1131.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1131.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1131.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1131.Value = @"{#ATS_HEADER.ATS_CHAIRTYPE#}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 93, 193, 98, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.Underline = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"SAĞLIK KURULU RAPORU:";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 99, 84, 104, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.Value = @"Raporu Veren Kurum";

                    DIAGNOSISFIELD1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 99, 193, 104, false);
                    DIAGNOSISFIELD1141.Name = "DIAGNOSISFIELD1141";
                    DIAGNOSISFIELD1141.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1141.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1141.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1141.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1141.Value = @"Gaziler Fizik Tedavi ve Rehabilitasyon Eğitim ve Araştırma XXXXXX";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 105, 84, 110, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.Value = @"Rapor Tarih ve Numarası";

                    DIAGNOSISFIELD1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 105, 193, 110, false);
                    DIAGNOSISFIELD1151.Name = "DIAGNOSISFIELD1151";
                    DIAGNOSISFIELD1151.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1151.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1151.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1151.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1151.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1151.Value = @"{%ReportDate11%} - {%ReportNo11%}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 111, 84, 123, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1191.Value = @"Raporda Yazılan Tekerlekli Sandalye Tipi
";

                    DIAGNOSISFIELD1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 111, 193, 123, false);
                    DIAGNOSISFIELD1161.Name = "DIAGNOSISFIELD1161";
                    DIAGNOSISFIELD1161.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD1161.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD1161.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1161.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1161.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD1161.Value = @"{#ATS_HEADER.ATS_SK_CHAIRTYPE#}";

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 155, 84, 160, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11021.Value = @"Başhekim Onayı Var mı?";

                    DIAGNOSISFIELD11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 155, 193, 160, false);
                    DIAGNOSISFIELD11711.Name = "DIAGNOSISFIELD11711";
                    DIAGNOSISFIELD11711.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11711.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11711.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11711.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11711.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11711.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11711.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11711.Value = @"{#ATS_HEADER.ATS_SK_HEADDOCTORAPPROVE#}";

                    NewField11041 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 149, 84, 154, false);
                    NewField11041.Name = "NewField11041";
                    NewField11041.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11041.Value = @"Ortopedi Uzman Onayı Var mı?";

                    DIAGNOSISFIELD11731 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 149, 193, 154, false);
                    DIAGNOSISFIELD11731.Name = "DIAGNOSISFIELD11731";
                    DIAGNOSISFIELD11731.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11731.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11731.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11731.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11731.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11731.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11731.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11731.Value = @"{#ATS_HEADER.ATS_SK_ORTHOPEDICEXPAPPROVE#}";

                    NewField11051 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 143, 84, 148, false);
                    NewField11051.Name = "NewField11051";
                    NewField11051.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11051.Value = @"FTR Uzman Onayı Var mı?";

                    DIAGNOSISFIELD11741 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 143, 193, 148, false);
                    DIAGNOSISFIELD11741.Name = "DIAGNOSISFIELD11741";
                    DIAGNOSISFIELD11741.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11741.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11741.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11741.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11741.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11741.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11741.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11741.Value = @"{#ATS_HEADER.ATS_SK_FTREXPERTAPPROVE#}";

                    NewField11061 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 137, 84, 142, false);
                    NewField11061.Name = "NewField11061";
                    NewField11061.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11061.Value = @"3. basamak sağlık kurumu";

                    DIAGNOSISFIELD11751 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 137, 193, 142, false);
                    DIAGNOSISFIELD11751.Name = "DIAGNOSISFIELD11751";
                    DIAGNOSISFIELD11751.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11751.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11751.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11751.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11751.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11751.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11751.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11751.Value = @"{#ATS_HEADER.ATS_SK_THIRDSTEPHEALTHINST#}";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 124, 84, 136, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11911.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11911.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11911.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11911.Value = @"Aktif TS yazılmasındaki tıbbi gerekçe nedir? (Raporda yazan)
";

                    DIAGNOSISFIELD11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 124, 193, 136, false);
                    DIAGNOSISFIELD11611.Name = "DIAGNOSISFIELD11611";
                    DIAGNOSISFIELD11611.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11611.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11611.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11611.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11611.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11611.Value = @"{#ATS_HEADER.ATS_SK_MEDICALREASON#}
";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 168, 193, 173, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.Underline = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"REÇETE İÇERİĞİ:";

                    NewField11071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 174, 84, 179, false);
                    NewField11071.Name = "NewField11071";
                    NewField11071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11071.Value = @"Hasta Adı Soyadı ve T.C kimlik NumarasıVar mı?";

                    DIAGNOSISFIELD11761 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 174, 193, 179, false);
                    DIAGNOSISFIELD11761.Name = "DIAGNOSISFIELD11761";
                    DIAGNOSISFIELD11761.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11761.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11761.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11761.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11761.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11761.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11761.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11761.Value = @"{#ATS_HEADER.ATS_RI_PATIENTNAMESURNAME#}";

                    NewField11081 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 180, 84, 190, false);
                    NewField11081.Name = "NewField11081";
                    NewField11081.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11081.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11081.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11081.Value = @"Reçeteyi düzenleyen sağlık hizmet sunucusu adı veya MEDULA tesis kodu var mı?";

                    DIAGNOSISFIELD11771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 180, 193, 190, false);
                    DIAGNOSISFIELD11771.Name = "DIAGNOSISFIELD11771";
                    DIAGNOSISFIELD11771.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11771.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11771.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSISFIELD11771.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11771.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11771.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11771.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11771.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11771.Value = @"{#ATS_HEADER.ATS_RI_MEDULAINSCODE#}";

                    NewField11091 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 189, 84, 194, false);
                    NewField11091.Name = "NewField11091";
                    NewField11091.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11091.Value = @"Medula veya Protokol Numarası Var mı?";

                    DIAGNOSISFIELD11781 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 189, 193, 194, false);
                    DIAGNOSISFIELD11781.Name = "DIAGNOSISFIELD11781";
                    DIAGNOSISFIELD11781.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11781.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11781.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11781.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11781.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11781.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11781.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11781.Value = @"{#ATS_HEADER.ATS_RI_MEDULAORPROTOCOLNO#}";

                    NewField11101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 195, 84, 200, false);
                    NewField11101.Name = "NewField11101";
                    NewField11101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11101.Value = @"Tanı ve ICD-10 Kodu Varmı";

                    DIAGNOSISFIELD11791 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 195, 193, 200, false);
                    DIAGNOSISFIELD11791.Name = "DIAGNOSISFIELD11791";
                    DIAGNOSISFIELD11791.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11791.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11791.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11791.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11791.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11791.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11791.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11791.Value = @"{#ATS_HEADER.ATS_RI_DIAGNOSANDICD10CODE#}";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 201, 84, 206, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.Value = @"Cihazın adı/taraf/adet bilgisi var mı?";

                    DIAGNOSISFIELD11801 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 201, 193, 206, false);
                    DIAGNOSISFIELD11801.Name = "DIAGNOSISFIELD11801";
                    DIAGNOSISFIELD11801.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11801.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11801.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11801.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11801.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11801.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11801.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11801.Value = @"{#ATS_HEADER.ATS_RI_MACHINENAME#}";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 207, 84, 212, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131.Value = @"Islak İmza Varmı?";

                    DIAGNOSISFIELD11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 207, 193, 212, false);
                    DIAGNOSISFIELD11821.Name = "DIAGNOSISFIELD11821";
                    DIAGNOSISFIELD11821.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11821.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11821.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11821.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11821.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11821.ObjectDefName = "YesNoEnum";
                    DIAGNOSISFIELD11821.DataMember = "DISPLAYTEXT";
                    DIAGNOSISFIELD11821.Value = @"{#ATS_HEADER.ATS_RI_WETSIGNATURE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = MyParentReport.ATS_HEADER.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    PNAME11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Name) : "");
                    PSURNAME11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Surname) : "");
                    ReportDate11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ReportDate) : "");
                    ReportNo11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ReportNo) : "");
                    FULLNAME111.CalcValue = MyParentReport.ATS.PNAME11.CalcValue + @" " + MyParentReport.ATS.PSURNAME11.CalcValue;
                    lblPAtientName111.CalcValue = lblPAtientName111.Value;
                    ExaminationDate11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ProcessDate) : "");
                    lblPAtientName1111.CalcValue = lblPAtientName1111.Value;
                    UNIQUEREFNO11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.UniqueRefNo) : "");
                    lblPAtientName1121.CalcValue = lblPAtientName1121.Value;
                    FULLNAME1121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.BirthDate) : "");
                    lblPAtientName1131.CalcValue = lblPAtientName1131.Value;
                    FULLNAME1131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.BirthPlace) : "");
                    lblPAtientName1141.CalcValue = lblPAtientName1141.Value;
                    FULLNAME1141.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.MobilePhone) : "");
                    lblPAtientName1151.CalcValue = lblPAtientName1151.Value;
                    NewField111.CalcValue = NewField111.Value;
                    DIAGNOSISFIELD111.CalcValue = DIAGNOSISFIELD111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_CauseOfInjury) : "");
                    NewField141.CalcValue = NewField141.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    DIAGNOSISFIELD1111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_ChairNumber) : "");
                    NewField1141.CalcValue = NewField1141.Value;
                    DIAGNOSISFIELD1121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_DeliveryDate) : "");
                    NewField1151.CalcValue = NewField1151.Value;
                    DIAGNOSISFIELD1131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_ChairType) : "");
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    DIAGNOSISFIELD1141.CalcValue = DIAGNOSISFIELD1141.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    DIAGNOSISFIELD1151.CalcValue = MyParentReport.ATS.ReportDate11.CalcValue + @" - " + MyParentReport.ATS.ReportNo11.CalcValue;
                    NewField1191.CalcValue = NewField1191.Value;
                    DIAGNOSISFIELD1161.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_SK_ChairType) : "");
                    NewField11021.CalcValue = NewField11021.Value;
                    DIAGNOSISFIELD11711.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_SK_HeadDoctorApprove) : "");
                    DIAGNOSISFIELD11711.PostFieldValueCalculation();
                    NewField11041.CalcValue = NewField11041.Value;
                    DIAGNOSISFIELD11731.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_SK_OrthopedicExpApprove) : "");
                    DIAGNOSISFIELD11731.PostFieldValueCalculation();
                    NewField11051.CalcValue = NewField11051.Value;
                    DIAGNOSISFIELD11741.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_SK_FTRExpertApprove) : "");
                    DIAGNOSISFIELD11741.PostFieldValueCalculation();
                    NewField11061.CalcValue = NewField11061.Value;
                    DIAGNOSISFIELD11751.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_SK_ThirdStepHealthInst) : "");
                    DIAGNOSISFIELD11751.PostFieldValueCalculation();
                    NewField11911.CalcValue = NewField11911.Value;
                    DIAGNOSISFIELD11611.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_SK_MedicalReason) : "") + @"
";
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField11071.CalcValue = NewField11071.Value;
                    DIAGNOSISFIELD11761.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_RI_PatientNameSurname) : "");
                    DIAGNOSISFIELD11761.PostFieldValueCalculation();
                    NewField11081.CalcValue = NewField11081.Value;
                    DIAGNOSISFIELD11771.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_RI_MedulaInsCode) : "");
                    DIAGNOSISFIELD11771.PostFieldValueCalculation();
                    NewField11091.CalcValue = NewField11091.Value;
                    DIAGNOSISFIELD11781.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_RI_MedulaOrProtocolNo) : "");
                    DIAGNOSISFIELD11781.PostFieldValueCalculation();
                    NewField11101.CalcValue = NewField11101.Value;
                    DIAGNOSISFIELD11791.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_RI_DiagnosAndICD10Code) : "");
                    DIAGNOSISFIELD11791.PostFieldValueCalculation();
                    NewField11111.CalcValue = NewField11111.Value;
                    DIAGNOSISFIELD11801.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_RI_MachineName) : "");
                    DIAGNOSISFIELD11801.PostFieldValueCalculation();
                    NewField11131.CalcValue = NewField11131.Value;
                    DIAGNOSISFIELD11821.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_RI_WetSignature) : "");
                    DIAGNOSISFIELD11821.PostFieldValueCalculation();
                    return new TTReportObject[] { PNAME11,PSURNAME11,ReportDate11,ReportNo11,FULLNAME111,lblPAtientName111,ExaminationDate11,lblPAtientName1111,UNIQUEREFNO11,lblPAtientName1121,FULLNAME1121,lblPAtientName1131,FULLNAME1131,lblPAtientName1141,FULLNAME1141,lblPAtientName1151,NewField111,DIAGNOSISFIELD111,NewField121,NewField131,NewField141,NewField1111,DIAGNOSISFIELD1111,NewField1141,DIAGNOSISFIELD1121,NewField1151,DIAGNOSISFIELD1131,NewField1161,NewField1171,DIAGNOSISFIELD1141,NewField1181,DIAGNOSISFIELD1151,NewField1191,DIAGNOSISFIELD1161,NewField11021,DIAGNOSISFIELD11711,NewField11041,DIAGNOSISFIELD11731,NewField11051,DIAGNOSISFIELD11741,NewField11061,DIAGNOSISFIELD11751,NewField11911,DIAGNOSISFIELD11611,NewField11611,NewField11071,DIAGNOSISFIELD11761,NewField11081,DIAGNOSISFIELD11771,NewField11091,DIAGNOSISFIELD11781,NewField11101,DIAGNOSISFIELD11791,NewField11111,DIAGNOSISFIELD11801,NewField11131,DIAGNOSISFIELD11821};
                }
                public override void RunPreScript()
                {
#region ATS BODY_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.ChairExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion ATS BODY_PreScript
                }
            }

        }

        public ATSGroup ATS;

        public partial class ATS_HDGroup : TTReportGroup
        {
            public HC_LowerExtremiteReport MyParentReport
            {
                get { return (HC_LowerExtremiteReport)ParentReport; }
            }

            new public ATS_HDGroupBody Body()
            {
                return (ATS_HDGroupBody)_body;
            }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NewField11711 { get {return Body().NewField11711;} }
            public TTReportField DIAGNOSISFIELD11411 { get {return Body().DIAGNOSISFIELD11411;} }
            public TTReportField NewField11721 { get {return Body().NewField11721;} }
            public TTReportField DIAGNOSISFIELD11421 { get {return Body().DIAGNOSISFIELD11421;} }
            public TTReportField NewField11731 { get {return Body().NewField11731;} }
            public TTReportField DIAGNOSISFIELD11431 { get {return Body().DIAGNOSISFIELD11431;} }
            public TTReportField NewField113111 { get {return Body().NewField113111;} }
            public TTReportField ATS_HD1 { get {return Body().ATS_HD1;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField11116121 { get {return Body().NewField11116121;} }
            public TTReportField ATS_HD_NW1 { get {return Body().ATS_HD_NW1;} }
            public TTReportField NewField113711 { get {return Body().NewField113711;} }
            public TTReportField AmbutasyonLevel { get {return Body().AmbutasyonLevel;} }
            public TTReportField NewField1111311 { get {return Body().NewField1111311;} }
            public TTReportField ATS_HD11 { get {return Body().ATS_HD11;} }
            public TTReportField ATS_HD_NW11 { get {return Body().ATS_HD_NW11;} }
            public TTReportField NewField1111312 { get {return Body().NewField1111312;} }
            public TTReportField ATS_HD12 { get {return Body().ATS_HD12;} }
            public TTReportField ATS_HD_NW12 { get {return Body().ATS_HD_NW12;} }
            public TTReportField NewField1111313 { get {return Body().NewField1111313;} }
            public TTReportField ATS_HD13 { get {return Body().ATS_HD13;} }
            public TTReportField ATS_HD_NW13 { get {return Body().ATS_HD_NW13;} }
            public TTReportField NewField1111314 { get {return Body().NewField1111314;} }
            public TTReportField ATS_HD14 { get {return Body().ATS_HD14;} }
            public TTReportField ATS_HD_NW14 { get {return Body().ATS_HD_NW14;} }
            public TTReportField NewField11131111 { get {return Body().NewField11131111;} }
            public TTReportField ATS_HD111 { get {return Body().ATS_HD111;} }
            public TTReportField ATS_HD_NW111 { get {return Body().ATS_HD_NW111;} }
            public TTReportField NewField12131111 { get {return Body().NewField12131111;} }
            public TTReportField ATS_HD121 { get {return Body().ATS_HD121;} }
            public TTReportField ATS_HD_NW121 { get {return Body().ATS_HD_NW121;} }
            public TTReportField NewField13131111 { get {return Body().NewField13131111;} }
            public TTReportField ATS_HD131 { get {return Body().ATS_HD131;} }
            public TTReportField ATS_HD_NW131 { get {return Body().ATS_HD_NW131;} }
            public TTReportField NewField14131111 { get {return Body().NewField14131111;} }
            public TTReportField ATS_HD141 { get {return Body().ATS_HD141;} }
            public TTReportField ATS_HD_NW141 { get {return Body().ATS_HD_NW141;} }
            public ATS_HDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ATS_HDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ATS_HDGroupBody(this);
            }

            public partial class ATS_HDGroupBody : TTReportSection
            {
                public HC_LowerExtremiteReport MyParentReport
                {
                    get { return (HC_LowerExtremiteReport)ParentReport; }
                }
                
                public TTReportField NewField111611;
                public TTReportField NewField11711;
                public TTReportField DIAGNOSISFIELD11411;
                public TTReportField NewField11721;
                public TTReportField DIAGNOSISFIELD11421;
                public TTReportField NewField11731;
                public TTReportField DIAGNOSISFIELD11431;
                public TTReportField NewField113111;
                public TTReportField ATS_HD1;
                public TTReportField NewField1116111;
                public TTReportField NewField11116111;
                public TTReportField NewField11116121;
                public TTReportField ATS_HD_NW1;
                public TTReportField NewField113711;
                public TTReportField AmbutasyonLevel;
                public TTReportField NewField1111311;
                public TTReportField ATS_HD11;
                public TTReportField ATS_HD_NW11;
                public TTReportField NewField1111312;
                public TTReportField ATS_HD12;
                public TTReportField ATS_HD_NW12;
                public TTReportField NewField1111313;
                public TTReportField ATS_HD13;
                public TTReportField ATS_HD_NW13;
                public TTReportField NewField1111314;
                public TTReportField ATS_HD14;
                public TTReportField ATS_HD_NW14;
                public TTReportField NewField11131111;
                public TTReportField ATS_HD111;
                public TTReportField ATS_HD_NW111;
                public TTReportField NewField12131111;
                public TTReportField ATS_HD121;
                public TTReportField ATS_HD_NW121;
                public TTReportField NewField13131111;
                public TTReportField ATS_HD131;
                public TTReportField ATS_HD_NW131;
                public TTReportField NewField14131111;
                public TTReportField ATS_HD141;
                public TTReportField ATS_HD_NW141; 
                public ATS_HDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 150;
                    RepeatCount = 0;
                    
                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 9, 202, 14, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.Underline = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"HASTA DEĞERLENDİRME:";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 15, 93, 20, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.Value = @"Boy:";

                    DIAGNOSISFIELD11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 15, 202, 20, false);
                    DIAGNOSISFIELD11411.Name = "DIAGNOSISFIELD11411";
                    DIAGNOSISFIELD11411.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11411.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11411.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11411.Value = @"{#ATS_HEADER.HEIGTH#}";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 21, 93, 26, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11721.Value = @"Kilo";

                    DIAGNOSISFIELD11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 21, 202, 26, false);
                    DIAGNOSISFIELD11421.Name = "DIAGNOSISFIELD11421";
                    DIAGNOSISFIELD11421.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11421.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11421.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11421.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11421.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11421.Value = @"{#ATS_HEADER.WEIGHT#}";

                    NewField11731 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 27, 93, 35, false);
                    NewField11731.Name = "NewField11731";
                    NewField11731.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11731.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11731.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11731.Value = @"Halihazırdaki sandalyesini ne kadar mesafe sürebiliyor?";

                    DIAGNOSISFIELD11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 27, 202, 35, false);
                    DIAGNOSISFIELD11431.Name = "DIAGNOSISFIELD11431";
                    DIAGNOSISFIELD11431.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISFIELD11431.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISFIELD11431.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11431.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11431.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD11431.Value = @"{#ATS_HEADER.ATS_HD_CHAIRDISTANCE#}";

                    NewField113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 54, 93, 59, false);
                    NewField113111.Name = "NewField113111";
                    NewField113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111.Value = @"Hasta yürümek için alt ekstremitelerini kullanabiliyor mu?";

                    ATS_HD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 54, 125, 59, false);
                    ATS_HD1.Name = "ATS_HD1";
                    ATS_HD1.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD1.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD1.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD1.ObjectDefName = "YesNoEnum";
                    ATS_HD1.DataMember = "DISPLAYTEXT";
                    ATS_HD1.Value = @"{#ATS_HEADER.ATS_HD_USELOWEREXTREMITIES#}";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 47, 93, 52, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1116111.TextFont.Name = "Arial";
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.Underline = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 47, 125, 52, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11116111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11116111.TextFont.Name = "Arial";
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"EVET / HAYIR";

                    NewField11116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 47, 202, 52, false);
                    NewField11116121.Name = "NewField11116121";
                    NewField11116121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11116121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11116121.TextFont.Name = "Arial";
                    NewField11116121.TextFont.Bold = true;
                    NewField11116121.TextFont.CharSet = 162;
                    NewField11116121.Value = @"AÇIKLAMA";

                    ATS_HD_NW1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 54, 202, 59, false);
                    ATS_HD_NW1.Name = "ATS_HD_NW1";
                    ATS_HD_NW1.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW1.TextFont.Name = "Arial";
                    ATS_HD_NW1.TextFont.Bold = true;
                    ATS_HD_NW1.TextFont.Underline = true;
                    ATS_HD_NW1.TextFont.CharSet = 162;
                    ATS_HD_NW1.Value = @"{#ATS_HEADER.ATS_HD_USELOWEREXTREMITY_DESC#}";

                    NewField113711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 36, 93, 44, false);
                    NewField113711.Name = "NewField113711";
                    NewField113711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113711.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113711.Value = @"Hastanın ambulasyon derecesi nedir?";

                    AmbutasyonLevel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 36, 202, 44, false);
                    AmbutasyonLevel.Name = "AmbutasyonLevel";
                    AmbutasyonLevel.DrawStyle = DrawStyleConstants.vbSolid;
                    AmbutasyonLevel.Value = @"";

                    NewField1111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 60, 93, 65, false);
                    NewField1111311.Name = "NewField1111311";
                    NewField1111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111311.Value = @"Hastalığı sürekli mi?";

                    ATS_HD11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 60, 125, 65, false);
                    ATS_HD11.Name = "ATS_HD11";
                    ATS_HD11.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD11.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD11.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD11.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD11.ObjectDefName = "YesNoEnum";
                    ATS_HD11.DataMember = "DISPLAYTEXT";
                    ATS_HD11.Value = @"{#ATS_HEADER.ATS_HD_CONSTANTCONDITION#}";

                    ATS_HD_NW11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 60, 202, 65, false);
                    ATS_HD_NW11.Name = "ATS_HD_NW11";
                    ATS_HD_NW11.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW11.TextFont.Name = "Arial";
                    ATS_HD_NW11.TextFont.Bold = true;
                    ATS_HD_NW11.TextFont.Underline = true;
                    ATS_HD_NW11.TextFont.CharSet = 162;
                    ATS_HD_NW11.Value = @"{#ATS_HEADER.ATS_HD_CONSTANTCONDITION_DESC#}";

                    NewField1111312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 66, 93, 71, false);
                    NewField1111312.Name = "NewField1111312";
                    NewField1111312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111312.Value = @"Hastanın tekerlekli sandalye marka/model tercih dilekçesi var mı?";

                    ATS_HD12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 66, 125, 71, false);
                    ATS_HD12.Name = "ATS_HD12";
                    ATS_HD12.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD12.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD12.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD12.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD12.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD12.ObjectDefName = "YesNoEnum";
                    ATS_HD12.DataMember = "DISPLAYTEXT";
                    ATS_HD12.Value = @"{#ATS_HEADER.ATS_HD_CHAIRMODEL#}";

                    ATS_HD_NW12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 66, 202, 71, false);
                    ATS_HD_NW12.Name = "ATS_HD_NW12";
                    ATS_HD_NW12.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW12.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW12.TextFont.Name = "Arial";
                    ATS_HD_NW12.TextFont.Bold = true;
                    ATS_HD_NW12.TextFont.Underline = true;
                    ATS_HD_NW12.TextFont.CharSet = 162;
                    ATS_HD_NW12.Value = @"{#ATS_HEADER.ATS_HD_CHAIRMODEL_DESC#}";

                    NewField1111313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 72, 93, 77, false);
                    NewField1111313.Name = "NewField1111313";
                    NewField1111313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111313.Value = @"Tekerlekli Sandalyeyi Kendisi Kullanabiliyor mu?  ";

                    ATS_HD13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 72, 125, 77, false);
                    ATS_HD13.Name = "ATS_HD13";
                    ATS_HD13.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD13.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD13.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD13.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD13.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD13.ObjectDefName = "YesNoEnum";
                    ATS_HD13.DataMember = "DISPLAYTEXT";
                    ATS_HD13.Value = @"{#ATS_HEADER.ATS_HD_USEHIMSELF#}";

                    ATS_HD_NW13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 72, 202, 77, false);
                    ATS_HD_NW13.Name = "ATS_HD_NW13";
                    ATS_HD_NW13.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW13.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW13.TextFont.Name = "Arial";
                    ATS_HD_NW13.TextFont.Bold = true;
                    ATS_HD_NW13.TextFont.Underline = true;
                    ATS_HD_NW13.TextFont.CharSet = 162;
                    ATS_HD_NW13.Value = @"{#ATS_HEADER.ATS_HD_USEHIMSELF_DESC#}";

                    NewField1111314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 78, 93, 83, false);
                    NewField1111314.Name = "NewField1111314";
                    NewField1111314.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111314.Value = @"Sandalyeye oturmayı engelleyecek deformitesi var mı?";

                    ATS_HD14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 78, 125, 83, false);
                    ATS_HD14.Name = "ATS_HD14";
                    ATS_HD14.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD14.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD14.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD14.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD14.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD14.ObjectDefName = "YesNoEnum";
                    ATS_HD14.DataMember = "DISPLAYTEXT";
                    ATS_HD14.Value = @"{#ATS_HEADER.ATS_HD_DEFORMITY#}";

                    ATS_HD_NW14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 78, 202, 83, false);
                    ATS_HD_NW14.Name = "ATS_HD_NW14";
                    ATS_HD_NW14.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW14.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW14.TextFont.Name = "Arial";
                    ATS_HD_NW14.TextFont.Bold = true;
                    ATS_HD_NW14.TextFont.Underline = true;
                    ATS_HD_NW14.TextFont.CharSet = 162;
                    ATS_HD_NW14.Value = @"{#ATS_HEADER.ATS_HD_DEFORMITY_DESC#}";

                    NewField11131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 84, 93, 89, false);
                    NewField11131111.Name = "NewField11131111";
                    NewField11131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131111.Value = @"Eklem kontraktürü var mı?";

                    ATS_HD111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 84, 125, 89, false);
                    ATS_HD111.Name = "ATS_HD111";
                    ATS_HD111.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD111.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD111.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD111.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD111.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD111.ObjectDefName = "YesNoEnum";
                    ATS_HD111.DataMember = "DISPLAYTEXT";
                    ATS_HD111.Value = @"{#ATS_HEADER.ATS_HD_CONTRACTURE#}";

                    ATS_HD_NW111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 84, 202, 89, false);
                    ATS_HD_NW111.Name = "ATS_HD_NW111";
                    ATS_HD_NW111.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW111.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW111.TextFont.Name = "Arial";
                    ATS_HD_NW111.TextFont.Bold = true;
                    ATS_HD_NW111.TextFont.Underline = true;
                    ATS_HD_NW111.TextFont.CharSet = 162;
                    ATS_HD_NW111.Value = @"{#ATS_HEADER.ATS_HD_CONTRACTURE_DESC#}";

                    NewField12131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 90, 93, 95, false);
                    NewField12131111.Name = "NewField12131111";
                    NewField12131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12131111.Value = @"Kardiyovasküler hastalık var mı?";

                    ATS_HD121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 90, 125, 95, false);
                    ATS_HD121.Name = "ATS_HD121";
                    ATS_HD121.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD121.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD121.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD121.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD121.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD121.ObjectDefName = "YesNoEnum";
                    ATS_HD121.DataMember = "DISPLAYTEXT";
                    ATS_HD121.Value = @"{#ATS_HEADER.ATS_HD_CARDIOVASCULAR#}";

                    ATS_HD_NW121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 90, 202, 95, false);
                    ATS_HD_NW121.Name = "ATS_HD_NW121";
                    ATS_HD_NW121.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW121.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW121.TextFont.Name = "Arial";
                    ATS_HD_NW121.TextFont.Bold = true;
                    ATS_HD_NW121.TextFont.Underline = true;
                    ATS_HD_NW121.TextFont.CharSet = 162;
                    ATS_HD_NW121.Value = @"{#ATS_HEADER.ATS_HD_CARDIOVASCULAR_DESC#}";

                    NewField13131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 96, 93, 101, false);
                    NewField13131111.Name = "NewField13131111";
                    NewField13131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13131111.Value = @"Pulmoner hastalık var mı?";

                    ATS_HD131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 96, 125, 101, false);
                    ATS_HD131.Name = "ATS_HD131";
                    ATS_HD131.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD131.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD131.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD131.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD131.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD131.ObjectDefName = "YesNoEnum";
                    ATS_HD131.DataMember = "DISPLAYTEXT";
                    ATS_HD131.Value = @"{#ATS_HEADER.ATS_HD_PULMONARY#}";

                    ATS_HD_NW131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 96, 202, 101, false);
                    ATS_HD_NW131.Name = "ATS_HD_NW131";
                    ATS_HD_NW131.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW131.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW131.TextFont.Name = "Arial";
                    ATS_HD_NW131.TextFont.Bold = true;
                    ATS_HD_NW131.TextFont.Underline = true;
                    ATS_HD_NW131.TextFont.CharSet = 162;
                    ATS_HD_NW131.Value = @"{#ATS_HEADER.ATS_HD_PULMONARY_DESC#}";

                    NewField14131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 102, 93, 107, false);
                    NewField14131111.Name = "NewField14131111";
                    NewField14131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14131111.Value = @"Organ yetmezliği var mı?";

                    ATS_HD141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 102, 125, 107, false);
                    ATS_HD141.Name = "ATS_HD141";
                    ATS_HD141.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD141.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD141.MultiLine = EvetHayirEnum.ehEvet;
                    ATS_HD141.WordBreak = EvetHayirEnum.ehEvet;
                    ATS_HD141.ExpandTabs = EvetHayirEnum.ehEvet;
                    ATS_HD141.ObjectDefName = "YesNoEnum";
                    ATS_HD141.DataMember = "DISPLAYTEXT";
                    ATS_HD141.Value = @"{#ATS_HEADER.ATS_HD_ORGANFAILURE#}";

                    ATS_HD_NW141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 102, 202, 107, false);
                    ATS_HD_NW141.Name = "ATS_HD_NW141";
                    ATS_HD_NW141.DrawStyle = DrawStyleConstants.vbSolid;
                    ATS_HD_NW141.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATS_HD_NW141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATS_HD_NW141.TextFont.Name = "Arial";
                    ATS_HD_NW141.TextFont.Bold = true;
                    ATS_HD_NW141.TextFont.Underline = true;
                    ATS_HD_NW141.TextFont.CharSet = 162;
                    ATS_HD_NW141.Value = @"{#ATS_HEADER.ATS_HD_ORGANFAILURE_DESC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LowerExtremity.GetExtremityReportInfoByObjId_Class dataset_GetExtremityReportInfoByObjId = MyParentReport.ATS_HEADER.rsGroup.GetCurrentRecord<LowerExtremity.GetExtremityReportInfoByObjId_Class>(0);
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    DIAGNOSISFIELD11411.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Heigth) : "");
                    NewField11721.CalcValue = NewField11721.Value;
                    DIAGNOSISFIELD11421.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.Weight) : "");
                    NewField11731.CalcValue = NewField11731.Value;
                    DIAGNOSISFIELD11431.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_ChairDistance) : "");
                    NewField113111.CalcValue = NewField113111.Value;
                    ATS_HD1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_USELOWEREXTREMITIES) : "");
                    ATS_HD1.PostFieldValueCalculation();
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField11116121.CalcValue = NewField11116121.Value;
                    ATS_HD_NW1.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_UseLowerExtremity_Desc) : "");
                    NewField113711.CalcValue = NewField113711.Value;
                    AmbutasyonLevel.CalcValue = AmbutasyonLevel.Value;
                    NewField1111311.CalcValue = NewField1111311.Value;
                    ATS_HD11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_ConstantCondition) : "");
                    ATS_HD11.PostFieldValueCalculation();
                    ATS_HD_NW11.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_ConstantCondition_Desc) : "");
                    NewField1111312.CalcValue = NewField1111312.Value;
                    ATS_HD12.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_ChairModel) : "");
                    ATS_HD12.PostFieldValueCalculation();
                    ATS_HD_NW12.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_ChairModel_Desc) : "");
                    NewField1111313.CalcValue = NewField1111313.Value;
                    ATS_HD13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_UseHimself) : "");
                    ATS_HD13.PostFieldValueCalculation();
                    ATS_HD_NW13.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_UseHimself_Desc) : "");
                    NewField1111314.CalcValue = NewField1111314.Value;
                    ATS_HD14.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Deformity) : "");
                    ATS_HD14.PostFieldValueCalculation();
                    ATS_HD_NW14.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Deformity_Desc) : "");
                    NewField11131111.CalcValue = NewField11131111.Value;
                    ATS_HD111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Contracture) : "");
                    ATS_HD111.PostFieldValueCalculation();
                    ATS_HD_NW111.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Contracture_Desc) : "");
                    NewField12131111.CalcValue = NewField12131111.Value;
                    ATS_HD121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Cardiovascular) : "");
                    ATS_HD121.PostFieldValueCalculation();
                    ATS_HD_NW121.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Cardiovascular_Desc) : "");
                    NewField13131111.CalcValue = NewField13131111.Value;
                    ATS_HD131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Pulmonary) : "");
                    ATS_HD131.PostFieldValueCalculation();
                    ATS_HD_NW131.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_Pulmonary_Desc) : "");
                    NewField14131111.CalcValue = NewField14131111.Value;
                    ATS_HD141.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_OrganFailure) : "");
                    ATS_HD141.PostFieldValueCalculation();
                    ATS_HD_NW141.CalcValue = (dataset_GetExtremityReportInfoByObjId != null ? Globals.ToStringCore(dataset_GetExtremityReportInfoByObjId.ATS_HD_OrganFailure_Desc) : "");
                    return new TTReportObject[] { NewField111611,NewField11711,DIAGNOSISFIELD11411,NewField11721,DIAGNOSISFIELD11421,NewField11731,DIAGNOSISFIELD11431,NewField113111,ATS_HD1,NewField1116111,NewField11116111,NewField11116121,ATS_HD_NW1,NewField113711,AmbutasyonLevel,NewField1111311,ATS_HD11,ATS_HD_NW11,NewField1111312,ATS_HD12,ATS_HD_NW12,NewField1111313,ATS_HD13,ATS_HD_NW13,NewField1111314,ATS_HD14,ATS_HD_NW14,NewField11131111,ATS_HD111,ATS_HD_NW111,NewField12131111,ATS_HD121,ATS_HD_NW121,NewField13131111,ATS_HD131,ATS_HD_NW131,NewField14131111,ATS_HD141,ATS_HD_NW141};
                }
                public override void RunPreScript()
                {
#region ATS_HD BODY_PreScript
                    if (((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.ReportType == HC_ExtremiteReportTypeEnum.ChairExtremite)
                this.Visible = EvetHayirEnum.ehEvet;
            else
                this.Visible = EvetHayirEnum.ehHayir;
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LowerExtremity leReport = (LowerExtremity)context.GetObject(new Guid(sObjectID), "LowerExtremity");
            if (leReport.ATS_HD_INTRACOMMUNITY == true)
            {
                this.AmbutasyonLevel.Value = "Toplum İçi Ambulasyon";
            }
            else if (leReport.ATS_HD_Therapeutic == true)
                this.AmbutasyonLevel.Value = "Terapötik Ambulasyon";
            else if (leReport.ATS_HD_NOAMBULATION == true)
                this.AmbutasyonLevel.Value = "Ambulasyonu Yok";
#endregion ATS_HD BODY_PreScript
                }

                public override void RunScript()
                {
#region ATS_HD BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((HC_LowerExtremiteReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    LowerExtremity leReport = (LowerExtremity)context.GetObject(new Guid(sObjectID), "LowerExtremity");
                    if (leReport.ATS_HD_INTRACOMMUNITY == true)
                    {
                        this.AmbutasyonLevel.Value = "Toplum İçi Ambulasyon";
                    }
                    else if (leReport.ATS_HD_Therapeutic == true)
                        this.AmbutasyonLevel.Value = "Terapötik Ambulasyon";
                    else if (leReport.ATS_HD_NOAMBULATION == true)
                        this.AmbutasyonLevel.Value = "Ambulasyonu Yok";
#endregion ATS_HD BODY_Script
                }
            }

        }

        public ATS_HDGroup ATS_HD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HC_LowerExtremiteReport()
        {
            ALT_EKTREMITE_HEADER = new ALT_EKTREMITE_HEADERGroup(this,"ALT_EKTREMITE_HEADER");
            ALT_EKSTREMITE = new ALT_EKSTREMITEGroup(ALT_EKTREMITE_HEADER,"ALT_EKSTREMITE");
            ALT_EKSTREMITE_TEM = new ALT_EKSTREMITE_TEMGroup(ALT_EKTREMITE_HEADER,"ALT_EKSTREMITE_TEM");
            UST_EKSTREMITE_HEADER = new UST_EKSTREMITE_HEADERGroup(this,"UST_EKSTREMITE_HEADER");
            UST_EKSTREMITE = new UST_EKSTREMITEGroup(UST_EKSTREMITE_HEADER,"UST_EKSTREMITE");
            UST_EKSTREMITE_HD = new UST_EKSTREMITE_HDGroup(UST_EKSTREMITE_HEADER,"UST_EKSTREMITE_HD");
            ATS_HEADER = new ATS_HEADERGroup(this,"ATS_HEADER");
            ATS = new ATSGroup(ATS_HEADER,"ATS");
            ATS_HD = new ATS_HDGroup(ATS_HEADER,"ATS_HD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("ReportType", "", "Rapor Tipi", @"", true, true, false, new Guid("96ad9769-6fe5-40d2-80de-44ca8d82be41"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("ReportType"))
                _runtimeParameters.ReportType = (HC_ExtremiteReportTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HC_ExtremiteReportTypeEnum"].ConvertValue(parameters["ReportType"]);
            Name = "HC_LOWEREXTREMITEREPORT";
            Caption = "ALT EKTREMİTE PROTEZLERİ İÇİN";
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