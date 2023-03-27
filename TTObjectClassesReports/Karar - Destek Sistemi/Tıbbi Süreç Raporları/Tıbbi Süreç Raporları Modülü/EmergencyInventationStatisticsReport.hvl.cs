
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
    /// Acil Servis Tanılara Göre İstatistiği
    /// </summary>
    public partial class EmergencyInventationStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public List<string> DIAGNOSIS = new List<string>();
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? CLINICS = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public EmergencyInventationStatisticsReport MyParentReport
            {
                get { return (EmergencyInventationStatisticsReport)ParentReport; }
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
            public TTReportShape NewRect11 { get {return Header().NewRect11;} }
            public TTReportShape NewRect111 { get {return Header().NewRect111;} }
            public TTReportShape NewRect1111 { get {return Header().NewRect1111;} }
            public TTReportShape NewRect1211 { get {return Header().NewRect1211;} }
            public TTReportField NAMESURNAME1 { get {return Header().NAMESURNAME1;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField TCKIMLIKNO1 { get {return Header().TCKIMLIKNO1;} }
            public TTReportField DOCTOR { get {return Header().DOCTOR;} }
            public TTReportShape NewRect11121 { get {return Header().NewRect11121;} }
            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportShape NewLine0 { get {return Footer().NewLine0;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public TTReportShape NewLine141 { get {return Footer().NewLine141;} }
            public TTReportShape NewLine151 { get {return Footer().NewLine151;} }
            public TTReportShape NewLine161 { get {return Footer().NewLine161;} }
            public TTReportShape NewLine1161 { get {return Footer().NewLine1161;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public EmergencyInventationStatisticsReport MyParentReport
                {
                    get { return (EmergencyInventationStatisticsReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportShape NewRect11;
                public TTReportShape NewRect111;
                public TTReportShape NewRect1111;
                public TTReportShape NewRect1211;
                public TTReportField NAMESURNAME1;
                public TTReportField MUAYENETARIHI;
                public TTReportField TCKIMLIKNO1;
                public TTReportField DOCTOR;
                public TTReportShape NewRect11121;
                public TTReportField TANI;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape NewRect1;
                public TTReportField NewField5;
                public TTReportField NewField6; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 6, 166, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"TANIYA GÖRE ACİL SERVİS KLİNİĞİ İSTATİSTİĞİ";

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 22, 30, 65, 36, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 65, 30, 91, 36, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 91, 30, 121, 36, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 121, 30, 160, 36, false);
                    NewRect1211.Name = "NewRect1211";
                    NewRect1211.DrawStyle = DrawStyleConstants.vbSolid;

                    NAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 31, 53, 36, false);
                    NAMESURNAME1.Name = "NAMESURNAME1";
                    NAMESURNAME1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAMESURNAME1.TextFont.Name = "Arial";
                    NAMESURNAME1.TextFont.Bold = true;
                    NAMESURNAME1.TextFont.CharSet = 162;
                    NAMESURNAME1.Value = @"Adı Soyadı";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 31, 120, 36, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    MUAYENETARIHI.TextFont.Name = "Arial";
                    MUAYENETARIHI.TextFont.Bold = true;
                    MUAYENETARIHI.TextFont.CharSet = 162;
                    MUAYENETARIHI.Value = @"Muayene Tarihi";

                    TCKIMLIKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 31, 90, 36, false);
                    TCKIMLIKNO1.Name = "TCKIMLIKNO1";
                    TCKIMLIKNO1.FillStyle = FillStyleConstants.vbFSTransparent;
                    TCKIMLIKNO1.TextFont.Name = "Arial";
                    TCKIMLIKNO1.TextFont.Bold = true;
                    TCKIMLIKNO1.TextFont.CharSet = 162;
                    TCKIMLIKNO1.Value = @"TC Kimlik No";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 31, 154, 36, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    DOCTOR.TextFont.Name = "Arial";
                    DOCTOR.TextFont.Bold = true;
                    DOCTOR.TextFont.CharSet = 162;
                    DOCTOR.Value = @"Dr. Adı Soyadı";

                    NewRect11121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 160, 30, 223, 36, false);
                    NewRect11121.Name = "NewRect11121";
                    NewRect11121.DrawStyle = DrawStyleConstants.vbSolid;

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 31, 198, 36, false);
                    TANI.Name = "TANI";
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.TextFont.Name = "Arial";
                    TANI.TextFont.Bold = true;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"Tanı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 22, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Tarih : ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 23, 39, 28, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFormat = @"dd/MM/yyyy";
                    NewField2.Value = @"{@STARTDATE@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 23, 67, 28, false);
                    NewField3.Name = "NewField3";
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.TextFormat = @"dd/MM/yyyy";
                    NewField3.Value = @"{@ENDDATE@}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 23, 42, 28, false);
                    NewField4.Name = "NewField4";
                    NewField4.Value = @" - ";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 8, 30, 22, 36, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 31, 21, 36, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Sıra No";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 30, 282, 36, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"H.Protokol No - Yattığı Servis";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NAMESURNAME1.CalcValue = NAMESURNAME1.Value;
                    MUAYENETARIHI.CalcValue = MUAYENETARIHI.Value;
                    TCKIMLIKNO1.CalcValue = TCKIMLIKNO1.Value;
                    DOCTOR.CalcValue = DOCTOR.Value;
                    TANI.CalcValue = TANI.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField3.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    return new TTReportObject[] { NewField11,NAMESURNAME1,MUAYENETARIHI,TCKIMLIKNO1,DOCTOR,TANI,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //this.Tanilar2.CalcValue =  this.DiagnoseCode.CalcValue + " " + this.Diagnose.CalcValue + "\n";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public EmergencyInventationStatisticsReport MyParentReport
                {
                    get { return (EmergencyInventationStatisticsReport)ParentReport; }
                }
                
                public TTReportShape NewLine0;
                public TTReportShape NewLine11;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine151;
                public TTReportShape NewLine161;
                public TTReportShape NewLine1161;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine0 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 3, 282, 3, false);
                    NewLine0.Name = "NewLine0";
                    NewLine0.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, -1, 8, 3, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 0, 65, 3, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 91, 0, 91, 3, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 121, 0, 121, 3, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine151.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 0, 160, 3, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 0, 223, 3, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, -1, 22, 3, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 282, 0, 282, 3, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public EmergencyInventationStatisticsReport MyParentReport
            {
                get { return (EmergencyInventationStatisticsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AdSoyad { get {return Body().AdSoyad;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportField EmergencyInvent { get {return Body().EmergencyInvent;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportShape NewLine1112 { get {return Body().NewLine1112;} }
            public TTReportShape NewLine1113 { get {return Body().NewLine1113;} }
            public TTReportShape NewLine1114 { get {return Body().NewLine1114;} }
            public TTReportField MuayeneTarihi { get {return Body().MuayeneTarihi;} }
            public TTReportField Doctor { get {return Body().Doctor;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportShape NewLine14111 { get {return Body().NewLine14111;} }
            public TTReportField Tanilar { get {return Body().Tanilar;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportShape NewLine1115 { get {return Body().NewLine1115;} }
            public TTReportField SiraNo { get {return Body().SiraNo;} }
            public TTReportField hprotocolclinic { get {return Body().hprotocolclinic;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class>("GetClinicStatisticsByDateDiagnosisAndPoliclinics", EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(MyParentReport.RuntimeParameters.CLINICS),(List<string>) MyParentReport.RuntimeParameters.DIAGNOSIS));
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
                public EmergencyInventationStatisticsReport MyParentReport
                {
                    get { return (EmergencyInventationStatisticsReport)ParentReport; }
                }
                
                public TTReportField AdSoyad;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportField EmergencyInvent;
                public TTReportField TC;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine1113;
                public TTReportShape NewLine1114;
                public TTReportField MuayeneTarihi;
                public TTReportField Doctor;
                public TTReportShape NewLine10;
                public TTReportShape NewLine14111;
                public TTReportField Tanilar;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportShape NewLine1115;
                public TTReportField SiraNo;
                public TTReportField hprotocolclinic;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    AdSoyad = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 1, 65, 9, false);
                    AdSoyad.Name = "AdSoyad";
                    AdSoyad.MultiLine = EvetHayirEnum.ehEvet;
                    AdSoyad.WordBreak = EvetHayirEnum.ehEvet;
                    AdSoyad.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, -2, 22, 17, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 1, 65, 20, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    EmergencyInvent = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 1, 325, 6, false);
                    EmergencyInvent.Name = "EmergencyInvent";
                    EmergencyInvent.Visible = EvetHayirEnum.ehHayir;
                    EmergencyInvent.FieldType = ReportFieldTypeEnum.ftVariable;
                    EmergencyInvent.Value = @"{#OBJECTID#}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 91, 9, false);
                    TC.Name = "TC";
                    TC.Value = @"";

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 91, 1, 91, 18, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 121, 0, 121, 19, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 0, 160, 19, false);
                    NewLine1114.Name = "NewLine1114";
                    NewLine1114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1114.ExtendTo = ExtendToEnum.extPageHeight;

                    MuayeneTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 121, 9, false);
                    MuayeneTarihi.Name = "MuayeneTarihi";
                    MuayeneTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    MuayeneTarihi.TextFormat = @"dd/MM/yyyy";
                    MuayeneTarihi.Value = @"{#REQUESTDATE#}";

                    Doctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 160, 9, false);
                    Doctor.Name = "Doctor";
                    Doctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    Doctor.Value = @"{#NAME#}";

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 282, 0, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, -2, 223, 17, false);
                    NewLine14111.Name = "NewLine14111";
                    NewLine14111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14111.ExtendTo = ExtendToEnum.extPageHeight;

                    Tanilar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 222, 9, false);
                    Tanilar.Name = "Tanilar";
                    Tanilar.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tanilar.MultiLine = EvetHayirEnum.ehEvet;
                    Tanilar.WordBreak = EvetHayirEnum.ehEvet;
                    Tanilar.Value = @"{#CODE#} - {#NAME#}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 3, 360, 8, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 3, 391, 8, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewLine1115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 19, false);
                    NewLine1115.Name = "NewLine1115";
                    NewLine1115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1115.ExtendTo = ExtendToEnum.extPageHeight;

                    SiraNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 21, 9, false);
                    SiraNo.Name = "SiraNo";
                    SiraNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    SiraNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SiraNo.Value = @"{@counter@}";

                    hprotocolclinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 1, 281, 9, false);
                    hprotocolclinic.Name = "hprotocolclinic";
                    hprotocolclinic.FieldType = ReportFieldTypeEnum.ftVariable;
                    hprotocolclinic.Value = @"{#HOSPITALPROTOCOLNO#} - {#BOLUM#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 282, -2, 282, 18, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class>(0);
                    AdSoyad.CalcValue = AdSoyad.Value;
                    EmergencyInvent.CalcValue = (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.ObjectID) : "");
                    TC.CalcValue = TC.Value;
                    MuayeneTarihi.CalcValue = (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.RequestDate) : "");
                    Doctor.CalcValue = (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.Name) : "");
                    Tanilar.CalcValue = (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.Code) : "") + @" - " + (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.Name) : "");
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    SiraNo.CalcValue = ParentGroup.Counter.ToString();
                    hprotocolclinic.CalcValue = (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.HospitalProtocolNo) : "") + @" - " + (dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics != null ? Globals.ToStringCore(dataset_GetClinicStatisticsByDateDiagnosisAndPoliclinics.Bolum) : "");
                    return new TTReportObject[] { AdSoyad,EmergencyInvent,TC,MuayeneTarihi,Doctor,Tanilar,STARTDATE,ENDDATE,SiraNo,hprotocolclinic};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    EpisodeAction episodeAction = (EpisodeAction)this.ParentReport.ReportObjectContext.GetObject(new Guid(this.EmergencyInvent.CalcValue), typeof(EpisodeAction));
           //emergencyIntervention.Episode.pat
           //  BindingList<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class> aa =  EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis(Convert.ToDateTime(this.STARTDATE.CalcValue), Convert.ToDateTime(this.ENDDATE.CalcValue), (((EmergencyInventationStatisticsReport)ParentReport).RuntimeParameters.DIAGNOSIS).ToString());
                    this.AdSoyad.CalcValue = episodeAction.Episode.Patient.Name + " " + episodeAction.Episode.Patient.Surname;
                    this.TC.CalcValue = episodeAction.Episode.Patient.Foreign == false ? (episodeAction.Episode.Patient.UniqueRefNo != null ? episodeAction.Episode.Patient.UniqueRefNo.ToString() : "") : " (*) " + (episodeAction.Episode.Patient.ForeignUniqueRefNo != null ? episodeAction.Episode.Patient.ForeignUniqueRefNo.ToString() : "");
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

        public EmergencyInventationStatisticsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DIAGNOSIS", "", "Tanılar", @"", true, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f438d7e5-bd84-472a-92ef-5b63f94cc57e");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CLINICS", "00000000-0000-0000-0000-000000000000", "Klinik", @"", false, true, false, new Guid("c0ae1e86-7d0f-412f-9366-d0199baae614"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DIAGNOSIS"))
                _runtimeParameters.DIAGNOSIS = (List<string>)parameters["DIAGNOSIS"];
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CLINICS"))
                _runtimeParameters.CLINICS = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(parameters["CLINICS"]);
            Name = "EMERGENCYINVENTATIONSTATISTICSREPORT";
            Caption = "Acil Servis Tanılara Göre İstatistiği";
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