
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSAdvisor")] 

    public  partial class MPBSAdvisor : MPBSPermanentTurkishPersonnel
    {
        public class MPBSAdvisorList : TTObjectCollection<MPBSAdvisor> { }
                    
        public class ChildMPBSAdvisorCollection : TTObject.TTChildObjectCollection<MPBSAdvisor>
        {
            public ChildMPBSAdvisorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSAdvisorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Danışmanlık Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Danışmanlık Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        protected MPBSAdvisor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSAdvisor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSAdvisor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSAdvisor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSAdvisor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSADVISOR", dataRow) { }
        protected MPBSAdvisor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSADVISOR", dataRow, isImported) { }
        public MPBSAdvisor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSAdvisor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSAdvisor() : base() { }

    }
}