
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DashboardData")] 

    public  partial class DashboardData : TTObject
    {
        public class DashboardDataList : TTObjectCollection<DashboardData> { }
                    
        public class ChildDashboardDataCollection : TTObject.TTChildObjectCollection<DashboardData>
        {
            public ChildDashboardDataCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDashboardDataCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? CreatedDate
        {
            get { return (DateTime?)this["CREATEDDATE"]; }
            set { this["CREATEDDATE"] = value; }
        }

        public object XML
        {
            get { return (object)this["XML"]; }
            set { this["XML"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public ResUser CreatedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEDBY"); }
            set { this["CREATEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Dashboard Dashboard
        {
            get { return (Dashboard)((ITTObject)this).GetParent("DASHBOARD"); }
            set { this["DASHBOARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DashboardData(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DashboardData(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DashboardData(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DashboardData(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DashboardData(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DASHBOARDDATA", dataRow) { }
        protected DashboardData(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DASHBOARDDATA", dataRow, isImported) { }
        public DashboardData(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DashboardData(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DashboardData() : base() { }

    }
}