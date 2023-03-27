
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
    public partial class DentalMovableProsthesisInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string DentalExaminationObject = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class headerGroup : TTReportGroup
        {
            public DentalMovableProsthesisInfoReport MyParentReport
            {
                get { return (DentalMovableProsthesisInfoReport)ParentReport; }
            }

            new public headerGroupHeader Header()
            {
                return (headerGroupHeader)_header;
            }

            new public headerGroupFooter Footer()
            {
                return (headerGroupFooter)_footer;
            }

            public TTReportField HospitalInfo1 { get {return Header().HospitalInfo1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField sayfaSayisi { get {return Header().sayfaSayisi;} }
            public TTReportField NewField7 { get {return Footer().NewField7;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField DentalExaminationObject { get {return Footer().DentalExaminationObject;} }
            public TTReportField doctorNameSurname { get {return Footer().doctorNameSurname;} }
            public TTReportField doctorDate { get {return Footer().doctorDate;} }
            public TTReportField doctorSignature { get {return Footer().doctorSignature;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField patientNameSurname { get {return Footer().patientNameSurname;} }
            public TTReportField patientDate { get {return Footer().patientDate;} }
            public TTReportField patientSignature { get {return Footer().patientSignature;} }
            public headerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public headerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new headerGroupHeader(this);
                _footer = new headerGroupFooter(this);

            }

            public partial class headerGroupHeader : TTReportSection
            {
                public DentalMovableProsthesisInfoReport MyParentReport
                {
                    get { return (DentalMovableProsthesisInfoReport)ParentReport; }
                }
                
                public TTReportField HospitalInfo1;
                public TTReportField LOGO;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField sayfaSayisi; 
                public headerGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 77;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 8, 175, 33, false);
                    HospitalInfo1.Name = "HospitalInfo1";
                    HospitalInfo1.DrawStyle = DrawStyleConstants.vbSolid;
                    HospitalInfo1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo1.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo1.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo1.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo1.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo1.TextFont.Bold = true;
                    HospitalInfo1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 28, 34, false);
                    LOGO.Name = "LOGO";
                    LOGO.DrawStyle = DrawStyleConstants.vbSolid;
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 8, 202, 30, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 201, 41, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"HAREKETLİ PROTEZ BİLGİLENDİRME RIZA BELGESİ";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 58, 46, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.TextFont.Size = 9;
                    NewField3.Value = @"DOKÜMAN KODU:AD.RB37";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 41, 102, 46, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.TextFont.Size = 9;
                    NewField4.Value = @"YAYIN TARİHİ:06.08.2018";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 41, 125, 46, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.TextFont.Size = 9;
                    NewField5.Value = @"REVİZYON NO";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 41, 161, 46, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.TextFont.Size = 9;
                    NewField6.Value = @"REVİZYON TARİHİ";

                    sayfaSayisi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 41, 201, 46, false);
                    sayfaSayisi.Name = "sayfaSayisi";
                    sayfaSayisi.DrawStyle = DrawStyleConstants.vbSolid;
                    sayfaSayisi.FieldType = ReportFieldTypeEnum.ftVariable;
                    sayfaSayisi.TextFont.Size = 9;
                    sayfaSayisi.Value = @"SAYFA SAYISI {@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    sayfaSayisi.CalcValue = @"SAYFA SAYISI " + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    HospitalInfo1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,sayfaSayisi,HospitalInfo1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class headerGroupFooter : TTReportSection
            {
                public DentalMovableProsthesisInfoReport MyParentReport
                {
                    get { return (DentalMovableProsthesisInfoReport)ParentReport; }
                }
                
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField19;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField DentalExaminationObject;
                public TTReportField doctorNameSurname;
                public TTReportField doctorDate;
                public TTReportField doctorSignature;
                public TTReportField NewField191;
                public TTReportField patientNameSurname;
                public TTReportField patientDate;
                public TTReportField patientSignature; 
                public headerGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 125;
                    RepeatCount = 0;
                    
                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 44, 54, 67, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Italic = true;
                    NewField7.Value = @"Yapılacak Protez Türü";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 44, 202, 67, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 94, 148, 100, false);
                    NewField19.Name = "NewField19";
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Size = 11;
                    NewField19.Value = @"Hekim
";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 73, 206, 90, false);
                    NewField10.Name = "NewField10";
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Size = 11;
                    NewField10.Value = @"Okudum Anladım. Kabul ediyor ve onaylıyorum. (Hasta kendi el yazısı ile yazacak)

....................................................................................................................................................
";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 3, 205, 36, false);
                    NewField11.Name = "NewField11";
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 12;
                    NewField11.Value = @"
          Proteze başlandıktan sonra verilen randevulara uyulmazsa , yapılan dişler kötü uyum gösterir. Bir aydan fazla geciken protezlerde yeniden yapım gerekir ve ilave ücret gerektirir.  
          Hareketli protez gerektiği durumlarda tedavi yapılmadığı takdirde: Konuşma , çiğneme ve estetik kaybına meydana gelir.
          İşlemin tahmini süresi: Yapım aşaması ve hareketli protezlerin takım süresi 20 iş günü kadardır.
";

                    DentalExaminationObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 51, 255, 56, false);
                    DentalExaminationObject.Name = "DentalExaminationObject";
                    DentalExaminationObject.Visible = EvetHayirEnum.ehHayir;
                    DentalExaminationObject.FieldType = ReportFieldTypeEnum.ftVariable;
                    DentalExaminationObject.Value = @"{@DentalExaminationObject@}";

                    doctorNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 100, 206, 105, false);
                    doctorNameSurname.Name = "doctorNameSurname";
                    doctorNameSurname.Value = @"Adı Soyadı:
";

                    doctorDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 105, 148, 110, false);
                    doctorDate.Name = "doctorDate";
                    doctorDate.Value = @"Tarih:
";

                    doctorSignature = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 110, 148, 115, false);
                    doctorSignature.Name = "doctorSignature";
                    doctorSignature.Value = @"İmza:";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 94, 39, 100, false);
                    NewField191.Name = "NewField191";
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Size = 11;
                    NewField191.Value = @"Hasta
