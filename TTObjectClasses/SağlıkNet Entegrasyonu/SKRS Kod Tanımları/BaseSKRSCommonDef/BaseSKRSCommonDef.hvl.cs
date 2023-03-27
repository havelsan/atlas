
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseSKRSCommonDef")] 

    /// <summary>
    /// Ortak SKRS Kodlarının bağlı olduğu base
    /// </summary>
    public  partial class BaseSKRSCommonDef : BaseSKRSDefinition
    {
        public class BaseSKRSCommonDefList : TTObjectCollection<BaseSKRSCommonDef> { }
                    
        public class ChildBaseSKRSCommonDefCollection : TTObject.TTChildObjectCollection<BaseSKRSCommonDef>
        {
            public ChildBaseSKRSCommonDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseSKRSCommonDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public string KODTIPIADI
        {
            get { return (string)this["KODTIPIADI"]; }
            set { this["KODTIPIADI"] = value; }
        }

        public string KODU
        {
            get { return (string)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public DateTime? OLUSTURULMATARIHI1
        {
            get { return (DateTime?)this["OLUSTURULMATARIHI1"]; }
            set { this["OLUSTURULMATARIHI1"] = value; }
        }

        public DateTime? GUNCELLENMETARIHI1
        {
            get { return (DateTime?)this["GUNCELLENMETARIHI1"]; }
            set { this["GUNCELLENMETARIHI1"] = value; }
        }

        protected BaseSKRSCommonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseSKRSCommonDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseSKRSCommonDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseSKRSCommonDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseSKRSCommonDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASESKRSCOMMONDEF", dataRow) { }
        protected BaseSKRSCommonDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASESKRSCOMMONDEF", dataRow, isImported) { }
        public BaseSKRSCommonDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseSKRSCommonDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseSKRSCommonDef() : base() { }

    }
}