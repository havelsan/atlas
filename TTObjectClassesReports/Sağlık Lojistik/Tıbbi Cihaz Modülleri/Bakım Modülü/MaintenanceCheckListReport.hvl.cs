
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
    /// Kontrol Listesi
    /// </summary>
    public partial class MaintenanceCheckListReport : TTReport
    {
#region Methods
   public int counter =0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public MaintenanceCheckListReport MyParentReport
            {
                get { return (MaintenanceCheckListReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField MARK { get {return Header().MARK;} }
            public TTReportField MODEL { get {return Header().MODEL;} }
            public TTReportField SERIALNUMBER { get {return Header().SERIALNUMBER;} }
            public TTReportField SENDERSECTION { get {return Header().SENDERSECTION;} }
            public TTReportField NewField11611 { get {return Footer().NewField11611;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField CHECK1 { get {return Footer().CHECK1;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField CHECK11 { get {return Footer().CHECK11;} }
            public TTReportField NewField181 { get {return Footer().NewField181;} }
            public TTReportField CHECK12 { get {return Footer().CHECK12;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField CHECK13 { get {return Footer().CHECK13;} }
            public TTReportField NewField102 { get {return Footer().NewField102;} }
            public TTReportField CHECK14 { get {return Footer().CHECK14;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField CHECK15 { get {return Footer().CHECK15;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField CHECK16 { get {return Footer().CHECK16;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField1231 { get {return Footer().NewField1231;} }
            public TTReportField NewField1331 { get {return Footer().NewField1331;} }
            public TTReportField NewField142 { get {return Footer().NewField142;} }
            public TTReportField NewField1241 { get {return Footer().NewField1241;} }
            public TTReportField NewField11421 { get {return Footer().NewField11421;} }
            public TTReportField NewField12421 { get {return Footer().NewField12421;} }
            public TTReportField NewField13421 { get {return Footer().NewField13421;} }
            public TTReportField NewField112431 { get {return Footer().NewField112431;} }
            public TTReportField NewField122431 { get {return Footer().NewField122431;} }
            public TTReportField NewField132431 { get {return Footer().NewField132431;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportShape NewLine141 { get {return Footer().NewLine141;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public TTReportField NAMESURNAME { get {return Footer().NAMESURNAME;} }
            public TTReportField CLASSRANK { get {return Footer().CLASSRANK;} }
            public TTReportField SICIL { get {return Footer().SICIL;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Maintenance.GetMaintenanceCheckListQuery_Class>("GetMaintenanceCheckListQuery2", Maintenance.GetMaintenanceCheckListQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NAME;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField SERIALNUMBER;
                public TTReportField SENDERSECTION; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 59;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 202, 18, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"TIBBİ CİHAZLARIN BAKIM VE KALİBRASYONUNDA KULLANILACAK KONTROL LİSTESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 18, 52, 25, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"CİHAZIN ADI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 25, 52, 32, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"MARKASI";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 32, 52, 39, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"MODELİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 39, 52, 46, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Size = 11;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"ZİMMET KODU";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 46, 52, 53, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"KLİNİĞİ";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 53, 202, 60, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"CİHAZLA İLGİLİ İŞLEMLER";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 18, 202, 25, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 25, 202, 32, false);
                    MARK.Name = "MARK";
                    MARK.DrawStyle = DrawStyleConstants.vbSolid;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.Value = @"{#MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 32, 202, 39, false);
                    MODEL.Name = "MODEL";
                    MODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.Value = @"{#MODEL#}";

                    SERIALNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 39, 202, 46, false);
                    SERIALNUMBER.Name = "SERIALNUMBER";
                    SERIALNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER.Value = @"{#SERIALNUMBER#}";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 46, 202, 53, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.ObjectDefName = "ResSection";
                    SENDERSECTION.DataMember = "NAME";
                    SENDERSECTION.Value = @"{#SENDERSECTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Maintenance.GetMaintenanceCheckListQuery_Class dataset_GetMaintenanceCheckListQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Maintenance.GetMaintenanceCheckListQuery_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NAME.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.Name) : "");
                    MARK.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.Mark) : "");
                    MODEL.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.Model) : "");
                    SERIALNUMBER.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.SerialNumber) : "");
                    SENDERSECTION.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.SenderSection) : "");
                    SENDERSECTION.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField11,NewField12,NewField121,NewField131,NewField141,NewField151,NewField161,NAME,MARK,MODEL,SERIALNUMBER,SENDERSECTION};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                
                public TTReportField NewField11611;
                public TTReportField NewField13;
                public TTReportField CHECK1;
                public TTReportField NewField171;
                public TTReportField CHECK11;
                public TTReportField NewField181;
                public TTReportField CHECK12;
                public TTReportField NewField191;
                public TTReportField CHECK13;
                public TTReportField NewField102;
                public TTReportField CHECK14;
                public TTReportField NewField112;
                public TTReportField CHECK15;
                public TTReportField NewField122;
                public TTReportField CHECK16;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine12;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportShape NewLine13;
                public TTReportField NewField132;
                public TTReportField NewField1231;
                public TTReportField NewField1331;
                public TTReportField NewField142;
                public TTReportField NewField1241;
                public TTReportField NewField11421;
                public TTReportField NewField12421;
                public TTReportField NewField13421;
                public TTReportField NewField112431;
                public TTReportField NewField122431;
                public TTReportField NewField132431;
                public TTReportShape NewLine14;
                public TTReportShape NewLine141;
                public TTReportShape NewLine131;
                public TTReportField NAMESURNAME;
                public TTReportField CLASSRANK;
                public TTReportField SICIL; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 203;
                    RepeatCount = 0;
                    
                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 202, 14, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.TextFont.Size = 11;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"ALTYAPININ KONTROLÜ VE İYİLEŞTİRİLME İHTİCAYI VAR MI ?";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 16, 44, 21, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"a. Elektrik";

                    CHECK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 16, 62, 21, false);
                    CHECK1.Name = "CHECK1";
                    CHECK1.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK1.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK1.TextFont.CharSet = 162;
                    CHECK1.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 24, 44, 29, false);
                    NewField171.Name = "NewField171";
                    NewField171.Value = @"b. Su";

                    CHECK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 24, 62, 29, false);
                    CHECK11.Name = "CHECK11";
                    CHECK11.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK11.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK11.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK11.TextFont.CharSet = 162;
                    CHECK11.Value = @"";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 32, 44, 37, false);
                    NewField181.Name = "NewField181";
                    NewField181.Value = @"c. Tıbbi gaz";

                    CHECK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 32, 62, 37, false);
                    CHECK12.Name = "CHECK12";
                    CHECK12.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK12.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK12.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK12.TextFont.CharSet = 162;
                    CHECK12.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 40, 44, 45, false);
                    NewField191.Name = "NewField191";
                    NewField191.Value = @"d. Klima";

                    CHECK13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 40, 62, 45, false);
                    CHECK13.Name = "CHECK13";
                    CHECK13.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK13.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK13.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK13.TextFont.CharSet = 162;
                    CHECK13.Value = @"";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 48, 44, 53, false);
                    NewField102.Name = "NewField102";
                    NewField102.Value = @"e. Havalandırma";

                    CHECK14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 48, 62, 53, false);
                    CHECK14.Name = "CHECK14";
                    CHECK14.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK14.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK14.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK14.TextFont.CharSet = 162;
                    CHECK14.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 56, 88, 61, false);
                    NewField112.Name = "NewField112";
                    NewField112.Value = @"f. Bina fiziksel durumu (toz, nem, tavan akıntısı vb.)";

                    CHECK15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 56, 96, 61, false);
                    CHECK15.Name = "CHECK15";
                    CHECK15.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK15.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK15.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK15.TextFont.CharSet = 162;
                    CHECK15.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 64, 44, 69, false);
                    NewField122.Name = "NewField122";
                    NewField122.Value = @"g. Ağ (network)";

                    CHECK16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 64, 62, 69, false);
                    CHECK16.Name = "CHECK16";
                    CHECK16.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK16.FillStyle = FillStyleConstants.vbFSTransparent;
                    CHECK16.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHECK16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK16.TextFont.CharSet = 162;
                    CHECK16.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 13, 7, 146, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 14, 202, 146, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 80, 202, 80, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 81, 60, 86, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"İLAVE HUSUSLAR :";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 89, 196, 145, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 146, 202, 146, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 148, 60, 153, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Size = 11;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"PERSONEL BİLGİLERİ";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 157, 131, 162, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.TextFont.Size = 11;
                    NewField1231.TextFont.Bold = true;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"BAKIM YAPAN";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 157, 197, 162, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.TextFont.Size = 11;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"KONTROL EDEN";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 172, 60, 177, false);
                    NewField142.Name = "NewField142";
                    NewField142.Value = @"ADI SOYADI";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 180, 60, 185, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.Value = @"SINIFI VE RÜTBESİ";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 188, 60, 193, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.Value = @"SİCİL NO";

                    NewField12421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 195, 60, 200, false);
                    NewField12421.Name = "NewField12421";
                    NewField12421.Value = @"İMZA";

                    NewField13421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 172, 62, 177, false);
                    NewField13421.Name = "NewField13421";
                    NewField13421.Value = @":";

                    NewField112431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 180, 62, 185, false);
                    NewField112431.Name = "NewField112431";
                    NewField112431.Value = @":";

                    NewField122431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 188, 62, 193, false);
                    NewField122431.Name = "NewField122431";
                    NewField122431.Value = @":";

                    NewField132431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 195, 62, 200, false);
                    NewField132431.Name = "NewField132431";
                    NewField132431.Value = @":";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 146, 7, 202, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 146, 202, 202, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 202, 202, 202, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 172, 131, 177, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.Value = @"";

                    CLASSRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 180, 131, 185, false);
                    CLASSRANK.Name = "CLASSRANK";
                    CLASSRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASSRANK.Value = @"";

                    SICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 188, 131, 193, false);
                    SICIL.Name = "SICIL";
                    SICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICIL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Maintenance.GetMaintenanceCheckListQuery_Class dataset_GetMaintenanceCheckListQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Maintenance.GetMaintenanceCheckListQuery_Class>(0);
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField13.CalcValue = NewField13.Value;
                    CHECK1.CalcValue = @"";
                    NewField171.CalcValue = NewField171.Value;
                    CHECK11.CalcValue = @"";
                    NewField181.CalcValue = NewField181.Value;
                    CHECK12.CalcValue = @"";
                    NewField191.CalcValue = NewField191.Value;
                    CHECK13.CalcValue = @"";
                    NewField102.CalcValue = NewField102.Value;
                    CHECK14.CalcValue = @"";
                    NewField112.CalcValue = NewField112.Value;
                    CHECK15.CalcValue = @"";
                    NewField122.CalcValue = NewField122.Value;
                    CHECK16.CalcValue = @"";
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField12421.CalcValue = NewField12421.Value;
                    NewField13421.CalcValue = NewField13421.Value;
                    NewField112431.CalcValue = NewField112431.Value;
                    NewField122431.CalcValue = NewField122431.Value;
                    NewField132431.CalcValue = NewField132431.Value;
                    NAMESURNAME.CalcValue = @"";
                    CLASSRANK.CalcValue = @"";
                    SICIL.CalcValue = @"";
                    return new TTReportObject[] { NewField11611,NewField13,CHECK1,NewField171,CHECK11,NewField181,CHECK12,NewField191,CHECK13,NewField102,CHECK14,NewField112,CHECK15,NewField122,CHECK16,NewField14,NewField15,NewField132,NewField1231,NewField1331,NewField142,NewField1241,NewField11421,NewField12421,NewField13421,NewField112431,NewField122431,NewField132431,NAMESURNAME,CLASSRANK,SICIL};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    string sObjectID = ((MaintenanceCheckListReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Maintenance maintenance = (Maintenance)this.ParentReport.ReportObjectContext.GetObject(new Guid(sObjectID),"Maintenance");
            string clas = maintenance.ResponsibleUser.MilitaryClass  != null ? maintenance.ResponsibleUser.MilitaryClass.ShortName : " ";
            string rank = maintenance.ResponsibleUser.Rank != null ? maintenance.ResponsibleUser.Rank.ShortName :" ";
            this.NAMESURNAME.CalcValue = maintenance.ResponsibleUser.Name != null ? maintenance.ResponsibleUser.Name :" ";
            this.CLASSRANK.CalcValue =  clas + " - "+ rank;
            this.SICIL.CalcValue = maintenance.ResponsibleUser.EmploymentRecordID != null ? maintenance.ResponsibleUser.EmploymentRecordID :" " ;
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaintenanceCheckListReport MyParentReport
            {
                get { return (MaintenanceCheckListReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField MAINTENANCEPARAMETERDEF1 { get {return Footer().MAINTENANCEPARAMETERDEF1;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField EVET1 { get {return Footer().EVET1;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField HAYIR1 { get {return Footer().HAYIR1;} }
            public TTReportField DESCRIPTION1 { get {return Footer().DESCRIPTION1;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public TTReportField CHECK1 { get {return Footer().CHECK1;} }
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

                Maintenance.GetMaintenanceCheckListQuery_Class dataSet_GetMaintenanceCheckListQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Maintenance.GetMaintenanceCheckListQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceCheckListQuery2==null ? null : dataSet_GetMaintenanceCheckListQuery2.MaintenanceParameterDef)};
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
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                
                public TTReportField MAINTENANCEPARAMETERDEF1;
                public TTReportField NewField121;
                public TTReportField EVET1;
                public TTReportField NewField1111;
                public TTReportField HAYIR1;
                public TTReportField DESCRIPTION1;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine131;
                public TTReportField CHECK1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    RepeatCount = 0;
                    
                    MAINTENANCEPARAMETERDEF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 74, 14, false);
                    MAINTENANCEPARAMETERDEF1.Name = "MAINTENANCEPARAMETERDEF1";
                    MAINTENANCEPARAMETERDEF1.DrawStyle = DrawStyleConstants.vbSolid;
                    MAINTENANCEPARAMETERDEF1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINTENANCEPARAMETERDEF1.MultiLine = EvetHayirEnum.ehEvet;
                    MAINTENANCEPARAMETERDEF1.WordBreak = EvetHayirEnum.ehEvet;
                    MAINTENANCEPARAMETERDEF1.ObjectDefName = "MaintenanceParameterDefinition";
                    MAINTENANCEPARAMETERDEF1.DataMember = "PARAMETER";
                    MAINTENANCEPARAMETERDEF1.Value = @"{#PARTC.MAINTENANCEPARAMETERDEF#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 1, 92, 6, false);
                    NewField121.Name = "NewField121";
                    NewField121.Value = @"Evet";

                    EVET1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 97, 6, false);
                    EVET1.Name = "EVET1";
                    EVET1.DrawStyle = DrawStyleConstants.vbSolid;
                    EVET1.FillStyle = FillStyleConstants.vbFSTransparent;
                    EVET1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVET1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EVET1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EVET1.TextFont.CharSet = 162;
                    EVET1.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 8, 92, 13, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Value = @"Hayır";

                    HAYIR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 8, 97, 13, false);
                    HAYIR1.Name = "HAYIR1";
                    HAYIR1.DrawStyle = DrawStyleConstants.vbSolid;
                    HAYIR1.FillStyle = FillStyleConstants.vbFSTransparent;
                    HAYIR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAYIR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HAYIR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAYIR1.TextFont.CharSet = 162;
                    HAYIR1.Value = @"";

                    DESCRIPTION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 1, 202, 13, false);
                    DESCRIPTION1.Name = "DESCRIPTION1";
                    DESCRIPTION1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1.Value = @"{#PARTC.DESCRIPTION#}";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 0, 202, 0, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 14, 202, 14, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 0, 202, 14, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    CHECK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 2, 237, 7, false);
                    CHECK1.Name = "CHECK1";
                    CHECK1.Visible = EvetHayirEnum.ehHayir;
                    CHECK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK1.Value = @"{#PARTC.CHECK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Maintenance.GetMaintenanceCheckListQuery_Class dataset_GetMaintenanceCheckListQuery2 = MyParentReport.PARTC.rsGroup.GetCurrentRecord<Maintenance.GetMaintenanceCheckListQuery_Class>(0);
                    MAINTENANCEPARAMETERDEF1.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.MaintenanceParameterDef) : "");
                    MAINTENANCEPARAMETERDEF1.PostFieldValueCalculation();
                    NewField121.CalcValue = NewField121.Value;
                    EVET1.CalcValue = @"";
                    NewField1111.CalcValue = NewField1111.Value;
                    HAYIR1.CalcValue = @"";
                    DESCRIPTION1.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.Description) : "");
                    CHECK1.CalcValue = (dataset_GetMaintenanceCheckListQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceCheckListQuery2.Check) : "");
                    return new TTReportObject[] { MAINTENANCEPARAMETERDEF1,NewField121,EVET1,NewField1111,HAYIR1,DESCRIPTION1,CHECK1};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    if(this.CHECK1.CalcValue != "")
            {
                if(this.CHECK1.CalcValue == "True" )
                    this.EVET1.CalcValue = "X";
                else
                    this.HAYIR1.CalcValue = "X";
            }
            else
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public MaintenanceCheckListReport MyParentReport
            {
                get { return (MaintenanceCheckListReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField MAINTENANCEPARAMETERDEF { get {return Header().MAINTENANCEPARAMETERDEF;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField EVET { get {return Header().EVET;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField HAYIR { get {return Header().HAYIR;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField CHECK { get {return Header().CHECK;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
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
                list[0] = new TTReportNqlData<Maintenance.GetDeviceCheckListQuery_Class>("GetDeviceCheckListQuery", Maintenance.GetDeviceCheckListQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                
                public TTReportField MAINTENANCEPARAMETERDEF;
                public TTReportField NewField1;
                public TTReportField EVET;
                public TTReportField NewField11;
                public TTReportField HAYIR;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField CHECK;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MAINTENANCEPARAMETERDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 74, 14, false);
                    MAINTENANCEPARAMETERDEF.Name = "MAINTENANCEPARAMETERDEF";
                    MAINTENANCEPARAMETERDEF.DrawStyle = DrawStyleConstants.vbSolid;
                    MAINTENANCEPARAMETERDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINTENANCEPARAMETERDEF.MultiLine = EvetHayirEnum.ehEvet;
                    MAINTENANCEPARAMETERDEF.WordBreak = EvetHayirEnum.ehEvet;
                    MAINTENANCEPARAMETERDEF.ObjectDefName = "MaintenanceParameterDefinition";
                    MAINTENANCEPARAMETERDEF.DataMember = "PARAMETER";
                    MAINTENANCEPARAMETERDEF.Value = @"{#MAINTENANCEPARAMETERDEF#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 1, 92, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Evet";

                    EVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 97, 6, false);
                    EVET.Name = "EVET";
                    EVET.DrawStyle = DrawStyleConstants.vbSolid;
                    EVET.FillStyle = FillStyleConstants.vbFSTransparent;
                    EVET.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVET.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EVET.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EVET.TextFont.CharSet = 162;
                    EVET.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 8, 92, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"Hayır";

                    HAYIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 8, 97, 13, false);
                    HAYIR.Name = "HAYIR";
                    HAYIR.DrawStyle = DrawStyleConstants.vbSolid;
                    HAYIR.FillStyle = FillStyleConstants.vbFSTransparent;
                    HAYIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAYIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HAYIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAYIR.TextFont.CharSet = 162;
                    HAYIR.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 0, 202, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 14, 202, 14, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    CHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 2, 238, 7, false);
                    CHECK.Name = "CHECK";
                    CHECK.Visible = EvetHayirEnum.ehHayir;
                    CHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK.Value = @"{#CHECK#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 1, 201, 13, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, -1, 202, 14, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Maintenance.GetDeviceCheckListQuery_Class dataset_GetDeviceCheckListQuery = ParentGroup.rsGroup.GetCurrentRecord<Maintenance.GetDeviceCheckListQuery_Class>(0);
                    MAINTENANCEPARAMETERDEF.CalcValue = (dataset_GetDeviceCheckListQuery != null ? Globals.ToStringCore(dataset_GetDeviceCheckListQuery.MaintenanceParameterDef) : "");
                    MAINTENANCEPARAMETERDEF.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    EVET.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    HAYIR.CalcValue = @"";
                    CHECK.CalcValue = (dataset_GetDeviceCheckListQuery != null ? Globals.ToStringCore(dataset_GetDeviceCheckListQuery.Check) : "");
                    DESCRIPTION.CalcValue = (dataset_GetDeviceCheckListQuery != null ? Globals.ToStringCore(dataset_GetDeviceCheckListQuery.Description) : "");
                    return new TTReportObject[] { MAINTENANCEPARAMETERDEF,NewField1,EVET,NewField11,HAYIR,CHECK,DESCRIPTION};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(this.CHECK.CalcValue == "True" )
                this.EVET.CalcValue = "X";
            else
                this.HAYIR.CalcValue = "X";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MaintenanceCheckListReport MyParentReport
            {
                get { return (MaintenanceCheckListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        public partial class PARTDGroup : TTReportGroup
        {
            public MaintenanceCheckListReport MyParentReport
            {
                get { return (MaintenanceCheckListReport)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField count { get {return Body().count;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Maintenance.GetDeviceCheckListQuery_Class dataSet_GetDeviceCheckListQuery = ParentGroup.rsGroup.GetCurrentRecord<Maintenance.GetDeviceCheckListQuery_Class>(0);    
                return new object[] {(dataSet_GetDeviceCheckListQuery==null ? null : dataSet_GetDeviceCheckListQuery.MaintenanceParameterDef)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public MaintenanceCheckListReport MyParentReport
                {
                    get { return (MaintenanceCheckListReport)ParentReport; }
                }
                
                public TTReportField NewField111611;
                public TTReportField count; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 202, 7, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.TextFont.Size = 11;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"BAKIM İLE İLGİLİ İŞLEMLER";

                    count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 6, false);
                    count.Name = "count";
                    count.Visible = EvetHayirEnum.ehHayir;
                    count.FieldType = ReportFieldTypeEnum.ftVariable;
                    count.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Maintenance.GetDeviceCheckListQuery_Class dataset_GetDeviceCheckListQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<Maintenance.GetDeviceCheckListQuery_Class>(0);
                    NewField111611.CalcValue = NewField111611.Value;
                    count.CalcValue = @"";
                    return new TTReportObject[] { NewField111611,count};
                }

                public override void RunScript()
                {
#region PARTD BODY_Script
                    ((MaintenanceCheckListReport)ParentReport).counter+=1;
            if (((MaintenanceCheckListReport)ParentReport).counter > 1)
                this.Visible = EvetHayirEnum.ehHayir;
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaintenanceCheckListReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            PARTD = new PARTDGroup(PARTA,"PARTD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MAINTENANCECHECKLISTREPORT";
            Caption = "Kontrol Listesi";
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