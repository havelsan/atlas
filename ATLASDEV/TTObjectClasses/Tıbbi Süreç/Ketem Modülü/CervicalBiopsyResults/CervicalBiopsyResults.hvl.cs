
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CervicalBiopsyResults")] 

    /// <summary>
    /// Servikal Biyopsi Sonucu
    /// </summary>
    public  partial class CervicalBiopsyResults : TTObject
    {
        public class CervicalBiopsyResultsList : TTObjectCollection<CervicalBiopsyResults> { }
                    
        public class ChildCervicalBiopsyResultsCollection : TTObject.TTChildObjectCollection<CervicalBiopsyResults>
        {
            public ChildCervicalBiopsyResultsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCervicalBiopsyResultsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CancerScreening CancerScreening
        {
            get { return (CancerScreening)((ITTObject)this).GetParent("CANCERSCREENING"); }
            set { this["CANCERSCREENING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSServikalBiyopsiSonucu SKRSServikalBiyopsiSonucu
        {
            get { return (SKRSServikalBiyopsiSonucu)((ITTObject)this).GetParent("SKRSSERVIKALBIYOPSISONUCU"); }
            set { this["SKRSSERVIKALBIYOPSISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CervicalBiopsyResults(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CervicalBiopsyResults(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CervicalBiopsyResults(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CervicalBiopsyResults(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CervicalBiopsyResults(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CERVICALBIOPSYRESULTS", dataRow) { }
        protected CervicalBiopsyResults(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CERVICALBIOPSYRESULTS", dataRow, isImported) { }
        public CervicalBiopsyResults(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CervicalBiopsyResults(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CervicalBiopsyResults() : base() { }

    }
}