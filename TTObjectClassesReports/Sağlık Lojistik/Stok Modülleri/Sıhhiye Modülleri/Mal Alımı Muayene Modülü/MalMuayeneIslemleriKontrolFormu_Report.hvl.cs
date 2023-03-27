
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
    /// Mal Muayene İşlemleri Kontrol Formu
    /// </summary>
    public partial class MalMuayeneIslemleriKontrolFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public MalMuayeneIslemleriKontrolFormu MyParentReport
            {
                get { return (MalMuayeneIslemleriKontrolFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField CONTRACTDATENO { get {return Body().CONTRACTDATENO;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField INSPECTIONDATE { get {return Body().INSPECTIONDATE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1122 { get {return Body().NewField1122;} }
            public TTReportField NewField1123 { get {return Body().NewField1123;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField13211 { get {return Body().NewField13211;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField111221 { get {return Body().NewField111221;} }
            public TTReportField NewField111212 { get {return Body().NewField111212;} }
            public TTReportField NewField111222 { get {return Body().NewField111222;} }
            public TTReportField NewField111213 { get {return Body().NewField111213;} }
            public TTReportField NewField111223 { get {return Body().NewField111223;} }
            public TTReportField NewField111214 { get {return Body().NewField111214;} }
            public TTReportField NewField111224 { get {return Body().NewField111224;} }
            public TTReportField NewField111215 { get {return Body().NewField111215;} }
            public TTReportField NewField111225 { get {return Body().NewField111225;} }
            public TTReportField NewField13212 { get {return Body().NewField13212;} }
            public TTReportField NewField111231 { get {return Body().NewField111231;} }
            public TTReportField NewField1412111 { get {return Body().NewField1412111;} }
            public TTReportField NewField1422111 { get {return Body().NewField1422111;} }
            public TTReportField NewField1512111 { get {return Body().NewField1512111;} }
            public TTReportField NewField1522111 { get {return Body().NewField1522111;} }
            public TTReportField NewField1512112 { get {return Body().NewField1512112;} }
            public TTReportField NewField1522112 { get {return Body().NewField1522112;} }
            public TTReportField NewField121231 { get {return Body().NewField121231;} }
            public TTReportField NewField1132111 { get {return Body().NewField1132111;} }
            public TTReportField NewField11112141 { get {return Body().NewField11112141;} }
            public TTReportField NewField11112241 { get {return Body().NewField11112241;} }
            public TTReportField NewField11112151 { get {return Body().NewField11112151;} }
            public TTReportField NewField11112251 { get {return Body().NewField11112251;} }
            public TTReportField NewField12112151 { get {return Body().NewField12112151;} }
            public TTReportField NewField12112251 { get {return Body().NewField12112251;} }
            public TTReportField NewField114121111 { get {return Body().NewField114121111;} }
            public TTReportField NewField114221111 { get {return Body().NewField114221111;} }
            public TTReportField NewField115121111 { get {return Body().NewField115121111;} }
            public TTReportField NewField115221111 { get {return Body().NewField115221111;} }
            public TTReportField NewField115121121 { get {return Body().NewField115121121;} }
            public TTReportField NewField115221121 { get {return Body().NewField115221121;} }
            public TTReportField NewField114121112 { get {return Body().NewField114121112;} }
            public TTReportField NewField114221112 { get {return Body().NewField114221112;} }
            public TTReportField NewField115121112 { get {return Body().NewField115121112;} }
            public TTReportField NewField115221112 { get {return Body().NewField115221112;} }
            public TTReportField NewField115121122 { get {return Body().NewField115121122;} }
            public TTReportField NewField115221122 { get {return Body().NewField115221122;} }
            public TTReportField NewField114121113 { get {return Body().NewField114121113;} }
            public TTReportField NewField114221113 { get {return Body().NewField114221113;} }
            public TTReportField NewField115121123 { get {return Body().NewField115121123;} }
            public TTReportField NewField115221123 { get {return Body().NewField115221123;} }
            public TTReportField NewField1132121 { get {return Body().NewField1132121;} }
            public TTReportField NewField11112311 { get {return Body().NewField11112311;} }
            public TTReportField NewField114121114 { get {return Body().NewField114121114;} }
            public TTReportField NewField114221114 { get {return Body().NewField114221114;} }
            public TTReportField NewField115121113 { get {return Body().NewField115121113;} }
            public TTReportField NewField115221113 { get {return Body().NewField115221113;} }
            public TTReportField NewField115121124 { get {return Body().NewField115121124;} }
            public TTReportField NewField115221124 { get {return Body().NewField115221124;} }
            public TTReportField NewField1111121411 { get {return Body().NewField1111121411;} }
            public TTReportField NewField1111122411 { get {return Body().NewField1111122411;} }
            public TTReportField NewField1111121511 { get {return Body().NewField1111121511;} }
            public TTReportField NewField1111122511 { get {return Body().NewField1111122511;} }
            public TTReportField NewField1121121511 { get {return Body().NewField1121121511;} }
            public TTReportField NewField1121122511 { get {return Body().NewField1121122511;} }
            public TTReportField NewField1211121411 { get {return Body().NewField1211121411;} }
            public TTReportField NewField1211122411 { get {return Body().NewField1211122411;} }
            public TTReportField NewField1211121511 { get {return Body().NewField1211121511;} }
            public TTReportField NewField1211122511 { get {return Body().NewField1211122511;} }
            public TTReportField NewField1221121511 { get {return Body().NewField1221121511;} }
            public TTReportField NewField1221122511 { get {return Body().NewField1221122511;} }
            public TTReportField NewField1311121411 { get {return Body().NewField1311121411;} }
            public TTReportField NewField1311122411 { get {return Body().NewField1311122411;} }
            public TTReportField NewField1321121511 { get {return Body().NewField1321121511;} }
            public TTReportField NewField1321122511 { get {return Body().NewField1321122511;} }
            public TTReportField NewField115121114 { get {return Body().NewField115121114;} }
            public TTReportField NewField115221114 { get {return Body().NewField115221114;} }
            public TTReportField NewField1111121412 { get {return Body().NewField1111121412;} }
            public TTReportField NewField1111122412 { get {return Body().NewField1111122412;} }
            public TTReportField NewField1111121512 { get {return Body().NewField1111121512;} }
            public TTReportField NewField1111122512 { get {return Body().NewField1111122512;} }
            public TTReportField NewField1121121512 { get {return Body().NewField1121121512;} }
            public TTReportField NewField1121122512 { get {return Body().NewField1121122512;} }
            public TTReportField NewField1211121412 { get {return Body().NewField1211121412;} }
            public TTReportField NewField1211122412 { get {return Body().NewField1211122412;} }
            public TTReportField NewField1221121512 { get {return Body().NewField1221121512;} }
            public TTReportField NewField1221122512 { get {return Body().NewField1221122512;} }
            public TTReportField NewField121232 { get {return Body().NewField121232;} }
            public TTReportField NewField1132112 { get {return Body().NewField1132112;} }
            public TTReportField NewField11112142 { get {return Body().NewField11112142;} }
            public TTReportField NewField11112242 { get {return Body().NewField11112242;} }
            public TTReportField NewField11112152 { get {return Body().NewField11112152;} }
            public TTReportField NewField11112252 { get {return Body().NewField11112252;} }
            public TTReportField NewField12112152 { get {return Body().NewField12112152;} }
            public TTReportField NewField12112252 { get {return Body().NewField12112252;} }
            public TTReportField NewField124121111 { get {return Body().NewField124121111;} }
            public TTReportField NewField124221111 { get {return Body().NewField124221111;} }
            public TTReportField NewField125121111 { get {return Body().NewField125121111;} }
            public TTReportField NewField125221111 { get {return Body().NewField125221111;} }
            public TTReportField NewField125121121 { get {return Body().NewField125121121;} }
            public TTReportField NewField125221121 { get {return Body().NewField125221121;} }
            public TTReportField NewField124121112 { get {return Body().NewField124121112;} }
            public TTReportField NewField124221112 { get {return Body().NewField124221112;} }
            public TTReportField NewField125121122 { get {return Body().NewField125121122;} }
            public TTReportField NewField125221122 { get {return Body().NewField125221122;} }
            public TTReportField CONTRACTDATE { get {return Body().CONTRACTDATE;} }
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
                list[0] = new TTReportNqlData<PurchaseExamination.GetByObjcetID_Class>("GetByObjcetID", PurchaseExamination.GetByObjcetID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MalMuayeneIslemleriKontrolFormu MyParentReport
                {
                    get { return (MalMuayeneIslemleriKontrolFormu)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField SUPPLIER;
                public TTReportField CONTRACTDATENO;
                public TTReportField NewField14;
                public TTReportField NewField122;
                public TTReportField INSPECTIONDATE;
                public TTReportField AMOUNT;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField1123;
                public TTReportField NewField11211;
                public TTReportField NewField12211;
                public TTReportField NewField13211;
                public TTReportField NewField111211;
                public TTReportField NewField111221;
                public TTReportField NewField111212;
                public TTReportField NewField111222;
                public TTReportField NewField111213;
                public TTReportField NewField111223;
                public TTReportField NewField111214;
                public TTReportField NewField111224;
                public TTReportField NewField111215;
                public TTReportField NewField111225;
                public TTReportField NewField13212;
                public TTReportField NewField111231;
                public TTReportField NewField1412111;
                public TTReportField NewField1422111;
                public TTReportField NewField1512111;
                public TTReportField NewField1522111;
                public TTReportField NewField1512112;
                public TTReportField NewField1522112;
                public TTReportField NewField121231;
                public TTReportField NewField1132111;
                public TTReportField NewField11112141;
                public TTReportField NewField11112241;
                public TTReportField NewField11112151;
                public TTReportField NewField11112251;
                public TTReportField NewField12112151;
                public TTReportField NewField12112251;
                public TTReportField NewField114121111;
                public TTReportField NewField114221111;
                public TTReportField NewField115121111;
                public TTReportField NewField115221111;
                public TTReportField NewField115121121;
                public TTReportField NewField115221121;
                public TTReportField NewField114121112;
                public TTReportField NewField114221112;
                public TTReportField NewField115121112;
                public TTReportField NewField115221112;
                public TTReportField NewField115121122;
                public TTReportField NewField115221122;
                public TTReportField NewField114121113;
                public TTReportField NewField114221113;
                public TTReportField NewField115121123;
                public TTReportField NewField115221123;
                public TTReportField NewField1132121;
                public TTReportField NewField11112311;
                public TTReportField NewField114121114;
                public TTReportField NewField114221114;
                public TTReportField NewField115121113;
                public TTReportField NewField115221113;
                public TTReportField NewField115121124;
                public TTReportField NewField115221124;
                public TTReportField NewField1111121411;
                public TTReportField NewField1111122411;
                public TTReportField NewField1111121511;
                public TTReportField NewField1111122511;
                public TTReportField NewField1121121511;
                public TTReportField NewField1121122511;
                public TTReportField NewField1211121411;
                public TTReportField NewField1211122411;
                public TTReportField NewField1211121511;
                public TTReportField NewField1211122511;
                public TTReportField NewField1221121511;
                public TTReportField NewField1221122511;
                public TTReportField NewField1311121411;
                public TTReportField NewField1311122411;
                public TTReportField NewField1321121511;
                public TTReportField NewField1321122511;
                public TTReportField NewField115121114;
                public TTReportField NewField115221114;
                public TTReportField NewField1111121412;
                public TTReportField NewField1111122412;
                public TTReportField NewField1111121512;
                public TTReportField NewField1111122512;
                public TTReportField NewField1121121512;
                public TTReportField NewField1121122512;
                public TTReportField NewField1211121412;
                public TTReportField NewField1211122412;
                public TTReportField NewField1221121512;
                public TTReportField NewField1221122512;
                public TTReportField NewField121232;
                public TTReportField NewField1132112;
                public TTReportField NewField11112142;
                public TTReportField NewField11112242;
                public TTReportField NewField11112152;
                public TTReportField NewField11112252;
                public TTReportField NewField12112152;
                public TTReportField NewField12112252;
                public TTReportField NewField124121111;
                public TTReportField NewField124221111;
                public TTReportField NewField125121111;
                public TTReportField NewField125221111;
                public TTReportField NewField125121121;
                public TTReportField NewField125221121;
                public TTReportField NewField124121112;
                public TTReportField NewField124221112;
                public TTReportField NewField125121122;
                public TTReportField NewField125221122;
                public TTReportField CONTRACTDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 291;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 10, 186, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 9;
                    NewField1.Value = @"MAL MUAYENE İŞLEMLERİ KONTROL FORMU";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 19, 49, 24, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.Value = @"FİRMA ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 24, 49, 29, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.Value = @"SÖZLEŞME TARİH-NO";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 19, 112, 24, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.Value = @"{#SUPPLIERNAME#}";

                    CONTRACTDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 24, 112, 29, false);
                    CONTRACTDATENO.Name = "CONTRACTDATENO";
                    CONTRACTDATENO.DrawStyle = DrawStyleConstants.vbSolid;
                    CONTRACTDATENO.FieldType = ReportFieldTypeEnum.ftExpression;
                    CONTRACTDATENO.Value = @"{%CONTRACTDATE%} + "" - "" + {#CONTRACTNO#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 19, 145, 24, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.Value = @"MUA.TARİHİ VE SAATİ";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 24, 145, 29, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.Value = @"MİKTARI";

                    INSPECTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 19, 186, 24, false);
                    INSPECTIONDATE.Name = "INSPECTIONDATE";
                    INSPECTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    INSPECTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INSPECTIONDATE.Value = @"{#EXAMINATIONSTARTDATE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 24, 186, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 33, 26, 38, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.Value = @"S.N.";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 33, 170, 38, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.Value = @"İŞLEMLER";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 33, 186, 38, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.Value = @"SONUÇ";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 38, 26, 73, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123.Value = @"1";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 38, 170, 43, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.Value = @"Geldi mi?";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 38, 186, 43, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.Value = @"";

                    NewField13211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 38, 59, 73, false);
                    NewField13211.Name = "NewField13211";
                    NewField13211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13211.Value = @"Muayene muhtırası";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 43, 170, 48, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.Value = @"Gelen evrak defterine kayıt edildi mi?";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 43, 186, 48, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.Value = @"";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 48, 170, 53, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111212.Value = @"Doğruluğu kontrol edildi mi?";

                    NewField111222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 48, 186, 53, false);
                    NewField111222.Name = "NewField111222";
                    NewField111222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111222.Value = @"";

                    NewField111213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 53, 170, 63, false);
                    NewField111213.Name = "NewField111213";
                    NewField111213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111213.Value = @"Taksitle alınan malların hangi takside ait olduğu ve ne çeşit bir muayene olduğu düşünceler hanesine yazılmış mı?";

                    NewField111223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 53, 186, 63, false);
                    NewField111223.Name = "NewField111223";
                    NewField111223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111223.Value = @"";

                    NewField111214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 63, 170, 68, false);
                    NewField111214.Name = "NewField111214";
                    NewField111214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111214.Value = @"Geç getirme, eksik getirme, itiraz veya ceza bilgileri kayda geçirilmiş mi?";

                    NewField111224 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 63, 186, 68, false);
                    NewField111224.Name = "NewField111224";
                    NewField111224.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111224.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111224.Value = @"";

                    NewField111215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 68, 170, 73, false);
                    NewField111215.Name = "NewField111215";
                    NewField111215.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111215.Value = @"Sözleşmesiyle çelişen hususlar var mı?";

                    NewField111225 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 68, 186, 73, false);
                    NewField111225.Name = "NewField111225";
                    NewField111225.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111225.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111225.Value = @"";

                    NewField13212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 73, 26, 88, false);
                    NewField13212.Name = "NewField13212";
                    NewField13212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13212.Value = @"2";

                    NewField111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 73, 59, 88, false);
                    NewField111231.Name = "NewField111231";
                    NewField111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111231.Value = @"Yüklenici veya Vekili";

                    NewField1412111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 78, 170, 83, false);
                    NewField1412111.Name = "NewField1412111";
                    NewField1412111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1412111.Value = @"Muayeneye katıldı mı?";

                    NewField1422111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 78, 186, 83, false);
                    NewField1422111.Name = "NewField1422111";
                    NewField1422111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1422111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1422111.Value = @"";

                    NewField1512111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 83, 170, 88, false);
                    NewField1512111.Name = "NewField1512111";
                    NewField1512111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1512111.Value = @"Kimlik kontrolü yapıldı mı? Vekili ise noter tastikli vekaletnamesi alındı mı?";

                    NewField1522111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 83, 186, 88, false);
                    NewField1522111.Name = "NewField1522111";
                    NewField1522111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1522111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1522111.Value = @"";

                    NewField1512112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 73, 170, 78, false);
                    NewField1512112.Name = "NewField1512112";
                    NewField1512112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1512112.Value = @"Muayenin tarih ve saati yükleniciye yazılı olarak bildirildi mi?";

                    NewField1522112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 73, 186, 78, false);
                    NewField1522112.Name = "NewField1522112";
                    NewField1522112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1522112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1522112.Value = @"";

                    NewField121231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 88, 26, 148, false);
                    NewField121231.Name = "NewField121231";
                    NewField121231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121231.Value = @"3";

                    NewField1132111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 88, 59, 148, false);
                    NewField1132111.Name = "NewField1132111";
                    NewField1132111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1132111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1132111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1132111.Value = @"






