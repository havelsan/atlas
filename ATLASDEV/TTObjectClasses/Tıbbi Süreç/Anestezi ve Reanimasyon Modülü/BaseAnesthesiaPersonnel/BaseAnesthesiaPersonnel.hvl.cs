
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseAnesthesiaPersonnel")] 

    /// <summary>
    /// Anestezi Ekibi Ana Objesi
    /// </summary>
    public  partial class BaseAnesthesiaPersonnel : TTObject
    {
        public class BaseAnesthesiaPersonnelList : TTObjectCollection<BaseAnesthesiaPersonnel> { }
                    
        public class ChildBaseAnesthesiaPersonnelCollection : TTObject.TTChildObjectCollection<BaseAnesthesiaPersonnel>
        {
            public ChildBaseAnesthesiaPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseAnesthesiaPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Anestezi Ekibi
    /// </summary>
        public ResUser AnesthesiaPersonnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTHESIAPERSONNEL"); }
            set { this["ANESTHESIAPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseAnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseAnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseAnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseAnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseAnesthesiaPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEANESTHESIAPERSONNEL", dataRow) { }
        protected BaseAnesthesiaPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEANESTHESIAPERSONNEL", dataRow, isImported) { }
        public BaseAnesthesiaPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseAnesthesiaPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseAnesthesiaPersonnel() : base() { }

    }
}