
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoubleZeroCardEpoch")] 

    /// <summary>
    /// Çift Sıfırlı Kartlar Devir Belgesi
    /// </summary>
    public  partial class DoubleZeroCardEpoch : BaseAction, IWorkListBaseAction
    {
        public class DoubleZeroCardEpochList : TTObjectCollection<DoubleZeroCardEpoch> { }
                    
        public class ChildDoubleZeroCardEpochCollection : TTObject.TTChildObjectCollection<DoubleZeroCardEpoch>
        {
            public ChildDoubleZeroCardEpochCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoubleZeroCardEpochCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDoubleZeroCardCensusReportQuery_Class : TTReportNqlObject 
        {
            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
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

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public StockCardStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["STATUS"].DataType;
                    return (StockCardStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? CardCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCHMATERIAL"].AllPropertyDefs["CARDCOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetDoubleZeroCardCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoubleZeroCardCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoubleZeroCardCensusReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldOrderNoQuery_Class : TTReportNqlObject 
        {
            public long? CardOrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["CARDORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetOldOrderNoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldOrderNoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldOrderNoQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("881065ff-5a9a-43d1-836d-0533f7ef23ed"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("b3016a49-f2cd-4e26-aea0-5b29d21081ea"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("0d85ea2e-478f-4008-b080-b3e263838dfc"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7a94c98c-64e9-480c-b60e-7595c4b0ad89"); } }
        }

        public static BindingList<DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class> GetDoubleZeroCardCensusReportQuery(Guid MAINCLASSID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCH"].QueryDefs["GetDoubleZeroCardCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINCLASSID", MAINCLASSID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class> GetDoubleZeroCardCensusReportQuery(TTObjectContext objectContext, Guid MAINCLASSID, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCH"].QueryDefs["GetDoubleZeroCardCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINCLASSID", MAINCLASSID);
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DoubleZeroCardEpoch.GetOldOrderNoQuery_Class> GetOldOrderNoQuery(int PREVIOUSTERM, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCH"].QueryDefs["GetOldOrderNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PREVIOUSTERM", PREVIOUSTERM);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<DoubleZeroCardEpoch.GetOldOrderNoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DoubleZeroCardEpoch.GetOldOrderNoQuery_Class> GetOldOrderNoQuery(TTObjectContext objectContext, int PREVIOUSTERM, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCH"].QueryDefs["GetOldOrderNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PREVIOUSTERM", PREVIOUSTERM);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<DoubleZeroCardEpoch.GetOldOrderNoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DoubleZeroCardEpoch> GetDoubleZeroByStoreAndTerm(TTObjectContext objectContext, Guid STOREID, Guid TERMID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOUBLEZEROCARDEPOCH"].QueryDefs["GetDoubleZeroByStoreAndTerm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("TERMID", TERMID);

            return ((ITTQuery)objectContext).QueryObjects<DoubleZeroCardEpoch>(queryDef, paramList);
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
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public AccountingTerm Term
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("TERM"); }
            set { this["TERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MainStoreDefinition Store
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDoubleZeroCardEpochMainClassesCollection()
        {
            _DoubleZeroCardEpochMainClasses = new DoubleZeroCardEpochMainClass.ChildDoubleZeroCardEpochMainClassCollection(this, new Guid("c000459f-44ec-4197-9224-0a65e7fa94c7"));
            ((ITTChildObjectCollection)_DoubleZeroCardEpochMainClasses).GetChildren();
        }

        protected DoubleZeroCardEpochMainClass.ChildDoubleZeroCardEpochMainClassCollection _DoubleZeroCardEpochMainClasses = null;
        public DoubleZeroCardEpochMainClass.ChildDoubleZeroCardEpochMainClassCollection DoubleZeroCardEpochMainClasses
        {
            get
            {
                if (_DoubleZeroCardEpochMainClasses == null)
                    CreateDoubleZeroCardEpochMainClassesCollection();
                return _DoubleZeroCardEpochMainClasses;
            }
        }

        virtual protected void CreateDoubleZeroCardEpochMaterialsCollection()
        {
            _DoubleZeroCardEpochMaterials = new DoubleZeroCardEpochMaterial.ChildDoubleZeroCardEpochMaterialCollection(this, new Guid("f32ef6c9-cba8-4efe-9e80-b96155ab1886"));
            ((ITTChildObjectCollection)_DoubleZeroCardEpochMaterials).GetChildren();
        }

        protected DoubleZeroCardEpochMaterial.ChildDoubleZeroCardEpochMaterialCollection _DoubleZeroCardEpochMaterials = null;
        public DoubleZeroCardEpochMaterial.ChildDoubleZeroCardEpochMaterialCollection DoubleZeroCardEpochMaterials
        {
            get
            {
                if (_DoubleZeroCardEpochMaterials == null)
                    CreateDoubleZeroCardEpochMaterialsCollection();
                return _DoubleZeroCardEpochMaterials;
            }
        }

        protected DoubleZeroCardEpoch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoubleZeroCardEpoch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoubleZeroCardEpoch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoubleZeroCardEpoch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoubleZeroCardEpoch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOUBLEZEROCARDEPOCH", dataRow) { }
        protected DoubleZeroCardEpoch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOUBLEZEROCARDEPOCH", dataRow, isImported) { }
        public DoubleZeroCardEpoch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoubleZeroCardEpoch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoubleZeroCardEpoch() : base() { }

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