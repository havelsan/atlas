
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CurrencyRateTypeDefinition")] 

    /// <summary>
    /// Kur Alış Satış Tipi
    /// </summary>
    public  partial class CurrencyRateTypeDefinition : TerminologyManagerDef
    {
        public class CurrencyRateTypeDefinitionList : TTObjectCollection<CurrencyRateTypeDefinition> { }
                    
        public class ChildCurrencyRateTypeDefinitionCollection : TTObject.TTChildObjectCollection<CurrencyRateTypeDefinition>
        {
            public ChildCurrencyRateTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCurrencyRateTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCurrencyRateTypeDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYRATETYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYRATETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCurrencyRateTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrencyRateTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrencyRateTypeDefinitions_Class() : base() { }
        }

        public static BindingList<CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions_Class> GetCurrencyRateTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYRATETYPEDEFINITION"].QueryDefs["GetCurrencyRateTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions_Class> GetCurrencyRateTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYRATETYPEDEFINITION"].QueryDefs["GetCurrencyRateTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CurrencyRateTypeDefinition.GetCurrencyRateTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CurrencyRateTypeDefinition> GetCurrencyRateTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYRATETYPEDEFINITION"].QueryDefs["GetCurrencyRateTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CurrencyRateTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateDailyRateDefinitionCollection()
        {
            _DailyRateDefinition = new DailyRateDefinition.ChildDailyRateDefinitionCollection(this, new Guid("92e4d2ce-48f1-4e05-bb37-817694092e73"));
            ((ITTChildObjectCollection)_DailyRateDefinition).GetChildren();
        }

        protected DailyRateDefinition.ChildDailyRateDefinitionCollection _DailyRateDefinition = null;
        public DailyRateDefinition.ChildDailyRateDefinitionCollection DailyRateDefinition
        {
            get
            {
                if (_DailyRateDefinition == null)
                    CreateDailyRateDefinitionCollection();
                return _DailyRateDefinition;
            }
        }

        protected CurrencyRateTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CurrencyRateTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CurrencyRateTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CurrencyRateTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CurrencyRateTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CURRENCYRATETYPEDEFINITION", dataRow) { }
        protected CurrencyRateTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CURRENCYRATETYPEDEFINITION", dataRow, isImported) { }
        public CurrencyRateTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CurrencyRateTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CurrencyRateTypeDefinition() : base() { }

    }
}