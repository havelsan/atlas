
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
    /// Radyoloji İstek Barkodu
    /// </summary>
    public partial class RadiologyRequestBarcode : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public RadiologyRequestBarcode MyParentReport
            {
                get { return (RadiologyRequestBarcode)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Uniquerefno { get {return Body().Uniquerefno;} }
            public TTReportField lbl113 { get {return Body().lbl113;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField lbl123 { get {return Body().lbl123;} }
            public TTReportField Test { get {return Body().Test;} }
            public TTReportField PtGroup { get {return Body().PtGroup;} }
            public TTReportField ReqDate { get {return Body().ReqDate;} }
            public TTReportField lbl1311 { get {return Body().lbl1311;} }
            public TTReportField PrtklNo { get {return Body().PrtklNo;} }
            public TTReportField lbl1312 { get {return Body().lbl1312;} }
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
                public RadiologyRequestBarcode MyParentReport
                {
                    get { return (RadiologyRequestBarcode)ParentReport; }
                }
                
                public TTReportField Uniquerefno;
                public TTReportField lbl113;
                public TTReportField NameSurname;
                public TTReportField lbl123;
                public TTReportField Test;
                public TTReportField PtGroup;
                public TTReportField ReqDate;
                public TTReportField lbl1311;
                public TTReportField PrtklNo;
                public TTReportField lbl1312; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    Uniquerefno = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 39, 4, false);
                    Uniquerefno.Name = "Uniquerefno";
                    Uniquerefno.FieldType = ReportFieldTypeEnum.ftVariable;
                    Uniquerefno.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Uniquerefno.TextFont.Size = 7;
                    Uniquerefno.TextFont.CharSet = 162;
                    Uniquerefno.Value = @"";

                    lbl113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 16, 4, false);
                    lbl113.Name = "lbl113";
                    lbl113.TextFont.Name = "Arial";
                    lbl113.TextFont.Size = 7;
                    lbl113.TextFont.Bold = true;
                    lbl113.TextFont.CharSet = 162;
                    lbl113.Value = @"TCKimlikNo:";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 4, 39, 8, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.FieldType = ReportFieldTypeEnum.ftVariable;
                    NameSurname.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NameSurname.TextFont.Size = 7;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"";

                    lbl123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 4, 16, 8, false);
                    lbl123.Name = "lbl123";
                    lbl123.TextFont.Name = "Arial";
                    lbl123.TextFont.Size = 7;
                    lbl123.TextFont.Bold = true;
                    lbl123.TextFont.CharSet = 162;
                    lbl123.Value = @"Adı Soyadı:";

                    Test = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 20, 39, 24, false);
                    Test.Name = "Test";
                    Test.FieldType = ReportFieldTypeEnum.ftVariable;
                    Test.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Test.TextFont.Size = 7;
                    Test.TextFont.CharSet = 162;
                    Test.Value = @"";

                    PtGroup = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 8, 39, 12, false);
                    PtGroup.Name = "PtGroup";
                    PtGroup.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PtGroup.TextFont.Size = 7;
                    PtGroup.TextFont.CharSet = 162;
                    PtGroup.Value = @"";

                    ReqDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 12, 39, 16, false);
                    ReqDate.Name = "ReqDate";
                    ReqDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReqDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    ReqDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReqDate.TextFont.Size = 7;
                    ReqDate.TextFont.CharSet = 162;
                    ReqDate.Value = @"";

                    lbl1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 12, 16, 16, false);
                    lbl1311.Name = "lbl1311";
                    lbl1311.TextFont.Name = "Arial";
                    lbl1311.TextFont.Size = 7;
                    lbl1311.TextFont.Bold = true;
                    lbl1311.TextFont.CharSet = 162;
                    lbl1311.Value = @"İstek Tarihi:";

                    PrtklNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 16, 39, 20, false);
                    PrtklNo.Name = "PrtklNo";
                    PrtklNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrtklNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PrtklNo.TextFont.Size = 7;
                    PrtklNo.TextFont.CharSet = 162;
                    PrtklNo.Value = @"";

                    lbl1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 16, 16, 20, false);
                    lbl1312.Name = "lbl1312";
                    lbl1312.TextFont.Name = "Arial";
                    lbl1312.TextFont.Size = 7;
                    lbl1312.TextFont.Bold = true;
                    lbl1312.TextFont.CharSet = 162;
                    lbl1312.Value = @"ProtokolNo:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Uniquerefno.CalcValue = @"";
                    lbl113.CalcValue = lbl113.Value;
                    NameSurname.CalcValue = @"";
                    lbl123.CalcValue = lbl123.Value;
                    Test.CalcValue = @"";
                    PtGroup.CalcValue = PtGroup.Value;
                    ReqDate.CalcValue = @"";
                    lbl1311.CalcValue = lbl1311.Value;
                    PrtklNo.CalcValue = @"";
                    lbl1312.CalcValue = lbl1312.Value;
                    return new TTReportObject[] { Uniquerefno,lbl113,NameSurname,lbl123,Test,PtGroup,ReqDate,lbl1311,PrtklNo,lbl1312};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyRequestBarcode)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            
            string _nameSurname = string.Empty;
            
            RadiologyTest radTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            
            if(radTest.Episode.Patient != null)
            {
                if(radTest.Episode.Patient.UniqueRefNo.HasValue)
                    this.Uniquerefno.CalcValue = radTest.Episode.Patient.UniqueRefNo.Value.ToString();
                
                if(!String.IsNullOrEmpty(radTest.Episode.Patient.Name))
                {
                    _nameSurname += radTest.Episode.Patient.Name.Trim();
                }
                
                if(!String.IsNullOrEmpty(radTest.Episode.Patient.Surname))
                {
                    _nameSurname += " " +radTest.Episode.Patient.Surname.Trim();
                }
                
                this.NameSurname.CalcValue = _nameSurname.Trim();
                
                /*if(radTest.Episode.Patient.PatientGroup.HasValue)
                {
                    this.PtGroup.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(radTest.Episode.Patient.PatientGroup.Value);
                    
                }
                else
                {
                    this.PtGroup.CalcValue = string.Empty;
                }*/
            }
            
            if(radTest.ProcedureObject != null)
                this.Test.CalcValue = String.IsNullOrEmpty(radTest.ProcedureObject.Name) ? string.Empty : radTest.ProcedureObject.Name.Trim();
             
            this.ReqDate.CalcValue = radTest.RequestDate != null ? radTest.RequestDate.Value.ToString() : string.Empty;
            this.PrtklNo.CalcValue = radTest.EpisodeAction.Episode.HospitalProtocolNo.Value != null ? radTest.EpisodeAction.Episode.HospitalProtocolNo.Value.ToString() : string.Empty;
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

        public RadiologyRequestBarcode()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ActionID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RADIOLOGYREQUESTBARCODE";
            Caption = "Radyoloji İstek Barkodu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 40;
            p_PageHeight = 25;
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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