
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
    public partial class FaaliyetRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string PROCEDUREBYUSER = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue("");
        }

        public partial class part1Group : TTReportGroup
        {
            public FaaliyetRaporu MyParentReport
            {
                get { return (FaaliyetRaporu)ParentReport; }
            }

            new public part1GroupHeader Header()
            {
                return (part1GroupHeader)_header;
            }

            new public part1GroupFooter Footer()
            {
                return (part1GroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HospitalInfo11 { get {return Header().HospitalInfo11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField182141 { get {return Footer().NewField182141;} }
            public TTReportField NewField182142 { get {return Footer().NewField182142;} }
            public TTReportField NewField1141281 { get {return Footer().NewField1141281;} }
            public TTReportField NewField1241281 { get {return Footer().NewField1241281;} }
            public TTReportField NewField1141282 { get {return Footer().NewField1141282;} }
            public TTReportField NewField1241282 { get {return Footer().NewField1241282;} }
            public TTReportField NewField11821411 { get {return Footer().NewField11821411;} }
            public TTReportField NewField11821421 { get {return Footer().NewField11821421;} }
            public TTReportField NewField11821412 { get {return Footer().NewField11821412;} }
            public TTReportField NewField11821422 { get {return Footer().NewField11821422;} }
            public TTReportField NewField11821413 { get {return Footer().NewField11821413;} }
            public TTReportField NewField11821423 { get {return Footer().NewField11821423;} }
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
                public FaaliyetRaporu MyParentReport
                {
                    get { return (FaaliyetRaporu)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField HospitalInfo11;
                public TTReportField NewField111; 
                public part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 38, 27, false);
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

                    HospitalInfo11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 4, 234, 30, false);
                    HospitalInfo11.Name = "HospitalInfo11";
                    HospitalInfo11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo11.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo11.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo11.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo11.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo11.TextFont.Size = 14;
                    HospitalInfo11.TextFont.Bold = true;
                    HospitalInfo11.TextFont.CharSet = 162;
                    HospitalInfo11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 31, 217, 38, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Sosyal Hizmetler Faaliyet Raporu
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    NewField111.CalcValue = NewField111.Value;
                    HospitalInfo11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,NewField111,HospitalInfo11};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    MyParentReport.RuntimeParameters.STARTDATE = Convert.ToDateTime(MyParentReport.RuntimeParameters.STARTDATE.Value.ToShortDateString() + " 00:00:00");
            MyParentReport.RuntimeParameters.ENDDATE = Convert.ToDateTime(MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString() + " 23:59:59");
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PART1 HEADER_Script
                }
            }
            public partial class part1GroupFooter : TTReportSection
            {
                public FaaliyetRaporu MyParentReport
                {
                    get { return (FaaliyetRaporu)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField182141;
                public TTReportField NewField182142;
                public TTReportField NewField1141281;
                public TTReportField NewField1241281;
                public TTReportField NewField1141282;
                public TTReportField NewField1241282;
                public TTReportField NewField11821411;
                public TTReportField NewField11821421;
                public TTReportField NewField11821412;
                public TTReportField NewField11821422;
                public TTReportField NewField11821413;
                public TTReportField NewField11821423; 
                public part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 39;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 5, 220, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.Value = @"XXXXXX HİZMETLERİNİN GELİŞTİRİLMESİNE VE PERSONELE YÖNELİK ÇALIŞMALAR";

                    NewField182141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 16, 67, 26, false);
                    NewField182141.Name = "NewField182141";
                    NewField182141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182141.Value = @"EĞİTİM ÇALIŞMALARI";

                    NewField182142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 26, 67, 36, false);
                    NewField182142.Name = "NewField182142";
                    NewField182142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182142.Value = @"GÖNÜLLÜ ÇALIŞMALARIN ORGANİZASYONU";

                    NewField1141281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 16, 113, 26, false);
                    NewField1141281.Name = "NewField1141281";
                    NewField1141281.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141281.Value = @"";

                    NewField1241281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 26, 113, 36, false);
                    NewField1241281.Name = "NewField1241281";
                    NewField1241281.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241281.Value = @"";

                    NewField1141282 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 16, 161, 26, false);
                    NewField1141282.Name = "NewField1141282";
                    NewField1141282.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141282.Value = @"ARAŞTIRMA KALİTE ÇALIŞMALARI";

                    NewField1241282 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 26, 161, 36, false);
                    NewField1241282.Name = "NewField1241282";
                    NewField1241282.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241282.Value = @"SOSYAL ETKİNLİK";

                    NewField11821411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 16, 199, 26, false);
                    NewField11821411.Name = "NewField11821411";
                    NewField11821411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821411.Value = @"";

                    NewField11821421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 26, 199, 36, false);
                    NewField11821421.Name = "NewField11821421";
                    NewField11821421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821421.Value = @"";

                    NewField11821412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 16, 245, 26, false);
                    NewField11821412.Name = "NewField11821412";
                    NewField11821412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11821412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11821412.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11821412.Value = @"PERSONELE YÖNELİK PSİKO
