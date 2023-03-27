using TTInstanceManagement;


namespace TTObjectClasses
{
    public partial class TibbiMalzemeEReceteIslemleri : TTObject
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
        public partial class eReceteGirisIstekDVO
        {

            private int tesisKoduField;

            private string doktorTcKimlikNoField;

            private eReceteDVO eReceteDVOField;

            public eReceteGirisIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
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
            public eReceteDVO eReceteDVO
            {
                get
                {
                    return eReceteDVOField;
                }
                set
                {
                    eReceteDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteDVO
        {

            private long tcKimlikNoField;

            private int tesisKoduField;

            private string receteTarihiField;

            private int receteTuruField;

            private string provizyonTipiField;

            private string takipNoField;

            private string protokolNoField;

            private doktorDVO receteYazanDoktorBilgisiField;

            private eReceteAciklamaDVO receteAciklamaField;

            private eReceteMalzemeGirisDVO[] malzemeListesiField;

            private eTaniDVO[] taniListesiField;

            public eReceteDVO()
            {
                tcKimlikNoField = ((long)(0));
                tesisKoduField = 0;
                receteTarihiField = "dd.MM.yyyy";
                receteTuruField = 0;
                provizyonTipiField = "";
                takipNoField = "";
                protokolNoField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long tcKimlikNo
            {
                get
                {
                    return tcKimlikNoField;
                }
                set
                {
                    tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string receteTarihi
            {
                get
                {
                    return receteTarihiField;
                }
                set
                {
                    receteTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int receteTuru
            {
                get
                {
                    return receteTuruField;
                }
                set
                {
                    receteTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string provizyonTipi
            {
                get
                {
                    return provizyonTipiField;
                }
                set
                {
                    provizyonTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipNo
            {
                get
                {
                    return takipNoField;
                }
                set
                {
                    takipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string protokolNo
            {
                get
                {
                    return protokolNoField;
                }
                set
                {
                    protokolNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public doktorDVO receteYazanDoktorBilgisi
            {
                get
                {
                    return receteYazanDoktorBilgisiField;
                }
                set
                {
                    receteYazanDoktorBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eReceteAciklamaDVO receteAciklama
            {
                get
                {
                    return receteAciklamaField;
                }
                set
                {
                    receteAciklamaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eReceteMalzemeGirisDVO[] malzemeListesi
            {
                get
                {
                    return malzemeListesiField;
                }
                set
                {
                    malzemeListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("taniListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eTaniDVO[] taniListesi
            {
                get
                {
                    return taniListesiField;
                }
                set
                {
                    taniListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class doktorDVO
        {

            private string tcKimlikNoField;

            private string bransKoduField;

            private string bransAdiField;

            private string adiField;

            private string soyadiField;

            private System.Nullable<int> doktorIdField;

            public doktorDVO()
            {
                tcKimlikNoField = "";
                bransKoduField = "";
                bransAdiField = "";
                adiField = "";
                soyadiField = "";
                doktorIdField = 0;
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tcKimlikNo
            {
                get
                {
                    return tcKimlikNoField;
                }
                set
                {
                    tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bransKodu
            {
                get
                {
                    return bransKoduField;
                }
                set
                {
                    bransKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string bransAdi
            {
                get
                {
                    return bransAdiField;
                }
                set
                {
                    bransAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string soyadi
            {
                get
                {
                    return soyadiField;
                }
                set
                {
                    soyadiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> doktorId
            {
                get
                {
                    return doktorIdField;
                }
                set
                {
                    doktorIdField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteTaniEkleIstekDVO
        {

            private byte[] imzaliEreceteTaniField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliEReceteTaniEkleIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEreceteTani
            {
                get
                {
                    return imzaliEreceteTaniField;
                }
                set
                {
                    imzaliEreceteTaniField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
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
            public string surumNumarasi
            {
                get
                {
                    return surumNumarasiField;
                }
                set
                {
                    surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteSorguCevapDVO
        {

            private eReceteCevapDVO eReceteCevapField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eReceteCevapDVO eReceteCevap
            {
                get
                {
                    return eReceteCevapField;
                }
                set
                {
                    eReceteCevapField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteCevapDVO
        {

            private string eReceteNoField;

            private long tcKimlikNoField;

            private int tesisKoduField;

            private string receteTarihiField;

            private int receteTuruField;

            private string receteTuruAdiField;

            private int provizyonTipiField;

            private string provizyonTipiAdiField;

            private string takipNoField;

            private string protokolNoField;

            private doktorDVO doktorBilgisiField;

            private eReceteMalzemeDVO[] malzemeListesiField;

            private eTaniDVO[] taniListesiField;

            private eReceteAciklamaDVO receteAciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string eReceteNo
            {
                get
                {
                    return eReceteNoField;
                }
                set
                {
                    eReceteNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long tcKimlikNo
            {
                get
                {
                    return tcKimlikNoField;
                }
                set
                {
                    tcKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string receteTarihi
            {
                get
                {
                    return receteTarihiField;
                }
                set
                {
                    receteTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int receteTuru
            {
                get
                {
                    return receteTuruField;
                }
                set
                {
                    receteTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string receteTuruAdi
            {
                get
                {
                    return receteTuruAdiField;
                }
                set
                {
                    receteTuruAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int provizyonTipi
            {
                get
                {
                    return provizyonTipiField;
                }
                set
                {
                    provizyonTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string provizyonTipiAdi
            {
                get
                {
                    return provizyonTipiAdiField;
                }
                set
                {
                    provizyonTipiAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string takipNo
            {
                get
                {
                    return takipNoField;
                }
                set
                {
                    takipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string protokolNo
            {
                get
                {
                    return protokolNoField;
                }
                set
                {
                    protokolNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public doktorDVO doktorBilgisi
            {
                get
                {
                    return doktorBilgisiField;
                }
                set
                {
                    doktorBilgisiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eReceteMalzemeDVO[] malzemeListesi
            {
                get
                {
                    return malzemeListesiField;
                }
                set
                {
                    malzemeListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("taniListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eTaniDVO[] taniListesi
            {
                get
                {
                    return taniListesiField;
                }
                set
                {
                    taniListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eReceteAciklamaDVO receteAciklama
            {
                get
                {
                    return receteAciklamaField;
                }
                set
                {
                    receteAciklamaField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteMalzemeDVO
        {

            private string malzemeSutKoduField;

            private int raporIdField;

            private string malzemeGrubuKoduField;

            private string malzemeGrubuAdiField;

            private string malzemeAdiField;

            private string kullanimYeriField;

            private string kullanimYeriAdiField;

            private string kullanimSekliField;

            private string kullanimSekliAdiField;

            private int adetField;

            private System.Nullable<int> kullanimPeriyodField;

            private System.Nullable<int> kullanimPeriyodBirimField;

            private string kullanimPeriyodBirimAdiField;

            private System.Nullable<int> malzemeButIdField;

            private System.Nullable<int> malzemeBransReferansKoduField;

            public eReceteMalzemeDVO()
            {
                malzemeSutKoduField = "";
                raporIdField = 0;
                malzemeGrubuKoduField = "";
                malzemeGrubuAdiField = "";
                malzemeAdiField = "";
                kullanimYeriField = "F";
                kullanimYeriAdiField = "";
                kullanimSekliField = "";
                kullanimSekliAdiField = "";
                adetField = 0;
                kullanimPeriyodField = 0;
                kullanimPeriyodBirimField = 0;
                kullanimPeriyodBirimAdiField = "";
                malzemeButIdField = 0;
                malzemeBransReferansKoduField = 0;
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string malzemeSutKodu
            {
                get
                {
                    return malzemeSutKoduField;
                }
                set
                {
                    malzemeSutKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int raporId
            {
                get
                {
                    return raporIdField;
                }
                set
                {
                    raporIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string malzemeGrubuKodu
            {
                get
                {
                    return malzemeGrubuKoduField;
                }
                set
                {
                    malzemeGrubuKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string malzemeGrubuAdi
            {
                get
                {
                    return malzemeGrubuAdiField;
                }
                set
                {
                    malzemeGrubuAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string malzemeAdi
            {
                get
                {
                    return malzemeAdiField;
                }
                set
                {
                    malzemeAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kullanimYeri
            {
                get
                {
                    return kullanimYeriField;
                }
                set
                {
                    kullanimYeriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string kullanimYeriAdi
            {
                get
                {
                    return kullanimYeriAdiField;
                }
                set
                {
                    kullanimYeriAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string kullanimSekli
            {
                get
                {
                    return kullanimSekliField;
                }
                set
                {
                    kullanimSekliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string kullanimSekliAdi
            {
                get
                {
                    return kullanimSekliAdiField;
                }
                set
                {
                    kullanimSekliAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int adet
            {
                get
                {
                    return adetField;
                }
                set
                {
                    adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> kullanimPeriyod
            {
                get
                {
                    return kullanimPeriyodField;
                }
                set
                {
                    kullanimPeriyodField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> kullanimPeriyodBirim
            {
                get
                {
                    return kullanimPeriyodBirimField;
                }
                set
                {
                    kullanimPeriyodBirimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string kullanimPeriyodBirimAdi
            {
                get
                {
                    return kullanimPeriyodBirimAdiField;
                }
                set
                {
                    kullanimPeriyodBirimAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> malzemeButId
            {
                get
                {
                    return malzemeButIdField;
                }
                set
                {
                    malzemeButIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> malzemeBransReferansKodu
            {
                get
                {
                    return malzemeBransReferansKoduField;
                }
                set
                {
                    malzemeBransReferansKoduField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eTaniDVO
        {

            private string taniKoduField;

            private string taniAdiField;

            public eTaniDVO()
            {
                taniKoduField = "";
                taniAdiField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string taniKodu
            {
                get
                {
                    return taniKoduField;
                }
                set
                {
                    taniKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string taniAdi
            {
                get
                {
                    return taniAdiField;
                }
                set
                {
                    taniAdiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteAciklamaDVO
        {

            private System.Nullable<int> aciklamaTuruField;

            private string aciklamaField;

            public eReceteAciklamaDVO()
            {
                aciklamaTuruField = 0;
                aciklamaField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> aciklamaTuru
            {
                get
                {
                    return aciklamaTuruField;
                }
                set
                {
                    aciklamaTuruField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteSorguIstekDVO
        {

            private byte[] imzaliEreceteSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliEReceteSorguIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEreceteSorgula
            {
                get
                {
                    return imzaliEreceteSorgulaField;
                }
                set
                {
                    imzaliEreceteSorgulaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
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
            public string surumNumarasi
            {
                get
                {
                    return surumNumarasiField;
                }
                set
                {
                    surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteSilCevapDVO
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteSilIstekDVO
        {

            private byte[] imzaliEreceteField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliEReceteSilIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliErecete
            {
                get
                {
                    return imzaliEreceteField;
                }
                set
                {
                    imzaliEreceteField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
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
            public string surumNumarasi
            {
                get
                {
                    return surumNumarasiField;
                }
                set
                {
                    surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteListeSorguCevapDVO
        {

            private eReceteCevapDVO[] receteListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("receteListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eReceteCevapDVO[] receteListesi
            {
                get
                {
                    return receteListesiField;
                }
                set
                {
                    receteListesiField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteListeSorguIstekDVO
        {

            private byte[] imzaliEreceteListeSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliEReceteListeSorguIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEreceteListeSorgula
            {
                get
                {
                    return imzaliEreceteListeSorgulaField;
                }
                set
                {
                    imzaliEreceteListeSorgulaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
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
            public string surumNumarasi
            {
                get
                {
                    return surumNumarasiField;
                }
                set
                {
                    surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteGirisCevapDVO
        {

            private eReceteCevapDVO eReceteDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eReceteCevapDVO eReceteDVO
            {
                get
                {
                    return eReceteDVOField;
                }
                set
                {
                    eReceteDVOField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliEReceteGirisIstekDVO
        {

            private byte[] imzaliEreceteField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliEReceteGirisIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliErecete
            {
                get
                {
                    return imzaliEreceteField;
                }
                set
                {
                    imzaliEreceteField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTcKimlikNo
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
            public string surumNumarasi
            {
                get
                {
                    return surumNumarasiField;
                }
                set
                {
                    surumNumarasiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteTaniEkleCevapDVO
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteTaniEkleIstekDVO
        {

            private string ereceteNoField;

            private int tesisKoduField;

            private long doktorTcKimlikNoField;

            private eTaniDVO[] taniListesiField;

            public eReceteTaniEkleIstekDVO()
            {
                ereceteNoField = "";
                tesisKoduField = 0;
                doktorTcKimlikNoField = ((long)(0));
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ereceteNo
            {
                get
                {
                    return ereceteNoField;
                }
                set
                {
                    ereceteNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long doktorTcKimlikNo
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
            [System.Xml.Serialization.XmlElementAttribute("taniListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eTaniDVO[] taniListesi
            {
                get
                {
                    return taniListesiField;
                }
                set
                {
                    taniListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteSorguCevapDVO
        {

            private eReceteCevapDVO eReceteCevapField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eReceteCevapDVO eReceteCevap
            {
                get
                {
                    return eReceteCevapField;
                }
                set
                {
                    eReceteCevapField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteSilCevapDVO
        {

            private string eReceteNoField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string eReceteNo
            {
                get
                {
                    return eReceteNoField;
                }
                set
                {
                    eReceteNoField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteSorguIstekDVO
        {

            private int tesisKoduField;

            private string ereceteNoField;

            private long doktorTcKimlikNoField;

            public eReceteSorguIstekDVO()
            {
                tesisKoduField = 0;
                ereceteNoField = "";
                doktorTcKimlikNoField = ((long)(0));
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ereceteNo
            {
                get
                {
                    return ereceteNoField;
                }
                set
                {
                    ereceteNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long doktorTcKimlikNo
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteListeSorguCevapDVO
        {

            private eReceteCevapDVO[] receteCevapDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("receteCevapDVO", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eReceteCevapDVO[] receteCevapDVO
            {
                get
                {
                    return receteCevapDVOField;
                }
                set
                {
                    receteCevapDVOField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteListeSorguIstekDVO
        {

            private int tesisKoduField;

            private long doktorTcKimlikNoField;

            private long hastaTcKimlikNoField;

            public eReceteListeSorguIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = ((long)(0));
                hastaTcKimlikNoField = ((long)(0));
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int tesisKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long doktorTcKimlikNo
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
            public long hastaTcKimlikNo
            {
                get
                {
                    return hastaTcKimlikNoField;
                }
                set
                {
                    hastaTcKimlikNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteGirisCevapDVO
        {

            private eReceteCevapDVO eReceteDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eReceteCevapDVO eReceteDVO
            {
                get
                {
                    return eReceteDVOField;
                }
                set
                {
                    eReceteDVOField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eMalzemeGirisDVO
        {

            private string sutKoduField;

            private string kullanimYeriField;

            private string kullanimSekliField;

            private string kullanimPeriyoduField;

            private System.Nullable<int> kullanimPeriyodBirimField;

            private int adetField;

            private string degistirmeRaporuField;

            public eMalzemeGirisDVO()
            {
                sutKoduField = "";
                kullanimYeriField = "F";
                kullanimSekliField = "";
                kullanimPeriyoduField = "0";
                kullanimPeriyodBirimField = 0;
                adetField = 0;
                degistirmeRaporuField = "H";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sutKodu
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string kullanimYeri
            {
                get
                {
                    return kullanimYeriField;
                }
                set
                {
                    kullanimYeriField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string kullanimSekli
            {
                get
                {
                    return kullanimSekliField;
                }
                set
                {
                    kullanimSekliField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string kullanimPeriyodu
            {
                get
                {
                    return kullanimPeriyoduField;
                }
                set
                {
                    kullanimPeriyoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<int> kullanimPeriyodBirim
            {
                get
                {
                    return kullanimPeriyodBirimField;
                }
                set
                {
                    kullanimPeriyodBirimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int adet
            {
                get
                {
                    return adetField;
                }
                set
                {
                    adetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string degistirmeRaporu
            {
                get
                {
                    return degistirmeRaporuField;
                }
                set
                {
                    degistirmeRaporuField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eReceteMalzemeGirisDVO
        {

            private int raporIdField;

            private eMalzemeGirisDVO receteMalzemeField;

            public eReceteMalzemeGirisDVO()
            {
                raporIdField = 0;
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int raporId
            {
                get
                {
                    return raporIdField;
                }
                set
                {
                    raporIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eMalzemeGirisDVO receteMalzeme
            {
                get
                {
                    return receteMalzemeField;
                }
                set
                {
                    receteMalzemeField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eReceteGirisCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eReceteGirisCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eReceteGirisCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eReceteGirisCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eReceteListeSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eReceteListeSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eReceteListeSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eReceteListeSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eReceteSilCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eReceteSilCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eReceteSilCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eReceteSilCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eReceteSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eReceteSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eReceteSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eReceteSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eReceteTaniEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eReceteTaniEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eReceteTaniEkleCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eReceteTaniEkleCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEReceteGirisCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEReceteGirisCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEReceteGirisCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliEReceteGirisCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEReceteListeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEReceteListeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEReceteListeSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliEReceteListeSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEReceteSilCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEReceteSilCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEReceteSilCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliEReceteSilCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEReceteSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEReceteSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliEReceteSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliEReceteSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliEReceteTaniEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliEReceteTaniEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eReceteTaniEkleCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eReceteTaniEkleCevapDVO)(results[0]));
                }
            }
        }





        #endregion Methods
    }
}