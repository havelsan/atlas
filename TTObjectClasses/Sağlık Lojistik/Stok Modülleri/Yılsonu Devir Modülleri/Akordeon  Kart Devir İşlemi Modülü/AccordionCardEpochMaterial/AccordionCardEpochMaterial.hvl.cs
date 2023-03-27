
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccordionCardEpochMaterial")] 

    /// <summary>
    /// Akordeon Kartlar Devir Belgesi Malzeme Sekmesi
    /// </summary>
    public  partial class AccordionCardEpochMaterial : TTObject
    {
        public class AccordionCardEpochMaterialList : TTObjectCollection<AccordionCardEpochMaterial> { }
                    
        public class ChildAccordionCardEpochMaterialCollection : TTObject.TTChildObjectCollection<AccordionCardEpochMaterial>
        {
            public ChildAccordionCardEpochMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccordionCardEpochMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Şimdiki Sıra No
    /// </summary>
        public long? CurrentOrderNO
        {
            get { return (long?)this["CURRENTORDERNO"]; }
            set { this["CURRENTORDERNO"] = value; }
        }

    /// <summary>
    /// Devredilecek
    /// </summary>
        public long? EpochAmount
        {
            get { return (long?)this["EPOCHAMOUNT"]; }
            set { this["EPOCHAMOUNT"] = value; }
        }

    /// <summary>
    /// Kart Adedi 
    /// </summary>
        public long? CardCount
        {
            get { return (long?)this["CARDCOUNT"]; }
            set { this["CARDCOUNT"] = value; }
        }

    /// <summary>
    /// Bir Önceki Sıra No
    /// </summary>
        public long? LastOrderNO
        {
            get { return (long?)this["LASTORDERNO"]; }
            set { this["LASTORDERNO"] = value; }
        }

        protected AccordionCardEpochMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccordionCardEpochMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccordionCardEpochMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccordionCardEpochMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccordionCardEpochMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCORDIONCARDEPOCHMATERIAL", dataRow) { }
        protected AccordionCardEpochMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCORDIONCARDEPOCHMATERIAL", dataRow, isImported) { }
        public AccordionCardEpochMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccordionCardEpochMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccordionCardEpochMaterial() : base() { }

    }
}