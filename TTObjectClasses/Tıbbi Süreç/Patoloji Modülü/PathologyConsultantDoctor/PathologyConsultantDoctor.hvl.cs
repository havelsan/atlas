
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyConsultantDoctor")] 

    public  partial class PathologyConsultantDoctor : TTObject
    {
        public class PathologyConsultantDoctorList : TTObjectCollection<PathologyConsultantDoctor> { }
                    
        public class ChildPathologyConsultantDoctorCollection : TTObject.TTChildObjectCollection<PathologyConsultantDoctor>
        {
            public ChildPathologyConsultantDoctorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyConsultantDoctorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uzman Doktor
    /// </summary>
        public ResUser ConsultantDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("CONSULTANTDOCTOR"); }
            set { this["CONSULTANTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Testi İlişkisi
    /// </summary>
        public Pathology PathologyTest
        {
            get { return (Pathology)((ITTObject)this).GetParent("PATHOLOGYTEST"); }
            set { this["PATHOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyConsultantDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyConsultantDoctor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyConsultantDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyConsultantDoctor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyConsultantDoctor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYCONSULTANTDOCTOR", dataRow) { }
        protected PathologyConsultantDoctor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYCONSULTANTDOCTOR", dataRow, isImported) { }
        public PathologyConsultantDoctor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyConsultantDoctor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyConsultantDoctor() : base() { }

    }
}