
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntensiveCareAfterSurgeryResponsiblePersonnel")] 

    /// <summary>
    /// Sorumlu Personel
    /// </summary>
    public  partial class IntensiveCareAfterSurgeryResponsiblePersonnel : TTObject
    {
        public class IntensiveCareAfterSurgeryResponsiblePersonnelList : TTObjectCollection<IntensiveCareAfterSurgeryResponsiblePersonnel> { }
                    
        public class ChildIntensiveCareAfterSurgeryResponsiblePersonnelCollection : TTObject.TTChildObjectCollection<IntensiveCareAfterSurgeryResponsiblePersonnel>
        {
            public ChildIntensiveCareAfterSurgeryResponsiblePersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntensiveCareAfterSurgeryResponsiblePersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Job
        {
            get { return (string)this["JOB"]; }
            set { this["JOB"] = value; }
        }

        public DateTime? SDateTime
        {
            get { return (DateTime?)this["SDATETIME"]; }
            set { this["SDATETIME"] = value; }
        }

    /// <summary>
    /// Sorumlu Personel
    /// </summary>
        public IntensiveCareAfterSurgery IntensiveCareAfterSurgery
        {
            get { return (IntensiveCareAfterSurgery)((ITTObject)this).GetParent("INTENSIVECAREAFTERSURGERY"); }
            set { this["INTENSIVECAREAFTERSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Personel
    /// </summary>
        public ResUser ResponsiblePersonnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEPERSONNEL"); }
            set { this["RESPONSIBLEPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTENSIVECAREAFTERSURGERYRESPONSIBLEPERSONNEL", dataRow) { }
        protected IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTENSIVECAREAFTERSURGERYRESPONSIBLEPERSONNEL", dataRow, isImported) { }
        public IntensiveCareAfterSurgeryResponsiblePersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntensiveCareAfterSurgeryResponsiblePersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntensiveCareAfterSurgeryResponsiblePersonnel() : base() { }

    }
}