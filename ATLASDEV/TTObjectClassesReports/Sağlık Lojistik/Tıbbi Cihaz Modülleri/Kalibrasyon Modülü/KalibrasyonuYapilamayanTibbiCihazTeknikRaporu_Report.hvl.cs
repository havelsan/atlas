
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
    /// Kalibrasyonu Yapılamayan Tıbbi Cihaz Teknik Raporu
    /// </summary>
    public partial class KalibrasyonuYapilamayanTibbiCihazTeknikRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public KalibrasyonuYapilamayanTibbiCihazTeknikRaporu MyParentReport
            {
                get { return (KalibrasyonuYapilamayanTibbiCihazTeknikRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NOTCALIBREREASONDESC { get {return Body().NOTCALIBREREASONDESC;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField REPORTNAME { get {return Body().REPORTNAME;} }
            public TTReportField REPORTNAME1 { get {return Body().REPORTNAME1;} }
            public TTReportField REPORTNAME11 { get {return Body().REPORTNAME11;} }
            public TTReportField REPORTNAME111 { get {return Body().REPORTNAME111;} }
            public TTReportField REPORTNAME112 { get {return Body().REPORTNAME112;} }
            public TTReportField REPORTNAME113 { get {return Body().REPORTNAME113;} }
            public TTReportField REPORTNAME1311 { get {return Body().REPORTNAME1311;} }
            public TTReportField REPORTNAME1312 { get {return Body().REPORTNAME1312;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField TONO { get {return Body().TONO;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NOTCALIBREREASON1 { get {return Body().NOTCALIBREREASON1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NOTCALIBREREASON2 { get {return Body().NOTCALIBREREASON2;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NOTCALIBREREASON3 { get {return Body().NOTCALIBREREASON3;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NOTCALIBREREASON4 { get {return Body().NOTCALIBREREASON4;} }
            public TTReportField NewField1122 { get {return Body().NewField1122;} }
            public TTReportField NOTCALIBREREASON5 { get {return Body().NOTCALIBREREASON5;} }
            public TTReportField NewField1123 { get {return Body().NewField1123;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField TITLE { get {return Body().TITLE;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
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
                list[0] = new TTReportNqlData<Calibration.GetNotCalibratedReportQuery_Class>("GetNotCalibratedReportQuery", Calibration.GetNotCalibratedReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KalibrasyonuYapilamayanTibbiCihazTeknikRaporu MyParentReport
                {
                    get { return (KalibrasyonuYapilamayanTibbiCihazTeknikRaporu)ParentReport; }
                }
                
                public TTReportField NOTCALIBREREASONDESC;
                public TTReportField NewField3;
                public TTReportField REPORTNAME;
                public TTReportField REPORTNAME1;
                public TTReportField REPORTNAME11;
                public TTReportField REPORTNAME111;
                public TTReportField REPORTNAME112;
                public TTReportField REPORTNAME113;
                public TTReportField REPORTNAME1311;
                public TTReportField REPORTNAME1312;
                public TTReportField MATERIALNAME;
                public TTReportField SERIALNO;
                public TTReportField NATOSTOCKNO;
                public TTReportField MODEL;
                public TTReportField TONO;
                public TTReportField REPORTDATE;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NOTCALIBREREASON1;
                public TTReportField NewField12;
                public TTReportField NOTCALIBREREASON2;
                public TTReportField NewField121;
                public TTReportField NOTCALIBREREASON3;
                public TTReportField NewField1121;
                public TTReportField NOTCALIBREREASON4;
                public TTReportField NewField1122;
                public TTReportField NOTCALIBREREASON5;
                public TTReportField NewField1123;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField4;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NAMESURNAME;
                public TTReportField TITLE;
                public TTReportField NewField17;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField1161;
                public TTReportField MILITARYUNIT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NOTCALIBREREASONDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 158, 194, 248, false);
                    NOTCALIBREREASONDESC.Name = "NOTCALIBREREASONDESC";
                    NOTCALIBREREASONDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTCALIBREREASONDESC.MultiLine = EvetHayirEnum.ehEvet;
                    NOTCALIBREREASONDESC.WordBreak = EvetHayirEnum.ehEvet;
                    NOTCALIBREREASONDESC.TextFont.Name = "Arial";
                    NOTCALIBREREASONDESC.TextFont.CharSet = 162;
                    NOTCALIBREREASONDESC.Value = @"       {#NOTCALIBREREASONDESC#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 150, 195, 158, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @" AÇIKLAMA VE ÖNERİLER:";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 20, 195, 31, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"KALİBRASYONU YAPILAMAYAN TIBBİ CİHAZ
TEKNİK RAPORU";

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 35, 195, 43, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 12;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"TIBBİ CİHAZIN";

                    REPORTNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 43, 47, 51, false);
                    REPORTNAME11.Name = "REPORTNAME11";
                    REPORTNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11.TextFont.Name = "Arial";
                    REPORTNAME11.TextFont.Size = 11;
                    REPORTNAME11.TextFont.Bold = true;
                    REPORTNAME11.TextFont.CharSet = 162;
                    REPORTNAME11.Value = @" ADI";

                    REPORTNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 51, 47, 59, false);
                    REPORTNAME111.Name = "REPORTNAME111";
                    REPORTNAME111.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME111.TextFont.Name = "Arial";
                    REPORTNAME111.TextFont.Size = 11;
                    REPORTNAME111.TextFont.Bold = true;
                    REPORTNAME111.TextFont.CharSet = 162;
                    REPORTNAME111.Value = @" SERİ NU.";

                    REPORTNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 59, 47, 67, false);
                    REPORTNAME112.Name = "REPORTNAME112";
                    REPORTNAME112.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME112.TextFont.Name = "Arial";
                    REPORTNAME112.TextFont.Size = 11;
                    REPORTNAME112.TextFont.Bold = true;
                    REPORTNAME112.TextFont.CharSet = 162;
                    REPORTNAME112.Value = @" STOK NU.";

                    REPORTNAME113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 43, 145, 51, false);
                    REPORTNAME113.Name = "REPORTNAME113";
                    REPORTNAME113.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME113.TextFont.Name = "Arial";
                    REPORTNAME113.TextFont.Size = 11;
                    REPORTNAME113.TextFont.Bold = true;
                    REPORTNAME113.TextFont.CharSet = 162;
                    REPORTNAME113.Value = @" MODEL/PARÇA NU.";

                    REPORTNAME1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 51, 145, 59, false);
                    REPORTNAME1311.Name = "REPORTNAME1311";
                    REPORTNAME1311.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1311.TextFont.Name = "Arial";
                    REPORTNAME1311.TextFont.Size = 11;
                    REPORTNAME1311.TextFont.Bold = true;
                    REPORTNAME1311.TextFont.CharSet = 162;
                    REPORTNAME1311.Value = @" T.O. NU.";

                    REPORTNAME1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 59, 145, 67, false);
                    REPORTNAME1312.Name = "REPORTNAME1312";
                    REPORTNAME1312.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1312.TextFont.Name = "Arial";
                    REPORTNAME1312.TextFont.Size = 11;
                    REPORTNAME1312.TextFont.Bold = true;
                    REPORTNAME1312.TextFont.CharSet = 162;
                    REPORTNAME1312.Value = @" RAPOR TARİHİ";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 43, 105, 51, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 11;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @" {#MATERIALNAME#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 51, 105, 59, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.TextFont.Name = "Arial";
                    SERIALNO.TextFont.Size = 11;
                    SERIALNO.TextFont.CharSet = 162;
                    SERIALNO.Value = @" {#SERIALNUMBER#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 59, 105, 67, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.Size = 11;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @" {#NATOSTOCKNO#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 43, 195, 51, false);
                    MODEL.Name = "MODEL";
                    MODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MODEL.TextFont.Name = "Arial";
                    MODEL.TextFont.Size = 11;
                    MODEL.TextFont.CharSet = 162;
                    MODEL.Value = @" {#MODEL#}";

                    TONO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 51, 195, 59, false);
                    TONO.Name = "TONO";
                    TONO.DrawStyle = DrawStyleConstants.vbSolid;
                    TONO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TONO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TONO.TextFont.Name = "Arial";
                    TONO.TextFont.Size = 11;
                    TONO.TextFont.CharSet = 162;
                    TONO.Value = @"";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 59, 195, 67, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTDATE.TextFont.Name = "Arial";
                    REPORTDATE.TextFont.Size = 11;
                    REPORTDATE.TextFont.CharSet = 162;
                    REPORTDATE.Value = @" {@printdate@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 67, 195, 150, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"
 AİT OLDUĞU BİRLİK :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 78, 194, 88, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"       Yukarıda tanıtıcı bilgileri verilen tıbbi cihaza aşağıda belirtilen sebeplerden dolayı bir işlem yapılamamıştır:";

                    NOTCALIBREREASON1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 95, 31, 100, false);
                    NOTCALIBREREASON1.Name = "NOTCALIBREREASON1";
                    NOTCALIBREREASON1.DrawStyle = DrawStyleConstants.vbSolid;
                    NOTCALIBREREASON1.FieldType = ReportFieldTypeEnum.ftExpression;
                    NOTCALIBREREASON1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NOTCALIBREREASON1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOTCALIBREREASON1.TextFont.Name = "Arial";
                    NOTCALIBREREASON1.TextFont.CharSet = 162;
                    NOTCALIBREREASON1.Value = @"{#NOTCALIBREREASON1#} == ""True"" ? "" X"" : """"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 95, 194, 105, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"       Kalibrasyon laboratuvarında tıbbi cihazın kalibrasyonu için gerekli standart, kalibratör, aksesuar yoktur.";

                    NOTCALIBREREASON2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 110, 31, 115, false);
                    NOTCALIBREREASON2.Name = "NOTCALIBREREASON2";
                    NOTCALIBREREASON2.DrawStyle = DrawStyleConstants.vbSolid;
                    NOTCALIBREREASON2.FieldType = ReportFieldTypeEnum.ftExpression;
                    NOTCALIBREREASON2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NOTCALIBREREASON2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOTCALIBREREASON2.TextFont.Name = "Arial";
                    NOTCALIBREREASON2.TextFont.CharSet = 162;
                    NOTCALIBREREASON2.Value = @"{#NOTCALIBREREASON2#} == ""True"" ? "" X"" : """"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 110, 194, 115, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"       Kalibrasyon için gerekli teknik emri ve teknik dökümanı yoktur.";

                    NOTCALIBREREASON3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 120, 31, 125, false);
                    NOTCALIBREREASON3.Name = "NOTCALIBREREASON3";
                    NOTCALIBREREASON3.DrawStyle = DrawStyleConstants.vbSolid;
                    NOTCALIBREREASON3.FieldType = ReportFieldTypeEnum.ftExpression;
                    NOTCALIBREREASON3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NOTCALIBREREASON3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOTCALIBREREASON3.TextFont.Name = "Arial";
                    NOTCALIBREREASON3.TextFont.CharSet = 162;
                    NOTCALIBREREASON3.Value = @"{#NOTCALIBREREASON3#} == ""True"" ? "" X"" : """"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 120, 194, 125, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"       Kalibrasyon için gerekli laboratuvar çevresel şartları uygun değil veya yoktur.";

                    NOTCALIBREREASON4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 130, 31, 135, false);
                    NOTCALIBREREASON4.Name = "NOTCALIBREREASON4";
                    NOTCALIBREREASON4.DrawStyle = DrawStyleConstants.vbSolid;
                    NOTCALIBREREASON4.FieldType = ReportFieldTypeEnum.ftExpression;
                    NOTCALIBREREASON4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NOTCALIBREREASON4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOTCALIBREREASON4.TextFont.Name = "Arial";
                    NOTCALIBREREASON4.TextFont.CharSet = 162;
                    NOTCALIBREREASON4.Value = @"{#NOTCALIBREREASON1#} == ""True"" ? "" X"" : """"";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 130, 194, 135, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"       Tıbbi cihazın kalibrasyonu için yeterli bilgiye sahip personel yoktur.";

                    NOTCALIBREREASON5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 140, 31, 145, false);
                    NOTCALIBREREASON5.Name = "NOTCALIBREREASON5";
                    NOTCALIBREREASON5.DrawStyle = DrawStyleConstants.vbSolid;
                    NOTCALIBREREASON5.FieldType = ReportFieldTypeEnum.ftExpression;
                    NOTCALIBREREASON5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NOTCALIBREREASON5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOTCALIBREREASON5.TextFont.Name = "Arial";
                    NOTCALIBREREASON5.TextFont.CharSet = 162;
                    NOTCALIBREREASON5.Value = @"{#NOTCALIBREREASON5#} == ""True"" ? "" X"" : """"";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 140, 194, 145, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123.TextFont.Name = "Arial";
                    NewField1123.TextFont.CharSet = 162;
                    NewField1123.Value = @"       Diğer sebepler";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 150, 25, 248, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 150, 195, 248, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 248, 81, 282, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"KALİBRASYON TEKNİSYENİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 248, 138, 282, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"KALİTE KONTROL ELEMANI";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 248, 195, 282, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"LABORATUVAR AMİRİ";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 255, 80, 260, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 260, 80, 265, false);
                    TITLE.Name = "TITLE";
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TITLE.TextFont.Name = "Arial";
                    TITLE.TextFont.CharSet = 162;
                    TITLE.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 255, 137, 260, false);
                    NewField17.Name = "NewField17";
                    NewField17.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 260, 137, 265, false);
                    NewField161.Name = "NewField161";
                    NewField161.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 255, 194, 260, false);
                    NewField171.Name = "NewField171";
                    NewField171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 260, 194, 265, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 72, 194, 77, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 11;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{#MILITARYUNIT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.GetNotCalibratedReportQuery_Class dataset_GetNotCalibratedReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Calibration.GetNotCalibratedReportQuery_Class>(0);
                    NOTCALIBREREASONDESC.CalcValue = @"       " + (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NotCalibreReasonDesc) : "");
                    NewField3.CalcValue = NewField3.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    REPORTNAME11.CalcValue = REPORTNAME11.Value;
                    REPORTNAME111.CalcValue = REPORTNAME111.Value;
                    REPORTNAME112.CalcValue = REPORTNAME112.Value;
                    REPORTNAME113.CalcValue = REPORTNAME113.Value;
                    REPORTNAME1311.CalcValue = REPORTNAME1311.Value;
                    REPORTNAME1312.CalcValue = REPORTNAME1312.Value;
                    MATERIALNAME.CalcValue = @" " + (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.Materialname) : "");
                    SERIALNO.CalcValue = @" " + (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.SerialNumber) : "");
                    NATOSTOCKNO.CalcValue = @" " + (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NATOStockNO) : "");
                    MODEL.CalcValue = @" " + (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.Model) : "");
                    TONO.CalcValue = @"";
                    REPORTDATE.CalcValue = @" " + DateTime.Now.ToShortDateString();
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NAMESURNAME.CalcValue = @"";
                    TITLE.CalcValue = @"";
                    NewField17.CalcValue = @"";
                    NewField161.CalcValue = @"";
                    NewField171.CalcValue = @"";
                    NewField1161.CalcValue = @"";
                    MILITARYUNIT.CalcValue = (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.Militaryunit) : "");
                    NOTCALIBREREASON1.CalcValue = (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NotCalibreReason1) : "") == "True" ? " X" : "";
                    NOTCALIBREREASON2.CalcValue = (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NotCalibreReason2) : "") == "True" ? " X" : "";
                    NOTCALIBREREASON3.CalcValue = (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NotCalibreReason3) : "") == "True" ? " X" : "";
                    NOTCALIBREREASON4.CalcValue = (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NotCalibreReason1) : "") == "True" ? " X" : "";
                    NOTCALIBREREASON5.CalcValue = (dataset_GetNotCalibratedReportQuery != null ? Globals.ToStringCore(dataset_GetNotCalibratedReportQuery.NotCalibreReason5) : "") == "True" ? " X" : "";
                    return new TTReportObject[] { NOTCALIBREREASONDESC,NewField3,REPORTNAME,REPORTNAME1,REPORTNAME11,REPORTNAME111,REPORTNAME112,REPORTNAME113,REPORTNAME1311,REPORTNAME1312,MATERIALNAME,SERIALNO,NATOSTOCKNO,MODEL,TONO,REPORTDATE,NewField1,NewField2,NewField12,NewField121,NewField1121,NewField1122,NewField1123,NewField4,NewField14,NewField15,NAMESURNAME,TITLE,NewField17,NewField161,NewField171,NewField1161,MILITARYUNIT,NOTCALIBREREASON1,NOTCALIBREREASON2,NOTCALIBREREASON3,NOTCALIBREREASON4,NOTCALIBREREASON5};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string objectID = ((KalibrasyonuYapilamayanTibbiCihazTeknikRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    TTObjectContext ctx = new TTObjectContext(true);
                    Calibration calibration = (Calibration)ctx.GetObject(new Guid(objectID), typeof(Calibration));
                    ResUser user = (ResUser)calibration.GetState("Calibration", true).User.UserObject;
                    NAMESURNAME.CalcValue = user.Name.ToString();
                    TITLE.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
//                    string userID = calibration.GetState("Calibration", true).UserID.ToString();
//                    ResUser user = (ResUser)ctx.GetObject(new Guid(userID), typeof(ResUser));
//                    NAMESURNAME.CalcValue = user.Name.ToString();
//                    TITLE.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
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

        public KalibrasyonuYapilamayanTibbiCihazTeknikRaporu()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KALIBRASYONUYAPILAMAYANTIBBICIHAZTEKNIKRAPORU";
            Caption = "Kalibrasyonu Yapılamayan Tıbbi Cihaz Teknik Raporu";
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