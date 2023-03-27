
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusOrderByStore")] 

    /// <summary>
    /// Sayım işlemi depo seçilerek
    /// </summary>
    public  partial class CensusOrderByStore : StockAction, ICensusOrderByStore
    {
        public class CensusOrderByStoreList : TTObjectCollection<CensusOrderByStore> { }
                    
        public class ChildCensusOrderByStoreCollection : TTObject.TTChildObjectCollection<CensusOrderByStore>
        {
            public ChildCensusOrderByStoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusOrderByStoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CensusRecordByStoreRQ_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Orderdetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDERDETAILOBJECTID"]);
                }
            }

            public long? OrderSequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERSEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["ORDERSEQUENCENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheldnew
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELDNEW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["CENSUSNEWINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public Currency? CensusNewInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CENSUSNEWINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERDETAIL"].AllPropertyDefs["CENSUSNEWINHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public CensusRecordByStoreRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusRecordByStoreRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusRecordByStoreRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Approval { get { return new Guid("fb5f4ef8-fbaf-4d88-bfb4-21c945193369"); } }
            public static Guid Cancelled { get { return new Guid("4391cdeb-a824-43c3-b7c4-7afb1eb1a516"); } }
            public static Guid Completed { get { return new Guid("90354697-863c-4dad-9183-ddefa4e4aa91"); } }
            public static Guid New { get { return new Guid("110386fa-5b7e-4f5a-9f13-8cf1f8eaf0f0"); } }
            public static Guid StockCardRegistry { get { return new Guid("7ff14353-a1ee-41dc-a928-93449b91b87e"); } }
        }

        public static BindingList<CensusOrderByStore.CensusRecordByStoreRQ_Class> CensusRecordByStoreRQ(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERBYSTORE"].QueryDefs["CensusRecordByStoreRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrderByStore.CensusRecordByStoreRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusOrderByStore.CensusRecordByStoreRQ_Class> CensusRecordByStoreRQ(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSORDERBYSTORE"].QueryDefs["CensusRecordByStoreRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CensusOrderByStore.CensusRecordByStoreRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sayım Emri Tipi
    /// </summary>
        public CensusOrderTypeEnum? CensusOrderType
        {
            get { return (CensusOrderTypeEnum?)(int?)this["CENSUSORDERTYPE"]; }
            set { this["CENSUSORDERTYPE"] = value; }
        }

    /// <summary>
    /// Toplam Kart Sayısı
    /// </summary>
        public long? TotalCardCount
        {
            get { return (long?)this["TOTALCARDCOUNT"]; }
            set { this["TOTALCARDCOUNT"] = value; }
        }

    /// <summary>
    /// Sayımın Yapıldığı Masa
    /// </summary>
        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCensusOrderDetailsCollection()
        {
            _CensusOrderDetails = new CensusOrderDetail.ChildCensusOrderDetailCollection(this, new Guid("84b1992e-3a75-4479-87e1-8c2664e8d486"));
            ((ITTChildObjectCollection)_CensusOrderDetails).GetChildren();
        }

        protected CensusOrderDetail.ChildCensusOrderDetailCollection _CensusOrderDetails = null;
        public CensusOrderDetail.ChildCensusOrderDetailCollection CensusOrderDetails
        {
            get
            {
                if (_CensusOrderDetails == null)
                    CreateCensusOrderDetailsCollection();
                return _CensusOrderDetails;
            }
        }

        virtual protected void CreateCensusOrderMainClassesCollection()
        {
            _CensusOrderMainClasses = new CensusOrderMainClass.ChildCensusOrderMainClassCollection(this, new Guid("42bdd22e-e133-48dc-a2de-02f47ed68632"));
            ((ITTChildObjectCollection)_CensusOrderMainClasses).GetChildren();
        }

        protected CensusOrderMainClass.ChildCensusOrderMainClassCollection _CensusOrderMainClasses = null;
        public CensusOrderMainClass.ChildCensusOrderMainClassCollection CensusOrderMainClasses
        {
            get
            {
                if (_CensusOrderMainClasses == null)
                    CreateCensusOrderMainClassesCollection();
                return _CensusOrderMainClasses;
            }
        }

        protected CensusOrderByStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusOrderByStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusOrderByStore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusOrderByStore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusOrderByStore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSORDERBYSTORE", dataRow) { }
        protected CensusOrderByStore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSORDERBYSTORE", dataRow, isImported) { }
        public CensusOrderByStore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusOrderByStore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusOrderByStore() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}