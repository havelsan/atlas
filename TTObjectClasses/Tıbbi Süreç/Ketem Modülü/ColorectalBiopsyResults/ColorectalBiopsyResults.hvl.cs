
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ColorectalBiopsyResults")] 

    /// <summary>
    /// Kolorektal Biyopsi Sonucu
    /// </summary>
    public  partial class ColorectalBiopsyResults : TTObject
    {
        public class ColorectalBiopsyResultsList : TTObjectCollection<ColorectalBiopsyResults> { }
                    
        public class ChildColorectalBiopsyResultsCollection : TTObject.TTChildObjectCollection<ColorectalBiopsyResults>
        {
            public ChildColorectalBiopsyResultsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildColorectalBiopsyResultsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CancerScreening CancerScreening
        {
            get { return (CancerScreening)((ITTObject)this).GetParent("CANCERSCREENING"); }
            set { this["CANCERSCREENING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKolorektalBiyopsiSonucu SKRSKolorektalBiyopsiSonucu
        {
            get { return (SKRSKolorektalBiyopsiSonucu)((ITTObject)this).GetParent("SKRSKOLOREKTALBIYOPSISONUCU"); }
            set { this["SKRSKOLOREKTALBIYOPSISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ColorectalBiopsyResults(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ColorectalBiopsyResults(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ColorectalBiopsyResults(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ColorectalBiopsyResults(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ColorectalBiopsyResults(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLORECTALBIOPSYRESULTS", dataRow) { }
        protected ColorectalBiopsyResults(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLORECTALBIOPSYRESULTS", dataRow, isImported) { }
        public ColorectalBiopsyResults(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ColorectalBiopsyResults(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ColorectalBiopsyResults() : base() { }

    }
}