
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CurrencyTypeDefinition")] 

    /// <summary>
    /// Para birimleri tanimi
    /// </summary>
    public  partial class CurrencyTypeDefinition : TerminologyManagerDef
    {
        public class CurrencyTypeDefinitionList : TTObjectCollection<CurrencyTypeDefinition> { }
                    
        public class ChildCurrencyTypeDefinitionCollection : TTObject.TTChildObjectCollection<CurrencyTypeDefinition>
        {
            public ChildCurrencyTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCurrencyTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCurrencyTypeDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public GetCurrencyTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrencyTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrencyTypeDefinitions_Class() : base() { }
        }

        public static BindingList<CurrencyTypeDefinition> GetByQref(TTObjectContext objectContext, string PRAMQREF)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].QueryDefs["GetByQref"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRAMQREF", PRAMQREF);

            return ((ITTQuery)objectContext).QueryObjects<CurrencyTypeDefinition>(queryDef, paramList);
        }

        public static BindingList<CurrencyTypeDefinition.GetCurrencyTypeDefinitions_Class> GetCurrencyTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].QueryDefs["GetCurrencyTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CurrencyTypeDefinition.GetCurrencyTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CurrencyTypeDefinition.GetCurrencyTypeDefinitions_Class> GetCurrencyTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].QueryDefs["GetCurrencyTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CurrencyTypeDefinition.GetCurrencyTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CurrencyTypeDefinition> GetCurrencyTypeDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].QueryDefs["GetCurrencyTypeDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CurrencyTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
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

    /// <summary>
    /// Kısa Ad
    /// </summary>
        public string Qref
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Tam Kısım Sembolü (TL, Dolar vb)
    /// </summary>
        public string LeftSymbol
        {
            get { return (string)this["LEFTSYMBOL"]; }
            set { this["LEFTSYMBOL"] = value; }
        }

    /// <summary>
    /// Küsürat Sembolü (Kr,Sent vb.)
    /// </summary>
        public string RightSymbol
        {
            get { return (string)this["RIGHTSYMBOL"]; }
            set { this["RIGHTSYMBOL"] = value; }
        }

        virtual protected void CreateDailyRateDefinitionCollection()
        {
            _DailyRateDefinition = new DailyRateDefinition.ChildDailyRateDefinitionCollection(this, new Guid("517bc633-9be7-4e18-8492-81904f0a1e59"));
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

        protected CurrencyTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CurrencyTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CurrencyTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CurrencyTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CurrencyTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CURRENCYTYPEDEFINITION", dataRow) { }
        protected CurrencyTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CURRENCYTYPEDEFINITION", dataRow, isImported) { }
        public CurrencyTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CurrencyTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CurrencyTypeDefinition() : base() { }

    }
}