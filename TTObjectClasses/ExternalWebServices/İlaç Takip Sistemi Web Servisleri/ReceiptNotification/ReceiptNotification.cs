﻿using System;
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
    public partial class ReceiptNotification : TTObject
    {
        #region Methods


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("AtlasSoapProxyGenerator", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/notification/receipt")]
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
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/notification/receipt")]
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
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com/notification/receipt")]
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
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://xxxxxx.com/notification/receipt")]
        public partial class ItsResponsePRODUCT
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
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        public partial class sendReceiptNotificationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {

            private object[] results;

            internal sendReceiptNotificationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
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