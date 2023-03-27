
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyGridDays")] 

    /// <summary>
    /// Günler
    /// </summary>
    public  partial class RadiologyGridDays : TTObject
    {
        public class RadiologyGridDaysList : TTObjectCollection<RadiologyGridDays> { }
                    
        public class ChildRadiologyGridDaysCollection : TTObject.TTChildObjectCollection<RadiologyGridDays>
        {
            public ChildRadiologyGridDaysCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyGridDaysCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Pazartesi
    /// </summary>
        public bool? Monday
        {
            get { return (bool?)this["MONDAY"]; }
            set { this["MONDAY"] = value; }
        }

    /// <summary>
    /// Salı
    /// </summary>
        public bool? Tuesday
        {
            get { return (bool?)this["TUESDAY"]; }
            set { this["TUESDAY"] = value; }
        }

    /// <summary>
    /// Çarşamba
    /// </summary>
        public bool? Wednesday
        {
            get { return (bool?)this["WEDNESDAY"]; }
            set { this["WEDNESDAY"] = value; }
        }

    /// <summary>
    /// Perşembe
    /// </summary>
        public bool? Thursday
        {
            get { return (bool?)this["THURSDAY"]; }
            set { this["THURSDAY"] = value; }
        }

    /// <summary>
    /// Cuma
    /// </summary>
        public bool? Friday
        {
            get { return (bool?)this["FRIDAY"]; }
            set { this["FRIDAY"] = value; }
        }

    /// <summary>
    /// Cumartesi
    /// </summary>
        public bool? Saturday
        {
            get { return (bool?)this["SATURDAY"]; }
            set { this["SATURDAY"] = value; }
        }

    /// <summary>
    /// Pazar
    /// </summary>
        public bool? Sunday
        {
            get { return (bool?)this["SUNDAY"]; }
            set { this["SUNDAY"] = value; }
        }

    /// <summary>
    /// Test Tanımı İlişkisi
    /// </summary>
        public RadiologyTestDefinition RadiologyTest
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyGridDays(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyGridDays(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyGridDays(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyGridDays(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyGridDays(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYGRIDDAYS", dataRow) { }
        protected RadiologyGridDays(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYGRIDDAYS", dataRow, isImported) { }
        public RadiologyGridDays(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyGridDays(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyGridDays() : base() { }

    }
}