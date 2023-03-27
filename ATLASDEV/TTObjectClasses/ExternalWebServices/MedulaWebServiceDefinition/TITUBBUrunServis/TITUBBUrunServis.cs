
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
    public  partial class TITUBBUrunServis : TTObject
    {
        public static partial class WebMethods
        {
                    
        }
                    
#region Methods
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ProductServiceResult {
        
        private Product[] productsField;
        
        /// <remarks/>
        public Product[] Products {
            get {
                return productsField;
            }
            set {
                productsField = value;
            }
        }
    }        
        
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Product {
        
        private System.Guid objectIDField;
        
        private string tITUBBProductIDField;
        
        private string productNumberField;
        
        private string nameField;
        
        private string productNumberTypeField;
        
        private Firm firmField;
        
        private ProductSUTMatch[] productSUTMatchesField;
        
        private System.DateTime registrationDateField;
        
        /// <remarks/>
        public System.Guid ObjectID {
            get {
                return objectIDField;
            }
            set {
                objectIDField = value;
            }
        }
        
        /// <remarks/>
        public string TITUBBProductID {
            get {
                return tITUBBProductIDField;
            }
            set {
                tITUBBProductIDField = value;
            }
        }
        
        /// <remarks/>
        public string ProductNumber {
            get {
                return productNumberField;
            }
            set {
                productNumberField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return nameField;
            }
            set {
                nameField = value;
            }
        }
        
        /// <remarks/>
        public string ProductNumberType {
            get {
                return productNumberTypeField;
            }
            set {
                productNumberTypeField = value;
            }
        }
        
        /// <remarks/>
        public Firm Firm {
            get {
                return firmField;
            }
            set {
                firmField = value;
            }
        }
        
        /// <remarks/>
        public ProductSUTMatch[] ProductSUTMatches {
            get {
                return productSUTMatchesField;
            }
            set {
                productSUTMatchesField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime RegistrationDate {
            get {
                return registrationDateField;
            }
            set {
                registrationDateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Firm {
        
        private System.Guid objectIDField;
        
        private string tITUBBFirmIDField;
        
        private long identityNumberField;
        
        private string nameField;
        
        private System.DateTime registrationDateField;
        
        /// <remarks/>
        public System.Guid ObjectID {
            get {
                return objectIDField;
            }
            set {
                objectIDField = value;
            }
        }
        
        /// <remarks/>
        public string TITUBBFirmID {
            get {
                return tITUBBFirmIDField;
            }
            set {
                tITUBBFirmIDField = value;
            }
        }
        
        /// <remarks/>
        public long IdentityNumber {
            get {
                return identityNumberField;
            }
            set {
                identityNumberField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return nameField;
            }
            set {
                nameField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime RegistrationDate {
            get {
                return registrationDateField;
            }
            set {
                registrationDateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class SUTAppendix {
        
        private System.Guid objectIDField;
        
        private string tITUBBSUTAppendixIDField;
        
        private string nameField;
        
        /// <remarks/>
        public System.Guid ObjectID {
            get {
                return objectIDField;
            }
            set {
                objectIDField = value;
            }
        }
        
        /// <remarks/>
        public string TITUBBSUTAppendixID {
            get {
                return tITUBBSUTAppendixIDField;
            }
            set {
                tITUBBSUTAppendixIDField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return nameField;
            }
            set {
                nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ProductSUTMatch {
        
        private System.Guid objectIDField;
        
        private string sUTCodeField;
        
        private string sUTNameField;
        
        private decimal sUTPriceField;
        
        private string tITUBBProductSUTMatchIDField;
        
        private System.Guid productIDField;
        
        private System.Guid sUTAppendixIDField;
        
        private Product productField;
        
        private SUTAppendix sUTAppendixField;
        
        /// <remarks/>
        public System.Guid ObjectID {
            get {
                return objectIDField;
            }
            set {
                objectIDField = value;
            }
        }
        
        /// <remarks/>
        public string SUTCode {
            get {
                return sUTCodeField;
            }
            set {
                sUTCodeField = value;
            }
        }
        
        /// <remarks/>
        public string SUTName {
            get {
                return sUTNameField;
            }
            set {
                sUTNameField = value;
            }
        }
        
        /// <remarks/>
        public decimal SUTPrice {
            get {
                return sUTPriceField;
            }
            set {
                sUTPriceField = value;
            }
        }
        
        /// <remarks/>
        public string TITUBBProductSUTMatchID {
            get {
                return tITUBBProductSUTMatchIDField;
            }
            set {
                tITUBBProductSUTMatchIDField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid ProductID {
            get {
                return productIDField;
            }
            set {
                productIDField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid SUTAppendixID {
            get {
                return sUTAppendixIDField;
            }
            set {
                sUTAppendixIDField = value;
            }
        }
        
        /// <remarks/>
        public Product Product {
            get {
                return productField;
            }
            set {
                productField = value;
            }
        }
        
        /// <remarks/>
        public SUTAppendix SUTAppendix {
            get {
                return sUTAppendixField;
            }
            set {
                sUTAppendixField = value;
            }
        }
    }
        
#endregion Methods

    }
}