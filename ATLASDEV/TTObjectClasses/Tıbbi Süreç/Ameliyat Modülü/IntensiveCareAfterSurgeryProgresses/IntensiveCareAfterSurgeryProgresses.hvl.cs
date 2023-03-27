
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntensiveCareAfterSurgeryProgresses")] 

    /// <summary>
    /// Hastanın Güncesi
    /// </summary>
    public  partial class IntensiveCareAfterSurgeryProgresses : TTObject
    {
        public class IntensiveCareAfterSurgeryProgressesList : TTObjectCollection<IntensiveCareAfterSurgeryProgresses> { }
                    
        public class ChildIntensiveCareAfterSurgeryProgressesCollection : TTObject.TTChildObjectCollection<IntensiveCareAfterSurgeryProgresses>
        {
            public ChildIntensiveCareAfterSurgeryProgressesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntensiveCareAfterSurgeryProgressesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hastanın Güncesi
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? SDateTime
        {
            get { return (DateTime?)this["SDATETIME"]; }
            set { this["SDATETIME"] = value; }
        }

    /// <summary>
    /// Hastanın Güncesi
    /// </summary>
        public IntensiveCareAfterSurgery IntensiveCareAfterSurgery
        {
            get { return (IntensiveCareAfterSurgery)((ITTObject)this).GetParent("INTENSIVECAREAFTERSURGERY"); }
            set { this["INTENSIVECAREAFTERSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTENSIVECAREAFTERSURGERYPROGRESSES", dataRow) { }
        protected IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTENSIVECAREAFTERSURGERYPROGRESSES", dataRow, isImported) { }
        public IntensiveCareAfterSurgeryProgresses(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntensiveCareAfterSurgeryProgresses(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntensiveCareAfterSurgeryProgresses() : base() { }

    }
}