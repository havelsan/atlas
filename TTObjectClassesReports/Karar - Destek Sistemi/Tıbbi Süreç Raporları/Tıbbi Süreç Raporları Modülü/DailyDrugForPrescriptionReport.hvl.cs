
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
    /// Reçete Türüne Göre Çıkış
    /// </summary>
    public partial class DailyDrugForPrescriptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? DOCTOR = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public PrescriptionTypeEnum? PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue("");
            public bool? ALLMATERIALS = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
            public List<string> MATERIALS = new List<string>();
        }

        public partial class hedGroup : TTReportGroup
        {
            public DailyDrugForPrescriptionReport MyParentReport
            {
                get { return (DailyDrugForPrescriptionReport)ParentReport; }
            }

            new public hedGroupHeader Header()
            {
                return (hedGroupHeader)_header;
            }

            new public hedGroupFooter Footer()
            {
                return (hedGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField Baslik { get {return Header().Baslik;} }
            public TTReportField TarihLabel1 { get {return Header().TarihLabel1;} }
            public TTReportField Klinik1 { get {return Header().Klinik1;} }
            public TTReportField BaslangicTarihi { get {return Header().BaslangicTarihi;} }
            public TTReportField BitisTarihi { get {return Header().BitisTarihi;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField Deposu { get {return Header().Deposu;} }
            public TTReportField STORE { get {return Header().STORE;} }
            public TTReportField IlacAdi11 { get {return Header().IlacAdi11;} }
            public TTReportField istenenMiktar11 { get {return Header().istenenMiktar11;} }
            public TTReportField TalepEdenDoktor11 { get {return Header().TalepEdenDoktor11;} }
            public TTReportField HastaninKliniğinAdi11 { get {return Header().HastaninKliniğinAdi11;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public hedGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public hedGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new hedGroupHeader(this);
                _footer = new hedGroupFooter(this);

            }

            public partial class hedGroupHeader : TTReportSection
            {
                public DailyDrugForPrescriptionReport MyParentReport
                {
                    get { return (DailyDrugForPrescriptionReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField Baslik;
                public TTReportField TarihLabel1;
                public TTReportField Klinik1;
                public TTReportField BaslangicTarihi;
                public TTReportField BitisTarihi;
                public TTReportShape NewLine11;
                public TTReportField Deposu;
                public TTReportField STORE;
                public TTReportField IlacAdi11;
                public TTReportField istenenMiktar11;
                public TTReportField TalepEdenDoktor11;
                public TTReportField HastaninKliniğinAdi11;
                public TTReportField NewField1111; 
                public hedGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 94;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 22, 47, 54, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 12, 185, 49, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Baslik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 52, 155, 62, false);
                    Baslik.Name = "Baslik";
                    Baslik.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Baslik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Baslik.TextFont.Size = 12;
                    Baslik.TextFont.Bold = true;
                    Baslik.Value = @"Kliniklere Göre İlaç Çıkış Raporu";

                    TarihLabel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 65, 38, 70, false);
                    TarihLabel1.Name = "TarihLabel1";
                    TarihLabel1.Value = @"Başlangıç Tarihi:";

                    Klinik1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 71, 30, 76, false);
                    Klinik1.Name = "Klinik1";
                    Klinik1.Value = @"Bitiş Tarihi:";

                    BaslangicTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 65, 195, 70, false);
                    BaslangicTarihi.Name = "BaslangicTarihi";
                    BaslangicTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    BaslangicTarihi.TextFont.Size = 9;
                    BaslangicTarihi.Value = @"{@STARTDATE@}";

                    BitisTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 71, 195, 76, false);
                    BitisTarihi.Name = "BitisTarihi";
                    BitisTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    BitisTarihi.TextFont.Size = 9;
                    BitisTarihi.Value = @"{@ENDDATE@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 63, 210, 63, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    Deposu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 78, 30, 83, false);
                    Deposu.Name = "Deposu";
                    Deposu.Value = @"Deposu:";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 78, 195, 83, false);
                    STORE.Name = "STORE";
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.ObjectDefName = "Store";
                    STORE.DataMember = "NAME";
                    STORE.TextFont.Size = 9;
                    STORE.Value = @"{@STORE@}";

                    IlacAdi11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 89, 129, 94, false);
                    IlacAdi11.Name = "IlacAdi11";
                    IlacAdi11.DrawStyle = DrawStyleConstants.vbSolid;
                    IlacAdi11.Value = @"  İlaç Adı";

                    istenenMiktar11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 89, 149, 94, false);
                    istenenMiktar11.Name = "istenenMiktar11";
                    istenenMiktar11.DrawStyle = DrawStyleConstants.vbSolid;
                    istenenMiktar11.Value = @" Miktar";

                    TalepEdenDoktor11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 89, 210, 94, false);
                    TalepEdenDoktor11.Name = "TalepEdenDoktor11";
                    TalepEdenDoktor11.DrawStyle = DrawStyleConstants.vbSolid;
                    TalepEdenDoktor11.Value = @"  Talep Eden Doktor";

                    HastaninKliniğinAdi11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 89, 74, 94, false);
                    HastaninKliniğinAdi11.Name = "HastaninKliniğinAdi11";
                    HastaninKliniğinAdi11.DrawStyle = DrawStyleConstants.vbSolid;
                    HastaninKliniğinAdi11.Value = @"Hastanın/Kliniğin Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 89, 15, 94, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.Value = @"Sıra";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    Baslik.CalcValue = Baslik.Value;
                    TarihLabel1.CalcValue = TarihLabel1.Value;
                    Klinik1.CalcValue = Klinik1.Value;
                    BaslangicTarihi.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    BitisTarihi.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    Deposu.CalcValue = Deposu.Value;
                    STORE.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    STORE.PostFieldValueCalculation();
                    IlacAdi11.CalcValue = IlacAdi11.Value;
                    istenenMiktar11.CalcValue = istenenMiktar11.Value;
                    TalepEdenDoktor11.CalcValue = TalepEdenDoktor11.Value;
                    HastaninKliniğinAdi11.CalcValue = HastaninKliniğinAdi11.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,Baslik,TarihLabel1,Klinik1,BaslangicTarihi,BitisTarihi,Deposu,STORE,IlacAdi11,istenenMiktar11,TalepEdenDoktor11,HastaninKliniğinAdi11,NewField1111,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HED HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
            TTObjectContext context = new TTObjectContext(true);
