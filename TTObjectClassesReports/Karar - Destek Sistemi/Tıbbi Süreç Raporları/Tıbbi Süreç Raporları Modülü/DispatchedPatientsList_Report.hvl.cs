
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
    /// Sevk Edilen Hastaların Listesi
    /// </summary>
    public partial class DispatchedPatientsList : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public DispatchedPatientsList MyParentReport
            {
                get { return (DispatchedPatientsList)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField Adi { get {return Header().Adi;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public DispatchedPatientsList MyParentReport
                {
                    get { return (DispatchedPatientsList)ParentReport; }
                }
                
                public TTReportField Adi;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField12; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    Adi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 30, 105, 36, false);
                    Adi.Name = "Adi";
                    Adi.DrawStyle = DrawStyleConstants.vbSolid;
                    Adi.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Adi.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Adi.TextFont.Size = 11;
                    Adi.TextFont.Bold = true;
                    Adi.TextFont.CharSet = 162;
                    Adi.Value = @"Adı Soyadı";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 30, 231, 36, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Sevk Edilen Dış Birim";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 30, 191, 36, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Sevk Edilen XXXXXX XXXXXX";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 30, 145, 36, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Sevk Eden Poliklinik";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 6, 204, 23, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Size = 14;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Sevk Edilen Hastaların Listesi";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 53, 36, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"TC Kimlik No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 30, 280, 36, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Sevk Gerekçesi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Adi.CalcValue = Adi.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { Adi,NewField2,NewField3,NewField4,NewField5,NewField6,NewField12};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public DispatchedPatientsList MyParentReport
                {
                    get { return (DispatchedPatientsList)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public DispatchedPatientsList MyParentReport
            {
                get { return (DispatchedPatientsList)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField DISPATCHEDRESOURCE { get {return Body().DISPATCHEDRESOURCE;} }
            public TTReportField DISPATCHEDXXXXXXRESOURCE { get {return Body().DISPATCHEDXXXXXXRESOURCE;} }
            public TTReportField DISPATCHERHOSPITAL { get {return Body().DISPATCHERHOSPITAL;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField REASONOFDISPATCH { get {return Body().REASONOFDISPATCH;} }
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
                list[0] = new TTReportNqlData<DispatchToOtherHospital.GetDispatchedPatientsNQL_Class>("GetDispatchedPatientsNQL2", DispatchToOtherHospital.GetDispatchedPatientsNQL((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public DispatchedPatientsList MyParentReport
                {
                    get { return (DispatchedPatientsList)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField DISPATCHEDRESOURCE;
                public TTReportField DISPATCHEDXXXXXXRESOURCE;
                public TTReportField DISPATCHERHOSPITAL;
                public TTReportField TCKIMLIKNO;
                public TTReportField REASONOFDISPATCH; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 105, 9, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#} {#SURNAME#}";

                    DISPATCHEDRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 0, 231, 9, false);
                    DISPATCHEDRESOURCE.Name = "DISPATCHEDRESOURCE";
                    DISPATCHEDRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISPATCHEDRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISPATCHEDRESOURCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DISPATCHEDRESOURCE.TextFont.CharSet = 162;
                    DISPATCHEDRESOURCE.Value = @"{#DISPATCHEDRESOURCE#}";

                    DISPATCHEDXXXXXXRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 191, 9, false);
                    DISPATCHEDXXXXXXRESOURCE.Name = "DISPATCHEDXXXXXXRESOURCE";
                    DISPATCHEDXXXXXXRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISPATCHEDXXXXXXRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISPATCHEDXXXXXXRESOURCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DISPATCHEDXXXXXXRESOURCE.TextFont.CharSet = 162;
                    DISPATCHEDXXXXXXRESOURCE.Value = @"{#DISPATCHEDXXXXXXRESOURCE#}";

                    DISPATCHERHOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 145, 9, false);
                    DISPATCHERHOSPITAL.Name = "DISPATCHERHOSPITAL";
                    DISPATCHERHOSPITAL.DrawStyle = DrawStyleConstants.vbSolid;
                    DISPATCHERHOSPITAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISPATCHERHOSPITAL.TextFont.CharSet = 162;
                    DISPATCHERHOSPITAL.Value = @"{#DISPATCHERHOSPITAL#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 53, 9, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    REASONOFDISPATCH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 280, 9, false);
                    REASONOFDISPATCH.Name = "REASONOFDISPATCH";
                    REASONOFDISPATCH.DrawStyle = DrawStyleConstants.vbSolid;
                    REASONOFDISPATCH.FieldType = ReportFieldTypeEnum.ftVariable;
                    REASONOFDISPATCH.ExpandTabs = EvetHayirEnum.ehEvet;
                    REASONOFDISPATCH.Value = @"{#REASONOFDISPATCH#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DispatchToOtherHospital.GetDispatchedPatientsNQL_Class dataset_GetDispatchedPatientsNQL2 = ParentGroup.rsGroup.GetCurrentRecord<DispatchToOtherHospital.GetDispatchedPatientsNQL_Class>(0);
                    NAME.CalcValue = (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.Name) : "") + @" " + (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.Surname) : "");
                    DISPATCHEDRESOURCE.CalcValue = (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.Dispatchedresource) : "");
                    DISPATCHEDXXXXXXRESOURCE.CalcValue = (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.DispatchedXXXXXXresource) : "");
                    DISPATCHERHOSPITAL.CalcValue = (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.Dispatcherhospital) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.Tckimlikno) : "");
                    REASONOFDISPATCH.CalcValue = (dataset_GetDispatchedPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetDispatchedPatientsNQL2.ReasonOfDispatch) : "");
                    return new TTReportObject[] { NAME,DISPATCHEDRESOURCE,DISPATCHEDXXXXXXRESOURCE,DISPATCHERHOSPITAL,TCKIMLIKNO,REASONOFDISPATCH};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DispatchedPatientsList()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "DISPATCHEDPATIENTSLIST";
            Caption = "Sevk Edilen Hastaların Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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