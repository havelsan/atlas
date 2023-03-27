
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TrikuspitKapakBulgu")] 

    public  partial class TrikuspitKapakBulgu : TTObject
    {
        public class TrikuspitKapakBulguList : TTObjectCollection<TrikuspitKapakBulgu> { }
                    
        public class ChildTrikuspitKapakBulguCollection : TTObject.TTChildObjectCollection<TrikuspitKapakBulgu>
        {
            public ChildTrikuspitKapakBulguCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTrikuspitKapakBulguCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Triküspit Kapak
    /// </summary>
        public TrikuspitKapakEnum? TrikuspitKapakTest
        {
            get { return (TrikuspitKapakEnum?)(int?)this["TRIKUSPITKAPAKTEST"]; }
            set { this["TRIKUSPITKAPAKTEST"] = value; }
        }

    /// <summary>
    /// Bulgu
    /// </summary>
        public string TrikuspitKapakTestBulgu
        {
            get { return (string)this["TRIKUSPITKAPAKTESTBULGU"]; }
            set { this["TRIKUSPITKAPAKTESTBULGU"] = value; }
        }

        public EkokardiografiFormObject EkokardiografiFormObject
        {
            get { return (EkokardiografiFormObject)((ITTObject)this).GetParent("EKOKARDIOGRAFIFORMOBJECT"); }
            set { this["EKOKARDIOGRAFIFORMOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TrikuspitKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TrikuspitKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TrikuspitKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TrikuspitKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TrikuspitKapakBulgu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRIKUSPITKAPAKBULGU", dataRow) { }
        protected TrikuspitKapakBulgu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRIKUSPITKAPAKBULGU", dataRow, isImported) { }
        public TrikuspitKapakBulgu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TrikuspitKapakBulgu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TrikuspitKapakBulgu() : base() { }

    }
}