SOSYAL DANIŞMANLIK";

                    NewField11821422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 26, 245, 36, false);
                    NewField11821422.Name = "NewField11821422";
                    NewField11821422.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821422.Value = @"DİĞER ÇALIŞMALAR";

                    NewField11821413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 16, 291, 26, false);
                    NewField11821413.Name = "NewField11821413";
                    NewField11821413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821413.Value = @"";

                    NewField11821423 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 26, 291, 36, false);
                    NewField11821423.Name = "NewField11821423";
                    NewField11821423.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821423.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    NewField182141.CalcValue = NewField182141.Value;
                    NewField182142.CalcValue = NewField182142.Value;
                    NewField1141281.CalcValue = NewField1141281.Value;
                    NewField1241281.CalcValue = NewField1241281.Value;
                    NewField1141282.CalcValue = NewField1141282.Value;
                    NewField1241282.CalcValue = NewField1241282.Value;
                    NewField11821411.CalcValue = NewField11821411.Value;
                    NewField11821421.CalcValue = NewField11821421.Value;
                    NewField11821412.CalcValue = NewField11821412.Value;
                    NewField11821422.CalcValue = NewField11821422.Value;
                    NewField11821413.CalcValue = NewField11821413.Value;
                    NewField11821423.CalcValue = NewField11821423.Value;
                    return new TTReportObject[] { NewField2,NewField182141,NewField182142,NewField1141281,NewField1241281,NewField1141282,NewField1241282,NewField11821411,NewField11821421,NewField11821412,NewField11821422,NewField11821413,NewField11821423};
                }
            }

        }

        public part1Group part1;

        public partial class MAINGroup : TTReportGroup
        {
            public FaaliyetRaporu MyParentReport
            {
                get { return (FaaliyetRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField1211 { get {return Body().NewField1211;} }
            public TTReportField NewField1212 { get {return Body().NewField1212;} }
            public TTReportField NewField1213 { get {return Body().NewField1213;} }
            public TTReportField NewField1214 { get {return Body().NewField1214;} }
            public TTReportField NewField14121 { get {return Body().NewField14121;} }
            public TTReportField NewField14122 { get {return Body().NewField14122;} }
            public TTReportField NewField14123 { get {return Body().NewField14123;} }
            public TTReportField NewField14124 { get {return Body().NewField14124;} }
            public TTReportField NewField14125 { get {return Body().NewField14125;} }
            public TTReportField NewField14126 { get {return Body().NewField14126;} }
            public TTReportField NewField14127 { get {return Body().NewField14127;} }
            public TTReportField NewField14128 { get {return Body().NewField14128;} }
            public TTReportField NewField14129 { get {return Body().NewField14129;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField ASDASD { get {return Body().ASDASD;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField R0C0 { get {return Body().R0C0;} }
            public TTReportField R0C1 { get {return Body().R0C1;} }
            public TTReportField R0C2 { get {return Body().R0C2;} }
            public TTReportField R0C3 { get {return Body().R0C3;} }
            public TTReportField R0C4 { get {return Body().R0C4;} }
            public TTReportField R0C5 { get {return Body().R0C5;} }
            public TTReportField R0C6 { get {return Body().R0C6;} }
            public TTReportField R0C7 { get {return Body().R0C7;} }
            public TTReportField R0C8 { get {return Body().R0C8;} }
            public TTReportField R0C10 { get {return Body().R0C10;} }
            public TTReportField R0C11 { get {return Body().R0C11;} }
            public TTReportField R0C12 { get {return Body().R0C12;} }
            public TTReportField R0C14 { get {return Body().R0C14;} }
            public TTReportField R0C15 { get {return Body().R0C15;} }
            public TTReportField R0C16 { get {return Body().R0C16;} }
            public TTReportField R0Toplam { get {return Body().R0Toplam;} }
            public TTReportField R0C9 { get {return Body().R0C9;} }
            public TTReportField R1C0 { get {return Body().R1C0;} }
            public TTReportField R1C1 { get {return Body().R1C1;} }
            public TTReportField R1C2 { get {return Body().R1C2;} }
            public TTReportField R1C3 { get {return Body().R1C3;} }
            public TTReportField R1C4 { get {return Body().R1C4;} }
            public TTReportField R1C5 { get {return Body().R1C5;} }
            public TTReportField R1C6 { get {return Body().R1C6;} }
            public TTReportField R1C7 { get {return Body().R1C7;} }
            public TTReportField R1C10 { get {return Body().R1C10;} }
            public TTReportField R1C11 { get {return Body().R1C11;} }
            public TTReportField R1C12 { get {return Body().R1C12;} }
            public TTReportField R1C14 { get {return Body().R1C14;} }
            public TTReportField R1C15 { get {return Body().R1C15;} }
            public TTReportField R1C16 { get {return Body().R1C16;} }
            public TTReportField R1Toplam { get {return Body().R1Toplam;} }
            public TTReportField R1C8 { get {return Body().R1C8;} }
            public TTReportField R1C9 { get {return Body().R1C9;} }
            public TTReportField R2C0 { get {return Body().R2C0;} }
            public TTReportField R2C1 { get {return Body().R2C1;} }
            public TTReportField R2C2 { get {return Body().R2C2;} }
            public TTReportField R2C3 { get {return Body().R2C3;} }
            public TTReportField R2C4 { get {return Body().R2C4;} }
            public TTReportField R2C5 { get {return Body().R2C5;} }
            public TTReportField R2C6 { get {return Body().R2C6;} }
            public TTReportField R2C7 { get {return Body().R2C7;} }
            public TTReportField R2C8 { get {return Body().R2C8;} }
            public TTReportField R2C9 { get {return Body().R2C9;} }
            public TTReportField R2C10 { get {return Body().R2C10;} }
            public TTReportField R2C11 { get {return Body().R2C11;} }
            public TTReportField R2C12 { get {return Body().R2C12;} }
            public TTReportField R2C14 { get {return Body().R2C14;} }
            public TTReportField R2C15 { get {return Body().R2C15;} }
            public TTReportField R2C16 { get {return Body().R2C16;} }
            public TTReportField R2Toplam { get {return Body().R2Toplam;} }
            public TTReportField R3C0 { get {return Body().R3C0;} }
            public TTReportField R3C1 { get {return Body().R3C1;} }
            public TTReportField R3C2 { get {return Body().R3C2;} }
            public TTReportField R3C3 { get {return Body().R3C3;} }
            public TTReportField R3C4 { get {return Body().R3C4;} }
            public TTReportField R3C5 { get {return Body().R3C5;} }
            public TTReportField R3C6 { get {return Body().R3C6;} }
            public TTReportField R3C7 { get {return Body().R3C7;} }
            public TTReportField R3C10 { get {return Body().R3C10;} }
            public TTReportField R3C11 { get {return Body().R3C11;} }
            public TTReportField R3C12 { get {return Body().R3C12;} }
            public TTReportField R3C14 { get {return Body().R3C14;} }
            public TTReportField R3C15 { get {return Body().R3C15;} }
            public TTReportField R3C16 { get {return Body().R3C16;} }
            public TTReportField R3Toplam { get {return Body().R3Toplam;} }
            public TTReportField R3C8 { get {return Body().R3C8;} }
            public TTReportField R3C9 { get {return Body().R3C9;} }
            public TTReportField R4C0 { get {return Body().R4C0;} }
            public TTReportField R4C1 { get {return Body().R4C1;} }
            public TTReportField R4C2 { get {return Body().R4C2;} }
            public TTReportField R4C3 { get {return Body().R4C3;} }
            public TTReportField R4C4 { get {return Body().R4C4;} }
            public TTReportField R4C5 { get {return Body().R4C5;} }
            public TTReportField R4C6 { get {return Body().R4C6;} }
            public TTReportField R4C7 { get {return Body().R4C7;} }
            public TTReportField R4C10 { get {return Body().R4C10;} }
            public TTReportField R4C11 { get {return Body().R4C11;} }
            public TTReportField R4C8 { get {return Body().R4C8;} }
            public TTReportField R4C9 { get {return Body().R4C9;} }
            public TTReportField R4C12 { get {return Body().R4C12;} }
            public TTReportField R4C14 { get {return Body().R4C14;} }
            public TTReportField R4C15 { get {return Body().R4C15;} }
            public TTReportField R4C16 { get {return Body().R4C16;} }
            public TTReportField R4Toplam { get {return Body().R4Toplam;} }
            public TTReportField R5C0 { get {return Body().R5C0;} }
            public TTReportField R5C1 { get {return Body().R5C1;} }
            public TTReportField R5C2 { get {return Body().R5C2;} }
            public TTReportField R5C3 { get {return Body().R5C3;} }
            public TTReportField R5C4 { get {return Body().R5C4;} }
            public TTReportField R5C5 { get {return Body().R5C5;} }
            public TTReportField R5C6 { get {return Body().R5C6;} }
            public TTReportField R5C7 { get {return Body().R5C7;} }
            public TTReportField R5C8 { get {return Body().R5C8;} }
            public TTReportField R5C9 { get {return Body().R5C9;} }
            public TTReportField R5C10 { get {return Body().R5C10;} }
            public TTReportField R5C11 { get {return Body().R5C11;} }
            public TTReportField R5C12 { get {return Body().R5C12;} }
            public TTReportField R5C14 { get {return Body().R5C14;} }
            public TTReportField R5C15 { get {return Body().R5C15;} }
            public TTReportField R5C16 { get {return Body().R5C16;} }
            public TTReportField R5Toplam { get {return Body().R5Toplam;} }
            public TTReportField R6C0 { get {return Body().R6C0;} }
            public TTReportField R7C0 { get {return Body().R7C0;} }
            public TTReportField R8C0 { get {return Body().R8C0;} }
            public TTReportField R9C0 { get {return Body().R9C0;} }
            public TTReportField R10C0 { get {return Body().R10C0;} }
            public TTReportField R11C0 { get {return Body().R11C0;} }
            public TTReportField R12C0 { get {return Body().R12C0;} }
            public TTReportField R13C0 { get {return Body().R13C0;} }
            public TTReportField C0Toplam { get {return Body().C0Toplam;} }
            public TTReportField R6C1 { get {return Body().R6C1;} }
            public TTReportField R7C1 { get {return Body().R7C1;} }
            public TTReportField R8C1 { get {return Body().R8C1;} }
            public TTReportField R9C1 { get {return Body().R9C1;} }
            public TTReportField R10C1 { get {return Body().R10C1;} }
            public TTReportField R11C1 { get {return Body().R11C1;} }
            public TTReportField R12C1 { get {return Body().R12C1;} }
            public TTReportField R13C1 { get {return Body().R13C1;} }
            public TTReportField C1Toplam { get {return Body().C1Toplam;} }
            public TTReportField R6C2 { get {return Body().R6C2;} }
            public TTReportField R7C2 { get {return Body().R7C2;} }
            public TTReportField R8C2 { get {return Body().R8C2;} }
            public TTReportField R9C2 { get {return Body().R9C2;} }
            public TTReportField R10C2 { get {return Body().R10C2;} }
            public TTReportField R11C2 { get {return Body().R11C2;} }
            public TTReportField R12C2 { get {return Body().R12C2;} }
            public TTReportField R13C2 { get {return Body().R13C2;} }
            public TTReportField C2Toplam { get {return Body().C2Toplam;} }
            public TTReportField R6C3 { get {return Body().R6C3;} }
            public TTReportField R7C3 { get {return Body().R7C3;} }
            public TTReportField R8C3 { get {return Body().R8C3;} }
            public TTReportField R9C3 { get {return Body().R9C3;} }
            public TTReportField R10C3 { get {return Body().R10C3;} }
            public TTReportField R11C3 { get {return Body().R11C3;} }
            public TTReportField R12C3 { get {return Body().R12C3;} }
            public TTReportField R13C3 { get {return Body().R13C3;} }
            public TTReportField C3Toplam { get {return Body().C3Toplam;} }
            public TTReportField R6C4 { get {return Body().R6C4;} }
            public TTReportField R7C4 { get {return Body().R7C4;} }
            public TTReportField R8C4 { get {return Body().R8C4;} }
            public TTReportField R9C4 { get {return Body().R9C4;} }
            public TTReportField R10C4 { get {return Body().R10C4;} }
            public TTReportField R11C4 { get {return Body().R11C4;} }
            public TTReportField R12C4 { get {return Body().R12C4;} }
            public TTReportField R13C4 { get {return Body().R13C4;} }
            public TTReportField C4Toplam { get {return Body().C4Toplam;} }
            public TTReportField R6C5 { get {return Body().R6C5;} }
            public TTReportField R7C5 { get {return Body().R7C5;} }
            public TTReportField R8C5 { get {return Body().R8C5;} }
            public TTReportField R9C5 { get {return Body().R9C5;} }
            public TTReportField R10C5 { get {return Body().R10C5;} }
            public TTReportField R11C5 { get {return Body().R11C5;} }
            public TTReportField R12C5 { get {return Body().R12C5;} }
            public TTReportField R13C5 { get {return Body().R13C5;} }
            public TTReportField C5Toplam { get {return Body().C5Toplam;} }
            public TTReportField R6C6 { get {return Body().R6C6;} }
            public TTReportField R7C6 { get {return Body().R7C6;} }
            public TTReportField R8C6 { get {return Body().R8C6;} }
            public TTReportField R9C6 { get {return Body().R9C6;} }
            public TTReportField R10C6 { get {return Body().R10C6;} }
            public TTReportField R12C6 { get {return Body().R12C6;} }
            public TTReportField R13C6 { get {return Body().R13C6;} }
            public TTReportField C6Toplam { get {return Body().C6Toplam;} }
            public TTReportField R6C7 { get {return Body().R6C7;} }
            public TTReportField R7C7 { get {return Body().R7C7;} }
            public TTReportField R8C7 { get {return Body().R8C7;} }
            public TTReportField R9C7 { get {return Body().R9C7;} }
            public TTReportField R10C7 { get {return Body().R10C7;} }
            public TTReportField R12C7 { get {return Body().R12C7;} }
            public TTReportField R13C7 { get {return Body().R13C7;} }
            public TTReportField C7Toplam { get {return Body().C7Toplam;} }
            public TTReportField R6C10 { get {return Body().R6C10;} }
            public TTReportField R7C10 { get {return Body().R7C10;} }
            public TTReportField R8C10 { get {return Body().R8C10;} }
            public TTReportField R9C10 { get {return Body().R9C10;} }
            public TTReportField R10C10 { get {return Body().R10C10;} }
            public TTReportField R12C10 { get {return Body().R12C10;} }
            public TTReportField R13C10 { get {return Body().R13C10;} }
            public TTReportField C10Toplam { get {return Body().C10Toplam;} }
            public TTReportField R6C11 { get {return Body().R6C11;} }
            public TTReportField R7C11 { get {return Body().R7C11;} }
            public TTReportField R8C11 { get {return Body().R8C11;} }
            public TTReportField R9C11 { get {return Body().R9C11;} }
            public TTReportField R10C11 { get {return Body().R10C11;} }
            public TTReportField R12C11 { get {return Body().R12C11;} }
            public TTReportField R13C11 { get {return Body().R13C11;} }
            public TTReportField C11Toplam { get {return Body().C11Toplam;} }
            public TTReportField R6C12 { get {return Body().R6C12;} }
            public TTReportField R7C12 { get {return Body().R7C12;} }
            public TTReportField R8C12 { get {return Body().R8C12;} }
            public TTReportField R9C12 { get {return Body().R9C12;} }
            public TTReportField R10C12 { get {return Body().R10C12;} }
            public TTReportField R12C12 { get {return Body().R12C12;} }
            public TTReportField R13C12 { get {return Body().R13C12;} }
            public TTReportField C12Toplam { get {return Body().C12Toplam;} }
            public TTReportField R6C14 { get {return Body().R6C14;} }
            public TTReportField R7C14 { get {return Body().R7C14;} }
            public TTReportField R8C14 { get {return Body().R8C14;} }
            public TTReportField R9C14 { get {return Body().R9C14;} }
            public TTReportField R10C14 { get {return Body().R10C14;} }
            public TTReportField R12C14 { get {return Body().R12C14;} }
            public TTReportField R13C14 { get {return Body().R13C14;} }
            public TTReportField C14Toplam { get {return Body().C14Toplam;} }
            public TTReportField R6C15 { get {return Body().R6C15;} }
            public TTReportField R7C15 { get {return Body().R7C15;} }
            public TTReportField R8C15 { get {return Body().R8C15;} }
            public TTReportField R9C15 { get {return Body().R9C15;} }
            public TTReportField R10C15 { get {return Body().R10C15;} }
            public TTReportField R12C15 { get {return Body().R12C15;} }
            public TTReportField R13C15 { get {return Body().R13C15;} }
            public TTReportField C15Toplam { get {return Body().C15Toplam;} }
            public TTReportField R6C16 { get {return Body().R6C16;} }
            public TTReportField R7C16 { get {return Body().R7C16;} }
            public TTReportField R8C16 { get {return Body().R8C16;} }
            public TTReportField R9C16 { get {return Body().R9C16;} }
            public TTReportField R10C16 { get {return Body().R10C16;} }
            public TTReportField R12C16 { get {return Body().R12C16;} }
            public TTReportField R13C16 { get {return Body().R13C16;} }
            public TTReportField C16Toplam { get {return Body().C16Toplam;} }
            public TTReportField R6Toplam { get {return Body().R6Toplam;} }
            public TTReportField R7Toplam { get {return Body().R7Toplam;} }
            public TTReportField R8Toplam { get {return Body().R8Toplam;} }
            public TTReportField R9Toplam { get {return Body().R9Toplam;} }
            public TTReportField R10Toplam { get {return Body().R10Toplam;} }
            public TTReportField R12Toplam { get {return Body().R12Toplam;} }
            public TTReportField R13Toplam { get {return Body().R13Toplam;} }
            public TTReportField Toplam { get {return Body().Toplam;} }
            public TTReportField R6C8 { get {return Body().R6C8;} }
            public TTReportField R7C8 { get {return Body().R7C8;} }
            public TTReportField R8C8 { get {return Body().R8C8;} }
            public TTReportField R9C8 { get {return Body().R9C8;} }
            public TTReportField R10C8 { get {return Body().R10C8;} }
            public TTReportField R12C8 { get {return Body().R12C8;} }
            public TTReportField R13C8 { get {return Body().R13C8;} }
            public TTReportField C8Toplam { get {return Body().C8Toplam;} }
            public TTReportField R6C9 { get {return Body().R6C9;} }
            public TTReportField R7C9 { get {return Body().R7C9;} }
            public TTReportField R8C9 { get {return Body().R8C9;} }
            public TTReportField R9C9 { get {return Body().R9C9;} }
            public TTReportField R10C9 { get {return Body().R10C9;} }
            public TTReportField R11C9 { get {return Body().R11C9;} }
            public TTReportField R12C9 { get {return Body().R12C9;} }
            public TTReportField R13C9 { get {return Body().R13C9;} }
            public TTReportField C9Toplam { get {return Body().C9Toplam;} }
            public TTReportField NewField152141 { get {return Body().NewField152141;} }
            public TTReportField R0C13 { get {return Body().R0C13;} }
            public TTReportField R1C13 { get {return Body().R1C13;} }
            public TTReportField R2C13 { get {return Body().R2C13;} }
            public TTReportField R3C13 { get {return Body().R3C13;} }
            public TTReportField R4C13 { get {return Body().R4C13;} }
            public TTReportField R5C13 { get {return Body().R5C13;} }
            public TTReportField R6C13 { get {return Body().R6C13;} }
            public TTReportField R7C13 { get {return Body().R7C13;} }
            public TTReportField R8C13 { get {return Body().R8C13;} }
            public TTReportField R9C13 { get {return Body().R9C13;} }
            public TTReportField R10C13 { get {return Body().R10C13;} }
            public TTReportField R12C13 { get {return Body().R12C13;} }
            public TTReportField R13C13 { get {return Body().R13C13;} }
            public TTReportField C13Toplam { get {return Body().C13Toplam;} }
            public TTReportField R11C6 { get {return Body().R11C6;} }
            public TTReportField R11C7 { get {return Body().R11C7;} }
            public TTReportField R11C8 { get {return Body().R11C8;} }
            public TTReportField R11C10 { get {return Body().R11C10;} }
            public TTReportField R11C11 { get {return Body().R11C11;} }
            public TTReportField R11C12 { get {return Body().R11C12;} }
            public TTReportField R11C14 { get {return Body().R11C14;} }
            public TTReportField R11C15 { get {return Body().R11C15;} }
            public TTReportField R11C16 { get {return Body().R11C16;} }
            public TTReportField R11Toplam { get {return Body().R11Toplam;} }
            public TTReportField R11C13 { get {return Body().R11C13;} }
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
                public FaaliyetRaporu MyParentReport
                {
                    get { return (FaaliyetRaporu)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField1212;
                public TTReportField NewField1213;
                public TTReportField NewField1214;
                public TTReportField NewField14121;
                public TTReportField NewField14122;
                public TTReportField NewField14123;
                public TTReportField NewField14124;
                public TTReportField NewField14125;
                public TTReportField NewField14126;
                public TTReportField NewField14127;
                public TTReportField NewField14128;
                public TTReportField NewField14129;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField ASDASD;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField R0C0;
                public TTReportField R0C1;
                public TTReportField R0C2;
                public TTReportField R0C3;
                public TTReportField R0C4;
                public TTReportField R0C5;
                public TTReportField R0C6;
                public TTReportField R0C7;
                public TTReportField R0C8;
                public TTReportField R0C10;
                public TTReportField R0C11;
                public TTReportField R0C12;
                public TTReportField R0C14;
                public TTReportField R0C15;
                public TTReportField R0C16;
                public TTReportField R0Toplam;
                public TTReportField R0C9;
                public TTReportField R1C0;
                public TTReportField R1C1;
                public TTReportField R1C2;
                public TTReportField R1C3;
                public TTReportField R1C4;
                public TTReportField R1C5;
                public TTReportField R1C6;
                public TTReportField R1C7;
                public TTReportField R1C10;
                public TTReportField R1C11;
                public TTReportField R1C12;
                public TTReportField R1C14;
                public TTReportField R1C15;
                public TTReportField R1C16;
                public TTReportField R1Toplam;
                public TTReportField R1C8;
                public TTReportField R1C9;
                public TTReportField R2C0;
                public TTReportField R2C1;
                public TTReportField R2C2;
                public TTReportField R2C3;
                public TTReportField R2C4;
                public TTReportField R2C5;
                public TTReportField R2C6;
                public TTReportField R2C7;
                public TTReportField R2C8;
                public TTReportField R2C9;
                public TTReportField R2C10;
                public TTReportField R2C11;
                public TTReportField R2C12;
                public TTReportField R2C14;
                public TTReportField R2C15;
                public TTReportField R2C16;
                public TTReportField R2Toplam;
                public TTReportField R3C0;
                public TTReportField R3C1;
                public TTReportField R3C2;
                public TTReportField R3C3;
                public TTReportField R3C4;
                public TTReportField R3C5;
                public TTReportField R3C6;
                public TTReportField R3C7;
                public TTReportField R3C10;
                public TTReportField R3C11;
                public TTReportField R3C12;
                public TTReportField R3C14;
                public TTReportField R3C15;
                public TTReportField R3C16;
                public TTReportField R3Toplam;
                public TTReportField R3C8;
                public TTReportField R3C9;
                public TTReportField R4C0;
                public TTReportField R4C1;
                public TTReportField R4C2;
                public TTReportField R4C3;
                public TTReportField R4C4;
                public TTReportField R4C5;
                public TTReportField R4C6;
                public TTReportField R4C7;
                public TTReportField R4C10;
                public TTReportField R4C11;
                public TTReportField R4C8;
                public TTReportField R4C9;
                public TTReportField R4C12;
                public TTReportField R4C14;
                public TTReportField R4C15;
                public TTReportField R4C16;
                public TTReportField R4Toplam;
                public TTReportField R5C0;
                public TTReportField R5C1;
                public TTReportField R5C2;
                public TTReportField R5C3;
                public TTReportField R5C4;
                public TTReportField R5C5;
                public TTReportField R5C6;
                public TTReportField R5C7;
                public TTReportField R5C8;
                public TTReportField R5C9;
                public TTReportField R5C10;
                public TTReportField R5C11;
                public TTReportField R5C12;
                public TTReportField R5C14;
                public TTReportField R5C15;
                public TTReportField R5C16;
                public TTReportField R5Toplam;
                public TTReportField R6C0;
                public TTReportField R7C0;
                public TTReportField R8C0;
                public TTReportField R9C0;
                public TTReportField R10C0;
                public TTReportField R11C0;
                public TTReportField R12C0;
                public TTReportField R13C0;
                public TTReportField C0Toplam;
                public TTReportField R6C1;
                public TTReportField R7C1;
                public TTReportField R8C1;
                public TTReportField R9C1;
                public TTReportField R10C1;
                public TTReportField R11C1;
                public TTReportField R12C1;
                public TTReportField R13C1;
                public TTReportField C1Toplam;
                public TTReportField R6C2;
                public TTReportField R7C2;
                public TTReportField R8C2;
                public TTReportField R9C2;
                public TTReportField R10C2;
                public TTReportField R11C2;
                public TTReportField R12C2;
                public TTReportField R13C2;
                public TTReportField C2Toplam;
                public TTReportField R6C3;
                public TTReportField R7C3;
                public TTReportField R8C3;
                public TTReportField R9C3;
                public TTReportField R10C3;
                public TTReportField R11C3;
                public TTReportField R12C3;
                public TTReportField R13C3;
                public TTReportField C3Toplam;
                public TTReportField R6C4;
                public TTReportField R7C4;
                public TTReportField R8C4;
                public TTReportField R9C4;
                public TTReportField R10C4;
                public TTReportField R11C4;
                public TTReportField R12C4;
                public TTReportField R13C4;
                public TTReportField C4Toplam;
                public TTReportField R6C5;
                public TTReportField R7C5;
                public TTReportField R8C5;
                public TTReportField R9C5;
                public TTReportField R10C5;
                public TTReportField R11C5;
                public TTReportField R12C5;
                public TTReportField R13C5;
                public TTReportField C5Toplam;
                public TTReportField R6C6;
                public TTReportField R7C6;
                public TTReportField R8C6;
                public TTReportField R9C6;
                public TTReportField R10C6;
                public TTReportField R12C6;
                public TTReportField R13C6;
                public TTReportField C6Toplam;
                public TTReportField R6C7;
                public TTReportField R7C7;
                public TTReportField R8C7;
                public TTReportField R9C7;
                public TTReportField R10C7;
                public TTReportField R12C7;
                public TTReportField R13C7;
                public TTReportField C7Toplam;
                public TTReportField R6C10;
                public TTReportField R7C10;
                public TTReportField R8C10;
                public TTReportField R9C10;
                public TTReportField R10C10;
                public TTReportField R12C10;
                public TTReportField R13C10;
                public TTReportField C10Toplam;
                public TTReportField R6C11;
                public TTReportField R7C11;
                public TTReportField R8C11;
                public TTReportField R9C11;
                public TTReportField R10C11;
                public TTReportField R12C11;
                public TTReportField R13C11;
                public TTReportField C11Toplam;
                public TTReportField R6C12;
                public TTReportField R7C12;
                public TTReportField R8C12;
                public TTReportField R9C12;
                public TTReportField R10C12;
                public TTReportField R12C12;
                public TTReportField R13C12;
                public TTReportField C12Toplam;
                public TTReportField R6C14;
                public TTReportField R7C14;
                public TTReportField R8C14;
                public TTReportField R9C14;
                public TTReportField R10C14;
                public TTReportField R12C14;
                public TTReportField R13C14;
                public TTReportField C14Toplam;
                public TTReportField R6C15;
                public TTReportField R7C15;
                public TTReportField R8C15;
                public TTReportField R9C15;
                public TTReportField R10C15;
                public TTReportField R12C15;
                public TTReportField R13C15;
                public TTReportField C15Toplam;
                public TTReportField R6C16;
                public TTReportField R7C16;
                public TTReportField R8C16;
                public TTReportField R9C16;
                public TTReportField R10C16;
                public TTReportField R12C16;
                public TTReportField R13C16;
                public TTReportField C16Toplam;
                public TTReportField R6Toplam;
                public TTReportField R7Toplam;
                public TTReportField R8Toplam;
                public TTReportField R9Toplam;
                public TTReportField R10Toplam;
                public TTReportField R12Toplam;
                public TTReportField R13Toplam;
                public TTReportField Toplam;
                public TTReportField R6C8;
                public TTReportField R7C8;
                public TTReportField R8C8;
                public TTReportField R9C8;
                public TTReportField R10C8;
                public TTReportField R12C8;
                public TTReportField R13C8;
                public TTReportField C8Toplam;
                public TTReportField R6C9;
                public TTReportField R7C9;
                public TTReportField R8C9;
                public TTReportField R9C9;
                public TTReportField R10C9;
                public TTReportField R11C9;
                public TTReportField R12C9;
                public TTReportField R13C9;
                public TTReportField C9Toplam;
                public TTReportField NewField152141;
                public TTReportField R0C13;
                public TTReportField R1C13;
                public TTReportField R2C13;
                public TTReportField R3C13;
                public TTReportField R4C13;
                public TTReportField R5C13;
                public TTReportField R6C13;
                public TTReportField R7C13;
                public TTReportField R8C13;
                public TTReportField R9C13;
                public TTReportField R10C13;
                public TTReportField R12C13;
                public TTReportField R13C13;
                public TTReportField C13Toplam;
                public TTReportField R11C6;
                public TTReportField R11C7;
                public TTReportField R11C8;
                public TTReportField R11C10;
                public TTReportField R11C11;
                public TTReportField R11C12;
                public TTReportField R11C14;
                public TTReportField R11C15;
                public TTReportField R11C16;
                public TTReportField R11Toplam;
                public TTReportField R11C13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 130;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 22, 71, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"HASTAYLA PSİKOSOSYAL ÇALIŞMA";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 27, 71, 32, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"HASTA AİLESİ İLE PSİKOSOSYAL ÇALIŞMA";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 32, 71, 37, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.Value = @"SOSYAL İNCELEME VE DEĞERLENDİRME";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 37, 71, 42, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.Value = @"EV VE KURULUŞ ZİYARETİ";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 42, 71, 47, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.Value = @"İŞ YERİ ZİYARETİ";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 47, 71, 52, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.Value = @"OKUL ZİYARETİ";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 52, 71, 57, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.Value = @"KURUM BAKIMINA YERLEŞTİRME";

                    NewField1214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 57, 71, 62, false);
                    NewField1214.Name = "NewField1214";
                    NewField1214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214.Value = @"GEÇİCİ BAKIM MERKEZLERİNE YERLEŞTİRME";

                    NewField14121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 62, 71, 67, false);
                    NewField14121.Name = "NewField14121";
                    NewField14121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14121.Value = @"AYNİ VE NAKDİ YARDIM SAĞLAMA";

                    NewField14122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 67, 71, 76, false);
                    NewField14122.Name = "NewField14122";
                    NewField14122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14122.Value = @"TEDAVİ GİDERLERİ İÇİN KAYNAK BULMA VE
YÖNLENDİRME";

                    NewField14123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 76, 71, 81, false);
                    NewField14123.Name = "NewField14123";
                    NewField14123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14123.Value = @"HASTALARA GRUP ÇALIŞMASI";

                    NewField14124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 81, 71, 86, false);
                    NewField14124.Name = "NewField14124";
                    NewField14124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14124.Value = @"HASTA AİLESİ İLE GRUP ÇALIŞMASI";

                    NewField14125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 86, 71, 91, false);
                    NewField14125.Name = "NewField14125";
                    NewField14125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14125.Value = @"HASTA EĞİTİMİ VE UĞRAŞI ÇALIŞMASI";

                    NewField14126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 96, 71, 101, false);
                    NewField14126.Name = "NewField14126";
                    NewField14126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14126.Value = @"HASTA AİLESİNİN PSİKOSOSYAL EĞİTİMİ";

                    NewField14127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 101, 71, 106, false);
                    NewField14127.Name = "NewField14127";
                    NewField14127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14127.Value = @"SOSYAL ETKİNLİK";

                    NewField14128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 106, 71, 111, false);
                    NewField14128.Name = "NewField14128";
                    NewField14128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14128.Value = @"DİĞER MESLEKİ MÜDAHALELER";

                    NewField14129 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 111, 71, 116, false);
                    NewField14129.Name = "NewField14129";
                    NewField14129.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14129.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14129.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14129.TextFont.Bold = true;
                    NewField14129.TextFont.CharSet = 162;
                    NewField14129.Value = @"TOPLAM";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 3, 87, 22, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"KİMSESİZ
