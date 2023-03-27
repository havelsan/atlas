
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AortKapakBulgu")] 

    public  partial class AortKapakBulgu : TTObject
    {
        public class AortKapakBulguList : TTObjectCollection<AortKapakBulgu> { }
                    
        public class ChildAortKapakBulguCollection : TTObject.TTChildObjectCollection<AortKapakBulgu>
        {
            public ChildAortKapakBulguCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAortKapakBulguCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Aort Kapak
    /// </summary>
        public AortKapakEnum? AortKapakTest
        {
            get { return (AortKapakEnum?)(int?)this["AORTKAPAKTEST"]; }
            set { this["AORTKAPAKTEST"] = value; }
        }

    /// <summary>
    /// Bulgu
    /// </summary>
        public string AortKapakTestBulgu
        {
            get { return (string)this["AORTKAPAKTESTBULGU"]; }
            set { this["AORTKAPAKTESTBULGU"] = value; }
        }

        public EkokardiografiFormObject EkokardiografiFormObject
        {
            get { return (EkokardiografiFormObject)((ITTObject)this).GetParent("EKOKARDIOGRAFIFORMOBJECT"); }
            set { this["EKOKARDIOGRAFIFORMOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AortKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AortKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AortKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AortKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AortKapakBulgu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AORTKAPAKBULGU", dataRow) { }
        protected AortKapakBulgu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AORTKAPAKBULGU", dataRow, isImported) { }
        public AortKapakBulgu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AortKapakBulgu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AortKapakBulgu() : base() { }

    }
}