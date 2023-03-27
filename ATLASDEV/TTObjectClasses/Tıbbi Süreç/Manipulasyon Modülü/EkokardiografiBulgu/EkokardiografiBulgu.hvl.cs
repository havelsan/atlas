
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EkokardiografiBulgu")] 

    public  partial class EkokardiografiBulgu : TTObject
    {
        public class EkokardiografiBulguList : TTObjectCollection<EkokardiografiBulgu> { }
                    
        public class ChildEkokardiografiBulguCollection : TTObject.TTChildObjectCollection<EkokardiografiBulgu>
        {
            public ChildEkokardiografiBulguCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEkokardiografiBulguCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ekokardiografi
    /// </summary>
        public EkokardiografiEnum? EkokardiografiTest
        {
            get { return (EkokardiografiEnum?)(int?)this["EKOKARDIOGRAFITEST"]; }
            set { this["EKOKARDIOGRAFITEST"] = value; }
        }

    /// <summary>
    /// Bulgu
    /// </summary>
        public string EkokardiografiTestBulgu
        {
            get { return (string)this["EKOKARDIOGRAFITESTBULGU"]; }
            set { this["EKOKARDIOGRAFITESTBULGU"] = value; }
        }

        public EkokardiografiFormObject EkokardiografiFormObject
        {
            get { return (EkokardiografiFormObject)((ITTObject)this).GetParent("EKOKARDIOGRAFIFORMOBJECT"); }
            set { this["EKOKARDIOGRAFIFORMOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EkokardiografiBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EkokardiografiBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EkokardiografiBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EkokardiografiBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EkokardiografiBulgu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EKOKARDIOGRAFIBULGU", dataRow) { }
        protected EkokardiografiBulgu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EKOKARDIOGRAFIBULGU", dataRow, isImported) { }
        public EkokardiografiBulgu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EkokardiografiBulgu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EkokardiografiBulgu() : base() { }

    }
}