
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
    /// İlaç İade Detayı Yüzde Raporu
    /// </summary>
    public partial class DrugReturnDetailPercentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string MASTERRESOURCE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string DOCTOR = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class hedGroup : TTReportGroup
        {
            public DrugReturnDetailPercentReport MyParentReport
            {
                get { return (DrugReturnDetailPercentReport)ParentReport; }
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
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField TarihLabel { get {return Header().TarihLabel;} }
            public TTReportField Klinik { get {return Header().Klinik;} }
            public TTReportField Tarih { get {return Header().Tarih;} }
            public TTReportField klinik { get {return Header().klinik;} }
            public TTReportField doktor { get {return Header().doktor;} }
            public TTReportField IlacMalzemeAdi1 { get {return Header().IlacMalzemeAdi1;} }
            public TTReportField CikisMiktari1 { get {return Header().CikisMiktari1;} }
            public TTReportField IadeMiktari1 { get {return Header().IadeMiktari1;} }
            public TTReportField Orani1 { get {return Header().Orani1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField RateField { get {return Header().RateField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
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
                public DrugReturnDetailPercentReport MyParentReport
                {
                    get { return (DrugReturnDetailPercentReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField111;
                public TTReportShape NewLine1;
                public TTReportField TarihLabel;
                public TTReportField Klinik;
                public TTReportField Tarih;
                public TTReportField klinik;
                public TTReportField doktor;
                public TTReportField IlacMalzemeAdi1;
                public TTReportField CikisMiktari1;
                public TTReportField IadeMiktari1;
                public TTReportField Orani1;
                public TTReportField NewField1;
                public TTReportField RateField;
                public TTReportField NewField2; 
                public hedGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 99;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 20, 47, 52, false);
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

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 10, 185, 47, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 53, 155, 63, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"İADE RAPORU (ORANSAL)";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 65, 208, 65, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TarihLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 66, 19, 71, false);
                    TarihLabel.Name = "TarihLabel";
                    TarihLabel.Value = @"Tarih:";

                    Klinik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 72, 19, 77, false);
                    Klinik.Name = "Klinik";
                    Klinik.Value = @"Klinik:";

                    Tarih = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 66, 193, 71, false);
                    Tarih.Name = "Tarih";
                    Tarih.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tarih.TextFont.Size = 9;
                    Tarih.Value = @"{@ENDDATE@}-{@STARTDATE@}
";

                    klinik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 72, 193, 77, false);
                    klinik.Name = "klinik";
                    klinik.FieldType = ReportFieldTypeEnum.ftVariable;
                    klinik.TextFont.Size = 9;
                    klinik.Value = @"";

                    doktor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 78, 193, 83, false);
                    doktor.Name = "doktor";
                    doktor.FieldType = ReportFieldTypeEnum.ftVariable;
                    doktor.TextFont.Size = 9;
                    doktor.Value = @"";

                    IlacMalzemeAdi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 95, 118, 100, false);
                    IlacMalzemeAdi1.Name = "IlacMalzemeAdi1";
                    IlacMalzemeAdi1.DrawStyle = DrawStyleConstants.vbSolid;
                    IlacMalzemeAdi1.Value = @"  İlaç/Malzeme Adı";

                    CikisMiktari1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 95, 145, 100, false);
                    CikisMiktari1.Name = "CikisMiktari1";
                    CikisMiktari1.DrawStyle = DrawStyleConstants.vbSolid;
                    CikisMiktari1.Value = @"  Çıkış Miltarı";

                    IadeMiktari1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 95, 174, 100, false);
                    IadeMiktari1.Name = "IadeMiktari1";
                    IadeMiktari1.DrawStyle = DrawStyleConstants.vbSolid;
                    IadeMiktari1.Value = @"  İade Miktarı";

                    Orani1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 95, 208, 100, false);
                    Orani1.Name = "Orani1";
                    Orani1.DrawStyle = DrawStyleConstants.vbSolid;
                    Orani1.Value = @"  Oranı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 95, 12, 100, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"Sıra";

                    RateField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 77, 253, 82, false);
                    RateField.Name = "RateField";
                    RateField.Visible = EvetHayirEnum.ehHayir;
                    RateField.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 78, 19, 83, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Doktor:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    NewField111.CalcValue = NewField111.Value;
                    TarihLabel.CalcValue = TarihLabel.Value;
                    Klinik.CalcValue = Klinik.Value;
                    Tarih.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString() + @"-" + MyParentReport.RuntimeParameters.STARTDATE.ToString() + @"
