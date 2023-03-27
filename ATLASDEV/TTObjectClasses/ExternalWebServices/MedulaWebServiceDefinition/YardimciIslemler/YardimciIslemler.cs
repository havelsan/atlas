
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
    public  abstract  partial class YardimciIslemler : TTObject
    {
        
                    
        public static partial class WebMethods
        {
                    
        }

        #region Methods

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacListesiSorguIstekDVO
        {

            private System.Nullable<int> tesisKoduField;

            private System.Nullable<long> doktorTcKimlikNoField;

            private string islemTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long> doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemTarihi
            {
                get
                {
                    return islemTarihiField;
                }
                set
                {
                    islemTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class etkinMaddeDVO
        {

            private string koduField;

            private string adiField;

            private string icerikMiktariField;

            private string formuField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kodu
            {
                get
                {
                    return koduField;
                }
                set
                {
                    koduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string adi
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string icerikMiktari
            {
                get
                {
                    return icerikMiktariField;
                }
                set
                {
                    icerikMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string formu
            {
                get
                {
                    return formuField;
                }
                set
                {
                    formuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class etkinMaddeListesiSorguCevapDVO
        {

            private etkinMaddeDVO[] etkinMaddeListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("etkinMaddeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public etkinMaddeDVO[] etkinMaddeListesi
            {
                get
                {
                    return etkinMaddeListesiField;
                }
                set
                {
                    etkinMaddeListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class etkinMaddeListesiSorguIstekDVO
        {

            private System.Nullable<int> tesisKoduField;

            private System.Nullable<long> doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long> doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class etkinMaddeSutDVO
        {

            private string etkinMaddeSutNoField;

            private raporTeshisDVO[] raporTeshisListesiField;

            private string[] doktorBransListesiField;

            private string[] doktorSertifikaListesiField;

            private string[] tesisAnaGrupListesiField;

            private string raporDuzenlemeTuruField;

            private string cinsiyetiField;

            private string maksimumRaporTarihiField;

            private string minimumYasiField;

            private string maksimumYasiField;

            private string maksimumRaporSuresiField;

            private string maksimumRaporSuresiBirimiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string etkinMaddeSutNo
            {
                get
                {
                    return etkinMaddeSutNoField;
                }
                set
                {
                    etkinMaddeSutNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporTeshisListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public raporTeshisDVO[] raporTeshisListesi
            {
                get
                {
                    return raporTeshisListesiField;
                }
                set
                {
                    raporTeshisListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("doktorBransListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] doktorBransListesi
            {
                get
                {
                    return doktorBransListesiField;
                }
                set
                {
                    doktorBransListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("doktorSertifikaListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] doktorSertifikaListesi
            {
                get
                {
                    return doktorSertifikaListesiField;
                }
                set
                {
                    doktorSertifikaListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tesisAnaGrupListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] tesisAnaGrupListesi
            {
                get
                {
                    return tesisAnaGrupListesiField;
                }
                set
                {
                    tesisAnaGrupListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporDuzenlemeTuru
            {
                get
                {
                    return raporDuzenlemeTuruField;
                }
                set
                {
                    raporDuzenlemeTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string cinsiyeti
            {
                get
                {
                    return cinsiyetiField;
                }
                set
                {
                    cinsiyetiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string maksimumRaporTarihi
            {
                get
                {
                    return maksimumRaporTarihiField;
                }
                set
                {
                    maksimumRaporTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string minimumYasi
            {
                get
                {
                    return minimumYasiField;
                }
                set
                {
                    minimumYasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string maksimumYasi
            {
                get
                {
                    return maksimumYasiField;
                }
                set
                {
                    maksimumYasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string maksimumRaporSuresi
            {
                get
                {
                    return maksimumRaporSuresiField;
                }
                set
                {
                    maksimumRaporSuresiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string maksimumRaporSuresiBirimi
            {
                get
                {
                    return maksimumRaporSuresiBirimiField;
                }
                set
                {
                    maksimumRaporSuresiBirimiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class raporTeshisDVO
        {

            private string raporTeshisKoduField;

            private string aciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTeshisKodu
            {
                get
                {
                    return raporTeshisKoduField;
                }
                set
                {
                    raporTeshisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string aciklama
            {
                get
                {
                    return aciklamaField;
                }
                set
                {
                    aciklamaField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class etkinMaddeSutListesiSorguCevapDVO
        {

            private etkinMaddeSutDVO[] etkinMaddeSutListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("etkinMaddeSutListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public etkinMaddeSutDVO[] etkinMaddeSutListesi
            {
                get
                {
                    return etkinMaddeSutListesiField;
                }
                set
                {
                    etkinMaddeSutListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class etkinMaddeSutListesiSorguIstekDVO
        {

            private System.Nullable<int> tesisKoduField;

            private System.Nullable<long> doktorTcKimlikNoField;

            private string etkinMaddeKoduField;

            private string raporTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long> doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string etkinMaddeKodu
            {
                get
                {
                    return etkinMaddeKoduField;
                }
                set
                {
                    etkinMaddeKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTarihi
            {
                get
                {
                    return raporTarihiField;
                }
                set
                {
                    raporTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class raporTeshisListesiSorguCevapDVO
        {

            private raporTeshisDVO[] raporTeshisListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporTeshisListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public raporTeshisDVO[] raporTeshisListesi
            {
                get
                {
                    return raporTeshisListesiField;
                }
                set
                {
                    raporTeshisListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class raporTeshisListesiSorguIstekDVO
        {

            private System.Nullable<int> tesisKoduField;

            private System.Nullable<long> doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> tesisKodu
            {
                get
                {
                    return tesisKoduField;
                }
                set
                {
                    tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long> doktorTcKimlikNo
            {
                get
                {
                    return doktorTcKimlikNoField;
                }
                set
                {
                    doktorTcKimlikNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacDVO
        {

            private long barkodField;

            private string ilacAdiField;

            private int sgkIlacKoduField;

            private double ambalajMiktariField;

            private double tekDozMiktariField;

            private double kutuBirimMiktariField;

            private string ayaktanOdenmeSartiField;

            private string yatanOdenmeSartiField;

            private string etkinMaddeKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long barkod
            {
                get
                {
                    return this.barkodField;
                }
                set
                {
                    this.barkodField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ilacAdi
            {
                get
                {
                    return this.ilacAdiField;
                }
                set
                {
                    this.ilacAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int sgkIlacKodu
            {
                get
                {
                    return this.sgkIlacKoduField;
                }
                set
                {
                    this.sgkIlacKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double ambalajMiktari
            {
                get
                {
                    return this.ambalajMiktariField;
                }
                set
                {
                    this.ambalajMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double tekDozMiktari
            {
                get
                {
                    return this.tekDozMiktariField;
                }
                set
                {
                    this.tekDozMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double kutuBirimMiktari
            {
                get
                {
                    return this.kutuBirimMiktariField;
                }
                set
                {
                    this.kutuBirimMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ayaktanOdenmeSarti
            {
                get
                {
                    return this.ayaktanOdenmeSartiField;
                }
                set
                {
                    this.ayaktanOdenmeSartiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yatanOdenmeSarti
            {
                get
                {
                    return this.yatanOdenmeSartiField;
                }
                set
                {
                    this.yatanOdenmeSartiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string etkinMaddeKodu
            {
                get
                {
                    return this.etkinMaddeKoduField;
                }
                set
                {
                    this.etkinMaddeKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacListesiSorguCevapDVO
        {

            private ilacDVO[] ilacListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ilacDVO[] ilacListesi
            {
                get
                {
                    return ilacListesiField;
                }
                set
                {
                    ilacListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return sonucKoduField;
                }
                set
                {
                    sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return sonucMesajiField;
                }
                set
                {
                    sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return uyariMesajiField;
                }
                set
                {
                    uyariMesajiField = value;
                }
            }
        }

        #endregion Methods

    }
}