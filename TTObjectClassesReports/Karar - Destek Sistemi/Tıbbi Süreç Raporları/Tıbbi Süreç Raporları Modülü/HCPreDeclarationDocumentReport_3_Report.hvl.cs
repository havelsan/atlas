
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
    /// Sağlık Kurulu Ön Bildirim Belgesi(Dosya Sureti,Sahsa, XXXXXXlik Şubesine ve Birliğe)
    /// </summary>
    public partial class HCPreDeclarationDocumentReport_3 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("C7203EFB-0742-4709-9E32-6D3608F9C34F");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentReport_3 MyParentReport
            {
                get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommittee", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public HCPreDeclarationDocumentReport_3 MyParentReport
                {
                    get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public HCPreDeclarationDocumentReport_3 MyParentReport
                {
                    get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentReport_3 MyParentReport
            {
                get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField64 { get {return Body().NewField64;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewFieldA3 { get {return Body().NewFieldA3;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField DYERTARIH { get {return Body().DYERTARIH;} }
            public TTReportField TCKN { get {return Body().TCKN;} }
            public TTReportField EVRAKNO { get {return Body().EVRAKNO;} }
            public TTReportField NewFieldA52 { get {return Body().NewFieldA52;} }
            public TTReportField RAPORSEBEP { get {return Body().RAPORSEBEP;} }
            public TTReportField FOTOGRAF { get {return Body().FOTOGRAF;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField RAPOR_NO { get {return Body().RAPOR_NO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField NewField67 { get {return Body().NewField67;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField NewField0 { get {return Body().NewField0;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField28 { get {return Body().NewField28;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewFieldQ52 { get {return Body().NewFieldQ52;} }
            public TTReportField XXXXXXLIKSUBE { get {return Body().XXXXXXLIKSUBE;} }
            public TTReportField NewField52 { get {return Body().NewField52;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField NewField770 { get {return Body().NewField770;} }
            public TTReportField NewField77 { get {return Body().NewField77;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField82 { get {return Body().NewField82;} }
            public TTReportField BASTABIP { get {return Body().BASTABIP;} }
            public TTReportField AdditionalMembers { get {return Body().AdditionalMembers;} }
            public TTReportField S5 { get {return Body().S5;} }
            public TTReportField S8 { get {return Body().S8;} }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField RAPORTARIHI2 { get {return Body().RAPORTARIHI2;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField EVRAKTARIHI { get {return Body().EVRAKTARIHI;} }
            public TTReportField NewField135 { get {return Body().NewField135;} }
            public TTReportField DOSYASURETIBASLIK { get {return Body().DOSYASURETIBASLIK;} }
            public TTReportField SKULBL1 { get {return Body().SKULBL1;} }
            public TTReportField SKULBL2 { get {return Body().SKULBL2;} }
            public TTReportField SKULBL3 { get {return Body().SKULBL3;} }
            public TTReportField ADATE { get {return Body().ADATE;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField NewField153 { get {return Body().NewField153;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Body().TCKIMLIKNOBARKOD;} }
            public TTReportField FOTOGRAF1 { get {return Body().FOTOGRAF1;} }
            public TTReportField NewField197 { get {return Body().NewField197;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField MUAYENEAMACI { get {return Body().MUAYENEAMACI;} }
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
                public HCPreDeclarationDocumentReport_3 MyParentReport
                {
                    get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField64;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewFieldA3;
                public TTReportField NewField14;
                public TTReportField DYERTARIH;
                public TTReportField TCKN;
                public TTReportField EVRAKNO;
                public TTReportField NewFieldA52;
                public TTReportField RAPORSEBEP;
                public TTReportField FOTOGRAF;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField RAPOR_NO;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField67;
                public TTReportField TANI;
                public TTReportField NewField0;
                public TTReportField ADISOYADI;
                public TTReportField BABAADI;
                public TTReportField NewField25;
                public TTReportField NewField28;
                public TTReportField NewField29;
                public TTReportField NewFieldQ52;
                public TTReportField XXXXXXLIKSUBE;
                public TTReportField NewField52;
                public TTReportField MAKAM;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField770;
                public TTReportField NewField77;
                public TTReportField HASTANO;
                public TTReportField NewField82;
                public TTReportField BASTABIP;
                public TTReportField AdditionalMembers;
                public TTReportField S5;
                public TTReportField S8;
                public TTReportField XXXXXXADI;
                public TTReportField NewField6;
                public TTReportField RAPORTARIHI2;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField BASLIK;
                public TTReportField DTARIHI;
                public TTReportField EVRAKTARIHI;
                public TTReportField NewField135;
                public TTReportField DOSYASURETIBASLIK;
                public TTReportField SKULBL1;
                public TTReportField SKULBL2;
                public TTReportField SKULBL3;
                public TTReportField ADATE;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE;
                public TTReportField NewField152;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField153;
                public TTReportField BIRLIK;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportField FOTOGRAF1;
                public TTReportField NewField197;
                public TTReportField DECISIONTIME;
                public TTReportField NewField131;
                public TTReportField MUAYENEAMACI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 212, 200, 235, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"";

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 93, 193, 103, false);
                    NewField64.Name = "NewField64";
                    NewField64.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField64.MultiLine = EvetHayirEnum.ehEvet;
                    NewField64.WordBreak = EvetHayirEnum.ehEvet;
                    NewField64.TextFont.Size = 9;
                    NewField64.Value = @"İLGİ: {%EVRAKTARIHI%} gün ve {#HEADER.EVRAKSAYISI#} sayılı sevk yazısı.";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 11, 172, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%BASLIK%}
RAPOR ÖN BİLDİRİM BELGESİ";

                    NewFieldA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 113, 42, false);
                    NewFieldA3.Name = "NewFieldA3";
                    NewFieldA3.Value = @"KONU   : Sağlık Kurulu Raporu Hakkında";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 34, 30, 38, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"SAĞ.KRL:";

                    DYERTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 261, 200, 265, false);
                    DYERTARIH.Name = "DYERTARIH";
                    DYERTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTARIH.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DYERTARIH.TextFont.Size = 8;
                    DYERTARIH.Value = @"{%DTARIHI%} / ";

                    TCKN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 39, 195, 43, false);
                    TCKN.Name = "TCKN";
                    TCKN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKN.MultiLine = EvetHayirEnum.ehEvet;
                    TCKN.NoClip = EvetHayirEnum.ehEvet;
                    TCKN.WordBreak = EvetHayirEnum.ehEvet;
                    TCKN.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKN.Value = @"{#HEADER.TCNO#}";

                    EVRAKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 34, 158, 38, false);
                    EVRAKNO.Name = "EVRAKNO";
                    EVRAKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKNO.Value = @"{#HEADER.ISLEMNO#}-{#HEADER.PROTOKOLNO#}-{%ADATE%}/SAĞ.KRL.-{#HEADER.ISLEMNO#}";

                    NewFieldA52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 251, 235, 255, false);
                    NewFieldA52.Name = "NewFieldA52";
                    NewFieldA52.Visible = EvetHayirEnum.ehHayir;
                    NewFieldA52.TextFont.Size = 8;
                    NewFieldA52.TextFont.Bold = true;
                    NewFieldA52.Value = @"Hasta Nu :";

                    RAPORSEBEP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, -6, 297, -2, false);
                    RAPORSEBEP.Name = "RAPORSEBEP";
                    RAPORSEBEP.Visible = EvetHayirEnum.ehHayir;
                    RAPORSEBEP.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSEBEP.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSEBEP.Value = @"";

                    FOTOGRAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 55, 193, 83, false);
                    FOTOGRAF.Name = "FOTOGRAF";
                    FOTOGRAF.Visible = EvetHayirEnum.ehHayir;
                    FOTOGRAF.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTOGRAF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF.WordBreak = EvetHayirEnum.ehEvet;
                    FOTOGRAF.TextFont.Size = 8;
                    FOTOGRAF.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 166, 38, 170, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.Value = @"Rapor Tarihi  :";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 170, 38, 174, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 9;
                    NewField4.Value = @"Rapor Nu.     :";

                    RAPOR_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 170, 92, 174, false);
                    RAPOR_NO.Name = "RAPOR_NO";
                    RAPOR_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR_NO.TextFont.Size = 9;
                    RAPOR_NO.Value = @"{#HEADER.RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 166, 92, 170, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.TextFont.Size = 9;
                    RAPORTARIHI.Value = @"{#HEADER.RAPORTARIHI#}";

                    NewField67 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 212, 38, 216, false);
                    NewField67.Name = "NewField67";
                    NewField67.TextFont.Size = 9;
                    NewField67.Value = @"Karar         :";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 174, 200, 212, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 174, 38, 178, false);
                    NewField0.Name = "NewField0";
                    NewField0.TextFont.Size = 9;
                    NewField0.Value = @"Teşhis        :";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 245, 200, 249, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{#HEADER.PNAME#} {#HEADER.PSURNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 257, 200, 261, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#HEADER.FATHERNAME#}";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 245, 66, 249, false);
                    NewField25.Name = "NewField25";
                    NewField25.TextFont.Size = 8;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"Adı Soyadı                   :";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 257, 66, 261, false);
                    NewField28.Name = "NewField28";
                    NewField28.TextFont.Size = 8;
                    NewField28.TextFont.Bold = true;
                    NewField28.Value = @"Baba Adı                     :";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 261, 66, 265, false);
                    NewField29.Name = "NewField29";
                    NewField29.TextFont.Size = 8;
                    NewField29.TextFont.Bold = true;
                    NewField29.Value = @"Doğum Tarihi / Doğum Yeri    :";

                    NewFieldQ52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 265, 66, 269, false);
                    NewFieldQ52.Name = "NewFieldQ52";
                    NewFieldQ52.TextFont.Size = 8;
                    NewFieldQ52.TextFont.Bold = true;
                    NewFieldQ52.Value = @"Sevki Yapan As. Ş. / Birlik  :";

                    XXXXXXLIKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 269, 200, 273, false);
                    XXXXXXLIKSUBE.Name = "XXXXXXLIKSUBE";
                    XXXXXXLIKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE.TextFont.Size = 8;
                    XXXXXXLIKSUBE.Value = @"";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 269, 66, 273, false);
                    NewField52.Name = "NewField52";
                    NewField52.TextFont.Size = 8;
                    NewField52.TextFont.Bold = true;
                    NewField52.Value = @"N.Kayıtlı Olduğu As Ş.       :";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 265, 200, 269, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 241, 200, 245, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#HEADER.TCNO#}";

                    NewField770 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 236, 66, 240, false);
                    NewField770.Name = "NewField770";
                    NewField770.TextFont.Size = 8;
                    NewField770.TextFont.Bold = true;
                    NewField770.TextFont.Underline = true;
                    NewField770.Value = @"KİMLİĞİ                      ";

                    NewField77 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 241, 66, 245, false);
                    NewField77.Name = "NewField77";
                    NewField77.TextFont.Size = 8;
                    NewField77.TextFont.Bold = true;
                    NewField77.Value = @"TC Kimlik Nu.                :";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 251, 262, 255, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.Size = 8;
                    HASTANO.Value = @"{#HEADER.PID#}";

                    NewField82 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 104, 193, 129, false);
                    NewField82.Name = "NewField82";
                    NewField82.MultiLine = EvetHayirEnum.ehEvet;
                    NewField82.WordBreak = EvetHayirEnum.ehEvet;
                    NewField82.TextFont.Size = 9;
                    NewField82.Value = @"1. İlgi  ile  XXXXXXmize  sevk  edilen  aşağıda   açık kimliği  yazılı  kişinin, Sağlık Kurulu'ndan almış olduğu karar ile rapor tarih ve numarası aşağıda çıkarılmıştır. 

2. Düzenlenmekte olan Sağlık Kurulu raporu üst onay makamınca onaylandıktan sonra gönderilecektir. 

Arz / Rica ederim. ";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 140, 192, 159, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Size = 8;
                    BASTABIP.Value = @"";

                    AdditionalMembers = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 140, 146, 159, false);
                    AdditionalMembers.Name = "AdditionalMembers";
                    AdditionalMembers.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdditionalMembers.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionalMembers.MultiLine = EvetHayirEnum.ehEvet;
                    AdditionalMembers.WordBreak = EvetHayirEnum.ehEvet;
                    AdditionalMembers.ExpandTabs = EvetHayirEnum.ehEvet;
                    AdditionalMembers.TextFont.Size = 8;
                    AdditionalMembers.Value = @"";

                    S5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 94, 451, 108, false);
                    S5.Name = "S5";
                    S5.Visible = EvetHayirEnum.ehHayir;
                    S5.FieldType = ReportFieldTypeEnum.ftVariable;
                    S5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S5.MultiLine = EvetHayirEnum.ehEvet;
                    S5.WordBreak = EvetHayirEnum.ehEvet;
                    S5.ExpandTabs = EvetHayirEnum.ehEvet;
                    S5.TextFont.Size = 8;
                    S5.Value = @"";

                    S8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 112, 451, 126, false);
                    S8.Name = "S8";
                    S8.Visible = EvetHayirEnum.ehHayir;
                    S8.FieldType = ReportFieldTypeEnum.ftVariable;
                    S8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S8.MultiLine = EvetHayirEnum.ehEvet;
                    S8.WordBreak = EvetHayirEnum.ehEvet;
                    S8.ExpandTabs = EvetHayirEnum.ehEvet;
                    S8.TextFont.Size = 8;
                    S8.Value = @"";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 97, 252, 101, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.TextFont.Size = 8;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 34, 30, 38, false);
                    NewField6.Name = "NewField6";
                    NewField6.Value = @"";

                    RAPORTARIHI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 34, 195, 38, false);
                    RAPORTARIHI2.Name = "RAPORTARIHI2";
                    RAPORTARIHI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI2.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTARIHI2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI2.Value = @"{@printdate@}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 134, 192, 139, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 8;
                    NewField7.Value = @"Sağlık Kurulu Başkanı";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 105, 233, 110, false);
                    NewField8.Name = "NewField8";
                    NewField8.Visible = EvetHayirEnum.ehHayir;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"İLGİ:";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 114, 226, 118, false);
                    NewField9.Name = "NewField9";
                    NewField9.Visible = EvetHayirEnum.ehHayir;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"1.";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 120, 226, 124, false);
                    NewField10.Name = "NewField10";
                    NewField10.Visible = EvetHayirEnum.ehHayir;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"2.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 30, 42, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"KONU   :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 34, 31, 38, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"SAĞ.KRL:";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 25, 241, 30, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 33, 240, 38, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#HEADER.DTARIHI#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 38, 240, 43, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.Value = @"{#HEADER.EVRAKTARIHI#}";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 84, 203, 92, false);
                    NewField135.Name = "NewField135";
                    NewField135.TextColor = System.Drawing.Color.Gray;
                    NewField135.MultiLine = EvetHayirEnum.ehEvet;
                    NewField135.NoClip = EvetHayirEnum.ehEvet;
                    NewField135.WordBreak = EvetHayirEnum.ehEvet;
                    NewField135.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField135.TextFont.Size = 8;
                    NewField135.Value = @"XXXXXXliğe Elverişli
Değildir Kararlılarda";

                    DOSYASURETIBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 66, 161, 86, false);
                    DOSYASURETIBASLIK.Name = "DOSYASURETIBASLIK";
                    DOSYASURETIBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSYASURETIBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOSYASURETIBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    DOSYASURETIBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    DOSYASURETIBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOSYASURETIBASLIK.TextFont.Bold = true;
                    DOSYASURETIBASLIK.Value = @"DOSYA SURETİ";

                    SKULBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 134, 45, 139, false);
                    SKULBL1.Name = "SKULBL1";
                    SKULBL1.Visible = EvetHayirEnum.ehHayir;
                    SKULBL1.TextFont.Size = 8;
                    SKULBL1.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 134, 90, 139, false);
                    SKULBL2.Name = "SKULBL2";
                    SKULBL2.Visible = EvetHayirEnum.ehHayir;
                    SKULBL2.TextFont.Size = 8;
                    SKULBL2.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 134, 136, 139, false);
                    SKULBL3.Name = "SKULBL3";
                    SKULBL3.Visible = EvetHayirEnum.ehHayir;
                    SKULBL3.TextFont.Size = 8;
                    SKULBL3.Value = @"Sağlık Kurulu Üyesi";

                    ADATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 45, 241, 50, false);
                    ADATE.Name = "ADATE";
                    ADATE.Visible = EvetHayirEnum.ehHayir;
                    ADATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADATE.TextFormat = @"Short Date";
                    ADATE.TextFont.Name = "Arial Narrow";
                    ADATE.TextFont.CharSet = 1;
                    ADATE.Value = @"{#HEADER.ADATE#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 234, 242, 239, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#HEADER.DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 242, 242, 247, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#HEADER.DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 226, 242, 231, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#HEADER.DOGUMYERIULKE#}";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 253, 66, 257, false);
                    NewField152.Name = "NewField152";
                    NewField152.TextFont.Size = 8;
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @"Sınıf ve Rütbesi             :";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 253, 200, 257, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 249, 66, 253, false);
                    NewField153.Name = "NewField153";
                    NewField153.TextFont.Size = 8;
                    NewField153.TextFont.Bold = true;
                    NewField153.Value = @"Birlik                       :";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 249, 200, 253, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 44, 193, 54, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    FOTOGRAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 55, 193, 83, false);
                    FOTOGRAF1.Name = "FOTOGRAF1";
                    FOTOGRAF1.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTOGRAF1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF1.TextFont.Size = 8;
                    FOTOGRAF1.Value = @"FOTOGRAF";

                    NewField197 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 276, 200, 293, false);
                    NewField197.Name = "NewField197";
                    NewField197.MultiLine = EvetHayirEnum.ehEvet;
                    NewField197.NoClip = EvetHayirEnum.ehEvet;
                    NewField197.WordBreak = EvetHayirEnum.ehEvet;
                    NewField197.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField197.TextFont.Size = 8;
                    NewField197.Value = @"Not : ""İlgili personelin ön raporudur. Bu belge ile kesin işlem yapılamaz. Kat'i Rapor onay işlemleri tamamlandıktan sonra MSB.lığı ve XXXXXX Sağlık K.lığınca gönderilecektir. ""XXXXXXliğe Elverişli Değildir"", ""XXXXXXnde Görev Yapamaz"" kararı alan personel rapor onaylanana kadar sıhhi izinli sayılır. Ayrıca bu ön rapora istinaden erbaş/erlerin şahsi dosyaları XXXXXXlik Şubelerine gönderilir.""  ";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 212, 240, 217, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 162, 38, 166, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.Value = @"Muayene Amacı :";

                    MUAYENEAMACI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 162, 200, 166, false);
                    MUAYENEAMACI.Name = "MUAYENEAMACI";
                    MUAYENEAMACI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEAMACI.TextFont.Size = 9;
                    MUAYENEAMACI.Value = @"{#HEADER.SKSEBEBI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.HEADER.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    KARAR.CalcValue = @"";
                    EVRAKTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField64.CalcValue = @"İLGİ: " + MyParentReport.MAIN.EVRAKTARIHI.FormattedValue + @" gün ve " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "") + @" sayılı sevk yazısı.";
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    XXXXXXBASLIK.CalcValue = MyParentReport.MAIN.BASLIK.CalcValue + @"
RAPOR ÖN BİLDİRİM BELGESİ";
                    NewFieldA3.CalcValue = NewFieldA3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    DYERTARIH.CalcValue = MyParentReport.MAIN.DTARIHI.FormattedValue + @" / ";
                    TCKN.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    ADATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adate) : "");
                    EVRAKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "") + @"-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Protokolno) : "") + @"-" + MyParentReport.MAIN.ADATE.FormattedValue + @"/SAĞ.KRL.-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    NewFieldA52.CalcValue = NewFieldA52.Value;
                    RAPORSEBEP.CalcValue = @"";
                    FOTOGRAF.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    RAPOR_NO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField67.CalcValue = NewField67.Value;
                    TANI.CalcValue = @"";
                    NewField0.CalcValue = NewField0.Value;
                    ADISOYADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    NewField25.CalcValue = NewField25.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewFieldQ52.CalcValue = NewFieldQ52.Value;
                    XXXXXXLIKSUBE.CalcValue = @"";
                    NewField52.CalcValue = NewField52.Value;
                    MAKAM.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField770.CalcValue = NewField770.Value;
                    NewField77.CalcValue = NewField77.Value;
                    HASTANO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    NewField82.CalcValue = NewField82.Value;
                    BASTABIP.CalcValue = @"";
                    AdditionalMembers.CalcValue = @"";
                    S5.CalcValue = @"";
                    S8.CalcValue = @"";
                    NewField6.CalcValue = NewField6.Value;
                    RAPORTARIHI2.CalcValue = DateTime.Now.ToShortDateString();
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField135.CalcValue = NewField135.Value;
                    DOSYASURETIBASLIK.CalcValue = @"DOSYA SURETİ";
                    SKULBL1.CalcValue = SKULBL1.Value;
                    SKULBL2.CalcValue = SKULBL2.Value;
                    SKULBL3.CalcValue = SKULBL3.Value;
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriulke) : "");
                    NewField152.CalcValue = NewField152.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField153.CalcValue = NewField153.Value;
                    BIRLIK.CalcValue = @"";
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    FOTOGRAF1.CalcValue = FOTOGRAF1.Value;
                    NewField197.CalcValue = NewField197.Value;
                    DECISIONTIME.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    MUAYENEAMACI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { KARAR,EVRAKTARIHI,NewField64,BASLIK,XXXXXXBASLIK,NewFieldA3,NewField14,DTARIHI,DYERTARIH,TCKN,ADATE,EVRAKNO,NewFieldA52,RAPORSEBEP,FOTOGRAF,NewField3,NewField4,RAPOR_NO,RAPORTARIHI,NewField67,TANI,NewField0,ADISOYADI,BABAADI,NewField25,NewField28,NewField29,NewFieldQ52,XXXXXXLIKSUBE,NewField52,MAKAM,TCKIMLIKNO,NewField770,NewField77,HASTANO,NewField82,BASTABIP,AdditionalMembers,S5,S8,NewField6,RAPORTARIHI2,NewField7,NewField8,NewField9,NewField10,NewField11,NewField12,NewField135,DOSYASURETIBASLIK,SKULBL1,SKULBL2,SKULBL3,DYERILCE,DYERIL,DYERULKE,NewField152,SINIFRUTBE,NewField153,BIRLIK,TCKIMLIKNOBARKOD,FOTOGRAF1,NewField197,DECISIONTIME,NewField131,MUAYENEAMACI,XXXXXXADI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPreDeclarationDocumentReport_3)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
