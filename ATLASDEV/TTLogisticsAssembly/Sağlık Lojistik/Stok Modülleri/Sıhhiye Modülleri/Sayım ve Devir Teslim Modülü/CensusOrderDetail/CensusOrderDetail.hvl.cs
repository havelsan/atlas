
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusOrderDetail")] 

    /// <summary>
    /// Sayım Emrinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class CensusOrderDetail : TTObject
    {
        public class CensusOrderDetailList : TTObjectCollection<CensusOrderDetail> { }
                    
        public class ChildCensusOrderDetailCollection : TTObject.TTChildObjectCollection<CensusOrderDetail>
        {
            public ChildCensusOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yeni Mevcut
    /// </summary>
        public Currency? NewInheld
        {
            get { return (Currency?)this["NEWINHELD"]; }
            set { this["NEWINHELD"] = value; }
        }

    /// <summary>
    /// Kullanılmış Mevcut
    /// </summary>
        public Currency? UsedInheld
        {
            get { return (Currency?)this["USEDINHELD"]; }
            set { this["USEDINHELD"] = value; }
        }

    /// <summary>
    /// Muvakkat
    /// </summary>
        public Currency? Consigned
        {
            get { return (Currency?)this["CONSIGNED"]; }
            set { this["CONSIGNED"] = value; }
        }

    /// <summary>
    /// Sayılan Yeni Miktar
    /// </summary>
        public Currency? CensusNewInheld
        {
            get { return (Currency?)this["CENSUSNEWINHELD"]; }
            set { this["CENSUSNEWINHELD"] = value; }
        }

    /// <summary>
    /// Sayılan Kullanılmış Miktar
    /// </summary>
        public Currency? CensusUsedInheld
        {
            get { return (Currency?)this["CENSUSUSEDINHELD"]; }
            set { this["CENSUSUSEDINHELD"] = value; }
        }

    /// <summary>
    /// Sıra Numarası
    /// </summary>
        public long? OrderSequenceNumber
        {
            get { return (long?)this["ORDERSEQUENCENUMBER"]; }
            set { this["ORDERSEQUENCENUMBER"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public CensusOrder CensusOrder
        {
            get { return (CensusOrder)((ITTObject)this).GetParent("CENSUSORDER"); }
            set { this["CENSUSORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CensusOrderByStore CensusOrderByStore
        {
            get { return (CensusOrderByStore)((ITTObject)this).GetParent("CENSUSORDERBYSTORE"); }
            set { this["CENSUSORDERBYSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CensusOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSORDERDETAIL", dataRow) { }
        protected CensusOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSORDERDETAIL", dataRow, isImported) { }
        public CensusOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusOrderDetail() : base() { }

    }
}