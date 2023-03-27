
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
    /// Sipariş Takip ve Kayıt Defteri
    /// </summary>
    public partial class OrderChaseAndRegistryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STARTDATE = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public OrderChaseAndRegistryReport MyParentReport
            {
                get { return (OrderChaseAndRegistryReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PAGENUMBER { get {return Header().PAGENUMBER;} }
            public TTReportField PAGENUMBER11 { get {return Header().PAGENUMBER11;} }
            public TTReportField ACCOUNTYEAR { get {return Header().ACCOUNTYEAR;} }
            public TTReportField PAGENUMBER1 { get {return Header().PAGENUMBER1;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField PAGENUMBER111 { get {return Header().PAGENUMBER111;} }
            public TTReportField PAGENUMBER1111 { get {return Header().PAGENUMBER1111;} }
            public TTReportField PAGENUMBER1112 { get {return Header().PAGENUMBER1112;} }
            public TTReportField PAGENUMBER12111 { get {return Header().PAGENUMBER12111;} }
            public TTReportField PAGENUMBER12112 { get {return Header().PAGENUMBER12112;} }
            public TTReportField PAGENUMBER12113 { get {return Header().PAGENUMBER12113;} }
            public TTReportField PAGENUMBER131121 { get {return Header().PAGENUMBER131121;} }
            public TTReportField PAGENUMBER1121131 { get {return Header().PAGENUMBER1121131;} }
            public TTReportField PAGENUMBER1121132 { get {return Header().PAGENUMBER1121132;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public OrderChaseAndRegistryReport MyParentReport
                {
                    get { return (OrderChaseAndRegistryReport)ParentReport; }
                }
                
                public TTReportField PAGENUMBER;
                public TTReportField PAGENUMBER11;
                public TTReportField ACCOUNTYEAR;
                public TTReportField PAGENUMBER1;
                public TTReportField REPORTNAME;
                public TTReportField PAGENUMBER111;
                public TTReportField PAGENUMBER1111;
                public TTReportField PAGENUMBER1112;
                public TTReportField PAGENUMBER12111;
                public TTReportField PAGENUMBER12112;
                public TTReportField PAGENUMBER12113;
                public TTReportField PAGENUMBER131121;
                public TTReportField PAGENUMBER1121131;
                public TTReportField PAGENUMBER1121132;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 42, 19, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER.DrawWidth = 2;
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 11;
                    PAGENUMBER.TextFont.Bold = true;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @" SAYFA NU. : {@pagenumber@}/{@pagecount@}";

                    PAGENUMBER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 19, 42, 34, false);
                    PAGENUMBER11.Name = "PAGENUMBER11";
                    PAGENUMBER11.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER11.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER11.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER11.TextFont.Name = "Arial";
                    PAGENUMBER11.TextFont.Bold = true;
                    PAGENUMBER11.TextFont.CharSet = 162;
                    PAGENUMBER11.Value = @"SİPARİŞİN NUMARASI";

                    ACCOUNTYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 10, 287, 19, false);
                    ACCOUNTYEAR.Name = "ACCOUNTYEAR";
                    ACCOUNTYEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ACCOUNTYEAR.DrawWidth = 2;
                    ACCOUNTYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTYEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTYEAR.TextFont.Name = "Arial";
                    ACCOUNTYEAR.TextFont.Size = 11;
                    ACCOUNTYEAR.TextFont.Bold = true;
                    ACCOUNTYEAR.TextFont.CharSet = 162;
                    ACCOUNTYEAR.Value = @" MALİ YIL : {@STARTDATE@}";

                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 19, 34, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER1.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER1.TextFont.Name = "Arial";
                    PAGENUMBER1.TextFont.Bold = true;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"S.
NU.";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 10, 237, 19, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME.DrawWidth = 2;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 14;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"SİPARİŞ TAKİP VE KAYIT DEFTERİ";

                    PAGENUMBER111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 19, 97, 34, false);
                    PAGENUMBER111.Name = "PAGENUMBER111";
                    PAGENUMBER111.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER111.TextFont.Name = "Arial";
                    PAGENUMBER111.TextFont.Bold = true;
                    PAGENUMBER111.TextFont.CharSet = 162;
                    PAGENUMBER111.Value = @"MALZEMENİN İSMİ";

                    PAGENUMBER1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 19, 146, 34, false);
                    PAGENUMBER1111.Name = "PAGENUMBER1111";
                    PAGENUMBER1111.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1111.TextFont.Name = "Arial";
                    PAGENUMBER1111.TextFont.Bold = true;
                    PAGENUMBER1111.TextFont.CharSet = 162;
                    PAGENUMBER1111.Value = @"BİRLİĞİ";

                    PAGENUMBER1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 19, 164, 34, false);
                    PAGENUMBER1112.Name = "PAGENUMBER1112";
                    PAGENUMBER1112.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1112.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER1112.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER1112.TextFont.Name = "Arial";
                    PAGENUMBER1112.TextFont.Bold = true;
                    PAGENUMBER1112.TextFont.CharSet = 162;
                    PAGENUMBER1112.Value = @"SİPARİŞ
MİKTARI
(ADET)";

                    PAGENUMBER12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 19, 184, 34, false);
                    PAGENUMBER12111.Name = "PAGENUMBER12111";
                    PAGENUMBER12111.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER12111.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER12111.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER12111.TextFont.Name = "Arial";
                    PAGENUMBER12111.TextFont.Bold = true;
                    PAGENUMBER12111.TextFont.CharSet = 162;
                    PAGENUMBER12111.Value = @"SİPARİŞ
İSTEK
TARİHİ";

                    PAGENUMBER12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 19, 204, 34, false);
                    PAGENUMBER12112.Name = "PAGENUMBER12112";
                    PAGENUMBER12112.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER12112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER12112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER12112.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER12112.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER12112.TextFont.Name = "Arial";
                    PAGENUMBER12112.TextFont.Bold = true;
                    PAGENUMBER12112.TextFont.CharSet = 162;
                    PAGENUMBER12112.Value = @"ATÖLYEYE VERİLİŞ TARİHİ";

                    PAGENUMBER12113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 19, 237, 34, false);
                    PAGENUMBER12113.Name = "PAGENUMBER12113";
                    PAGENUMBER12113.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER12113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER12113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER12113.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER12113.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER12113.TextFont.Name = "Arial";
                    PAGENUMBER12113.TextFont.Bold = true;
                    PAGENUMBER12113.TextFont.CharSet = 162;
                    PAGENUMBER12113.Value = @"SORUMLU TEKNİSYEN";

                    PAGENUMBER131121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 19, 257, 34, false);
                    PAGENUMBER131121.Name = "PAGENUMBER131121";
                    PAGENUMBER131121.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER131121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER131121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER131121.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER131121.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER131121.TextFont.Name = "Arial";
                    PAGENUMBER131121.TextFont.Bold = true;
                    PAGENUMBER131121.TextFont.CharSet = 162;
                    PAGENUMBER131121.Value = @"SİPARİŞİN
