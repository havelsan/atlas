
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
    public partial class DistributionDocumentForPrescriptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public PrescriptionTypeEnum? PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue("");
            public bool? ALLMATERIALS = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
            public List<string> MATERIALS = new List<string>();
        }

        public partial class hedGroup : TTReportGroup
        {
            public DistributionDocumentForPrescriptionReport MyParentReport
            {
                get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
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
            public TTReportField Baslik1 { get {return Header().Baslik1;} }
            public TTReportField TarihLabel11 { get {return Header().TarihLabel11;} }
            public TTReportField Klinik11 { get {return Header().Klinik11;} }
            public TTReportField BaslangicTarihi { get {return Header().BaslangicTarihi;} }
            public TTReportField BitisTarihi { get {return Header().BitisTarihi;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField IlacAdi2 { get {return Header().IlacAdi2;} }
            public TTReportField istenenMiktar2 { get {return Header().istenenMiktar2;} }
            public TTReportField TalepEdenDoktor2 { get {return Header().TalepEdenDoktor2;} }
            public TTReportField HastaninKliniğinAdi2 { get {return Header().HastaninKliniğinAdi2;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField Deposu1 { get {return Header().Deposu1;} }
            public TTReportField STORE { get {return Header().STORE;} }
            public TTReportField Eden111 { get {return Footer().Eden111;} }
            public TTReportField Alan111 { get {return Footer().Alan111;} }
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
                public DistributionDocumentForPrescriptionReport MyParentReport
                {
                    get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField Baslik1;
                public TTReportField TarihLabel11;
                public TTReportField Klinik11;
                public TTReportField BaslangicTarihi;
                public TTReportField BitisTarihi;
                public TTReportShape NewLine111;
                public TTReportField IlacAdi2;
                public TTReportField istenenMiktar2;
                public TTReportField TalepEdenDoktor2;
                public TTReportField HastaninKliniğinAdi2;
                public TTReportField NewField112;
                public TTReportField Deposu1;
                public TTReportField STORE; 
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

                    Baslik1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 52, 155, 62, false);
                    Baslik1.Name = "Baslik1";
                    Baslik1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Baslik1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Baslik1.TextFont.Size = 12;
                    Baslik1.TextFont.Bold = true;
                    Baslik1.Value = @"Kliniklere Göre İlaç Çıkış Raporu";

                    TarihLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 65, 37, 70, false);
                    TarihLabel11.Name = "TarihLabel11";
                    TarihLabel11.Value = @"Başlangıç Tarihi:";

                    Klinik11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 71, 30, 76, false);
                    Klinik11.Name = "Klinik11";
                    Klinik11.Value = @"Bitiş Tarihi:";

                    BaslangicTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 65, 196, 70, false);
                    BaslangicTarihi.Name = "BaslangicTarihi";
                    BaslangicTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    BaslangicTarihi.TextFont.Size = 9;
                    BaslangicTarihi.Value = @"{@STARTDATE@}";

                    BitisTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 71, 196, 76, false);
                    BitisTarihi.Name = "BitisTarihi";
                    BitisTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    BitisTarihi.TextFont.Size = 9;
                    BitisTarihi.Value = @"{@ENDDATE@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 63, 210, 63, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    IlacAdi2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 89, 130, 94, false);
                    IlacAdi2.Name = "IlacAdi2";
                    IlacAdi2.DrawStyle = DrawStyleConstants.vbSolid;
                    IlacAdi2.Value = @"  İlaç Adı";

                    istenenMiktar2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 89, 150, 94, false);
                    istenenMiktar2.Name = "istenenMiktar2";
                    istenenMiktar2.DrawStyle = DrawStyleConstants.vbSolid;
                    istenenMiktar2.Value = @"  İstenen Miktar";

                    TalepEdenDoktor2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 89, 210, 94, false);
                    TalepEdenDoktor2.Name = "TalepEdenDoktor2";
                    TalepEdenDoktor2.DrawStyle = DrawStyleConstants.vbSolid;
                    TalepEdenDoktor2.Value = @"  Talep Eden Doktor";

                    HastaninKliniğinAdi2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 89, 74, 94, false);
                    HastaninKliniğinAdi2.Name = "HastaninKliniğinAdi2";
                    HastaninKliniğinAdi2.DrawStyle = DrawStyleConstants.vbSolid;
                    HastaninKliniğinAdi2.Value = @"Hastanın/Kliniğin Adı";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 89, 15, 94, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.Value = @"Sıra";

                    Deposu1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 78, 30, 83, false);
                    Deposu1.Name = "Deposu1";
                    Deposu1.Value = @"Deposu:";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 78, 196, 83, false);
                    STORE.Name = "STORE";
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.ObjectDefName = "Store";
                    STORE.DataMember = "NAME";
                    STORE.TextFont.Size = 9;
                    STORE.Value = @"{@STORE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    Baslik1.CalcValue = Baslik1.Value;
                    TarihLabel11.CalcValue = TarihLabel11.Value;
                    Klinik11.CalcValue = Klinik11.Value;
                    BaslangicTarihi.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    BitisTarihi.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    IlacAdi2.CalcValue = IlacAdi2.Value;
                    istenenMiktar2.CalcValue = istenenMiktar2.Value;
                    TalepEdenDoktor2.CalcValue = TalepEdenDoktor2.Value;
                    HastaninKliniğinAdi2.CalcValue = HastaninKliniğinAdi2.Value;
                    NewField112.CalcValue = NewField112.Value;
                    Deposu1.CalcValue = Deposu1.Value;
                    STORE.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    STORE.PostFieldValueCalculation();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,Baslik1,TarihLabel11,Klinik11,BaslangicTarihi,BitisTarihi,IlacAdi2,istenenMiktar2,TalepEdenDoktor2,HastaninKliniğinAdi2,NewField112,Deposu1,STORE,XXXXXXBASLIK};
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
                public DistributionDocumentForPrescriptionReport MyParentReport
                {
                    get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
                }
                
                public TTReportField Eden111;
                public TTReportField Alan111; 
                public hedGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    Eden111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 8, 39, 13, false);
                    Eden111.Name = "Eden111";
                    Eden111.Value = @"Teslim Eden";

                    Alan111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 8, 202, 13, false);
                    Alan111.Name = "Alan111";
                    Alan111.Value = @"Teslim Alan";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Eden111.CalcValue = Eden111.Value;
                    Alan111.CalcValue = Alan111.Value;
                    return new TTReportObject[] { Eden111,Alan111};
                }
            }

        }

        public hedGroup hed;

        public partial class PARENTGroup : TTReportGroup
        {
            public DistributionDocumentForPrescriptionReport MyParentReport
            {
                get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
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
                list[0] = new TTReportNqlData<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class>("PrescriptionTypeDistQuery2", DistributionDocumentMaterial.PrescriptionTypeDistQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue),(bool)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(MyParentReport.RuntimeParameters.ALLMATERIALS),(List<string>) MyParentReport.RuntimeParameters.MATERIALS,(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public DistributionDocumentForPrescriptionReport MyParentReport
                {
                    get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
                }
                 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public DistributionDocumentForPrescriptionReport MyParentReport
                {
                    get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
                }
                 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARENTGroup PARENT;

        public partial class MAINGroup : TTReportGroup
        {
            public DistributionDocumentForPrescriptionReport MyParentReport
            {
                get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESTINATIONSTORE { get {return Body().DESTINATIONSTORE;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField satir { get {return Body().satir;} }
            public TTReportField MKYS_TESLIMALANOBJID1 { get {return Body().MKYS_TESLIMALANOBJID1;} }
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
                public DistributionDocumentForPrescriptionReport MyParentReport
                {
                    get { return (DistributionDocumentForPrescriptionReport)ParentReport; }
                }
                
                public TTReportField DESTINATIONSTORE;
                public TTReportField MATERIAL;
                public TTReportField MIKTAR;
                public TTReportField satir;
                public TTReportField MKYS_TESLIMALANOBJID1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    DESTINATIONSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 74, 5, false);
                    DESTINATIONSTORE.Name = "DESTINATIONSTORE";
                    DESTINATIONSTORE.DrawStyle = DrawStyleConstants.vbSolid;
                    DESTINATIONSTORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESTINATIONSTORE.ObjectDefName = "Store";
                    DESTINATIONSTORE.DataMember = "NAME";
                    DESTINATIONSTORE.Value = @"     {#PARENT.DESTINATIONSTORE#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 130, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.ObjectDefName = "Material";
                    MATERIAL.DataMember = "NAME";
                    MATERIAL.Value = @"     {#PARENT.MATERIAL#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 150, 5, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.Value = @"      {#PARENT.NQLCOLUMN#}";

                    satir = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 15, 5, false);
                    satir.Name = "satir";
                    satir.DrawStyle = DrawStyleConstants.vbSolid;
                    satir.FieldType = ReportFieldTypeEnum.ftVariable;
                    satir.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    satir.TextFont.Size = 9;
                    satir.Value = @"{@counter@}";

                    MKYS_TESLIMALANOBJID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 210, 5, false);
                    MKYS_TESLIMALANOBJID1.Name = "MKYS_TESLIMALANOBJID1";
                    MKYS_TESLIMALANOBJID1.DrawStyle = DrawStyleConstants.vbSolid;
                    MKYS_TESLIMALANOBJID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MKYS_TESLIMALANOBJID1.ObjectDefName = "ResUser";
                    MKYS_TESLIMALANOBJID1.DataMember = "NAME";
                    MKYS_TESLIMALANOBJID1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class dataset_PrescriptionTypeDistQuery2 = MyParentReport.PARENT.rsGroup.GetCurrentRecord<DistributionDocumentMaterial.PrescriptionTypeDistQuery_Class>(0);
                    DESTINATIONSTORE.CalcValue = @"     " + (dataset_PrescriptionTypeDistQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeDistQuery2.DestinationStore) : "");
                    DESTINATIONSTORE.PostFieldValueCalculation();
                    MATERIAL.CalcValue = @"     " + (dataset_PrescriptionTypeDistQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeDistQuery2.Material) : "");
                    MATERIAL.PostFieldValueCalculation();
                    MIKTAR.CalcValue = @"      " + (dataset_PrescriptionTypeDistQuery2 != null ? Globals.ToStringCore(dataset_PrescriptionTypeDistQuery2.Nqlcolumn) : "");
                    satir.CalcValue = ParentGroup.Counter.ToString();
                    MKYS_TESLIMALANOBJID1.CalcValue = @"";
                    MKYS_TESLIMALANOBJID1.PostFieldValueCalculation();
                    return new TTReportObject[] { DESTINATIONSTORE,MATERIAL,MIKTAR,satir,MKYS_TESLIMALANOBJID1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DistributionDocumentForPrescriptionReport()
        {
            hed = new hedGroup(this,"hed");
            PARENT = new PARENTGroup(hed,"PARENT");
            MAIN = new MAINGroup(PARENT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
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
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("PRESCRIPTIONTYPE"))
                _runtimeParameters.PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue(parameters["PRESCRIPTIONTYPE"]);
            if (parameters.ContainsKey("ALLMATERIALS"))
                _runtimeParameters.ALLMATERIALS = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["ALLMATERIALS"]);
            if (parameters.ContainsKey("MATERIALS"))
                _runtimeParameters.MATERIALS = (List<string>)parameters["MATERIALS"];
            Name = "DISTRIBUTIONDOCUMENTFORPRESCRIPTIONREPORT";
            Caption = "Dağıtım Belgesi İçin Reçete Raporu";
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