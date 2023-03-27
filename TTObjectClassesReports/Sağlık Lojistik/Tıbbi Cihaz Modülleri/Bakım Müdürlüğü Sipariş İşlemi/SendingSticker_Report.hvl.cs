
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
    /// Gönderme Etiketi
    /// </summary>
    public partial class SendingSticker : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public SendingSticker MyParentReport
            {
                get { return (SendingSticker)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportField NewField164 { get {return Body().NewField164;} }
            public TTReportField NewField165 { get {return Body().NewField165;} }
            public TTReportField SENDERUNIT { get {return Body().SENDERUNIT;} }
            public TTReportField OWNERUNIT { get {return Body().OWNERUNIT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField166 { get {return Body().NewField166;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField1361 { get {return Body().NewField1361;} }
            public TTReportField NewField1461 { get {return Body().NewField1461;} }
            public TTReportField NewField1561 { get {return Body().NewField1561;} }
            public TTReportField SENDERUNIT1 { get {return Body().SENDERUNIT1;} }
            public TTReportField OWNERUNIT1 { get {return Body().OWNERUNIT1;} }
            public TTReportField ORDERNO1 { get {return Body().ORDERNO1;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine123 { get {return Body().NewLine123;} }
            public TTReportShape NewLine1122 { get {return Body().NewLine1122;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField NewField142 { get {return Body().NewField142;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField NewField167 { get {return Body().NewField167;} }
            public TTReportField NewField1162 { get {return Body().NewField1162;} }
            public TTReportField NewField1262 { get {return Body().NewField1262;} }
            public TTReportField NewField1362 { get {return Body().NewField1362;} }
            public TTReportField NewField1462 { get {return Body().NewField1462;} }
            public TTReportField NewField1562 { get {return Body().NewField1562;} }
            public TTReportField SENDERUNIT2 { get {return Body().SENDERUNIT2;} }
            public TTReportField OWNERUNIT2 { get {return Body().OWNERUNIT2;} }
            public TTReportField ORDERNO2 { get {return Body().ORDERNO2;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine113 { get {return Body().NewLine113;} }
            public TTReportShape NewLine124 { get {return Body().NewLine124;} }
            public TTReportShape NewLine1123 { get {return Body().NewLine1123;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField133 { get {return Body().NewField133;} }
            public TTReportField NewField143 { get {return Body().NewField143;} }
            public TTReportField NewField153 { get {return Body().NewField153;} }
            public TTReportField NewField168 { get {return Body().NewField168;} }
            public TTReportField NewField1163 { get {return Body().NewField1163;} }
            public TTReportField NewField1263 { get {return Body().NewField1263;} }
            public TTReportField NewField1363 { get {return Body().NewField1363;} }
            public TTReportField NewField1463 { get {return Body().NewField1463;} }
            public TTReportField NewField1563 { get {return Body().NewField1563;} }
            public TTReportField SENDERUNIT3 { get {return Body().SENDERUNIT3;} }
            public TTReportField OWNERUNIT3 { get {return Body().OWNERUNIT3;} }
            public TTReportField ORDERNO3 { get {return Body().ORDERNO3;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
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
                public SendingSticker MyParentReport
                {
                    get { return (SendingSticker)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField162;
                public TTReportField NewField163;
                public TTReportField NewField164;
                public TTReportField NewField165;
                public TTReportField SENDERUNIT;
                public TTReportField OWNERUNIT;
                public TTReportField ORDERNO;
                public TTReportShape NewLine13;
                public TTReportShape NewLine111;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1121;
                public TTReportField NewField17;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField166;
                public TTReportField NewField1161;
                public TTReportField NewField1261;
                public TTReportField NewField1361;
                public TTReportField NewField1461;
                public TTReportField NewField1561;
                public TTReportField SENDERUNIT1;
                public TTReportField OWNERUNIT1;
                public TTReportField ORDERNO1;
                public TTReportShape NewLine14;
                public TTReportShape NewLine112;
                public TTReportShape NewLine123;
                public TTReportShape NewLine1122;
                public TTReportField NewField18;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField NewField167;
                public TTReportField NewField1162;
                public TTReportField NewField1262;
                public TTReportField NewField1362;
                public TTReportField NewField1462;
                public TTReportField NewField1562;
                public TTReportField SENDERUNIT2;
                public TTReportField OWNERUNIT2;
                public TTReportField ORDERNO2;
                public TTReportShape NewLine15;
                public TTReportShape NewLine113;
                public TTReportShape NewLine124;
                public TTReportShape NewLine1123;
                public TTReportField NewField19;
                public TTReportField NewField113;
                public TTReportField NewField123;
                public TTReportField NewField133;
                public TTReportField NewField143;
                public TTReportField NewField153;
                public TTReportField NewField168;
                public TTReportField NewField1163;
                public TTReportField NewField1263;
                public TTReportField NewField1363;
                public TTReportField NewField1463;
                public TTReportField NewField1563;
                public TTReportField SENDERUNIT3;
                public TTReportField OWNERUNIT3;
                public TTReportField ORDERNO3;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField25; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 222;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 15, 146, 15, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 3;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 100, 146, 100, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 3;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 15, 18, 100, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 3;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 146, 15, 146, 100, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 3;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 20, 67, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GÖNDEREN BİRLİK";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 41, 67, 46, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ALICI BİRLİK";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 62, 67, 67, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"SİPARİŞ NUMARASI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 71, 67, 76, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"EBADI";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 79, 67, 84, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"AĞIRLIK";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 87, 67, 92, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"MALZEME ÖNCELİK KODU";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 87, 68, 92, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 79, 68, 84, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 71, 68, 76, false);
                    NewField162.Name = "NewField162";
                    NewField162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.TextFont.Name = "Arial";
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @":";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 62, 68, 67, false);
                    NewField163.Name = "NewField163";
                    NewField163.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField163.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField163.TextFont.Name = "Arial";
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @":";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 41, 68, 46, false);
                    NewField164.Name = "NewField164";
                    NewField164.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField164.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField164.TextFont.Name = "Arial";
                    NewField164.TextFont.Bold = true;
                    NewField164.TextFont.CharSet = 162;
                    NewField164.Value = @":";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 20, 68, 25, false);
                    NewField165.Name = "NewField165";
                    NewField165.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField165.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField165.TextFont.Name = "Arial";
                    NewField165.TextFont.Bold = true;
                    NewField165.TextFont.CharSet = 162;
                    NewField165.Value = @":";

                    SENDERUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 20, 145, 40, false);
                    SENDERUNIT.Name = "SENDERUNIT";
                    SENDERUNIT.FieldType = ReportFieldTypeEnum.ftExpression;
                    SENDERUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERUNIT.TextFont.Name = "Arial";
                    SENDERUNIT.TextFont.CharSet = 162;
                    SENDERUNIT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    OWNERUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 41, 145, 59, false);
                    OWNERUNIT.Name = "OWNERUNIT";
                    OWNERUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OWNERUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    OWNERUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    OWNERUNIT.TextFont.Name = "Arial";
                    OWNERUNIT.TextFont.CharSet = 162;
                    OWNERUNIT.Value = @"{#OWNERMILITARYUNIT#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 62, 100, 67, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 103, 146, 103, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 3;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 188, 146, 188, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 3;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 103, 18, 188, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.DrawWidth = 3;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 146, 103, 146, 188, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.DrawWidth = 3;

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 108, 67, 113, false);
                    NewField17.Name = "NewField17";
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"GÖNDEREN BİRLİK";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 129, 67, 134, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ALICI BİRLİK";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 150, 67, 155, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"SİPARİŞ NUMARASI";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 159, 67, 164, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"EBADI";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 167, 67, 172, false);
                    NewField141.Name = "NewField141";
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"AĞIRLIK";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 175, 67, 180, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"MALZEME ÖNCELİK KODU";

                    NewField166 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 175, 68, 180, false);
                    NewField166.Name = "NewField166";
                    NewField166.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField166.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField166.TextFont.Name = "Arial";
                    NewField166.TextFont.Bold = true;
                    NewField166.TextFont.CharSet = 162;
                    NewField166.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 167, 68, 172, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 159, 68, 164, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Name = "Arial";
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @":";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 150, 68, 155, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.TextFont.Name = "Arial";
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @":";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 129, 68, 134, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1461.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1461.TextFont.Name = "Arial";
                    NewField1461.TextFont.Bold = true;
                    NewField1461.TextFont.CharSet = 162;
                    NewField1461.Value = @":";

                    NewField1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 108, 68, 113, false);
                    NewField1561.Name = "NewField1561";
                    NewField1561.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1561.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1561.TextFont.Name = "Arial";
                    NewField1561.TextFont.Bold = true;
                    NewField1561.TextFont.CharSet = 162;
                    NewField1561.Value = @":";

                    SENDERUNIT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 108, 145, 128, false);
                    SENDERUNIT1.Name = "SENDERUNIT1";
                    SENDERUNIT1.FieldType = ReportFieldTypeEnum.ftExpression;
                    SENDERUNIT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERUNIT1.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERUNIT1.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERUNIT1.TextFont.Name = "Arial";
                    SENDERUNIT1.TextFont.CharSet = 162;
                    SENDERUNIT1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    OWNERUNIT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 129, 145, 147, false);
                    OWNERUNIT1.Name = "OWNERUNIT1";
                    OWNERUNIT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERUNIT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OWNERUNIT1.MultiLine = EvetHayirEnum.ehEvet;
                    OWNERUNIT1.WordBreak = EvetHayirEnum.ehEvet;
                    OWNERUNIT1.TextFont.Name = "Arial";
                    OWNERUNIT1.TextFont.CharSet = 162;
                    OWNERUNIT1.Value = @"{#OWNERMILITARYUNIT#}";

                    ORDERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 150, 100, 155, false);
                    ORDERNO1.Name = "ORDERNO1";
                    ORDERNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO1.TextFont.Name = "Arial";
                    ORDERNO1.TextFont.CharSet = 162;
                    ORDERNO1.Value = @"{#ORDERNO#}";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 15, 279, 15, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 3;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 100, 279, 100, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.DrawWidth = 3;

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 15, 151, 100, false);
                    NewLine123.Name = "NewLine123";
                    NewLine123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123.DrawWidth = 3;

                    NewLine1122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 279, 15, 279, 100, false);
                    NewLine1122.Name = "NewLine1122";
                    NewLine1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1122.DrawWidth = 3;

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 20, 200, 25, false);
                    NewField18.Name = "NewField18";
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"GÖNDEREN BİRLİK";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 41, 200, 46, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"ALICI BİRLİK";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 62, 200, 67, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"SİPARİŞ NUMARASI";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 71, 200, 76, false);
                    NewField132.Name = "NewField132";
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"EBADI";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 79, 200, 84, false);
                    NewField142.Name = "NewField142";
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Name = "Arial";
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"AĞIRLIK";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 87, 200, 92, false);
                    NewField152.Name = "NewField152";
                    NewField152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152.TextFont.Name = "Arial";
                    NewField152.TextFont.Bold = true;
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @"MALZEME ÖNCELİK KODU";

                    NewField167 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 87, 201, 92, false);
                    NewField167.Name = "NewField167";
                    NewField167.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField167.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField167.TextFont.Name = "Arial";
                    NewField167.TextFont.Bold = true;
                    NewField167.TextFont.CharSet = 162;
                    NewField167.Value = @":";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 79, 201, 84, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1162.TextFont.Name = "Arial";
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @":";

                    NewField1262 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 71, 201, 76, false);
                    NewField1262.Name = "NewField1262";
                    NewField1262.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1262.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1262.TextFont.Name = "Arial";
                    NewField1262.TextFont.Bold = true;
                    NewField1262.TextFont.CharSet = 162;
                    NewField1262.Value = @":";

                    NewField1362 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 62, 201, 67, false);
                    NewField1362.Name = "NewField1362";
                    NewField1362.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1362.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1362.TextFont.Name = "Arial";
                    NewField1362.TextFont.Bold = true;
                    NewField1362.TextFont.CharSet = 162;
                    NewField1362.Value = @":";

                    NewField1462 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 41, 201, 46, false);
                    NewField1462.Name = "NewField1462";
                    NewField1462.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1462.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1462.TextFont.Name = "Arial";
                    NewField1462.TextFont.Bold = true;
                    NewField1462.TextFont.CharSet = 162;
                    NewField1462.Value = @":";

                    NewField1562 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 20, 201, 25, false);
                    NewField1562.Name = "NewField1562";
                    NewField1562.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1562.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1562.TextFont.Name = "Arial";
                    NewField1562.TextFont.Bold = true;
                    NewField1562.TextFont.CharSet = 162;
                    NewField1562.Value = @":";

                    SENDERUNIT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 20, 278, 40, false);
                    SENDERUNIT2.Name = "SENDERUNIT2";
                    SENDERUNIT2.FieldType = ReportFieldTypeEnum.ftExpression;
                    SENDERUNIT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERUNIT2.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERUNIT2.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERUNIT2.TextFont.Name = "Arial";
                    SENDERUNIT2.TextFont.CharSet = 162;
                    SENDERUNIT2.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    OWNERUNIT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 41, 278, 59, false);
                    OWNERUNIT2.Name = "OWNERUNIT2";
                    OWNERUNIT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERUNIT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OWNERUNIT2.MultiLine = EvetHayirEnum.ehEvet;
                    OWNERUNIT2.WordBreak = EvetHayirEnum.ehEvet;
                    OWNERUNIT2.TextFont.Name = "Arial";
                    OWNERUNIT2.TextFont.CharSet = 162;
                    OWNERUNIT2.Value = @"{#OWNERMILITARYUNIT#}";

                    ORDERNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 62, 233, 67, false);
                    ORDERNO2.Name = "ORDERNO2";
                    ORDERNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO2.TextFont.Name = "Arial";
                    ORDERNO2.TextFont.CharSet = 162;
                    ORDERNO2.Value = @"{#ORDERNO#}";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 103, 279, 103, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.DrawWidth = 3;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 188, 279, 188, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.DrawWidth = 3;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 103, 151, 188, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine124.DrawWidth = 3;

                    NewLine1123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 279, 103, 279, 188, false);
                    NewLine1123.Name = "NewLine1123";
                    NewLine1123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1123.DrawWidth = 3;

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 108, 200, 113, false);
                    NewField19.Name = "NewField19";
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"GÖNDEREN BİRLİK";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 129, 200, 134, false);
                    NewField113.Name = "NewField113";
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Name = "Arial";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"ALICI BİRLİK";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 150, 200, 155, false);
                    NewField123.Name = "NewField123";
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Name = "Arial";
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"SİPARİŞ NUMARASI";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 159, 200, 164, false);
                    NewField133.Name = "NewField133";
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"EBADI";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 167, 200, 172, false);
                    NewField143.Name = "NewField143";
                    NewField143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField143.TextFont.Name = "Arial";
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"AĞIRLIK";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 175, 200, 180, false);
                    NewField153.Name = "NewField153";
                    NewField153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField153.TextFont.Name = "Arial";
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @"MALZEME ÖNCELİK KODU";

                    NewField168 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 175, 201, 180, false);
                    NewField168.Name = "NewField168";
                    NewField168.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField168.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField168.TextFont.Name = "Arial";
                    NewField168.TextFont.Bold = true;
                    NewField168.TextFont.CharSet = 162;
                    NewField168.Value = @":";

                    NewField1163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 167, 201, 172, false);
                    NewField1163.Name = "NewField1163";
                    NewField1163.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1163.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1163.TextFont.Name = "Arial";
                    NewField1163.TextFont.Bold = true;
                    NewField1163.TextFont.CharSet = 162;
                    NewField1163.Value = @":";

                    NewField1263 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 159, 201, 164, false);
                    NewField1263.Name = "NewField1263";
                    NewField1263.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1263.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1263.TextFont.Name = "Arial";
                    NewField1263.TextFont.Bold = true;
                    NewField1263.TextFont.CharSet = 162;
                    NewField1263.Value = @":";

                    NewField1363 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 150, 201, 155, false);
                    NewField1363.Name = "NewField1363";
                    NewField1363.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1363.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1363.TextFont.Name = "Arial";
                    NewField1363.TextFont.Bold = true;
                    NewField1363.TextFont.CharSet = 162;
                    NewField1363.Value = @":";

                    NewField1463 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 129, 201, 134, false);
                    NewField1463.Name = "NewField1463";
                    NewField1463.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1463.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1463.TextFont.Name = "Arial";
                    NewField1463.TextFont.Bold = true;
                    NewField1463.TextFont.CharSet = 162;
                    NewField1463.Value = @":";

                    NewField1563 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 108, 201, 113, false);
                    NewField1563.Name = "NewField1563";
                    NewField1563.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1563.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1563.TextFont.Name = "Arial";
                    NewField1563.TextFont.Bold = true;
                    NewField1563.TextFont.CharSet = 162;
                    NewField1563.Value = @":";

                    SENDERUNIT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 108, 278, 128, false);
                    SENDERUNIT3.Name = "SENDERUNIT3";
                    SENDERUNIT3.FieldType = ReportFieldTypeEnum.ftExpression;
                    SENDERUNIT3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERUNIT3.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERUNIT3.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERUNIT3.TextFont.Name = "Arial";
                    SENDERUNIT3.TextFont.CharSet = 162;
                    SENDERUNIT3.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    OWNERUNIT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 129, 278, 147, false);
                    OWNERUNIT3.Name = "OWNERUNIT3";
                    OWNERUNIT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERUNIT3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OWNERUNIT3.MultiLine = EvetHayirEnum.ehEvet;
                    OWNERUNIT3.WordBreak = EvetHayirEnum.ehEvet;
                    OWNERUNIT3.TextFont.Name = "Arial";
                    OWNERUNIT3.TextFont.CharSet = 162;
                    OWNERUNIT3.Value = @"{#OWNERMILITARYUNIT#}";

                    ORDERNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 150, 233, 155, false);
                    ORDERNO3.Name = "ORDERNO3";
                    ORDERNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO3.TextFont.Name = "Arial";
                    ORDERNO3.TextFont.CharSet = 162;
                    ORDERNO3.Value = @"{#ORDERNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 62, 145, 67, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"{#REQUESTNO#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 62, 105, 67, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.Value = @"-";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 62, 278, 67, false);
                    NewField20.Name = "NewField20";
                    NewField20.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"{#REQUESTNO#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 62, 238, 67, false);
                    NewField21.Name = "NewField21";
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.Value = @"-";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 150, 278, 155, false);
                    NewField22.Name = "NewField22";
                    NewField22.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField22.TextFont.Name = "Arial";
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @"{#REQUESTNO#}";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 150, 238, 155, false);
                    NewField23.Name = "NewField23";
                    NewField23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23.Value = @"-";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 150, 145, 155, false);
                    NewField24.Name = "NewField24";
                    NewField24.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField24.TextFont.Name = "Arial";
                    NewField24.TextFont.CharSet = 162;
                    NewField24.Value = @"{#REQUESTNO#}";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 150, 105, 155, false);
                    NewField25.Name = "NewField25";
                    NewField25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField25.Value = @"-";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField165.CalcValue = NewField165.Value;
                    OWNERUNIT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    ORDERNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    NewField17.CalcValue = NewField17.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField166.CalcValue = NewField166.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField1561.CalcValue = NewField1561.Value;
                    OWNERUNIT1.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    ORDERNO1.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    NewField18.CalcValue = NewField18.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField167.CalcValue = NewField167.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField1262.CalcValue = NewField1262.Value;
                    NewField1362.CalcValue = NewField1362.Value;
                    NewField1462.CalcValue = NewField1462.Value;
                    NewField1562.CalcValue = NewField1562.Value;
                    OWNERUNIT2.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    ORDERNO2.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    NewField19.CalcValue = NewField19.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField168.CalcValue = NewField168.Value;
                    NewField1163.CalcValue = NewField1163.Value;
                    NewField1263.CalcValue = NewField1263.Value;
                    NewField1363.CalcValue = NewField1363.Value;
                    NewField1463.CalcValue = NewField1463.Value;
                    NewField1563.CalcValue = NewField1563.Value;
                    OWNERUNIT3.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    ORDERNO3.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    NewField2.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField20.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "");
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "");
                    NewField25.CalcValue = NewField25.Value;
                    SENDERUNIT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    SENDERUNIT1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    SENDERUNIT2.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    SENDERUNIT3.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,NewField161,NewField162,NewField163,NewField164,NewField165,OWNERUNIT,ORDERNO,NewField17,NewField111,NewField121,NewField131,NewField141,NewField151,NewField166,NewField1161,NewField1261,NewField1361,NewField1461,NewField1561,OWNERUNIT1,ORDERNO1,NewField18,NewField112,NewField122,NewField132,NewField142,NewField152,NewField167,NewField1162,NewField1262,NewField1362,NewField1462,NewField1562,OWNERUNIT2,ORDERNO2,NewField19,NewField113,NewField123,NewField133,NewField143,NewField153,NewField168,NewField1163,NewField1263,NewField1363,NewField1463,NewField1563,OWNERUNIT3,ORDERNO3,NewField2,NewField3,NewField20,NewField21,NewField22,NewField23,NewField24,NewField25,SENDERUNIT,SENDERUNIT1,SENDERUNIT2,SENDERUNIT3};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SendingSticker()
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
            Name = "SENDINGSTICKER";
            Caption = "Gönderme Etiketi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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