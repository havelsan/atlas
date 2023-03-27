
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyLocation")] 

    public  partial class RadiologyLocation : TTObject
    {
        public class RadiologyLocationList : TTObjectCollection<RadiologyLocation> { }
                    
        public class ChildRadiologyLocationCollection : TTObject.TTChildObjectCollection<RadiologyLocation>
        {
            public ChildRadiologyLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<RadiologyLocation> GetByTest(TTObjectContext objectContext, string PARAMTEST)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYLOCATION"].QueryDefs["GetByTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTEST", PARAMTEST);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyLocation>(queryDef, paramList);
        }

        public static BindingList<RadiologyLocation> GetByTab(TTObjectContext objectContext, string PARAMTAB)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYLOCATION"].QueryDefs["GetByTab"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyLocation>(queryDef, paramList);
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Bulnduğu Tab
    /// </summary>
        public RadiologyTabDefinition Tab
        {
            get { return (RadiologyTabDefinition)((ITTObject)this).GetParent("TAB"); }
            set { this["TAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Test Adı
    /// </summary>
        public RadiologyTestDefinition Test
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("TEST"); }
            set { this["TEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYLOCATION", dataRow) { }
        protected RadiologyLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYLOCATION", dataRow, isImported) { }
        public RadiologyLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyLocation() : base() { }

    }
}