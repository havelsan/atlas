
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccordionCardEpoch")] 

    /// <summary>
    /// Akordeon Kartlar Devir Belgesi
    /// </summary>
    public  partial class AccordionCardEpoch : BaseAction
    {
        public class AccordionCardEpochList : TTObjectCollection<AccordionCardEpoch> { }
                    
        public class ChildAccordionCardEpochCollection : TTObject.TTChildObjectCollection<AccordionCardEpoch>
        {
            public ChildAccordionCardEpochCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccordionCardEpochCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hesap Dönemi
    /// </summary>
        public long? Term
        {
            get { return (long?)this["TERM"]; }
            set { this["TERM"] = value; }
        }

    /// <summary>
    /// Toplam Kart Sayısı
    /// </summary>
        public long? TotalCardCount
        {
            get { return (long?)this["TOTALCARDCOUNT"]; }
            set { this["TOTALCARDCOUNT"] = value; }
        }

        virtual protected void CreateAccordionCardEpochMainClassesCollection()
        {
            _AccordionCardEpochMainClasses = new AccordionCardEpochMainClass.ChildAccordionCardEpochMainClassCollection(this, new Guid("f6a809e3-161f-409c-8ba2-2e8c9a9c07c2"));
            ((ITTChildObjectCollection)_AccordionCardEpochMainClasses).GetChildren();
        }

        protected AccordionCardEpochMainClass.ChildAccordionCardEpochMainClassCollection _AccordionCardEpochMainClasses = null;
        public AccordionCardEpochMainClass.ChildAccordionCardEpochMainClassCollection AccordionCardEpochMainClasses
        {
            get
            {
                if (_AccordionCardEpochMainClasses == null)
                    CreateAccordionCardEpochMainClassesCollection();
                return _AccordionCardEpochMainClasses;
            }
        }

        protected AccordionCardEpoch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccordionCardEpoch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccordionCardEpoch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccordionCardEpoch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccordionCardEpoch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCORDIONCARDEPOCH", dataRow) { }
        protected AccordionCardEpoch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCORDIONCARDEPOCH", dataRow, isImported) { }
        public AccordionCardEpoch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccordionCardEpoch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccordionCardEpoch() : base() { }

    }
}