//
            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
            
            /* Yakınlık derecesinin artık görünmemesi istendi (27.07.2016 Mustafa)
            if (hc.Episode.MyRelationship() != null)
            {
                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            }
             */
            
            //SK Başkanı
            const int SPECIALITY_COUNT = 25;
            string sMemberSpeciality = "";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string sEmpID = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string sName = member.MemberDoctor.Name;
                    string sTitle = ""; //(hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass.ShortName);
                    sTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    sTitle += (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);

                    string specialityRow1 = "";
                    string specialityRow2 = "";

                    if (member.MemberDoctor.GetSpeciality() != null)
                        sMemberSpeciality = member.MemberDoctor.GetSpeciality().Name;

                    if (sMemberSpeciality != "")
                    {
                        sMemberSpeciality += " Uzm.";
                        if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                        {
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT * 2)
                                sMemberSpeciality = sMemberSpeciality.Substring(0, SPECIALITY_COUNT * 2);

                            specialityRow1 = sMemberSpeciality.Substring(0, SPECIALITY_COUNT);
                            specialityRow2 = sMemberSpeciality.Substring(SPECIALITY_COUNT, sMemberSpeciality.Length - SPECIALITY_COUNT);
                        }
                        else
                        {
                            specialityRow1 = sMemberSpeciality;
                            specialityRow2 = "";
                        }
                    }
                    else
                    {
                        specialityRow1 = "";
                        specialityRow2 = "";
                    }

                    string sMasterText = sName + "\n" + sTitle + "(" + sEmpID + ")" + "\n" + specialityRow1 + "\n" + specialityRow2;

                    this.BASTABIP.CalcValue = sMasterText;
                }
            }
            
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                string maddeDilimFikra = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    maddeDilimFikra += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    maddeDilimFikra += "  ";
                }
                maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                maddeDilimFikra += "]";
                
                this.KARAR.CalcValue = maddeDilimFikra + "\n";
            }

            // Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\n";
            }
            
            
            // Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            //AdditionalMembers
            //            if (hc.UnsuitableForMilitaryService == true)
            //            {
            //                if(hc.MemberOfHealthCommittee != null)
            //                {
            //                    string sCrLf = "\r\n";
            //                    string sMembersText = "";// = sCrLf;
            //                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId;
//
            //                    const int COLUMN_COUNT = 3;
            //                    const int SPACE_COUNT = 27;
            //                    int nCounter = 0;
            //                    int nRow = 0;
//
            //                    //string sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
//
            //                    foreach(HealthCommitteAdditionalMemberGrid pMember in hc.MemberOfHealthCommittee.AdditionalMembers)
            //                    {
            //                        sMemberName = pMember.Doctor.Name;
            //                        sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
            //                        sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
            //                        sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
            //                        sMemberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
//
            //                        //sHeaderRow = sHeaderRow.Insert(nCounter, "Sağlık Kurulu Üyesi");
            //                        sNameRow = sNameRow.Insert(nCounter, sMemberName);
            //                        //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
            //                        //sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);
            //                        sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
            //                        //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
//
            //                        if (pMember.Doctor.GetSpeciality() != null)
            //                            sMemberSpeciality = pMember.Doctor.GetSpeciality().Name;
            //                        else
            //                            sMemberSpeciality = "";
//
            //                        if (sMemberSpeciality != "")
            //                        {
            //                            sMemberSpeciality += " Uzm.";
            //                            if (sMemberSpeciality.Length > SPECIALITY_COUNT)
            //                            {
            //                                if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
            //                                    sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
//
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
            //                            }
            //                            else
            //                            {
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            sTitleRow = sTitleRow.Insert(nCounter, "");
            //                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                        }
//
            //                        nCounter += SPACE_COUNT;
//
            //                        nRow = nCounter / SPACE_COUNT;
            //                        int nRate = nRow % COLUMN_COUNT;
            //                        if (nRate == 0)
            //                        {
            //                            //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                            //sMembersText += sHeaderRow + "\r\n";
            //                            sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sNameRow + "\r\n";
            //                            sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sRankRow + "\r\n";
            //                            sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sTitleRow + "\r\n";
            //                            sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sSpecialityRow + "\r\n";
//
//
            //                            //sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sSpecialityRow = new string(' ',SPACE_COUNT * COLUMN_COUNT);
//
            //                            sMembersText +=  sCrLf + sCrLf + sCrLf;
            //                            nCounter = 0;
            //                        }
            //                    }
//
            //                    //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                    //sMembersText += sHeaderRow + "\r\n";
            //                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sNameRow + "\r\n";
            //                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sRankRow + "\r\n";
            //                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sTitleRow + "\r\n";
            //                    sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sSpecialityRow + "\r\n";
//
            //                    this.AdditionalMembers.CalcValue = sMembersText;
