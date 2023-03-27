
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
    /// Borç Senedi
    /// </summary>
    public partial class DebentureDebtReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public DebentureDebtReport MyParentReport
            {
                get { return (DebentureDebtReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public DebentureDebtReport MyParentReport
                {
                    get { return (DebentureDebtReport)ParentReport; }
                }
                
                public TTReportField NewField; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 5, 161, 14, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"BORÇ SENEDİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    return new TTReportObject[] { NewField};
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public DebentureDebtReport MyParentReport
                {
                    get { return (DebentureDebtReport)ParentReport; }
                }
                 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public DebentureDebtReport MyParentReport
            {
                get { return (DebentureDebtReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField GUARANTORSIGN { get {return Body().GUARANTORSIGN;} }
            public TTReportField PATIENTSIGN { get {return Body().PATIENTSIGN;} }
            public TTReportField NewField46 { get {return Body().NewField46;} }
            public TTReportField GUARANTORWORKADDRESS { get {return Body().GUARANTORWORKADDRESS;} }
            public TTReportField PATIENTWORKADDRESS { get {return Body().PATIENTWORKADDRESS;} }
            public TTReportField NewField45 { get {return Body().NewField45;} }
            public TTReportField GUARANTORHOMEADDRESS { get {return Body().GUARANTORHOMEADDRESS;} }
            public TTReportField PATIENTHOMEADDRESS { get {return Body().PATIENTHOMEADDRESS;} }
            public TTReportField NewField44 { get {return Body().NewField44;} }
            public TTReportField GUARANTORBIRTHINFO { get {return Body().GUARANTORBIRTHINFO;} }
            public TTReportField PATIENTBIRTHINFO { get {return Body().PATIENTBIRTHINFO;} }
            public TTReportField NewField43 { get {return Body().NewField43;} }
            public TTReportField GUARANTORIDENTITYINFO { get {return Body().GUARANTORIDENTITYINFO;} }
            public TTReportField PATIENTIDENTITYINFO { get {return Body().PATIENTIDENTITYINFO;} }
            public TTReportField NewField42 { get {return Body().NewField42;} }
            public TTReportField GUARANTORFATHERNAME { get {return Body().GUARANTORFATHERNAME;} }
            public TTReportField PATIENTFATHERNAME { get {return Body().PATIENTFATHERNAME;} }
            public TTReportField NewField41 { get {return Body().NewField41;} }
            public TTReportField GUARANTORNAME { get {return Body().GUARANTORNAME;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField DOCUMENTNO { get {return Body().DOCUMENTNO;} }
            public TTReportField DEPARTMENT { get {return Body().DEPARTMENT;} }
            public TTReportField CARDNO { get {return Body().CARDNO;} }
            public TTReportField RECORDNO { get {return Body().RECORDNO;} }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField NOLABEL { get {return Body().NOLABEL;} }
            public TTReportField LIRA { get {return Body().LIRA;} }
            public TTReportField KURUS { get {return Body().KURUS;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField TEXT { get {return Body().TEXT;} }
            public TTReportField DEBENTUREDUEDATE { get {return Body().DEBENTUREDUEDATE;} }
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
                list[0] = new TTReportNqlData<DebentureGuarantorCorrection.DebentureDebtReportQuery_Class>("DebentureDebtReportQuery2", DebentureGuarantorCorrection.DebentureDebtReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DebentureDebtReport MyParentReport
                {
                    get { return (DebentureDebtReport)ParentReport; }
                }
                
                public TTReportField GUARANTORSIGN;
                public TTReportField PATIENTSIGN;
                public TTReportField NewField46;
                public TTReportField GUARANTORWORKADDRESS;
                public TTReportField PATIENTWORKADDRESS;
                public TTReportField NewField45;
                public TTReportField GUARANTORHOMEADDRESS;
                public TTReportField PATIENTHOMEADDRESS;
                public TTReportField NewField44;
                public TTReportField GUARANTORBIRTHINFO;
                public TTReportField PATIENTBIRTHINFO;
                public TTReportField NewField43;
                public TTReportField GUARANTORIDENTITYINFO;
                public TTReportField PATIENTIDENTITYINFO;
                public TTReportField NewField42;
                public TTReportField GUARANTORFATHERNAME;
                public TTReportField PATIENTFATHERNAME;
                public TTReportField NewField41;
                public TTReportField GUARANTORNAME;
                public TTReportField PATIENTNAME;
                public TTReportField NewField14;
                public TTReportField NewField13;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField DOCUMENTNO;
                public TTReportField DEPARTMENT;
                public TTReportField CARDNO;
                public TTReportField RECORDNO;
                public TTReportField NO;
                public TTReportField NOLABEL;
                public TTReportField LIRA;
                public TTReportField KURUS;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField TEXT;
                public TTReportField DEBENTUREDUEDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 207;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    GUARANTORSIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 195, 193, 204, false);
                    GUARANTORSIGN.Name = "GUARANTORSIGN";
                    GUARANTORSIGN.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORSIGN.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORSIGN.DrawWidth = 2;
                    GUARANTORSIGN.TextFont.Size = 12;
                    GUARANTORSIGN.TextFont.CharSet = 162;
                    GUARANTORSIGN.Value = @"";

                    PATIENTSIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 195, 123, 204, false);
                    PATIENTSIGN.Name = "PATIENTSIGN";
                    PATIENTSIGN.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTSIGN.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTSIGN.DrawWidth = 2;
                    PATIENTSIGN.TextFont.Size = 12;
                    PATIENTSIGN.TextFont.CharSet = 162;
                    PATIENTSIGN.Value = @"";

                    NewField46 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 195, 53, 204, false);
                    NewField46.Name = "NewField46";
                    NewField46.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField46.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField46.DrawWidth = 2;
                    NewField46.TextFont.Size = 12;
                    NewField46.TextFont.CharSet = 162;
                    NewField46.Value = @"İMZA";

                    GUARANTORWORKADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 180, 193, 195, false);
                    GUARANTORWORKADDRESS.Name = "GUARANTORWORKADDRESS";
                    GUARANTORWORKADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORWORKADDRESS.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORWORKADDRESS.DrawWidth = 2;
                    GUARANTORWORKADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORWORKADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTORWORKADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    GUARANTORWORKADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    GUARANTORWORKADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTORWORKADDRESS.TextFont.Size = 12;
                    GUARANTORWORKADDRESS.TextFont.CharSet = 162;
                    GUARANTORWORKADDRESS.Value = @"";

                    PATIENTWORKADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 180, 123, 195, false);
                    PATIENTWORKADDRESS.Name = "PATIENTWORKADDRESS";
                    PATIENTWORKADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTWORKADDRESS.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTWORKADDRESS.DrawWidth = 2;
                    PATIENTWORKADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTWORKADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTWORKADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTWORKADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTWORKADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTWORKADDRESS.TextFont.Size = 12;
                    PATIENTWORKADDRESS.TextFont.CharSet = 162;
                    PATIENTWORKADDRESS.Value = @"";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 180, 53, 195, false);
                    NewField45.Name = "NewField45";
                    NewField45.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField45.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField45.DrawWidth = 2;
                    NewField45.TextFont.Size = 12;
                    NewField45.TextFont.CharSet = 162;
                    NewField45.Value = @"İş Adresi ve Telefonu";

                    GUARANTORHOMEADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 165, 193, 180, false);
                    GUARANTORHOMEADDRESS.Name = "GUARANTORHOMEADDRESS";
                    GUARANTORHOMEADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORHOMEADDRESS.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORHOMEADDRESS.DrawWidth = 2;
                    GUARANTORHOMEADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORHOMEADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTORHOMEADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    GUARANTORHOMEADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    GUARANTORHOMEADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTORHOMEADDRESS.TextFont.Size = 12;
                    GUARANTORHOMEADDRESS.TextFont.CharSet = 162;
                    GUARANTORHOMEADDRESS.Value = @"";

                    PATIENTHOMEADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 165, 123, 180, false);
                    PATIENTHOMEADDRESS.Name = "PATIENTHOMEADDRESS";
                    PATIENTHOMEADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTHOMEADDRESS.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTHOMEADDRESS.DrawWidth = 2;
                    PATIENTHOMEADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTHOMEADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTHOMEADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTHOMEADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTHOMEADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTHOMEADDRESS.TextFont.Size = 12;
                    PATIENTHOMEADDRESS.TextFont.CharSet = 162;
                    PATIENTHOMEADDRESS.Value = @"";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 165, 53, 180, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField44.DrawWidth = 2;
                    NewField44.MultiLine = EvetHayirEnum.ehEvet;
                    NewField44.NoClip = EvetHayirEnum.ehEvet;
                    NewField44.WordBreak = EvetHayirEnum.ehEvet;
                    NewField44.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Size = 12;
                    NewField44.TextFont.CharSet = 162;
                    NewField44.Value = @"İkametgah Adresi
ve Telefonu";

                    GUARANTORBIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 151, 193, 165, false);
                    GUARANTORBIRTHINFO.Name = "GUARANTORBIRTHINFO";
                    GUARANTORBIRTHINFO.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORBIRTHINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORBIRTHINFO.DrawWidth = 2;
                    GUARANTORBIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORBIRTHINFO.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTORBIRTHINFO.NoClip = EvetHayirEnum.ehEvet;
                    GUARANTORBIRTHINFO.WordBreak = EvetHayirEnum.ehEvet;
                    GUARANTORBIRTHINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTORBIRTHINFO.TextFont.Size = 12;
                    GUARANTORBIRTHINFO.TextFont.CharSet = 162;
                    GUARANTORBIRTHINFO.Value = @"";

                    PATIENTBIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 151, 123, 165, false);
                    PATIENTBIRTHINFO.Name = "PATIENTBIRTHINFO";
                    PATIENTBIRTHINFO.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTBIRTHINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTBIRTHINFO.DrawWidth = 2;
                    PATIENTBIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTBIRTHINFO.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTBIRTHINFO.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTBIRTHINFO.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTBIRTHINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTBIRTHINFO.TextFont.Size = 12;
                    PATIENTBIRTHINFO.TextFont.CharSet = 162;
                    PATIENTBIRTHINFO.Value = @"";

                    NewField43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 151, 53, 165, false);
                    NewField43.Name = "NewField43";
                    NewField43.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField43.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField43.DrawWidth = 2;
                    NewField43.MultiLine = EvetHayirEnum.ehEvet;
                    NewField43.NoClip = EvetHayirEnum.ehEvet;
                    NewField43.WordBreak = EvetHayirEnum.ehEvet;
                    NewField43.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField43.TextFont.Size = 12;
                    NewField43.TextFont.CharSet = 162;
                    NewField43.Value = @"Nüfusa Kayıtlı olduğu
