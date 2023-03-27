
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
    /// Yatan Hasta Etiketi
    /// </summary>
    public partial class InPatientEtiquetteReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String_50"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public InPatientEtiquetteReport MyParentReport
            {
                get { return (InPatientEtiquetteReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField DOGUMTARIHI { get {return Body().DOGUMTARIHI;} }
            public TTReportField LBYATISTARIHI { get {return Body().LBYATISTARIHI;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField YATISTARIHI { get {return Body().YATISTARIHI;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetInPatientEtiquette_Class>("GetInPatientEtiquette", InpatientAdmission.GetInPatientEtiquette((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InPatientEtiquetteReport MyParentReport
                {
                    get { return (InPatientEtiquetteReport)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField NewField13;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField FULLNAME;
                public TTReportField TC;
                public TTReportField PROTOKOLNO;
                public TTReportField DOGUMTARIHI;
                public TTReportField LBYATISTARIHI;
                public TTReportField KLINIK;
                public TTReportField NewField2;
                public TTReportField YATISTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 22;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 3, 24, 6, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"NewField2";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 6, 24, 9, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"NewField2";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 9, 24, 12, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @"NewField2";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 12, 24, 15, false);
                    NewField171.Name = "NewField171";
                    NewField171.Value = @"NewField2";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 15, 24, 18, false);
                    NewField181.Name = "NewField181";
                    NewField181.Value = @"NewField2";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 18, 24, 21, false);
                    NewField191.Name = "NewField191";
                    NewField191.Value = @"NewField2";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 12, 36, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 5;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Doğum Tarihi/Yeri:";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 3, 28, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 6, 28, 9, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 9, 28, 12, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 12, 28, 15, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 15, 28, 18, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 18, 28, 21, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 3, 59, 6, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Arial";
                    FULLNAME.TextFont.Size = 5;
                    FULLNAME.TextFont.Bold = true;
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @"Adı Soyadı: {#AD#} {#SOYAD#}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 6, 59, 9, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.TextFont.Name = "Arial";
                    TC.TextFont.Size = 5;
                    TC.TextFont.Bold = true;
                    TC.TextFont.CharSet = 162;
                    TC.Value = @"Kimlik No: {#TC#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 9, 59, 12, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial";
                    PROTOKOLNO.TextFont.Size = 5;
                    PROTOKOLNO.TextFont.Bold = true;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"Hast./Tıbbi Kayıt Protokol No: {#PROTOKOLNO#} / {#TIBBIKAYITPROTOKOLNO#}";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 12, 50, 15, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"dd/MM/yyyy";
                    DOGUMTARIHI.TextFont.Name = "Arial";
                    DOGUMTARIHI.TextFont.Size = 5;
                    DOGUMTARIHI.TextFont.Bold = true;
                    DOGUMTARIHI.TextFont.CharSet = 162;
                    DOGUMTARIHI.Value = @"{#DOGUMTARIHI#}";

                    LBYATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 15, 35, 18, false);
                    LBYATISTARIHI.Name = "LBYATISTARIHI";
                    LBYATISTARIHI.TextFont.Name = "Arial";
                    LBYATISTARIHI.TextFont.Size = 5;
                    LBYATISTARIHI.TextFont.Bold = true;
                    LBYATISTARIHI.TextFont.CharSet = 162;
                    LBYATISTARIHI.Value = @"Yatış Tarihi:";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 18, 59, 21, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    KLINIK.NoClip = EvetHayirEnum.ehEvet;
                    KLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    KLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    KLINIK.TextFont.Name = "Arial";
                    KLINIK.TextFont.Size = 5;
                    KLINIK.TextFont.Bold = true;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"Klinik: {#KLINIK#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 12, 62, 15, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 5;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 0;
                    NewField2.Value = @"/{#DOGUMYERI#}";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 15, 59, 18, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    YATISTARIHI.TextFont.Name = "Arial";
                    YATISTARIHI.TextFont.Size = 5;
                    YATISTARIHI.TextFont.Bold = true;
                    YATISTARIHI.TextFont.CharSet = 162;
                    YATISTARIHI.Value = @"{#YATISTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInPatientEtiquette_Class dataset_GetInPatientEtiquette = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInPatientEtiquette_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    FULLNAME.CalcValue = @"Adı Soyadı: " + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Ad) : "") + @" " + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Soyad) : "");
                    TC.CalcValue = @"Kimlik No: " + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Tc) : "");
                    PROTOKOLNO.CalcValue = @"Hast./Tıbbi Kayıt Protokol No: " + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Protokolno) : "") + @" / " + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Tibbikayitprotokolno) : "");
                    DOGUMTARIHI.CalcValue = (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Dogumtarihi) : "");
                    LBYATISTARIHI.CalcValue = LBYATISTARIHI.Value;
                    KLINIK.CalcValue = @"Klinik: " + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Klinik) : "");
                    NewField2.CalcValue = @"/" + (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Dogumyeri) : "");
                    YATISTARIHI.CalcValue = (dataset_GetInPatientEtiquette != null ? Globals.ToStringCore(dataset_GetInPatientEtiquette.Yatistarihi) : "");
                    return new TTReportObject[] { NewField12,NewField151,NewField161,NewField171,NewField181,NewField191,NewField13,NewField1,NewField11,NewField14,NewField15,NewField16,NewField17,FULLNAME,TC,PROTOKOLNO,DOGUMTARIHI,LBYATISTARIHI,KLINIK,NewField2,YATISTARIHI};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InPatientEtiquetteReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("ad729221-77ee-47c8-9be2-c31ed6e2c1d1"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String_50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INPATIENTETIQUETTEREPORT";
            Caption = "Yatan Hasta Etiketi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 80;
            p_PageHeight = 30;
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