//
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 0)
            //                        this.SKULBL1.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 1)
            //                        this.SKULBL2.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 2)
            //                        this.SKULBL3.Visible = EvetHayirEnum.ehEvet;
            //                }
            //                this.FOTOGRAF.Visible = EvetHayirEnum.ehEvet;
            //                this.NewField135.Visible = EvetHayirEnum.ehHayir;
            //                this.FOTOGRAF1.Visible = EvetHayirEnum.ehHayir;
            //            }

            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIlce;
                else
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            }
            else if (dogumIl.Trim() != "")
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            else
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumUlke;
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCPREDECREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKN.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKN.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class SAHISGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentReport_3 MyParentReport
            {
                get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
            }

            new public SAHISGroupBody Body()
            {
                return (SAHISGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField46 { get {return Body().NewField46;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewFieldA { get {return Body().NewFieldA;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField DYERTARIH { get {return Body().DYERTARIH;} }
            public TTReportField TCKN { get {return Body().TCKN;} }
            public TTReportField EVRAKNO { get {return Body().EVRAKNO;} }
            public TTReportField NewFieldA125 { get {return Body().NewFieldA125;} }
            public TTReportField RAPORSEBEP { get {return Body().RAPORSEBEP;} }
            public TTReportField FOTOGRAF { get {return Body().FOTOGRAF;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField RAPOR_NO { get {return Body().RAPOR_NO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField NewField176 { get {return Body().NewField176;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField NewField182 { get {return Body().NewField182;} }
            public TTReportField NewField192 { get {return Body().NewField192;} }
            public TTReportField NewFieldQ125 { get {return Body().NewFieldQ125;} }
            public TTReportField XXXXXXLIKSUBE { get {return Body().XXXXXXLIKSUBE;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField NewField1077 { get {return Body().NewField1077;} }
            public TTReportField NewField177 { get {return Body().NewField177;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField28 { get {return Body().NewField28;} }
            public TTReportField BASTABIP { get {return Body().BASTABIP;} }
            public TTReportField AdditionalMembers { get {return Body().AdditionalMembers;} }
            public TTReportField S15 { get {return Body().S15;} }
            public TTReportField S18 { get {return Body().S18;} }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField RAPORTARIHI2 { get {return Body().RAPORTARIHI2;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField01 { get {return Body().NewField01;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField EVRAKTARIHI { get {return Body().EVRAKTARIHI;} }
            public TTReportField NewField531 { get {return Body().NewField531;} }
            public TTReportField SAHSINADINABASLIK { get {return Body().SAHSINADINABASLIK;} }
            public TTReportField SKULBL1 { get {return Body().SKULBL1;} }
            public TTReportField SKULBL2 { get {return Body().SKULBL2;} }
            public TTReportField SKULBL3 { get {return Body().SKULBL3;} }
            public TTReportField ADATE { get {return Body().ADATE;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportField NewField1251 { get {return Body().NewField1251;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField NewField1351 { get {return Body().NewField1351;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Body().TCKIMLIKNOBARKOD;} }
            public TTReportField FOTOGRAF1 { get {return Body().FOTOGRAF1;} }
            public TTReportField NewField197 { get {return Body().NewField197;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField MUAYENEAMACI { get {return Body().MUAYENEAMACI;} }
            public SAHISGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SAHISGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SAHISGroupBody(this);
            }

            public partial class SAHISGroupBody : TTReportSection
            {
                public HCPreDeclarationDocumentReport_3 MyParentReport
                {
                    get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField46;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewFieldA;
                public TTReportField NewField141;
                public TTReportField DYERTARIH;
                public TTReportField TCKN;
                public TTReportField EVRAKNO;
                public TTReportField NewFieldA125;
                public TTReportField RAPORSEBEP;
                public TTReportField FOTOGRAF;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField RAPOR_NO;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField176;
                public TTReportField TANI;
                public TTReportField NewField10;
                public TTReportField ADISOYADI;
                public TTReportField BABAADI;
                public TTReportField NewField152;
                public TTReportField NewField182;
                public TTReportField NewField192;
                public TTReportField NewFieldQ125;
                public TTReportField XXXXXXLIKSUBE;
                public TTReportField NewField125;
                public TTReportField MAKAM;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField1077;
                public TTReportField NewField177;
                public TTReportField HASTANO;
                public TTReportField NewField28;
                public TTReportField BASTABIP;
                public TTReportField AdditionalMembers;
                public TTReportField S15;
                public TTReportField S18;
                public TTReportField XXXXXXADI;
                public TTReportField NewField16;
                public TTReportField RAPORTARIHI2;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField01;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField BASLIK;
                public TTReportField DTARIHI;
                public TTReportField EVRAKTARIHI;
                public TTReportField NewField531;
                public TTReportField SAHSINADINABASLIK;
                public TTReportField SKULBL1;
                public TTReportField SKULBL2;
                public TTReportField SKULBL3;
                public TTReportField ADATE;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE;
                public TTReportField NewField1251;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField1351;
                public TTReportField BIRLIK;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportField FOTOGRAF1;
                public TTReportField NewField197;
                public TTReportField DECISIONTIME;
                public TTReportField NewField131;
                public TTReportField MUAYENEAMACI; 
                public SAHISGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 301;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 216, 200, 239, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"";

                    NewField46 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 97, 193, 107, false);
                    NewField46.Name = "NewField46";
                    NewField46.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField46.MultiLine = EvetHayirEnum.ehEvet;
                    NewField46.WordBreak = EvetHayirEnum.ehEvet;
                    NewField46.TextFont.Size = 9;
                    NewField46.Value = @"İLGİ: {%EVRAKTARIHI%} gün ve {#HEADER.EVRAKSAYISI#} sayılı sevk yazısı.";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 15, 172, 37, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%BASLIK%}
RAPOR ÖN BİLDİRİM BELGESİ";

                    NewFieldA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 42, 113, 46, false);
                    NewFieldA.Name = "NewFieldA";
                    NewFieldA.Value = @"KONU   : Sağlık Kurulu Raporu Hakkında";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 30, 42, false);
                    NewField141.Name = "NewField141";
                    NewField141.Value = @"SAĞ.KRL:";

                    DYERTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 265, 200, 269, false);
                    DYERTARIH.Name = "DYERTARIH";
                    DYERTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTARIH.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DYERTARIH.TextFont.Size = 8;
                    DYERTARIH.Value = @"{%DTARIHI%} / ";

                    TCKN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 43, 195, 47, false);
                    TCKN.Name = "TCKN";
                    TCKN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKN.MultiLine = EvetHayirEnum.ehEvet;
                    TCKN.NoClip = EvetHayirEnum.ehEvet;
                    TCKN.WordBreak = EvetHayirEnum.ehEvet;
                    TCKN.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKN.Value = @"{#HEADER.TCNO#}";

                    EVRAKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 38, 158, 42, false);
                    EVRAKNO.Name = "EVRAKNO";
                    EVRAKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKNO.Value = @"{#HEADER.ISLEMNO#}-{#HEADER.PROTOKOLNO#}-{%ADATE%}/SAĞ.KRL.-{#HEADER.ISLEMNO#}";

                    NewFieldA125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 255, 235, 259, false);
                    NewFieldA125.Name = "NewFieldA125";
                    NewFieldA125.Visible = EvetHayirEnum.ehHayir;
                    NewFieldA125.TextFont.Size = 8;
                    NewFieldA125.TextFont.Bold = true;
                    NewFieldA125.Value = @"Hasta Nu :";

                    RAPORSEBEP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 5, 299, 9, false);
                    RAPORSEBEP.Name = "RAPORSEBEP";
                    RAPORSEBEP.Visible = EvetHayirEnum.ehHayir;
                    RAPORSEBEP.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSEBEP.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSEBEP.Value = @"";

                    FOTOGRAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 59, 193, 87, false);
                    FOTOGRAF.Name = "FOTOGRAF";
                    FOTOGRAF.Visible = EvetHayirEnum.ehHayir;
                    FOTOGRAF.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTOGRAF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF.WordBreak = EvetHayirEnum.ehEvet;
                    FOTOGRAF.TextFont.Size = 8;
                    FOTOGRAF.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 170, 38, 174, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 9;
                    NewField13.Value = @"Rapor Tarihi  :";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 174, 38, 178, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 9;
                    NewField14.Value = @"Rapor Nu.     :";

                    RAPOR_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 174, 92, 178, false);
                    RAPOR_NO.Name = "RAPOR_NO";
                    RAPOR_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR_NO.TextFont.Size = 9;
                    RAPOR_NO.Value = @"{#HEADER.RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 170, 92, 174, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.TextFont.Size = 9;
                    RAPORTARIHI.Value = @"{#HEADER.RAPORTARIHI#}";

                    NewField176 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 216, 38, 220, false);
                    NewField176.Name = "NewField176";
                    NewField176.TextFont.Size = 9;
                    NewField176.Value = @"Karar         :";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 178, 200, 216, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 178, 38, 182, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Size = 9;
                    NewField10.Value = @"Teşhis        :";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 249, 200, 253, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{#HEADER.PNAME#} {#HEADER.PSURNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 261, 200, 265, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#HEADER.FATHERNAME#}";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 249, 66, 253, false);
                    NewField152.Name = "NewField152";
                    NewField152.TextFont.Size = 8;
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @"Adı Soyadı                   :";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 261, 66, 265, false);
                    NewField182.Name = "NewField182";
                    NewField182.TextFont.Size = 8;
                    NewField182.TextFont.Bold = true;
                    NewField182.Value = @"Baba Adı                     :";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 265, 66, 269, false);
                    NewField192.Name = "NewField192";
                    NewField192.TextFont.Size = 8;
                    NewField192.TextFont.Bold = true;
                    NewField192.Value = @"Doğum Tarihi / Doğum Yeri    :";

                    NewFieldQ125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 269, 66, 273, false);
                    NewFieldQ125.Name = "NewFieldQ125";
                    NewFieldQ125.TextFont.Size = 8;
                    NewFieldQ125.TextFont.Bold = true;
                    NewFieldQ125.Value = @"Sevki Yapan As. Ş. / Birlik  :";

                    XXXXXXLIKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 273, 200, 277, false);
                    XXXXXXLIKSUBE.Name = "XXXXXXLIKSUBE";
                    XXXXXXLIKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE.TextFont.Size = 8;
                    XXXXXXLIKSUBE.Value = @"";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 273, 66, 277, false);
                    NewField125.Name = "NewField125";
                    NewField125.TextFont.Size = 8;
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @"N.Kayıtlı Olduğu As Ş.       :";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 269, 200, 273, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 245, 200, 249, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#HEADER.TCNO#}";

                    NewField1077 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 240, 66, 244, false);
                    NewField1077.Name = "NewField1077";
                    NewField1077.TextFont.Size = 8;
                    NewField1077.TextFont.Bold = true;
                    NewField1077.TextFont.Underline = true;
                    NewField1077.Value = @"KİMLİĞİ                      ";

                    NewField177 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 245, 66, 249, false);
                    NewField177.Name = "NewField177";
                    NewField177.TextFont.Size = 8;
                    NewField177.TextFont.Bold = true;
                    NewField177.Value = @"TC Kimlik Nu.                :";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 255, 262, 259, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.Size = 8;
                    HASTANO.Value = @"{#HEADER.PID#}";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 108, 193, 133, false);
                    NewField28.Name = "NewField28";
                    NewField28.MultiLine = EvetHayirEnum.ehEvet;
                    NewField28.WordBreak = EvetHayirEnum.ehEvet;
                    NewField28.TextFont.Size = 9;
                    NewField28.Value = @"1. İlgi  ile  XXXXXXmize  sevk  edilen  aşağıda   açık kimliği  yazılı  kişinin, Sağlık Kurulu'ndan almış olduğu karar ile rapor tarih ve numarası aşağıda çıkarılmıştır. 

2. Düzenlenmekte olan Sağlık Kurulu raporu üst onay makamınca onaylandıktan sonra gönderilecektir. 

Arz / Rica ederim. ";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 144, 192, 163, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Size = 8;
                    BASTABIP.Value = @"";

                    AdditionalMembers = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 144, 146, 163, false);
                    AdditionalMembers.Name = "AdditionalMembers";
                    AdditionalMembers.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdditionalMembers.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionalMembers.MultiLine = EvetHayirEnum.ehEvet;
                    AdditionalMembers.WordBreak = EvetHayirEnum.ehEvet;
                    AdditionalMembers.ExpandTabs = EvetHayirEnum.ehEvet;
                    AdditionalMembers.TextFont.Size = 8;
                    AdditionalMembers.Value = @"";

                    S15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 98, 451, 112, false);
                    S15.Name = "S15";
                    S15.Visible = EvetHayirEnum.ehHayir;
                    S15.FieldType = ReportFieldTypeEnum.ftVariable;
                    S15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S15.MultiLine = EvetHayirEnum.ehEvet;
                    S15.WordBreak = EvetHayirEnum.ehEvet;
                    S15.ExpandTabs = EvetHayirEnum.ehEvet;
                    S15.TextFont.Size = 8;
                    S15.Value = @"";

                    S18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 116, 451, 130, false);
                    S18.Name = "S18";
                    S18.Visible = EvetHayirEnum.ehHayir;
                    S18.FieldType = ReportFieldTypeEnum.ftVariable;
                    S18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S18.MultiLine = EvetHayirEnum.ehEvet;
                    S18.WordBreak = EvetHayirEnum.ehEvet;
                    S18.ExpandTabs = EvetHayirEnum.ehEvet;
                    S18.TextFont.Size = 8;
                    S18.Value = @"";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 101, 252, 105, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.TextFont.Size = 8;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 38, 30, 42, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"";

                    RAPORTARIHI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 38, 195, 42, false);
                    RAPORTARIHI2.Name = "RAPORTARIHI2";
                    RAPORTARIHI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI2.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTARIHI2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI2.Value = @"{@printdate@}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 138, 192, 143, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 8;
                    NewField7.Value = @"Sağlık Kurulu Başkanı";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 109, 233, 114, false);
                    NewField8.Name = "NewField8";
                    NewField8.Visible = EvetHayirEnum.ehHayir;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"İLGİ:";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 118, 226, 122, false);
                    NewField9.Name = "NewField9";
                    NewField9.Visible = EvetHayirEnum.ehHayir;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"1.";

                    NewField01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 124, 226, 128, false);
                    NewField01.Name = "NewField01";
                    NewField01.Visible = EvetHayirEnum.ehHayir;
                    NewField01.TextFont.Bold = true;
                    NewField01.Value = @"2.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 42, 30, 46, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"KONU   :";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 31, 42, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"SAĞ.KRL:";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 29, 241, 34, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 37, 240, 42, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#HEADER.DTARIHI#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 42, 240, 47, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.Value = @"{#HEADER.EVRAKTARIHI#}";

                    NewField531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 88, 203, 96, false);
                    NewField531.Name = "NewField531";
                    NewField531.TextColor = System.Drawing.Color.Gray;
                    NewField531.MultiLine = EvetHayirEnum.ehEvet;
                    NewField531.NoClip = EvetHayirEnum.ehEvet;
                    NewField531.WordBreak = EvetHayirEnum.ehEvet;
                    NewField531.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField531.TextFont.Size = 8;
                    NewField531.Value = @"XXXXXXliğe Elverişli
Değildir Kararlılarda";

                    SAHSINADINABASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 70, 161, 90, false);
                    SAHSINADINABASLIK.Name = "SAHSINADINABASLIK";
                    SAHSINADINABASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAHSINADINABASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAHSINADINABASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SAHSINADINABASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SAHSINADINABASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAHSINADINABASLIK.TextFont.Bold = true;
                    SAHSINADINABASLIK.Value = @"{#HEADER.PNAME#} {#HEADER.PSURNAME#}";

                    SKULBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 138, 45, 143, false);
                    SKULBL1.Name = "SKULBL1";
                    SKULBL1.Visible = EvetHayirEnum.ehHayir;
                    SKULBL1.TextFont.Size = 8;
                    SKULBL1.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 138, 90, 143, false);
                    SKULBL2.Name = "SKULBL2";
                    SKULBL2.Visible = EvetHayirEnum.ehHayir;
                    SKULBL2.TextFont.Size = 8;
                    SKULBL2.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 138, 136, 143, false);
                    SKULBL3.Name = "SKULBL3";
                    SKULBL3.Visible = EvetHayirEnum.ehHayir;
                    SKULBL3.TextFont.Size = 8;
                    SKULBL3.Value = @"Sağlık Kurulu Üyesi";

                    ADATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 49, 241, 54, false);
                    ADATE.Name = "ADATE";
                    ADATE.Visible = EvetHayirEnum.ehHayir;
                    ADATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADATE.TextFormat = @"Short Date";
                    ADATE.TextFont.Name = "Arial Narrow";
                    ADATE.TextFont.CharSet = 1;
                    ADATE.Value = @"{#HEADER.ADATE#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 238, 242, 243, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#HEADER.DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 246, 242, 251, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#HEADER.DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 230, 242, 235, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#HEADER.DOGUMYERIULKE#}";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 257, 66, 261, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.TextFont.Size = 8;
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @"Sınıf ve Rütbesi             :";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 257, 200, 261, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 253, 66, 257, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.TextFont.Size = 8;
                    NewField1351.TextFont.Bold = true;
                    NewField1351.Value = @"Birlik                       :";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 253, 200, 257, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 48, 193, 58, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    FOTOGRAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 59, 193, 87, false);
                    FOTOGRAF1.Name = "FOTOGRAF1";
                    FOTOGRAF1.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTOGRAF1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF1.TextFont.Size = 8;
                    FOTOGRAF1.Value = @"FOTOGRAF";

                    NewField197 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 280, 200, 297, false);
                    NewField197.Name = "NewField197";
                    NewField197.MultiLine = EvetHayirEnum.ehEvet;
                    NewField197.NoClip = EvetHayirEnum.ehEvet;
                    NewField197.WordBreak = EvetHayirEnum.ehEvet;
                    NewField197.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField197.TextFont.Size = 8;
                    NewField197.Value = @"Not : ""İlgili personelin ön raporudur. Bu belge ile kesin işlem yapılamaz. Kat'i Rapor onay işlemleri tamamlandıktan sonra MSB.lığı ve XXXXXX Sağlık K.lığınca gönderilecektir. ""XXXXXXliğe Elverişli Değildir"", ""XXXXXXnde Görev Yapamaz"" kararı alan personel rapor onaylanana kadar sıhhi izinli sayılır. Ayrıca bu ön rapora istinaden erbaş/erlerin şahsi dosyaları XXXXXXlik Şubelerine gönderilir.""  ";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 222, 241, 227, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 166, 38, 170, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.Value = @"Muayene Amacı :";

                    MUAYENEAMACI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 166, 200, 170, false);
                    MUAYENEAMACI.Name = "MUAYENEAMACI";
                    MUAYENEAMACI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEAMACI.TextFont.Size = 9;
                    MUAYENEAMACI.Value = @"{#HEADER.SKSEBEBI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.HEADER.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    KARAR.CalcValue = @"";
                    EVRAKTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField46.CalcValue = @"İLGİ: " + MyParentReport.SAHIS.EVRAKTARIHI.FormattedValue + @" gün ve " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "") + @" sayılı sevk yazısı.";
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    XXXXXXBASLIK.CalcValue = MyParentReport.SAHIS.BASLIK.CalcValue + @"
RAPOR ÖN BİLDİRİM BELGESİ";
                    NewFieldA.CalcValue = NewFieldA.Value;
                    NewField141.CalcValue = NewField141.Value;
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    DYERTARIH.CalcValue = MyParentReport.SAHIS.DTARIHI.FormattedValue + @" / ";
                    TCKN.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    ADATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adate) : "");
                    EVRAKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "") + @"-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Protokolno) : "") + @"-" + MyParentReport.SAHIS.ADATE.FormattedValue + @"/SAĞ.KRL.-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    NewFieldA125.CalcValue = NewFieldA125.Value;
                    RAPORSEBEP.CalcValue = @"";
                    FOTOGRAF.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    RAPOR_NO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField176.CalcValue = NewField176.Value;
                    TANI.CalcValue = @"";
                    NewField10.CalcValue = NewField10.Value;
                    ADISOYADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    NewField152.CalcValue = NewField152.Value;
                    NewField182.CalcValue = NewField182.Value;
                    NewField192.CalcValue = NewField192.Value;
                    NewFieldQ125.CalcValue = NewFieldQ125.Value;
                    XXXXXXLIKSUBE.CalcValue = @"";
                    NewField125.CalcValue = NewField125.Value;
                    MAKAM.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField1077.CalcValue = NewField1077.Value;
                    NewField177.CalcValue = NewField177.Value;
                    HASTANO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    NewField28.CalcValue = NewField28.Value;
                    BASTABIP.CalcValue = @"";
                    AdditionalMembers.CalcValue = @"";
                    S15.CalcValue = @"";
                    S18.CalcValue = @"";
                    NewField16.CalcValue = NewField16.Value;
                    RAPORTARIHI2.CalcValue = DateTime.Now.ToShortDateString();
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField01.CalcValue = NewField01.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField531.CalcValue = NewField531.Value;
                    SAHSINADINABASLIK.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    SKULBL1.CalcValue = SKULBL1.Value;
                    SKULBL2.CalcValue = SKULBL2.Value;
                    SKULBL3.CalcValue = SKULBL3.Value;
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriulke) : "");
                    NewField1251.CalcValue = NewField1251.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField1351.CalcValue = NewField1351.Value;
                    BIRLIK.CalcValue = @"";
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    FOTOGRAF1.CalcValue = FOTOGRAF1.Value;
                    NewField197.CalcValue = NewField197.Value;
                    DECISIONTIME.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    MUAYENEAMACI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { KARAR,EVRAKTARIHI,NewField46,BASLIK,XXXXXXBASLIK,NewFieldA,NewField141,DTARIHI,DYERTARIH,TCKN,ADATE,EVRAKNO,NewFieldA125,RAPORSEBEP,FOTOGRAF,NewField13,NewField14,RAPOR_NO,RAPORTARIHI,NewField176,TANI,NewField10,ADISOYADI,BABAADI,NewField152,NewField182,NewField192,NewFieldQ125,XXXXXXLIKSUBE,NewField125,MAKAM,TCKIMLIKNO,NewField1077,NewField177,HASTANO,NewField28,BASTABIP,AdditionalMembers,S15,S18,NewField16,RAPORTARIHI2,NewField7,NewField8,NewField9,NewField01,NewField111,NewField121,NewField531,SAHSINADINABASLIK,SKULBL1,SKULBL2,SKULBL3,DYERILCE,DYERIL,DYERULKE,NewField1251,SINIFRUTBE,NewField1351,BIRLIK,TCKIMLIKNOBARKOD,FOTOGRAF1,NewField197,DECISIONTIME,NewField131,MUAYENEAMACI,XXXXXXADI};
                }

                public override void RunScript()
                {
#region SAHIS BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPreDeclarationDocumentReport_3)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
//
            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
            
            /* Yakınlık derecesinin artık görünmemesi istendi (27.07.2016 Mustafa)
            if (hc.Episode.MyRelationship() != null)
            {
                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            }
             */
            
            //SK Başkanı
            const int SPECIALITY_COUNT = 25;
            string sMemberSpeciality = "";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string sEmpID = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string sName = member.MemberDoctor.Name;
                    string sTitle = ""; //(hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass.ShortName);
                    sTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    sTitle += (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);

                    string specialityRow1 = "";
                    string specialityRow2 = "";

                    if (member.MemberDoctor.GetSpeciality() != null)
                        sMemberSpeciality = member.MemberDoctor.GetSpeciality().Name;

                    if (sMemberSpeciality != "")
                    {
                        sMemberSpeciality += " Uzm.";
                        if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                        {
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT * 2)
                                sMemberSpeciality = sMemberSpeciality.Substring(0, SPECIALITY_COUNT * 2);

                            specialityRow1 = sMemberSpeciality.Substring(0, SPECIALITY_COUNT);
                            specialityRow2 = sMemberSpeciality.Substring(SPECIALITY_COUNT, sMemberSpeciality.Length - SPECIALITY_COUNT);
                        }
                        else
                        {
                            specialityRow1 = sMemberSpeciality;
                            specialityRow2 = "";
                        }
                    }
                    else
                    {
                        specialityRow1 = "";
                        specialityRow2 = "";
                    }

                    string sMasterText = sName + "\n" + sTitle + "(" + sEmpID + ")" + "\n" + specialityRow1 + "\n" + specialityRow2;

                    this.BASTABIP.CalcValue = sMasterText;
                }
            }
            
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                string maddeDilimFikra = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    maddeDilimFikra += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    maddeDilimFikra += "  ";
                }
                maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                maddeDilimFikra += "]";
                
                this.KARAR.CalcValue = maddeDilimFikra + "\n";
            }

            // Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\n";
            }
            
            // Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            //AdditionalMembers
            //            if (hc.UnsuitableForMilitaryService == true)
            //            {
            //                if(hc.MemberOfHealthCommittee != null)
            //                {
            //                    string sCrLf = "\r\n";
            //                    string sMembersText = "";// = sCrLf;
            //                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId;
