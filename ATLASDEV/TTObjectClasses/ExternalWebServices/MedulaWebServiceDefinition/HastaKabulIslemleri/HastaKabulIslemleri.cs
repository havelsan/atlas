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
    /// MEDULA Hasta Kabul İşlemleri
    /// </summary>
    public abstract partial class HastaKabulIslemleri : TTObject
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
        public partial class basvuruTakipOkuDVO
        {

            private string hastaBasvuruNoField;

            private int saglikTesisKoduField;

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
        public partial class tedaviTuruDegistirCevapDVO
        {

            private string takipNoField;

            private string yeniTedaviTuruField;

            private string hastaBasvuruNoField;

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yeniTedaviTuru
            {
                get
                {
                    return this.yeniTedaviTuruField;
                }
                set
                {
                    this.yeniTedaviTuruField = value;
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
        public partial class tedaviTuruDegistirGirisDVO
        {

            private string takipNoField;

            private string yeniTedaviTuruField;

            private string yatisBitisTarihiField;

            private int saglikTesisKoduField;

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
            public string yeniTedaviTuru
            {
                get
                {
                    return this.yeniTedaviTuruField;
                }
                set
                {
                    this.yeniTedaviTuruField = value;
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
        public partial class takipTipiDegistirCevapDVO
        {

            private string takipNoField;

            private string yeniTakipTipiField;

            private string hastaBasvuruNoField;

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yeniTakipTipi
            {
                get
                {
                    return this.yeniTakipTipiField;
                }
                set
                {
                    this.yeniTakipTipiField = value;
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
        public partial class takipTipiDegistirGirisDVO
        {

            private string takipNoField;

            private string yeniTakiTipiField;

            private int saglikTesisKoduField;

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
            public string yeniTakiTipi
            {
                get
                {
                    return this.yeniTakiTipiField;
                }
                set
                {
                    this.yeniTakiTipiField = value;
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
        public partial class provizyonDegistirCevapDVO
        {

            private string hastaBasvuruNoField;

            private string takipNoField;

            private string yeniProvizyonTipiField;

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
            public string yeniProvizyonTipi
            {
                get
                {
                    return this.yeniProvizyonTipiField;
                }
                set
                {
                    this.yeniProvizyonTipiField = value;
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
        public partial class provizyonDegistirGirisDVO
        {

            private string takipNoField;

            private string yeniProvizyonTipiField;

            private int saglikTesisKoduField;

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
            public string yeniProvizyonTipi
            {
                get
                {
                    return this.yeniProvizyonTipiField;
                }
                set
                {
                    this.yeniProvizyonTipiField = value;
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
        public partial class sevkBildirSonucDVO
        {

            private string sevkEdilisTarihiField;

            private string takipNoField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sevkEdilisTarihi
            {
                get
                {
                    return this.sevkEdilisTarihiField;
                }
                set
                {
                    this.sevkEdilisTarihiField = value;
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
        public partial class sevkBildirGirisDVO
        {

            private string takipNoField;

            private string sevkEdilisTarihiField;

            private int saglikTesisKoduField;

            private string yesilKartSevkEdilenBransKoduField;

            private int yesilKartSevkEdilenTedaviTipiField;

            private string yesilKartSevkEdilenTakipTipiField;

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
            public string sevkEdilisTarihi
            {
                get
                {
                    return this.sevkEdilisTarihiField;
                }
                set
                {
                    this.sevkEdilisTarihiField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int yesilKartSevkEdilenTedaviTipi
            {
                get
                {
                    return this.yesilKartSevkEdilenTedaviTipiField;
                }
                set
                {
                    this.yesilKartSevkEdilenTedaviTipiField = value;
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
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class basvuruYatisBilgileriDVO
        {

            private string baslangicTarihiField;

            private string bitisTarihiField;

            private string durumField;

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
        public partial class hastaYatisOkuCevapDVO
        {

            private string donorTckField;

            private string yeniDoganCocukSiraNoField;

            private string yeniDoganDogumTarihiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private basvuruYatisBilgileriDVO[] basvuruYatisBilgileriField;

            private string hastaBasvuruNoField;

            private int saglikTesisiKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string donorTck
            {
                get
                {
                    return this.donorTckField;
                }
                set
                {
                    this.donorTckField = value;
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
            [System.Xml.Serialization.XmlElementAttribute("basvuruYatisBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public basvuruYatisBilgileriDVO[] basvuruYatisBilgileri
            {
                get
                {
                    return this.basvuruYatisBilgileriField;
                }
                set
                {
                    this.basvuruYatisBilgileriField = value;
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
            public int saglikTesisiKodu
            {
                get
                {
                    return this.saglikTesisiKoduField;
                }
                set
                {
                    this.saglikTesisiKoduField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class hastaYatisOkuDVO
        {

            private string hastaBasvuruNoField;

            private int saglikTesisKoduField;

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
        public partial class takipOkuGirisDVO
        {

            private string takipNoField;

            private System.Nullable<int> yeniTedaviTipiField;

            private int saglikTesisKoduField;

            private string ktsHbysKoduField;

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
            public System.Nullable<int> yeniTedaviTipi
            {
                get
                {
                    return this.yeniTedaviTipiField;
                }
                set
                {
                    this.yeniTedaviTipiField = value;
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
        public partial class takipSilCevapDVO
        {

            private string takipNoField;

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
        public partial class takipSilGirisDVO
        {

            private int saglikTesisKoduField;

            private string takipNoField;

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
        public partial class sigortaliAdliGecmisDVO
        {

            private string tckNoField;

            private string provTipiField;

            private string provTarihiField;

            private string vakaTarihiField;

            private string plakaNoField;

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
            public string provTipi
            {
                get
                {
                    return this.provTipiField;
                }
                set
                {
                    this.provTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string provTarihi
            {
                get
                {
                    return this.provTarihiField;
                }
                set
                {
                    this.provTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string vakaTarihi
            {
                get
                {
                    return this.vakaTarihiField;
                }
                set
                {
                    this.vakaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string plakaNo
            {
                get
                {
                    return this.plakaNoField;
                }
                set
                {
                    this.plakaNoField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class provizyonCevapDVO
        {

            private string takipNoField;

            private string hastaBasvuruNoField;

            private hastaBilgileriDVO hastaBilgileriField;

            private sigortaliAdliGecmisDVO[] sigortaliAdliGecmisiField;

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
            [System.Xml.Serialization.XmlElementAttribute("sigortaliAdliGecmisi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public sigortaliAdliGecmisDVO[] sigortaliAdliGecmisi
            {
                get
                {
                    return this.sigortaliAdliGecmisiField;
                }
                set
                {
                    this.sigortaliAdliGecmisiField = value;
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
        public partial class yeniDoganBilgisiDVO
        {

            private string dogumTarihiField;

            private System.Nullable<int> cocukSiraField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> cocukSira
            {
                get
                {
                    return this.cocukSiraField;
                }
                set
                {
                    this.cocukSiraField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class provizyonGirisDVO
        {

            private string hastaTCKimlikNoField;

            private string provizyonTarihiField;

            private int saglikTesisKoduField;

            private string bransKoduField;

            private string provizyonTipiField;

            private string tedaviTuruField;

            private string tedaviTipiField;

            private string kurumSevkTalepNoField;

            private string takipTipiField;

            private string takipNoField;

            private string istisnaiHalField;

            private string yatisBitisTarihiField;

            private yeniDoganBilgisiDVO yeniDoganBilgisiField;

            private string donorTCKimlikNoField;

            private System.Nullable<int> yesilKartSevkEdenTesisKoduField;

            private System.Nullable<int> yesilKartSevkEdenTedaviTipiField;

            private string yesilKartSevkEdenTakipTipiField;

            private System.Nullable<int> yardimHakkiIDField;

            private string plakaNoField;

            private string devredilenKurumField;

            private string sigortaliTuruField;

            private string yakinlikKoduField;

            private string hastaTelefonField;

            private string hastaAdresField;

            private string vakaTarihiField;

            private string ktsHbysKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaTCKimlikNo
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            public yeniDoganBilgisiDVO yeniDoganBilgisi
            {
                get
                {
                    return this.yeniDoganBilgisiField;
                }
                set
                {
                    this.yeniDoganBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> yesilKartSevkEdenTesisKodu
            {
                get
                {
                    return this.yesilKartSevkEdenTesisKoduField;
                }
                set
                {
                    this.yesilKartSevkEdenTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> yesilKartSevkEdenTedaviTipi
            {
                get
                {
                    return this.yesilKartSevkEdenTedaviTipiField;
                }
                set
                {
                    this.yesilKartSevkEdenTedaviTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yesilKartSevkEdenTakipTipi
            {
                get
                {
                    return this.yesilKartSevkEdenTakipTipiField;
                }
                set
                {
                    this.yesilKartSevkEdenTakipTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> yardimHakkiID
            {
                get
                {
                    return this.yardimHakkiIDField;
                }
                set
                {
                    this.yardimHakkiIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string plakaNo
            {
                get
                {
                    return this.plakaNoField;
                }
                set
                {
                    this.plakaNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yakinlikKodu
            {
                get
                {
                    return this.yakinlikKoduField;
                }
                set
                {
                    this.yakinlikKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string vakaTarihi
            {
                get
                {
                    return this.vakaTarihiField;
                }
                set
                {
                    this.vakaTarihiField = value;
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
        public partial class hastaCikisDVO
        {

            private string hastaBasvuruNoField;

            private string hastaCikisTarihiField;

            private int saglikTesisKoduField;

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
            public string hastaCikisTarihi
            {
                get
                {
                    return this.hastaCikisTarihiField;
                }
                set
                {
                    this.hastaCikisTarihiField = value;
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
        public partial class hastaCikisCevapDVO
        {

            private string yatisBaslangicTarihiField;

            private string yatisBitisTarihiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        public partial class hastaCikisIptalDVO
        {

            private string hastaBasvuruNoField;

            private string hastaCikisTarihiField;

            private string yeniHastaCikisTarihiField;

            private int saglikTesisKoduField;

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
            public string hastaCikisTarihi
            {
                get
                {
                    return this.hastaCikisTarihiField;
                }
                set
                {
                    this.hastaCikisTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string yeniHastaCikisTarihi
            {
                get
                {
                    return this.yeniHastaCikisTarihiField;
                }
                set
                {
                    this.yeniHastaCikisTarihiField = value;
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
        public partial class yesilKartliHastaSevkBilgileriDVO
        {

            private string takipNoField;

            private string sevkEdilmeTarihiField;

            private int sevkEdenTesisKoduField;

            private string sevkEdilenBransKoduField;

            private string provizyonTipiField;

            private string tedaviTuruField;

            private string tedaviTipiField;

            private string bransKoduField;

            private string takipTipiField;

            private string sevkEdilenTesisAdiField;

            private string sevkEdilenTakipTipiField;

            private string sevkEdilenTedaviTipiField;

            private string sevkAciklamaField;

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
            public string sevkEdilmeTarihi
            {
                get
                {
                    return this.sevkEdilmeTarihiField;
                }
                set
                {
                    this.sevkEdilmeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int sevkEdenTesisKodu
            {
                get
                {
                    return this.sevkEdenTesisKoduField;
                }
                set
                {
                    this.sevkEdenTesisKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sevkEdilenBransKodu
            {
                get
                {
                    return this.sevkEdilenBransKoduField;
                }
                set
                {
                    this.sevkEdilenBransKoduField = value;
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
            public string sevkEdilenTesisAdi
            {
                get
                {
                    return this.sevkEdilenTesisAdiField;
                }
                set
                {
                    this.sevkEdilenTesisAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sevkEdilenTakipTipi
            {
                get
                {
                    return this.sevkEdilenTakipTipiField;
                }
                set
                {
                    this.sevkEdilenTakipTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sevkEdilenTedaviTipi
            {
                get
                {
                    return this.sevkEdilenTedaviTipiField;
                }
                set
                {
                    this.sevkEdilenTedaviTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sevkAciklama
            {
                get
                {
                    return this.sevkAciklamaField;
                }
                set
                {
                    this.sevkAciklamaField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class yesilKartliSevkliHastaCevapDVO
        {

            private hastaBilgileriDVO hastaBilgileriField;

            private yesilKartliHastaSevkBilgileriDVO[] yesilKartliHastaSevkBilgileriField;

            private string sonucKoduField;

            private string sonucMesajiField;

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
            [System.Xml.Serialization.XmlElementAttribute("yesilKartliHastaSevkBilgileri", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public yesilKartliHastaSevkBilgileriDVO[] yesilKartliHastaSevkBilgileri
            {
                get
                {
                    return this.yesilKartliHastaSevkBilgileriField;
                }
                set
                {
                    this.yesilKartliHastaSevkBilgileriField = value;
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
        public partial class yesilKartliSevkliHastaGirisDVO
        {

            private string hastaTCKNoField;

            private int saglikTesisKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hastaTCKNo
            {
                get
                {
                    return this.hastaTCKNoField;
                }
                set
                {
                    this.hastaTCKNoField = value;
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
        public partial class mustehaklikCevapDVO
        {

            private long kapsamTuruField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long kapsamTuru
            {
                get
                {
                    return this.kapsamTuruField;
                }
                set
                {
                    this.kapsamTuruField = value;
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
        public partial class mustehaklikGirisDVO
        {

            private long tcKimlikNoField;

            private string tarihField;

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
        public partial class basvuruTakipDVO
        {

            private string takipNoField;

            private string takipFaturaDurumuField;

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
            public string takipFaturaDurumu
            {
                get
                {
                    return this.takipFaturaDurumuField;
                }
                set
                {
                    this.takipFaturaDurumuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class basvuruTakipOkuCevapDVO
        {

            private basvuruTakipDVO[] basvuruTakipField;

            private string hastaBasvuruNoField;

            private string sonucKoduField;

            private string sonucMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("basvuruTakip", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public basvuruTakipDVO[] basvuruTakip
            {
                get
                {
                    return this.basvuruTakipField;
                }
                set
                {
                    this.basvuruTakipField = value;
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