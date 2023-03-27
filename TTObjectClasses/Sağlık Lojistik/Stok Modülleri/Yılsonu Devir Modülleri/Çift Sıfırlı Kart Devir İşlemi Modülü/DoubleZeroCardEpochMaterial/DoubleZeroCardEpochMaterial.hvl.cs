
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoubleZeroCardEpochMaterial")] 

    /// <summary>
    /// Çift Sıfırlı Kartlar Devir Belgesi  Malzeme Sekmesi
    /// </summary>
    public  partial class DoubleZeroCardEpochMaterial : TTObject
    {
        public class DoubleZeroCardEpochMaterialList : TTObjectCollection<DoubleZeroCardEpochMaterial> { }
                    
        public class ChildDoubleZeroCardEpochMaterialCollection : TTObject.TTChildObjectCollection<DoubleZeroCardEpochMaterial>
        {
            public ChildDoubleZeroCardEpochMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoubleZeroCardEpochMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CensusReportNQL_DoubleZeros_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Nsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Censusorder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CENSUSORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCHMATERIAL"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DoubleZeros_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DoubleZeros_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DoubleZeros_Class() : base() { }
        }

        public static BindingList<DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class> CensusReportNQL_DoubleZeros(string TERMID, string CARDDRAWER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCHMATERIAL"].QueryDefs["CensusReportNQL_DoubleZeros"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("CARDDRAWER", CARDDRAWER);

            return TTReportNqlObject.QueryObjects<DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class> CensusReportNQL_DoubleZeros(TTObjectContext objectContext, string TERMID, string CARDDRAWER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCHMATERIAL"].QueryDefs["CensusReportNQL_DoubleZeros"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("CARDDRAWER", CARDDRAWER);

            return TTReportNqlObject.QueryObjects<DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class>(objectContext, queryDef, paramList, pi);
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
    /// Elle Eklenmiş 
    /// </summary>
        public bool? AddedManually
        {
            get { return (bool?)this["ADDEDMANUALLY"]; }
            set { this["ADDEDMANUALLY"] = value; }
        }

    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Existing
        {
            get { return (Currency?)this["EXISTING"]; }
            set { this["EXISTING"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public long? OrderNo
        {
            get { return (long?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Bağlı Malzemeler
    /// </summary>
        public long? DependentMaterials
        {
            get { return (long?)this["DEPENDENTMATERIALS"]; }
            set { this["DEPENDENTMATERIALS"] = value; }
        }

        public StockCardStatusEnum? OldStockCardStatus
        {
            get { return (StockCardStatusEnum?)(int?)this["OLDSTOCKCARDSTATUS"]; }
            set { this["OLDSTOCKCARDSTATUS"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DoubleZeroCardEpoch DoubleZeroCardEpoch
        {
            get { return (DoubleZeroCardEpoch)((ITTObject)this).GetParent("DOUBLEZEROCARDEPOCH"); }
            set { this["DOUBLEZEROCARDEPOCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoubleZeroCardEpochMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoubleZeroCardEpochMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoubleZeroCardEpochMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoubleZeroCardEpochMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoubleZeroCardEpochMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOUBLEZEROCARDEPOCHMATERIAL", dataRow) { }
        protected DoubleZeroCardEpochMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOUBLEZEROCARDEPOCHMATERIAL", dataRow, isImported) { }
        public DoubleZeroCardEpochMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoubleZeroCardEpochMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoubleZeroCardEpochMaterial() : base() { }

    }
}