//
            //                    const int COLUMN_COUNT = 3;
            //                    const int SPACE_COUNT = 27;
            //                    int nCounter = 0;
            //                    int nRow = 0;
//
            //                    //string sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
//
            //                    foreach(HealthCommitteAdditionalMemberGrid pMember in hc.MemberOfHealthCommittee.AdditionalMembers)
            //                    {
            //                        sMemberName = pMember.Doctor.Name;
            //                        sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
            //                        sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
            //                        sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
            //                        sMemberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
//
            //                        //sHeaderRow = sHeaderRow.Insert(nCounter, "Sağlık Kurulu Üyesi");
            //                        sNameRow = sNameRow.Insert(nCounter, sMemberName);
            //                        //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
            //                        //sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);
            //                        sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
            //                        //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
//
            //                        if (pMember.Doctor.GetSpeciality() != null)
            //                            sMemberSpeciality = pMember.Doctor.GetSpeciality().Name;
            //                        else
            //                            sMemberSpeciality = "";
//
            //                        if (sMemberSpeciality != "")
            //                        {
            //                            sMemberSpeciality += " Uzm.";
            //                            if (sMemberSpeciality.Length > SPECIALITY_COUNT)
            //                            {
            //                                if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
            //                                    sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
//
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
            //                            }
            //                            else
            //                            {
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            sTitleRow = sTitleRow.Insert(nCounter, "");
            //                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                        }
//
            //                        nCounter += SPACE_COUNT;
//
            //                        nRow = nCounter / SPACE_COUNT;
            //                        int nRate = nRow % COLUMN_COUNT;
            //                        if (nRate == 0)
            //                        {
            //                            //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                            //sMembersText += sHeaderRow + "\r\n";
            //                            sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sNameRow + "\r\n";
            //                            sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sRankRow + "\r\n";
            //                            sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sTitleRow + "\r\n";
            //                            sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sSpecialityRow + "\r\n";
//
//
            //                            //sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sSpecialityRow = new string(' ',SPACE_COUNT * COLUMN_COUNT);
//
            //                            sMembersText +=  sCrLf + sCrLf + sCrLf;
            //                            nCounter = 0;
            //                        }
            //                    }
//
            //                    //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                    //sMembersText += sHeaderRow + "\r\n";
            //                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sNameRow + "\r\n";
            //                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sRankRow + "\r\n";
            //                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sTitleRow + "\r\n";
            //                    sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sSpecialityRow + "\r\n";
//
            //                    this.AdditionalMembers.CalcValue = sMembersText;