Muayeneye sunulan malın";

                    NewField11112141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 93, 170, 103, false);
                    NewField11112141.Name = "NewField11112141";
                    NewField11112141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112141.Value = @"AQAP, ISO, TSE, Labaratuar Uygunluk Belgesi vb. gibi muayenede aranacak belgeler mevcut mu?";

                    NewField11112241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 93, 186, 103, false);
                    NewField11112241.Name = "NewField11112241";
                    NewField11112241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112241.Value = @"";

                    NewField11112151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 103, 170, 108, false);
                    NewField11112151.Name = "NewField11112151";
                    NewField11112151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112151.Value = @"Mal numunesi alımı için gerekli alet edavat hazır mı?";

                    NewField11112251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 103, 186, 108, false);
                    NewField11112251.Name = "NewField11112251";
                    NewField11112251.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112251.Value = @"";

                    NewField12112151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 88, 170, 93, false);
                    NewField12112151.Name = "NewField12112151";
                    NewField12112151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112151.Value = @"Sözleşmesi incelendi mi?";

                    NewField12112251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 88, 186, 93, false);
                    NewField12112251.Name = "NewField12112251";
                    NewField12112251.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112251.Value = @"";

                    NewField114121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 113, 170, 118, false);
                    NewField114121111.Name = "NewField114121111";
                    NewField114121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114121111.Value = @"İstek şekli muayeneye uygun mu?";

                    NewField114221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 113, 186, 118, false);
                    NewField114221111.Name = "NewField114221111";
                    NewField114221111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114221111.Value = @"";

                    NewField115121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 118, 170, 123, false);
                    NewField115121111.Name = "NewField115121111";
                    NewField115121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121111.Value = @"Ambalaj şekli tespit edildi mi? Ambalajın fiziksel muayenesi yapıldı mı?";

                    NewField115221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 118, 186, 123, false);
                    NewField115221111.Name = "NewField115221111";
                    NewField115221111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221111.Value = @"";

                    NewField115121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 108, 170, 113, false);
                    NewField115121121.Name = "NewField115121121";
                    NewField115121121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121121.Value = @"Tamam olup olmadığı kontrol edildi mi?";

                    NewField115221121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 108, 186, 113, false);
                    NewField115221121.Name = "NewField115221121";
                    NewField115221121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221121.Value = @"";

                    NewField114121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 128, 170, 133, false);
                    NewField114121112.Name = "NewField114121112";
                    NewField114121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114121112.Value = @"Parti, çeşit, miktarı tespit edildi mi?";

                    NewField114221112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 128, 186, 133, false);
                    NewField114221112.Name = "NewField114221112";
                    NewField114221112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114221112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114221112.Value = @"";

                    NewField115121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 133, 170, 138, false);
                    NewField115121112.Name = "NewField115121112";
                    NewField115121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121112.Value = @"Birim ambalaj ağırlığı tespit edildi mi?";

                    NewField115221112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 133, 186, 138, false);
                    NewField115221112.Name = "NewField115221112";
                    NewField115221112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221112.Value = @"";

                    NewField115121122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 123, 170, 128, false);
                    NewField115121122.Name = "NewField115121122";
                    NewField115121122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121122.Value = @"Ambalaj - Etiket - Barkod bilgileri kontrol edildi mi?";

                    NewField115221122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 123, 186, 128, false);
                    NewField115221122.Name = "NewField115221122";
                    NewField115221122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221122.Value = @"";

                    NewField114121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 143, 170, 148, false);
                    NewField114121113.Name = "NewField114121113";
                    NewField114121113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114121113.Value = @"Mal numunesi etiketleri hazırlandı mı?";

                    NewField114221113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 143, 186, 148, false);
                    NewField114221113.Name = "NewField114221113";
                    NewField114221113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114221113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114221113.Value = @"";

                    NewField115121123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 138, 170, 143, false);
                    NewField115121123.Name = "NewField115121123";
                    NewField115121123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121123.Value = @"Mal nunumesi alma yöntemi belirlendi mi?";

                    NewField115221123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 138, 186, 143, false);
                    NewField115221123.Name = "NewField115221123";
                    NewField115221123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221123.Value = @"";

                    NewField1132121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 148, 26, 238, false);
                    NewField1132121.Name = "NewField1132121";
                    NewField1132121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1132121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132121.Value = @"4";

                    NewField11112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 148, 59, 238, false);
                    NewField11112311.Name = "NewField11112311";
                    NewField11112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112311.Value = @"






