
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsignedCensusFixed")] 

    /// <summary>
    /// Muvakkaten Sayım Düzeltme Belgesi  için kullanılan temel sınıftır
    /// </summary>
    public  partial class ConsignedCensusFixed : StockAction, IAutoDocumentRecordLog, IConsignedCensusFixed, IStockConsumptionTransaction, IAutoDocumentNumber, IStockProductionTransaction
    {
        public class ConsignedCensusFixedList : TTObjectCollection<ConsignedCensusFixed> { }
                    
        public class ChildConsignedCensusFixedCollection : TTObject.TTChildObjectCollection<ConsignedCensusFixed>
        {
            public ChildConsignedCensusFixedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsignedCensusFixedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ConsignedCensusFixedReportForReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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

            public Currency? CardAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSIGNEDCENSUSFIXEDMATERIALOUT"].AllPropertyDefs["CARDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CensusAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CENSUSAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSIGNEDCENSUSFIXEDMATERIALOUT"].AllPropertyDefs["CENSUSAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSIGNEDCENSUSFIXEDMATERIALOUT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Unitprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNITPRICE"]);
                }
            }

            public Object Islemtipi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMTIPI"]);
                }
            }

            public ConsignedCensusFixedReportForReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsignedCensusFixedReportForReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsignedCensusFixedReportForReportQuery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("9fa02815-6723-49a5-bf00-04dfaf25419c"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("3a5673da-ed16-4ce8-8159-6959fd17372e"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("a06f3564-17a9-4939-9440-4359ee042dea"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("7d88eeea-6f5d-479f-9861-817cde447c37"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("f849ab38-d1dc-43b6-a916-940dca4ff36b"); } }
        }

        public static BindingList<ConsignedCensusFixed.ConsignedCensusFixedReportForReportQuery_Class> ConsignedCensusFixedReportForReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSIGNEDCENSUSFIXED"].QueryDefs["ConsignedCensusFixedReportForReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ConsignedCensusFixed.ConsignedCensusFixedReportForReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ConsignedCensusFixed.ConsignedCensusFixedReportForReportQuery_Class> ConsignedCensusFixedReportForReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONSIGNEDCENSUSFIXED"].QueryDefs["ConsignedCensusFixedReportForReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ConsignedCensusFixed.ConsignedCensusFixedReportForReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ConsignedCensusFixedInMaterials = new ConsignedCensusFixedMaterialIn.ChildConsignedCensusFixedMaterialInCollection(_StockActionDetails, "ConsignedCensusFixedInMaterials");
            _ConsignedCensusFixedOutMaterials = new ConsignedCensusFixedMaterialOut.ChildConsignedCensusFixedMaterialOutCollection(_StockActionDetails, "ConsignedCensusFixedOutMaterials");
        }

        private ConsignedCensusFixedMaterialIn.ChildConsignedCensusFixedMaterialInCollection _ConsignedCensusFixedInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ConsignedCensusFixedMaterialIn.ChildConsignedCensusFixedMaterialInCollection ConsignedCensusFixedInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ConsignedCensusFixedInMaterials;
            }            
        }

        private ConsignedCensusFixedMaterialOut.ChildConsignedCensusFixedMaterialOutCollection _ConsignedCensusFixedOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ConsignedCensusFixedMaterialOut.ChildConsignedCensusFixedMaterialOutCollection ConsignedCensusFixedOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ConsignedCensusFixedOutMaterials;
            }            
        }

        protected ConsignedCensusFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsignedCensusFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsignedCensusFixed(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsignedCensusFixed(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsignedCensusFixed(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSIGNEDCENSUSFIXED", dataRow) { }
        protected ConsignedCensusFixed(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSIGNEDCENSUSFIXED", dataRow, isImported) { }
        public ConsignedCensusFixed(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsignedCensusFixed(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsignedCensusFixed() : base() { }

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