using TTInstanceManagement;


namespace TTObjectClasses
{
    public partial class TibbiMalzemeYardimciIslemler : TTObject
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
        public partial class butKodlariCevapDVO
        {

            private merkezSutKodlariPojo[] malzemeListesiField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("malzemeListesi", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public merkezSutKodlariPojo[] malzemeListesi
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
        public partial class merkezSutKodlariPojo
        {

            private string adiField;

            private int butIdField;

            private string butKoduField;

            private int malzemeBransReferansKoduField;

            private string malzemeGrubuAdiField;

            private string malzemeGrubuKoduField;

            private string turuField;

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
            public int butId
            {
                get
                {
                    return butIdField;
                }
                set
                {
                    butIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string butKodu
            {
                get
                {
                    return butKoduField;
                }
                set
                {
                    butKoduField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int malzemeBransReferansKodu
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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string turu
            {
                get
                {
                    return turuField;
                }
                set
                {
                    turuField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com")]
        public partial class odyometriTestiCevapDVO
        {

            private string testIdField;

            private string sonucKoduField;

            private string sonucMesajiField;

            private string uyariMesajiField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string testId
            {
                get
                {
                    return testIdField;
                }
                set
                {
                    testIdField = value;
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
        public partial class odyometriTestGirisIstekDVO
        {

            private byte[] imzaliOdyometriTestBilgiField;

            private string tesisKoduField;

            private string doktorTcKimlikNoField;

            private string surumNumarasiField;

            public odyometriTestGirisIstekDVO()
            {
                tesisKoduField = "";
                doktorTcKimlikNoField = "";
                surumNumarasiField = "";
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "base64Binary")]
            public byte[] imzaliOdyometriTestBilgi
            {
                get
                {
                    return imzaliOdyometriTestBilgiField;
                }
                set
                {
                    imzaliOdyometriTestBilgiField = value;
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
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class sutMalzemeSorgulaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal sutMalzemeSorgulaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public butKodlariCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((butKodlariCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class safSesOdyometrisiTestKaydetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal safSesOdyometrisiTestKaydetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public odyometriTestiCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((odyometriTestiCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class abrTestiKaydetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal abrTestiKaydetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public odyometriTestiCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((odyometriTestiCevapDVO)(results[0]));
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class davranimOdyometrisiTestKaydetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal davranimOdyometrisiTestKaydetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public odyometriTestiCevapDVO Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((odyometriTestiCevapDVO)(results[0]));
                }
            }
        }



        #endregion Methods
    }
}