
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_MilitaryDrugIn")] 

    /// <summary>
    /// İBF Detay kalemi - XXXXXX ilaç malzemeleri için kullanılan sınıftır. (İBF listesi dahili)
    /// </summary>
    public  partial class IBFDet_MilitaryDrugIn : IBFDetDetailIn
    {
        public class IBFDet_MilitaryDrugInList : TTObjectCollection<IBFDet_MilitaryDrugIn> { }
                    
        public class ChildIBFDet_MilitaryDrugInCollection : TTObject.TTChildObjectCollection<IBFDet_MilitaryDrugIn>
        {
            public ChildIBFDet_MilitaryDrugInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_MilitaryDrugInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
        }

    /// <summary>
    /// Toplam İstek (Kutu)
    /// </summary>
        public Currency? RequestAmountBox
        {
            get { return (Currency?)this["REQUESTAMOUNTBOX"]; }
            set { this["REQUESTAMOUNTBOX"] = value; }
        }

        protected IBFDet_MilitaryDrugIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_MilitaryDrugIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_MilitaryDrugIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_MilitaryDrugIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_MilitaryDrugIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_MILITARYDRUGIN", dataRow) { }
        protected IBFDet_MilitaryDrugIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_MILITARYDRUGIN", dataRow, isImported) { }
        public IBFDet_MilitaryDrugIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_MilitaryDrugIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_MilitaryDrugIn() : base() { }

    }
}