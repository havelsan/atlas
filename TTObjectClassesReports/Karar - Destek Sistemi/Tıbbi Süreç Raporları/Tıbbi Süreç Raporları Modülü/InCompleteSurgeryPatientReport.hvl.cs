
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
    /// Ameliyatı Tamamlanmamış Hastalar Raporu
    /// </summary>
    public partial class InCompleteSurgeryPatientReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public InCompleteSurgeryPatientReport MyParentReport
            {
                get { return (InCompleteSurgeryPatientReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField119 { get {return Header().NewField119;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField HASTAISIM { get {return Header().HASTAISIM;} }
            public TTReportField SORUMLUDOKTOR { get {return Header().SORUMLUDOKTOR;} }
            public TTReportField BIRIM { get {return Header().BIRIM;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField HOSPITALPROTNO { get {return Header().HOSPITALPROTNO;} }
            public TTReportField PrintDate1111 { get {return Footer().PrintDate1111;} }
            public TTReportField PageNumber1111 { get {return Footer().PageNumber1111;} }
            public TTReportField CurrentUser1111 { get {return Footer().CurrentUser1111;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public InCompleteSurgeryPatientReport MyParentReport
                {
                    get { return (InCompleteSurgeryPatientReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField16;
                public TTReportField NewField18;
                public TTReportField NewField181;
                public TTReportField NewField19;
                public TTReportField NewField119;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAISIM;
                public TTReportField SORUMLUDOKTOR;
                public TTReportField BIRIM;
                public TTReportField TARIH;
                public TTReportField HOSPITALPROTNO; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 76;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 28, 202, 34, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"AMELİYATI TAMAMLANMAMIŞ HASTALAR RAPORU";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 5, 186, 28, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 41, 47, 47, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"HİZMETE ÖZEL";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 49, 51, 54, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"Başlangıç Tarihi";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 49, 54, 54, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Size = 11;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 51, 59, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Bitiş Tarihi";

                    NewField119 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 54, 54, 59, false);
                    NewField119.Name = "NewField119";
                    NewField119.TextFont.Size = 11;
                    NewField119.TextFont.Bold = true;
                    NewField119.TextFont.CharSet = 162;
                    NewField119.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 49, 94, 54, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 54, 94, 59, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 70, 33, 75, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.TextFont.Bold = true;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"TC Kimlik No";

                    HASTAISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 70, 81, 75, false);
                    HASTAISIM.Name = "HASTAISIM";
                    HASTAISIM.TextFont.Size = 9;
                    HASTAISIM.TextFont.Bold = true;
                    HASTAISIM.TextFont.CharSet = 162;
                    HASTAISIM.Value = @"Hasta İsim Soyisim";

                    SORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 70, 274, 75, false);
                    SORUMLUDOKTOR.Name = "SORUMLUDOKTOR";
                    SORUMLUDOKTOR.TextFont.Size = 9;
                    SORUMLUDOKTOR.TextFont.Bold = true;
                    SORUMLUDOKTOR.TextFont.CharSet = 162;
                    SORUMLUDOKTOR.Value = @"Sorumlu Doktor";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 70, 217, 75, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.TextFont.Size = 9;
                    BIRIM.TextFont.Bold = true;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"Birim";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 70, 123, 75, false);
                    TARIH.Name = "TARIH";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.Bold = true;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"Tarih";

                    HOSPITALPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 70, 98, 75, false);
                    HOSPITALPROTNO.Name = "HOSPITALPROTNO";
                    HOSPITALPROTNO.TextFont.Size = 9;
                    HOSPITALPROTNO.TextFont.Bold = true;
                    HOSPITALPROTNO.TextFont.CharSet = 162;
                    HOSPITALPROTNO.Value = @"Prot No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField119.CalcValue = NewField119.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    TCKIMLIKNO.CalcValue = TCKIMLIKNO.Value;
                    HASTAISIM.CalcValue = HASTAISIM.Value;
                    SORUMLUDOKTOR.CalcValue = SORUMLUDOKTOR.Value;
                    BIRIM.CalcValue = BIRIM.Value;
                    TARIH.CalcValue = TARIH.Value;
                    HOSPITALPROTNO.CalcValue = HOSPITALPROTNO.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,NewField16,NewField18,NewField181,NewField19,NewField119,STARTDATE,ENDDATE,TCKIMLIKNO,HASTAISIM,SORUMLUDOKTOR,BIRIM,TARIH,HOSPITALPROTNO,XXXXXXBASLIK1};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public InCompleteSurgeryPatientReport MyParentReport
                {
                    get { return (InCompleteSurgeryPatientReport)ParentReport; }
                }
                
                public TTReportField PrintDate1111;
                public TTReportField PageNumber1111;
                public TTReportField CurrentUser1111;
                public TTReportShape NewLine111111; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 38, 7, false);
                    PrintDate1111.Name = "PrintDate1111";
                    PrintDate1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1111.TextFont.Size = 8;
                    PrintDate1111.TextFont.CharSet = 162;
                    PrintDate1111.Value = @"{@printdate@}";

                    PageNumber1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 2, 274, 7, false);
                    PageNumber1111.Name = "PageNumber1111";
                    PageNumber1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1111.TextFont.Size = 8;
                    PageNumber1111.TextFont.CharSet = 162;
                    PageNumber1111.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 2, 159, 7, false);
                    CurrentUser1111.Name = "CurrentUser1111";
                    CurrentUser1111.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1111.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1111.TextFont.Size = 8;
                    CurrentUser1111.TextFont.CharSet = 162;
                    CurrentUser1111.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 274, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1111.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1111.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1111.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1111,PageNumber1111,CurrentUser1111};
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public InCompleteSurgeryPatientReport MyParentReport
            {
                get { return (InCompleteSurgeryPatientReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField ISIM { get {return Body().ISIM;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField BIRIM { get {return Body().BIRIM;} }
            public TTReportField SORUMLUDOKTOR { get {return Body().SORUMLUDOKTOR;} }
            public TTReportField XXXXXXPROTNO { get {return Body().XXXXXXPROTNO;} }
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
                list[0] = new TTReportNqlData<Surgery.InCompleteSurgeryPatientListNQL_Class>("InCompleteSurgeryPatientListNQL2", Surgery.InCompleteSurgeryPatientListNQL((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
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
                public InCompleteSurgeryPatientReport MyParentReport
                {
                    get { return (InCompleteSurgeryPatientReport)ParentReport; }
                }
                
                public TTReportField TCKIMLIKNO;
                public TTReportField ISIM;
                public TTReportField TARIH;
                public TTReportField BIRIM;
                public TTReportField SORUMLUDOKTOR;
                public TTReportField XXXXXXPROTNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 33, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    ISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 81, 6, false);
                    ISIM.Name = "ISIM";
                    ISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISIM.MultiLine = EvetHayirEnum.ehEvet;
                    ISIM.NoClip = EvetHayirEnum.ehEvet;
                    ISIM.WordBreak = EvetHayirEnum.ehEvet;
                    ISIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISIM.Value = @"{#ISIM#} {#SOYISIM#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 1, 123, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.Value = @"{#PLANLANANTARIH#}";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 1, 217, 6, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM.NoClip = EvetHayirEnum.ehEvet;
                    BIRIM.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM.Value = @"{#BIRIM#}";

                    SORUMLUDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 1, 274, 6, false);
                    SORUMLUDOKTOR.Name = "SORUMLUDOKTOR";
                    SORUMLUDOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SORUMLUDOKTOR.MultiLine = EvetHayirEnum.ehEvet;
                    SORUMLUDOKTOR.NoClip = EvetHayirEnum.ehEvet;
                    SORUMLUDOKTOR.WordBreak = EvetHayirEnum.ehEvet;
                    SORUMLUDOKTOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    SORUMLUDOKTOR.Value = @"{#SORUMLUDOKTOR#}";

                    XXXXXXPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 1, 98, 6, false);
                    XXXXXXPROTNO.Name = "XXXXXXPROTNO";
                    XXXXXXPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXPROTNO.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXPROTNO.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXPROTNO.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXPROTNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXPROTNO.Value = @"{#XXXXXXPROTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.InCompleteSurgeryPatientListNQL_Class dataset_InCompleteSurgeryPatientListNQL2 = ParentGroup.rsGroup.GetCurrentRecord<Surgery.InCompleteSurgeryPatientListNQL_Class>(0);
                    TCKIMLIKNO.CalcValue = (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.Tckimlikno) : "");
                    ISIM.CalcValue = (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.Isim) : "") + @" " + (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.Soyisim) : "");
                    TARIH.CalcValue = (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.Planlanantarih) : "");
                    BIRIM.CalcValue = (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.Birim) : "");
                    SORUMLUDOKTOR.CalcValue = (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.Sorumludoktor) : "");
                    XXXXXXPROTNO.CalcValue = (dataset_InCompleteSurgeryPatientListNQL2 != null ? Globals.ToStringCore(dataset_InCompleteSurgeryPatientListNQL2.XXXXXXprotno) : "");
                    return new TTReportObject[] { TCKIMLIKNO,ISIM,TARIH,BIRIM,SORUMLUDOKTOR,XXXXXXPROTNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InCompleteSurgeryPatientReport()
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
            Name = "INCOMPLETESURGERYPATIENTREPORT";
            Caption = "Ameliyatı Tamamlanmamış Hastalar Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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