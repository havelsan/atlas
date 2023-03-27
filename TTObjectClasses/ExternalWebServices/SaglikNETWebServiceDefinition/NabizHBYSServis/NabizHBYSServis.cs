
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
    public partial class NabizHBYSServis : TTObject
    {
        #region Methods
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class DoktorErisimTalep
        {

            private long hASTA_KIMLIK_NUMARASIField;

            private long hEKIM_KIMLIK_NUMARASIField;

            private string kURUM_KODUField;

            /// <remarks/>
            public long HASTA_KIMLIK_NUMARASI
            {
                get
                {
                    return hASTA_KIMLIK_NUMARASIField;
                }
                set
                {
                    hASTA_KIMLIK_NUMARASIField = value;
                }
            }

            /// <remarks/>
            public long HEKIM_KIMLIK_NUMARASI
            {
                get
                {
                    return hEKIM_KIMLIK_NUMARASIField;
                }
                set
                {
                    hEKIM_KIMLIK_NUMARASIField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string KURUM_KODU
            {
                get
                {
                    return kURUM_KODUField;
                }
                set
                {
                    kURUM_KODUField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HataliIslem
        {

            private System.DateTime bILDIRIM_TARIHIField;

            private bool bILDIRIM_TARIHIFieldSpecified;

            private string iSLEM_REFERANS_NOField;

            private string sYSTakipNoField;

            /// <remarks/>
            public System.DateTime BILDIRIM_TARIHI
            {
                get
                {
                    return bILDIRIM_TARIHIField;
                }
                set
                {
                    bILDIRIM_TARIHIField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool BILDIRIM_TARIHISpecified
            {
                get
                {
                    return bILDIRIM_TARIHIFieldSpecified;
                }
                set
                {
                    bILDIRIM_TARIHIFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string ISLEM_REFERANS_NO
            {
                get
                {
                    return iSLEM_REFERANS_NOField;
                }
                set
                {
                    iSLEM_REFERANS_NOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SYSTakipNo
            {
                get
                {
                    return sYSTakipNoField;
                }
                set
                {
                    sYSTakipNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HBYSHataliIslemSorgulaCevap
        {

            private HataliIslem[] hataliIslemlerField;

            private bool islemBasarisiField;

            private string servisMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(IsNullable = true)]
            public HataliIslem[] HataliIslemler
            {
                get
                {
                    return hataliIslemlerField;
                }
                set
                {
                    hataliIslemlerField = value;
                }
            }

            /// <remarks/>
            public bool IslemBasarisi
            {
                get
                {
                    return islemBasarisiField;
                }
                set
                {
                    islemBasarisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string ServisMesaji
            {
                get
                {
                    return servisMesajiField;
                }
                set
                {
                    servisMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HBYSHataliIslemSorgulaTalep
        {

            private string kURUM_KODUField;

            private System.DateTime sORGU_BASLANGIC_TARIHIField;

            private System.DateTime sORGU_BITIS_TARIHIField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string KURUM_KODU
            {
                get
                {
                    return kURUM_KODUField;
                }
                set
                {
                    kURUM_KODUField = value;
                }
            }

            /// <remarks/>
            public System.DateTime SORGU_BASLANGIC_TARIHI
            {
                get
                {
                    return sORGU_BASLANGIC_TARIHIField;
                }
                set
                {
                    sORGU_BASLANGIC_TARIHIField = value;
                }
            }

            /// <remarks/>
            public System.DateTime SORGU_BITIS_TARIHI
            {
                get
                {
                    return sORGU_BITIS_TARIHIField;
                }
                set
                {
                    sORGU_BITIS_TARIHIField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HastaVitalBulguGonderCevap
        {

            private bool islemBasarisiField;

            private string servisMesajiField;

            /// <remarks/>
            public bool IslemBasarisi
            {
                get
                {
                    return islemBasarisiField;
                }
                set
                {
                    islemBasarisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string ServisMesaji
            {
                get
                {
                    return servisMesajiField;
                }
                set
                {
                    servisMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HastaVitalBulguGonderTalep
        {

            private string degerField;

            private long hASTA_KIMLIK_NUMARASIField;

            private string kURUM_KODUField;

            private System.DateTime tarihField;

            private string vitalBulguIDField;

            private VitalBulguTuru vitalBulguTuruField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string Deger
            {
                get
                {
                    return degerField;
                }
                set
                {
                    degerField = value;
                }
            }

            /// <remarks/>
            public long HASTA_KIMLIK_NUMARASI
            {
                get
                {
                    return hASTA_KIMLIK_NUMARASIField;
                }
                set
                {
                    hASTA_KIMLIK_NUMARASIField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string KURUM_KODU
            {
                get
                {
                    return kURUM_KODUField;
                }
                set
                {
                    kURUM_KODUField = value;
                }
            }

            /// <remarks/>
            public System.DateTime Tarih
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
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string VitalBulguID
            {
                get
                {
                    return vitalBulguIDField;
                }
                set
                {
                    vitalBulguIDField = value;
                }
            }

            /// <remarks/>
            public VitalBulguTuru VitalBulguTuru
            {
                get
                {
                    return vitalBulguTuruField;
                }
                set
                {
                    vitalBulguTuruField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public enum VitalBulguTuru
        {

            /// <remarks/>
            Nabiz,

            /// <remarks/>
            Tansiyon,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HastaMesajGonderCevap
        {

            private bool islemBasarisiField;

            private string servisMesajiField;

            /// <remarks/>
            public bool IslemBasarisi
            {
                get
                {
                    return islemBasarisiField;
                }
                set
                {
                    islemBasarisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string ServisMesaji
            {
                get
                {
                    return servisMesajiField;
                }
                set
                {
                    servisMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class HastaMesajGonderTalep
        {

            private long hASTA_KIMLIK_NUMARASIField;

            private string kURUM_KODUField;

            private string mESAJ_DETAYIField;

            private System.DateTime mESAJ_TARIHIField;

            private string sKRS_HASTA_MESAJLARI_ADIField;

            private int sKRS_HASTA_MESAJLARI_KODUField;

            private string sYSTakipNoField;

            /// <remarks/>
            public long HASTA_KIMLIK_NUMARASI
            {
                get
                {
                    return hASTA_KIMLIK_NUMARASIField;
                }
                set
                {
                    hASTA_KIMLIK_NUMARASIField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string KURUM_KODU
            {
                get
                {
                    return kURUM_KODUField;
                }
                set
                {
                    kURUM_KODUField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string MESAJ_DETAYI
            {
                get
                {
                    return mESAJ_DETAYIField;
                }
                set
                {
                    mESAJ_DETAYIField = value;
                }
            }

            /// <remarks/>
            public System.DateTime MESAJ_TARIHI
            {
                get
                {
                    return mESAJ_TARIHIField;
                }
                set
                {
                    mESAJ_TARIHIField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SKRS_HASTA_MESAJLARI_ADI
            {
                get
                {
                    return sKRS_HASTA_MESAJLARI_ADIField;
                }
                set
                {
                    sKRS_HASTA_MESAJLARI_ADIField = value;
                }
            }

            /// <remarks/>
            public int SKRS_HASTA_MESAJLARI_KODU
            {
                get
                {
                    return sKRS_HASTA_MESAJLARI_KODUField;
                }
                set
                {
                    sKRS_HASTA_MESAJLARI_KODUField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string SYSTakipNo
            {
                get
                {
                    return sYSTakipNoField;
                }
                set
                {
                    sYSTakipNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://schemas.datacontract.org/2004/07/NabizHBYS")]
        public partial class DoktorErisimCevap
        {

            private string accessKeyField;

            private bool islemBasarisiField;

            private string servisMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string AccessKey
            {
                get
                {
                    return accessKeyField;
                }
                set
                {
                    accessKeyField = value;
                }
            }

            /// <remarks/>
            public bool IslemBasarisi
            {
                get
                {
                    return islemBasarisiField;
                }
                set
                {
                    islemBasarisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public string ServisMesaji
            {
                get
                {
                    return servisMesajiField;
                }
                set
                {
                    servisMesajiField = value;
                }
            }
        }
        #endregion
    }
}