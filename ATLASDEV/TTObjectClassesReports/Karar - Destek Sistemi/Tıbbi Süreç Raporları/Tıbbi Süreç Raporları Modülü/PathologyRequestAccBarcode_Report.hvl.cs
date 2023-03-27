
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
    /// Patoloji İstek Kabul Barkodu
    /// </summary>
    public partial class PathologyRequestAccBarcode : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyRequestAccBarcode MyParentReport
            {
                get { return (PathologyRequestAccBarcode)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField TCField { get {return Body().TCField;} }
            public TTReportField AdSoyadField { get {return Body().AdSoyadField;} }
            public TTReportField DogumField { get {return Body().DogumField;} }
            public TTReportField TabipField { get {return Body().TabipField;} }
            public TTReportField MatPrtField { get {return Body().MatPrtField;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField NewField103 { get {return Body().NewField103;} }
            public TTReportField NewField104 { get {return Body().NewField104;} }
            public TTReportField NewField105 { get {return Body().NewField105;} }
            public TTReportField BarcodeField { get {return Body().BarcodeField;} }
            public TTReportField MatPrtField2 { get {return Body().MatPrtField2;} }
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
                public PathologyRequestAccBarcode MyParentReport
                {
                    get { return (PathologyRequestAccBarcode)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField TCField;
                public TTReportField AdSoyadField;
                public TTReportField DogumField;
                public TTReportField TabipField;
                public TTReportField MatPrtField;
                public TTReportField NewField20;
                public TTReportField NewField102;
                public TTReportField NewField103;
                public TTReportField NewField104;
                public TTReportField NewField105;
                public TTReportField BarcodeField;
                public TTReportField MatPrtField2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 24;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 4, 16, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 5;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Ad Soyad";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 7, 16, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 5;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Doğum Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 16, 4, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 5;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"T.C. Kimlik Nu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 10, 16, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 5;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Sorumlu Tabip";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 13, 16, 16, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 5;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Materyal Prt No";

                    TCField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 39, 4, false);
                    TCField.Name = "TCField";
                    TCField.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCField.TextFont.Name = "Arial";
                    TCField.TextFont.Size = 5;
                    TCField.TextFont.CharSet = 162;
                    TCField.Value = @"";

                    AdSoyadField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 4, 39, 7, false);
                    AdSoyadField.Name = "AdSoyadField";
                    AdSoyadField.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdSoyadField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdSoyadField.TextFont.Name = "Arial";
                    AdSoyadField.TextFont.Size = 5;
                    AdSoyadField.TextFont.CharSet = 162;
                    AdSoyadField.Value = @"";

                    DogumField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 39, 10, false);
                    DogumField.Name = "DogumField";
                    DogumField.FieldType = ReportFieldTypeEnum.ftVariable;
                    DogumField.TextFormat = @"dd/MM/yyyy";
                    DogumField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DogumField.TextFont.Name = "Arial";
                    DogumField.TextFont.Size = 5;
                    DogumField.TextFont.CharSet = 162;
                    DogumField.Value = @"";

                    TabipField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 10, 39, 13, false);
                    TabipField.Name = "TabipField";
                    TabipField.FieldType = ReportFieldTypeEnum.ftVariable;
                    TabipField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TabipField.TextFont.Name = "Arial";
                    TabipField.TextFont.Size = 5;
                    TabipField.TextFont.CharSet = 162;
                    TabipField.Value = @"";

                    MatPrtField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 13, 39, 16, false);
                    MatPrtField.Name = "MatPrtField";
                    MatPrtField.FieldType = ReportFieldTypeEnum.ftVariable;
                    MatPrtField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MatPrtField.TextFont.Name = "Arial";
                    MatPrtField.TextFont.Size = 5;
                    MatPrtField.TextFont.CharSet = 162;
                    MatPrtField.Value = @"";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 18, 4, false);
                    NewField20.Name = "NewField20";
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Size = 6;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @":";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 4, 18, 7, false);
                    NewField102.Name = "NewField102";
                    NewField102.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField102.TextFont.Name = "Arial";
                    NewField102.TextFont.Size = 6;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @":";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 18, 10, false);
                    NewField103.Name = "NewField103";
                    NewField103.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField103.TextFont.Name = "Arial";
                    NewField103.TextFont.Size = 6;
                    NewField103.TextFont.CharSet = 162;
                    NewField103.Value = @":";

                    NewField104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 10, 18, 13, false);
                    NewField104.Name = "NewField104";
                    NewField104.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField104.TextFont.Name = "Arial";
                    NewField104.TextFont.Size = 6;
                    NewField104.TextFont.CharSet = 162;
                    NewField104.Value = @":";

                    NewField105 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 13, 18, 16, false);
                    NewField105.Name = "NewField105";
                    NewField105.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField105.TextFont.Name = "Arial";
                    NewField105.TextFont.Size = 6;
                    NewField105.TextFont.CharSet = 162;
                    NewField105.Value = @":";

                    BarcodeField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 16, 39, 21, false);
                    BarcodeField.Name = "BarcodeField";
                    BarcodeField.FieldType = ReportFieldTypeEnum.ftVariable;
                    BarcodeField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BarcodeField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BarcodeField.TextFont.Name = "Code39HalfInchTT-Regular";
                    BarcodeField.TextFont.Size = 11;
                    BarcodeField.TextFont.CharSet = 0;
                    BarcodeField.Value = @"";

                    MatPrtField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 21, 39, 24, false);
                    MatPrtField2.Name = "MatPrtField2";
                    MatPrtField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MatPrtField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MatPrtField2.TextFont.Name = "Arial";
                    MatPrtField2.TextFont.Size = 5;
                    MatPrtField2.TextFont.CharSet = 162;
                    MatPrtField2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    TCField.CalcValue = @"";
                    AdSoyadField.CalcValue = @"";
                    DogumField.CalcValue = @"";
                    TabipField.CalcValue = @"";
                    MatPrtField.CalcValue = @"";
                    NewField20.CalcValue = NewField20.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField104.CalcValue = NewField104.Value;
                    NewField105.CalcValue = NewField105.Value;
                    BarcodeField.CalcValue = @"";
                    MatPrtField2.CalcValue = @"";
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14,TCField,AdSoyadField,DogumField,TabipField,MatPrtField,NewField20,NewField102,NewField103,NewField104,NewField105,BarcodeField,MatPrtField2};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((PathologyRequestAccBarcode)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            
            string nameSurname = string.Empty;
            
            nameSurname += pathologyTest.Episode.Patient.Name == null ? string.Empty : pathologyTest.Episode.Patient.Name.Trim();
            nameSurname += " ";
            nameSurname += pathologyTest.Episode.Patient.Surname == null ? string.Empty : pathologyTest.Episode.Patient.Surname.Trim();
            this.AdSoyadField.CalcValue = nameSurname;
            
            this.TCField.CalcValue = pathologyTest.Episode.Patient.UniqueRefNo.HasValue == true ? pathologyTest.Episode.Patient.UniqueRefNo.Value.ToString() : string.Empty;
            this.DogumField.CalcValue = pathologyTest.Episode.Patient.BirthDate.HasValue == true ? pathologyTest.Episode.Patient.BirthDate.Value.ToString() : string.Empty;
            
            if(pathologyTest.ResponsibleDoctor != null)
            {
                this.TabipField.CalcValue = pathologyTest.ResponsibleDoctor.Name == null ? string.Empty : pathologyTest.ResponsibleDoctor.Name.Trim();
            }
            
            this.MatPrtField.CalcValue = pathologyTest.MatPrtNoString == null ? string.Empty : pathologyTest.MatPrtNoString.Trim();
            this.MatPrtField2.CalcValue = pathologyTest.MatPrtNoString == null ? string.Empty : pathologyTest.MatPrtNoString.Trim();
            this.BarcodeField.CalcValue = pathologyTest.MatPrtNoString == null ? string.Empty : pathologyTest.MatPrtNoString.Trim();
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

        public PathologyRequestAccBarcode()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "EpisodeActionObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYREQUESTACCBARCODE";
            Caption = "Patoloji İstek Kabul Barkodu";
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