BAKIMA
MUHTAÇ
HASTA
";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 3, 101, 22, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"ÖZÜRLÜ
HASTA
";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 3, 112, 22, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"YAŞLI
HASTA
";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 3, 125, 22, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"YOKSUL
HASTA";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 3, 140, 22, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"SAĞLIK
GÜVEN.
OLMAYAN
HASTA
";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 3, 157, 22, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"AİLE İÇİ
ŞİDDETİ
MAĞDURU
HASTA
";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 3, 172, 22, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Size = 8;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"İHMAL
İSTİSMAR
ŞÜPHELİ
ÇOCUK";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 3, 189, 22, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.WordBreak = EvetHayirEnum.ehEvet;
                    NewField18.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField18.TextFont.Size = 8;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"SIĞINMACI
MÜLTECİ
YABANCI
UYRUKLU";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 3, 205, 22, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Size = 8;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"İNSAN
TİCARETİ
MAĞDURU
HASTA";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 3, 220, 22, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.MultiLine = EvetHayirEnum.ehEvet;
                    NewField20.WordBreak = EvetHayirEnum.ehEvet;
                    NewField20.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField20.TextFont.Size = 8;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"İL
DIŞINDAN
GELEN
HASTA";

                    ASDASD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 3, 235, 22, false);
                    ASDASD.Name = "ASDASD";
                    ASDASD.DrawStyle = DrawStyleConstants.vbSolid;
                    ASDASD.MultiLine = EvetHayirEnum.ehEvet;
                    ASDASD.WordBreak = EvetHayirEnum.ehEvet;
                    ASDASD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ASDASD.TextFont.Size = 8;
                    ASDASD.TextFont.CharSet = 162;
                    ASDASD.Value = @"GAZİ DUL
YETİM VE
ŞEHİT
YAKINI";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 3, 248, 22, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Size = 8;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"KRONİK
BAKIM
HASTASI";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 3, 263, 22, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Size = 8;
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @"ALKOL VE 
MADDE
BAĞIMLISI
HASTA";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 3, 275, 22, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Size = 8;
                    NewField23.TextFont.CharSet = 162;
                    NewField23.Value = @"DİĞER