";
                    klinik.CalcValue = @"";
                    doktor.CalcValue = @"";
                    IlacMalzemeAdi1.CalcValue = IlacMalzemeAdi1.Value;
                    CikisMiktari1.CalcValue = CikisMiktari1.Value;
                    IadeMiktari1.CalcValue = IadeMiktari1.Value;
                    Orani1.CalcValue = Orani1.Value;
                    NewField1.CalcValue = NewField1.Value;
                    RateField.CalcValue = RateField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField111,TarihLabel,Klinik,Tarih,klinik,doktor,IlacMalzemeAdi1,CikisMiktari1,IadeMiktari1,Orani1,NewField1,RateField,NewField2,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HED HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
            TTObjectContext context = new TTObjectContext(true);
            
            string sObjectID = ((DrugReturnDetailPercentReport)ParentReport).RuntimeParameters.DOCTOR.ToString();
            if(sObjectID!="00000000-0000-0000-0000-000000000000"){
            ResUser labObject = (ResUser)context.GetObject(new Guid(sObjectID),"ResUser");
            this.doktor.CalcValue = labObject.Name;
            }

            string s1ObjectID = ((DrugReturnDetailPercentReport)ParentReport).RuntimeParameters.MASTERRESOURCE.ToString();
            if(s1ObjectID!="00000000-0000-0000-0000-000000000000"){
            Store labObject = (Store)context.GetObject(new Guid(s1ObjectID),"Store");
            this.klinik.CalcValue = labObject.Name;
            }
            
            //                   if(this.doctorField.CalcValue==""){
//
            //                      }
            
       ///     this.RATE.CalcValue=this.RETURNAMOUNT.CalcValue/this.AMOUNT.CalcValue;
            
            //                       if(this.MASTERRESOURCE.CalcValue==""{
//
            //                      }
