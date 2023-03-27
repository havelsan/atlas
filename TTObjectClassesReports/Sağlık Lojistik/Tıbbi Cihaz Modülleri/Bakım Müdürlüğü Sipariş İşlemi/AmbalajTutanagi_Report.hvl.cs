
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
    /// Ambalaj Tutanağı
    /// </summary>
    public partial class AmbalajTutanagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? UYE1 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? UYE2 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? UYE3 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? BASKAN = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public AmbalajTutanagi MyParentReport
            {
                get { return (AmbalajTutanagi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField REPORTNAME11 { get {return Header().REPORTNAME11;} }
            public TTReportField REPORTNAME12 { get {return Header().REPORTNAME12;} }
            public TTReportField REPORTNAME121 { get {return Header().REPORTNAME121;} }
            public TTReportField REPORTNAME122 { get {return Header().REPORTNAME122;} }
            public TTReportField REPORTNAME1121 { get {return Header().REPORTNAME1121;} }
            public TTReportField REPORTNAME11211 { get {return Header().REPORTNAME11211;} }
            public TTReportField REPORTNAME1122 { get {return Header().REPORTNAME1122;} }
            public TTReportField REPORTNAME123 { get {return Header().REPORTNAME123;} }
            public TTReportField REPORTNAME1321 { get {return Header().REPORTNAME1321;} }
            public TTReportField REPORTNAME11231 { get {return Header().REPORTNAME11231;} }
            public TTReportField REPORTNAME1322 { get {return Header().REPORTNAME1322;} }
            public TTReportField REPORTNAME12231 { get {return Header().REPORTNAME12231;} }
            public TTReportField REPORTNAME12232 { get {return Header().REPORTNAME12232;} }
            public TTReportField DELIVERER { get {return Header().DELIVERER;} }
            public TTReportField RECEIVER { get {return Header().RECEIVER;} }
            public TTReportField MARKMODELSERIALNO { get {return Footer().MARKMODELSERIALNO;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NATOSTOCKNO { get {return Footer().NATOSTOCKNO;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine11211 { get {return Footer().NewLine11211;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
            public TTReportShape NewLine11212 { get {return Footer().NewLine11212;} }
            public TTReportShape NewLine122 { get {return Footer().NewLine122;} }
            public TTReportShape NewLine1113 { get {return Footer().NewLine1113;} }
            public TTReportShape NewLine1221 { get {return Footer().NewLine1221;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportField ORDERNO { get {return Footer().ORDERNO;} }
            public TTReportField BASKAN1 { get {return Footer().BASKAN1;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField OBASKAN { get {return Footer().OBASKAN;} }
            public TTReportField OUYE1 { get {return Footer().OUYE1;} }
            public TTReportField UYE11 { get {return Footer().UYE11;} }
            public TTReportField OUYE2 { get {return Footer().OUYE2;} }
            public TTReportField UYE12 { get {return Footer().UYE12;} }
            public TTReportField OUYE3 { get {return Footer().OUYE3;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public AmbalajTutanagi MyParentReport
                {
                    get { return (AmbalajTutanagi)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField REPORTNAME1;
                public TTReportField REPORTNAME11;
                public TTReportField REPORTNAME12;
                public TTReportField REPORTNAME121;
                public TTReportField REPORTNAME122;
                public TTReportField REPORTNAME1121;
                public TTReportField REPORTNAME11211;
                public TTReportField REPORTNAME1122;
                public TTReportField REPORTNAME123;
                public TTReportField REPORTNAME1321;
                public TTReportField REPORTNAME11231;
                public TTReportField REPORTNAME1322;
                public TTReportField REPORTNAME12231;
                public TTReportField REPORTNAME12232;
                public TTReportField DELIVERER;
                public TTReportField RECEIVER; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 195, 6, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.DrawWidth = 2;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"TUTANAK";

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 90, 21, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1.DrawWidth = 2;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 8;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @" Geldiği Yer :";

                    REPORTNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 6, 195, 21, false);
                    REPORTNAME11.Name = "REPORTNAME11";
                    REPORTNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11.DrawWidth = 2;
                    REPORTNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11.TextFont.Name = "Arial";
                    REPORTNAME11.TextFont.Size = 8;
                    REPORTNAME11.TextFont.Bold = true;
                    REPORTNAME11.TextFont.CharSet = 162;
                    REPORTNAME11.Value = @" Alacak Olan :";

                    REPORTNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 21, 34, 29, false);
                    REPORTNAME12.Name = "REPORTNAME12";
                    REPORTNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME12.DrawWidth = 2;
                    REPORTNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME12.TextFont.Name = "Arial";
                    REPORTNAME12.TextFont.Size = 8;
                    REPORTNAME12.TextFont.Bold = true;
                    REPORTNAME12.TextFont.CharSet = 162;
                    REPORTNAME12.Value = @" Taşıt :";

                    REPORTNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 21, 90, 29, false);
                    REPORTNAME121.Name = "REPORTNAME121";
                    REPORTNAME121.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME121.DrawWidth = 2;
                    REPORTNAME121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME121.TextFont.Name = "Arial";
                    REPORTNAME121.TextFont.Size = 8;
                    REPORTNAME121.TextFont.Bold = true;
                    REPORTNAME121.TextFont.CharSet = 162;
                    REPORTNAME121.Value = @" Taşıt Nu. :";

                    REPORTNAME122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 21, 65, 29, false);
                    REPORTNAME122.Name = "REPORTNAME122";
                    REPORTNAME122.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME122.DrawWidth = 2;
                    REPORTNAME122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME122.TextFont.Name = "Arial";
                    REPORTNAME122.TextFont.Size = 8;
                    REPORTNAME122.TextFont.Bold = true;
                    REPORTNAME122.TextFont.CharSet = 162;
                    REPORTNAME122.Value = @"";

                    REPORTNAME1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 21, 133, 29, false);
                    REPORTNAME1121.Name = "REPORTNAME1121";
                    REPORTNAME1121.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1121.DrawWidth = 2;
                    REPORTNAME1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1121.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME1121.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME1121.TextFont.Name = "Arial";
                    REPORTNAME1121.TextFont.Size = 8;
                    REPORTNAME1121.TextFont.Bold = true;
                    REPORTNAME1121.TextFont.CharSet = 162;
                    REPORTNAME1121.Value = @" Taşıta Ait Belge
 Nu. :";

                    REPORTNAME11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 21, 195, 29, false);
                    REPORTNAME11211.Name = "REPORTNAME11211";
                    REPORTNAME11211.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11211.DrawWidth = 2;
                    REPORTNAME11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11211.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME11211.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME11211.TextFont.Name = "Arial";
                    REPORTNAME11211.TextFont.Size = 8;
                    REPORTNAME11211.TextFont.Bold = true;
                    REPORTNAME11211.TextFont.CharSet = 162;
                    REPORTNAME11211.Value = @" Belge
 Kayıt Nu. :";

                    REPORTNAME1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 21, 167, 29, false);
                    REPORTNAME1122.Name = "REPORTNAME1122";
                    REPORTNAME1122.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1122.DrawWidth = 2;
                    REPORTNAME1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1122.TextFont.Name = "Arial";
                    REPORTNAME1122.TextFont.Size = 8;
                    REPORTNAME1122.TextFont.Bold = true;
                    REPORTNAME1122.TextFont.CharSet = 162;
                    REPORTNAME1122.Value = @" Kontrat Nu. :";

                    REPORTNAME123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 29, 34, 37, false);
                    REPORTNAME123.Name = "REPORTNAME123";
                    REPORTNAME123.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME123.DrawWidth = 2;
                    REPORTNAME123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME123.TextFont.Name = "Arial";
                    REPORTNAME123.TextFont.Size = 8;
                    REPORTNAME123.TextFont.Bold = true;
                    REPORTNAME123.TextFont.CharSet = 162;
                    REPORTNAME123.Value = @"Ambalaj Nu.";

                    REPORTNAME1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 29, 65, 37, false);
                    REPORTNAME1321.Name = "REPORTNAME1321";
                    REPORTNAME1321.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1321.DrawWidth = 2;
                    REPORTNAME1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1321.TextFont.Name = "Arial";
                    REPORTNAME1321.TextFont.Size = 8;
                    REPORTNAME1321.TextFont.Bold = true;
                    REPORTNAME1321.TextFont.CharSet = 162;
                    REPORTNAME1321.Value = @"NATO Stok Nu.";

                    REPORTNAME11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 29, 133, 37, false);
                    REPORTNAME11231.Name = "REPORTNAME11231";
                    REPORTNAME11231.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11231.DrawWidth = 2;
                    REPORTNAME11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11231.TextFont.Name = "Arial";
                    REPORTNAME11231.TextFont.Size = 8;
                    REPORTNAME11231.TextFont.Bold = true;
                    REPORTNAME11231.TextFont.CharSet = 162;
                    REPORTNAME11231.Value = @"Fenni İsim ve Parça Nu.";

                    REPORTNAME1322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 29, 148, 37, false);
                    REPORTNAME1322.Name = "REPORTNAME1322";
                    REPORTNAME1322.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1322.DrawWidth = 2;
                    REPORTNAME1322.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1322.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1322.TextFont.Name = "Arial";
                    REPORTNAME1322.TextFont.Size = 8;
                    REPORTNAME1322.TextFont.Bold = true;
                    REPORTNAME1322.TextFont.CharSet = 162;
                    REPORTNAME1322.Value = @"Miktar";

                    REPORTNAME12231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 29, 167, 37, false);
                    REPORTNAME12231.Name = "REPORTNAME12231";
                    REPORTNAME12231.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME12231.DrawWidth = 2;
                    REPORTNAME12231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME12231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME12231.TextFont.Name = "Arial";
                    REPORTNAME12231.TextFont.Size = 8;
                    REPORTNAME12231.TextFont.Bold = true;
                    REPORTNAME12231.TextFont.CharSet = 162;
                    REPORTNAME12231.Value = @"Ölçü Cinsi";

                    REPORTNAME12232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 29, 195, 37, false);
                    REPORTNAME12232.Name = "REPORTNAME12232";
                    REPORTNAME12232.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME12232.DrawWidth = 2;
                    REPORTNAME12232.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME12232.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME12232.TextFont.Name = "Arial";
                    REPORTNAME12232.TextFont.Size = 8;
                    REPORTNAME12232.TextFont.Bold = true;
                    REPORTNAME12232.TextFont.CharSet = 162;
                    REPORTNAME12232.Value = @"Düşünceler";

                    DELIVERER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 7, 89, 19, false);
                    DELIVERER.Name = "DELIVERER";
                    DELIVERER.FieldType = ReportFieldTypeEnum.ftExpression;
                    DELIVERER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVERER.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVERER.WordBreak = EvetHayirEnum.ehEvet;
                    DELIVERER.TextFont.Name = "Arial";
                    DELIVERER.TextFont.Size = 8;
                    DELIVERER.TextFont.CharSet = 162;
                    DELIVERER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    RECEIVER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 7, 194, 20, false);
                    RECEIVER.Name = "RECEIVER";
                    RECEIVER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RECEIVER.MultiLine = EvetHayirEnum.ehEvet;
                    RECEIVER.WordBreak = EvetHayirEnum.ehEvet;
                    RECEIVER.ObjectDefName = "ReferToUpperLevel";
                    RECEIVER.DataMember = "OWNERMILITARYUNIT.NAME";
                    RECEIVER.TextFont.Name = "Arial";
                    RECEIVER.TextFont.Size = 8;
                    RECEIVER.TextFont.CharSet = 162;
                    RECEIVER.Value = @"{#RULOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    REPORTNAME11.CalcValue = REPORTNAME11.Value;
                    REPORTNAME12.CalcValue = REPORTNAME12.Value;
                    REPORTNAME121.CalcValue = REPORTNAME121.Value;
                    REPORTNAME122.CalcValue = REPORTNAME122.Value;
                    REPORTNAME1121.CalcValue = REPORTNAME1121.Value;
                    REPORTNAME11211.CalcValue = REPORTNAME11211.Value;
                    REPORTNAME1122.CalcValue = REPORTNAME1122.Value;
                    REPORTNAME123.CalcValue = REPORTNAME123.Value;
                    REPORTNAME1321.CalcValue = REPORTNAME1321.Value;
                    REPORTNAME11231.CalcValue = REPORTNAME11231.Value;
                    REPORTNAME1322.CalcValue = REPORTNAME1322.Value;
                    REPORTNAME12231.CalcValue = REPORTNAME12231.Value;
                    REPORTNAME12232.CalcValue = REPORTNAME12232.Value;
                    RECEIVER.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Rulobjectid) : "");
                    RECEIVER.PostFieldValueCalculation();
                    DELIVERER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME,REPORTNAME1,REPORTNAME11,REPORTNAME12,REPORTNAME121,REPORTNAME122,REPORTNAME1121,REPORTNAME11211,REPORTNAME1122,REPORTNAME123,REPORTNAME1321,REPORTNAME11231,REPORTNAME1322,REPORTNAME12231,REPORTNAME12232,RECEIVER,DELIVERER};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public AmbalajTutanagi MyParentReport
                {
                    get { return (AmbalajTutanagi)ParentReport; }
                }
                
                public TTReportField MARKMODELSERIALNO;
                public TTReportField NewField13;
                public TTReportField NATOSTOCKNO;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine12;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine11212;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1113;
                public TTReportShape NewLine1221;
                public TTReportShape NewLine13;
                public TTReportField ORDERNO;
                public TTReportField BASKAN1;
                public TTReportField UYE1;
                public TTReportField OBASKAN;
                public TTReportField OUYE1;
                public TTReportField UYE11;
                public TTReportField OUYE2;
                public TTReportField UYE12;
                public TTReportField OUYE3; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 107;
                    RepeatCount = 0;
                    
                    MARKMODELSERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 5, 194, 10, false);
                    MARKMODELSERIALNO.Name = "MARKMODELSERIALNO";
                    MARKMODELSERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODELSERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKMODELSERIALNO.NoClip = EvetHayirEnum.ehEvet;
                    MARKMODELSERIALNO.TextFont.Name = "Arial";
                    MARKMODELSERIALNO.TextFont.Size = 8;
                    MARKMODELSERIALNO.TextFont.CharSet = 162;
                    MARKMODELSERIALNO.Value = @"{#MARK#} - {#MODEL#} - {#SERIALNUMBER#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 195, 5, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 7;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @" Yukarıda cins ve miktarı belirtilen shh. sınıfı XXXXXX malları tam, hasarsız ve faal olarak aşağıdaki heyet huzurunda ambalajlanmıştır.";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 5, 64, 10, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.NoClip = EvetHayirEnum.ehEvet;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @" {#NATOSTOCKNO#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 10, 34, 18, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" İLGİ :";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 5, 34, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" Açıklama :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 34, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" Açıklama :";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 5, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 5, 195, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 5, 15, 10, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 5, 34, 10, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 10, 195, 10, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 10, 15, 52, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.DrawWidth = 2;

                    NewLine11212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 10, 34, 18, false);
                    NewLine11212.Name = "NewLine11212";
                    NewLine11212.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 18, 195, 18, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.DrawWidth = 2;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 0, 195, 52, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1113.DrawWidth = 2;

                    NewLine1221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 52, 195, 52, false);
                    NewLine1221.Name = "NewLine1221";
                    NewLine1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1221.DrawWidth = 2;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 195, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 11, 97, 17, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.NoClip = EvetHayirEnum.ehEvet;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    BASKAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 22, 189, 27, false);
                    BASKAN1.Name = "BASKAN1";
                    BASKAN1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASKAN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASKAN1.WordBreak = EvetHayirEnum.ehEvet;
                    BASKAN1.TextFont.Bold = true;
                    BASKAN1.TextFont.CharSet = 162;
                    BASKAN1.Value = @"BAŞKAN";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 22, 53, 27, false);
                    UYE1.Name = "UYE1";
                    UYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYE1.WordBreak = EvetHayirEnum.ehEvet;
                    UYE1.TextFont.Bold = true;
                    UYE1.TextFont.CharSet = 162;
                    UYE1.Value = @"ÜYE";

                    OBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 29, 189, 46, false);
                    OBASKAN.Name = "OBASKAN";
                    OBASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBASKAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OBASKAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    OBASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    OBASKAN.TextFont.CharSet = 162;
                    OBASKAN.Value = @"";

                    OUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 29, 53, 47, false);
                    OUYE1.Name = "OUYE1";
                    OUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OUYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    OUYE1.WordBreak = EvetHayirEnum.ehEvet;
                    OUYE1.TextFont.CharSet = 162;
                    OUYE1.Value = @"";

                    UYE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 22, 98, 27, false);
                    UYE11.Name = "UYE11";
                    UYE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYE11.WordBreak = EvetHayirEnum.ehEvet;
                    UYE11.TextFont.Bold = true;
                    UYE11.TextFont.CharSet = 162;
                    UYE11.Value = @"ÜYE";

                    OUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 29, 98, 47, false);
                    OUYE2.Name = "OUYE2";
                    OUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUYE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OUYE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OUYE2.MultiLine = EvetHayirEnum.ehEvet;
                    OUYE2.WordBreak = EvetHayirEnum.ehEvet;
                    OUYE2.TextFont.CharSet = 162;
                    OUYE2.Value = @"";

                    UYE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 22, 144, 27, false);
                    UYE12.Name = "UYE12";
                    UYE12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYE12.WordBreak = EvetHayirEnum.ehEvet;
                    UYE12.TextFont.Bold = true;
                    UYE12.TextFont.CharSet = 162;
                    UYE12.Value = @"ÜYE";

                    OUYE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 29, 144, 47, false);
                    OUYE3.Name = "OUYE3";
                    OUYE3.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUYE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OUYE3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OUYE3.MultiLine = EvetHayirEnum.ehEvet;
                    OUYE3.WordBreak = EvetHayirEnum.ehEvet;
                    OUYE3.TextFont.CharSet = 162;
                    OUYE3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    MARKMODELSERIALNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "") + @" - " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "") + @" - " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    NewField13.CalcValue = NewField13.Value;
                    NATOSTOCKNO.CalcValue = @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    ORDERNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    BASKAN1.CalcValue = BASKAN1.Value;
                    UYE1.CalcValue = UYE1.Value;
                    OBASKAN.CalcValue = @"";
                    OUYE1.CalcValue = @"";
                    UYE11.CalcValue = UYE11.Value;
                    OUYE2.CalcValue = @"";
                    UYE12.CalcValue = UYE12.Value;
                    OUYE3.CalcValue = @"";
                    return new TTReportObject[] { MARKMODELSERIALNO,NewField13,NATOSTOCKNO,NewField12,NewField11,NewField1,ORDERNO,BASKAN1,UYE1,OBASKAN,OUYE1,UYE11,OUYE2,UYE12,OUYE3};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    if(this.MyParentReport.RuntimeParameters.UYE1 != System.Guid.Empty)
            {
                if (this.MyParentReport.RuntimeParameters.UYE1.HasValue)
                {
                    ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.UYE1.Value, typeof(ResUser));
                    OUYE1.CalcValue = muaKontR.Name+"\r\n";
                    OUYE1.CalcValue += (muaKontR.MilitaryClass!=null)?muaKontR.MilitaryClass.ShortName:"";
                    OUYE1.CalcValue += (muaKontR.Rank!=null)?muaKontR.Rank.ShortName+"\r\n":"";
                    OUYE1.CalcValue += (muaKontR.EmploymentRecordID!=null)?"("+muaKontR.EmploymentRecordID.ToString()+")":"";
                }
            }
            else
                OUYE1.CalcValue="";
            
            if(this.MyParentReport.RuntimeParameters.UYE2 != System.Guid.Empty)
            {
                if (this.MyParentReport.RuntimeParameters.UYE2.HasValue)
                {
                    ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.UYE2.Value, typeof(ResUser));
                    OUYE2.CalcValue = muaKontR.Name+"\r\n";
                    OUYE2.CalcValue += (muaKontR.MilitaryClass!=null)?muaKontR.MilitaryClass.ShortName:"";
                    OUYE2.CalcValue += (muaKontR.Rank!=null)?muaKontR.Rank.ShortName+"\r\n":"";
                    OUYE2.CalcValue += (muaKontR.EmploymentRecordID!=null)?"("+muaKontR.EmploymentRecordID.ToString()+")":"";
                }
            }
            else
                OUYE2.CalcValue="";
            
            if(this.MyParentReport.RuntimeParameters.UYE3 != System.Guid.Empty)
            {
                if (this.MyParentReport.RuntimeParameters.UYE3.HasValue)
                {
                    ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.UYE3.Value, typeof(ResUser));
                    OUYE3.CalcValue = muaKontR.Name+"\r\n";
                    OUYE3.CalcValue += (muaKontR.MilitaryClass!=null)?muaKontR.MilitaryClass.ShortName:"";
                    OUYE3.CalcValue += (muaKontR.Rank!=null)?muaKontR.Rank.ShortName+"\r\n":"";
                    OUYE3.CalcValue += (muaKontR.EmploymentRecordID!=null)?"("+muaKontR.EmploymentRecordID.ToString()+")":"";
                }
            }
            else
                OUYE3.CalcValue="";
            
            if(this.MyParentReport.RuntimeParameters.BASKAN != System.Guid.Empty)
            {
                if (this.MyParentReport.RuntimeParameters.BASKAN.HasValue)
                {
                    ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.BASKAN.Value, typeof(ResUser));
                    OBASKAN.CalcValue = muaKontR.Name+"\r\n";
                    OBASKAN.CalcValue += (muaKontR.MilitaryClass!=null)?muaKontR.MilitaryClass.ShortName:"";
                    OBASKAN.CalcValue += (muaKontR.Rank!=null)?muaKontR.Rank.ShortName+"\r\n":"";
                    OBASKAN.CalcValue += (muaKontR.EmploymentRecordID!=null)?"("+muaKontR.EmploymentRecordID.ToString()+")":"";
                }
            }
            else
                OBASKAN.CalcValue="";
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public AmbalajTutanagi MyParentReport
            {
                get { return (AmbalajTutanagi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Header().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField PACKAGENO { get {return Header().PACKAGENO;} }
            public TTReportField NATOSTOCKNO { get {return Header().NATOSTOCKNO;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine122 { get {return Header().NewLine122;} }
            public TTReportShape NewLine123 { get {return Header().NewLine123;} }
            public TTReportShape NewLine124 { get {return Header().NewLine124;} }
            public TTReportField MUHTEVIYAT { get {return Header().MUHTEVIYAT;} }
            public TTReportField RULOBJECTID { get {return Header().RULOBJECTID;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine125 { get {return Footer().NewLine125;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public TTReportShape NewLine1221 { get {return Footer().NewLine1221;} }
            public TTReportShape NewLine1321 { get {return Footer().NewLine1321;} }
            public TTReportShape NewLine1421 { get {return Footer().NewLine1421;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField COUNT { get {return Footer().COUNT;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataSet_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceOrderByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderByObjectIDQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public AmbalajTutanagi MyParentReport
                {
                    get { return (AmbalajTutanagi)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField MATERIALNAME;
                public TTReportField PACKAGENO;
                public TTReportField NATOSTOCKNO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine123;
                public TTReportShape NewLine124;
                public TTReportField MUHTEVIYAT;
                public TTReportField RULOBJECTID; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 195, 11, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 167, 11, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#PARTA.DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 148, 11, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PARTA.AMOUNT#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 133, 11, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 8;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#PARTA.FIXEDASSETNAME#}";

                    PACKAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 34, 11, false);
                    PACKAGENO.Name = "PACKAGENO";
                    PACKAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PACKAGENO.TextFont.Name = "Arial";
                    PACKAGENO.TextFont.Size = 8;
                    PACKAGENO.TextFont.CharSet = 162;
                    PACKAGENO.Value = @"{@groupcounter@}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 65, 11, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#PARTA.NATOSTOCKNO#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 20, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 0, 195, 20, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 20, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 0, 65, 20, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 133, 0, 133, 20, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 148, 0, 148, 20, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 167, 0, 167, 20, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;

                    MUHTEVIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 12, 119, 17, false);
                    MUHTEVIYAT.Name = "MUHTEVIYAT";
                    MUHTEVIYAT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUHTEVIYAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUHTEVIYAT.TextFont.Name = "Arial";
                    MUHTEVIYAT.TextFont.Size = 9;
                    MUHTEVIYAT.TextFont.Bold = true;
                    MUHTEVIYAT.TextFont.CharSet = 162;
                    MUHTEVIYAT.Value = @"MUHTEVİYAT";

                    RULOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 6, 240, 11, false);
                    RULOBJECTID.Name = "RULOBJECTID";
                    RULOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    RULOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    RULOBJECTID.Value = @"{#PARTA.RULOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    DESCRIPTION.CalcValue = @"";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "");
                    MATERIALNAME.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    PACKAGENO.CalcValue = ParentGroup.GroupCounter.ToString();
                    NATOSTOCKNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    MUHTEVIYAT.CalcValue = MUHTEVIYAT.Value;
                    RULOBJECTID.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Rulobjectid) : "");
                    return new TTReportObject[] { DESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,MATERIALNAME,PACKAGENO,NATOSTOCKNO,MUHTEVIYAT,RULOBJECTID};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public AmbalajTutanagi MyParentReport
                {
                    get { return (AmbalajTutanagi)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportShape NewLine13;
                public TTReportShape NewLine111;
                public TTReportShape NewLine125;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1221;
                public TTReportShape NewLine1321;
                public TTReportShape NewLine1421;
                public TTReportField COUNTTEXT;
                public TTReportField COUNT;
                public TTReportField AMOUNTTEXT; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 4, 133, 9, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.NoClip = EvetHayirEnum.ehEvet;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.Size = 9;
                    TOTAL.TextFont.Bold = true;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"""YALNIZ ("" + COUNT.FormattedValue + "") "" + COUNTTEXT.FormattedValue + "" KALEM ("" + {#PARTA.AMOUNT#} + "") "" + AMOUNTTEXT.FormattedValue + "" ADETTİR.""";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 15, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 0, 195, 15, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine125 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 15, false);
                    NewLine125.Name = "NewLine125";
                    NewLine125.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 0, 65, 15, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 133, 0, 133, 15, false);
                    NewLine1221.Name = "NewLine1221";
                    NewLine1221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 148, 0, 148, 15, false);
                    NewLine1321.Name = "NewLine1321";
                    NewLine1321.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1421 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 167, 0, 167, 15, false);
                    NewLine1421.Name = "NewLine1421";
                    NewLine1421.DrawStyle = DrawStyleConstants.vbSolid;

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 5, 244, 10, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.TextFormat = @"NUMBERTEXT";
                    COUNTTEXT.Value = @"{@groupcounter@}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 5, 272, 10, false);
                    COUNT.Name = "COUNT";
                    COUNT.Visible = EvetHayirEnum.ehHayir;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.Value = @"{@groupcounter@}";

                    AMOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 275, 5, 300, 10, false);
                    AMOUNTTEXT.Name = "AMOUNTTEXT";
                    AMOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    AMOUNTTEXT.Value = @"{#PARTA.AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    COUNTTEXT.CalcValue = ParentGroup.GroupCounter.ToString();
                    COUNT.CalcValue = ParentGroup.GroupCounter.ToString();
                    AMOUNTTEXT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "");
                    TOTAL.CalcValue = "YALNIZ (" + COUNT.FormattedValue + ") " + COUNTTEXT.FormattedValue + " KALEM (" + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "") + ") " + AMOUNTTEXT.FormattedValue + " ADETTİR.";
                    return new TTReportObject[] { COUNTTEXT,COUNT,AMOUNTTEXT,TOTAL};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public AmbalajTutanagi MyParentReport
            {
                get { return (AmbalajTutanagi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ITEMDISTRIBUTIONTYPE { get {return Body().ITEMDISTRIBUTIONTYPE;} }
            public TTReportField ITEMAMOUNT { get {return Body().ITEMAMOUNT;} }
            public TTReportField ITEMNAME { get {return Body().ITEMNAME;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine1221 { get {return Body().NewLine1221;} }
            public TTReportShape NewLine1321 { get {return Body().NewLine1321;} }
            public TTReportShape NewLine1421 { get {return Body().NewLine1421;} }
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
                list[0] = new TTReportNqlData<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>("GetRULDetailsByObjectIDQuery", ReferToUpperLevel.GetRULDetailsByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTB.RULOBJECTID.CalcValue)));
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
                public AmbalajTutanagi MyParentReport
                {
                    get { return (AmbalajTutanagi)ParentReport; }
                }
                
                public TTReportField ITEMDISTRIBUTIONTYPE;
                public TTReportField ITEMAMOUNT;
                public TTReportField ITEMNAME;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1221;
                public TTReportShape NewLine1321;
                public TTReportShape NewLine1421; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    ITEMDISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 167, 5, false);
                    ITEMDISTRIBUTIONTYPE.Name = "ITEMDISTRIBUTIONTYPE";
                    ITEMDISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMDISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMDISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMDISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    ITEMDISTRIBUTIONTYPE.TextFont.Size = 8;
                    ITEMDISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    ITEMDISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    ITEMAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 148, 5, false);
                    ITEMAMOUNT.Name = "ITEMAMOUNT";
                    ITEMAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMAMOUNT.TextFont.Name = "Arial";
                    ITEMAMOUNT.TextFont.Size = 8;
                    ITEMAMOUNT.TextFont.CharSet = 162;
                    ITEMAMOUNT.Value = @"{#AMOUNT#}";

                    ITEMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 0, 133, 5, false);
                    ITEMNAME.Name = "ITEMNAME";
                    ITEMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMNAME.TextFont.Name = "Arial";
                    ITEMNAME.TextFont.Size = 8;
                    ITEMNAME.TextFont.CharSet = 162;
                    ITEMNAME.Value = @"{#ITEMNAME#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 0, 195, 6, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 6, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 0, 65, 6, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 133, 0, 133, 6, false);
                    NewLine1221.Name = "NewLine1221";
                    NewLine1221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 148, 0, 148, 6, false);
                    NewLine1321.Name = "NewLine1321";
                    NewLine1321.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1421 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 167, 0, 167, 6, false);
                    NewLine1421.Name = "NewLine1421";
                    NewLine1421.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class dataset_GetRULDetailsByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>(0);
                    ITEMDISTRIBUTIONTYPE.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.DistributionType) : "");
                    ITEMAMOUNT.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.Amount) : "");
                    ITEMNAME.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.ItemName) : "");
                    return new TTReportObject[] { ITEMDISTRIBUTIONTYPE,ITEMAMOUNT,ITEMNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AmbalajTutanagi()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("UYE1", "00000000-0000-0000-0000-000000000000", "1. Üye", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("UYE2", "00000000-0000-0000-0000-000000000000", "2. Üye", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("UYE3", "00000000-0000-0000-0000-000000000000", "3. Üye", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("BASKAN", "00000000-0000-0000-0000-000000000000", "Başkan", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("UYE1"))
                _runtimeParameters.UYE1 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["UYE1"]);
            if (parameters.ContainsKey("UYE2"))
                _runtimeParameters.UYE2 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["UYE2"]);
            if (parameters.ContainsKey("UYE3"))
                _runtimeParameters.UYE3 = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["UYE3"]);
            if (parameters.ContainsKey("BASKAN"))
                _runtimeParameters.BASKAN = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["BASKAN"]);
            Name = "AMBALAJTUTANAGI";
            Caption = "Ambalaj Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginTop = 10;
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