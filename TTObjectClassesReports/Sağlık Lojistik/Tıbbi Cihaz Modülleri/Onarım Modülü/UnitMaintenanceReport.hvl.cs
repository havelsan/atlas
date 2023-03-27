
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
    /// Birlik Seviyesi Bakım Formu
    /// </summary>
    public partial class UnitMaintenanceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public UnitMaintenanceReport MyParentReport
            {
                get { return (UnitMaintenanceReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField RESPONSIBLEPERSON { get {return Header().RESPONSIBLEPERSON;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1123 { get {return Header().NewField1123;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1112121 { get {return Header().NewField1112121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NATOSTOCKNO { get {return Header().NATOSTOCKNO;} }
            public TTReportField MARKMODEL { get {return Header().MARKMODEL;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField SERIALNO { get {return Header().SERIALNO;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField PERIOD { get {return Header().PERIOD;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField NewField121211 { get {return Header().NewField121211;} }
            public TTReportField NewField121212 { get {return Header().NewField121212;} }
            public TTReportField NewField1212121 { get {return Header().NewField1212121;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField NewField1211 { get {return Footer().NewField1211;} }
            public TTReportShape NewLine1211 { get {return Footer().NewLine1211;} }
            public TTReportShape NewLine113 { get {return Footer().NewLine113;} }
            public TTReportField NewField1212 { get {return Footer().NewField1212;} }
            public TTReportField NewField12121 { get {return Footer().NewField12121;} }
            public TTReportField NewField12122 { get {return Footer().NewField12122;} }
            public TTReportField NewField122121 { get {return Footer().NewField122121;} }
            public TTReportField NewField122122 { get {return Footer().NewField122122;} }
            public TTReportField NewField1221221 { get {return Footer().NewField1221221;} }
            public TTReportField NewField1221222 { get {return Footer().NewField1221222;} }
            public TTReportField NewField11221221 { get {return Footer().NewField11221221;} }
            public TTReportField NewField112121 { get {return Footer().NewField112121;} }
            public TTReportField NewField1121211 { get {return Footer().NewField1121211;} }
            public TTReportField NewField1121212 { get {return Footer().NewField1121212;} }
            public TTReportField NewField11121211 { get {return Footer().NewField11121211;} }
            public TTReportShape NewLine11211 { get {return Footer().NewLine11211;} }
            public TTReportShape NewLine111211 { get {return Footer().NewLine111211;} }
            public TTReportShape NewLine1311 { get {return Footer().NewLine1311;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField REPORTNAME111 { get {return Footer().REPORTNAME111;} }
            public TTReportField NewField11611 { get {return Footer().NewField11611;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>("GetUnitMaintenanceReportQueryNew", CMRActionRequest.GetUnitMaintenanceReportQueryNew((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public UnitMaintenanceReport MyParentReport
                {
                    get { return (UnitMaintenanceReport)ParentReport; }
                }
                
                public TTReportField MILITARYUNIT;
                public TTReportField NewField1111;
                public TTReportField RESPONSIBLEPERSON;
                public TTReportField NewField131;
                public TTReportField NewField1123;
                public TTReportField NewField111;
                public TTReportField NewField11;
                public TTReportField NewField1112121;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField1121;
                public TTReportField NATOSTOCKNO;
                public TTReportField MARKMODEL;
                public TTReportField MATERIALNAME;
                public TTReportField REPORTNAME;
                public TTReportField NewField121;
                public TTReportField NewField1141;
                public TTReportField NewField1241;
                public TTReportField NewField1341;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportField SERIALNO;
                public TTReportField NewField1122;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportField PERIOD;
                public TTReportField NewField11411;
                public TTReportShape NewLine112;
                public TTReportField NewField11212;
                public TTReportField NewField121211;
                public TTReportField NewField121212;
                public TTReportField NewField1212121;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1121;
                public TTReportField REPORTNAME1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 36, 153, 41, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @" {#MILITARYUNIT#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 36, 65, 41, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @" Birliği / Kurumu / Servisi :";

                    RESPONSIBLEPERSON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 36, 287, 41, false);
                    RESPONSIBLEPERSON.Name = "RESPONSIBLEPERSON";
                    RESPONSIBLEPERSON.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPERSON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPERSON.TextFont.Name = "Arial";
                    RESPONSIBLEPERSON.TextFont.CharSet = 162;
                    RESPONSIBLEPERSON.Value = @"{#DEVICEUSER#} / {#RANK#}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 36, 212, 41, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @" Kullanıcı Adı ve Soyadı / Rütbesi :";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 31, 230, 36, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123.TextFont.Name = "Arial";
                    NewField1123.TextFont.Bold = true;
                    NewField1123.TextFont.CharSet = 162;
                    NewField1123.Value = @" Bakım Periyodu";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 31, 53, 36, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @" Marka ve Modeli";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 26, 52, 31, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" Cihazın Adı";

                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 42, 153, 57, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112121.TextFont.Name = "Arial";
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @"Kontrol Edilecek Yerler";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 42, 220, 47, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"1 nci Bakım";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 42, 287, 47, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"2 nci Bakım";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 42, 31, 57, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"
Sıra
Nu.";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 26, 287, 31, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MARKMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 31, 153, 36, false);
                    MARKMODEL.Name = "MARKMODEL";
                    MARKMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKMODEL.TextFont.Name = "Arial";
                    MARKMODEL.TextFont.CharSet = 162;
                    MARKMODEL.Value = @"{#MARK#} / {#MODEL#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 26, 153, 31, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 287, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"BİRLİK SEVİYESİ BAKIM FORMU";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 26, 230, 31, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @" Stok Nu.";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 26, 231, 31, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 31, 53, 36, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @":";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 26, 53, 31, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1341.TextFont.Name = "Arial";
                    NewField1341.TextFont.Bold = true;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @":";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 25, 287, 25, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 42, 287, 42, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 25, 20, 57, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 28, 201, 33, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.TextFont.Name = "Arial";
                    SERIALNO.TextFont.CharSet = 162;
                    SERIALNO.Value = @"{#SERIALNUMBER#}";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 28, 171, 33, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @" Seri Nu. :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 25, 153, 42, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 25, 201, 36, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    PERIOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 31, 287, 36, false);
                    PERIOD.Name = "PERIOD";
                    PERIOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERIOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERIOD.TextFont.Name = "Arial";
                    PERIOD.TextFont.CharSet = 162;
                    PERIOD.Value = @"{#MAINTENANCEPERIOD#} GÜN";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 31, 231, 36, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 36, 287, 36, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 47, 187, 57, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212.TextFont.Name = "Arial";
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @"Kontrol
.. / .. / ..";

                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 47, 254, 57, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121211.TextFont.Name = "Arial";
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @"Kontrol
.. / .. / ..";

                    NewField121212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 47, 287, 57, false);
                    NewField121212.Name = "NewField121212";
                    NewField121212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121212.TextFont.Name = "Arial";
                    NewField121212.TextFont.Bold = true;
                    NewField121212.TextFont.CharSet = 162;
                    NewField121212.Value = @"Parafe";

                    NewField1212121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 47, 220, 57, false);
                    NewField1212121.Name = "NewField1212121";
                    NewField1212121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212121.TextFont.Name = "Arial";
                    NewField1212121.TextFont.Bold = true;
                    NewField1212121.TextFont.CharSet = 162;
                    NewField1212121.Value = @"Parafe";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 57, 287, 57, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 25, 287, 57, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.DrawWidth = 2;

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 287, 12, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 11;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class dataset_GetUnitMaintenanceReportQueryNew = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>(0);
                    MILITARYUNIT.CalcValue = @" " + (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Militaryunit) : "");
                    NewField1111.CalcValue = NewField1111.Value;
                    RESPONSIBLEPERSON.CalcValue = (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Deviceuser) : "") + @" / " + (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Rank) : "");
                    NewField131.CalcValue = NewField131.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1112121.CalcValue = NewField1112121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NATOSTOCKNO.CalcValue = (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.NATOStockNO) : "");
                    MARKMODEL.CalcValue = (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Mark) : "") + @" / " + (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Model) : "");
                    MATERIALNAME.CalcValue = (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Materialname) : "");
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    SERIALNO.CalcValue = (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.SerialNumber) : "");
                    NewField1122.CalcValue = NewField1122.Value;
                    PERIOD.CalcValue = (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.MaintenancePeriod) : "") + @" GÜN";
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField121212.CalcValue = NewField121212.Value;
                    NewField1212121.CalcValue = NewField1212121.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    return new TTReportObject[] { MILITARYUNIT,NewField1111,RESPONSIBLEPERSON,NewField131,NewField1123,NewField111,NewField11,NewField1112121,NewField11211,NewField111211,NewField1121,NATOSTOCKNO,MARKMODEL,MATERIALNAME,REPORTNAME,NewField121,NewField1141,NewField1241,NewField1341,SERIALNO,NewField1122,PERIOD,NewField11411,NewField11212,NewField121211,NewField121212,NewField1212121,REPORTNAME1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public UnitMaintenanceReport MyParentReport
                {
                    get { return (UnitMaintenanceReport)ParentReport; }
                }
                
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine113;
                public TTReportField NewField1212;
                public TTReportField NewField12121;
                public TTReportField NewField12122;
                public TTReportField NewField122121;
                public TTReportField NewField122122;
                public TTReportField NewField1221221;
                public TTReportField NewField1221222;
                public TTReportField NewField11221221;
                public TTReportField NewField112121;
                public TTReportField NewField1121211;
                public TTReportField NewField1121212;
                public TTReportField NewField11121211;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine111211;
                public TTReportShape NewLine1311;
                public TTReportField NewField151;
                public TTReportField NewField12;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField REPORTNAME111;
                public TTReportField NewField11611; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 99;
                    RepeatCount = 0;
                    
                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 57, 6, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @" Varsa İlave Bilgiler :";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 6, 287, 11, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @" Tıbbi Cihazın Bu Formdaki Maddelerde Geçen Bakımının; Cihazın Özel Teknik Dökümanına Göre Tam Olarak Yapıldığı Tasdik Edilir.";

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 6, 287, 6, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 11, 287, 11, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.DrawWidth = 2;

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 25, 53, 39, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @" İMZASI
 ADI SOYADI
 SINIF VE RÜTBESİ";

                    NewField12121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 11, 53, 25, false);
                    NewField12121.Name = "NewField12121";
                    NewField12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12121.TextFont.Name = "Arial";
                    NewField12121.TextFont.Bold = true;
                    NewField12121.TextFont.CharSet = 162;
                    NewField12121.Value = @"";

                    NewField12122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 11, 170, 18, false);
                    NewField12122.Name = "NewField12122";
                    NewField12122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12122.TextFont.Name = "Arial";
                    NewField12122.TextFont.Bold = true;
                    NewField12122.TextFont.CharSet = 162;
                    NewField12122.Value = @"Birlik Bakım Kademe Teknisyeni";

                    NewField122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 11, 287, 18, false);
                    NewField122121.Name = "NewField122121";
                    NewField122121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122121.TextFont.Name = "Arial";
                    NewField122121.TextFont.Bold = true;
                    NewField122121.TextFont.CharSet = 162;
                    NewField122121.Value = @"Kullanıcı Birlik Personeli";

                    NewField122122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 18, 112, 25, false);
                    NewField122122.Name = "NewField122122";
                    NewField122122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122122.TextFont.Name = "Arial";
                    NewField122122.TextFont.Bold = true;
                    NewField122122.TextFont.CharSet = 162;
                    NewField122122.Value = @"1 nci Bakım";

                    NewField1221221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 18, 170, 25, false);
                    NewField1221221.Name = "NewField1221221";
                    NewField1221221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221221.TextFont.Name = "Arial";
                    NewField1221221.TextFont.Bold = true;
                    NewField1221221.TextFont.CharSet = 162;
                    NewField1221221.Value = @"2 nci Bakım";

                    NewField1221222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 18, 229, 25, false);
                    NewField1221222.Name = "NewField1221222";
                    NewField1221222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221222.TextFont.Name = "Arial";
                    NewField1221222.TextFont.Bold = true;
                    NewField1221222.TextFont.CharSet = 162;
                    NewField1221222.Value = @"1 nci Bakım";

                    NewField11221221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 18, 287, 25, false);
                    NewField11221221.Name = "NewField11221221";
                    NewField11221221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221221.TextFont.Name = "Arial";
                    NewField11221221.TextFont.Bold = true;
                    NewField11221221.TextFont.CharSet = 162;
                    NewField11221221.Value = @"2 nci Bakım";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 25, 112, 39, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"";

                    NewField1121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 25, 170, 39, false);
                    NewField1121211.Name = "NewField1121211";
                    NewField1121211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121211.TextFont.Name = "Arial";
                    NewField1121211.TextFont.Bold = true;
                    NewField1121211.TextFont.CharSet = 162;
                    NewField1121211.Value = @"";

                    NewField1121212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 25, 229, 39, false);
                    NewField1121212.Name = "NewField1121212";
                    NewField1121212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121212.TextFont.Name = "Arial";
                    NewField1121212.TextFont.Bold = true;
                    NewField1121212.TextFont.CharSet = 162;
                    NewField1121212.Value = @"";

                    NewField11121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 25, 287, 39, false);
                    NewField11121211.Name = "NewField11121211";
                    NewField11121211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121211.TextFont.Name = "Arial";
                    NewField11121211.TextFont.Bold = true;
                    NewField11121211.TextFont.CharSet = 162;
                    NewField11121211.Value = @"";

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 20, 39, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211.DrawWidth = 2;

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 39, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111211.DrawWidth = 2;

                    NewLine1311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 39, 287, 39, false);
                    NewLine1311.Name = "NewLine1311";
                    NewLine1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311.DrawWidth = 2;

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 45, 168, 50, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.Underline = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"O N A Y";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 52, 184, 57, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.Value = @"....................................................";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 59, 184, 64, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.Value = @"....................................................";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 64, 184, 71, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.TextFont.Size = 12;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"XXXXXX.Shh.İkm.Bkm.Mrk.K.lığı";

                    REPORTNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 82, 184, 89, false);
                    REPORTNAME111.Name = "REPORTNAME111";
                    REPORTNAME111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME111.TextFont.Name = "Arial";
                    REPORTNAME111.TextFont.Size = 11;
                    REPORTNAME111.TextFont.Bold = true;
                    REPORTNAME111.TextFont.CharSet = 162;
                    REPORTNAME111.Value = @"HİZMETE ÖZEL";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 76, 184, 82, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 12;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"5-30";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class dataset_GetUnitMaintenanceReportQueryNew = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>(0);
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField12121.CalcValue = NewField12121.Value;
                    NewField12122.CalcValue = NewField12122.Value;
                    NewField122121.CalcValue = NewField122121.Value;
                    NewField122122.CalcValue = NewField122122.Value;
                    NewField1221221.CalcValue = NewField1221221.Value;
                    NewField1221222.CalcValue = NewField1221222.Value;
                    NewField11221221.CalcValue = NewField11221221.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField1121211.CalcValue = NewField1121211.Value;
                    NewField1121212.CalcValue = NewField1121212.Value;
                    NewField11121211.CalcValue = NewField11121211.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    REPORTNAME111.CalcValue = REPORTNAME111.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    return new TTReportObject[] { NewField112,NewField1211,NewField1212,NewField12121,NewField12122,NewField122121,NewField122122,NewField1221221,NewField1221222,NewField11221221,NewField112121,NewField1121211,NewField1121212,NewField11121211,NewField151,NewField12,NewField161,NewField1161,REPORTNAME111,NewField11611};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public UnitMaintenanceReport MyParentReport
            {
                get { return (UnitMaintenanceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField DAILYMAINTENANCE { get {return Body().DAILYMAINTENANCE;} }
            public TTReportField WEEKLYMAINTENANCE { get {return Body().WEEKLYMAINTENANCE;} }
            public TTReportField PARAMETER { get {return Body().PARAMETER;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportField DAILYMAINTENANCE1 { get {return Body().DAILYMAINTENANCE1;} }
            public TTReportField WEEKLYMAINTENANCE1 { get {return Body().WEEKLYMAINTENANCE1;} }
            public TTReportShape NewLine11211 { get {return Body().NewLine11211;} }
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

                CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class dataSet_GetUnitMaintenanceReportQueryNew = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>(0);    
                return new object[] {(dataSet_GetUnitMaintenanceReportQueryNew==null ? null : dataSet_GetUnitMaintenanceReportQueryNew.ObjectID)};
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
                public UnitMaintenanceReport MyParentReport
                {
                    get { return (UnitMaintenanceReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField DAILYMAINTENANCE;
                public TTReportField WEEKLYMAINTENANCE;
                public TTReportField PARAMETER;
                public TTReportShape NewLine1121;
                public TTReportField DAILYMAINTENANCE1;
                public TTReportField WEEKLYMAINTENANCE1;
                public TTReportShape NewLine11211; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 31, 10, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    DAILYMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 187, 10, false);
                    DAILYMAINTENANCE.Name = "DAILYMAINTENANCE";
                    DAILYMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DAILYMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAILYMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAILYMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DAILYMAINTENANCE.TextFont.Name = "Arial";
                    DAILYMAINTENANCE.TextFont.CharSet = 162;
                    DAILYMAINTENANCE.Value = @"";

                    WEEKLYMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 220, 10, false);
                    WEEKLYMAINTENANCE.Name = "WEEKLYMAINTENANCE";
                    WEEKLYMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    WEEKLYMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEEKLYMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEEKLYMAINTENANCE.TextFont.Name = "Arial";
                    WEEKLYMAINTENANCE.TextFont.CharSet = 162;
                    WEEKLYMAINTENANCE.Value = @"";

                    PARAMETER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 0, 153, 10, false);
                    PARAMETER.Name = "PARAMETER";
                    PARAMETER.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETER.MultiLine = EvetHayirEnum.ehEvet;
                    PARAMETER.WordBreak = EvetHayirEnum.ehEvet;
                    PARAMETER.TextFont.Name = "Arial";
                    PARAMETER.TextFont.CharSet = 162;
                    PARAMETER.Value = @" {#PARTA.PARAMETER#}";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 20, 10, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.DrawWidth = 2;

                    DAILYMAINTENANCE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 0, 254, 10, false);
                    DAILYMAINTENANCE1.Name = "DAILYMAINTENANCE1";
                    DAILYMAINTENANCE1.DrawStyle = DrawStyleConstants.vbSolid;
                    DAILYMAINTENANCE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAILYMAINTENANCE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAILYMAINTENANCE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DAILYMAINTENANCE1.TextFont.Name = "Arial";
                    DAILYMAINTENANCE1.TextFont.CharSet = 162;
                    DAILYMAINTENANCE1.Value = @"";

                    WEEKLYMAINTENANCE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 287, 10, false);
                    WEEKLYMAINTENANCE1.Name = "WEEKLYMAINTENANCE1";
                    WEEKLYMAINTENANCE1.DrawStyle = DrawStyleConstants.vbSolid;
                    WEEKLYMAINTENANCE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYMAINTENANCE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEEKLYMAINTENANCE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEEKLYMAINTENANCE1.TextFont.Name = "Arial";
                    WEEKLYMAINTENANCE1.TextFont.CharSet = 162;
                    WEEKLYMAINTENANCE1.Value = @"";

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 10, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class dataset_GetUnitMaintenanceReportQueryNew = MyParentReport.PARTA.rsGroup.GetCurrentRecord<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    DAILYMAINTENANCE.CalcValue = @"";
                    WEEKLYMAINTENANCE.CalcValue = @"";
                    PARAMETER.CalcValue = @" " + (dataset_GetUnitMaintenanceReportQueryNew != null ? Globals.ToStringCore(dataset_GetUnitMaintenanceReportQueryNew.Parameter) : "");
                    DAILYMAINTENANCE1.CalcValue = @"";
                    WEEKLYMAINTENANCE1.CalcValue = @"";
                    return new TTReportObject[] { COUNT,DAILYMAINTENANCE,WEEKLYMAINTENANCE,PARAMETER,DAILYMAINTENANCE1,WEEKLYMAINTENANCE1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public UnitMaintenanceReport()
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
            Name = "UNITMAINTENANCEREPORT";
            Caption = "Birlik Seviyesi Bakım Formu";
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