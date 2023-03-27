
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoubleZeroCardEpochMainClass")] 

    /// <summary>
    /// Çift Sıfırlı Kartlar Devir Belgesi - Teknik Ana Sınıfı
    /// </summary>
    public  partial class DoubleZeroCardEpochMainClass : TTObject
    {
        public class DoubleZeroCardEpochMainClassList : TTObjectCollection<DoubleZeroCardEpochMainClass> { }
                    
        public class ChildDoubleZeroCardEpochMainClassCollection : TTObject.TTChildObjectCollection<DoubleZeroCardEpochMainClass>
        {
            public ChildDoubleZeroCardEpochMainClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoubleZeroCardEpochMainClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kart Adedi
    /// </summary>
        public Currency? CardAmount
        {
            get { return (Currency?)this["CARDAMOUNT"]; }
            set { this["CARDAMOUNT"] = value; }
        }

    /// <summary>
    /// Kart Sayısı
    /// </summary>
        public Currency? CardCount
        {
            get { return (Currency?)this["CARDCOUNT"]; }
            set { this["CARDCOUNT"] = value; }
        }

        public DoubleZeroCardEpoch DoubleZeroCardEpoch
        {
            get { return (DoubleZeroCardEpoch)((ITTObject)this).GetParent("DOUBLEZEROCARDEPOCH"); }
            set { this["DOUBLEZEROCARDEPOCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCardClass StockCardClass
        {
            get { return (StockCardClass)((ITTObject)this).GetParent("STOCKCARDCLASS"); }
            set { this["STOCKCARDCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoubleZeroCardEpochMainClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoubleZeroCardEpochMainClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoubleZeroCardEpochMainClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoubleZeroCardEpochMainClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoubleZeroCardEpochMainClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOUBLEZEROCARDEPOCHMAINCLASS", dataRow) { }
        protected DoubleZeroCardEpochMainClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOUBLEZEROCARDEPOCHMAINCLASS", dataRow, isImported) { }
        public DoubleZeroCardEpochMainClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoubleZeroCardEpochMainClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoubleZeroCardEpochMainClass() : base() { }

    }
}