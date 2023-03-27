
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
    /// Tedavi Kararı Raporu
    /// </summary>
    public partial class TreatmentDischargeReport : TTReport
    {
#region Methods
   //
//   public List<DagitimBilgi> dagitimList = new List<DagitimBilgi>();
//        public string dagitim = "";
//        public string Saymanlik = "";
//        
//        public class DagitimBilgi
//        {
//            public string Baslik;
//            public EvetHayirEnum IsSaymanlikVisible;
//            public string Yazi;
//
//            public DagitimBilgi(string baslik, EvetHayirEnum isSaymanlikVisible, string yazi)
//            {
//                Baslik = baslik;
//                IsSaymanlikVisible = isSaymanlikVisible;
//                yazi = Yazi;
//            }
//        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Counter_GroupGroup : TTReportGroup
        {
            public TreatmentDischargeReport MyParentReport
            {
                get { return (TreatmentDischargeReport)ParentReport; }
            }

            new public Counter_GroupGroupHeader Header()
            {
                return (Counter_GroupGroupHeader)_header;
            }

            new public Counter_GroupGroupFooter Footer()
            {
                return (Counter_GroupGroupFooter)_footer;
            }

            public Counter_GroupGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Counter_GroupGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Counter_GroupGroupHeader(this);
                _footer = new Counter_GroupGroupFooter(this);

            }

            public partial class Counter_GroupGroupHeader : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                 
                public Counter_GroupGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class Counter_GroupGroupFooter : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                 
                public Counter_GroupGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public Counter_GroupGroup Counter_Group;

        public partial class HeaderGroup : TTReportGroup
        {
            public TreatmentDischargeReport MyParentReport
            {
                get { return (TreatmentDischargeReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField YAZI { get {return Header().YAZI;} }
            public TTReportField YAZIAYAKTAN { get {return Header().YAZIAYAKTAN;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField BIRIMPRTNO { get {return Header().BIRIMPRTNO;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField RUTBE { get {return Header().RUTBE;} }
            public TTReportField SINIF { get {return Header().SINIF;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField DAGIT { get {return Header().DAGIT;} }
            public TTReportField DAGITIM2 { get {return Header().DAGITIM2;} }
            public TTReportField DAGITIM1 { get {return Header().DAGITIM1;} }
            public TTReportField SAG { get {return Header().SAG;} }
            public TTReportField DYERIDTARIHI { get {return Header().DYERIDTARIHI;} }
            public TTReportField SINRUTBE { get {return Header().SINRUTBE;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField AD { get {return Header().AD;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField BAB { get {return Header().BAB;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField NewField270 { get {return Header().NewField270;} }
            public TTReportField NewField28 { get {return Header().NewField28;} }
            public TTReportField BIRLIGI { get {return Header().BIRLIGI;} }
            public TTReportField NewField30 { get {return Header().NewField30;} }
            public TTReportField BIR { get {return Header().BIR;} }
            public TTReportField DAGITIM12 { get {return Header().DAGITIM12;} }
            public TTReportField DAGITIM11 { get {return Header().DAGITIM11;} }
            public TTReportField DAGITIM13 { get {return Header().DAGITIM13;} }
            public TTReportField DAGITIM14 { get {return Header().DAGITIM14;} }
            public TTReportField KIMLIK { get {return Header().KIMLIK;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField NewField42 { get {return Header().NewField42;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField KarantinaPNLable { get {return Header().KarantinaPNLable;} }
            public TTReportField YatısTarihiLable { get {return Header().YatısTarihiLable;} }
            public TTReportField CıkısTarihiLable { get {return Header().CıkısTarihiLable;} }
            public TTReportField HPROTOKOL { get {return Header().HPROTOKOL;} }
            public TTReportField KPROTOKOLNO { get {return Header().KPROTOKOLNO;} }
            public TTReportField YATISTARIH { get {return Header().YATISTARIH;} }
            public TTReportField CIKISTARIH { get {return Header().CIKISTARIH;} }
            public TTReportField YAZIKODU { get {return Header().YAZIKODU;} }
            public TTReportField SAGNO { get {return Header().SAGNO;} }
            public TTReportField NewField55 { get {return Header().NewField55;} }
            public TTReportField KarantinaPNLableNokta { get {return Header().KarantinaPNLableNokta;} }
            public TTReportField NewField57 { get {return Header().NewField57;} }
            public TTReportField NewField58 { get {return Header().NewField58;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField60 { get {return Header().NewField60;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField SINRUT { get {return Header().SINRUT;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField ACTIONDATE2 { get {return Header().ACTIONDATE2;} }
            public TTReportField ONAY { get {return Header().ONAY;} }
            public TTReportField EXTRACOPIES { get {return Header().EXTRACOPIES;} }
            public TTReportField DAGITIM15 { get {return Header().DAGITIM15;} }
            public TTReportField DAGITIM16 { get {return Header().DAGITIM16;} }
            public TTReportField FOTO { get {return Header().FOTO;} }
            public TTReportField LBLFOTO { get {return Header().LBLFOTO;} }
            public TTReportField KimlikNolabel { get {return Header().KimlikNolabel;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField Cinsiyeti { get {return Header().Cinsiyeti;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField CINSIYETI { get {return Header().CINSIYETI;} }
            public TTReportField SIVILNOT { get {return Footer().SIVILNOT;} }
            public TTReportField NewField1181 { get {return Footer().NewField1181;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<TreatmentDischarge.TreatmentDischargeReport_Class>("TreatmentDischargeReportNQL", TreatmentDischarge.TreatmentDischargeReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField YAZI;
                public TTReportField YAZIAYAKTAN;
                public TTReportField ACTIONDATE;
                public TTReportField BIRIMPRTNO;
                public TTReportField BIRIMADI;
                public TTReportField RUTBE;
                public TTReportField SINIF;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField RAPORNO;
                public TTReportField KONU;
                public TTReportField DAGIT;
                public TTReportField DAGITIM2;
                public TTReportField DAGITIM1;
                public TTReportField SAG;
                public TTReportField DYERIDTARIHI;
                public TTReportField SINRUTBE;
                public TTReportField NewField19;
                public TTReportField BABAADI;
                public TTReportField AD;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField BAB;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField270;
                public TTReportField NewField28;
                public TTReportField BIRLIGI;
                public TTReportField NewField30;
                public TTReportField BIR;
                public TTReportField DAGITIM12;
                public TTReportField DAGITIM11;
                public TTReportField DAGITIM13;
                public TTReportField DAGITIM14;
                public TTReportField KIMLIK;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportField NewField42;
                public TTReportShape NewLine3;
                public TTReportField NewField44;
                public TTReportField KarantinaPNLable;
                public TTReportField YatısTarihiLable;
                public TTReportField CıkısTarihiLable;
                public TTReportField HPROTOKOL;
                public TTReportField KPROTOKOLNO;
                public TTReportField YATISTARIH;
                public TTReportField CIKISTARIH;
                public TTReportField YAZIKODU;
                public TTReportField SAGNO;
                public TTReportField NewField55;
                public TTReportField KarantinaPNLableNokta;
                public TTReportField NewField57;
                public TTReportField NewField58;
                public TTReportField ACTIONID;
                public TTReportField NewField60;
                public TTReportShape NewLine4;
                public TTReportField SINRUT;
                public TTReportField HASTANO;
                public TTReportField ADSOYAD;
                public TTReportField ACTIONDATE2;
                public TTReportField ONAY;
                public TTReportField EXTRACOPIES;
                public TTReportField DAGITIM15;
                public TTReportField DAGITIM16;
                public TTReportField FOTO;
                public TTReportField LBLFOTO;
                public TTReportField KimlikNolabel;
                public TTReportField NewField142;
                public TTReportField KIMLIKNO;
                public TTReportField EPISODE;
                public TTReportField NewField102;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField Cinsiyeti;
                public TTReportField NewField1241;
                public TTReportField CINSIYETI; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 194;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    YAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 52, 200, 66, false);
                    YAZI.Name = "YAZI";
                    YAZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZI.MultiLine = EvetHayirEnum.ehEvet;
                    YAZI.WordBreak = EvetHayirEnum.ehEvet;
                    YAZI.TextFont.Name = "Arial Narrow";
                    YAZI.TextFont.Size = 9;
                    YAZI.Value = @"Aşağıda açık kimliği yazılı personelin {%BIRIMADI%}'ne yatırılarak yapılan muayene ve tedavi sonucu bildirilmiştir.
Arz/Rica ederim.";

                    YAZIAYAKTAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 53, 200, 67, false);
                    YAZIAYAKTAN.Name = "YAZIAYAKTAN";
                    YAZIAYAKTAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZIAYAKTAN.MultiLine = EvetHayirEnum.ehEvet;
                    YAZIAYAKTAN.WordBreak = EvetHayirEnum.ehEvet;
                    YAZIAYAKTAN.TextFont.Name = "Arial Narrow";
                    YAZIAYAKTAN.TextFont.Size = 9;
                    YAZIAYAKTAN.Value = @"Aşağıda açık kimliği yazılı personelin {%BIRIMADI%}'nde yapılan muayene ve tedavi sonucu bildirilmiştir.
Arz/Rica ederim.";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 30, 200, 34, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDATE.TextFont.Size = 9;
                    ACTIONDATE.Value = @"{#REQUESTDATE#}";

                    BIRIMPRTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 16, 254, 20, false);
                    BIRIMPRTNO.Name = "BIRIMPRTNO";
                    BIRIMPRTNO.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPRTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPRTNO.TextFont.Name = "Arial";
                    BIRIMPRTNO.Value = @"{#PROTOCOLNO#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 26, 254, 30, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.TextFont.Name = "Arial";
                    BIRIMADI.Value = @"{#FROMRES#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 66, 253, 70, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial";
                    RUTBE.Value = @"";

                    SINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 78, 253, 82, false);
                    SINIF.Name = "SINIF";
                    SINIF.Visible = EvetHayirEnum.ehHayir;
                    SINIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIF.TextFont.Name = "Arial";
                    SINIF.Value = @"";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 74, 253, 78, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial";
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 70, 253, 74, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial";
                    DYER.Value = @"{#CITYNAME#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 50, 253, 54, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.Visible = EvetHayirEnum.ehHayir;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial";
                    RAPORNO.Value = @"";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 167, 45, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.TextFont.Name = "Arial Narrow";
                    KONU.TextFont.Size = 9;
                    KONU.Value = @"KONU : Hasta Tedavi Kararı";

                    DAGIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 79, 117, 83, false);
                    DAGIT.Name = "DAGIT";
                    DAGIT.TextFont.Name = "Arial Narrow";
                    DAGIT.TextFont.Size = 9;
                    DAGIT.Value = @"DAĞITIM                                     :";

                    DAGITIM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 90, 164, 114, false);
                    DAGITIM2.Name = "DAGITIM2";
                    DAGITIM2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    DAGITIM2.MultiLine = EvetHayirEnum.ehEvet;
                    DAGITIM2.TextFont.Name = "Arial Narrow";
                    DAGITIM2.TextFont.Size = 9;
                    DAGITIM2.Value = @"";

                    DAGITIM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 46, 200, 51, false);
                    DAGITIM1.Name = "DAGITIM1";
                    DAGITIM1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DAGITIM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAGITIM1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    DAGITIM1.MultiLine = EvetHayirEnum.ehEvet;
                    DAGITIM1.TextFont.Name = "Arial Narrow";
                    DAGITIM1.TextFont.Size = 9;
                    DAGITIM1.TextFont.Bold = true;
                    DAGITIM1.Value = @"{%DAGITIM11%}
{%DAGITIM12%}
{%DAGITIM13%}
{%DAGITIM14%}";

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 35, 167, 39, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.TextFont.Name = "Arial Narrow";
                    SAG.TextFont.Size = 9;
                    SAG.Value = @"SAĞ:{%SAGNO%}-{%BIRIMPRTNO%}-{%ACTIONDATE2%} / {%BIRIMADI%}-{%ACTIONID%}";

                    DYERIDTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 162, 201, 166, false);
                    DYERIDTARIHI.Name = "DYERIDTARIHI";
                    DYERIDTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIDTARIHI.TextFont.Name = "Arial Narrow";
                    DYERIDTARIHI.TextFont.Size = 9;
                    DYERIDTARIHI.Value = @"{%DYER%} / {%DTARIH%}";

                    SINRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 147, 57, 151, false);
                    SINRUTBE.Name = "SINRUTBE";
                    SINRUTBE.TextFont.Name = "Arial Narrow";
                    SINRUTBE.TextFont.Size = 9;
                    SINRUTBE.TextFont.Bold = true;
                    SINRUTBE.Value = @"Sınıf ve Rütbesi";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 162, 57, 166, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Doğum Yeri ve Tarihi";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 157, 201, 161, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 9;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 137, 57, 141, false);
                    AD.Name = "AD";
                    AD.TextFont.Name = "Arial Narrow";
                    AD.TextFont.Size = 9;
                    AD.TextFont.Bold = true;
                    AD.Value = @"Adı Soyadı";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 147, 69, 151, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Size = 9;
                    NewField23.Value = @":";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 137, 69, 141, false);
                    NewField24.Name = "NewField24";
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.Value = @":";

                    BAB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 157, 57, 161, false);
                    BAB.Name = "BAB";
                    BAB.TextFont.Name = "Arial Narrow";
                    BAB.TextFont.Size = 9;
                    BAB.TextFont.Bold = true;
                    BAB.Value = @"Baba Adı";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 82, 253, 86, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.Visible = EvetHayirEnum.ehHayir;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Name = "Arial";
                    SINIFRUTBE.Value = @"";

                    NewField270 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 162, 69, 166, false);
                    NewField270.Name = "NewField270";
                    NewField270.TextFont.Name = "Arial Narrow";
                    NewField270.TextFont.Size = 9;
                    NewField270.Value = @":";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 157, 69, 161, false);
                    NewField28.Name = "NewField28";
                    NewField28.TextFont.Name = "Arial Narrow";
                    NewField28.TextFont.Size = 9;
                    NewField28.Value = @":";

                    BIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 152, 201, 156, false);
                    BIRLIGI.Name = "BIRLIGI";
                    BIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIGI.TextFont.Name = "Arial Narrow";
                    BIRLIGI.TextFont.Size = 9;
                    BIRLIGI.Value = @"";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 152, 69, 156, false);
                    NewField30.Name = "NewField30";
                    NewField30.TextFont.Name = "Arial Narrow";
                    NewField30.TextFont.Size = 9;
                    NewField30.Value = @":";

                    BIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 152, 57, 156, false);
                    BIR.Name = "BIR";
                    BIR.TextFont.Name = "Arial Narrow";
                    BIR.TextFont.Size = 9;
                    BIR.TextFont.Bold = true;
                    BIR.Value = @"Birliği";

                    DAGITIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 129, 253, 133, false);
                    DAGITIM12.Name = "DAGITIM12";
                    DAGITIM12.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM12.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM12.TextFont.Name = "Arial";
                    DAGITIM12.Value = @"";

                    DAGITIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 125, 253, 129, false);
                    DAGITIM11.Name = "DAGITIM11";
                    DAGITIM11.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM11.MultiLine = EvetHayirEnum.ehEvet;
                    DAGITIM11.TextFont.Name = "Arial";
                    DAGITIM11.Value = @"";

                    DAGITIM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 133, 253, 137, false);
                    DAGITIM13.Name = "DAGITIM13";
                    DAGITIM13.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM13.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM13.TextFont.Name = "Arial";
                    DAGITIM13.Value = @"";

                    DAGITIM14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 137, 253, 141, false);
                    DAGITIM14.Name = "DAGITIM14";
                    DAGITIM14.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM14.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM14.TextFont.Name = "Arial";
                    DAGITIM14.Value = @"";

                    KIMLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 126, 112, 130, false);
                    KIMLIK.Name = "KIMLIK";
                    KIMLIK.TextFont.Name = "Arial Narrow";
                    KIMLIK.TextFont.Size = 9;
                    KIMLIK.TextFont.Bold = true;
                    KIMLIK.Value = @"KİMLİĞİ                                     :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 130, 112, 130, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 83, 106, 83, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 168, 112, 172, false);
                    NewField42.Name = "NewField42";
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.TextFont.Size = 9;
                    NewField42.TextFont.Bold = true;
                    NewField42.Value = @"MUAYENE VE TEDAVİ SONUCU                    :";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 172, 112, 172, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 184, 57, 188, false);
                    NewField44.Name = "NewField44";
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.TextFont.Size = 9;
                    NewField44.TextFont.Bold = true;
                    NewField44.Value = @"Hastahane Protokol No";

                    KarantinaPNLable = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 189, 57, 193, false);
                    KarantinaPNLable.Name = "KarantinaPNLable";
                    KarantinaPNLable.TextFont.Name = "Arial Narrow";
                    KarantinaPNLable.TextFont.Size = 9;
                    KarantinaPNLable.TextFont.Bold = true;
                    KarantinaPNLable.Value = @"Karantina Protokol No";

                    YatısTarihiLable = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 174, 57, 178, false);
                    YatısTarihiLable.Name = "YatısTarihiLable";
                    YatısTarihiLable.TextFont.Name = "Arial Narrow";
                    YatısTarihiLable.TextFont.Size = 9;
                    YatısTarihiLable.TextFont.Bold = true;
                    YatısTarihiLable.Value = @"Yatış Tarihi";

                    CıkısTarihiLable = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 179, 57, 183, false);
                    CıkısTarihiLable.Name = "CıkısTarihiLable";
                    CıkısTarihiLable.TextFont.Name = "Arial Narrow";
                    CıkısTarihiLable.TextFont.Size = 9;
                    CıkısTarihiLable.TextFont.Bold = true;
                    CıkısTarihiLable.Value = @"Önerilen Çıkış Tarihi";

                    HPROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 184, 119, 188, false);
                    HPROTOKOL.Name = "HPROTOKOL";
                    HPROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOL.ObjectDefName = "TreatmentDischarge";
                    HPROTOKOL.DataMember = "EPISODE.HOSPITALPROTOCOLNO";
                    HPROTOKOL.TextFont.Name = "Arial Narrow";
                    HPROTOKOL.TextFont.Size = 9;
                    HPROTOKOL.Value = @"{@TTOBJECTID@}";

                    KPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 189, 119, 193, false);
                    KPROTOKOLNO.Name = "KPROTOKOLNO";
                    KPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KPROTOKOLNO.TextFont.Name = "Arial Narrow";
                    KPROTOKOLNO.TextFont.Size = 9;
                    KPROTOKOLNO.Value = @"";

                    YATISTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 174, 119, 178, false);
                    YATISTARIH.Name = "YATISTARIH";
                    YATISTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIH.TextFormat = @"Short Date";
                    YATISTARIH.TextFont.Name = "Arial Narrow";
                    YATISTARIH.TextFont.Size = 9;
                    YATISTARIH.Value = @"{#HOSPITALINPATIENTDATE#}";

                    CIKISTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 179, 119, 183, false);
                    CIKISTARIH.Name = "CIKISTARIH";
                    CIKISTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKISTARIH.TextFormat = @"Short Date";
                    CIKISTARIH.TextFont.Name = "Arial Narrow";
                    CIKISTARIH.TextFont.Size = 9;
                    CIKISTARIH.Value = @"{#DISCHARGEDATE#}";

                    YAZIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 54, 254, 58, false);
                    YAZIKODU.Name = "YAZIKODU";
                    YAZIKODU.Visible = EvetHayirEnum.ehHayir;
                    YAZIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZIKODU.TextFont.Name = "Arial";
                    YAZIKODU.Value = @"";

                    SAGNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 12, 254, 16, false);
                    SAGNO.Name = "SAGNO";
                    SAGNO.Visible = EvetHayirEnum.ehHayir;
                    SAGNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAGNO.TextFont.Name = "Arial";
                    SAGNO.Value = @"";

                    NewField55 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 184, 69, 188, false);
                    NewField55.Name = "NewField55";
                    NewField55.TextFont.Name = "Arial Narrow";
                    NewField55.TextFont.Size = 9;
                    NewField55.Value = @":";

                    KarantinaPNLableNokta = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 189, 69, 193, false);
                    KarantinaPNLableNokta.Name = "KarantinaPNLableNokta";
                    KarantinaPNLableNokta.TextFont.Name = "Arial Narrow";
                    KarantinaPNLableNokta.TextFont.Size = 9;
                    KarantinaPNLableNokta.Value = @":";

                    NewField57 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 179, 69, 183, false);
                    NewField57.Name = "NewField57";
                    NewField57.TextFont.Name = "Arial Narrow";
                    NewField57.TextFont.Size = 9;
                    NewField57.Value = @":";

                    NewField58 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 174, 69, 178, false);
                    NewField58.Name = "NewField58";
                    NewField58.TextFont.Name = "Arial Narrow";
                    NewField58.TextFont.Size = 9;
                    NewField58.Value = @":";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 169, 253, 173, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial";
                    ACTIONID.Value = @"";

                    NewField60 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 84, 28, 88, false);
                    NewField60.Name = "NewField60";
                    NewField60.TextFont.Name = "Arial Narrow";
                    NewField60.TextFont.Size = 9;
                    NewField60.Value = @"Gereği:";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 88, 28, 88, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 147, 201, 151, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 88, 251, 92, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.Name = "Arial";
                    HASTANO.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 137, 201, 141, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{#NAME#} {#SURNAME#}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 20, 251, 25, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"%y";
                    ACTIONDATE2.TextFont.Name = "Arial";
                    ACTIONDATE2.Value = @"{#REQUESTDATE#}";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 69, 201, 87, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial Narrow";
                    ONAY.TextFont.Size = 9;
                    ONAY.Value = @"";

                    EXTRACOPIES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 119, 266, 123, false);
                    EXTRACOPIES.Name = "EXTRACOPIES";
                    EXTRACOPIES.Visible = EvetHayirEnum.ehHayir;
                    EXTRACOPIES.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTRACOPIES.MultiLine = EvetHayirEnum.ehEvet;
                    EXTRACOPIES.TextFont.Name = "Arial";
                    EXTRACOPIES.Value = @"";

                    DAGITIM15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 141, 253, 145, false);
                    DAGITIM15.Name = "DAGITIM15";
                    DAGITIM15.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM15.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM15.TextFont.Name = "Arial";
                    DAGITIM15.Value = @"";

                    DAGITIM16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 145, 253, 149, false);
                    DAGITIM16.Name = "DAGITIM16";
                    DAGITIM16.Visible = EvetHayirEnum.ehHayir;
                    DAGITIM16.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIM16.TextFont.Name = "Arial";
                    DAGITIM16.Value = @"";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 10, 202, 19, false);
                    FOTO.Name = "FOTO";
                    FOTO.Visible = EvetHayirEnum.ehHayir;
                    FOTO.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTO.Value = @"";

                    LBLFOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 12, 191, 16, false);
                    LBLFOTO.Name = "LBLFOTO";
                    LBLFOTO.Visible = EvetHayirEnum.ehHayir;
                    LBLFOTO.Value = @"FOTOĞRAF";

                    KimlikNolabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 132, 57, 136, false);
                    KimlikNolabel.Name = "KimlikNolabel";
                    KimlikNolabel.TextFont.Name = "Arial Narrow";
                    KimlikNolabel.TextFont.Size = 9;
                    KimlikNolabel.TextFont.Bold = true;
                    KimlikNolabel.Value = @"T.C. Kimlik No";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 132, 69, 136, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.Size = 9;
                    NewField142.Value = @":";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 132, 112, 136, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.TextFont.Name = "Arial Narrow";
                    KIMLIKNO.TextFont.Size = 9;
                    KIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 8, 239, 12, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.Value = @"{#EPISODE#}";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 38, 12, false);
                    NewField102.Name = "NewField102";
                    NewField102.TextFont.Name = "Arial Narrow";
                    NewField102.TextFont.Size = 11;
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.Underline = true;
                    NewField102.Value = @"TASNİF DIŞI";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 8, 168, 31, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    Cinsiyeti = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 132, 142, 136, false);
                    Cinsiyeti.Name = "Cinsiyeti";
                    Cinsiyeti.TextFont.Name = "Arial Narrow";
                    Cinsiyeti.TextFont.Size = 9;
                    Cinsiyeti.TextFont.Bold = true;
                    Cinsiyeti.Value = @"Cinsiyeti";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 132, 170, 136, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.Size = 9;
                    NewField1241.Value = @":";

                    CINSIYETI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 132, 201, 136, false);
                    CINSIYETI.Name = "CINSIYETI";
                    CINSIYETI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYETI.TextFont.Name = "Arial Narrow";
                    CINSIYETI.TextFont.Size = 9;
                    CINSIYETI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TreatmentDischarge.TreatmentDischargeReport_Class dataset_TreatmentDischargeReportNQL = ParentGroup.rsGroup.GetCurrentRecord<TreatmentDischarge.TreatmentDischargeReport_Class>(0);
                    BIRIMADI.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Fromres) : "");
                    YAZI.CalcValue = @"Aşağıda açık kimliği yazılı personelin " + MyParentReport.Header.BIRIMADI.CalcValue + @"'ne yatırılarak yapılan muayene ve tedavi sonucu bildirilmiştir.
