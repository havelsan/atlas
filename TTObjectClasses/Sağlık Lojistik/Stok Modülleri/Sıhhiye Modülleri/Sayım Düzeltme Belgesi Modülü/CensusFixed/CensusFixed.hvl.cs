
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CensusFixed")] 

    /// <summary>
    /// Sayım Düzeltme Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class CensusFixed : StockAction, IStockOutTransaction, IAutoDocumentNumber, IStockInTransaction, IAutoDocumentRecordLog, ICensusFixed, ICheckStockActionInDetail, ICheckStockActionOutDetail
    {
        public class CensusFixedList : TTObjectCollection<CensusFixed> { }
                    
        public class ChildCensusFixedCollection : TTObject.TTChildObjectCollection<CensusFixed>
        {
            public ChildCensusFixedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCensusFixedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCensusFixedCensusReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXED"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCensusFixedCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCensusFixedCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCensusFixedCensusReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusFixedReportForReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXEDMATERIALOUT"].AllPropertyDefs["CARDAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXEDMATERIALOUT"].AllPropertyDefs["CENSUSAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXEDMATERIALOUT"].AllPropertyDefs["AMOUNT"].DataType;
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

            public Object Sira
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SIRA"]);
                }
            }

            public int? Sirano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIRANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXEDMATERIALOUT"].AllPropertyDefs["CHATTELDOCDETAILORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public CensusFixedReportForReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusFixedReportForReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusFixedReportForReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("1b960acc-0ba5-4b0c-ab2d-8c4ba1f46e6a"); } }
            public static Guid Cancelled { get { return new Guid("2bd249d5-7d84-44d0-b359-59a53b3951b7"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("d6edd23c-fb88-4677-98be-8331ee36ed64"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("70453b7c-8e89-4681-b4f2-fc977be6c89d"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("41ff8c38-df1b-4a1a-be7b-d7abb35f3467"); } }
        }

        public static BindingList<CensusFixed.GetCensusFixedCensusReportQuery_Class> GetCensusFixedCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXED"].QueryDefs["GetCensusFixedCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<CensusFixed.GetCensusFixedCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusFixed.GetCensusFixedCensusReportQuery_Class> GetCensusFixedCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXED"].QueryDefs["GetCensusFixedCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<CensusFixed.GetCensusFixedCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CensusFixed.CensusFixedReportForReportQuery_Class> CensusFixedReportForReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXED"].QueryDefs["CensusFixedReportForReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<CensusFixed.CensusFixedReportForReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CensusFixed.CensusFixedReportForReportQuery_Class> CensusFixedReportForReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CENSUSFIXED"].QueryDefs["CensusFixedReportForReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<CensusFixed.CensusFixedReportForReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// MKYS Giriş Kontrol 
    /// </summary>
        public bool? InMkysControl
        {
            get { return (bool?)this["INMKYSCONTROL"]; }
            set { this["INMKYSCONTROL"] = value; }
        }

        public int? MKYS_AyniyatMakbuzIDGiris
        {
            get { return (int?)this["MKYS_AYNIYATMAKBUZIDGIRIS"]; }
            set { this["MKYS_AYNIYATMAKBUZIDGIRIS"] = value; }
        }

    /// <summary>
    /// MKYS Çıkış Kontrol 
    /// </summary>
        public bool? OutMkysControl
        {
            get { return (bool?)this["OUTMKYSCONTROL"]; }
            set { this["OUTMKYSCONTROL"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _CensusFixedInMaterials = new CensusFixedMaterialIn.ChildCensusFixedMaterialInCollection(_StockActionDetails, "CensusFixedInMaterials");
            _CensusFixedOutMaterials = new CensusFixedMaterialOut.ChildCensusFixedMaterialOutCollection(_StockActionDetails, "CensusFixedOutMaterials");
        }

        private CensusFixedMaterialIn.ChildCensusFixedMaterialInCollection _CensusFixedInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public CensusFixedMaterialIn.ChildCensusFixedMaterialInCollection CensusFixedInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _CensusFixedInMaterials;
            }            
        }

        private CensusFixedMaterialOut.ChildCensusFixedMaterialOutCollection _CensusFixedOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public CensusFixedMaterialOut.ChildCensusFixedMaterialOutCollection CensusFixedOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _CensusFixedOutMaterials;
            }            
        }

        protected CensusFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CensusFixed(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CensusFixed(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CensusFixed(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CensusFixed(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CENSUSFIXED", dataRow) { }
        protected CensusFixed(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CENSUSFIXED", dataRow, isImported) { }
        public CensusFixed(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CensusFixed(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CensusFixed() : base() { }

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