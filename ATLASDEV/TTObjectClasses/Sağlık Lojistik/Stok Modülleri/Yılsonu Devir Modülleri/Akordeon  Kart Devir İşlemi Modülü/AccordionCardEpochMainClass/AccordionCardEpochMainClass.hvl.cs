
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccordionCardEpochMainClass")] 

    /// <summary>
    /// Akordeon Kartlar Devir Belgesi - Teknik Ana Sınıf
    /// </summary>
    public  partial class AccordionCardEpochMainClass : TTObject
    {
        public class AccordionCardEpochMainClassList : TTObjectCollection<AccordionCardEpochMainClass> { }
                    
        public class ChildAccordionCardEpochMainClassCollection : TTObject.TTChildObjectCollection<AccordionCardEpochMainClass>
        {
            public ChildAccordionCardEpochMainClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccordionCardEpochMainClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kart Sayısı
    /// </summary>
        public string CardCount
        {
            get { return (string)this["CARDCOUNT"]; }
            set { this["CARDCOUNT"] = value; }
        }

    /// <summary>
    /// Kart Adedi
    /// </summary>
        public string CardAmount
        {
            get { return (string)this["CARDAMOUNT"]; }
            set { this["CARDAMOUNT"] = value; }
        }

        public AccordionCardEpoch AccordionCardEpoch
        {
            get { return (AccordionCardEpoch)((ITTObject)this).GetParent("ACCORDIONCARDEPOCH"); }
            set { this["ACCORDIONCARDEPOCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCardClass StockCardClass
        {
            get { return (StockCardClass)((ITTObject)this).GetParent("STOCKCARDCLASS"); }
            set { this["STOCKCARDCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccordionCardEpochMainClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccordionCardEpochMainClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccordionCardEpochMainClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccordionCardEpochMainClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccordionCardEpochMainClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCORDIONCARDEPOCHMAINCLASS", dataRow) { }
        protected AccordionCardEpochMainClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCORDIONCARDEPOCHMAINCLASS", dataRow, isImported) { }
        public AccordionCardEpochMainClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccordionCardEpochMainClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccordionCardEpochMainClass() : base() { }

    }
}