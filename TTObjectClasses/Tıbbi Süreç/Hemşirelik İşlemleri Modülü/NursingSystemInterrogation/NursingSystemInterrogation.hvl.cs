
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingSystemInterrogation")] 

    public  partial class NursingSystemInterrogation : TTObject
    {
        public class NursingSystemInterrogationList : TTObjectCollection<NursingSystemInterrogation> { }
                    
        public class ChildNursingSystemInterrogationCollection : TTObject.TTChildObjectCollection<NursingSystemInterrogation>
        {
            public ChildNursingSystemInterrogationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingSystemInterrogationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sistem Sorguları
    /// </summary>
        public SystemInterrogationDefinition SystemInterrogation
        {
            get { return (SystemInterrogationDefinition)((ITTObject)this).GetParent("SYSTEMINTERROGATION"); }
            set { this["SYSTEMINTERROGATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseNursingSystemInterrogation BaseNursSysInterrogation
        {
            get { return (BaseNursingSystemInterrogation)((ITTObject)this).GetParent("BASENURSSYSINTERROGATION"); }
            set { this["BASENURSSYSINTERROGATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingSystemInterrogation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingSystemInterrogation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGSYSTEMINTERROGATION", dataRow) { }
        protected NursingSystemInterrogation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGSYSTEMINTERROGATION", dataRow, isImported) { }
        public NursingSystemInterrogation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingSystemInterrogation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingSystemInterrogation() : base() { }

    }
}