Arz/Rica ederim.";
                    YAZIAYAKTAN.CalcValue = @"Aşağıda açık kimliği yazılı personelin " + MyParentReport.Header.BIRIMADI.CalcValue + @"'nde yapılan muayene ve tedavi sonucu bildirilmiştir.
Arz/Rica ederim.";
                    ACTIONDATE.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.RequestDate) : "");
                    BIRIMPRTNO.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.ProtocolNo) : "");
                    RUTBE.CalcValue = @"";
                    SINIF.CalcValue = @"";
                    DTARIH.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.BirthDate) : "");
                    DYER.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Cityname) : "");
                    RAPORNO.CalcValue = @"";
                    KONU.CalcValue = @"KONU : Hasta Tedavi Kararı";
                    DAGIT.CalcValue = DAGIT.Value;
                    DAGITIM2.CalcValue = @"";
                    DAGITIM11.CalcValue = @"";
                    DAGITIM12.CalcValue = @"";
                    DAGITIM13.CalcValue = @"";
                    DAGITIM14.CalcValue = @"";
                    DAGITIM1.CalcValue = MyParentReport.Header.DAGITIM11.CalcValue + @"
" + MyParentReport.Header.DAGITIM12.CalcValue + @"
" + MyParentReport.Header.DAGITIM13.CalcValue + @"
" + MyParentReport.Header.DAGITIM14.CalcValue;
                    SAGNO.CalcValue = @"";
                    ACTIONDATE2.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.RequestDate) : "");
                    ACTIONID.CalcValue = @"";
                    SAG.CalcValue = @"SAĞ:" + MyParentReport.Header.SAGNO.CalcValue + @"-" + MyParentReport.Header.BIRIMPRTNO.CalcValue + @"-" + MyParentReport.Header.ACTIONDATE2.FormattedValue + @" / " + MyParentReport.Header.BIRIMADI.CalcValue + @"-" + MyParentReport.Header.ACTIONID.CalcValue;
                    DYERIDTARIHI.CalcValue = MyParentReport.Header.DYER.CalcValue + @" / " + MyParentReport.Header.DTARIH.FormattedValue;
                    SINRUTBE.CalcValue = SINRUTBE.Value;
                    NewField19.CalcValue = NewField19.Value;
                    BABAADI.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.FatherName) : "");
                    AD.CalcValue = AD.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    BAB.CalcValue = BAB.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField270.CalcValue = NewField270.Value;
                    NewField28.CalcValue = NewField28.Value;
                    BIRLIGI.CalcValue = @"";
                    NewField30.CalcValue = NewField30.Value;
                    BIR.CalcValue = BIR.Value;
                    KIMLIK.CalcValue = KIMLIK.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField44.CalcValue = NewField44.Value;
                    KarantinaPNLable.CalcValue = KarantinaPNLable.Value;
                    YatısTarihiLable.CalcValue = YatısTarihiLable.Value;
                    CıkısTarihiLable.CalcValue = CıkısTarihiLable.Value;
                    HPROTOKOL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HPROTOKOL.PostFieldValueCalculation();
                    KPROTOKOLNO.CalcValue = @"";
                    YATISTARIH.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.HospitalInPatientDate) : "");
                    CIKISTARIH.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.DischargeDate) : "");
                    YAZIKODU.CalcValue = @"";
                    NewField55.CalcValue = NewField55.Value;
                    KarantinaPNLableNokta.CalcValue = KarantinaPNLableNokta.Value;
                    NewField57.CalcValue = NewField57.Value;
                    NewField58.CalcValue = NewField58.Value;
                    NewField60.CalcValue = NewField60.Value;
                    SINRUT.CalcValue = @"";
                    HASTANO.CalcValue = @"";
                    ADSOYAD.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Name) : "") + @" " + (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Surname) : "");
                    ONAY.CalcValue = @"";
                    EXTRACOPIES.CalcValue = @"";
                    DAGITIM15.CalcValue = @"";
                    DAGITIM16.CalcValue = @"";
                    FOTO.CalcValue = FOTO.Value;
                    LBLFOTO.CalcValue = LBLFOTO.Value;
                    KimlikNolabel.CalcValue = KimlikNolabel.Value;
                    NewField142.CalcValue = NewField142.Value;
                    KIMLIKNO.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.UniqueRefNo) : "");
                    EPISODE.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Episode) : "");
                    NewField102.CalcValue = NewField102.Value;
                    Cinsiyeti.CalcValue = Cinsiyeti.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    CINSIYETI.CalcValue = @"";
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { BIRIMADI,YAZI,YAZIAYAKTAN,ACTIONDATE,BIRIMPRTNO,RUTBE,SINIF,DTARIH,DYER,RAPORNO,KONU,DAGIT,DAGITIM2,DAGITIM11,DAGITIM12,DAGITIM13,DAGITIM14,DAGITIM1,SAGNO,ACTIONDATE2,ACTIONID,SAG,DYERIDTARIHI,SINRUTBE,NewField19,BABAADI,AD,NewField23,NewField24,BAB,SINIFRUTBE,NewField270,NewField28,BIRLIGI,NewField30,BIR,KIMLIK,NewField42,NewField44,KarantinaPNLable,YatısTarihiLable,CıkısTarihiLable,HPROTOKOL,KPROTOKOLNO,YATISTARIH,CIKISTARIH,YAZIKODU,NewField55,KarantinaPNLableNokta,NewField57,NewField58,NewField60,SINRUT,HASTANO,ADSOYAD,ONAY,EXTRACOPIES,DAGITIM15,DAGITIM16,FOTO,LBLFOTO,KimlikNolabel,NewField142,KIMLIKNO,EPISODE,NewField102,Cinsiyeti,NewField1241,CINSIYETI,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    //                                                                                                                                                                                                                                    
//                    TreatmentDischargeReport parentReport = (TreatmentDischargeReport)ParentReport;
//                    TTObjectContext context = parentReport.ReportObjectContext;
//                    string sObjectID = ((TreatmentDischargeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//                    TreatmentDischarge treatmentDischarge = (TreatmentDischarge)context.GetObject(new Guid(sObjectID), "TreatmentDischarge");
//                    Episode episode = treatmentDischarge.Episode;
//                    if (episode == null)
//                        throw new Exception("Hastanın vakasına ulaşılamadı .Lütfen Bilgi işleme Başvurunuz");
//
//                    if (treatmentDischarge.Episode.PatientStatus == PatientStatusEnum.Inpatient)
//                    {
//                        this.YAZI.Visible = EvetHayirEnum.ehEvet;
//                        this.YAZIAYAKTAN.Visible = EvetHayirEnum.ehHayir;
//                    }
//                    else
//                    {
//                        this.YAZI.Visible = EvetHayirEnum.ehHayir;
//
//                        this.YAZIAYAKTAN.Visible = EvetHayirEnum.ehEvet;
//                    }
//
//                    //Sevkli sivilde sınıf, rütbe, sicilno boşaltılır..
//                    /*if (treatmentDischarge.Episode.PatientGroup.Equals(PatientGroupEnum.CivilianConsignment))
//                    {
//                        this.BIRLIGI.CalcValue = "";
//                    }*/
//
////                    this.SINRUT.CalcValue = episode.MilitaryClass != null ? episode.MilitaryClass.Name + " " : null;
////                    this.SINRUT.CalcValue += episode.Rank != null ? episode.Rank.Name : null;
//               
//                    this.ONAY.CalcValue = "ONAYLI\n\r" + TTObjectClasses.ResHospital.ApprovalSignatureBlock;
//
//                   /* if (episode.ReasonForAdmission.Type == ReasonForAdmissionTypeEnum.PeriodicExamination)
//                        this.SAGNO.CalcValue = "9126";
//                    else
//                        this.SAGNO.CalcValue = this.YAZIKODU.CalcValue;
//*/
//                    if (episode.PatientStatus.Equals(PatientStatusEnum.Outpatient))
//                    {
//                        YatısTarihiLable.CalcValue = "Giriş Tarihi";
//                        YATISTARIH.CalcValue = episode.OpeningDate.ToString();
//                        CIKISTARIH.CalcValue = episode.ClosingDate.ToString();
//                        KarantinaPNLable.Visible = EvetHayirEnum.ehHayir; ;
//                        KarantinaPNLableNokta.Visible = EvetHayirEnum.ehHayir; ;
//                        KPROTOKOLNO.Visible = EvetHayirEnum.ehHayir; ;
//                    }
//                    else
//                    {
//                        if(episode.QuarantineProtocolNo.Value == null)
//                        {
//                            foreach(InpatientAdmission ia in episode.InpatientAdmissions)
//                            {
//                                if(ia.CurrentStateDef.Status != StateStatusEnum.Cancelled && ia.QuarantineProtocolNo.Value.HasValue)
//                                {
//                                    this.KPROTOKOLNO.CalcValue = ia.QuarantineProtocolNo.Value.ToString();
//                                }
//                            }
//                        }
//                        else
//                            this.KPROTOKOLNO.CalcValue = episode.QuarantineProtocolNo.Value.ToString();
//                    }
//                    
////                    if(episode.WarVetera == true)
////                        this.WARVETERA.CalcValue ="(Muharip Gazi)";
////                    if(episode.DisabledWarVetera == true)
////                       this.WARVETERA.CalcValue ="(Malul Gazi)";
//
//
//                    this.DAGITIM2.CalcValue = parentReport.dagitim;
//                    this.SAYMANLIK.CalcValue = parentReport.Saymanlik;
//                    DagitimBilgi dagitimBilgi = parentReport.dagitimList[parentReport.Counter_Group.GroupCounter-1];
//                    this.DAGITIM1.CalcValue = dagitimBilgi.Baslik;
//                    if (dagitimBilgi.Yazi != null)
//                        this.YAZI.CalcValue = dagitimBilgi.Yazi;
//                    this.SAYMANLIK.Visible = dagitimBilgi.IsSaymanlikVisible;
//                    
//                    if(treatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.OkWithoutApprove)
//                        this.ONAY.Visible = EvetHayirEnum.ehHayir;
//                    if(episode.Patient.Sex == SexEnum.Female)
//                        this.CINSIYETI.CalcValue = "KADIN";
//                    else if(episode.Patient.Sex == SexEnum.Male)
//                        this.CINSIYETI.CalcValue = "ERKEK";
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField SIVILNOT;
                public TTReportField NewField1181; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SIVILNOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 206, 5, false);
                    SIVILNOT.Name = "SIVILNOT";
                    SIVILNOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIVILNOT.MultiLine = EvetHayirEnum.ehEvet;
                    SIVILNOT.NoClip = EvetHayirEnum.ehEvet;
                    SIVILNOT.WordBreak = EvetHayirEnum.ehEvet;
                    SIVILNOT.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIVILNOT.TextFont.Name = "Arial Narrow";
                    SIVILNOT.TextFont.Size = 9;
                    SIVILNOT.Value = @"";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 43, 14, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.Size = 11;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.Underline = true;
                    NewField1181.Value = @"TASNİF DIŞI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TreatmentDischarge.TreatmentDischargeReport_Class dataset_TreatmentDischargeReportNQL = ParentGroup.rsGroup.GetCurrentRecord<TreatmentDischarge.TreatmentDischargeReport_Class>(0);
                    SIVILNOT.CalcValue = @"";
                    NewField1181.CalcValue = NewField1181.Value;
                    return new TTReportObject[] { SIVILNOT,NewField1181};
                }
            }

        }

        public HeaderGroup Header;

        public partial class ReportGroup : TTReportGroup
        {
            public TreatmentDischargeReport MyParentReport
            {
                get { return (TreatmentDischargeReport)ParentReport; }
            }

            new public ReportGroupHeader Header()
            {
                return (ReportGroupHeader)_header;
            }

            new public ReportGroupFooter Footer()
            {
                return (ReportGroupFooter)_footer;
            }

            public TTReportField LBL11311 { get {return Header().LBL11311;} }
            public TTReportRTF Report { get {return Header().Report;} }
            public TTReportField NOT1 { get {return Footer().NOT1;} }
            public ReportGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ReportGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ReportGroupHeader(this);
                _footer = new ReportGroupFooter(this);

            }

            public partial class ReportGroupHeader : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField LBL11311;
                public TTReportRTF Report; 
                public ReportGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 18;
                    RepeatCount = 0;
                    
                    LBL11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 20, 7, false);
                    LBL11311.Name = "LBL11311";
                    LBL11311.TextFont.Name = "Arial Narrow";
                    LBL11311.TextFont.Size = 9;
                    LBL11311.TextFont.Bold = true;
                    LBL11311.Value = @"Karar ";

                    Report = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 20, 1, 198, 18, false);
                    Report.Name = "Report";
                    Report.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL11311.CalcValue = LBL11311.Value;
                    Report.CalcValue = Report.Value;
                    return new TTReportObject[] { LBL11311,Report};
                }
                public override void RunPreScript()
                {
#region REPORT HEADER_PreScript
                    //                    TreatmentDischargeReport parentReport = (TreatmentDischargeReport)ParentReport;
//                    TTObjectContext context = parentReport.ReportObjectContext;
//                    string sObjectID = ((TreatmentDischargeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//                    TreatmentDischarge treatmentDischarge = (TreatmentDischarge)context.GetObject(new Guid(sObjectID), "TreatmentDischarge");
//                    this.Report.Value = treatmentDischarge.Conclusion.ToString();
#endregion REPORT HEADER_PreScript
                }
            }
            public partial class ReportGroupFooter : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField NOT1; 
                public ReportGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 207, 4, false);
                    NOT1.Name = "NOT1";
                    NOT1.Visible = EvetHayirEnum.ehHayir;
                    NOT1.MultiLine = EvetHayirEnum.ehEvet;
                    NOT1.NoClip = EvetHayirEnum.ehEvet;
                    NOT1.WordBreak = EvetHayirEnum.ehEvet;
                    NOT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT1.TextFont.Size = 8;
                    NOT1.Value = @"NOT: 1- Bu vesika ile kesin işlem yapılmaz. Kesin işlem ancak rapor aslı üzerine yapılır. Fakat istirahat ve hava değişimlerine gidebilir.