HASTA";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 3, 291, 22, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Size = 8;
                    NewField24.TextFont.CharSet = 162;
                    NewField24.Value = @"TOPLAM";

                    R0C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 22, 87, 27, false);
                    R0C0.Name = "R0C0";
                    R0C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C0.MultiLine = EvetHayirEnum.ehEvet;
                    R0C0.WordBreak = EvetHayirEnum.ehEvet;
                    R0C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C0.Value = @"0";

                    R0C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 27, 87, 32, false);
                    R0C1.Name = "R0C1";
                    R0C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C1.MultiLine = EvetHayirEnum.ehEvet;
                    R0C1.WordBreak = EvetHayirEnum.ehEvet;
                    R0C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C1.Value = @"0";

                    R0C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 32, 87, 37, false);
                    R0C2.Name = "R0C2";
                    R0C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C2.MultiLine = EvetHayirEnum.ehEvet;
                    R0C2.WordBreak = EvetHayirEnum.ehEvet;
                    R0C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C2.Value = @"0";

                    R0C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 37, 87, 42, false);
                    R0C3.Name = "R0C3";
                    R0C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C3.MultiLine = EvetHayirEnum.ehEvet;
                    R0C3.WordBreak = EvetHayirEnum.ehEvet;
                    R0C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C3.Value = @"0";

                    R0C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 42, 87, 47, false);
                    R0C4.Name = "R0C4";
                    R0C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C4.MultiLine = EvetHayirEnum.ehEvet;
                    R0C4.WordBreak = EvetHayirEnum.ehEvet;
                    R0C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C4.Value = @"0";

                    R0C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 47, 87, 52, false);
                    R0C5.Name = "R0C5";
                    R0C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C5.MultiLine = EvetHayirEnum.ehEvet;
                    R0C5.WordBreak = EvetHayirEnum.ehEvet;
                    R0C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C5.Value = @"0";

                    R0C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 52, 87, 57, false);
                    R0C6.Name = "R0C6";
                    R0C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C6.MultiLine = EvetHayirEnum.ehEvet;
                    R0C6.WordBreak = EvetHayirEnum.ehEvet;
                    R0C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C6.Value = @"0";

                    R0C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 57, 87, 62, false);
                    R0C7.Name = "R0C7";
                    R0C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C7.MultiLine = EvetHayirEnum.ehEvet;
                    R0C7.WordBreak = EvetHayirEnum.ehEvet;
                    R0C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C7.Value = @"0";

                    R0C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 62, 87, 67, false);
                    R0C8.Name = "R0C8";
                    R0C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C8.MultiLine = EvetHayirEnum.ehEvet;
                    R0C8.WordBreak = EvetHayirEnum.ehEvet;
                    R0C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C8.Value = @"0";

                    R0C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 76, 87, 81, false);
                    R0C10.Name = "R0C10";
                    R0C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C10.MultiLine = EvetHayirEnum.ehEvet;
                    R0C10.WordBreak = EvetHayirEnum.ehEvet;
                    R0C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C10.Value = @"0";

                    R0C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 81, 87, 86, false);
                    R0C11.Name = "R0C11";
                    R0C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C11.MultiLine = EvetHayirEnum.ehEvet;
                    R0C11.WordBreak = EvetHayirEnum.ehEvet;
                    R0C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C11.Value = @"0";

                    R0C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 86, 87, 91, false);
                    R0C12.Name = "R0C12";
                    R0C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C12.MultiLine = EvetHayirEnum.ehEvet;
                    R0C12.WordBreak = EvetHayirEnum.ehEvet;
                    R0C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C12.Value = @"0";

                    R0C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 96, 87, 101, false);
                    R0C14.Name = "R0C14";
                    R0C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C14.MultiLine = EvetHayirEnum.ehEvet;
                    R0C14.WordBreak = EvetHayirEnum.ehEvet;
                    R0C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C14.Value = @"0";

                    R0C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 101, 87, 106, false);
                    R0C15.Name = "R0C15";
                    R0C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C15.MultiLine = EvetHayirEnum.ehEvet;
                    R0C15.WordBreak = EvetHayirEnum.ehEvet;
                    R0C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C15.Value = @"0";

                    R0C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 106, 87, 111, false);
                    R0C16.Name = "R0C16";
                    R0C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C16.MultiLine = EvetHayirEnum.ehEvet;
                    R0C16.WordBreak = EvetHayirEnum.ehEvet;
                    R0C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C16.Value = @"0";

                    R0Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 111, 87, 116, false);
                    R0Toplam.Name = "R0Toplam";
                    R0Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R0Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R0Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R0Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0Toplam.Value = @"0";

                    R0C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 67, 87, 76, false);
                    R0C9.Name = "R0C9";
                    R0C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C9.MultiLine = EvetHayirEnum.ehEvet;
                    R0C9.WordBreak = EvetHayirEnum.ehEvet;
                    R0C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C9.Value = @"0";

                    R1C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 22, 101, 27, false);
                    R1C0.Name = "R1C0";
                    R1C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C0.MultiLine = EvetHayirEnum.ehEvet;
                    R1C0.WordBreak = EvetHayirEnum.ehEvet;
                    R1C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C0.Value = @"0";

                    R1C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 27, 101, 32, false);
                    R1C1.Name = "R1C1";
                    R1C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C1.MultiLine = EvetHayirEnum.ehEvet;
                    R1C1.WordBreak = EvetHayirEnum.ehEvet;
                    R1C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C1.Value = @"0";

                    R1C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 32, 101, 37, false);
                    R1C2.Name = "R1C2";
                    R1C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C2.MultiLine = EvetHayirEnum.ehEvet;
                    R1C2.WordBreak = EvetHayirEnum.ehEvet;
                    R1C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C2.Value = @"0";

                    R1C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 37, 101, 42, false);
                    R1C3.Name = "R1C3";
                    R1C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C3.MultiLine = EvetHayirEnum.ehEvet;
                    R1C3.WordBreak = EvetHayirEnum.ehEvet;
                    R1C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C3.Value = @"0";

                    R1C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 42, 101, 47, false);
                    R1C4.Name = "R1C4";
                    R1C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C4.MultiLine = EvetHayirEnum.ehEvet;
                    R1C4.WordBreak = EvetHayirEnum.ehEvet;
                    R1C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C4.Value = @"0";

                    R1C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 47, 101, 52, false);
                    R1C5.Name = "R1C5";
                    R1C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C5.MultiLine = EvetHayirEnum.ehEvet;
                    R1C5.WordBreak = EvetHayirEnum.ehEvet;
                    R1C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C5.Value = @"0";

                    R1C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 52, 101, 57, false);
                    R1C6.Name = "R1C6";
                    R1C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C6.MultiLine = EvetHayirEnum.ehEvet;
                    R1C6.WordBreak = EvetHayirEnum.ehEvet;
                    R1C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C6.Value = @"0";

                    R1C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 57, 101, 62, false);
                    R1C7.Name = "R1C7";
                    R1C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C7.MultiLine = EvetHayirEnum.ehEvet;
                    R1C7.WordBreak = EvetHayirEnum.ehEvet;
                    R1C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C7.Value = @"0";

                    R1C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 76, 101, 81, false);
                    R1C10.Name = "R1C10";
                    R1C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C10.MultiLine = EvetHayirEnum.ehEvet;
                    R1C10.WordBreak = EvetHayirEnum.ehEvet;
                    R1C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C10.Value = @"0";

                    R1C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 81, 101, 86, false);
                    R1C11.Name = "R1C11";
                    R1C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C11.MultiLine = EvetHayirEnum.ehEvet;
                    R1C11.WordBreak = EvetHayirEnum.ehEvet;
                    R1C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C11.Value = @"0";

                    R1C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 86, 101, 91, false);
                    R1C12.Name = "R1C12";
                    R1C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C12.MultiLine = EvetHayirEnum.ehEvet;
                    R1C12.WordBreak = EvetHayirEnum.ehEvet;
                    R1C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C12.Value = @"0";

                    R1C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 96, 101, 101, false);
                    R1C14.Name = "R1C14";
                    R1C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C14.MultiLine = EvetHayirEnum.ehEvet;
                    R1C14.WordBreak = EvetHayirEnum.ehEvet;
                    R1C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C14.Value = @"0";

                    R1C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 101, 101, 106, false);
                    R1C15.Name = "R1C15";
                    R1C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C15.MultiLine = EvetHayirEnum.ehEvet;
                    R1C15.WordBreak = EvetHayirEnum.ehEvet;
                    R1C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C15.Value = @"0";

                    R1C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 106, 101, 111, false);
                    R1C16.Name = "R1C16";
                    R1C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C16.MultiLine = EvetHayirEnum.ehEvet;
                    R1C16.WordBreak = EvetHayirEnum.ehEvet;
                    R1C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C16.Value = @"0";

                    R1Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 111, 101, 116, false);
                    R1Toplam.Name = "R1Toplam";
                    R1Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R1Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R1Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R1Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1Toplam.Value = @"0";

                    R1C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 62, 101, 67, false);
                    R1C8.Name = "R1C8";
                    R1C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C8.MultiLine = EvetHayirEnum.ehEvet;
                    R1C8.WordBreak = EvetHayirEnum.ehEvet;
                    R1C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C8.Value = @"0";

                    R1C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 67, 101, 76, false);
                    R1C9.Name = "R1C9";
                    R1C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C9.MultiLine = EvetHayirEnum.ehEvet;
                    R1C9.WordBreak = EvetHayirEnum.ehEvet;
                    R1C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C9.Value = @"0";

                    R2C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 22, 112, 27, false);
                    R2C0.Name = "R2C0";
                    R2C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C0.MultiLine = EvetHayirEnum.ehEvet;
                    R2C0.WordBreak = EvetHayirEnum.ehEvet;
                    R2C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C0.Value = @"0";

                    R2C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 27, 112, 32, false);
                    R2C1.Name = "R2C1";
                    R2C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C1.MultiLine = EvetHayirEnum.ehEvet;
                    R2C1.WordBreak = EvetHayirEnum.ehEvet;
                    R2C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C1.Value = @"0";

                    R2C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 32, 112, 37, false);
                    R2C2.Name = "R2C2";
                    R2C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C2.MultiLine = EvetHayirEnum.ehEvet;
                    R2C2.WordBreak = EvetHayirEnum.ehEvet;
                    R2C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C2.Value = @"0";

                    R2C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 37, 112, 42, false);
                    R2C3.Name = "R2C3";
                    R2C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C3.MultiLine = EvetHayirEnum.ehEvet;
                    R2C3.WordBreak = EvetHayirEnum.ehEvet;
                    R2C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C3.Value = @"0";

                    R2C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 42, 112, 47, false);
                    R2C4.Name = "R2C4";
                    R2C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C4.MultiLine = EvetHayirEnum.ehEvet;
                    R2C4.WordBreak = EvetHayirEnum.ehEvet;
                    R2C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C4.Value = @"0";

                    R2C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 47, 112, 52, false);
                    R2C5.Name = "R2C5";
                    R2C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C5.MultiLine = EvetHayirEnum.ehEvet;
                    R2C5.WordBreak = EvetHayirEnum.ehEvet;
                    R2C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C5.Value = @"0";

                    R2C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 52, 112, 57, false);
                    R2C6.Name = "R2C6";
                    R2C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C6.MultiLine = EvetHayirEnum.ehEvet;
                    R2C6.WordBreak = EvetHayirEnum.ehEvet;
                    R2C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C6.Value = @"0";

                    R2C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 57, 112, 62, false);
                    R2C7.Name = "R2C7";
                    R2C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C7.MultiLine = EvetHayirEnum.ehEvet;
                    R2C7.WordBreak = EvetHayirEnum.ehEvet;
                    R2C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C7.Value = @"0";

                    R2C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 62, 112, 67, false);
                    R2C8.Name = "R2C8";
                    R2C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C8.MultiLine = EvetHayirEnum.ehEvet;
                    R2C8.WordBreak = EvetHayirEnum.ehEvet;
                    R2C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C8.Value = @"0";

                    R2C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 67, 112, 76, false);
                    R2C9.Name = "R2C9";
                    R2C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C9.MultiLine = EvetHayirEnum.ehEvet;
                    R2C9.WordBreak = EvetHayirEnum.ehEvet;
                    R2C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C9.Value = @"0";

                    R2C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 76, 112, 81, false);
                    R2C10.Name = "R2C10";
                    R2C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C10.MultiLine = EvetHayirEnum.ehEvet;
                    R2C10.WordBreak = EvetHayirEnum.ehEvet;
                    R2C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C10.Value = @"0";

                    R2C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 81, 112, 86, false);
                    R2C11.Name = "R2C11";
                    R2C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C11.MultiLine = EvetHayirEnum.ehEvet;
                    R2C11.WordBreak = EvetHayirEnum.ehEvet;
                    R2C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C11.Value = @"0";

                    R2C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 86, 112, 91, false);
                    R2C12.Name = "R2C12";
                    R2C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C12.MultiLine = EvetHayirEnum.ehEvet;
                    R2C12.WordBreak = EvetHayirEnum.ehEvet;
                    R2C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C12.Value = @"0";

                    R2C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 96, 112, 101, false);
                    R2C14.Name = "R2C14";
                    R2C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C14.MultiLine = EvetHayirEnum.ehEvet;
                    R2C14.WordBreak = EvetHayirEnum.ehEvet;
                    R2C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C14.Value = @"0";

                    R2C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 101, 112, 106, false);
                    R2C15.Name = "R2C15";
                    R2C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C15.MultiLine = EvetHayirEnum.ehEvet;
                    R2C15.WordBreak = EvetHayirEnum.ehEvet;
                    R2C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C15.Value = @"0";

                    R2C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 106, 112, 111, false);
                    R2C16.Name = "R2C16";
                    R2C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C16.MultiLine = EvetHayirEnum.ehEvet;
                    R2C16.WordBreak = EvetHayirEnum.ehEvet;
                    R2C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C16.Value = @"0";

                    R2Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 111, 112, 116, false);
                    R2Toplam.Name = "R2Toplam";
                    R2Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R2Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R2Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R2Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2Toplam.Value = @"0";

                    R3C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 22, 125, 27, false);
                    R3C0.Name = "R3C0";
                    R3C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C0.MultiLine = EvetHayirEnum.ehEvet;
                    R3C0.WordBreak = EvetHayirEnum.ehEvet;
                    R3C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C0.Value = @"0";

                    R3C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 27, 125, 32, false);
                    R3C1.Name = "R3C1";
                    R3C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C1.MultiLine = EvetHayirEnum.ehEvet;
                    R3C1.WordBreak = EvetHayirEnum.ehEvet;
                    R3C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C1.Value = @"0";

                    R3C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 32, 125, 37, false);
                    R3C2.Name = "R3C2";
                    R3C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C2.MultiLine = EvetHayirEnum.ehEvet;
                    R3C2.WordBreak = EvetHayirEnum.ehEvet;
                    R3C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C2.Value = @"0";

                    R3C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 37, 125, 42, false);
                    R3C3.Name = "R3C3";
                    R3C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C3.MultiLine = EvetHayirEnum.ehEvet;
                    R3C3.WordBreak = EvetHayirEnum.ehEvet;
                    R3C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C3.Value = @"0";

                    R3C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 42, 125, 47, false);
                    R3C4.Name = "R3C4";
                    R3C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C4.MultiLine = EvetHayirEnum.ehEvet;
                    R3C4.WordBreak = EvetHayirEnum.ehEvet;
                    R3C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C4.Value = @"0";

                    R3C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 47, 125, 52, false);
                    R3C5.Name = "R3C5";
                    R3C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C5.MultiLine = EvetHayirEnum.ehEvet;
                    R3C5.WordBreak = EvetHayirEnum.ehEvet;
                    R3C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C5.Value = @"0";

                    R3C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 52, 125, 57, false);
                    R3C6.Name = "R3C6";
                    R3C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C6.MultiLine = EvetHayirEnum.ehEvet;
                    R3C6.WordBreak = EvetHayirEnum.ehEvet;
                    R3C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C6.Value = @"0";

                    R3C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 57, 125, 62, false);
                    R3C7.Name = "R3C7";
                    R3C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C7.MultiLine = EvetHayirEnum.ehEvet;
                    R3C7.WordBreak = EvetHayirEnum.ehEvet;
                    R3C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C7.Value = @"0";

                    R3C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 76, 125, 81, false);
                    R3C10.Name = "R3C10";
                    R3C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C10.MultiLine = EvetHayirEnum.ehEvet;
                    R3C10.WordBreak = EvetHayirEnum.ehEvet;
                    R3C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C10.Value = @"0";

                    R3C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 81, 125, 86, false);
                    R3C11.Name = "R3C11";
                    R3C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C11.MultiLine = EvetHayirEnum.ehEvet;
                    R3C11.WordBreak = EvetHayirEnum.ehEvet;
                    R3C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C11.Value = @"0";

                    R3C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 86, 125, 91, false);
                    R3C12.Name = "R3C12";
                    R3C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C12.MultiLine = EvetHayirEnum.ehEvet;
                    R3C12.WordBreak = EvetHayirEnum.ehEvet;
                    R3C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C12.Value = @"0";

                    R3C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 96, 125, 101, false);
                    R3C14.Name = "R3C14";
                    R3C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C14.MultiLine = EvetHayirEnum.ehEvet;
                    R3C14.WordBreak = EvetHayirEnum.ehEvet;
                    R3C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C14.Value = @"0";

                    R3C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 101, 125, 106, false);
                    R3C15.Name = "R3C15";
                    R3C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C15.MultiLine = EvetHayirEnum.ehEvet;
                    R3C15.WordBreak = EvetHayirEnum.ehEvet;
                    R3C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C15.Value = @"0";

                    R3C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 106, 125, 111, false);
                    R3C16.Name = "R3C16";
                    R3C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C16.MultiLine = EvetHayirEnum.ehEvet;
                    R3C16.WordBreak = EvetHayirEnum.ehEvet;
                    R3C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C16.Value = @"0";

                    R3Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 111, 125, 116, false);
                    R3Toplam.Name = "R3Toplam";
                    R3Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R3Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R3Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R3Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3Toplam.Value = @"0";

                    R3C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 62, 125, 67, false);
                    R3C8.Name = "R3C8";
                    R3C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C8.MultiLine = EvetHayirEnum.ehEvet;
                    R3C8.WordBreak = EvetHayirEnum.ehEvet;
                    R3C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C8.Value = @"0";

                    R3C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 67, 125, 76, false);
                    R3C9.Name = "R3C9";
                    R3C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C9.MultiLine = EvetHayirEnum.ehEvet;
                    R3C9.WordBreak = EvetHayirEnum.ehEvet;
                    R3C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C9.Value = @"0";

                    R4C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 22, 140, 27, false);
                    R4C0.Name = "R4C0";
                    R4C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C0.MultiLine = EvetHayirEnum.ehEvet;
                    R4C0.WordBreak = EvetHayirEnum.ehEvet;
                    R4C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C0.Value = @"0";

                    R4C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 27, 140, 32, false);
                    R4C1.Name = "R4C1";
                    R4C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C1.MultiLine = EvetHayirEnum.ehEvet;
                    R4C1.WordBreak = EvetHayirEnum.ehEvet;
                    R4C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C1.Value = @"0";

                    R4C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 32, 140, 37, false);
                    R4C2.Name = "R4C2";
                    R4C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C2.MultiLine = EvetHayirEnum.ehEvet;
                    R4C2.WordBreak = EvetHayirEnum.ehEvet;
                    R4C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C2.Value = @"0";

                    R4C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 37, 140, 42, false);
                    R4C3.Name = "R4C3";
                    R4C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C3.MultiLine = EvetHayirEnum.ehEvet;
                    R4C3.WordBreak = EvetHayirEnum.ehEvet;
                    R4C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C3.Value = @"0";

                    R4C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 42, 140, 47, false);
                    R4C4.Name = "R4C4";
                    R4C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C4.MultiLine = EvetHayirEnum.ehEvet;
                    R4C4.WordBreak = EvetHayirEnum.ehEvet;
                    R4C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C4.Value = @"0";

                    R4C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 47, 140, 52, false);
                    R4C5.Name = "R4C5";
                    R4C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C5.MultiLine = EvetHayirEnum.ehEvet;
                    R4C5.WordBreak = EvetHayirEnum.ehEvet;
                    R4C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C5.Value = @"0";

                    R4C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 52, 140, 57, false);
                    R4C6.Name = "R4C6";
                    R4C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C6.MultiLine = EvetHayirEnum.ehEvet;
                    R4C6.WordBreak = EvetHayirEnum.ehEvet;
                    R4C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C6.Value = @"0";

                    R4C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 57, 140, 62, false);
                    R4C7.Name = "R4C7";
                    R4C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C7.MultiLine = EvetHayirEnum.ehEvet;
                    R4C7.WordBreak = EvetHayirEnum.ehEvet;
                    R4C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C7.Value = @"0";

                    R4C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 76, 140, 81, false);
                    R4C10.Name = "R4C10";
                    R4C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C10.MultiLine = EvetHayirEnum.ehEvet;
                    R4C10.WordBreak = EvetHayirEnum.ehEvet;
                    R4C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C10.Value = @"0";

                    R4C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 81, 140, 86, false);
                    R4C11.Name = "R4C11";
                    R4C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C11.MultiLine = EvetHayirEnum.ehEvet;
                    R4C11.WordBreak = EvetHayirEnum.ehEvet;
                    R4C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C11.Value = @"0";

                    R4C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 62, 140, 67, false);
                    R4C8.Name = "R4C8";
                    R4C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C8.MultiLine = EvetHayirEnum.ehEvet;
                    R4C8.WordBreak = EvetHayirEnum.ehEvet;
                    R4C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C8.Value = @"0";

                    R4C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 67, 140, 76, false);
                    R4C9.Name = "R4C9";
                    R4C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C9.MultiLine = EvetHayirEnum.ehEvet;
                    R4C9.WordBreak = EvetHayirEnum.ehEvet;
                    R4C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C9.Value = @"0";

                    R4C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 86, 140, 91, false);
                    R4C12.Name = "R4C12";
                    R4C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C12.MultiLine = EvetHayirEnum.ehEvet;
                    R4C12.WordBreak = EvetHayirEnum.ehEvet;
                    R4C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C12.Value = @"0";

                    R4C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 96, 140, 101, false);
                    R4C14.Name = "R4C14";
                    R4C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C14.MultiLine = EvetHayirEnum.ehEvet;
                    R4C14.WordBreak = EvetHayirEnum.ehEvet;
                    R4C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C14.Value = @"0";

                    R4C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 101, 140, 106, false);
                    R4C15.Name = "R4C15";
                    R4C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C15.MultiLine = EvetHayirEnum.ehEvet;
                    R4C15.WordBreak = EvetHayirEnum.ehEvet;
                    R4C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C15.Value = @"0";

                    R4C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 106, 140, 111, false);
                    R4C16.Name = "R4C16";
                    R4C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C16.MultiLine = EvetHayirEnum.ehEvet;
                    R4C16.WordBreak = EvetHayirEnum.ehEvet;
                    R4C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C16.Value = @"0";

                    R4Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 111, 140, 116, false);
                    R4Toplam.Name = "R4Toplam";
                    R4Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R4Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R4Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R4Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4Toplam.Value = @"0";

                    R5C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 22, 157, 27, false);
                    R5C0.Name = "R5C0";
                    R5C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C0.MultiLine = EvetHayirEnum.ehEvet;
                    R5C0.WordBreak = EvetHayirEnum.ehEvet;
                    R5C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C0.Value = @"0";

                    R5C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 27, 157, 32, false);
                    R5C1.Name = "R5C1";
                    R5C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C1.MultiLine = EvetHayirEnum.ehEvet;
                    R5C1.WordBreak = EvetHayirEnum.ehEvet;
                    R5C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C1.Value = @"0";

                    R5C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 32, 157, 37, false);
                    R5C2.Name = "R5C2";
                    R5C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C2.MultiLine = EvetHayirEnum.ehEvet;
                    R5C2.WordBreak = EvetHayirEnum.ehEvet;
                    R5C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C2.Value = @"0";

                    R5C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 37, 157, 42, false);
                    R5C3.Name = "R5C3";
                    R5C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C3.MultiLine = EvetHayirEnum.ehEvet;
                    R5C3.WordBreak = EvetHayirEnum.ehEvet;
                    R5C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C3.Value = @"0";

                    R5C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 42, 157, 47, false);
                    R5C4.Name = "R5C4";
                    R5C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C4.MultiLine = EvetHayirEnum.ehEvet;
                    R5C4.WordBreak = EvetHayirEnum.ehEvet;
                    R5C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C4.Value = @"0";

                    R5C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 47, 157, 52, false);
                    R5C5.Name = "R5C5";
                    R5C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C5.MultiLine = EvetHayirEnum.ehEvet;
                    R5C5.WordBreak = EvetHayirEnum.ehEvet;
                    R5C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C5.Value = @"0";

                    R5C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 52, 157, 57, false);
                    R5C6.Name = "R5C6";
                    R5C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C6.MultiLine = EvetHayirEnum.ehEvet;
                    R5C6.WordBreak = EvetHayirEnum.ehEvet;
                    R5C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C6.Value = @"0";

                    R5C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 57, 157, 62, false);
                    R5C7.Name = "R5C7";
                    R5C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C7.MultiLine = EvetHayirEnum.ehEvet;
                    R5C7.WordBreak = EvetHayirEnum.ehEvet;
                    R5C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C7.Value = @"0";

                    R5C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 62, 157, 67, false);
                    R5C8.Name = "R5C8";
                    R5C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C8.MultiLine = EvetHayirEnum.ehEvet;
                    R5C8.WordBreak = EvetHayirEnum.ehEvet;
                    R5C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C8.Value = @"0";

                    R5C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 67, 157, 76, false);
                    R5C9.Name = "R5C9";
                    R5C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C9.MultiLine = EvetHayirEnum.ehEvet;
                    R5C9.WordBreak = EvetHayirEnum.ehEvet;
                    R5C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C9.Value = @"0";

                    R5C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 76, 157, 81, false);
                    R5C10.Name = "R5C10";
                    R5C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C10.MultiLine = EvetHayirEnum.ehEvet;
                    R5C10.WordBreak = EvetHayirEnum.ehEvet;
                    R5C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C10.Value = @"0";

                    R5C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 81, 157, 86, false);
                    R5C11.Name = "R5C11";
                    R5C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C11.MultiLine = EvetHayirEnum.ehEvet;
                    R5C11.WordBreak = EvetHayirEnum.ehEvet;
                    R5C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C11.Value = @"0";

                    R5C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 86, 157, 91, false);
                    R5C12.Name = "R5C12";
                    R5C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C12.MultiLine = EvetHayirEnum.ehEvet;
                    R5C12.WordBreak = EvetHayirEnum.ehEvet;
                    R5C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C12.Value = @"0";

                    R5C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 96, 157, 101, false);
                    R5C14.Name = "R5C14";
                    R5C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C14.MultiLine = EvetHayirEnum.ehEvet;
                    R5C14.WordBreak = EvetHayirEnum.ehEvet;
                    R5C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C14.Value = @"0";

                    R5C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 101, 157, 106, false);
                    R5C15.Name = "R5C15";
                    R5C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C15.MultiLine = EvetHayirEnum.ehEvet;
                    R5C15.WordBreak = EvetHayirEnum.ehEvet;
                    R5C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C15.Value = @"0";

                    R5C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 106, 157, 111, false);
                    R5C16.Name = "R5C16";
                    R5C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C16.MultiLine = EvetHayirEnum.ehEvet;
                    R5C16.WordBreak = EvetHayirEnum.ehEvet;
                    R5C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C16.Value = @"0";

                    R5Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 111, 157, 116, false);
                    R5Toplam.Name = "R5Toplam";
                    R5Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R5Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R5Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R5Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5Toplam.Value = @"0";

                    R6C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 22, 172, 27, false);
                    R6C0.Name = "R6C0";
                    R6C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C0.MultiLine = EvetHayirEnum.ehEvet;
                    R6C0.WordBreak = EvetHayirEnum.ehEvet;
                    R6C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C0.Value = @"0";

                    R7C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 22, 189, 27, false);
                    R7C0.Name = "R7C0";
                    R7C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C0.MultiLine = EvetHayirEnum.ehEvet;
                    R7C0.WordBreak = EvetHayirEnum.ehEvet;
                    R7C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C0.Value = @"0";

                    R8C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 22, 205, 27, false);
                    R8C0.Name = "R8C0";
                    R8C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C0.MultiLine = EvetHayirEnum.ehEvet;
                    R8C0.WordBreak = EvetHayirEnum.ehEvet;
                    R8C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C0.Value = @"0";

                    R9C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 22, 220, 27, false);
                    R9C0.Name = "R9C0";
                    R9C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C0.MultiLine = EvetHayirEnum.ehEvet;
                    R9C0.WordBreak = EvetHayirEnum.ehEvet;
                    R9C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C0.Value = @"0";

                    R10C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 22, 235, 27, false);
                    R10C0.Name = "R10C0";
                    R10C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C0.MultiLine = EvetHayirEnum.ehEvet;
                    R10C0.WordBreak = EvetHayirEnum.ehEvet;
                    R10C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C0.Value = @"0";

                    R11C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 22, 248, 27, false);
                    R11C0.Name = "R11C0";
                    R11C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C0.MultiLine = EvetHayirEnum.ehEvet;
                    R11C0.WordBreak = EvetHayirEnum.ehEvet;
                    R11C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C0.Value = @"0";

                    R12C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 22, 263, 27, false);
                    R12C0.Name = "R12C0";
                    R12C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C0.MultiLine = EvetHayirEnum.ehEvet;
                    R12C0.WordBreak = EvetHayirEnum.ehEvet;
                    R12C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C0.Value = @"0";

                    R13C0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 22, 275, 27, false);
                    R13C0.Name = "R13C0";
                    R13C0.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C0.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C0.MultiLine = EvetHayirEnum.ehEvet;
                    R13C0.WordBreak = EvetHayirEnum.ehEvet;
                    R13C0.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C0.Value = @"0";

                    C0Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 22, 291, 27, false);
                    C0Toplam.Name = "C0Toplam";
                    C0Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C0Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C0Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C0Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C0Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C0Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C0Toplam.Value = @"0";

                    R6C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 27, 172, 32, false);
                    R6C1.Name = "R6C1";
                    R6C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C1.MultiLine = EvetHayirEnum.ehEvet;
                    R6C1.WordBreak = EvetHayirEnum.ehEvet;
                    R6C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C1.Value = @"0";

                    R7C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 27, 189, 32, false);
                    R7C1.Name = "R7C1";
                    R7C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C1.MultiLine = EvetHayirEnum.ehEvet;
                    R7C1.WordBreak = EvetHayirEnum.ehEvet;
                    R7C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C1.Value = @"0";

                    R8C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 27, 205, 32, false);
                    R8C1.Name = "R8C1";
                    R8C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C1.MultiLine = EvetHayirEnum.ehEvet;
                    R8C1.WordBreak = EvetHayirEnum.ehEvet;
                    R8C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C1.Value = @"0";

                    R9C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 27, 220, 32, false);
                    R9C1.Name = "R9C1";
                    R9C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C1.MultiLine = EvetHayirEnum.ehEvet;
                    R9C1.WordBreak = EvetHayirEnum.ehEvet;
                    R9C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C1.Value = @"0";

                    R10C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 27, 235, 32, false);
                    R10C1.Name = "R10C1";
                    R10C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C1.MultiLine = EvetHayirEnum.ehEvet;
                    R10C1.WordBreak = EvetHayirEnum.ehEvet;
                    R10C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C1.Value = @"0";

                    R11C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 27, 248, 32, false);
                    R11C1.Name = "R11C1";
                    R11C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C1.MultiLine = EvetHayirEnum.ehEvet;
                    R11C1.WordBreak = EvetHayirEnum.ehEvet;
                    R11C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C1.Value = @"0";

                    R12C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 27, 263, 32, false);
                    R12C1.Name = "R12C1";
                    R12C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C1.MultiLine = EvetHayirEnum.ehEvet;
                    R12C1.WordBreak = EvetHayirEnum.ehEvet;
                    R12C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C1.Value = @"0";

                    R13C1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 27, 275, 32, false);
                    R13C1.Name = "R13C1";
                    R13C1.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C1.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C1.MultiLine = EvetHayirEnum.ehEvet;
                    R13C1.WordBreak = EvetHayirEnum.ehEvet;
                    R13C1.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C1.Value = @"0";

                    C1Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 27, 291, 32, false);
                    C1Toplam.Name = "C1Toplam";
                    C1Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C1Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C1Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C1Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C1Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C1Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C1Toplam.Value = @"0";

                    R6C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 32, 172, 37, false);
                    R6C2.Name = "R6C2";
                    R6C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C2.MultiLine = EvetHayirEnum.ehEvet;
                    R6C2.WordBreak = EvetHayirEnum.ehEvet;
                    R6C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C2.Value = @"0";

                    R7C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 32, 189, 37, false);
                    R7C2.Name = "R7C2";
                    R7C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C2.MultiLine = EvetHayirEnum.ehEvet;
                    R7C2.WordBreak = EvetHayirEnum.ehEvet;
                    R7C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C2.Value = @"0";

                    R8C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 32, 205, 37, false);
                    R8C2.Name = "R8C2";
                    R8C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C2.MultiLine = EvetHayirEnum.ehEvet;
                    R8C2.WordBreak = EvetHayirEnum.ehEvet;
                    R8C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C2.Value = @"0";

                    R9C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 32, 220, 37, false);
                    R9C2.Name = "R9C2";
                    R9C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C2.MultiLine = EvetHayirEnum.ehEvet;
                    R9C2.WordBreak = EvetHayirEnum.ehEvet;
                    R9C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C2.Value = @"0";

                    R10C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 32, 235, 37, false);
                    R10C2.Name = "R10C2";
                    R10C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C2.MultiLine = EvetHayirEnum.ehEvet;
                    R10C2.WordBreak = EvetHayirEnum.ehEvet;
                    R10C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C2.Value = @"0";

                    R11C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 32, 248, 37, false);
                    R11C2.Name = "R11C2";
                    R11C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C2.MultiLine = EvetHayirEnum.ehEvet;
                    R11C2.WordBreak = EvetHayirEnum.ehEvet;
                    R11C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C2.Value = @"0";

                    R12C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 32, 263, 37, false);
                    R12C2.Name = "R12C2";
                    R12C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C2.MultiLine = EvetHayirEnum.ehEvet;
                    R12C2.WordBreak = EvetHayirEnum.ehEvet;
                    R12C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C2.Value = @"0";

                    R13C2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 32, 275, 37, false);
                    R13C2.Name = "R13C2";
                    R13C2.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C2.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C2.MultiLine = EvetHayirEnum.ehEvet;
                    R13C2.WordBreak = EvetHayirEnum.ehEvet;
                    R13C2.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C2.Value = @"0";

                    C2Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 32, 291, 37, false);
                    C2Toplam.Name = "C2Toplam";
                    C2Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C2Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C2Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C2Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C2Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C2Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C2Toplam.Value = @"0";

                    R6C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 37, 172, 42, false);
                    R6C3.Name = "R6C3";
                    R6C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C3.MultiLine = EvetHayirEnum.ehEvet;
                    R6C3.WordBreak = EvetHayirEnum.ehEvet;
                    R6C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C3.Value = @"0";

                    R7C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 37, 189, 42, false);
                    R7C3.Name = "R7C3";
                    R7C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C3.MultiLine = EvetHayirEnum.ehEvet;
                    R7C3.WordBreak = EvetHayirEnum.ehEvet;
                    R7C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C3.Value = @"0";

                    R8C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 37, 205, 42, false);
                    R8C3.Name = "R8C3";
                    R8C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C3.MultiLine = EvetHayirEnum.ehEvet;
                    R8C3.WordBreak = EvetHayirEnum.ehEvet;
                    R8C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C3.Value = @"0";

                    R9C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 37, 220, 42, false);
                    R9C3.Name = "R9C3";
                    R9C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C3.MultiLine = EvetHayirEnum.ehEvet;
                    R9C3.WordBreak = EvetHayirEnum.ehEvet;
                    R9C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C3.Value = @"0";

                    R10C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 37, 235, 42, false);
                    R10C3.Name = "R10C3";
                    R10C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C3.MultiLine = EvetHayirEnum.ehEvet;
                    R10C3.WordBreak = EvetHayirEnum.ehEvet;
                    R10C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C3.Value = @"0";

                    R11C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 37, 248, 42, false);
                    R11C3.Name = "R11C3";
                    R11C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C3.MultiLine = EvetHayirEnum.ehEvet;
                    R11C3.WordBreak = EvetHayirEnum.ehEvet;
                    R11C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C3.Value = @"0";

                    R12C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 37, 263, 42, false);
                    R12C3.Name = "R12C3";
                    R12C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C3.MultiLine = EvetHayirEnum.ehEvet;
                    R12C3.WordBreak = EvetHayirEnum.ehEvet;
                    R12C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C3.Value = @"0";

                    R13C3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 37, 275, 42, false);
                    R13C3.Name = "R13C3";
                    R13C3.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C3.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C3.MultiLine = EvetHayirEnum.ehEvet;
                    R13C3.WordBreak = EvetHayirEnum.ehEvet;
                    R13C3.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C3.Value = @"0";

                    C3Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 37, 291, 42, false);
                    C3Toplam.Name = "C3Toplam";
                    C3Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C3Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C3Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C3Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C3Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C3Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C3Toplam.Value = @"0";

                    R6C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 42, 172, 47, false);
                    R6C4.Name = "R6C4";
                    R6C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C4.MultiLine = EvetHayirEnum.ehEvet;
                    R6C4.WordBreak = EvetHayirEnum.ehEvet;
                    R6C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C4.Value = @"0";

                    R7C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 42, 189, 47, false);
                    R7C4.Name = "R7C4";
                    R7C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C4.MultiLine = EvetHayirEnum.ehEvet;
                    R7C4.WordBreak = EvetHayirEnum.ehEvet;
                    R7C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C4.Value = @"0";

                    R8C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 42, 205, 47, false);
                    R8C4.Name = "R8C4";
                    R8C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C4.MultiLine = EvetHayirEnum.ehEvet;
                    R8C4.WordBreak = EvetHayirEnum.ehEvet;
                    R8C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C4.Value = @"0";

                    R9C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 42, 220, 47, false);
                    R9C4.Name = "R9C4";
                    R9C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C4.MultiLine = EvetHayirEnum.ehEvet;
                    R9C4.WordBreak = EvetHayirEnum.ehEvet;
                    R9C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C4.Value = @"0";

                    R10C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 42, 235, 47, false);
                    R10C4.Name = "R10C4";
                    R10C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C4.MultiLine = EvetHayirEnum.ehEvet;
                    R10C4.WordBreak = EvetHayirEnum.ehEvet;
                    R10C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C4.Value = @"0";

                    R11C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 42, 248, 47, false);
                    R11C4.Name = "R11C4";
                    R11C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C4.MultiLine = EvetHayirEnum.ehEvet;
                    R11C4.WordBreak = EvetHayirEnum.ehEvet;
                    R11C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C4.Value = @"0";

                    R12C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 42, 263, 47, false);
                    R12C4.Name = "R12C4";
                    R12C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C4.MultiLine = EvetHayirEnum.ehEvet;
                    R12C4.WordBreak = EvetHayirEnum.ehEvet;
                    R12C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C4.Value = @"0";

                    R13C4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 42, 275, 47, false);
                    R13C4.Name = "R13C4";
                    R13C4.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C4.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C4.MultiLine = EvetHayirEnum.ehEvet;
                    R13C4.WordBreak = EvetHayirEnum.ehEvet;
                    R13C4.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C4.Value = @"0";

                    C4Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 42, 291, 47, false);
                    C4Toplam.Name = "C4Toplam";
                    C4Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C4Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C4Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C4Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C4Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C4Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C4Toplam.Value = @"0";

                    R6C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 47, 172, 52, false);
                    R6C5.Name = "R6C5";
                    R6C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C5.MultiLine = EvetHayirEnum.ehEvet;
                    R6C5.WordBreak = EvetHayirEnum.ehEvet;
                    R6C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C5.Value = @"0";

                    R7C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 47, 189, 52, false);
                    R7C5.Name = "R7C5";
                    R7C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C5.MultiLine = EvetHayirEnum.ehEvet;
                    R7C5.WordBreak = EvetHayirEnum.ehEvet;
                    R7C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C5.Value = @"0";

                    R8C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 47, 205, 52, false);
                    R8C5.Name = "R8C5";
                    R8C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C5.MultiLine = EvetHayirEnum.ehEvet;
                    R8C5.WordBreak = EvetHayirEnum.ehEvet;
                    R8C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C5.Value = @"0";

                    R9C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 47, 220, 52, false);
                    R9C5.Name = "R9C5";
                    R9C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C5.MultiLine = EvetHayirEnum.ehEvet;
                    R9C5.WordBreak = EvetHayirEnum.ehEvet;
                    R9C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C5.Value = @"0";

                    R10C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 47, 235, 52, false);
                    R10C5.Name = "R10C5";
                    R10C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C5.MultiLine = EvetHayirEnum.ehEvet;
                    R10C5.WordBreak = EvetHayirEnum.ehEvet;
                    R10C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C5.Value = @"0";

                    R11C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 47, 248, 52, false);
                    R11C5.Name = "R11C5";
                    R11C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C5.MultiLine = EvetHayirEnum.ehEvet;
                    R11C5.WordBreak = EvetHayirEnum.ehEvet;
                    R11C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C5.Value = @"0";

                    R12C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 47, 263, 52, false);
                    R12C5.Name = "R12C5";
                    R12C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C5.MultiLine = EvetHayirEnum.ehEvet;
                    R12C5.WordBreak = EvetHayirEnum.ehEvet;
                    R12C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C5.Value = @"0";

                    R13C5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 47, 275, 52, false);
                    R13C5.Name = "R13C5";
                    R13C5.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C5.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C5.MultiLine = EvetHayirEnum.ehEvet;
                    R13C5.WordBreak = EvetHayirEnum.ehEvet;
                    R13C5.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C5.Value = @"0";

                    C5Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 47, 291, 52, false);
                    C5Toplam.Name = "C5Toplam";
                    C5Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C5Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C5Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C5Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C5Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C5Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C5Toplam.Value = @"0";

                    R6C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 52, 172, 57, false);
                    R6C6.Name = "R6C6";
                    R6C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C6.MultiLine = EvetHayirEnum.ehEvet;
                    R6C6.WordBreak = EvetHayirEnum.ehEvet;
                    R6C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C6.Value = @"0";

                    R7C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 52, 189, 57, false);
                    R7C6.Name = "R7C6";
                    R7C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C6.MultiLine = EvetHayirEnum.ehEvet;
                    R7C6.WordBreak = EvetHayirEnum.ehEvet;
                    R7C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C6.Value = @"0";

                    R8C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 52, 205, 57, false);
                    R8C6.Name = "R8C6";
                    R8C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C6.MultiLine = EvetHayirEnum.ehEvet;
                    R8C6.WordBreak = EvetHayirEnum.ehEvet;
                    R8C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C6.Value = @"0";

                    R9C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 52, 220, 57, false);
                    R9C6.Name = "R9C6";
                    R9C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C6.MultiLine = EvetHayirEnum.ehEvet;
                    R9C6.WordBreak = EvetHayirEnum.ehEvet;
                    R9C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C6.Value = @"0";

                    R10C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 52, 235, 57, false);
                    R10C6.Name = "R10C6";
                    R10C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C6.MultiLine = EvetHayirEnum.ehEvet;
                    R10C6.WordBreak = EvetHayirEnum.ehEvet;
                    R10C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C6.Value = @"0";

                    R12C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 52, 263, 57, false);
                    R12C6.Name = "R12C6";
                    R12C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C6.MultiLine = EvetHayirEnum.ehEvet;
                    R12C6.WordBreak = EvetHayirEnum.ehEvet;
                    R12C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C6.Value = @"0";

                    R13C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 52, 275, 57, false);
                    R13C6.Name = "R13C6";
                    R13C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C6.MultiLine = EvetHayirEnum.ehEvet;
                    R13C6.WordBreak = EvetHayirEnum.ehEvet;
                    R13C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C6.Value = @"0";

                    C6Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 52, 291, 57, false);
                    C6Toplam.Name = "C6Toplam";
                    C6Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C6Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C6Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C6Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C6Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C6Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C6Toplam.Value = @"0";

                    R6C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 57, 172, 62, false);
                    R6C7.Name = "R6C7";
                    R6C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C7.MultiLine = EvetHayirEnum.ehEvet;
                    R6C7.WordBreak = EvetHayirEnum.ehEvet;
                    R6C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C7.Value = @"0";

                    R7C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 57, 189, 62, false);
                    R7C7.Name = "R7C7";
                    R7C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C7.MultiLine = EvetHayirEnum.ehEvet;
                    R7C7.WordBreak = EvetHayirEnum.ehEvet;
                    R7C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C7.Value = @"0";

                    R8C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 57, 205, 62, false);
                    R8C7.Name = "R8C7";
                    R8C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C7.MultiLine = EvetHayirEnum.ehEvet;
                    R8C7.WordBreak = EvetHayirEnum.ehEvet;
                    R8C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C7.Value = @"0";

                    R9C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 57, 220, 62, false);
                    R9C7.Name = "R9C7";
                    R9C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C7.MultiLine = EvetHayirEnum.ehEvet;
                    R9C7.WordBreak = EvetHayirEnum.ehEvet;
                    R9C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C7.Value = @"0";

                    R10C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 57, 235, 62, false);
                    R10C7.Name = "R10C7";
                    R10C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C7.MultiLine = EvetHayirEnum.ehEvet;
                    R10C7.WordBreak = EvetHayirEnum.ehEvet;
                    R10C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C7.Value = @"0";

                    R12C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 57, 263, 62, false);
                    R12C7.Name = "R12C7";
                    R12C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C7.MultiLine = EvetHayirEnum.ehEvet;
                    R12C7.WordBreak = EvetHayirEnum.ehEvet;
                    R12C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C7.Value = @"0";

                    R13C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 57, 275, 62, false);
                    R13C7.Name = "R13C7";
                    R13C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C7.MultiLine = EvetHayirEnum.ehEvet;
                    R13C7.WordBreak = EvetHayirEnum.ehEvet;
                    R13C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C7.Value = @"0";

                    C7Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 57, 291, 62, false);
                    C7Toplam.Name = "C7Toplam";
                    C7Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C7Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C7Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C7Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C7Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C7Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C7Toplam.Value = @"0";

                    R6C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 76, 172, 81, false);
                    R6C10.Name = "R6C10";
                    R6C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C10.MultiLine = EvetHayirEnum.ehEvet;
                    R6C10.WordBreak = EvetHayirEnum.ehEvet;
                    R6C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C10.Value = @"0";

                    R7C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 76, 189, 81, false);
                    R7C10.Name = "R7C10";
                    R7C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C10.MultiLine = EvetHayirEnum.ehEvet;
                    R7C10.WordBreak = EvetHayirEnum.ehEvet;
                    R7C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C10.Value = @"0";

                    R8C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 76, 205, 81, false);
                    R8C10.Name = "R8C10";
                    R8C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C10.MultiLine = EvetHayirEnum.ehEvet;
                    R8C10.WordBreak = EvetHayirEnum.ehEvet;
                    R8C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C10.Value = @"0";

                    R9C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 76, 220, 81, false);
                    R9C10.Name = "R9C10";
                    R9C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C10.MultiLine = EvetHayirEnum.ehEvet;
                    R9C10.WordBreak = EvetHayirEnum.ehEvet;
                    R9C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C10.Value = @"0";

                    R10C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 76, 235, 81, false);
                    R10C10.Name = "R10C10";
                    R10C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C10.MultiLine = EvetHayirEnum.ehEvet;
                    R10C10.WordBreak = EvetHayirEnum.ehEvet;
                    R10C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C10.Value = @"0";

                    R12C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 76, 263, 81, false);
                    R12C10.Name = "R12C10";
                    R12C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C10.MultiLine = EvetHayirEnum.ehEvet;
                    R12C10.WordBreak = EvetHayirEnum.ehEvet;
                    R12C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C10.Value = @"0";

                    R13C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 76, 275, 81, false);
                    R13C10.Name = "R13C10";
                    R13C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C10.MultiLine = EvetHayirEnum.ehEvet;
                    R13C10.WordBreak = EvetHayirEnum.ehEvet;
                    R13C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C10.Value = @"0";

                    C10Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 76, 291, 81, false);
                    C10Toplam.Name = "C10Toplam";
                    C10Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C10Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C10Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C10Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C10Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C10Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C10Toplam.Value = @"0";

                    R6C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 81, 172, 86, false);
                    R6C11.Name = "R6C11";
                    R6C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C11.MultiLine = EvetHayirEnum.ehEvet;
                    R6C11.WordBreak = EvetHayirEnum.ehEvet;
                    R6C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C11.Value = @"0";

                    R7C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 81, 189, 86, false);
                    R7C11.Name = "R7C11";
                    R7C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C11.MultiLine = EvetHayirEnum.ehEvet;
                    R7C11.WordBreak = EvetHayirEnum.ehEvet;
                    R7C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C11.Value = @"0";

                    R8C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 81, 205, 86, false);
                    R8C11.Name = "R8C11";
                    R8C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C11.MultiLine = EvetHayirEnum.ehEvet;
                    R8C11.WordBreak = EvetHayirEnum.ehEvet;
                    R8C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C11.Value = @"0";

                    R9C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 81, 220, 86, false);
                    R9C11.Name = "R9C11";
                    R9C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C11.MultiLine = EvetHayirEnum.ehEvet;
                    R9C11.WordBreak = EvetHayirEnum.ehEvet;
                    R9C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C11.Value = @"0";

                    R10C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 81, 235, 86, false);
                    R10C11.Name = "R10C11";
                    R10C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C11.MultiLine = EvetHayirEnum.ehEvet;
                    R10C11.WordBreak = EvetHayirEnum.ehEvet;
                    R10C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C11.Value = @"0";

                    R12C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 81, 263, 86, false);
                    R12C11.Name = "R12C11";
                    R12C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C11.MultiLine = EvetHayirEnum.ehEvet;
                    R12C11.WordBreak = EvetHayirEnum.ehEvet;
                    R12C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C11.Value = @"0";

                    R13C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 81, 275, 86, false);
                    R13C11.Name = "R13C11";
                    R13C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C11.MultiLine = EvetHayirEnum.ehEvet;
                    R13C11.WordBreak = EvetHayirEnum.ehEvet;
                    R13C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C11.Value = @"0";

                    C11Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 81, 291, 86, false);
                    C11Toplam.Name = "C11Toplam";
                    C11Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C11Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C11Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C11Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C11Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C11Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C11Toplam.Value = @"0";

                    R6C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 86, 172, 91, false);
                    R6C12.Name = "R6C12";
                    R6C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C12.MultiLine = EvetHayirEnum.ehEvet;
                    R6C12.WordBreak = EvetHayirEnum.ehEvet;
                    R6C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C12.Value = @"0";

                    R7C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 86, 189, 91, false);
                    R7C12.Name = "R7C12";
                    R7C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C12.MultiLine = EvetHayirEnum.ehEvet;
                    R7C12.WordBreak = EvetHayirEnum.ehEvet;
                    R7C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C12.Value = @"0";

                    R8C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 86, 205, 91, false);
                    R8C12.Name = "R8C12";
                    R8C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C12.MultiLine = EvetHayirEnum.ehEvet;
                    R8C12.WordBreak = EvetHayirEnum.ehEvet;
                    R8C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C12.Value = @"0";

                    R9C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 86, 220, 91, false);
                    R9C12.Name = "R9C12";
                    R9C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C12.MultiLine = EvetHayirEnum.ehEvet;
                    R9C12.WordBreak = EvetHayirEnum.ehEvet;
                    R9C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C12.Value = @"0";

                    R10C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 86, 235, 91, false);
                    R10C12.Name = "R10C12";
                    R10C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C12.MultiLine = EvetHayirEnum.ehEvet;
                    R10C12.WordBreak = EvetHayirEnum.ehEvet;
                    R10C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C12.Value = @"0";

                    R12C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 86, 263, 91, false);
                    R12C12.Name = "R12C12";
                    R12C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C12.MultiLine = EvetHayirEnum.ehEvet;
                    R12C12.WordBreak = EvetHayirEnum.ehEvet;
                    R12C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C12.Value = @"0";

                    R13C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 86, 275, 91, false);
                    R13C12.Name = "R13C12";
                    R13C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C12.MultiLine = EvetHayirEnum.ehEvet;
                    R13C12.WordBreak = EvetHayirEnum.ehEvet;
                    R13C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C12.Value = @"0";

                    C12Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 86, 291, 91, false);
                    C12Toplam.Name = "C12Toplam";
                    C12Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C12Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C12Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C12Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C12Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C12Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C12Toplam.Value = @"0";

                    R6C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 96, 172, 101, false);
                    R6C14.Name = "R6C14";
                    R6C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C14.MultiLine = EvetHayirEnum.ehEvet;
                    R6C14.WordBreak = EvetHayirEnum.ehEvet;
                    R6C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C14.Value = @"0";

                    R7C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 96, 189, 101, false);
                    R7C14.Name = "R7C14";
                    R7C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C14.MultiLine = EvetHayirEnum.ehEvet;
                    R7C14.WordBreak = EvetHayirEnum.ehEvet;
                    R7C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C14.Value = @"0";

                    R8C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 96, 205, 101, false);
                    R8C14.Name = "R8C14";
                    R8C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C14.MultiLine = EvetHayirEnum.ehEvet;
                    R8C14.WordBreak = EvetHayirEnum.ehEvet;
                    R8C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C14.Value = @"0";

                    R9C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 96, 220, 101, false);
                    R9C14.Name = "R9C14";
                    R9C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C14.MultiLine = EvetHayirEnum.ehEvet;
                    R9C14.WordBreak = EvetHayirEnum.ehEvet;
                    R9C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C14.Value = @"0";

                    R10C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 96, 235, 101, false);
                    R10C14.Name = "R10C14";
                    R10C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C14.MultiLine = EvetHayirEnum.ehEvet;
                    R10C14.WordBreak = EvetHayirEnum.ehEvet;
                    R10C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C14.Value = @"0";

                    R12C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 96, 263, 101, false);
                    R12C14.Name = "R12C14";
                    R12C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C14.MultiLine = EvetHayirEnum.ehEvet;
                    R12C14.WordBreak = EvetHayirEnum.ehEvet;
                    R12C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C14.Value = @"0";

                    R13C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 96, 275, 101, false);
                    R13C14.Name = "R13C14";
                    R13C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C14.MultiLine = EvetHayirEnum.ehEvet;
                    R13C14.WordBreak = EvetHayirEnum.ehEvet;
                    R13C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C14.Value = @"0";

                    C14Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 96, 291, 101, false);
                    C14Toplam.Name = "C14Toplam";
                    C14Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C14Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C14Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C14Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C14Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C14Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C14Toplam.Value = @"0";

                    R6C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 101, 172, 106, false);
                    R6C15.Name = "R6C15";
                    R6C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C15.MultiLine = EvetHayirEnum.ehEvet;
                    R6C15.WordBreak = EvetHayirEnum.ehEvet;
                    R6C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C15.Value = @"0";

                    R7C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 101, 189, 106, false);
                    R7C15.Name = "R7C15";
                    R7C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C15.MultiLine = EvetHayirEnum.ehEvet;
                    R7C15.WordBreak = EvetHayirEnum.ehEvet;
                    R7C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C15.Value = @"0";

                    R8C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 101, 205, 106, false);
                    R8C15.Name = "R8C15";
                    R8C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C15.MultiLine = EvetHayirEnum.ehEvet;
                    R8C15.WordBreak = EvetHayirEnum.ehEvet;
                    R8C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C15.Value = @"0";

                    R9C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 101, 220, 106, false);
                    R9C15.Name = "R9C15";
                    R9C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C15.MultiLine = EvetHayirEnum.ehEvet;
                    R9C15.WordBreak = EvetHayirEnum.ehEvet;
                    R9C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C15.Value = @"0";

                    R10C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 101, 235, 106, false);
                    R10C15.Name = "R10C15";
                    R10C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C15.MultiLine = EvetHayirEnum.ehEvet;
                    R10C15.WordBreak = EvetHayirEnum.ehEvet;
                    R10C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C15.Value = @"0";

                    R12C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 101, 263, 106, false);
                    R12C15.Name = "R12C15";
                    R12C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C15.MultiLine = EvetHayirEnum.ehEvet;
                    R12C15.WordBreak = EvetHayirEnum.ehEvet;
                    R12C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C15.Value = @"0";

                    R13C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 101, 275, 106, false);
                    R13C15.Name = "R13C15";
                    R13C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C15.MultiLine = EvetHayirEnum.ehEvet;
                    R13C15.WordBreak = EvetHayirEnum.ehEvet;
                    R13C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C15.Value = @"0";

                    C15Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 101, 291, 106, false);
                    C15Toplam.Name = "C15Toplam";
                    C15Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C15Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C15Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C15Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C15Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C15Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C15Toplam.Value = @"0";

                    R6C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 106, 172, 111, false);
                    R6C16.Name = "R6C16";
                    R6C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C16.MultiLine = EvetHayirEnum.ehEvet;
                    R6C16.WordBreak = EvetHayirEnum.ehEvet;
                    R6C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C16.Value = @"0";

                    R7C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 106, 189, 111, false);
                    R7C16.Name = "R7C16";
                    R7C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C16.MultiLine = EvetHayirEnum.ehEvet;
                    R7C16.WordBreak = EvetHayirEnum.ehEvet;
                    R7C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C16.Value = @"0";

                    R8C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 106, 205, 111, false);
                    R8C16.Name = "R8C16";
                    R8C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C16.MultiLine = EvetHayirEnum.ehEvet;
                    R8C16.WordBreak = EvetHayirEnum.ehEvet;
                    R8C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C16.Value = @"0";

                    R9C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 106, 220, 111, false);
                    R9C16.Name = "R9C16";
                    R9C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C16.MultiLine = EvetHayirEnum.ehEvet;
                    R9C16.WordBreak = EvetHayirEnum.ehEvet;
                    R9C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C16.Value = @"0";

                    R10C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 106, 235, 111, false);
                    R10C16.Name = "R10C16";
                    R10C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C16.MultiLine = EvetHayirEnum.ehEvet;
                    R10C16.WordBreak = EvetHayirEnum.ehEvet;
                    R10C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C16.Value = @"0";

                    R12C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 106, 263, 111, false);
                    R12C16.Name = "R12C16";
                    R12C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C16.MultiLine = EvetHayirEnum.ehEvet;
                    R12C16.WordBreak = EvetHayirEnum.ehEvet;
                    R12C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C16.Value = @"0";

                    R13C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 106, 275, 111, false);
                    R13C16.Name = "R13C16";
                    R13C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C16.MultiLine = EvetHayirEnum.ehEvet;
                    R13C16.WordBreak = EvetHayirEnum.ehEvet;
                    R13C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C16.Value = @"0";

                    C16Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 106, 291, 111, false);
                    C16Toplam.Name = "C16Toplam";
                    C16Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C16Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C16Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C16Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C16Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C16Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C16Toplam.Value = @"0";

                    R6Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 111, 172, 116, false);
                    R6Toplam.Name = "R6Toplam";
                    R6Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R6Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R6Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R6Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6Toplam.Value = @"0";

                    R7Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 111, 189, 116, false);
                    R7Toplam.Name = "R7Toplam";
                    R7Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R7Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R7Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R7Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7Toplam.Value = @"0";

                    R8Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 111, 205, 116, false);
                    R8Toplam.Name = "R8Toplam";
                    R8Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R8Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R8Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R8Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8Toplam.Value = @"0";

                    R9Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 111, 220, 116, false);
                    R9Toplam.Name = "R9Toplam";
                    R9Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R9Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R9Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R9Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9Toplam.Value = @"0";

                    R10Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 111, 235, 116, false);
                    R10Toplam.Name = "R10Toplam";
                    R10Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R10Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R10Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R10Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10Toplam.Value = @"0";

                    R12Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 111, 263, 116, false);
                    R12Toplam.Name = "R12Toplam";
                    R12Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R12Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R12Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R12Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12Toplam.Value = @"0";

                    R13Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 111, 275, 116, false);
                    R13Toplam.Name = "R13Toplam";
                    R13Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R13Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R13Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R13Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13Toplam.Value = @"0";

                    Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 111, 291, 116, false);
                    Toplam.Name = "Toplam";
                    Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    Toplam.Value = @"0";

                    R6C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 62, 172, 67, false);
                    R6C8.Name = "R6C8";
                    R6C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C8.MultiLine = EvetHayirEnum.ehEvet;
                    R6C8.WordBreak = EvetHayirEnum.ehEvet;
                    R6C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C8.Value = @"0";

                    R7C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 62, 189, 67, false);
                    R7C8.Name = "R7C8";
                    R7C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C8.MultiLine = EvetHayirEnum.ehEvet;
                    R7C8.WordBreak = EvetHayirEnum.ehEvet;
                    R7C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C8.Value = @"0";

                    R8C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 62, 205, 67, false);
                    R8C8.Name = "R8C8";
                    R8C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C8.MultiLine = EvetHayirEnum.ehEvet;
                    R8C8.WordBreak = EvetHayirEnum.ehEvet;
                    R8C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C8.Value = @"0";

                    R9C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 62, 220, 67, false);
                    R9C8.Name = "R9C8";
                    R9C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C8.MultiLine = EvetHayirEnum.ehEvet;
                    R9C8.WordBreak = EvetHayirEnum.ehEvet;
                    R9C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C8.Value = @"0";

                    R10C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 62, 235, 67, false);
                    R10C8.Name = "R10C8";
                    R10C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C8.MultiLine = EvetHayirEnum.ehEvet;
                    R10C8.WordBreak = EvetHayirEnum.ehEvet;
                    R10C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C8.Value = @"0";

                    R12C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 62, 263, 67, false);
                    R12C8.Name = "R12C8";
                    R12C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C8.MultiLine = EvetHayirEnum.ehEvet;
                    R12C8.WordBreak = EvetHayirEnum.ehEvet;
                    R12C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C8.Value = @"0";

                    R13C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 62, 275, 67, false);
                    R13C8.Name = "R13C8";
                    R13C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C8.MultiLine = EvetHayirEnum.ehEvet;
                    R13C8.WordBreak = EvetHayirEnum.ehEvet;
                    R13C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C8.Value = @"0";

                    C8Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 62, 291, 67, false);
                    C8Toplam.Name = "C8Toplam";
                    C8Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C8Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C8Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C8Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C8Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C8Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C8Toplam.Value = @"0";

                    R6C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 67, 172, 76, false);
                    R6C9.Name = "R6C9";
                    R6C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C9.MultiLine = EvetHayirEnum.ehEvet;
                    R6C9.WordBreak = EvetHayirEnum.ehEvet;
                    R6C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C9.Value = @"0";

                    R7C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 67, 189, 76, false);
                    R7C9.Name = "R7C9";
                    R7C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C9.MultiLine = EvetHayirEnum.ehEvet;
                    R7C9.WordBreak = EvetHayirEnum.ehEvet;
                    R7C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C9.Value = @"0";

                    R8C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 67, 205, 76, false);
                    R8C9.Name = "R8C9";
                    R8C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C9.MultiLine = EvetHayirEnum.ehEvet;
                    R8C9.WordBreak = EvetHayirEnum.ehEvet;
                    R8C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C9.Value = @"0";

                    R9C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 67, 220, 76, false);
                    R9C9.Name = "R9C9";
                    R9C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C9.MultiLine = EvetHayirEnum.ehEvet;
                    R9C9.WordBreak = EvetHayirEnum.ehEvet;
                    R9C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C9.Value = @"0";

                    R10C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 67, 235, 76, false);
                    R10C9.Name = "R10C9";
                    R10C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C9.MultiLine = EvetHayirEnum.ehEvet;
                    R10C9.WordBreak = EvetHayirEnum.ehEvet;
                    R10C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C9.Value = @"0";

                    R11C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 67, 248, 76, false);
                    R11C9.Name = "R11C9";
                    R11C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C9.MultiLine = EvetHayirEnum.ehEvet;
                    R11C9.WordBreak = EvetHayirEnum.ehEvet;
                    R11C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C9.Value = @"0";

                    R12C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 67, 263, 76, false);
                    R12C9.Name = "R12C9";
                    R12C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C9.MultiLine = EvetHayirEnum.ehEvet;
                    R12C9.WordBreak = EvetHayirEnum.ehEvet;
                    R12C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C9.Value = @"0";

                    R13C9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 67, 275, 76, false);
                    R13C9.Name = "R13C9";
                    R13C9.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C9.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C9.MultiLine = EvetHayirEnum.ehEvet;
                    R13C9.WordBreak = EvetHayirEnum.ehEvet;
                    R13C9.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C9.Value = @"0";

                    C9Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 67, 291, 76, false);
                    C9Toplam.Name = "C9Toplam";
                    C9Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C9Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C9Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C9Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C9Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C9Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C9Toplam.Value = @"0";

                    NewField152141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 91, 71, 96, false);
                    NewField152141.Name = "NewField152141";
                    NewField152141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152141.Value = @"HASTA NAKİL HİZMETİ";

                    R0C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 91, 87, 96, false);
                    R0C13.Name = "R0C13";
                    R0C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R0C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R0C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R0C13.MultiLine = EvetHayirEnum.ehEvet;
                    R0C13.WordBreak = EvetHayirEnum.ehEvet;
                    R0C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R0C13.Value = @"0";

                    R1C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 91, 101, 96, false);
                    R1C13.Name = "R1C13";
                    R1C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R1C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R1C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R1C13.MultiLine = EvetHayirEnum.ehEvet;
                    R1C13.WordBreak = EvetHayirEnum.ehEvet;
                    R1C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R1C13.Value = @"0";

                    R2C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 91, 112, 96, false);
                    R2C13.Name = "R2C13";
                    R2C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R2C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R2C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R2C13.MultiLine = EvetHayirEnum.ehEvet;
                    R2C13.WordBreak = EvetHayirEnum.ehEvet;
                    R2C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R2C13.Value = @"0";

                    R3C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 91, 125, 96, false);
                    R3C13.Name = "R3C13";
                    R3C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R3C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R3C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R3C13.MultiLine = EvetHayirEnum.ehEvet;
                    R3C13.WordBreak = EvetHayirEnum.ehEvet;
                    R3C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R3C13.Value = @"0";

                    R4C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 91, 140, 96, false);
                    R4C13.Name = "R4C13";
                    R4C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R4C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R4C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R4C13.MultiLine = EvetHayirEnum.ehEvet;
                    R4C13.WordBreak = EvetHayirEnum.ehEvet;
                    R4C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R4C13.Value = @"0";

                    R5C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 91, 157, 96, false);
                    R5C13.Name = "R5C13";
                    R5C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R5C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R5C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R5C13.MultiLine = EvetHayirEnum.ehEvet;
                    R5C13.WordBreak = EvetHayirEnum.ehEvet;
                    R5C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R5C13.Value = @"0";

                    R6C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 91, 172, 96, false);
                    R6C13.Name = "R6C13";
                    R6C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R6C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R6C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R6C13.MultiLine = EvetHayirEnum.ehEvet;
                    R6C13.WordBreak = EvetHayirEnum.ehEvet;
                    R6C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R6C13.Value = @"0";

                    R7C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 91, 189, 96, false);
                    R7C13.Name = "R7C13";
                    R7C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R7C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R7C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R7C13.MultiLine = EvetHayirEnum.ehEvet;
                    R7C13.WordBreak = EvetHayirEnum.ehEvet;
                    R7C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R7C13.Value = @"0";

                    R8C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 91, 205, 96, false);
                    R8C13.Name = "R8C13";
                    R8C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R8C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R8C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R8C13.MultiLine = EvetHayirEnum.ehEvet;
                    R8C13.WordBreak = EvetHayirEnum.ehEvet;
                    R8C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R8C13.Value = @"0";

                    R9C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 91, 220, 96, false);
                    R9C13.Name = "R9C13";
                    R9C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R9C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R9C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R9C13.MultiLine = EvetHayirEnum.ehEvet;
                    R9C13.WordBreak = EvetHayirEnum.ehEvet;
                    R9C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R9C13.Value = @"0";

                    R10C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 91, 235, 96, false);
                    R10C13.Name = "R10C13";
                    R10C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R10C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R10C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R10C13.MultiLine = EvetHayirEnum.ehEvet;
                    R10C13.WordBreak = EvetHayirEnum.ehEvet;
                    R10C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R10C13.Value = @"0";

                    R12C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 91, 263, 96, false);
                    R12C13.Name = "R12C13";
                    R12C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R12C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R12C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R12C13.MultiLine = EvetHayirEnum.ehEvet;
                    R12C13.WordBreak = EvetHayirEnum.ehEvet;
                    R12C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R12C13.Value = @"0";

                    R13C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 91, 275, 96, false);
                    R13C13.Name = "R13C13";
                    R13C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R13C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R13C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R13C13.MultiLine = EvetHayirEnum.ehEvet;
                    R13C13.WordBreak = EvetHayirEnum.ehEvet;
                    R13C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R13C13.Value = @"0";

                    C13Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 91, 291, 96, false);
                    C13Toplam.Name = "C13Toplam";
                    C13Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    C13Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    C13Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    C13Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    C13Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    C13Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    C13Toplam.Value = @"0";

                    R11C6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 52, 248, 57, false);
                    R11C6.Name = "R11C6";
                    R11C6.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C6.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C6.MultiLine = EvetHayirEnum.ehEvet;
                    R11C6.WordBreak = EvetHayirEnum.ehEvet;
                    R11C6.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C6.Value = @"0";

                    R11C7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 57, 248, 62, false);
                    R11C7.Name = "R11C7";
                    R11C7.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C7.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C7.MultiLine = EvetHayirEnum.ehEvet;
                    R11C7.WordBreak = EvetHayirEnum.ehEvet;
                    R11C7.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C7.Value = @"0";

                    R11C8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 62, 248, 67, false);
                    R11C8.Name = "R11C8";
                    R11C8.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C8.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C8.MultiLine = EvetHayirEnum.ehEvet;
                    R11C8.WordBreak = EvetHayirEnum.ehEvet;
                    R11C8.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C8.Value = @"0";

                    R11C10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 76, 248, 81, false);
                    R11C10.Name = "R11C10";
                    R11C10.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C10.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C10.MultiLine = EvetHayirEnum.ehEvet;
                    R11C10.WordBreak = EvetHayirEnum.ehEvet;
                    R11C10.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C10.Value = @"0";

                    R11C11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 81, 248, 86, false);
                    R11C11.Name = "R11C11";
                    R11C11.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C11.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C11.MultiLine = EvetHayirEnum.ehEvet;
                    R11C11.WordBreak = EvetHayirEnum.ehEvet;
                    R11C11.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C11.Value = @"0";

                    R11C12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 86, 248, 91, false);
                    R11C12.Name = "R11C12";
                    R11C12.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C12.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C12.MultiLine = EvetHayirEnum.ehEvet;
                    R11C12.WordBreak = EvetHayirEnum.ehEvet;
                    R11C12.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C12.Value = @"0";

                    R11C14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 96, 248, 101, false);
                    R11C14.Name = "R11C14";
                    R11C14.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C14.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C14.MultiLine = EvetHayirEnum.ehEvet;
                    R11C14.WordBreak = EvetHayirEnum.ehEvet;
                    R11C14.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C14.Value = @"0";

                    R11C15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 101, 248, 106, false);
                    R11C15.Name = "R11C15";
                    R11C15.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C15.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C15.MultiLine = EvetHayirEnum.ehEvet;
                    R11C15.WordBreak = EvetHayirEnum.ehEvet;
                    R11C15.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C15.Value = @"0";

                    R11C16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 106, 248, 111, false);
                    R11C16.Name = "R11C16";
                    R11C16.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C16.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C16.MultiLine = EvetHayirEnum.ehEvet;
                    R11C16.WordBreak = EvetHayirEnum.ehEvet;
                    R11C16.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C16.Value = @"0";

                    R11Toplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 111, 248, 116, false);
                    R11Toplam.Name = "R11Toplam";
                    R11Toplam.DrawStyle = DrawStyleConstants.vbSolid;
                    R11Toplam.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11Toplam.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11Toplam.MultiLine = EvetHayirEnum.ehEvet;
                    R11Toplam.WordBreak = EvetHayirEnum.ehEvet;
                    R11Toplam.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11Toplam.Value = @"0";

                    R11C13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 91, 248, 96, false);
                    R11C13.Name = "R11C13";
                    R11C13.DrawStyle = DrawStyleConstants.vbSolid;
                    R11C13.FieldType = ReportFieldTypeEnum.ftVariable;
                    R11C13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11C13.MultiLine = EvetHayirEnum.ehEvet;
                    R11C13.WordBreak = EvetHayirEnum.ehEvet;
                    R11C13.ExpandTabs = EvetHayirEnum.ehEvet;
                    R11C13.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField1213.CalcValue = NewField1213.Value;
                    NewField1214.CalcValue = NewField1214.Value;
                    NewField14121.CalcValue = NewField14121.Value;
                    NewField14122.CalcValue = NewField14122.Value;
                    NewField14123.CalcValue = NewField14123.Value;
                    NewField14124.CalcValue = NewField14124.Value;
                    NewField14125.CalcValue = NewField14125.Value;
                    NewField14126.CalcValue = NewField14126.Value;
                    NewField14127.CalcValue = NewField14127.Value;
                    NewField14128.CalcValue = NewField14128.Value;
                    NewField14129.CalcValue = NewField14129.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    ASDASD.CalcValue = ASDASD.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    R0C0.CalcValue = @"0";
                    R0C1.CalcValue = @"0";
                    R0C2.CalcValue = @"0";
                    R0C3.CalcValue = @"0";
                    R0C4.CalcValue = @"0";
                    R0C5.CalcValue = @"0";
                    R0C6.CalcValue = @"0";
                    R0C7.CalcValue = @"0";
                    R0C8.CalcValue = @"0";
                    R0C10.CalcValue = @"0";
                    R0C11.CalcValue = @"0";
                    R0C12.CalcValue = @"0";
                    R0C14.CalcValue = @"0";
                    R0C15.CalcValue = @"0";
                    R0C16.CalcValue = @"0";
                    R0Toplam.CalcValue = @"0";
                    R0C9.CalcValue = @"0";
                    R1C0.CalcValue = @"0";
                    R1C1.CalcValue = @"0";
                    R1C2.CalcValue = @"0";
                    R1C3.CalcValue = @"0";
                    R1C4.CalcValue = @"0";
                    R1C5.CalcValue = @"0";
                    R1C6.CalcValue = @"0";
                    R1C7.CalcValue = @"0";
                    R1C10.CalcValue = @"0";
                    R1C11.CalcValue = @"0";
                    R1C12.CalcValue = @"0";
                    R1C14.CalcValue = @"0";
                    R1C15.CalcValue = @"0";
                    R1C16.CalcValue = @"0";
                    R1Toplam.CalcValue = @"0";
                    R1C8.CalcValue = @"0";
                    R1C9.CalcValue = @"0";
                    R2C0.CalcValue = @"0";
                    R2C1.CalcValue = @"0";
                    R2C2.CalcValue = @"0";
                    R2C3.CalcValue = @"0";
                    R2C4.CalcValue = @"0";
                    R2C5.CalcValue = @"0";
                    R2C6.CalcValue = @"0";
                    R2C7.CalcValue = @"0";
                    R2C8.CalcValue = @"0";
                    R2C9.CalcValue = @"0";
                    R2C10.CalcValue = @"0";
                    R2C11.CalcValue = @"0";
                    R2C12.CalcValue = @"0";
                    R2C14.CalcValue = @"0";
                    R2C15.CalcValue = @"0";
                    R2C16.CalcValue = @"0";
                    R2Toplam.CalcValue = @"0";
                    R3C0.CalcValue = @"0";
                    R3C1.CalcValue = @"0";
                    R3C2.CalcValue = @"0";
                    R3C3.CalcValue = @"0";
                    R3C4.CalcValue = @"0";
                    R3C5.CalcValue = @"0";
                    R3C6.CalcValue = @"0";
                    R3C7.CalcValue = @"0";
                    R3C10.CalcValue = @"0";
                    R3C11.CalcValue = @"0";
                    R3C12.CalcValue = @"0";
                    R3C14.CalcValue = @"0";
                    R3C15.CalcValue = @"0";
                    R3C16.CalcValue = @"0";
                    R3Toplam.CalcValue = @"0";
                    R3C8.CalcValue = @"0";
                    R3C9.CalcValue = @"0";
                    R4C0.CalcValue = @"0";
                    R4C1.CalcValue = @"0";
                    R4C2.CalcValue = @"0";
                    R4C3.CalcValue = @"0";
                    R4C4.CalcValue = @"0";
                    R4C5.CalcValue = @"0";
                    R4C6.CalcValue = @"0";
                    R4C7.CalcValue = @"0";
                    R4C10.CalcValue = @"0";
                    R4C11.CalcValue = @"0";
                    R4C8.CalcValue = @"0";
                    R4C9.CalcValue = @"0";
                    R4C12.CalcValue = @"0";
                    R4C14.CalcValue = @"0";
                    R4C15.CalcValue = @"0";
                    R4C16.CalcValue = @"0";
                    R4Toplam.CalcValue = @"0";
                    R5C0.CalcValue = @"0";
                    R5C1.CalcValue = @"0";
                    R5C2.CalcValue = @"0";
                    R5C3.CalcValue = @"0";
                    R5C4.CalcValue = @"0";
                    R5C5.CalcValue = @"0";
                    R5C6.CalcValue = @"0";
                    R5C7.CalcValue = @"0";
                    R5C8.CalcValue = @"0";
                    R5C9.CalcValue = @"0";
                    R5C10.CalcValue = @"0";
                    R5C11.CalcValue = @"0";
                    R5C12.CalcValue = @"0";
                    R5C14.CalcValue = @"0";
                    R5C15.CalcValue = @"0";
                    R5C16.CalcValue = @"0";
                    R5Toplam.CalcValue = @"0";
                    R6C0.CalcValue = @"0";
                    R7C0.CalcValue = @"0";
                    R8C0.CalcValue = @"0";
                    R9C0.CalcValue = @"0";
                    R10C0.CalcValue = @"0";
                    R11C0.CalcValue = @"0";
                    R12C0.CalcValue = @"0";
                    R13C0.CalcValue = @"0";
                    C0Toplam.CalcValue = @"0";
                    R6C1.CalcValue = @"0";
                    R7C1.CalcValue = @"0";
                    R8C1.CalcValue = @"0";
                    R9C1.CalcValue = @"0";
                    R10C1.CalcValue = @"0";
                    R11C1.CalcValue = @"0";
                    R12C1.CalcValue = @"0";
                    R13C1.CalcValue = @"0";
                    C1Toplam.CalcValue = @"0";
                    R6C2.CalcValue = @"0";
                    R7C2.CalcValue = @"0";
                    R8C2.CalcValue = @"0";
                    R9C2.CalcValue = @"0";
                    R10C2.CalcValue = @"0";
                    R11C2.CalcValue = @"0";
                    R12C2.CalcValue = @"0";
                    R13C2.CalcValue = @"0";
                    C2Toplam.CalcValue = @"0";
                    R6C3.CalcValue = @"0";
                    R7C3.CalcValue = @"0";
                    R8C3.CalcValue = @"0";
                    R9C3.CalcValue = @"0";
                    R10C3.CalcValue = @"0";
                    R11C3.CalcValue = @"0";
                    R12C3.CalcValue = @"0";
                    R13C3.CalcValue = @"0";
                    C3Toplam.CalcValue = @"0";
                    R6C4.CalcValue = @"0";
                    R7C4.CalcValue = @"0";
                    R8C4.CalcValue = @"0";
                    R9C4.CalcValue = @"0";
                    R10C4.CalcValue = @"0";
                    R11C4.CalcValue = @"0";
                    R12C4.CalcValue = @"0";
                    R13C4.CalcValue = @"0";
                    C4Toplam.CalcValue = @"0";
                    R6C5.CalcValue = @"0";
                    R7C5.CalcValue = @"0";
                    R8C5.CalcValue = @"0";
                    R9C5.CalcValue = @"0";
                    R10C5.CalcValue = @"0";
                    R11C5.CalcValue = @"0";
                    R12C5.CalcValue = @"0";
                    R13C5.CalcValue = @"0";
                    C5Toplam.CalcValue = @"0";
                    R6C6.CalcValue = @"0";
                    R7C6.CalcValue = @"0";
                    R8C6.CalcValue = @"0";
                    R9C6.CalcValue = @"0";
                    R10C6.CalcValue = @"0";
                    R12C6.CalcValue = @"0";
                    R13C6.CalcValue = @"0";
                    C6Toplam.CalcValue = @"0";
                    R6C7.CalcValue = @"0";
                    R7C7.CalcValue = @"0";
                    R8C7.CalcValue = @"0";
                    R9C7.CalcValue = @"0";
                    R10C7.CalcValue = @"0";
                    R12C7.CalcValue = @"0";
                    R13C7.CalcValue = @"0";
                    C7Toplam.CalcValue = @"0";
                    R6C10.CalcValue = @"0";
                    R7C10.CalcValue = @"0";
                    R8C10.CalcValue = @"0";
                    R9C10.CalcValue = @"0";
                    R10C10.CalcValue = @"0";
                    R12C10.CalcValue = @"0";
                    R13C10.CalcValue = @"0";
                    C10Toplam.CalcValue = @"0";
                    R6C11.CalcValue = @"0";
                    R7C11.CalcValue = @"0";
                    R8C11.CalcValue = @"0";
                    R9C11.CalcValue = @"0";
                    R10C11.CalcValue = @"0";
                    R12C11.CalcValue = @"0";
                    R13C11.CalcValue = @"0";
                    C11Toplam.CalcValue = @"0";
                    R6C12.CalcValue = @"0";
                    R7C12.CalcValue = @"0";
                    R8C12.CalcValue = @"0";
                    R9C12.CalcValue = @"0";
                    R10C12.CalcValue = @"0";
                    R12C12.CalcValue = @"0";
                    R13C12.CalcValue = @"0";
                    C12Toplam.CalcValue = @"0";
                    R6C14.CalcValue = @"0";
                    R7C14.CalcValue = @"0";
                    R8C14.CalcValue = @"0";
                    R9C14.CalcValue = @"0";
                    R10C14.CalcValue = @"0";
                    R12C14.CalcValue = @"0";
                    R13C14.CalcValue = @"0";
                    C14Toplam.CalcValue = @"0";
                    R6C15.CalcValue = @"0";
                    R7C15.CalcValue = @"0";
                    R8C15.CalcValue = @"0";
                    R9C15.CalcValue = @"0";
                    R10C15.CalcValue = @"0";
                    R12C15.CalcValue = @"0";
                    R13C15.CalcValue = @"0";
                    C15Toplam.CalcValue = @"0";
                    R6C16.CalcValue = @"0";
                    R7C16.CalcValue = @"0";
                    R8C16.CalcValue = @"0";
                    R9C16.CalcValue = @"0";
                    R10C16.CalcValue = @"0";
                    R12C16.CalcValue = @"0";
                    R13C16.CalcValue = @"0";
                    C16Toplam.CalcValue = @"0";
                    R6Toplam.CalcValue = @"0";
                    R7Toplam.CalcValue = @"0";
                    R8Toplam.CalcValue = @"0";
                    R9Toplam.CalcValue = @"0";
                    R10Toplam.CalcValue = @"0";
                    R12Toplam.CalcValue = @"0";
                    R13Toplam.CalcValue = @"0";
                    Toplam.CalcValue = @"0";
                    R6C8.CalcValue = @"0";
                    R7C8.CalcValue = @"0";
                    R8C8.CalcValue = @"0";
                    R9C8.CalcValue = @"0";
                    R10C8.CalcValue = @"0";
                    R12C8.CalcValue = @"0";
                    R13C8.CalcValue = @"0";
                    C8Toplam.CalcValue = @"0";
                    R6C9.CalcValue = @"0";
                    R7C9.CalcValue = @"0";
                    R8C9.CalcValue = @"0";
                    R9C9.CalcValue = @"0";
                    R10C9.CalcValue = @"0";
                    R11C9.CalcValue = @"0";
                    R12C9.CalcValue = @"0";
                    R13C9.CalcValue = @"0";
                    C9Toplam.CalcValue = @"0";
                    NewField152141.CalcValue = NewField152141.Value;
                    R0C13.CalcValue = @"0";
                    R1C13.CalcValue = @"0";
                    R2C13.CalcValue = @"0";
                    R3C13.CalcValue = @"0";
                    R4C13.CalcValue = @"0";
                    R5C13.CalcValue = @"0";
                    R6C13.CalcValue = @"0";
                    R7C13.CalcValue = @"0";
                    R8C13.CalcValue = @"0";
                    R9C13.CalcValue = @"0";
                    R10C13.CalcValue = @"0";
                    R12C13.CalcValue = @"0";
                    R13C13.CalcValue = @"0";
                    C13Toplam.CalcValue = @"0";
                    R11C6.CalcValue = @"0";
                    R11C7.CalcValue = @"0";
                    R11C8.CalcValue = @"0";
                    R11C10.CalcValue = @"0";
                    R11C11.CalcValue = @"0";
                    R11C12.CalcValue = @"0";
                    R11C14.CalcValue = @"0";
                    R11C15.CalcValue = @"0";
                    R11C16.CalcValue = @"0";
                    R11Toplam.CalcValue = @"0";
                    R11C13.CalcValue = @"0";
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField112,NewField1211,NewField1212,NewField1213,NewField1214,NewField14121,NewField14122,NewField14123,NewField14124,NewField14125,NewField14126,NewField14127,NewField14128,NewField14129,NewField2,NewField12,NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,NewField19,NewField20,ASDASD,NewField21,NewField22,NewField23,NewField24,R0C0,R0C1,R0C2,R0C3,R0C4,R0C5,R0C6,R0C7,R0C8,R0C10,R0C11,R0C12,R0C14,R0C15,R0C16,R0Toplam,R0C9,R1C0,R1C1,R1C2,R1C3,R1C4,R1C5,R1C6,R1C7,R1C10,R1C11,R1C12,R1C14,R1C15,R1C16,R1Toplam,R1C8,R1C9,R2C0,R2C1,R2C2,R2C3,R2C4,R2C5,R2C6,R2C7,R2C8,R2C9,R2C10,R2C11,R2C12,R2C14,R2C15,R2C16,R2Toplam,R3C0,R3C1,R3C2,R3C3,R3C4,R3C5,R3C6,R3C7,R3C10,R3C11,R3C12,R3C14,R3C15,R3C16,R3Toplam,R3C8,R3C9,R4C0,R4C1,R4C2,R4C3,R4C4,R4C5,R4C6,R4C7,R4C10,R4C11,R4C8,R4C9,R4C12,R4C14,R4C15,R4C16,R4Toplam,R5C0,R5C1,R5C2,R5C3,R5C4,R5C5,R5C6,R5C7,R5C8,R5C9,R5C10,R5C11,R5C12,R5C14,R5C15,R5C16,R5Toplam,R6C0,R7C0,R8C0,R9C0,R10C0,R11C0,R12C0,R13C0,C0Toplam,R6C1,R7C1,R8C1,R9C1,R10C1,R11C1,R12C1,R13C1,C1Toplam,R6C2,R7C2,R8C2,R9C2,R10C2,R11C2,R12C2,R13C2,C2Toplam,R6C3,R7C3,R8C3,R9C3,R10C3,R11C3,R12C3,R13C3,C3Toplam,R6C4,R7C4,R8C4,R9C4,R10C4,R11C4,R12C4,R13C4,C4Toplam,R6C5,R7C5,R8C5,R9C5,R10C5,R11C5,R12C5,R13C5,C5Toplam,R6C6,R7C6,R8C6,R9C6,R10C6,R12C6,R13C6,C6Toplam,R6C7,R7C7,R8C7,R9C7,R10C7,R12C7,R13C7,C7Toplam,R6C10,R7C10,R8C10,R9C10,R10C10,R12C10,R13C10,C10Toplam,R6C11,R7C11,R8C11,R9C11,R10C11,R12C11,R13C11,C11Toplam,R6C12,R7C12,R8C12,R9C12,R10C12,R12C12,R13C12,C12Toplam,R6C14,R7C14,R8C14,R9C14,R10C14,R12C14,R13C14,C14Toplam,R6C15,R7C15,R8C15,R9C15,R10C15,R12C15,R13C15,C15Toplam,R6C16,R7C16,R8C16,R9C16,R10C16,R12C16,R13C16,C16Toplam,R6Toplam,R7Toplam,R8Toplam,R9Toplam,R10Toplam,R12Toplam,R13Toplam,Toplam,R6C8,R7C8,R8C8,R9C8,R10C8,R12C8,R13C8,C8Toplam,R6C9,R7C9,R8C9,R9C9,R10C9,R11C9,R12C9,R13C9,C9Toplam,NewField152141,R0C13,R1C13,R2C13,R3C13,R4C13,R5C13,R6C13,R7C13,R8C13,R9C13,R10C13,R12C13,R13C13,C13Toplam,R11C6,R11C7,R11C8,R11C10,R11C11,R11C12,R11C14,R11C15,R11C16,R11Toplam,R11C13};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    BindingList<PatientInterviewForm.SocialServicesUnitActivityReport_Class> list = PatientInterviewForm.SocialServicesUnitActivityReport(MyParentReport.ReportObjectContext, MyParentReport.RuntimeParameters.STARTDATE.Value, MyParentReport.RuntimeParameters.ENDDATE.Value, MyParentReport.RuntimeParameters.PROCEDUREBYUSER);
            foreach (PatientInterviewForm.SocialServicesUnitActivityReport_Class listItem in list)
            {
                string fieldName = "R" + (int)listItem.PatientType;
                this.FieldsByName(fieldName + "C0").CalcValue = Convert.ToInt16(listItem.C0).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C0));
                this.FieldsByName("C0Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C0Toplam").CalcValue) + Convert.ToInt16(listItem.C0));

                this.FieldsByName(fieldName + "C1").CalcValue = Convert.ToInt16(listItem.C1).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C1));
                this.FieldsByName("C1Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C1Toplam").CalcValue) + Convert.ToInt16(listItem.C1));

                this.FieldsByName(fieldName + "C2").CalcValue = Convert.ToInt16(listItem.C2).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C2));
                this.FieldsByName("C2Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C2Toplam").CalcValue) + Convert.ToInt16(listItem.C2));

                this.FieldsByName(fieldName + "C3").CalcValue = Convert.ToInt16(listItem.C3).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C3));
                this.FieldsByName("C3Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C3Toplam").CalcValue) + Convert.ToInt16(listItem.C3));

                this.FieldsByName(fieldName + "C4").CalcValue = Convert.ToInt16(listItem.C4).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C4));
                this.FieldsByName("C4Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C4Toplam").CalcValue) + Convert.ToInt16(listItem.C4));

                this.FieldsByName(fieldName + "C5").CalcValue = Convert.ToInt16(listItem.C5).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C5));
                this.FieldsByName("C5Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C5Toplam").CalcValue) + Convert.ToInt16(listItem.C5));

                this.FieldsByName(fieldName + "C6").CalcValue = Convert.ToInt16(listItem.C6).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C6));
                this.FieldsByName("C6Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C6Toplam").CalcValue) + Convert.ToInt16(listItem.C6));

                this.FieldsByName(fieldName + "C7").CalcValue = Convert.ToInt16(listItem.C7).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C7));
                this.FieldsByName("C7Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C7Toplam").CalcValue) + Convert.ToInt16(listItem.C7));

                this.FieldsByName(fieldName + "C8").CalcValue = Convert.ToInt16(listItem.C8).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C8));
                this.FieldsByName("C8Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C8Toplam").CalcValue) + Convert.ToInt16(listItem.C8));

                this.FieldsByName(fieldName + "C9").CalcValue = Convert.ToInt16(listItem.C9).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C9));
                this.FieldsByName("C9Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C9Toplam").CalcValue) + Convert.ToInt16(listItem.C9));

                this.FieldsByName(fieldName + "C10").CalcValue = Convert.ToInt16(listItem.C10).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C10));
                this.FieldsByName("C10Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C10Toplam").CalcValue) + Convert.ToInt16(listItem.C10));

                this.FieldsByName(fieldName + "C11").CalcValue = Convert.ToInt16(listItem.C11).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C11));
                this.FieldsByName("C11Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C11Toplam").CalcValue) + Convert.ToInt16(listItem.C11));

                this.FieldsByName(fieldName + "C12").CalcValue = Convert.ToInt16(listItem.C12).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C12));
                this.FieldsByName("C12Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C12Toplam").CalcValue) + Convert.ToInt16(listItem.C12));

                this.FieldsByName(fieldName + "C13").CalcValue = Convert.ToInt16(listItem.C13).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C13));
                this.FieldsByName("C13Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C13Toplam").CalcValue) + Convert.ToInt16(listItem.C13));

                this.FieldsByName(fieldName + "C14").CalcValue = Convert.ToInt16(listItem.C14).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C14));
                this.FieldsByName("C14Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C14Toplam").CalcValue) + Convert.ToInt16(listItem.C14));

                this.FieldsByName(fieldName + "C15").CalcValue = Convert.ToInt16(listItem.C15).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C15));
                this.FieldsByName("C15Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C15Toplam").CalcValue) + Convert.ToInt16(listItem.C15));

                this.FieldsByName(fieldName + "C16").CalcValue = Convert.ToInt16(listItem.C16).ToString();
                this.FieldsByName(fieldName + "Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName(fieldName + "Toplam").CalcValue) + Convert.ToInt16(listItem.C16));
                this.FieldsByName("C16Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("C16Toplam").CalcValue) + Convert.ToInt16(listItem.C16));

            }
            for(int i=0 ; i<14 ; i++){
                this.FieldsByName("Toplam").CalcValue = Convert.ToString(Convert.ToInt16(this.FieldsByName("Toplam").CalcValue) + Convert.ToInt16(this.FieldsByName("R" + i + "Toplam").CalcValue));
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

        public FaaliyetRaporu()
        {
            part1 = new part1Group(this,"part1");
            MAIN = new MAINGroup(part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PROCEDUREBYUSER", "", "İşlemi Yapan", @"", false, false, false, new Guid("0bf6ce17-e764-4aca-9715-722d1b252a6f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PROCEDUREBYUSER"))
                _runtimeParameters.PROCEDUREBYUSER = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue(parameters["PROCEDUREBYUSER"]);
            Name = "FAALIYETRAPORU";
            Caption = "FaaliyetRaporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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