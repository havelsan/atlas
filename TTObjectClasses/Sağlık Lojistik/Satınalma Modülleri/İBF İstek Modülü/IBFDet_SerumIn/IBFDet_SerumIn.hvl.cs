
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_SerumIn")] 

    /// <summary>
    /// İBF Detay kalemi - Serumlar için kullanılan sınıftır. (İBF listesi dahili)
    /// </summary>
    public  partial class IBFDet_SerumIn : IBFDetDetailIn
    {
        public class IBFDet_SerumInList : TTObjectCollection<IBFDet_SerumIn> { }
                    
        public class ChildIBFDet_SerumInCollection : TTObject.TTChildObjectCollection<IBFDet_SerumIn>
        {
            public ChildIBFDet_SerumInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_SerumInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected IBFDet_SerumIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_SerumIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_SerumIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_SerumIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_SerumIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_SERUMIN", dataRow) { }
        protected IBFDet_SerumIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_SERUMIN", dataRow, isImported) { }
        public IBFDet_SerumIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_SerumIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_SerumIn() : base() { }

    }
}