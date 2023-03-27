
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
    /// Cihaz Tanıtım Kartı Raporu
    /// </summary>
    public partial class FixedAssetMaterialPresentationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialPresentationReport MyParentReport
            {
                get { return (FixedAssetMaterialPresentationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField GuarantyStartDate { get {return Header().GuarantyStartDate;} }
            public TTReportField GuarantyEndDate { get {return Header().GuarantyEndDate;} }
            public TTReportField LastCalibrationDate { get {return Header().LastCalibrationDate;} }
            public TTReportField LastMaintenanceDate { get {return Header().LastMaintenanceDate;} }
            public TTReportField Mark { get {return Header().Mark;} }
            public TTReportField Model { get {return Header().Model;} }
            public TTReportField SerialNO { get {return Header().SerialNO;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField12241 { get {return Header().NewField12241;} }
            public TTReportField FixedAssetCode { get {return Header().FixedAssetCode;} }
            public TTReportField FixedAssetName { get {return Header().FixedAssetName;} }
            public TTReportField MaterialName { get {return Header().MaterialName;} }
            public TTReportField DeviceUser { get {return Header().DeviceUser;} }
            public TTReportField Service { get {return Header().Service;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField EVET { get {return Header().EVET;} }
            public TTReportField HAYIR { get {return Header().HAYIR;} }
            public TTReportField CHECK { get {return Header().CHECK;} }
            public TTReportField CHECK1 { get {return Header().CHECK1;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NEEDCALIBRATION { get {return Header().NEEDCALIBRATION;} }
            public TTReportField CALIBRATIONPERIOD { get {return Header().CALIBRATIONPERIOD;} }
            public TTReportField PRODUCTIONDATE { get {return Header().PRODUCTIONDATE;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
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
                list[0] = new TTReportNqlData<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>("GetFixedAssetMaterialPresentationReportQuery2", FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.OBJECTID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public FixedAssetMaterialPresentationReport MyParentReport
                {
                    get { return (FixedAssetMaterialPresentationReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField GuarantyStartDate;
                public TTReportField GuarantyEndDate;
                public TTReportField LastCalibrationDate;
                public TTReportField LastMaintenanceDate;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNO;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField12241;
                public TTReportField FixedAssetCode;
                public TTReportField FixedAssetName;
                public TTReportField MaterialName;
                public TTReportField DeviceUser;
                public TTReportField Service;
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField2;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField EVET;
                public TTReportField HAYIR;
                public TTReportField CHECK;
                public TTReportField CHECK1;
                public TTReportField NewField1161;
                public TTReportField NewField11611;
                public TTReportField NEEDCALIBRATION;
                public TTReportField CALIBRATIONPERIOD;
                public TTReportField PRODUCTIONDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 45, 20, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Demirbaş Kodu";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 8, 118, 20, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Demirbaş Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 118, 32, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Malzeme Adı";

                    GuarantyStartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 8, 170, 14, false);
                    GuarantyStartDate.Name = "GuarantyStartDate";
                    GuarantyStartDate.DrawStyle = DrawStyleConstants.vbSolid;
                    GuarantyStartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    GuarantyStartDate.TextFormat = @"dd/MM/yyyy";
                    GuarantyStartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GuarantyStartDate.Value = @"{#GUARANTYSTARTDATE#}";

                    GuarantyEndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 14, 170, 20, false);
                    GuarantyEndDate.Name = "GuarantyEndDate";
                    GuarantyEndDate.DrawStyle = DrawStyleConstants.vbSolid;
                    GuarantyEndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    GuarantyEndDate.TextFormat = @"dd/MM/yyyy";
                    GuarantyEndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GuarantyEndDate.Value = @"{#GUARANTYENDDATE#}";

                    LastCalibrationDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 20, 170, 26, false);
                    LastCalibrationDate.Name = "LastCalibrationDate";
                    LastCalibrationDate.DrawStyle = DrawStyleConstants.vbSolid;
                    LastCalibrationDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    LastCalibrationDate.TextFormat = @"dd/MM/yyyy";
                    LastCalibrationDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LastCalibrationDate.Value = @"{#LASTCALIBRATIONDATE#}";

                    LastMaintenanceDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 26, 170, 32, false);
                    LastMaintenanceDate.Name = "LastMaintenanceDate";
                    LastMaintenanceDate.DrawStyle = DrawStyleConstants.vbSolid;
                    LastMaintenanceDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    LastMaintenanceDate.TextFormat = @"dd/MM/yyyy";
                    LastMaintenanceDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LastMaintenanceDate.Value = @"{#LASTMAINTENANCEDATE#}";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 32, 56, 38, false);
                    Mark.Name = "Mark";
                    Mark.DrawStyle = DrawStyleConstants.vbSolid;
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.Value = @"{#MARK#}";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 32, 113, 38, false);
                    Model.Name = "Model";
                    Model.DrawStyle = DrawStyleConstants.vbSolid;
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.Value = @"{#MODEL#}";

                    SerialNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 32, 170, 38, false);
                    SerialNO.Name = "SerialNO";
                    SerialNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SerialNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNO.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SerialNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNO.Value = @"{#SERIALNUMBER#}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 44, 85, 56, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Zimmet Sahibi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 44, 170, 56, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Bulunduğu Servis";

                    NewField12241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 56, 170, 62, false);
                    NewField12241.Name = "NewField12241";
                    NewField12241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12241.TextFont.Bold = true;
                    NewField12241.TextFont.CharSet = 162;
                    NewField12241.Value = @"Muhteviyat";

                    FixedAssetCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 14, 44, 19, false);
                    FixedAssetCode.Name = "FixedAssetCode";
                    FixedAssetCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetCode.Value = @"{#FIXEDASSETNO#}";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 14, 117, 19, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.Value = @"{#FIXEDMATERIALNAME#}";

                    MaterialName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 26, 117, 31, false);
                    MaterialName.Name = "MaterialName";
                    MaterialName.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MaterialName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialName.Value = @"{#MATERIALNAME#}";

                    DeviceUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 50, 84, 55, false);
                    DeviceUser.Name = "DeviceUser";
                    DeviceUser.FieldType = ReportFieldTypeEnum.ftVariable;
                    DeviceUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    DeviceUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DeviceUser.Value = @"{#DEVICEUSER#}";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 50, 169, 55, false);
                    Service.Name = "Service";
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.Value = @"{#SERVICE#}";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 120, 6, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.NoClip = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Size = 11;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"CİHAZ TANITIM KARTI";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 8, 151, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Garanti Başlama Tarihi:";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 14, 151, 20, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Garanti Bitiş Tarihi:";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 20, 151, 26, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Son Kalibrasyon Tarihi:";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 26, 151, 32, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Son Bakım Tarihi:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 32, 20, 38, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Marka";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 32, 76, 38, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Model";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 32, 133, 38, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Seri Numarası";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 38, 32, 44, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 9;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Kalibrasyon Gerektir :";

                    EVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 38, 47, 44, false);
                    EVET.Name = "EVET";
                    EVET.DrawStyle = DrawStyleConstants.vbSolid;
                    EVET.CaseFormat = CaseFormatEnum.fcTitleCase;
                    EVET.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EVET.Value = @"EVET";

                    HAYIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 38, 64, 44, false);
                    HAYIR.Name = "HAYIR";
                    HAYIR.DrawStyle = DrawStyleConstants.vbSolid;
                    HAYIR.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HAYIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAYIR.Value = @"HAYIR";

                    CHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 38, 39, 44, false);
                    CHECK.Name = "CHECK";
                    CHECK.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CHECK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK.Value = @"";

                    CHECK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 38, 54, 44, false);
                    CHECK1.Name = "CHECK1";
                    CHECK1.DrawStyle = DrawStyleConstants.vbSolid;
                    CHECK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHECK1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CHECK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHECK1.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 38, 96, 44, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Kalibrasyon Periyodu :";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 38, 133, 44, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"İmal Tarihi :";

                    NEEDCALIBRATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 10, 236, 15, false);
                    NEEDCALIBRATION.Name = "NEEDCALIBRATION";
                    NEEDCALIBRATION.Visible = EvetHayirEnum.ehHayir;
                    NEEDCALIBRATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEEDCALIBRATION.Value = @"{#NEEDCALIBRATION#}";

                    CALIBRATIONPERIOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 38, 113, 44, false);
                    CALIBRATIONPERIOD.Name = "CALIBRATIONPERIOD";
                    CALIBRATIONPERIOD.DrawStyle = DrawStyleConstants.vbSolid;
                    CALIBRATIONPERIOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    CALIBRATIONPERIOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CALIBRATIONPERIOD.Value = @"{#CALIBRATIONPERIOD#}";

                    PRODUCTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 38, 170, 44, false);
                    PRODUCTIONDATE.Name = "PRODUCTIONDATE";
                    PRODUCTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTIONDATE.TextFormat = @"Short Date";
                    PRODUCTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCTIONDATE.Value = @"{#PRODUCTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class dataset_GetFixedAssetMaterialPresentationReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = @"Demirbaş Adı";
                    NewField1111.CalcValue = NewField1111.Value;
                    GuarantyStartDate.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.GuarantyStartDate) : "");
                    GuarantyEndDate.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.GuarantyEndDate) : "");
                    LastCalibrationDate.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.LastCalibrationDate) : "");
                    LastMaintenanceDate.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.LastMaintenanceDate) : "");
                    Mark.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Mark) : "");
                    Model.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Model) : "");
                    SerialNO.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.SerialNumber) : "");
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField12241.CalcValue = NewField12241.Value;
                    FixedAssetCode.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.FixedAssetNO) : "");
                    FixedAssetName.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Fixedmaterialname) : "");
                    MaterialName.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Materialname) : "");
                    DeviceUser.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Deviceuser) : "");
                    Service.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Service) : "");
                    ReportName.CalcValue = ReportName.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    EVET.CalcValue = EVET.Value;
                    HAYIR.CalcValue = HAYIR.Value;
                    CHECK.CalcValue = @"";
                    CHECK1.CalcValue = @"";
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NEEDCALIBRATION.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.NeedCalibration) : "");
                    CALIBRATIONPERIOD.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.CalibrationPeriod) : "");
                    PRODUCTIONDATE.CalcValue = (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.ProductionDate) : "");
                    return new TTReportObject[] { NewField11,NewField111,NewField1111,GuarantyStartDate,GuarantyEndDate,LastCalibrationDate,LastMaintenanceDate,Mark,Model,SerialNO,NewField131,NewField1131,NewField12241,FixedAssetCode,FixedAssetName,MaterialName,DeviceUser,Service,ReportName,NewField1,NewField12,NewField13,NewField14,NewField2,NewField15,NewField16,NewField161,EVET,HAYIR,CHECK,CHECK1,NewField1161,NewField11611,NEEDCALIBRATION,CALIBRATIONPERIOD,PRODUCTIONDATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(NEEDCALIBRATION.CalcValue == "")
            {
                CHECK.CalcValue ="";
                CHECK1.CalcValue ="";
            }
            else if(NEEDCALIBRATION.CalcValue == "False")
            {
                CHECK.CalcValue ="";
                CHECK1.CalcValue ="X";
            }
            else
            {
                CHECK.CalcValue ="X";
                CHECK1.CalcValue ="";
            }
            if(CALIBRATIONPERIOD.CalcValue == "0")
                CALIBRATIONPERIOD.CalcValue = "-";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialPresentationReport MyParentReport
                {
                    get { return (FixedAssetMaterialPresentationReport)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 0, 100, 5, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Name = "Arial";
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class dataset_GetFixedAssetMaterialPresentationReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>(0);
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CurrentUser1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public FixedAssetMaterialPresentationReport MyParentReport
            {
                get { return (FixedAssetMaterialPresentationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MaterialContent { get {return Body().MaterialContent;} }
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

                FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class dataSet_GetFixedAssetMaterialPresentationReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>(0);    
                return new object[] {(dataSet_GetFixedAssetMaterialPresentationReportQuery2==null ? null : dataSet_GetFixedAssetMaterialPresentationReportQuery2.ObjectID)};
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
                public FixedAssetMaterialPresentationReport MyParentReport
                {
                    get { return (FixedAssetMaterialPresentationReport)ParentReport; }
                }
                
                public TTReportField MaterialContent; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    MaterialContent = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 170, 6, false);
                    MaterialContent.Name = "MaterialContent";
                    MaterialContent.DrawStyle = DrawStyleConstants.vbSolid;
                    MaterialContent.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialContent.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialContent.Value = @"{@counter@} - {#PARTA.CONTENTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class dataset_GetFixedAssetMaterialPresentationReportQuery2 = MyParentReport.PARTA.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>(0);
                    MaterialContent.CalcValue = ParentGroup.Counter.ToString() + @" - " + (dataset_GetFixedAssetMaterialPresentationReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialPresentationReportQuery2.Contentname) : "");
                    return new TTReportObject[] { MaterialContent};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FixedAssetMaterialPresentationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "", "Demirbaş Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("a45073d2-3e80-4264-b596-1d4962072c8e");
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["OBJECTID"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            Name = "FIXEDASSETMATERIALPRESENTATIONREPORT";
            Caption = "Cihaz Tanıtım Kartı Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 25;
            UserMarginTop = 15;
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