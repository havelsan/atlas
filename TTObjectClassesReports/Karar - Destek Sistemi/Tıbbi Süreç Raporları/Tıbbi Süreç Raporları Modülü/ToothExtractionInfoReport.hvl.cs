
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
    public partial class ToothExtractionInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string DentalExaminationObject = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class ParentGroup : TTReportGroup
        {
            public ToothExtractionInfoReport MyParentReport
            {
                get { return (ToothExtractionInfoReport)ParentReport; }
            }

            new public ParentGroupHeader Header()
            {
                return (ParentGroupHeader)_header;
            }

            new public ParentGroupFooter Footer()
            {
                return (ParentGroupFooter)_footer;
            }

            public TTReportField HospitalInfo1 { get {return Header().HospitalInfo1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField sayfaSayisi { get {return Header().sayfaSayisi;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField DentalExaminationObject { get {return Footer().DentalExaminationObject;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField doctorNameSurname { get {return Footer().doctorNameSurname;} }
            public TTReportField doctorDate { get {return Footer().doctorDate;} }
            public TTReportField doctorSignature1 { get {return Footer().doctorSignature1;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
            public TTReportField patientNameSurname { get {return Footer().patientNameSurname;} }
            public TTReportField patientDate { get {return Footer().patientDate;} }
            public TTReportField patientSignature1 { get {return Footer().patientSignature1;} }
            public ParentGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ParentGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ParentGroupHeader(this);
                _footer = new ParentGroupFooter(this);

            }

            public partial class ParentGroupHeader : TTReportSection
            {
                public ToothExtractionInfoReport MyParentReport
                {
                    get { return (ToothExtractionInfoReport)ParentReport; }
                }
                
                public TTReportField HospitalInfo1;
                public TTReportField LOGO;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField sayfaSayisi; 
                public ParentGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 53;
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

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 8, 202, 30, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 201, 41, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"DİŞ ÇEKİMİ İŞLEMİ BİLGİLENDİRME RIZA BELGESİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 58, 46, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Size = 9;
                    NewField13.Value = @"DOKÜMAN KODU:AD.RB39";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 41, 102, 46, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Size = 9;
                    NewField14.Value = @"YAYIN TARİHİ:06.08.2018";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 41, 125, 46, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Size = 9;
                    NewField15.Value = @"REVİZYON NO";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 41, 161, 46, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.TextFont.Size = 9;
                    NewField16.Value = @"REVİZYON TARİHİ";

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
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    sayfaSayisi.CalcValue = @"SAYFA SAYISI " + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    HospitalInfo1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,sayfaSayisi,HospitalInfo1};
                }

                public override void RunScript()
                {
#region PARENT HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PARENT HEADER_Script
                }
            }
            public partial class ParentGroupFooter : TTReportSection
            {
                public ToothExtractionInfoReport MyParentReport
                {
                    get { return (ToothExtractionInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField DentalExaminationObject;
                public TTReportField NewField191;
                public TTReportField doctorNameSurname;
                public TTReportField doctorDate;
                public TTReportField doctorSignature1;
                public TTReportField NewField1191;
                public TTReportField patientNameSurname;
                public TTReportField patientDate;
                public TTReportField patientSignature1; 
                public ParentGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 101;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 9, 204, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"Çekilecek Diş No:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 40, 204, 56, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.Value = @"Okudum, Anladım, Kabul ediyor ve onaylıyorum.(Hasta kendi el yazısı ile yazacak)

...................................................................................................................................................................................................................................................";

                    DentalExaminationObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 24, 254, 29, false);
                    DentalExaminationObject.Name = "DentalExaminationObject";
                    DentalExaminationObject.Visible = EvetHayirEnum.ehHayir;
                    DentalExaminationObject.FieldType = ReportFieldTypeEnum.ftVariable;
                    DentalExaminationObject.Value = @"{@DentalExaminationObject@}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 66, 151, 72, false);
                    NewField191.Name = "NewField191";
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Size = 11;
                    NewField191.Value = @"Hekim
";

                    doctorNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 72, 209, 77, false);
                    doctorNameSurname.Name = "doctorNameSurname";
                    doctorNameSurname.Value = @"Adı Soyadı:
";

                    doctorDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 77, 151, 82, false);
                    doctorDate.Name = "doctorDate";
                    doctorDate.Value = @"Tarih:
";

                    doctorSignature1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 82, 151, 87, false);
                    doctorSignature1.Name = "doctorSignature1";
                    doctorSignature1.Value = @"İmza:";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 66, 42, 72, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1191.TextFont.Size = 11;
                    NewField1191.Value = @"Hasta
";

                    patientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 72, 108, 77, false);
                    patientNameSurname.Name = "patientNameSurname";
                    patientNameSurname.Value = @"Adı Soyadı:
";

                    patientDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 77, 42, 82, false);
                    patientDate.Name = "patientDate";
                    patientDate.Value = @"Tarih:
";

                    patientSignature1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 82, 42, 87, false);
                    patientSignature1.Name = "patientSignature1";
                    patientSignature1.Value = @"İmza:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    DentalExaminationObject.CalcValue = MyParentReport.RuntimeParameters.DentalExaminationObject.ToString();
                    NewField191.CalcValue = NewField191.Value;
                    doctorNameSurname.CalcValue = doctorNameSurname.Value;
                    doctorDate.CalcValue = doctorDate.Value;
                    doctorSignature1.CalcValue = doctorSignature1.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    patientNameSurname.CalcValue = patientNameSurname.Value;
                    patientDate.CalcValue = patientDate.Value;
                    patientSignature1.CalcValue = patientSignature1.Value;
                    return new TTReportObject[] { NewField1,NewField2,DentalExaminationObject,NewField191,doctorNameSurname,doctorDate,doctorSignature1,NewField1191,patientNameSurname,patientDate,patientSignature1};
                }

                public override void RunScript()
                {
#region PARENT FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    DentalExamination dentalExamination = (DentalExamination)objectContext.GetObject(new Guid(this.DentalExaminationObject.CalcValue.ToString()), "DentalExamination");
                    this.patientNameSurname.CalcValue = this.patientNameSurname.CalcValue + dentalExamination.Episode.Patient.Name + " " + dentalExamination.Episode.Patient.Surname;
                    this.patientDate.CalcValue = this.patientDate.CalcValue + TTObjectClasses.Common.RecTime().ToShortDateString();
                    this.doctorNameSurname.CalcValue = this.doctorNameSurname.CalcValue + TTObjectClasses.Common.CurrentResource.ShortSignatureBlock;
                    this.doctorDate.CalcValue = this.doctorDate.CalcValue + TTObjectClasses.Common.RecTime().ToShortDateString();
#endregion PARENT FOOTER_Script
                }
            }

        }

        public ParentGroup Parent;

        public partial class MAINGroup : TTReportGroup
        {
            public ToothExtractionInfoReport MyParentReport
            {
                get { return (ToothExtractionInfoReport)ParentReport; }
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
                public ToothExtractionInfoReport MyParentReport
                {
                    get { return (ToothExtractionInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 133;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 201, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.Value = @"Tedaviye başlamadan önce hastaların sistemik rahatsızlıklarını(kalp, şeker, tansiyon vb.), bulaşıcı bir hastalığı(hepatit gibi), varsa kullandığı ilaçları hekimiyle paylaşması zorunludur. Hekim, gerekli gördüğü takdirde diğer branşlardan konsültasyon isteme hakkına sahiptir.
Tedavimi yapacak hekime kendi genel sağlığım, kullandığım ilaçlar ve özel durumlarım hakkında tam ve doğru bilgiler verdiğimi ifade ederim. Hekimim, yukarıda bahsi geçen tedaviler için oluşabilecek ve aşağıda özetlenen muhtemel yan etkiler hakkında beni sözlü olarak da detaylı bir şekilde bilgilendirmiş, bu tedaviyi reddetmem durumunda karşılaşabileceğim tıbbi sorunlar detaylı olarak anlatılmış, tıbbi uygulamanın gereğince yapılmış olması halinde dahi uygulanan tedavilerle ilgili tam bir memnuniyet sözü veya garanti verilmemiştir.
Diş çekiminin gerektiği durumlarda tedavi yapılmadığı takdirde: Foka) enfeksiyon kaynağı olan diş ağızda  bulunduğu sürece tüm organlara enfeksiyon riski oluşturmaktadır. işlemin riskleri ve komplikasyonları: Diş çekimi sırasında dişlerde kırılmalar, işlem sırasında ya da sonrasında çene kemiğinde kırılmalar, eklemde yaralanmalar, çekim sonrasında hassasiyet, hafif ya da şiddetli ağrı, işlem sonrası yanakta ya da dudakta ödem(şişlik ), diş çekimi sonrasıııda dilde veya dudakta geçici ya da kalıcı his kaybı, işlem sırasında veya sonrasında uzun süren kanama, çekim bölgesinde iltihabi duruma bağlı gelişen şiddetli ağrı (alveolit) oluşabilir. Anatomik boşluklara diş ya da kemik parçalarını kaçabilir. Bazen çekim sırasında kök kırığı durumu meydana geldiğinde, bu kökün çıkarılması hastaya daha fazla zarar verecekse kök yerinde bırakılabilir. işlemin tahmini süresi: 15-45 dakikadır.

Diş çekiminden sonra:
Tamponun tam çekim yerinin üstüne gelecek şekilde 20-30 dakika sıkılması gerekmektedir.
2 saat bir şey yememeli , sonrasında çekim boşluğuna yiyecek artığı kaçmamasına özen gösterilmelidir. Dişin çekildiği gün içinde soğuk sıcak yememeli, ılık yemelidir.
Çekim günü ağrı rahatsızlığı olabilir. Aspirin dışında uygun bir ağrı kesici kullanmalıdır. Sonraki günlerde çekim yerinde ağrı olursa tekrar hekime başvurmalıdır.
Çekim yerindeki enfeksiyona bağlı olarak çekim kavitesi etrafındaki kemik çıkıntıları hasta tarafından hissedilebilir. Bu orada kök kaldığı anlamına gelmez. Yapılması gereken vakit kaybetmeden hekiminize başvurmaktır.
Diş çekimi anestezi uygulaması dahil 45dak-l saat sürebilir. Diş kırılırsa bu zaman artar ve hastanın cerrahi müdahale kliniğine yönlendirilmesi gerekebilir.
Diş çekilmez ise kırılabilir, apse gelişebilir.
Lokal Anestezi: İnsan vücudunda his iletimi yapan sinirlerin, belirli bir bölgesinin, anestezik maddelerle (lidokain, mepivikain vb.) geçici süre iletim yapılmasının engellenmesi olarak kısaca tarif edilebilir. Diş hekimliğinde kullanılan lokal anestezi sonucu oluşan his kaybı süresi, kullanılan anestezik maddeye, anestezinin uygulandığı bölgeye ve kişinin anatomik yapısına göre, 1-4 saat arasında değişiklik gösterir. Anestezi sonucu fasiyal paralizi (geçici yüz felci), amfizem  (yüzde şişlik), hematom (yüzde kızarma, morarma) gibi komplikasyonlar oluşabilir. Bu durumlar geçici olup endişe edilmesine gerek yoktur. Anestezi sonucunda ayrıca alerjik reaksiyon (anaflaktik şok), senkop (bayılma)oluşabilmektedir. Bu durumda acil müdahale edilmesi gerekmektedir. Bunun için hastanın herhangi maddeye alerji olup olmadığını (penisilin alerjisi vb.) tedaviye başlamadan önce veya hekim reçete (ilaç) yazacağı zaman söylemesi gerekmektedir. Yapılmazsa tedavide ağrı hissedilebilir. İşlemin tahmini süresi:5-10 dakikadır.";

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

        public ToothExtractionInfoReport()
        {
            Parent = new ParentGroup(this,"Parent");
            MAIN = new MAINGroup(Parent,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DentalExaminationObject", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DentalExaminationObject"))
                _runtimeParameters.DentalExaminationObject = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DentalExaminationObject"]);
            Name = "TOOTHEXTRACTIONINFOREPORT";
            Caption = "Diş Çekimi İşlem Bilgilendirme Rıza Belgesi";
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