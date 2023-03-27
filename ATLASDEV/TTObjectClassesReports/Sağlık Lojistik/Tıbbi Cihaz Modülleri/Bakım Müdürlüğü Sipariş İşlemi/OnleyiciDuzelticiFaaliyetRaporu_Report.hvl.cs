
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
    /// Önleyici/Düzeltici Faaliyet Raporu
    /// </summary>
    public partial class OnleyiciDuzelticiFaaliyetRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public OnleyiciDuzelticiFaaliyetRaporu MyParentReport
            {
                get { return (OnleyiciDuzelticiFaaliyetRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PRINTDATE { get {return Body().PRINTDATE;} }
            public TTReportField PREVENTIVETREATMENTWORKLOAD { get {return Body().PREVENTIVETREATMENTWORKLOAD;} }
            public TTReportField PREVENTIVETREATMENT { get {return Body().PREVENTIVETREATMENT;} }
            public TTReportField AGENDA { get {return Body().AGENDA;} }
            public TTReportField ERRORREASON { get {return Body().ERRORREASON;} }
            public TTReportField NewField113121 { get {return Body().NewField113121;} }
            public TTReportField NewField12132 { get {return Body().NewField12132;} }
            public TTReportField NewField12131 { get {return Body().NewField12131;} }
            public TTReportField NewField1312 { get {return Body().NewField1312;} }
            public TTReportField NewField11131 { get {return Body().NewField11131;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField REPORTNAME { get {return Body().REPORTNAME;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1112 { get {return Body().NewField1112;} }
            public TTReportField NewField12111 { get {return Body().NewField12111;} }
            public TTReportField NewField12112 { get {return Body().NewField12112;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField1113 { get {return Body().NewField1113;} }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField NewField12113 { get {return Body().NewField12113;} }
            public TTReportField NewField111121 { get {return Body().NewField111121;} }
            public TTReportField NewField121121 { get {return Body().NewField121121;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField NewField1311 { get {return Body().NewField1311;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportShape NewLine1221 { get {return Body().NewLine1221;} }
            public TTReportShape NewLine11221 { get {return Body().NewLine11221;} }
            public TTReportShape NewLine11222 { get {return Body().NewLine11222;} }
            public TTReportShape NewLine112211 { get {return Body().NewLine112211;} }
            public TTReportField NewField1121311 { get {return Body().NewField1121311;} }
            public TTReportShape NewLine122211 { get {return Body().NewLine122211;} }
            public TTReportShape NewLine1112211 { get {return Body().NewLine1112211;} }
            public TTReportField NewField11131211 { get {return Body().NewField11131211;} }
            public TTReportShape NewLine1112221 { get {return Body().NewLine1112221;} }
            public TTReportShape NewLine123 { get {return Body().NewLine123;} }
            public TTReportShape NewLine1321 { get {return Body().NewLine1321;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OnleyiciDuzelticiFaaliyetRaporu MyParentReport
                {
                    get { return (OnleyiciDuzelticiFaaliyetRaporu)ParentReport; }
                }
                
                public TTReportField PRINTDATE;
                public TTReportField PREVENTIVETREATMENTWORKLOAD;
                public TTReportField PREVENTIVETREATMENT;
                public TTReportField AGENDA;
                public TTReportField ERRORREASON;
                public TTReportField NewField113121;
                public TTReportField NewField12132;
                public TTReportField NewField12131;
                public TTReportField NewField1312;
                public TTReportField NewField11131;
                public TTReportField NewField1;
                public TTReportField REPORTNAME;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField12112;
                public TTReportField ORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField NATOSTOCKNO;
                public TTReportField NewField112;
                public TTReportField NewField1113;
                public TTReportField NewField11111;
                public TTReportField NewField12113;
                public TTReportField NewField111121;
                public TTReportField NewField121121;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField113;
                public TTReportShape NewLine12;
                public TTReportField NewField1311;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1221;
                public TTReportShape NewLine11221;
                public TTReportShape NewLine11222;
                public TTReportShape NewLine112211;
                public TTReportField NewField1121311;
                public TTReportShape NewLine122211;
                public TTReportShape NewLine1112211;
                public TTReportField NewField11131211;
                public TTReportShape NewLine1112221;
                public TTReportShape NewLine123;
                public TTReportShape NewLine1321;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportField NewField12; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    RepeatCount = 0;
                    
                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 30, 170, 35, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.TextFormat = @"dd/MM/yyyy";
                    PRINTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRINTDATE.TextFont.Name = "Arial";
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@}";

                    PREVENTIVETREATMENTWORKLOAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 192, 169, 219, false);
                    PREVENTIVETREATMENTWORKLOAD.Name = "PREVENTIVETREATMENTWORKLOAD";
                    PREVENTIVETREATMENTWORKLOAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREVENTIVETREATMENTWORKLOAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PREVENTIVETREATMENTWORKLOAD.MultiLine = EvetHayirEnum.ehEvet;
                    PREVENTIVETREATMENTWORKLOAD.WordBreak = EvetHayirEnum.ehEvet;
                    PREVENTIVETREATMENTWORKLOAD.ObjectDefName = "MaintenanceOrder";
                    PREVENTIVETREATMENTWORKLOAD.DataMember = "PREVENTIVETREATMENTWORKLOAD";
                    PREVENTIVETREATMENTWORKLOAD.TextFont.Name = "Arial";
                    PREVENTIVETREATMENTWORKLOAD.TextFont.CharSet = 162;
                    PREVENTIVETREATMENTWORKLOAD.Value = @"{@TTOBJECTID@}";

                    PREVENTIVETREATMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 158, 169, 187, false);
                    PREVENTIVETREATMENT.Name = "PREVENTIVETREATMENT";
                    PREVENTIVETREATMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREVENTIVETREATMENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PREVENTIVETREATMENT.MultiLine = EvetHayirEnum.ehEvet;
                    PREVENTIVETREATMENT.WordBreak = EvetHayirEnum.ehEvet;
                    PREVENTIVETREATMENT.ObjectDefName = "MaintenanceOrder";
                    PREVENTIVETREATMENT.DataMember = "PREVENTIVETREATMENT";
                    PREVENTIVETREATMENT.TextFont.Name = "Arial";
                    PREVENTIVETREATMENT.TextFont.CharSet = 162;
                    PREVENTIVETREATMENT.Value = @"{@TTOBJECTID@}";

                    AGENDA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 119, 169, 148, false);
                    AGENDA.Name = "AGENDA";
                    AGENDA.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGENDA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGENDA.MultiLine = EvetHayirEnum.ehEvet;
                    AGENDA.WordBreak = EvetHayirEnum.ehEvet;
                    AGENDA.ObjectDefName = "MaintenanceOrder";
                    AGENDA.DataMember = "AGENDA";
                    AGENDA.TextFont.Name = "Arial";
                    AGENDA.TextFont.CharSet = 162;
                    AGENDA.Value = @"{@TTOBJECTID@}";

                    ERRORREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 74, 169, 99, false);
                    ERRORREASON.Name = "ERRORREASON";
                    ERRORREASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERRORREASON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ERRORREASON.MultiLine = EvetHayirEnum.ehEvet;
                    ERRORREASON.WordBreak = EvetHayirEnum.ehEvet;
                    ERRORREASON.ObjectDefName = "MaintenanceOrder";
                    ERRORREASON.DataMember = "ERRORREASON";
                    ERRORREASON.TextFont.Name = "Arial";
                    ERRORREASON.TextFont.CharSet = 162;
                    ERRORREASON.Value = @"       {@TTOBJECTID@}";

                    NewField113121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 187, 91, 192, false);
                    NewField113121.Name = "NewField113121";
                    NewField113121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113121.TextFont.Name = "Arial";
                    NewField113121.TextFont.Bold = true;
                    NewField113121.TextFont.CharSet = 162;
                    NewField113121.Value = @" Düzeltici İşleme Harcanan Malzeme ve Zaman:";

                    NewField12132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 153, 44, 158, false);
                    NewField12132.Name = "NewField12132";
                    NewField12132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12132.TextFont.Name = "Arial";
                    NewField12132.TextFont.Bold = true;
                    NewField12132.TextFont.CharSet = 162;
                    NewField12132.Value = @" Yapılan Düzeltici İşlem:";

                    NewField12131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 143, 12, 148, false);
                    NewField12131.Name = "NewField12131";
                    NewField12131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12131.TextFont.Name = "Arial";
                    NewField12131.TextFont.Bold = true;
                    NewField12131.TextFont.CharSet = 162;
                    NewField12131.Value = @" Miat:";

                    NewField1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 114, 44, 119, false);
                    NewField1312.Name = "NewField1312";
                    NewField1312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1312.TextFont.Name = "Arial";
                    NewField1312.TextFont.Bold = true;
                    NewField1312.TextFont.CharSet = 162;
                    NewField1312.Value = @" Yapılacak Düzeltmeler:";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 99, 170, 104, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11131.TextFont.Name = "Arial";
                    NewField11131.TextFont.Bold = true;
                    NewField11131.TextFont.CharSet = 162;
                    NewField11131.Value = @"Hatayı Tespit Eden Birim İmzaları:";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 5, 100, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HİZMETE ÖZEL";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 170, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"ÖNLEYİCİ/DÜZELTİCİ FAALİYET RAPORU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 30, 40, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" 1.Sipariş Numarası";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 35, 40, 40, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @" 2.Malzeme Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 40, 45, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @" 3.NATO Stok/Parça Nu.";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 30, 41, 35, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @":";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 35, 41, 40, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @":";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 41, 45, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112.TextFont.Name = "Arial";
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @":";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 30, 102, 35, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 35, 102, 40, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#FIXEDASSETNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 40, 102, 45, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 30, 141, 35, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Düzenleme Tarihi";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 35, 141, 40, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"Düzeltici Faaliyet Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 40, 141, 45, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Referans Nu.";

                    NewField12113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 30, 142, 35, false);
                    NewField12113.Name = "NewField12113";
                    NewField12113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12113.TextFont.Name = "Arial";
                    NewField12113.TextFont.Bold = true;
                    NewField12113.TextFont.CharSet = 162;
                    NewField12113.Value = @":";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 35, 142, 40, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111121.TextFont.Name = "Arial";
                    NewField111121.TextFont.Bold = true;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @":";

                    NewField121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 40, 142, 45, false);
                    NewField121121.Name = "NewField121121";
                    NewField121121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121121.TextFont.Name = "Arial";
                    NewField121121.TextFont.Bold = true;
                    NewField121121.TextFont.CharSet = 162;
                    NewField121121.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 35, 170, 35, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 40, 170, 40, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 29, 50, false);
                    NewField113.Name = "NewField113";
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Name = "Arial";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @" Hatanın Tanımı:";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 45, 170, 45, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 69, 61, 74, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Name = "Arial";
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @" Muhtemel Hata Nedeni ve Öneriler:";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 99, 170, 99, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 114, 170, 114, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 148, 170, 148, false);
                    NewLine1221.Name = "NewLine1221";
                    NewLine1221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 153, 170, 153, false);
                    NewLine11221.Name = "NewLine11221";
                    NewLine11221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11222 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 187, 170, 187, false);
                    NewLine11222.Name = "NewLine11222";
                    NewLine11222.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 192, 170, 192, false);
                    NewLine112211.Name = "NewLine112211";
                    NewLine112211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 219, 170, 224, false);
                    NewField1121311.Name = "NewField1121311";
                    NewField1121311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121311.TextFont.Name = "Arial";
                    NewField1121311.TextFont.Bold = true;
                    NewField1121311.TextFont.CharSet = 162;
                    NewField1121311.Value = @"Düzeltici İşlemi Yapan Personelin İmzaları";

                    NewLine122211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 219, 170, 219, false);
                    NewLine122211.Name = "NewLine122211";
                    NewLine122211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 224, 170, 224, false);
                    NewLine1112211.Name = "NewLine1112211";
                    NewLine1112211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11131211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 247, 170, 252, false);
                    NewField11131211.Name = "NewField11131211";
                    NewField11131211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11131211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11131211.TextFont.Name = "Arial";
                    NewField11131211.TextFont.Bold = true;
                    NewField11131211.TextFont.CharSet = 162;
                    NewField11131211.Value = @"Doğrulama Kontrolü Yapan Personelin İmzaları";

                    NewLine1112221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 247, 170, 247, false);
                    NewLine1112221.Name = "NewLine1112221";
                    NewLine1112221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 30, 170, 30, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123.DrawWidth = 2;

                    NewLine1321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 275, 170, 275, false);
                    NewLine1321.Name = "NewLine1321";
                    NewLine1321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1321.DrawWidth = 2;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 30, 170, 275, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 30, 0, 275, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 283, 100, 288, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    PREVENTIVETREATMENTWORKLOAD.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PREVENTIVETREATMENTWORKLOAD.PostFieldValueCalculation();
                    PREVENTIVETREATMENT.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PREVENTIVETREATMENT.PostFieldValueCalculation();
                    AGENDA.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    AGENDA.PostFieldValueCalculation();
                    ERRORREASON.CalcValue = @"       " + MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ERRORREASON.PostFieldValueCalculation();
                    NewField113121.CalcValue = NewField113121.Value;
                    NewField12132.CalcValue = NewField12132.Value;
                    NewField12131.CalcValue = NewField12131.Value;
                    NewField1312.CalcValue = NewField1312.Value;
                    NewField11131.CalcValue = NewField11131.Value;
                    NewField1.CalcValue = NewField1.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    ORDERNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    NewField112.CalcValue = NewField112.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField12113.CalcValue = NewField12113.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField121121.CalcValue = NewField121121.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField1121311.CalcValue = NewField1121311.Value;
                    NewField11131211.CalcValue = NewField11131211.Value;
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { PRINTDATE,PREVENTIVETREATMENTWORKLOAD,PREVENTIVETREATMENT,AGENDA,ERRORREASON,NewField113121,NewField12132,NewField12131,NewField1312,NewField11131,NewField1,REPORTNAME,NewField11,NewField111,NewField1111,NewField1112,NewField12111,NewField12112,ORDERNO,MATERIALNAME,NATOSTOCKNO,NewField112,NewField1113,NewField11111,NewField12113,NewField111121,NewField121121,NewField113,NewField1311,NewField1121311,NewField11131211,NewField12};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //TTObjectContext ctx = new TTObjectContext(true);
                    //string objectID = ((OnleyiciDuzelticiFaaliyetRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    //MaintenanceOrder maintenanceOrder = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
                    //if (maintenanceOrder != null)
                    //{
                    //    ERRORREASON.CalcValue = maintenanceOrder.ErrorReason.ToString();
                    //    AGENDA.CalcValue = maintenanceOrder.Agenda.ToString();
                    //    PREVENTIVETREATMENT.CalcValue = "       " + maintenanceOrder.PreventiveTreatment.ToString();
                    //}
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

        public OnleyiciDuzelticiFaaliyetRaporu()
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
            Name = "ONLEYICIDUZELTICIFAALIYETRAPORU";
            Caption = "Önleyici/Düzeltici Faaliyet Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
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