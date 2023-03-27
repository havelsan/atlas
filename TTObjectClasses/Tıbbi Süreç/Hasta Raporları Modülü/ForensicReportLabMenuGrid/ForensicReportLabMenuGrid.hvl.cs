
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ForensicReportLabMenuGrid")] 

    public  partial class ForensicReportLabMenuGrid : TTObject
    {
        public class ForensicReportLabMenuGridList : TTObjectCollection<ForensicReportLabMenuGrid> { }
                    
        public class ChildForensicReportLabMenuGridCollection : TTObject.TTChildObjectCollection<ForensicReportLabMenuGrid>
        {
            public ChildForensicReportLabMenuGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildForensicReportLabMenuGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ForensicMedicalReport ForensicMedicalReport
        {
            get { return (ForensicMedicalReport)((ITTObject)this).GetParent("FORENSICMEDICALREPORT"); }
            set { this["FORENSICMEDICALREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MenuDefinition MenuDefinition
        {
            get { return (MenuDefinition)((ITTObject)this).GetParent("MENUDEFINITION"); }
            set { this["MENUDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ForensicReportLabMenuGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ForensicReportLabMenuGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ForensicReportLabMenuGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ForensicReportLabMenuGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ForensicReportLabMenuGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FORENSICREPORTLABMENUGRID", dataRow) { }
        protected ForensicReportLabMenuGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FORENSICREPORTLABMENUGRID", dataRow, isImported) { }
        public ForensicReportLabMenuGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ForensicReportLabMenuGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ForensicReportLabMenuGrid() : base() { }

    }
}