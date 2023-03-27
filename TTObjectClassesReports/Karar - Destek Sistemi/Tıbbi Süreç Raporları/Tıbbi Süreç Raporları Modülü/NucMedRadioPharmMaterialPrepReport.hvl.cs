
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
    /// Radyofarmasötik Madde Etiketi
    /// </summary>
    public partial class NucMedRadioPharmMaterialPrepReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public NucMedRadioPharmMaterialPrepReport MyParentReport
            {
                get { return (NucMedRadioPharmMaterialPrepReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField BIRTHDATE { get {return Header().BIRTHDATE;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public NucMedRadioPharmMaterialPrepReport MyParentReport
                {
                    get { return (NucMedRadioPharmMaterialPrepReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NAME;
                public TTReportField BIRTHDATE;
                public TTReportField NewField13;
                public TTReportField NewField121;
                public TTReportField SURNAME;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NAMESURNAME;
                public TTReportField UNIQUEREFNO;
                public TTReportField NewField3; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 5, 38, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Hasta Adı: ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 15, 38, 20, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Doğum Tarihi:";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 9, 238, 14, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "NuclearMedicine";
                    NAME.DataMember = "EPISODE.PATIENT.NAME";
                    NAME.Value = @"{@TTOBJECTID@}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 15, 64, 20, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.ObjectDefName = "NuclearMedicine";
                    BIRTHDATE.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    BIRTHDATE.Value = @"{@TTOBJECTID@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 21, 64, 26, false);
                    NewField13.Name = "NewField13";
                    NewField13.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.Underline = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Kullanılan Etken Maddeler:";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 10, 38, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"TC Kimlik No: ";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 14, 239, 19, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "NuclearMedicine";
                    SURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    SURNAME.Value = @"{@TTOBJECTID@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 38, 31, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Madde";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 26, 91, 31, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Doz";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 5, 64, 10, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.Value = @"{%NAME%} {%SURNAME%}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 10, 64, 15, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.ObjectDefName = "NuclearMedicine";
                    UNIQUEREFNO.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UNIQUEREFNO.Value = @"{@TTOBJECTID@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 26, 117, 31, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Tarih Saat";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    BIRTHDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BIRTHDATE.PostFieldValueCalculation();
                    NewField13.CalcValue = NewField13.Value;
                    NewField121.CalcValue = NewField121.Value;
                    SURNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SURNAME.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NAMESURNAME.CalcValue = MyParentReport.HEADER.NAME.CalcValue + @" " + MyParentReport.HEADER.SURNAME.CalcValue;
                    UNIQUEREFNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UNIQUEREFNO.PostFieldValueCalculation();
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField11,NewField12,NAME,BIRTHDATE,NewField13,NewField121,SURNAME,NewField1,NewField2,NAMESURNAME,UNIQUEREFNO,NewField3};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NucMedRadioPharmMaterialPrepReport MyParentReport
                {
                    get { return (NucMedRadioPharmMaterialPrepReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NucMedRadioPharmMaterialPrepReport MyParentReport
            {
                get { return (NucMedRadioPharmMaterialPrepReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATNAME { get {return Body().MATNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DATETIME { get {return Body().DATETIME;} }
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
                list[0] = new TTReportNqlData<NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class>("NucMedRadPharmMatRepNQL", NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NucMedRadioPharmMaterialPrepReport MyParentReport
                {
                    get { return (NucMedRadioPharmMaterialPrepReport)ParentReport; }
                }
                
                public TTReportField MATNAME;
                public TTReportField AMOUNT;
                public TTReportField DATETIME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    MATNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 63, 6, false);
                    MATNAME.Name = "MATNAME";
                    MATNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATNAME.Value = @"{#NAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 91, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DATETIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 120, 6, false);
                    DATETIME.Name = "DATETIME";
                    DATETIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIME.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    DATETIME.Value = @"{#ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class dataset_NucMedRadPharmMatRepNQL = ParentGroup.rsGroup.GetCurrentRecord<NucMedRadPharmMatGrid.NucMedRadPharmMatRepNQL_Class>(0);
                    MATNAME.CalcValue = (dataset_NucMedRadPharmMatRepNQL != null ? Globals.ToStringCore(dataset_NucMedRadPharmMatRepNQL.Name) : "");
                    AMOUNT.CalcValue = (dataset_NucMedRadPharmMatRepNQL != null ? Globals.ToStringCore(dataset_NucMedRadPharmMatRepNQL.Amount) : "");
                    DATETIME.CalcValue = (dataset_NucMedRadPharmMatRepNQL != null ? Globals.ToStringCore(dataset_NucMedRadPharmMatRepNQL.ActionDate) : "");
                    return new TTReportObject[] { MATNAME,AMOUNT,DATETIME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NucMedRadioPharmMaterialPrepReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NUCMEDRADIOPHARMMATERIALPREPREPORT";
            Caption = "Radyofarmasötik Madde Etiketi";
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