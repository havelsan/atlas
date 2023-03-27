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
    public partial class TibbiMalzemeERaporIslemleri : TTObject
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
        public partial class eRaporGirisIstekDVO
        {

            private int tesisKoduField;

            private string doktorTcKimlikNoField;

            private eRaporGirisDVO eRaporDVOField;

            public eRaporGirisIstekDVO()
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
            public eRaporGirisDVO eRaporDVO
            {
                get
                {
                    return eRaporDVOField;
                }
                set
                {
                    eRaporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eRaporGirisDVO
        {

            private long tcKimlikNoField;

            private string raporTarihiField;

            private string raporBitisTarihiField;

            private int tesisKoduField;

            private string protokolNoField;

            private string raporNoField;

            private string takipNoField;

            private System.Nullable<long> odyometriTestIdField;

            private int raporDuzenlemeTuruKoduField;

            private string aciklamaField;

            private string raporOnayDurumuField;

            private eMalzemeGirisDVO[] malzemeListesiField;

            private doktorDVO[] doktorListesiField;

            private eTaniDVO[] taniListesiField;

            public eRaporGirisDVO()
            {
                tcKimlikNoField = ((long)(0));
                raporTarihiField = "dd.MM.yyyy";
                raporBitisTarihiField = "dd.MM.yyyy";
                tesisKoduField = 0;
                protokolNoField = "";
                raporNoField = "0";
                takipNoField = "";
                odyometriTestIdField = ((long)(0));
                raporDuzenlemeTuruKoduField = 2;
                aciklamaField = "";
                raporOnayDurumuField = "2";
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporBitisTarihi
            {
                get
                {
                    return raporBitisTarihiField;
                }
                set
                {
                    raporBitisTarihiField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("0")]
            public string raporNo
            {
                get
                {
                    return raporNoField;
                }
                set
                {
                    raporNoField = value;
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
            public System.Nullable<long> odyometriTestId
            {
                get
                {
                    return odyometriTestIdField;
                }
                set
                {
                    odyometriTestIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int raporDuzenlemeTuruKodu
            {
                get
                {
                    return raporDuzenlemeTuruKoduField;
                }
                set
                {
                    raporDuzenlemeTuruKoduField = value;
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("2")]
            public string raporOnayDurumu
            {
                get
                {
                    return raporOnayDurumuField;
                }
                set
                {
                    raporOnayDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eMalzemeGirisDVO[] malzemeListesi
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
            [System.Xml.Serialization.XmlElementAttribute("doktorListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public doktorDVO[] doktorListesi
            {
                get
                {
                    return doktorListesiField;
                }
                set
                {
                    doktorListesiField = value;
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
        public partial class imzaliERaporMalzemeEkleCevapDVO
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
        public partial class imzaliERaporMalzemeEkleIstekDVO
        {

            private byte[] imzaliERaporMalzemeField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporMalzemeEkleIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliERaporMalzeme
            {
                get
                {
                    return imzaliERaporMalzemeField;
                }
                set
                {
                    imzaliERaporMalzemeField = value;
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
        public partial class eRaporMalzemeEkleIstekDVO
        {

            private int tesisKoduField;

            private long doktorTcKimlikNoField;

            private string raporTakipNoField;

            private eMalzemeGirisDVO[] malzemeListesiField;

            public eRaporMalzemeEkleIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = ((long)(0));
                raporTakipNoField = "";
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
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eMalzemeGirisDVO[] malzemeListesi
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliERaporAciklamaGuncelleCevapDVO
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
        public partial class imzaliERaporAciklamaGuncelleIstekDVO
        {

            private byte[] imzaliERaporAciklamaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporAciklamaGuncelleIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliERaporAciklama
            {
                get
                {
                    return imzaliERaporAciklamaField;
                }
                set
                {
                    imzaliERaporAciklamaField = value;
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
        public partial class eRaporAciklamaGuncelleIstekDVO
        {

            private int tesisKoduField;

            private long doktorTcKimlikNoField;

            private string raporTakipNoField;

            private string aciklamaField;

            public eRaporAciklamaGuncelleIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = ((long)(0));
                raporTakipNoField = "";
                aciklamaField = "";
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
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliERaporTaniEkleCevapDVO
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
        public partial class imzaliERaporTaniEkleIstekDVO
        {

            private byte[] imzaliERaporTaniField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporTaniEkleIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliERaporTani
            {
                get
                {
                    return imzaliERaporTaniField;
                }
                set
                {
                    imzaliERaporTaniField = value;
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
        public partial class eRaporTaniEkleIstekDVO
        {

            private int tesisKoduField;

            private long doktorTcKimlikNoField;

            private string raporTakipNoField;

            private eTaniDVO[] taniListesiField;

            public eRaporTaniEkleIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = ((long)(0));
                raporTakipNoField = "";
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
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
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
        public partial class eRaporDoktorOnayBilgisiDVO
        {

            private string doktorTCKimlikNoField;

            private string doktorAdiField;

            private string doktorSoyadiField;

            private int onayKoduField;

            private string onayKoduAciklamaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorTCKimlikNo
            {
                get
                {
                    return doktorTCKimlikNoField;
                }
                set
                {
                    doktorTCKimlikNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorAdi
            {
                get
                {
                    return doktorAdiField;
                }
                set
                {
                    doktorAdiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string doktorSoyadi
            {
                get
                {
                    return doktorSoyadiField;
                }
                set
                {
                    doktorSoyadiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int onayKodu
            {
                get
                {
                    return onayKoduField;
                }
                set
                {
                    onayKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string onayKoduAciklama
            {
                get
                {
                    return onayKoduAciklamaField;
                }
                set
                {
                    onayKoduAciklamaField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eRaporOnayBilgisiCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private string raporTakipNoField;

            private eRaporDoktorOnayBilgisiDVO[] doktorOnayListesiField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("doktorOnayListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eRaporDoktorOnayBilgisiDVO[] doktorOnayListesi
            {
                get
                {
                    return doktorOnayListesiField;
                }
                set
                {
                    doktorOnayListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eRaporOnayBilgisiIstekDVO
        {

            private int tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            public eRaporOnayBilgisiIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = "";
                raporTakipNoField = "";
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
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class onayBekleyenRaporCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private string[] onaysizRaporTakipListesiField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("onaysizRaporTakipListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] onaysizRaporTakipListesi
            {
                get
                {
                    return onaysizRaporTakipListesiField;
                }
                set
                {
                    onaysizRaporTakipListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class doktorOnaysizRaporDVO
        {

            private string tcKimlikNoField;

            private string adiField;

            private string soyadiField;

            private string[] onaysizRaporTakipListesiField;

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
            [System.Xml.Serialization.XmlElementAttribute("onaysizRaporTakipListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string[] onaysizRaporTakipListesi
            {
                get
                {
                    return onaysizRaporTakipListesiField;
                }
                set
                {
                    onaysizRaporTakipListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class onayBekleyenTesisRaporCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private doktorOnaysizRaporDVO[] onaysizDoktorRaporListesiField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("onaysizDoktorRaporListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public doktorOnaysizRaporDVO[] onaysizDoktorRaporListesi
            {
                get
                {
                    return onaysizDoktorRaporListesiField;
                }
                set
                {
                    onaysizDoktorRaporListesiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class onayBekleyenRaporIstekDVO
        {

            private int tesisKoduField;

            private string doktorTcKimlikNoField;

            public onayBekleyenRaporIstekDVO()
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
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class imzaliERaporSilCevapDVO
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
        public partial class imzaliERaporSilIstekDVO
        {

            private byte[] imzaliEraporField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporSilIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliErapor
            {
                get
                {
                    return imzaliEraporField;
                }
                set
                {
                    imzaliEraporField = value;
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
        public partial class imzaliERaporListeSorguIstekDVO
        {

            private byte[] imzaliEraporListeSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporListeSorguIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporListeSorgula
            {
                get
                {
                    return imzaliEraporListeSorgulaField;
                }
                set
                {
                    imzaliEraporListeSorgulaField = value;
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
        public partial class imzaliERaporSorguCevapDVO
        {

            private eRaporDVO[] raporListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eRaporDVO[] raporListesi
            {
                get
                {
                    return raporListesiField;
                }
                set
                {
                    raporListesiField = value;
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
        public partial class eRaporDVO
        {

            private long tcKimlikNoField;

            private string raporTarihiField;

            private string raporBitisTarihiField;

            private int tesisKoduField;

            private string protokolNoField;

            private string raporNoField;

            private string raporTakipNoField;

            private string takipNoField;

            private System.Nullable<long> odyometriTestIdField;

            private int raporDuzenlemeTuruKoduField;

            private string raporDuzenlemeTuruAdiField;

            private string aciklamaField;

            private string raporOnayDurumuField;

            private eMalzemeCevapDVO[] malzemeListesiField;

            private doktorDVO[] doktorListesiField;

            private eTaniDVO[] taniListesiField;

            public eRaporDVO()
            {
                tcKimlikNoField = ((long)(0));
                raporTarihiField = "dd.MM.yyyy";
                raporBitisTarihiField = "dd.MM.yyyy";
                tesisKoduField = 0;
                protokolNoField = "";
                raporNoField = "0";
                raporTakipNoField = "0";
                takipNoField = "";
                odyometriTestIdField = ((long)(0));
                raporDuzenlemeTuruKoduField = 2;
                raporDuzenlemeTuruAdiField = "";
                aciklamaField = "";
                raporOnayDurumuField = "TASLAK";
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string raporBitisTarihi
            {
                get
                {
                    return raporBitisTarihiField;
                }
                set
                {
                    raporBitisTarihiField = value;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("0")]
            public string raporNo
            {
                get
                {
                    return raporNoField;
                }
                set
                {
                    raporNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("0")]
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
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
            public System.Nullable<long> odyometriTestId
            {
                get
                {
                    return odyometriTestIdField;
                }
                set
                {
                    odyometriTestIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int raporDuzenlemeTuruKodu
            {
                get
                {
                    return raporDuzenlemeTuruKoduField;
                }
                set
                {
                    raporDuzenlemeTuruKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("")]
            public string raporDuzenlemeTuruAdi
            {
                get
                {
                    return raporDuzenlemeTuruAdiField;
                }
                set
                {
                    raporDuzenlemeTuruAdiField = value;
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("TASLAK")]
            public string raporOnayDurumu
            {
                get
                {
                    return raporOnayDurumuField;
                }
                set
                {
                    raporOnayDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eMalzemeCevapDVO[] malzemeListesi
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
            [System.Xml.Serialization.XmlElementAttribute("doktorListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public doktorDVO[] doktorListesi
            {
                get
                {
                    return doktorListesiField;
                }
                set
                {
                    doktorListesiField = value;
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
        public partial class eMalzemeCevapDVO
        {

            private string sutKoduField;

            private string malzemeAdiField;

            private string malzemeGrubuKoduField;

            private string malzemeGrubuAdiField;

            private string kullanimYeriField;

            private string kullanimYeriAdiField;

            private string kullanimSekliField;

            private string kullanimSekliAdiField;

            private string kullanimPeriyoduField;

            private System.Nullable<int> kullanimPeriyodBirimField;

            private string kullanimPeriyodBirimAdiField;

            private System.Nullable<int> adetField;

            private string degistirmeRaporuField;

            public eMalzemeCevapDVO()
            {
                sutKoduField = "";
                malzemeGrubuKoduField = "R";
                malzemeGrubuAdiField = "";
                kullanimYeriField = "F";
                kullanimYeriAdiField = "";
                kullanimSekliField = "";
                kullanimSekliAdiField = "";
                kullanimPeriyoduField = "0";
                kullanimPeriyodBirimField = 0;
                kullanimPeriyodBirimAdiField = "";
                adetField = 1;
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.ComponentModel.DefaultValueAttribute("F")]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            [System.ComponentModel.DefaultValueAttribute("0")]
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
            public System.Nullable<int> adet
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
            [System.ComponentModel.DefaultValueAttribute("H")]
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
        public partial class imzaliERaporSorguIstekDVO
        {

            private byte[] imzaliEraporSorgulaField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporSorguIstekDVO()
            {
                tesisKoduField = "0";
                doktorTcKimlikNoField = "0";
                surumNumarasiField = "1";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliEraporSorgula
            {
                get
                {
                    return imzaliEraporSorgulaField;
                }
                set
                {
                    imzaliEraporSorgulaField = value;
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
        public partial class imzaliERaporGirisCevapDVO
        {

            private eRaporDVO eRaporDVOField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eRaporDVO eRaporDVO
            {
                get
                {
                    return eRaporDVOField;
                }
                set
                {
                    eRaporDVOField = value;
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
        public partial class imzaliERaporGirisIstekDVO
        {

            private byte[] imzaliEraporField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public imzaliERaporGirisIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliErapor
            {
                get
                {
                    return imzaliEraporField;
                }
                set
                {
                    imzaliEraporField = value;
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
        public partial class eRaporListeSorguIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string hastaTcKimlikNoField;

            public eRaporListeSorguIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                hastaTcKimlikNoField = "";
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
            public string hastaTcKimlikNo
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
        public partial class eRaporOnayCevapDVO
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
        public partial class eRaporOnayIstekDVO
        {

            private int tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            private int onayKodField;

            public eRaporOnayIstekDVO()
            {
                tesisKoduField = 0;
                doktorTcKimlikNoField = "";
                onayKodField = 1;
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
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int onayKod
            {
                get
                {
                    return onayKodField;
                }
                set
                {
                    onayKodField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eRaporSorguCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eRaporDVO[] raporCevapField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("raporCevap", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public eRaporDVO[] raporCevap
            {
                get
                {
                    return raporCevapField;
                }
                set
                {
                    raporCevapField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eRaporCevapDVO
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
        public partial class eRaporSorguIstekDVO
        {

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string raporTakipNoField;

            public eRaporSorguIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                raporTakipNoField = "";
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
            public string raporTakipNo
            {
                get
                {
                    return raporTakipNoField;
                }
                set
                {
                    raporTakipNoField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class eRaporGirisCevapDVO
        {

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            private eRaporDVO eRaporDVOField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public eRaporDVO eRaporDVO
            {
                get
                {
                    return eRaporDVOField;
                }
                set
                {
                    eRaporDVOField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporGirisCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporGirisCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporGirisCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporGirisCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporSilCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporSilCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class doktorERaporOnayVeIptalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal doktorERaporOnayVeIptalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporOnayCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporOnayCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class bashekimERaporOnayVeIptalCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal bashekimERaporOnayVeIptalCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporOnayCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporOnayCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporListeSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporListeSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporGirisCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporGirisCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporGirisCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporGirisCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporListeSorguCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporListeSorguCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporSorguCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporSorguCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporSilCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporSilCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporSilCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporSilCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class doktorOnayiBekleyenRaporlarTesisBazliSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal doktorOnayiBekleyenRaporlarTesisBazliSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public onayBekleyenTesisRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((onayBekleyenTesisRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class doktorOnayiBekleyenRaporlarDoktorBazliSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal doktorOnayiBekleyenRaporlarDoktorBazliSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public onayBekleyenRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((onayBekleyenRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class bashekimOnayiBekleyenRaporlarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal bashekimOnayiBekleyenRaporlarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public onayBekleyenRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((onayBekleyenRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class raporOnayDetayiSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal raporOnayDetayiSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporOnayBilgisiCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporOnayBilgisiCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporTaniEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporTaniEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporTaniEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporTaniEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporTaniEkleCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporTaniEkleCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporAciklamaGuncelleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporAciklamaGuncelleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporAciklamaGuncelleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporAciklamaGuncelleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporAciklamaGuncelleCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporAciklamaGuncelleCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class eRaporMalzemeEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal eRaporMalzemeEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public eRaporCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((eRaporCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class imzaliERaporMalzemeEkleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal imzaliERaporMalzemeEkleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public imzaliERaporMalzemeEkleCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((imzaliERaporMalzemeEkleCevapDVO)(results[0]));
                }
            }
        }




        #endregion Methods
    }
}