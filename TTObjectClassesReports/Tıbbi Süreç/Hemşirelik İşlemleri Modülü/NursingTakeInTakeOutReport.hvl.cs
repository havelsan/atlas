
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
    /// Hemşirelik İşlemleri Aldığı Çıkardığı Raporu
    /// </summary>
    public partial class NursingTakeInTakeOutReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingTakeInTakeOutReport MyParentReport
            {
                get { return (NursingTakeInTakeOutReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField LOGO111 { get {return Header().LOGO111;} }
            public TTReportField BLEEDINGLable11 { get {return Header().BLEEDINGLable11;} }
            public TTReportField DRENLabel11 { get {return Header().DRENLabel11;} }
            public TTReportField GAITALable11 { get {return Header().GAITALable11;} }
            public TTReportField IVINFLable11 { get {return Header().IVINFLable11;} }
            public TTReportField ORALLable11 { get {return Header().ORALLable11;} }
            public TTReportField URETICLable11 { get {return Header().URETICLable11;} }
            public TTReportField VOMITINGLable11 { get {return Header().VOMITINGLable11;} }
            public TTReportField NAMELable11 { get {return Header().NAMELable11;} }
            public TTReportField INTOTALLable11 { get {return Header().INTOTALLable11;} }
            public TTReportField OUTTOTAL111 { get {return Header().OUTTOTAL111;} }
            public TTReportField DENGELable11 { get {return Header().DENGELable11;} }
            public TTReportField DATELable11 { get {return Header().DATELable11;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField DATELable111 { get {return Header().DATELable111;} }
            public TTReportField INTOTALLable111 { get {return Header().INTOTALLable111;} }
            public TTReportField INTOTALLable1111 { get {return Header().INTOTALLable1111;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField ODAYATAK { get {return Header().ODAYATAK;} }
            public TTReportField NewField11721 { get {return Header().NewField11721;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField SERVIS { get {return Header().SERVIS;} }
            public TTReportField NewField112711 { get {return Header().NewField112711;} }
            public TTReportField NewField1114111 { get {return Header().NewField1114111;} }
            public TTReportField ODA { get {return Header().ODA;} }
            public TTReportField YATAK { get {return Header().YATAK;} }
            public TTReportField ALDIGI { get {return Header().ALDIGI;} }
            public TTReportField CIGARDIGI { get {return Header().CIGARDIGI;} }
            public TTReportField ODAGRUBU { get {return Header().ODAGRUBU;} }
            public TTReportField KLINIK { get {return Header().KLINIK;} }
            public TTReportField BLEEDINGDAYTOTAL1 { get {return Footer().BLEEDINGDAYTOTAL1;} }
            public TTReportField DRENDAYTOTAL1 { get {return Footer().DRENDAYTOTAL1;} }
            public TTReportField GAITADAYTOTAL1 { get {return Footer().GAITADAYTOTAL1;} }
            public TTReportField IVINFDAYTOTAL1 { get {return Footer().IVINFDAYTOTAL1;} }
            public TTReportField ORALDAYTOTAL1 { get {return Footer().ORALDAYTOTAL1;} }
            public TTReportField URETICDAYTOTAL1 { get {return Footer().URETICDAYTOTAL1;} }
            public TTReportField VOMITINGDAYTOTAL1 { get {return Footer().VOMITINGDAYTOTAL1;} }
            public TTReportField INTOTALDAYTOTAL1 { get {return Footer().INTOTALDAYTOTAL1;} }
            public TTReportField OUTTOTALDAYTOTAL1 { get {return Footer().OUTTOTALDAYTOTAL1;} }
            public TTReportField DENGEDAYTOTAL1 { get {return Footer().DENGEDAYTOTAL1;} }
            public TTReportField TARIH111 { get {return Footer().TARIH111;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public NursingTakeInTakeOutReport MyParentReport
                {
                    get { return (NursingTakeInTakeOutReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField XXXXXXBASLIK111;
                public TTReportField LOGO111;
                public TTReportField BLEEDINGLable11;
                public TTReportField DRENLabel11;
                public TTReportField GAITALable11;
                public TTReportField IVINFLable11;
                public TTReportField ORALLable11;
                public TTReportField URETICLable11;
                public TTReportField VOMITINGLable11;
                public TTReportField NAMELable11;
                public TTReportField INTOTALLable11;
                public TTReportField OUTTOTAL111;
                public TTReportField DENGELable11;
                public TTReportField DATELable11;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField DATELable111;
                public TTReportField INTOTALLable111;
                public TTReportField INTOTALLable1111;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField141;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField1221;
                public TTReportField TARIH;
                public TTReportField NewField1271;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField ODAYATAK;
                public TTReportField NewField11721;
                public TTReportField NewField111411;
                public TTReportField SERVIS;
                public TTReportField NewField112711;
                public TTReportField NewField1114111;
                public TTReportField ODA;
                public TTReportField YATAK;
                public TTReportField ALDIGI;
                public TTReportField CIGARDIGI;
                public TTReportField ODAGRUBU;
                public TTReportField KLINIK; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 85;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 28, 210, 36, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Hemşirelik Bilgileri Raporu";

                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 4, 210, 27, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Size = 11;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.TextFont.CharSet = 162;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 4, 67, 24, false);
                    LOGO111.Name = "LOGO111";
                    LOGO111.TextFont.Name = "Courier New";
                    LOGO111.Value = @"LOGO";

                    BLEEDINGLable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 80, 234, 85, false);
                    BLEEDINGLable11.Name = "BLEEDINGLable11";
                    BLEEDINGLable11.TextFont.Size = 9;
                    BLEEDINGLable11.TextFont.Bold = true;
                    BLEEDINGLable11.TextFont.CharSet = 162;
                    BLEEDINGLable11.Value = @"Kanama";

                    DRENLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 80, 204, 85, false);
                    DRENLabel11.Name = "DRENLabel11";
                    DRENLabel11.TextFont.Size = 9;
                    DRENLabel11.TextFont.Bold = true;
                    DRENLabel11.TextFont.CharSet = 162;
                    DRENLabel11.Value = @"Dren";

                    GAITALable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 80, 189, 85, false);
                    GAITALable11.Name = "GAITALable11";
                    GAITALable11.TextFont.Size = 9;
                    GAITALable11.TextFont.Bold = true;
                    GAITALable11.TextFont.CharSet = 162;
                    GAITALable11.Value = @"Gaita";

                    IVINFLable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 80, 129, 85, false);
                    IVINFLable11.Name = "IVINFLable11";
                    IVINFLable11.TextFont.Size = 9;
                    IVINFLable11.TextFont.Bold = true;
                    IVINFLable11.TextFont.CharSet = 162;
                    IVINFLable11.Value = @"IV İnf";

                    ORALLable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 80, 144, 85, false);
                    ORALLable11.Name = "ORALLable11";
                    ORALLable11.TextFont.Size = 9;
                    ORALLable11.TextFont.Bold = true;
                    ORALLable11.TextFont.CharSet = 162;
                    ORALLable11.Value = @"Oral";

                    URETICLable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 80, 174, 85, false);
                    URETICLable11.Name = "URETICLable11";
                    URETICLable11.TextFont.Size = 9;
                    URETICLable11.TextFont.Bold = true;
                    URETICLable11.TextFont.CharSet = 162;
                    URETICLable11.Value = @"İdrar";

                    VOMITINGLable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 80, 219, 85, false);
                    VOMITINGLable11.Name = "VOMITINGLable11";
                    VOMITINGLable11.TextFont.Size = 9;
                    VOMITINGLable11.TextFont.Bold = true;
                    VOMITINGLable11.TextFont.CharSet = 162;
                    VOMITINGLable11.Value = @"Kusma";

                    NAMELable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 80, 70, 85, false);
                    NAMELable11.Name = "NAMELable11";
                    NAMELable11.TextFont.Size = 9;
                    NAMELable11.TextFont.Bold = true;
                    NAMELable11.TextFont.CharSet = 162;
                    NAMELable11.Value = @"Sıvı";

                    INTOTALLable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 80, 159, 85, false);
                    INTOTALLable11.Name = "INTOTALLable11";
                    INTOTALLable11.TextFont.Size = 9;
                    INTOTALLable11.TextFont.Bold = true;
                    INTOTALLable11.TextFont.CharSet = 162;
                    INTOTALLable11.Value = @"Toplam";

                    OUTTOTAL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 80, 249, 85, false);
                    OUTTOTAL111.Name = "OUTTOTAL111";
                    OUTTOTAL111.TextFont.Size = 9;
                    OUTTOTAL111.TextFont.Bold = true;
                    OUTTOTAL111.TextFont.CharSet = 162;
                    OUTTOTAL111.Value = @"Toplam";

                    DENGELable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 80, 264, 85, false);
                    DENGELable11.Name = "DENGELable11";
                    DENGELable11.TextFont.Size = 9;
                    DENGELable11.TextFont.Bold = true;
                    DENGELable11.TextFont.CharSet = 162;
                    DENGELable11.Value = @"Denge";

                    DATELable11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 80, 19, 85, false);
                    DATELable11.Name = "DATELable11";
                    DATELable11.TextFont.Size = 9;
                    DATELable11.TextFont.Bold = true;
                    DATELable11.TextFont.CharSet = 162;
                    DATELable11.Value = @"Tarih";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 21, 276, 26, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFont.Name = "Courier New";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 30, 276, 35, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFont.Name = "Courier New";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    DATELable111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 80, 42, 85, false);
                    DATELable111.Name = "DATELable111";
                    DATELable111.TextFont.Size = 9;
                    DATELable111.TextFont.Bold = true;
                    DATELable111.TextFont.CharSet = 162;
                    DATELable111.Value = @"Saat Aralığı";

                    INTOTALLable111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 75, 159, 80, false);
                    INTOTALLable111.Name = "INTOTALLable111";
                    INTOTALLable111.TextFont.Size = 9;
                    INTOTALLable111.TextFont.Bold = true;
                    INTOTALLable111.TextFont.CharSet = 162;
                    INTOTALLable111.Value = @"Aldığı";

                    INTOTALLable1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 75, 249, 80, false);
                    INTOTALLable1111.Name = "INTOTALLable1111";
                    INTOTALLable1111.TextFont.Size = 9;
                    INTOTALLable1111.TextFont.Bold = true;
                    INTOTALLable1111.TextFont.CharSet = 162;
                    INTOTALLable1111.Value = @"Çıkardığı";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 42, 99, 47, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.ObjectDefName = "NursingApplication";
                    ADSOYAD.DataMember = "EPISODE.PATIENT.FullName";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{@TTOBJECTID@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 42, 36, 47, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Adı Soyadı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 43, 39, 47, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Courier New";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 48, 77, 52, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.ObjectDefName = "NursingApplication";
                    PROTOKOLNO.DataMember = "SUBEPISODE.INPATIENTADMISSION.QUARANTINEPROTOCOLNO";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{@TTOBJECTID@}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 48, 36, 52, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Protokol No";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 63, 125, 67, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{@STARTDATE@} / {@ENDDATE@}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 63, 36, 67, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.TextFont.CharSet = 162;
                    NewField1271.Value = @"Tarih";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 48, 39, 52, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Courier New";
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 63, 39, 67, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Courier New";
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    ODAYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 58, 125, 62, false);
                    ODAYATAK.Name = "ODAYATAK";
                    ODAYATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAYATAK.TextFormat = @"g";
                    ODAYATAK.TextFont.Size = 9;
                    ODAYATAK.TextFont.CharSet = 162;
                    ODAYATAK.Value = @"{%ODA%} / {%YATAK%}";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 58, 36, 62, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.TextFont.Size = 9;
                    NewField11721.TextFont.Bold = true;
                    NewField11721.TextFont.CharSet = 162;
                    NewField11721.Value = @"Oda/Yatak";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 58, 39, 62, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.TextFont.Name = "Courier New";
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @":";

                    SERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 53, 210, 57, false);
                    SERVIS.Name = "SERVIS";
                    SERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS.TextFont.Size = 9;
                    SERVIS.TextFont.CharSet = 162;
                    SERVIS.Value = @"{%KLINIK%} / {%ODAGRUBU%}";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 53, 36, 57, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.TextFont.Size = 9;
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"Servis/Oda Grubu";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 53, 39, 57, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.TextFont.Name = "Courier New";
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @":";

                    ODA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 44, 254, 48, false);
                    ODA.Name = "ODA";
                    ODA.Visible = EvetHayirEnum.ehHayir;
                    ODA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODA.ObjectDefName = "NursingApplication";
                    ODA.DataMember = "INPATIENTTREATMENTCLINICAPP.BASEINPATIENTADMISSION.ROOM.NAME";
                    ODA.TextFont.Size = 9;
                    ODA.TextFont.CharSet = 162;
                    ODA.Value = @"{@TTOBJECTID@}";

                    YATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 49, 254, 53, false);
                    YATAK.Name = "YATAK";
                    YATAK.Visible = EvetHayirEnum.ehHayir;
                    YATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATAK.ObjectDefName = "NursingApplication";
                    YATAK.DataMember = "INPATIENTTREATMENTCLINICAPP.BASEINPATIENTADMISSION.BED.NAME";
                    YATAK.TextFont.Size = 9;
                    YATAK.TextFont.CharSet = 162;
                    YATAK.Value = @"{@TTOBJECTID@}";

                    ALDIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 73, 144, 79, false);
                    ALDIGI.Name = "ALDIGI";
                    ALDIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ALDIGI.TextFont.Size = 9;
                    ALDIGI.TextFont.Bold = true;
                    ALDIGI.TextFont.CharSet = 162;
                    ALDIGI.Value = @"ALDIĞI";

                    CIGARDIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 73, 233, 79, false);
                    CIGARDIGI.Name = "CIGARDIGI";
                    CIGARDIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CIGARDIGI.TextFont.Size = 9;
                    CIGARDIGI.TextFont.Bold = true;
                    CIGARDIGI.TextFont.CharSet = 162;
                    CIGARDIGI.Value = @"ÇIKARDIĞI";

                    ODAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 39, 254, 43, false);
                    ODAGRUBU.Name = "ODAGRUBU";
                    ODAGRUBU.Visible = EvetHayirEnum.ehHayir;
                    ODAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAGRUBU.ObjectDefName = "NursingApplication";
                    ODAGRUBU.DataMember = "INPATIENTTREATMENTCLINICAPP.BASEINPATIENTADMISSION.ROOMGROUP.NAME";
                    ODAGRUBU.TextFont.Size = 9;
                    ODAGRUBU.TextFont.CharSet = 162;
                    ODAGRUBU.Value = @"{@TTOBJECTID@}";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 34, 254, 38, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.Visible = EvetHayirEnum.ehHayir;
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.ObjectDefName = "NursingApplication";
                    KLINIK.DataMember = "INPATIENTTREATMENTCLINICAPP.MASTERRESOURCE.NAME";
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    LOGO111.CalcValue = LOGO111.Value;
                    BLEEDINGLable11.CalcValue = BLEEDINGLable11.Value;
                    DRENLabel11.CalcValue = DRENLabel11.Value;
                    GAITALable11.CalcValue = GAITALable11.Value;
                    IVINFLable11.CalcValue = IVINFLable11.Value;
                    ORALLable11.CalcValue = ORALLable11.Value;
                    URETICLable11.CalcValue = URETICLable11.Value;
                    VOMITINGLable11.CalcValue = VOMITINGLable11.Value;
                    NAMELable11.CalcValue = NAMELable11.Value;
                    INTOTALLable11.CalcValue = INTOTALLable11.Value;
                    OUTTOTAL111.CalcValue = OUTTOTAL111.Value;
                    DENGELable11.CalcValue = DENGELable11.Value;
                    DATELable11.CalcValue = DATELable11.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    DATELable111.CalcValue = DATELable111.Value;
                    INTOTALLable111.CalcValue = INTOTALLable111.Value;
                    INTOTALLable1111.CalcValue = INTOTALLable1111.Value;
                    ADSOYAD.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ADSOYAD.PostFieldValueCalculation();
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    PROTOKOLNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROTOKOLNO.PostFieldValueCalculation();
                    NewField1221.CalcValue = NewField1221.Value;
                    TARIH.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString() + @" / " + MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    ODA.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ODA.PostFieldValueCalculation();
                    YATAK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    YATAK.PostFieldValueCalculation();
                    ODAYATAK.CalcValue = MyParentReport.HEADER.ODA.CalcValue + @" / " + MyParentReport.HEADER.YATAK.CalcValue;
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    KLINIK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    KLINIK.PostFieldValueCalculation();
                    ODAGRUBU.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ODAGRUBU.PostFieldValueCalculation();
                    SERVIS.CalcValue = MyParentReport.HEADER.KLINIK.CalcValue + @" / " + MyParentReport.HEADER.ODAGRUBU.CalcValue;
                    NewField112711.CalcValue = NewField112711.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    ALDIGI.CalcValue = ALDIGI.Value;
                    CIGARDIGI.CalcValue = CIGARDIGI.Value;
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField111,LOGO111,BLEEDINGLable11,DRENLabel11,GAITALable11,IVINFLable11,ORALLable11,URETICLable11,VOMITINGLable11,NAMELable11,INTOTALLable11,OUTTOTAL111,DENGELable11,DATELable11,STARTDATE,ENDDATE,DATELable111,INTOTALLable111,INTOTALLable1111,ADSOYAD,NewField121,NewField141,PROTOKOLNO,NewField1221,TARIH,NewField1271,NewField1141,NewField11411,ODA,YATAK,ODAYATAK,NewField11721,NewField111411,KLINIK,ODAGRUBU,SERVIS,NewField112711,NewField1114111,ALDIGI,CIGARDIGI,XXXXXXBASLIK111};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    DateTime datestart = Convert.ToDateTime(((NursingTakeInTakeOutReport)ParentReport).RuntimeParameters.STARTDATE.ToString());
            DateTime dateend =  Convert.ToDateTime(((NursingTakeInTakeOutReport)ParentReport).RuntimeParameters.ENDDATE.ToString());
            datestart =  (Convert.ToDateTime(datestart.ToString())).Date.AddHours(Convert.ToDateTime(datestart.ToString()).Hour);
            if (Convert.ToDateTime(dateend.ToString()).Minute > 0)
                dateend =  (Convert.ToDateTime(dateend.ToString())).Date.AddHours(Convert.ToDateTime(dateend.ToString()).Hour+1);
            else
                dateend =  (Convert.ToDateTime(dateend.ToString())).Date.AddHours(Convert.ToDateTime(dateend.ToString()).Hour);
            this.STARTDATE.CalcValue= datestart.ToString();
            this.ENDDATE.CalcValue= dateend.ToString();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingTakeInTakeOutReport MyParentReport
                {
                    get { return (NursingTakeInTakeOutReport)ParentReport; }
                }
                
                public TTReportField BLEEDINGDAYTOTAL1;
                public TTReportField DRENDAYTOTAL1;
                public TTReportField GAITADAYTOTAL1;
                public TTReportField IVINFDAYTOTAL1;
                public TTReportField ORALDAYTOTAL1;
                public TTReportField URETICDAYTOTAL1;
                public TTReportField VOMITINGDAYTOTAL1;
                public TTReportField INTOTALDAYTOTAL1;
                public TTReportField OUTTOTALDAYTOTAL1;
                public TTReportField DENGEDAYTOTAL1;
                public TTReportField TARIH111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                    BLEEDINGDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 2, 234, 7, false);
                    BLEEDINGDAYTOTAL1.Name = "BLEEDINGDAYTOTAL1";
                    BLEEDINGDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BLEEDINGDAYTOTAL1.Value = @"{@sumof(BLEEDING)@}";

                    DRENDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 2, 204, 7, false);
                    DRENDAYTOTAL1.Name = "DRENDAYTOTAL1";
                    DRENDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRENDAYTOTAL1.Value = @"{@sumof(DREN)@}";

                    GAITADAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 2, 189, 7, false);
                    GAITADAYTOTAL1.Name = "GAITADAYTOTAL1";
                    GAITADAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GAITADAYTOTAL1.Value = @"{@sumof(GAITA)@}";

                    IVINFDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 2, 129, 7, false);
                    IVINFDAYTOTAL1.Name = "IVINFDAYTOTAL1";
                    IVINFDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    IVINFDAYTOTAL1.Value = @"{@sumof(IVINF)@}";

                    ORALDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 2, 144, 7, false);
                    ORALDAYTOTAL1.Name = "ORALDAYTOTAL1";
                    ORALDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORALDAYTOTAL1.Value = @"{@sumof(ORAL)@}";

                    URETICDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 2, 174, 7, false);
                    URETICDAYTOTAL1.Name = "URETICDAYTOTAL1";
                    URETICDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    URETICDAYTOTAL1.Value = @"{@sumof(URETIC)@}";

                    VOMITINGDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 2, 219, 7, false);
                    VOMITINGDAYTOTAL1.Name = "VOMITINGDAYTOTAL1";
                    VOMITINGDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    VOMITINGDAYTOTAL1.Value = @"{@sumof(VOMITING)@}";

                    INTOTALDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 2, 159, 7, false);
                    INTOTALDAYTOTAL1.Name = "INTOTALDAYTOTAL1";
                    INTOTALDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    INTOTALDAYTOTAL1.Value = @"{@sumof(INTOTAL)@}";

                    OUTTOTALDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 2, 249, 7, false);
                    OUTTOTALDAYTOTAL1.Name = "OUTTOTALDAYTOTAL1";
                    OUTTOTALDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUTTOTALDAYTOTAL1.Value = @"{@sumof(OUTTOTAL)@}";

                    DENGEDAYTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 2, 265, 7, false);
                    DENGEDAYTOTAL1.Name = "DENGEDAYTOTAL1";
                    DENGEDAYTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DENGEDAYTOTAL1.Value = @"{@sumof(DENGE)@}";

                    TARIH111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 2, 112, 7, false);
                    TARIH111.Name = "TARIH111";
                    TARIH111.TextFormat = @"Short Date";
                    TARIH111.TextFont.Size = 9;
                    TARIH111.TextFont.Bold = true;
                    TARIH111.TextFont.CharSet = 162;
                    TARIH111.Value = @"TOPLAMI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BLEEDINGDAYTOTAL1.CalcValue = ParentGroup.FieldSums["BLEEDING"].Value.ToString();;
                    DRENDAYTOTAL1.CalcValue = ParentGroup.FieldSums["DREN"].Value.ToString();;
                    GAITADAYTOTAL1.CalcValue = ParentGroup.FieldSums["GAITA"].Value.ToString();;
                    IVINFDAYTOTAL1.CalcValue = ParentGroup.FieldSums["IVINF"].Value.ToString();;
                    ORALDAYTOTAL1.CalcValue = ParentGroup.FieldSums["ORAL"].Value.ToString();;
                    URETICDAYTOTAL1.CalcValue = ParentGroup.FieldSums["URETIC"].Value.ToString();;
                    VOMITINGDAYTOTAL1.CalcValue = ParentGroup.FieldSums["VOMITING"].Value.ToString();;
                    INTOTALDAYTOTAL1.CalcValue = ParentGroup.FieldSums["INTOTAL"].Value.ToString();;
                    OUTTOTALDAYTOTAL1.CalcValue = ParentGroup.FieldSums["OUTTOTAL"].Value.ToString();;
                    DENGEDAYTOTAL1.CalcValue = ParentGroup.FieldSums["DENGE"].Value.ToString();;
                    TARIH111.CalcValue = TARIH111.Value;
                    return new TTReportObject[] { BLEEDINGDAYTOTAL1,DRENDAYTOTAL1,GAITADAYTOTAL1,IVINFDAYTOTAL1,ORALDAYTOTAL1,URETICDAYTOTAL1,VOMITINGDAYTOTAL1,INTOTALDAYTOTAL1,OUTTOTALDAYTOTAL1,DENGEDAYTOTAL1,TARIH111};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class TARIHGROUPGroup : TTReportGroup
        {
            public NursingTakeInTakeOutReport MyParentReport
            {
                get { return (NursingTakeInTakeOutReport)ParentReport; }
            }

            new public TARIHGROUPGroupHeader Header()
            {
                return (TARIHGROUPGroupHeader)_header;
            }

            new public TARIHGROUPGroupFooter Footer()
            {
                return (TARIHGROUPGroupFooter)_footer;
            }

            public TTReportField BLEEDING { get {return Header().BLEEDING;} }
            public TTReportField DREN { get {return Header().DREN;} }
            public TTReportField GAITA { get {return Header().GAITA;} }
            public TTReportField IVINF { get {return Header().IVINF;} }
            public TTReportField ORAL { get {return Header().ORAL;} }
            public TTReportField URETIC { get {return Header().URETIC;} }
            public TTReportField VOMITING { get {return Header().VOMITING;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField INTOTAL { get {return Header().INTOTAL;} }
            public TTReportField OUTTOTAL { get {return Header().OUTTOTAL;} }
            public TTReportField DENGE { get {return Header().DENGE;} }
            public TTReportField HOURINTERVAL { get {return Header().HOURINTERVAL;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TARIHGROUPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TARIHGROUPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NursingTakeInTakeOut.GetByNursingApplication_Class>("GetByNursingApplication", NursingTakeInTakeOut.GetByNursingApplication((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TARIHGROUPGroupHeader(this);
                _footer = new TARIHGROUPGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TARIHGROUPGroupHeader : TTReportSection
            {
                public NursingTakeInTakeOutReport MyParentReport
                {
                    get { return (NursingTakeInTakeOutReport)ParentReport; }
                }
                
                public TTReportField BLEEDING;
                public TTReportField DREN;
                public TTReportField GAITA;
                public TTReportField IVINF;
                public TTReportField ORAL;
                public TTReportField URETIC;
                public TTReportField VOMITING;
                public TTReportField NAME;
                public TTReportField INTOTAL;
                public TTReportField OUTTOTAL;
                public TTReportField DENGE;
                public TTReportField HOURINTERVAL;
                public TTReportField ACTIONDATE; 
                public TARIHGROUPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BLEEDING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 2, 234, 7, false);
                    BLEEDING.Name = "BLEEDING";
                    BLEEDING.FieldType = ReportFieldTypeEnum.ftVariable;
                    BLEEDING.Value = @"{#BLEEDING#}";

                    DREN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 2, 204, 7, false);
                    DREN.Name = "DREN";
                    DREN.FieldType = ReportFieldTypeEnum.ftVariable;
                    DREN.Value = @"{#DREN#}";

                    GAITA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 2, 189, 7, false);
                    GAITA.Name = "GAITA";
                    GAITA.FieldType = ReportFieldTypeEnum.ftVariable;
                    GAITA.Value = @"{#GAITA#}";

                    IVINF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 2, 129, 7, false);
                    IVINF.Name = "IVINF";
                    IVINF.FieldType = ReportFieldTypeEnum.ftVariable;
                    IVINF.Value = @"{#IVINF#}";

                    ORAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 2, 144, 7, false);
                    ORAL.Name = "ORAL";
                    ORAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORAL.Value = @"{#ORAL#}";

                    URETIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 2, 174, 7, false);
                    URETIC.Name = "URETIC";
                    URETIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    URETIC.Value = @"{#URETIC#}";

                    VOMITING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 2, 219, 7, false);
                    VOMITING.Name = "VOMITING";
                    VOMITING.FieldType = ReportFieldTypeEnum.ftVariable;
                    VOMITING.Value = @"{#VOMITING#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 2, 112, 7, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    INTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 2, 159, 7, false);
                    INTOTAL.Name = "INTOTAL";
                    INTOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    INTOTAL.Value = @"(Convert.ToInt32(this.ORAL.CalcValue + """" == """" ? ""0"" : this.ORAL.CalcValue)+ Convert.ToInt32(this.IVINF.CalcValue + """" == """" ? ""0"" : this.IVINF.CalcValue)).ToString()";

                    OUTTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 2, 249, 7, false);
                    OUTTOTAL.Name = "OUTTOTAL";
                    OUTTOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    OUTTOTAL.Value = @"(Convert.ToInt32(this.URETIC.CalcValue + """" == """" ? ""0"" : this.URETIC.CalcValue)+Convert.ToInt32(this.VOMITING.CalcValue + """" == """" ? ""0"" : this.VOMITING.CalcValue)+Convert.ToInt32(this.GAITA.CalcValue + """" == """" ? ""0"" : this.GAITA.CalcValue)+Convert.ToInt32(this.DREN.CalcValue + """" == """" ? ""0"" : this.DREN.CalcValue)+Convert.ToInt32(this.BLEEDING.CalcValue + """" == """" ? ""0"" : this.BLEEDING.CalcValue)).ToString()";

                    DENGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 2, 264, 7, false);
                    DENGE.Name = "DENGE";
                    DENGE.FieldType = ReportFieldTypeEnum.ftExpression;
                    DENGE.Value = @"(Convert.ToInt32(this.INTOTAL.CalcValue + """" == """" ? ""0"" : this.INTOTAL.CalcValue)-Convert.ToInt32(this.OUTTOTAL.CalcValue + """" == """" ? ""0"" : this.OUTTOTAL.CalcValue)).ToString()";

                    HOURINTERVAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 45, 7, false);
                    HOURINTERVAL.Name = "HOURINTERVAL";
                    HOURINTERVAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOURINTERVAL.ObjectDefName = "HourIntervalEnum";
                    HOURINTERVAL.DataMember = "DISPLAYTEXT";
                    HOURINTERVAL.Value = @"{#HOURINTERVAL#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 25, 7, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingTakeInTakeOut.GetByNursingApplication_Class dataset_GetByNursingApplication = ParentGroup.rsGroup.GetCurrentRecord<NursingTakeInTakeOut.GetByNursingApplication_Class>(0);
                    BLEEDING.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Bleeding) : "");
                    DREN.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Dren) : "");
                    GAITA.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Gaita) : "");
                    IVINF.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.IVInf) : "");
                    ORAL.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Oral) : "");
                    URETIC.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Uretic) : "");
                    VOMITING.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Vomiting) : "");
                    NAME.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.Name) : "");
                    HOURINTERVAL.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.HourInterval) : "");
                    HOURINTERVAL.PostFieldValueCalculation();
                    ACTIONDATE.CalcValue = (dataset_GetByNursingApplication != null ? Globals.ToStringCore(dataset_GetByNursingApplication.ActionDate) : "");
                    INTOTAL.CalcValue = (Convert.ToInt32(this.ORAL.CalcValue + "" == "" ? "0" : this.ORAL.CalcValue)+ Convert.ToInt32(this.IVINF.CalcValue + "" == "" ? "0" : this.IVINF.CalcValue)).ToString();
                    OUTTOTAL.CalcValue = (Convert.ToInt32(this.URETIC.CalcValue + "" == "" ? "0" : this.URETIC.CalcValue)+Convert.ToInt32(this.VOMITING.CalcValue + "" == "" ? "0" : this.VOMITING.CalcValue)+Convert.ToInt32(this.GAITA.CalcValue + "" == "" ? "0" : this.GAITA.CalcValue)+Convert.ToInt32(this.DREN.CalcValue + "" == "" ? "0" : this.DREN.CalcValue)+Convert.ToInt32(this.BLEEDING.CalcValue + "" == "" ? "0" : this.BLEEDING.CalcValue)).ToString();
                    DENGE.CalcValue = (Convert.ToInt32(this.INTOTAL.CalcValue + "" == "" ? "0" : this.INTOTAL.CalcValue)-Convert.ToInt32(this.OUTTOTAL.CalcValue + "" == "" ? "0" : this.OUTTOTAL.CalcValue)).ToString();
                    return new TTReportObject[] { BLEEDING,DREN,GAITA,IVINF,ORAL,URETIC,VOMITING,NAME,HOURINTERVAL,ACTIONDATE,INTOTAL,OUTTOTAL,DENGE};
                }
            }
            public partial class TARIHGROUPGroupFooter : TTReportSection
            {
                public NursingTakeInTakeOutReport MyParentReport
                {
                    get { return (NursingTakeInTakeOutReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public TARIHGROUPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 264, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingTakeInTakeOut.GetByNursingApplication_Class dataset_GetByNursingApplication = ParentGroup.rsGroup.GetCurrentRecord<NursingTakeInTakeOut.GetByNursingApplication_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public TARIHGROUPGroup TARIHGROUP;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingTakeInTakeOutReport MyParentReport
            {
                get { return (NursingTakeInTakeOutReport)ParentReport; }
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
                public NursingTakeInTakeOutReport MyParentReport
                {
                    get { return (NursingTakeInTakeOutReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingTakeInTakeOutReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            TARIHGROUP = new TARIHGROUPGroup(HEADER,"TARIHGROUP");
            MAIN = new MAINGroup(TARIHGROUP,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hemşirelik İşlemi", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "NURSINGTAKEINTAKEOUTREPORT";
            Caption = "Hemşirelik İşlemleri Aldığı Çıkardığı Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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