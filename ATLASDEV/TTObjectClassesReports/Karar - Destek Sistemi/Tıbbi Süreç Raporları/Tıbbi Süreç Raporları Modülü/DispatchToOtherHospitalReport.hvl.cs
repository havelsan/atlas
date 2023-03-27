
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
    /// Hasta Sevk Formu
    /// </summary>
    public partial class DispatchToOtherHospitalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public DispatchToOtherHospitalReport MyParentReport
            {
                get { return (DispatchToOtherHospitalReport)ParentReport; }
            }

            new public MASTERGroupHeader Header()
            {
                return (MASTERGroupHeader)_header;
            }

            new public MASTERGroupFooter Footer()
            {
                return (MASTERGroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField NewField11156117 { get {return Footer().NewField11156117;} }
            public MASTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MASTERGroupHeader(this);
                _footer = new MASTERGroupFooter(this);

            }

            public partial class MASTERGroupHeader : TTReportSection
            {
                public DispatchToOtherHospitalReport MyParentReport
                {
                    get { return (DispatchToOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField BASLIK; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 5, 152, 10, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.TextFont.Name = "Calibri";
                    BASLIK.TextFont.Size = 9;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"HASTA SEVK FORMU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = BASLIK.Value;
                    return new TTReportObject[] { BASLIK};
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public DispatchToOtherHospitalReport MyParentReport
                {
                    get { return (DispatchToOtherHospitalReport)ParentReport; }
                }
                
                public TTReportField NewField11156117; 
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 43;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11156117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 200, 40, false);
                    NewField11156117.Name = "NewField11156117";
                    NewField11156117.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11156117.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11156117.TextFont.Name = "Calibri";
                    NewField11156117.TextFont.Size = 8;
                    NewField11156117.TextFont.Bold = true;
                    NewField11156117.Value = @"SEVK EDİLEN SAĞLİK HİZMETİ SUNUCUSUNA MÜRACAAT SÜRESİ ÜÇ (3)  İŞ GÜNÜDÜR.

(*) Gerekli teşhis ve tedavi cihazlarının veya ilgili branş uzman hekiminin bulunmaması vb. tıbbi nedenlerin belirtilmesi gerekmektedir.
(**) Refakatin tıbben gerekli olduğunun gerekçesi ile birlikte belirtilmesi gerekmektedir.
(***) Refakatli olarak gelindiğinin/kalındığının hekim tarafından belirtilmesi gerekmektedir.
(****) Kaşede yer alması gereken diğer bilgiler yanında hekimin çalıştığı sağlık hizmeti sunucusunun adının da yer alması (yoksa hekim tarafından elle yazılmış olması) gerekir.
SEVK FORMUNUN ASLI MÜRACAAT EDİLEN SAĞLIK KURUM/KURULUŞUNDAN AYRILIŞ AŞAMASINDA HASTAYA VERİLECEKTİR. (Ancak; 3816 sayılı ?Ödeme Gücü Olmayan Vatandaşların Tedavi Giderlerinin Yeşil Kart Verilerek Devlet Tarafından Karşılanması Hakkında Kanun? kapsamındaki kişilerin yerleşim yeri dışına yapılan sevklerinde bu sevk formu üç (3) nüsha düzenlenerek, 2 (iki)  nüshası hastaya verilecektir.)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11156117.CalcValue = NewField11156117.Value;
                    return new TTReportObject[] { NewField11156117};
                }
            }

        }

        public MASTERGroup MASTER;

        public partial class PART_AGroup : TTReportGroup
        {
            public DispatchToOtherHospitalReport MyParentReport
            {
                get { return (DispatchToOtherHospitalReport)ParentReport; }
            }

            new public PART_AGroupHeader Header()
            {
                return (PART_AGroupHeader)_header;
            }

            new public PART_AGroupFooter Footer()
            {
                return (PART_AGroupFooter)_footer;
            }

            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField LBLTANI1 { get {return Header().LBLTANI1;} }
            public TTReportField DIAGNOSIS { get {return Header().DIAGNOSIS;} }
            public TTReportShape NewLine171 { get {return Header().NewLine171;} }
            public TTReportField LBLSAGLIKTESISI11 { get {return Header().LBLSAGLIKTESISI11;} }
            public TTReportField LBLPOLIKLINIK11 { get {return Header().LBLPOLIKLINIK11;} }
            public TTReportField LBLSEVKTARIHI11 { get {return Header().LBLSEVKTARIHI11;} }
            public TTReportField LBLDOSYANO11 { get {return Header().LBLDOSYANO11;} }
            public TTReportField LBLSIGORTALIADI11 { get {return Header().LBLSIGORTALIADI11;} }
            public TTReportField LBLPROTOKOLNO11 { get {return Header().LBLPROTOKOLNO11;} }
            public TTReportField LBLSIGORTALITCNO11 { get {return Header().LBLSIGORTALITCNO11;} }
            public TTReportField LBLDOGUMYERI11 { get {return Header().LBLDOGUMYERI11;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField MRESOURCE { get {return Header().MRESOURCE;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportField DOSYANO { get {return Header().DOSYANO;} }
            public TTReportField SIGORTALIADISOYADI { get {return Header().SIGORTALIADISOYADI;} }
            public TTReportField HASTANINADISOYADI { get {return Header().HASTANINADISOYADI;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField SIGORTALITCNO { get {return Header().SIGORTALITCNO;} }
            public TTReportField DOGUMYERIVETARIHI { get {return Header().DOGUMYERIVETARIHI;} }
            public TTReportField LBLSIGORTALIADI111 { get {return Header().LBLSIGORTALIADI111;} }
            public TTReportField LBLSIGORTALITCNO111 { get {return Header().LBLSIGORTALITCNO111;} }
            public TTReportField HASTATCNO { get {return Header().HASTATCNO;} }
            public TTReportField LBLTANI11 { get {return Header().LBLTANI11;} }
            public TTReportField SEVKGEREKCESI { get {return Header().SEVKGEREKCESI;} }
            public TTReportField BIRTHDATE { get {return Header().BIRTHDATE;} }
            public TTReportField BDATE1 { get {return Header().BDATE1;} }
            public TTReportShape NewLine1171 { get {return Header().NewLine1171;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField FIDNUMBER { get {return Header().FIDNUMBER;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public PART_AGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART_AGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class>("GetDispatchInformationOfPatientNQL", DispatchToOtherHospital.GetDispatchInformationOfPatientNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART_AGroupHeader(this);
                _footer = new PART_AGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART_AGroupHeader : TTReportSection
            {
                public DispatchToOtherHospitalReport MyParentReport
                {
                    get { return (DispatchToOtherHospitalReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField LBLTANI1;
                public TTReportField DIAGNOSIS;
                public TTReportShape NewLine171;
                public TTReportField LBLSAGLIKTESISI11;
                public TTReportField LBLPOLIKLINIK11;
                public TTReportField LBLSEVKTARIHI11;
                public TTReportField LBLDOSYANO11;
                public TTReportField LBLSIGORTALIADI11;
                public TTReportField LBLPROTOKOLNO11;
                public TTReportField LBLSIGORTALITCNO11;
                public TTReportField LBLDOGUMYERI11;
                public TTReportField HOSPITALNAME;
                public TTReportField MRESOURCE;
                public TTReportField RDATE;
                public TTReportField DOSYANO;
                public TTReportField SIGORTALIADISOYADI;
                public TTReportField HASTANINADISOYADI;
                public TTReportField PROTOKOLNO;
                public TTReportField SIGORTALITCNO;
                public TTReportField DOGUMYERIVETARIHI;
                public TTReportField LBLSIGORTALIADI111;
                public TTReportField LBLSIGORTALITCNO111;
                public TTReportField HASTATCNO;
                public TTReportField LBLTANI11;
                public TTReportField SEVKGEREKCESI;
                public TTReportField BIRTHDATE;
                public TTReportField BDATE1;
                public TTReportShape NewLine1171;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField TCNO;
                public TTReportField FIDNUMBER;
                public TTReportField OBJECTID; 
                public PART_AGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 70;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 49, 201, 49, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    LBLTANI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 51, 38, 56, false);
                    LBLTANI1.Name = "LBLTANI1";
                    LBLTANI1.TextFont.Name = "Calibri";
                    LBLTANI1.TextFont.Size = 9;
                    LBLTANI1.TextFont.Bold = true;
                    LBLTANI1.Value = @"TANI                             :";

                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 51, 200, 60, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.TextFont.Name = "Calibri";
                    DIAGNOSIS.TextFont.Size = 9;
                    DIAGNOSIS.Value = @"";

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 23, 201, 23, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    LBLSAGLIKTESISI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 78, 10, false);
                    LBLSAGLIKTESISI11.Name = "LBLSAGLIKTESISI11";
                    LBLSAGLIKTESISI11.TextFont.Name = "Calibri";
                    LBLSAGLIKTESISI11.TextFont.Size = 9;
                    LBLSAGLIKTESISI11.TextFont.Bold = true;
                    LBLSAGLIKTESISI11.Value = @"FORMU DÜZENLEYEN SAĞLIK HİZMETİ SUNUCUSU :";

                    LBLPOLIKLINIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 37, 22, false);
                    LBLPOLIKLINIK11.Name = "LBLPOLIKLINIK11";
                    LBLPOLIKLINIK11.TextFont.Name = "Calibri";
                    LBLPOLIKLINIK11.TextFont.Size = 9;
                    LBLPOLIKLINIK11.TextFont.Bold = true;
                    LBLPOLIKLINIK11.Value = @"SEVKİ YAPAN BİRİM : ";

                    LBLSEVKTARIHI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 37, 16, false);
                    LBLSEVKTARIHI11.Name = "LBLSEVKTARIHI11";
                    LBLSEVKTARIHI11.TextFont.Name = "Calibri";
                    LBLSEVKTARIHI11.TextFont.Size = 9;
                    LBLSEVKTARIHI11.TextFont.Bold = true;
                    LBLSEVKTARIHI11.Value = @"SEVK TARİHİ             :";

                    LBLDOSYANO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 43, 67, 48, false);
                    LBLDOSYANO11.Name = "LBLDOSYANO11";
                    LBLDOSYANO11.TextFont.Name = "Calibri";
                    LBLDOSYANO11.TextFont.Size = 9;
                    LBLDOSYANO11.TextFont.Bold = true;
                    LBLDOSYANO11.Value = @"DOSYA NO                                                       : ";

                    LBLSIGORTALIADI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 67, 30, false);
                    LBLSIGORTALIADI11.Name = "LBLSIGORTALIADI11";
                    LBLSIGORTALIADI11.TextFont.Name = "Calibri";
                    LBLSIGORTALIADI11.TextFont.Size = 9;
                    LBLSIGORTALIADI11.TextFont.Bold = true;
                    LBLSIGORTALIADI11.Value = @"GENEL SAĞLIK SİGORTALISININ ADI SOYADI : ";

                    LBLPROTOKOLNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 46, 249, 51, false);
                    LBLPROTOKOLNO11.Name = "LBLPROTOKOLNO11";
                    LBLPROTOKOLNO11.TextFont.Name = "Calibri";
                    LBLPROTOKOLNO11.TextFont.Size = 9;
                    LBLPROTOKOLNO11.TextFont.Bold = true;
                    LBLPROTOKOLNO11.Value = @"PROTOKOL NO  :";

                    LBLSIGORTALITCNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 28, 249, 33, false);
                    LBLSIGORTALITCNO11.Name = "LBLSIGORTALITCNO11";
                    LBLSIGORTALITCNO11.TextFont.Name = "Calibri";
                    LBLSIGORTALITCNO11.TextFont.Size = 9;
                    LBLSIGORTALITCNO11.TextFont.Bold = true;
                    LBLSIGORTALITCNO11.Value = @"TC. KİMLİK NO  :";

                    LBLDOGUMYERI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 37, 67, 42, false);
                    LBLDOGUMYERI11.Name = "LBLDOGUMYERI11";
                    LBLDOGUMYERI11.TextFont.Name = "Calibri";
                    LBLDOGUMYERI11.TextFont.Size = 9;
                    LBLDOGUMYERI11.TextFont.Bold = true;
                    LBLDOGUMYERI11.Value = @"HASTANIN DOĞUM YERİ                                :";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 5, 200, 10, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Calibri";
                    HOSPITALNAME.TextFont.Size = 9;
                    HOSPITALNAME.Value = @"{#REQUESTERHOSPITALNAME#}";

                    MRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 17, 200, 22, false);
                    MRESOURCE.Name = "MRESOURCE";
                    MRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MRESOURCE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    MRESOURCE.NoClip = EvetHayirEnum.ehEvet;
                    MRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    MRESOURCE.TextFont.Name = "Calibri";
                    MRESOURCE.TextFont.Size = 9;
                    MRESOURCE.Value = @"{#MRESOURCE#}";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 11, 70, 16, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.TextFont.Name = "Calibri";
                    RDATE.TextFont.Size = 9;
                    RDATE.Value = @"{#RDATE#}";

                    DOSYANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 43, 104, 48, false);
                    DOSYANO.Name = "DOSYANO";
                    DOSYANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSYANO.TextFont.Name = "Calibri";
                    DOSYANO.TextFont.Size = 9;
                    DOSYANO.Value = @"{#DOSYANO#}";

                    SIGORTALIADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 25, 147, 30, false);
                    SIGORTALIADISOYADI.Name = "SIGORTALIADISOYADI";
                    SIGORTALIADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGORTALIADISOYADI.TextFont.Name = "Calibri";
                    SIGORTALIADISOYADI.TextFont.Size = 9;
                    SIGORTALIADISOYADI.Value = @"{#GSSOWNERNAME#}";

                    HASTANINADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 31, 147, 36, false);
                    HASTANINADISOYADI.Name = "HASTANINADISOYADI";
                    HASTANINADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANINADISOYADI.TextFont.Name = "Calibri";
                    HASTANINADISOYADI.TextFont.Size = 9;
                    HASTANINADISOYADI.Value = @"{#NAME#}   {#SURNAME#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 46, 279, 51, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Calibri";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"";

                    SIGORTALITCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 28, 279, 33, false);
                    SIGORTALITCNO.Name = "SIGORTALITCNO";
                    SIGORTALITCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGORTALITCNO.TextFont.Name = "Calibri";
                    SIGORTALITCNO.TextFont.Size = 9;
                    SIGORTALITCNO.Value = @"{#GSSOWNERUNIQUEREFNO#}";

                    DOGUMYERIVETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 37, 147, 42, false);
                    DOGUMYERIVETARIHI.Name = "DOGUMYERIVETARIHI";
                    DOGUMYERIVETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERIVETARIHI.TextFormat = @"Short Date";
                    DOGUMYERIVETARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DOGUMYERIVETARIHI.NoClip = EvetHayirEnum.ehEvet;
                    DOGUMYERIVETARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    DOGUMYERIVETARIHI.TextFont.Name = "Calibri";
                    DOGUMYERIVETARIHI.TextFont.Size = 9;
                    DOGUMYERIVETARIHI.Value = @"{#CITYOFBIRTHNAME#}{#COUNTRYOFBIRTHNAME#}";

                    LBLSIGORTALIADI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 31, 67, 36, false);
                    LBLSIGORTALIADI111.Name = "LBLSIGORTALIADI111";
                    LBLSIGORTALIADI111.TextFont.Name = "Calibri";
                    LBLSIGORTALIADI111.TextFont.Size = 9;
                    LBLSIGORTALIADI111.TextFont.Bold = true;
                    LBLSIGORTALIADI111.Value = @"HASTANIN ADI SOYADI                                   : ";

                    LBLSIGORTALITCNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 34, 249, 39, false);
                    LBLSIGORTALITCNO111.Name = "LBLSIGORTALITCNO111";
                    LBLSIGORTALITCNO111.TextFont.Name = "Calibri";
                    LBLSIGORTALITCNO111.TextFont.Size = 9;
                    LBLSIGORTALITCNO111.TextFont.Bold = true;
                    LBLSIGORTALITCNO111.Value = @"TC. KİMLİK NO  :";

                    HASTATCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 34, 279, 39, false);
                    HASTATCNO.Name = "HASTATCNO";
                    HASTATCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNO.TextFont.Name = "Calibri";
                    HASTATCNO.TextFont.Size = 9;
                    HASTATCNO.Value = @"";

                    LBLTANI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 61, 38, 66, false);
                    LBLTANI11.Name = "LBLTANI11";
                    LBLTANI11.TextFont.Name = "Calibri";
                    LBLTANI11.TextFont.Size = 9;
                    LBLTANI11.TextFont.Bold = true;
                    LBLTANI11.Value = @"SEVK GEREKÇESİ (*)   : ";

                    SEVKGEREKCESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 61, 200, 70, false);
                    SEVKGEREKCESI.Name = "SEVKGEREKCESI";
                    SEVKGEREKCESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKGEREKCESI.MultiLine = EvetHayirEnum.ehEvet;
                    SEVKGEREKCESI.NoClip = EvetHayirEnum.ehEvet;
                    SEVKGEREKCESI.WordBreak = EvetHayirEnum.ehEvet;
                    SEVKGEREKCESI.TextFont.Name = "Calibri";
                    SEVKGEREKCESI.TextFont.Size = 9;
                    SEVKGEREKCESI.Value = @"{#REASONOFDISPATCH#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 40, 279, 45, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"Short Date";
                    BIRTHDATE.TextFont.Name = "Calibri";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.Value = @"{#BIRTHDATE#}";

                    BDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 40, 249, 45, false);
                    BDATE1.Name = "BDATE1";
                    BDATE1.TextFont.Name = "Calibri";
                    BDATE1.TextFont.Size = 9;
                    BDATE1.TextFont.Bold = true;
                    BDATE1.Value = @"DOĞUM TARİHİ:";

                    NewLine1171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 4, 201, 4, false);
                    NewLine1171.Name = "NewLine1171";
                    NewLine1171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 4, 5, 72, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 4, 201, 72, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 5, 259, 10, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Name = "Arial Narrow";
                    TCNO.TextFont.CharSet = 1;
                    TCNO.Value = @"{#REFNO#}";

                    FIDNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 16, 259, 21, false);
                    FIDNUMBER.Name = "FIDNUMBER";
                    FIDNUMBER.Visible = EvetHayirEnum.ehHayir;
                    FIDNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIDNUMBER.TextFont.Name = "Arial Narrow";
                    FIDNUMBER.TextFont.CharSet = 1;
                    FIDNUMBER.Value = @"{#FOREIGNUNIQUEREFNO#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 10, 254, 15, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFormat = @"dd/MM/yyyy";
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class dataset_GetDispatchInformationOfPatientNQL = ParentGroup.rsGroup.GetCurrentRecord<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class>(0);
                    LBLTANI1.CalcValue = LBLTANI1.Value;
                    DIAGNOSIS.CalcValue = @"";
                    LBLSAGLIKTESISI11.CalcValue = LBLSAGLIKTESISI11.Value;
                    LBLPOLIKLINIK11.CalcValue = LBLPOLIKLINIK11.Value;
                    LBLSEVKTARIHI11.CalcValue = LBLSEVKTARIHI11.Value;
                    LBLDOSYANO11.CalcValue = LBLDOSYANO11.Value;
                    LBLSIGORTALIADI11.CalcValue = LBLSIGORTALIADI11.Value;
                    LBLPROTOKOLNO11.CalcValue = LBLPROTOKOLNO11.Value;
                    LBLSIGORTALITCNO11.CalcValue = LBLSIGORTALITCNO11.Value;
                    LBLDOGUMYERI11.CalcValue = LBLDOGUMYERI11.Value;
                    HOSPITALNAME.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Requesterhospitalname) : "");
                    MRESOURCE.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Mresource) : "");
                    RDATE.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Rdate) : "");
                    DOSYANO.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Dosyano) : "");
                    SIGORTALIADISOYADI.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.GSSOwnerName) : "");
                    HASTANINADISOYADI.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Name) : "") + @"   " + (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Surname) : "");
                    PROTOKOLNO.CalcValue = @"";
                    SIGORTALITCNO.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.GSSOwnerUniquerefNo) : "");
                    DOGUMYERIVETARIHI.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Cityofbirthname) : "") + (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Countryofbirthname) : "");
                    LBLSIGORTALIADI111.CalcValue = LBLSIGORTALIADI111.Value;
                    LBLSIGORTALITCNO111.CalcValue = LBLSIGORTALITCNO111.Value;
                    HASTATCNO.CalcValue = @"";
                    LBLTANI11.CalcValue = LBLTANI11.Value;
                    SEVKGEREKCESI.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.ReasonOfDispatch) : "");
                    BIRTHDATE.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.BirthDate) : "");
                    BDATE1.CalcValue = BDATE1.Value;
                    TCNO.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Refno) : "");
                    FIDNUMBER.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.ForeignUniqueRefNo) : "");
                    OBJECTID.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.ObjectID) : "");
                    return new TTReportObject[] { LBLTANI1,DIAGNOSIS,LBLSAGLIKTESISI11,LBLPOLIKLINIK11,LBLSEVKTARIHI11,LBLDOSYANO11,LBLSIGORTALIADI11,LBLPROTOKOLNO11,LBLSIGORTALITCNO11,LBLDOGUMYERI11,HOSPITALNAME,MRESOURCE,RDATE,DOSYANO,SIGORTALIADISOYADI,HASTANINADISOYADI,PROTOKOLNO,SIGORTALITCNO,DOGUMYERIVETARIHI,LBLSIGORTALIADI111,LBLSIGORTALITCNO111,HASTATCNO,LBLTANI11,SEVKGEREKCESI,BIRTHDATE,BDATE1,TCNO,FIDNUMBER,OBJECTID};
                }

                public override void RunScript()
                {
#region PART_A HEADER_Script
                    if(this.FIDNUMBER.CalcValue != null && this.FIDNUMBER.CalcValue != "")
                this.HASTATCNO.CalcValue = "(*)" + this.FIDNUMBER.CalcValue;
            else if(this.TCNO.CalcValue != null)
                this.HASTATCNO.CalcValue = this.TCNO.CalcValue;
            
            TTObjectContext context = new TTObjectContext(true);
            string objectID = ((DispatchToOtherHospitalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DispatchToOtherHospital dispatchToOtherHospital = (DispatchToOtherHospital)context.GetObject(new Guid(objectID), "DispatchToOtherHospital");

            Episode episodeForDiagnosis = dispatchToOtherHospital.Episode;
            foreach (DiagnosisGrid diagnosis in episodeForDiagnosis.Diagnosis)
            {
                if(diagnosis.Diagnose.Name != null)
                {
                    DIAGNOSIS.CalcValue =(diagnosis.Diagnose.Name).ToString();
                }
            }
            
            this.PROTOKOLNO.CalcValue = episodeForDiagnosis.HospitalProtocolNo.ToString();
            
            
            //if(dispatchToOtherHospital.RequestedReferableHospital != null)
            //{
            //    this.REQUESTEDHOSPITAL.CalcValue = dispatchToOtherHospital.RequestedReferableHospital.ResOtherHospital.Name;
            //    if(dispatchToOtherHospital.RequestedReferableResource != null)
            //       this.REQUESTEDUNIT.CalcValue = dispatchToOtherHospital.RequestedReferableResource.ResourceName;
            //}
            //else if(dispatchToOtherHospital.RequestedExternalHospital != null)
            //{
            //      this.REQUESTEDHOSPITAL.CalcValue = dispatchToOtherHospital.RequestedExternalHospital.Name;
            //      if(dispatchToOtherHospital.RequestedExternalDepartment != null)
            //          this.REQUESTEDUNIT.CalcValue = dispatchToOtherHospital.RequestedExternalDepartment.Name;
            
            //}
#endregion PART_A HEADER_Script
                }
            }
            public partial class PART_AGroupFooter : TTReportSection
            {
                public DispatchToOtherHospitalReport MyParentReport
                {
                    get { return (DispatchToOtherHospitalReport)ParentReport; }
                }
                 
                public PART_AGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PART_AGroup PART_A;

        public partial class MAINGroup : TTReportGroup
        {
            public DispatchToOtherHospitalReport MyParentReport
            {
                get { return (DispatchToOtherHospitalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField NewField1121561112 { get {return Body().NewField1121561112;} }
            public TTReportField NewField111165111 { get {return Body().NewField111165111;} }
            public TTReportField NewField1111561111 { get {return Body().NewField1111561111;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1211561111 { get {return Body().NewField1211561111;} }
            public TTReportField NewField1111561151 { get {return Body().NewField1111561151;} }
            public TTReportField NewField1111561164 { get {return Body().NewField1111561164;} }
            public TTReportField NewField1111561152 { get {return Body().NewField1111561152;} }
            public TTReportField RESSTARTDATE1 { get {return Body().RESSTARTDATE1;} }
            public TTReportField RESENDDATE1 { get {return Body().RESENDDATE1;} }
            public TTReportField SITUATIONDATE1 { get {return Body().SITUATIONDATE1;} }
            public TTReportField ADMISSIONDATE1 { get {return Body().ADMISSIONDATE1;} }
            public TTReportField DISCHARGEDATE1 { get {return Body().DISCHARGEDATE1;} }
            public TTReportField DOCTOR { get {return Body().DOCTOR;} }
            public TTReportField LBLTANI11 { get {return Body().LBLTANI11;} }
            public TTReportField LBLTANI111 { get {return Body().LBLTANI111;} }
            public TTReportField LBLTANI1111 { get {return Body().LBLTANI1111;} }
            public TTReportField NewField0 { get {return Body().NewField0;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField DOCTOR1 { get {return Body().DOCTOR1;} }
            public TTReportField REFAKATCIGEREKCESI { get {return Body().REFAKATCIGEREKCESI;} }
            public TTReportField SEVKVASITASI { get {return Body().SEVKVASITASI;} }
            public TTReportField RESENDDATE11 { get {return Body().RESENDDATE11;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField DOCTOR11 { get {return Body().DOCTOR11;} }
            public TTReportField REFAKATCIDURUMU { get {return Body().REFAKATCIDURUMU;} }
            public TTReportField GIDECEGISEHIR { get {return Body().GIDECEGISEHIR;} }
            public TTReportField LBLTANI112 { get {return Body().LBLTANI112;} }
            public TTReportField DISPATCHEDSPECIALITY { get {return Body().DISPATCHEDSPECIALITY;} }
            public TTReportField SEHTESCILNO { get {return Body().SEHTESCILNO;} }
            public TTReportField LBLSAGLIKTESISI11 { get {return Body().LBLSAGLIKTESISI11;} }
            public TTReportField DISPATCHEDHOSPITAL { get {return Body().DISPATCHEDHOSPITAL;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField DISCHARGEDATE11 { get {return Body().DISCHARGEDATE11;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
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
                public DispatchToOtherHospitalReport MyParentReport
                {
                    get { return (DispatchToOtherHospitalReport)ParentReport; }
                }
                
                public TTReportShape NewLine12;
                public TTReportField NewField1121561112;
                public TTReportField NewField111165111;
                public TTReportField NewField1111561111;
                public TTReportField NewField111;
                public TTReportField NewField1211561111;
                public TTReportField NewField1111561151;
                public TTReportField NewField1111561164;
                public TTReportField NewField1111561152;
                public TTReportField RESSTARTDATE1;
                public TTReportField RESENDDATE1;
                public TTReportField SITUATIONDATE1;
                public TTReportField ADMISSIONDATE1;
                public TTReportField DISCHARGEDATE1;
                public TTReportField DOCTOR;
                public TTReportField LBLTANI11;
                public TTReportField LBLTANI111;
                public TTReportField LBLTANI1111;
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField DOCTOR1;
                public TTReportField REFAKATCIGEREKCESI;
                public TTReportField SEVKVASITASI;
                public TTReportField RESENDDATE11;
                public TTReportField NewField1111;
                public TTReportField DOCTOR11;
                public TTReportField REFAKATCIDURUMU;
                public TTReportField GIDECEGISEHIR;
                public TTReportField LBLTANI112;
                public TTReportField DISPATCHEDSPECIALITY;
                public TTReportField SEHTESCILNO;
                public TTReportField LBLSAGLIKTESISI11;
                public TTReportField DISPATCHEDHOSPITAL;
                public TTReportField NewField2;
                public TTReportField NewField11111;
                public TTReportField DISCHARGEDATE11;
                public TTReportField NewField3;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 122;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 51, 201, 51, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121561112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 59, 103, 64, false);
                    NewField1121561112.Name = "NewField1121561112";
                    NewField1121561112.TextFont.Name = "Calibri";
                    NewField1121561112.TextFont.Size = 9;
                    NewField1121561112.TextFont.Bold = true;
                    NewField1121561112.Value = @"Sevk nedeniyle müracaat edilen sağlık kurum/kuruluşuna başvuru tarihi :";

                    NewField111165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 65, 103, 70, false);
                    NewField111165111.Name = "NewField111165111";
                    NewField111165111.TextFont.Name = "Calibri";
                    NewField111165111.TextFont.Size = 9;
                    NewField111165111.TextFont.Bold = true;
                    NewField111165111.Value = @"Müracaat edilen sağlık kurum/kuruluşundan ayrılış tarihi                          :";

                    NewField1111561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 71, 117, 76, false);
                    NewField1111561111.Name = "NewField1111561111";
                    NewField1111561111.TextFont.Name = "Calibri";
                    NewField1111561111.TextFont.Size = 9;
                    NewField1111561111.TextFont.Bold = true;
                    NewField1111561111.Value = @"tarihleri arasında ayaktan tedavi görmüştür.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 71, 33, 76, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Calibri";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"-";

                    NewField1211561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 77, 117, 82, false);
                    NewField1211561111.Name = "NewField1211561111";
                    NewField1211561111.TextFont.Name = "Calibri";
                    NewField1211561111.TextFont.Size = 9;
                    NewField1211561111.TextFont.Bold = true;
                    NewField1211561111.Value = @"tarihleri arasında yatarak tedavi görmüştür.";

                    NewField1111561151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 101, 147, 106, false);
                    NewField1111561151.Name = "NewField1111561151";
                    NewField1111561151.TextFont.Name = "Calibri";
                    NewField1111561151.TextFont.Size = 9;
                    NewField1111561151.TextFont.Bold = true;
                    NewField1111561151.Value = @"DÜZENLEYEN HEKİM :";

                    NewField1111561164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 107, 134, 112, false);
                    NewField1111561164.Name = "NewField1111561164";
                    NewField1111561164.TextFont.Name = "Calibri";
                    NewField1111561164.TextFont.Size = 9;
                    NewField1111561164.TextFont.Bold = true;
                    NewField1111561164.Value = @"KAŞE (****)";

                    NewField1111561152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 113, 128, 118, false);
                    NewField1111561152.Name = "NewField1111561152";
                    NewField1111561152.TextFont.Name = "Calibri";
                    NewField1111561152.TextFont.Size = 9;
                    NewField1111561152.TextFont.Bold = true;
                    NewField1111561152.Value = @"İMZA     ";

                    RESSTARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 59, 127, 64, false);
                    RESSTARTDATE1.Name = "RESSTARTDATE1";
                    RESSTARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESSTARTDATE1.TextFormat = @"dd/MM/yy";
                    RESSTARTDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESSTARTDATE1.TextFont.Name = "Calibri";
                    RESSTARTDATE1.TextFont.Size = 9;
                    RESSTARTDATE1.Value = @"{#PART_A.RESTINGSTARTDATE1#}";

                    RESENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 65, 127, 70, false);
                    RESENDDATE1.Name = "RESENDDATE1";
                    RESENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESENDDATE1.TextFormat = @"dd/MM/yy";
                    RESENDDATE1.TextFont.Name = "Calibri";
                    RESENDDATE1.TextFont.Size = 9;
                    RESENDDATE1.Value = @"{#PART_A.RESTINGENDDATE1#}";

                    SITUATIONDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 71, 29, 76, false);
                    SITUATIONDATE1.Name = "SITUATIONDATE1";
                    SITUATIONDATE1.TextFormat = @"dd/MM/yyyy";
                    SITUATIONDATE1.TextFont.Name = "Calibri";
                    SITUATIONDATE1.TextFont.Size = 9;
                    SITUATIONDATE1.Value = @"";

                    ADMISSIONDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 77, 29, 82, false);
                    ADMISSIONDATE1.Name = "ADMISSIONDATE1";
                    ADMISSIONDATE1.TextFormat = @"dd/MM/yyyy";
                    ADMISSIONDATE1.TextFont.Name = "Calibri";
                    ADMISSIONDATE1.TextFont.Size = 9;
                    ADMISSIONDATE1.Value = @"";

                    DISCHARGEDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 77, 57, 82, false);
                    DISCHARGEDATE1.Name = "DISCHARGEDATE1";
                    DISCHARGEDATE1.TextFormat = @"dd/MM/yyyy";
                    DISCHARGEDATE1.TextFont.Name = "Calibri";
                    DISCHARGEDATE1.TextFont.Size = 9;
                    DISCHARGEDATE1.Value = @"";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 101, 199, 106, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR.TextFont.Name = "Calibri";
                    DOCTOR.TextFont.Size = 9;
                    DOCTOR.Value = @"{#PART_A.DISPATCHEDDOCTORNAME#}";

                    LBLTANI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 37, 12, false);
                    LBLTANI11.Name = "LBLTANI11";
                    LBLTANI11.TextFont.Name = "Calibri";
                    LBLTANI11.TextFont.Size = 9;
                    LBLTANI11.TextFont.Bold = true;
                    LBLTANI11.Value = @"GİDECEĞİ ŞEHİR          : ";

                    LBLTANI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 13, 37, 18, false);
                    LBLTANI111.Name = "LBLTANI111";
                    LBLTANI111.TextFont.Name = "Calibri";
                    LBLTANI111.TextFont.Size = 9;
                    LBLTANI111.TextFont.Bold = true;
                    LBLTANI111.Value = @"SEVK VASITASI             : ";

                    LBLTANI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 19, 44, 24, false);
                    LBLTANI1111.Name = "LBLTANI1111";
                    LBLTANI1111.TextFont.Name = "Calibri";
                    LBLTANI1111.TextFont.Size = 9;
                    LBLTANI1111.TextFont.Bold = true;
                    LBLTANI1111.Value = @"REFAKATÇİ GEREKÇESİ (**) : ";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 37, 134, 42, false);
                    NewField0.Name = "NewField0";
                    NewField0.TextFont.Name = "Calibri";
                    NewField0.TextFont.Size = 9;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"KAŞE (****)";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 43, 127, 48, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Calibri";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"İMZA ";

                    DOCTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 31, 199, 36, false);
                    DOCTOR1.Name = "DOCTOR1";
                    DOCTOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR1.TextFont.Name = "Calibri";
                    DOCTOR1.TextFont.Size = 9;
                    DOCTOR1.Value = @"{#PART_A.DISPATCHERDOCTORNAME#}";

                    REFAKATCIGEREKCESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 19, 199, 29, false);
                    REFAKATCIGEREKCESI.Name = "REFAKATCIGEREKCESI";
                    REFAKATCIGEREKCESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCIGEREKCESI.MultiLine = EvetHayirEnum.ehEvet;
                    REFAKATCIGEREKCESI.NoClip = EvetHayirEnum.ehEvet;
                    REFAKATCIGEREKCESI.WordBreak = EvetHayirEnum.ehEvet;
                    REFAKATCIGEREKCESI.TextFont.Name = "Calibri";
                    REFAKATCIGEREKCESI.TextFont.Size = 9;
                    REFAKATCIGEREKCESI.Value = @"{#PART_A.COMPANIONREASON#}";

                    SEVKVASITASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 13, 199, 18, false);
                    SEVKVASITASI.Name = "SEVKVASITASI";
                    SEVKVASITASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKVASITASI.TextFont.Name = "Calibri";
                    SEVKVASITASI.TextFont.Size = 9;
                    SEVKVASITASI.Value = @"{#PART_A.DISPATCHVEHICLE#}";

                    RESENDDATE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 71, 57, 76, false);
                    RESENDDATE11.Name = "RESENDDATE11";
                    RESENDDATE11.TextFormat = @"dd/MM/yyyy";
                    RESENDDATE11.TextFont.Name = "Calibri";
                    RESENDDATE11.TextFont.Size = 9;
                    RESENDDATE11.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 77, 33, 82, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Calibri";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"-";

                    DOCTOR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 89, 39, 94, false);
                    DOCTOR11.Name = "DOCTOR11";
                    DOCTOR11.TextFont.Name = "Calibri";
                    DOCTOR11.TextFont.Size = 9;
                    DOCTOR11.TextFont.Bold = true;
                    DOCTOR11.Value = @"Refakatçi durumu (***)  :";

                    REFAKATCIDURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 89, 199, 99, false);
                    REFAKATCIDURUMU.Name = "REFAKATCIDURUMU";
                    REFAKATCIDURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCIDURUMU.TextFont.Name = "Calibri";
                    REFAKATCIDURUMU.TextFont.Size = 9;
                    REFAKATCIDURUMU.Value = @"{#PART_A.COMPANIONSTATUS#}";

                    GIDECEGISEHIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 7, 199, 12, false);
                    GIDECEGISEHIR.Name = "GIDECEGISEHIR";
                    GIDECEGISEHIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDECEGISEHIR.TextFont.Name = "Calibri";
                    GIDECEGISEHIR.TextFont.Size = 9;
                    GIDECEGISEHIR.Value = @"{#PART_A.DISPATCHCITYNAME#}";

                    LBLTANI112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 37, 6, false);
                    LBLTANI112.Name = "LBLTANI112";
                    LBLTANI112.TextFont.Name = "Calibri";
                    LBLTANI112.TextFont.Size = 9;
                    LBLTANI112.TextFont.Bold = true;
                    LBLTANI112.Value = @"SEVK EDİLDİĞİ BRANŞ: ";

                    DISPATCHEDSPECIALITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 199, 6, false);
                    DISPATCHEDSPECIALITY.Name = "DISPATCHEDSPECIALITY";
                    DISPATCHEDSPECIALITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISPATCHEDSPECIALITY.TextFont.Name = "Calibri";
                    DISPATCHEDSPECIALITY.TextFont.Size = 9;
                    DISPATCHEDSPECIALITY.Value = @"{#PART_A.DISPATCHEDSPECIALITYNAME#}";

                    SEHTESCILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 31, 146, 36, false);
                    SEHTESCILNO.Name = "SEHTESCILNO";
                    SEHTESCILNO.TextFont.Name = "Calibri";
                    SEHTESCILNO.TextFont.Size = 9;
                    SEHTESCILNO.TextFont.Bold = true;
                    SEHTESCILNO.Value = @"SEVK EDEN HEKİM    :";

                    LBLSAGLIKTESISI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 53, 73, 58, false);
                    LBLSAGLIKTESISI11.Name = "LBLSAGLIKTESISI11";
                    LBLSAGLIKTESISI11.TextFont.Name = "Calibri";
                    LBLSAGLIKTESISI11.TextFont.Size = 9;
                    LBLSAGLIKTESISI11.TextFont.Bold = true;
                    LBLSAGLIKTESISI11.Value = @"MÜRACAAT EDİLEN SAĞLIK HİZMETİ SUNUCUSU : ";

                    DISPATCHEDHOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 53, 199, 58, false);
                    DISPATCHEDHOSPITAL.Name = "DISPATCHEDHOSPITAL";
                    DISPATCHEDHOSPITAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISPATCHEDHOSPITAL.TextFont.Name = "Arial Narrow";
                    DISPATCHEDHOSPITAL.TextFont.CharSet = 1;
                    DISPATCHEDHOSPITAL.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 83, 29, 88, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.CharSet = 1;
                    NewField2.Value = @"";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 83, 33, 88, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Calibri";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"-";

                    DISCHARGEDATE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 83, 57, 88, false);
                    DISCHARGEDATE11.Name = "DISCHARGEDATE11";
                    DISCHARGEDATE11.TextFormat = @"dd/MM/yyyy";
                    DISCHARGEDATE11.TextFont.Name = "Calibri";
                    DISCHARGEDATE11.TextFont.Size = 9;
                    DISCHARGEDATE11.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 83, 117, 88, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Calibri";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"tarihleri arasında istirahat raporu verilmiştir.   ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, -2, 5, 119, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, -2, 201, 119, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 119, 201, 119, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class dataset_GetDispatchInformationOfPatientNQL = MyParentReport.PART_A.rsGroup.GetCurrentRecord<DispatchToOtherHospital.GetDispatchInformationOfPatientNQL_Class>(0);
                    NewField1121561112.CalcValue = NewField1121561112.Value;
                    NewField111165111.CalcValue = NewField111165111.Value;
                    NewField1111561111.CalcValue = NewField1111561111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1211561111.CalcValue = NewField1211561111.Value;
                    NewField1111561151.CalcValue = NewField1111561151.Value;
                    NewField1111561164.CalcValue = NewField1111561164.Value;
                    NewField1111561152.CalcValue = NewField1111561152.Value;
                    RESSTARTDATE1.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Restingstartdate1) : "");
                    RESENDDATE1.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Restingenddate1) : "");
                    SITUATIONDATE1.CalcValue = SITUATIONDATE1.Value;
                    ADMISSIONDATE1.CalcValue = ADMISSIONDATE1.Value;
                    DISCHARGEDATE1.CalcValue = DISCHARGEDATE1.Value;
                    DOCTOR.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.DispatchedDoctorName) : "");
                    LBLTANI11.CalcValue = LBLTANI11.Value;
                    LBLTANI111.CalcValue = LBLTANI111.Value;
                    LBLTANI1111.CalcValue = LBLTANI1111.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    DOCTOR1.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.DispatcherDoctorName) : "");
                    REFAKATCIGEREKCESI.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.CompanionReason) : "");
                    SEVKVASITASI.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.DispatchVehicle) : "");
                    RESENDDATE11.CalcValue = RESENDDATE11.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    DOCTOR11.CalcValue = DOCTOR11.Value;
                    REFAKATCIDURUMU.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.CompanionStatus) : "");
                    GIDECEGISEHIR.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Dispatchcityname) : "");
                    LBLTANI112.CalcValue = LBLTANI112.Value;
                    DISPATCHEDSPECIALITY.CalcValue = (dataset_GetDispatchInformationOfPatientNQL != null ? Globals.ToStringCore(dataset_GetDispatchInformationOfPatientNQL.Dispatchedspecialityname) : "");
                    SEHTESCILNO.CalcValue = SEHTESCILNO.Value;
                    LBLSAGLIKTESISI11.CalcValue = LBLSAGLIKTESISI11.Value;
                    DISPATCHEDHOSPITAL.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    DISCHARGEDATE11.CalcValue = DISCHARGEDATE11.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField1121561112,NewField111165111,NewField1111561111,NewField111,NewField1211561111,NewField1111561151,NewField1111561164,NewField1111561152,RESSTARTDATE1,RESENDDATE1,SITUATIONDATE1,ADMISSIONDATE1,DISCHARGEDATE1,DOCTOR,LBLTANI11,LBLTANI111,LBLTANI1111,NewField0,NewField1,DOCTOR1,REFAKATCIGEREKCESI,SEVKVASITASI,RESENDDATE11,NewField1111,DOCTOR11,REFAKATCIDURUMU,GIDECEGISEHIR,LBLTANI112,DISPATCHEDSPECIALITY,SEHTESCILNO,LBLSAGLIKTESISI11,DISPATCHEDHOSPITAL,NewField2,NewField11111,DISCHARGEDATE11,NewField3};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DispatchToOtherHospitalReport()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            PART_A = new PART_AGroup(MASTER,"PART_A");
            MAIN = new MAINGroup(PART_A,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DISPATCHTOOTHERHOSPITALREPORT";
            Caption = "Hasta Sevk Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            UserMarginLeft = 5;
            UserMarginTop = 10;
            p_PageWidth = 216;
            p_PageHeight = 279;
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