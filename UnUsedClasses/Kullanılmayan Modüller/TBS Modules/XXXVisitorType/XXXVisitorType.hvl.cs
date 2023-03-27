
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXVisitorType")] 

    /// <summary>
    /// Ziyaretçi Tipi
    /// </summary>
    public  partial class XXXVisitorType : TTDefinitionSet
    {
        public class XXXVisitorTypeList : TTObjectCollection<XXXVisitorType> { }
                    
        public class ChildXXXVisitorTypeCollection : TTObject.TTChildObjectCollection<XXXVisitorType>
        {
            public ChildXXXVisitorTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXVisitorTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

        protected XXXVisitorType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXVisitorType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXVisitorType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXVisitorType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXVisitorType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXVISITORTYPE", dataRow) { }
        protected XXXVisitorType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXVISITORTYPE", dataRow, isImported) { }
        public XXXVisitorType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXVisitorType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXVisitorType() : base() { }

    }
}