//
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 0)
            //                        this.SKULBL1.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 1)
            //                        this.SKULBL2.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 2)
            //                        this.SKULBL3.Visible = EvetHayirEnum.ehEvet;
            //                }
            //                this.FOTOGRAF.Visible = EvetHayirEnum.ehEvet;
            //                this.NewField531.Visible = EvetHayirEnum.ehHayir;
            //                this.FOTOGRAF1.Visible = EvetHayirEnum.ehHayir;
            //            }

            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIlce;
                else
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            }
            else if (dogumIl.Trim() != "")
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            else
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumUlke;
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCPREDECREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKN.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKN.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
#endregion SAHIS BODY_Script
                }
            }

        }

        public SAHISGroup SAHIS;

        public partial class XXXXXXLIKSUBESIGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentReport_3 MyParentReport
            {
                get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
            }

            new public XXXXXXLIKSUBESIGroupBody Body()
            {
                return (XXXXXXLIKSUBESIGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField64 { get {return Body().NewField64;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewFieldA { get {return Body().NewFieldA;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField DYERTARIH { get {return Body().DYERTARIH;} }
            public TTReportField TCKN { get {return Body().TCKN;} }
            public TTReportField EVRAKNO { get {return Body().EVRAKNO;} }
            public TTReportField NewFieldA1521 { get {return Body().NewFieldA1521;} }
            public TTReportField RAPORSEBEP { get {return Body().RAPORSEBEP;} }
            public TTReportField FOTOGRAF { get {return Body().FOTOGRAF;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField RAPOR_NO { get {return Body().RAPOR_NO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField NewField1671 { get {return Body().NewField1671;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField NewField1251 { get {return Body().NewField1251;} }
            public TTReportField NewField1281 { get {return Body().NewField1281;} }
            public TTReportField NewField1291 { get {return Body().NewField1291;} }
            public TTReportField NewFieldQ1521 { get {return Body().NewFieldQ1521;} }
            public TTReportField XXXXXXLIKSUBE { get {return Body().XXXXXXLIKSUBE;} }
            public TTReportField NewField1521 { get {return Body().NewField1521;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField NewField17701 { get {return Body().NewField17701;} }
            public TTReportField NewField1771 { get {return Body().NewField1771;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField182 { get {return Body().NewField182;} }
            public TTReportField BASTABIP { get {return Body().BASTABIP;} }
            public TTReportField AdditionalMembers { get {return Body().AdditionalMembers;} }
            public TTReportField S151 { get {return Body().S151;} }
            public TTReportField S181 { get {return Body().S181;} }
            public TTReportField XXXXXXADI1 { get {return Body().XXXXXXADI1;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField RAPORTARIHI2 { get {return Body().RAPORTARIHI2;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField110 { get {return Body().NewField110;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField EVRAKTARIHI { get {return Body().EVRAKTARIHI;} }
            public TTReportField NewField1135 { get {return Body().NewField1135;} }
            public TTReportField XXXXXXLIKSUBESIBASLIK { get {return Body().XXXXXXLIKSUBESIBASLIK;} }
            public TTReportField SKULBL1 { get {return Body().SKULBL1;} }
            public TTReportField SKULBL2 { get {return Body().SKULBL2;} }
            public TTReportField SKULBL3 { get {return Body().SKULBL3;} }
            public TTReportField ADATE { get {return Body().ADATE;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportField NewField11521 { get {return Body().NewField11521;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField NewField11531 { get {return Body().NewField11531;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Body().TCKIMLIKNOBARKOD;} }
            public TTReportField FOTOGRAF1 { get {return Body().FOTOGRAF1;} }
            public TTReportField NewField197 { get {return Body().NewField197;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField MUAYENEAMACI { get {return Body().MUAYENEAMACI;} }
            public XXXXXXLIKSUBESIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public XXXXXXLIKSUBESIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new XXXXXXLIKSUBESIGroupBody(this);
            }

            public partial class XXXXXXLIKSUBESIGroupBody : TTReportSection
            {
                public HCPreDeclarationDocumentReport_3 MyParentReport
                {
                    get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField64;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewFieldA;
                public TTReportField NewField1141;
                public TTReportField DYERTARIH;
                public TTReportField TCKN;
                public TTReportField EVRAKNO;
                public TTReportField NewFieldA1521;
                public TTReportField RAPORSEBEP;
                public TTReportField FOTOGRAF;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField RAPOR_NO;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField1671;
                public TTReportField TANI;
                public TTReportField NewField101;
                public TTReportField ADISOYADI;
                public TTReportField BABAADI;
                public TTReportField NewField1251;
                public TTReportField NewField1281;
                public TTReportField NewField1291;
                public TTReportField NewFieldQ1521;
                public TTReportField XXXXXXLIKSUBE;
                public TTReportField NewField1521;
                public TTReportField MAKAM;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField17701;
                public TTReportField NewField1771;
                public TTReportField HASTANO;
                public TTReportField NewField182;
                public TTReportField BASTABIP;
                public TTReportField AdditionalMembers;
                public TTReportField S151;
                public TTReportField S181;
                public TTReportField XXXXXXADI1;
                public TTReportField NewField161;
                public TTReportField RAPORTARIHI2;
                public TTReportField NewField7;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField110;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField BASLIK;
                public TTReportField DTARIHI;
                public TTReportField EVRAKTARIHI;
                public TTReportField NewField1135;
                public TTReportField XXXXXXLIKSUBESIBASLIK;
                public TTReportField SKULBL1;
                public TTReportField SKULBL2;
                public TTReportField SKULBL3;
                public TTReportField ADATE;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE;
                public TTReportField NewField11521;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField11531;
                public TTReportField BIRLIK;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportField FOTOGRAF1;
                public TTReportField NewField197;
                public TTReportField DECISIONTIME;
                public TTReportField NewField132;
                public TTReportField MUAYENEAMACI; 
                public XXXXXXLIKSUBESIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 212, 200, 235, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"";

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 93, 193, 103, false);
                    NewField64.Name = "NewField64";
                    NewField64.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField64.MultiLine = EvetHayirEnum.ehEvet;
                    NewField64.WordBreak = EvetHayirEnum.ehEvet;
                    NewField64.TextFont.Size = 9;
                    NewField64.Value = @"İLGİ: {%EVRAKTARIHI%} gün ve {#HEADER.EVRAKSAYISI#} sayılı sevk yazısı.";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 11, 172, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%BASLIK%}
RAPOR ÖN BİLDİRİM BELGESİ";

                    NewFieldA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 113, 42, false);
                    NewFieldA.Name = "NewFieldA";
                    NewFieldA.Value = @"KONU   : Sağlık Kurulu Raporu Hakkında";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 34, 30, 38, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.Value = @"SAĞ.KRL:";

                    DYERTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 261, 200, 265, false);
                    DYERTARIH.Name = "DYERTARIH";
                    DYERTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTARIH.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DYERTARIH.TextFont.Size = 8;
                    DYERTARIH.Value = @"{%DTARIHI%} / ";

                    TCKN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 39, 195, 43, false);
                    TCKN.Name = "TCKN";
                    TCKN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKN.MultiLine = EvetHayirEnum.ehEvet;
                    TCKN.NoClip = EvetHayirEnum.ehEvet;
                    TCKN.WordBreak = EvetHayirEnum.ehEvet;
                    TCKN.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKN.Value = @"{#HEADER.TCNO#}";

                    EVRAKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 34, 158, 38, false);
                    EVRAKNO.Name = "EVRAKNO";
                    EVRAKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKNO.Value = @"{#HEADER.ISLEMNO#}-{#HEADER.PROTOKOLNO#}-{%ADATE%}/SAĞ.KRL.-{#HEADER.ISLEMNO#}";

                    NewFieldA1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 251, 235, 255, false);
                    NewFieldA1521.Name = "NewFieldA1521";
                    NewFieldA1521.Visible = EvetHayirEnum.ehHayir;
                    NewFieldA1521.TextFont.Size = 8;
                    NewFieldA1521.TextFont.Bold = true;
                    NewFieldA1521.Value = @"Hasta Nu :";

                    RAPORSEBEP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 1, 299, 5, false);
                    RAPORSEBEP.Name = "RAPORSEBEP";
                    RAPORSEBEP.Visible = EvetHayirEnum.ehHayir;
                    RAPORSEBEP.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSEBEP.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSEBEP.Value = @"";

                    FOTOGRAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 55, 193, 83, false);
                    FOTOGRAF.Name = "FOTOGRAF";
                    FOTOGRAF.Visible = EvetHayirEnum.ehHayir;
                    FOTOGRAF.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTOGRAF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF.WordBreak = EvetHayirEnum.ehEvet;
                    FOTOGRAF.TextFont.Size = 8;
                    FOTOGRAF.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 166, 38, 170, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.Value = @"Rapor Tarihi  :";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 170, 38, 174, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 9;
                    NewField141.Value = @"Rapor Nu.     :";

                    RAPOR_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 170, 92, 174, false);
                    RAPOR_NO.Name = "RAPOR_NO";
                    RAPOR_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR_NO.TextFont.Size = 9;
                    RAPOR_NO.Value = @"{#HEADER.RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 166, 92, 170, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.TextFont.Size = 9;
                    RAPORTARIHI.Value = @"{#HEADER.RAPORTARIHI#}";

                    NewField1671 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 212, 38, 216, false);
                    NewField1671.Name = "NewField1671";
                    NewField1671.TextFont.Size = 9;
                    NewField1671.Value = @"Karar         :";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 174, 200, 212, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 174, 38, 178, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Size = 9;
                    NewField101.Value = @"Teşhis        :";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 245, 200, 249, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{#HEADER.PNAME#} {#HEADER.PSURNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 257, 200, 261, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#HEADER.FATHERNAME#}";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 245, 66, 249, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.TextFont.Size = 8;
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @"Adı Soyadı                   :";

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 257, 66, 261, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.TextFont.Size = 8;
                    NewField1281.TextFont.Bold = true;
                    NewField1281.Value = @"Baba Adı                     :";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 261, 66, 265, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.Size = 8;
                    NewField1291.TextFont.Bold = true;
                    NewField1291.Value = @"Doğum Tarihi / Doğum Yeri    :";

                    NewFieldQ1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 265, 66, 269, false);
                    NewFieldQ1521.Name = "NewFieldQ1521";
                    NewFieldQ1521.TextFont.Size = 8;
                    NewFieldQ1521.TextFont.Bold = true;
                    NewFieldQ1521.Value = @"Sevki Yapan As. Ş. / Birlik  :";

                    XXXXXXLIKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 269, 200, 273, false);
                    XXXXXXLIKSUBE.Name = "XXXXXXLIKSUBE";
                    XXXXXXLIKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE.TextFont.Size = 8;
                    XXXXXXLIKSUBE.Value = @"";

                    NewField1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 269, 66, 273, false);
                    NewField1521.Name = "NewField1521";
                    NewField1521.TextFont.Size = 8;
                    NewField1521.TextFont.Bold = true;
                    NewField1521.Value = @"N.Kayıtlı Olduğu As Ş.       :";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 265, 200, 269, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 241, 200, 245, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#HEADER.TCNO#}";

                    NewField17701 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 236, 66, 240, false);
                    NewField17701.Name = "NewField17701";
                    NewField17701.TextFont.Size = 8;
                    NewField17701.TextFont.Bold = true;
                    NewField17701.TextFont.Underline = true;
                    NewField17701.Value = @"KİMLİĞİ                      ";

                    NewField1771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 241, 66, 245, false);
                    NewField1771.Name = "NewField1771";
                    NewField1771.TextFont.Size = 8;
                    NewField1771.TextFont.Bold = true;
                    NewField1771.Value = @"TC Kimlik Nu.                :";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 251, 262, 255, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.Size = 8;
                    HASTANO.Value = @"{#HEADER.PID#}";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 104, 193, 129, false);
                    NewField182.Name = "NewField182";
                    NewField182.MultiLine = EvetHayirEnum.ehEvet;
                    NewField182.WordBreak = EvetHayirEnum.ehEvet;
                    NewField182.TextFont.Size = 9;
                    NewField182.Value = @"1. İlgi  ile  XXXXXXmize  sevk  edilen  aşağıda   açık kimliği  yazılı  kişinin, Sağlık Kurulu'ndan almış olduğu karar ile rapor tarih ve numarası aşağıda çıkarılmıştır. 

2. Düzenlenmekte olan Sağlık Kurulu raporu üst onay makamınca onaylandıktan sonra gönderilecektir. 

Arz / Rica ederim. ";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 140, 192, 159, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Size = 8;
                    BASTABIP.Value = @"";

                    AdditionalMembers = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 140, 146, 159, false);
                    AdditionalMembers.Name = "AdditionalMembers";
                    AdditionalMembers.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdditionalMembers.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionalMembers.MultiLine = EvetHayirEnum.ehEvet;
                    AdditionalMembers.WordBreak = EvetHayirEnum.ehEvet;
                    AdditionalMembers.ExpandTabs = EvetHayirEnum.ehEvet;
                    AdditionalMembers.TextFont.Size = 8;
                    AdditionalMembers.Value = @"";

                    S151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 94, 451, 108, false);
                    S151.Name = "S151";
                    S151.Visible = EvetHayirEnum.ehHayir;
                    S151.FieldType = ReportFieldTypeEnum.ftVariable;
                    S151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S151.MultiLine = EvetHayirEnum.ehEvet;
                    S151.WordBreak = EvetHayirEnum.ehEvet;
                    S151.ExpandTabs = EvetHayirEnum.ehEvet;
                    S151.TextFont.Size = 8;
                    S151.Value = @"";

                    S181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 112, 451, 126, false);
                    S181.Name = "S181";
                    S181.Visible = EvetHayirEnum.ehHayir;
                    S181.FieldType = ReportFieldTypeEnum.ftVariable;
                    S181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S181.MultiLine = EvetHayirEnum.ehEvet;
                    S181.WordBreak = EvetHayirEnum.ehEvet;
                    S181.ExpandTabs = EvetHayirEnum.ehEvet;
                    S181.TextFont.Size = 8;
                    S181.Value = @"";

                    XXXXXXADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 97, 252, 101, false);
                    XXXXXXADI1.Name = "XXXXXXADI1";
                    XXXXXXADI1.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXADI1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI1.TextFont.Size = 8;
                    XXXXXXADI1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 34, 30, 38, false);
                    NewField161.Name = "NewField161";
                    NewField161.Value = @"";

                    RAPORTARIHI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 34, 195, 38, false);
                    RAPORTARIHI2.Name = "RAPORTARIHI2";
                    RAPORTARIHI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI2.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTARIHI2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI2.Value = @"{@printdate@}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 134, 192, 139, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 8;
                    NewField7.Value = @"Sağlık Kurulu Başkanı";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 105, 233, 110, false);
                    NewField18.Name = "NewField18";
                    NewField18.Visible = EvetHayirEnum.ehHayir;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"İLGİ:";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 114, 226, 118, false);
                    NewField19.Name = "NewField19";
                    NewField19.Visible = EvetHayirEnum.ehHayir;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"1.";

                    NewField110 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 120, 226, 124, false);
                    NewField110.Name = "NewField110";
                    NewField110.Visible = EvetHayirEnum.ehHayir;
                    NewField110.TextFont.Bold = true;
                    NewField110.Value = @"2.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 30, 42, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"KONU   :";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 34, 31, 38, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"SAĞ.KRL:";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 25, 241, 30, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 33, 240, 38, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#HEADER.DTARIHI#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 38, 240, 43, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.Value = @"{#HEADER.EVRAKTARIHI#}";

                    NewField1135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 84, 203, 92, false);
                    NewField1135.Name = "NewField1135";
                    NewField1135.TextColor = System.Drawing.Color.Gray;
                    NewField1135.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1135.NoClip = EvetHayirEnum.ehEvet;
                    NewField1135.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1135.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1135.TextFont.Size = 8;
                    NewField1135.Value = @"XXXXXXliğe Elverişli
Değildir Kararlılarda";

                    XXXXXXLIKSUBESIBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 66, 161, 86, false);
                    XXXXXXLIKSUBESIBASLIK.Name = "XXXXXXLIKSUBESIBASLIK";
                    XXXXXXLIKSUBESIBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBESIBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXLIKSUBESIBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESIBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESIBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBESIBASLIK.TextFont.Bold = true;
                    XXXXXXLIKSUBESIBASLIK.Value = @"";

                    SKULBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 134, 45, 139, false);
                    SKULBL1.Name = "SKULBL1";
                    SKULBL1.Visible = EvetHayirEnum.ehHayir;
                    SKULBL1.TextFont.Size = 8;
                    SKULBL1.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 134, 90, 139, false);
                    SKULBL2.Name = "SKULBL2";
                    SKULBL2.Visible = EvetHayirEnum.ehHayir;
                    SKULBL2.TextFont.Size = 8;
                    SKULBL2.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 134, 136, 139, false);
                    SKULBL3.Name = "SKULBL3";
                    SKULBL3.Visible = EvetHayirEnum.ehHayir;
                    SKULBL3.TextFont.Size = 8;
                    SKULBL3.Value = @"Sağlık Kurulu Üyesi";

                    ADATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 45, 241, 50, false);
                    ADATE.Name = "ADATE";
                    ADATE.Visible = EvetHayirEnum.ehHayir;
                    ADATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADATE.TextFormat = @"Short Date";
                    ADATE.TextFont.Name = "Arial Narrow";
                    ADATE.TextFont.CharSet = 1;
                    ADATE.Value = @"{#HEADER.ADATE#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 234, 242, 239, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#HEADER.DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 242, 242, 247, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#HEADER.DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 226, 242, 231, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#HEADER.DOGUMYERIULKE#}";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 253, 66, 257, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.TextFont.Size = 8;
                    NewField11521.TextFont.Bold = true;
                    NewField11521.Value = @"Sınıf ve Rütbesi             :";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 253, 200, 257, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    NewField11531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 249, 66, 253, false);
                    NewField11531.Name = "NewField11531";
                    NewField11531.TextFont.Size = 8;
                    NewField11531.TextFont.Bold = true;
                    NewField11531.Value = @"Birlik                       :";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 249, 200, 253, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 44, 193, 54, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    FOTOGRAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 55, 193, 83, false);
                    FOTOGRAF1.Name = "FOTOGRAF1";
                    FOTOGRAF1.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTOGRAF1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF1.TextFont.Size = 8;
                    FOTOGRAF1.Value = @"FOTOGRAF";

                    NewField197 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 276, 201, 293, false);
                    NewField197.Name = "NewField197";
                    NewField197.MultiLine = EvetHayirEnum.ehEvet;
                    NewField197.NoClip = EvetHayirEnum.ehEvet;
                    NewField197.WordBreak = EvetHayirEnum.ehEvet;
                    NewField197.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField197.TextFont.Size = 8;
                    NewField197.Value = @"Not : ""İlgili personelin ön raporudur. Bu belge ile kesin işlem yapılamaz. Kat'i Rapor onay işlemleri tamamlandıktan sonra MSB.lığı ve XXXXXX Sağlık K.lığınca gönderilecektir. ""XXXXXXliğe Elverişli Değildir"", ""XXXXXXnde Görev Yapamaz"" kararı alan personel rapor onaylanana kadar sıhhi izinli sayılır. Ayrıca bu ön rapora istinaden erbaş/erlerin şahsi dosyaları XXXXXXlik Şubelerine gönderilir.""  ";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 219, 241, 224, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 162, 38, 166, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Size = 9;
                    NewField132.Value = @"Muayene Amacı :";

                    MUAYENEAMACI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 162, 200, 166, false);
                    MUAYENEAMACI.Name = "MUAYENEAMACI";
                    MUAYENEAMACI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEAMACI.TextFont.Size = 9;
                    MUAYENEAMACI.Value = @"{#HEADER.SKSEBEBI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.HEADER.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    KARAR.CalcValue = @"";
                    EVRAKTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField64.CalcValue = @"İLGİ: " + MyParentReport.XXXXXXLIKSUBESI.EVRAKTARIHI.FormattedValue + @" gün ve " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "") + @" sayılı sevk yazısı.";
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    XXXXXXBASLIK.CalcValue = MyParentReport.XXXXXXLIKSUBESI.BASLIK.CalcValue + @"
RAPOR ÖN BİLDİRİM BELGESİ";
                    NewFieldA.CalcValue = NewFieldA.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    DYERTARIH.CalcValue = MyParentReport.XXXXXXLIKSUBESI.DTARIHI.FormattedValue + @" / ";
                    TCKN.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    ADATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adate) : "");
                    EVRAKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "") + @"-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Protokolno) : "") + @"-" + MyParentReport.XXXXXXLIKSUBESI.ADATE.FormattedValue + @"/SAĞ.KRL.-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    NewFieldA1521.CalcValue = NewFieldA1521.Value;
                    RAPORSEBEP.CalcValue = @"";
                    FOTOGRAF.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    RAPOR_NO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField1671.CalcValue = NewField1671.Value;
                    TANI.CalcValue = @"";
                    NewField101.CalcValue = NewField101.Value;
                    ADISOYADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField1281.CalcValue = NewField1281.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewFieldQ1521.CalcValue = NewFieldQ1521.Value;
                    XXXXXXLIKSUBE.CalcValue = @"";
                    NewField1521.CalcValue = NewField1521.Value;
                    MAKAM.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField17701.CalcValue = NewField17701.Value;
                    NewField1771.CalcValue = NewField1771.Value;
                    HASTANO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    NewField182.CalcValue = NewField182.Value;
                    BASTABIP.CalcValue = @"";
                    AdditionalMembers.CalcValue = @"";
                    S151.CalcValue = @"";
                    S181.CalcValue = @"";
                    NewField161.CalcValue = NewField161.Value;
                    RAPORTARIHI2.CalcValue = DateTime.Now.ToShortDateString();
                    NewField7.CalcValue = NewField7.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField110.CalcValue = NewField110.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1135.CalcValue = NewField1135.Value;
                    XXXXXXLIKSUBESIBASLIK.CalcValue = @"";
                    SKULBL1.CalcValue = SKULBL1.Value;
                    SKULBL2.CalcValue = SKULBL2.Value;
                    SKULBL3.CalcValue = SKULBL3.Value;
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriulke) : "");
                    NewField11521.CalcValue = NewField11521.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField11531.CalcValue = NewField11531.Value;
                    BIRLIK.CalcValue = @"";
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    FOTOGRAF1.CalcValue = FOTOGRAF1.Value;
                    NewField197.CalcValue = NewField197.Value;
                    DECISIONTIME.CalcValue = @"";
                    NewField132.CalcValue = NewField132.Value;
                    MUAYENEAMACI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    XXXXXXADI1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { KARAR,EVRAKTARIHI,NewField64,BASLIK,XXXXXXBASLIK,NewFieldA,NewField1141,DTARIHI,DYERTARIH,TCKN,ADATE,EVRAKNO,NewFieldA1521,RAPORSEBEP,FOTOGRAF,NewField131,NewField141,RAPOR_NO,RAPORTARIHI,NewField1671,TANI,NewField101,ADISOYADI,BABAADI,NewField1251,NewField1281,NewField1291,NewFieldQ1521,XXXXXXLIKSUBE,NewField1521,MAKAM,TCKIMLIKNO,NewField17701,NewField1771,HASTANO,NewField182,BASTABIP,AdditionalMembers,S151,S181,NewField161,RAPORTARIHI2,NewField7,NewField18,NewField19,NewField110,NewField1111,NewField1121,NewField1135,XXXXXXLIKSUBESIBASLIK,SKULBL1,SKULBL2,SKULBL3,DYERILCE,DYERIL,DYERULKE,NewField11521,SINIFRUTBE,NewField11531,BIRLIK,TCKIMLIKNOBARKOD,FOTOGRAF1,NewField197,DECISIONTIME,NewField132,MUAYENEAMACI,XXXXXXADI1};
                }

                public override void RunScript()
                {
#region XXXXXXLIKSUBESI BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPreDeclarationDocumentReport_3)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
//
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
//
            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
            
            /* Yakınlık derecesinin artık görünmemesi istendi (27.07.2016 Mustafa)
            if (hc.Episode.MyRelationship() != null)
            {
                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            }
             */
            
            //SK Başkanı
            const int SPECIALITY_COUNT = 25;
            string sMemberSpeciality = "";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string sEmpID = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string sName = member.MemberDoctor.Name;
                    string sTitle = ""; //(hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass.ShortName);
                    sTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    sTitle += (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);

                    string specialityRow1 = "";
                    string specialityRow2 = "";

                    if (member.MemberDoctor.GetSpeciality() != null)
                        sMemberSpeciality = member.MemberDoctor.GetSpeciality().Name;

                    if (sMemberSpeciality != "")
                    {
                        sMemberSpeciality += " Uzm.";
                        if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                        {
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT * 2)
                                sMemberSpeciality = sMemberSpeciality.Substring(0, SPECIALITY_COUNT * 2);

                            specialityRow1 = sMemberSpeciality.Substring(0, SPECIALITY_COUNT);
                            specialityRow2 = sMemberSpeciality.Substring(SPECIALITY_COUNT, sMemberSpeciality.Length - SPECIALITY_COUNT);
                        }
                        else
                        {
                            specialityRow1 = sMemberSpeciality;
                            specialityRow2 = "";
                        }
                    }
                    else
                    {
                        specialityRow1 = "";
                        specialityRow2 = "";
                    }

                    string sMasterText = sName + "\n" + sTitle + "(" + sEmpID + ")" + "\n" + specialityRow1 + "\n" + specialityRow2;

                    this.BASTABIP.CalcValue = sMasterText;
                }
            }
            
            
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                string maddeDilimFikra = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    maddeDilimFikra += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    maddeDilimFikra += "  ";
                }
                maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                maddeDilimFikra += "]";
                
                this.KARAR.CalcValue = maddeDilimFikra + "\n";
            }

            // Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\n";
            }
            
            // Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            //AdditionalMembers
            //            if (hc.UnsuitableForMilitaryService == true)
            //            {
            //                if(hc.MemberOfHealthCommittee != null)
            //                {
            //                    string sCrLf = "\r\n";
            //                    string sMembersText = "";// = sCrLf;
            //                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId;
