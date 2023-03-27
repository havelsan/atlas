
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
    /// Maliyet Formu
    /// </summary>
    public partial class CostReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CostReport MyParentReport
            {
                get { return (CostReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField112125896 { get {return Header().NewField112125896;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField12212 { get {return Header().NewField12212;} }
            public TTReportField NewField111222 { get {return Header().NewField111222;} }
            public TTReportField NewField1122111 { get {return Header().NewField1122111;} }
            public TTReportField NewField121221 { get {return Header().NewField121221;} }
            public TTReportField NewField1222111 { get {return Header().NewField1222111;} }
            public TTReportField NewField11112211 { get {return Header().NewField11112211;} }
            public TTReportField ORDERNAME { get {return Header().ORDERNAME;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField WORKSHOP1 { get {return Footer().WORKSHOP1;} }
            public TTReportField TOTALDIRECTLABORTIME { get {return Footer().TOTALDIRECTLABORTIME;} }
            public TTReportField TOTALLABORCOST { get {return Footer().TOTALLABORCOST;} }
            public TTReportField TOTALGENERALPROCESSINGCOST { get {return Footer().TOTALGENERALPROCESSINGCOST;} }
            public TTReportField TOTALDEPRECIATIONEXPENSE { get {return Footer().TOTALDEPRECIATIONEXPENSE;} }
            public TTReportField WORKSHOP11 { get {return Footer().WORKSHOP11;} }
            public TTReportField WORKSHOP12 { get {return Footer().WORKSHOP12;} }
            public TTReportField WORKSHOP111 { get {return Footer().WORKSHOP111;} }
            public TTReportField DIRECTLABORCOST { get {return Footer().DIRECTLABORCOST;} }
            public TTReportField WORKSHOP112 { get {return Footer().WORKSHOP112;} }
            public TTReportField DIRECTMATERIALCOST { get {return Footer().DIRECTMATERIALCOST;} }
            public TTReportField WORKSHOP113 { get {return Footer().WORKSHOP113;} }
            public TTReportField GENERALPROCESSINGCOST { get {return Footer().GENERALPROCESSINGCOST;} }
            public TTReportField WORKSHOP114 { get {return Footer().WORKSHOP114;} }
            public TTReportField DEPRECIATIONEXPENSE { get {return Footer().DEPRECIATIONEXPENSE;} }
            public TTReportField WORKSHOP115 { get {return Footer().WORKSHOP115;} }
            public TTReportField TOTALCOST { get {return Footer().TOTALCOST;} }
            public TTReportField WORKSHOP116 { get {return Footer().WORKSHOP116;} }
            public TTReportField AMOUNT { get {return Footer().AMOUNT;} }
            public TTReportField WORKSHOP117 { get {return Footer().WORKSHOP117;} }
            public TTReportField UNITCOST { get {return Footer().UNITCOST;} }
            public TTReportField WORKSHOP118 { get {return Footer().WORKSHOP118;} }
            public TTReportField UNITLABORTIME { get {return Footer().UNITLABORTIME;} }
            public TTReportField SHARPDIRECTLABORTIME { get {return Footer().SHARPDIRECTLABORTIME;} }
            public TTReportField OBJECTID { get {return Footer().OBJECTID;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>("GetMaintenanceOrderCostByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public CostReport MyParentReport
                {
                    get { return (CostReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField112125896;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField12211;
                public TTReportField NewField111221;
                public TTReportField NewField12212;
                public TTReportField NewField111222;
                public TTReportField NewField1122111;
                public TTReportField NewField121221;
                public TTReportField NewField1222111;
                public TTReportField NewField11112211;
                public TTReportField ORDERNAME;
                public TTReportField ORDERNO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 83;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 200, 21, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 11;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 200, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TEKNİK MÜDÜRLÜK";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 200, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"PLAN KOORDİNASYON KISMI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 76, 60, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 14;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"MALİYET FORMU";

                    NewField112125896 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 40, 138, 60, false);
                    NewField112125896.Name = "NewField112125896";
                    NewField112125896.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112125896.TextFont.Name = "Arial";
                    NewField112125896.TextFont.Bold = true;
                    NewField112125896.TextFont.CharSet = 162;
                    NewField112125896.Value = @" SİPARİŞİN ADI :";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 40, 200, 60, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @" SİPARİŞ NU. :";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 60, 200, 81, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Size = 9;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"AMORTİSMAN
GİDERİ
(TL)";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 60, 177, 81, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12211.TextFont.Name = "Arial";
                    NewField12211.TextFont.Size = 9;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"ORTALAMA
AMORTİSMAN
GİDERİ
(TL)";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 60, 154, 81, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 9;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"GENEL
ÜRETİM
GİDERİ
(TL)";

                    NewField12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 60, 138, 81, false);
                    NewField12212.Name = "NewField12212";
                    NewField12212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12212.TextFont.Name = "Arial";
                    NewField12212.TextFont.Size = 9;
                    NewField12212.TextFont.Bold = true;
                    NewField12212.TextFont.CharSet = 162;
                    NewField12212.Value = @"ORTALAMA
GENEL
ÜRETİM
GİDERİ
(TL)";

                    NewField111222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 60, 115, 81, false);
                    NewField111222.Name = "NewField111222";
                    NewField111222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111222.TextFont.Name = "Arial";
                    NewField111222.TextFont.Size = 9;
                    NewField111222.TextFont.Bold = true;
                    NewField111222.TextFont.CharSet = 162;
                    NewField111222.Value = @"İŞÇİLİK
GİDERİ
(TL)";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 60, 95, 81, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122111.TextFont.Name = "Arial";
                    NewField1122111.TextFont.Size = 9;
                    NewField1122111.TextFont.Bold = true;
                    NewField1122111.TextFont.CharSet = 162;
                    NewField1122111.Value = @"ORTALAMA
DİREKT
İŞÇİLİK
GİDERİ
(TL)";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 76, 81, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121221.TextFont.Name = "Arial";
                    NewField121221.TextFont.Size = 9;
                    NewField121221.TextFont.Bold = true;
                    NewField121221.TextFont.CharSet = 162;
                    NewField121221.Value = @"NET
DİREKT
İŞÇİLİK
SAATİ";

                    NewField1222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 60, 62, 81, false);
                    NewField1222111.Name = "NewField1222111";
                    NewField1222111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1222111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1222111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1222111.TextFont.Name = "Arial";
                    NewField1222111.TextFont.Size = 9;
                    NewField1222111.TextFont.Bold = true;
                    NewField1222111.TextFont.CharSet = 162;
                    NewField1222111.Value = @"AY";

                    NewField11112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 45, 81, false);
                    NewField11112211.Name = "NewField11112211";
                    NewField11112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112211.TextFont.Name = "Arial";
                    NewField11112211.TextFont.Size = 9;
                    NewField11112211.TextFont.Bold = true;
                    NewField11112211.TextFont.CharSet = 162;
                    NewField11112211.Value = @"ATÖLYE";

                    ORDERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 45, 137, 59, false);
                    ORDERNAME.Name = "ORDERNAME";
                    ORDERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNAME.ObjectDefName = "MaintenanceOrder";
                    ORDERNAME.DataMember = "ORDERNAME";
                    ORDERNAME.TextFont.Name = "Arial";
                    ORDERNAME.TextFont.CharSet = 162;
                    ORDERNAME.Value = @"{@TTOBJECTID@}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 45, 199, 59, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO.ObjectDefName = "MaintenanceOrder";
                    ORDERNO.DataMember = "REQUESTNO";
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class dataset_GetMaintenanceOrderCostByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField112125896.CalcValue = NewField112125896.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField12212.CalcValue = NewField12212.Value;
                    NewField111222.CalcValue = NewField111222.Value;
                    NewField1122111.CalcValue = NewField1122111.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    NewField1222111.CalcValue = NewField1222111.Value;
                    NewField11112211.CalcValue = NewField11112211.Value;
                    ORDERNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ORDERNAME.PostFieldValueCalculation();
                    ORDERNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ORDERNO.PostFieldValueCalculation();
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField112125896,NewField1121,NewField1122,NewField12211,NewField111221,NewField12212,NewField111222,NewField1122111,NewField121221,NewField1222111,NewField11112211,ORDERNAME,ORDERNO,HOSPITAL};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CostReport MyParentReport
                {
                    get { return (CostReport)ParentReport; }
                }
                
                public TTReportField WORKSHOP1;
                public TTReportField TOTALDIRECTLABORTIME;
                public TTReportField TOTALLABORCOST;
                public TTReportField TOTALGENERALPROCESSINGCOST;
                public TTReportField TOTALDEPRECIATIONEXPENSE;
                public TTReportField WORKSHOP11;
                public TTReportField WORKSHOP12;
                public TTReportField WORKSHOP111;
                public TTReportField DIRECTLABORCOST;
                public TTReportField WORKSHOP112;
                public TTReportField DIRECTMATERIALCOST;
                public TTReportField WORKSHOP113;
                public TTReportField GENERALPROCESSINGCOST;
                public TTReportField WORKSHOP114;
                public TTReportField DEPRECIATIONEXPENSE;
                public TTReportField WORKSHOP115;
                public TTReportField TOTALCOST;
                public TTReportField WORKSHOP116;
                public TTReportField AMOUNT;
                public TTReportField WORKSHOP117;
                public TTReportField UNITCOST;
                public TTReportField WORKSHOP118;
                public TTReportField UNITLABORTIME;
                public TTReportField SHARPDIRECTLABORTIME;
                public TTReportField OBJECTID; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 106;
                    RepeatCount = 0;
                    
                    WORKSHOP1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 45, 8, false);
                    WORKSHOP1.Name = "WORKSHOP1";
                    WORKSHOP1.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP1.TextFont.Name = "Arial";
                    WORKSHOP1.TextFont.Bold = true;
                    WORKSHOP1.TextFont.CharSet = 162;
                    WORKSHOP1.Value = @" TOPLAM";

                    TOTALDIRECTLABORTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 76, 8, false);
                    TOTALDIRECTLABORTIME.Name = "TOTALDIRECTLABORTIME";
                    TOTALDIRECTLABORTIME.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALDIRECTLABORTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDIRECTLABORTIME.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDIRECTLABORTIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALDIRECTLABORTIME.TextFont.Name = "Arial";
                    TOTALDIRECTLABORTIME.TextFont.CharSet = 162;
                    TOTALDIRECTLABORTIME.Value = @"{@sumof(SHARPDIRECTLABORTIME)@}";

                    TOTALLABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 0, 115, 8, false);
                    TOTALLABORCOST.Name = "TOTALLABORCOST";
                    TOTALLABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALLABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALLABORCOST.TextFormat = @"#,##0.#0";
                    TOTALLABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALLABORCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALLABORCOST.TextFont.Name = "Arial";
                    TOTALLABORCOST.TextFont.CharSet = 162;
                    TOTALLABORCOST.Value = @"{@sumof(LABORCOST)@}";

                    TOTALGENERALPROCESSINGCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 154, 8, false);
                    TOTALGENERALPROCESSINGCOST.Name = "TOTALGENERALPROCESSINGCOST";
                    TOTALGENERALPROCESSINGCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALGENERALPROCESSINGCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALGENERALPROCESSINGCOST.TextFormat = @"#,##0.#0";
                    TOTALGENERALPROCESSINGCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALGENERALPROCESSINGCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALGENERALPROCESSINGCOST.TextFont.Name = "Arial";
                    TOTALGENERALPROCESSINGCOST.TextFont.CharSet = 162;
                    TOTALGENERALPROCESSINGCOST.Value = @"{@sumof(GENERALPROCESSINGCOST)@}";

                    TOTALDEPRECIATIONEXPENSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 200, 8, false);
                    TOTALDEPRECIATIONEXPENSE.Name = "TOTALDEPRECIATIONEXPENSE";
                    TOTALDEPRECIATIONEXPENSE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALDEPRECIATIONEXPENSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDEPRECIATIONEXPENSE.TextFormat = @"#,##0.#0";
                    TOTALDEPRECIATIONEXPENSE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDEPRECIATIONEXPENSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALDEPRECIATIONEXPENSE.TextFont.Name = "Arial";
                    TOTALDEPRECIATIONEXPENSE.TextFont.CharSet = 162;
                    TOTALDEPRECIATIONEXPENSE.Value = @"{@sumof(DEPRECIATIONEXPENSE)@}";

                    WORKSHOP11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 154, 16, false);
                    WORKSHOP11.Name = "WORKSHOP11";
                    WORKSHOP11.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP11.TextFont.Name = "Arial";
                    WORKSHOP11.TextFont.Bold = true;
                    WORKSHOP11.TextFont.CharSet = 162;
                    WORKSHOP11.Value = @" MALİYET UNSURLARI";

                    WORKSHOP12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 8, 200, 16, false);
                    WORKSHOP12.Name = "WORKSHOP12";
                    WORKSHOP12.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP12.TextFont.Name = "Arial";
                    WORKSHOP12.TextFont.Bold = true;
                    WORKSHOP12.TextFont.CharSet = 162;
                    WORKSHOP12.Value = @" TUTARI";

                    WORKSHOP111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 154, 24, false);
                    WORKSHOP111.Name = "WORKSHOP111";
                    WORKSHOP111.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP111.TextFont.Name = "Arial";
                    WORKSHOP111.TextFont.CharSet = 162;
                    WORKSHOP111.Value = @" DİREKT İŞÇİLİK GİDERİ (TL)";

                    DIRECTLABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 16, 200, 24, false);
                    DIRECTLABORCOST.Name = "DIRECTLABORCOST";
                    DIRECTLABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    DIRECTLABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIRECTLABORCOST.TextFormat = @"#,##0.#0";
                    DIRECTLABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DIRECTLABORCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIRECTLABORCOST.TextFont.Name = "Arial";
                    DIRECTLABORCOST.TextFont.CharSet = 162;
                    DIRECTLABORCOST.Value = @"{@sumof(LABORCOST)@}";

                    WORKSHOP112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 154, 32, false);
                    WORKSHOP112.Name = "WORKSHOP112";
                    WORKSHOP112.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP112.TextFont.Name = "Arial";
                    WORKSHOP112.TextFont.CharSet = 162;
                    WORKSHOP112.Value = @" DİREK MALZEME GİDERİ (TL)";

                    DIRECTMATERIALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 24, 200, 32, false);
                    DIRECTMATERIALCOST.Name = "DIRECTMATERIALCOST";
                    DIRECTMATERIALCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    DIRECTMATERIALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIRECTMATERIALCOST.TextFormat = @"#,##0.#0";
                    DIRECTMATERIALCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DIRECTMATERIALCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIRECTMATERIALCOST.TextFont.Name = "Arial";
                    DIRECTMATERIALCOST.TextFont.CharSet = 162;
                    DIRECTMATERIALCOST.Value = @"{#DIRECTMATERIALEXPENSE#}";

                    WORKSHOP113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 32, 154, 40, false);
                    WORKSHOP113.Name = "WORKSHOP113";
                    WORKSHOP113.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP113.TextFont.Name = "Arial";
                    WORKSHOP113.TextFont.CharSet = 162;
                    WORKSHOP113.Value = @" GENEL ÜRETİM GİDERİ (TL)";

                    GENERALPROCESSINGCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 32, 200, 40, false);
                    GENERALPROCESSINGCOST.Name = "GENERALPROCESSINGCOST";
                    GENERALPROCESSINGCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    GENERALPROCESSINGCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALPROCESSINGCOST.TextFormat = @"#,##0.#0";
                    GENERALPROCESSINGCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALPROCESSINGCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENERALPROCESSINGCOST.TextFont.Name = "Arial";
                    GENERALPROCESSINGCOST.TextFont.CharSet = 162;
                    GENERALPROCESSINGCOST.Value = @"{@sumof(GENERALPROCESSINGCOST)@}";

                    WORKSHOP114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 154, 48, false);
                    WORKSHOP114.Name = "WORKSHOP114";
                    WORKSHOP114.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP114.TextFont.Name = "Arial";
                    WORKSHOP114.TextFont.CharSet = 162;
                    WORKSHOP114.Value = @" AMORTİSMAN GİDERİ (TL)";

                    DEPRECIATIONEXPENSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 40, 200, 48, false);
                    DEPRECIATIONEXPENSE.Name = "DEPRECIATIONEXPENSE";
                    DEPRECIATIONEXPENSE.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPRECIATIONEXPENSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPRECIATIONEXPENSE.TextFormat = @"#,##0.#0";
                    DEPRECIATIONEXPENSE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEPRECIATIONEXPENSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEPRECIATIONEXPENSE.TextFont.Name = "Arial";
                    DEPRECIATIONEXPENSE.TextFont.CharSet = 162;
                    DEPRECIATIONEXPENSE.Value = @"{@sumof(DEPRECIATIONEXPENSE)@}";

                    WORKSHOP115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 154, 58, false);
                    WORKSHOP115.Name = "WORKSHOP115";
                    WORKSHOP115.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP115.TextFont.Name = "Arial";
                    WORKSHOP115.TextFont.Size = 12;
                    WORKSHOP115.TextFont.Bold = true;
                    WORKSHOP115.TextFont.CharSet = 162;
                    WORKSHOP115.Value = @"TOPLAM MALİYET (TL)";

                    TOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 48, 200, 58, false);
                    TOTALCOST.Name = "TOTALCOST";
                    TOTALCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOST.TextFormat = @"#,##0.#0";
                    TOTALCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCOST.TextFont.Name = "Arial";
                    TOTALCOST.TextFont.CharSet = 162;
                    TOTALCOST.Value = @"";

                    WORKSHOP116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 154, 66, false);
                    WORKSHOP116.Name = "WORKSHOP116";
                    WORKSHOP116.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP116.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP116.TextFont.Name = "Arial";
                    WORKSHOP116.TextFont.CharSet = 162;
                    WORKSHOP116.Value = @" YAPILAN MİKTAR (ADET)";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 58, 200, 66, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#MANUFACTURINGAMOUNT#}";

                    WORKSHOP117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 154, 76, false);
                    WORKSHOP117.Name = "WORKSHOP117";
                    WORKSHOP117.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP117.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP117.TextFont.Name = "Arial";
                    WORKSHOP117.TextFont.Size = 12;
                    WORKSHOP117.TextFont.Bold = true;
                    WORKSHOP117.TextFont.CharSet = 162;
                    WORKSHOP117.Value = @"BİRİM MALİYET (TL)";

                    UNITCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 66, 200, 76, false);
                    UNITCOST.Name = "UNITCOST";
                    UNITCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITCOST.TextFormat = @"#,##0.#0";
                    UNITCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITCOST.TextFont.Name = "Arial";
                    UNITCOST.TextFont.Bold = true;
                    UNITCOST.TextFont.CharSet = 162;
                    UNITCOST.Value = @"";

                    WORKSHOP118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 76, 154, 84, false);
                    WORKSHOP118.Name = "WORKSHOP118";
                    WORKSHOP118.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP118.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP118.TextFont.Name = "Arial";
                    WORKSHOP118.TextFont.CharSet = 162;
                    WORKSHOP118.Value = @" BİRİM İŞÇİLİK SAATİ (SAAT)";

                    UNITLABORTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 76, 200, 84, false);
                    UNITLABORTIME.Name = "UNITLABORTIME";
                    UNITLABORTIME.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITLABORTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITLABORTIME.TextFormat = @"#,##0.#0";
                    UNITLABORTIME.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITLABORTIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITLABORTIME.TextFont.Name = "Arial";
                    UNITLABORTIME.TextFont.CharSet = 162;
                    UNITLABORTIME.Value = @"";

                    SHARPDIRECTLABORTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 12, 258, 17, false);
                    SHARPDIRECTLABORTIME.Name = "SHARPDIRECTLABORTIME";
                    SHARPDIRECTLABORTIME.Visible = EvetHayirEnum.ehHayir;
                    SHARPDIRECTLABORTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME.Value = @"{#SHARPDIRECTLABORTIME#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 22, 258, 27, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class dataset_GetMaintenanceOrderCostByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(0);
                    WORKSHOP1.CalcValue = WORKSHOP1.Value;
                    TOTALDIRECTLABORTIME.CalcValue = ParentGroup.FieldSums["SHARPDIRECTLABORTIME"].Value.ToString();;
                    TOTALLABORCOST.CalcValue = ParentGroup.FieldSums["LABORCOST"].Value.ToString();;
                    TOTALGENERALPROCESSINGCOST.CalcValue = ParentGroup.FieldSums["GENERALPROCESSINGCOST"].Value.ToString();;
                    TOTALDEPRECIATIONEXPENSE.CalcValue = ParentGroup.FieldSums["DEPRECIATIONEXPENSE"].Value.ToString();;
                    WORKSHOP11.CalcValue = WORKSHOP11.Value;
                    WORKSHOP12.CalcValue = WORKSHOP12.Value;
                    WORKSHOP111.CalcValue = WORKSHOP111.Value;
                    DIRECTLABORCOST.CalcValue = ParentGroup.FieldSums["LABORCOST"].Value.ToString();;
                    WORKSHOP112.CalcValue = WORKSHOP112.Value;
                    DIRECTMATERIALCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Directmaterialexpense) : "");
                    WORKSHOP113.CalcValue = WORKSHOP113.Value;
                    GENERALPROCESSINGCOST.CalcValue = ParentGroup.FieldSums["GENERALPROCESSINGCOST"].Value.ToString();;
                    WORKSHOP114.CalcValue = WORKSHOP114.Value;
                    DEPRECIATIONEXPENSE.CalcValue = ParentGroup.FieldSums["DEPRECIATIONEXPENSE"].Value.ToString();;
                    WORKSHOP115.CalcValue = WORKSHOP115.Value;
                    TOTALCOST.CalcValue = @"";
                    WORKSHOP116.CalcValue = WORKSHOP116.Value;
                    AMOUNT.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Manufacturingamount) : "");
                    WORKSHOP117.CalcValue = WORKSHOP117.Value;
                    UNITCOST.CalcValue = @"";
                    WORKSHOP118.CalcValue = WORKSHOP118.Value;
                    UNITLABORTIME.CalcValue = @"";
                    SHARPDIRECTLABORTIME.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Sharpdirectlabortime) : "");
                    OBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { WORKSHOP1,TOTALDIRECTLABORTIME,TOTALLABORCOST,TOTALGENERALPROCESSINGCOST,TOTALDEPRECIATIONEXPENSE,WORKSHOP11,WORKSHOP12,WORKSHOP111,DIRECTLABORCOST,WORKSHOP112,DIRECTMATERIALCOST,WORKSHOP113,GENERALPROCESSINGCOST,WORKSHOP114,DEPRECIATIONEXPENSE,WORKSHOP115,TOTALCOST,WORKSHOP116,AMOUNT,WORKSHOP117,UNITCOST,WORKSHOP118,UNITLABORTIME,SHARPDIRECTLABORTIME,OBJECTID};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((CostReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            if (mo.MaintenanceOrderType.TypeCode == "BS" || mo.MaintenanceOrderType.TypeCode == "FS" || mo.MaintenanceOrderType.TypeCode == "KS" || mo.MaintenanceOrderType.TypeCode == "MS")
            {
                AMOUNT.CalcValue = "1";
            }

            if (mo.MaintenanceOrderType.TypeCode == "OS")
            {
                AMOUNT.CalcValue = mo.SpecialWorkAmount.ToString();
            }
            
            if (mo.MaintenanceOrderType.TypeCode == "IS")
            {
                AMOUNT.CalcValue = mo.ManufacturingAmount.ToString();
            }
            TOTALCOST.CalcValue = (Convert.ToDouble(DIRECTLABORCOST.CalcValue) + Convert.ToDouble(DIRECTMATERIALCOST.CalcValue) + Convert.ToDouble(GENERALPROCESSINGCOST.CalcValue) + Convert.ToDouble(DEPRECIATIONEXPENSE.CalcValue)).ToString();
            UNITCOST.CalcValue = (Convert.ToDouble(TOTALCOST.CalcValue) / Convert.ToDouble(AMOUNT.CalcValue)).ToString();
            UNITLABORTIME.CalcValue = (Convert.ToDouble(SHARPDIRECTLABORTIME.CalcValue) / Convert.ToDouble(AMOUNT.CalcValue)).ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CostReport MyParentReport
            {
                get { return (CostReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField WORKSHOP { get {return Body().WORKSHOP;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField SHARPDIRECTLABORTIME { get {return Body().SHARPDIRECTLABORTIME;} }
            public TTReportField AVERAGEDIRECTLABORCOST { get {return Body().AVERAGEDIRECTLABORCOST;} }
            public TTReportField LABORCOST { get {return Body().LABORCOST;} }
            public TTReportField AVERAGEGENERALPROCESSINGCOST { get {return Body().AVERAGEGENERALPROCESSINGCOST;} }
            public TTReportField GENERALPROCESSINGCOST { get {return Body().GENERALPROCESSINGCOST;} }
            public TTReportField AVERAGEDEPRECIATIONEXPENSE { get {return Body().AVERAGEDEPRECIATIONEXPENSE;} }
            public TTReportField DEPRECIATIONEXPENSE { get {return Body().DEPRECIATIONEXPENSE;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class dataSet_GetMaintenanceOrderCostByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceOrderCostByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderCostByObjectIDQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CostReport MyParentReport
                {
                    get { return (CostReport)ParentReport; }
                }
                
                public TTReportField WORKSHOP;
                public TTReportField DATE;
                public TTReportField SHARPDIRECTLABORTIME;
                public TTReportField AVERAGEDIRECTLABORCOST;
                public TTReportField LABORCOST;
                public TTReportField AVERAGEGENERALPROCESSINGCOST;
                public TTReportField GENERALPROCESSINGCOST;
                public TTReportField AVERAGEDEPRECIATIONEXPENSE;
                public TTReportField DEPRECIATIONEXPENSE;
                public TTReportField MONTH;
                public TTReportField YEAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 45, 9, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.MultiLine = EvetHayirEnum.ehEvet;
                    WORKSHOP.WordBreak = EvetHayirEnum.ehEvet;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @"{#PARTA.WORKSHOP#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 62, 9, false);
                    DATE.Name = "DATE";
                    DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.WordBreak = EvetHayirEnum.ehEvet;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"";

                    SHARPDIRECTLABORTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 76, 9, false);
                    SHARPDIRECTLABORTIME.Name = "SHARPDIRECTLABORTIME";
                    SHARPDIRECTLABORTIME.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME.Value = @"{#PARTA.SHARPDIRECTLABORTIME#}";

                    AVERAGEDIRECTLABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 0, 95, 9, false);
                    AVERAGEDIRECTLABORCOST.Name = "AVERAGEDIRECTLABORCOST";
                    AVERAGEDIRECTLABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    AVERAGEDIRECTLABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVERAGEDIRECTLABORCOST.TextFormat = @"#,##0.#0";
                    AVERAGEDIRECTLABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVERAGEDIRECTLABORCOST.TextFont.Name = "Arial";
                    AVERAGEDIRECTLABORCOST.TextFont.CharSet = 162;
                    AVERAGEDIRECTLABORCOST.Value = @"{#PARTA.AVARAGEDIRECTLABORCOST#}";

                    LABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 115, 9, false);
                    LABORCOST.Name = "LABORCOST";
                    LABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST.TextFormat = @"#,##0.#0";
                    LABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST.TextFont.Name = "Arial";
                    LABORCOST.TextFont.CharSet = 162;
                    LABORCOST.Value = @"{#PARTA.LABORCOST#}";

                    AVERAGEGENERALPROCESSINGCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 138, 9, false);
                    AVERAGEGENERALPROCESSINGCOST.Name = "AVERAGEGENERALPROCESSINGCOST";
                    AVERAGEGENERALPROCESSINGCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    AVERAGEGENERALPROCESSINGCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVERAGEGENERALPROCESSINGCOST.TextFormat = @"#,##0.#0";
                    AVERAGEGENERALPROCESSINGCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVERAGEGENERALPROCESSINGCOST.TextFont.Name = "Arial";
                    AVERAGEGENERALPROCESSINGCOST.TextFont.CharSet = 162;
                    AVERAGEGENERALPROCESSINGCOST.Value = @"{#PARTA.AVERAGEGENERALPROCESSINGCOST#}";

                    GENERALPROCESSINGCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 154, 9, false);
                    GENERALPROCESSINGCOST.Name = "GENERALPROCESSINGCOST";
                    GENERALPROCESSINGCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    GENERALPROCESSINGCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALPROCESSINGCOST.TextFormat = @"#,##0.#0";
                    GENERALPROCESSINGCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALPROCESSINGCOST.TextFont.Name = "Arial";
                    GENERALPROCESSINGCOST.TextFont.CharSet = 162;
                    GENERALPROCESSINGCOST.Value = @"{#PARTA.GENERALPROCESSINGCOST#}";

                    AVERAGEDEPRECIATIONEXPENSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 177, 9, false);
                    AVERAGEDEPRECIATIONEXPENSE.Name = "AVERAGEDEPRECIATIONEXPENSE";
                    AVERAGEDEPRECIATIONEXPENSE.DrawStyle = DrawStyleConstants.vbSolid;
                    AVERAGEDEPRECIATIONEXPENSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVERAGEDEPRECIATIONEXPENSE.TextFormat = @"#,##0.#0";
                    AVERAGEDEPRECIATIONEXPENSE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVERAGEDEPRECIATIONEXPENSE.TextFont.Name = "Arial";
                    AVERAGEDEPRECIATIONEXPENSE.TextFont.CharSet = 162;
                    AVERAGEDEPRECIATIONEXPENSE.Value = @"{#PARTA.AVERAGEDEPRECIATIONEXPENSE#}";

                    DEPRECIATIONEXPENSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 200, 9, false);
                    DEPRECIATIONEXPENSE.Name = "DEPRECIATIONEXPENSE";
                    DEPRECIATIONEXPENSE.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPRECIATIONEXPENSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPRECIATIONEXPENSE.TextFormat = @"#,##0.#0";
                    DEPRECIATIONEXPENSE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEPRECIATIONEXPENSE.TextFont.Name = "Arial";
                    DEPRECIATIONEXPENSE.TextFont.CharSet = 162;
                    DEPRECIATIONEXPENSE.Value = @"{#PARTA.DEPRECIATIONEXPENSE#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 3, 227, 8, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.Value = @"{#PARTA.MONTH#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 3, 238, 8, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.Value = @"{#PARTA.YEAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class dataset_GetMaintenanceOrderCostByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(0);
                    WORKSHOP.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Workshop) : "");
                    DATE.CalcValue = @"";
                    SHARPDIRECTLABORTIME.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Sharpdirectlabortime) : "");
                    AVERAGEDIRECTLABORCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Avaragedirectlaborcost) : "");
                    LABORCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Laborcost) : "");
                    AVERAGEGENERALPROCESSINGCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Averagegeneralprocessingcost) : "");
                    GENERALPROCESSINGCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Generalprocessingcost) : "");
                    AVERAGEDEPRECIATIONEXPENSE.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Averagedepreciationexpense) : "");
                    DEPRECIATIONEXPENSE.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Depreciationexpense) : "");
                    MONTH.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Month) : "");
                    YEAR.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Year) : "");
                    return new TTReportObject[] { WORKSHOP,DATE,SHARPDIRECTLABORTIME,AVERAGEDIRECTLABORCOST,LABORCOST,AVERAGEGENERALPROCESSINGCOST,GENERALPROCESSINGCOST,AVERAGEDEPRECIATIONEXPENSE,DEPRECIATIONEXPENSE,MONTH,YEAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    switch (Convert.ToInt32(MONTH.CalcValue))
                    {
                        case 1:
                            DATE.CalcValue = "OCAK\n";
                            break;

                        case 2:
                            DATE.CalcValue = "ŞUBAT\n";
                            break;

                        case 3:
                            DATE.CalcValue = "MART\n";
                            break;

                        case 4:
                            DATE.CalcValue = "NİSAN\n";
                            break;

                        case 5:
                            DATE.CalcValue = "MAYIS\n";
                            break;

                        case 6:
                            DATE.CalcValue = "HAZİRAN\n";
                            break;

                        case 7:
                            DATE.CalcValue = "TEMMUZ\n";
                            break;

                        case 8:
                            DATE.CalcValue = "AĞUSTOS\n";
                            break;

                        case 9:
                            DATE.CalcValue = "EYLÜL\n";
                            break;

                        case 10:
                            DATE.CalcValue = "EKİM\n";
                            break;

                        case 11:
                            DATE.CalcValue = "KASIM\n";
                            break;

                        case 12:
                            DATE.CalcValue = "ARALIK\n";
                            break;
                    }

                    DATE.CalcValue = DATE.CalcValue + YEAR.CalcValue;
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

        public CostReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COSTREPORT";
            Caption = "Maliyet Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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