
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsignedCensusFixedMaterialOut")] 

    /// <summary>
    /// Muvakkaten Sayım Düzeltme Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class ConsignedCensusFixedMaterialOut : StockActionDetailOut
    {
        public class ConsignedCensusFixedMaterialOutList : TTObjectCollection<ConsignedCensusFixedMaterialOut> { }
                    
        public class ChildConsignedCensusFixedMaterialOutCollection : TTObject.TTChildObjectCollection<ConsignedCensusFixedMaterialOut>
        {
            public ChildConsignedCensusFixedMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsignedCensusFixedMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sayılan Miktar
    /// </summary>
        public Currency? CensusAmount
        {
            get { return (Currency?)this["CENSUSAMOUNT"]; }
            set { this["CENSUSAMOUNT"] = value; }
        }

    /// <summary>
    /// Stok Kart Kayıt Nevi
    /// </summary>
        public Currency? CardAmount
        {
            get { return (Currency?)this["CARDAMOUNT"]; }
            set { this["CARDAMOUNT"] = value; }
        }

    /// <summary>
    /// Sayım Fişi Numarası
    /// </summary>
        public long? OrderSequenceNumber
        {
            get { return (long?)this["ORDERSEQUENCENUMBER"]; }
            set { this["ORDERSEQUENCENUMBER"] = value; }
        }

        protected ConsignedCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsignedCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsignedCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsignedCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsignedCensusFixedMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSIGNEDCENSUSFIXEDMATERIALOUT", dataRow) { }
        protected ConsignedCensusFixedMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSIGNEDCENSUSFIXEDMATERIALOUT", dataRow, isImported) { }
        public ConsignedCensusFixedMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsignedCensusFixedMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsignedCensusFixedMaterialOut() : base() { }

    }
}