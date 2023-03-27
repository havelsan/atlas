
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
    /// İş Kartı
    /// </summary>
    public partial class WorkCard : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public WorkCard MyParentReport
            {
                get { return (WorkCard)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HOSPITAL { get {return Body().HOSPITAL;} }
            public TTReportField REPORTNAME { get {return Body().REPORTNAME;} }
            public TTReportField REPORTNAME1 { get {return Body().REPORTNAME1;} }
            public TTReportField REPORTNAME11 { get {return Body().REPORTNAME11;} }
            public TTReportField REPORTNAME111 { get {return Body().REPORTNAME111;} }
            public TTReportField REPORTNAME1111 { get {return Body().REPORTNAME1111;} }
            public TTReportField REPORTNAME1112 { get {return Body().REPORTNAME1112;} }
            public TTReportField REPORTNAME2 { get {return Body().REPORTNAME2;} }
            public TTReportField REPORTNAME11111 { get {return Body().REPORTNAME11111;} }
            public TTReportField REPORTNAME111111 { get {return Body().REPORTNAME111111;} }
            public TTReportField REPORTNAME1111111 { get {return Body().REPORTNAME1111111;} }
            public TTReportField REPORTNAME11111111 { get {return Body().REPORTNAME11111111;} }
            public TTReportField REPORTNAME11111112 { get {return Body().REPORTNAME11111112;} }
            public TTReportField REPORTNAME11111113 { get {return Body().REPORTNAME11111113;} }
            public TTReportField REPORTNAME11111114 { get {return Body().REPORTNAME11111114;} }
            public TTReportField REPORTNAME11111115 { get {return Body().REPORTNAME11111115;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField RECEIVERSECTION { get {return Body().RECEIVERSECTION;} }
            public TTReportField SENDERSECTION { get {return Body().SENDERSECTION;} }
            public TTReportField RECEIVERRESDIVISION { get {return Body().RECEIVERRESDIVISION;} }
            public TTReportField SENDERRESDIVISION { get {return Body().SENDERRESDIVISION;} }
            public TTReportField PRODUCTIONCONTROLCHIEF { get {return Body().PRODUCTIONCONTROLCHIEF;} }
            public TTReportField REPORTNAME161111111 { get {return Body().REPORTNAME161111111;} }
            public TTReportField DIVISIONCHIEF { get {return Body().DIVISIONCHIEF;} }
            public TTReportField DIVISIONSECTION { get {return Body().DIVISIONSECTION;} }
            public TTReportField REPORTNAME161111114 { get {return Body().REPORTNAME161111114;} }
            public TTReportField REPORTNAME161111115 { get {return Body().REPORTNAME161111115;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
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
                list[0] = new TTReportNqlData<WorkStep.GetWorkCardByObjectIDReportQuery_Class>("GetWorkCardByObjectIDReportQuery", WorkStep.GetWorkCardByObjectIDReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public WorkCard MyParentReport
                {
                    get { return (WorkCard)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField REPORTNAME;
                public TTReportField REPORTNAME1;
                public TTReportField REPORTNAME11;
                public TTReportField REPORTNAME111;
                public TTReportField REPORTNAME1111;
                public TTReportField REPORTNAME1112;
                public TTReportField REPORTNAME2;
                public TTReportField REPORTNAME11111;
                public TTReportField REPORTNAME111111;
                public TTReportField REPORTNAME1111111;
                public TTReportField REPORTNAME11111111;
                public TTReportField REPORTNAME11111112;
                public TTReportField REPORTNAME11111113;
                public TTReportField REPORTNAME11111114;
                public TTReportField REPORTNAME11111115;
                public TTReportField ORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField DESCRIPTION;
                public TTReportField STARTDATE;
                public TTReportField MILITARYUNIT;
                public TTReportField RECEIVERSECTION;
                public TTReportField SENDERSECTION;
                public TTReportField RECEIVERRESDIVISION;
                public TTReportField SENDERRESDIVISION;
                public TTReportField PRODUCTIONCONTROLCHIEF;
                public TTReportField REPORTNAME161111111;
                public TTReportField DIVISIONCHIEF;
                public TTReportField DIVISIONSECTION;
                public TTReportField REPORTNAME161111114;
                public TTReportField REPORTNAME161111115;
                public TTReportShape NewLine1;
                public TTReportField TTOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 148;
                    RepeatCount = 0;
                    
                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 200, 31, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITAL.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 11;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 95, 41, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"İŞ KARTI";

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 31, 200, 41, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @" SİPARİŞ NU. :";

                    REPORTNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 41, 200, 51, false);
                    REPORTNAME11.Name = "REPORTNAME11";
                    REPORTNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11.TextFont.Name = "Arial";
                    REPORTNAME11.TextFont.Bold = true;
                    REPORTNAME11.TextFont.CharSet = 162;
                    REPORTNAME11.Value = @" TARİHİ :";

                    REPORTNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 51, 200, 61, false);
                    REPORTNAME111.Name = "REPORTNAME111";
                    REPORTNAME111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME111.TextFont.Name = "Arial";
                    REPORTNAME111.TextFont.Bold = true;
                    REPORTNAME111.TextFont.CharSet = 162;
                    REPORTNAME111.Value = @" BİRLİĞİ :";

                    REPORTNAME1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 61, 200, 71, false);
                    REPORTNAME1111.Name = "REPORTNAME1111";
                    REPORTNAME1111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1111.TextFont.Name = "Arial";
                    REPORTNAME1111.TextFont.Bold = true;
                    REPORTNAME1111.TextFont.CharSet = 162;
                    REPORTNAME1111.Value = @" KISIM :";

                    REPORTNAME1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 71, 200, 81, false);
                    REPORTNAME1112.Name = "REPORTNAME1112";
                    REPORTNAME1112.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1112.TextFont.Name = "Arial";
                    REPORTNAME1112.TextFont.Bold = true;
                    REPORTNAME1112.TextFont.CharSet = 162;
                    REPORTNAME1112.Value = @" KISIM :";

                    REPORTNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 95, 61, false);
                    REPORTNAME2.Name = "REPORTNAME2";
                    REPORTNAME2.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME2.TextFont.Name = "Arial";
                    REPORTNAME2.TextFont.Bold = true;
                    REPORTNAME2.TextFont.CharSet = 162;
                    REPORTNAME2.Value = @" YAPILACAK İŞ :";

                    REPORTNAME11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 61, 95, 71, false);
                    REPORTNAME11111.Name = "REPORTNAME11111";
                    REPORTNAME11111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11111.TextFont.Name = "Arial";
                    REPORTNAME11111.TextFont.Bold = true;
                    REPORTNAME11111.TextFont.CharSet = 162;
                    REPORTNAME11111.Value = @" İŞİ YAPACAK BÖLÜM :";

                    REPORTNAME111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 71, 95, 81, false);
                    REPORTNAME111111.Name = "REPORTNAME111111";
                    REPORTNAME111111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME111111.TextFont.Name = "Arial";
                    REPORTNAME111111.TextFont.Bold = true;
                    REPORTNAME111111.TextFont.CharSet = 162;
                    REPORTNAME111111.Value = @" İŞİ İSTEYEN BÖLÜM :";

                    REPORTNAME1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 82, 95, 92, false);
                    REPORTNAME1111111.Name = "REPORTNAME1111111";
                    REPORTNAME1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1111111.TextFont.Name = "Arial";
                    REPORTNAME1111111.TextFont.Bold = true;
                    REPORTNAME1111111.TextFont.CharSet = 162;
                    REPORTNAME1111111.Value = @" PRODÜKSİYON KONTROL BÖLÜM AMİRİ";

                    REPORTNAME11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 92, 95, 102, false);
                    REPORTNAME11111111.Name = "REPORTNAME11111111";
                    REPORTNAME11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11111111.TextFont.Name = "Arial";
                    REPORTNAME11111111.TextFont.Bold = true;
                    REPORTNAME11111111.TextFont.CharSet = 162;
                    REPORTNAME11111111.Value = @" ÖNCELİK NU.";

                    REPORTNAME11111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 102, 95, 112, false);
                    REPORTNAME11111112.Name = "REPORTNAME11111112";
                    REPORTNAME11111112.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11111112.TextFont.Name = "Arial";
                    REPORTNAME11111112.TextFont.Bold = true;
                    REPORTNAME11111112.TextFont.CharSet = 162;
                    REPORTNAME11111112.Value = @" İŞİ İSTEYEN KISIM AMİRİ";

                    REPORTNAME11111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 112, 95, 122, false);
                    REPORTNAME11111113.Name = "REPORTNAME11111113";
                    REPORTNAME11111113.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11111113.TextFont.Name = "Arial";
                    REPORTNAME11111113.TextFont.Bold = true;
                    REPORTNAME11111113.TextFont.CharSet = 162;
                    REPORTNAME11111113.Value = @" İŞİ İSTEYEN BÖLÜM AMİRİ";

                    REPORTNAME11111114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 122, 95, 132, false);
                    REPORTNAME11111114.Name = "REPORTNAME11111114";
                    REPORTNAME11111114.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11111114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11111114.TextFont.Name = "Arial";
                    REPORTNAME11111114.TextFont.Bold = true;
                    REPORTNAME11111114.TextFont.CharSet = 162;
                    REPORTNAME11111114.Value = @" İŞİ YAPACAK KISIM AMİRİ";

                    REPORTNAME11111115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 132, 95, 142, false);
                    REPORTNAME11111115.Name = "REPORTNAME11111115";
                    REPORTNAME11111115.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11111115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11111115.TextFont.Name = "Arial";
                    REPORTNAME11111115.TextFont.Bold = true;
                    REPORTNAME11111115.TextFont.CharSet = 162;
                    REPORTNAME11111115.Value = @" İŞİ YAPACAK BÖLÜM AMİRİ";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 31, 199, 36, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 36, 199, 40, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 46, 94, 60, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 46, 199, 50, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#STARTDATE#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 56, 199, 60, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{#MILITARYUNIT#}";

                    RECEIVERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 66, 199, 70, false);
                    RECEIVERSECTION.Name = "RECEIVERSECTION";
                    RECEIVERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVERSECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RECEIVERSECTION.TextFont.Name = "Arial";
                    RECEIVERSECTION.TextFont.CharSet = 162;
                    RECEIVERSECTION.Value = @"{#RECEIVERSECTION#}";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 76, 199, 80, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERSECTION.TextFont.Name = "Arial";
                    SENDERSECTION.TextFont.CharSet = 162;
                    SENDERSECTION.Value = @"{#SENDERSECTION#}";

                    RECEIVERRESDIVISION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 66, 94, 70, false);
                    RECEIVERRESDIVISION.Name = "RECEIVERRESDIVISION";
                    RECEIVERRESDIVISION.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVERRESDIVISION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RECEIVERRESDIVISION.TextFont.Name = "Arial";
                    RECEIVERRESDIVISION.TextFont.CharSet = 162;
                    RECEIVERRESDIVISION.Value = @"{#RECEIVERRESDIVISION#}";

                    SENDERRESDIVISION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 76, 94, 80, false);
                    SENDERRESDIVISION.Name = "SENDERRESDIVISION";
                    SENDERRESDIVISION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERRESDIVISION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERRESDIVISION.TextFont.Name = "Arial";
                    SENDERRESDIVISION.TextFont.CharSet = 162;
                    SENDERRESDIVISION.Value = @"{#SENDERRESDIVISION#}";

                    PRODUCTIONCONTROLCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 82, 200, 92, false);
                    PRODUCTIONCONTROLCHIEF.Name = "PRODUCTIONCONTROLCHIEF";
                    PRODUCTIONCONTROLCHIEF.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCTIONCONTROLCHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTIONCONTROLCHIEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCTIONCONTROLCHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    PRODUCTIONCONTROLCHIEF.WordBreak = EvetHayirEnum.ehEvet;
                    PRODUCTIONCONTROLCHIEF.TextFont.Name = "Arial";
                    PRODUCTIONCONTROLCHIEF.TextFont.CharSet = 162;
                    PRODUCTIONCONTROLCHIEF.Value = @"";

                    REPORTNAME161111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 92, 200, 102, false);
                    REPORTNAME161111111.Name = "REPORTNAME161111111";
                    REPORTNAME161111111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME161111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME161111111.TextFont.Name = "Arial";
                    REPORTNAME161111111.TextFont.Bold = true;
                    REPORTNAME161111111.TextFont.CharSet = 162;
                    REPORTNAME161111111.Value = @"";

                    DIVISIONCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 112, 200, 122, false);
                    DIVISIONCHIEF.Name = "DIVISIONCHIEF";
                    DIVISIONCHIEF.DrawStyle = DrawStyleConstants.vbSolid;
                    DIVISIONCHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIVISIONCHIEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIVISIONCHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    DIVISIONCHIEF.WordBreak = EvetHayirEnum.ehEvet;
                    DIVISIONCHIEF.TextFont.Name = "Arial";
                    DIVISIONCHIEF.TextFont.CharSet = 162;
                    DIVISIONCHIEF.Value = @"";

                    DIVISIONSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 102, 200, 112, false);
                    DIVISIONSECTION.Name = "DIVISIONSECTION";
                    DIVISIONSECTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DIVISIONSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIVISIONSECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIVISIONSECTION.MultiLine = EvetHayirEnum.ehEvet;
                    DIVISIONSECTION.WordBreak = EvetHayirEnum.ehEvet;
                    DIVISIONSECTION.TextFont.Name = "Arial";
                    DIVISIONSECTION.TextFont.CharSet = 162;
                    DIVISIONSECTION.Value = @"";

                    REPORTNAME161111114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 122, 200, 132, false);
                    REPORTNAME161111114.Name = "REPORTNAME161111114";
                    REPORTNAME161111114.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME161111114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME161111114.TextFont.Name = "Arial";
                    REPORTNAME161111114.TextFont.Bold = true;
                    REPORTNAME161111114.TextFont.CharSet = 162;
                    REPORTNAME161111114.Value = @"";

                    REPORTNAME161111115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 132, 200, 142, false);
                    REPORTNAME161111115.Name = "REPORTNAME161111115";
                    REPORTNAME161111115.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME161111115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME161111115.TextFont.Name = "Arial";
                    REPORTNAME161111115.TextFont.Bold = true;
                    REPORTNAME161111115.TextFont.CharSet = 162;
                    REPORTNAME161111115.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 112, 31, 199, 31, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 30, 257, 35, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    WorkStep.GetWorkCardByObjectIDReportQuery_Class dataset_GetWorkCardByObjectIDReportQuery = ParentGroup.rsGroup.GetCurrentRecord<WorkStep.GetWorkCardByObjectIDReportQuery_Class>(0);
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    REPORTNAME11.CalcValue = REPORTNAME11.Value;
                    REPORTNAME111.CalcValue = REPORTNAME111.Value;
                    REPORTNAME1111.CalcValue = REPORTNAME1111.Value;
                    REPORTNAME1112.CalcValue = REPORTNAME1112.Value;
                    REPORTNAME2.CalcValue = REPORTNAME2.Value;
                    REPORTNAME11111.CalcValue = REPORTNAME11111.Value;
                    REPORTNAME111111.CalcValue = REPORTNAME111111.Value;
                    REPORTNAME1111111.CalcValue = REPORTNAME1111111.Value;
                    REPORTNAME11111111.CalcValue = REPORTNAME11111111.Value;
                    REPORTNAME11111112.CalcValue = REPORTNAME11111112.Value;
                    REPORTNAME11111113.CalcValue = REPORTNAME11111113.Value;
                    REPORTNAME11111114.CalcValue = REPORTNAME11111114.Value;
                    REPORTNAME11111115.CalcValue = REPORTNAME11111115.Value;
                    ORDERNO.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.OrderNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Materialname) : "");
                    DESCRIPTION.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Description) : "");
                    STARTDATE.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.StartDate) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Militaryunit) : "");
                    RECEIVERSECTION.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Receiversection) : "");
                    SENDERSECTION.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Sendersection) : "");
                    RECEIVERRESDIVISION.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Receiverresdivision) : "");
                    SENDERRESDIVISION.CalcValue = (dataset_GetWorkCardByObjectIDReportQuery != null ? Globals.ToStringCore(dataset_GetWorkCardByObjectIDReportQuery.Senderresdivision) : "");
                    PRODUCTIONCONTROLCHIEF.CalcValue = @"";
                    REPORTNAME161111111.CalcValue = REPORTNAME161111111.Value;
                    DIVISIONCHIEF.CalcValue = @"";
                    DIVISIONSECTION.CalcValue = @"";
                    REPORTNAME161111114.CalcValue = REPORTNAME161111114.Value;
                    REPORTNAME161111115.CalcValue = REPORTNAME161111115.Value;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME,REPORTNAME1,REPORTNAME11,REPORTNAME111,REPORTNAME1111,REPORTNAME1112,REPORTNAME2,REPORTNAME11111,REPORTNAME111111,REPORTNAME1111111,REPORTNAME11111111,REPORTNAME11111112,REPORTNAME11111113,REPORTNAME11111114,REPORTNAME11111115,ORDERNO,MATERIALNAME,DESCRIPTION,STARTDATE,MILITARYUNIT,RECEIVERSECTION,SENDERSECTION,RECEIVERRESDIVISION,SENDERRESDIVISION,PRODUCTIONCONTROLCHIEF,REPORTNAME161111111,DIVISIONCHIEF,DIVISIONSECTION,REPORTNAME161111114,REPORTNAME161111115,TTOBJECTID,HOSPITAL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            WorkStep ws = (WorkStep)ctx.GetObject(new Guid(TTOBJECTID.CalcValue), typeof(WorkStep));
            ResUser user;
            if(ws.MaintenanceOrder.GetState("OrderApproval", true) != null)
            {
                user = (ResUser)ws.MaintenanceOrder.GetState("OrderApproval", true).User.UserObject;
                if(user.Title != null)
                    PRODUCTIONCONTROLCHIEF.CalcValue = " " + user.Name.ToString() + "\n " + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
                else
                    PRODUCTIONCONTROLCHIEF.CalcValue = " " + user.Name.ToString();
            }
            
            if(ws.MaintenanceOrder.GetState("DivisionSectionApproval", true) != null)
            {
                user = (ResUser)ws.MaintenanceOrder.GetState("DivisionSectionApproval", true).User.UserObject;
                if(user.Title != null)
                    DIVISIONSECTION.CalcValue = " " + user.Name.ToString() + "\n " + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
                else
                    DIVISIONSECTION.CalcValue = " " + user.Name.ToString();
            }
            
            if(ws.MaintenanceOrder.GetState("DivisionChiefApproval", true) != null)
            {
                user = (ResUser) ws.MaintenanceOrder.GetState("DivisionChiefApproval", true).User.UserObject;
                if(user.Title != null)
                    DIVISIONCHIEF.CalcValue = " " + user.Name.ToString() + "\n " + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
                else
                    DIVISIONCHIEF.CalcValue = " " + user.Name.ToString();
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

        public WorkCard()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "WORKCARD";
            Caption = "İş Kartı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 11;
            p_PageWidth = 148;
            p_PageHeight = 210;
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