
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LinenLocation")] 

    public  partial class LinenLocation : TTDefinitionSet
    {
        public class LinenLocationList : TTObjectCollection<LinenLocation> { }
                    
        public class ChildLinenLocationCollection : TTObject.TTChildObjectCollection<LinenLocation>
        {
            public ChildLinenLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLinenLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string IntegrationCode
        {
            get { return (string)this["INTEGRATIONCODE"]; }
            set { this["INTEGRATIONCODE"] = value; }
        }

        public string Location
        {
            get { return (string)this["LOCATION"]; }
            set { this["LOCATION"] = value; }
        }

        public string MahalNo
        {
            get { return (string)this["MAHALNO"]; }
            set { this["MAHALNO"] = value; }
        }

        protected LinenLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LinenLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LinenLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LinenLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LinenLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LINENLOCATION", dataRow) { }
        protected LinenLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LINENLOCATION", dataRow, isImported) { }
        public LinenLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LinenLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LinenLocation() : base() { }

    }
}