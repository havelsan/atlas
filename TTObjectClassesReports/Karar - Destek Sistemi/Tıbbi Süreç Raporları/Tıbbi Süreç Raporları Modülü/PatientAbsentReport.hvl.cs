
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
    public partial class PatientAbsentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? Tarih = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? POLICLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class headerGroup : TTReportGroup
        {
            public PatientAbsentReport MyParentReport
            {
                get { return (PatientAbsentReport)ParentReport; }
            }

            new public headerGroupHeader Header()
            {
                return (headerGroupHeader)_header;
            }

            new public headerGroupFooter Footer()
            {
                return (headerGroupFooter)_footer;
            }

            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField Adi111 { get {return Header().Adi111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public headerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public headerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new headerGroupHeader(this);
                _footer = new headerGroupFooter(this);

            }

            public partial class headerGroupHeader : TTReportSection
            {
                public PatientAbsentReport MyParentReport
                {
                    get { return (PatientAbsentReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField Adi111;
                public TTReportField NewField1111;
                public TTReportField NewField1161;
                public TTReportField NewField11111;
                public TTReportField NewField111111; 
                public headerGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 13, 162, 22, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Size = 14;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Muayeneye Aşamasında Kalan Hasta Listesi";

                    Adi111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 26, 74, 31, false);
                    Adi111.Name = "Adi111";
                    Adi111.DrawStyle = DrawStyleConstants.vbSolid;
                    Adi111.TextFont.Size = 9;
                    Adi111.TextFont.Bold = true;
                    Adi111.TextFont.CharSet = 162;
                    Adi111.Value = @"Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 26, 107, 31, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Soyadı";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 26, 42, 31, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"TC Kimlik No";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 26, 141, 31, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Protokol Numarası";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 26, 181, 31, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.TextFont.Size = 9;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Kabul Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField15.CalcValue = NewField15.Value;
                    Adi111.CalcValue = Adi111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField15,Adi111,NewField1111,NewField1161,NewField11111,NewField111111};
                }
            }
            public partial class headerGroupFooter : TTReportSection
            {
                public PatientAbsentReport MyParentReport
                {
                    get { return (PatientAbsentReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public headerGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 4, 134, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public headerGroup header;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientAbsentReport MyParentReport
            {
                get { return (PatientAbsentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<PatientExamination.GetPatientAbsentNQL_Class>("GetPatientAbsentNQL", PatientExamination.GetPatientAbsentNQL((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.Tarih),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.POLICLINIC)));
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
                public PatientAbsentReport MyParentReport
                {
                    get { return (PatientAbsentReport)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField UNIQUEREFNO;
                public TTReportField PROTOCOLNO;
                public TTReportField ACTIONDATE;
                public TTReportShape NewLine2;
                public TTReportShape NewLine6;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine7;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 74, 6, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 1, 107, 6, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.Value = @"{#SURNAME#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 42, 6, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 141, 6, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.Value = @"{#PROTOCOLNO#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 1, 180, 6, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 42, -4, 42, 6, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, -1, 12, 6, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 0, 74, 7, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 107, 7, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 0, 141, 7, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 181, -1, 181, 6, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 6, 181, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientExamination.GetPatientAbsentNQL_Class dataset_GetPatientAbsentNQL = ParentGroup.rsGroup.GetCurrentRecord<PatientExamination.GetPatientAbsentNQL_Class>(0);
                    NAME.CalcValue = (dataset_GetPatientAbsentNQL != null ? Globals.ToStringCore(dataset_GetPatientAbsentNQL.Name) : "");
                    SURNAME.CalcValue = (dataset_GetPatientAbsentNQL != null ? Globals.ToStringCore(dataset_GetPatientAbsentNQL.Surname) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetPatientAbsentNQL != null ? Globals.ToStringCore(dataset_GetPatientAbsentNQL.UniqueRefNo) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetPatientAbsentNQL != null ? Globals.ToStringCore(dataset_GetPatientAbsentNQL.ProtocolNo) : "");
                    ACTIONDATE.CalcValue = (dataset_GetPatientAbsentNQL != null ? Globals.ToStringCore(dataset_GetPatientAbsentNQL.ActionDate) : "");
                    return new TTReportObject[] { NAME,SURNAME,UNIQUEREFNO,PROTOCOLNO,ACTIONDATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PatientAbsentReport()
        {
            header = new headerGroup(this,"header");
            MAIN = new MAINGroup(header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("Tarih", "", "Tarih", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("POLICLINIC", "00000000-0000-0000-0000-000000000000", "Poliklinik", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cf0f9ec0-906f-4eab-8752-4c8f8e1aec48");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("Tarih"))
                _runtimeParameters.Tarih = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["Tarih"]);
            if (parameters.ContainsKey("POLICLINIC"))
                _runtimeParameters.POLICLINIC = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["POLICLINIC"]);
            Name = "PATIENTABSENTREPORT";
            Caption = "Muayeneye Gelmeyen Hastalar";
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