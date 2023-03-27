
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Participiants")] 

    public  partial class Participiants : TTObject
    {
        public class ParticipiantsList : TTObjectCollection<Participiants> { }
                    
        public class ChildParticipiantsCollection : TTObject.TTChildObjectCollection<Participiants>
        {
            public ChildParticipiantsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParticipiantsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Biography
        {
            get { return (string)this["BIOGRAPHY"]; }
            set { this["BIOGRAPHY"] = value; }
        }

        public ResUser ProjectParticipiant
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROJECTPARTICIPIANT"); }
            set { this["PROJECTPARTICIPIANT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArgeProject ArgeProject
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("ARGEPROJECT"); }
            set { this["ARGEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResDepartment OwnerDepartment
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("OWNERDEPARTMENT"); }
            set { this["OWNERDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Participiants(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Participiants(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Participiants(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Participiants(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Participiants(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARTICIPIANTS", dataRow) { }
        protected Participiants(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARTICIPIANTS", dataRow, isImported) { }
        public Participiants(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Participiants(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Participiants() : base() { }

    }
}