
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
    /// Ayaktan Hasta Etiketi
    /// </summary>
    public partial class OutPatientEtiquetteReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String_50"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public OutPatientEtiquetteReport MyParentReport
            {
                get { return (OutPatientEtiquetteReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField POLIKLINIK { get {return Body().POLIKLINIK;} }
            public TTReportField DOGUMTARIHI { get {return Body().DOGUMTARIHI;} }
            public TTReportField VAKAACILISTARIHI2 { get {return Body().VAKAACILISTARIHI2;} }
            public TTReportField VAKAACILISTARIHI { get {return Body().VAKAACILISTARIHI;} }
            public TTReportField NewField11911 { get {return Body().NewField11911;} }
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
                list[0] = new TTReportNqlData<PatientAdmission.GetOutPatientEtiquette_Class>("GetOutPatientEtiquette", PatientAdmission.GetOutPatientEtiquette((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OutPatientEtiquetteReport MyParentReport
                {
                    get { return (OutPatientEtiquetteReport)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField NewField1191;
                public TTReportField NewField131;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField171;
                public TTReportField FULLNAME;
                public TTReportField TC;
                public TTReportField PROTOKOLNO;
                public TTReportField POLIKLINIK;
                public TTReportField DOGUMTARIHI;
                public TTReportField VAKAACILISTARIHI2;
                public TTReportField VAKAACILISTARIHI;
                public TTReportField NewField11911; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 22;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 7, 25, 10, false);
                    NewField121.Name = "NewField121";
                    NewField121.Value = @"NewField2";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 3, 24, 7, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.Value = @"NewField2";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 10, 25, 13, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"NewField2";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 13, 25, 16, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.Value = @"NewField2";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 16, 25, 19, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.Value = @"NewField2";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 13, 64, 16, false);
                    NewField131.Name = "NewField131";
                    NewField131.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 5;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Doğum Tarihi/Yeri:{%DOGUMTARIHI%}/{#DOGUMYERI#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 3, 25, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 4, 25, 7, false);
                    NewField111.Name = "NewField111";
                    NewField111.Value = @"";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 11, 25, 14, false);
                    NewField141.Name = "NewField141";
                    NewField141.Value = @"";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 13, 25, 16, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 16, 28, 19, false);
                    NewField171.Name = "NewField171";
                    NewField171.Value = @"";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 7, 64, 10, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Arial";
                    FULLNAME.TextFont.Size = 5;
                    FULLNAME.TextFont.Bold = true;
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @"Adı Soyadı: {#AD#} {#SOYAD#}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 3, 64, 7, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.TextFont.Bold = true;
                    TC.TextFont.CharSet = 162;
                    TC.Value = @"Kimlik No: {#TC#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 10, 64, 13, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial";
                    PROTOKOLNO.TextFont.Size = 5;
                    PROTOKOLNO.TextFont.Bold = true;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"Protokol No: {#PROTOKOLNO#}";

                    POLIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 16, 64, 19, false);
                    POLIKLINIK.Name = "POLIKLINIK";
                    POLIKLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    POLIKLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    POLIKLINIK.NoClip = EvetHayirEnum.ehEvet;
                    POLIKLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    POLIKLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    POLIKLINIK.TextFont.Name = "Arial";
                    POLIKLINIK.TextFont.Size = 5;
                    POLIKLINIK.TextFont.Bold = true;
                    POLIKLINIK.TextFont.CharSet = 162;
                    POLIKLINIK.Value = @"Klinik: {#NAME#}";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 6, 114, 9, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"dd/MM/yyyy";
                    DOGUMTARIHI.TextFont.Name = "Arial";
                    DOGUMTARIHI.TextFont.Size = 5;
                    DOGUMTARIHI.TextFont.Bold = true;
                    DOGUMTARIHI.TextFont.CharSet = 162;
                    DOGUMTARIHI.Value = @"{#DOGUMTARIHI#}";

                    VAKAACILISTARIHI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 19, 64, 22, false);
                    VAKAACILISTARIHI2.Name = "VAKAACILISTARIHI2";
                    VAKAACILISTARIHI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    VAKAACILISTARIHI2.TextFont.Name = "Arial";
                    VAKAACILISTARIHI2.TextFont.Size = 5;
                    VAKAACILISTARIHI2.TextFont.Bold = true;
                    VAKAACILISTARIHI2.TextFont.CharSet = 162;
                    VAKAACILISTARIHI2.Value = @"Vaka Açılış Tarihi: {%VAKAACILISTARIHI%}";

                    VAKAACILISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 11, 114, 14, false);
                    VAKAACILISTARIHI.Name = "VAKAACILISTARIHI";
                    VAKAACILISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    VAKAACILISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    VAKAACILISTARIHI.TextFormat = @"dd/MM/yyyy HH:mm";
                    VAKAACILISTARIHI.TextFont.Name = "Arial";
                    VAKAACILISTARIHI.TextFont.Size = 5;
                    VAKAACILISTARIHI.TextFont.Bold = true;
                    VAKAACILISTARIHI.TextFont.CharSet = 162;
                    VAKAACILISTARIHI.Value = @"{#OPENINGDATE#}";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 19, 25, 22, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.Value = @"NewField2";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientAdmission.GetOutPatientEtiquette_Class dataset_GetOutPatientEtiquette = ParentGroup.rsGroup.GetCurrentRecord<PatientAdmission.GetOutPatientEtiquette_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    DOGUMTARIHI.CalcValue = (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Dogumtarihi) : "");
                    NewField131.CalcValue = @"Doğum Tarihi/Yeri:" + MyParentReport.MAIN.DOGUMTARIHI.FormattedValue + @"/" + (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Dogumyeri) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField171.CalcValue = NewField171.Value;
                    FULLNAME.CalcValue = @"Adı Soyadı: " + (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Ad) : "") + @" " + (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Soyad) : "");
                    TC.CalcValue = @"Kimlik No: " + (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Tc) : "");
                    PROTOKOLNO.CalcValue = @"Protokol No: " + (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Protokolno) : "");
                    POLIKLINIK.CalcValue = @"Klinik: " + (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.Name) : "");
                    VAKAACILISTARIHI.CalcValue = (dataset_GetOutPatientEtiquette != null ? Globals.ToStringCore(dataset_GetOutPatientEtiquette.OpeningDate) : "");
                    VAKAACILISTARIHI2.CalcValue = @"Vaka Açılış Tarihi: " + MyParentReport.MAIN.VAKAACILISTARIHI.FormattedValue;
                    NewField11911.CalcValue = NewField11911.Value;
                    return new TTReportObject[] { NewField121,NewField1151,NewField1161,NewField1171,NewField1191,DOGUMTARIHI,NewField131,NewField11,NewField111,NewField141,NewField151,NewField171,FULLNAME,TC,PROTOKOLNO,POLIKLINIK,VAKAACILISTARIHI,VAKAACILISTARIHI2,NewField11911};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OutPatientEtiquetteReport()
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
            Name = "OUTPATIENTETIQUETTEREPORT";
            Caption = "Ayaktan Hasta Etiketi";
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