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
    /// MEDULA Hizmet Kayıt İşlemleri
    /// </summary>
    public abstract partial class HizmetKayitIslemleri : TTObject
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
        public partial class hizmetIptalGirisDVO
        {

            private string[] islemSiraNumaralariField;

            private int saglikTesisKoduField;

            private string takipNoField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("islemSiraNumaralari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] islemSiraNumaralari
            {
                get
                {
                    return this.islemSiraNumaralariField;
                }
                set
                {
                    this.islemSiraNumaralariField = value;
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
        public partial class utsKesinlestirmeKayitDVO
        {

            private string kullanimBildirimIDField;

            private string tCKimlikNoField;

            private string seriNoField;

            private string lotNoField;

            private string hizmetSunucuReferansNoField;

            private string takipNoField;

            private int saglikTesisKoduField;

            private string durumField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimBildirimID
            {
                get
                {
                    return this.kullanimBildirimIDField;
                }
                set
                {
                    this.kullanimBildirimIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string TCKimlikNo
            {
                get
                {
                    return this.tCKimlikNoField;
                }
                set
                {
                    this.tCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string lotNo
            {
                get
                {
                    return this.lotNoField;
                }
                set
                {
                    this.lotNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hizmetSunucuReferansNo
            {
                get
                {
                    return this.hizmetSunucuReferansNoField;
                }
                set
                {
                    this.hizmetSunucuReferansNoField = value;
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
        public partial class utsKesinlestirmeSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private utsKesinlestirmeKayitDVO[] utsKesinlestirmeKayitDVOField;

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
            [System.Xml.Serialization.XmlElementAttribute("utsKesinlestirmeKayitDVO", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public utsKesinlestirmeKayitDVO[] utsKesinlestirmeKayitDVO
            {
                get
                {
                    return this.utsKesinlestirmeKayitDVOField;
                }
                set
                {
                    this.utsKesinlestirmeKayitDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class utsKesinlestirmeSorguGirisDVO
        {

            private string tckNoField;

            private int saglikTesisKoduField;

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
        public partial class utsKesinlestirmeIptalCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

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
        public partial class utsKesinlestirmeIptalGirisDVO
        {

            private string kullanimBildirimIDField;

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimBildirimID
            {
                get
                {
                    return this.kullanimBildirimIDField;
                }
                set
                {
                    this.kullanimBildirimIDField = value;
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
        public partial class utsKesinlestirmeKayitCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private hataliIslemBilgisiDVO[] hataliKayitlarField;

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
            [System.Xml.Serialization.XmlElementAttribute("hataliKayitlar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public hataliIslemBilgisiDVO[] hataliKayitlar
            {
                get
                {
                    return this.hataliKayitlarField;
                }
                set
                {
                    this.hataliKayitlarField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hataliIslemBilgisiDVO
        {

            private string hataKoduField;

            private string hataMesajiField;

            private string hizmetSunucuRefNoField;

            private oncekiIslemBilgisiDVO oncekiIslemBilgisiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hataKodu
            {
                get
                {
                    return this.hataKoduField;
                }
                set
                {
                    this.hataKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hataMesaji
            {
                get
                {
                    return this.hataMesajiField;
                }
                set
                {
                    this.hataMesajiField = value;
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
            public oncekiIslemBilgisiDVO oncekiIslemBilgisi
            {
                get
                {
                    return this.oncekiIslemBilgisiField;
                }
                set
                {
                    this.oncekiIslemBilgisiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class oncekiIslemBilgisiDVO
        {

            private int islemAdediField;

            private string islemTarihiField;

            private int saglikTesisKoduField;

            private string tesisAdiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int islemAdedi
            {
                get
                {
                    return this.islemAdediField;
                }
                set
                {
                    this.islemAdediField = value;
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
        public partial class utsKesinlestirmeKayitMalzemeDVO
        {

            private string hizmetSunucuRefNoField;

            private string takipNoField;

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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class utsKesinlestirmeKayitGirisDVO
        {

            private utsKesinlestirmeKayitMalzemeDVO[] utsKesinlestirmeKayitMalzemeDVOField;

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("utsKesinlestirmeKayitMalzemeDVO", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public utsKesinlestirmeKayitMalzemeDVO[] utsKesinlestirmeKayitMalzemeDVO
            {
                get
                {
                    return this.utsKesinlestirmeKayitMalzemeDVOField;
                }
                set
                {
                    this.utsKesinlestirmeKayitMalzemeDVOField = value;
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
        public partial class hizmetDVO
        {

            private string triajBeyaniField;

            private kanBilgisiDVO[] kanBilgileriField;

            private string odemeSorguDurumField;

            private ameliyatveGirisimBilgisiDVO[] ameliyatveGirisimBilgileriField;

            private digerIslemBilgisiDVO[] digerIslemBilgileriField;

            private disBilgisiDVO[] disBilgileriField;

            private hastaYatisBilgisiDVO[] hastaYatisBilgileriField;

            private ilacBilgisiDVO[] ilacBilgileriField;

            private konsultasyonBilgisiDVO[] konsultasyonBilgileriField;

            private malzemeBilgisiDVO[] malzemeBilgileriField;

            private muayeneBilgisiDVO muayeneBilgisiField;

            private tahlilBilgisiDVO[] tahlilBilgileriField;

            private string takipNoField;

            private taniBilgisiDVO[] tanilarField;

            private tetkikveRadyolojiBilgisiDVO[] tetkikveRadyolojiBilgileriField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string triajBeyani
            {
                get
                {
                    return this.triajBeyaniField;
                }
                set
                {
                    this.triajBeyaniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("kanBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kanBilgisiDVO[] kanBilgileri
            {
                get
                {
                    return this.kanBilgileriField;
                }
                set
                {
                    this.kanBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string odemeSorguDurum
            {
                get
                {
                    return this.odemeSorguDurumField;
                }
                set
                {
                    this.odemeSorguDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ameliyatveGirisimBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ameliyatveGirisimBilgisiDVO[] ameliyatveGirisimBilgileri
            {
                get
                {
                    return this.ameliyatveGirisimBilgileriField;
                }
                set
                {
                    this.ameliyatveGirisimBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("digerIslemBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public digerIslemBilgisiDVO[] digerIslemBilgileri
            {
                get
                {
                    return this.digerIslemBilgileriField;
                }
                set
                {
                    this.digerIslemBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("disBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public disBilgisiDVO[] disBilgileri
            {
                get
                {
                    return this.disBilgileriField;
                }
                set
                {
                    this.disBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("hastaYatisBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public hastaYatisBilgisiDVO[] hastaYatisBilgileri
            {
                get
                {
                    return this.hastaYatisBilgileriField;
                }
                set
                {
                    this.hastaYatisBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ilacBilgisiDVO[] ilacBilgileri
            {
                get
                {
                    return this.ilacBilgileriField;
                }
                set
                {
                    this.ilacBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("konsultasyonBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public konsultasyonBilgisiDVO[] konsultasyonBilgileri
            {
                get
                {
                    return this.konsultasyonBilgileriField;
                }
                set
                {
                    this.konsultasyonBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public malzemeBilgisiDVO[] malzemeBilgileri
            {
                get
                {
                    return this.malzemeBilgileriField;
                }
                set
                {
                    this.malzemeBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public muayeneBilgisiDVO muayeneBilgisi
            {
                get
                {
                    return this.muayeneBilgisiField;
                }
                set
                {
                    this.muayeneBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tahlilBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public tahlilBilgisiDVO[] tahlilBilgileri
            {
                get
                {
                    return this.tahlilBilgileriField;
                }
                set
                {
                    this.tahlilBilgileriField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("tanilar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public taniBilgisiDVO[] tanilar
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tetkikveRadyolojiBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public tetkikveRadyolojiBilgisiDVO[] tetkikveRadyolojiBilgileri
            {
                get
                {
                    return this.tetkikveRadyolojiBilgileriField;
                }
                set
                {
                    this.tetkikveRadyolojiBilgileriField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class kanBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private System.Nullable<int> adetField;

            private string bransKoduField;

            private string drTescilNoField;

            private string islemSiraNoField;

            private string ozelDurumField;

            private string sutKoduField;

            private string hizmetSunucuRefNoField;

            private string islemTarihiField;

            private string isbtBilesenNoField;

            private string isbtUniteNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string isbtBilesenNo
            {
                get
                {
                    return this.isbtBilesenNoField;
                }
                set
                {
                    this.isbtBilesenNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string isbtUniteNo
            {
                get
                {
                    return this.isbtUniteNoField;
                }
                set
                {
                    this.isbtUniteNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ameliyatveGirisimBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string ozelDurumField;

            private string euroscoreField;

            private string aciklamaField;

            private System.Nullable<int> adetField;

            private string ayniFarkliKesiField;

            private string bransKoduField;

            private string drTescilNoField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string sagSolField;

            private string sutKoduField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string euroscore
            {
                get
                {
                    return this.euroscoreField;
                }
                set
                {
                    this.euroscoreField = value;
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
            public System.Nullable<int> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ayniFarkliKesi
            {
                get
                {
                    return this.ayniFarkliKesiField;
                }
                set
                {
                    this.ayniFarkliKesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSol
            {
                get
                {
                    return this.sagSolField;
                }
                set
                {
                    this.sagSolField = value;
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
        public partial class digerIslemBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string ayniFarkliKesiField;

            private string ozelDurumField;

            private System.Nullable<int> adetField;

            private string bransKoduField;

            private string sutKoduField;

            private string drTescilNoField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string raporTakipNoField;

            private string aciklamaField;

            private string sagSolField;

            private string istemYapanDrTescilNoField;

            private string istemYapanDrBransField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ayniFarkliKesi
            {
                get
                {
                    return this.ayniFarkliKesiField;
                }
                set
                {
                    this.ayniFarkliKesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public string sagSol
            {
                get
                {
                    return this.sagSolField;
                }
                set
                {
                    this.sagSolField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string istemYapanDrTescilNo
            {
                get
                {
                    return this.istemYapanDrTescilNoField;
                }
                set
                {
                    this.istemYapanDrTescilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string istemYapanDrBrans
            {
                get
                {
                    return this.istemYapanDrBransField;
                }
                set
                {
                    this.istemYapanDrBransField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class disBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private System.Nullable<int> disTaahhutNoField;

            private string ayniFarkliKesiField;

            private string ozelDurumField;

            private System.Nullable<int> adetField;

            private string anomaliField;

            private string bransKoduField;

            private string drTescilNoField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string sagAltCeneField;

            private string sagSutAltCeneField;

            private string sagSutUstCeneField;

            private string sagUstCeneField;

            private string solAltCeneField;

            private string solSutAltCeneField;

            private string solSutUstCeneField;

            private string solUstCeneField;

            private string sutKoduField;

            private string sagAltCeneAnomaliDisField;

            private string sagUstCeneAnomaliDisField;

            private string solAltCeneAnomaliDisField;

            private string solUstCeneAnomaliDisField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> disTaahhutNo
            {
                get
                {
                    return this.disTaahhutNoField;
                }
                set
                {
                    this.disTaahhutNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ayniFarkliKesi
            {
                get
                {
                    return this.ayniFarkliKesiField;
                }
                set
                {
                    this.ayniFarkliKesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string anomali
            {
                get
                {
                    return this.anomaliField;
                }
                set
                {
                    this.anomaliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagAltCene
            {
                get
                {
                    return this.sagAltCeneField;
                }
                set
                {
                    this.sagAltCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSutAltCene
            {
                get
                {
                    return this.sagSutAltCeneField;
                }
                set
                {
                    this.sagSutAltCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSutUstCene
            {
                get
                {
                    return this.sagSutUstCeneField;
                }
                set
                {
                    this.sagSutUstCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagUstCene
            {
                get
                {
                    return this.sagUstCeneField;
                }
                set
                {
                    this.sagUstCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solAltCene
            {
                get
                {
                    return this.solAltCeneField;
                }
                set
                {
                    this.solAltCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solSutAltCene
            {
                get
                {
                    return this.solSutAltCeneField;
                }
                set
                {
                    this.solSutAltCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solSutUstCene
            {
                get
                {
                    return this.solSutUstCeneField;
                }
                set
                {
                    this.solSutUstCeneField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solUstCene
            {
                get
                {
                    return this.solUstCeneField;
                }
                set
                {
                    this.solUstCeneField = value;
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
            public string sagAltCeneAnomaliDis
            {
                get
                {
                    return this.sagAltCeneAnomaliDisField;
                }
                set
                {
                    this.sagAltCeneAnomaliDisField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagUstCeneAnomaliDis
            {
                get
                {
                    return this.sagUstCeneAnomaliDisField;
                }
                set
                {
                    this.sagUstCeneAnomaliDisField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solAltCeneAnomaliDis
            {
                get
                {
                    return this.solAltCeneAnomaliDisField;
                }
                set
                {
                    this.solAltCeneAnomaliDisField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string solUstCeneAnomaliDis
            {
                get
                {
                    return this.solUstCeneAnomaliDisField;
                }
                set
                {
                    this.solUstCeneAnomaliDisField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hastaYatisBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string aciklamaField;

            private string ozelDurumField;

            private string bransKoduField;

            private string drTescilNoField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string refakatciGunSayisiField;

            private string sutKoduField;

            private string yatisBaslangicTarihiField;

            private string yatisBitisTarihiField;

            private string yatakKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
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
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string refakatciGunSayisi
            {
                get
                {
                    return this.refakatciGunSayisiField;
                }
                set
                {
                    this.refakatciGunSayisiField = value;
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
            public string yatisBaslangicTarihi
            {
                get
                {
                    return this.yatisBaslangicTarihiField;
                }
                set
                {
                    this.yatisBaslangicTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yatisBitisTarihi
            {
                get
                {
                    return this.yatisBitisTarihiField;
                }
                set
                {
                    this.yatisBitisTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class ilacBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string ozelDurumField;

            private string paketHaricField;

            private string aciklamaField;

            private System.Nullable<double> adetField;

            private string barkodField;

            private string hizmetSunucuRefNoField;

            private string ilacTuruField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private System.Nullable<double> tutarField;

            private string raporTakipNoField;

            private string snField;

            private string sonKullanimTarihiField;

            private string batchNoField;

            private string itsBirimSarfIdField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string paketHaric
            {
                get
                {
                    return this.paketHaricField;
                }
                set
                {
                    this.paketHaricField = value;
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
            public System.Nullable<double> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ilacTuru
            {
                get
                {
                    return this.ilacTuruField;
                }
                set
                {
                    this.ilacTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<double> tutar
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string SN
            {
                get
                {
                    return this.snField;
                }
                set
                {
                    this.snField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sonKullanimTarihi
            {
                get
                {
                    return this.sonKullanimTarihiField;
                }
                set
                {
                    this.sonKullanimTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string batchNo
            {
                get
                {
                    return this.batchNoField;
                }
                set
                {
                    this.batchNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string itsBirimSarfId
            {
                get
                {
                    return this.itsBirimSarfIdField;
                }
                set
                {
                    this.itsBirimSarfIdField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class konsultasyonBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string ozelDurumField;

            private string bransKoduField;

            private string drTescilNoField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string sutKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class malzemeBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private System.Nullable<int> kdvField;

            private string ozelDurumField;

            private string katkiPayiField;

            private string kodsuzMalzemeAdiField;

            private System.Nullable<double> adetField;

            private string barkodField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private System.Nullable<double> kodsuzMalzemeFiyatiField;

            private string malzemeKoduField;

            private string malzemeTuruField;

            private string paketHaricField;

            private string firmaTanimlayiciNoField;

            private string bransKoduField;

            private string drTescilNoField;

            private string malzemeSatinAlisTarihiField;

            private string donorIdField;

            private string ihaleKesinlesmeTarihiField;

            private string ikNoAlimNoField;

            private string bayiNoField;

            private string seriNoField;

            private string lotNoField;

            private string kullanimBildirimIDField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> kdv
            {
                get
                {
                    return this.kdvField;
                }
                set
                {
                    this.kdvField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string katkiPayi
            {
                get
                {
                    return this.katkiPayiField;
                }
                set
                {
                    this.katkiPayiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string kodsuzMalzemeAdi
            {
                get
                {
                    return this.kodsuzMalzemeAdiField;
                }
                set
                {
                    this.kodsuzMalzemeAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<double> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<double> kodsuzMalzemeFiyati
            {
                get
                {
                    return this.kodsuzMalzemeFiyatiField;
                }
                set
                {
                    this.kodsuzMalzemeFiyatiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string malzemeKodu
            {
                get
                {
                    return this.malzemeKoduField;
                }
                set
                {
                    this.malzemeKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string malzemeTuru
            {
                get
                {
                    return this.malzemeTuruField;
                }
                set
                {
                    this.malzemeTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string paketHaric
            {
                get
                {
                    return this.paketHaricField;
                }
                set
                {
                    this.paketHaricField = value;
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
            public string malzemeSatinAlisTarihi
            {
                get
                {
                    return this.malzemeSatinAlisTarihiField;
                }
                set
                {
                    this.malzemeSatinAlisTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string donorId
            {
                get
                {
                    return this.donorIdField;
                }
                set
                {
                    this.donorIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ihaleKesinlesmeTarihi
            {
                get
                {
                    return this.ihaleKesinlesmeTarihiField;
                }
                set
                {
                    this.ihaleKesinlesmeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ikNoAlimNo
            {
                get
                {
                    return this.ikNoAlimNoField;
                }
                set
                {
                    this.ikNoAlimNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string bayiNo
            {
                get
                {
                    return this.bayiNoField;
                }
                set
                {
                    this.bayiNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string seriNo
            {
                get
                {
                    return this.seriNoField;
                }
                set
                {
                    this.seriNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string lotNo
            {
                get
                {
                    return this.lotNoField;
                }
                set
                {
                    this.lotNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string kullanimBildirimID
            {
                get
                {
                    return this.kullanimBildirimIDField;
                }
                set
                {
                    this.kullanimBildirimIDField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class muayeneBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string ozelDurumField;

            private string bransKoduField;

            private string drTescilNoField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string muayeneTarihiField;

            private string sutKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string muayeneTarihi
            {
                get
                {
                    return this.muayeneTarihiField;
                }
                set
                {
                    this.muayeneTarihiField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class tahlilBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private tahlilSonucDVO[] tahlilSonuclariField;

            private string ozelDurumField;

            private System.Nullable<int> adetField;

            private string bransKoduField;

            private string drTescilNoField;

            private string istemYapanDrTescilNoField;

            private string istemYapanDrBransField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string sutKoduField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tahlilSonuclari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public tahlilSonucDVO[] tahlilSonuclari
            {
                get
                {
                    return this.tahlilSonuclariField;
                }
                set
                {
                    this.tahlilSonuclariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public string istemYapanDrTescilNo
            {
                get
                {
                    return this.istemYapanDrTescilNoField;
                }
                set
                {
                    this.istemYapanDrTescilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string istemYapanDrBrans
            {
                get
                {
                    return this.istemYapanDrBransField;
                }
                set
                {
                    this.istemYapanDrBransField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
        public partial class tahlilSonucDVO
        {

            private string islemSiraNoField;

            private string sonucField;

            private string tahlilTipiField;

            private string birimField;

            private string ayniFarkliKesiField;

            private string sagSolField;

            private string aciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sonuc
            {
                get
                {
                    return this.sonucField;
                }
                set
                {
                    this.sonucField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string tahlilTipi
            {
                get
                {
                    return this.tahlilTipiField;
                }
                set
                {
                    this.tahlilTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string birim
            {
                get
                {
                    return this.birimField;
                }
                set
                {
                    this.birimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ayniFarkliKesi
            {
                get
                {
                    return this.ayniFarkliKesiField;
                }
                set
                {
                    this.ayniFarkliKesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSol
            {
                get
                {
                    return this.sagSolField;
                }
                set
                {
                    this.sagSolField = value;
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
        public partial class taniBilgisiDVO
        {

            private string[] cokluOzelDurumField;

            private string ozelDurumField;

            private string islemSiraNoField;

            private string hizmetSunucuRefNoField;

            private string birincilTaniField;

            private string taniKoduField;

            private string taniTipiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string birincilTani
            {
                get
                {
                    return this.birincilTaniField;
                }
                set
                {
                    this.birincilTaniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string taniTipi
            {
                get
                {
                    return this.taniTipiField;
                }
                set
                {
                    this.taniTipiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class tetkikveRadyolojiBilgisiDVO
        {

            private string modalityField;

            private string[] cokluOzelDurumField;

            private string sagSolField;

            private string ayniFarkliKesiField;

            private string aciklamaField;

            private string birimField;

            private string sonucField;

            private string ozelDurumField;

            private System.Nullable<int> adetField;

            private string bransKoduField;

            private string drTescilNoField;

            private string istemYapanDrTescilNoField;

            private string istemYapanDrBransField;

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string sutKoduField;

            private string accessionField;

            private string raporTakipNoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string modality
            {
                get
                {
                    return this.modalityField;
                }
                set
                {
                    this.modalityField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("cokluOzelDurum", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] cokluOzelDurum
            {
                get
                {
                    return this.cokluOzelDurumField;
                }
                set
                {
                    this.cokluOzelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sagSol
            {
                get
                {
                    return this.sagSolField;
                }
                set
                {
                    this.sagSolField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ayniFarkliKesi
            {
                get
                {
                    return this.ayniFarkliKesiField;
                }
                set
                {
                    this.ayniFarkliKesiField = value;
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
            public string birim
            {
                get
                {
                    return this.birimField;
                }
                set
                {
                    this.birimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string sonuc
            {
                get
                {
                    return this.sonucField;
                }
                set
                {
                    this.sonucField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string ozelDurum
            {
                get
                {
                    return this.ozelDurumField;
                }
                set
                {
                    this.ozelDurumField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> adet
            {
                get
                {
                    return this.adetField;
                }
                set
                {
                    this.adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public string istemYapanDrTescilNo
            {
                get
                {
                    return this.istemYapanDrTescilNoField;
                }
                set
                {
                    this.istemYapanDrTescilNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string istemYapanDrBrans
            {
                get
                {
                    return this.istemYapanDrBransField;
                }
                set
                {
                    this.istemYapanDrBransField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public string accession
            {
                get
                {
                    return this.accessionField;
                }
                set
                {
                    this.accessionField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hizmetOkuCevapDVO
        {

            private string hastaBasvuruNoField;

            private hizmetDVO hizmetlerField;

            private string sonucKoduField;

            private string sonucMesajiField;

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
            public hizmetDVO hizmetler
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
        public partial class hizmetOkuGirisDVO
        {

            private string[] islemSiraNumaralariField;

            private int saglikTesisKoduField;

            private string takipNoField;

            private string[] hizmetSunucuRefNolariField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("islemSiraNumaralari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] islemSiraNumaralari
            {
                get
                {
                    return this.islemSiraNumaralariField;
                }
                set
                {
                    this.islemSiraNumaralariField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("hizmetSunucuRefNolari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] hizmetSunucuRefNolari
            {
                get
                {
                    return this.hizmetSunucuRefNolariField;
                }
                set
                {
                    this.hizmetSunucuRefNolariField = value;
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
        public partial class kayitliIslemBilgisiDVO
        {

            private string hizmetSunucuRefNoField;

            private string islemSiraNoField;

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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hizmetKayitCevapDVO
        {

            private string hastaBasvuruNoField;

            private hataliIslemBilgisiDVO[] hataliKayitlarField;

            private kayitliIslemBilgisiDVO[] islemBilgileriField;

            private string saglikTesisKoduField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string takipNoField;

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
            [System.Xml.Serialization.XmlElementAttribute("hataliKayitlar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public hataliIslemBilgisiDVO[] hataliKayitlar
            {
                get
                {
                    return this.hataliKayitlarField;
                }
                set
                {
                    this.hataliKayitlarField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("islemBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kayitliIslemBilgisiDVO[] islemBilgileri
            {
                get
                {
                    return this.islemBilgileriField;
                }
                set
                {
                    this.islemBilgileriField = value;
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hizmetKayitGirisDVO
        {

            private string triajBeyaniField;

            private kanBilgisiDVO[] kanBilgileriField;

            private ameliyatveGirisimBilgisiDVO[] ameliyatveGirisimBilgileriField;

            private digerIslemBilgisiDVO[] digerIslemBilgileriField;

            private disBilgisiDVO[] disBilgileriField;

            private string hastaBasvuruNoField;

            private hastaYatisBilgisiDVO[] hastaYatisBilgileriField;

            private ilacBilgisiDVO[] ilacBilgileriField;

            private konsultasyonBilgisiDVO[] konsultasyonBilgileriField;

            private malzemeBilgisiDVO[] malzemeBilgileriField;

            private muayeneBilgisiDVO muayeneBilgisiField;

            private int saglikTesisKoduField;

            private tahlilBilgisiDVO[] tahlilBilgileriField;

            private string takipNoField;

            private taniBilgisiDVO[] tanilarField;

            private tetkikveRadyolojiBilgisiDVO[] tetkikveRadyolojiBilgileriField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string triajBeyani
            {
                get
                {
                    return this.triajBeyaniField;
                }
                set
                {
                    this.triajBeyaniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("kanBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public kanBilgisiDVO[] kanBilgileri
            {
                get
                {
                    return this.kanBilgileriField;
                }
                set
                {
                    this.kanBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ameliyatveGirisimBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ameliyatveGirisimBilgisiDVO[] ameliyatveGirisimBilgileri
            {
                get
                {
                    return this.ameliyatveGirisimBilgileriField;
                }
                set
                {
                    this.ameliyatveGirisimBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("digerIslemBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public digerIslemBilgisiDVO[] digerIslemBilgileri
            {
                get
                {
                    return this.digerIslemBilgileriField;
                }
                set
                {
                    this.digerIslemBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("disBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public disBilgisiDVO[] disBilgileri
            {
                get
                {
                    return this.disBilgileriField;
                }
                set
                {
                    this.disBilgileriField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("hastaYatisBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public hastaYatisBilgisiDVO[] hastaYatisBilgileri
            {
                get
                {
                    return this.hastaYatisBilgileriField;
                }
                set
                {
                    this.hastaYatisBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("ilacBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public ilacBilgisiDVO[] ilacBilgileri
            {
                get
                {
                    return this.ilacBilgileriField;
                }
                set
                {
                    this.ilacBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("konsultasyonBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public konsultasyonBilgisiDVO[] konsultasyonBilgileri
            {
                get
                {
                    return this.konsultasyonBilgileriField;
                }
                set
                {
                    this.konsultasyonBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public malzemeBilgisiDVO[] malzemeBilgileri
            {
                get
                {
                    return this.malzemeBilgileriField;
                }
                set
                {
                    this.malzemeBilgileriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public muayeneBilgisiDVO muayeneBilgisi
            {
                get
                {
                    return this.muayeneBilgisiField;
                }
                set
                {
                    this.muayeneBilgisiField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("tahlilBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public tahlilBilgisiDVO[] tahlilBilgileri
            {
                get
                {
                    return this.tahlilBilgileriField;
                }
                set
                {
                    this.tahlilBilgileriField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("tanilar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public taniBilgisiDVO[] tanilar
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("tetkikveRadyolojiBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public tetkikveRadyolojiBilgisiDVO[] tetkikveRadyolojiBilgileri
            {
                get
                {
                    return this.tetkikveRadyolojiBilgileriField;
                }
                set
                {
                    this.tetkikveRadyolojiBilgileriField = value;
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
        public partial class hizmetIptalCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

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
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class hizmetIptalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal hizmetIptalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public hizmetIptalCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((hizmetIptalCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class hizmetKayitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal hizmetKayitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public hizmetKayitCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((hizmetKayitCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class hizmetOkuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal hizmetOkuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public hizmetOkuCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((hizmetOkuCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class utsKullanimKesinlestirmeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal utsKullanimKesinlestirmeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public utsKesinlestirmeKayitCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((utsKesinlestirmeKayitCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class utsKullanimKesinlestirmeIptalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal utsKullanimKesinlestirmeIptalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public utsKesinlestirmeIptalCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((utsKesinlestirmeIptalCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class utsKullanimKesinlestirmeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal utsKullanimKesinlestirmeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public utsKesinlestirmeSorguCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((utsKesinlestirmeSorguCevapDVO)(this.results[0]));
                }
            }
        }
                          
        #endregion Methods

    }
}