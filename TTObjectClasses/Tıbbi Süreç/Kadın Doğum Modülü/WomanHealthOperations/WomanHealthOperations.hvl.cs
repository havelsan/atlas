
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WomanHealthOperations")] 

    /// <summary>
    /// Kadın Sağlığı İşlemleri
    /// </summary>
    public  partial class WomanHealthOperations : TTObject
    {
        public class WomanHealthOperationsList : TTObjectCollection<WomanHealthOperations> { }
                    
        public class ChildWomanHealthOperationsCollection : TTObject.TTChildObjectCollection<WomanHealthOperations>
        {
            public ChildWomanHealthOperationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWomanHealthOperationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSKadinSagligiIslemleri SKRSWomanHealthOperations
        {
            get { return (SKRSKadinSagligiIslemleri)((ITTObject)this).GetParent("SKRSWOMANHEALTHOPERATIONS"); }
            set { this["SKRSWOMANHEALTHOPERATIONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PostpartumFollowUp PostpartumFollowUp
        {
            get { return (PostpartumFollowUp)((ITTObject)this).GetParent("POSTPARTUMFOLLOWUP"); }
            set { this["POSTPARTUMFOLLOWUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WomanHealthOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WomanHealthOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WomanHealthOperations(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WomanHealthOperations(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WomanHealthOperations(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOMANHEALTHOPERATIONS", dataRow) { }
        protected WomanHealthOperations(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOMANHEALTHOPERATIONS", dataRow, isImported) { }
        public WomanHealthOperations(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WomanHealthOperations(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WomanHealthOperations() : base() { }

    }
}