
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
    public partial class DentalRootCanalOperationInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string DentalExaminationObject = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class headerGroup : TTReportGroup
        {
            public DentalRootCanalOperationInfoReport MyParentReport
            {
                get { return (DentalRootCanalOperationInfoReport)ParentReport; }
            }

            new public headerGroupHeader Header()
            {
                return (headerGroupHeader)_header;
            }

            new public headerGroupFooter Footer()
            {
                return (headerGroupFooter)_footer;
            }

            public TTReportField HospitalInfo11 { get {return Header().HospitalInfo11;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField sayfaSayisi1 { get {return Header().sayfaSayisi1;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField NewField101 { get {return Footer().NewField101;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField doctorNameSurname { get {return Footer().doctorNameSurname;} }
            public TTReportField doctorDate { get {return Footer().doctorDate;} }
            public TTReportField doctorSignature1 { get {return Footer().doctorSignature1;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
            public TTReportField patientNameSurname { get {return Footer().patientNameSurname;} }
            public TTReportField patientDate { get {return Footer().patientDate;} }
            public TTReportField patientSignature1 { get {return Footer().patientSignature1;} }
            public TTReportField DentalExaminationObject { get {return Footer().DentalExaminationObject;} }
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
                public DentalRootCanalOperationInfoReport MyParentReport
                {
                    get { return (DentalRootCanalOperationInfoReport)ParentReport; }
                }
                
                public TTReportField HospitalInfo11;
                public TTReportField LOGO;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField sayfaSayisi1; 
                public headerGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 8, 175, 33, false);
                    HospitalInfo11.Name = "HospitalInfo11";
                    HospitalInfo11.DrawStyle = DrawStyleConstants.vbSolid;
                    HospitalInfo11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo11.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo11.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo11.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo11.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo11.TextFont.Bold = true;
                    HospitalInfo11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

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
                    NewField12.Value = @"DOLGU-KANAL TEDAVİSİ BİLGİLENDİRME RIZA BELGESİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 58, 46, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Size = 9;
                    NewField13.Value = @"DOKÜMAN KODU:AD.RB37";

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

                    sayfaSayisi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 41, 201, 46, false);
                    sayfaSayisi1.Name = "sayfaSayisi1";
                    sayfaSayisi1.DrawStyle = DrawStyleConstants.vbSolid;
                    sayfaSayisi1.FieldType = ReportFieldTypeEnum.ftVariable;
                    sayfaSayisi1.TextFont.Size = 9;
                    sayfaSayisi1.Value = @"SAYFA SAYISI {@pagenumber@}/{@pagecount@}";

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
                    sayfaSayisi1.CalcValue = @"SAYFA SAYISI " + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    HospitalInfo11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,sayfaSayisi1,HospitalInfo11};
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
                public DentalRootCanalOperationInfoReport MyParentReport
                {
                    get { return (DentalRootCanalOperationInfoReport)ParentReport; }
                }
                
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField191;
                public TTReportField NewField101;
                public TTReportField NewField111;
                public TTReportField doctorNameSurname;
                public TTReportField doctorDate;
                public TTReportField doctorSignature1;
                public TTReportField NewField1191;
                public TTReportField patientNameSurname;
                public TTReportField patientDate;
                public TTReportField patientSignature1;
                public TTReportField DentalExaminationObject; 
                public headerGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 146;
                    RepeatCount = 0;
                    
                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 45, 76, 68, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Italic = true;
                    NewField17.Value = @"Tedavi Yapılacak Diş no ve İşlem";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 45, 205, 68, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 95, 148, 101, false);
                    NewField191.Name = "NewField191";
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Size = 11;
                    NewField191.Value = @"Hekim
";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 74, 206, 91, false);
                    NewField101.Name = "NewField101";
                    NewField101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField101.TextFont.Size = 11;
                    NewField101.Value = @"Okudum Anladım. Kabul ediyor ve onaylıyorum. (Hasta kendi el yazısı ile yazacak)

....................................................................................................................................................
";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 4, 205, 37, false);
                    NewField111.Name = "NewField111";
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Size = 12;
                    NewField111.Value = @"reaksiyon (anafilaktik şok) oluşabilmektedir. Bu durumda acil müdahale edilmesi gerekmektedir. Bumm için hastanın herhangi maddeye alerji olup olmadığını (penisilin aleıjisi vb.) tedaviye başlamadan önce veya hekim reçete (ilaç) yazacağı zaman söylemesi gerekmektedir. 
İşlemin tahmini süresi: 5-10 dakikadır. Gerektiğinde aynı konuda tıbbı yardıma XXXXXXlerin diş polikliniklerinden, Ağız ve Diş Sağlığı XXXXXXlerinden ve Diş Hekimliği Fakültelerinden ulaşabilir.
";

                    doctorNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 101, 206, 106, false);
                    doctorNameSurname.Name = "doctorNameSurname";
                    doctorNameSurname.Value = @"Adı Soyadı:
";

                    doctorDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 106, 148, 111, false);
                    doctorDate.Name = "doctorDate";
                    doctorDate.Value = @"Tarih:
";

                    doctorSignature1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 111, 148, 116, false);
                    doctorSignature1.Name = "doctorSignature1";
                    doctorSignature1.Value = @"İmza:";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 95, 39, 101, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1191.TextFont.Size = 11;
                    NewField1191.Value = @"Hasta
";

                    patientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 101, 105, 106, false);
                    patientNameSurname.Name = "patientNameSurname";
                    patientNameSurname.Value = @"Adı Soyadı:
";

                    patientDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 106, 39, 111, false);
                    patientDate.Name = "patientDate";
                    patientDate.Value = @"Tarih:
