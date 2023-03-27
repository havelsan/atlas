
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
    /// Ortez Protez Garanti Belgesi
    /// </summary>
    public partial class OrthesisProsthesisWarrantyReport : TTReport
    {
#region Methods
   string _tempWarrant = "";
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PartAGroup : TTReportGroup
        {
            public OrthesisProsthesisWarrantyReport MyParentReport
            {
                get { return (OrthesisProsthesisWarrantyReport)ParentReport; }
            }

            new public PartAGroupHeader Header()
            {
                return (PartAGroupHeader)_header;
            }

            new public PartAGroupFooter Footer()
            {
                return (PartAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField garanti { get {return Header().garanti;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public PartAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PartAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PartAGroupHeader(this);
                _footer = new PartAGroupFooter(this);

            }

            public partial class PartAGroupHeader : TTReportSection
            {
                public OrthesisProsthesisWarrantyReport MyParentReport
                {
                    get { return (OrthesisProsthesisWarrantyReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField garanti; 
                public PartAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 4, 171, 38, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    garanti = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 43, 125, 48, false);
                    garanti.Name = "garanti";
                    garanti.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    garanti.TextFont.Name = "Arial";
                    garanti.TextFont.Size = 12;
                    garanti.TextFont.Bold = true;
                    garanti.TextFont.CharSet = 162;
                    garanti.Value = @"GARANTİ BELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    garanti.CalcValue = garanti.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { garanti,XXXXXXBASLIK1};
                }
            }
            public partial class PartAGroupFooter : TTReportSection
            {
                public OrthesisProsthesisWarrantyReport MyParentReport
                {
                    get { return (OrthesisProsthesisWarrantyReport)ParentReport; }
                }
                
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField1; 
                public PartAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 156;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 206, 52, false);
                    NewField17.Name = "NewField17";
                    NewField17.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 59, 205, 86, false);
                    NewField18.Name = "NewField18";
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.WordBreak = EvetHayirEnum.ehEvet;
                    NewField18.Value = @"Resmi Sağlık Kurumunun Adı : Gaziler Fizik Tedavi ve Rehabilitasyon Eğitim ve Araştırma XXXXXX

Adres : Gaziler Fizik Tedavi ve Rehabilitasyon Eğitim ve Araştırma XXXXXX 06800 Lodumlu yolu Bilkent/XXXXXX

Merkez Sorumlu İmzası/Kaşe:
";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 93, 65, 108, false);
                    NewField19.Name = "NewField19";
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Engin ASLAN
Gaziler fizik Tedavi ve Reh.E.A.H
Ortez-Protez Birim Sorumlusu";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 114, 205, 155, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField17.CalcValue = @"";
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField17,NewField18,NewField19,NewField1};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    NewField17.CalcValue = @"     Merkezimiz tarafınan üretilen ve uygulanan yukarıda belirtilen cihaza ait garanti süresi teslim tarihinde başlar. Bu süre içinde kullanıcının kasıt ve kusuru olmaksızın arızalanması halinde " +MyParentReport._tempWarrant + @" garanti kapsamında olduğunu kabul ve taahhüt ederim.

     Aksi durumun taspiti halinde, garantiden doğan haklarının kullanılması ile ilgili olarak çıkabilecek uyuşmazlıklarda yerleşim yerinin bulunduğu veya cihazın işleminin yapıldığı yerdeki Tüketici Heyetine ve Tüketici Mahkemesine başvurulabileceğini, kabul ve beyan ederim.";
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PartAGroup PartA;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisProsthesisWarrantyReport MyParentReport
            {
                get { return (OrthesisProsthesisWarrantyReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField PHONE { get {return Body().PHONE;} }
            public TTReportField ADRESS { get {return Body().ADRESS;} }
            public TTReportField HiddenName { get {return Body().HiddenName;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField ProcedureDefObJId1 { get {return Body().ProcedureDefObJId1;} }
            public TTReportField PROCEDUREOBJECT { get {return Body().PROCEDUREOBJECT;} }
            public TTReportField WarrantyNote { get {return Body().WarrantyNote;} }
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
                list[0] = new TTReportNqlData<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>("GetOrthesisRceptionReportInfo", OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OrthesisProsthesisWarrantyReport MyParentReport
                {
                    get { return (OrthesisProsthesisWarrantyReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField FULLNAME;
                public TTReportField TC;
                public TTReportField FATHERNAME;
                public TTReportField PHONE;
                public TTReportField ADRESS;
                public TTReportField HiddenName;
                public TTReportField NewField11;
                public TTReportField ProcedureDefObJId1;
                public TTReportField PROCEDUREOBJECT;
                public TTReportField WarrantyNote; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 82;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 60, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HASTAYA  AİT  BİLGİLER:";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 33, 17, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Adı Soyadı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 33, 22, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"TC No";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 22, 33, 27, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Baba Adı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 27, 33, 32, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Tel No";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 32, 33, 37, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Adresi";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 12, 36, 17, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 17, 36, 22, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 22, 36, 27, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 27, 36, 32, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 32, 36, 37, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @":";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 12, 139, 17, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @"{%HiddenName%}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 17, 139, 22, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.TextFont.CharSet = 162;
                    TC.Value = @"{#TCKIMLIKNO#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 22, 139, 27, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    PHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 27, 139, 32, false);
                    PHONE.Name = "PHONE";
                    PHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHONE.TextFont.CharSet = 162;
                    PHONE.Value = @"{#MOBILEPHONE#}";

                    ADRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 32, 209, 37, false);
                    ADRESS.Name = "ADRESS";
                    ADRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRESS.TextFont.CharSet = 162;
                    ADRESS.Value = @"{#HOMEADDRESS#}";

                    HiddenName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 8, 237, 13, false);
                    HiddenName.Name = "HiddenName";
                    HiddenName.Visible = EvetHayirEnum.ehHayir;
                    HiddenName.FieldType = ReportFieldTypeEnum.ftVariable;
                    HiddenName.Value = @"{#NAME#}{#SURNAME#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 43, 60, 48, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"CİHAZA  AİT  BİLGİLER:";

                    ProcedureDefObJId1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 16, 237, 21, false);
                    ProcedureDefObJId1.Name = "ProcedureDefObJId1";
                    ProcedureDefObJId1.Visible = EvetHayirEnum.ehHayir;
                    ProcedureDefObJId1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProcedureDefObJId1.Value = @"{@TTOBJECTID@}";

                    PROCEDUREOBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 52, 209, 72, false);
                    PROCEDUREOBJECT.Name = "PROCEDUREOBJECT";
                    PROCEDUREOBJECT.Value = @"";

                    WarrantyNote = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 27, 236, 32, false);
                    WarrantyNote.Name = "WarrantyNote";
                    WarrantyNote.Visible = EvetHayirEnum.ehHayir;
                    WarrantyNote.FieldType = ReportFieldTypeEnum.ftVariable;
                    WarrantyNote.Value = @"{#WARRANTYNOTE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class dataset_GetOrthesisRceptionReportInfo = ParentGroup.rsGroup.GetCurrentRecord<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    HiddenName.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Name) : "") + (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Surname) : "");
                    FULLNAME.CalcValue = MyParentReport.MAIN.HiddenName.CalcValue;
                    TC.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.Tckimlikno) : "");
                    FATHERNAME.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.FatherName) : "");
                    PHONE.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.MobilePhone) : "");
                    ADRESS.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.HomeAddress) : "");
                    NewField11.CalcValue = NewField11.Value;
                    ProcedureDefObJId1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCEDUREOBJECT.CalcValue = PROCEDUREOBJECT.Value;
                    WarrantyNote.CalcValue = (dataset_GetOrthesisRceptionReportInfo != null ? Globals.ToStringCore(dataset_GetOrthesisRceptionReportInfo.WarrantyNote) : "");
                    return new TTReportObject[] { NewField1,NewField12,NewField121,NewField131,NewField141,NewField151,NewField161,NewField1121,NewField1131,NewField1141,NewField1151,HiddenName,FULLNAME,TC,FATHERNAME,PHONE,ADRESS,NewField11,ProcedureDefObJId1,PROCEDUREOBJECT,WarrantyNote};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class[] p = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction(ProcedureDefObJId1.CalcValue).ToArray();
                    string _tempSide = "";
                    if (p[0].Side != null)
                    {
                        _tempSide = "("+(TTObjectClasses.Common.GetEnumValueDefOfEnumValue(p[0].Side).DisplayText)+")";
                    }

                    PROCEDUREOBJECT.CalcValue = "SUT KODU : " + _tempSide + " " + p[0].Procedurecode + " " + p[0].Procedurename;

                    MyParentReport._tempWarrant = this.WarrantyNote.CalcValue;
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

        public OrthesisProsthesisWarrantyReport()
        {
            PartA = new PartAGroup(this,"PartA");
            MAIN = new MAINGroup(PartA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ORTHESISPROSTHESISWARRANTYREPORT";
            Caption = "Garanti Belgesi";
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