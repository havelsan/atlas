
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DisabledReportSpecialGrid")] 

    /// <summary>
    /// Sağlık Kurulu engelli Raporu Branşları
    /// </summary>
    public  partial class DisabledReportSpecialGrid : TTObject
    {
        public class DisabledReportSpecialGridList : TTObjectCollection<DisabledReportSpecialGrid> { }
                    
        public class ChildDisabledReportSpecialGridCollection : TTObject.TTChildObjectCollection<DisabledReportSpecialGrid>
        {
            public ChildDisabledReportSpecialGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDisabledReportSpecialGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SystemForDisabledReportDefinition DisabledReport
        {
            get { return (SystemForDisabledReportDefinition)((ITTObject)this).GetParent("DISABLEDREPORT"); }
            set { this["DISABLEDREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DisabledReportSpecialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DisabledReportSpecialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DisabledReportSpecialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DisabledReportSpecialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DisabledReportSpecialGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISABLEDREPORTSPECIALGRID", dataRow) { }
        protected DisabledReportSpecialGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISABLEDREPORTSPECIALGRID", dataRow, isImported) { }
        public DisabledReportSpecialGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DisabledReportSpecialGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DisabledReportSpecialGrid() : base() { }

    }
}