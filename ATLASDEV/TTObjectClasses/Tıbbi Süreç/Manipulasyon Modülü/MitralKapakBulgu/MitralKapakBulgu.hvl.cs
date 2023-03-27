
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MitralKapakBulgu")] 

    public  partial class MitralKapakBulgu : TTObject
    {
        public class MitralKapakBulguList : TTObjectCollection<MitralKapakBulgu> { }
                    
        public class ChildMitralKapakBulguCollection : TTObject.TTChildObjectCollection<MitralKapakBulgu>
        {
            public ChildMitralKapakBulguCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMitralKapakBulguCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mitral Kapak
    /// </summary>
        public MitralKapakEnum? MitralKapakTest
        {
            get { return (MitralKapakEnum?)(int?)this["MITRALKAPAKTEST"]; }
            set { this["MITRALKAPAKTEST"] = value; }
        }

        public string MitralKapakTestBulgu
        {
            get { return (string)this["MITRALKAPAKTESTBULGU"]; }
            set { this["MITRALKAPAKTESTBULGU"] = value; }
        }

        public EkokardiografiFormObject EkokardiografiFormObject
        {
            get { return (EkokardiografiFormObject)((ITTObject)this).GetParent("EKOKARDIOGRAFIFORMOBJECT"); }
            set { this["EKOKARDIOGRAFIFORMOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MitralKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MitralKapakBulgu(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MitralKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MitralKapakBulgu(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MitralKapakBulgu(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MITRALKAPAKBULGU", dataRow) { }
        protected MitralKapakBulgu(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MITRALKAPAKBULGU", dataRow, isImported) { }
        public MitralKapakBulgu(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MitralKapakBulgu(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MitralKapakBulgu() : base() { }

    }
}