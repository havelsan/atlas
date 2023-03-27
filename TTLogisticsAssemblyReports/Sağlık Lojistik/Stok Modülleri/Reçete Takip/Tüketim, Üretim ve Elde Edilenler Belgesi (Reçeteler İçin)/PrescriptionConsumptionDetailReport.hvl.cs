
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
    /// Reçete Sarf Detayları
    /// </summary>
    public partial class PrescriptionConsumptionDetailReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PrescriptionConsumptionDetailReport MyParentReport
            {
                get { return (PrescriptionConsumptionDetailReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField ReportName11 { get {return Header().ReportName11;} }
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
                public PrescriptionConsumptionDetailReport MyParentReport
                {
                    get { return (PrescriptionConsumptionDetailReport)ParentReport; }
                }
                
                public TTReportField ReportName11; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 286, 24, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Size = 15;
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"REÇETE SARF DETAYLARI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName11.CalcValue = ReportName11.Value;
                    return new TTReportObject[] { ReportName11};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PrescriptionConsumptionDetailReport MyParentReport
                {
                    get { return (PrescriptionConsumptionDetailReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public PrescriptionConsumptionDetailReport MyParentReport
            {
                get { return (PrescriptionConsumptionDetailReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
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
                list[0] = new TTReportNqlData<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class>("GetPrescriptionConsumptionDetails", PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PrescriptionConsumptionDetailReport MyParentReport
                {
                    get { return (PrescriptionConsumptionDetailReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportField MATERIAL; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 9, 32, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.DrawWidth = 2;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İşlem Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 9, 57, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.DrawWidth = 2;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İşlem No";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 9, 93, 14, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.DrawWidth = 2;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İşlem ";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 9, 124, 14, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.DrawWidth = 2;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Reçete No";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 9, 193, 14, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.DrawWidth = 2;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Hasta Adı Soyadı";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 9, 262, 14, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.DrawWidth = 2;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Doktor Adı Soyadı";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 9, 280, 14, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.DrawWidth = 2;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Miktar";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 147, 7, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.ObjectDefName = "Material";
                    MATERIAL.DataMember = "NAME";
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 11;
                    MATERIAL.TextFont.Bold = true;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class dataset_GetPrescriptionConsumptionDetails = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    MATERIAL.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.Material) : "");
                    MATERIAL.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField1111,NewField11111,NewField111111,NewField1111111,MATERIAL};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PrescriptionConsumptionDetailReport MyParentReport
                {
                    get { return (PrescriptionConsumptionDetailReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionConsumptionDetailReport MyParentReport
            {
                get { return (PrescriptionConsumptionDetailReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField ACTIONDESCRIPTION { get {return Body().ACTIONDESCRIPTION;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DOCKTORFULLNAME { get {return Body().DOCKTORFULLNAME;} }
            public TTReportField PATIENFULLNAME { get {return Body().PATIENFULLNAME;} }
            public TTReportField PRESCRIPTIONNO { get {return Body().PRESCRIPTIONNO;} }
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

                PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class dataSet_GetPrescriptionConsumptionDetails = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class>(0);    
                return new object[] {(dataSet_GetPrescriptionConsumptionDetails==null ? null : dataSet_GetPrescriptionConsumptionDetails.Material)};
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
                public PrescriptionConsumptionDetailReport MyParentReport
                {
                    get { return (PrescriptionConsumptionDetailReport)ParentReport; }
                }
                
                public TTReportField ACTIONDATE;
                public TTReportField ACTIONDESCRIPTION;
                public TTReportField ACTIONID;
                public TTReportField AMOUNT;
                public TTReportField DOCKTORFULLNAME;
                public TTReportField PATIENFULLNAME;
                public TTReportField PRESCRIPTIONNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 32, 5, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.Value = @"{#PARTA.ACTIONDATE#}";

                    ACTIONDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 93, 5, false);
                    ACTIONDESCRIPTION.Name = "ACTIONDESCRIPTION";
                    ACTIONDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDESCRIPTION.Value = @"{#PARTA.ACTIONDESCRIPTION#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 57, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.Value = @"{#PARTA.ACTIONID#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 280, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#PARTA.AMOUNT#}";

                    DOCKTORFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 0, 262, 5, false);
                    DOCKTORFULLNAME.Name = "DOCKTORFULLNAME";
                    DOCKTORFULLNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCKTORFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCKTORFULLNAME.Value = @"{#PARTA.DOCKTORFULLNAME#}";

                    PATIENFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 193, 5, false);
                    PATIENFULLNAME.Name = "PATIENFULLNAME";
                    PATIENFULLNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENFULLNAME.Value = @"{#PARTA.PATIENFULLNAME#}";

                    PRESCRIPTIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 124, 5, false);
                    PRESCRIPTIONNO.Name = "PRESCRIPTIONNO";
                    PRESCRIPTIONNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PRESCRIPTIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONNO.Value = @"{#PARTA.PRESCRIPTIONNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class dataset_GetPrescriptionConsumptionDetails = MyParentReport.PARTA.rsGroup.GetCurrentRecord<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class>(0);
                    ACTIONDATE.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.ActionDate) : "");
                    ACTIONDESCRIPTION.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.ActionDescription) : "");
                    ACTIONID.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.ActionID) : "");
                    AMOUNT.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.Amount) : "");
                    DOCKTORFULLNAME.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.DocktorFullName) : "");
                    PATIENFULLNAME.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.PatienFullName) : "");
                    PRESCRIPTIONNO.CalcValue = (dataset_GetPrescriptionConsumptionDetails != null ? Globals.ToStringCore(dataset_GetPrescriptionConsumptionDetails.PrescriptionNo) : "");
                    return new TTReportObject[] { ACTIONDATE,ACTIONDESCRIPTION,ACTIONID,AMOUNT,DOCKTORFULLNAME,PATIENFULLNAME,PRESCRIPTIONNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PrescriptionConsumptionDetailReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Girin", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PRESCRIPTIONCONSUMPTIONDETAILREPORT";
            Caption = "Reçete Sarf Detayları";
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