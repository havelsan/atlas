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
    public abstract partial class FaturaKayitIslemleri : TTObject
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
        public partial class faturaIptalGirisDVO
        {

            private string[] faturaTeslimNoField;

            private int saglikTesisKoduField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("faturaTeslimNo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string[] faturaTeslimNo
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
        public partial class itsIlacBilgisiDVO
        {

            private string itsBirimSarfIdField;

            private string islemSiraNoField;

            private string islemTarihiField;

            private string barkodField;

            private string seriNoField;

            private int adetField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            public int adet
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
        public partial class takipIlacBilgisiDVO
        {

            private string takipNoField;

            private itsIlacBilgisiDVO[] ilacBilgisiField;

            private string sonucKoduField;

            private string sonucMesajiField;

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
            [System.Xml.Serialization.XmlElementAttribute("ilacBilgisi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public itsIlacBilgisiDVO[] ilacBilgisi
            {
                get
                {
                    return this.ilacBilgisiField;
                }
                set
                {
                    this.ilacBilgisiField = value;
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
        public partial class itsIslemCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private takipIlacBilgisiDVO[] takipIlacBilgisiField;

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
            [System.Xml.Serialization.XmlElementAttribute("takipIlacBilgisi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public takipIlacBilgisiDVO[] takipIlacBilgisi
            {
                get
                {
                    return this.takipIlacBilgisiField;
                }
                set
                {
                    this.takipIlacBilgisiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class itsIslemGirisDVO
        {

            private int saglikTesisKoduField;

            private string hastaBasvuruNoField;

            private string islemTipiField;

            private string[] takipNumaralariField;

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
            public string islemTipi
            {
                get
                {
                    return this.islemTipiField;
                }
                set
                {
                    this.islemTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("takipNumaralari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string[] takipNumaralari
            {
                get
                {
                    return this.takipNumaralariField;
                }
                set
                {
                    this.takipNumaralariField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class faturaCevapDetayDVO
        {

            private string aciklamaField;

            private islemDetayDVO[] islemDetaylariField;

            private string protokolNoField;

            private string taburcuKoduField;

            private string takipNoField;

            private double takipToplamTutarField;

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
            [System.Xml.Serialization.XmlElementAttribute("islemDetaylari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public islemDetayDVO[] islemDetaylari
            {
                get
                {
                    return this.islemDetaylariField;
                }
                set
                {
                    this.islemDetaylariField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string taburcuKodu
            {
                get
                {
                    return this.taburcuKoduField;
                }
                set
                {
                    this.taburcuKoduField = value;
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
            public double takipToplamTutar
            {
                get
                {
                    return this.takipToplamTutarField;
                }
                set
                {
                    this.takipToplamTutarField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class islemDetayDVO
        {

            private string islemSiraNoField;

            private double islemTutariField;

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
            public double islemTutari
            {
                get
                {
                    return this.islemTutariField;
                }
                set
                {
                    this.islemTutariField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class faturaOkuCevapDVO
        {

            private faturaCevapDetayDVO[] faturaDetaylariField;

            private string faturaRefNoField;

            private string faturaTarihiField;

            private string faturaTeslimNoField;

            private double faturaTutariField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("faturaDetaylari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public faturaCevapDetayDVO[] faturaDetaylari
            {
                get
                {
                    return this.faturaDetaylariField;
                }
                set
                {
                    this.faturaDetaylariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string faturaRefNo
            {
                get
                {
                    return this.faturaRefNoField;
                }
                set
                {
                    this.faturaRefNoField = value;
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
            public double faturaTutari
            {
                get
                {
                    return this.faturaTutariField;
                }
                set
                {
                    this.faturaTutariField = value;
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
        public partial class faturaOkuGirisDVO
        {

            private string faturaTeslimNoField;

            private string faturaRefNoField;

            private string faturaTarihiField;

            private int saglikTesisKoduField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string faturaRefNo
            {
                get
                {
                    return this.faturaRefNoField;
                }
                set
                {
                    this.faturaRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
        public partial class faturaHataDVO
        {

            private string takipNoField;

            private string hataKoduField;

            private string hataMesajiField;

            private string hizmetSunucuRefNoField;

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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class faturaDetayDVO
        {

            private string takipNoField;

            private double takipToplamTutarField;

            private islemDetayDVO[] islemDetaylariField;

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
            public double takipToplamTutar
            {
                get
                {
                    return this.takipToplamTutarField;
                }
                set
                {
                    this.takipToplamTutarField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("islemDetaylari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public islemDetayDVO[] islemDetaylari
            {
                get
                {
                    return this.islemDetaylariField;
                }
                set
                {
                    this.islemDetaylariField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class faturaCevapDVO
        {

            private string faturaTeslimNoField;

            private double faturaTutariField;

            private string hastaBasvuruNoField;

            private string faturaRefNoField;

            private faturaDetayDVO[] faturaDetaylariField;

            private faturaHataDVO[] hataliKayitlarField;

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
            public double faturaTutari
            {
                get
                {
                    return this.faturaTutariField;
                }
                set
                {
                    this.faturaTutariField = value;
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
            public string faturaRefNo
            {
                get
                {
                    return this.faturaRefNoField;
                }
                set
                {
                    this.faturaRefNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("faturaDetaylari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public faturaDetayDVO[] faturaDetaylari
            {
                get
                {
                    return this.faturaDetaylariField;
                }
                set
                {
                    this.faturaDetaylariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("hataliKayitlar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public faturaHataDVO[] hataliKayitlar
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
        public partial class hizmetDetayDVO
        {

            private string takipNoField;

            private string protokolNoField;

            private string taburcuKoduField;

            private string aciklamaField;

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string taburcuKodu
            {
                get
                {
                    return this.taburcuKoduField;
                }
                set
                {
                    this.taburcuKoduField = value;
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
        public partial class faturaGirisDVO
        {

            private string hastaBasvuruNoField;

            private string faturaTarihiField;

            private string faturaRefNoField;

            private int saglikTesisKoduField;

            private hizmetDetayDVO[] hizmetDetaylariField;

            private string yesilKartSevkEdilenBransKoduField;

            private System.Nullable<int> yesilKartSevkEdilenTesisKoduField;

            private string yesilKartSevkEdilenTesisAdiField;

            private string yesilKartSevkEdilenTakipTipiField;

            private string yesilKartSevkEdilenAciklamaField;

            private System.Nullable<int> trafikKazasiOdemeYuzdesiField;

            private double ilaveUcretField;

            private string ktsHbysKoduField;

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
            public string faturaRefNo
            {
                get
                {
                    return this.faturaRefNoField;
                }
                set
                {
                    this.faturaRefNoField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("hizmetDetaylari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public hizmetDetayDVO[] hizmetDetaylari
            {
                get
                {
                    return this.hizmetDetaylariField;
                }
                set
                {
                    this.hizmetDetaylariField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yesilKartSevkEdilenBransKodu
            {
                get
                {
                    return this.yesilKartSevkEdilenBransKoduField;
                }
                set
                {
                    this.yesilKartSevkEdilenBransKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> yesilKartSevkEdilenTesisKodu
            {
                get
                {
                    return this.yesilKartSevkEdilenTesisKoduField;
                }
                set
                {
                    this.yesilKartSevkEdilenTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yesilKartSevkEdilenTesisAdi
            {
                get
                {
                    return this.yesilKartSevkEdilenTesisAdiField;
                }
                set
                {
                    this.yesilKartSevkEdilenTesisAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yesilKartSevkEdilenTakipTipi
            {
                get
                {
                    return this.yesilKartSevkEdilenTakipTipiField;
                }
                set
                {
                    this.yesilKartSevkEdilenTakipTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yesilKartSevkEdilenAciklama
            {
                get
                {
                    return this.yesilKartSevkEdilenAciklamaField;
                }
                set
                {
                    this.yesilKartSevkEdilenAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> trafikKazasiOdemeYuzdesi
            {
                get
                {
                    return this.trafikKazasiOdemeYuzdesiField;
                }
                set
                {
                    this.trafikKazasiOdemeYuzdesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public double ilaveUcret
            {
                get
                {
                    return this.ilaveUcretField;
                }
                set
                {
                    this.ilaveUcretField = value;
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
        public partial class faturaIptalHataliKayitDVO
        {

            private string faturaTeslimNoField;

            private string hataKoduField;

            private string hataMesajiField;

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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class faturaIptalCevapDVO
        {

            private faturaIptalHataliKayitDVO[] hataliKayitlarField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("hataliKayitlar", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public faturaIptalHataliKayitDVO[] hataliKayitlar
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
        public partial class faturaIptalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal faturaIptalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public faturaIptalCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((faturaIptalCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class faturaKayitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal faturaKayitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public faturaCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((faturaCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class faturaOkuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal faturaOkuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public faturaOkuCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((faturaOkuCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class faturaTutarOkuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal faturaTutarOkuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public faturaCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((faturaCevapDVO)(this.results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class itsIlacIslemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal itsIlacIslemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public itsIslemCevapDVO Result
            {
                get
                {
                    this.RaiseExceptionIfNecessary();
                    return ((itsIslemCevapDVO)(this.results[0]));
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