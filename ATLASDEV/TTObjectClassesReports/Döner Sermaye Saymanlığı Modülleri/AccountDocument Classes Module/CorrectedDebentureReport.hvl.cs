
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
    public partial class CorrectedDebentureReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public CorrectedDebentureReport MyParentReport
            {
                get { return (CorrectedDebentureReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField DEBENTUREOBJECTID { get {return Header().DEBENTUREOBJECTID;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DebentureCorrection.GetNewDebentures_Class>("GetNewDebentures", DebentureCorrection.GetNewDebentures((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public CorrectedDebentureReport MyParentReport
                {
                    get { return (CorrectedDebentureReport)ParentReport; }
                }
                
                public TTReportField DEBENTUREOBJECTID; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DEBENTUREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 4, 250, 9, false);
                    DEBENTUREOBJECTID.Name = "DEBENTUREOBJECTID";
                    DEBENTUREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTUREOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebentureCorrection.GetNewDebentures_Class dataset_GetNewDebentures = ParentGroup.rsGroup.GetCurrentRecord<DebentureCorrection.GetNewDebentures_Class>(0);
                    DEBENTUREOBJECTID.CalcValue = (dataset_GetNewDebentures != null ? Globals.ToStringCore(dataset_GetNewDebentures.ObjectID) : "");
                    return new TTReportObject[] { DEBENTUREOBJECTID};
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public CorrectedDebentureReport MyParentReport
                {
                    get { return (CorrectedDebentureReport)ParentReport; }
                }
                 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public CorrectedDebentureReport MyParentReport
            {
                get { return (CorrectedDebentureReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BOX13 { get {return Body().BOX13;} }
            public TTReportField BOX21 { get {return Body().BOX21;} }
            public TTReportField BOX20 { get {return Body().BOX20;} }
            public TTReportField BOX19 { get {return Body().BOX19;} }
            public TTReportField BOX18 { get {return Body().BOX18;} }
            public TTReportField BOX17 { get {return Body().BOX17;} }
            public TTReportField BOX16 { get {return Body().BOX16;} }
            public TTReportField BOX15 { get {return Body().BOX15;} }
            public TTReportField BOX14 { get {return Body().BOX14;} }
            public TTReportField BOX12 { get {return Body().BOX12;} }
            public TTReportField BOX11 { get {return Body().BOX11;} }
            public TTReportField BOX1 { get {return Body().BOX1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField3_1 { get {return Body().NewField3_1;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField DEBENTURENO { get {return Body().DEBENTURENO;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField DEPARTMENT { get {return Body().DEPARTMENT;} }
            public TTReportField EPISODEID { get {return Body().EPISODEID;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField LIRA { get {return Body().LIRA;} }
            public TTReportField KURUS { get {return Body().KURUS;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField TEXT { get {return Body().TEXT;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField GUARANTORSIGN11 { get {return Body().GUARANTORSIGN11;} }
            public TTReportField PATIENTSIGN11 { get {return Body().PATIENTSIGN11;} }
            public TTReportField NewField1461 { get {return Body().NewField1461;} }
            public TTReportField NewField1451 { get {return Body().NewField1451;} }
            public TTReportField NewField1441 { get {return Body().NewField1441;} }
            public TTReportField NewField1431 { get {return Body().NewField1431;} }
            public TTReportField NewField1421 { get {return Body().NewField1421;} }
            public TTReportField NewField1411 { get {return Body().NewField1411;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField DUEDATE { get {return Body().DUEDATE;} }
            public TTReportField NewField193 { get {return Body().NewField193;} }
            public TTReportField NewField1391 { get {return Body().NewField1391;} }
            public TTReportField USER { get {return Body().USER;} }
            public TTReportField PNAME { get {return Body().PNAME;} }
            public TTReportField PSURNAME { get {return Body().PSURNAME;} }
            public TTReportField HOSPITALDSNAME { get {return Body().HOSPITALDSNAME;} }
            public TTReportField HOSPITALCITY { get {return Body().HOSPITALCITY;} }
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
                list[0] = new TTReportNqlData<Debenture.DebentureReportQuery_Class>("DebentureReportQuery", Debenture.DebentureReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.HEAD.DEBENTUREOBJECTID.CalcValue)));
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
                public CorrectedDebentureReport MyParentReport
                {
                    get { return (CorrectedDebentureReport)ParentReport; }
                }
                
                public TTReportField BOX13;
                public TTReportField BOX21;
                public TTReportField BOX20;
                public TTReportField BOX19;
                public TTReportField BOX18;
                public TTReportField BOX17;
                public TTReportField BOX16;
                public TTReportField BOX15;
                public TTReportField BOX14;
                public TTReportField BOX12;
                public TTReportField BOX11;
                public TTReportField BOX1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField3_1;
                public TTReportField NewField14;
                public TTReportField NewField13;
                public TTReportField NewField15;
                public TTReportField DEBENTURENO;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField DATE;
                public TTReportField DEPARTMENT;
                public TTReportField EPISODEID;
                public TTReportField UNIQUEREFNO;
                public TTReportField LIRA;
                public TTReportField KURUS;
                public TTReportField NewField19;
                public TTReportField NewField191;
                public TTReportField TEXT;
                public TTReportField PRICE;
                public TTReportField GUARANTORSIGN11;
                public TTReportField PATIENTSIGN11;
                public TTReportField NewField1461;
                public TTReportField NewField1451;
                public TTReportField NewField1441;
                public TTReportField NewField1431;
                public TTReportField NewField1421;
                public TTReportField NewField1411;
                public TTReportField NewField1141;
                public TTReportField NewField1131;
                public TTReportField NewField1121;
                public TTReportField NewField1111;
                public TTReportField DUEDATE;
                public TTReportField NewField193;
                public TTReportField NewField1391;
                public TTReportField USER;
                public TTReportField PNAME;
                public TTReportField PSURNAME;
                public TTReportField HOSPITALDSNAME;
                public TTReportField HOSPITALCITY; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 273;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BOX13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 140, 188, 154, false);
                    BOX13.Name = "BOX13";
                    BOX13.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX13.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX13.DrawWidth = 2;
                    BOX13.MultiLine = EvetHayirEnum.ehEvet;
                    BOX13.NoClip = EvetHayirEnum.ehEvet;
                    BOX13.WordBreak = EvetHayirEnum.ehEvet;
                    BOX13.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX13.TextFont.Size = 12;
                    BOX13.TextFont.CharSet = 162;
                    BOX13.Value = @"";

                    BOX21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 203, 188, 226, false);
                    BOX21.Name = "BOX21";
                    BOX21.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX21.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX21.DrawWidth = 2;
                    BOX21.MultiLine = EvetHayirEnum.ehEvet;
                    BOX21.NoClip = EvetHayirEnum.ehEvet;
                    BOX21.WordBreak = EvetHayirEnum.ehEvet;
                    BOX21.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX21.TextFont.Size = 12;
                    BOX21.TextFont.CharSet = 162;
                    BOX21.Value = @"";

                    BOX20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 203, 118, 226, false);
                    BOX20.Name = "BOX20";
                    BOX20.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX20.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX20.DrawWidth = 2;
                    BOX20.MultiLine = EvetHayirEnum.ehEvet;
                    BOX20.NoClip = EvetHayirEnum.ehEvet;
                    BOX20.WordBreak = EvetHayirEnum.ehEvet;
                    BOX20.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX20.TextFont.Size = 12;
                    BOX20.TextFont.CharSet = 162;
                    BOX20.Value = @"";

                    BOX19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 181, 188, 203, false);
                    BOX19.Name = "BOX19";
                    BOX19.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX19.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX19.DrawWidth = 2;
                    BOX19.MultiLine = EvetHayirEnum.ehEvet;
                    BOX19.NoClip = EvetHayirEnum.ehEvet;
                    BOX19.WordBreak = EvetHayirEnum.ehEvet;
                    BOX19.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX19.TextFont.Size = 12;
                    BOX19.TextFont.CharSet = 162;
                    BOX19.Value = @"";

                    BOX18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 181, 118, 203, false);
                    BOX18.Name = "BOX18";
                    BOX18.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX18.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX18.DrawWidth = 2;
                    BOX18.MultiLine = EvetHayirEnum.ehEvet;
                    BOX18.NoClip = EvetHayirEnum.ehEvet;
                    BOX18.WordBreak = EvetHayirEnum.ehEvet;
                    BOX18.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX18.TextFont.Size = 12;
                    BOX18.TextFont.CharSet = 162;
                    BOX18.Value = @"";

                    BOX17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 163, 188, 181, false);
                    BOX17.Name = "BOX17";
                    BOX17.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX17.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX17.DrawWidth = 2;
                    BOX17.MultiLine = EvetHayirEnum.ehEvet;
                    BOX17.NoClip = EvetHayirEnum.ehEvet;
                    BOX17.WordBreak = EvetHayirEnum.ehEvet;
                    BOX17.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX17.TextFont.Size = 12;
                    BOX17.TextFont.CharSet = 162;
                    BOX17.Value = @"";

                    BOX16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 163, 118, 181, false);
                    BOX16.Name = "BOX16";
                    BOX16.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX16.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX16.DrawWidth = 2;
                    BOX16.MultiLine = EvetHayirEnum.ehEvet;
                    BOX16.NoClip = EvetHayirEnum.ehEvet;
                    BOX16.WordBreak = EvetHayirEnum.ehEvet;
                    BOX16.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX16.TextFont.Size = 12;
                    BOX16.TextFont.CharSet = 162;
                    BOX16.Value = @"";

                    BOX15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 154, 188, 163, false);
                    BOX15.Name = "BOX15";
                    BOX15.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX15.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX15.DrawWidth = 2;
                    BOX15.MultiLine = EvetHayirEnum.ehEvet;
                    BOX15.NoClip = EvetHayirEnum.ehEvet;
                    BOX15.WordBreak = EvetHayirEnum.ehEvet;
                    BOX15.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX15.TextFont.Size = 12;
                    BOX15.TextFont.CharSet = 162;
                    BOX15.Value = @"";

                    BOX14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 154, 118, 163, false);
                    BOX14.Name = "BOX14";
                    BOX14.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX14.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX14.DrawWidth = 2;
                    BOX14.MultiLine = EvetHayirEnum.ehEvet;
                    BOX14.NoClip = EvetHayirEnum.ehEvet;
                    BOX14.WordBreak = EvetHayirEnum.ehEvet;
                    BOX14.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX14.TextFont.Size = 12;
                    BOX14.TextFont.CharSet = 162;
                    BOX14.Value = @"";

                    BOX12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 140, 118, 154, false);
                    BOX12.Name = "BOX12";
                    BOX12.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX12.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX12.DrawWidth = 2;
                    BOX12.MultiLine = EvetHayirEnum.ehEvet;
                    BOX12.NoClip = EvetHayirEnum.ehEvet;
                    BOX12.WordBreak = EvetHayirEnum.ehEvet;
                    BOX12.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX12.TextFont.Size = 12;
                    BOX12.TextFont.CharSet = 162;
                    BOX12.Value = @"";

                    BOX11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 126, 188, 140, false);
                    BOX11.Name = "BOX11";
                    BOX11.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX11.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX11.DrawWidth = 2;
                    BOX11.MultiLine = EvetHayirEnum.ehEvet;
                    BOX11.NoClip = EvetHayirEnum.ehEvet;
                    BOX11.WordBreak = EvetHayirEnum.ehEvet;
                    BOX11.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX11.TextFont.Size = 12;
                    BOX11.TextFont.CharSet = 162;
                    BOX11.Value = @"";

                    BOX1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 126, 118, 140, false);
                    BOX1.Name = "BOX1";
                    BOX1.DrawStyle = DrawStyleConstants.vbSolid;
                    BOX1.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOX1.DrawWidth = 2;
                    BOX1.MultiLine = EvetHayirEnum.ehEvet;
                    BOX1.NoClip = EvetHayirEnum.ehEvet;
                    BOX1.WordBreak = EvetHayirEnum.ehEvet;
                    BOX1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOX1.TextFont.Size = 12;
                    BOX1.TextFont.CharSet = 162;
                    BOX1.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 35, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Tanzim Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 35, 39, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Uzmanlık Dalı";

                    NewField3_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 35, 45, false);
                    NewField3_1.Name = "NewField3_1";
                    NewField3_1.TextFont.Size = 12;
                    NewField3_1.TextFont.Bold = true;
                    NewField3_1.TextFont.CharSet = 162;
                    NewField3_1.Value = @"Epizot No";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 35, 51, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"TC Kimlik No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 6, 135, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 14;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"BORÇ SENEDİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 20, 174, 27, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Size = 12;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"NO:";

                    DEBENTURENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 20, 186, 27, false);
                    DEBENTURENO.Name = "DEBENTURENO";
                    DEBENTURENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTURENO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEBENTURENO.TextFont.Size = 12;
                    DEBENTURENO.TextFont.Bold = true;
                    DEBENTURENO.TextFont.CharSet = 162;
                    DEBENTURENO.Value = @"{#NO#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 28, 38, 33, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.TextFont.Size = 12;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 34, 38, 39, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.TextFont.Size = 12;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 40, 38, 45, false);
                    NewField171.Name = "NewField171";
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.TextFont.Size = 12;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @":";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 46, 38, 51, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Size = 12;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 28, 64, 33, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.TextFont.Size = 12;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{#ACTIONDATE#}";

                    DEPARTMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 34, 64, 39, false);
                    DEPARTMENT.Name = "DEPARTMENT";
                    DEPARTMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPARTMENT.ObjectDefName = "Episode";
                    DEPARTMENT.DataMember = "MAINSPECIALITY.NAME";
                    DEPARTMENT.TextFont.Size = 12;
                    DEPARTMENT.TextFont.CharSet = 162;
                    DEPARTMENT.Value = @"{#EPISODE#}";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 64, 45, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.ObjectDefName = "Episode";
                    EPISODEID.DataMember = "ID";
                    EPISODEID.TextFont.Size = 12;
                    EPISODEID.TextFont.CharSet = 162;
                    EPISODEID.Value = @"{#EPISODE#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 46, 64, 51, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.ObjectDefName = "Patient";
                    UNIQUEREFNO.DataMember = "UNIQUEREFNO";
                    UNIQUEREFNO.TextFont.Size = 12;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#PATIENT#}";

                    LIRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 70, 102, 76, false);
                    LIRA.Name = "LIRA";
                    LIRA.DrawStyle = DrawStyleConstants.vbSolid;
                    LIRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    LIRA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LIRA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LIRA.TextFont.Size = 12;
                    LIRA.TextFont.Bold = true;
                    LIRA.TextFont.CharSet = 162;
                    LIRA.Value = @"";

                    KURUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 70, 134, 76, false);
                    KURUS.Name = "KURUS";
                    KURUS.DrawStyle = DrawStyleConstants.vbSolid;
                    KURUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KURUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KURUS.TextFont.Size = 12;
                    KURUS.TextFont.Bold = true;
                    KURUS.TextFont.CharSet = 162;
                    KURUS.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 64, 102, 69, false);
                    NewField19.Name = "NewField19";
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Size = 12;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Lira";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 64, 134, 69, false);
                    NewField191.Name = "NewField191";
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.TextFont.Size = 12;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Krş.";

                    TEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 83, 189, 104, false);
                    TEXT.Name = "TEXT";
                    TEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT.NoClip = EvetHayirEnum.ehEvet;
                    TEXT.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT.TextFont.Size = 12;
                    TEXT.TextFont.CharSet = 162;
                    TEXT.Value = @"";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 35, 253, 40, false);
                    PRICE.Name = "PRICE";
                    PRICE.Visible = EvetHayirEnum.ehHayir;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.Value = @"{#PRICE#}";

                    GUARANTORSIGN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 226, 188, 235, false);
                    GUARANTORSIGN11.Name = "GUARANTORSIGN11";
                    GUARANTORSIGN11.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTORSIGN11.FillStyle = FillStyleConstants.vbFSTransparent;
                    GUARANTORSIGN11.DrawWidth = 2;
                    GUARANTORSIGN11.MultiLine = EvetHayirEnum.ehEvet;
                    GUARANTORSIGN11.NoClip = EvetHayirEnum.ehEvet;
                    GUARANTORSIGN11.WordBreak = EvetHayirEnum.ehEvet;
                    GUARANTORSIGN11.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUARANTORSIGN11.TextFont.Size = 12;
                    GUARANTORSIGN11.TextFont.CharSet = 162;
                    GUARANTORSIGN11.Value = @"";

                    PATIENTSIGN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 226, 118, 235, false);
                    PATIENTSIGN11.Name = "PATIENTSIGN11";
                    PATIENTSIGN11.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTSIGN11.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATIENTSIGN11.DrawWidth = 2;
                    PATIENTSIGN11.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTSIGN11.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTSIGN11.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTSIGN11.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTSIGN11.TextFont.Size = 12;
                    PATIENTSIGN11.TextFont.CharSet = 162;
                    PATIENTSIGN11.Value = @"";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 226, 48, 235, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1461.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1461.DrawWidth = 2;
                    NewField1461.TextFont.Size = 12;
                    NewField1461.TextFont.Bold = true;
                    NewField1461.TextFont.CharSet = 162;
                    NewField1461.Value = @"İMZA";

                    NewField1451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 203, 48, 226, false);
                    NewField1451.Name = "NewField1451";
                    NewField1451.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1451.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1451.DrawWidth = 2;
                    NewField1451.TextFont.Size = 12;
                    NewField1451.TextFont.Bold = true;
                    NewField1451.TextFont.CharSet = 162;
                    NewField1451.Value = @"İş Adresi ve Telefonu";

                    NewField1441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 181, 48, 203, false);
                    NewField1441.Name = "NewField1441";
                    NewField1441.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1441.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1441.DrawWidth = 2;
                    NewField1441.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1441.NoClip = EvetHayirEnum.ehEvet;
                    NewField1441.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1441.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1441.TextFont.Size = 12;
                    NewField1441.TextFont.Bold = true;
                    NewField1441.TextFont.CharSet = 162;
                    NewField1441.Value = @"İkametgah Adresi
