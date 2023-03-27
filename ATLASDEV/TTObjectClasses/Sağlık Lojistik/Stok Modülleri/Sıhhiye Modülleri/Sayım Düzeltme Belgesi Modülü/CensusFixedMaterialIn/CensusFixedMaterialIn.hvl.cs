
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusFixedMaterialIn")] 

    /// <summary>
    /// Sayım Düzeltme Belgesi - Arttırılan malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class CensusFixedMaterialIn : StockActionDetailIn
    {
        public class CensusFixedMaterialInList : TTObjectCollection<CensusFixedMaterialIn> { }
                    
        public class ChildCensusFixedMaterialInCollection : TTObject.TTChildObjectCollection<CensusFixedMaterialIn>
        {
            public ChildCensusFixedMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusFixedMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Sayılan Miktar
    /// </summary>
        public Currency? CensusAmount
        {
            get { return (Currency?)this["CENSUSAMOUNT"]; }
            set { this["CENSUSAMOUNT"] = value; }
        }

    /// <summary>
    /// Sayım Fişi Numarası
    /// </summary>
        public long? OrderSequenceNumber
        {
            get { return (long?)this["ORDERSEQUENCENUMBER"]; }
            set { this["ORDERSEQUENCENUMBER"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public CensusFixed CensusFixed
        {
            get 
            {   
                if (StockAction is CensusFixed)
                    return (CensusFixed)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected CensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusFixedMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSFIXEDMATERIALIN", dataRow) { }
        protected CensusFixedMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSFIXEDMATERIALIN", dataRow, isImported) { }
        public CensusFixedMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusFixedMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusFixedMaterialIn() : base() { }

    }
}