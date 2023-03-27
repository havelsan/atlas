
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
    /// Ortez-Protez Kullanım Raporu
    /// </summary>
    public partial class OrthesisProsthesisUsageReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public OrthesisProsthesisUsageReport MyParentReport
            {
                get { return (OrthesisProsthesisUsageReport)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField BASHEKIM { get {return Header().BASHEKIM;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField XXXXXXBASLIK2 { get {return Header().XXXXXXBASLIK2;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField EVRAKNO { get {return Header().EVRAKNO;} }
            public TTReportField AD { get {return Header().AD;} }
            public TANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>("GetOrthesisProsthesisRequest", OrthesisProsthesisRequest.GetOrthesisProsthesisRequest((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANIGroupHeader(this);
                _footer = new TANIGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANIGroupHeader : TTReportSection
            {
                public OrthesisProsthesisUsageReport MyParentReport
                {
                    get { return (OrthesisProsthesisUsageReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField ACIKLAMA;
                public TTReportField ACTIONDATE;
                public TTReportField BASHEKIM;
                public TTReportField NewField21;
                public TTReportField XXXXXXBASLIK2;
                public TTReportField XXXXXXIL;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField NewField3;
                public TTReportField NewField14;
                public TTReportField EVRAKNO;
                public TTReportField AD; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 127;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 10, 205, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%XXXXXXBASLIK%}
{%XXXXXXIL%}

KULLANIM RAPORU";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 73, 201, 91, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.Value = @"Merkezimiz Ortez-Protez kısmında imal ve tatbik edilen aşağıdaki cihaz / cihazların {%NAME%} {%SURNAME%}'a teslim edildiği ve fonksiyonlarını yerine getirdiği tesbit edilmiştir.

Bilgilerinize arz ederim.";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 41, 197, 45, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"Short Date";
                    ACTIONDATE.Value = @"{#ISLEMTARIHI#}";

                    BASHEKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 96, 199, 113, false);
                    BASHEKIM.Name = "BASHEKIM";
                    BASHEKIM.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASHEKIM.MultiLine = EvetHayirEnum.ehEvet;
                    BASHEKIM.WordBreak = EvetHayirEnum.ehEvet;
                    BASHEKIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASHEKIM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"","""")";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 122, 32, 126, false);
                    NewField21.Name = "NewField21";
                    NewField21.Value = @"CİHAZLAR  :";

                    XXXXXXBASLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 15, 239, 20, false);
                    XXXXXXBASLIK2.Name = "XXXXXXBASLIK2";
                    XXXXXXBASLIK2.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK2.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK2.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 20, 239, 25, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 46, 237, 51, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "Patient";
                    NAME.DataMember = "NAME";
                    NAME.Value = @"{#PID#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 40, 237, 45, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.Value = @"{#PID#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 45, 39, 49, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"KONU         :";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 41, 39, 45, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"ORTEZ PROTEZ :";

                    EVRAKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 41, 153, 45, false);
                    EVRAKNO.Name = "EVRAKNO";
                    EVRAKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKNO.Value = @"{#ORTEZID#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 146, 49, false);
                    AD.Name = "AD";
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.MultiLine = EvetHayirEnum.ehEvet;
                    AD.NoClip = EvetHayirEnum.ehEvet;
                    AD.WordBreak = EvetHayirEnum.ehEvet;
                    AD.Value = @"{%NAME%} {%SURNAME%} Hk";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class dataset_GetOrthesisProsthesisRequest = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>(0);
                    XXXXXXBASLIK.CalcValue = MyParentReport.TANI.XXXXXXBASLIK.CalcValue + @"
" + MyParentReport.TANI.XXXXXXIL.CalcValue + @"

KULLANIM RAPORU";
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    NAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    NAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Pid) : "");
                    SURNAME.PostFieldValueCalculation();
                    ACIKLAMA.CalcValue = @"Merkezimiz Ortez-Protez kısmında imal ve tatbik edilen aşağıdaki cihaz / cihazların " + MyParentReport.TANI.NAME.CalcValue + @" " + MyParentReport.TANI.SURNAME.CalcValue + @"'a teslim edildiği ve fonksiyonlarını yerine getirdiği tesbit edilmiştir.

Bilgilerinize arz ederim.";
                    ACTIONDATE.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Islemtarihi) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    EVRAKNO.CalcValue = (dataset_GetOrthesisProsthesisRequest != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisRequest.Ortezid) : "");
                    AD.CalcValue = MyParentReport.TANI.NAME.CalcValue + @" " + MyParentReport.TANI.SURNAME.CalcValue + @" Hk";
                    BASHEKIM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","");
                    XXXXXXBASLIK2.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { XXXXXXBASLIK,XXXXXXIL,NAME,SURNAME,ACIKLAMA,ACTIONDATE,NewField21,NewField3,NewField14,EVRAKNO,AD,BASHEKIM,XXXXXXBASLIK2};
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public OrthesisProsthesisUsageReport MyParentReport
                {
                    get { return (OrthesisProsthesisUsageReport)ParentReport; }
                }
                 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TANIGroup TANI;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisUsageReport MyParentReport
            {
                get { return (OrthesisProsthesisUsageReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CIHAZ { get {return Body().CIHAZ;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
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
                list[0] = new TTReportNqlData<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>("GetOrthesisProsthesisProcedureByAction", OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OrthesisProsthesisUsageReport MyParentReport
                {
                    get { return (OrthesisProsthesisUsageReport)ParentReport; }
                }
                
                public TTReportField CIHAZ;
                public TTReportField NewField3; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CIHAZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 126, 5, false);
                    CIHAZ.Name = "CIHAZ";
                    CIHAZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIHAZ.Value = @"{#PROCEDURECODE#} {#PROCEDURENAME#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 15, 5, false);
                    NewField3.Name = "NewField3";
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.Value = @"{@counter@}.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class dataset_GetOrthesisProsthesisProcedureByAction = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>(0);
                    CIHAZ.CalcValue = (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedurecode) : "") + @" " + (dataset_GetOrthesisProsthesisProcedureByAction != null ? Globals.ToStringCore(dataset_GetOrthesisProsthesisProcedureByAction.Procedurename) : "");
                    NewField3.CalcValue = ParentGroup.Counter.ToString() + @".";
                    return new TTReportObject[] { CIHAZ,NewField3};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OrthesisProsthesisUsageReport()
        {
            TANI = new TANIGroup(this,"TANI");
            MAIN = new MAINGroup(TANI,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ORTHESISPROSTHESISUSAGEREPORT";
            Caption = "Ortez-Protez Kullanım Raporu";
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
            fd.TextFont.Name = "Courier New";
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