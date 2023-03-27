
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
    /// Fiziki Muayene Tebligat
    /// </summary>
    public partial class FizikiMuayeneTebligat : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public FizikiMuayeneTebligat MyParentReport
            {
                get { return (FizikiMuayeneTebligat)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseExamination.GetByObjcetID_Class>("GetByObjcetID", PurchaseExamination.GetByObjcetID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public FizikiMuayeneTebligat MyParentReport
                {
                    get { return (FizikiMuayeneTebligat)ParentReport; }
                }
                
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1;
                public TTReportRTF ReportRTF;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 125;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 190, 50, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 12;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 190, 43, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\nMUAYENE KOMİSYONU BAŞKANLIĞI""";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 35, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.Value = @"TASNİF DIŞI";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 52, 190, 107, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 121, 20, 126, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 121, 135, 126, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.Value = @"MUAYENESİ YAPILACAK MALZEME";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 121, 161, 126, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.Value = @"MİKTARI";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 121, 190, 126, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.Value = @"BİRİMİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\nMUAYENE KOMİSYONU BAŞKANLIĞI";
                    return new TTReportObject[] { NewField1,ReportRTF,NewField2,NewField12,NewField121,NewField1121,XXXXXXIL,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region PART1 HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((FizikiMuayeneTebligat)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination purchaseExamination = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            this.ReportRTF.Value = purchaseExamination.PhysicalInspectionNoticeText;
#endregion PART1 HEADER_PreScript
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public FizikiMuayeneTebligat MyParentReport
                {
                    get { return (FizikiMuayeneTebligat)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 35, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.Value = @"TASNİF DIŞI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public FizikiMuayeneTebligat MyParentReport
            {
                get { return (FizikiMuayeneTebligat)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField CNT { get {return Body().CNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
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
                list[0] = new TTReportNqlData<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class>("ExaminationDetailReportNQL", PurchaseExaminationDetail.ExaminationDetailReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public FizikiMuayeneTebligat MyParentReport
                {
                    get { return (FizikiMuayeneTebligat)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField MATERIALNAME;
                public TTReportField CNT;
                public TTReportField DISTRIBUTIONTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 161, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 135, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    CNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 20, 5, false);
                    CNT.Name = "CNT";
                    CNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CNT.Value = @"{@counter@}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 190, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExaminationDetail.ExaminationDetailReportNQL_Class dataset_ExaminationDetailReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class>(0);
                    AMOUNT.CalcValue = (dataset_ExaminationDetailReportNQL != null ? Globals.ToStringCore(dataset_ExaminationDetailReportNQL.Amount) : "");
                    MATERIALNAME.CalcValue = (dataset_ExaminationDetailReportNQL != null ? Globals.ToStringCore(dataset_ExaminationDetailReportNQL.Materialname) : "");
                    CNT.CalcValue = ParentGroup.Counter.ToString();
                    DISTRIBUTIONTYPE.CalcValue = (dataset_ExaminationDetailReportNQL != null ? Globals.ToStringCore(dataset_ExaminationDetailReportNQL.DistributionType) : "");
                    return new TTReportObject[] { AMOUNT,MATERIALNAME,CNT,DISTRIBUTIONTYPE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FizikiMuayeneTebligat()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9b2306a7-2381-4099-8a37-63dbae04c00e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FIZIKIMUAYENETEBLIGAT";
            Caption = "Fiziki Muayene Tebligat";
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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