İl-İlçe ve Köy";

                    GUARANTORIDENTITYINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 142, 193, 151, false);
                    GUARANTORIDENTITYINFO.Name = "GUARANTORIDENTITYINFO";
                    GUARANTORIDENTITYINFO.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORIDENTITYINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORIDENTITYINFO.DrawWidth = 2;
                    GUARANTORIDENTITYINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORIDENTITYINFO.TextFont.Size = 12;
                    GUARANTORIDENTITYINFO.TextFont.CharSet = 162;
                    GUARANTORIDENTITYINFO.Value = @"";

                    PATIENTIDENTITYINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 142, 123, 151, false);
                    PATIENTIDENTITYINFO.Name = "PATIENTIDENTITYINFO";
                    PATIENTIDENTITYINFO.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTIDENTITYINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTIDENTITYINFO.DrawWidth = 2;
                    PATIENTIDENTITYINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTIDENTITYINFO.TextFont.Size = 12;
                    PATIENTIDENTITYINFO.TextFont.CharSet = 162;
                    PATIENTIDENTITYINFO.Value = @"";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 142, 53, 151, false);
                    NewField42.Name = "NewField42";
                    NewField42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField42.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField42.DrawWidth = 2;
                    NewField42.TextFont.Size = 12;
                    NewField42.TextFont.CharSet = 162;
                    NewField42.Value = @"Cilt-Sayfa-Kütük No";

                    GUARANTORFATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 128, 193, 142, false);
                    GUARANTORFATHERNAME.Name = "GUARANTORFATHERNAME";
                    GUARANTORFATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORFATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORFATHERNAME.DrawWidth = 2;
                    GUARANTORFATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORFATHERNAME.TextFont.Size = 12;
                    GUARANTORFATHERNAME.TextFont.CharSet = 162;
                    GUARANTORFATHERNAME.Value = @"{#GUARANTORFATHERNAME#}";

                    PATIENTFATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 128, 123, 142, false);
                    PATIENTFATHERNAME.Name = "PATIENTFATHERNAME";
                    PATIENTFATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTFATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTFATHERNAME.DrawWidth = 2;
                    PATIENTFATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTFATHERNAME.TextFont.Size = 12;
                    PATIENTFATHERNAME.TextFont.CharSet = 162;
                    PATIENTFATHERNAME.Value = @"{#PATIENTFATHERNAME#}";

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 128, 53, 142, false);
                    NewField41.Name = "NewField41";
                    NewField41.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField41.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField41.DrawWidth = 2;
                    NewField41.TextFont.Size = 12;
                    NewField41.TextFont.CharSet = 162;
                    NewField41.Value = @"Baba Adı";

                    GUARANTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 114, 193, 128, false);
                    GUARANTORNAME.Name = "GUARANTORNAME";
                    GUARANTORNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORNAME.DrawWidth = 2;
                    GUARANTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTORNAME.TextFont.Size = 12;
                    GUARANTORNAME.TextFont.CharSet = 162;
                    GUARANTORNAME.Value = @"{#GUARANTORNAME#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 114, 123, 128, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTNAME.DrawWidth = 2;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Size = 12;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENTNAME#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 114, 53, 128, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField14.DrawWidth = 2;
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Adı ve Soyadı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 109, 193, 114, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField13.DrawWidth = 2;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"KEFİL";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 109, 123, 114, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField12.DrawWidth = 2;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BORÇLU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 109, 53, 114, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField11.DrawWidth = 2;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"KİMLİĞİ";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 11, 41, 16, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Tanzim Tarihi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 17, 41, 22, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Bölüm";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 23, 41, 28, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Kart No";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 29, 41, 34, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 12;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Kayıt No";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 11, 43, 16, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 12;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 17, 43, 22, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 12;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 23, 43, 28, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 12;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 29, 43, 34, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Size = 12;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @":";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 11, 74, 16, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFormat = @"Short Date";
                    DOCUMENTNO.TextFont.Size = 12;
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTDATE#}";

                    DEPARTMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 17, 153, 22, false);
                    DEPARTMENT.Name = "DEPARTMENT";
                    DEPARTMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPARTMENT.TextFormat = @"Short Date";
                    DEPARTMENT.TextFont.Size = 12;
                    DEPARTMENT.TextFont.CharSet = 162;
                    DEPARTMENT.Value = @"{#DEPARTMENT#}";

                    CARDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 23, 74, 28, false);
                    CARDNO.Name = "CARDNO";
                    CARDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDNO.TextFormat = @"Short Date";
                    CARDNO.TextFont.Size = 12;
                    CARDNO.TextFont.CharSet = 162;
                    CARDNO.Value = @"{#EPISODEID#}";

                    RECORDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 29, 133, 34, false);
                    RECORDNO.Name = "RECORDNO";
                    RECORDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDNO.TextFormat = @"Short Date";
                    RECORDNO.TextFont.Size = 12;
                    RECORDNO.TextFont.CharSet = 162;
                    RECORDNO.Value = @"{#PATIENTUNIQUEREFNO#}";

                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 11, 190, 18, false);
                    NO.Name = "NO";
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.TextFormat = @"Short Date";
                    NO.TextFont.Size = 14;
                    NO.TextFont.Bold = true;
                    NO.TextFont.CharSet = 162;
                    NO.Value = @"{#DEBENTURENO#}";

                    NOLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 11, 165, 18, false);
                    NOLABEL.Name = "NOLABEL";
                    NOLABEL.TextFormat = @"Short Date";
                    NOLABEL.TextFont.Size = 14;
                    NOLABEL.TextFont.Bold = true;
                    NOLABEL.TextFont.CharSet = 162;
                    NOLABEL.Value = @"No:";

                    LIRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 50, 102, 55, false);
                    LIRA.Name = "LIRA";
                    LIRA.DrawStyle = DrawStyleConstants.vbSolid;
                    LIRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    LIRA.TextFont.Size = 12;
                    LIRA.TextFont.CharSet = 162;
                    LIRA.Value = @"";

                    KURUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 50, 127, 55, false);
                    KURUS.Name = "KURUS";
                    KURUS.DrawStyle = DrawStyleConstants.vbSolid;
                    KURUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUS.TextFont.Size = 12;
                    KURUS.TextFont.CharSet = 162;
                    KURUS.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 44, 102, 49, false);
                    NewField9.Name = "NewField9";
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.Value = @"Lira";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 44, 127, 49, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.Value = @"Krş.";

                    TEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 70, 190, 105, false);
                    TEXT.Name = "TEXT";
                    TEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT.NoClip = EvetHayirEnum.ehEvet;
                    TEXT.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT.TextFont.Size = 12;
                    TEXT.TextFont.CharSet = 162;
                    TEXT.Value = @"          XXXXXX Döner Sermaye Saymanlığı'na tedavi bedeli olarak {#DEBENTUREPRICE#} Lira borçlanmış bulunmaktayım.
          Bu borcumu {%DEBENTUREDUEDATE%} tarihinde ödeyeceğimi şimdiden kabul ve taahhüt ediyorum.
          Aksi takdirde, tahsilat icrası için hakkımda yapılacak kanuni muameleyi hiçbir itirazım olmayacağını ve merci olarak XXXXXX Mahkemelerini, ikametime tevcih edildiği takdirde Mahalli Mahkemelerinin takip ve icrasını kabul edeceğime dair iş bu borç senedini imza ediyorum.";

                    DEBENTUREDUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 51, 267, 56, false);
                    DEBENTUREDUEDATE.Name = "DEBENTUREDUEDATE";
                    DEBENTUREDUEDATE.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREDUEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTUREDUEDATE.TextFormat = @"Short Date";
                    DEBENTUREDUEDATE.Value = @"{#DUEDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebentureGuarantorCorrection.DebentureDebtReportQuery_Class dataset_DebentureDebtReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<DebentureGuarantorCorrection.DebentureDebtReportQuery_Class>(0);
                    GUARANTORSIGN.CalcValue = GUARANTORSIGN.Value;
                    PATIENTSIGN.CalcValue = PATIENTSIGN.Value;
                    NewField46.CalcValue = NewField46.Value;
                    GUARANTORWORKADDRESS.CalcValue = @"";
                    PATIENTWORKADDRESS.CalcValue = @"";
                    NewField45.CalcValue = NewField45.Value;
                    GUARANTORHOMEADDRESS.CalcValue = @"";
                    PATIENTHOMEADDRESS.CalcValue = @"";
                    NewField44.CalcValue = NewField44.Value;
                    GUARANTORBIRTHINFO.CalcValue = @"";
                    PATIENTBIRTHINFO.CalcValue = @"";
                    NewField43.CalcValue = NewField43.Value;
                    GUARANTORIDENTITYINFO.CalcValue = @"";
                    PATIENTIDENTITYINFO.CalcValue = @"";
                    NewField42.CalcValue = NewField42.Value;
                    GUARANTORFATHERNAME.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Guarantorfathername) : "");
                    PATIENTFATHERNAME.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Patientfathername) : "");
                    NewField41.CalcValue = NewField41.Value;
                    GUARANTORNAME.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Guarantorname) : "");
                    PATIENTNAME.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Patientname) : "");
                    NewField14.CalcValue = NewField14.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    DOCUMENTNO.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.DocumentDate) : "");
                    DEPARTMENT.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Department) : "");
                    CARDNO.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Episodeid) : "");
                    RECORDNO.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Patientuniquerefno) : "");
                    NO.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Debentureno) : "");
                    NOLABEL.CalcValue = NOLABEL.Value;
                    LIRA.CalcValue = @"";
                    KURUS.CalcValue = @"";
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    DEBENTUREDUEDATE.CalcValue = (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.DueDate) : "");
                    TEXT.CalcValue = @"          XXXXXX Döner Sermaye Saymanlığı'na tedavi bedeli olarak " + (dataset_DebentureDebtReportQuery2 != null ? Globals.ToStringCore(dataset_DebentureDebtReportQuery2.Debentureprice) : "") + @" Lira borçlanmış bulunmaktayım.
          Bu borcumu " + MyParentReport.MAIN.DEBENTUREDUEDATE.FormattedValue + @" tarihinde ödeyeceğimi şimdiden kabul ve taahhüt ediyorum.
          Aksi takdirde, tahsilat icrası için hakkımda yapılacak kanuni muameleyi hiçbir itirazım olmayacağını ve merci olarak XXXXXX Mahkemelerini, ikametime tevcih edildiği takdirde Mahalli Mahkemelerinin takip ve icrasını kabul edeceğime dair iş bu borç senedini imza ediyorum.";
                    return new TTReportObject[] { GUARANTORSIGN,PATIENTSIGN,NewField46,GUARANTORWORKADDRESS,PATIENTWORKADDRESS,NewField45,GUARANTORHOMEADDRESS,PATIENTHOMEADDRESS,NewField44,GUARANTORBIRTHINFO,PATIENTBIRTHINFO,NewField43,GUARANTORIDENTITYINFO,PATIENTIDENTITYINFO,NewField42,GUARANTORFATHERNAME,PATIENTFATHERNAME,NewField41,GUARANTORNAME,PATIENTNAME,NewField14,NewField13,NewField12,NewField11,NewField,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,DOCUMENTNO,DEPARTMENT,CARDNO,RECORDNO,NO,NOLABEL,LIRA,KURUS,NewField9,NewField10,DEBENTUREDUEDATE,TEXT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DebentureDebtReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DEBENTUREDEBTREPORT";
            Caption = "Borç Senedi";
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