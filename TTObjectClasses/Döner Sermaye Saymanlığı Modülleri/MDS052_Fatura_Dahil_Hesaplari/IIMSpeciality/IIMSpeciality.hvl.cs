
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IIMSpeciality")] 

    public  partial class IIMSpeciality : TTObject
    {
        public class IIMSpecialityList : TTObjectCollection<IIMSpeciality> { }
                    
        public class ChildIIMSpecialityCollection : TTObject.TTChildObjectCollection<IIMSpeciality>
        {
            public ChildIIMSpecialityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIIMSpecialityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? Checked
        {
            get { return (bool?)this["CHECKED"]; }
            set { this["CHECKED"] = value; }
        }

    /// <summary>
    /// Kuralın Branş bilgisi
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Branş bilgisi
    /// </summary>
        public InvoiceInclusionMaster InvoiceInclusionMaster
        {
            get { return (InvoiceInclusionMaster)((ITTObject)this).GetParent("INVOICEINCLUSIONMASTER"); }
            set { this["INVOICEINCLUSIONMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IIMSpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IIMSpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IIMSpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IIMSpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IIMSpeciality(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IIMSPECIALITY", dataRow) { }
        protected IIMSpeciality(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IIMSPECIALITY", dataRow, isImported) { }
        public IIMSpeciality(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IIMSpeciality(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IIMSpeciality() : base() { }

    }
}