#endregion HED HEADER_Script
                }
            }
            public partial class hedGroupFooter : TTReportSection
            {
                public DailyDrugForPrescriptionReport MyParentReport
                {
                    get { return (DailyDrugForPrescriptionReport)ParentReport; }
                }
                 
                public hedGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 24;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public hedGroup hed;

        public partial class PARENTGroup : TTReportGroup
        {
            public DailyDrugForPrescriptionReport MyParentReport
            {
                get { return (DailyDrugForPrescriptionReport)ParentReport; }
            }

            new public PARENTGroupHeader Header()
            {
                return (PARENTGroupHeader)_header;
            }

            new public PARENTGroupFooter Footer()
            {
                return (PARENTGroupFooter)_footer;
            }

            public PARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<KScheduleMaterial.PrescriptionTypeQuery_Class>("PrescriptionTypeQuery2", KScheduleMaterial.PrescriptionTypeQuery(((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.DOCTOR),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(List<string>) MyParentReport.RuntimeParameters.MATERIALS,(bool)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(MyParentReport.RuntimeParameters.ALLMATERIALS)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGroupHeader(this);
                _footer = new PARENTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARENTGroupHeader : TTReportSection
            {
                public DailyDrugForPrescriptionReport MyParentReport
                {
                    get { return (DailyDrugForPrescriptionReport)ParentReport; }
                }
                 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public DailyDrugForPrescriptionReport MyParentReport
                {
                    get { return (DailyDrugForPrescriptionReport)ParentReport; }
                }
                 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARENTGroup PARENT;

        public partial class MAINGroup : TTReportGroup
        {
            public DailyDrugForPrescriptionReport MyParentReport
            {
                get { return (DailyDrugForPrescriptionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField satir { get {return Body().satir;} }
            public TTReportField PATIENT { get {return Body().PATIENT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField MKYS_TESLIMALANOBJID { get {return Body().MKYS_TESLIMALANOBJID;} }
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
                public DailyDrugForPrescriptionReport MyParentReport
                {
                    get { return (DailyDrugForPrescriptionReport)ParentReport; }
                }
                
                public TTReportField satir;
                public TTReportField PATIENT;
                public TTReportField MATERIAL;
                public TTReportField MIKTAR;
                public TTReportField MKYS_TESLIMALANOBJID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    satir = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 15, 5, false);
                    satir.Name = "satir";
                    satir.DrawStyle = DrawStyleConstants.vbSolid;
                    satir.FieldType = ReportFieldTypeEnum.ftVariable;
                    satir.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    satir.TextFont.Size = 9;
                    satir.Value = @"{@counter@}";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 74, 5, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.ObjectDefName = "Patient";
                    PATIENT.DataMember = "FullName";
                    PATIENT.Value = @"      {#PARENT.PATIENT#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 129, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.ObjectDefName = "Material";
                    MATERIAL.DataMember = "NAME";
                    MATERIAL.Value = @"      {#PARENT.MATERIAL#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 149, 5, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.Value = @"      {#PARENT.NQLCOLUMN#}";

                    MKYS_TESLIMALANOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 210, 5, false);
                    MKYS_TESLIMALANOBJID.Name = "MKYS_TESLIMALANOBJID";
                    MKYS_TESLIMALANOBJID.DrawStyle = DrawStyleConstants.vbSolid;
                    MKYS_TESLIMALANOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MKYS_TESLIMALANOBJID.ObjectDefName = "ResUser";
                    MKYS_TESLIMALANOBJID.DataMember = "NAME";
                    MKYS_TESLIMALANOBJID.Value = @"     {#PARENT.MKYS_TESLIMALANOBJID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KScheduleMaterial.PrescriptionTypeQuery_Class dataset_PrescriptionTypeQuery2 = MyParentReport.PARENT.rsGroup.GetCurrentRecord<KScheduleMaterial.PrescriptionTypeQuery_Class>(0);
                    satir.CalcValue = ParentGroup.Counter.ToString();
                    PATIENT.CalcValue = @"      " + (dataset_PrescriptionTypeQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeQuery2.Patient) : "");
                    PATIENT.PostFieldValueCalculation();
                    MATERIAL.CalcValue = @"      " + (dataset_PrescriptionTypeQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeQuery2.Material) : "");
                    MATERIAL.PostFieldValueCalculation();
                    MIKTAR.CalcValue = @"      " + (dataset_PrescriptionTypeQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeQuery2.Nqlcolumn) : "");
                    MKYS_TESLIMALANOBJID.CalcValue = @"     " + (dataset_PrescriptionTypeQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeQuery2.MKYS_TeslimAlanObjID) : "");
                    MKYS_TESLIMALANOBJID.PostFieldValueCalculation();
                    return new TTReportObject[] { satir,PATIENT,MATERIAL,MIKTAR,MKYS_TESLIMALANOBJID};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DailyDrugForPrescriptionReport()
        {
            hed = new hedGroup(this,"hed");
            PARENT = new PARENTGroup(hed,"PARENT");
            MAIN = new MAINGroup(PARENT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DOCTOR", "00000000-0000-0000-0000-000000000000", "Doktor", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Store", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("PRESCRIPTIONTYPE", "", "PrescriptionType", @"", true, true, false, new Guid("5c575de3-430a-4947-9d86-9273d771d9ee"));
            reportParameter = Parameters.Add("ALLMATERIALS", "", "AllMaterials", @"", true, true, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
            reportParameter = Parameters.Add("MATERIALS", "", "Materials", @"", true, true, true, new Guid("ad729221-77ee-47c8-9be2-c31ed6e2c1d1"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DOCTOR"))
                _runtimeParameters.DOCTOR = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["DOCTOR"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("PRESCRIPTIONTYPE"))
                _runtimeParameters.PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue(parameters["PRESCRIPTIONTYPE"]);
            if (parameters.ContainsKey("ALLMATERIALS"))
                _runtimeParameters.ALLMATERIALS = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["ALLMATERIALS"]);
            if (parameters.ContainsKey("MATERIALS"))
                _runtimeParameters.MATERIALS = (List<string>)parameters["MATERIALS"];
            Name = "DAILYDRUGFORPRESCRIPTIONREPORT";
            Caption = "Reçete Türüne Göre Çıkış";
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
            fd.TextFont.CharSet = 162;
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