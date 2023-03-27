
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
    /// Onaylama İşlemi Tamamlanan Rapor Listesi
    /// </summary>
    public partial class CompletedApprovalReportList : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CompletedApprovalReportList MyParentReport
            {
                get { return (CompletedApprovalReportList)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportField POBJECTID { get {return Header().POBJECTID;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
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
                public CompletedApprovalReportList MyParentReport
                {
                    get { return (CompletedApprovalReportList)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportShape NewLine;
                public TTReportField POBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 157, 18, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.MultiLine = EvetHayirEnum.ehEvet;
                    NewField.WordBreak = EvetHayirEnum.ehEvet;
                    NewField.TextFont.Size = 14;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"ONAYLAMA İŞLEMİ TAMAMLANAN RAPOR LİSTESİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 30, 22, 35, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Sıra";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 30, 64, 35, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İşlem No";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 30, 88, 35, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Episode";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 30, 45, 35, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Tarih";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 30, 116, 35, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Hasta No";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 30, 195, 35, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Hasta Adı";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 35, 195, 35, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    POBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 14, 242, 19, false);
                    POBJECTID.Name = "POBJECTID";
                    POBJECTID.Visible = EvetHayirEnum.ehHayir;
                    POBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    POBJECTID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    POBJECTID.CalcValue = @"";
                    return new TTReportObject[] { NewField,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,POBJECTID};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((CompletedApprovalReportList)ParentReport).RuntimeParameters.OBJECTID.ToString();
            SendingCheckedHealthCommitteeReport pObject = (SendingCheckedHealthCommitteeReport)context.GetObject(new Guid(sObjectID),"SendingCheckedHealthCommitteeReport");
            
            this.POBJECTID.Value = pObject.Episode.Patient.ObjectID.ToString();
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CompletedApprovalReportList MyParentReport
                {
                    get { return (CompletedApprovalReportList)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField PRINTDATE; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 195, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 13, 196, 18, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    return new TTReportObject[] { PRINTDATE};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CompletedApprovalReportList MyParentReport
            {
                get { return (CompletedApprovalReportList)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField ISLEMNO { get {return Body().ISLEMNO;} }
            public TTReportField EPISODE { get {return Body().EPISODE;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField ADI { get {return Body().ADI;} }
            public TTReportField SOYADI { get {return Body().SOYADI;} }
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
                list[0] = new TTReportNqlData<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class>("GetCheckingExternalHospitalHCReportsCompleted", CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.PARTA.POBJECTID.CalcValue)));
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
                public CompletedApprovalReportList MyParentReport
                {
                    get { return (CompletedApprovalReportList)ParentReport; }
                }
                
                public TTReportField NO;
                public TTReportField TARIH;
                public TTReportField ISLEMNO;
                public TTReportField EPISODE;
                public TTReportField HASTANO;
                public TTReportField HASTAADI;
                public TTReportField ADI;
                public TTReportField SOYADI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 22, 6, false);
                    NO.Name = "NO";
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NO.Value = @"{@counter@}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 1, 45, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.Value = @"{#ISLEMTARIHI#}";

                    ISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 64, 6, false);
                    ISLEMNO.Name = "ISLEMNO";
                    ISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMNO.TextFormat = @"Short Date";
                    ISLEMNO.Value = @"{#ISLEMNO#}";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 88, 6, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFormat = @"Short Date";
                    EPISODE.ObjectDefName = "Episode";
                    EPISODE.DataMember = "ID";
                    EPISODE.Value = @"{#EID#}";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 1, 116, 6, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFormat = @"Short Date";
                    HASTANO.ObjectDefName = "Patient";
                    HASTANO.DataMember = "ID";
                    HASTANO.Value = @"{#PATIENTOBJECTID#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 195, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.TextFormat = @"Short Date";
                    HASTAADI.Value = @"{%ADI%} {%SOYADI%}";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 231, 5, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.TextFormat = @"Short Date";
                    ADI.ObjectDefName = "Patient";
                    ADI.DataMember = "NAME";
                    ADI.Value = @"{#PATIENTOBJECTID#}";

                    SOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 248, 5, false);
                    SOYADI.Name = "SOYADI";
                    SOYADI.Visible = EvetHayirEnum.ehHayir;
                    SOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYADI.TextFormat = @"Short Date";
                    SOYADI.ObjectDefName = "Patient";
                    SOYADI.DataMember = "SURNAME";
                    SOYADI.Value = @"{#PATIENTOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class dataset_GetCheckingExternalHospitalHCReportsCompleted = ParentGroup.rsGroup.GetCurrentRecord<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class>(0);
                    NO.CalcValue = ParentGroup.Counter.ToString();
                    TARIH.CalcValue = (dataset_GetCheckingExternalHospitalHCReportsCompleted != null ? Globals.ToStringCore(dataset_GetCheckingExternalHospitalHCReportsCompleted.Islemtarihi) : "");
                    ISLEMNO.CalcValue = (dataset_GetCheckingExternalHospitalHCReportsCompleted != null ? Globals.ToStringCore(dataset_GetCheckingExternalHospitalHCReportsCompleted.Islemno) : "");
                    EPISODE.CalcValue = (dataset_GetCheckingExternalHospitalHCReportsCompleted != null ? Globals.ToStringCore(dataset_GetCheckingExternalHospitalHCReportsCompleted.Eid) : "");
                    EPISODE.PostFieldValueCalculation();
                    HASTANO.CalcValue = (dataset_GetCheckingExternalHospitalHCReportsCompleted != null ? Globals.ToStringCore(dataset_GetCheckingExternalHospitalHCReportsCompleted.Patientobjectid) : "");
                    HASTANO.PostFieldValueCalculation();
                    ADI.CalcValue = (dataset_GetCheckingExternalHospitalHCReportsCompleted != null ? Globals.ToStringCore(dataset_GetCheckingExternalHospitalHCReportsCompleted.Patientobjectid) : "");
                    ADI.PostFieldValueCalculation();
                    SOYADI.CalcValue = (dataset_GetCheckingExternalHospitalHCReportsCompleted != null ? Globals.ToStringCore(dataset_GetCheckingExternalHospitalHCReportsCompleted.Patientobjectid) : "");
                    SOYADI.PostFieldValueCalculation();
                    HASTAADI.CalcValue = MyParentReport.MAIN.ADI.FormattedValue + @" " + MyParentReport.MAIN.SOYADI.FormattedValue;
                    return new TTReportObject[] { NO,TARIH,ISLEMNO,EPISODE,HASTANO,ADI,SOYADI,HASTAADI};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CompletedApprovalReportList()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "", "ID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["OBJECTID"]);
            Name = "COMPLETEDAPPROVALREPORTLIST";
            Caption = "Onaylama İşlemi Tamamlanan Rapor Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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