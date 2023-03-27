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
    /// SKRS Sistemler
    /// </summary>
    public partial class SKRSSistemlerServis : TTObject
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
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class wsskrsSistemlerResponse
        {

            private hata hataField;

            private responseSistemler[] sistemlerField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public hata hata
            {
                get
                {
                    return hataField;
                }
                set
                {
                    hataField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("sistemler", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public responseSistemler[] sistemler
            {
                get
                {
                    return sistemlerField;
                }
                set
                {
                    sistemlerField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class hata
        {

            private string yerelHataAciklamasiField;

            private hataTanimi hataTanimiField;

            private hataOgesi[] yerelHataListesiField;

            private string throwableStackTraceField;

            private string yerelHataKapsamiField;

            private string yerelHataKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string yerelHataAciklamasi
            {
                get
                {
                    return yerelHataAciklamasiField;
                }
                set
                {
                    yerelHataAciklamasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public hataTanimi hataTanimi
            {
                get
                {
                    return hataTanimiField;
                }
                set
                {
                    hataTanimiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("hata", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
            public hataOgesi[] yerelHataListesi
            {
                get
                {
                    return yerelHataListesiField;
                }
                set
                {
                    yerelHataListesiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string throwableStackTrace
            {
                get
                {
                    return throwableStackTraceField;
                }
                set
                {
                    throwableStackTraceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string yerelHataKapsami
            {
                get
                {
                    return yerelHataKapsamiField;
                }
                set
                {
                    yerelHataKapsamiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string yerelHataKodu
            {
                get
                {
                    return yerelHataKoduField;
                }
                set
                {
                    yerelHataKoduField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class hataTanimi
        {

            private string genelHataAciklamasiField;

            private string genelHataKapsamiField;

            private string genelHataKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string genelHataAciklamasi
            {
                get
                {
                    return genelHataAciklamasiField;
                }
                set
                {
                    genelHataAciklamasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string genelHataKapsami
            {
                get
                {
                    return genelHataKapsamiField;
                }
                set
                {
                    genelHataKapsamiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string genelHataKodu
            {
                get
                {
                    return genelHataKoduField;
                }
                set
                {
                    genelHataKoduField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class kodDegeriKolonIcerigi
        {

            private kodDegeriKolonIcerigiTipi kodDegeriKolonIcerigiTipiField;

            private bool kodDegeriKolonIcerigiTipiFieldSpecified;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public kodDegeriKolonIcerigiTipi kodDegeriKolonIcerigiTipi
            {
                get
                {
                    return kodDegeriKolonIcerigiTipiField;
                }
                set
                {
                    kodDegeriKolonIcerigiTipiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool kodDegeriKolonIcerigiTipiSpecified
            {
                get
                {
                    return kodDegeriKolonIcerigiTipiFieldSpecified;
                }
                set
                {
                    kodDegeriKolonIcerigiTipiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return valueField;
                }
                set
                {
                    valueField = value;
                }
            }
        }
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public enum kodDegeriKolonIcerigiTipi
        {

            /// <remarks/>
            NUMBER,

            /// <remarks/>
            BOOLEAN,

            /// <remarks/>
            TEXT,

            /// <remarks/>
            DATE,

            /// <remarks/>
            NULL,

            /// <remarks/>
            UNKNOWN,
        }


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class kodDegeriKolonu
        {

            private kodDegeriKolonIcerigi kolonIcerigiField;

            private string kolonAdiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public kodDegeriKolonIcerigi kolonIcerigi
            {
                get
                {
                    return kolonIcerigiField;
                }
                set
                {
                    kolonIcerigiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string kolonAdi
            {
                get
                {
                    return kolonAdiField;
                }
                set
                {
                    kolonAdiField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class kodDegerleriResponse
        {

            private hata hataField;

            private kodDegeriKolonu[][] kodDegerleriField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public hata hata
            {
                get
                {
                    return hataField;
                }
                set
                {
                    hataField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("kodDegeriSatirlari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("kodDegeriKolonlari", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, NestingLevel = 1)]
            public kodDegeriKolonu[][] kodDegerleri
            {
                get
                {
                    return kodDegerleriField;
                }
                set
                {
                    kodDegerleriField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class responseSistemler
        {

            private string adiField;

            private bool aktifField;

            private bool aktifFieldSpecified;

            private System.DateTime guncellenmeTarihiField;

            private bool guncellenmeTarihiFieldSpecified;

            private hata hataField;

            private string hl7KoduField;

            private string koduField;

            private System.DateTime olusturulmaTarihiField;

            private bool olusturulmaTarihiFieldSpecified;

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
            public bool aktif
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
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool aktifSpecified
            {
                get
                {
                    return aktifFieldSpecified;
                }
                set
                {
                    aktifFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime guncellenmeTarihi
            {
                get
                {
                    return guncellenmeTarihiField;
                }
                set
                {
                    guncellenmeTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool guncellenmeTarihiSpecified
            {
                get
                {
                    return guncellenmeTarihiFieldSpecified;
                }
                set
                {
                    guncellenmeTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public hata hata
            {
                get
                {
                    return hataField;
                }
                set
                {
                    hataField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hl7Kodu
            {
                get
                {
                    return hl7KoduField;
                }
                set
                {
                    hl7KoduField = value;
                }
            }

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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime olusturulmaTarihi
            {
                get
                {
                    return olusturulmaTarihiField;
                }
                set
                {
                    olusturulmaTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool olusturulmaTarihiSpecified
            {
                get
                {
                    return olusturulmaTarihiFieldSpecified;
                }
                set
                {
                    olusturulmaTarihiFieldSpecified = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/")]
        public partial class hataOgesi
        {

            private string hataAciklamasiField;

            private string hataKapsamiField;

            private string hataKoduField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string hataAciklamasi
            {
                get
                {
                    return hataAciklamasiField;
                }
                set
                {
                    hataAciklamasiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string hataKapsami
            {
                get
                {
                    return hataKapsamiField;
                }
                set
                {
                    hataKapsamiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string hataKodu
            {
                get
                {
                    return hataKoduField;
                }
                set
                {
                    hataKoduField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class SistemlerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal SistemlerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public wsskrsSistemlerResponse Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((wsskrsSistemlerResponse)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class SistemKodlariCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal SistemKodlariCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public kodDegerleriResponse Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((kodDegerleriResponse)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class SistemKodlariSayfaGetirCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal SistemKodlariSayfaGetirCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public kodDegerleriResponse Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((kodDegerleriResponse)(results[0]));
                }
            }
        }




        #endregion Methods

    }
}