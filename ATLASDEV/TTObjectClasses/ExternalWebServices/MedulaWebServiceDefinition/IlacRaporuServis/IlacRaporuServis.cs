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
    public partial class IlacRaporuServis : TTObject
    {


        public static partial class WebMethods
        {

        }

        #region Methods


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporAciklamaEkleIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            private eraporAciklamaDVO eraporAciklamaDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporAciklamaDVO eraporAciklamaDVO
            {
                get
                {
                    return this.eraporAciklamaDVOField;
                }
                set
                {
                    this.eraporAciklamaDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporAciklamaDVO
        {

            private string aciklamaField;

            private string takipFormuNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string aciklama
            {
                get
                {
                    return this.aciklamaField;
                }
                set
                {
                    this.aciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string takipFormuNo
            {
                get
                {
                    return this.takipFormuNoField;
                }
                set
                {
                    this.takipFormuNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporTeshisEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporTeshisEkleIstekDVO
        {

            private byte[] imzaliEraporTeshisField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporTeshis
            {
                get
                {
                    return this.imzaliEraporTeshisField;
                }
                set
                {
                    this.imzaliEraporTeshisField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporTaniEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporTaniEkleIstekDVO
        {

            private byte[] imzaliEraporTaniField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporTani
            {
                get
                {
                    return this.imzaliEraporTaniField;
                }
                set
                {
                    this.imzaliEraporTaniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eraporDVO eraporDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporDVO eraporDVO
            {
                get
                {
                    return this.eraporDVOField;
                }
                set
                {
                    this.eraporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporDVO
        {

            private string tesisKoduField;

            private string raporTakipNoField;

            private string hastaTcKimlikNoField;

            private string raporNoField;

            private string raporTarihiField;

            private string protokolNoField;

            private string aciklamaField;

            private string klinikTaniField;

            private string raporDuzenlemeTuruField;

            private string takipNoField;

            private string raporOnayDurumuField;

            private kisiDVO kisiDVOField;

            private eraporTeshisDVO[] eraporTeshisListesiField;

            private eraporDoktorDVO[] eraporDoktorListesiField;

            private eraporEtkinMaddeDVO[] eraporEtkinMaddeListesiField;

            private eraporAciklamaDVO[] eraporAciklamaListesiField;

            private eraporTaniDVO[] eraporTaniListesiField;

            private eraporIlaveDegerDVO[] eraporIlaveDegerListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaTcKimlikNo
            {
                get
                {
                    return this.hastaTcKimlikNoField;
                }
                set
                {
                    this.hastaTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporNo
            {
                get
                {
                    return this.raporNoField;
                }
                set
                {
                    this.raporNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTarihi
            {
                get
                {
                    return this.raporTarihiField;
                }
                set
                {
                    this.raporTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string protokolNo
            {
                get
                {
                    return this.protokolNoField;
                }
                set
                {
                    this.protokolNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string aciklama
            {
                get
                {
                    return this.aciklamaField;
                }
                set
                {
                    this.aciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string klinikTani
            {
                get
                {
                    return this.klinikTaniField;
                }
                set
                {
                    this.klinikTaniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporDuzenlemeTuru
            {
                get
                {
                    return this.raporDuzenlemeTuruField;
                }
                set
                {
                    this.raporDuzenlemeTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipNo
            {
                get
                {
                    return this.takipNoField;
                }
                set
                {
                    this.takipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string raporOnayDurumu
            {
                get
                {
                    return this.raporOnayDurumuField;
                }
                set
                {
                    this.raporOnayDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kisiDVO kisiDVO
            {
                get
                {
                    return this.kisiDVOField;
                }
                set
                {
                    this.kisiDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporTeshisListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporTeshisDVO[] eraporTeshisListesi
            {
                get
                {
                    return this.eraporTeshisListesiField;
                }
                set
                {
                    this.eraporTeshisListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporDoktorListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporDoktorDVO[] eraporDoktorListesi
            {
                get
                {
                    return this.eraporDoktorListesiField;
                }
                set
                {
                    this.eraporDoktorListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporEtkinMaddeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporEtkinMaddeDVO[] eraporEtkinMaddeListesi
            {
                get
                {
                    return this.eraporEtkinMaddeListesiField;
                }
                set
                {
                    this.eraporEtkinMaddeListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporAciklamaListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporAciklamaDVO[] eraporAciklamaListesi
            {
                get
                {
                    return this.eraporAciklamaListesiField;
                }
                set
                {
                    this.eraporAciklamaListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporTaniListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eraporTaniDVO[] eraporTaniListesi
            {
                get
                {
                    return this.eraporTaniListesiField;
                }
                set
                {
                    this.eraporTaniListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporIlaveDegerListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eraporIlaveDegerDVO[] eraporIlaveDegerListesi
            {
                get
                {
                    return this.eraporIlaveDegerListesiField;
                }
                set
                {
                    this.eraporIlaveDegerListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiDVO
        {

            private string adiField;

            private string cinsiyetiField;

            private string dogumTarihiField;

            private string soyadiField;

            private long tcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string adi
            {
                get
                {
                    return this.adiField;
                }
                set
                {
                    this.adiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string cinsiyeti
            {
                get
                {
                    return this.cinsiyetiField;
                }
                set
                {
                    this.cinsiyetiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string dogumTarihi
            {
                get
                {
                    return this.dogumTarihiField;
                }
                set
                {
                    this.dogumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string soyadi
            {
                get
                {
                    return this.soyadiField;
                }
                set
                {
                    this.soyadiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long tcKimlikNo
            {
                get
                {
                    return this.tcKimlikNoField;
                }
                set
                {
                    this.tcKimlikNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporTeshisDVO
        {

            private string raporTeshisKoduField;

            private string baslangicTarihiField;

            private string bitisTarihiField;

            private taniDVO[] taniListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTeshisKodu
            {
                get
                {
                    return this.raporTeshisKoduField;
                }
                set
                {
                    this.raporTeshisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string baslangicTarihi
            {
                get
                {
                    return this.baslangicTarihiField;
                }
                set
                {
                    this.baslangicTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string bitisTarihi
            {
                get
                {
                    return this.bitisTarihiField;
                }
                set
                {
                    this.bitisTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("taniListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public taniDVO[] taniListesi
            {
                get
                {
                    return this.taniListesiField;
                }
                set
                {
                    this.taniListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class taniDVO
        {

            private string koduField;

            private string adiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kodu
            {
                get
                {
                    return this.koduField;
                }
                set
                {
                    this.koduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string adi
            {
                get
                {
                    return this.adiField;
                }
                set
                {
                    this.adiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporDoktorDVO
        {

            private string tcKimlikNoField;

            private string bransKoduField;

            private string sertifikaKoduField;

            private string adiField;

            private string soyadiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tcKimlikNo
            {
                get
                {
                    return this.tcKimlikNoField;
                }
                set
                {
                    this.tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bransKodu
            {
                get
                {
                    return this.bransKoduField;
                }
                set
                {
                    this.bransKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sertifikaKodu
            {
                get
                {
                    return this.sertifikaKoduField;
                }
                set
                {
                    this.sertifikaKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string adi
            {
                get
                {
                    return this.adiField;
                }
                set
                {
                    this.adiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string soyadi
            {
                get
                {
                    return this.soyadiField;
                }
                set
                {
                    this.soyadiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporEtkinMaddeDVO
        {

            private string etkinMaddeKoduField;

            private string kullanimDoz1Field;

            private string kullanimDoz2Field;

            private string kullanimDozBirimiField;

            private string kullanimDozPeriyotField;

            private string kullanimDozPeriyotBirimiField;

            private etkinMaddeDVO etkinMaddeDVOField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimDoz1
            {
                get
                {
                    return this.kullanimDoz1Field;
                }
                set
                {
                    this.kullanimDoz1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimDoz2
            {
                get
                {
                    return this.kullanimDoz2Field;
                }
                set
                {
                    this.kullanimDoz2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimDozBirimi
            {
                get
                {
                    return this.kullanimDozBirimiField;
                }
                set
                {
                    this.kullanimDozBirimiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimDozPeriyot
            {
                get
                {
                    return this.kullanimDozPeriyotField;
                }
                set
                {
                    this.kullanimDozPeriyotField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimDozPeriyotBirimi
            {
                get
                {
                    return this.kullanimDozPeriyotBirimiField;
                }
                set
                {
                    this.kullanimDozPeriyotBirimiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public etkinMaddeDVO etkinMaddeDVO
            {
                get
                {
                    return this.etkinMaddeDVOField;
                }
                set
                {
                    this.etkinMaddeDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
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
                    return this.koduField;
                }
                set
                {
                    this.koduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string adi
            {
                get
                {
                    return this.adiField;
                }
                set
                {
                    this.adiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string icerikMiktari
            {
                get
                {
                    return this.icerikMiktariField;
                }
                set
                {
                    this.icerikMiktariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string formu
            {
                get
                {
                    return this.formuField;
                }
                set
                {
                    this.formuField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporTaniDVO
        {

            private string taniAdiField;

            private string taniKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string taniAdi
            {
                get
                {
                    return this.taniAdiField;
                }
                set
                {
                    this.taniAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string taniKodu
            {
                get
                {
                    return this.taniKoduField;
                }
                set
                {
                    this.taniKoduField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporIlaveDegerDVO
        {

            private int turuField;

            private string degeriField;

            private string aciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int turu
            {
                get
                {
                    return this.turuField;
                }
                set
                {
                    this.turuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string degeri
            {
                get
                {
                    return this.degeriField;
                }
                set
                {
                    this.degeriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string aciklama
            {
                get
                {
                    return this.aciklamaField;
                }
                set
                {
                    this.aciklamaField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporSorguIstekDVO
        {

            private byte[] imzaliEraporSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporSorgula
            {
                get
                {
                    return this.imzaliEraporSorgulaField;
                }
                set
                {
                    this.imzaliEraporSorgulaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporSilCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporSilIstekDVO
        {

            private byte[] imzaliEraporSilField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporSil
            {
                get
                {
                    return this.imzaliEraporSilField;
                }
                set
                {
                    this.imzaliEraporSilField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporOnayRedCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporOnayRedIstekDVO
        {

            private byte[] imzaliEraporOnayRedField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporOnayRed
            {
                get
                {
                    return this.imzaliEraporOnayRedField;
                }
                set
                {
                    this.imzaliEraporOnayRedField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporOnayBekleyenListeSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private System.Nullable<long>[] raporTakipNoListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporTakipNoListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long>[] raporTakipNoListesi
            {
                get
                {
                    return this.raporTakipNoListesiField;
                }
                set
                {
                    this.raporTakipNoListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporOnayBekleyenListeSorguIstekDVO
        {

            private byte[] imzaliEraporOnayBekleyenListeSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporOnayBekleyenListeSorgula
            {
                get
                {
                    return this.imzaliEraporOnayBekleyenListeSorgulaField;
                }
                set
                {
                    this.imzaliEraporOnayBekleyenListeSorgulaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporOnayCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporOnayIstekDVO
        {

            private byte[] imzaliEraporOnayField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporOnay
            {
                get
                {
                    return this.imzaliEraporOnayField;
                }
                set
                {
                    this.imzaliEraporOnayField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporListeSorguCevapDVO
        {

            private kisiDVO kisiDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eraporDVO[] eraporListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public kisiDVO kisiDVO
            {
                get
                {
                    return this.kisiDVOField;
                }
                set
                {
                    this.kisiDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eraporDVO[] eraporListesi
            {
                get
                {
                    return this.eraporListesiField;
                }
                set
                {
                    this.eraporListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporListeSorguIstekDVO
        {

            private byte[] imzaliEraporListeSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporListeSorgula
            {
                get
                {
                    return this.imzaliEraporListeSorgulaField;
                }
                set
                {
                    this.imzaliEraporListeSorgulaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporIlaveDegerEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporIlaveDegerEkleIstekDVO
        {

            private byte[] imzaliEraporIlaveDegerField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporIlaveDeger
            {
                get
                {
                    return this.imzaliEraporIlaveDegerField;
                }
                set
                {
                    this.imzaliEraporIlaveDegerField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporGirisCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eraporDVO eraporDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporDVO eraporDVO
            {
                get
                {
                    return this.eraporDVOField;
                }
                set
                {
                    this.eraporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporGirisIstekDVO
        {

            private byte[] imzaliEraporField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliErapor
            {
                get
                {
                    return this.imzaliEraporField;
                }
                set
                {
                    this.imzaliEraporField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporEtkinMaddeEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporEtkinMaddeEkleIstekDVO
        {

            private byte[] imzaliEraporEtkinMaddeField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporEtkinMadde
            {
                get
                {
                    return this.imzaliEraporEtkinMaddeField;
                }
                set
                {
                    this.imzaliEraporEtkinMaddeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporBashekimOnayRedCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporBashekimOnayRedIstekDVO
        {

            private byte[] imzaliEraporBashekimOnayBekleyenOnayRedField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporBashekimOnayBekleyenOnayRed
            {
                get
                {
                    return this.imzaliEraporBashekimOnayBekleyenOnayRedField;
                }
                set
                {
                    this.imzaliEraporBashekimOnayBekleyenOnayRedField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private System.Nullable<long>[] raporTakipNoListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporTakipNoListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long>[] raporTakipNoListesi
            {
                get
                {
                    return this.raporTakipNoListesiField;
                }
                set
                {
                    this.raporTakipNoListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporBashekimOnayBekleyenListeSorguIstekDVO
        {

            private byte[] imzaliEraporBashekimOnayBekleyenListeSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporBashekimOnayBekleyenListeSorgula
            {
                get
                {
                    return this.imzaliEraporBashekimOnayBekleyenListeSorgulaField;
                }
                set
                {
                    this.imzaliEraporBashekimOnayBekleyenListeSorgulaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporBashekimOnayCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporBashekimOnayIstekDVO
        {

            private byte[] imzaliEraporBashekimOnayField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporBashekimOnay
            {
                get
                {
                    return this.imzaliEraporBashekimOnayField;
                }
                set
                {
                    this.imzaliEraporBashekimOnayField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporAciklamaEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEraporAciklamaEkleIstekDVO
        {

            private byte[] imzaliEraporAciklamaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private int surumNumarasiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporAciklama
            {
                get
                {
                    return this.imzaliEraporAciklamaField;
                }
                set
                {
                    this.imzaliEraporAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int surumNumarasi
            {
                get
                {
                    return this.surumNumarasiField;
                }
                set
                {
                    this.surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporTeshisEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporTeshisEkleIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            private eraporTeshisDVO eraporTeshisDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporTeshisDVO eraporTeshisDVO
            {
                get
                {
                    return this.eraporTeshisDVOField;
                }
                set
                {
                    this.eraporTeshisDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporTaniEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporTaniEkleIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            private string raporTeshisKoduField;

            private eraporTaniDVO eraporTaniDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTeshisKodu
            {
                get
                {
                    return this.raporTeshisKoduField;
                }
                set
                {
                    this.raporTeshisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporTaniDVO eraporTaniDVO
            {
                get
                {
                    return this.eraporTaniDVOField;
                }
                set
                {
                    this.eraporTaniDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eraporDVO eraporDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporDVO eraporDVO
            {
                get
                {
                    return this.eraporDVOField;
                }
                set
                {
                    this.eraporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporSorguIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporSilCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporSilIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporOnayRedCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporOnayRedIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporOnayBekleyenListeSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private System.Nullable<long>[] raporTakipNoListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporTakipNoListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long>[] raporTakipNoListesi
            {
                get
                {
                    return this.raporTakipNoListesiField;
                }
                set
                {
                    this.raporTakipNoListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporOnayBekleyenListeSorguIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporOnayCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporOnayIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporListeSorguCevapDVO
        {

            private kisiDVO kisiDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eraporDVO[] eraporListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public kisiDVO kisiDVO
            {
                get
                {
                    return this.kisiDVOField;
                }
                set
                {
                    this.kisiDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eraporListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eraporDVO[] eraporListesi
            {
                get
                {
                    return this.eraporListesiField;
                }
                set
                {
                    this.eraporListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporListeSorguIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string hastaTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaTcKimlikNo
            {
                get
                {
                    return this.hastaTcKimlikNoField;
                }
                set
                {
                    this.hastaTcKimlikNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporIlaveDegerEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporIlaveDegerEkleIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            private eraporIlaveDegerDVO[] ilaveDegerListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilaveDegerListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporIlaveDegerDVO[] ilaveDegerListesi
            {
                get
                {
                    return this.ilaveDegerListesiField;
                }
                set
                {
                    this.ilaveDegerListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporGirisCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eraporDVO eraporDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporDVO eraporDVO
            {
                get
                {
                    return this.eraporDVOField;
                }
                set
                {
                    this.eraporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporGirisIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private eraporDVO eraporDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporDVO eraporDVO
            {
                get
                {
                    return this.eraporDVOField;
                }
                set
                {
                    this.eraporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporEtkinMaddeEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporEtkinMaddeEkleIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            private eraporEtkinMaddeDVO eraporEtkinMaddeDVOField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eraporEtkinMaddeDVO eraporEtkinMaddeDVO
            {
                get
                {
                    return this.eraporEtkinMaddeDVOField;
                }
                set
                {
                    this.eraporEtkinMaddeDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporBashekimOnayRedCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporBashekimOnayRedIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporBashekimOnayBekleyenListeSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private System.Nullable<long>[] raporTakipNoListesiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporTakipNoListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long>[] raporTakipNoListesi
            {
                get
                {
                    return this.raporTakipNoListesiField;
                }
                set
                {
                    this.raporTakipNoListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporBashekimOnayBekleyenListeSorguIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporBashekimOnayCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporBashekimOnayIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
            {
                get
                {
                    return this.tesisKoduField;
                }
                set
                {
                    this.tesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
            {
                get
                {
                    return this.doktorTcKimlikNoField;
                }
                set
                {
                    this.doktorTcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return this.raporTakipNoField;
                }
                set
                {
                    this.raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eraporAciklamaEkleCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucKodu
            {
                get
                {
                    return this.sonucKoduField;
                }
                set
                {
                    this.sonucKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sonucMesaji
            {
                get
                {
                    return this.sonucMesajiField;
                }
                set
                {
                    this.sonucMesajiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string uyariMesaji
            {
                get
                {
                    return this.uyariMesajiField;
                }
                set
                {
                    this.uyariMesajiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporAciklamaEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporAciklamaEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporAciklamaEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporAciklamaEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporBashekimOnayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporBashekimOnayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporBashekimOnayCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporBashekimOnayCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporBashekimOnayBekleyenListeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporBashekimOnayBekleyenListeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporBashekimOnayBekleyenListeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporBashekimOnayBekleyenListeSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporBashekimOnayRedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporBashekimOnayRedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporBashekimOnayRedCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporBashekimOnayRedCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporEtkinMaddeEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporEtkinMaddeEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporEtkinMaddeEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporEtkinMaddeEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporGirisCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporGirisCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporGirisCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporGirisCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporIlaveDegerEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporIlaveDegerEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporIlaveDegerEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporIlaveDegerEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporListeSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporListeSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporListeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporListeSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporOnayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporOnayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporOnayCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporOnayCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporOnayBekleyenListeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporOnayBekleyenListeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporOnayBekleyenListeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporOnayBekleyenListeSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporOnayRedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporOnayRedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporOnayRedCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporOnayRedCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporSilCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporSilCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporSilCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporSilCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporTaniEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporTaniEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporTaniEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporTaniEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eraporTeshisEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eraporTeshisEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eraporTeshisEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((eraporTeshisEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporAciklamaEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporAciklamaEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporAciklamaEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporAciklamaEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporBashekimOnayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporBashekimOnayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporBashekimOnayCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporBashekimOnayCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporBashekimOnayBekleyenListeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporBashekimOnayBekleyenListeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporBashekimOnayBekleyenListeSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporBashekimOnayRedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporBashekimOnayRedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporBashekimOnayRedCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporBashekimOnayRedCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporEtkinMaddeEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporEtkinMaddeEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporEtkinMaddeEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporEtkinMaddeEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporGirisCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporGirisCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporGirisCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporGirisCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporIlaveDegerEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporIlaveDegerEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporIlaveDegerEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporIlaveDegerEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporListeSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporListeSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporListeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporListeSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporOnayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporOnayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporOnayCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporOnayCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporOnayBekleyenListeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporOnayBekleyenListeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporOnayBekleyenListeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporOnayBekleyenListeSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporOnayRedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporOnayRedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporOnayRedCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporOnayRedCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporSilCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporSilCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporSilCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporSilCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporSorguCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporTaniEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporTaniEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporTaniEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporTaniEkleCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEraporTeshisEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEraporTeshisEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEraporTeshisEkleCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((imzaliEraporTeshisEkleCevapDVO)(this.results[0]));
                }
            }
        }

        #endregion Methods

    }
}