#endregion HED HEADER_Script
                }
            }
            public partial class hedGroupFooter : TTReportSection
            {
                public DrugReturnDetailPercentReport MyParentReport
                {
                    get { return (DrugReturnDetailPercentReport)ParentReport; }
                }
                 
                public hedGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public hedGroup hed;

        public partial class PARENTGroup : TTReportGroup
        {
            public DrugReturnDetailPercentReport MyParentReport
            {
                get { return (DrugReturnDetailPercentReport)ParentReport; }
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
                list[0] = new TTReportNqlData<DrugReturnActionDetail.DrugReturnDetailPercent_Class>("DrugReturnDetailPercent", DrugReturnActionDetail.DrugReturnDetailPercent((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERRESOURCE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.DOCTOR)));
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
                public DrugReturnDetailPercentReport MyParentReport
                {
                    get { return (DrugReturnDetailPercentReport)ParentReport; }
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
                public DrugReturnDetailPercentReport MyParentReport
                {
                    get { return (DrugReturnDetailPercentReport)ParentReport; }
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
            public DrugReturnDetailPercentReport MyParentReport
            {
                get { return (DrugReturnDetailPercentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Ilac_MalzemeAdi { get {return Body().Ilac_MalzemeAdi;} }
            public TTReportField RETURNAMOUNT { get {return Body().RETURNAMOUNT;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField satir1 { get {return Body().satir1;} }
            public TTReportField RATE { get {return Body().RATE;} }
            public TTReportField STOREID { get {return Body().STOREID;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
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
                public DrugReturnDetailPercentReport MyParentReport
                {
                    get { return (DrugReturnDetailPercentReport)ParentReport; }
                }
                
                public TTReportField Ilac_MalzemeAdi;
                public TTReportField RETURNAMOUNT;
                public TTReportField AMOUNT;
                public TTReportField satir1;
                public TTReportField RATE;
                public TTReportField STOREID;
                public TTReportField MATERIAL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    Ilac_MalzemeAdi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 118, 8, false);
                    Ilac_MalzemeAdi.Name = "Ilac_MalzemeAdi";
                    Ilac_MalzemeAdi.FieldType = ReportFieldTypeEnum.ftVariable;
                    Ilac_MalzemeAdi.ObjectDefName = "Material";
                    Ilac_MalzemeAdi.DataMember = "NAME";
                    Ilac_MalzemeAdi.Value = @"  {#PARENT.MATERIAL#}
 ";

                    RETURNAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 174, 8, false);
                    RETURNAMOUNT.Name = "RETURNAMOUNT";
                    RETURNAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETURNAMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    RETURNAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    RETURNAMOUNT.Value = @"  {#PARENT.RETURNAMOUNT#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 145, 8, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"  {#PARENT.AMOUNT#}
 ";

                    satir1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 12, 8, false);
                    satir1.Name = "satir1";
                    satir1.FieldType = ReportFieldTypeEnum.ftVariable;
                    satir1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    satir1.TextFont.Size = 9;
                    satir1.Value = @"{@counter@}";

                    RATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 208, 8, false);
                    RATE.Name = "RATE";
                    RATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RATE.MultiLine = EvetHayirEnum.ehEvet;
                    RATE.NoClip = EvetHayirEnum.ehEvet;
                    RATE.WordBreak = EvetHayirEnum.ehEvet;
                    RATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    RATE.Value = @"";

                    STOREID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 240, 6, false);
                    STOREID.Name = "STOREID";
                    STOREID.Visible = EvetHayirEnum.ehHayir;
                    STOREID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOREID.Value = @"{#PARENT.STOREID#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 1, 267, 6, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.Visible = EvetHayirEnum.ehHayir;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.Value = @"{#PARENT.MATERIAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugReturnActionDetail.DrugReturnDetailPercent_Class dataset_DrugReturnDetailPercent = MyParentReport.PARENT.rsGroup.GetCurrentRecord<DrugReturnActionDetail.DrugReturnDetailPercent_Class>(0);
                    Ilac_MalzemeAdi.CalcValue = @"  " + (dataset_DrugReturnDetailPercent != null ? Globals.ToStringCore(dataset_DrugReturnDetailPercent.Material) : "") + @"
 ";
                    Ilac_MalzemeAdi.PostFieldValueCalculation();
                    RETURNAMOUNT.CalcValue = @"  " + (dataset_DrugReturnDetailPercent != null ? Globals.ToStringCore(dataset_DrugReturnDetailPercent.Returnamount) : "");
                    AMOUNT.CalcValue = @"  " + (dataset_DrugReturnDetailPercent != null ? Globals.ToStringCore(dataset_DrugReturnDetailPercent.Amount) : "") + @"
 ";
                    satir1.CalcValue = ParentGroup.Counter.ToString();
                    RATE.CalcValue = @"";
                    STOREID.CalcValue = (dataset_DrugReturnDetailPercent != null ? Globals.ToStringCore(dataset_DrugReturnDetailPercent.Storeid) : "");
                    MATERIAL.CalcValue = (dataset_DrugReturnDetailPercent != null ? Globals.ToStringCore(dataset_DrugReturnDetailPercent.Material) : "");
                    return new TTReportObject[] { Ilac_MalzemeAdi,RETURNAMOUNT,AMOUNT,satir1,RATE,STOREID,MATERIAL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            DateTime startDate = ((DrugReturnDetailPercentReport)ParentReport).RuntimeParameters.STARTDATE.Value;
            DateTime endDate = ((DrugReturnDetailPercentReport)ParentReport).RuntimeParameters.ENDDATE.Value;
            BindingList<StockTransaction> outTrxs = StockTransaction.GetOutputMaterials(context, startDate, endDate, new Guid(this.STOREID.CalcValue.ToString()), new Guid(this.MATERIAL.CalcValue.ToString()));
            Double sumAmount = Convert.ToDouble(outTrxs.Sum(x => x.Amount));
            this.AMOUNT.CalcValue = sumAmount.ToString();
            var result = double.Parse(this.RETURNAMOUNT.CalcValue) / double.Parse(this.AMOUNT.CalcValue) * 100;
            this.RATE.CalcValue = result.ToString("0.##");
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

        public DrugReturnDetailPercentReport()
        {
            hed = new hedGroup(this,"hed");
            PARENT = new PARENTGroup(hed,"PARENT");
            MAIN = new MAINGroup(PARENT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("MASTERRESOURCE", "", "Clinic", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("65cf14d4-129b-42dd-a991-b5e06fc66abc");
            reportParameter = Parameters.Add("DOCTOR", "", "Doktor", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("MASTERRESOURCE"))
                _runtimeParameters.MASTERRESOURCE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MASTERRESOURCE"]);
            if (parameters.ContainsKey("DOCTOR"))
                _runtimeParameters.DOCTOR = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DOCTOR"]);
            Name = "DRUGRETURNDETAILPERCENTREPORT";
            Caption = "İlaç İade Detayı Yüzde Raporu";
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