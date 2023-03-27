
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
    /// Eczaneye İlaç İade Raporu.
    /// </summary>
    public partial class DrugReturnReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugReturnReport MyParentReport
            {
                get { return (DrugReturnReport)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField DrugReturnReason { get {return Header().DrugReturnReason;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField ReturningClinic { get {return Header().ReturningClinic;} }
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
                list[0] = new TTReportNqlData<DrugReturnAction.GetDrugReturnReportQuery_Class>("GetDrugReturnReportQuery", DrugReturnAction.GetDrugReturnReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DrugReturnReport MyParentReport
                {
                    get { return (DrugReturnReport)ParentReport; }
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
                public TTReportField NewField2;
                public TTReportField DrugReturnReason;
                public TTReportField NewField13;
                public TTReportField ReturningClinic; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 110;
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

                    HOSPITALCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 38, 171, 46, false);
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
                    PATIENT.Value = @"       Aşağıda listesi bulunan ilaçlar {#NAME#} {#SURNAME#} adlı hastanın ilaçları Eczaneye teslim edilmiştir.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 102, 146, 108, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @" İlaç Adı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 102, 169, 108, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"T. Miktar ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 110, 146, 110, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 110, 170, 110, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 47, 170, 52, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.TextFormat = @"dd/MM/yyyy";
                    PRINTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRINTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRINTDATE.NoClip = EvetHayirEnum.ehEvet;
                    PRINTDATE.TextFont.Name = "Arial";
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 79, 25, 84, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"İADE NEDENİ :";

                    DrugReturnReason = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 79, 170, 90, false);
                    DrugReturnReason.Name = "DrugReturnReason";
                    DrugReturnReason.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugReturnReason.Value = @"{#DRUGRETURNREASON#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 95, 29, 100, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İADE EDEN KLİNİK:";

                    ReturningClinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 95, 170, 100, false);
                    ReturningClinic.Name = "ReturningClinic";
                    ReturningClinic.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningClinic.Value = @"{#CLINIC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugReturnAction.GetDrugReturnReportQuery_Class dataset_GetDrugReturnReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugReturnAction.GetDrugReturnReportQuery_Class>(0);
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    PATIENT.CalcValue = @"       Aşağıda listesi bulunan ilaçlar " + (dataset_GetDrugReturnReportQuery != null ? Globals.ToStringCore(dataset_GetDrugReturnReportQuery.Name) : "") + @" " + (dataset_GetDrugReturnReportQuery != null ? Globals.ToStringCore(dataset_GetDrugReturnReportQuery.Surname) : "") + @" adlı hastanın ilaçları Eczaneye teslim edilmiştir.";
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField2.CalcValue = NewField2.Value;
                    DrugReturnReason.CalcValue = (dataset_GetDrugReturnReportQuery != null ? Globals.ToStringCore(dataset_GetDrugReturnReportQuery.DrugReturnReason) : "");
                    NewField13.CalcValue = NewField13.Value;
                    ReturningClinic.CalcValue = (dataset_GetDrugReturnReportQuery != null ? Globals.ToStringCore(dataset_GetDrugReturnReportQuery.Clinic) : "");
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HOSPITALCITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField1,PATIENT,NewField12,NewField121,PRINTDATE,NewField2,DrugReturnReason,NewField13,ReturningClinic,HOSPITALNAME,HOSPITALCITY};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DrugReturnReport MyParentReport
                {
                    get { return (DrugReturnReport)ParentReport; }
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
                    DrugReturnAction.GetDrugReturnReportQuery_Class dataset_GetDrugReturnReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugReturnAction.GetDrugReturnReportQuery_Class>(0);
                    NewField122.CalcValue = NewField122.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField122,NewField1121};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public DrugReturnReport MyParentReport
            {
                get { return (DrugReturnReport)ParentReport; }
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

                DrugReturnAction.GetDrugReturnReportQuery_Class dataSet_GetDrugReturnReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugReturnAction.GetDrugReturnReportQuery_Class>(0);    
                return new object[] {(dataSet_GetDrugReturnReportQuery==null ? null : dataSet_GetDrugReturnReportQuery.ObjectID)};
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
                public DrugReturnReport MyParentReport
                {
                    get { return (DrugReturnReport)ParentReport; }
                }
                
                public TTReportField DRUGNAME;
                public TTReportField RESDOSE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 147, 8, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.WordBreak = EvetHayirEnum.ehEvet;
                    DRUGNAME.ObjectDefName = "Material";
                    DRUGNAME.DataMember = "NAME";
                    DRUGNAME.TextFont.CharSet = 162;
                    DRUGNAME.Value = @" {#PARTA.DRUGNAME#}";

                    RESDOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 1, 170, 8, false);
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
                    DrugReturnAction.GetDrugReturnReportQuery_Class dataset_GetDrugReturnReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<DrugReturnAction.GetDrugReturnReportQuery_Class>(0);
                    DRUGNAME.CalcValue = @" " + (dataset_GetDrugReturnReportQuery != null ? Globals.ToStringCore(dataset_GetDrugReturnReportQuery.Drugname) : "");
                    DRUGNAME.PostFieldValueCalculation();
                    RESDOSE.CalcValue = (dataset_GetDrugReturnReportQuery != null ? Globals.ToStringCore(dataset_GetDrugReturnReportQuery.Resdose) : "") + @" ";
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

        public DrugReturnReport()
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
            Name = "DRUGRETURNREPORT";
            Caption = "Eczaneye İlaç İade Raporu";
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