Muayene esnasında
(Malın cinsine göre)";

                    NewField114121114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 153, 170, 163, false);
                    NewField114121114.Name = "NewField114121114";
                    NewField114121114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114121114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114121114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114121114.Value = @"Mal numuneleri (vatsa yüklenici veya kanuni temsilcisinin huzurunda) malın bütününü temsil edecek şekilde alındı mı?";

                    NewField114221114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 153, 186, 163, false);
                    NewField114221114.Name = "NewField114221114";
                    NewField114221114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114221114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114221114.Value = @"";

                    NewField115121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 163, 170, 168, false);
                    NewField115121113.Name = "NewField115121113";
                    NewField115121113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121113.Value = @"Alınan mal numunesi miktarı, sözleşmesine uygun mu?";

                    NewField115221113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 163, 186, 168, false);
                    NewField115221113.Name = "NewField115221113";
                    NewField115221113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221113.Value = @"";

                    NewField115121124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 148, 170, 153, false);
                    NewField115121124.Name = "NewField115121124";
                    NewField115121124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121124.Value = @"Hava şartları ve aydınlık durumu muayene için uygun mu?";

                    NewField115221124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 148, 186, 153, false);
                    NewField115221124.Name = "NewField115221124";
                    NewField115221124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221124.Value = @"";

                    NewField1111121411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 173, 170, 178, false);
                    NewField1111121411.Name = "NewField1111121411";
                    NewField1111121411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121411.Value = @"Görünüş, renk, tat, koku, kitle ve yapı bakımından muayenesi yapıldı mı?";

                    NewField1111122411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 173, 186, 178, false);
                    NewField1111122411.Name = "NewField1111122411";
                    NewField1111122411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111122411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111122411.Value = @"";

                    NewField1111121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 178, 170, 183, false);
                    NewField1111121511.Name = "NewField1111121511";
                    NewField1111121511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121511.Value = @"Fiziki ölçümleri yapıldı mı?";

                    NewField1111122511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 178, 186, 183, false);
                    NewField1111122511.Name = "NewField1111122511";
                    NewField1111122511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111122511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111122511.Value = @"";

                    NewField1121121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 168, 170, 173, false);
                    NewField1121121511.Name = "NewField1121121511";
                    NewField1121121511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121121511.Value = @"Yöntem ve usuller Teknik Şartname veya TS'ye göre belirlendi mi?";

                    NewField1121122511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 168, 186, 173, false);
                    NewField1121122511.Name = "NewField1121122511";
                    NewField1121122511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121122511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121122511.Value = @"";

                    NewField1211121411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 188, 170, 193, false);
                    NewField1211121411.Name = "NewField1211121411";
                    NewField1211121411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211121411.Value = @"Malın süzme ağırlık oranı TS'ye uygun olarak tespit edildi mi?";

                    NewField1211122411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 188, 186, 193, false);
                    NewField1211122411.Name = "NewField1211122411";
                    NewField1211122411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211122411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211122411.Value = @"";

                    NewField1211121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 193, 170, 198, false);
                    NewField1211121511.Name = "NewField1211121511";
                    NewField1211121511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211121511.Value = @"Yabancı madde, canlı, cansız, parazit ve bunların aksamları görüldü mü?";

                    NewField1211122511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 193, 186, 198, false);
                    NewField1211122511.Name = "NewField1211122511";
                    NewField1211122511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211122511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211122511.Value = @"";

                    NewField1221121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 183, 170, 188, false);
                    NewField1221121511.Name = "NewField1221121511";
                    NewField1221121511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221121511.Value = @"Alım esas numunesi ile mal numunesinin mukayesesi yapıldı mı?";

                    NewField1221122511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 183, 186, 188, false);
                    NewField1221122511.Name = "NewField1221122511";
                    NewField1221122511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221122511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221122511.Value = @"";

                    NewField1311121411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 203, 170, 208, false);
                    NewField1311121411.Name = "NewField1311121411";
                    NewField1311121411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311121411.Value = @"Küçük, büyük ve kritik özürler tespit edildi mi?";

                    NewField1311122411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 203, 186, 208, false);
                    NewField1311122411.Name = "NewField1311122411";
                    NewField1311122411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311122411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311122411.Value = @"";

                    NewField1321121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 198, 170, 203, false);
                    NewField1321121511.Name = "NewField1321121511";
                    NewField1321121511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321121511.Value = @"Pişirme, kaynatma, dinlendirme vs. gibi deneyler yapıldı mı?";

                    NewField1321122511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 198, 186, 203, false);
                    NewField1321122511.Name = "NewField1321122511";
                    NewField1321122511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321122511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321122511.Value = @"";

                    NewField115121114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 208, 170, 213, false);
                    NewField115121114.Name = "NewField115121114";
                    NewField115121114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115121114.Value = @"Fonksiyon testleri yaptırıldı mı?";

                    NewField115221114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 208, 186, 213, false);
                    NewField115221114.Name = "NewField115221114";
                    NewField115221114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115221114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115221114.Value = @"";

                    NewField1111121412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 218, 170, 223, false);
                    NewField1111121412.Name = "NewField1111121412";
                    NewField1111121412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121412.Value = @"Farklı parti seri numaralarından numuneler ayrı ayrı alındı mı?";

                    NewField1111122412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 218, 186, 223, false);
                    NewField1111122412.Name = "NewField1111122412";
                    NewField1111122412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111122412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111122412.Value = @"";

                    NewField1111121512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 223, 170, 228, false);
                    NewField1111121512.Name = "NewField1111121512";
                    NewField1111121512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121512.Value = @"İmal ve son kullanma tarihi sözleşmesine uygun mu?";

                    NewField1111122512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 223, 186, 228, false);
                    NewField1111122512.Name = "NewField1111122512";
                    NewField1111122512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111122512.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111122512.Value = @"";

                    NewField1121121512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 213, 170, 218, false);
                    NewField1121121512.Name = "NewField1121121512";
                    NewField1121121512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121121512.Value = @"Malda bir örneklik (marka ve şekil farklılığı açısından) tespit edildi mi?";

                    NewField1121122512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 213, 186, 218, false);
                    NewField1121122512.Name = "NewField1121122512";
                    NewField1121122512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121122512.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121122512.Value = @"";

                    NewField1211121412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 233, 170, 238, false);
                    NewField1211121412.Name = "NewField1211121412";
                    NewField1211121412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211121412.Value = @"Labaratuar muayeneleri için numuneler ve nitelik çizelgeleri uygun olarak teslim edildi mi?";

                    NewField1211122412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 233, 186, 238, false);
                    NewField1211122412.Name = "NewField1211122412";
                    NewField1211122412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211122412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211122412.Value = @"";

                    NewField1221121512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 228, 170, 233, false);
                    NewField1221121512.Name = "NewField1221121512";
                    NewField1221121512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221121512.Value = @"Mal numunesi talimatlara uygun olarak ve gerektiğinde hijyenik koşullarda hazırlandı mı?";

                    NewField1221122512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 228, 186, 233, false);
                    NewField1221122512.Name = "NewField1221122512";
                    NewField1221122512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221122512.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221122512.Value = @"";

                    NewField121232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 238, 26, 283, false);
                    NewField121232.Name = "NewField121232";
                    NewField121232.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121232.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121232.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121232.Value = @"5";

                    NewField1132112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 238, 59, 283, false);
                    NewField1132112.Name = "NewField1132112";
                    NewField1132112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1132112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132112.Value = @"Muayene Raporları";

                    NewField11112142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 243, 170, 248, false);
                    NewField11112142.Name = "NewField11112142";
                    NewField11112142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112142.Value = @"Ara denetim sonucu uygun mu?";

                    NewField11112242 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 243, 186, 248, false);
                    NewField11112242.Name = "NewField11112242";
                    NewField11112242.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112242.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112242.Value = @"";

                    NewField11112152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 248, 170, 258, false);
                    NewField11112152.Name = "NewField11112152";
                    NewField11112152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112152.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112152.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112152.Value = @"Muayane edilen mala ait alım dosyasında yer alan nitelikler ile tespit edilen nitelikler ayrı ayrı yazıldı mı?";

                    NewField11112252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 248, 186, 258, false);
                    NewField11112252.Name = "NewField11112252";
                    NewField11112252.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112252.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112252.Value = @"";

                    NewField12112152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 238, 170, 243, false);
                    NewField12112152.Name = "NewField12112152";
                    NewField12112152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112152.Value = @"Ara denetim raporu var mı?";

                    NewField12112252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 238, 186, 243, false);
                    NewField12112252.Name = "NewField12112252";
                    NewField12112252.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112252.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112252.Value = @"";

                    NewField124121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 263, 170, 268, false);
                    NewField124121111.Name = "NewField124121111";
                    NewField124121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124121111.Value = @"Giden evrak defterine kayıt edildi mi?";

                    NewField124221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 263, 186, 268, false);
                    NewField124221111.Name = "NewField124221111";
                    NewField124221111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField124221111.Value = @"";

                    NewField125121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 268, 170, 273, false);
                    NewField125121111.Name = "NewField125121111";
                    NewField125121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125121111.Value = @"Kayıt numarası verildi mi?";

                    NewField125221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 268, 186, 273, false);
                    NewField125221111.Name = "NewField125221111";
                    NewField125221111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125221111.Value = @"";

                    NewField125121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 258, 170, 263, false);
                    NewField125121121.Name = "NewField125121121";
                    NewField125121121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125121121.Value = @"Eklenmesi gereken tutanak ve raporlar eksiksiz eklenerek kayda geçirildi mi?";

                    NewField125221121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 258, 186, 263, false);
                    NewField125221121.Name = "NewField125221121";
                    NewField125221121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125221121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125221121.Value = @"";

                    NewField124121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 278, 170, 283, false);
                    NewField124121112.Name = "NewField124121112";
                    NewField124121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124121112.Value = @"Yüklenici veya vekilin Muayene Başlama Tutanağına imzası alındı mı?";

                    NewField124221112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 278, 186, 283, false);
                    NewField124221112.Name = "NewField124221112";
                    NewField124221112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124221112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField124221112.Value = @"";

                    NewField125121122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 273, 170, 278, false);
                    NewField125121122.Name = "NewField125121122";
                    NewField125121122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125121122.Value = @"Yüklenici dâhil imzalar tamamlandı mı?";

                    NewField125221122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 273, 186, 278, false);
                    NewField125221122.Name = "NewField125221122";
                    NewField125221122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125221122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125221122.Value = @"";

                    CONTRACTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 25, 215, 30, false);
                    CONTRACTDATE.Name = "CONTRACTDATE";
                    CONTRACTDATE.Visible = EvetHayirEnum.ehHayir;
                    CONTRACTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTRACTDATE.TextFormat = @"Short Date";
                    CONTRACTDATE.Value = @"{#CONTRACTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    SUPPLIER.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.Suppliername) : "");
                    NewField14.CalcValue = NewField14.Value;
                    NewField122.CalcValue = NewField122.Value;
                    INSPECTIONDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ExaminationStartDate) : "");
                    AMOUNT.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField13211.CalcValue = NewField13211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField111222.CalcValue = NewField111222.Value;
                    NewField111213.CalcValue = NewField111213.Value;
                    NewField111223.CalcValue = NewField111223.Value;
                    NewField111214.CalcValue = NewField111214.Value;
                    NewField111224.CalcValue = NewField111224.Value;
                    NewField111215.CalcValue = NewField111215.Value;
                    NewField111225.CalcValue = NewField111225.Value;
                    NewField13212.CalcValue = NewField13212.Value;
                    NewField111231.CalcValue = NewField111231.Value;
                    NewField1412111.CalcValue = NewField1412111.Value;
                    NewField1422111.CalcValue = NewField1422111.Value;
                    NewField1512111.CalcValue = NewField1512111.Value;
                    NewField1522111.CalcValue = NewField1522111.Value;
                    NewField1512112.CalcValue = NewField1512112.Value;
                    NewField1522112.CalcValue = NewField1522112.Value;
                    NewField121231.CalcValue = NewField121231.Value;
                    NewField1132111.CalcValue = NewField1132111.Value;
                    NewField11112141.CalcValue = NewField11112141.Value;
                    NewField11112241.CalcValue = NewField11112241.Value;
                    NewField11112151.CalcValue = NewField11112151.Value;
                    NewField11112251.CalcValue = NewField11112251.Value;
                    NewField12112151.CalcValue = NewField12112151.Value;
                    NewField12112251.CalcValue = NewField12112251.Value;
                    NewField114121111.CalcValue = NewField114121111.Value;
                    NewField114221111.CalcValue = NewField114221111.Value;
                    NewField115121111.CalcValue = NewField115121111.Value;
                    NewField115221111.CalcValue = NewField115221111.Value;
                    NewField115121121.CalcValue = NewField115121121.Value;
                    NewField115221121.CalcValue = NewField115221121.Value;
                    NewField114121112.CalcValue = NewField114121112.Value;
                    NewField114221112.CalcValue = NewField114221112.Value;
                    NewField115121112.CalcValue = NewField115121112.Value;
                    NewField115221112.CalcValue = NewField115221112.Value;
                    NewField115121122.CalcValue = NewField115121122.Value;
                    NewField115221122.CalcValue = NewField115221122.Value;
                    NewField114121113.CalcValue = NewField114121113.Value;
                    NewField114221113.CalcValue = NewField114221113.Value;
                    NewField115121123.CalcValue = NewField115121123.Value;
                    NewField115221123.CalcValue = NewField115221123.Value;
                    NewField1132121.CalcValue = NewField1132121.Value;
                    NewField11112311.CalcValue = NewField11112311.Value;
                    NewField114121114.CalcValue = NewField114121114.Value;
                    NewField114221114.CalcValue = NewField114221114.Value;
                    NewField115121113.CalcValue = NewField115121113.Value;
                    NewField115221113.CalcValue = NewField115221113.Value;
                    NewField115121124.CalcValue = NewField115121124.Value;
                    NewField115221124.CalcValue = NewField115221124.Value;
                    NewField1111121411.CalcValue = NewField1111121411.Value;
                    NewField1111122411.CalcValue = NewField1111122411.Value;
                    NewField1111121511.CalcValue = NewField1111121511.Value;
                    NewField1111122511.CalcValue = NewField1111122511.Value;
                    NewField1121121511.CalcValue = NewField1121121511.Value;
                    NewField1121122511.CalcValue = NewField1121122511.Value;
                    NewField1211121411.CalcValue = NewField1211121411.Value;
                    NewField1211122411.CalcValue = NewField1211122411.Value;
                    NewField1211121511.CalcValue = NewField1211121511.Value;
                    NewField1211122511.CalcValue = NewField1211122511.Value;
                    NewField1221121511.CalcValue = NewField1221121511.Value;
                    NewField1221122511.CalcValue = NewField1221122511.Value;
                    NewField1311121411.CalcValue = NewField1311121411.Value;
                    NewField1311122411.CalcValue = NewField1311122411.Value;
                    NewField1321121511.CalcValue = NewField1321121511.Value;
                    NewField1321122511.CalcValue = NewField1321122511.Value;
                    NewField115121114.CalcValue = NewField115121114.Value;
                    NewField115221114.CalcValue = NewField115221114.Value;
                    NewField1111121412.CalcValue = NewField1111121412.Value;
                    NewField1111122412.CalcValue = NewField1111122412.Value;
                    NewField1111121512.CalcValue = NewField1111121512.Value;
                    NewField1111122512.CalcValue = NewField1111122512.Value;
                    NewField1121121512.CalcValue = NewField1121121512.Value;
                    NewField1121122512.CalcValue = NewField1121122512.Value;
                    NewField1211121412.CalcValue = NewField1211121412.Value;
                    NewField1211122412.CalcValue = NewField1211122412.Value;
                    NewField1221121512.CalcValue = NewField1221121512.Value;
                    NewField1221122512.CalcValue = NewField1221122512.Value;
                    NewField121232.CalcValue = NewField121232.Value;
                    NewField1132112.CalcValue = NewField1132112.Value;
                    NewField11112142.CalcValue = NewField11112142.Value;
                    NewField11112242.CalcValue = NewField11112242.Value;
                    NewField11112152.CalcValue = NewField11112152.Value;
                    NewField11112252.CalcValue = NewField11112252.Value;
                    NewField12112152.CalcValue = NewField12112152.Value;
                    NewField12112252.CalcValue = NewField12112252.Value;
                    NewField124121111.CalcValue = NewField124121111.Value;
                    NewField124221111.CalcValue = NewField124221111.Value;
                    NewField125121111.CalcValue = NewField125121111.Value;
                    NewField125221111.CalcValue = NewField125221111.Value;
                    NewField125121121.CalcValue = NewField125121121.Value;
                    NewField125221121.CalcValue = NewField125221121.Value;
                    NewField124121112.CalcValue = NewField124121112.Value;
                    NewField124221112.CalcValue = NewField124221112.Value;
                    NewField125121122.CalcValue = NewField125121122.Value;
                    NewField125221122.CalcValue = NewField125221122.Value;
                    CONTRACTDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractDate) : "");
                    CONTRACTDATENO.CalcValue = MyParentReport.MAIN.CONTRACTDATE.FormattedValue + " - " + (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractNo) : "");
                    return new TTReportObject[] { NewField1,NewField2,NewField12,SUPPLIER,NewField14,NewField122,INSPECTIONDATE,AMOUNT,NewField121,NewField1121,NewField1122,NewField1123,NewField11211,NewField12211,NewField13211,NewField111211,NewField111221,NewField111212,NewField111222,NewField111213,NewField111223,NewField111214,NewField111224,NewField111215,NewField111225,NewField13212,NewField111231,NewField1412111,NewField1422111,NewField1512111,NewField1522111,NewField1512112,NewField1522112,NewField121231,NewField1132111,NewField11112141,NewField11112241,NewField11112151,NewField11112251,NewField12112151,NewField12112251,NewField114121111,NewField114221111,NewField115121111,NewField115221111,NewField115121121,NewField115221121,NewField114121112,NewField114221112,NewField115121112,NewField115221112,NewField115121122,NewField115221122,NewField114121113,NewField114221113,NewField115121123,NewField115221123,NewField1132121,NewField11112311,NewField114121114,NewField114221114,NewField115121113,NewField115221113,NewField115121124,NewField115221124,NewField1111121411,NewField1111122411,NewField1111121511,NewField1111122511,NewField1121121511,NewField1121122511,NewField1211121411,NewField1211122411,NewField1211121511,NewField1211122511,NewField1221121511,NewField1221122511,NewField1311121411,NewField1311122411,NewField1321121511,NewField1321122511,NewField115121114,NewField115221114,NewField1111121412,NewField1111122412,NewField1111121512,NewField1111122512,NewField1121121512,NewField1121122512,NewField1211121412,NewField1211122412,NewField1221121512,NewField1221122512,NewField121232,NewField1132112,NewField11112142,NewField11112242,NewField11112152,NewField11112252,NewField12112152,NewField12112252,NewField124121111,NewField124221111,NewField125121111,NewField125221111,NewField125121121,NewField125221121,NewField124121112,NewField124221112,NewField125121122,NewField125221122,CONTRACTDATE,CONTRACTDATENO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MalMuayeneIslemleriKontrolFormu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination pp = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            PurchaseExaminationDetail ped = (PurchaseExaminationDetail)pp.PurchaseExaminationDetails[0];
            //MATERIALNAME.CalcValue = ped.PurchaseOrderDetail.ContractDetail.Material.Name;
            AMOUNT.CalcValue = ped.Amount + " " + ped.PurchaseOrderDetail.ContractDetail.Material.DistributionTypeName + " / " + pp.PurchaseExaminationDetails.Count.ToString() + " KLM";
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

        public MalMuayeneIslemleriKontrolFormu()
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
            Name = "MALMUAYENEISLEMLERIKONTROLFORMU";
            Caption = "Mal Muayene İşlemleri Kontrol Formu";
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 8;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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