";

                    patientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 100, 105, 105, false);
                    patientNameSurname.Name = "patientNameSurname";
                    patientNameSurname.Value = @"Adı Soyadı:
";

                    patientDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 105, 39, 110, false);
                    patientDate.Name = "patientDate";
                    patientDate.Value = @"Tarih:
";

                    patientSignature = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 110, 39, 115, false);
                    patientSignature.Name = "patientSignature";
                    patientSignature.Value = @"İmza:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    DentalExaminationObject.CalcValue = MyParentReport.RuntimeParameters.DentalExaminationObject.ToString();
                    doctorNameSurname.CalcValue = doctorNameSurname.Value;
                    doctorDate.CalcValue = doctorDate.Value;
                    doctorSignature.CalcValue = doctorSignature.Value;
                    NewField191.CalcValue = NewField191.Value;
                    patientNameSurname.CalcValue = patientNameSurname.Value;
                    patientDate.CalcValue = patientDate.Value;
                    patientSignature.CalcValue = patientSignature.Value;
                    return new TTReportObject[] { NewField7,NewField8,NewField19,NewField10,NewField11,DentalExaminationObject,doctorNameSurname,doctorDate,doctorSignature,NewField191,patientNameSurname,patientDate,patientSignature};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    DentalExamination dentalExamination = (DentalExamination)objectContext.GetObject(new Guid(this.DentalExaminationObject.CalcValue.ToString()), "DentalExamination");
                    this.patientNameSurname.CalcValue = this.patientNameSurname.CalcValue + dentalExamination.Episode.Patient.Name + " " + dentalExamination.Episode.Patient.Surname;
                    this.patientDate.CalcValue = this.patientDate.CalcValue + TTObjectClasses.Common.RecTime().ToShortDateString();
                    this.doctorNameSurname.CalcValue = this.doctorNameSurname.CalcValue + TTObjectClasses.Common.CurrentResource.ShortSignatureBlock;
                    this.doctorDate.CalcValue = this.doctorDate.CalcValue + TTObjectClasses.Common.RecTime().ToShortDateString();
