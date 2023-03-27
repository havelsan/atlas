
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseAdditionalInfo")] 

    public  partial class BaseAdditionalInfo : TTObject
    {
        public class BaseAdditionalInfoList : TTObjectCollection<BaseAdditionalInfo> { }
                    
        public class ChildBaseAdditionalInfoCollection : TTObject.TTChildObjectCollection<BaseAdditionalInfo>
        {
            public ChildBaseAdditionalInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseAdditionalInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ekleme Tarihi / Saati
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

        public BaseAdditionalApplication BaseAdditionalApplication
        {
            get { return (BaseAdditionalApplication)((ITTObject)this).GetParent("BASEADDITIONALAPPLICATION"); }
            set { this["BASEADDITIONALAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseAdditionalInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseAdditionalInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseAdditionalInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseAdditionalInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseAdditionalInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEADDITIONALINFO", dataRow) { }
        protected BaseAdditionalInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEADDITIONALINFO", dataRow, isImported) { }
        public BaseAdditionalInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseAdditionalInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseAdditionalInfo() : base() { }

    }
}