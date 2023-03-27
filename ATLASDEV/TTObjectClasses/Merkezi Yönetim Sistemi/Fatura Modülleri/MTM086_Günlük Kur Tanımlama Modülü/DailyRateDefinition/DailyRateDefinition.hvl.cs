
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyRateDefinition")] 

    /// <summary>
    /// Günlük Kur Tanımı
    /// </summary>
    public  partial class DailyRateDefinition : TTDefinitionSet
    {
        public class DailyRateDefinitionList : TTObjectCollection<DailyRateDefinition> { }
                    
        public class ChildDailyRateDefinitionCollection : TTObject.TTChildObjectCollection<DailyRateDefinition>
        {
            public ChildDailyRateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyRateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDailyRateDefinitions_Class : TTReportNqlObject 
        {
            public Currency? DailyRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYRATEDEFINITION"].AllPropertyDefs["DAILYRATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DAILYRATEDEFINITION"].AllPropertyDefs["RATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Currencytypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENCYTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Currencyratetypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENCYRATETYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYRATETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDailyRateDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDailyRateDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDailyRateDefinitions_Class() : base() { }
        }

        public static BindingList<DailyRateDefinition.GetDailyRateDefinitions_Class> GetDailyRateDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYRATEDEFINITION"].QueryDefs["GetDailyRateDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DailyRateDefinition.GetDailyRateDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DailyRateDefinition.GetDailyRateDefinitions_Class> GetDailyRateDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYRATEDEFINITION"].QueryDefs["GetDailyRateDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DailyRateDefinition.GetDailyRateDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DailyRateDefinition> GetDailyRateByDateAndCurrType(TTObjectContext objectContext, string PARAMCURRTYPE, DateTime STARTDATE, DateTime ENDDATE, string RATETYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DAILYRATEDEFINITION"].QueryDefs["GetDailyRateByDateAndCurrType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCURRTYPE", PARAMCURRTYPE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RATETYPE", RATETYPE);

            return ((ITTQuery)objectContext).QueryObjects<DailyRateDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? RateDate
        {
            get { return (DateTime?)this["RATEDATE"]; }
            set { this["RATEDATE"] = value; }
        }

    /// <summary>
    /// Günlük Kur
    /// </summary>
        public Currency? DailyRate
        {
            get { return (Currency?)this["DAILYRATE"]; }
            set { this["DAILYRATE"] = value; }
        }

        public CurrencyRateTypeDefinition CurrencyRateType
        {
            get { return (CurrencyRateTypeDefinition)((ITTObject)this).GetParent("CURRENCYRATETYPE"); }
            set { this["CURRENCYRATETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CurrencyTypeDefinition CurrencyType
        {
            get { return (CurrencyTypeDefinition)((ITTObject)this).GetParent("CURRENCYTYPE"); }
            set { this["CURRENCYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReceiptCollection()
        {
            _Receipt = new Receipt.ChildReceiptCollection(this, new Guid("b8b02e00-d86e-4a05-84f2-fdb29937ecfc"));
            ((ITTChildObjectCollection)_Receipt).GetChildren();
        }

        protected Receipt.ChildReceiptCollection _Receipt = null;
        public Receipt.ChildReceiptCollection Receipt
        {
            get
            {
                if (_Receipt == null)
                    CreateReceiptCollection();
                return _Receipt;
            }
        }

        protected DailyRateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyRateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyRateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyRateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyRateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYRATEDEFINITION", dataRow) { }
        protected DailyRateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYRATEDEFINITION", dataRow, isImported) { }
        public DailyRateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyRateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyRateDefinition() : base() { }

    }
}