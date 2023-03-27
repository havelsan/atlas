
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnancyComplications")] 

    public  partial class PregnancyComplications : TTObject
    {
        public class PregnancyComplicationsList : TTObjectCollection<PregnancyComplications> { }
                    
        public class ChildPregnancyComplicationsCollection : TTObject.TTChildObjectCollection<PregnancyComplications>
        {
            public ChildPregnancyComplicationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyComplicationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gebelik Komplikasyon Açıklaması
    /// </summary>
        public string ComplicationsDescription
        {
            get { return (string)this["COMPLICATIONSDESCRIPTION"]; }
            set { this["COMPLICATIONSDESCRIPTION"] = value; }
        }

        public SKRSGebelikteRiskFaktorleri Complication
        {
            get { return (SKRSGebelikteRiskFaktorleri)((ITTObject)this).GetParent("COMPLICATION"); }
            set { this["COMPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PregnancyFollow PregnancyFollow
        {
            get { return (PregnancyFollow)((ITTObject)this).GetParent("PREGNANCYFOLLOW"); }
            set { this["PREGNANCYFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pregnancy Pregnancy
        {
            get { return (Pregnancy)((ITTObject)this).GetParent("PREGNANCY"); }
            set { this["PREGNANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PregnancyComplications(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnancyComplications(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnancyComplications(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnancyComplications(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnancyComplications(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCYCOMPLICATIONS", dataRow) { }
        protected PregnancyComplications(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCYCOMPLICATIONS", dataRow, isImported) { }
        public PregnancyComplications(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnancyComplications(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnancyComplications() : base() { }

    }
}