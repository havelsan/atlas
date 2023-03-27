
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class XXXXXXIHEWS : TTObject
    {

        #region Methods


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", IsNullable = false)]
        public partial class IHEWsHeader 
        {

            private string usernameField;

            private string passwordField;

            private System.Xml.XmlAttribute[] anyAttrField;

            /// <remarks/>
            public string Username
            {
                get
                {
                    return usernameField;
                }
                set
                {
                    usernameField = value;
                }
            }

            /// <remarks/>
            public string Password
            {
                get
                {
                    return passwordField;
                }
                set
                {
                    passwordField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAnyAttributeAttribute()]
            public System.Xml.XmlAttribute[] AnyAttr
            {
                get
                {
                    return anyAttrField;
                }
                set
                {
                    anyAttrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OrnekDosya
        {

            private int ornekNoField;

            private string loincKoduField;

            private string dosyaHexField;

            /// <remarks/>
            public int OrnekNo
            {
                get
                {
                    return ornekNoField;
                }
                set
                {
                    ornekNoField = value;
                }
            }

            /// <remarks/>
            public string LoincKodu
            {
                get
                {
                    return loincKoduField;
                }
                set
                {
                    loincKoduField = value;
                }
            }

            /// <remarks/>
            public string DosyaHex
            {
                get
                {
                    return dosyaHexField;
                }
                set
                {
                    dosyaHexField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OrnekDosyaList
        {

            private OrnekDosya[] ornekDosyaArrField;

            private string hataMesajiField;

            /// <remarks/>
            public OrnekDosya[] OrnekDosyaArr
            {
                get
                {
                    return ornekDosyaArrField;
                }
                set
                {
                    ornekDosyaArrField = value;
                }
            }

            /// <remarks/>
            public string HataMesaji
            {
                get
                {
                    return hataMesajiField;
                }
                set
                {
                    hataMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TestCalisSayi
        {

            private string test_AdiField;

            private string lOINC_KoduField;

            private string sayiField;

            private string aciklama1Field;

            private string aciklama2Field;

            private string aciklama3Field;

            private string aciklama4Field;

            private string aciklama5Field;

            /// <remarks/>
            public string Test_Adi
            {
                get
                {
                    return test_AdiField;
                }
                set
                {
                    test_AdiField = value;
                }
            }

            /// <remarks/>
            public string LOINC_Kodu
            {
                get
                {
                    return lOINC_KoduField;
                }
                set
                {
                    lOINC_KoduField = value;
                }
            }

            /// <remarks/>
            public string Sayi
            {
                get
                {
                    return sayiField;
                }
                set
                {
                    sayiField = value;
                }
            }

            /// <remarks/>
            public string Aciklama1
            {
                get
                {
                    return aciklama1Field;
                }
                set
                {
                    aciklama1Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama2
            {
                get
                {
                    return aciklama2Field;
                }
                set
                {
                    aciklama2Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama3
            {
                get
                {
                    return aciklama3Field;
                }
                set
                {
                    aciklama3Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama4
            {
                get
                {
                    return aciklama4Field;
                }
                set
                {
                    aciklama4Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama5
            {
                get
                {
                    return aciklama5Field;
                }
                set
                {
                    aciklama5Field = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TestCalisSayiArr
        {

            private TestCalisSayi[] testCalisSayiListField;

            /// <remarks/>
            public TestCalisSayi[] TestCalisSayiList
            {
                get
                {
                    return testCalisSayiListField;
                }
                set
                {
                    testCalisSayiListField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Mesajlar
        {

            private Mesaj[] mesajArrField;

            /// <remarks/>
            public Mesaj[] MesajArr
            {
                get
                {
                    return mesajArrField;
                }
                set
                {
                    mesajArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Mesaj
        {

            private string mesajNoField;

            private string ref_MesajNoField;

            private string kaynakKurumKoduField;

            private string hedefKurumKoduField;

            private string kaynakKurumField;

            private string ornekNoField;

            private string mesajTuruField;

            private string mesajTextField;

            private string tarihField;

            /// <remarks/>
            public string MesajNo
            {
                get
                {
                    return mesajNoField;
                }
                set
                {
                    mesajNoField = value;
                }
            }

            /// <remarks/>
            public string Ref_MesajNo
            {
                get
                {
                    return ref_MesajNoField;
                }
                set
                {
                    ref_MesajNoField = value;
                }
            }

            /// <remarks/>
            public string KaynakKurumKodu
            {
                get
                {
                    return kaynakKurumKoduField;
                }
                set
                {
                    kaynakKurumKoduField = value;
                }
            }

            /// <remarks/>
            public string HedefKurumKodu
            {
                get
                {
                    return hedefKurumKoduField;
                }
                set
                {
                    hedefKurumKoduField = value;
                }
            }

            /// <remarks/>
            public string KaynakKurum
            {
                get
                {
                    return kaynakKurumField;
                }
                set
                {
                    kaynakKurumField = value;
                }
            }

            /// <remarks/>
            public string OrnekNo
            {
                get
                {
                    return ornekNoField;
                }
                set
                {
                    ornekNoField = value;
                }
            }

            /// <remarks/>
            public string MesajTuru
            {
                get
                {
                    return mesajTuruField;
                }
                set
                {
                    mesajTuruField = value;
                }
            }

            /// <remarks/>
            public string MesajText
            {
                get
                {
                    return mesajTextField;
                }
                set
                {
                    mesajTextField = value;
                }
            }

            /// <remarks/>
            public string Tarih
            {
                get
                {
                    return tarihField;
                }
                set
                {
                    tarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TetkikBilgi
        {

            private string loincKoduField;

            private string sutKoduField;

            private string adiField;

            private string uniteKoduField;

            private string uniteAdiField;

            private string aktifField;

            private string calistigiYerField;

            private string baslikField;

            private string birlikteIstenenTestlerField;

            private string panelAdiField;

            private string panelLoincKoduField;

            private int testSirasiField;

            private string notField;

            private string degismeTarihiField;

            /// <remarks/>
            public string LoincKodu
            {
                get
                {
                    return loincKoduField;
                }
                set
                {
                    loincKoduField = value;
                }
            }

            /// <remarks/>
            public string SutKodu
            {
                get
                {
                    return sutKoduField;
                }
                set
                {
                    sutKoduField = value;
                }
            }

            /// <remarks/>
            public string Adi
            {
                get
                {
                    return adiField;
                }
                set
                {
                    adiField = value;
                }
            }

            /// <remarks/>
            public string UniteKodu
            {
                get
                {
                    return uniteKoduField;
                }
                set
                {
                    uniteKoduField = value;
                }
            }

            /// <remarks/>
            public string UniteAdi
            {
                get
                {
                    return uniteAdiField;
                }
                set
                {
                    uniteAdiField = value;
                }
            }

            /// <remarks/>
            public string Aktif
            {
                get
                {
                    return aktifField;
                }
                set
                {
                    aktifField = value;
                }
            }

            /// <remarks/>
            public string CalistigiYer
            {
                get
                {
                    return calistigiYerField;
                }
                set
                {
                    calistigiYerField = value;
                }
            }

            /// <remarks/>
            public string Baslik
            {
                get
                {
                    return baslikField;
                }
                set
                {
                    baslikField = value;
                }
            }

            /// <remarks/>
            public string BirlikteIstenenTestler
            {
                get
                {
                    return birlikteIstenenTestlerField;
                }
                set
                {
                    birlikteIstenenTestlerField = value;
                }
            }

            /// <remarks/>
            public string PanelAdi
            {
                get
                {
                    return panelAdiField;
                }
                set
                {
                    panelAdiField = value;
                }
            }

            /// <remarks/>
            public string PanelLoincKodu
            {
                get
                {
                    return panelLoincKoduField;
                }
                set
                {
                    panelLoincKoduField = value;
                }
            }

            /// <remarks/>
            public int TestSirasi
            {
                get
                {
                    return testSirasiField;
                }
                set
                {
                    testSirasiField = value;
                }
            }

            /// <remarks/>
            public string Not
            {
                get
                {
                    return notField;
                }
                set
                {
                    notField = value;
                }
            }

            /// <remarks/>
            public string DegismeTarihi
            {
                get
                {
                    return degismeTarihiField;
                }
                set
                {
                    degismeTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TetkikBilgiListe
        {

            private TetkikBilgi[] tetkikBilgiArrField;

            /// <remarks/>
            public TetkikBilgi[] TetkikBilgiArr
            {
                get
                {
                    return tetkikBilgiArrField;
                }
                set
                {
                    tetkikBilgiArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HazirOrnek
        {

            private string ornekNoField;

            private string tarihField;

            /// <remarks/>
            public string OrnekNo
            {
                get
                {
                    return ornekNoField;
                }
                set
                {
                    ornekNoField = value;
                }
            }

            /// <remarks/>
            public string Tarih
            {
                get
                {
                    return tarihField;
                }
                set
                {
                    tarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HazirOrnekler
        {

            private HazirOrnek[] hazirOrnekArrField;

            /// <remarks/>
            public HazirOrnek[] HazirOrnekArr
            {
                get
                {
                    return hazirOrnekArrField;
                }
                set
                {
                    hazirOrnekArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HazirUrun
        {

            private string urunNoField;

            private string tarihField;

            private string aciklama1Field;

            private string aciklama2Field;

            private string aciklama3Field;

            private string aciklama4Field;

            private string aciklama5Field;

            /// <remarks/>
            public string UrunNo
            {
                get
                {
                    return urunNoField;
                }
                set
                {
                    urunNoField = value;
                }
            }

            /// <remarks/>
            public string Tarih
            {
                get
                {
                    return tarihField;
                }
                set
                {
                    tarihField = value;
                }
            }

            /// <remarks/>
            public string Aciklama1
            {
                get
                {
                    return aciklama1Field;
                }
                set
                {
                    aciklama1Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama2
            {
                get
                {
                    return aciklama2Field;
                }
                set
                {
                    aciklama2Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama3
            {
                get
                {
                    return aciklama3Field;
                }
                set
                {
                    aciklama3Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama4
            {
                get
                {
                    return aciklama4Field;
                }
                set
                {
                    aciklama4Field = value;
                }
            }

            /// <remarks/>
            public string Aciklama5
            {
                get
                {
                    return aciklama5Field;
                }
                set
                {
                    aciklama5Field = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HazirUrunler
        {

            private HazirUrun[] hazirUrunArrField;

            /// <remarks/>
            public HazirUrun[] HazirUrunArr
            {
                get
                {
                    return hazirUrunArrField;
                }
                set
                {
                    hazirUrunArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HastaUrun
        {

            private string hASTAURUNENTEG_IDField;

            private string uRUN_LOINC_KODUField;

            private string uRUN_TIPIField;

            private string uRUNNOField;

            private string iSBT_UNITE_NOField;

            private string iSBT_BILESEN_KODUField;

            private string kANGRUP_ADField;

            private string sTATUField;

            private string uRUN_TALEPField;

            private string uRUN_TALEP_TARIHIField;

            private string cROSS_SONUCField;

            private string tRANSFUZYONField;

            private string pARAMETRE_1_ACIKLAMAField;

            private string pARAMETRE_1_DEGERField;

            private string pARAMETRE_2_ACIKLAMAField;

            private string pARAMETRE_2_DEGERField;

            private string pARAMETRE_3_ACIKLAMAField;

            private string pARAMETRE_3_DEGERField;

            private string pARAMETRE_4_ACIKLAMAField;

            private string pARAMETRE_4_DEGERField;

            private string pARAMETRE_5_ACIKLAMAField;

            private string pARAMETRE_5_DEGERField;

            private string pARAMETRE_6_ACIKLAMAField;

            private string pARAMETRE_6_DEGERField;

            private string pARAMETRE_7_ACIKLAMAField;

            private string pARAMETRE_7_DEGERField;

            private string pARAMETRE_8_ACIKLAMAField;

            private string pARAMETRE_8_DEGERField;

            private string pARAMETRE_9_ACIKLAMAField;

            private string pARAMETRE_9_DEGERField;

            private string pARAMETRE_10_ACIKLAMAField;

            private string pARAMETRE_10_DEGERField;

            /// <remarks/>
            public string HASTAURUNENTEG_ID
            {
                get
                {
                    return hASTAURUNENTEG_IDField;
                }
                set
                {
                    hASTAURUNENTEG_IDField = value;
                }
            }

            /// <remarks/>
            public string URUN_LOINC_KODU
            {
                get
                {
                    return uRUN_LOINC_KODUField;
                }
                set
                {
                    uRUN_LOINC_KODUField = value;
                }
            }

            /// <remarks/>
            public string URUN_TIPI
            {
                get
                {
                    return uRUN_TIPIField;
                }
                set
                {
                    uRUN_TIPIField = value;
                }
            }

            /// <remarks/>
            public string URUNNO
            {
                get
                {
                    return uRUNNOField;
                }
                set
                {
                    uRUNNOField = value;
                }
            }

            /// <remarks/>
            public string ISBT_UNITE_NO
            {
                get
                {
                    return iSBT_UNITE_NOField;
                }
                set
                {
                    iSBT_UNITE_NOField = value;
                }
            }

            /// <remarks/>
            public string ISBT_BILESEN_KODU
            {
                get
                {
                    return iSBT_BILESEN_KODUField;
                }
                set
                {
                    iSBT_BILESEN_KODUField = value;
                }
            }

            /// <remarks/>
            public string KANGRUP_AD
            {
                get
                {
                    return kANGRUP_ADField;
                }
                set
                {
                    kANGRUP_ADField = value;
                }
            }

            /// <remarks/>
            public string STATU
            {
                get
                {
                    return sTATUField;
                }
                set
                {
                    sTATUField = value;
                }
            }

            /// <remarks/>
            public string URUN_TALEP
            {
                get
                {
                    return uRUN_TALEPField;
                }
                set
                {
                    uRUN_TALEPField = value;
                }
            }

            /// <remarks/>
            public string URUN_TALEP_TARIHI
            {
                get
                {
                    return uRUN_TALEP_TARIHIField;
                }
                set
                {
                    uRUN_TALEP_TARIHIField = value;
                }
            }

            /// <remarks/>
            public string CROSS_SONUC
            {
                get
                {
                    return cROSS_SONUCField;
                }
                set
                {
                    cROSS_SONUCField = value;
                }
            }

            /// <remarks/>
            public string TRANSFUZYON
            {
                get
                {
                    return tRANSFUZYONField;
                }
                set
                {
                    tRANSFUZYONField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_1_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_1_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_1_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_1_DEGER
            {
                get
                {
                    return pARAMETRE_1_DEGERField;
                }
                set
                {
                    pARAMETRE_1_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_2_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_2_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_2_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_2_DEGER
            {
                get
                {
                    return pARAMETRE_2_DEGERField;
                }
                set
                {
                    pARAMETRE_2_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_3_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_3_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_3_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_3_DEGER
            {
                get
                {
                    return pARAMETRE_3_DEGERField;
                }
                set
                {
                    pARAMETRE_3_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_4_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_4_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_4_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_4_DEGER
            {
                get
                {
                    return pARAMETRE_4_DEGERField;
                }
                set
                {
                    pARAMETRE_4_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_5_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_5_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_5_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_5_DEGER
            {
                get
                {
                    return pARAMETRE_5_DEGERField;
                }
                set
                {
                    pARAMETRE_5_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_6_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_6_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_6_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_6_DEGER
            {
                get
                {
                    return pARAMETRE_6_DEGERField;
                }
                set
                {
                    pARAMETRE_6_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_7_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_7_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_7_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_7_DEGER
            {
                get
                {
                    return pARAMETRE_7_DEGERField;
                }
                set
                {
                    pARAMETRE_7_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_8_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_8_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_8_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_8_DEGER
            {
                get
                {
                    return pARAMETRE_8_DEGERField;
                }
                set
                {
                    pARAMETRE_8_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_9_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_9_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_9_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_9_DEGER
            {
                get
                {
                    return pARAMETRE_9_DEGERField;
                }
                set
                {
                    pARAMETRE_9_DEGERField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_10_ACIKLAMA
            {
                get
                {
                    return pARAMETRE_10_ACIKLAMAField;
                }
                set
                {
                    pARAMETRE_10_ACIKLAMAField = value;
                }
            }

            /// <remarks/>
            public string PARAMETRE_10_DEGER
            {
                get
                {
                    return pARAMETRE_10_DEGERField;
                }
                set
                {
                    pARAMETRE_10_DEGERField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HastaKanIstem
        {

            private HastaUrun[] hastaUrunlerField;

            private string hASTA_IDField;

            private string dOSYA_NOField;

            private string pROTOKOL_NOField;

            private string hIZMET_IDField;

            private string iSTEM_IDField;

            private string iSTEM_TARIHIField;

            private string kBTESTLERField;

            /// <remarks/>
            public HastaUrun[] HastaUrunler
            {
                get
                {
                    return hastaUrunlerField;
                }
                set
                {
                    hastaUrunlerField = value;
                }
            }

            /// <remarks/>
            public string HASTA_ID
            {
                get
                {
                    return hASTA_IDField;
                }
                set
                {
                    hASTA_IDField = value;
                }
            }

            /// <remarks/>
            public string DOSYA_NO
            {
                get
                {
                    return dOSYA_NOField;
                }
                set
                {
                    dOSYA_NOField = value;
                }
            }

            /// <remarks/>
            public string PROTOKOL_NO
            {
                get
                {
                    return pROTOKOL_NOField;
                }
                set
                {
                    pROTOKOL_NOField = value;
                }
            }

            /// <remarks/>
            public string HIZMET_ID
            {
                get
                {
                    return hIZMET_IDField;
                }
                set
                {
                    hIZMET_IDField = value;
                }
            }

            /// <remarks/>
            public string ISTEM_ID
            {
                get
                {
                    return iSTEM_IDField;
                }
                set
                {
                    iSTEM_IDField = value;
                }
            }

            /// <remarks/>
            public string ISTEM_TARIHI
            {
                get
                {
                    return iSTEM_TARIHIField;
                }
                set
                {
                    iSTEM_TARIHIField = value;
                }
            }

            /// <remarks/>
            public string KBTESTLER
            {
                get
                {
                    return kBTESTLERField;
                }
                set
                {
                    kBTESTLERField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class HastaKanIstemler
        {

            private HastaKanIstem[] hastaKanIstemArrField;

            /// <remarks/>
            public HastaKanIstem[] HastaKanIstemArr
            {
                get
                {
                    return hastaKanIstemArrField;
                }
                set
                {
                    hastaKanIstemArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ACK
        {

            private MSH mshField;

            private MSA msaField;

            private ERR[] errArrField;

            /// <remarks/>
            public MSH Msh
            {
                get
                {
                    return mshField;
                }
                set
                {
                    mshField = value;
                }
            }

            /// <remarks/>
            public MSA Msa
            {
                get
                {
                    return msaField;
                }
                set
                {
                    msaField = value;
                }
            }

            /// <remarks/>
            public ERR[] ErrArr
            {
                get
                {
                    return errArrField;
                }
                set
                {
                    errArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MSH
        {

            private string fieldSeparatorField;

            private string encodingCharactersField;

            private string sendingApplicationField;

            private string sendingFacilityField;

            private string receivingApplicationField;

            private string receivingFacilityField;

            private string dateTimeOfMessageField;

            private string securityField;

            private string messageTypeField;

            private string messageControlIDField;

            private string processingIDField;

            private string versionIDField;

            private string sequenceNumberField;

            private string continuationPointerField;

            private string acceptAckTypeField;

            private string appAckTypeField;

            private string countryCodeField;

            private string characterSetField;

            private string prncplLangOfMessageField;

            private string altCharSetHandSchemeField;

            private string messageProfIDField;

            /// <remarks/>
            public string FieldSeparator
            {
                get
                {
                    return fieldSeparatorField;
                }
                set
                {
                    fieldSeparatorField = value;
                }
            }

            /// <remarks/>
            public string EncodingCharacters
            {
                get
                {
                    return encodingCharactersField;
                }
                set
                {
                    encodingCharactersField = value;
                }
            }

            /// <remarks/>
            public string SendingApplication
            {
                get
                {
                    return sendingApplicationField;
                }
                set
                {
                    sendingApplicationField = value;
                }
            }

            /// <remarks/>
            public string SendingFacility
            {
                get
                {
                    return sendingFacilityField;
                }
                set
                {
                    sendingFacilityField = value;
                }
            }

            /// <remarks/>
            public string ReceivingApplication
            {
                get
                {
                    return receivingApplicationField;
                }
                set
                {
                    receivingApplicationField = value;
                }
            }

            /// <remarks/>
            public string ReceivingFacility
            {
                get
                {
                    return receivingFacilityField;
                }
                set
                {
                    receivingFacilityField = value;
                }
            }

            /// <remarks/>
            public string DateTimeOfMessage
            {
                get
                {
                    return dateTimeOfMessageField;
                }
                set
                {
                    dateTimeOfMessageField = value;
                }
            }

            /// <remarks/>
            public string Security
            {
                get
                {
                    return securityField;
                }
                set
                {
                    securityField = value;
                }
            }

            /// <remarks/>
            public string MessageType
            {
                get
                {
                    return messageTypeField;
                }
                set
                {
                    messageTypeField = value;
                }
            }

            /// <remarks/>
            public string MessageControlID
            {
                get
                {
                    return messageControlIDField;
                }
                set
                {
                    messageControlIDField = value;
                }
            }

            /// <remarks/>
            public string ProcessingID
            {
                get
                {
                    return processingIDField;
                }
                set
                {
                    processingIDField = value;
                }
            }

            /// <remarks/>
            public string VersionID
            {
                get
                {
                    return versionIDField;
                }
                set
                {
                    versionIDField = value;
                }
            }

            /// <remarks/>
            public string SequenceNumber
            {
                get
                {
                    return sequenceNumberField;
                }
                set
                {
                    sequenceNumberField = value;
                }
            }

            /// <remarks/>
            public string ContinuationPointer
            {
                get
                {
                    return continuationPointerField;
                }
                set
                {
                    continuationPointerField = value;
                }
            }

            /// <remarks/>
            public string AcceptAckType
            {
                get
                {
                    return acceptAckTypeField;
                }
                set
                {
                    acceptAckTypeField = value;
                }
            }

            /// <remarks/>
            public string AppAckType
            {
                get
                {
                    return appAckTypeField;
                }
                set
                {
                    appAckTypeField = value;
                }
            }

            /// <remarks/>
            public string CountryCode
            {
                get
                {
                    return countryCodeField;
                }
                set
                {
                    countryCodeField = value;
                }
            }

            /// <remarks/>
            public string CharacterSet
            {
                get
                {
                    return characterSetField;
                }
                set
                {
                    characterSetField = value;
                }
            }

            /// <remarks/>
            public string PrncplLangOfMessage
            {
                get
                {
                    return prncplLangOfMessageField;
                }
                set
                {
                    prncplLangOfMessageField = value;
                }
            }

            /// <remarks/>
            public string AltCharSetHandScheme
            {
                get
                {
                    return altCharSetHandSchemeField;
                }
                set
                {
                    altCharSetHandSchemeField = value;
                }
            }

            /// <remarks/>
            public string MessageProfID
            {
                get
                {
                    return messageProfIDField;
                }
                set
                {
                    messageProfIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class MSA
        {

            private string acknowledgmentCodeField;

            private string messageControlIDField;

            private string textMessageField;

            private string expectedSequenceNumberField;

            private string delayedAcknowledgmentTypeField;

            private string errorConditionField;

            /// <remarks/>
            public string AcknowledgmentCode
            {
                get
                {
                    return acknowledgmentCodeField;
                }
                set
                {
                    acknowledgmentCodeField = value;
                }
            }

            /// <remarks/>
            public string MessageControlID
            {
                get
                {
                    return messageControlIDField;
                }
                set
                {
                    messageControlIDField = value;
                }
            }

            /// <remarks/>
            public string TextMessage
            {
                get
                {
                    return textMessageField;
                }
                set
                {
                    textMessageField = value;
                }
            }

            /// <remarks/>
            public string ExpectedSequenceNumber
            {
                get
                {
                    return expectedSequenceNumberField;
                }
                set
                {
                    expectedSequenceNumberField = value;
                }
            }

            /// <remarks/>
            public string DelayedAcknowledgmentType
            {
                get
                {
                    return delayedAcknowledgmentTypeField;
                }
                set
                {
                    delayedAcknowledgmentTypeField = value;
                }
            }

            /// <remarks/>
            public string ErrorCondition
            {
                get
                {
                    return errorConditionField;
                }
                set
                {
                    errorConditionField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ERR
        {

            private string errorCodeAndLocationField;

            private string errorLocationField;

            private string hL7ErrorCodeField;

            private string severityField;

            private string applicationErrorCodeField;

            private string applicationErrorParameterField;

            private string diagnosticInformationField;

            private string userMessageField;

            private string informPersonIndicatorField;

            private string overrideTypeField;

            private string overrideReasonCodeField;

            private string helpDeskContactPointField;

            /// <remarks/>
            public string ErrorCodeAndLocation
            {
                get
                {
                    return errorCodeAndLocationField;
                }
                set
                {
                    errorCodeAndLocationField = value;
                }
            }

            /// <remarks/>
            public string ErrorLocation
            {
                get
                {
                    return errorLocationField;
                }
                set
                {
                    errorLocationField = value;
                }
            }

            /// <remarks/>
            public string HL7ErrorCode
            {
                get
                {
                    return hL7ErrorCodeField;
                }
                set
                {
                    hL7ErrorCodeField = value;
                }
            }

            /// <remarks/>
            public string Severity
            {
                get
                {
                    return severityField;
                }
                set
                {
                    severityField = value;
                }
            }

            /// <remarks/>
            public string ApplicationErrorCode
            {
                get
                {
                    return applicationErrorCodeField;
                }
                set
                {
                    applicationErrorCodeField = value;
                }
            }

            /// <remarks/>
            public string ApplicationErrorParameter
            {
                get
                {
                    return applicationErrorParameterField;
                }
                set
                {
                    applicationErrorParameterField = value;
                }
            }

            /// <remarks/>
            public string DiagnosticInformation
            {
                get
                {
                    return diagnosticInformationField;
                }
                set
                {
                    diagnosticInformationField = value;
                }
            }

            /// <remarks/>
            public string UserMessage
            {
                get
                {
                    return userMessageField;
                }
                set
                {
                    userMessageField = value;
                }
            }

            /// <remarks/>
            public string InformPersonIndicator
            {
                get
                {
                    return informPersonIndicatorField;
                }
                set
                {
                    informPersonIndicatorField = value;
                }
            }

            /// <remarks/>
            public string OverrideType
            {
                get
                {
                    return overrideTypeField;
                }
                set
                {
                    overrideTypeField = value;
                }
            }

            /// <remarks/>
            public string OverrideReasonCode
            {
                get
                {
                    return overrideReasonCodeField;
                }
                set
                {
                    overrideReasonCodeField = value;
                }
            }

            /// <remarks/>
            public string HelpDeskContactPoint
            {
                get
                {
                    return helpDeskContactPointField;
                }
                set
                {
                    helpDeskContactPointField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OULOrder
        {

            private OBR obrField;

            private ORC orcField;

            private TQ1 tq1Field;

            private OBX[] obxArrField;

            /// <remarks/>
            public OBR Obr
            {
                get
                {
                    return obrField;
                }
                set
                {
                    obrField = value;
                }
            }

            /// <remarks/>
            public ORC Orc
            {
                get
                {
                    return orcField;
                }
                set
                {
                    orcField = value;
                }
            }

            /// <remarks/>
            public TQ1 Tq1
            {
                get
                {
                    return tq1Field;
                }
                set
                {
                    tq1Field = value;
                }
            }

            /// <remarks/>
            public OBX[] ObxArr
            {
                get
                {
                    return obxArrField;
                }
                set
                {
                    obxArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OBR
        {

            private string setIDOBRField;

            private string placerOrderNumberField;

            private string fillerOrderNumberField;

            private string universalServiceIDField;

            private string priorityField;

            private string requestedDatetimeField;

            private string observationDateTimeField;

            private string observationEndDateTimeField;

            private string collectionVolumeField;

            private string collectorIdentifierField;

            private string specimenActionCodeField;

            private string dangerCodeField;

            private string relevantClinicalInfoField;

            private string specimenReceivedDateTimeField;

            private string specimenSourceField;

            private string orderingProviderField;

            private string orderCallbackPhoneNumberField;

            private string placerfield1Field;

            private string placerfield2Field;

            private string fillerField1Field;

            private string fillerField2Field;

            private string resultsRptStatusChngDTimeField;

            private string chargetoPracticeField;

            private string diagnosticServSectIDField;

            private string resultStatusField;

            private string parentResultField;

            private string quantityTimingField;

            private string resultCopiesToField;

            private string parentField;

            private string transportationModeField;

            private string reasonforStudyField;

            private string principalResultInterpreterField;

            private string assistantResultInterpreterField;

            private string technicianField;

            private string transcriptionistField;

            private string scheduledDateTimeField;

            private string numberofSampleContainersField;

            private string transLogisticsofCSampleField;

            private string collectorsCommentField;

            private string transportArrRespField;

            private string transportArrangedField;

            private string escortRequiredField;

            private string patientTransportCommentField;

            private string procedureCodeField;

            private string procedureCodeModifierField;

            private string placerSuppServiceInfoField;

            private string fillerSuppServiceInfoField;

            private string medicNecessaryDupProcReaField;

            private string resultHandlingField;

            private DG1[] dg1Field;

            /// <remarks/>
            public string SetIDOBR
            {
                get
                {
                    return setIDOBRField;
                }
                set
                {
                    setIDOBRField = value;
                }
            }

            /// <remarks/>
            public string PlacerOrderNumber
            {
                get
                {
                    return placerOrderNumberField;
                }
                set
                {
                    placerOrderNumberField = value;
                }
            }

            /// <remarks/>
            public string FillerOrderNumber
            {
                get
                {
                    return fillerOrderNumberField;
                }
                set
                {
                    fillerOrderNumberField = value;
                }
            }

            /// <remarks/>
            public string UniversalServiceID
            {
                get
                {
                    return universalServiceIDField;
                }
                set
                {
                    universalServiceIDField = value;
                }
            }

            /// <remarks/>
            public string Priority
            {
                get
                {
                    return priorityField;
                }
                set
                {
                    priorityField = value;
                }
            }

            /// <remarks/>
            public string RequestedDatetime
            {
                get
                {
                    return requestedDatetimeField;
                }
                set
                {
                    requestedDatetimeField = value;
                }
            }

            /// <remarks/>
            public string ObservationDateTime
            {
                get
                {
                    return observationDateTimeField;
                }
                set
                {
                    observationDateTimeField = value;
                }
            }

            /// <remarks/>
            public string ObservationEndDateTime
            {
                get
                {
                    return observationEndDateTimeField;
                }
                set
                {
                    observationEndDateTimeField = value;
                }
            }

            /// <remarks/>
            public string CollectionVolume
            {
                get
                {
                    return collectionVolumeField;
                }
                set
                {
                    collectionVolumeField = value;
                }
            }

            /// <remarks/>
            public string CollectorIdentifier
            {
                get
                {
                    return collectorIdentifierField;
                }
                set
                {
                    collectorIdentifierField = value;
                }
            }

            /// <remarks/>
            public string SpecimenActionCode
            {
                get
                {
                    return specimenActionCodeField;
                }
                set
                {
                    specimenActionCodeField = value;
                }
            }

            /// <remarks/>
            public string DangerCode
            {
                get
                {
                    return dangerCodeField;
                }
                set
                {
                    dangerCodeField = value;
                }
            }

            /// <remarks/>
            public string RelevantClinicalInfo
            {
                get
                {
                    return relevantClinicalInfoField;
                }
                set
                {
                    relevantClinicalInfoField = value;
                }
            }

            /// <remarks/>
            public string SpecimenReceivedDateTime
            {
                get
                {
                    return specimenReceivedDateTimeField;
                }
                set
                {
                    specimenReceivedDateTimeField = value;
                }
            }

            /// <remarks/>
            public string SpecimenSource
            {
                get
                {
                    return specimenSourceField;
                }
                set
                {
                    specimenSourceField = value;
                }
            }

            /// <remarks/>
            public string OrderingProvider
            {
                get
                {
                    return orderingProviderField;
                }
                set
                {
                    orderingProviderField = value;
                }
            }

            /// <remarks/>
            public string OrderCallbackPhoneNumber
            {
                get
                {
                    return orderCallbackPhoneNumberField;
                }
                set
                {
                    orderCallbackPhoneNumberField = value;
                }
            }

            /// <remarks/>
            public string Placerfield1
            {
                get
                {
                    return placerfield1Field;
                }
                set
                {
                    placerfield1Field = value;
                }
            }

            /// <remarks/>
            public string Placerfield2
            {
                get
                {
                    return placerfield2Field;
                }
                set
                {
                    placerfield2Field = value;
                }
            }

            /// <remarks/>
            public string FillerField1
            {
                get
                {
                    return fillerField1Field;
                }
                set
                {
                    fillerField1Field = value;
                }
            }

            /// <remarks/>
            public string FillerField2
            {
                get
                {
                    return fillerField2Field;
                }
                set
                {
                    fillerField2Field = value;
                }
            }

            /// <remarks/>
            public string ResultsRptStatusChngDTime
            {
                get
                {
                    return resultsRptStatusChngDTimeField;
                }
                set
                {
                    resultsRptStatusChngDTimeField = value;
                }
            }

            /// <remarks/>
            public string ChargetoPractice
            {
                get
                {
                    return chargetoPracticeField;
                }
                set
                {
                    chargetoPracticeField = value;
                }
            }

            /// <remarks/>
            public string DiagnosticServSectID
            {
                get
                {
                    return diagnosticServSectIDField;
                }
                set
                {
                    diagnosticServSectIDField = value;
                }
            }

            /// <remarks/>
            public string ResultStatus
            {
                get
                {
                    return resultStatusField;
                }
                set
                {
                    resultStatusField = value;
                }
            }

            /// <remarks/>
            public string ParentResult
            {
                get
                {
                    return parentResultField;
                }
                set
                {
                    parentResultField = value;
                }
            }

            /// <remarks/>
            public string QuantityTiming
            {
                get
                {
                    return quantityTimingField;
                }
                set
                {
                    quantityTimingField = value;
                }
            }

            /// <remarks/>
            public string ResultCopiesTo
            {
                get
                {
                    return resultCopiesToField;
                }
                set
                {
                    resultCopiesToField = value;
                }
            }

            /// <remarks/>
            public string Parent
            {
                get
                {
                    return parentField;
                }
                set
                {
                    parentField = value;
                }
            }

            /// <remarks/>
            public string TransportationMode
            {
                get
                {
                    return transportationModeField;
                }
                set
                {
                    transportationModeField = value;
                }
            }

            /// <remarks/>
            public string ReasonforStudy
            {
                get
                {
                    return reasonforStudyField;
                }
                set
                {
                    reasonforStudyField = value;
                }
            }

            /// <remarks/>
            public string PrincipalResultInterpreter
            {
                get
                {
                    return principalResultInterpreterField;
                }
                set
                {
                    principalResultInterpreterField = value;
                }
            }

            /// <remarks/>
            public string AssistantResultInterpreter
            {
                get
                {
                    return assistantResultInterpreterField;
                }
                set
                {
                    assistantResultInterpreterField = value;
                }
            }

            /// <remarks/>
            public string Technician
            {
                get
                {
                    return technicianField;
                }
                set
                {
                    technicianField = value;
                }
            }

            /// <remarks/>
            public string Transcriptionist
            {
                get
                {
                    return transcriptionistField;
                }
                set
                {
                    transcriptionistField = value;
                }
            }

            /// <remarks/>
            public string ScheduledDateTime
            {
                get
                {
                    return scheduledDateTimeField;
                }
                set
                {
                    scheduledDateTimeField = value;
                }
            }

            /// <remarks/>
            public string NumberofSampleContainers
            {
                get
                {
                    return numberofSampleContainersField;
                }
                set
                {
                    numberofSampleContainersField = value;
                }
            }

            /// <remarks/>
            public string TransLogisticsofCSample
            {
                get
                {
                    return transLogisticsofCSampleField;
                }
                set
                {
                    transLogisticsofCSampleField = value;
                }
            }

            /// <remarks/>
            public string CollectorsComment
            {
                get
                {
                    return collectorsCommentField;
                }
                set
                {
                    collectorsCommentField = value;
                }
            }

            /// <remarks/>
            public string TransportArrResp
            {
                get
                {
                    return transportArrRespField;
                }
                set
                {
                    transportArrRespField = value;
                }
            }

            /// <remarks/>
            public string TransportArranged
            {
                get
                {
                    return transportArrangedField;
                }
                set
                {
                    transportArrangedField = value;
                }
            }

            /// <remarks/>
            public string EscortRequired
            {
                get
                {
                    return escortRequiredField;
                }
                set
                {
                    escortRequiredField = value;
                }
            }

            /// <remarks/>
            public string PatientTransportComment
            {
                get
                {
                    return patientTransportCommentField;
                }
                set
                {
                    patientTransportCommentField = value;
                }
            }

            /// <remarks/>
            public string ProcedureCode
            {
                get
                {
                    return procedureCodeField;
                }
                set
                {
                    procedureCodeField = value;
                }
            }

            /// <remarks/>
            public string ProcedureCodeModifier
            {
                get
                {
                    return procedureCodeModifierField;
                }
                set
                {
                    procedureCodeModifierField = value;
                }
            }

            /// <remarks/>
            public string PlacerSuppServiceInfo
            {
                get
                {
                    return placerSuppServiceInfoField;
                }
                set
                {
                    placerSuppServiceInfoField = value;
                }
            }

            /// <remarks/>
            public string FillerSuppServiceInfo
            {
                get
                {
                    return fillerSuppServiceInfoField;
                }
                set
                {
                    fillerSuppServiceInfoField = value;
                }
            }

            /// <remarks/>
            public string MedicNecessaryDupProcRea
            {
                get
                {
                    return medicNecessaryDupProcReaField;
                }
                set
                {
                    medicNecessaryDupProcReaField = value;
                }
            }

            /// <remarks/>
            public string ResultHandling
            {
                get
                {
                    return resultHandlingField;
                }
                set
                {
                    resultHandlingField = value;
                }
            }

            /// <remarks/>
            public DG1[] Dg1
            {
                get
                {
                    return dg1Field;
                }
                set
                {
                    dg1Field = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class DG1
        {

            private string setIDField;

            private string diagnosisCodingMethodField;

            private string diagnosisCodeField;

            private string diagnosisDescriptionField;

            private string diagnosisDateTimeField;

            private string diagnosisTypeField;

            private string majorDiagnosticCategoryField;

            private string diagnosticRelatedGroupField;

            private string dRGApprovalIndicatorField;

            private string dRGGrouperReviewCodeField;

            private string outlierTypeField;

            private string outlierDaysField;

            private string outlierCostField;

            private string grouperVersionAndTypeField;

            private string diagnosisPriorityField;

            private string diagnosingClinicianField;

            private string diagnosisClassificationField;

            private string confidentialIndicatorField;

            private string attestationDateTimeField;

            private string diagnosisIdentifierField;

            private string diagnosisActionCodeField;

            /// <remarks/>
            public string SetID
            {
                get
                {
                    return setIDField;
                }
                set
                {
                    setIDField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisCodingMethod
            {
                get
                {
                    return diagnosisCodingMethodField;
                }
                set
                {
                    diagnosisCodingMethodField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisCode
            {
                get
                {
                    return diagnosisCodeField;
                }
                set
                {
                    diagnosisCodeField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisDescription
            {
                get
                {
                    return diagnosisDescriptionField;
                }
                set
                {
                    diagnosisDescriptionField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisDateTime
            {
                get
                {
                    return diagnosisDateTimeField;
                }
                set
                {
                    diagnosisDateTimeField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisType
            {
                get
                {
                    return diagnosisTypeField;
                }
                set
                {
                    diagnosisTypeField = value;
                }
            }

            /// <remarks/>
            public string MajorDiagnosticCategory
            {
                get
                {
                    return majorDiagnosticCategoryField;
                }
                set
                {
                    majorDiagnosticCategoryField = value;
                }
            }

            /// <remarks/>
            public string DiagnosticRelatedGroup
            {
                get
                {
                    return diagnosticRelatedGroupField;
                }
                set
                {
                    diagnosticRelatedGroupField = value;
                }
            }

            /// <remarks/>
            public string DRGApprovalIndicator
            {
                get
                {
                    return dRGApprovalIndicatorField;
                }
                set
                {
                    dRGApprovalIndicatorField = value;
                }
            }

            /// <remarks/>
            public string DRGGrouperReviewCode
            {
                get
                {
                    return dRGGrouperReviewCodeField;
                }
                set
                {
                    dRGGrouperReviewCodeField = value;
                }
            }

            /// <remarks/>
            public string OutlierType
            {
                get
                {
                    return outlierTypeField;
                }
                set
                {
                    outlierTypeField = value;
                }
            }

            /// <remarks/>
            public string OutlierDays
            {
                get
                {
                    return outlierDaysField;
                }
                set
                {
                    outlierDaysField = value;
                }
            }

            /// <remarks/>
            public string OutlierCost
            {
                get
                {
                    return outlierCostField;
                }
                set
                {
                    outlierCostField = value;
                }
            }

            /// <remarks/>
            public string GrouperVersionAndType
            {
                get
                {
                    return grouperVersionAndTypeField;
                }
                set
                {
                    grouperVersionAndTypeField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisPriority
            {
                get
                {
                    return diagnosisPriorityField;
                }
                set
                {
                    diagnosisPriorityField = value;
                }
            }

            /// <remarks/>
            public string DiagnosingClinician
            {
                get
                {
                    return diagnosingClinicianField;
                }
                set
                {
                    diagnosingClinicianField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisClassification
            {
                get
                {
                    return diagnosisClassificationField;
                }
                set
                {
                    diagnosisClassificationField = value;
                }
            }

            /// <remarks/>
            public string ConfidentialIndicator
            {
                get
                {
                    return confidentialIndicatorField;
                }
                set
                {
                    confidentialIndicatorField = value;
                }
            }

            /// <remarks/>
            public string AttestationDateTime
            {
                get
                {
                    return attestationDateTimeField;
                }
                set
                {
                    attestationDateTimeField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisIdentifier
            {
                get
                {
                    return diagnosisIdentifierField;
                }
                set
                {
                    diagnosisIdentifierField = value;
                }
            }

            /// <remarks/>
            public string DiagnosisActionCode
            {
                get
                {
                    return diagnosisActionCodeField;
                }
                set
                {
                    diagnosisActionCodeField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ORC
        {

            private string orderControlField;

            private string placerOrderNumberField;

            private string fillerOrderNumberField;

            private string placerGroupNumberField;

            private string orderStatusField;

            private string responseFlagField;

            private string quantityTimingField;

            private string parentField;

            private string dateTimeofTransactionField;

            private string enteredByField;

            private string verifiedByField;

            private string orderingProviderField;

            private string enterersLocationField;

            private string callBackPhoneNumberField;

            private string orderEffectiveDateTimeField;

            private string orderControlCodeReasonField;

            private string enteringOrganizationField;

            private string enteringDeviceField;

            private string actionByField;

            private string advBenNoticeCodeField;

            private string orderFacilNameField;

            private string orderFacilAddrField;

            private string orderFacilTelField;

            private string orderProvAddrField;

            private string orderStatusModifyField;

            private string advBenNoticeOverrideField;

            private string fillerExpectAvailDTField;

            private string confidentialCodeField;

            private string orderTypeField;

            private string entererAuthModeField;

            private string parentUniServiceIDField;

            /// <remarks/>
            public string OrderControl
            {
                get
                {
                    return orderControlField;
                }
                set
                {
                    orderControlField = value;
                }
            }

            /// <remarks/>
            public string PlacerOrderNumber
            {
                get
                {
                    return placerOrderNumberField;
                }
                set
                {
                    placerOrderNumberField = value;
                }
            }

            /// <remarks/>
            public string FillerOrderNumber
            {
                get
                {
                    return fillerOrderNumberField;
                }
                set
                {
                    fillerOrderNumberField = value;
                }
            }

            /// <remarks/>
            public string PlacerGroupNumber
            {
                get
                {
                    return placerGroupNumberField;
                }
                set
                {
                    placerGroupNumberField = value;
                }
            }

            /// <remarks/>
            public string OrderStatus
            {
                get
                {
                    return orderStatusField;
                }
                set
                {
                    orderStatusField = value;
                }
            }

            /// <remarks/>
            public string ResponseFlag
            {
                get
                {
                    return responseFlagField;
                }
                set
                {
                    responseFlagField = value;
                }
            }

            /// <remarks/>
            public string QuantityTiming
            {
                get
                {
                    return quantityTimingField;
                }
                set
                {
                    quantityTimingField = value;
                }
            }

            /// <remarks/>
            public string Parent
            {
                get
                {
                    return parentField;
                }
                set
                {
                    parentField = value;
                }
            }

            /// <remarks/>
            public string DateTimeofTransaction
            {
                get
                {
                    return dateTimeofTransactionField;
                }
                set
                {
                    dateTimeofTransactionField = value;
                }
            }

            /// <remarks/>
            public string EnteredBy
            {
                get
                {
                    return enteredByField;
                }
                set
                {
                    enteredByField = value;
                }
            }

            /// <remarks/>
            public string VerifiedBy
            {
                get
                {
                    return verifiedByField;
                }
                set
                {
                    verifiedByField = value;
                }
            }

            /// <remarks/>
            public string OrderingProvider
            {
                get
                {
                    return orderingProviderField;
                }
                set
                {
                    orderingProviderField = value;
                }
            }

            /// <remarks/>
            public string EnterersLocation
            {
                get
                {
                    return enterersLocationField;
                }
                set
                {
                    enterersLocationField = value;
                }
            }

            /// <remarks/>
            public string CallBackPhoneNumber
            {
                get
                {
                    return callBackPhoneNumberField;
                }
                set
                {
                    callBackPhoneNumberField = value;
                }
            }

            /// <remarks/>
            public string OrderEffectiveDateTime
            {
                get
                {
                    return orderEffectiveDateTimeField;
                }
                set
                {
                    orderEffectiveDateTimeField = value;
                }
            }

            /// <remarks/>
            public string OrderControlCodeReason
            {
                get
                {
                    return orderControlCodeReasonField;
                }
                set
                {
                    orderControlCodeReasonField = value;
                }
            }

            /// <remarks/>
            public string EnteringOrganization
            {
                get
                {
                    return enteringOrganizationField;
                }
                set
                {
                    enteringOrganizationField = value;
                }
            }

            /// <remarks/>
            public string EnteringDevice
            {
                get
                {
                    return enteringDeviceField;
                }
                set
                {
                    enteringDeviceField = value;
                }
            }

            /// <remarks/>
            public string ActionBy
            {
                get
                {
                    return actionByField;
                }
                set
                {
                    actionByField = value;
                }
            }

            /// <remarks/>
            public string AdvBenNoticeCode
            {
                get
                {
                    return advBenNoticeCodeField;
                }
                set
                {
                    advBenNoticeCodeField = value;
                }
            }

            /// <remarks/>
            public string OrderFacilName
            {
                get
                {
                    return orderFacilNameField;
                }
                set
                {
                    orderFacilNameField = value;
                }
            }

            /// <remarks/>
            public string OrderFacilAddr
            {
                get
                {
                    return orderFacilAddrField;
                }
                set
                {
                    orderFacilAddrField = value;
                }
            }

            /// <remarks/>
            public string OrderFacilTel
            {
                get
                {
                    return orderFacilTelField;
                }
                set
                {
                    orderFacilTelField = value;
                }
            }

            /// <remarks/>
            public string OrderProvAddr
            {
                get
                {
                    return orderProvAddrField;
                }
                set
                {
                    orderProvAddrField = value;
                }
            }

            /// <remarks/>
            public string OrderStatusModify
            {
                get
                {
                    return orderStatusModifyField;
                }
                set
                {
                    orderStatusModifyField = value;
                }
            }

            /// <remarks/>
            public string AdvBenNoticeOverride
            {
                get
                {
                    return advBenNoticeOverrideField;
                }
                set
                {
                    advBenNoticeOverrideField = value;
                }
            }

            /// <remarks/>
            public string FillerExpectAvailDT
            {
                get
                {
                    return fillerExpectAvailDTField;
                }
                set
                {
                    fillerExpectAvailDTField = value;
                }
            }

            /// <remarks/>
            public string ConfidentialCode
            {
                get
                {
                    return confidentialCodeField;
                }
                set
                {
                    confidentialCodeField = value;
                }
            }

            /// <remarks/>
            public string OrderType
            {
                get
                {
                    return orderTypeField;
                }
                set
                {
                    orderTypeField = value;
                }
            }

            /// <remarks/>
            public string EntererAuthMode
            {
                get
                {
                    return entererAuthModeField;
                }
                set
                {
                    entererAuthModeField = value;
                }
            }

            /// <remarks/>
            public string ParentUniServiceID
            {
                get
                {
                    return parentUniServiceIDField;
                }
                set
                {
                    parentUniServiceIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class TQ1
        {

            private string setIDTQ1Field;

            private string quantityField;

            private string repeatPatternField;

            private string explicitTimeField;

            private string relativeTimeUnitField;

            private string serviceDurationField;

            private string startDateField;

            private string endDateField;

            private string priorityField;

            private string conditionTextField;

            private string textInstructionField;

            private string conjuctionField;

            private string occurrenceDurationField;

            private string totalOccurrenceField;

            /// <remarks/>
            public string SetIDTQ1
            {
                get
                {
                    return setIDTQ1Field;
                }
                set
                {
                    setIDTQ1Field = value;
                }
            }

            /// <remarks/>
            public string Quantity
            {
                get
                {
                    return quantityField;
                }
                set
                {
                    quantityField = value;
                }
            }

            /// <remarks/>
            public string RepeatPattern
            {
                get
                {
                    return repeatPatternField;
                }
                set
                {
                    repeatPatternField = value;
                }
            }

            /// <remarks/>
            public string ExplicitTime
            {
                get
                {
                    return explicitTimeField;
                }
                set
                {
                    explicitTimeField = value;
                }
            }

            /// <remarks/>
            public string RelativeTimeUnit
            {
                get
                {
                    return relativeTimeUnitField;
                }
                set
                {
                    relativeTimeUnitField = value;
                }
            }

            /// <remarks/>
            public string ServiceDuration
            {
                get
                {
                    return serviceDurationField;
                }
                set
                {
                    serviceDurationField = value;
                }
            }

            /// <remarks/>
            public string StartDate
            {
                get
                {
                    return startDateField;
                }
                set
                {
                    startDateField = value;
                }
            }

            /// <remarks/>
            public string EndDate
            {
                get
                {
                    return endDateField;
                }
                set
                {
                    endDateField = value;
                }
            }

            /// <remarks/>
            public string Priority
            {
                get
                {
                    return priorityField;
                }
                set
                {
                    priorityField = value;
                }
            }

            /// <remarks/>
            public string ConditionText
            {
                get
                {
                    return conditionTextField;
                }
                set
                {
                    conditionTextField = value;
                }
            }

            /// <remarks/>
            public string TextInstruction
            {
                get
                {
                    return textInstructionField;
                }
                set
                {
                    textInstructionField = value;
                }
            }

            /// <remarks/>
            public string Conjuction
            {
                get
                {
                    return conjuctionField;
                }
                set
                {
                    conjuctionField = value;
                }
            }

            /// <remarks/>
            public string OccurrenceDuration
            {
                get
                {
                    return occurrenceDurationField;
                }
                set
                {
                    occurrenceDurationField = value;
                }
            }

            /// <remarks/>
            public string TotalOccurrence
            {
                get
                {
                    return totalOccurrenceField;
                }
                set
                {
                    totalOccurrenceField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OBX
        {

            private string setIDOBXField;

            private string valueTypeField;

            private string observationIDField;

            private string observationSubIDField;

            private string observationValueField;

            private string unitsField;

            private string referencesRangeField;

            private string abnormalFlagsField;

            private string probabilityField;

            private string natureOfAbnormalTestField;

            private string observResultStatusField;

            private string effectDateOfReferenceField;

            private string userDefinedAccessCheckField;

            private string dateOfObservationField;

            private string producersIDField;

            private string responsibleObserverField;

            private string observationMethodField;

            private string equipmentInstanceIDField;

            private string dateOfAnalysisField;

            /// <remarks/>
            public string SetIDOBX
            {
                get
                {
                    return setIDOBXField;
                }
                set
                {
                    setIDOBXField = value;
                }
            }

            /// <remarks/>
            public string ValueType
            {
                get
                {
                    return valueTypeField;
                }
                set
                {
                    valueTypeField = value;
                }
            }

            /// <remarks/>
            public string ObservationID
            {
                get
                {
                    return observationIDField;
                }
                set
                {
                    observationIDField = value;
                }
            }

            /// <remarks/>
            public string ObservationSubID
            {
                get
                {
                    return observationSubIDField;
                }
                set
                {
                    observationSubIDField = value;
                }
            }

            /// <remarks/>
            public string ObservationValue
            {
                get
                {
                    return observationValueField;
                }
                set
                {
                    observationValueField = value;
                }
            }

            /// <remarks/>
            public string Units
            {
                get
                {
                    return unitsField;
                }
                set
                {
                    unitsField = value;
                }
            }

            /// <remarks/>
            public string ReferencesRange
            {
                get
                {
                    return referencesRangeField;
                }
                set
                {
                    referencesRangeField = value;
                }
            }

            /// <remarks/>
            public string AbnormalFlags
            {
                get
                {
                    return abnormalFlagsField;
                }
                set
                {
                    abnormalFlagsField = value;
                }
            }

            /// <remarks/>
            public string Probability
            {
                get
                {
                    return probabilityField;
                }
                set
                {
                    probabilityField = value;
                }
            }

            /// <remarks/>
            public string NatureOfAbnormalTest
            {
                get
                {
                    return natureOfAbnormalTestField;
                }
                set
                {
                    natureOfAbnormalTestField = value;
                }
            }

            /// <remarks/>
            public string ObservResultStatus
            {
                get
                {
                    return observResultStatusField;
                }
                set
                {
                    observResultStatusField = value;
                }
            }

            /// <remarks/>
            public string EffectDateOfReference
            {
                get
                {
                    return effectDateOfReferenceField;
                }
                set
                {
                    effectDateOfReferenceField = value;
                }
            }

            /// <remarks/>
            public string UserDefinedAccessCheck
            {
                get
                {
                    return userDefinedAccessCheckField;
                }
                set
                {
                    userDefinedAccessCheckField = value;
                }
            }

            /// <remarks/>
            public string DateOfObservation
            {
                get
                {
                    return dateOfObservationField;
                }
                set
                {
                    dateOfObservationField = value;
                }
            }

            /// <remarks/>
            public string ProducersID
            {
                get
                {
                    return producersIDField;
                }
                set
                {
                    producersIDField = value;
                }
            }

            /// <remarks/>
            public string ResponsibleObserver
            {
                get
                {
                    return responsibleObserverField;
                }
                set
                {
                    responsibleObserverField = value;
                }
            }

            /// <remarks/>
            public string ObservationMethod
            {
                get
                {
                    return observationMethodField;
                }
                set
                {
                    observationMethodField = value;
                }
            }

            /// <remarks/>
            public string EquipmentInstanceID
            {
                get
                {
                    return equipmentInstanceIDField;
                }
                set
                {
                    equipmentInstanceIDField = value;
                }
            }

            /// <remarks/>
            public string DateOfAnalysis
            {
                get
                {
                    return dateOfAnalysisField;
                }
                set
                {
                    dateOfAnalysisField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OUL22Specimen
        {

            private Specimen specimenField;

            private OULOrder[] oULOrderArrField;

            /// <remarks/>
            public Specimen Specimen
            {
                get
                {
                    return specimenField;
                }
                set
                {
                    specimenField = value;
                }
            }

            /// <remarks/>
            public OULOrder[] OULOrderArr
            {
                get
                {
                    return oULOrderArrField;
                }
                set
                {
                    oULOrderArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Specimen
        {

            private SPM spmField;

            private SAC[] sacField;

            /// <remarks/>
            public SPM Spm
            {
                get
                {
                    return spmField;
                }
                set
                {
                    spmField = value;
                }
            }

            /// <remarks/>
            public SAC[] Sac
            {
                get
                {
                    return sacField;
                }
                set
                {
                    sacField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class SPM
        {

            private string setIDSPMField;

            private string specimenIDField;

            private string specimenParentIDField;

            private string specimenTypeField;

            private string specimenTypeModField;

            private string specimenAdditivesField;

            private string specimenCollectMethodField;

            private string specimenSourceSiteField;

            private string specimenSourceSiteModField;

            private string specimenCollectSiteField;

            private string specimenRoleField;

            private string specimenCollectAmountField;

            private string groupedSpecimenCountField;

            private string specimenDescField;

            private string specimenHandlingCodeField;

            private string specimenRiskCodeField;

            private string specimenCollectDTField;

            private string specimenReceiveDTField;

            private string specimenExpireDTField;

            private string specimenAvailabilityField;

            private string specimenRejectReasonField;

            private string specimenQualityField;

            private string specimenAppropriateField;

            private string specimenConditionField;

            private string specimenCurrentQuantityField;

            private string numberOfSpecimenContainersField;

            private string containerTypeField;

            private string containerConditionField;

            private string specimenChildRoleField;

            /// <remarks/>
            public string SetIDSPM
            {
                get
                {
                    return setIDSPMField;
                }
                set
                {
                    setIDSPMField = value;
                }
            }

            /// <remarks/>
            public string SpecimenID
            {
                get
                {
                    return specimenIDField;
                }
                set
                {
                    specimenIDField = value;
                }
            }

            /// <remarks/>
            public string SpecimenParentID
            {
                get
                {
                    return specimenParentIDField;
                }
                set
                {
                    specimenParentIDField = value;
                }
            }

            /// <remarks/>
            public string SpecimenType
            {
                get
                {
                    return specimenTypeField;
                }
                set
                {
                    specimenTypeField = value;
                }
            }

            /// <remarks/>
            public string SpecimenTypeMod
            {
                get
                {
                    return specimenTypeModField;
                }
                set
                {
                    specimenTypeModField = value;
                }
            }

            /// <remarks/>
            public string SpecimenAdditives
            {
                get
                {
                    return specimenAdditivesField;
                }
                set
                {
                    specimenAdditivesField = value;
                }
            }

            /// <remarks/>
            public string SpecimenCollectMethod
            {
                get
                {
                    return specimenCollectMethodField;
                }
                set
                {
                    specimenCollectMethodField = value;
                }
            }

            /// <remarks/>
            public string SpecimenSourceSite
            {
                get
                {
                    return specimenSourceSiteField;
                }
                set
                {
                    specimenSourceSiteField = value;
                }
            }

            /// <remarks/>
            public string SpecimenSourceSiteMod
            {
                get
                {
                    return specimenSourceSiteModField;
                }
                set
                {
                    specimenSourceSiteModField = value;
                }
            }

            /// <remarks/>
            public string SpecimenCollectSite
            {
                get
                {
                    return specimenCollectSiteField;
                }
                set
                {
                    specimenCollectSiteField = value;
                }
            }

            /// <remarks/>
            public string SpecimenRole
            {
                get
                {
                    return specimenRoleField;
                }
                set
                {
                    specimenRoleField = value;
                }
            }

            /// <remarks/>
            public string SpecimenCollectAmount
            {
                get
                {
                    return specimenCollectAmountField;
                }
                set
                {
                    specimenCollectAmountField = value;
                }
            }

            /// <remarks/>
            public string GroupedSpecimenCount
            {
                get
                {
                    return groupedSpecimenCountField;
                }
                set
                {
                    groupedSpecimenCountField = value;
                }
            }

            /// <remarks/>
            public string SpecimenDesc
            {
                get
                {
                    return specimenDescField;
                }
                set
                {
                    specimenDescField = value;
                }
            }

            /// <remarks/>
            public string SpecimenHandlingCode
            {
                get
                {
                    return specimenHandlingCodeField;
                }
                set
                {
                    specimenHandlingCodeField = value;
                }
            }

            /// <remarks/>
            public string SpecimenRiskCode
            {
                get
                {
                    return specimenRiskCodeField;
                }
                set
                {
                    specimenRiskCodeField = value;
                }
            }

            /// <remarks/>
            public string SpecimenCollectDT
            {
                get
                {
                    return specimenCollectDTField;
                }
                set
                {
                    specimenCollectDTField = value;
                }
            }

            /// <remarks/>
            public string SpecimenReceiveDT
            {
                get
                {
                    return specimenReceiveDTField;
                }
                set
                {
                    specimenReceiveDTField = value;
                }
            }

            /// <remarks/>
            public string SpecimenExpireDT
            {
                get
                {
                    return specimenExpireDTField;
                }
                set
                {
                    specimenExpireDTField = value;
                }
            }

            /// <remarks/>
            public string SpecimenAvailability
            {
                get
                {
                    return specimenAvailabilityField;
                }
                set
                {
                    specimenAvailabilityField = value;
                }
            }

            /// <remarks/>
            public string SpecimenRejectReason
            {
                get
                {
                    return specimenRejectReasonField;
                }
                set
                {
                    specimenRejectReasonField = value;
                }
            }

            /// <remarks/>
            public string SpecimenQuality
            {
                get
                {
                    return specimenQualityField;
                }
                set
                {
                    specimenQualityField = value;
                }
            }

            /// <remarks/>
            public string SpecimenAppropriate
            {
                get
                {
                    return specimenAppropriateField;
                }
                set
                {
                    specimenAppropriateField = value;
                }
            }

            /// <remarks/>
            public string SpecimenCondition
            {
                get
                {
                    return specimenConditionField;
                }
                set
                {
                    specimenConditionField = value;
                }
            }

            /// <remarks/>
            public string SpecimenCurrentQuantity
            {
                get
                {
                    return specimenCurrentQuantityField;
                }
                set
                {
                    specimenCurrentQuantityField = value;
                }
            }

            /// <remarks/>
            public string NumberOfSpecimenContainers
            {
                get
                {
                    return numberOfSpecimenContainersField;
                }
                set
                {
                    numberOfSpecimenContainersField = value;
                }
            }

            /// <remarks/>
            public string ContainerType
            {
                get
                {
                    return containerTypeField;
                }
                set
                {
                    containerTypeField = value;
                }
            }

            /// <remarks/>
            public string ContainerCondition
            {
                get
                {
                    return containerConditionField;
                }
                set
                {
                    containerConditionField = value;
                }
            }

            /// <remarks/>
            public string SpecimenChildRole
            {
                get
                {
                    return specimenChildRoleField;
                }
                set
                {
                    specimenChildRoleField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class SAC
        {

            private string externalAccessionIDField;

            private string accessionIDField;

            private string containerIDField;

            private string primaryContainerIDField;

            private string equipContainerIDField;

            private string specimenSourceField;

            private string registerDateField;

            private string containerStatusField;

            private string carrierTypeField;

            private string carrierIDField;

            private string positionInCarrierField;

            private string trayTypeField;

            private string trayIDField;

            private string positionInTrayField;

            private string locationField;

            private string containerHeightField;

            private string containerDiameterField;

            private string barrierDeltaField;

            private string bottomDeltaField;

            private string containerHeigDiaDeltaField;

            private string containerVolumeField;

            private string availableSpecimenVolField;

            private string initialSpecimenVolField;

            private string volumeUnitsField;

            private string seperatorTypeField;

            private string capTypeField;

            private string additiveField;

            private string specimenComponentField;

            private string dilutionFactorField;

            private string treatmentField;

            private string temperatureField;

            private string hemolysisIndexField;

            private string hemolysisIndexUnitsField;

            private string lipemiaIndexField;

            private string lipemiaIndexUnitsField;

            private string icterusIndexField;

            private string icterusIndexUnitsField;

            private string fibrinIndexField;

            private string fibrinIndexUnitsField;

            private string systemIndContaminantField;

            private string drugInterferenceField;

            private string artificialBloodField;

            private string specialHandlingCodeField;

            private string otherEnvFactorField;

            /// <remarks/>
            public string ExternalAccessionID
            {
                get
                {
                    return externalAccessionIDField;
                }
                set
                {
                    externalAccessionIDField = value;
                }
            }

            /// <remarks/>
            public string AccessionID
            {
                get
                {
                    return accessionIDField;
                }
                set
                {
                    accessionIDField = value;
                }
            }

            /// <remarks/>
            public string ContainerID
            {
                get
                {
                    return containerIDField;
                }
                set
                {
                    containerIDField = value;
                }
            }

            /// <remarks/>
            public string PrimaryContainerID
            {
                get
                {
                    return primaryContainerIDField;
                }
                set
                {
                    primaryContainerIDField = value;
                }
            }

            /// <remarks/>
            public string EquipContainerID
            {
                get
                {
                    return equipContainerIDField;
                }
                set
                {
                    equipContainerIDField = value;
                }
            }

            /// <remarks/>
            public string SpecimenSource
            {
                get
                {
                    return specimenSourceField;
                }
                set
                {
                    specimenSourceField = value;
                }
            }

            /// <remarks/>
            public string RegisterDate
            {
                get
                {
                    return registerDateField;
                }
                set
                {
                    registerDateField = value;
                }
            }

            /// <remarks/>
            public string ContainerStatus
            {
                get
                {
                    return containerStatusField;
                }
                set
                {
                    containerStatusField = value;
                }
            }

            /// <remarks/>
            public string CarrierType
            {
                get
                {
                    return carrierTypeField;
                }
                set
                {
                    carrierTypeField = value;
                }
            }

            /// <remarks/>
            public string CarrierID
            {
                get
                {
                    return carrierIDField;
                }
                set
                {
                    carrierIDField = value;
                }
            }

            /// <remarks/>
            public string PositionInCarrier
            {
                get
                {
                    return positionInCarrierField;
                }
                set
                {
                    positionInCarrierField = value;
                }
            }

            /// <remarks/>
            public string TrayType
            {
                get
                {
                    return trayTypeField;
                }
                set
                {
                    trayTypeField = value;
                }
            }

            /// <remarks/>
            public string TrayID
            {
                get
                {
                    return trayIDField;
                }
                set
                {
                    trayIDField = value;
                }
            }

            /// <remarks/>
            public string PositionInTray
            {
                get
                {
                    return positionInTrayField;
                }
                set
                {
                    positionInTrayField = value;
                }
            }

            /// <remarks/>
            public string Location
            {
                get
                {
                    return locationField;
                }
                set
                {
                    locationField = value;
                }
            }

            /// <remarks/>
            public string ContainerHeight
            {
                get
                {
                    return containerHeightField;
                }
                set
                {
                    containerHeightField = value;
                }
            }

            /// <remarks/>
            public string ContainerDiameter
            {
                get
                {
                    return containerDiameterField;
                }
                set
                {
                    containerDiameterField = value;
                }
            }

            /// <remarks/>
            public string BarrierDelta
            {
                get
                {
                    return barrierDeltaField;
                }
                set
                {
                    barrierDeltaField = value;
                }
            }

            /// <remarks/>
            public string BottomDelta
            {
                get
                {
                    return bottomDeltaField;
                }
                set
                {
                    bottomDeltaField = value;
                }
            }

            /// <remarks/>
            public string ContainerHeigDiaDelta
            {
                get
                {
                    return containerHeigDiaDeltaField;
                }
                set
                {
                    containerHeigDiaDeltaField = value;
                }
            }

            /// <remarks/>
            public string ContainerVolume
            {
                get
                {
                    return containerVolumeField;
                }
                set
                {
                    containerVolumeField = value;
                }
            }

            /// <remarks/>
            public string AvailableSpecimenVol
            {
                get
                {
                    return availableSpecimenVolField;
                }
                set
                {
                    availableSpecimenVolField = value;
                }
            }

            /// <remarks/>
            public string InitialSpecimenVol
            {
                get
                {
                    return initialSpecimenVolField;
                }
                set
                {
                    initialSpecimenVolField = value;
                }
            }

            /// <remarks/>
            public string VolumeUnits
            {
                get
                {
                    return volumeUnitsField;
                }
                set
                {
                    volumeUnitsField = value;
                }
            }

            /// <remarks/>
            public string SeperatorType
            {
                get
                {
                    return seperatorTypeField;
                }
                set
                {
                    seperatorTypeField = value;
                }
            }

            /// <remarks/>
            public string CapType
            {
                get
                {
                    return capTypeField;
                }
                set
                {
                    capTypeField = value;
                }
            }

            /// <remarks/>
            public string Additive
            {
                get
                {
                    return additiveField;
                }
                set
                {
                    additiveField = value;
                }
            }

            /// <remarks/>
            public string SpecimenComponent
            {
                get
                {
                    return specimenComponentField;
                }
                set
                {
                    specimenComponentField = value;
                }
            }

            /// <remarks/>
            public string DilutionFactor
            {
                get
                {
                    return dilutionFactorField;
                }
                set
                {
                    dilutionFactorField = value;
                }
            }

            /// <remarks/>
            public string Treatment
            {
                get
                {
                    return treatmentField;
                }
                set
                {
                    treatmentField = value;
                }
            }

            /// <remarks/>
            public string Temperature
            {
                get
                {
                    return temperatureField;
                }
                set
                {
                    temperatureField = value;
                }
            }

            /// <remarks/>
            public string HemolysisIndex
            {
                get
                {
                    return hemolysisIndexField;
                }
                set
                {
                    hemolysisIndexField = value;
                }
            }

            /// <remarks/>
            public string HemolysisIndexUnits
            {
                get
                {
                    return hemolysisIndexUnitsField;
                }
                set
                {
                    hemolysisIndexUnitsField = value;
                }
            }

            /// <remarks/>
            public string LipemiaIndex
            {
                get
                {
                    return lipemiaIndexField;
                }
                set
                {
                    lipemiaIndexField = value;
                }
            }

            /// <remarks/>
            public string LipemiaIndexUnits
            {
                get
                {
                    return lipemiaIndexUnitsField;
                }
                set
                {
                    lipemiaIndexUnitsField = value;
                }
            }

            /// <remarks/>
            public string IcterusIndex
            {
                get
                {
                    return icterusIndexField;
                }
                set
                {
                    icterusIndexField = value;
                }
            }

            /// <remarks/>
            public string IcterusIndexUnits
            {
                get
                {
                    return icterusIndexUnitsField;
                }
                set
                {
                    icterusIndexUnitsField = value;
                }
            }

            /// <remarks/>
            public string FibrinIndex
            {
                get
                {
                    return fibrinIndexField;
                }
                set
                {
                    fibrinIndexField = value;
                }
            }

            /// <remarks/>
            public string FibrinIndexUnits
            {
                get
                {
                    return fibrinIndexUnitsField;
                }
                set
                {
                    fibrinIndexUnitsField = value;
                }
            }

            /// <remarks/>
            public string SystemIndContaminant
            {
                get
                {
                    return systemIndContaminantField;
                }
                set
                {
                    systemIndContaminantField = value;
                }
            }

            /// <remarks/>
            public string DrugInterference
            {
                get
                {
                    return drugInterferenceField;
                }
                set
                {
                    drugInterferenceField = value;
                }
            }

            /// <remarks/>
            public string ArtificialBlood
            {
                get
                {
                    return artificialBloodField;
                }
                set
                {
                    artificialBloodField = value;
                }
            }

            /// <remarks/>
            public string SpecialHandlingCode
            {
                get
                {
                    return specialHandlingCodeField;
                }
                set
                {
                    specialHandlingCodeField = value;
                }
            }

            /// <remarks/>
            public string OtherEnvFactor
            {
                get
                {
                    return otherEnvFactorField;
                }
                set
                {
                    otherEnvFactorField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OUL22
        {

            private MSH mshField;

            private Patient patientField;

            private OUL22Specimen[] oUL22SpecimenArrField;

            /// <remarks/>
            public MSH Msh
            {
                get
                {
                    return mshField;
                }
                set
                {
                    mshField = value;
                }
            }

            /// <remarks/>
            public Patient Patient
            {
                get
                {
                    return patientField;
                }
                set
                {
                    patientField = value;
                }
            }

            /// <remarks/>
            public OUL22Specimen[] OUL22SpecimenArr
            {
                get
                {
                    return oUL22SpecimenArrField;
                }
                set
                {
                    oUL22SpecimenArrField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Patient
        {

            private PID pidField;

            private PV1 pv1Field;

            /// <remarks/>
            public PID Pid
            {
                get
                {
                    return pidField;
                }
                set
                {
                    pidField = value;
                }
            }

            /// <remarks/>
            public PV1 Pv1
            {
                get
                {
                    return pv1Field;
                }
                set
                {
                    pv1Field = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class PID
        {

            private string setIDPatientIDField;

            private string patientIDField;

            private string patientIdentifierListField;

            private string alternatePatientIDField;

            private string patientNameField;

            private string mothersMaidenNameField;

            private string dateTimeofBirthField;

            private string sexField;

            private string patientAliasField;

            private string raceField;

            private string patientAddressField;

            private string countyCodeField;

            private string phoneNumberHomeField;

            private string phoneNumberBusinessField;

            private string primaryLanguageField;

            private string maritalStatusField;

            private string religionField;

            private string patientAccountNumberField;

            private string sSNNumberPatientField;

            private string driversLicenseNumberField;

            private string mothersIdentifierField;

            private string ethnicGroupField;

            private string birthPlaceField;

            private string multipleBirthIndicatorField;

            private string birthOrderField;

            private string citizenshipField;

            private string veteransMilitaryStatusField;

            private string nationalityField;

            private string patientDeathDateandTimeField;

            private string patientDeathIndicatorField;

            private string iDUnknownIndicatorField;

            private string iDReliableCodeField;

            private string lastUpdateDTField;

            private string lastUpdateFacilityField;

            private string speciesCodeField;

            private string breedCodeField;

            private string strainField;

            private string productionClassCodeField;

            private string tribalCitizenshipField;

            /// <remarks/>
            public string SetIDPatientID
            {
                get
                {
                    return setIDPatientIDField;
                }
                set
                {
                    setIDPatientIDField = value;
                }
            }

            /// <remarks/>
            public string PatientID
            {
                get
                {
                    return patientIDField;
                }
                set
                {
                    patientIDField = value;
                }
            }

            /// <remarks/>
            public string PatientIdentifierList
            {
                get
                {
                    return patientIdentifierListField;
                }
                set
                {
                    patientIdentifierListField = value;
                }
            }

            /// <remarks/>
            public string AlternatePatientID
            {
                get
                {
                    return alternatePatientIDField;
                }
                set
                {
                    alternatePatientIDField = value;
                }
            }

            /// <remarks/>
            public string PatientName
            {
                get
                {
                    return patientNameField;
                }
                set
                {
                    patientNameField = value;
                }
            }

            /// <remarks/>
            public string MothersMaidenName
            {
                get
                {
                    return mothersMaidenNameField;
                }
                set
                {
                    mothersMaidenNameField = value;
                }
            }

            /// <remarks/>
            public string DateTimeofBirth
            {
                get
                {
                    return dateTimeofBirthField;
                }
                set
                {
                    dateTimeofBirthField = value;
                }
            }

            /// <remarks/>
            public string Sex
            {
                get
                {
                    return sexField;
                }
                set
                {
                    sexField = value;
                }
            }

            /// <remarks/>
            public string PatientAlias
            {
                get
                {
                    return patientAliasField;
                }
                set
                {
                    patientAliasField = value;
                }
            }

            /// <remarks/>
            public string Race
            {
                get
                {
                    return raceField;
                }
                set
                {
                    raceField = value;
                }
            }

            /// <remarks/>
            public string PatientAddress
            {
                get
                {
                    return patientAddressField;
                }
                set
                {
                    patientAddressField = value;
                }
            }

            /// <remarks/>
            public string CountyCode
            {
                get
                {
                    return countyCodeField;
                }
                set
                {
                    countyCodeField = value;
                }
            }

            /// <remarks/>
            public string PhoneNumberHome
            {
                get
                {
                    return phoneNumberHomeField;
                }
                set
                {
                    phoneNumberHomeField = value;
                }
            }

            /// <remarks/>
            public string PhoneNumberBusiness
            {
                get
                {
                    return phoneNumberBusinessField;
                }
                set
                {
                    phoneNumberBusinessField = value;
                }
            }

            /// <remarks/>
            public string PrimaryLanguage
            {
                get
                {
                    return primaryLanguageField;
                }
                set
                {
                    primaryLanguageField = value;
                }
            }

            /// <remarks/>
            public string MaritalStatus
            {
                get
                {
                    return maritalStatusField;
                }
                set
                {
                    maritalStatusField = value;
                }
            }

            /// <remarks/>
            public string Religion
            {
                get
                {
                    return religionField;
                }
                set
                {
                    religionField = value;
                }
            }

            /// <remarks/>
            public string PatientAccountNumber
            {
                get
                {
                    return patientAccountNumberField;
                }
                set
                {
                    patientAccountNumberField = value;
                }
            }

            /// <remarks/>
            public string SSNNumberPatient
            {
                get
                {
                    return sSNNumberPatientField;
                }
                set
                {
                    sSNNumberPatientField = value;
                }
            }

            /// <remarks/>
            public string DriversLicenseNumber
            {
                get
                {
                    return driversLicenseNumberField;
                }
                set
                {
                    driversLicenseNumberField = value;
                }
            }

            /// <remarks/>
            public string MothersIdentifier
            {
                get
                {
                    return mothersIdentifierField;
                }
                set
                {
                    mothersIdentifierField = value;
                }
            }

            /// <remarks/>
            public string EthnicGroup
            {
                get
                {
                    return ethnicGroupField;
                }
                set
                {
                    ethnicGroupField = value;
                }
            }

            /// <remarks/>
            public string BirthPlace
            {
                get
                {
                    return birthPlaceField;
                }
                set
                {
                    birthPlaceField = value;
                }
            }

            /// <remarks/>
            public string MultipleBirthIndicator
            {
                get
                {
                    return multipleBirthIndicatorField;
                }
                set
                {
                    multipleBirthIndicatorField = value;
                }
            }

            /// <remarks/>
            public string BirthOrder
            {
                get
                {
                    return birthOrderField;
                }
                set
                {
                    birthOrderField = value;
                }
            }

            /// <remarks/>
            public string Citizenship
            {
                get
                {
                    return citizenshipField;
                }
                set
                {
                    citizenshipField = value;
                }
            }

            /// <remarks/>
            public string VeteransMilitaryStatus
            {
                get
                {
                    return veteransMilitaryStatusField;
                }
                set
                {
                    veteransMilitaryStatusField = value;
                }
            }

            /// <remarks/>
            public string Nationality
            {
                get
                {
                    return nationalityField;
                }
                set
                {
                    nationalityField = value;
                }
            }

            /// <remarks/>
            public string PatientDeathDateandTime
            {
                get
                {
                    return patientDeathDateandTimeField;
                }
                set
                {
                    patientDeathDateandTimeField = value;
                }
            }

            /// <remarks/>
            public string PatientDeathIndicator
            {
                get
                {
                    return patientDeathIndicatorField;
                }
                set
                {
                    patientDeathIndicatorField = value;
                }
            }

            /// <remarks/>
            public string IDUnknownIndicator
            {
                get
                {
                    return iDUnknownIndicatorField;
                }
                set
                {
                    iDUnknownIndicatorField = value;
                }
            }

            /// <remarks/>
            public string IDReliableCode
            {
                get
                {
                    return iDReliableCodeField;
                }
                set
                {
                    iDReliableCodeField = value;
                }
            }

            /// <remarks/>
            public string LastUpdateDT
            {
                get
                {
                    return lastUpdateDTField;
                }
                set
                {
                    lastUpdateDTField = value;
                }
            }

            /// <remarks/>
            public string LastUpdateFacility
            {
                get
                {
                    return lastUpdateFacilityField;
                }
                set
                {
                    lastUpdateFacilityField = value;
                }
            }

            /// <remarks/>
            public string SpeciesCode
            {
                get
                {
                    return speciesCodeField;
                }
                set
                {
                    speciesCodeField = value;
                }
            }

            /// <remarks/>
            public string BreedCode
            {
                get
                {
                    return breedCodeField;
                }
                set
                {
                    breedCodeField = value;
                }
            }

            /// <remarks/>
            public string Strain
            {
                get
                {
                    return strainField;
                }
                set
                {
                    strainField = value;
                }
            }

            /// <remarks/>
            public string ProductionClassCode
            {
                get
                {
                    return productionClassCodeField;
                }
                set
                {
                    productionClassCodeField = value;
                }
            }

            /// <remarks/>
            public string TribalCitizenship
            {
                get
                {
                    return tribalCitizenshipField;
                }
                set
                {
                    tribalCitizenshipField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class PV1
        {

            private string setIDPV1Field;

            private string patientClassField;

            private string assignedPatientLocationField;

            private string admissionTypeField;

            private string preadmitNumberField;

            private string priorPatientLocationField;

            private string attendingDoctorField;

            private string referringDoctorField;

            private string consultingDoctorField;

            private string hospitalServiceField;

            private string temporaryLocationField;

            private string preadmitTestIndicatorField;

            private string readmissionIndicatorField;

            private string admitSourceField;

            private string ambulatoryStatusField;

            private string vIPIndicatorField;

            private string admittingDoctorField;

            private string patientTypeField;

            private string visitNumberField;

            private string financialClassField;

            private string chargePriceIndicatorField;

            private string courtesyCodeField;

            private string creditRatingField;

            private string contractCodeField;

            private string contractEffectiveDateField;

            private string contractAmountField;

            private string contractPeriodField;

            private string interestCodeField;

            private string transfertoBadDebtCodeField;

            private string transfertoBadDebtDateField;

            private string badDebtAgencyCodeField;

            private string badDebtTransferAmountField;

            private string badDebtRecoveryAmountField;

            private string deleteAccountIndicatorField;

            private string deleteAccountDateField;

            private string dischargeDispositionField;

            private string dischargedtoLocationField;

            private string dietTypeField;

            private string servicingFacilityField;

            private string bedStatusField;

            private string accountStatusField;

            private string pendingLocationField;

            private string priorTemporaryLocationField;

            private string admitDateTimeField;

            private string dischargeDateTimeField;

            private string currentPatientBalanceField;

            private string totalChargesField;

            private string totalAdjustmentsField;

            private string totalPaymentsField;

            private string alternateVisitIDField;

            private string visitIndicatorField;

            private string otherHealthcareProviderField;

            /// <remarks/>
            public string SetIDPV1
            {
                get
                {
                    return setIDPV1Field;
                }
                set
                {
                    setIDPV1Field = value;
                }
            }

            /// <remarks/>
            public string PatientClass
            {
                get
                {
                    return patientClassField;
                }
                set
                {
                    patientClassField = value;
                }
            }

            /// <remarks/>
            public string AssignedPatientLocation
            {
                get
                {
                    return assignedPatientLocationField;
                }
                set
                {
                    assignedPatientLocationField = value;
                }
            }

            /// <remarks/>
            public string AdmissionType
            {
                get
                {
                    return admissionTypeField;
                }
                set
                {
                    admissionTypeField = value;
                }
            }

            /// <remarks/>
            public string PreadmitNumber
            {
                get
                {
                    return preadmitNumberField;
                }
                set
                {
                    preadmitNumberField = value;
                }
            }

            /// <remarks/>
            public string PriorPatientLocation
            {
                get
                {
                    return priorPatientLocationField;
                }
                set
                {
                    priorPatientLocationField = value;
                }
            }

            /// <remarks/>
            public string AttendingDoctor
            {
                get
                {
                    return attendingDoctorField;
                }
                set
                {
                    attendingDoctorField = value;
                }
            }

            /// <remarks/>
            public string ReferringDoctor
            {
                get
                {
                    return referringDoctorField;
                }
                set
                {
                    referringDoctorField = value;
                }
            }

            /// <remarks/>
            public string ConsultingDoctor
            {
                get
                {
                    return consultingDoctorField;
                }
                set
                {
                    consultingDoctorField = value;
                }
            }

            /// <remarks/>
            public string HospitalService
            {
                get
                {
                    return hospitalServiceField;
                }
                set
                {
                    hospitalServiceField = value;
                }
            }

            /// <remarks/>
            public string TemporaryLocation
            {
                get
                {
                    return temporaryLocationField;
                }
                set
                {
                    temporaryLocationField = value;
                }
            }

            /// <remarks/>
            public string PreadmitTestIndicator
            {
                get
                {
                    return preadmitTestIndicatorField;
                }
                set
                {
                    preadmitTestIndicatorField = value;
                }
            }

            /// <remarks/>
            public string ReadmissionIndicator
            {
                get
                {
                    return readmissionIndicatorField;
                }
                set
                {
                    readmissionIndicatorField = value;
                }
            }

            /// <remarks/>
            public string AdmitSource
            {
                get
                {
                    return admitSourceField;
                }
                set
                {
                    admitSourceField = value;
                }
            }

            /// <remarks/>
            public string AmbulatoryStatus
            {
                get
                {
                    return ambulatoryStatusField;
                }
                set
                {
                    ambulatoryStatusField = value;
                }
            }

            /// <remarks/>
            public string VIPIndicator
            {
                get
                {
                    return vIPIndicatorField;
                }
                set
                {
                    vIPIndicatorField = value;
                }
            }

            /// <remarks/>
            public string AdmittingDoctor
            {
                get
                {
                    return admittingDoctorField;
                }
                set
                {
                    admittingDoctorField = value;
                }
            }

            /// <remarks/>
            public string PatientType
            {
                get
                {
                    return patientTypeField;
                }
                set
                {
                    patientTypeField = value;
                }
            }

            /// <remarks/>
            public string VisitNumber
            {
                get
                {
                    return visitNumberField;
                }
                set
                {
                    visitNumberField = value;
                }
            }

            /// <remarks/>
            public string FinancialClass
            {
                get
                {
                    return financialClassField;
                }
                set
                {
                    financialClassField = value;
                }
            }

            /// <remarks/>
            public string ChargePriceIndicator
            {
                get
                {
                    return chargePriceIndicatorField;
                }
                set
                {
                    chargePriceIndicatorField = value;
                }
            }

            /// <remarks/>
            public string CourtesyCode
            {
                get
                {
                    return courtesyCodeField;
                }
                set
                {
                    courtesyCodeField = value;
                }
            }

            /// <remarks/>
            public string CreditRating
            {
                get
                {
                    return creditRatingField;
                }
                set
                {
                    creditRatingField = value;
                }
            }

            /// <remarks/>
            public string ContractCode
            {
                get
                {
                    return contractCodeField;
                }
                set
                {
                    contractCodeField = value;
                }
            }

            /// <remarks/>
            public string ContractEffectiveDate
            {
                get
                {
                    return contractEffectiveDateField;
                }
                set
                {
                    contractEffectiveDateField = value;
                }
            }

            /// <remarks/>
            public string ContractAmount
            {
                get
                {
                    return contractAmountField;
                }
                set
                {
                    contractAmountField = value;
                }
            }

            /// <remarks/>
            public string ContractPeriod
            {
                get
                {
                    return contractPeriodField;
                }
                set
                {
                    contractPeriodField = value;
                }
            }

            /// <remarks/>
            public string InterestCode
            {
                get
                {
                    return interestCodeField;
                }
                set
                {
                    interestCodeField = value;
                }
            }

            /// <remarks/>
            public string TransfertoBadDebtCode
            {
                get
                {
                    return transfertoBadDebtCodeField;
                }
                set
                {
                    transfertoBadDebtCodeField = value;
                }
            }

            /// <remarks/>
            public string TransfertoBadDebtDate
            {
                get
                {
                    return transfertoBadDebtDateField;
                }
                set
                {
                    transfertoBadDebtDateField = value;
                }
            }

            /// <remarks/>
            public string BadDebtAgencyCode
            {
                get
                {
                    return badDebtAgencyCodeField;
                }
                set
                {
                    badDebtAgencyCodeField = value;
                }
            }

            /// <remarks/>
            public string BadDebtTransferAmount
            {
                get
                {
                    return badDebtTransferAmountField;
                }
                set
                {
                    badDebtTransferAmountField = value;
                }
            }

            /// <remarks/>
            public string BadDebtRecoveryAmount
            {
                get
                {
                    return badDebtRecoveryAmountField;
                }
                set
                {
                    badDebtRecoveryAmountField = value;
                }
            }

            /// <remarks/>
            public string DeleteAccountIndicator
            {
                get
                {
                    return deleteAccountIndicatorField;
                }
                set
                {
                    deleteAccountIndicatorField = value;
                }
            }

            /// <remarks/>
            public string DeleteAccountDate
            {
                get
                {
                    return deleteAccountDateField;
                }
                set
                {
                    deleteAccountDateField = value;
                }
            }

            /// <remarks/>
            public string DischargeDisposition
            {
                get
                {
                    return dischargeDispositionField;
                }
                set
                {
                    dischargeDispositionField = value;
                }
            }

            /// <remarks/>
            public string DischargedtoLocation
            {
                get
                {
                    return dischargedtoLocationField;
                }
                set
                {
                    dischargedtoLocationField = value;
                }
            }

            /// <remarks/>
            public string DietType
            {
                get
                {
                    return dietTypeField;
                }
                set
                {
                    dietTypeField = value;
                }
            }

            /// <remarks/>
            public string ServicingFacility
            {
                get
                {
                    return servicingFacilityField;
                }
                set
                {
                    servicingFacilityField = value;
                }
            }

            /// <remarks/>
            public string BedStatus
            {
                get
                {
                    return bedStatusField;
                }
                set
                {
                    bedStatusField = value;
                }
            }

            /// <remarks/>
            public string AccountStatus
            {
                get
                {
                    return accountStatusField;
                }
                set
                {
                    accountStatusField = value;
                }
            }

            /// <remarks/>
            public string PendingLocation
            {
                get
                {
                    return pendingLocationField;
                }
                set
                {
                    pendingLocationField = value;
                }
            }

            /// <remarks/>
            public string PriorTemporaryLocation
            {
                get
                {
                    return priorTemporaryLocationField;
                }
                set
                {
                    priorTemporaryLocationField = value;
                }
            }

            /// <remarks/>
            public string AdmitDateTime
            {
                get
                {
                    return admitDateTimeField;
                }
                set
                {
                    admitDateTimeField = value;
                }
            }

            /// <remarks/>
            public string DischargeDateTime
            {
                get
                {
                    return dischargeDateTimeField;
                }
                set
                {
                    dischargeDateTimeField = value;
                }
            }

            /// <remarks/>
            public string CurrentPatientBalance
            {
                get
                {
                    return currentPatientBalanceField;
                }
                set
                {
                    currentPatientBalanceField = value;
                }
            }

            /// <remarks/>
            public string TotalCharges
            {
                get
                {
                    return totalChargesField;
                }
                set
                {
                    totalChargesField = value;
                }
            }

            /// <remarks/>
            public string TotalAdjustments
            {
                get
                {
                    return totalAdjustmentsField;
                }
                set
                {
                    totalAdjustmentsField = value;
                }
            }

            /// <remarks/>
            public string TotalPayments
            {
                get
                {
                    return totalPaymentsField;
                }
                set
                {
                    totalPaymentsField = value;
                }
            }

            /// <remarks/>
            public string AlternateVisitID
            {
                get
                {
                    return alternateVisitIDField;
                }
                set
                {
                    alternateVisitIDField = value;
                }
            }

            /// <remarks/>
            public string VisitIndicator
            {
                get
                {
                    return visitIndicatorField;
                }
                set
                {
                    visitIndicatorField = value;
                }
            }

            /// <remarks/>
            public string OtherHealthcareProvider
            {
                get
                {
                    return otherHealthcareProviderField;
                }
                set
                {
                    otherHealthcareProviderField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class QAK
        {

            private string queryTagField;

            private string queryResponseStatusIDField;

            private string messageQueryNameField;

            private string hitCountField;

            private string thisPayloadField;

            private string hitsRemainingField;

            /// <remarks/>
            public string QueryTag
            {
                get
                {
                    return queryTagField;
                }
                set
                {
                    queryTagField = value;
                }
            }

            /// <remarks/>
            public string QueryResponseStatusID
            {
                get
                {
                    return queryResponseStatusIDField;
                }
                set
                {
                    queryResponseStatusIDField = value;
                }
            }

            /// <remarks/>
            public string MessageQueryName
            {
                get
                {
                    return messageQueryNameField;
                }
                set
                {
                    messageQueryNameField = value;
                }
            }

            /// <remarks/>
            public string HitCount
            {
                get
                {
                    return hitCountField;
                }
                set
                {
                    hitCountField = value;
                }
            }

            /// <remarks/>
            public string ThisPayload
            {
                get
                {
                    return thisPayloadField;
                }
                set
                {
                    thisPayloadField = value;
                }
            }

            /// <remarks/>
            public string HitsRemaining
            {
                get
                {
                    return hitsRemainingField;
                }
                set
                {
                    hitsRemainingField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class RSP11
        {

            private MSH mshField;

            private MSA msaField;

            private ERR errField;

            private QAK qakField;

            private QPD qpdField;

            private Patient patientField;

            private OML33Specimen[] oML33SpecimenField;

            /// <remarks/>
            public MSH Msh
            {
                get
                {
                    return mshField;
                }
                set
                {
                    mshField = value;
                }
            }

            /// <remarks/>
            public MSA Msa
            {
                get
                {
                    return msaField;
                }
                set
                {
                    msaField = value;
                }
            }

            /// <remarks/>
            public ERR Err
            {
                get
                {
                    return errField;
                }
                set
                {
                    errField = value;
                }
            }

            /// <remarks/>
            public QAK Qak
            {
                get
                {
                    return qakField;
                }
                set
                {
                    qakField = value;
                }
            }

            /// <remarks/>
            public QPD Qpd
            {
                get
                {
                    return qpdField;
                }
                set
                {
                    qpdField = value;
                }
            }

            /// <remarks/>
            public Patient Patient
            {
                get
                {
                    return patientField;
                }
                set
                {
                    patientField = value;
                }
            }

            /// <remarks/>
            public OML33Specimen[] OML33Specimen
            {
                get
                {
                    return oML33SpecimenField;
                }
                set
                {
                    oML33SpecimenField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class QPD
        {

            private string messageQueryNameField;

            private string queryTagField;

            private string patientIDField;

            private string patientVisitNumberField;

            private string placerGroupNumberField;

            private string placerOrderNumberField;

            private string fillerOrderNumberField;

            private string searchPeriodField;

            /// <remarks/>
            public string MessageQueryName
            {
                get
                {
                    return messageQueryNameField;
                }
                set
                {
                    messageQueryNameField = value;
                }
            }

            /// <remarks/>
            public string QueryTag
            {
                get
                {
                    return queryTagField;
                }
                set
                {
                    queryTagField = value;
                }
            }

            /// <remarks/>
            public string PatientID
            {
                get
                {
                    return patientIDField;
                }
                set
                {
                    patientIDField = value;
                }
            }

            /// <remarks/>
            public string PatientVisitNumber
            {
                get
                {
                    return patientVisitNumberField;
                }
                set
                {
                    patientVisitNumberField = value;
                }
            }

            /// <remarks/>
            public string PlacerGroupNumber
            {
                get
                {
                    return placerGroupNumberField;
                }
                set
                {
                    placerGroupNumberField = value;
                }
            }

            /// <remarks/>
            public string PlacerOrderNumber
            {
                get
                {
                    return placerOrderNumberField;
                }
                set
                {
                    placerOrderNumberField = value;
                }
            }

            /// <remarks/>
            public string FillerOrderNumber
            {
                get
                {
                    return fillerOrderNumberField;
                }
                set
                {
                    fillerOrderNumberField = value;
                }
            }

            /// <remarks/>
            public string SearchPeriod
            {
                get
                {
                    return searchPeriodField;
                }
                set
                {
                    searchPeriodField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OML33Specimen
        {

            private Specimen specimenField;

            private Order[] orderField;

            /// <remarks/>
            public Specimen Specimen
            {
                get
                {
                    return specimenField;
                }
                set
                {
                    specimenField = value;
                }
            }

            /// <remarks/>
            public Order[] Order
            {
                get
                {
                    return orderField;
                }
                set
                {
                    orderField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class Order
        {

            private ORC orcField;

            private TQ1 tq1Field;

            private OBR obrField;

            private OBX[] obxField;

            /// <remarks/>
            public ORC Orc
            {
                get
                {
                    return orcField;
                }
                set
                {
                    orcField = value;
                }
            }

            /// <remarks/>
            public TQ1 Tq1
            {
                get
                {
                    return tq1Field;
                }
                set
                {
                    tq1Field = value;
                }
            }

            /// <remarks/>
            public OBR Obr
            {
                get
                {
                    return obrField;
                }
                set
                {
                    obrField = value;
                }
            }

            /// <remarks/>
            public OBX[] Obx
            {
                get
                {
                    return obxField;
                }
                set
                {
                    obxField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class RCP
        {

            private string queryPriorityIDField;

            private string quantityLimitedRequestField;

            private string responseModalityField;

            private string executionDeliveryTimeField;

            private string modifyIndicatorIDField;

            private string sortByFieldField;

            private string segmentGroupInclusionIDField;

            /// <remarks/>
            public string QueryPriorityID
            {
                get
                {
                    return queryPriorityIDField;
                }
                set
                {
                    queryPriorityIDField = value;
                }
            }

            /// <remarks/>
            public string QuantityLimitedRequest
            {
                get
                {
                    return quantityLimitedRequestField;
                }
                set
                {
                    quantityLimitedRequestField = value;
                }
            }

            /// <remarks/>
            public string ResponseModality
            {
                get
                {
                    return responseModalityField;
                }
                set
                {
                    responseModalityField = value;
                }
            }

            /// <remarks/>
            public string ExecutionDeliveryTime
            {
                get
                {
                    return executionDeliveryTimeField;
                }
                set
                {
                    executionDeliveryTimeField = value;
                }
            }

            /// <remarks/>
            public string ModifyIndicatorID
            {
                get
                {
                    return modifyIndicatorIDField;
                }
                set
                {
                    modifyIndicatorIDField = value;
                }
            }

            /// <remarks/>
            public string SortByField
            {
                get
                {
                    return sortByFieldField;
                }
                set
                {
                    sortByFieldField = value;
                }
            }

            /// <remarks/>
            public string SegmentGroupInclusionID
            {
                get
                {
                    return segmentGroupInclusionIDField;
                }
                set
                {
                    segmentGroupInclusionIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class QBP11
        {

            private MSH mshField;

            private QPD qpdField;

            private RCP rcpField;

            /// <remarks/>
            public MSH Msh
            {
                get
                {
                    return mshField;
                }
                set
                {
                    mshField = value;
                }
            }

            /// <remarks/>
            public QPD Qpd
            {
                get
                {
                    return qpdField;
                }
                set
                {
                    qpdField = value;
                }
            }

            /// <remarks/>
            public RCP Rcp
            {
                get
                {
                    return rcpField;
                }
                set
                {
                    rcpField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class ORL34
        {

            private MSH mshField;

            private MSA msaField;

            private PID pidField;

            private ERR errField;

            private OML33Specimen[] oML33SpecimenField;

            /// <remarks/>
            public MSH Msh
            {
                get
                {
                    return mshField;
                }
                set
                {
                    mshField = value;
                }
            }

            /// <remarks/>
            public MSA Msa
            {
                get
                {
                    return msaField;
                }
                set
                {
                    msaField = value;
                }
            }

            /// <remarks/>
            public PID Pid
            {
                get
                {
                    return pidField;
                }
                set
                {
                    pidField = value;
                }
            }

            /// <remarks/>
            public ERR Err
            {
                get
                {
                    return errField;
                }
                set
                {
                    errField = value;
                }
            }

            /// <remarks/>
            public OML33Specimen[] OML33Specimen
            {
                get
                {
                    return oML33SpecimenField;
                }
                set
                {
                    oML33SpecimenField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1086.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
        public partial class OML33
        {

            private MSH mshField;

            private Patient patientField;

            private OML33Specimen[] oML33SpecimenArrField;

            /// <remarks/>
            public MSH Msh
            {
                get
                {
                    return mshField;
                }
                set
                {
                    mshField = value;
                }
            }

            /// <remarks/>
            public Patient Patient
            {
                get
                {
                    return patientField;
                }
                set
                {
                    patientField = value;
                }
            }

            /// <remarks/>
            public OML33Specimen[] OML33SpecimenArr
            {
                get
                {
                    return oML33SpecimenArrField;
                }
                set
                {
                    oML33SpecimenArrField = value;
                }
            }
        }

       


        #endregion
    }
}