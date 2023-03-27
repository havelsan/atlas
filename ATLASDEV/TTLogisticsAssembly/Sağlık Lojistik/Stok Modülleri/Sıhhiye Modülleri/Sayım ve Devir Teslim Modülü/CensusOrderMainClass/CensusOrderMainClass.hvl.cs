
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusOrderMainClass")] 

    /// <summary>
    /// Sayım Emri
    /// </summary>
    public  partial class CensusOrderMainClass : TTObject
    {
        public class CensusOrderMainClassList : TTObjectCollection<CensusOrderMainClass> { }
                    
        public class ChildCensusOrderMainClassCollection : TTObject.TTChildObjectCollection<CensusOrderMainClass>
        {
            public ChildCensusOrderMainClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusOrderMainClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kart Sayısı
    /// </summary>
        public int? CardCount
        {
            get { return (int?)this["CARDCOUNT"]; }
            set { this["CARDCOUNT"] = value; }
        }

    /// <summary>
    /// Kart Adeti
    /// </summary>
        public int? CardAmount
        {
            get { return (int?)this["CARDAMOUNT"]; }
            set { this["CARDAMOUNT"] = value; }
        }

        public StockCardClass StockCardClass
        {
            get { return (StockCardClass)((ITTObject)this).GetParent("STOCKCARDCLASS"); }
            set { this["STOCKCARDCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CensusOrder CensusOrder
        {
            get { return (CensusOrder)((ITTObject)this).GetParent("CENSUSORDER"); }
            set { this["CENSUSORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CensusOrderByStore CensusOrderByStore
        {
            get { return (CensusOrderByStore)((ITTObject)this).GetParent("CENSUSORDERBYSTORE"); }
            set { this["CENSUSORDERBYSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CensusOrderMainClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusOrderMainClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusOrderMainClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusOrderMainClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusOrderMainClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSORDERMAINCLASS", dataRow) { }
        protected CensusOrderMainClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSORDERMAINCLASS", dataRow, isImported) { }
        public CensusOrderMainClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusOrderMainClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusOrderMainClass() : base() { }

    }
}