KAPANMA
TARİHİ";

                    PAGENUMBER1121131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 19, 273, 34, false);
                    PAGENUMBER1121131.Name = "PAGENUMBER1121131";
                    PAGENUMBER1121131.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER1121131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER1121131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1121131.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER1121131.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER1121131.TextFont.Name = "Arial";
                    PAGENUMBER1121131.TextFont.Bold = true;
                    PAGENUMBER1121131.TextFont.CharSet = 162;
                    PAGENUMBER1121131.Value = @"CİHAZIN
DURUMU";

                    PAGENUMBER1121132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 19, 287, 34, false);
                    PAGENUMBER1121132.Name = "PAGENUMBER1121132";
                    PAGENUMBER1121132.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENUMBER1121132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER1121132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER1121132.MultiLine = EvetHayirEnum.ehEvet;
                    PAGENUMBER1121132.WordBreak = EvetHayirEnum.ehEvet;
                    PAGENUMBER1121132.TextFont.Name = "Arial";
                    PAGENUMBER1121132.TextFont.Bold = true;
                    PAGENUMBER1121132.TextFont.CharSet = 162;
                    PAGENUMBER1121132.Value = @"DÜŞ
ÜNCE
LER";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 19, 10, 34, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 19, 287, 34, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @" SAYFA NU. : " + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PAGENUMBER11.CalcValue = PAGENUMBER11.Value;
                    ACCOUNTYEAR.CalcValue = @" MALİ YIL : " + MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    PAGENUMBER1.CalcValue = PAGENUMBER1.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    PAGENUMBER111.CalcValue = PAGENUMBER111.Value;
                    PAGENUMBER1111.CalcValue = PAGENUMBER1111.Value;
                    PAGENUMBER1112.CalcValue = PAGENUMBER1112.Value;
                    PAGENUMBER12111.CalcValue = PAGENUMBER12111.Value;
                    PAGENUMBER12112.CalcValue = PAGENUMBER12112.Value;
                    PAGENUMBER12113.CalcValue = PAGENUMBER12113.Value;
                    PAGENUMBER131121.CalcValue = PAGENUMBER131121.Value;
                    PAGENUMBER1121131.CalcValue = PAGENUMBER1121131.Value;
                    PAGENUMBER1121132.CalcValue = PAGENUMBER1121132.Value;
                    return new TTReportObject[] { PAGENUMBER,PAGENUMBER11,ACCOUNTYEAR,PAGENUMBER1,REPORTNAME,PAGENUMBER111,PAGENUMBER1111,PAGENUMBER1112,PAGENUMBER12111,PAGENUMBER12112,PAGENUMBER12113,PAGENUMBER131121,PAGENUMBER1121131,PAGENUMBER1121132};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OrderChaseAndRegistryReport MyParentReport
                {
                    get { return (OrderChaseAndRegistryReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public OrderChaseAndRegistryReport MyParentReport
            {
                get { return (OrderChaseAndRegistryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField WORKSHOPDELIVERYDATE { get {return Body().WORKSHOPDELIVERYDATE;} }
            public TTReportField RESPONSIBLEUSER { get {return Body().RESPONSIBLEUSER;} }
            public TTReportField CLOSEDATE { get {return Body().CLOSEDATE;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField ORDERSTATUS { get {return Body().ORDERSTATUS;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class>("GetOrderChaseAndRegistryReportQuery", MaintenanceOrder.GetOrderChaseAndRegistryReportQuery((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
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
                public OrderChaseAndRegistryReport MyParentReport
                {
                    get { return (OrderChaseAndRegistryReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField ORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField MILITARYUNIT;
                public TTReportField AMOUNT;
                public TTReportField REQUESTDATE;
                public TTReportField WORKSHOPDELIVERYDATE;
                public TTReportField RESPONSIBLEUSER;
                public TTReportField CLOSEDATE;
                public TTReportField STATUS;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField ORDERSTATUS; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 10, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 42, 10, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 97, 10, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 146, 10, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{#OWNERMILITARYUNIT#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 164, 10, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 184, 10, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDATE.TextFont.Name = "Arial";
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    WORKSHOPDELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 204, 10, false);
                    WORKSHOPDELIVERYDATE.Name = "WORKSHOPDELIVERYDATE";
                    WORKSHOPDELIVERYDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOPDELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOPDELIVERYDATE.TextFormat = @"dd/MM/yyyy";
                    WORKSHOPDELIVERYDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOPDELIVERYDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOPDELIVERYDATE.MultiLine = EvetHayirEnum.ehEvet;
                    WORKSHOPDELIVERYDATE.WordBreak = EvetHayirEnum.ehEvet;
                    WORKSHOPDELIVERYDATE.TextFont.Name = "Arial";
                    WORKSHOPDELIVERYDATE.TextFont.CharSet = 162;
                    WORKSHOPDELIVERYDATE.Value = @"{#ORDERDATE#}";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 0, 237, 10, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RESPONSIBLEUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESPONSIBLEUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEUSER.MultiLine = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.WordBreak = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.TextFont.Name = "Arial";
                    RESPONSIBLEUSER.TextFont.CharSet = 162;
                    RESPONSIBLEUSER.Value = @"{#RESPONSIBLEUSER#}";

                    CLOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 257, 10, false);
                    CLOSEDATE.Name = "CLOSEDATE";
                    CLOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    CLOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSEDATE.TextFormat = @"dd/MM/yyyy";
                    CLOSEDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLOSEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLOSEDATE.MultiLine = EvetHayirEnum.ehEvet;
                    CLOSEDATE.WordBreak = EvetHayirEnum.ehEvet;
                    CLOSEDATE.TextFont.Name = "Arial";
                    CLOSEDATE.TextFont.CharSet = 162;
                    CLOSEDATE.Value = @"{#ENDDATE#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 273, 10, false);
                    STATUS.Name = "STATUS";
                    STATUS.DrawStyle = DrawStyleConstants.vbSolid;
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATUS.MultiLine = EvetHayirEnum.ehEvet;
                    STATUS.WordBreak = EvetHayirEnum.ehEvet;
                    STATUS.TextFont.Name = "Arial";
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 0, 287, 10, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 10, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    ORDERSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 0, 333, 5, false);
                    ORDERSTATUS.Name = "ORDERSTATUS";
                    ORDERSTATUS.Visible = EvetHayirEnum.ehHayir;
                    ORDERSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERSTATUS.Value = @"{#ORDERSTATUS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class dataset_GetOrderChaseAndRegistryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    ORDERNO.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.OrderNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.Materialname) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.Ownermilitaryunit) : "");
                    AMOUNT.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.Amount) : "");
                    REQUESTDATE.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.RequestDate) : "");
                    WORKSHOPDELIVERYDATE.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.OrderDate) : "");
                    RESPONSIBLEUSER.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.Responsibleuser) : "");
                    CLOSEDATE.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.EndDate) : "");
                    STATUS.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    ORDERSTATUS.CalcValue = (dataset_GetOrderChaseAndRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetOrderChaseAndRegistryReportQuery.OrderStatus) : "");
                    return new TTReportObject[] { COUNT,ORDERNO,MATERIALNAME,MILITARYUNIT,AMOUNT,REQUESTDATE,WORKSHOPDELIVERYDATE,RESPONSIBLEUSER,CLOSEDATE,STATUS,DESCRIPTION,ORDERSTATUS};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(ORDERSTATUS.CalcValue == "Active")
                STATUS.CalcValue = "FAAL";
            
            if(ORDERSTATUS.CalcValue == "HEKFromFromExamination" || ORDERSTATUS.CalcValue == "HEKFromFromRepair")
                STATUS.CalcValue = "HEK";
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

        public OrderChaseAndRegistryReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Mali Yılı Giriniz", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["STARTDATE"]);
            Name = "ORDERCHASEANDREGISTRYREPORT";
            Caption = "Sipariş Takip ve Kayıt Defteri";
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