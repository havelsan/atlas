using TTInstanceManagement;
namespace TTObjectClasses
{
    public partial class CheckStatusNotification : TTObject
    {
        #region Methods


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/notification/queryStatus")]
        public partial class ItsPlainRequest
        {

            private ItsPlainRequestPRODUCT[] pRODUCTSField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
            public ItsPlainRequestPRODUCT[] PRODUCTS
            {
                get
                {
                    return pRODUCTSField;
                }
                set
                {
                    pRODUCTSField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/notification/queryStatus")]
        public partial class ItsPlainRequestPRODUCT
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
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/notification/queryStatus")]
        public partial class ItsResponse
        {

            private string nOTIFICATIONIDField;

            private ItsResponsePRODUCT[] pRODUCTSField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string NOTIFICATIONID
            {
                get
                {
                    return nOTIFICATIONIDField;
                }
                set
                {
                    nOTIFICATIONIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
            public ItsResponsePRODUCT[] PRODUCTS
            {
                get
                {
                    return pRODUCTSField;
                }
                set
                {
                    pRODUCTSField = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/notification/queryStatus")]
        public partial class ItsResponsePRODUCT
        {

            private string gTINField;

            private string snField;

            private string ucField;

            private string gLN1Field;

            private string gLN2Field;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string GLN1
            {
                get
                {
                    return gLN1Field;
                }
                set
                {
                    gLN1Field = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string GLN2
            {
                get
                {
                    return gLN2Field;
                }
                set
                {
                    gLN2Field = value;
                }
            }
        }



        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class sendCheckStatusNotificationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal sendCheckStatusNotificationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                    base(exception, cancelled, userState)
            {
                this.results = results;
            }

            /// <remarks/>
            public ItsResponse Result
            {
                get
                {
                    RaiseExceptionIfNecessary();
                    return ((ItsResponse)(results[0]));
                }
            }
        }


        #endregion

    }
}