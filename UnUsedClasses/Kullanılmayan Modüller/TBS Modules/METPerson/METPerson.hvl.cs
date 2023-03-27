
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METPerson")] 

    /// <summary>
    /// Kişi
    /// </summary>
    public  partial class METPerson : METTarget
    {
        public class METPersonList : TTObjectCollection<METPerson> { }
                    
        public class ChildMETPersonCollection : TTObject.TTChildObjectCollection<METPerson>
        {
            public ChildMETPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Soyadı
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string FirstName
        {
            get { return (string)this["FIRSTNAME"]; }
            set { this["FIRSTNAME"] = value; }
        }

        protected METPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METPerson(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METPerson(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METPerson(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METPERSON", dataRow) { }
        protected METPerson(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METPERSON", dataRow, isImported) { }
        public METPerson(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METPerson(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METPerson() : base() { }

    }
}