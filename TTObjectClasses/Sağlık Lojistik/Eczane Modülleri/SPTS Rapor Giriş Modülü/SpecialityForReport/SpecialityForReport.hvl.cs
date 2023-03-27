
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialityForReport")] 

    public  partial class SpecialityForReport : TTObject
    {
        public class SpecialityForReportList : TTObjectCollection<SpecialityForReport> { }
                    
        public class ChildSpecialityForReportCollection : TTObject.TTChildObjectCollection<SpecialityForReport>
        {
            public ChildSpecialityForReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialityForReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SPTSReportEntryAction SPTSReportEntryAction
        {
            get { return (SPTSReportEntryAction)((ITTObject)this).GetParent("SPTSREPORTENTRYACTION"); }
            set { this["SPTSREPORTENTRYACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SpecialityForReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialityForReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialityForReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialityForReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialityForReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALITYFORREPORT", dataRow) { }
        protected SpecialityForReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALITYFORREPORT", dataRow, isImported) { }
        public SpecialityForReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialityForReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialityForReport() : base() { }

    }
}