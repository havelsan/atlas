
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CervicalCytologyResults")] 

    /// <summary>
    /// Servikal Sitoloji Sonuçları
    /// </summary>
    public  partial class CervicalCytologyResults : TTObject
    {
        public class CervicalCytologyResultsList : TTObjectCollection<CervicalCytologyResults> { }
                    
        public class ChildCervicalCytologyResultsCollection : TTObject.TTChildObjectCollection<CervicalCytologyResults>
        {
            public ChildCervicalCytologyResultsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCervicalCytologyResultsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CancerScreening CancerScreening
        {
            get { return (CancerScreening)((ITTObject)this).GetParent("CANCERSCREENING"); }
            set { this["CANCERSCREENING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSServikalSitolojiSonucu SKRSServikalSitolojiSonucu
        {
            get { return (SKRSServikalSitolojiSonucu)((ITTObject)this).GetParent("SKRSSERVIKALSITOLOJISONUCU"); }
            set { this["SKRSSERVIKALSITOLOJISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CervicalCytologyResults(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CervicalCytologyResults(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CervicalCytologyResults(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CervicalCytologyResults(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CervicalCytologyResults(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CERVICALCYTOLOGYRESULTS", dataRow) { }
        protected CervicalCytologyResults(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CERVICALCYTOLOGYRESULTS", dataRow, isImported) { }
        public CervicalCytologyResults(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CervicalCytologyResults(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CervicalCytologyResults() : base() { }

    }
}