#endregion HEADER FOOTER_Script
                }
            }

        }

        public headerGroup header;

        public partial class MAINGroup : TTReportGroup
        {
            public DentalMovableProsthesisInfoReport MyParentReport
            {
                get { return (DentalMovableProsthesisInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
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
                public DentalMovableProsthesisInfoReport MyParentReport
                {
                    get { return (DentalMovableProsthesisInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 217;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 12, 205, 214, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 12;
                    NewField1.Value = @"                Tedaviye başlamadan önce hastaların sistemik rahatsızlarını(kalp, şeker, tansiyon vb.), bulaşıcı bir hastalığı(hepatit gibi), varsa kullandığı ilaçları hekimiyle paylaşması zorunludur. Hekim, gerekli gördüğü takdirde diğer branşlardan konsültasyon isteme hakkına sahiptir.
          Tedavimi yapacak hekime kendi genel sağlığım, kullandığım ilaçlar ve özel durumlarım hakkında tam ve doğru bilgiler verdiğimi ifade ederim. Hekimim, yukarıda bahsi geçen tedaviler için oluşabilecek ve aşağıda özetlenen muhtemel yan etkiler hakkında beni sözlü olarak da detaylı bir şekilde bilgilendirmiş, bu tedaviyi reddetmem durumunda karşılaşabileceğim tıbbi sorunlar detaylı olarak anlatılmış, tıbbi uygulamanın gereğince yapılmış olması halinde dahi uygulanan tedavilerle ilgili tam bir memnuniyet sözü veya garanti verilmemiştir.
          Total protez: Ağzında hiç dişi bulunmayan hastalarda yapılan takma dişlerdir.Proteze (ölçü alım işlemine) başlamadan önce hekiminiz damaklarınızı incelemeli ve protezin sağlıklı olup olmayacağına (tutup tutmayacağına) karar vermelidir.
           Proteze başlamadan damakların değerlendirilmesi:
          1-Kemik erime hızı kişiden kişiye değişeceği için, kemik yapısı ve seviyesi (yüksekliği)(özellikle alt çenedeki kemik seviyesi önemlidir.)
          2-Damaklardaki yumuşak doku büyümeleri(epilusvb)
          3-Daha önce çekilmiş dişten dolayı kalan parça ve kemik çıkıntıları
          4-Damaklardaki varsa yaraların(aft, mantar , lökoplaki vb. değerlendirilmesinin hekim tarafından yapılması gerekmektedir . Özellikle alt çenede dilin konumundan dolayı ve kemik seviyesinin yetersizliğinden protezin tutması zor olmaktadır. Alt çenede protez hiçbir zaman tam olarak sıkı sıkıya tutmaz, her zaman oynama ihtimali vardır. Hasta proteze alıştıkça bu sorun ortadan kalkar.
          Bölümlü (kancalı) protez:Kısmi diş eksikliğinde özel akrilik (plastik) ve metallerle beraber yapılan kroşe(kanca) adı verilen metal parçalar ile dişe tutunmayı sağlayan protez çeşididir. Proteze başlamadan önce total protezlerde olduğu gibi hekim tarafından damakların ve kalan dişlerin değerlendirilmesi gerekmektedir.Bölümlü (kancalı) protezlerde özellikle kancanın geldiği dişlere özen gösterilmeli, temizlenmesine dikkat edilmelidir. Eğer dikkat edilmezse kancanın geldiği dişlerde çürüme başlar ve dişin çekilmesiyle sonuçlanabilir. Kancanın geldiği yerlerdeki yiyecek artıklarının temizlenmesi şarttır.Kancanın geldiği dişlerdeki çürümeler hastanın protezini temizlememesi ve özen göstermemesinden kaynaklanmaktadır.
          Proteze başlamadan damakların değerlendirilmesi:
          1-     Her yemekten sonra protez fırçası veya diş fırçası ile sabun yardımıyla fırçalayıp takınız.
          2-     1 geceden sonraki günlerde gece fırçaladıktan sonra ıslak pamuklar arasında yada su dolu kapaklı bir saklama kabındamuhafaza ediniz. içine eczaneden temin edebileceğiniz suda eriyen dezenfektan tabletler atılabilir.
          3-     Dişetinin kapladığı kemik dokusundaki sivrilikler ve çıkıntılar, çiğneme esnasında proteze ilk temas eden bölgeler olduğu için dişeti yaralanabilir. Şikayetlerde 3-4 günde azalma olmadığında hekiminprotezde aşındırma yapması gerekmektedir. Protez çok acıtıyorsa kontrole gelene kadar yemeklerde takmayınız, yemek haricinde takınız
          4-     Mutlaka çift taraflı çiğneme yap ıl malıdır. Çok büyük lokma almaktan ve ön dişlerle ısırmaktan(protez dengesini bozacağından) kaçınılmalıdır.
          5-     Her insanın kemik erime hızı farklıdır. Eriyen çene kemiği ile protez arasını yeniden protez maddesiyle doldurmak, beslemek gerekir yada yeniden yapılması gerekir. Bu süre 1-5 yıl arasında değişir.
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DentalMovableProsthesisInfoReport()
        {
            header = new headerGroup(this,"header");
            MAIN = new MAINGroup(header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DentalExaminationObject", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DentalExaminationObject"))
                _runtimeParameters.DentalExaminationObject = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DentalExaminationObject"]);
            Name = "DENTALMOVABLEPROSTHESISINFOREPORT";
            Caption = "Hareketli Protez";
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