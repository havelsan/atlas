
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReProcessStudy")] 

    /// <summary>
    /// Teletıp Yeniden Eşleştir
    /// </summary>
    public  partial class ReProcessStudy : BaseScheduledTask
    {
        public class ReProcessStudyList : TTObjectCollection<ReProcessStudy> { }
                    
        public class ChildReProcessStudyCollection : TTObject.TTChildObjectCollection<ReProcessStudy>
        {
            public ChildReProcessStudyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReProcessStudyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ReProcessStudy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReProcessStudy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReProcessStudy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReProcessStudy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReProcessStudy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPROCESSSTUDY", dataRow) { }
        protected ReProcessStudy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPROCESSSTUDY", dataRow, isImported) { }
        public ReProcessStudy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReProcessStudy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReProcessStudy() : base() { }

    }
}