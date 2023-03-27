
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SystemForDisabledReportGrid")] 

    public  partial class SystemForDisabledReportGrid : TTObject
    {
        public class SystemForDisabledReportGridList : TTObjectCollection<SystemForDisabledReportGrid> { }
                    
        public class ChildSystemForDisabledReportGridCollection : TTObject.TTChildObjectCollection<SystemForDisabledReportGrid>
        {
            public ChildSystemForDisabledReportGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSystemForDisabledReportGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SystemForDisabledReportDefinition SystemForDisabledReport
        {
            get { return (SystemForDisabledReportDefinition)((ITTObject)this).GetParent("SYSTEMFORDISABLEDREPORT"); }
            set { this["SYSTEMFORDISABLEDREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SystemForDisabledReportGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SystemForDisabledReportGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SystemForDisabledReportGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SystemForDisabledReportGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SystemForDisabledReportGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSTEMFORDISABLEDREPORTGRID", dataRow) { }
        protected SystemForDisabledReportGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSTEMFORDISABLEDREPORTGRID", dataRow, isImported) { }
        public SystemForDisabledReportGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SystemForDisabledReportGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SystemForDisabledReportGrid() : base() { }

    }
}