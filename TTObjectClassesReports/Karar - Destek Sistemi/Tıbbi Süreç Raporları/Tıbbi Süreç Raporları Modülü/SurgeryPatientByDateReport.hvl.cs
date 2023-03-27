
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
    /// Ameliyat Olacak Hastalar
    /// </summary>
    public partial class SurgeryPatientByDateReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? SURGERYROOM = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public SurgeryPatientByDateReport MyParentReport
            {
                get { return (SurgeryPatientByDateReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField91 { get {return Header().NewField91;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField6;
                public TTReportField LOGO;
                public TTReportField NewField8;
                public TTReportField NewField18;
                public TTReportField NewField9;
                public TTReportField NewField91;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 62;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 33, 156, 39, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"AMELİYAT OLACAK HASTALAR";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 10, 156, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 43, 45, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"LOGO";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 47, 52, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Başlangıç Tarihi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 47, 50, 52, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 47, 57, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Bitiş Tarihi";

                    NewField91 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 52, 50, 57, false);
                    NewField91.Name = "NewField91";
                    NewField91.TextFont.Size = 11;
                    NewField91.TextFont.Bold = true;
                    NewField91.TextFont.CharSet = 162;
                    NewField91.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 47, 90, 52, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Long Date";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 52, 90, 57, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Long Date";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField6.CalcValue = NewField6.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField91.CalcValue = NewField91.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField6,LOGO,NewField8,NewField18,NewField9,NewField91,STARTDATE,ENDDATE,XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class AmeliyathaneGroup : TTReportGroup
        {
            public SurgeryPatientByDateReport MyParentReport
            {
                get { return (SurgeryPatientByDateReport)ParentReport; }
            }

            new public AmeliyathaneGroupHeader Header()
            {
                return (AmeliyathaneGroupHeader)_header;
            }

            new public AmeliyathaneGroupFooter Footer()
            {
                return (AmeliyathaneGroupFooter)_footer;
            }

            public TTReportField AMELIYATHANE { get {return Header().AMELIYATHANE;} }
            public AmeliyathaneGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AmeliyathaneGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Surgery.SurgeryPatientByDateNQL_Class>("SurgeryPatientByDateNQL", Surgery.SurgeryPatientByDateNQL((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SURGERYROOM)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new AmeliyathaneGroupHeader(this);
                _footer = new AmeliyathaneGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class AmeliyathaneGroupHeader : TTReportSection
            {
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                
                public TTReportField AMELIYATHANE; 
                public AmeliyathaneGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    AMELIYATHANE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 216, 6, false);
                    AMELIYATHANE.Name = "AMELIYATHANE";
                    AMELIYATHANE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMELIYATHANE.ObjectDefName = "ResSurgeryDepartment";
                    AMELIYATHANE.DataMember = "NAME";
                    AMELIYATHANE.TextFont.Size = 11;
                    AMELIYATHANE.TextFont.Bold = true;
                    AMELIYATHANE.TextFont.CharSet = 162;
                    AMELIYATHANE.Value = @"{#AMELIYATHANE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryPatientByDateNQL_Class dataset_SurgeryPatientByDateNQL = ParentGroup.rsGroup.GetCurrentRecord<Surgery.SurgeryPatientByDateNQL_Class>(0);
                    AMELIYATHANE.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Ameliyathane) : "");
                    AMELIYATHANE.PostFieldValueCalculation();
                    return new TTReportObject[] { AMELIYATHANE};
                }
            }
            public partial class AmeliyathaneGroupFooter : TTReportSection
            {
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                 
                public AmeliyathaneGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public AmeliyathaneGroup Ameliyathane;

        public partial class AmeliyatSalonuGroup : TTReportGroup
        {
            public SurgeryPatientByDateReport MyParentReport
            {
                get { return (SurgeryPatientByDateReport)ParentReport; }
            }

            new public AmeliyatSalonuGroupHeader Header()
            {
                return (AmeliyatSalonuGroupHeader)_header;
            }

            new public AmeliyatSalonuGroupFooter Footer()
            {
                return (AmeliyatSalonuGroupFooter)_footer;
            }

            public TTReportField AMELIYATSALONU { get {return Header().AMELIYATSALONU;} }
            public TTReportField HASTAADI { get {return Header().HASTAADI;} }
            public TTReportField HASTASOYADI { get {return Header().HASTASOYADI;} }
            public TTReportField PROCEDUREDOCTORNAME { get {return Header().PROCEDUREDOCTORNAME;} }
            public TTReportField HASTAADI1 { get {return Header().HASTAADI1;} }
            public TTReportField HASTADOGUMTARIHI { get {return Header().HASTADOGUMTARIHI;} }
            public AmeliyatSalonuGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AmeliyatSalonuGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Surgery.SurgeryPatientByDateNQL_Class dataSet_SurgeryPatientByDateNQL = ParentGroup.rsGroup.GetCurrentRecord<Surgery.SurgeryPatientByDateNQL_Class>(0);    
                return new object[] {(dataSet_SurgeryPatientByDateNQL==null ? null : dataSet_SurgeryPatientByDateNQL.Ameliyathane)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new AmeliyatSalonuGroupHeader(this);
                _footer = new AmeliyatSalonuGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class AmeliyatSalonuGroupHeader : TTReportSection
            {
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                
                public TTReportField AMELIYATSALONU;
                public TTReportField HASTAADI;
                public TTReportField HASTASOYADI;
                public TTReportField PROCEDUREDOCTORNAME;
                public TTReportField HASTAADI1;
                public TTReportField HASTADOGUMTARIHI; 
                public AmeliyatSalonuGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    AMELIYATSALONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 2, 216, 7, false);
                    AMELIYATSALONU.Name = "AMELIYATSALONU";
                    AMELIYATSALONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMELIYATSALONU.ObjectDefName = "ResSurgeryRoom";
                    AMELIYATSALONU.DataMember = "NAME";
                    AMELIYATSALONU.TextFont.Size = 9;
                    AMELIYATSALONU.TextFont.Bold = true;
                    AMELIYATSALONU.TextFont.CharSet = 162;
                    AMELIYATSALONU.Value = @"{#Ameliyathane.AMELIYATSALONU#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 37, 13, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.TextFont.Size = 9;
                    HASTAADI.TextFont.Bold = true;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"Hasta Adı";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 8, 66, 13, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.TextFont.Size = 9;
                    HASTASOYADI.TextFont.Bold = true;
                    HASTASOYADI.TextFont.CharSet = 162;
                    HASTASOYADI.Value = @"Hasta Soyadı ";

                    PROCEDUREDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 8, 157, 13, false);
                    PROCEDUREDOCTORNAME.Name = "PROCEDUREDOCTORNAME";
                    PROCEDUREDOCTORNAME.TextFont.Size = 9;
                    PROCEDUREDOCTORNAME.TextFont.Bold = true;
                    PROCEDUREDOCTORNAME.TextFont.CharSet = 162;
                    PROCEDUREDOCTORNAME.Value = @"Doktor Adı";

                    HASTAADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 37, 7, false);
                    HASTAADI1.Name = "HASTAADI1";
                    HASTAADI1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HASTAADI1.TextFont.Size = 9;
                    HASTAADI1.TextFont.Bold = true;
                    HASTAADI1.TextFont.CharSet = 162;
                    HASTAADI1.Value = @"Ameliyat Salonu";

                    HASTADOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 8, 85, 13, false);
                    HASTADOGUMTARIHI.Name = "HASTADOGUMTARIHI";
                    HASTADOGUMTARIHI.TextFont.Size = 9;
                    HASTADOGUMTARIHI.TextFont.Bold = true;
                    HASTADOGUMTARIHI.TextFont.CharSet = 162;
                    HASTADOGUMTARIHI.Value = @"Doğum Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryPatientByDateNQL_Class dataset_SurgeryPatientByDateNQL = MyParentReport.Ameliyathane.rsGroup.GetCurrentRecord<Surgery.SurgeryPatientByDateNQL_Class>(0);
                    AMELIYATSALONU.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Ameliyatsalonu) : "");
                    AMELIYATSALONU.PostFieldValueCalculation();
                    HASTAADI.CalcValue = HASTAADI.Value;
                    HASTASOYADI.CalcValue = HASTASOYADI.Value;
                    PROCEDUREDOCTORNAME.CalcValue = PROCEDUREDOCTORNAME.Value;
                    HASTAADI1.CalcValue = HASTAADI1.Value;
                    HASTADOGUMTARIHI.CalcValue = HASTADOGUMTARIHI.Value;
                    return new TTReportObject[] { AMELIYATSALONU,HASTAADI,HASTASOYADI,PROCEDUREDOCTORNAME,HASTAADI1,HASTADOGUMTARIHI};
                }
            }
            public partial class AmeliyatSalonuGroupFooter : TTReportSection
            {
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                 
                public AmeliyatSalonuGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public AmeliyatSalonuGroup AmeliyatSalonu;

        public partial class MAINGroup : TTReportGroup
        {
            public SurgeryPatientByDateReport MyParentReport
            {
                get { return (SurgeryPatientByDateReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NOTE { get {return Body().NOTE;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField PROCEDUREDOCTORNAME { get {return Body().PROCEDUREDOCTORNAME;} }
            public TTReportField HASTADOGUMTARIHI { get {return Body().HASTADOGUMTARIHI;} }
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
                public SurgeryPatientByDateReport MyParentReport
                {
                    get { return (SurgeryPatientByDateReport)ParentReport; }
                }
                
                public TTReportField NOTE;
                public TTReportShape NewLine;
                public TTReportField HASTAADI;
                public TTReportField HASTASOYADI;
                public TTReportField PROCEDUREDOCTORNAME;
                public TTReportField HASTADOGUMTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 216, 17, false);
                    NOTE.Name = "NOTE";
                    NOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTE.Value = @"{#Ameliyathane.NOTE#}";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 19, 216, 19, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 37, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.Value = @"{#Ameliyathane.HASTAADI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 66, 6, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.Value = @"{#Ameliyathane.HASTASOYADI#}";

                    PROCEDUREDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 157, 6, false);
                    PROCEDUREDOCTORNAME.Name = "PROCEDUREDOCTORNAME";
                    PROCEDUREDOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTORNAME.Value = @"{#Ameliyathane.PROCEDUREDOCTORNAME#}";

                    HASTADOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 1, 85, 6, false);
                    HASTADOGUMTARIHI.Name = "HASTADOGUMTARIHI";
                    HASTADOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTADOGUMTARIHI.Value = @"{#Ameliyathane.HASTADOGUMTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Surgery.SurgeryPatientByDateNQL_Class dataset_SurgeryPatientByDateNQL = MyParentReport.Ameliyathane.rsGroup.GetCurrentRecord<Surgery.SurgeryPatientByDateNQL_Class>(0);
                    NOTE.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Note) : "");
                    HASTAADI.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Hastasoyadi) : "");
                    PROCEDUREDOCTORNAME.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Proceduredoctorname) : "");
                    HASTADOGUMTARIHI.CalcValue = (dataset_SurgeryPatientByDateNQL != null ? Globals.ToStringCore(dataset_SurgeryPatientByDateNQL.Hastadogumtarihi) : "");
                    return new TTReportObject[] { NOTE,HASTAADI,HASTASOYADI,PROCEDUREDOCTORNAME,HASTADOGUMTARIHI};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SurgeryPatientByDateReport()
        {
            Header = new HeaderGroup(this,"Header");
            Ameliyathane = new AmeliyathaneGroup(Header,"Ameliyathane");
            AmeliyatSalonu = new AmeliyatSalonuGroup(Ameliyathane,"AmeliyatSalonu");
            MAIN = new MAINGroup(AmeliyatSalonu,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SURGERYROOM", "00000000-0000-0000-0000-000000000000", "Ameliyat Salonu", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d8c32a25-f3e8-4424-92e6-912018707aa7");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SURGERYROOM"))
                _runtimeParameters.SURGERYROOM = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SURGERYROOM"]);
            Name = "SURGERYPATIENTBYDATEREPORT";
            Caption = "Ameliyat Olacak Hastalar";
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