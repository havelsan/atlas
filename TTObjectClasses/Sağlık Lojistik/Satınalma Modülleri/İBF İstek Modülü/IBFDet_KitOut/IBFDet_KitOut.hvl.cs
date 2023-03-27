
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_KitOut")] 

    /// <summary>
    /// İBF Detay kalemi - Kitler için kullanılan sınıftır. (İBF listesi harici)
    /// </summary>
    public  partial class IBFDet_KitOut : IBFDetDetailOut
    {
        public class IBFDet_KitOutList : TTObjectCollection<IBFDet_KitOut> { }
                    
        public class ChildIBFDet_KitOutCollection : TTObject.TTChildObjectCollection<IBFDet_KitOut>
        {
            public ChildIBFDet_KitOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_KitOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Üretim Durumu
    /// </summary>
        public string ProductStatus
        {
            get { return (string)this["PRODUCTSTATUS"]; }
            set { this["PRODUCTSTATUS"] = value; }
        }

    /// <summary>
    /// 1. Grup (Ocak - Haziran) İstek Miktarı
    /// </summary>
        public Currency? FirstRequestAmount
        {
            get { return (Currency?)this["FIRSTREQUESTAMOUNT"]; }
            set { this["FIRSTREQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// 2. Grup (Temmuz - Aralık) İstek Miktarı
    /// </summary>
        public Currency? SecondRequestAmount
        {
            get { return (Currency?)this["SECONDREQUESTAMOUNT"]; }
            set { this["SECONDREQUESTAMOUNT"] = value; }
        }

        protected IBFDet_KitOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_KitOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_KitOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_KitOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_KitOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_KITOUT", dataRow) { }
        protected IBFDet_KitOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_KITOUT", dataRow, isImported) { }
        public IBFDet_KitOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_KitOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_KitOut() : base() { }

    }
}