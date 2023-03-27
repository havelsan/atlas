
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
    /// İlaç Teslimi Raporu
    /// </summary>
    public partial class DrugDeliveryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugDeliveryReport MyParentReport
            {
                get { return (DrugDeliveryReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField HOSPITALCITY { get {return Header().HOSPITALCITY;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PATIENT { get {return Header().PATIENT;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField PRINTDATE { get {return Header().PRINTDATE;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
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
                list[0] = new TTReportNqlData<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>("GetDrugDeliveryReportQuery", DrugDeliveryAction.GetDrugDeliveryReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DrugDeliveryReport MyParentReport
                {
                    get { return (DrugDeliveryReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField HOSPITALNAME;
                public TTReportField HOSPITALCITY;
                public TTReportField NewField1;
                public TTReportField PATIENT;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField PRINTDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 93;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 18, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 12;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    HOSPITALCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 18, 170, 26, false);
                    HOSPITALCITY.Name = "HOSPITALCITY";
                    HOSPITALCITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCITY.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HOSPITALCITY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALCITY.TextFont.Name = "Arial";
                    HOSPITALCITY.TextFont.Size = 12;
                    HOSPITALCITY.TextFont.Bold = true;
                    HOSPITALCITY.TextFont.CharSet = 162;
                    HOSPITALCITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 56, 170, 61, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TUTANAKTIR";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 66, 170, 78, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENT.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENT.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENT.TextFont.Name = "Arial";
                    PATIENT.TextFont.Size = 11;
                    PATIENT.TextFont.CharSet = 162;
                    PATIENT.Value = @"       Aşağıda listesi bulunan ilaçlar {#NAME#} {#SURNAME#} adlı hastaya/hastanın yakınına teslim edilmiştir.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 83, 124, 89, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" İlaç Adı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 83, 170, 89, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Teslim Edilen Miktar ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 89, 124, 89, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 128, 89, 170, 89, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 46, 170, 51, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.TextFormat = @"dd/MM/yyyy";
                    PRINTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRINTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRINTDATE.NoClip = EvetHayirEnum.ehEvet;
                    PRINTDATE.TextFont.Name = "Arial";
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDeliveryAction.GetDrugDeliveryReportQuery_Class dataset_GetDrugDeliveryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>(0);
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    PATIENT.CalcValue = @"       Aşağıda listesi bulunan ilaçlar " + (dataset_GetDrugDeliveryReportQuery != null ? Globals.ToStringCore(dataset_GetDrugDeliveryReportQuery.Name) : "") + @" " + (dataset_GetDrugDeliveryReportQuery != null ? Globals.ToStringCore(dataset_GetDrugDeliveryReportQuery.Surname) : "") + @" adlı hastaya/hastanın yakınına teslim edilmiştir.";
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HOSPITALCITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField1,PATIENT,NewField12,NewField121,PRINTDATE,HOSPITALNAME,HOSPITALCITY};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DrugDeliveryReport MyParentReport
                {
                    get { return (DrugDeliveryReport)ParentReport; }
                }
                
                public TTReportField NewField122;
                public TTReportField NewField1121; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 100;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 50, 8, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Teslim Eden";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 2, 170, 8, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 11;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Teslim Alan";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDeliveryAction.GetDrugDeliveryReportQuery_Class dataset_GetDrugDeliveryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>(0);
                    NewField122.CalcValue = NewField122.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField122,NewField1121};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public DrugDeliveryReport MyParentReport
            {
                get { return (DrugDeliveryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUGNAME { get {return Body().DRUGNAME;} }
            public TTReportField RESDOSE { get {return Body().RESDOSE;} }
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

                DrugDeliveryAction.GetDrugDeliveryReportQuery_Class dataSet_GetDrugDeliveryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>(0);    
                return new object[] {(dataSet_GetDrugDeliveryReportQuery==null ? null : dataSet_GetDrugDeliveryReportQuery.ObjectID)};
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
                public DrugDeliveryReport MyParentReport
                {
                    get { return (DrugDeliveryReport)ParentReport; }
                }
                
                public TTReportField DRUGNAME;
                public TTReportField RESDOSE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 124, 6, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DRUGNAME.WordBreak = EvetHayirEnum.ehEvet;
                    DRUGNAME.TextFont.Name = "Arial";
                    DRUGNAME.TextFont.CharSet = 162;
                    DRUGNAME.Value = @" {#PARTA.DRUGNAME#}";

                    RESDOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 170, 6, false);
                    RESDOSE.Name = "RESDOSE";
                    RESDOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESDOSE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RESDOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESDOSE.TextFont.Name = "Arial";
                    RESDOSE.TextFont.CharSet = 162;
                    RESDOSE.Value = @"{#PARTA.RESDOSE#} ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDeliveryAction.GetDrugDeliveryReportQuery_Class dataset_GetDrugDeliveryReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<DrugDeliveryAction.GetDrugDeliveryReportQuery_Class>(0);
                    DRUGNAME.CalcValue = @" " + (dataset_GetDrugDeliveryReportQuery != null ? Globals.ToStringCore(dataset_GetDrugDeliveryReportQuery.DrugName) : "");
                    RESDOSE.CalcValue = (dataset_GetDrugDeliveryReportQuery != null ? Globals.ToStringCore(dataset_GetDrugDeliveryReportQuery.ResDose) : "") + @" ";
                    return new TTReportObject[] { DRUGNAME,RESDOSE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DrugDeliveryReport()
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
            Name = "DRUGDELIVERYREPORT";
            Caption = "İlaç Teslimi Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
            UserMarginTop = 25;
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