//
            //                    const int COLUMN_COUNT = 3;
            //                    const int SPACE_COUNT = 27;
            //                    int nCounter = 0;
            //                    int nRow = 0;
//
            //                    //string sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
//
            //                    foreach(HealthCommitteAdditionalMemberGrid pMember in hc.MemberOfHealthCommittee.AdditionalMembers)
            //                    {
            //                        sMemberName = pMember.Doctor.Name;
            //                        sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
            //                        sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
            //                        sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
            //                        sMemberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
//
            //                        //sHeaderRow = sHeaderRow.Insert(nCounter, "Sağlık Kurulu Üyesi");
            //                        sNameRow = sNameRow.Insert(nCounter, sMemberName);
            //                        //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
            //                        //sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);
            //                        sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
            //                        //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
//
            //                        if (pMember.Doctor.GetSpeciality() != null)
            //                            sMemberSpeciality = pMember.Doctor.GetSpeciality().Name;
            //                        else
            //                            sMemberSpeciality = "";
//
            //                        if (sMemberSpeciality != "")
            //                        {
            //                            sMemberSpeciality += " Uzm.";
            //                            if (sMemberSpeciality.Length > SPECIALITY_COUNT)
            //                            {
            //                                if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
            //                                    sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
//
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
            //                            }
            //                            else
            //                            {
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            sTitleRow = sTitleRow.Insert(nCounter, "");
            //                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                        }
//
            //                        nCounter += SPACE_COUNT;
//
            //                        nRow = nCounter / SPACE_COUNT;
            //                        int nRate = nRow % COLUMN_COUNT;
            //                        if (nRate == 0)
            //                        {
            //                            //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                            //sMembersText += sHeaderRow + "\r\n";
            //                            sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sNameRow + "\r\n";
            //                            sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sRankRow + "\r\n";
            //                            sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sTitleRow + "\r\n";
            //                            sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sSpecialityRow + "\r\n";
//
//
            //                            //sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sSpecialityRow = new string(' ',SPACE_COUNT * COLUMN_COUNT);
//
            //                            sMembersText +=  sCrLf + sCrLf + sCrLf;
            //                            nCounter = 0;
            //                        }
            //                    }
//
            //                    //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                    //sMembersText += sHeaderRow + "\r\n";
            //                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sNameRow + "\r\n";
            //                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sRankRow + "\r\n";
            //                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sTitleRow + "\r\n";
            //                    sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sSpecialityRow + "\r\n";
//
            //                    this.AdditionalMembers.CalcValue = sMembersText;
