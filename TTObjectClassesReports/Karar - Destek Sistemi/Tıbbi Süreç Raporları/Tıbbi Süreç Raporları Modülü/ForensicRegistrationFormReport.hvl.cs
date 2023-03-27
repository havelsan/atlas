
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
    /// Adli Tıp Kayıt Formu
    /// </summary>
    public partial class ForensicRegistrationFormReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ForensicRegistrationFormReport MyParentReport
            {
                get { return (ForensicRegistrationFormReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField RAPORTIPI { get {return Header().RAPORTIPI;} }
            public TTReportField HIZMETEOZEL11 { get {return Footer().HIZMETEOZEL11;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ForensicMedicalReport.GetForensicMedicalReport_Class>("GetForensicMedicalReport", ForensicMedicalReport.GetForensicMedicalReport((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public ForensicRegistrationFormReport MyParentReport
                {
                    get { return (ForensicRegistrationFormReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField DATE;
                public TTReportField NewField101;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField KURUM;
                public TTReportShape NewLine1;
                public TTReportField RAPORTIPI; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 11, 169, 34, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Size = 11;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 37, 197, 42, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@printdate@}";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 37, 22, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"HİZMETE ÖZEL";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 12, 201, 17, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.TextFont.Name = "Courier New";
                    SITENAME.TextFont.CharSet = 162;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 18, 202, 23, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.TextFont.Name = "Courier New";
                    SITECITY.TextFont.CharSet = 162;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 25, 202, 30, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.TextFont.Name = "Courier New";
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 52, 197, 52, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 45, 129, 51, false);
                    RAPORTIPI.Name = "RAPORTIPI";
                    RAPORTIPI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTIPI.TextFont.Size = 11;
                    RAPORTIPI.TextFont.Bold = true;
                    RAPORTIPI.TextFont.CharSet = 162;
                    RAPORTIPI.Value = @"Adli Rapor";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = ParentGroup.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField101.CalcValue = NewField101.Value;
                    RAPORTIPI.CalcValue = RAPORTIPI.Value;
                    HEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { DATE,NewField101,RAPORTIPI,HEADER,SITENAME,SITECITY,KURUM};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ForensicRegistrationFormReport MyParentReport
                {
                    get { return (ForensicRegistrationFormReport)ParentReport; }
                }
                
                public TTReportField HIZMETEOZEL11; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HIZMETEOZEL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 39, 10, false);
                    HIZMETEOZEL11.Name = "HIZMETEOZEL11";
                    HIZMETEOZEL11.TextFont.Name = "Courier New";
                    HIZMETEOZEL11.TextFont.Underline = true;
                    HIZMETEOZEL11.TextFont.CharSet = 162;
                    HIZMETEOZEL11.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = ParentGroup.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    HIZMETEOZEL11.CalcValue = HIZMETEOZEL11.Value;
                    return new TTReportObject[] { HIZMETEOZEL11};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ForensicRegistrationFormReport MyParentReport
            {
                get { return (ForensicRegistrationFormReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF RegistationForm { get {return Body().RegistationForm;} }
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
                public ForensicRegistrationFormReport MyParentReport
                {
                    get { return (ForensicRegistrationFormReport)ParentReport; }
                }
                
                public TTReportRTF RegistationForm; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 82;
                    RepeatCount = 0;
                    
                    RegistationForm = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 11, 3, 197, 79, false);
                    RegistationForm.Name = "RegistationForm";
                    RegistationForm.CanExpand = EvetHayirEnum.ehHayir;
                    RegistationForm.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RegistationForm.CalcValue = RegistationForm.Value;
                    return new TTReportObject[] { RegistationForm};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ForensicRegistrationFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ForensicMedicalReport forensicMedicalReport = (ForensicMedicalReport)context.GetObject(new Guid(sObjectID),"ForensicMedicalReport");
            if(forensicMedicalReport.Report!=null)
                this.RegistationForm.Value = forensicMedicalReport.Report.ToString();
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ForensicRegistrationFormReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FORENSICREGISTRATIONFORMREPORT";
            Caption = "Adli Tıp Kayıt Formu";
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