ve Telefonu";

                    NewField1431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 163, 48, 181, false);
                    NewField1431.Name = "NewField1431";
                    NewField1431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1431.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1431.DrawWidth = 2;
                    NewField1431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1431.NoClip = EvetHayirEnum.ehEvet;
                    NewField1431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1431.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1431.TextFont.Size = 12;
                    NewField1431.TextFont.Bold = true;
                    NewField1431.TextFont.CharSet = 162;
                    NewField1431.Value = @"Nüfusa Kayıtlı olduğu
İl-İlçe ve Köy";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 154, 48, 163, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1421.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1421.DrawWidth = 2;
                    NewField1421.TextFont.Size = 12;
                    NewField1421.TextFont.Bold = true;
                    NewField1421.TextFont.CharSet = 162;
                    NewField1421.Value = @"Cilt-Sayfa-Kütük No";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 140, 48, 154, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1411.DrawWidth = 2;
                    NewField1411.TextFont.Size = 12;
                    NewField1411.TextFont.Bold = true;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"Baba Adı";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 126, 48, 140, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1141.DrawWidth = 2;
                    NewField1141.TextFont.Size = 12;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Adı ve Soyadı";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 119, 188, 126, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1131.DrawWidth = 2;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.TextFont.Size = 12;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"KEFİL";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 119, 118, 126, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1121.DrawWidth = 2;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.TextFont.Size = 12;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"BORÇLU";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 119, 48, 126, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1111.DrawWidth = 2;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"KİMLİĞİ";

                    DUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 43, 253, 48, false);
                    DUEDATE.Name = "DUEDATE";
                    DUEDATE.Visible = EvetHayirEnum.ehHayir;
                    DUEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUEDATE.TextFormat = @"Short Date";
                    DUEDATE.Value = @"{#DUEDATE#}";

                    NewField193 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 245, 51, 250, false);
                    NewField193.Name = "NewField193";
                    NewField193.TextFont.Size = 12;
                    NewField193.TextFont.Bold = true;
                    NewField193.TextFont.CharSet = 162;
                    NewField193.Value = @"Senedi Tanzim Eden    :";

                    NewField1391 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 252, 51, 257, false);
                    NewField1391.Name = "NewField1391";
                    NewField1391.TextFont.Size = 12;
                    NewField1391.TextFont.Bold = true;
                    NewField1391.TextFont.CharSet = 162;
                    NewField1391.Value = @"Açıklama                      :";

                    USER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 245, 90, 250, false);
                    USER.Name = "USER";
                    USER.FieldType = ReportFieldTypeEnum.ftVariable;
                    USER.TextFont.Size = 12;
                    USER.TextFont.CharSet = 162;
                    USER.Value = @"";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 125, 242, 130, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.ObjectDefName = "Patient";
                    PNAME.DataMember = "NAME";
                    PNAME.Value = @"{#PATIENT#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 125, 270, 130, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.ObjectDefName = "Patient";
                    PSURNAME.DataMember = "SURNAME";
                    PSURNAME.Value = @"{#PATIENT#}";

                    HOSPITALDSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 63, 257, 68, false);
                    HOSPITALDSNAME.Name = "HOSPITALDSNAME";
                    HOSPITALDSNAME.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALDSNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALDSNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDSNAME"", """")";

                    HOSPITALCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 73, 268, 78, false);
                    HOSPITALCITY.Name = "HOSPITALCITY";
                    HOSPITALCITY.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALCITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCITY.TextFont.Size = 12;
                    HOSPITALCITY.TextFont.CharSet = 162;
                    HOSPITALCITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Debenture.DebentureReportQuery_Class dataset_DebentureReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Debenture.DebentureReportQuery_Class>(0);
                    BOX13.CalcValue = BOX13.Value;
                    BOX21.CalcValue = BOX21.Value;
                    BOX20.CalcValue = BOX20.Value;
                    BOX19.CalcValue = BOX19.Value;
                    BOX18.CalcValue = BOX18.Value;
                    BOX17.CalcValue = BOX17.Value;
                    BOX16.CalcValue = BOX16.Value;
                    BOX15.CalcValue = BOX15.Value;
                    BOX14.CalcValue = BOX14.Value;
                    BOX12.CalcValue = BOX12.Value;
                    BOX11.CalcValue = BOX11.Value;
                    BOX1.CalcValue = BOX1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField3_1.CalcValue = NewField3_1.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField15.CalcValue = NewField15.Value;
                    DEBENTURENO.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.No) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    DATE.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.ActionDate) : "");
                    DEPARTMENT.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.Episode) : "");
                    DEPARTMENT.PostFieldValueCalculation();
                    EPISODEID.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.Episode) : "");
                    EPISODEID.PostFieldValueCalculation();
                    UNIQUEREFNO.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.Patient) : "");
                    UNIQUEREFNO.PostFieldValueCalculation();
                    LIRA.CalcValue = @"";
                    KURUS.CalcValue = @"";
                    NewField19.CalcValue = NewField19.Value;
                    NewField191.CalcValue = NewField191.Value;
                    TEXT.CalcValue = @"";
                    PRICE.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.Price) : "");
                    GUARANTORSIGN11.CalcValue = GUARANTORSIGN11.Value;
                    PATIENTSIGN11.CalcValue = PATIENTSIGN11.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField1451.CalcValue = NewField1451.Value;
                    NewField1441.CalcValue = NewField1441.Value;
                    NewField1431.CalcValue = NewField1431.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    DUEDATE.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.DueDate) : "");
                    NewField193.CalcValue = NewField193.Value;
                    NewField1391.CalcValue = NewField1391.Value;
                    USER.CalcValue = @"";
                    PNAME.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.Patient) : "");
                    PNAME.PostFieldValueCalculation();
                    PSURNAME.CalcValue = (dataset_DebentureReportQuery != null ? Globals.ToStringCore(dataset_DebentureReportQuery.Patient) : "");
                    PSURNAME.PostFieldValueCalculation();
                    HOSPITALDSNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDSNAME", "");
                    HOSPITALCITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { BOX13,BOX21,BOX20,BOX19,BOX18,BOX17,BOX16,BOX15,BOX14,BOX12,BOX11,BOX1,NewField11,NewField12,NewField3_1,NewField14,NewField13,NewField15,DEBENTURENO,NewField16,NewField161,NewField171,NewField181,DATE,DEPARTMENT,EPISODEID,UNIQUEREFNO,LIRA,KURUS,NewField19,NewField191,TEXT,PRICE,GUARANTORSIGN11,PATIENTSIGN11,NewField1461,NewField1451,NewField1441,NewField1431,NewField1421,NewField1411,NewField1141,NewField1131,NewField1121,NewField1111,DUEDATE,NewField193,NewField1391,USER,PNAME,PSURNAME,HOSPITALDSNAME,HOSPITALCITY};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string s = new string (' ',15) ;
//            if ((this.PRICE.CalcValue.ToString()).Split(',').Length == 2)
//            {
//                this.LIRA.CalcValue = (string)(this.PRICE.CalcValue.ToString()).Split(',')[0];
//                this.KURUS.CalcValue = (this.PRICE.CalcValue.ToString()).Split(',')[1];
//            }
//            else if ((this.PRICE.CalcValue.ToString()).Split(',').Length == 1)
//            {
//                this.LIRA.CalcValue = (this.PRICE.CalcValue.ToString()).Split(',')[0];
//                this.KURUS.CalcValue = "0";
//            }
//            this.PATIENTNAME.CalcValue = this.PNAME.CalcValue.ToString() + " " + this.PSURNAME.CalcValue.ToString();
//            this.GUARANTORIDENTITYINFO.CalcValue = this.GVOLUMENO.CalcValue.ToString() + "-" + this.GPAGENO.CalcValue.ToString() + "-" + this.GFAMILYORDERNO.CalcValue.ToString() ;
//            this.GUARANTORHOMEADDRESS.CalcValue = this.GHOMEADDRESS.CalcValue.ToString() + " " + this.GHOMEPHONE.CalcValue.ToString();
//            this.GUARANTORWORKADDRESS.CalcValue = this.GWORKADDRESS.CalcValue.ToString() + " " + this.GWORKPHONE.CalcValue.ToString();
//            this.GUARANTORBIRTHINFO.CalcValue = this.GCITYOFREGISTRY.CalcValue.ToString() + "-" + this.GTOWNOFREGISTRY.CalcValue.ToString() + "-" + this.GVILLAGEOFREGISTRY.CalcValue.ToString() ;
//            // listeden gelen degerler null gelirse hata verdiigi icin eskisi gibi yapıldı,gecildi...
//            //            TTObjectContext context = new TTObjectContext(true);
//            //            string sObjectID = this.PATIENTOBJECTID.CalcValue.ToString();
//            //            Patient p = (Patient)context.GetObject(new Guid(sObjectID),"Patient");
//            //            this.PATIENTBIRTHINFO.CalcValue = Convert.ToString(p.CityOfBirth.Name) + "-" + Convert.ToString(p.TownOfBirth.Name) ;
//            //            this.PATIENTHOMEADDRESS.CalcValue = Convert.ToString(p.HomeAddress) + " " + Convert.ToString(p.HomeCity.Name) + " " + Convert.ToString(p.HomeTown.Name) + " " + Convert.ToString(p.HomePhone);
//            this.PATIENTBIRTHINFO.CalcValue = this.PCITYOFBIRTH.CalcValue.ToString() + "-" + this.PTOWNOFBIRTH.CalcValue.ToString() ;
//            this.PATIENTHOMEADDRESS.CalcValue =  this.PHOMEADDRESS.CalcValue.ToString() + " " + this.PHOMECITY.CalcValue.ToString() + " " + this.PHOMETOWN.CalcValue.ToString() + " " + this.PHOMEPHONE.CalcValue.ToString();
//            this.TEXT.CalcValue = s + this.HOSPITALDSNAME.CalcValue.ToString() + "ne tedavi bedeli olarak " + this.PRICE.FormattedValue.ToString() + " Lira borçlanmış bulunmaktayım.\n" + s + "Bu borcumu  " + this.DUEDATE.FormattedValue.ToString() + " tarihinde ödeyeceğimi şimdiden kabul ve taahhüt ediyorum.\n" + s + "Aksi takdirde, tahsilat icrası için hakkımda yapılacak kanuni muameleye hiçbir itirazım olmayacağını ve merci olarak " + this.HOSPITALCITY.CalcValue.ToString() + " Mahkemelerini, ikametime tevcih edildiği takdirde Mahalli Mahkemelerinin takip ve icrasını kabul edeceğime dair iş bu borç senedini imza ediyorum.";
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

        public CorrectedDebentureReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CORRECTEDDEBENTUREREPORT";
            Caption = "Borç Senedi";
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