";

                    patientSignature1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 111, 39, 116, false);
                    patientSignature1.Name = "patientSignature1";
                    patientSignature1.Value = @"İmza:";

                    DentalExaminationObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 49, 272, 54, false);
                    DentalExaminationObject.Name = "DentalExaminationObject";
                    DentalExaminationObject.Visible = EvetHayirEnum.ehHayir;
                    DentalExaminationObject.FieldType = ReportFieldTypeEnum.ftVariable;
                    DentalExaminationObject.Value = @"{@DentalExaminationObject@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField111.CalcValue = NewField111.Value;
                    doctorNameSurname.CalcValue = doctorNameSurname.Value;
                    doctorDate.CalcValue = doctorDate.Value;
                    doctorSignature1.CalcValue = doctorSignature1.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    patientNameSurname.CalcValue = patientNameSurname.Value;
                    patientDate.CalcValue = patientDate.Value;
                    patientSignature1.CalcValue = patientSignature1.Value;
                    DentalExaminationObject.CalcValue = MyParentReport.RuntimeParameters.DentalExaminationObject.ToString();
                    return new TTReportObject[] { NewField17,NewField18,NewField191,NewField101,NewField111,doctorNameSurname,doctorDate,doctorSignature1,NewField1191,patientNameSurname,patientDate,patientSignature1,DentalExaminationObject};
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
            public DentalRootCanalOperationInfoReport MyParentReport
            {
                get { return (DentalRootCanalOperationInfoReport)ParentReport; }
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
                public DentalRootCanalOperationInfoReport MyParentReport
                {
                    get { return (DentalRootCanalOperationInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 221;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 8, 201, 148, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 12;
                    NewField1.Value = @"Tedaviye başlamadan önce hastaların sistemik rahatsızlıklarını (kalp, şeker, tansiyon vb.), bulaşıcı bir hastalığı (hepatit gibi), varsa kullandığı ilaçları lıekimiyle paylaşması zorunludur. Hekim,gerekli gördüğü takdirde diğer branşlardan konsültasyon isteme hakkına sahiptir. Tedavimi yapacak bekime kendi genel sağlığım, kullandığım ilaçlar ve özel durwnlarım hakkında tam ve doğru bilgiler verdiğimi ifade ederim. Hekimim, yukaııda bahsi geçen tedaviler için oluşabilecek ve aşağıda özetlenen muhtemel yan etkiler hakkında beni sözlü olarak da detaylı bir şekilde bilgilendirmiş, bu tedaviyi reddetmem durumunda karşılaşabileceğim tıbbi sorunlar detaylı olarak anlatılmış, hbbi uygulamanın gereğince yapılmış olması halinde dahi uygulanan tedavilerle ilgili tam bir memnuniyet sözü veya garanti verilmemiştir. Dolgu: Çürüyen diş dokulannın yerine yapay maddelerle doldurma işlemidir. Dolgu ile hastanın sıcak soğuk hassasiyetinin, estetik kaygısının iki diş arasında gıda birikmesi gibi sorunların giderilmesi ve dişin çiğnemeye katılarak fonksiyona kavuşması beklenir. Derin çürüklerde hastanın çok belirgin şikayetleri olmasa bile dişin siniri açığa çıkabilir. Çürüğün sinire uzaklığma göre dolgudan sonra soğuk sıcak hassasiyeti olabilmektedir. Su içerken dahi ilk zamanlar aşırı hassaslık olabilir. Birkaç ay ya da daha kısa sürede bu şikayet azalabilir yada azalmaz artabilir. Artarsa dolgunun altmda çürük bırakılmasından değil; sinirin uyaranlar etkisi ile yorulmasından, yozlaşmasından kaynaklanmaktadır. Bu durumda kanal tedavisi yapılır. Her dolgu yapımından sonra az ya da çok kanal tedavisi ihtimali vardır. Dolgu yapılmaz ise çürük ilerler ve kanal tedavisine gidebilir.

Kanal Tedavisi: Çürüğün sinire kadar ulaşması ya da darbe sonucunda kırılan dişte açığa çıkan sinir dokusunun köklerdeki siniri de kapsayarak çıkarılması ve yapay maddelerle dişin doldurulması işlemidir. Bu işlemde bir tür dolgudur. İşlem sonrasında ısırmada ağrı duyulabilir. Bu durum geçici bir durumdur. Süresi kişiden kişiye değişebilir. Eğer kanal tedavisi yapılmasına rağmen, kendiliğinden başlayan zonklama tarzında şiddetli ağrılar oluşursa, dişin çekilmesi gerekebilir. Bu durumda son kararı doktorunuzun vermesi gerekmektedir. Kanal tedavisi başarılı olsa bile bu durum o dişin bir daha ağrımayacağı anlamına gelmez. Kanal tedavisi dişi ağızda tutabilmek için denenen son tedavidir.
Tedavi sonrasında bir hafta on gün kadar dişin üzerine basarken , yemek yerken ağrı şikayeti olabilir. Anestezi yapılan bölgede birkaç gün hassasiyet olabilir, bu şikayetin zamanla azalarak geçmesi beklenir. Kanal tedavisi dişin durumuna göre tek seans veya birkaç seansta yapılabilir. Kanal tedavisini yaptırmak istemeyen, bulantı refleksinden dolayı film çektirmekte zorlanan hastalar dişlerini çektirebilir.

Dolgu ve kanal tedavisi gerektiği durumlarda tedavi yapılmadığı takdiı·de: Fokalenfeksiyon kaynağı olan diş ağızda bulunduğu sürece tüm organlara enfeksiyon riski oluştumıaktadır. Ağrı de am eder, tedavi edilmediği takdirde diş çekilme zorunda kalır. İşlemin riskleri ve komplikasyonları: kanal tedavisi sırasında kullanılan aletler kanal içerisinde kırılabilir, diş çekime gidebilir. Dişin konumu, hastanın ağız açıklığı, dil, yanak ve komşu dokuların anatomik yapısı nedeniyle çalışma sırasında alet ağız boşluğuna düşebilir. Hasta diliyle refleks olarak kanal aletini geriye itebilir, aspire edebilir. (solunum yoluna kaçabilir.) İşlemin tahmini süresi: Dolgu tedavisi dişin ağızdaki konumuna ve dolgu tipine göre 15-30 dakika sürebilir. Kanal tedavisi 30 dk- 1 saat arasında sürebilir.

Lokal Anestezi: İnsan vücudunda his iletimi yapan sinirlerin, belirli bir bölgesinin anestezik maddelerle ( lidokain, mepivikain vb.) geçici süre iletim yapılmasının engellenmesi olarak kısaca tarif edilebilir. Diş hekimliğinde kullanılan lokal anestezi sonucu oluşan his kaybı süresi, kullanılan anestezik maddeye, anestezinin uygulandığı bölgeye ve kişinin anatomik yapısına göre, 1-4 saat arasında  değişiklik gösterir. Anestezi sonucu fasiyal paralizi (geçici yüz felci), amfizem (yüzde şişlik), lıematom (yüzde kızarma , morarma) gibi komplikasyonlar oluşabilir. Bu durumlar geçici olup endişe edilmesine gerek yoktur. Anestezi sonucunda ayrıca alerjik ";

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

        public DentalRootCanalOperationInfoReport()
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
            Name = "DENTALROOTCANALOPERATIONINFOREPORT";
            Caption = "Kanal Tedavisi";
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