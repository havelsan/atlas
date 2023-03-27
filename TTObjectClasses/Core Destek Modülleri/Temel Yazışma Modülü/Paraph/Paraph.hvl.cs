
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Paraph")] 

    /// <summary>
    /// Paraf
    /// </summary>
    public  partial class Paraph : TTObject
    {
        public class ParaphList : TTObjectCollection<Paraph> { }
                    
        public class ChildParaphCollection : TTObject.TTChildObjectCollection<Paraph>
        {
            public ChildParaphCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParaphCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Satır
    /// </summary>
        public string ParaphLine
        {
            get { return (string)this["PARAPHLINE"]; }
            set { this["PARAPHLINE"] = value; }
        }

        public InternalCorrespondenceKIMK InternalCorrespondenceKIMK
        {
            get { return (InternalCorrespondenceKIMK)((ITTObject)this).GetParent("INTERNALCORRESPONDENCEKIMK"); }
            set { this["INTERNALCORRESPONDENCEKIMK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseCorrespondence BaseCorrespondence
        {
            get { return (BaseCorrespondence)((ITTObject)this).GetParent("BASECORRESPONDENCE"); }
            set { this["BASECORRESPONDENCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Paraph(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Paraph(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Paraph(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Paraph(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Paraph(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARAPH", dataRow) { }
        protected Paraph(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARAPH", dataRow, isImported) { }
        public Paraph(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Paraph(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Paraph() : base() { }

    }
}