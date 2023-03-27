
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
    /// K Çizelgesi Hasta Barkodu
    /// </summary>
    public partial class KScheduleBarcodeReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public KScheduleBarcodeReport MyParentReport
            {
                get { return (KScheduleBarcodeReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAMESURNAME1 { get {return Body().NAMESURNAME1;} }
            public TTReportField TCKNO { get {return Body().TCKNO;} }
            public TTReportField BARCODE { get {return Body().BARCODE;} }
            public TTReportField PROTOKOL { get {return Body().PROTOKOL;} }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField PATIENTID { get {return Body().PATIENTID;} }
            public TTReportField QUARANTIANO { get {return Body().QUARANTIANO;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField NAMESURNAME11 { get {return Body().NAMESURNAME11;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField MATERIALID { get {return Body().MATERIALID;} }
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
                list[0] = new TTReportNqlData<KSchedule.KScheduleMaterialBarcodeRQ_Class>("KScheduleMaterialBarcodeRQ", KSchedule.KScheduleMaterialBarcodeRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KScheduleBarcodeReport MyParentReport
                {
                    get { return (KScheduleBarcodeReport)ParentReport; }
                }
                
                public TTReportField NAMESURNAME1;
                public TTReportField TCKNO;
                public TTReportField BARCODE;
                public TTReportField PROTOKOL;
                public TTReportField NAMESURNAME;
                public TTReportField PATIENTID;
                public TTReportField QUARANTIANO;
                public TTReportField TCNO;
                public TTReportField NAMESURNAME11;
                public TTReportField MATERIAL;
                public TTReportField MATERIALID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 9, 34, 13, false);
                    NAMESURNAME1.Name = "NAMESURNAME1";
                    NAMESURNAME1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NAMESURNAME1.TextFont.Size = 5;
                    NAMESURNAME1.TextFont.Bold = true;
                    NAMESURNAME1.TextFont.CharSet = 162;
                    NAMESURNAME1.Value = @"ADI SOYADI :";

                    TCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 5, 34, 9, false);
                    TCKNO.Name = "TCKNO";
                    TCKNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKNO.TextFont.Size = 5;
                    TCKNO.TextFont.Bold = true;
                    TCKNO.TextFont.CharSet = 162;
                    TCKNO.Value = @"TC NO :";

                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 64, 24, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BARCODE.TextFont.Name = "Code39HalfInchTT-Regular";
                    BARCODE.TextFont.Size = 18;
                    BARCODE.TextFont.CharSet = 0;
                    BARCODE.Value = @"";

                    PROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 24, 34, 28, false);
                    PROTOKOL.Name = "PROTOKOL";
                    PROTOKOL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PROTOKOL.TextFont.Size = 5;
                    PROTOKOL.TextFont.Bold = true;
                    PROTOKOL.TextFont.CharSet = 162;
                    PROTOKOL.Value = @"PROT. NO :";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 9, 74, 13, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.TextFont.Size = 5;
                    NAMESURNAME.TextFont.Bold = true;
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 5, 113, 10, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.Visible = EvetHayirEnum.ehHayir;
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.TextFont.Size = 7;
                    PATIENTID.TextFont.CharSet = 162;
                    PATIENTID.Value = @"{#PATIENTID#}";

                    QUARANTIANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 24, 74, 28, false);
                    QUARANTIANO.Name = "QUARANTIANO";
                    QUARANTIANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTIANO.TextFont.Size = 5;
                    QUARANTIANO.TextFont.Bold = true;
                    QUARANTIANO.TextFont.CharSet = 162;
                    QUARANTIANO.Value = @"{#QUARANTIANO#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 5, 74, 9, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Size = 5;
                    TCNO.TextFont.Bold = true;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"";

                    NAMESURNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 13, 34, 17, false);
                    NAMESURNAME11.Name = "NAMESURNAME11";
                    NAMESURNAME11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NAMESURNAME11.TextFont.Size = 5;
                    NAMESURNAME11.TextFont.Bold = true;
                    NAMESURNAME11.TextFont.CharSet = 162;
                    NAMESURNAME11.Value = @"İLAÇ ADI :";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 13, 74, 17, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.TextFont.Size = 5;
                    MATERIAL.TextFont.Bold = true;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}";

                    MATERIALID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 12, 113, 17, false);
                    MATERIALID.Name = "MATERIALID";
                    MATERIALID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALID.ObjectDefName = "Material";
                    MATERIALID.DataMember = "BARCODE";
                    MATERIALID.Value = @"{#MATERIALID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.KScheduleMaterialBarcodeRQ_Class dataset_KScheduleMaterialBarcodeRQ = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.KScheduleMaterialBarcodeRQ_Class>(0);
                    NAMESURNAME1.CalcValue = NAMESURNAME1.Value;
                    TCKNO.CalcValue = TCKNO.Value;
                    BARCODE.CalcValue = @"";
                    PROTOKOL.CalcValue = PROTOKOL.Value;
                    NAMESURNAME.CalcValue = (dataset_KScheduleMaterialBarcodeRQ != null ? Globals.ToStringCore(dataset_KScheduleMaterialBarcodeRQ.Namesurname) : "");
                    PATIENTID.CalcValue = (dataset_KScheduleMaterialBarcodeRQ != null ? Globals.ToStringCore(dataset_KScheduleMaterialBarcodeRQ.PatientID) : "");
                    QUARANTIANO.CalcValue = (dataset_KScheduleMaterialBarcodeRQ != null ? Globals.ToStringCore(dataset_KScheduleMaterialBarcodeRQ.Quarantiano) : "");
                    TCNO.CalcValue = @"";
                    NAMESURNAME11.CalcValue = NAMESURNAME11.Value;
                    MATERIAL.CalcValue = (dataset_KScheduleMaterialBarcodeRQ != null ? Globals.ToStringCore(dataset_KScheduleMaterialBarcodeRQ.Material) : "");
                    MATERIALID.CalcValue = (dataset_KScheduleMaterialBarcodeRQ != null ? Globals.ToStringCore(dataset_KScheduleMaterialBarcodeRQ.Materialid) : "");
                    MATERIALID.PostFieldValueCalculation();
                    return new TTReportObject[] { NAMESURNAME1,TCKNO,BARCODE,PROTOKOL,NAMESURNAME,PATIENTID,QUARANTIANO,TCNO,NAMESURNAME11,MATERIAL,MATERIALID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            BindingList<Patient> patients = TTObjectClasses.Patient.GetPatientByPID(context, long.Parse(this.PATIENTID.CalcValue));
            
            if(!string.IsNullOrEmpty(MATERIALID.CalcValue))
               {
                   this.BARCODE.CalcValue =  MATERIALID.CalcValue ; //TC
               }
               else
                   this.BARCODE.CalcValue = "0000000000000";
               
               if (patients != null && patients.Count > 0)
               {
                   if (patients[0].UniqueRefNo != null)
                   {
                       this.TCNO.CalcValue =  patients[0].UniqueRefNo.Value.ToString(); //TC
                   }
               }
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

        public KScheduleBarcodeReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KSCHEDULEBARCODEREPORT";
            Caption = "K Çizelgesi Hasta Barkodu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 80;
            p_PageHeight = 30;
            DontUseWatermark = EvetHayirEnum.ehEvet;
            PreferredPrinter = "ZDesigner TLP 2844";
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