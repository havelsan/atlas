
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSRpIlacProspektus")] 

    public  partial class SOSRpIlacProspektus : TerminologyManagerDef
    {
        public class SOSRpIlacProspektusList : TTObjectCollection<SOSRpIlacProspektus> { }
                    
        public class ChildSOSRpIlacProspektusCollection : TTObject.TTChildObjectCollection<SOSRpIlacProspektus>
        {
            public ChildSOSRpIlacProspektusCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSRpIlacProspektusCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

        public string ProspektusDetay
        {
            get { return (string)this["PROSPEKTUSDETAY"]; }
            set { this["PROSPEKTUSDETAY"] = value; }
        }

        public SOSUrunBilgisi SOSUrunBilgisi
        {
            get { return (SOSUrunBilgisi)((ITTObject)this).GetParent("SOSURUNBILGISI"); }
            set { this["SOSURUNBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSRpProspektusBaslik SOSRpProspektusBaslik
        {
            get { return (SOSRpProspektusBaslik)((ITTObject)this).GetParent("SOSRPPROSPEKTUSBASLIK"); }
            set { this["SOSRPPROSPEKTUSBASLIK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSRpIlacProspektus(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSRpIlacProspektus(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSRpIlacProspektus(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSRpIlacProspektus(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSRpIlacProspektus(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSRPILACPROSPEKTUS", dataRow) { }
        protected SOSRpIlacProspektus(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSRPILACPROSPEKTUS", dataRow, isImported) { }
        public SOSRpIlacProspektus(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSRpIlacProspektus(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSRpIlacProspektus() : base() { }

    }
}