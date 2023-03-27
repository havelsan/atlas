
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
    public partial class DentalConstantProsthesisInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string DentalExaminationObject = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class headerGroup : TTReportGroup
        {
            public DentalConstantProsthesisInfoReport MyParentReport
            {
                get { return (DentalConstantProsthesisInfoReport)ParentReport; }
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
                public DentalConstantProsthesisInfoReport MyParentReport
                {
                    get { return (DentalConstantProsthesisInfoReport)ParentReport; }
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
                    NewField2.Value = @"SABİT PROTEZ BİLGİLENDİRME RIZA BELGESİ";

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
                public DentalConstantProsthesisInfoReport MyParentReport
                {
                    get { return (DentalConstantProsthesisInfoReport)ParentReport; }
                }
                
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField19;
                public TTReportField NewField10;
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

                    Height = 83;
                    RepeatCount = 0;
                    
                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 56, 29, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Italic = true;
                    NewField7.Value = @"Yapılacak Protez Türü";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 6, 204, 29, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 56, 148, 62, false);
                    NewField19.Name = "NewField19";
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Size = 11;
                    NewField19.Value = @"Hekim
";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 35, 206, 52, false);
                    NewField10.Name = "NewField10";
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Size = 11;
                    NewField10.Value = @"Okudum Anladım. Kabul ediyor ve onaylıyorum. (Hasta kendi el yazısı ile yazacak)

....................................................................................................................................................
";

                    DentalExaminationObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 51, 255, 56, false);
                    DentalExaminationObject.Name = "DentalExaminationObject";
                    DentalExaminationObject.Visible = EvetHayirEnum.ehHayir;
                    DentalExaminationObject.FieldType = ReportFieldTypeEnum.ftVariable;
                    DentalExaminationObject.Value = @"{@DentalExaminationObject@}";

                    doctorNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 62, 206, 67, false);
                    doctorNameSurname.Name = "doctorNameSurname";
                    doctorNameSurname.Value = @"Adı Soyadı:
";

                    doctorDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 67, 148, 72, false);
                    doctorDate.Name = "doctorDate";
                    doctorDate.Value = @"Tarih:
";

                    doctorSignature = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 72, 148, 77, false);
                    doctorSignature.Name = "doctorSignature";
                    doctorSignature.Value = @"İmza:";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 56, 39, 62, false);
                    NewField191.Name = "NewField191";
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Size = 11;
                    NewField191.Value = @"Hasta
";

                    patientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 62, 105, 67, false);
                    patientNameSurname.Name = "patientNameSurname";
                    patientNameSurname.Value = @"Adı Soyadı:
";

                    patientDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 67, 39, 72, false);
                    patientDate.Name = "patientDate";
                    patientDate.Value = @"Tarih:
";

                    patientSignature = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 72, 39, 77, false);
                    patientSignature.Name = "patientSignature";
                    patientSignature.Value = @"İmza:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField10.CalcValue = NewField10.Value;
                    DentalExaminationObject.CalcValue = MyParentReport.RuntimeParameters.DentalExaminationObject.ToString();
                    doctorNameSurname.CalcValue = doctorNameSurname.Value;
                    doctorDate.CalcValue = doctorDate.Value;
                    doctorSignature.CalcValue = doctorSignature.Value;
                    NewField191.CalcValue = NewField191.Value;
                    patientNameSurname.CalcValue = patientNameSurname.Value;
                    patientDate.CalcValue = patientDate.Value;
                    patientSignature.CalcValue = patientSignature.Value;
                    return new TTReportObject[] { NewField7,NewField8,NewField19,NewField10,DentalExaminationObject,doctorNameSurname,doctorDate,doctorSignature,NewField191,patientNameSurname,patientDate,patientSignature};
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
            public DentalConstantProsthesisInfoReport MyParentReport
            {
                get { return (DentalConstantProsthesisInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
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
                public DentalConstantProsthesisInfoReport MyParentReport
                {
                    get { return (DentalConstantProsthesisInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 147;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 207, 142, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 12;
                    NewField1.Value = @"1- Tanı işlemlerim sonucunda tedavi olarak yapılması planlanan işlemler alternatif önerilen protetik uygulamaların seçenekleri ve girişim yöntemleri,
2- Protetik işlemler sırasında uygulanan antibiyotik, ağrı kesici ve lokal anestezik ilaçlarla uyuşturmaya bağlı olarak his kaybı, şişlik, yanakta morarma, kaşıntı, bulantı ve nadirde olsa anaflaktik şok gibi yan etkiler oluşabileceği,
3- Tedavinin başarılı olacağı veya mutlaka tatminkâr sonuçlar elde edileceği konusunda hiçbir garanti, teminat veya söz verilemeyeceği,
4- Köprü sökümü sırasında köprü ayağı olan dişlerin kırılabileceği, köprü ile beraber çıkabileceği, buna bağlı olarak tedavi planı ve randevu tarihinin değişebileceği,
5- Önerilen protetik uygulamanın olası risk ve yararları ile ağız sağlığı açısından etkisi,
6- Diş kesimi sırasında, dişin pozisyonuna bağlı olarak kanal tedavisi gereksinimi olabileceği,
7- Dişler kesildikten sonra ve kron-köprü protezler takıldıktan sonra da ağrı olabileceği, protezlere alışmakta kısa bir süre zorlanma yaşanacağı,
8- Önerilen protetik tedavinin uygulanması durumunda mevcut dişlerde uzama, devrilme olabileceği; çiğneme fonksiyonunun tam gerçekleşemeyeceği,
9- Protezin renginin doğal dişlerin rengine uyum sağlayamama olasılığı,
10- Klinik işlemlerin hekim tarafından, laboratuvar işlemlerinin ihale ile belirlenmiş diş protez laboratuvarı tarafından yapılacağı,
11- Sabit protetik tedavi sonucunda çiğneme fonksiyonunun geri kazanılacağı (belirli bir yüzde oranında),
12- Daha önce yapılan protetik uygulamaların şu anki protetik uygulamaların başarılı olmasında önemli olduğu,
13- Protetik uygulamalar sonrası uymam gereken kurallar takip zorunluluğu, uyum aşamalarındaki sorunlar ve yapılması gerekenler ayrıntılı olarak anlatıldı. Konulan tanıya ilgili alternatif tedavileri, bunların risklerini yapılan tedavinin risk ve yan etkilerini biliyorum. Başarı olasılığını biliyorum. Tedavi olmadığımda neler olabileceğini biliyorum. Bana söylenenlerin tümünü anladım. Doktorum tüm sorularımı yanıtladı. Aydınlatılmış onam formunun anlamını biliyorum. Bana müdahale yapacak kişinin kim olduğunu biliyorum. Kendi özgür irademle karar veriyorum. Bu müdahaleyi kabul etmeme ya da istediğim zaman vazgeçme hakkımın olduğunu biliyorum.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 89, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.NoClip = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"PROTETİK TEDAVİ (SABİT PROTEZ)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { NewField1,NewField2};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DentalConstantProsthesisInfoReport()
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
            Name = "DENTALCONSTANTPROSTHESISINFOREPORT";
            Caption = "Sabit Protez Onam Formu";
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