
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserDigitalSignature")] 

    /// <summary>
    /// Kullanıcı e-imza
    /// </summary>
    public  partial class UserDigitalSignature : TTObject
    {
        public class UserDigitalSignatureList : TTObjectCollection<UserDigitalSignature> { }
                    
        public class ChildUserDigitalSignatureCollection : TTObject.TTChildObjectCollection<UserDigitalSignature>
        {
            public ChildUserDigitalSignatureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserDigitalSignatureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Özell İmza
    /// </summary>
        public object PrivateSignature
        {
            get { return (object)this["PRIVATESIGNATURE"]; }
            set { this["PRIVATESIGNATURE"] = value; }
        }

    /// <summary>
    /// Genel İmza
    /// </summary>
        public object GeneralSignature
        {
            get { return (object)this["GENERALSIGNATURE"]; }
            set { this["GENERALSIGNATURE"] = value; }
        }

    /// <summary>
    /// Yaradılış Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

        protected UserDigitalSignature(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserDigitalSignature(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserDigitalSignature(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserDigitalSignature(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserDigitalSignature(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERDIGITALSIGNATURE", dataRow) { }
        protected UserDigitalSignature(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERDIGITALSIGNATURE", dataRow, isImported) { }
        public UserDigitalSignature(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserDigitalSignature(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserDigitalSignature() : base() { }

    }
}