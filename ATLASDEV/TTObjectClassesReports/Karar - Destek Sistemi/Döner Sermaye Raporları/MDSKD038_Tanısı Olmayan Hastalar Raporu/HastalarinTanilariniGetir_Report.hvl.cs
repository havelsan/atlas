
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
    public partial class HastalarinTanilariniGetir : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HastalarinTanilariniGetir MyParentReport
            {
                get { return (HastalarinTanilariniGetir)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NameField { get {return Body().NameField;} }
            public TTReportField DoctorName { get {return Body().DoctorName;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField VakaName { get {return Body().VakaName;} }
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
                list[0] = new TTReportNqlData<DiagnosisGrid.QueryFatih_Class>("QueryFatih", DiagnosisGrid.QueryFatih());
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
                public HastalarinTanilariniGetir MyParentReport
                {
                    get { return (HastalarinTanilariniGetir)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NameField;
                public TTReportField DoctorName;
                public TTReportField NewField2;
                public TTReportField VakaName; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 52;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 4, 30, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Name:";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 12, 30, 17, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"Doctor Name:";

                    NameField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 4, 56, 9, false);
                    NameField.Name = "NameField";
                    NameField.FieldType = ReportFieldTypeEnum.ftVariable;
                    NameField.Value = @"{#NAME#}";

                    DoctorName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 12, 56, 17, false);
                    DoctorName.Name = "DoctorName";
                    DoctorName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DoctorName.Value = @"{#NAME1#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 19, 30, 24, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Vaka Tipi Adı";

                    VakaName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 19, 56, 24, false);
                    VakaName.Name = "VakaName";
                    VakaName.FieldType = ReportFieldTypeEnum.ftVariable;
                    VakaName.Value = @"{#ADI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.QueryFatih_Class dataset_QueryFatih = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.QueryFatih_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NameField.CalcValue = (dataset_QueryFatih != null ? Globals.ToStringCore(dataset_QueryFatih.Name) : "");
                    DoctorName.CalcValue = (dataset_QueryFatih != null ? Globals.ToStringCore(dataset_QueryFatih.Name1) : "");
                    NewField2.CalcValue = NewField2.Value;
                    VakaName.CalcValue = (dataset_QueryFatih != null ? Globals.ToStringCore(dataset_QueryFatih.ADI) : "");
                    return new TTReportObject[] { NewField1,NewField11,NameField,DoctorName,NewField2,VakaName};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HastalarinTanilariniGetir()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "HASTALARINTANILARINIGETIR";
            Caption = "HastalarinTanilariniGetir";
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