2- XXXXXX Mensuplarının Sağlık Muayeneleri Yönergesi (M.S.B. 160-1)'nin 30. maddesi gereğince sonunda muayene kaydı ile hava değişimi veya istirahat raporu alanlar hava değişimi ve istirahatınınbitim tarihinden 15 gün evvel bulunduğu yerdeki birliğine, Garnizon XXXXXXna veya XXXXXXlik Şubesine müracaatla muyenesini istemesi lazımdır.
3- XXXXXXe alındıktan sonra XXXXXX XXXXXXleri sağlık kurallarından (XXXXXXliğe elverişli değildir) kararı alan erler raporlarının onaylanmasını beklemek üzere bu XXXXXXler tarafından yerli kayotlı bulunduğu XXXXXXlik şubesi emrine gönderilir. Ayrıca durum ilgililerin birliğine duyrulur. Terhis işlemleri, raporları ilgili makamlarca onaylanıp XXXXXXlik şubesine geldikten sonra yapılır(XXXXXX. Sağlık Yeteneği Yönetmeliğinin 15 nci maddesi).
4- XXXXXXnde görev yapamaz, kesin işlem kararlı rapor alan personel rapor tarihinden itibaren emeklilik işlemi kesinleşinceye kadar izinli sayılır. Görev verilemez (XXXXXX. Mensuplarının Sağlık Muayeneleri Yönergesi M.S.B. 160-1 Madde 18/d).
5- Sınıf değişikliği kararı alınanlara raporlar üst makamlardan onaylanıp sınıf değişikliği işlemleri tamamlanarak kesinleşinceye kadar eski sınıfında görev verilmez, ilgili blunduğu birliğin karargah hizmetlerinde geçici olarak görevlendirilir.(XXXXXX. Mensuplarının Sağlık Muayeneleri Yönergesi M.S.B. 160-1 Madde 26).";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NOT1.CalcValue = NOT1.Value;
                    return new TTReportObject[] { NOT1};
                }
            }

        }

        public ReportGroup Report;

        public partial class KararGroup : TTReportGroup
        {
            public TreatmentDischargeReport MyParentReport
            {
                get { return (TreatmentDischargeReport)ParentReport; }
            }

            new public KararGroupHeader Header()
            {
                return (KararGroupHeader)_header;
            }

            new public KararGroupFooter Footer()
            {
                return (KararGroupFooter)_footer;
            }

            public TTReportField LableDIAGNOSIS11 { get {return Header().LableDIAGNOSIS11;} }
            public TTReportField ONAYNOT1 { get {return Footer().ONAYNOT1;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
            public KararGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KararGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KararGroupHeader(this);
                _footer = new KararGroupFooter(this);

            }

            public partial class KararGroupHeader : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField LableDIAGNOSIS11; 
                public KararGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LableDIAGNOSIS11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 19, 6, false);
                    LableDIAGNOSIS11.Name = "LableDIAGNOSIS11";
                    LableDIAGNOSIS11.ForeColor = System.Drawing.Color.White;
                    LableDIAGNOSIS11.DrawStyle = DrawStyleConstants.vbSolid;
                    LableDIAGNOSIS11.TextFont.Name = "Arial Narrow";
                    LableDIAGNOSIS11.TextFont.Size = 9;
                    LableDIAGNOSIS11.TextFont.Bold = true;
                    LableDIAGNOSIS11.Value = @"Tanılar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LableDIAGNOSIS11.CalcValue = LableDIAGNOSIS11.Value;
                    return new TTReportObject[] { LableDIAGNOSIS11};
                }
            }
            public partial class KararGroupFooter : TTReportSection
            {
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField ONAYNOT1;
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField UZMANLIKDAL;
                public TTReportField DIPSICLABEL;
                public TTReportField SINRUT;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField UZ;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO;
                public TTReportField ISTEKDR; 
                public KararGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    RepeatCount = 0;
                    
                    ONAYNOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 206, 29, false);
                    ONAYNOT1.Name = "ONAYNOT1";
                    ONAYNOT1.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYNOT1.NoClip = EvetHayirEnum.ehEvet;
                    ONAYNOT1.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYNOT1.TextFont.Name = "Arial Narrow";
                    ONAYNOT1.TextFont.Size = 12;
                    ONAYNOT1.TextFont.Bold = true;
                    ONAYNOT1.Value = @"";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 11, 200, 15, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.Visible = EvetHayirEnum.ehHayir;
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 3, 200, 7, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.Visible = EvetHayirEnum.ehHayir;
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#Header.PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 3, 89, 7, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#Header.DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 11, 150, 15, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.Visible = EvetHayirEnum.ehHayir;
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 7, 200, 11, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.Visible = EvetHayirEnum.ehHayir;
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 8, 61, 12, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#Header.DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 6, 89, 11, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#Header.DOCMILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 15, 200, 19, false);
                    UZ.Name = "UZ";
                    UZ.Visible = EvetHayirEnum.ehHayir;
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 3, 62, 8, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#Header.DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 12, 118, 16, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#Header.DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 4, 118, 8, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 12, 61, 16, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 11, 89, 16, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#Header.DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 8, 118, 12, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#Header.DOCEMPLOYMENTRECORDID#}";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 3, 199, 21, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Name = "Arial Narrow";
                    ISTEKDR.TextFont.CharSet = 1;
                    ISTEKDR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TreatmentDischarge.TreatmentDischargeReport_Class dataset_TreatmentDischargeReportNQL = MyParentReport.Header.rsGroup.GetCurrentRecord<TreatmentDischarge.TreatmentDischargeReport_Class>(0);
                    ONAYNOT1.CalcValue = ONAYNOT1.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.Karar.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_TreatmentDischargeReportNQL != null ? Globals.ToStringCore(dataset_TreatmentDischargeReportNQL.Docemploymentrecordid) : "");
                    ISTEKDR.CalcValue = @"";
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { ONAYNOT1,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,ISTEKDR,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region KARAR FOOTER_Script
                    //                    TreatmentDischargeReport parentReport = (TreatmentDischargeReport)ParentReport;
//                    TTObjectContext context = parentReport.ReportObjectContext;
//                    string objectID = ((TreatmentDischargeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//                    TreatmentDischarge treatmentDischarge = (TreatmentDischarge)context.GetObject(new Guid(objectID), "TreatmentDischarge");
//
//                    if (treatmentDischarge.ProcedureDoctor != null)
//                        this.ISTEKDR.CalcValue = treatmentDischarge.ProcedureDoctor.SignatureBlockWDiplomaInfo;
#endregion KARAR FOOTER_Script
                }
            }

        }

        public KararGroup Karar;

        public partial class MAINGroup : TTReportGroup
        {
            public TreatmentDischargeReport MyParentReport
            {
                get { return (TreatmentDischargeReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DIAGNOSEDATE { get {return Body().DIAGNOSEDATE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DIAGNOSISTYPE1 { get {return Body().DIAGNOSISTYPE1;} }
            public TTReportField DIAGNOSISDEF { get {return Body().DIAGNOSISDEF;} }
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
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnosisByEpisode_Class>("GetDiagnosisByEpisode", DiagnosisGrid.GetDiagnosisByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.Header.EPISODE.CalcValue)));
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
                public TreatmentDischargeReport MyParentReport
                {
                    get { return (TreatmentDischargeReport)ParentReport; }
                }
                
                public TTReportField DIAGNOSEDATE;
                public TTReportField NAME;
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DIAGNOSISTYPE1;
                public TTReportField DIAGNOSISDEF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 49, 5, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.ForeColor = System.Drawing.Color.White;
                    DIAGNOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.TextFormat = @"Short Date";
                    DIAGNOSEDATE.TextFont.Name = "Arial Narrow";
                    DIAGNOSEDATE.TextFont.Size = 9;
                    DIAGNOSEDATE.Value = @"{#DIAGNOSEDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 0, 121, 5, false);
                    NAME.Name = "NAME";
                    NAME.ForeColor = System.Drawing.Color.White;
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#NAME#}";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 0, 61, 5, false);
                    CODE.Name = "CODE";
                    CODE.ForeColor = System.Drawing.Color.White;
                    CODE.DrawStyle = DrawStyleConstants.vbSolid;
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.Size = 9;
                    CODE.Value = @"{#CODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 0, 161, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.ForeColor = System.Drawing.Color.White;
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.Value = @"{#FREEDIAGNOSIS#}";

                    DIAGNOSISTYPE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 29, 5, false);
                    DIAGNOSISTYPE1.Name = "DIAGNOSISTYPE1";
                    DIAGNOSISTYPE1.ForeColor = System.Drawing.Color.White;
                    DIAGNOSISTYPE1.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISTYPE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISTYPE1.ObjectDefName = "DiagnosisTypeEnum";
                    DIAGNOSISTYPE1.DataMember = "DISPLAYTEXT";
                    DIAGNOSISTYPE1.TextFont.Name = "Arial Narrow";
                    DIAGNOSISTYPE1.TextFont.Size = 9;
                    DIAGNOSISTYPE1.Value = @"{#DIAGNOSISTYPE#}";

                    DIAGNOSISDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 206, 5, false);
                    DIAGNOSISDEF.Name = "DIAGNOSISDEF";
                    DIAGNOSISDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISDEF.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISDEF.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSISDEF.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISDEF.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISDEF.TextFont.Name = "Arial Narrow";
                    DIAGNOSISDEF.TextFont.CharSet = 1;
                    DIAGNOSISDEF.Value = @"{#DIAGNOSISDEFINITION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnosisByEpisode_Class dataset_GetDiagnosisByEpisode = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnosisByEpisode_Class>(0);
                    DIAGNOSEDATE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Diagnosedate) : "");
                    NAME.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Name) : "");
                    CODE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Code) : "");
                    DESCRIPTION.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Freediagnosis) : "");
                    DIAGNOSISTYPE1.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.DiagnosisType) : "");
                    DIAGNOSISTYPE1.PostFieldValueCalculation();
                    DIAGNOSISDEF.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.DiagnosisDefinition) : "");
                    return new TTReportObject[] { DIAGNOSEDATE,NAME,CODE,DESCRIPTION,DIAGNOSISTYPE1,DIAGNOSISDEF};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TreatmentDischargeReport()
        {
            Counter_Group = new Counter_GroupGroup(this,"Counter_Group");
            Header = new HeaderGroup(Counter_Group,"Header");
            Report = new ReportGroup(Header,"Report");
            Karar = new KararGroup(Report,"Karar");
            MAIN = new MAINGroup(Karar,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Tedavi Kararı", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TREATMENTDISCHARGEREPORT";
            Caption = "Tedavi Kararı Raporu";
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


        protected override void RunPreScript()
        {
#region TREATMENTDISCHARGEREPORT_PreScript
            //            TTObjectContext context = this.ReportObjectContext;
//            string sObjectID = this.RuntimeParameters.TTOBJECTID.ToString();
//            TreatmentDischarge treatmentDischarge = (TreatmentDischarge)context.GetObject(new Guid(sObjectID), "TreatmentDischarge");
//            
//            Episode episode = treatmentDischarge.Episode;
//            if (episode == null)
//                throw new Exception("Hastanın vakasına ulaşılamadı .Lütfen Bilgi işleme Başvurunuz");
//
//            int Sayac = 0;
//            NumberOfCopiesGrid numberOfCopies = treatmentDischarge.GetNumberOfCopisGridFromDefinition();
//            if (numberOfCopies != null)
//            {
//                int i = 1;
//                string s = "";
//                if (!(numberOfCopies.NotPrintOthersIfHospExists == true && numberOfCopies.ToHospitalSendingTo > 0 && treatmentDischarge.HospitalSendingTo != null))
//                {
////                    if (numberOfCopies.ToMilitaryOffice > 0 && episode.MilitaryOffice != null)
////                    {
////                        s = s + i.ToString() + "." + episode.MilitaryOffice.Name.ToString() + "\n";
////                        i++;
////                    }
////                    if (numberOfCopies.ToMilitaryUnit > 0 && episode.MilitaryUnit != null)
////                    {
////                        s = s + i.ToString() + "." + episode.MilitaryUnit.Name.ToString() + "\n";
////                        i++;
////                    }
////                    if (numberOfCopies.ToExaminationSenderUnit > 0 && episode.SenderChair != null)
////                    {
////                        bool isequal = false;
////                        if (episode.MilitaryUnit != null)
////                        {
////                            if (episode.MilitaryUnit.ObjectID == episode.SenderChair.ObjectID)
////                                isequal = true;
////                        }
////                        if (!(numberOfCopies.ToMilitaryUnit > 0 && numberOfCopies.NotPrintIfMilUnitEqualSendCh == true && isequal))
////                        {
////                            s = s + i.ToString() + "." + episode.SenderChair.Name.ToString() + "\n";
////                            i++;
////                        }
////                    }
//                }
//                if (numberOfCopies.ToHospitalSendingTo > 0 && treatmentDischarge.HospitalSendingTo != null)
//                {
//                    s = s + i.ToString() + "." + treatmentDischarge.HospitalSendingTo.Name.ToString() + "\n";
//                    i++;
//                }
//                if (numberOfCopies.ToSupplierUnit > 0 && treatmentDischarge.SentToSupplierUnit == true)
//                {
//                    s = s + i.ToString() + ".LEVAZIM ŞUBE MÜDÜRLÜĞÜ" + "\n";
//                    i++;
//                }
//
//                this.dagitim = s;
////                if (!(numberOfCopies.NotPrintOthersIfHospExists == true && numberOfCopies.ToHospitalSendingTo > 0 && treatmentDischarge.HospitalSendingTo != null))
////                {
////                    if (numberOfCopies.ToMilitaryOffice > 0 && episode.MilitaryOffice != null)
////                    {
////                        int cnt = Convert.ToInt16(numberOfCopies.ToMilitaryOffice);
////                        Sayac += cnt;
////                        for (int j = 0; j < cnt; j++)
////                            this.dagitimList.Add(new DagitimBilgi(episode.MilitaryOffice.Name.ToString(), EvetHayirEnum.ehHayir, null));
////                    }
////
////                    if (numberOfCopies.ToMilitaryUnit > 0 && episode.MilitaryUnit != null)
////                    {
////                        int cnt = Convert.ToInt16(numberOfCopies.ToMilitaryUnit);
////                        Sayac += cnt;
////                        for (int j = 0; j < cnt; j++)
////                            this.dagitimList.Add(new DagitimBilgi(episode.MilitaryUnit.Name.ToString(), EvetHayirEnum.ehHayir, null));
////                    }
////                    if (numberOfCopies.ToExaminationSenderUnit > 0 && episode.SenderChair != null)
////                    {
////                        bool isequal = false;
////                        if (episode.MilitaryUnit != null)
////                        {
////                            if (episode.MilitaryUnit.ObjectID == episode.SenderChair.ObjectID)
////                                isequal = true;
////                        }
////                        if (!(numberOfCopies.ToMilitaryUnit > 0 && numberOfCopies.NotPrintIfMilUnitEqualSendCh == true && isequal))
////                        {
////                            int cnt = Convert.ToInt16(numberOfCopies.ToExaminationSenderUnit);
////                            Sayac += cnt;
////                            for (int j = 0; j < cnt; j++)
////                                this.dagitimList.Add(new DagitimBilgi(episode.SenderChair.Name.ToString(), EvetHayirEnum.ehHayir, null));
////                        }
////                    }
////                }
//
//                Accountancy acc = null;
////                if (episode.ForcesCommand != null)
////                    acc = AccountancyMatchingDefinition.GetAccountancy(context, episode.ForcesCommand, treatmentDischarge.HospitalSendingTo);
//                if (acc != null)
//                    this.Saymanlik = acc.Name.ToString();
//
//                if (numberOfCopies.ToAccountingOffice > 0 && treatmentDischarge.HospitalSendingTo != null)
//                {
//                    int cnt = Convert.ToInt16(numberOfCopies.ToAccountingOffice);
//                    Sayac += cnt;
//                    for (int j = 0; j < cnt; j++)
//                        this.dagitimList.Add(new DagitimBilgi(treatmentDischarge.HospitalSendingTo.Name.ToString(), EvetHayirEnum.ehEvet, "     Aşağıda açık kimliği yazılı personel , ileri tetkik ve tedavisinin yapılabilmesi için XXXXXXnize sevk edilmiştir. Hastanın muayene ve tedavisinin yapılarak sonucun birliğine bildirilmesini arz/rica ederim."));
//                }
//
//                if (numberOfCopies.ToHospitalSendingTo > 0 && treatmentDischarge.HospitalSendingTo != null)
//                {
//                    int cnt = Convert.ToInt16(numberOfCopies.ToHospitalSendingTo);
//                    Sayac += cnt;
//                    for (int j = 0; j < cnt; j++)
//                        this.dagitimList.Add(new DagitimBilgi(treatmentDischarge.HospitalSendingTo.Name.ToString(), EvetHayirEnum.ehEvet, "     Aşağıda açık kimliği yazılı personel , ileri tetkik ve tedavisinin yapılabilmesi için XXXXXXnize sevk edilmiştir. Hastanın muayene ve tedavisinin yapılarak sonucun birliğine bildirilmesini arz/rica ederim."));
//                }
//                if (numberOfCopies.ToSupplierUnit > 0 && treatmentDischarge.SentToSupplierUnit == true)
//                {
//                    int cnt = Convert.ToInt16(numberOfCopies.ToSupplierUnit);
//                    Sayac += cnt;
//                    for (int j = 0; j < cnt; j++)
//                        this.dagitimList.Add(new DagitimBilgi("LEVAZIM ŞUBE MÜDÜRLÜĞÜ", EvetHayirEnum.ehHayir, null));
//                }
//                if (numberOfCopies.ToPatientFolder > 0 && (numberOfCopies.PrintFileIfHospitalExists == true || (numberOfCopies.PrintFileIfHospitalExists == false && numberOfCopies.ToHospitalSendingTo > 0 && treatmentDischarge.HospitalSendingTo != null)))
//                {
//                    int cnt = Convert.ToInt16(numberOfCopies.ToPatientFolder);
//                    Sayac += cnt;
//                    for (int j = 0; j < cnt; j++)
//                        this.dagitimList.Add(new DagitimBilgi("DOSYA", EvetHayirEnum.ehHayir, null));
//                }
//            }
//            else
//            {
//                //  tanımı yapılmamış
//            }
//
//            if (Sayac == 0)
//            {
//                Sayac = 1;
//                this.dagitimList.Add(new DagitimBilgi("", EvetHayirEnum.ehHayir, null));
//            }
//            this.Counter_Group.RepeatCount = Sayac;
#endregion TREATMENTDISCHARGEREPORT_PreScript
        }
    }
}