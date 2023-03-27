
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ArchiveDeliveryFormDetails")] 

    /// <summary>
    /// Hasta Teslim Form Detayları
    /// </summary>
    public  partial class ArchiveDeliveryFormDetails : TTObject
    {
        public class ArchiveDeliveryFormDetailsList : TTObjectCollection<ArchiveDeliveryFormDetails> { }
                    
        public class ChildArchiveDeliveryFormDetailsCollection : TTObject.TTChildObjectCollection<ArchiveDeliveryFormDetails>
        {
            public ChildArchiveDeliveryFormDetailsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildArchiveDeliveryFormDetailsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? IsSelected
        {
            get { return (bool?)this["ISSELECTED"]; }
            set { this["ISSELECTED"] = value; }
        }

    /// <summary>
    /// Sayfa Sayısı
    /// </summary>
        public string PageNumber
        {
            get { return (string)this["PAGENUMBER"]; }
            set { this["PAGENUMBER"] = value; }
        }

        public ArchiveDeliveryForm ArchiveDeliveryForm
        {
            get { return (ArchiveDeliveryForm)((ITTObject)this).GetParent("ARCHIVEDELIVERYFORM"); }
            set { this["ARCHIVEDELIVERYFORM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientFolderContentDefinition FolderContent
        {
            get { return (PatientFolderContentDefinition)((ITTObject)this).GetParent("FOLDERCONTENT"); }
            set { this["FOLDERCONTENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ArchiveDeliveryFormDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ArchiveDeliveryFormDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ArchiveDeliveryFormDetails(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ArchiveDeliveryFormDetails(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ArchiveDeliveryFormDetails(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARCHIVEDELIVERYFORMDETAILS", dataRow) { }
        protected ArchiveDeliveryFormDetails(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARCHIVEDELIVERYFORMDETAILS", dataRow, isImported) { }
        public ArchiveDeliveryFormDetails(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ArchiveDeliveryFormDetails(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ArchiveDeliveryFormDetails() : base() { }

    }
}