//
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 0)
            //                        this.SKULBL1.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 1)
            //                        this.SKULBL2.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 2)
            //                        this.SKULBL3.Visible = EvetHayirEnum.ehEvet;
            //                }
            //                this.FOTOGRAF.Visible = EvetHayirEnum.ehEvet;
            //                this.NewField1135.Visible = EvetHayirEnum.ehHayir;
            //                this.FOTOGRAF1.Visible = EvetHayirEnum.ehHayir;
            //            }

            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIlce;
                else
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            }
            else if (dogumIl.Trim() != "")
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            else
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumUlke;
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCPREDECREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKN.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKN.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
#endregion XXXXXXLIKSUBESI BODY_Script
                }
            }

        }

        public XXXXXXLIKSUBESIGroup XXXXXXLIKSUBESI;

        public partial class BIRLIKGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentReport_3 MyParentReport
            {
                get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
            }

            new public BIRLIKGroupBody Body()
            {
                return (BIRLIKGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField46 { get {return Body().NewField46;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewFieldA { get {return Body().NewFieldA;} }
            public TTReportField NewField11411 { get {return Body().NewField11411;} }
            public TTReportField DYERTARIH { get {return Body().DYERTARIH;} }
            public TTReportField TCKN { get {return Body().TCKN;} }
            public TTReportField EVRAKNO { get {return Body().EVRAKNO;} }
            public TTReportField NewFieldA11251 { get {return Body().NewFieldA11251;} }
            public TTReportField RAPORSEBEP { get {return Body().RAPORSEBEP;} }
            public TTReportField FOTOGRAF { get {return Body().FOTOGRAF;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField RAPOR_NO { get {return Body().RAPOR_NO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField NewField11761 { get {return Body().NewField11761;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField NewField1101 { get {return Body().NewField1101;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField NewField11521 { get {return Body().NewField11521;} }
            public TTReportField NewField11821 { get {return Body().NewField11821;} }
            public TTReportField NewField11921 { get {return Body().NewField11921;} }
            public TTReportField NewFieldQ11251 { get {return Body().NewFieldQ11251;} }
            public TTReportField XXXXXXLIKSUBE { get {return Body().XXXXXXLIKSUBE;} }
            public TTReportField NewField11251 { get {return Body().NewField11251;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField NewField110771 { get {return Body().NewField110771;} }
            public TTReportField NewField11771 { get {return Body().NewField11771;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField1281 { get {return Body().NewField1281;} }
            public TTReportField BASTABIP { get {return Body().BASTABIP;} }
            public TTReportField AdditionalMembers { get {return Body().AdditionalMembers;} }
            public TTReportField S1151 { get {return Body().S1151;} }
            public TTReportField S1181 { get {return Body().S1181;} }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField RAPORTARIHI2 { get {return Body().RAPORTARIHI2;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField81 { get {return Body().NewField81;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField NewField1011 { get {return Body().NewField1011;} }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField EVRAKTARIHI { get {return Body().EVRAKTARIHI;} }
            public TTReportField NewField15311 { get {return Body().NewField15311;} }
            public TTReportField BIRLIGI { get {return Body().BIRLIGI;} }
            public TTReportField SKULBL1 { get {return Body().SKULBL1;} }
            public TTReportField SKULBL2 { get {return Body().SKULBL2;} }
            public TTReportField SKULBL3 { get {return Body().SKULBL3;} }
            public TTReportField ADATE { get {return Body().ADATE;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportField NewField112511 { get {return Body().NewField112511;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField NewField113511 { get {return Body().NewField113511;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Body().TCKIMLIKNOBARKOD;} }
            public TTReportField FOTOGRAF1 { get {return Body().FOTOGRAF1;} }
            public TTReportField NewField198 { get {return Body().NewField198;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField MUAYENEAMACI { get {return Body().MUAYENEAMACI;} }
            public BIRLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BIRLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BIRLIKGroupBody(this);
            }

            public partial class BIRLIKGroupBody : TTReportSection
            {
                public HCPreDeclarationDocumentReport_3 MyParentReport
                {
                    get { return (HCPreDeclarationDocumentReport_3)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField46;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewFieldA;
                public TTReportField NewField11411;
                public TTReportField DYERTARIH;
                public TTReportField TCKN;
                public TTReportField EVRAKNO;
                public TTReportField NewFieldA11251;
                public TTReportField RAPORSEBEP;
                public TTReportField FOTOGRAF;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField RAPOR_NO;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField11761;
                public TTReportField TANI;
                public TTReportField NewField1101;
                public TTReportField ADISOYADI;
                public TTReportField BABAADI;
                public TTReportField NewField11521;
                public TTReportField NewField11821;
                public TTReportField NewField11921;
                public TTReportField NewFieldQ11251;
                public TTReportField XXXXXXLIKSUBE;
                public TTReportField NewField11251;
                public TTReportField MAKAM;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField110771;
                public TTReportField NewField11771;
                public TTReportField HASTANO;
                public TTReportField NewField1281;
                public TTReportField BASTABIP;
                public TTReportField AdditionalMembers;
                public TTReportField S1151;
                public TTReportField S1181;
                public TTReportField XXXXXXADI;
                public TTReportField NewField1161;
                public TTReportField RAPORTARIHI2;
                public TTReportField NewField17;
                public TTReportField NewField81;
                public TTReportField NewField191;
                public TTReportField NewField1011;
                public TTReportField NewField11111;
                public TTReportField NewField11211;
                public TTReportField BASLIK;
                public TTReportField DTARIHI;
                public TTReportField EVRAKTARIHI;
                public TTReportField NewField15311;
                public TTReportField BIRLIGI;
                public TTReportField SKULBL1;
                public TTReportField SKULBL2;
                public TTReportField SKULBL3;
                public TTReportField ADATE;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE;
                public TTReportField NewField112511;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField113511;
                public TTReportField BIRLIK;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportField FOTOGRAF1;
                public TTReportField NewField198;
                public TTReportField DECISIONTIME;
                public TTReportField NewField131;
                public TTReportField MUAYENEAMACI; 
                public BIRLIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 296;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 211, 200, 234, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"";

                    NewField46 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 92, 193, 102, false);
                    NewField46.Name = "NewField46";
                    NewField46.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField46.MultiLine = EvetHayirEnum.ehEvet;
                    NewField46.WordBreak = EvetHayirEnum.ehEvet;
                    NewField46.TextFont.Size = 9;
                    NewField46.Value = @"İLGİ: {%EVRAKTARIHI%} gün ve {#HEADER.EVRAKSAYISI#} sayılı sevk yazısı.";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 10, 172, 32, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%BASLIK%}
RAPOR ÖN BİLDİRİM BELGESİ";

                    NewFieldA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 37, 113, 41, false);
                    NewFieldA.Name = "NewFieldA";
                    NewFieldA.Value = @"KONU   : Sağlık Kurulu Raporu Hakkında";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 33, 30, 37, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.Value = @"SAĞ.KRL:";

                    DYERTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 260, 200, 264, false);
                    DYERTARIH.Name = "DYERTARIH";
                    DYERTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTARIH.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DYERTARIH.TextFont.Size = 8;
                    DYERTARIH.Value = @"{%DTARIHI%} / ";

                    TCKN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 38, 195, 42, false);
                    TCKN.Name = "TCKN";
                    TCKN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKN.MultiLine = EvetHayirEnum.ehEvet;
                    TCKN.NoClip = EvetHayirEnum.ehEvet;
                    TCKN.WordBreak = EvetHayirEnum.ehEvet;
                    TCKN.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKN.Value = @"{#HEADER.TCNO#}";

                    EVRAKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 33, 158, 37, false);
                    EVRAKNO.Name = "EVRAKNO";
                    EVRAKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKNO.Value = @"{#HEADER.ISLEMNO#}-{#HEADER.PROTOKOLNO#}-{%ADATE%}/SAĞ.KRL.-{#HEADER.ISLEMNO#}";

                    NewFieldA11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 250, 235, 254, false);
                    NewFieldA11251.Name = "NewFieldA11251";
                    NewFieldA11251.Visible = EvetHayirEnum.ehHayir;
                    NewFieldA11251.TextFont.Size = 8;
                    NewFieldA11251.TextFont.Bold = true;
                    NewFieldA11251.Value = @"Hasta Nu :";

                    RAPORSEBEP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 299, 4, false);
                    RAPORSEBEP.Name = "RAPORSEBEP";
                    RAPORSEBEP.Visible = EvetHayirEnum.ehHayir;
                    RAPORSEBEP.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSEBEP.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSEBEP.Value = @"";

                    FOTOGRAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 54, 193, 82, false);
                    FOTOGRAF.Name = "FOTOGRAF";
                    FOTOGRAF.Visible = EvetHayirEnum.ehHayir;
                    FOTOGRAF.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTOGRAF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF.WordBreak = EvetHayirEnum.ehEvet;
                    FOTOGRAF.TextFont.Size = 8;
                    FOTOGRAF.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 165, 38, 169, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.Value = @"Rapor Tarihi  :";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 169, 38, 173, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.Value = @"Rapor Nu.     :";

                    RAPOR_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 169, 92, 173, false);
                    RAPOR_NO.Name = "RAPOR_NO";
                    RAPOR_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR_NO.TextFont.Size = 9;
                    RAPOR_NO.Value = @"{#HEADER.RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 165, 92, 169, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.TextFont.Size = 9;
                    RAPORTARIHI.Value = @"{#HEADER.RAPORTARIHI#}";

                    NewField11761 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 211, 38, 215, false);
                    NewField11761.Name = "NewField11761";
                    NewField11761.TextFont.Size = 9;
                    NewField11761.Value = @"Karar         :";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 173, 200, 211, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 173, 38, 177, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.TextFont.Size = 9;
                    NewField1101.Value = @"Teşhis        :";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 244, 200, 248, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{#HEADER.PNAME#} {#HEADER.PSURNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 256, 200, 260, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#HEADER.FATHERNAME#}";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 244, 66, 248, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.TextFont.Size = 8;
                    NewField11521.TextFont.Bold = true;
                    NewField11521.Value = @"Adı Soyadı                   :";

                    NewField11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 256, 66, 260, false);
                    NewField11821.Name = "NewField11821";
                    NewField11821.TextFont.Size = 8;
                    NewField11821.TextFont.Bold = true;
                    NewField11821.Value = @"Baba Adı                     :";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 260, 66, 264, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.TextFont.Size = 8;
                    NewField11921.TextFont.Bold = true;
                    NewField11921.Value = @"Doğum Tarihi / Doğum Yeri    :";

                    NewFieldQ11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 264, 66, 268, false);
                    NewFieldQ11251.Name = "NewFieldQ11251";
                    NewFieldQ11251.TextFont.Size = 8;
                    NewFieldQ11251.TextFont.Bold = true;
                    NewFieldQ11251.Value = @"Sevki Yapan As. Ş. / Birlik  :";

                    XXXXXXLIKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 268, 200, 272, false);
                    XXXXXXLIKSUBE.Name = "XXXXXXLIKSUBE";
                    XXXXXXLIKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE.TextFont.Size = 8;
                    XXXXXXLIKSUBE.Value = @"";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 268, 66, 272, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.TextFont.Size = 8;
                    NewField11251.TextFont.Bold = true;
                    NewField11251.Value = @"N.Kayıtlı Olduğu As Ş.       :";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 264, 200, 268, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 240, 200, 244, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#HEADER.TCNO#}";

                    NewField110771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 235, 66, 239, false);
                    NewField110771.Name = "NewField110771";
                    NewField110771.TextFont.Size = 8;
                    NewField110771.TextFont.Bold = true;
                    NewField110771.TextFont.Underline = true;
                    NewField110771.Value = @"KİMLİĞİ                      ";

                    NewField11771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 240, 66, 244, false);
                    NewField11771.Name = "NewField11771";
                    NewField11771.TextFont.Size = 8;
                    NewField11771.TextFont.Bold = true;
                    NewField11771.Value = @"TC Kimlik Nu.                :";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 250, 262, 254, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.Size = 8;
                    HASTANO.Value = @"{#HEADER.PID#}";

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 103, 193, 128, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1281.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1281.TextFont.Size = 9;
                    NewField1281.Value = @"1. İlgi  ile  XXXXXXmize  sevk  edilen  aşağıda   açık kimliği  yazılı  kişinin, Sağlık Kurulu'ndan almış olduğu karar ile rapor tarih ve numarası aşağıda çıkarılmıştır. 

2. Düzenlenmekte olan Sağlık Kurulu raporu üst onay makamınca onaylandıktan sonra gönderilecektir. 

Arz / Rica ederim. ";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 139, 192, 158, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Size = 8;
                    BASTABIP.Value = @"";

                    AdditionalMembers = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 139, 146, 158, false);
                    AdditionalMembers.Name = "AdditionalMembers";
                    AdditionalMembers.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdditionalMembers.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionalMembers.MultiLine = EvetHayirEnum.ehEvet;
                    AdditionalMembers.WordBreak = EvetHayirEnum.ehEvet;
                    AdditionalMembers.ExpandTabs = EvetHayirEnum.ehEvet;
                    AdditionalMembers.TextFont.Size = 8;
                    AdditionalMembers.Value = @"";

                    S1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 93, 451, 107, false);
                    S1151.Name = "S1151";
                    S1151.Visible = EvetHayirEnum.ehHayir;
                    S1151.FieldType = ReportFieldTypeEnum.ftVariable;
                    S1151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S1151.MultiLine = EvetHayirEnum.ehEvet;
                    S1151.WordBreak = EvetHayirEnum.ehEvet;
                    S1151.ExpandTabs = EvetHayirEnum.ehEvet;
                    S1151.TextFont.Size = 8;
                    S1151.Value = @"";

                    S1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 111, 451, 125, false);
                    S1181.Name = "S1181";
                    S1181.Visible = EvetHayirEnum.ehHayir;
                    S1181.FieldType = ReportFieldTypeEnum.ftVariable;
                    S1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S1181.MultiLine = EvetHayirEnum.ehEvet;
                    S1181.WordBreak = EvetHayirEnum.ehEvet;
                    S1181.ExpandTabs = EvetHayirEnum.ehEvet;
                    S1181.TextFont.Size = 8;
                    S1181.Value = @"";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 96, 252, 100, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.TextFont.Size = 8;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 33, 30, 37, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"";

                    RAPORTARIHI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 33, 195, 37, false);
                    RAPORTARIHI2.Name = "RAPORTARIHI2";
                    RAPORTARIHI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI2.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTARIHI2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI2.Value = @"{@printdate@}";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 133, 192, 138, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Size = 8;
                    NewField17.Value = @"Sağlık Kurulu Başkanı";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 104, 233, 109, false);
                    NewField81.Name = "NewField81";
                    NewField81.Visible = EvetHayirEnum.ehHayir;
                    NewField81.TextFont.Bold = true;
                    NewField81.Value = @"İLGİ:";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 113, 226, 117, false);
                    NewField191.Name = "NewField191";
                    NewField191.Visible = EvetHayirEnum.ehHayir;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"1.";

                    NewField1011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 119, 226, 123, false);
                    NewField1011.Name = "NewField1011";
                    NewField1011.Visible = EvetHayirEnum.ehHayir;
                    NewField1011.TextFont.Bold = true;
                    NewField1011.Value = @"2.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 37, 30, 41, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"KONU   :";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 33, 31, 37, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"SAĞ.KRL:";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 24, 241, 29, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 32, 240, 37, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#HEADER.DTARIHI#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 37, 240, 42, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.Value = @"{#HEADER.EVRAKTARIHI#}";

                    NewField15311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 83, 203, 91, false);
                    NewField15311.Name = "NewField15311";
                    NewField15311.TextColor = System.Drawing.Color.Gray;
                    NewField15311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15311.NoClip = EvetHayirEnum.ehEvet;
                    NewField15311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField15311.TextFont.Size = 8;
                    NewField15311.Value = @"XXXXXXliğe Elverişli
Değildir Kararlılarda";

                    BIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 65, 161, 85, false);
                    BIRLIGI.Name = "BIRLIGI";
                    BIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIGI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIGI.TextFont.Bold = true;
                    BIRLIGI.Value = @"";

                    SKULBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 133, 45, 138, false);
                    SKULBL1.Name = "SKULBL1";
                    SKULBL1.Visible = EvetHayirEnum.ehHayir;
                    SKULBL1.TextFont.Size = 8;
                    SKULBL1.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 133, 90, 138, false);
                    SKULBL2.Name = "SKULBL2";
                    SKULBL2.Visible = EvetHayirEnum.ehHayir;
                    SKULBL2.TextFont.Size = 8;
                    SKULBL2.Value = @"Sağlık Kurulu Üyesi";

                    SKULBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 133, 136, 138, false);
                    SKULBL3.Name = "SKULBL3";
                    SKULBL3.Visible = EvetHayirEnum.ehHayir;
                    SKULBL3.TextFont.Size = 8;
                    SKULBL3.Value = @"Sağlık Kurulu Üyesi";

                    ADATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 44, 241, 49, false);
                    ADATE.Name = "ADATE";
                    ADATE.Visible = EvetHayirEnum.ehHayir;
                    ADATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADATE.TextFormat = @"Short Date";
                    ADATE.TextFont.Name = "Arial Narrow";
                    ADATE.TextFont.CharSet = 1;
                    ADATE.Value = @"{#HEADER.ADATE#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 233, 242, 238, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#HEADER.DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 241, 242, 246, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#HEADER.DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 225, 242, 230, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#HEADER.DOGUMYERIULKE#}";

                    NewField112511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 252, 66, 256, false);
                    NewField112511.Name = "NewField112511";
                    NewField112511.TextFont.Size = 8;
                    NewField112511.TextFont.Bold = true;
                    NewField112511.Value = @"Sınıf ve Rütbesi             :";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 252, 200, 256, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    NewField113511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 248, 66, 252, false);
                    NewField113511.Name = "NewField113511";
                    NewField113511.TextFont.Size = 8;
                    NewField113511.TextFont.Bold = true;
                    NewField113511.Value = @"Birlik                       :";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 248, 200, 252, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 43, 193, 53, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    FOTOGRAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 54, 193, 82, false);
                    FOTOGRAF1.Name = "FOTOGRAF1";
                    FOTOGRAF1.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTOGRAF1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF1.TextFont.Size = 8;
                    FOTOGRAF1.Value = @"FOTOGRAF";

                    NewField198 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 276, 201, 293, false);
                    NewField198.Name = "NewField198";
                    NewField198.MultiLine = EvetHayirEnum.ehEvet;
                    NewField198.NoClip = EvetHayirEnum.ehEvet;
                    NewField198.WordBreak = EvetHayirEnum.ehEvet;
                    NewField198.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField198.TextFont.Size = 8;
                    NewField198.Value = @"Not : ""İlgili personelin ön raporudur. Bu belge ile kesin işlem yapılamaz. Kat'i Rapor onay işlemleri tamamlandıktan sonra MSB.lığı ve XXXXXX Sağlık K.lığınca gönderilecektir. ""XXXXXXliğe Elverişli Değildir"", ""XXXXXXnde Görev Yapamaz"" kararı alan personel rapor onaylanana kadar sıhhi izinli sayılır. Ayrıca bu ön rapora istinaden erbaş/erlerin şahsi dosyaları XXXXXXlik Şubelerine gönderilir.""  ";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 214, 241, 219, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 161, 38, 165, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.Value = @"Muayene Amacı :";

                    MUAYENEAMACI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 161, 200, 165, false);
                    MUAYENEAMACI.Name = "MUAYENEAMACI";
                    MUAYENEAMACI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEAMACI.TextFont.Size = 9;
                    MUAYENEAMACI.Value = @"{#HEADER.SKSEBEBI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.HEADER.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    KARAR.CalcValue = @"";
                    EVRAKTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField46.CalcValue = @"İLGİ: " + MyParentReport.BIRLIK.EVRAKTARIHI.FormattedValue + @" gün ve " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "") + @" sayılı sevk yazısı.";
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    XXXXXXBASLIK.CalcValue = MyParentReport.BIRLIK.BASLIK.CalcValue + @"
RAPOR ÖN BİLDİRİM BELGESİ";
                    NewFieldA.CalcValue = NewFieldA.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    DYERTARIH.CalcValue = MyParentReport.BIRLIK.DTARIHI.FormattedValue + @" / ";
                    TCKN.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    ADATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adate) : "");
                    EVRAKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "") + @"-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Protokolno) : "") + @"-" + MyParentReport.BIRLIK.ADATE.FormattedValue + @"/SAĞ.KRL.-" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    NewFieldA11251.CalcValue = NewFieldA11251.Value;
                    RAPORSEBEP.CalcValue = @"";
                    FOTOGRAF.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    RAPOR_NO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NewField11761.CalcValue = NewField11761.Value;
                    TANI.CalcValue = @"";
                    NewField1101.CalcValue = NewField1101.Value;
                    ADISOYADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField11821.CalcValue = NewField11821.Value;
                    NewField11921.CalcValue = NewField11921.Value;
                    NewFieldQ11251.CalcValue = NewFieldQ11251.Value;
                    XXXXXXLIKSUBE.CalcValue = @"";
                    NewField11251.CalcValue = NewField11251.Value;
                    MAKAM.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField110771.CalcValue = NewField110771.Value;
                    NewField11771.CalcValue = NewField11771.Value;
                    HASTANO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    NewField1281.CalcValue = NewField1281.Value;
                    BASTABIP.CalcValue = @"";
                    AdditionalMembers.CalcValue = @"";
                    S1151.CalcValue = @"";
                    S1181.CalcValue = @"";
                    NewField1161.CalcValue = NewField1161.Value;
                    RAPORTARIHI2.CalcValue = DateTime.Now.ToShortDateString();
                    NewField17.CalcValue = NewField17.Value;
                    NewField81.CalcValue = NewField81.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1011.CalcValue = NewField1011.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField15311.CalcValue = NewField15311.Value;
                    BIRLIGI.CalcValue = @"";
                    SKULBL1.CalcValue = SKULBL1.Value;
                    SKULBL2.CalcValue = SKULBL2.Value;
                    SKULBL3.CalcValue = SKULBL3.Value;
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriulke) : "");
                    NewField112511.CalcValue = NewField112511.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField113511.CalcValue = NewField113511.Value;
                    BIRLIK.CalcValue = @"";
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    FOTOGRAF1.CalcValue = FOTOGRAF1.Value;
                    NewField198.CalcValue = NewField198.Value;
                    DECISIONTIME.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    MUAYENEAMACI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { KARAR,EVRAKTARIHI,NewField46,BASLIK,XXXXXXBASLIK,NewFieldA,NewField11411,DTARIHI,DYERTARIH,TCKN,ADATE,EVRAKNO,NewFieldA11251,RAPORSEBEP,FOTOGRAF,NewField1131,NewField1141,RAPOR_NO,RAPORTARIHI,NewField11761,TANI,NewField1101,ADISOYADI,BABAADI,NewField11521,NewField11821,NewField11921,NewFieldQ11251,XXXXXXLIKSUBE,NewField11251,MAKAM,TCKIMLIKNO,NewField110771,NewField11771,HASTANO,NewField1281,BASTABIP,AdditionalMembers,S1151,S1181,NewField1161,RAPORTARIHI2,NewField17,NewField81,NewField191,NewField1011,NewField11111,NewField11211,NewField15311,BIRLIGI,SKULBL1,SKULBL2,SKULBL3,DYERILCE,DYERIL,DYERULKE,NewField112511,SINIFRUTBE,NewField113511,BIRLIK,TCKIMLIKNOBARKOD,FOTOGRAF1,NewField198,DECISIONTIME,NewField131,MUAYENEAMACI,XXXXXXADI};
                }

                public override void RunScript()
                {
#region BIRLIK BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPreDeclarationDocumentReport_3)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
//
            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
            
            /* Yakınlık derecesinin artık görünmemesi istendi (27.07.2016 Mustafa)
            if (hc.Episode.MyRelationship() != null)
            {
                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            }
             */
            
            //SK Başkanı
            const int SPECIALITY_COUNT = 25;
            string sMemberSpeciality = "";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string sEmpID = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string sName = member.MemberDoctor.Name;
                    string sTitle = ""; //(hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass == null ? "" : hc.MemberOfHealthCommittee.MasterOfHealthCommittee2.MilitaryClass.ShortName);
                    sTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    sTitle += (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);

                    string specialityRow1 = "";
                    string specialityRow2 = "";

                    if (member.MemberDoctor.GetSpeciality() != null)
                        sMemberSpeciality = member.MemberDoctor.GetSpeciality().Name;

                    if (sMemberSpeciality != "")
                    {
                        sMemberSpeciality += " Uzm.";
                        if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                        {
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT * 2)
                                sMemberSpeciality = sMemberSpeciality.Substring(0, SPECIALITY_COUNT * 2);

                            specialityRow1 = sMemberSpeciality.Substring(0, SPECIALITY_COUNT);
                            specialityRow2 = sMemberSpeciality.Substring(SPECIALITY_COUNT, sMemberSpeciality.Length - SPECIALITY_COUNT);
                        }
                        else
                        {
                            specialityRow1 = sMemberSpeciality;
                            specialityRow2 = "";
                        }
                    }
                    else
                    {
                        specialityRow1 = "";
                        specialityRow2 = "";
                    }

                    string sMasterText = sName + "\n" + sTitle + "(" + sEmpID + ")" + "\n" + specialityRow1 + "\n" + specialityRow2;

                    this.BASTABIP.CalcValue = sMasterText;
                }
            }
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                string maddeDilimFikra = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    maddeDilimFikra += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    maddeDilimFikra += "  ";
                }
                maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                maddeDilimFikra += "]";
                
                this.KARAR.CalcValue = maddeDilimFikra + "\n";
            }

            // Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\n";
            }
            
            // Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            //AdditionalMembers
            //            if (hc.UnsuitableForMilitaryService == true)
            //            {
            //                if(hc.MemberOfHealthCommittee != null)
            //                {
            //                    string sCrLf = "\r\n";
            //                    string sMembersText = "";// = sCrLf;
            //                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId;
