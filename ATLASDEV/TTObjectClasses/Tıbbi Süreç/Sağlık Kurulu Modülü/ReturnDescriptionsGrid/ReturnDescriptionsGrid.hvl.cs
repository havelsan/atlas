
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReturnDescriptionsGrid")] 

    /// <summary>
    /// İade Sebepleri Grid Base Class ı
    /// </summary>
    public  partial class ReturnDescriptionsGrid : TTObject
    {
        public class ReturnDescriptionsGridList : TTObjectCollection<ReturnDescriptionsGrid> { }
                    
        public class ChildReturnDescriptionsGridCollection : TTObject.TTChildObjectCollection<ReturnDescriptionsGrid>
        {
            public ChildReturnDescriptionsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReturnDescriptionsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Giriş Tarihi
    /// </summary>
        public DateTime? EntryDate
        {
            get { return (DateTime?)this["ENTRYDATE"]; }
            set { this["ENTRYDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kullanıcı adı
    /// </summary>
        public string UserName
        {
            get { return (string)this["USERNAME"]; }
            set { this["USERNAME"] = value; }
        }

        protected ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReturnDescriptionsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReturnDescriptionsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RETURNDESCRIPTIONSGRID", dataRow) { }
        protected ReturnDescriptionsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RETURNDESCRIPTIONSGRID", dataRow, isImported) { }
        public ReturnDescriptionsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReturnDescriptionsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReturnDescriptionsGrid() : base() { }

    }
}