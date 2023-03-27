
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSUrunEtkenMadde")] 

    public  partial class SOSUrunEtkenMadde : TerminologyManagerDef
    {
        public class SOSUrunEtkenMaddeList : TTObjectCollection<SOSUrunEtkenMadde> { }
                    
        public class ChildSOSUrunEtkenMaddeCollection : TTObject.TTChildObjectCollection<SOSUrunEtkenMadde>
        {
            public ChildSOSUrunEtkenMaddeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSUrunEtkenMaddeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

    /// <summary>
    /// Maximum Doz
    /// </summary>
        public double? MaxDose
        {
            get { return (double?)this["MAXDOSE"]; }
            set { this["MAXDOSE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public double? Value
        {
            get { return (double?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public SOSListeler Unit
        {
            get { return (SOSListeler)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSListeler MaxDoseUnit
        {
            get { return (SOSListeler)((ITTObject)this).GetParent("MAXDOSEUNIT"); }
            set { this["MAXDOSEUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSEtkenMadde SOSEtkenMadde
        {
            get { return (SOSEtkenMadde)((ITTObject)this).GetParent("SOSETKENMADDE"); }
            set { this["SOSETKENMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SOSUrunBilgisi SOSUrunBilgisi
        {
            get { return (SOSUrunBilgisi)((ITTObject)this).GetParent("SOSURUNBILGISI"); }
            set { this["SOSURUNBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSUrunEtkenMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSUrunEtkenMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSUrunEtkenMadde(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSUrunEtkenMadde(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSUrunEtkenMadde(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSURUNETKENMADDE", dataRow) { }
        protected SOSUrunEtkenMadde(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSURUNETKENMADDE", dataRow, isImported) { }
        public SOSUrunEtkenMadde(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSUrunEtkenMadde(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSUrunEtkenMadde() : base() { }

    }
}