//
            //                    const int COLUMN_COUNT = 3;
            //                    const int SPACE_COUNT = 27;
            //                    int nCounter = 0;
            //                    int nRow = 0;
//
            //                    //string sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                    string sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
//
            //                    foreach(HealthCommitteAdditionalMemberGrid pMember in hc.MemberOfHealthCommittee.AdditionalMembers)
            //                    {
            //                        sMemberName = pMember.Doctor.Name;
            //                        sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
            //                        sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
            //                        sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
            //                        sMemberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
//
            //                        //sHeaderRow = sHeaderRow.Insert(nCounter, "Sağlık Kurulu Üyesi");
            //                        sNameRow = sNameRow.Insert(nCounter, sMemberName);
            //                        //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
            //                        //sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);
            //                        sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
            //                        //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
//
            //                        if (pMember.Doctor.GetSpeciality() != null)
            //                            sMemberSpeciality = pMember.Doctor.GetSpeciality().Name;
            //                        else
            //                            sMemberSpeciality = "";
//
            //                        if (sMemberSpeciality != "")
            //                        {
            //                            sMemberSpeciality += " Uzm.";
            //                            if (sMemberSpeciality.Length > SPECIALITY_COUNT)
            //                            {
            //                                if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
            //                                    sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
//
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
            //                            }
            //                            else
            //                            {
            //                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
            //                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            sTitleRow = sTitleRow.Insert(nCounter, "");
            //                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
            //                        }
//
            //                        nCounter += SPACE_COUNT;
//
            //                        nRow = nCounter / SPACE_COUNT;
            //                        int nRate = nRow % COLUMN_COUNT;
            //                        if (nRate == 0)
            //                        {
            //                            //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                            //sMembersText += sHeaderRow + "\r\n";
            //                            sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sNameRow + "\r\n";
            //                            sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sRankRow + "\r\n";
            //                            sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sTitleRow + "\r\n";
            //                            sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                            sMembersText += sSpecialityRow + "\r\n";
//
//
            //                            //sHeaderRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
            //                            sSpecialityRow = new string(' ',SPACE_COUNT * COLUMN_COUNT);
//
            //                            sMembersText +=  sCrLf + sCrLf + sCrLf;
            //                            nCounter = 0;
            //                        }
            //                    }
//
            //                    //sHeaderRow = sHeaderRow.TrimEnd(new char[] { ' ' });
            //                    //sMembersText += sHeaderRow + "\r\n";
            //                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sNameRow + "\r\n";
            //                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sRankRow + "\r\n";
            //                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sTitleRow + "\r\n";
            //                    sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
            //                    sMembersText += sSpecialityRow + "\r\n";
//
            //                    this.AdditionalMembers.CalcValue = sMembersText;
//
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 0)
            //                        this.SKULBL1.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 1)
            //                        this.SKULBL2.Visible = EvetHayirEnum.ehEvet;
            //                    if (hc.MemberOfHealthCommittee.AdditionalMembers.Count > 2)
            //                        this.SKULBL3.Visible = EvetHayirEnum.ehEvet;
            //                }
            //                this.FOTOGRAF.Visible = EvetHayirEnum.ehEvet;
            //                this.NewField15311.Visible = EvetHayirEnum.ehHayir;
            //                this.FOTOGRAF1.Visible = EvetHayirEnum.ehHayir;
            //            }

            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIlce;
                else
                    this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            }
            else if (dogumIl.Trim() != "")
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumIl;
            else
                this.DYERTARIH.CalcValue = this.DYERTARIH.CalcValue + dogumUlke;
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCPREDECREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKN.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKN.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
#endregion BIRLIK BODY_Script
                }
            }

        }

        public BIRLIKGroup BIRLIK;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HCPreDeclarationDocumentReport_3()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            SAHIS = new SAHISGroup(HEADER,"SAHIS");
            XXXXXXLIKSUBESI = new XXXXXXLIKSUBESIGroup(HEADER,"XXXXXXLIKSUBESI");
            BIRLIK = new BIRLIKGroup(HEADER,"BIRLIK");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "C7203EFB-0742-4709-9E32-6D3608F9C34F", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCPREDECLARATIONDOCUMENTREPORT_3";
            Caption = "Sağlık Kurulu Ön Bildirim Belgesi(Dosya Sureti,Sahsa, XXXXXXlik Şubesine ve Birliğe)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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
            fd.TextFont.Name = "Courier New";
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