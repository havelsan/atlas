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
    /// <summary>
    /// MEDULA YArd?mc? ??lemleri
    /// </summary>
    public abstract partial class MedulaYardimciIslemler : TTObject
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
        public partial class barkodSutEslesmeSorguGirisDVO
        {

            private int saglikTesisKoduField;

            private string barkodField;

            private string firmaTanimlayiciNoField;

            private string sutKoduField;

            private string tarihField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string barkod
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string firmaTanimlayiciNo
            {
                get
                {
                    return this.firmaTanimlayiciNoField;
                }
                set
                {
                    this.firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string tarih
            {
                get
                {
                    return this.tarihField;
                }
                set
                {
                    this.tarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class yurtDisiYardimHakkiGetirCevapDetayDVO
        {

            private int idField;

            private string kisiNoField;

            private string adiField;

            private string soyadiField;

            private string formulAdiField;

            private string odemeTuruField;

            private string tedaviKapsamiField;

            private string sorguTarihiField;

            private string aciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kisiNo
            {
                get
                {
                    return this.kisiNoField;
                }
                set
                {
                    this.kisiNoField = value;
                }
            }

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
            public string formulAdi
            {
                get
                {
                    return this.formulAdiField;
                }
                set
                {
                    this.formulAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string odemeTuru
            {
                get
                {
                    return this.odemeTuruField;
                }
                set
                {
                    this.odemeTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tedaviKapsami
            {
                get
                {
                    return this.tedaviKapsamiField;
                }
                set
                {
                    this.tedaviKapsamiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sorguTarihi
            {
                get
                {
                    return this.sorguTarihiField;
                }
                set
                {
                    this.sorguTarihiField = value;
                }
            }

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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class yurtDisiYardimHakkiGetirCevapDVO
        {

            private yurtDisiYardimHakkiGetirCevapDetayDVO[] yurtDisiDetayField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("yurtDisiDetay", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public yurtDisiYardimHakkiGetirCevapDetayDVO[] yurtDisiDetay
            {
                get
                {
                    return this.yurtDisiDetayField;
                }
                set
                {
                    this.yurtDisiDetayField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class yurtDisiYardimHakkiGetirGirisDVO
        {

            private int saglikTesisKoduField;

            private string kisiNoField;

            private string provizyonTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kisiNo
            {
                get
                {
                    return this.kisiNoField;
                }
                set
                {
                    this.kisiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string provizyonTarihi
            {
                get
                {
                    return this.provizyonTarihiField;
                }
                set
                {
                    this.provizyonTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class tesisYatakBilgiDVO
        {

            private string yatakKoduField;

            private string turuField;

            private int tescilTuruField;

            private int seviyeField;

            private string gecerlilikBaslangicTarihiField;

            private string gecerlilikBitisTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yatakKodu
            {
                get
                {
                    return this.yatakKoduField;
                }
                set
                {
                    this.yatakKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string turu
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
            public int tescilTuru
            {
                get
                {
                    return this.tescilTuruField;
                }
                set
                {
                    this.tescilTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int seviye
            {
                get
                {
                    return this.seviyeField;
                }
                set
                {
                    this.seviyeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string gecerlilikBaslangicTarihi
            {
                get
                {
                    return this.gecerlilikBaslangicTarihiField;
                }
                set
                {
                    this.gecerlilikBaslangicTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string gecerlilikBitisTarihi
            {
                get
                {
                    return this.gecerlilikBitisTarihiField;
                }
                set
                {
                    this.gecerlilikBitisTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class tesisYatakSorguCevapDVO
        {

            private tesisYatakBilgiDVO[] yataklarField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("yataklar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public tesisYatakBilgiDVO[] yataklar
            {
                get
                {
                    return this.yataklarField;
                }
                set
                {
                    this.yataklarField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class tesisYatakSorguGirisDVO
        {

            private int saglikTesisKoduField;

            private string tarihField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string tarih
            {
                get
                {
                    return this.tarihField;
                }
                set
                {
                    this.tarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class taniListDVO
        {

            private string icd10KoduField;

            private string taniAdiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string icd10Kodu
            {
                get
                {
                    return this.icd10KoduField;
                }
                set
                {
                    this.icd10KoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class taniAraCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private taniListDVO[] tanilarField;

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
            [System.Xml.Serialization.XmlElementAttribute("tanilar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public taniListDVO[] tanilar
            {
                get
                {
                    return this.tanilarField;
                }
                set
                {
                    this.tanilarField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class taniAraGirisWSDVO
        {

            private string icd10KoduField;

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string icd10Kodu
            {
                get
                {
                    return this.icd10KoduField;
                }
                set
                {
                    this.icd10KoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipBilgisiListDVO
        {

            private string takipNoField;

            private string grupTuruField;

            private string grupAdiField;

            private double toplamTutarField;

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string grupTuru
            {
                get
                {
                    return this.grupTuruField;
                }
                set
                {
                    this.grupTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string grupAdi
            {
                get
                {
                    return this.grupAdiField;
                }
                set
                {
                    this.grupAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double toplamTutar
            {
                get
                {
                    return this.toplamTutarField;
                }
                set
                {
                    this.toplamTutarField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipBilgisiCevapDVO
        {

            private takipBilgisiListDVO[] takipBilgisiListDVOField;

            private int saglikTesisKoduField;

            private int evrakRefNoField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("takipBilgisiListDVO", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public takipBilgisiListDVO[] takipBilgisiListDVO
            {
                get
                {
                    return this.takipBilgisiListDVOField;
                }
                set
                {
                    this.takipBilgisiListDVOField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipBilgisiGirisDVO
        {

            private int saglikTesisKoduField;

            private int evrakRefNoField;

            private string grupTuruField;

            private int grupKoduField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string grupTuru
            {
                get
                {
                    return this.grupTuruField;
                }
                set
                {
                    this.grupTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int grupKodu
            {
                get
                {
                    return this.grupKoduField;
                }
                set
                {
                    this.grupKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ktsHbysKodu
            {
                get
                {
                    return this.ktsHbysKoduField;
                }
                set
                {
                    this.ktsHbysKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hastaBilgileriDVO
        {

            private string tcKimlikNoField;

            private string adField;

            private string soyadField;

            private string cinsiyetField;

            private string dogumTarihiField;

            private string sigortaliTuruField;

            private string devredilenKurumField;

            private string katilimPayindanMuafField;

            private string kapsamAdiField;

            private string olumTarihiField;

            private string ilaveUcrettenMuafField;

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
            public string ad
            {
                get
                {
                    return this.adField;
                }
                set
                {
                    this.adField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string soyad
            {
                get
                {
                    return this.soyadField;
                }
                set
                {
                    this.soyadField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string cinsiyet
            {
                get
                {
                    return this.cinsiyetField;
                }
                set
                {
                    this.cinsiyetField = value;
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
            public string sigortaliTuru
            {
                get
                {
                    return this.sigortaliTuruField;
                }
                set
                {
                    this.sigortaliTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string devredilenKurum
            {
                get
                {
                    return this.devredilenKurumField;
                }
                set
                {
                    this.devredilenKurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string katilimPayindanMuaf
            {
                get
                {
                    return this.katilimPayindanMuafField;
                }
                set
                {
                    this.katilimPayindanMuafField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kapsamAdi
            {
                get
                {
                    return this.kapsamAdiField;
                }
                set
                {
                    this.kapsamAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string olumTarihi
            {
                get
                {
                    return this.olumTarihiField;
                }
                set
                {
                    this.olumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ilaveUcrettenMuaf
            {
                get
                {
                    return this.ilaveUcrettenMuafField;
                }
                set
                {
                    this.ilaveUcrettenMuafField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipDVO
        {

            private string faturaTeslimNoField;

            private string ilkTakipNoField;

            private string bransKoduField;

            private string donorTCKimlikNoField;

            private string hastaBasvuruNoField;

            private hastaBilgileriDVO hastaBilgileriField;

            private string kayitTarihiField;

            private string provizyonTipiField;

            private string takipDurumuField;

            private string takipNoField;

            private string takipTarihiField;

            private string takipTipiField;

            private string kurumSevkTalepNoField;

            private string tedaviTipiField;

            private string tedaviTuruField;

            private int tesisKoduField;

            private string sevkDurumuField;

            private string yeniDoganCocukSiraNoField;

            private string yeniDoganDogumTarihiField;

            private string arvFlagField;

            private int evrakIDField;

            private string istisnaiHalField;

            private int fatutaIptalHakkiField;

            private string faturaTarihiField;

            private string hastaTelefonField;

            private string hastaAdresField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string faturaTeslimNo
            {
                get
                {
                    return this.faturaTeslimNoField;
                }
                set
                {
                    this.faturaTeslimNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ilkTakipNo
            {
                get
                {
                    return this.ilkTakipNoField;
                }
                set
                {
                    this.ilkTakipNoField = value;
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
            public string donorTCKimlikNo
            {
                get
                {
                    return this.donorTCKimlikNoField;
                }
                set
                {
                    this.donorTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaBasvuruNo
            {
                get
                {
                    return this.hastaBasvuruNoField;
                }
                set
                {
                    this.hastaBasvuruNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public hastaBilgileriDVO hastaBilgileri
            {
                get
                {
                    return this.hastaBilgileriField;
                }
                set
                {
                    this.hastaBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kayitTarihi
            {
                get
                {
                    return this.kayitTarihiField;
                }
                set
                {
                    this.kayitTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string provizyonTipi
            {
                get
                {
                    return this.provizyonTipiField;
                }
                set
                {
                    this.provizyonTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipDurumu
            {
                get
                {
                    return this.takipDurumuField;
                }
                set
                {
                    this.takipDurumuField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipTarihi
            {
                get
                {
                    return this.takipTarihiField;
                }
                set
                {
                    this.takipTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipTipi
            {
                get
                {
                    return this.takipTipiField;
                }
                set
                {
                    this.takipTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kurumSevkTalepNo
            {
                get
                {
                    return this.kurumSevkTalepNoField;
                }
                set
                {
                    this.kurumSevkTalepNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tedaviTipi
            {
                get
                {
                    return this.tedaviTipiField;
                }
                set
                {
                    this.tedaviTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tedaviTuru
            {
                get
                {
                    return this.tedaviTuruField;
                }
                set
                {
                    this.tedaviTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            public string sevkDurumu
            {
                get
                {
                    return this.sevkDurumuField;
                }
                set
                {
                    this.sevkDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yeniDoganCocukSiraNo
            {
                get
                {
                    return this.yeniDoganCocukSiraNoField;
                }
                set
                {
                    this.yeniDoganCocukSiraNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yeniDoganDogumTarihi
            {
                get
                {
                    return this.yeniDoganDogumTarihiField;
                }
                set
                {
                    this.yeniDoganDogumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string arvFlag
            {
                get
                {
                    return this.arvFlagField;
                }
                set
                {
                    this.arvFlagField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakID
            {
                get
                {
                    return this.evrakIDField;
                }
                set
                {
                    this.evrakIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string istisnaiHal
            {
                get
                {
                    return this.istisnaiHalField;
                }
                set
                {
                    this.istisnaiHalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int fatutaIptalHakki
            {
                get
                {
                    return this.fatutaIptalHakkiField;
                }
                set
                {
                    this.fatutaIptalHakkiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string faturaTarihi
            {
                get
                {
                    return this.faturaTarihiField;
                }
                set
                {
                    this.faturaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaTelefon
            {
                get
                {
                    return this.hastaTelefonField;
                }
                set
                {
                    this.hastaTelefonField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaAdres
            {
                get
                {
                    return this.hastaAdresField;
                }
                set
                {
                    this.hastaAdresField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipAraCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private takipDVO[] takiplerField;

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
            [System.Xml.Serialization.XmlElementAttribute("takipler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public takipDVO[] takipler
            {
                get
                {
                    return this.takiplerField;
                }
                set
                {
                    this.takiplerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipAraGirisDVO
        {

            private string hastaTCKField;

            private string baslangicTarihiField;

            private string bitisTarihiField;

            private string sevkDurumuField;

            private int saglikTesisKoduField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaTCK
            {
                get
                {
                    return this.hastaTCKField;
                }
                set
                {
                    this.hastaTCKField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sevkDurumu
            {
                get
                {
                    return this.sevkDurumuField;
                }
                set
                {
                    this.sevkDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ktsHbysKodu
            {
                get
                {
                    return this.ktsHbysKoduField;
                }
                set
                {
                    this.ktsHbysKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class saglikTesisiListDVO
        {

            private int tesisKoduField;

            private string tesisAdiField;

            private string tesisIlField;

            private string tesisTuruField;

            private string tesisSinifKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            public string tesisAdi
            {
                get
                {
                    return this.tesisAdiField;
                }
                set
                {
                    this.tesisAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisIl
            {
                get
                {
                    return this.tesisIlField;
                }
                set
                {
                    this.tesisIlField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisTuru
            {
                get
                {
                    return this.tesisTuruField;
                }
                set
                {
                    this.tesisTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisSinifKodu
            {
                get
                {
                    return this.tesisSinifKoduField;
                }
                set
                {
                    this.tesisSinifKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class saglikTesisiAraCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private saglikTesisiListDVO[] tesislerField;

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
            [System.Xml.Serialization.XmlElementAttribute("tesisler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public saglikTesisiListDVO[] tesisler
            {
                get
                {
                    return this.tesislerField;
                }
                set
                {
                    this.tesislerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class saglikTesisiAraGirisDVO
        {

            private int saglikTesisKoduField;

            private string tesisKoduField;

            private string tesisTuruField;

            private string tesisIlKoduField;

            private string tesisAdiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public string tesisTuru
            {
                get
                {
                    return this.tesisTuruField;
                }
                set
                {
                    this.tesisTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string tesisIlKodu
            {
                get
                {
                    return this.tesisIlKoduField;
                }
                set
                {
                    this.tesisIlKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string tesisAdi
            {
                get
                {
                    return this.tesisAdiField;
                }
                set
                {
                    this.tesisAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kurumSevkTalepNoSorguDetayDVO
        {

            private string kurumSevkTalepNoField;

            private string tcKimlikNoField;

            private string sevkTarihiField;

            private string saglikTesisKoduField;

            private string hastaBasvuruNoField;

            private string aciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kurumSevkTalepNo
            {
                get
                {
                    return this.kurumSevkTalepNoField;
                }
                set
                {
                    this.kurumSevkTalepNoField = value;
                }
            }

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
            public string sevkTarihi
            {
                get
                {
                    return this.sevkTarihiField;
                }
                set
                {
                    this.sevkTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaBasvuruNo
            {
                get
                {
                    return this.hastaBasvuruNoField;
                }
                set
                {
                    this.hastaBasvuruNoField = value;
                }
            }

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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kurumSevkTalepNoSorguCevapDVO
        {

            private kurumSevkTalepNoSorguDetayDVO[] kurumSevkGirisDetayField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("kurumSevkGirisDetay", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kurumSevkTalepNoSorguDetayDVO[] kurumSevkGirisDetay
            {
                get
                {
                    return this.kurumSevkGirisDetayField;
                }
                set
                {
                    this.kurumSevkGirisDetayField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kurumSevkTalepNoSorguGirisDVO
        {

            private long tcKimlikNoField;

            private int saglikTesisKoduField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiOlumKayitDetayDVO
        {

            private string tcKimlikNoField;

            private string adiField;

            private string soyadiField;

            private string olumTarihiField;

            private int saglikTesisKoduField;

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
            public string olumTarihi
            {
                get
                {
                    return this.olumTarihiField;
                }
                set
                {
                    this.olumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiOlumKayitCevapDVO
        {

            private kisiOlumKayitDetayDVO[] kisiOlumKayitDetayField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("kisiOlumKayitDetay", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kisiOlumKayitDetayDVO[] kisiOlumKayitDetay
            {
                get
                {
                    return this.kisiOlumKayitDetayField;
                }
                set
                {
                    this.kisiOlumKayitDetayField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiOlumKayitGirisDVO
        {

            private string tcKimlikNoField;

            private string olumTarihiField;

            private int saglikTesisKoduField;

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
            public string olumTarihi
            {
                get
                {
                    return this.olumTarihiField;
                }
                set
                {
                    this.olumTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiIslemDVO
        {

            private int tesisKoduField;

            private string tesisAdiField;

            private string islemTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            public string tesisAdi
            {
                get
                {
                    return this.tesisAdiField;
                }
                set
                {
                    this.tesisAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemTarihi
            {
                get
                {
                    return this.islemTarihiField;
                }
                set
                {
                    this.islemTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiGecmisIslemlerCevapDVO
        {

            private kisiIslemDVO[] oncekiIslemlerField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("oncekiIslemler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kisiIslemDVO[] oncekiIslemler
            {
                get
                {
                    return this.oncekiIslemlerField;
                }
                set
                {
                    this.oncekiIslemlerField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kisiGecmisIslemlerGirisDVO
        {

            private long hastaTCKimlikNoField;

            private string sutKoduField;

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long hastaTCKimlikNo
            {
                get
                {
                    return this.hastaTCKimlikNoField;
                }
                set
                {
                    this.hastaTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class evrakKesintiCevapDVO
        {

            private int evrakRefNoField;

            private double muayeneKatilimTutariField;

            private double malzemeKatilimTutariField;

            private double tupBebekKatilimTutariField;

            private evrakTakipDVO[] takiplerField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double muayeneKatilimTutari
            {
                get
                {
                    return this.muayeneKatilimTutariField;
                }
                set
                {
                    this.muayeneKatilimTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double malzemeKatilimTutari
            {
                get
                {
                    return this.malzemeKatilimTutariField;
                }
                set
                {
                    this.malzemeKatilimTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double tupBebekKatilimTutari
            {
                get
                {
                    return this.tupBebekKatilimTutariField;
                }
                set
                {
                    this.tupBebekKatilimTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("takipler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public evrakTakipDVO[] takipler
            {
                get
                {
                    return this.takiplerField;
                }
                set
                {
                    this.takiplerField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class evrakTakipDVO
        {

            private string takipNoField;

            private string grupTuruField;

            private int grupKoduField;

            private double toplamTutarField;

            private takipIslemKesintiDVO[] kesintilerField;

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string grupTuru
            {
                get
                {
                    return this.grupTuruField;
                }
                set
                {
                    this.grupTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int grupKodu
            {
                get
                {
                    return this.grupKoduField;
                }
                set
                {
                    this.grupKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double toplamTutar
            {
                get
                {
                    return this.toplamTutarField;
                }
                set
                {
                    this.toplamTutarField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("kesintiler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public takipIslemKesintiDVO[] kesintiler
            {
                get
                {
                    return this.kesintilerField;
                }
                set
                {
                    this.kesintilerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class takipIslemKesintiDVO
        {

            private string islemSiraNoField;

            private string hizmetSunucuRefNoField;

            private string islemTarihiField;

            private string sutKoduField;

            private string islemAdiField;

            private double tutarField;

            private double kesintiTutariField;

            private string aciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemSiraNo
            {
                get
                {
                    return this.islemSiraNoField;
                }
                set
                {
                    this.islemSiraNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hizmetSunucuRefNo
            {
                get
                {
                    return this.hizmetSunucuRefNoField;
                }
                set
                {
                    this.hizmetSunucuRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemTarihi
            {
                get
                {
                    return this.islemTarihiField;
                }
                set
                {
                    this.islemTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemAdi
            {
                get
                {
                    return this.islemAdiField;
                }
                set
                {
                    this.islemAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double tutar
            {
                get
                {
                    return this.tutarField;
                }
                set
                {
                    this.tutarField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double kesintiTutari
            {
                get
                {
                    return this.kesintiTutariField;
                }
                set
                {
                    this.kesintiTutariField = value;
                }
            }

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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class evrakKesintiGirisDVO
        {

            private int saglikTesisKoduField;

            private int evrakRefNoField;

            private string grupTuruField;

            private int grupKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string grupTuru
            {
                get
                {
                    return this.grupTuruField;
                }
                set
                {
                    this.grupTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int grupKodu
            {
                get
                {
                    return this.grupKoduField;
                }
                set
                {
                    this.grupKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class katilimPayiDVO
        {

            private string takipNoField;

            private double muayeneKatilimTutariField;

            private double malzemeKatilimTutariField;

            private double tupBebekKatilimTutariField;

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double muayeneKatilimTutari
            {
                get
                {
                    return this.muayeneKatilimTutariField;
                }
                set
                {
                    this.muayeneKatilimTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double malzemeKatilimTutari
            {
                get
                {
                    return this.malzemeKatilimTutariField;
                }
                set
                {
                    this.malzemeKatilimTutariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double tupBebekKatilimTutari
            {
                get
                {
                    return this.tupBebekKatilimTutariField;
                }
                set
                {
                    this.tupBebekKatilimTutariField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class katilimPayiCevapDVO
        {

            private int evrakRefNoField;

            private katilimPayiDVO[] katilimPayiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("katilimPayi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public katilimPayiDVO[] katilimPayi
            {
                get
                {
                    return this.katilimPayiField;
                }
                set
                {
                    this.katilimPayiField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class katilimPayiGirisDVO
        {

            private int saglikTesisKoduField;

            private int evrakRefNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacIndirimDVO
        {

            private string gecerlilikTarihiField;

            private int ilac_idField;

            private double kamuIndOranUstField;

            private double kamuIndOranAltField;

            private double indirimOrani1Field;

            private double indirimOrani2Field;

            private double indirimOrani3Field;

            private double indirimOrani4Field;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string gecerlilikTarihi
            {
                get
                {
                    return this.gecerlilikTarihiField;
                }
                set
                {
                    this.gecerlilikTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int ilac_id
            {
                get
                {
                    return this.ilac_idField;
                }
                set
                {
                    this.ilac_idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double kamuIndOranUst
            {
                get
                {
                    return this.kamuIndOranUstField;
                }
                set
                {
                    this.kamuIndOranUstField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double kamuIndOranAlt
            {
                get
                {
                    return this.kamuIndOranAltField;
                }
                set
                {
                    this.kamuIndOranAltField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double indirimOrani1
            {
                get
                {
                    return this.indirimOrani1Field;
                }
                set
                {
                    this.indirimOrani1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double indirimOrani2
            {
                get
                {
                    return this.indirimOrani2Field;
                }
                set
                {
                    this.indirimOrani2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double indirimOrani3
            {
                get
                {
                    return this.indirimOrani3Field;
                }
                set
                {
                    this.indirimOrani3Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double indirimOrani4
            {
                get
                {
                    return this.indirimOrani4Field;
                }
                set
                {
                    this.indirimOrani4Field = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class fiyatListDVO
        {

            private string gecerlilikTarihiField;

            private double fiyatField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string gecerlilikTarihi
            {
                get
                {
                    return this.gecerlilikTarihiField;
                }
                set
                {
                    this.gecerlilikTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double fiyat
            {
                get
                {
                    return this.fiyatField;
                }
                set
                {
                    this.fiyatField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacListDVO
        {

            private string barkodField;

            private string ilacAdiField;

            private double kullanimBirimiField;

            private fiyatListDVO[] ilacFiyatlariField;

            private ilacIndirimDVO[] ilacIndirimleriField;

            private string eczAktifPasifField;

            private string hasAktifPasifField;

            private string ayaktanOdenmeField;

            private string yatanOdenmeField;

            private double guncelKamuIndirimliFiyatiField;

            private int yatanMaksimumKullanimPeriyotField;

            private int yatanMaksimumKullanimPeriyotBirimField;

            private int yatanMaksimumKullanimDoz1Field;

            private double yatanMaksimumKullanimDoz2Field;

            private int ayaktanMaksimumKullanimPeriyotField;

            private int ayaktanMaksimumKullanimPeriyotBirimField;

            private int ayaktanMaksimumKullanimDoz1Field;

            private double ayaktanMaksimumKullanimDoz2Field;

            private double esdegerGrupFiyatiField;

            private double esdegerKullanimBirimiField;

            private string esdegerBarkodField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string barkod
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
            public double kullanimBirimi
            {
                get
                {
                    return this.kullanimBirimiField;
                }
                set
                {
                    this.kullanimBirimiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacFiyatlari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public fiyatListDVO[] ilacFiyatlari
            {
                get
                {
                    return this.ilacFiyatlariField;
                }
                set
                {
                    this.ilacFiyatlariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacIndirimleri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ilacIndirimDVO[] ilacIndirimleri
            {
                get
                {
                    return this.ilacIndirimleriField;
                }
                set
                {
                    this.ilacIndirimleriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string eczAktifPasif
            {
                get
                {
                    return this.eczAktifPasifField;
                }
                set
                {
                    this.eczAktifPasifField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hasAktifPasif
            {
                get
                {
                    return this.hasAktifPasifField;
                }
                set
                {
                    this.hasAktifPasifField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ayaktanOdenme
            {
                get
                {
                    return this.ayaktanOdenmeField;
                }
                set
                {
                    this.ayaktanOdenmeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yatanOdenme
            {
                get
                {
                    return this.yatanOdenmeField;
                }
                set
                {
                    this.yatanOdenmeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double guncelKamuIndirimliFiyati
            {
                get
                {
                    return this.guncelKamuIndirimliFiyatiField;
                }
                set
                {
                    this.guncelKamuIndirimliFiyatiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int yatanMaksimumKullanimPeriyot
            {
                get
                {
                    return this.yatanMaksimumKullanimPeriyotField;
                }
                set
                {
                    this.yatanMaksimumKullanimPeriyotField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int yatanMaksimumKullanimPeriyotBirim
            {
                get
                {
                    return this.yatanMaksimumKullanimPeriyotBirimField;
                }
                set
                {
                    this.yatanMaksimumKullanimPeriyotBirimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int yatanMaksimumKullanimDoz1
            {
                get
                {
                    return this.yatanMaksimumKullanimDoz1Field;
                }
                set
                {
                    this.yatanMaksimumKullanimDoz1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double yatanMaksimumKullanimDoz2
            {
                get
                {
                    return this.yatanMaksimumKullanimDoz2Field;
                }
                set
                {
                    this.yatanMaksimumKullanimDoz2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int ayaktanMaksimumKullanimPeriyot
            {
                get
                {
                    return this.ayaktanMaksimumKullanimPeriyotField;
                }
                set
                {
                    this.ayaktanMaksimumKullanimPeriyotField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int ayaktanMaksimumKullanimPeriyotBirim
            {
                get
                {
                    return this.ayaktanMaksimumKullanimPeriyotBirimField;
                }
                set
                {
                    this.ayaktanMaksimumKullanimPeriyotBirimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int ayaktanMaksimumKullanimDoz1
            {
                get
                {
                    return this.ayaktanMaksimumKullanimDoz1Field;
                }
                set
                {
                    this.ayaktanMaksimumKullanimDoz1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double ayaktanMaksimumKullanimDoz2
            {
                get
                {
                    return this.ayaktanMaksimumKullanimDoz2Field;
                }
                set
                {
                    this.ayaktanMaksimumKullanimDoz2Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double esdegerGrupFiyati
            {
                get
                {
                    return this.esdegerGrupFiyatiField;
                }
                set
                {
                    this.esdegerGrupFiyatiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double esdegerKullanimBirimi
            {
                get
                {
                    return this.esdegerKullanimBirimiField;
                }
                set
                {
                    this.esdegerKullanimBirimiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string esdegerBarkod
            {
                get
                {
                    return this.esdegerBarkodField;
                }
                set
                {
                    this.esdegerBarkodField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacAraCevapDVO
        {

            private ilacListDVO[] ilaclarField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilaclar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ilacListDVO[] ilaclar
            {
                get
                {
                    return this.ilaclarField;
                }
                set
                {
                    this.ilaclarField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacAraGirisDVO
        {

            private string barkodField;

            private string ilacAdiField;

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string barkod
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class sutFiyatDVO
        {

            private string sutKoduField;

            private string adiField;

            private double fiyatField;

            private int turuField;

            private string gecerlilikTarihiField;

            private string listeAdiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

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
            public double fiyat
            {
                get
                {
                    return this.fiyatField;
                }
                set
                {
                    this.fiyatField = value;
                }
            }

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
            public string gecerlilikTarihi
            {
                get
                {
                    return this.gecerlilikTarihiField;
                }
                set
                {
                    this.gecerlilikTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string listeAdi
            {
                get
                {
                    return this.listeAdiField;
                }
                set
                {
                    this.listeAdiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class guncelSutSorguCevapDVO
        {

            private sutFiyatDVO[] sutKodlariField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("sutKodlari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public sutFiyatDVO[] sutKodlari
            {
                get
                {
                    return this.sutKodlariField;
                }
                set
                {
                    this.sutKodlariField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class guncelSutSorguGirisDVO
        {

            private int saglikTesisKoduField;

            private string tarihField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string tarih
            {
                get
                {
                    return this.tarihField;
                }
                set
                {
                    this.tarihField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class orneklenmisCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private int saglikTesisKoduField;

            private int evrakRefNoField;

            private evrakTakipDVO[] takiplerField;

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
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("takipler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public evrakTakipDVO[] takipler
            {
                get
                {
                    return this.takiplerField;
                }
                set
                {
                    this.takiplerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class orneklenmisGirisDVO
        {

            private int saglikTesisKoduField;

            private int evrakRefNoField;

            private string grupTuruField;

            private int grupKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int evrakRefNo
            {
                get
                {
                    return this.evrakRefNoField;
                }
                set
                {
                    this.evrakRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string grupTuru
            {
                get
                {
                    return this.grupTuruField;
                }
                set
                {
                    this.grupTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int grupKodu
            {
                get
                {
                    return this.grupKoduField;
                }
                set
                {
                    this.grupKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class evrakTakipGrupKoduDVO
        {

            private int koduField;

            private string adiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int kodu
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class evrakTakipGrupKoduSorguCevapDVO
        {

            private evrakTakipGrupKoduDVO[] grupKodlariField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("grupKodlari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public evrakTakipGrupKoduDVO[] grupKodlari
            {
                get
                {
                    return this.grupKodlariField;
                }
                set
                {
                    this.grupKodlariField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class evrakTakipGrupKoduSorguGirisDVO
        {

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eNabizHizmetBilgiDVO
        {

            private string hizmetSunucuRefNoField;

            private string islemKoduField;

            private string islemTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hizmetSunucuRefNo
            {
                get
                {
                    return this.hizmetSunucuRefNoField;
                }
                set
                {
                    this.hizmetSunucuRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemKodu
            {
                get
                {
                    return this.islemKoduField;
                }
                set
                {
                    this.islemKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemTarihi
            {
                get
                {
                    return this.islemTarihiField;
                }
                set
                {
                    this.islemTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eNabizBildirimSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private eNabizHizmetBilgiDVO[] hizmetlerField;

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
            [System.Xml.Serialization.XmlElementAttribute("hizmetler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eNabizHizmetBilgiDVO[] hizmetler
            {
                get
                {
                    return this.hizmetlerField;
                }
                set
                {
                    this.hizmetlerField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eNabizBildirimSorguGirisDVO
        {

            private int saglikTesisKoduField;

            private string takipNoField;

            private string[] hizmetSunucuRefNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("hizmetSunucuRefNo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] hizmetSunucuRefNo
            {
                get
                {
                    return this.hizmetSunucuRefNoField;
                }
                set
                {
                    this.hizmetSunucuRefNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class doktorListDVO
        {

            private string drTescilNoField;

            private string drAdiField;

            private string drSoyadiField;

            private string drDiplomaNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string drTescilNo
            {
                get
                {
                    return this.drTescilNoField;
                }
                set
                {
                    this.drTescilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string drAdi
            {
                get
                {
                    return this.drAdiField;
                }
                set
                {
                    this.drAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string drSoyadi
            {
                get
                {
                    return this.drSoyadiField;
                }
                set
                {
                    this.drSoyadiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string drDiplomaNo
            {
                get
                {
                    return this.drDiplomaNoField;
                }
                set
                {
                    this.drDiplomaNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class doktorAraCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private doktorListDVO[] doktorlarField;

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
            [System.Xml.Serialization.XmlElementAttribute("doktorlar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public doktorListDVO[] doktorlar
            {
                get
                {
                    return this.doktorlarField;
                }
                set
                {
                    this.doktorlarField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class doktorAraGirisDVO
        {

            private int saglikTesisKoduField;

            private string drTescilNoField;

            private string drAdiField;

            private string drSoyadiField;

            private string drDiplomaNoField;

            private string drBransKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string drTescilNo
            {
                get
                {
                    return this.drTescilNoField;
                }
                set
                {
                    this.drTescilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string drAdi
            {
                get
                {
                    return this.drAdiField;
                }
                set
                {
                    this.drAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string drSoyadi
            {
                get
                {
                    return this.drSoyadiField;
                }
                set
                {
                    this.drSoyadiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string drDiplomaNo
            {
                get
                {
                    return this.drDiplomaNoField;
                }
                set
                {
                    this.drDiplomaNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string drBransKodu
            {
                get
                {
                    return this.drBransKoduField;
                }
                set
                {
                    this.drBransKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class damarIziDogrulamaDetayDVO
        {

            private string tckNoField;

            private string islemTarihiField;

            private string bransField;

            private int tesisKoduField;

            private string firmaAdiField;

            private string islemSaatiField;

            private string durumField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tckNo
            {
                get
                {
                    return this.tckNoField;
                }
                set
                {
                    this.tckNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemTarihi
            {
                get
                {
                    return this.islemTarihiField;
                }
                set
                {
                    this.islemTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string brans
            {
                get
                {
                    return this.bransField;
                }
                set
                {
                    this.bransField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            public string firmaAdi
            {
                get
                {
                    return this.firmaAdiField;
                }
                set
                {
                    this.firmaAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemSaati
            {
                get
                {
                    return this.islemSaatiField;
                }
                set
                {
                    this.islemSaatiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string durum
            {
                get
                {
                    return this.durumField;
                }
                set
                {
                    this.durumField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class damarIziDogrulamaSorguCevapDVO
        {

            private damarIziDogrulamaDetayDVO[] damarIziSorguDetayField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("damarIziSorguDetay", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public damarIziDogrulamaDetayDVO[] damarIziSorguDetay
            {
                get
                {
                    return this.damarIziSorguDetayField;
                }
                set
                {
                    this.damarIziSorguDetayField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class damarIziDogrulamaSorguGirisDVO
        {

            private int saglikTesisKoduField;

            private string tckNoField;

            private string islemTarihiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int saglikTesisKodu
            {
                get
                {
                    return this.saglikTesisKoduField;
                }
                set
                {
                    this.saglikTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tckNo
            {
                get
                {
                    return this.tckNoField;
                }
                set
                {
                    this.tckNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string islemTarihi
            {
                get
                {
                    return this.islemTarihiField;
                }
                set
                {
                    this.islemTarihiField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class barkodSutDVO
        {

            private string barkodField;

            private string firmaTanimlayiciNoField;

            private string sutKoduField;

            private string baslangicTarihiField;

            private string bitisTarihiField;

            private string sutListeKoduField;

            private string iptalNedeniField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string barkod
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
            public string firmaTanimlayiciNo
            {
                get
                {
                    return this.firmaTanimlayiciNoField;
                }
                set
                {
                    this.firmaTanimlayiciNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sutKodu
            {
                get
                {
                    return this.sutKoduField;
                }
                set
                {
                    this.sutKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sutListeKodu
            {
                get
                {
                    return this.sutListeKoduField;
                }
                set
                {
                    this.sutListeKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string iptalNedeni
            {
                get
                {
                    return this.iptalNedeniField;
                }
                set
                {
                    this.iptalNedeniField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class barkodSutEslesmeSorguCevapDVO
        {

            private barkodSutDVO[] eslesmelerField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("eslesmeler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public barkodSutDVO[] eslesmeler
            {
                get
                {
                    return this.eslesmelerField;
                }
                set
                {
                    this.eslesmelerField = value;
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
        }


        #endregion Methods
    }
}