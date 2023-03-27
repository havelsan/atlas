using TTInstanceManagement;
namespace TTObjectClasses
{
    /// <summary>
    /// XXXXXXSarfBildirimReceiverService
    /// </summary>
    public partial class XXXXXXSarfBildirimReceiverService : TTObject
    {
        #region Methods


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/bildirim/BR/v1/Sarf/XXXXXX")]
        public partial class XXXXXXSarfType
        {

            private string dtField;

            private string frField;

            private string iSACIKLAMAField;

            private XXXXXXSarfTypeBELGE bELGEField;

            private XXXXXXSarfTypeURUN[] uRUNLERField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string DT
            {
                get
                {
                    return dtField;
                }
                set
                {
                    dtField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string FR
            {
                get
                {
                    return frField;
                }
                set
                {
                    frField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string ISACIKLAMA
            {
                get
                {
                    return iSACIKLAMAField;
                }
                set
                {
                    iSACIKLAMAField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public XXXXXXSarfTypeBELGE BELGE
            {
                get
                {
                    return bELGEField;
                }
                set
                {
                    bELGEField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("URUN", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
            public XXXXXXSarfTypeURUN[] URUNLER
            {
                get
                {
                    return uRUNLERField;
                }
                set
                {
                    uRUNLERField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/bildirim/BR/v1/Sarf/XXXXXX")]
        public partial class XXXXXXSarfTypeBELGE
        {

            private System.Nullable<System.DateTime> ddField;

            private string dnField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date", IsNullable = true)]
            public System.Nullable<System.DateTime> DD
            {
                get
                {
                    return ddField;
                }
                set
                {
                    ddField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public string DN
            {
                get
                {
                    return dnField;
                }
                set
                {
                    dnField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/bildirim/BR/v1/Sarf/XXXXXX")]
        public partial class XXXXXXSarfCevapType
        {

            private string bILDIRIMIDField;

            private XXXXXXSarfCevapTypeURUNDURUM[] uRUNLERField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string BILDIRIMID
            {
                get
                {
                    return bILDIRIMIDField;
                }
                set
                {
                    bILDIRIMIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("URUNDURUM", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
            public XXXXXXSarfCevapTypeURUNDURUM[] URUNLER
            {
                get
                {
                    return uRUNLERField;
                }
                set
                {
                    uRUNLERField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/bildirim/BR/v1/Sarf/XXXXXX")]
        public partial class XXXXXXSarfCevapTypeURUNDURUM
        {

            private string gTINField;

            private string snField;

            private string ucField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string GTIN
            {
                get
                {
                    return gTINField;
                }
                set
                {
                    gTINField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string SN
            {
                get
                {
                    return snField;
                }
                set
                {
                    snField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string UC
            {
                get
                {
                    return ucField;
                }
                set
                {
                    ucField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/bildirim/BR/v1/Sarf/XXXXXX")]
        public partial class XXXXXXSarfTypeURUN
        {

            private string gTINField;

            private string bnField;

            private string snField;

            private System.DateTime xdField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string GTIN
            {
                get
                {
                    return gTINField;
                }
                set
                {
                    gTINField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string BN
            {
                get
                {
                    return bnField;
                }
                set
                {
                    bnField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string SN
            {
                get
                {
                    return snField;
                }
                set
                {
                    snField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "date")]
            public System.DateTime XD
            {
                get
                {
                    return xdField;
                }
                set
                {
                    xdField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class XXXXXXSarfBildirCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal XXXXXXSarfBildirCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public XXXXXXSarfCevapType Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((XXXXXXSarfCevapType)(results[0]));
                }
            }
        }


        #endregion
    }
}