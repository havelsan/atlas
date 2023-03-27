
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
    /// Yabancı Hasta Listesi (Ayaktan)
    /// </summary>
    public partial class ForeignPatientListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ForeignPatientListReport MyParentReport
            {
                get { return (ForeignPatientListReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField111211411 { get {return Header().NewField111211411;} }
            public TTReportField NewField1114112111 { get {return Header().NewField1114112111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1115111 { get {return Header().NewField1115111;} }
            public TTReportField NewField1117111 { get {return Header().NewField1117111;} }
            public TTReportField NewField1119111 { get {return Header().NewField1119111;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportField NewField11117111 { get {return Header().NewField11117111;} }
            public TTReportField NewField111171111 { get {return Header().NewField111171111;} }
            public TTReportField NewField111171112 { get {return Header().NewField111171112;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportShape NewLine11112 { get {return Footer().NewLine11112;} }
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
                public ForeignPatientListReport MyParentReport
                {
                    get { return (ForeignPatientListReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField NewField111211411;
                public TTReportField NewField1114112111;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1115111;
                public TTReportField NewField1117111;
                public TTReportField NewField1119111;
                public TTReportShape NewLine1111111;
                public TTReportField NewField11117111;
                public TTReportField NewField111171111;
                public TTReportField NewField111171112;
                public TTReportField XXXXXXBASLIK; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 206, 26, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"XXXXXXYE BAŞVURU YAPAN AYAKTAN YABANCI HASTA LİSTESİ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 32, 34, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.NoClip = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Tarih";

                    NewField111211411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 29, 34, 34, false);
                    NewField111211411.Name = "NewField111211411";
                    NewField111211411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211411.TextFont.Name = "Arial";
                    NewField111211411.TextFont.Size = 8;
                    NewField111211411.TextFont.Bold = true;
                    NewField111211411.TextFont.CharSet = 162;
                    NewField111211411.Value = @":";

                    NewField1114112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 29, 62, 34, false);
                    NewField1114112111.Name = "NewField1114112111";
                    NewField1114112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114112111.TextFont.Name = "Arial";
                    NewField1114112111.TextFont.Size = 8;
                    NewField1114112111.TextFont.CharSet = 162;
                    NewField1114112111.Value = @"-";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 29, 60, 34, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.TextFormat = @"Short Date";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"{@STARTDATE@}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 29, 102, 34, false);
                    NewField111.Name = "NewField111";
                    NewField111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField111.TextFormat = @"Short Date";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"{@ENDDATE@}";

                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 20, 44, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.TextFont.Name = "Arial";
                    NewField1115111.TextFont.Size = 8;
                    NewField1115111.TextFont.Bold = true;
                    NewField1115111.TextFont.CharSet = 162;
                    NewField1115111.Value = @"Sıra";

                    NewField1117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 40, 98, 44, false);
                    NewField1117111.Name = "NewField1117111";
                    NewField1117111.TextFont.Name = "Arial";
                    NewField1117111.TextFont.Size = 8;
                    NewField1117111.TextFont.Bold = true;
                    NewField1117111.TextFont.CharSet = 162;
                    NewField1117111.Value = @"Yabancı Kimlik No";

                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 40, 60, 44, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.TextFont.Name = "Arial";
                    NewField1119111.TextFont.Size = 8;
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.CharSet = 162;
                    NewField1119111.Value = @"Hasta Adı";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 45, 206, 45, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.DrawWidth = 2;

                    NewField11117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 40, 136, 44, false);
                    NewField11117111.Name = "NewField11117111";
                    NewField11117111.TextFont.Name = "Arial";
                    NewField11117111.TextFont.Size = 8;
                    NewField11117111.TextFont.Bold = true;
                    NewField11117111.TextFont.CharSet = 162;
                    NewField11117111.Value = @"YUPASS No";

                    NewField111171111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 40, 172, 44, false);
                    NewField111171111.Name = "NewField111171111";
                    NewField111171111.TextFont.Name = "Arial";
                    NewField111171111.TextFont.Size = 8;
                    NewField111171111.TextFont.Bold = true;
                    NewField111171111.TextFont.CharSet = 162;
                    NewField111171111.Value = @"Tarih";

                    NewField111171112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 40, 206, 44, false);
                    NewField111171112.Name = "NewField111171112";
                    NewField111171112.TextFont.Name = "Arial";
                    NewField111171112.TextFont.Size = 8;
                    NewField111171112.TextFont.Bold = true;
                    NewField111171112.TextFont.CharSet = 162;
                    NewField111171112.Value = @"H. Protokol No";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 206, 19, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField111211411.CalcValue = NewField111211411.Value;
                    NewField1114112111.CalcValue = NewField1114112111.Value;
                    NewField11.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField111.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField1117111.CalcValue = NewField1117111.Value;
                    NewField1119111.CalcValue = NewField1119111.Value;
                    NewField11117111.CalcValue = NewField11117111.Value;
                    NewField111171111.CalcValue = NewField111171111.Value;
                    NewField111171112.CalcValue = NewField111171112.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1111,NewField1121,NewField111211411,NewField1114112111,NewField11,NewField111,NewField1115111,NewField1117111,NewField1119111,NewField11117111,NewField111171111,NewField111171112,XXXXXXBASLIK};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ForeignPatientListReport MyParentReport
                {
                    get { return (ForeignPatientListReport)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1;
                public TTReportShape NewLine11112; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 116, 5, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 206, 5, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 206, 0, false);
                    NewLine11112.Name = "NewLine11112";
                    NewLine11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11112.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CurrentUser1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ForeignPatientListReport MyParentReport
            {
                get { return (ForeignPatientListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField YUPASSNO { get {return Body().YUPASSNO;} }
            public TTReportField FOREIGNUNIQUEREFNO { get {return Body().FOREIGNUNIQUEREFNO;} }
            public TTReportField SNO1 { get {return Body().SNO1;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField HPROTNO { get {return Body().HPROTNO;} }
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
                list[0] = new TTReportNqlData<PatientAdmission.GetForeignPatientsNQL_Class>("GetForeignPatientsNQL2", PatientAdmission.GetForeignPatientsNQL((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public ForeignPatientListReport MyParentReport
                {
                    get { return (ForeignPatientListReport)ParentReport; }
                }
                
                public TTReportField HASTAADI;
                public TTReportField YUPASSNO;
                public TTReportField FOREIGNUNIQUEREFNO;
                public TTReportField SNO1;
                public TTReportField TARIH;
                public TTReportField HPROTNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 60, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#ISIM#} {#SOYISIM#} ";

                    YUPASSNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 1, 136, 6, false);
                    YUPASSNO.Name = "YUPASSNO";
                    YUPASSNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    YUPASSNO.MultiLine = EvetHayirEnum.ehEvet;
                    YUPASSNO.NoClip = EvetHayirEnum.ehEvet;
                    YUPASSNO.WordBreak = EvetHayirEnum.ehEvet;
                    YUPASSNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    YUPASSNO.TextFont.Size = 8;
                    YUPASSNO.TextFont.CharSet = 162;
                    YUPASSNO.Value = @"{#YUPASSNO#}";

                    FOREIGNUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 1, 98, 6, false);
                    FOREIGNUNIQUEREFNO.Name = "FOREIGNUNIQUEREFNO";
                    FOREIGNUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUEREFNO.MultiLine = EvetHayirEnum.ehEvet;
                    FOREIGNUNIQUEREFNO.NoClip = EvetHayirEnum.ehEvet;
                    FOREIGNUNIQUEREFNO.WordBreak = EvetHayirEnum.ehEvet;
                    FOREIGNUNIQUEREFNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOREIGNUNIQUEREFNO.TextFont.Size = 8;
                    FOREIGNUNIQUEREFNO.TextFont.CharSet = 162;
                    FOREIGNUNIQUEREFNO.Value = @"{#FOREIGNUNIQUEREFNO#}";

                    SNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 20, 6, false);
                    SNO1.Name = "SNO1";
                    SNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO1.TextFont.Name = "Arial";
                    SNO1.TextFont.Size = 8;
                    SNO1.TextFont.CharSet = 162;
                    SNO1.Value = @"{@counter@}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 172, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#TARIH#}";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 1, 206, 6, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNO.MultiLine = EvetHayirEnum.ehEvet;
                    HPROTNO.NoClip = EvetHayirEnum.ehEvet;
                    HPROTNO.WordBreak = EvetHayirEnum.ehEvet;
                    HPROTNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HPROTNO.TextFont.Size = 8;
                    HPROTNO.TextFont.CharSet = 162;
                    HPROTNO.Value = @"{#HPROTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientAdmission.GetForeignPatientsNQL_Class dataset_GetForeignPatientsNQL2 = ParentGroup.rsGroup.GetCurrentRecord<PatientAdmission.GetForeignPatientsNQL_Class>(0);
                    HASTAADI.CalcValue = (dataset_GetForeignPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetForeignPatientsNQL2.Isim) : "") + @" " + (dataset_GetForeignPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetForeignPatientsNQL2.Soyisim) : "") + @" ";
                    YUPASSNO.CalcValue = (dataset_GetForeignPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetForeignPatientsNQL2.YUPASSNO) : "");
                    FOREIGNUNIQUEREFNO.CalcValue = (dataset_GetForeignPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetForeignPatientsNQL2.ForeignUniqueRefNo) : "");
                    SNO1.CalcValue = ParentGroup.Counter.ToString();
                    TARIH.CalcValue = (dataset_GetForeignPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetForeignPatientsNQL2.Tarih) : "");
                    HPROTNO.CalcValue = (dataset_GetForeignPatientsNQL2 != null ? Globals.ToStringCore(dataset_GetForeignPatientsNQL2.Hprotno) : "");
                    return new TTReportObject[] { HASTAADI,YUPASSNO,FOREIGNUNIQUEREFNO,SNO1,TARIH,HPROTNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ForeignPatientListReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "FOREIGNPATIENTLISTREPORT";
            Caption = "Yabancı Hasta Listesi (Ayaktan)";
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