
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ColonoscopyQualityCriteria")] 

    /// <summary>
    /// Kolonoskopi Kalite Kriterleri
    /// </summary>
    public  partial class ColonoscopyQualityCriteria : TTObject
    {
        public class ColonoscopyQualityCriteriaList : TTObjectCollection<ColonoscopyQualityCriteria> { }
                    
        public class ChildColonoscopyQualityCriteriaCollection : TTObject.TTChildObjectCollection<ColonoscopyQualityCriteria>
        {
            public ChildColonoscopyQualityCriteriaCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildColonoscopyQualityCriteriaCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CancerScreening CancerScreening
        {
            get { return (CancerScreening)((ITTObject)this).GetParent("CANCERSCREENING"); }
            set { this["CANCERSCREENING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKolonoskopiKaliteKriterleri KolonoskopiKaliteKriterleri
        {
            get { return (SKRSKolonoskopiKaliteKriterleri)((ITTObject)this).GetParent("KOLONOSKOPIKALITEKRITERLERI"); }
            set { this["KOLONOSKOPIKALITEKRITERLERI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ColonoscopyQualityCriteria(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ColonoscopyQualityCriteria(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ColonoscopyQualityCriteria(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ColonoscopyQualityCriteria(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ColonoscopyQualityCriteria(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLONOSCOPYQUALITYCRITERIA", dataRow) { }
        protected ColonoscopyQualityCriteria(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLONOSCOPYQUALITYCRITERIA", dataRow, isImported) { }
        public ColonoscopyQualityCriteria(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ColonoscopyQualityCriteria(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ColonoscopyQualityCriteria() : base() { }

    }
}